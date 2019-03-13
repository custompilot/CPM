//#define ___debug___

#include "Radio.h"

using namespace GLOBAL::DATA;
using namespace GLOBAL;

Radio::Radio()
{
	_radio = NULL;
}

Radio::~Radio()
{
}

void Radio::setup()
{

}

void Radio::loop()
{
	if (_radio)
	{
		_radio->process();		
		if (_radio->IsDataupdated)
			normalizePulse();
			
		__dat.radio.is_failsafe = _radio->IsFailsafe;
		__dat.radio.NoSignal = _radio->IsNosignal;
	}
}

uint16_t Radio::pulse_to_normalize(uint16_t pulse, s_eeprom::s_channel& trim)
{
	uint16_t s = pulse;
	float com = ((float)s - (float)trim.offset);
	if (s <= trim.offset)
		s = com / ((float)trim.offset - (float)trim.min) * (___cen_pulse - ___min_pulse) + ___cen_pulse;
	else
		s = com / ((float)trim.max - (float)trim.offset) * (___max_pulse - ___cen_pulse) + ___cen_pulse;
	
	return s;
}

void Radio::Begin()
{
	if (_radio != NULL)
	{
		_radio->end();
		_radio = NULL;
	}

	switch (__eeprom.radio.protocol)
	{
#if ___RADIO__SID
	case SBUS:
		_radio = &_sbus;
		break;

	case IBUS:
		_radio = &_ibus;
		break;

	case PPM:
		_radio = &_cppm;
		break;
#else
	case DSM:
		_radio = &_dsx1024;
		break;

	case DSMX:
		_radio = &_dsx;
		break;

	case SUMD:
		return;
		break;
#endif
	default:
		return;
		break;
	}
	_radio->begin();	
}

bool Radio::NoSignal()
{
	return _radio->IsNosignal;
}

void Radio::normalizePulse()
{
	for (int i = 0; i < 16; i++)
	{
		__dat.radio.normal.channels[i] = pulse_to_normalize(__dat.radio.raw.channels[i] / 10, __eeprom.radio.trim);
	}
}

bool Radio::IsDataUpdated()
{
	return _radio->IsDataupdated;
}

uint16_t Radio::getRadiohz()
{
	if (_radio)
		return uint16_t(_radio->Info.dhz);
	else
		return 0;
}


uint16_t Radio::getRadiofhz()
{
	if (_radio)
		return uint16_t(_radio->Info.fhz);
	else
		return 0;
}
