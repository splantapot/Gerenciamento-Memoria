/*
 * gerenciador_memoria.c
 *
 *  Created on: 05/06/2026
 *      Author: evert
 */
#include <msp430g2553.h>
#include "gerenciador_memoria.h"

volatile byte var = 0xF0;//DEON; por enquanto aqui
volatile unsigned int end16; volatile byte indice, indice_alto, valor;//todo deletar depois

MEM* vetor_ptr = NULL;// = {&indice, &indice_alto, &P3OUT, &var};////na RTI defino o vetor  &v4}; //<<<<<<<<<{&P1IN, &P2IN, &P3IN, &v4};
MEM vetor_qtd = NULL;// = {&indice, &indice_alto, &P3OUT, &var};////na RTI defino o vetor  &v4}; //<<<<<<<<<{&P1IN, &P2IN, &P3IN, &v4};
byte svt = 0;//indica a quantidade de vetores de uma ou mais posições.
//variaveis do gerenciador
volatile byte break_condicao;//acessivel
byte e = 0, cont = 0, i = 0, j = 0;//
enum EnumTxEtapas txEtapa = FAZ_NADA;//todo variaveis, permitir que o usuario definina variavieis como "i" global sem que haja erro de comp. Solucao: static quando for possível
//??static é possivel para enum?

// P3OUT is 19 in hex
volatile byte* pc = 0; //GERENCIADOR de memoria.  pc aponta para ninguem. Com volatile, ele é obrigado a ler da memória toda vez.
byte qtd_itens_fila = 0; char* fila_msgs[5]; //fila
byte imp_user = 0;//para informar se vai ter ou se está tendo imprimando de mensagens do usuario

byte escreve_endereco(byte dado) {
	static byte comando = 0;//todo essa variavel, vai deixar de existir.
	static byte estado = 0;//ficando só a variavel estado que é inicializado com zero
	static byte buffer_rx[6];//sem inicializacao mesmo

	if(break_condicao) {//detectou o break gerado pelo C#?
		UCA0STAT &= ~UCBRK;  estado = 1; buffer_rx[1] = 254;//valor sentinela para aguardar receber o segundo RxData, i.e, a qtd de argumentos
		return 1;
	}

	// break 251 2 0
	switch (estado) {//indice, valor, id
	    case 1: // Recebe byte de comando
	        estado = 2;
	        comando = dado;
	        break;
	    case 2:
	        estado = 3;
	        indice = dado;
	        break;
	        // valor = dado;
	    case 3:     // Recebe valor de 8 bits a ser escrito na memória
	        estado = 0;
	        valor = dado;
	        switch(comando) {//tipo de comando de escrita
	        // 0x0019;
	        case 190:   //BITSET
	            // cmd, indice (baixo), indice(alto), valor
	            estado = 4;
	            indice_alto = dado;
	            break;
	        case 191:   //BITCLR
	            // cmd, indice (baixo), indice(alto), valor
	            estado = 5;
	            indice_alto = dado;
	            break;
	        case 192:   //BITINV
	            // cmd, indice (baixo), indice(alto), valor
	            estado = 6;
	            indice_alto = dado;
	            break;

	            // Escreve efetivamente na memória, por índice
	        case 251:
	            *(vetor_ptr[indice]) = valor;
	            break;
	        }
	        return 3;
	        break;

	        default:
	            estado = 0;
	            break;

	    case 4:
	        // BITSET
	        estado = 0;
	        end16 = (((unsigned int) (indice_alto << 8)) + ((unsigned int) indice));
	        *(byte*)end16 |= dado;
	        return 3;
	        break;
	    case 5:
	        // BITCLR
	        estado = 0;
	        end16 = (((unsigned int) (indice_alto << 8)) + ((unsigned int) indice));
	        *(byte*)end16 &= ~dado;
	        return 3;
	        break;
	    case 6:
	        // BITCLR
	        estado = 0;
	        end16 = (((unsigned int) (indice_alto << 8)) + ((unsigned int) indice));
	        *(byte*)end16 ^= dado;
	        return 3;
	        break;
	    }//switch estado

	//nova ideia para recebimentos e tratamento de comandos especiais
	// break 251 DOIS_ARGS 2 0
	if (0)//todo a ser testado
	if (estado){//if estado qualquer valor diferente de zero
		buffer_rx[estado - 1] = dado;//armazena cada dado no buffer //0: CMD, 1: QTD_dados: 2 a varios dados: os dados ou nao	//244,      1: 1

		if ( buffer_rx[1] == (estado - 2) ){//recebeu todos os parametros?  buffer_rx[0]=>CMD e buffer_rx[1]=> a QTD de argumentos //decodificar o comando que está no buffer

			switch(buffer_rx[0]){//qual comando? e faça o que tem que ser feito para o comando
				case 251://comando write no "indice" da tabela do C#
					write_ind(buffer_rx[2], buffer_rx[2 + 1]);//*(vetor_ptr[indice]) = valor;
					break;
				case 190://BITSET, //BITCLEAR, BITINV respectivamente
				case 191:
				case 192://comandos 190 a 192 de TRÊS argumentos://indice (baixo), indice_alto, valor
					end16 = (((unsigned int) (buffer_rx[2 + 1] << 8)) + ((unsigned int) buffer_rx[2]));
					if (buffer_rx[0] == 190) 		*(byte*)end16 |= buffer_rx[2 + 2];//setar
					else if (buffer_rx[0] == 191) 	*(byte*)end16 &= ~buffer_rx[2 + 2];//limpar
					else 							*(byte*)end16 ^= buffer_rx[2 + 2];//inverter
					break;
				case 247: estado = 0; 							return 247;//break;//despausa a main //RUN
				case 246: __bis_SR_register_on_exit(LPM0_bits); break;//pausar //pausa a main o
				case 245: WDTCTL = 0; 							break;//Resetar por PUC
			}//switch buffer_rx[0]

			estado = 0; return 2;//feito? então retorne 2, mas colocando o estado em zero
		}//else if buffer_re == estado - 2

		estado++;
	}//if estado != de zero
	return estado;
}//escreve_endereco()

void imprima_gerenciador(char* ptr_C) {//Funcao NAO bloqueante
	fila_msgs[qtd_itens_fila++] = ptr_C;  		//adiciona o ponteiro a fila
	if (qtd_itens_fila > 5) {
		pc = "ERROR_FILA_CHEIA\n";//<<<<<<<<
		qtd_itens_fila = 5;
	}  		//=3 para saturar no fim, no error
}

void imprima_user(char* ptr_C) {//OK, funcionando perfeitamente, Funcao bloqueante
	imp_user = 1;  			//semaforo mais robusto.
	while (e != 0); 		//aguarda gerenciador de memoria ficar desocupado da transmissão de dados da memoria
	while (*ptr_C != 0) {   //imprime a string do usuario
		while (!(IFG2 & UCA0TXIFG));// Aguarda buffer livre
		UCA0TXBUF = *ptr_C++;
	}
	//while (!(IFG2 & UCA0TXIFG));
	//UCA0TXBUF = '\n';	//transmitir automaticamente o barra n? Ja testei assim e funcionou, ok
	//while(!UCA0STAT & UCBUSY);//opcional
	imp_user = 0;
}//imprima_user

//retorna 1 se deu certo a alocacao e 0 caso contrario
byte aloc_addr(MEM p, byte tam){//aloca endereço no vetor_ptr
	MEM* p1 = (MEM*)realloc(vetor_ptr,       (svt + 1)*sizeof(MEM)    );
	MEM p2 = (MEM)realloc((void*)vetor_qtd, (svt + 1) );
	if ((p1!= NULL) && (p2!= NULL)){
		vetor_ptr = p1; vetor_qtd = p2;
		vetor_ptr[svt] = p; vetor_qtd[svt] = tam - 1;//seria bom verificar o TAM
		svt++;
		imprima_gerenciador("ao\n");//alocacão ok
		//while(e); todo aguarda a transmissao da msg antes de retornar
		return 1;//sucesso
	} else {
		imprima_gerenciador("Error_aloc_memoria\n");
		//while(e); todo aguarda a transmissao da msg antes de retornar
		return 0;//falha na alocacao!
	}
}//funcao add_addr

void write_ind(byte indice, byte valor){//todo a ser testada
	byte i, j, it = 0;
	for (i = 0; i < svt; i++) {
		for (j = 0; j < vetor_qtd[i]; j++) {
			if (it == indice){
				vetor_ptr[i][j] = valor;
				return;
			}//if it
			it++;
		}//for j
	}//for i
}//write_ind
/*case 2: // Recebe byte baixo do endereço
		addr_low = dado;
		endereco16 = ((unsigned int) indice << 8) | addr_low;
		estado = 3;
		break;
		// grava somente o dado de 8 bits no endereço de 16 bits válido
		if((endereco16 >= 0x0200) && (endereco16 <= 0x03FF))
			*((volatile byte *) endereco16) = valor8;
*/






