<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBank))
        Me.txtBankName = New System.Windows.Forms.TextBox
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblBankName = New System.Windows.Forms.Label
        Me.lblBankCode = New System.Windows.Forms.Label
        Me.lblBankDescription = New System.Windows.Forms.Label
        Me.txtBankCode = New System.Windows.Forms.TextBox
        Me.txtBankDescription = New System.Windows.Forms.TextBox
        Me.btnLogo = New System.Windows.Forms.Button
        Me.cmenuLogo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuClear = New System.Windows.Forms.ToolStripMenuItem
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblBankLogo = New System.Windows.Forms.Label
        Me.lblZipCode = New System.Windows.Forms.Label
        Me.txtBankAddress = New System.Windows.Forms.TextBox
        Me.cboZipCodeId = New System.Windows.Forms.ComboBox
        Me.lblBankAddress = New System.Windows.Forms.Label
        Me.cboZipCodeArea = New System.Windows.Forms.ComboBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.lblFaxNo = New System.Windows.Forms.Label
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.txtFaxNo = New System.Windows.Forms.TextBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.lblZipCodeArea = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.cboPcode = New System.Windows.Forms.ComboBox
        Me.txtTelNo = New System.Windows.Forms.TextBox
        Me.lblTelNo = New System.Windows.Forms.Label
        Me.lblEmailAddress = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.lblWebsite = New System.Windows.Forms.Label
        Me.lblLastName = New System.Windows.Forms.Label
        Me.txtWebsite = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.grpBankProfile = New System.Windows.Forms.GroupBox
        Me.lblRegion = New System.Windows.Forms.Label
        Me.cboMcode = New System.Windows.Forms.ComboBox
        Me.lblBarangay = New System.Windows.Forms.Label
        Me.cboRurcode = New System.Windows.Forms.ComboBox
        Me.lblMunicipality = New System.Windows.Forms.Label
        Me.lblProvince = New System.Windows.Forms.Label
        Me.cboMunicipality = New System.Windows.Forms.ComboBox
        Me.cboProvince = New System.Windows.Forms.ComboBox
        Me.cboBarangay = New System.Windows.Forms.ComboBox
        Me.cboZipCode = New System.Windows.Forms.ComboBox
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.grpContactDetails = New System.Windows.Forms.GroupBox
        Me.cmenuLogo.SuspendLayout()
        Me.grpBankProfile.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.grpContactDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBankName
        '
        Me.txtBankName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankName.Location = New System.Drawing.Point(105, 20)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(510, 20)
        Me.txtBankName.TabIndex = 1
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(105, 260)
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
        Me.lblRemarks.Location = New System.Drawing.Point(15, 260)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(90, 16)
        Me.lblRemarks.TabIndex = 28
        Me.lblRemarks.Text = "Remarks"
        '
        'lblBankName
        '
        Me.lblBankName.BackColor = System.Drawing.SystemColors.Control
        Me.lblBankName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBankName.Location = New System.Drawing.Point(15, 20)
        Me.lblBankName.Name = "lblBankName"
        Me.lblBankName.Size = New System.Drawing.Size(90, 16)
        Me.lblBankName.TabIndex = 0
        Me.lblBankName.Text = "Name"
        '
        'lblBankCode
        '
        Me.lblBankCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBankCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBankCode.Location = New System.Drawing.Point(15, 50)
        Me.lblBankCode.Name = "lblBankCode"
        Me.lblBankCode.Size = New System.Drawing.Size(90, 16)
        Me.lblBankCode.TabIndex = 2
        Me.lblBankCode.Text = "Code"
        '
        'lblBankDescription
        '
        Me.lblBankDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblBankDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBankDescription.Location = New System.Drawing.Point(15, 80)
        Me.lblBankDescription.Name = "lblBankDescription"
        Me.lblBankDescription.Size = New System.Drawing.Size(90, 16)
        Me.lblBankDescription.TabIndex = 7
        Me.lblBankDescription.Text = "Description"
        '
        'txtBankCode
        '
        Me.txtBankCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBankCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankCode.Location = New System.Drawing.Point(105, 50)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(510, 20)
        Me.txtBankCode.TabIndex = 3
        '
        'txtBankDescription
        '
        Me.txtBankDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankDescription.Location = New System.Drawing.Point(105, 80)
        Me.txtBankDescription.Multiline = True
        Me.txtBankDescription.Name = "txtBankDescription"
        Me.txtBankDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBankDescription.Size = New System.Drawing.Size(510, 50)
        Me.txtBankDescription.TabIndex = 8
        '
        'btnLogo
        '
        Me.btnLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLogo.ContextMenuStrip = Me.cmenuLogo
        Me.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLogo.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnLogo.Location = New System.Drawing.Point(745, 20)
        Me.btnLogo.Name = "btnLogo"
        Me.btnLogo.Size = New System.Drawing.Size(200, 170)
        Me.btnLogo.TabIndex = 5
        Me.btnLogo.UseVisualStyleBackColor = True
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
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(720, 170)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(20, 20)
        Me.txtFileName.TabIndex = 6
        Me.txtFileName.TabStop = False
        Me.txtFileName.Visible = False
        '
        'lblBankLogo
        '
        Me.lblBankLogo.BackColor = System.Drawing.SystemColors.Control
        Me.lblBankLogo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankLogo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBankLogo.Location = New System.Drawing.Point(655, 20)
        Me.lblBankLogo.Name = "lblBankLogo"
        Me.lblBankLogo.Size = New System.Drawing.Size(90, 16)
        Me.lblBankLogo.TabIndex = 4
        Me.lblBankLogo.Text = "Logo"
        '
        'lblZipCode
        '
        Me.lblZipCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZipCode.Location = New System.Drawing.Point(655, 225)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(90, 16)
        Me.lblZipCode.TabIndex = 26
        Me.lblZipCode.Text = "Zip Code Number"
        '
        'txtBankAddress
        '
        Me.txtBankAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBankAddress.Location = New System.Drawing.Point(105, 140)
        Me.txtBankAddress.Multiline = True
        Me.txtBankAddress.Name = "txtBankAddress"
        Me.txtBankAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBankAddress.Size = New System.Drawing.Size(510, 50)
        Me.txtBankAddress.TabIndex = 10
        '
        'cboZipCodeId
        '
        Me.cboZipCodeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCodeId.FormattingEnabled = True
        Me.cboZipCodeId.Location = New System.Drawing.Point(595, 230)
        Me.cboZipCodeId.Name = "cboZipCodeId"
        Me.cboZipCodeId.Size = New System.Drawing.Size(20, 22)
        Me.cboZipCodeId.TabIndex = 25
        Me.cboZipCodeId.TabStop = False
        Me.cboZipCodeId.Visible = False
        '
        'lblBankAddress
        '
        Me.lblBankAddress.BackColor = System.Drawing.SystemColors.Control
        Me.lblBankAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBankAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBankAddress.Location = New System.Drawing.Point(15, 140)
        Me.lblBankAddress.Name = "lblBankAddress"
        Me.lblBankAddress.Size = New System.Drawing.Size(90, 16)
        Me.lblBankAddress.TabIndex = 9
        Me.lblBankAddress.Text = "Address"
        '
        'cboZipCodeArea
        '
        Me.cboZipCodeArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCodeArea.DropDownWidth = 250
        Me.cboZipCodeArea.FormattingEnabled = True
        Me.cboZipCodeArea.Location = New System.Drawing.Point(415, 230)
        Me.cboZipCodeArea.Name = "cboZipCodeArea"
        Me.cboZipCodeArea.Size = New System.Drawing.Size(200, 22)
        Me.cboZipCodeArea.TabIndex = 24
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
        'cboRcode
        '
        Me.cboRcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRcode.FormattingEnabled = True
        Me.cboRcode.Location = New System.Drawing.Point(285, 200)
        Me.cboRcode.Name = "cboRcode"
        Me.cboRcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRcode.TabIndex = 13
        Me.cboRcode.TabStop = False
        Me.cboRcode.Visible = False
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
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.DropDownWidth = 250
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(105, 200)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(200, 22)
        Me.cboRegion.TabIndex = 12
        '
        'lblZipCodeArea
        '
        Me.lblZipCodeArea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZipCodeArea.Location = New System.Drawing.Point(325, 230)
        Me.lblZipCodeArea.Name = "lblZipCodeArea"
        Me.lblZipCodeArea.Size = New System.Drawing.Size(90, 16)
        Me.lblZipCodeArea.TabIndex = 23
        Me.lblZipCodeArea.Text = "Zip Code Area"
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
        'cboPcode
        '
        Me.cboPcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPcode.FormattingEnabled = True
        Me.cboPcode.Location = New System.Drawing.Point(595, 200)
        Me.cboPcode.Name = "cboPcode"
        Me.cboPcode.Size = New System.Drawing.Size(20, 22)
        Me.cboPcode.TabIndex = 16
        Me.cboPcode.TabStop = False
        Me.cboPcode.Visible = False
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
        'txtEmailAddress
        '
        Me.txtEmailAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtEmailAddress.Location = New System.Drawing.Point(415, 50)
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(200, 20)
        Me.txtEmailAddress.TabIndex = 9
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
        'txtWebsite
        '
        Me.txtWebsite.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWebsite.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtWebsite.Location = New System.Drawing.Point(745, 50)
        Me.txtWebsite.Name = "txtWebsite"
        Me.txtWebsite.Size = New System.Drawing.Size(200, 20)
        Me.txtWebsite.TabIndex = 11
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
        'grpBankProfile
        '
        Me.grpBankProfile.Controls.Add(Me.txtBankName)
        Me.grpBankProfile.Controls.Add(Me.txtRemarks)
        Me.grpBankProfile.Controls.Add(Me.lblRemarks)
        Me.grpBankProfile.Controls.Add(Me.lblBankName)
        Me.grpBankProfile.Controls.Add(Me.lblBankCode)
        Me.grpBankProfile.Controls.Add(Me.lblBankDescription)
        Me.grpBankProfile.Controls.Add(Me.txtBankCode)
        Me.grpBankProfile.Controls.Add(Me.txtBankDescription)
        Me.grpBankProfile.Controls.Add(Me.btnLogo)
        Me.grpBankProfile.Controls.Add(Me.txtFileName)
        Me.grpBankProfile.Controls.Add(Me.lblBankLogo)
        Me.grpBankProfile.Controls.Add(Me.lblZipCode)
        Me.grpBankProfile.Controls.Add(Me.txtBankAddress)
        Me.grpBankProfile.Controls.Add(Me.cboZipCodeId)
        Me.grpBankProfile.Controls.Add(Me.lblBankAddress)
        Me.grpBankProfile.Controls.Add(Me.cboZipCodeArea)
        Me.grpBankProfile.Controls.Add(Me.cboRcode)
        Me.grpBankProfile.Controls.Add(Me.cboRegion)
        Me.grpBankProfile.Controls.Add(Me.lblZipCodeArea)
        Me.grpBankProfile.Controls.Add(Me.cboPcode)
        Me.grpBankProfile.Controls.Add(Me.lblRegion)
        Me.grpBankProfile.Controls.Add(Me.cboMcode)
        Me.grpBankProfile.Controls.Add(Me.lblBarangay)
        Me.grpBankProfile.Controls.Add(Me.cboRurcode)
        Me.grpBankProfile.Controls.Add(Me.lblMunicipality)
        Me.grpBankProfile.Controls.Add(Me.lblProvince)
        Me.grpBankProfile.Controls.Add(Me.cboMunicipality)
        Me.grpBankProfile.Controls.Add(Me.cboProvince)
        Me.grpBankProfile.Controls.Add(Me.cboBarangay)
        Me.grpBankProfile.Controls.Add(Me.cboZipCode)
        Me.grpBankProfile.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBankProfile.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpBankProfile.Location = New System.Drawing.Point(10, 50)
        Me.grpBankProfile.Name = "grpBankProfile"
        Me.grpBankProfile.Size = New System.Drawing.Size(955, 330)
        Me.grpBankProfile.TabIndex = 17
        Me.grpBankProfile.TabStop = False
        Me.grpBankProfile.Text = "Profile"
        '
        'lblRegion
        '
        Me.lblRegion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegion.Location = New System.Drawing.Point(15, 200)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(90, 16)
        Me.lblRegion.TabIndex = 11
        Me.lblRegion.Text = "Region"
        '
        'cboMcode
        '
        Me.cboMcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMcode.FormattingEnabled = True
        Me.cboMcode.Location = New System.Drawing.Point(925, 195)
        Me.cboMcode.Name = "cboMcode"
        Me.cboMcode.Size = New System.Drawing.Size(20, 22)
        Me.cboMcode.TabIndex = 19
        Me.cboMcode.TabStop = False
        Me.cboMcode.Visible = False
        '
        'lblBarangay
        '
        Me.lblBarangay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangay.Location = New System.Drawing.Point(15, 230)
        Me.lblBarangay.Name = "lblBarangay"
        Me.lblBarangay.Size = New System.Drawing.Size(90, 16)
        Me.lblBarangay.TabIndex = 20
        Me.lblBarangay.Text = "Barangay"
        '
        'cboRurcode
        '
        Me.cboRurcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRurcode.FormattingEnabled = True
        Me.cboRurcode.Location = New System.Drawing.Point(285, 230)
        Me.cboRurcode.Name = "cboRurcode"
        Me.cboRurcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRurcode.TabIndex = 22
        Me.cboRurcode.TabStop = False
        Me.cboRurcode.Visible = False
        '
        'lblMunicipality
        '
        Me.lblMunicipality.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipality.Location = New System.Drawing.Point(655, 200)
        Me.lblMunicipality.Name = "lblMunicipality"
        Me.lblMunicipality.Size = New System.Drawing.Size(90, 16)
        Me.lblMunicipality.TabIndex = 17
        Me.lblMunicipality.Text = "City / Municipality"
        '
        'lblProvince
        '
        Me.lblProvince.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvince.Location = New System.Drawing.Point(325, 200)
        Me.lblProvince.Name = "lblProvince"
        Me.lblProvince.Size = New System.Drawing.Size(90, 16)
        Me.lblProvince.TabIndex = 14
        Me.lblProvince.Text = "Province"
        '
        'cboMunicipality
        '
        Me.cboMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipality.DropDownWidth = 250
        Me.cboMunicipality.FormattingEnabled = True
        Me.cboMunicipality.Location = New System.Drawing.Point(745, 195)
        Me.cboMunicipality.Name = "cboMunicipality"
        Me.cboMunicipality.Size = New System.Drawing.Size(200, 22)
        Me.cboMunicipality.TabIndex = 18
        '
        'cboProvince
        '
        Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvince.DropDownWidth = 250
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(415, 200)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(200, 22)
        Me.cboProvince.TabIndex = 15
        '
        'cboBarangay
        '
        Me.cboBarangay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBarangay.DropDownWidth = 250
        Me.cboBarangay.FormattingEnabled = True
        Me.cboBarangay.Location = New System.Drawing.Point(105, 230)
        Me.cboBarangay.Name = "cboBarangay"
        Me.cboBarangay.Size = New System.Drawing.Size(200, 22)
        Me.cboBarangay.TabIndex = 21
        '
        'cboZipCode
        '
        Me.cboZipCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCode.DropDownWidth = 250
        Me.cboZipCode.Enabled = False
        Me.cboZipCode.FormattingEnabled = True
        Me.cboZipCode.Location = New System.Drawing.Point(745, 225)
        Me.cboZipCode.Name = "cboZipCode"
        Me.cboZipCode.Size = New System.Drawing.Size(200, 22)
        Me.cboZipCode.TabIndex = 27
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
        'btnEdit
        '
        Me.btnEdit.ImageIndex = 1
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "Edit "
        Me.btnEdit.ToolTipText = "Edit record"
        '
        'btnAdd
        '
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Add"
        Me.btnAdd.ToolTipText = "Add new record"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(974, 40)
        Me.pnlToolbar.TabIndex = 19
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
        Me.grpContactDetails.Location = New System.Drawing.Point(10, 390)
        Me.grpContactDetails.Name = "grpContactDetails"
        Me.grpContactDetails.Size = New System.Drawing.Size(952, 90)
        Me.grpContactDetails.TabIndex = 18
        Me.grpContactDetails.TabStop = False
        Me.grpContactDetails.Text = "Contact Details"
        '
        'frmBank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 487)
        Me.Controls.Add(Me.grpBankProfile)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.grpContactDetails)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(980, 515)
        Me.MinimumSize = New System.Drawing.Size(980, 515)
        Me.Name = "frmBank"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank"
        Me.cmenuLogo.ResumeLayout(False)
        Me.grpBankProfile.ResumeLayout(False)
        Me.grpBankProfile.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.grpContactDetails.ResumeLayout(False)
        Me.grpContactDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblBankName As System.Windows.Forms.Label
    Friend WithEvents lblBankCode As System.Windows.Forms.Label
    Friend WithEvents lblBankDescription As System.Windows.Forms.Label
    Friend WithEvents txtBankCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBankDescription As System.Windows.Forms.TextBox
    Friend WithEvents btnLogo As System.Windows.Forms.Button
    Friend WithEvents cmenuLogo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblBankLogo As System.Windows.Forms.Label
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents txtBankAddress As System.Windows.Forms.TextBox
    Friend WithEvents cboZipCodeId As System.Windows.Forms.ComboBox
    Friend WithEvents lblBankAddress As System.Windows.Forms.Label
    Friend WithEvents cboZipCodeArea As System.Windows.Forms.ComboBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblFaxNo As System.Windows.Forms.Label
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents txtFaxNo As System.Windows.Forms.TextBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents lblZipCodeArea As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents cboPcode As System.Windows.Forms.ComboBox
    Friend WithEvents txtTelNo As System.Windows.Forms.TextBox
    Friend WithEvents lblTelNo As System.Windows.Forms.Label
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtWebsite As System.Windows.Forms.TextBox
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents grpBankProfile As System.Windows.Forms.GroupBox
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents cboMcode As System.Windows.Forms.ComboBox
    Friend WithEvents lblBarangay As System.Windows.Forms.Label
    Friend WithEvents cboRurcode As System.Windows.Forms.ComboBox
    Friend WithEvents lblMunicipality As System.Windows.Forms.Label
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents cboMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents cboBarangay As System.Windows.Forms.ComboBox
    Friend WithEvents cboZipCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents grpContactDetails As System.Windows.Forms.GroupBox
End Class
