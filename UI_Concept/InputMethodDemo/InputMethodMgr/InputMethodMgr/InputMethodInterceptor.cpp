#include "StdAfx.h"
#include "InputMethodInterceptor.h"
#include "InputMethodContext.pb.h"
using namespace std;

const wchar_t * const PIPENAME = L"\\\\.\\pipe\\InputMethodPipe";

const DWORD PIPE_TIMEOUT = 2000;

const int MAX_PAGE_SIZE = 1024;

InputMethodInterceptor::InputMethodInterceptor(void)
{
	m_hPipe = 0;
	m_iRefCount = 0;
	m_dwSinkCookie = 0;
	m_pThreadMgrEx = 0;
}

InputMethodInterceptor::~InputMethodInterceptor(void)
{
}

HRESULT InputMethodInterceptor::Initialize()
{
	HRESULT hr;
	TfClientId clientId;
	ITfSource *pSource;
	hr = CoCreateInstance(CLSID_TF_ThreadMgr, NULL, CLSCTX_INPROC_SERVER, IID_ITfThreadMgrEx, (void**)&m_pThreadMgrEx);
	hr = m_pThreadMgrEx->ActivateEx( &clientId, TF_TMAE_UIELEMENTENABLEDONLY);
	hr = m_pThreadMgrEx->QueryInterface(IID_ITfSource, (LPVOID*)&pSource);
	hr = pSource->AdviseSink(IID_ITfUIElementSink, this, &m_dwSinkCookie);
	pSource->Release();
	return hr;
}

HRESULT InputMethodInterceptor::BeginUIElement(DWORD dwUIElementId, BOOL *pbShow)
{
	*pbShow = !m_bEnabled;
	return S_OK;
}

HRESULT InputMethodInterceptor::UpdateUIElement(DWORD dwUIElementId)
{
	if(m_hPipe==NULL)
	{
		ConnectToInputMethodDaemon();
	}
	ListenAndSubmitInputMethodContext(dwUIElementId);
	return S_OK;
}

HRESULT InputMethodInterceptor::EndUIElement(DWORD dwUIElementId)
{
	HANDLE hPipe = m_hPipe;
	if(hPipe==INVALID_HANDLE_VALUE)
	{
		return S_OK;
	}
	DWORD dwNumberOfBytesWritten;
	int iContextSize = 0;
	try
	{
		WriteFile(hPipe, &iContextSize, sizeof(int), &dwNumberOfBytesWritten, 0);
	}catch(...)
	{
	}
	DisconnectFromInputMethodDaemon();
	return S_OK;
}

int InputMethodInterceptor::GetInputMethodContext(InputMethodContext &objContext, DWORD dwUIElementId)
{
	HRESULT hr;
	ITfUIElementMgr* pUIElementMgr = NULL;
	ITfUIElement *pUIElement = NULL;
	ITfCandidateListUIElement *pCandidateListUIElement = NULL;
	hr = m_pThreadMgrEx->QueryInterface(IID_ITfUIElementMgr, (void**)&pUIElementMgr);
	if(hr!=S_OK) return hr;
	hr = pUIElementMgr->GetUIElement(dwUIElementId, &pUIElement);
	if(hr!=S_OK) 
	{
		pUIElementMgr->Release();
		return hr;
	}
	hr = pUIElement->QueryInterface(__uuidof(ITfCandidateListUIElement), (void**)&pCandidateListUIElement);
	if(hr!=S_OK)
	{
		pUIElementMgr->Release();
		pUIElement->Release();
		return hr;
	}
	BSTR str;
	UINT iCount = 0;
	UINT iCurrentPageIdx = 0;
	UINT aPageOffsets[MAX_PAGE_SIZE];
	UINT iPageCount;
	UINT iSelection = 0;
	pCandidateListUIElement->GetPageIndex(aPageOffsets, MAX_PAGE_SIZE, &iPageCount);
	pCandidateListUIElement->GetCurrentPage(&iCurrentPageIdx);
	pCandidateListUIElement->GetSelection(&iSelection);
	int iBegin = aPageOffsets[iCurrentPageIdx];
	UINT iEnd = 0;
	if(iCurrentPageIdx==iPageCount-1)
	{
		pCandidateListUIElement->GetCount(&iEnd);
	}
	else
	{
		iEnd = aPageOffsets[iCurrentPageIdx+1];
	}
	for(int i=iBegin; i<iEnd; i++) {
		pCandidateListUIElement->GetString(i, &str);
		string *pItem = objContext.add_candidates();
		(*pItem) = ToUTF8(str);
		SysFreeString(str);
	}
	objContext.set_pageindex(iCurrentPageIdx);
	objContext.set_selectionindex(iSelection - iBegin);
	pCandidateListUIElement->Release();
	pUIElement->Release();
	pUIElementMgr->Release();
	return hr;
}

void InputMethodInterceptor::ListenAndSubmitInputMethodContext(DWORD dwUIElementId)
{
	InputMethodContext objContext;
	int iErr = GetInputMethodContext(objContext, dwUIElementId);
	if(iErr!=0)
	{
		return;
	}
	string szContext;
	BOOL bSerializeState = objContext.SerializeToString(&szContext);
	if(bSerializeState!=TRUE)
	{
		return;
	}
	int iContextSize = szContext.size();
	HANDLE hPipe = m_hPipe;
	if(hPipe==INVALID_HANDLE_VALUE)
	{
		return;
	}
	DWORD dwNumberOfBytesWritten;
	WriteFile(hPipe, &iContextSize, sizeof(int), &dwNumberOfBytesWritten, 0);
	WriteFile(hPipe, szContext.c_str(), (DWORD)szContext.size(), &dwNumberOfBytesWritten, 0);
}

ULONG InputMethodInterceptor::Release(void)
{
	m_iRefCount--;
	if(m_iRefCount == 0)
	{
		delete this;
		m_pThreadMgrEx->Release();
	}
	return m_iRefCount;
}

string InputMethodInterceptor::ToUTF8(const BSTR str)
{
	const int BUF_SIZE = 1024;
	char szBuf[BUF_SIZE];
	memset(szBuf, 0, BUF_SIZE);
	WideCharToMultiByte(CP_UTF8,0,str,-1,szBuf,BUF_SIZE,NULL,0);
	return string(szBuf);
}

HRESULT InputMethodInterceptor::ConnectToInputMethodDaemon()
{
	BOOL bPipeOK = WaitNamedPipe(PIPENAME,PIPE_TIMEOUT);
	if(bPipeOK)
	{
		m_hPipe = CreateFile(PIPENAME,GENERIC_WRITE,0,NULL,OPEN_EXISTING,0,NULL);
		return S_OK;
	}
	return S_FALSE;
}

HRESULT InputMethodInterceptor::DisconnectFromInputMethodDaemon()
{
	if(m_hPipe==NULL) return S_OK;
	if(m_hPipe!=INVALID_HANDLE_VALUE)
	{
		CloseHandle(m_hPipe);
		m_hPipe = NULL;
		return S_OK;
	}
	return S_FALSE;
}