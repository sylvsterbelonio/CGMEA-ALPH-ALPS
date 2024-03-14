Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmSignatoryFinder
    Inherits System.Windows.Forms.Form

#Region "frmSignatoryFinder Variable Declaration"

    Private colSignatory As New Collection
    Private colButton As New Collection
    Private tooltipSignatory As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Private start As DateTime
    Private span As TimeSpan

    Public frmMainUser As Form
    Private WithEvents clsSignatory As New Signatory.Signatory
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private intSignatoryId As Integer
    Private LastName As String
    Private FirstName As String
    Private Designation As String
    Private DepartmentName As String

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String)

#End Region

#Region "frmSignatoryFinder Public Property Variable Declaration"

    <CLSCompliant(False)> _
    Public Property _SignatoryId() As Integer
        Get
            Return intSignatoryId
        End Get
        Set(ByVal value As Integer)
            If intSignatoryId = value Then
                Return
            End If
            intSignatoryId = value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property _LastName() As String
        Get
            Return LastName
        End Get
        Set(ByVal value As String)
            If LastName = value Then
                Return
            End If
            LastName = value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property _FirstName() As String
        Get
            Return FirstName
        End Get
        Set(ByVal value As String)
            If FirstName = value Then
                Return
            End If
            FirstName = value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property _Designation() As String
        Get
            Return Designation
        End Get
        Set(ByVal value As String)
            If Designation = value Then
                Return
            End If
            Designation = value
        End Set
    End Property

    <CLSCompliant(False)> _
    Public Property _DepartmentName() As String
        Get
            Return DepartmentName
        End Get
        Set(ByVal value As String)
            If DepartmentName = value Then
                Return
            End If
            DepartmentName = value
        End Set
    End Property

#End Region

#Region "frmSignatoryFinder Form Sub"

    Private Sub frmSignatoryFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmSignatoryFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Sub frmSignatoryFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtFirstName.KeyPress, txtLName.KeyPress, txtDesignation.KeyPress, txtDepartmentName.KeyPress, dgvFinder.KeyPress
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

#Region "frmSignatoryFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtFirstName.Focus()
        intSignatoryId = 0
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
                    Dim NwfrmSignatory As New frmSignatory
                    frmTitle = "Signatory"

                    If Use_Record_State = USE_STATE Then
                        NwfrmSignatory = New frmSignatory
                        With NwfrmSignatory
                            .State = Current_State
                            .blnUseFinder = True
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .ShowDialog()
                        End With
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmSignatory = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmSignatory.Activate()
                        Else
                            NwfrmSignatory = New frmSignatory
                            With NwfrmSignatory
                                .State = Current_State
                                .RecordId = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&view", "&edit"
                    Current_State = VIEW_STATE
                    clsSignatory.Init_Flag = intSignatoryId
                    If clsSignatory.Selected_Record() Then
                        Dim NwfrmSignatory As frmSignatory
                        frmTitle = "Signatory - " & clsSignatory._fname & IIf(Len(clsSignatory._mname) > 0, " " & clsSignatory._mname, "") & " " & clsSignatory._lname & IIf(Len(clsSignatory._suffix) > 0, ", " & clsSignatory._suffix, "") & " [" & clsSignatory._departmentName & "]"

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmSignatory = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmSignatory.Activate()
                        Else
                            NwfrmSignatory = New frmSignatory
                            With NwfrmSignatory
                                .State = Current_State
                                .RecordId = intSignatoryId
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
                        RaiseEvent Use_Clicked(intSignatoryId, LastName, FirstName)
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

        With clsSignatory
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            ._CritFirstName = ""
            ._CritLastName = ""
            ._CritDesignation = ""
            ._CritDepartmentName = ""

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

        With clsSignatory
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            ._CritFirstName = Trim(txtFirstName.Text)
            ._CritLastName = Trim(txtLName.Text)
            ._CritDesignation = Trim(txtDesignation.Text)
            ._CritDepartmentName = Trim(txtDepartmentName.Text)

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
                        intSignatoryId = dgvFinder.SelectedRows(0).Cells(0).Value
                        FirstName = dgvFinder.SelectedRows(0).Cells(1).Value
                        LastName = dgvFinder.SelectedRows(0).Cells(2).Value
                        Designation = dgvFinder.SelectedRows(0).Cells(5).Value
                        DepartmentName = dgvFinder.SelectedRows(0).Cells(7).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colSignatory = New Collection
        With colSignatory
            .Add(txtFirstName)
            .Add(txtLName)
            .Add(txtDesignation)
            .Add(txtDepartmentName)
        End With
        clsCommon.ClearControls(colSignatory)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Signatory Finder"

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

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        Set_Max_Length()
        txtFirstName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipSignatory = clsCommon.SetUp_ToolTip_Finder(colButton)
        Create_Context_Menu()
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsSignatory.MsgArrival
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
        Me.txtFirstName.MaxLength = 45
        Me.txtLName.MaxLength = 45
        Me.txtDesignation.MaxLength = 45
        txtDepartmentName.MaxLength = 45
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

#Region "frmSignatoryFinder DataGridView Private Sub"

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
            Dim dgvColumnFirstName = New DataGridViewTextBoxColumn
            Dim dgvColumnMiddleName = New DataGridViewTextBoxColumn
            Dim dgvColumnLastName = New DataGridViewTextBoxColumn
            Dim dgvColumnSuffixName = New DataGridViewTextBoxColumn
            Dim dgvColumnDesignation = New DataGridViewTextBoxColumn
            Dim dgvColumnDepartmentId = New DataGridViewTextBoxColumn
            Dim dgvColumnDepartmentName = New DataGridViewTextBoxColumn
            Dim dgvColumnDepartmentCode = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "signatoryId"
                .ToolTipText = "Signatory Id"
                .HeaderText = "SIGNATORY ID"
                .Width = 0
            End With

            With dgvColumnFirstName
                .Visible = True
                .DataPropertyName = "fname"
                .ToolTipText = "First Name"
                .HeaderText = "FIRST NAME"
                .Width = 175
            End With

            With dgvColumnMiddleName
                .Visible = True
                .DataPropertyName = "mname"
                .ToolTipText = "Middle Name"
                .HeaderText = "MIDDLE NAME"
                .Width = 150
            End With

            With dgvColumnLastName
                .Visible = True
                .DataPropertyName = "lname"
                .ToolTipText = "Last Name"
                .HeaderText = "LAST NAME"
                .Width = 175
            End With

            With dgvColumnSuffixName
                .Visible = True
                .DataPropertyName = "suffix"
                .ToolTipText = "Suffix"
                .HeaderText = "SUFFIX"
                .Width = 100
            End With

            With dgvColumnDesignation
                .Visible = True
                .DataPropertyName = "designation"
                .ToolTipText = "Designation"
                .HeaderText = "DESIGNATION"
                .Width = 200
            End With

            With dgvColumnDepartmentId
                .Visible = False
                .DataPropertyName = "departmentId"
                .ToolTipText = "Dapertment Id"
                .HeaderText = "DEPARTMENT ID"
                .Width = 0
            End With

            With dgvColumnDepartmentName
                .Visible = False
                .DataPropertyName = "departmentName"
                .ToolTipText = "Department Name"
                .HeaderText = "DEPARTMENT NAME"
                .Width = 0
            End With

            With dgvColumnDepartmentCode
                .Visible = True
                .DataPropertyName = "departmentCode"
                .ToolTipText = "Department"
                .HeaderText = "DEPARTMENT"
                .Width = 120
            End With

            With dgvColumnMessage
                .Visible = False
                .DataPropertyName = "ErrorMessage"
                .ToolTipText = "Error Message"
                .HeaderText = "Error Message"
                .Width = 0
            End With

            .Columns.Add(dgvColumnId)
            .Columns.Add(dgvColumnFirstName)
            .Columns.Add(dgvColumnMiddleName)
            .Columns.Add(dgvColumnLastName)
            .Columns.Add(dgvColumnSuffixName)
            .Columns.Add(dgvColumnDesignation)
            .Columns.Add(dgvColumnDepartmentId)
            .Columns.Add(dgvColumnDepartmentName)
            .Columns.Add(dgvColumnDepartmentCode)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intSignatoryId = dgvFinder.SelectedRows(0).Cells(0).Value
            FirstName = dgvFinder.SelectedRows(0).Cells(1).Value
            LastName = dgvFinder.SelectedRows(0).Cells(2).Value
            Designation = dgvFinder.SelectedRows(0).Cells(5).Value
            DepartmentName = dgvFinder.SelectedRows(0).Cells(7).Value
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

#Region "frmSignatoryFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class