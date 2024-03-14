<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanPaymentUpdater
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
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.grbOthers = New System.Windows.Forms.GroupBox
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.btnPreview = New System.Windows.Forms.Button
        Me.grbDetails = New System.Windows.Forms.GroupBox
        Me.dgvMemberLoanPayment = New System.Windows.Forms.DataGridView
        Me.colMemberId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrincipal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotalBalance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMonthlyPayment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanInterest = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanDt = New Common.CalendarColumn
        Me.colMaturityDt = New Common.CalendarColumn
        Me.colTerm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colclosed = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colCloseDt = New Common.CalendarColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbParameters = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboDeductionType = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTotalInterestPaid = New System.Windows.Forms.TextBox
        Me.txtTInterest = New System.Windows.Forms.TextBox
        Me.lblTotalLoanInterest = New System.Windows.Forms.Label
        Me.chkAllLoanType = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.clbLoanTypeId = New System.Windows.Forms.CheckedListBox
        Me.clbLoanType = New System.Windows.Forms.CheckedListBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTotalAmountPaid = New System.Windows.Forms.TextBox
        Me.txtCurMemberName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTotalMembers = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTPayment = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkClose = New System.Windows.Forms.CheckBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.lblContributionDate = New System.Windows.Forms.Label
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalendarColumn1 = New Common.CalendarColumn
        Me.CalendarColumn2 = New Common.CalendarColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblTotalRecord = New System.Windows.Forms.Label
        Me.grbOthers.SuspendLayout()
        Me.grbDetails.SuspendLayout()
        CType(Me.dgvMemberLoanPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbOthers
        '
        Me.grbOthers.Controls.Add(Me.btnGenerate)
        Me.grbOthers.Controls.Add(Me.btnPreview)
        Me.grbOthers.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grbOthers.Location = New System.Drawing.Point(3, 525)
        Me.grbOthers.Name = "grbOthers"
        Me.grbOthers.Size = New System.Drawing.Size(340, 59)
        Me.grbOthers.TabIndex = 6
        Me.grbOthers.TabStop = False
        '
        'btnGenerate
        '
        Me.btnGenerate.BackColor = System.Drawing.Color.Green
        Me.btnGenerate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnGenerate.ForeColor = System.Drawing.SystemColors.Control
        Me.btnGenerate.Location = New System.Drawing.Point(19, 19)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(148, 28)
        Me.btnGenerate.TabIndex = 13
        Me.btnGenerate.Text = "Generate Payment"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.Green
        Me.btnPreview.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnPreview.ForeColor = System.Drawing.SystemColors.Control
        Me.btnPreview.Location = New System.Drawing.Point(170, 19)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(148, 28)
        Me.btnPreview.TabIndex = 14
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'grbDetails
        '
        Me.grbDetails.Controls.Add(Me.dgvMemberLoanPayment)
        Me.grbDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grbDetails.Location = New System.Drawing.Point(346, 0)
        Me.grbDetails.Name = "grbDetails"
        Me.grbDetails.Size = New System.Drawing.Size(543, 587)
        Me.grbDetails.TabIndex = 5
        Me.grbDetails.TabStop = False
        Me.grbDetails.Text = "Loan Payment Details"
        '
        'dgvMemberLoanPayment
        '
        Me.dgvMemberLoanPayment.AllowUserToAddRows = False
        Me.dgvMemberLoanPayment.AllowUserToDeleteRows = False
        Me.dgvMemberLoanPayment.AllowUserToResizeRows = False
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMemberLoanPayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle23
        Me.dgvMemberLoanPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMemberLoanPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMemberId, Me.colMemberNo, Me.colMemberName, Me.colLoanId, Me.colLoanNo, Me.colLoanType, Me.colPrincipal, Me.colTotalBalance, Me.colMonthlyPayment, Me.colAmountPaid, Me.colLoanInterest, Me.colLoanDt, Me.colMaturityDt, Me.colTerm, Me.Column1, Me.Column2, Me.colclosed, Me.colCloseDt, Me.colStatus})
        Me.dgvMemberLoanPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMemberLoanPayment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvMemberLoanPayment.Location = New System.Drawing.Point(3, 16)
        Me.dgvMemberLoanPayment.Name = "dgvMemberLoanPayment"
        Me.dgvMemberLoanPayment.RowHeadersWidth = 51
        Me.dgvMemberLoanPayment.Size = New System.Drawing.Size(537, 568)
        Me.dgvMemberLoanPayment.TabIndex = 0
        '
        'colMemberId
        '
        Me.colMemberId.Frozen = True
        Me.colMemberId.HeaderText = "MID"
        Me.colMemberId.Name = "colMemberId"
        Me.colMemberId.ReadOnly = True
        Me.colMemberId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMemberId.Visible = False
        '
        'colMemberNo
        '
        Me.colMemberNo.Frozen = True
        Me.colMemberNo.HeaderText = "MNo."
        Me.colMemberNo.Name = "colMemberNo"
        Me.colMemberNo.ReadOnly = True
        Me.colMemberNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMemberNo.Visible = False
        Me.colMemberNo.Width = 85
        '
        'colMemberName
        '
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.LightSkyBlue
        Me.colMemberName.DefaultCellStyle = DataGridViewCellStyle24
        Me.colMemberName.Frozen = True
        Me.colMemberName.HeaderText = "MEMBER NAME"
        Me.colMemberName.Name = "colMemberName"
        Me.colMemberName.ReadOnly = True
        Me.colMemberName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMemberName.Width = 150
        '
        'colLoanId
        '
        Me.colLoanId.Frozen = True
        Me.colLoanId.HeaderText = "LOAN ID"
        Me.colLoanId.Name = "colLoanId"
        Me.colLoanId.ReadOnly = True
        Me.colLoanId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLoanId.Visible = False
        Me.colLoanId.Width = 150
        '
        'colLoanNo
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.NullValue = Nothing
        Me.colLoanNo.DefaultCellStyle = DataGridViewCellStyle25
        Me.colLoanNo.Frozen = True
        Me.colLoanNo.HeaderText = "LOAN No."
        Me.colLoanNo.Name = "colLoanNo"
        Me.colLoanNo.ReadOnly = True
        Me.colLoanNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLoanNo.Width = 75
        '
        'colLoanType
        '
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colLoanType.DefaultCellStyle = DataGridViewCellStyle26
        Me.colLoanType.Frozen = True
        Me.colLoanType.HeaderText = "TYPE OF LOAN"
        Me.colLoanType.Name = "colLoanType"
        Me.colLoanType.ReadOnly = True
        Me.colLoanType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLoanType.Width = 150
        '
        'colPrincipal
        '
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.Format = "N2"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.colPrincipal.DefaultCellStyle = DataGridViewCellStyle27
        Me.colPrincipal.Frozen = True
        Me.colPrincipal.HeaderText = "PRINCIPAL"
        Me.colPrincipal.Name = "colPrincipal"
        Me.colPrincipal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colTotalBalance
        '
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle28.Format = "N2"
        DataGridViewCellStyle28.NullValue = Nothing
        Me.colTotalBalance.DefaultCellStyle = DataGridViewCellStyle28
        Me.colTotalBalance.Frozen = True
        Me.colTotalBalance.HeaderText = "OUTSTANDING BALANCE"
        Me.colTotalBalance.Name = "colTotalBalance"
        Me.colTotalBalance.ReadOnly = True
        Me.colTotalBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colMonthlyPayment
        '
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.Format = "N2"
        DataGridViewCellStyle29.NullValue = Nothing
        Me.colMonthlyPayment.DefaultCellStyle = DataGridViewCellStyle29
        Me.colMonthlyPayment.HeaderText = "MONTHLY PAYMENT"
        Me.colMonthlyPayment.Name = "colMonthlyPayment"
        Me.colMonthlyPayment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colAmountPaid
        '
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle30.Format = "N2"
        DataGridViewCellStyle30.NullValue = Nothing
        Me.colAmountPaid.DefaultCellStyle = DataGridViewCellStyle30
        Me.colAmountPaid.HeaderText = "TOTAL AMOUNT PAID"
        Me.colAmountPaid.Name = "colAmountPaid"
        Me.colAmountPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colLoanInterest
        '
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle31.Format = "N2"
        DataGridViewCellStyle31.NullValue = Nothing
        Me.colLoanInterest.DefaultCellStyle = DataGridViewCellStyle31
        Me.colLoanInterest.HeaderText = "LOAN INTEREST"
        Me.colLoanInterest.Name = "colLoanInterest"
        Me.colLoanInterest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colLoanDt
        '
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle32.NullValue = Nothing
        Me.colLoanDt.DefaultCellStyle = DataGridViewCellStyle32
        Me.colLoanDt.HeaderText = "LOAN DATE"
        Me.colLoanDt.Name = "colLoanDt"
        Me.colLoanDt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLoanDt.Width = 75
        '
        'colMaturityDt
        '
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colMaturityDt.DefaultCellStyle = DataGridViewCellStyle33
        Me.colMaturityDt.HeaderText = "MATURITY DATE"
        Me.colMaturityDt.Name = "colMaturityDt"
        Me.colMaturityDt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colTerm
        '
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle34.Format = "N0"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.colTerm.DefaultCellStyle = DataGridViewCellStyle34
        Me.colTerm.HeaderText = "TERM"
        Me.colTerm.Name = "colTerm"
        Me.colTerm.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTerm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTerm.Width = 50
        '
        'Column1
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle35
        Me.Column1.HeaderText = "VOUCHER NO"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle36
        Me.Column2.HeaderText = "CHECK NO"
        Me.Column2.Name = "Column2"
        '
        'colclosed
        '
        Me.colclosed.HeaderText = "CLOSED"
        Me.colclosed.Name = "colclosed"
        Me.colclosed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colCloseDt
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCloseDt.DefaultCellStyle = DataGridViewCellStyle37
        Me.colCloseDt.HeaderText = "CLOSE DATE"
        Me.colCloseDt.Name = "colCloseDt"
        Me.colCloseDt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "STATUS"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colStatus.Width = 200
        '
        'gbParameters
        '
        Me.gbParameters.Controls.Add(Me.lblTotalRecord)
        Me.gbParameters.Controls.Add(Me.lblDate)
        Me.gbParameters.Controls.Add(Me.Label10)
        Me.gbParameters.Controls.Add(Me.txtTotal)
        Me.gbParameters.Controls.Add(Me.Label8)
        Me.gbParameters.Controls.Add(Me.cboDeductionType)
        Me.gbParameters.Controls.Add(Me.Label9)
        Me.gbParameters.Controls.Add(Me.txtTotalInterestPaid)
        Me.gbParameters.Controls.Add(Me.txtTInterest)
        Me.gbParameters.Controls.Add(Me.lblTotalLoanInterest)
        Me.gbParameters.Controls.Add(Me.chkAllLoanType)
        Me.gbParameters.Controls.Add(Me.Label7)
        Me.gbParameters.Controls.Add(Me.clbLoanTypeId)
        Me.gbParameters.Controls.Add(Me.clbLoanType)
        Me.gbParameters.Controls.Add(Me.Label6)
        Me.gbParameters.Controls.Add(Me.Label5)
        Me.gbParameters.Controls.Add(Me.txtTotalAmountPaid)
        Me.gbParameters.Controls.Add(Me.txtCurMemberName)
        Me.gbParameters.Controls.Add(Me.Label4)
        Me.gbParameters.Controls.Add(Me.Label3)
        Me.gbParameters.Controls.Add(Me.txtTotalMembers)
        Me.gbParameters.Controls.Add(Me.Label2)
        Me.gbParameters.Controls.Add(Me.txtTPayment)
        Me.gbParameters.Controls.Add(Me.Label1)
        Me.gbParameters.Controls.Add(Me.chkClose)
        Me.gbParameters.Controls.Add(Me.grbOthers)
        Me.gbParameters.Controls.Add(Me.btnClose)
        Me.gbParameters.Controls.Add(Me.btnSearch)
        Me.gbParameters.Controls.Add(Me.lblMemberNo)
        Me.gbParameters.Controls.Add(Me.txtMemberNo)
        Me.gbParameters.Controls.Add(Me.txtMemberName)
        Me.gbParameters.Controls.Add(Me.lblMemberName)
        Me.gbParameters.Controls.Add(Me.dtpPaymentDate)
        Me.gbParameters.Controls.Add(Me.lblContributionDate)
        Me.gbParameters.Dock = System.Windows.Forms.DockStyle.Left
        Me.gbParameters.Location = New System.Drawing.Point(0, 0)
        Me.gbParameters.Name = "gbParameters"
        Me.gbParameters.Size = New System.Drawing.Size(346, 587)
        Me.gbParameters.TabIndex = 4
        Me.gbParameters.TabStop = False
        Me.gbParameters.Text = "Filter Options"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(90, 513)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 14)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "TOTAL"
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotal.Location = New System.Drawing.Point(136, 510)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(185, 20)
        Me.txtTotal.TabIndex = 45
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(19, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 14)
        Me.Label8.TabIndex = 44
        Me.Label8.Text = "Deduction Type"
        '
        'cboDeductionType
        '
        Me.cboDeductionType.FormattingEnabled = True
        Me.cboDeductionType.Items.AddRange(New Object() {"SALARY DEDUCTION", "PERA DEDUCTION"})
        Me.cboDeductionType.Location = New System.Drawing.Point(120, 97)
        Me.cboDeductionType.Name = "cboDeductionType"
        Me.cboDeductionType.Size = New System.Drawing.Size(201, 21)
        Me.cboDeductionType.TabIndex = 43
        Me.cboDeductionType.Text = "SALARY DEDUCTION"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 486)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 14)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Total Interest Paid"
        '
        'txtTotalInterestPaid
        '
        Me.txtTotalInterestPaid.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTotalInterestPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalInterestPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalInterestPaid.Location = New System.Drawing.Point(136, 484)
        Me.txtTotalInterestPaid.Name = "txtTotalInterestPaid"
        Me.txtTotalInterestPaid.ReadOnly = True
        Me.txtTotalInterestPaid.Size = New System.Drawing.Size(185, 20)
        Me.txtTotalInterestPaid.TabIndex = 41
        Me.txtTotalInterestPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTInterest
        '
        Me.txtTInterest.BackColor = System.Drawing.SystemColors.Info
        Me.txtTInterest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTInterest.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTInterest.Location = New System.Drawing.Point(157, 355)
        Me.txtTInterest.Name = "txtTInterest"
        Me.txtTInterest.ReadOnly = True
        Me.txtTInterest.Size = New System.Drawing.Size(164, 20)
        Me.txtTInterest.TabIndex = 40
        Me.txtTInterest.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalLoanInterest
        '
        Me.lblTotalLoanInterest.AutoSize = True
        Me.lblTotalLoanInterest.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblTotalLoanInterest.Location = New System.Drawing.Point(19, 358)
        Me.lblTotalLoanInterest.Name = "lblTotalLoanInterest"
        Me.lblTotalLoanInterest.Size = New System.Drawing.Size(110, 14)
        Me.lblTotalLoanInterest.TabIndex = 39
        Me.lblTotalLoanInterest.Text = "Total Loan Interest"
        '
        'chkAllLoanType
        '
        Me.chkAllLoanType.AutoSize = True
        Me.chkAllLoanType.Location = New System.Drawing.Point(22, 143)
        Me.chkAllLoanType.Name = "chkAllLoanType"
        Me.chkAllLoanType.Size = New System.Drawing.Size(70, 17)
        Me.chkAllLoanType.TabIndex = 37
        Me.chkAllLoanType.Text = "Select All"
        Me.chkAllLoanType.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(19, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 14)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Loan Type"
        '
        'clbLoanTypeId
        '
        Me.clbLoanTypeId.CheckOnClick = True
        Me.clbLoanTypeId.FormattingEnabled = True
        Me.clbLoanTypeId.Location = New System.Drawing.Point(302, 239)
        Me.clbLoanTypeId.Name = "clbLoanTypeId"
        Me.clbLoanTypeId.Size = New System.Drawing.Size(19, 19)
        Me.clbLoanTypeId.TabIndex = 35
        Me.clbLoanTypeId.Visible = False
        '
        'clbLoanType
        '
        Me.clbLoanType.CheckOnClick = True
        Me.clbLoanType.FormattingEnabled = True
        Me.clbLoanType.Location = New System.Drawing.Point(120, 126)
        Me.clbLoanType.Name = "clbLoanType"
        Me.clbLoanType.Size = New System.Drawing.Size(201, 109)
        Me.clbLoanType.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label6.Location = New System.Drawing.Point(19, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(132, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Total Payment as of "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 460)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 14)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Total Loan Paid"
        '
        'txtTotalAmountPaid
        '
        Me.txtTotalAmountPaid.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTotalAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmountPaid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalAmountPaid.Location = New System.Drawing.Point(136, 458)
        Me.txtTotalAmountPaid.Name = "txtTotalAmountPaid"
        Me.txtTotalAmountPaid.ReadOnly = True
        Me.txtTotalAmountPaid.Size = New System.Drawing.Size(185, 20)
        Me.txtTotalAmountPaid.TabIndex = 25
        Me.txtTotalAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurMemberName
        '
        Me.txtCurMemberName.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtCurMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCurMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtCurMemberName.Location = New System.Drawing.Point(136, 432)
        Me.txtCurMemberName.Name = "txtCurMemberName"
        Me.txtCurMemberName.ReadOnly = True
        Me.txtCurMemberName.Size = New System.Drawing.Size(185, 20)
        Me.txtCurMemberName.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 434)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 14)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Member Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkCyan
        Me.Label3.Location = New System.Drawing.Point(19, 411)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Current Member Information"
        '
        'txtTotalMembers
        '
        Me.txtTotalMembers.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtTotalMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalMembers.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalMembers.Location = New System.Drawing.Point(157, 381)
        Me.txtTotalMembers.Name = "txtTotalMembers"
        Me.txtTotalMembers.ReadOnly = True
        Me.txtTotalMembers.Size = New System.Drawing.Size(164, 20)
        Me.txtTotalMembers.TabIndex = 21
        Me.txtTotalMembers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(68, 384)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 14)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "GRAND TOTAL"
        '
        'txtTPayment
        '
        Me.txtTPayment.BackColor = System.Drawing.SystemColors.Info
        Me.txtTPayment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTPayment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTPayment.Location = New System.Drawing.Point(157, 329)
        Me.txtTPayment.Name = "txtTPayment"
        Me.txtTPayment.ReadOnly = True
        Me.txtTPayment.Size = New System.Drawing.Size(164, 20)
        Me.txtTPayment.TabIndex = 19
        Me.txtTPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(19, 332)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 14)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Total Loan Payment"
        '
        'chkClose
        '
        Me.chkClose.AutoSize = True
        Me.chkClose.Checked = True
        Me.chkClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClose.Location = New System.Drawing.Point(120, 241)
        Me.chkClose.Name = "chkClose"
        Me.chkClose.Size = New System.Drawing.Size(110, 17)
        Me.chkClose.TabIndex = 17
        Me.chkClose.Text = "With Closed Loan"
        Me.chkClose.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(223, 265)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(98, 28)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.Control
        Me.btnSearch.Location = New System.Drawing.Point(120, 265)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(98, 28)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'lblMemberNo
        '
        Me.lblMemberNo.AutoSize = True
        Me.lblMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMemberNo.Location = New System.Drawing.Point(19, 48)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(74, 14)
        Me.lblMemberNo.TabIndex = 5
        Me.lblMemberNo.Text = "Member No."
        '
        'txtMemberNo
        '
        Me.txtMemberNo.Location = New System.Drawing.Point(120, 45)
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.Size = New System.Drawing.Size(201, 20)
        Me.txtMemberNo.TabIndex = 4
        '
        'txtMemberName
        '
        Me.txtMemberName.Location = New System.Drawing.Point(120, 71)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(201, 20)
        Me.txtMemberName.TabIndex = 3
        '
        'lblMemberName
        '
        Me.lblMemberName.AutoSize = True
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMemberName.Location = New System.Drawing.Point(19, 74)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(88, 14)
        Me.lblMemberName.TabIndex = 2
        Me.lblMemberName.Text = "Member Name"
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.CustomFormat = "MMMM yyyy"
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDate.Location = New System.Drawing.Point(120, 19)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.ShowCheckBox = True
        Me.dtpPaymentDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpPaymentDate.TabIndex = 1
        '
        'lblContributionDate
        '
        Me.lblContributionDate.AutoSize = True
        Me.lblContributionDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblContributionDate.Location = New System.Drawing.Point(19, 24)
        Me.lblContributionDate.Name = "lblContributionDate"
        Me.lblContributionDate.Size = New System.Drawing.Size(92, 14)
        Me.lblContributionDate.TabIndex = 0
        Me.lblContributionDate.Text = "Month and Year"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "MNo."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "MEMBER NAME"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "LOAN ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'DataGridViewTextBoxColumn5
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle38.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle38
        Me.DataGridViewTextBoxColumn5.HeaderText = "LOAN No."
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn6
        '
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle39
        Me.DataGridViewTextBoxColumn6.HeaderText = "TYPE OF LOAN"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.Width = 150
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "N2"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle40
        Me.DataGridViewTextBoxColumn7.HeaderText = "TOTAL BALANCE"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.Width = 125
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle41.Format = "N2"
        DataGridViewCellStyle41.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle41
        Me.DataGridViewTextBoxColumn8.HeaderText = "MONTHLY PAYMENT"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N2"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle42
        Me.DataGridViewTextBoxColumn9.HeaderText = "AMOUNT PAID"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'CalendarColumn1
        '
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle43.NullValue = Nothing
        Me.CalendarColumn1.DefaultCellStyle = DataGridViewCellStyle43
        Me.CalendarColumn1.HeaderText = "LOAN DATE"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'CalendarColumn2
        '
        Me.CalendarColumn2.HeaderText = "MATURITY DATE"
        Me.CalendarColumn2.Name = "CalendarColumn2"
        Me.CalendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn10
        '
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle44.Format = "N0"
        DataGridViewCellStyle44.NullValue = Nothing
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle44
        Me.DataGridViewTextBoxColumn10.HeaderText = "TERM"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "STATUS"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 200
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.DarkCyan
        Me.lblDate.Location = New System.Drawing.Point(133, 307)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(79, 13)
        Me.lblDate.TabIndex = 48
        Me.lblDate.Text = "January 2016"
        '
        'lblTotalRecord
        '
        Me.lblTotalRecord.AutoSize = True
        Me.lblTotalRecord.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRecord.ForeColor = System.Drawing.Color.DarkCyan
        Me.lblTotalRecord.Location = New System.Drawing.Point(208, 307)
        Me.lblTotalRecord.Name = "lblTotalRecord"
        Me.lblTotalRecord.Size = New System.Drawing.Size(11, 13)
        Me.lblTotalRecord.TabIndex = 49
        Me.lblTotalRecord.Text = "-"
        '
        'frmLoanPaymentUpdater
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(889, 587)
        Me.Controls.Add(Me.grbDetails)
        Me.Controls.Add(Me.gbParameters)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoanPaymentUpdater"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Loan Payment Updater"
        Me.grbOthers.ResumeLayout(False)
        Me.grbDetails.ResumeLayout(False)
        CType(Me.dgvMemberLoanPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbParameters.ResumeLayout(False)
        Me.gbParameters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbOthers As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents grbDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dgvMemberLoanPayment As System.Windows.Forms.DataGridView
    Friend WithEvents gbParameters As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContributionDate As System.Windows.Forms.Label
    Friend WithEvents chkClose As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTPayment As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalMembers As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmountPaid As System.Windows.Forms.TextBox
    Friend WithEvents txtCurMemberName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As Common.CalendarColumn
    Friend WithEvents CalendarColumn2 As Common.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clbLoanType As System.Windows.Forms.CheckedListBox
    Friend WithEvents clbLoanTypeId As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkAllLoanType As System.Windows.Forms.CheckBox
    Friend WithEvents txtTInterest As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalLoanInterest As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTotalInterestPaid As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboDeductionType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents colMemberId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrincipal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonthlyPayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanInterest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanDt As Common.CalendarColumn
    Friend WithEvents colMaturityDt As Common.CalendarColumn
    Friend WithEvents colTerm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colclosed As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCloseDt As Common.CalendarColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTotalRecord As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
End Class
