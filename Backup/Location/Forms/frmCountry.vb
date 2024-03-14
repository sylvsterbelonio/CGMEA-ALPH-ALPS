Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmCountry
    Inherits System.Windows.Forms.Form

#Region "frmCountry Variable Declaration"
    'declaration of classes
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsCountry As New Country.Country

    'declaration of Forms and other objects
    Private WithEvents frmFinder As frmCountryFinder
    Private txtUpdateDt As New TextBox

    'declaration of Collections
    Private ColRequired As New Collection
    Private ColCountry As New Collection

    'declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String

    Private KeyPressChar As Long
#End Region

#Region "frmCountry Main Form Private Sub"

    Private Sub frmCountry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsCountry.Init_Flag = RecordId
            clsCountry.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmCountry_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtCountryName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmCountry_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmCountry_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress, txtAreaSQKM.KeyPress, txtAreaSQMI.KeyPress, txtCountryName.KeyPress, txtCurrencyCode.KeyPress, txtCurrencyType.KeyPress, txtFIPS.KeyPress, txtGMI.KeyPress, txtPopulation.KeyPress, txtSovereign.KeyPress
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

#Region "frmCountry ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmCountry As New frmCountry
                    frmTitle = "Country"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        NwfrmCountry = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        NwfrmCountry.Activate()
                    Else
                        State = ADD_STATE
                        Call clsCommon.ClearControls(ColCountry)
                        Call Set_Form_State()
                        RecordId = 0
                        ClearImage()
                        Me.Text = "Country"
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
                        With clsCountry
                            .Country_Id = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    Dim frmFinder As frmCountryFinder
                    frmTitle = "Country Finder"
                    If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                        frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                        frmFinder.Activate()
                        frmFinder.ActiveControl = frmFinder.btnSearch
                        frmFinder.btnSearch.PerformClick()
                        frmFinder.txtCountryName.Focus()
                    Else
                        frmFinder = New frmCountryFinder
                        With frmFinder
                            .Country_ID = 0
                            .MdiParent = Me.MdiParent
                            .Show()
                        End With
                    End If
                    Me.Close()
                Case 4 'save
save_rec:
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor
                        With clsCountry
                            .Country_Id = RecordId
                            .Country_FIPS = Trim(txtFIPS.Text)
                            .Country_GMI = Trim(txtGMI.Text)
                            .Country_Name = Trim(txtCountryName.Text)
                            .Country_Flag = Trim(txtFileName.Text)
                            .Country_Sovereign = Trim(txtSovereign.Text)
                            .Country_Population = IIf((Len(txtPopulation.Text.Replace(",", "")) = 0), 0, Val(txtPopulation.Text.Replace(",", "")))
                            .CountryArea_Sqkm = IIf((Len(txtAreaSQKM.Text.Replace(",", "")) = 0), 0, Val(txtAreaSQKM.Text.Replace(",", "")))
                            .CountryArea_Sqmi = IIf((Len(txtAreaSQMI.Text.Replace(",", "")) = 0), 0, Val(txtAreaSQMI.Text.Replace(",", "")))
                            .CountryCurrency_Code = Trim(txtCurrencyCode.Text)
                            .CountryCurrency_Type = Trim(txtCurrencyType.Text)

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                Set_Form_State()
                                RecordId = .Country_Id
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Country - " & Me.txtCountryName.Text

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
                        Me.txtCountryName.Focus()
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

                        With clsCountry
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

#Region "frmCountry User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Country"
        Me.txtCountryName.Focus()
    End Sub

    Private Sub Define_Collection()
        With ColCountry
            .Add(txtCountryName)
            .Add(btnFlag)
            .Add(txtFIPS)
            .Add(txtGMI)
            .Add(txtSovereign)
            .Add(txtPopulation)
            .Add(txtAreaSQKM)
            .Add(txtAreaSQMI)
            .Add(txtCurrencyCode)
            .Add(txtCurrencyType)

            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColCountry)
        Define_Required_Fields()
        Me.Text = "Country"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtCountryName)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsCountry
            txtCountryName.Text = .Country_Name

            Me.txtFileName.Text = .Country_Flag

            If File.Exists(txtFileName.Text) Then
                Dim image1, imageCopy As Bitmap
                image1 = Bitmap.FromFile(txtFileName.Text)
                imageCopy = image1.Clone
                btnFlag.BackgroundImage = imageCopy
                btnFlag.BackgroundImageLayout = ImageLayout.Zoom
                cmnuClear.Enabled = True
            Else
                ClearImage()
                cmnuClear.Enabled = False
            End If

            txtFIPS.Text = .Country_FIPS
            txtGMI.Text = .Country_GMI
            txtSovereign.Text = .Country_Sovereign
            txtPopulation.Text = Format(.Country_Population, "Standard")
            txtAreaSQKM.Text = Format(.CountryArea_Sqkm, "Standard")
            txtAreaSQMI.Text = Format(.CountryArea_Sqmi, "Standard")
            txtCurrencyCode.Text = .CountryCurrency_Code
            txtCurrencyType.Text = .CountryCurrency_Type

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Country_Id
        End With
        Me.txtCountryName.Focus()
        Me.Text = "Country - " & Me.txtCountryName.Text
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
        clsCountry = Nothing
        clsCommon = Nothing
        ColCountry = Nothing
        ColRequired = Nothing
        If Directory.Exists(ImageDir) Then
            Try
                For Each fName As String In Directory.GetFiles(ImageDir)
                    If File.Exists(fName) Then
                        File.Delete(fName)
                    End If
                Next
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Set_Form_State()
        Set_Permission()
        clsCommon.EnableDisableFields(ColCountry, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)
        If State = "View" Then
            lblCountryName.Text = "Country Name"
        Else
            lblCountryName.Text = "Country Name *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsCountry.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtCountryName.Tag = "Country Name"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtFIPS.MaxLength = 2
        Me.txtGMI.MaxLength = 3
        Me.txtCountryName.MaxLength = 255
        Me.txtSovereign.MaxLength = 255
        Me.txtPopulation.MaxLength = 20
        Me.txtAreaSQKM.MaxLength = 20
        Me.txtAreaSQMI.MaxLength = 20
        Me.txtCurrencyType.MaxLength = 255
        Me.txtCurrencyCode.MaxLength = 45
    End Sub

    Private Sub txtPopulation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPopulation.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.AcceptNumbers(e)
        End If
    End Sub

    Private Sub txtAreaSQKM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAreaSQKM.KeyPress, txtAreaSQMI.KeyPress
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        KeyPressChar = e.KeyChar.GetHashCode

        If Not (KeyPressChar = 65537 Or KeyPressChar = 327685 Or KeyPressChar = 262148 Or KeyPressChar = 393222 Or KeyPressChar = 1245203 Or KeyPressChar = 1769499 Or KeyPressChar = 983055) Then
            clsCommon.AcceptAmount(sender, e)
        End If
    End Sub

    Private Sub btnFlag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlag.Click
        Dim cdlOpen As New OpenFileDialog

        cdlOpen.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png) | *.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png | All Files | *.*"

        cdlOpen.ShowDialog()

        If File.Exists(cdlOpen.FileName) Then
            txtFileName.Text = cdlOpen.FileName
            Dim image1 As Bitmap = New Bitmap(cdlOpen.FileName)
            btnFlag.BackgroundImage = image1
            btnFlag.BackgroundImageLayout = ImageLayout.Stretch
            cmnuClear.Enabled = True
        End If
    End Sub

    Private Sub cmnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuClear.Click
        ClearImage()
        cmnuClear.Enabled = False
    End Sub

    Public Sub ClearImage()
        Dim image1 As Bitmap = New Bitmap(Me.GetType, "no-flag.gif")
        btnFlag.BackgroundImage = image1
        btnFlag.BackgroundImageLayout = ImageLayout.Stretch
        txtFileName.Text = ""
    End Sub

#End Region

End Class