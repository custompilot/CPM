#pragma once
#include "mpu6050.h"
#include "defines.h"
#include "Net.h"

using namespace GLOBAL;

#define MultiS16X16to32(longRes, intIn1, intIn2) \
asm volatile ( \
"clr r26 \n\t" \
"mul %A1, %A2 \n\t" \
"movw %A0, r0 \n\t" \
"muls %B1, %B2 \n\t" \
"movw %C0, r0 \n\t" \
"mulsu %B2, %A1 \n\t" \
"sbc %D0, r26 \n\t" \
"add %B0, r0 \n\t" \
"adc %C0, r1 \n\t" \
"adc %D0, r26 \n\t" \
"mulsu %B1, %A2 \n\t" \
"sbc %D0, r26 \n\t" \
"add %B0, r0 \n\t" \
"adc %C0, r1 \n\t" \
"adc %D0, r26 \n\t" \
"clr r1 \n\t" \
: \
"=&r" (longRes) \
: \
"a" (intIn1), \
"a" (intIn2) \
: \
"r26" \
)

#define ACC_1G 512
#define ACCZ_25deg   (int16_t)(ACC_1G * 0.90631) // 0.90631 = cos(25deg) (cos(theta) of accZ comparison)

// imu

#define ___ACC_LPF_FACTOR	4	
#define ___GYR_CMPF_FACTOR	10

typedef struct {
	int32_t X, Y, Z;
} t_int32_t_vector_def;

typedef struct {
	union {
		struct {
			uint16_t XL; int16_t X;
			uint16_t YL; int16_t Y;
			uint16_t ZL; int16_t Z;
		};
		uint16_t buf[6];
		int16_t  ubuf[6];
	};
} t_int16_t_vector_def;

// note: we use implicit first 16 MSB bits 32 -> 16 cast. ie V32.X>>16 = V16.X
typedef union {
	int32_t A32[3];
	t_int32_t_vector_def V32;
	int16_t A16[6];
	t_int16_t_vector_def V16;
} t_int32_t_vector;

class IMU: public MPU6050
{
public:
							IMU				();
							~IMU			();
public:
	virtual		void		setup			();
	virtual		void		do_gyro			();
	virtual		void		do_acc			();
	virtual		void		do_loop			();
				//void		do_loop2		();
				void		acc_calibration	();
				void		gyro_calibration();

protected:
				int32_t		mul						(int16_t a, int16_t b);
				void		rotateV32				(t_int32_t_vector *v, int16_t* delta);
				float		InvSqrt					(float x);
				int16_t		atan2					(int32_t y, int32_t x);
				void		check_nan				(s_ypr *ypr, s_ypr *gravity);
				int16_t		_gyroADCinter[3];
};

