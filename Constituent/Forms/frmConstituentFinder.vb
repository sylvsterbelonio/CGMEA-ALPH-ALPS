Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmConstituentFinder
    Inherits System.Windows.Forms.Form

#Region "frmConstituentFinder Variable Declaration"

    Private colConstituent As New Collection
    Private colButton As New Collection
    Private tooltipConstituent As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Private start As DateTime
    Private span As TimeSpan

    Public frmMainUser As Form
    Private WithEvents clsConstituent As New Constituents.Constituents
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private intConstituentId As Integer
    Private ConstituentLastName As String
    Private ConstituentFirstName As String
    Private ConstituentMiddleName As String

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String, ByVal Record_Desc As String)

#End Region

#Region "frmConstituentFinder Public Property Variable Declaration"

    Public Property Constituent_Id() As Integer
        Get
            Return intConstituentId
        End Get
        Set(ByVal value As Integer)
            If intConstituentId = value Then
                Return
            End If
            intConstituentId = value
        End Set
    End Property

#End Region

#Region "frmConstituentFinder Form Sub"

    Private Sub frmConstituentFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        get_all_records()
        Initialize_All()
        Me.Cursor = Arrow
        onload_search = True
        Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, True, True, Add_Permission)
    End Sub

    Private Sub frmConstituentFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

    Private Sub frmConstituentFinder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtFirstName.KeyPress, txtLastName.KeyPress, dgvFinder.KeyPress, cboConstituentType.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyChar.GetHashCode = 851981 Then
            Me.Cursor = WaitCursor
            ini_page = 1
            Search_Crit_Count()
            Search_Crit()
            Me.Cursor = Arrow
        End If
    End Sub

#End Region

#Region "frmConstituentFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        ini_page = 1
        If onload_search Then Search_Crit_Count()
        If onload_search Then Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtFirstName.Focus()
        intConstituentId = 0
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
                    Dim NwfrmConstituent As New frmConstituent
                    frmTitle = "Constituent"

                    If Use_Record_State = USE_STATE Then
                        NwfrmConstituent = New frmConstituent
                        With NwfrmConstituent
                            .ClearImage()
                            .State = Current_State
                            .blnUseFinder = True
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .ShowDialog()
                        End With
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmConstituent = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmConstituent.Activate()
                        Else
                            NwfrmConstituent = New frmConstituent
                            With NwfrmConstituent
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
                    clsConstituent.Init_Flag = intConstituentId
                    If clsConstituent.Selected_Record() Then
                        Dim NwfrmConstituent As frmConstituent
                        frmTitle = "Constituent - " & IIf(LCase(clsConstituent._constituentType) = "individual", clsConstituent.last_Name & IIf(Len(clsConstituent.suffix_Name) > 0, " " & clsConstituent.suffix_Name, "") & ", " & clsConstituent.first_Name & IIf(Len(clsConstituent.middle_Name) > 0, " " & clsConstituent.middle_Name, ""), clsConstituent.first_Name)

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmConstituent = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmConstituent.Activate()
                        Else
                            NwfrmConstituent = New frmConstituent
                            With NwfrmConstituent
                                .State = Current_State
                                .RecordId = intConstituentId
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
                        RaiseEvent Use_Clicked(intConstituentId, ConstituentLastName, ConstituentFirstName, ConstituentMiddleName)
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

        With clsConstituent
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritFirst_Name = ""
            .CritLast_Name = ""
            .CritConstituent_Type = ""

            start = DateTime.Now

            Dim test_ini_page As Long = ini_page - 1
            If test_ini_page < 0 Then test_ini_page = 0
            .page_no = test_ini_page
            .limiter = Val(cboLimiter.Text)

            dtable = .Search_Record()
            span = DateTime.Now - start

            With dgvFinder
                .Refresh()
                .DataSource = dtable
                dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission)
            End With

            Me.Refresh()
        End With
    End Sub

    Private Sub Search_Crit()
        Dim dtable As DataTable = Nothing

        With clsConstituent
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritFirst_Name = Trim(Me.txtFirstName.Text)
            .CritLast_Name = Trim(Me.txtLastName.Text)
            .CritConstituent_Type = Trim(cboConstituentType.Text)

            start = DateTime.Now
            dtable = .Search_Record()
            span = DateTime.Now - start

            Dim test_ini_page As Long = ini_page - 1
            If test_ini_page < 0 Then test_ini_page = 0
            .page_no = test_ini_page

            .limiter = Val(cboLimiter.Text)

            dgvFinder.Refresh()
            dgvFinder.DataSource = dtable
            dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"

            If dtable.Rows.Count > 0 Then
                dgvFinder.Rows(0).Selected = True
                dgvFinder.ContextMenuStrip = mnuContextMenuStrip
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, True, True, Add_Permission)
                If Use_Record_State = USE_STATE Then
                    If dgvFinder.SelectedRows.Count > 0 Then
                        intConstituentId = dgvFinder.SelectedRows(0).Cells(0).Value
                        ConstituentLastName = dgvFinder.SelectedRows(0).Cells(4).Value
                        ConstituentFirstName = dgvFinder.SelectedRows(0).Cells(2).Value
                        ConstituentMiddleName = dgvFinder.SelectedRows(0).Cells(3).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colConstituent = New Collection
        With colConstituent
            .Add(txtFirstName)
            .Add(txtLastName)
        End With
        cboConstituentType.Text = ""
        clsCommon.ClearControls(colConstituent)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Constituent Finder"

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
        Me.tooltipConstituent = clsCommon.SetUp_ToolTip_Finder(colButton)
        Create_Context_Menu()
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsConstituent.MsgArrival
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
        Me.txtLastName.MaxLength = 45
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

#Region "frmConstituentFinder DataGridView Private Sub"

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
            Dim dgvColumnConstituentType = New DataGridViewTextBoxColumn
            Dim dgvColumnFirstName = New DataGridViewTextBoxColumn
            Dim dgvColumnMiddleName = New DataGridViewTextBoxColumn
            Dim dgvColumnLastName = New DataGridViewTextBoxColumn
            Dim dgvColumnSuffixName = New DataGridViewTextBoxColumn
            Dim dgvColumnBirthDate = New DataGridViewTextBoxColumn
            Dim dgvColumnGender = New DataGridViewTextBoxColumn
            Dim dgvColumnStatus = New DataGridViewTextBoxColumn
            Dim dgvColumnFlag = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "constituentId"
                .ToolTipText = "Constituent Id"
                .HeaderText = "Constituent Id"
                .Width = 0
            End With

            With dgvColumnConstituentType
                .Visible = True
                .DataPropertyName = "constituentType"
                .ToolTipText = "Constituent Type"
                .HeaderText = "CONSTITUENT TYPE"
                .Width = 140
            End With

            With dgvColumnFirstName
                .Visible = True
                .DataPropertyName = "firstName"
                .ToolTipText = "First Name"
                .HeaderText = "FIRST NAME"
                .Width = 140
            End With

            With dgvColumnMiddleName
                .Visible = True
                .DataPropertyName = "middleName"
                .ToolTipText = "Middle Name"
                .HeaderText = "MIDDLE NAME"
                .Width = 120
            End With

            With dgvColumnLastName
                .Visible = True
                .DataPropertyName = "lastName"
                .ToolTipText = "Last Name"
                .HeaderText = "LAST NAME"
                .Width = 140
            End With

            With dgvColumnSuffixName
                .Visible = True
                .DataPropertyName = "suffixName"
                .ToolTipText = "Suffix"
                .HeaderText = "SUFFIX"
                .Width = 100
            End With

            With dgvColumnBirthDate
                .Visible = True
                .DataPropertyName = "birthDate"
                .ToolTipText = "Birth Date"
                .HeaderText = "BIRTH DATE"
                .Width = 200
            End With

            With dgvColumnGender
                .Visible = True
                .DataPropertyName = "constituentGender"
                .ToolTipText = "Gender"
                .HeaderText = "GENDER"
                .Width = 150
            End With

            With dgvColumnStatus
                .Visible = True
                .DataPropertyName = "civilStatus"
                .ToolTipText = "Civil Status"
                .HeaderText = "CIVIL STATUS"
                .Width = 150
            End With

            With dgvColumnFlag
                .Visible = False
                .DataPropertyName = "activeFl"
                .ToolTipText = "Active?"
                .HeaderText = "ACTIVE?"
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
            .Columns.Add(dgvColumnConstituentType)
            .Columns.Add(dgvColumnFirstName)
            .Columns.Add(dgvColumnMiddleName)
            .Columns.Add(dgvColumnLastName)
            .Columns.Add(dgvColumnSuffixName)
            .Columns.Add(dgvColumnBirthDate)
            .Columns.Add(dgvColumnGender)
            .Columns.Add(dgvColumnStatus)
            .Columns.Add(dgvColumnFlag)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intConstituentId = dgvFinder.SelectedRows(0).Cells(0).Value
            ConstituentLastName = dgvFinder.SelectedRows(0).Cells(4).Value
            ConstituentFirstName = dgvFinder.SelectedRows(0).Cells(2).Value
            ConstituentMiddleName = dgvFinder.SelectedRows(0).Cells(3).Value
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

#Region "frmConstituentFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region


#Region "Edited by: Sylvster R. Belonio - I added new events to have search tools here:"

    Dim max_page As Long
    Dim ini_page As Long
    Dim max_record As Long
    Dim start_record As Long
    Dim end_record As Long
    Dim onload_cbo As Boolean = False
    Dim onload_search As Boolean = False

    Private Sub txtPageNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPageNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            ini_page = txtPageNo.Text
            reload_page_events()
        End If
    End Sub

    Private Sub txtPageNo_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPageNo.MouseClick
        txtPageNo.SelectionStart = 0
        txtPageNo.SelectionLength = Len(txtPageNo.Text)
    End Sub

    Private Sub txtPageNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPageNo.TextChanged
        If IsNumeric(txtPageNo.Text) Then
            If Val(txtPageNo.Text) > max_page Then
                txtPageNo.Text = max_page.ToString
                ini_page = txtPageNo.Text
            End If
        Else
            txtPageNo.Text = "1"
            ini_page = 1
        End If
    End Sub

    Private Sub picNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picNext.Click
        Me.Cursor = WaitCursor
        ini_page += 1
        If ini_page >= max_page Then
            ini_page = max_page
            picLast.Image = My.Resources.page_last_disabled
            picLast.Enabled = False
            picNext.Image = My.Resources.page_next_disabled
            picNext.Enabled = False
        End If

        picFirst.Image = My.Resources.page_first
        picFirst.Enabled = True
        picPrev.Image = My.Resources.page_prev
        picPrev.Enabled = True

        txtPageNo.Text = ini_page.ToString
        reload_page_events()
        Me.Cursor = Arrow
    End Sub

    Private Sub picLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picLast.Click
        Me.Cursor = WaitCursor
        ini_page = max_page
        picLast.Image = My.Resources.page_last_disabled
        picLast.Enabled = False
        picNext.Image = My.Resources.page_next_disabled
        picNext.Enabled = False

        picFirst.Image = My.Resources.page_first
        picFirst.Enabled = True
        picPrev.Image = My.Resources.page_prev
        picPrev.Enabled = True
        txtPageNo.Text = ini_page.ToString
        reload_page_events()
        Me.Cursor = Arrow
    End Sub

    Private Sub picPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPrev.Click
        Me.Cursor = WaitCursor
        ini_page -= 1
        If ini_page <= 1 Then
            picFirst.Image = My.Resources.page_first_disabled
            picFirst.Enabled = False
            picPrev.Image = My.Resources.page_prev_disabled
            picPrev.Enabled = False
        End If

        picLast.Image = My.Resources.page_last
        picLast.Enabled = True
        picNext.Image = My.Resources.page_next
        picNext.Enabled = True

        txtPageNo.Text = ini_page.ToString
        reload_page_events()
        Me.Cursor = Arrow
    End Sub

    Private Sub picFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picFirst.Click
        Me.Cursor = WaitCursor
        ini_page = 1
        picFirst.Image = My.Resources.page_first_disabled
        picFirst.Enabled = False
        picPrev.Image = My.Resources.page_prev_disabled
        picPrev.Enabled = False

        picLast.Image = My.Resources.page_last
        picLast.Enabled = True
        picNext.Image = My.Resources.page_next
        picNext.Enabled = True

        txtPageNo.Text = ini_page.ToString
        reload_page_events()
        Me.Cursor = Arrow
    End Sub

    Private Sub cboLimiter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLimiter.SelectedIndexChanged

        If onload_cbo Then
            Me.Cursor = WaitCursor
            ini_page = 1
            Search_Crit_Count()
            Search_Crit()
            Me.Cursor = Arrow
        End If
    End Sub

    Public Sub MouseMoves(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'this is how to make a dynamic hover event'
        '''''''''''''''''''''''''''''''''''''''''''
        If TypeOf sender Is PictureBox Then
            CType(sender, PictureBox).BackColor = Orange
            CType(sender, PictureBox).Cursor = Cursors.Hand
            ' many more functions customize
        End If
    End Sub

    Public Sub MouseLeaves(ByVal sender As Object, ByVal e As System.EventArgs)
        'this is how to make a dynamic hover event'
        '''''''''''''''''''''''''''''''''''''''''''
        If TypeOf sender Is PictureBox Then
            CType(sender, PictureBox).BackColor = Azure
            ' many more functions customize
        End If
    End Sub

    Private Sub get_all_records()
        AddHandler picFirst.MouseMove, AddressOf MouseMoves
        AddHandler picFirst.MouseLeave, AddressOf MouseLeaves
        AddHandler picPrev.MouseMove, AddressOf MouseMoves
        AddHandler picPrev.MouseLeave, AddressOf MouseLeaves
        AddHandler picNext.MouseMove, AddressOf MouseMoves
        AddHandler picNext.MouseLeave, AddressOf MouseLeaves
        AddHandler picLast.MouseMove, AddressOf MouseMoves
        AddHandler picLast.MouseLeave, AddressOf MouseLeaves


        Try
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            cboLimiter.SelectedIndex = 0
            onload_cbo = True
            With clsDataAccess
                Dim mydata As DataTable = New DataTable

                strSql = "select count(*) from tblconstituent WHERE 1 = 1 AND activefl=1 AND constituentId > 0 "
                mydata = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                max_record = mydata.Rows(0).Item(0)

                max_page = max_record / cboLimiter.Text
                If max_page = 0 Then max_page = 1
                ini_page = 1

                Dim test As Long = max_record - (max_page * cboLimiter.Text)
                If test > 0 Then max_page += 1


                txtPageNo.Text = ini_page.ToString
                lblTotalPage.Text = "/ " + max_page.ToString("#,#")
                start_record = (Val(cboLimiter.Text) * ini_page) - cboLimiter.Text
                If start_record <= 0 Then start_record = 1




                lblRemarks.Text = "View " + start_record.ToString("#,#") + " of " + max_record.ToString("#,#")

                picFirst.Image = My.Resources.page_first_disabled
                picFirst.Enabled = False
                picPrev.Image = My.Resources.page_prev_disabled
                picPrev.Enabled = False

                picLast.Image = My.Resources.page_last
                picLast.Enabled = True
                picNext.Image = My.Resources.page_next
                picNext.Enabled = True

                If ini_page = max_page Then
                    picFirst.Image = My.Resources.page_first_disabled
                    picFirst.Enabled = False
                    picPrev.Image = My.Resources.page_prev_disabled
                    picPrev.Enabled = False

                    picLast.Image = My.Resources.page_first_disabled
                    picLast.Enabled = False
                    picNext.Image = My.Resources.page_next_disabled
                    picNext.Enabled = False
                End If

            End With
        Catch ex As Exception
        End Try


    End Sub

    Private Sub Search_Crit_Count()
        Try
            Dim dtable As DataTable = Nothing

            With clsConstituent
                .Dt_gRID = dtable
                dtable = New DataTable
                .Init_Flag = 1
                .CritFirst_Name = Trim(Me.txtFirstName.Text)
                .CritLast_Name = Trim(Me.txtLastName.Text)
                .CritConstituent_Type = Trim(cboConstituentType.Text)

                start = DateTime.Now
                dtable = .Search_Record()
                span = DateTime.Now - start

                Dim test_ini_page As Long = ini_page - 1
                If test_ini_page < 0 Then test_ini_page = 0
                .page_no = test_ini_page

                .limiter = Val(cboLimiter.Text)

                dgvFinder.Refresh()
                dgvFinder.DataSource = dtable
                dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"

                dtable = .Search_Record_Count()

                If IsNumeric(dtable.Rows(0).Item(0)) Then
                    max_record = dtable.Rows(0).Item(0)
                Else
                    max_record = 1
                End If

                Dim max_page_float As Long = max_record / cboLimiter.Text
                Dim max_ As Long = max_record
                'max_page = max_record / Val(cboLimiter.Text)

                If max_page_float <= 0 Then max_page_float = 1
                max_page = max_page_float

                Dim test As Long = max_record - (max_page * cboLimiter.Text)
                If test > 0 Then max_page += 1

                txtPageNo.Text = ini_page.ToString
                lblTotalPage.Text = "/ " + max_page.ToString("#,#")
                start_record = (Val(cboLimiter.Text) * ini_page) - Val(cboLimiter.Text)
                If start_record <= 0 Then start_record = 1

                If max_record = 0 Then
                    lblRemarks.Text = "View " + start_record.ToString("#,#") + " of 1"
                Else
                    lblRemarks.Text = "View " + start_record.ToString("#,#") + " of " + max_record.ToString("#,#")
                End If

                picFirst.Image = My.Resources.page_first_disabled
                picFirst.Enabled = False
                picPrev.Image = My.Resources.page_prev_disabled
                picPrev.Enabled = False

                picLast.Image = My.Resources.page_last
                picLast.Enabled = True
                picNext.Image = My.Resources.page_next
                picNext.Enabled = True

                If ini_page = max_page Then
                    picFirst.Image = My.Resources.page_first_disabled
                    picFirst.Enabled = False
                    picPrev.Image = My.Resources.page_prev_disabled
                    picPrev.Enabled = False

                    picLast.Image = My.Resources.page_first_disabled
                    picLast.Enabled = False
                    picNext.Image = My.Resources.page_next_disabled
                    picNext.Enabled = False
                End If
            End With

        Catch ex As Exception

        End Try

    End Sub



    Private Sub reload_page_events()
        Try
            Dim dtable As DataTable = Nothing

            With clsConstituent
                .Dt_gRID = dtable
                dtable = New DataTable
                .Init_Flag = 1
                .CritFirst_Name = Trim(Me.txtFirstName.Text)
                .CritLast_Name = Trim(Me.txtLastName.Text)
                .CritConstituent_Type = Trim(cboConstituentType.Text)

                If ini_page = 1 Then
                    .page_no = 0
                Else
                    .page_no = (Val(cboLimiter.Text) * ini_page) - Val(cboLimiter.Text)
                End If

                .limiter = Val(cboLimiter.Text)

                start = DateTime.Now
                dtable = .Search_Record()
                span = DateTime.Now - start

                dgvFinder.Refresh()
                dgvFinder.DataSource = dtable
                dgvHeader.Text = dtable.Rows.Count & " Record(s) found. (" & span.TotalSeconds.ToString & "s)"

                If dtable.Rows.Count > 0 Then
                    dgvFinder.Rows(0).Selected = True
                    dgvFinder.ContextMenuStrip = mnuContextMenuStrip
                    Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, True, True, Add_Permission)
                    If Use_Record_State = USE_STATE Then
                        If dgvFinder.SelectedRows.Count > 0 Then
                            intConstituentId = dgvFinder.SelectedRows(0).Cells(0).Value
                            ConstituentLastName = dgvFinder.SelectedRows(0).Cells(4).Value
                            ConstituentFirstName = dgvFinder.SelectedRows(0).Cells(2).Value
                            ConstituentMiddleName = dgvFinder.SelectedRows(0).Cells(3).Value
                        End If
                    End If
                Else
                    dgvFinder.ContextMenuStrip = Nothing
                    Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False, True, Add_Permission)
                End If

            End With

            txtPageNo.Text = ini_page.ToString
            lblTotalPage.Text = "/ " + max_page.ToString("#,#")
            start_record = (Val(cboLimiter.Text) * ini_page) - Val(cboLimiter.Text)
            If start_record <= 0 Then start_record = 1

            lblRemarks.Text = "View " + start_record.ToString("#,#") + " of " + max_record.ToString("#,#")

            If ini_page = max_page And ini_page = 1 Then
                picFirst.Image = My.Resources.page_first_disabled
                picFirst.Enabled = False
                picPrev.Image = My.Resources.page_prev_disabled
                picPrev.Enabled = False

                picLast.Image = My.Resources.page_first_disabled
                picLast.Enabled = False
                picNext.Image = My.Resources.page_next_disabled
                picNext.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub


#End Region




    Private Sub dgvFinder_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFinder.CellContentClick

    End Sub
End Class