Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmRegion
    Inherits System.Windows.Forms.Form

#Region "frmRegion Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsRegion As New Region.Region

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmRegionFinder
    Private txtUpdateDt As New TextBox

    'declaration of Collections
    Private ColRequired As New Collection
    Private ColRegion As New Collection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String

    Private KeyPressChar As Long
#End Region

#Region "frmRegion Main Form Private Sub"

    Private Sub frmRegion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsRegion.Init_Flag = RecordId
            clsRegion.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmRegion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtRegionName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmRegion_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmRegion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtBarangayCount.KeyPress, txtCityCount.KeyPress, txtMunicipalityCount.KeyPress, txtProvinceCount.KeyPress, txtRegionCode.KeyPress, txtRegionName.KeyPress
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

#Region "frmRegion ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmRegion As New frmRegion
                    frmTitle = "Region"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmRegion = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmRegion.Activate()
                    Else
                        State = ADD_STATE
                        Call clsCommon.ClearControls(ColRegion)
                        Call Set_Form_State()
                        RecordId = 0
                        Me.Text = "Region"
                    End If
                Case 1 'edit
edit_rec:
                    State = EDIT_STATE
                    Call Set_Form_State()
                Case 2 'delete
delete_rec:
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        With clsRegion
                            .Region_Id = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    Dim frmFinder As frmRegionFinder
                    frmTitle = "Region Finder"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        frmFinder.Activate()
                        frmFinder.ActiveControl = frmFinder.btnSearch
                        frmFinder.btnSearch.PerformClick()
                        frmFinder.txtRegionName.Focus()
                    Else
                        frmFinder = New frmRegionFinder
                        With frmFinder
                            .Region_ID = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        With clsRegion
                            .Region_Id = RecordId
                            .Region_Name = Trim(txtRegionName.Text)
                            .R_Code = Trim(txtRegionCode.Text)
                            .Province_Cnt = IIf((Len(txtProvinceCount.Text.Replace(",", "")) = 0), 0, Val(txtProvinceCount.Text.Replace(",", "")))
                            .City_Cnt = IIf((Len(txtCityCount.Text.Replace(",", "")) = 0), 0, Val(txtCityCount.Text.Replace(",", "")))
                            .Municipality_Cnt = IIf((Len(txtMunicipalityCount.Text.Replace(",", "")) = 0), 0, Val(txtMunicipalityCount.Text.Replace(",", "")))
                            .Barangay_Cnt = IIf((Len(txtBarangayCount.Text.Replace(",", "")) = 0), 0, Val(txtBarangayCount.Text.Replace(",", "")))

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = .Region_Id
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Region - " & Me.txtRegionName.Text

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
                        Me.txtRegionName.Focus()
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

                        With clsRegion
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

#Region "frmRegion User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Region"
        Me.txtRegionName.Focus()
    End Sub

    Private Sub Define_Collection()
        With ColRegion
            .Add(txtRegionName)
            .Add(txtRegionCode)
            .Add(txtProvinceCount)
            .Add(txtCityCount)
            .Add(txtMunicipalityCount)
            .Add(txtBarangayCount)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColRegion)
        Define_Required_Fields()
        Me.Text = "Region"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtRegionName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsRegion
            txtRegionName.Text = .Region_Name
            txtRegionCode.Text = .R_Code
            txtProvinceCount.Text = .Province_Cnt
            txtCityCount.Text = .City_Cnt
            txtMunicipalityCount.Text = .Municipality_Cnt
            txtBarangayCount.Text = .Barangay_Cnt

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Region_Id
        End With
        Me.txtRegionName.Focus()
        Me.Text = "Region - " & Me.txtRegionName.Text
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
        clsRegion = Nothing
        clsCommon = Nothing
        ColRegion = Nothing
        ColRequired = Nothing
    End Sub

    Private Sub Set_Form_State()
        Set_Permission()
        clsCommon.EnableDisableFields(ColRegion, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblRegionName.Text = "Region Name"
        Else
            lblRegionName.Text = "Region Name *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsRegion.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtRegionName.Tag = "Region Name"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtRegionName.MaxLength = 255
        Me.txtRegionCode.MaxLength = 2
        Me.txtProvinceCount.MaxLength = 20
        Me.txtCityCount.MaxLength = 20
        Me.txtMunicipalityCount.MaxLength = 20
        Me.txtBarangayCount.MaxLength = 20
    End Sub

    Private Sub txtProvinceCount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProvinceCount.KeyPress, txtCityCount.KeyPress, txtMunicipalityCount.KeyPress, txtBarangayCount.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.AcceptNumbers(e)
        End If
    End Sub

#End Region

End Class