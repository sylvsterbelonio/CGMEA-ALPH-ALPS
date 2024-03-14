<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPayment))
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.chkDeleteFl = New System.Windows.Forms.CheckBox
        Me.chkOnlineFl = New System.Windows.Forms.CheckBox
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
        Me.grpPaymentType = New System.Windows.Forms.GroupBox
        Me.rbCashCheque = New System.Windows.Forms.RadioButton
        Me.rbCheque = New System.Windows.Forms.RadioButton
        Me.rbCash = New System.Windows.Forms.RadioButton
        Me.grpCashChequeMemo = New System.Windows.Forms.GroupBox
        Me.cboBankName = New System.Windows.Forms.ComboBox
        Me.cboBankId = New System.Windows.Forms.ComboBox
        Me.dgvCheckDetails = New System.Windows.Forms.DataGridView
        Me.colBankId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBankName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBranchName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colCheckDate = New Common.CalendarColumn
        Me.colCheckRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblORAmount = New System.Windows.Forms.Label
        Me.txtCashAmount = New System.Windows.Forms.TextBox
        Me.txtORAmount = New System.Windows.Forms.TextBox
        Me.lblCashAmount = New System.Windows.Forms.Label
        Me.lblCheckAmount = New System.Windows.Forms.Label
        Me.txtCheckAmount = New System.Windows.Forms.TextBox
        Me.pnlTotalPayable = New System.Windows.Forms.Panel
        Me.lblTotalAmountPayable = New System.Windows.Forms.Label
        Me.txtTotalAmountPayable = New System.Windows.Forms.TextBox
        Me.lblTotalAmountDue = New System.Windows.Forms.Label
        Me.txtTotalAmountDue = New System.Windows.Forms.TextBox
        Me.txtCollectorId = New System.Windows.Forms.TextBox
        Me.lblCollectorName = New System.Windows.Forms.Label
        Me.txtCollectorName = New System.Windows.Forms.TextBox
        Me.txtTaxCreditAvailable = New System.Windows.Forms.TextBox
        Me.lblTaxCreditAvailable = New System.Windows.Forms.Label
        Me.chkSaveCredit = New System.Windows.Forms.CheckBox
        Me.lblAmountChange = New System.Windows.Forms.Label
        Me.txtAmountChange = New System.Windows.Forms.TextBox
        Me.lblTaxCreditAmount = New System.Windows.Forms.Label
        Me.txtTaxCreditAmount = New System.Windows.Forms.TextBox
        Me.grpBillingStatement = New System.Windows.Forms.GroupBox
        Me.cboTypeName = New System.Windows.Forms.ComboBox
        Me.cboTypeId = New System.Windows.Forms.ComboBox
        Me.dgvBillingDetails = New System.Windows.Forms.DataGridView
        Me.colchkCollectible = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.colTypeId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colTypeName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colBillingId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colAmountDue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colDueDate = New Common.CalendarColumn
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReferenceId3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRebatesAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colUnusedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colReferenceId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colInterest = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalendarColumn1 = New Common.CalendarColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalendarColumn2 = New Common.CalendarColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CalendarColumn3 = New Common.CalendarColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmnsPayment = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.StartORNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ClearCollectibleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadLoanScheduleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintOfficialReceiptToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pnlToolbar.SuspendLayout()
        Me.grpPaymentDetails.SuspendLayout()
        Me.grpPaymentType.SuspendLayout()
        Me.grpCashChequeMemo.SuspendLayout()
        CType(Me.dgvCheckDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTotalPayable.SuspendLayout()
        Me.grpBillingStatement.SuspendLayout()
        CType(Me.dgvBillingDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmnsPayment.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pnlToolbar.Size = New System.Drawing.Size(974, 40)
        Me.pnlToolbar.TabIndex = 164
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
        Me.tbrMainForm.Size = New System.Drawing.Size(974, 40)
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
        Me.grpPaymentDetails.Controls.Add(Me.chkDeleteFl)
        Me.grpPaymentDetails.Controls.Add(Me.chkOnlineFl)
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
        Me.grpPaymentDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPaymentDetails.Location = New System.Drawing.Point(10, 50)
        Me.grpPaymentDetails.Name = "grpPaymentDetails"
        Me.grpPaymentDetails.Size = New System.Drawing.Size(570, 140)
        Me.grpPaymentDetails.TabIndex = 0
        Me.grpPaymentDetails.TabStop = False
        Me.grpPaymentDetails.Text = "Payment Details"
        '
        'chkDeleteFl
        '
        Me.chkDeleteFl.AutoSize = True
        Me.chkDeleteFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDeleteFl.Location = New System.Drawing.Point(100, 118)
        Me.chkDeleteFl.Name = "chkDeleteFl"
        Me.chkDeleteFl.Size = New System.Drawing.Size(15, 14)
        Me.chkDeleteFl.TabIndex = 169
        Me.chkDeleteFl.TabStop = False
        Me.chkDeleteFl.Tag = "0"
        Me.chkDeleteFl.Visible = False
        '
        'chkOnlineFl
        '
        Me.chkOnlineFl.AutoSize = True
        Me.chkOnlineFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOnlineFl.Location = New System.Drawing.Point(55, 115)
        Me.chkOnlineFl.Name = "chkOnlineFl"
        Me.chkOnlineFl.Size = New System.Drawing.Size(15, 14)
        Me.chkOnlineFl.TabIndex = 168
        Me.chkOnlineFl.TabStop = False
        Me.chkOnlineFl.Tag = "0"
        Me.chkOnlineFl.Visible = False
        '
        'chkBillingFl
        '
        Me.chkBillingFl.AutoSize = True
        Me.chkBillingFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBillingFl.Location = New System.Drawing.Point(35, 115)
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
        Me.txtRefId.Location = New System.Drawing.Point(75, 115)
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
        Me.chkCancelFl.Location = New System.Drawing.Point(15, 115)
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
        Me.lblAccountMemoRemarks.Location = New System.Drawing.Point(15, 85)
        Me.lblAccountMemoRemarks.Name = "lblAccountMemoRemarks"
        Me.lblAccountMemoRemarks.Size = New System.Drawing.Size(100, 16)
        Me.lblAccountMemoRemarks.TabIndex = 8
        Me.lblAccountMemoRemarks.Text = "Remarks"
        '
        'txtPaymentRemarks
        '
        Me.txtPaymentRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaymentRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPaymentRemarks.Location = New System.Drawing.Point(125, 85)
        Me.txtPaymentRemarks.Multiline = True
        Me.txtPaymentRemarks.Name = "txtPaymentRemarks"
        Me.txtPaymentRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPaymentRemarks.Size = New System.Drawing.Size(435, 40)
        Me.txtPaymentRemarks.TabIndex = 9
        '
        'txtMemberId
        '
        Me.txtMemberId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberId.Location = New System.Drawing.Point(540, 55)
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
        Me.txtORNo.Location = New System.Drawing.Point(125, 25)
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
        Me.lblORDt.Location = New System.Drawing.Point(290, 25)
        Me.lblORDt.Name = "lblORDt"
        Me.lblORDt.Size = New System.Drawing.Size(105, 16)
        Me.lblORDt.TabIndex = 2
        Me.lblORDt.Text = "Official Receipt Date"
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(125, 55)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(435, 20)
        Me.txtMemberName.TabIndex = 6
        '
        'dtpORDt
        '
        Me.dtpORDt.Checked = False
        Me.dtpORDt.CustomFormat = "MMMM dd, yyyy"
        Me.dtpORDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpORDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpORDt.Location = New System.Drawing.Point(410, 25)
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
        Me.lblMemberName.Location = New System.Drawing.Point(15, 55)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(100, 16)
        Me.lblMemberName.TabIndex = 5
        Me.lblMemberName.Text = "Payor Name *"
        '
        'grpPaymentType
        '
        Me.grpPaymentType.BackColor = System.Drawing.Color.Transparent
        Me.grpPaymentType.Controls.Add(Me.rbCashCheque)
        Me.grpPaymentType.Controls.Add(Me.rbCheque)
        Me.grpPaymentType.Controls.Add(Me.rbCash)
        Me.grpPaymentType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpPaymentType.Location = New System.Drawing.Point(585, 80)
        Me.grpPaymentType.Name = "grpPaymentType"
        Me.grpPaymentType.Size = New System.Drawing.Size(385, 110)
        Me.grpPaymentType.TabIndex = 1
        Me.grpPaymentType.TabStop = False
        Me.grpPaymentType.Text = "Payment Type"
        '
        'rbCashCheque
        '
        Me.rbCashCheque.AutoSize = True
        Me.rbCashCheque.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCashCheque.Location = New System.Drawing.Point(15, 73)
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
        Me.rbCheque.Location = New System.Drawing.Point(15, 49)
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
        Me.rbCash.Location = New System.Drawing.Point(15, 25)
        Me.rbCash.Name = "rbCash"
        Me.rbCash.Size = New System.Drawing.Size(75, 18)
        Me.rbCash.TabIndex = 0
        Me.rbCash.TabStop = True
        Me.rbCash.Text = "Cash Only"
        Me.rbCash.UseVisualStyleBackColor = True
        '
        'grpCashChequeMemo
        '
        Me.grpCashChequeMemo.BackColor = System.Drawing.Color.Transparent
        Me.grpCashChequeMemo.Controls.Add(Me.cboBankName)
        Me.grpCashChequeMemo.Controls.Add(Me.cboBankId)
        Me.grpCashChequeMemo.Controls.Add(Me.dgvCheckDetails)
        Me.grpCashChequeMemo.Controls.Add(Me.lblORAmount)
        Me.grpCashChequeMemo.Controls.Add(Me.txtCashAmount)
        Me.grpCashChequeMemo.Controls.Add(Me.txtORAmount)
        Me.grpCashChequeMemo.Controls.Add(Me.lblCashAmount)
        Me.grpCashChequeMemo.Controls.Add(Me.lblCheckAmount)
        Me.grpCashChequeMemo.Controls.Add(Me.txtCheckAmount)
        Me.grpCashChequeMemo.Location = New System.Drawing.Point(10, 185)
        Me.grpCashChequeMemo.Name = "grpCashChequeMemo"
        Me.grpCashChequeMemo.Size = New System.Drawing.Size(960, 165)
        Me.grpCashChequeMemo.TabIndex = 2
        Me.grpCashChequeMemo.TabStop = False
        '
        'cboBankName
        '
        Me.cboBankName.FormattingEnabled = True
        Me.cboBankName.Location = New System.Drawing.Point(370, 10)
        Me.cboBankName.Name = "cboBankName"
        Me.cboBankName.Size = New System.Drawing.Size(25, 22)
        Me.cboBankName.TabIndex = 141
        Me.cboBankName.TabStop = False
        Me.cboBankName.Visible = False
        '
        'cboBankId
        '
        Me.cboBankId.FormattingEnabled = True
        Me.cboBankId.Location = New System.Drawing.Point(340, 10)
        Me.cboBankId.Name = "cboBankId"
        Me.cboBankId.Size = New System.Drawing.Size(25, 22)
        Me.cboBankId.TabIndex = 140
        Me.cboBankId.TabStop = False
        Me.cboBankId.Visible = False
        '
        'dgvCheckDetails
        '
        Me.dgvCheckDetails.AllowUserToResizeRows = False
        Me.dgvCheckDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCheckDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvCheckDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCheckDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBankId, Me.colBankName, Me.colBranchName, Me.colCheckNo, Me.colCheckAmount, Me.colCheckDate, Me.colCheckRemarks})
        Me.dgvCheckDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvCheckDetails.Location = New System.Drawing.Point(350, 25)
        Me.dgvCheckDetails.MultiSelect = False
        Me.dgvCheckDetails.Name = "dgvCheckDetails"
        Me.dgvCheckDetails.RowHeadersWidth = 50
        Me.dgvCheckDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvCheckDetails.ShowCellToolTips = False
        Me.dgvCheckDetails.Size = New System.Drawing.Size(600, 125)
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
        'lblORAmount
        '
        Me.lblORAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORAmount.Location = New System.Drawing.Point(15, 130)
        Me.lblORAmount.Name = "lblORAmount"
        Me.lblORAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblORAmount.TabIndex = 6
        Me.lblORAmount.Text = "Total OR Amount"
        '
        'txtCashAmount
        '
        Me.txtCashAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashAmount.Location = New System.Drawing.Point(125, 25)
        Me.txtCashAmount.Name = "txtCashAmount"
        Me.txtCashAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtCashAmount.TabIndex = 1
        Me.txtCashAmount.Text = "0.00"
        Me.txtCashAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtORAmount
        '
        Me.txtORAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORAmount.Location = New System.Drawing.Point(125, 130)
        Me.txtORAmount.Name = "txtORAmount"
        Me.txtORAmount.ReadOnly = True
        Me.txtORAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtORAmount.TabIndex = 7
        Me.txtORAmount.TabStop = False
        Me.txtORAmount.Text = "0.00"
        Me.txtORAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCashAmount
        '
        Me.lblCashAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCashAmount.Location = New System.Drawing.Point(15, 25)
        Me.lblCashAmount.Name = "lblCashAmount"
        Me.lblCashAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblCashAmount.TabIndex = 0
        Me.lblCashAmount.Text = "Cash Amount"
        '
        'lblCheckAmount
        '
        Me.lblCheckAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCheckAmount.Location = New System.Drawing.Point(15, 55)
        Me.lblCheckAmount.Name = "lblCheckAmount"
        Me.lblCheckAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblCheckAmount.TabIndex = 2
        Me.lblCheckAmount.Text = "Cheque Amount "
        '
        'txtCheckAmount
        '
        Me.txtCheckAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheckAmount.Location = New System.Drawing.Point(125, 55)
        Me.txtCheckAmount.Name = "txtCheckAmount"
        Me.txtCheckAmount.ReadOnly = True
        Me.txtCheckAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtCheckAmount.TabIndex = 3
        Me.txtCheckAmount.TabStop = False
        Me.txtCheckAmount.Text = "0.00"
        Me.txtCheckAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlTotalPayable
        '
        Me.pnlTotalPayable.BackColor = System.Drawing.SystemColors.Info
        Me.pnlTotalPayable.Controls.Add(Me.lblTotalAmountPayable)
        Me.pnlTotalPayable.Controls.Add(Me.txtTotalAmountPayable)
        Me.pnlTotalPayable.Controls.Add(Me.lblTotalAmountDue)
        Me.pnlTotalPayable.Controls.Add(Me.txtTotalAmountDue)
        Me.pnlTotalPayable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTotalPayable.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlTotalPayable.Location = New System.Drawing.Point(10, 515)
        Me.pnlTotalPayable.Name = "pnlTotalPayable"
        Me.pnlTotalPayable.Size = New System.Drawing.Size(960, 50)
        Me.pnlTotalPayable.TabIndex = 4
        '
        'lblTotalAmountPayable
        '
        Me.lblTotalAmountPayable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmountPayable.Location = New System.Drawing.Point(520, 10)
        Me.lblTotalAmountPayable.Name = "lblTotalAmountPayable"
        Me.lblTotalAmountPayable.Size = New System.Drawing.Size(200, 16)
        Me.lblTotalAmountPayable.TabIndex = 2
        Me.lblTotalAmountPayable.Text = "TOTAL AMOUNT PAID"
        '
        'txtTotalAmountPayable
        '
        Me.txtTotalAmountPayable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmountPayable.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmountPayable.Location = New System.Drawing.Point(730, 10)
        Me.txtTotalAmountPayable.Name = "txtTotalAmountPayable"
        Me.txtTotalAmountPayable.ReadOnly = True
        Me.txtTotalAmountPayable.Size = New System.Drawing.Size(220, 26)
        Me.txtTotalAmountPayable.TabIndex = 3
        Me.txtTotalAmountPayable.TabStop = False
        Me.txtTotalAmountPayable.Text = "0.00"
        Me.txtTotalAmountPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmountDue
        '
        Me.lblTotalAmountDue.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAmountDue.Location = New System.Drawing.Point(5, 10)
        Me.lblTotalAmountDue.Name = "lblTotalAmountDue"
        Me.lblTotalAmountDue.Size = New System.Drawing.Size(200, 16)
        Me.lblTotalAmountDue.TabIndex = 0
        Me.lblTotalAmountDue.Text = "TOTAL AMOUNT DUE"
        '
        'txtTotalAmountDue
        '
        Me.txtTotalAmountDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalAmountDue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmountDue.Location = New System.Drawing.Point(215, 10)
        Me.txtTotalAmountDue.Name = "txtTotalAmountDue"
        Me.txtTotalAmountDue.ReadOnly = True
        Me.txtTotalAmountDue.Size = New System.Drawing.Size(220, 26)
        Me.txtTotalAmountDue.TabIndex = 1
        Me.txtTotalAmountDue.TabStop = False
        Me.txtTotalAmountDue.Text = "0.00"
        Me.txtTotalAmountDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCollectorId
        '
        Me.txtCollectorId.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectorId.Location = New System.Drawing.Point(945, 55)
        Me.txtCollectorId.Name = "txtCollectorId"
        Me.txtCollectorId.ReadOnly = True
        Me.txtCollectorId.Size = New System.Drawing.Size(26, 22)
        Me.txtCollectorId.TabIndex = 6
        Me.txtCollectorId.TabStop = False
        Me.txtCollectorId.Visible = False
        '
        'lblCollectorName
        '
        Me.lblCollectorName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectorName.Location = New System.Drawing.Point(590, 55)
        Me.lblCollectorName.Name = "lblCollectorName"
        Me.lblCollectorName.Size = New System.Drawing.Size(180, 20)
        Me.lblCollectorName.TabIndex = 4
        Me.lblCollectorName.Text = "COLLECTOR NAME"
        '
        'txtCollectorName
        '
        Me.txtCollectorName.BackColor = System.Drawing.Color.White
        Me.txtCollectorName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCollectorName.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectorName.Location = New System.Drawing.Point(770, 55)
        Me.txtCollectorName.Name = "txtCollectorName"
        Me.txtCollectorName.ReadOnly = True
        Me.txtCollectorName.Size = New System.Drawing.Size(200, 22)
        Me.txtCollectorName.TabIndex = 5
        Me.txtCollectorName.TabStop = False
        '
        'txtTaxCreditAvailable
        '
        Me.txtTaxCreditAvailable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxCreditAvailable.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxCreditAvailable.Location = New System.Drawing.Point(434, 435)
        Me.txtTaxCreditAvailable.Name = "txtTaxCreditAvailable"
        Me.txtTaxCreditAvailable.ReadOnly = True
        Me.txtTaxCreditAvailable.Size = New System.Drawing.Size(26, 26)
        Me.txtTaxCreditAvailable.TabIndex = 10
        Me.txtTaxCreditAvailable.TabStop = False
        Me.txtTaxCreditAvailable.Text = "0.00"
        Me.txtTaxCreditAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxCreditAvailable.Visible = False
        '
        'lblTaxCreditAvailable
        '
        Me.lblTaxCreditAvailable.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxCreditAvailable.ForeColor = System.Drawing.Color.Red
        Me.lblTaxCreditAvailable.Location = New System.Drawing.Point(55, 450)
        Me.lblTaxCreditAvailable.Name = "lblTaxCreditAvailable"
        Me.lblTaxCreditAvailable.Size = New System.Drawing.Size(200, 30)
        Me.lblTaxCreditAvailable.TabIndex = 8
        Me.lblTaxCreditAvailable.Text = "(Php 1,000,000,000,000,000,000.00 credit available)"
        Me.lblTaxCreditAvailable.Visible = False
        '
        'chkSaveCredit
        '
        Me.chkSaveCredit.AutoSize = True
        Me.chkSaveCredit.Enabled = False
        Me.chkSaveCredit.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSaveCredit.Location = New System.Drawing.Point(120, 390)
        Me.chkSaveCredit.Name = "chkSaveCredit"
        Me.chkSaveCredit.Size = New System.Drawing.Size(131, 17)
        Me.chkSaveCredit.TabIndex = 5
        Me.chkSaveCredit.Tag = "0"
        Me.chkSaveCredit.Text = "Save to Tax Credit?"
        Me.chkSaveCredit.Visible = False
        '
        'lblAmountChange
        '
        Me.lblAmountChange.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmountChange.Location = New System.Drawing.Point(55, 390)
        Me.lblAmountChange.Name = "lblAmountChange"
        Me.lblAmountChange.Size = New System.Drawing.Size(200, 16)
        Me.lblAmountChange.TabIndex = 4
        Me.lblAmountChange.Text = "CHANGE"
        Me.lblAmountChange.Visible = False
        '
        'txtAmountChange
        '
        Me.txtAmountChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmountChange.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountChange.Location = New System.Drawing.Point(260, 390)
        Me.txtAmountChange.Name = "txtAmountChange"
        Me.txtAmountChange.ReadOnly = True
        Me.txtAmountChange.Size = New System.Drawing.Size(200, 26)
        Me.txtAmountChange.TabIndex = 6
        Me.txtAmountChange.TabStop = False
        Me.txtAmountChange.Text = "0.00"
        Me.txtAmountChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtAmountChange.Visible = False
        '
        'lblTaxCreditAmount
        '
        Me.lblTaxCreditAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxCreditAmount.Location = New System.Drawing.Point(55, 435)
        Me.lblTaxCreditAmount.Name = "lblTaxCreditAmount"
        Me.lblTaxCreditAmount.Size = New System.Drawing.Size(200, 30)
        Me.lblTaxCreditAmount.TabIndex = 7
        Me.lblTaxCreditAmount.Text = "USE TAX CREDIT? "
        Me.lblTaxCreditAmount.Visible = False
        '
        'txtTaxCreditAmount
        '
        Me.txtTaxCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTaxCreditAmount.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaxCreditAmount.Location = New System.Drawing.Point(260, 435)
        Me.txtTaxCreditAmount.Name = "txtTaxCreditAmount"
        Me.txtTaxCreditAmount.ReadOnly = True
        Me.txtTaxCreditAmount.Size = New System.Drawing.Size(200, 26)
        Me.txtTaxCreditAmount.TabIndex = 9
        Me.txtTaxCreditAmount.TabStop = False
        Me.txtTaxCreditAmount.Text = "0.00"
        Me.txtTaxCreditAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTaxCreditAmount.Visible = False
        '
        'grpBillingStatement
        '
        Me.grpBillingStatement.BackColor = System.Drawing.Color.Transparent
        Me.grpBillingStatement.Controls.Add(Me.cboTypeName)
        Me.grpBillingStatement.Controls.Add(Me.cboTypeId)
        Me.grpBillingStatement.Controls.Add(Me.dgvBillingDetails)
        Me.grpBillingStatement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBillingStatement.Location = New System.Drawing.Point(10, 355)
        Me.grpBillingStatement.Name = "grpBillingStatement"
        Me.grpBillingStatement.Size = New System.Drawing.Size(960, 155)
        Me.grpBillingStatement.TabIndex = 3
        Me.grpBillingStatement.TabStop = False
        Me.grpBillingStatement.Text = "Collectible Records"
        '
        'cboTypeName
        '
        Me.cboTypeName.FormattingEnabled = True
        Me.cboTypeName.Location = New System.Drawing.Point(40, 20)
        Me.cboTypeName.Name = "cboTypeName"
        Me.cboTypeName.Size = New System.Drawing.Size(25, 22)
        Me.cboTypeName.TabIndex = 143
        Me.cboTypeName.TabStop = False
        Me.cboTypeName.Visible = False
        '
        'cboTypeId
        '
        Me.cboTypeId.FormattingEnabled = True
        Me.cboTypeId.Location = New System.Drawing.Point(10, 20)
        Me.cboTypeId.Name = "cboTypeId"
        Me.cboTypeId.Size = New System.Drawing.Size(25, 22)
        Me.cboTypeId.TabIndex = 142
        Me.cboTypeId.TabStop = False
        Me.cboTypeId.Visible = False
        '
        'dgvBillingDetails
        '
        Me.dgvBillingDetails.AllowUserToResizeRows = False
        Me.dgvBillingDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBillingDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvBillingDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBillingDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colchkCollectible, Me.colTypeId, Me.colTypeName, Me.colBillingId, Me.colAmountDue, Me.colDueDate, Me.colAmount, Me.colRemarks, Me.colReferenceId3, Me.colRebatesAmount, Me.colUnusedAmount, Me.colReferenceId, Me.colInterest, Me.colLoanType})
        Me.dgvBillingDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvBillingDetails.Location = New System.Drawing.Point(10, 20)
        Me.dgvBillingDetails.MultiSelect = False
        Me.dgvBillingDetails.Name = "dgvBillingDetails"
        Me.dgvBillingDetails.RowHeadersWidth = 50
        Me.dgvBillingDetails.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvBillingDetails.ShowCellToolTips = False
        Me.dgvBillingDetails.Size = New System.Drawing.Size(940, 130)
        Me.dgvBillingDetails.TabIndex = 0
        Me.dgvBillingDetails.Tag = "0"
        '
        'colchkCollectible
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.NullValue = False
        Me.colchkCollectible.DefaultCellStyle = DataGridViewCellStyle4
        Me.colchkCollectible.FalseValue = "0"
        Me.colchkCollectible.HeaderText = ""
        Me.colchkCollectible.MinimumWidth = 25
        Me.colchkCollectible.Name = "colchkCollectible"
        Me.colchkCollectible.ToolTipText = "0"
        Me.colchkCollectible.TrueValue = "1"
        Me.colchkCollectible.Width = 25
        '
        'colTypeId
        '
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = "0"
        Me.colTypeId.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTypeId.HeaderText = "Type Id"
        Me.colTypeId.Name = "colTypeId"
        Me.colTypeId.ReadOnly = True
        Me.colTypeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTypeId.ToolTipText = "1"
        Me.colTypeId.Visible = False
        Me.colTypeId.Width = 5
        '
        'colTypeName
        '
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colTypeName.DefaultCellStyle = DataGridViewCellStyle6
        Me.colTypeName.HeaderText = "COLLECTION NAME"
        Me.colTypeName.MinimumWidth = 200
        Me.colTypeName.Name = "colTypeName"
        Me.colTypeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colTypeName.ToolTipText = "0"
        Me.colTypeName.Width = 200
        '
        'colBillingId
        '
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = "0"
        Me.colBillingId.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBillingId.HeaderText = "Billing Id"
        Me.colBillingId.Name = "colBillingId"
        Me.colBillingId.ReadOnly = True
        Me.colBillingId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colBillingId.ToolTipText = "1"
        Me.colBillingId.Visible = False
        Me.colBillingId.Width = 5
        '
        'colAmountDue
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = "0.00"
        Me.colAmountDue.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAmountDue.HeaderText = "AMOUNT DUE"
        Me.colAmountDue.MinimumWidth = 85
        Me.colAmountDue.Name = "colAmountDue"
        Me.colAmountDue.ReadOnly = True
        Me.colAmountDue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colAmountDue.ToolTipText = "1"
        Me.colAmountDue.Width = 85
        '
        'colDueDate
        '
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colDueDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.colDueDate.HeaderText = "DUE DATE"
        Me.colDueDate.MinimumWidth = 70
        Me.colDueDate.Name = "colDueDate"
        Me.colDueDate.ReadOnly = True
        Me.colDueDate.ToolTipText = "1"
        Me.colDueDate.Width = 70
        '
        'colAmount
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = "0.00"
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle10
        Me.colAmount.HeaderText = "TOTAL AMOUNT"
        Me.colAmount.MinimumWidth = 125
        Me.colAmount.Name = "colAmount"
        Me.colAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colAmount.ToolTipText = "0"
        Me.colAmount.Width = 125
        '
        'colRemarks
        '
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colRemarks.DefaultCellStyle = DataGridViewCellStyle11
        Me.colRemarks.HeaderText = "REMARKS"
        Me.colRemarks.MinimumWidth = 275
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colRemarks.ToolTipText = "0"
        Me.colRemarks.Width = 275
        '
        'colReferenceId3
        '
        DataGridViewCellStyle12.Format = "N0"
        DataGridViewCellStyle12.NullValue = "0"
        Me.colReferenceId3.DefaultCellStyle = DataGridViewCellStyle12
        Me.colReferenceId3.HeaderText = "RefId3"
        Me.colReferenceId3.Name = "colReferenceId3"
        Me.colReferenceId3.ReadOnly = True
        Me.colReferenceId3.ToolTipText = "1"
        Me.colReferenceId3.Visible = False
        Me.colReferenceId3.Width = 5
        '
        'colRebatesAmount
        '
        Me.colRebatesAmount.HeaderText = "Rebates"
        Me.colRebatesAmount.Name = "colRebatesAmount"
        Me.colRebatesAmount.ReadOnly = True
        Me.colRebatesAmount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colRebatesAmount.ToolTipText = "1"
        Me.colRebatesAmount.Visible = False
        Me.colRebatesAmount.Width = 5
        '
        'colUnusedAmount
        '
        Me.colUnusedAmount.HeaderText = "Unused"
        Me.colUnusedAmount.Name = "colUnusedAmount"
        Me.colUnusedAmount.ReadOnly = True
        Me.colUnusedAmount.ToolTipText = "1"
        Me.colUnusedAmount.Visible = False
        Me.colUnusedAmount.Width = 5
        '
        'colReferenceId
        '
        Me.colReferenceId.HeaderText = "RefId"
        Me.colReferenceId.Name = "colReferenceId"
        Me.colReferenceId.ReadOnly = True
        Me.colReferenceId.ToolTipText = "1"
        Me.colReferenceId.Visible = False
        Me.colReferenceId.Width = 5
        '
        'colInterest
        '
        Me.colInterest.HeaderText = "Interest"
        Me.colInterest.Name = "colInterest"
        Me.colInterest.ReadOnly = True
        Me.colInterest.Visible = False
        '
        'colLoanType
        '
        Me.colLoanType.HeaderText = "Loan Type"
        Me.colLoanType.Name = "colLoanType"
        Me.colLoanType.ReadOnly = True
        Me.colLoanType.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn1.HeaderText = "Memo No."
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn2
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn2.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 80
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.HeaderText = "Memo Date"
        Me.CalendarColumn1.MinimumWidth = 80
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.ToolTipText = "0"
        Me.CalendarColumn1.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 280
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn3.Width = 280
        '
        'DataGridViewTextBoxColumn4
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.Format = "N0"
        DataGridViewCellStyle15.NullValue = "0"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn4.HeaderText = "BankId"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.ToolTipText = "1"
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 5
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Bank Name"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 125
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn5.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn5.Width = 125
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Branch Name"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 125
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn6.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn6.Width = 125
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle16
        Me.DataGridViewTextBoxColumn7.HeaderText = "Check No."
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn7.ToolTipText = "0"
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle17
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 100
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn8.ToolTipText = "0"
        '
        'CalendarColumn2
        '
        Me.CalendarColumn2.HeaderText = "Check Date"
        Me.CalendarColumn2.MinimumWidth = 100
        Me.CalendarColumn2.Name = "CalendarColumn2"
        Me.CalendarColumn2.ToolTipText = "0"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn9.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn9.Width = 200
        '
        'DataGridViewTextBoxColumn10
        '
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.NullValue = "0"
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle18
        Me.DataGridViewTextBoxColumn10.HeaderText = "Type Id"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn10.ToolTipText = "1"
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 5
        '
        'DataGridViewTextBoxColumn11
        '
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewTextBoxColumn11.HeaderText = "Collection Name"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 200
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn11.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn11.Width = 200
        '
        'DataGridViewTextBoxColumn12
        '
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.NullValue = "0"
        Me.DataGridViewTextBoxColumn12.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewTextBoxColumn12.HeaderText = "Billing Id"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn12.ToolTipText = "1"
        Me.DataGridViewTextBoxColumn12.Visible = False
        Me.DataGridViewTextBoxColumn12.Width = 5
        '
        'DataGridViewTextBoxColumn13
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = "0"
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewTextBoxColumn13.HeaderText = "Amount Due"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn13.ToolTipText = "1"
        Me.DataGridViewTextBoxColumn13.Visible = False
        Me.DataGridViewTextBoxColumn13.Width = 5
        '
        'CalendarColumn3
        '
        Me.CalendarColumn3.HeaderText = "Due Date"
        Me.CalendarColumn3.Name = "CalendarColumn3"
        Me.CalendarColumn3.ReadOnly = True
        Me.CalendarColumn3.ToolTipText = "1"
        Me.CalendarColumn3.Visible = False
        Me.CalendarColumn3.Width = 5
        '
        'DataGridViewTextBoxColumn14
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = "0.00"
        Me.DataGridViewTextBoxColumn14.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewTextBoxColumn14.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn14.MinimumWidth = 115
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn14.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn14.Width = 115
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn15.MinimumWidth = 275
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn15.ToolTipText = "0"
        Me.DataGridViewTextBoxColumn15.Width = 275
        '
        'cmnsPayment
        '
        Me.cmnsPayment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartORNoToolStripMenuItem, Me.ToolStripSeparator1, Me.ClearCollectibleToolStripMenuItem, Me.LoadLoanScheduleToolStripMenuItem, Me.ToolStripMenuItem1, Me.PrintOfficialReceiptToolStripMenuItem})
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
        'LoadLoanScheduleToolStripMenuItem
        '
        Me.LoadLoanScheduleToolStripMenuItem.Name = "LoadLoanScheduleToolStripMenuItem"
        Me.LoadLoanScheduleToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.LoadLoanScheduleToolStripMenuItem.Text = "Load Loan Balance"
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
        'frmPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(974, 572)
        Me.ContextMenuStrip = Me.cmnsPayment
        Me.Controls.Add(Me.lblCollectorName)
        Me.Controls.Add(Me.grpBillingStatement)
        Me.Controls.Add(Me.txtCollectorId)
        Me.Controls.Add(Me.pnlTotalPayable)
        Me.Controls.Add(Me.txtCollectorName)
        Me.Controls.Add(Me.chkSaveCredit)
        Me.Controls.Add(Me.lblAmountChange)
        Me.Controls.Add(Me.grpPaymentType)
        Me.Controls.Add(Me.grpPaymentDetails)
        Me.Controls.Add(Me.txtAmountChange)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.grpCashChequeMemo)
        Me.Controls.Add(Me.lblTaxCreditAmount)
        Me.Controls.Add(Me.txtTaxCreditAmount)
        Me.Controls.Add(Me.txtTaxCreditAvailable)
        Me.Controls.Add(Me.lblTaxCreditAvailable)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPayment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposits, Loans and Miscellaneous Payment"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.grpPaymentDetails.ResumeLayout(False)
        Me.grpPaymentDetails.PerformLayout()
        Me.grpPaymentType.ResumeLayout(False)
        Me.grpPaymentType.PerformLayout()
        Me.grpCashChequeMemo.ResumeLayout(False)
        Me.grpCashChequeMemo.PerformLayout()
        CType(Me.dgvCheckDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTotalPayable.ResumeLayout(False)
        Me.pnlTotalPayable.PerformLayout()
        Me.grpBillingStatement.ResumeLayout(False)
        CType(Me.dgvBillingDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmnsPayment.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents lblORNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents lblORDt As System.Windows.Forms.Label
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents dtpORDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents lblAccountMemoRemarks As System.Windows.Forms.Label
    Friend WithEvents txtPaymentRemarks As System.Windows.Forms.TextBox
    Friend WithEvents grpPaymentType As System.Windows.Forms.GroupBox
    Friend WithEvents rbCashCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbCash As System.Windows.Forms.RadioButton
    Friend WithEvents grpCashChequeMemo As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCheckDetails As System.Windows.Forms.DataGridView
    Friend WithEvents lblORAmount As System.Windows.Forms.Label
    Friend WithEvents txtCashAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtORAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblCashAmount As System.Windows.Forms.Label
    Friend WithEvents lblCheckAmount As System.Windows.Forms.Label
    Friend WithEvents txtCheckAmount As System.Windows.Forms.TextBox
    Friend WithEvents pnlTotalPayable As System.Windows.Forms.Panel
    Friend WithEvents txtTaxCreditAvailable As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxCreditAvailable As System.Windows.Forms.Label
    Friend WithEvents chkSaveCredit As System.Windows.Forms.CheckBox
    Friend WithEvents lblAmountChange As System.Windows.Forms.Label
    Friend WithEvents txtAmountChange As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmountPayable As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmountPayable As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxCreditAmount As System.Windows.Forms.Label
    Friend WithEvents txtTaxCreditAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmountDue As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmountDue As System.Windows.Forms.TextBox
    Friend WithEvents grpBillingStatement As System.Windows.Forms.GroupBox
    Friend WithEvents dgvBillingDetails As System.Windows.Forms.DataGridView
    Friend WithEvents txtCollectorId As System.Windows.Forms.TextBox
    Friend WithEvents lblCollectorName As System.Windows.Forms.Label
    Friend WithEvents txtCollectorName As System.Windows.Forms.TextBox
    Friend WithEvents colBankId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBranchName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCheckDate As Common.CalendarColumn
    Friend WithEvents colCheckRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtRefId As System.Windows.Forms.TextBox
    Friend WithEvents chkCancelFl As System.Windows.Forms.CheckBox
    Friend WithEvents cboBankName As System.Windows.Forms.ComboBox
    Friend WithEvents cboBankId As System.Windows.Forms.ComboBox
    Friend WithEvents cboTypeName As System.Windows.Forms.ComboBox
    Friend WithEvents cboTypeId As System.Windows.Forms.ComboBox
    Friend WithEvents chkBillingFl As System.Windows.Forms.CheckBox
    Friend WithEvents chkOnlineFl As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As Common.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn2 As Common.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn3 As Common.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmnsPayment As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintOfficialReceiptToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearCollectibleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadLoanScheduleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StartORNoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents chkDeleteFl As System.Windows.Forms.CheckBox
    Friend WithEvents colchkCollectible As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTypeId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTypeName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillingId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountDue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDueDate As Common.CalendarColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReferenceId3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRebatesAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnusedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReferenceId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInterest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanType As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
