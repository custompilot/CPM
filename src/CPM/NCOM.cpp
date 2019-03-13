#include "NCOM.h"
#include "defines.h"

NCOM::NCOM()
	: _size(0)
	, Data(NULL)
	, Command(NULL)
{
	Data = new byte[sizeof(GLOBAL::DATA::s_eeprom)];
}

NCOM::~NCOM()
{
}

uint16_t NCOM::loop()
{
	static int step = 0;
	static int current = 0;
	int hr = 0;

	switch(step)
	{
	case 0:
		// stx 읽기
		byte stx;
		current = 0;
		if (hr = read_bytes(&stx, current, 1) && stx == 0x02)
		{
			step++;
			current = 0;
		}
		break;
	case 1:
		// size 읽기
		if (hr = read_bytes(&_size, current, 2) == 2)
		{
			current = 0;
			step++;
		}
		break;
	case 2:
		// command 읽기
		static byte _buf[222];
		if (hr = read_bytes(&Command, current, 2) == 2)
		{
			if (_size > 0)
			{
				step++;
				memset(Data, 0, sizeof(GLOBAL::DATA::s_eeprom));
			}
			else
				step += 2;

			current = 0;
		}
		break;
	case 3:
		// data 읽기
		if (hr = read_bytes(Data, current, _size) == _size)
		{
			step++;
			current = 0;
		}
	case 4:
		// etx 읽기
		byte etx;
		if (hr = read_bytes(&etx, current, 1))
		{
			// step 초기화
			step = 0;

			if (etx == 0x03)
			{
				return Command;
			}
			else
			{
				// packet error
				return -1;
			}
		}
		break;
	
	default:
		step = 0;
		break;
	}

	if (hr < 0)
	{
		// com 에러 발생 통신 초기화
		step = 0;
		current = 0;
	}

	return 0;
}

int NCOM::read_bytes(void* pByte, int& current, int size)
{

	if (Serial.available() && size - current <= 0)
		return -1;

	if (Serial.available())
	{
		current += Serial.readBytes(((char*)pByte + current), size - current);
		return current;
	}
	else
	{
		return 0;
	}
}

void NCOM::Send(int16_t command)
{
	Send(command, NULL, 0);
}
void NCOM::Send(int16_t command, void* data, int size)
{
	Send(command, data, size, NULL, 0);
}
void NCOM::Send(int16_t command, void* data, int size, void* data2, int size2)
{
	int total_size = size + size2;

	// stx 보내기
	Serial.write(0x02);

	// size 보내기
	Serial.write((char*)&total_size, 2);

	// command 보내기
	Serial.write((char*)&command, 2);

	// data 보내기
	if (size > 0)
		Serial.write((byte*)data, size);

	if (size2 > 0)
		Serial.write((byte*)data2, size2);

	// etx 보내기
	Serial.write(0x03);
}

int NCOM::GetDatasize()
{
	return _size;
}
