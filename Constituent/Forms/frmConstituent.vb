Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmConstituent
    Inherits System.Windows.Forms.Form

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsConstituent As New Constituents.Constituents
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmConstituentFinder
    Private WithEvents frmUseConstituentFinder As frmConstituentFinder
    Private cboNationalityId As New ComboBox
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColConstituent As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    'Declaration of SQL Related functions
    Private dsCountry As DataSet
    Private dsRegion As DataSet
    Private dsProvince As DataSet
    Private dsMunicipal As DataSet
    Private dsBarangay As DataSet
    Private dsZipCode As DataSet

    Private KeyPressChar As Long

#Region "frmConstituent Main Form Private Sub"

    Private Sub frmConstituent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsConstituent.Init_Flag = RecordId
            clsConstituent.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmConstituent_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtFirstName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmConstituent_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmConstituent_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, cboBarangay.KeyPress, cboCivilStatus.KeyPress, cboCountryId.KeyPress, cboCountryName.KeyPress, _
    cboGender.KeyPress, cboMcode.KeyPress, cboMunicipality.KeyPress, cboPcode.KeyPress, cboProvince.KeyPress, cboRcode.KeyPress, cboRegion.KeyPress, cboRurcode.KeyPress, cboZipCode.KeyPress, cboZipCodeArea.KeyPress, cboZipCodeId.KeyPress, _
    dtpBirthDate.KeyPress, txtBirthPlace.KeyPress, txtEmailAddress.KeyPress, txtFaxNo.KeyPress, txtFirstName.KeyPress, txtHomeAddress.KeyPress, txtHomeTel.KeyPress, txtLastName.KeyPress, txtMiddleName.KeyPress, _
    txtMobileNo.KeyPress, txtConstituentRemarks.KeyPress, txtSpouseContactNo.KeyPress, txtSpouseId.KeyPress, txtSpouseName.KeyPress, txtWorkTel.KeyPress, txtStructureNo.KeyPress, txtPermanentHomeAddress.KeyPress, txtBillingAddress.KeyPress, txtSuffixName.KeyPress, cboConstituentType.KeyPress, cboNationality.KeyPress
        Dim tbArgs As ToolBarButtonClickEventArgs

        KeyPressChar = e.KeyChar.GetHashCode
        Select Case KeyPressChar
            Case 65537 ' press crtl+a
                If Me.tbrMainForm.Buttons(0).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(0))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 327685 'press crtl+e
                If Me.tbrMainForm.Buttons(1).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(1))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 262148 'press crtl+d
                If Me.tbrMainForm.Buttons(2).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(2))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                    Exit Sub
                End If
            Case 393222 'press crtl+f
                If Me.tbrMainForm.Buttons(3).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(3))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1245203 'press crtl+s
                If Me.tbrMainForm.Buttons(4).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(4))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1769499 ' press esc
                If Me.tbrMainForm.Buttons(5).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(5))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
        End Select

    End Sub

#End Region

#Region "frmConstituent ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmConstituent As New frmConstituent
                    frmTitle = "Constituent"
                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColConstituent)
                        Set_Form_State()
                        cboConstituentType.SelectedIndex = 0
                        cboGender.SelectedIndex = 0
                        cboCivilStatus.SelectedIndex = 0
                        cboRegion.SelectedIndex = 0
                        cboCountryName.Text = clsConstituent.GetDefaultParameter("country")
                        cboRegion.SelectedIndex = cboRcode.Items.IndexOf(clsConstituent.GetDefaultParameter("rcode"))
                        'cboProvince.SelectedIndex = cboPcode.Items.IndexOf(clsConstituent.GetDefaultParameter("pcode"))
                        'cboMunicipality.SelectedIndex = cboMcode.Items.IndexOf(clsConstituent.GetDefaultParameter("mcode"))
                        RecordId = 0
                        ClearImage()
                        Initialize_AutoComplete()
                        Me.Text = "Constituent"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmConstituent = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmConstituent.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColConstituent)
                            Set_Form_State()
                            cboConstituentType.SelectedIndex = 0
                            cboGender.SelectedIndex = 0
                            cboCivilStatus.SelectedIndex = 0
                            cboRegion.SelectedIndex = 0
                            cboCountryName.Text = clsConstituent.GetDefaultParameter("country")
                            cboRegion.SelectedIndex = cboRcode.Items.IndexOf(clsConstituent.GetDefaultParameter("rcode"))
                            'cboProvince.SelectedIndex = cboPcode.Items.IndexOf(clsConstituent.GetDefaultParameter("pcode"))
                            'cboMunicipality.SelectedIndex = cboMcode.Items.IndexOf(clsConstituent.GetDefaultParameter("mcode"))
                            RecordId = 0
                            ClearImage()
                            Initialize_AutoComplete()
                            Me.Text = "Constituent"
                        End If
                    End If
                Case 1 'edit
edit_rec:
                    State = EDIT_STATE
                    Set_Form_State()
                Case 2 'delete
delete_rec:
                    If chkActiveFl.CheckState = CheckState.Unchecked Then
                        clsCommon.Prompt_User("information", "The current constituent record has already been set inactive.")
                        Exit Sub
                    Else
                        Dim iAns
                        iAns = clsCommon.Prompt_User("question", MSGBOX_INACTIVE_CONFIRMATION)
                        If iAns = vbYes Then
                            With clsConstituent
                                .constituent_Id = RecordId
                                .Updated_By = gUserID
                                If .Delete_Record() Then
                                    Me.Close()
                                End If
                            End With
                        End If
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmConstituentFinder
                        frmTitle = "Constituent Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtFirstName.Focus()
                        Else
                            frmFinder = New frmConstituentFinder
                            With frmFinder
                                .Constituent_Id = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        With clsConstituent
                            .constituent_Id = RecordId
                            ._constituentType = IIf(Len(cboConstituentType.Text) = 0, "Not Specified", cboConstituentType.Text)
                            .first_Name = Trim(txtFirstName.Text)
                            .middle_Name = Trim(txtMiddleName.Text)
                            .last_Name = Trim(txtLastName.Text)
                            .suffix_Name = Trim(txtSuffixName.Text)
                            .TempBirth_Date = dtpBirthDate.Value
                            .Birth_Place = Trim(txtBirthPlace.Text)
                            .Constituent_Gender = IIf(Len(cboGender.Text) = 0, "Not Specified", cboGender.Text)
                            .Civil_Status = IIf(Len(cboCivilStatus.Text) = 0, "Not Specified", cboCivilStatus.Text)
                            .Constituent_Nationality = Trim(cboNationality.Text)
                            .Household_No = Trim(txtStructureNo.Text)
                            .Constituent_Address = Trim(txtHomeAddress.Text)
                            .ConstituentPermanent_Address = Trim(txtPermanentHomeAddress.Text)
                            .ConstituentBilling_Address = Trim(txtBillingAddress.Text)
                            .Country_Id = IIf((Len(cboCountryId.Text.Replace(",", "")) = 0), 0, Val(cboCountryId.Text.Replace(",", "")))
                            .R_Code = IIf(Len(cboRcode.Text) = 0, "00", cboRcode.Text)
                            .P_Code = IIf(Len(cboPcode.Text) = 0, "0000", cboPcode.Text)
                            .M_Code = IIf(Len(cboMcode.Text) = 0, "000000", cboMcode.Text)
                            .Rur_Code = IIf(Len(cboRurcode.Text) = 0, "000000000", cboRurcode.Text)
                            .ZipCode_Id = IIf((Len(cboZipCodeId.Text.Replace(",", "")) = 0), 0, Val(cboZipCodeId.Text.Replace(",", "")))
                            .HomeTel_No = Trim(txtHomeTel.Text)
                            .WorkTel_No = Trim(txtWorkTel.Text)
                            .Fax_No = Trim(txtFaxNo.Text)
                            .Mobile_No = Trim(txtMobileNo.Text)
                            .Email_Address = Trim(txtEmailAddress.Text)
                            .spouse_Id = IIf((Len(txtSpouseId.Text.Replace(",", "")) = 0), 0, Val(txtSpouseId.Text.Replace(",", "")))
                            .SpouseContact_No = Trim(txtSpouseContactNo.Text)
                            .Constituent_Remarks = Trim(txtConstituentRemarks.Text)
                            .Active_Fl = chkActiveFl.CheckState
                            .constituent_Photo = Trim(txtFileName.Text)
                            ._taxIdNo = Trim(mtxtTINo.Text)
                            If dtpBirthDate.Checked Then
                                .birth_Fl = 1
                            Else
                                .birth_Fl = 0
                            End If

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = .constituent_Id
                                Set_Form_State()
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Constituent - " & IIf(LCase(cboConstituentType.Text) = "individual", txtLastName.Text & IIf(Len(txtSuffixName.Text) > 0, " " & txtSuffixName.Text, "") & ", " & txtFirstName.Text & IIf(Len(txtMiddleName.Text) > 0, " " & txtMiddleName.Text, ""), txtFirstName.Text)

                                If clsCommon.GetRegistrySetting("Add New Record", "Disabled") = "" Then
                                    Dim iAns
                                    iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to add another record?" & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                                    If iAns = vbYes Then
                                        GoTo add_rec
                                    ElseIf iAns = vbCancel Then
                                        clsCommon.SaveRegistrySetting("Add New Record", "Disabled", "Yes")
                                    End If
                                End If
                            Else
                                If State = EDIT_STATE Then
                                    .Init_Flag = RecordId
                                    If .Selected_Record() Then
                                        Assign_Data()
                                    End If
                                End If
                            End If
                        End With
                        Me.Cursor = Arrow
                    Else
                        Me.txtFirstName.Focus()
                    End If
                Case 5 'cancel
cancel_rec:
                    Me.Close()
            End Select
            '------------------------------------------------------------------------------
        Else
            'form KeyPress
            '------------------------------------------------------------------------------
            Select Case KeyPressChar
                Case 65537 ' press crtl+a
                    GoTo add_rec
                Case 327685 'press crtl+e
                    GoTo edit_rec
                Case 262148 'press crtl+d
                    GoTo delete_rec
                Case 393222 'press crtl+f
                    GoTo find_rec
                Case 1245203 'press crtl+s
                    GoTo save_rec
                Case 1769499 ' press esc
                    GoTo cancel_rec
            End Select
            '------------------------------------------------------------------------------
        End If

    End Sub

#End Region

#Region "frmConstituent User Defined Private Sub"

    Private Sub Initialize_Form()
        With clsConstituent
            dsCountry = .GetCountryList
            clsCommon.PopulateComboBox(cboCountryId, cboCountryName, dsCountry)

            dsRegion = .GetRegionList
            clsCommon.PopulateComboBox(cboRcode, cboRegion, dsRegion, Nothing, True)
        End With

        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        cboConstituentType.SelectedIndex = 0
        cboRegion.SelectedIndex = 0
        cboCountryName.Text = clsConstituent.GetDefaultParameter("country")
        cboRegion.SelectedIndex = cboRcode.Items.IndexOf(clsConstituent.GetDefaultParameter("rcode"))
        'cboProvince.SelectedIndex = cboPcode.Items.IndexOf(clsConstituent.GetDefaultParameter("pcode"))
        'cboMunicipality.SelectedIndex = cboMcode.Items.IndexOf(clsConstituent.GetDefaultParameter("mcode"))
        Initialize_AutoComplete()
        Me.Text = "Constituent"
        Me.txtFirstName.Focus()
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsConstituent
            dataCombo = .GetNationality

            clsCommon.PopulateComboBox(cboNationalityId, cboNationality, dataCombo)
        End With
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(cboBarangay)
            .Add(cboCivilStatus)
            .Add(cboCountryId)
            .Add(cboConstituentType)
            .Add(cboCountryName)
            .Add(cboGender)
            .Add(cboMcode)
            .Add(cboMunicipality)
            .Add(cboNationality)
            .Add(cboNationalityId)
            .Add(cboPcode)
            .Add(cboProvince)
            .Add(cboRcode)
            .Add(cboRegion)
            .Add(cboRurcode)
            .Add(cboZipCodeArea)
            .Add(cboZipCodeId)
            .Add(dtpBirthDate)
            .Add(txtBirthPlace)
            .Add(txtEmailAddress)
            .Add(txtFaxNo)
            .Add(txtFirstName)
            .Add(txtHomeAddress)
            .Add(txtPermanentHomeAddress)
            .Add(txtBillingAddress)
            .Add(txtStructureNo)
            .Add(txtHomeTel)
            .Add(txtLastName)
            .Add(txtMiddleName)
            .Add(txtSuffixName)
            .Add(txtMobileNo)
            .Add(txtConstituentRemarks)
            .Add(txtSpouseContactNo)
            .Add(txtSpouseName)
            .Add(txtSpouseId)
            .Add(txtWorkTel)
            '.Add(btnPicture)
            .Add(mtxtTINo)
            If State <> ADD_STATE Then
                .Add(chkActiveFl)
            End If

            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColConstituent
            .Add(cboNationality)
            .Add(cboNationalityId)
            .Add(txtBirthPlace)
            .Add(txtEmailAddress)
            .Add(txtFaxNo)
            .Add(txtFirstName)
            .Add(txtHomeAddress)
            .Add(txtPermanentHomeAddress)
            .Add(txtBillingAddress)
            .Add(txtStructureNo)
            .Add(dtpBirthDate)
            .Add(txtHomeTel)
            .Add(txtLastName)
            .Add(txtMiddleName)
            .Add(txtSuffixName)
            .Add(txtMobileNo)
            .Add(txtConstituentRemarks)
            .Add(txtSpouseContactNo)
            .Add(txtSpouseName)
            .Add(txtSpouseId)
            .Add(txtWorkTel)
            .Add(chkActiveFl)
            .Add(mtxtTINo)

            .Add(txtUpdateDt)
        End With

        clsCommon.ClearControls(ColConstituent)
        Define_Required_Fields()
        Me.Text = "Constituent"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblSpouseName)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        ColRequired = New Collection
        With ColRequired
            .Add(txtFirstName)
            If cboConstituentType.SelectedIndex = 0 Then
                .Add(txtLastName)
                Me.txtFirstName.Tag = "First Name"
                Me.txtLastName.Tag = "Last Name"
            Else
                Me.txtFirstName.Tag = "Company Name"
                Me.txtLastName.Tag = "Other Name"
            End If
        End With
    End Sub

    Private Sub Assign_Data()
        With clsConstituent
            Me.cboCountryId.Text = .Country_Id
            Me.cboCountryName.SelectedIndex = Me.cboCountryId.SelectedIndex

            Me.cboRcode.Text = .R_Code
            Me.cboRegion.SelectedIndex = Me.cboRcode.SelectedIndex

            dsProvince = .GetProvinceList
            clsCommon.PopulateComboBox(cboPcode, cboProvince, dsProvince)
            Me.cboPcode.Text = .P_Code
            Me.cboProvince.SelectedIndex = Me.cboPcode.SelectedIndex

            dsMunicipal = .GetMunicipalityList()
            clsCommon.PopulateComboBox(cboMcode, cboMunicipality, dsMunicipal)
            Me.cboMcode.Text = .M_Code
            Me.cboMunicipality.SelectedIndex = Me.cboMcode.SelectedIndex

            dsBarangay = .GetBarangayList()
            clsCommon.PopulateComboBox(cboRurcode, cboBarangay, dsBarangay)
            Me.cboRurcode.Text = .Rur_Code
            Me.cboBarangay.SelectedIndex = Me.cboRurcode.SelectedIndex

            dsZipCode = .GetZipCodeList
            clsCommon.PopulateComboBox(cboZipCodeId, cboZipCodeArea, dsZipCode, cboZipCode)
            Me.cboZipCodeId.Text = .ZipCode_Id
            Me.cboZipCodeArea.SelectedIndex = Me.cboZipCodeId.SelectedIndex
            Me.cboZipCode.SelectedIndex = Me.cboZipCodeId.SelectedIndex

            Me.cboConstituentType.Text = ._constituentType
            Me.txtFirstName.Text = .first_Name
            Me.txtMiddleName.Text = .middle_Name
            Me.txtLastName.Text = .last_Name
            Me.txtSuffixName.Text = .suffix_Name
            Me.dtpBirthDate.Value = .Birth_Date
            Me.dtpBirthDate.Checked = (.birth_Fl = 1)
            Me.txtBirthPlace.Text = .Birth_Place
            Me.cboGender.Text = .Constituent_Gender
            Me.cboCivilStatus.Text = .Civil_Status
            Me.cboNationality.Text = .Constituent_Nationality
            Me.txtStructureNo.Text = .Household_No
            Me.txtHomeAddress.Text = .Constituent_Address
            Me.txtPermanentHomeAddress.Text = .ConstituentPermanent_Address
            Me.txtBillingAddress.Text = .ConstituentBilling_Address
            Me.txtHomeTel.Text = .HomeTel_No
            Me.txtWorkTel.Text = .WorkTel_No
            Me.txtFaxNo.Text = .Fax_No
            Me.txtMobileNo.Text = .Mobile_No
            Me.txtEmailAddress.Text = .Email_Address
            Me.txtSpouseId.Text = .spouse_Id
            Me.txtSpouseName.Text = .Spouse_Name
            Me.txtSpouseContactNo.Text = .SpouseContact_No
            Me.txtConstituentRemarks.Text = .Constituent_Remarks
            Me.chkActiveFl.CheckState = .Active_Fl
            Me.mtxtTINo.Text = ._taxIdNo
            Me.txtFileName.Text = .constituent_Photo

            If File.Exists(txtFileName.Text) Then
                Dim image1, imageCopy As Bitmap
                image1 = Bitmap.FromFile(txtFileName.Text)
                imageCopy = image1.Clone
                btnPicture.BackgroundImage = imageCopy
                btnPicture.BackgroundImageLayout = ImageLayout.Zoom
                cmnuClear.Enabled = True
            Else
                ClearImage()
                cmnuClear.Enabled = False
            End If

            If dtpBirthDate.Checked Then
                lblAge.ForeColor = Color.Black
                lblAge.Text = "( " & clsCommon.GetAge(dtpBirthDate.Value.Date) & " )"
            Else
                lblAge.ForeColor = Color.Red
                lblAge.Text = "( - )"
            End If

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .constituent_Id
        End With
        Me.txtFirstName.Focus()

        Me.Text = "Constituent - " & IIf(LCase(cboConstituentType.Text) = "individual", txtLastName.Text & IIf(Len(txtSuffixName.Text) > 0, " " & txtSuffixName.Text, "") & ", " & txtFirstName.Text & IIf(Len(txtMiddleName.Text) > 0, " " & txtMiddleName.Text, ""), txtFirstName.Text)
    End Sub

    Private Sub Set_Permission()
        With clsPermission
            .Role_ID = gRoleID
            .Form_Name = Me.Name
            .SetPermission()
            Add_Permission = .Add_Permission
            Delete_Permission = .Delete_Permission
            Edit_Permission = .Edit_Permission
            View_Permission = .View_Permission
            Approve_Permission = .Approve_Permission
        End With
    End Sub

    Private Sub Disposed_Class()
        clsConstituent = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColConstituent = Nothing
        If Directory.Exists(ImageDir) Then
            Try
                For Each fName As String In Directory.GetFiles(ImageDir)
                    If File.Exists(fName) Then
                        File.Delete(fName)
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub Set_Form_State()
        Define_Display()
        Define_Pipe_Fields()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            If cboConstituentType.SelectedIndex = 0 Then
                lblFirstName.Text = "First Name"
                lblLastName.Text = "Last Name"
                lblBirthDate.Text = "Birth Date"
                lblSpouseName.Text = "Spouse Name"
                Label1.Text = "Spouse Name"
                txtFirstName.Width = 200
                txtLastName.Width = 200
            Else
                lblFirstName.Text = "Company Name"
                lblLastName.Text = "Other Name"
                lblBirthDate.Text = "Date Established"
                lblSpouseName.Text = "Contact Name"
                Label1.Text = "Contact Name"
                txtFirstName.Width = 520
                txtLastName.Width = 520
            End If
        Else
            If cboConstituentType.SelectedIndex = 0 Then
                lblFirstName.Text = "First Name *"
                lblLastName.Text = "Last Name *"
                lblBirthDate.Text = "Birth Date"
                lblSpouseName.Text = "Spouse Name"
                lblSpouseName.Text = "Spouse Name"
                txtFirstName.Width = 200
                txtLastName.Width = 200
            Else
                lblFirstName.Text = "Company Name *"
                lblLastName.Text = "Other Name"
                lblBirthDate.Text = "Date Established"
                lblSpouseName.Text = "Contact Name"
                Label1.Text = "Contact Name"
                txtFirstName.Width = 520
                txtLastName.Width = 520
            End If
        End If
        Me.Refresh()
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsConstituent.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtFirstName.Tag = "First Name"
        Me.txtLastName.Tag = "Last Name"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtBirthPlace.MaxLength = 255
        Me.txtEmailAddress.MaxLength = 255
        Me.txtFaxNo.MaxLength = 255
        Me.txtFirstName.MaxLength = 255
        Me.txtHomeAddress.MaxLength = 2000
        Me.txtPermanentHomeAddress.MaxLength = 2000
        Me.txtBillingAddress.MaxLength = 2000
        Me.txtHomeTel.MaxLength = 255
        Me.txtStructureNo.MaxLength = 255
        Me.txtLastName.MaxLength = 255
        Me.txtMiddleName.MaxLength = 100
        Me.txtSuffixName.MaxLength = 45
        Me.txtMobileNo.MaxLength = 255
        Me.cboNationality.MaxLength = 100
        Me.txtConstituentRemarks.MaxLength = 2000
        Me.txtSpouseContactNo.MaxLength = 255
        'Me.txtSpouseName.MaxLength = 255
        Me.txtWorkTel.MaxLength = 255
        'Me.txtTIN.MaxLength = 45
    End Sub

    Private Sub txtSpouseName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSpouseName.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.DisAllow_Input(e)
        End If
    End Sub

    Private Sub txtSpouseName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSpouseName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtSpouseId, e)
            clsCommon.Delete_TxtBox_Value(txtSpouseName, e)
        End If
    End Sub

    Private Sub txtSpouseNametxtReceiptName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSpouseName.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

    Private Sub cboNationality_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboNationality.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.CapitalizeKeyPressString(e)
        End If
    End Sub

    Private Sub dtpBirthDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBirthDate.ValueChanged, dtpBirthDate.Leave
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        'Dim intAge As Integer = CInt(clsCommon.GetAge(dtpBirthDate.Value.Date))

        If dtpBirthDate.Checked Then
            lblAge.ForeColor = Color.Black
            lblAge.Text = "( " & clsCommon.GetAge(dtpBirthDate.Value.Date) & " )"
        Else
            lblAge.ForeColor = Color.Red
            lblAge.Text = "( - )"
        End If
        'If intAge < 100 And intAge > 0 Then
        '    lblAge.Text = "( " & clsCommon.GetAge(dtpBirthDate.Value.Date) & " )"
        'ElseIf intAge < 0 Then
        '    lblAge.Text = "( - )"
        'ElseIf intAge > 100 Then
        '    lblAge.Text = "( 100+ )"
        'End If
    End Sub

    Private Sub cboConstituentType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboConstituentType.SelectedIndexChanged
        If State <> VIEW_STATE Then
            Define_Required_Fields()
        End If
        Set_Form_State()
    End Sub

    Private Sub cboCountryName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCountryName.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboCountryId.SelectedIndex = cboCountryName.SelectedIndex
        End If
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboRcode.SelectedIndex = cboRegion.SelectedIndex
            With clsConstituent
                .R_Code = cboRcode.Text
                dsProvince = .GetProvinceList
                clsCommon.PopulateComboBox(cboPcode, cboProvince, dsProvince, Nothing, True)
            End With
            cboProvince.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboProvince_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvince.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboPcode.SelectedIndex = cboProvince.SelectedIndex
            With clsConstituent
                .P_Code = cboPcode.Text
                dsMunicipal = .GetMunicipalityList
                clsCommon.PopulateComboBox(cboMcode, cboMunicipality, dsMunicipal, Nothing, True)
            End With
            cboMunicipality.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboMunicipality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMunicipality.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboMcode.SelectedIndex = cboMunicipality.SelectedIndex
            With clsConstituent
                .M_Code = cboMcode.Text
                dsBarangay = .GetBarangayList
                clsCommon.PopulateComboBox(cboRurcode, cboBarangay, dsBarangay, Nothing, True)

                dsZipCode = .GetZipCodeList
                clsCommon.PopulateComboBox(cboZipCodeId, cboZipCodeArea, dsZipCode, cboZipCode, True)
            End With
            cboBarangay.SelectedIndex = 0
            cboZipCodeArea.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboBarangay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBarangay.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboRurcode.SelectedIndex = cboBarangay.SelectedIndex
        End If
    End Sub

    Private Sub cboZipCodeArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZipCodeArea.SelectedIndexChanged
        If State <> VIEW_STATE Then
            Me.cboZipCodeId.SelectedIndex = Me.cboZipCodeArea.SelectedIndex
            Me.cboZipCode.SelectedIndex = Me.cboZipCodeArea.SelectedIndex
        End If
    End Sub

    Private Sub cboProvince_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvince.TextChanged, cboMunicipality.TextChanged, cboBarangay.TextChanged
        If State <> VIEW_STATE Then
            txtPermanentHomeAddress.Text = IIf(Len(cboBarangay.Text) > 0, cboBarangay.Text, "") & IIf(Len(cboMunicipality.Text) > 0, ", " & cboMunicipality.Text, "") & IIf(Len(cboProvince.Text) > 0, ", " & cboProvince.Text, "")
        End If
    End Sub

    Private Sub btnPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicture.Click
        If State = VIEW_STATE Then
            If File.Exists(txtFileName.Text) Then
                Dim ps As New ProcessStartInfo
                With ps
                    .FileName = txtFileName.Text
                    .UseShellExecute = True
                End With

                Dim p As New Process
                p.StartInfo = ps
                p.Start()
            End If
        Else
            Dim cdlOpen As New OpenFileDialog

            cdlOpen.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png) | *.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png | All Files | *.*"

            cdlOpen.ShowDialog()

            If File.Exists(cdlOpen.FileName) Then
                txtFileName.Text = cdlOpen.FileName
                Dim image1 As Bitmap = New Bitmap(cdlOpen.FileName)
                btnPicture.BackgroundImage = image1
                btnPicture.BackgroundImageLayout = ImageLayout.Zoom
                cmnuClear.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnPicture_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPicture.MouseUp
        cmnuClear.Enabled = (State <> VIEW_STATE And File.Exists(txtFileName.Text))
        cmnuCapture.Enabled = False
        If State <> VIEW_STATE Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                cmnuCapture.Enabled = clsCommon.IsImageCaptureAvailable
            End If
        End If
    End Sub

    Private Sub cmnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuClear.Click
        ClearImage()
        cmnuClear.Enabled = False
    End Sub

    Private Sub cmnuCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuCapture.Click
        If State <> VIEW_STATE Then
            Dim image1 As Bitmap = clsCommon.CaptureImagetoBMP

            If Not image1 Is Nothing Then
                txtFileName.Text = ImageDir & "\" & Now.TimeOfDay.TotalMilliseconds & ".jpg"
                image1.Save(txtFileName.Text, Imaging.ImageFormat.Jpeg)
                btnPicture.BackgroundImage = image1
                btnPicture.BackgroundImageLayout = ImageLayout.Zoom
                cmnuClear.Enabled = True
            End If
        End If
    End Sub

    Public Sub ClearImage()
        If State <> VIEW_STATE Then
            Dim image1 As Bitmap = New Bitmap(Me.GetType, "blank-user.gif")
            btnPicture.BackgroundImage = image1
            btnPicture.BackgroundImageLayout = ImageLayout.Zoom
            txtFileName.Text = ""
        End If
    End Sub

#End Region

#Region "frmConstituent Label Piping Click"

    Private Sub lblSpouseName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSpouseName.Click
        Try
            frmUseConstituentFinder = New frmConstituentFinder

            With frmUseConstituentFinder
                Use_Record_State = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "frmConstituent Handle Piping"

    Private Sub frmUseConstituentFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String, ByVal Record_Desc As String) Handles frmUseConstituentFinder.Use_Clicked
        If String.IsNullOrEmpty(Record_Name) OrElse String.IsNullOrEmpty(Record_Cd) Then
            Return
        End If

        With clsConstituent
            .Init_Flag = Record_Id
            .Selected_Record()

            txtSpouseId.Text = .constituent_Id
            txtSpouseName.Text = IIf((LCase(._constituentType) = "individual"), .last_Name & IIf(Len(.suffix_Name) > 0, " " & .suffix_Name, "") & ", " & .first_Name & " " & .middle_Name, .first_Name)
        End With
    End Sub

#End Region

End Class