#include <msp430.h> 
#include <stdio.h>

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1INbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1OUTbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1DIRbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1IFGbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1IESbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1IEbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1SELbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1SEL2bits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P1RENbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2INbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2OUTbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2DIRbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2IFGbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2IESbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2IEbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2SELbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2SEL2bits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P2RENbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P3INbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P3OUTbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P3DIRbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P3SELbits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P3SEL2bits;

typedef struct {
    volatile unsigned char bit0 : 1;
    volatile unsigned char bit1 : 1;
    volatile unsigned char bit2 : 1;
    volatile unsigned char bit3 : 1;
    volatile unsigned char bit4 : 1;
    volatile unsigned char bit5 : 1;
    volatile unsigned char bit6 : 1;
    volatile unsigned char bit7 : 1;
}P3RENbits;


#define _P1IN (*(volatile P1INbits*)0x0020)
#define _P1OUT (*(volatile P1OUTbits*)0x0021)
#define _P1DIR (*(volatile P1DIRbits*)0x0022)
#define _P1IFG (*(volatile P1IFGbits*)0x0023)
#define _P1IES (*(volatile P1IESbits*)0x0024)
#define _P1IE (*(volatile P1IEbits*)0x0025)
#define _P1SEL (*(volatile P1SELbits*)0x0026)
#define _P1SEL2 (*(volatile P1SEL2bits*)0x0041)
#define _P1REN (*(volatile P1RENbits*)0x0027)

#define _P2IN (*(volatile P2INbits*)0x0028)
#define _P2OUT (*(volatile P2OUTbits*)0x0029)
#define _P2DIR (*(volatile P2DIRbits*)0x002A)
#define _P2IFG (*(volatile P2IFGbits*)0x002B)
#define _P2IES (*(volatile P2IESbits*)0x002C)
#define _P2IE (*(volatile P2IEbits*)0x002D)
#define _P2SEL (*(volatile P2SELbits*)0x002E)
#define _P2SEL2 (*(volatile P2SEL2bits*)0x0042)
#define _P2REN (*(volatile P2RENbits*)0x002F)

#define _P3IN (*(volatile P3INbits*)0x0018)
#define _P3OUT (*(volatile P3OUTbits*)0x0019)
#define _P3DIR (*(volatile P3DIRbits*)0x001A)
#define _P3SEL (*(volatile P3SELbits*)0x001B)
#define _P3SEL2 (*(volatile P3SEL2bits*)0x0043)
#define _P3REN (*(volatile P3RENbits*)0x0010)


     // ADC10SAbits;       pág 606

    // ADC10MEMbits; // pág 604

typedef struct {
    volatile unsigned int bADC10SC : 1;
    volatile unsigned int bENC : 1;
    volatile unsigned int bADC10IFG : 1;
    volatile unsigned int bADC10IE : 1;
    volatile unsigned int bADC10ON : 1;
    volatile unsigned int REFON5 : 1;
    volatile unsigned int bREF2_5V : 1;
    volatile unsigned int bMSC : 1;
    volatile unsigned int bREFBURST : 1;
    volatile unsigned int REFOUT9 : 1;
    volatile unsigned int ADC10SR10 : 1;
    volatile unsigned int ADC10SHTx : 2;
    volatile unsigned int SREFx : 3;
}ADC10CTL0bits; // pág 603

typedef struct {
    volatile unsigned int ADC10BUSY0 : 1;
    volatile unsigned int CONSEQx : 2;
    volatile unsigned int ADC10SSELx : 2;
    volatile unsigned int ADC10DIVx : 3;
    volatile unsigned int bISSH : 1;
    volatile unsigned int ADC10DF9 : 1;
    volatile unsigned int SHSx : 2;
    volatile unsigned int INCHx : 4;
}ADC10CTL1bits; // pág 604

//TA1CCR2bits;   // PÁG. 392

//TA1CCR1bits;   // PÁG. 392

//TA1CCR0bits;   // PÁG. 392

typedef struct {
    volatile unsigned int TARx : 16;
}TA1Rbits;            // pág. 389

typedef struct {
    volatile unsigned int bCCIFG : 1;
    volatile unsigned int bCOV : 1;
    volatile unsigned int bOUT : 1;
    volatile unsigned int bCCI : 1;
    volatile unsigned int bCCIE : 1;
    volatile unsigned int OUTMODx : 3;
    volatile unsigned int bCAP : 1;
    volatile unsigned int Unused : 1;
    volatile unsigned int bSCCI : 1;
    volatile unsigned int bSCS : 1;
    volatile unsigned int CCISx : 2;
    volatile unsigned int CMx : 2;
}TA1CCTL2bits;          // pág. 390

typedef struct {
    volatile unsigned int CCIFG0 : 1;
    volatile unsigned int COV1 : 1;
    volatile unsigned int OUT2 : 1;
    volatile unsigned int CCI3 : 1;
    volatile unsigned int CCIE4 : 1;
    volatile unsigned int OUTMODx : 3;
    volatile unsigned int CAP8 : 1;
    volatile unsigned int Unused9 : 1;
    volatile unsigned int SCCI10 : 1;
    volatile unsigned int SCS11 : 1;
    volatile unsigned int CCISx12 : 2;
    volatile unsigned int CMx : 2;
}TA1CCTL1bits  ;       // pág 390


typedef struct {
    volatile unsigned int CCIFG0 : 1;
    volatile unsigned int COV1 : 1;
    volatile unsigned int OUT2 : 1;
    volatile unsigned int CCI3 : 1;
    volatile unsigned int CCIE4 : 1;
    volatile unsigned int OUTMODx5 : 3;
    volatile unsigned int CAP9 : 1;
    volatile unsigned int Unused : 1;
    volatile unsigned int SCCI11 : 1;
    volatile unsigned int SCS12 : 1;
    volatile unsigned int CCISx : 2;
    volatile unsigned int CMx : 2;
}TA1CCTL0bits;

typedef struct {
    volatile unsigned int TAIFG0 : 1;
    volatile unsigned int TAIE1 : 1;
    volatile unsigned int TACLR2 : 1;
    volatile unsigned int RESERVED1 : 1;
    volatile unsigned int MCx : 2;
    volatile unsigned int IDx : 2;
    volatile unsigned int TASSELx : 2;
    volatile unsigned int RESERVED2 : 6;
}TA0CTLbits;

typedef struct {
    volatile unsigned int bTAIFG0 : 1;
    volatile unsigned int bTAIE1 : 1;
    volatile unsigned int bTACLR2 : 1;
    volatile unsigned int bRESERVED13 : 1;
    volatile unsigned int MCx4 : 2;
    volatile unsigned int IDx6 : 2;
    volatile unsigned int TASSELx : 2;
    volatile unsigned int bRESERVED210 : 6;
}TA1CTLbits;


	 // TA1IVbits;    pág. 393

	//TA0CCR2bits;    PÁG. 392

	//TA0CCR1bits;    PÁG. 392

	//TA0CCR0bits;    PÁG. 392

	//TA0Rbits;         pág. 389

typedef struct {
    volatile unsigned int bCCIFG : 1;
    volatile unsigned int bCOV : 1;
    volatile unsigned int bOUT : 1;
    volatile unsigned int bCCI : 1;
    volatile unsigned int bCCIE : 1;
    volatile unsigned int OUTMODx : 3;
    volatile unsigned int bCAP : 1;
    volatile unsigned int Unused : 1;
    volatile unsigned int bSCCI : 1;
    volatile unsigned int bSCS : 1;
    volatile unsigned int CCISx : 2;
    volatile unsigned int CMx : 2;
}TA0CCTL2bits;          // pág. 390

typedef struct {
    volatile unsigned int bCCIFG : 1;
    volatile unsigned int bCOV : 1;
    volatile unsigned int bOUT : 1;
    volatile unsigned int bCCI : 1;
    volatile unsigned int bCCIE : 1;
    volatile unsigned int OUTMODx : 3;
    volatile unsigned int bCAP : 1;
    volatile unsigned int Unused : 1;
    volatile unsigned int bSCCI : 1;
    volatile unsigned int bSCS : 1;
    volatile unsigned int CCISx : 2;
    volatile unsigned int CMx : 2;
}TA0CCTL1bits;                 // pág 390


typedef struct {
    volatile unsigned int bCCIFG : 1;
    volatile unsigned int bCOV : 1;
    volatile unsigned int bOUT : 1;
    volatile unsigned int bCCI : 1;
    volatile unsigned int bCCIE : 1;
    volatile unsigned int OUTMODx : 3;
    volatile unsigned int bCAP : 1;
    volatile unsigned int Unused : 1;
    volatile unsigned int bSCCI : 1;
    volatile unsigned int bSCS : 1;
    volatile unsigned int CCISx : 2;
    volatile unsigned int CMx : 2;
}TA0CCTL0bits;


 // TA0IVbits;    pág. 393



typedef struct {
    volatile unsigned int ERASE0 : 1;
    volatile unsigned int MERAS1 : 1;
    volatile unsigned int EEI : 1;
    volatile unsigned int EEIEX : 1;
    volatile unsigned int WRT4 : 1;
    volatile unsigned int BLKWRT5 : 1;
    volatile unsigned int RESERVED : 2;
    volatile unsigned int FWKEY8 : 8;
} FCTL1bits;

typedef struct {
    volatile unsigned int FNx : 6;
    volatile unsigned int FSSELx : 2;
    volatile unsigned int bFWKEY8 : 8;
} FCTL2bits;

typedef struct {
    volatile unsigned int BUSY0 : 1;
    volatile unsigned int KEYV1 : 1;
    volatile unsigned int ACCVIFG2 : 1;
    volatile unsigned int WAIT3 : 1;
    volatile unsigned int LOCK4 : 1;
    volatile unsigned int EMEX5 : 1;
    volatile unsigned int LOCKA6 : 1;
    volatile unsigned int bFAIL : 1;
    volatile unsigned int FWKEY8 : 8;
} FCTL3bits;

typedef struct {
    volatile unsigned int WDTISx : 2;
    volatile unsigned int bWDTSSEL : 1;
    volatile unsigned int WDTCNTCL3 : 1;
    volatile unsigned int WDTTMSEL4 : 1;
    volatile unsigned int bWDTNMI : 1;
    volatile unsigned int bWDTNMIES : 1;
    volatile unsigned int WDTHOLD7 : 1;
    volatile unsigned int WDTPW8 : 8;
} WDTCTLbits;

typedef struct {
    volatile unsigned char UCTXBUFx : 8;
}UCB0TXBUFbits;  // pág. 477

typedef struct {

    volatile unsigned char UCRXBUFx : 8;
}UCB0RXBUFbits;  // pág. 477

typedef struct {
    volatile unsigned char UCBUSY0 : 1;
    volatile unsigned char bReserved1 : 4;
    volatile unsigned char UCOE5 : 1;
    volatile unsigned char UCFE6 : 1;
    volatile unsigned char UCLISTEN7 : 1;
}UCB0STATbits;  // pág. 476

typedef struct{
    volatile unsigned char UCALIE0 : 1;
    volatile unsigned char UCSTTIE1 : 1;
    volatile unsigned char UCSTPIE2 : 1;
    volatile unsigned char UCNACKIE3 : 1;
    volatile unsigned char bRESERVED4   : 4;
}UCB0CIEbits;  // PÁG. 508

  // UCB0SAbits;   PÁG. 507

// UCB0OAbits;  PÁG. 507

typedef struct {
    volatile unsigned char UCBRx  : 8;
}UCB0BR1bits; // pág.475

typedef struct {
    volatile unsigned char UCBRx  : 8;
}UCB0BR0bits; // pág 475

typedef struct {
    volatile unsigned char UCSYNC0  : 1;
    volatile unsigned char UCMODEx  : 2;
    volatile unsigned char UCMST3  : 1;
    volatile unsigned char UC7BIT4  : 1;
    volatile unsigned char UCMSB5 : 1;
    volatile unsigned char UCCKPL6  : 1;
    volatile unsigned char UCCKPH7  : 1;
}UCB0CTL1bits;

typedef struct {
    volatile unsigned char UCSYNC0  : 1;
    volatile unsigned char UCMODEx1  : 2;
    volatile unsigned char UCMST3  : 1;
    volatile unsigned char UC7BIT4  : 1;
    volatile unsigned char UCMSB5  : 1;
    volatile unsigned char UCCKPL6  : 1;
    volatile unsigned char UCCKPH7 : 1;
}UCB0CTL0bits;

typedef struct {
    volatile unsigned char UCTXBUFx : 8;
}UCA0TXBUFbits;  // pág. 477

typedef struct {

    volatile unsigned char UCRXBUFx : 8;
}UCA0RXBUFbits;  // pág. 477

typedef struct {
    volatile unsigned char UCBUSY0 : 1;
    volatile unsigned char bReserved2 : 4;
    volatile unsigned char UCOE5 : 1;
    volatile unsigned char UCFE6 : 1;
    volatile unsigned char UCLISTEN7 : 1;
}UCA0STATbits;  // pág. 476

typedef struct {
    volatile unsigned char UCBRx  : 8;
}UCA0BR0bits;

typedef struct {
    volatile unsigned char UCBRx  : 8;
}UCA0BR1bits;

typedef struct {
    volatile unsigned char UCSWRST0  : 1;
    volatile unsigned char UCTXBRK1 : 2;
    volatile unsigned char UCTXADDR3 : 1;
    volatile unsigned char UCDORM4 : 1;
    volatile unsigned char UCBRKIE5 : 1;
    volatile unsigned char UCRXEIE6 : 1;
    volatile unsigned char UCSSELx7  : 1;
}UCA0CTL1bits; // pág. 453

typedef struct {
    volatile unsigned char UCSYNC0  : 1;
    volatile unsigned char UCMODEx  : 2;
    volatile unsigned char UCMST4  : 1;
    volatile unsigned char UC7BIT5  : 1;
    volatile unsigned char UCMSB6  : 1;
    volatile unsigned char UCCKPL7  : 1;
    volatile unsigned char UCCKPH8  : 1;
}UCA0CTL0bits;

typedef struct {
    volatile unsigned char UCOS160  : 1;
    volatile unsigned char UCBRSx  : 3;
    volatile unsigned char UCBRFx  : 4;
}UCA0MCTLbits;

typedef struct {
    volatile unsigned char UCIRRXFE0  : 1;
    volatile unsigned char UCIRRXPL1  : 1;
    volatile unsigned char UCIRRXFLx  : 6;
}UCA0IRRCTLbits;

typedef struct {
    volatile unsigned char UCIREN0  : 1;
    volatile unsigned char UCIRTXCLK1  : 1;
    volatile unsigned char UCIRTXPLx  : 6;
}UCA0IRTCTLbits;

typedef struct {
    volatile unsigned char bUCABDEN  : 1;
    volatile unsigned char Reserved  : 1;
    volatile unsigned char bUCBTOE2  : 1;
    volatile unsigned char bUCSTOE3  : 1;
    volatile unsigned char UCDELIMx  : 2;
    volatile unsigned char bReserved5  : 2;
}UCA0ABCTLbits;

typedef struct {
    volatile unsigned char ADC10AE0x  : 8;
}ADC10AE0bits;    // pág. 603

typedef struct {
    volatile unsigned char Reserved  : 4;
    volatile unsigned char ADC10AE1x : 4;
}ADC10AE1bits;    // pág. 603

typedef struct {
    volatile unsigned char DTC_Transfers  : 8;
}ADC10DTC1bits; // PÁG. 605

typedef struct {
    volatile unsigned char ADC10FETCH0  : 1;
    volatile unsigned char ADC10B11 : 1;
    volatile unsigned char ADC10CT2 : 1;
    volatile unsigned char ADC10TB3 : 1;
    volatile unsigned char Reserved4 : 4;
}ADC10DTC0bits;   // PÁG. 605

typedef struct {
    volatile unsigned char bCAPD0  : 1;
    volatile unsigned char bCAPD1 : 1;
    volatile unsigned char bCAPD2 : 1;
    volatile unsigned char bCAPD3 : 1;
    volatile unsigned char bCAPD4 : 1;
    volatile unsigned char bCAPD5 : 1;
    volatile unsigned char bCAPD6  : 1;
    volatile unsigned char bCAPD7  : 1;
}CAPDbits;  // PÁG. 577

typedef struct {
    volatile unsigned char CAOUT0  : 1;
    volatile unsigned char CAF1 : 1;
    volatile unsigned char P2CA02 : 1;
    volatile unsigned char P2CA13 : 1;
    volatile unsigned char P2CA24 : 1;
    volatile unsigned char P2CA35 : 1;
    volatile unsigned char P2CA46  : 1;
    volatile unsigned char CASHORT7  : 1;
}CACTL2bits; // PÁG. 576

typedef struct {
    volatile unsigned char CAIFG0  : 1;
    volatile unsigned char CAIE1 : 1;
    volatile unsigned char CAIES2 : 1;
    volatile unsigned char CAON3 : 1;
    volatile unsigned char CAREFx : 2;
    volatile unsigned char CARSEL6  : 1;
    volatile unsigned char CAEX7  : 1;
}CACTL1bits;

typedef struct {
    volatile unsigned char LFXT1OF0  : 1;
    volatile unsigned char XT2OF1 : 1;
    volatile unsigned char XCAPx : 2;
    volatile unsigned char LFXT1Sx : 2;
    volatile unsigned char XT2Sx  : 2;
}BCSCTL3bits;  // PÁG. 289

typedef struct {
    volatile unsigned char DCOR  : 1;
    volatile unsigned char DIVSx : 2;
    volatile unsigned char SELS3 : 1;
    volatile unsigned char DIVMx : 2;
    volatile unsigned char SELMx  : 2;
}BCSCTL2bits;  // PÁG. 288

typedef struct {
    volatile unsigned char RSELx0  : 4;
    volatile unsigned char bDIVAx4 : 2;
    volatile unsigned char XTS7  : 1;
    volatile unsigned char XT2OFF8  : 1;
}BCSCTL1bits;  // PÁG. 287

typedef struct {
    volatile unsigned char MODx : 5;
    volatile unsigned char DCOx  : 3;
}DCOCTLbits;  // PÁG. 286

typedef struct {
    volatile unsigned char RESERVED0 : 1; // Bit 0 - reservado
    volatile unsigned char RESERVED1 : 1; // Bit 1 - reservado
    volatile unsigned char RESERVED2 : 1; // Bit 2 - reservado
    volatile unsigned char RESERVED3 : 1; // Bit 3 - reservado
    volatile unsigned char URXIFG1   : 1; // Bit 4 - flag de recepção UART1
    volatile unsigned char UTXIFG1   : 1; // Bit 5 - flag de transmissão UART1
    volatile unsigned char RESERVED6 : 1; // Bit 6 - reservado
    volatile unsigned char RESERVED7 : 1; // Bit 7 - reservado
} IFG2bits; // PÁG. 552

typedef struct {
    volatile unsigned char RESERVED0 : 6;
    volatile unsigned char URXIFG0   : 1;
    volatile unsigned char UTXIFG0   : 1;
} IFG1bits; // PÁG. 552

typedef struct {
    volatile unsigned char UCA0RXIE0 : 1;
    volatile unsigned char UCA0TXIE1 : 1;
    volatile unsigned char RESERVED : 6;
}IE2bits; // PÁG. 461

 //IE2bits - PÁG. 551

 // IFG1bits -  PÁG. 551

#define _ADC10CTL0 (*(volatile ADC10CTL0bits*)0x01B0)
#define _ADC10CTL1 (*(volatile ADC10CTL1bits*)0x01B2)
#define _ADC10MEM  (*(volatile ADC10MEMbits*) 0x01B4)
#define _ADC10SA   (*(volatile ADC10SAbits*)  0x01BC)

#define _TA0CTL (*(volatile TA0CTLbits*)0x0160)
#define _TA1CTL (*(volatile TA1CTLbits*)0x0180)
#define _TA0CCTL0 (*(volatile TA0CCTL0bits*)0x0162)
#define _TA0CCTL1 (*(volatile TA0CCTL1bits*)0x0164)
#define _TA0CCTL2 (*(volatile TA0CCTL2bits*)0x0166)
#define _TA1CCR2 (*(volatile TA1CCR2bits*)0x0196)
#define _TA1CCR1 (*(volatile TA1CCR1bits*)0x0194)
#define _TA1CCR0 (*(volatile TA1CCR0bits*)0x0192)
#define _TA1R (*(volatile TA1Rbits*)0x0190)
#define _TA1CCTL2 (*(volatile TA1CCTL2bits*)0x0186)
#define _TA1CCTL1 (*(volatile TA1CCTL1bits*)0x0184)
#define _TA1CCTL0 (*(volatile TA1CCTL0bits*)0x0182)
#define _TA1IV (*(volatile TA1IVbits*)0x011E)
#define _TA0CCR2 (*(volatile TA0CCR2bits*)0x0176)
#define _TA0CCR1 (*(volatile TA0CCR1bits*)0x0174)
#define _TA0CCR0 (*(volatile TA0CCR0bits*)0x0172)
#define _TA0R (*(volatile TA0Rbits*)0x0170)
#define _TA0IV (*(volatile TA0IVbits*)0x012E)




#define _FCTL1 (*(volatile FCTL1bits*)0x0128)
#define _FCTL2 (*(volatile FCTL2bits*)0x012A)
#define _FCTL3 (*(volatile FCTL3bits*)0x012C)

#define _WDTCTL (*(volatile WDTCTLbits*)0x0120)

#define _UCB0TXBUFbits   (*(volatile UCB0TXBUFbits*)0x06F)
#define _UCB0RXBUFbits   (*(volatile UCB0RXBUFbits*)0x06E)
#define _UCB0STATbits    (*(volatile UCB0STATbits*)0x06D)
#define _UCB0CIEbits     (*(volatile UCB0CIEbits*)0x06C)
#define _UCB0SAbits      (*(volatile UCB0SAbits*)0x011A)  // PASSÍVEL DE CORRELÇAO PARA 011A
#define _UCB0OAbits      (*(volatile UCB0OAbits*)0x0118)
#define _UCB0BR1bits     (*(volatile UCB0BR1bits*)0x06B)
#define _UCB0BR0bits     (*(volatile UCB0BR0bits*)0x06A)
#define _UCB0CTL1bits    (*(volatile UCB0CTL1bits*)0x069)
#define _UCB0CTL0bits    (*(volatile UCB0CTL0bits*)0x068)

#define _UCA0TXBUFbits   (*(volatile UCA0TXBUFbits*)0x067)
#define _UCA0RXBUFbits   (*(volatile UCA0RXBUFbits*)0x066)
#define _UCA0STATbits    (*(volatile UCA0STATbits*)0x065)
#define _UCA0BR0bits     (*(volatile UCA0BR0bits*)0x062)
#define _UCA0BR1bits     (*(volatile UCA0BR1bits*)0x063)
#define _UCA0CTL1bits    (*(volatile UCA0CTL1bits*)0x061)
#define _UCA0CTL0bits    (*(volatile UCA0CTL0bits*)0x060)
#define _UCA0MCTLbits    (*(volatile UCA0MCTLbits*)0x064)
#define _UCA0IRRCTLbits  (*(volatile UCA0IRRCTLbits*)0x05F)
#define _UCA0IRTCTLbits  (*(volatile UCA0IRTCTLbits*)0x05E)
#define _UCA0ABCTLbits   (*(volatile UCA0ABCTLbits*)0x05D)

#define _ADC10AE0bits    (*(volatile ADC10AE0bits*)0x04A)
#define _ADC10AE1bits    (*(volatile ADC10AE1bits*)0x04B)
#define _ADC10DTC1bits   (*(volatile ADC10DTC1bits*)0x049)
#define _ADC10DTC0bits   (*(volatile ADC10DTC0bits*)0x048)

#define _CAPDbits        (*(volatile CAPDbits*)0x05B)
#define _CACTL2bits      (*(volatile CACTL2bits*)0x05A)
#define _CACTL1bits      (*(volatile CACTL1bits*)0x059)

#define _BCSCTL3bits     (*(volatile BCSCTL3bits*)0x053)
#define _BCSCTL2bits     (*(volatile BCSCTL2bits*)0x058)
#define _BCSCTL1bits     (*(volatile BCSCTL1bits*)0x057)
#define _DCOCTLbits      (*(volatile DCOCTLbits*)0x056)

#define _IFG2bits        (*(volatile IFG2bits*)0x003)
#define _IFG1bits        (*(volatile IFG1bits*)0x002)
#define _IE2bits         (*(volatile IE2bits*)0x001)
#define _IE1bits         (*(volatile IE1bits*)0x000)
/*
int main(void)
{
	// WDTCTL = WDTPW | WDTHOLD;  // WDTCTL não pode ser acessado como um struct normal, porque é um registrador de 16 bits
	// protegido por senha (password protected).Ou seja, não existe endereço 1 byte + bitfields
    // Parar o Watchdog temporizador que reinicia o sistema
    // se o programa travar. Desativamos ele no início para evitar reinicializações indesejadas durante o teste.

   _P1DIR.bit0 = 1; // P1.0 como saída, o LED  está conectado a esse pino.


   volatile int i;

   while(1)
   {
       _P1OUT.bit0 = 1; // LED aceso


       for(i = 0; i < 10000; i++) { }  // correto para C89, DELLAY SIMPLES

       _P1OUT.bit0 = 0; // LED apagado

       for(i = 0; i < 10000; i++) { }  // correto para C89, DELLAY SIMPLES
   }



}
*/
