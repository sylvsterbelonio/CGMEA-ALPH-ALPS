Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml
Public Class frmMemberWithdrawalFinder
    Inherits System.Windows.Forms.Form

#Region "frmMemberWithdrawalFinder Variable Declaration"

    Private colWithdrawal As New Microsoft.VisualBasic.Collection
    Private colButton As New Microsoft.VisualBasic.Collection
    Private tooltipWithdrawal As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Public frmMainUser As Form
    Public strFormTitle As String
    Public strFormTag As String
    Public Use_Record_State As String

    Private start As DateTime
    Private span As TimeSpan

    Private intwithdrawalId As Integer
    Private VoucherNo As String
    Private CancelFl As Integer
    Public intCancelFl As Integer = 1

    Private WithEvents clsWithdrawal As New Withdrawal.Withdrawal
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
    Private WithEvents frmLoginOverride As DataAccess.frmLoginOverride = Nothing

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String)

    Private KeyPressChar As Long

    Public Property withdrawal_Id() As Integer
        Get
            Return intwithdrawalId
        End Get
        Set(ByVal value As Integer)
            If intwithdrawalId = value Then
                Return
            End If
            intwithdrawalId = value
        End Set
    End Property

    Public ReadOnly Property Cancel_Fl() As Integer
        Get
            Return CancelFl
        End Get
    End Property

#End Region

#Region "frmMemberWithdrawalFinder Form Sub"

    Private Sub frmWithdrawalFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
        If Use_Record_State = USE_STATE Then
            SelectDefaultRecord()
        End If
    End Sub

#End Region

#Region "frmMemberWithdrawalFinder User Defined Private Sub"

    Private Sub SelectDefaultRecord()
        intwithdrawalId = dgvFinder.SelectedRows(0).Cells("withdrawalId").Value
        VoucherNo = dgvFinder.SelectedRows(0).Cells("voucherNo").Value
        CancelFl = dgvFinder.SelectedRows(0).Cells("cancelFl").Value
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtVoucherNo.Focus()
        intwithdrawalId = 0
    End Sub

    Private Sub txtVoucherNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemberName.KeyPress, txtCapitalAmount.KeyPress, txtVoucherNo.KeyPress, dtpWithdrawnDate.KeyPress, dgvFinder.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyChar.GetHashCode = 851981 Then
            Me.Cursor = WaitCursor
            Search_Crit()
            Me.Cursor = Arrow
        End If
    End Sub

    Private Sub txtCapitalAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCapitalAmount.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.AcceptAmount(sender, e)
        End If
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
                    If LCase(Me.Tag) = "withdrawal" Then
                        Dim NwfrmMemberWithdrawal As New frmMemberWithdrawal
                        frmTitle = "Withdrawal"

                        If Use_Record_State = USE_STATE Then
                            NwfrmMemberWithdrawal = New frmMemberWithdrawal
                            With NwfrmMemberWithdrawal
                                .State = Current_State
                                .blnUseFinder = True
                                .RecordId = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        Else
                            If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                                NwfrmMemberWithdrawal = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                                NwfrmMemberWithdrawal.Activate()
                            Else
                                NwfrmMemberWithdrawal = New frmMemberWithdrawal
                                With NwfrmMemberWithdrawal
                                    .State = Current_State
                                    .RecordId = 0
                                    .MdiParent = Me.MdiParent
                                    .Show()
                                End With
                            End If
                        End If
                    End If

                Case "&view", "&edit"
                    Current_State = VIEW_STATE
                    clsWithdrawal._initFlag = intwithdrawalId
                    If clsWithdrawal.Selected_Record() Then
                        If LCase(Me.Tag) = "withdrawal" Then
                            Dim NwfrmMemberWithdrawal As frmMemberWithdrawal
                            frmTitle = "Withdrawal - [" & clsWithdrawal._voucherNo & "]"

                            If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                                NwfrmMemberWithdrawal = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                                NwfrmMemberWithdrawal.Activate()
                            Else
                                NwfrmMemberWithdrawal = New frmMemberWithdrawal
                                With NwfrmMemberWithdrawal
                                    .State = Current_State
                                    .RecordId = intwithdrawalId
                                    .MdiParent = Me.MdiParent
                                    .Show()
                                    If Not LCase(btnObject.Name) = "btnview" Then
                                        If CancelFl = 1 Then
                                            clsCommon.Prompt_User("information", "You can no longer edit this withdrawal record. This record has already been cancelled.")
                                            Exit Sub
                                        Else
                                            frmLoginOverride = clsDataAccess.NewfrmLoginOverride
                                            With frmLoginOverride
                                                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                                    NwfrmMemberWithdrawal.State = EDIT_STATE
                                                    NwfrmMemberWithdrawal.Set_Form_State()
                                                End If
                                            End With
                                        End If
                                    End If
                                End With
                            End If
                        End If
                    End If
                Case "&use"
Use_Rec:
                    With frmMainUser
                        RaiseEvent Use_Clicked(intwithdrawalId, VoucherNo, "")
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

        With clsWithdrawal
            ._dtgRID = dtable
            dtable = New DataTable
            ._initFlag = 0
            ._CritVoucherNo = ""
            ._CritMemberName = ""
            ._CritWithdrawalDate = ""
            ._CritCapitalAmount = CDbl(0)
            ._CritCancelFl = intCancelFl

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

        With clsWithdrawal
            ._dtgRID = dtable
            dtable = New DataTable
            ._initFlag = 1
            ._CritVoucherNo = Trim(txtVoucherNo.Text)
            ._CritMemberName = txtMemberName.Text
            If dtpWithdrawnDate.Checked = True Then
                ._CritWithdrawalDate = dtpWithdrawnDate.Value.ToString("yyyy-MM-dd")
            Else
                ._CritWithdrawalDate = ""
            End If
            ._CritCapitalAmount = CDbl(IIf((Len(txtCapitalAmount.Text.Replace(",", "")) = 0), 0, Val(txtCapitalAmount.Text.Replace(",", ""))))
            ._CritCancelFl = intCancelFl

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
                        intwithdrawalId = dgvFinder.SelectedRows(0).Cells(0).Value
                        VoucherNo = dgvFinder.SelectedRows(0).Cells(4).Value
                        CancelFl = dgvFinder.SelectedRows(0).Cells(9).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colWithdrawal = New Microsoft.VisualBasic.Collection
        With colWithdrawal
            .Add(txtVoucherNo)
            .Add(txtMemberName)
            .Add(dtpWithdrawnDate)
            .Add(txtCapitalAmount)
        End With
        clsCommon.ClearControls(colWithdrawal)
    End Sub

    Private Sub Initialize_All()
        Me.Tag = strFormTag
        Me.Text = strFormTitle

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        txtVoucherNo.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipWithdrawal = clsCommon.SetUp_ToolTip_Finder(colButton)
        Create_Context_Menu()
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsWithdrawal.MsgArrival, clsCommon.MsgArrival
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

#End Region

#Region "frmMemberWithdrawalFinder DataGridView Private Sub"

    Private Sub dgvFinder_Initialize()
        With dgvFinder
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .BorderStyle = System.Windows.Forms.BorderStyle.None
            .ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .Location = New System.Drawing.Point(10, 175)
            .MultiSelect = False
            .Name = "dgvFinder"
            .ReadOnly = True
            .RowHeadersWidth = 45
            .RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            .Size = New System.Drawing.Size(635, 290)

            .EnableHeadersVisualStyles = True
            .GridColor = ColorTranslator.FromHtml("#cad5a5")
            '.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cad5a5")
            '.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cad5a5")
            .RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            .RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbfbfb")
            .AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#eaebf6")

            Dim dgvColumnId = New DataGridViewTextBoxColumn
            Dim dgvColumnReceivedBy = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberId = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberName = New DataGridViewTextBoxColumn
            Dim dgvColumnVoucherNo = New DataGridViewTextBoxColumn
            Dim dgvColumnCheckNo = New DataGridViewTextBoxColumn
            Dim dgvColumnWithdrawDate = New DataGridViewTextBoxColumn
            Dim dgvColumnCapitalAmount = New DataGridViewTextBoxColumn
            Dim dgvColumnNetProceeds = New DataGridViewTextBoxColumn
            Dim dgvColumnCancelFlag = New DataGridViewTextBoxColumn
            Dim dgvColumnWithdrawalRemarks = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "withdrawalId"
                .Name = "withdrawalId"
                .ToolTipText = "Withdrawal Id"
                .HeaderText = "WITHDRAWAL ID"
                .Width = 0
            End With

            With dgvColumnReceivedBy
                .Visible = True
                .DataPropertyName = "receivedBy"
                .Name = "receivedBy"
                .ToolTipText = "Received By"
                .HeaderText = "RECEIVED BY"
                .Width = 225
            End With

            With dgvColumnMemberId
                .Visible = False
                .DataPropertyName = "memberId"
                .Name = "memberId"
                .ToolTipText = "Member Id"
                .HeaderText = "MEMBER ID"
                .Width = 0
            End With

            With dgvColumnMemberName
                .Visible = True
                .DataPropertyName = "memberName"
                .Name = "memberName"
                .ToolTipText = "Member Name"
                .HeaderText = "MEMBER NAME"
                .Width = 225
            End With

            With dgvColumnVoucherNo
                .Visible = True
                .DataPropertyName = "voucherNo"
                .Name = "voucherNo"
                .ToolTipText = "Voucher No"
                .HeaderText = "VOUCHER NUMBER"
                .Width = 200
            End With

            With dgvColumnCheckNo
                .Visible = True
                .DataPropertyName = "checkNo"
                .Name = "checkNo"
                .ToolTipText = "Check No"
                .HeaderText = "CHECK NUMBER"
                .Width = 200
            End With

            With dgvColumnWithdrawDate
                .Visible = True
                .DataPropertyName = "withdrawDt"
                .Name = "withdrawDt"
                .ToolTipText = "Date"
                .HeaderText = "WITHDRAW DATE"
                .DefaultCellStyle.Format = "D"
                .Width = 175
            End With

            With dgvColumnCapitalAmount
                .Visible = True
                .DataPropertyName = "capitalAmount"
                .Name = "capitalAmount"
                .ToolTipText = "Capital Amount"
                .HeaderText = "CAPITAL AMOUNT"
                .DefaultCellStyle.Format = "N2"
                .Width = 150
            End With

            With dgvColumnNetProceeds
                .Visible = True
                .DataPropertyName = "netProceeds"
                .Name = "netProceeds"
                .ToolTipText = "Net Proceeds"
                .HeaderText = "NET PROCEEDS"
                .DefaultCellStyle.Format = "N2"
                .Width = 150
            End With

            With dgvColumnCancelFlag
                .Visible = False
                .DataPropertyName = "cancelFl"
                .Name = "cancelFl"
                .ToolTipText = "Cancel?"
                .HeaderText = "CANCEL?"
                .Width = 0
            End With

            With dgvColumnWithdrawalRemarks
                .Visible = True
                .DataPropertyName = "withdrawalRemarks"
                .Name = "withdrawalRemarks"
                .ToolTipText = "Remarks"
                .HeaderText = "REMARKS"
                .Width = 300
            End With

            With dgvColumnMessage
                .Visible = False
                .DataPropertyName = "ErrorMessage"
                .Name = "ErrorMessage"
                .ToolTipText = "Error Message"
                .HeaderText = "Error Message"
                .Width = 0
            End With

            .Columns.Clear()
            .Columns.Add(dgvColumnId)
            .Columns.Add(dgvColumnReceivedBy)
            .Columns.Add(dgvColumnMemberId)
            .Columns.Add(dgvColumnMemberName)
            .Columns.Add(dgvColumnVoucherNo)
            .Columns.Add(dgvColumnCheckNo)
            .Columns.Add(dgvColumnWithdrawDate)
            .Columns.Add(dgvColumnCapitalAmount)
            .Columns.Add(dgvColumnNetProceeds)
            .Columns.Add(dgvColumnCancelFlag)
            .Columns.Add(dgvColumnWithdrawalRemarks)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intwithdrawalId = dgvFinder.SelectedRows(0).Cells("withdrawalId").Value
            VoucherNo = dgvFinder.SelectedRows(0).Cells("voucherNo").Value
            CancelFl = dgvFinder.SelectedRows(0).Cells("cancelFl").Value
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

    Private Sub dgvFinder_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvFinder.CellFormatting
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim f As Font = dgvFinder.DefaultCellStyle.Font

        If dgvFinder.Rows(e.RowIndex).Cells("cancelFl").Value = 1 AndAlso dgvFinder.Rows(e.RowIndex).Cells("cancelFl").Value IsNot DBNull.Value Then
            dgvFinder.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            dgvFinder.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(f, FontStyle.Strikeout Or FontStyle.Bold)
        End If
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

#Region "frmMemberWithdrawalFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class