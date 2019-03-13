#pragma once

#include <Arduino.h>

class nwire
{
private:
	uint16_t	_error;


public:
				nwire				();
				~nwire				();

public:
	void		begin				();

	size_t		write				(char* b);
	size_t		write				(int i);
	size_t		write				(void* pChar, int size);
	size_t		write				(uint8_t val);
	
	int __attribute__((noinline)) waitTransmissionI2C(uint8_t twcr) {
		TWCR = twcr;
		uint8_t count = 255;
		while (!(TWCR & (1 << TWINT))) {
			count--;
			if (count == 0) {              //we are in a blocking state => we don't insist
				TWCR = 0;                  //and we force a reset on TWINT register
#if defined(WMP)
				neutralizeTime = micros(); //we take a timestamp here to neutralize the value during a short delay
#endif
				_error++;
				return -1;
			}
		}
	};


	void		i2c_writeReg(uint8_t add, uint8_t reg, uint8_t val);
	void		i2c_rep_start(uint8_t address);
	void		i2c_write(uint8_t data);
	void		i2c_stop();
	uint8_t		i2c_readReg(uint8_t add, uint8_t reg, uint8_t* buf, uint8_t size);
	uint8_t		i2c_read_reg_to_buf(uint8_t add, uint8_t reg, uint8_t *buf, uint8_t size);
	uint8_t		i2c_readNak();
	uint8_t		i2c_readAck();
	uint16_t	get_error_count();
	void writeRegMPU6050(uint8_t reg, uint8_t val);
};

