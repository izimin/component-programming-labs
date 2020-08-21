#define MAX_SPEED 60
#define MAX_QUALITY 100
#define MIN_SPEED 0
#define MIN_QUALITY 0
#include <windows.h>
#include "interfaces.h"
#include "stdio.h"

class CoPrinter : public IEngine, public ICreatePrinter, public IStats, public IDispatch
{
public:
	CoPrinter();

	virtual ~CoPrinter();

	// IUnknown
	STDMETHODIMP QueryInterface(REFIID riid, void** pIFace);
	STDMETHODIMP_(DWORD)AddRef();
	STDMETHODIMP_(DWORD)Release();

	// Разработчик IDispatch может использовать его для обеспечения автоматического делегирования вызовов IDispatch 
	// на интерфейс
	ITypeInfo* m_ptinfo = NULL;

	// IDispatch
	STDMETHODIMP GetIDsOfNames(REFIID riid, LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID *rgDispId);
	STDMETHODIMP GetTypeInfo(UINT iTInfo, LCID lcid, ITypeInfo **ppTInfo);
	STDMETHODIMP GetTypeInfoCount(UINT * pctinfo);
	STDMETHODIMP Invoke(DISPID dispIdMember, REFIID riid, LCID lcid, WORD wFlags, DISPPARAMS *pDispParams, 
				VARIANT *pVarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr);

	// IEngine
	STDMETHODIMP SpeedUp();
	STDMETHODIMP QualityUp();
	STDMETHODIMP GetMaxSpeed(int* maxSpeed);
	STDMETHODIMP GetCurSpeed(int* curSpeed);
	STDMETHODIMP GetCurQuality(int* curQuality);

	// IStats
	STDMETHODIMP DisplayStats();
	STDMETHODIMP GetPetName(BSTR* petName);

	// ICreatePrinter
	STDMETHODIMP SetPetName(BSTR petName);
	STDMETHODIMP SetMaxSpeed(int maxSp);

	BSTR m_petName;      // Инициализация через SysAllocString(), 
					     // удаление — через вызов SysFreeString()
	int	 m_maxSpeed;    // Максимальная скорость
	int	 m_currSpeed;   // Текущая скорость СоСаr
	int  m_maxQuality;  // Наилучшее качество
	int  m_currQuality; // Текущее качество

private:
	ULONG m_refCount;
};