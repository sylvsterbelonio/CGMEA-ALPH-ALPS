<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemUser
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemUser))
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.grpGeneralInfo = New System.Windows.Forms.GroupBox
        Me.txtRoleId = New System.Windows.Forms.TextBox
        Me.txtRoleName = New System.Windows.Forms.TextBox
        Me.lblVerify = New System.Windows.Forms.Label
        Me.txtVerify = New System.Windows.Forms.TextBox
        Me.lblActive = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblUserName = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.btnPassword = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.lblRole = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.grpMemberDetails = New System.Windows.Forms.GroupBox
        Me.lblAge = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.btnPicture = New System.Windows.Forms.Button
        Me.cmenuPhoto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuClear = New System.Windows.Forms.ToolStripMenuItem
        Me.txtBDate = New System.Windows.Forms.Label
        Me.cboJobTitle = New System.Windows.Forms.ComboBox
        Me.cboGender = New System.Windows.Forms.ComboBox
        Me.lblGender = New System.Windows.Forms.Label
        Me.txtLName = New System.Windows.Forms.TextBox
        Me.txtMName = New System.Windows.Forms.TextBox
        Me.lblLName = New System.Windows.Forms.Label
        Me.lblMName = New System.Windows.Forms.Label
        Me.lblFName = New System.Windows.Forms.Label
        Me.txtFName = New System.Windows.Forms.TextBox
        Me.lblJob = New System.Windows.Forms.Label
        Me.dtBDate = New System.Windows.Forms.DateTimePicker
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.txtEmployeeId = New System.Windows.Forms.TextBox
        Me.txtEmployeeNo = New System.Windows.Forms.TextBox
        Me.pnlToolbar.SuspendLayout()
        Me.grpGeneralInfo.SuspendLayout()
        Me.grpMemberDetails.SuspendLayout()
        Me.cmenuPhoto.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(650, 45)
        Me.pnlToolbar.TabIndex = 15
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
        Me.tbrMainForm.Size = New System.Drawing.Size(650, 40)
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
        'grpGeneralInfo
        '
        Me.grpGeneralInfo.Controls.Add(Me.txtEmployeeNo)
        Me.grpGeneralInfo.Controls.Add(Me.txtEmployeeId)
        Me.grpGeneralInfo.Controls.Add(Me.txtRoleId)
        Me.grpGeneralInfo.Controls.Add(Me.txtRoleName)
        Me.grpGeneralInfo.Controls.Add(Me.lblVerify)
        Me.grpGeneralInfo.Controls.Add(Me.txtVerify)
        Me.grpGeneralInfo.Controls.Add(Me.lblActive)
        Me.grpGeneralInfo.Controls.Add(Me.chkActive)
        Me.grpGeneralInfo.Controls.Add(Me.lblPassword)
        Me.grpGeneralInfo.Controls.Add(Me.lblUserName)
        Me.grpGeneralInfo.Controls.Add(Me.txtUserName)
        Me.grpGeneralInfo.Controls.Add(Me.btnPassword)
        Me.grpGeneralInfo.Controls.Add(Me.txtPassword)
        Me.grpGeneralInfo.Controls.Add(Me.lblRole)
        Me.grpGeneralInfo.Controls.Add(Me.Label1)
        Me.grpGeneralInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpGeneralInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpGeneralInfo.Location = New System.Drawing.Point(10, 50)
        Me.grpGeneralInfo.Name = "grpGeneralInfo"
        Me.grpGeneralInfo.Size = New System.Drawing.Size(625, 105)
        Me.grpGeneralInfo.TabIndex = 0
        Me.grpGeneralInfo.TabStop = False
        Me.grpGeneralInfo.Text = "General Information"
        '
        'txtRoleId
        '
        Me.txtRoleId.Location = New System.Drawing.Point(285, 20)
        Me.txtRoleId.Name = "txtRoleId"
        Me.txtRoleId.ReadOnly = True
        Me.txtRoleId.Size = New System.Drawing.Size(20, 20)
        Me.txtRoleId.TabIndex = 2
        Me.txtRoleId.TabStop = False
        Me.txtRoleId.Visible = False
        '
        'txtRoleName
        '
        Me.txtRoleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoleName.Location = New System.Drawing.Point(105, 20)
        Me.txtRoleName.Name = "txtRoleName"
        Me.txtRoleName.Size = New System.Drawing.Size(200, 20)
        Me.txtRoleName.TabIndex = 1
        '
        'lblVerify
        '
        Me.lblVerify.BackColor = System.Drawing.SystemColors.Control
        Me.lblVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblVerify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerify.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVerify.Location = New System.Drawing.Point(315, 50)
        Me.lblVerify.Name = "lblVerify"
        Me.lblVerify.Size = New System.Drawing.Size(90, 16)
        Me.lblVerify.TabIndex = 7
        Me.lblVerify.Text = "Verify Password"
        Me.lblVerify.Visible = False
        '
        'txtVerify
        '
        Me.txtVerify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVerify.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVerify.Location = New System.Drawing.Point(410, 50)
        Me.txtVerify.Name = "txtVerify"
        Me.txtVerify.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtVerify.Size = New System.Drawing.Size(200, 20)
        Me.txtVerify.TabIndex = 8
        Me.txtVerify.Visible = False
        '
        'lblActive
        '
        Me.lblActive.BackColor = System.Drawing.SystemColors.Control
        Me.lblActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblActive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblActive.Location = New System.Drawing.Point(15, 80)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(90, 16)
        Me.lblActive.TabIndex = 9
        Me.lblActive.Text = "User Active ?"
        '
        'chkActive
        '
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Enabled = False
        Me.chkActive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(105, 80)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(20, 20)
        Me.chkActive.TabIndex = 10
        Me.chkActive.TabStop = False
        Me.chkActive.Tag = "1"
        '
        'lblPassword
        '
        Me.lblPassword.BackColor = System.Drawing.SystemColors.Control
        Me.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPassword.Location = New System.Drawing.Point(15, 50)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(90, 16)
        Me.lblPassword.TabIndex = 5
        Me.lblPassword.Text = "Password"
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.SystemColors.Control
        Me.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblUserName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblUserName.Location = New System.Drawing.Point(315, 20)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(90, 16)
        Me.lblUserName.TabIndex = 3
        Me.lblUserName.Text = "User Name"
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUserName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUserName.Location = New System.Drawing.Point(410, 20)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(200, 20)
        Me.txtUserName.TabIndex = 4
        '
        'btnPassword
        '
        Me.btnPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPassword.Location = New System.Drawing.Point(105, 50)
        Me.btnPassword.Name = "btnPassword"
        Me.btnPassword.Size = New System.Drawing.Size(200, 25)
        Me.btnPassword.TabIndex = 6
        Me.btnPassword.Text = "&Reset Password"
        Me.btnPassword.Visible = False
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPassword.Location = New System.Drawing.Point(105, 50)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(200, 20)
        Me.txtPassword.TabIndex = 4
        '
        'lblRole
        '
        Me.lblRole.BackColor = System.Drawing.SystemColors.Control
        Me.lblRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRole.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRole.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRole.Location = New System.Drawing.Point(15, 20)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(90, 16)
        Me.lblRole.TabIndex = 0
        Me.lblRole.Text = "System Role *"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "System Role"
        '
        'grpMemberDetails
        '
        Me.grpMemberDetails.Controls.Add(Me.lblAge)
        Me.grpMemberDetails.Controls.Add(Me.cboStatus)
        Me.grpMemberDetails.Controls.Add(Me.lblStatus)
        Me.grpMemberDetails.Controls.Add(Me.Label5)
        Me.grpMemberDetails.Controls.Add(Me.txtFileName)
        Me.grpMemberDetails.Controls.Add(Me.btnPicture)
        Me.grpMemberDetails.Controls.Add(Me.txtBDate)
        Me.grpMemberDetails.Controls.Add(Me.cboJobTitle)
        Me.grpMemberDetails.Controls.Add(Me.cboGender)
        Me.grpMemberDetails.Controls.Add(Me.lblGender)
        Me.grpMemberDetails.Controls.Add(Me.txtLName)
        Me.grpMemberDetails.Controls.Add(Me.txtMName)
        Me.grpMemberDetails.Controls.Add(Me.lblLName)
        Me.grpMemberDetails.Controls.Add(Me.lblMName)
        Me.grpMemberDetails.Controls.Add(Me.lblFName)
        Me.grpMemberDetails.Controls.Add(Me.txtFName)
        Me.grpMemberDetails.Controls.Add(Me.lblJob)
        Me.grpMemberDetails.Controls.Add(Me.dtBDate)
        Me.grpMemberDetails.Controls.Add(Me.txtMemberId)
        Me.grpMemberDetails.Controls.Add(Me.lblMemberNo)
        Me.grpMemberDetails.Controls.Add(Me.txtMemberNo)
        Me.grpMemberDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpMemberDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpMemberDetails.Location = New System.Drawing.Point(10, 160)
        Me.grpMemberDetails.Name = "grpMemberDetails"
        Me.grpMemberDetails.Size = New System.Drawing.Size(625, 240)
        Me.grpMemberDetails.TabIndex = 1
        Me.grpMemberDetails.TabStop = False
        Me.grpMemberDetails.Text = "Member Details"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        Me.lblAge.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAge.Location = New System.Drawing.Point(310, 165)
        Me.lblAge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(21, 14)
        Me.lblAge.TabIndex = 16
        Me.lblAge.Text = "(0)"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.ItemHeight = 14
        Me.cboStatus.Items.AddRange(New Object() {"Not Specified", "Annulled", "Cohabiting", "Deceased", "Divorced", "Engaged", "Married", "Separated", "Single", "Widowed"})
        Me.cboStatus.Location = New System.Drawing.Point(410, 195)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(200, 22)
        Me.cboStatus.TabIndex = 20
        Me.cboStatus.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.SystemColors.Control
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(315, 195)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(90, 16)
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.Text = "Civil Status"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(315, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Member Photo"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(385, 165)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(20, 20)
        Me.txtFileName.TabIndex = 5
        Me.txtFileName.TabStop = False
        Me.txtFileName.Visible = False
        '
        'btnPicture
        '
        Me.btnPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPicture.ContextMenuStrip = Me.cmenuPhoto
        Me.btnPicture.Enabled = False
        Me.btnPicture.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPicture.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnPicture.Location = New System.Drawing.Point(410, 20)
        Me.btnPicture.Name = "btnPicture"
        Me.btnPicture.Size = New System.Drawing.Size(200, 165)
        Me.btnPicture.TabIndex = 4
        Me.btnPicture.TabStop = False
        Me.btnPicture.UseVisualStyleBackColor = True
        '
        'cmenuPhoto
        '
        Me.cmenuPhoto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuClear})
        Me.cmenuPhoto.Name = "cmenuPhoto"
        Me.cmenuPhoto.Size = New System.Drawing.Size(137, 26)
        '
        'cmnuClear
        '
        Me.cmnuClear.Name = "cmnuClear"
        Me.cmnuClear.Size = New System.Drawing.Size(136, 22)
        Me.cmnuClear.Text = "&Clear Photo"
        '
        'txtBDate
        '
        Me.txtBDate.BackColor = System.Drawing.SystemColors.Control
        Me.txtBDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBDate.Location = New System.Drawing.Point(15, 165)
        Me.txtBDate.Name = "txtBDate"
        Me.txtBDate.Size = New System.Drawing.Size(90, 16)
        Me.txtBDate.TabIndex = 14
        Me.txtBDate.Text = "Birth Date"
        '
        'cboJobTitle
        '
        Me.cboJobTitle.Enabled = False
        Me.cboJobTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJobTitle.ItemHeight = 14
        Me.cboJobTitle.Location = New System.Drawing.Point(105, 135)
        Me.cboJobTitle.Name = "cboJobTitle"
        Me.cboJobTitle.Size = New System.Drawing.Size(200, 22)
        Me.cboJobTitle.TabIndex = 13
        Me.cboJobTitle.TabStop = False
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.Enabled = False
        Me.cboGender.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGender.ItemHeight = 14
        Me.cboGender.Items.AddRange(New Object() {"Not Specified", "Male", "Female"})
        Me.cboGender.Location = New System.Drawing.Point(105, 195)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(200, 22)
        Me.cboGender.TabIndex = 18
        Me.cboGender.TabStop = False
        '
        'lblGender
        '
        Me.lblGender.BackColor = System.Drawing.SystemColors.Control
        Me.lblGender.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGender.Location = New System.Drawing.Point(15, 195)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(90, 16)
        Me.lblGender.TabIndex = 17
        Me.lblGender.Text = "Gender"
        '
        'txtLName
        '
        Me.txtLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLName.Location = New System.Drawing.Point(105, 105)
        Me.txtLName.Name = "txtLName"
        Me.txtLName.ReadOnly = True
        Me.txtLName.Size = New System.Drawing.Size(200, 20)
        Me.txtLName.TabIndex = 11
        Me.txtLName.TabStop = False
        '
        'txtMName
        '
        Me.txtMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMName.Location = New System.Drawing.Point(105, 75)
        Me.txtMName.Name = "txtMName"
        Me.txtMName.ReadOnly = True
        Me.txtMName.Size = New System.Drawing.Size(200, 20)
        Me.txtMName.TabIndex = 9
        Me.txtMName.TabStop = False
        '
        'lblLName
        '
        Me.lblLName.BackColor = System.Drawing.SystemColors.Control
        Me.lblLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLName.Location = New System.Drawing.Point(15, 105)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(90, 16)
        Me.lblLName.TabIndex = 10
        Me.lblLName.Text = "Last Name"
        '
        'lblMName
        '
        Me.lblMName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMName.Location = New System.Drawing.Point(15, 75)
        Me.lblMName.Name = "lblMName"
        Me.lblMName.Size = New System.Drawing.Size(90, 16)
        Me.lblMName.TabIndex = 8
        Me.lblMName.Text = "Middle Name"
        '
        'lblFName
        '
        Me.lblFName.BackColor = System.Drawing.SystemColors.Control
        Me.lblFName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblFName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFName.Location = New System.Drawing.Point(15, 45)
        Me.lblFName.Name = "lblFName"
        Me.lblFName.Size = New System.Drawing.Size(90, 16)
        Me.lblFName.TabIndex = 6
        Me.lblFName.Text = "First Name"
        '
        'txtFName
        '
        Me.txtFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFName.Location = New System.Drawing.Point(105, 45)
        Me.txtFName.Name = "txtFName"
        Me.txtFName.ReadOnly = True
        Me.txtFName.Size = New System.Drawing.Size(200, 20)
        Me.txtFName.TabIndex = 7
        Me.txtFName.TabStop = False
        '
        'lblJob
        '
        Me.lblJob.BackColor = System.Drawing.SystemColors.Control
        Me.lblJob.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJob.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJob.Location = New System.Drawing.Point(15, 135)
        Me.lblJob.Name = "lblJob"
        Me.lblJob.Size = New System.Drawing.Size(90, 16)
        Me.lblJob.TabIndex = 12
        Me.lblJob.Text = "Job Title"
        '
        'dtBDate
        '
        Me.dtBDate.Enabled = False
        Me.dtBDate.Location = New System.Drawing.Point(105, 165)
        Me.dtBDate.Name = "dtBDate"
        Me.dtBDate.Size = New System.Drawing.Size(200, 20)
        Me.dtBDate.TabIndex = 15
        Me.dtBDate.TabStop = False
        '
        'txtMemberId
        '
        Me.txtMemberId.Location = New System.Drawing.Point(285, 20)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 2
        Me.txtMemberId.TabStop = False
        Me.txtMemberId.Visible = False
        '
        'lblMemberNo
        '
        Me.lblMemberNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lblMemberNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNo.Location = New System.Drawing.Point(15, 23)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(90, 16)
        Me.lblMemberNo.TabIndex = 7
        Me.lblMemberNo.Text = "Member No. *"
        '
        'txtMemberNo
        '
        Me.txtMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberNo.Location = New System.Drawing.Point(105, 20)
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberNo.TabIndex = 1
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeId.Location = New System.Drawing.Point(410, 80)
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.ReadOnly = True
        Me.txtEmployeeId.Size = New System.Drawing.Size(73, 20)
        Me.txtEmployeeId.TabIndex = 11
        Me.txtEmployeeId.TabStop = False
        Me.txtEmployeeId.Visible = False
        '
        'txtEmployeeNo
        '
        Me.txtEmployeeNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeNo.Location = New System.Drawing.Point(489, 80)
        Me.txtEmployeeNo.Name = "txtEmployeeNo"
        Me.txtEmployeeNo.ReadOnly = True
        Me.txtEmployeeNo.Size = New System.Drawing.Size(73, 20)
        Me.txtEmployeeNo.TabIndex = 12
        Me.txtEmployeeNo.TabStop = False
        Me.txtEmployeeNo.Visible = False
        '
        'frmSystemUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(644, 408)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.grpGeneralInfo)
        Me.Controls.Add(Me.grpMemberDetails)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSystemUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System User"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.grpGeneralInfo.ResumeLayout(False)
        Me.grpGeneralInfo.PerformLayout()
        Me.grpMemberDetails.ResumeLayout(False)
        Me.grpMemberDetails.PerformLayout()
        Me.cmenuPhoto.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents grpGeneralInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblActive As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents lblVerify As System.Windows.Forms.Label
    Friend WithEvents txtVerify As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblRole As System.Windows.Forms.Label
    Friend WithEvents btnPassword As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents grpMemberDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtBDate As System.Windows.Forms.Label
    Friend WithEvents cboJobTitle As System.Windows.Forms.ComboBox
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents lblLName As System.Windows.Forms.Label
    Friend WithEvents lblMName As System.Windows.Forms.Label
    Friend WithEvents lblFName As System.Windows.Forms.Label
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblJob As System.Windows.Forms.Label
    Friend WithEvents dtBDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnPicture As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cmenuPhoto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtRoleId As System.Windows.Forms.TextBox
    Friend WithEvents txtRoleName As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeNo As System.Windows.Forms.TextBox
    Friend WithEvents txtEmployeeId As System.Windows.Forms.TextBox
End Class
