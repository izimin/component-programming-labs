#include "CoPrinter.h"
#include "CoPrinterClassFactory.h"

extern DWORD g_lockCount;
extern DWORD g_objCount;

// Конструктор CoPrinterClassFactory
CoPrinterClassFactory::CoPrinterClassFactory()
{
	m_refCount = 0;
	g_objCount++;
}

// Деструктор CoPrinterClassFactory
CoPrinterClassFactory::~CoPrinterClassFactory()
{
	g_objCount--;
}

#pragma region Реализация IUnknown

STDMETHODIMP_(ULONG) CoPrinterClassFactory::AddRef()
{
	return ++m_refCount;
}

STDMETHODIMP_(ULONG) CoPrinterClassFactory::Release()
{
	if (--m_refCount == 0)
	{
		delete this;
		return 0;
	}
	return m_refCount;
}

STDMETHODIMP CoPrinterClassFactory::QueryInterface(REFIID riid, void** ppv)
{
	// Which aspect of me do they want?
	if (riid == IID_IUnknown)
	{
		*ppv = (IUnknown*)this;
	}
	else if (riid == IID_IClassFactory)
	{
		*ppv = (IClassFactory*)this;
	}
	else
	{
		*ppv = NULL;
		return E_NOINTERFACE;
	}

	((IUnknown*)(*ppv))->AddRef();
	return S_OK;
}

#pragma endregion 

#pragma region Реализация IClassFactory

STDMETHODIMP CoPrinterClassFactory::CreateInstance(LPUNKNOWN pUnkOuter, REFIID riid, void** ppv)
{
	if (pUnkOuter != NULL)					// Если подали не нулевой указатель на интерфейс IUnknown тооооо...
		return CLASS_E_NOAGGREGATION;		// Возвращаем ошибку - "параметр pUnkOuter был не-NULL, и объект не поддерживает агрегацию"
											/*  Агрегация — это отношение между объектами, при котором

											- один объект содержит другой как часть, но
											- внешний объект не является владельцем внутреннего.

											ИНЫМИ СЛОВАМИ, ПРОСТО ВСЕГДА ПОДАЕМ NULL

											*/

	CoPrinter* pCarObj = NULL;					// Если все нормас, создаем указатель на объект класса машинки
	HRESULT hr;								// ох уж это тип ошибок		

	pCarObj = new CoPrinter;						// выделяем память по объект класса

	hr = pCarObj->QueryInterface(riid, ppv);	// Получаем указатель на нужный итерфейс (по гуиду) и так как ppv в ф-ю подан по указателю, то меняется везде

	if (FAILED(hr))							// Если все НЕ благополучно hr != S_OK удаляем указатель на объект 
		delete pCarObj;

	return hr;	// S_OK or E_NOINTERFACE.		
}

STDMETHODIMP CoPrinterClassFactory::LockServer(BOOL fLock)
{
	// Тут изи, если подан true то увеличивам число блокироквок сервера, иначе снимаем одну блокировочку
	// Мы эту функцию не юзаем и не будем юзать, так как она нужна если используется внепроуессорная активация, короче непонятно. 
	// Просто так реализуем для того чтобы можно было инициализировать клаасс
	if (fLock)
		++g_lockCount;
	else
		--g_lockCount;

	return S_OK;
}
#pragma endregion