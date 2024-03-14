Imports System.IO
Imports System.Drawing
Imports System.Drawing.Color
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmMemberInfoAndAccounts

    Inherits System.Windows.Forms.Form

#Region "frmMembersInfoAndAccounts Variables Declaration"
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsMemberInfoAndAccounts As New MemberInfoAndAccounts.MemberInfoAndAccounts

    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMember As New Personnel.Member.Member
   
    Private WithEvents clsBookkeper As New Bookkeper.Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMemberContribution As New Bookkeper.MemberContribution.MemberContribution
    
    Private WithEvents clsDepartment As New Personnel.Department.Department
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride
    Private WithEvents frmMemberContributionGenerationForm As Bookkeper.frmMemberContributionGeneration

    Private frmLoanApplicationReportViewer As frmCrystalReportViewer

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmMemberInfoAndAccountsFinder
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMember As New Collection

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

    Private contributionAmount As Double
    Private currentDt As String = ""

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow
    Private dtConstituent As New DataTable

    Private processComplete As Boolean = False

    Private allowCloseFromMemConGen As Boolean = False

    Private KeyPressChar As Long

    Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

    Private Const MSGBOX_PIPING_USE_SELF = "Record used is not valid. Please select record other than self."
    Private Const MSGBOX_PIPING_USE_CHILD = "Record used is not valid. You can not set existing child record of this record as its parent record."
    Private Const MSGBOX_PIPING_USE_PARENT = "Record used is not valid. You can not set a record with child records as a new child record."
    Public Const MSGBOX_LISTVIEWITEM_DELETE = "Please select appropriate record to delete."
    Public Const MSGBOX_LISTVIEWITEM_EDIT = "Please select appropriate record to edit."
#End Region

#Region "frmMembersInfoAndAccounts Main Form Private Sub"

    Private Sub frmMembersInfoAndAccounts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        If State = Nothing Then

            State = VIEW_STATE
            Dim mydata As New DataTable
            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblsystemuser WHERE userId = '" & gUserID & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)
            If mydata.Rows.Count <> 0 Then
                RecordId = mydata.Rows(0).Item("memberId")
            End If
        End If
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsMemberInfoAndAccounts.Init_Flag = RecordId
            clsMemberInfoAndAccounts.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMembersInfoAndAccounts_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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

    Private Sub frmMembersInfoAndAccounts_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

#End Region

#Region "frmMembersInfoAndAccounts User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Max_Length()
        Set_Default_Values()
        pnlSelectDt.Visible = False
        Me.Text = "Member Information and Accounts"
        Me.txtFirstName.Focus()
    End Sub

    Private Sub Set_Default_Values()
        Try
            txtMemberNo.Text = ""
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtMiddleName.Text = ""
            txtSuffixName.Text = ""
            txtBirthDate.Text = ""
            txtAge.Text = ""
            txtGender.Text = ""
            txtCivilStatus.Text = ""
            txtHomeTel.Text = ""
            txtMobileNo.Text = ""
            txtDepartmentName.Text = ""
            txtJobTitle.Text = ""
            txtAppointmentDt.Text = ""
            txtPermanentYears.Text = ""
            txtMembershipDt.Text = ""
            txtCGMEAYears.Text = ""
            txtHomeAddress.Text = ""
            dgvMemberContributionMonthly.Rows.Clear()
            dgvMemberContributionDetails.Rows.Clear()
            dgvLoan.Rows.Clear()
            dgvPaymentRecords.Rows.Clear()
            ClearImage()
            Initialize_AutoComplete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Initialize_AutoComplete()
        With clsMemberInfoAndAccounts
            nudConYear.Minimum = (.GetMemberContributionMinYear())
            nudConYear.Value = Now.Year
            nudConYear.Maximum = Now.Year
        End With
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            'Member Information
            .Add(txtFileName)
            .Add(lblCapital)
            .Add(txtHomeAddress)
            .Add(txtMobileNo)
            .Add(txtHomeTel)
            .Add(txtLastName)
            .Add(txtSuffixName)
            .Add(txtMiddleName)
            .Add(txtFirstName)
            .Add(txtBirthDate)
            .Add(txtDepartmentName)
            .Add(txtAppointmentDt)
            .Add(txtUpdateDt)
            .Add(txtMembershipDt)
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColMember
            'Member Information
            .Add(txtFileName)
            .Add(txtHomeAddress)
            .Add(txtMobileNo)
            .Add(txtHomeTel)
            .Add(txtLastName)
            .Add(txtSuffixName)
            .Add(txtMiddleName)
            .Add(txtFirstName)
            .Add(txtBirthDate)
            .Add(txtDepartmentName)
            .Add(txtAppointmentDt)
            .Add(txtUpdateDt)
            .Add(txtMembershipDt)
        End With

        clsCommon.ClearControls(ColMember)
        Me.Text = "Member"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(Me.lblDepartmentName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsMemberInfoAndAccounts

            Me.txtFileName.Text = .Member_Photo
            Try
                If File.Exists(txtFileName.Text) Then
                    Dim image1, imageCopy As Bitmap
                    image1 = Bitmap.FromFile(txtFileName.Text)
                    imageCopy = image1.Clone
                    lblCapital.BackgroundImage = imageCopy
                    lblCapital.BackgroundImageLayout = ImageLayout.Zoom
                Else
                    ClearImage()
                End If
            Catch ex As Exception

            End Try
            
            Me.txtMemberNo.Text = .Member_No

            Me.txtFirstName.Text = .First_Name
            Me.txtMiddleName.Text = .Middle_Name
            Me.txtLastName.Text = .Last_Name
            Me.txtSuffixName.Text = ._suffixName

            Me.txtBirthDate.Text = .Member_Birthdate
            If .Birth_Fl = 1 Then
                txtAge.ForeColor = Color.Black
                txtAge.Text = "( " & clsCommon.GetAge(txtBirthDate.Text) & " )"
            Else
                txtAge.ForeColor = Color.Red
                txtAge.Text = "( - )"
            End If

            Me.txtGender.Text = .Member_Gender
            Me.txtHomeAddress.Text = .Home_Address
            Me.txtCivilStatus.Text = .Marital_Status
            Me.txtHomeTel.Text = .Home_Tel
            Me.txtMobileNo.Text = .Mobile_No
            Me.txtDepartmentName.Text = .Department_Name
            Me.txtJobTitle.Text = .Job_Description

            Me.txtAppointmentDt.Text = .TempAppointment_Dt
            If .Appointment_Fl = 1 Then
                txtPermanentYears.ForeColor = Color.Black
                txtPermanentYears.Text = "( " & clsCommon.GetAge(txtAppointmentDt.Text) & " )"
            Else
                txtPermanentYears.ForeColor = Color.Red
                txtPermanentYears.Text = "( - )"
            End If

            Me.txtMembershipDt.Text = .TempCgmeaMembership_Dt

            If .CgmeaMembership_Fl = 1 Then
                txtCGMEAYears.ForeColor = Color.Black
                txtCGMEAYears.Text = "( " & clsCommon.GetAge(txtMembershipDt.Text) & " )"
            Else
                txtCGMEAYears.ForeColor = Color.Red
                txtCGMEAYears.Text = "( - )"
            End If

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Member_Id

            Load_Member_Contribution_Monthly()
            Load_Member_Contribution_Detail()

            'populate member loan history
            dtDataGridView = .Populate_Member_Loan(.Member_Id)
            dgvLoan.Rows.Clear()
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    With dgvLoan
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("loanId")
                        .Item(1, rowndx).Value = dtDataGridViewRow("loanNo")
                        .Item(2, rowndx).Value = dtDataGridViewRow("typeId")
                        .Item(3, rowndx).Value = dtDataGridViewRow("typeName")
                        .Item(4, rowndx).Value = dtDataGridViewRow("memberName")
                        .Item(5, rowndx).Value = dtDataGridViewRow("loanDt")
                        .Item(6, rowndx).Value = dtDataGridViewRow("loanStatus")
                        .Item(7, rowndx).Value = dtDataGridViewRow("voucherNo")
                        .Item(8, rowndx).Value = dtDataGridViewRow("checkNo")
                        .Item(9, rowndx).Value = dtDataGridViewRow("principalAmount")
                        .Item(10, rowndx).Value = dtDataGridViewRow("balanceAmount")
                        .Item(11, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                        .Item(12, rowndx).Value = dtDataGridViewRow("loanRemarks")
                        .Item(13, rowndx).Value = dtDataGridViewRow("closeFl")
                    End With
                Next
            End If

            'populate rpt payment records
            dtDataGridView = .Populate_Loan_Payment_Record(.Member_Id)
            dgvPaymentRecords.Rows.Clear()
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    With dgvPaymentRecords
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("paymentId")
                        .Item(1, rowndx).Value = Trim(UCase(dtDataGridViewRow("orNo")))
                        .Item(2, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("Amount")), "#,##0.00"))
                        .Item(3, rowndx).Value = Trim(UCase(dtDataGridViewRow("orDate")))
                        .Item(4, rowndx).Value = Trim(UCase(dtDataGridViewRow("typeName")))
                        .Item(5, rowndx).Value = Trim(UCase(dtDataGridViewRow("paymentRemarks")))
                    End With
                Next
            End If

            'populate rpt Withdrawals records
            Dim tWithdrawals As Double = 0
            dtDataGridView = .Populate_Member_Withdrawal_Record(.Member_Id)
            dgvWithdrawals.Rows.Clear()
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    With dgvWithdrawals
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("withdrawalId")
                        .Item(1, rowndx).Value = Trim(UCase(dtDataGridViewRow("voucherNo")))
                        .Item(2, rowndx).Value = Trim(UCase(dtDataGridViewRow("checkNo")))
                        .Item(3, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("capitalAmount")), "#,##0.00"))
                        .Item(4, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("serviceFee")), "#,##0.00"))
                        .Item(5, rowndx).Value = Trim(Format(CDbl(dtDataGridViewRow("netProceeds")), "#,##0.00"))
                        .Item(6, rowndx).Value = Trim(UCase(dtDataGridViewRow("withdrawDt")))
                        .Item(7, rowndx).Value = Trim(UCase(dtDataGridViewRow("receivedBy")))
                        .Item(8, rowndx).Value = Trim(UCase(dtDataGridViewRow("withdrawalRemarks")))
                        tWithdrawals = CDbl(.Item(3, rowndx).Value) + tWithdrawals
                    End With
                Next
            End If
            txtTotalWithdrawals.Text = Format(tWithdrawals, "Standard")
            txtTotalCurrentCapital.Text = Format(CDbl(txtTotalCapital.Text) - tWithdrawals, "Standard")
        End With



        Me.txtFirstName.Focus()
        Me.Text = "Member - " & txtLastName.Text & IIf(Len(txtSuffixName.Text) > 0, " " & txtSuffixName.Text, "") & ", " & txtFirstName.Text & IIf(Len(txtMiddleName.Text) > 0, " " & txtMiddleName.Text, "") & " (" & txtJobTitle.Text & ") - [" & txtDepartmentName.Text & "]"
        processComplete = True
    End Sub

    Public Sub Load_Member_Contribution_Monthly()
        'populate member contribution information

        Dim dgvDt As Date
        Dim dgvDtC As String = ""
        With clsMemberInfoAndAccounts
            dtDataGridView = .Populate_Member_Contribution_Monthly(.Member_Id, Trim(nudConYear.Value))
            dgvMemberContributionMonthly.Rows.Clear()
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    With dgvMemberContributionMonthly
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("contributionDt")
                        dgvDt = .Item(0, rowndx).Value
                        .Item(1, rowndx).Value = dgvDt.ToString("MMMM yyyy")
                        .Item(2, rowndx).Value = dtDataGridViewRow("totalAmount")
                        dgvDtC = Month(dgvDt)
                        If rowndx = 0 Then
                            currentDt = dgvDtC
                        End If
                    End With
                Next
            End If
            If dtDataGridView.Rows.Count > 0 Then
                dgvMemberContributionMonthly.Rows(0).Selected = True
            End If

            txtTotalCapital.Text = Format(.GetMemberContributionTotal(2, .Member_Id), "Standard")
            txtTotalPabaon.Text = Format(.GetMemberContributionTotal(3, .Member_Id), "Standard")
            txtTotalMortuary.Text = Format(.GetMemberContributionTotal(4, .Member_Id), "Standard")
        End With
    End Sub

    Private Sub Load_Member_Contribution_Detail()
        'populate member contribution details
        If dgvMemberContributionMonthly.RowCount > 0 Then
            Dim dgvDt As Date
            With clsMemberInfoAndAccounts
                dtDataGridView = .Populate_Member_Contribution_Details(.Member_Id, Trim(dgvMemberContributionMonthly.Rows(0).Cells(0).Value))
                dgvMemberContributionDetails.Rows.Clear()
                lblConHeader3.Text = Trim(dgvMemberContributionMonthly.SelectedRows(0).Cells(1).Value)
                If Not dtDataGridView Is Nothing Then
                    For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                        With dgvMemberContributionDetails
                            Dim rowndx As Integer
                            rowndx = .Rows.Add()
                            .Item(0, rowndx).Value = dtDataGridViewRow("contributionId")
                            .Item(1, rowndx).Value = dtDataGridViewRow("feeId")
                            .Item(2, rowndx).Value = dtDataGridViewRow("TypeName")
                            .Item(3, rowndx).Value = dtDataGridViewRow("contributionDt")
                            dgvDt = .Item(3, rowndx).Value
                            .Item(4, rowndx).Value = dgvDt.ToString("MMMM yyyy")
                            .Item(5, rowndx).Value = dtDataGridViewRow("contributionAmount")
                            .Item(6, rowndx).Value = dtDataGridViewRow("contributionRemarks")
                        End With
                    Next
                End If
            End With
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
        clsMemberInfoAndAccounts = Nothing
        clsCommon = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMember = Nothing
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
        dgvMemberContributionMonthly.ReadOnly = False
        dgvMemberContributionDetails.ReadOnly = False
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        If State = "View" Then
            lblMemberNo.Text = "Member No."
            lblDepartmentName.Text = "Department Name"
            lblFirstName.Text = "First Name"
            lblLastName.Text = "Last Name"
        Else
            lblMemberNo.Text = "Member No. *"
            lblDepartmentName.Text = "Department Name *"
            lblFirstName.Text = "First Name *"
            lblLastName.Text = "Last Name *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsMemberInfoAndAccounts.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Max_Length()
    End Sub

    Private Sub btnPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cdlOpen As New OpenFileDialog

        cdlOpen.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png) | *.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png | All Files | *.*"

        cdlOpen.ShowDialog()

        If File.Exists(cdlOpen.FileName) Then
            txtFileName.Text = cdlOpen.FileName
            Dim image1 As Bitmap = New Bitmap(cdlOpen.FileName)
            lblCapital.BackgroundImage = image1
            lblCapital.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub

    Public Sub ClearImage()
        Dim image1 As Bitmap = New Bitmap(Me.GetType, "blank-user.gif")
        lblCapital.BackgroundImage = image1
        lblCapital.BackgroundImageLayout = ImageLayout.Zoom
        txtFileName.Text = ""
    End Sub

    Private Sub Populate_Collection()
        Try
            Dim GridRows As Integer

            Dim MemberContributionDetailItem As New Collection

            If CInt(dgvMemberContributionDetails.Item(1, dgvMemberContributionDetails.Rows.Count - 1).Value) = 0 Then
                GridRows = dgvMemberContributionDetails.Rows.Count - 1
            Else
                GridRows = dgvMemberContributionDetails.Rows.Count
            End If

            For A As Integer = 0 To GridRows - 1
                clsMemberContribution = New Bookkeper.MemberContribution.MemberContribution
                With clsMemberContribution
                    .ConType_Id = CInt(dgvMemberContributionDetails.Item("colTypeId", A).Value)
                    Dim dueDate As Date = CStr(dgvMemberContributionDetails.Item("colContributionDt", A).Value)
                    .Contribution_Dt = dueDate.ToString("yyyy-MM-dd")
                    .Contribution_Amount = CStr(dgvMemberContributionDetails.Item("colContributionAmount", A).Value)
                    .Contribution_Remarks = CStr(dgvMemberContributionDetails.Item("colRemarks", A).Value)
                End With
                MemberContributionDetailItem.Add(clsMemberContribution)
            Next

            With clsMemberInfoAndAccounts
                .colMemberContribution_Detail = MemberContributionDetailItem
            End With

            MemberContributionDetailItem = Nothing
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub

    Private Function Validate_Before_Saving() As Boolean
        Try
            Dim GridRows1 As Integer
            GridRows1 = dgvMemberContributionDetails.Rows.Count
            For A As Integer = 0 To GridRows1 - 1
                If CDbl(dgvMemberContributionDetails.Item(5, A).Value) = 0 Then
                    clsCommon.Prompt_User("error", "Can not update monthly contribution. Please check the amount.")
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
            Return False
        End Try
    End Function

    Private Sub dgvMemberContributionMonthly_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMemberContributionMonthly.SelectionChanged
        'populate member contribution details
        If dgvMemberContributionMonthly.SelectedRows.Count > 0 Then
            With clsMemberInfoAndAccounts
                dtDataGridView = .Populate_Member_Contribution_Details(.Member_Id, Trim(dgvMemberContributionMonthly.SelectedRows(0).Cells(0).Value))
                dgvMemberContributionDetails.Rows.Clear()
                lblConHeader3.Text = Trim(dgvMemberContributionMonthly.SelectedRows(0).Cells(1).Value)
                If Not dtDataGridView Is Nothing Then
                    For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                        With dgvMemberContributionDetails
                            Dim rowndx As Integer
                            rowndx = .Rows.Add()
                            .Item(0, rowndx).Value = dtDataGridViewRow("contributionId")
                            .Item(1, rowndx).Value = dtDataGridViewRow("feeId")
                            .Item(2, rowndx).Value = dtDataGridViewRow("TypeName")
                            .Item(3, rowndx).Value = dtDataGridViewRow("contributionDt")
                            .Item(4, rowndx).Value = Trim(lblConHeader3.Text)
                            .Item(5, rowndx).Value = dtDataGridViewRow("contributionAmount")
                            .Item(6, rowndx).Value = dtDataGridViewRow("contributionRemarks")
                        End With
                    Next
                End If
                If dtDataGridView.Rows.Count > 0 Then
                    dgvMemberContributionDetails.Rows(0).Selected = True
                End If
            End With
        End If
    End Sub

    Private Sub nudConYear_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nudConYear.ValueChanged
        If processComplete = True Then
            Load_Member_Contribution_Monthly()
            Load_Member_Contribution_Detail()
        End If
    End Sub

    Public Sub LoadMemberContributionGenerationDialog()
        frmMemberContributionGenerationForm = New Bookkeper.frmMemberContributionGeneration
        With frmMemberContributionGenerationForm
            .memberNo = txtMemberNo.Text
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                Load_Member_Contribution_Monthly()
                Application.DoEvents()
            Else
                If .allowClose Then
                    allowCloseFromMemConGen = .allowClose
                    Me.Close()
                End If
            End If

        End With
    End Sub

#End Region

    Private Sub PrintLoanDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintLoanDetailsToolStripMenuItem.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsLoanApplicationReport As New DataSet
            Dim dtMember As DataTable
            Dim dtLoanDetails As DataTable
            Dim dtLoanSchedules As DataTable

            With clsMemberInfoAndAccounts
                dtMember = .Populate_Record_Member(RecordId)
                dtLoanDetails = .Member_Loan_Details_Report(Trim(dgvLoan.SelectedRows(0).Cells(0).Value))
                dtLoanSchedules = .Member_Loan_Schedules_Report(Trim(dgvLoan.SelectedRows(0).Cells(0).Value))
            End With

            dtMember.TableName = "Member"
            dtLoanDetails.TableName = "LoanDetails"
            dtLoanSchedules.TableName = "LoanSchedules"

            dsLoanApplicationReport.Tables.Add(dtMember)
            dsLoanApplicationReport.Tables.Add(dtLoanDetails)
            dsLoanApplicationReport.Tables.Add(dtLoanSchedules)

            frmLoanApplicationReportViewer = New frmCrystalReportViewer

            dsLoanApplicationReport.DataSetName = "crptMemberLoanDetails"
            dsLoanApplicationReport.WriteXml(ReportDir + "\crptMemberLoanDetails.xml", XmlWriteMode.WriteSchema)
            dsLoanApplicationReport.WriteXmlSchema(ReportDir + "\" + "crptMemberLoanDetails.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmLoanApplicationReportViewer
                    .ds = dsLoanApplicationReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberLoanDetails.rpt"
                    .ReportTitle = "Member Loan Details"
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

    Private Sub PrintAccountDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintAccountDetailsToolStripMenuItem.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsLoanApplicationReport As New DataSet
            Dim dtMember As DataTable
            Dim dtContribution As DataTable

            With clsMemberInfoAndAccounts
                dtMember = .Populate_Record_Member(RecordId)
                dtContribution = .Populate_Member_Contribution_Report(RecordId)
            End With

            dtMember.TableName = "Member"
            dtContribution.TableName = "Contribution"

            dsLoanApplicationReport.Tables.Add(dtMember)
            dsLoanApplicationReport.Tables.Add(dtContribution)

            frmLoanApplicationReportViewer = New frmCrystalReportViewer

            dsLoanApplicationReport.DataSetName = "crptMemberAccountDetails"
            dsLoanApplicationReport.WriteXml(ReportDir + "\crptMemberAccountDetails.xml", XmlWriteMode.WriteSchema)
            dsLoanApplicationReport.WriteXmlSchema(ReportDir + "\" + "crptMemberAccountDetails.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmLoanApplicationReportViewer
                    .ds = dsLoanApplicationReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberAccountDetails.rpt"
                    .ReportTitle = "Member Account Details"
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

    Private Sub PrintLoanSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintLoanSummaryToolStripMenuItem1.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsLoanApplicationReport As New DataSet
            Dim dtMember As DataTable
            Dim dtLoanSummary As DataTable

            With clsMemberInfoAndAccounts
                dtMember = .Populate_Record_Member(RecordId)
                dtLoanSummary = .Member_Loan_Summary_Report(RecordId)
            End With

            dtMember.TableName = "Member"
            dtLoanSummary.TableName = "LoanSummary"

            dsLoanApplicationReport.Tables.Add(dtMember)
            dsLoanApplicationReport.Tables.Add(dtLoanSummary)

            frmLoanApplicationReportViewer = New frmCrystalReportViewer

            dsLoanApplicationReport.DataSetName = "crptMemberLoanSummary"
            dsLoanApplicationReport.WriteXml(ReportDir + "\crptMemberLoanSummary.xml", XmlWriteMode.WriteSchema)
            dsLoanApplicationReport.WriteXmlSchema(ReportDir + "\" + "crptMemberLoanSummary.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmLoanApplicationReportViewer
                    .ds = dsLoanApplicationReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberLoanSummary.rpt"
                    .ReportTitle = "Member Loan Summary"
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

    Private Sub ViewLedgerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewLedgerToolStripMenuItem.Click
        pnlSelectDt.Visible = True
        tabMemberInfoAndAccounts.Enabled = False
    End Sub

    Private Sub btnPnlClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPnlClose.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsLedgerReport As New DataSet
            Dim dtMember As DataTable
            Dim dtContribution As DataTable
            Dim dtLoan As DataTable
            Dim dtPayment As DataTable
            Dim vDt As Date = dtpConDt.Value.ToString("yyyy-MM-dd")

            pnlSelectDt.Visible = False
            tabMemberInfoAndAccounts.Enabled = True

            With clsMemberInfoAndAccounts
                dtMember = .Populate_Record_Member(RecordId)
                dtContribution = .Populate_Contribution_Report(RecordId, dtpConDt.Value.ToString("yyyy-MM-dd"))
                dtLoan = .Populate_Member_Loan_Report(RecordId, dtpConDt.Value.ToString("yyyy-MM-dd"))
                dtPayment = .Populate_Loan_Payment_Report(RecordId, dtpConDt.Value.ToString("yyyy-MM-dd"))
            End With

            dtMember.TableName = "Member"
            dtContribution.TableName = "Contribution"
            dtLoan.TableName = "Loan"
            dtPayment.TableName = "Payment"

            dsLedgerReport.Tables.Add(dtMember)
            dsLedgerReport.Tables.Add(dtContribution)
            dsLedgerReport.Tables.Add(dtLoan)
            dsLedgerReport.Tables.Add(dtPayment)

            frmLoanApplicationReportViewer = New frmCrystalReportViewer

            dsLedgerReport.DataSetName = "crptMemberLedgerAccountDetails"
            dsLedgerReport.WriteXml(ReportDir + "\crptMemberLedgerAccountDetails.xml", XmlWriteMode.WriteSchema)
            dsLedgerReport.WriteXmlSchema(ReportDir + "\" + "crptMemberLedgerAccountDetails.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmLoanApplicationReportViewer
                    .ds = dsLedgerReport
                    .blnDataSource = True
                    .ReportOrientation = 1
                    .ReportPaperSize = 3
                    .ReportPath = gApplicationPath + "\Reports\crptMemberLedgerAccountDetails.rpt"
                    .ReportTitle = "Member Ledger Account Details"
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub CloseLoansOnlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseLoansOnlyToolStripMenuItem.Click, ActiveLoansOnlyToolStripMenuItem.Click, ViewAllLoansToolStripMenuItem.Click
        Try
            With clsMemberInfoAndAccounts
                'populate member loan history
                dtDataGridView = .Populate_Member_Loan(.Member_Id)
                dgvLoan.Rows.Clear()
                If Not dtDataGridView Is Nothing Then
                    For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                        With dgvLoan
                            Dim rowndx As Integer
                            If sender.ToString = "View Close Loans" Then
                                If dtDataGridViewRow("closeFl") = 1 Then
                                    rowndx = .Rows.Add()
                                    .Item(0, rowndx).Value = dtDataGridViewRow("loanId")
                                    .Item(1, rowndx).Value = dtDataGridViewRow("loanNo")
                                    .Item(2, rowndx).Value = dtDataGridViewRow("typeId")
                                    .Item(3, rowndx).Value = dtDataGridViewRow("typeName")
                                    .Item(4, rowndx).Value = dtDataGridViewRow("memberName")
                                    .Item(5, rowndx).Value = dtDataGridViewRow("loanDt")
                                    .Item(6, rowndx).Value = dtDataGridViewRow("loanStatus")
                                    .Item(7, rowndx).Value = dtDataGridViewRow("voucherNo")
                                    .Item(8, rowndx).Value = dtDataGridViewRow("checkNo")
                                    .Item(9, rowndx).Value = dtDataGridViewRow("principalAmount")
                                    .Item(10, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                    .Item(11, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                                    .Item(12, rowndx).Value = dtDataGridViewRow("loanRemarks")
                                    .Item(13, rowndx).Value = dtDataGridViewRow("closeFl")
                                End If
                            ElseIf sender.ToString = "View Active Loans" Then
                                If dtDataGridViewRow("closeFl") = 0 Then
                                    rowndx = .Rows.Add()
                                    .Item(0, rowndx).Value = dtDataGridViewRow("loanId")
                                    .Item(1, rowndx).Value = dtDataGridViewRow("loanNo")
                                    .Item(2, rowndx).Value = dtDataGridViewRow("typeId")
                                    .Item(3, rowndx).Value = dtDataGridViewRow("typeName")
                                    .Item(4, rowndx).Value = dtDataGridViewRow("memberName")
                                    .Item(5, rowndx).Value = dtDataGridViewRow("loanDt")
                                    .Item(6, rowndx).Value = dtDataGridViewRow("loanStatus")
                                    .Item(7, rowndx).Value = dtDataGridViewRow("voucherNo")
                                    .Item(8, rowndx).Value = dtDataGridViewRow("checkNo")
                                    .Item(9, rowndx).Value = dtDataGridViewRow("principalAmount")
                                    .Item(10, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                    .Item(11, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                                    .Item(12, rowndx).Value = dtDataGridViewRow("loanRemarks")
                                    .Item(13, rowndx).Value = dtDataGridViewRow("closeFl")
                                End If
                            ElseIf sender.ToString = "View All Loans" Then
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = dtDataGridViewRow("loanId")
                                .Item(1, rowndx).Value = dtDataGridViewRow("loanNo")
                                .Item(2, rowndx).Value = dtDataGridViewRow("typeId")
                                .Item(3, rowndx).Value = dtDataGridViewRow("typeName")
                                .Item(4, rowndx).Value = dtDataGridViewRow("memberName")
                                .Item(5, rowndx).Value = dtDataGridViewRow("loanDt")
                                .Item(6, rowndx).Value = dtDataGridViewRow("loanStatus")
                                .Item(7, rowndx).Value = dtDataGridViewRow("voucherNo")
                                .Item(8, rowndx).Value = dtDataGridViewRow("checkNo")
                                .Item(9, rowndx).Value = dtDataGridViewRow("principalAmount")
                                .Item(10, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                .Item(11, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                                .Item(12, rowndx).Value = dtDataGridViewRow("loanRemarks")
                                .Item(13, rowndx).Value = dtDataGridViewRow("closeFl")
                            End If
                        End With
                    Next
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub
End Class