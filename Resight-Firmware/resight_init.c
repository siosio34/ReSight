#include "resight_init.h"
#include <stdio.h>

// Uart 통신 정의

#define BUFFER_SIZE 200 // 200 byte  

#ifdef __GNUC__
  #define PUTCHAR_PROTOTYPE int __io_putchar(int ascii)
#else
  #define PUTCHAR_PROTOTYPE int fputc(int ascii, FILE *f)
#endif 


// Uart 통신 변수---------------------------------------------------------------
 
 u8 RxBuf[BUFFER_SIZE];                    
 u8 TxBuf[BUFFER_SIZE]; 
 u8 TxInCnt=0;   
 u8 TxOutCnt=0;     
 u8 RxCnt=0;
volatile u8 select_menu=0;
volatile u8 SYSTEM_FLAG=0;
volatile char control_data = 'm';  





void RCC_Configuration()
{
   ErrorStatus HSEStartUpStatus;
   RCC_DeInit(); //RCC system reset(for debug purpose)
   RCC_HSEConfig(RCC_HSE_ON); //Enaeble HSE
   HSEStartUpStatus = RCC_WaitForHSEStartUp(); //Wait till HSE is ready

   if(HSEStartUpStatus == SUCCESS) {
      FLASH_PrefetchBufferCmd(FLASH_PrefetchBuffer_Enable); //Enable Prefetch Buffer
      FLASH_SetLatency(FLASH_Latency_2); //Flash 2 wait state
      RCC_HCLKConfig(RCC_SYSCLK_Div1); //HCLK = SYSCLK

      RCC_PCLK2Config(RCC_HCLK_Div1); //PCLK2 = HCLK    72MHZ
      RCC_PCLK1Config(RCC_HCLK_Div4); //PCLK1 = HCLK/2  72MHZ

      RCC_PLLConfig(RCC_PLLSource_HSE_Div1, RCC_PLLMul_9); //PLLCLK = 8MHz * 9 = 72 MHz
      RCC_PLLCmd(ENABLE); //Enable PLL

      while (RCC_GetFlagStatus(RCC_FLAG_PLLRDY) == RESET); //Wait till PLL is ready
      RCC_SYSCLKConfig(RCC_SYSCLKSource_PLLCLK); //Select PLL as system clock source
      while (RCC_GetSYSCLKSource() != 0x08); //Wait till PLL is used as system clock source
   }

   RCC_APB1PeriphClockCmd(RCC_APB1Periph_TIM3, ENABLE);     //TIM2 clock enable
   RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOA, ENABLE);    //GPIOC clock enable
   RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOC, ENABLE);    //GPIOC clock enable
   RCC_APB2PeriphClockCmd(RCC_APB2Periph_USART1, ENABLE);   //USART1 clock enable
   RCC_APB2PeriphClockCmd(RCC_APB2Periph_AFIO, ENABLE);
}


void GPIO_Configuration()
{
   GPIO_InitTypeDef GPIO_InitStructure;
     
   GPIO_InitStructure.GPIO_Pin =  GPIO_Pin_12;
   GPIO_InitStructure.GPIO_Mode = GPIO_Mode_Out_PP; 
   GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
   GPIO_Init(GPIOC, &GPIO_InitStructure);
   
   // Bluetooth 통신 Tx & Rx
   GPIO_InitStructure.GPIO_Pin = GPIO_Pin_9;              
   GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
   GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_PP;
   GPIO_Init(GPIOA, &GPIO_InitStructure);

   GPIO_InitStructure.GPIO_Pin = GPIO_Pin_10;             
   GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN_FLOATING;
   GPIO_Init(GPIOA, &GPIO_InitStructure);
   
}


void NVIC_Configuration(void)
{
   NVIC_InitTypeDef NVIC_InitStructure;
   
   NVIC_InitStructure.NVIC_IRQChannel = TIM3_IRQn; 
   NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 1;
   NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0; 
   NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
   NVIC_Init(&NVIC_InitStructure);
   
   NVIC_InitStructure.NVIC_IRQChannel = USART1_IRQn; 
   NVIC_InitStructure.NVIC_IRQChannelPreemptionPriority = 0;
   NVIC_InitStructure.NVIC_IRQChannelSubPriority = 0;
   NVIC_InitStructure.NVIC_IRQChannelCmd = ENABLE;
   NVIC_Init(&NVIC_InitStructure);
}

void UART1_Configuration()  // PC와 통신
{
   USART_InitTypeDef USART_InitStructure;
   USART_InitStructure.USART_BaudRate = 115200;
   USART_InitStructure.USART_WordLength = USART_WordLength_8b;
   USART_InitStructure.USART_StopBits = USART_StopBits_1;
   USART_InitStructure.USART_Parity = USART_Parity_No;
   USART_InitStructure.USART_HardwareFlowControl = USART_HardwareFlowControl_None;
   USART_InitStructure.USART_Mode = USART_Mode_Rx|USART_Mode_Tx;

   USART_Init(USART1, &USART_InitStructure);
   
   USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);  //enable receive interrupt
   USART_Cmd(USART1, ENABLE);

}


void USART1_IRQHandler(void)
{   
  
  // Tx 인터럽트 
  if(USART_GetITStatus(USART1, USART_IT_TXE) != RESET)
    {         
        
        USART_SendData(USART1,TxBuf[TxOutCnt]);
        
        if(TxOutCnt<BUFFER_SIZE-1) TxOutCnt++;
        else TxOutCnt = 0;      
            
        if(TxOutCnt == TxInCnt)
        {
          USART_ITConfig(USART1, USART_IT_TXE, DISABLE); 
          USART_ITConfig(USART1, USART_IT_RXNE, ENABLE);
        }         
    }  
  
  // Rx 인터럽트 
  if(USART_GetITStatus(USART1, USART_IT_RXNE) != RESET)
    {         
       
        RxBuf[RxCnt] = USART_ReceiveData(USART1);
        //control_data  = USART_ReceiveData(USART1);
        USART_ClearITPendingBit(USART1, USART_IT_RXNE);
        
        if(RxCnt<5) RxCnt++;
        else{ 
                RxCnt = 0; 
                 if(RxBuf[0]==0xff&&RxBuf[1]==0xff&&RxBuf[2]==0x02&&RxBuf[4]==0xfe&&RxBuf[5]==0xfe)
                 {
                    select_menu = RxBuf[3];
                 }          
        }        
    }
  
  

}

PUTCHAR_PROTOTYPE
{
    TxBuf[TxInCnt] = ascii;
    if(TxInCnt<BUFFER_SIZE-1) TxInCnt++;
    else TxInCnt = 0;     
    
    //Enable the USART1 Transmit interrupt     
    USART_ITConfig(USART1, USART_IT_TXE, ENABLE);

    return ascii; 
}


void I2C_Configuration()
{
  I2C_InitTypeDef  I2C_InitStructure;
  GPIO_InitTypeDef GPIO_InitStructure;

  /* Enable I2C and GPIO clocks */
  RCC_APB1PeriphClockCmd(RCC_APB1Periph_I2C1, ENABLE);
  RCC_APB2PeriphClockCmd(RCC_APB2Periph_GPIOB, ENABLE);

  /* Configure I2C pins: SCL and SDA */
  GPIO_InitStructure.GPIO_Pin =  GPIO_Pin_6 | GPIO_Pin_7; 
  GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF_OD;
  GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
  GPIO_Init(GPIOB, &GPIO_InitStructure); 
  
  /* I2C configuration */
  I2C_InitStructure.I2C_Mode = I2C_Mode_I2C;
  I2C_InitStructure.I2C_DutyCycle = I2C_DutyCycle_2;
  
  I2C_InitStructure.I2C_Ack = I2C_Ack_Enable;
  I2C_InitStructure.I2C_AcknowledgedAddress = I2C_AcknowledgedAddress_7bit;
  I2C_InitStructure.I2C_ClockSpeed = 100000;//MPU6050_I2C_Speed;
  
  /* Apply I2C configuration after enabling it */
  I2C_Init(I2C1, &I2C_InitStructure);
  /* I2C Peripheral Enable */  
  I2C_Cmd(I2C1, ENABLE);
  
}

void TIM3_IRQHandler(void)
{
  TIM_ClearFlag(TIM3, TIM_FLAG_Update);
  SYSTEM_FLAG=1;
  TIM_ClearITPendingBit(TIM3, TIM_IT_Update);
}

void TIM3_Configuration()
{
  TIM_TimeBaseInitTypeDef  TIM_TimeBaseStructure;
  TIM_TimeBaseStructure.TIM_Period =499;//총 500ms 시스템 주기
  TIM_TimeBaseStructure.TIM_Prescaler = 36000;//36Mhz 분주비36000 = 1ms
  TIM_TimeBaseStructure.TIM_ClockDivision = 0;
  TIM_TimeBaseStructure.TIM_CounterMode = TIM_CounterMode_Up;
  TIM_TimeBaseInit(TIM3, &TIM_TimeBaseStructure);
  TIM_ITConfig(TIM3, TIM_IT_Update, DISABLE);
  TIM_Cmd(TIM3, DISABLE);
}



