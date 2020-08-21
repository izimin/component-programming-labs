#define _CRT_SECURE_NO_WARNINGS
#include "CoPrinter.h"
#include "iid.h" 

// Доступ к глобальным переменным
extern DWORD g_objCount;
extern DWORD g_lockCount;

// Конструктор CoPrinter
CoPrinter::CoPrinter() : m_refCount(0), m_currSpeed(1), m_maxSpeed(60), m_currQuality(100), m_maxQuality(100)
{
	m_petName = SysAllocString(L"Default Pet Name");
	++g_objCount;
}

// Деструктор CoPrinter
CoPrinter::~CoPrinter()
{
	--g_objCount;
	if (m_petName)
		SysFreeString(m_petName);
	MessageBox(NULL, L"CoPrinter is dead", L"Destructor", MB_OK |
		MB_SETFOREGROUND);
}

#pragma region Реализация IUnknown

/* Увеличение числа ссылок
   Всякий раз, когда клиент запрашивает интерфейс, значение счетчика будет увеличиваться */
STDMETHODIMP_(DWORD) CoPrinter::AddRef()
{
	++m_refCount;
	return m_refCount;
}

/* Уменьшение числа ссылок
   Когда клиент завершает работу с интерфейсом, значение счетчика уменьшается */
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

/* Метод QueryInterface обращается к идентификатору интерфейса
   и возвращает указатель на определенный интерфейс  */
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

#pragma region Реализация IDispatch

LPOLESTR methods[9] = { L"SpeedUp", L"QualityUp", L"GetMaxSpeed", L"GetCurSpeed", L"GetCurQuality",
						L"SetPetName", L"SetMaxSpeed", L"DisplayStats", L"GetPetName" };

/*
	 GetIDsOfNames
	 Сопоставляет один член и необязательный набор ИМЕН аргументов с соответствующим набором целочисленных DISPID, 
	 которые могут использоваться при последующих вызовах Invoke. Функция отправки DispGetIDsOfNames обеспечивает
	 стандартную реализацию GetIDsOfNames.

	 // Параметры
	 riid      - Зарезервировано для будущего использования. Должно быть IID_NULL.
	 rgszNames - (Входной массив) Массив имен для сопоставления
	 cNames    - Количесвто сопоставляемых имен (иными словами сколько имен функций нам нкужно сопоставить с их номером) 
	 lcid      - Контекст локали, в котором интерпретируются имена. (не понятно, не используем)
	 rgDispId  - (выходной массив) Выделенный Caller массив, каждый элемент которого содержит идентификатор (ID), 
			     соответствующий одному из имен, переданных в массиве rgszNames

	 // Возвразаемые значения 
	 S_OK				- Все четко!
	 E_OUTOFMEMORY		- Нелостаточно памяти!
	 DISP_E_UNKNOWNNAME - Одно или несколько указанных имен не были известны.   Возвращаемый массив rgDispId
						  содержит DISPID_UNKNOWN для каждой записи, которая соответствует неизвестному имени. 
     DISP_E_UNKNOWNLCID - Идентификатор локали (LCID) не был распознан.			 
*/

STDMETHODIMP CoPrinter::GetIDsOfNames(REFIID riid, LPOLESTR *rgszNames, UINT cNames, LCID lcid, DISPID *rgDispId)
{
	// hr - для методаа вцелом,  hr1 - для каждого имени
	HRESULT hr(S_OK), hr1;			

	for (UINT i = 0; i < cNames; i++)
	{
		hr1 = DISP_E_UNKNOWNNAME;
		for (UINT j = 0; j < 9; j++)
		{
			// wcscmp - сравнение двух строк
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
	Обеспечивает доступ к свойствам и методам, выставленным объектом.
	Функция отправки DispInvoke обеспечивает стандартную реализацию Invoke.

	// Параметры
	dispIdMember  - 
	riid      - Зарезервировано для будущего использования. Должно быть IID_NULL.
	lcid      - Контекст локали, в котором интерпретируются имена. (не понятно, не используем)
	wFlags	  - Флаги, описывающие контекст вызова Invoke.
		// Значения флагов
		DISPATCH_METHOD		    -  Элемент вызывается как метод. Если свойство имеет одно и то же имя, 
								   можно установить и это, и флаг DISPATCH_PROPERTYGET.
		DISPATCH_PROPERTYGET    -  Элемент извлекается как элемент свойства или данных.
		DISPATCH_PROPERTYPUT    -  Член изменяется как элемент свойства или данных.
		DISPATCH_PROPERTYPUTREF -  Член изменяется путем задания ссылки, а не для присвоения значения. 
								   Этот флаг действителен только тогда, когда свойство принимает ссылку на объект.
    pDispParams - Указатель на структуру DISPPARAMS, содержащую массив аргументов, массив аргументов DISPID 
				  для именованных аргументов и число для количества элементов в массивах.
	pVarResult  - Указатель на место, где должен быть сохранен результат, или NULL, если вызывающий объект не ожидает результата. 
			      Этот аргумент игнорируется, если указан параметр DISPATCH_PROPERTYPUT или DISPATCH_PROPERTYPUTREF.
	pExcepInfo  - Указатель на структуру, содержащую информацию об исключении. Эта структура должна быть заполнена, 
				  если возвращается DISP_E_EXCEPTION. Может быть NULL.
	puArgErr    - Индекс внутри rgvarg первого аргумента, который имеет ошибку. Аргументы хранятся в pDispParams -> rgvarg 
			      в обратном порядке, поэтому первым аргументом является тот, у которого самый высокий индекс в массиве. 
				  Этот параметр возвращается только тогда, когда результирующим возвращаемым значением является DISP_E_TYPEMISMATCH 
				  или DISP_E_PARAMNOTFOUND. Этот аргумент может быть установлен в null. Подробнее см. «Возврат ошибок».
*/

STDMETHODIMP CoPrinter::Invoke(DISPID dispIdMember, REFIID riid, LCID lcid, WORD wFlags, 
			 DISPPARAMS *pDispParams, VARIANT *pVarResult, EXCEPINFO *pExcepInfo, UINT *puArgErr)
{
	HRESULT hr = S_OK;

	VARIANTARG arg;

	// Иничиализирует вариант
	VariantInit(&arg);

	BSTR* name = new BSTR;    // Переменная для метода GetPetName
	int speed, quality;		  // Переменные для методов Get... 

	VariantInit(pVarResult);

	// Смотрим какой метод был вызван.
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
			 Считывает параметр из структуры DISPPARAMS, проверяя как позиционные, так и именованные параметры, и приводит параметр к заданному типу.
			 
			 //Параметры
			 pdispparams - Указатель на параметры, переданные IDispatch::Invoke.
			 position    - Позиция параметра в списке аргументов. DispGetParam начинает с конца массива, так что если position равен 0, 
						   то возвращается последний параметр массива.
			 vtTarg      - Тип, к которому следует привести значение параметра.
			 pvarResult  - Указатель на вариант, в который следует поместить параметр.
			 puArgErr    - После возврата указывает на индекс аргумента, вызвавшего ошибку DISP_E_TYPEMISMATCH. 
			               Этот указатель возвращается Invoke, чтобы указать позицию вызвавшего ошибку аргумента в DISPPARAMS.
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
	Извлекает информацию о типе для объекта, который затем может использоваться для получения информации о типе для интерфейса. 

	//Параметры
	iTInfo  - Возвращаемая информация о типе. Передайте 0 для получения информации о типе для реализации IDispatch.
	lcid    - Идентификатор локали для информации о типе. Объект может возвращать информацию различного типа для разных языков. 
			  Это важно для классов, которые поддерживают локализованные имена участников. Для классов, которые не поддерживают 
			  локализованные имена элементов, этот параметр можно игнорировать.
    ppTInfo - Запрошенный тип информационного объекта
		// Возможные значения
		S_OK				- Все четко!
		DISP_E_BADINDEX     - Параметр iTInfo не был 0.	
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
	Получает количество интерфейсов информации типа, которые предоставляет объект (0 или 1).

	// Параметры
	pctinfo - Количество интерфейсов информации типа, предоставляемых объектом.
			  Если объект предоставляет информацию о типе, это число равно 1; в противном случае число равно 0
		// Возможные значения
		S_OK		- Удача!
		E_NOTIMPL   - Неудача :(
*/

STDMETHODIMP CoPrinter::GetTypeInfoCount(UINT * pctinfo)
{
	if (pctinfo == NULL) 
		return E_INVALIDARG;
	
	*pctinfo = 1;
	return S_OK;
}

#pragma endregion

#pragma region Реализация IEngine

// Увеличение скорочти печати на 1 лист в минуту
STDMETHODIMP CoPrinter::SpeedUp()
{
	m_currSpeed += 1;

	// Увеличили скорость на 1, качество уменьшается на 5%
	m_currQuality -= 5;

	return S_OK;
}

// Повышение качества печати печати на 5%
STDMETHODIMP CoPrinter::QualityUp()
{
	m_currQuality += 5;

	// Повысили качество на 5%, уменьшаем скорость на 1
	m_currSpeed -= 1;

	return S_OK;
}

// Получение максимальной скорости печати 
STDMETHODIMP CoPrinter::GetMaxSpeed(int* maxSpeed)
{
	*maxSpeed = m_maxSpeed;
	return S_OK;
}

// Получение текущей скорости печати
STDMETHODIMP CoPrinter::GetCurSpeed(int* curSpeed)
{
	*curSpeed = m_currSpeed;
	return S_OK;
}

// Получение текущего качества
STDMETHODIMP CoPrinter::GetCurQuality(int* curQuality)
{
	*curQuality = m_currQuality;
	return S_OK;
}

#pragma endregion

#pragma region Реализация ICreatePrinter  

// Присвоение имени автомобилю
STDMETHODIMP CoPrinter::SetPetName(BSTR petName)
{
	SysReAllocString(&m_petName, petName);
	return S_OK;
}

// Задание максимальной скорости автомобиля
STDMETHODIMP CoPrinter::SetMaxSpeed(int maxSp)
{
	if (maxSp < MAX_SPEED && maxSp > MIN_SPEED)
		m_maxSpeed = maxSp;
	return S_OK;
}

#pragma endregion

#pragma region Реализация IStats

// Получение имени автомобиля
// Возвращает клиенту копию внутреннего буфера BSTR 
STDMETHODIMP CoPrinter::GetPetName(BSTR* petName)
{
	*petName = SysAllocString(m_petName);
	return S_OK;
}

// Отображение параметров состояния реализуемого объекта
STDMETHODIMP CoPrinter::DisplayStats()
{
	MessageBox(NULL, m_petName, L"Pet Name", MB_OK | MB_SETFOREGROUND);
	WCHAR buff[10];
	_itow(m_maxSpeed, buff, 10);
	MessageBox(NULL, buff, L"Max Speed", MB_OK | MB_SETFOREGROUND);
	return S_OK;
}

#pragma endregion