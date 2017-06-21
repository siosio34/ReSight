#include "Bluetooth.h"
#include <stm32f10x.h>



void Packet_Send(u8 instruction, u8* Data, u8 length)
{
  //u16 Cheak_Sum=0;
  int i = 0;

  USART_SendData(USART1,0xff);
  while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  USART_SendData(USART1,0xff);
  while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  USART_SendData(USART1,resight_ID);
  while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  USART_SendData(USART1,instruction);
  while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  
  for(i=0;i<length;i++)
  {
    USART_SendData(USART1,Data[i]);
    while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  }

 
  USART_SendData(USART1,0xfe);
  while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  USART_SendData(USART1,0xfe);
  while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
 
}

void AT_Command(char*command)
{
  int i = 0;
  while(command[i]!='n')
  {
    USART_SendData(USART1,command[i]);
    while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
    i++;  
  }
  
   //USART_SendData(USART1,'\n');
   //while(USART_GetFlagStatus(USART1, USART_FLAG_TXE) == RESET);
  
}