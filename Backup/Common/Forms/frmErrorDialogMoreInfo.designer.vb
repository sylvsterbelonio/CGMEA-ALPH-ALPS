<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmErrorDialogMoreInfo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmErrorDialogMoreInfo))
        Me.btnCopy = New System.Windows.Forms.Button
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtFullText = New System.Windows.Forms.TextBox
        Me.lblErr = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCopy.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCopy.Location = New System.Drawing.Point(275, 385)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(100, 30)
        Me.btnCopy.TabIndex = 18
        Me.btnCopy.Text = "C&opy"
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSend.Location = New System.Drawing.Point(380, 385)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(100, 30)
        Me.btnSend.TabIndex = 17
        Me.btnSend.Text = "&Close"
        '
        'txtFullText
        '
        Me.txtFullText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFullText.Location = New System.Drawing.Point(15, 55)
        Me.txtFullText.Multiline = True
        Me.txtFullText.Name = "txtFullText"
        Me.txtFullText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFullText.Size = New System.Drawing.Size(465, 320)
        Me.txtFullText.TabIndex = 16
        '
        'lblErr
        '
        Me.lblErr.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblErr.Location = New System.Drawing.Point(15, 15)
        Me.lblErr.Name = "lblErr"
        Me.lblErr.Size = New System.Drawing.Size(465, 30)
        Me.lblErr.TabIndex = 15
        Me.lblErr.Text = "The following text is what will be contained in the error report. You may also cl" & _
            "ick the Copy button to copy this text to the clipboard."
        '
        'frmErrorDialogMoreInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 425)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtFullText)
        Me.Controls.Add(Me.lblErr)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmErrorDialogMoreInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "An Error Has Occurred"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents txtFullText As System.Windows.Forms.TextBox
    Friend WithEvents lblErr As System.Windows.Forms.Label
End Class
