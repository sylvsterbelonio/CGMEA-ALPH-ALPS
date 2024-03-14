Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmPaymentLoanAndContributionFinder
    Inherits System.Windows.Forms.Form

#Region "frmPaymentLoanAndContributionFinder Variable Declaration"

    Private colPayment As New Microsoft.VisualBasic.Collection
    Private colButton As New Microsoft.VisualBasic.Collection
    Private tooltipPayment As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Public frmMainUser As Form
    Public strFormTitle As String
    Public strFormLoanTag As String
    Public Use_Record_State As String

    Private start As DateTime
    Private span As TimeSpan

    Private intpaymentId As Integer
    Private ORNo As String
    Private referenceId As Integer
    Private CancelFl As Integer
    Private DeleteFl As Integer
    Public intCancelFl As Integer = 1
    Public intReferenceId As Integer = -1

    Private WithEvents clsPayment As New Payment.Payment
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
    Private WithEvents frmLoginOverride As DataAccess.frmLoginOverride = Nothing

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String)

    Private KeyPressChar As Long

    Public Property payment_Id() As Integer
        Get
            Return intpaymentId
        End Get
        Set(ByVal value As Integer)
            If intpaymentId = value Then
                Return
            End If
            intpaymentId = value
        End Set
    End Property

    Public ReadOnly Property Cancel_Fl() As Integer
        Get
            Return CancelFl
        End Get
    End Property

    Public ReadOnly Property Delete_Fl() As Integer
        Get
            Return DeleteFl
        End Get
    End Property

#End Region

#Region "frmPaymentLoanAndContributionFinder Form Sub"

    Private Sub frmPaymentLoanAndContributionFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
        If Use_Record_State = USE_STATE Then
            SelectDefaultRecord()
        End If
    End Sub

    'Private Sub frmPaymentLoanAndContributionFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
    '    If Use_Record_State = USE_STATE Then
    '        btnEdit.PerformClick()
    '    End If
    'End Sub

#End Region

#Region "frmPaymentLoanAndContributionFinder User Defined Private Sub"

    Private Sub SelectDefaultRecord()
        intpaymentId = dgvFinder.SelectedRows(0).Cells("paymentId").Value
        ORNo = dgvFinder.SelectedRows(0).Cells("orNo").Value
        referenceId = dgvFinder.SelectedRows(0).Cells("referenceId").Value
        CancelFl = dgvFinder.SelectedRows(0).Cells("cancelFl").Value
        DeleteFl = dgvFinder.SelectedRows(0).Cells("deleteFl").Value
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
        Me.txtORNo.Focus()
        intpaymentId = 0
    End Sub

    Private Sub txtORNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMemberName.KeyPress, txtORAmount.KeyPress, txtORNo.KeyPress, dtpORDate.KeyPress, dgvFinder.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyChar.GetHashCode = 851981 Then
            Me.Cursor = WaitCursor
            Search_Crit()
            Me.Cursor = Arrow
        End If
    End Sub

    Private Sub txtORAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtORAmount.KeyPress
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
                    If LCase(Me.Tag) = "loan and contribution" Then
                        Dim NwfrmPaymentLoanAndContribution As New frmPaymentLoanAndContribution
                        frmTitle = "Loan and Contribution Payment"

                        If Use_Record_State = USE_STATE Then
                            NwfrmPaymentLoanAndContribution = New frmPaymentLoanAndContribution
                            With NwfrmPaymentLoanAndContribution
                                .State = Current_State
                                .blnUseFinder = True
                                .RecordId = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        Else
                            If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                                NwfrmPaymentLoanAndContribution = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                                NwfrmPaymentLoanAndContribution.Activate()
                            Else
                                NwfrmPaymentLoanAndContribution = New frmPaymentLoanAndContribution
                                With NwfrmPaymentLoanAndContribution
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
                    clsPayment.Init_Flag = intpaymentId
                    If clsPayment.Selected_Record() Then
                        If LCase(Me.Tag) = "loan and contribution" Then
                            Dim NwfrmPaymentLoanAndContribution As frmPaymentLoanAndContribution
                            frmTitle = "Loan and Contribution Payment - [" & clsPayment.OR_No & "]"

                            If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                                NwfrmPaymentLoanAndContribution = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                                NwfrmPaymentLoanAndContribution.Activate()
                            Else
                                NwfrmPaymentLoanAndContribution = New frmPaymentLoanAndContribution
                                With NwfrmPaymentLoanAndContribution
                                    .State = Current_State
                                    .RecordId = intpaymentId
                                    .MdiParent = Me.MdiParent
                                    .Show()
                                    If Not LCase(btnObject.Name) = "btnview" Then
                                        If CancelFl = 1 Then
                                            clsCommon.Prompt_User("information", "You can no longer edit this payment record. This record has already been cancelled.")
                                            Exit Sub
                                        ElseIf DeleteFl = 1 Then
                                            clsCommon.Prompt_User("information", "You can no longer edit this payment record. This record has already been deleted.")
                                            Exit Sub
                                        Else
                                            frmLoginOverride = clsDataAccess.NewfrmLoginOverride
                                            With frmLoginOverride
                                                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                                                    NwfrmPaymentLoanAndContribution.State = EDIT_STATE
                                                    NwfrmPaymentLoanAndContribution.Set_Form_State()
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
                        RaiseEvent Use_Clicked(intpaymentId, ORNo, "")
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

        With clsPayment
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            .CritOR_No = ""
            .CritMember_Name = ""
            .CritOR_Dt = ""
            .CritOR_Amount = CDbl(0)
            .CritCancel_Fl = intCancelFl
            .CritReference_Id = intReferenceId

            start = DateTime.Now
            dtable = .Search_LC_Record()
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

        With clsPayment
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritOR_No = Trim(txtORNo.Text)
            .CritMember_Name = txtMemberName.Text
            If dtpORDate.Checked = True Then
                .CritOR_Dt = dtpORDate.Value.ToString("yyyy-MM-dd")
            Else
                .CritOR_Dt = ""
            End If
            .CritOR_Amount = CDbl(IIf((Len(txtORAmount.Text.Replace(",", "")) = 0), 0, Val(txtORAmount.Text.Replace(",", ""))))
            .CritCancel_Fl = intCancelFl
            .CritReference_Id = intReferenceId

            start = DateTime.Now
            dtable = .Search_LC_Record()
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
                        intpaymentId = dgvFinder.SelectedRows(0).Cells(0).Value
                        ORNo = dgvFinder.SelectedRows(0).Cells(3).Value
                        referenceId = dgvFinder.SelectedRows(0).Cells(7).Value
                        CancelFl = dgvFinder.SelectedRows(0).Cells(6).Value
                        DeleteFl = dgvFinder.SelectedRows(0).Cells(8).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colPayment = New Microsoft.VisualBasic.Collection
        With colPayment
            .Add(txtORNo)
            .Add(txtMemberName)
            .Add(dtpORDate)
            .Add(txtORAmount)
        End With
        clsCommon.ClearControls(colPayment)
    End Sub

    Private Sub Initialize_All()
        Me.Tag = strFormLoanTag
        Me.Text = strFormTitle

        If LCase(Me.Tag) = "loan and contribution" Then
            intReferenceId = 2
        End If

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        txtORNo.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipPayment = clsCommon.SetUp_ToolTip_Finder(colButton)
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsPayment.MsgArrival, clsCommon.MsgArrival
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

#Region "frmPaymentLoanAndContributionFinder DataGridView Private Sub"

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
            .RowHeadersWidth = 65
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
            Dim dgvColumnMemberId = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberName = New DataGridViewTextBoxColumn
            Dim dgvColumnORNo = New DataGridViewTextBoxColumn
            Dim dgvColumnORDate = New DataGridViewTextBoxColumn
            Dim dgvColumnORAmount = New DataGridViewTextBoxColumn
            Dim dgvColumnCancelFlag = New DataGridViewTextBoxColumn
            Dim dgvColumnReferenceId = New DataGridViewTextBoxColumn
            Dim dgvColumnDeleteFlag = New DataGridViewTextBoxColumn
            Dim dgvColumnPaymentRemarks = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "paymentId"
                .Name = "paymentId"
                .ToolTipText = "Payment Id"
                .HeaderText = "PAYMENT ID"
                .Width = 0
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

            With dgvColumnORNo
                .Visible = True
                .DataPropertyName = "orNo"
                .Name = "orNo"
                .ToolTipText = "OR No"
                .HeaderText = "OR NUMBER"
                .Width = 200
            End With

            With dgvColumnORDate
                .Visible = True
                .DataPropertyName = "orDate"
                .Name = "orDate"
                .ToolTipText = "Date"
                .HeaderText = "OR DATE"
                .DefaultCellStyle.Format = "D"
                .Width = 175
            End With

            With dgvColumnORAmount
                .Visible = True
                .DataPropertyName = "orAmount"
                .Name = "orAmount"
                .ToolTipText = "Amount"
                .HeaderText = "OR AMOUNT"
                .DefaultCellStyle.Format = "N2"
                .Width = 150
            End With

            With dgvColumnReferenceId
                .Visible = False
                .DataPropertyName = "referenceId"
                .Name = "referenceId"
                .ToolTipText = "Reference Id"
                .HeaderText = "REFERENCE ID"
                .Width = 0
            End With

            With dgvColumnCancelFlag
                .Visible = False
                .DataPropertyName = "cancelFl"
                .Name = "cancelFl"
                .ToolTipText = "Cancel?"
                .HeaderText = "CANCEL?"
                .Width = 0
            End With

            With dgvColumnDeleteFlag
                .Visible = False
                .DataPropertyName = "deleteFl"
                .Name = "deleteFl"
                .ToolTipText = "Delete?"
                .HeaderText = "DELETE?"
                .Width = 0
            End With

            With dgvColumnPaymentRemarks
                .Visible = True
                .DataPropertyName = "paymentRemarks"
                .Name = "paymentRemarks"
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
            .Columns.Add(dgvColumnMemberId)
            .Columns.Add(dgvColumnMemberName)
            .Columns.Add(dgvColumnORNo)
            .Columns.Add(dgvColumnORDate)
            .Columns.Add(dgvColumnORAmount)
            .Columns.Add(dgvColumnCancelFlag)
            .Columns.Add(dgvColumnReferenceId)
            .Columns.Add(dgvColumnDeleteFlag)
            .Columns.Add(dgvColumnPaymentRemarks)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intpaymentId = dgvFinder.SelectedRows(0).Cells("paymentId").Value
            ORNo = dgvFinder.SelectedRows(0).Cells("orNo").Value
            referenceId = dgvFinder.SelectedRows(0).Cells("referenceId").Value
            CancelFl = dgvFinder.SelectedRows(0).Cells("cancelFl").Value
            DeleteFl = dgvFinder.SelectedRows(0).Cells("deleteFl").Value
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
        If dgvFinder.Rows(e.RowIndex).Cells("deleteFl").Value = 1 AndAlso dgvFinder.Rows(e.RowIndex).Cells("deleteFl").Value IsNot DBNull.Value Then
            dgvFinder.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Gray
            dgvFinder.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(f, FontStyle.Italic Or FontStyle.Bold)
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

#Region "frmPaymentLoanAndContributionFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class