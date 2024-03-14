<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentLoanAndContribution
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPaymentLoanAndContribution))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmnsPayment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartORNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ClearCollectibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadLoanCollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintOfficialReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.grpPaymentDetails = New System.Windows.Forms.GroupBox
        Me.txtCollectorId = New System.Windows.Forms.TextBox
        Me.txtAmountChange = New System.Windows.Forms.TextBox
        Me.chkSaveCredit = New System.Windows.Forms.CheckBox
        Me.txtTaxCreditAvailable = New System.Windows.Forms.TextBox
        Me.txtTaxCreditAmount = New System.Windows.Forms.TextBox
        Me.cboBankName = New System.Windows.Forms.ComboBox
        Me.cboBankId = New System.Windows.Forms.ComboBox
        Me.chkDeleteFl = New System.Windows.Forms.CheckBox
        Me.pnlTotalPayable = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtTotalAmountDue = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTotalContributionDue = New System.Windows.Forms.TextBox
        Me.lblTotalAmountPayable = New System.Windows.Forms.Label
        Me.txtTotalAmountPayable = New System.Windows.Forms.TextBox
        Me.lblTotalAmountDue = New System.Windows.Forms.Label
        Me.txtTotalLoanDue = New System.Windows.Forms.TextBox
        Me.grpPaymentType = New System.Windows.Forms.GroupBox
        Me.rbCashCheque = New System.Windows.Forms.RadioButton
        Me.rbCheque = New System.Windows.Forms.RadioButton
        Me.rbCash = New System.Windows.Forms.RadioButton
        Me.lblORAmount = New System.Windows.Forms.Label
        Me.dgvCheckDetails = New System.Windows.Forms.DataGridView
        Me.colBankId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBankName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckDate = New Common.CalendarColumn
        Me.colCheckRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtCashAmount = New System.Windows.Forms.TextBox
        Me.txtORAmount = New System.Windows.Forms.TextBox
        Me.txtCollectorName = New System.Windows.Forms.TextBox
        Me.lblCashAmount = New System.Windows.Forms.Label
        Me.lblCollectorName = New System.Windows.Forms.Label
        Me.lblCheckAmount = New System.Windows.Forms.Label
        Me.chkOnlineFl = New System.Windows.Forms.CheckBox
        Me.txtCheckAmount = New System.Windows.Forms.TextBox
        Me.chkBillingFl = New System.Windows.Forms.CheckBox
        Me.txtRefId = New System.Windows.Forms.TextBox
        Me.chkCancelFl = New System.Windows.Forms.CheckBox
        Me.lblAccountMemoRemarks = New System.Windows.Forms.Label
        Me.txtPaymentRemarks = New System.Windows.Forms.TextBox
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.txtORNo = New System.Windows.Forms.TextBox
        Me.lblORDt = New System.Windows.Forms.Label
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.dtpORDt = New System.Windows.Forms.DateTimePicker
        Me.lblORNo = New System.Windows.Forms.Label
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.tabCollectibleRecords = New System.Windows.Forms.TabControl
        Me.tabLoanRecords = New System.Windows.Forms.TabPage
        Me.cboTypeName = New System.Windows.Forms.ComboBox
        Me.pnlLoanCollection = New System.Windows.Forms.Panel
        Me.btnCancelCollection = New System.Windows.Forms.Button
        Me.cboDeductionType = New System.Windows.Forms.ComboBox
        Me.btnLoadCollection = New System.Windows.Forms.Button
        Me.lblCollectionHeader = New System.Windows.Forms.Label
        Me.dtpPaymentDate = New System.Windows.Forms.DateTimePicker
        Me.lblContributionDate = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboTypeId = New System.Windows.Forms.ComboBox
        Me.dgvLoanBillingDetails = New System.Windows.Forms.DataGridView
        Me.colMemberId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTotalBalance = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMonthlyPayment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanInterest = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colclosed = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanBillId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tabContributionRecords = New System.Windows.Forms.TabPage
        Me.dgvContributionBillingDetails = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colContribution = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPabaon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMortuary = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPSLink = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colOATotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colActive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colContributionBillId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmnsPayment.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.grpPaymentDetails.SuspendLayout()
        Me.pnlTotalPayable.SuspendLayout()
        Me.grpPaymentType.SuspendLayout()
        CType(Me.dgvCheckDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCollectibleRecords.SuspendLayout()
        Me.tabLoanRecords.SuspendLayout()
        Me.pnlLoanCollection.SuspendLayout()
        CType(Me.dgvLoanBillingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabContributionRecords.SuspendLayout()
        CType(Me.dgvContributionBillingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmnsPayment
        '
        Me.cmnsPayment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartORNoToolStripMenuItem, Me.ToolStripSeparator1, Me.ClearCollectibleToolStripMenuItem, Me.LoadLoanCollectionToolStripMenuItem, Me.ToolStripMenuItem1, Me.PrintOfficialReceiptToolStripMenuItem})
        Me.cmnsPayment.Name = "cmnsPayment"
        Me.cmnsPayment.Size = New System.Drawing.Size(206, 104)
        '
        'StartORNoToolStripMenuItem
        '
        Me.StartORNoToolStripMenuItem.Name = "StartORNoToolStripMenuItem"
        Me.StartORNoToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.StartORNoToolStripMenuItem.Text = "Start Official Receipt No."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(202, 6)
        '
        'ClearCollectibleToolStripMenuItem
        '
        Me.ClearCollectibleToolStripMenuItem.Name = "ClearCollectibleToolStripMenuItem"
        Me.ClearCollectibleToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ClearCollectibleToolStripMenuItem.Text = "&Clear Collectible Records"
        '
        'LoadLoanCollectionToolStripMenuItem
        '
        Me.LoadLoanCollectionToolStripMenuItem.Name = "LoadLoanCollectionToolStripMenuItem"
        Me.LoadLoanCollectionToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.LoadLoanCollectionToolStripMenuItem.Text = "Load Loan Collection"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(202, 6)
        '
        'PrintOfficialReceiptToolStripMenuItem
        '
        Me.PrintOfficialReceiptToolStripMenuItem.Name = "PrintOfficialReceiptToolStripMenuItem"
        Me.PrintOfficialReceiptToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.PrintOfficialReceiptToolStripMenuItem.Text = "&Print Official Receipt"
        '
        'ilTool
        '
        Me.ilTool.ImageStream = CType(resources.GetObject("ilTool.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTool.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTool.Images.SetKeyName(0, "add.ico")
        Me.ilTool.Images.SetKeyName(1, "edit.ico")
        Me.ilTool.Images.SetKeyName(2, "delete.ico")
        Me.ilTool.Images.SetKeyName(3, "find.ico")
        Me.ilTool.Images.SetKeyName(4, "save.ico")
        Me.ilTool.Images.SetKeyName(5, "cancel.ico")
        Me.ilTool.Images.SetKeyName(6, "approve.ico")
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(1008, 40)
        Me.pnlToolbar.TabIndex = 167
        '
        'tbrMainForm
        '
        Me.tbrMainForm.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMainForm.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnFind, Me.btnSave, Me.btnCancel, Me.btnApprove})
        Me.tbrMainForm.ButtonSize = New System.Drawing.Size(40, 36)
        Me.tbrMainForm.Divider = False
        Me.tbrMainForm.DropDownArrows = True
        Me.tbrMainForm.ImageList = Me.ilTool
        Me.tbrMainForm.Location = New System.Drawing.Point(0, 0)
        Me.tbrMainForm.Name = "tbrMainForm"
        Me.tbrMainForm.ShowToolTips = True
        Me.tbrMainForm.Size = New System.Drawing.Size(1008, 40)
        Me.tbrMainForm.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Add"
        Me.btnAdd.ToolTipText = "Add new record"
        '
        'btnEdit
        '
        Me.btnEdit.ImageIndex = 1
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "Edit "
        Me.btnEdit.ToolTipText = "Edit record"
        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Delete record"
        '
        'btnFind
        '
        Me.btnFind.ImageIndex = 3
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Find"
        Me.btnFind.ToolTipText = "Launch Finder Screen"
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 4
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save Record"
        '
        'btnCancel
        '
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancel Changes Made"
        '
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 6
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Text = "Approve"
        '
        'grpPaymentDetails
        '
        Me.grpPaymentDetails.BackColor = System.Drawing.Color.Transparent
        Me.grpPaymentDetails.Controls.Add(Me.txtCollectorId)
        Me.grpPaymentDetails.Controls.Add(Me.txtAmountChange)
        Me.grpPaymentDetails.Controls.Add(Me.chkSaveCredit)
        Me.grpPaymentDetails.Controls.Add(Me.txtTaxCreditAvailable)
        Me.grpPaymentDetails.Controls.Add(Me.txtTaxCreditAmount)
        Me.grpPaymentDetails.Controls.Add(Me.cboBankName)
        Me.grpPaymentDetails.Controls.Add(Me.cboBankId)
        Me.grpPaymentDetails.Controls.Add(Me.chkDeleteFl)
        Me.grpPaymentDetails.Controls.Add(Me.pnlTotalPayable)
        Me.grpPaymentDetails.Controls.Add(Me.grpPaymentType)
        Me.grpPaymentDetails.Controls.Add(Me.lblORAmount)
        Me.grpPaymentDetails.Controls.Add(Me.dgvCheckDetails)
        Me.grpPaymentDetails.Controls.Add(Me.txtCashAmount)
        Me.grpPaymentDetails.Controls.Add(Me.txtORAmount)
        Me.grpPaymentDetails.Controls.Add(Me.txtCollectorName)
        Me.grpPaymentDetails.Controls.Add(Me.lblCashAmount)
        Me.grpPaymentDetails.Controls.Add(Me.lblCollectorName)
        Me.grpPaymentDetails.Controls.Add(Me.lblCheckAmount)
        Me.grpPaymentDetails.Controls.Add(Me.chkOnlineFl)
        Me.grpPaymentDetails.Controls.Add(Me.txtCheckAmount)
        Me.grpPaymentDetails.Controls.Add(Me.chkBillingFl)
        Me.grpPaymentDetails.Controls.Add(Me.txtRefId)
        Me.grpPaymentDetails.Controls.Add(Me.chkCancelFl)
        Me.grpPaymentDetails.Controls.Add(Me.lblAccountMemoRemarks)
        Me.grpPaymentDetails.Controls.Add(Me.txtPaymentRemarks)
        Me.grpPaymentDetails.Controls.Add(Me.txtMemberId)
        Me.grpPaymentDetails.Controls.Add(Me.txtORNo)
        Me.grpPaymentDetails.Controls.Add(Me.lblORDt)
        Me.grpPaymentDetails.Controls.Add(Me.txtMemberName)
        Me.grpPaymentDetails.Controls.Add(Me.dtpORDt)
        Me.grpPaymentDetails.Controls.Add(Me.lblORNo)
        Me.grpPaymentDetails.Controls.Add(Me.lblMemberName)
        Me.grpPaymentDetails.Dock = System.Windows.Forms.DockStyle.Left
        Me.grpPaymentDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPaymentDetails.Location = New System.Drawing.Point(0, 40)
        Me.grpPaymentDetails.Name = "grpPaymentDetails"
        Me.grpPaymentDetails.Size = New System.Drawing.Size(405, 579)
        Me.grpPaymentDetails.TabIndex = 168
        Me.grpPaymentDetails.TabStop = False
        Me.grpPaymentDetails.Text = "Payment Details"
        '
        'txtCollectorId
        '
        Me.txtCollectorId.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectorId.Location = New System.Drawing.Point(359, 149)
        Me.txtCollectorId.Name = "txtCollectorId"
        Me.txtCollectorId.ReadOnly = True
        Me.txtCollectorId.Size = New System.Drawing.Size(26, 22)
        Me.txtCollectorId.TabIndex = 178
        Me.txtCollectorId.TabStop = False
        Me.txtCollectorId.Visible = False
        '
        'txtAmountChange
        '
        Me.txtAmountChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmountChange.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountChange.Location = New System.Drawing.Point(218, 409)
        Me.txtAmountChange.Name = "txtAmountChange"
        Me.txtAmountChange.ReadOnly = True
        Me.txtAmountChange.Size = New System.Drawing.Size(27, 26)
        Me.txtAmountChange.TabIndex = 177
        Me.txtAmountChange.TabStop = False
        Me.txtAmountChange.Text = "0.00"
        Me.txtAmountChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountChange.Visible = False
        '
        'chkSaveCredit
        '
        Me.chkSaveCredit.AutoSize = True
        Me.chkSaveCredit.Enabled = False
        Me.chkSaveCredit.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSaveCredit.Location = New System.Drawing.Point(18, 418)
        Me.chkSaveCredit.Name = "chkSaveCredit"
        Me.chkSaveCredit.Size = New System.Drawing.Size(131, 17)
        Me.chkSaveCredit.TabIndex = 176
        Me.chkSaveCredit.Tag = "0"
        Me.chkSaveCredit.Text = "Save to Tax Credit?"
        Me.chkSaveCredit.Visible = False
        '
        'txtTaxCreditAvailable
        '
        Me.txtTaxCreditAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxCreditAvailable.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxCreditAvailable.Location = New System.Drawing.Point(153, 409)
        Me.txtTaxCreditAvailable.Name = "txtTaxCreditAvailable"
        Me.txtTaxCreditAvailable.ReadOnly = True
        Me.txtTaxCreditAvailable.Size = New System.Drawing.Size(26, 26)
        Me.txtTaxCreditAvailable.TabIndex = 175
        Me.txtTaxCreditAvailable.TabStop = False
        Me.txtTaxCreditAvailable.Text = "0.00"
        Me.txtTaxCreditAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxCreditAvailable.Visible = False
        '
        'txtTaxCreditAmount
        '
        Me.txtTaxCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxCreditAmount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxCreditAmount.Location = New System.Drawing.Point(185, 409)
        Me.txtTaxCreditAmount.Name = "txtTaxCreditAmount"
        Me.txtTaxCreditAmount.ReadOnly = True
        Me.txtTaxCreditAmount.Size = New System.Drawing.Size(27, 26)
        Me.txtTaxCreditAmount.TabIndex = 174
        Me.txtTaxCreditAmount.TabStop = False
        Me.txtTaxCreditAmount.Text = "0.00"
        Me.txtTaxCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxCreditAmount.Visible = False
        '
        'cboBankName
        '
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(359, 233)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(25, 22)
        Me.cboBankName.TabIndex = 141
        Me.cboBankName.TabStop = False
        Me.cboBankName.Visible = False
        '
        'cboBankId
        '
        Me.cboBankId.FormattingEnabled = True
        Me.cboBankId.Location = New System.Drawing.Point(340, 233)
        Me.cboBankId.Name = "cboBankId"
        Me.cboBankId.Size = New System.Drawing.Size(25, 22)
        Me.cboBankId.TabIndex = 140
        Me.cboBankId.TabStop = False
        Me.cboBankId.Visible = False
        '
        'chkDeleteFl
        '
        Me.chkDeleteFl.AutoSize = True
        Me.chkDeleteFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDeleteFl.Location = New System.Drawing.Point(103, 125)
        Me.chkDeleteFl.Name = "chkDeleteFl"
        Me.chkDeleteFl.Size = New System.Drawing.Size(15, 14)
        Me.chkDeleteFl.TabIndex = 169
        Me.chkDeleteFl.TabStop = False
        Me.chkDeleteFl.Tag = "0"
        Me.chkDeleteFl.Visible = False
        '
        'pnlTotalPayable
        '
        Me.pnlTotalPayable.BackColor = System.Drawing.SystemColors.Info
        Me.pnlTotalPayable.Controls.Add(Me.Label2)
        Me.pnlTotalPayable.Controls.Add(Me.txtTotalAmountDue)
        Me.pnlTotalPayable.Controls.Add(Me.Label1)
        Me.pnlTotalPayable.Controls.Add(Me.txtTotalContributionDue)
        Me.pnlTotalPayable.Controls.Add(Me.lblTotalAmountPayable)
        Me.pnlTotalPayable.Controls.Add(Me.txtTotalAmountPayable)
        Me.pnlTotalPayable.Controls.Add(Me.lblTotalAmountDue)
        Me.pnlTotalPayable.Controls.Add(Me.txtTotalLoanDue)
        Me.pnlTotalPayable.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlTotalPayable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTotalPayable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlTotalPayable.Location = New System.Drawing.Point(3, 422)
        Me.pnlTotalPayable.Name = "pnlTotalPayable"
        Me.pnlTotalPayable.Size = New System.Drawing.Size(399, 154)
        Me.pnlTotalPayable.TabIndex = 173
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "TOTAL AMOUNT DUE"
        '
        'txtTotalAmountDue
        '
        Me.txtTotalAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmountDue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmountDue.Location = New System.Drawing.Point(185, 74)
        Me.txtTotalAmountDue.Name = "txtTotalAmountDue"
        Me.txtTotalAmountDue.ReadOnly = True
        Me.txtTotalAmountDue.Size = New System.Drawing.Size(200, 26)
        Me.txtTotalAmountDue.TabIndex = 7
        Me.txtTotalAmountDue.TabStop = False
        Me.txtTotalAmountDue.Text = "0.00"
        Me.txtTotalAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "CONTRIBUTION DUE"
        '
        'txtTotalContributionDue
        '
        Me.txtTotalContributionDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalContributionDue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalContributionDue.Location = New System.Drawing.Point(185, 42)
        Me.txtTotalContributionDue.Name = "txtTotalContributionDue"
        Me.txtTotalContributionDue.ReadOnly = True
        Me.txtTotalContributionDue.Size = New System.Drawing.Size(200, 26)
        Me.txtTotalContributionDue.TabIndex = 5
        Me.txtTotalContributionDue.TabStop = False
        Me.txtTotalContributionDue.Text = "0.00"
        Me.txtTotalContributionDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmountPayable
        '
        Me.lblTotalAmountPayable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmountPayable.Location = New System.Drawing.Point(12, 125)
        Me.lblTotalAmountPayable.Name = "lblTotalAmountPayable"
        Me.lblTotalAmountPayable.Size = New System.Drawing.Size(132, 16)
        Me.lblTotalAmountPayable.TabIndex = 2
        Me.lblTotalAmountPayable.Text = "TOTAL AMOUNT PAID"
        '
        'txtTotalAmountPayable
        '
        Me.txtTotalAmountPayable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmountPayable.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmountPayable.Location = New System.Drawing.Point(185, 119)
        Me.txtTotalAmountPayable.Name = "txtTotalAmountPayable"
        Me.txtTotalAmountPayable.ReadOnly = True
        Me.txtTotalAmountPayable.Size = New System.Drawing.Size(200, 26)
        Me.txtTotalAmountPayable.TabIndex = 3
        Me.txtTotalAmountPayable.TabStop = False
        Me.txtTotalAmountPayable.Text = "0.00"
        Me.txtTotalAmountPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmountDue
        '
        Me.lblTotalAmountDue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmountDue.Location = New System.Drawing.Point(12, 16)
        Me.lblTotalAmountDue.Name = "lblTotalAmountDue"
        Me.lblTotalAmountDue.Size = New System.Drawing.Size(122, 16)
        Me.lblTotalAmountDue.TabIndex = 0
        Me.lblTotalAmountDue.Text = "LOAN DUE"
        '
        'txtTotalLoanDue
        '
        Me.txtTotalLoanDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalLoanDue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalLoanDue.Location = New System.Drawing.Point(185, 10)
        Me.txtTotalLoanDue.Name = "txtTotalLoanDue"
        Me.txtTotalLoanDue.ReadOnly = True
        Me.txtTotalLoanDue.Size = New System.Drawing.Size(200, 26)
        Me.txtTotalLoanDue.TabIndex = 1
        Me.txtTotalLoanDue.TabStop = False
        Me.txtTotalLoanDue.Text = "0.00"
        Me.txtTotalLoanDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpPaymentType
        '
        Me.grpPaymentType.BackColor = System.Drawing.Color.Transparent
        Me.grpPaymentType.Controls.Add(Me.rbCashCheque)
        Me.grpPaymentType.Controls.Add(Me.rbCheque)
        Me.grpPaymentType.Controls.Add(Me.rbCash)
        Me.grpPaymentType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpPaymentType.Location = New System.Drawing.Point(18, 177)
        Me.grpPaymentType.Name = "grpPaymentType"
        Me.grpPaymentType.Size = New System.Drawing.Size(367, 50)
        Me.grpPaymentType.TabIndex = 169
        Me.grpPaymentType.TabStop = False
        Me.grpPaymentType.Text = "Payment Type"
        '
        'rbCashCheque
        '
        Me.rbCashCheque.AutoSize = True
        Me.rbCashCheque.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCashCheque.Location = New System.Drawing.Point(206, 19)
        Me.rbCashCheque.Name = "rbCashCheque"
        Me.rbCashCheque.Size = New System.Drawing.Size(111, 18)
        Me.rbCashCheque.TabIndex = 2
        Me.rbCashCheque.Text = "Cash and Cheque"
        Me.rbCashCheque.UseVisualStyleBackColor = True
        '
        'rbCheque
        '
        Me.rbCheque.AutoSize = True
        Me.rbCheque.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCheque.Location = New System.Drawing.Point(107, 19)
        Me.rbCheque.Name = "rbCheque"
        Me.rbCheque.Size = New System.Drawing.Size(87, 18)
        Me.rbCheque.TabIndex = 1
        Me.rbCheque.Text = "Cheque Only"
        Me.rbCheque.UseVisualStyleBackColor = True
        '
        'rbCash
        '
        Me.rbCash.AutoSize = True
        Me.rbCash.Checked = True
        Me.rbCash.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCash.Location = New System.Drawing.Point(20, 19)
        Me.rbCash.Name = "rbCash"
        Me.rbCash.Size = New System.Drawing.Size(75, 18)
        Me.rbCash.TabIndex = 0
        Me.rbCash.TabStop = True
        Me.rbCash.Text = "Cash Only"
        Me.rbCash.UseVisualStyleBackColor = True
        '
        'lblORAmount
        '
        Me.lblORAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORAmount.Location = New System.Drawing.Point(15, 399)
        Me.lblORAmount.Name = "lblORAmount"
        Me.lblORAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblORAmount.TabIndex = 6
        Me.lblORAmount.Text = "Total OR Amount"
        '
        'dgvCheckDetails
        '
        Me.dgvCheckDetails.AllowUserToResizeRows = False
        Me.dgvCheckDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCheckDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvCheckDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBankId, Me.colBankName, Me.colBranchName, Me.colCheckNo, Me.colCheckAmount, Me.colCheckDate, Me.colCheckRemarks})
        Me.dgvCheckDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCheckDetails.Location = New System.Drawing.Point(18, 233)
        Me.dgvCheckDetails.MultiSelect = False
        Me.dgvCheckDetails.Name = "dgvCheckDetails"
        Me.dgvCheckDetails.RowHeadersWidth = 30
        Me.dgvCheckDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCheckDetails.ShowCellToolTips = False
        Me.dgvCheckDetails.Size = New System.Drawing.Size(367, 79)
        Me.dgvCheckDetails.TabIndex = 8
        Me.dgvCheckDetails.Tag = "0"
        '
        'colBankId
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = "0"
        Me.colBankId.DefaultCellStyle = DataGridViewCellStyle1
        Me.colBankId.HeaderText = "BankId"
        Me.colBankId.Name = "colBankId"
        Me.colBankId.ReadOnly = True
        Me.colBankId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colBankId.ToolTipText = "1"
        Me.colBankId.Visible = False
        Me.colBankId.Width = 5
        '
        'colBankName
        '
        Me.colBankName.HeaderText = "Bank Name"
        Me.colBankName.MinimumWidth = 125
        Me.colBankName.Name = "colBankName"
        Me.colBankName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colBankName.ToolTipText = "0"
        Me.colBankName.Width = 125
        '
        'colBranchName
        '
        Me.colBranchName.HeaderText = "Branch Name"
        Me.colBranchName.MinimumWidth = 125
        Me.colBranchName.Name = "colBranchName"
        Me.colBranchName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colBranchName.ToolTipText = "0"
        Me.colBranchName.Width = 125
        '
        'colCheckNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colCheckNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCheckNo.HeaderText = "Check No."
        Me.colCheckNo.MinimumWidth = 100
        Me.colCheckNo.Name = "colCheckNo"
        Me.colCheckNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCheckNo.ToolTipText = "0"
        '
        'colCheckAmount
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = "0.00"
        Me.colCheckAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.colCheckAmount.HeaderText = "Amount"
        Me.colCheckAmount.MinimumWidth = 100
        Me.colCheckAmount.Name = "colCheckAmount"
        Me.colCheckAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCheckAmount.ToolTipText = "0"
        '
        'colCheckDate
        '
        Me.colCheckDate.HeaderText = "Check Date"
        Me.colCheckDate.MinimumWidth = 100
        Me.colCheckDate.Name = "colCheckDate"
        Me.colCheckDate.ToolTipText = "0"
        '
        'colCheckRemarks
        '
        Me.colCheckRemarks.HeaderText = "Remarks"
        Me.colCheckRemarks.MinimumWidth = 200
        Me.colCheckRemarks.Name = "colCheckRemarks"
        Me.colCheckRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colCheckRemarks.ToolTipText = "0"
        Me.colCheckRemarks.Width = 200
        '
        'txtCashAmount
        '
        Me.txtCashAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashAmount.Location = New System.Drawing.Point(185, 331)
        Me.txtCashAmount.Name = "txtCashAmount"
        Me.txtCashAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtCashAmount.TabIndex = 1
        Me.txtCashAmount.Text = "0.00"
        Me.txtCashAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtORAmount
        '
        Me.txtORAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORAmount.Location = New System.Drawing.Point(185, 396)
        Me.txtORAmount.Name = "txtORAmount"
        Me.txtORAmount.ReadOnly = True
        Me.txtORAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtORAmount.TabIndex = 7
        Me.txtORAmount.TabStop = False
        Me.txtORAmount.Text = "0.00"
        Me.txtORAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCollectorName
        '
        Me.txtCollectorName.BackColor = System.Drawing.Color.White
        Me.txtCollectorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCollectorName.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectorName.Location = New System.Drawing.Point(131, 149)
        Me.txtCollectorName.Name = "txtCollectorName"
        Me.txtCollectorName.ReadOnly = True
        Me.txtCollectorName.Size = New System.Drawing.Size(254, 22)
        Me.txtCollectorName.TabIndex = 172
        Me.txtCollectorName.TabStop = False
        '
        'lblCashAmount
        '
        Me.lblCashAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashAmount.Location = New System.Drawing.Point(15, 331)
        Me.lblCashAmount.Name = "lblCashAmount"
        Me.lblCashAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblCashAmount.TabIndex = 0
        Me.lblCashAmount.Text = "Cash Amount"
        '
        'lblCollectorName
        '
        Me.lblCollectorName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectorName.Location = New System.Drawing.Point(15, 153)
        Me.lblCollectorName.Name = "lblCollectorName"
        Me.lblCollectorName.Size = New System.Drawing.Size(132, 17)
        Me.lblCollectorName.TabIndex = 171
        Me.lblCollectorName.Text = "COLLECTOR NAME"
        '
        'lblCheckAmount
        '
        Me.lblCheckAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckAmount.Location = New System.Drawing.Point(15, 357)
        Me.lblCheckAmount.Name = "lblCheckAmount"
        Me.lblCheckAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblCheckAmount.TabIndex = 2
        Me.lblCheckAmount.Text = "Cheque Amount "
        '
        'chkOnlineFl
        '
        Me.chkOnlineFl.AutoSize = True
        Me.chkOnlineFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOnlineFl.Location = New System.Drawing.Point(58, 122)
        Me.chkOnlineFl.Name = "chkOnlineFl"
        Me.chkOnlineFl.Size = New System.Drawing.Size(15, 14)
        Me.chkOnlineFl.TabIndex = 168
        Me.chkOnlineFl.TabStop = False
        Me.chkOnlineFl.Tag = "0"
        Me.chkOnlineFl.Visible = False
        '
        'txtCheckAmount
        '
        Me.txtCheckAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckAmount.Location = New System.Drawing.Point(185, 357)
        Me.txtCheckAmount.Name = "txtCheckAmount"
        Me.txtCheckAmount.ReadOnly = True
        Me.txtCheckAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtCheckAmount.TabIndex = 3
        Me.txtCheckAmount.TabStop = False
        Me.txtCheckAmount.Text = "0.00"
        Me.txtCheckAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkBillingFl
        '
        Me.chkBillingFl.AutoSize = True
        Me.chkBillingFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBillingFl.Location = New System.Drawing.Point(38, 122)
        Me.chkBillingFl.Name = "chkBillingFl"
        Me.chkBillingFl.Size = New System.Drawing.Size(15, 14)
        Me.chkBillingFl.TabIndex = 167
        Me.chkBillingFl.TabStop = False
        Me.chkBillingFl.Tag = "0"
        Me.chkBillingFl.Visible = False
        '
        'txtRefId
        '
        Me.txtRefId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefId.Location = New System.Drawing.Point(78, 122)
        Me.txtRefId.Name = "txtRefId"
        Me.txtRefId.ReadOnly = True
        Me.txtRefId.Size = New System.Drawing.Size(20, 20)
        Me.txtRefId.TabIndex = 166
        Me.txtRefId.TabStop = False
        Me.txtRefId.Visible = False
        '
        'chkCancelFl
        '
        Me.chkCancelFl.AutoSize = True
        Me.chkCancelFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCancelFl.Location = New System.Drawing.Point(18, 122)
        Me.chkCancelFl.Name = "chkCancelFl"
        Me.chkCancelFl.Size = New System.Drawing.Size(15, 14)
        Me.chkCancelFl.TabIndex = 165
        Me.chkCancelFl.TabStop = False
        Me.chkCancelFl.Tag = "0"
        Me.chkCancelFl.Visible = False
        '
        'lblAccountMemoRemarks
        '
        Me.lblAccountMemoRemarks.BackColor = System.Drawing.Color.White
        Me.lblAccountMemoRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountMemoRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAccountMemoRemarks.Location = New System.Drawing.Point(15, 103)
        Me.lblAccountMemoRemarks.Name = "lblAccountMemoRemarks"
        Me.lblAccountMemoRemarks.Size = New System.Drawing.Size(100, 16)
        Me.lblAccountMemoRemarks.TabIndex = 8
        Me.lblAccountMemoRemarks.Text = "Remarks"
        '
        'txtPaymentRemarks
        '
        Me.txtPaymentRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentRemarks.Location = New System.Drawing.Point(131, 103)
        Me.txtPaymentRemarks.Multiline = True
        Me.txtPaymentRemarks.Name = "txtPaymentRemarks"
        Me.txtPaymentRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPaymentRemarks.Size = New System.Drawing.Size(254, 40)
        Me.txtPaymentRemarks.TabIndex = 9
        '
        'txtMemberId
        '
        Me.txtMemberId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberId.Location = New System.Drawing.Point(365, 77)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 7
        Me.txtMemberId.TabStop = False
        Me.txtMemberId.Visible = False
        '
        'txtORNo
        '
        Me.txtORNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtORNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNo.Location = New System.Drawing.Point(131, 25)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.ReadOnly = True
        Me.txtORNo.Size = New System.Drawing.Size(150, 20)
        Me.txtORNo.TabIndex = 1
        Me.txtORNo.TabStop = False
        '
        'lblORDt
        '
        Me.lblORDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORDt.Location = New System.Drawing.Point(15, 51)
        Me.lblORDt.Name = "lblORDt"
        Me.lblORDt.Size = New System.Drawing.Size(105, 16)
        Me.lblORDt.TabIndex = 2
        Me.lblORDt.Text = "Official Receipt Date"
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(131, 77)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(254, 20)
        Me.txtMemberName.TabIndex = 6
        '
        'dtpORDt
        '
        Me.dtpORDt.Checked = False
        Me.dtpORDt.CustomFormat = "MMMM dd, yyyy"
        Me.dtpORDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpORDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpORDt.Location = New System.Drawing.Point(131, 51)
        Me.dtpORDt.Name = "dtpORDt"
        Me.dtpORDt.Size = New System.Drawing.Size(150, 20)
        Me.dtpORDt.TabIndex = 3
        Me.dtpORDt.Value = New Date(2011, 7, 17, 0, 0, 0, 0)
        '
        'lblORNo
        '
        Me.lblORNo.BackColor = System.Drawing.Color.White
        Me.lblORNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORNo.Location = New System.Drawing.Point(15, 25)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(110, 16)
        Me.lblORNo.TabIndex = 0
        Me.lblORNo.Text = "Official Receipt No. *"
        '
        'lblMemberName
        '
        Me.lblMemberName.BackColor = System.Drawing.Color.White
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(15, 77)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(100, 16)
        Me.lblMemberName.TabIndex = 5
        Me.lblMemberName.Text = "Payor Name *"
        '
        'tabCollectibleRecords
        '
        Me.tabCollectibleRecords.Controls.Add(Me.tabLoanRecords)
        Me.tabCollectibleRecords.Controls.Add(Me.tabContributionRecords)
        Me.tabCollectibleRecords.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCollectibleRecords.Location = New System.Drawing.Point(405, 40)
        Me.tabCollectibleRecords.Name = "tabCollectibleRecords"
        Me.tabCollectibleRecords.SelectedIndex = 0
        Me.tabCollectibleRecords.Size = New System.Drawing.Size(603, 579)
        Me.tabCollectibleRecords.TabIndex = 181
        '
        'tabLoanRecords
        '
        Me.tabLoanRecords.Controls.Add(Me.cboTypeName)
        Me.tabLoanRecords.Controls.Add(Me.pnlLoanCollection)
        Me.tabLoanRecords.Controls.Add(Me.cboTypeId)
        Me.tabLoanRecords.Controls.Add(Me.dgvLoanBillingDetails)
        Me.tabLoanRecords.Location = New System.Drawing.Point(4, 22)
        Me.tabLoanRecords.Name = "tabLoanRecords"
        Me.tabLoanRecords.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLoanRecords.Size = New System.Drawing.Size(595, 553)
        Me.tabLoanRecords.TabIndex = 0
        Me.tabLoanRecords.Text = "Loan Collectibles"
        Me.tabLoanRecords.UseVisualStyleBackColor = True
        '
        'cboTypeName
        '
        Me.cboTypeName.FormattingEnabled = True
        Me.cboTypeName.Location = New System.Drawing.Point(30, 3)
        Me.cboTypeName.Name = "cboTypeName"
        Me.cboTypeName.Size = New System.Drawing.Size(25, 21)
        Me.cboTypeName.TabIndex = 181
        Me.cboTypeName.TabStop = False
        Me.cboTypeName.Visible = False
        '
        'pnlLoanCollection
        '
        Me.pnlLoanCollection.BackColor = System.Drawing.Color.White
        Me.pnlLoanCollection.Controls.Add(Me.btnCancelCollection)
        Me.pnlLoanCollection.Controls.Add(Me.cboDeductionType)
        Me.pnlLoanCollection.Controls.Add(Me.btnLoadCollection)
        Me.pnlLoanCollection.Controls.Add(Me.lblCollectionHeader)
        Me.pnlLoanCollection.Controls.Add(Me.dtpPaymentDate)
        Me.pnlLoanCollection.Controls.Add(Me.lblContributionDate)
        Me.pnlLoanCollection.Controls.Add(Me.Label7)
        Me.pnlLoanCollection.Location = New System.Drawing.Point(30, 113)
        Me.pnlLoanCollection.Name = "pnlLoanCollection"
        Me.pnlLoanCollection.Size = New System.Drawing.Size(278, 150)
        Me.pnlLoanCollection.TabIndex = 179
        Me.pnlLoanCollection.Visible = False
        '
        'btnCancelCollection
        '
        Me.btnCancelCollection.BackColor = System.Drawing.Color.Brown
        Me.btnCancelCollection.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnCancelCollection.ForeColor = System.Drawing.SystemColors.Control
        Me.btnCancelCollection.Location = New System.Drawing.Point(145, 104)
        Me.btnCancelCollection.Name = "btnCancelCollection"
        Me.btnCancelCollection.Size = New System.Drawing.Size(115, 28)
        Me.btnCancelCollection.TabIndex = 46
        Me.btnCancelCollection.Text = "Cancel"
        Me.btnCancelCollection.UseVisualStyleBackColor = False
        '
        'cboDeductionType
        '
        Me.cboDeductionType.FormattingEnabled = True
        Me.cboDeductionType.Items.AddRange(New Object() {"SALARY DEDUCTION", "PERA DEDUCTION"})
        Me.cboDeductionType.Location = New System.Drawing.Point(59, 69)
        Me.cboDeductionType.Name = "cboDeductionType"
        Me.cboDeductionType.Size = New System.Drawing.Size(201, 21)
        Me.cboDeductionType.TabIndex = 45
        Me.cboDeductionType.Text = "SALARY DEDUCTION"
        '
        'btnLoadCollection
        '
        Me.btnLoadCollection.BackColor = System.Drawing.Color.Green
        Me.btnLoadCollection.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnLoadCollection.ForeColor = System.Drawing.SystemColors.Control
        Me.btnLoadCollection.Location = New System.Drawing.Point(18, 104)
        Me.btnLoadCollection.Name = "btnLoadCollection"
        Me.btnLoadCollection.Size = New System.Drawing.Size(121, 28)
        Me.btnLoadCollection.TabIndex = 44
        Me.btnLoadCollection.Text = "Load"
        Me.btnLoadCollection.UseVisualStyleBackColor = False
        '
        'lblCollectionHeader
        '
        Me.lblCollectionHeader.BackColor = System.Drawing.Color.ForestGreen
        Me.lblCollectionHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectionHeader.ForeColor = System.Drawing.Color.White
        Me.lblCollectionHeader.Location = New System.Drawing.Point(-2, 0)
        Me.lblCollectionHeader.Name = "lblCollectionHeader"
        Me.lblCollectionHeader.Size = New System.Drawing.Size(280, 22)
        Me.lblCollectionHeader.TabIndex = 43
        Me.lblCollectionHeader.Text = "Collections"
        Me.lblCollectionHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpPaymentDate
        '
        Me.dtpPaymentDate.CustomFormat = "MMMM yyyy"
        Me.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDate.Location = New System.Drawing.Point(59, 43)
        Me.dtpPaymentDate.Name = "dtpPaymentDate"
        Me.dtpPaymentDate.ShowCheckBox = True
        Me.dtpPaymentDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpPaymentDate.TabIndex = 42
        '
        'lblContributionDate
        '
        Me.lblContributionDate.AutoSize = True
        Me.lblContributionDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblContributionDate.Location = New System.Drawing.Point(15, 48)
        Me.lblContributionDate.Name = "lblContributionDate"
        Me.lblContributionDate.Size = New System.Drawing.Size(31, 14)
        Me.lblContributionDate.TabIndex = 41
        Me.lblContributionDate.Text = "Date"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(14, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 14)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Type"
        '
        'cboTypeId
        '
        Me.cboTypeId.FormattingEnabled = True
        Me.cboTypeId.Location = New System.Drawing.Point(6, 3)
        Me.cboTypeId.Name = "cboTypeId"
        Me.cboTypeId.Size = New System.Drawing.Size(25, 21)
        Me.cboTypeId.TabIndex = 180
        Me.cboTypeId.TabStop = False
        Me.cboTypeId.Visible = False
        '
        'dgvLoanBillingDetails
        '
        Me.dgvLoanBillingDetails.AllowUserToAddRows = False
        Me.dgvLoanBillingDetails.AllowUserToDeleteRows = False
        Me.dgvLoanBillingDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvLoanBillingDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvLoanBillingDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLoanBillingDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMemberId, Me.colMemberNo, Me.colMemberName, Me.colLoanId, Me.colLoanNo, Me.colLoanType, Me.colTotalBalance, Me.colMonthlyPayment, Me.colAmountPaid, Me.colLoanInterest, Me.colclosed, Me.colStatus, Me.colLoanBillId})
        Me.dgvLoanBillingDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLoanBillingDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvLoanBillingDetails.Location = New System.Drawing.Point(3, 3)
        Me.dgvLoanBillingDetails.Name = "dgvLoanBillingDetails"
        Me.dgvLoanBillingDetails.RowHeadersWidth = 51
        Me.dgvLoanBillingDetails.Size = New System.Drawing.Size(589, 547)
        Me.dgvLoanBillingDetails.TabIndex = 1
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
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.colMemberName.DefaultCellStyle = DataGridViewCellStyle5
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
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colLoanNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.colLoanNo.Frozen = True
        Me.colLoanNo.HeaderText = "LOAN No."
        Me.colLoanNo.Name = "colLoanNo"
        Me.colLoanNo.ReadOnly = True
        Me.colLoanNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLoanNo.Width = 75
        '
        'colLoanType
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colLoanType.DefaultCellStyle = DataGridViewCellStyle7
        Me.colLoanType.Frozen = True
        Me.colLoanType.HeaderText = "TYPE OF LOAN"
        Me.colLoanType.Name = "colLoanType"
        Me.colLoanType.ReadOnly = True
        Me.colLoanType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLoanType.Width = 150
        '
        'colTotalBalance
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colTotalBalance.DefaultCellStyle = DataGridViewCellStyle8
        Me.colTotalBalance.Frozen = True
        Me.colTotalBalance.HeaderText = "CURRENT BALANCE"
        Me.colTotalBalance.Name = "colTotalBalance"
        Me.colTotalBalance.ReadOnly = True
        Me.colTotalBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTotalBalance.Width = 125
        '
        'colMonthlyPayment
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colMonthlyPayment.DefaultCellStyle = DataGridViewCellStyle9
        Me.colMonthlyPayment.HeaderText = "MONTHLY PAYMENT"
        Me.colMonthlyPayment.Name = "colMonthlyPayment"
        Me.colMonthlyPayment.ReadOnly = True
        Me.colMonthlyPayment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colAmountPaid
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colAmountPaid.DefaultCellStyle = DataGridViewCellStyle10
        Me.colAmountPaid.HeaderText = "AMOUNT PAID"
        Me.colAmountPaid.Name = "colAmountPaid"
        Me.colAmountPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colLoanInterest
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colLoanInterest.DefaultCellStyle = DataGridViewCellStyle11
        Me.colLoanInterest.HeaderText = "LOAN INTEREST"
        Me.colLoanInterest.Name = "colLoanInterest"
        Me.colLoanInterest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colclosed
        '
        Me.colclosed.HeaderText = "CLOSED"
        Me.colclosed.Name = "colclosed"
        Me.colclosed.ReadOnly = True
        Me.colclosed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colStatus
        '
        Me.colStatus.HeaderText = "STATUS"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colStatus.Width = 200
        '
        'colLoanBillId
        '
        Me.colLoanBillId.HeaderText = "BILLING ID"
        Me.colLoanBillId.Name = "colLoanBillId"
        Me.colLoanBillId.Visible = False
        '
        'tabContributionRecords
        '
        Me.tabContributionRecords.Controls.Add(Me.dgvContributionBillingDetails)
        Me.tabContributionRecords.Location = New System.Drawing.Point(4, 22)
        Me.tabContributionRecords.Name = "tabContributionRecords"
        Me.tabContributionRecords.Padding = New System.Windows.Forms.Padding(3)
        Me.tabContributionRecords.Size = New System.Drawing.Size(595, 553)
        Me.tabContributionRecords.TabIndex = 1
        Me.tabContributionRecords.Text = "Contribution Collectibles"
        Me.tabContributionRecords.UseVisualStyleBackColor = True
        '
        'dgvContributionBillingDetails
        '
        Me.dgvContributionBillingDetails.AllowUserToAddRows = False
        Me.dgvContributionBillingDetails.AllowUserToDeleteRows = False
        Me.dgvContributionBillingDetails.AllowUserToResizeRows = False
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContributionBillingDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvContributionBillingDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvContributionBillingDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.colContribution, Me.colPabaon, Me.colMortuary, Me.colPSLink, Me.colOATotal, Me.DataGridViewTextBoxColumn4, Me.colActive, Me.colContributionBillId})
        Me.dgvContributionBillingDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvContributionBillingDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvContributionBillingDetails.Location = New System.Drawing.Point(3, 3)
        Me.dgvContributionBillingDetails.Name = "dgvContributionBillingDetails"
        Me.dgvContributionBillingDetails.RowHeadersWidth = 51
        Me.dgvContributionBillingDetails.Size = New System.Drawing.Size(589, 547)
        Me.dgvContributionBillingDetails.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.Frozen = True
        Me.DataGridViewTextBoxColumn1.HeaderText = "MID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.Frozen = True
        Me.DataGridViewTextBoxColumn2.HeaderText = "MNo."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn3.Frozen = True
        Me.DataGridViewTextBoxColumn3.HeaderText = "MEMBER NAME"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 175
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 175
        '
        'colContribution
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colContribution.DefaultCellStyle = DataGridViewCellStyle13
        Me.colContribution.HeaderText = "CONTRIBUTION"
        Me.colContribution.Name = "colContribution"
        Me.colContribution.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colContribution.Width = 90
        '
        'colPabaon
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.colPabaon.DefaultCellStyle = DataGridViewCellStyle14
        Me.colPabaon.HeaderText = "PABAON"
        Me.colPabaon.Name = "colPabaon"
        Me.colPabaon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPabaon.Width = 90
        '
        'colMortuary
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colMortuary.DefaultCellStyle = DataGridViewCellStyle15
        Me.colMortuary.HeaderText = "MORTUARY"
        Me.colMortuary.Name = "colMortuary"
        Me.colMortuary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colMortuary.Width = 90
        '
        'colPSLink
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colPSLink.DefaultCellStyle = DataGridViewCellStyle16
        Me.colPSLink.HeaderText = "PSLINK"
        Me.colPSLink.Name = "colPSLink"
        Me.colPSLink.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colPSLink.Width = 90
        '
        'colOATotal
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colOATotal.DefaultCellStyle = DataGridViewCellStyle17
        Me.colOATotal.HeaderText = "OVERALL TOTAL"
        Me.colOATotal.Name = "colOATotal"
        Me.colOATotal.ReadOnly = True
        Me.colOATotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "STATUS"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 150
        '
        'colActive
        '
        Me.colActive.HeaderText = "ACTIVE?"
        Me.colActive.Name = "colActive"
        Me.colActive.ReadOnly = True
        Me.colActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colActive.Visible = False
        '
        'colContributionBillId
        '
        Me.colContributionBillId.HeaderText = "BILLING ID"
        Me.colContributionBillId.Name = "colContributionBillId"
        '
        'frmPaymentLoanAndContribution
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 619)
        Me.ContextMenuStrip = Me.cmnsPayment
        Me.Controls.Add(Me.tabCollectibleRecords)
        Me.Controls.Add(Me.grpPaymentDetails)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Name = "frmPaymentLoanAndContribution"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan and Contribution Payment"
        Me.cmnsPayment.ResumeLayout(False)
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.grpPaymentDetails.ResumeLayout(False)
        Me.grpPaymentDetails.PerformLayout()
        Me.pnlTotalPayable.ResumeLayout(False)
        Me.pnlTotalPayable.PerformLayout()
        Me.grpPaymentType.ResumeLayout(False)
        Me.grpPaymentType.PerformLayout()
        CType(Me.dgvCheckDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCollectibleRecords.ResumeLayout(False)
        Me.tabLoanRecords.ResumeLayout(False)
        Me.pnlLoanCollection.ResumeLayout(False)
        Me.pnlLoanCollection.PerformLayout()
        CType(Me.dgvLoanBillingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabContributionRecords.ResumeLayout(False)
        CType(Me.dgvContributionBillingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmnsPayment As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents StartORNoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ClearCollectibleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadLoanCollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintOfficialReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents grpPaymentDetails As System.Windows.Forms.GroupBox
    Friend WithEvents chkDeleteFl As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnlineFl As System.Windows.Forms.CheckBox
    Friend WithEvents chkBillingFl As System.Windows.Forms.CheckBox
    Friend WithEvents txtRefId As System.Windows.Forms.TextBox
    Friend WithEvents chkCancelFl As System.Windows.Forms.CheckBox
    Friend WithEvents lblAccountMemoRemarks As System.Windows.Forms.Label
    Friend WithEvents txtPaymentRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents lblORDt As System.Windows.Forms.Label
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents dtpORDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblORNo As System.Windows.Forms.Label
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents lblCollectorName As System.Windows.Forms.Label
    Friend WithEvents txtCollectorName As System.Windows.Forms.TextBox
    Friend WithEvents grpPaymentType As System.Windows.Forms.GroupBox
    Friend WithEvents rbCashCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbCash As System.Windows.Forms.RadioButton
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents cboBankId As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCheckDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colBankId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckDate As Common.CalendarColumn
    Friend WithEvents colCheckRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblORAmount As System.Windows.Forms.Label
    Friend WithEvents txtCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtORAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblCashAmount As System.Windows.Forms.Label
    Friend WithEvents lblCheckAmount As System.Windows.Forms.Label
    Friend WithEvents txtCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents pnlTotalPayable As System.Windows.Forms.Panel
    Friend WithEvents lblTotalAmountPayable As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmountPayable As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmountDue As System.Windows.Forms.Label
    Friend WithEvents txtTotalLoanDue As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxCreditAvailable As System.Windows.Forms.TextBox
    Friend WithEvents chkSaveCredit As System.Windows.Forms.CheckBox
    Friend WithEvents txtAmountChange As System.Windows.Forms.TextBox
    Friend WithEvents txtCollectorId As System.Windows.Forms.TextBox
    Friend WithEvents tabCollectibleRecords As System.Windows.Forms.TabControl
    Friend WithEvents tabLoanRecords As System.Windows.Forms.TabPage
    Friend WithEvents cboTypeName As System.Windows.Forms.ComboBox
    Friend WithEvents pnlLoanCollection As System.Windows.Forms.Panel
    Friend WithEvents btnCancelCollection As System.Windows.Forms.Button
    Friend WithEvents cboDeductionType As System.Windows.Forms.ComboBox
    Friend WithEvents btnLoadCollection As System.Windows.Forms.Button
    Friend WithEvents lblCollectionHeader As System.Windows.Forms.Label
    Friend WithEvents dtpPaymentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContributionDate As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTypeId As System.Windows.Forms.ComboBox
    Friend WithEvents dgvLoanBillingDetails As System.Windows.Forms.DataGridView
    Friend WithEvents tabContributionRecords As System.Windows.Forms.TabPage
    Friend WithEvents dgvContributionBillingDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalContributionDue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmountDue As System.Windows.Forms.TextBox
    Friend WithEvents colMemberId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonthlyPayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanInterest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colclosed As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanBillId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContribution As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPabaon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMortuary As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPSLink As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOATotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colContributionBillId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
