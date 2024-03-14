Imports PowerNET8.myString.Share
Public Class frmChangePassword

    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
    End Sub

    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
    End Sub
End Class