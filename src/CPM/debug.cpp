#include "debug.h"



debug::debug()
{
}


debug::~debug()
{
}


void debug::setup()
{
	_rad.begin();
}


void debug::loop()
{
	if (Serial.available())
	{
		Serial.read();
		Serial1.read();
	}

	_rad.process();
}
