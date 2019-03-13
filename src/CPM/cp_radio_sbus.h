#pragma once

#include "cp_radio_parent.h"

#define SBUS_STARTBYTE	0x0f
#define SBUS_ENDBYTE0	0x00
#define SBUS_ENDBYTE1	0x04
#define SBUS_ENDBYTE2	0x14
#define SBUS_ENDBYTE3	0x24
#define SBUS_ENDBYTE4	0x34

class cp_radio_sbus: public cp_radio_parent
{
public:
								cp_radio_sbus					();
								~cp_radio_sbus					();

	virtual void				process							();
	virtual void				begin							();

protected:
	void						sbusParse						();
	
};

