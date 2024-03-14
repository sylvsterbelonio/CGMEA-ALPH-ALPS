<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal uid As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        UserID = uid

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePassword))
        Me.lblConfirmPswrd = New System.Windows.Forms.Label()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.lblNewPswrd = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.lblOldPswrd = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.gbChangePassword = New System.Windows.Forms.GroupBox()
        Me.gbChangePassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblConfirmPswrd
        '
        Me.lblConfirmPswrd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmPswrd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConfirmPswrd.Location = New System.Drawing.Point(20, 95)
        Me.lblConfirmPswrd.Name = "lblConfirmPswrd"
        Me.lblConfirmPswrd.Size = New System.Drawing.Size(100, 16)
        Me.lblConfirmPswrd.TabIndex = 18
        Me.lblConfirmPswrd.Text = "Confirm Password"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtConfirmPassword.Location = New System.Drawing.Point(130, 95)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(200, 20)
        Me.txtConfirmPassword.TabIndex = 2
        '
        'lblNewPswrd
        '
        Me.lblNewPswrd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewPswrd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNewPswrd.Location = New System.Drawing.Point(20, 70)
        Me.lblNewPswrd.Name = "lblNewPswrd"
        Me.lblNewPswrd.Size = New System.Drawing.Size(100, 16)
        Me.lblNewPswrd.TabIndex = 16
        Me.lblNewPswrd.Text = "New Password"
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNewPassword.Location = New System.Drawing.Point(130, 70)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(200, 20)
        Me.txtNewPassword.TabIndex = 1
        '
        'lblOldPswrd
        '
        Me.lblOldPswrd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOldPswrd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOldPswrd.Location = New System.Drawing.Point(20, 45)
        Me.lblOldPswrd.Name = "lblOldPswrd"
        Me.lblOldPswrd.Size = New System.Drawing.Size(100, 16)
        Me.lblOldPswrd.TabIndex = 13
        Me.lblOldPswrd.Text = "Old Password"
        '
        'lblUserName
        '
        Me.lblUserName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblUserName.Location = New System.Drawing.Point(20, 20)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(100, 16)
        Me.lblUserName.TabIndex = 9
        Me.lblUserName.Text = "Username"
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtOldPassword.Location = New System.Drawing.Point(130, 45)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPassword.Size = New System.Drawing.Size(200, 20)
        Me.txtOldPassword.TabIndex = 0
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserName.Location = New System.Drawing.Point(130, 20)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(200, 20)
        Me.txtUserName.TabIndex = 0
        Me.txtUserName.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Transparent
        Me.btnOK.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOK.Location = New System.Drawing.Point(125, 130)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(100, 30)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCancel.Location = New System.Drawing.Point(230, 130)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'gbChangePassword
        '
        Me.gbChangePassword.BackColor = System.Drawing.SystemColors.Control
        Me.gbChangePassword.Controls.Add(Me.lblConfirmPswrd)
        Me.gbChangePassword.Controls.Add(Me.txtConfirmPassword)
        Me.gbChangePassword.Controls.Add(Me.lblNewPswrd)
        Me.gbChangePassword.Controls.Add(Me.txtNewPassword)
        Me.gbChangePassword.Controls.Add(Me.lblOldPswrd)
        Me.gbChangePassword.Controls.Add(Me.lblUserName)
        Me.gbChangePassword.Controls.Add(Me.txtOldPassword)
        Me.gbChangePassword.Controls.Add(Me.txtUserName)
        Me.gbChangePassword.Controls.Add(Me.btnOK)
        Me.gbChangePassword.Controls.Add(Me.btnCancel)
        Me.gbChangePassword.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.gbChangePassword.Location = New System.Drawing.Point(10, 10)
        Me.gbChangePassword.Name = "gbChangePassword"
        Me.gbChangePassword.Size = New System.Drawing.Size(345, 170)
        Me.gbChangePassword.TabIndex = 12
        Me.gbChangePassword.TabStop = False
        '
        'frmChangePassword
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(364, 195)
        Me.Controls.Add(Me.gbChangePassword)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePassword"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change User Password"
        Me.gbChangePassword.ResumeLayout(False)
        Me.gbChangePassword.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblConfirmPswrd As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblNewPswrd As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblOldPswrd As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtOldPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents gbChangePassword As System.Windows.Forms.GroupBox
End Class
