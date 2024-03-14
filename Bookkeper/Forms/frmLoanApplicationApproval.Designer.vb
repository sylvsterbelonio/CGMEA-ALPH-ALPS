<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanApplicationApproval
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoanApplicationApproval))
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
        Me.txtLoanId = New System.Windows.Forms.TextBox
        Me.txtLoanNo = New System.Windows.Forms.TextBox
        Me.lblLoanApplicationNo = New System.Windows.Forms.Label
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.txtLoanType = New System.Windows.Forms.TextBox
        Me.lblLoanType = New System.Windows.Forms.Label
        Me.lblPrincipalAmount = New System.Windows.Forms.Label
        Me.txtPrincipalAmount = New System.Windows.Forms.TextBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.lblDepartment = New System.Windows.Forms.Label
        Me.lblApprovedDate = New System.Windows.Forms.Label
        Me.dtpApprovedDate = New System.Windows.Forms.DateTimePicker
        Me.txtApprovedId = New System.Windows.Forms.TextBox
        Me.lblApprovedBy = New System.Windows.Forms.Label
        Me.cboApprovedId = New System.Windows.Forms.ComboBox
        Me.txtApprovedName = New System.Windows.Forms.TextBox
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
        Me.pnlToolbar.TabIndex = 152
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
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(139, 83)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.ReadOnly = True
        Me.txtMemberName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemberName.Size = New System.Drawing.Size(413, 20)
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
        'txtLoanType
        '
        Me.txtLoanType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanType.Location = New System.Drawing.Point(139, 135)
        Me.txtLoanType.Name = "txtLoanType"
        Me.txtLoanType.ReadOnly = True
        Me.txtLoanType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLoanType.Size = New System.Drawing.Size(413, 20)
        Me.txtLoanType.TabIndex = 8
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
        'lblPrincipalAmount
        '
        Me.lblPrincipalAmount.AutoSize = True
        Me.lblPrincipalAmount.BackColor = System.Drawing.SystemColors.Control
        Me.lblPrincipalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrincipalAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPrincipalAmount.Location = New System.Drawing.Point(13, 164)
        Me.lblPrincipalAmount.Name = "lblPrincipalAmount"
        Me.lblPrincipalAmount.Size = New System.Drawing.Size(86, 14)
        Me.lblPrincipalAmount.TabIndex = 9
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
        Me.txtPrincipalAmount.Size = New System.Drawing.Size(413, 20)
        Me.txtPrincipalAmount.TabIndex = 10
        Me.txtPrincipalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(139, 213)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(413, 67)
        Me.txtRemarks.TabIndex = 14
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(13, 216)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(49, 14)
        Me.lblRemarks.TabIndex = 13
        Me.lblRemarks.Text = "Remarks"
        '
        'txtDepartment
        '
        Me.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartment.Location = New System.Drawing.Point(139, 109)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.ReadOnly = True
        Me.txtDepartment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDepartment.Size = New System.Drawing.Size(413, 20)
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
        'lblApprovedDate
        '
        Me.lblApprovedDate.AutoSize = True
        Me.lblApprovedDate.Location = New System.Drawing.Point(13, 192)
        Me.lblApprovedDate.Name = "lblApprovedDate"
        Me.lblApprovedDate.Size = New System.Drawing.Size(86, 14)
        Me.lblApprovedDate.TabIndex = 11
        Me.lblApprovedDate.Text = "Date Approved *"
        '
        'dtpApprovedDate
        '
        Me.dtpApprovedDate.Checked = False
        Me.dtpApprovedDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpApprovedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpApprovedDate.Location = New System.Drawing.Point(139, 187)
        Me.dtpApprovedDate.Name = "dtpApprovedDate"
        Me.dtpApprovedDate.ShowCheckBox = True
        Me.dtpApprovedDate.Size = New System.Drawing.Size(413, 20)
        Me.dtpApprovedDate.TabIndex = 12
        Me.dtpApprovedDate.Tag = "0"
        '
        'txtApprovedId
        '
        Me.txtApprovedId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprovedId.Location = New System.Drawing.Point(532, 286)
        Me.txtApprovedId.Name = "txtApprovedId"
        Me.txtApprovedId.ReadOnly = True
        Me.txtApprovedId.Size = New System.Drawing.Size(20, 20)
        Me.txtApprovedId.TabIndex = 17
        Me.txtApprovedId.Visible = False
        '
        'lblApprovedBy
        '
        Me.lblApprovedBy.AutoSize = True
        Me.lblApprovedBy.BackColor = System.Drawing.Color.Transparent
        Me.lblApprovedBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprovedBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblApprovedBy.Location = New System.Drawing.Point(13, 292)
        Me.lblApprovedBy.Name = "lblApprovedBy"
        Me.lblApprovedBy.Size = New System.Drawing.Size(78, 14)
        Me.lblApprovedBy.TabIndex = 15
        Me.lblApprovedBy.Text = "Approved By *"
        '
        'cboApprovedId
        '
        Me.cboApprovedId.Enabled = False
        Me.cboApprovedId.FormattingEnabled = True
        Me.cboApprovedId.Location = New System.Drawing.Point(527, 289)
        Me.cboApprovedId.Name = "cboApprovedId"
        Me.cboApprovedId.Size = New System.Drawing.Size(25, 22)
        Me.cboApprovedId.TabIndex = 18
        Me.cboApprovedId.TabStop = False
        Me.cboApprovedId.Visible = False
        '
        'txtApprovedName
        '
        Me.txtApprovedName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApprovedName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApprovedName.Location = New System.Drawing.Point(139, 289)
        Me.txtApprovedName.Name = "txtApprovedName"
        Me.txtApprovedName.Size = New System.Drawing.Size(413, 20)
        Me.txtApprovedName.TabIndex = 16
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(452, 325)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 153
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmLoanApplicationApproval
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 367)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtApprovedId)
        Me.Controls.Add(Me.lblApprovedBy)
        Me.Controls.Add(Me.cboApprovedId)
        Me.Controls.Add(Me.txtApprovedName)
        Me.Controls.Add(Me.lblApprovedDate)
        Me.Controls.Add(Me.dtpApprovedDate)
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
        Me.Name = "frmLoanApplicationApproval"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Application Approval"
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
    Friend WithEvents txtLoanId As System.Windows.Forms.TextBox
    Friend WithEvents txtLoanNo As System.Windows.Forms.TextBox
    Friend WithEvents lblLoanApplicationNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents txtLoanType As System.Windows.Forms.TextBox
    Friend WithEvents lblLoanType As System.Windows.Forms.Label
    Friend WithEvents lblPrincipalAmount As System.Windows.Forms.Label
    Friend WithEvents txtPrincipalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartment As System.Windows.Forms.Label
    Friend WithEvents lblApprovedDate As System.Windows.Forms.Label
    Friend WithEvents dtpApprovedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtApprovedId As System.Windows.Forms.TextBox
    Friend WithEvents lblApprovedBy As System.Windows.Forms.Label
    Friend WithEvents cboApprovedId As System.Windows.Forms.ComboBox
    Friend WithEvents txtApprovedName As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
