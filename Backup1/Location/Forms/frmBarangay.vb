Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmBarangay
    Inherits System.Windows.Forms.Form

#Region "frmBarangay Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsBarangay As New Barangay.Barangay

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmBarangayFinder
    Private txtUpdateDt As New TextBox

    'declaration of Collections
    Private ColRequired As New Collection
    Private ColBarangay As New Collection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String

    'Declaration of SQL Related functions
    Private dsRegion As DataSet
    Private dsProvince As DataSet
    Private dsMunicipality As DataSet

    Private KeyPressChar As Long
#End Region

#Region "frmBarangay Main Form Private Sub"

    Private Sub frmBarangay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsBarangay.Init_Flag = RecordId
            clsBarangay.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmBarangay_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtBrgyName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmBarangay_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmBarangay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, cboMcode.KeyPress, cboMunicipality.KeyPress, cboPcode.KeyPress, cboProvince.KeyPress, cboRcode.KeyPress, cboRegion.KeyPress, txtBrgyCode.KeyPress, txtBrgyName.KeyPress, txtBarangayIndex.KeyPress, txtDistrictIndex.KeyPress
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

#Region "frmBarangay ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmBarangay As New frmBarangay
                    frmTitle = "Barangay"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmBarangay = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmBarangay.Activate()
                    Else
                        State = ADD_STATE
                        Call clsCommon.ClearControls(ColBarangay)
                        Call Set_Form_State()
                        RecordId = 0
                        cboRegion.SelectedIndex = 0
                        Me.Text = "Barangay"
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
                        With clsBarangay
                            .Barangay_Id = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    Dim frmFinder As frmBarangayFinder
                    frmTitle = "Barangay Finder"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        frmFinder.Activate()
                        frmFinder.ActiveControl = frmFinder.btnSearch
                        frmFinder.btnSearch.PerformClick()
                        frmFinder.txtBarangayName.Focus()
                    Else
                        frmFinder = New frmBarangayFinder
                        With frmFinder
                            .Barangay_ID = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        With clsBarangay
                            .Barangay_Id = RecordId
                            .Barangay_Name = Trim(txtBrgyName.Text)
                            .rur_Code = Trim(txtBrgyCode.Text)
                            .m_Code = IIf(Len(cboMcode.Text) = 0, "000000", cboMcode.Text)
                            ._bIndex = IIf(Len(txtBarangayIndex.Text) = 0, "000", txtBarangayIndex.Text)
                            ._dIndex = IIf(Len(txtDistrictIndex.Text) = 0, "00", txtDistrictIndex.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = .Barangay_Id
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Barangay - " & Me.txtBrgyName.Text

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
                        Me.txtBrgyName.Focus()
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

                        With clsBarangay
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

#Region "frmBarangay User Defined Private Sub"

    Private Sub Initialize_Form()
        With clsBarangay
            dsRegion = .GetRegionList
            clsCommon.PopulateComboBox(cboRcode, cboRegion, dsRegion)
        End With

        Define_Collection()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Barangay"
        Me.txtBrgyName.Focus()
    End Sub

    Private Sub Define_Collection()
        With ColBarangay
            .Add(cboRegion)
            .Add(cboProvince)
            .Add(cboMunicipality)
            .Add(txtBrgyName)
            .Add(txtBrgyCode)
            .Add(txtBarangayIndex)
            .Add(txtDistrictIndex)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColBarangay)
        Define_Required_Fields()
        Me.Text = "Barangay"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(cboRegion)
            .Add(cboProvince)
            .Add(cboMunicipality)
            .Add(txtBrgyName)
            .Add(txtBrgyCode)
            .Add(txtBarangayIndex)
            .Add(txtDistrictIndex)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsBarangay
            cboRcode.Text = Microsoft.VisualBasic.Left(.m_Code, 2)
            cboRegion.SelectedIndex = cboRcode.SelectedIndex

            dsProvince = .GetProvinceList
            clsCommon.PopulateComboBox(cboPcode, cboProvince, dsProvince)

            cboPcode.Text = Microsoft.VisualBasic.Left(.m_Code, 4)
            cboProvince.SelectedIndex = cboPcode.SelectedIndex

            dsMunicipality = .GetMunicipalityList
            clsCommon.PopulateComboBox(cboMcode, cboMunicipality, dsMunicipality)

            cboMcode.Text = .m_Code
            cboMunicipality.SelectedIndex = cboMcode.SelectedIndex

            txtBrgyName.Text = .Barangay_Name
            txtBrgyCode.Text = .rur_Code

            txtBarangayIndex.Text = ._bIndex

            txtDistrictIndex.Text = ._dIndex

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Barangay_Id
        End With
        Me.txtBrgyName.Focus()
        Me.Text = "Barangay - " & Me.txtBrgyName.Text
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
        clsBarangay = Nothing
        clsCommon = Nothing
        ColBarangay = Nothing
        ColRequired = Nothing
    End Sub

    Private Sub Set_Form_State()
        Set_Permission()
        clsCommon.EnableDisableFields(ColBarangay, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblRegionName.Text = "Region Name"
            lblProvinceName.Text = "Province Name"
            lblMunicipalityName.Text = "Municipality Name"
            lblBrgyName.Text = "Barangay Name"
            lblBrgyCode.Text = "Rural Code"
            lblBarangayIndex.Text = "Barangay Index"
        Else
            lblRegionName.Text = "Region Name *"
            lblProvinceName.Text = "Province Name *"
            lblMunicipalityName.Text = "Municipality Name *"
            lblBrgyName.Text = "Barangay Name *"
            lblBrgyCode.Text = "Rural Code *"
            lblBarangayIndex.Text = "Barangay Index *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsBarangay.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.cboRegion.Tag = "Region Name"
        Me.cboProvince.Tag = "Province Name"
        Me.cboMunicipality.Tag = "Municipality Name"
        Me.txtBrgyName.Tag = "Barangay Name"
        Me.txtBrgyCode.Tag = "Rural Code"
        txtDistrictIndex.Tag = "District / Municipality Index (PIN)"
        txtBarangayIndex.Tag = "Barangay Index (PIN)"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtBrgyName.MaxLength = 255
        Me.txtBrgyCode.MaxLength = 9
        txtDistrictIndex.MaxLength = 2
        txtBarangayIndex.MaxLength = 3
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboRcode.SelectedIndex = cboRegion.SelectedIndex
            With clsBarangay
                .m_Code = cboRcode.Text
                dsProvince = .GetProvinceList
                clsCommon.PopulateComboBox(cboPcode, cboProvince, dsProvince)
            End With
            cboProvince.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboProvince_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvince.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboPcode.SelectedIndex = cboProvince.SelectedIndex
            With clsBarangay
                .m_Code = cboPcode.Text
                dsMunicipality = .GetMunicipalityList
                clsCommon.PopulateComboBox(cboMcode, cboMunicipality, dsMunicipality)
            End With
            cboMunicipality.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboMunicipality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMunicipality.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboMcode.SelectedIndex = cboMunicipality.SelectedIndex
        End If
    End Sub

    Private Sub txtBrgyCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBrgyCode.KeyPress, txtBarangayIndex.KeyPress, txtDistrictIndex.KeyPress
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