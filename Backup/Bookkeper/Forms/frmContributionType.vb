Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmContributionType

    Inherits System.Windows.Forms.Form

#Region "frmContributionType Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsContributionType As New ContributionType.ContributionType

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmContributionTypeFinder
    Private txtUpdateDt As New TextBox

    'declaration of Collections
    Private ColRequired As New Collection
    Private ColContributionType As New Collection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    Private KeyPressChar As Long
#End Region

#Region "frmContributionType Main Form Private Sub"

    Private Sub frmContributionType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        Initialize_AutoComplete()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsContributionType.Init_Flag = RecordId
            clsContributionType.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow

    End Sub

    Private Sub frmContributionType_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtConTypeName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmContributionType_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmContributionType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, nudConYear.KeyPress, txtConTypeName.KeyPress, txtConMinAmount.KeyPress, txtConTypeDescription.KeyPress
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

#Region "frmContributionType ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmContributionType As New frmContributionType
                    frmTitle = "Contribution Type"

                    If blnUseFinder Then
                        State = ADD_STATE
                        Call clsCommon.ClearControls(ColContributionType)
                        Call Set_Form_State()
                        RecordId = 0
                        Me.Text = "Contribution Type"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmContributionType = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmContributionType.Activate()
                        Else
                            State = ADD_STATE
                            Call clsCommon.ClearControls(ColContributionType)
                            Call Set_Form_State()
                            RecordId = 0
                            Me.Text = "Contribution Type"
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
                        With clsContributionType
                            .ConType_Id = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmContributionTypeFinder
                        frmTitle = "Contribution Type Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtConTypeName.Focus()
                        Else
                            frmFinder = New frmContributionTypeFinder
                            With frmFinder
                                .ConType_ID = 0
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
                        With clsContributionType
                            .ConType_Id = RecordId
                            .Con_Year = nudConYear.Value
                            .ConType_Name = Trim(txtConTypeName.Text)
                            .Min_Amount = IIf((Len(txtConMinAmount.Text.Replace(",", "")) = 0), 0, Val(txtConMinAmount.Text.Replace(",", "")))
                            .ConType_Description = Trim(txtConTypeDescription.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = .ConType_Id
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Department - " & Me.txtConTypeName.Text

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
                        Me.txtConTypeName.Focus()
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

#Region "frmContributionType User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Contribution Type"
        Me.txtConTypeName.Focus()
    End Sub

    Private Sub Initialize_AutoComplete()
        With clsContributionType
            If State = EDIT_STATE Then
                nudConYear.Minimum = (.GetContributionTypeMinYear())
                nudConYear.Value = Now.Year
                nudConYear.Maximum = Now.Year
            Else
                nudConYear.Minimum = (.GetContributionTypeMaxYear())
                nudConYear.Value = Now.Year
                nudConYear.Maximum = Now.Year
            End If
        End With
    End Sub

    Private Sub Define_Collection()
        With ColContributionType
            .Add(nudConYear)
            .Add(txtConTypeName)
            .Add(txtConMinAmount)
            .Add(txtConTypeDescription)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColContributionType)
        Define_Required_Fields()
        Me.Text = "Contribution Type"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(nudConYear)
            .Add(txtConTypeName)
            .Add(txtConMinAmount)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsContributionType
            nudConYear.Value = .Con_Year
            txtConTypeName.Text = .ConType_Name
            txtConMinAmount.Text = Format(.Min_Amount, "Standard")
            txtConTypeDescription.Text = .ConType_Description

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .ConType_Id
        End With
        Me.txtConTypeName.Focus()
        Me.Text = "Contribution Type - " & Me.txtConTypeName.Text
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
        clsContributionType = Nothing
        clsCommon = Nothing
        ColContributionType = Nothing
        ColRequired = Nothing
    End Sub

    Public Sub Set_Form_State()
        clsCommon.EnableDisableFields(ColContributionType, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblConYear.Text = "Year"
            lblConTypeName.Text = "Type Name"
            lblMinAmount.Text = "Minimum Amount"
        Else
            lblConYear.Text = "Year *"
            lblConTypeName.Text = "Type Name *"
            lblMinAmount.Text = "Minimum Amount *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsContributionType.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.nudConYear.Tag = "Contribution Type Year"
        Me.txtConTypeName.Tag = "Type Name"
        Me.txtConMinAmount.Tag = "Minimum Amount"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtConTypeName.MaxLength = 255
        Me.txtConMinAmount.MaxLength = 20
        Me.txtConTypeDescription.MaxLength = 2000
    End Sub

#End Region

    Private Sub txtConMinAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConMinAmount.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.AcceptAmount(sender, e)
        End If
    End Sub
End Class