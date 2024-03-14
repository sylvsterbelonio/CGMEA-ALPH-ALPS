﻿Imports PowerNET8.myNumber.Share.Formatter
Public Class frmFS
    Private KeyPressChar As Long
    Private WithEvents clsCommon As New Common.Common
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private myObject As New PowerNET8.myObject
    Private colObjects As New Collection
    Public FSID As String = "0"
    Public action As String = "add"

    Private Sub initialize()
        Connect(mysql)
        myObject.get_all_objects_data(colObjects, Me)
        If action = "add" Then
            myObject.Clear_All(colObjects)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
        ElseIf action = "edit" Then
            reloadRecord()
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
        ElseIf action = "view" Then
            reloadRecord()
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.Yes)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.view)
        End If
        clsGeneral.autoSuggestTextBox(txtFSName, mysql, "FSType", "tbl_expenses_group")
        clsGeneral.autoSuggestTextBox(txtcategoryName, mysql, "category", "tbl_expenses_group")
        clsGeneral.autoSuggestTextBox(txtexpenseName, mysql, "name", "tbl_expenses_group")
    End Sub

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_expenses_group where FSID=" + FSID)
        If mydata.Rows.Count > 0 Then
            txtFSName.Text = mydata.Rows(0).Item("FSType")
            txtcategoryName.Text = mydata.Rows(0).Item("category")
            txtexpenseName.Text = mydata.Rows(0).Item("name")
        End If
    End Sub

    Private Sub frmExpensesFlow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        initialize()
    End Sub


    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    FSID = "0"
                    txtcategoryName.Text = ""
                    txtFSName.Text = ""
                    txtexpenseName.Text = ""
                    txtFSName.Focus()
                    clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
                    myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
                Case 1 'edit
edit_rec:
                    myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
                    clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
                Case 2 'delete
delete_rec:

                Case 3 'find
find_rec:
                    Me.Close()
                Case 4 'save
save_rec:
                    If txtFSName.Text <> "" And txtcategoryName.Text <> "" And txtexpenseName.Text <> "" Then
                        With mysql
                            .setTable("tbl_expenses_group")
                            .addValue(txtFSName.Text, "FSType")
                            .addValue(txtcategoryName.Text, "category")
                            .addValue(txtexpenseName.Text, "name")
                            .addValue(Now, "updatedDt")
                            .addValue(gUserID, "updatedBy")
                            If FSID = "0" Then
                                FSID = .nextID("FSID")
                                .addValue(FSID, "FSID")
                                .addValue(gUserID, "createdBy")
                                .addValue(Now, "createdDt")
                                .Insert()
                            Else
                                .Update("FSID", FSID)
                            End If
                        End With
                        MsgBox("You have successfully saved the record.", MsgBoxStyle.Information)

                        If clsCommon.GetRegistrySetting("Add New Record", "Disabled") = "" Then
                            Dim iAns
                            iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to add another record?" & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                            If iAns = vbYes Then
                                GoTo add_rec
                            ElseIf iAns = vbCancel Then
                                clsCommon.SaveRegistrySetting("Add New Record", "Disabled", "Yes")
                            End If
                        End If
                        myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.Yes)
                        clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.view)
                    Else
                        MsgBox("Please enter field of longterm and rate factor")
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
        End If
    End Sub

End Class