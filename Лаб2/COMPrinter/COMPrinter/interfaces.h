#ifndef _INTERFACES   // ���� ����� ���������� ��� 
#define _INTERFACES
#include <windows.h>

/*
DECLARE_INTERFACE_(IStats, IUnknown) - ������� �������� IStats �� IUnknown
STDMETHOD ���������� ���� ��� ������������� �������� HRESULT � STDMETHOD_ ���� ����� ������ ���
HRESULT - ��� �������� ���� ������. ��������� ���� ������ HRESULT �������� ���������� � ��������� ���� ������ � ������ �� ������.
*/

/*  IStats   ������������  ���  ���������  �����   ��������,
� ����� ��� ����������� ���������� ��������� ������������ �������  */
DECLARE_INTERFACE_(IStats, IUnknown)
{
	STDMETHOD(DisplayStats)() PURE;
	STDMETHOD(GetPetName)(BSTR* petName) PURE;
};

/*  IEngine ���������� ��������� ��������.
����� ����������� ������� ������ (��� ���� ����������� ��������),
����� �������� �������� (�������� �����������),
����� �������� �������� ������������ � ������� ��������, � �������� �������� */
DECLARE_INTERFACE_(IEngine, IUnknown)
{
	STDMETHOD(SpeedUp)() PURE;
	STDMETHOD(QualityUp)() PURE;
	STDMETHOD(GetMaxSpeed)(int* maxSpeed) PURE;
	STDMETHOD(GetCurSpeed)(int* curSpeed) PURE;
	STDMETHOD(GetCurQuality)(int* curQuality) PURE;
};

/*	CreateCar ������������ ��� ���������� ����� ������������
�������, ������� ������������ �������� (�������� �������� ������ 100%) */
DECLARE_INTERFACE_(ICreatePrinter, IUnknown)
{
	STDMETHOD(SetPetName)(BSTR petName) PURE;
	STDMETHOD(SetMaxSpeed)(int maxSp) PURE;
};

#endif // _INTERFACES