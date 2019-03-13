#include "Sensors.h"

Sensors::Sensors()
{
}

Sensors::~Sensors()
{
}

void Sensors::setup()
{
	imu.setup();
}

void Sensors::loop()
{
	// read acc, temp, gyro
	imu.do_loop();
}
