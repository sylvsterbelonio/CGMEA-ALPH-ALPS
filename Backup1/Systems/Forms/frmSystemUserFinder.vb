Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmSystemUserFinder
    Inherits System.Windows.Forms.Form

#Region "frmSystemUserFinder Variable Declaration"

    Private colSystemUser As New Collection
    Private colButton As New Collection
    Private tooltipSystemUser As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Public frmMainUser As Form
    Private start As DateTime
    Private span As TimeSpan

    Private WithEvents clsSystemUser As New SystemUser.SystemUser
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)


    Private cboRoleId As New ComboBox
    Private dsCombo As DataSet
    Private intUserId As Integer
    Private RoleName As String
    Private UserName As String
    Private FirstName As String
    Private MiddleName As String
    Private LastName As String
    Private JobDesc As String
    Private MemberActiveFl As Integer

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Cd As String, ByVal Record_Name As String, ByVal Record_Desc As String)

#End Region

#Region "frmSystemUserFinder Public Property Variable Declaration"

    Public Property User_Id() As Integer
        Get
            Return intUserId
        End Get
        Set(ByVal Value As Integer)
            If intUserId = Value Then
                Return
            End If
            intUserId = Value
        End Set
    End Property

    Public Property Role_Name() As String
        Get
            Return RoleName
        End Get
        Set(ByVal value As String)
            If RoleName = value Then
                Return
            End If
            RoleName = value
        End Set
    End Property

#End Region

#Region "frmSystemUserFinder Form Sub"





    Private Sub frmSystemUserFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmSystemUserFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Sub frmSystemUserFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtFName.KeyPress, txtLName.KeyPress, cboRole.KeyPress
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

#Region "frmSystemUserFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtFName.Focus()
        intUserId = 0
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
                    Dim NwfrmSystemUser As New frmSystemUser

                    frmTitle = "System User"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmSystemUser = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmSystemUser.Activate()
                    Else
                        NwfrmSystemUser = New frmSystemUser
                        With NwfrmSystemUser
                            .ClearImage()
                            .State = Current_State
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                Case "&view", "&edit"
                    Current_State = VIEW_STATE
                    clsSystemUser.Init_Flag = intUserId
                    If clsSystemUser.Selected_Record() Then
                        Dim NwfrmSystemUser As frmSystemUser
                        If clsSystemUser.User_ID = 0 Then
                            frmTitle = "System User - System Administrator"
                        Else
                            frmTitle = "System User - " & clsSystemUser.Last_Name & ", " & clsSystemUser.First_Name & " " & clsSystemUser.Middle_Name & " (" & clsSystemUser.Role_Name & ")"
                        End If

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmSystemUser = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmSystemUser.Activate()
                        Else
                            NwfrmSystemUser = New frmSystemUser
                            With NwfrmSystemUser
                                .State = Current_State
                                .RecordId = intUserId
                                .MdiParent = Me.MdiParent
                                .Show()
                                If Not LCase(btnObject.Name) = "btnview" Then
                                    If MemberActiveFl = 0 Then
                                        clsCommon.Prompt_User("information", "You are not allowed to edit the current system user. The linked member record has already been set inactive.")
                                        Exit Sub
                                    Else
                                        .State = EDIT_STATE
                                        .Set_Form_State()
                                    End If
                                End If
                            End With
                        End If
                    End If
                Case "&use"

                    With frmMainUser
                        RaiseEvent Use_Clicked(intUserId, FirstName, MiddleName, LastName)
                        Use_Record_State = ""
                        Me.Close()
                    End With
Use_Rec:
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

        With clsSystemUser
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            .CritFirst_Name = ""
            .CritLast_Name = ""
            .CritRole_Name = ""
            .CritActive_Fl = 0

            start = DateTime.Now
            dtable = .Search_Record()
            span = DateTime.Now - start

            With dgvFinder
                .Refresh()
                .DataSource = dtable
                dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False)
            End With

            Me.Refresh()
        End With
    End Sub

    Private Sub Search_Crit()
        Dim dtable As DataTable = Nothing

        Set_Permission()

        With clsSystemUser
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritFirst_Name = Trim(Me.txtFName.Text)
            .CritLast_Name = Trim(Me.txtLName.Text)
            .CritRole_Name = Trim(Me.cboRole.Text)
            .CritActive_Fl = chkActiveFl.CheckState

            start = DateTime.Now
            dtable = .Search_Record()
            span = DateTime.Now - start

            dgvFinder.Refresh()
            dgvFinder.DataSource = dtable
            dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"

            If dtable.Rows.Count > 0 Then
                dgvFinder.Rows(0).Selected = True
                dgvFinder.ContextMenuStrip = mnuContextMenuStrip
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, True)
                If Use_Record_State = USE_STATE Then
                    If dgvFinder.SelectedRows.Count > 0 Then
                        intUserId = dgvFinder.SelectedRows(0).Cells(0).Value
                        MemberActiveFl = dgvFinder.SelectedRows(0).Cells(7).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colSystemUser = New Collection
        With colSystemUser
            .Add(txtFName)
            .Add(txtLName)
            .Add(cboRole)
            .Add(chkActiveFl)
        End With
        clsCommon.ClearControls(colSystemUser)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "System User Finder"

        With clsSystemUser
            dsCombo = .GetRoleNames
            clsCommon.PopulateComboBox(cboRoleId, cboRole, dsCombo, Nothing, True)
        End With

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        Set_Max_Length()
        txtFName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipSystemUser = clsCommon.SetUp_ToolTip_Finder(colButton)
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsSystemUser.MsgArrival
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
        Me.txtFName.MaxLength = 50
        Me.txtLName.MaxLength = 50
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

#Region "frmSystemUserFinder DataGridView Private Sub"

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
            Dim dgvColumnUserName = New DataGridViewTextBoxColumn
            Dim dgvColumnRoleName = New DataGridViewTextBoxColumn
            Dim dgvColumnFirstName = New DataGridViewTextBoxColumn
            Dim dgvColumnLastName = New DataGridViewTextBoxColumn
            Dim dgvColumnJobDescription = New DataGridViewTextBoxColumn
            Dim dgvColumnActiveFl = New DataGridViewTextBoxColumn
            Dim dgvColumnMemberActiveFl = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "userId"
                .ToolTipText = "User Id"
                .HeaderText = "User Id"
                .Width = 0
            End With

            With dgvColumnUserName
                .Visible = True
                .DataPropertyName = "userName"
                .ToolTipText = "User Name"
                .HeaderText = "USER NAME"
                .Width = 200
            End With

            With dgvColumnRoleName
                .Visible = True
                .DataPropertyName = "roleName"
                .ToolTipText = "Role Name"
                .HeaderText = "ROLE NAME"
                .Width = 200
            End With

            With dgvColumnFirstName
                .Visible = True
                .DataPropertyName = "firstName"
                .ToolTipText = "First Name"
                .HeaderText = "FIRST NAME"
                .Width = 200
            End With

            With dgvColumnLastName
                .Visible = True
                .DataPropertyName = "lastName"
                .ToolTipText = "Last Name"
                .HeaderText = "LAST NAME"
                .Width = 200
            End With

            With dgvColumnJobDescription
                .Visible = True
                .DataPropertyName = "jobDescription"
                .ToolTipText = "Job Description / Position"
                .HeaderText = "JOB DESCRIPTION / POSITION"
                .Width = 300
            End With

            With dgvColumnActiveFl
                .Visible = False
                .DataPropertyName = "activeFl"
                .ToolTipText = "Active?"
                .HeaderText = "ACTIVE?"
                .Width = 0
            End With

            With dgvColumnMemberActiveFl
                .Visible = False
                .DataPropertyName = "memberActiveFl"
                .ToolTipText = "Member Active?"
                .HeaderText = "MEMBER ACTIVE?"
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
            .Columns.Add(dgvColumnUserName)
            .Columns.Add(dgvColumnRoleName)
            .Columns.Add(dgvColumnFirstName)
            .Columns.Add(dgvColumnLastName)
            .Columns.Add(dgvColumnJobDescription)
            .Columns.Add(dgvColumnActiveFl)
            .Columns.Add(dgvColumnMemberActiveFl)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intUserId = dgvFinder.SelectedRows(0).Cells(0).Value
            MemberActiveFl = dgvFinder.SelectedRows(0).Cells(7).Value
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

#Region "frmSystemUserFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class