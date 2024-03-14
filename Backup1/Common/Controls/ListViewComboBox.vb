Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Windows.Forms

Public Class ListViewComboBox
    Inherits System.Windows.Forms.ListView

    Private Const WM_HSCROLL As Integer = &H114
    Private Const WM_VSCROLL As Integer = &H115

    Protected Overrides Sub WndProc(ByRef msg As Message)
        ' Look for the WM_VSCROLL or the WM_HSCROLL messages.
        If ((msg.Msg = WM_VSCROLL) Or (msg.Msg = WM_HSCROLL)) Then
            ' Move focus to the ListView to cause ComboBox to lose focus.
            Me.Focus()
        End If

        ' Pass message to default handler.
        MyBase.WndProc(msg)
    End Sub

End Class
