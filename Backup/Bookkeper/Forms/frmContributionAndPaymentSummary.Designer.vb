<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContributionAndPaymentSummary
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
        Me.gbParameters = New System.Windows.Forms.GroupBox
        Me.dtpLoanPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.lblContributionDate = New System.Windows.Forms.Label
        Me.gbParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(361, 22)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(131, 40)
        Me.btnPreview.TabIndex = 10
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'gbParameters
        '
        Me.gbParameters.Controls.Add(Me.dtpLoanPaymentDate)
        Me.gbParameters.Controls.Add(Me.lblContributionDate)
        Me.gbParameters.Location = New System.Drawing.Point(12, 12)
        Me.gbParameters.Name = "gbParameters"
        Me.gbParameters.Size = New System.Drawing.Size(343, 57)
        Me.gbParameters.TabIndex = 9
        Me.gbParameters.TabStop = False
        Me.gbParameters.Text = "Parameters"
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
        Me.lblContributionDate.Size = New System.Drawing.Size(83, 13)
        Me.lblContributionDate.TabIndex = 0
        Me.lblContributionDate.Text = "Month and Year"
        '
        'frmContributionAndPaymentSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(503, 81)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.gbParameters)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContributionAndPaymentSummary"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contribution And Payment Summary"
        Me.gbParameters.ResumeLayout(False)
        Me.gbParameters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents gbParameters As System.Windows.Forms.GroupBox
    Friend WithEvents dtpLoanPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContributionDate As System.Windows.Forms.Label
End Class
