Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmPaymentLoanAndContribution
    Inherits System.Windows.Forms.Form

#Region "frmPaymentLoanAndContribution Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsPayment As New Payment.Payment
    Private WithEvents clsPaymentCheckDetail As New Payment.PaymentCheck
    Private WithEvents clsPaymentBillingDetail As New Payment.PaymentDetail
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMember As New Personnel.Member.Member
    Private WithEvents clsUtility As New Utility.Utility(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsBank As New Utility.Bank.Bank
    Private WithEvents clsCollectionType As New Utility.CollectionType.CollectionType
    Private WithEvents clsTreasurer As New Treasurer(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsBookkeper As New Bookkeper.Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsLoanApplication As New Bookkeper.LoanApplication.LoanApplication
    Private WithEvents clsLoanPaymentUpdater As New Bookkeper.LoanPaymentUpdater.LoanPaymentUpdater
    Private WithEvents clsContributionUpdater As New Bookkeper.ContributionGeneration.ContributionGeneration
    Private WithEvents clsMemberContribution As New Bookkeper.MemberContribution.MemberContribution
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmPaymentFinder
    Private WithEvents frmUseLoanApplicationFinder As Bookkeper.frmLoanApplicationFinder = Nothing

    Private WithEvents frmLoginOverride As DataAccess.frmLoginOverride = Nothing
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    Private WithEvents frmStartORNoPayment As frmStartORNo
    Private frmPaymentMicrosoftReportViewer As frmCrystalReportViewer

    'declaration of Collections
    Private ColPipe As New Microsoft.VisualBasic.Collection
    Private ColRequired As New Microsoft.VisualBasic.Collection
    Private ColDisplay As New Microsoft.VisualBasic.Collection
    Private ColPayment As New Microsoft.VisualBasic.Collection
    Private PaymentMemoDetailItem As New Microsoft.VisualBasic.Collection
    Private PaymentCheckDetailItem As New Microsoft.VisualBasic.Collection
    Private PaymentLoanBillingDetailItem As New Microsoft.VisualBasic.Collection
    Private PaymentContributionBillingDetailItem As New Microsoft.VisualBasic.Collection
    Private CurRow As New DataGridViewRow
    Private scAutoComplete As New AutoCompleteStringCollection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False
    Private strRemarks As String = ""
    Private strRemarkSuffix As String = ""
    Private taxCodeId As Integer
    Private fineTypeId As Integer
    Private dtOR As Date
    Private curOR As Integer = 0
    Private curAlphaOR As String = ""
    Private dtPayment As Date
    Private ref3 As Integer = 0

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow
    Private dtMember As New DataTable

    Private dtMemberId As New DataTable
    Private loanType As String = ""
    Private balance_process_done As Boolean
    Private payment_process As Boolean = False
    Private contribution_process As Boolean = False

    Private KeyPressChar As Long

#End Region

#Region "frmPaymentLoanAndContribution Main Form Private Sub"

    Private Sub frmPaymentLoanAndContribution_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        curOR = 0
        curAlphaOR = ""
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Me.WindowState = FormWindowState.Maximized
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsPayment.Init_Flag = RecordId
            clsPayment.Selected_Loan_And_Contribution_Record()
            Assign_Data()
        End If
        If State = ADD_STATE Then
            'StartORNo()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmPaymentLoanAndContribution_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtORNo.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmPaymentLoanAndContribution_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Disposed_Class()
    End Sub

    Private Sub frmPaymentLoanAndContribution_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, dgvCheckDetails.KeyPress, dtpORDt.KeyPress, chkSaveCredit.KeyPress, txtAmountChange.KeyPress, txtCashAmount.KeyPress, txtCheckAmount.KeyPress, txtCollectorId.KeyPress, _
        txtCollectorName.KeyPress, txtMemberId.KeyPress, txtMemberName.KeyPress, txtORAmount.KeyPress, txtORNo.KeyPress, txtPaymentRemarks.KeyPress, txtTaxCreditAmount.KeyPress, txtTaxCreditAvailable.KeyPress, txtTotalLoanDue.KeyPress, txtTotalContributionDue.KeyPress, txtTotalAmountDue.KeyPress, txtTotalAmountPayable.KeyPress, rbCash.KeyPress, rbCashCheque.KeyPress, rbCheque.KeyPress
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

#Region "frmPaymentLoanAndContribution ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmPaymentLoanAndContribution As New frmPaymentLoanAndContribution
                    frmTitle = "Loan and Contribution Payment"
                    If blnUseFinder Then
                        State = ADD_STATE
                        RecordId = 0
                        Call clsCommon.ClearControls(ColPayment)
                        dgvCheckDetails.Rows.Clear()
                        dgvLoanBillingDetails.Rows.Clear()
                        dgvContributionBillingDetails.Rows.Clear()
                        Call Set_Form_State()
                        Call Default_Values()
                        Call Initialize_AutoComplete()
                        Call GetUserRecord(gUserID)
                        Me.dtpORDt.Value = Now
                        rbCash.Checked = True
                        Me.Text = "Loan and Contribution Payment"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmPaymentLoanAndContribution = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmPaymentLoanAndContribution.Activate()
                        Else
                            State = ADD_STATE
                            RecordId = 0
                            Call clsCommon.ClearControls(ColPayment)
                            dgvCheckDetails.Rows.Clear()
                            dgvLoanBillingDetails.Rows.Clear()
                            dgvContributionBillingDetails.Rows.Clear()
                            Call Set_Form_State()
                            Call Default_Values()
                            Call Initialize_AutoComplete()
                            Call GetUserRecord(gUserID)
                            Me.dtpORDt.Value = Now
                            rbCash.Checked = True
                            Me.Text = "Loan and Contribution Payment"
                        End If
                    End If

                    'auto increment OR number
                    curOR += 1
                    txtORNo.Text = curOR.ToString("00000000") & curAlphaOR

                Case 1 'edit
edit_rec:
                    If chkCancelFl.CheckState = 1 Then
                        clsCommon.Prompt_User("information", "You can no longer edit this payment record. This record has already been cancelled.")
                        Exit Sub
                    ElseIf chkDeleteFl.CheckState = 1 Then
                        clsCommon.Prompt_User("information", "You can no longer edit this payment record. This record has already been deleted.")
                        Exit Sub
                    Else
                        frmLoginOverride = clsDataAccess.NewfrmLoginOverride
                        With frmLoginOverride
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                State = EDIT_STATE
                                Call Set_Form_State()
                            End If
                        End With
                    End If
                Case 2 'delete
delete_rec:
                    If chkCancelFl.CheckState = 1 Then
                        clsCommon.Prompt_User("information", "You can no longer cancel / delete this payment record. This record has already been cancelled.")
                        Exit Sub
                    ElseIf chkDeleteFl.CheckState = 1 Then
                        clsCommon.Prompt_User("information", "You can no longer cancel / delete this payment record. This record has already been deleted.")
                        Exit Sub
                    Else
                        frmLoginOverride = clsDataAccess.NewfrmLoginOverride
                        With frmLoginOverride
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dim iAns
                                iAns = clsCommon.Prompt_User("yesnocancel", MSGBOX_CANCEL_OR_DELETE_CONFIRMATION)
                                If iAns <> vbCancel Then
                                    With clsPayment
                                        .Payment_Id = RecordId
                                        .Updated_By = gUserID
                                        .Init_Flag = IIf(iAns = vbYes, 0, 1)
                                        If .Delete_Loan_And_Contribution_Record() Then
                                            Me.Close()
                                        End If
                                    End With
                                End If
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmPaymentLoanAndContributionFinder
                        frmTitle = "Loan and Contribution Payment Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.txtMemberName.Focus()
                        Else
                            frmFinder = New frmPaymentLoanAndContributionFinder("Loan and Contribution")
                            With frmFinder
                                .payment_Id = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If txtORNo.Text = "" Then
                        clsCommon.Prompt_User("error", "Please provide or number for current payment record.")
                        Exit Sub
                    End If

                    If clsCommon.Required_Validation_List(ColRequired) Then
                        If Validate_Before_Saving() Then
                            Me.Cursor = WaitCursor
                            With clsPayment
                                .Payment_Id = RecordId
                                .OR_No = Trim(txtORNo.Text)
                                .TempOR_Dt = dtpORDt.Value
                                .Member_Id = IIf((Len(txtMemberId.Text.Replace(",", "")) = 0), 0, Val(txtMemberId.Text.Replace(",", "")))
                                .billing_Fl = 0

                                If rbCash.Checked Then
                                    .payment_Fl = 0
                                ElseIf rbCheque.Checked Then
                                    .payment_Fl = 1
                                ElseIf rbCashCheque.Checked Then
                                    .payment_Fl = 2
                                End If

                                .OR_Amount = IIf((Len(txtORAmount.Text.Replace(",", "")) = 0), 0, Val(txtORAmount.Text.Replace(",", "")))
                                .Cash_Amount = IIf((Len(txtCashAmount.Text.Replace(",", "")) = 0), 0, Val(txtCashAmount.Text.Replace(",", "")))
                                .Check_Amount = IIf((Len(txtCheckAmount.Text.Replace(",", "")) = 0), 0, Val(txtCheckAmount.Text.Replace(",", "")))
                                .Credit_Amount = IIf((Len(txtTaxCreditAmount.Text.Replace(",", "")) = 0), 0, Val(txtTaxCreditAmount.Text.Replace(",", "")))
                                .credit_Fl = 0
                                .reference_Id = ref3
                                .Payment_Remarks = Trim(txtPaymentRemarks.Text)

                                .Updated_Dt = txtUpdateDt.Text
                                .Updated_By = gUserID

                                ._dueDate = dtPayment.ToString("yyyy-MM-dd")
                                Populate_Collection()

                                Dim iPostAns
                                iPostAns = clsCommon.Prompt_User("question", _
                                "You are about to post a payment with the following details: " & vbCrLf & vbCrLf & _
                                "Official Receipt No : " & Trim(txtORNo.Text) & vbCrLf & _
                                "OR Date : " & Format(dtpORDt.Value, "ddd, MMM dd, yyyy") & vbCrLf & _
                                "Payer Name : " & Trim(txtMemberName.Text) & vbCrLf & _
                                "Total OR Amount : " & Format(IIf((Len(txtORAmount.Text.Replace(",", "")) = 0), 0, Val(txtORAmount.Text.Replace(",", ""))), "Standard") & vbCrLf & vbCrLf & _
                                "Continue and save payment?")
                                If iPostAns = vbNo Then
                                    Me.Cursor = Arrow
                                    Exit Sub
                                End If

                                If .Save_Loan_And_Contribution_Record() Then
                                    State = VIEW_STATE
                                    RecordId = .Payment_Id
                                    txtUpdateDt.Text = .Updated_Dt
                                    Set_Form_State()

                                    .Init_Flag = RecordId
                                    If .Selected_Loan_And_Contribution_Record() Then
                                        Assign_Data()
                                    End If

                                    Me.Text = "Loan and Contribution Payment - [" & Me.txtORNo.Text & "]"

                                    If clsCommon.GetRegistrySetting("Print OR", "Disabled") = "" Then
                                        Dim iAns
                                        iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to preview OR AF 51 of the corresponding payment? Press 'YES' to preview AF 51 (Old) Revision January 1992. Press 'NO' to preview AF 51 (New) Revision June 2008." & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                                        If iAns = vbYes Then
                                            PrintOfficialReceiptAF51OldToolStripMenuItem_Click(cmnsPayment, New System.EventArgs)
                                            'ElseIf iAns = vbNo Then
                                            '   PrintOfficialReceiptAF51NewToolStripMenuItem_Click(cmnsPayment, New System.EventArgs)
                                        ElseIf iAns = vbCancel Then
                                            clsCommon.SaveRegistrySetting("Print OR", "Disabled", "Yes")
                                        End If
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
                                        If .Selected_Loan_And_Contribution_Record() Then
                                            Assign_Data()
                                        End If
                                    End If
                                End If
                            End With
                            Me.Cursor = Arrow
                        End If
                    Else
                        Me.txtMemberName.Focus()
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

                        With clsPayment
                            State = VIEW_STATE
                            .Init_Flag = RecordId
                            If .Selected_Loan_And_Contribution_Record() Then
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

#Region "frmPaymentLoanAndContribution User Defined Private Sub"

    Private Sub Initialize_Form()
        Set_Form_State()
        clsCommon.ClearControls(ColPayment)
        Define_Required_Fields()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        'Default_Values()
        Set_Max_Length()
        Initialize_AutoComplete()
        Call GetUserRecord(gUserID)
        Me.Text = "Loan and Contribution Payment"
        dtpORDt.Value = Now
        dtOR = Now
        rbCash.Checked = True
        txtMemberName.Focus()
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet
        Dim dataComboRow As DataRow

        With clsPayment
            dataCombo = .GetBankNameList
            cboBankId.Items.Clear()
            cboBankName.Items.Clear()
            For Each dataComboRow In dataCombo.Tables(0).Rows
                cboBankId.Items.Add(dataComboRow(0))
                cboBankName.Items.Add(dataComboRow(1))
            Next

            dataCombo = .GetCollectionTypeList
            cboTypeId.Items.Clear()
            cboTypeName.Items.Clear()
            For Each dataComboRow In dataCombo.Tables(0).Rows
                cboTypeId.Items.Add(dataComboRow(0))
                cboTypeName.Items.Add(dataComboRow(1))
            Next
        End With

        'member list
        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
        Dim autoSourceCollection As New AutoCompleteStringCollection()
        Dim drow As DataRow

        dtMember = clsDA.ExecuteQuery("SELECT memberId, TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) 'Name' FROM tblmember WHERE activeFl = 1 AND cancelFl = 0 AND retireFl = 0;", True, RETURN_TYPE_DATATABLE)
        txtMemberName.AutoCompleteSource = AutoCompleteSource.None

        For Each drow In dtMember.Rows
            autoSourceCollection.Add(drow.Item("Name"))
        Next

        txtMemberName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtMemberName.AutoCompleteCustomSource = autoSourceCollection
        txtMemberName.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub Default_Values()

        txtCashAmount.Text = Format(0, "Standard")
        txtCheckAmount.Text = Format(0, "Standard")

        txtTotalAmountDue.Text = Format(0, "Standard")
        txtTotalAmountPayable.Text = Format(0, "Standard")
    End Sub

    Private Sub Define_Collection()
        ColDisplay = New Microsoft.VisualBasic.Collection
        With ColDisplay
            If RecordId = 0 Or State <> EDIT_STATE Then
                '.Add(Me.dtpORDt)
                .Add(Me.txtMemberId)
                .Add(Me.txtMemberName)
            End If
            .Add(Me.chkCancelFl)
            .Add(Me.chkDeleteFl)
            .Add(Me.chkSaveCredit)
            .Add(Me.dgvCheckDetails)
            .Add(Me.dgvLoanBillingDetails)
            .Add(Me.dgvContributionBillingDetails)
            .Add(Me.txtCashAmount)
            .Add(Me.txtPaymentRemarks)
            .Add(rbCash)
            .Add(rbCashCheque)
            .Add(rbCheque)

            .Add(txtUpdateDt)
        End With

        ColPayment = New Microsoft.VisualBasic.Collection
        With ColPayment
            .Add(Me.chkCancelFl)
            .Add(Me.chkDeleteFl)
            .Add(Me.chkSaveCredit)
            .Add(Me.dtpORDt)
            .Add(Me.txtCashAmount)
            .Add(Me.txtCheckAmount)
            .Add(Me.txtMemberId)
            .Add(Me.txtMemberName)
            .Add(Me.txtTaxCreditAmount)
            .Add(Me.txtORAmount)
            .Add(Me.txtORNo)
            .Add(Me.txtPaymentRemarks)
            .Add(Me.txtTotalLoanDue)
            .Add(Me.txtTotalContributionDue)
            .Add(Me.txtTotalAmountDue)
            .Add(Me.txtTotalAmountPayable)

            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Define_Pipe_Fields()
        ColPipe = New Microsoft.VisualBasic.Collection
        With ColPipe
            If RecordId = 0 Or State <> EDIT_STATE Then
                .Add(lblMemberName)
            End If
        End With
    End Sub

    Private Sub Define_Required_Fields()
        ColRequired = New Microsoft.VisualBasic.Collection
        With ColRequired
            .Add(txtMemberName)
            .Add(txtORNo)
            If rbCashCheque.Checked Or rbCheque.Checked Then
                .Add(dgvCheckDetails)
            End If
            .Add(dgvLoanBillingDetails)
            .Add(dgvContributionBillingDetails)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsPayment
            chkBillingFl.CheckState = .billing_Fl

            If .payment_Fl = 0 Then
                rbCash.Checked = True
            ElseIf .payment_Fl = 1 Then
                rbCheque.Checked = True
            ElseIf .payment_Fl = 2 Then
                rbCashCheque.Checked = True
            End If

            txtMemberId.Text = .Member_Id
            txtMemberName.Text = .Member_Name
            txtORNo.Text = .OR_No
            dtpORDt.Value = .TempOR_Dt
            txtORAmount.Text = Format(.OR_Amount, "Standard")
            txtCashAmount.Text = Format(.Cash_Amount, "Standard")
            txtCheckAmount.Text = Format(.Check_Amount, "Standard")
            txtTaxCreditAmount.Text = Format(.Credit_Amount, "Standard")
            txtPaymentRemarks.Text = .Payment_Remarks
            chkCancelFl.CheckState = .Cancel_Fl
            chkDeleteFl.CheckState = .Delete_Fl
            chkOnlineFl.CheckState = .Online_Fl
            chkSaveCredit.CheckState = .credit_Fl
            txtRefId.Text = .reference_Id

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Payment_Id


            Dim tLoan As Double = 0
            Dim tContribution As Double = 0

            'populate check details
            dtDataGridView = Nothing
            dgvCheckDetails.Rows.Clear()
            dtDataGridView = .Populate_Payment_Check_Detail
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvCheckDetails
                        Dim rowndx As Integer

                        rowndx = .Rows.Add()
                        dgvCheckDetails.Item(0, rowndx).Value = Trim(dtDataGridViewRow("bankId"))
                        dgvCheckDetails.Item(1, rowndx).Value = Trim(dtDataGridViewRow("bankName"))
                        dgvCheckDetails.Item(2, rowndx).Value = Trim(dtDataGridViewRow("bankBranch"))
                        dgvCheckDetails.Item(3, rowndx).Value = Trim(dtDataGridViewRow("checkNo"))
                        dgvCheckDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("checkAmount")), "Standard"))
                        dgvCheckDetails.Item(5, rowndx).Value = Trim(dtDataGridViewRow("checkDate"))
                        dgvCheckDetails.Item(6, rowndx).Value = Trim(dtDataGridViewRow("checkRemarks"))
                    End With
                Next
            End If

            Compute_Total_Check_Amount()

            payment_process = False
            'populate billing details
            dtDataGridView = Nothing
            dgvLoanBillingDetails.Rows.Clear()
            dtDataGridView = .Populate_Payment_Billing_Loan_Detail
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvLoanBillingDetails
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("memberId")
                        .Item(1, rowndx).Value = dtDataGridViewRow("memberNo")
                        .Item(2, rowndx).Value = dtDataGridViewRow("memberName")
                        .Item(3, rowndx).Value = dtDataGridViewRow("loanId")
                        .Item(4, rowndx).Value = dtDataGridViewRow("loanNo")
                        .Item(5, rowndx).Value = dtDataGridViewRow("loanType")
                        .Item(6, rowndx).Value = dtDataGridViewRow("balanceAmount")
                        .Item(7, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                        .Item(8, rowndx).Value = dtDataGridViewRow("amountPaid")
                        .Item(9, rowndx).Value = dtDataGridViewRow("loanInterest")
                        .Item(10, rowndx).Value = dtDataGridViewRow("closeFl")
                        .Item(12, rowndx).Value = dtDataGridViewRow("billingId")
                        tLoan = tLoan + CDbl(.Item(8, rowndx).Value) + CDbl(.Item(9, rowndx).Value)

                    End With
                Next
            End If

            'populate billing details
            dtDataGridView = Nothing
            dgvContributionBillingDetails.Rows.Clear()
            dtDataGridView = .Populate_Payment_Billing_Contribution_Detail
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvContributionBillingDetails
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("memberId")
                        .Item(1, rowndx).Value = dtDataGridViewRow("memberNo")
                        .Item(2, rowndx).Value = dtDataGridViewRow("memberName")
                        .Item(3, rowndx).Value = dtDataGridViewRow("contribution")
                        .Item(4, rowndx).Value = dtDataGridViewRow("pabaon")
                        .Item(5, rowndx).Value = dtDataGridViewRow("mortuary")
                        .Item(6, rowndx).Value = dtDataGridViewRow("pSLink")
                        .Item(7, rowndx).Value = dtDataGridViewRow("overallTotal")
                        tContribution = tContribution + CDbl(.Item(7, rowndx).Value)
                    End With
                Next
            End If
            txtTotalLoanDue.Text = Format(tLoan, "Standard")
            txtTotalContributionDue.Text = Format(tContribution, "Standard")
            txtTotalAmountDue.Text = Format(tLoan + tContribution, "Standard")
            'Compute_Total_Amount_Due()
        End With

        txtMemberName.Focus()
        Me.Text = "Loan and Contribution Payment - [" & Me.txtORNo.Text & "]"
    End Sub

    Private Sub GetUserRecord(ByVal UserId As Integer)
        Try
            Me.txtCollectorId.Text = clsPayment.GetMemberId(UserId)

            clsMember = clsPersonnel.NewclsMember
            With clsMember
                .Init_Flag = CInt(txtCollectorId.Text)
                .Selected_Record()
                txtCollectorName.Text = .Last_Name & IIf(Len(._suffixName) > 0, " " & ._suffixName, "") & ", " & .First_Name & " " & .Middle_Name
            End With
        Catch ex As Exception

        End Try
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
        clsPayment = Nothing
        clsCommon = Nothing
        ColPipe = Nothing
        ColDisplay = Nothing
        ColPayment = Nothing
        ColRequired = Nothing
        PaymentCheckDetailItem = Nothing
        PaymentLoanBillingDetailItem = Nothing
        PaymentContributionBillingDetailItem = Nothing
        PaymentMemoDetailItem = Nothing
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsPayment.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        txtMemberName.Tag = "Payer Name"
        txtORNo.Tag = "Official Receipt Number"
        dgvCheckDetails.Tag = "Check Details"
        dgvLoanBillingDetails.Tag = "Loan Collectible"
        dgvContributionBillingDetails.Tag = "Contribution Collectible"
    End Sub

    Private Sub Set_Max_Length()
        txtORNo.MaxLength = 45
        txtPaymentRemarks.MaxLength = 2000
    End Sub

    Public Sub Set_Form_State()
        Define_Collection()
        Set_Permission()
        Define_Pipe_Fields()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)

        If State = "View" Then
            lblORNo.Text = "Official Receipt No."
        Else
            If RecordId = 0 Then
                lblORNo.Text = "Official Receipt No. *"
            End If
        End If

        PrintOfficialReceiptToolStripMenuItem.Enabled = (State = "View" And RecordId > 0)
        ClearCollectibleToolStripMenuItem.Enabled = (State <> "View" And RecordId = 0)
        LoadLoanCollectionToolStripMenuItem.Enabled = (State <> "View" And RecordId = 0)
        StartORNoToolStripMenuItem.Enabled = (State <> "View" And RecordId = 0)
        dgvLoanBillingDetails.AllowUserToAddRows = False
        dgvLoanBillingDetails.AllowUserToDeleteRows = False
        dgvContributionBillingDetails.AllowUserToAddRows = False
        dgvContributionBillingDetails.AllowUserToDeleteRows = False

        'dgvLoanBillingDetails.Columns(8).ReadOnly = False
        'dgvLoanBillingDetails.Columns(9).ReadOnly = False

        'dgvContributionBillingDetails.Columns(3).ReadOnly = False
        'dgvContributionBillingDetails.Columns(4).ReadOnly = False
        'dgvContributionBillingDetails.Columns(5).ReadOnly = False
        'dgvContributionBillingDetails.Columns(6).ReadOnly = False
    End Sub

    'Private Sub txtConstituentName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConstituentName.KeyPress
    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If

    '    KeyPressChar = e.KeyChar.GetHashCode

    '    If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
    '        clsCommon.DisAllow_Input(e)
    '    End If
    'End Sub

    Private Sub txtMemberName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMemberName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            If RecordId = 0 Then
                clsCommon.Delete_TxtBox_Value(txtMemberName, e)
                clsCommon.Delete_TxtBox_Value(txtMemberId, e)
                clsCommon.Delete_TxtBox_Value(txtTaxCreditAvailable, e)
            End If
        End If
    End Sub

    Private Sub txtMemberName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMemberName.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If TypeOf (sender) Is TextBox Then
            clsCommon.Disable_Field_Context_Menu(e, sender)
        End If
    End Sub


    Private Sub txtMemberName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberName.LostFocus
        ValidateMember(CStr(txtMemberName.Text))
    End Sub

    Private Sub ValidateMember(ByVal ColName As String)
        Try
            Dim mydata As New DataTable

            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblmember WHERE TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) = '" & Trim(txtMemberName.Text) & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)

            If mydata.Rows.Count <> 0 Then
                With clsMember
                    .Init_Flag = mydata.Rows(0).Item("memberId")
                    .Selected_Record()
                    txtMemberId.Text = .Member_Id
                End With
            Else
                txtMemberId.Text = ""
            End If
        Catch ex As Exception
            txtMemberId.Text = ""
        End Try
    End Sub

    Private Sub txtCashAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCashAmount.KeyPress, txtTaxCreditAmount.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            If TypeOf (sender) Is TextBox Then
                clsCommon.AcceptAmount(sender, e)
            End If
        End If
    End Sub

    Private Sub rbCash_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCash.CheckedChanged, rbCashCheque.CheckedChanged, rbCheque.CheckedChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            dgvCheckDetails.Rows.Clear()
            Default_Values()
            Define_Required_Fields()
            Compute_Total_Amount_Due()
            Compute_Total_Check_Amount()
        End If
        Me.txtCashAmount.Enabled = Not (rbCheque.Checked) 'Or rbChequeMemo.Checked Or rbMemo.Checked
        Me.dgvCheckDetails.Enabled = Not (rbCash.Checked) ' Or rbCashMemo.Checked Or rbMemo.Checked
    End Sub

    Private Sub dgvCheckDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCheckDetails.CellValueChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Try
            If State <> VIEW_STATE Then
                Select Case LCase(dgvCheckDetails.Columns(e.ColumnIndex).Name)
                    Case "colbankname"
                        If cboBankName.Items.IndexOf(dgvCheckDetails.Item(e.ColumnIndex, e.RowIndex).Value) = -1 And Len(dgvCheckDetails.Item(e.ColumnIndex, e.RowIndex).Value) > 0 Then
                            dgvCheckDetails.Item(e.ColumnIndex, e.RowIndex).Value = ""
                        Else
                            clsBank = clsUtility.NewclsBank
                            With clsBank
                                .Init_Flag = cboBankId.Items(cboBankName.Items.IndexOf(dgvCheckDetails.Item(e.ColumnIndex, e.RowIndex).Value))
                                .Selected_Record()

                                dgvCheckDetails.Item(0, e.RowIndex).Value = .Bank_Id
                            End With
                            dgvCheckDetails.CurrentCell = dgvCheckDetails.Item(2, e.RowIndex)
                        End If
                    Case "colcheckamount"
                        Compute_Total_Check_Amount()
                End Select
            End If

        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub

    Private Sub dgvCheckDetails_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCheckDetails.EditingControlShowing
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            If State <> VIEW_STATE Then
                Dim dataCombo As DataSet
                Dim dataComboRow As DataRow

                If CInt(dgvCheckDetails.Columns(dgvCheckDetails.CurrentCell.ColumnIndex).ToolTipText) = 0 AndAlso TypeOf e.Control Is TextBox Then
                    Select Case LCase(dgvCheckDetails.Columns(dgvCheckDetails.CurrentCell.ColumnIndex).Name)
                        Case "colbankname"
                            With clsPayment
                                dataCombo = .GetBankNameList

                            End With

                            With scAutoComplete
                                .Clear()
                                For Each dataComboRow In dataCombo.Tables(0).Rows
                                    .Add(dataComboRow(1))
                                Next
                            End With

                            With DirectCast(e.Control, TextBox)
                                .CharacterCasing = CharacterCasing.Upper
                                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                                .AutoCompleteSource = AutoCompleteSource.CustomSource
                                .AutoCompleteCustomSource = scAutoComplete
                            End With
                        Case Else
                            With DirectCast(e.Control, TextBox)
                                .CharacterCasing = CharacterCasing.Upper
                                .AutoCompleteMode = AutoCompleteMode.None
                            End With
                    End Select
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCheckDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvCheckDetails.CellValidating
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            Dim cell As DataGridViewCell = dgvCheckDetails.Item(e.ColumnIndex, e.RowIndex)

            If cell.IsInEditMode Then
                Dim c As Control = dgvCheckDetails.EditingControl

                Select Case dgvCheckDetails.Columns(e.ColumnIndex).Name
                    Case "colCheckAmount"
                        c.Text = Format(CDbl(clsCommon.CleanInputFloat(c.Text)), "#,##0.00")
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCheckDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvCheckDetails.RowsRemoved
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            Compute_Total_Check_Amount()
        End If

    End Sub

    Private Sub Compute_Total_Check_Amount()
        Try
            Dim GridRows, recno As Integer
            Dim TotalCheckAmount As Double

            If CInt(dgvCheckDetails.Item(0, dgvCheckDetails.Rows.Count - 1).Value) = 0 Then
                GridRows = dgvCheckDetails.Rows.Count - 1
            Else
                GridRows = dgvCheckDetails.Rows.Count
            End If

            recno = 0
            TotalCheckAmount = 0
            For A As Integer = 0 To GridRows - 1
                TotalCheckAmount = TotalCheckAmount + CDbl(dgvCheckDetails.Item("colCheckAmount", A).Value)
                recno += 1
            Next

            txtCheckAmount.Text = Format(TotalCheckAmount, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Compute_Total_Amount_Due()
        Try
            Dim tLoan As Double = 0
            Dim tContribution As Double = 0

            For a As Integer = 0 To dgvLoanBillingDetails.RowCount - 1
                tLoan = tLoan + CDbl(dgvLoanBillingDetails.Item(8, a).Value) + CDbl(dgvLoanBillingDetails.Item(9, a).Value)
            Next
            For a As Integer = 0 To dgvContributionBillingDetails.RowCount - 1
                tContribution = tContribution + CDbl(dgvContributionBillingDetails.Item(7, a).Value)
            Next
            txtTotalLoanDue.Text = Format(tLoan, "Standard")
            txtTotalContributionDue.Text = Format(tContribution, "Standard")
            txtTotalAmountDue.Text = Format(tLoan + tContribution, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalLoanDue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalAmountDue.TextChanged, txtCashAmount.TextChanged, txtCheckAmount.TextChanged ', txtTaxCreditAmount.TextChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim TotalCashAmountPayable As Double = IIf((Len(txtCashAmount.Text.Replace(",", "")) = 0), 0, Val(txtCashAmount.Text.Replace(",", "")))
        Dim TotalCheckAmountPayable As Double = IIf((Len(txtCheckAmount.Text.Replace(",", "")) = 0), 0, Val(txtCheckAmount.Text.Replace(",", "")))
        'Dim TotalMemoAmountPayable As Double = IIf((Len(txtMemoAmount.Text.Replace(",", "")) = 0), 0, Val(txtMemoAmount.Text.Replace(",", "")))

        txtORAmount.Text = Format(TotalCashAmountPayable + TotalCheckAmountPayable, "Standard") ' + TotalMemoAmountPayable
        txtTotalAmountPayable.Text = Format(TotalCashAmountPayable + TotalCheckAmountPayable, "Standard") '+ TotalMemoAmountPayable
        If rbCash.Checked = True Then
            txtCashAmount.Text = txtTotalAmountDue.Text
        End If
    End Sub

    Private Function Validate_Before_Saving() As Boolean
        Try
            Dim TotalORAmount As Double = IIf((Len(txtORAmount.Text.Replace(",", "")) = 0), 0, Val(txtORAmount.Text.Replace(",", "")))

            If TotalORAmount <= 0 Then
                clsCommon.Prompt_User("error", "Can not save payment record. You have not posted the amount payable for either 'CASH', 'CHEQUE' and/or 'MEMO'.")
                Return False
            End If

            Dim GridRows1 As Integer

            If CInt(dgvCheckDetails.Item(0, dgvCheckDetails.Rows.Count - 1).Value) = 0 Then
                GridRows1 = dgvCheckDetails.Rows.Count - 1
            Else
                GridRows1 = dgvCheckDetails.Rows.Count
            End If

            For A As Integer = 0 To GridRows1 - 1
                For B As Integer = 0 To GridRows1 - 1
                    If A <> B Then
                        If CStr(dgvCheckDetails.Item("colCheckNo", A).Value) = CStr(dgvCheckDetails.Item("colCheckNo", B).Value) Then
                            clsCommon.Prompt_User("error", "Can not save payment record. Duplicate records for check details are found in rows " & CStr(A + 1) & " and " & CStr(B + 1) & ".")
                            Return False
                        End If
                    End If
                Next
            Next

            'check if amount paid is less than amount due
            If CDbl(txtTotalAmountPayable.Text) < CDbl(txtTotalAmountDue.Text) Then
                clsCommon.Prompt_User("error", "Can not save payment record. Amount paid is less than amount due.")
                Return False
            End If

            If CDbl(txtTotalLoanDue.Text) = 0 And CDbl(txtTotalContributionDue.Text) = 0 Then
                clsCommon.Prompt_User("error", "Can not save payment record. There are no collectible records in your payment record.")
                Return False
            End If

            If txtMemberName.Text <> "" Then
                Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
                Dim dtTemp As New DataTable

                dtTemp = clsDA.ExecuteQuery("SELECT memberId FROM tblmember WHERE  TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) = '" & clsCommon.ReplaceSingleQuotes(txtMemberName.Text) & "';", True, RETURN_TYPE_DATATABLE)

                If dtTemp.Rows.Count > 0 Then
                    txtMemberId.Text = CStr(dtTemp.Rows(0)(0))
                    Return True
                End If
            End If
            If (txtMemberId.Text = "" Or txtMemberId.Text = "0") Then
                clsCommon.Prompt_User("error", "Can not save payment record. Payor name is not in your record.")
                Return False
            End If

            Return True
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
            Return False
        End Try
    End Function

    Private Sub correct_Remarks()

    End Sub

    'Private Sub txtCashAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCashAmount.GotFocus
    '    If State <> VIEW_STATE Then
    '        txtCashAmount.Text = ""
    '    End If
    'End Sub

#End Region

#Region "frmPaymentLoanAndContribution Handle Piping"

    'Private Sub frmUseLoanApplicationFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseLoanApplicationFinder.Use_Clicked
    '    If Record_Desc Is Nothing Then
    '        Return
    '    End If

    '    clsLoanApplication = clsBookkeper.NewclsLoanApplication
    '    With clsLoanApplication
    '        .Init_Flag = Record_Id
    '        .Selected_Record()

    '        txtPaymentRemarks.Text = ""
    '        strRemarks = txtPaymentRemarks.Text
    '    End With

    '    'additonal parameter for CTO
    '    Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
    '    Dim dtOwner As New DataTable

    '    With clsPayment
    '        'populate billing details
    '        dgvLoanBillingDetails.Rows.Clear()
    '        dtDataGridView = .Populate_Loan_Billing_Records(clsLoanApplication._loanId, dtpORDt.Value)
    '        dtMemberId = .Populate_Loan_Billing_MemberId(clsLoanApplication._loanId)
    '        txtMemberName.Text = Trim(dtMemberId.Rows(0).Item(1))
    '        txtMemberId.Text = Trim(dtMemberId.Rows(0).Item(0))
    '        loanType = Trim(dtMemberId.Rows(0).Item(2))

    '        If Not dtDataGridView Is Nothing Then
    '            For Each Me.dtDataGridViewRow In dtDataGridView.Rows
    '                With dgvLoanBillingDetails
    '                    Dim rowndx As Integer
    '                    If Trim(dtDataGridViewRow("typeName")) = "LOAN PAYMENT" And CDbl(dtDataGridViewRow("amountDue")) = 0 Then
    '                        'do nothing
    '                    Else
    '                        rowndx = .Rows.Add()
    '                        dgvLoanBillingDetails.Item(0, rowndx).Value = 1
    '                        dgvLoanBillingDetails.Item(0, rowndx).ReadOnly = (CInt(dtDataGridViewRow("referenceId3")) = 2)
    '                        dgvLoanBillingDetails.Item(1, rowndx).Value = Trim(dtDataGridViewRow("typeId"))
    '                        dgvLoanBillingDetails.Item(2, rowndx).Value = Trim(dtDataGridViewRow("typeName"))
    '                        dgvLoanBillingDetails.Item(2, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(3, rowndx).Value = Trim(dtDataGridViewRow("billingId"))
    '                        dgvLoanBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("amountDue")), "Standard"))
    '                        dgvLoanBillingDetails.Item(4, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(5, rowndx).Value = Trim(dtDataGridViewRow("amountDueDt"))
    '                        dgvLoanBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("monthlyPayment")), "Standard"))
    '                        dgvLoanBillingDetails.Item(6, rowndx).ReadOnly = False
    '                        dgvLoanBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("billingName") & IIf(Len(dtDataGridViewRow("billingRemarks")) > 0, " - " & dtDataGridViewRow("billingRemarks"), ""))
    '                        dgvLoanBillingDetails.Item(7, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(8, rowndx).Value = CInt(dtDataGridViewRow("referenceId3"))
    '                        dgvLoanBillingDetails.Item(9, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
    '                        dgvLoanBillingDetails.Item(10, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
    '                        dgvLoanBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
    '                        dgvLoanBillingDetails.Item(12, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("interestAmount")), "Standard"))
    '                    End If


    '                End With
    '            Next

    '            For Each Me.dtDataGridViewRow In dtDataGridView.Rows
    '                With dgvLoanBillingDetails
    '                    Dim rowndx As Integer
    '                    If CDbl(dtDataGridViewRow("rebatesAmount")) > 0 And CInt(dtDataGridViewRow("referenceId3")) = 1 And dtDataGridViewRow("typeId") <> 9 Then
    '                        rowndx = .Rows.Add()
    '                        dgvLoanBillingDetails.Item(0, rowndx).Value = 1
    '                        dgvLoanBillingDetails.Item(0, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(1, rowndx).Value = 10
    '                        cboTypeId.Text = 10
    '                        cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
    '                        dgvLoanBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
    '                        dgvLoanBillingDetails.Item(2, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(3, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
    '                        dgvLoanBillingDetails.Item(4, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
    '                        dgvLoanBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
    '                        dgvLoanBillingDetails.Item(6, rowndx).ReadOnly = False
    '                        dgvLoanBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("billingName") & IIf(Len(dtDataGridViewRow("billingRemarks")) > 0, " - " & dtDataGridViewRow("billingRemarks"), ""))
    '                        dgvLoanBillingDetails.Item(7, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(8, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(9, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(10, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
    '                        dgvLoanBillingDetails.Item(12, rowndx).Value = 0
    '                    End If
    '                End With
    '            Next

    '            For Each Me.dtDataGridViewRow In dtDataGridView.Rows
    '                With dgvLoanBillingDetails
    '                    Dim rowndx As Integer
    '                    If CDbl(dtDataGridViewRow("unusedAmount")) > 0 And CInt(dtDataGridViewRow("referenceId3")) = 1 And dtDataGridViewRow("typeId") <> 9 Then
    '                        rowndx = .Rows.Add()
    '                        dgvLoanBillingDetails.Item(0, rowndx).Value = 1
    '                        dgvLoanBillingDetails.Item(0, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(1, rowndx).Value = 11
    '                        cboTypeId.Text = 11
    '                        cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
    '                        dgvLoanBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
    '                        dgvLoanBillingDetails.Item(2, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(3, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
    '                        dgvLoanBillingDetails.Item(4, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
    '                        dgvLoanBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
    '                        dgvLoanBillingDetails.Item(6, rowndx).ReadOnly = False
    '                        dgvLoanBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("billingName") & IIf(Len(dtDataGridViewRow("billingRemarks")) > 0, " - " & dtDataGridViewRow("billingRemarks"), ""))
    '                        dgvLoanBillingDetails.Item(7, rowndx).ReadOnly = True
    '                        dgvLoanBillingDetails.Item(8, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(9, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(10, rowndx).Value = 0
    '                        dgvLoanBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
    '                        dgvLoanBillingDetails.Item(12, rowndx).Value = 0
    '                    End If
    '                End With
    '            Next

    '        End If

    '        correct_Remarks()

    '        'Compute_Total_Loan_Due()
    '        'Compute_Total_Contribution_Due()
    '    End With
    'End Sub

    Private Sub dgvFinder_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvCheckDetails.RowPostPaint
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Using b As SolidBrush = New SolidBrush(sender.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  sender.DefaultCellStyle.Font, _
                                   b, _
                                   e.RowBounds.Location.X + 15, _
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub Populate_Collection()
        Try
            Dim PaymentCheckDetailItem As New Microsoft.VisualBasic.Collection
            Dim PaymentBillingDetailItem As New Microsoft.VisualBasic.Collection
            'Dim PaymentLoanBillingDetailItem As New Microsoft.VisualBasic.Collection
            'Dim PaymentContributionBillingDetailItem As New Microsoft.VisualBasic.Collection

            'Dim GridRows1 As Integer
            Dim GridRows2 As Integer
            'Dim GridRows3 As Integer
            dtPayment = dtpPaymentDate.Value

            If CInt(dgvCheckDetails.Item(1, dgvCheckDetails.Rows.Count - 1).Value) = 0 Then
                GridRows2 = dgvCheckDetails.Rows.Count - 1
            Else
                GridRows2 = dgvCheckDetails.Rows.Count
            End If

            For A As Integer = 0 To GridRows2 - 1
                clsPaymentCheckDetail = New Payment.PaymentCheck
                With clsPaymentCheckDetail
                    .check_No = CStr(dgvCheckDetails.Item("colCheckNo", A).Value)
                    .check_Amount = CDbl(dgvCheckDetails.Item("colCheckAmount", A).Value)
                    .check_Date = CDate(dgvCheckDetails.Item("colCheckDate", A).Value).ToString("yyyy-MM-dd")
                    .bank_Id = CInt(dgvCheckDetails.Item("colBankId", A).Value)
                    .bank_Branch = CStr(dgvCheckDetails.Item("colBranchName", A).Value)
                    .check_Remarks = CStr(dgvCheckDetails.Item("colCheckRemarks", A).Value)
                End With
                PaymentCheckDetailItem.Add(clsPaymentCheckDetail)
            Next

            'If CInt(dgvLoanBillingDetails.Item(0, dgvLoanBillingDetails.Rows.Count - 1).Value) = 0 Then
            '    GridRows3 = dgvLoanBillingDetails.Rows.Count - 1
            'Else
            '    GridRows3 = dgvLoanBillingDetails.Rows.Count
            'End If

            'For A As Integer = 0 To GridRows3 - 1
            '    'Loan Payments
            '    If CInt(dgvLoanBillingDetails.Item("colAmountPaid", A).Value) > 0 Then
            '        clsPaymentBillingDetail = New Payment.PaymentDetail
            '        With clsPaymentBillingDetail
            '            .billing_Id = CLng(dgvLoanBillingDetails.Item("colLoanBillId", A).Value)
            '            .type_Id = 9
            '            .amount_Paid = CDbl(dgvLoanBillingDetails.Item("colAmountPaid", A).Value)
            '            .payment_Remarks = "LOAN PAYMENT - " & CStr(dgvLoanBillingDetails.Item("colLoanType", A).Value) & " (" & dtPayment.ToString("yyyy-MM-dd") & ")"
            '            .discount_Amount = CDbl(0)
            '            .fines_Amount = CDbl(0)
            '            .reference_Id = CStr(dgvLoanBillingDetails.Item("colLoanId", A).Value)
            '        End With
            '        PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
            '    End If
            '    'Loan Interest Payments
            '    If CInt(dgvLoanBillingDetails.Item("colLoanInterest", A).Value) > 0 Then
            '        clsPaymentBillingDetail = New Payment.PaymentDetail
            '        With clsPaymentBillingDetail
            '            .billing_Id = CLng(dgvLoanBillingDetails.Item("colLoanBillId", A).Value)
            '            .type_Id = 8
            '            .amount_Paid = CDbl(dgvLoanBillingDetails.Item("colLoanInterest", A).Value)
            '            .payment_Remarks = "LOAN INTEREST - " & CStr(dgvLoanBillingDetails.Item("colLoanType", A).Value) & " (" & dtPayment.ToString("yyyy-MM-dd") & ")"
            '            .discount_Amount = CDbl(0)
            '            .fines_Amount = CDbl(0)
            '            .reference_Id = CStr(dgvLoanBillingDetails.Item("colLoanId", A).Value)
            '        End With
            '        PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
            '    End If
            'Next

            'If CInt(dgvContributionBillingDetails.Item(0, dgvContributionBillingDetails.Rows.Count - 1).Value) = 0 Then
            '    GridRows3 = dgvContributionBillingDetails.Rows.Count - 1
            'Else
            '    GridRows3 = dgvContributionBillingDetails.Rows.Count
            'End If

            'For A As Integer = 0 To GridRows3 - 1
            '    'Contribution Payments
            '    If CInt(dgvContributionBillingDetails.Item("colContribution", A).Value) > 0 Then
            '        clsPaymentBillingDetail = New Payment.PaymentDetail
            '        With clsPaymentBillingDetail
            '            .billing_Id = CLng(dgvContributionBillingDetails.Item("colContributionBillId", A).Value)
            '            .type_Id = 2
            '            .amount_Paid = CDbl(dgvContributionBillingDetails.Item("colContribution", A).Value)
            '            .payment_Remarks = "CAPITAL CONTRIBUTION (" & dtPayment.ToString("yyyy-MM-dd") & ")"
            '            .discount_Amount = CDbl(0)
            '            .fines_Amount = CDbl(0)
            '            .reference_Id = 0
            '        End With
            '        PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
            '    End If
            '    'Pabaon Payments
            '    If CInt(dgvContributionBillingDetails.Item("colPabaon", A).Value) > 0 Then
            '        clsPaymentBillingDetail = New Payment.PaymentDetail
            '        With clsPaymentBillingDetail
            '            .billing_Id = CLng(dgvContributionBillingDetails.Item("colContributionBillId", A).Value)
            '            .type_Id = 3
            '            .amount_Paid = CDbl(dgvContributionBillingDetails.Item("colPabaon", A).Value)
            '            .payment_Remarks = "PABAON (" & dtPayment.ToString("yyyy-MM-dd") & ")"
            '            .discount_Amount = CDbl(0)
            '            .fines_Amount = CDbl(0)
            '            .reference_Id = 0
            '        End With
            '        PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
            '    End If
            '    'Mortuary Payments
            '    If CInt(dgvContributionBillingDetails.Item("colMortuary", A).Value) > 0 Then
            '        clsPaymentBillingDetail = New Payment.PaymentDetail
            '        With clsPaymentBillingDetail
            '            .billing_Id = CLng(dgvContributionBillingDetails.Item("colContributionBillId", A).Value)
            '            .type_Id = 4
            '            .amount_Paid = CDbl(dgvContributionBillingDetails.Item("colMortuary", A).Value)
            '            .payment_Remarks = "MORTUARY (" & dtPayment.ToString("yyyy-MM-dd") & ")"
            '            .discount_Amount = CDbl(0)
            '            .fines_Amount = CDbl(0)
            '            .reference_Id = 0
            '        End With
            '        PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
            '    End If
            '    'PSLINK INSURANCE Payments
            '    If CInt(dgvContributionBillingDetails.Item("colPSLink", A).Value) > 0 Then
            '        clsPaymentBillingDetail = New Payment.PaymentDetail
            '        With clsPaymentBillingDetail
            '            .billing_Id = CLng(dgvContributionBillingDetails.Item("colContributionBillId", A).Value)
            '            .type_Id = 5
            '            .amount_Paid = CDbl(dgvContributionBillingDetails.Item("colPSLink", A).Value)
            '            .payment_Remarks = "PSLINK INSURANCE (" & dtPayment.ToString("yyyy-MM-dd") & ")"
            '            .discount_Amount = CDbl(0)
            '            .fines_Amount = CDbl(0)
            '            .reference_Id = 0
            '        End With
            '        PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
            '    End If
            'Next

            With clsPayment
                .colPaymentCheck_Detail = PaymentCheckDetailItem
                '.colPaymentBilling_Detail = PaymentBillingDetailItem
                '.colPaymentBilling_Detail = PaymentLoanBillingDetailItem
                '.colPaymentBilling_Detail = PaymentContributionBillingDetailItem

                PaymentCheckDetailItem = Nothing
                'PaymentBillingDetailItem = Nothing
                'PaymentLoanBillingDetailItem = Nothing
                'PaymentContributionBillingDetailItem = Nothing
            End With

        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub

#End Region

    Private Sub PrintOfficialReceiptAF51OldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintOfficialReceiptToolStripMenuItem.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsORReport As New DataSet
            Dim dtORDetail As DataTable
            Dim dtReportParameter As New DataTable
            Dim dtSystemUser As DataTable

            With clsPayment
                dtORDetail = .Populate_Payment_Report(RecordId)
                dtSystemUser = .System_User_Report
            End With

            dtORDetail.TableName = "ORDetail"
            dtSystemUser.TableName = "SystemUser"

            dsORReport.Tables.Add(dtORDetail)
            dsORReport.Tables.Add(dtSystemUser)

            frmPaymentMicrosoftReportViewer = New frmCrystalReportViewer

            dsORReport.DataSetName = "crptOfficialReceipt"
            dsORReport.WriteXml(ReportDir + "\crptOfficialReceipt.xml", XmlWriteMode.WriteSchema)
            dsORReport.WriteXmlSchema(ReportDir + "\" + "crptOfficialReceipt.xsd")

            If dtORDetail.Rows.Count > 0 Then
                With frmPaymentMicrosoftReportViewer
                    .ds = dsORReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptOfficialReceipt.rpt"
                    .ReportTitle = "Fees and Miscellaneous Payment - Official Receipt No.: [" & txtORNo.Text & "]"
                    .ShowInTaskbar = False
                    .DisplayGroupTree = False
                    .MaximizeBox = True
                    .WindowState = FormWindowState.Maximized
                    .MinimizeBox = False
                    .ShowDialog()
                End With
            Else
                clsCommon.Prompt_User("information", "There are no records available for the corresponding query.")
            End If
            Me.Cursor = Arrow
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClearCollectibleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearCollectibleToolStripMenuItem.Click
        Try
            If RecordId = 0 Then
                txtPaymentRemarks.Text = ""
                With dgvLoanBillingDetails
                    .Rows.Clear()
                End With
                With dgvContributionBillingDetails
                    .Rows.Clear()
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpORDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpORDt.Validating
        Try
            If RecordId = 0 And State <> VIEW_STATE Then
                Dim GridRows As Integer

                If CInt(dgvLoanBillingDetails.Item(0, dgvLoanBillingDetails.Rows.Count - 1).Value) = 0 Then
                    GridRows = dgvLoanBillingDetails.Rows.Count - 1
                Else
                    GridRows = dgvLoanBillingDetails.Rows.Count
                End If

                If GridRows > 0 And dtOR <> dtpORDt.Value Then
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", "Changing the OR Date will force you to clear your current billing records. You will need to reload tax due / order of payment again. Click 'YES' to continue?")
                    If iAns = vbYes Then
                        e.Cancel = False
                        txtPaymentRemarks.Text = ""
                        With dgvLoanBillingDetails
                            .Rows.Clear()
                            .AllowUserToAddRows = False
                            .AllowUserToDeleteRows = False
                        End With
                        With dgvContributionBillingDetails
                            .Rows.Clear()
                            .AllowUserToAddRows = False
                            .AllowUserToDeleteRows = False
                        End With
                        dtOR = dtpORDt.Value
                    Else
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StartORNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartORNoToolStripMenuItem.Click
        Try
            frmStartORNoPayment = clsTreasurer.NewfrmStartORNo
            clsTreasurer.UseRecordState = USE_STATE

            With frmStartORNoPayment
                .ShowDialog()
                If .isCancelled <> True Then
                    Me.txtORNo.Text = ._ORNoNumerical.ToString("00000000") & ._ORNoAlpha
                    Me.dtpORDt.Value = ._ORDate
                    dtOR = ._ORDate
                    'Saving current OR number for auto increment
                    curOR = ._ORNoNumerical
                    curAlphaOR = ._ORNoAlpha
                End If
                txtMemberName.Focus()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub StartORNo()
        StartORNoToolStripMenuItem.PerformClick()
    End Sub

    Private Sub LoadLoanCollectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadLoanCollectionToolStripMenuItem.Click
        pnlLoanCollection.Visible = True
    End Sub

    Private Sub btnLoadCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadCollection.Click
        If dtpPaymentDate.Checked = False Then
            clsCommon.Prompt_User("information", "No selected date.")
            dtpPaymentDate.Focus()
            Exit Sub
        End If
        If cboDeductionType.Text = "SALARY DEDUCTION" Then
            ref3 = 2
        ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
            ref3 = 3
        End If
        dtPayment = dtpPaymentDate.Value
        LoadLoanBillingRecords()
        LoadContributionBillingRecords()
        pnlLoanCollection.Visible = False
        txtTotalAmountDue.Text = Format(CDbl(txtTotalLoanDue.Text) + CDbl(txtTotalContributionDue.Text), "Standard")
    End Sub

    Private Sub LoadLoanBillingRecords()
        Try
            Dim listCnt As Integer = 0
            If dtpPaymentDate.Checked = False Then
                clsCommon.Prompt_User("information", "No selected date.")
                dtpPaymentDate.Focus()
            End If
            Dim closeFl As Integer = 0
            Dim tPayment As Double = 0
            Dim tInterest As Double = 0
            Dim tMem As Integer = 0

            payment_process = False
            dgvLoanBillingDetails.Rows.Clear()

            Dim rcount As Integer = 0
            If payment_process = False Then
                With dgvLoanBillingDetails
                    .Columns(8).HeaderText = "AMOUNT PAID " + vbCrLf + "(" + dtPayment.ToString("yyyy-MM-dd") + ")"
                    .Columns(9).HeaderText = "LOAN INTEREST " + vbCrLf + "(" + dtPayment.ToString("yyyy-MM-dd") + ")"
                End With
                With clsLoanPaymentUpdater
                    dtDataGridView = .Populate_Loan_Billing_List_Record(dtPayment.ToString("yyyy-MM-dd"), ref3)
                    If Not dtDataGridView Is Nothing Then
                        For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                            With dgvLoanBillingDetails
                                Dim rowndx As Integer
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = dtDataGridViewRow("memberId")
                                .Item(1, rowndx).Value = dtDataGridViewRow("memberNo")
                                .Item(2, rowndx).Value = dtDataGridViewRow("memberName")
                                .Item(3, rowndx).Value = dtDataGridViewRow("loanId")
                                .Item(4, rowndx).Value = dtDataGridViewRow("loanNo")
                                .Item(5, rowndx).Value = dtDataGridViewRow("loanType")
                                .Item(6, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                .Item(7, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                                .Item(8, rowndx).Value = dtDataGridViewRow("amountPaid")
                                .Item(9, rowndx).Value = dtDataGridViewRow("loanInterest")
                                .Item(10, rowndx).Value = dtDataGridViewRow("closeFl")
                                tPayment = tPayment + dtDataGridViewRow("amountPaid")
                                tInterest = tInterest + dtDataGridViewRow("loanInterest")
                            End With
                        Next
                    End If
                End With
                'txtTPayment.Text = Format(tPayment, "Standard")
                'txtTInterest.Text = Format(tInterest, "Standard")
                txtTotalLoanDue.Text = Format(tPayment + tInterest, "Standard")
            End If
            If dgvLoanBillingDetails.Rows.Count > 0 Then
                payment_process = True
                dgvLoanBillingDetails.Rows(0).Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadContributionBillingRecords()
        Try
            Dim memberFl As Integer = 0
            Dim tContribution As Double = 0
            Dim tPabaon As Double = 0
            Dim tMortuary As Double = 0
            Dim tPSLink As Double = 0
            Dim oTotal As Double = 0
            contribution_process = False
            dgvContributionBillingDetails.Rows.Clear()

            Dim rcount As Integer = 0
            If contribution_process = False Then
                With dgvContributionBillingDetails
                    .Columns(3).HeaderText = "CONTRIBUTION " + vbCrLf + "(" + dtPayment.ToString("yyyy-MM-dd") + ")"
                    .Columns(4).HeaderText = "PABAON " + vbCrLf + "(" + dtPayment.ToString("yyyy-MM-dd") + ")"
                    .Columns(5).HeaderText = "MORTUARY " + vbCrLf + "(" + dtPayment.ToString("yyyy-MM-dd") + ")"
                    .Columns(6).HeaderText = "PSLINK " + vbCrLf + "(" + dtPayment.ToString("yyyy-MM-dd") + ")"
                End With
                With clsContributionUpdater
                    dtDataGridView = .Populate_Member_Contribution_Billing_Record(dtPayment.ToString("yyyy-MM-dd"), ref3)
                    If Not dtDataGridView Is Nothing Then
                        For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                            With dgvContributionBillingDetails
                                Dim rowndx As Integer
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = dtDataGridViewRow("memberId")
                                .Item(1, rowndx).Value = dtDataGridViewRow("memberNo")
                                .Item(2, rowndx).Value = dtDataGridViewRow("memberName")
                                .Item(3, rowndx).Value = dtDataGridViewRow("contribution")
                                .Item(4, rowndx).Value = dtDataGridViewRow("pabaon")
                                .Item(5, rowndx).Value = dtDataGridViewRow("mortuary")
                                .Item(6, rowndx).Value = dtDataGridViewRow("pSLink")
                                .Item(7, rowndx).Value = dtDataGridViewRow("overallTotal")
                                oTotal = oTotal + dtDataGridViewRow("overallTotal")
                            End With
                        Next
                    End If
                End With
                'txtTContribution.Text = Format(tContribution, "Standard")
                'txtTPabaon.Text = Format(tPabaon, "Standard")
                'txtTMortuary.Text = Format(tMortuary, "Standard")
                'txtTPSLink.Text = Format(tPSLink, "Standard")
                txtTotalContributionDue.Text = Format(oTotal, "Standard")
            End If

            If dgvContributionBillingDetails.Rows.Count > 0 Then
                contribution_process = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancelCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelCollection.Click
        pnlLoanCollection.Visible = False
    End Sub

#Region "dgvLoanBillingDetails DataGridView Private Sub"

    Private Sub dgvLoanBillingDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLoanBillingDetails.CellValueChanged
        Try
            Dim conDt As Date = dtpPaymentDate.Text
            Dim fId As Integer = 0
            If payment_process = True Then
                Select Case e.ColumnIndex
                    Case 8 'Amount Paid
                        With dgvLoanBillingDetails
                            fId = 9
                            'Dim ref3 As Integer = 0
                            'If cboDeductionType.Text = "SALARY DEDUCTION" Then
                            '    ref3 = 2
                            'ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                            '    ref3 = 3
                            'End If
                            If clsLoanPaymentUpdater.Save_Member_Loan_Payment_Record(Trim(.Rows(e.RowIndex).Cells(3).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                                .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                                Compute_Total_Amount_Due()
                            End If
                        End With
                    Case 9 'Loan Interest
                        With dgvLoanBillingDetails
                            fId = 8
                            'Dim ref3 As Integer = 0
                            'If cboDeductionType.Text = "SALARY DEDUCTION" Then
                            '    ref3 = 2
                            'ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                            '    ref3 = 3
                            'End If
                            If clsLoanPaymentUpdater.Save_Member_Loan_Interest_Payment_Record(Trim(.Rows(e.RowIndex).Cells(3).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                                .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                                .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                                Compute_Total_Amount_Due()
                            End If
                        End With
                End Select
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvLoanBillingDetails_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvLoanBillingDetails.RowPostPaint
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Using b As SolidBrush = New SolidBrush(sender.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  sender.DefaultCellStyle.Font, _
                                   b, _
                                   e.RowBounds.Location.X + 15, _
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub dgvLoanBillingDetails_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvLoanBillingDetails.CellFormatting
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim f As Font = dgvLoanBillingDetails.DefaultCellStyle.Font

        If dgvLoanBillingDetails.Rows(e.RowIndex).Cells(10).Value = 1 AndAlso dgvLoanBillingDetails.Rows(e.RowIndex).Cells(10).Value IsNot DBNull.Value Then
            dgvLoanBillingDetails.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            dgvLoanBillingDetails.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(f, FontStyle.Strikeout Or FontStyle.Bold)
        End If
    End Sub

#End Region

#Region "dgvContributionBillingDetails Private Sub"

    Private Sub dgvContributionBillingDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvContributionBillingDetails.CellValueChanged
        Try
            Dim conDt As Date = dtpPaymentDate.Text
            Dim fId As Integer = 0
            If contribution_process = True Then
                Dim ref3 As Integer = 0
                If cboDeductionType.Text = "SALARY DEDUCTION" Then
                    ref3 = 2
                ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                    ref3 = 3
                End If
                If e.ColumnIndex = 3 Then 'Contribution
                    With dgvContributionBillingDetails
                        fId = 2
                        If clsMemberContribution.Save_Member_Contribution_Record(Trim(.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                            .Rows(e.RowIndex).Cells(7).Value = Format(CDbl(.Rows(e.RowIndex).Cells(3).Value) + CDbl(.Rows(e.RowIndex).Cells(4).Value) + CDbl(.Rows(e.RowIndex).Cells(5).Value) + CDbl(.Rows(e.RowIndex).Cells(6).Value), "Standard")
                            Compute_Total_Amount_Due()
                        Else
                            'Nothing
                        End If
                    End With
                ElseIf e.ColumnIndex = 4 Then 'Pabaon
                    With dgvContributionBillingDetails
                        fId = 3
                        If clsMemberContribution.Save_Member_Contribution_Record(Trim(.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                            .Rows(e.RowIndex).Cells(7).Value = Format(CDbl(.Rows(e.RowIndex).Cells(3).Value) + CDbl(.Rows(e.RowIndex).Cells(4).Value) + CDbl(.Rows(e.RowIndex).Cells(5).Value) + CDbl(.Rows(e.RowIndex).Cells(6).Value), "Standard")
                            Compute_Total_Amount_Due()
                        Else
                            'Nothing
                        End If
                    End With
                ElseIf e.ColumnIndex = 5 Then 'Mortuary
                    With dgvContributionBillingDetails
                        fId = 4
                        If clsMemberContribution.Save_Member_Contribution_Record(Trim(.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                            .Rows(e.RowIndex).Cells(7).Value = Format(CDbl(.Rows(e.RowIndex).Cells(3).Value) + CDbl(.Rows(e.RowIndex).Cells(4).Value) + CDbl(.Rows(e.RowIndex).Cells(5).Value) + CDbl(.Rows(e.RowIndex).Cells(6).Value), "Standard")
                            Compute_Total_Amount_Due()
                        Else
                            'Nothing
                        End If
                    End With
                ElseIf e.ColumnIndex = 6 Then 'PSLink
                    With dgvContributionBillingDetails
                        fId = 5
                        If clsMemberContribution.Save_Member_Contribution_Record(Trim(.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            .Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                            .Rows(e.RowIndex).Cells(12).Value = Format(CDbl(.Rows(e.RowIndex).Cells(3).Value) + CDbl(.Rows(e.RowIndex).Cells(4).Value) + CDbl(.Rows(e.RowIndex).Cells(5).Value) + CDbl(.Rows(e.RowIndex).Cells(6).Value), "Standard")
                            Compute_Total_Amount_Due()
                        Else
                            'Nothing
                        End If
                    End With
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvContributionBillingDetails_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvContributionBillingDetails.RowPostPaint
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Using b As SolidBrush = New SolidBrush(sender.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  sender.DefaultCellStyle.Font, _
                                   b, _
                                   e.RowBounds.Location.X + 15, _
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

#End Region

End Class