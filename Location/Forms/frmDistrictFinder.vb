Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmDistrictFinder
    Inherits System.Windows.Forms.Form

#Region "frmDistrictFinder Variable Declaration"

    Private colDistrict As New Collection
    Private colButton As New Collection
    Private tooltipDistrict As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Public frmMainUser As Form
    Private start As DateTime
    Private span As TimeSpan

    Private intDistrictID As Integer
    Private DistrictName As String
    Private DistrictCode As String

    Private WithEvents clsDistrict As New District.District
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String)

#End Region

    Public Property District_ID() As Integer
        Get
            Return intDistrictID
        End Get
        Set(ByVal value As Integer)
            If intDistrictID = value Then
                Return
            End If
            intDistrictID = value
        End Set
    End Property

#Region "frmDistrictFinder Form Sub"

    Private Sub frmDistrictFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmDistrictFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

#End Region

#Region "frmDistrictFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtDistrictName.Focus()
        intDistrictID = 0
    End Sub

    Private Sub txtDistrictName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDistrictName.KeyPress, txtProvinceName.KeyPress, txtDistrict.KeyPress, txtRegionName.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If e.KeyChar.GetHashCode = 851981 Then
            Me.Cursor = WaitCursor
            Search_Crit()
            Me.Cursor = Arrow
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
                    Dim NwfrmDistrict As New frmDistrict

                    frmTitle = "District"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmDistrict = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmDistrict.Activate()
                    Else
                        NwfrmDistrict = New frmDistrict
                        With NwfrmDistrict
                            .State = Current_State
                            .RecordId = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                Case "&view", "&edit"
                    If LCase(btnObject.Name) = "btnview" Then
View_Rec:
                        Current_State = VIEW_STATE
                    Else
Edit_Rec:
                        Current_State = EDIT_STATE
                    End If
                    clsDistrict.Init_Flag = intDistrictID
                    If clsDistrict.Selected_Record() Then
                        Dim NwfrmDistrict As frmDistrict
                        frmTitle = "District - " & clsDistrict.District_Name

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmDistrict = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmDistrict.Activate()
                        Else
                            NwfrmDistrict = New frmDistrict
                            With NwfrmDistrict
                                .State = Current_State
                                .RecordId = intDistrictID
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&use"
Use_Rec:
                    With frmMainUser
                        RaiseEvent Use_Clicked(intDistrictID, DistrictName, DistrictCode)
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
                        GoTo View_Rec
                    Else
                        GoTo Edit_Rec
                    End If
            End Select
        ElseIf TypeOf (sender) Is DataGridView Then
            If Use_Record_State <> USE_STATE Then
                Current_State = VIEW_STATE
                btnView.PerformClick()
            Else
            End If
        End If
    End Sub

    Private Sub Initialize_Grid()
        Dim dtable As DataTable = Nothing

        With clsDistrict
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            .CritRegion_Name = ""
            .CritProvince_Name = ""
            .CritDistrict_Name = ""
            .Crit_District = ""

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

        With clsDistrict
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritRegion_Name = Trim(Me.txtRegionName.Text)
            .CritProvince_Name = Trim(Me.txtProvinceName.Text)
            .CritDistrict_Name = Trim(Me.txtDistrictName.Text)
            .Crit_District = Trim(Me.txtDistrict.Text)

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
                        intDistrictID = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
                        DistrictName = dgvFinder.SelectedRows(0).Cells(6).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
                        DistrictCode = dgvFinder.SelectedRows(0).Cells(5).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colDistrict = New Collection
        With colDistrict
            .Add(txtRegionName)
            .Add(txtDistrictName)
            .Add(txtProvinceName)
            .Add(txtDistrict)
        End With
        clsCommon.ClearControls(colDistrict)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "District Finder"

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        txtDistrictName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipDistrict = clsCommon.SetUp_ToolTip_Finder(colButton)
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsDistrict.MsgArrival, clsCommon.MsgArrival
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

#Region "frmDistrictFinder DataGridView Private Sub"

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
            Dim dgvColumnRCode = New DataGridViewTextBoxColumn
            Dim dgvColumnRegionName = New DataGridViewTextBoxColumn
            Dim dgvColumnPCode = New DataGridViewTextBoxColumn
            Dim dgvColumnProvinceName = New DataGridViewTextBoxColumn
            Dim dgvColumnDCode = New DataGridViewTextBoxColumn
            Dim dgvColumnDistrictName = New DataGridViewTextBoxColumn
            Dim dgvColumnDistrict = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "districtId"
                .ToolTipText = "District Id"
                .HeaderText = "DISTRICT ID"
                .Width = 0
            End With

            With dgvColumnRCode
                .Visible = True
                .DataPropertyName = "rCode"
                .ToolTipText = "Region Code"
                .HeaderText = "REGION CODE"
                .Width = 150
            End With

            With dgvColumnRegionName
                .Visible = True
                .DataPropertyName = "regionName"
                .ToolTipText = "Region Name"
                .HeaderText = "REGION NAME"
                .Width = 250
            End With

            With dgvColumnPCode
                .Visible = True
                .DataPropertyName = "pCode"
                .ToolTipText = "Province Code"
                .HeaderText = "PROVINCE CODE"
                .Width = 150
            End With

            With dgvColumnProvinceName
                .Visible = True
                .DataPropertyName = "provinceName"
                .ToolTipText = "Province Name"
                .HeaderText = "PROVINCE NAME"
                .Width = 300
            End With

            With dgvColumnDCode
                .Visible = True
                .DataPropertyName = "dCode"
                .ToolTipText = "District Code"
                .HeaderText = "DISTRICT CODE"
                .Width = 150
            End With

            With dgvColumnDistrictName
                .Visible = True
                .DataPropertyName = "districtName"
                .ToolTipText = "District Name"
                .HeaderText = "DISTRICT NAME"
                .Width = 300
            End With

            With dgvColumnDistrict
                .Visible = True
                .DataPropertyName = "district"
                .ToolTipText = "District"
                .HeaderText = "DISTRICT"
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
            .Columns.Add(dgvColumnRCode)
            .Columns.Add(dgvColumnRegionName)
            .Columns.Add(dgvColumnPCode)
            .Columns.Add(dgvColumnProvinceName)
            .Columns.Add(dgvColumnDCode)
            .Columns.Add(dgvColumnDistrictName)
            .Columns.Add(dgvColumnDistrict)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intDistrictID = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
            DistrictName = dgvFinder.SelectedRows(0).Cells(6).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
            DistrictCode = dgvFinder.SelectedRows(0).Cells(5).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
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

#Region "frmDistrictFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class