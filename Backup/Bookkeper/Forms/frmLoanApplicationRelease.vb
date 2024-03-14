Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmLoanApplicationRelease
    Inherits System.Windows.Forms.Form

#Region "frmLoanApplicationRelease Variable Declaration"
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsBookkeper As New Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsLoanApplicationRelease As New LoanApplicationRelease.LoanApplicationRelease
    Private WithEvents clsLoanApplication As New LoanApplication.LoanApplication
    Private WithEvents clsUtility As New Utility.Utility(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsSignatory As Utility.Signatory.Signatory

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride
    Private WithEvents frmUseSignatoryFinder As Utility.frmSignatoryFinder

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmLoanApplicationReleaseFinder
    Private WithEvents frmUseLoanApplicationFinder As frmLoanApplicationFinder
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColLoanApplicationRelease As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public releasedLoanId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    Private KeyPressChar As Long
#End Region

#Region "frmLoanApplicationRelease Main Form Private Sub"

    Private Sub frmLoanApplicationRelease_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsLoanApplicationRelease.Init_Flag = RecordId
            clsLoanApplicationRelease.Selected_Record()
            Assign_Data()
        ElseIf State = ADD_STATE Then
            With clsLoanApplication
                .Init_Flag = releasedLoanId
                .Selected_Record()

                If ._cancelFl = 1 Then
                    clsCommon.Prompt_User("information", "Can not approve selected loan application record." & vbCrLf & "The loan application has already been cancelled.")
                    Exit Sub
                End If

                If ._closedFl = 1 Then
                    clsCommon.Prompt_User("information", "Can not approve selected loan application record." & vbCrLf & "The loan application has already been tagged as closed.")
                    Exit Sub
                End If

                txtLoanId.Text = ._loanId
                txtLoanNo.Text = ._loanNo
                txtMemberName.Text = ._memberName
                txtDepartment.Text = ._departmentName
                txtLoanType.Text = ._loanType
                txtPrincipalAmount.Text = Format(._principalAmount, "Standard")
            End With
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmLoanApplicationRelease_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtLoanNo.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmLoanApplicationRelease_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmLoanApplicationRelease_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtLoanNo.KeyPress, dtpReleasedDate.KeyPress, txtRemarks.KeyPress
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

#Region "frmLoanApplicationRelease ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmLoanApplicationRelease As New frmLoanApplicationRelease
                    frmTitle = "Loan Application Release"
                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColLoanApplicationRelease)
                        Set_Form_State()
                        RecordId = 0
                        Me.Text = "Loan Application Release"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmLoanApplicationRelease = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmLoanApplicationRelease.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColLoanApplicationRelease)
                            Set_Form_State()
                            RecordId = 0
                            Me.Text = "Loan Application Release"
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
                                    With clsLoanApplicationRelease
                                        ._releasedId = RecordId
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
                            With clsLoanApplicationRelease
                                ._releasedId = RecordId
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
                        Dim frmFinder As frmLoanApplicationReleaseFinder
                        frmTitle = "Loan Application Release Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtLoanNo.Focus()
                        Else
                            frmFinder = New frmLoanApplicationReleaseFinder
                            With frmFinder
                                ._refId = 0
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
                        With clsLoanApplicationRelease
                            ._releasedId = RecordId
                            ._loanId = IIf(Len(txtLoanId.Text) = 0, 0, Val(txtLoanId.Text.Replace(",", "")))
                            ._releasedFl = IIf(dtpReleasedDate.Checked, 1, 0)
                            ._voucherNo = Trim(txtVoucherNo.Text)
                            ._checkNo = Trim(txtCheckNo.Text)
                            ._tempreleasedDt = dtpReleasedDate.Value
                            ._releasedRemarks = Trim(txtRemarks.Text)
                            ._releasedBy = IIf(Len(txtReleasedId.Text) = 0, 0, Val(txtReleasedId.Text.Replace(",", "")))

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = ._releasedId
                                Set_Form_State()
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Loan Application Release - " & Trim(txtLoanNo.Text) & " - " & Trim(txtMemberName.Text)

                                If clsCommon.GetRegistrySetting("Add New Record", "Disabled") = "" Then
                                    Dim iAns
                                    iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to add another record?" & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                                    If iAns = vbYes Then
                                        GoTo add_rec
                                    ElseIf iAns = vbCancel Then
                                        clsCommon.SaveRegistrySetting("Add New Record", "Disabled", "Yes")
                                    End If
                                End If

                                Dim mysql As New PowerNET8.mySQL.Init.SQL
                                Connect(mysql)
                                Dim re As DataTable = mysql.Query("SELECT * FROM tbl_notification where typeNotification='LOAN RELEASED' and loanID=" + RecordId.ToString)
                                If re.Rows.Count = 0 Then
                                    With mysql
                                        .setTable("tbl_notification")
                                        .addValue(.nextID("NID"), "NID")
                                        .addValue(RecordId, "loanID")
                                        .addValue("LOAN RELEASED", "typeNotification")
                                        .addValue("Application Released!", "notHeader")
                                        .addValue(txtMemberName.Text + " - loan application is released.", "Nofications")
                                        Dim str() As String = Now.ToString.Split(" ")
                                        Dim dt() As String = str(0).Split("/")
                                        Dim tm() As String = str(1).Split(":")
                                        If str(2) = "AM" Then
                                            .addValue(dt(2) + "-" + dt(0) + "-" + dt(1) + " " + str(1), "DtRecorded")
                                            Dim a As String = dt(2) + "-" + dt(0) + "-" + dt(1) + " " + str(1)
                                        Else
                                            .addValue(dt(2) + "-" + dt(0) + "-" + dt(1) + " " + (Val(tm(0)) + 12).ToString + ":" + tm(1) + ":" + tm(2), "DtRecorded")
                                            Dim s As String = dt(2) + "-" + dt(0) + "-" + dt(1) + " " + str(1)
                                            s = dt(2) + "-" + dt(0) + "-" + dt(1) + " " + (Val(tm(0)) + 12).ToString + ":" + tm(1) + ":" + tm(2)
                                        End If
                                        .addValue(gRoleID, "roleId")
                                        .addValue(gUserID, "createdBy")
                                        .Insert()
                                    End With
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
                        Me.txtLoanNo.Focus()
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

#Region "frmLoanApplicationRelease User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Loan Application Release"
        Me.txtLoanNo.Focus()
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(txtLoanNo)
            .Add(txtVoucherNo)
            .Add(txtCheckNo)
            .Add(dtpReleasedDate)
            .Add(txtRemarks)
            .Add(txtReleasedName)
            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet
        Dim dataComboRow As DataRow

        With clsLoanApplicationRelease
            dataCombo = .GetSignatory

            txtReleasedName.AutoCompleteCustomSource.Clear()
            cboReleasedId.Items.Clear()
            For Each dataComboRow In dataCombo.Tables(0).Rows
                cboReleasedId.Items.Add(dataComboRow(0))
                txtReleasedName.AutoCompleteCustomSource.Add(dataComboRow(1))
            Next
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColLoanApplicationRelease
            .Add(txtLoanId)
            .Add(txtLoanNo)
            .Add(txtVoucherNo)
            .Add(txtCheckNo)
            .Add(dtpReleasedDate)
            .Add(txtRemarks)
            .Add(txtReleasedId)
            .Add(txtReleasedName)
            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColLoanApplicationRelease)
        Define_Required_Fields()
        Me.Text = "Loan Application Release"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblLoanApplicationNo)
            .Add(Me.lblReleasedBy)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtLoanNo)
            .Add(txtVoucherNo)
            '.Add(txtCheckNo)
            .Add(dtpReleasedDate)
            .Add(txtReleasedName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsLoanApplicationRelease
            txtLoanId.Text = ._loanId
            txtVoucherNo.Text = ._voucherNo
            txtCheckNo.Text = ._checkNo
            dtpReleasedDate.Value = ._releasedDt
            If ._releasedFl = 1 Then
                dtpReleasedDate.Checked = True
            End If
            txtRemarks.Text = ._releasedRemarks

            txtReleasedId.Text = ._releasedBy
            If Val(txtReleasedId.Text.Replace(",", "")) = -1 Then
                txtReleasedName.Text = ""
            Else
                clsSignatory = clsUtility.NewclsSignatory
                With clsSignatory
                    .Init_Flag = IIf((Len(txtReleasedId.Text.Replace(",", "")) = 0), 0, Val(txtReleasedId.Text.Replace(",", "")))
                    .Selected_Record()
                    txtReleasedName.Text = ._lname & IIf(Len(._suffix) > 0, " " & ._suffix, "") & ", " & ._fname & " " & ._mname
                End With
            End If

            txtUpdateDt.Text = .Updated_Dt
            RecordId = ._releasedId
        End With

        With clsLoanApplication
            .Init_Flag = clsLoanApplicationRelease._loanId
            .Selected_Record()
            txtLoanNo.Text = ._loanNo
            txtMemberName.Text = ._memberName
            txtDepartment.Text = ._departmentName
            txtLoanType.Text = ._loanType
            txtPrincipalAmount.Text = Format(._principalAmount, "Standard")
            txtNetProceeds.Text = Format(._netProceeds, "Standard")
        End With
        txtLoanNo.Focus()

        Me.Text = "Loan Application Release - " & Trim(txtLoanNo.Text)
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
        clsLoanApplicationRelease = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColLoanApplicationRelease = Nothing
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblLoanApplicationNo.Text = "Loan Application No."
            lblVoucherNo.Text = "Voucher No."
            lblCheckNo.Text = "Check No."
            lblReleasedDate.Text = "Date Released"
            lblReleasedBy.Text = "Released By"
        Else
            lblLoanApplicationNo.Text = "Loan Application No. *"
            lblVoucherNo.Text = "Voucher No. *"
            lblCheckNo.Text = "Check No. *"
            lblReleasedDate.Text = "Date Released *"
            lblReleasedBy.Text = "Released By *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsLoanApplicationRelease.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        txtLoanNo.Tag = "Loan Application No."
        txtVoucherNo.Tag = "Voucher No."
        'txtCheckNo.Tag = "Check No."
        dtpReleasedDate.Tag = "Date Released"
        txtReleasedName.Tag = "Released By"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtRemarks.MaxLength = 2000
        Me.txtVoucherNo.MaxLength = 20
        Me.txtCheckNo.MaxLength = 20
    End Sub

    Private Sub txtLoanNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLoanNo.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.DisAllow_Input(e)
        End If
    End Sub

    Private Sub txtLoanNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLoanNo.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtLoanId, e)
            clsCommon.Delete_TxtBox_Value(txtLoanNo, e)
            clsCommon.Delete_TxtBox_Value(txtMemberName, e)
            clsCommon.Delete_TxtBox_Value(txtDepartment, e)
            clsCommon.Delete_TxtBox_Value(txtLoanType, e)
            clsCommon.Delete_TxtBox_Value(txtPrincipalAmount, e)
        End If
    End Sub

    Private Sub txtLoanNo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLoanNo.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

#End Region

#Region "frmLoanApplicationRelease Label Piping Click"

    Private Sub lblLoanApplicationNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblLoanApplicationNo.Click
        'Try
        '    frmUseLoanApplicationFinder = New frmLoanApplicationFinder

        '    With frmUseLoanApplicationFinder
        '        clsBookkeper.UseRecordState = USE_STATE
        '        .frmMainUser = Me
        '        .MaximizeBox = False
        '        .MinimizeBox = False

        '        .ShowDialog()
        '    End With

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub lblReleasedBy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblReleasedBy.Click
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Try
            frmUseSignatoryFinder = clsUtility.NewfrmSignatoryFinder
            clsUtility.UseRecordState = USE_STATE

            With frmUseSignatoryFinder
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False

                .ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "frmLoanApplicationApproval Handle Piping"

    Private Sub frmUseLoanApplicationFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseLoanApplicationFinder.Use_Clicked
        With clsLoanApplication
            .Init_Flag = Record_Id
            .Selected_Record()

            If ._cancelFl = 1 Then
                clsCommon.Prompt_User("information", "Can not Release selected loan application record." & vbCrLf & "The loan application has already been cancelled.")
                Exit Sub
            End If

            If ._closedFl = 1 Then
                clsCommon.Prompt_User("information", "Can not Release selected loan application record." & vbCrLf & "The loan application has already been tagged as closed.")
                Exit Sub
            End If

            txtLoanId.Text = ._loanId
            txtLoanNo.Text = ._loanNo
            txtMemberName.Text = ._memberName
            txtDepartment.Text = ._departmentName
            txtLoanType.Text = ._loanType
            txtPrincipalAmount.Text = Format(._principalAmount, "Standard")
            txtNetProceeds.Text = Format(._netProceeds, "Standard")
        End With
    End Sub

    Private Sub frmUseSignatoryFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseSignatoryFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If
        clsSignatory = clsUtility.NewclsSignatory
        With clsSignatory
            .Init_Flag = Record_Id
            .Selected_Record()
            txtReleasedName.Text = ._fname & IIf(Len(._mname) > 0, " " & ._mname, "") & IIf(Len(._lname) > 0, " " & ._lname, "") & IIf(Len(._suffix) > 0, " " & ._suffix, "")
            txtReleasedId.Text = Record_Id
        End With
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class