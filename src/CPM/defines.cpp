#include "defines.h"

using namespace GLOBAL;

#ifdef __AVR_ATmega328P__
	uint8_t PINOUT::pins [] =	{ A3, A2, A1, A0, 13, 12, 11, 10,  9,  8,  7,  6,  5,  4,  3,  2 };
#elif defined( __AVR_ATmega32U4__)
	
	//uint8_t PINOUT::pins[] =	{   9, 10,  5,  6, 11, 12, A4,  0, A1, A2, A3,  4, A5,  7 };

#define ____NOCOPPER	0
#define ____COPPER_3mm	0
#define ____VER100		1 

#if ____COPPER_3mm
	// board no copper
	uint8_t PINOUT::pins[] = { 4, 12,  6,  8,  9, 10,  5, 13, A0, A1, A3, 7 };
#endif

#if ____NOCOPPER
	// board 3mm copper
	uint8_t PINOUT::pins[] =	{  11, 4, 12,  6,  8,  9, 10,  5, 13, A0, A1, A3};
#endif

#if ____VER100
	uint8_t PINOUT::pins[] = { 11, 4, 12,  6,  8,  9, 10,  5, 13, A0, A1, A2 };
#endif


#else
	uint8_t PINOUT::pins[] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 20, 21 };
#endif
		
	void DATA::load_eeprom()
	{
#if defined(__STM32F1__) 
#else
		eeprom_read_block(&__eeprom, 0, sizeof(DATA::s_eeprom));
#endif
	}

	void DATA::save_eeprom()
	{
#ifdef __STM32F1__

#else
		 __dat.monitor.wdt.skip = true;
		eeprom_write_block(&__eeprom, 0, sizeof(DATA::s_eeprom));
		reset_wdt();
#endif
	}

	void DATA::reset_wdt()
	{
		__dat.monitor.wdt.Reset();
		__dat.monitor.wdt.saved_time = millis();
		__dat.monitor.wdt.skip = false;
	}

	void DATA::save_rom()
	{
#ifdef __STM32F1__

#else
		__dat.monitor.wdt.skip = true;
		eeprom_write_block(&__history, (void*)300, sizeof(DATA::s_history));
		reset_wdt();
#endif
	}

	void DATA::load_rom()
	{
#ifdef __STM32F1__

#else
		eeprom_read_block(&__history, (void*)300, sizeof(DATA::s_history));
#endif
	}
	
	void DATA::save_history()
	{
		// save every 3 seconds
		static uint8_t saved = 0;
		if (millis() - __dat.monitor.wdt.saved_time > 3000 && saved < 10)
		{
			// save current sensors
			// current state
			__history.current->FID = __history.FID;
			__history.current->time = micros();

			// 1. vcc
			//if(__history.current->triggers & __trigger_vcc == 0)
			//	__history.current->voltage = __dat.monitor.sensors.raw_vcc;

			// 2. wire error count
			//if(__history.current->triggers & __trigger_i2c == 0)
			//	__history.current->wire_error_count = __dat.imu.i2c_error_count;

			// 3. radio hz
			//if(__history.current->triggers & __trigger_radio == 0)
			//	__history.current->radio_hz = __dat.radio.hz;

			// 4. temperature
			//__history.current->temperature = __dat.monitor.sensors.raw_temp;

			// 5. thread location
			__history.current->wdt_loc = __dat.monitor.wdt.current_location;

			saved++;
			__history.report_count++;
			save_rom();
			__history.get_next_history();
			__dat.monitor.history.need_save = false;
		}
	}

DATA::s_eeprom	DATA::__eeprom;
DATA::s_share	DATA::__dat;
DATA::s_history	DATA::__history;