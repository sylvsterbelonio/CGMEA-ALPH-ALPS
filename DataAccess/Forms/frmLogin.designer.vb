<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal frmType As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        formType = frmType
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnLogin = New System.Windows.Forms.Button
        Me.lblHidden = New System.Windows.Forms.Label
        Me.tooltipPassword = New System.Windows.Forms.ToolTip(Me.components)
        Me.pbLogoMapping = New System.Windows.Forms.PictureBox
        Me.pbLogoMain = New System.Windows.Forms.PictureBox
        CType(Me.pbLogoMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLogoMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(120, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(305, 30)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "This application manipulates sensitive data. Only registered users are allowed ac" & _
            "cess."
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(120, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(305, 30)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Caution : If you lose or forget the password, it can not be recovered. (Remember " & _
            "that passwords are case sensitive.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(120, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "User Name     :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(120, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Password      :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(120, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "If you've been registered, please supply the following data:"
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPassword.Location = New System.Drawing.Point(205, 155)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(210, 20)
        Me.txtPassword.TabIndex = 12
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserName
        '
        Me.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserName.Location = New System.Drawing.Point(205, 125)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(210, 20)
        Me.txtUserName.TabIndex = 11
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(205, 190)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnLogin
        '
        Me.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLogin.Location = New System.Drawing.Point(315, 190)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(100, 30)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.Text = "&OK"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'lblHidden
        '
        Me.lblHidden.AutoSize = True
        Me.lblHidden.Location = New System.Drawing.Point(423, 232)
        Me.lblHidden.Name = "lblHidden"
        Me.lblHidden.Size = New System.Drawing.Size(13, 14)
        Me.lblHidden.TabIndex = 18
        Me.lblHidden.Text = "+"
        Me.lblHidden.Visible = False
        '
        'tooltipPassword
        '
        Me.tooltipPassword.Active = False
        Me.tooltipPassword.IsBalloon = True
        Me.tooltipPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.tooltipPassword.ToolTipTitle = "Caps Lock is On"
        '
        'pbLogoMapping
        '
        Me.pbLogoMapping.Location = New System.Drawing.Point(10, 120)
        Me.pbLogoMapping.Name = "pbLogoMapping"
        Me.pbLogoMapping.Size = New System.Drawing.Size(100, 100)
        Me.pbLogoMapping.TabIndex = 20
        Me.pbLogoMapping.TabStop = False
        '
        'pbLogoMain
        '
        Me.pbLogoMain.Location = New System.Drawing.Point(10, 10)
        Me.pbLogoMain.Name = "pbLogoMain"
        Me.pbLogoMain.Size = New System.Drawing.Size(100, 100)
        Me.pbLogoMain.TabIndex = 19
        Me.pbLogoMain.TabStop = False
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 240)
        Me.Controls.Add(Me.pbLogoMapping)
        Me.Controls.Add(Me.lblHidden)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.pbLogoMain)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbLogoMapping, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLogoMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblHidden As System.Windows.Forms.Label
    Friend WithEvents pbLogoMain As System.Windows.Forms.PictureBox
    Friend WithEvents pbLogoMapping As System.Windows.Forms.PictureBox
    Friend WithEvents tooltipPassword As System.Windows.Forms.ToolTip
End Class
