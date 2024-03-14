<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMember
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMember))
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.lblStatus = New System.Windows.Forms.Label
        Me.lblMemberPhoto = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.btnPicture = New System.Windows.Forms.Button
        Me.cmenuPhoto = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuClear = New System.Windows.Forms.ToolStripMenuItem
        Me.cmnuCapture = New System.Windows.Forms.ToolStripMenuItem
        Me.cboJobTitle = New System.Windows.Forms.ComboBox
        Me.lblBirthDate = New System.Windows.Forms.Label
        Me.cboGender = New System.Windows.Forms.ComboBox
        Me.lblGender = New System.Windows.Forms.Label
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.txtMiddleName = New System.Windows.Forms.TextBox
        Me.lblLastName = New System.Windows.Forms.Label
        Me.lblMiddleName = New System.Windows.Forms.Label
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.lblJobTitle = New System.Windows.Forms.Label
        Me.dtpBirthDate = New System.Windows.Forms.DateTimePicker
        Me.lblActive = New System.Windows.Forms.Label
        Me.chkActive = New System.Windows.Forms.CheckBox
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.lblLGUName = New System.Windows.Forms.Label
        Me.lblDepartmentName = New System.Windows.Forms.Label
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.cboJobId = New System.Windows.Forms.ComboBox
        Me.dtpDateHired = New System.Windows.Forms.DateTimePicker
        Me.lblDateHired = New System.Windows.Forms.Label
        Me.tclMember = New System.Windows.Forms.TabControl
        Me.tpgMemberInformation = New System.Windows.Forms.TabPage
        Me.txtEmployeeId = New System.Windows.Forms.TextBox
        Me.lblEmployeeId = New System.Windows.Forms.Label
        Me.lblMember = New System.Windows.Forms.Label
        Me.chkMember = New System.Windows.Forms.CheckBox
        Me.dtpMembershipDate = New System.Windows.Forms.DateTimePicker
        Me.lblCGMEADateMembered = New System.Windows.Forms.Label
        Me.dtpOathDt = New System.Windows.Forms.DateTimePicker
        Me.lblOathDt = New System.Windows.Forms.Label
        Me.dtpAppointmentDt = New System.Windows.Forms.DateTimePicker
        Me.lblAppointmentDt = New System.Windows.Forms.Label
        Me.chkRetireFl = New System.Windows.Forms.CheckBox
        Me.chkReplaceFl = New System.Windows.Forms.CheckBox
        Me.chkReassignFl = New System.Windows.Forms.CheckBox
        Me.txtSalary = New System.Windows.Forms.TextBox
        Me.lblSalaryAmount = New System.Windows.Forms.Label
        Me.cboQualificationId = New System.Windows.Forms.ComboBox
        Me.cboQualification = New System.Windows.Forms.ComboBox
        Me.lblQualification = New System.Windows.Forms.Label
        Me.cboAppointmentId = New System.Windows.Forms.ComboBox
        Me.txtReferredByID = New System.Windows.Forms.TextBox
        Me.txtReferredBy = New System.Windows.Forms.TextBox
        Me.cboStatusAppointment = New System.Windows.Forms.ComboBox
        Me.lblStatusofAppointment = New System.Windows.Forms.Label
        Me.lblBirthPlace = New System.Windows.Forms.Label
        Me.lblAge = New System.Windows.Forms.Label
        Me.txtLGUId = New System.Windows.Forms.TextBox
        Me.txtLGUName = New System.Windows.Forms.TextBox
        Me.lblSuffixName = New System.Windows.Forms.Label
        Me.txtSuffixName = New System.Windows.Forms.TextBox
        Me.txtDepartmentId = New System.Windows.Forms.TextBox
        Me.txtDepartmentName = New System.Windows.Forms.TextBox
        Me.txtBloodType = New System.Windows.Forms.TextBox
        Me.lblPagibigIDNo = New System.Windows.Forms.Label
        Me.txtPagibigIDNo = New System.Windows.Forms.TextBox
        Me.lblBloodType = New System.Windows.Forms.Label
        Me.lblPhilHealthNo = New System.Windows.Forms.Label
        Me.txtCitizenship = New System.Windows.Forms.TextBox
        Me.lblHeight = New System.Windows.Forms.Label
        Me.txtHeight = New System.Windows.Forms.TextBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.lblCitizenship = New System.Windows.Forms.Label
        Me.lblWeight = New System.Windows.Forms.Label
        Me.lblZipCode = New System.Windows.Forms.Label
        Me.cboZipCodeId = New System.Windows.Forms.ComboBox
        Me.txtBirthPlace = New System.Windows.Forms.TextBox
        Me.cboZipCodeArea = New System.Windows.Forms.ComboBox
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.lblBarangay = New System.Windows.Forms.Label
        Me.lblProvince = New System.Windows.Forms.Label
        Me.cboRurcode = New System.Windows.Forms.ComboBox
        Me.cboMcode = New System.Windows.Forms.ComboBox
        Me.cboPcode = New System.Windows.Forms.ComboBox
        Me.cboBarangay = New System.Windows.Forms.ComboBox
        Me.cboMunicipality = New System.Windows.Forms.ComboBox
        Me.cboProvince = New System.Windows.Forms.ComboBox
        Me.txtHomeAddress = New System.Windows.Forms.TextBox
        Me.lblWorkTel = New System.Windows.Forms.Label
        Me.txtWorkTel = New System.Windows.Forms.TextBox
        Me.lblTINo = New System.Windows.Forms.Label
        Me.txtEmailAddress = New System.Windows.Forms.TextBox
        Me.lblEmailAddress = New System.Windows.Forms.Label
        Me.txtMobileNo = New System.Windows.Forms.TextBox
        Me.txtHomeTel = New System.Windows.Forms.TextBox
        Me.cboZipCode = New System.Windows.Forms.ComboBox
        Me.lblZipCodeArea = New System.Windows.Forms.Label
        Me.lblRegion = New System.Windows.Forms.Label
        Me.lblMunicipality = New System.Windows.Forms.Label
        Me.lblHomeAddress = New System.Windows.Forms.Label
        Me.lblSSSNo = New System.Windows.Forms.Label
        Me.lblMobileNo = New System.Windows.Forms.Label
        Me.lblHomeTel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.mtxtPhilHealthNo = New System.Windows.Forms.MaskedTextBox
        Me.mtxtTINo = New System.Windows.Forms.MaskedTextBox
        Me.mtxtSSSNo = New System.Windows.Forms.MaskedTextBox
        Me.lblReferredBy = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.tpgEducationalBackground = New System.Windows.Forms.TabPage
        Me.btnEducationalEdit = New System.Windows.Forms.Button
        Me.dtpEducationalToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpEducationalFromDate = New System.Windows.Forms.DateTimePicker
        Me.btnEducationalDelete = New System.Windows.Forms.Button
        Me.btnEducationalClear = New System.Windows.Forms.Button
        Me.btnEducationalAdd = New System.Windows.Forms.Button
        Me.txtHonors = New System.Windows.Forms.TextBox
        Me.lblHonors = New System.Windows.Forms.Label
        Me.lblEducationalToDate = New System.Windows.Forms.Label
        Me.lblEducationalFromDate = New System.Windows.Forms.Label
        Me.txtHighestGrade = New System.Windows.Forms.TextBox
        Me.lblHighestGrade = New System.Windows.Forms.Label
        Me.txtDegreeCourse = New System.Windows.Forms.TextBox
        Me.lblDegreeCourse = New System.Windows.Forms.Label
        Me.txtNameofSchool = New System.Windows.Forms.TextBox
        Me.lblNameofSchool = New System.Windows.Forms.Label
        Me.cboEducationalLevel = New System.Windows.Forms.ComboBox
        Me.lblLevel = New System.Windows.Forms.Label
        Me.lvwEducationalBackground = New System.Windows.Forms.ListView
        Me.chrLevel = New System.Windows.Forms.ColumnHeader
        Me.chrSchool = New System.Windows.Forms.ColumnHeader
        Me.chrDegreeCourse = New System.Windows.Forms.ColumnHeader
        Me.chrHighestGrade = New System.Windows.Forms.ColumnHeader
        Me.chrFromDate = New System.Windows.Forms.ColumnHeader
        Me.chrToDate = New System.Windows.Forms.ColumnHeader
        Me.chrHonors = New System.Windows.Forms.ColumnHeader
        Me.tpgEmploymentHistory = New System.Windows.Forms.TabPage
        Me.txtEmploymentTaskAccomplishment = New System.Windows.Forms.TextBox
        Me.lblEmploymentTaskAccomplishment = New System.Windows.Forms.Label
        Me.txtEmploymentCompanyAddress = New System.Windows.Forms.TextBox
        Me.lblEmploymentCompanyAddress = New System.Windows.Forms.Label
        Me.txtMonthlySalary = New System.Windows.Forms.TextBox
        Me.lblMonthlySalary = New System.Windows.Forms.Label
        Me.txtEmploymentContactNo = New System.Windows.Forms.TextBox
        Me.lblEmploymentContactNo = New System.Windows.Forms.Label
        Me.txtEmploymentCompanyName = New System.Windows.Forms.TextBox
        Me.lblEmploymentCompanyName = New System.Windows.Forms.Label
        Me.txtEmploymentPosition = New System.Windows.Forms.TextBox
        Me.lblEmploymentPosition = New System.Windows.Forms.Label
        Me.dtpEmploymentToDate = New System.Windows.Forms.DateTimePicker
        Me.dtpEmploymentFromDate = New System.Windows.Forms.DateTimePicker
        Me.lblEmploymentToDate = New System.Windows.Forms.Label
        Me.lblEmploymentFromDate = New System.Windows.Forms.Label
        Me.btnEmploymentEdit = New System.Windows.Forms.Button
        Me.btnEmploymentDelete = New System.Windows.Forms.Button
        Me.btnEmploymentClear = New System.Windows.Forms.Button
        Me.btnEmploymentAdd = New System.Windows.Forms.Button
        Me.lvwEmploymentHistory = New System.Windows.Forms.ListView
        Me.chrWorkFromDate = New System.Windows.Forms.ColumnHeader
        Me.chrWorkToDate = New System.Windows.Forms.ColumnHeader
        Me.chrPosition = New System.Windows.Forms.ColumnHeader
        Me.chrCompany = New System.Windows.Forms.ColumnHeader
        Me.chrCompanyAddress = New System.Windows.Forms.ColumnHeader
        Me.chrCompanyContactNo = New System.Windows.Forms.ColumnHeader
        Me.chrSalary = New System.Windows.Forms.ColumnHeader
        Me.chrTaskAccomplishment = New System.Windows.Forms.ColumnHeader
        Me.tpgOrganization = New System.Windows.Forms.TabPage
        Me.txtOrganizationAddress = New System.Windows.Forms.TextBox
        Me.lblOrganizationAddress = New System.Windows.Forms.Label
        Me.txtOrganizationPosition = New System.Windows.Forms.TextBox
        Me.lblOrganizationPosition = New System.Windows.Forms.Label
        Me.txtOrganizationName = New System.Windows.Forms.TextBox
        Me.lblOrganizationName = New System.Windows.Forms.Label
        Me.dtpOrganizationSinceDt = New System.Windows.Forms.DateTimePicker
        Me.lblOrganizationSinceDt = New System.Windows.Forms.Label
        Me.btnOrganizationEdit = New System.Windows.Forms.Button
        Me.btnOrganizationDelete = New System.Windows.Forms.Button
        Me.btnOrganizationClear = New System.Windows.Forms.Button
        Me.btnOrganizationAdd = New System.Windows.Forms.Button
        Me.lvwOrganization = New System.Windows.Forms.ListView
        Me.chrOrganizationName = New System.Windows.Forms.ColumnHeader
        Me.chrOrganizationAddress = New System.Windows.Forms.ColumnHeader
        Me.chrOrganizationPosition = New System.Windows.Forms.ColumnHeader
        Me.chrOrganizationSinceDt = New System.Windows.Forms.ColumnHeader
        Me.tpgSeminarsAttended = New System.Windows.Forms.TabPage
        Me.txtSeminarRemarks = New System.Windows.Forms.TextBox
        Me.lblSeminarRemarks = New System.Windows.Forms.Label
        Me.txtSeminarLocation = New System.Windows.Forms.TextBox
        Me.lblSeminarLocation = New System.Windows.Forms.Label
        Me.txtSeminarName = New System.Windows.Forms.TextBox
        Me.lblSeminarName = New System.Windows.Forms.Label
        Me.dtpSeminarDate = New System.Windows.Forms.DateTimePicker
        Me.lblSeminarDate = New System.Windows.Forms.Label
        Me.btnSeminarEdit = New System.Windows.Forms.Button
        Me.btnSeminarDelete = New System.Windows.Forms.Button
        Me.btnSeminarClear = New System.Windows.Forms.Button
        Me.btnSeminarAdd = New System.Windows.Forms.Button
        Me.lvwSeminarsAttended = New System.Windows.Forms.ListView
        Me.chrSeminarName = New System.Windows.Forms.ColumnHeader
        Me.chrSeminarLocation = New System.Windows.Forms.ColumnHeader
        Me.chrSeminarDate = New System.Windows.Forms.ColumnHeader
        Me.chrSeminarRemarks = New System.Windows.Forms.ColumnHeader
        Me.tpgFamilyBackground = New System.Windows.Forms.TabPage
        Me.lvwFamilyBackground = New System.Windows.Forms.ListView
        Me.chrSpouseFName = New System.Windows.Forms.ColumnHeader
        Me.chrSpouseMName = New System.Windows.Forms.ColumnHeader
        Me.chrSpouseLName = New System.Windows.Forms.ColumnHeader
        Me.chrSpouseSuffix = New System.Windows.Forms.ColumnHeader
        Me.chrSpouseBirthdate = New System.Windows.Forms.ColumnHeader
        Me.chrFatherFName = New System.Windows.Forms.ColumnHeader
        Me.chrFatherMName = New System.Windows.Forms.ColumnHeader
        Me.chrFatherLName = New System.Windows.Forms.ColumnHeader
        Me.chrMotherFName = New System.Windows.Forms.ColumnHeader
        Me.chrMotherLName = New System.Windows.Forms.ColumnHeader
        Me.btnFamilyDelete = New System.Windows.Forms.Button
        Me.btnFamilyEdit = New System.Windows.Forms.Button
        Me.btnFamilyAdd = New System.Windows.Forms.Button
        Me.btnFamilyClear = New System.Windows.Forms.Button
        Me.lblMother = New System.Windows.Forms.Label
        Me.txtMotherLName = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtMotherMName = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtMotherFName = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblFatherName = New System.Windows.Forms.Label
        Me.txtFatherSuffix = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtFatherLName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtFatherMName = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtFatherFName = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblSpouseName = New System.Windows.Forms.Label
        Me.dtpSpouseBirth = New System.Windows.Forms.DateTimePicker
        Me.lblSpouseBirthdate = New System.Windows.Forms.Label
        Me.txtSpouseSuffix = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSpouseLName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSpouseMName = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSpouseFName = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.tpgChildren = New System.Windows.Forms.TabPage
        Me.cboChildStatus = New System.Windows.Forms.ComboBox
        Me.lblChildStatus = New System.Windows.Forms.Label
        Me.lvwChildren = New System.Windows.Forms.ListView
        Me.chrChildFName = New System.Windows.Forms.ColumnHeader
        Me.chrChildMName = New System.Windows.Forms.ColumnHeader
        Me.chrChildLName = New System.Windows.Forms.ColumnHeader
        Me.chrChildSuffix = New System.Windows.Forms.ColumnHeader
        Me.chrChildBirth = New System.Windows.Forms.ColumnHeader
        Me.chrChildAge = New System.Windows.Forms.ColumnHeader
        Me.chrChildStatus = New System.Windows.Forms.ColumnHeader
        Me.dtpChildBirth = New System.Windows.Forms.DateTimePicker
        Me.lblChildBirthDate = New System.Windows.Forms.Label
        Me.txtChildSuffix = New System.Windows.Forms.TextBox
        Me.lblChildSuffix = New System.Windows.Forms.Label
        Me.txtChildLName = New System.Windows.Forms.TextBox
        Me.lblChildLName = New System.Windows.Forms.Label
        Me.txtChildMName = New System.Windows.Forms.TextBox
        Me.lblChildMName = New System.Windows.Forms.Label
        Me.txtChildFName = New System.Windows.Forms.TextBox
        Me.lblChildFName = New System.Windows.Forms.Label
        Me.btnChildDelete = New System.Windows.Forms.Button
        Me.btnChildEdit = New System.Windows.Forms.Button
        Me.btnChildAdd = New System.Windows.Forms.Button
        Me.btnChildClear = New System.Windows.Forms.Button
        Me.tpgOtherBeneficiary = New System.Windows.Forms.TabPage
        Me.txtBeneficiarySuffix = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtBeneficiaryLName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtBeneficiaryMName = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtBeneficiaryRelation = New System.Windows.Forms.TextBox
        Me.lblMemberRelation = New System.Windows.Forms.Label
        Me.txtBeneficiaryFName = New System.Windows.Forms.TextBox
        Me.lblbeneficiaryName = New System.Windows.Forms.Label
        Me.btnBeneficiaryEdit = New System.Windows.Forms.Button
        Me.btnBeneficiaryDelete = New System.Windows.Forms.Button
        Me.btnBeneficiaryClear = New System.Windows.Forms.Button
        Me.btnBeneficiaryAdd = New System.Windows.Forms.Button
        Me.lvwOtherBeneficiary = New System.Windows.Forms.ListView
        Me.chrBeneficiaryFName = New System.Windows.Forms.ColumnHeader
        Me.chrBeneficiaryMName = New System.Windows.Forms.ColumnHeader
        Me.chrBeneficiaryLName = New System.Windows.Forms.ColumnHeader
        Me.chrBeneficiarySuffix = New System.Windows.Forms.ColumnHeader
        Me.chrBeneficiaryRelation = New System.Windows.Forms.ColumnHeader
        Me.cmsPreview = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PrintMemberProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmenuPhoto.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.tclMember.SuspendLayout()
        Me.tpgMemberInformation.SuspendLayout()
        Me.tpgEducationalBackground.SuspendLayout()
        Me.tpgEmploymentHistory.SuspendLayout()
        Me.tpgOrganization.SuspendLayout()
        Me.tpgSeminarsAttended.SuspendLayout()
        Me.tpgFamilyBackground.SuspendLayout()
        Me.tpgChildren.SuspendLayout()
        Me.tpgOtherBeneficiary.SuspendLayout()
        Me.cmsPreview.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.DropDownWidth = 250
        Me.cboStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.ItemHeight = 14
        Me.cboStatus.Items.AddRange(New Object() {"", "ANNULLED", "COHABITING", "DECEASED", "DIVORCED", "ENGAGED", "MARRIED", "SEPARATED", "SINGLE", "WIDOWED"})
        Me.cboStatus.Location = New System.Drawing.Point(750, 225)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(200, 22)
        Me.cboStatus.TabIndex = 44
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatus.Location = New System.Drawing.Point(650, 225)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(100, 16)
        Me.lblStatus.TabIndex = 43
        Me.lblStatus.Text = "Civil Status"
        '
        'lblMemberPhoto
        '
        Me.lblMemberPhoto.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberPhoto.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberPhoto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberPhoto.Location = New System.Drawing.Point(10, 75)
        Me.lblMemberPhoto.Name = "lblMemberPhoto"
        Me.lblMemberPhoto.Size = New System.Drawing.Size(100, 16)
        Me.lblMemberPhoto.TabIndex = 25
        Me.lblMemberPhoto.Text = "Member Photo"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(85, 255)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(20, 20)
        Me.txtFileName.TabIndex = 26
        Me.txtFileName.TabStop = False
        Me.txtFileName.Visible = False
        '
        'btnPicture
        '
        Me.btnPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPicture.ContextMenuStrip = Me.cmenuPhoto
        Me.btnPicture.FlatAppearance.BorderSize = 0
        Me.btnPicture.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPicture.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnPicture.Location = New System.Drawing.Point(110, 75)
        Me.btnPicture.Name = "btnPicture"
        Me.btnPicture.Size = New System.Drawing.Size(200, 200)
        Me.btnPicture.TabIndex = 27
        Me.btnPicture.TabStop = False
        Me.btnPicture.UseVisualStyleBackColor = True
        '
        'cmenuPhoto
        '
        Me.cmenuPhoto.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuClear, Me.cmnuCapture})
        Me.cmenuPhoto.Name = "cmenuPhoto"
        Me.cmenuPhoto.Size = New System.Drawing.Size(153, 48)
        '
        'cmnuClear
        '
        Me.cmnuClear.Name = "cmnuClear"
        Me.cmnuClear.Size = New System.Drawing.Size(152, 22)
        Me.cmnuClear.Text = "&Clear Photo"
        '
        'cmnuCapture
        '
        Me.cmnuCapture.Name = "cmnuCapture"
        Me.cmnuCapture.Size = New System.Drawing.Size(152, 22)
        Me.cmnuCapture.Text = "Capture &Image"
        '
        'cboJobTitle
        '
        Me.cboJobTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboJobTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJobTitle.DropDownWidth = 300
        Me.cboJobTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJobTitle.ItemHeight = 14
        Me.cboJobTitle.Location = New System.Drawing.Point(435, 45)
        Me.cboJobTitle.Name = "cboJobTitle"
        Me.cboJobTitle.Size = New System.Drawing.Size(200, 22)
        Me.cboJobTitle.TabIndex = 11
        '
        'lblBirthDate
        '
        Me.lblBirthDate.BackColor = System.Drawing.Color.Transparent
        Me.lblBirthDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBirthDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBirthDate.Location = New System.Drawing.Point(335, 195)
        Me.lblBirthDate.Name = "lblBirthDate"
        Me.lblBirthDate.Size = New System.Drawing.Size(100, 16)
        Me.lblBirthDate.TabIndex = 36
        Me.lblBirthDate.Text = "Birth Date"
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.DropDownWidth = 250
        Me.cboGender.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGender.ItemHeight = 14
        Me.cboGender.Items.AddRange(New Object() {"", "MALE", "FEMALE"})
        Me.cboGender.Location = New System.Drawing.Point(435, 225)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(200, 22)
        Me.cboGender.TabIndex = 42
        '
        'lblGender
        '
        Me.lblGender.BackColor = System.Drawing.Color.Transparent
        Me.lblGender.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGender.Location = New System.Drawing.Point(335, 225)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(100, 16)
        Me.lblGender.TabIndex = 41
        Me.lblGender.Text = "Gender"
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(435, 165)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(200, 20)
        Me.txtLastName.TabIndex = 33
        '
        'txtMiddleName
        '
        Me.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMiddleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(751, 135)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(200, 20)
        Me.txtMiddleName.TabIndex = 31
        '
        'lblLastName
        '
        Me.lblLastName.BackColor = System.Drawing.Color.Transparent
        Me.lblLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastName.Location = New System.Drawing.Point(335, 165)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(100, 16)
        Me.lblLastName.TabIndex = 32
        Me.lblLastName.Text = "Last Name"
        '
        'lblMiddleName
        '
        Me.lblMiddleName.BackColor = System.Drawing.Color.Transparent
        Me.lblMiddleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiddleName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMiddleName.Location = New System.Drawing.Point(651, 135)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(100, 16)
        Me.lblMiddleName.TabIndex = 30
        Me.lblMiddleName.Text = "Middle Name"
        '
        'lblFirstName
        '
        Me.lblFirstName.BackColor = System.Drawing.Color.Transparent
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(335, 135)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(100, 16)
        Me.lblFirstName.TabIndex = 28
        Me.lblFirstName.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(435, 135)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 20)
        Me.txtFirstName.TabIndex = 29
        '
        'lblJobTitle
        '
        Me.lblJobTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblJobTitle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblJobTitle.Location = New System.Drawing.Point(335, 45)
        Me.lblJobTitle.Name = "lblJobTitle"
        Me.lblJobTitle.Size = New System.Drawing.Size(100, 16)
        Me.lblJobTitle.TabIndex = 10
        Me.lblJobTitle.Text = "Job Title / Position"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.Checked = False
        Me.dtpBirthDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBirthDate.Location = New System.Drawing.Point(435, 195)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.ShowCheckBox = True
        Me.dtpBirthDate.Size = New System.Drawing.Size(175, 20)
        Me.dtpBirthDate.TabIndex = 37
        Me.dtpBirthDate.Tag = "0"
        '
        'lblActive
        '
        Me.lblActive.BackColor = System.Drawing.Color.Transparent
        Me.lblActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblActive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblActive.Location = New System.Drawing.Point(650, 465)
        Me.lblActive.Name = "lblActive"
        Me.lblActive.Size = New System.Drawing.Size(94, 16)
        Me.lblActive.TabIndex = 91
        Me.lblActive.Text = "Active Account ?"
        '
        'chkActive
        '
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.Location = New System.Drawing.Point(750, 465)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(20, 20)
        Me.chkActive.TabIndex = 92
        Me.chkActive.Tag = "1"
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
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(974, 45)
        Me.pnlToolbar.TabIndex = 18
        '
        'txtMemberNo
        '
        Me.txtMemberNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMemberNo.Location = New System.Drawing.Point(110, 15)
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.ReadOnly = True
        Me.txtMemberNo.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberNo.TabIndex = 1
        '
        'lblLGUName
        '
        Me.lblLGUName.BackColor = System.Drawing.Color.Transparent
        Me.lblLGUName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLGUName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLGUName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLGUName.Location = New System.Drawing.Point(335, 15)
        Me.lblLGUName.Name = "lblLGUName"
        Me.lblLGUName.Size = New System.Drawing.Size(100, 15)
        Me.lblLGUName.TabIndex = 2
        Me.lblLGUName.Text = "LGU Name *"
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentName.Location = New System.Drawing.Point(650, 15)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(100, 15)
        Me.lblDepartmentName.TabIndex = 5
        Me.lblDepartmentName.Text = "Department Name *"
        '
        'lblMemberNo
        '
        Me.lblMemberNo.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNo.Location = New System.Drawing.Point(10, 14)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(100, 15)
        Me.lblMemberNo.TabIndex = 0
        Me.lblMemberNo.Text = "Member No."
        '
        'cboJobId
        '
        Me.cboJobId.FormattingEnabled = True
        Me.cboJobId.Location = New System.Drawing.Point(615, 45)
        Me.cboJobId.Name = "cboJobId"
        Me.cboJobId.Size = New System.Drawing.Size(20, 22)
        Me.cboJobId.TabIndex = 12
        Me.cboJobId.TabStop = False
        Me.cboJobId.Visible = False
        '
        'dtpDateHired
        '
        Me.dtpDateHired.Checked = False
        Me.dtpDateHired.CustomFormat = "MMMM dd, yyyy"
        Me.dtpDateHired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateHired.Location = New System.Drawing.Point(110, 45)
        Me.dtpDateHired.Name = "dtpDateHired"
        Me.dtpDateHired.ShowCheckBox = True
        Me.dtpDateHired.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateHired.TabIndex = 9
        Me.dtpDateHired.Tag = "0"
        '
        'lblDateHired
        '
        Me.lblDateHired.BackColor = System.Drawing.Color.Transparent
        Me.lblDateHired.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateHired.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDateHired.Location = New System.Drawing.Point(10, 45)
        Me.lblDateHired.Name = "lblDateHired"
        Me.lblDateHired.Size = New System.Drawing.Size(100, 16)
        Me.lblDateHired.TabIndex = 8
        Me.lblDateHired.Text = "Date Started"
        '
        'tclMember
        '
        Me.tclMember.Controls.Add(Me.tpgMemberInformation)
        Me.tclMember.Controls.Add(Me.tpgEducationalBackground)
        Me.tclMember.Controls.Add(Me.tpgEmploymentHistory)
        Me.tclMember.Controls.Add(Me.tpgOrganization)
        Me.tclMember.Controls.Add(Me.tpgSeminarsAttended)
        Me.tclMember.Controls.Add(Me.tpgFamilyBackground)
        Me.tclMember.Controls.Add(Me.tpgChildren)
        Me.tclMember.Controls.Add(Me.tpgOtherBeneficiary)
        Me.tclMember.Location = New System.Drawing.Point(5, 51)
        Me.tclMember.Name = "tclMember"
        Me.tclMember.SelectedIndex = 0
        Me.tclMember.Size = New System.Drawing.Size(965, 544)
        Me.tclMember.TabIndex = 0
        '
        'tpgMemberInformation
        '
        Me.tpgMemberInformation.Controls.Add(Me.txtEmployeeId)
        Me.tpgMemberInformation.Controls.Add(Me.lblEmployeeId)
        Me.tpgMemberInformation.Controls.Add(Me.lblMember)
        Me.tpgMemberInformation.Controls.Add(Me.chkMember)
        Me.tpgMemberInformation.Controls.Add(Me.dtpMembershipDate)
        Me.tpgMemberInformation.Controls.Add(Me.lblCGMEADateMembered)
        Me.tpgMemberInformation.Controls.Add(Me.dtpOathDt)
        Me.tpgMemberInformation.Controls.Add(Me.lblOathDt)
        Me.tpgMemberInformation.Controls.Add(Me.dtpAppointmentDt)
        Me.tpgMemberInformation.Controls.Add(Me.lblAppointmentDt)
        Me.tpgMemberInformation.Controls.Add(Me.chkRetireFl)
        Me.tpgMemberInformation.Controls.Add(Me.chkReplaceFl)
        Me.tpgMemberInformation.Controls.Add(Me.chkReassignFl)
        Me.tpgMemberInformation.Controls.Add(Me.txtSalary)
        Me.tpgMemberInformation.Controls.Add(Me.lblSalaryAmount)
        Me.tpgMemberInformation.Controls.Add(Me.cboQualificationId)
        Me.tpgMemberInformation.Controls.Add(Me.cboQualification)
        Me.tpgMemberInformation.Controls.Add(Me.lblQualification)
        Me.tpgMemberInformation.Controls.Add(Me.cboAppointmentId)
        Me.tpgMemberInformation.Controls.Add(Me.txtReferredByID)
        Me.tpgMemberInformation.Controls.Add(Me.txtReferredBy)
        Me.tpgMemberInformation.Controls.Add(Me.cboStatusAppointment)
        Me.tpgMemberInformation.Controls.Add(Me.lblStatusofAppointment)
        Me.tpgMemberInformation.Controls.Add(Me.lblBirthPlace)
        Me.tpgMemberInformation.Controls.Add(Me.lblAge)
        Me.tpgMemberInformation.Controls.Add(Me.txtLGUId)
        Me.tpgMemberInformation.Controls.Add(Me.txtLGUName)
        Me.tpgMemberInformation.Controls.Add(Me.lblSuffixName)
        Me.tpgMemberInformation.Controls.Add(Me.txtSuffixName)
        Me.tpgMemberInformation.Controls.Add(Me.txtDepartmentId)
        Me.tpgMemberInformation.Controls.Add(Me.txtDepartmentName)
        Me.tpgMemberInformation.Controls.Add(Me.txtBloodType)
        Me.tpgMemberInformation.Controls.Add(Me.lblPagibigIDNo)
        Me.tpgMemberInformation.Controls.Add(Me.txtPagibigIDNo)
        Me.tpgMemberInformation.Controls.Add(Me.lblBloodType)
        Me.tpgMemberInformation.Controls.Add(Me.lblPhilHealthNo)
        Me.tpgMemberInformation.Controls.Add(Me.txtCitizenship)
        Me.tpgMemberInformation.Controls.Add(Me.lblHeight)
        Me.tpgMemberInformation.Controls.Add(Me.txtHeight)
        Me.tpgMemberInformation.Controls.Add(Me.txtWeight)
        Me.tpgMemberInformation.Controls.Add(Me.lblCitizenship)
        Me.tpgMemberInformation.Controls.Add(Me.lblWeight)
        Me.tpgMemberInformation.Controls.Add(Me.lblZipCode)
        Me.tpgMemberInformation.Controls.Add(Me.cboZipCodeId)
        Me.tpgMemberInformation.Controls.Add(Me.txtBirthPlace)
        Me.tpgMemberInformation.Controls.Add(Me.cboZipCodeArea)
        Me.tpgMemberInformation.Controls.Add(Me.cboJobId)
        Me.tpgMemberInformation.Controls.Add(Me.cboRcode)
        Me.tpgMemberInformation.Controls.Add(Me.cboRegion)
        Me.tpgMemberInformation.Controls.Add(Me.dtpDateHired)
        Me.tpgMemberInformation.Controls.Add(Me.lblBarangay)
        Me.tpgMemberInformation.Controls.Add(Me.lblDateHired)
        Me.tpgMemberInformation.Controls.Add(Me.lblProvince)
        Me.tpgMemberInformation.Controls.Add(Me.cboRurcode)
        Me.tpgMemberInformation.Controls.Add(Me.chkActive)
        Me.tpgMemberInformation.Controls.Add(Me.cboMcode)
        Me.tpgMemberInformation.Controls.Add(Me.cboPcode)
        Me.tpgMemberInformation.Controls.Add(Me.cboBarangay)
        Me.tpgMemberInformation.Controls.Add(Me.lblActive)
        Me.tpgMemberInformation.Controls.Add(Me.cboMunicipality)
        Me.tpgMemberInformation.Controls.Add(Me.cboProvince)
        Me.tpgMemberInformation.Controls.Add(Me.lblMemberNo)
        Me.tpgMemberInformation.Controls.Add(Me.txtHomeAddress)
        Me.tpgMemberInformation.Controls.Add(Me.cboStatus)
        Me.tpgMemberInformation.Controls.Add(Me.lblWorkTel)
        Me.tpgMemberInformation.Controls.Add(Me.txtWorkTel)
        Me.tpgMemberInformation.Controls.Add(Me.lblStatus)
        Me.tpgMemberInformation.Controls.Add(Me.lblTINo)
        Me.tpgMemberInformation.Controls.Add(Me.txtEmailAddress)
        Me.tpgMemberInformation.Controls.Add(Me.lblEmailAddress)
        Me.tpgMemberInformation.Controls.Add(Me.txtMobileNo)
        Me.tpgMemberInformation.Controls.Add(Me.txtFileName)
        Me.tpgMemberInformation.Controls.Add(Me.txtHomeTel)
        Me.tpgMemberInformation.Controls.Add(Me.lblMemberPhoto)
        Me.tpgMemberInformation.Controls.Add(Me.cboZipCode)
        Me.tpgMemberInformation.Controls.Add(Me.cboGender)
        Me.tpgMemberInformation.Controls.Add(Me.lblZipCodeArea)
        Me.tpgMemberInformation.Controls.Add(Me.btnPicture)
        Me.tpgMemberInformation.Controls.Add(Me.lblRegion)
        Me.tpgMemberInformation.Controls.Add(Me.lblMunicipality)
        Me.tpgMemberInformation.Controls.Add(Me.cboJobTitle)
        Me.tpgMemberInformation.Controls.Add(Me.lblHomeAddress)
        Me.tpgMemberInformation.Controls.Add(Me.lblSSSNo)
        Me.tpgMemberInformation.Controls.Add(Me.txtMemberNo)
        Me.tpgMemberInformation.Controls.Add(Me.lblMobileNo)
        Me.tpgMemberInformation.Controls.Add(Me.lblHomeTel)
        Me.tpgMemberInformation.Controls.Add(Me.txtFirstName)
        Me.tpgMemberInformation.Controls.Add(Me.lblFirstName)
        Me.tpgMemberInformation.Controls.Add(Me.dtpBirthDate)
        Me.tpgMemberInformation.Controls.Add(Me.txtMiddleName)
        Me.tpgMemberInformation.Controls.Add(Me.lblMiddleName)
        Me.tpgMemberInformation.Controls.Add(Me.lblLastName)
        Me.tpgMemberInformation.Controls.Add(Me.txtLastName)
        Me.tpgMemberInformation.Controls.Add(Me.lblJobTitle)
        Me.tpgMemberInformation.Controls.Add(Me.lblGender)
        Me.tpgMemberInformation.Controls.Add(Me.lblBirthDate)
        Me.tpgMemberInformation.Controls.Add(Me.lblDepartmentName)
        Me.tpgMemberInformation.Controls.Add(Me.Label1)
        Me.tpgMemberInformation.Controls.Add(Me.lblLGUName)
        Me.tpgMemberInformation.Controls.Add(Me.Label2)
        Me.tpgMemberInformation.Controls.Add(Me.mtxtPhilHealthNo)
        Me.tpgMemberInformation.Controls.Add(Me.mtxtTINo)
        Me.tpgMemberInformation.Controls.Add(Me.mtxtSSSNo)
        Me.tpgMemberInformation.Controls.Add(Me.lblReferredBy)
        Me.tpgMemberInformation.Controls.Add(Me.Label4)
        Me.tpgMemberInformation.Location = New System.Drawing.Point(4, 23)
        Me.tpgMemberInformation.Name = "tpgMemberInformation"
        Me.tpgMemberInformation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgMemberInformation.Size = New System.Drawing.Size(957, 517)
        Me.tpgMemberInformation.TabIndex = 0
        Me.tpgMemberInformation.Text = "Member Information"
        Me.tpgMemberInformation.UseVisualStyleBackColor = True
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmployeeId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeId.Location = New System.Drawing.Point(110, 491)
        Me.txtEmployeeId.MaxLength = 10
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.Size = New System.Drawing.Size(200, 20)
        Me.txtEmployeeId.TabIndex = 101
        '
        'lblEmployeeId
        '
        Me.lblEmployeeId.BackColor = System.Drawing.Color.Transparent
        Me.lblEmployeeId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeId.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmployeeId.Location = New System.Drawing.Point(10, 491)
        Me.lblEmployeeId.Name = "lblEmployeeId"
        Me.lblEmployeeId.Size = New System.Drawing.Size(95, 15)
        Me.lblEmployeeId.TabIndex = 100
        Me.lblEmployeeId.Text = "Employee ID"
        '
        'lblMember
        '
        Me.lblMember.BackColor = System.Drawing.Color.Transparent
        Me.lblMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMember.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMember.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMember.Location = New System.Drawing.Point(651, 493)
        Me.lblMember.Name = "lblMember"
        Me.lblMember.Size = New System.Drawing.Size(93, 16)
        Me.lblMember.TabIndex = 99
        Me.lblMember.Text = "Member Active ?"
        '
        'chkMember
        '
        Me.chkMember.Checked = True
        Me.chkMember.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMember.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMember.Location = New System.Drawing.Point(750, 489)
        Me.chkMember.Name = "chkMember"
        Me.chkMember.Size = New System.Drawing.Size(20, 20)
        Me.chkMember.TabIndex = 98
        Me.chkMember.Tag = "1"
        '
        'dtpMembershipDate
        '
        Me.dtpMembershipDate.Checked = False
        Me.dtpMembershipDate.CustomFormat = "MMMM dd, yyyy"
        Me.dtpMembershipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpMembershipDate.Location = New System.Drawing.Point(435, 465)
        Me.dtpMembershipDate.Name = "dtpMembershipDate"
        Me.dtpMembershipDate.ShowCheckBox = True
        Me.dtpMembershipDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpMembershipDate.TabIndex = 97
        Me.dtpMembershipDate.Tag = "0"
        '
        'lblCGMEADateMembered
        '
        Me.lblCGMEADateMembered.BackColor = System.Drawing.Color.Transparent
        Me.lblCGMEADateMembered.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCGMEADateMembered.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCGMEADateMembered.Location = New System.Drawing.Point(335, 465)
        Me.lblCGMEADateMembered.Name = "lblCGMEADateMembered"
        Me.lblCGMEADateMembered.Size = New System.Drawing.Size(97, 16)
        Me.lblCGMEADateMembered.TabIndex = 96
        Me.lblCGMEADateMembered.Text = "Membership Date"
        '
        'dtpOathDt
        '
        Me.dtpOathDt.Checked = False
        Me.dtpOathDt.CustomFormat = "MMMM dd, yyyy"
        Me.dtpOathDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOathDt.Location = New System.Drawing.Point(750, 105)
        Me.dtpOathDt.Name = "dtpOathDt"
        Me.dtpOathDt.ShowCheckBox = True
        Me.dtpOathDt.Size = New System.Drawing.Size(200, 20)
        Me.dtpOathDt.TabIndex = 24
        Me.dtpOathDt.Tag = "0"
        '
        'lblOathDt
        '
        Me.lblOathDt.BackColor = System.Drawing.Color.Transparent
        Me.lblOathDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOathDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOathDt.Location = New System.Drawing.Point(650, 105)
        Me.lblOathDt.Name = "lblOathDt"
        Me.lblOathDt.Size = New System.Drawing.Size(100, 16)
        Me.lblOathDt.TabIndex = 23
        Me.lblOathDt.Text = "Oath Taking Date"
        '
        'dtpAppointmentDt
        '
        Me.dtpAppointmentDt.Checked = False
        Me.dtpAppointmentDt.CustomFormat = "MMMM dd, yyyy"
        Me.dtpAppointmentDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAppointmentDt.Location = New System.Drawing.Point(435, 105)
        Me.dtpAppointmentDt.Name = "dtpAppointmentDt"
        Me.dtpAppointmentDt.ShowCheckBox = True
        Me.dtpAppointmentDt.Size = New System.Drawing.Size(200, 20)
        Me.dtpAppointmentDt.TabIndex = 22
        Me.dtpAppointmentDt.Tag = "0"
        '
        'lblAppointmentDt
        '
        Me.lblAppointmentDt.BackColor = System.Drawing.Color.Transparent
        Me.lblAppointmentDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppointmentDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAppointmentDt.Location = New System.Drawing.Point(335, 105)
        Me.lblAppointmentDt.Name = "lblAppointmentDt"
        Me.lblAppointmentDt.Size = New System.Drawing.Size(100, 16)
        Me.lblAppointmentDt.TabIndex = 21
        Me.lblAppointmentDt.Text = "Appointment Date"
        '
        'chkRetireFl
        '
        Me.chkRetireFl.Enabled = False
        Me.chkRetireFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRetireFl.Location = New System.Drawing.Point(930, 480)
        Me.chkRetireFl.Name = "chkRetireFl"
        Me.chkRetireFl.Size = New System.Drawing.Size(20, 20)
        Me.chkRetireFl.TabIndex = 95
        Me.chkRetireFl.TabStop = False
        Me.chkRetireFl.Tag = "0"
        Me.chkRetireFl.Visible = False
        '
        'chkReplaceFl
        '
        Me.chkReplaceFl.Enabled = False
        Me.chkReplaceFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReplaceFl.Location = New System.Drawing.Point(904, 480)
        Me.chkReplaceFl.Name = "chkReplaceFl"
        Me.chkReplaceFl.Size = New System.Drawing.Size(20, 20)
        Me.chkReplaceFl.TabIndex = 94
        Me.chkReplaceFl.TabStop = False
        Me.chkReplaceFl.Tag = "0"
        Me.chkReplaceFl.Visible = False
        '
        'chkReassignFl
        '
        Me.chkReassignFl.Enabled = False
        Me.chkReassignFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkReassignFl.Location = New System.Drawing.Point(878, 480)
        Me.chkReassignFl.Name = "chkReassignFl"
        Me.chkReassignFl.Size = New System.Drawing.Size(20, 20)
        Me.chkReassignFl.TabIndex = 93
        Me.chkReassignFl.TabStop = False
        Me.chkReassignFl.Tag = "0"
        Me.chkReassignFl.Visible = False
        '
        'txtSalary
        '
        Me.txtSalary.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalary.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalary.Location = New System.Drawing.Point(750, 75)
        Me.txtSalary.Name = "txtSalary"
        Me.txtSalary.Size = New System.Drawing.Size(200, 20)
        Me.txtSalary.TabIndex = 20
        Me.txtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSalaryAmount
        '
        Me.lblSalaryAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblSalaryAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalaryAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSalaryAmount.Location = New System.Drawing.Point(650, 75)
        Me.lblSalaryAmount.Name = "lblSalaryAmount"
        Me.lblSalaryAmount.Size = New System.Drawing.Size(100, 16)
        Me.lblSalaryAmount.TabIndex = 19
        Me.lblSalaryAmount.Text = "Salary (Amount)"
        '
        'cboQualificationId
        '
        Me.cboQualificationId.FormattingEnabled = True
        Me.cboQualificationId.Location = New System.Drawing.Point(615, 75)
        Me.cboQualificationId.Name = "cboQualificationId"
        Me.cboQualificationId.Size = New System.Drawing.Size(20, 22)
        Me.cboQualificationId.TabIndex = 18
        Me.cboQualificationId.TabStop = False
        Me.cboQualificationId.Visible = False
        '
        'cboQualification
        '
        Me.cboQualification.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboQualification.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboQualification.DropDownWidth = 300
        Me.cboQualification.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQualification.ItemHeight = 14
        Me.cboQualification.Location = New System.Drawing.Point(435, 75)
        Me.cboQualification.Name = "cboQualification"
        Me.cboQualification.Size = New System.Drawing.Size(200, 22)
        Me.cboQualification.TabIndex = 17
        '
        'lblQualification
        '
        Me.lblQualification.BackColor = System.Drawing.Color.Transparent
        Me.lblQualification.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQualification.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblQualification.Location = New System.Drawing.Point(335, 75)
        Me.lblQualification.Name = "lblQualification"
        Me.lblQualification.Size = New System.Drawing.Size(100, 16)
        Me.lblQualification.TabIndex = 16
        Me.lblQualification.Text = "Qualification"
        '
        'cboAppointmentId
        '
        Me.cboAppointmentId.FormattingEnabled = True
        Me.cboAppointmentId.Location = New System.Drawing.Point(930, 45)
        Me.cboAppointmentId.Name = "cboAppointmentId"
        Me.cboAppointmentId.Size = New System.Drawing.Size(20, 22)
        Me.cboAppointmentId.TabIndex = 15
        Me.cboAppointmentId.TabStop = False
        Me.cboAppointmentId.Visible = False
        '
        'txtReferredByID
        '
        Me.txtReferredByID.Location = New System.Drawing.Point(615, 465)
        Me.txtReferredByID.Name = "txtReferredByID"
        Me.txtReferredByID.ReadOnly = True
        Me.txtReferredByID.Size = New System.Drawing.Size(20, 20)
        Me.txtReferredByID.TabIndex = 90
        Me.txtReferredByID.TabStop = False
        Me.txtReferredByID.Visible = False
        '
        'txtReferredBy
        '
        Me.txtReferredBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReferredBy.Enabled = False
        Me.txtReferredBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferredBy.Location = New System.Drawing.Point(435, 491)
        Me.txtReferredBy.Name = "txtReferredBy"
        Me.txtReferredBy.Size = New System.Drawing.Size(200, 20)
        Me.txtReferredBy.TabIndex = 89
        Me.txtReferredBy.Visible = False
        '
        'cboStatusAppointment
        '
        Me.cboStatusAppointment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStatusAppointment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatusAppointment.DropDownWidth = 250
        Me.cboStatusAppointment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatusAppointment.ItemHeight = 14
        Me.cboStatusAppointment.Location = New System.Drawing.Point(750, 45)
        Me.cboStatusAppointment.Name = "cboStatusAppointment"
        Me.cboStatusAppointment.Size = New System.Drawing.Size(200, 22)
        Me.cboStatusAppointment.TabIndex = 14
        '
        'lblStatusofAppointment
        '
        Me.lblStatusofAppointment.BackColor = System.Drawing.Color.Transparent
        Me.lblStatusofAppointment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusofAppointment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStatusofAppointment.Location = New System.Drawing.Point(650, 40)
        Me.lblStatusofAppointment.Name = "lblStatusofAppointment"
        Me.lblStatusofAppointment.Size = New System.Drawing.Size(100, 32)
        Me.lblStatusofAppointment.TabIndex = 13
        Me.lblStatusofAppointment.Text = "Status of Appointment"
        '
        'lblBirthPlace
        '
        Me.lblBirthPlace.BackColor = System.Drawing.Color.Transparent
        Me.lblBirthPlace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBirthPlace.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBirthPlace.Location = New System.Drawing.Point(650, 195)
        Me.lblBirthPlace.Name = "lblBirthPlace"
        Me.lblBirthPlace.Size = New System.Drawing.Size(100, 16)
        Me.lblBirthPlace.TabIndex = 39
        Me.lblBirthPlace.Text = "Birth Place"
        '
        'lblAge
        '
        Me.lblAge.AutoSize = True
        Me.lblAge.BackColor = System.Drawing.Color.Transparent
        Me.lblAge.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAge.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAge.Location = New System.Drawing.Point(615, 195)
        Me.lblAge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(21, 14)
        Me.lblAge.TabIndex = 38
        Me.lblAge.Text = "(0)"
        '
        'txtLGUId
        '
        Me.txtLGUId.Location = New System.Drawing.Point(615, 15)
        Me.txtLGUId.Name = "txtLGUId"
        Me.txtLGUId.ReadOnly = True
        Me.txtLGUId.Size = New System.Drawing.Size(20, 20)
        Me.txtLGUId.TabIndex = 4
        Me.txtLGUId.TabStop = False
        Me.txtLGUId.Visible = False
        '
        'txtLGUName
        '
        Me.txtLGUName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLGUName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLGUName.Location = New System.Drawing.Point(435, 15)
        Me.txtLGUName.Name = "txtLGUName"
        Me.txtLGUName.Size = New System.Drawing.Size(200, 20)
        Me.txtLGUName.TabIndex = 3
        '
        'lblSuffixName
        '
        Me.lblSuffixName.BackColor = System.Drawing.Color.Transparent
        Me.lblSuffixName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuffixName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSuffixName.Location = New System.Drawing.Point(650, 165)
        Me.lblSuffixName.Name = "lblSuffixName"
        Me.lblSuffixName.Size = New System.Drawing.Size(100, 16)
        Me.lblSuffixName.TabIndex = 34
        Me.lblSuffixName.Text = "Suffix"
        '
        'txtSuffixName
        '
        Me.txtSuffixName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSuffixName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffixName.Location = New System.Drawing.Point(750, 165)
        Me.txtSuffixName.Name = "txtSuffixName"
        Me.txtSuffixName.Size = New System.Drawing.Size(200, 20)
        Me.txtSuffixName.TabIndex = 35
        '
        'txtDepartmentId
        '
        Me.txtDepartmentId.Location = New System.Drawing.Point(930, 15)
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
        Me.txtDepartmentName.Location = New System.Drawing.Point(750, 15)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(200, 20)
        Me.txtDepartmentName.TabIndex = 6
        '
        'txtBloodType
        '
        Me.txtBloodType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBloodType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBloodType.Location = New System.Drawing.Point(436, 285)
        Me.txtBloodType.MaxLength = 25
        Me.txtBloodType.Name = "txtBloodType"
        Me.txtBloodType.Size = New System.Drawing.Size(200, 20)
        Me.txtBloodType.TabIndex = 52
        '
        'lblPagibigIDNo
        '
        Me.lblPagibigIDNo.BackColor = System.Drawing.Color.Transparent
        Me.lblPagibigIDNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPagibigIDNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPagibigIDNo.Location = New System.Drawing.Point(650, 285)
        Me.lblPagibigIDNo.Name = "lblPagibigIDNo"
        Me.lblPagibigIDNo.Size = New System.Drawing.Size(100, 16)
        Me.lblPagibigIDNo.TabIndex = 53
        Me.lblPagibigIDNo.Text = "Pag-ibig ID No."
        '
        'txtPagibigIDNo
        '
        Me.txtPagibigIDNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPagibigIDNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPagibigIDNo.Location = New System.Drawing.Point(750, 285)
        Me.txtPagibigIDNo.MaxLength = 25
        Me.txtPagibigIDNo.Name = "txtPagibigIDNo"
        Me.txtPagibigIDNo.Size = New System.Drawing.Size(200, 20)
        Me.txtPagibigIDNo.TabIndex = 54
        '
        'lblBloodType
        '
        Me.lblBloodType.BackColor = System.Drawing.Color.Transparent
        Me.lblBloodType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBloodType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBloodType.Location = New System.Drawing.Point(336, 285)
        Me.lblBloodType.Name = "lblBloodType"
        Me.lblBloodType.Size = New System.Drawing.Size(100, 16)
        Me.lblBloodType.TabIndex = 51
        Me.lblBloodType.Text = "Blood Type"
        '
        'lblPhilHealthNo
        '
        Me.lblPhilHealthNo.BackColor = System.Drawing.Color.Transparent
        Me.lblPhilHealthNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhilHealthNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPhilHealthNo.Location = New System.Drawing.Point(10, 315)
        Me.lblPhilHealthNo.Name = "lblPhilHealthNo"
        Me.lblPhilHealthNo.Size = New System.Drawing.Size(100, 16)
        Me.lblPhilHealthNo.TabIndex = 55
        Me.lblPhilHealthNo.Text = "Phil. Health No."
        '
        'txtCitizenship
        '
        Me.txtCitizenship.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCitizenship.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCitizenship.Location = New System.Drawing.Point(435, 255)
        Me.txtCitizenship.MaxLength = 50
        Me.txtCitizenship.Name = "txtCitizenship"
        Me.txtCitizenship.Size = New System.Drawing.Size(200, 20)
        Me.txtCitizenship.TabIndex = 46
        '
        'lblHeight
        '
        Me.lblHeight.BackColor = System.Drawing.Color.Transparent
        Me.lblHeight.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHeight.Location = New System.Drawing.Point(650, 255)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(100, 16)
        Me.lblHeight.TabIndex = 47
        Me.lblHeight.Text = "Height (in cms.)"
        '
        'txtHeight
        '
        Me.txtHeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeight.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.Location = New System.Drawing.Point(750, 255)
        Me.txtHeight.MaxLength = 25
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(200, 20)
        Me.txtHeight.TabIndex = 48
        '
        'txtWeight
        '
        Me.txtWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWeight.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(110, 285)
        Me.txtWeight.MaxLength = 25
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(200, 20)
        Me.txtWeight.TabIndex = 50
        '
        'lblCitizenship
        '
        Me.lblCitizenship.BackColor = System.Drawing.Color.Transparent
        Me.lblCitizenship.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCitizenship.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCitizenship.Location = New System.Drawing.Point(335, 255)
        Me.lblCitizenship.Name = "lblCitizenship"
        Me.lblCitizenship.Size = New System.Drawing.Size(100, 16)
        Me.lblCitizenship.TabIndex = 45
        Me.lblCitizenship.Text = "Citizenship"
        '
        'lblWeight
        '
        Me.lblWeight.BackColor = System.Drawing.Color.Transparent
        Me.lblWeight.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWeight.Location = New System.Drawing.Point(10, 285)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(100, 16)
        Me.lblWeight.TabIndex = 49
        Me.lblWeight.Text = "Weight (in kgs.)"
        '
        'lblZipCode
        '
        Me.lblZipCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZipCode.Location = New System.Drawing.Point(650, 405)
        Me.lblZipCode.Name = "lblZipCode"
        Me.lblZipCode.Size = New System.Drawing.Size(100, 16)
        Me.lblZipCode.TabIndex = 78
        Me.lblZipCode.Text = "Zip Code Number"
        '
        'cboZipCodeId
        '
        Me.cboZipCodeId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCodeId.FormattingEnabled = True
        Me.cboZipCodeId.Location = New System.Drawing.Point(615, 405)
        Me.cboZipCodeId.Name = "cboZipCodeId"
        Me.cboZipCodeId.Size = New System.Drawing.Size(20, 22)
        Me.cboZipCodeId.TabIndex = 77
        Me.cboZipCodeId.TabStop = False
        Me.cboZipCodeId.Visible = False
        '
        'txtBirthPlace
        '
        Me.txtBirthPlace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBirthPlace.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBirthPlace.Location = New System.Drawing.Point(751, 195)
        Me.txtBirthPlace.Name = "txtBirthPlace"
        Me.txtBirthPlace.Size = New System.Drawing.Size(200, 20)
        Me.txtBirthPlace.TabIndex = 40
        '
        'cboZipCodeArea
        '
        Me.cboZipCodeArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCodeArea.DropDownWidth = 250
        Me.cboZipCodeArea.FormattingEnabled = True
        Me.cboZipCodeArea.Location = New System.Drawing.Point(435, 405)
        Me.cboZipCodeArea.Name = "cboZipCodeArea"
        Me.cboZipCodeArea.Size = New System.Drawing.Size(200, 22)
        Me.cboZipCodeArea.TabIndex = 76
        '
        'cboRcode
        '
        Me.cboRcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRcode.FormattingEnabled = True
        Me.cboRcode.Location = New System.Drawing.Point(290, 375)
        Me.cboRcode.Name = "cboRcode"
        Me.cboRcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRcode.TabIndex = 65
        Me.cboRcode.TabStop = False
        Me.cboRcode.Visible = False
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.DropDownWidth = 250
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(110, 375)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(200, 22)
        Me.cboRegion.TabIndex = 64
        '
        'lblBarangay
        '
        Me.lblBarangay.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangay.Location = New System.Drawing.Point(10, 405)
        Me.lblBarangay.Name = "lblBarangay"
        Me.lblBarangay.Size = New System.Drawing.Size(100, 16)
        Me.lblBarangay.TabIndex = 72
        Me.lblBarangay.Text = "Barangay"
        '
        'lblProvince
        '
        Me.lblProvince.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvince.Location = New System.Drawing.Point(335, 375)
        Me.lblProvince.Name = "lblProvince"
        Me.lblProvince.Size = New System.Drawing.Size(100, 16)
        Me.lblProvince.TabIndex = 66
        Me.lblProvince.Text = "Province"
        '
        'cboRurcode
        '
        Me.cboRurcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRurcode.FormattingEnabled = True
        Me.cboRurcode.Location = New System.Drawing.Point(290, 405)
        Me.cboRurcode.Name = "cboRurcode"
        Me.cboRurcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRurcode.TabIndex = 74
        Me.cboRurcode.TabStop = False
        Me.cboRurcode.Visible = False
        '
        'cboMcode
        '
        Me.cboMcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMcode.FormattingEnabled = True
        Me.cboMcode.Location = New System.Drawing.Point(930, 375)
        Me.cboMcode.Name = "cboMcode"
        Me.cboMcode.Size = New System.Drawing.Size(20, 22)
        Me.cboMcode.TabIndex = 71
        Me.cboMcode.TabStop = False
        Me.cboMcode.Visible = False
        '
        'cboPcode
        '
        Me.cboPcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPcode.FormattingEnabled = True
        Me.cboPcode.Location = New System.Drawing.Point(615, 375)
        Me.cboPcode.Name = "cboPcode"
        Me.cboPcode.Size = New System.Drawing.Size(20, 22)
        Me.cboPcode.TabIndex = 68
        Me.cboPcode.TabStop = False
        Me.cboPcode.Visible = False
        '
        'cboBarangay
        '
        Me.cboBarangay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBarangay.DropDownWidth = 250
        Me.cboBarangay.FormattingEnabled = True
        Me.cboBarangay.Location = New System.Drawing.Point(110, 405)
        Me.cboBarangay.Name = "cboBarangay"
        Me.cboBarangay.Size = New System.Drawing.Size(200, 22)
        Me.cboBarangay.TabIndex = 73
        '
        'cboMunicipality
        '
        Me.cboMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipality.DropDownWidth = 250
        Me.cboMunicipality.FormattingEnabled = True
        Me.cboMunicipality.Location = New System.Drawing.Point(750, 375)
        Me.cboMunicipality.Name = "cboMunicipality"
        Me.cboMunicipality.Size = New System.Drawing.Size(200, 22)
        Me.cboMunicipality.TabIndex = 70
        '
        'cboProvince
        '
        Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvince.DropDownWidth = 250
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(435, 375)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(200, 22)
        Me.cboProvince.TabIndex = 67
        '
        'txtHomeAddress
        '
        Me.txtHomeAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHomeAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeAddress.Location = New System.Drawing.Point(110, 345)
        Me.txtHomeAddress.Name = "txtHomeAddress"
        Me.txtHomeAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHomeAddress.Size = New System.Drawing.Size(840, 20)
        Me.txtHomeAddress.TabIndex = 62
        '
        'lblWorkTel
        '
        Me.lblWorkTel.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkTel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkTel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWorkTel.Location = New System.Drawing.Point(335, 435)
        Me.lblWorkTel.Name = "lblWorkTel"
        Me.lblWorkTel.Size = New System.Drawing.Size(100, 16)
        Me.lblWorkTel.TabIndex = 82
        Me.lblWorkTel.Text = "Work Tel No."
        '
        'txtWorkTel
        '
        Me.txtWorkTel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkTel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkTel.Location = New System.Drawing.Point(435, 435)
        Me.txtWorkTel.MaxLength = 50
        Me.txtWorkTel.Name = "txtWorkTel"
        Me.txtWorkTel.Size = New System.Drawing.Size(200, 20)
        Me.txtWorkTel.TabIndex = 83
        '
        'lblTINo
        '
        Me.lblTINo.BackColor = System.Drawing.Color.Transparent
        Me.lblTINo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTINo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTINo.Location = New System.Drawing.Point(650, 318)
        Me.lblTINo.Name = "lblTINo"
        Me.lblTINo.Size = New System.Drawing.Size(100, 16)
        Me.lblTINo.TabIndex = 59
        Me.lblTINo.Text = "Tax ID Number"
        '
        'txtEmailAddress
        '
        Me.txtEmailAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailAddress.Location = New System.Drawing.Point(110, 465)
        Me.txtEmailAddress.MaxLength = 100
        Me.txtEmailAddress.Name = "txtEmailAddress"
        Me.txtEmailAddress.Size = New System.Drawing.Size(200, 20)
        Me.txtEmailAddress.TabIndex = 87
        '
        'lblEmailAddress
        '
        Me.lblEmailAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblEmailAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmailAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmailAddress.Location = New System.Drawing.Point(10, 465)
        Me.lblEmailAddress.Name = "lblEmailAddress"
        Me.lblEmailAddress.Size = New System.Drawing.Size(100, 16)
        Me.lblEmailAddress.TabIndex = 86
        Me.lblEmailAddress.Text = "Email Address"
        '
        'txtMobileNo
        '
        Me.txtMobileNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMobileNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMobileNo.Location = New System.Drawing.Point(750, 435)
        Me.txtMobileNo.MaxLength = 50
        Me.txtMobileNo.Name = "txtMobileNo"
        Me.txtMobileNo.Size = New System.Drawing.Size(200, 20)
        Me.txtMobileNo.TabIndex = 85
        '
        'txtHomeTel
        '
        Me.txtHomeTel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHomeTel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHomeTel.Location = New System.Drawing.Point(110, 435)
        Me.txtHomeTel.MaxLength = 50
        Me.txtHomeTel.Name = "txtHomeTel"
        Me.txtHomeTel.Size = New System.Drawing.Size(200, 20)
        Me.txtHomeTel.TabIndex = 81
        '
        'cboZipCode
        '
        Me.cboZipCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboZipCode.DropDownWidth = 250
        Me.cboZipCode.Enabled = False
        Me.cboZipCode.FormattingEnabled = True
        Me.cboZipCode.Location = New System.Drawing.Point(750, 405)
        Me.cboZipCode.Name = "cboZipCode"
        Me.cboZipCode.Size = New System.Drawing.Size(200, 22)
        Me.cboZipCode.TabIndex = 79
        '
        'lblZipCodeArea
        '
        Me.lblZipCodeArea.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblZipCodeArea.Location = New System.Drawing.Point(335, 405)
        Me.lblZipCodeArea.Name = "lblZipCodeArea"
        Me.lblZipCodeArea.Size = New System.Drawing.Size(100, 16)
        Me.lblZipCodeArea.TabIndex = 75
        Me.lblZipCodeArea.Text = "Zip Code Area"
        '
        'lblRegion
        '
        Me.lblRegion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegion.Location = New System.Drawing.Point(10, 375)
        Me.lblRegion.Name = "lblRegion"
        Me.lblRegion.Size = New System.Drawing.Size(100, 16)
        Me.lblRegion.TabIndex = 63
        Me.lblRegion.Text = "Region"
        '
        'lblMunicipality
        '
        Me.lblMunicipality.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipality.Location = New System.Drawing.Point(650, 375)
        Me.lblMunicipality.Name = "lblMunicipality"
        Me.lblMunicipality.Size = New System.Drawing.Size(100, 16)
        Me.lblMunicipality.TabIndex = 69
        Me.lblMunicipality.Text = "City / Municipality"
        '
        'lblHomeAddress
        '
        Me.lblHomeAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblHomeAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHomeAddress.Location = New System.Drawing.Point(10, 345)
        Me.lblHomeAddress.Name = "lblHomeAddress"
        Me.lblHomeAddress.Size = New System.Drawing.Size(100, 16)
        Me.lblHomeAddress.TabIndex = 61
        Me.lblHomeAddress.Text = "Home Address"
        '
        'lblSSSNo
        '
        Me.lblSSSNo.BackColor = System.Drawing.Color.Transparent
        Me.lblSSSNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSSSNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSSSNo.Location = New System.Drawing.Point(335, 315)
        Me.lblSSSNo.Name = "lblSSSNo"
        Me.lblSSSNo.Size = New System.Drawing.Size(100, 16)
        Me.lblSSSNo.TabIndex = 57
        Me.lblSSSNo.Text = "SSS Number"
        '
        'lblMobileNo
        '
        Me.lblMobileNo.BackColor = System.Drawing.Color.Transparent
        Me.lblMobileNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMobileNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMobileNo.Location = New System.Drawing.Point(650, 435)
        Me.lblMobileNo.Name = "lblMobileNo"
        Me.lblMobileNo.Size = New System.Drawing.Size(100, 16)
        Me.lblMobileNo.TabIndex = 84
        Me.lblMobileNo.Text = "Mobile No."
        '
        'lblHomeTel
        '
        Me.lblHomeTel.BackColor = System.Drawing.Color.Transparent
        Me.lblHomeTel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHomeTel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHomeTel.Location = New System.Drawing.Point(10, 435)
        Me.lblHomeTel.Name = "lblHomeTel"
        Me.lblHomeTel.Size = New System.Drawing.Size(100, 16)
        Me.lblHomeTel.TabIndex = 80
        Me.lblHomeTel.Text = "Home Tel No."
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(650, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Department Name"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(335, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "LGU Name"
        '
        'mtxtPhilHealthNo
        '
        Me.mtxtPhilHealthNo.Location = New System.Drawing.Point(110, 315)
        Me.mtxtPhilHealthNo.Mask = "00-000000000-0"
        Me.mtxtPhilHealthNo.Name = "mtxtPhilHealthNo"
        Me.mtxtPhilHealthNo.Size = New System.Drawing.Size(200, 20)
        Me.mtxtPhilHealthNo.TabIndex = 56
        '
        'mtxtTINo
        '
        Me.mtxtTINo.Location = New System.Drawing.Point(750, 318)
        Me.mtxtTINo.Mask = "000-000-000-000"
        Me.mtxtTINo.Name = "mtxtTINo"
        Me.mtxtTINo.Size = New System.Drawing.Size(200, 20)
        Me.mtxtTINo.TabIndex = 60
        '
        'mtxtSSSNo
        '
        Me.mtxtSSSNo.Location = New System.Drawing.Point(435, 315)
        Me.mtxtSSSNo.Mask = "00-0000000-0"
        Me.mtxtSSSNo.Name = "mtxtSSSNo"
        Me.mtxtSSSNo.Size = New System.Drawing.Size(200, 20)
        Me.mtxtSSSNo.TabIndex = 58
        '
        'lblReferredBy
        '
        Me.lblReferredBy.BackColor = System.Drawing.Color.Transparent
        Me.lblReferredBy.Enabled = False
        Me.lblReferredBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblReferredBy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReferredBy.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReferredBy.Location = New System.Drawing.Point(336, 494)
        Me.lblReferredBy.Name = "lblReferredBy"
        Me.lblReferredBy.Size = New System.Drawing.Size(100, 15)
        Me.lblReferredBy.TabIndex = 88
        Me.lblReferredBy.Text = "Referred By"
        Me.lblReferredBy.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(335, 494)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Referred By"
        Me.Label4.Visible = False
        '
        'tpgEducationalBackground
        '
        Me.tpgEducationalBackground.Controls.Add(Me.btnEducationalEdit)
        Me.tpgEducationalBackground.Controls.Add(Me.dtpEducationalToDate)
        Me.tpgEducationalBackground.Controls.Add(Me.dtpEducationalFromDate)
        Me.tpgEducationalBackground.Controls.Add(Me.btnEducationalDelete)
        Me.tpgEducationalBackground.Controls.Add(Me.btnEducationalClear)
        Me.tpgEducationalBackground.Controls.Add(Me.btnEducationalAdd)
        Me.tpgEducationalBackground.Controls.Add(Me.txtHonors)
        Me.tpgEducationalBackground.Controls.Add(Me.lblHonors)
        Me.tpgEducationalBackground.Controls.Add(Me.lblEducationalToDate)
        Me.tpgEducationalBackground.Controls.Add(Me.lblEducationalFromDate)
        Me.tpgEducationalBackground.Controls.Add(Me.txtHighestGrade)
        Me.tpgEducationalBackground.Controls.Add(Me.lblHighestGrade)
        Me.tpgEducationalBackground.Controls.Add(Me.txtDegreeCourse)
        Me.tpgEducationalBackground.Controls.Add(Me.lblDegreeCourse)
        Me.tpgEducationalBackground.Controls.Add(Me.txtNameofSchool)
        Me.tpgEducationalBackground.Controls.Add(Me.lblNameofSchool)
        Me.tpgEducationalBackground.Controls.Add(Me.cboEducationalLevel)
        Me.tpgEducationalBackground.Controls.Add(Me.lblLevel)
        Me.tpgEducationalBackground.Controls.Add(Me.lvwEducationalBackground)
        Me.tpgEducationalBackground.Location = New System.Drawing.Point(4, 23)
        Me.tpgEducationalBackground.Name = "tpgEducationalBackground"
        Me.tpgEducationalBackground.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgEducationalBackground.Size = New System.Drawing.Size(957, 517)
        Me.tpgEducationalBackground.TabIndex = 1
        Me.tpgEducationalBackground.Text = "Educational Background"
        Me.tpgEducationalBackground.UseVisualStyleBackColor = True
        '
        'btnEducationalEdit
        '
        Me.btnEducationalEdit.Location = New System.Drawing.Point(630, 135)
        Me.btnEducationalEdit.Name = "btnEducationalEdit"
        Me.btnEducationalEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEducationalEdit.TabIndex = 8
        Me.btnEducationalEdit.Text = "Edit"
        Me.btnEducationalEdit.UseVisualStyleBackColor = True
        '
        'dtpEducationalToDate
        '
        Me.dtpEducationalToDate.CustomFormat = "MMM dd, yyyy"
        Me.dtpEducationalToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEducationalToDate.Location = New System.Drawing.Point(750, 45)
        Me.dtpEducationalToDate.Name = "dtpEducationalToDate"
        Me.dtpEducationalToDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEducationalToDate.TabIndex = 5
        '
        'dtpEducationalFromDate
        '
        Me.dtpEducationalFromDate.CustomFormat = "MMM dd, yyyy"
        Me.dtpEducationalFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEducationalFromDate.Location = New System.Drawing.Point(430, 45)
        Me.dtpEducationalFromDate.Name = "dtpEducationalFromDate"
        Me.dtpEducationalFromDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEducationalFromDate.TabIndex = 4
        '
        'btnEducationalDelete
        '
        Me.btnEducationalDelete.Location = New System.Drawing.Point(850, 135)
        Me.btnEducationalDelete.Name = "btnEducationalDelete"
        Me.btnEducationalDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnEducationalDelete.TabIndex = 10
        Me.btnEducationalDelete.Text = "Delete"
        Me.btnEducationalDelete.UseVisualStyleBackColor = True
        '
        'btnEducationalClear
        '
        Me.btnEducationalClear.Location = New System.Drawing.Point(740, 135)
        Me.btnEducationalClear.Name = "btnEducationalClear"
        Me.btnEducationalClear.Size = New System.Drawing.Size(100, 30)
        Me.btnEducationalClear.TabIndex = 9
        Me.btnEducationalClear.Text = "Clear"
        Me.btnEducationalClear.UseVisualStyleBackColor = True
        '
        'btnEducationalAdd
        '
        Me.btnEducationalAdd.Location = New System.Drawing.Point(520, 135)
        Me.btnEducationalAdd.Name = "btnEducationalAdd"
        Me.btnEducationalAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnEducationalAdd.TabIndex = 7
        Me.btnEducationalAdd.Text = "Add"
        Me.btnEducationalAdd.UseVisualStyleBackColor = True
        '
        'txtHonors
        '
        Me.txtHonors.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHonors.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHonors.Location = New System.Drawing.Point(110, 75)
        Me.txtHonors.Multiline = True
        Me.txtHonors.Name = "txtHonors"
        Me.txtHonors.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtHonors.Size = New System.Drawing.Size(840, 40)
        Me.txtHonors.TabIndex = 6
        '
        'lblHonors
        '
        Me.lblHonors.BackColor = System.Drawing.Color.Transparent
        Me.lblHonors.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHonors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHonors.Location = New System.Drawing.Point(10, 75)
        Me.lblHonors.Name = "lblHonors"
        Me.lblHonors.Size = New System.Drawing.Size(100, 32)
        Me.lblHonors.TabIndex = 130
        Me.lblHonors.Text = "Academic Honors Received"
        '
        'lblEducationalToDate
        '
        Me.lblEducationalToDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEducationalToDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEducationalToDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEducationalToDate.Location = New System.Drawing.Point(650, 45)
        Me.lblEducationalToDate.Name = "lblEducationalToDate"
        Me.lblEducationalToDate.Size = New System.Drawing.Size(100, 16)
        Me.lblEducationalToDate.TabIndex = 128
        Me.lblEducationalToDate.Text = "To Date"
        '
        'lblEducationalFromDate
        '
        Me.lblEducationalFromDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEducationalFromDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEducationalFromDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEducationalFromDate.Location = New System.Drawing.Point(330, 45)
        Me.lblEducationalFromDate.Name = "lblEducationalFromDate"
        Me.lblEducationalFromDate.Size = New System.Drawing.Size(100, 16)
        Me.lblEducationalFromDate.TabIndex = 126
        Me.lblEducationalFromDate.Text = "From Date"
        '
        'txtHighestGrade
        '
        Me.txtHighestGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHighestGrade.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHighestGrade.Location = New System.Drawing.Point(110, 45)
        Me.txtHighestGrade.Name = "txtHighestGrade"
        Me.txtHighestGrade.Size = New System.Drawing.Size(200, 20)
        Me.txtHighestGrade.TabIndex = 3
        '
        'lblHighestGrade
        '
        Me.lblHighestGrade.BackColor = System.Drawing.Color.Transparent
        Me.lblHighestGrade.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighestGrade.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblHighestGrade.Location = New System.Drawing.Point(10, 45)
        Me.lblHighestGrade.Name = "lblHighestGrade"
        Me.lblHighestGrade.Size = New System.Drawing.Size(100, 16)
        Me.lblHighestGrade.TabIndex = 124
        Me.lblHighestGrade.Text = "Highest Grade"
        '
        'txtDegreeCourse
        '
        Me.txtDegreeCourse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDegreeCourse.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDegreeCourse.Location = New System.Drawing.Point(750, 15)
        Me.txtDegreeCourse.Name = "txtDegreeCourse"
        Me.txtDegreeCourse.Size = New System.Drawing.Size(200, 20)
        Me.txtDegreeCourse.TabIndex = 2
        '
        'lblDegreeCourse
        '
        Me.lblDegreeCourse.BackColor = System.Drawing.Color.Transparent
        Me.lblDegreeCourse.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDegreeCourse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDegreeCourse.Location = New System.Drawing.Point(650, 15)
        Me.lblDegreeCourse.Name = "lblDegreeCourse"
        Me.lblDegreeCourse.Size = New System.Drawing.Size(100, 16)
        Me.lblDegreeCourse.TabIndex = 122
        Me.lblDegreeCourse.Text = "Degree / Course"
        '
        'txtNameofSchool
        '
        Me.txtNameofSchool.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNameofSchool.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNameofSchool.Location = New System.Drawing.Point(430, 15)
        Me.txtNameofSchool.Name = "txtNameofSchool"
        Me.txtNameofSchool.Size = New System.Drawing.Size(200, 20)
        Me.txtNameofSchool.TabIndex = 1
        '
        'lblNameofSchool
        '
        Me.lblNameofSchool.BackColor = System.Drawing.Color.Transparent
        Me.lblNameofSchool.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNameofSchool.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblNameofSchool.Location = New System.Drawing.Point(330, 15)
        Me.lblNameofSchool.Name = "lblNameofSchool"
        Me.lblNameofSchool.Size = New System.Drawing.Size(100, 16)
        Me.lblNameofSchool.TabIndex = 120
        Me.lblNameofSchool.Text = "Name of School"
        '
        'cboEducationalLevel
        '
        Me.cboEducationalLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEducationalLevel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEducationalLevel.ItemHeight = 14
        Me.cboEducationalLevel.Items.AddRange(New Object() {"", "Elementary", "Secondary", "Vocational / Trade Course", "Tertiary", "Graduate Studies - Diploma", "Graduate Studies - Master's", "Graduate Studies - Doctorate", "Non-Degree Course", "Others"})
        Me.cboEducationalLevel.Location = New System.Drawing.Point(110, 15)
        Me.cboEducationalLevel.Name = "cboEducationalLevel"
        Me.cboEducationalLevel.Size = New System.Drawing.Size(200, 22)
        Me.cboEducationalLevel.TabIndex = 0
        '
        'lblLevel
        '
        Me.lblLevel.BackColor = System.Drawing.Color.Transparent
        Me.lblLevel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLevel.Location = New System.Drawing.Point(10, 15)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(100, 16)
        Me.lblLevel.TabIndex = 118
        Me.lblLevel.Text = "Educational Level"
        '
        'lvwEducationalBackground
        '
        Me.lvwEducationalBackground.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrLevel, Me.chrSchool, Me.chrDegreeCourse, Me.chrHighestGrade, Me.chrFromDate, Me.chrToDate, Me.chrHonors})
        Me.lvwEducationalBackground.FullRowSelect = True
        Me.lvwEducationalBackground.GridLines = True
        Me.lvwEducationalBackground.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwEducationalBackground.Location = New System.Drawing.Point(10, 180)
        Me.lvwEducationalBackground.MultiSelect = False
        Me.lvwEducationalBackground.Name = "lvwEducationalBackground"
        Me.lvwEducationalBackground.Size = New System.Drawing.Size(940, 305)
        Me.lvwEducationalBackground.TabIndex = 11
        Me.lvwEducationalBackground.UseCompatibleStateImageBehavior = False
        Me.lvwEducationalBackground.View = System.Windows.Forms.View.Details
        '
        'chrLevel
        '
        Me.chrLevel.Text = "Level"
        Me.chrLevel.Width = 150
        '
        'chrSchool
        '
        Me.chrSchool.Text = "Name of School"
        Me.chrSchool.Width = 300
        '
        'chrDegreeCourse
        '
        Me.chrDegreeCourse.Text = "Degree / Course"
        Me.chrDegreeCourse.Width = 200
        '
        'chrHighestGrade
        '
        Me.chrHighestGrade.Text = "Highest Grade / Level / Units Earned (if not graduated)"
        '
        'chrFromDate
        '
        Me.chrFromDate.Text = "From"
        Me.chrFromDate.Width = 100
        '
        'chrToDate
        '
        Me.chrToDate.Text = "To"
        Me.chrToDate.Width = 100
        '
        'chrHonors
        '
        Me.chrHonors.Text = "Academic Honors Received"
        Me.chrHonors.Width = 150
        '
        'tpgEmploymentHistory
        '
        Me.tpgEmploymentHistory.Controls.Add(Me.txtEmploymentTaskAccomplishment)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentTaskAccomplishment)
        Me.tpgEmploymentHistory.Controls.Add(Me.txtEmploymentCompanyAddress)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentCompanyAddress)
        Me.tpgEmploymentHistory.Controls.Add(Me.txtMonthlySalary)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblMonthlySalary)
        Me.tpgEmploymentHistory.Controls.Add(Me.txtEmploymentContactNo)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentContactNo)
        Me.tpgEmploymentHistory.Controls.Add(Me.txtEmploymentCompanyName)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentCompanyName)
        Me.tpgEmploymentHistory.Controls.Add(Me.txtEmploymentPosition)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentPosition)
        Me.tpgEmploymentHistory.Controls.Add(Me.dtpEmploymentToDate)
        Me.tpgEmploymentHistory.Controls.Add(Me.dtpEmploymentFromDate)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentToDate)
        Me.tpgEmploymentHistory.Controls.Add(Me.lblEmploymentFromDate)
        Me.tpgEmploymentHistory.Controls.Add(Me.btnEmploymentEdit)
        Me.tpgEmploymentHistory.Controls.Add(Me.btnEmploymentDelete)
        Me.tpgEmploymentHistory.Controls.Add(Me.btnEmploymentClear)
        Me.tpgEmploymentHistory.Controls.Add(Me.btnEmploymentAdd)
        Me.tpgEmploymentHistory.Controls.Add(Me.lvwEmploymentHistory)
        Me.tpgEmploymentHistory.Location = New System.Drawing.Point(4, 23)
        Me.tpgEmploymentHistory.Name = "tpgEmploymentHistory"
        Me.tpgEmploymentHistory.Size = New System.Drawing.Size(957, 517)
        Me.tpgEmploymentHistory.TabIndex = 3
        Me.tpgEmploymentHistory.Text = "Employment History"
        Me.tpgEmploymentHistory.UseVisualStyleBackColor = True
        '
        'txtEmploymentTaskAccomplishment
        '
        Me.txtEmploymentTaskAccomplishment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmploymentTaskAccomplishment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmploymentTaskAccomplishment.Location = New System.Drawing.Point(110, 125)
        Me.txtEmploymentTaskAccomplishment.Multiline = True
        Me.txtEmploymentTaskAccomplishment.Name = "txtEmploymentTaskAccomplishment"
        Me.txtEmploymentTaskAccomplishment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEmploymentTaskAccomplishment.Size = New System.Drawing.Size(840, 40)
        Me.txtEmploymentTaskAccomplishment.TabIndex = 7
        '
        'lblEmploymentTaskAccomplishment
        '
        Me.lblEmploymentTaskAccomplishment.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentTaskAccomplishment.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentTaskAccomplishment.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentTaskAccomplishment.Location = New System.Drawing.Point(10, 125)
        Me.lblEmploymentTaskAccomplishment.Name = "lblEmploymentTaskAccomplishment"
        Me.lblEmploymentTaskAccomplishment.Size = New System.Drawing.Size(100, 32)
        Me.lblEmploymentTaskAccomplishment.TabIndex = 157
        Me.lblEmploymentTaskAccomplishment.Text = "Tasks and Accomplishments"
        '
        'txtEmploymentCompanyAddress
        '
        Me.txtEmploymentCompanyAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmploymentCompanyAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmploymentCompanyAddress.Location = New System.Drawing.Point(110, 75)
        Me.txtEmploymentCompanyAddress.Multiline = True
        Me.txtEmploymentCompanyAddress.Name = "txtEmploymentCompanyAddress"
        Me.txtEmploymentCompanyAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEmploymentCompanyAddress.Size = New System.Drawing.Size(840, 40)
        Me.txtEmploymentCompanyAddress.TabIndex = 6
        '
        'lblEmploymentCompanyAddress
        '
        Me.lblEmploymentCompanyAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentCompanyAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentCompanyAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentCompanyAddress.Location = New System.Drawing.Point(10, 75)
        Me.lblEmploymentCompanyAddress.Name = "lblEmploymentCompanyAddress"
        Me.lblEmploymentCompanyAddress.Size = New System.Drawing.Size(100, 16)
        Me.lblEmploymentCompanyAddress.TabIndex = 155
        Me.lblEmploymentCompanyAddress.Text = "Company Address"
        '
        'txtMonthlySalary
        '
        Me.txtMonthlySalary.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMonthlySalary.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthlySalary.Location = New System.Drawing.Point(750, 45)
        Me.txtMonthlySalary.Name = "txtMonthlySalary"
        Me.txtMonthlySalary.Size = New System.Drawing.Size(200, 20)
        Me.txtMonthlySalary.TabIndex = 5
        Me.txtMonthlySalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMonthlySalary
        '
        Me.lblMonthlySalary.BackColor = System.Drawing.Color.Transparent
        Me.lblMonthlySalary.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonthlySalary.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMonthlySalary.Location = New System.Drawing.Point(650, 45)
        Me.lblMonthlySalary.Name = "lblMonthlySalary"
        Me.lblMonthlySalary.Size = New System.Drawing.Size(100, 16)
        Me.lblMonthlySalary.TabIndex = 153
        Me.lblMonthlySalary.Text = "Monthly Salary"
        '
        'txtEmploymentContactNo
        '
        Me.txtEmploymentContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmploymentContactNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmploymentContactNo.Location = New System.Drawing.Point(430, 45)
        Me.txtEmploymentContactNo.Name = "txtEmploymentContactNo"
        Me.txtEmploymentContactNo.Size = New System.Drawing.Size(200, 20)
        Me.txtEmploymentContactNo.TabIndex = 4
        '
        'lblEmploymentContactNo
        '
        Me.lblEmploymentContactNo.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentContactNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentContactNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentContactNo.Location = New System.Drawing.Point(330, 45)
        Me.lblEmploymentContactNo.Name = "lblEmploymentContactNo"
        Me.lblEmploymentContactNo.Size = New System.Drawing.Size(100, 16)
        Me.lblEmploymentContactNo.TabIndex = 151
        Me.lblEmploymentContactNo.Text = "Contact No."
        '
        'txtEmploymentCompanyName
        '
        Me.txtEmploymentCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmploymentCompanyName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmploymentCompanyName.Location = New System.Drawing.Point(110, 45)
        Me.txtEmploymentCompanyName.Name = "txtEmploymentCompanyName"
        Me.txtEmploymentCompanyName.Size = New System.Drawing.Size(200, 20)
        Me.txtEmploymentCompanyName.TabIndex = 3
        '
        'lblEmploymentCompanyName
        '
        Me.lblEmploymentCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentCompanyName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentCompanyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentCompanyName.Location = New System.Drawing.Point(10, 45)
        Me.lblEmploymentCompanyName.Name = "lblEmploymentCompanyName"
        Me.lblEmploymentCompanyName.Size = New System.Drawing.Size(100, 16)
        Me.lblEmploymentCompanyName.TabIndex = 149
        Me.lblEmploymentCompanyName.Text = "Company Name"
        '
        'txtEmploymentPosition
        '
        Me.txtEmploymentPosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEmploymentPosition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmploymentPosition.Location = New System.Drawing.Point(750, 15)
        Me.txtEmploymentPosition.Name = "txtEmploymentPosition"
        Me.txtEmploymentPosition.Size = New System.Drawing.Size(200, 20)
        Me.txtEmploymentPosition.TabIndex = 2
        '
        'lblEmploymentPosition
        '
        Me.lblEmploymentPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentPosition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentPosition.Location = New System.Drawing.Point(650, 15)
        Me.lblEmploymentPosition.Name = "lblEmploymentPosition"
        Me.lblEmploymentPosition.Size = New System.Drawing.Size(100, 16)
        Me.lblEmploymentPosition.TabIndex = 147
        Me.lblEmploymentPosition.Text = "Job Title"
        '
        'dtpEmploymentToDate
        '
        Me.dtpEmploymentToDate.CustomFormat = "MMM dd, yyyy"
        Me.dtpEmploymentToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEmploymentToDate.Location = New System.Drawing.Point(430, 15)
        Me.dtpEmploymentToDate.Name = "dtpEmploymentToDate"
        Me.dtpEmploymentToDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEmploymentToDate.TabIndex = 1
        '
        'dtpEmploymentFromDate
        '
        Me.dtpEmploymentFromDate.CustomFormat = "MMM dd, yyyy"
        Me.dtpEmploymentFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEmploymentFromDate.Location = New System.Drawing.Point(110, 15)
        Me.dtpEmploymentFromDate.Name = "dtpEmploymentFromDate"
        Me.dtpEmploymentFromDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEmploymentFromDate.TabIndex = 0
        '
        'lblEmploymentToDate
        '
        Me.lblEmploymentToDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentToDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentToDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentToDate.Location = New System.Drawing.Point(330, 15)
        Me.lblEmploymentToDate.Name = "lblEmploymentToDate"
        Me.lblEmploymentToDate.Size = New System.Drawing.Size(100, 16)
        Me.lblEmploymentToDate.TabIndex = 145
        Me.lblEmploymentToDate.Text = "To Date"
        '
        'lblEmploymentFromDate
        '
        Me.lblEmploymentFromDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEmploymentFromDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentFromDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmploymentFromDate.Location = New System.Drawing.Point(10, 15)
        Me.lblEmploymentFromDate.Name = "lblEmploymentFromDate"
        Me.lblEmploymentFromDate.Size = New System.Drawing.Size(100, 16)
        Me.lblEmploymentFromDate.TabIndex = 144
        Me.lblEmploymentFromDate.Text = "From Date"
        '
        'btnEmploymentEdit
        '
        Me.btnEmploymentEdit.Location = New System.Drawing.Point(630, 180)
        Me.btnEmploymentEdit.Name = "btnEmploymentEdit"
        Me.btnEmploymentEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEmploymentEdit.TabIndex = 9
        Me.btnEmploymentEdit.Text = "Edit"
        Me.btnEmploymentEdit.UseVisualStyleBackColor = True
        '
        'btnEmploymentDelete
        '
        Me.btnEmploymentDelete.Location = New System.Drawing.Point(850, 180)
        Me.btnEmploymentDelete.Name = "btnEmploymentDelete"
        Me.btnEmploymentDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnEmploymentDelete.TabIndex = 11
        Me.btnEmploymentDelete.Text = "Delete"
        Me.btnEmploymentDelete.UseVisualStyleBackColor = True
        '
        'btnEmploymentClear
        '
        Me.btnEmploymentClear.Location = New System.Drawing.Point(740, 180)
        Me.btnEmploymentClear.Name = "btnEmploymentClear"
        Me.btnEmploymentClear.Size = New System.Drawing.Size(100, 30)
        Me.btnEmploymentClear.TabIndex = 10
        Me.btnEmploymentClear.Text = "Clear"
        Me.btnEmploymentClear.UseVisualStyleBackColor = True
        '
        'btnEmploymentAdd
        '
        Me.btnEmploymentAdd.Location = New System.Drawing.Point(520, 180)
        Me.btnEmploymentAdd.Name = "btnEmploymentAdd"
        Me.btnEmploymentAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnEmploymentAdd.TabIndex = 8
        Me.btnEmploymentAdd.Text = "Add"
        Me.btnEmploymentAdd.UseVisualStyleBackColor = True
        '
        'lvwEmploymentHistory
        '
        Me.lvwEmploymentHistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrWorkFromDate, Me.chrWorkToDate, Me.chrPosition, Me.chrCompany, Me.chrCompanyAddress, Me.chrCompanyContactNo, Me.chrSalary, Me.chrTaskAccomplishment})
        Me.lvwEmploymentHistory.FullRowSelect = True
        Me.lvwEmploymentHistory.GridLines = True
        Me.lvwEmploymentHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwEmploymentHistory.Location = New System.Drawing.Point(10, 225)
        Me.lvwEmploymentHistory.MultiSelect = False
        Me.lvwEmploymentHistory.Name = "lvwEmploymentHistory"
        Me.lvwEmploymentHistory.Size = New System.Drawing.Size(940, 260)
        Me.lvwEmploymentHistory.TabIndex = 12
        Me.lvwEmploymentHistory.UseCompatibleStateImageBehavior = False
        Me.lvwEmploymentHistory.View = System.Windows.Forms.View.Details
        '
        'chrWorkFromDate
        '
        Me.chrWorkFromDate.Text = "From"
        Me.chrWorkFromDate.Width = 100
        '
        'chrWorkToDate
        '
        Me.chrWorkToDate.Text = "To"
        Me.chrWorkToDate.Width = 100
        '
        'chrPosition
        '
        Me.chrPosition.Text = "Position"
        Me.chrPosition.Width = 150
        '
        'chrCompany
        '
        Me.chrCompany.Text = "Company Name"
        Me.chrCompany.Width = 200
        '
        'chrCompanyAddress
        '
        Me.chrCompanyAddress.Text = "Address"
        Me.chrCompanyAddress.Width = 250
        '
        'chrCompanyContactNo
        '
        Me.chrCompanyContactNo.Text = "Contact Number"
        Me.chrCompanyContactNo.Width = 200
        '
        'chrSalary
        '
        Me.chrSalary.Text = "Monthly Salary"
        Me.chrSalary.Width = 150
        '
        'chrTaskAccomplishment
        '
        Me.chrTaskAccomplishment.Text = "Tasks and Accomplishments"
        Me.chrTaskAccomplishment.Width = 300
        '
        'tpgOrganization
        '
        Me.tpgOrganization.Controls.Add(Me.txtOrganizationAddress)
        Me.tpgOrganization.Controls.Add(Me.lblOrganizationAddress)
        Me.tpgOrganization.Controls.Add(Me.txtOrganizationPosition)
        Me.tpgOrganization.Controls.Add(Me.lblOrganizationPosition)
        Me.tpgOrganization.Controls.Add(Me.txtOrganizationName)
        Me.tpgOrganization.Controls.Add(Me.lblOrganizationName)
        Me.tpgOrganization.Controls.Add(Me.dtpOrganizationSinceDt)
        Me.tpgOrganization.Controls.Add(Me.lblOrganizationSinceDt)
        Me.tpgOrganization.Controls.Add(Me.btnOrganizationEdit)
        Me.tpgOrganization.Controls.Add(Me.btnOrganizationDelete)
        Me.tpgOrganization.Controls.Add(Me.btnOrganizationClear)
        Me.tpgOrganization.Controls.Add(Me.btnOrganizationAdd)
        Me.tpgOrganization.Controls.Add(Me.lvwOrganization)
        Me.tpgOrganization.Location = New System.Drawing.Point(4, 23)
        Me.tpgOrganization.Name = "tpgOrganization"
        Me.tpgOrganization.Size = New System.Drawing.Size(957, 517)
        Me.tpgOrganization.TabIndex = 2
        Me.tpgOrganization.Text = "Organizations"
        Me.tpgOrganization.UseVisualStyleBackColor = True
        '
        'txtOrganizationAddress
        '
        Me.txtOrganizationAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrganizationAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganizationAddress.Location = New System.Drawing.Point(110, 45)
        Me.txtOrganizationAddress.Multiline = True
        Me.txtOrganizationAddress.Name = "txtOrganizationAddress"
        Me.txtOrganizationAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOrganizationAddress.Size = New System.Drawing.Size(840, 40)
        Me.txtOrganizationAddress.TabIndex = 3
        '
        'lblOrganizationAddress
        '
        Me.lblOrganizationAddress.BackColor = System.Drawing.Color.Transparent
        Me.lblOrganizationAddress.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganizationAddress.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOrganizationAddress.Location = New System.Drawing.Point(10, 45)
        Me.lblOrganizationAddress.Name = "lblOrganizationAddress"
        Me.lblOrganizationAddress.Size = New System.Drawing.Size(100, 16)
        Me.lblOrganizationAddress.TabIndex = 159
        Me.lblOrganizationAddress.Text = "Address"
        '
        'txtOrganizationPosition
        '
        Me.txtOrganizationPosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrganizationPosition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganizationPosition.Location = New System.Drawing.Point(430, 15)
        Me.txtOrganizationPosition.Name = "txtOrganizationPosition"
        Me.txtOrganizationPosition.Size = New System.Drawing.Size(200, 20)
        Me.txtOrganizationPosition.TabIndex = 1
        '
        'lblOrganizationPosition
        '
        Me.lblOrganizationPosition.BackColor = System.Drawing.Color.Transparent
        Me.lblOrganizationPosition.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganizationPosition.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOrganizationPosition.Location = New System.Drawing.Point(330, 15)
        Me.lblOrganizationPosition.Name = "lblOrganizationPosition"
        Me.lblOrganizationPosition.Size = New System.Drawing.Size(100, 16)
        Me.lblOrganizationPosition.TabIndex = 155
        Me.lblOrganizationPosition.Text = "Position"
        '
        'txtOrganizationName
        '
        Me.txtOrganizationName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOrganizationName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrganizationName.Location = New System.Drawing.Point(110, 15)
        Me.txtOrganizationName.Name = "txtOrganizationName"
        Me.txtOrganizationName.Size = New System.Drawing.Size(200, 20)
        Me.txtOrganizationName.TabIndex = 0
        '
        'lblOrganizationName
        '
        Me.lblOrganizationName.BackColor = System.Drawing.Color.Transparent
        Me.lblOrganizationName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganizationName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOrganizationName.Location = New System.Drawing.Point(10, 15)
        Me.lblOrganizationName.Name = "lblOrganizationName"
        Me.lblOrganizationName.Size = New System.Drawing.Size(100, 16)
        Me.lblOrganizationName.TabIndex = 153
        Me.lblOrganizationName.Text = "Organization Name"
        '
        'dtpOrganizationSinceDt
        '
        Me.dtpOrganizationSinceDt.CustomFormat = "MMM dd, yyyy"
        Me.dtpOrganizationSinceDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOrganizationSinceDt.Location = New System.Drawing.Point(750, 15)
        Me.dtpOrganizationSinceDt.Name = "dtpOrganizationSinceDt"
        Me.dtpOrganizationSinceDt.Size = New System.Drawing.Size(200, 20)
        Me.dtpOrganizationSinceDt.TabIndex = 2
        '
        'lblOrganizationSinceDt
        '
        Me.lblOrganizationSinceDt.BackColor = System.Drawing.Color.Transparent
        Me.lblOrganizationSinceDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrganizationSinceDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblOrganizationSinceDt.Location = New System.Drawing.Point(650, 15)
        Me.lblOrganizationSinceDt.Name = "lblOrganizationSinceDt"
        Me.lblOrganizationSinceDt.Size = New System.Drawing.Size(100, 16)
        Me.lblOrganizationSinceDt.TabIndex = 151
        Me.lblOrganizationSinceDt.Text = "Member Since"
        '
        'btnOrganizationEdit
        '
        Me.btnOrganizationEdit.Location = New System.Drawing.Point(630, 100)
        Me.btnOrganizationEdit.Name = "btnOrganizationEdit"
        Me.btnOrganizationEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnOrganizationEdit.TabIndex = 5
        Me.btnOrganizationEdit.Text = "Edit"
        Me.btnOrganizationEdit.UseVisualStyleBackColor = True
        '
        'btnOrganizationDelete
        '
        Me.btnOrganizationDelete.Location = New System.Drawing.Point(850, 100)
        Me.btnOrganizationDelete.Name = "btnOrganizationDelete"
        Me.btnOrganizationDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnOrganizationDelete.TabIndex = 7
        Me.btnOrganizationDelete.Text = "Delete"
        Me.btnOrganizationDelete.UseVisualStyleBackColor = True
        '
        'btnOrganizationClear
        '
        Me.btnOrganizationClear.Location = New System.Drawing.Point(740, 100)
        Me.btnOrganizationClear.Name = "btnOrganizationClear"
        Me.btnOrganizationClear.Size = New System.Drawing.Size(100, 30)
        Me.btnOrganizationClear.TabIndex = 6
        Me.btnOrganizationClear.Text = "Clear"
        Me.btnOrganizationClear.UseVisualStyleBackColor = True
        '
        'btnOrganizationAdd
        '
        Me.btnOrganizationAdd.Location = New System.Drawing.Point(520, 100)
        Me.btnOrganizationAdd.Name = "btnOrganizationAdd"
        Me.btnOrganizationAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnOrganizationAdd.TabIndex = 4
        Me.btnOrganizationAdd.Text = "Add"
        Me.btnOrganizationAdd.UseVisualStyleBackColor = True
        '
        'lvwOrganization
        '
        Me.lvwOrganization.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrOrganizationName, Me.chrOrganizationAddress, Me.chrOrganizationPosition, Me.chrOrganizationSinceDt})
        Me.lvwOrganization.FullRowSelect = True
        Me.lvwOrganization.GridLines = True
        Me.lvwOrganization.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwOrganization.Location = New System.Drawing.Point(10, 145)
        Me.lvwOrganization.MultiSelect = False
        Me.lvwOrganization.Name = "lvwOrganization"
        Me.lvwOrganization.Size = New System.Drawing.Size(940, 340)
        Me.lvwOrganization.TabIndex = 8
        Me.lvwOrganization.UseCompatibleStateImageBehavior = False
        Me.lvwOrganization.View = System.Windows.Forms.View.Details
        '
        'chrOrganizationName
        '
        Me.chrOrganizationName.Text = "Organization Name"
        Me.chrOrganizationName.Width = 200
        '
        'chrOrganizationAddress
        '
        Me.chrOrganizationAddress.Text = "Address"
        Me.chrOrganizationAddress.Width = 250
        '
        'chrOrganizationPosition
        '
        Me.chrOrganizationPosition.Text = "Position"
        Me.chrOrganizationPosition.Width = 150
        '
        'chrOrganizationSinceDt
        '
        Me.chrOrganizationSinceDt.Text = "Member Since"
        Me.chrOrganizationSinceDt.Width = 125
        '
        'tpgSeminarsAttended
        '
        Me.tpgSeminarsAttended.Controls.Add(Me.txtSeminarRemarks)
        Me.tpgSeminarsAttended.Controls.Add(Me.lblSeminarRemarks)
        Me.tpgSeminarsAttended.Controls.Add(Me.txtSeminarLocation)
        Me.tpgSeminarsAttended.Controls.Add(Me.lblSeminarLocation)
        Me.tpgSeminarsAttended.Controls.Add(Me.txtSeminarName)
        Me.tpgSeminarsAttended.Controls.Add(Me.lblSeminarName)
        Me.tpgSeminarsAttended.Controls.Add(Me.dtpSeminarDate)
        Me.tpgSeminarsAttended.Controls.Add(Me.lblSeminarDate)
        Me.tpgSeminarsAttended.Controls.Add(Me.btnSeminarEdit)
        Me.tpgSeminarsAttended.Controls.Add(Me.btnSeminarDelete)
        Me.tpgSeminarsAttended.Controls.Add(Me.btnSeminarClear)
        Me.tpgSeminarsAttended.Controls.Add(Me.btnSeminarAdd)
        Me.tpgSeminarsAttended.Controls.Add(Me.lvwSeminarsAttended)
        Me.tpgSeminarsAttended.Location = New System.Drawing.Point(4, 23)
        Me.tpgSeminarsAttended.Name = "tpgSeminarsAttended"
        Me.tpgSeminarsAttended.Size = New System.Drawing.Size(957, 517)
        Me.tpgSeminarsAttended.TabIndex = 4
        Me.tpgSeminarsAttended.Text = "Seminars Attended"
        Me.tpgSeminarsAttended.UseVisualStyleBackColor = True
        '
        'txtSeminarRemarks
        '
        Me.txtSeminarRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSeminarRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeminarRemarks.Location = New System.Drawing.Point(110, 45)
        Me.txtSeminarRemarks.Multiline = True
        Me.txtSeminarRemarks.Name = "txtSeminarRemarks"
        Me.txtSeminarRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtSeminarRemarks.Size = New System.Drawing.Size(840, 40)
        Me.txtSeminarRemarks.TabIndex = 3
        '
        'lblSeminarRemarks
        '
        Me.lblSeminarRemarks.BackColor = System.Drawing.Color.Transparent
        Me.lblSeminarRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeminarRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeminarRemarks.Location = New System.Drawing.Point(10, 45)
        Me.lblSeminarRemarks.Name = "lblSeminarRemarks"
        Me.lblSeminarRemarks.Size = New System.Drawing.Size(100, 16)
        Me.lblSeminarRemarks.TabIndex = 167
        Me.lblSeminarRemarks.Text = "Remarks"
        '
        'txtSeminarLocation
        '
        Me.txtSeminarLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSeminarLocation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeminarLocation.Location = New System.Drawing.Point(430, 15)
        Me.txtSeminarLocation.Name = "txtSeminarLocation"
        Me.txtSeminarLocation.Size = New System.Drawing.Size(200, 20)
        Me.txtSeminarLocation.TabIndex = 1
        '
        'lblSeminarLocation
        '
        Me.lblSeminarLocation.BackColor = System.Drawing.Color.Transparent
        Me.lblSeminarLocation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeminarLocation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeminarLocation.Location = New System.Drawing.Point(330, 15)
        Me.lblSeminarLocation.Name = "lblSeminarLocation"
        Me.lblSeminarLocation.Size = New System.Drawing.Size(100, 16)
        Me.lblSeminarLocation.TabIndex = 166
        Me.lblSeminarLocation.Text = "Location"
        '
        'txtSeminarName
        '
        Me.txtSeminarName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSeminarName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeminarName.Location = New System.Drawing.Point(110, 15)
        Me.txtSeminarName.Name = "txtSeminarName"
        Me.txtSeminarName.Size = New System.Drawing.Size(200, 20)
        Me.txtSeminarName.TabIndex = 0
        '
        'lblSeminarName
        '
        Me.lblSeminarName.BackColor = System.Drawing.Color.Transparent
        Me.lblSeminarName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeminarName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeminarName.Location = New System.Drawing.Point(10, 15)
        Me.lblSeminarName.Name = "lblSeminarName"
        Me.lblSeminarName.Size = New System.Drawing.Size(100, 16)
        Me.lblSeminarName.TabIndex = 165
        Me.lblSeminarName.Text = "Seminar Name"
        '
        'dtpSeminarDate
        '
        Me.dtpSeminarDate.CustomFormat = "MMM dd, yyyy"
        Me.dtpSeminarDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSeminarDate.Location = New System.Drawing.Point(750, 15)
        Me.dtpSeminarDate.Name = "dtpSeminarDate"
        Me.dtpSeminarDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpSeminarDate.TabIndex = 2
        '
        'lblSeminarDate
        '
        Me.lblSeminarDate.BackColor = System.Drawing.Color.Transparent
        Me.lblSeminarDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeminarDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSeminarDate.Location = New System.Drawing.Point(650, 15)
        Me.lblSeminarDate.Name = "lblSeminarDate"
        Me.lblSeminarDate.Size = New System.Drawing.Size(100, 16)
        Me.lblSeminarDate.TabIndex = 164
        Me.lblSeminarDate.Text = "Date"
        '
        'btnSeminarEdit
        '
        Me.btnSeminarEdit.Location = New System.Drawing.Point(630, 100)
        Me.btnSeminarEdit.Name = "btnSeminarEdit"
        Me.btnSeminarEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnSeminarEdit.TabIndex = 5
        Me.btnSeminarEdit.Text = "Edit"
        Me.btnSeminarEdit.UseVisualStyleBackColor = True
        '
        'btnSeminarDelete
        '
        Me.btnSeminarDelete.Location = New System.Drawing.Point(850, 100)
        Me.btnSeminarDelete.Name = "btnSeminarDelete"
        Me.btnSeminarDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnSeminarDelete.TabIndex = 7
        Me.btnSeminarDelete.Text = "Delete"
        Me.btnSeminarDelete.UseVisualStyleBackColor = True
        '
        'btnSeminarClear
        '
        Me.btnSeminarClear.Location = New System.Drawing.Point(740, 100)
        Me.btnSeminarClear.Name = "btnSeminarClear"
        Me.btnSeminarClear.Size = New System.Drawing.Size(100, 30)
        Me.btnSeminarClear.TabIndex = 6
        Me.btnSeminarClear.Text = "Clear"
        Me.btnSeminarClear.UseVisualStyleBackColor = True
        '
        'btnSeminarAdd
        '
        Me.btnSeminarAdd.Location = New System.Drawing.Point(520, 100)
        Me.btnSeminarAdd.Name = "btnSeminarAdd"
        Me.btnSeminarAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnSeminarAdd.TabIndex = 4
        Me.btnSeminarAdd.Text = "Add"
        Me.btnSeminarAdd.UseVisualStyleBackColor = True
        '
        'lvwSeminarsAttended
        '
        Me.lvwSeminarsAttended.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrSeminarName, Me.chrSeminarLocation, Me.chrSeminarDate, Me.chrSeminarRemarks})
        Me.lvwSeminarsAttended.FullRowSelect = True
        Me.lvwSeminarsAttended.GridLines = True
        Me.lvwSeminarsAttended.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwSeminarsAttended.Location = New System.Drawing.Point(10, 145)
        Me.lvwSeminarsAttended.MultiSelect = False
        Me.lvwSeminarsAttended.Name = "lvwSeminarsAttended"
        Me.lvwSeminarsAttended.Size = New System.Drawing.Size(940, 340)
        Me.lvwSeminarsAttended.TabIndex = 8
        Me.lvwSeminarsAttended.UseCompatibleStateImageBehavior = False
        Me.lvwSeminarsAttended.View = System.Windows.Forms.View.Details
        '
        'chrSeminarName
        '
        Me.chrSeminarName.Text = "Seminar / Workshop / Training"
        Me.chrSeminarName.Width = 300
        '
        'chrSeminarLocation
        '
        Me.chrSeminarLocation.Text = "Location"
        Me.chrSeminarLocation.Width = 200
        '
        'chrSeminarDate
        '
        Me.chrSeminarDate.Text = "Date Attended"
        Me.chrSeminarDate.Width = 150
        '
        'chrSeminarRemarks
        '
        Me.chrSeminarRemarks.Text = "Remarks"
        Me.chrSeminarRemarks.Width = 250
        '
        'tpgFamilyBackground
        '
        Me.tpgFamilyBackground.Controls.Add(Me.lvwFamilyBackground)
        Me.tpgFamilyBackground.Controls.Add(Me.btnFamilyDelete)
        Me.tpgFamilyBackground.Controls.Add(Me.btnFamilyEdit)
        Me.tpgFamilyBackground.Controls.Add(Me.btnFamilyAdd)
        Me.tpgFamilyBackground.Controls.Add(Me.btnFamilyClear)
        Me.tpgFamilyBackground.Controls.Add(Me.lblMother)
        Me.tpgFamilyBackground.Controls.Add(Me.txtMotherLName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label14)
        Me.tpgFamilyBackground.Controls.Add(Me.txtMotherMName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label15)
        Me.tpgFamilyBackground.Controls.Add(Me.txtMotherFName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label16)
        Me.tpgFamilyBackground.Controls.Add(Me.lblFatherName)
        Me.tpgFamilyBackground.Controls.Add(Me.txtFatherSuffix)
        Me.tpgFamilyBackground.Controls.Add(Me.Label10)
        Me.tpgFamilyBackground.Controls.Add(Me.txtFatherLName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label11)
        Me.tpgFamilyBackground.Controls.Add(Me.txtFatherMName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label12)
        Me.tpgFamilyBackground.Controls.Add(Me.txtFatherFName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label13)
        Me.tpgFamilyBackground.Controls.Add(Me.lblSpouseName)
        Me.tpgFamilyBackground.Controls.Add(Me.dtpSpouseBirth)
        Me.tpgFamilyBackground.Controls.Add(Me.lblSpouseBirthdate)
        Me.tpgFamilyBackground.Controls.Add(Me.txtSpouseSuffix)
        Me.tpgFamilyBackground.Controls.Add(Me.Label5)
        Me.tpgFamilyBackground.Controls.Add(Me.txtSpouseLName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label6)
        Me.tpgFamilyBackground.Controls.Add(Me.txtSpouseMName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label7)
        Me.tpgFamilyBackground.Controls.Add(Me.txtSpouseFName)
        Me.tpgFamilyBackground.Controls.Add(Me.Label8)
        Me.tpgFamilyBackground.Location = New System.Drawing.Point(4, 23)
        Me.tpgFamilyBackground.Name = "tpgFamilyBackground"
        Me.tpgFamilyBackground.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgFamilyBackground.Size = New System.Drawing.Size(957, 517)
        Me.tpgFamilyBackground.TabIndex = 5
        Me.tpgFamilyBackground.Text = "Family Background"
        Me.tpgFamilyBackground.UseVisualStyleBackColor = True
        '
        'lvwFamilyBackground
        '
        Me.lvwFamilyBackground.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrSpouseFName, Me.chrSpouseMName, Me.chrSpouseLName, Me.chrSpouseSuffix, Me.chrSpouseBirthdate, Me.chrFatherFName, Me.chrFatherMName, Me.chrFatherLName, Me.chrMotherFName, Me.chrMotherLName})
        Me.lvwFamilyBackground.FullRowSelect = True
        Me.lvwFamilyBackground.GridLines = True
        Me.lvwFamilyBackground.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwFamilyBackground.Location = New System.Drawing.Point(8, 226)
        Me.lvwFamilyBackground.MultiSelect = False
        Me.lvwFamilyBackground.Name = "lvwFamilyBackground"
        Me.lvwFamilyBackground.Size = New System.Drawing.Size(940, 260)
        Me.lvwFamilyBackground.TabIndex = 222
        Me.lvwFamilyBackground.UseCompatibleStateImageBehavior = False
        Me.lvwFamilyBackground.View = System.Windows.Forms.View.Details
        '
        'chrSpouseFName
        '
        Me.chrSpouseFName.Text = "Spouse First Name"
        Me.chrSpouseFName.Width = 125
        '
        'chrSpouseMName
        '
        Me.chrSpouseMName.Text = "Spouse Middle Name"
        Me.chrSpouseMName.Width = 125
        '
        'chrSpouseLName
        '
        Me.chrSpouseLName.Text = "Spouse Last Name"
        Me.chrSpouseLName.Width = 125
        '
        'chrSpouseSuffix
        '
        Me.chrSpouseSuffix.Text = "Spouse Suffix"
        Me.chrSpouseSuffix.Width = 100
        '
        'chrSpouseBirthdate
        '
        Me.chrSpouseBirthdate.Text = "Spouse Birth Date"
        Me.chrSpouseBirthdate.Width = 125
        '
        'chrFatherFName
        '
        Me.chrFatherFName.Text = "Father First Name"
        Me.chrFatherFName.Width = 125
        '
        'chrFatherMName
        '
        Me.chrFatherMName.Text = "Father Middle Name"
        Me.chrFatherMName.Width = 125
        '
        'chrFatherLName
        '
        Me.chrFatherLName.Text = "Father Last Name"
        Me.chrFatherLName.Width = 125
        '
        'chrMotherFName
        '
        Me.chrMotherFName.Text = "Mother First Name"
        Me.chrMotherFName.Width = 125
        '
        'chrMotherLName
        '
        Me.chrMotherLName.Text = "Mother Last Name"
        Me.chrMotherLName.Width = 125
        '
        'btnFamilyDelete
        '
        Me.btnFamilyDelete.Location = New System.Drawing.Point(828, 190)
        Me.btnFamilyDelete.Name = "btnFamilyDelete"
        Me.btnFamilyDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnFamilyDelete.TabIndex = 221
        Me.btnFamilyDelete.Text = "Delete"
        Me.btnFamilyDelete.UseVisualStyleBackColor = True
        '
        'btnFamilyEdit
        '
        Me.btnFamilyEdit.Location = New System.Drawing.Point(608, 190)
        Me.btnFamilyEdit.Name = "btnFamilyEdit"
        Me.btnFamilyEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnFamilyEdit.TabIndex = 219
        Me.btnFamilyEdit.Text = "Edit"
        Me.btnFamilyEdit.UseVisualStyleBackColor = True
        '
        'btnFamilyAdd
        '
        Me.btnFamilyAdd.Location = New System.Drawing.Point(498, 190)
        Me.btnFamilyAdd.Name = "btnFamilyAdd"
        Me.btnFamilyAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnFamilyAdd.TabIndex = 218
        Me.btnFamilyAdd.Text = "Add"
        Me.btnFamilyAdd.UseVisualStyleBackColor = True
        '
        'btnFamilyClear
        '
        Me.btnFamilyClear.Location = New System.Drawing.Point(718, 190)
        Me.btnFamilyClear.Name = "btnFamilyClear"
        Me.btnFamilyClear.Size = New System.Drawing.Size(100, 30)
        Me.btnFamilyClear.TabIndex = 220
        Me.btnFamilyClear.Text = "Clear"
        Me.btnFamilyClear.UseVisualStyleBackColor = True
        '
        'lblMother
        '
        Me.lblMother.AutoSize = True
        Me.lblMother.Location = New System.Drawing.Point(11, 139)
        Me.lblMother.Name = "lblMother"
        Me.lblMother.Size = New System.Drawing.Size(83, 14)
        Me.lblMother.TabIndex = 217
        Me.lblMother.Text = "Name of Mother"
        '
        'txtMotherLName
        '
        Me.txtMotherLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotherLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotherLName.Location = New System.Drawing.Point(522, 136)
        Me.txtMotherLName.Name = "txtMotherLName"
        Me.txtMotherLName.Size = New System.Drawing.Size(200, 20)
        Me.txtMotherLName.TabIndex = 215
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(522, 159)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(81, 16)
        Me.Label14.TabIndex = 216
        Me.Label14.Text = "Last Name"
        '
        'txtMotherMName
        '
        Me.txtMotherMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotherMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotherMName.Location = New System.Drawing.Point(316, 136)
        Me.txtMotherMName.Name = "txtMotherMName"
        Me.txtMotherMName.Size = New System.Drawing.Size(200, 20)
        Me.txtMotherMName.TabIndex = 213
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label15.Location = New System.Drawing.Point(313, 160)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 16)
        Me.Label15.TabIndex = 214
        Me.Label15.Text = "Middle Name"
        '
        'txtMotherFName
        '
        Me.txtMotherFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMotherFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotherFName.Location = New System.Drawing.Point(110, 136)
        Me.txtMotherFName.Name = "txtMotherFName"
        Me.txtMotherFName.Size = New System.Drawing.Size(200, 20)
        Me.txtMotherFName.TabIndex = 211
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(107, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 16)
        Me.Label16.TabIndex = 212
        Me.Label16.Text = "First Name"
        '
        'lblFatherName
        '
        Me.lblFatherName.AutoSize = True
        Me.lblFatherName.Location = New System.Drawing.Point(11, 96)
        Me.lblFatherName.Name = "lblFatherName"
        Me.lblFatherName.Size = New System.Drawing.Size(81, 14)
        Me.lblFatherName.TabIndex = 210
        Me.lblFatherName.Text = "Name of Father"
        '
        'txtFatherSuffix
        '
        Me.txtFatherSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFatherSuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFatherSuffix.Location = New System.Drawing.Point(728, 93)
        Me.txtFatherSuffix.Name = "txtFatherSuffix"
        Me.txtFatherSuffix.Size = New System.Drawing.Size(200, 20)
        Me.txtFatherSuffix.TabIndex = 208
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(725, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 16)
        Me.Label10.TabIndex = 209
        Me.Label10.Text = "Suffix"
        '
        'txtFatherLName
        '
        Me.txtFatherLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFatherLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFatherLName.Location = New System.Drawing.Point(522, 93)
        Me.txtFatherLName.Name = "txtFatherLName"
        Me.txtFatherLName.Size = New System.Drawing.Size(200, 20)
        Me.txtFatherLName.TabIndex = 206
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label11.Location = New System.Drawing.Point(522, 116)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 16)
        Me.Label11.TabIndex = 207
        Me.Label11.Text = "Last Name"
        '
        'txtFatherMName
        '
        Me.txtFatherMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFatherMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFatherMName.Location = New System.Drawing.Point(316, 93)
        Me.txtFatherMName.Name = "txtFatherMName"
        Me.txtFatherMName.Size = New System.Drawing.Size(200, 20)
        Me.txtFatherMName.TabIndex = 204
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(313, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 16)
        Me.Label12.TabIndex = 205
        Me.Label12.Text = "Middle Name"
        '
        'txtFatherFName
        '
        Me.txtFatherFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFatherFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFatherFName.Location = New System.Drawing.Point(110, 93)
        Me.txtFatherFName.Name = "txtFatherFName"
        Me.txtFatherFName.Size = New System.Drawing.Size(200, 20)
        Me.txtFatherFName.TabIndex = 202
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Location = New System.Drawing.Point(107, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(81, 16)
        Me.Label13.TabIndex = 203
        Me.Label13.Text = "First Name"
        '
        'lblSpouseName
        '
        Me.lblSpouseName.AutoSize = True
        Me.lblSpouseName.Location = New System.Drawing.Point(10, 15)
        Me.lblSpouseName.Name = "lblSpouseName"
        Me.lblSpouseName.Size = New System.Drawing.Size(87, 14)
        Me.lblSpouseName.TabIndex = 201
        Me.lblSpouseName.Text = "Name of Spouse"
        '
        'dtpSpouseBirth
        '
        Me.dtpSpouseBirth.CustomFormat = "MMM dd, yyyy"
        Me.dtpSpouseBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSpouseBirth.Location = New System.Drawing.Point(110, 58)
        Me.dtpSpouseBirth.Name = "dtpSpouseBirth"
        Me.dtpSpouseBirth.Size = New System.Drawing.Size(200, 20)
        Me.dtpSpouseBirth.TabIndex = 200
        '
        'lblSpouseBirthdate
        '
        Me.lblSpouseBirthdate.BackColor = System.Drawing.Color.Transparent
        Me.lblSpouseBirthdate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpouseBirthdate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSpouseBirthdate.Location = New System.Drawing.Point(11, 62)
        Me.lblSpouseBirthdate.Name = "lblSpouseBirthdate"
        Me.lblSpouseBirthdate.Size = New System.Drawing.Size(85, 16)
        Me.lblSpouseBirthdate.TabIndex = 199
        Me.lblSpouseBirthdate.Text = "Spouse Birth"
        '
        'txtSpouseSuffix
        '
        Me.txtSpouseSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpouseSuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpouseSuffix.Location = New System.Drawing.Point(728, 15)
        Me.txtSpouseSuffix.Name = "txtSpouseSuffix"
        Me.txtSpouseSuffix.Size = New System.Drawing.Size(200, 20)
        Me.txtSpouseSuffix.TabIndex = 197
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(725, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 16)
        Me.Label5.TabIndex = 198
        Me.Label5.Text = "Suffix"
        '
        'txtSpouseLName
        '
        Me.txtSpouseLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpouseLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpouseLName.Location = New System.Drawing.Point(522, 15)
        Me.txtSpouseLName.Name = "txtSpouseLName"
        Me.txtSpouseLName.Size = New System.Drawing.Size(200, 20)
        Me.txtSpouseLName.TabIndex = 195
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(522, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 16)
        Me.Label6.TabIndex = 196
        Me.Label6.Text = "Last Name"
        '
        'txtSpouseMName
        '
        Me.txtSpouseMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpouseMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpouseMName.Location = New System.Drawing.Point(316, 15)
        Me.txtSpouseMName.Name = "txtSpouseMName"
        Me.txtSpouseMName.Size = New System.Drawing.Size(200, 20)
        Me.txtSpouseMName.TabIndex = 193
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(313, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 16)
        Me.Label7.TabIndex = 194
        Me.Label7.Text = "Middle Name"
        '
        'txtSpouseFName
        '
        Me.txtSpouseFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpouseFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpouseFName.Location = New System.Drawing.Point(110, 15)
        Me.txtSpouseFName.Name = "txtSpouseFName"
        Me.txtSpouseFName.Size = New System.Drawing.Size(200, 20)
        Me.txtSpouseFName.TabIndex = 191
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(107, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 16)
        Me.Label8.TabIndex = 192
        Me.Label8.Text = "First Name"
        '
        'tpgChildren
        '
        Me.tpgChildren.Controls.Add(Me.cboChildStatus)
        Me.tpgChildren.Controls.Add(Me.lblChildStatus)
        Me.tpgChildren.Controls.Add(Me.lvwChildren)
        Me.tpgChildren.Controls.Add(Me.dtpChildBirth)
        Me.tpgChildren.Controls.Add(Me.lblChildBirthDate)
        Me.tpgChildren.Controls.Add(Me.txtChildSuffix)
        Me.tpgChildren.Controls.Add(Me.lblChildSuffix)
        Me.tpgChildren.Controls.Add(Me.txtChildLName)
        Me.tpgChildren.Controls.Add(Me.lblChildLName)
        Me.tpgChildren.Controls.Add(Me.txtChildMName)
        Me.tpgChildren.Controls.Add(Me.lblChildMName)
        Me.tpgChildren.Controls.Add(Me.txtChildFName)
        Me.tpgChildren.Controls.Add(Me.lblChildFName)
        Me.tpgChildren.Controls.Add(Me.btnChildDelete)
        Me.tpgChildren.Controls.Add(Me.btnChildEdit)
        Me.tpgChildren.Controls.Add(Me.btnChildAdd)
        Me.tpgChildren.Controls.Add(Me.btnChildClear)
        Me.tpgChildren.Location = New System.Drawing.Point(4, 23)
        Me.tpgChildren.Name = "tpgChildren"
        Me.tpgChildren.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgChildren.Size = New System.Drawing.Size(957, 517)
        Me.tpgChildren.TabIndex = 6
        Me.tpgChildren.Text = "Children"
        Me.tpgChildren.UseVisualStyleBackColor = True
        '
        'cboChildStatus
        '
        Me.cboChildStatus.FormattingEnabled = True
        Me.cboChildStatus.Items.AddRange(New Object() {"", "MARRIED", "DECEASED"})
        Me.cboChildStatus.Location = New System.Drawing.Point(430, 41)
        Me.cboChildStatus.Name = "cboChildStatus"
        Me.cboChildStatus.Size = New System.Drawing.Size(200, 22)
        Me.cboChildStatus.TabIndex = 193
        '
        'lblChildStatus
        '
        Me.lblChildStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblChildStatus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChildStatus.Location = New System.Drawing.Point(330, 44)
        Me.lblChildStatus.Name = "lblChildStatus"
        Me.lblChildStatus.Size = New System.Drawing.Size(81, 16)
        Me.lblChildStatus.TabIndex = 192
        Me.lblChildStatus.Text = "Status"
        '
        'lvwChildren
        '
        Me.lvwChildren.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrChildFName, Me.chrChildMName, Me.chrChildLName, Me.chrChildSuffix, Me.chrChildBirth, Me.chrChildAge, Me.chrChildStatus})
        Me.lvwChildren.FullRowSelect = True
        Me.lvwChildren.GridLines = True
        Me.lvwChildren.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwChildren.Location = New System.Drawing.Point(8, 157)
        Me.lvwChildren.MultiSelect = False
        Me.lvwChildren.Name = "lvwChildren"
        Me.lvwChildren.Size = New System.Drawing.Size(940, 329)
        Me.lvwChildren.TabIndex = 191
        Me.lvwChildren.UseCompatibleStateImageBehavior = False
        Me.lvwChildren.View = System.Windows.Forms.View.Details
        '
        'chrChildFName
        '
        Me.chrChildFName.Text = "Child First Name"
        Me.chrChildFName.Width = 200
        '
        'chrChildMName
        '
        Me.chrChildMName.Text = "Child Middle Name"
        Me.chrChildMName.Width = 175
        '
        'chrChildLName
        '
        Me.chrChildLName.Text = "Child Last Name"
        Me.chrChildLName.Width = 225
        '
        'chrChildSuffix
        '
        Me.chrChildSuffix.Text = "Child Suffix"
        Me.chrChildSuffix.Width = 75
        '
        'chrChildBirth
        '
        Me.chrChildBirth.Text = "Birth Date"
        Me.chrChildBirth.Width = 100
        '
        'chrChildAge
        '
        Me.chrChildAge.Text = "Age"
        Me.chrChildAge.Width = 75
        '
        'chrChildStatus
        '
        Me.chrChildStatus.Text = "Status"
        Me.chrChildStatus.Width = 100
        '
        'dtpChildBirth
        '
        Me.dtpChildBirth.CustomFormat = "MMM dd, yyyy"
        Me.dtpChildBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpChildBirth.Location = New System.Drawing.Point(430, 15)
        Me.dtpChildBirth.Name = "dtpChildBirth"
        Me.dtpChildBirth.Size = New System.Drawing.Size(200, 20)
        Me.dtpChildBirth.TabIndex = 190
        '
        'lblChildBirthDate
        '
        Me.lblChildBirthDate.BackColor = System.Drawing.Color.Transparent
        Me.lblChildBirthDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildBirthDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChildBirthDate.Location = New System.Drawing.Point(330, 15)
        Me.lblChildBirthDate.Name = "lblChildBirthDate"
        Me.lblChildBirthDate.Size = New System.Drawing.Size(85, 16)
        Me.lblChildBirthDate.TabIndex = 189
        Me.lblChildBirthDate.Text = "Date of Birth"
        '
        'txtChildSuffix
        '
        Me.txtChildSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChildSuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChildSuffix.Location = New System.Drawing.Point(110, 93)
        Me.txtChildSuffix.Name = "txtChildSuffix"
        Me.txtChildSuffix.Size = New System.Drawing.Size(200, 20)
        Me.txtChildSuffix.TabIndex = 187
        '
        'lblChildSuffix
        '
        Me.lblChildSuffix.BackColor = System.Drawing.Color.Transparent
        Me.lblChildSuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildSuffix.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChildSuffix.Location = New System.Drawing.Point(10, 96)
        Me.lblChildSuffix.Name = "lblChildSuffix"
        Me.lblChildSuffix.Size = New System.Drawing.Size(81, 16)
        Me.lblChildSuffix.TabIndex = 188
        Me.lblChildSuffix.Text = "Suffix"
        '
        'txtChildLName
        '
        Me.txtChildLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChildLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChildLName.Location = New System.Drawing.Point(110, 67)
        Me.txtChildLName.Name = "txtChildLName"
        Me.txtChildLName.Size = New System.Drawing.Size(200, 20)
        Me.txtChildLName.TabIndex = 185
        '
        'lblChildLName
        '
        Me.lblChildLName.BackColor = System.Drawing.Color.Transparent
        Me.lblChildLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildLName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChildLName.Location = New System.Drawing.Point(10, 70)
        Me.lblChildLName.Name = "lblChildLName"
        Me.lblChildLName.Size = New System.Drawing.Size(81, 16)
        Me.lblChildLName.TabIndex = 186
        Me.lblChildLName.Text = "Last Name"
        '
        'txtChildMName
        '
        Me.txtChildMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChildMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChildMName.Location = New System.Drawing.Point(110, 41)
        Me.txtChildMName.Name = "txtChildMName"
        Me.txtChildMName.Size = New System.Drawing.Size(200, 20)
        Me.txtChildMName.TabIndex = 183
        '
        'lblChildMName
        '
        Me.lblChildMName.BackColor = System.Drawing.Color.Transparent
        Me.lblChildMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildMName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChildMName.Location = New System.Drawing.Point(10, 44)
        Me.lblChildMName.Name = "lblChildMName"
        Me.lblChildMName.Size = New System.Drawing.Size(81, 16)
        Me.lblChildMName.TabIndex = 184
        Me.lblChildMName.Text = "Middle Name"
        '
        'txtChildFName
        '
        Me.txtChildFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChildFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtChildFName.Location = New System.Drawing.Point(110, 15)
        Me.txtChildFName.Name = "txtChildFName"
        Me.txtChildFName.Size = New System.Drawing.Size(200, 20)
        Me.txtChildFName.TabIndex = 181
        '
        'lblChildFName
        '
        Me.lblChildFName.BackColor = System.Drawing.Color.Transparent
        Me.lblChildFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChildFName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblChildFName.Location = New System.Drawing.Point(10, 15)
        Me.lblChildFName.Name = "lblChildFName"
        Me.lblChildFName.Size = New System.Drawing.Size(81, 16)
        Me.lblChildFName.TabIndex = 182
        Me.lblChildFName.Text = "First Name"
        '
        'btnChildDelete
        '
        Me.btnChildDelete.Location = New System.Drawing.Point(835, 121)
        Me.btnChildDelete.Name = "btnChildDelete"
        Me.btnChildDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnChildDelete.TabIndex = 180
        Me.btnChildDelete.Text = "Delete"
        Me.btnChildDelete.UseVisualStyleBackColor = True
        '
        'btnChildEdit
        '
        Me.btnChildEdit.Location = New System.Drawing.Point(615, 121)
        Me.btnChildEdit.Name = "btnChildEdit"
        Me.btnChildEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnChildEdit.TabIndex = 178
        Me.btnChildEdit.Text = "Edit"
        Me.btnChildEdit.UseVisualStyleBackColor = True
        '
        'btnChildAdd
        '
        Me.btnChildAdd.Location = New System.Drawing.Point(505, 121)
        Me.btnChildAdd.Name = "btnChildAdd"
        Me.btnChildAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnChildAdd.TabIndex = 177
        Me.btnChildAdd.Text = "Add"
        Me.btnChildAdd.UseVisualStyleBackColor = True
        '
        'btnChildClear
        '
        Me.btnChildClear.Location = New System.Drawing.Point(725, 121)
        Me.btnChildClear.Name = "btnChildClear"
        Me.btnChildClear.Size = New System.Drawing.Size(100, 30)
        Me.btnChildClear.TabIndex = 179
        Me.btnChildClear.Text = "Clear"
        Me.btnChildClear.UseVisualStyleBackColor = True
        '
        'tpgOtherBeneficiary
        '
        Me.tpgOtherBeneficiary.Controls.Add(Me.txtBeneficiarySuffix)
        Me.tpgOtherBeneficiary.Controls.Add(Me.Label3)
        Me.tpgOtherBeneficiary.Controls.Add(Me.txtBeneficiaryLName)
        Me.tpgOtherBeneficiary.Controls.Add(Me.Label9)
        Me.tpgOtherBeneficiary.Controls.Add(Me.txtBeneficiaryMName)
        Me.tpgOtherBeneficiary.Controls.Add(Me.Label17)
        Me.tpgOtherBeneficiary.Controls.Add(Me.Label18)
        Me.tpgOtherBeneficiary.Controls.Add(Me.txtBeneficiaryRelation)
        Me.tpgOtherBeneficiary.Controls.Add(Me.lblMemberRelation)
        Me.tpgOtherBeneficiary.Controls.Add(Me.txtBeneficiaryFName)
        Me.tpgOtherBeneficiary.Controls.Add(Me.lblbeneficiaryName)
        Me.tpgOtherBeneficiary.Controls.Add(Me.btnBeneficiaryEdit)
        Me.tpgOtherBeneficiary.Controls.Add(Me.btnBeneficiaryDelete)
        Me.tpgOtherBeneficiary.Controls.Add(Me.btnBeneficiaryClear)
        Me.tpgOtherBeneficiary.Controls.Add(Me.btnBeneficiaryAdd)
        Me.tpgOtherBeneficiary.Controls.Add(Me.lvwOtherBeneficiary)
        Me.tpgOtherBeneficiary.Location = New System.Drawing.Point(4, 23)
        Me.tpgOtherBeneficiary.Name = "tpgOtherBeneficiary"
        Me.tpgOtherBeneficiary.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOtherBeneficiary.Size = New System.Drawing.Size(957, 517)
        Me.tpgOtherBeneficiary.TabIndex = 7
        Me.tpgOtherBeneficiary.Text = "Other Beneficiary"
        Me.tpgOtherBeneficiary.UseVisualStyleBackColor = True
        '
        'txtBeneficiarySuffix
        '
        Me.txtBeneficiarySuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiarySuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeneficiarySuffix.Location = New System.Drawing.Point(728, 15)
        Me.txtBeneficiarySuffix.Name = "txtBeneficiarySuffix"
        Me.txtBeneficiarySuffix.Size = New System.Drawing.Size(200, 20)
        Me.txtBeneficiarySuffix.TabIndex = 204
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(725, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 205
        Me.Label3.Text = "Suffix"
        '
        'txtBeneficiaryLName
        '
        Me.txtBeneficiaryLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiaryLName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeneficiaryLName.Location = New System.Drawing.Point(522, 15)
        Me.txtBeneficiaryLName.Name = "txtBeneficiaryLName"
        Me.txtBeneficiaryLName.Size = New System.Drawing.Size(200, 20)
        Me.txtBeneficiaryLName.TabIndex = 202
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(522, 38)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(81, 16)
        Me.Label9.TabIndex = 203
        Me.Label9.Text = "Last Name"
        '
        'txtBeneficiaryMName
        '
        Me.txtBeneficiaryMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiaryMName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeneficiaryMName.Location = New System.Drawing.Point(316, 15)
        Me.txtBeneficiaryMName.Name = "txtBeneficiaryMName"
        Me.txtBeneficiaryMName.Size = New System.Drawing.Size(200, 20)
        Me.txtBeneficiaryMName.TabIndex = 200
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label17.Location = New System.Drawing.Point(313, 39)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 16)
        Me.Label17.TabIndex = 201
        Me.Label17.Text = "Middle Name"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label18.Location = New System.Drawing.Point(107, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 16)
        Me.Label18.TabIndex = 199
        Me.Label18.Text = "First Name"
        '
        'txtBeneficiaryRelation
        '
        Me.txtBeneficiaryRelation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiaryRelation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeneficiaryRelation.Location = New System.Drawing.Point(110, 58)
        Me.txtBeneficiaryRelation.Name = "txtBeneficiaryRelation"
        Me.txtBeneficiaryRelation.Size = New System.Drawing.Size(200, 20)
        Me.txtBeneficiaryRelation.TabIndex = 177
        '
        'lblMemberRelation
        '
        Me.lblMemberRelation.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberRelation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberRelation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberRelation.Location = New System.Drawing.Point(10, 58)
        Me.lblMemberRelation.Name = "lblMemberRelation"
        Me.lblMemberRelation.Size = New System.Drawing.Size(94, 35)
        Me.lblMemberRelation.TabIndex = 184
        Me.lblMemberRelation.Text = "Relationship to Member"
        '
        'txtBeneficiaryFName
        '
        Me.txtBeneficiaryFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiaryFName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBeneficiaryFName.Location = New System.Drawing.Point(110, 15)
        Me.txtBeneficiaryFName.Name = "txtBeneficiaryFName"
        Me.txtBeneficiaryFName.Size = New System.Drawing.Size(200, 20)
        Me.txtBeneficiaryFName.TabIndex = 176
        '
        'lblbeneficiaryName
        '
        Me.lblbeneficiaryName.BackColor = System.Drawing.Color.Transparent
        Me.lblbeneficiaryName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblbeneficiaryName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblbeneficiaryName.Location = New System.Drawing.Point(10, 15)
        Me.lblbeneficiaryName.Name = "lblbeneficiaryName"
        Me.lblbeneficiaryName.Size = New System.Drawing.Size(100, 16)
        Me.lblbeneficiaryName.TabIndex = 183
        Me.lblbeneficiaryName.Text = "Beneficiary Name"
        '
        'btnBeneficiaryEdit
        '
        Me.btnBeneficiaryEdit.Location = New System.Drawing.Point(629, 86)
        Me.btnBeneficiaryEdit.Name = "btnBeneficiaryEdit"
        Me.btnBeneficiaryEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnBeneficiaryEdit.TabIndex = 179
        Me.btnBeneficiaryEdit.Text = "Edit"
        Me.btnBeneficiaryEdit.UseVisualStyleBackColor = True
        '
        'btnBeneficiaryDelete
        '
        Me.btnBeneficiaryDelete.Location = New System.Drawing.Point(849, 86)
        Me.btnBeneficiaryDelete.Name = "btnBeneficiaryDelete"
        Me.btnBeneficiaryDelete.Size = New System.Drawing.Size(100, 30)
        Me.btnBeneficiaryDelete.TabIndex = 181
        Me.btnBeneficiaryDelete.Text = "Delete"
        Me.btnBeneficiaryDelete.UseVisualStyleBackColor = True
        '
        'btnBeneficiaryClear
        '
        Me.btnBeneficiaryClear.Location = New System.Drawing.Point(739, 86)
        Me.btnBeneficiaryClear.Name = "btnBeneficiaryClear"
        Me.btnBeneficiaryClear.Size = New System.Drawing.Size(100, 30)
        Me.btnBeneficiaryClear.TabIndex = 180
        Me.btnBeneficiaryClear.Text = "Clear"
        Me.btnBeneficiaryClear.UseVisualStyleBackColor = True
        '
        'btnBeneficiaryAdd
        '
        Me.btnBeneficiaryAdd.Location = New System.Drawing.Point(519, 86)
        Me.btnBeneficiaryAdd.Name = "btnBeneficiaryAdd"
        Me.btnBeneficiaryAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnBeneficiaryAdd.TabIndex = 178
        Me.btnBeneficiaryAdd.Text = "Add"
        Me.btnBeneficiaryAdd.UseVisualStyleBackColor = True
        '
        'lvwOtherBeneficiary
        '
        Me.lvwOtherBeneficiary.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chrBeneficiaryFName, Me.chrBeneficiaryMName, Me.chrBeneficiaryLName, Me.chrBeneficiarySuffix, Me.chrBeneficiaryRelation})
        Me.lvwOtherBeneficiary.FullRowSelect = True
        Me.lvwOtherBeneficiary.GridLines = True
        Me.lvwOtherBeneficiary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvwOtherBeneficiary.Location = New System.Drawing.Point(8, 131)
        Me.lvwOtherBeneficiary.MultiSelect = False
        Me.lvwOtherBeneficiary.Name = "lvwOtherBeneficiary"
        Me.lvwOtherBeneficiary.Size = New System.Drawing.Size(940, 350)
        Me.lvwOtherBeneficiary.TabIndex = 182
        Me.lvwOtherBeneficiary.UseCompatibleStateImageBehavior = False
        Me.lvwOtherBeneficiary.View = System.Windows.Forms.View.Details
        '
        'chrBeneficiaryFName
        '
        Me.chrBeneficiaryFName.Text = "Beneficiary First Name"
        Me.chrBeneficiaryFName.Width = 150
        '
        'chrBeneficiaryMName
        '
        Me.chrBeneficiaryMName.Text = "Beneficiary Middle Name"
        Me.chrBeneficiaryMName.Width = 150
        '
        'chrBeneficiaryLName
        '
        Me.chrBeneficiaryLName.Text = "Beneficiary Last Name"
        Me.chrBeneficiaryLName.Width = 150
        '
        'chrBeneficiarySuffix
        '
        Me.chrBeneficiarySuffix.Text = "Beneficiary Suffix"
        Me.chrBeneficiarySuffix.Width = 100
        '
        'chrBeneficiaryRelation
        '
        Me.chrBeneficiaryRelation.Text = "Relation to Member"
        Me.chrBeneficiaryRelation.Width = 150
        '
        'cmsPreview
        '
        Me.cmsPreview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrintMemberProfileToolStripMenuItem})
        Me.cmsPreview.Name = "cmsPreview"
        Me.cmsPreview.Size = New System.Drawing.Size(185, 26)
        '
        'PrintMemberProfileToolStripMenuItem
        '
        Me.PrintMemberProfileToolStripMenuItem.Name = "PrintMemberProfileToolStripMenuItem"
        Me.PrintMemberProfileToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.PrintMemberProfileToolStripMenuItem.Text = "Print Member Profile"
        '
        'frmMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 596)
        Me.ContextMenuStrip = Me.cmsPreview
        Me.Controls.Add(Me.tclMember)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMember"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member"
        Me.cmenuPhoto.ResumeLayout(False)
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.tclMember.ResumeLayout(False)
        Me.tpgMemberInformation.ResumeLayout(False)
        Me.tpgMemberInformation.PerformLayout()
        Me.tpgEducationalBackground.ResumeLayout(False)
        Me.tpgEducationalBackground.PerformLayout()
        Me.tpgEmploymentHistory.ResumeLayout(False)
        Me.tpgEmploymentHistory.PerformLayout()
        Me.tpgOrganization.ResumeLayout(False)
        Me.tpgOrganization.PerformLayout()
        Me.tpgSeminarsAttended.ResumeLayout(False)
        Me.tpgSeminarsAttended.PerformLayout()
        Me.tpgFamilyBackground.ResumeLayout(False)
        Me.tpgFamilyBackground.PerformLayout()
        Me.tpgChildren.ResumeLayout(False)
        Me.tpgChildren.PerformLayout()
        Me.tpgOtherBeneficiary.ResumeLayout(False)
        Me.tpgOtherBeneficiary.PerformLayout()
        Me.cmsPreview.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblMemberPhoto As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents btnPicture As System.Windows.Forms.Button
    Friend WithEvents cmenuPhoto As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboJobTitle As System.Windows.Forms.ComboBox
    Friend WithEvents lblBirthDate As System.Windows.Forms.Label
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblJobTitle As System.Windows.Forms.Label
    Friend WithEvents dtpBirthDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblActive As System.Windows.Forms.Label
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents lblLGUName As System.Windows.Forms.Label
    Friend WithEvents lblDepartmentName As System.Windows.Forms.Label
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents cboJobId As System.Windows.Forms.ComboBox
    Friend WithEvents tclMember As System.Windows.Forms.TabControl
    Friend WithEvents tpgMemberInformation As System.Windows.Forms.TabPage
    Friend WithEvents tpgEducationalBackground As System.Windows.Forms.TabPage
    Friend WithEvents dtpDateHired As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateHired As System.Windows.Forms.Label
    Friend WithEvents lblBirthPlace As System.Windows.Forms.Label
    Friend WithEvents txtBirthPlace As System.Windows.Forms.TextBox
    Friend WithEvents lblZipCode As System.Windows.Forms.Label
    Friend WithEvents cboZipCodeId As System.Windows.Forms.ComboBox
    Friend WithEvents cboZipCodeArea As System.Windows.Forms.ComboBox
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents lblBarangay As System.Windows.Forms.Label
    Friend WithEvents lblProvince As System.Windows.Forms.Label
    Friend WithEvents cboRurcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboMcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboPcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboBarangay As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents txtHomeAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblWorkTel As System.Windows.Forms.Label
    Friend WithEvents txtWorkTel As System.Windows.Forms.TextBox
    Friend WithEvents lblTINo As System.Windows.Forms.Label
    Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmailAddress As System.Windows.Forms.Label
    Friend WithEvents txtMobileNo As System.Windows.Forms.TextBox
    Friend WithEvents txtHomeTel As System.Windows.Forms.TextBox
    Friend WithEvents cboZipCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblZipCodeArea As System.Windows.Forms.Label
    Friend WithEvents lblRegion As System.Windows.Forms.Label
    Friend WithEvents lblMunicipality As System.Windows.Forms.Label
    Friend WithEvents lblHomeAddress As System.Windows.Forms.Label
    Friend WithEvents lblSSSNo As System.Windows.Forms.Label
    Friend WithEvents lblMobileNo As System.Windows.Forms.Label
    Friend WithEvents lblHomeTel As System.Windows.Forms.Label
    Friend WithEvents txtBloodType As System.Windows.Forms.TextBox
    Friend WithEvents lblPagibigIDNo As System.Windows.Forms.Label
    Friend WithEvents txtPagibigIDNo As System.Windows.Forms.TextBox
    Friend WithEvents lblBloodType As System.Windows.Forms.Label
    Friend WithEvents lblPhilHealthNo As System.Windows.Forms.Label
    Friend WithEvents txtCitizenship As System.Windows.Forms.TextBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents lblCitizenship As System.Windows.Forms.Label
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents lvwEducationalBackground As System.Windows.Forms.ListView
    Friend WithEvents chrLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSchool As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrDegreeCourse As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrHighestGrade As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrFromDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrToDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrHonors As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpgOrganization As System.Windows.Forms.TabPage
    Friend WithEvents btnEducationalDelete As System.Windows.Forms.Button
    Friend WithEvents btnEducationalClear As System.Windows.Forms.Button
    Friend WithEvents btnEducationalAdd As System.Windows.Forms.Button
    Friend WithEvents txtHonors As System.Windows.Forms.TextBox
    Friend WithEvents lblHonors As System.Windows.Forms.Label
    Friend WithEvents lblEducationalToDate As System.Windows.Forms.Label
    Friend WithEvents lblEducationalFromDate As System.Windows.Forms.Label
    Friend WithEvents txtHighestGrade As System.Windows.Forms.TextBox
    Friend WithEvents lblHighestGrade As System.Windows.Forms.Label
    Friend WithEvents txtDegreeCourse As System.Windows.Forms.TextBox
    Friend WithEvents lblDegreeCourse As System.Windows.Forms.Label
    Friend WithEvents txtNameofSchool As System.Windows.Forms.TextBox
    Friend WithEvents lblNameofSchool As System.Windows.Forms.Label
    Friend WithEvents cboEducationalLevel As System.Windows.Forms.ComboBox
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents tpgEmploymentHistory As System.Windows.Forms.TabPage
    Friend WithEvents tpgSeminarsAttended As System.Windows.Forms.TabPage
    Friend WithEvents btnEmploymentDelete As System.Windows.Forms.Button
    Friend WithEvents btnEmploymentClear As System.Windows.Forms.Button
    Friend WithEvents btnEmploymentAdd As System.Windows.Forms.Button
    Friend WithEvents lvwEmploymentHistory As System.Windows.Forms.ListView
    Friend WithEvents chrWorkFromDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrWorkToDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrPosition As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrCompany As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSalary As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrTaskAccomplishment As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpEducationalToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEducationalFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnEducationalEdit As System.Windows.Forms.Button
    Friend WithEvents btnEmploymentEdit As System.Windows.Forms.Button
    Friend WithEvents dtpEmploymentToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEmploymentFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEmploymentToDate As System.Windows.Forms.Label
    Friend WithEvents lblEmploymentFromDate As System.Windows.Forms.Label
    Friend WithEvents chrCompanyAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrCompanyContactNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtEmploymentTaskAccomplishment As System.Windows.Forms.TextBox
    Friend WithEvents lblEmploymentTaskAccomplishment As System.Windows.Forms.Label
    Friend WithEvents txtEmploymentCompanyAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblEmploymentCompanyAddress As System.Windows.Forms.Label
    Friend WithEvents txtMonthlySalary As System.Windows.Forms.TextBox
    Friend WithEvents lblMonthlySalary As System.Windows.Forms.Label
    Friend WithEvents txtEmploymentContactNo As System.Windows.Forms.TextBox
    Friend WithEvents lblEmploymentContactNo As System.Windows.Forms.Label
    Friend WithEvents txtEmploymentCompanyName As System.Windows.Forms.TextBox
    Friend WithEvents lblEmploymentCompanyName As System.Windows.Forms.Label
    Friend WithEvents txtEmploymentPosition As System.Windows.Forms.TextBox
    Friend WithEvents lblEmploymentPosition As System.Windows.Forms.Label
    Friend WithEvents btnOrganizationEdit As System.Windows.Forms.Button
    Friend WithEvents btnOrganizationDelete As System.Windows.Forms.Button
    Friend WithEvents btnOrganizationClear As System.Windows.Forms.Button
    Friend WithEvents btnOrganizationAdd As System.Windows.Forms.Button
    Friend WithEvents lvwOrganization As System.Windows.Forms.ListView
    Friend WithEvents chrOrganizationSinceDt As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrOrganizationPosition As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrOrganizationName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrOrganizationAddress As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSeminarEdit As System.Windows.Forms.Button
    Friend WithEvents btnSeminarDelete As System.Windows.Forms.Button
    Friend WithEvents btnSeminarClear As System.Windows.Forms.Button
    Friend WithEvents btnSeminarAdd As System.Windows.Forms.Button
    Friend WithEvents lvwSeminarsAttended As System.Windows.Forms.ListView
    Friend WithEvents chrSeminarName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSeminarLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSeminarDate As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSeminarRemarks As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtOrganizationPosition As System.Windows.Forms.TextBox
    Friend WithEvents lblOrganizationPosition As System.Windows.Forms.Label
    Friend WithEvents txtOrganizationName As System.Windows.Forms.TextBox
    Friend WithEvents lblOrganizationName As System.Windows.Forms.Label
    Friend WithEvents dtpOrganizationSinceDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOrganizationSinceDt As System.Windows.Forms.Label
    Friend WithEvents txtOrganizationAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblOrganizationAddress As System.Windows.Forms.Label
    Friend WithEvents txtSeminarRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblSeminarRemarks As System.Windows.Forms.Label
    Friend WithEvents txtSeminarLocation As System.Windows.Forms.TextBox
    Friend WithEvents lblSeminarLocation As System.Windows.Forms.Label
    Friend WithEvents txtSeminarName As System.Windows.Forms.TextBox
    Friend WithEvents lblSeminarName As System.Windows.Forms.Label
    Friend WithEvents dtpSeminarDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSeminarDate As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtDepartmentId As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmnuCapture As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblSuffixName As System.Windows.Forms.Label
    Friend WithEvents txtSuffixName As System.Windows.Forms.TextBox
    Friend WithEvents txtLGUId As System.Windows.Forms.TextBox
    Friend WithEvents txtLGUName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents mtxtTINo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtSSSNo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtxtPhilHealthNo As System.Windows.Forms.MaskedTextBox
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents cboStatusAppointment As System.Windows.Forms.ComboBox
    Friend WithEvents lblStatusofAppointment As System.Windows.Forms.Label
    Friend WithEvents txtReferredByID As System.Windows.Forms.TextBox
    Friend WithEvents txtReferredBy As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblReferredBy As System.Windows.Forms.Label
    Friend WithEvents cboAppointmentId As System.Windows.Forms.ComboBox
    Friend WithEvents cboQualificationId As System.Windows.Forms.ComboBox
    Friend WithEvents cboQualification As System.Windows.Forms.ComboBox
    Friend WithEvents lblQualification As System.Windows.Forms.Label
    Friend WithEvents txtSalary As System.Windows.Forms.TextBox
    Friend WithEvents lblSalaryAmount As System.Windows.Forms.Label
    Friend WithEvents chkRetireFl As System.Windows.Forms.CheckBox
    Friend WithEvents chkReplaceFl As System.Windows.Forms.CheckBox
    Friend WithEvents chkReassignFl As System.Windows.Forms.CheckBox
    Friend WithEvents dtpOathDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblOathDt As System.Windows.Forms.Label
    Friend WithEvents dtpAppointmentDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAppointmentDt As System.Windows.Forms.Label
    Friend WithEvents tpgFamilyBackground As System.Windows.Forms.TabPage
    Friend WithEvents tpgChildren As System.Windows.Forms.TabPage
    Friend WithEvents tpgOtherBeneficiary As System.Windows.Forms.TabPage
    Friend WithEvents dtpMembershipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCGMEADateMembered As System.Windows.Forms.Label
    Friend WithEvents txtBeneficiaryRelation As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberRelation As System.Windows.Forms.Label
    Friend WithEvents txtBeneficiaryFName As System.Windows.Forms.TextBox
    Friend WithEvents lblbeneficiaryName As System.Windows.Forms.Label
    Friend WithEvents btnBeneficiaryEdit As System.Windows.Forms.Button
    Friend WithEvents btnBeneficiaryDelete As System.Windows.Forms.Button
    Friend WithEvents btnBeneficiaryClear As System.Windows.Forms.Button
    Friend WithEvents btnBeneficiaryAdd As System.Windows.Forms.Button
    Friend WithEvents lvwOtherBeneficiary As System.Windows.Forms.ListView
    Friend WithEvents chrBeneficiaryFName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrBeneficiaryRelation As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwChildren As System.Windows.Forms.ListView
    Friend WithEvents chrChildFName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrChildMName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrChildLName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrChildSuffix As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrChildBirth As System.Windows.Forms.ColumnHeader
    Friend WithEvents dtpChildBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblChildBirthDate As System.Windows.Forms.Label
    Friend WithEvents txtChildSuffix As System.Windows.Forms.TextBox
    Friend WithEvents lblChildSuffix As System.Windows.Forms.Label
    Friend WithEvents txtChildLName As System.Windows.Forms.TextBox
    Friend WithEvents lblChildLName As System.Windows.Forms.Label
    Friend WithEvents txtChildMName As System.Windows.Forms.TextBox
    Friend WithEvents lblChildMName As System.Windows.Forms.Label
    Friend WithEvents txtChildFName As System.Windows.Forms.TextBox
    Friend WithEvents lblChildFName As System.Windows.Forms.Label
    Friend WithEvents btnChildDelete As System.Windows.Forms.Button
    Friend WithEvents btnChildEdit As System.Windows.Forms.Button
    Friend WithEvents btnChildAdd As System.Windows.Forms.Button
    Friend WithEvents btnChildClear As System.Windows.Forms.Button
    Friend WithEvents dtpSpouseBirth As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSpouseBirthdate As System.Windows.Forms.Label
    Friend WithEvents txtSpouseSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSpouseLName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSpouseMName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSpouseFName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFatherName As System.Windows.Forms.Label
    Friend WithEvents txtFatherSuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtFatherLName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtFatherMName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtFatherFName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblSpouseName As System.Windows.Forms.Label
    Friend WithEvents lblMother As System.Windows.Forms.Label
    Friend WithEvents txtMotherLName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMotherMName As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMotherFName As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lvwFamilyBackground As System.Windows.Forms.ListView
    Friend WithEvents chrSpouseFName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSpouseMName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSpouseLName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSpouseSuffix As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrSpouseBirthdate As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnFamilyDelete As System.Windows.Forms.Button
    Friend WithEvents btnFamilyEdit As System.Windows.Forms.Button
    Friend WithEvents btnFamilyAdd As System.Windows.Forms.Button
    Friend WithEvents btnFamilyClear As System.Windows.Forms.Button
    Friend WithEvents chrFatherFName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrFatherMName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrFatherLName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrMotherFName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrMotherLName As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBeneficiarySuffix As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBeneficiaryLName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtBeneficiaryMName As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chrBeneficiaryMName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrBeneficiaryLName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chrBeneficiarySuffix As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblMember As System.Windows.Forms.Label
    Friend WithEvents chkMember As System.Windows.Forms.CheckBox
    Friend WithEvents chrChildAge As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboChildStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblChildStatus As System.Windows.Forms.Label
    Friend WithEvents chrChildStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmsPreview As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PrintMemberProfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEmployeeId As System.Windows.Forms.TextBox
    Friend WithEvents lblEmployeeId As System.Windows.Forms.Label
End Class
