#include "interfaces.h"
#include "iid.h"
#include <iostream>
#include <locale>

using namespace std;

int main()
{
	CoInitialize(NULL); // This parameter is reserved, 
						// and should be NULL

	HRESULT hr;
	IClassFactory* pCF = NULL;
	ICreatePrinter* pICreatePrinter = NULL;
	IStats* pStats = NULL;
	IEngine* pEngine = NULL;
	IDispatch* pDispatch = NULL;

	hr = CoGetClassObject(CLSID_CoPrinter, CLSCTX_INPROC_SERVER, NULL, IID_IClassFactory, (void**)&pCF);

	// Make a CoPrinter & get ICreatePrinter.
	hr = pCF->CreateInstance(NULL, IID_ICreatePrinter, (void**)&pICreatePrinter);
	pCF->Release();

	if (SUCCEEDED(hr))
	{
		pICreatePrinter->SetMaxSpeed(5);
		BSTR petName = SysAllocString(L"HP!");
		pICreatePrinter->SetPetName(petName);
		SysFreeString(petName);

		hr = pICreatePrinter->QueryInterface(IID_IStats, (void**)&pStats);
		pICreatePrinter->Release();
	}

	if (SUCCEEDED(hr))
	{
		// Show my car!
		pStats->DisplayStats();
		hr = pStats->QueryInterface(IID_IEngine, (void**)&pEngine);
	}

	if (SUCCEEDED(hr))
	{
		int curSp = 0;
		int maxSp = 0;
		int curQual = 0;
		pEngine->GetMaxSpeed(&maxSp);

		do	// Zoom!
		{
			pEngine->SpeedUp();
			pEngine->GetCurSpeed(&curSp);
			pEngine->GetCurQuality(&curQual);
			cout << "Speed is: " << curSp << endl;
			cout << "Quality is " << curQual << endl;
		} while (curSp <= maxSp);

		// Gotta convert to char array.
		char buff[80];
		BSTR bstr;
		pStats->GetPetName(&bstr);
		WideCharToMultiByte(CP_ACP, NULL, bstr, -1, buff, 80, NULL, NULL);
		cout << buff << " has blown up! Lead Foot!" << endl << endl;
		SysFreeString(bstr);

		//hr = pDispatch->QueryInterface(IID_IDispatch, (void**)&pDispatch);
		if (pEngine) pEngine->Release();
		if (pStats) pStats->Release();

	}
	//if (SUCCEEDED(hr))
	//{
	//	UINT *a = 0;
	//	pDispatch->GetTypeInfoCount(a);
	//	IID riid;
	//	LPOLESTR methods[9] = { L"GetMaxSpeed" };
	//	DISPID *b = new DISPID[1];
	//	pDispatch->GetIDsOfNames(riid, methods, 1, 1, b);
	//	cout << b[0];
	//}
	CoUninitialize();
	system("pause");
	return 0;
}
