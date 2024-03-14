<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberWithdrawal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMemberWithdrawal))
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.lblCheckNo = New System.Windows.Forms.Label
        Me.txtVoucherNo = New System.Windows.Forms.TextBox
        Me.lblVoucherNo = New System.Windows.Forms.Label
        Me.lblCurrentShare = New System.Windows.Forms.Label
        Me.txtCurrentShare = New System.Windows.Forms.TextBox
        Me.lblWithdrawDate = New System.Windows.Forms.Label
        Me.dtpWithrawDate = New System.Windows.Forms.DateTimePicker
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.lblDepartment = New System.Windows.Forms.Label
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.lblCapitalAmount = New System.Windows.Forms.Label
        Me.txtCapitallAmount = New System.Windows.Forms.TextBox
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.lblReceivedBy = New System.Windows.Forms.Label
        Me.txtReceivedBy = New System.Windows.Forms.TextBox
        Me.txtWithdrawalId = New System.Windows.Forms.TextBox
        Me.txtNetProceeds = New System.Windows.Forms.TextBox
        Me.lblNetProceeds = New System.Windows.Forms.Label
        Me.lblInterestIncome = New System.Windows.Forms.Label
        Me.txtInterestIncome = New System.Windows.Forms.TextBox
        Me.lblInterestRate = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(439, 424)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 181
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtCheckNo
        '
        Me.txtCheckNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckNo.Location = New System.Drawing.Point(125, 219)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(202, 20)
        Me.txtCheckNo.TabIndex = 169
        '
        'lblCheckNo
        '
        Me.lblCheckNo.AutoSize = True
        Me.lblCheckNo.Location = New System.Drawing.Point(13, 222)
        Me.lblCheckNo.Name = "lblCheckNo"
        Me.lblCheckNo.Size = New System.Drawing.Size(58, 13)
        Me.lblCheckNo.TabIndex = 168
        Me.lblCheckNo.Text = "Check No."
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVoucherNo.Location = New System.Drawing.Point(125, 193)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(202, 20)
        Me.txtVoucherNo.TabIndex = 165
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(13, 196)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(67, 13)
        Me.lblVoucherNo.TabIndex = 164
        Me.lblVoucherNo.Text = "Voucher No."
        '
        'lblCurrentShare
        '
        Me.lblCurrentShare.AutoSize = True
        Me.lblCurrentShare.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrentShare.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentShare.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrentShare.Location = New System.Drawing.Point(13, 144)
        Me.lblCurrentShare.Name = "lblCurrentShare"
        Me.lblCurrentShare.Size = New System.Drawing.Size(75, 14)
        Me.lblCurrentShare.TabIndex = 170
        Me.lblCurrentShare.Text = "Current Share"
        '
        'txtCurrentShare
        '
        Me.txtCurrentShare.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrentShare.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrentShare.Location = New System.Drawing.Point(125, 141)
        Me.txtCurrentShare.Name = "txtCurrentShare"
        Me.txtCurrentShare.ReadOnly = True
        Me.txtCurrentShare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCurrentShare.Size = New System.Drawing.Size(202, 20)
        Me.txtCurrentShare.TabIndex = 171
        Me.txtCurrentShare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblWithdrawDate
        '
        Me.lblWithdrawDate.AutoSize = True
        Me.lblWithdrawDate.Location = New System.Drawing.Point(13, 69)
        Me.lblWithdrawDate.Name = "lblWithdrawDate"
        Me.lblWithdrawDate.Size = New System.Drawing.Size(78, 13)
        Me.lblWithdrawDate.TabIndex = 172
        Me.lblWithdrawDate.Text = "Date Withdraw"
        '
        'dtpWithrawDate
        '
        Me.dtpWithrawDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpWithrawDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWithrawDate.Location = New System.Drawing.Point(125, 63)
        Me.dtpWithrawDate.Name = "dtpWithrawDate"
        Me.dtpWithrawDate.ShowCheckBox = True
        Me.dtpWithrawDate.Size = New System.Drawing.Size(202, 20)
        Me.dtpWithrawDate.TabIndex = 173
        Me.dtpWithrawDate.Tag = "0"
        '
        'txtDepartment
        '
        Me.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(125, 115)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDepartment.Size = New System.Drawing.Size(414, 20)
        Me.txtDepartment.TabIndex = 161
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartment.Location = New System.Drawing.Point(13, 118)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(62, 14)
        Me.lblDepartment.TabIndex = 160
        Me.lblDepartment.Text = "Department"
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
        'btnAdd
        '
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Add"
        Me.btnAdd.ToolTipText = "Add new record"
        '
        'btnFind
        '
        Me.btnFind.ImageIndex = 3
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Find"
        Me.btnFind.ToolTipText = "Launch Finder Screen"
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(125, 323)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(414, 69)
        Me.txtRemarks.TabIndex = 175
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(13, 326)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 14)
        Me.lblRemarks.TabIndex = 174
        Me.lblRemarks.Text = "Remarks"
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 4
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save Record"
        '
        'lblCapitalAmount
        '
        Me.lblCapitalAmount.AutoSize = True
        Me.lblCapitalAmount.BackColor = System.Drawing.SystemColors.Control
        Me.lblCapitalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapitalAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapitalAmount.Location = New System.Drawing.Point(13, 248)
        Me.lblCapitalAmount.Name = "lblCapitalAmount"
        Me.lblCapitalAmount.Size = New System.Drawing.Size(103, 14)
        Me.lblCapitalAmount.TabIndex = 166
        Me.lblCapitalAmount.Text = "Total Capital Amount"
        '
        'txtCapitallAmount
        '
        Me.txtCapitallAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapitallAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapitallAmount.Location = New System.Drawing.Point(125, 245)
        Me.txtCapitallAmount.Name = "txtCapitallAmount"
        Me.txtCapitallAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCapitallAmount.Size = New System.Drawing.Size(202, 20)
        Me.txtCapitallAmount.TabIndex = 167
        Me.txtCapitallAmount.Text = "0.00"
        Me.txtCapitallAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Delete record"
        '
        'btnEdit
        '
        Me.btnEdit.ImageIndex = 1
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "Edit "
        Me.btnEdit.ToolTipText = "Edit record"
        '
        'btnCancel
        '
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancel Changes Made"
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(125, 89)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemberName.Size = New System.Drawing.Size(414, 20)
        Me.txtMemberName.TabIndex = 159
        '
        'lblMemberName
        '
        Me.lblMemberName.AutoSize = True
        Me.lblMemberName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(13, 92)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(78, 14)
        Me.lblMemberName.TabIndex = 158
        Me.lblMemberName.Text = "Account Name"
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
        Me.tbrMainForm.Size = New System.Drawing.Size(556, 40)
        Me.tbrMainForm.TabIndex = 0
        '
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 6
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Text = "Approve"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(556, 43)
        Me.pnlToolbar.TabIndex = 180
        '
        'txtMemberId
        '
        Me.txtMemberId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberId.Location = New System.Drawing.Point(519, 89)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 182
        Me.txtMemberId.Visible = False
        '
        'lblReceivedBy
        '
        Me.lblReceivedBy.AutoSize = True
        Me.lblReceivedBy.BackColor = System.Drawing.SystemColors.Control
        Me.lblReceivedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceivedBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReceivedBy.Location = New System.Drawing.Point(13, 401)
        Me.lblReceivedBy.Name = "lblReceivedBy"
        Me.lblReceivedBy.Size = New System.Drawing.Size(68, 14)
        Me.lblReceivedBy.TabIndex = 183
        Me.lblReceivedBy.Text = "Received By"
        '
        'txtReceivedBy
        '
        Me.txtReceivedBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReceivedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReceivedBy.Location = New System.Drawing.Point(125, 398)
        Me.txtReceivedBy.Name = "txtReceivedBy"
        Me.txtReceivedBy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtReceivedBy.Size = New System.Drawing.Size(414, 20)
        Me.txtReceivedBy.TabIndex = 184
        '
        'txtWithdrawalId
        '
        Me.txtWithdrawalId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWithdrawalId.Location = New System.Drawing.Point(333, 63)
        Me.txtWithdrawalId.Name = "txtWithdrawalId"
        Me.txtWithdrawalId.ReadOnly = True
        Me.txtWithdrawalId.Size = New System.Drawing.Size(20, 20)
        Me.txtWithdrawalId.TabIndex = 185
        Me.txtWithdrawalId.Visible = False
        '
        'txtNetProceeds
        '
        Me.txtNetProceeds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNetProceeds.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetProceeds.Location = New System.Drawing.Point(125, 297)
        Me.txtNetProceeds.Name = "txtNetProceeds"
        Me.txtNetProceeds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNetProceeds.Size = New System.Drawing.Size(202, 20)
        Me.txtNetProceeds.TabIndex = 186
        Me.txtNetProceeds.Text = "0.00"
        Me.txtNetProceeds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNetProceeds
        '
        Me.lblNetProceeds.AutoSize = True
        Me.lblNetProceeds.BackColor = System.Drawing.SystemColors.Control
        Me.lblNetProceeds.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetProceeds.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNetProceeds.Location = New System.Drawing.Point(13, 300)
        Me.lblNetProceeds.Name = "lblNetProceeds"
        Me.lblNetProceeds.Size = New System.Drawing.Size(72, 14)
        Me.lblNetProceeds.TabIndex = 187
        Me.lblNetProceeds.Text = "Net Proceeds"
        '
        'lblInterestIncome
        '
        Me.lblInterestIncome.AutoSize = True
        Me.lblInterestIncome.BackColor = System.Drawing.SystemColors.Control
        Me.lblInterestIncome.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestIncome.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInterestIncome.Location = New System.Drawing.Point(13, 274)
        Me.lblInterestIncome.Name = "lblInterestIncome"
        Me.lblInterestIncome.Size = New System.Drawing.Size(80, 14)
        Me.lblInterestIncome.TabIndex = 189
        Me.lblInterestIncome.Text = "Interest Income"
        '
        'txtInterestIncome
        '
        Me.txtInterestIncome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInterestIncome.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterestIncome.Location = New System.Drawing.Point(125, 271)
        Me.txtInterestIncome.Name = "txtInterestIncome"
        Me.txtInterestIncome.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInterestIncome.Size = New System.Drawing.Size(202, 20)
        Me.txtInterestIncome.TabIndex = 188
        Me.txtInterestIncome.Text = "0.00"
        Me.txtInterestIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblInterestRate
        '
        Me.lblInterestRate.AutoSize = True
        Me.lblInterestRate.BackColor = System.Drawing.SystemColors.Control
        Me.lblInterestRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInterestRate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblInterestRate.Location = New System.Drawing.Point(333, 274)
        Me.lblInterestRate.Name = "lblInterestRate"
        Me.lblInterestRate.Size = New System.Drawing.Size(46, 14)
        Me.lblInterestRate.TabIndex = 190
        Me.lblInterestRate.Text = "(2.00%)"
        '
        'frmMemberWithdrawal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 467)
        Me.Controls.Add(Me.lblInterestRate)
        Me.Controls.Add(Me.lblInterestIncome)
        Me.Controls.Add(Me.txtInterestIncome)
        Me.Controls.Add(Me.lblNetProceeds)
        Me.Controls.Add(Me.txtNetProceeds)
        Me.Controls.Add(Me.txtWithdrawalId)
        Me.Controls.Add(Me.txtReceivedBy)
        Me.Controls.Add(Me.lblReceivedBy)
        Me.Controls.Add(Me.txtMemberId)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtCheckNo)
        Me.Controls.Add(Me.lblCheckNo)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.lblVoucherNo)
        Me.Controls.Add(Me.lblCurrentShare)
        Me.Controls.Add(Me.txtCurrentShare)
        Me.Controls.Add(Me.lblWithdrawDate)
        Me.Controls.Add(Me.dtpWithrawDate)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblCapitalAmount)
        Me.Controls.Add(Me.txtCapitallAmount)
        Me.Controls.Add(Me.txtMemberName)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMemberWithdrawal"
        Me.Text = "frmMemberWithdrawal"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckNo As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents lblVoucherNo As System.Windows.Forms.Label
    Friend WithEvents lblCurrentShare As System.Windows.Forms.Label
    Friend WithEvents txtCurrentShare As System.Windows.Forms.TextBox
    Friend WithEvents lblWithdrawDate As System.Windows.Forms.Label
    Friend WithEvents dtpWithrawDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblCapitalAmount As System.Windows.Forms.Label
    Friend WithEvents txtCapitallAmount As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents lblReceivedBy As System.Windows.Forms.Label
    Friend WithEvents txtReceivedBy As System.Windows.Forms.TextBox
    Friend WithEvents txtWithdrawalId As System.Windows.Forms.TextBox
    Friend WithEvents txtNetProceeds As System.Windows.Forms.TextBox
    Friend WithEvents lblNetProceeds As System.Windows.Forms.Label
    Friend WithEvents lblInterestIncome As System.Windows.Forms.Label
    Friend WithEvents txtInterestIncome As System.Windows.Forms.TextBox
    Friend WithEvents lblInterestRate As System.Windows.Forms.Label
End Class
