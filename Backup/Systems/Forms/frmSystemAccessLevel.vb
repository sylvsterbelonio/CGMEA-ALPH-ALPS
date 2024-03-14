Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmSystemAccessLevel
    Inherits System.Windows.Forms.Form

#Region "frmSystemAccessLevel Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsSystemAccessLevel As New SystemAccessLevel.SystemAccessLevel
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private clsAccessPermission As New AccessPermission.AccessPermission

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmSystemAccessLevelFinder
    Private txtUpdateDt As New TextBox

    'declaration of Collections
    Private ColRequired As New Collection
    Private ColSystemAccessLevel As New Collection
    Private AccessPermission As New Collection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Private dtable As DataTable

    Private blnAccess As Boolean = False
    'Private Bad_Cell As Infragistics.Win.UltraWinGrid.UltraGridCell
    'Private View_Cell As Infragistics.Win.UltraWinGrid.UltraGridCell

    Private KeyPressChar As Long
#End Region

#Region "frmSystemAccessLevel Main Form Private Sub"

    Private Sub frmSystemAccessLevel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsSystemAccessLevel.Init_Flag = RecordId
            clsSystemAccessLevel.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmSystemAccessLevel_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtRoleName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmSystemAccessLevel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtRoleName.KeyPress, txtRoleDescription.KeyPress ', udgSystemAccess.KeyPress
        Dim tbArgs As ToolBarButtonClickEventArgs

        KeyPressChar = e.KeyChar.GetHashCode
        Select Case KeyPressChar
            Case 65537 ' press ctrl+a
                If Me.tbrMainForm.Buttons(0).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(0))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 327685 'press ctrl+e
                If Me.tbrMainForm.Buttons(1).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(1))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 262148 'press ctrl+d
                If Me.tbrMainForm.Buttons(2).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(2))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                    Exit Sub
                End If
            Case 393222 'press ctrl+f
                If Me.tbrMainForm.Buttons(3).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(3))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1245203 'press ctrl+s
                If Me.tbrMainForm.Buttons(4).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(4))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1769499 ' press esc
                If Me.tbrMainForm.Buttons(5).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(5))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 983055 ' press ctrl+o
                If Me.tbrMainForm.Buttons(6).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(6))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
        End Select

    End Sub

#End Region

#Region "frmSystemAccessLevel ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmSystemAccessLevel As New frmSystemAccessLevel
                    frmTitle = "System Access Level"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmSystemAccessLevel = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmSystemAccessLevel.Activate()
                    Else
                        Call clsCommon.ClearControls(ColSystemAccessLevel)
                        State = ADD_STATE
                        RecordId = 0
                        Call Set_Form_State()
                        Me.Text = "System Access Level"
                    End If
                Case 1 'edit
edit_rec:
                    If (txtRoleName.Text.Trim.ToLower = LCase("super administrator")) Then
                        clsCommon.Prompt_User("information", "System access level can not be modified for built-in system super administrator.")
                        Exit Sub
                    End If
                    State = EDIT_STATE
                    Call Set_Form_State()
                Case 2 'delete
delete_rec:
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        With clsSystemAccessLevel
                            .Role_ID = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    Dim frmFinder As frmSystemAccessLevelFinder
                    frmTitle = "System Access Level Finder"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        frmFinder.Activate()
                        frmFinder.ActiveControl = frmFinder.btnSearch
                        frmFinder.btnSearch.PerformClick()
                        frmFinder.txtRoleName.Focus()
                    Else
                        frmFinder = New frmSystemAccessLevelFinder
                        With frmFinder
                            .intRoleID = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        With clsSystemAccessLevel
                            Try
                                dtable.AcceptChanges()
                            Catch ex As Exception

                            End Try
                            .Role_ID = RecordId
                            .Role_Name = Trim(txtRoleName.Text)
                            .Role_Desc = Trim(txtRoleDescription.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            Populate_Permission_Collection()
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = .Role_ID
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "System Access Level - " & Me.txtRoleName.Text

                                If clsCommon.GetRegistrySetting("Add New Record", "Disabled") = "" Then
                                    Dim iAns
                                    iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to add another record?" & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                                    If iAns = vbYes Then
                                        GoTo add_rec
                                    ElseIf iAns = vbCancel Then
                                        clsCommon.SaveRegistrySetting("Add New Record", "Disabled", "Yes")
                                    End If
                                End If
                            Else
                                If State = EDIT_STATE Then
                                    .Init_Flag = RecordId
                                    If .Selected_Record() Then
                                        Assign_Data()
                                    End If
                                End If
                            End If
                        End With
                        Me.Cursor = Arrow
                    Else
                        Me.txtRoleName.Focus()
                    End If
                Case 5 'cancel
cancel_rec:
                    If RecordId = 0 Then
                        Me.Close()
                    Else
                        Dim iAns

                        iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
                        If iAns = vbNo Then
                            Exit Sub
                        End If

                        With clsSystemAccessLevel
                            State = VIEW_STATE
                            .Init_Flag = RecordId
                            If .Selected_Record() Then
                                Assign_Data()
                            End If
                            Set_Form_State()
                        End With
                    End If
                Case 6 'approve
approve_rec:
            End Select
            '------------------------------------------------------------------------------
        Else
            'form KeyPress
            '------------------------------------------------------------------------------
            Select Case KeyPressChar
                Case 65537 ' press ctrl+a
                    GoTo add_rec
                Case 327685 'press ctrl+e
                    GoTo edit_rec
                Case 262148 'press ctrl+d
                    GoTo delete_rec
                Case 393222 'press ctrl+f
                    GoTo find_rec
                Case 1245203 'press ctrl+s
                    GoTo save_rec
                Case 1769499 ' press esc
                    GoTo cancel_rec
                Case 983055 ' press ctrl+o
                    GoTo approve_rec
            End Select
            '------------------------------------------------------------------------------
        End If

    End Sub

#End Region

#Region "frmSystemAccessLevel DataGridView Private Sub"

    Private Sub dgvSystemAccess_Initialize()
        With dgvSystemAccess
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .BorderStyle = System.Windows.Forms.BorderStyle.None
            .ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
            .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            .Location = New System.Drawing.Point(10, 145)
            .MultiSelect = False
            .Name = "dgvFinder"
            .ReadOnly = False
            .RowHeadersWidth = 65
            .RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            .Size = New System.Drawing.Size(875, 370)
            .TabStop = False

            .EnableHeadersVisualStyles = True
            .GridColor = ColorTranslator.FromHtml("#cad5a5")
            '.RowHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cad5a5")
            '.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#cad5a5")
            .RowsDefaultCellStyle.Padding = New System.Windows.Forms.Padding(2)
            .RowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fbfbfb")
            .AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#eaebf6")

            Dim dgvColumnId = New DataGridViewTextBoxColumn
            Dim dgvColumnModuleName = New DataGridViewTextBoxColumn
            Dim dgvColumnModuleDescription = New DataGridViewTextBoxColumn
            Dim dgvColumnViewRecord = New DataGridViewCheckBoxColumn
            Dim dgvColumnAddRecord = New DataGridViewCheckBoxColumn
            Dim dgvColumnSaveRecord = New DataGridViewCheckBoxColumn
            Dim dgvColumnDeleteRecord = New DataGridViewCheckBoxColumn
            Dim dgvColumnApproveRecord = New DataGridViewCheckBoxColumn
            Dim dgvColumnMessage = New DataGridViewTextBoxColumn

            With dgvColumnId
                .Visible = False
                .ReadOnly = True
                .Name = "moduleId"
                .DataPropertyName = "moduleId"
                .ToolTipText = "1"
                .HeaderText = "Module Id"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnModuleName
                .Visible = True
                .ReadOnly = True
                .Name = "moduleName"
                .DataPropertyName = "moduleName"
                .ToolTipText = "1"
                .HeaderText = "MODULE NAME"
                .Width = 200
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnModuleDescription
                .Visible = True
                .ReadOnly = True
                .Name = "moduleDescription"
                .DataPropertyName = "moduleDescription"
                .ToolTipText = "1"
                .HeaderText = "DESCRIPTION"
                .Width = 300
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnViewRecord
                .Visible = True
                .ReadOnly = False
                .Name = "viewRecord"
                .DataPropertyName = "viewRecord"
                .ToolTipText = "0"
                .HeaderText = "VIEW"
                .Width = 55
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnAddRecord
                .Visible = True
                .ReadOnly = False
                .Name = "addRecord"
                .DataPropertyName = "addRecord"
                .ToolTipText = "0"
                .HeaderText = "ADD"
                .Width = 55
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnSaveRecord
                .Visible = True
                .ReadOnly = False
                .Name = "saveRecord"
                .DataPropertyName = "saveRecord"
                .ToolTipText = "0"
                .HeaderText = "SAVE"
                .Width = 55
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnDeleteRecord
                .Visible = True
                .ReadOnly = False
                .Name = "deleteRecord"
                .DataPropertyName = "deleteRecord"
                .ToolTipText = "0"
                .HeaderText = "DELETE"
                .Width = 55
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnApproveRecord
                .Visible = True
                .ReadOnly = False
                .Name = "approveRecord"
                .DataPropertyName = "approveRecord"
                .ToolTipText = "0"
                .HeaderText = "APPROVE"
                .Width = 65
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            With dgvColumnMessage
                .Visible = False
                .ReadOnly = True
                .Name = "ErrorMessage"
                .DataPropertyName = "ErrorMessage"
                .ToolTipText = "1"
                .HeaderText = "Error Message"
                .Width = 0
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With

            .Columns.Add(dgvColumnId)
            .Columns.Add(dgvColumnModuleName)
            .Columns.Add(dgvColumnModuleDescription)
            .Columns.Add(dgvColumnViewRecord)
            .Columns.Add(dgvColumnAddRecord)
            .Columns.Add(dgvColumnSaveRecord)
            .Columns.Add(dgvColumnDeleteRecord)
            .Columns.Add(dgvColumnApproveRecord)
            .Columns.Add(dgvColumnMessage)
        End With
    End Sub

    Private Sub dgvSystemAccess_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSystemAccess.CellValueChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Try
            Dim cell As DataGridViewCell = dgvSystemAccess.Item(e.ColumnIndex, e.RowIndex)

            If State <> VIEW_STATE Then
                If dgvSystemAccess.Item(0, e.RowIndex).Value = 0 Then
                    Select Case dgvSystemAccess.Columns(e.ColumnIndex).Name
                        Case "viewRecord", "addRecord", "saveRecord", "deleteRecord", "approveRecord"
                            If GetCellValueOrDefault(cell) = 0 Then
                                clsCommon.Prompt_User("information", "Can not remove '" & dgvSystemAccess.Columns(e.ColumnIndex).HeaderText & "' access in " & dgvSystemAccess.Rows(e.RowIndex).Cells("moduleName").Value & ". This is the default module available for all users.")
                                cell.Value = 1
                            End If
                    End Select
                Else
                    Select Case dgvSystemAccess.Columns(e.ColumnIndex).Name
                        Case "addRecord", "saveRecord", "deleteRecord", "approveRecord"
                            If GetCellValueOrDefault(dgvSystemAccess.Rows(e.RowIndex).Cells("viewRecord")) = 0 And GetCellValueOrDefault(cell) <> 0 Then
                                clsCommon.Prompt_User("information", "View permission is currently set to 'OFF'. You should first enable view permission before you can add '" & dgvSystemAccess.Columns(e.ColumnIndex).HeaderText & "' permission to current module.")
                                cell.Value = 0
                            End If
                        Case "viewRecord"
                            If GetCellValueOrDefault(cell) = 0 And (GetCellValueOrDefault(dgvSystemAccess.Rows(e.RowIndex).Cells("addRecord")) = 1 Or GetCellValueOrDefault(dgvSystemAccess.Rows(e.RowIndex).Cells("saveRecord")) = 1 Or GetCellValueOrDefault(dgvSystemAccess.Rows(e.RowIndex).Cells("deleteRecord")) = 1 Or GetCellValueOrDefault(dgvSystemAccess.Rows(e.RowIndex).Cells("approveRecord")) = 1) Then
                                clsCommon.Prompt_User("information", "Can not remove '" & dgvSystemAccess.Columns(e.ColumnIndex).HeaderText & "' access in " & dgvSystemAccess.Rows(e.RowIndex).Cells("moduleName").Value & ". There are other permissions currently set 'ON' for this selected module.")
                                cell.Value = 1
                            End If
                    End Select
                End If
            End If
        Catch ex As Exception
            clsCommon.Prompt_User("error", ex.Message)
        End Try
    End Sub

    Private Sub dgvSystemAccess_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvSystemAccess.RowPostPaint
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

    Public Function GetCellValueOrDefault(ByVal x As DataGridViewCell) As Integer
        Dim CellValue As Integer

        If IsNumeric(x.Value) Then CellValue = CInt(x.Value) Else CellValue = 0

        Return CellValue
    End Function

#End Region

#Region "frmSystemAccessLevel User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        dgvSystemAccess_Initialize()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "System Access Level"
        Me.txtRoleName.Focus()
    End Sub

    Private Sub Define_Collection()
        With ColSystemAccessLevel
            .Add(txtRoleName)
            .Add(txtRoleDescription)
            .Add(dgvSystemAccess)
            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColSystemAccessLevel)
        Define_Required_Fields()
        Me.Text = "System Access Level"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtRoleName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsSystemAccessLevel
            .Dt_gRID2 = dtable
            dtable = New DataTable

            txtRoleName.Text = .Role_Name
            txtRoleDescription.Text = .Role_Desc

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Role_ID
            .Init_Flag = 1
            dtable = .Populate_Record_System_Access
        End With
        dgvSystemAccess.DataSource = dtable

        If dgvSystemAccess.SelectedRows.Count > 0 Then
            dgvSystemAccess.Rows(0).Selected = True
        End If

        Me.txtRoleName.Focus()
        Me.Text = "System Access Level - " & Me.txtRoleName.Text
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

    Private Sub Disposed_Class()
        clsSystemAccessLevel = Nothing
        clsCommon = Nothing
        ColSystemAccessLevel = Nothing
        ColRequired = Nothing
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Dim dtable As DataTable

        clsCommon.EnableDisableFields(ColSystemAccessLevel, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)

        dtable = New DataTable
        clsSystemAccessLevel.Role_ID = RecordId
        clsSystemAccessLevel.Init_Flag = IIf(State = ADD_STATE, 0, 1)
        dtable = clsSystemAccessLevel.Populate_Record_System_Access
        dgvSystemAccess.DataSource = dtable

        If dgvSystemAccess.SelectedRows.Count > 0 Then
            dgvSystemAccess.Rows(0).Selected = True
        End If

        If (txtRoleName.Text.Trim.ToLower = LCase("super administrator")) Then
            tbrMainForm.Buttons(4).Visible = False
            txtRoleName.Enabled = False
            txtRoleDescription.Enabled = False
        Else
            txtRoleName.Enabled = True
            txtRoleDescription.Enabled = True
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsSystemAccessLevel.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtRoleName.Tag = "System Role Name"
        Me.txtRoleDescription.Tag = "System Role Description"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtRoleName.MaxLength = 45
        Me.txtRoleDescription.MaxLength = 2000
    End Sub

    Private Sub Populate_Permission_Collection()
        Try
            Dim AccessPermission As New Collection
            Dim AccessRow As DataGridViewRow

            For Each AccessRow In dgvSystemAccess.Rows
                clsAccessPermission = New AccessPermission.AccessPermission
                With clsAccessPermission
                    .Module_ID = GetCellValueOrDefault(AccessRow.Cells("moduleId"))
                    .View_Permission = GetCellValueOrDefault(AccessRow.Cells("viewRecord"))
                    .Add_Permission = GetCellValueOrDefault(AccessRow.Cells("addRecord"))
                    .Save_Permission = GetCellValueOrDefault(AccessRow.Cells("saveRecord"))
                    .Delete_Permission = GetCellValueOrDefault(AccessRow.Cells("deleteRecord"))
                    .Approve_Permission = GetCellValueOrDefault(AccessRow.Cells("approveRecord"))

                    AccessPermission.Add(clsAccessPermission)
                End With
            Next

            With clsSystemAccessLevel
                .colAccess_Permission = AccessPermission
                AccessPermission = Nothing
            End With

        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub

#End Region

End Class