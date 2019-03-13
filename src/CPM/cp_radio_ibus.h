#pragma once
#include "cp_radio_parent.h"

#define	IBUS_NEEDED_FRAME_INTERVAL	1500

class cp_radio_ibus: public cp_radio_parent
{
public:
								cp_radio_ibus();
								~cp_radio_ibus();
	
	virtual void				process();
	virtual void				begin();

protected:

};

