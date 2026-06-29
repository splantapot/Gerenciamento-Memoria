/*teste de envio de dados pela serial para envio de string e dados da memoria para
 implementar um depurador ou pelo menos para visualizar na tela do computador os dados
 na memória */ //C:\Users\evert\workspace_v5_5\Transmissor_USCIA_TX
#include <msp430.h>
#include "Temporizador.h"
#include <stdlib.h>
#include <string.h>
#include "gerenciador_memoria.h"
#define TEMPO_TICK 10000 /* 10 mil us = 10 ms*/ //para uso da Biblioteca do TEMPORIZADOR
unsigned int tick;
void setup_tick(unsigned int tempo_tick); void setup_hardware();

//====================GERENCIADOR DE MEMORIA=========================================
//==variaveis e funções
#define tp BIT3 //transistor bc639 de programação //para uso dos pinos RX e TX e gravacao sem precisar mudar a posição nos pinos
#define tu BIT4 //transistor bc337 de utilização


int main(void) {
	setup_hardware();//watchdog, pinos, etc...
	/*Temporizador t; apareceu perfeitamente após 10 segundos a mensagem resetado e quando pressionado para resetar também
	inicializa_temporizador(1000, &t);//
	while(!passou_tempo(&t));*/
	//imprima_gerenciador("\n");//<<<<<<para ajudar a filtrar a ruideira 255 no momento de reset
	imprima_gerenciador("Resetado\n");//<<<<<<
	LPM0;//pausa por LPM
	imprima_gerenciador("Running...\n");
	char cont = 0;//contador para dar uma base de tempo para alternar entre opcoes automaticamente
	Temporizador t; inicializa_temporizador(100, &t); //5000 ms	//P3OUT = 48;	//Temporizador* temp = (Temporizador* )malloc(sizeof(Temporizador));  	//inicializa_temporizador(10,temp);

	while (1) {
		if (passou_tempo(&t)) {//tempo de 1 segundo
			reseta_temporizador(&t);
			P1OUT ^= BIT0;
			switch (cont) {
			case 0:
				imprima_gerenciador("Ex Timeout\n");
				break;
			case 1:
				imprima_user("TESTANDO O ENVIO PELA FUNCAO IMPRIMA_USER\n");
				break;
			case 2:
				imprima_user("0\n");
				imprima_user("from user\n");
				break;
			case 3://bp(0); BREAKPOINT(0)
			{
				char v[3] = {1 + 48,'\n','\0'};//vetor de mensagem de ponto de breakpoint
				imprima_gerenciador(v);
				break;
			}
			case 4:
				 imprima_user("Sou usuario\n");
				 break;
				/*case 5:
				 __bis_SR_register(LPM0);//da no mesmo disso __bis_SR_register(LPM0 or GIE);
				 break;*/
			}//switch
			cont++; cont %= 5;
			//__asm(" NOP");__asm(" NOP");//para marcar a localização
		} //passou tempo
	}//while 1
}//main



void setup_hardware(){
	WDTCTL = WDTPW + WDTHOLD;
	DCOCTL = 68;
	BCSCTL1 = 135;  			//calibrado para 1 MHz
	P1DIR = 0xFF;               // All P1.x outputs
	P1OUT = 0;                  // All P1.x reset
	P2DIR = 0xFF;               // All P2.x outputs
	P2OUT = 0;                  // All P2.x reset
	P1SEL = BIT1 + BIT2;        // P1.1 = RXD, P1.2=TXD
	P1SEL2 = BIT1 + BIT2;       // P1.1 = RXD, P1.2=TXD
	P3DIR = 0xFF;               // All P3.x outputs
	P3OUT = 0;                  // All P3.x reset
	setup_tick(TEMPO_TICK);

	P1REN = 0xFF;
	P2REN = 0xFF;
	P3REN = 0xF7;                                //p3.3 resistor desativado
	P3OUT |= BIT0;	P2OUT &= ~BIT0; //para colocar os leds indicadores de niveis
	//configuração dos pinos para chaveamento
	P1DIR &= ~BIT5;          //entrada
	P1REN &= ~(BIT5 + BIT2); //sem resistor  <<<??? tp também?
	P1REN |= BIT1; //<<<<<<<<<habilita resistor de pullup no pino RX do msp<<<<<<<<<<<<<
	P1DIR |= tp + tu;  //saída
	P1REN &= ~tp;	    //sem resistor
	P1OUT &= ~tp;	    //nivel baixo para permitir a aplicaçao Rx/Tx do usuario
	P1REN |= tu;	    //resistor on
	P1OUT |= tu | BIT1;

	//UART configuração
	UCA0CTL1 |= UCSWRST;
	UCA0CTL1 |= UCSSEL_2 | UCBRKIE;//SMCLK e habilitada a detecção de break!!!!!!!!!!!!!!

	UCA0BR0 = 26;      		//38400 bps OK!!!, mas dá erro repetindo o primeiro caracter a 76800 bps, por que?
	UCA0BR1 = 0;
	UCA0MCTL = 0;
	UCA0CTL1 &= ~UCSWRST;	// **Initialize USCI state machine**
	IE2 |= UCA0RXIE;		// Enable USCI_A0 RX interrupt

	__bis_SR_register(GIE);
}

/*void func(void);
 unsigned int pece = (unsigned int)func;*/
//volatile unsigned int pece;//para saber do valor do PC
//void pc_to_string(char *str); char buff[5];
//na main {	//__asm(" MOV R0, &pece");//saber do pc atual => 0xC00A 	//pc_to_string(buff); }

/*void pc_to_string(char *str) {
 unsigned int val = pece; 	int i;

 for (i = 0; i < 4; i++) {
 unsigned char nibble = (val >> (12 - 4 * i)) & 0x0F;

 if (nibble < 10)
 str[i] = '0' + nibble;
 else
 str[i] = 'A' + (nibble - 10);
 }

 str[4] = '\0';
 }*/
//para depurar uma função?
//void func(void);
//unsigned int pc = (unsigned int)func; //pega o endereço do PC da função
//if ( func =< pc < foo)
//void foo();

/* Dentro da RTI
 unsigned int *sp;
 sp = (unsigned int *)_get_SP_register();
 unsigned int pc_salvo = *(sp); // ou offset dependendo do compilador
 */
/*
 * 	//_get_SP_register
 1. 🔎 Debug e análise de memória

 Você pode verificar:

 quanto da pilha está sendo usada
 se há risco de stack overflow
 * */

/*IE2 |= UCA0TXIE;                        // Enable USCI_A0 TX interruptUCA0TXBUF = *pc++;//string1[i++]; //triga o tx inicial*/

