#include "Control.h"
#include "Canal.h"

using namespace GLOBAL::DATA;
using namespace GLOBAL;

Control::Control()
{
}

Control::~Control()
{
}

void Control::setup()
{
}

void Control::loop()
{
	loop_tail();

	uint16_t pulse;
	for (uint8_t i = 0; i < ___servo_count; i++)
	{
		// normalize
		if ((byte)__eeprom.servo.OCHS[i] == DATA::NA)
		{
			__dat.control.pulses[i] = 0;
		}
		else
		{
			// role pulse
			if (__eeprom.servo.OCHS[i] < DATA::CH01)
				pulse = _tails.bufs[__eeprom.servo.OCHS[i]];
			// bypass ch
			else if (__eeprom.servo.OCHS[i] <= DATA::CH16)
				pulse = __dat.radio.normal.channels[__eeprom.servo.OCHS[i] - DATA::CH01];
			
			if (NBASE::is_pulse_range(pulse))
				__dat.control.pulses[i] = NBASE::get_safe_range(pulse_to_scale(pulse, __eeprom.servo.trim.channels[i]), __eeprom.servo.trim.channels[i].min, __eeprom.servo.trim.channels[i].max);
			else
				__dat.control.pulses[i] = 0;
		}
		
		write_servo(i, __dat.control.pulses[i]);
	}
}

void Control::loop_tail()
{
	// thr, ail + fsron
	static union {
		struct {
			int thr, ail, ele, rud;
		};
		int pointer[4];
	}buf;
	
	for (uint8_t i = 0; i < 4; i++)
		buf.pointer[i] = GetRolePulse(__eeprom.radio.ICH.Roles[i]);

	int fsreon = ___cen_pulse;
	if(__eeprom.radio.ICH.FSReon != NA)
		fsreon = GetRolePulse(__eeprom.radio.ICH.FSReon);

	memset(&_tails, 0, 18);

	// ail range check
	if (NBASE::is_pulse_range(buf.ail))
	{
		int suma = fsreon - ___cen_pulse;
		_tails.AIL = NBASE::get_safe_pulse(buf.ail + suma);
		_tails.AILR = NBASE::get_safe_pulse(buf.ail - suma);
	}	

	_tails.THR = buf.thr;
	
	// ele, rud check
	if (NBASE::is_pulse_range(buf.ele) && NBASE::is_pulse_range(buf.rud))
	{

		_tails.ELE = buf.ele;
		_tails.RUD = buf.rud;

		int suma = buf.ele - ___cen_pulse;
		_tails.VL = buf.rud - suma;
		_tails.VR = buf.rud + suma;

		suma = buf.ail - ___cen_pulse;
		_tails.EV_L = buf.ele + suma;
		_tails.EV_R = buf.ele - suma;

		for (uint8_t i = 1; i <= 8; i++)
		{
			if (i != 2)
				_tails.bufs[i] = NBASE::get_safe_pulse(_tails.bufs[i]);
		}
	}
}


uint16_t Control::GetNoPulseMix(int a, int b, int mix)
{
	if (abs(a) > 900 && abs(b) > 900)
	{
		return a + b + mix;
	}
	else return 0;
}

uint16_t Control::GetRolePulse(uint8_t ich_role)
{
	if (ich_role < DATA::CH01)
		return  __dat.atitude.pulses[ich_role];
	else if (ich_role <= DATA::CH16)
		return __dat.radio.normal.channels[ich_role];
	else return 0;
}

void Control::write_servo(const int ch, const uint16_t pulse)
{
	if (__eeprom.servo.OCHS[ch] != NA && pulse >= 900 && pulse <= 2100)
	{
		if(!_servos[ch].attached())
			_servos[ch].attach(PINOUT::pins[ch], 900, 2100);
		_servos[ch].writeMicroseconds(pulse);
	}
	else if (_servos[ch].attached())
		_servos[ch].detach();
}

void Control::detach()
{
	for (uint8_t i = 0; i < ___servo_count; i++)
		if (_servos[i].attached())
		{
			_servos[i].detach();
			__dat.control.pulses[i] = 0;
		}
}

uint16_t Control::pulse_to_scale(const uint16_t& pulse, s_eeprom::s_channel &trim)
{
	float	scale_pulse;
	if (trim.direction == -1)
		scale_pulse = NBASE::reverse_pulse((float)pulse);
	else
		scale_pulse = (float)pulse;

	if (scale_pulse <= ___cen_pulse)
		scale_pulse = (scale_pulse - (float)___cen_pulse) / ((float)___cen_pulse - (float)___min_pulse) * (trim.offset - (float)trim.min) + trim.offset;
	else
		scale_pulse = (scale_pulse - (float)___cen_pulse) / ((float)___max_pulse - (float)___cen_pulse) * ((float)trim.max - trim.offset) + trim.offset;

	return scale_pulse;
}

/*
uint16_t Control::exponential_curve(uint16_t pulse, uint8_t percent)
{
	double x = (int)NBASE::get_safe_range(pulse, ___min_pulse, ___max_pulse) - ___cen_pulse;
	x = x / 500.0 * 7.9370052598;
	x = pow(x, 3) + ___cen_pulse + 0.5;
	x = x * (double)percent / 100.0 + (double)pulse * (double)(100 - percent) / 100.0;
	return uint16_t(x);
}
*/
