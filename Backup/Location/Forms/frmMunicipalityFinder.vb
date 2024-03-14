Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmMunicipalityFinder
    Inherits System.Windows.Forms.Form

#Region "frmMunicipalityFinder Variable Declaration"

    Private colMunicipality As New Collection
    Private colButton As New Collection
    Private tooltipMunicipality As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Public frmMainUser As Form
    Private start As DateTime
    Private span As TimeSpan

    Private intMunicipalityID As Integer
    Private MunicipalityName As String
    Private MunicipalityCode As String

    Private WithEvents clsMunicipality As New Municipality.Municipality
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String)

#End Region

    Public Property Municipality_ID() As Integer
        Get
            Return intMunicipalityID
        End Get
        Set(ByVal value As Integer)
            If intMunicipalityID = value Then
                Return
            End If
            intMunicipalityID = value
        End Set
    End Property

#Region "frmMunicipalityFinder Form Sub"

    Private Sub frmMunicipalityFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMunicipalityFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

#End Region

#Region "frmMunicipalityFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtMunicipalityName.Focus()
        intMunicipalityID = 0
    End Sub

    Private Sub txtMunicipalityName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMunicipalityName.KeyPress, txtProvinceName.KeyPress, chkCityFl.KeyPress, txtRegionName.KeyPress
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
                    Dim NwfrmMunicipality As New frmMunicipality

                    frmTitle = "City / Municipality"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmMunicipality = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmMunicipality.Activate()
                    Else
                        NwfrmMunicipality = New frmMunicipality
                        With NwfrmMunicipality
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
                    clsMunicipality.Init_Flag = intMunicipalityID
                    If clsMunicipality.Selected_Record() Then
                        Dim NwfrmMunicipality As frmMunicipality
                        frmTitle = "City / Municipality - " & clsMunicipality.Municipality_Name

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmMunicipality = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmMunicipality.Activate()
                        Else
                            NwfrmMunicipality = New frmMunicipality
                            With NwfrmMunicipality
                                .State = Current_State
                                .RecordId = intMunicipalityID
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&use"
Use_Rec:
                    With frmMainUser
                        RaiseEvent Use_Clicked(intMunicipalityID, MunicipalityName, MunicipalityCode)
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

        With clsMunicipality
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            .CritRegion_Name = ""
            .CritProvince_Name = ""
            .CritMunicipality_Name = ""
            .CritCity_Fl = 0

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

        With clsMunicipality
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritRegion_Name = Trim(Me.txtRegionName.Text)
            .CritProvince_Name = Trim(Me.txtProvinceName.Text)
            .CritMunicipality_Name = Trim(Me.txtMunicipalityName.Text)
            If chkCityFl.Checked Then
                .CritCity_Fl = 1
            Else
                .CritCity_Fl = 0
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
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, True)
                If Use_Record_State = USE_STATE Then
                    If dgvFinder.SelectedRows.Count > 0 Then
                        intMunicipalityID = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
                        MunicipalityName = dgvFinder.SelectedRows(0).Cells(6).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
                        MunicipalityCode = dgvFinder.SelectedRows(0).Cells(5).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colMunicipality = New Collection
        With colMunicipality
            .Add(txtRegionName)
            .Add(txtMunicipalityName)
            .Add(txtProvinceName)
            .Add(chkCityFl)
        End With
        clsCommon.ClearControls(colMunicipality)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "City / Municipality Finder"

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        txtMunicipalityName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipMunicipality = clsCommon.SetUp_ToolTip_Finder(colButton)
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsMunicipality.MsgArrival, clsCommon.MsgArrival
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

#Region "frmMunicipalityFinder DataGridView Private Sub"

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
            Dim dgvColumnMCode = New DataGridViewTextBoxColumn
            Dim dgvColumnMunicipalName = New DataGridViewTextBoxColumn
            Dim dgvColumnCityFl = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "municipalityId"
                .ToolTipText = "City / Municipality Id"
                .HeaderText = "CITY / MUNICIPALITY ID"
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

            With dgvColumnMCode
                .Visible = True
                .DataPropertyName = "mCode"
                .ToolTipText = "City / Municipality Code"
                .HeaderText = "CITY / MUNICIPALITY CODE"
                .Width = 150
            End With

            With dgvColumnMunicipalName
                .Visible = True
                .DataPropertyName = "municipalityName"
                .ToolTipText = "City / Municipality Name"
                .HeaderText = "CITY / MUNICIPALITY NAME"
                .Width = 300
            End With

            With dgvColumnCityFl
                .Visible = True
                .DataPropertyName = "cityFl"
                .ToolTipText = "City?"
                .HeaderText = "CITY?"
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
            .Columns.Add(dgvColumnMCode)
            .Columns.Add(dgvColumnMunicipalName)
            .Columns.Add(dgvColumnCityFl)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intMunicipalityID = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
            MunicipalityName = dgvFinder.SelectedRows(0).Cells(6).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
            MunicipalityCode = dgvFinder.SelectedRows(0).Cells(5).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
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

#Region "frmMunicipalityFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class