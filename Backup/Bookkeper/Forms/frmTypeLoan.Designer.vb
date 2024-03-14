<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTypeLoan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTypeLoan))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMin = New System.Windows.Forms.NumericUpDown
        Me.txtMax = New System.Windows.Forms.NumericUpDown
        Me.txtMaxAmount = New System.Windows.Forms.TextBox
        Me.txtMinAmount = New System.Windows.Forms.TextBox
        Me.txtLoanType = New System.Windows.Forms.TextBox
        Me.txtInterestRate = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.dgvFees = New System.Windows.Forms.DataGridView
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dgvRequirements = New System.Windows.Forms.DataGridView
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.cboRevision = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtDeductionTerm = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtReloanRate = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.txtMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRequirements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Loan Type"
        '
        'txtMin
        '
        Me.txtMin.Location = New System.Drawing.Point(130, 96)
        Me.txtMin.Name = "txtMin"
        Me.txtMin.Size = New System.Drawing.Size(107, 20)
        Me.txtMin.TabIndex = 1
        Me.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(331, 96)
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(107, 20)
        Me.txtMax.TabIndex = 3
        Me.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaxAmount
        '
        Me.txtMaxAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMaxAmount.Location = New System.Drawing.Point(331, 122)
        Me.txtMaxAmount.Name = "txtMaxAmount"
        Me.txtMaxAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtMaxAmount.TabIndex = 15
        Me.txtMaxAmount.Text = "0.00"
        Me.txtMaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinAmount
        '
        Me.txtMinAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMinAmount.Location = New System.Drawing.Point(130, 122)
        Me.txtMinAmount.Name = "txtMinAmount"
        Me.txtMinAmount.Size = New System.Drawing.Size(107, 20)
        Me.txtMinAmount.TabIndex = 14
        Me.txtMinAmount.Text = "0.00"
        Me.txtMinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLoanType
        '
        Me.txtLoanType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLoanType.Location = New System.Drawing.Point(130, 57)
        Me.txtLoanType.Name = "txtLoanType"
        Me.txtLoanType.Size = New System.Drawing.Size(308, 20)
        Me.txtLoanType.TabIndex = 4
        '
        'txtInterestRate
        '
        Me.txtInterestRate.Location = New System.Drawing.Point(130, 148)
        Me.txtInterestRate.Name = "txtInterestRate"
        Me.txtInterestRate.Size = New System.Drawing.Size(107, 20)
        Me.txtInterestRate.TabIndex = 8
        Me.txtInterestRate.Text = "0.00"
        Me.txtInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Interest Rate/Month"
        '
        'dgvFees
        '
        Me.dgvFees.AllowUserToAddRows = False
        Me.dgvFees.AllowUserToDeleteRows = False
        Me.dgvFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFees.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column1, Me.Column2, Me.Column4})
        Me.dgvFees.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvFees.Location = New System.Drawing.Point(19, 380)
        Me.dgvFees.MultiSelect = False
        Me.dgvFees.Name = "dgvFees"
        Me.dgvFees.Size = New System.Drawing.Size(419, 155)
        Me.dgvFees.TabIndex = 10
        '
        'Column6
        '
        Me.Column6.HeaderText = "refID"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        '
        'Column1
        '
        Me.Column1.FillWeight = 174.6193!
        Me.Column1.HeaderText = "FEES"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.NullValue = "0.00"
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column2.HeaderText = "Value"
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column4
        '
        Me.Column4.FillWeight = 25.38071!
        Me.Column4.HeaderText = ""
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'dgvRequirements
        '
        Me.dgvRequirements.AllowUserToAddRows = False
        Me.dgvRequirements.AllowUserToDeleteRows = False
        Me.dgvRequirements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRequirements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRequirements.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.DataGridViewTextBoxColumn1, Me.Column3})
        Me.dgvRequirements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.dgvRequirements.Location = New System.Drawing.Point(19, 214)
        Me.dgvRequirements.MultiSelect = False
        Me.dgvRequirements.Name = "dgvRequirements"
        Me.dgvRequirements.Size = New System.Drawing.Size(419, 151)
        Me.dgvRequirements.TabIndex = 9
        '
        'Column5
        '
        Me.Column5.HeaderText = "refID"
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Column5.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 151.8746!
        Me.DataGridViewTextBoxColumn1.HeaderText = "REQUIREMENTS"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Column3
        '
        Me.Column3.FillWeight = 17.16097!
        Me.Column3.HeaderText = ""
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
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
        Me.tbrMainForm.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnFind, Me.btnSave, Me.btnCancel, Me.btnApprove})
        Me.tbrMainForm.ButtonSize = New System.Drawing.Size(40, 36)
        Me.tbrMainForm.Divider = False
        Me.tbrMainForm.DropDownArrows = True
        Me.tbrMainForm.ImageList = Me.ilTool
        Me.tbrMainForm.Location = New System.Drawing.Point(0, 0)
        Me.tbrMainForm.Name = "tbrMainForm"
        Me.tbrMainForm.ShowToolTips = True
        Me.tbrMainForm.Size = New System.Drawing.Size(458, 40)
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
        'cboRevision
        '
        Me.cboRevision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRevision.FormattingEnabled = True
        Me.cboRevision.Location = New System.Drawing.Point(19, 76)
        Me.cboRevision.Name = "cboRevision"
        Me.cboRevision.Size = New System.Drawing.Size(35, 21)
        Me.cboRevision.TabIndex = 2
        Me.cboRevision.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(344, 198)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 14
        '
        'txtDeductionTerm
        '
        Me.txtDeductionTerm.Location = New System.Drawing.Point(130, 174)
        Me.txtDeductionTerm.Name = "txtDeductionTerm"
        Me.txtDeductionTerm.Size = New System.Drawing.Size(107, 20)
        Me.txtDeductionTerm.TabIndex = 13
        Me.txtDeductionTerm.Text = "0"
        Me.txtDeductionTerm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Deduction Term"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(243, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Reloan Rate"
        '
        'txtReloanRate
        '
        Me.txtReloanRate.Location = New System.Drawing.Point(331, 148)
        Me.txtReloanRate.Name = "txtReloanRate"
        Me.txtReloanRate.Size = New System.Drawing.Size(107, 20)
        Me.txtReloanRate.TabIndex = 16
        Me.txtReloanRate.Text = "0.00"
        Me.txtReloanRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 125)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 17)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Min Amount"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(16, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Min Term"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(243, 98)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Max Term"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(243, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Max Amount"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(331, 178)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(15, 14)
        Me.chkActive.TabIndex = 20
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(243, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Loan Active?"
        '
        'frmTypeLoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(458, 547)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtMaxAmount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtMinAmount)
        Me.Controls.Add(Me.txtReloanRate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtMax)
        Me.Controls.Add(Me.txtMin)
        Me.Controls.Add(Me.txtDeductionTerm)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboRevision)
        Me.Controls.Add(Me.tbrMainForm)
        Me.Controls.Add(Me.dgvRequirements)
        Me.Controls.Add(Me.dgvFees)
        Me.Controls.Add(Me.txtInterestRate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLoanType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTypeLoan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Type of Loan"
        CType(Me.txtMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRequirements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtLoanType As System.Windows.Forms.TextBox
    Friend WithEvents txtInterestRate As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvFees As System.Windows.Forms.DataGridView
    Friend WithEvents dgvRequirements As System.Windows.Forms.DataGridView
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboRevision As System.Windows.Forms.ComboBox
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtMaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtMinAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDeductionTerm As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtReloanRate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
