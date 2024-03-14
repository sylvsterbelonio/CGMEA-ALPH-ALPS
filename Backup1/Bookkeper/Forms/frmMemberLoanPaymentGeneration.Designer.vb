<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberLoanPaymentGeneration
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
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.gbParameters = New System.Windows.Forms.GroupBox
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.dtpLoanPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.lblContributionDate = New System.Windows.Forms.Label
        Me.gbParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(361, 63)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(131, 40)
        Me.btnPreview.TabIndex = 8
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(361, 109)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(131, 40)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(361, 17)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(131, 40)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "Generate Loan Payment"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'gbParameters
        '
        Me.gbParameters.Controls.Add(Me.lblMemberNo)
        Me.gbParameters.Controls.Add(Me.txtMemberNo)
        Me.gbParameters.Controls.Add(Me.txtMemberName)
        Me.gbParameters.Controls.Add(Me.lblMemberName)
        Me.gbParameters.Controls.Add(Me.dtpLoanPaymentDate)
        Me.gbParameters.Controls.Add(Me.lblContributionDate)
        Me.gbParameters.Location = New System.Drawing.Point(12, 12)
        Me.gbParameters.Name = "gbParameters"
        Me.gbParameters.Size = New System.Drawing.Size(343, 137)
        Me.gbParameters.TabIndex = 5
        Me.gbParameters.TabStop = False
        Me.gbParameters.Text = "Parameters"
        '
        'lblMemberNo
        '
        Me.lblMemberNo.AutoSize = True
        Me.lblMemberNo.Location = New System.Drawing.Point(19, 48)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(64, 14)
        Me.lblMemberNo.TabIndex = 5
        Me.lblMemberNo.Text = "Member No."
        '
        'txtMemberNo
        '
        Me.txtMemberNo.Location = New System.Drawing.Point(108, 45)
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.Size = New System.Drawing.Size(208, 20)
        Me.txtMemberNo.TabIndex = 4
        '
        'txtMemberName
        '
        Me.txtMemberName.Location = New System.Drawing.Point(108, 71)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(208, 20)
        Me.txtMemberName.TabIndex = 3
        '
        'lblMemberName
        '
        Me.lblMemberName.AutoSize = True
        Me.lblMemberName.Location = New System.Drawing.Point(19, 74)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(75, 14)
        Me.lblMemberName.TabIndex = 2
        Me.lblMemberName.Text = "Member Name"
        '
        'dtpLoanPaymentDate
        '
        Me.dtpLoanPaymentDate.CustomFormat = "MMMM, yyyy"
        Me.dtpLoanPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLoanPaymentDate.Location = New System.Drawing.Point(108, 19)
        Me.dtpLoanPaymentDate.Name = "dtpLoanPaymentDate"
        Me.dtpLoanPaymentDate.Size = New System.Drawing.Size(208, 20)
        Me.dtpLoanPaymentDate.TabIndex = 1
        '
        'lblContributionDate
        '
        Me.lblContributionDate.AutoSize = True
        Me.lblContributionDate.Location = New System.Drawing.Point(19, 24)
        Me.lblContributionDate.Name = "lblContributionDate"
        Me.lblContributionDate.Size = New System.Drawing.Size(83, 14)
        Me.lblContributionDate.TabIndex = 0
        Me.lblContributionDate.Text = "Month and Year"
        '
        'frmMemberLoanPaymentGeneration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(502, 162)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.gbParameters)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMemberLoanPaymentGeneration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Loan Payment Generation"
        Me.gbParameters.ResumeLayout(False)
        Me.gbParameters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents gbParameters As System.Windows.Forms.GroupBox
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents dtpLoanPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContributionDate As System.Windows.Forms.Label
End Class
