//para a versão 1 do Software C:\Users\evert\workspace_v5_5\Transmissor_USCIA_TX
#include <msp430.h>
#include <Temporizador.h>
#include "gerenciador_memoria.h"

void setup_hardware();

int main(void) {
	setup_hardware();//watchdog, pinos, etc...

	imprima_gerenciador("Resetado\n");
	LPM0;//pausa por LPM
	imprima_gerenciador("Running...\n");
	Temporizador t; inicializa_temporizador(100, &t);

	byte vetor_teste[] = {8, 9};//, 3, 4};

	// TA0CTL in address: 0x160
	TA0CTL = 0x0301;//teste de inicialização do registrador de 16 bits

	aloc_addr(&P3OUT, 1);//interessante o uso do sizeof, que informa certo o tamanho do registrador em bytes
	//aloc_addr(vetor_teste, sizeof(vetor_teste));
	//aloc_addr(&svt, 1);//svt = 3 nesse caso

	//alocação de registrador sempre por último na tabela para facilitar
	aloc_reg(&TA0CTL); //0x0301 esperado
	aloc_reg(&TA1CTL); //0x0221 esperado

	char cont = 0;//contador para dar uma base de tempo para alternar entre opcoes automaticamente
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
				char v[3] = {1 + 48,'\n','\0'};//vetor de mensagem de ponto de breakpoint para a versão 2
				imprima_gerenciador(v);
				break;
			}
			case 4:
				 imprima_user("Sou usuario\n");
				 vetor_teste[0] += 1;
				 vetor_teste[1] += 10;
				 break;
			}//switch
			cont++; cont %= 5;
		} //passou tempo
	}//while 1
}//main

void setup_hardware(){
	#define tp BIT3 //transistor bc639 de programação //para uso dos pinos RX e TX e gravacao sem precisar mudar a posição nos pinos
	#define tu BIT4 //transistor bc337 de utilização
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

/*
 o endereço 0x0161 não é um registrador independente acessível por byte no MSP430G2553.
Embora anteriormente tenhamos tratado o TA0CTL como um registrador de 16 bits com:
0x0160 → byte baixo
0x0161 → byte alto
isso é uma visão de mapa de memória genérico. Nos periféricos MSP430, o acesso por byte depende de como o módulo foi implementado no silício.
No caso do Timer_A, o TA0CTL deve ser acessado como um registrador de 16 bits:*/
