#pragma once

#include <Arduino.h>
#include <Servo.h>
#include "defines.h"

using namespace GLOBAL::DATA;

class Control
{
public:
				Control();
				~Control();

	Servo		_servos[___servo_count];
	struct
	{
		union {
			struct {
				uint16_t AIL, ELE, THR, RUD, AILR, VL, VR, EV_L, EV_R;
			};
			uint16_t bufs[8];
		};
	}_tails;

	void		setup						();
	void		loop						();
	void		write_servo					(const int ch, const uint16_t pulse);
	void		detach						();
	uint16_t	pulse_to_scale				(const uint16_t &pulse, s_eeprom::s_channel& trim);

protected:
	void		loop_tail					();
	uint16_t	GetRolePulse				(uint8_t ich_role);
	uint16_t	GetNoPulseMix				(int a, int b, int mix);

	//uint16_t	exponential_curve			(uint16_t pulse, uint8_t percent);	

};