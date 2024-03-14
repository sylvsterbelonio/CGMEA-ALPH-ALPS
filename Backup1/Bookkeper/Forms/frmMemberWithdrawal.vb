Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmMemberWithdrawal
    Inherits System.Windows.Forms.Form

#Region "frmMemberWithdrawal Variable Declaration"
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsBookkeper As New Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsWithdrawal As New Withdrawal.Withdrawal
    Private WithEvents clsUtility As New Utility.Utility(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)

    Private WithEvents clsMember As New Personnel.Member.Member

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride
    Private WithEvents frmUseMemberFinder As Personnel.frmMemberFinder

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmMemberWithdrawalFinder
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColWithdrawal As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public withdrawalId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    Private KeyPressChar As Long
#End Region

#Region "frmMemberWithdrawal Main Form Private Sub"

    Private Sub frmMemberWithdrawal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsWithdrawal._initFlag = RecordId
            clsWithdrawal.Selected_Record()
            Assign_Data()
        ElseIf State = ADD_STATE Then
            With clsWithdrawal
                ._initFlag = withdrawalId
                .Selected_Record()

                txtWithdrawalId.Text = ._withdrawalId
                txtMemberId.Text = ._memberId
                txtMemberName.Text = ._memberName
                txtDepartment.Text = ._department
            End With
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMemberWithdrawal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                dtpWithrawDate.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmMemberWithdrawal_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmLoanApplicationRelease_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, dtpWithrawDate.KeyPress, txtRemarks.KeyPress
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

#Region "frmMemberWithdrawal ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmLoanApplicationRelease As New frmLoanApplicationRelease
                    frmTitle = "Withdrwal"
                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColWithdrawal)
                        Set_Form_State()
                        RecordId = 0
                        Me.Text = "Withdrawal"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmLoanApplicationRelease = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmLoanApplicationRelease.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColWithdrawal)
                            Set_Form_State()
                            RecordId = 0
                            Me.Text = "Withdrawal"
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
                                    With clsWithdrawal
                                        ._withdrawalId = RecordId
                                        ._updatedBy = gUserID
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
                            With clsWithdrawal
                                ._withdrawalId = RecordId
                                ._updatedBy = gUserID
                                If .Delete_Record() Then
                                    Me.Close()
                                End If
                            End With
                        End If
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmMemberWithdrawalFinder
                        frmTitle = "Withdrawal Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.dtpWithdrawnDate.Focus()
                        Else
                            frmFinder = New frmMemberWithdrawalFinder
                            With frmFinder
                                '._refId = 0
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
                        With clsWithdrawal
                            ._withdrawalId = RecordId
                            ._memberId = IIf(Len(txtMemberId.Text) = 0, 0, Val(txtMemberId.Text.Replace(",", "")))
                            ._voucherNo = Trim(txtVoucherNo.Text)
                            ._checkNo = Trim(txtCheckNo.Text)
                            ._receivedBy = Trim(txtReceivedBy.Text)
                            ._tempWithdrawnDate = dtpWithrawDate.Value
                            ._withdrawalRemarks = Trim(txtRemarks.Text)
                            ._updatedDt = txtUpdateDt.Text
                            ._updatedBy = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = ._withdrawalId
                                Set_Form_State()
                                txtUpdateDt.Text = ._updatedDt
                                Me.Text = "Withdrawal - " & Trim(txtMemberName.Text)

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
                                    ._initFlag = RecordId
                                    If .Selected_Record() Then
                                        Assign_Data()
                                    End If
                                End If
                            End If
                        End With
                        Me.Cursor = Arrow
                    Else
                        Me.dtpWithrawDate.Focus()
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

#Region "frmMemberWithdrawal User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Withdrawal"
        Me.dtpWithrawDate.Focus()
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(dtpWithrawDate)
            .Add(txtMemberName)
            .Add(txtVoucherNo)
            .Add(txtCheckNo)
            .Add(txtReceivedBy)
            .Add(txtCapitallAmount)
            .Add(txtRemarks)
            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Initialize_AutoComplete()
        'Dim dataCombo As DataSet
        'Dim dataComboRow As DataRow
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColWithdrawal
            .Add(txtWithdrawalId)
            .Add(dtpWithrawDate)
            .Add(txtMemberId)
            .Add(txtVoucherNo)
            .Add(txtCheckNo)
            .Add(txtCapitallAmount)
            .Add(txtReceivedBy)
            .Add(txtRemarks)
            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColWithdrawal)
        Define_Required_Fields()
        Me.Text = "Withdrawal"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblMemberName)
            .Add(Me.lblReceivedBy)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(dtpWithrawDate)
            .Add(txtVoucherNo)
            .Add(txtCheckNo)
            .Add(txtCapitallAmount)
            .Add(txtReceivedBy)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsWithdrawal
            txtWithdrawalId.Text = ._withdrawalId
            txtVoucherNo.Text = ._voucherNo
            txtCheckNo.Text = ._checkNo
            txtCapitallAmount.Text = ._capitalAmount
            dtpWithrawDate.Value = ._withdrawnDate

            txtRemarks.Text = ._withdrawalRemarks

            txtMemberId.Text = ._memberId
            If Val(txtMemberId.Text.Replace(",", "")) = -1 Then
                txtMemberName.Text = ""
            Else
                With clsMember
                    .Init_Flag = IIf((Len(txtMemberId.Text.Replace(",", "")) = 0), 0, Val(txtMemberId.Text.Replace(",", "")))
                    .Selected_Record()
                    txtMemberName.Text = .Last_Name & IIf(Len(._suffixName) > 0, " " & ._suffixName, "") & ", " & .First_Name & " " & .Middle_Name
                End With
            End If

            txtUpdateDt.Text = ._updatedDt
            RecordId = ._withdrawalId
        End With

        With clsWithdrawal
            ._initFlag = clsWithdrawal._withdrawalId
            .Selected_Record()
            txtMemberName.Text = ._memberName
            txtDepartment.Text = ._department
        End With
        dtpWithrawDate.Focus()

        Me.Text = "Withdrawal - " & Trim(txtMemberName.Text)
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
        clsWithdrawal = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColWithdrawal = Nothing
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblMemberName.Text = "Account Name"
            lblVoucherNo.Text = "Voucher No."
            lblCheckNo.Text = "Check No."
            lblCapitalAmount.Text = "Capital Amount"
            lblWithdrawDate.Text = "Withdraw Date"
            lblReceivedBy.Text = "Received By"
        Else
            lblMemberName.Text = "Account Name *"
            lblVoucherNo.Text = "Voucher No. *"
            lblCheckNo.Text = "Check No. *"
            lblCapitalAmount.Text = "Capital Amount *"
            lblWithdrawDate.Text = "Withdraw Date *"
            lblReceivedBy.Text = "Received By *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsWithdrawal.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        txtMemberName.Tag = "Account Name"
        txtVoucherNo.Tag = "Voucher No."
        txtCheckNo.Tag = "Check No."
        txtCapitallAmount.Tag = "Capital Amount"
        dtpWithrawDate.Tag = "Withdraw Date"
        txtReceivedBy.Tag = "Received By"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtRemarks.MaxLength = 2000
        Me.txtVoucherNo.MaxLength = 20
        Me.txtCheckNo.MaxLength = 20
        Me.txtCapitallAmount.MaxLength = 20
        Me.txtReceivedBy.MaxLength = 255
    End Sub

    Private Sub txtMemberName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemberName.KeyPress
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
            clsCommon.Delete_TxtBox_Value(txtDepartment, e)
            clsCommon.Delete_TxtBox_Value(txtCurrentShare, e)
        End If
    End Sub

    Private Sub txtMemberName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMemberName.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

#End Region

#Region "frmMemberWithdrawal Label Piping Click"

    Private Sub lblMemberName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMemberName.Click
        Try
            frmUseMemberFinder = New Personnel.frmMemberFinder

            With frmUseMemberFinder
                clsBookkeper.UseRecordState = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "frmMemberWithdrawal Handle Piping"

    Private Sub ValidateMember(ByVal ColName As String)
        Try
            Dim mydata As New DataTable
            Dim mydataCon As New DataTable

            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblmember WHERE CONCAT(lastName, IF(LENGTH(suffixName),' ',''),suffixName,', ',firstName, ' ',middleName) = '" & txtMemberName.Text & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)

            If mydata.Rows.Count <> 0 Then

                clsMember = clsPersonnel.NewclsMember
                With clsMember
                    mydataCon = clsDataAccess.ExecuteQuery("SELECT COUNT(1) as recCount FROM tblmembercontribution WHERE feeId = 2 AND cancelFl = 0 AND memberId = " & CInt(mydata.Rows(0).Item("memberId")) & ";", True, RETURN_TYPE_DATATABLE)
                    If mydataCon.Rows(0).Item("recCount") > 1 Then
                        .Init_Flag = mydata.Rows(0).Item("memberId")
                        .Selected_Record()
                        txtMemberId.Text = .Member_Id

                        If Len(.Department_Name) > 0 Then
                            txtDepartment.Text = .Department_Name
                        Else
                            txtDepartment.Text = ""
                            'Exit Sub
                        End If
                        txtCurrentShare.Text = Format(clsWithdrawal.GetTotalMemberContribution(2, CInt(txtMemberId.Text)), "Standard")
                    Else
                        'MsgBox(txtMember.Text & " still not allowed to apply this loan. " & vbCrLf & "Number of montly contributions: " & CInt(mydataCon.Rows(0).Item("recCount")), MsgBoxStyle.Information)
                    End If
                End With
            Else
                txtMemberId.Name = ""
                txtDepartment.Text = ""
            End If
        Catch ex As Exception
            ''nothing
        End Try
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtCapitallAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCapitallAmount.TextChanged
        txtInterestIncome.Text = Format(CDbl(txtCapitallAmount.Text) * 0.02, "Standard")
        txtNetProceeds.Text = Format(CDbl(txtCapitallAmount.Text) - CDbl(txtInterestIncome.Text), "Standard")
    End Sub
End Class