#include "Atitude.h"

Atitude::Atitude()
{
	//int count = sizeof(target_degrees) / sizeof(target_degrees.STABILIZE);

	// set mode target degrees to 180
	memset(&target_degrees, 0, sizeof(target_degrees));

	// takeoff
	target_degrees.TAKEOFF.pitch = 25;

	// reverse
	target_degrees.REVERSE.roll = -180;
			
	// hovering
	target_degrees.HOVERING.pitch = 90;

	memset(&add, 0, sizeof(add));
}

Atitude::~Atitude()
{
}

void Atitude::setup()
{
}

void Atitude::loop()
{	
	loop_atitude();
}

void Atitude::loop_radio()
{		
	// 6-1	
	uint8_t size = sizeof(__eeprom.radio.ICH);
	int j = 1;
	
	__dat.mode.tmode = 0;
	// mode, modeB, modeC
	for (uint8_t i = 0; i < 3; i++, j *= 10)
		if (__eeprom.radio.ICH.Roles[7 + i] != size)
			__dat.mode.tmode += __dat.mode.modes[i] = pulse_to_tmode(GetRolePulse(__eeprom.radio.ICH.Roles[7 + i])) * j;

	/*
	Serial.print(GetRolePulse(__eeprom.radio.ICH.Roles[7]));
	Serial.print(",");
	Serial.println(__dat.mode.tmode);
	*/

	// 1. update flight mode
	get_mode(GetRolePulse(__eeprom.radio.ICH.Mode));

	// 2. update ail, ele, thr, rud
	for (int8_t i = 0, j = 1; i < 3; i++, j *= -1)
	{
		int pulse = GetRolePulse(__eeprom.radio.ICH.Roles[i + 1]);
		if (NBASE::is_pulse_range(pulse))
			input_degree.ypr[i] = NBASE::dmap(GetRolePulse(__eeprom.radio.ICH.Roles[i + 1]), ___min_pulse, ___max_pulse, -___target_degree * j, ___target_degree * j);
		else
			input_degree.ypr[i] = 0;
	}
	// 3. calc gain
	gain.roll = gain.pitch = 0.875;

	if (__eeprom.radio.ICH.AGain != NA)
		gain.pitch = gain.roll = pulse_to_gain(GetRolePulse(__eeprom.radio.ICH.AGain));
	if (__eeprom.radio.ICH.EGain != NA)
		gain.pitch = pulse_to_gain(GetRolePulse(__eeprom.radio.ICH.EGain));
	
	// 4. bypass radios ail~rud
	memcpy(__dat.atitude.pulses, __dat.radio.normal.channels, 32);
}

int Atitude::GetRolePulse(int ch)
{
	// 역할이 16채널 이하에 할당되어 있어야함 255 는 N/A
	if (ch < 16)
		return __dat.radio.normal.channels[ch];
	else
		return ___min_pulse;
}


int16_t Atitude::pulse_to_tmode(uint16_t pulse)
{
	int16_t tmode = int16_t((pulse - ___min_pulse) / 102.4 + 0.5);

	if (tmode >= 9)
		tmode = 9;
	else if (tmode < 0)
		tmode = 0;
	
	return tmode;
}


void Atitude::get_mode(const int mode_pulse)
{
	// updated at: 06-30-2016 pulse to tmode 23,650 kb -> 
	//*
	static uint16_t _preTMode = 9999;

	if (__dat.mode.tmode != _preTMode)
	{
		// 채널 변경됨
		// tmode 최상위 값 가져오기
		int top = __dat.mode.tmode;

		for (uint8_t j = 100; j > 9; j /= 10)
		{
			if (__dat.mode.tmode > j)
				top -= __dat.mode.tmode % j;
		}
		
		/*
		if (__dat.mode.tmode > 100)
			top -= (__dat.mode.tmode % 100);
		else if (__dat.mode.tmode > 10)
			top -= (__dat.mode.tmode % 10);
			*/
		
		// 현재 모드 찾기
		for (char i = 0; i <= 6; i++)
		{
			if (__eeprom.mode.modes[i] == top)
			{
				__dat.mode.FlightMode = (MODE::MODE)(i + 1);
				break;
			}

			// manual 모드면 imu reset 하지 않음
			// 다른 모드이면 무조건 reset하기
			if (i == 0)
				__dat.mode.FlightMode = MODE::MANUAL;
		}

		switch (__dat.mode.FlightMode)
		{
		case MODE::KNIFEEDGE:
			// 나이프 에지 모드
			if (isInDegrees(__dat.imu.ypr.roll, 180, 360))
				// 오른쪽 90도 돌리기
				target_degrees.KNIFEEDGE.roll = 270;
			else
				// 왼쪽 90도 돌리기
				target_degrees.KNIFEEDGE.roll = 90;
			break;
		}

		//현재 비행모드 목표 각 설정
		target_degrees.current = &target_degrees.bufs[__dat.mode.FlightMode - 1];
		memset(&add, 0, sizeof(add));
		_preTMode = __dat.mode.tmode;
	}
}

void Atitude::loop_atitude()
{
	if (__dat.mode.FlightMode <= MODE::MANUAL)
	{
	}
	else
	{
		s_ypr dt;
		float tp, tr;

		if ((__dat.mode.FlightMode == MODE::HOVERING) && isInDegrees(__dat.imu.ypr.pitch, 220, 320))
		{			
			// 호버링 dt to pulse
			// rud, ele 조종
			dt.pitch	= calc360dt(180 - input_degree.pitch ,	__dat.imu.gravity.yaw);
			dt.yaw		= calc360dt(180 - input_degree.yaw,		__dat.imu.gravity.roll);
			
			// 2017-04-03	v0.04.21
			for(int i = 1; i < 3; i++)
				__dat.atitude.pulses[__eeprom.radio.ICH.Roles[1 + i]] = NBASE::get_safe_pulse(getPulseFromDT(dt.ypr[i], gain.pitch * 1.25));			
		}
		else
		{
			if (__dat.imu.ypr.pitch >= 90 && __dat.imu.ypr.pitch <= 270)
				tp = 180;
			else
				tp = 15;		// 배면 비행일 경우 360에서 15도 위를 향하도록 수정

			dt.pitch = calc360dt(tp - target_degrees.current->pitch - input_degree.pitch, -__dat.imu.ypr.pitch);
			if (__dat.mode.FlightMode == MODE::KNIFEEDGE)
			{
				// 나이프에지 모드
				float dp;
				if (target_degrees.current->roll == 270)
				{
					dt.yaw = calc360dt(130 + target_degrees.KNIFEEDGE.pitch, -__dat.imu.gravity.pitch);
					dt.roll = calc360dt(270 + target_degrees.KNIFEEDGE.roll, -__dat.imu.gravity.yaw);
				}
				else
				{
					dt.yaw = -calc360dt(130 + target_degrees.KNIFEEDGE.pitch, -__dat.imu.gravity.pitch);
					dt.roll = -calc360dt(90 + target_degrees.KNIFEEDGE.roll, -__dat.imu.gravity.yaw);
				}

				if (isInDegrees(__dat.imu.ypr.roll, 225, 315) || isInDegrees(__dat.imu.ypr.roll, 45, 135))
				{
					__dat.atitude.pulses[__eeprom.radio.ICH.Rudder] = NBASE::get_safe_pulse(getPulseFromDT(dt.yaw + input_degree.yaw, gain.pitch));		// 2017-04-03
				}
				else
				{
					dt.roll = calc360dt(target_degrees.KNIFEEDGE.roll, __dat.imu.ypr.roll);
					__dat.atitude.pulses[__eeprom.radio.ICH.Elevator] = NBASE::get_safe_pulse(getPulseFromDT(dt.pitch, gain.pitch));		// 2017-04-03
				}

				// 나이프 에지 dt to pulse
				__dat.atitude.pulses[__eeprom.radio.ICH.Aileron] = NBASE::get_safe_pulse(getPulseFromDT(dt.roll + input_degree.roll, gain.roll));		// 2017-04-03
			}
			else
			{
				dt.roll = calc360dt(180 + target_degrees.current->roll + input_degree.roll, __dat.imu.ypr.roll);
				dt.pitch = calc360dt(tp - target_degrees.current->pitch - input_degree.pitch, -__dat.imu.ypr.pitch);
				
				for (int i = 0; i < 2; i++)
				{
					if (__dat.mode.FlightMode == MODE::STABILIZE2)
					{
						const static char		mxDegrees = 15;
						static uint32_t			preTime = 0;
						uint32_t				now = millis();

						//const static float unitTime = 6, dvdTime = 1000 / unitTime;
						const static float unitTime = 6, dvdTime = 50;
						if (now - preTime >= unitTime)
						{
							add.ypr[i] += (dt.ypr[i] / dvdTime);
							add.ypr[i] = NBASE::get_safe_range(add.ypr[i], -mxDegrees, mxDegrees);
							if(i > 0)
								preTime = now;
						}
						dt.ypr[i] += add.ypr[i];
						dt.ypr[i] = NBASE::get_safe_range(dt.ypr[i], -___target_degree, ___target_degree);
					}

					__dat.atitude.pulses[__eeprom.radio.ICH.Roles[i + 1]] = NBASE::get_safe_pulse(getPulseFromDT(dt.ypr[i], gain.ypr[i]));
				}
			}
		}
	}
}

int16_t	Atitude::getPulseFromDT(float dt, float gain)
{
	//return ___cen_pulse + dt * 512.0 / 45.0 * gain;
	return ___cen_pulse + dt * 11.378 * gain;
}

float Atitude::calc360dt(float targetDegree, float currentDegree)
{
	float dt = (targetDegree - currentDegree);

	while (1)
	{
		if (dt > 180.0)
			dt -= 360.0;
		else if (dt < -180.0)
			dt += 360.0;
		else
			break;
	}
	return dt;
}

// pulse to rate: -1.0 - 1.0
float Atitude::pulse_to_rate(const uint16_t pulse)
{
	return (pulse - ___cen_pulse) / 500.0;
}

// pulse to 0.25 ~ 1.75 -> 0.5 ~ 3.5
float Atitude::pulse_to_gain(const int pulse)
{
	//return ((float)(pulse - ___min_pulse) / (float)___wid_pulse) * 3.0 + 0.5;
	return ((float)(pulse - ___min_pulse) / 800.0) + 0.25;				// 2017-04-03 :: 0.25 ~ 1.5
}

bool Atitude::isInDegrees(float degree, float min, float max)
{
	if (degree >= min && degree <= max)
		return true;
	
	return false;
}
