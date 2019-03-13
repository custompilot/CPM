#include "IMU.h"

#define	___debug_rawacc			0
#define ___debug_rawgyro		0
#define	___debug_acc_step1		0
#define	___debug_acc_step2		0
#define	___debug_acc_step3		0
#define	___debug_acc_step4		0
#define	___debug_acc_step5		0

using namespace GLOBAL;
using namespace DATA;

IMU::IMU()
{
	memset(&_adc, 0, 12);
}

IMU::~IMU()
{
}

void IMU::setup()
{
	MPU6050::setup();
}

void IMU::do_loop()
{
	/*
	int8_t status = getIntStatus();
	if (status & 0x10)
	{
		resetFIFO();
		static bool led = false;
		digitalWrite(A3, led);
		led = !led;
	}*/
	
	if (MPU6050::read_acc() == 0)
	{
		do_acc();
		if (MPU6050::read_gyro() == 0)
		{
			do_gyro();

			//memcpy(_gyroADCinter, _adc.gyro, 6);

			// do_loop2 사용 시 제거
			//*
			/*
			static int16_t		gyroADCprevious[3];
			for (uint8_t axis = 0; axis < 3; axis++)
			{
				_gyroADCinter[axis] = _adc.gyro[axis] + _gyroADCinter[axis];
				// empirical, we take a weighted value of the current and the previous values
				gyro.ypr[axis] = (_gyroADCinter[axis] + gyroADCprevious[axis]) / 3;
				gyroADCprevious[axis] = _gyroADCinter[axis] >> 1;
			}//*/
		}
	}
	__dat.imu.i2c_error_count = get_error_count();
}

void IMU::acc_calibration()
{
}

void IMU::gyro_calibration()
{
}


/*
void IMU::do_loop2()
{
	static int16_t		gyroADCprevious[3];

	MPU6050::read_gyro();
	do_gyro();

	for (uint8_t axis = 0; axis < 3; axis++)
	{
	_gyroADCinter[axis] = _gyroADC[axis] + _gyroADCinter[axis];
	// empirical, we take a weighted value of the current and the previous values
	gyro.ypr[axis] = (_gyroADCinter[axis] + gyroADCprevious[axis]) / 3;
	gyroADCprevious[axis] = _gyroADCinter[axis] >> 1;
	if (!___ACC) _accADC[axis] = 0;
	}
}*/

void IMU::do_gyro()
{	
	// gyro_common
	static		int16_t			previousGyroADC[3] = { 0,0,0 };
	static		int32_t			g[3];
				uint8_t			axis;

	// gyro calibrating
	if (__dat.imu.calibratingG > 0)
	{
		for (axis = 0; axis < 3; axis++) 
		{
			if (__dat.imu.calibratingG == 512)
			{ // Reset g[axis] at start of calibration
				g[axis] = 0;
			}
			g[axis] += _adc.gyro[axis]; // Sum up 512 readings
			__eeprom.mpu.calibration.gyros[axis] = g[axis] >> 9;
		}
		__dat.imu.calibratingG--;
		if (__dat.imu.calibratingG == 0)
		{
			save_eeprom();
			((Net*)__dat.canal.net)->sendEEPROM();
		}
	}	
	for (axis = 0; axis < 3; axis++) 
	{
		_adc.gyro[axis] -= __eeprom.mpu.calibration.gyros[axis];
		//anti gyro glitch, limit the variation between two consecutive readings
		_adc.gyro[axis] = constrain(_adc.gyro[axis], previousGyroADC[axis] - 800, previousGyroADC[axis] + 800);
		//previousGyroADC[axis] = _adc.gyro[axis];
	}

	memcpy(previousGyroADC, _adc.gyro, 6);
}

void IMU::check_nan(s_ypr *ypr, s_ypr *gravity)
{
	static struct {
		int16_t acc[3], gyro[3];
	}pre;

	if (ypr->ypr[0] * ypr->ypr[1] * ypr->ypr[2] * 0 == 0)
	{
		memcpy(&__dat.imu.ypr, ypr, sizeof(s_ypr));
		memcpy(&__dat.imu.gravity, gravity, sizeof(s_ypr));
	}
	else
	{
	}
}

void IMU::do_acc()
{
	s_ypr ypr, gravity;
	
	//acc calibrating
	static int32_t a[3];
	if (__dat.imu.calibratingA > 0) {
		__dat.imu.calibratingA--;
		for (uint8_t axis = 0; axis < 3; axis++) 
		{
			if (__dat.imu.calibratingA == 511)
				a[axis] = 0;   // Reset a[axis] at start of calibration

			a[axis] += _adc.acc[axis];           // Sum up 512 readings
			__eeprom.mpu.calibration.accs[axis] = a[axis] >> 9;
		}
		//__dpln();
		if (__dat.imu.calibratingA == 0) {
			__eeprom.mpu.calibration.accs[2] -= ACC_1G;	// shift Z down by ACC_1G and store values in EEPROM at end of calibration

			//save_eeprom();
		}
	}
	
	for (uint8_t i = 0; i < 3; i++)
		_adc.acc[i] -= __eeprom.mpu.calibration.accs[i];

	// end acc_common	
			double				scale;
			uint16_t			currentT = micros();
	static	uint16_t			previousT;
			uint8_t				axis;
			static	uint32_t	LPFAcc[3] = { 0, 0, 0 };
	static	int16_t				accSmooth[3] = {0, 0, 0};
			int32_t				accMag = 0;
			int16_t				deltaGyroAngle16[3];
	static	t_int32_t_vector	EstG = { 0,0,(int32_t) ACC_1G << 16 };
	static	t_int32_t_vector	EstM = { 0,(int32_t) 1 << 24,0 };
			int32_t				accZ_tmp = 0;
	static  uint8_t				SMALL_ANGLES_25 = 1;
			float				invG;
	static	int16_t				accZ = 0;
	static	int16_t				accZoffset = 0;

	// unit: radian per bit, scaled by 2^16 for further multiplication
	// with a delta time of 3000 us, and GYRO scale of most gyros, scale = a little bit less than 1
	scale = (currentT - previousT) * (GYRO_SCALE * 65536);
	previousT = currentT;
		
	// Initialization
	//*
	for (axis = 0; axis < 3; axis++) {
		// valid as long as LPF_FACTOR is less than 1
		accSmooth[axis] = LPFAcc[axis] >> ___ACC_LPF_FACTOR;
		LPFAcc[axis] += _adc.acc[axis] - accSmooth[axis];
		// used to calculate later the magnitude of acc vector
		accMag += mul(accSmooth[axis], accSmooth[axis]);
		// unit: radian scaled by 2^16
		// imu.gyroADC[axis] is 14 bit long, the scale factor ensure deltaGyroAngle16[axis] is still 14 bit long
		deltaGyroAngle16[axis] = _adc.gyro[axis] * scale;
	}//*/

	rotateV32(&EstG, deltaGyroAngle16);
	rotateV32(&EstM, deltaGyroAngle16);

	/*
	for (axis = 0; axis < 3; axis++) {
		if ((int16_t)(0.85*ACC_1G*ACC_1G / 256) < (int16_t)(accMag >> 8) && (int16_t)(accMag >> 8) < (int16_t)(1.15*ACC_1G*ACC_1G / 256))
			EstG.A32[axis] += (int32_t)(accSmooth[axis] - EstG.A16[2 * axis + 1]) << (16 - ___GYR_CMPF_FACTOR);
			*/

	uint16_t accMag88 = accMag >> 8;
	for (axis = 0; axis < 3; axis++) {
		if ((int16_t)(0.85*ACC_1G*ACC_1G / 256) < accMag88 && accMag88 < (int16_t)(1.15*ACC_1G*ACC_1G / 256))
			EstG.A32[axis] += (int32_t)(accSmooth[axis] - EstG.A16[2 * axis + 1]) << (16 - ___GYR_CMPF_FACTOR);
		
		accZ_tmp += mul(accSmooth[axis], EstG.A16[2 * axis + 1]);
#if MAG
		EstM.A32[axis] += (int32_t)(imu.magADC[axis] - EstM.A16[2 * axis + 1]) << (16 - GYR_CMPFM_FACTOR);
#endif
	}

	/*
	int8_t __a = 1;
	for (int i = 0; i < 3; i++)
	{	
		if (i > 1)
			__a = -1;
		gravity.ypr[i] = 180.0 - __a * (float)EstG.V16.ubuf[i * 2 + 1] * 0.166666666667;
	}*/

	gravity.roll =	180.0 - (float)EstG.V16.Y * 0.166666666667;
	gravity.pitch = 180.0 - (float)EstG.V16.X * 0.166666666667;
	gravity.yaw =	180.0 + (float)EstG.V16.Z * 0.166666666667;
	
	// Attitude of the estimated vector	gravity.roll = E
	int32_t sqGX_sqGZ = mul(EstG.V16.X, EstG.V16.X) + mul(EstG.V16.Z, EstG.V16.Z);
	invG = InvSqrt(sqGX_sqGZ + mul(EstG.V16.Y, EstG.V16.Y));	

	ypr.pitch	= (-atan2(EstG.V16.X, EstG.V16.Z) + 1800) / 10.0;
	ypr.roll	= (1800 - atan2(EstG.V16.Y, InvSqrt(sqGX_sqGZ)*sqGX_sqGZ)) / 10.0;
	ypr.yaw		= (atan2(
		mul(EstM.V16.Z, EstG.V16.X) - mul(EstM.V16.X, EstG.V16.Z),
		(EstM.V16.Y * sqGX_sqGZ - (mul(EstM.V16.X, EstG.V16.X) + mul(EstM.V16.Z, EstG.V16.Z)) * EstG.V16.Y)*invG) + 1800) / 10.0;
	
	accZ = accZ_tmp *  invG;
	accZ -= accZoffset >> 3;

	// pitch to 360 deg
	if (ypr.pitch < 90 || ypr.pitch > 270)
	{
		if (ypr.roll < 180)
			ypr.roll = 180 - ypr.roll;
		else
			ypr.roll = 540 - ypr.roll;
	}

	check_nan(&ypr, &gravity);
}

int32_t __attribute__((noinline)) IMU::mul(int16_t a, int16_t b)
{
	int32_t r;
	MultiS16X16to32(r, a, b);
	return r;
}

void IMU::rotateV32(t_int32_t_vector *v, int16_t* delta) {
	int16_t X = v->V16.X;
	int16_t Y = v->V16.Y;
	int16_t Z = v->V16.Z;

	v->V32.X += mul(delta[0], Z) - mul(delta[2], Y);
	v->V32.Y += mul(delta[1], Z) + mul(delta[2], X);
	v->V32.Z -= mul(delta[0], X) + mul(delta[1], Y);	
}

float IMU::InvSqrt(float x) {
	union {
		int32_t i;
		float   f;
	} conv;
	conv.f = x;
	conv.i = 0x5f1ffff9 - (conv.i >> 1);
	return conv.f * (1.68191409f - 0.703952253f * x * conv.f * conv.f);
}

int16_t IMU::atan2(int32_t y, int32_t x) {
	float z = y;
	int16_t a;
	uint8_t c;
	c = abs(y) < abs(x);
	if (c) { z = z / x; }
	else { z = x / z; }
	a = 2046.43 * (z / (3.5714 + z * z));
	if (c) {
		if (x<0) {
			if (y<0) a -= 1800;
			else a += 1800;
		}
	}
	else {
		a = 900 - a;
		if (y<0) a -= 1800;
	}
	return a;
}
