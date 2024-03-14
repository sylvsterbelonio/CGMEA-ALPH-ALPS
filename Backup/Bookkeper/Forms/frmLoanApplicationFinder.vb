Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmLoanApplicationFinder
    Inherits System.Windows.Forms.Form

#Region "frmLoanApplicationFinder Variable Declaration"

    Private colLoanApplication As New Collection
    Private colButton As New Collection
    Private tooltipLoanApplication As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Private start As DateTime
    Private span As TimeSpan

    Public frmMainUser As Form
    Private WithEvents clsLoanApplication As New LoanApplication.LoanApplication
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
    Private WithEvents frmLoginOverrideForm As DataAccess.frmLoginOverride

    Private intLoanId As Integer
    Private LoanNo As String
    Private TypeId As Integer
    Private TypeName As String
    Private MemberNo As String
    Private MemberName As String
    Private LoanStatus As String
    Private ReleasedFl As Integer = 0

    Public Use_Menu_Name As String

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String)

#End Region

#Region "frmLoanApplicationFinder Public Property Variable Declaration"

    Public Property Loan_Id() As Integer
        Get
            Return intLoanId
        End Get
        Set(ByVal value As Integer)
            If intLoanId = value Then
                Return
            End If
            intLoanId = value
        End Set
    End Property

#End Region

#Region "frmLoanApplicationFinder Form Sub"

    Private Sub frmLoanApplicationFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        'Me.WindowState = FormWindowState.Maximized
        Initialize_All()
        If gRoleID = 1 Then
            txtMemberNo.Text = clsLoanApplication.GetMemberNo(gUserID)
            txtMemberNo.Enabled = False
            btnSearch.PerformClick()
        Else
            txtMemberNo.Enabled = True
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmLoanApplicationFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Sub frmLoanApplicationFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtMemberName.KeyPress, txtMemberNo.KeyPress, txtLoanNo.KeyPress
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

#Region "frmLoanApplicationFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        'SetActiveAndCloseLoan()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtLoanNo.Focus()
        intLoanId = 0
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnEdit.Click, btnView.Click, dgvFinder.DoubleClick
        Dim btnObject As Button
        Dim frmTitle As String

        If TypeOf (sender) Is Button Then
            btnObject = sender
            Select Case LCase(btnObject.Text)
                Case "&add"
Add_Rec:
                    Current_State = ADD_STATE
                    Dim NwfrmLoanApplication As New frmLoanApplication
                    frmTitle = "Loan Application"

                    If Use_Record_State = USE_STATE Then
                        NwfrmLoanApplication = New frmLoanApplication
                        With NwfrmLoanApplication
                            .State = Current_State
                            .blnUseFinder = True
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .ShowDialog()
                        End With
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmLoanApplication = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmLoanApplication.Activate()
                        Else
                            NwfrmLoanApplication = New frmLoanApplication
                            With NwfrmLoanApplication
                                .State = Current_State
                                .RecordId = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&view", "&edit"
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
                                If Not LCase(btnObject.Name) = "btnview" Then
                                    If Not LoanStatus = "PENDING" And Not LoanStatus = "FOR APPROVAL" Then
                                        clsCommon.Prompt_User("information", "You can no longer edit the current loan application." & vbCrLf & "The record status has already been set as '" & UCase(LoanStatus) & "'.")
                                        Exit Sub
                                    Else
                                        'frmLoginOverrideForm = clsDataAccess.NewfrmLoginOverride
                                        'With frmLoginOverrideForm
                                        'If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                        NwfrmLoanApplication.State = EDIT_STATE
                                        NwfrmLoanApplication.Set_Form_State()
                                        'End If
                                        'End With
                                    End If
                                End If
                            End With
                        End If
                    End If
                Case "&use"
Use_Rec:
                        With frmMainUser
                            RaiseEvent Use_Clicked(intLoanId, LoanNo, TypeName)
                            Use_Record_State = ""
                            Me.Close()
                        End With
                Case "&cancel"
                        Use_Record_State = ""
                        Use_Record_Id = 0
                        Use_Record_Cd = ""
                        Use_Record_Name = ""
                        Me.Close()
            End Select
        ElseIf TypeOf (sender) Is ToolStripMenuItem Then
            Select Case LCase(sender.text)
                Case "add"
                    GoTo Add_Rec
                Case "use"
                    GoTo Use_Rec
                Case "edit", "view"
                    If LCase(sender.text) = "view" Then
                        ActiveControl = btnView
                        btnView.PerformClick()
                    Else
                        ActiveControl = btnEdit
                        btnEdit.PerformClick()
                    End If
            End Select
        ElseIf TypeOf (sender) Is DataGridView Then
            If Use_Record_State <> USE_STATE Then
                Current_State = VIEW_STATE
            End If
            btnView.PerformClick()
        End If
    End Sub

    Private Sub Initialize_Grid()
        Dim dtable As DataTable = Nothing

        With clsLoanApplication
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            ._CritLoanNo = 0
            ._CritTypeId = 0
            ._CritMemberName = ""
            ._CritMemberNo = ""
            ._CritReleasedFl = ReleasedFl

            start = DateTime.Now
            dtable = .Search_Record()
            span = DateTime.Now - start

            With dgvFinder
                .Refresh()
                .DataSource = dtable
                dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
            End With

            Me.Refresh()
        End With
    End Sub

    Private Sub Search_Crit()
        Dim dtable As DataTable = Nothing
        Set_Permission()
        With clsLoanApplication
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            ._CritLoanNo = Trim(Me.txtLoanNo.Text)
            ._CritTypeId = 0 'CInt(Trim(Me.cboTypeId.Text))
            ._CritMemberName = Trim(Me.txtMemberName.Text)
            ._CritMemberNo = Trim(Me.txtMemberNo.Text)

            ._CritReleasedFl = 0
            ._CritApprovedFl = 0
            ._CritCancelFl = 0
            ._CritActiveFl = 0

            If chkLoanReleased.Checked = True Then
                ._CritReleasedFl = 1
            End If
            If chkApproved.Checked = True Then
                ._CritApprovedFl = 1
            End If
            If chkCancelled.Checked = True Then
                ._CritCancelFl = 1
            End If

            If chkActive.Checked = True Then
                ._CritActiveFl = 1
            End If

            start = DateTime.Now
            dtable = .Search_Record()
            span = DateTime.Now - start

            dgvFinder.Refresh()
            dgvFinder.DataSource = dtable
            dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"

            If dtable.Rows.Count > 0 Then
                dgvFinder.Rows(0).Selected = True
                dgvFinder.ContextMenuStrip = mnuContextMenuStrip
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, True, True, Add_Permission = 1)
                If Use_Record_State = USE_STATE Then
                    If dgvFinder.SelectedRows.Count > 0 Then
                        intLoanId = dgvFinder.SelectedRows(0).Cells(0).Value
                        LoanNo = dgvFinder.SelectedRows(0).Cells(1).Value
                        TypeId = dgvFinder.SelectedRows(0).Cells(2).Value
                        TypeName = dgvFinder.SelectedRows(0).Cells(3).Value
                        MemberNo = dgvFinder.SelectedRows(0).Cells(5).Value
                        MemberName = dgvFinder.SelectedRows(0).Cells(6).Value
                        LoanStatus = dgvFinder.SelectedRows(0).Cells(9).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
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
            .Add(chkApproved)
            .Add(chkLoanReleased)
            .Add(chkCancelled)
            .Add(chkActive)
            .Add(dgvHeader)
        End With
        clsCommon.ClearControls(colLoanApplication)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Loan Application Finder"

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        Set_Max_Length()
        txtMemberName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipLoanApplication = clsCommon.SetUp_ToolTip_Finder(colButton)
        Initialize_AutoComplete()
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsLoanApplication
            dataCombo = .GetLoanTypeList

            clsCommon.PopulateComboBox(cboTypeId, cboTypeName, dataCombo)
        End With
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsLoanApplication.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessfl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub SetUp_Collection()
        With colButton
            .Add(btnAdd)
            .Add(btnEdit)
            .Add(btnView)
            .Add(btnSearch)
            .Add(btnClear)
        End With
    End Sub

    Private Sub Set_Max_Length()
        Me.txtMemberName.MaxLength = 125
        Me.txtMemberNo.MaxLength = 12
        Me.txtLoanNo.MaxLength = 8
    End Sub

    Private Sub Create_Context_Menu()
        Dim tsMenuItem As ToolStripMenuItem

        If Use_Record_State = USE_STATE Then
            tsMenuItem = New ToolStripMenuItem("Use", Nothing, New System.EventHandler(AddressOf btnAdd_Click))
        Else
            tsMenuItem = New ToolStripMenuItem("View", Nothing, New System.EventHandler(AddressOf btnAdd_Click))

            Dim tsMenuItemAdd As New ToolStripMenuItem("Add", Nothing, New System.EventHandler(AddressOf btnAdd_Click))
            Dim tsMenuItemEdit As New ToolStripMenuItem("Edit", Nothing, New System.EventHandler(AddressOf btnAdd_Click))

            mnuContextMenuStrip.Items.Add(tsMenuItemAdd)
            mnuContextMenuStrip.Items.Add(tsMenuItemEdit)
        End If
        Me.ContextMenu = Nothing
        mnuContextMenuStrip.Items.Add(tsMenuItem)
    End Sub

    Private Sub SetUp_UseFinderState()
        clsCommon.Setup_Use_Buttons(colButton)
    End Sub

    Private Sub SetActiveAndCloseLoan()
        Try
            If dgvFinder.RowCount > 0 Then
                For a As Integer = 0 To dgvFinder.RowCount - 1
                    'PENDING
                    'FOR APPROVAL
                    'APPROVED
                    'LOAN RELEASED
                    'CANCELED
                    'CLOSED
                    If Trim(dgvFinder.Rows(a).Cells(9).Value) = "PENDING" Or Trim(dgvFinder.Rows(a).Cells(9).Value) = "FOR APPROVAL" Then
                        'NOTHING
                    ElseIf Trim(dgvFinder.Rows(a).Cells(9).Value) = "LOAN APPROVED" Then
                        dgvFinder.Rows(a).DefaultCellStyle.BackColor = SkyBlue
                    ElseIf Trim(dgvFinder.Rows(a).Cells(9).Value) = "LOAN RELEASED" Then
                        dgvFinder.RowsDefaultCellStyle.BackColor = LightGreen
                    ElseIf Trim(dgvFinder.Rows(a).Cells(9).Value) = "CANCELED" Then
                        dgvFinder.Rows(a).DefaultCellStyle.BackColor = Pink
                    ElseIf Trim(dgvFinder.Rows(a).Cells(9).Value) = "CLOSED" Then
                        dgvFinder.Rows(a).DefaultCellStyle.BackColor = Gray
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "frmLoanApplicationFinder DataGridView Private Sub"

    Private Sub dgvFinder_Initialize()
        With dgvFinder
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .BorderStyle = System.Windows.Forms.BorderStyle.None
            .ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .Location = New System.Drawing.Point(12, 180)
            .MultiSelect = False
            .Name = "dgvFinder"
            .ReadOnly = True
            .RowHeadersWidth = 65
            .RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            .Size = New System.Drawing.Size(713, 290)

            .EnableHeadersVisualStyles = True
            .GridColor = ColorTranslator.FromHtml("#cad5a5")
            '.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cad5a5")
            '.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cad5a5")
            .RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            .RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbfbfb")
            .AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#eaebf6")

            Dim dgvColumnId = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanNo = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanTypeId = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanType = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberId = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberNo = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberName = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanDate = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanPrincipal = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanStatus = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanRemarks = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "loanId"
                .ToolTipText = "Loan Id"
                .HeaderText = "LOAN ID"
                .Width = 0
            End With

            With dgvColumnLoanNo
                .Visible = True
                .DataPropertyName = "loanNo"
                .ToolTipText = "Loan Number"
                .HeaderText = "LOAN APP. NO."
                .Width = 100
            End With

            With dgvColumnLoanTypeId
                .Visible = False
                .DataPropertyName = "loanTypeId"
                .ToolTipText = "Loan Type Id"
                .HeaderText = "LOAN TYPE ID"
                .Width = 0
            End With

            With dgvColumnLoanType
                .Visible = True
                .DataPropertyName = "loanType"
                .ToolTipText = "Loan Type"
                .HeaderText = "LOAN TYPE"
                .Width = 125
            End With

            With dgvColumnMemberId
                .Visible = False
                .DataPropertyName = "memberId"
                .ToolTipText = "Member Id"
                .HeaderText = "MEMBER ID"
                .Width = 0
            End With

            With dgvColumnMemberNo
                .Visible = False
                .DataPropertyName = "memberNo"
                .ToolTipText = "Member No"
                .HeaderText = "MEMBER NO"
                .Width = 125
            End With

            With dgvColumnMemberName
                .Visible = True
                .DataPropertyName = "memberName"
                .ToolTipText = "Member Name"
                .HeaderText = "MEMBER NAME"
                .Width = 150
            End With

            With dgvColumnLoanDate
                .Visible = True
                .DataPropertyName = "loanDt"
                .ToolTipText = "Loan Date"
                .HeaderText = "LOAN DATE"
                .DefaultCellStyle.Format = "D"
                .Width = 150
            End With

            With dgvColumnLoanPrincipal
                .Visible = True
                .DataPropertyName = "principalAmount"
                .ToolTipText = "Principal Amount"
                .HeaderText = "PRINCIPAL"
                .DefaultCellStyle.Format = "N2"
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Width = 100
            End With

            With dgvColumnLoanStatus
                .Visible = True
                .DataPropertyName = "loanStatus"
                .ToolTipText = "Loan Status"
                .HeaderText = "LOAN STATUS"
                .Width = 100
            End With

            With dgvColumnLoanRemarks
                .Visible = True
                .DataPropertyName = "loanRemarks"
                .ToolTipText = "Remarks"
                .HeaderText = "REMARKS"
                .Width = 150
            End With

            With dgvColumnMessage
                .Visible = False
                .DataPropertyName = "ErrorMessage"
                .ToolTipText = "Error Message"
                .HeaderText = "Error Message"
                .Width = 0
            End With

            .Columns.Add(dgvColumnId)
            .Columns.Add(dgvColumnLoanNo)
            .Columns.Add(dgvColumnLoanTypeId)
            .Columns.Add(dgvColumnLoanType)
            .Columns.Add(dgvColumnMemberId)
            .Columns.Add(dgvColumnMemberNo)
            .Columns.Add(dgvColumnMemberName)
            .Columns.Add(dgvColumnLoanDate)
            .Columns.Add(dgvColumnLoanPrincipal)
            .Columns.Add(dgvColumnLoanStatus)
            .Columns.Add(dgvColumnLoanRemarks)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intLoanId = dgvFinder.SelectedRows(0).Cells(0).Value
            LoanNo = dgvFinder.SelectedRows(0).Cells(1).Value
            TypeId = dgvFinder.SelectedRows(0).Cells(2).Value
            TypeName = dgvFinder.SelectedRows(0).Cells(3).Value
            MemberNo = dgvFinder.SelectedRows(0).Cells(5).Value
            MemberName = dgvFinder.SelectedRows(0).Cells(6).Value
            LoanStatus = dgvFinder.SelectedRows(0).Cells(9).Value
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

#Region "frmLoanApplicationFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class