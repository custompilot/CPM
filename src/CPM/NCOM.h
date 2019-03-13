#pragma once
#include <Arduino.h>

class NCOM
{
public:
	enum ECMD {
		VERSION					= 10000,
		DEVICENAME				= 10100,
		DEVICENAME_SET			= 10200,

		RADIO_RAW				= 20100,
		RADIO_PROTOCOL_SET		= 20200,        //data[01]  - protocol
		RADIO					= 20300,
		RADIO_CAL_SET			= 20400,


		EEPROM_RAW				= 30000,
		EEPROM_SET				= 30100,
		EEPROM_RADIO_ICH		= 30200,

		ROM_RAW					= 35000,
		ROM_RESET				= 35100,

		SERVO_RAW				= 40100,
		SERVO_SET				= 40200,

		IMU_CAL					= 50000,
		IMU_RESET				= 50100,

		LOOPTIME				= 60000,
		UNKNOWN					= 60100,
		ERROR					= 60200,

		DEBUG_WDT			    = 61000,

		TMODE					=  1100
	};

	uint16_t	_size;
	byte*		Data;
	uint16_t	Command;

				NCOM			();
				~NCOM			();
	uint16_t	loop			();
	void		Send			(int16_t command);
	void		Send			(int16_t command, void* data, int size);
	void		Send			(int16_t command, void* data, int size, void* data2, int size2);
	int			read_bytes		(void* pByte,int& current, int size);
	int			GetDatasize		();
};

