#include "cp_radio_spektrum1024.h"



cp_radio_spektrum1024::cp_radio_spektrum1024()
{
}


cp_radio_spektrum1024::~cp_radio_spektrum1024()
{
}


void cp_radio_spektrum1024::begin()
{
	cp_radio_spektrum::begin();

	// 10 bit frames
	_chan_shift = 2;
	_chan_mask = 0x03;
	//_HiRes = false;
	_rawMin = 191;
	_rawMax = 1008;
}