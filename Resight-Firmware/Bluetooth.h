#ifndef _BLUETOOTH_H_
#define _BLUETOOTH_H_

#define resight_ID 0x02
#include "stm32f10x.h"

void Packet_Send(u8 instruction, u8* Data, u8 length);
void AT_Command(char*command);


#endif