/*
 * gerenciador_memoria.c
 *
 *  Created on: 05/06/2026
 *      Author: evert
 */
#include <msp430g2553.h>
#include "gerenciador_memoria.h"
char* msg = "TESTE\r\n";//DEON //<<<<<<<<<<apagar depois

MEM* vetor_ptr = NULL; MEM vetor_qtd = NULL; byte svt = 0;//indica a quantidade de vetores de uma ou mais posições.
byte e = 0; byte imp_user = 0; byte cont = 0;//contador de amostragem dos RAWs.

volatile byte* pc = 0; //pc aponta para ninguem. Com volatile, ele é obrigado a ler da memória toda vez.
byte qtd_itens_fila = 0; char* fila_msgs[5]; //fila

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
	    obter_inds(tam);
		//imprima_gerenciador("ao\n"); //alocacão ok
		//while(e); todo aguarda a transmissao da msg antes de retornar
		return 1;//sucesso
	} else {
		imprima_gerenciador("Error_aloc_memoria\n");
		//while(e); todo aguarda a transmissao da msg antes de retornar
		return 0;//falha na alocacao!
	}
}//funcao add_addr

// Escreve a confirmação da quantidade de índices salva, no formato: "ao000\n"
void obter_inds(byte bytes_to_add) {
    static byte tam_N = 0; // Quantos bytes de índice temos no total
    tam_N += bytes_to_add;
    char msg_confirmacao[7] = {
      'a','o',
      '0' + (tam_N/100),
      '0' + ((tam_N%100)/10),
      '0' + (tam_N%10),
      '\n', '\0'
    };
    imprima_gerenciador(msg_confirmacao);
}//funcao obter_inds

void write_ind(byte indice, byte valor){
	byte i, j, it = 0;
	for (i = 0; i < svt; i++) {
		for (j = 0; j <= vetor_qtd[i]; j++) {//<<<< aqui
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






