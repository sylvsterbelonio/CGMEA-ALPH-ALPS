Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmErrorDialogNoSend
    Inherits System.Windows.Forms.Form

    Private gException As Exception
    'Private jpgTechSupport As Bitmap = New System.Drawing.Bitmap(Me.GetType, "techsupport.jpg")
    Private clsCommon As New Common

    Private Sub frmErrorDialogNoSend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblErr01.Text = "An error has occurred in " & modApp.AssemblyTitle & " or in one of its assemblies."
        lblErr02.Text = "The full error text appears in the box below."
        lblAltLink.Text = "Problems may be reported at " & modApp.AssemblyDefaultAlias & " as well."
        'With pbTechSupport
        '    .BackgroundImage = jpgTechSupport
        '    .BackgroundImageLayout = Windows.Forms.ImageLayout.Stretch
        'End With
        txtComments.Text = modApp.AssemblyTitle + " (" + System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString() + ")" + vbCrLf + vbCrLf + gException.ToString() + vbCrLf + vbCrLf + clsCommon.GetDebugInfo()
    End Sub

    Private Sub txtComments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComments.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Clipboard.SetText(txtComments.Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lblAltLink_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblAltLink.LinkClicked
        Try
            System.Diagnostics.Process.Start("mailto:" & modApp.AssemblyDefaultAlias)
        Catch
        End Try
    End Sub

End Class