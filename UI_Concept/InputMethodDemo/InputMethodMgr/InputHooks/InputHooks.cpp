// InputHooks.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "InputMethodInterceptor.h"

#pragma data_seg("shared")
HHOOK hHookOnWindowActive;
HHOOK hHookOnMsg;
#pragma data_seg()

static InputMethodInterceptor *_pInputMethodInterceptor;

LRESULT CALLBACK HookProcOnWindowActive(int nCode,WPARAM wParam,LPARAM lParam)
{
	if(nCode==HCBT_ACTIVATE)
	{
		_pInputMethodInterceptor = new InputMethodInterceptor();
		_pInputMethodInterceptor->Initialize();
		_pInputMethodInterceptor->ConnectToInputMethodDaemon();
		return 0;
	}
	else if(nCode == HCBT_SETFOCUS)
	{

	}
	return CallNextHookEx(hHookOnWindowActive,nCode,wParam,lParam);
}

LRESULT CALLBACK HookProcOnMsg(int nCode, WPARAM wParam, LPARAM lParam)
{
	if(nCode==HC_ACTION)
	{
		return 0;
		MSG *pMsg = (MSG*)lParam;
	}
	return CallNextHookEx(hHookOnMsg,nCode,wParam,lParam);
}

HRESULT InstallHooks()
{
	hHookOnWindowActive = SetWindowsHookEx(WH_CBT, HookProcOnWindowActive, GetModuleHandle(L"InputHooks"), 0);
	hHookOnMsg = SetWindowsHookEx(WH_GETMESSAGE, HookProcOnMsg, GetModuleHandle(L"InputHooks"), 0);
	return S_OK;
}

HRESULT UninstallHooks()
{
	return S_OK;
}
