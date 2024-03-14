<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartORNo
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
        Me.txtORNoNumerical = New System.Windows.Forms.TextBox
        Me.lblORNo = New System.Windows.Forms.Label
        Me.lblORDt = New System.Windows.Forms.Label
        Me.dtpORDt = New System.Windows.Forms.DateTimePicker
        Me.btnOK = New System.Windows.Forms.Button
        Me.txtORNoAlpha = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtORNoNumerical
        '
        Me.txtORNoNumerical.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtORNoNumerical.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNoNumerical.Location = New System.Drawing.Point(20, 40)
        Me.txtORNoNumerical.MaxLength = 8
        Me.txtORNoNumerical.Name = "txtORNoNumerical"
        Me.txtORNoNumerical.Size = New System.Drawing.Size(200, 20)
        Me.txtORNoNumerical.TabIndex = 1
        '
        'lblORNo
        '
        Me.lblORNo.AutoSize = True
        Me.lblORNo.BackColor = System.Drawing.Color.Transparent
        Me.lblORNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORNo.Location = New System.Drawing.Point(20, 20)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(126, 14)
        Me.lblORNo.TabIndex = 0
        Me.lblORNo.Text = "Enter Oficial Receipt No.:"
        '
        'lblORDt
        '
        Me.lblORDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORDt.Location = New System.Drawing.Point(20, 80)
        Me.lblORDt.Name = "lblORDt"
        Me.lblORDt.Size = New System.Drawing.Size(105, 16)
        Me.lblORDt.TabIndex = 3
        Me.lblORDt.Text = "Official Receipt Date"
        '
        'dtpORDt
        '
        Me.dtpORDt.Checked = False
        Me.dtpORDt.CustomFormat = "dddd, MMMM dd, yyyy"
        Me.dtpORDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpORDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpORDt.Location = New System.Drawing.Point(20, 105)
        Me.dtpORDt.Name = "dtpORDt"
        Me.dtpORDt.Size = New System.Drawing.Size(225, 20)
        Me.dtpORDt.TabIndex = 4
        Me.dtpORDt.Value = New Date(2011, 7, 17, 0, 0, 0, 0)
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(150, 140)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(95, 40)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'txtORNoAlpha
        '
        Me.txtORNoAlpha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtORNoAlpha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNoAlpha.Location = New System.Drawing.Point(225, 40)
        Me.txtORNoAlpha.MaxLength = 1
        Me.txtORNoAlpha.Name = "txtORNoAlpha"
        Me.txtORNoAlpha.Size = New System.Drawing.Size(20, 20)
        Me.txtORNoAlpha.TabIndex = 2
        '
        'frmStartORNo
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 192)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblORDt)
        Me.Controls.Add(Me.dtpORDt)
        Me.Controls.Add(Me.txtORNoAlpha)
        Me.Controls.Add(Me.txtORNoNumerical)
        Me.Controls.Add(Me.lblORNo)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStartORNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Start OR No."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtORNoNumerical As System.Windows.Forms.TextBox
    Friend WithEvents lblORNo As System.Windows.Forms.Label
    Friend WithEvents lblORDt As System.Windows.Forms.Label
    Friend WithEvents dtpORDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents txtORNoAlpha As System.Windows.Forms.TextBox
End Class
