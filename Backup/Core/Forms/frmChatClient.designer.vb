<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChatClient
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
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtChatBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMessagebox = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.lstClients = New System.Windows.Forms.ListBox
        Me.bgw = New System.ComponentModel.BackgroundWorker
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(456, 427)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(107, 25)
        Me.btnSend.TabIndex = 0
        Me.btnSend.Text = "Send Message"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtChatBox
        '
        Me.txtChatBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtChatBox.Location = New System.Drawing.Point(12, 34)
        Me.txtChatBox.Multiline = True
        Me.txtChatBox.Name = "txtChatBox"
        Me.txtChatBox.ReadOnly = True
        Me.txtChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChatBox.Size = New System.Drawing.Size(551, 283)
        Me.txtChatBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Chat name :"
        '
        'txtMessagebox
        '
        Me.txtMessagebox.Location = New System.Drawing.Point(12, 323)
        Me.txtMessagebox.Multiline = True
        Me.txtMessagebox.Name = "txtMessagebox"
        Me.txtMessagebox.Size = New System.Drawing.Size(551, 95)
        Me.txtMessagebox.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(82, 6)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.ReadOnly = True
        Me.txtUserName.Size = New System.Drawing.Size(481, 20)
        Me.txtUserName.TabIndex = 5
        Me.txtUserName.Text = "Cow Boy"
        '
        'lstClients
        '
        Me.lstClients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstClients.FormattingEnabled = True
        Me.lstClients.Items.AddRange(New Object() {"CGMEA-ALPS GROUP"})
        Me.lstClients.Location = New System.Drawing.Point(569, 8)
        Me.lstClients.Name = "lstClients"
        Me.lstClients.Size = New System.Drawing.Size(186, 446)
        Me.lstClients.TabIndex = 6
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        '
        'frmChatClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(767, 461)
        Me.Controls.Add(Me.lstClients)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.txtMessagebox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtChatBox)
        Me.Controls.Add(Me.btnSend)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChatClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CGMEA-ALPS Chat Box"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txtChatBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMessagebox As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lstClients As System.Windows.Forms.ListBox
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker

End Class
