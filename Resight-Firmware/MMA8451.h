
#ifndef _MMA8451_H_
#define _MMA8451_H_

#include "stm32f10x_i2c.h"
#include<Delay.h>

//#define MMA8451_I2C I2C1

/*=========================================================================
    I2C ADDRESS/BITS
    -----------------------------------------------------------------------*/
    #define MMA8451_DEFAULT_ADDRESS                 (0x1D<<1)    // if A is GND, its 0x1C
/*=========================================================================*/

#define MMA8451_REG_OUT_X_MSB     0x01
#define MMA8451_REG_SYSMOD        0x0B
#define MMA8451_REG_WHOAMI        0x0D
#define MMA8451_REG_XYZ_DATA_CFG  0x0E
#define MMA8451_REG_PL_STATUS     0x10
#define MMA8451_REG_PL_CFG        0x11
#define MMA8451_REG_CTRL_REG1     0x2A
#define MMA8451_REG_CTRL_REG2     0x2B
#define MMA8451_REG_CTRL_REG4     0x2D
#define MMA8451_REG_CTRL_REG5     0x2E



#define MMA8451_PL_PUF            0
#define MMA8451_PL_PUB            1
#define MMA8451_PL_PDF            2
#define MMA8451_PL_PDB            3
#define MMA8451_PL_LRF            4
#define MMA8451_PL_LRB            5
#define MMA8451_PL_LLF            6
#define MMA8451_PL_LLB            7

typedef enum
{
  MMA8451_RANGE_8_G           = 2,   // +/- 8g
  MMA8451_RANGE_4_G           = 1,   // +/- 4g
  MMA8451_RANGE_2_G           = 0    // +/- 2g (default value)
} mma8451_range_t;


/* Used with register 0x2A (MMA8451_REG_CTRL_REG1) to set bandwidth */
typedef enum
{
  MMA8451_DATARATE_800_HZ     = 0, //  800Hz
  MMA8451_DATARATE_400_HZ     = 1, //  400Hz
  MMA8451_DATARATE_200_HZ     = 2, //  200Hz
  MMA8451_DATARATE_100_HZ     = 3, //  100Hz
  MMA8451_DATARATE_50_HZ      = 4, //   50Hz
  MMA8451_DATARATE_12_5_HZ    = 5, // 12.5Hz
  MMA8451_DATARATE_6_25HZ     = 6, // 6.25Hz
  MMA8451_DATARATE_1_56_HZ    = 7, // 1.56Hz

  MMA8451_DATARATE_MASK       = 7
} mma8451_dataRate_t;



  //Adafruit_MMA8451(int32_t id = -1);


  void MMA8451_begin();

  void MMA8451_read();

  void MMA8451_setRange(mma8451_range_t range);
  mma8451_range_t getRange(void);

  void MMA8451_setDataRate(mma8451_dataRate_t dataRate);
  mma8451_dataRate_t getDataRate(void);

  uint8_t MMA8451_getOrientation(void);

  //int16_t x, y, z;
  //float x_g, y_g, z_g;

  //void MMA8451_writeRegister(uint8_t reg, uint8_t value);
  
  uint8_t MMA8451_readRegister8(uint8_t reg);
  

#endif