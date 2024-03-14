Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmSignatory
    Inherits System.Windows.Forms.Form

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsSignatory As New Signatory.Signatory
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsDepartment As Personnel.Department.Department
    Private WithEvents clsMember As Personnel.Member.Member
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmSignatoryFinder
    Private WithEvents frmUseDepartmentFinder As Personnel.frmDepartmentFinder = Nothing
    Private WithEvents frmUseMemberFinder As Personnel.frmMemberFinder = Nothing
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColSignatory As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    Private KeyPressChar As Long

#Region "frmSignatory Main Form Private Sub"

    Private Sub frmSignatory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsSignatory.Init_Flag = RecordId
            clsSignatory.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmSignatory_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtLastName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmSignatory_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmSignatory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtDesignation.KeyPress, txtFirstName.KeyPress, txtLastName.KeyPress, txtMiddleName.KeyPress, txtRemarks.KeyPress, txtSuffix.KeyPress, txtDepartmentId.KeyPress, txtDepartmentName.KeyPress, txtMemberId.KeyPress, txtMemberNo.KeyPress
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

#Region "frmSignatory ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmSignatory As New frmSignatory
                    frmTitle = "Signatory"
                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColSignatory)
                        Set_Form_State()
                        RecordId = 0
                        Me.Text = "Signatory"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmSignatory = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmSignatory.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColSignatory)
                            Set_Form_State()
                            RecordId = 0
                            Me.Text = "Signatory"
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
                                    With clsSignatory
                                        ._signatoryId = RecordId
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
                            With clsSignatory
                                ._signatoryId = RecordId
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
                        Dim frmFinder As frmSignatoryFinder
                        frmTitle = "Signatory Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtFirstName.Focus()
                        Else
                            frmFinder = New frmSignatoryFinder
                            With frmFinder
                                ._SignatoryId = 0
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
                        With clsSignatory
                            ._signatoryId = RecordId
                            ._lname = Trim(txtLastName.Text)
                            ._fname = Trim(txtFirstName.Text)
                            ._mname = Trim(txtMiddleName.Text)
                            ._suffix = Trim(txtSuffix.Text)
                            ._designation = Trim(txtDesignation.Text)
                            ._departmentId = IIf(Len(txtDepartmentId.Text) = 0, 0, Val(txtDepartmentId.Text.Replace(",", "")))
                            ._memberId = IIf(Len(txtMemberId.Text) = 0, 0, Val(txtMemberId.Text.Replace(",", "")))
                            ._remarks = Trim(txtRemarks.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = ._signatoryId
                                Set_Form_State()
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Signatory - " & Trim(txtFirstName.Text) & IIf(Len(txtMiddleName.Text) > 0, " " & Trim(txtMiddleName.Text), "") & " " & Trim(txtLastName.Text) & IIf(Len(txtSuffix.Text) > 0, ", " & Trim(txtSuffix.Text), "") & " [" & txtDepartmentName.Text & "]"

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
                        Me.txtLastName.Focus()
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

#Region "frmSignatory User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Signatory"
        Me.txtLastName.Focus()
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(txtDesignation)
            .Add(txtFirstName)
            .Add(txtLastName)
            .Add(txtMiddleName)
            .Add(txtRemarks)
            .Add(txtSuffix)
            .Add(txtDepartmentId)
            .Add(txtDepartmentName)
            .Add(txtMemberId)
            .Add(txtMemberNo)

            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColSignatory
            .Add(txtDesignation)
            .Add(txtFirstName)
            .Add(txtLastName)
            .Add(txtMiddleName)
            .Add(txtRemarks)
            .Add(txtSuffix)
            .Add(txtDepartmentId)
            .Add(txtDepartmentName)
            .Add(txtMemberId)
            .Add(txtMemberNo)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColSignatory)

        Define_Required_Fields()
        Me.Text = "Signatory"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblDepartmentName)
            .Add(lblMemberNo)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            '.Add(txtLastName)
            .Add(txtFirstName)
            '.Add(txtDepartmentName)
            '.Add(txtDesignation)
            '.Add(txtCTCNo)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsSignatory
            txtLastName.Text = ._lname
            txtFirstName.Text = ._fname
            txtMiddleName.Text = ._mname
            txtSuffix.Text = ._suffix
            txtDesignation.Text = ._designation
            txtDepartmentId.Text = ._departmentId
            txtDepartmentName.Text = ._departmentName
            txtMemberId.Text = ._memberId
            txtMemberNo.Text = ._memberNo
            txtRemarks.Text = ._remarks

            txtUpdateDt.Text = .Updated_Dt
            RecordId = ._signatoryId
        End With
        Me.txtLastName.Focus()

        Me.Text = "Signatory - " & Trim(txtFirstName.Text) & IIf(Len(txtMiddleName.Text) > 0, " " & Trim(txtMiddleName.Text), "") & " " & Trim(txtLastName.Text) & IIf(Len(txtSuffix.Text) > 0, ", " & Trim(txtSuffix.Text), "") & " [" & txtDepartmentName.Text & "]"
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
        clsSignatory = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColSignatory = Nothing
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            'lblLastName.Text = "Last Name"
            lblFirstName.Text = "First Name"
            'lblDesignation.Text = "Designation"
            'lblCTCNo.Text = "CTC No."
        Else
            'lblLastName.Text = "Last Name *"
            lblFirstName.Text = "First Name *"
            'lblDesignation.Text = "Designation *"
            'lblCTCNo.Text = "CTC No. *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsSignatory.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        'txtLastName.Tag = "Last Name"
        txtFirstName.Tag = "First Name"
        'txtDepartmentName.Tag = "Department Name"
        'txtDesignation.Tag = "Designation"
        'txtCTCNo.Tag = "CTC No."
    End Sub

    Private Sub Set_Max_Length()
        txtLastName.MaxLength = 255
        txtFirstName.MaxLength = 255
        txtMiddleName.MaxLength = 255
        txtSuffix.MaxLength = 255
        txtDesignation.MaxLength = 255
        Me.txtRemarks.MaxLength = 2000
    End Sub

    Private Sub txtDepartmentName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDepartmentName.KeyPress, txtMemberNo.KeyPress
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

    Private Sub txtMemberNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMemberNo.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtMemberId, e)
            clsCommon.Delete_TxtBox_Value(txtMemberNo, e)

        End If
    End Sub

    Private Sub txtDepartmentName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtDepartmentName.MouseUp, txtMemberNo.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

#End Region

    Private Sub lblDepartmentName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblDepartmentName.Click
        Try
            frmUseDepartmentFinder = clsPersonnel.NewfrmDepartmentFinder
            clsPersonnel.UseRecordState = USE_STATE

            With frmUseDepartmentFinder
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblMemberNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMemberNo.Click
        Try
            frmUseMemberFinder = clsPersonnel.NewfrmMemberFinder
            clsPersonnel.UseRecordState = USE_STATE

            With frmUseMemberFinder
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

        clsDepartment = clsPersonnel.NewclsDepartment
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

        clsMember = clsPersonnel.NewclsMember
        With clsMember
            .Init_Flag = Record_Id
            .Selected_Record()

            txtMemberId.Text = .Member_Id
            txtMemberNo.Text = .Member_No
            txtLastName.Text = .Last_Name
            txtFirstName.Text = .First_Name
            txtMiddleName.Text = .Middle_Name
            txtSuffix.Text = ._suffixName
            txtDepartmentId.Text = .Department_Id
            txtDepartmentName.Text = .Department_Name
            txtDesignation.Text = .Job_Description
        End With
    End Sub

End Class