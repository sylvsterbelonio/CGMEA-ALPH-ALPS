Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmLoanApplicationReleaseFinder
    Inherits System.Windows.Forms.Form

#Region "frmLoanApplicationReleaseFinder Variable Declaration"

    Private colLoanApplication As New Collection
    Private colButton As New Collection
    Private tooltipLoanApplicationRelease As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Private start As DateTime
    Private span As TimeSpan

    Public frmMainUser As Form
    Private WithEvents clsLoanApplicationRelease As New LoanApplicationRelease.LoanApplicationRelease
    Private WithEvents clsLoanApplication As New LoanApplication.LoanApplication
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    Private refId As Integer
    Private intLoanId As Integer
    Private loanStatus As String

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String)

#End Region

#Region "frmLoanApplicationReleaseFinder Public Property Variable Declaration"

    Public Property _refId() As Integer
        Get
            Return refId
        End Get
        Set(ByVal value As Integer)
            If refId = value Then
                Return
            End If
            refId = value
        End Set
    End Property

#End Region

#Region "frmLoanApplicationReleaseFinder Form Sub"

    Private Sub frmLoanApplicationReleaseFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmLoanApplicationReleaseFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyChar.GetHashCode = 851981 Then
            Me.Cursor = WaitCursor
            Search_Crit()
            Me.Cursor = Arrow
        End If
    End Sub

#End Region

#Region "frmLoanApplicationReleaseFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtMemberName.Focus()
        intLoanId = 0
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsLoanApplicationRelease
            dataCombo = .GetLoanTypeList

            clsCommon.PopulateComboBox(cboTypeId, cboTypeName, dataCombo)
        End With
    End Sub

    Private Sub Search_Crit()
        Dim dtable As DataTable = Nothing

        Set_Permission()

        With clsLoanApplicationRelease
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            ._CritLoanNo = Trim(txtLoanNo.Text)
            ._CritTypeId = Trim(Me.cboTypeId.Text)
            ._CritMemberName = Trim(Me.txtMemberName.Text)
            ._CritMemberNo = Trim(Me.txtMemberNo.Text)

            Dim conDt As Date = dtpLoanDate.Value
            If dtpLoanDate.Checked = True Then
                ._CritLoanDt = conDt.ToString("yyyy-MM-dd")
            Else
                ._CritLoanDt = ""
            End If
            ._CritLoanStatus = Trim(Me.cboLoanStatus.Text)

            start = DateTime.Now
            'dtable = .Search_Record()
            span = DateTime.Now - start

            dgvFinder.Rows.Clear()
            dgvFinder.Refresh()
            'dgvFinder.DataSource = dtable
            dtDataGridView = .Populate_Loan_Record()
            If Not dtDataGridView Is Nothing Then
                For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                    With dgvFinder
                        Dim rowndx As Integer
                        rowndx = .Rows.Add()
                        .Item(0, rowndx).Value = dtDataGridViewRow("loanId")
                        .Item(1, rowndx).Value = dtDataGridViewRow("loanNo")
                        .Item(2, rowndx).Value = dtDataGridViewRow("memberId")
                        .Item(3, rowndx).Value = dtDataGridViewRow("memberNo")
                        .Item(4, rowndx).Value = dtDataGridViewRow("memberName")
                        .Item(5, rowndx).Value = dtDataGridViewRow("loanDt")
                        .Item(6, rowndx).Value = dtDataGridViewRow("loanType")
                        .Item(7, rowndx).Value = dtDataGridViewRow("principalAmount")
                        .Item(8, rowndx).Value = dtDataGridViewRow("netProceeds")
                        .Item(9, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                        .Item(10, rowndx).Value = dtDataGridViewRow("loanStatus")
                        .Item(11, rowndx).Value = dtDataGridViewRow("Remarks")
                        .Item(12, rowndx).Value = dtDataGridViewRow("refId")
                    End With
                Next
            End If

            'dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"
            cboLoanApplication.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"
            If dgvFinder.Rows.Count > 0 Then
                dgvFinder.Rows(0).Selected = True
                If dgvFinder.SelectedRows.Count > 0 Then
                    intLoanId = dgvFinder.SelectedRows(0).Cells(0).Value
                    loanStatus = CStr(dgvFinder.SelectedRows(0).Cells(10).Value)
                    refId = CStr(dgvFinder.SelectedRows(0).Cells(12).Value)
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
            End If
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

    Private Sub Clear_All_Controls()
        colLoanApplication = New Collection
        With colLoanApplication
            .Add(txtLoanNo)
            .Add(cboTypeName)
            .Add(cboTypeId)
            .Add(txtMemberName)
            .Add(txtMemberNo)
        End With
        clsCommon.ClearControls(colLoanApplication)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Loan Application Release Finder"

        SetUp_Collection()
        Clear_All_Controls()
        Set_Max_Length()
        txtMemberName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipLoanApplicationRelease = clsCommon.SetUp_ToolTip_Finder(colButton)
        Initialize_AutoComplete()
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsLoanApplicationRelease.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessfl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub SetUp_Collection()
        With colButton
            .Add(btnSearch)
            .Add(btnClear)
        End With
    End Sub

    Private Sub Set_Max_Length()
        Me.txtMemberName.MaxLength = 100
        Me.txtMemberNo.MaxLength = 10
        Me.txtLoanNo.MaxLength = 6
    End Sub

    Private Sub SetUp_UseFinderState()
        clsCommon.Setup_Use_Buttons(colButton)
    End Sub

#End Region

#Region "frmLoanApplicationReleaseFinder DataGridView Private Sub"

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intLoanId = dgvFinder.SelectedRows(0).Cells(0).Value
            loanStatus = dgvFinder.SelectedRows(0).Cells(10).Value
            refId = dgvFinder.SelectedRows(0).Cells(12).Value
        End If
    End Sub

    Private Sub dgvFinder_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFinder.MouseUp
        Try
            Dim htInfo As DataGridView.HitTestInfo

            If e.Button = Windows.Forms.MouseButtons.Right Then
                htInfo = dgvFinder.HitTest(e.X, e.Y)
                If htInfo.Type = DataGridViewHitTestType.Cell Then
                    dgvFinder.Rows(htInfo.RowIndex).Selected = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvFinder_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvFinder.RowPostPaint
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

#Region "frmLoanApplicationReleaseFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ReleaseLoanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseLoanToolStripMenuItem.Click, EditReleasedLoanToolStripMenuItem.Click, ViewLoanApplicationToolStripMenuItem.Click
        Dim frmTitle As String
        Select Case LCase(sender.Text)
            Case "release loan"
                Current_State = ADD_STATE
                Dim NwfrmLoanApplicationRelease As New frmLoanApplicationRelease
                frmTitle = "Loan Application Release"

                If Use_Record_State = USE_STATE Then
                    NwfrmLoanApplicationRelease = New frmLoanApplicationRelease
                    With NwfrmLoanApplicationRelease
                        .State = Current_State
                        .blnUseFinder = True
                        .RecordId = 0
                        .MdiParent = Me.MdiParent
                        .ShowDialog()
                    End With
                Else
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmLoanApplicationRelease = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmLoanApplicationRelease.Activate()
                    Else
                        NwfrmLoanApplicationRelease = New frmLoanApplicationRelease
                        With NwfrmLoanApplicationRelease
                            .State = Current_State
                            .RecordId = 0
                            .releasedLoanId = CInt(dgvFinder.SelectedRows(0).Cells(0).Value)
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                End If
            Case "edit released loan"
                Current_State = VIEW_STATE
                clsLoanApplicationRelease.Init_Flag = refId
                If clsLoanApplicationRelease.Selected_Record() Then
                    Dim NwfrmLoanApplicationRelease As frmLoanApplicationRelease
                    frmTitle = "Loan Application Release - " & clsLoanApplicationRelease._memberName

                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmLoanApplicationRelease = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmLoanApplicationRelease.Activate()
                    Else
                        NwfrmLoanApplicationRelease = New frmLoanApplicationRelease
                        With NwfrmLoanApplicationRelease
                            .State = Current_State
                            .RecordId = refId
                            .MdiParent = Me.MdiParent
                            .Show()
                            If Not LCase(sender.Name) = "ViewLoanApplicationToolStripMenuItem" Then
                                If Not loanStatus = "LOAN RELEASED" Then
                                    clsCommon.Prompt_User("information", "You can no longer edit the current loan application." & vbCrLf & "The record status has already been set as '" & UCase(loanStatus) & "'.")
                                    Exit Sub
                                Else
                                    frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
                                    With frmLoginOverrideForm
                                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                            NwfrmLoanApplicationRelease.State = EDIT_STATE
                                            NwfrmLoanApplicationRelease.Set_Form_State()
                                        End If
                                    End With
                                End If
                            End If
                        End With
                    End If
                End If
            Case "view loan application"
                Current_State = VIEW_STATE
                clsLoanApplication.Init_Flag = intLoanId
                If clsLoanApplication.Selected_Record() Then
                    Dim NwfrmLoanApplication As frmLoanApplication
                    frmTitle = "Loan Application - " & clsLoanApplication._memberName
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmLoanApplication = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmLoanApplication.Activate()
                    Else
                        NwfrmLoanApplication = New frmLoanApplication
                        With NwfrmLoanApplication
                            .State = Current_State
                            .RecordId = intLoanId
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                End If
        End Select
    End Sub

End Class