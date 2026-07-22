/* * gerenciador_memoria.h*/

#ifndef GERENCIADOR_MEMORIA_H_
#define GERENCIADOR_MEMORIA_H_
#include <stdlib.h>

#define byte unsigned char
#define uint16 unsigned int

#define MEM volatile byte*
typedef volatile unsigned int* REG16;
extern char* msg;//DEON apagar depois
extern REG16* vetor_reg16;

extern MEM* vetor_ptr; extern MEM vetor_qtd; extern byte svt; extern byte nreg;
extern byte e, imp_user, cont;

extern volatile byte* pc;
extern byte qtd_itens_fila; extern char* fila_msgs[];

//prototipos de funções
void imprima_gerenciador(char* ptr_C);
void imprima_user(char* ptr_C);
byte aloc_reg(REG16 p);
byte aloc_addr(MEM p, byte tam);
void obter_inds(byte bytes_to_add);  // Obtém confirmação de índices
void write_ind(byte indice, byte valor);
void write_reg(byte indice, byte valorL, byte valorH);

#define clear_e_cont_txie e = 0; cont = 0; IE2 &= ~UCA0TXIE;
#endif /* GERENCIADOR_MEMORIA_H_ */
