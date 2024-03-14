<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSplashScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'frmSplashScreen
        '
        Me.ClientSize = New System.Drawing.Size(294, 269)
        Me.Name = "frmSplashScreen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents pbProgressRoller As System.Windows.Forms.PictureBox
    Friend WithEvents tmrSplash As System.Windows.Forms.Timer
    Friend WithEvents pSplash As System.Windows.Forms.PictureBox
    Friend WithEvents lblSplashScreen As System.Windows.Forms.Label
    Friend WithEvents pbLoading As System.Windows.Forms.PictureBox
End Class
