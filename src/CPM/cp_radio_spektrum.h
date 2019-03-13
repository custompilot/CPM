#pragma once

#include "cp_radio_parent.h"

#define		NEEDED_FRAME_INTERVAL			5000
#define		FADE_REPORTS_PER_SEC			2
#define		MAX_SUPPORTED_CHANNEL_COUNT		12
#define		MAX_FADE_PER_SEC				40

class cp_radio_spektrum: public cp_radio_parent
{
public:
						cp_radio_spektrum();
						~cp_radio_spektrum();

	virtual void		process							();
	virtual void		begin							();

protected:
	uint8_t				_chan_shift;
	uint8_t				_chan_mask;
	//bool				_HiRes;
	
};

