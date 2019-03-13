#include "cp_radio_cppm.h"

volatile	cp_radio_cppm*		__me;
typedef void(cp_radio_cppm::*PINTFUNC)();
volatile	PINTFUNC	__pint;
volatile	uint32_t	__preTime = 0, __cppmnow;

cp_radio_cppm::cp_radio_cppm()
{
	__me = this;
	__pint = &this->interrupt;
}

cp_radio_cppm::~cp_radio_cppm()
{
}

void cp_radio_cppm::process()
{
	cp_radio_parent::process();

	if (_isInterrupted)
	{
		serialUpdated();
		_isInterrupted = false;

		if (_isFrameUpdated)
		{
			frameUpdated();
			_isFrameUpdated = false;
			
			if (isChangedRaw())
			{
				dataUpdated();
				memcpy(_buf.pPulse, _buf.preRaw, _frameSize);
			}
		}
	}
	else
		updateStatistics();
}

void ppmInterrupted()
{
	__cppmnow = micros();
	(__me->*__pint)();
	__preTime = __cppmnow;
}

void cp_radio_cppm::begin()
{
	pinMode(0, INPUT_PULLUP);
	attachInterrupt(digitalPinToInterrupt(0), ppmInterrupted, RISING);
	_frameSize = 16;
}

void cp_radio_cppm::interrupt()
{	
	_isInterrupted = true;
	_span = (uint16_t)(__cppmnow - __preTime);

	if (_span > 2400 || _frameOffset >= 16)
	{		
		_frameOffset = 0;
		_isFrameUpdated = true;
	}
	else
	{
		_span = _span * 10;
		memcpy(&_buf.pRaw[_frameOffset], &_span, 2);
		_frameOffset += 2;
	}
}


void cp_radio_cppm::end()
{
	detachInterrupt(digitalPinToInterrupt(0));
}
