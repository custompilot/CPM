#pragma once

#include "NBASE.H"
#define	___RADIO__SID			1

// ******************* secret III ****************************
#define ___initialized_id		39486093486093486
// ******************* secret III ****************************

#define ___servo_count			12
#define ___radio_channels		16

#define ___min_pulse			988
#define ___max_pulse			2012
#define ___wid_pulse			1024
#define ___cen_pulse			1500

#define ___omn_pulse			700
#define ___omx_pulse			2300

#define ___target_degree		75

#if defined __MK20DX256__ || defined __MK20DX128__
	#define ___radio_serial		Serial2
#elif defined __AVR_ATmega32U4__
	#define ___radio_serial		Serial1
#else
	#define ___radio_serial Serial
#endif

// chipset
#ifdef __SAMD21G18A__
#define	_usb		SerialUSB
#else
#define _usb		Serial
#endif

#define ___RLED					B00000001
#define ___BLED					B00000010

#define ___PIN_BLED				A4
#define ___PIN_RLED				A5

#define ___CBLED(x)				digitalWrite(___PIN_BLED, x)
#define ___CRLED(x)				digitalWrite(___PIN_RLED , x)

#define ___LED_ON(x)			PORTF = PORTF | x
#define ___LED_OFF(x)			PORTF = PORTF & (~x)

#define __trigger_radio			B00000001
#define __trigger_vcc			B00000010
#define __trigger_temp			B00000100
#define __trigger_i2c			B00001000
#define __trigger_wdt			B00010000

namespace GLOBAL {

	struct s_ypr
	{
		union {
			float ypr[3];
			struct {
				float roll, pitch, yaw;
			};
		};
	};

	namespace PINOUT {
		extern uint8_t pins[];
	}
	
	namespace MODE {
		enum MODE {
			NA, MANUAL, STABILIZE, TAKEOFF, HOVERING, REVERSE, KNIFEEDGE, STABILIZE2, HSTABILIZE
			/*
			1000	1100		1200	1300		1400		1500	1600			1800		1900  			2000
			*/
		};
	}

	namespace CHR {
		enum CHR {
			AL, TL, THR, TR, AR, FL, FR, CH10, CH11, CH12, CH13, CH14, count
		};
	}

	namespace TAIL {
		enum TAIL
		{
			t_tail, v_tail, elevon, count
		};
	}

	namespace DATA
	{
		struct s_history
		{
			uint16_t		FID;
			uint8_t			idx_data;
			uint8_t			report_count;
			uint8_t			wdt;

			struct s_history_data {
				uint16_t	FID;
				uint32_t	time;
				uint16_t	wire_error_count;
				uint8_t		voltage;
				uint8_t		temperature;
				uint8_t		radio_hz;
				uint8_t		wdt_loc;
				uint8_t		triggers;				
			}datas[20];
			
			void get_next_history()
			{
				idx_data++;
				if (idx_data >= 20)
					idx_data = 0;

				current = &datas[idx_data];
			}						

			// 2 byte
			s_history_data*	current;
		};

		struct s_eeprom
		{
			struct s_channel {
				uint16_t	offset, min, max;
				int8_t		direction;
			};
			
			struct s_radio{
			uint8_t		protocol;
			// 01 byte

			struct
			{
				public:
					union {
						struct {
							byte Throttle, Aileron, Elevator, Rudder, AGain, EGain, FSReon, Mode, ModeB, ModeC;
						};
						byte Roles[10];
					};
				}ICH;
			// 10 + 01 = 11

				s_channel	trim;

			// 07 + 11 = 18
			}radio;

			struct s_servo{
				char OCHS[12];
				struct {
					s_channel channels[12];
				}trim;
			}servo;
			//12 + 84 + 18 = 114

			struct {
				struct {
					int16_t		accs[3];
					int16_t		gyros[3];
				}calibration;

				struct {
					bool		backward, reversed;
				}mount;
			}mpu;

			//14 + 114 = 128
			struct {
				union {
					struct { uint16_t MANUAL, STAIBILIZE, TAKEOFF, STABILIZE2, HOVERING, KNIFEEDGE, REVERSE; };
					uint16_t modes[7];
				};
			}mode;

			//14 + 128 = 142


			struct {
				uint64_t	initialized;
				uint64_t	license;
				char		name[32];
			}plane;

			//16 + 32 + 142 = 190
		};

		struct s_share
		{
			uint8_t		VER[3];
			uint16_t	LoopTime = 0;
			s_share()
			{
				imu.calibratingG = imu.calibratingA = 0;
			}

			struct s_radio {
				struct s_source {
					uint16_t channels[___radio_channels];
				}normal, raw;
				uint16_t hz, fhz;
				char is_failsafe;
				bool NoSignal;
			}radio;

			struct s_atitude {
				uint16_t pulses[___radio_channels];
			}atitude;

			struct s_control {
				uint16_t pulses[___radio_channels];
			}control;

			struct s_imu {
				s_ypr		ypr, gravity;
				uint16_t	i2c_error_count;
				int16_t		calibratingG, calibratingA;
			}imu;

			struct s_mode {
				uint16_t	modes[3];
				uint16_t	tmode;
				MODE::MODE	FlightMode;
			}mode;

			struct s_monitor {
				struct {
					uint8_t		raw_vcc;
					uint8_t		raw_temp;
				}sensors;
				struct {
					uint32_t	timeout;
					bool		skip;
					uint32_t	saved_time;
					uint8_t		current_location;

					void Reset()
					{
						timeout = millis();
					}
				}wdt;
				struct{
					uint8_t		connection_count;
					bool		saved;
				}usb;
				struct {
					bool		need_save;
					uint8_t		trigger;
				}history;
			}monitor;

			struct {
				uint8_t raw[32];
				uint8_t preRaw[32];
			}buf;

			struct {
				void* net;
			}canal;
		};

		enum ROLE {
			THR, AL, ELE, RUD, AR, VL, VR, ELL, ELR, CH01 = 9, CH02,
			CH03, CH04, CH05, CH06, CH07, CH08, CH09, CH10, CH11, CH12, 
			CH13, CH14, CH15, CH16, NA = 255
		};
		
		extern void load_eeprom();
		extern void save_eeprom();
		extern void reset_wdt();

		extern void load_rom();
		extern void save_rom();
		
		extern void save_history();

		extern s_eeprom		__eeprom;
		extern s_share		__dat;
		extern s_history	__history;
	};

}