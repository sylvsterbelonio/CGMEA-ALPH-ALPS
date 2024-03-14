Imports System.IO
Imports System.Drawing
Imports System.Drawing.Color
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmLoanApplication
    Inherits System.Windows.Forms.Form

#Region "frmLoanApplication Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsLoanApplication As New LoanApplication.LoanApplication
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsUtility As New Utility.Utility(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMember As Personnel.Member.Member
    Private WithEvents clsSignatory As Utility.Signatory.Signatory
    Private WithEvents clsMemberSignatory As Utility.MemberSignatory.MemberSignatory
    Private WithEvents clsLoanType As New LoanType.LoanType

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
    Private clsLoanApplicationDetails As New LoanApplicationDetails.LoanApplicationDetails

    Private frmLoanApplicationReportViewer As frmCrystalReportViewer

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmLoanApplicationFinder
    Private txtUpdateDt As New TextBox
    Private Piping_ToolTip As New ToolTip

    Private WithEvents frmLoanCalculatorForm As frmLoanCalculator
    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride
    Private WithEvents frmUseMemberSignatoryFinder As Utility.frmMemberSignatoryFinder = Nothing
    Private WithEvents frmUseSignatoryFinder As Utility.frmSignatoryFinder = Nothing

    'declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColLoanApplication As New Collection
    Private CurRow As New DataGridViewRow

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False
    Private allowCloseFromCalculator As Boolean = False
    Private KeyPressChar As Long

    Private valueDt As Date
    Private minAmount As Double
    Private maxAmount As Double
    Private intTerm As Double

    Private loan_balance_process As Boolean = False
    Private loan_fee_process As Boolean = False

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow
    Private dtMember As New DataTable
    Private dtTerm As New DataTable

#End Region

#Region "frmLoanApplication Main Form Private Sub"

    Private Sub frmLoanApplication_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        If State = Nothing Then
            State = ADD_STATE
            Initialize_Form()
            tbrMainForm.Buttons.Item(2).Visible = False
        Else
            Initialize_Form()
        End If
        If State = ADD_STATE Then
            If gRoleID = 1 Then
                txtMember.Text = clsLoanApplication.GetMemberName(gUserID)
                ValidateMember(CStr(txtMember.Text))
                txtMember.Enabled = False
            Else
                txtMember.Enabled = True
            End If
        End If
        
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsLoanApplication.Init_Flag = RecordId
            clsLoanApplication.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmLoanApplication_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.FormClosing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                'txtMemberNo.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmLoanApplication_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmLoanApplication_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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

#Region "frmLoanApplication ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmLoanApplication As New frmLoanApplication
                    frmTitle = "Loan Application"
                    If blnUseFinder Then
                        State = ADD_STATE
                        RecordId = 0
                        clsCommon.ClearControls(ColLoanApplication)
                        Set_Form_State()
                        Set_Default_Values()
                        Initialize_AutoComplete()
                        Initialize_Status()
                        dgvSignatory.Columns(2).ReadOnly = False
                        dgvSignatory.Columns(3).ReadOnly = False
                        Me.Text = "Loan Application"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmLoanApplication = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmLoanApplication.Activate()
                        Else
                            State = ADD_STATE
                            RecordId = 0
                            clsCommon.ClearControls(ColLoanApplication)
                            Set_Form_State()
                            Set_Default_Values()
                            Initialize_AutoComplete()
                            Initialize_Status()
                            dgvSignatory.Columns(2).ReadOnly = False
                            dgvSignatory.Columns(3).ReadOnly = False
                            Me.Text = "Loan Application"
                        End If
                    End If
                Case 1 'edit
edit_rec:
                    If Not cboLoanStatus.Text = "FOR APPROVAL" Then
                        clsCommon.Prompt_User("information", "You can no longer edit the current loan application." & vbCrLf & "The record status has already been set as '" & UCase(cboLoanStatus.Text) & "'.")
                        Exit Sub
                    Else
                        frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
                        With frmLoginOverrideForm
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                State = EDIT_STATE
                                Set_Form_State()
                                dgvSignatory.Columns(2).ReadOnly = False
                                dgvSignatory.Columns(3).ReadOnly = False
                            End If
                        End With
                    End If
                Case 2 'delete
delete_rec:
                    If Not cboLoanStatus.Text = "FOR APPROVAL" Then
                        clsCommon.Prompt_User("information", "You can no longer cancel the current loan application." & vbCrLf & "The record status has already been set as '" & UCase(cboLoanStatus.Text) & "'.")
                        Exit Sub
                    Else
                        frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
                        With frmLoginOverrideForm
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                Dim iAns
                                iAns = clsCommon.Prompt_User("question", "Are you sure you want to cancel this loan application?")
                                If iAns = vbYes Then
                                    With clsLoanApplication
                                        ._loanId = RecordId
                                        ._updatedBy = gUserID
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
                        Dim frmFinder As frmLoanApplicationFinder
                        frmTitle = "Member Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtMemberName.Focus()
                        Else
                            frmFinder = New frmLoanApplicationFinder
                            With frmFinder
                                .Loan_Id = 0
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
                        With clsLoanApplication
                            ._loanId = RecordId
                            ._loanNo = IIf((Len(txtRefLoanAppNo.Text.Replace(",", "")) = 0), 0, Val(txtRefLoanAppNo.Text.Replace(",", "")))
                            ._memberId = IIf((Len(txtMemberId.Text.Replace(",", "")) = 0), 0, Val(txtMemberId.Text.Replace(",", "")))
                            ._capitalAmount = IIf((Len(txtCapitalAmount.Text.Replace(",", "")) = 0), 0, Val(txtCapitalAmount.Text.Replace(",", "")))
                            ._loanRemarks = Trim(txtLoanRemarks.Text)
                            ._loanStatus = Trim(cboLoanStatus.Text)
                            ._voucherNo = Trim(txtVoucherNo.Text)
                            ._checkNo = Trim(txtCheckNo.Text)
                            ._tempLoanDt = dtpLoanDt.Value
                            ._loanTypeId = Trim(cboLoanTypeId.Text)
                            ._principalAmount = IIf((Len(txtPrincipalAmount.Text.Replace(",", "")) = 0), 0, Val(txtPrincipalAmount.Text.Replace(",", "")))
                            ._valueFl = IIf(dtpValueDate.Checked, 1, 0)
                            ._tempValueDt = dtpValueDate.Value
                            ._loanTerm = Trim(nudTerm.Value)
                            ._interestRate = IIf((Len(txtInterestRate.Text.Replace(",", "")) = 0), 0, Val(txtInterestRate.Text.Replace(",", "")))
                            ._monthlyPayment = IIf((Len(txtMonthlyPayment.Text.Replace(",", "")) = 0), 0, Val(txtMonthlyPayment.Text.Replace(",", "")))
                            ._loanInterest = 0 'IIf((Len(txtLoanInterest.Text.ToString.Replace(",", "")) = 0), 0, Val(txtLoanInterest.Text.ToString.Replace(",", "")))
                            ._rebates = 0 'IIf((Len(txtRebates.Text.ToString.Replace(",", "")) = 0), 0, Val(txtRebates.Text.ToString.Replace(",", "")))
                            ._totalLoanInterest = 0 'IIf((Len(txtTotalLoanInterest.Text.ToString.Replace(",", "")) = 0), 0, Val(txtTotalLoanInterest.Text.ToString.Replace(",", "")))
                            ._loanBalance = 0 'IIf((Len(txtLoanBalance.Text.ToString.Replace(",", "")) = 0), 0, Val(txtLoanBalance.Text.ToString.Replace(",", "")))
                            ._serviceFee = 0 'IIf((Len(txtServiceFee.Text.ToString.Replace(",", "")) = 0), 0, Val(txtServiceFee.Text.ToString.Replace(",", "")))
                            ._cisp = 0 'IIf((Len(txtCISP.Text.ToString.Replace(",", "")) = 0), 0, Val(txtCISP.Text.ToString.Replace(",", "")))
                            ._cispUnused = 0 'IIf((Len(txtCISPUnused.Text.ToString.Replace(",", "")) = 0), 0, Val(txtCISPUnused.Text.ToString.Replace(",", "")))
                            ._totalCISP = 0 'IIf((Len(txtTotalCISP.Text.ToString.Replace(",", "")) = 0), 0, Val(txtTotalCISP.Text.ToString.Replace(",", "")))
                            ._totalDeductions = IIf((Len(txtTotalDeductions.Text.Replace(",", "")) = 0), 0, Val(txtTotalDeductions.Text.Replace(",", "")))
                            ._netProceeds = IIf((Len(txtNetProceeds.Text.Replace(",", "")) = 0), 0, Val(txtNetProceeds.Text.Replace(",", "")))
                            ._maturityDt = Trim(txtSMaturityDate.Text)
                            ._signedFl = IIf(dtpDateSigned.Checked, 1, 0)
                            ._tempSignedDt = dtpDateSigned.Value
                            ._cancelFl = chkCancelFl.CheckState
                            ._closedFl = chkClosedFl.CheckState
                            ._updatedDt = txtUpdateDt.Text
                            ._updatedBy = gUserID

                            Populate_Collection()

                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = ._loanId
                                .Init_Flag = RecordId
                                .Selected_Record()
                                lblLoanApplicationNo.Text = "Loan Application No: " & ._loanNo
                                txtRefLoanAppNo.Text = ._loanNo
                                txtUpdateDt.Text = ._updatedDt
                                Set_Form_State()
                                Me.Text = "Member - " & txtMember.Text & " - [" & txtDepartment.Text & "]"

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''
                                'THIS IS TO SAVE TH'E NOTIFICATIONS
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim mysql As New PowerNET8.mySQL.Init.SQL
                                Connect(mysql)
                                Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_notification where loanID=" + RecordId.ToString + " and typeNotification='LOAN APPLIED' ")
                                If mydata.Rows.Count = 0 Then
                                    With mysql
                                        .setTable("tbl_notification")
                                        .addValue(.nextID("NID"), "NID")
                                        .addValue(RecordId, "loanID")
                                        .addValue("LOAN APPLIED", "typeNotification")
                                        .addValue("Application Created!", "notHeader")
                                        .addValue(txtMember.Text + " - loan application successfully created and is subject for approval.", "Nofications")
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
                                ''''''''''''''''''''''''''''''''''''''''''''''''''
                                ''''''''''''''''''''''''''''''''''''''''''''''''''


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
                        Me.txtMember.Focus()
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

#Region "frmLoanApplication Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Default_Values()
        Set_Max_Length()
        If State = ADD_STATE Then
            lblStatus.Text = "NEW"
            cboLoanStatus.SelectedIndex = 2
        End If
        Me.Text = "Loan Application"
        txtMember.Focus()
        loan_balance_process = False
        loan_fee_process = False
        btnDefault.Enabled = False
    End Sub

    Private Sub Initialize_AutoComplete()
        'member list
        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
        Dim autoSourceCollection As New AutoCompleteStringCollection()
        Dim drow As DataRow

        With txtMember
            dtMember = clsDA.ExecuteQuery("SELECT memberId, CONCAT(lastName, IF(LENGTH(suffixName),' ',''),suffixName,', ',firstName, ' ',middleName) 'Name' FROM tblmember WHERE activeFl = 1 AND cancelFl = 0 AND memberFl = 1 AND retireFl = 0;", True, RETURN_TYPE_DATATABLE)
            .AutoCompleteSource = AutoCompleteSource.None

            For Each drow In dtMember.Rows
                autoSourceCollection.Add(drow.Item("Name"))
            Next

            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteCustomSource = autoSourceCollection
            .AutoCompleteSource = AutoCompleteSource.CustomSource
            Dim dataCombo As DataSet

            dataCombo = clsLoanApplication.GetLoanTypeList
            clsCommon.PopulateComboBox(cboLoanTypeId, cboLoanType, dataCombo)
        End With
    End Sub

    Private Sub Set_Default_Values()
        Try

            Initialize_AutoComplete()
            'GENERAL INFORMATION
            txtMember.Text = ""
            txtDepartment.Text = ""
            txtLoanRemarks.Text = ""

            dtpLoanDt.Value = Date.Now
            dtpLoanDt.Checked = False
            cboLoanStatus.Text = "FOR APPROVAL"

            txtCapitalAmount.Text = "0.00"

            txtRefLoanAppNo.Text = ""
            txtVoucherNo.Text = ""
            txtCheckNo.Text = ""

            chkCancelFl.Checked = False
            chkClosedFl.Checked = False

            cboLoanType.Text = ""
            dtpValueDate.Value = Date.Now
            dtpValueDate.Checked = False
            txtPrincipalAmount.Text = "0.00"
            nudTerm.Value = 1
            txtInterestRate.Text = 0
            txtMonthlyPayment.Text = "0.00"

            'txtLoanInterest.Text = "0.00"
            'txtRebates.Text = "0.00"
            'txtTotalLoanInterest.Text = "0.00"
            'txtLoanBalance.Text = "0.00"
            'txtCISP.Text = "0.00"
            'txtCISPUnused.Text = "0.00"
            'txtTotalCISP.Text = "0.00"
            'txtServiceFee.Text = "0.00"

            txtTotalDeductions.Text = "0.00"
            txtNetProceeds.Text = "0.00"

            'PROMISSORY NOTES / AUTHORIZATION
            txtPromName.Text = ""
            txtPromSumWord.Text = ""
            txtPromSumAmt.Text = ""
            txtPromMonthlyWord.Text = ""
            txtPromMonthlyAmt.Text = ""
            mtbPromFromDate.Text = ""
            mtbPromToDate.Text = ""
            lblAuthorization.Text = "       In the fulfillment and performance of my obligation, I authorized the City Treasurer or " & _
            "Disbursing Officer of Malaybalay City Government to set off, collect, withheld an amount equivalent to the outstanding " & _
            "obligation/s inclusive of interest due from my monies or pecuniary benefits in the form of bonuses, gratuity pay, " & _
            "benefits, etc. due me and remit the same to the CITY GOVERNMENT OF MALAYBALAY EMPLOYEES ASSOCIATION. "

            'SIGNATORIES
            dtpDateSigned.Value = Date.Now
            dtpDateSigned.Checked = False
            txtApprovedBy.Text = ""
            txtReleasedBy.Text = ""
            With clsLoanApplication
                dgvSignatory.Rows.Clear()
                dtDataGridView = .GetDefaultChoices("accountability")
                If Not dtDataGridView Is Nothing Then
                    For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                        With dgvSignatory
                            Dim rowndx As Integer
                            rowndx = .Rows.Add()
                            dgvSignatory.Item(0, rowndx).Value = dtDataGridViewRow("paramVal")
                            dgvSignatory.Item(1, rowndx).Value = ""
                            dgvSignatory.Item(2, rowndx).Value = ""
                            dgvSignatory.Item(3, rowndx).Value = ""
                            dgvSignatory.Item(4, rowndx).Value = 0
                        End With
                    Next
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(txtMember)
            .Add(txtLoanRemarks)
            .Add(dtpLoanDt)
            .Add(cboLoanType)
            .Add(txtPrincipalAmount)
            .Add(dtpValueDate)
            .Add(nudTerm)
            .Add(dtpDateSigned)
            .Add(txtUpdateDt)
        End With
    End Sub

    Private Sub Initialize_Status()
        If RecordId = 0 And chkCancelFl.CheckState = 0 And chkClosedFl.CheckState = 0 Then
            lblStatus.Text = "FOR APPROVAL"
            lblStatus.ForeColor = Black
        ElseIf RecordId <> 0 And chkCancelFl.CheckState = 0 And chkClosedFl.CheckState = 0 And lblStatus.Text <> "FOR APPROVAL" Then
            lblStatus.ForeColor = Green
        ElseIf RecordId <> 0 And chkCancelFl.CheckState = 1 And chkClosedFl.CheckState = 0 Then
            lblStatus.Text = "CANCELLED"
            lblStatus.ForeColor = Red
        ElseIf RecordId <> 0 And chkCancelFl.CheckState = 0 And chkClosedFl.CheckState = 1 Then
            lblStatus.Text = "CLOSED"
            lblStatus.ForeColor = Gray
        End If
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColLoanApplication
            'Member Information
            .Add(txtMember)
            .Add(txtMemberId)
            .Add(txtLoanRemarks)

            .Add(dtpLoanDt)
            .Add(cboLoanStatus)
            .Add(txtCapitalAmount)
            .Add(txtRefLoanAppNo)

            .Add(cboLoanTypeId)
            .Add(cboLoanType)
            .Add(dtpValueDate)
            .Add(txtPrincipalAmount)
            .Add(nudTerm)
            .Add(txtInterestRate)
            .Add(txtMonthlyPayment)
            '.Add(txtLoanInterest)
            '.Add(txtRebates)
            '.Add(txtTotalLoanInterest)
            '.Add(txtLoanBalance)
            '.Add(txtCISP)
            '.Add(txtCISPUnused)
            '.Add(txtTotalCISP)
            '.Add(txtServiceFee)
            .Add(txtTotalDeductions)
            .Add(txtNetProceeds)

            .Add(dgvBalanceRecord)
            .Add(dtpDateSigned)
            .Add(dgvSignatory)
            .Add(dgvLoanSchedule)
            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColLoanApplication)
        Define_Required_Fields()
        Me.Text = "Loan Application"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblApplicant)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtMember)
            .Add(cboLoanStatus)
            .Add(cboLoanType)
            .Add(txtPrincipalAmount)

            .Add(dgvBalanceRecord)
            .Add(dgvSignatory)
            .Add(dgvLoanSchedule)
        End With

    End Sub

    Private Sub Assign_Data()

        Dim dtable As New DataTable
        With clsLoanApplication
            'GENERAL INFORMATION
            lblLoanApplicationNo.Text = "Loan Application No: " & ._loanNo
            txtRefLoanAppId.Text = ._loanId
            txtRefLoanAppNo.Text = ._loanNo

            txtMemberId.Text = ._memberId
            clsMember = clsPersonnel.NewclsMember
            txtDepartment.Text = ._departmentName
            txtMember.Text = ._memberName
            txtPromName.Text = ._memberName
            txtCapitalAmount.Text = Format(._capitalAmount, "Standard")

            txtLoanRemarks.Text = ._loanRemarks
            cboLoanStatus.Text = ._loanStatus
            lblStatus.Text = ._loanStatus
            txtRefLoanAppId.Text = ._loanId
            txtRefLoanAppNo.Text = ._loanNo
            txtVoucherNo.Text = ._voucherNo
            txtCheckNo.Text = ._checkNo
            dtpLoanDt.Value = ._loanDt

            cboLoanTypeId.Text = ._loanTypeId
            'With clsLoanType
            '    .Init_Flag = 2
            '    .Type_Id = CInt(cboLoanTypeId.Text)
            '    dtable = .Search_Record()
            '    Dim myRow As DataRow
            '    For Each myRow In dtable.Rows
            '        nudTerm.Minimum = Trim(myRow("terms_min").ToString)
            '        nudTerm.Maximum = Trim(myRow("terms_max").ToString)
            '        nudTerm.Value = Trim(myRow("terms_max").ToString)
            '        txtInterestRate.Text = Trim(myRow("interestRate").ToString)
            '        minAmount = Trim(myRow("amount_min").ToString)
            '        maxAmount = Trim(myRow("amount_max").ToString)
            '        'txtPrincipalAmount.Text = minAmount
            '    Next
            'End With

            With clsLoanType
                .Init_Flag = 2
                .Type_Id = CInt(cboLoanTypeId.Text)
                dtable = .Search_Loan_Type_Record()
                Dim myRow As DataRow
                For Each myRow In dtable.Rows
                    nudTerm.Minimum = Trim(myRow("terms_min").ToString)
                    nudTerm.Maximum = Trim(myRow("terms_max").ToString)
                    nudTerm.Value = Trim(myRow("terms_min").ToString)
                    txtInterestRate.Text = Trim(myRow("interestRate").ToString)
                    intTerm = Trim(myRow("interestTerm").ToString)
                    minAmount = CDbl(myRow("amount_min").ToString)
                    If CInt(cboLoanTypeId.Text) = 6 Then
                        maxAmount = CDbl(txtSalary.Text) + 5000
                    ElseIf CInt(cboLoanTypeId.Text) = 7 Then
                        maxAmount = CDbl(txtSalary.Text)
                    Else
                        maxAmount = CDbl(myRow("amount_max").ToString)
                    End If
                    'txtPrincipalAmount.Text = Format(minAmount, "Standard")
                Next
            End With

            cboLoanType.Text = ._loanType
            txtPrincipalAmount.Text = Format(._principalAmount, "Standard")
            txtTotalLoansGranted.Text = Format(._principalAmount, "Standard")

            dtpValueDate.Checked = ._valueFl
            If ._valueFl = 1 Then
                dtpValueDate.Value = ._valueDt
            End If

            If ._loanTerm > nudTerm.Maximum Then
                nudTerm.Maximum = ._loanTerm
                nudTerm.Value = ._loanTerm
            Else
                nudTerm.Value = ._loanTerm
            End If

            txtInterestRate.Text = ._interestRate
            txtMonthlyPayment.Text = Format(._monthlyPayment, "Standard")

            'txtLoanInterest.Text = Format(._loanInterest, "Standard")
            'txtRebates.Text = Format(._rebates, "Standard")
            'txtTotalLoanInterest.Text = Format(._totalLoanInterest, "Standard")
            'txtLoanBalance.Text = Format(._loanBalance, "Standard")
            'txtServiceFee.Text = Format(._serviceFee, "Standard")
            'txtCISP.Text = Format(._cisp, "Standard")
            'txtCISPUnused.Text = Format(._cispUnused, "Standard")
            'txtTotalCISP.Text = Format(._totalCISP, "Standard")

            txtTotalDeductions.Text = Format(._totalDeductions, "Standard")
            txtNetProceeds.Text = Format(._netProceeds, "Standard")

            If Val(txtApprovedId.Text.Replace(",", "")) = -1 Then
                txtApprovedBy.Text = ""
            Else
                clsSignatory = clsUtility.NewclsSignatory
                With clsSignatory
                    .Init_Flag = IIf((Len(txtApprovedId.Text.Replace(",", "")) = 0), 0, Val(txtApprovedId.Text.Replace(",", "")))
                    .Selected_Record()
                    txtApprovedBy.Text = ._lname & IIf(Len(._suffix) > 0, " " & ._suffix, "") & ", " & ._fname & " " & ._mname
                End With
            End If
            If ._approvedFl = 1 Then
                dtpApprovedDt.Value = ._approvedDt
            End If

            If Val(txtReleasedId.Text.Replace(",", "")) = -1 Then
                txtReleasedBy.Text = ""
            Else
                clsSignatory = clsUtility.NewclsSignatory
                With clsSignatory
                    .Init_Flag = IIf((Len(txtReleasedId.Text.Replace(",", "")) = 0), 0, Val(txtReleasedId.Text.Replace(",", "")))
                    .Selected_Record()
                    txtReleasedBy.Text = ._lname & IIf(Len(._suffix) > 0, " " & ._suffix, "") & ", " & ._fname & " " & ._mname
                End With
            End If
            If ._releasedFl = 1 Then
                dtpReleasedDt.Value = ._releasedDt
            End If

            chkCancelFl.CheckState = ._cancelFl
            chkClosedFl.CheckState = ._closedFl

            Dim mDate As Date = ._maturityDt
            'PROMISSORY NOTE / AUTHORIZATION
            txtPromName.Text = ._memberName
            txtPromSumWord.Text = AmountInWords(Trim(txtPrincipalAmount.Text))
            txtPromSumAmt.Text = Format(txtPrincipalAmount.Text, "Standard")
            txtPromMonthlyWord.Text = AmountInWords(Trim(txtMonthlyPayment.Text))
            txtPromMonthlyAmt.Text = Format(txtMonthlyPayment.Text, "Standard")
            mtbPromFromDate.Text = dtpValueDate.Value.ToString("MM-dd-yyyy")
            mtbPromToDate.Text = mDate.ToString("MM-dd-yyyy")
            txtMaturityDt.Text = mDate.ToString("MM-dd-yyyy")

            txtSLoanType.Text = Trim(cboLoanType.Text)
            txtSLoanTypeId.Text = CInt(cboLoanTypeId.Text)
            txtSPrincipalAmount.Text = Format(CDbl(txtPrincipalAmount.Text), "Standard")
            txtSIssuedDate.Text = dtpValueDate.Value.ToString("yyyy-MM-dd")
            txtSMaturityDate.Text = mDate.ToString("yyyy-MM-dd")
            txtSTerm.Text = CInt(nudTerm.Value)
            txtSInterestRate.Text = CDbl(txtInterestRate.Text)

            'LOAN BALANCES
            dtDataGridView = .Populate_Loan_Application_Balance(CInt(txtMemberId.Text))
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    Dim rwcount As Integer
                    With dgvBalanceRecord
                        rwcount = .Rows.Add
                        If CDbl(dtDataGridViewRow("amountToPaid")) > 0 Then
                            .Item(0, rwcount).Value = 1
                        End If
                        .Item(1, rwcount).Value = dtDataGridViewRow("prevLoanId")
                        .Item(2, rwcount).Value = dtDataGridViewRow("prevLoanNo")
                        .Item(3, rwcount).Value = dtDataGridViewRow("loanType")
                        .Item(4, rwcount).Value = dtDataGridViewRow("totalBalance")
                        .Item(5, rwcount).Value = dtDataGridViewRow("amountToPaid")
                        .Item(6, rwcount).Value = dtDataGridViewRow("rebates")
                        .Item(7, rwcount).Value = dtDataGridViewRow("unused")
                        .Item(8, rwcount).Value = dtDataGridViewRow("loanTypeId")
                        .Rows(rwcount).DefaultCellStyle.BackColor = Highlight_Unchecked(.Item(0, rwcount).Value)
                    End With
                Next
            End If
            If dgvBalanceRecord.RowCount > 0 Then
                loan_balance_process = True
                Compute_Loan_Balance()
                btnDefault.Enabled = True
            End If

            'FEES
            dtDataGridView = .Populate_Loan_Application_Fee(RecordId, CInt(cboLoanTypeId.Text))
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    With dgvFees
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("typeId")
                        .Item(1, rowndx).Value = dtDataGridViewRow("typeName")
                        .Item(2, rowndx).Value = dtDataGridViewRow("feeAmount")
                    End With
                Next
            End If

            If dgvFees.RowCount > 0 Then
                loan_fee_process = True
                Compute_Loan_Fees()
            End If


            'SIGNATORIES
            dtpDateSigned.Value = ._signedDt
            dtDataGridView = .Populate_Loan_Application_Signatory(RecordId)
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    Dim GridRows As Integer = dgvSignatory.Rows.Count

                    Dim count As Integer = 1
                    If dgvSignatory.AllowUserToAddRows Then count = 2

                    For A As Integer = 0 To GridRows - count
                        With dgvSignatory
                            If LCase(Trim(.Item(0, A).Value.ToString)) = LCase(Trim(dtDataGridViewRow("signatoryType"))) Then
                                .Item(2, A).Value = dtDataGridViewRow("signatoryName")
                                .Item(3, A).Value = dtDataGridViewRow("signatoryPosition")
                                .Item(4, A).Value = dtDataGridViewRow("signedBy")
                            End If
                        End With
                    Next
                Next
            End If

            'SCHEDULE
            dtDataGridView = .Populate_Loan_Application_Schedule(RecordId)
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    Dim rwcount As Integer
                    With dgvLoanSchedule
                        rwcount = .Rows.Add
                        .Item(0, rwcount).Value = dtDataGridViewRow("scheduleId")
                        .Item(1, rwcount).Value = dtDataGridViewRow("scheduleDt")
                        .Item(2, rwcount).Value = dtDataGridViewRow("monthlyInterest")
                        .Item(3, rwcount).Value = dtDataGridViewRow("monthlyPrincipal")
                        .Item(4, rwcount).Value = dtDataGridViewRow("totalAmount")
                        .Item(5, rwcount).Value = dtDataGridViewRow("paidFl")
                    End With
                Next
            End If
            GenerateLoanSchedule()
        End With
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
        clsLoanApplication = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColLoanApplication = Nothing
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsLoanApplication.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtMember.Tag = "Name of Applicant"
        Me.cboLoanStatus.Tag = "Loan Status"
        Me.cboLoanType.Tag = "Loan Type"
        Me.txtPrincipalAmount.Tag = "Principal Amount"

        Me.dgvSignatory.Tag = "Signatories"
        Me.dgvLoanSchedule.Tag = "Loan Schedule"
    End Sub

    Public Sub Set_Form_State()

        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblApplicant.Text = "Name of Applicant"
            lblLoanStatus.Text = "Loan Status"
            lblLoanType.Text = "Loan Type"
            lblPrincipalAmount.Text = "Principal Amount"
            btnCalculation.Enabled = False
            btnDefault.Enabled = False
            dgvBalanceRecord.ReadOnly = True
            dgvFees.ReadOnly = True
        Else
            lblApplicant.Text = "Name of Applicant *"
            lblLoanStatus.Text = "Loan Status *"
            lblLoanType.Text = "Loan Type *"
            lblPrincipalAmount.Text = "Principal Amount *"
            btnCalculation.Enabled = True
            btnDefault.Enabled = True
            dgvBalanceRecord.ReadOnly = False
            dgvFees.ReadOnly = False
        End If
    End Sub

    Private Sub Set_Max_Length()
        Me.txtMember.MaxLength = 255
        Me.txtLoanRemarks.MaxLength = 1000
        Me.txtVoucherNo.MaxLength = 20
        Me.txtCheckNo.MaxLength = 15
        Me.txtPrincipalAmount.MaxLength = 20
    End Sub

    Private Sub ValidateMember(ByVal ColName As String)
        Try
            Dim mydata As New DataTable
            Dim mydataCon As New DataTable

            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblmember WHERE CONCAT(lastName, IF(LENGTH(suffixName),' ',''),suffixName,', ',firstName, ' ',middleName) = '" & txtMember.Text & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)

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
                        txtPromName.Text = txtMember.Text
                        txtCapitalAmount.Text = Format(clsLoanApplication.GetTotalMemberContribution(2, CInt(txtMemberId.Text)), "Standard")
                        txtSalary.Text = Format(.Salary_Amount, "Standard")
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

    Private Sub ValidateUserMember(ByVal ColName As String)
        Try
            Dim mydata As New DataTable
            Dim mydataCon As New DataTable

            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblmember WHERE memberId = '" & txtMemberId.Text & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)

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
                            Exit Sub
                        End If
                        txtPromName.Text = txtMember.Text
                        txtCapitalAmount.Text = Format(clsLoanApplication.GetTotalMemberContribution(2, CInt(txtMemberId.Text)), "Standard")
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

    Private Sub Populate_Collection()
        Try
            Dim GridRows As Integer

            'Loan Fees
            Dim LoanApplicationFeesItem As New Collection

            If Len(CStr(dgvFees.Item(0, dgvFees.Rows.Count - 1).Value)) = 0 Then
                GridRows = dgvFees.Rows.Count - 1
            Else
                GridRows = dgvFees.Rows.Count
            End If

            For A As Integer = 0 To GridRows - 1
                clsLoanApplicationDetails = New LoanApplicationDetails.LoanApplicationDetails
                If dgvFees.Item(2, A).Value <> 0 Then
                    With clsLoanApplicationDetails
                        ._feeId = AddSlashes(CStr(dgvFees.Item(0, A).Value))
                        ._feeAmount = AddSlashes(CStr(dgvFees.Item(2, A).Value))
                    End With
                    LoanApplicationFeesItem.Add(clsLoanApplicationDetails)
                End If
            Next

            'Loan Balance

            Dim LoanBalanceItem As New Collection
            If dgvBalanceRecord.Rows.Count > 0 Then
                If Len(CStr(dgvBalanceRecord.Item(0, dgvBalanceRecord.Rows.Count - 1).Value)) = 0 Then
                    GridRows = dgvBalanceRecord.Rows.Count - 1
                Else
                    GridRows = dgvBalanceRecord.Rows.Count
                End If

                For A As Integer = 0 To GridRows - 1
                    clsLoanApplicationDetails = New LoanApplicationDetails.LoanApplicationDetails
                    Dim aa As String = dgvBalanceRecord.Item(0, A).Value
                    If dgvBalanceRecord.Item(0, A).Value = 1 Then
                        With clsLoanApplicationDetails
                            ._loanId = AddSlashes(CStr(dgvBalanceRecord.Item(1, A).Value))
                            ._loanBalAmount = AddSlashes(CStr(dgvBalanceRecord.Item(5, A).Value))
                            ._loanRebates = AddSlashes(CStr(dgvBalanceRecord.Item(6, A).Value))
                            ._loanUnused = AddSlashes(CStr(dgvBalanceRecord.Item(7, A).Value))
                        End With
                        LoanBalanceItem.Add(clsLoanApplicationDetails)
                    End If
                Next
            End If

            'Loan Application Signatory
            Dim LoanApplicationSignatoryItem As New Collection

            If Len(CStr(dgvSignatory.Item(0, dgvSignatory.Rows.Count - 1).Value)) = 0 Then
                GridRows = dgvSignatory.Rows.Count - 1
            Else
                GridRows = dgvSignatory.Rows.Count
            End If

            For A As Integer = 0 To GridRows - 1
                clsLoanApplicationDetails = New LoanApplicationDetails.LoanApplicationDetails
                With clsLoanApplicationDetails
                    ._signatoryType = AddSlashes(CStr(dgvSignatory.Item(0, A).Value))
                    ._signatoryName = AddSlashes(CStr(dgvSignatory.Item(2, A).Value))
                    ._signatoryPosition = AddSlashes(CStr(dgvSignatory.Item(3, A).Value))
                    ._signedBy = AddSlashes(CInt(dgvSignatory.Item(4, A).Value))
                End With
                LoanApplicationSignatoryItem.Add(clsLoanApplicationDetails)
            Next

            'Loan Application Due
            Dim LoanApplicationScheduleItem As New Collection

            If Len(CStr(dgvLoanSchedule.Item(0, dgvLoanSchedule.Rows.Count - 1).Value)) = 0 Then
                GridRows = dgvLoanSchedule.Rows.Count - 1
            Else
                GridRows = dgvLoanSchedule.Rows.Count
            End If

            For A As Integer = 0 To GridRows - 1
                clsLoanApplicationDetails = New LoanApplicationDetails.LoanApplicationDetails
                With clsLoanApplicationDetails
                    ._scheduleDt = AddSlashes(CStr(dgvLoanSchedule.Item(1, A).Value))
                    ._monthlyInterest = AddSlashes(CStr(dgvLoanSchedule.Item(2, A).Value))
                    ._monthlyPrincipal = AddSlashes(CStr(dgvLoanSchedule.Item(3, A).Value))
                    ._totalAmount = AddSlashes(CStr(dgvLoanSchedule.Item(4, A).Value))
                End With
                LoanApplicationScheduleItem.Add(clsLoanApplicationDetails)
            Next

            With clsLoanApplication
                ._colLoanBalance = LoanBalanceItem
                ._colLoanApplicationFee = LoanApplicationFeesItem
                ._colLoanApplicationSignatory = LoanApplicationSignatoryItem
                ._colLoanApplicationSchedule = LoanApplicationScheduleItem

                LoanBalanceItem = Nothing
                LoanApplicationFeesItem = Nothing
                LoanApplicationSignatoryItem = Nothing
                LoanApplicationScheduleItem = Nothing
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Function AmountInWords(ByVal nAmount As String, Optional ByVal wAmount _
                 As String = vbNullString, Optional ByVal nSet As Object = Nothing) As String
        'Let's make sure entered value is numeric
        If Not IsNumeric(nAmount) Then Return "Please enter numeric values only."

        Dim tempDecValue As String = String.Empty : If InStr(nAmount, ".") Then _
            tempDecValue = nAmount.Substring(nAmount.IndexOf("."))
        nAmount = Replace(nAmount, tempDecValue, String.Empty)

        Try
            Dim intAmount As Long = nAmount
            If intAmount > 0 Then
                nSet = IIf((intAmount.ToString.Trim.Length / 3) _
                 > (CLng(intAmount.ToString.Trim.Length / 3)), _
                  CLng(intAmount.ToString.Trim.Length / 3) + 1, _
                   CLng(intAmount.ToString.Trim.Length / 3))
                Dim eAmount As Long = Microsoft.VisualBasic.Left(intAmount.ToString.Trim, _
                  (intAmount.ToString.Trim.Length - ((nSet - 1) * 3)))
                Dim multiplier As Long = 10 ^ (((nSet - 1) * 3))

                Dim Ones() As String = _
                {"", "One", "Two", "Three", _
                  "Four", "Five", _
                  "Six", "Seven", "Eight", "Nine"}
                Dim Teens() As String = {"", _
                "Eleven", "Twelve", "Thirteen", _
                  "Fourteen", "Fifteen", _
                  "Sixteen", "Seventeen", "Eighteen", "Nineteen"}
                Dim Tens() As String = {"", "Ten", _
                "Twenty", "Thirty", _
                  "Forty", "Fifty", "Sixty", _
                  "Seventy", "Eighty", "Ninety"}
                Dim HMBT() As String = {"", "", _
                "Thousand", "Million", _
                  "Billion", "Trillion", _
                  "Quadrillion", "Quintillion"}

                intAmount = eAmount

                Dim nHundred As Integer = intAmount \ 100 : intAmount = intAmount Mod 100
                Dim nTen As Integer = intAmount \ 10 : intAmount = intAmount Mod 10
                Dim nOne As Integer = intAmount \ 1

                If nHundred > 0 Then wAmount = wAmount & _
                Ones(nHundred) & " Hundred " 'This is for hundreds                
                If nTen > 0 Then 'This is for tens and teens
                    If nTen = 1 And nOne > 0 Then 'This is for teens 
                        wAmount = wAmount & Teens(nOne) & " "
                    Else 'This is for tens, 10 to 90
                        wAmount = wAmount & Tens(nTen) & IIf(nOne > 0, "-", " ")
                        If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                    End If
                Else 'This is for ones, 1 to 9
                    If nOne > 0 Then wAmount = wAmount & Ones(nOne) & " "
                End If
                wAmount = wAmount & HMBT(nSet) & " "
                wAmount = AmountInWords(CStr(CLng(nAmount) - _
                  (eAmount * multiplier)).Trim & tempDecValue, wAmount, nSet - 1)
            Else
                If Val(nAmount) = 0 Then nAmount = nAmount & _
                tempDecValue : tempDecValue = String.Empty
                If (Math.Round(Val(nAmount), 2) * 100) > 0 Then wAmount = _
                  Trim(AmountInWords(CStr(Math.Round(Val(nAmount), 2) * 100), _
                  wAmount.Trim & " Pesos And ", 1)) & " Cents"
            End If
        Catch ex As Exception
            MessageBox.Show("Error Encountered: " & ex.Message, _
              "Convert Numbers To Words", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return "!#ERROR_ENCOUNTERED"
        End Try

        'Trap null values
        If IsNothing(wAmount) = True Then wAmount = String.Empty Else wAmount = _
          IIf(InStr(wAmount.Trim.ToLower, "pesos"), _
          wAmount.Trim, wAmount.Trim & " Pesos")

        'Display the result
        Return wAmount
    End Function

    Private Function Validate_Net_Proceeds(ByVal vAmount As Double) As Boolean
        If vAmount < 0 Then
            MsgBox("Less than zero value for net proceed amount is not allowed.", MsgBoxStyle.Exclamation)
            Set_Default_Values_Calculation()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Set_Default_Values_Calculation()
        txtInterestRate.Text = 0
        txtMonthlyPayment.Text = "0.00"
        txtMaturityDt.Text = ""

        txtTotalLoansGranted.Text = "0.00"
        txtMonthlyPayment.Text = "0.00"

        'txtLoanInterest.Text = "0.00"
        'txtRebates.Text = "0.00"
        'txtTotalLoanInterest.Text = "0.00"
        'txtLoanBalance.Text = "0.00"
        'txtCISP.Text = "0.00"
        'txtCISPUnused.Text = "0.00"
        'txtTotalCISP.Text = "0.00"
        'txtServiceFee.Text = "0.00"

        txtTotalDeductions.Text = "0.00"
        txtNetProceeds.Text = "0.00"
        txtTotalFees.Text = "0.00"

        txtPromSumWord.Text = ""
        txtPromSumAmt.Text = ""
        txtPromMonthlyWord.Text = ""
        txtPromMonthlyAmt.Text = ""
        mtbPromFromDate.Text = Nothing
        mtbPromToDate.Text = Nothing
        dgvLoanSchedule.Rows.Clear()
        dgvBalanceRecord.Rows.Clear()
        dgvFees.Rows.Clear()

        loan_balance_process = False
        loan_fee_process = False
        btnDefault.Enabled = False
    End Sub

    'Loan Balance

    Private Sub Load_Loan_Balance_Record()
        If Trim(txtMemberId.Text) = "" Then
            clsCommon.Prompt_User("error", "Please provide applicant's name for current loan application record.")
            Exit Sub
        End If
        If Trim(cboLoanTypeId.Text) = "" Then
            clsCommon.Prompt_User("error", "Please provide loan type for current loan application record.")
            Exit Sub
        End If
        loan_balance_process = False
        dgvBalanceRecord.Rows.Clear()
        Try
            Dim rcount As Integer = 0
            If loan_balance_process = False Then
                With clsLoanApplication
                    dtDataGridView = .Populate_Loan_Balance_Record(CInt(txtMemberId.Text))
                    If Not dtDataGridView Is Nothing Then
                        For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                            With dgvBalanceRecord
                                Dim rowndx As Integer
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = 0
                                .Item(1, rowndx).Value = dtDataGridViewRow("loanId")
                                .Item(2, rowndx).Value = dtDataGridViewRow("loanNo")
                                .Item(3, rowndx).Value = dtDataGridViewRow("loanType")
                                .Item(4, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                .Item(5, rowndx).Value = "0.00"
                                If CInt(dtDataGridViewRow("loanTypeId")) = CInt(cboLoanTypeId.Text) Then
                                    .Rows(rowndx).ReadOnly = True
                                    .Item(0, rowndx).Value = 1
                                    .Item(5, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                    .Item(6, rowndx).Value = Format(clsLoanApplication.GetPrevRebates(CInt(dtDataGridViewRow("loanId")), CInt(dtDataGridViewRow("loanTypeId")), CInt(txtMemberId.Text)), "Standard")
                                    .Item(7, rowndx).Value = Format(clsLoanApplication.GetPrevCISPUnused(CInt(dtDataGridViewRow("loanId")), CInt(dtDataGridViewRow("loanTypeId")), CInt(txtMemberId.Text)), "Standard")
                                End If
                                .Rows(rowndx).DefaultCellStyle.BackColor = Highlight_Unchecked(.Item(0, rowndx).Value)
                                .Item(5, rowndx).ReadOnly = True
                                .Item(8, rowndx).Value = dtDataGridViewRow("loanTypeId")
                                .Columns(8).Visible = False
                            End With
                        Next
                    End If
                End With
            End If

            If dgvBalanceRecord.Rows.Count > 0 Then
                loan_balance_process = True
                Compute_Loan_Balance()
                btnDefault.Enabled = True
                
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Load_Fee_Record()
        If Trim(txtMemberId.Text) = "" Then
            clsCommon.Prompt_User("error", "Please provide applicant's name for current loan application record.")
            Exit Sub
        End If
        If Trim(cboLoanTypeId.Text) = "" Then
            clsCommon.Prompt_User("error", "Please provide loan type for current loan application record.")
            Exit Sub
        End If
        loan_fee_process = False
        dgvFees.Rows.Clear()
        Try
            Dim rcount As Integer = 0
            If loan_fee_process = False Then
                With clsLoanApplication
                    dtDataGridView = .Populate_Loan_Fee_Record(CInt(cboLoanTypeId.Text), CInt(nudTerm.Text), CInt(intTerm), CDbl(txtPrincipalAmount.Text))
                    If Not dtDataGridView Is Nothing Then
                        For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                            With dgvFees
                                Dim rowndx As Integer
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = dtDataGridViewRow("typeId")
                                .Item(1, rowndx).Value = dtDataGridViewRow("typeName")
                                .Item(2, rowndx).Value = dtDataGridViewRow("feeDefault")
                                Dim totalRebates As Double = 0
                                Dim totalUnused As Double = 0
                                If dgvBalanceRecord.RowCount > 0 Then
                                    For a As Integer = 0 To dgvBalanceRecord.RowCount - 1
                                        If CInt(dgvBalanceRecord.Rows(a).Cells(0).Value) = 1 Then
                                            totalRebates = totalRebates + CDbl(dgvBalanceRecord.Rows(a).Cells(6).Value)
                                            totalUnused = totalUnused + CDbl(dgvBalanceRecord.Rows(a).Cells(7).Value)
                                        End If
                                    Next
                                End If
                                If .Item(0, rowndx).Value = 10 Then
                                    .Item(2, rowndx).Value = Format(-totalRebates, "#,##0.00")
                                ElseIf .Item(0, rowndx).Value = 11 Then
                                    .Item(2, rowndx).Value = Format(-totalUnused, "#,##0.00")
                                End If
                                If .Item(0, rowndx).Value <> 6 Or .Item(0, rowndx).Value <> 9 Then
                                    .Item(0, rowndx).ReadOnly = False
                                Else
                                    .Item(0, rowndx).ReadOnly = True
                                End If
                            End With
                        Next
                    End If
                End With
            End If

            If dgvFees.Rows.Count > 0 Then
                loan_fee_process = True
                Compute_Loan_Fees()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Compute_Loan_Balance()
        Dim totalBalance As Double = 0
        Dim totalRebates As Double = 0
        Dim totalUnused As Double = 0
        If dgvBalanceRecord.RowCount > 0 Then
            For a As Integer = 0 To dgvBalanceRecord.RowCount - 1
                If CInt(dgvBalanceRecord.Rows(a).Cells(0).Value) = 1 Then
                    totalBalance = totalBalance + CDbl(dgvBalanceRecord.Rows(a).Cells(5).Value)
                    totalRebates = totalRebates - CDbl(dgvBalanceRecord.Rows(a).Cells(6).Value)
                    totalUnused = totalUnused - CDbl(dgvBalanceRecord.Rows(a).Cells(7).Value)
                End If
            Next
        End If
        txtTotalBal.Text = "0.00"
        'txtLoanBalance.Text = "0.00"
        txtTotalBal.Text = Format(TotalBalance, "#,##0.00")
        'txtLoanBalance.Text = Format(totalBalance, "#,##0.00")

        'txtRebates.Text = Format(totalRebates, "#,##0.00")
        'txtCISPUnused.Text = Format(totalUnused, "#,##0.00")

        With dgvFees
            If .RowCount > 0 Then
                For a1 As Integer = 0 To .RowCount - 1
                    If CInt(.Rows(a1).Cells(0).Value) = 10 Then
                        .Rows(a1).Cells(2).Value = Format(totalRebates, "#,##0.00")
                    ElseIf CInt(.Rows(a1).Cells(0).Value) = 11 Then
                        .Rows(a1).Cells(2).Value = Format(totalUnused, "#,##0.00")
                    End If
                Next
            End If
        End With
       
    End Sub

    Private Sub Compute_Loan_Fees()
        Dim totalFees As Double = 0
        If dgvFees.RowCount > 0 Then
            For a As Integer = 0 To dgvFees.RowCount - 1
                If IsNumeric(dgvFees.Rows(a).Cells(2).Value) Then
                    totalFees = totalFees + CDbl(dgvFees.Rows(a).Cells(2).Value)
                End If
            Next
        End If
        txtTotalFees.Text = Format(totalFees, "#,##0.00")
    End Sub

    Private Sub objPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46, 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub GenerateSchedule()
        Dim periodicInt As Double = 0
        Dim monthlyPrincipal As Double = 0
        Dim dtDate As Date
        Dim total As Double

        monthlyPrincipal = CInt(txtPrincipalAmount.Text) / CInt(nudTerm.Value)
        dgvLoanSchedule.Rows.Clear()

        For i As Integer = 1 To CInt(nudTerm.Value)
            dtDate = valueDt.AddMonths(i)
            total = monthlyPrincipal
            Me.dgvLoanSchedule.Rows.Add(i, Format(dtDate, "yyyy-MM-dd"), "0.00", Format(monthlyPrincipal, "Standard"), Format(total, "Standard"))
        Next
    End Sub

    Private Sub GenerateLoanSchedule()
        Try
            If Year(dtpValueDate.Value) > 2015 Then

                If dgvLoanSchedule.RowCount = 0 Then
                    Dim RemMonths As Integer = 0
                    Dim lastDt As Date = "2015-10-01"
                    Dim Maturity As Date = Trim(txtSMaturityDate.Text)
                    RemMonths = DateDiff(DateInterval.Month, lastDt, Maturity)

                    For a As Integer = 0 To RemMonths - 1
                        Dim rwcount As Integer
                        With dgvLoanSchedule
                            rwcount = .Rows.Add
                            .Item(0, rwcount).Value = ""
                            .Item(1, rwcount).Value = lastDt.AddMonths(a + 1).ToString("yyyy-MM-dd")
                            .Item(2, rwcount).Value = "0.00"
                            .Item(3, rwcount).Value = CDbl(txtMonthlyPayment.Text)
                            .Item(4, rwcount).Value = CDbl(txtMonthlyPayment.Text)
                        End With
                    Next
                End If
            Else
                If dgvLoanSchedule.RowCount = 0 Then
                    Dim termInMns As Integer = 0
                    Dim RemMonths As Integer = 0
                    Dim lastDt As Date = "2015-10-01"
                    Dim ValDt As Date = dtpValueDate.Value
                    Dim MatDt As Date = Trim(txtSMaturityDate.Text)
                    termInMns = DateDiff(DateInterval.Month, ValDt, MatDt)
                    RemMonths = DateDiff(DateInterval.Month, lastDt, MatDt)

                    For a As Integer = 0 To termInMns - 1
                        Dim rwcount As Integer
                        With dgvLoanSchedule
                            rwcount = .Rows.Add
                            .Item(0, rwcount).Value = ""
                            .Item(1, rwcount).Value = ValDt.AddMonths(-a).ToString("yyyy-MM-dd")
                            .Item(2, rwcount).Value = "0.00"
                            .Item(3, rwcount).Value = CDbl(txtMonthlyPayment.Text)
                            .Item(4, rwcount).Value = CDbl(txtMonthlyPayment.Text)
                            '.Item(5, rwcount).Value = False
                            'If a >= RemMonths Then
                            '    .Item(5, rwcount).Value = True
                            'End If
                        End With
                    Next
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Compute_Total_Net_Proceeds()
        txtTotalDeductions.Text = "0.00"
        txtNetProceeds.Text = "0.00"

        'txtTotalDeductions.Text = Format(CDbl(txtTotalLoanInterest.Text) + CDbl(txtLoanBalance.Text) + CDbl(txtTotalCISP.Text) + CDbl(txtServiceFee.Text), "Standard")
        'txtNetProceeds.Text = Format(CDbl(txtPrincipalAmount.Text) - CDbl(txtTotalDeductions.Text), "Standard")
        txtTotalDeductions.Text = Format(CDbl(txtTotalBal.Text) + CDbl(txtTotalFees.Text), "Standard")
        txtNetProceeds.Text = Format(CDbl(txtPrincipalAmount.Text) - CDbl(txtTotalDeductions.Text), "Standard")
    End Sub

    Private Function Highlight_Unchecked(ByVal chkval As Integer) As System.Drawing.Color
        If chkval = 0 Then
            Return Pink
        ElseIf chkval = 1 Then
            Return White
        End If
    End Function

#End Region

#Region "frmLoanApplication Defined Form events"

    Private Sub txtMember_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMember.LostFocus
        ValidateMember(CStr(txtMember.Text))
    End Sub

    Private Sub cboLoanStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoanStatus.SelectedIndexChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        lblStatus.Text = cboLoanStatus.Text
    End Sub

    Private Sub frmUseSignatoryFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String) Handles frmUseSignatoryFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If
        clsSignatory = clsUtility.NewclsSignatory
        With clsSignatory
            .Init_Flag = Record_Id
            .Selected_Record()
            dgvSignatory.Item(2, CurRow.Index).Value = ._fname & IIf(Len(._mname) > 0, " " & ._mname, "") & IIf(Len(._lname) > 0, " " & ._lname, "") & IIf(Len(._suffix) > 0, " " & ._suffix, "")
            dgvSignatory.Item(3, CurRow.Index).Value = ._designation
            dgvSignatory.Item(4, CurRow.Index).Value = ._memberId
        End With
        CurRow = Nothing
    End Sub

    Private Sub frmUseMemberSignatoryFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String) Handles frmUseMemberSignatoryFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If
        clsMemberSignatory = clsUtility.NewclsMemberSignatory
        With clsMemberSignatory
            .Init_Flag = Record_Id
            .Selected_Record()
            dgvSignatory.Item(2, CurRow.Index).Value = ._fname & IIf(Len(._mname) > 0, " " & ._mname, "") & IIf(Len(._lname) > 0, " " & ._lname, "") & IIf(Len(._suffix) > 0, " " & ._suffix, "")
            dgvSignatory.Item(3, CurRow.Index).Value = ._jobDescription
            dgvSignatory.Item(4, CurRow.Index).Value = ._memberId
        End With
        CurRow = Nothing
    End Sub

    Private Sub btnCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculation.Click
        If Not IsNumeric(Me.txtPrincipalAmount.Text) Then
            MsgBox("Invalid principal value.", MsgBoxStyle.Exclamation, "Invalid Value")
            Return
        End If

        If CDbl(txtPrincipalAmount.Text) < minAmount Or CDbl(txtPrincipalAmount.Text) > maxAmount Then
            MsgBox("Must be between " & Format(minAmount, "Standard") & " and " & Format(maxAmount, "Standard") & " principal's amount.", MsgBoxStyle.Exclamation, "Invalid Value")
            txtPrincipalAmount.Text = Format(minAmount, "Standard")
            Return
        End If

        If CDbl(cboLoanTypeId.Text) = 7 And Month(dtpValueDate.Value) > 3 Then
            MsgBox("This loan type available only between the month of January and April.", MsgBoxStyle.Exclamation, "Invalid Value")
            dtpValueDate.Focus()
            Return
        End If
        If CDbl(cboLoanTypeId.Text) = 6 And Month(dtpValueDate.Value) < 6 And Month(dtpValueDate.Value) < 10 Then
            MsgBox("This loan type available only between the month of June and October.", MsgBoxStyle.Exclamation, "Invalid Value")
            dtpValueDate.Focus()
            Return
        End If

        If dtpValueDate.Checked = False Then
            MsgBox("Unchecked value date.", MsgBoxStyle.Exclamation, "Check Value Date")
            Return
        End If

        If Not IsNumeric(Me.nudTerm.Value) Then
            MsgBox("Invalid period value.", MsgBoxStyle.Exclamation, "Invalid Term")
            Return
        End If

        If Not IsNumeric(Me.txtInterestRate.Text) Then
            MsgBox("Invalid interest rate value.", MsgBoxStyle.Exclamation, "Invalid Interest Rate")
            Return
        End If

        If cboLoanType.Text.Trim = "" Then
            MsgBox("Invalid loan type.", MsgBoxStyle.Exclamation, "Invalid Loan Type")
            Exit Sub
        End If

        If Not IsNumeric(txtMemberId.Text) Then
            MsgBox("Select first the member name.", MsgBoxStyle.Exclamation, "Empty Member Name")
            Exit Sub
        End If

        If clsLoanApplication.GetLoanTypeCount(RecordId, CInt(cboLoanTypeId.Text), CInt(txtMemberId.Text)) = 1 Then
            MsgBox("Loan type cannot be re-applied for this current year. Please check you previous loan.", MsgBoxStyle.Exclamation, "Invalid Loan Type.")
            Exit Sub
        End If

        btnDefault.Enabled = True
        txtTotalLoansGranted.Text = Format(CDbl(txtPrincipalAmount.Text), "Standard")
        txtMonthlyPayment.Text = Format(CDbl(txtPrincipalAmount.Text) / CInt(Me.nudTerm.Value), "Standard")
        'txtLoanInterest.Text = Format((CDbl(txtPrincipalAmount.Text) * (CDbl(txtInterestRate.Text) * 0.01)) * CDbl(nudTerm.Text), "Standard")

        valueDt = dtpValueDate.Value.ToString("yyyy-MM-dd")
        txtMaturityDt.Text = valueDt.AddMonths(CInt(nudTerm.Value)).ToString("yyyy-MM-dd")

        txtSLoanType.Text = Trim(cboLoanType.Text)
        txtSLoanTypeId.Text = CInt(cboLoanTypeId.Text)
        txtSPrincipalAmount.Text = Format(CDbl(txtPrincipalAmount.Text), "Standard")
        txtSIssuedDate.Text = valueDt.ToString("yyyy-MM-dd")
        txtSMaturityDate.Text = valueDt.AddMonths(CInt(nudTerm.Value)).ToString("yyyy-MM-dd")
        txtSTerm.Text = CInt(nudTerm.Value)
        txtSInterestRate.Text = CDbl(txtInterestRate.Text)

        GenerateSchedule()

        With clsLoanApplication
            If .ValidateLoanPayment30Percent(RecordId, CInt(cboLoanTypeId.Text), CInt(txtMemberId.Text)) = False Then
                MsgBox("The total amount paid for the previous loan is less than 30 percent the amount required to re-loan.", MsgBoxStyle.Exclamation)
                Set_Default_Values_Calculation()
                Exit Sub
            End If

            'txtRebates.Text = Format(.GetRebates(RecordId, CInt(cboLoanTypeId.Text), CInt(txtMemberId.Text)), "Standard")
            'txtTotalLoanInterest.Text = Format(CDbl(txtLoanInterest.Text) - CDbl(txtRebates.Text), "Standard")
            'txtLoanBalance.Text = Format(.GetLoanBalance(RecordId, CInt(cboLoanTypeId.Text), CInt(txtMemberId.Text)), "Standard")
            'txtCISP.Text = Format(.GetCISPRate(CInt(nudTerm.Text)) * CDbl(txtPrincipalAmount.Text), "Standard")
            'txtCISPUnused.Text = Format(.GetCISPUnused(RecordId, CInt(cboLoanTypeId.Text), CInt(txtMemberId.Text)), "Standard")
            'txtTotalCISP.Text = Format(CDbl(txtCISP.Text) - CDbl(txtCISPUnused.Text), "Standard")
            'txtServiceFee.Text = Format(.getServiceFee(), "Standard")
        End With
       
        If Trim(txtMonthlyPayment.Text) <> "" Then
            txtPromSumWord.Text = AmountInWords(Trim(txtPrincipalAmount.Text))
            txtPromSumAmt.Text = Format(Trim(txtPrincipalAmount.Text), "Standard")
            txtPromMonthlyWord.Text = AmountInWords(Trim(txtMonthlyPayment.Text))
            txtPromMonthlyAmt.Text = Format(txtMonthlyPayment.Text, "Standard")
            mtbPromFromDate.Text = valueDt.ToString("MM/dd/yyyy")
            mtbPromToDate.Text = valueDt.AddMonths(CInt(nudTerm.Value)).ToString("MM/dd/yyyy")
        End If
        Load_Loan_Balance_Record()
        Load_Fee_Record()
        Compute_Total_Net_Proceeds()
        'If Validate_Net_Proceeds() = False Then
        '    Exit Sub
        'End If
    End Sub

    Private Sub txtPrincipalAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrincipalAmount.LostFocus
        txtPrincipalAmount.Text = Format(txtPrincipalAmount.Text, "Standard")
    End Sub

    Private Sub txtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSPrincipalAmount.KeyPress, txtInterestRate.KeyPress, txtSTerm.KeyPress
        objPress(sender, e)
    End Sub

    Private Sub cboLoanType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoanType.TextChanged
        Dim dtable As DataTable = Nothing

        If State <> VIEW_STATE Then
            If cboLoanType.Text <> "" Then
                Set_Default_Values_Calculation()
                txtPrincipalAmount.Text = "0.00"
                cboLoanTypeId.SelectedIndex = cboLoanType.SelectedIndex
                With clsLoanType
                    .Init_Flag = 2
                    .Type_Id = CInt(cboLoanTypeId.Text)
                    dtable = .Search_Loan_Type_Record()
                    Dim myRow As DataRow
                    For Each myRow In dtable.Rows
                        nudTerm.Minimum = Trim(myRow("terms_min").ToString)
                        nudTerm.Maximum = Trim(myRow("terms_max").ToString)
                        nudTerm.Value = Trim(myRow("terms_min").ToString)
                        txtInterestRate.Text = Trim(myRow("interestRate").ToString)
                        intTerm = Trim(myRow("interestTerm").ToString)
                        minAmount = CDbl(myRow("amount_min").ToString)
                        If CInt(cboLoanTypeId.Text) = 6 Then
                            maxAmount = CDbl(txtSalary.Text) + 5000
                        ElseIf CInt(cboLoanTypeId.Text) = 7 Then
                            maxAmount = CDbl(txtSalary.Text)
                        Else
                            maxAmount = CDbl(myRow("amount_max").ToString)
                        End If
                        txtPrincipalAmount.Text = Format(minAmount, "Standard")
                    Next
                End With
            End If
        End If
    End Sub

    Private Sub PrintLoanApplicationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintLoanApplicationToolStripMenuItem.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsLoanApplicationReport As New DataSet
            Dim dtLoanDetails As DataTable
            Dim dtLoanBalancePayment As DataTable
            Dim dtLoanFee As DataTable
            Dim dtSignatory As DataTable
            Dim dtSystemUser As DataTable

            With clsLoanApplication
                dtLoanDetails = .Populate_Loan_Detail_Report(RecordId)
                dtLoanBalancePayment = .Populate_Loan_Balance_Report(RecordId)
                dtLoanFee = .Populate_Loan_Fee_Report(RecordId)
                dtSignatory = .Populate_Loan_Signatory_Detail_Report(RecordId)
                dtSystemUser = .System_User_Report
            End With

            dtLoanDetails.TableName = "LoanDetails"
            dtLoanBalancePayment.TableName = "LoanBalancePayment"
            dtLoanFee.TableName = "LoanFee"
            dtSignatory.TableName = "Signatory"
            dtSystemUser.TableName = "SystemUser"

            dsLoanApplicationReport.Tables.Add(dtLoanDetails)
            dsLoanApplicationReport.Tables.Add(dtLoanBalancePayment)
            dsLoanApplicationReport.Tables.Add(dtLoanFee)
            dsLoanApplicationReport.Tables.Add(dtSignatory)
            dsLoanApplicationReport.Tables.Add(dtSystemUser)

            frmLoanApplicationReportViewer = New frmCrystalReportViewer

            dsLoanApplicationReport.DataSetName = "crptLoanApplication"
            dsLoanApplicationReport.WriteXml(ReportDir + "\crptLoanApplication.xml", XmlWriteMode.WriteSchema)
            dsLoanApplicationReport.WriteXmlSchema(ReportDir + "\" + "crptLoanApplication.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmLoanApplicationReportViewer
                    .ds = dsLoanApplicationReport
                    .blnDataSource = True
                    .ReportPaperSize = 3
                    .ReportPath = gApplicationPath + "\Reports\crptLoanApplication.rpt"
                    .ReportTitle = "Loan Application"
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

    Private Sub btnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        Load_Loan_Balance_Record()
        Compute_Total_Net_Proceeds()
    End Sub

    'Datagridview

    Private Sub dgvSignatory_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSignatory.CellContentClick
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            If dgvSignatory.CurrentCell.ColumnIndex = 1 Then
                CurRow = dgvSignatory.CurrentRow
                If Trim(dgvSignatory.CurrentRow.Cells(0).Value) = "PREPARED BY" Or Trim(dgvSignatory.CurrentRow.Cells(0).Value) = "APPROVED BY" Or Trim(dgvSignatory.CurrentRow.Cells(0).Value) = "RELEASED BY" Then
                    frmUseSignatoryFinder = clsUtility.NewfrmSignatoryFinder
                    clsUtility.UseRecordState = USE_STATE
                    With frmUseSignatoryFinder
                        .frmMainUser = Me
                        .MaximizeBox = False
                        .MinimizeBox = False
                        .ShowDialog()
                    End With
                Else
                    frmUseMemberSignatoryFinder = clsUtility.NewfrmMemberSignatoryFinder
                    clsUtility.UseRecordState = USE_STATE
                    With frmUseMemberSignatoryFinder
                        .frmMainUser = Me
                        .MaximizeBox = False
                        .MinimizeBox = False
                        .ShowDialog()
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub dgvSignatory_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvSignatory.EditingControlShowing
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim AscAutoComplete As New AutoCompleteStringCollection
        If TypeOf e.Control Is TextBox Then
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case "colSignatoryName"
                    Dim mydata As DataTable = clsLoanApplication.getSignatoryName
                    With AscAutoComplete
                        .Clear()
                        For i As Integer = 0 To mydata.Rows.Count - 1
                            .Add(mydata.Rows(i).Item(0))
                        Next
                    End With
                    With CType(e.Control, TextBox)
                        .CharacterCasing = CharacterCasing.Upper
                        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        .AutoCompleteSource = AutoCompleteSource.CustomSource
                        .AutoCompleteCustomSource = AscAutoComplete
                    End With
                Case "colSignatoryPosition"
                    Dim mydata As DataTable = clsLoanApplication.getSignatoryPosition
                    With AscAutoComplete
                        .Clear()
                        For i As Integer = 0 To mydata.Rows.Count - 1
                            .Add(mydata.Rows(i).Item(0))
                        Next
                    End With
                    With CType(e.Control, TextBox)
                        .CharacterCasing = CharacterCasing.Upper
                        .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                        .AutoCompleteSource = AutoCompleteSource.CustomSource
                        .AutoCompleteCustomSource = AscAutoComplete
                    End With
            End Select
        End If

    End Sub

    Private Sub dgvBalanceRecord_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBalanceRecord.CellValueChanged
        Try
            If loan_balance_process = True Then
                If e.ColumnIndex = 0 Then
                    With dgvBalanceRecord
                        If CInt(.Item("colchkCollectible", e.RowIndex).Value) = 1 Then
                            .Item(5, e.RowIndex).ReadOnly = False
                        Else
                            .Item(5, e.RowIndex).Value = 0
                            .Item(6, e.RowIndex).Value = 0
                            .Item(7, e.RowIndex).Value = 0
                            .Item(5, e.RowIndex).ReadOnly = True
                        End If
                        .Rows(e.RowIndex).DefaultCellStyle.BackColor = Highlight_Unchecked(.Item(0, e.RowIndex).Value)
                    End With
                ElseIf e.ColumnIndex = 5 Then
                    With dgvBalanceRecord
                        .Rows(e.RowIndex).Cells(5).Value = Format(CDbl(.Item("colTotalAmount", e.RowIndex).Value), "#,##0.00")

                        If CDbl(.Rows(e.RowIndex).Cells(4).Value) = CDbl(.Rows(e.RowIndex).Cells(5).Value) Then
                            .Rows(e.RowIndex).Cells(6).Value = Format(clsLoanApplication.GetPrevRebates(CInt(.Rows(e.RowIndex).Cells(1).Value), CInt(.Rows(e.RowIndex).Cells(8).Value), CInt(txtMemberId.Text)), "Standard")
                            .Rows(e.RowIndex).Cells(7).Value = Format(clsLoanApplication.GetPrevCISPUnused(CInt(.Rows(e.RowIndex).Cells(1).Value), CInt(.Rows(e.RowIndex).Cells(8).Value), CInt(txtMemberId.Text)), "Standard")
                        Else
                            .Rows(e.RowIndex).Cells(6).Value = "0.00"
                            .Rows(e.RowIndex).Cells(7).Value = "0.00"
                        End If
                        Compute_Loan_Balance()
                        Compute_Loan_Fees()
                        Compute_Total_Net_Proceeds()
                        If Validate_Net_Proceeds(CDbl(.Rows(e.RowIndex).Cells(5).Value)) = False Then
                            Exit Sub
                        End If
                    End With
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvFees_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFees.CellValueChanged
        Try
            If loan_fee_process = True Then
                Compute_Loan_Fees()
                Compute_Total_Net_Proceeds()
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class