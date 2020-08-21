#include <windows.h>
#include <initguid.h>
#include "iid.h" 
#include "interfaces.h"
#include "CoPrinterClassFactory.h"

ULONG g_lockCount = 0; // ���������� ���������� �������
ULONG g_objCount = 0;  // ���������� "�����" �������� � �������


STDAPI DllCanUnloadNow()
{
	if (g_lockCount == 0 && g_objCount == 0)
	{
		return S_OK;
	}
	else
		return S_FALSE;
}

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void** ppv)
{
	HRESULT hr;
	CoPrinterClassFactory *pCFact = NULL;

	if (rclsid != CLSID_CoPrinter)
		return CLASS_E_CLASSNOTAVAILABLE;

	pCFact = new CoPrinterClassFactory;

	hr = pCFact->QueryInterface(riid, ppv);

	if (FAILED(hr))
		delete pCFact;

	return hr;
}