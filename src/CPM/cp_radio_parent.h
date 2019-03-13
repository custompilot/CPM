#pragma once
#include "NBASE.H"
#include "defines.h"

enum PROTOCOL { SBUS = 0, DSMX = 1, SUMD = 2, PPM = 3, DSM = 4, IBUS = 5 };

class cp_radio_parent
{
public:
						cp_radio_parent();
						~cp_radio_parent();

	virtual void		end							();
	virtual void		process();
	virtual void		begin();

	struct SInfo
	{
		uint16_t		fhz;			// frame hz
		uint16_t		dhz;			// data changed hz
		//float			preference;		// preference hz
	}Info;
	bool				IsFailsafe, IsNosignal, IsDataupdated;

protected:
	
			void				serialUpdated				();
			void				frameUpdated				();
			void				updateStatistics			();
			void				dataUpdated					();
			//void				viewRaw						();
			bool				isChangedRaw				();
			void				emptySerial					();
			uint16_t			norm10Pulse					(uint16_t raw);
			int					checkAvailable				();

			uint8_t				_frameOffset = 0;

	struct {
		uint16_t	*pPulse;
		uint8_t		*pRaw;
		uint8_t		*preRaw;
	}_buf;

	uint8_t				i;
	uint16_t			_rawMin, _rawMax;
	uint8_t				_frameSize;
	

	struct SStat {
		uint32_t		preSerialTime;
		uint32_t		preFrameTime;
		uint32_t		preDataTime;

		uint16_t		fhzCounter, dhzCounter;
		uint16_t		serialSpan;
	}_stat;

	uint32_t			_now;
	NTimer				_statTimer;
	HardwareSerial*		_serial;
	uint8_t				_rx, _rx2;
};

