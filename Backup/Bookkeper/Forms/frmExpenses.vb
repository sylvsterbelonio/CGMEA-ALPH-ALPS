Imports PowerNET8.myNumber.Share.Formatter

Public Class frmExpenses
    Public EID As String
    Public action As String = "add"
    Private KeyPressChar As Long
    Private WithEvents clsCommon As New Common.Common
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private myObject As New PowerNET8.myObject
    Private colObjects As New Collection
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)

    Private WithEvents frmMemberFinder As Personnel.frmMemberFinder

    Private Sub initialize()
        Connect(mysql)
        reloadExpenses()
        myObject.get_all_objects_data(colObjects, Me)
        If action = "add" Then
            myObject.Clear_All(colObjects)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
            LinkLabel1.Visible = True
        ElseIf action = "edit" Then
            reloadRecord()
            LinkLabel1.Visible = True
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
        ElseIf action = "view" Then
            reloadRecord()
            LinkLabel1.Visible = False
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.Yes)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.view)
        End If
        clsGeneral.autoSuggestTextBox(txtPaidTo, mysql, "FSType", "tbl_expenses_group")

    End Sub

    Private Sub reloadExpenses()
        cboExpensesType.Items.Clear()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_expenses_group order by `name`")
        For i As Integer = 0 To mydata.Rows.Count - 1
            cboExpensesType.Items.Add(mydata.Rows(i).Item("name"))
        Next
    End Sub

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_expenses where EID=" + EID)
        If mydata.Rows.Count > 0 Then
            cboExpensesType.Text = mydata.Rows(0).Item("expensesName")
            txtAmount.Text = format_DecimalOnly(mydata.Rows(0).Item("amount"), 2)

            Dim dt As Date = mydata.Rows(0).Item("date_incurred")
            If dt.Year = 1700 Then
                dtpDateIncurred.Checked = False
            Else
                dtpDateIncurred.Checked = True
                dtpDateIncurred.Value = dt
            End If

            dt = mydata.Rows(0).Item("date_posted")
            If dt.Year = 1700 Then
                dtpDatePosted.Checked = False
            Else
                dtpDatePosted.Checked = True
                dtpDatePosted.Value = dt
            End If

            dt = mydata.Rows(0).Item("accountingCycle_from")
            If dt.Year = 1700 Then
                dtpACFrom.Checked = False
            Else
                dtpACFrom.Checked = True
                dtpACFrom.Value = dt
            End If

            txtCheckNo.Text = mydata.Rows(0).Item("voucherNo")
            txtVoucherNo.Text = mydata.Rows(0).Item("voucherNo")

            If mydata.Rows(0).Item("frmPerson") <> 0 Then
                frmPerson = mydata.Rows(0).Item("frmPerson")
                With clsMember
                    .Init_Flag = mydata.Rows(0).Item("frmPerson")
                    .Selected_Record()
                    txtPaidTo.Text = .First_Name + " " + .Middle_Name + " " + .Last_Name + " " + ._suffixName
                End With
                optPerson.Checked = True
            Else
                optEstablishment.Checked = True
                txtPaidTo.Text = mydata.Rows(0).Item("frmEstablishment")
                frmPerson = "0"
                clsGeneral.autoSuggestTextBox(txtPaidTo, mysql, "frmEstablishment", "tbl_expenses")
            End If


            dt = mydata.Rows(0).Item("accountingCycle_to")
            If dt.Year = 1700 Then
                dtpACTo.Checked = False
            Else
                dtpACTo.Checked = True
                dtpACTo.Value = dt
            End If

            txtReceiptNo.Text = mydata.Rows(0).Item("receiptNo")
            txtRemarks.Text = mydata.Rows(0).Item("remarks")
            'txtPaidTo.Text = mydata.Rows(0).Item("from")
        End If
    End Sub

    Private Sub frmExpenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)

        initialize()

    End Sub

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    EID = "0"
                    cboExpensesType.SelectedIndex = -1
                    txtAmount.Text = ""
                    dtpDateIncurred.Checked = False
                    dtpDatePosted.Checked = False
                    dtpACFrom.Checked = False
                    dtpACTo.Checked = False
                    txtReceiptNo.Text = ""
                    txtAmount.Text = "0.00"
                    txtPaidTo.Text = ""
                    txtRemarks.Focus()
                    cboExpensesType.Focus()
                    LinkLabel1.Visible = True
                    clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
                    myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
                Case 1 'edit
edit_rec:
                    LinkLabel1.Visible = True
                    myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
                    clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
                Case 2 'delete
delete_rec:

                Case 3 'find
find_rec:
                    Me.Close()
                Case 4 'save
save_rec:
                    If cboExpensesType.Text <> "" Then
                        With mysql
                            .setTable("tbl_expenses")
                            .addValue(cboExpensesType.Text, "expensesName")
                            .addValue(CDbl(txtAmount.Text), "amount")


                            If dtpDateIncurred.Checked = False Then
                                .addValue("1700-1-1", "date_incurred")
                            Else
                                .addValue(dtpDateIncurred.Value, "date_incurred")
                            End If
                            If dtpDatePosted.Checked = False Then
                                .addValue("1700-1-1", "date_posted")
                            Else
                                .addValue(dtpDatePosted.Value, "date_posted")
                            End If
                            If dtpACFrom.Checked = False Then
                                .addValue("1700-1-1", "accountingCycle_from")
                            Else
                                .addValue(dtpACFrom.Value, "accountingCycle_from")
                            End If
                            If dtpACTo.Checked = False Then
                                .addValue("1700-1-1", "accountingCycle_to")
                            Else
                                .addValue(dtpACTo.Value, "accountingCycle_to")
                            End If
                            .addValue(txtReceiptNo.Text, "receiptNo")
                            '.addValue(txtPaidTo.Text, "from")
                            .addValue(txtRemarks.Text, "remarks")

                            If optPerson.Checked Then
                                .addValue(frmPerson, "frmPerson")
                                .addValue("", "frmEstablishment")
                            Else
                                .addValue(txtPaidTo.Text, "frmEstablishment")
                                .addValue("0", "frmPerson")
                            End If
                            .addValue(txtCheckNo.Text, "checkNo")
                            .addValue(txtVoucherNo.Text, "voucherNo")
                            .addValue(Now, "updatedDt")
                            .addValue(gUserID, "updatedBy")
                            If EID = "0" Then
                                EID = .nextID("EID")
                                .addValue(EID, "EID")
                                .addValue(gUserID, "createdBy")
                                .addValue(Now, "createdDt")
                                Dim vali As DataTable = mysql.Query("SELECT * FROM tbl_expenses where EID=" + EID)
                                If vali.Rows.Count = 0 Then
                                    .Insert()
                                Else
                                    MsgBox("Duplication of expenses name, please try another expenses name.", MsgBoxStyle.Critical)
                                    Exit Sub
                                End If
                            Else
                                .Update("EID", EID)
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
                    LinkLabel1.Visible = False
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

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus
        txtAmount.Text = format_DecimalOnly(txtAmount.Text, 2)
    End Sub

    Private Sub txtAmount_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAmount.MouseClick
        sender.selectall()
    End Sub

    Private WithEvents clsMember As New Personnel.Member.Member
    Private frmPerson As String = "0"

    Private Sub frmMemberFinder_Use_Clicked(ByVal Record_Id As Integer, ByVal Record_Name As String, ByVal Record_Cd As String) Handles frmMemberFinder.Use_Clicked
        If Record_Name Is Nothing Then
            Return
        End If
        frmPerson = Record_Id
        With clsMember
            .Init_Flag = Record_Id
            .Selected_Record()
            txtPaidTo.Text = .First_Name + " " + .Middle_Name + " " + .Last_Name + " " + ._suffixName
        End With
    End Sub

    Private Sub txtFrom_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtPaidTo.MouseClick
        If optPerson.Checked Then
            frmMemberFinder = clsPersonnel.NewfrmMemberFinder
            clsPersonnel.UseRecordState = USE_STATE
            With frmMemberFinder
                .frmMainUser = Me
                .MaximizeBox = False
                .MinimizeBox = False
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub optPerson_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPerson.Click, optEstablishment.Click
        If optPerson.Checked Then
            txtPaidTo.Text = ""
        Else
            txtPaidTo.Text = ""
            frmPerson = "0"
            clsGeneral.autoSuggestTextBox(txtPaidTo, mysql, "frmEstablishment", "tbl_expenses")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New frmFSFinder
        With frm
            .ShowDialog()
            reloadExpenses()
        End With
    End Sub

    Private Sub dtpACFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpACFrom.ValueChanged
        Dim dt As Date = dtpACFrom.Value
        If dt.Month >= 1 And dt.Month <= 10 Then
            dtpACTo.Value = New Date(dt.Year, 10, 1)
        Else
            dtpACTo.Value = New Date(dt.Year + 1, 10, 30)
        End If
    End Sub

    Private Sub dtpACTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpACTo.ValueChanged

    End Sub
End Class