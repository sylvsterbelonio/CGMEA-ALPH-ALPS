Imports System
'Imports System.Web
Imports System.Drawing
Imports System.Windows.Forms.Cursors
Imports Microsoft.VisualBasic

Public Class frmErrorDialog
    Inherits System.Windows.Forms.Form

    Private Shared resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmErrorDialog))

    Private gException As Exception
    Private clsCommon As New Common

    Private Const REGISTRY_SECTION_ERRORS = "Reports"
    Private Const REGISTRY_KEY_REPORT_BUGS = "DontReportBugs"

    Private Sub frmErrorDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblErr01.Text = "An error has occurred in " & modApp.AssemblyTitle & " or in one of its assemblies."
        lblErr02.Text = "If you would like to send the error details to " & modApp.AssemblyCompany & " CPG automatically, please press Send Data below."
        lblAltLink.Text = "Problems can also be reported to " & modApp.AssemblyDefaultAlias & " as well."
        chkNoReport.CheckState = IIf((Len(clsCommon.GetRegistrySetting(REGISTRY_SECTION_ERRORS, REGISTRY_KEY_REPORT_BUGS)) = 0), 0, CInt(clsCommon.GetRegistrySetting(REGISTRY_SECTION_ERRORS, REGISTRY_KEY_REPORT_BUGS)))
    End Sub

    Private Sub lblWhatReport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblWhatReport.LinkClicked
        Dim moreInfo As New frmErrorDialogMoreInfo()

        moreInfo.txtFullText.Text = modApp.AssemblyTitle + " (" + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString() + ")" + vbCrLf + vbCrLf + gException.ToString() + vbCrLf + vbCrLf + clsCommon.GetDebugInfo()
        moreInfo.Owner = Me
        moreInfo.Show()
        moreInfo.BringToFront()
    End Sub

    Private Sub lblAltLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAltLink.LinkClicked
        Try
            System.Diagnostics.Process.Start("mailto:" & modApp.AssemblyDefaultAlias)
        Catch
        End Try
    End Sub

    Private Sub btnDontSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDontSend.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Cursor = WaitCursor
        If Not clsCommon.IsConnectionAvailable Then
            Cursor = Arrow
            clsCommon.Prompt_User("error", "There is an error connecting to the internet." & vbCr & "The application detected that you are currently not connected to the internet." & vbCr & "Please make sure that you are connected to the internet before trying to resend this error report. If this problem persists, please notify the system administrator immediately.")
            Exit Sub
        End If

        Dim Expression As New System.Text.RegularExpressions.Regex("\S+@\S+\.\S+")
        If Not Expression.IsMatch(txtEMail.Text) Then
            clsCommon.Prompt_User("error", "Please provide a valid email address.")
            Exit Sub
        End If

        Try
            If Not gException Is Nothing Then
                Dim post As String = "prog=" + System.Web.HttpUtility.UrlEncode(modApp.AssemblyProduct + " (" + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly().Location).ToShortDateString() + ")") + "&ex=" + System.Web.HttpUtility.UrlEncode(gException.ToString()) + "&fromemail=" + System.Web.HttpUtility.UrlEncode(txtEMail.Text) + "&adtnl=" + System.Web.HttpUtility.UrlEncode(clsCommon.GetDebugInfo()) + "&comments=" + System.Web.HttpUtility.UrlEncode(txtComments.Text)

                Try
                    Common.ExecuteUrl("http://www.jamediasolutions.com/automailer.php", post)
                Catch ex As Exception
                    System.Diagnostics.Debug.WriteLine(ex.ToString())
                End Try
            End If
        Catch

        Finally
            Cursor = Arrow
        End Try

        Try
            Dim msg As String = Resources.GetString("msgDataSubmitted.Text")
            If msg.Trim() = "" Then msg = "Thank you! The data has been submitted."
            clsCommon.Prompt_User("information", msg)
        Catch
            clsCommon.Prompt_User("information", "Thank you! The data has been submitted.")
        End Try
    End Sub

    Private Sub chkNoReport_CheckStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNoReport.CheckStateChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.SaveRegistrySetting(REGISTRY_SECTION_ERRORS, REGISTRY_KEY_REPORT_BUGS, chkNoReport.CheckState)
    End Sub

    Private Sub chkNoReport_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNoReport.CheckedChanged

    End Sub
End Class