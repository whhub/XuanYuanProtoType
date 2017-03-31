#pragma once
#include "msctf.h"
#include <vector>
#include <string>
class InputMethodContext;

class InputMethodInterceptor 
	: public ITfUIElementSink
{
public:

	InputMethodInterceptor(void);

	~InputMethodInterceptor(void);

	HRESULT Initialize();

	HRESULT STDMETHODCALLTYPE BeginUIElement(
		DWORD dwUIElementId, BOOL *pbShow);

	HRESULT STDMETHODCALLTYPE UpdateUIElement( 
		DWORD dwUIElementId);

	HRESULT STDMETHODCALLTYPE EndUIElement( 
		DWORD dwUIElementId);

	HRESULT STDMETHODCALLTYPE QueryInterface( 
		REFIID riid,
		__RPC__deref_out void __RPC_FAR *__RPC_FAR *ppvObject)
	{
			if (riid == __uuidof(ITfUIElementSink))
			{
				*ppvObject = this;
				AddRef();
				return S_OK;
			}
			return S_FALSE;
	}

	ULONG STDMETHODCALLTYPE AddRef(void)
	{
		m_iRefCount++;
		return m_iRefCount;
	}

	ULONG STDMETHODCALLTYPE Release(void);

	void Disable()
	{
		m_bEnabled = false;
	}

	void Enable()
	{
		m_bEnabled = true;
	}

private:
	volatile bool m_bEnabled;

	int m_iRefCount;

	DWORD m_dwSinkCookie;

	ITfThreadMgrEx *m_pThreadMgrEx;

	HANDLE m_hPipe;

	void ListenAndSubmitInputMethodContext(DWORD dwUIElementId);

	int MakeCandidateList(ITfCandidateListUIElement *pCandidateListUIElement);

	int GetInputMethodContext(InputMethodContext &objContext, DWORD dwUIElementId);

	HRESULT ConnectToInputMethodDaemon();

	HRESULT DisconnectFromInputMethodDaemon();

	std::string ToUTF8(const BSTR str);
};

