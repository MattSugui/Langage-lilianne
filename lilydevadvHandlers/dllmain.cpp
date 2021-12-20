// dllmain.cpp : Implementation of DllMain.

#include "pch.h"
#include "framework.h"
#include "resource.h"
#include "lilydevadvHandlers_i.h"
#include "dllmain.h"
#include "xdlldata.h"

ClilydevadvHandlersModule _AtlModule;

class ClilydevadvHandlersApp : public CWinApp
{
public:

// Overrides
	virtual BOOL InitInstance();
	virtual int ExitInstance();

	DECLARE_MESSAGE_MAP()
};

BEGIN_MESSAGE_MAP(ClilydevadvHandlersApp, CWinApp)
END_MESSAGE_MAP()

ClilydevadvHandlersApp theApp;

BOOL ClilydevadvHandlersApp::InitInstance()
{
	if (!PrxDllMain(m_hInstance, DLL_PROCESS_ATTACH, nullptr))
		return FALSE;
	return CWinApp::InitInstance();
}

int ClilydevadvHandlersApp::ExitInstance()
{
	return CWinApp::ExitInstance();
}
