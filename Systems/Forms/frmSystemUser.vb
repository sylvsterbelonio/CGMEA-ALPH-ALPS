Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmSystemUser
    Inherits System.Windows.Forms.Form

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsSystemUser As New SystemUser.SystemUser
    Private WithEvents clsSystemAccessLevel As New SystemAccessLevel.SystemAccessLevel
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMember As Personnel.Member.Member

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmSystemUserFinder
    Private WithEvents frmUseSystemAccessLevelFinder As frmSystemAccessLevelFinder
    Private WithEvents frmUseMemberFinder As Personnel.frmMemberFinder = Nothing
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox
    'Private cboRoleId As New ComboBox
    Private cboJobId As New ComboBox
    Private MemberActiveFl As Integer

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColSystemUser As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String

    'Declaration of SQL Related functions
    'Private dsRole As DataSet
    Private dsJob As DataSet

    Private KeyPressChar As Long

#Region "frmSystemUser Main Form Private Sub"

    Private Sub frmSystemUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsSystemUser.Init_Flag = RecordId
            clsSystemUser.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmSystemUser_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtFName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmSystemUser_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmSystemUser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtMemberId.KeyPress, txtMemberNo.KeyPress, txtFileName.KeyPress, txtFName.KeyPress, txtLName.KeyPress, txtMName.KeyPress, txtPassword.KeyPress, txtRoleId.KeyPress, txtRoleName.KeyPress, txtUserName.KeyPress, txtVerify.KeyPress, dtBDate.KeyPress, cboGender.KeyPress, cboJobTitle.KeyPress, cboStatus.KeyPress, btnPicture.KeyPress, btnPassword.KeyPress, chkActive.KeyPress
        Dim tbArgs As ToolBarButtonClickEventArgs

        KeyPressChar = e.KeyChar.GetHashCode
        Select Case KeyPressChar
            Case 65537 ' press ctrl+a
                If Me.tbrMainForm.Buttons(0).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(0))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 327685 'press ctrl+e
                If Me.tbrMainForm.Buttons(1).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(1))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 262148 'press ctrl+d
                If Me.tbrMainForm.Buttons(2).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(2))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                    Exit Sub
                End If
            Case 393222 'press ctrl+f
                If Me.tbrMainForm.Buttons(3).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(3))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1245203 'press ctrl+s
                If Me.tbrMainForm.Buttons(4).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(4))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1769499 ' press esc
                If Me.tbrMainForm.Buttons(5).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(5))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 983055 ' press ctrl+o
                If Me.tbrMainForm.Buttons(6).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(6))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
        End Select

    End Sub

#End Region

#Region "frmSystemUser ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmSystemUser As New frmSystemUser
                    frmTitle = "System User"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmSystemUser = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmSystemUser.Activate()
                        'NwfrmSystemUser.btnPassword.SendToBack()
                        NwfrmSystemUser.btnPassword.Visible = False
                    Else
                        State = ADD_STATE
                        clsCommon.ClearControls(ColSystemUser)
                        Set_Form_State()
                        ClearImage()
                        cboGender.SelectedIndex = 0
                        cboStatus.SelectedIndex = 0
                        chkActive.Checked = True
                        'btnPassword.SendToBack()
                        btnPassword.Visible = False
                        RecordId = 0
                        Me.Text = "System User"
                    End If
                Case 1 'edit
edit_rec:
                    If MemberActiveFl = 0 Then
                        clsCommon.Prompt_User("information", "You are not allowed to edit the current system user. The linked member record has already been set inactive.")
                        Exit Sub
                    Else
                        State = EDIT_STATE
                        Set_Form_State()
                    End If
                Case 2 'delete
delete_rec:
                    If chkActive.CheckState = CheckState.Unchecked Then
                        clsCommon.Prompt_User("information", "The current user account record has already been set inactive.")
                        Exit Sub
                    Else
                        Dim iAns
                        iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                        If iAns = vbYes Then
                            With clsSystemUser
                                .User_ID = RecordId
                                .Updated_By = gUserID
                                If .Delete_Record() Then
                                    Me.Close()
                                End If
                            End With
                        End If
                    End If
                Case 3 'find
find_rec:
                    Dim frmFinder As frmSystemUserFinder
                    frmTitle = "System User Finder"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        frmFinder.Activate()
                        frmFinder.ActiveControl = frmFinder.btnSearch
                        frmFinder.btnSearch.PerformClick()
                        frmFinder.txtFName.Focus()
                    Else
                        frmFinder = New frmSystemUserFinder
                        With frmFinder
                            .User_Id = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        If User_Validation() Then
                            With clsSystemUser
                                .User_ID = RecordId
                                .User_Name = txtUserName.Text
                                .Role_ID = IIf(Len(txtRoleId.Text) = 0, 0, Val(txtRoleId.Text.Replace(",", "")))
                                .Passwd = clsCommon.Crypt(txtPassword.Text)
                                .Member_Id = IIf(Len(txtMemberId.Text) = 0, 0, Val(txtMemberId.Text.Replace(",", "")))
                                .Active_fl = chkActive.CheckState

                                .Updated_Dt = txtUpdateDt.Text
                                .Updated_By = gUserID
                                If .Save_Record() Then
                                    State = VIEW_STATE
                                    RecordId = .User_ID
                                    Set_Form_State()
                                    txtUpdateDt.Text = .Updated_Dt
                                    If (RecordId = 0) Then
                                        Me.Text = "System User - System Administrator"
                                    Else
                                        Me.Text = "System User - " & txtLName.Text & ", " & txtFName.Text & " " & txtMName.Text & " (" & txtRoleName.Text & ")"
                                    End If

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
                        End If
                        Me.Cursor = Arrow
                    Else
                        Me.txtRoleName.Focus()
                    End If
                Case 5 'cancel
cancel_rec:
                    If RecordId = 0 Then
                        Me.Close()
                    Else
                        Dim iAns

                        iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
                        If iAns = vbNo Then
                            Exit Sub
                        End If

                        With clsSystemUser
                            State = VIEW_STATE
                            .Init_Flag = RecordId
                            If .Selected_Record() Then
                                Assign_Data()
                            End If
                            Set_Form_State()
                        End With
                    End If
                Case 6 'approve
approve_rec:
            End Select
            '------------------------------------------------------------------------------
        Else
            'form KeyPress
            '------------------------------------------------------------------------------
            Select Case KeyPressChar
                Case 65537 ' press ctrl+a
                    GoTo add_rec
                Case 327685 'press ctrl+e
                    GoTo edit_rec
                Case 262148 'press ctrl+d
                    GoTo delete_rec
                Case 393222 'press ctrl+f
                    GoTo find_rec
                Case 1245203 'press ctrl+s
                    GoTo save_rec
                Case 1769499 ' press esc
                    GoTo cancel_rec
                Case 983055 ' press ctrl+o
                    GoTo approve_rec
            End Select
            '------------------------------------------------------------------------------
        End If

    End Sub

#End Region

#Region "frmSystemUser User Defined Private Sub"

    Private Sub Initialize_Form()
        With clsSystemUser
            'dsRole = .GetRoleNames
            'clsCommon.PopulateComboBox(cboRoleId, cboRoleName, dsRole)

            dsJob = .GetJobTitles
            clsCommon.PopulateComboBox(cboJobId, cboJobTitle, dsJob)
        End With

        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        chkActive.Checked = True
        Me.Text = "System User"
        Me.txtRoleName.Focus()
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            '.Add(Me.cboRoleName)
            .Add(txtRoleName)
            .Add(txtRoleId)
            .Add(Me.txtUserName)
            .Add(Me.txtPassword)
            .Add(Me.txtVerify)
            .Add(Me.txtMemberNo)
            If State <> ADD_STATE Then
                .Add(Me.chkActive)
            End If
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColSystemUser
            .Add(Me.txtUserName)
            .Add(Me.txtPassword)
            .Add(Me.txtVerify)
            .Add(txtRoleName)
            .Add(txtRoleId)
            .Add(Me.txtMemberNo)
            .Add(Me.txtFName)
            .Add(Me.txtMName)
            .Add(Me.txtLName)
            .Add(Me.cboJobTitle)
            .Add(Me.dtBDate)
            .Add(Me.chkActive)
            .Add(txtUpdateDt)
            .Add(Me.cboGender)
            .Add(Me.cboJobTitle)
            '.Add(Me.cboRoleName)
            .Add(Me.cboStatus)
            .Add(Me.btnPicture)
        End With
        clsCommon.ClearControls(ColSystemUser)
        Define_Required_Fields()
        Me.Text = "System User"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(lblRole)
            .Add(Me.lblMemberNo)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            '.Add(cboRoleName)
            .Add(txtRoleName)
            .Add(txtUserName)
            .Add(txtMemberNo)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsSystemUser
            Me.txtFileName.Text = .member_Photo

            If File.Exists(txtFileName.Text) Then
                Dim image1 As Bitmap = New Bitmap(txtFileName.Text)
                btnPicture.BackgroundImage = image1
                btnPicture.BackgroundImageLayout = ImageLayout.Zoom
                cmnuClear.Enabled = True
            Else
                ClearImage()
                cmnuClear.Enabled = False
            End If

            'Me.cboRoleName.Text = .Role_Name
            txtRoleName.Text = .Role_Name
            txtRoleId.Text = .Role_ID
            Me.txtUserName.Text = .User_Name
            Me.txtPassword.Text = clsCommon.Crypt(.Passwd)
            Me.txtVerify.Text = clsCommon.Crypt(.Passwd)
            Me.txtMemberId.Text = .Member_Id
            Me.txtMemberNo.Text = .Member_No
            Me.txtFName.Text = .First_Name
            Me.txtMName.Text = .Middle_Name
            Me.txtLName.Text = .Last_Name
            Me.cboJobTitle.Text = .Job_Description
            Me.dtBDate.Value = .member_Birthdate
            Me.cboGender.Text = .member_Gender
            Me.cboStatus.Text = .Marital_Status
            Me.chkActive.CheckState = .Active_fl
            MemberActiveFl = .MemberActive_fl

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .User_ID
        End With
        'Me.cboRoleName.Focus()
        txtRoleName.Focus()

        If RecordId = 0 Then
            Me.Text = "System User - System Administrator"
        Else
            Me.Text = "System User - " & txtLName.Text & ", " & txtFName.Text & " " & txtMName.Text & " (" & txtRoleName.Text & ")"
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
        clsSystemUser = Nothing
        clsCommon = Nothing
        ColSystemUser = Nothing
        ColRequired = Nothing
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)

        If State = "View" Then
            'lblRole.Text = "System Role"
            lblUserName.Text = "User Name"
        Else
            'lblRole.Text = "System Role *"
            lblUserName.Text = "User Name *"
        End If

        txtVerify.Visible = (State = ADD_STATE)
        lblVerify.Visible = (State = ADD_STATE)
        btnPassword.Visible = (State <> ADD_STATE)

        If State <> ADD_STATE Then
            With clsSystemUser
                .Init_Flag = RecordId
                If .Selected_Record Then
                    btnPassword.Visible = ((Len(.User_Name) > 0))
                    btnPassword.Enabled = ((State = EDIT_STATE) And (Len(.User_Name) > 0))
                    txtPassword.TabStop = Not ((State = EDIT_STATE) And (Len(.User_Name) > 0))
                    txtVerify.TabStop = Not ((State = EDIT_STATE) And (Len(.User_Name) > 0))

                    txtVerify.Visible = Not (Len(.User_Name) > 0)
                    lblVerify.Visible = Not (Len(.User_Name) > 0)
                End If
            End With
        End If
        If State = EDIT_STATE And txtUserName.Text.Trim.ToLower = LCase("administrator") Then
            'cboRoleName.Enabled = False
            txtRoleName.ReadOnly = True
            txtUserName.ReadOnly = True
            chkActive.Enabled = False
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsSystemUser.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        'Me.cboRoleName.Tag = "System User Role"
        Me.txtRoleName.Tag = "System User Role"
        Me.txtUserName.Tag = "System User Name"
        Me.txtMemberNo.Tag = "Member Details"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtUserName.MaxLength = 20
        Me.txtPassword.MaxLength = 14
        Me.txtVerify.MaxLength = 14
    End Sub

    Private Sub dtBDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtBDate.ValueChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Dim intAge As Integer = CInt(clsCommon.GetAge(dtBDate.Value.Date))

        If intAge < 100 And intAge > 0 Then
            lblAge.Text = "( " & clsCommon.GetAge(dtBDate.Value.Date) & " )"
        ElseIf intAge < 0 Then
            lblAge.Text = "( - )"
        ElseIf intAge > 100 Then
            lblAge.Text = "( 100+ )"
        End If
    End Sub

    Public Function User_Validation() As Boolean
        User_Validation = True
        If Len(txtUserName.Text) > 0 Then
            If txtPassword.Text = "" Then
                clsCommon.Prompt_User("error", MSGBOX_PROVIDE_PASSWORD)
                User_Validation = False
                Exit Function
            ElseIf txtPassword.Text <> txtVerify.Text Then
                clsCommon.Prompt_User("error", MSGBOX_VERIFY_PASSWORD)
                txtPassword.Text = ""
                txtVerify.Text = ""
                txtPassword.Focus()
                User_Validation = False
                Exit Function
            End If
        Else
            If Len(txtPassword.Text) > 0 Or Len(txtVerify.Text) > 0 Then
                clsCommon.Prompt_User("error", MSGBOX_PROVIDE_USERNAME)
                User_Validation = False
                Exit Function
            End If
        End If
    End Function

    Private Sub btnPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        txtPassword.Text = ""
        txtVerify.Text = ""
        txtPassword.TabStop = True
        txtVerify.TabStop = True
        txtVerify.Visible = True
        lblVerify.Visible = True
        txtPassword.Focus()
        btnPassword.Visible = False
    End Sub

    'Private Sub cboRoleName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRoleName.SelectedIndexChanged
    '    Me.cboRoleId.SelectedIndex = Me.cboRoleName.SelectedIndex
    'End Sub

    Public Sub ClearImage()
        Dim image1 As Bitmap = New Bitmap(Me.GetType, "blank-user.gif")
        btnPicture.BackgroundImage = image1
        btnPicture.BackgroundImageLayout = ImageLayout.Zoom
        txtFileName.Text = ""
    End Sub

    Private Sub txtMemberNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemberNo.KeyPress, txtRoleName.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.DisAllow_Input(e)
        End If
    End Sub

    Private Sub txtMemberNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMemberNo.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtMemberId, e)
            clsCommon.Delete_TxtBox_Value(txtMemberNo, e)
            clsCommon.Delete_TxtBox_Value(txtFName, e)
            clsCommon.Delete_TxtBox_Value(txtMName, e)
            clsCommon.Delete_TxtBox_Value(txtLName, e)

            cboJobTitle.Text = ""
            dtBDate.Value = Now()
            ClearImage()
            cboGender.SelectedIndex = 0
            cboStatus.SelectedIndex = 0
            chkActive.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub txtRoleName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRoleName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtRoleId, e)
            clsCommon.Delete_TxtBox_Value(txtRoleName, e)
        End If
    End Sub

    Private Sub txtMemberNo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMemberNo.MouseUp, txtRoleName.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

#End Region

#Region "frmSystemUser Label Piping Click"

    Private Sub lblMemberName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMemberNo.Click
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

    Private Sub lblRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRole.Click
        Try
            frmUseSystemAccessLevelFinder = New frmSystemAccessLevelFinder

            With frmUseSystemAccessLevelFinder
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

#Region "frmSystemUser Handle Piping"

    Private Sub frmUseMemberFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String) Handles frmUseMemberFinder.Use_Clicked
        If Record_Name Is Nothing OrElse Record_Cd Is Nothing Then
            Return
        End If

        clsMember = clsPersonnel.NewclsMember
        With clsMember
            .Init_Flag = Record_Id
            .Selected_Record()

            If .Active_Fl = 0 Then
                clsCommon.Prompt_User("information", "Can not create a user account from selected member record. This member record has already been set inactive.")
                Exit Sub
            Else
                Me.txtFileName.Text = .Member_Photo

                If File.Exists(txtFileName.Text) Then
                    Dim image1 As Bitmap = New Bitmap(txtFileName.Text)
                    btnPicture.BackgroundImage = image1
                    btnPicture.BackgroundImageLayout = ImageLayout.Zoom
                    cmnuClear.Enabled = True
                Else
                    ClearImage()
                    cmnuClear.Enabled = False
                End If

                Me.txtMemberId.Text = .Member_Id
                Me.txtMemberNo.Text = .Member_No
                Me.txtFName.Text = .First_Name
                Me.txtMName.Text = .Middle_Name
                Me.txtLName.Text = .Last_Name
                Me.cboJobTitle.Text = .Job_Description
                Me.dtBDate.Value = .Member_Birthdate
                Me.cboGender.Text = .Member_Gender
                Me.cboStatus.Text = .Marital_Status
                Me.chkActive.CheckState = .Active_Fl
            End If
        End With
    End Sub

    Private Sub frmUseSystemAccessLevelFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String) Handles frmUseSystemAccessLevelFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If
        Me.txtRoleName.Text = Record_Name
        Me.txtRoleId.Text = Record_Id
    End Sub

#End Region


End Class