// This MFC Samples source code demonstrates using MFC Microsoft Office Fluent User Interface 
// (the "Fluent UI") and is provided only as referential material to supplement the 
// Microsoft Foundation Classes Reference and related electronic documentation 
// included with the MFC C++ library software.  
// License terms to copy, use or distribute the Fluent UI are available separately.  
// To learn more about our Fluent UI licensing program, please visit 
// https://go.microsoft.com/fwlink/?LinkId=238214.
//
// Copyright (C) Microsoft Corporation
// All rights reserved.

// ChildWindow.cpp : implementation of the CChildWindow class
//

#include "pch.h"
#include "framework.h"
#include "lilydevadv.h"

#include "ChildWindow.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CChildWindow

IMPLEMENT_DYNCREATE(CChildWindow, CMDIChildWndEx)

BEGIN_MESSAGE_MAP(CChildWindow, CMDIChildWndEx)
	ON_COMMAND(ID_FILE_PRINT, &CChildWindow::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CChildWindow::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CChildWindow::OnFilePrintPreview)
	ON_UPDATE_COMMAND_UI(ID_FILE_PRINT_PREVIEW, &CChildWindow::OnUpdateFilePrintPreview)
END_MESSAGE_MAP()

// CChildWindow construction/destruction

CChildWindow::CChildWindow() noexcept
{
	// TODO: add member initialization code here
}

CChildWindow::~CChildWindow()
{
}


BOOL CChildWindow::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: Modify the Window class or styles here by modifying the CREATESTRUCT cs
	if( !CMDIChildWndEx::PreCreateWindow(cs) )
		return FALSE;

	cs.style = WS_CHILD | WS_VISIBLE | WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU
		| FWS_ADDTOTITLE | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_MAXIMIZE;

	return TRUE;
}

// CChildWindow diagnostics

#ifdef _DEBUG
void CChildWindow::AssertValid() const
{
	CMDIChildWndEx::AssertValid();
}

void CChildWindow::Dump(CDumpContext& dc) const
{
	CMDIChildWndEx::Dump(dc);
}
#endif //_DEBUG

// CChildWindow message handlers

void CChildWindow::OnFilePrint()
{
	if (m_dockManager.IsPrintPreviewValid())
	{
		PostMessage(WM_COMMAND, AFX_ID_PREVIEW_PRINT);
	}
}

void CChildWindow::OnFilePrintPreview()
{
	if (m_dockManager.IsPrintPreviewValid())
	{
		PostMessage(WM_COMMAND, AFX_ID_PREVIEW_CLOSE);  // force Print Preview mode closed
	}
}

void CChildWindow::OnUpdateFilePrintPreview(CCmdUI* pCmdUI)
{
	pCmdUI->SetCheck(m_dockManager.IsPrintPreviewValid());
}
