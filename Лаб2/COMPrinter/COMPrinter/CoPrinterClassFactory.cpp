#include "CoPrinter.h"
#include "CoPrinterClassFactory.h"

extern DWORD g_lockCount;
extern DWORD g_objCount;

// ����������� CoPrinterClassFactory
CoPrinterClassFactory::CoPrinterClassFactory()
{
	m_refCount = 0;
	g_objCount++;
}

// ���������� CoPrinterClassFactory
CoPrinterClassFactory::~CoPrinterClassFactory()
{
	g_objCount--;
}

#pragma region ���������� IUnknown

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

#pragma region ���������� IClassFactory

STDMETHODIMP CoPrinterClassFactory::CreateInstance(LPUNKNOWN pUnkOuter, REFIID riid, void** ppv)
{
	if (pUnkOuter != NULL)					// ���� ������ �� ������� ��������� �� ��������� IUnknown ������...
		return CLASS_E_NOAGGREGATION;		// ���������� ������ - "�������� pUnkOuter ��� ��-NULL, � ������ �� ������������ ���������"
											/*  ��������� � ��� ��������� ����� ���������, ��� �������

											- ���� ������ �������� ������ ��� �����, ��
											- ������� ������ �� �������� ���������� �����������.

											����� �������, ������ ������ ������ NULL

											*/

	CoPrinter* pCarObj = NULL;					// ���� ��� ������, ������� ��������� �� ������ ������ �������
	HRESULT hr;								// �� �� ��� ��� ������		

	pCarObj = new CoPrinter;						// �������� ������ �� ������ ������

	hr = pCarObj->QueryInterface(riid, ppv);	// �������� ��������� �� ������ �������� (�� �����) � ��� ��� ppv � �-� ����� �� ���������, �� �������� �����

	if (FAILED(hr))							// ���� ��� �� ������������ hr != S_OK ������� ��������� �� ������ 
		delete pCarObj;

	return hr;	// S_OK or E_NOINTERFACE.		
}

STDMETHODIMP CoPrinterClassFactory::LockServer(BOOL fLock)
{
	// ��� ���, ���� ����� true �� ���������� ����� ����������� �������, ����� ������� ���� ������������
	// �� ��� ������� �� ����� � �� ����� �����, ��� ��� ��� ����� ���� ������������ ��������������� ���������, ������ ���������. 
	// ������ ��� ��������� ��� ���� ����� ����� ���� ���������������� ������
	if (fLock)
		++g_lockCount;
	else
		--g_lockCount;

	return S_OK;
}
#pragma endregion