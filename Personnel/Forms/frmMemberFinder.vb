Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmMemberFinder
    Inherits System.Windows.Forms.Form

#Region "frmMemberFinder Variable Declaration"

    Private colMember As New Collection
    Private colButton As New Collection
    Private tooltipMember As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Private start As DateTime
    Private span As TimeSpan

    Public frmMainUser As Form
    Private WithEvents clsMember As New Member.Member
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private intMemberId As Integer
    Private MemberNo As String
    Private MemberName As String
    Private LGUName As String
    Private DeptName As String

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String)

#End Region

#Region "frmMemberFinder Public Property Variable Declaration"

    Public Property Member_Id() As Integer
        Get
            Return IntMemberId
        End Get
        Set(ByVal value As Integer)
            If intMemberId = value Then
                Return
            End If
            intMemberId = value
        End Set
    End Property

    Public Property Member_No() As String
        Get
            Return MemberNo
        End Get
        Set(ByVal value As String)
            If MemberNo = value Then
                Return
            End If
            MemberNo = value
        End Set
    End Property

    Public Property Member_Name() As String
        Get
            Return MemberName
        End Get
        Set(ByVal value As String)
            If MemberName = value Then
                Return
            End If
            MemberName = value
        End Set
    End Property

    Public Property LGU_Name() As String
        Get
            Return LGUName
        End Get
        Set(ByVal value As String)
            If LGUName = value Then
                Return
            End If
            LGUName = value
        End Set
    End Property

    Public Property Dept_Name() As String
        Get
            Return DeptName
        End Get
        Set(ByVal value As String)
            If DeptName = value Then
                Return
            End If
            DeptName = value
        End Set
    End Property

#End Region

#Region "frmMemberFinder Form Sub"

    Private Sub frmMemberFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMemberFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Sub frmMemberFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtLGUName.KeyPress, txtDepartmentName.KeyPress, txtMemberName.KeyPress, txtMemberNo.KeyPress ', udgFinder.KeyPress
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

#Region "frmMemberFinder User Defined Private Sub"

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
        intMemberId = 0
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
                    Dim NwfrmMember As New frmMember
                    frmTitle = "Member"

                    If Use_Record_State = USE_STATE Then
                        NwfrmMember = New frmMember
                        With NwfrmMember
                            .ClearImage()
                            .State = Current_State
                            .blnUseFinder = True
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .ShowDialog()
                        End With
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmMember = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmMember.Activate()
                        Else
                            NwfrmMember = New frmMember
                            With NwfrmMember
                                .ClearImage()
                                .State = Current_State
                                .RecordId = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&view", "&edit"
                    Current_State = VIEW_STATE
                    clsMember.Init_Flag = intMemberId
                    If clsMember.Selected_Record() Then
                        Dim NwfrmMember As frmMember
                        frmTitle = "Member - " & clsMember.Last_Name & IIf(Len(clsMember._suffixName) > 0, " " & clsMember._suffixName, "") & ", " & clsMember.First_Name & IIf(Len(clsMember.Middle_Name) > 0, " " & clsMember.Middle_Name, "") & " (" & clsMember.Job_Description & ") - [" & clsMember.Department_Name & "]"

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmMember = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmMember.Activate()
                        Else
                            NwfrmMember = New frmMember
                            With NwfrmMember
                                .State = Current_State
                                .RecordId = intMemberId
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
                        RaiseEvent Use_Clicked(intMemberId, MemberNo, MemberName)
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

        With clsMember
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            .CritMember_Name = ""
            .CritMember_No = ""
            .Critlgu_Name = ""
            .CritDepartment_Name = ""

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

        With clsMember
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritMember_Name = Trim(Me.txtMemberName.Text)
            .CritMember_No = Trim(Me.txtMemberNo.Text)
            .Critlgu_Name = Trim(Me.txtLGUName.Text)
            .CritDepartment_Name = Trim(Me.txtDepartmentName.Text)

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
                        intMemberId = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
                        MemberNo = dgvFinder.SelectedRows(0).Cells(1).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
                        MemberName = dgvFinder.SelectedRows(0).Cells(2).Value & ", " & dgvFinder.SelectedRows(0).Cells(3).Value & " " & dgvFinder.SelectedRows(0).Cells(4).Value
                        LGUName = dgvFinder.SelectedRows(0).Cells(8).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
                        DeptName = dgvFinder.SelectedRows(0).Cells(10).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission = 1)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colMember = New Collection
        With colMember
            .Add(txtMemberName)
            .Add(txtMemberNo)
            .Add(txtLGUName)
            .Add(txtDepartmentName)
        End With
        clsCommon.ClearControls(colMember)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Member Finder"

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
        txtMemberName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipMember = clsCommon.SetUp_ToolTip_Finder(colButton)
        Create_Context_Menu()
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsMember.MsgArrival
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
        Me.txtMemberName.MaxLength = 50
        Me.txtMemberNo.MaxLength = 50
        Me.txtLGUName.MaxLength = 50
        Me.txtDepartmentName.MaxLength = 50
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

#Region "frmMemberFinder DataGridView Private Sub"

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
            Dim dgvColumnMemberNo = New DataGridViewTextBoxColumn
            Dim dgvColumnLastName = New DataGridViewTextBoxColumn
            Dim dgvColumnFirstName = New DataGridViewTextBoxColumn
            Dim dgvColumnMiddleName = New DataGridViewTextBoxColumn
            Dim dgvColumnSuffixName = New DataGridViewTextBoxColumn
            Dim dgvColumnJobDescription = New DataGridViewTextBoxColumn
            Dim dgvColumnappointmentStatus = New DataGridViewTextBoxColumn
            Dim dgvColumnLGUId = New DataGridViewTextBoxColumn
            Dim dgvColumnLGUName = New DataGridViewTextBoxColumn
            Dim dgvColumnDepartmentId = New DataGridViewTextBoxColumn
            Dim dgvColumnDepartmentName = New DataGridViewTextBoxColumn
            Dim dgvColumnHireDt = New DataGridViewTextBoxColumn
            Dim dgvColumnMembershipDt = New DataGridViewTextBoxColumn
            Dim dgvColumnActiveFl = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberFl = New DataGridViewTextBoxColumn
            Dim dgvColumnReassignFl = New DataGridViewTextBoxColumn
            Dim dgvColumnReplaceFl = New DataGridViewTextBoxColumn
            Dim dgvColumnRetireFl = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "memberId"
                .ToolTipText = "Member Id"
                .HeaderText = "MEMBER ID"
                .Width = 0
            End With

            With dgvColumnMemberNo
                .Visible = True
                .DataPropertyName = "memberNo"
                .ToolTipText = "Member Number"
                .HeaderText = "MEMBER NUMBER"
                .Width = 150
            End With

            With dgvColumnLastName
                .Visible = True
                .DataPropertyName = "lastName"
                .ToolTipText = "Last Name"
                .HeaderText = "LAST NAME"
                .Width = 150
            End With

            With dgvColumnFirstName
                .Visible = True
                .DataPropertyName = "firstName"
                .ToolTipText = "First Name"
                .HeaderText = "FIRST NAME"
                .Width = 150
            End With

            With dgvColumnMiddleName
                .Visible = True
                .DataPropertyName = "middleName"
                .ToolTipText = "Middle Name"
                .HeaderText = "MIDDLE NAME"
                .Width = 150
            End With

            With dgvColumnSuffixName
                .Visible = True
                .DataPropertyName = "suffixName"
                .ToolTipText = "Suffix"
                .HeaderText = "SUFFIX"
                .Width = 100
            End With

            With dgvColumnJobDescription
                .Visible = True
                .DataPropertyName = "jobDescription"
                .ToolTipText = "Job Description / Position"
                .HeaderText = "JOB DESCRIPTION / POSITION"
                .Width = 300
            End With

            With dgvColumnappointmentStatus
                .Visible = True
                .DataPropertyName = "appointmentStatus"
                .ToolTipText = "Status of Appointment"
                .HeaderText = "STATUS OF APPOINTMENT"
                .Width = 200
            End With

            With dgvColumnLGUId
                .Visible = False
                .DataPropertyName = "lguId"
                .ToolTipText = "LGU ID"
                .HeaderText = "LGU ID"
                .Width = 0
            End With

            With dgvColumnLGUName
                .Visible = False
                .DataPropertyName = "lguName"
                .ToolTipText = "LGU Name"
                .HeaderText = "LGU NAME"
                .Width = 0
            End With

            With dgvColumnDepartmentId
                .Visible = False
                .DataPropertyName = "departmentId"
                .ToolTipText = "Department ID"
                .HeaderText = "DEPARTMENT ID"
                .Width = 0
            End With

            With dgvColumnDepartmentName
                .Visible = True
                .DataPropertyName = "departmentName"
                .ToolTipText = "Department Name"
                .HeaderText = "DEPARTMENT NAME"
                .Width = 300
            End With

            With dgvColumnHireDt
                .Visible = True
                .DataPropertyName = "hireDt"
                .ToolTipText = "Date Hired"
                .HeaderText = "DATE HIRED"
                .DefaultCellStyle.Format = "D"
                .Width = 150
            End With

            With dgvColumnMembershipDt
                .Visible = True
                .DataPropertyName = "cgmeaMembershipDt"
                .ToolTipText = "Date Membered"
                .HeaderText = "DATE MEMBERED"
                .DefaultCellStyle.Format = "D"
                .Width = 150
            End With

            With dgvColumnActiveFl
                .Visible = True
                .DataPropertyName = "activeFl"
                .ToolTipText = "Active?"
                .HeaderText = "ACTIVE?"
                .Width = 100
            End With

            With dgvColumnMemberFl
                .Visible = True
                .DataPropertyName = "memberFl"
                .ToolTipText = "Member?"
                .HeaderText = "MEMBER?"
                .Width = 100
            End With

            With dgvColumnReassignFl
                .Visible = False
                .DataPropertyName = "reassignFl"
                .ToolTipText = "Reassign F1"
                .HeaderText = "Reassign F1"
                .Width = 0
            End With

            With dgvColumnReplaceFl
                .Visible = False
                .DataPropertyName = "replaceFl"
                .ToolTipText = "Replace F1"
                .HeaderText = "Replace F1"
                .Width = 0
            End With

            With dgvColumnRetireFl
                .Visible = False
                .DataPropertyName = "retireFl"
                .ToolTipText = "Retire F1"
                .HeaderText = "Retire F1"
                .Width = 0
            End With

            With dgvColumnMessage
                .Visible = False
                .DataPropertyName = "ErrorMessage"
                .ToolTipText = "Error Message"
                .HeaderText = "Error Message"
                .Width = 0
            End With

            .Columns.Add(dgvColumnId)
            .Columns.Add(dgvColumnMemberNo)
            .Columns.Add(dgvColumnLastName)
            .Columns.Add(dgvColumnFirstName)
            .Columns.Add(dgvColumnMiddleName)
            .Columns.Add(dgvColumnSuffixName)
            .Columns.Add(dgvColumnJobDescription)
            .Columns.Add(dgvColumnappointmentStatus)
            .Columns.Add(dgvColumnLGUId)
            .Columns.Add(dgvColumnLGUName)
            .Columns.Add(dgvColumnDepartmentId)
            .Columns.Add(dgvColumnDepartmentName)
            .Columns.Add(dgvColumnHireDt)
            .Columns.Add(dgvColumnMembershipDt)
            .Columns.Add(dgvColumnActiveFl)
            .Columns.Add(dgvColumnMemberFl)
            .Columns.Add(dgvColumnReassignFl)
            .Columns.Add(dgvColumnReplaceFl)
            .Columns.Add(dgvColumnRetireFl)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intMemberId = dgvFinder.SelectedRows(0).Cells(0).Value
            MemberNo = dgvFinder.SelectedRows(0).Cells(1).Value
            MemberName = dgvFinder.SelectedRows(0).Cells(2).Value & ", " & dgvFinder.SelectedRows(0).Cells(3).Value & " " & dgvFinder.SelectedRows(0).Cells(4).Value
            LGUName = dgvFinder.SelectedRows(0).Cells(8).Value
            DeptName = dgvFinder.SelectedRows(0).Cells(10).Value
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

#Region "frmMemberFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class