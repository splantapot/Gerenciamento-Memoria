#include <msp430.h>//C:\Users\evert\workspace_v5_5\Transmissor_USCIA_TX
#include "gerenciador_memoria.h"
#define TEMPO_TICK 10000 //resolver essa duplicidade aqui depois
extern unsigned int tick;//biblioteca temporizador

byte cont = 0;//contador de amostragem dos RAWs
char* msg = "TESTE\r\n";//DEON //<<<<<<<<<<apagar depois

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
				}

				if (pc != 0) {  //tenho string vindo da fila?//
					IE2 |= UCA0TXIE;
					e = 1;
					txEtapa = HEADER;  //tendo, imprima-a
				} else
					if(svt){//ha dados para mostrar?
						if (++cont >= 10) { //momento de ver se é para enviar os RAWs, até que a contagem chegue
							IE2 |= UCA0TXIE;
							e = 3;
							txEtapa = HEADER; //<<<<<<<<<<<i = 1;
						} //100 ms
					}//if (svt)
			} //if e == 0
		}//if imp_ser igual a zero.

		TA1CCR2 += TEMPO_TICK; // timer1 contando até seu máximo de 65535(modo 2)
		tick++;//obrigatório para que a biblioteca do temporizador funcione
		break;
	}// fim switch taiv
}//RTI Timer1 canal2 usado */

#pragma vector=USCIAB0TX_VECTOR
__interrupt void USCI0TX_ISR(void){	//1) versão com break;
	static byte i = 0; static byte j = 0;//indices da matriz esparsa

	switch (txEtapa) {
	case TX_DADOS:
		switch (e) {
		case 1:
			if (*pc == 0){//fim da string, i.e, feito?
				e = 0;  IE2 &= ~UCA0TXIE; pc = 0;	//clear_e_cont_txie_pc;
				txEtapa = FAZ_NADA;//desnecessario mesmo isto? penso que sim no momento
			} //pc em zero é o mesmo indicativo de TXie em zero, talvez desnecessário ter que zerar ele
			else { UCA0TXBUF = *pc++; }//nao, i,e, caracteres ainda a enviar
			break;

		case 3:
			if (i < svt ){
				UCA0TXBUF = vetor_ptr[i][j];//aponta para o raw e avança o indice i
				if (j >= vetor_qtd[i]){
					j = 0; i++;
				} else j++;
			} else {
				i = j = 0; clear_e_cont_txie_pc;
				txEtapa = FAZ_NADA;
			}//else if i < svt

			break;

			//UCA0TXBUF = *vetor_ptr[i++];//aponta para o raw e avança o indice i
			//if (i > (4 - 1)) {//enviou todos os raws? /*sizeof(vetor_ptr)>>1)*/
			//	i = 0;//0 1 2
			//	clear_e_cont_txie_pc;
			//	txEtapa = FAZ_NADA;//desnecessario mesmo isto? penso que sim no momento
			//}//se enviou todos os raws
			//break;

		}//fim do switch
		break;

	case ID:
		UCA0TXBUF = e; txEtapa = TX_DADOS;
		break;
	case HEADER:// É necessário enviar um "dummy byte" para disparar a sequência// UCA0TXBUF = 0x00;
		UCA0TXBUF = 255; txEtapa = ID;
		break;
	case FAZ_NADA:
		break;
	}//switch

	//if (e == 0){//para impressao de dados do usuario nao bloqueante, i.e, via interrupcao
		//imp_user = 1;
	//}
}//interrupcao TX

#pragma vector=USCIAB0RX_VECTOR
__interrupt void USCI0RX_ISR(void){
	//aplicaçao de escrita na memoria
	break_condicao = UCA0STAT & UCBRK;
	unsigned char dado;	dado = UCA0RXBUF;//leitura do dado recebido na UART RX
	unsigned char retorno = escreve_endereco(dado);//Se estritamente necessário, escreve no endereço
	if (retorno == 247) __bic_SR_register_on_exit(LPM0_bits);//só vai se deixar aqui

	//comandos r, s, p: Reset, String TESTE, Pausa a CPU do MSP
	if (!retorno){//se não estiver ocupada a recepção com o recebimento dos bytes de escrita na memória, receba os comandos do INFERIOR_DIREITO
		if (dado == 'r')// 'r' reseta por software a gerar o reset PUC por error de senha do WDT
			WDTCTL = 0;

		if (dado == 's'){// 's' imprime a string TESTE para ver se imprime em qualquer tempo aleatorio desejado, ok
			imprima_gerenciador(msg);//imprime a mensagem de TESTE
			_bic_SR_register_on_exit(LPM0_bits);//despausa a main     LPM0_EXIT     //_bis_SR_register_on_exit(LPM0 + GIE);
		}

		if (dado == 'p'){// mudando o valor da porta para ver, ok
			P3OUT = P3IN + (1 << 5);//__bis_SR_register_on_exit(LPM0);
			__bis_SR_register_on_exit(LPM0_bits );//pausa a main ou     sem | GIE da o mesmo efeito. Faz sentido, pois só seta o CPUOFF
		}
	}

}//RTI RX

/*
 //fila_msgs[qtd++] = msg;//fila_msgs
 //if (qtd_itens_fila > 3) {pc = "ERROR_FILA_CHEIA\r\n"; qtd = 3;}
 * */
