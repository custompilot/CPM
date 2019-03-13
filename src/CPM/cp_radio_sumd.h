#pragma once
#include "cp_radio_parent.h"
class cp_radio_sumd :
	public cp_radio_parent
{
public:
						cp_radio_sumd					();
						~cp_radio_sumd					();
	virtual void		process							();
	virtual void		begin							();
};

