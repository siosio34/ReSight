
#include "Delay.h"

void delay_us(vu32 nCount)
{
   nCount *= 8;
   for(; nCount!=0; nCount--);
}



void delay_ms(vu32 nCount)
{
   nCount *= 6000;
   for(; nCount!=0; nCount--);
}
