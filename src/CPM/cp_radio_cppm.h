#pragma once
#include "cp_radio_parent.h"

class cp_radio_cppm: public cp_radio_parent
{
public:
	cp_radio_cppm();
	~cp_radio_cppm();

	virtual void			process					();
	virtual void			begin					();
	virtual void			end						();

protected:
	void					interrupt				();

	uint16_t				_span;

	volatile	bool		_isInterrupted = false,
							_isFrameUpdated = false;
};

