Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmCollectionTypeFinder

#Region "frmCollectionTypeFinder Variable Declaration"

    Private colCollectionType As New Collection
    Private colButton As New Collection
    Private tooltipCollectionType As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Private start As DateTime
    Private span As TimeSpan

    Public frmMainUser As Form
    Private WithEvents clsCollectionType As New CollectionType.CollectionType
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private intTypeId As Integer
    Private TypeName As String

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String)

#End Region

#Region "frmCollectionTypeFinder Public Property Variable Declaration"

    Public Property Type_Id() As Integer
        Get
            Return intTypeId
        End Get
        Set(ByVal Value As Integer)
            If intTypeId = Value Then
                Return
            End If
            intTypeId = Value
        End Set
    End Property

#End Region

#Region "frmCollectionTypeFinder Form Sub"

    Private Sub frmCollectionTypeFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmCollectionTypeFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Sub frmCollectionTypeFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtCollectionName.KeyPress, txtCollectionCode.KeyPress, dgvFinder.KeyPress
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

#Region "frmCollectionTypeFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtCollectionName.Focus()
        intTypeId = 0
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
                    Dim NwfrmCollectionType As New frmCollectionType
                    frmTitle = "Collection Type"

                    If Use_Record_State = USE_STATE Then
                        NwfrmCollectionType = New frmCollectionType
                        With NwfrmCollectionType
                            .State = Current_State
                            .blnUseFinder = True
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmCollectionType = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmCollectionType.Activate()
                        Else
                            NwfrmCollectionType = New frmCollectionType
                            With NwfrmCollectionType
                                .State = Current_State
                                .RecordId = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&view", "&edit"
                    Current_State = VIEW_STATE
                    clsCollectionType.Init_Flag = intTypeId
                    If clsCollectionType.Selected_Record() Then
                        Dim NwfrmCollectionType As frmCollectionType
                        frmTitle = "Collection Type - " & clsCollectionType._typeName & " (" & clsCollectionType._typeCode & ")"

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmCollectionType = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmCollectionType.Activate()
                        Else
                            NwfrmCollectionType = New frmCollectionType
                            With NwfrmCollectionType
                                .State = Current_State
                                .RecordId = intTypeId
                                .MdiParent = Me.MdiParent
                                .Show()
                                If Not LCase(btnObject.Name) = "btnview" Then
                                    .State = EDIT_STATE
                                    .Set_Form_State()
                                End If
                            End With
                        End If
                    End If
                Case "&use"
Use_Rec:
                    With frmMainUser
                        RaiseEvent Use_Clicked(intTypeId, TypeName)
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

        With clsCollectionType
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            ._CritCollectionName = ""
            ._CritCollectionCode = ""

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

        With clsCollectionType
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            ._CritCollectionName = Trim(txtCollectionName.Text)
            ._CritCollectionCode = Trim(txtCollectionCode.Text)

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
                        intTypeId = dgvFinder.SelectedRows(0).Cells(0).Value
                        TypeName = dgvFinder.SelectedRows(0).Cells(1).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colCollectionType = New Collection
        With colCollectionType
            .Add(txtCollectionName)
            .Add(txtCollectionCode)
        End With
        clsCommon.ClearControls(colCollectionType)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Collection Type Finder"

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        Set_Max_Length()
        txtCollectionName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipCollectionType = clsCommon.SetUp_ToolTip_Finder(colButton)
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsCollectionType.MsgArrival
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
        Me.txtCollectionName.MaxLength = 45
        Me.txtCollectionCode.MaxLength = 45
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

#Region "frmCollectionTypeFinder DataGridView Private Sub"

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
            Dim dgvColumnTypeName = New DataGridViewTextBoxColumn
            Dim dgvColumnTypeCode = New DataGridViewTextBoxColumn
            Dim dgvColumnLoanRequired = New DataGridViewCheckBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "typeId"
                .ToolTipText = "Type Id"
                .HeaderText = "TYPE ID"
                .Width = 0
            End With

            With dgvColumnTypeName
                .Visible = True
                .DataPropertyName = "typeName"
                .ToolTipText = "Collection Name"
                .HeaderText = "COLLECTION NAME"
                .Width = 250
            End With

            With dgvColumnLoanRequired
                .Visible = True
                .DataPropertyName = "loanRequired"
                .ToolTipText = "Loan Required"
                .HeaderText = "LOAN REQUIRED"
                .Width = 75
            End With

            With dgvColumnTypeCode
                .Visible = True
                .DataPropertyName = "typeCode"
                .ToolTipText = "Code"
                .HeaderText = "CODE"
                .Width = 80
            End With

            With dgvColumnMessage
                .Visible = False
                .DataPropertyName = "ErrorMessage"
                .ToolTipText = "Error Message"
                .HeaderText = "Error Message"
                .Width = 0
            End With

            .Columns.Add(dgvColumnId)
            .Columns.Add(dgvColumnTypeName)
            .Columns.Add(dgvColumnTypeCode)
            .Columns.Add(dgvColumnLoanRequired)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intTypeId = dgvFinder.SelectedRows(0).Cells(0).Value
            TypeName = dgvFinder.SelectedRows(0).Cells(1).Value
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

#Region "frmCollectionTypeFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class