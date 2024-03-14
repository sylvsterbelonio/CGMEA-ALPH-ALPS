﻿Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors

Public Class frmBank
    Inherits System.Windows.Forms.Form

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsBank As New Bank.Bank

    'Declaration of Forms and other objects
    Private WithEvents frmFinder As frmBankFinder
    Private txtUpdateDt As New TextBox

    'Declaration of Collections
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColBank As New Collection

    'Declaration of Other Variables
    Public RecordId As Integer
    Public State As String
    Private frmTitle As String
    Public blnUseFinder As Boolean = False

    'Declaration of SQL Related functions
    Private dsRegion As DataSet
    Private dsProvince As DataSet
    Private dsMunicipal As DataSet
    Private dsBarangay As DataSet
    Private dsZipCode As DataSet

    Private KeyPressChar As Long

#Region "frmBank Main Form Private Sub"

    Private Sub frmBank_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        Me.Cursor = WaitCursor
        Initialize_Form()
        If State = EDIT_STATE Or State = VIEW_STATE Then
            clsBank.Init_Flag = RecordId
            clsBank.Selected_Record()
            Assign_Data()
        End If
        Me.Cursor = Arrow
    End Sub

    Private Sub frmBank_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            Dim iAns

            iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
            If iAns = vbYes Then
                State = VIEW_STATE
                e.Cancel = False
            Else
                e.Cancel = True
                txtBankName.Focus()
            End If
        Else
        End If
    End Sub

    Private Sub frmBank_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

    Private Sub frmBank_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
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

#Region "frmBank ToolBar Private Sub"

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            'toolbar
            '----------------------------------------------------------------------------
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    Dim NwfrmBank As New frmBank
                    frmTitle = "Bank"

                    If blnUseFinder Then
                        State = ADD_STATE
                        clsCommon.ClearControls(ColBank)
                        Set_Form_State()
                        ClearImage()
                        cboRegion.SelectedIndex = 0
                        RecordId = 0
                        Me.Text = "Bank"
                    Else
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            NwfrmBank = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            NwfrmBank.Activate()
                        Else
                            State = ADD_STATE
                            clsCommon.ClearControls(ColBank)
                            Set_Form_State()
                            ClearImage()
                            cboRegion.SelectedIndex = 0
                            RecordId = 0
                            Me.Text = "Bank"
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
                        With clsBank
                            .Bank_Id = RecordId
                            .Updated_By = gUserID
                            If .Delete_Record() Then
                                Me.Close()
                            End If
                        End With
                    End If
                Case 3 'find
find_rec:
                    If Not blnUseFinder Then
                        Dim frmFinder As frmBankFinder
                        frmTitle = "Bank Finder"
                        If clsCommon.CheckIfRecordIsLoaded(Me.ParentForm, frmTitle) Then
                            frmFinder = clsCommon.GetRecordChildForm(Me.ParentForm, frmTitle)
                            frmFinder.Activate()
                            frmFinder.ActiveControl = frmFinder.btnSearch
                            frmFinder.btnSearch.PerformClick()
                            frmFinder.txtBankName.Focus()
                        Else
                            frmFinder = New frmBankFinder
                            With frmFinder
                                .Bank_Id = 0
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
                        With clsBank
                            .Bank_Id = RecordId
                            .Bank_Name = Trim(txtBankName.Text)
                            .Bank_Code = Trim(txtBankCode.Text)
                            .Bank_Description = Trim(txtBankDescription.Text)
                            .Bank_Remarks = Trim(txtRemarks.Text)
                            .Bank_Address = txtBankAddress.Text
                            .Bank_Logo = txtFileName.Text
                            .R_Code = IIf(Len(cboRcode.Text) = 0, "00", cboRcode.Text)
                            .P_Code = IIf(Len(cboPcode.Text) = 0, "0000", cboPcode.Text)
                            .M_Code = IIf(Len(cboMcode.Text) = 0, "000000", cboMcode.Text)
                            .Rur_Code = IIf(Len(cboRurcode.Text) = 0, "000000000", cboRurcode.Text)
                            .ZipCode_Id = IIf((Len(cboZipCodeId.Text.Replace(",", "")) = 0), 0, Val(cboZipCodeId.Text.Replace(",", "")))
                            .ContactFirst_Name = txtFirstName.Text
                            .ContactLast_Name = txtLastName.Text
                            .ContactTel_No = txtTelNo.Text
                            .ContactFax_No = txtFaxNo.Text
                            .ContactEmail_Address = txtEmailAddress.Text
                            .Contact_Website = txtWebsite.Text

                            .Updated_Dt = txtUpdateDt.Text
                            .Updated_By = gUserID
                            If .Save_Record() Then
                                State = VIEW_STATE
                                RecordId = .Bank_Id
                                Set_Form_State()
                                txtUpdateDt.Text = .Updated_Dt
                                Me.Text = "Bank - " & txtBankName.Text

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
                        Me.txtBankName.Focus()
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

#Region "frmBank User Defined Private Sub"

    Private Sub Initialize_Form()
        With clsBank
            dsRegion = .GetRegionList
            clsCommon.PopulateComboBox(cboRcode, cboRegion, dsRegion)
        End With

        Define_Collection()
        Set_Permission()
        Set_Form_State()
        Set_Required_Tags()
        Set_Max_Length()
        Me.Text = "Bank"
        Me.txtBankName.Focus()
    End Sub

    Private Sub Define_Collection()
        With ColBank
            .Add(Me.txtBankName)
            .Add(Me.txtBankCode)
            .Add(Me.txtBankDescription)
            .Add(Me.txtRemarks)
            .Add(Me.txtBankAddress)
            .Add(Me.cboBarangay)
            .Add(Me.cboMunicipality)
            .Add(Me.cboProvince)
            .Add(Me.cboRegion)
            .Add(Me.cboZipCodeArea)
            .Add(Me.btnLogo)
            .Add(Me.txtFirstName)
            .Add(Me.txtLastName)
            .Add(Me.txtTelNo)
            .Add(Me.txtFaxNo)
            .Add(Me.txtEmailAddress)
            .Add(Me.txtWebsite)
            .Add(txtUpdateDt)
        End With
        clsCommon.ClearControls(ColBank)
        Define_Required_Fields()
        Me.Text = "Bank"
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(txtBankName)
            .Add(txtBankCode)
        End With
    End Sub

    Private Sub Assign_Data()
        With clsBank
            Me.cboRcode.Text = .R_Code
            Me.cboRegion.SelectedIndex = Me.cboRcode.SelectedIndex

            dsProvince = .GetProvinceList
            clsCommon.PopulateComboBox(cboPcode, cboProvince, dsProvince)
            Me.cboPcode.Text = .P_Code
            Me.cboProvince.SelectedIndex = Me.cboPcode.SelectedIndex

            dsMunicipal = .GetMunicipalityList()
            clsCommon.PopulateComboBox(cboMcode, cboMunicipality, dsMunicipal)
            Me.cboMcode.Text = .M_Code
            Me.cboMunicipality.SelectedIndex = Me.cboMcode.SelectedIndex

            dsBarangay = .GetBarangayList()
            clsCommon.PopulateComboBox(cboRurcode, cboBarangay, dsBarangay)
            Me.cboRurcode.Text = .Rur_Code
            Me.cboBarangay.SelectedIndex = Me.cboRurcode.SelectedIndex

            dsZipCode = .GetZipCodeList
            clsCommon.PopulateComboBox(cboZipCodeId, cboZipCodeArea, dsZipCode, cboZipCode)
            Me.cboZipCodeId.Text = .ZipCode_Id
            Me.cboZipCodeArea.SelectedIndex = Me.cboZipCodeId.SelectedIndex
            Me.cboZipCode.SelectedIndex = Me.cboZipCodeId.SelectedIndex

            Me.txtFileName.Text = .Bank_Logo

            If File.Exists(txtFileName.Text) Then
                Dim image1, imageCopy As Bitmap
                image1 = Bitmap.FromFile(txtFileName.Text)
                imageCopy = image1.Clone
                btnLogo.BackgroundImage = imageCopy
                btnLogo.BackgroundImageLayout = ImageLayout.Zoom
                cmnuClear.Enabled = True
            Else
                ClearImage()
                cmnuClear.Enabled = False
            End If

            Me.txtBankName.Text = .Bank_Name
            Me.txtBankCode.Text = .Bank_Code
            Me.txtBankDescription.Text = .Bank_Description
            Me.txtRemarks.Text = .Bank_Remarks
            Me.txtBankAddress.Text = .Bank_Address
            Me.txtFirstName.Text = .ContactFirst_Name
            Me.txtLastName.Text = .ContactLast_Name
            Me.txtTelNo.Text = .ContactTel_No
            Me.txtFaxNo.Text = .ContactFax_No
            Me.txtEmailAddress.Text = .ContactEmail_Address
            Me.txtWebsite.Text = .Contact_Website

            txtUpdateDt.Text = .Updated_Dt
            RecordId = .Bank_Id
        End With
        Me.txtBankName.Focus()

        Me.Text = "Bank - " & txtBankName.Text
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
        clsBank = Nothing
        clsCommon = Nothing
        ColBank = Nothing
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

    Public Sub Set_Form_State()
        clsCommon.EnableDisableFields(ColBank, State)
        clsCommon.HideUnhideToolbarButtons(tbrMainForm, State, Add_Permission, Edit_Permission, Delete_Permission, View_Permission, Approve_Permission)

        If State = "View" Then
            lblBankName.Text = "Name"
            lblBankCode.Text = "Code"
        Else
            lblBankName.Text = "Name *"
            lblBankCode.Text = "Code *"
        End If
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsBank.MsgArrival, clsCommon.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub Set_Required_Tags()
        Me.txtBankName.Tag = "Name"
        Me.txtBankCode.Tag = "Code"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtBankName.MaxLength = 255
        Me.txtBankCode.MaxLength = 45
        Me.txtBankDescription.MaxLength = 2000
        Me.txtRemarks.MaxLength = 2000
        Me.txtBankAddress.MaxLength = 2000
        Me.txtFirstName.MaxLength = 255
        Me.txtLastName.MaxLength = 255
        Me.txtTelNo.MaxLength = 45
        Me.txtFaxNo.MaxLength = 45
        Me.txtEmailAddress.MaxLength = 45
        Me.txtWebsite.MaxLength = 45
    End Sub

    Private Sub cboRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRegion.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboRcode.SelectedIndex = cboRegion.SelectedIndex
            With clsBank
                .R_Code = cboRcode.Text
                dsProvince = .GetProvinceList
                clsCommon.PopulateComboBox(cboPcode, cboProvince, dsProvince, Nothing, True)
            End With
            cboProvince.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboProvince_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProvince.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboPcode.SelectedIndex = cboProvince.SelectedIndex
            With clsBank
                .P_code = cboPcode.Text
                dsMunicipal = .GetMunicipalityList
                clsCommon.PopulateComboBox(cboMcode, cboMunicipality, dsMunicipal, Nothing, True)
            End With
            cboMunicipality.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboMunicipality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMunicipality.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboMcode.SelectedIndex = cboMunicipality.SelectedIndex
            With clsBank
                .M_code = cboMcode.Text
                dsBarangay = .GetBarangayList
                clsCommon.PopulateComboBox(cboRurcode, cboBarangay, dsBarangay, Nothing, True)

                dsZipCode = .GetZipCodeList
                clsCommon.PopulateComboBox(cboZipCodeId, cboZipCodeArea, dsZipCode, cboZipCode, True)
            End With
            cboBarangay.SelectedIndex = 0
            cboZipCodeArea.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboBarangay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBarangay.SelectedIndexChanged
        If State <> VIEW_STATE Then
            cboRurcode.SelectedIndex = cboBarangay.SelectedIndex
        End If
    End Sub

    Private Sub cboZipCodeArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboZipCodeArea.SelectedIndexChanged
        If State <> VIEW_STATE Then
            Me.cboZipCodeId.SelectedIndex = Me.cboZipCodeArea.SelectedIndex
            Me.cboZipCode.SelectedIndex = Me.cboZipCodeArea.SelectedIndex
        End If
    End Sub

    Private Sub btnLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogo.Click
        Dim cdlOpen As New OpenFileDialog

        cdlOpen.Filter = "Image Files (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png) | *.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png | All Files | *.*"

        cdlOpen.ShowDialog()

        If File.Exists(cdlOpen.FileName) Then
            txtFileName.Text = cdlOpen.FileName
            Dim image1 As Bitmap = New Bitmap(cdlOpen.FileName)
            btnLogo.BackgroundImage = image1
            btnLogo.BackgroundImageLayout = ImageLayout.Zoom
            cmnuClear.Enabled = True
        End If
    End Sub

    Private Sub cmnuClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmnuClear.Click
        ClearImage()
        cmnuClear.Enabled = False
    End Sub

    Public Sub ClearImage()
        Dim image1 As Bitmap = New Bitmap(Me.GetType, "blank-logo.gif")
        btnLogo.BackgroundImage = image1
        btnLogo.BackgroundImageLayout = ImageLayout.Zoom
        txtFileName.Text = ""
    End Sub

#End Region

End Class