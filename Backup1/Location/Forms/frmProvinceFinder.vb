Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmProvinceFinder
    Inherits System.Windows.Forms.Form

#Region "frmProvinceFinder Variable Declaration"

    Private colProvince As New Collection
    Private colButton As New Collection
    Private tooltipProvince As New ToolTip
    Private mnuContextMenuStrip As New ContextMenuStrip
    Public frmMainUser As Form
    Private start As DateTime
    Private span As TimeSpan

    Private intProvinceID As Integer
    Private ProvinceName As String
    Private ProvinceCode As String

    Private WithEvents clsProvince As New Province.Province
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Public Event Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Desc As String)

#End Region

    Public Property Province_ID() As Integer
        Get
            Return intProvinceID
        End Get
        Set(ByVal value As Integer)
            If intProvinceID = value Then
                Return
            End If
            intProvinceID = value
        End Set
    End Property

#Region "frmProvinceFinder Form Sub"

    Private Sub frmProvinceFinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_All()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmProvinceFinder_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Use_Record_State = USE_STATE Then
            btnEdit.PerformClick()
        End If
    End Sub

#End Region

#Region "frmProvinceFinder User Defined Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Me.Cursor = WaitCursor
        Search_Crit()
        Me.Cursor = Arrow
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If ActiveControl.Name <> CType(sender, Button).Name And Control.ModifierKeys <> Keys.Alt Then Exit Sub
        Clear_All_Controls()
        Me.txtProvinceName.Focus()
        intProvinceID = 0
    End Sub

    Private Sub txtProvinceName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProvinceName.KeyPress, txtProvinceCode.KeyPress, chkProvinceFl.KeyPress, txtRegionName.KeyPress
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
                    Dim NwfrmProvince As New frmProvince

                    frmTitle = "Province"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmProvince = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmProvince.Activate()
                    Else
                        NwfrmProvince = New frmProvince
                        With NwfrmProvince
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
                    clsProvince.Init_Flag = intProvinceID
                    If clsProvince.Selected_Record() Then
                        Dim NwfrmProvince As frmProvince
                        frmTitle = "Province - " & clsProvince.Province_Name

                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmProvince = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmProvince.Activate()
                        Else
                            NwfrmProvince = New frmProvince
                            With NwfrmProvince
                                .State = Current_State
                                .RecordId = intProvinceID
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                Case "&use"
Use_Rec:
                    With frmMainUser
                        RaiseEvent Use_Clicked(intProvinceID, ProvinceName, ProvinceCode)
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

        With clsProvince
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 0
            .CritRegion_Name = ""
            .CritProvince_Code = ""
            .CritProvince_Name = ""
            .CritProvince_Fl = 0

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

        With clsProvince
            .Dt_gRID = dtable
            dtable = New DataTable
            .Init_Flag = 1
            .CritRegion_Name = Trim(Me.txtRegionName.Text)
            .CritProvince_Code = Trim(Me.txtProvinceCode.Text)
            .CritProvince_Name = Trim(Me.txtProvinceName.Text)
            If chkProvinceFl.Checked Then
                .CritProvince_Fl = 1
            Else
                .CritProvince_Fl = 0
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
                        intProvinceID = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
                        ProvinceName = dgvFinder.SelectedRows(0).Cells(4).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
                        ProvinceCode = dgvFinder.SelectedRows(0).Cells(3).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
                    End If
                End If
            Else
                dgvFinder.ContextMenuStrip = Nothing
                Call clsCommon.EnableDisableFinderButtons(Use_Record_State, btnView, btnAdd, btnEdit, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission, False)
            End If

        End With
    End Sub

    Private Sub Clear_All_Controls()
        colProvince = New Collection
        With colProvince
            .Add(txtRegionName)
            .Add(txtProvinceName)
            .Add(txtProvinceCode)
            .Add(chkProvinceFl)
        End With
        clsCommon.ClearControls(colProvince)
    End Sub

    Private Sub Initialize_All()
        Me.Text = "Province Finder"

        SetUp_Collection()
        dgvFinder_Initialize()
        Initialize_Grid()
        Clear_All_Controls()
        txtProvinceName.Focus()
        If Use_Record_State = USE_STATE Then
            SetUp_UseFinderState()
        End If
        ActiveControl = btnSearch
        btnSearch.PerformClick()
        Me.tooltipProvince = clsCommon.SetUp_ToolTip_Finder(colButton)
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

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessfl As Boolean) Handles clsProvince.MsgArrival, clsCommon.MsgArrival
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

#Region "frmProvinceFinder DataGridView Private Sub"

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
            Dim dgvColumnProvinceFl = New DataGridViewTextBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .DataPropertyName = "provinceId"
                .ToolTipText = "Province Id"
                .HeaderText = "PROVINCE ID"
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

            With dgvColumnProvinceFl
                .Visible = True
                .DataPropertyName = "provinceFl"
                .ToolTipText = "Province?"
                .HeaderText = "PROVINCE?"
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
            .Columns.Add(dgvColumnProvinceFl)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvFinder_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvFinder.SelectionChanged
        If dgvFinder.SelectedRows.Count > 0 Then
            intProvinceID = dgvFinder.SelectedRows(0).Cells(0).Value 'udgFinder.Selected.Rows(0).Cells(0).Value
            ProvinceName = dgvFinder.SelectedRows(0).Cells(4).Value 'udgFinder.Selected.Rows(0).Cells(1).Value
            ProvinceCode = dgvFinder.SelectedRows(0).Cells(3).Value 'udgFinder.Selected.Rows(0).Cells(4).Value
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

#Region "frmProvinceFinder UltraWinGrid Private Sub"

    'Private Sub udgFinder_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles udgFinder.InitializeLayout
    '    If sender Is Nothing OrElse e Is Nothing Then
    '        Return
    '    End If
    '    Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
    '    Dim s As Stream = asm.GetManifestResourceStream(asm.GetName().Name & ".WindowsXP - Green Theme.xml")
    '    Dim xdoc As New XmlDocument
    '    Dim reader As New StreamReader(s)

    '    With e.Layout.Override

    '        '   Set alpha blending values
    '        .RowAppearance.BackColorAlpha = Infragistics.Win.Alpha.Transparent

    '        'use the same appearance for alternate rows
    '        .RowAlternateAppearance = .RowAppearance
    '        .CellAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    '        .CellAppearance.AlphaLevel = 192

    '        .HeaderAppearance.AlphaLevel = 192
    '        .HeaderAppearance.BackColorAlpha = Infragistics.Win.Alpha.UseAlphaLevel
    '    End With

    '    '   Change the captions of the name columns
    '    With Me.udgFinder.DisplayLayout.Bands(0)
    '        .Columns("provinceId").Hidden = True

    '        .Columns("rCode").Hidden = True
    '        '.Columns("rCode").Header.Caption = "Region Code"
    '        '.Columns("rCode").Width = 150
    '        '.Columns("rCode").Header.ToolTipText = "This field contains region codes available."

    '        .Columns("regionName").Header.Caption = "Region Name"
    '        .Columns("regionName").Width = 250
    '        .Columns("regionName").Header.ToolTipText = "This field contains region names available."

    '        .Columns("pCode").Header.Caption = "Province Code"
    '        .Columns("pCode").Width = 150
    '        .Columns("pCode").Header.ToolTipText = "This field contains province codes available."

    '        .Columns("provinceName").Header.Caption = "Province Name"
    '        .Columns("provinceName").Width = 250
    '        .Columns("provinceName").Header.ToolTipText = "This field contains province names available."

    '        .Columns("provinceFl").Header.Caption = "Province Flag"
    '        .Columns("provinceFl").Width = 150
    '        .Columns("provinceFl").Header.ToolTipText = "This field tags records as province if applicable."

    '        .Columns("ErrorMessage").Hidden = True
    '    End With

    '    With Me.udgFinder.DisplayLayout
    '        With .Appearance
    '            .BackColor = White
    '            .BackColor2 = YellowGreen
    '            .BackGradientStyle = Infragistics.Win.GradientStyle.ForwardDiagonal
    '        End With

    '        With .CaptionAppearance
    '            .TextHAlign = Infragistics.Win.HAlign.Left
    '            .TextVAlign = Infragistics.Win.VAlign.Middle
    '        End With

    '        With .EmptyRowSettings
    '            .ShowEmptyRows = True
    '            .Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.PrefixWithEmptyCell
    '        End With

    '        .AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
    '        .InterBandSpacing = 10
    '        .RowConnectorColor = DarkKhaki
    '        .ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
    '        .ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
    '        .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
    '        .ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand

    '        With .Override
    '            .AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed
    '            .AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None
    '            .AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed
    '            .AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True
    '            .RowAlternateAppearance.BackColor = Lavender
    '            .RowSelectors = Infragistics.Win.DefaultableBoolean.True
    '            .RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.SeparateElement
    '            .RowSelectorNumberStyle = Infragistics.Win.UltraWinGrid.RowSelectorNumberStyle.ListIndex
    '            .RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed
    '            .SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single
    '            .SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None
    '            .SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None
    '        End With
    '    End With

    '    xdoc.LoadXml(reader.ReadToEnd())
    '    reader.Close()
    '    presetFile = PresetDir & "\" & Me.Name & ".xml"
    '    xdoc.Save(presetFile)

    '    If File.Exists(presetFile) Then
    '        Me.udgFinder.ApplyPresetFromXml(presetFile, False)
    '    End If
    'End Sub

    'Private Sub udgFinder_AfterSelectChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.AfterSelectChangeEventArgs) Handles udgFinder.AfterSelectChange
    '    If udgFinder.Selected.Rows.Count > 0 Then
    '        intProvinceID = udgFinder.Selected.Rows(0).Cells(0).Value
    '        ProvinceName = udgFinder.Selected.Rows(0).Cells(4).Value
    '        ProvinceCode = udgFinder.Selected.Rows(0).Cells(3).Value
    '    End If
    'End Sub

    'Private Sub udgFinder_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles udgFinder.MouseUp
    '    Try
    '        Dim aUIElement As Infragistics.Win.UIElement
    '        aUIElement = udgFinder.DisplayLayout.UIElement.ElementFromPoint(New Point(e.X, e.Y))

    '        ' declare and retrieve a reference to the Row
    '        Dim aRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '        aRow = aUIElement.GetContext(GetType(Infragistics.Win.UltraWinGrid.UltraGridRow))

    '        aRow.Selected = (Not aRow Is Nothing)
    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region

#Region "frmProvinceFinder Protected Overrides Sub"

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#End Region

End Class