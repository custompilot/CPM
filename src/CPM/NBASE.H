#ifndef ___NBASE_H
#define ___NBASE_H

// version		16-09-24		ref voltage monitor
#include <Arduino.h>
#define ___debug___ 0

// ---------------------- debugs --------------------------
#if ___debug___
	#define	__dp(x)				Serial.print(x);
	#define __dpln(x)			Serial.println(x);
	#define __dflush()			Serial.flush();
#else
	#define __dp(x)
	#define __dpln(x)
	#define __dpf(...)
	#define __dflush()
	//*/
#endif

class NBASE
{
public:
	static void setup()
	{
	}

	static void setup_raw_voltage()
	{
	}

#ifndef __SAMD21G18A__
	static float get_raw_voltage()
	{
		static uint8_t reject_count = 1;
		if(ADCSRB)
		{
			ADCSRB = 0;
			reject_count = 1;
			get_raw_voltage();
			return -1;
		}
		else if(reject_count)
		{
			reject_count--;
			get_raw_voltage();
			return -1;
		}		

		// Read 1.1V reference against AVcc
		// set the reference to Vcc and the measurement to the internal 1.1V reference
#if defined(__AVR_ATmega32U4__) || defined(__AVR_ATmega1280__) || defined(__AVR_ATmega2560__)
		ADMUX = _BV(REFS0) | _BV(MUX4) | _BV(MUX3) | _BV(MUX2) | _BV(MUX1);
#elif defined (__AVR_ATtiny24__) || defined(__AVR_ATtiny44__) || defined(__AVR_ATtiny84__)
		ADMUX = _BV(MUX5) | _BV(MUX0);
#elif defined (__AVR_ATtiny25__) || defined(__AVR_ATtiny45__) || defined(__AVR_ATtiny85__)
		ADMUX = _BV(MUX3) | _BV(MUX2);
#else
		ADMUX = _BV(REFS0) | _BV(MUX3) | _BV(MUX2) | _BV(MUX1);
#endif  

		ADCSRA |= _BV(ADSC); // Start conversion	
		

		while (bit_is_set(ADCSRA,ADSC)); // measuring

		uint8_t low  = ADCL; // must read ADCL first - it then locks ADCH  
		uint8_t high = ADCH; // unlocks both

		long result = (high<<8) | low;
		return (1125300L / result) / 1000.0; // Calculate Vcc (in mV); 1125300 = 1.1*1023*1000
	}
#endif
	//*
	static int get_raw_temp()
	{
		double t;

#if defined(__AVR_ATmega32U4__) || defined(__AVR_ATmega1280__) || defined(__AVR_ATmega2560__)
		if(ADCSRB != 32)
		{
			ADCSRB |= (1 << MUX5); // enable the ADC
		}
		// Set the internal reference and mux for the ATmega32U4.

		ADMUX = 0b11000111;
		

		//delay(5); // wait for voltages to become stable.

		ADCSRA |= _BV(ADSC); // Start the ADC

		// Detect end-of-conversion
		while (bit_is_set(ADCSRA,ADSC));

		//delay(5);

		ADCSRA |= _BV(ADSC); // Start the ADC

		// Detect end-of-conversion
		while (bit_is_set(ADCSRA,ADSC));

		byte low = ADCL;
		byte high = ADCH;

		t = (high << 8) | low;
		t = (t - 273 + 5) / 1.00; //Convert from Kelvin to Celcius plus Offset
#endif
		return (t);
	}//*/
	
	static bool is_connected(const int pinA, const int pinB)
	{
		pinMode(pinA, OUTPUT);
		pinMode(pinB, INPUT_PULLUP);
		digitalWrite(pinA, LOW);

		for (int i = 0; i < 77; i++)
		{
			digitalWrite(pinA, i % 2);
			if (digitalRead(pinB) != i % 2)
				return false;
		}
		return true;
	}

	static double get_safe_range(double value, const double min, const double max)
	{
		if (value < min)
			value = min;
		else if (value > max)
			value = max;
		return value;
	}

	static uint16_t get_safe_pulse(double value)
	{
		return get_safe_range(value, 988, 2012);
	}

	static uint16_t reverse_pulse(const uint16_t pulse)
	{
		return 2012 - pulse + 988;
	}

	static void zero_memory(void* const buf, const int size)
	{
		memset(buf, 0, size);
	}

	static bool is_near(const double target, const double value, const double range)
	{
		if (abs(target - value) <= range)
			return true;
		else
			return false;
	}

	static double dmap(double x, double in_min, double in_max, double out_min, double out_max)
	{
		return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
	}

	static bool is_jumping(char a, char b)
	{
		//__dpf("IsConnected %d, %d\n", pinA, pinB);
		pinMode(a, OUTPUT);
		pinMode(b, INPUT_PULLUP);
		digitalWrite(a, LOW);

		for (int i = 0; i < 77; i++)
		{
			digitalWrite(a, i % 2);
			if (digitalRead(b) != i % 2)
				return false;
		}
		return true;

	}

	static bool is_pulse_range(uint16_t pulse)
	{
		if (pulse >= 900 && pulse <= 2100)
			return true;
		else
			return false;
	}
};

class NTimer
{
private:
	unsigned long	_ttime;
	float			_span;
	unsigned long	_now;

private:
	void update_next_time(unsigned long _time)
	{
		_ttime = _time + (double)_span * 1000000.0;
	}

public:
	NTimer(float timespan)
	{
		_span = timespan;
		update_next_time(micros());
	}

	bool IsTime()
	{
		_now = micros();
		if(_now >= _ttime)
		{
			update_next_time(_now);
			return true;
		}
		{
			return false;
		}
	}

	void Reset()
	{
		update_next_time(micros());
	}		
};

class NFilter {
private:
	float _absdt;
	float _current;

public:
	NFilter()
	{
		_absdt = 0.3;
		_current = 0;
	}

	NFilter(float absDT, float value):_absdt(absDT), _current(value)
	{
	}

	float FilterA(float value)
	{
		float dt = value - _current;

		if (abs(dt) <= _absdt)
			return _current;
		
		if (dt < 0)
			dt = _absdt;
		else
			dt = -_absdt;

		_current = value + dt;
		return _current;
	}
};

class NPerformance
{
public:
	NPerformance() {
		_stime = micros();
	}

	uint32_t getLooptime()
	{
		uint32_t looptime = micros() - _stime;
		_stime = micros();
		return looptime;
	}

private:
	uint32_t _stime;
};

class NSerial
#if defined __STM32F1__
	:public USBSerial
#else
	:public HardwareSerial
#endif
{
	public:
	unsigned int NReadInt()
	{
		return ((NReadByte() << 8) + NReadByte());
	}

	byte NReadByte()
	{
		return read(); 
	}
};

#endif