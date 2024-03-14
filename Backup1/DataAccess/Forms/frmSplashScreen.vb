Imports System.Io
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class frmSplashScreen

    Inherits System.Windows.Forms.Form
    Private pbSplash As New ProgressBar

    Public gifLoading As Bitmap = New System.Drawing.Bitmap(Me.GetType, "loading11.gif")
    Public jpgBackground As Bitmap = New System.Drawing.Bitmap(Me.GetType, "seal.png")

    Private intTick As Integer

    Private Sub frmSplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Text = modApp.AssemblyProduct
        lblProduct.Text = modApp.AssemblyProduct
        Me.lblCopyright.Text = modApp.AssemblyCopyright
        pbLoading.Image = gifLoading
        'pb()
        pSplash.BackgroundImage = jpgBackground
        pSplash.BackgroundImageLayout = ImageLayout.Zoom
        lblProduct.Parent = pSplash
        lblCopyright.Parent = pSplash
        lblSplashScreen.Parent = pSplash

        With pbSplash
            .Maximum = 500
        End With
    End Sub

    Private Sub Initialize_Timer()
        tmrSplash.Start()
        intTick = tmrSplash.Interval
    End Sub

    Private Sub tmrSplash_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrSplash.Tick
        intTick = intTick + 1

        If intTick = 100 Then
            tmrSplash.Dispose()
            Me.Close()
        End If
    End Sub


End Class