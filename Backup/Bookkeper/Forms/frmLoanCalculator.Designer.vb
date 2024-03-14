<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanCalculator
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnCalculation = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblNetProceeds = New System.Windows.Forms.Label
        Me.txtNetProceeds = New System.Windows.Forms.TextBox
        Me.lblTotalDeductions = New System.Windows.Forms.Label
        Me.txtTotalLoansGranted = New System.Windows.Forms.TextBox
        Me.lblTotalLoansGranted = New System.Windows.Forms.Label
        Me.txtTotalDeductions = New System.Windows.Forms.TextBox
        Me.txtCISP = New System.Windows.Forms.TextBox
        Me.txtLoanInterest = New System.Windows.Forms.TextBox
        Me.lblCISP = New System.Windows.Forms.Label
        Me.lblLoanInterest = New System.Windows.Forms.Label
        Me.txtServiceFee = New System.Windows.Forms.TextBox
        Me.lblServiceFee = New System.Windows.Forms.Label
        Me.txtInterest = New System.Windows.Forms.TextBox
        Me.txtPrincipal = New System.Windows.Forms.TextBox
        Me.cboTypeId = New System.Windows.Forms.ComboBox
        Me.cboTypeName = New System.Windows.Forms.ComboBox
        Me.lblPrincipal = New System.Windows.Forms.Label
        Me.lblTypeName = New System.Windows.Forms.Label
        Me.lblValueDate = New System.Windows.Forms.Label
        Me.dtpValueDate = New System.Windows.Forms.DateTimePicker
        Me.nudTerm = New System.Windows.Forms.NumericUpDown
        Me.gbxDetails = New System.Windows.Forms.GroupBox
        Me.txtMonthlyPayment = New System.Windows.Forms.TextBox
        Me.lblMonthlyPayment = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTerm = New System.Windows.Forms.Label
        Me.dgvLoanSchedule = New System.Windows.Forms.DataGridView
        Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInterest = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrincipal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudTerm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxDetails.SuspendLayout()
        CType(Me.dgvLoanSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCalculation
        '
        Me.btnCalculation.BackColor = System.Drawing.Color.Green
        Me.btnCalculation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnCalculation.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCalculation.Location = New System.Drawing.Point(120, 187)
        Me.btnCalculation.Name = "btnCalculation"
        Me.btnCalculation.Size = New System.Drawing.Size(173, 30)
        Me.btnCalculation.TabIndex = 29
        Me.btnCalculation.Text = "Calculate"
        Me.btnCalculation.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNetProceeds)
        Me.GroupBox1.Controls.Add(Me.txtNetProceeds)
        Me.GroupBox1.Controls.Add(Me.lblTotalDeductions)
        Me.GroupBox1.Controls.Add(Me.txtTotalLoansGranted)
        Me.GroupBox1.Controls.Add(Me.lblTotalLoansGranted)
        Me.GroupBox1.Controls.Add(Me.txtTotalDeductions)
        Me.GroupBox1.Controls.Add(Me.txtCISP)
        Me.GroupBox1.Controls.Add(Me.txtLoanInterest)
        Me.GroupBox1.Controls.Add(Me.lblCISP)
        Me.GroupBox1.Controls.Add(Me.lblLoanInterest)
        Me.GroupBox1.Controls.Add(Me.txtServiceFee)
        Me.GroupBox1.Controls.Add(Me.lblServiceFee)
        Me.GroupBox1.Location = New System.Drawing.Point(334, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(338, 233)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Loan Deductions"
        '
        'lblNetProceeds
        '
        Me.lblNetProceeds.AutoSize = True
        Me.lblNetProceeds.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetProceeds.Location = New System.Drawing.Point(23, 190)
        Me.lblNetProceeds.Name = "lblNetProceeds"
        Me.lblNetProceeds.Size = New System.Drawing.Size(86, 14)
        Me.lblNetProceeds.TabIndex = 166
        Me.lblNetProceeds.Text = "NET PROCEEDS"
        '
        'txtNetProceeds
        '
        Me.txtNetProceeds.BackColor = System.Drawing.SystemColors.Control
        Me.txtNetProceeds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNetProceeds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNetProceeds.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtNetProceeds.ForeColor = System.Drawing.Color.Blue
        Me.txtNetProceeds.Location = New System.Drawing.Point(167, 184)
        Me.txtNetProceeds.Name = "txtNetProceeds"
        Me.txtNetProceeds.ReadOnly = True
        Me.txtNetProceeds.Size = New System.Drawing.Size(146, 26)
        Me.txtNetProceeds.TabIndex = 167
        Me.txtNetProceeds.Text = "0.00"
        Me.txtNetProceeds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalDeductions
        '
        Me.lblTotalDeductions.AutoSize = True
        Me.lblTotalDeductions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDeductions.Location = New System.Drawing.Point(23, 158)
        Me.lblTotalDeductions.Name = "lblTotalDeductions"
        Me.lblTotalDeductions.Size = New System.Drawing.Size(113, 14)
        Me.lblTotalDeductions.TabIndex = 164
        Me.lblTotalDeductions.Text = "TOTAL DEDUCTIONS"
        '
        'txtTotalLoansGranted
        '
        Me.txtTotalLoansGranted.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalLoansGranted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalLoansGranted.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalLoansGranted.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalLoansGranted.ForeColor = System.Drawing.Color.Black
        Me.txtTotalLoansGranted.Location = New System.Drawing.Point(167, 120)
        Me.txtTotalLoansGranted.Name = "txtTotalLoansGranted"
        Me.txtTotalLoansGranted.ReadOnly = True
        Me.txtTotalLoansGranted.Size = New System.Drawing.Size(146, 26)
        Me.txtTotalLoansGranted.TabIndex = 169
        Me.txtTotalLoansGranted.Text = "0.00"
        Me.txtTotalLoansGranted.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalLoansGranted
        '
        Me.lblTotalLoansGranted.AutoSize = True
        Me.lblTotalLoansGranted.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalLoansGranted.Location = New System.Drawing.Point(23, 126)
        Me.lblTotalLoansGranted.Name = "lblTotalLoansGranted"
        Me.lblTotalLoansGranted.Size = New System.Drawing.Size(96, 14)
        Me.lblTotalLoansGranted.TabIndex = 168
        Me.lblTotalLoansGranted.Text = "TOTAL GRANTED"
        '
        'txtTotalDeductions
        '
        Me.txtTotalDeductions.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalDeductions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDeductions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalDeductions.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtTotalDeductions.ForeColor = System.Drawing.Color.Red
        Me.txtTotalDeductions.Location = New System.Drawing.Point(167, 152)
        Me.txtTotalDeductions.Name = "txtTotalDeductions"
        Me.txtTotalDeductions.ReadOnly = True
        Me.txtTotalDeductions.Size = New System.Drawing.Size(146, 26)
        Me.txtTotalDeductions.TabIndex = 165
        Me.txtTotalDeductions.Text = "0.00"
        Me.txtTotalDeductions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCISP
        '
        Me.txtCISP.BackColor = System.Drawing.SystemColors.Info
        Me.txtCISP.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCISP.ForeColor = System.Drawing.Color.Red
        Me.txtCISP.Location = New System.Drawing.Point(167, 50)
        Me.txtCISP.Name = "txtCISP"
        Me.txtCISP.ReadOnly = True
        Me.txtCISP.Size = New System.Drawing.Size(146, 21)
        Me.txtCISP.TabIndex = 169
        Me.txtCISP.Text = "0.00"
        Me.txtCISP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLoanInterest
        '
        Me.txtLoanInterest.BackColor = System.Drawing.SystemColors.Info
        Me.txtLoanInterest.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanInterest.ForeColor = System.Drawing.Color.Red
        Me.txtLoanInterest.Location = New System.Drawing.Point(167, 23)
        Me.txtLoanInterest.Name = "txtLoanInterest"
        Me.txtLoanInterest.ReadOnly = True
        Me.txtLoanInterest.Size = New System.Drawing.Size(146, 21)
        Me.txtLoanInterest.TabIndex = 165
        Me.txtLoanInterest.Text = "0.00"
        Me.txtLoanInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCISP
        '
        Me.lblCISP.AutoSize = True
        Me.lblCISP.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblCISP.Location = New System.Drawing.Point(23, 51)
        Me.lblCISP.Name = "lblCISP"
        Me.lblCISP.Size = New System.Drawing.Size(29, 14)
        Me.lblCISP.TabIndex = 168
        Me.lblCISP.Text = "CISP"
        '
        'lblLoanInterest
        '
        Me.lblLoanInterest.AutoSize = True
        Me.lblLoanInterest.Location = New System.Drawing.Point(23, 27)
        Me.lblLoanInterest.Name = "lblLoanInterest"
        Me.lblLoanInterest.Size = New System.Drawing.Size(70, 14)
        Me.lblLoanInterest.TabIndex = 164
        Me.lblLoanInterest.Text = "Loan Interest"
        '
        'txtServiceFee
        '
        Me.txtServiceFee.BackColor = System.Drawing.SystemColors.Info
        Me.txtServiceFee.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiceFee.ForeColor = System.Drawing.Color.Red
        Me.txtServiceFee.Location = New System.Drawing.Point(167, 77)
        Me.txtServiceFee.Name = "txtServiceFee"
        Me.txtServiceFee.ReadOnly = True
        Me.txtServiceFee.Size = New System.Drawing.Size(146, 21)
        Me.txtServiceFee.TabIndex = 167
        Me.txtServiceFee.Text = "0.00"
        Me.txtServiceFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblServiceFee
        '
        Me.lblServiceFee.AutoSize = True
        Me.lblServiceFee.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServiceFee.Location = New System.Drawing.Point(23, 78)
        Me.lblServiceFee.Name = "lblServiceFee"
        Me.lblServiceFee.Size = New System.Drawing.Size(65, 14)
        Me.lblServiceFee.TabIndex = 166
        Me.lblServiceFee.Text = "Service Fee"
        '
        'txtInterest
        '
        Me.txtInterest.BackColor = System.Drawing.SystemColors.Info
        Me.txtInterest.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterest.Location = New System.Drawing.Point(120, 133)
        Me.txtInterest.Name = "txtInterest"
        Me.txtInterest.ReadOnly = True
        Me.txtInterest.Size = New System.Drawing.Size(173, 21)
        Me.txtInterest.TabIndex = 19
        Me.txtInterest.Text = "0"
        Me.txtInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPrincipal
        '
        Me.txtPrincipal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipal.Location = New System.Drawing.Point(120, 52)
        Me.txtPrincipal.Name = "txtPrincipal"
        Me.txtPrincipal.Size = New System.Drawing.Size(173, 21)
        Me.txtPrincipal.TabIndex = 17
        Me.txtPrincipal.Text = "0.00"
        Me.txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTypeId
        '
        Me.cboTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeId.FormattingEnabled = True
        Me.cboTypeId.Location = New System.Drawing.Point(274, 23)
        Me.cboTypeId.Name = "cboTypeId"
        Me.cboTypeId.Size = New System.Drawing.Size(19, 22)
        Me.cboTypeId.TabIndex = 69
        Me.cboTypeId.TabStop = False
        Me.cboTypeId.Visible = False
        '
        'cboTypeName
        '
        Me.cboTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeName.DropDownWidth = 250
        Me.cboTypeName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTypeName.FormattingEnabled = True
        Me.cboTypeName.Location = New System.Drawing.Point(120, 23)
        Me.cboTypeName.Name = "cboTypeName"
        Me.cboTypeName.Size = New System.Drawing.Size(173, 23)
        Me.cboTypeName.TabIndex = 68
        '
        'lblPrincipal
        '
        Me.lblPrincipal.AutoSize = True
        Me.lblPrincipal.Location = New System.Drawing.Point(22, 56)
        Me.lblPrincipal.Name = "lblPrincipal"
        Me.lblPrincipal.Size = New System.Drawing.Size(47, 14)
        Me.lblPrincipal.TabIndex = 71
        Me.lblPrincipal.Text = "Principal"
        '
        'lblTypeName
        '
        Me.lblTypeName.AutoSize = True
        Me.lblTypeName.Location = New System.Drawing.Point(22, 27)
        Me.lblTypeName.Name = "lblTypeName"
        Me.lblTypeName.Size = New System.Drawing.Size(57, 14)
        Me.lblTypeName.TabIndex = 72
        Me.lblTypeName.Text = "Loan Type"
        '
        'lblValueDate
        '
        Me.lblValueDate.AutoSize = True
        Me.lblValueDate.Location = New System.Drawing.Point(22, 81)
        Me.lblValueDate.Name = "lblValueDate"
        Me.lblValueDate.Size = New System.Drawing.Size(59, 14)
        Me.lblValueDate.TabIndex = 73
        Me.lblValueDate.Text = "Value Date"
        '
        'dtpValueDate
        '
        Me.dtpValueDate.Checked = False
        Me.dtpValueDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpValueDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpValueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpValueDate.Location = New System.Drawing.Point(120, 79)
        Me.dtpValueDate.Name = "dtpValueDate"
        Me.dtpValueDate.ShowCheckBox = True
        Me.dtpValueDate.Size = New System.Drawing.Size(173, 21)
        Me.dtpValueDate.TabIndex = 161
        Me.dtpValueDate.Tag = "0"
        '
        'nudTerm
        '
        Me.nudTerm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTerm.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudTerm.Location = New System.Drawing.Point(120, 106)
        Me.nudTerm.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.nudTerm.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudTerm.Name = "nudTerm"
        Me.nudTerm.Size = New System.Drawing.Size(173, 21)
        Me.nudTerm.TabIndex = 162
        Me.nudTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudTerm.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gbxDetails
        '
        Me.gbxDetails.Controls.Add(Me.txtMonthlyPayment)
        Me.gbxDetails.Controls.Add(Me.lblMonthlyPayment)
        Me.gbxDetails.Controls.Add(Me.Label1)
        Me.gbxDetails.Controls.Add(Me.btnCalculation)
        Me.gbxDetails.Controls.Add(Me.lblTerm)
        Me.gbxDetails.Controls.Add(Me.lblTypeName)
        Me.gbxDetails.Controls.Add(Me.nudTerm)
        Me.gbxDetails.Controls.Add(Me.txtPrincipal)
        Me.gbxDetails.Controls.Add(Me.dtpValueDate)
        Me.gbxDetails.Controls.Add(Me.txtInterest)
        Me.gbxDetails.Controls.Add(Me.cboTypeName)
        Me.gbxDetails.Controls.Add(Me.cboTypeId)
        Me.gbxDetails.Controls.Add(Me.lblPrincipal)
        Me.gbxDetails.Controls.Add(Me.lblValueDate)
        Me.gbxDetails.Location = New System.Drawing.Point(12, 12)
        Me.gbxDetails.Name = "gbxDetails"
        Me.gbxDetails.Size = New System.Drawing.Size(316, 233)
        Me.gbxDetails.TabIndex = 163
        Me.gbxDetails.TabStop = False
        Me.gbxDetails.Text = "Loan Information"
        '
        'txtMonthlyPayment
        '
        Me.txtMonthlyPayment.BackColor = System.Drawing.SystemColors.Info
        Me.txtMonthlyPayment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthlyPayment.Location = New System.Drawing.Point(120, 160)
        Me.txtMonthlyPayment.Name = "txtMonthlyPayment"
        Me.txtMonthlyPayment.ReadOnly = True
        Me.txtMonthlyPayment.Size = New System.Drawing.Size(173, 21)
        Me.txtMonthlyPayment.TabIndex = 166
        Me.txtMonthlyPayment.Text = "0.00"
        Me.txtMonthlyPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMonthlyPayment
        '
        Me.lblMonthlyPayment.AutoSize = True
        Me.lblMonthlyPayment.Location = New System.Drawing.Point(22, 164)
        Me.lblMonthlyPayment.Name = "lblMonthlyPayment"
        Me.lblMonthlyPayment.Size = New System.Drawing.Size(88, 14)
        Me.lblMonthlyPayment.TabIndex = 165
        Me.lblMonthlyPayment.Text = "Monthly Payment"
        Me.lblMonthlyPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 14)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Interest Rate (%)"
        '
        'lblTerm
        '
        Me.lblTerm.AutoSize = True
        Me.lblTerm.Location = New System.Drawing.Point(22, 109)
        Me.lblTerm.Name = "lblTerm"
        Me.lblTerm.Size = New System.Drawing.Size(79, 14)
        Me.lblTerm.TabIndex = 163
        Me.lblTerm.Text = "Term in Months"
        '
        'dgvLoanSchedule
        '
        Me.dgvLoanSchedule.AllowUserToAddRows = False
        Me.dgvLoanSchedule.AllowUserToDeleteRows = False
        Me.dgvLoanSchedule.AllowUserToOrderColumns = True
        Me.dgvLoanSchedule.AllowUserToResizeRows = False
        Me.dgvLoanSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLoanSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDate, Me.colInterest, Me.colPrincipal, Me.colTotal})
        Me.dgvLoanSchedule.Location = New System.Drawing.Point(12, 251)
        Me.dgvLoanSchedule.Name = "dgvLoanSchedule"
        Me.dgvLoanSchedule.Size = New System.Drawing.Size(660, 252)
        Me.dgvLoanSchedule.TabIndex = 164
        '
        'colDate
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDate.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDate.HeaderText = "SCHEDULE DATE"
        Me.colDate.Name = "colDate"
        Me.colDate.ReadOnly = True
        Me.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colDate.Width = 140
        '
        'colInterest
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colInterest.DefaultCellStyle = DataGridViewCellStyle6
        Me.colInterest.HeaderText = "INTEREST PAYMENT"
        Me.colInterest.Name = "colInterest"
        Me.colInterest.ReadOnly = True
        Me.colInterest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colInterest.Width = 140
        '
        'colPrincipal
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colPrincipal.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPrincipal.HeaderText = "PRINCIPAL PAYMENT"
        Me.colPrincipal.Name = "colPrincipal"
        Me.colPrincipal.ReadOnly = True
        Me.colPrincipal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPrincipal.Width = 150
        '
        'colTotal
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colTotal.DefaultCellStyle = DataGridViewCellStyle8
        Me.colTotal.HeaderText = "TOTAL PAYMENT"
        Me.colTotal.Name = "colTotal"
        Me.colTotal.ReadOnly = True
        Me.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTotal.Width = 150
        '
        'frmLoanCalculator
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 516)
        Me.Controls.Add(Me.dgvLoanSchedule)
        Me.Controls.Add(Me.gbxDetails)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoanCalculator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Calculator"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudTerm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxDetails.ResumeLayout(False)
        Me.gbxDetails.PerformLayout()
        CType(Me.dgvLoanSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCalculation As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInterest As System.Windows.Forms.TextBox
    Friend WithEvents txtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents cboTypeId As System.Windows.Forms.ComboBox
    Friend WithEvents cboTypeName As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrincipal As System.Windows.Forms.Label
    Friend WithEvents lblTypeName As System.Windows.Forms.Label
    Friend WithEvents lblValueDate As System.Windows.Forms.Label
    Friend WithEvents dtpValueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents nudTerm As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbxDetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTerm As System.Windows.Forms.Label
    Friend WithEvents txtCISP As System.Windows.Forms.TextBox
    Friend WithEvents txtLoanInterest As System.Windows.Forms.TextBox
    Friend WithEvents lblCISP As System.Windows.Forms.Label
    Friend WithEvents lblLoanInterest As System.Windows.Forms.Label
    Friend WithEvents txtServiceFee As System.Windows.Forms.TextBox
    Friend WithEvents lblServiceFee As System.Windows.Forms.Label
    Friend WithEvents txtMonthlyPayment As System.Windows.Forms.TextBox
    Friend WithEvents lblMonthlyPayment As System.Windows.Forms.Label
    Friend WithEvents lblNetProceeds As System.Windows.Forms.Label
    Friend WithEvents txtNetProceeds As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDeductions As System.Windows.Forms.Label
    Friend WithEvents txtTotalLoansGranted As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalLoansGranted As System.Windows.Forms.Label
    Friend WithEvents txtTotalDeductions As System.Windows.Forms.TextBox
    Friend WithEvents dgvLoanSchedule As System.Windows.Forms.DataGridView
    Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInterest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrincipal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
