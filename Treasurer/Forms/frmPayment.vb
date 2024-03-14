Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmPayment
    Inherits System.Windows.Forms.Form

#Region "frmPayment Variable Declaration"
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
    Private PaymentBillingDetailItem As New Microsoft.VisualBasic.Collection
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

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow
    Private dtMember As New DataTable

    Private dtMemberId As New DataTable
    Private loanType As String = ""
    Private balance_process_done As Boolean

    Private KeyPressChar As Long

#End Region

#Region "frmPayment Main Form Private Sub"

    Private Sub frmPayment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        curOR = 0
        curAlphaOR = ""
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsPayment.Init_Flag = RecordId
            clsPayment.Selected_Record()
            Assign_Data()
        End If
        If State = ADD_STATE Then
            StartORNo()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmPayment_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

    Private Sub frmPayment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Disposed_Class()
    End Sub

    Private Sub frmPayment_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, dgvBillingDetails.KeyPress, dgvCheckDetails.KeyPress, dtpORDt.KeyPress, chkSaveCredit.KeyPress, txtAmountChange.KeyPress, txtCashAmount.KeyPress, txtCheckAmount.KeyPress, txtCollectorId.KeyPress, _
        txtCollectorName.KeyPress, txtMemberId.KeyPress, txtMemberName.KeyPress, txtORAmount.KeyPress, txtORNo.KeyPress, txtPaymentRemarks.KeyPress, txtTaxCreditAmount.KeyPress, txtTaxCreditAvailable.KeyPress, txtTotalAmountDue.KeyPress, txtTotalAmountPayable.KeyPress, rbCash.KeyPress, rbCashCheque.KeyPress, rbCheque.KeyPress
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

#Region "frmPayment ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmPayment As New frmPayment
                    frmTitle = "Deposits, Loans and Miscellaneous Payment"
                    If blnUseFinder Then
                        State = ADD_STATE
                        RecordId = 0
                        Call clsCommon.ClearControls(ColPayment)
                        dgvCheckDetails.Rows.Clear()
                        dgvBillingDetails.Rows.Clear()
                        Call Set_Form_State()
                        Call Default_Values()
                        Call Initialize_AutoComplete()
                        Call GetUserRecord(gUserID)
                        Me.dtpORDt.Value = Now
                        rbCash.Checked = True
                        Me.Text = "Deposits, Loans and Miscellaneous Payment"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmPayment = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmPayment.Activate()
                        Else
                            State = ADD_STATE
                            RecordId = 0
                            Call clsCommon.ClearControls(ColPayment)
                            dgvCheckDetails.Rows.Clear()
                            dgvBillingDetails.Rows.Clear()
                            Call Set_Form_State()
                            Call Default_Values()
                            Call Initialize_AutoComplete()
                            Call GetUserRecord(gUserID)
                            Me.dtpORDt.Value = Now
                            rbCash.Checked = True
                            Me.Text = "Deposits, Loans and Miscellaneous Payment"
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
                                        If .Delete_Record() Then
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
                        Dim frmFinder As frmPaymentFinder
                        frmTitle = "Payment Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.txtMemberName.Focus()
                        Else
                            frmFinder = New frmPaymentFinder("deposits, loans and miscellaneous")
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
                                .reference_Id = 0
                                .Payment_Remarks = Trim(txtPaymentRemarks.Text)

                                .Updated_Dt = txtUpdateDt.Text
                                .Updated_By = gUserID
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

                                If .Save_Record() Then
                                    State = VIEW_STATE
                                    RecordId = .Payment_Id
                                    txtUpdateDt.Text = .Updated_Dt
                                    Set_Form_State()

                                    .Init_Flag = RecordId
                                    If .Selected_Record() Then
                                        Assign_Data()
                                    End If

                                    Me.Text = "Deposits, Loans and Miscellaneous Payment - [" & Me.txtORNo.Text & "]"

                                    If clsCommon.GetRegistrySetting("Print OR AF 51", "Disabled") = "" Then
                                        Dim iAns
                                        iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to preview OR AF 51 of the corresponding payment? Press 'YES' to preview AF 51 (Old) Revision January 1992. Press 'NO' to preview AF 51 (New) Revision June 2008." & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                                        If iAns = vbYes Then
                                            PrintOfficialReceiptAF51OldToolStripMenuItem_Click(cmnsPayment, New System.EventArgs)
                                            'ElseIf iAns = vbNo Then
                                            '   PrintOfficialReceiptAF51NewToolStripMenuItem_Click(cmnsPayment, New System.EventArgs)
                                        ElseIf iAns = vbCancel Then
                                            clsCommon.SaveRegistrySetting("Print OR AF 51", "Disabled", "Yes")
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
                                        If .Selected_Record() Then
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

#Region "frmPayment User Defined Private Sub"

    Private Sub Initialize_Form()
        Set_Form_State()
        clsCommon.ClearControls(ColPayment)
        Define_Required_Fields()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Default_Values()
        Set_Max_Length()
        Initialize_AutoComplete()
        Call GetUserRecord(gUserID)
        Me.Text = "Deposits, Loans and Miscellaneous Payment"
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

        dtMember = clsDA.ExecuteQuery("SELECT memberId, TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) 'Name' FROM tblmember WHERE cancelFl = 0 AND retireFl = 0;", True, RETURN_TYPE_DATATABLE)
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
            .Add(Me.dgvBillingDetails)
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
            .Add(dgvBillingDetails)
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

            'populate check details
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

            'populate billing details
            Dim loanIdCount As Integer = 0
            dgvBillingDetails.Rows.Clear()
            dtDataGridView = .Populate_Payment_Billing_Detail
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvBillingDetails
                        Dim rowndx As Integer

                        rowndx = .Rows.Add()
                        dgvBillingDetails.Item(0, rowndx).Value = 1
                        dgvBillingDetails.Item(1, rowndx).Value = Trim(dtDataGridViewRow("typeId"))
                        dgvBillingDetails.Item(2, rowndx).Value = Trim(dtDataGridViewRow("typeName"))
                        dgvBillingDetails.Item(3, rowndx).Value = Trim(dtDataGridViewRow("billingId"))
                        dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("amountDue")), "Standard"))
                        dgvBillingDetails.Item(5, rowndx).Value = Trim(dtDataGridViewRow("amountDueDt"))
                        dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("amountPaid")), "Standard"))
                        dgvBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("paymentRemarks"))
                        dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                        dgvBillingDetails.Item(8, rowndx).Value = Trim(dtDataGridViewRow("referenceId3"))
                        dgvBillingDetails.Item(9, rowndx).Value = 0
                        dgvBillingDetails.Item(10, rowndx).Value = 0
                        dgvBillingDetails.Item(11, rowndx).Value = Trim(dtDataGridViewRow("referenceId"))
                        If CLng(dtDataGridViewRow("referenceId")) > 0 Then
                            loanIdCount = loanIdCount + 1
                        End If
                        dgvBillingDetails.Item(12, rowndx).Value = 0
                        dgvBillingDetails.Item(13, rowndx).Value = ""
                    End With
                Next

                If dtDataGridView.Rows.Count > 0 Then
                    If loanIdCount > 0 Then
                        balance_process_done = True
                        clsLoanApplication = clsBookkeper.NewclsLoanApplication
                        With clsLoanApplication
                            .Init_Flag = CInt(dtDataGridViewRow("referenceId"))
                            .Selected_Record()
                        End With
                    End If
                End If

            End If

            Compute_Total_Amount_Due()
        End With

        txtMemberName.Focus()
        Me.Text = "Deposits, Loans and Miscellaneous Payment - [" & Me.txtORNo.Text & "]"
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
        PaymentBillingDetailItem = Nothing
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
        dgvBillingDetails.Tag = "Collectible Records Details"
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
        LoadLoanScheduleToolStripMenuItem.Enabled = (State <> "View" And RecordId = 0)
        StartORNoToolStripMenuItem.Enabled = (State <> "View" And RecordId = 0)
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

    Private Sub txtTaxCreditAvailable_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTaxCreditAvailable.TextChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            If RecordId = 0 Then
                txtTaxCreditAmount.ReadOnly = (IIf((Len(txtTaxCreditAvailable.Text.Replace(",", "")) = 0), 0, Val(txtTaxCreditAvailable.Text.Replace(",", ""))) = 0)
            End If

            lblTaxCreditAvailable.Text = "(Php " & Format(txtTaxCreditAvailable.Text, "Standard") & " credit available)"
        End If
    End Sub

    Private Sub rbCash_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbCash.CheckedChanged, rbCashCheque.CheckedChanged, rbCheque.CheckedChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            'dgvBillingDetails.Rows.Clear()
            dgvCheckDetails.Rows.Clear()
            'dgvMemoDetails.Rows.Clear()
            Default_Values()
            Define_Required_Fields()
            Compute_Total_Amount_Due()
            Compute_Total_Check_Amount()
            'Compute_Total_Memo_Amount()
        End If
        Me.txtCashAmount.Enabled = Not (rbCheque.Checked) 'Or rbChequeMemo.Checked Or rbMemo.Checked
        ' Me.dgvMemoDetails.Enabled = Not (rbCash.Checked Or rbCheque.Checked Or rbCashCheque.Checked)
        Me.dgvCheckDetails.Enabled = Not (rbCash.Checked) ' Or rbCashMemo.Checked Or rbMemo.Checked
    End Sub

    Private Sub dgvBillingDetails_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillingDetails.CellValueChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Try
            If State <> VIEW_STATE Then

                Select Case LCase(dgvBillingDetails.Columns(e.ColumnIndex).Name)
                    Case "colchkcollectible"
                        Dim GridRows As Integer

                        GridRows = dgvBillingDetails.Rows.Count

                        For A As Integer = 0 To GridRows - 1
                            For B As Integer = 0 To GridRows - 1
                                If A <> B Then
                                    If CStr(dgvBillingDetails.Item("colRemarks", A).Value) = CStr(dgvBillingDetails.Item("colRemarks", B).Value) And CInt(dgvBillingDetails.Item("colTypeId", B).Value) = fineTypeId Then
                                        dgvBillingDetails.Item("colchkCollectible", B).Value = dgvBillingDetails.Item("colchkCollectible", A).Value
                                    End If
                                End If
                            Next

                        Next

                        Try
                            Dim tmpTypeName As String = CStr(dgvBillingDetails.Item(7, e.RowIndex).Value)

                            If CStr(dgvBillingDetails.Item("colTypeName", e.RowIndex).Value) = "LOAN PAYMENT" Then

                                If tmpTypeName.Contains("LOAN PAYMENT") And tmpTypeName.Contains(" - ") And CInt(dgvBillingDetails.Item(0, e.RowIndex).Value) = 0 Then
                                    Dim tmpNature As String = ""
                                    Dim tmpPrevNature As String = ""
                                    Dim tmpDashIndex As Integer = 0

                                    tmpDashIndex = tmpTypeName.IndexOf("(")
                                    tmpNature = Replace(Replace(Strings.Mid(tmpTypeName, tmpDashIndex + 1), "(", ""), ")", "")


                                    Dim tmpNextTypeName As String = CStr(dgvBillingDetails.Item(7, e.RowIndex + 1).Value)
                                    Dim tmpNextNature As String = Replace(Replace(Strings.Mid(tmpNextTypeName, tmpDashIndex + 1), "(", ""), ")", "")
                                    Dim cnt As Integer = 0

                                    Do Until Convert.ToDateTime(tmpNature) > Convert.ToDateTime(tmpNextNature)
                                        cnt += 1
                                        tmpNextTypeName = CStr(dgvBillingDetails.Item(7, e.RowIndex + cnt).Value)
                                        tmpNextNature = Replace(Replace(Strings.Mid(tmpNextTypeName, tmpDashIndex + 1), "(", ""), ")", "")
                                        If Convert.ToDateTime(tmpNature) < Convert.ToDateTime(tmpNextNature) Then
                                            dgvBillingDetails.Item(0, e.RowIndex + cnt).Value = 0
                                        End If
                                    Loop

                                ElseIf tmpTypeName.Contains("LOAN PAYMENT") And tmpTypeName.Contains(" - ") And CInt(dgvBillingDetails.Item(0, e.RowIndex).Value) = 1 And e.RowIndex <> 0 Then
                                    Dim tmpNature As String = ""
                                    Dim tmpDashIndex As Integer = 0

                                    tmpDashIndex = tmpTypeName.IndexOf("(")
                                    tmpNature = Replace(Replace(Strings.Mid(tmpTypeName, tmpDashIndex + 1), "(", ""), ")", "")

                                    Dim tmpPrevTypeName As String = CStr(dgvBillingDetails.Item(7, e.RowIndex - 1).Value)
                                    Dim tmpPrevNature As String = Replace(Replace(Strings.Mid(tmpPrevTypeName, tmpDashIndex + 1), "(", ""), ")", "")
                                    Dim cnt As Integer = 0

                                    Do Until Convert.ToDateTime(tmpNature) < Convert.ToDateTime(tmpPrevNature)
                                        cnt += 1
                                        tmpPrevTypeName = CStr(dgvBillingDetails.Item(7, e.RowIndex - cnt).Value)
                                        tmpPrevNature = Replace(Replace(Strings.Mid(tmpPrevTypeName, tmpDashIndex + 1), "(", ""), ")", "")
                                        If Convert.ToDateTime(tmpNature) > Convert.ToDateTime(tmpPrevNature) Then
                                            dgvBillingDetails.Item(0, e.RowIndex - cnt).Value = 1
                                        End If
                                    Loop
                                End If

                            End If



                        Catch ex As Exception

                        End Try
                        txtPaymentRemarks.Text = strRemarks
                        correct_Remarks()
                        Compute_Total_Amount_Due()
                        highlight_unchecked_dgvbillingdetails()
                        'end
                    Case "coltypename"
                        If cboTypeName.Items.IndexOf(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value) = -1 And Len(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value) > 0 Then
                            dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value = ""
                        Else
                            clsCollectionType = clsUtility.NewclsCollectionType
                            With clsCollectionType
                                .Init_Flag = cboTypeId.Items(cboTypeName.Items.IndexOf(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value))
                                .Selected_Record()

                                dgvBillingDetails.Item(0, e.RowIndex).Value = 1
                                dgvBillingDetails.Item(1, e.RowIndex).Value = ._typeId
                            End With
                            dgvBillingDetails.CurrentCell = dgvBillingDetails.Item(6, e.RowIndex)
                            dgvBillingDetails.Item(5, e.RowIndex).ReadOnly = False 'Due Date
                            dgvBillingDetails.Item(6, e.RowIndex).ReadOnly = False 'Total Amount
                        End If
                    Case "colDueDate"
                        Dim dDate As Date = dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value

                    Case "colamount"
                        Dim rAmount As Double = 0
                        Dim uAmount As Double = 0
                        Dim GridRows As Integer
                        GridRows = dgvBillingDetails.Rows.Count - 1
                        'Dim a As String = dgvBillingDetails.Item(11, e.RowIndex).Value
                        If balance_process_done = True Then
                            If CInt(dgvBillingDetails.Item(1, e.RowIndex).Value) = 9 Then
                                If CDbl(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Replace(",", "")) > 0 And CDbl(dgvBillingDetails.Item(4, e.RowIndex).Value.ToString.Replace(",", "")) = CDbl(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Replace(",", "")) Then
                                    rAmount = clsLoanApplication.RebatesGet(CInt(dgvBillingDetails.Item(11, e.RowIndex).Value), CInt(txtMemberId.Text), dtpORDt.Value.ToString("yyyy-MM-dd")) * -1
                                    uAmount = clsLoanApplication.CISPUnusedGet(CInt(dgvBillingDetails.Item(11, e.RowIndex).Value), CInt(txtMemberId.Text), dtpORDt.Value.ToString("yyyy-MM-dd")) * -1
                                    With dgvBillingDetails
                                        Dim rowndx As Integer
                                        If rAmount < 0 Then
                                            rowndx = .Rows.Add()
                                            .Item(0, rowndx).Value = 1
                                            .Item(0, rowndx).ReadOnly = True
                                            .Item(1, rowndx).Value = 10
                                            cboTypeId.Text = 10
                                            cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                                            .Item(2, rowndx).Value = cboTypeName.Text
                                            .Item(2, rowndx).ReadOnly = True
                                            .Item(3, rowndx).Value = 0
                                            .Item(4, rowndx).Value = Trim(Format(rAmount, "Standard"))
                                            .Item(4, rowndx).ReadOnly = True
                                            .Item(5, rowndx).Value = dtpORDt.Value
                                            .Item(6, rowndx).Value = Trim(Format(rAmount, "Standard"))
                                            .Item(6, rowndx).ReadOnly = False
                                            .Item(7, rowndx).Value = "LOAN INTEREST (REBATES) - " & Trim(dgvBillingDetails.Item(13, e.RowIndex).Value)
                                            .Item(7, rowndx).ReadOnly = True
                                            .Item(8, rowndx).Value = 0
                                            .Item(9, rowndx).Value = 0
                                            .Item(10, rowndx).Value = 0
                                            .Item(11, rowndx).Value = CInt(dgvBillingDetails.Item(11, e.RowIndex).Value)
                                            .Item(12, rowndx).Value = 0
                                        End If
                                    End With

                                    With dgvBillingDetails
                                        Dim rowndx As Integer
                                        If uAmount < 0 Then
                                            rowndx = .Rows.Add()
                                            .Item(0, rowndx).Value = 1
                                            .Item(0, rowndx).ReadOnly = True
                                            .Item(1, rowndx).Value = 11
                                            cboTypeId.Text = 11
                                            cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                                            .Item(2, rowndx).Value = cboTypeName.Text
                                            .Item(2, rowndx).ReadOnly = True
                                            .Item(3, rowndx).Value = 0
                                            .Item(4, rowndx).Value = Trim(Format(uAmount, "Standard"))
                                            .Item(4, rowndx).ReadOnly = True
                                            .Item(5, rowndx).Value = dtpORDt.Value
                                            .Item(6, rowndx).Value = Trim(Format(uAmount, "Standard"))
                                            .Item(6, rowndx).ReadOnly = False
                                            .Item(7, rowndx).Value = "CSIP (UNUSED) - " & Trim(dgvBillingDetails.Item(13, e.RowIndex).Value)
                                            .Item(7, rowndx).ReadOnly = True
                                            .Item(8, rowndx).Value = 0
                                            .Item(9, rowndx).Value = 0
                                            .Item(10, rowndx).Value = 0
                                            .Item(11, rowndx).Value = CInt(dgvBillingDetails.Item(11, e.RowIndex).Value)
                                            .Item(12, rowndx).Value = 0
                                        End If
                                    End With
                                ElseIf CDbl(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Replace(",", "")) > 0 And CDbl(dgvBillingDetails.Item(4, e.RowIndex).Value.ToString.Replace(",", "")) > CDbl(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Replace(",", "")) Then
                                    With dgvBillingDetails
                                        For i = GridRows To 0 Step -1
                                            If CInt(dgvBillingDetails.Item(11, i).Value) = CInt(dgvBillingDetails.Item(11, e.RowIndex).Value) And (CInt(.Item(1, i).Value) = 10 Or CInt(.Item(1, i).Value) = 11) Then
                                                .Rows.RemoveAt(i)
                                            End If
                                        Next
                                    End With
                                End If
                                If CDbl(clsPayment.GetMemberBalanceAmountTotal(CInt(dgvBillingDetails.Rows(e.RowIndex).Cells(11).Value), CInt(txtMemberId.Text))) < CDbl(dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex).Value.ToString.Replace(",", "")) Then
                                    clsCommon.Prompt_User("error", "Amount invalid. Amount to pay should not be greater than to amount due.")
                                    dgvBillingDetails.Item(6, e.RowIndex).Value = CDbl(dgvBillingDetails.Item(4, e.RowIndex).Value)
                                    Exit Sub
                                End If
                            End If
                        End If
                        Compute_Total_Amount_Due()
                End Select
            End If
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
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

    Private Sub dgvBillingDetails_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvBillingDetails.EditingControlShowing
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            If State <> VIEW_STATE Then
                Dim dataCombo As DataSet
                Dim dataComboRow As DataRow

                If CInt(dgvBillingDetails.Columns(dgvBillingDetails.CurrentCell.ColumnIndex).ToolTipText) = 0 AndAlso TypeOf e.Control Is TextBox Then
                    Select Case LCase(dgvBillingDetails.Columns(dgvBillingDetails.CurrentCell.ColumnIndex).Name)
                        Case "coltypename"
                            With clsPayment
                                dataCombo = .GetCollectionTypeList

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

    Private Sub dgvBillingDetails_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvBillingDetails.CellValidating
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            Dim fAmount As Double = 0
            Dim cell As DataGridViewCell = dgvBillingDetails.Item(e.ColumnIndex, e.RowIndex)

            If cell.IsInEditMode Then
                Dim c As Control = dgvBillingDetails.EditingControl

                Select Case dgvBillingDetails.Columns(e.ColumnIndex).Name
                    Case "colTypeName"
                        If CInt(dgvBillingDetails.Item(1, e.RowIndex).Value) > 0 Then
                            With clsPayment
                                fAmount = .GetCollectionFeeDefault(CInt(dgvBillingDetails.Item(1, e.RowIndex).Value))
                                dgvBillingDetails.Item(6, e.RowIndex).Value = Format(fAmount, "Standard")
                                If fAmount <> 0 Then
                                    dgvBillingDetails.Item(6, e.RowIndex).ReadOnly = True
                                End If
                            End With
                        End If
                    Case "colAmount"
                        c.Text = Format(CDbl(clsCommon.CleanInputFloat(c.Text)), "#,##0.00")
                End Select
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

    Private Sub dgvBillingDetails_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgvBillingDetails.RowsRemoved
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If State <> VIEW_STATE Then
            Compute_Total_Amount_Due()
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
            Dim GridRows As Integer
            Dim TotalAmountDue As Double

            If CInt(dgvBillingDetails.Item(0, dgvBillingDetails.Rows.Count - 1).Value) = 0 Then
                GridRows = dgvBillingDetails.Rows.Count - 1
            Else
                GridRows = dgvBillingDetails.Rows.Count
            End If

            TotalAmountDue = 0
            For A As Integer = 0 To GridRows - 1
                If CInt(dgvBillingDetails.Item(0, A).Value) = 1 Then
                    TotalAmountDue = TotalAmountDue + CDbl(dgvBillingDetails.Item("colAmount", A).Value)
                End If
            Next

            txtTotalAmountDue.Text = Format(TotalAmountDue, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotalAmountDue_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalAmountDue.TextChanged, txtCashAmount.TextChanged, txtCheckAmount.TextChanged ', txtTaxCreditAmount.TextChanged
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

            Dim GridRows3 As Integer
            Dim checkedRec As Integer = 0

            'If CInt(dgvBillingDetails.Item(0, dgvBillingDetails.Rows.Count - 1).Value) = 0 Then
            '    GridRows3 = dgvBillingDetails.Rows.Count - 1
            'Else
            '    GridRows3 = dgvBillingDetails.Rows.Count
            'End If

            'Dim lessrow As Integer = 1

            'If dgvBillingDetails.AllowUserToAddRows Then
            '    lessrow = 2
            'End If

            GridRows3 = dgvBillingDetails.Rows.Count

            For A As Integer = 0 To GridRows3 - 2
                If (CInt(dgvBillingDetails.Item("colchkCollectible", A).Value) = 1) And (CDbl(dgvBillingDetails.Item("colAmount", A).Value) = 0) Then
                    clsCommon.Prompt_User("error", "Can not save payment record. Amount to pay should not be less than or equal to zero.")
                    Return False
                End If

                If (CInt(dgvBillingDetails.Item("colchkCollectible", A).Value) = 1) Then
                    checkedRec = +1
                End If
                'If CStr(dgvBillingDetails.Item("colPaymentMode", A).Value) = "" Then
                '    clsCommon.Prompt_User("error", "Can not save payment record. You should set payment mode (partial or full payment) for billing record at row " & CStr(A + 1) & ".")
                '    Return False
                'End If
                'colchkCollectible
            Next

            'check if amount paid is less than amount due
            If CDbl(txtTotalAmountPayable.Text) < CDbl(txtTotalAmountDue.Text) Then
                clsCommon.Prompt_User("error", "Can not save payment record. Amount paid is less than amount due.")
                Return False
            End If

            If checkedRec = 0 Then
                clsCommon.Prompt_User("error", "Can not save payment record. There are no 'CHECKED' collectible records in your payment record.")
                Return False
            End If

            If txtMemberName.Text <> "" Then
                Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
                Dim dtTemp As New DataTable

                dtTemp = clsDA.ExecuteQuery("SELECT memberId FROM tblmember WHERE  TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) = '" & clsCommon.ReplaceSingleQuotes(txtMemberName.Text) & "';", True, RETURN_TYPE_DATATABLE)

                If dtTemp.Rows.Count > 0 Then
                    txtMemberId.Text = CStr(dtTemp.Rows(0)(0))
                    Return True
                    'Else
                    'clsCommon.Prompt_User("error", "No member record found on database. Please click Payor Name and manually ADD and USE instead.")
                    'Return False
                End If

                'For Each drow As DataRow In dtConstituent.Rows
                '    If Trim(UCase(txtConstituentName.Text)) = Trim(UCase(CStr(drow("Name")))) Then
                '        txtConstituentId.Text = CStr(drow("constituentId"))
                '        Return True
                '    End If
                'Next
                'clsCommon.Prompt_User("error", "No constituent record found on database. Please click Payor Name and manually ADD and USE instead.")
                'Return False
            End If

            Return True
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
            Return False
        End Try
    End Function

    Private Sub correct_Remarks()
      
    End Sub

    Private Sub highlight_unchecked_dgvbillingdetails()
        For x As Integer = 0 To dgvBillingDetails.RowCount - 1
            'Edit by zhalick highlight unchecked
            If CInt(dgvBillingDetails.Item(0, x).Value) <> 1 Then
                dgvBillingDetails.Rows(x).DefaultCellStyle.BackColor = Pink
            Else
                dgvBillingDetails.Rows(x).DefaultCellStyle.BackColor = White
            End If
        Next
        Try
            'colorCode()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtCashAmount_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCashAmount.GotFocus
        If State <> VIEW_STATE Then
            txtCashAmount.Text = ""
        End If
    End Sub

#End Region

#Region "frmPayment Label Piping Click"

    'Private Sub lblConstituentName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblConstituentName.Click
    '    Try
    '        frmUseConstituentFinder = clsConstituent.NewfrmConstituentFinder
    '        clsConstituent.UseRecordState = USE_STATE

    '        With frmUseConstituentFinder
    '            .frmMainUser = Me
    '            .MaximizeBox = False
    '            .MinimizeBox = False

    '            .ShowDialog()
    '        End With

    '        'constituent list
    '        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
    '        Dim autoSourceCollection As New AutoCompleteStringCollection()
    '        Dim drow As DataRow

    '        dtConstituent = clsDA.ExecuteQuery("SELECT constituentId, TRIM(IF(constituentType='INDIVIDUAL',CONCAT(lastName, IF(LENGTH(suffixName),' ',''),suffixName,', ',firstName, ' ',middleName),firstname)) 'Name' FROM tblconstituent;", True, RETURN_TYPE_DATATABLE)
    '        txtConstituentName.AutoCompleteSource = AutoCompleteSource.None

    '        For Each drow In dtConstituent.Rows
    '            Dim a As String = drow.Item("Name")
    '            autoSourceCollection.Add(drow.Item("Name"))
    '        Next

    '        txtConstituentName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        txtConstituentName.AutoCompleteCustomSource = autoSourceCollection
    '        txtConstituentName.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region "frmPayment Handle Piping"

    Private Sub frmUseLoanApplicationFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String) Handles frmUseLoanApplicationFinder.Use_Clicked
        If Record_Desc Is Nothing Then
            Return
        End If

        clsLoanApplication = clsBookkeper.NewclsLoanApplication
        With clsLoanApplication
            .Init_Flag = Record_Id
            .Selected_Record()

            txtPaymentRemarks.Text = ""
            strRemarks = txtPaymentRemarks.Text
        End With

        'additonal parameter for CTO
        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
        Dim dtOwner As New DataTable

        With clsPayment
            'populate billing details
            dgvBillingDetails.Rows.Clear()
            dtDataGridView = .Populate_Loan_Billing_Records(clsLoanApplication._loanId, dtpORDt.Value)
            dtMemberId = .Populate_Loan_Billing_MemberId(clsLoanApplication._loanId)
            txtMemberName.Text = Trim(dtMemberId.Rows(0).Item(1))
            txtMemberId.Text = Trim(dtMemberId.Rows(0).Item(0))
            loanType = Trim(dtMemberId.Rows(0).Item(2))

            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvBillingDetails
                        Dim rowndx As Integer
                        If Trim(dtDataGridViewRow("typeName")) = "LOAN PAYMENT" And CDbl(dtDataGridViewRow("amountDue")) = 0 Then
                            'do nothing
                        Else
                            rowndx = .Rows.Add()
                            dgvBillingDetails.Item(0, rowndx).Value = 1
                            dgvBillingDetails.Item(0, rowndx).ReadOnly = (CInt(dtDataGridViewRow("referenceId3")) = 2)
                            dgvBillingDetails.Item(1, rowndx).Value = Trim(dtDataGridViewRow("typeId"))
                            dgvBillingDetails.Item(2, rowndx).Value = Trim(dtDataGridViewRow("typeName"))
                            dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(3, rowndx).Value = Trim(dtDataGridViewRow("billingId"))
                            dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("amountDue")), "Standard"))
                            dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(5, rowndx).Value = Trim(dtDataGridViewRow("amountDueDt"))
                            dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("monthlyPayment")), "Standard"))
                            dgvBillingDetails.Item(6, rowndx).ReadOnly = False
                            dgvBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("billingName") & IIf(Len(dtDataGridViewRow("billingRemarks")) > 0, " - " & dtDataGridViewRow("billingRemarks"), ""))
                            dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(8, rowndx).Value = CInt(dtDataGridViewRow("referenceId3"))
                            dgvBillingDetails.Item(9, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
                            dgvBillingDetails.Item(10, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
                            dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                            dgvBillingDetails.Item(12, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("interestAmount")), "Standard"))
                        End If


                    End With
                Next

                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvBillingDetails
                        Dim rowndx As Integer
                        If CDbl(dtDataGridViewRow("rebatesAmount")) > 0 And CInt(dtDataGridViewRow("referenceId3")) = 1 And dtDataGridViewRow("typeId") <> 9 Then
                            rowndx = .Rows.Add()
                            dgvBillingDetails.Item(0, rowndx).Value = 1
                            dgvBillingDetails.Item(0, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(1, rowndx).Value = 10
                            cboTypeId.Text = 10
                            cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                            dgvBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
                            dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(3, rowndx).Value = 0
                            dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
                            dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
                            dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
                            dgvBillingDetails.Item(6, rowndx).ReadOnly = False
                            dgvBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("billingName") & IIf(Len(dtDataGridViewRow("billingRemarks")) > 0, " - " & dtDataGridViewRow("billingRemarks"), ""))
                            dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(8, rowndx).Value = 0
                            dgvBillingDetails.Item(9, rowndx).Value = 0
                            dgvBillingDetails.Item(10, rowndx).Value = 0
                            dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                            dgvBillingDetails.Item(12, rowndx).Value = 0
                        End If
                    End With
                Next

                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    With dgvBillingDetails
                        Dim rowndx As Integer
                        If CDbl(dtDataGridViewRow("unusedAmount")) > 0 And CInt(dtDataGridViewRow("referenceId3")) = 1 And dtDataGridViewRow("typeId") <> 9 Then
                            rowndx = .Rows.Add()
                            dgvBillingDetails.Item(0, rowndx).Value = 1
                            dgvBillingDetails.Item(0, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(1, rowndx).Value = 11
                            cboTypeId.Text = 11
                            cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                            dgvBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
                            dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(3, rowndx).Value = 0
                            dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
                            dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
                            dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
                            dgvBillingDetails.Item(6, rowndx).ReadOnly = False
                            dgvBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("billingName") & IIf(Len(dtDataGridViewRow("billingRemarks")) > 0, " - " & dtDataGridViewRow("billingRemarks"), ""))
                            dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(8, rowndx).Value = 0
                            dgvBillingDetails.Item(9, rowndx).Value = 0
                            dgvBillingDetails.Item(10, rowndx).Value = 0
                            dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                            dgvBillingDetails.Item(12, rowndx).Value = 0
                        End If
                    End With
                Next

                'dgvBillingDetails.Rows.Add()

                If dtDataGridView.Rows.Count > 0 Then
                    With dgvBillingDetails
                        .AllowUserToDeleteRows = False
                        .AllowUserToAddRows = True
                    End With
                End If
            End If

            correct_Remarks()

            Compute_Total_Amount_Due()
        End With
    End Sub

    Private Sub dgvFinder_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvBillingDetails.RowPostPaint, dgvCheckDetails.RowPostPaint
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

            'Dim GridRows1 As Integer
            Dim GridRows2 As Integer
            Dim GridRows3 As Integer

            'If Len(CStr(dgvMemoDetails.Item(0, dgvMemoDetails.Rows.Count - 1).Value)) = 0 Then
            '    GridRows1 = dgvMemoDetails.Rows.Count - 1
            'Else
            '    GridRows1 = dgvMemoDetails.Rows.Count
            'End If

            'For A As Integer = 0 To GridRows1 - 1
            '    clsPaymentMemo = New Payment.PaymentMemo
            '    With clsPaymentMemo
            '        .memo_No = CStr(dgvMemoDetails.Item("colMemoNo", A).Value)
            '        .memo_Amount = CDbl(dgvMemoDetails.Item("colMemoAmount", A).Value)
            '        .memo_Date = CDate(dgvMemoDetails.Item("colMemoDate", A).Value).ToString("yyyy-MM-dd")
            '        .memo_Remarks = CStr(dgvMemoDetails.Item("colMemoRemarks", A).Value)
            '    End With
            '    PaymentMemoDetailItem.Add(clsPaymentMemo)
            'Next

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

            If CInt(dgvBillingDetails.Item(0, dgvBillingDetails.Rows.Count - 1).Value) = 0 Then
                GridRows3 = dgvBillingDetails.Rows.Count - 1
            Else
                GridRows3 = dgvBillingDetails.Rows.Count
            End If

            For A As Integer = 0 To GridRows3 - 1
                If CInt(dgvBillingDetails.Item("colchkCollectible", A).Value) = 1 And CInt(dgvBillingDetails.Item("colTypeId", A).Value) > 0 Then
                    clsPaymentBillingDetail = New Payment.PaymentDetail
                    With clsPaymentBillingDetail
                        Dim aa As Long = CLng(dgvBillingDetails.Item("colBillingId", A).Value)
                        .billing_Id = CLng(dgvBillingDetails.Item("colBillingId", A).Value)
                        .type_Id = CInt(dgvBillingDetails.Item("colTypeId", A).Value)
                        .amount_Paid = CDbl(dgvBillingDetails.Item("colAmount", A).Value)
                        .payment_Remarks = CStr(dgvBillingDetails.Item("colRemarks", A).Value)
                        .discount_Amount = CDbl(0)
                        .fines_Amount = CDbl(0)
                        .reference_Id = CStr(dgvBillingDetails.Item("colReferenceId", A).Value)
                    End With
                    PaymentBillingDetailItem.Add(clsPaymentBillingDetail)
                End If
            Next

            With clsPayment
                .colPaymentCheck_Detail = PaymentCheckDetailItem
                .colPaymentBilling_Detail = PaymentBillingDetailItem

                PaymentCheckDetailItem = Nothing
                PaymentBillingDetailItem = Nothing
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
                    .ReportTitle = "Deposits, Loans and Miscellaneous Payment - Official Receipt No.: [" & txtORNo.Text & "]"
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
                With dgvBillingDetails
                    .Rows.Clear()
                    .AllowUserToAddRows = True
                    .AllowUserToDeleteRows = True
                End With
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadLoanScheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadLoanScheduleToolStripMenuItem.Click
        'pnlBillingRecord.Visible = True
        If Len(txtMemberId.Text) > 0 Then
            'Dim colDt As Date = dtpPaymentDate.Value
            txtPaymentRemarks.Text = "PAYMENT FOR LOAN APPLICATION"
            strRemarks = txtPaymentRemarks.Text
            balance_process_done = False
            With clsPayment
                'populate billing details
                dgvBillingDetails.Rows.Clear()
                dtDataGridView = .Populate_Loan_Billing_Records(CInt(txtMemberId.Text), dtpORDt.Value)

                If Not dtDataGridView Is Nothing Then
                    For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                        With dgvBillingDetails
                            Dim rowndx As Integer
                            rowndx = .Rows.Add()
                            dgvBillingDetails.Item(0, rowndx).Value = 1
                            dgvBillingDetails.Item(0, rowndx).ReadOnly = (CInt(dtDataGridViewRow("referenceId3")) = 2)
                            dgvBillingDetails.Item(1, rowndx).Value = Trim(dtDataGridViewRow("typeId"))
                            dgvBillingDetails.Item(2, rowndx).Value = Trim(dtDataGridViewRow("typeName"))
                            dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(3, rowndx).Value = Trim(dtDataGridViewRow("billingId"))
                            dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("amountDue")), "Standard"))
                            dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(5, rowndx).Value = Trim(dtDataGridViewRow("amountDueDt"))
                            dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("monthlyPayment")), "Standard"))
                            dgvBillingDetails.Item(6, rowndx).ReadOnly = False
                            dgvBillingDetails.Item(7, rowndx).Value = Trim(dtDataGridViewRow("typeName")) & " - " & Trim(dtDataGridViewRow("type")) & " (" & Trim(dtDataGridViewRow("amountDueDt")) & ")"
                            dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                            dgvBillingDetails.Item(8, rowndx).Value = CInt(dtDataGridViewRow("referenceId3"))
                            dgvBillingDetails.Item(9, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
                            dgvBillingDetails.Item(10, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
                            dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                            dgvBillingDetails.Item(12, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("interestAmount")), "Standard"))
                            dgvBillingDetails.Item(13, rowndx).Value = Trim(dtDataGridViewRow("loanType"))
                        End With
                    Next

                    For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                        With dgvBillingDetails
                            Dim rowndx As Integer
                            If CDbl(dtDataGridViewRow("interestAmount")) > 0 Then
                                rowndx = .Rows.Add()
                                dgvBillingDetails.Item(0, rowndx).Value = 1
                                dgvBillingDetails.Item(0, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(1, rowndx).Value = 8
                                cboTypeId.Text = 8
                                cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                                dgvBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
                                dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(3, rowndx).Value = 0
                                dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("interestAmount")), "Standard"))
                                dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
                                dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("interestAmount")), "Standard"))
                                dgvBillingDetails.Item(6, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(7, rowndx).Value = cboTypeName.Text & " - " & Trim(dtDataGridViewRow("type")) & " (" & " (" & Trim(dtDataGridViewRow("amountDueDt")) & ")"
                                dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(8, rowndx).Value = 0
                                dgvBillingDetails.Item(9, rowndx).Value = 0
                                dgvBillingDetails.Item(10, rowndx).Value = 0
                                dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                                dgvBillingDetails.Item(12, rowndx).Value = 0
                                dgvBillingDetails.Item(13, rowndx).Value = Trim(dtDataGridViewRow("type"))
                            End If
                        End With
                    Next

                    For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                        With dgvBillingDetails
                            Dim rowndx As Integer
                            If CDbl(dtDataGridViewRow("rebatesAmount")) > 0 And CInt(dtDataGridViewRow("referenceId3")) = 1 And dtDataGridViewRow("typeId") <> 9 Then
                                rowndx = .Rows.Add()
                                dgvBillingDetails.Item(0, rowndx).Value = 1
                                dgvBillingDetails.Item(0, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(1, rowndx).Value = 10
                                cboTypeId.Text = 10
                                cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                                dgvBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
                                dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(3, rowndx).Value = 0
                                dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
                                dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
                                dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("rebatesAmount")), "Standard"))
                                dgvBillingDetails.Item(6, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(7, rowndx).Value = cboTypeName.Text & " - " & Trim(dtDataGridViewRow("type")) & " (" & " (" & Trim(dtDataGridViewRow("amountDueDt")) & ")"
                                dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(8, rowndx).Value = 0
                                dgvBillingDetails.Item(9, rowndx).Value = 0
                                dgvBillingDetails.Item(10, rowndx).Value = 0
                                dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                                dgvBillingDetails.Item(12, rowndx).Value = 0
                                dgvBillingDetails.Item(13, rowndx).Value = Trim(dtDataGridViewRow("loanType"))
                            End If
                        End With
                    Next

                    For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                        With dgvBillingDetails
                            Dim rowndx As Integer
                            If CDbl(dtDataGridViewRow("unusedAmount")) > 0 And CInt(dtDataGridViewRow("referenceId3")) = 1 And dtDataGridViewRow("typeId") <> 9 Then
                                rowndx = .Rows.Add()
                                dgvBillingDetails.Item(0, rowndx).Value = 1
                                dgvBillingDetails.Item(0, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(1, rowndx).Value = 11
                                cboTypeId.Text = 11
                                cboTypeName.SelectedIndex = cboTypeId.SelectedIndex
                                dgvBillingDetails.Item(2, rowndx).Value = cboTypeName.Text
                                dgvBillingDetails.Item(2, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(3, rowndx).Value = 0
                                dgvBillingDetails.Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
                                dgvBillingDetails.Item(4, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(5, rowndx).Value = dtpORDt.Value
                                dgvBillingDetails.Item(6, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("unusedAmount")), "Standard"))
                                dgvBillingDetails.Item(6, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(7, rowndx).Value = cboTypeName.Text & " - " & Trim(dtDataGridViewRow("type")) & " (" & " (" & Trim(dtDataGridViewRow("amountDueDt")) & ")"
                                dgvBillingDetails.Item(7, rowndx).ReadOnly = True
                                dgvBillingDetails.Item(8, rowndx).Value = 0
                                dgvBillingDetails.Item(9, rowndx).Value = 0
                                dgvBillingDetails.Item(10, rowndx).Value = 0
                                dgvBillingDetails.Item(11, rowndx).Value = CInt(dtDataGridViewRow("referenceId"))
                                dgvBillingDetails.Item(12, rowndx).Value = 0
                                dgvBillingDetails.Item(13, rowndx).Value = Trim(dtDataGridViewRow("loanType"))
                            End If
                        End With
                    Next
                    If dtDataGridView.Rows.Count > 0 Then
                        With dgvBillingDetails
                            .AllowUserToDeleteRows = True
                            .AllowUserToAddRows = True
                            balance_process_done = True
                        End With
                    End If
                End If
                correct_Remarks()
                Compute_Total_Amount_Due()
            End With
            'pnlBillingRecord.Visible = False
            'balance_process_done = False
            'ClearCollectibleToolStripMenuItem.PerformClick()

            'Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
            'Dim dtBillId As New DataTable
            'dtBillId = clsDA.ExecuteQuery("SELECT loanId FROM tblloanapplication WHERE memberId = '" & CStr(txtMemberId.Text) & "';", True, RETURN_TYPE_DATATABLE)

            'If dtBillId.Rows.Count = 1 Then
            'balance_process_done = False
            'frmUseLoanApplicationFinder_Use_Clicked(CInt(dtBillId.Rows(0).Item(0)), "", "")
            'Else
            'balance_process_done = False
            'ClearCollectibleToolStripMenuItem.PerformClick()
            'End If

            'frmUseLoanApplicationFinder = clsBookkeper.NewfrmLoanApplicationFinder
            'clsBookkeper.UseRecordState = USE_STATE

            'With frmUseLoanApplicationFinder
            '    .frmMainUser = Me
            '    .MaximizeBox = False
            '    .MinimizeBox = False

            '    .ShowDialog()
            'End With
        End If

    End Sub

    'Private Sub Load_Loan_Balance_Data()
    '    'Populate Tax Declaration Information
    '    Try
    '        If balance_process_done = True Then
    '            dgvBalanceRecord.Rows.Clear()
    '            dgvTaxDue.Rows.Clear()
    '            Dim rcount As Integer = 0
    '            balance_process_done = False
    '            With clsRealPropertyBilling
    '                txtBillNumber.Text = ._realPropertyBillingNo
    '                dtDataGridView = .Populate_Real_Property_Billing_Tax_Declaration(._realPropertyBillingId)
    '                If Not dtDataGridView Is Nothing Then
    '                    For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
    '                        With dgvBillingRecord
    '                            Dim rowndx As Integer
    '                            rowndx = .Rows.Add()
    '                            .Item(1, rowndx).Value = dtDataGridViewRow("taxDeclarationId")
    '                            .Item(2, rowndx).Value = dtDataGridViewRow("taxDeclarationNo")
    '                            .Item(3, rowndx).Value = dtDataGridViewRow("ownerName")
    '                            .Item(4, rowndx).Value = dtDataGridViewRow("ownerAddress")
    '                            .Item(0, rowndx).Value = 0
    '                            dgv_checker(0, dtDataGridViewRow("taxDeclarationNo"))

    '                            If CInt(dtDataGridViewRow("taxDeclarationId")) = 0 Then
    '                                'Temporary tax declaration records
    '                                If clsTaxDeclaration.Populate_Tax_Declaration_Due_Temp_Record(Trim(dtDataGridViewRow("taxDeclarationNo"))).Rows.Count = 0 Then
    '                                    .Rows(rowndx).DefaultCellStyle.BackColor = highlight_unchecked(.Item(0, rowndx).Value)
    '                                    .Rows(rowndx).ReadOnly = True
    '                                End If
    '                            Else
    '                                If clsTaxDeclaration.Populate_Tax_Declaration_Due_Record(CInt(dtDataGridViewRow("taxDeclarationId"))).Rows.Count = 0 Then
    '                                    .Rows(rowndx).DefaultCellStyle.BackColor = highlight_unchecked(.Item(0, rowndx).Value)
    '                                    .Rows(rowndx).ReadOnly = True
    '                                End If
    '                            End If
    '                            .Item(5, rowndx).Value = CStr(dtDataGridViewRow("detailRemarks"))
    '                        End With
    '                    Next
    '                    balance_process_done = True
    '                    If RPTAnnuallyToolStripMenuItem.Enabled = False Then
    '                        RPTQuarterlyToolStripMenuItem.PerformClick()
    '                    End If
    '                End If
    '            End With
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub dtpORDt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpORDt.Validating
        Try
            If RecordId = 0 And State <> VIEW_STATE Then
                Dim GridRows As Integer

                If CInt(dgvBillingDetails.Item(0, dgvBillingDetails.Rows.Count - 1).Value) = 0 Then
                    GridRows = dgvBillingDetails.Rows.Count - 1
                Else
                    GridRows = dgvBillingDetails.Rows.Count
                End If

                If GridRows > 0 And dtOR <> dtpORDt.Value Then
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", "Changing the OR Date will force you to clear your current billing records. You will need to reload tax due / order of payment again. Click 'YES' to continue?")
                    If iAns = vbYes Then
                        e.Cancel = False
                        txtPaymentRemarks.Text = ""
                        With dgvBillingDetails
                            .Rows.Clear()
                            .AllowUserToAddRows = True
                            .AllowUserToDeleteRows = True
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

    End Sub
End Class