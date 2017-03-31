// CLRInputMethodMgr.h

#pragma once
#include "InputMethodInterceptor.h"
using namespace System;

namespace CLRInputMethodMgr {

	public ref class CLRInputMethodInterceptor
	{
	public:

		static void Enable()
		{
			if(m_pInterceptor==0){
				m_pInterceptor = new InputMethodInterceptor();
				m_pInterceptor->Initialize();
			}
			m_pInterceptor->Enable();
		}

		static void Disable()
		{
			m_pInterceptor->Disable();
		}

	private:
		CLRInputMethodInterceptor(){}
		static InputMethodInterceptor *m_pInterceptor = 0;
	};
}
