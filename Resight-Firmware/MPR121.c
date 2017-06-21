

#include "MPR121.h"
#include "Delay.h"

void MPR121_begin() 
{
  // soft reset
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_SOFTRESET, 0x63);

  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_ECR, 0x00);

  //uint8_t c = MPR121_readRegister8(MPR121_CONFIG2);
  
  MPR121_setThresholds(12, 6);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_MHDR, 0x01);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_NHDR, 0x01);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_NCLR, 0x0E);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_FDLR, 0x00);

  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_MHDF, 0x01);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_NHDF, 0x05);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_NCLF, 0x01);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_FDLF, 0x00);

  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_NHDT, 0x00);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_NCLT, 0x00);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_FDLT, 0x00);

  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_DEBOUNCE, 0x00);
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_CONFIG1, 0xFF); // default, 16uA charge current
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_CONFIG2, 0x20); // 0.5uS encoding, 1ms period

//  writeRegister(MPR121_AUTOCONFIG0, 0x8F);

//  writeRegister(MPR121_UPLIMIT, 150);
//  writeRegister(MPR121_TARGETLIMIT, 100); // should be ~400 (100 shifted)
//  writeRegister(MPR121_LOWLIMIT, 50);
  // enable all electrodes
  I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_ECR, 0xCF);  // start with first 5 bits of baseline tracking

}



void MPR121_setThresholds(uint8_t touch, uint8_t release) {
  for (uint8_t i=0; i<12; i++) {
    I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_TOUCHTH_0 + 2*i, touch);
    I2C_ByteWrite(I2C1, MPR121_DEFAULT_DEFAULT,MPR121_RELEASETH_0 + 2*i, release);
  }
}


uint16_t  MPR121_baselineData(uint8_t t) {
  if (t > 12) return 0;
  uint16_t bl = MPR121_readRegister8(MPR121_BASELINE_0 + t);
  return (bl << 2);
}

uint16_t  MPR121_touched(void) {
  uint16_t t = MPR121_readRegister16(MPR121_TOUCHSTATUS_L);
  return t & 0x0FFF;
}

/*********************************************************************/


u8 MPR121_readRegister8(u8 reg) {
    
    u8 temp;
    I2C_BufferRead(I2C1, MPR121_DEFAULT_DEFAULT, reg,&temp,1);
    return temp;
}

u16 MPR121_readRegister16(u8 reg){
    
    u8 temp[2];
    I2C_BufferRead(I2C1, MPR121_DEFAULT_DEFAULT, reg,temp,2);
    u16 v = temp[0];
    v |=  ((u16) temp[1]) << 8;
    return v;
}

void MPR121_read_Pressure(u16* Pressure_data) {
 
  u8 tmpBuffer[12];
  I2C_BufferRead(I2C1, MPR121_DEFAULT_DEFAULT, MPR121_FILTDATA_0L,tmpBuffer,12);
  
  for(int i=0; i<6; i++) Pressure_data[i]=(tmpBuffer[2*i] + (tmpBuffer[2*i+1]<< 8));
  
}
  