#include <msp430.h>//C:\Users\evert\workspace_v5_5\Transmissor_USCIA_TX
#include <Temporizador.h>
#include "gerenciador_memoria.h"

#pragma vector=TIMER1_A1_VECTOR
__interrupt void TIMER1_A1_ISR_HOOK(void){//RTI do timer E421
	switch (TA1IV) {
	case TA1IV_TACCR2:  //canal 2, //Vem pra cá a cada intervalo de tempo definido pelo ta1ccr2
		if (!imp_user){ //se nao esta imprimindo mensagens comuns, transmita dados da memoria
			if (e == 0) { //estado de decisao, se envia string ou sequencia de dados RAWs
				if (qtd_itens_fila) {  //se tem item na fila, pega ele
					pc = fila_msgs[0]; //pega o primeiro elemento. Obs: deixa por enquanto esse warning, pois assim funcionou. /*pc = msg; pc = paux; int x;  = 0;*/
					byte ite;  //indexador ou iterador
					for (ite = 0; ite < (qtd_itens_fila - 1); ite++) //deslocamento os ponteiros
						fila_msgs[ite] = fila_msgs[ite + 1]; //desloca os elementos na fila, caminhando a fila...
					qtd_itens_fila--;

					IE2 |= UCA0TXIE;	e = 1;
				} else if(svt){//ha dados para mostrar?
					if (++cont >= 10) { //momento de ver se é para enviar os RAWs, até que a contagem chegue
						IE2 |= UCA0TXIE; e = 3;
					} //@100 ms
				}//else if (svt)
			} //if e == 0
		}//if imp_ser igual a zero.

		TA1CCR2 += TEMPO_TICK; // timer1 contando até seu máximo de 65535(modo 2)
		tick++;//obrigatório para que a biblioteca do temporizador funcione
		break;
	}// fim switch taiv
}//RTI Timer1 canal2 usado */

#pragma vector=USCIAB0TX_VECTOR
__interrupt void USCI0TX_ISR(void){	//1) versão com break;
	static byte i = 0, j = 0, txCount = 0, n = 0, parteL_H = 0;//i e j indices da matriz esparsa

	//if(e) //para implementacao futura de algo bem interessante
	if (txCount < 2)//transmitir os dois bytes
		UCA0TXBUF = (txCount++)? e : 255;//transmite 255 e depois "e"
	else {//transmitir conforme o ID , i.e, e
		if (e == 1) {//enviar string
			if (*pc == 0) {
				IE2 &= ~UCA0TXIE;
				e = txCount = 0;
			}
			else UCA0TXBUF = *pc++;
		}
		else if (e == 3) {//enviar dados RAWs
			if (i < svt) {//há dados de vetores para mostrar?
				UCA0TXBUF = vetor_ptr[i][j];
				if (j >= vetor_qtd[i]) { j = 0; i++;} else j++;
			} else if ( n < nreg ){//há registradores de 16 bits para mostrar na tabela?
				if (parteL_H) { UCA0TXBUF = (byte)( *vetor_reg16[n] & 0x00FF ); n++; }
				else {UCA0TXBUF  = (byte)( (*vetor_reg16[n] >> 8) & 0x00FF);}
				parteL_H ^= 1;
			}
			else {i = j = txCount = parteL_H = n = 0, clear_e_cont_txie;}
		}//else if (e == 3) //dados RAWs quer seja de 8 bits ou de 16 bits

	}//else => txCount = 2; , transmitir conforme o id!

	/*else {//Futuro uso
		//imp_user = 1; e depois zera imp_user tx_uart_USER_via_RTI nao bloqueante
	}*/
}//interrupcao TX

/*UCA0TXBUF = parteL_H++?  (unsigned char)((*vetor_reg16[n++] >> 8) & 0x00FF): //parte ALTA
									   (unsigned char)(*vetor_reg16[n] & 0x00FF);//parte BAIXA*/

#pragma vector=USCIAB0RX_VECTOR
__interrupt void USCI0RX_ISR(void){
	static byte ordem = 0; static byte buffer_rx[6];//sem inicializacao mesmo

	if(UCA0STAT & UCBRK) {//detectou o break gerado pelo C#?
		UCA0STAT &= ~UCBRK; ordem = 1; buffer_rx[1] = UCA0RXBUF - 2;//valor sentinela para aguardar receber o segundo RxData, i.e, a qtd de argumentos
	} else if (ordem){//if estado qualquer valor diferente de zero
		buffer_rx[ordem - 1] = UCA0RXBUF;//armazena cada dado no buffer //0: CMD, 1: QTD_dados: 2 a varios dados: os dados ou nao	//244,      1: 1

		if ( buffer_rx[1] == (ordem - 2) ){//recebeu todos os parametros?  buffer_rx[0]=>CMD e buffer_rx[1]=> a QTD de argumentos //decodificar o comando que está no buffer
			#define end16   ((unsigned int)(buffer_rx[2 + 1] << 8) + (unsigned int)buffer_rx[2])
			switch(buffer_rx[0]){//qual comando? e faça o que tem que ser feito para o comando
			case 251://comando write no "indice" da tabela do C#
				write_ind(buffer_rx[2], buffer_rx[2 + 1]);//*(vetor_ptr[indice]) = valor;
				break;
			case 190://BITSET, //BITCLEAR, BITINV respectivamente
			case 191:
			case 192://comandos 190 a 192 de TRÊS argumentos://indice (baixo), indice_alto, valor
				if (buffer_rx[0] == 190) 		*(byte*)end16 |= buffer_rx[2 + 2];//setar
				else if (buffer_rx[0] == 191) 	*(byte*)end16 &= ~buffer_rx[2 + 2];//limpar
				else 							*(byte*)end16 ^= buffer_rx[2 + 2];//inverter
				break;
			case 193: aloc_addr((MEM) end16,  buffer_rx[2 + 2]); break;
			case 194: aloc_reg((REG16) end16); break;
			case 195: obter_inds(0); break;
			case 247: __bic_SR_register_on_exit(LPM0_bits); break;//despausa a main //RUN
			case 246: __bis_SR_register_on_exit(LPM0_bits); break;//pausar //pausa a main o
			case 245: WDTCTL = 0; 							break;//Resetar por PUC
			}//switch buffer_rx[0]

			ordem = 255; //feito? então retorne 2, mas colocando o estado em zero
		}//else if buffer_re == estado - 2
		
		ordem++;//avanca ordem do dado ou o dado vai para zero caso tiver executado o CMD que tiver de fazer
	} else
		
	{//Recepcao do usuario. comandos r, s, p: Reset, String TESTE, Pausa a CPU do MSP
		if (UCA0RXBUF == 'r')// 'r' reseta por software a gerar o reset PUC por error de senha do WDT
			WDTCTL = 0;

		if (UCA0RXBUF == 's'){// 's' imprime a string TESTE para ver se imprime em qualquer tempo aleatorio desejado, ok
			imprima_gerenciador(msg);//imprime a mensagem de TESTE
			_bic_SR_register_on_exit(LPM0_bits);//despausa a main     LPM0_EXIT     //_bis_SR_register_on_exit(LPM0 + GIE);
		}

		if (UCA0RXBUF == 'p'){// mudando o valor da porta para ver, ok
			P3OUT = P3IN + (1 << 5);
			__bis_SR_register_on_exit(LPM0_bits );//pausa a main
		}
	}
	
}//RTI RX

