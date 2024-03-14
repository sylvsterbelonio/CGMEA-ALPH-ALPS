Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmCollectionFee
    Inherits System.Windows.Forms.Form

#Region "frmCollectionFee Variable Declaration"

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsCollectionFee As New CollectionFee.CollectionFee
    Private WithEvents clsCollectionType As New CollectionType.CollectionType

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmCollectionFeeFinder
    Private WithEvents frmUseCollectionFeeFinder As frmCollectionFeeFinder
    Private WithEvents frmUseCollectionTypeFinder As frmCollectionTypeFinder
    Private Piping_ToolTip As New ToolTip
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColCollectionFee As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    'Declaration of SQL Related functions
    Private dsUnitType As DataSet

    Private KeyPressChar As Long

#End Region

#Region "frmCollectionFee Main Form Private Sub"

    Private Sub frmCollectionFee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        Initialize_AutoComplete()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsCollectionFee.Init_Flag = RecordId
            clsCollectionFee.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmCollectionFee_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtCollectionName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmCollectionFee_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmCollectionFee_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboRevisionCode.KeyPress, txtCollectionName.KeyPress, cboFeeType.KeyPress, txtFeeDefault.KeyPress
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

#Region "frmCollectionFee ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmCollectionFee As New frmCollectionFee
                    frmTitle = "Collection Fee"

                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColCollectionFee)
                        Set_Form_State()
                        Set_Default_Values()
                        RecordId = 0
                        Me.Text = "Collection Fee"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmCollectionFee = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmCollectionFee.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColCollectionFee)
                            Set_Form_State()
                            Set_Default_Values()
                            RecordId = 0
                            Me.Text = "Collection Fee"
                        End If
                    End If
                Case 1 'edit
edit_rec:
                    State = EDIT_STATE
                    Set_Form_State()
                Case 2 'delete
delete_rec:
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", MSGBOX_DELETE_CONFIRMATION)
                    If iAns = vbYes Then
                        With clsCollectionFee
                            ._feeId = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmCollectionFeeFinder
                        frmTitle = "Collection Fee Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtCollectionName.Focus()
                        Else
                            frmFinder = New frmCollectionFeeFinder
                            With frmFinder
                                .Fee_Id = 0
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
                        With clsCollectionFee
                            ._feeId = RecordId
                            ._revisionId = IIf((Len(cboRevisionId.Text.Replace(",", "")) = 0), 0, Val(cboRevisionId.Text.Replace(",", "")))
                            ._revisionCode = Trim(cboRevisionCode.Text)
                            ._typeId = IIf((Len(txtCollectionId.Text.Replace(",", "")) = 0), 0, Val(txtCollectionId.Text.Replace(",", "")))
                            ._typeName = Trim(txtCollectionName.Text)
                            If cboFeeType.Text = "FIXED" Then
                                ._feeType = 1
                            Else
                                ._feeType = 0
                            End If
                            ._feeDefault = IIf((Len(txtFeeDefault.Text.Replace(",", "")) = 0), 0, Val(txtFeeDefault.Text.Replace(",", "")))
                            
                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = ._feeId
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Collection Fee - " & txtCollectionName.Text & ")"

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
                        Me.txtCollectionName.Focus()
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

                        With clsCollectionFee
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

#Region "frmCollectionFee User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Collection Fee"
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsCollectionFee
            dataCombo = .GetRevisionList

            clsCommon.PopulateComboBox(cboRevisionId, cboRevisionCode, dataCombo)
        End With
    End Sub

    Private Sub Set_Default_Values()
        Try
            cboRevisionCode.SelectedIndex = 0
            cboFeeType.SelectedIndex = 0
            txtCollectionName.Text = ""
            Initialize_AutoComplete()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(cboRevisionId)
            .Add(cboRevisionCode)
            .Add(txtCollectionId)
            .Add(txtCollectionName)
            .Add(cboFeeType)
            .Add(txtFeeDefault)
        End With
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColCollectionFee
            .Add(cboRevisionId)
            .Add(cboRevisionCode)
            .Add(txtCollectionId)
            .Add(txtCollectionName)
            .Add(cboFeeType)
            .Add(txtFeeDefault)
        End With
        clsCommon.ClearControls(ColCollectionFee)
        Define_Required_Fields()
        Me.Text = "Collection Fee"
    End Sub

    Private Sub Define_Pipe_Fields()
        Dim ColTemp As New Collection
        ColPipe = ColTemp
        With ColPipe
            .Add(lblCollectionName)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtCollectionName)
            .Add(cboRevisionCode)
            .Add(cboFeeType)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsCollectionFee
            cboRevisionId.Text = ._revisionId
            cboRevisionCode.Text = ._revisionCode
            txtCollectionId.Text = ._typeId
            txtCollectionName.Text = ._typeName
            If ._feeType = 1 Then
                cboFeeType.Text = "FIXED"
            Else
                cboFeeType.Text = "RATE"
            End If
            txtFeeDefault.Text = ._feeDefault

            txtUpdateDt.Text = .Updated_Dt
            RecordId = ._feeId
        End With

        Me.Text = "Collection Type - " & txtCollectionName.Text
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
        clsCollectionFee = Nothing
        clsCommon = Nothing
        ColCollectionFee = Nothing
        ColRequired = Nothing
    End Sub

    Public Sub Set_Form_State()
        Define_Pipe_Fields()
        Define_Display()
        clsCommon.EnableDisableControls(ColPipe, ColDisplay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblCollectionName.Text = "Collection Name"
            lblRevisionCode.Text = "Revision Code"
            lblFeeType.Text = "Fee Type"
        Else
            lblCollectionName.Text = "Collection Name *"
            lblRevisionCode.Text = "Revision Code *"
            lblFeeType.Text = "Fee Type *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsCollectionFee.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        cboRevisionCode.Tag = "Revision Code"
        txtCollectionName.Tag = "Collection Type Name"
        cboFeeType.Tag = "Fee Type"
    End Sub

    Private Sub Set_Max_Length()
        txtCollectionName.MaxLength = 255
    End Sub

    Private Sub txtCollectionName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCollectionName.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.DisAllow_Input(e)
        End If
    End Sub

    Private Sub txtCollectionName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCollectionName.KeyUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If State <> VIEW_STATE Then
            clsCommon.Delete_TxtBox_Value(txtCollectionId, e)
            clsCommon.Delete_TxtBox_Value(txtCollectionName, e)
        End If
    End Sub

    Private Sub txtCollectionName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCollectionName.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.Disable_Field_Context_Menu(e, sender)
    End Sub

    Private Sub cboRevisionCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRevisionCode.TextChanged
        Dim dtable As DataTable = Nothing

        If State <> VIEW_STATE Then
            cboRevisionId.SelectedIndex = cboRevisionCode.SelectedIndex
        End If
    End Sub

#End Region

#Region "frmCollectionfEE Label Piping Click"

    Private Sub lblCollectionName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblCollectionName.Click
        Try
            frmUseCollectionTypeFinder = New frmCollectionTypeFinder

            With frmUseCollectionTypeFinder
                Use_Record_State = USE_STATE
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False
                .ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "frmCollectionFee Handle Piping"

    Private Sub frmUseCollectionTypeFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String) Handles frmUseCollectionTypeFinder.Use_Clicked
        If String.IsNullOrEmpty(Record_Name) Then
            Return
        End If

        With clsCollectionType
            .Init_Flag = Record_Id
            .Selected_Record()

            txtCollectionName.Text = ._typeName & " (" & ._typeCode & ")"
            txtCollectionId.Text = ._typeId
        End With
    End Sub

#End Region

End Class