#pragma once

#include <Arduino.h>
#include <avr/wdt.h>
#include "defines.h"

#define WDTFLAG		67

using namespace GLOBAL;
using namespace DATA;

class nwdt
{
public:
	nwdt();
	~nwdt();
	void Setup();
	void loop();
	void setup_sos();
};

