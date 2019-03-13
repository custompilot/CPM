#pragma once

#include <Arduino.h>
#include "Radio.h"
#include "NBASE.h"
#include "defines.h"
#include "IMU.h"

using namespace GLOBAL;
using namespace DATA;

class Atitude
{
public:
	Atitude();
	~Atitude();

	void	setup				();
	void	loop				();
	void	loop_radio			();
	void	get_mode			(int mode_pulse);
	bool	isInDegrees			(float degree, float min, float max);

protected:
	struct s_targets
	{
		union {
			struct {
				//MANUAL, STABILIZE, TAKEOFF, STABILIZE2, HOVERING, REVERSE, KNIFEEDGE, SETUP_MODE = 8, RESET_ACC = 9, RESET_GYRO = 10, NA = 11
				s_ypr MANUAL, STABILIZE, TAKEOFF, HOVERING, REVERSE, KNIFEEDGE, STABILIZE2, m7, setup_mode, reset_acc, reset_gyro, NA;
			};
			s_ypr	bufs[];
		};
		s_ypr *current;
	};

	void		loop_atitude		();
	float		pulse_to_rate		(const uint16_t pulse);
	float		pulse_to_gain		(const int pulse);
	void		loop_manual			(const uint16_t* const channels);
	float		calc360dt			(float targetDegree, float currentDegree);
	int			GetRolePulse		(int role);
	float		fmapPulse			(float value, float vmin, float vmax, float tmin, float tmax);
	int16_t		getPulseFromDT		(float dt, float gain);
	int16_t		pulse_to_tmode		(uint16_t pulse);
	float		calcgain			(byte role);

	s_ypr		input_degree, gain, add;
	s_targets	target_degrees;	
};