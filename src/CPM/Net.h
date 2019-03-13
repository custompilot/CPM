#include "NCOM.h"
#include "defines.h"
#include "Radio.h"

#pragma once
class Net
{
public:
	Net(Radio &radio);
	~Net();
	void setup();
	void loop();

private:
	NCOM	_com;
	Radio	&_radio;
public:
	bool					checkDatasize					(int hopeSize);
	void					sendEEPROM						();
};

