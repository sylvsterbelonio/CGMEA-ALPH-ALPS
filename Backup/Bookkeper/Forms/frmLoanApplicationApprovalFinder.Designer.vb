<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanApplicationApprovalFinder
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.colLoanId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colPrincialAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colNetProceeds = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colMonthly = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colLoanStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.colRefId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ApproveLoanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditApproveLoanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewLoanApplicationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.lblLoanApplicationNo = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.cboLoanStatus = New System.Windows.Forms.ComboBox
        Me.lblLoanStatus = New System.Windows.Forms.Label
        Me.lblLoanDt = New System.Windows.Forms.Label
        Me.dtpLoanDate = New System.Windows.Forms.DateTimePicker
        Me.cboTypeId = New System.Windows.Forms.ComboBox
        Me.cboTypeName = New System.Windows.Forms.ComboBox
        Me.lblLoanType = New System.Windows.Forms.Label
        Me.txtLoanNo = New System.Windows.Forms.TextBox
        Me.lblLoanNo = New System.Windows.Forms.Label
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.cboLoanApplication = New System.Windows.Forms.GroupBox
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsMenu.SuspendLayout()
        Me.grpSearchCriteria.SuspendLayout()
        Me.cboLoanApplication.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvFinder
        '
        Me.dgvFinder.AllowUserToAddRows = False
        Me.dgvFinder.AllowUserToDeleteRows = False
        Me.dgvFinder.AllowUserToResizeRows = False
        Me.dgvFinder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLoanId, Me.colLoanNo, Me.colMemberId, Me.colMemberNo, Me.colMemberName, Me.colLoanDate, Me.colLoanType, Me.colPrincialAmount, Me.colNetProceeds, Me.colMonthly, Me.colLoanStatus, Me.colRemarks, Me.colRefId})
        Me.dgvFinder.ContextMenuStrip = Me.cmsMenu
        Me.dgvFinder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFinder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvFinder.Location = New System.Drawing.Point(3, 16)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.ReadOnly = True
        Me.dgvFinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinder.Size = New System.Drawing.Size(1007, 361)
        Me.dgvFinder.TabIndex = 61
        '
        'colLoanId
        '
        Me.colLoanId.HeaderText = "LOAN ID"
        Me.colLoanId.MinimumWidth = 100
        Me.colLoanId.Name = "colLoanId"
        Me.colLoanId.ReadOnly = True
        Me.colLoanId.Visible = False
        '
        'colLoanNo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colLoanNo.DefaultCellStyle = DataGridViewCellStyle1
        Me.colLoanNo.HeaderText = "LOAN NO"
        Me.colLoanNo.MinimumWidth = 100
        Me.colLoanNo.Name = "colLoanNo"
        Me.colLoanNo.ReadOnly = True
        '
        'colMemberId
        '
        Me.colMemberId.HeaderText = "MEMBER ID"
        Me.colMemberId.MinimumWidth = 100
        Me.colMemberId.Name = "colMemberId"
        Me.colMemberId.ReadOnly = True
        Me.colMemberId.Visible = False
        '
        'colMemberNo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colMemberNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colMemberNo.HeaderText = "MEMBER NO"
        Me.colMemberNo.MinimumWidth = 100
        Me.colMemberNo.Name = "colMemberNo"
        Me.colMemberNo.ReadOnly = True
        '
        'colMemberName
        '
        Me.colMemberName.HeaderText = "MEMBER NAME"
        Me.colMemberName.MinimumWidth = 150
        Me.colMemberName.Name = "colMemberName"
        Me.colMemberName.ReadOnly = True
        Me.colMemberName.Width = 150
        '
        'colLoanDate
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colLoanDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.colLoanDate.HeaderText = "LOAN DATE"
        Me.colLoanDate.Name = "colLoanDate"
        Me.colLoanDate.ReadOnly = True
        '
        'colLoanType
        '
        Me.colLoanType.HeaderText = "LOAN TYPE"
        Me.colLoanType.MinimumWidth = 150
        Me.colLoanType.Name = "colLoanType"
        Me.colLoanType.ReadOnly = True
        Me.colLoanType.Width = 150
        '
        'colPrincialAmount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colPrincialAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPrincialAmount.HeaderText = "PRINCIPAL"
        Me.colPrincialAmount.MinimumWidth = 100
        Me.colPrincialAmount.Name = "colPrincialAmount"
        Me.colPrincialAmount.ReadOnly = True
        '
        'colNetProceeds
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colNetProceeds.DefaultCellStyle = DataGridViewCellStyle5
        Me.colNetProceeds.HeaderText = "NET PROCEEDS"
        Me.colNetProceeds.MinimumWidth = 125
        Me.colNetProceeds.Name = "colNetProceeds"
        Me.colNetProceeds.ReadOnly = True
        Me.colNetProceeds.Width = 125
        '
        'colMonthly
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colMonthly.DefaultCellStyle = DataGridViewCellStyle6
        Me.colMonthly.HeaderText = "MONTHLY"
        Me.colMonthly.MinimumWidth = 100
        Me.colMonthly.Name = "colMonthly"
        Me.colMonthly.ReadOnly = True
        '
        'colLoanStatus
        '
        Me.colLoanStatus.HeaderText = "LOAN STATUS"
        Me.colLoanStatus.MinimumWidth = 125
        Me.colLoanStatus.Name = "colLoanStatus"
        Me.colLoanStatus.ReadOnly = True
        Me.colLoanStatus.Width = 125
        '
        'colRemarks
        '
        Me.colRemarks.HeaderText = "REMARKS"
        Me.colRemarks.MinimumWidth = 200
        Me.colRemarks.Name = "colRemarks"
        Me.colRemarks.ReadOnly = True
        Me.colRemarks.Width = 200
        '
        'colRefId
        '
        Me.colRefId.HeaderText = "REFID"
        Me.colRefId.Name = "colRefId"
        Me.colRefId.ReadOnly = True
        Me.colRefId.Visible = False
        '
        'cmsMenu
        '
        Me.cmsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApproveLoanToolStripMenuItem, Me.EditApproveLoanToolStripMenuItem, Me.ViewLoanApplicationToolStripMenuItem})
        Me.cmsMenu.Name = "cmsMenu"
        Me.cmsMenu.Size = New System.Drawing.Size(193, 70)
        '
        'ApproveLoanToolStripMenuItem
        '
        Me.ApproveLoanToolStripMenuItem.Name = "ApproveLoanToolStripMenuItem"
        Me.ApproveLoanToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ApproveLoanToolStripMenuItem.Text = "Approve Loan"
        '
        'EditApproveLoanToolStripMenuItem
        '
        Me.EditApproveLoanToolStripMenuItem.Name = "EditApproveLoanToolStripMenuItem"
        Me.EditApproveLoanToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.EditApproveLoanToolStripMenuItem.Text = "Edit Approved Loan"
        '
        'ViewLoanApplicationToolStripMenuItem
        '
        Me.ViewLoanApplicationToolStripMenuItem.Enabled = False
        Me.ViewLoanApplicationToolStripMenuItem.Name = "ViewLoanApplicationToolStripMenuItem"
        Me.ViewLoanApplicationToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ViewLoanApplicationToolStripMenuItem.Text = "View Loan Application"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.ForeColor = System.Drawing.Color.White
        Me.btnSearch.Location = New System.Drawing.Point(29, 142)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 56
        Me.btnSearch.Text = "&Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(135, 142)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 57
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.lblLoanApplicationNo)
        Me.grpSearchCriteria.Controls.Add(Me.btnClose)
        Me.grpSearchCriteria.Controls.Add(Me.cboLoanStatus)
        Me.grpSearchCriteria.Controls.Add(Me.lblLoanStatus)
        Me.grpSearchCriteria.Controls.Add(Me.lblLoanDt)
        Me.grpSearchCriteria.Controls.Add(Me.dtpLoanDate)
        Me.grpSearchCriteria.Controls.Add(Me.cboTypeId)
        Me.grpSearchCriteria.Controls.Add(Me.btnSearch)
        Me.grpSearchCriteria.Controls.Add(Me.cboTypeName)
        Me.grpSearchCriteria.Controls.Add(Me.btnClear)
        Me.grpSearchCriteria.Controls.Add(Me.lblLoanType)
        Me.grpSearchCriteria.Controls.Add(Me.txtLoanNo)
        Me.grpSearchCriteria.Controls.Add(Me.lblLoanNo)
        Me.grpSearchCriteria.Controls.Add(Me.txtMemberNo)
        Me.grpSearchCriteria.Controls.Add(Me.txtMemberName)
        Me.grpSearchCriteria.Controls.Add(Me.lblMemberName)
        Me.grpSearchCriteria.Controls.Add(Me.lblMemberNo)
        Me.grpSearchCriteria.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(0, 0)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(1013, 191)
        Me.grpSearchCriteria.TabIndex = 55
        Me.grpSearchCriteria.TabStop = False
        '
        'lblLoanApplicationNo
        '
        Me.lblLoanApplicationNo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanApplicationNo.Location = New System.Drawing.Point(21, 9)
        Me.lblLoanApplicationNo.Name = "lblLoanApplicationNo"
        Me.lblLoanApplicationNo.Size = New System.Drawing.Size(500, 40)
        Me.lblLoanApplicationNo.TabIndex = 73
        Me.lblLoanApplicationNo.Text = "Approval of Loan Application"
        Me.lblLoanApplicationNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(241, 142)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 72
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'cboLoanStatus
        '
        Me.cboLoanStatus.DropDownWidth = 250
        Me.cboLoanStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboLoanStatus.FormattingEnabled = True
        Me.cboLoanStatus.Items.AddRange(New Object() {"", "PENDING", "FOR APPROVAL", "FOR RELEASING", "LOAN RELEASED", "CANCELED", "CLOSED"})
        Me.cboLoanStatus.Location = New System.Drawing.Point(469, 103)
        Me.cboLoanStatus.Name = "cboLoanStatus"
        Me.cboLoanStatus.Size = New System.Drawing.Size(200, 22)
        Me.cboLoanStatus.TabIndex = 71
        Me.cboLoanStatus.Text = "FOR APPROVAL"
        '
        'lblLoanStatus
        '
        Me.lblLoanStatus.AutoSize = True
        Me.lblLoanStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblLoanStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanStatus.Location = New System.Drawing.Point(368, 106)
        Me.lblLoanStatus.Name = "lblLoanStatus"
        Me.lblLoanStatus.Size = New System.Drawing.Size(72, 14)
        Me.lblLoanStatus.TabIndex = 70
        Me.lblLoanStatus.Text = "Loan Status"
        '
        'lblLoanDt
        '
        Me.lblLoanDt.BackColor = System.Drawing.Color.White
        Me.lblLoanDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLoanDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanDt.Location = New System.Drawing.Point(26, 106)
        Me.lblLoanDt.Name = "lblLoanDt"
        Me.lblLoanDt.Size = New System.Drawing.Size(90, 18)
        Me.lblLoanDt.TabIndex = 69
        Me.lblLoanDt.Text = "Loan Date"
        '
        'dtpLoanDate
        '
        Me.dtpLoanDate.Checked = False
        Me.dtpLoanDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpLoanDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.dtpLoanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLoanDate.Location = New System.Drawing.Point(122, 105)
        Me.dtpLoanDate.Name = "dtpLoanDate"
        Me.dtpLoanDate.ShowCheckBox = True
        Me.dtpLoanDate.Size = New System.Drawing.Size(219, 20)
        Me.dtpLoanDate.TabIndex = 68
        '
        'cboTypeId
        '
        Me.cboTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeId.FormattingEnabled = True
        Me.cboTypeId.Location = New System.Drawing.Point(318, 77)
        Me.cboTypeId.Name = "cboTypeId"
        Me.cboTypeId.Size = New System.Drawing.Size(23, 22)
        Me.cboTypeId.TabIndex = 67
        Me.cboTypeId.TabStop = False
        Me.cboTypeId.Visible = False
        '
        'cboTypeName
        '
        Me.cboTypeName.DropDownWidth = 250
        Me.cboTypeName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.cboTypeName.FormattingEnabled = True
        Me.cboTypeName.Location = New System.Drawing.Point(122, 77)
        Me.cboTypeName.Name = "cboTypeName"
        Me.cboTypeName.Size = New System.Drawing.Size(219, 22)
        Me.cboTypeName.TabIndex = 66
        '
        'lblLoanType
        '
        Me.lblLoanType.BackColor = System.Drawing.Color.White
        Me.lblLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLoanType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanType.Location = New System.Drawing.Point(26, 80)
        Me.lblLoanType.Name = "lblLoanType"
        Me.lblLoanType.Size = New System.Drawing.Size(90, 18)
        Me.lblLoanType.TabIndex = 16
        Me.lblLoanType.Text = "Loan Type"
        '
        'txtLoanNo
        '
        Me.txtLoanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtLoanNo.Location = New System.Drawing.Point(122, 51)
        Me.txtLoanNo.MaxLength = 45
        Me.txtLoanNo.Name = "txtLoanNo"
        Me.txtLoanNo.Size = New System.Drawing.Size(219, 20)
        Me.txtLoanNo.TabIndex = 3
        '
        'lblLoanNo
        '
        Me.lblLoanNo.BackColor = System.Drawing.Color.White
        Me.lblLoanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblLoanNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanNo.Location = New System.Drawing.Point(26, 54)
        Me.lblLoanNo.Name = "lblLoanNo"
        Me.lblLoanNo.Size = New System.Drawing.Size(90, 18)
        Me.lblLoanNo.TabIndex = 15
        Me.lblLoanNo.Text = "Loan App. No."
        '
        'txtMemberNo
        '
        Me.txtMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMemberNo.Location = New System.Drawing.Point(469, 77)
        Me.txtMemberNo.MaxLength = 45
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberNo.TabIndex = 1
        '
        'txtMemberName
        '
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtMemberName.Location = New System.Drawing.Point(469, 51)
        Me.txtMemberName.MaxLength = 45
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberName.TabIndex = 0
        '
        'lblMemberName
        '
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(368, 54)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(89, 18)
        Me.lblMemberName.TabIndex = 10
        Me.lblMemberName.Text = "Member Name"
        '
        'lblMemberNo
        '
        Me.lblMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblMemberNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNo.Location = New System.Drawing.Point(368, 80)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(89, 18)
        Me.lblMemberNo.TabIndex = 11
        Me.lblMemberNo.Text = "Member No."
        '
        'cboLoanApplication
        '
        Me.cboLoanApplication.ContextMenuStrip = Me.cmsMenu
        Me.cboLoanApplication.Controls.Add(Me.dgvFinder)
        Me.cboLoanApplication.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cboLoanApplication.Location = New System.Drawing.Point(0, 191)
        Me.cboLoanApplication.Name = "cboLoanApplication"
        Me.cboLoanApplication.Size = New System.Drawing.Size(1013, 380)
        Me.cboLoanApplication.TabIndex = 62
        Me.cboLoanApplication.TabStop = False
        '
        'frmLoanApplicationApprovalFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1013, 571)
        Me.Controls.Add(Me.cboLoanApplication)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmLoanApplicationApprovalFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Application Approval Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsMenu.ResumeLayout(False)
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.cboLoanApplication.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents cboTypeId As System.Windows.Forms.ComboBox
    Friend WithEvents cboTypeName As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoanType As System.Windows.Forms.Label
    Friend WithEvents txtLoanNo As System.Windows.Forms.TextBox
    Friend WithEvents lblLoanNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents lblLoanDt As System.Windows.Forms.Label
    Friend WithEvents dtpLoanDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboLoanApplication As System.Windows.Forms.GroupBox
    Friend WithEvents cboLoanStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoanStatus As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblLoanApplicationNo As System.Windows.Forms.Label
    Friend WithEvents cmsMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ApproveLoanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditApproveLoanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewLoanApplicationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colLoanId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrincialAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNetProceeds As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMonthly As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoanStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefId As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
