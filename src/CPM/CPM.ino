#include <Servo.h>
#include "defines.h"
#include "Canal.h"
#include <avr/wdt.h>
#include "NBASE.H"
#include "debug.h"

//#if defined __MK20DX256__ || __MK20DX128__
//#include <i2c_t3.h>
//#else
//#endif2558

//#define VER "0.00.001\n"	// 2015.08.24 new project 분기 ms: multi-protocol stabilizer, mpu6050 DMP -> FreeIMU로 변경
//#define VER "0.00.100\n"	// 2015.09.07 1차 테스트 코드 완료
//#define VER "0.00.101\n"	// 2015.09.19 1차 테스트 성공 및 게인 값 변경 기존 0.25~1.75 -> 0.5 ~ 2.5
//#define VER "0.00.102\n"	// 2015.09.21 모드 추가
//#define VER "0.00.103\n"	// 2015.09.29 flap 양쪽 반대 방향, fsron 추가
//#define VER "0.00.104\n"	// 2015.10.01 flap fsron 버그 수정

//#define VER "0.01.000\n"	// 2015-12-27 mp 개발 시작
//#define VER "0.01.001\n"	// 2016-01-13 mp 기본 완료
//#define VER "0.01.002\n"	// 2016-01-15 acc, gyro calibration command 추가
//#define VER "0.01.003\n"	// 2016-01-15 acc, gyro calibration 추가, 8bit 테스트 준비 완료
//#define VER "0.01.004\n"	// 2016-01-22 nanowii 보드 지원
//#define VER "0.01.005\n"	// 2016-01-22 gyro orientation, direction, command 추가/개선
//#define VER "0.01.006\n"	// 2016-02-13 // pulse to 0.25 ~ 1.75 -> 0.5 ~ 3.5, elevator reverse pulse 제거
//#define VER "0.01.005\n"	// 2016-01-29 trim 추가/개선
//#define VER "0.01.006\n"	// 2016-01-29 trim 개선 완성, reverse, hovering, stabilize2 추가
//#define VER "0.01.007\n"	// 2016-03-03 hovering_degree 모드 추가	-- 실패
//#define VER "\n0.01.008\n"// 2016-03-17 i2c 400khz 속도조정, gyro acc cal setup mode 안전장치
//#define VER "\n0.01.009\n"	// 2016-05-04~ knife edge 모드 추가, reverse, knife edge 모드 전환시 에일러론 방향으로 회전하도록

//	#define ___VER "0.02.000";	//	(86% -        -      ) 2016-06-01 PCManager Communication 추가 시작, 조종기 세팅 Command 기능 제거		
//	#define ___VER "0.02.000";	//	(88% - 25,284 - 2525 ) 2016-06-03 net 추가( fps, radio hz)
//	#define ___VER "0.02.001";	//	(88% - 25,206 - 2560 ) 2016-06-06 dynamic ch 적용
// VER 0.02.002	2016 06 15 (85% - 24,330 -     )		version 체계 변경	LED 신호 추가 RED: Serial.available, ich 체계 변경
// VER 0.02.003	2016 06 16 (85% - 24,424 -     )		control 고정 채널 -> 가변 채널로 변경
// VER 0.02.004 2016 06 17 (85% - 24,282 - 1733)		센서 방향성 고정, 최적화, i2c bus 900khz
// VER 0.02.005 2016 06 18 (81% - 23,258 - 1735)		i2c bus 800khz, Expo 제거, Servo 출력 채널, 역할기능 추가
// VER 0.02.006 2016 06 29 (82% - 23,650 - 1761)		mode 체계 변경 전
// VER 0.02.007 2016-06-30 (83% - 23,682 - 1761)		mode 체계 변경 기존 단일 채널 pulse -> tmode로 변경
// VER 0.02.008 2016-08-07 (80% - 22,848 - 1847)		RAW 전압 체크 추가
// VER 0.02.009 2016-08-08 (81% - 23,120 - 1855)		펌웨어 버젼 체크 코드 추가
// VER 0.02.009 2016-08-08 (80% - 22,856 - 1822)		SBUS Failsafe by flag
// VER 0.03.001 2016-09-05 (88% - 25,100 - 1865)		FreeIMU -> Multiwii IMU
// VER 0.04.000 2016-09-22 (83% - 23,750 - 1689)		Arduino Wire->AVR
// VER 0.04.001 2016-09-22 (84% - 23,976 - 1689)		WDT 추가 16ms동안 reset 안하면 동작
// VER 0.04.003 2016-09-22 (84% - 24,082 - 1674), 		i2c error, VCC, TEMP monitor 추가, ver 소스 표기 일원화
// VER 0.04.003 2016-09-22 (85% - 24,390 - 1684), 		history 추가 특정 이벤트 발생 시 history 저장 10개
// VER 0.04.003 2016-09-22 (86% - 24,732 - 1952), 		i2c 오류시 imu 계산 안함 usb 허브 외부 전원 아답터dns로 테스트 가능
// VER 0.04.004 2016-09-27 (88% - 25,334 - 1959), 		모니터링 완료
// VER 0.04.005 2016-10-16 (89% - 25,480 - 1973), 		전압 3.6V 미만에서 4.0V 초과로 복귀시 imu fifoReset
// VER 0.04.006 2016-10-23 (89% - 25,582 - 1975),		설치방향 역, 뒤, history 알람 발생있으면 있던 기록 저장하도록
// VER 0.04.007 2016-10-24 (89% - 25,530 - 1959),		코드 다이어트 1차
// VER 0.04.008 2016-  -   (89% - 25,530 - 1959),		처음 부팅시 서보 이상한 출력 초기값을 no pulse로
// VER 0.04.009 2016-  -   (90% - 25,808 - 1944),		roll 뒤집힌 값 오류 수정
// VER 0.04.010 2016-  -   (90% - 25,786 - 1944),		나이프 에지 롤게인 1.5 -> 0.7, 엘리게인 1.0 -> 0.7
// VER 0.04.011 2016-11-21 (85% - 24,618 - 1755),		위/아래, 정/역 마운트 기능 추가
// VER 0.04.012 2016-11-26 (85% - 24,604 - 1755),		acc gyro cal 통합
// VER 0.04.013 2016-11-30 (85% - 24,610 - 1755),		eeprom save시 wdt skip 추가
// VER 0.04.014 2016-12-10 (85% - 24,582 - 1749),		ICH Role 수정( ch01~16제거), OCH CH01~16 bypass
// VER 0.04.015 2016-12-26 (85% -		 -	   ),		Gravity 각도 수정 * 180 -> 90
// VER 0.04.015 2016-12-26 (78% - 22,536 - 1746),		stabilize2 버그 수정 및 6ms로 낮춤
// VER 0.04.016 2016-12-27 (79% - 22,666 - 1746),		no-pulse 채널별 처리
 
// VER 0.04.017 2017-02-01 (79% - 22,666 - 1790),		name 버퍼 사이즈 확대 20->64 bytes
// VER 0.04.018 2017-02-03 (80% - 23,016 - 1790),		v, delta 양쪽 중 한쪽 면만 no pulse 처리 안되는 버그 수정
// VER 0.04.019 2017-02-07 (80% - 23,016 - 1790),		자동비행 no-pulse 로 처리되는 오류 수정
// VER 0.04.020 2017-03-15 (80% - 23,016 - 1790),		PPM, CPPM 수신기 기능 추가
// VER 0.04.021 2017-04-03 (83% - 23,914 - 1831),		GAIN 의미 변경 input를 타겟 각에서 gain 값으로 변경, EGain 없으면 AGain으로 사용하도록, AGain 없으면 기본값 0.875로 설정
// VER 0.04.022 2017-04-04 (82% - 23,604 - 1835),		호버링 버그 수정, 속도 약간 개선, 크기 최적화, 서보 66hz -> 100hz 
// VER 0.04.023 2017-04-20 (82% - 23,554 - 1872),		Futaba R3008SB 호환성 문제 해결	https://github.com/cleanflight/cleanflight/issues/590 참조
// VER 0.04.024 2017-04-20 (82% - 23,500 - 1872),		아두이노 보드버젼 1.6.18에서 17로 다운 18 버젼 문제발생
// VER 0.04.025 2017-05-16 (82% - 23,892 - 1872),		부팅 시 CH12에 바인딩 점퍼 사용 시 DSMX 부팅 모드로 진입
// VER 0.04.026 2017-05-18 (83% - 23,900 - 1872),		SBUS END BYTE 검사( 안정성 개선 )
// VER 0.04.027 2017-08-04 (83% - 23,846 - 1839),		장치 이름 줄임 버그로 64 -> 32 bytes
// VER 0.04.028 2017-08-16 (84% - 24,284 - 1926),		DSX, DSM 프로토콜 분리

// VER 0.05.000 2017-09-28 (),		Radio 개편, IBUS 추가 SBUS, DSM추가 DSMX 개편, Network 개편, Mode 버그 수정, I, S PPM 수신기 지원 펌
// VER 0.06.000 2017-09-28 (),		Radio 개편, IBUS 추가 SBUS, DSM추가 DSMX 개편, Network 개편, Mode 버그 수정, DS?, SUMD 지원 펌

#if ___RADIO__SID
	#define ___VERSION	{ 'V','E','R',':', 0, 5, 00 }		
#else
	#define ___VERSION	{ 'V','E','R',':', 0, 6, 00 }		
#endif

using namespace GLOBAL::DATA;

Canal _canal;

debug _debug;

/*
void serialEvent1()
{
	_canal._radio.loop();
}*/

void setup()
{
	/*
	_debug.setup();
	while(1)
	_debug.loop();*/

	// debug mode
	/*
	debug _d;
	_d.setup();
	while (1)
		_d.loop();
	//*/
	//USBCON |= (1 << OTGPADE);
	_canal.setup();

	// ******************* write for firmware marking *****************
	//Serial.println(___VERSION);	// 22856
	volatile char ver[] = ___VERSION;

	__dat.VER[0] = ver[4];
	__dat.VER[1] = ver[5];
	__dat.VER[2] = ver[6];

	//Serial.println(ver[0]);
}

void loop()
{
	_canal.loop();
}
