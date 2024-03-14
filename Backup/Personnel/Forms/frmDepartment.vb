Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmDepartment
    Inherits System.Windows.Forms.Form

#Region "frmDepartment Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsDepartment As New Department.Department

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmDepartmentFinder
    Private txtUpdateDt As New TextBox

    'declaration of Collections
    Private ColRequired As New Collection
    Private ColDepartment As New Collection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    Private KeyPressChar As Long
#End Region

#Region "frmDepartment Main Form Private Sub"

    Private Sub frmDepartment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsDepartment.Init_Flag = RecordId
            clsDepartment.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmDepartment_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtDepartmentName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmDepartment_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmDepartment_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtDepartmentCode.KeyPress, txtDepartmentDescription.KeyPress, txtDepartmentName.KeyPress
        Dim tbArgs As ToolBarButtonClickEventArgs

        KeyPressChar = e.KeyChar.GetHashCode
        Select Case KeyPressChar
            Case 65537 ' press crtl+a
                If Me.tbrMainForm.Buttons(0).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(0))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 327685 'press crtl+e
                If Me.tbrMainForm.Buttons(1).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(1))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 262148 'press crtl+d
                If Me.tbrMainForm.Buttons(2).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(2))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                    Exit Sub
                End If
            Case 393222 'press crtl+f
                If Me.tbrMainForm.Buttons(3).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(3))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1245203 'press crtl+s
                If Me.tbrMainForm.Buttons(4).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(4))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
            Case 1769499 ' press esc
                If Me.tbrMainForm.Buttons(5).Visible Then
                    tbArgs = New ToolBarButtonClickEventArgs(tbrMainForm.Buttons(5))
                    tbrMainForm_ButtonClick(sender, tbArgs)
                End If
        End Select

    End Sub

#End Region

#Region "frmDepartment ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmDepartment As New frmDepartment
                    frmTitle = "Department"

                    If blnUseFinder Then
                        State = ADD_STATE
                        Call clsCommon.ClearControls(ColDepartment)
                        Call Set_Form_State()
                        RecordId = 0
                        Me.Text = "Department"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmDepartment = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmDepartment.Activate()
                        Else
                            State = ADD_STATE
                            Call clsCommon.ClearControls(ColDepartment)
                            Call Set_Form_State()
                            RecordId = 0
                            Me.Text = "Department"
                        End If
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
                        With clsDepartment
                            .Department_ID = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmDepartmentFinder
                        frmTitle = "Department Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtDepartmentName.Focus()
                        Else
                            frmFinder = New frmDepartmentFinder
                            With frmFinder
                                .Department_ID = 0
                                .MdiParent = Me.MdiParent
                                .Show()
                            End With
                        End If
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        With clsDepartment
                            .Department_ID = RecordId
                            .Department_Name = Trim(txtDepartmentName.Text)
                            .Department_Code = Trim(txtDepartmentCode.Text)
                            .Department_Description = Trim(txtDepartmentDescription.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = .Department_ID
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Department - " & Me.txtDepartmentName.Text

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
                        Me.txtDepartmentName.Focus()
                    End If
                Case 5 'cancel
cancel_rec:
                    Me.Close()
            End Select
            '------------------------------------------------------------------------------
        Else
            'form KeyPress
            '------------------------------------------------------------------------------
            Select Case KeyPressChar
                Case 65537 ' press crtl+a
                    GoTo add_rec
                Case 327685 'press crtl+e
                    GoTo edit_rec
                Case 262148 'press crtl+d
                    GoTo delete_rec
                Case 393222 'press crtl+f
                    GoTo find_rec
                Case 1245203 'press crtl+s
                    GoTo save_rec
                Case 1769499 ' press esc
                    GoTo cancel_rec
            End Select
            '------------------------------------------------------------------------------
        End If

    End Sub

#End Region

#Region "frmDepartment User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Department"
        Me.txtDepartmentName.Focus()
    End Sub

    Private Sub Define_Collection()
        With ColDepartment
            .Add(txtDepartmentName)
            .Add(txtDepartmentCode)
            .Add(txtDepartmentDescription)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColDepartment)
        Define_Required_Fields()
        Me.Text = "Department"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtDepartmentName)
            .Add(txtDepartmentCode)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsDepartment
            txtDepartmentName.Text = .Department_Name
            txtDepartmentCode.Text = .Department_Code
            txtDepartmentDescription.Text = .Department_Description

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Department_ID
        End With
        Me.txtDepartmentName.Focus()
        Me.Text = "Department - " & Me.txtDepartmentName.Text
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
        clsDepartment = Nothing
        clsCommon = Nothing
        ColDepartment = Nothing
        ColRequired = Nothing
    End Sub

    Public Sub Set_Form_State()
        clsCommon.EnableDisableFields(ColDepartment, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblDepartmentName.Text = "Department Name"
            lblDepartmentCode.Text = "Department Code"
        Else
            lblDepartmentName.Text = "Department Name *"
            lblDepartmentCode.Text = "Department Code *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsDepartment.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtDepartmentName.Tag = "Department Name"
        Me.txtDepartmentCode.Tag = "Department Code"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtDepartmentName.MaxLength = 255
        Me.txtDepartmentCode.MaxLength = 45
        Me.txtDepartmentDescription.MaxLength = 2000
    End Sub

#End Region

End Class