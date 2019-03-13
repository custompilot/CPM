//#define ___debug___

#include "Canal.h"

using namespace GLOBAL::DATA;
using namespace GLOBAL;

Canal::Canal(): _net(_radio)
{
}

Canal::~Canal()
{
}

void Canal::setup()
{
	// DSMX Binding mode check
	checkDSMXBinding();

	//USBCON |= (1 << OTGPADE);
	
	//pinMode(___BLED, OUTPUT);
	//pinMode(___RLED, OUTPUT);
	DDRF = DDRF | B00000001;
	DDRF = DDRF | B00000010;

	//BLED(1);
	//RLED(1);
	___LED_ON(___BLED);
	___LED_ON(___RLED);

	load_eeprom();
	load_rom();

	_radio.Begin();
	
	//int8_t try_count = 16;
	//do {
	_sensors.setup();
		//try_count--;
	//}while(__dat.imu.i2c_error_count != 0 || try_count >= 0);

	_control.setup();
	//enables VBUS pad
	_net.setup();
	_wdt.setup_sos();

	___LED_OFF(___BLED);
	___CRLED(__history.wdt);		
}

#define ___LOC_NET		B00000001	//	1
#define ___LOC_WDT		B00000010	//	2
#define ___LOC_SENSORS	B00000100	//	4
#define ___LOC_RADIO	B00001000	//	8
#define ___LOC_ATITUDE	B00010000	//	16
#define ___LOC_CONTROL	B00100000	//	32
#define ___LOC_STAT		B01000000	//	64


void Canal::loop()
{	
	__dat.monitor.wdt.current_location = ___LOC_NET;
	_net.loop();
		
	// 기본 데이터값 없으면 통신 처리만 하기
	if (__eeprom.plane.initialized != ___initialized_id)
		return;	

	__dat.monitor.wdt.current_location = ___LOC_WDT;
	// 왓치독 리셋하기
	__dat.monitor.wdt.Reset();

	__dat.monitor.wdt.current_location = ___LOC_SENSORS;
	_sensors.loop();
	
	///*
	__dat.monitor.wdt.current_location = ___LOC_RADIO;
	_radio.loop();

	//*
	if (_radio.IsDataUpdated())
		_atitude.loop_radio();

	//*/
	// output servo at 50hz
	//*
	static NTimer _t_servohz(0.02);
	if (_t_servohz.IsTime())
	{
		__dat.monitor.wdt.current_location = ___LOC_ATITUDE;
		_atitude.loop();
		
		__dat.monitor.wdt.current_location = ___LOC_CONTROL;

		if (__dat.radio.NoSignal)
			_control.detach();
		else
			_control.loop();
	}//*/
	static NTimer _ltimer(0.1);
	if (_ltimer.IsTime())
	{
		__dat.monitor.wdt.current_location = ___LOC_STAT;
		// 1초 주기 실행
		static uint8_t oneSecondCount = 0;
		if (oneSecondCount++ >= 10)
		{
			// check watch dog running
			_wdt.loop();

			// usb 통신상태 체크
			___CBLED(__dat.monitor.usb.connection_count);

			__dat.LoopTime = 1000000 / _looptime;
			__dat.radio.hz = _radio.getRadiohz();
			__dat.radio.fhz = _radio.getRadiofhz();
			_looptime = 0;
			oneSecondCount = 0;
		}
		// 0.1초 주기로 실행
		static uint8_t monitorSort = 0;
		if (monitorSort++ <= 5)
		{
			// 전압 모니터링
			float vcc = NBASE::get_raw_voltage();
			static bool _need_reset_imu = false;

			if (vcc > 4.0)
			{
				if (vcc < 3.6)
					_need_reset_imu = true;
				else if (_need_reset_imu && vcc > 4.0)
				{
					_sensors.imu.resetFIFO();
					_need_reset_imu = false;
				}
				__dat.monitor.sensors.raw_vcc = (uint8_t)(vcc * 10);
			}
		}
		else
		{
			// 온도 모니터링
			int16_t temp = NBASE::get_raw_temp();
			if (temp > 0)
				__dat.monitor.sensors.raw_temp = temp;

			if (monitorSort >= 12)
				monitorSort = 0;
		}

		// led controls
		uint8_t red = __history.wdt > 0 ? 20 : 0;
		red += __history.report_count;

		if (monitorSort < red)
		{
			___LED_ON(___RLED);
		}
		else
		{
			___LED_OFF(___RLED);
		}
	}
	
	_looptime++;
}


void Canal::checkDSMXBinding()
{
	/*
	pinMode(A3, INPUT_PULLUP);
	if (digitalRead(A3))
	{
		pinMode(0, OUTPUT);
		while (digitalRead(A3))
		{
			digitalWrite(0, HIGH);
			delay(1);
			digitalWrite(0, LOW);
			delay(1);
		}
	}*/

	pinMode(GLOBAL::PINOUT::pins[11], INPUT_PULLUP);
	if (digitalRead(GLOBAL::PINOUT::pins[11]) == 0)
	{
		_control._servos[11].attach(0);
		_control._servos[11].writeMicroseconds(1500);
		delay(200);
	}	
}
