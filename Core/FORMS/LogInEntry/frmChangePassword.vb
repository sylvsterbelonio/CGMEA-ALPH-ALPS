Imports System.Windows.Forms.Cursors

Public Class frmChangePassword
    Inherits System.Windows.Forms.Form

    Private Const MSGBOX_BLANK_PASSWORD_VALIDATION As String = "Please provide a new password for the given user name."
    Private Const MSGBOX_SAME_NEW_PASSWORD_VALIDATION As String = "New password must not be the same as the old password."
    Private Const MSGBOX_CHANGE_PASSWORD_VALIDATION As String = "The password you typed do not match. Type the new password in both text boxes."

    Private UserID As Integer
    Private WithEvents clsChangePassword As New ChangePassword.ChangePassword
    Private clsCommon As New Common.Common

    Private Sub frmChangePassword_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetTextBoxLength()
        With clsChangePassword
            .user_ID = UserID
            If .Selected_Record Then
                txtUserName.Text = .user_Name
            End If
        End With
    End Sub

    Private Sub SetTextBoxLength()
        Me.txtOldPassword.MaxLength = 20
        Me.txtNewPassword.MaxLength = 45
        Me.txtConfirmPassword.MaxLength = 45
    End Sub

    Public Function User_Validation() As Boolean
        User_Validation = True
        If Len(txtNewPassword.Text) = 0 Then
            clsCommon.Prompt_User("error", MSGBOX_BLANK_PASSWORD_VALIDATION)
            txtNewPassword.Focus()
            User_Validation = False
        ElseIf Len(txtOldPassword.Text) > 0 And (txtOldPassword.Text = txtNewPassword.Text) Then
            clsCommon.Prompt_User("error", MSGBOX_SAME_NEW_PASSWORD_VALIDATION)
            txtNewPassword.Text = ""
            txtConfirmPassword.Text = ""
            txtNewPassword.Focus()
            User_Validation = False
        ElseIf Len(txtOldPassword.Text) > 0 And Len(txtNewPassword.Text) > 0 And txtNewPassword.Text <> txtConfirmPassword.Text Then
            clsCommon.Prompt_User("error", MSGBOX_CHANGE_PASSWORD_VALIDATION)
            txtNewPassword.Text = ""
            txtConfirmPassword.Text = ""
            txtNewPassword.Focus()
            User_Validation = False
        End If
    End Function

    Private Sub EventHandler(ByVal strMessage As String, ByVal Successfl As Boolean) Handles clsChangePassword.MsgArrival
        If Successfl Then
            clsCommon.Prompt_User("Information", strMessage)
        Else
            clsCommon.Prompt_User("Error", strMessage)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Cursor = WaitCursor

        If User_Validation() Then
            With clsChangePassword
                .user_ID = UserID
                .user_Name = txtUserName.Text
                .oldPasswrd = txtOldPassword.Text
                .newPasswrd = txtNewPassword.Text
                .updated_By = UserID
                If .Save_Record() Then
                    Me.Close()
                End If
            End With
        End If

        Me.Cursor = Arrow
    End Sub


End Class