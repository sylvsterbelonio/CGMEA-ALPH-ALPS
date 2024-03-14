Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmLoginOverride
    Inherits System.Windows.Forms.Form

    Private UserAuthenticated As Boolean

    Public UserName As String
    Public LogIn_Success As Boolean = True

    Private WithEvents clsLoginOverride As New LoginOverride.LoginOverride
    Private clsCommon As New Common.Common
    Private clsDataAccess As New DataAccess(gConnStringFileName)


    Private Const MSG_INVALID_PASSWORD = "Please enter a valid administrator user name and password."
    Private Const MAX_LOGIN_FAILURE = 3
    Private Const MSG_MAX_LOGIN_FAILURE = "You have reached the maximum login attempts. System override will now be cancelled."

    Public Event LoginSuccess()

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler txtUserName.KeyPress, AddressOf KeyPressed
        AddHandler txtPassword.KeyPress, AddressOf KeyPressed

        Me.Text = "System Log-in Override"
    End Sub

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.txtUserName.Focus()
    End Sub

    Sub KeyPressed(ByVal o As [Object], ByVal e As Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            btnLogin.PerformClick()
        End If
        If e.KeyChar = Microsoft.VisualBasic.ChrW(27) Then
            btnCancel.PerformClick()
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim blnExist As Boolean
        UserName = txtUserName.Text
        If txtUserName.Text = "" Then
            clsCommon.Prompt_User("error", MSG_INVALID_PASSWORD)
        Else
            Me.Cursor = WaitCursor

            'Call clsLoginOverride class for Validation
            blnExist = clsLoginOverride.ValidateLogin(txtUserName.Text, txtPassword.Text)

            Me.Cursor = Arrow

            If blnExist Then
                UserAuthenticated = True

                RaiseEvent LoginSuccess()

                LogIn_Success = True
                Me.Hide()

                DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                clsCommon.Prompt_User("error", MSG_INVALID_PASSWORD)
                DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtPassword_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPassword.MouseDown
        clsCommon.Disable_Field_Context_Menu(e, txtPassword)
    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        clsCommon.Key_Down(e)
    End Sub

    Private Sub frmLogin_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If Not UserAuthenticated Then
            LogIn_Success = False
        End If
    End Sub

    Private Sub lblHidden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblHidden.Click
        Try
            clsCommon.Prompt_User("information", clsCommon.Crypt(txtPassword.Text))
        Catch ex As Exception

        End Try
    End Sub

End Class