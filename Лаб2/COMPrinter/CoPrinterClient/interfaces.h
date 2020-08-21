#ifndef _INTERFACES   // ≈сли такой константыы нет 
#define _INTERFACES
#include <windows.h>

/*
DECLARE_INTERFACE_(IStats, IUnknown) - выводим итерфейс IStats из IUnknown
STDMETHOD используем если тип возвращаемого значени€ HRESULT и STDMETHOD_ если любой другой тип
HRESULT - это числовые коды ошибок. –азличные биты внутри HRESULT кодируют информацию о характере кода ошибки и откуда он пришел.
*/

/*  IStats   используетс€  дл€  получени€  марки   принтера,
а также дл€ отображени€ параметров состо€ни€ реализуемого объекта  */
DECLARE_INTERFACE_(IStats, IUnknown)
{
	STDMETHOD(DisplayStats)() PURE;
	STDMETHOD(GetPetName)(BSTR* petName) PURE;
};

/*  IEngine моделирует поведение принтера.
ћожем увеличивать скороть печати (при этом уменьшаетс€ качество),
можем повышать качество (скорость уменьшаетс€),
можем получать значени€ максимальной и текущей скорости, и текущего качества */
DECLARE_INTERFACE_(IEngine, IUnknown)
{
	STDMETHOD(SpeedUp)() PURE;
	STDMETHOD(QualityUp)() PURE;
	STDMETHOD(GetMaxSpeed)(int* maxSpeed) PURE;
	STDMETHOD(GetCurSpeed)(int* curSpeed) PURE;
	STDMETHOD(GetCurQuality)(int* curQuality) PURE;
};

/*	CreateCar используетс€ дл€ присвоени€ имени реализуемому
объекту, задани€ максимальной скорости (нилучшее качество всегда 100%) */
DECLARE_INTERFACE_(ICreatePrinter, IUnknown)
{
	STDMETHOD(SetPetName)(BSTR petName) PURE;
	STDMETHOD(SetMaxSpeed)(int maxSp) PURE;
};

#endif // _INTERFACES