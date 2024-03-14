<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpenses))
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.cboExpensesType = New System.Windows.Forms.ComboBox
        Me.txtAmount = New System.Windows.Forms.TextBox
        Me.dtpDateIncurred = New System.Windows.Forms.DateTimePicker
        Me.dtpDatePosted = New System.Windows.Forms.DateTimePicker
        Me.dtpACFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpACTo = New System.Windows.Forms.DateTimePicker
        Me.txtReceiptNo = New System.Windows.Forms.TextBox
        Me.txtPaidTo = New System.Windows.Forms.TextBox
        Me.optPerson = New System.Windows.Forms.RadioButton
        Me.optEstablishment = New System.Windows.Forms.RadioButton
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.txtCheckNo = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtVoucherNo = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
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
        Me.tbrMainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbrMainForm.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnFind, Me.btnSave, Me.btnCancel, Me.btnApprove})
        Me.tbrMainForm.ButtonSize = New System.Drawing.Size(40, 36)
        Me.tbrMainForm.Divider = False
        Me.tbrMainForm.DropDownArrows = True
        Me.tbrMainForm.ImageList = Me.ilTool
        Me.tbrMainForm.Location = New System.Drawing.Point(0, 0)
        Me.tbrMainForm.Name = "tbrMainForm"
        Me.tbrMainForm.ShowToolTips = True
        Me.tbrMainForm.Size = New System.Drawing.Size(613, 41)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Disbursement Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Date Incurred"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Date Posted"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Accounting Cycle"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "From"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(43, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "To"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(328, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Remarks"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(328, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Receipt No"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(328, 152)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Paid To"
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Location = New System.Drawing.Point(395, 209)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(203, 103)
        Me.txtRemarks.TabIndex = 26
        '
        'cboExpensesType
        '
        Me.cboExpensesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExpensesType.FormattingEnabled = True
        Me.cboExpensesType.Location = New System.Drawing.Point(108, 55)
        Me.cboExpensesType.Name = "cboExpensesType"
        Me.cboExpensesType.Size = New System.Drawing.Size(181, 21)
        Me.cboExpensesType.TabIndex = 2
        '
        'txtAmount
        '
        Me.txtAmount.Location = New System.Drawing.Point(108, 90)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(203, 20)
        Me.txtAmount.TabIndex = 4
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpDateIncurred
        '
        Me.dtpDateIncurred.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDateIncurred.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateIncurred.Location = New System.Drawing.Point(108, 124)
        Me.dtpDateIncurred.Name = "dtpDateIncurred"
        Me.dtpDateIncurred.ShowCheckBox = True
        Me.dtpDateIncurred.Size = New System.Drawing.Size(203, 20)
        Me.dtpDateIncurred.TabIndex = 6
        '
        'dtpDatePosted
        '
        Me.dtpDatePosted.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDatePosted.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDatePosted.Location = New System.Drawing.Point(108, 150)
        Me.dtpDatePosted.Name = "dtpDatePosted"
        Me.dtpDatePosted.ShowCheckBox = True
        Me.dtpDatePosted.Size = New System.Drawing.Size(203, 20)
        Me.dtpDatePosted.TabIndex = 8
        '
        'dtpACFrom
        '
        Me.dtpACFrom.CustomFormat = "MMMM dd, yyyy"
        Me.dtpACFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpACFrom.Location = New System.Drawing.Point(108, 209)
        Me.dtpACFrom.Name = "dtpACFrom"
        Me.dtpACFrom.ShowCheckBox = True
        Me.dtpACFrom.Size = New System.Drawing.Size(203, 20)
        Me.dtpACFrom.TabIndex = 11
        '
        'dtpACTo
        '
        Me.dtpACTo.CustomFormat = "MMMM dd, yyyy"
        Me.dtpACTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpACTo.Location = New System.Drawing.Point(108, 235)
        Me.dtpACTo.Name = "dtpACTo"
        Me.dtpACTo.ShowCheckBox = True
        Me.dtpACTo.Size = New System.Drawing.Size(203, 20)
        Me.dtpACTo.TabIndex = 13
        '
        'txtReceiptNo
        '
        Me.txtReceiptNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReceiptNo.Location = New System.Drawing.Point(395, 55)
        Me.txtReceiptNo.Name = "txtReceiptNo"
        Me.txtReceiptNo.Size = New System.Drawing.Size(203, 20)
        Me.txtReceiptNo.TabIndex = 16
        '
        'txtPaidTo
        '
        Me.txtPaidTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPaidTo.Location = New System.Drawing.Point(395, 145)
        Me.txtPaidTo.Name = "txtPaidTo"
        Me.txtPaidTo.Size = New System.Drawing.Size(203, 20)
        Me.txtPaidTo.TabIndex = 22
        '
        'optPerson
        '
        Me.optPerson.AutoSize = True
        Me.optPerson.Checked = True
        Me.optPerson.Location = New System.Drawing.Point(395, 175)
        Me.optPerson.Name = "optPerson"
        Me.optPerson.Size = New System.Drawing.Size(58, 17)
        Me.optPerson.TabIndex = 23
        Me.optPerson.TabStop = True
        Me.optPerson.Text = "Person"
        Me.optPerson.UseVisualStyleBackColor = True
        '
        'optEstablishment
        '
        Me.optEstablishment.AutoSize = True
        Me.optEstablishment.Location = New System.Drawing.Point(459, 175)
        Me.optEstablishment.Name = "optEstablishment"
        Me.optEstablishment.Size = New System.Drawing.Size(90, 17)
        Me.optEstablishment.TabIndex = 24
        Me.optEstablishment.TabStop = True
        Me.optEstablishment.Text = "Establishment"
        Me.optEstablishment.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(289, 59)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(26, 13)
        Me.LinkLabel1.TabIndex = 14
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Add"
        '
        'txtCheckNo
        '
        Me.txtCheckNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheckNo.Location = New System.Drawing.Point(395, 86)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(203, 20)
        Me.txtCheckNo.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(328, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Check No"
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtVoucherNo.Location = New System.Drawing.Point(395, 117)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(203, 20)
        Me.txtVoucherNo.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(328, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "Voucher No"
        '
        'frmExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(613, 327)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtCheckNo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.optEstablishment)
        Me.Controls.Add(Me.optPerson)
        Me.Controls.Add(Me.txtPaidTo)
        Me.Controls.Add(Me.txtReceiptNo)
        Me.Controls.Add(Me.dtpACTo)
        Me.Controls.Add(Me.dtpACFrom)
        Me.Controls.Add(Me.dtpDatePosted)
        Me.Controls.Add(Me.dtpDateIncurred)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.cboExpensesType)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbrMainForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExpenses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disbursement"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents cboExpensesType As System.Windows.Forms.ComboBox
    Friend WithEvents txtAmount As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateIncurred As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDatePosted As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpACFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpACTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPaidTo As System.Windows.Forms.TextBox
    Friend WithEvents optPerson As System.Windows.Forms.RadioButton
    Friend WithEvents optEstablishment As System.Windows.Forms.RadioButton
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtCheckNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
