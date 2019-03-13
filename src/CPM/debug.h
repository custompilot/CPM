#pragma once
#include "Arduino.h"
#include "cp_radio_ibus.h"

class debug
{
public:
	debug();
	~debug();
	void setup();
	void loop();

	cp_radio_ibus _rad;
};

