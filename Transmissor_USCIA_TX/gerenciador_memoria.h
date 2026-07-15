/* * gerenciador_memoria.h*/

#ifndef GERENCIADOR_MEMORIA_H_
#define GERENCIADOR_MEMORIA_H_
#include <stdlib.h>
#define byte unsigned char
#define MEM volatile byte*
extern char* msg;//DEON apagar depois

extern MEM* vetor_ptr; extern MEM vetor_qtd; extern byte svt;
extern byte e, imp_user, cont;

extern volatile byte* pc;
extern byte qtd_itens_fila; extern char* fila_msgs[];

//prototipos de funções
void imprima_gerenciador(char* ptr_C);
void imprima_user(char* ptr_C);
byte aloc_addr(MEM p, byte tam);
void obter_inds(byte bytes_to_add);  // Obtém confirmação de índices
void write_ind(byte indice, byte valor);

#define clear_e_cont_txie_pc e = 0; cont = 0; IE2 &= ~UCA0TXIE; pc = 0
#endif /* GERENCIADOR_MEMORIA_H_ */
