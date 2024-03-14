Imports System.IO
Imports System.Drawing
Imports System.Drawing.Color
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmMemberContribution
    Inherits System.Windows.Forms.Form

#Region "frmMemberContribution Variables Declaration"

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsMemberContribution As New MemberContribution.MemberContribution
    Private WithEvents clsContributionDetails As New ContributionDetails.ContributionDetails

    Private WithEvents clsDepartment As New Personnel.Department.Department
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmMemberContributionFinder
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

#Region "frmMemberContribution Main Form Private Sub"

    Private Sub frmMemberContribution_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsMemberContribution.Init_Flag = RecordId
            clsMemberContribution.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMemberContribution_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtMember.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmMemberContribution_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

#End Region

#Region "frmMemberContribution User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Default_Values()
        Me.Text = "Member Contribution"
        Me.txtMember.Focus()
    End Sub

    Private Sub Set_Default_Values()
        Try
            pnlSelectDt.Visible = False
            Initialize_AutoComplete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Initialize_AutoComplete()
        With clsMemberContribution
            With clsMemberContribution
                If State = EDIT_STATE Then
                    nudConYear.Minimum = (.GetMemberContributionMinYear())
                    nudConYear.Value = Now.Year
                    nudConYear.Maximum = Now.Year
                Else
                    nudConYear.Minimum = (.GetMemberContributionMaxYear())
                    nudConYear.Value = Now.Year
                    nudConYear.Maximum = Now.Year
                End If
            End With
        End With
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            'Member Information
            '.Add(txtFileName)
            '.Add(lblCapital)
            '.Add(txtHomeAddress)
            '.Add(txtMobileNo)
            '.Add(txtHomeTel)
            '.Add(txtLastName)
            '.Add(txtSuffixName)
            '.Add(txtMiddleName)
            '.Add(txtFirstName)
            '.Add(txtBirthDate)
            '.Add(txtDepartmentName)
            '.Add(txtAppointmentDt)
            '.Add(txtUpdateDt)
            '.Add(txtMembershipDt)
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColMember
            'Member Information
            '.Add(txtFileName)
            '.Add(txtHomeAddress)
            '.Add(txtMobileNo)
            '.Add(txtHomeTel)
            '.Add(txtLastName)
            '.Add(txtSuffixName)
            '.Add(txtMiddleName)
            '.Add(txtFirstName)
            '.Add(txtBirthDate)
            '.Add(txtDepartmentName)
            '.Add(txtAppointmentDt)
            '.Add(txtUpdateDt)
            '.Add(txtMembershipDt)
        End With

        clsCommon.ClearControls(ColMember)
        Me.Text = "Member"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            '.Add(Me.lblDepartmentName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsMemberContribution
            Me.txtMemberId.Text = .Member_Id
            Me.txtMemberNo.Text = .Member_No
            Me.txtMember.Text = .Last_Name & IIf(Len(._suffixName) > 0, " " & ._suffixName, "") & ", " & .First_Name & IIf(Len(.Middle_Name) > 0, " " & .Middle_Name, "")
            Me.txtDepartmentName.Text = .Department_Name

            Load_Member_Contribution_Monthly()
            Load_Member_Contribution_Detail()

            Me.txtMemberNo.Focus()
            Me.Text = "Member - " & .Last_Name & IIf(Len(._suffixName) > 0, " " & ._suffixName, "") & ", " & .First_Name & IIf(Len(.Middle_Name) > 0, " " & .Middle_Name, "") & " - [" & txtDepartmentName.Text & "]"
            processComplete = True
        End With
    End Sub

    Public Sub Load_Member_Contribution_Monthly()
        'populate member contribution information

        Dim dgvDt As Date
        Dim dgvDtC As String = ""
        With clsMemberContribution
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
            txtTotalPSLink.Text = Format(.GetMemberContributionTotal(5, .Member_Id), "Standard")
            txtGrandTotal.Text = Format(CDbl(txtTotalCapital.Text) + CDbl(txtTotalPabaon.Text) + CDbl(txtTotalMortuary.Text) + CDbl(txtTotalPSLink.Text), "Standard")
        End With
    End Sub

    Private Sub Load_Member_Contribution_Detail()
        'populate member contribution details
        If dgvMemberContributionMonthly.RowCount > 0 Then
            Dim dgvDt As Date
            With clsMemberContribution
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
        clsMemberContribution = Nothing
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
        'If State = "View" Then
        '    lblMemberNo.Text = "Member No."
        '    lblDepartmentName.Text = "Department Name"
        '    lblFirstName.Text = "First Name"
        '    lblLastName.Text = "Last Name"
        'Else
        '    lblMemberNo.Text = "Member No. *"
        '    lblDepartmentName.Text = "Department Name *"
        '    lblFirstName.Text = "First Name *"
        '    lblLastName.Text = "Last Name *"
        'End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsMemberContribution.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub btnAddContribution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddContribution.Click
        pnlSelectDt.Visible = True
    End Sub

    Private Sub Populate_Contribution()
        Try
            Dim GridRows As Integer

            Dim ContributionDetailItem As New Collection

            If CInt(dgvContribution.Item(1, dgvContribution.Rows.Count - 1).Value) = 0 Then
                GridRows = dgvContribution.Rows.Count - 1
            Else
                GridRows = dgvContribution.Rows.Count
            End If

            For A As Integer = 0 To GridRows - 1
                clsContributionDetails = New ContributionDetails.ContributionDetails
                With clsContributionDetails
                    ._ContributionId = CInt(dgvContribution.Item("ConId", A).Value)
                    ._TypeId = CInt(dgvContribution.Item("TypeId", A).Value)
                    Dim dueDate As Date = CStr(dgvContribution.Item("ConDate", A).Value)
                    ._ContributionDt = dueDate.ToString("yyyy-MM-dd")
                    ._Amount = CDbl(dgvContribution.Item("Amount", A).Value)
                    ._Remarks = CStr(dgvContribution.Item("Remarks", A).Value)
                End With
                ContributionDetailItem.Add(clsContributionDetails)
            Next

            With clsMemberContribution
                .colContribution_Detail = ContributionDetailItem
            End With

            ContributionDetailItem = Nothing
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

    Private Function ValidateContribution_Before_Saving() As Boolean
        Try
            Dim GridRows1 As Integer
            GridRows1 = dgvContribution.Rows.Count
            For A As Integer = 0 To GridRows1 - 1
                If CDbl(dgvContribution.Item(5, A).Value) = 0 Then
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

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
            With frmLoginOverrideForm
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_INACTIVE_CONFIRMATION)
                    If iAns = vbYes Then
                        With clsMemberContribution
                            .Member_Id = RecordId
                            .Contribution_Dt = Trim(dgvMemberContributionMonthly.SelectedRows(0).Cells(0).Value)
                            .Updated_By = gUserID
                            If .Delete_Record_Contribution() Then
                                Load_Member_Contribution_Monthly()
                                Load_Member_Contribution_Detail()
                                dgvContribution.Rows.Clear()
                            End If
                        End With
                    End If
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveContribution_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveContribution.Click
        Try
            If dgvContribution.RowCount > 0 Then
                With clsMemberContribution
                    If ValidateContribution_Before_Saving() Then
                        Me.Cursor = WaitCursor
                        With clsMemberContribution
                            .Member_Id = RecordId
                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            Populate_Contribution()
                            If .Save_Record_Contribution() Then
                                Load_Member_Contribution_Monthly()
                                Load_Member_Contribution_Detail()
                                dgvContribution.Rows.Clear()
                            End If
                        End With
                    End If
                End With
            Else
                MsgBox("No contribtion record to be save.", MsgBoxStyle.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        dgvContribution.Rows.Clear()
        pnlSelectDt.Visible = False
    End Sub

#End Region

#Region "frmMemberContribution DataGrid Private Sub"

    Private Sub dgvMemberContributionMonthly_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMemberContributionMonthly.SelectionChanged
        'populate member contribution details
        If dgvMemberContributionMonthly.SelectedRows.Count > 0 Then
            With clsMemberContribution
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

    Private Sub dgvMemberContributionMonthly_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMemberContributionMonthly.CellDoubleClick
        Dim rowndx As Integer = 0
        dgvContribution.Rows.Clear()
        If dgvMemberContributionDetails.RowCount > 0 Then
            For i As Integer = 0 To dgvMemberContributionDetails.RowCount - 1
                With dgvContribution
                    rowndx = .Rows.Add()
                    .Item(0, rowndx).Value = CInt(dgvMemberContributionDetails.Rows(rowndx).Cells(0).Value)
                    .Item(1, rowndx).Value = CInt(dgvMemberContributionDetails.Rows(rowndx).Cells(1).Value)
                    .Item(2, rowndx).Value = Trim(dgvMemberContributionDetails.Rows(rowndx).Cells(2).Value)
                    .Item(3, rowndx).Value = Trim(dgvMemberContributionDetails.Rows(rowndx).Cells(3).Value)
                    .Item(4, rowndx).Value = Trim(dgvMemberContributionDetails.Rows(rowndx).Cells(4).Value)
                    .Item(5, rowndx).Value = CDbl(dgvMemberContributionDetails.Rows(rowndx).Cells(5).Value)
                    .Item(6, rowndx).Value = Trim(dgvMemberContributionDetails.Rows(rowndx).Cells(6).Value)
                End With
            Next
        End If
    End Sub

#End Region

    Private Sub btnPnlClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPnlClose.Click
        Dim rowndx As Integer
        If dtpConDt.Value.Date <= "2015-09-30" Then
            clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
            dtpConDt.Focus()
            Exit Sub
        End If
        With dgvContribution
            .Rows.Clear()
            dtDataGridView = clsMemberContribution.Populate_Contribution_List_Detail
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In dtDataGridView.Rows
                    rowndx = .Rows.Add()
                    .Item(0, rowndx).Value = 0
                    .Item(1, rowndx).Value = Trim(dtDataGridViewRow("typeId"))
                    .Item(2, rowndx).Value = Trim(dtDataGridViewRow("typeName"))
                    .Item(3, rowndx).Value = Trim(dtpConDt.Value.ToString("yyyy") & dtpConDt.Value.ToString("-MM-") & "01")
                    .Item(4, rowndx).Value = dtpConDt.Value.ToString("MMMM yyyy")
                    .Item(5, rowndx).Value = Trim(dtDataGridViewRow("feeDefault"))
                    If clsMemberContribution.GetMemberContributionPrev(Trim(txtMemberId.Text), Trim(dtDataGridViewRow("feeId"))) > 0 Then
                        .Item(5, rowndx).Value = CDbl(clsMemberContribution.GetMemberContributionPrev(Trim(txtMemberId.Text), Trim(dtDataGridViewRow("feeId"))))
                    End If
                    .Item(6, rowndx).Value = ""
                Next
            End If
        End With
        pnlSelectDt.Visible = False
    End Sub

End Class