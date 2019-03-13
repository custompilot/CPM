#include "cp_radio_spektrum.h"

cp_radio_spektrum::cp_radio_spektrum()
{
}


cp_radio_spektrum::~cp_radio_spektrum()
{
}

void cp_radio_spektrum::process()
{
	// step 1. receive serial data
	cp_radio_parent::process();

	if (checkAvailable())
	{
		while (_serial->available())
		{			
			serialUpdated();
			if (_stat.serialSpan > NEEDED_FRAME_INTERVAL)
			{
				//*
				//*/
				if(_frameOffset != 16)
					_frameOffset = 0;
			}
			if (_frameOffset < _frameSize)
			{
				_buf.pRaw[_frameOffset++] = _serial->read();
			}
			else
				emptySerial();
						
			if(_frameOffset >= _frameSize)
			{
				frameUpdated();
				// step 2. parse frame
				// fetch the fade count
				//const uint16_t fade = (_rawbuf[0] << 8) + _rawbuf[1];
				//const uint32_t current_secs = micros() / 1000 / (1000 / FADE_REPORTS_PER_SEC);

				// view raw frame
				/*
				for (int i = 0; i < 16; i++)
				{
					if (_rawbuf[i] <= 0xF)
						Serial.print("0");

					Serial.print(_rawbuf[i], HEX);

				}
				Serial.println();
				//*/

				/*
				if (_fade_last_sec == 0) {
				// This is the first frame status received.
				_fade_last_sec_count = fade;
				_fade_last_sec = current_secs;
				}
				else if (_fade_last_sec != current_secs) {
				// If the difference is > 1, then we missed several seconds worth of frames and
				// should just throw out the fade calc (as it's likely a full signal loss).
				if ((current_secs - _fade_last_sec) == 1) {
				if (_rssi_channel != 0) {
				if (_HiRes)
					_rssi = 2048 - ((fade - _fade_last_sec_count) * 2048 / (MAX_FADE_PER_SEC / FADE_REPORTS_PER_SEC));
				else
					_rssi = 1024 - ((fade - _fade_last_sec_count) * 1024 / (MAX_FADE_PER_SEC / FADE_REPORTS_PER_SEC));
				}
				}
				_fade_last_sec_count = fade;
				_fade_last_sec = current_secs;
				}//*/
				if(isChangedRaw())
				{
					
					for (int i = 3; i < _frameSize; i += 2)
					{
						const uint8_t spekChannel = 0x0F & (_buf.pRaw[i - 1] >> _chan_shift);
						//if (spekChannel < _channelCount && spekChannel <= MAX_SUPPORTED_CHANNEL_COUNT)
						if (spekChannel <= MAX_SUPPORTED_CHANNEL_COUNT)
						{
							//if (spekChannel != _rssi_channel)
							//{
								_buf.pPulse[spekChannel] = norm10Pulse((((_buf.pRaw[i - 1] & _chan_mask) << 8) + _buf.pRaw[i]));
							//}
						}
					}
				}
			}
		}
	}
	else
	{
		updateStatistics();
	}
}

void cp_radio_spektrum::begin()
{
	cp_radio_parent::begin();

	// 11 bit frames
	_chan_shift = 3;
	_chan_mask = 0x07;
	//_HiRes = true;
	_rawMin = 148;
	_rawMax = 1900;
}
