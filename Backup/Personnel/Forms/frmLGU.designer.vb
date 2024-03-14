<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLGU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLGU))
        Me.cmenuLogo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuClear = New System.Windows.Forms.ToolStripMenuItem
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
        Me.txtLGUDescription = New System.Windows.Forms.TextBox
        Me.txtLGUCode = New System.Windows.Forms.TextBox
        Me.lblLGUDescription = New System.Windows.Forms.Label
        Me.lblLGUCode = New System.Windows.Forms.Label
        Me.lblLGUName = New System.Windows.Forms.Label
        Me.txtLGUName = New System.Windows.Forms.TextBox
        Me.lblLGULogo = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.btnLogo = New System.Windows.Forms.Button
        Me.lblZipCode = New System.Windows.Forms.Label
        Me.cboZipCodeId = New System.Windows.Forms.ComboBox
        Me.cboZipCodeArea = New System.Windows.Forms.ComboBox
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.lblZipCodeArea = New System.Windows.Forms.Label
        Me.lblRegion = New System.Windows.Forms.Label
        Me.lblBarangay = New System.Windows.Forms.Label
        Me.lblMunicipality = New System.Windows.Forms.Label
        Me.lblProvince = New System.Windows.Forms.Label
        Me.cboRurcode = New System.Windows.Forms.ComboBox
        Me.cboMcode = New System.Windows.Forms.ComboBox
        Me.cboPcode = New System.Windows.Forms.ComboBox
        Me.cboBarangay = New System.Windows.Forms.ComboBox
        Me.cboMunicipality = New System.Windows.Forms.ComboBox
        Me.cboProvince = New System.Windows.Forms.ComboBox
        Me.lblLGUAddress = New System.Windows.Forms.Label
        Me.txtLGUAddress = New System.Windows.Forms.TextBox
        Me.cboZipCode = New System.Windows.Forms.ComboBox
        Me.lblFaxNo = New System.Windows.Forms.Label
        Me.txtFaxNo = New System.Windows.Forms.TextBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.lblLastName = New System.Windows.Forms.Label
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.txtWebsite = New System.Windows.Forms.TextBox
        Me.lblWebsite = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.lblEmailAddress = New System.Windows.Forms.Label
        Me.lblTelNo = New System.Windows.Forms.Label
        Me.txtTelNo = New System.Windows.Forms.TextBox
        Me.grpLGUProfile = New System.Windows.Forms.GroupBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.grpContactDetails = New System.Windows.Forms.GroupBox
        Me.cmenuLogo.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.grpLGUProfile.SuspendLayout()
        Me.grpContactDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmenuLogo
        '
        Me.cmenuLogo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuClear})
        Me.cmenuLogo.Name = "cmenuPhoto"
        Me.cmenuLogo.Size = New System.Drawing.Size(132, 26)
        '
        'cmnuClear
        '
        Me.cmnuClear.Name = "cmnuClear"
        Me.cmnuClear.Size = New System.Drawing.Size(131, 22)
        Me.cmnuClear.Text = "&Clear Logo"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(974, 40)
        Me.pnlToolbar.TabIndex = 16
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
        Me.tbrMainForm.Size = New System.Drawing.Size(974, 40)
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
        'txtLGUDescription
        '
        Me.txtLGUDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLGUDescription.Location = New System.Drawing.Point(105, 50)
        Me.txtLGUDescription.Multiline = True
        Me.txtLGUDescription.Name = "txtLGUDescription"
        Me.txtLGUDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLGUDescription.Size = New System.Drawing.Size(510, 50)
        Me.txtLGUDescription.TabIndex = 8
        '
        'txtLGUCode
        '
        Me.txtLGUCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLGUCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLGUCode.Location = New System.Drawing.Point(415, 20)
        Me.txtLGUCode.Name = "txtLGUCode"
        Me.txtLGUCode.Size = New System.Drawing.Size(200, 20)
        Me.txtLGUCode.TabIndex = 3
        '
        'lblLGUDescription
        '
        Me.lblLGUDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblLGUDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLGUDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLGUDescription.Location = New System.Drawing.Point(15, 50)
        Me.lblLGUDescription.Name = "lblLGUDescription"
        Me.lblLGUDescription.Size = New System.Drawing.Size(90, 16)
        Me.lblLGUDescription.TabIndex = 7
        Me.lblLGUDescription.Text = "Description"
        '
        'lblLGUCode
        '
        Me.lblLGUCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblLGUCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLGUCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLGUCode.Location = New System.Drawing.Point(325, 20)
        Me.lblLGUCode.Name = "lblLGUCode"
        Me.lblLGUCode.Size = New System.Drawing.Size(90, 16)
        Me.lblLGUCode.TabIndex = 2
        Me.lblLGUCode.Text = "Code"
        '
        'lblLGUName
        '
        Me.lblLGUName.BackColor = System.Drawing.SystemColors.Control
        Me.lblLGUName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLGUName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLGUName.Location = New System.Drawing.Point(15, 20)
        Me.lblLGUName.Name = "lblLGUName"
        Me.lblLGUName.Size = New System.Drawing.Size(90, 16)
        Me.lblLGUName.TabIndex = 0
        Me.lblLGUName.Text = "Name"
        '
        'txtLGUName
        '
        Me.txtLGUName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLGUName.Location = New System.Drawing.Point(105, 20)
        Me.txtLGUName.Name = "txtLGUName"
        Me.txtLGUName.Size = New System.Drawing.Size(200, 20)
        Me.txtLGUName.TabIndex = 1
        '
        'lblLGULogo
        '
        Me.lblLGULogo.BackColor = System.Drawing.SystemColors.Control
        Me.lblLGULogo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLGULogo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLGULogo.Location = New System.Drawing.Point(655, 20)
        Me.lblLGULogo.Name = "lblLGULogo"
        Me.lblLGULogo.Size = New System.Drawing.Size(90, 16)
        Me.lblLGULogo.TabIndex = 4
        Me.lblLGULogo.Text = "Logo"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(720, 140)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(20, 20)
        Me.txtFileName.TabIndex = 6
        Me.txtFileName.TabStop = False
        Me.txtFileName.Visible = False
        '
        'btnLogo
        '
        Me.btnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogo.ContextMenuStrip = Me.cmenuLogo
        Me.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogo.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLogo.Location = New System.Drawing.Point(745, 20)
        Me.btnLogo.Name = "btnLogo"
        Me.btnLogo.Size = New System.Drawing.Size(200, 140)
        Me.btnLogo.TabIndex = 5
        Me.btnLogo.UseVisualStyleBackColor = True
        '
        'lblZipCode
        '
        Me.lblZipCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZipCode.Location = New System.Drawing.Point(655, 200)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(90, 16)
        Me.lblZipCode.TabIndex = 26
        Me.lblZipCode.Text = "Zip Code Number"
        '
        'cboZipCodeId
        '
        Me.cboZipCodeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCodeId.FormattingEnabled = True
        Me.cboZipCodeId.Location = New System.Drawing.Point(595, 200)
        Me.cboZipCodeId.Name = "cboZipCodeId"
        Me.cboZipCodeId.Size = New System.Drawing.Size(20, 22)
        Me.cboZipCodeId.TabIndex = 25
        Me.cboZipCodeId.TabStop = False
        Me.cboZipCodeId.Visible = False
        '
        'cboZipCodeArea
        '
        Me.cboZipCodeArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCodeArea.DropDownWidth = 250
        Me.cboZipCodeArea.FormattingEnabled = True
        Me.cboZipCodeArea.Location = New System.Drawing.Point(415, 200)
        Me.cboZipCodeArea.Name = "cboZipCodeArea"
        Me.cboZipCodeArea.Size = New System.Drawing.Size(200, 22)
        Me.cboZipCodeArea.TabIndex = 24
        '
        'cboRcode
        '
        Me.cboRcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRcode.FormattingEnabled = True
        Me.cboRcode.Location = New System.Drawing.Point(285, 170)
        Me.cboRcode.Name = "cboRcode"
        Me.cboRcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRcode.TabIndex = 13
        Me.cboRcode.TabStop = False
        Me.cboRcode.Visible = False
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.DropDownWidth = 250
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(105, 170)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(200, 22)
        Me.cboRegion.TabIndex = 12
        '
        'lblZipCodeArea
        '
        Me.lblZipCodeArea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZipCodeArea.Location = New System.Drawing.Point(325, 200)
        Me.lblZipCodeArea.Name = "lblZipCodeArea"
        Me.lblZipCodeArea.Size = New System.Drawing.Size(90, 16)
        Me.lblZipCodeArea.TabIndex = 23
        Me.lblZipCodeArea.Text = "Zip Code Area"
        '
        'lblRegion
        '
        Me.lblRegion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegion.Location = New System.Drawing.Point(15, 170)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(90, 16)
        Me.lblRegion.TabIndex = 11
        Me.lblRegion.Text = "Region"
        '
        'lblBarangay
        '
        Me.lblBarangay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangay.Location = New System.Drawing.Point(15, 200)
        Me.lblBarangay.Name = "lblBarangay"
        Me.lblBarangay.Size = New System.Drawing.Size(90, 16)
        Me.lblBarangay.TabIndex = 20
        Me.lblBarangay.Text = "Barangay"
        '
        'lblMunicipality
        '
        Me.lblMunicipality.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipality.Location = New System.Drawing.Point(655, 175)
        Me.lblMunicipality.Name = "lblMunicipality"
        Me.lblMunicipality.Size = New System.Drawing.Size(90, 16)
        Me.lblMunicipality.TabIndex = 17
        Me.lblMunicipality.Text = "City / Municipality"
        '
        'lblProvince
        '
        Me.lblProvince.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvince.Location = New System.Drawing.Point(325, 170)
        Me.lblProvince.Name = "lblProvince"
        Me.lblProvince.Size = New System.Drawing.Size(90, 16)
        Me.lblProvince.TabIndex = 14
        Me.lblProvince.Text = "Province"
        '
        'cboRurcode
        '
        Me.cboRurcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRurcode.FormattingEnabled = True
        Me.cboRurcode.Location = New System.Drawing.Point(285, 200)
        Me.cboRurcode.Name = "cboRurcode"
        Me.cboRurcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRurcode.TabIndex = 22
        Me.cboRurcode.TabStop = False
        Me.cboRurcode.Visible = False
        '
        'cboMcode
        '
        Me.cboMcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMcode.FormattingEnabled = True
        Me.cboMcode.Location = New System.Drawing.Point(925, 170)
        Me.cboMcode.Name = "cboMcode"
        Me.cboMcode.Size = New System.Drawing.Size(20, 22)
        Me.cboMcode.TabIndex = 19
        Me.cboMcode.TabStop = False
        Me.cboMcode.Visible = False
        '
        'cboPcode
        '
        Me.cboPcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPcode.FormattingEnabled = True
        Me.cboPcode.Location = New System.Drawing.Point(595, 170)
        Me.cboPcode.Name = "cboPcode"
        Me.cboPcode.Size = New System.Drawing.Size(20, 22)
        Me.cboPcode.TabIndex = 16
        Me.cboPcode.TabStop = False
        Me.cboPcode.Visible = False
        '
        'cboBarangay
        '
        Me.cboBarangay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBarangay.DropDownWidth = 250
        Me.cboBarangay.FormattingEnabled = True
        Me.cboBarangay.Location = New System.Drawing.Point(105, 200)
        Me.cboBarangay.Name = "cboBarangay"
        Me.cboBarangay.Size = New System.Drawing.Size(200, 22)
        Me.cboBarangay.TabIndex = 21
        '
        'cboMunicipality
        '
        Me.cboMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipality.DropDownWidth = 250
        Me.cboMunicipality.FormattingEnabled = True
        Me.cboMunicipality.Location = New System.Drawing.Point(745, 170)
        Me.cboMunicipality.Name = "cboMunicipality"
        Me.cboMunicipality.Size = New System.Drawing.Size(200, 22)
        Me.cboMunicipality.TabIndex = 18
        '
        'cboProvince
        '
        Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvince.DropDownWidth = 250
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(415, 170)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(200, 22)
        Me.cboProvince.TabIndex = 15
        '
        'lblLGUAddress
        '
        Me.lblLGUAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblLGUAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLGUAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLGUAddress.Location = New System.Drawing.Point(15, 110)
        Me.lblLGUAddress.Name = "lblLGUAddress"
        Me.lblLGUAddress.Size = New System.Drawing.Size(90, 16)
        Me.lblLGUAddress.TabIndex = 9
        Me.lblLGUAddress.Text = "Address"
        '
        'txtLGUAddress
        '
        Me.txtLGUAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLGUAddress.Location = New System.Drawing.Point(105, 110)
        Me.txtLGUAddress.Multiline = True
        Me.txtLGUAddress.Name = "txtLGUAddress"
        Me.txtLGUAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLGUAddress.Size = New System.Drawing.Size(510, 50)
        Me.txtLGUAddress.TabIndex = 10
        '
        'cboZipCode
        '
        Me.cboZipCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCode.DropDownWidth = 250
        Me.cboZipCode.Enabled = False
        Me.cboZipCode.FormattingEnabled = True
        Me.cboZipCode.Location = New System.Drawing.Point(745, 200)
        Me.cboZipCode.Name = "cboZipCode"
        Me.cboZipCode.Size = New System.Drawing.Size(200, 22)
        Me.cboZipCode.TabIndex = 27
        '
        'lblFaxNo
        '
        Me.lblFaxNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblFaxNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaxNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFaxNo.Location = New System.Drawing.Point(15, 50)
        Me.lblFaxNo.Name = "lblFaxNo"
        Me.lblFaxNo.Size = New System.Drawing.Size(90, 16)
        Me.lblFaxNo.TabIndex = 6
        Me.lblFaxNo.Text = "Fax No."
        '
        'txtFaxNo
        '
        Me.txtFaxNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaxNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFaxNo.Location = New System.Drawing.Point(105, 50)
        Me.txtFaxNo.Name = "txtFaxNo"
        Me.txtFaxNo.Size = New System.Drawing.Size(200, 20)
        Me.txtFaxNo.TabIndex = 7
        '
        'lblFirstName
        '
        Me.lblFirstName.BackColor = System.Drawing.SystemColors.Control
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(15, 20)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(90, 16)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFirstName.Location = New System.Drawing.Point(105, 20)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'lblLastName
        '
        Me.lblLastName.BackColor = System.Drawing.SystemColors.Control
        Me.lblLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastName.Location = New System.Drawing.Point(325, 20)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(90, 16)
        Me.lblLastName.TabIndex = 2
        Me.lblLastName.Text = "Last Name"
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLastName.Location = New System.Drawing.Point(415, 20)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(200, 20)
        Me.txtLastName.TabIndex = 3
        '
        'txtWebsite
        '
        Me.txtWebsite.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtWebsite.Location = New System.Drawing.Point(745, 50)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(200, 20)
        Me.txtWebsite.TabIndex = 11
        '
        'lblWebsite
        '
        Me.lblWebsite.BackColor = System.Drawing.SystemColors.Control
        Me.lblWebsite.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebsite.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWebsite.Location = New System.Drawing.Point(655, 50)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(90, 16)
        Me.lblWebsite.TabIndex = 10
        Me.lblWebsite.Text = "Website"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEmailAddress.Location = New System.Drawing.Point(415, 50)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(200, 20)
        Me.txtEmailAddress.TabIndex = 9
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblEmailAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmailAddress.Location = New System.Drawing.Point(325, 50)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(90, 16)
        Me.lblEmailAddress.TabIndex = 8
        Me.lblEmailAddress.Text = "Email Address"
        '
        'lblTelNo
        '
        Me.lblTelNo.BackColor = System.Drawing.SystemColors.Control
        Me.lblTelNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTelNo.Location = New System.Drawing.Point(655, 20)
        Me.lblTelNo.Name = "lblTelNo"
        Me.lblTelNo.Size = New System.Drawing.Size(90, 16)
        Me.lblTelNo.TabIndex = 4
        Me.lblTelNo.Text = "Tel No."
        '
        'txtTelNo
        '
        Me.txtTelNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTelNo.Location = New System.Drawing.Point(745, 20)
        Me.txtTelNo.Name = "txtTelNo"
        Me.txtTelNo.Size = New System.Drawing.Size(200, 20)
        Me.txtTelNo.TabIndex = 5
        '
        'grpLGUProfile
        '
        Me.grpLGUProfile.Controls.Add(Me.txtLGUName)
        Me.grpLGUProfile.Controls.Add(Me.txtRemarks)
        Me.grpLGUProfile.Controls.Add(Me.lblRemarks)
        Me.grpLGUProfile.Controls.Add(Me.lblLGUName)
        Me.grpLGUProfile.Controls.Add(Me.lblLGUCode)
        Me.grpLGUProfile.Controls.Add(Me.lblLGUDescription)
        Me.grpLGUProfile.Controls.Add(Me.txtLGUCode)
        Me.grpLGUProfile.Controls.Add(Me.txtLGUDescription)
        Me.grpLGUProfile.Controls.Add(Me.btnLogo)
        Me.grpLGUProfile.Controls.Add(Me.txtFileName)
        Me.grpLGUProfile.Controls.Add(Me.lblLGULogo)
        Me.grpLGUProfile.Controls.Add(Me.lblZipCode)
        Me.grpLGUProfile.Controls.Add(Me.txtLGUAddress)
        Me.grpLGUProfile.Controls.Add(Me.cboZipCodeId)
        Me.grpLGUProfile.Controls.Add(Me.lblLGUAddress)
        Me.grpLGUProfile.Controls.Add(Me.cboZipCodeArea)
        Me.grpLGUProfile.Controls.Add(Me.cboRcode)
        Me.grpLGUProfile.Controls.Add(Me.cboRegion)
        Me.grpLGUProfile.Controls.Add(Me.lblZipCodeArea)
        Me.grpLGUProfile.Controls.Add(Me.cboPcode)
        Me.grpLGUProfile.Controls.Add(Me.lblRegion)
        Me.grpLGUProfile.Controls.Add(Me.cboMcode)
        Me.grpLGUProfile.Controls.Add(Me.lblBarangay)
        Me.grpLGUProfile.Controls.Add(Me.cboRurcode)
        Me.grpLGUProfile.Controls.Add(Me.lblMunicipality)
        Me.grpLGUProfile.Controls.Add(Me.lblProvince)
        Me.grpLGUProfile.Controls.Add(Me.cboMunicipality)
        Me.grpLGUProfile.Controls.Add(Me.cboProvince)
        Me.grpLGUProfile.Controls.Add(Me.cboBarangay)
        Me.grpLGUProfile.Controls.Add(Me.cboZipCode)
        Me.grpLGUProfile.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLGUProfile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpLGUProfile.Location = New System.Drawing.Point(10, 50)
        Me.grpLGUProfile.Name = "grpLGUProfile"
        Me.grpLGUProfile.Size = New System.Drawing.Size(955, 300)
        Me.grpLGUProfile.TabIndex = 0
        Me.grpLGUProfile.TabStop = False
        Me.grpLGUProfile.Text = "Profile"
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(105, 230)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(840, 50)
        Me.txtRemarks.TabIndex = 29
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(15, 230)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(90, 16)
        Me.lblRemarks.TabIndex = 28
        Me.lblRemarks.Text = "Remarks"
        '
        'grpContactDetails
        '
        Me.grpContactDetails.Controls.Add(Me.lblFirstName)
        Me.grpContactDetails.Controls.Add(Me.txtTelNo)
        Me.grpContactDetails.Controls.Add(Me.lblFaxNo)
        Me.grpContactDetails.Controls.Add(Me.lblTelNo)
        Me.grpContactDetails.Controls.Add(Me.txtFaxNo)
        Me.grpContactDetails.Controls.Add(Me.lblEmailAddress)
        Me.grpContactDetails.Controls.Add(Me.txtEmailAddress)
        Me.grpContactDetails.Controls.Add(Me.txtFirstName)
        Me.grpContactDetails.Controls.Add(Me.lblWebsite)
        Me.grpContactDetails.Controls.Add(Me.lblLastName)
        Me.grpContactDetails.Controls.Add(Me.txtWebsite)
        Me.grpContactDetails.Controls.Add(Me.txtLastName)
        Me.grpContactDetails.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpContactDetails.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpContactDetails.Location = New System.Drawing.Point(10, 360)
        Me.grpContactDetails.Name = "grpContactDetails"
        Me.grpContactDetails.Size = New System.Drawing.Size(952, 90)
        Me.grpContactDetails.TabIndex = 1
        Me.grpContactDetails.TabStop = False
        Me.grpContactDetails.Text = "Contact Details"
        '
        'frmLGU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 457)
        Me.Controls.Add(Me.grpLGUProfile)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.grpContactDetails)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmLGU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Local Government Unit"
        Me.cmenuLogo.ResumeLayout(False)
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.grpLGUProfile.ResumeLayout(False)
        Me.grpLGUProfile.PerformLayout()
        Me.grpContactDetails.ResumeLayout(False)
        Me.grpContactDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmenuLogo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtLGUDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtLGUCode As System.Windows.Forms.TextBox
    Friend WithEvents lblLGUDescription As System.Windows.Forms.Label
    Friend WithEvents lblLGUCode As System.Windows.Forms.Label
    Friend WithEvents lblLGUName As System.Windows.Forms.Label
    Friend WithEvents txtLGUName As System.Windows.Forms.TextBox
    Friend WithEvents lblLGULogo As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnLogo As System.Windows.Forms.Button
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents cboZipCodeId As System.Windows.Forms.ComboBox
    Friend WithEvents cboZipCodeArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents lblZipCodeArea As System.Windows.Forms.Label
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblBarangay As System.Windows.Forms.Label
    Friend WithEvents lblMunicipality As System.Windows.Forms.Label
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents cboRurcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboMcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboPcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboBarangay As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents lblLGUAddress As System.Windows.Forms.Label
    Friend WithEvents txtLGUAddress As System.Windows.Forms.TextBox
    Friend WithEvents cboZipCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblFaxNo As System.Windows.Forms.Label
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents lblTelNo As System.Windows.Forms.Label
    Friend WithEvents txtTelNo As System.Windows.Forms.TextBox
    Friend WithEvents grpLGUProfile As System.Windows.Forms.GroupBox
    Friend WithEvents grpContactDetails As System.Windows.Forms.GroupBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
