#pragma once
#include "IMU.h"
#include "MPU6050.h"

class Sensors
{
public:
	IMU			imu;

				Sensors			();
				~Sensors		();
	void		setup			();
	void		loop			();
};

