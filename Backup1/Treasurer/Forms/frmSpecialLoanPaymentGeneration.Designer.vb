<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecialLoanPaymentGeneration
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
        Me.cboLoanType = New System.Windows.Forms.ComboBox
        Me.cboLoanTypeId = New System.Windows.Forms.ComboBox
        Me.lblLoanType = New System.Windows.Forms.Label
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.lblContributionDate = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboLoanType
        '
        Me.cboLoanType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoanType.DropDownWidth = 250
        Me.cboLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLoanType.FormattingEnabled = True
        Me.cboLoanType.Location = New System.Drawing.Point(120, 45)
        Me.cboLoanType.Name = "cboLoanType"
        Me.cboLoanType.Size = New System.Drawing.Size(201, 22)
        Me.cboLoanType.TabIndex = 34
        '
        'cboLoanTypeId
        '
        Me.cboLoanTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLoanTypeId.FormattingEnabled = True
        Me.cboLoanTypeId.Location = New System.Drawing.Point(301, 46)
        Me.cboLoanTypeId.Name = "cboLoanTypeId"
        Me.cboLoanTypeId.Size = New System.Drawing.Size(20, 21)
        Me.cboLoanTypeId.TabIndex = 35
        Me.cboLoanTypeId.TabStop = False
        Me.cboLoanTypeId.Visible = False
        '
        'lblLoanType
        '
        Me.lblLoanType.AutoSize = True
        Me.lblLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLoanType.Location = New System.Drawing.Point(19, 49)
        Me.lblLoanType.Name = "lblLoanType"
        Me.lblLoanType.Size = New System.Drawing.Size(63, 14)
        Me.lblLoanType.TabIndex = 33
        Me.lblLoanType.Text = "Loan Type"
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.Green
        Me.btnGenerate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnGenerate.ForeColor = System.Drawing.SystemColors.Control
        Me.btnGenerate.Location = New System.Drawing.Point(22, 89)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(299, 28)
        Me.btnGenerate.TabIndex = 36
        Me.btnGenerate.Text = "Generate Payment"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.CustomFormat = "MMMM yyyy"
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDate.Location = New System.Drawing.Point(120, 19)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.ShowCheckBox = True
        Me.dtpPaymentDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpPaymentDate.TabIndex = 38
        '
        'lblContributionDate
        '
        Me.lblContributionDate.AutoSize = True
        Me.lblContributionDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblContributionDate.Location = New System.Drawing.Point(19, 24)
        Me.lblContributionDate.Name = "lblContributionDate"
        Me.lblContributionDate.Size = New System.Drawing.Size(92, 14)
        Me.lblContributionDate.TabIndex = 37
        Me.lblContributionDate.Text = "Month and Year"
        '
        'frmSpecialLoanPaymentGeneration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(343, 140)
        Me.Controls.Add(Me.dtpPaymentDate)
        Me.Controls.Add(Me.lblContributionDate)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.cboLoanType)
        Me.Controls.Add(Me.cboLoanTypeId)
        Me.Controls.Add(Me.lblLoanType)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSpecialLoanPaymentGeneration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Special Loan Payment Generation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboLoanType As System.Windows.Forms.ComboBox
    Friend WithEvents cboLoanTypeId As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoanType As System.Windows.Forms.Label
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContributionDate As System.Windows.Forms.Label
End Class
