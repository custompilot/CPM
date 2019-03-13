#pragma once
#include "cp_radio_spektrum.h"

class cp_radio_spektrum1024: public cp_radio_spektrum
{
public:
	cp_radio_spektrum1024();
	~cp_radio_spektrum1024();

	virtual void				begin();
};

