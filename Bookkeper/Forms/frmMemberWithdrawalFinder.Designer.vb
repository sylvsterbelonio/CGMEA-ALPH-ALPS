<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberWithdrawalFinder
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
        Me.dgvHeader = New System.Windows.Forms.Label
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.dtpWithdrawnDate = New System.Windows.Forms.DateTimePicker
        Me.lblWithdrawalDate = New System.Windows.Forms.Label
        Me.txtCapitalAmount = New System.Windows.Forms.TextBox
        Me.lblCapitalAmount = New System.Windows.Forms.Label
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblConstituentName = New System.Windows.Forms.Label
        Me.txtVoucherNo = New System.Windows.Forms.TextBox
        Me.lblVoucherNo = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHeader
        '
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(12, 152)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(635, 22)
        Me.dgvHeader.TabIndex = 14
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.RowTemplate.Height = 24
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 15
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(115, 115)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "C&lear"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(545, 115)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "&Edit"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(335, 115)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "&View"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(10, 115)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "&Search"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.dtpWithdrawnDate)
        Me.grpSearchCriteria.Controls.Add(Me.lblWithdrawalDate)
        Me.grpSearchCriteria.Controls.Add(Me.txtCapitalAmount)
        Me.grpSearchCriteria.Controls.Add(Me.lblCapitalAmount)
        Me.grpSearchCriteria.Controls.Add(Me.txtMemberName)
        Me.grpSearchCriteria.Controls.Add(Me.lblConstituentName)
        Me.grpSearchCriteria.Controls.Add(Me.txtVoucherNo)
        Me.grpSearchCriteria.Controls.Add(Me.lblVoucherNo)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 8
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'dtpWithdrawnDate
        '
        Me.dtpWithdrawnDate.CalendarFont = New System.Drawing.Font("Arial", 8.25!)
        Me.dtpWithdrawnDate.Checked = False
        Me.dtpWithdrawnDate.CustomFormat = "dddd, MMM dd, yyyy"
        Me.dtpWithdrawnDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpWithdrawnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpWithdrawnDate.Location = New System.Drawing.Point(425, 55)
        Me.dtpWithdrawnDate.Name = "dtpWithdrawnDate"
        Me.dtpWithdrawnDate.ShowCheckBox = True
        Me.dtpWithdrawnDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpWithdrawnDate.TabIndex = 7
        Me.dtpWithdrawnDate.Tag = "0"
        '
        'lblWithdrawalDate
        '
        Me.lblWithdrawalDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWithdrawalDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWithdrawalDate.Location = New System.Drawing.Point(324, 58)
        Me.lblWithdrawalDate.Name = "lblWithdrawalDate"
        Me.lblWithdrawalDate.Size = New System.Drawing.Size(95, 22)
        Me.lblWithdrawalDate.TabIndex = 6
        Me.lblWithdrawalDate.Text = "Date Withdrawn"
        '
        'txtCapitalAmount
        '
        Me.txtCapitalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapitalAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCapitalAmount.Location = New System.Drawing.Point(115, 55)
        Me.txtCapitalAmount.MaxLength = 45
        Me.txtCapitalAmount.Name = "txtCapitalAmount"
        Me.txtCapitalAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtCapitalAmount.TabIndex = 5
        Me.txtCapitalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCapitalAmount
        '
        Me.lblCapitalAmount.AutoSize = True
        Me.lblCapitalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapitalAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapitalAmount.Location = New System.Drawing.Point(15, 55)
        Me.lblCapitalAmount.Name = "lblCapitalAmount"
        Me.lblCapitalAmount.Size = New System.Drawing.Size(110, 14)
        Me.lblCapitalAmount.TabIndex = 4
        Me.lblCapitalAmount.Text = "Capital Amount ( < = )"
        '
        'txtMemberName
        '
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMemberName.Location = New System.Drawing.Point(425, 25)
        Me.txtMemberName.MaxLength = 45
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberName.TabIndex = 3
        '
        'lblConstituentName
        '
        Me.lblConstituentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConstituentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConstituentName.Location = New System.Drawing.Point(325, 25)
        Me.lblConstituentName.Name = "lblConstituentName"
        Me.lblConstituentName.Size = New System.Drawing.Size(95, 22)
        Me.lblConstituentName.TabIndex = 2
        Me.lblConstituentName.Text = "Member Name"
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoucherNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVoucherNo.Location = New System.Drawing.Point(115, 25)
        Me.txtVoucherNo.MaxLength = 45
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(200, 20)
        Me.txtVoucherNo.TabIndex = 1
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVoucherNo.Location = New System.Drawing.Point(16, 25)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(95, 22)
        Me.lblVoucherNo.TabIndex = 0
        Me.lblVoucherNo.Text = "Voucher Number"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(440, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "&Add"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.DarkRed
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.SystemColors.Control
        Me.btnClose.Location = New System.Drawing.Point(547, 471)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 32)
        Me.btnClose.TabIndex = 182
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmMemberWithdrawalFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 512)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnAdd)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMemberWithdrawalFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Withdrawal Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents dtpWithdrawnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblWithdrawalDate As System.Windows.Forms.Label
    Friend WithEvents txtCapitalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblCapitalAmount As System.Windows.Forms.Label
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblConstituentName As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents lblVoucherNo As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
