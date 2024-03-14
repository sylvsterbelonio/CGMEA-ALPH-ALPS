<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanApplicationRelease
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoanApplicationRelease))
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.txtReleasedId = New System.Windows.Forms.TextBox
        Me.lblReleasedBy = New System.Windows.Forms.Label
        Me.cboReleasedId = New System.Windows.Forms.ComboBox
        Me.txtReleasedName = New System.Windows.Forms.TextBox
        Me.lblReleasedDate = New System.Windows.Forms.Label
        Me.dtpReleasedDate = New System.Windows.Forms.DateTimePicker
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.lblDepartment = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblPrincipalAmount = New System.Windows.Forms.Label
        Me.txtPrincipalAmount = New System.Windows.Forms.TextBox
        Me.lblLoanType = New System.Windows.Forms.Label
        Me.txtLoanType = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.txtLoanId = New System.Windows.Forms.TextBox
        Me.txtLoanNo = New System.Windows.Forms.TextBox
        Me.lblLoanApplicationNo = New System.Windows.Forms.Label
        Me.lblNetProceeds = New System.Windows.Forms.Label
        Me.txtNetProceeds = New System.Windows.Forms.TextBox
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.lblCheckNo = New System.Windows.Forms.Label
        Me.txtVoucherNo = New System.Windows.Forms.TextBox
        Me.lblVoucherNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.pnlToolbar.SuspendLayout()
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
        Me.tbrMainForm.Size = New System.Drawing.Size(568, 41)
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
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(568, 43)
        Me.pnlToolbar.TabIndex = 153
        '
        'txtReleasedId
        '
        Me.txtReleasedId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReleasedId.Location = New System.Drawing.Point(533, 314)
        Me.txtReleasedId.Name = "txtReleasedId"
        Me.txtReleasedId.ReadOnly = True
        Me.txtReleasedId.Size = New System.Drawing.Size(20, 20)
        Me.txtReleasedId.TabIndex = 24
        Me.txtReleasedId.Visible = False
        '
        'lblReleasedBy
        '
        Me.lblReleasedBy.AutoSize = True
        Me.lblReleasedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblReleasedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReleasedBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReleasedBy.Location = New System.Drawing.Point(13, 320)
        Me.lblReleasedBy.Name = "lblReleasedBy"
        Me.lblReleasedBy.Size = New System.Drawing.Size(68, 14)
        Me.lblReleasedBy.TabIndex = 21
        Me.lblReleasedBy.Text = "Released By"
        '
        'cboReleasedId
        '
        Me.cboReleasedId.Enabled = False
        Me.cboReleasedId.FormattingEnabled = True
        Me.cboReleasedId.Location = New System.Drawing.Point(528, 312)
        Me.cboReleasedId.Name = "cboReleasedId"
        Me.cboReleasedId.Size = New System.Drawing.Size(25, 22)
        Me.cboReleasedId.TabIndex = 23
        Me.cboReleasedId.TabStop = False
        Me.cboReleasedId.Visible = False
        '
        'txtReleasedName
        '
        Me.txtReleasedName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReleasedName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReleasedName.Location = New System.Drawing.Point(139, 317)
        Me.txtReleasedName.Name = "txtReleasedName"
        Me.txtReleasedName.Size = New System.Drawing.Size(414, 20)
        Me.txtReleasedName.TabIndex = 22
        '
        'lblReleasedDate
        '
        Me.lblReleasedDate.AutoSize = True
        Me.lblReleasedDate.Location = New System.Drawing.Point(13, 218)
        Me.lblReleasedDate.Name = "lblReleasedDate"
        Me.lblReleasedDate.Size = New System.Drawing.Size(77, 14)
        Me.lblReleasedDate.TabIndex = 17
        Me.lblReleasedDate.Text = "Date Released"
        '
        'dtpReleasedDate
        '
        Me.dtpReleasedDate.Checked = False
        Me.dtpReleasedDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpReleasedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReleasedDate.Location = New System.Drawing.Point(139, 213)
        Me.dtpReleasedDate.Name = "dtpReleasedDate"
        Me.dtpReleasedDate.ShowCheckBox = True
        Me.dtpReleasedDate.Size = New System.Drawing.Size(222, 20)
        Me.dtpReleasedDate.TabIndex = 18
        Me.dtpReleasedDate.Tag = "0"
        '
        'txtDepartment
        '
        Me.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(139, 109)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDepartment.Size = New System.Drawing.Size(414, 20)
        Me.txtDepartment.TabIndex = 6
        '
        'lblDepartment
        '
        Me.lblDepartment.AutoSize = True
        Me.lblDepartment.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartment.Location = New System.Drawing.Point(13, 112)
        Me.lblDepartment.Name = "lblDepartment"
        Me.lblDepartment.Size = New System.Drawing.Size(62, 14)
        Me.lblDepartment.TabIndex = 5
        Me.lblDepartment.Text = "Department"
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(139, 239)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(414, 69)
        Me.txtRemarks.TabIndex = 20
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(13, 242)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 14)
        Me.lblRemarks.TabIndex = 19
        Me.lblRemarks.Text = "Remarks"
        '
        'lblPrincipalAmount
        '
        Me.lblPrincipalAmount.AutoSize = True
        Me.lblPrincipalAmount.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrincipalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrincipalAmount.Location = New System.Drawing.Point(13, 164)
        Me.lblPrincipalAmount.Name = "lblPrincipalAmount"
        Me.lblPrincipalAmount.Size = New System.Drawing.Size(86, 14)
        Me.lblPrincipalAmount.TabIndex = 11
        Me.lblPrincipalAmount.Text = "Principal Amount"
        '
        'txtPrincipalAmount
        '
        Me.txtPrincipalAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrincipalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrincipalAmount.Location = New System.Drawing.Point(139, 161)
        Me.txtPrincipalAmount.Name = "txtPrincipalAmount"
        Me.txtPrincipalAmount.ReadOnly = True
        Me.txtPrincipalAmount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPrincipalAmount.Size = New System.Drawing.Size(222, 20)
        Me.txtPrincipalAmount.TabIndex = 12
        Me.txtPrincipalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLoanType
        '
        Me.lblLoanType.AutoSize = True
        Me.lblLoanType.BackColor = System.Drawing.SystemColors.Control
        Me.lblLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanType.Location = New System.Drawing.Point(13, 138)
        Me.lblLoanType.Name = "lblLoanType"
        Me.lblLoanType.Size = New System.Drawing.Size(70, 14)
        Me.lblLoanType.TabIndex = 7
        Me.lblLoanType.Text = "Type of Loan"
        '
        'txtLoanType
        '
        Me.txtLoanType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanType.Location = New System.Drawing.Point(139, 135)
        Me.txtLoanType.Name = "txtLoanType"
        Me.txtLoanType.ReadOnly = True
        Me.txtLoanType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLoanType.Size = New System.Drawing.Size(222, 20)
        Me.txtLoanType.TabIndex = 8
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(139, 83)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.ReadOnly = True
        Me.txtMemberName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemberName.Size = New System.Drawing.Size(414, 20)
        Me.txtMemberName.TabIndex = 4
        '
        'lblMemberName
        '
        Me.lblMemberName.AutoSize = True
        Me.lblMemberName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(13, 86)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(75, 14)
        Me.lblMemberName.TabIndex = 3
        Me.lblMemberName.Text = "Member Name"
        '
        'txtLoanId
        '
        Me.txtLoanId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanId.Location = New System.Drawing.Point(284, 57)
        Me.txtLoanId.Name = "txtLoanId"
        Me.txtLoanId.ReadOnly = True
        Me.txtLoanId.Size = New System.Drawing.Size(20, 20)
        Me.txtLoanId.TabIndex = 2
        Me.txtLoanId.Visible = False
        '
        'txtLoanNo
        '
        Me.txtLoanNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanNo.Location = New System.Drawing.Point(139, 57)
        Me.txtLoanNo.Name = "txtLoanNo"
        Me.txtLoanNo.Size = New System.Drawing.Size(165, 20)
        Me.txtLoanNo.TabIndex = 1
        '
        'lblLoanApplicationNo
        '
        Me.lblLoanApplicationNo.AutoSize = True
        Me.lblLoanApplicationNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblLoanApplicationNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanApplicationNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanApplicationNo.Location = New System.Drawing.Point(13, 60)
        Me.lblLoanApplicationNo.Name = "lblLoanApplicationNo"
        Me.lblLoanApplicationNo.Size = New System.Drawing.Size(112, 14)
        Me.lblLoanApplicationNo.TabIndex = 0
        Me.lblLoanApplicationNo.Text = "Loan Application No. *"
        '
        'lblNetProceeds
        '
        Me.lblNetProceeds.AutoSize = True
        Me.lblNetProceeds.BackColor = System.Drawing.SystemColors.Control
        Me.lblNetProceeds.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNetProceeds.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNetProceeds.Location = New System.Drawing.Point(13, 190)
        Me.lblNetProceeds.Name = "lblNetProceeds"
        Me.lblNetProceeds.Size = New System.Drawing.Size(72, 14)
        Me.lblNetProceeds.TabIndex = 15
        Me.lblNetProceeds.Text = "Net Proceeds"
        '
        'txtNetProceeds
        '
        Me.txtNetProceeds.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNetProceeds.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetProceeds.Location = New System.Drawing.Point(139, 187)
        Me.txtNetProceeds.Name = "txtNetProceeds"
        Me.txtNetProceeds.ReadOnly = True
        Me.txtNetProceeds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNetProceeds.Size = New System.Drawing.Size(222, 20)
        Me.txtNetProceeds.TabIndex = 16
        Me.txtNetProceeds.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCheckNo
        '
        Me.txtCheckNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtCheckNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckNo.Location = New System.Drawing.Point(451, 161)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(102, 20)
        Me.txtCheckNo.TabIndex = 14
        '
        'lblCheckNo
        '
        Me.lblCheckNo.AutoSize = True
        Me.lblCheckNo.Location = New System.Drawing.Point(378, 164)
        Me.lblCheckNo.Name = "lblCheckNo"
        Me.lblCheckNo.Size = New System.Drawing.Size(56, 14)
        Me.lblCheckNo.TabIndex = 13
        Me.lblCheckNo.Text = "Check No."
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.BackColor = System.Drawing.SystemColors.Window
        Me.txtVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVoucherNo.Location = New System.Drawing.Point(451, 135)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(102, 20)
        Me.txtVoucherNo.TabIndex = 10
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(378, 138)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(67, 14)
        Me.lblVoucherNo.TabIndex = 9
        Me.lblVoucherNo.Text = "Voucher No."
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(453, 349)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 154
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmLoanApplicationRelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 393)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtCheckNo)
        Me.Controls.Add(Me.lblCheckNo)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.lblVoucherNo)
        Me.Controls.Add(Me.lblNetProceeds)
        Me.Controls.Add(Me.txtNetProceeds)
        Me.Controls.Add(Me.txtReleasedId)
        Me.Controls.Add(Me.lblReleasedBy)
        Me.Controls.Add(Me.cboReleasedId)
        Me.Controls.Add(Me.txtReleasedName)
        Me.Controls.Add(Me.lblReleasedDate)
        Me.Controls.Add(Me.dtpReleasedDate)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.lblDepartment)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblPrincipalAmount)
        Me.Controls.Add(Me.txtPrincipalAmount)
        Me.Controls.Add(Me.lblLoanType)
        Me.Controls.Add(Me.txtLoanType)
        Me.Controls.Add(Me.txtMemberName)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.txtLoanId)
        Me.Controls.Add(Me.txtLoanNo)
        Me.Controls.Add(Me.lblLoanApplicationNo)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoanApplicationRelease"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Application Release"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtReleasedId As System.Windows.Forms.TextBox
    Friend WithEvents lblReleasedBy As System.Windows.Forms.Label
    Friend WithEvents cboReleasedId As System.Windows.Forms.ComboBox
    Friend WithEvents txtReleasedName As System.Windows.Forms.TextBox
    Friend WithEvents lblReleasedDate As System.Windows.Forms.Label
    Friend WithEvents dtpReleasedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblPrincipalAmount As System.Windows.Forms.Label
    Friend WithEvents txtPrincipalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblLoanType As System.Windows.Forms.Label
    Friend WithEvents txtLoanType As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents txtLoanId As System.Windows.Forms.TextBox
    Friend WithEvents txtLoanNo As System.Windows.Forms.TextBox
    Friend WithEvents lblLoanApplicationNo As System.Windows.Forms.Label
    Friend WithEvents lblNetProceeds As System.Windows.Forms.Label
    Friend WithEvents txtNetProceeds As System.Windows.Forms.TextBox
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCheckNo As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents lblVoucherNo As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
