#define _CRT_SECURE_NO_WARNINGS
#include "CoPrinter.h"
#include "iid.h" 

// ������ � ���������� ����������
extern DWORD g_objCount;
extern DWORD g_lockCount;

// ����������� CoPrinter
CoPrinter::CoPrinter() : m_refCount(0), m_currSpeed(1), m_maxSpeed(60), m_currQuality(100), m_maxQuality(100)
{
	m_petName = SysAllocString(L"Default Pet Name");
	++g_objCount;
}

// ���������� CoPrinter
CoPrinter::~CoPrinter()
{
	--g_objCount;
	if (m_petName)
		SysFreeString(m_petName);
	MessageBox(NULL, L"CoPrinter is dead", L"Destructor", MB_OK |
		MB_SETFOREGROUND);
}

#pragma region ���������� IUnknown

/* ���������� ����� ������
   ������ ���, ����� ������ ����������� ���������, �������� �������� ����� ������������� */
STDMETHODIMP_(DWORD) CoPrinter::AddRef()
{
	++m_refCount;
	return m_refCount;
}

/* ���������� ����� ������
   ����� ������ ��������� ������ � �����������, �������� �������� ����������� */
STDMETHODIMP_(DWORD) CoPrinter::Release()
{
	if (--m_refCount == 0)
	{
		delete this;
		return 0;
	}
	else
		return m_refCount;
}

/* ����� QueryInterface ���������� � �������������� ����������
   � ���������� ��������� �� ������������ ���������  */
STDMETHODIMP CoPrinter::QueryInterface(REFIID riid, void** pIFace)
{
	// Which aspect of me do they want?
	if (riid == IID_IUnknown)
	{
		*pIFace = (IUnknown*)(IEngine*)this;
		MessageBox(NULL, L"Handed out IUnknown", L"QI", MB_OK |
			MB_SETFOREGROUND);
	}

	else if (riid == IID_IEngine)
	{
		*pIFace = (IEngine*)this;
		MessageBox(NULL, L"Handed out IEngine", L"QI", MB_OK |
			MB_SETFOREGROUND);
	}

	else if (riid == IID_IStats)
	{
		*pIFace = (IStats*)this;
		MessageBox(NULL, L"Handed out IStats", L"QI", MB_OK |
			MB_SETFOREGROUND);
	}

	else if (riid == IID_ICreatePrinter)
	{
		*pIFace = (ICreatePrinter*)this;
		MessageBox(NULL, L"Handed out ICreatePrinter", L"QI", MB_OK |
			MB_SETFOREGROUND);
	}
	else if (riid == IID_IDispatch)
	{
		*pIFace = (IDispatch*)this;
		MessageBox(NULL, L"Handed out IDispatch", L"QI", MB_OK |
			MB_SETFOREGROUND);
	}
	else
	{
		*pIFace = NULL;
		return E_NOINTERFACE;
	}

	((IUnknown*)(*pIFace))->AddRef();
	return S_OK;
}

#pragma endregion

#pragma region ���������� IDispatch

LPOLESTR methods[9] = { L"SpeedUp", L"QualityUp", L"GetMaxSpeed", L"GetCurSpeed", L"GetCurQuality",
						L"SetPetName", L"SetMaxSpeed", L"DisplayStats", L"GetPetName" };

/*
	 GetIDsOfNames
	 ������������ ���� ���� � �������������� ����� ���� ���������� � ��������������� ������� ������������� DISPID, 
	 ������� ����� �������������� ��� ����������� ������� Invoke. ������� �������� DispGetIDsOfNames ������������
	 ����������� ���������� GetIDsOfNames.

	 // ���������
	 riid      - ��������������� ��� �������� �������������. ������ ���� IID_NULL.
	 rgszNames - (������� ������) ������ ���� ��� �������������
	 cNames    - ���������� �������������� ���� (����� ������� ������� ���� ������� ��� ������ ����������� � �� �������) 
	 lcid      - �������� ������, � ������� ���������������� �����. (�� �������, �� ����������)
	 rgDispId  - (�������� ������) ���������� Caller ������, ������ ������� �������� �������� ������������� (ID), 
			     ��������������� ������ �� ����, ���������� � ������� rgszNames

	 // ������������ �������� 
	 S_OK				- ��� �����!
	 E_OUTOFMEMORY		- ������������ ������!
	 DISP_E_UNKNOWNNAME - ���� ��� ��������� ��������� ���� �� ���� ��������.   ������������ ������ rgDispId
						  �������� DISPID_UNKNOWN ��� ������ ������, ������� ������������� ������������ �����. 
     DISP_E_UNKNOWNLCID - ������������� ������ (LCID) �� ��� ���������.			 
*/

STDMETHODIMP CoPrinter::GetIDsOfNames(REFIID riid, LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID *rgDispId)
{
	// hr - ��� ������� ������,  hr1 - ��� ������� �����
	HRESULT hr(S_OK), hr1;			

	for (UINT i = 0; i < cNames; i++)
	{
		hr1 = DISP_E_UNKNOWNNAME;
		for (UINT j = 0; j < 9; j++)
		{
			// wcscmp - ��������� ���� �����
			if (wcscmp(methods[j], rgszNames[i]) == 0)
			{
				rgDispId[i] = j;
				hr1 = S_OK;
				break;
			}
		}
		if (FAILED(hr))
		{
			rgDispId[i] = DISPID_UNKNOWN;
			hr = DISP_E_UNKNOWNNAME;
		}
	}

	return hr;
}

/*
	Invoke
	������������ ������ � ��������� � �������, ������������ ��������.
	������� �������� DispInvoke ������������ ����������� ���������� Invoke.

	// ���������
	dispIdMember  - 
	riid      - ��������������� ��� �������� �������������. ������ ���� IID_NULL.
	lcid      - �������� ������, � ������� ���������������� �����. (�� �������, �� ����������)
	wFlags	  - �����, ����������� �������� ������ Invoke.
		// �������� ������
		DISPATCH_METHOD		    -  ������� ���������� ��� �����. ���� �������� ����� ���� � �� �� ���, 
								   ����� ���������� � ���, � ���� DISPATCH_PROPERTYGET.
		DISPATCH_PROPERTYGET    -  ������� ����������� ��� ������� �������� ��� ������.
		DISPATCH_PROPERTYPUT    -  ���� ���������� ��� ������� �������� ��� ������.
		DISPATCH_PROPERTYPUTREF -  ���� ���������� ����� ������� ������, � �� ��� ���������� ��������. 
								   ���� ���� ������������ ������ �����, ����� �������� ��������� ������ �� ������.
    pDispParams - ��������� �� ��������� DISPPARAMS, ���������� ������ ����������, ������ ���������� DISPID 
				  ��� ����������� ���������� � ����� ��� ���������� ��������� � ��������.
	pVarResult  - ��������� �� �����, ��� ������ ���� �������� ���������, ��� NULL, ���� ���������� ������ �� ������� ����������. 
			      ���� �������� ������������, ���� ������ �������� DISPATCH_PROPERTYPUT ��� DISPATCH_PROPERTYPUTREF.
	pExcepInfo  - ��������� �� ���������, ���������� ���������� �� ����������. ��� ��������� ������ ���� ���������, 
				  ���� ������������ DISP_E_EXCEPTION. ����� ���� NULL.
	puArgErr    - ������ ������ rgvarg ������� ���������, ������� ����� ������. ��������� �������� � pDispParams -> rgvarg 
			      � �������� �������, ������� ������ ���������� �������� ���, � �������� ����� ������� ������ � �������. 
				  ���� �������� ������������ ������ �����, ����� �������������� ������������ ��������� �������� DISP_E_TYPEMISMATCH 
				  ��� DISP_E_PARAMNOTFOUND. ���� �������� ����� ���� ���������� � null. ��������� ��. �������� ������.
*/

STDMETHODIMP CoPrinter::Invoke(DISPID dispIdMember, REFIID riid, LCID lcid, WORD wFlags, 
			 DISPPARAMS *pDispParams, VARIANT *pVarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr)
{
	HRESULT hr = S_OK;

	VARIANTARG arg;

	// �������������� �������
	VariantInit(&arg);

	BSTR* name = new BSTR;    // ���������� ��� ������ GetPetName
	int speed, quality;		  // ���������� ��� ������� Get... 

	VariantInit(pVarResult);

	// ������� ����� ����� ��� ������.
	switch (dispIdMember)
	{
	case 0:
		SpeedUp();
		break;
	case 1:
		QualityUp();
		break;
	case 2:
		speed = 0;
		GetMaxSpeed(&speed);
		V_VT(pVarResult) = VT_INT;
		V_INT(pVarResult) = speed;
		break;
	case 3:
		speed = 0;
		GetCurSpeed(&speed);
		V_VT(pVarResult) = VT_INT;
		V_INT(pVarResult) = speed;
		break;
	case 4:
		speed = 0;
		GetCurQuality(&quality);
		V_VT(pVarResult) = VT_INT;
		V_INT(pVarResult) = quality;
		break;
	case 5:
		/*   DispGetParam
			 ��������� �������� �� ��������� DISPPARAMS, �������� ��� �����������, ��� � ����������� ���������, � �������� �������� � ��������� ����.
			 
			 //���������
			 pdispparams - ��������� �� ���������, ���������� IDispatch::Invoke.
			 position    - ������� ��������� � ������ ����������. DispGetParam �������� � ����� �������, ��� ��� ���� position ����� 0, 
						   �� ������������ ��������� �������� �������.
			 vtTarg      - ���, � �������� ������� �������� �������� ���������.
			 pvarResult  - ��������� �� �������, � ������� ������� ��������� ��������.
			 puArgErr    - ����� �������� ��������� �� ������ ���������, ���������� ������ DISP_E_TYPEMISMATCH. 
			               ���� ��������� ������������ Invoke, ����� ������� ������� ���������� ������ ��������� � DISPPARAMS.
		*/
		hr = DispGetParam(pDispParams, 0, VT_BSTR, &arg, puArgErr);
		if (FAILED(hr))
			return hr;
		SetPetName(V_BSTR(&arg));
		break;
	case 6:
		hr = DispGetParam(pDispParams, 0, VT_INT, &arg, puArgErr);
		if (FAILED(hr)) 
			return hr;
		SetMaxSpeed(V_INT(&arg));
		break;
	case 7:
		DisplayStats();
		break;
	case 8:
		GetPetName(name);
		V_VT(pVarResult) = VT_BSTR;
		V_BSTR(pVarResult) = *name;
		break;
	default:
		return DISP_E_UNKNOWNNAME;
		break;
	}
	return S_OK;
}

/*  
	GetTypeInfo
	��������� ���������� � ���� ��� �������, ������� ����� ����� �������������� ��� ��������� ���������� � ���� ��� ����������. 

	//���������
	iTInfo  - ������������ ���������� � ����. ��������� 0 ��� ��������� ���������� � ���� ��� ���������� IDispatch.
	lcid    - ������������� ������ ��� ���������� � ����. ������ ����� ���������� ���������� ���������� ���� ��� ������ ������. 
			  ��� ����� ��� �������, ������� ������������ �������������� ����� ����������. ��� �������, ������� �� ������������ 
			  �������������� ����� ���������, ���� �������� ����� ������������.
    ppTInfo - ����������� ��� ��������������� �������
		// ��������� ��������
		S_OK				- ��� �����!
		DISP_E_BADINDEX     - �������� iTInfo �� ��� 0.	
*/

STDMETHODIMP CoPrinter::GetTypeInfo(UINT iTInfo, LCID lcid, ITypeInfo FAR* FAR* ppTInfo)
{
	if (ppTInfo == NULL)
		return E_INVALIDARG;

	if (iTInfo != 0)
		return DISP_E_BADINDEX;

	m_ptinfo->AddRef();      

	*ppTInfo = m_ptinfo;

	return S_OK;
}

/*
	GetTypeInfoCount
	�������� ���������� ����������� ���������� ����, ������� ������������� ������ (0 ��� 1).

	// ���������
	pctinfo - ���������� ����������� ���������� ����, ��������������� ��������.
			  ���� ������ ������������� ���������� � ����, ��� ����� ����� 1; � ��������� ������ ����� ����� 0
		// ��������� ��������
		S_OK		- �����!
		E_NOTIMPL   - ������� :(
*/

STDMETHODIMP CoPrinter::GetTypeInfoCount(UINT * pctinfo)
{
	if (pctinfo == NULL) 
		return E_INVALIDARG;
	
	*pctinfo = 1;
	return S_OK;
}

#pragma endregion

#pragma region ���������� IEngine

// ���������� �������� ������ �� 1 ���� � ������
STDMETHODIMP CoPrinter::SpeedUp()
{
	m_currSpeed += 1;

	// ��������� �������� �� 1, �������� ����������� �� 5%
	m_currQuality -= 5;

	return S_OK;
}

// ��������� �������� ������ ������ �� 5%
STDMETHODIMP CoPrinter::QualityUp()
{
	m_currQuality += 5;

	// �������� �������� �� 5%, ��������� �������� �� 1
	m_currSpeed -= 1;

	return S_OK;
}

// ��������� ������������ �������� ������ 
STDMETHODIMP CoPrinter::GetMaxSpeed(int* maxSpeed)
{
	*maxSpeed = m_maxSpeed;
	return S_OK;
}

// ��������� ������� �������� ������
STDMETHODIMP CoPrinter::GetCurSpeed(int* curSpeed)
{
	*curSpeed = m_currSpeed;
	return S_OK;
}

// ��������� �������� ��������
STDMETHODIMP CoPrinter::GetCurQuality(int* curQuality)
{
	*curQuality = m_currQuality;
	return S_OK;
}

#pragma endregion

#pragma region ���������� ICreatePrinter  

// ���������� ����� ����������
STDMETHODIMP CoPrinter::SetPetName(BSTR petName)
{
	SysReAllocString(&m_petName, petName);
	return S_OK;
}

// ������� ������������ �������� ����������
STDMETHODIMP CoPrinter::SetMaxSpeed(int maxSp)
{
	if (maxSp < MAX_SPEED && maxSp > MIN_SPEED)
		m_maxSpeed = maxSp;
	return S_OK;
}

#pragma endregion

#pragma region ���������� IStats

// ��������� ����� ����������
// ���������� ������� ����� ����������� ������ BSTR 
STDMETHODIMP CoPrinter::GetPetName(BSTR* petName)
{
	*petName = SysAllocString(m_petName);
	return S_OK;
}

// ����������� ���������� ��������� ������������ �������
STDMETHODIMP CoPrinter::DisplayStats()
{
	MessageBox(NULL, m_petName, L"Pet Name", MB_OK | MB_SETFOREGROUND);
	WCHAR buff[10];
	_itow(m_maxSpeed, buff, 10);
	MessageBox(NULL, buff, L"Max Speed", MB_OK | MB_SETFOREGROUND);
	return S_OK;
}

#pragma endregion