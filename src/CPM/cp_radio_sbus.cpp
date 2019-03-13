#include "cp_radio_sbus.h"



cp_radio_sbus::cp_radio_sbus()
{
}


cp_radio_sbus::~cp_radio_sbus()
{
}


void cp_radio_sbus::process()
{
	cp_radio_parent::process();

	if (checkAvailable())
	{
		while (_serial->available())
		{
			serialUpdated();

			_rx = _serial->read();
			if (_frameOffset == 0 && _rx != SBUS_STARTBYTE)
			{
				// Find frame starting point
				continue;
			}

			_buf.pRaw[_frameOffset++] = _rx;

			// parse frame
			if (_frameOffset >= 26)
			{
				// check STX, ETX
				if ((
					_buf.pRaw[24] != SBUS_ENDBYTE0 &&
					_buf.pRaw[24] != SBUS_ENDBYTE1 &&
					_buf.pRaw[24] != SBUS_ENDBYTE2 &&
					_buf.pRaw[24] != SBUS_ENDBYTE3 &&
					_buf.pRaw[24] != SBUS_ENDBYTE4)
					||
					_buf.pRaw[25] != SBUS_STARTBYTE)
				{
					_frameOffset = 0;
					return;
				}

				frameUpdated();
				_frameOffset = 1;

				if ((_buf.pRaw[23] & B1000) >> 3 || (_buf.pRaw[23] & B100) >> 2)
					IsFailsafe = true;
				else
					IsFailsafe = false;

				if (isChangedRaw())
				{
					sbusParse();
				}
			}
		}
	}
	else
		updateStatistics();
}


void cp_radio_sbus::begin()
{
	_serial->begin(100000, SERIAL_8E2);
	_rawMin = 172;
	_rawMax = 1811;
	_frameSize = 25;
}


void cp_radio_sbus::sbusParse()
{
	int bi = 1, a = 0, b = 8;
	for (int i = 0; i < 16; i++)
	{
		int val = _buf.pRaw[bi++] >> a | _buf.pRaw[bi] << b;


		if (a >= 6)
		{
			//val = _buf.pRaw[bi++] >> a | _buf.pRaw[bi] << b | _buf.pRaw[++bi] << (16 - a);
			val = val | _buf.pRaw[++bi] << (16 - a);
		}
		//else
		//{
			//val = _buf.pRaw[bi++] >> a | _buf.pRaw[bi] << b;
		//}

		a = (a + 3) % 8;
		b = 8 - a;

		if (b == 8)
			bi++;

		_buf.pPulse[i] = norm10Pulse(val & 0x07FF);
	}
}
