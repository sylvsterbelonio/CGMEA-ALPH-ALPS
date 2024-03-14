Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmSystemLock
    Inherits System.Windows.Forms.Form

    Private WithEvents clsLogin As New Login.Login
    Private clsCommon As New Common.Common
    Private clsDataAccess As New DataAccess(gConnStringFileName)

    Public gifLogo As Drawing.Bitmap = New System.Drawing.Bitmap(Me.GetType, "seal.png")
    Private intTick As Integer
    Private KeyPressChar As Long

    Private Sub frmSystemLock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With pbLogoMain
            .BackgroundImage = gifLogo
            .BackgroundImageLayout = ImageLayout.Zoom
        End With

        btnUnlock.Enabled = False
        lblSystemLock.Text = "This system has been locked by [" & Trim(txtUserName.Text) & "]. Only the same user can lift this system lock." & vbCr & vbCr & "Caution : If you lose or forget the password, it can not be recovered. (Remember that passwords are case sensitive.)" & vbCr & vbCr & "If you have the correct account, press [ESC] key to enter password and unlock the system."
        lblWarning.Text = "Warning : This software is protected by copyright laws and international treaties. Unauthorized reproduction or distribution of this software, or any portion of it, may result in severe civil and criminal penalties, and the offender will be prosecuted to the maximum extent possible under the law."
        pnlSystemLock.Visible = True
        Me.Text = modApp.AssemblyProduct & " [System Lock]"
    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        Dim blnExist As Boolean

        Me.Cursor = WaitCursor

        blnExist = clsLogin.ValidateLogin(txtUserName.Text, txtPassword.Text, 0)

        Me.Cursor = Arrow

        If blnExist Then
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            clsCommon.Prompt_User("error", "Please enter correct password for user '" & Trim(txtUserName.Text) & "' to unlock system.")
            If txtPassword.Text.Length > 0 Then
                txtPassword.SelectAll()
            End If
            txtPassword.Focus()
            DialogResult = Windows.Forms.DialogResult.None
        End If
    End Sub

    Private Sub frmSystemLock_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress, btnUnlock.KeyPress, txtPassword.KeyPress, txtUserName.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        KeyPressChar = e.KeyChar.GetHashCode

        Select Case KeyPressChar
            Case 851981 ' enter
                btnUnlock.PerformClick()
            Case 1769499 ' esc
                If pnlSystemLock.Visible Then
                    lblSystemLock.Text = "This system has been locked by [" & Trim(txtUserName.Text) & "]. Only the same user can lift this system lock." & vbCr & vbCr & "Caution : If you lose or forget the password, it can not be recovered. (Remember that passwords are case sensitive.)" & vbCr & vbCr & "If you have the correct account specified below, enter your password to unlock the system."
                    pnlSystemLock.Visible = False
                    btnUnlock.Enabled = True
                    If txtPassword.Text.Length > 0 Then
                        txtPassword.SelectAll()
                    End If
                    txtPassword.Focus()
                Else
                    lblSystemLock.Text = "This system has been locked by [" & Trim(txtUserName.Text) & "]. Only the same user can lift this system lock." & vbCr & vbCr & "Caution : If you lose or forget the password, it can not be recovered. (Remember that passwords are case sensitive.)" & vbCr & vbCr & "If you have the correct account, press [ESC] key to enter password and unlock the system."
                    pnlSystemLock.Visible = True
                    btnUnlock.Enabled = False
                    txtPassword.Text = ""
                End If
        End Select
    End Sub

    Private Sub txtPassword_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPassword.MouseDown
        clsCommon.Disable_Field_Context_Menu(e, txtPassword)
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        clsCommon.Key_Down(e)
    End Sub

    Private Sub lblSystemLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSystemLock.Click

    End Sub
End Class