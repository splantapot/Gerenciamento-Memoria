/*
 * Escrita_memoria.c
 *
 *  Created on: 08/05/2026
 *      Author: evert
 *      Para escrever em uma dada posição da memória
 */
#include <msp430g2553.h>
//#include "gerenciador_memoria.h"

unsigned char escreve_endereco(unsigned char dado) {
	static unsigned char comando = 0; static unsigned char estado = 0;//estado inicializado com zero

	if(break_condicao) {//detectou o break gerado pelo C#?
		UCA0STAT &= ~UCBRK;  estado = 1;
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
	        *(unsigned char*)end16 |= dado;
	        return 3;
	        break;
	    case 5:// BITCLR
	        estado = 0;
	        end16 = (((unsigned int) (indice_alto << 8)) + ((unsigned int) indice));
	        *(unsigned char*)end16 &= ~dado;
	        return 3;
	        break;
	    case 6:// BITCLR
	        estado = 0;
	        end16 = (((unsigned int) (indice_alto << 8)) + ((unsigned int) indice));
	        *(unsigned char*)end16 ^= dado;
	        return 3;
	        break;
	    }//switch estado

	return estado;
}//escreve_endereco()

void imprima_gerenciador(char* ptr_C) {//Funcao NAO bloqueante
	fila_msgs[qtd_itens_fila++] = ptr_C;  		//adiciona o ponteiro a fila
	if (qtd_itens_fila > 3) {
		pc = "ERROR_FILA_CHEIA\n";//<<<<<<<<
		qtd_itens_fila = 3;
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

/*case 2: // Recebe byte baixo do endereço
		addr_low = dado;
		endereco16 = ((unsigned int) indice << 8) | addr_low;
		estado = 3;
		break;
		// grava somente o dado de 8 bits no endereço de 16 bits válido
		if((endereco16 >= 0x0200) && (endereco16 <= 0x03FF))
			*((volatile unsigned char *) endereco16) = valor8;
*/





