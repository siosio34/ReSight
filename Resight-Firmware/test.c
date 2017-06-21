#include <stm32f10x.h>
#include <stdio.h>
#include "Delay.h"
#include "MPR121.h"
#include "MMA8451.h"
#include "resight_init.h"
#include "Bluetooth.h"

#define Filtered_Pressure_Data 0x10
#define Law_Pressure_Data 0x11
#define Walk_step_Data 0x12
#define Battery_Data 0x14

uint16_t Last_Touched = 0;
uint16_t Current_Touched = 0;

extern volatile u8 select_menu;
extern volatile u8 SYSTEM_FLAG;
extern u8 RxBuf[200]; 
extern volatile char control_data;


int main()
{
  
  RCC_Configuration();
  GPIO_Configuration();
  NVIC_Configuration();  
  UART1_Configuration();
  I2C_Configuration();
  TIM3_Configuration();
  delay_ms(100);
  
  MPR121_begin();
  MMA8451_begin();
  
  /*블루투스 설정 */
  
// AT_Command("AT+NAMEresight3n"); 
 //printf("AT+NAMEresight3\n");
// delay_ms(1000);
 //printf("AT+PIN1234\n");
 //delay_ms(1000);
 //printf("AT+BAUD8");//115200
 //delay_ms(1000);
 
 TIM_ITConfig(TIM3, TIM_IT_Update, ENABLE);
 TIM_Cmd(TIM3, ENABLE); 
  
  
  //만약안된다면 UART1_Configuration()에서 9600으로 바꾼후

  
   
  s16 Acc_data[3]={0,};
  u8 Acc_data_Byte[12]={0,};
  u16 Pressure_data[6]={0,};
  u8 Pressure_data_Byte[12]={0,};
  //GPIOC->ODR = 0x1000;
  //delay_ms(1000);
  
  
  while(1)
  {
       
    if(SYSTEM_FLAG)
    {
        MPR121_read_Pressure(Pressure_data);
        
        for(int i = 0; i <6;i++)
        {
          Pressure_data_Byte[i*2]=(u8)(Pressure_data[i]>>8);
          Pressure_data_Byte[i*2+1]=(u8)(0x00ff&Pressure_data[i]);       
        }
        
        switch(select_menu)
        {
          case 0x00 : break;
          case 0x10 : Packet_Send(select_menu,RxBuf , 6);
                      break;
          case 0x11 : Packet_Send(select_menu,Pressure_data_Byte , 12);
                      //GPIOC->ODR = 0x1000;
                      break;
          case 0x12 : Packet_Send(select_menu,RxBuf , 6);
                      break;
          case 0x14 : Packet_Send(select_menu,RxBuf , 6);
                      break;
          default : break;
        }
        SYSTEM_FLAG=0;    
    }
  }
  
}
