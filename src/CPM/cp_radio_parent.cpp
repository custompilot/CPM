#include "cp_radio_parent.h"

using namespace GLOBAL::DATA;

cp_radio_parent::cp_radio_parent():_statTimer(1.0)
{
	_buf.pPulse = __dat.radio.raw.channels;
	_buf.pRaw = __dat.buf.raw;
	_buf.preRaw = __dat.buf.preRaw;

	IsFailsafe = IsNosignal = false;
	_serial = NULL;
	_serial = (NSerial*)&Serial1;
}


cp_radio_parent::~cp_radio_parent()
{
}

void cp_radio_parent::serialUpdated()
{
	_stat.serialSpan = _now - _stat.preSerialTime;
	_stat.preSerialTime = _now;
	IsNosignal = false;
}


void cp_radio_parent::frameUpdated()
{
	_stat.fhzCounter++;
	_stat.preFrameTime = _now;
}

void cp_radio_parent::dataUpdated()
{
	_stat.preDataTime = _now;
	IsDataupdated = true;
}

void cp_radio_parent::updateStatistics()
{
	//if (IsFailsafe == false && _now - _stat.preFrameTime > 500000)
	//IsFailsafe = true;

	if (IsNosignal == false && _now - _stat.preSerialTime > 500000)
	{
		IsNosignal = true;
		_frameOffset = 0;
	}
	
	if (IsNosignal && _now - _stat.preDataTime > 500000)
	{
		memset(_buf.pPulse, 0, 32);
		dataUpdated();
	}

	if (_statTimer.IsTime())
	{
		Info.fhz = _stat.fhzCounter;
		Info.dhz = _stat.dhzCounter;

		_stat.fhzCounter = 0;
		_stat.dhzCounter = 0;		

		//Info.preference = (Info.preference + Info.fhz) * 0.9;
	}
}

void cp_radio_parent::end()
{
	if(_serial)
		_serial->end();
}

void cp_radio_parent::process()
{
	IsDataupdated = false;
	_now = micros();
}

void cp_radio_parent::begin()
{
	_serial->begin(115200);
	_frameSize = 32;
}
/*
void cp_radio_parent::viewRaw()

{
	while (_serial->available())
	{
		uint8_t rx = _serial->read();
		if (rx <= 0xf)
			Serial.print("0");
		Serial.print(rx, HEX);

		if (_frameOffset++ >= 31)
		{
			Serial.println();
			_frameOffset = 0;
		}
	}
}*/

bool cp_radio_parent::isChangedRaw()
{
	int c = memcmp(_buf.preRaw, _buf.pRaw, _frameSize);
	if (c != 0)
	{
		/*
		static NTimer _timer(1.0);
		if (_timer.IsTime())
		{
			for (int i = 0; i < 32; i++)
				Serial.print(_buf.pRaw[i], HEX);
			Serial.println();
			for (int i = 0; i < 32; i++)
				Serial.print(_buf.preRaw[i], HEX);


			Serial.println();
			Serial.println();
			Serial.println();
		}*/
		_stat.dhzCounter++;
		dataUpdated();
		memcpy(_buf.preRaw, _buf.pRaw, _frameSize);
		return true;
	}
	return false;
}


void cp_radio_parent::emptySerial()
{
	while (_serial->available())
	{
		_serial->read();
		_frameOffset = 0;
	}
}


uint16_t cp_radio_parent::norm10Pulse(uint16_t raw)
{
	return uint16_t(map(raw, _rawMin, _rawMax, ___min_pulse * 10, ___max_pulse * 10));
}


int cp_radio_parent::checkAvailable()
{
	return Serial1.available();
}
