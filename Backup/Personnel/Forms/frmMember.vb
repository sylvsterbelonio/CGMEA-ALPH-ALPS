Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmMember
    Inherits System.Windows.Forms.Form

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsMember As New Member.Member
    Private WithEvents clsLGU As New LGU.LGU
    Private WithEvents clsDepartment As New Department.Department
    Private WithEvents clsConstituent As New Constituent.Constituent(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsConstituents As Constituent.Constituents.Constituents
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private clsEducationalBackground As New MemberEducationalBackground.MemberEducationalBackground
    Private clsEmploymentHistory As New MemberEmploymentHistory.MemberEmploymentHistory
    Private clsOrganizations As New MemberOrganizations.MemberOrganizations
    Private clsSeminarsAttended As New MemberSeminarsAttended.MemberSeminarsAttended
    Private clsFamilyBackground As New MemberFamilyBackground.MemberFamilyBackground
    Private clsChildren As New MemberChildren.MemberChildren
    Private clsOtherBeneficiary As New MemberOtherBeneficiary.MemberOtherBeneficiary
    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    Private frmMemberDetailReportViewer As frmCrystalReportViewer

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmMemberFinder
    Private WithEvents frmUseLGUFinder As frmLGUFinder
    Private WithEvents frmUseDepartmentFinder As frmDepartmentFinder
    Private WithEvents frmUseConstituentFinder As Constituent.frmConstituentFinder = Nothing
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMember As New Collection
    Private colEducationalBackground As New Collection
    Private colEducationalBackgroundRequired As New Collection
    Private EducationalBackground As New Collection
    Private colEmploymentHistory As New Collection
    Private colEmploymentHistoryRequired As New Collection
    Private EmploymentHistory As New Collection
    Private colMemberOrganization As New Collection
    Private colMemberOrganizationRequired As New Collection
    Private MemberOrganization As New Collection
    Private colSeminarsAttended As New Collection
    Private colSeminarsAttendedRequired As New Collection
    Private SeminarsAttended As New Collection
    Private colFamilyBackground As New Collection
    Private colFamilyBackgroundRequired As New Collection
    Private FamilyBackground As New Collection
    Private colChildren As New Collection
    Private colChildrenRequired As New Collection
    Private Children As New Collection
    Private colOtherBeneficiary As New Collection
    Private colOtherBeneficiaryRequired As New Collection
    Private OtherBeneficiary As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    'Declaration of SQL Related functions
    Private dsJob As DataSet
    Private dsAppointment As DataSet
    Private dsRegion As DataSet
    Private dsProvince As DataSet
    Private dsMunicipal As DataSet
    Private dsBarangay As DataSet
    Private dsZipCode As DataSet
    Private dtListView As DataTable
    Private dtListViewRow As DataRow
    Private lvwEducationalBackgroundItem As ListViewItem = Nothing
    Private lvwEmploymentHistoryItem As ListViewItem = Nothing
    Private lvwMemberOrganizationItem As ListViewItem = Nothing
    Private lvwSeminarsAttendedItem As ListViewItem = Nothing
    Private lvwFamilyBackgroundItem As ListViewItem = Nothing
    Private lvwChildrenItem As ListViewItem = Nothing
    Private lvwOtherBeneficiaryItem As ListViewItem = Nothing

    Private KeyPressChar As Long

    Private Const MSGBOX_PIPING_USE_SELF = "Record used is not valid. Please select record other than self."
    Private Const MSGBOX_PIPING_USE_CHILD = "Record used is not valid. You can not set existing child record of this record as its parent record."
    Private Const MSGBOX_PIPING_USE_PARENT = "Record used is not valid. You can not set a record with child records as a new child record."
    Public Const MSGBOX_LISTVIEWITEM_DELETE = "Please select appropriate record to delete."
    Public Const MSGBOX_LISTVIEWITEM_EDIT = "Please select appropriate record to edit."

#Region "frmMember Main Form Private Sub"

    Private Sub frmMember_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        If State = Nothing Then
            State = VIEW_STATE
            Dim mydata As New DataTable
            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblsystemuser WHERE userId = '" & gUserID & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)
            If mydata.Rows.Count <> 0 Then
                RecordId = mydata.Rows(0).Item("memberId")
            End If
            Initialize_Form()
            tbrMainForm.Buttons.Item(0).Visible = False
            tbrMainForm.Buttons.Item(2).Visible = False
        Else
            Initialize_Form()
        End If
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsMember.Init_Flag = RecordId
            clsMember.Selected_Record()
            Assign_Data()
        End If

        Me.Cursor = Arrow
    End Sub

    Private Sub frmMember_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtMemberNo.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmMember_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmMember_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, cboBarangay.KeyPress, cboEducationalLevel.KeyPress, cboGender.KeyPress, cboJobId.KeyPress, cboJobTitle.KeyPress, cboMcode.KeyPress, cboMunicipality.KeyPress, cboPcode.KeyPress, cboProvince.KeyPress, cboRcode.KeyPress, cboRegion.KeyPress, cboRurcode.KeyPress, cboStatus.KeyPress, cboZipCode.KeyPress, cboZipCodeArea.KeyPress, cboZipCodeId.KeyPress, _
        txtBirthPlace.KeyPress, txtBloodType.KeyPress, txtCitizenship.KeyPress, txtDegreeCourse.KeyPress, txtDepartmentId.KeyPress, txtDepartmentName.KeyPress, txtEmailAddress.KeyPress, txtEmployeeId.KeyPress, txtMemberNo.KeyPress, txtEmploymentCompanyAddress.KeyPress, txtEmploymentCompanyName.KeyPress, txtEmploymentContactNo.KeyPress, txtEmploymentPosition.KeyPress, txtEmploymentTaskAccomplishment.KeyPress, txtFileName.KeyPress, txtFirstName.KeyPress, txtHeight.KeyPress, txtHighestGrade.KeyPress, _
        txtHomeAddress.KeyPress, txtHomeTel.KeyPress, txtHonors.KeyPress, txtLastName.KeyPress, txtLGUId.KeyPress, txtLGUName.KeyPress, txtMiddleName.KeyPress, txtMobileNo.KeyPress, txtMonthlySalary.KeyPress, txtNameofSchool.KeyPress, txtOrganizationAddress.KeyPress, txtOrganizationName.KeyPress, txtOrganizationPosition.KeyPress, txtPagibigIDNo.KeyPress, txtSeminarLocation.KeyPress, txtSeminarName.KeyPress, txtSeminarRemarks.KeyPress, txtSuffixName.KeyPress, txtWeight.KeyPress, _
        txtWorkTel.KeyPress, btnEducationalAdd.KeyPress, btnEducationalClear.KeyPress, btnEducationalDelete.KeyPress, btnEducationalEdit.KeyPress, btnEmploymentAdd.KeyPress, btnEmploymentClear.KeyPress, btnEmploymentDelete.KeyPress, btnEmploymentEdit.KeyPress, btnOrganizationAdd.KeyPress, btnOrganizationClear.KeyPress, btnOrganizationDelete.KeyPress, btnOrganizationEdit.KeyPress, btnSeminarAdd.KeyPress, btnSeminarClear.KeyPress, btnSeminarDelete.KeyPress, btnSeminarEdit.KeyPress, _
        lvwEducationalBackground.KeyPress, lvwEmploymentHistory.KeyPress, lvwOrganization.KeyPress, lvwSeminarsAttended.KeyPress, dtpBirthDate.KeyPress, dtpDateHired.KeyPress, dtpEducationalFromDate.KeyPress, dtpEducationalToDate.KeyPress, dtpEmploymentFromDate.KeyPress, dtpEmploymentToDate.KeyPress, dtpOrganizationSinceDt.KeyPress, dtpSeminarDate.KeyPress, mtxtPhilHealthNo.KeyPress, mtxtSSSNo.KeyPress, mtxtTINo.KeyPress, cboAppointmentId.KeyPress, cboStatusAppointment.KeyPress, _
        cboQualification.KeyPress, cboQualificationId.KeyPress, txtSalary.KeyPress, txtReferredBy.KeyPress, txtReferredByID.KeyPress, dtpAppointmentDt.KeyPress, dtpOathDt.KeyPress, _
        txtSpouseFName.KeyPress, txtSpouseMName.KeyPress, txtSpouseLName.KeyPress, dtpSpouseBirth.KeyPress, txtFatherFName.KeyPress, txtFatherMName.KeyPress, txtFatherLName.KeyPress, txtMotherFName.KeyPress, txtMotherMName.KeyPress, txtMotherLName.KeyPress, lvwFamilyBackground.KeyPress, btnFamilyAdd.KeyPress, btnFamilyClear.KeyPress, btnFamilyDelete.KeyPress, btnFamilyEdit.KeyPress, _
        txtChildFName.KeyPress, txtChildMName.KeyPress, txtChildLName.KeyPress, txtChildSuffix.KeyPress, dtpChildBirth.KeyPress, cboChildStatus.KeyPress, lvwChildren.KeyPress, btnChildAdd.KeyPress, btnChildClear.KeyPress, btnChildDelete.KeyPress, btnChildEdit.KeyPress, _
        txtBeneficiaryFName.KeyPress, txtBeneficiaryMName.KeyPress, txtBeneficiaryLName.KeyPress, txtBeneficiarySuffix.KeyPress, txtBeneficiaryRelation.KeyPress, lvwOtherBeneficiary.KeyPress, btnBeneficiaryAdd.KeyPress, btnBeneficiaryClear.KeyPress, btnBeneficiaryDelete.KeyPress, btnBeneficiaryEdit.KeyPress
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

#Region "frmMember ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmMember As New frmMember
                    frmTitle = "Member"
                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColMember)
                        clsCommon.ClearControls(colEducationalBackground)
                        clsCommon.ClearControls(colEmploymentHistory)
                        clsCommon.ClearControls(colmemberOrganization)
                        clsCommon.ClearControls(colSeminarsAttended)
                        clsCommon.ClearControls(colFamilyBackground)
                        clsCommon.ClearControls(colChildren)
                        clsCommon.ClearControls(colOtherBeneficiary)
                        lvwEducationalBackgroundItem = Nothing
                        lvwEmploymentHistoryItem = Nothing
                        lvwmemberOrganizationItem = Nothing
                        lvwSeminarsAttendedItem = Nothing
                        lvwFamilyBackgroundItem = Nothing
                        lvwChildrenItem = Nothing
                        lvwOtherBeneficiaryItem = Nothing
                        lvwEducationalBackground.Items.Clear()
                        lvwEmploymentHistory.Items.Clear()
                        lvwOrganization.Items.Clear()
                        lvwSeminarsAttended.Items.Clear()
                        lvwFamilyBackground.Items.Clear()
                        lvwChildren.Items.Clear()
                        lvwOtherBeneficiary.Items.Clear()
                        Set_Form_State()
                        Set_Default_Values()
                        RecordId = 0
                        Me.Text = "Member"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmMember = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmMember.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColMember)
                            clsCommon.ClearControls(colEducationalBackground)
                            clsCommon.ClearControls(colEmploymentHistory)
                            clsCommon.ClearControls(colmemberOrganization)
                            clsCommon.ClearControls(colSeminarsAttended)
                            clsCommon.ClearControls(colFamilyBackground)
                            clsCommon.ClearControls(colChildren)
                            clsCommon.ClearControls(colOtherBeneficiary)
                            lvwEducationalBackgroundItem = Nothing
                            lvwEmploymentHistoryItem = Nothing
                            lvwmemberOrganizationItem = Nothing
                            lvwSeminarsAttendedItem = Nothing
                            lvwFamilyBackgroundItem = Nothing
                            lvwChildrenItem = Nothing
                            lvwOtherBeneficiaryItem = Nothing
                            lvwEducationalBackground.Items.Clear()
                            lvwEmploymentHistory.Items.Clear()
                            lvwOrganization.Items.Clear()
                            lvwSeminarsAttended.Items.Clear()
                            lvwFamilyBackground.Items.Clear()
                            lvwChildren.Items.Clear()
                            lvwOtherBeneficiary.Items.Clear()
                            Set_Form_State()
                            Set_Default_Values()
                            RecordId = 0
                            Me.Text = "Member"
                        End If
                    End If
                Case 1 'edit
edit_rec:
                    State = EDIT_STATE
                    Set_Form_State()
                Case 2 'delete
delete_rec:
                    If chkActive.CheckState = CheckState.Unchecked Then
                        clsCommon.Prompt_User("information", "The current Member record has already been set inactive.")
                        Exit Sub
                    Else
                        If gRoleID <> 0 Then
                            frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
                            With frmLoginOverrideForm
                                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                    Dim iAns
                                    iAns = clsCommon.Prompt_User("question", MSGBOX_INACTIVE_CONFIRMATION)
                                    If iAns = vbYes Then
                                        With clsMember
                                            .Member_Id = RecordId
                                            .Updated_By = gUserID
                                            If .Delete_Record() Then
                                                Me.Close()
                                            End If
                                        End With
                                    End If
                                End If
                            End With
                        Else
                            Dim iAns
                            iAns = clsCommon.Prompt_User("question", MSGBOX_INACTIVE_CONFIRMATION)
                            If iAns = vbYes Then
                                With clsMember
                                    .Member_Id = RecordId
                                    .Updated_By = gUserID
                                    If .Delete_Record() Then
                                        Me.Close()
                                    End If
                                End With
                            End If
                        End If
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmMemberFinder
                        frmTitle = "Member Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtMemberName.Focus()
                        Else
                            frmFinder = New frmMemberFinder
                            With frmFinder
                                .Member_Id = 0
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
                        With clsMember
                            .Member_Id = RecordId
                            .Member_No = Trim(txtMemberNo.Text)
                            .lgu_Id = IIf((Len(txtLGUId.Text.Replace(",", "")) = 0), 0, Val(txtLGUId.Text.Replace(",", "")))
                            .Department_Id = IIf((Len(txtDepartmentId.Text.Replace(",", "")) = 0), 0, Val(txtDepartmentId.Text.Replace(",", "")))
                            .Referral_Id = IIf((Len(txtReferredByID.Text.Replace(",", "")) = 0), 0, Val(txtReferredByID.Text.Replace(",", "")))
                            .First_Name = Trim(txtFirstName.Text)
                            .Middle_Name = Trim(txtMiddleName.Text)
                            .Last_Name = Trim(txtLastName.Text)
                            ._suffixName = Trim(txtSuffixName.Text)
                            .Job_Description = Trim(cboJobTitle.Text)
                            .Appointment_Status = Trim(cboStatusAppointment.Text)
                            .Member_Qualification = Trim(cboQualification.Text)
                            .Salary_Amount = IIf((Len(txtSalary.Text.Replace(",", "")) = 0), 0, Val(txtSalary.Text.Replace(",", "")))
                            .Member_Photo = Trim(txtFileName.Text)
                            .Birth_Fl = IIf(dtpBirthDate.Checked, 1, 0)
                            .TempMemberBirth_Date = dtpBirthDate.Value
                            .Member_Gender = IIf(Len(cboGender.Text) = 0, "Not Specified", cboGender.Text)
                            .Marital_Status = IIf(Len(cboStatus.Text) = 0, "Not Specified", cboStatus.Text)
                            .Home_Address = txtHomeAddress.Text
                            .R_Code = IIf(Len(cboRcode.Text) = 0, "00", cboRcode.Text)
                            .P_Code = IIf(Len(cboPcode.Text) = 0, "0000", cboPcode.Text)
                            .M_Code = IIf(Len(cboMcode.Text) = 0, "000000", cboMcode.Text)
                            .Rur_Code = IIf(Len(cboRurcode.Text) = 0, "000000000", cboRurcode.Text)
                            .Zip_CodeId = IIf((Len(cboZipCodeId.Text.Replace(",", "")) = 0), 0, Val(cboZipCodeId.Text.Replace(",", "")))
                            .Sss_No = Trim(mtxtSSSNo.Text)
                            .Tax_IdNo = Trim(mtxtTINo.Text)
                            .Home_Tel = Trim(txtHomeTel.Text)
                            .Work_Tel = Trim(txtWorkTel.Text)
                            .Mobile_No = Trim(txtMobileNo.Text)
                            .Email_Address = Trim(txtEmailAddress.Text)
                            .Employee_Id = Trim(txtEmployeeId.Text)
                            .Hired_Fl = IIf(dtpDateHired.Checked, 1, 0)
                            .Tempdate_Hired = dtpDateHired.Value
                            .MemberBirth_Place = Trim(txtBirthPlace.Text)
                            .Member_Citizenship = Trim(txtCitizenship.Text)
                            .Member_Height = Trim(txtHeight.Text)
                            .Member_Weight = Trim(txtWeight.Text)
                            .MemberBlood_Type = Trim(txtBloodType.Text)
                            .PagibigID_No = Trim(txtPagibigIDNo.Text)
                            .PhilHealth_No = Trim(mtxtPhilHealthNo.Text)
                            .Active_Fl = chkActive.CheckState
                            .Member_Fl = chkMember.CheckState
                            .Appointment_Fl = IIf(dtpAppointmentDt.Checked, 1, 0)
                            .TempAppointment_Dt = dtpAppointmentDt.Value
                            .Oath_Fl = IIf(dtpOathDt.Checked, 1, 0)
                            .TempOath_Dt = dtpOathDt.Value
                            .CgmeaMembership_Fl = IIf(dtpMembershipDate.Checked, 1, 0)
                            .TempCgmeaMembership_Dt = dtpMembershipDate.Value

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            Populate_Collection()
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = .Member_Id
                                Set_Form_State()
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Member - " & txtLastName.Text & IIf(Len(txtSuffixName.Text) > 0, " " & txtSuffixName.Text, "") & ", " & txtFirstName.Text & IIf(Len(txtMiddleName.Text) > 0, " " & txtMiddleName.Text, "") & " (" & cboJobTitle.Text & ") - [" & txtDepartmentName.Text & "]"

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
                        Me.txtMemberNo.Focus()
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

#Region "frmMember User Defined Private Sub"

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsMember
            dataCombo = .GetJobTitles

            clsCommon.PopulateComboBox(cboJobId, cboJobTitle, dataCombo)

            dataCombo = .GetAppointmentStatus

            clsCommon.PopulateComboBox(cboAppointmentId, cboStatusAppointment, dataCombo)

            dataCombo = .GetQualification

            clsCommon.PopulateComboBox(cboQualificationId, cboQualification, dataCombo)
        End With
    End Sub

    Private Sub Initialize_Form()
        With clsMember
            dsRegion = .GetRegionList
            clsCommon.PopulateComboBox(cboRcode, cboRegion, dsRegion)
        End With

        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Set_Default_Values()
        Me.Text = "Member"
        Me.txtMemberNo.Focus()
    End Sub

    Private Sub Set_Default_Values()
        Try
            ClearImage()
            cboGender.SelectedIndex = 0
            cboStatus.SelectedIndex = 0

            cboRegion.SelectedIndex = cboRcode.Items.IndexOf(clsMember.GetDefaultParameter("rcode"))
            cboProvince.SelectedIndex = cboPcode.Items.IndexOf(clsMember.GetDefaultParameter("pcode"))
            cboMunicipality.SelectedIndex = cboMcode.Items.IndexOf(clsMember.GetDefaultParameter("mcode"))
            If Len(clsMember.GetDefaultParameter("lgu")) > 0 Then
                With clsLGU
                    .Init_Flag = CInt(clsMember.GetDefaultParameter("lgu"))
                    .Selected_Record()

                    Me.txtLGUName.Text = .LGU_Name
                    Me.txtLGUId.Text = .LGU_Id
                End With
            End If
            dtpDateHired.Checked = False
            dtpBirthDate.Checked = False
            Initialize_AutoComplete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            'Member Information
            .Add(cboStatus)
            .Add(txtFileName)
            .Add(btnPicture)
            .Add(txtHomeAddress)
            .Add(mtxtSSSNo)
            .Add(cboJobTitle)
            .Add(cboStatusAppointment)
            .Add(txtSalary)
            .Add(cboQualification)
            .Add(mtxtTINo)
            .Add(txtWorkTel)
            .Add(cboGender)
            .Add(txtEmailAddress)
            .Add(txtEmployeeId)
            .Add(txtMobileNo)
            .Add(txtHomeTel)
            .Add(txtLastName)
            .Add(txtSuffixName)
            .Add(txtMiddleName)
            .Add(txtFirstName)
            .Add(dtpBirthDate)
            .Add(txtBirthPlace)
            .Add(cboProvince)
            If State <> ADD_STATE Then
                .Add(chkActive)
                .Add(chkMember)
            End If
            .Add(cboZipCodeArea)
            .Add(cboRegion)
            .Add(cboBarangay)
            '.Add(txtMemberNo)
            .Add(cboMunicipality)
            .Add(txtLGUName)
            .Add(txtDepartmentName)
            .Add(dtpDateHired)
            .Add(txtCitizenship)
            .Add(txtPagibigIDNo)
            .Add(mtxtPhilHealthNo)
            .Add(txtBloodType)
            .Add(txtHeight)
            .Add(txtWeight)
            .Add(txtReferredBy)
            .Add(txtReferredByID)
            .Add(chkReassignFl)
            .Add(chkReplaceFl)
            .Add(chkRetireFl)
            .Add(dtpAppointmentDt)
            .Add(dtpOathDt)
            .Add(dtpMembershipDate)
            .Add(txtUpdateDt)

            'Educational Background
            .Add(Me.btnEducationalEdit)
            .Add(Me.dtpEducationalToDate)
            .Add(Me.dtpEducationalFromDate)
            .Add(Me.btnEducationalDelete)
            .Add(Me.btnEducationalClear)
            .Add(Me.btnEducationalAdd)
            .Add(Me.txtHonors)
            .Add(Me.txtHighestGrade)
            .Add(Me.txtDegreeCourse)
            .Add(Me.txtNameofSchool)
            .Add(Me.cboEducationalLevel)

            'Employment History
            .Add(Me.txtEmploymentTaskAccomplishment)
            .Add(Me.txtEmploymentCompanyAddress)
            .Add(Me.txtMonthlySalary)
            .Add(Me.txtEmploymentContactNo)
            .Add(Me.txtEmploymentCompanyName)
            .Add(Me.txtEmploymentPosition)
            .Add(Me.dtpEmploymentToDate)
            .Add(Me.dtpEmploymentFromDate)
            .Add(Me.btnEmploymentEdit)
            .Add(Me.btnEmploymentDelete)
            .Add(Me.btnEmploymentClear)
            .Add(Me.btnEmploymentAdd)

            'Organizations
            .Add(Me.txtOrganizationAddress)
            .Add(Me.txtOrganizationPosition)
            .Add(Me.txtOrganizationName)
            .Add(Me.dtpOrganizationSinceDt)
            .Add(Me.btnOrganizationEdit)
            .Add(Me.btnOrganizationDelete)
            .Add(Me.btnOrganizationClear)
            .Add(Me.btnOrganizationAdd)

            'Seminars Attended
            .Add(Me.txtSeminarRemarks)
            .Add(Me.txtSeminarLocation)
            .Add(Me.txtSeminarName)
            .Add(Me.dtpSeminarDate)
            .Add(Me.btnSeminarEdit)
            .Add(Me.btnSeminarDelete)
            .Add(Me.btnSeminarClear)
            .Add(Me.btnSeminarAdd)

            'Family Background
            .Add(Me.btnFamilyEdit)
            .Add(Me.btnFamilyDelete)
            .Add(Me.btnFamilyClear)
            .Add(Me.btnFamilyAdd)
            .Add(Me.txtSpouseFName)
            .Add(Me.txtSpouseMName)
            .Add(Me.txtSpouseLName)
            .Add(Me.txtSpouseSuffix)
            .Add(Me.dtpSpouseBirth)
            .Add(Me.txtFatherFName)
            .Add(Me.txtFatherMName)
            .Add(Me.txtFatherLName)
            .Add(Me.txtFatherSuffix)
            .Add(Me.txtMotherFName)
            .Add(Me.txtMotherMName)
            .Add(Me.txtMotherLName)

            'Children
            .Add(Me.btnChildEdit)
            .Add(Me.btnChildDelete)
            .Add(Me.btnChildClear)
            .Add(Me.btnChildAdd)
            .Add(Me.txtChildFName)
            .Add(Me.txtChildMName)
            .Add(Me.txtChildLName)
            .Add(Me.txtChildSuffix)
            .Add(Me.dtpChildBirth)
            .Add(Me.cboChildStatus)

            'Other Beneficiary
            .Add(Me.btnBeneficiaryEdit)
            .Add(Me.btnBeneficiaryDelete)
            .Add(Me.btnBeneficiaryClear)
            .Add(Me.btnBeneficiaryAdd)
            .Add(Me.txtBeneficiaryFName)
            .Add(Me.txtBeneficiaryMName)
            .Add(Me.txtBeneficiaryLName)
            .Add(Me.txtBeneficiarySuffix)
            .Add(Me.txtBeneficiaryRelation)

        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColMember
            'Member Information
            .Add(cboStatus)
            .Add(txtFileName)
            .Add(txtHomeAddress)
            .Add(mtxtSSSNo)
            .Add(cboJobTitle)
            .Add(cboStatusAppointment)
            .Add(txtSalary)
            .Add(cboQualification)
            .Add(mtxtTINo)
            .Add(txtWorkTel)
            .Add(cboGender)
            .Add(txtEmailAddress)
            .Add(txtEmployeeId)
            .Add(txtMobileNo)
            .Add(txtHomeTel)
            .Add(txtLastName)
            .Add(txtSuffixName)
            .Add(txtMiddleName)
            .Add(txtFirstName)
            .Add(dtpBirthDate)
            .Add(txtBirthPlace)
            .Add(cboZipCode)
            .Add(cboProvince)
            .Add(chkActive)
            .Add(chkMember)
            .Add(cboZipCodeArea)
            .Add(cboRegion)
            .Add(cboBarangay)
            .Add(txtMemberNo)
            .Add(cboMunicipality)
            .Add(txtLGUName)
            .Add(txtDepartmentName)
            .Add(dtpDateHired)
            .Add(txtCitizenship)
            .Add(txtPagibigIDNo)
            .Add(mtxtPhilHealthNo)
            .Add(txtBloodType)
            .Add(txtHeight)
            .Add(txtWeight)
            .Add(txtReferredBy)
            .Add(txtReferredByID)
            .Add(chkReassignFl)
            .Add(chkReplaceFl)
            .Add(chkRetireFl)
            .Add(dtpAppointmentDt)
            .Add(dtpOathDt)
            .Add(dtpMembershipDate)
            .Add(txtUpdateDt)

            'Educational Background
            .Add(Me.dtpEducationalToDate)
            .Add(Me.dtpEducationalFromDate)
            .Add(Me.txtHonors)
            .Add(Me.txtHighestGrade)
            .Add(Me.txtDegreeCourse)
            .Add(Me.txtNameofSchool)
            .Add(Me.cboEducationalLevel)

            'Employment History
            .Add(Me.txtEmploymentTaskAccomplishment)
            .Add(Me.txtEmploymentCompanyAddress)
            .Add(Me.txtMonthlySalary)
            .Add(Me.txtEmploymentContactNo)
            .Add(Me.txtEmploymentCompanyName)
            .Add(Me.txtEmploymentPosition)
            .Add(Me.dtpEmploymentToDate)
            .Add(Me.dtpEmploymentFromDate)

            'Organizations
            .Add(Me.txtOrganizationAddress)
            .Add(Me.txtOrganizationPosition)
            .Add(Me.txtOrganizationName)
            .Add(Me.dtpOrganizationSinceDt)

            'Seminars Attended
            .Add(Me.txtSeminarRemarks)
            .Add(Me.txtSeminarLocation)
            .Add(Me.txtSeminarName)
            .Add(Me.dtpSeminarDate)

            'Family Background
            .Add(Me.txtSpouseFName)
            .Add(Me.txtSpouseMName)
            .Add(Me.txtSpouseLName)
            .Add(Me.txtSpouseSuffix)
            .Add(Me.dtpSpouseBirth)
            .Add(Me.txtFatherFName)
            .Add(Me.txtFatherMName)
            .Add(Me.txtFatherLName)
            .Add(Me.txtFatherSuffix)
            .Add(Me.txtMotherFName)
            .Add(Me.txtMotherMName)
            .Add(Me.txtMotherLName)

            'Children
            .Add(Me.txtChildFName)
            .Add(Me.txtChildMName)
            .Add(Me.txtChildLName)
            .Add(Me.txtChildSuffix)
            .Add(Me.dtpChildBirth)
            .Add(Me.cboChildStatus)

            'Other Benefeciary
            .Add(Me.txtBeneficiaryFName)
            .Add(Me.txtBeneficiaryMName)
            .Add(Me.txtBeneficiaryLName)
            .Add(Me.txtBeneficiarySuffix)
            .Add(Me.txtBeneficiaryRelation)

            'CGMEA Membership

        End With
        With colEducationalBackground
            .Add(Me.dtpEducationalToDate)
            .Add(Me.dtpEducationalFromDate)
            .Add(Me.txtHonors)
            .Add(Me.txtHighestGrade)
            .Add(Me.txtDegreeCourse)
            .Add(Me.txtNameofSchool)
            .Add(Me.cboEducationalLevel)
        End With
        With colEmploymentHistory
            .Add(Me.txtEmploymentTaskAccomplishment)
            .Add(Me.txtEmploymentCompanyAddress)
            .Add(Me.txtMonthlySalary)
            .Add(Me.txtEmploymentContactNo)
            .Add(Me.txtEmploymentCompanyName)
            .Add(Me.txtEmploymentPosition)
            .Add(Me.dtpEmploymentToDate)
            .Add(Me.dtpEmploymentFromDate)
        End With
        With colmemberOrganization
            .Add(Me.txtOrganizationAddress)
            .Add(Me.txtOrganizationPosition)
            .Add(Me.txtOrganizationName)
            .Add(Me.dtpOrganizationSinceDt)
        End With
        With colSeminarsAttended
            .Add(Me.txtSeminarRemarks)
            .Add(Me.txtSeminarLocation)
            .Add(Me.txtSeminarName)
            .Add(Me.dtpSeminarDate)
        End With

        With colChildren
            .Add(Me.txtChildFName)
            .Add(Me.txtChildMName)
            .Add(Me.txtChildLName)
            .Add(Me.txtChildSuffix)
            .Add(Me.dtpChildBirth)
            .Add(Me.cboChildStatus)
        End With

        With colOtherBeneficiary
            .Add(Me.txtBeneficiaryFName)
            .Add(Me.txtBeneficiaryRelation)
        End With

        clsCommon.ClearControls(ColMember)
        clsCommon.ClearControls(colEducationalBackground)
        clsCommon.ClearControls(colEmploymentHistory)
        clsCommon.ClearControls(colmemberOrganization)
        clsCommon.ClearControls(colSeminarsAttended)
        clsCommon.ClearControls(colChildren)
        clsCommon.ClearControls(colOtherBeneficiary)
        Define_Required_Fields()
        Me.Text = "Member"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblLGUName)
            .Add(Me.lblDepartmentName)
            .Add(Me.lblReferredBy)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            '.Add(txtMemberNo)
            '.Add(txtDepartmentName)
            .Add(txtLGUName)
            .Add(txtFirstName)
            '.Add(txtLastName)
            '.Add(cboJobTitle)
            '.Add(cboStatusAppointment)
        End With
        With colEducationalBackgroundRequired
            .Add(Me.txtNameofSchool)
            .Add(Me.cboEducationalLevel)
        End With
        With colEmploymentHistoryRequired
            .Add(Me.txtEmploymentCompanyName)
            .Add(Me.txtEmploymentPosition)
        End With
        With colmemberOrganizationRequired
            .Add(Me.txtOrganizationName)
        End With
        With colSeminarsAttendedRequired
            .Add(Me.txtSeminarName)
        End With
        With colChildrenRequired
            .Add(Me.txtChildFName)
            .Add(Me.txtChildLName)
        End With
        With colOtherBeneficiaryRequired
            .Add(Me.txtBeneficiaryFName)
            .Add(Me.txtBeneficiaryRelation)
        End With

    End Sub

    Private Sub Assign_Data()
        With clsMember
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
            Me.cboZipCodeId.Text = .Zip_CodeId
            Me.cboZipCodeArea.SelectedIndex = Me.cboZipCodeId.SelectedIndex
            Me.cboZipCode.SelectedIndex = Me.cboZipCodeId.SelectedIndex

            Me.txtFileName.Text = .Member_Photo
            Try
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
            Catch ex As Exception

            End Try


            Me.txtLGUId.Text = .lgu_Id
            Me.txtLGUName.Text = .lgu_Name

            Me.txtDepartmentId.Text = .Department_Id
            Me.txtDepartmentName.Text = .Department_Name

            Me.txtReferredByID.Text = .Referral_Id
            Me.txtReferredBy.Text = .Referral_Name

            Me.txtMemberNo.Text = .Member_No
            Me.txtFirstName.Text = .First_Name
            Me.txtMiddleName.Text = .Middle_Name
            Me.txtLastName.Text = .Last_Name
            txtSuffixName.Text = ._suffixName
            Me.cboJobTitle.Text = .Job_Description
            Me.cboStatusAppointment.Text = .Appointment_Status
            Me.cboQualification.Text = .Member_Qualification
            txtSalary.Text = Format(.Salary_Amount, "Standard")

            Me.dtpBirthDate.Checked = IIf(.Birth_Fl = 1, True, False)
            If dtpBirthDate.Checked Then
                Me.dtpBirthDate.Value = .Member_Birthdate
            End If

            Me.mtxtSSSNo.Text = .Sss_No
            Me.mtxtTINo.Text = .Tax_IdNo
            Me.cboGender.Text = .Member_Gender
            Me.cboStatus.Text = .Marital_Status
            Me.txtHomeAddress.Text = .Home_Address
            Me.txtHomeTel.Text = .Home_Tel
            Me.txtWorkTel.Text = .Work_Tel
            Me.txtMobileNo.Text = .Mobile_No
            Me.txtEmailAddress.Text = .Email_Address
            Me.txtEmployeeId.Text = .Employee_Id

            Me.dtpDateHired.Checked = IIf(.Hired_Fl = 1, True, False)
            If dtpDateHired.Checked Then
                Me.dtpDateHired.Value = .Date_Hired
            End If

            Me.txtBirthPlace.Text = .MemberBirth_Place
            Me.txtCitizenship.Text = .Member_Citizenship
            Me.txtHeight.Text = .Member_Height
            Me.txtWeight.Text = .Member_Weight
            Me.txtBloodType.Text = .MemberBlood_Type
            Me.txtPagibigIDNo.Text = .PagibigID_No
            Me.mtxtPhilHealthNo.Text = .PhilHealth_No
            Me.chkActive.CheckState = .Active_Fl
            Me.chkMember.CheckState = .Member_Fl
            Me.chkReassignFl.CheckState = .reassign_Fl
            Me.chkReplaceFl.CheckState = .replace_Fl
            Me.chkRetireFl.CheckState = .retire_Fl

            If dtpBirthDate.Checked Then
                lblAge.ForeColor = Color.Black
                lblAge.Text = "( " & clsCommon.GetAge(dtpBirthDate.Value.Date) & " )"
            Else
                lblAge.ForeColor = Color.Red
                lblAge.Text = "( - )"
            End If

            Me.dtpAppointmentDt.Checked = IIf(.Appointment_Fl = 1, True, False)
            If dtpAppointmentDt.Checked Then
                Me.dtpAppointmentDt.Value = .TempAppointment_Dt
            End If

            Me.dtpOathDt.Checked = IIf(.Oath_Fl = 1, True, False)
            If dtpOathDt.Checked Then
                Me.dtpOathDt.Value = .TempOath_Dt
            End If

            Me.dtpMembershipDate.Checked = IIf(.CgmeaMembership_Fl = 1, True, False)
            If dtpMembershipDate.Checked Then
                Me.dtpMembershipDate.Value = .TempCgmeaMembership_Dt
            End If

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Member_Id

            'populate educational background
            lvwEducationalBackground.Items.Clear()
            Me.dtListView = .Populate_Record_Educational_Background
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwEducationalBackground
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("educationalLevel")))
                        Itm.SubItems.Add(Trim(dtListViewRow("schoolName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("degreeCourse")))
                        Itm.SubItems.Add(Trim(dtListViewRow("highestGrade")))
                        Itm.SubItems.Add(Trim(dtListViewRow("fromDate")))
                        Itm.SubItems.Add(Trim(dtListViewRow("toDate")))
                        Itm.SubItems.Add(Trim(dtListViewRow("honorsReceived")))
                    End With
                Next
            End If

            'populate employment history
            lvwEmploymentHistory.Items.Clear()
            Me.dtListView = .Populate_Record_Employment_History
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwEmploymentHistory
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("fromDate")))
                        Itm.SubItems.Add(Trim(dtListViewRow("toDate")))
                        Itm.SubItems.Add(Trim(dtListViewRow("jobTitle")))
                        Itm.SubItems.Add(Trim(dtListViewRow("companyName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("companyAddress")))
                        Itm.SubItems.Add(Trim(dtListViewRow("contactNo")))
                        Itm.SubItems.Add(Format(Trim(dtListViewRow("monthlySalary")), "Standard"))
                        Itm.SubItems.Add(Trim(dtListViewRow("taskAccomplishment")))
                    End With
                Next
            End If

            'populate Member organization
            lvwOrganization.Items.Clear()
            Me.dtListView = .Populate_Record_Member_Organization
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwOrganization
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("organizationName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("organizationAddress")))
                        Itm.SubItems.Add(Trim(dtListViewRow("organizationPosition")))
                        Itm.SubItems.Add(Trim(dtListViewRow("sinceDt")))
                    End With
                Next
            End If

            'populate seminars attended
            lvwSeminarsAttended.Items.Clear()
            Me.dtListView = .Populate_Record_Seminars_Attended
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwSeminarsAttended
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("seminarName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("seminarLocation")))
                        Itm.SubItems.Add(Trim(dtListViewRow("seminarDt")))
                        Itm.SubItems.Add(Trim(dtListViewRow("seminarRemarks")))
                    End With
                Next
            End If

            'populate family background
            lvwFamilyBackground.Items.Clear()
            Me.dtListView = .Populate_Record_Family_Background
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwFamilyBackground
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("spouseFName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("spouseMName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("spouseLName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("spouseSuffix")))
                        Itm.SubItems.Add(Trim(dtListViewRow("spouseBirth")))
                        Itm.SubItems.Add(Trim(dtListViewRow("fatherFName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("fatherMName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("fatherLName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("fatherSuffix")))
                        Itm.SubItems.Add(Trim(dtListViewRow("motherFName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("motherMName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("motherLName")))
                    End With
                Next
            End If

            'populate children
            lvwChildren.Items.Clear()
            Me.dtListView = .Populate_Record_Children
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwChildren
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("childFName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("childMName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("childLName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("childSuffix")))
                        Itm.SubItems.Add(Trim(dtListViewRow("childBirth")))
                        Itm.SubItems.Add(Trim(clsCommon.GetAge(Trim(dtListViewRow("childBirth")))))
                        Itm.SubItems.Add(Trim(dtListViewRow("cStatus")))
                    End With
                Next
            End If

            'populate other beneficiary
            lvwOtherBeneficiary.Items.Clear()
            Me.dtListView = .Populate_Record_Other_Beneficiary
            If Not Me.dtListView Is Nothing Then
                For Each Me.dtListViewRow In Me.dtListView.Rows
                    With lvwOtherBeneficiary
                        Dim Itm As ListViewItem
                        Itm = .Items.Add(Trim(dtListViewRow("beneficiaryFName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("beneficiaryMName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("beneficiaryLName")))
                        Itm.SubItems.Add(Trim(dtListViewRow("beneficiarySuffix")))
                        Itm.SubItems.Add(Trim(dtListViewRow("beneficiaryRelation")))
                    End With
                Next
            End If

        End With
        Me.txtMemberNo.Focus()

        Me.Text = "Member - " & txtLastName.Text & IIf(Len(txtSuffixName.Text) > 0, " " & txtSuffixName.Text, "") & ", " & txtFirstName.Text & IIf(Len(txtMiddleName.Text) > 0, " " & txtMiddleName.Text, "") & " (" & cboJobTitle.Text & ") - [" & txtDepartmentName.Text & "]"
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
        clsMember = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMember = Nothing
        colEducationalBackground = Nothing
        colEducationalBackgroundRequired = Nothing
        EducationalBackground = Nothing
        colEmploymentHistory = Nothing
        colEmploymentHistoryRequired = Nothing
        EmploymentHistory = Nothing
        colmemberOrganization = Nothing
        colmemberOrganizationRequired = Nothing
        memberOrganization = Nothing
        colSeminarsAttended = Nothing
        colSeminarsAttendedRequired = Nothing
        SeminarsAttended = Nothing
        colFamilyBackground = Nothing
        colFamilyBackgroundRequired = Nothing
        FamilyBackground = Nothing
        colChildren = Nothing
        colChildrenRequired = Nothing
        Children = Nothing
        colOtherBeneficiary = Nothing
        colOtherBeneficiaryRequired = Nothing
        OtherBeneficiary = Nothing
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
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblMemberNo.Text = "Member No."
            lblLGUName.Text = "LGU Name"
            lblDepartmentName.Text = "Department Name"
            lblFirstName.Text = "First Name"
            lblLastName.Text = "Last Name"
            'lblJobTitle.Text = "Job Title"
            'lblStatusofAppointment.Text = "Status of Appointment"
            lblLevel.Text = "Educational Level"
            lblNameofSchool.Text = "Name of School"
            lblEmploymentCompanyName.Text = "Company Name"
            lblEmploymentPosition.Text = "Job Title"
            lblOrganizationName.Text = "Organization Name"
            lblSeminarName.Text = "Seminar Name"
        Else
            lblMemberNo.Text = "Member No. *"
            lblLGUName.Text = "LGU Name *"
            lblDepartmentName.Text = "Department Name *"
            lblFirstName.Text = "First Name *"
            lblLastName.Text = "Last Name *"
            'lblJobTitle.Text = "Job Title *"
            'lblStatusofAppointment.Text = "Status of Appointment *"
            lblLevel.Text = "Educational Level *"
            lblNameofSchool.Text = "Name of School *"
            lblEmploymentCompanyName.Text = "Company Name *"
            lblEmploymentPosition.Text = "Job Title *"
            lblOrganizationName.Text = "Organization Name *"
            lblSeminarName.Text = "Seminar Name *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsMember.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        'Me.txtMemberNo.Tag = "Member Number"
        Me.txtDepartmentName.Tag = "Department Name"
        Me.txtLGUName.Tag = "LGU Name"
        Me.txtFirstName.Tag = "First Name"
        Me.txtLastName.Tag = "Last Name"
        Me.cboJobTitle.Tag = "Job Description"
        cboStatusAppointment.Tag = "Status of Appointment"
        Me.txtNameofSchool.Tag = "Name of School"
        Me.cboEducationalLevel.Tag = "Educational Level"
        Me.txtEmploymentCompanyName.Tag = "Company Name"
        Me.txtEmploymentPosition.Tag = "Employment Position"
        Me.txtOrganizationName.Tag = "Organization Name"
        Me.txtSeminarName.Tag = "Seminar Name"
        Me.txtChildFName.Tag = "Child First Name"
        Me.txtChildLName.Tag = "Child Last Name"
        Me.txtBeneficiaryFName.Tag = "Beneficiary First Name"
        Me.txtBeneficiaryLName.Tag = "Beneficiary Last Name"
        Me.txtBeneficiaryRelation.Tag = "Beneficiary Relation"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtFileName.MaxLength = 255
        Me.txtHomeAddress.MaxLength = 2000
        'Me.txtSSSNo.MaxLength = 45
        'Me.txtTINo.MaxLength = 45
        Me.txtWorkTel.MaxLength = 45
        Me.txtEmailAddress.MaxLength = 45
        Me.txtEmployeeId.MaxLength = 10
        Me.txtMobileNo.MaxLength = 45
        Me.txtHomeTel.MaxLength = 45
        Me.txtLastName.MaxLength = 50
        Me.txtMiddleName.MaxLength = 50
        Me.txtFirstName.MaxLength = 50
        txtSuffixName.MaxLength = 50
        'Me.txtMemberNo.MaxLength = 45
        Me.txtBirthPlace.MaxLength = 255
        Me.txtCitizenship.MaxLength = 255
        Me.txtHeight.MaxLength = 45
        Me.txtWeight.MaxLength = 45
        Me.txtBloodType.MaxLength = 45
        Me.txtPagibigIDNo.MaxLength = 45
        'Me.txtPhilHealthNo.MaxLength = 45
        Me.txtDegreeCourse.MaxLength = 0
        Me.txtEmploymentCompanyAddress.MaxLength = 2000
        Me.txtEmploymentCompanyName.MaxLength = 255
        Me.txtEmploymentContactNo.MaxLength = 255
        Me.txtEmploymentPosition.MaxLength = 255
        Me.txtEmploymentTaskAccomplishment.MaxLength = 2000
        Me.txtHighestGrade.MaxLength = 255
        Me.txtHonors.MaxLength = 10000
        Me.txtMonthlySalary.MaxLength = 14
        Me.txtNameofSchool.MaxLength = 255
        Me.txtOrganizationAddress.MaxLength = 2000
        Me.txtOrganizationName.MaxLength = 255
        Me.txtOrganizationPosition.MaxLength = 255
        Me.txtSeminarLocation.MaxLength = 255
        Me.txtSeminarName.MaxLength = 255
        Me.txtSeminarRemarks.MaxLength = 2000
        cboJobTitle.MaxLength = 255
        cboStatusAppointment.MaxLength = 255
        cboQualification.MaxLength = 255
        txtSalary.MaxLength = 20

        Me.txtSpouseFName.MaxLength = 75
        Me.txtSpouseMName.MaxLength = 75
        Me.txtSpouseLName.MaxLength = 75
        Me.txtSpouseSuffix.MaxLength = 75

        Me.txtFatherFName.MaxLength = 75
        Me.txtFatherMName.MaxLength = 75
        Me.txtFatherLName.MaxLength = 75
        Me.txtFatherSuffix.MaxLength = 75
        Me.txtMotherFName.MaxLength = 75
        Me.txtMotherMName.MaxLength = 75
        Me.txtMotherLName.MaxLength = 75

        Me.txtChildFName.MaxLength = 75
        Me.txtChildMName.MaxLength = 75
        Me.txtChildLName.MaxLength = 75
        Me.txtChildSuffix.MaxLength = 75
        Me.txtBeneficiaryFName.MaxLength = 75
        Me.txtBeneficiaryMName.MaxLength = 75
        Me.txtBeneficiaryLName.MaxLength = 75
        Me.txtBeneficiarySuffix.MaxLength = 75
        Me.txtBeneficiaryRelation.MaxLength = 75

    End Sub

    Private Sub txtFirstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFirstName.TextChanged, txtLastName.TextChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State = ADD_STATE Then
            Me.txtMemberNo.Text = Mid(txtFirstName.Text, 1, 1) + Mid(txtLastName.Text, 1, 1) + clsCommon.GenerateRecordNo(clsMember.GetNewMemberNo(), 10)
        End If
    End Sub

    Private Sub dtpBirthDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBirthDate.ValueChanged, dtpBirthDate.Leave
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Dim intAge As Integer = CInt(clsCommon.GetAge(dtpBirthDate.Value.Date))

        If dtpBirthDate.Checked Then
            lblAge.ForeColor = Color.Black

            If intAge < 100 And intAge > 0 Then
                lblAge.Text = "( " & clsCommon.GetAge(dtpBirthDate.Value.Date) & " )"
            ElseIf intAge < 0 Then
                lblAge.Text = "( - )"
            ElseIf intAge > 100 Then
                lblAge.Text = "( 100+ )"
            End If
        Else
            lblAge.ForeColor = Color.Red
            lblAge.Text = "( - )"
        End If
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboRcode.SelectedIndex = cboRegion.SelectedIndex
            With clsMember
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
            With clsMember
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
            With clsMember
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

    Private Sub btnPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPicture.Click
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
    End Sub


    'Private Function ResizeImage(ByVal SourceImage As Drawing.Image) As Drawing.Bitmap
    '    Dim imageToBeResized As System.Drawing.Image = SourceImage
    '    Dim imageHeight As Integer = imageToBeResized.Height
    '    Dim imageWidth As Integer = imageToBeResized.Width
    '    Dim maxHeight As Integer = 350
    '    Dim maxWidth As Integer = 350
    '    imageHeight = (imageHeight * maxWidth) / imageWidth
    '    imageWidth = maxWidth

    '    If imageHeight > maxHeight Then
    '        imageWidth = (imageWidth * maxHeight) / imageHeight
    '        imageHeight = maxHeight
    '    End If

    '    Dim bitmap As New Bitmap(imageToBeResized, imageWidth, imageHeight)
    '    bitmap.Save("MyFile.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
    '    Return bitmap
    'End Function

    Private Sub btnPicture_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPicture.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmnuCapture.Enabled = clsCommon.IsImageCaptureAvailable
        End If
    End Sub

    Private Sub cmnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuClear.Click
        ClearImage()
        cmnuClear.Enabled = False
    End Sub

    Private Sub cmnuCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuCapture.Click
        Dim image1 As Bitmap = clsCommon.CaptureImagetoBMP

        If Not image1 Is Nothing Then
            txtFileName.Text = ImageDir & "\" & Now.TimeOfDay.TotalMilliseconds & ".jpg"
            image1.Save(txtFileName.Text, Imaging.ImageFormat.Jpeg)
            btnPicture.BackgroundImage = image1
            btnPicture.BackgroundImageLayout = ImageLayout.Zoom
            cmnuClear.Enabled = True
        End If
    End Sub

    Public Sub ClearImage()
        Dim image1 As Bitmap = New Bitmap(Me.GetType, "blank-user.gif")
        btnPicture.BackgroundImage = image1
        btnPicture.BackgroundImageLayout = ImageLayout.Zoom
        txtFileName.Text = ""
    End Sub

    Private Sub Populate_Collection()
        Try
            Dim EducationalBackground As New Collection
            Dim EmploymentHistory As New Collection
            Dim MemberOrganization As New Collection
            Dim SeminarsAttended As New Collection
            Dim FamilyBackground As New Collection
            Dim Children As New Collection
            Dim OtherBeneficiary As New Collection

            Dim lvwEducationalItem As ListViewItem
            Dim lvwEmploymentItem As ListViewItem
            Dim lvwOrganizationItem As ListViewItem
            Dim lvwSeminarItem As ListViewItem
            Dim lvwFamilyItem As ListViewItem
            Dim lvwChildrenItem As ListViewItem
            Dim lvwOtherBeneficiaryItem As ListViewItem

            For Each lvwEducationalItem In Me.lvwEducationalBackground.Items
                clsEducationalBackground = New MemberEducationalBackground.MemberEducationalBackground
                With clsEducationalBackground
                    .Educational_Level = Trim(lvwEducationalItem.SubItems(0).Text)
                    .School_Name = Trim(lvwEducationalItem.SubItems(1).Text)
                    .Degree_Course = Trim(lvwEducationalItem.SubItems(2).Text)
                    .Higest_Grade = Trim(lvwEducationalItem.SubItems(3).Text)
                    .From_Date = Trim(lvwEducationalItem.SubItems(4).Text)
                    .To_Date = Trim(lvwEducationalItem.SubItems(5).Text)
                    .Honors_Received = Trim(lvwEducationalItem.SubItems(6).Text)
                End With
                EducationalBackground.Add(clsEducationalBackground)
            Next

            For Each lvwEmploymentItem In Me.lvwEmploymentHistory.Items
                clsEmploymentHistory = New MemberEmploymentHistory.MemberEmploymentHistory
                With clsEmploymentHistory
                    .From_Date = Trim(lvwEmploymentItem.SubItems(0).Text)
                    .To_Date = Trim(lvwEmploymentItem.SubItems(1).Text)
                    .Job_Title = Trim(lvwEmploymentItem.SubItems(2).Text)
                    .Company_Name = Trim(lvwEmploymentItem.SubItems(3).Text)
                    .Company_Address = Trim(lvwEmploymentItem.SubItems(4).Text)
                    .CompanyContact_No = Trim(lvwEmploymentItem.SubItems(5).Text)
                    .Monthly_Salary = Trim(lvwEmploymentItem.SubItems(6).Text.Replace(",", ""))
                    .Task_Accomplishment = Trim(lvwEmploymentItem.SubItems(7).Text)
                End With
                EmploymentHistory.Add(clsEmploymentHistory)
            Next

            For Each lvwOrganizationItem In Me.lvwOrganization.Items
                clsOrganizations = New MemberOrganizations.MemberOrganizations
                With clsOrganizations
                    .Organization_Name = Trim(lvwOrganizationItem.SubItems(0).Text)
                    .Organization_Address = Trim(lvwOrganizationItem.SubItems(1).Text)
                    .Organization_Position = Trim(lvwOrganizationItem.SubItems(2).Text)
                    .Since_Date = Trim(lvwOrganizationItem.SubItems(3).Text)
                End With
                MemberOrganization.Add(clsOrganizations)
            Next

            For Each lvwSeminarItem In Me.lvwSeminarsAttended.Items
                clsSeminarsAttended = New MemberSeminarsAttended.MemberSeminarsAttended
                With clsSeminarsAttended
                    .Seminar_Name = Trim(lvwSeminarItem.SubItems(0).Text)
                    .Seminar_Location = Trim(lvwSeminarItem.SubItems(1).Text)
                    .Seminar_Date = Trim(lvwSeminarItem.SubItems(2).Text)
                    .Seminar_Remarks = Trim(lvwSeminarItem.SubItems(3).Text)
                End With
                SeminarsAttended.Add(clsSeminarsAttended)
            Next

            For Each lvwFamilyItem In Me.lvwFamilyBackground.Items
                clsFamilyBackground = New MemberFamilyBackground.MemberFamilyBackground
                With clsFamilyBackground
                    .Spouse_FName = Trim(lvwFamilyItem.SubItems(0).Text)
                    .Spouse_MName = Trim(lvwFamilyItem.SubItems(1).Text)
                    .Spouse_LName = Trim(lvwFamilyItem.SubItems(2).Text)
                    .Spouse_Suffix = Trim(lvwFamilyItem.SubItems(3).Text)
                    .Spouse_Birth = Trim(lvwFamilyItem.SubItems(4).Text)
                    .Father_FName = Trim(lvwFamilyItem.SubItems(5).Text)
                    .Father_MName = Trim(lvwFamilyItem.SubItems(6).Text)
                    .Father_LName = Trim(lvwFamilyItem.SubItems(7).Text)
                    .Father_Suffix = Trim(lvwFamilyItem.SubItems(8).Text)
                    .Mother_FName = Trim(lvwFamilyItem.SubItems(9).Text)
                    .Mother_MName = Trim(lvwFamilyItem.SubItems(10).Text)
                    .Mother_LName = Trim(lvwFamilyItem.SubItems(11).Text)
                End With
                FamilyBackground.Add(clsFamilyBackground)
            Next

            For Each lvwChildrenItem In Me.lvwChildren.Items
                clsChildren = New MemberChildren.MemberChildren
                With clsChildren
                    .Child_FName = Trim(lvwChildrenItem.SubItems(0).Text)
                    .Child_MName = Trim(lvwChildrenItem.SubItems(1).Text)
                    .Child_LName = Trim(lvwChildrenItem.SubItems(2).Text)
                    .Child_Suffix = Trim(lvwChildrenItem.SubItems(3).Text)
                    .Child_Birth = Trim(lvwChildrenItem.SubItems(4).Text)
                    .Child_Status = Trim(lvwChildrenItem.SubItems(6).Text)
                End With
                Children.Add(clsChildren)
            Next

            For Each lvwOtherBeneficiaryItem In Me.lvwOtherBeneficiary.Items
                clsOtherBeneficiary = New MemberOtherBeneficiary.MemberOtherBeneficiary
                With clsOtherBeneficiary
                    .Beneficiary_FName = Trim(lvwOtherBeneficiaryItem.SubItems(0).Text)
                    .Beneficiary_MName = Trim(lvwOtherBeneficiaryItem.SubItems(1).Text)
                    .Beneficiary_LName = Trim(lvwOtherBeneficiaryItem.SubItems(2).Text)
                    .Beneficiary_Suffix = Trim(lvwOtherBeneficiaryItem.SubItems(3).Text)
                    .Beneficiary_Relation = Trim(lvwOtherBeneficiaryItem.SubItems(4).Text)
                End With
                OtherBeneficiary.Add(clsOtherBeneficiary)
            Next

            With clsMember
                .colEducational_Background = EducationalBackground
                .colEmployment_History = EmploymentHistory
                .col_Organizations = MemberOrganization
                .colSeminars_Attended = SeminarsAttended

                .colFamily_Background = FamilyBackground
                .col_Children = Children
                .colOther_Beneficiary = OtherBeneficiary

                EducationalBackground = Nothing
                EmploymentHistory = Nothing
                MemberOrganization = Nothing
                SeminarsAttended = Nothing

                FamilyBackground = Nothing
                Children = Nothing
                OtherBeneficiary = Nothing
            End With

        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub

    Private Sub btnEducationalAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEducationalAdd.Click, btnEducationalClear.Click, btnEducationalDelete.Click, btnEducationalEdit.Click, _
    btnEmploymentAdd.Click, btnEmploymentClear.Click, btnEmploymentDelete.Click, btnEmploymentEdit.Click, btnOrganizationAdd.Click, btnOrganizationClear.Click, btnOrganizationDelete.Click, btnOrganizationEdit.Click, _
    btnSeminarAdd.Click, btnSeminarClear.Click, btnSeminarDelete.Click, btnSeminarEdit.Click, _
    btnFamilyAdd.Click, btnFamilyClear.Click, btnFamilyDelete.Click, btnFamilyEdit.Click, _
    btnChildAdd.Click, btnChildClear.Click, btnChildDelete.Click, btnChildEdit.Click, _
    btnBeneficiaryAdd.Click, btnBeneficiaryClear.Click, btnBeneficiaryDelete.Click, btnBeneficiaryEdit.Click
        Dim btnObject As Button
        If TypeOf (sender) Is Button Then
            btnObject = sender
            Select Case LCase(btnObject.Name)
                Case "btneducationaladd"
                    If clsCommon.Required_Validation_List(colEducationalBackgroundRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwEducationalBackground
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(Trim(cboEducationalLevel.Text))
                                Itm.SubItems.Add(Trim(txtNameofSchool.Text))
                                Itm.SubItems.Add(Trim(txtDegreeCourse.Text))
                                Itm.SubItems.Add(Trim(txtHighestGrade.Text))
                                Itm.SubItems.Add(dtpEducationalFromDate.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(dtpEducationalToDate.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(Trim(txtHonors.Text))
                            End With
                        Else
                            lvwEducationalBackgroundItem.SubItems(0).Text = Trim(cboEducationalLevel.Text)
                            lvwEducationalBackgroundItem.SubItems(1).Text = Trim(txtNameofSchool.Text)
                            lvwEducationalBackgroundItem.SubItems(2).Text = Trim(txtDegreeCourse.Text)
                            lvwEducationalBackgroundItem.SubItems(3).Text = Trim(txtHighestGrade.Text)
                            lvwEducationalBackgroundItem.SubItems(4).Text = dtpEducationalFromDate.Value.ToString("yyyy-MM-dd")
                            lvwEducationalBackgroundItem.SubItems(5).Text = dtpEducationalToDate.Value.ToString("yyyy-MM-dd")
                            lvwEducationalBackgroundItem.SubItems(6).Text = Trim(txtHonors.Text)
                        End If

                        GoTo educational_clear
                    End If
                Case "btnemploymentadd"
                    If clsCommon.Required_Validation_List(colEmploymentHistoryRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwEmploymentHistory
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(dtpEmploymentFromDate.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(dtpEmploymentToDate.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(Trim(txtEmploymentPosition.Text))
                                Itm.SubItems.Add(Trim(txtEmploymentCompanyName.Text))
                                Itm.SubItems.Add(Trim(txtEmploymentCompanyAddress.Text))
                                Itm.SubItems.Add(Trim(txtEmploymentContactNo.Text))
                                Itm.SubItems.Add(Format(Trim(txtMonthlySalary.Text.Replace(",", "")), "Standard"))
                                Itm.SubItems.Add(Trim(txtEmploymentTaskAccomplishment.Text))
                            End With
                        Else
                            lvwEmploymentHistoryItem.SubItems(0).Text = dtpEmploymentFromDate.Value.ToString("yyyy-MM-dd")
                            lvwEmploymentHistoryItem.SubItems(1).Text = dtpEmploymentToDate.Value.ToString("yyyy-MM-dd")
                            lvwEmploymentHistoryItem.SubItems(2).Text = Trim(txtEmploymentPosition.Text)
                            lvwEmploymentHistoryItem.SubItems(3).Text = Trim(txtEmploymentCompanyName.Text)
                            lvwEmploymentHistoryItem.SubItems(4).Text = Trim(txtEmploymentCompanyAddress.Text)
                            lvwEmploymentHistoryItem.SubItems(5).Text = Trim(txtEmploymentContactNo.Text)
                            lvwEmploymentHistoryItem.SubItems(6).Text = Format(Trim(txtMonthlySalary.Text.Replace(",", "")), "Standard")
                            lvwEmploymentHistoryItem.SubItems(7).Text = Trim(txtEmploymentTaskAccomplishment.Text)
                        End If

                        GoTo employment_clear
                    End If
                Case "btnorganizationadd"
                    If clsCommon.Required_Validation_List(colMemberOrganizationRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwOrganization
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(Trim(txtOrganizationName.Text))
                                Itm.SubItems.Add(Trim(txtOrganizationAddress.Text))
                                Itm.SubItems.Add(Trim(txtOrganizationPosition.Text))
                                Itm.SubItems.Add(dtpOrganizationSinceDt.Value.ToString("yyyy-MM-dd"))
                            End With
                        Else
                            lvwMemberOrganizationItem.SubItems(0).Text = Trim(txtOrganizationName.Text)
                            lvwMemberOrganizationItem.SubItems(1).Text = Trim(txtOrganizationAddress.Text)
                            lvwMemberOrganizationItem.SubItems(2).Text = Trim(txtOrganizationPosition.Text)
                            lvwMemberOrganizationItem.SubItems(3).Text = dtpOrganizationSinceDt.Value.ToString("yyyy-MM-dd")
                        End If

                        GoTo organization_clear
                    End If
                Case "btnseminaradd"
                    If clsCommon.Required_Validation_List(colSeminarsAttendedRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwSeminarsAttended
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(Trim(txtSeminarName.Text))
                                Itm.SubItems.Add(Trim(txtSeminarLocation.Text))
                                Itm.SubItems.Add(dtpSeminarDate.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(Trim(txtSeminarRemarks.Text))
                            End With
                        Else
                            lvwSeminarsAttendedItem.SubItems(0).Text = Trim(txtSeminarName.Text)
                            lvwSeminarsAttendedItem.SubItems(1).Text = Trim(txtSeminarLocation.Text)
                            lvwSeminarsAttendedItem.SubItems(2).Text = dtpSeminarDate.Value.ToString("yyyy-MM-dd")
                            lvwSeminarsAttendedItem.SubItems(3).Text = Trim(txtSeminarRemarks.Text)
                        End If

                        GoTo seminar_clear
                    End If
                Case "btnfamilyadd"
                    If clsCommon.Required_Validation_List(colFamilyBackgroundRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwFamilyBackground
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(Trim(txtSpouseFName.Text))
                                Itm.SubItems.Add(Trim(txtSpouseMName.Text))
                                Itm.SubItems.Add(Trim(txtSpouseLName.Text))
                                Itm.SubItems.Add(Trim(txtSpouseSuffix.Text))
                                Itm.SubItems.Add(dtpSpouseBirth.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(Trim(txtFatherFName.Text))
                                Itm.SubItems.Add(Trim(txtFatherMName.Text))
                                Itm.SubItems.Add(Trim(txtFatherLName.Text))
                                Itm.SubItems.Add(Trim(txtFatherSuffix.Text))
                                Itm.SubItems.Add(Trim(txtMotherFName.Text))
                                Itm.SubItems.Add(Trim(txtMotherMName.Text))
                                Itm.SubItems.Add(Trim(txtMotherLName.Text))
                            End With
                        Else
                            lvwFamilyBackgroundItem.SubItems(0).Text = Trim(txtSpouseFName.Text)
                            lvwFamilyBackgroundItem.SubItems(1).Text = Trim(txtSpouseMName.Text)
                            lvwFamilyBackgroundItem.SubItems(2).Text = Trim(txtSpouseLName.Text)
                            lvwFamilyBackgroundItem.SubItems(3).Text = Trim(txtSpouseSuffix.Text)
                            lvwFamilyBackgroundItem.SubItems(4).Text = dtpSpouseBirth.Value.ToString("yyyy-MM-dd")
                            lvwFamilyBackgroundItem.SubItems(5).Text = Trim(txtFatherFName.Text)
                            lvwFamilyBackgroundItem.SubItems(6).Text = Trim(txtFatherMName.Text)
                            lvwFamilyBackgroundItem.SubItems(7).Text = Trim(txtFatherLName.Text)
                            lvwFamilyBackgroundItem.SubItems(8).Text = Trim(txtFatherSuffix.Text)
                            lvwFamilyBackgroundItem.SubItems(9).Text = Trim(txtMotherFName.Text)
                            lvwFamilyBackgroundItem.SubItems(10).Text = Trim(txtMotherMName.Text)
                            lvwFamilyBackgroundItem.SubItems(11).Text = Trim(txtMotherLName.Text)
                        End If

                        GoTo family_clear
                    End If
                Case "btnchildadd"
                    If clsCommon.Required_Validation_List(colChildrenRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwChildren
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(Trim(txtChildFName.Text))
                                Itm.SubItems.Add(Trim(txtChildMName.Text))
                                Itm.SubItems.Add(Trim(txtChildLName.Text))
                                Itm.SubItems.Add(Trim(txtChildSuffix.Text))
                                Itm.SubItems.Add(dtpChildBirth.Value.ToString("yyyy-MM-dd"))
                                Itm.SubItems.Add(Trim(clsCommon.GetAge(dtpChildBirth.Value.ToString("yyyy-MM-dd"))))
                                Itm.SubItems.Add(Trim(cboChildStatus.Text))
                            End With
                        Else
                            lvwChildrenItem.SubItems(0).Text = Trim(txtChildFName.Text)
                            lvwChildrenItem.SubItems(1).Text = Trim(txtChildMName.Text)
                            lvwChildrenItem.SubItems(2).Text = Trim(txtChildLName.Text)
                            lvwChildrenItem.SubItems(3).Text = Trim(txtChildSuffix.Text)
                            lvwChildrenItem.SubItems(4).Text = dtpChildBirth.Value.ToString("yyyy-MM-dd")
                            lvwChildrenItem.SubItems(5).Text = Trim(clsCommon.GetAge(dtpChildBirth.Value.ToString("yyyy-MM-dd")))
                            lvwChildrenItem.SubItems(6).Text = Trim(cboChildStatus.Text)
                        End If

                        GoTo children_clear
                    End If
                Case "btnbeneficiaryadd"
                    If clsCommon.Required_Validation_List(colOtherBeneficiaryRequired) Then
                        If LCase(btnObject.Text) = "add" Then
                            With lvwOtherBeneficiary
                                Dim Itm As ListViewItem
                                Itm = .Items.Add(Trim(txtBeneficiaryFName.Text))
                                Itm.SubItems.Add(Trim(txtBeneficiaryRelation.Text))
                            End With
                        Else
                            lvwOtherBeneficiaryItem.SubItems(0).Text = Trim(txtBeneficiaryFName.Text)
                            lvwOtherBeneficiaryItem.SubItems(1).Text = Trim(txtBeneficiaryMName.Text)
                            lvwOtherBeneficiaryItem.SubItems(2).Text = Trim(txtBeneficiaryLName.Text)
                            lvwOtherBeneficiaryItem.SubItems(3).Text = Trim(txtBeneficiarySuffix.Text)
                            lvwOtherBeneficiaryItem.SubItems(4).Text = Trim(txtBeneficiaryRelation.Text)
                        End If

                        GoTo beneficiary_clear
                    End If
                Case "btneducationalclear"
educational_clear:
                    btnEducationalAdd.Text = "Add"
                    lvwEducationalBackgroundItem = Nothing
                    clsCommon.ClearControls(colEducationalBackground)
                    cboEducationalLevel.Focus()
                Case "btnemploymentclear"
employment_clear:
                    btnEmploymentAdd.Text = "Add"
                    lvwEmploymentHistoryItem = Nothing
                    clsCommon.ClearControls(colEmploymentHistory)
                    dtpEmploymentFromDate.Focus()
                Case "btnorganizationclear"
organization_clear:
                    btnOrganizationAdd.Text = "Add"
                    lvwMemberOrganizationItem = Nothing
                    clsCommon.ClearControls(colMemberOrganization)
                    txtOrganizationName.Focus()
                Case "btnseminarclear"
seminar_clear:
                    btnSeminarAdd.Text = "Add"
                    lvwSeminarsAttendedItem = Nothing
                    clsCommon.ClearControls(colSeminarsAttended)
                    txtSeminarName.Focus()
                Case "btnfamilyclear"
family_clear:
                    btnFamilyAdd.Text = "Add"
                    lvwFamilyBackgroundItem = Nothing
                    clsCommon.ClearControls(colFamilyBackground)
                    txtSpouseFName.Focus()
                Case "btnchildclear"
children_clear:
                    btnChildAdd.Text = "Add"
                    lvwChildrenItem = Nothing
                    clsCommon.ClearControls(colChildren)
                    txtChildFName.Focus()
                Case "btnbeneficiaryclear"
beneficiary_clear:
                    btnBeneficiaryAdd.Text = "Add"
                    lvwOtherBeneficiaryItem = Nothing
                    clsCommon.ClearControls(colOtherBeneficiary)
                    txtBeneficiaryFName.Focus()
                Case "btneducationaldelete"
                    If lvwEducationalBackground.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwEducationalBackground.Items.RemoveAt(lvwEducationalBackground.SelectedItems(0).Index)
                        GoTo educational_clear
                    End If
                Case "btnemploymentdelete"
                    If lvwEmploymentHistory.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwEmploymentHistory.Items.RemoveAt(lvwEmploymentHistory.SelectedItems(0).Index)
                        GoTo employment_clear
                    End If
                Case "btnorganizationdelete"
                    If lvwOrganization.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwOrganization.Items.RemoveAt(lvwOrganization.SelectedItems(0).Index)
                        GoTo organization_clear
                    End If
                Case "btnseminardelete"
                    If lvwSeminarsAttended.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwSeminarsAttended.Items.RemoveAt(lvwSeminarsAttended.SelectedItems(0).Index)
                        GoTo seminar_clear
                    End If
                Case "btnfamilydelete"
                    If lvwFamilyBackground.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwFamilyBackground.Items.RemoveAt(lvwFamilyBackground.SelectedItems(0).Index)
                        GoTo family_clear
                    End If
                Case "btnchilddelete"
                    If lvwChildren.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwChildren.Items.RemoveAt(lvwChildren.SelectedItems(0).Index)
                        GoTo children_clear
                    End If
                Case "btnbeneficiarydelete"
                    If lvwOtherBeneficiary.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_DELETE)
                        Exit Sub
                    End If

                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        lvwOtherBeneficiary.Items.RemoveAt(lvwOtherBeneficiary.SelectedItems(0).Index)
                        GoTo beneficiary_clear
                    End If
                Case "btneducationaledit"
                    If lvwEducationalBackground.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnEducationalAdd.Text = "Update"
                    lvwEducationalBackgroundItem = lvwEducationalBackground.SelectedItems(0)

                    cboEducationalLevel.Text = Trim(lvwEducationalBackgroundItem.SubItems(0).Text)
                    txtNameofSchool.Text = Trim(lvwEducationalBackgroundItem.SubItems(1).Text)
                    txtDegreeCourse.Text = Trim(lvwEducationalBackgroundItem.SubItems(2).Text)
                    txtHighestGrade.Text = Trim(lvwEducationalBackgroundItem.SubItems(3).Text)
                    dtpEducationalFromDate.Value = CDate(Trim(lvwEducationalBackgroundItem.SubItems(4).Text))
                    dtpEducationalToDate.Value = CDate(Trim(lvwEducationalBackgroundItem.SubItems(5).Text))
                    txtHonors.Text = Trim(lvwEducationalBackgroundItem.SubItems(6).Text)
                Case "btnemploymentedit"
                    If lvwEmploymentHistory.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnEmploymentAdd.Text = "Update"
                    lvwEmploymentHistoryItem = lvwEmploymentHistory.SelectedItems(0)

                    dtpEmploymentFromDate.Value = CDate(Trim(lvwEmploymentHistoryItem.SubItems(0).Text))
                    dtpEmploymentToDate.Value = CDate(Trim(lvwEmploymentHistoryItem.SubItems(1).Text))
                    txtEmploymentPosition.Text = Trim(lvwEmploymentHistoryItem.SubItems(2).Text)
                    txtEmploymentCompanyName.Text = Trim(lvwEmploymentHistoryItem.SubItems(3).Text)
                    txtEmploymentCompanyAddress.Text = Trim(lvwEmploymentHistoryItem.SubItems(4).Text)
                    txtEmploymentContactNo.Text = Trim(lvwEmploymentHistoryItem.SubItems(5).Text)
                    txtMonthlySalary.Text = Format(Trim(lvwEmploymentHistoryItem.SubItems(6).Text), "Standard")
                    txtEmploymentTaskAccomplishment.Text = Trim(lvwEmploymentHistoryItem.SubItems(7).Text)
                Case "btnorganizationedit"
                    If lvwOrganization.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnOrganizationAdd.Text = "Update"
                    lvwMemberOrganizationItem = lvwOrganization.SelectedItems(0)

                    txtOrganizationName.Text = Trim(lvwMemberOrganizationItem.SubItems(0).Text)
                    txtOrganizationAddress.Text = Trim(lvwMemberOrganizationItem.SubItems(1).Text)
                    txtOrganizationPosition.Text = Trim(lvwMemberOrganizationItem.SubItems(2).Text)
                    dtpOrganizationSinceDt.Value = CDate(Trim(lvwMemberOrganizationItem.SubItems(3).Text))
                Case "btnseminaredit"
                    If lvwSeminarsAttended.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnSeminarAdd.Text = "Update"
                    lvwSeminarsAttendedItem = lvwSeminarsAttended.SelectedItems(0)

                    txtSeminarName.Text = Trim(lvwSeminarsAttendedItem.SubItems(0).Text)
                    txtSeminarLocation.Text = Trim(lvwSeminarsAttendedItem.SubItems(1).Text)
                    dtpSeminarDate.Value = CDate(Trim(lvwSeminarsAttendedItem.SubItems(2).Text))
                    txtSeminarRemarks.Text = Trim(lvwSeminarsAttendedItem.SubItems(3).Text)
                Case "btnfamilyedit"
                    If lvwFamilyBackground.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnFamilyAdd.Text = "Update"
                    lvwFamilyBackgroundItem = lvwFamilyBackground.SelectedItems(0)

                    txtSpouseFName.Text = Trim(lvwFamilyBackgroundItem.SubItems(0).Text)
                    txtSpouseMName.Text = Trim(lvwFamilyBackgroundItem.SubItems(1).Text)
                    txtSpouseLName.Text = Trim(lvwFamilyBackgroundItem.SubItems(2).Text)
                    txtSpouseSuffix.Text = Trim(lvwFamilyBackgroundItem.SubItems(3).Text)
                    dtpSpouseBirth.Value = CDate(Trim(lvwFamilyBackgroundItem.SubItems(4).Text))
                    txtFatherFName.Text = Trim(lvwFamilyBackgroundItem.SubItems(5).Text)
                    txtFatherMName.Text = Trim(lvwFamilyBackgroundItem.SubItems(6).Text)
                    txtFatherLName.Text = Trim(lvwFamilyBackgroundItem.SubItems(7).Text)
                    txtFatherSuffix.Text = Trim(lvwFamilyBackgroundItem.SubItems(8).Text)
                    txtMotherFName.Text = Trim(lvwFamilyBackgroundItem.SubItems(9).Text)
                    txtMotherMName.Text = Trim(lvwFamilyBackgroundItem.SubItems(10).Text)
                    txtMotherLName.Text = Trim(lvwFamilyBackgroundItem.SubItems(11).Text)
                Case "btnchildedit"
                    If lvwChildren.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnChildAdd.Text = "Update"
                    lvwChildrenItem = lvwChildren.SelectedItems(0)

                    txtChildFName.Text = Trim(lvwChildrenItem.SubItems(0).Text)
                    txtChildMName.Text = Trim(lvwChildrenItem.SubItems(1).Text)
                    txtChildLName.Text = Trim(lvwChildrenItem.SubItems(2).Text)
                    txtChildSuffix.Text = Trim(lvwChildrenItem.SubItems(3).Text)
                    dtpChildBirth.Value = CDate(Trim(lvwChildrenItem.SubItems(4).Text))
                    cboChildStatus.Text = Trim(lvwChildrenItem.SubItems(6).Text)
                Case "btnbeneficiaryedit"
                    If lvwOtherBeneficiary.SelectedItems.Count = 0 Then
                        clsCommon.Prompt_User("error", MSGBOX_LISTVIEWITEM_EDIT)
                        Exit Sub
                    End If

                    btnBeneficiaryAdd.Text = "Update"
                    lvwOtherBeneficiaryItem = lvwOtherBeneficiary.SelectedItems(0)

                    txtBeneficiaryFName.Text = Trim(lvwOtherBeneficiaryItem.SubItems(0).Text)
                    txtBeneficiaryMName.Text = Trim(lvwOtherBeneficiaryItem.SubItems(1).Text)
                    txtBeneficiaryLName.Text = Trim(lvwOtherBeneficiaryItem.SubItems(2).Text)
                    txtBeneficiarySuffix.Text = Trim(lvwOtherBeneficiaryItem.SubItems(3).Text)
                    txtBeneficiaryRelation.Text = Trim(lvwOtherBeneficiaryItem.SubItems(4).Text)
            End Select
        Else
        End If
    End Sub

    Private Sub cboJobTitle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboJobTitle.KeyPress, cboStatusAppointment.KeyPress, cboQualification.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.CapitalizeKeyPressString(e)
        End If
    End Sub

    Private Sub txtMonthlySalary_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonthlySalary.KeyPress, txtSalary.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.AcceptAmount(sender, e)
        End If
    End Sub

    Private Sub txtDepartmentName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartmentName.KeyPress, txtLGUName.KeyPress, txtReferredBy.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.DisAllow_Input(e)
        End If
    End Sub

    Private Sub txtDepartmentName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDepartmentName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtDepartmentId, e)
            clsCommon.Delete_TxtBox_Value(txtDepartmentName, e)
        End If
    End Sub

    Private Sub txtLGUName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLGUName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtLGUId, e)
            clsCommon.Delete_TxtBox_Value(txtLGUName, e)
        End If
    End Sub

    Private Sub txtReferredBy_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReferredBy.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtReferredByID, e)
            clsCommon.Delete_TxtBox_Value(txtReferredBy, e)
        End If
    End Sub

    Private Sub txtDepartmentName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDepartmentName.MouseUp, txtLGUName.MouseUp, txtReferredBy.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

    Private Sub lblLGUName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblLGUName.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            frmUseLGUFinder = New frmLGUFinder

            With frmUseLGUFinder
                Use_Record_State = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblDepartmentName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblDepartmentName.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            frmUseDepartmentFinder = New frmDepartmentFinder

            With frmUseDepartmentFinder
                Use_Record_State = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblReferredBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblReferredBy.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            frmUseConstituentFinder = clsConstituent.NewfrmConstituentFinder
            clsConstituent.UseRecordState = USE_STATE

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

    Private Sub frmUseLGUFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseLGUFinder.Use_Clicked
        If Record_Name Is Nothing OrElse Record_Desc Is Nothing Then
            Return
        End If
        Me.txtLGUName.Text = Record_Name
        Me.txtLGUId.Text = Record_Id
    End Sub

    Private Sub frmUseDepartmentFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseDepartmentFinder.Use_Clicked
        If Record_Name Is Nothing OrElse Record_Desc Is Nothing Then
            Return
        End If
        Me.txtDepartmentName.Text = Record_Name
        Me.txtDepartmentId.Text = Record_Id
    End Sub

    Private Sub frmUseConstituentFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String, ByVal Record_Desc As String) Handles frmUseConstituentFinder.Use_Clicked
        If Record_Name Is Nothing And Record_Cd Is Nothing Then
            Return
        End If

        clsConstituents = clsConstituent.NewclsConstituents
        With clsConstituents
            .Init_Flag = Record_Id
            .Selected_Record()
            txtReferredByID.Text = .constituent_Id
            txtReferredBy.Text = IIf((LCase(._constituentType) = "individual"), .last_Name & IIf(Len(.suffix_Name) > 0, " " & .suffix_Name, "") & ", " & .first_Name & " " & .middle_Name, .first_Name)
        End With
    End Sub

#End Region

    Private Sub PrintMemberProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintMemberProfileToolStripMenuItem.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsMemberReport As New DataSet
            Dim dtMember As DataTable
            Dim dtMemberFamily As DataTable
            Dim dtMemberChildren As DataTable
            'Dim dtMemberEducation As DataTable
            'Dim dtMemberEmployment As DataTable
            'Dim dtMemberOrganization As DataTable
            'Dim dtMemberBeneficiary As DataTable
            'Dim dtMemberSeminars As DataTable
            Dim dtSystemUser As DataTable

            With clsMember
                dtMember = .Populate_Record_Member
                dtMemberFamily = .Populate_Record_Family_Background
                dtMemberChildren = .Populate_Record_Children_Report
                'dtMemberEducation = .Populate_Record_Educational_Background
                'dtMemberEmployment = .Populate_Record_Employment_History
                'dtMemberOrganization = .Populate_Record_Member_Organization
                'dtMemberBeneficiary = .Populate_Record_Other_Beneficiary
                'dtMemberSeminars = .Populate_Record_Seminars_Attended
                dtSystemUser = .System_User_Report
            End With

            dtMember.TableName = "Member"
            dtMemberFamily.TableName = "Family"
            dtMemberChildren.TableName = "Children"
            'dtMemberEducation.TableName = "Education"
            'dtMemberEmployment.TableName = "Employment"
            'dtMemberOrganization.TableName = "Organization"
            'dtMemberBeneficiary.TableName = "Beneficiary"
            'dtMemberSeminars.TableName = "Seminars"
            dtSystemUser.TableName = "SystemUser"

            dsMemberReport.Tables.Add(dtMember)
            dsMemberReport.Tables.Add(dtMemberFamily)
            dsMemberReport.Tables.Add(dtMemberChildren)
            'dsMemberReport.Tables.Add(dtMemberEducation)
            'dsMemberReport.Tables.Add(dtMemberEmployment)
            'dsMemberReport.Tables.Add(dtMemberOrganization)
            'dsMemberReport.Tables.Add(dtMemberBeneficiary)
            'dsMemberReport.Tables.Add(dtMemberSeminars)
            dsMemberReport.Tables.Add(dtSystemUser)

            frmMemberDetailReportViewer = New frmCrystalReportViewer

            dsMemberReport.DataSetName = "crptMemberProfile"
            dsMemberReport.WriteXml(ReportDir + "\crptMemberProfile.xml", XmlWriteMode.WriteSchema)
            dsMemberReport.WriteXmlSchema(ReportDir + "\" + "crptMemberProfile.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmMemberDetailReportViewer
                    .ds = dsMemberReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberProfile.rpt"
                    .ReportTitle = "Member Profile"
                    .ShowInTaskbar = False
                    .DisplayGroupTree = False
                    .MaximizeBox = True
                    .WindowState = FormWindowState.Maximized
                    .MinimizeBox = False
                    .ShowDialog()
                End With
            Else
                clsCommon.Prompt_User("information", "There are no records available for the corresponding report.")
            End If
            Me.Cursor = Arrow
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub
End Class