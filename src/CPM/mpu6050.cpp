#include "mpu6050.h"
#include "defines.h"

using namespace GLOBAL;
using namespace DATA;

MPU6050::MPU6050()
{
}

MPU6050::~MPU6050()
{
}

void MPU6050::setup()
{
	/*
	_wire.begin();	
	_wire.writeReg(0x6B, 0x80);		// reset
	delay(50);
	_wire.writeReg(0x6B, 0x03);		// clksel
	_wire.writeReg(0x1A, 0);		// ACC bandwidth = 260Hz  GYRO bandwidth = 256Hz
	_wire.writeReg(0x1B, 0x18);		// Full scale set to 2000 deg/sec

	_wire.writeReg(0x1c, 0x10);		//ACCEL_CONFIG  -- AFS_SEL=2 (Full Scale = +/-8G)  ; ACCELL_HPF=0   //note something is wrong in the spec.
	*/	
	begin();
	// gyro init
	writeRegMPU6050(0x6B, 0x80);             //PWR_MGMT_1    -- DEVICE_RESET 1
	delay(50);
	writeRegMPU6050(0x6B, 0x03);             //PWR_MGMT_1    -- SLEEP 0; CYCLE 0; TEMP_DIS 0; CLKSEL 3 (PLL with Z Gyro reference)
	writeRegMPU6050(0x1A, GYRO_DLPF_CFG);    //CONFIG        -- EXT_SYNC_SET 0 (disable input pin for data sync) ; default DLPF_CFG = 0 => ACC bandwidth = 260Hz  GYRO bandwidth = 256Hz)
	writeRegMPU6050(0x1B, 0x18);             //GYRO_CONFIG   -- FS_SEL = 3: Full scale set to 2000 deg/sec

	// acc init
	writeRegMPU6050(0x1C, 0x10);             //ACCEL_CONFIG  -- AFS_SEL=2 (Full Scale = +/-8G)  ; ACCELL_HPF=0   //note something is wrong in the spec.
}

uint8_t MPU6050::read_acc()
{
	if (i2c_read_reg_to_buf(MPU6050_ADDRESS, 0x3B, _buf, 6) == 0)
	{
		if (__eeprom.mpu.mount.reversed == false)
		{
			if (__eeprom.mpu.mount.backward == false)
			{
				___ACC_ORIENTATION_TF(((_buf[0] << 8) | _buf[1]) >> 3, ((_buf[2] << 8) | _buf[3]) >> 3, ((_buf[4] << 8) | _buf[5]) >> 3, _adc.acc[0], _adc.acc[1], _adc.acc[2]);
			}
			else
			{
				___ACC_ORIENTATION_TR(((_buf[0] << 8) | _buf[1]) >> 3, ((_buf[2] << 8) | _buf[3]) >> 3, ((_buf[4] << 8) | _buf[5]) >> 3, _adc.acc[0], _adc.acc[1], _adc.acc[2]);
			}
		}
		else
		{
			if (__eeprom.mpu.mount.backward == false)
			{
				___ACC_ORIENTATION_BF(((_buf[0] << 8) | _buf[1]) >> 3, ((_buf[2] << 8) | _buf[3]) >> 3, ((_buf[4] << 8) | _buf[5]) >> 3, _adc.acc[0], _adc.acc[1], _adc.acc[2]);
			}
			else
			{
				___ACC_ORIENTATION_BR(((_buf[0] << 8) | _buf[1]) >> 3, ((_buf[2] << 8) | _buf[3]) >> 3, ((_buf[4] << 8) | _buf[5]) >> 3, _adc.acc[0], _adc.acc[1], _adc.acc[2]);
			}
		}
		
		return 0;
	}
	return 1;
	//for (int i = 0; i < 3; i++)
	//Serial.println(_raw[i]);
}

uint8_t MPU6050::read_gyro()
{
	if (i2c_read_reg_to_buf(MPU6050_ADDRESS, 0x43, _buf, 6) == 0)
	{
		if (__eeprom.mpu.mount.reversed == false)
		{
			if (__eeprom.mpu.mount.backward == false)
			{
				___GYRO_ORIENTATION_TF(((_buf[0] << 8) | _buf[1]) >> 2, ((_buf[2] << 8) | _buf[3]) >> 2, ((_buf[4] << 8) | _buf[5]) >> 2, _adc.gyro[0], _adc.gyro[1], _adc.gyro[2]);
			}
			else
			{
				___GYRO_ORIENTATION_TR(((_buf[0] << 8) | _buf[1]) >> 2, ((_buf[2] << 8) | _buf[3]) >> 2, ((_buf[4] << 8) | _buf[5]) >> 2, _adc.gyro[0], _adc.gyro[1], _adc.gyro[2]);
			}
		}
		else
		{
			if (__eeprom.mpu.mount.backward == false)
			{
				___GYRO_ORIENTATION_BF(((_buf[0] << 8) | _buf[1]) >> 2, ((_buf[2] << 8) | _buf[3]) >> 2, ((_buf[4] << 8) | _buf[5]) >> 2, _adc.gyro[0], _adc.gyro[1], _adc.gyro[2]);
			}
			else
			{
				___GYRO_ORIENTATION_BR(((_buf[0] << 8) | _buf[1]) >> 2, ((_buf[2] << 8) | _buf[3]) >> 2, ((_buf[4] << 8) | _buf[5]) >> 2, _adc.gyro[0], _adc.gyro[1], _adc.gyro[2]);
			}
		}
		
		return 0;
	}
	return 1;
}

void MPU6050::Reset()
{
	setup();
}

void MPU6050::resetFIFO()
{
	setup();
}

/*
uint16_t MPU6050::byteToUint(uint8_t one, uint8_t two)
{
	return one << 8 | two >> 2;
}*/
