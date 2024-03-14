<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemLock
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal userName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.txtUserName.Text = userName
        'TODO - It may be desirable to also write this exception to a log file
        'somewhere at some point, beyond the automatic logging that will take place
        'when (if?) the user hits "Send Data".
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemLock))
        Me.lblSystemLock = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.btnUnlock = New System.Windows.Forms.Button
        Me.pbLogoMain = New System.Windows.Forms.PictureBox
        Me.pnlSystemLock = New System.Windows.Forms.Panel
        Me.lblWarning = New System.Windows.Forms.Label
        Me.pnlBorder = New System.Windows.Forms.Panel
        Me.lblSystem = New System.Windows.Forms.Label
        Me.tooltipPassword = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.pbLogoMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSystemLock.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSystemLock
        '
        Me.lblSystemLock.BackColor = System.Drawing.Color.Transparent
        Me.lblSystemLock.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystemLock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSystemLock.Location = New System.Drawing.Point(150, 5)
        Me.lblSystemLock.Name = "lblSystemLock"
        Me.lblSystemLock.Size = New System.Drawing.Size(340, 135)
        Me.lblSystemLock.TabIndex = 29
        Me.lblSystemLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(170, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "User Name     :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(170, 205)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Password      :"
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPassword.Location = New System.Drawing.Point(255, 205)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(210, 20)
        Me.txtPassword.TabIndex = 24
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtUserName
        '
        Me.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserName.Location = New System.Drawing.Point(255, 175)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(210, 20)
        Me.txtUserName.TabIndex = 23
        '
        'btnUnlock
        '
        Me.btnUnlock.Enabled = False
        Me.btnUnlock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnUnlock.Location = New System.Drawing.Point(255, 240)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(210, 30)
        Me.btnUnlock.TabIndex = 21
        Me.btnUnlock.Text = "&OK"
        Me.btnUnlock.UseVisualStyleBackColor = True
        '
        'pbLogoMain
        '
        Me.pbLogoMain.Location = New System.Drawing.Point(5, 5)
        Me.pbLogoMain.Name = "pbLogoMain"
        Me.pbLogoMain.Size = New System.Drawing.Size(135, 135)
        Me.pbLogoMain.TabIndex = 31
        Me.pbLogoMain.TabStop = False
        '
        'pnlSystemLock
        '
        Me.pnlSystemLock.Controls.Add(Me.lblWarning)
        Me.pnlSystemLock.Location = New System.Drawing.Point(150, 145)
        Me.pnlSystemLock.Name = "pnlSystemLock"
        Me.pnlSystemLock.Size = New System.Drawing.Size(340, 135)
        Me.pnlSystemLock.TabIndex = 33
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.Transparent
        Me.lblWarning.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWarning.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWarning.Location = New System.Drawing.Point(0, 0)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(340, 135)
        Me.lblWarning.TabIndex = 30
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlBorder
        '
        Me.pnlBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBorder.Location = New System.Drawing.Point(150, 140)
        Me.pnlBorder.Name = "pnlBorder"
        Me.pnlBorder.Size = New System.Drawing.Size(340, 5)
        Me.pnlBorder.TabIndex = 31
        '
        'lblSystem
        '
        Me.lblSystem.BackColor = System.Drawing.Color.Transparent
        Me.lblSystem.Font = New System.Drawing.Font("High Tower Text", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSystem.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSystem.Location = New System.Drawing.Point(5, 145)
        Me.lblSystem.Name = "lblSystem"
        Me.lblSystem.Size = New System.Drawing.Size(135, 135)
        Me.lblSystem.TabIndex = 34
        Me.lblSystem.Text = "CGMEA-ALPS"
        Me.lblSystem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tooltipPassword
        '
        Me.tooltipPassword.Active = False
        Me.tooltipPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning
        Me.tooltipPassword.ToolTipTitle = "Caps Lock is On"
        '
        'frmSystemLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 285)
        Me.Controls.Add(Me.pnlBorder)
        Me.Controls.Add(Me.lblSystem)
        Me.Controls.Add(Me.pnlSystemLock)
        Me.Controls.Add(Me.lblSystemLock)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.btnUnlock)
        Me.Controls.Add(Me.pbLogoMain)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSystemLock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Lock"
        Me.TopMost = True
        CType(Me.pbLogoMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSystemLock.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSystemLock As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btnUnlock As System.Windows.Forms.Button
    Friend WithEvents pbLogoMain As System.Windows.Forms.PictureBox
    Friend WithEvents pnlSystemLock As System.Windows.Forms.Panel
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents pnlBorder As System.Windows.Forms.Panel
    Friend WithEvents lblSystem As System.Windows.Forms.Label
    Friend WithEvents tooltipPassword As System.Windows.Forms.ToolTip
End Class
