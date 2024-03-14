<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorDialogNoSend
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal ex As System.Exception)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        gException = ex

        'TODO - It may be desirable to also write this exception to a log file
        'somewhere at some point, beyond the automatic logging that will take place
        'when (if?) the user hits "Send Data".
    End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrorDialogNoSend))
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.pbTechSupport = New System.Windows.Forms.PictureBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblErr02 = New System.Windows.Forms.Label()
        Me.lblErr01 = New System.Windows.Forms.Label()
        Me.lblAltLink = New System.Windows.Forms.LinkLabel()
        CType(Me.pbTechSupport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCopy
        '
        Me.btnCopy.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCopy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCopy.Location = New System.Drawing.Point(170, 300)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(100, 30)
        Me.btnCopy.TabIndex = 18
        Me.btnCopy.Text = "C&opy"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(15, 105)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtComments.Size = New System.Drawing.Size(365, 175)
        Me.txtComments.TabIndex = 17
        '
        'pbTechSupport
        '
        Me.pbTechSupport.BackgroundImage = CType(resources.GetObject("pbTechSupport.BackgroundImage"), System.Drawing.Image)
        Me.pbTechSupport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbTechSupport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbTechSupport.Location = New System.Drawing.Point(15, 15)
        Me.pbTechSupport.Name = "pbTechSupport"
        Me.pbTechSupport.Size = New System.Drawing.Size(55, 75)
        Me.pbTechSupport.TabIndex = 16
        Me.pbTechSupport.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnClose.Location = New System.Drawing.Point(280, 300)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "&Close"
        '
        'lblErr02
        '
        Me.lblErr02.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblErr02.Location = New System.Drawing.Point(75, 45)
        Me.lblErr02.Name = "lblErr02"
        Me.lblErr02.Size = New System.Drawing.Size(305, 35)
        Me.lblErr02.TabIndex = 28
        '
        'lblErr01
        '
        Me.lblErr01.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblErr01.Location = New System.Drawing.Point(75, 15)
        Me.lblErr01.Name = "lblErr01"
        Me.lblErr01.Size = New System.Drawing.Size(305, 16)
        Me.lblErr01.TabIndex = 27
        '
        'lblAltLink
        '
        Me.lblAltLink.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAltLink.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.lblAltLink.Location = New System.Drawing.Point(15, 340)
        Me.lblAltLink.Name = "lblAltLink"
        Me.lblAltLink.Size = New System.Drawing.Size(370, 19)
        Me.lblAltLink.TabIndex = 29
        Me.lblAltLink.UseMnemonic = False
        '
        'frmErrorDialogNoSend
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 375)
        Me.Controls.Add(Me.lblAltLink)
        Me.Controls.Add(Me.lblErr02)
        Me.Controls.Add(Me.lblErr01)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.pbTechSupport)
        Me.Controls.Add(Me.btnClose)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmErrorDialogNoSend"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "An Error Has Occured"
        CType(Me.pbTechSupport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents pbTechSupport As System.Windows.Forms.PictureBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblErr02 As System.Windows.Forms.Label
    Friend WithEvents lblErr01 As System.Windows.Forms.Label
    Friend WithEvents lblAltLink As System.Windows.Forms.LinkLabel
End Class
