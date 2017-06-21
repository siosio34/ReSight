
#include "MMA8451.h"
#include "stm32f10x_i2c.h"
#include "Delay.h"

void MMA8451_begin() {

  //I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG2, 0x40); // reset

  //while (MMA8451_readRegister8(MMA8451_REG_CTRL_REG2) & 0x40);

  // enable 4G range
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_XYZ_DATA_CFG, MMA8451_RANGE_4_G);
  // High res
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG2, 0x02);
  // DRDY on INT1
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG4, 0x01);
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG5, 0x01);

  // Turn on orientation config
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_PL_CFG, 0x40);

  // Activate at max rate, low noise mode
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG1, 0x01 | 0x04);
}


uint8_t MMA8451_readRegister8(uint8_t reg) {
   
    u8 temp;
    I2C_BufferRead(I2C1, MMA8451_DEFAULT_ADDRESS, reg,&temp,1);
    return temp;
}


void MMA8451_read(s16* Acc_data) {
 
  u8 tmpBuffer[6];
  
  I2C_BufferRead(I2C1, MMA8451_DEFAULT_ADDRESS, MMA8451_REG_OUT_X_MSB,tmpBuffer,6);
  
  for(int i=0; i<3; i++) Acc_data[i]=((s16)((u16)tmpBuffer[2*i] << 8) + tmpBuffer[2*i+1])>>2;
  
  
   /*
  //uint8_t range = getRange();
  uint16_t divider = 1;
  if (range == MMA8451_RANGE_8_G) divider = 1024;
  if (range == MMA8451_RANGE_4_G) divider = 2048;
  if (range == MMA8451_RANGE_2_G) divider = 4096;

  x_g = (float)x / divider;
  y_g = (float)y / divider;
  z_g = (float)z / divider;*/

}


uint8_t MMA8451_getOrientation(void) {
  return MMA8451_readRegister8(MMA8451_REG_PL_STATUS) & 0x07;
}

void MMA8451_setRange(mma8451_range_t range)
{
  uint8_t reg1 = MMA8451_readRegister8(MMA8451_REG_CTRL_REG1);
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG1, 0x00);            // deactivate
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_XYZ_DATA_CFG, range & 0x3);
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG1, reg1 | 0x01);     // activate
}


mma8451_range_t MMA8451_getRange(void)
{
  /* Read the data format register to preserve bits */
  return (mma8451_range_t)(MMA8451_readRegister8(MMA8451_REG_XYZ_DATA_CFG) & 0x03);
}


void MMA8451_setDataRate(mma8451_dataRate_t dataRate)
{
  uint8_t ctl1 = MMA8451_readRegister8(MMA8451_REG_CTRL_REG1);
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG1, 0x00);            // deactivate
  ctl1 &= ~(MMA8451_DATARATE_MASK << 3);                  // mask off bits
  ctl1 |= (dataRate << 3);
  I2C_ByteWrite(I2C1, MMA8451_DEFAULT_ADDRESS , MMA8451_REG_CTRL_REG1, ctl1 | 0x01);     // activate
}


mma8451_dataRate_t MMA8451_getDataRate(void)
{
  return (mma8451_dataRate_t)((MMA8451_readRegister8(MMA8451_REG_CTRL_REG1) >> 3) & MMA8451_DATARATE_MASK);
}



