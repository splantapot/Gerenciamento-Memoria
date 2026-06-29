/* * gerenciador_memoria.h*/

#ifndef GERENCIADOR_MEMORIA_H_
#define GERENCIADOR_MEMORIA_H_

extern volatile unsigned int end16; extern volatile unsigned char indice, indice_alto, valor;
extern volatile unsigned char* vetor_ptr[];// = {&indice, &indice_alto, &P3OUT, &var};// &v4}; //<<<<<<<<<{&P1IN, &P2IN, &P3IN, &v4};
extern volatile unsigned char* pc;
extern unsigned char qtd_itens_fila; extern char* fila_msgs[]; //char* paux=  (char*)0xC44C;
extern unsigned char e, cont, i, imp_user;// P3OUT is 19 in hex
extern volatile unsigned char break_condicao;

//prototipos de funções
void imprima_gerenciador(char* ptr_C);
void imprima_user(char* ptr_C);
unsigned char escreve_endereco(unsigned char dado);

enum EnumTxEtapas {HEADER, ID, TX_DADOS, FAZ_NADA}; extern enum EnumTxEtapas txEtapa;// = FAZ_NADA;//??static é possiveo?

#define clear_e_cont_txie_pc e = 0; cont = 0; IE2 &= ~UCA0TXIE; pc = 0
#endif /* GERENCIADOR_MEMORIA_H_ */
