#include "nwdt.h"

nwdt::nwdt()
{
}


nwdt::~nwdt()
{
}

void nwdt::setup_sos()
{
	__history.FID++;
	__history.get_next_history();
	memset(&__dat.monitor, 0, sizeof(__dat.monitor));
}

void nwdt::Setup()
{
	cli();  // disable all interrupts
	wdt_reset(); // reset the WDT timer
	MCUSR &= ~(1 << WDRF);  // because the data sheet said to
							/*
							WDTCSR configuration:
							WDIE = 1 :Interrupt Enable
							WDE = 1  :Reset Enable - I won't be using this on the 2560
							WDP3 = 0 :For 1000ms Time-out
							WDP2 = 1 :bit pattern is
							WDP1 = 1 :0110  change this for a different
							WDP0 = 0 :timeout period.
							*/
							// Enter Watchdog Configuration mode:
	WDTCSR = (1 << WDCE) | (1 << WDE);
	// Set Watchdog settings: interrupte enable, 0110 for timer
	WDTCSR = (1 << WDIE) | (0 << WDP3) | (0 << WDP2) | (1 << WDP1) | (1 << WDP0);
	sei();
}

#define __need_save()			__dat.monitor.history.need_save = true
#define __trigger				__history.current->triggers

ISR(WDT_vect) // Watchdog timer interrupt.
{
	wdt_reset();

	if (__dat.monitor.usb.connection_count == 0 )
	{
		if ((millis() - __dat.monitor.wdt.timeout) > 256 && __dat.monitor.wdt.skip == false)
		{
			// 시스템 재부팅
			wdt_disable();

			// wdt 기록
			__trigger |= __trigger_wdt;
			__history.wdt++;

			save_history();
						
			// must be rebooted
			// configure
			MCUSR = 0;                          // reset flags

												// Put timer in reset-only mode:
			WDTCSR |= 0b00011000;               // Enter config mode.
			WDTCSR = 0b00001000 | 0b000000;		// clr WDIE (interrupt enable...7th from left)
												// set WDE (reset enable...4th from left), and set delay interval
												// reset system in 16 ms...
												// unless wdt_disable() in loop() is reached first
												// reboot
			while (1);

		}
	}
	else
		__dat.monitor.usb.connection_count--;
}

void nwdt::loop()
{
	// 왓치독 꺼지면 다시 시작하기
	if (MCUSR != WDTFLAG)
		Setup();

	// 상태 모니터링 하기
	// 1. 전압 제한 4.5V - 16mhz
	static uint8_t pre_vcc = 45;
	if (__dat.monitor.sensors.raw_vcc < pre_vcc)
	{
		//__need_save();
		__trigger |= __trigger_vcc;
		__history.current->voltage = pre_vcc = __dat.monitor.sensors.raw_vcc;
	}

	// 2. 온도 제한 60℃ >, 80℃ > , 85℃
	static uint8_t	pre_temp = 81;
	if (__dat.monitor.sensors.raw_temp > 80 && __dat.monitor.sensors.raw_temp != pre_temp)
	{
		//__need_save();
		__trigger |= __trigger_temp;
		__history.current->temperature = pre_temp = __dat.monitor.sensors.raw_temp;
	}

	// 3. I2C error 0 >, 10 >, 100 >
	static uint16_t	digit = 0;
	if (__dat.imu.i2c_error_count > digit * 10)
	{
		//__need_save();
		__trigger |= __trigger_i2c;

		if (digit == 0)
			digit = 1;

		digit *= 10;
		__history.current->wire_error_count = __dat.imu.i2c_error_count;
	}

	// 4. radio hz, < 10, < 0
	static uint8_t	pre_hz = 10;
	static bool		_start = false;
	static bool		pre_failsafe = false;
	if ((pre_failsafe == false) && __dat.radio.is_failsafe && _start)
	{
		__need_save();
		__trigger |= __trigger_radio;
		pre_failsafe = true;
	}
	else if (__dat.radio.is_failsafe == false && _start == false)
		_start = true;

	// save process
	if (__dat.monitor.history.need_save)
	{
		save_history();
	}
}




