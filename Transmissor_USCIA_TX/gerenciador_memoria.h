/* * gerenciador_memoria.h*/

#ifndef GERENCIADOR_MEMORIA_H_
#define GERENCIADOR_MEMORIA_H_
#include <stdlib.h>
#define MEM volatile unsigned char*
#define byte unsigned char

extern MEM* vetor_ptr; extern MEM vetor_qtd;
extern byte svt;

extern volatile byte* pc;
extern byte qtd_itens_fila; extern char* fila_msgs[]; //char* paux=  (char*)0xC44C;

extern byte e, imp_user;//P3OUT is 19 in hex
extern volatile byte break_condicao;

//prototipos de funções
void imprima_gerenciador(char* ptr_C);
void imprima_user(char* ptr_C);
unsigned char escreve_endereco(byte dado);
byte aloc_addr(MEM p, byte tam);///<<<<
void write_ind(byte indice, byte valor);///<<<<

enum EnumTxEtapas {HEADER, ID, TX_DADOS, FAZ_NADA}; extern enum EnumTxEtapas txEtapa;// = FAZ_NADA;//??static é possiveo?

#define clear_e_cont_txie_pc e = 0; cont = 0; IE2 &= ~UCA0TXIE; pc = 0
#endif /* GERENCIADOR_MEMORIA_H_ */
