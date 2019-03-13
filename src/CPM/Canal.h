#include "NBASE.h"
#include "Radio.h"
#include "Atitude.h"
#include "defines.h"
#include "Control.h"
//#include "Command.h"
#include "Net.h"
#include "sensors.h"
#include "nwdt.h"
#include <stdio.h>
#include <Arduino.h>

#ifndef ___CANAL_H
#define	___CANAL_H

class Canal
{
public:
					Canal();
					~Canal();
	void			setup();
	void			loop();
	void			test_scenario();
				
	Radio			_radio;
	Atitude			_atitude;
	Control			_control;
	//Command		_command;
	Net				_net;
	Sensors			_sensors;
	nwdt			_wdt;


private:
	void			checkDSMXBinding();
	uint16_t		_looptime;
};

#endif