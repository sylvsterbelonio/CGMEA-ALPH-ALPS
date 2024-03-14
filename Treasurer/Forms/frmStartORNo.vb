Imports System.Windows.Forms.Cursors
Imports System.Windows.Forms

Public Class frmStartORNo
    Inherits System.Windows.Forms.Form

    Public _ORNoNumerical As Integer
    Public _ORNoAlpha As String
    Public _ORDate As Date
    Public isCancelled As Boolean = False

    Public frmMainUser As Form

    Private clsCommon As New Common.Common
    Private WithEvents clsPayment As New Payment.Payment

    Private Sub frmStartORNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Escape Then
            isCancelled = True
            Me.Close()
        End If
    End Sub

    Private Sub frmStartORNo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim hMenu As IntPtr
        Dim menuItemCount As Integer
        hMenu = Common.Common.GetSystemMenu(Me.Handle, False)
        menuItemCount = Common.Common.GetMenuItemCount(hMenu)
        Call Common.Common.RemoveMenu(hMenu, menuItemCount - 1, MF_DISABLED Or MF_BYPOSITION)
        Call Common.Common.RemoveMenu(hMenu, menuItemCount - 2, MF_DISABLED Or MF_BYPOSITION)
        Call Common.Common.DrawMenuBar(Me.Handle)
        isCancelled = False
        txtORNoNumerical.Text = Now.Year
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If IsNumeric(txtORNoNumerical.Text) = False Or Trim(txtORNoNumerical.Text) = "" Then
            MsgBox("Please check OR No. [Input numbers only]", MsgBoxStyle.Exclamation)
            txtORNoNumerical.SelectAll()
            txtORNoNumerical.Focus()
            Exit Sub
        ElseIf IsNumeric(txtORNoAlpha.Text) = True Or Trim(txtORNoAlpha.Text) = "" Then
            MsgBox("Please check OR Alpha. [Input letter only]", MsgBoxStyle.Exclamation)
            txtORNoAlpha.SelectAll()
            txtORNoAlpha.Focus()
            Exit Sub
        End If
        _ORNoNumerical = Me.txtORNoNumerical.Text
        _ORNoAlpha = Me.txtORNoAlpha.Text
        _ORDate = Me.dtpORDt.Text
        Me.Close()
    End Sub
End Class