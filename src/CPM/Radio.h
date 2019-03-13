#pragma once

#include "NBASE.h"
#include <Arduino.h>
#include "cp_radio_parent.h"
#include "cp_radio_spektrum1024.h"
#include "cp_radio_spektrum.h"
#include "cp_radio_sbus.h"
#include "cp_radio_ibus.h"
#include "cp_radio_cppm.h"
#include "defines.h"

using namespace GLOBAL::DATA;

class Radio
{
public:
					Radio				();
					~Radio				();

	void			setup				();
	void			loop				();
	void			Begin				();
	void			normalizePulse		();
	bool			NoSignal			();
	bool			IsDataUpdated		();
	uint16_t		getRadiohz			();
	uint16_t		getRadiofhz			();
	 
	uint16_t		pulse_to_normalize	(uint16_t pulse, s_eeprom::s_channel& trim);
	NSerial*		_serial;

private:
	cp_radio_parent			*_radio;

#if ___RADIO__SID
	cp_radio_sbus			_sbus;
	cp_radio_ibus			_ibus;
	cp_radio_cppm			_cppm;
#else
	cp_radio_spektrum1024	_dsx1024;
	cp_radio_spektrum		_dsx;
	
#endif

	//*/
public:
	
};