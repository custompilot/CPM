#pragma once
#include <Arduino.h>
#include "nwire.h"
#include "defines.h"

using namespace GLOBAL;

#define MPU6050_ADDRESS			0x68
#define GYRO_DLPF_CFG			0

using namespace GLOBAL;
#define GYRO_SCALE (4 / 16.4 * PI / 180.0 / 1000000.0) //16.4 LSB = 1 deg/s

// 2016. 05 .09
//#define ___ACC_ORIENTATION(rX, rY, rZ, tX, tY, tZ)	{tX = -rX; tY =  -rY; tZ =  rZ;}
//#define ___GYRO_ORIENTATION(rX, rY, rZ, tX, tY, tZ)	{tX =  rY; tY =  -rX; tZ = -rZ;} 

//#define ___ACC_ORIENTATION(rX, rY, rZ, tX, tY, tZ)	{tX = -rX; tY =  rY; tZ =  rZ;}
//#define ___GYRO_ORIENTATION(rX, rY, rZ, tX, tY, tZ)	{tX =  rY; tY =  rX; tZ = -rZ;} 

// nanowii
//#define ___ACC_ORIENTATION(rX, rY, rZ, tX, tY, tZ)	{tX =  -rY; tY =   rX; tZ =   rZ;}
//#define ___GYRO_ORIENTATION(rX, rY, rZ, tX, tY, tZ)	{tX =  -rX; tY =  -rY; tZ =  -rZ;}

// 2016. 09. 04 최종
// 정상
#define ___ACC_ORIENTATION_TF(rX, rY, rZ, tX, tY, tZ)	{tX =  -rY; tY =   rX; tZ =   rZ;}
#define ___GYRO_ORIENTATION_TF(rX, rY, rZ, tX, tY, tZ)	{tX =  -rX; tY =  -rY; tZ =  -rZ;}

// 정상, 역
#define ___ACC_ORIENTATION_TR(rX, rY, rZ, tX, tY, tZ)	{tX =   rY; tY =  -rX; tZ =   rZ;}
#define ___GYRO_ORIENTATION_TR(rX, rY, rZ, tX, tY, tZ)	{tX =   rX; tY =   rY; tZ =  -rZ;}

// 뒤집기
#define ___ACC_ORIENTATION_BF(rX, rY, rZ, tX, tY, tZ)	{tX =  -rY; tY =  -rX; tZ =  -rZ;}
#define ___GYRO_ORIENTATION_BF(rX, rY, rZ, tX, tY, tZ)	{tX =   rX; tY =  -rY; tZ =   rZ;}

// 뒤집기, 역
#define ___ACC_ORIENTATION_BR(rX, rY, rZ, tX, tY, tZ)	{tX =   rY; tY =   rX; tZ =  -rZ;}
#define ___GYRO_ORIENTATION_BR(rX, rY, rZ, tX, tY, tZ)	{tX =  -rX; tY =   rY; tZ =   rZ;}



class MPU6050: public nwire
{
protected:
	nwire		_wire;
	uint8_t		_buf[6];

	struct {
		int16_t		gyro[3];
		int16_t		acc[3];
		int16_t		gyroADCprevious[3];
	}_adc;

public:
	// gyro, acc, temp buf
	union {
		struct {
			s_ypr	acc;
			int16_t temp;
			s_ypr	gyro;
		};
		int16_t	buf[7];
	};

				MPU6050			();
				~MPU6050		();
	void		setup			();
	uint8_t		read_gyro		();
	uint8_t		read_acc		();
	void		Reset();
	void		resetFIFO();
	uint16_t byteToUint(uint8_t one, uint8_t two);
};

