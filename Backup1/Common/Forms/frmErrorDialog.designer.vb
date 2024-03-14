<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrorDialog))
        Me.txtEMail = New System.Windows.Forms.TextBox
        Me.chkNoReport = New System.Windows.Forms.CheckBox
        Me.txtComments = New System.Windows.Forms.TextBox
        Me.lblComments = New System.Windows.Forms.Label
        Me.lblWhatReport = New System.Windows.Forms.LinkLabel
        Me.btnDontSend = New System.Windows.Forms.Button
        Me.pbTechSupport = New System.Windows.Forms.PictureBox
        Me.lblErr01 = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.lblAltLink = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblErr02 = New System.Windows.Forms.Label
        CType(Me.pbTechSupport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEMail
        '
        Me.txtEMail.Location = New System.Drawing.Point(12, 252)
        Me.txtEMail.Name = "txtEMail"
        Me.txtEMail.Size = New System.Drawing.Size(365, 20)
        Me.txtEMail.TabIndex = 16
        '
        'chkNoReport
        '
        Me.chkNoReport.AutoSize = True
        Me.chkNoReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chkNoReport.Location = New System.Drawing.Point(12, 317)
        Me.chkNoReport.Name = "chkNoReport"
        Me.chkNoReport.Size = New System.Drawing.Size(163, 18)
        Me.chkNoReport.TabIndex = 24
        Me.chkNoReport.Text = "Don't Ask Me to Report Bugs"
        Me.chkNoReport.UseVisualStyleBackColor = True
        '
        'txtComments
        '
        Me.txtComments.AcceptsReturn = True
        Me.txtComments.Location = New System.Drawing.Point(12, 143)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(365, 66)
        Me.txtComments.TabIndex = 15
        '
        'lblComments
        '
        Me.lblComments.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblComments.Location = New System.Drawing.Point(12, 107)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(365, 30)
        Me.lblComments.TabIndex = 23
        Me.lblComments.Text = "If you would like to include additional comments such as how to cause this proble" & _
            "m, please enter your text below:    (Optional)"
        '
        'lblWhatReport
        '
        Me.lblWhatReport.AutoSize = True
        Me.lblWhatReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWhatReport.Location = New System.Drawing.Point(72, 82)
        Me.lblWhatReport.Name = "lblWhatReport"
        Me.lblWhatReport.Size = New System.Drawing.Size(109, 14)
        Me.lblWhatReport.TabIndex = 19
        Me.lblWhatReport.TabStop = True
        Me.lblWhatReport.Text = "What's in this report?"
        '
        'btnDontSend
        '
        Me.btnDontSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDontSend.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDontSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDontSend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnDontSend.Location = New System.Drawing.Point(172, 282)
        Me.btnDontSend.Name = "btnDontSend"
        Me.btnDontSend.Size = New System.Drawing.Size(100, 30)
        Me.btnDontSend.TabIndex = 18
        Me.btnDontSend.Text = "&No, Don't Send"
        '
        'pbTechSupport
        '
        Me.pbTechSupport.BackgroundImage = CType(resources.GetObject("pbTechSupport.BackgroundImage"), System.Drawing.Image)
        Me.pbTechSupport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbTechSupport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbTechSupport.Location = New System.Drawing.Point(12, 12)
        Me.pbTechSupport.Name = "pbTechSupport"
        Me.pbTechSupport.Size = New System.Drawing.Size(55, 75)
        Me.pbTechSupport.TabIndex = 22
        Me.pbTechSupport.TabStop = False
        '
        'lblErr01
        '
        Me.lblErr01.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblErr01.Location = New System.Drawing.Point(72, 12)
        Me.lblErr01.Name = "lblErr01"
        Me.lblErr01.Size = New System.Drawing.Size(305, 16)
        Me.lblErr01.TabIndex = 21
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSend.Location = New System.Drawing.Point(277, 282)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(100, 30)
        Me.btnSend.TabIndex = 17
        Me.btnSend.Text = "&Send Data"
        '
        'lblAltLink
        '
        Me.lblAltLink.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblAltLink.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline
        Me.lblAltLink.Location = New System.Drawing.Point(12, 337)
        Me.lblAltLink.Name = "lblAltLink"
        Me.lblAltLink.Size = New System.Drawing.Size(370, 19)
        Me.lblAltLink.TabIndex = 20
        Me.lblAltLink.UseMnemonic = False
        '
        'Label1
        '
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 217)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 30)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Please provide a vaid email address where we can contact you with questions or co" & _
            "mments about this error. (Required)"
        '
        'lblErr02
        '
        Me.lblErr02.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblErr02.Location = New System.Drawing.Point(72, 42)
        Me.lblErr02.Name = "lblErr02"
        Me.lblErr02.Size = New System.Drawing.Size(305, 35)
        Me.lblErr02.TabIndex = 26
        '
        'frmErrorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 375)
        Me.Controls.Add(Me.lblErr02)
        Me.Controls.Add(Me.lblErr01)
        Me.Controls.Add(Me.pbTechSupport)
        Me.Controls.Add(Me.lblComments)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblWhatReport)
        Me.Controls.Add(Me.lblAltLink)
        Me.Controls.Add(Me.chkNoReport)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.btnDontSend)
        Me.Controls.Add(Me.txtEMail)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmErrorDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "An Error Has Occured"
        CType(Me.pbTechSupport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEMail As System.Windows.Forms.TextBox
    Friend WithEvents chkNoReport As System.Windows.Forms.CheckBox
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblWhatReport As System.Windows.Forms.LinkLabel
    Friend WithEvents btnDontSend As System.Windows.Forms.Button
    Friend WithEvents pbTechSupport As System.Windows.Forms.PictureBox
    Friend WithEvents lblErr01 As System.Windows.Forms.Label
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents lblAltLink As System.Windows.Forms.LinkLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblErr02 As System.Windows.Forms.Label
End Class