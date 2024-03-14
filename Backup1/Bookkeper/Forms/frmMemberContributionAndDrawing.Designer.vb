<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberContributionAndDrawing
    Inherits System.Windows.Forms.Form

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
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.btnPreview = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtMemberId
        '
        Me.txtMemberId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberId.Location = New System.Drawing.Point(330, 12)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 10
        Me.txtMemberId.TabStop = False
        Me.txtMemberId.Visible = False
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(121, 12)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(229, 20)
        Me.txtMemberName.TabIndex = 9
        '
        'lblMemberName
        '
        Me.lblMemberName.BackColor = System.Drawing.Color.White
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(11, 12)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(100, 16)
        Me.lblMemberName.TabIndex = 8
        Me.lblMemberName.Text = "Member Name *"
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPreview.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnPreview.ForeColor = System.Drawing.Color.White
        Me.btnPreview.Location = New System.Drawing.Point(14, 52)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(336, 28)
        Me.btnPreview.TabIndex = 14
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'frmMemberContributionAndDrawing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(366, 95)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.txtMemberId)
        Me.Controls.Add(Me.txtMemberName)
        Me.Controls.Add(Me.lblMemberName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMemberContributionAndDrawing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Contributions And Drawings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
End Class
