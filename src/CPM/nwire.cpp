#include "nwire.h"

nwire::nwire()
{
}

nwire::~nwire()
{
}

void nwire::begin()
{
	PORTD &= ~(1 << 0); PORTD &= ~(1 << 1);
	//PORTC &= ~(1 << 4); PORTC &= ~(1 << 5);

	TWSR = 0;
	TWBR = ((F_CPU / 800000) - 16) / 2;			// 8bit maxium: 900 khz
	TWCR = 1 << TWEN;                           // enable twi module, no interrupt

	_error = 0;
}

void nwire::i2c_writeReg(uint8_t add, uint8_t reg, uint8_t val)
{
	i2c_rep_start(add << 1); // I2C write direction
	i2c_write(reg);        // register selection
	i2c_write(val);        // value to write in register
	i2c_stop();
}

void nwire::writeRegMPU6050(uint8_t reg, uint8_t val)
{
	i2c_rep_start(0x68 << 1); // I2C write direction
	i2c_write(reg);        // register selection
	i2c_write(val);        // value to write in register
	i2c_stop();
}



void nwire::i2c_rep_start(uint8_t address)
{
	waitTransmissionI2C((1 << TWINT) | (1 << TWSTA) | (1 << TWEN)); // send REPEAT START condition and wait until transmission completed
	TWDR = address;                                           // send device address
	waitTransmissionI2C((1 << TWINT) | (1 << TWEN));              // wail until transmission completed
}


void nwire::i2c_write(uint8_t data)
{
	TWDR = data;
	waitTransmissionI2C((1 << TWINT) | (1 << TWEN));
}


void nwire::i2c_stop()
{
	TWCR = (1 << TWINT) | (1 << TWEN) | (1 << TWSTO);
}


uint8_t nwire::i2c_readReg(uint8_t add, uint8_t reg, uint8_t* buf, uint8_t size)
{
	uint8_t val;
	i2c_read_reg_to_buf(add, reg, &val, 1);
	return val;
}


uint8_t nwire::i2c_read_reg_to_buf(uint8_t add, uint8_t reg, uint8_t *buf, uint8_t size)
{
	i2c_rep_start(add << 1); // I2C write direction
	i2c_write(reg);        // register selection
	i2c_rep_start((add << 1) | 1);  // I2C read direction
	uint8_t *b = buf;
	uint16_t	_cError = _error;

	while (--size) {
		*b++ = i2c_readAck(); // acknowledge all but the final byte
		if (_error != _cError)
			return 1;
	}
	*b = i2c_readNak();
	if (_error != _cError)
		return 1;
	else
		return 0;
}


uint8_t nwire::i2c_readNak()
{
	waitTransmissionI2C((1 << TWINT) | (1 << TWEN));
	uint8_t r = TWDR;
	i2c_stop();
	return r;
}


uint8_t nwire::i2c_readAck()
{
	waitTransmissionI2C((1 << TWINT) | (1 << TWEN) | (1 << TWEA));
	return TWDR;
}

uint16_t nwire::get_error_count()
{
	return _error;
}