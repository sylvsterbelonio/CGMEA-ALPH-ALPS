Public Class frmNotificationBoard

    Public allowTimer As Boolean
    Public NID As String
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Public Event CallBack(ByVal allowTimer As Boolean)

    Public Sub setAllowTime(ByRef time As Boolean)
        allowTimer = time
    End Sub

    Private Sub frmNotificationBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Connect(mysql)
        Dim Width As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim height As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Left = Width - Me.Width - 50
        Me.Top = height - Me.Height - 100
        Timer1.Start()

    End Sub

    Public opacitys As Decimal = 0.0
    Public opa2 As Decimal = 0.5

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If opacitys > 0.75 Then
            Me.Opacity = 0.75
        Else
            Me.Opacity = opacitys
        End If

        If opacitys <= 0.75 Then
            opacitys += 0.04
        ElseIf opacitys >= 1 Then
            Me.Opacity = opa2
            opa2 -= 0.04
            If opa2 < 0 Then
                Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_notification_user where NID=" + NID)
                If mydata.Rows.Count = 0 Then
                    With mysql
                        .setTable("tbl_notification_user")
                        .addValue(NID, "NID")
                        .addValue(App_UserID, "userId")
                        .addValue(0, "notifyMode")
                        .addValue(1, "viewMode")
                        .Insert()
                    End With
                End If
                RaiseEvent CallBack(True)
                Me.Hide()
            End If
        ElseIf opa2 < 0 Then
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_notification_user where NID=" + NID)
            If mydata.Rows.Count = 0 Then
                With mysql
                    .setTable("tbl_notification_user")
                    .addValue(NID, "NID")
                    .addValue(App_UserID, "userId")
                    .addValue(0, "notifyMode")
                    .addValue(1, "viewMode")
                    .Insert()
                End With
            End If
            RaiseEvent CallBack(True)
            Me.Hide()
        ElseIf opacitys >= 0.75 Then
            opacitys += 0.04
        End If
    End Sub

    Private Sub frmNotificationBoard_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, lblContent.MouseLeave, lblHead.MouseLeave
        Timer1.Start()
    End Sub

    Private Sub frmNotificationBoard_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove, lblContent.MouseMove, lblHead.MouseMove
        Timer1.Stop()
    End Sub

End Class