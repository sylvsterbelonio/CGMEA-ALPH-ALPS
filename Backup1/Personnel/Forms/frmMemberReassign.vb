Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmMemberReassign
    Inherits System.Windows.Forms.Form

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsMemberReassign As New MemberManagement.MemberManagement
    Private WithEvents clsDepartment As New Department.Department
    Private WithEvents clsMember As New Member.Member
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmMemberReassignFinder
    Private WithEvents frmUseDepartmentFinder As frmDepartmentFinder
    Private WithEvents frmUseMemberFinder As frmMemberFinder
    Private WithEvents frmUseForMemberFinder As frmMemberFinder
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMemberReassign As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    Private KeyPressChar As Long

#Region "frmMemberReassign Main Form Private Sub"

    Private Sub frmMemberReassign_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsMemberReassign.Init_Flag = RecordId
            clsMemberReassign.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMemberReassign_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtMemberName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmMemberReassign_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmMemberReassign_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtDepartmentId.KeyPress, txtDepartmentName.KeyPress, txtMemberId.KeyPress, txtMemberIdToReplace.KeyPress, txtMemberName.KeyPress, txtMemberNameToReplace.KeyPress, txtRemarks.KeyPress, cboAppointmentId.KeyPress, cboJobId.KeyPress, cboJobTitle.KeyPress, cboStatusAppointment.KeyPress, dtpManagementDt.KeyPress
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

#Region "frmMemberReassign ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmMemberReassign As New frmMemberReassign
                    frmTitle = "Member Reassign"
                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColMemberReassign)
                        Set_Form_State()
                        RecordId = 0
                        Initialize_AutoComplete()
                        Me.Text = "Member Reassign"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmMemberReassign = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmMemberReassign.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColMemberReassign)
                            Set_Form_State()
                            RecordId = 0
                            Initialize_AutoComplete()
                            Me.Text = "Member Reassign"
                        End If
                    End If
                Case 1 'edit
edit_rec:
                    State = EDIT_STATE
                    Set_Form_State()
                Case 2 'delete
delete_rec:
                    If gRoleID <> 0 Then
                        frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
                        With frmLoginOverrideForm
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dim iAns
                                iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                                If iAns = vbYes Then
                                    With clsMemberReassign
                                        .Management_Id = RecordId
                                        .Management_Status = 0
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
                        iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                        If iAns = vbYes Then
                            With clsMemberReassign
                                .Management_Id = RecordId
                                .Management_Status = 0
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
                        Dim frmFinder As frmMemberReassignFinder
                        frmTitle = "Member Reassign Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtMemberNo.Focus()
                        Else
                            frmFinder = New frmMemberReassignFinder
                            With frmFinder
                                .Management_Id = 0
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
                        With clsMemberReassign
                            .Management_Id = RecordId
                            .Member_Id = IIf(Len(txtMemberId.Text) = 0, 0, Val(txtMemberId.Text.Replace(",", "")))
                            .Management_Status = 0
                            .ToDepartment_Id = IIf(Len(txtDepartmentId.Text) = 0, 0, Val(txtDepartmentId.Text.Replace(",", "")))
                            .To_Designation = Trim(cboJobTitle.Text)
                            .ToAppointment_Status = Trim(cboStatusAppointment.Text)
                            .ForMember_Id = IIf(Len(txtMemberIdToReplace.Text) = 0, 0, Val(txtMemberIdToReplace.Text.Replace(",", "")))
                            .ManagementDt_Fl = IIf(dtpManagementDt.Checked, 1, 0)
                            .TempManagement_Dt = dtpManagementDt.Value
                            .Management_Remarks = Trim(txtRemarks.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = .Management_Id
                                Set_Form_State()
                                txtUpdateDt.Text = .Updated_Dt
                                clsMember.Init_Flag = clsMemberReassign.Member_Id
                                clsMember.Selected_Record()
                                Me.Text = "Member Reassign - " & clsMember.Last_Name & IIf(Len(clsMember._suffixName) > 0, " " & clsMember._suffixName, "") & ", " & clsMember.First_Name & IIf(Len(clsMember.Middle_Name) > 0, " " & clsMember.Middle_Name, "")

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
                        Me.txtMemberName.Focus()
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

#Region "frmMemberReassign User Defined Private Sub"

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsMember
            dataCombo = .GetJobTitles

            clsCommon.PopulateComboBox(cboJobId, cboJobTitle, dataCombo)

            dataCombo = .GetAppointmentStatus

            clsCommon.PopulateComboBox(cboAppointmentId, cboStatusAppointment, dataCombo)
        End With
    End Sub

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Initialize_AutoComplete()
        Me.Text = "Member Reassign"
        Me.txtMemberName.Focus()
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(txtDepartmentId)
            .Add(txtDepartmentName)
            .Add(txtMemberId)
            .Add(txtMemberIdToReplace)
            .Add(txtMemberName)
            .Add(txtMemberNameToReplace)
            .Add(txtRemarks)
            .Add(cboAppointmentId)
            .Add(cboJobId)
            .Add(cboJobTitle)
            .Add(cboStatusAppointment)
            .Add(dtpManagementDt)

            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColMemberReassign
            .Add(txtDepartmentId)
            .Add(txtDepartmentName)
            .Add(txtMemberId)
            .Add(txtMemberIdToReplace)
            .Add(txtMemberName)
            .Add(txtMemberNameToReplace)
            .Add(txtRemarks)
            .Add(cboAppointmentId)
            .Add(cboJobId)
            .Add(cboJobTitle)
            .Add(cboStatusAppointment)
            .Add(dtpManagementDt)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColMemberReassign)

        Define_Required_Fields()
        Me.Text = "Member Reassign"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblMemberName)
            .Add(Me.lblDepartmentName)
            .Add(Me.lblMemberNameToReplace)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtMemberName)
            .Add(txtDepartmentName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsMemberReassign
            txtMemberId.Text = .Member_Id
            txtDepartmentId.Text = .ToDepartment_Id
            cboJobTitle.Text = .To_Designation
            cboStatusAppointment.Text = .ToAppointment_Status
            txtMemberIdToReplace.Text = .ForMember_Id

            Me.dtpManagementDt.Checked = IIf(.ManagementDt_Fl = 1, True, False)
            If dtpManagementDt.Checked Then
                Me.dtpManagementDt.Value = .TempManagement_Dt
            End If
            Me.txtRemarks.Text = .Management_Remarks

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Management_Id
        End With
        Me.txtMemberName.Focus()

        clsMember.Init_Flag = clsMemberReassign.Member_Id
        clsMember.Selected_Record()
        Me.Text = "Member Reassign - " & clsMember.Last_Name & IIf(Len(clsMember._suffixName) > 0, " " & clsMember._suffixName, "") & ", " & clsMember.First_Name & IIf(Len(clsMember.Middle_Name) > 0, " " & clsMember.Middle_Name, "")
        txtMemberName.Text = clsMember.Last_Name & IIf(Len(clsMember._suffixName) > 0, " " & clsMember._suffixName, "") & ", " & clsMember.First_Name & IIf(Len(clsMember.Middle_Name) > 0, " " & clsMember.Middle_Name, "")

        clsDepartment.Init_Flag = clsMemberReassign.ToDepartment_Id
        clsDepartment.Selected_Record()
        txtDepartmentName.Text = clsDepartment.Department_Name

        If clsMemberReassign.ForMember_Id > 0 Then
            clsMember.Init_Flag = clsMemberReassign.ForMember_Id
            clsMember.Selected_Record()
            txtMemberNameToReplace.Text = clsMember.Last_Name & IIf(Len(clsMember._suffixName) > 0, " " & clsMember._suffixName, "") & ", " & clsMember.First_Name & IIf(Len(clsMember.Middle_Name) > 0, " " & clsMember.Middle_Name, "")
        End If
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
        clsMemberReassign = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMemberReassign = Nothing
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        'If State = "View" Then
        '    lblLastName.Text = "Last Name"
        '    lblFirstName.Text = "First Name"
        '    'lblDesignation.Text = "Designation"
        '    'lblCTCNo.Text = "CTC No."
        'Else
        '    lblLastName.Text = "Last Name"
        '    'lblLastName.Text = "Last Name *"
        '    lblFirstName.Text = "First Name *"
        '    'lblDesignation.Text = "Designation *"
        '    'lblCTCNo.Text = "CTC No. *"
        'End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsMemberReassign.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        txtMemberName.Tag = "Member Name to Reassign"
        txtDepartmentName.Tag = "Department Name"
        'txtDesignation.Tag = "Designation"
        'txtCTCNo.Tag = "CTC No."
    End Sub

    Private Sub Set_Max_Length()
        Me.txtRemarks.MaxLength = 2000
    End Sub

    Private Sub txtMemberName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartmentName.KeyPress, txtMemberName.KeyPress, txtMemberNameToReplace.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.DisAllow_Input(e)
        End If
    End Sub

    Private Sub txtMemberName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMemberName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtMemberId, e)
            clsCommon.Delete_TxtBox_Value(txtMemberName, e)

        End If
    End Sub

    Private Sub txtMemberNameToReplace_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMemberNameToReplace.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtMemberIdToReplace, e)
            clsCommon.Delete_TxtBox_Value(txtMemberNameToReplace, e)

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

    Private Sub txtMemberName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDepartmentName.MouseUp, txtMemberName.MouseUp, txtMemberNameToReplace.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

#End Region

    Private Sub lblDepartmentName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDepartmentName.Click
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

    Private Sub lblMemberNameClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMemberName.Click
        Try
            frmUseMemberFinder = New frmMemberFinder

            With frmUseMemberFinder
                Use_Record_State = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblMemberNameToReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMemberNameToReplace.Click
        Try
            frmUseForMemberFinder = New frmMemberFinder

            With frmUseForMemberFinder
                Use_Record_State = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmUseDepartmentFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseDepartmentFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If

        With clsDepartment
            .Init_Flag = Record_Id
            .Selected_Record()

            txtDepartmentId.Text = .Department_ID
            txtDepartmentName.Text = .Department_Name
        End With
    End Sub

    Private Sub frmUseMemberFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String) Handles frmUseMemberFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If

        With clsMember
            .Init_Flag = Record_Id
            .Selected_Record()

            txtMemberId.Text = .Member_Id
            txtMemberName.Text = .Last_Name & IIf(Len(._suffixName) > 0, " " & ._suffixName, "") & ", " & .First_Name & IIf(Len(.Middle_Name) > 0, " " & .Middle_Name, "")
        End With
    End Sub

    Private Sub frmUseForMemberFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String) Handles frmUseForMemberFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If

        With clsMember
            .Init_Flag = Record_Id
            .Selected_Record()

            txtMemberIdToReplace.Text = .Member_Id
            txtMemberNameToReplace.Text = .Last_Name & IIf(Len(._suffixName) > 0, " " & ._suffixName, "") & ", " & .First_Name & IIf(Len(.Middle_Name) > 0, " " & .Middle_Name, "")
        End With
    End Sub

End Class