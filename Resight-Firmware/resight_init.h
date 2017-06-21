#ifndef _resight_INIT_H_
#define _resight_INIT_H_

#include "stm32f10x.h"

void RCC_Configuration();
void GPIO_Configuration();

void NVIC_Configuration();

void UART1_Configuration();
void USART1_IRQHandler();
void I2C_Configuration();

void TIM3_IRQHandler(void);
void TIM3_Configuration();






#endif