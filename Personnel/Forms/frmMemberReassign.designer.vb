<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberReassign
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMemberReassign))
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.txtMemberIdToReplace = New System.Windows.Forms.TextBox
        Me.txtMemberNameToReplace = New System.Windows.Forms.TextBox
        Me.dtpManagementDt = New System.Windows.Forms.DateTimePicker
        Me.lblReassignedDt = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblMemberNameToReplace = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDepartmentId = New System.Windows.Forms.TextBox
        Me.txtDepartmentName = New System.Windows.Forms.TextBox
        Me.lblDepartmentName = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboJobId = New System.Windows.Forms.ComboBox
        Me.cboJobTitle = New System.Windows.Forms.ComboBox
        Me.lblJobTitle = New System.Windows.Forms.Label
        Me.lblToReplace = New System.Windows.Forms.Label
        Me.cboAppointmentId = New System.Windows.Forms.ComboBox
        Me.cboStatusAppointment = New System.Windows.Forms.ComboBox
        Me.lblStatusofAppointment = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFind
        '
        Me.btnFind.ImageIndex = 3
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Find"
        Me.btnFind.ToolTipText = "Launch Finder Screen"
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
        'btnSave
        '
        Me.btnSave.ImageIndex = 4
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save Record"
        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Delete record"
        '
        'btnCancel
        '
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancel Changes Made"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(674, 37)
        Me.pnlToolbar.TabIndex = 160
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
        Me.tbrMainForm.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbrMainForm.Name = "tbrMainForm"
        Me.tbrMainForm.ShowToolTips = True
        Me.tbrMainForm.Size = New System.Drawing.Size(674, 40)
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
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 6
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Text = "Approve"
        '
        'txtMemberIdToReplace
        '
        Me.txtMemberIdToReplace.Location = New System.Drawing.Point(645, 280)
        Me.txtMemberIdToReplace.Name = "txtMemberIdToReplace"
        Me.txtMemberIdToReplace.ReadOnly = True
        Me.txtMemberIdToReplace.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberIdToReplace.TabIndex = 19
        Me.txtMemberIdToReplace.TabStop = False
        Me.txtMemberIdToReplace.Visible = False
        '
        'txtMemberNameToReplace
        '
        Me.txtMemberNameToReplace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberNameToReplace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberNameToReplace.Location = New System.Drawing.Point(130, 280)
        Me.txtMemberNameToReplace.Name = "txtMemberNameToReplace"
        Me.txtMemberNameToReplace.Size = New System.Drawing.Size(535, 20)
        Me.txtMemberNameToReplace.TabIndex = 18
        '
        'dtpManagementDt
        '
        Me.dtpManagementDt.Checked = False
        Me.dtpManagementDt.CustomFormat = "MMMM dd, yyyy"
        Me.dtpManagementDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpManagementDt.Location = New System.Drawing.Point(130, 95)
        Me.dtpManagementDt.Name = "dtpManagementDt"
        Me.dtpManagementDt.ShowCheckBox = True
        Me.dtpManagementDt.Size = New System.Drawing.Size(200, 20)
        Me.dtpManagementDt.TabIndex = 4
        Me.dtpManagementDt.Tag = "0"
        '
        'lblReassignedDt
        '
        Me.lblReassignedDt.BackColor = System.Drawing.Color.Transparent
        Me.lblReassignedDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReassignedDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReassignedDt.Location = New System.Drawing.Point(15, 95)
        Me.lblReassignedDt.Name = "lblReassignedDt"
        Me.lblReassignedDt.Size = New System.Drawing.Size(115, 15)
        Me.lblReassignedDt.TabIndex = 3
        Me.lblReassignedDt.Text = "Date Reassigned"
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(15, 185)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(115, 16)
        Me.lblRemarks.TabIndex = 14
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(130, 185)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(535, 60)
        Me.txtRemarks.TabIndex = 15
        '
        'txtMemberId
        '
        Me.txtMemberId.Location = New System.Drawing.Point(645, 65)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 2
        Me.txtMemberId.TabStop = False
        Me.txtMemberId.Visible = False
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(130, 65)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(535, 20)
        Me.txtMemberName.TabIndex = 1
        '
        'lblMemberName
        '
        Me.lblMemberName.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(15, 65)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(115, 15)
        Me.lblMemberName.TabIndex = 0
        Me.lblMemberName.Text = "Member Name *"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(15, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Member Name"
        '
        'lblMemberNameToReplace
        '
        Me.lblMemberNameToReplace.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberNameToReplace.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMemberNameToReplace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberNameToReplace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNameToReplace.Location = New System.Drawing.Point(15, 280)
        Me.lblMemberNameToReplace.Name = "lblMemberNameToReplace"
        Me.lblMemberNameToReplace.Size = New System.Drawing.Size(115, 15)
        Me.lblMemberNameToReplace.TabIndex = 17
        Me.lblMemberNameToReplace.Text = "Member To Replace"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 280)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Member To Replace"
        '
        'txtDepartmentId
        '
        Me.txtDepartmentId.Location = New System.Drawing.Point(645, 125)
        Me.txtDepartmentId.Name = "txtDepartmentId"
        Me.txtDepartmentId.ReadOnly = True
        Me.txtDepartmentId.Size = New System.Drawing.Size(20, 20)
        Me.txtDepartmentId.TabIndex = 7
        Me.txtDepartmentId.TabStop = False
        Me.txtDepartmentId.Visible = False
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentName.Location = New System.Drawing.Point(130, 125)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(535, 20)
        Me.txtDepartmentName.TabIndex = 6
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentName.Location = New System.Drawing.Point(15, 125)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(115, 15)
        Me.lblDepartmentName.TabIndex = 5
        Me.lblDepartmentName.Text = "To Department Name *"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "To Department Name"
        '
        'cboJobId
        '
        Me.cboJobId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobId.FormattingEnabled = True
        Me.cboJobId.Location = New System.Drawing.Point(310, 155)
        Me.cboJobId.Name = "cboJobId"
        Me.cboJobId.Size = New System.Drawing.Size(20, 22)
        Me.cboJobId.TabIndex = 10
        Me.cboJobId.TabStop = False
        Me.cboJobId.Visible = False
        '
        'cboJobTitle
        '
        Me.cboJobTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJobTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobTitle.DropDownWidth = 300
        Me.cboJobTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJobTitle.ItemHeight = 14
        Me.cboJobTitle.Location = New System.Drawing.Point(130, 155)
        Me.cboJobTitle.Name = "cboJobTitle"
        Me.cboJobTitle.Size = New System.Drawing.Size(200, 22)
        Me.cboJobTitle.TabIndex = 9
        '
        'lblJobTitle
        '
        Me.lblJobTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblJobTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJobTitle.Location = New System.Drawing.Point(15, 155)
        Me.lblJobTitle.Name = "lblJobTitle"
        Me.lblJobTitle.Size = New System.Drawing.Size(115, 15)
        Me.lblJobTitle.TabIndex = 8
        Me.lblJobTitle.Text = "Job Title / Position"
        '
        'lblToReplace
        '
        Me.lblToReplace.AutoSize = True
        Me.lblToReplace.BackColor = System.Drawing.Color.Transparent
        Me.lblToReplace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToReplace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblToReplace.Location = New System.Drawing.Point(15, 255)
        Me.lblToReplace.Name = "lblToReplace"
        Me.lblToReplace.Size = New System.Drawing.Size(288, 14)
        Me.lblToReplace.TabIndex = 16
        Me.lblToReplace.Text = "* IF MEMBER HAS TO REPLACE SOMEONE (OPTIONAL)"
        '
        'cboAppointmentId
        '
        Me.cboAppointmentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAppointmentId.FormattingEnabled = True
        Me.cboAppointmentId.Location = New System.Drawing.Point(645, 155)
        Me.cboAppointmentId.Name = "cboAppointmentId"
        Me.cboAppointmentId.Size = New System.Drawing.Size(20, 22)
        Me.cboAppointmentId.TabIndex = 13
        Me.cboAppointmentId.TabStop = False
        Me.cboAppointmentId.Visible = False
        '
        'cboStatusAppointment
        '
        Me.cboStatusAppointment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatusAppointment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatusAppointment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusAppointment.DropDownWidth = 250
        Me.cboStatusAppointment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusAppointment.ItemHeight = 14
        Me.cboStatusAppointment.Location = New System.Drawing.Point(465, 155)
        Me.cboStatusAppointment.Name = "cboStatusAppointment"
        Me.cboStatusAppointment.Size = New System.Drawing.Size(200, 22)
        Me.cboStatusAppointment.TabIndex = 12
        '
        'lblStatusofAppointment
        '
        Me.lblStatusofAppointment.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusofAppointment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusofAppointment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatusofAppointment.Location = New System.Drawing.Point(350, 155)
        Me.lblStatusofAppointment.Name = "lblStatusofAppointment"
        Me.lblStatusofAppointment.Size = New System.Drawing.Size(115, 15)
        Me.lblStatusofAppointment.TabIndex = 11
        Me.lblStatusofAppointment.Text = "Status of Appointment"
        '
        'frmMemberReassign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 317)
        Me.Controls.Add(Me.cboAppointmentId)
        Me.Controls.Add(Me.cboStatusAppointment)
        Me.Controls.Add(Me.lblStatusofAppointment)
        Me.Controls.Add(Me.lblToReplace)
        Me.Controls.Add(Me.cboJobId)
        Me.Controls.Add(Me.cboJobTitle)
        Me.Controls.Add(Me.lblJobTitle)
        Me.Controls.Add(Me.txtDepartmentId)
        Me.Controls.Add(Me.txtDepartmentName)
        Me.Controls.Add(Me.txtMemberIdToReplace)
        Me.Controls.Add(Me.txtMemberNameToReplace)
        Me.Controls.Add(Me.dtpManagementDt)
        Me.Controls.Add(Me.lblReassignedDt)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtMemberId)
        Me.Controls.Add(Me.txtMemberName)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblDepartmentName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMemberNameToReplace)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMemberReassign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Reassign"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtMemberIdToReplace As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberNameToReplace As System.Windows.Forms.TextBox
    Friend WithEvents dtpManagementDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReassignedDt As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMemberNameToReplace As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDepartmentId As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartmentName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboJobId As System.Windows.Forms.ComboBox
    Friend WithEvents cboJobTitle As System.Windows.Forms.ComboBox
    Friend WithEvents lblJobTitle As System.Windows.Forms.Label
    Friend WithEvents lblToReplace As System.Windows.Forms.Label
    Friend WithEvents cboAppointmentId As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusAppointment As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusofAppointment As System.Windows.Forms.Label
End Class
