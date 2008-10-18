/////////////////////////////////////////////////////////////////////////////
// Name:        DlgSaveLayout.cpp
// Purpose:     
// Author:      
// Modified by: 
// Created:     01/19/06 14:07:42
// RCS-ID:      
// Copyright:   
// Licence:     
/////////////////////////////////////////////////////////////////////////////

// Generated by DialogBlocks (unregistered), 01/19/06 14:07:42

#if defined(__GNUG__) && !defined(__APPLE__)
#pragma implementation "DlgSaveLayout.h"
#endif

// For compilers that support precompilation, includes "wx/wx.h".
#include "wx/wxprec.h"
#include "wx/ifm/ifm.h"
#include "wx/msgout.h"



#ifdef __BORLANDC__
#pragma hdrstop
#endif

#ifndef WX_PRECOMP
#include "wx/wx.h"
#endif

////@begin includes
////@end includes

#include "DlgSaveLayout.h"
#include "MainFrame.h"

////@begin XPM images
////@end XPM images

/*!
 * DlgSaveLayout type definition
 */

IMPLEMENT_DYNAMIC_CLASS( DlgSaveLayout, wxDialog )

/*!
 * DlgSaveLayout event table definition
 */

BEGIN_EVENT_TABLE( DlgSaveLayout, wxDialog )

////@begin DlgSaveLayout event table entries
    EVT_BUTTON( wxID_OK, DlgSaveLayout::OnOkClick )

////@end DlgSaveLayout event table entries

END_EVENT_TABLE()

/*!
 * DlgSaveLayout constructors
 */

DlgSaveLayout::DlgSaveLayout( )
{
}

DlgSaveLayout::DlgSaveLayout( bool _bSave )
{
	bSave = _bSave;
	wxString caption(bSave?SYMBOL_DLGSAVELAYOUT_TITLE:SYMBOL_DLGDELETELAYOUT_TITLE);


    Create(NULL, SYMBOL_DLGSAVELAYOUT_IDNAME, caption, SYMBOL_DLGSAVELAYOUT_POSITION, SYMBOL_DLGSAVELAYOUT_SIZE, SYMBOL_DLGSAVELAYOUT_STYLE);
}

/*!
 * DlgSaveLayout creator
 */

bool DlgSaveLayout::Create( wxWindow* parent, wxWindowID id, const wxString& caption, const wxPoint& pos, const wxSize& size, long style )
{
////@begin DlgSaveLayout member initialisation
    m_ComboLayout = NULL;
////@end DlgSaveLayout member initialisation

////@begin DlgSaveLayout creation
    SetExtraStyle(GetExtraStyle()|wxWS_EX_BLOCK_EVENTS);
    SetParent(parent);
    CreateControls();
    GetSizer()->Fit(this);
    GetSizer()->SetSizeHints(this);
    Centre();
////@end DlgSaveLayout creation

	SetTitle(caption);
    return true;
}

/*!
 * Control creation for DlgSaveLayout
 */

void DlgSaveLayout::CreateControls()
{    
////@begin DlgSaveLayout content construction
    // Generated by DialogBlocks, 01/19/06 21:43:54 (unregistered)

    wxXmlResource::Get()->LoadDialog(this, GetParent(), _T("ID_DIALOG_SAVE_LAYOUT"));
    m_ComboLayout = XRCCTRL(*this, "ID_COMBOBOX_LAYOUT", wxComboBox);
////@end DlgSaveLayout content construction

    // Create custom windows not generated automatically here.

////@begin DlgSaveLayout content initialisation

////@end DlgSaveLayout content initialisation

	wxStringList layoutList(wxMainFrame::Get()->GetLayoutControl()->GetLayoutList());

	for(int i = 0; i < layoutList.size(); i++)
	{
		wxString name(layoutList[i]);

		if(name != wxMainFrame::Get()->GetLayoutControl()->getDefaultString())
		{
			m_ComboLayout->Append(name);
		}
	}

	SetBackgroundColour(wxBackground_Pen);
	SetForegroundColour(colorCaptionText);

	m_ComboLayout->SetBackgroundColour(colorBgContent);

}

/*!
 * Should we show tooltips?
 */

bool DlgSaveLayout::ShowToolTips()
{
    return true;
}

/*!
 * Get bitmap resources
 */

wxBitmap DlgSaveLayout::GetBitmapResource( const wxString& name )
{
    // Bitmap retrieval
////@begin DlgSaveLayout bitmap retrieval
    wxUnusedVar(name);
    return wxNullBitmap;
////@end DlgSaveLayout bitmap retrieval
}

/*!
 * Get icon resources
 */

wxIcon DlgSaveLayout::GetIconResource( const wxString& name )
{
    // Icon retrieval
////@begin DlgSaveLayout icon retrieval
    wxUnusedVar(name);
    return wxNullIcon;
////@end DlgSaveLayout icon retrieval
}
/*!
 * wxEVT_COMMAND_BUTTON_CLICKED event handler for wxID_OK
 */

void DlgSaveLayout::OnOkClick( wxCommandEvent& event )
{
	if(!m_ComboLayout->GetValue().IsEmpty())
    {
		if(bSave)
		{
			wxMainFrame::Get()->AddLayout(m_ComboLayout->GetValue());
		}
		else
		{
			wxMainFrame::Get()->RemoveLayout(m_ComboLayout->GetValue());
		}

        if ( IsModal() )
            EndModal(wxID_OK); // If modal
        else
        {
            SetReturnCode(wxID_OK);
            this->Show(false); // If modeless
        }
    }	
	else
	{
		wxMessageBox(wxT("You must enter a layout name"), wxT("Error"));
	}
}


