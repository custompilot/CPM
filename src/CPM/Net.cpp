#include "Net.h"

using namespace GLOBAL;
using namespace DATA;

Net::Net(Radio &radio):_radio(radio)
{
	__dat.canal.net = this;
}


Net::~Net()
{
}


void Net::setup()
{
}

void Net::sendEEPROM()
{
	_com.Send(NCOM::EEPROM_RAW, &__eeprom, sizeof(__eeprom));
}

void Net::loop()
{	
	uint16_t cmd = _com.loop();
	switch (cmd)
	{
	case NCOM::RADIO_RAW:
		//라디오 데이터 보내기
		_com.Send(NCOM::RADIO_RAW, &__dat.radio, sizeof(__dat.radio));
		break;
		
	case NCOM::VERSION:
		// 펌 버젼 및 초기 기본정보 보내기
		unsigned char ver[3 + 8];	// ver: 3 + initedid: 8
		memcpy(&ver[0], __dat.VER, 3);
		memcpy(&ver[3], &__eeprom.plane.initialized, 8);
		_com.Send(NCOM::VERSION, (byte*)ver, 11);
		//_com.Send(NCOM::VERSION, &__dat.VER, 3, &__eeprom.plane.initialized, 8);
		break;

	case NCOM::RADIO_PROTOCOL_SET:
	case NCOM::EEPROM_SET:
		if (checkDatasize(sizeof(__eeprom)))
		{
			memcpy(&__eeprom, _com.Data, sizeof(__eeprom));
			save_eeprom();

			if (cmd == NCOM::RADIO_PROTOCOL_SET)
				_radio.Begin();
		}
		

		break;
	case NCOM::EEPROM_RAW:
		sendEEPROM();
		break;
	/*
	case NCOM::RADIO:
		// radio trim
		if (checkDatasize(sizeof(__eeprom.radio.trim)))
		{
			memcpy(&__eeprom.radio.trim, _com.Data, 7 * 16);
			save_eeprom();
		}
		break;
		*/

	case NCOM::LOOPTIME:
		// looptime
		byte _buf[2 + 12 + 1 + 1 + 2 + 1 + 1 + 12];
		
		// looptime
		memcpy(_buf, &__dat.LoopTime, 2);

		// ypr, gravity, i2c error
		memcpy(&_buf[2], __dat.imu.ypr.ypr, 26);

		// vcc, temp
		memcpy(&_buf[28], &__dat.monitor.sensors.raw_vcc, 2);

		// temp
		//memcpy(&_buf[15], &__dat.monitor.sensors.raw_temp, 1);

		// i2c error
		//memcpy(&_buf[16], &__dat.imu.i2c_error_count, 2);

		// report count, wdt count
		memcpy(&_buf[30], &__history.report_count, 2);

		// wdt_count
		//memcpy(&_buf[19], &__history.wdt, 1);

		// G-force
		//memcpy(&_buf[20], &__dat.imu.gravity, 12);

		_com.Send(NCOM::LOOPTIME, _buf, 32);
		break;
		/*
	case NCOM::EEPROM_RADIO_ICH:
		if (checkDatasize(10))
		{
			memcpy(&__eeprom.radio.ICH, _com.Data, 10);
			save_eeprom();
		}
		break;*/

		/*
	case NCOM::RADIO_CAL_SET:
		if (checkDatasize(sizeof(__eeprom.radio.trim)))
		{
			memcpy(&__eeprom.radio.trim, _com.Data, 7);
			save_eeprom();
		}
		break;*/

	case NCOM::SERVO_RAW:
		_com.Send(NCOM::SERVO_RAW, __dat.control.pulses, 24, &__dat.radio.is_failsafe, 1);
		break;
		
	case NCOM::IMU_CAL:
		__dat.imu.calibratingG = 512;
		__dat.imu.calibratingA = 512;
		break;

	/*
	case NCOM::SERVO_SET:
		if (checkDatasize(sizeof(__eeprom.servo)))
		{
			memcpy(&__eeprom.servo, _com.Data, 96);
			save_eeprom();
		}
		break;
		*/

	case NCOM::TMODE:
		_com.Send(NCOM::TMODE, &__dat.mode, sizeof(__dat.mode));
		break;

		/*
	case NCOM::DEVICENAME:
		_com.Send(NCOM::DEVICENAME, &__eeprom.plane.name, 64);
		break;*/

	/*
	case NCOM::DEVICENAME_SET:
		if (checkDatasize(sizeof(__eeprom.plane.name)))
		{
			memcpy(&__eeprom.plane.name, _com.Data, 64);
			save_eeprom();
		}
		break;
		*/

	case NCOM::ROM_RAW:
		_com.Send(NCOM::ROM_RAW, &__history, sizeof(__history));
		break;

	case NCOM::ROM_RESET:
		memset(&__history, 0, sizeof(__history));
		save_rom();
		__history.get_next_history();
		break;

	/*
	case NCOM::DEBUG_WDT:
		__dat.monitor.usb.connection_count = 0;
		while (1) {

		}
		break;

	default:
		_com.Send(NCOM::UNKNOWN, &_com.Command, 2);
		break;
		*/
	}

	__dat.monitor.usb.connection_count = 10;
}


bool Net::checkDatasize(int hopeSize)
{
	if (hopeSize == _com.GetDatasize())
		return true;
	else
		_com.Send(NCOM::ERROR);

	return false;		
}
