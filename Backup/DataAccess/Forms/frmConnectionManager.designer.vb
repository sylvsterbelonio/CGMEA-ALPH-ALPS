<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionManager
    Inherits System.Windows.Forms.Form

    '<CLSCompliant(False)> _
    'Public Sub New(ByVal OwnerForm As Windows.Forms.Form, ByVal blnConn As Boolean)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call
    '    m_owner = OwnerForm
    '    m_newconnection = blnConn
    'End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnectionManager))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbConnection = New System.Windows.Forms.GroupBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.cboDBName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.gbConnection.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(356, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select appropriate configuration for your system's database connection."
        '
        'gbConnection
        '
        Me.gbConnection.Controls.Add(Me.txtPort)
        Me.gbConnection.Controls.Add(Me.lblPort)
        Me.gbConnection.Controls.Add(Me.cboDBName)
        Me.gbConnection.Controls.Add(Me.Label3)
        Me.gbConnection.Controls.Add(Me.txtServer)
        Me.gbConnection.Controls.Add(Me.Label2)
        Me.gbConnection.Controls.Add(Me.txtUserID)
        Me.gbConnection.Controls.Add(Me.Label5)
        Me.gbConnection.Controls.Add(Me.Label7)
        Me.gbConnection.Controls.Add(Me.Label8)
        Me.gbConnection.Controls.Add(Me.txtPassword)
        Me.gbConnection.ForeColor = System.Drawing.SystemColors.ControlText
        Me.gbConnection.Location = New System.Drawing.Point(10, 25)
        Me.gbConnection.Name = "gbConnection"
        Me.gbConnection.Size = New System.Drawing.Size(350, 240)
        Me.gbConnection.TabIndex = 5
        Me.gbConnection.TabStop = False
        Me.gbConnection.Text = "Connect to MySQL Server Instance"
        '
        'txtPort
        '
        Me.txtPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPort.Location = New System.Drawing.Point(120, 50)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(200, 20)
        Me.txtPort.TabIndex = 1
        Me.txtPort.Text = "3306"
        '
        'lblPort
        '
        Me.lblPort.AutoSize = True
        Me.lblPort.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPort.Location = New System.Drawing.Point(20, 50)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(26, 14)
        Me.lblPort.TabIndex = 25
        Me.lblPort.Text = "Port"
        '
        'cboDBName
        '
        Me.cboDBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDBName.Enabled = False
        Me.cboDBName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboDBName.FormattingEnabled = True
        Me.cboDBName.Location = New System.Drawing.Point(120, 125)
        Me.cboDBName.Name = "cboDBName"
        Me.cboDBName.Size = New System.Drawing.Size(200, 22)
        Me.cboDBName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(20, 165)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(324, 60)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'txtServer
        '
        Me.txtServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtServer.Location = New System.Drawing.Point(120, 25)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(200, 20)
        Me.txtServer.TabIndex = 0
        Me.txtServer.Text = "LOCALHOST"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(20, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Database Name"
        '
        'txtUserID
        '
        Me.txtUserID.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserID.Location = New System.Drawing.Point(120, 75)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(200, 20)
        Me.txtUserID.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(20, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Server Host"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(20, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 14)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "User Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(20, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 14)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPassword.Location = New System.Drawing.Point(120, 100)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(200, 20)
        Me.txtPassword.TabIndex = 3
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(40, 280)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Enabled = False
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(260, 280)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 30)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTest.Location = New System.Drawing.Point(150, 280)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(100, 30)
        Me.btnTest.TabIndex = 6
        Me.btnTest.Text = "&Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'frmConnectionManager
        '
        Me.AcceptButton = Me.btnTest
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(369, 327)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.gbConnection)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnectionManager"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Connection Manager"
        Me.gbConnection.ResumeLayout(False)
        Me.gbConnection.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbConnection As System.Windows.Forms.GroupBox
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboDBName As System.Windows.Forms.ComboBox
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents lblPort As System.Windows.Forms.Label
End Class
