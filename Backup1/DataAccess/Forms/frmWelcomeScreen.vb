Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmWelcomeScreen
    Inherits System.Windows.Forms.Form

    Private clsCommon As New Common.Common

    Private Const REGISTRY_SECTION_WELCOME_SCREEN = "Welcome"
    Private Const REGISTRY_KEY_WELCOME_SCREEN = "ShowScreen"

    Private Sub frmWelcomeScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim hMenu As IntPtr
        Dim menuItemCount As Integer
        hMenu = Common.Common.GetSystemMenu(Me.Handle, False)
        menuItemCount = Common.Common.GetMenuItemCount(hMenu)
        Call Common.Common.RemoveMenu(hMenu, menuItemCount - 1, MF_DISABLED Or MF_BYPOSITION)
        Call Common.Common.RemoveMenu(hMenu, menuItemCount - 2, MF_DISABLED Or MF_BYPOSITION)
        Call Common.Common.DrawMenuBar(Me.Handle)

        chkDisplay.CheckState = IIf((Len(clsCommon.GetRegistrySetting(REGISTRY_SECTION_WELCOME_SCREEN, REGISTRY_KEY_WELCOME_SCREEN)) = 0), 0, CInt(clsCommon.GetRegistrySetting(REGISTRY_SECTION_WELCOME_SCREEN, REGISTRY_KEY_WELCOME_SCREEN)))
    End Sub

    Private Sub btnIntroduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntroduction.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Me.Close()
    End Sub

    Private Sub frmWelcomeScreen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        clsCommon.SaveRegistrySetting(REGISTRY_SECTION_WELCOME_SCREEN, REGISTRY_KEY_WELCOME_SCREEN, chkDisplay.CheckState)
    End Sub

    Private Sub rtbInfo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtbInfo.GotFocus, rtbInfo.DoubleClick, rtbInfo.SelectionChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.RichTextBox_No_Selection(sender, pnlBorder)
    End Sub
End Class