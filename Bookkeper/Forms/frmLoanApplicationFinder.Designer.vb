<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanApplicationFinder
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
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.chkCancelled = New System.Windows.Forms.CheckBox
        Me.chkLoanReleased = New System.Windows.Forms.CheckBox
        Me.chkApproved = New System.Windows.Forms.CheckBox
        Me.btnView = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.dgvHeader = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.cboTypeId = New System.Windows.Forms.ComboBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.cboTypeName = New System.Windows.Forms.ComboBox
        Me.lblLoanType = New System.Windows.Forms.Label
        Me.txtLoanNo = New System.Windows.Forms.TextBox
        Me.lblLoanNo = New System.Windows.Forms.Label
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.gbGrid = New System.Windows.Forms.GroupBox
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.chkActive)
        Me.grpSearchCriteria.Controls.Add(Me.chkCancelled)
        Me.grpSearchCriteria.Controls.Add(Me.chkLoanReleased)
        Me.grpSearchCriteria.Controls.Add(Me.chkApproved)
        Me.grpSearchCriteria.Controls.Add(Me.btnView)
        Me.grpSearchCriteria.Controls.Add(Me.btnClose)
        Me.grpSearchCriteria.Controls.Add(Me.btnAdd)
        Me.grpSearchCriteria.Controls.Add(Me.dgvHeader)
        Me.grpSearchCriteria.Controls.Add(Me.btnEdit)
        Me.grpSearchCriteria.Controls.Add(Me.btnSearch)
        Me.grpSearchCriteria.Controls.Add(Me.cboTypeId)
        Me.grpSearchCriteria.Controls.Add(Me.btnClear)
        Me.grpSearchCriteria.Controls.Add(Me.cboTypeName)
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
        Me.grpSearchCriteria.Size = New System.Drawing.Size(737, 209)
        Me.grpSearchCriteria.TabIndex = 40
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(110, 83)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(60, 18)
        Me.chkActive.TabIndex = 74
        Me.chkActive.Text = "Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'chkCancelled
        '
        Me.chkCancelled.AutoSize = True
        Me.chkCancelled.Location = New System.Drawing.Point(216, 107)
        Me.chkCancelled.Name = "chkCancelled"
        Me.chkCancelled.Size = New System.Drawing.Size(80, 18)
        Me.chkCancelled.TabIndex = 73
        Me.chkCancelled.Text = "Cancelled"
        Me.chkCancelled.UseVisualStyleBackColor = True
        '
        'chkLoanReleased
        '
        Me.chkLoanReleased.AutoSize = True
        Me.chkLoanReleased.Location = New System.Drawing.Point(216, 83)
        Me.chkLoanReleased.Name = "chkLoanReleased"
        Me.chkLoanReleased.Size = New System.Drawing.Size(107, 18)
        Me.chkLoanReleased.TabIndex = 72
        Me.chkLoanReleased.Text = "Loan Released"
        Me.chkLoanReleased.UseVisualStyleBackColor = True
        '
        'chkApproved
        '
        Me.chkApproved.AutoSize = True
        Me.chkApproved.Location = New System.Drawing.Point(110, 107)
        Me.chkApproved.Name = "chkApproved"
        Me.chkApproved.Size = New System.Drawing.Size(80, 18)
        Me.chkApproved.TabIndex = 71
        Me.chkApproved.Text = "Approved"
        Me.chkApproved.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(413, 143)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 50
        Me.btnView.Text = "&View"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(223, 143)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 30)
        Me.btnClose.TabIndex = 68
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(519, 143)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 51
        Me.btnAdd.Text = "&Add"
        '
        'dgvHeader
        '
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(12, 176)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(713, 20)
        Me.dgvHeader.TabIndex = 54
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(625, 143)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 52
        Me.btnEdit.Text = "&Edit"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(12, 143)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 48
        Me.btnSearch.Text = "&Search"
        '
        'cboTypeId
        '
        Me.cboTypeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeId.FormattingEnabled = True
        Me.cboTypeId.Location = New System.Drawing.Point(295, 55)
        Me.cboTypeId.Name = "cboTypeId"
        Me.cboTypeId.Size = New System.Drawing.Size(28, 22)
        Me.cboTypeId.TabIndex = 67
        Me.cboTypeId.TabStop = False
        Me.cboTypeId.Visible = False
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(117, 143)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 49
        Me.btnClear.Text = "C&lear"
        '
        'cboTypeName
        '
        Me.cboTypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTypeName.DropDownWidth = 250
        Me.cboTypeName.FormattingEnabled = True
        Me.cboTypeName.Location = New System.Drawing.Point(110, 55)
        Me.cboTypeName.Name = "cboTypeName"
        Me.cboTypeName.Size = New System.Drawing.Size(213, 22)
        Me.cboTypeName.TabIndex = 66
        '
        'lblLoanType
        '
        Me.lblLoanType.BackColor = System.Drawing.SystemColors.Window
        Me.lblLoanType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanType.Location = New System.Drawing.Point(15, 60)
        Me.lblLoanType.Name = "lblLoanType"
        Me.lblLoanType.Size = New System.Drawing.Size(90, 18)
        Me.lblLoanType.TabIndex = 16
        Me.lblLoanType.Text = "Loan Type"
        '
        'txtLoanNo
        '
        Me.txtLoanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoanNo.Location = New System.Drawing.Point(110, 29)
        Me.txtLoanNo.MaxLength = 45
        Me.txtLoanNo.Name = "txtLoanNo"
        Me.txtLoanNo.Size = New System.Drawing.Size(213, 20)
        Me.txtLoanNo.TabIndex = 3
        '
        'lblLoanNo
        '
        Me.lblLoanNo.BackColor = System.Drawing.SystemColors.Window
        Me.lblLoanNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoanNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLoanNo.Location = New System.Drawing.Point(15, 32)
        Me.lblLoanNo.Name = "lblLoanNo"
        Me.lblLoanNo.Size = New System.Drawing.Size(90, 18)
        Me.lblLoanNo.TabIndex = 15
        Me.lblLoanNo.Text = "Loan App. No."
        '
        'txtMemberNo
        '
        Me.txtMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberNo.Location = New System.Drawing.Point(507, 55)
        Me.txtMemberNo.MaxLength = 45
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.Size = New System.Drawing.Size(213, 20)
        Me.txtMemberNo.TabIndex = 1
        '
        'txtMemberName
        '
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(507, 29)
        Me.txtMemberName.MaxLength = 45
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(213, 20)
        Me.txtMemberName.TabIndex = 0
        '
        'lblMemberName
        '
        Me.lblMemberName.BackColor = System.Drawing.SystemColors.Window
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(412, 32)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(92, 18)
        Me.lblMemberName.TabIndex = 10
        Me.lblMemberName.Text = "Member Name"
        '
        'lblMemberNo
        '
        Me.lblMemberNo.BackColor = System.Drawing.SystemColors.Window
        Me.lblMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNo.Location = New System.Drawing.Point(412, 58)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(89, 18)
        Me.lblMemberNo.TabIndex = 11
        Me.lblMemberNo.Text = "Member No."
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFinder.Location = New System.Drawing.Point(3, 16)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.Size = New System.Drawing.Size(731, 253)
        Me.dgvFinder.TabIndex = 53
        '
        'gbGrid
        '
        Me.gbGrid.Controls.Add(Me.dgvFinder)
        Me.gbGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbGrid.Location = New System.Drawing.Point(0, 209)
        Me.gbGrid.Name = "gbGrid"
        Me.gbGrid.Size = New System.Drawing.Size(737, 272)
        Me.gbGrid.TabIndex = 55
        Me.gbGrid.TabStop = False
        '
        'frmLoanApplicationFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(737, 481)
        Me.Controls.Add(Me.gbGrid)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoanApplicationFinder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Application Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents txtLoanNo As System.Windows.Forms.TextBox
    Friend WithEvents lblLoanNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblLoanType As System.Windows.Forms.Label
    Friend WithEvents cboTypeId As System.Windows.Forms.ComboBox
    Friend WithEvents cboTypeName As System.Windows.Forms.ComboBox
    Friend WithEvents gbGrid As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents chkCancelled As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoanReleased As System.Windows.Forms.CheckBox
    Friend WithEvents chkApproved As System.Windows.Forms.CheckBox
End Class
