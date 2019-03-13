#include "cp_radio_ibus.h"

cp_radio_ibus::cp_radio_ibus()
{
}


cp_radio_ibus::~cp_radio_ibus()
{
}


void cp_radio_ibus::process()
{
	cp_radio_parent::process();
	//*
	while (checkAvailable() > 2)
	{
		serialUpdated();

		if (_frameOffset == 0)
		{
			_rx = _serial->read();
			_rx2 = _serial->read();

			if (_rx == 0x20 && _rx2 == 0x40)
			{
				//Serial.println("stx found");
				_frameOffset = 2;
			}
			else
			{
				emptySerial();
			}
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
						for (i = 0, offset = 2; i < 14; i++, offset += 2)
						{
							_buf.pPulse[i] = norm10Pulse(_buf.pRaw[offset] + (_buf.pRaw[offset + 1] << 8));
							//Serial.print(_buf.pPulse[i]);
							//Serial.print(" ");
						}
						//Serial.println();
					}
					break;
				}
			}
		}
	}	
	
	updateStatistics();
	//*/



	/*
	if (_serial->available())
	{
		while (_serial->available())
		{
			serialUpdated();
			if (_stat.serialSpan > IBUS_NEEDED_FRAME_INTERVAL)
			{
				_frameOffset = 0;
			}

			if (_frameOffset < _frameSize)
			{
				uint8_t rx = _buf.pRaw[_frameOffset++] = _serial->read();
			}
			else
			{
				emptySerial();
			}
			if (_frameOffset >= _frameSize)
			{	
				frameUpdated();
				if (isChangedRaw())
				{
					_checkSum = 0;
					for (int i = 0, offset = 2; i < 14; i++, offset += 2)
						_buf.pPulse[i] = norm10Pulse(_buf.pRaw[offset] + (_buf.pRaw[offset + 1] << 8));
				}
			}
		}
	}
	else
		updateStatistics();
		//*/
}


void cp_radio_ibus::begin()
{
	//_serial->begin(115200);
	//_frameSize = 32;
	cp_radio_parent::begin();
	
	_rawMin = 1000;
	_rawMax = 2000;
}
