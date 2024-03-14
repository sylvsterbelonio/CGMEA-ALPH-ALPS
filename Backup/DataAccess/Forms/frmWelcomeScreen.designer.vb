<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWelcomeScreen
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWelcomeScreen))
        Me.btnPrevious = New System.Windows.Forms.Button
        Me.ilWelcome = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlBorder = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.chkDisplay = New System.Windows.Forms.CheckBox
        Me.btnIntroduction = New System.Windows.Forms.Button
        Me.rtbInfo = New System.Windows.Forms.RichTextBox
        Me.SuspendLayout()
        '
        'btnPrevious
        '
        Me.btnPrevious.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrevious.ImageIndex = 0
        Me.btnPrevious.ImageList = Me.ilWelcome
        Me.btnPrevious.Location = New System.Drawing.Point(415, 55)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(150, 30)
        Me.btnPrevious.TabIndex = 2
        Me.btnPrevious.Text = "&Previous Tip"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'ilWelcome
        '
        Me.ilWelcome.ImageStream = CType(resources.GetObject("ilWelcome.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilWelcome.TransparentColor = System.Drawing.Color.Transparent
        Me.ilWelcome.Images.SetKeyName(0, "previous.ico")
        Me.ilWelcome.Images.SetKeyName(1, "next.ico")
        Me.ilWelcome.Images.SetKeyName(2, "cancel.ico")
        '
        'pnlBorder
        '
        Me.pnlBorder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBorder.Location = New System.Drawing.Point(10, 245)
        Me.pnlBorder.Name = "pnlBorder"
        Me.pnlBorder.Size = New System.Drawing.Size(560, 4)
        Me.pnlBorder.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.ImageIndex = 2
        Me.btnClose.ImageList = Me.ilWelcome
        Me.btnClose.Location = New System.Drawing.Point(415, 255)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(150, 30)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNext.ImageIndex = 1
        Me.btnNext.ImageList = Me.ilWelcome
        Me.btnNext.Location = New System.Drawing.Point(415, 95)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(150, 30)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "&Next Tip"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'chkDisplay
        '
        Me.chkDisplay.AutoSize = True
        Me.chkDisplay.Location = New System.Drawing.Point(415, 215)
        Me.chkDisplay.Name = "chkDisplay"
        Me.chkDisplay.Size = New System.Drawing.Size(143, 18)
        Me.chkDisplay.TabIndex = 4
        Me.chkDisplay.Text = "Do not display at startup"
        Me.chkDisplay.UseVisualStyleBackColor = True
        '
        'btnIntroduction
        '
        Me.btnIntroduction.Location = New System.Drawing.Point(415, 15)
        Me.btnIntroduction.Name = "btnIntroduction"
        Me.btnIntroduction.Size = New System.Drawing.Size(150, 30)
        Me.btnIntroduction.TabIndex = 1
        Me.btnIntroduction.Text = "&Introduction..."
        Me.btnIntroduction.UseVisualStyleBackColor = True
        '
        'rtbInfo
        '
        Me.rtbInfo.BackColor = System.Drawing.SystemColors.Info
        Me.rtbInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbInfo.Location = New System.Drawing.Point(15, 15)
        Me.rtbInfo.Margin = New System.Windows.Forms.Padding(5)
        Me.rtbInfo.Name = "rtbInfo"
        Me.rtbInfo.ReadOnly = True
        Me.rtbInfo.ShowSelectionMargin = True
        Me.rtbInfo.Size = New System.Drawing.Size(380, 210)
        Me.rtbInfo.TabIndex = 0
        Me.rtbInfo.Text = resources.GetString("rtbInfo.Text")
        '
        'frmWelcomeScreen
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(579, 300)
        Me.Controls.Add(Me.rtbInfo)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.pnlBorder)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.chkDisplay)
        Me.Controls.Add(Me.btnIntroduction)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmWelcomeScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome Screen - Tip of the Day"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents ilWelcome As System.Windows.Forms.ImageList
    Friend WithEvents pnlBorder As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents chkDisplay As System.Windows.Forms.CheckBox
    Friend WithEvents btnIntroduction As System.Windows.Forms.Button
    Friend WithEvents rtbInfo As System.Windows.Forms.RichTextBox
End Class
