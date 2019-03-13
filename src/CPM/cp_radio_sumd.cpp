#include "cp_radio_sumd.h"



cp_radio_sumd::cp_radio_sumd()
{
}


cp_radio_sumd::~cp_radio_sumd()
{
}


void cp_radio_sumd::process()
{
	cp_radio_parent::process();

	while (checkAvailable())
	{
		serialUpdated();

		if (_frameOffset == 0)
		{
			_rx = _serial->read();

			if (_rx == 0xA8)
				_frameOffset = 1;
			else
				emptySerial();
		}
		else
		{
			while (_serial->available())
			{
				_buf.pRaw[_frameOffset++] = _serial->read();
				if (_frameOffset >= _frameSize)
				{
					_frameOffset = 0;
					frameUpdated();
					if (isChangedRaw())
					{
						uint8_t offset;
						for (i = 0, offset = 2; i < 16; i++, offset += 2)
						{
							_buf.pPulse[i] = norm10Pulse(_buf.pRaw[2 * i + 1] << 8 + _buf.pPulse[2 * i + 2]);
						}
					}
				}
			}
		}
	}
}


void cp_radio_sumd::begin()
{
	cp_radio_parent::begin();

	_rawMin = 8800;
	_rawMax = 15200;
}
