Public Class frmTypeLoan
    Public NoId As String = ""
    Public action As String = "add"

    Private WithEvents clsCommon As New Common.Common
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private KeyPressChar As Long
    Private myObject As New PowerNET8.myObject
    Private colObjects As New Collection

    Private Sub initialize()
        Connect(mysql)
        myObject.get_all_objects_data(colObjects, Me)
        If action = "add" Then
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
    End Sub

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_typeloan where NoId=" + NoId)
        If mydata.Rows.Count > 0 Then
            txtSalary.Text = mydata.Rows(0).Item("type")
            txtMin.Text = mydata.Rows(0).Item("terms_min")
            txtMax.Text = mydata.Rows(0).Item("terms_max")
            txtInterestRate.Text = mydata.Rows(0).Item("interestRate")
        End If

        dgvRequirements.Rows.Clear()
        mydata = mysql.Query("SELECT * FROM tbl_typeloan_requirements where NoId=" + NoId + " order by requirements")
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvRequirements
                .Rows.Add()
                With .Rows(i)
                    .Cells(0).Value = mydata.Rows(i).Item(1).ToString
                End With
            End With
        Next

        dgvFees.Rows.Clear()
        mydata = mysql.Query("SELECT * FROM tbl_typeloan_fees where NoId=" + NoId + " order by fees")
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvFees
                .Rows.Add()
                With .Rows(i)
                    .Cells(0).Value = mydata.Rows(i).Item(1).ToString
                End With
            End With
        Next
    End Sub

    Private Sub frmTypeLoan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        initialize()
    End Sub

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    NoId = "0"
                    txtInterestRate.Text = ""
                    txtMax.Value = 0
                    txtMin.Value = 0
                    txtSalary.Text = ""
                    txtSalary.Focus()
                    dgvFees.Rows.Clear()
                    dgvRequirements.Rows.Clear()
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
                    If txtSalary.Text <> "" And txtInterestRate.Text <> "" Then
                        With mysql
                            .setTable("tbl_typeloan")
                            .addValue(txtSalary.Text, "type")
                            .addValue(txtMin.Value, "terms_min")
                            .addValue(txtMax.Value, "terms_max")
                            .addValue(txtInterestRate.Text, "interestRate")
                            .addValue(guserID, "updatedBy")
                            .addValue(Now, "updatedDt")
                            If NoId = "0" Then
                                NoId = .nextID("NoId")
                                .addValue(NoId, "NoId")
                                .addValue(guserID, "createdBy")
                                .addValue(Now, "createdDt")
                                .Insert()
                            Else
                                .Update("NoId", NoId)
                            End If
                        End With

                        mysql.Query("DELETE FROM tbl_typeloan_requirements where NoId=" + NoId)
                        For i As Integer = 0 To dgvRequirements.RowCount - 2
                            With mysql
                                .setTable("tbl_typeloan_requirements")
                                .addValue(NoId, "NoId")
                                .addValue(dgvRequirements.Rows(i).Cells(0).Value, "requirements")
                                .Insert()
                            End With
                        Next

                        mysql.Query("DELETE FROM tbl_typeloan_fees where NoId=" + NoId)
                        For i As Integer = 0 To dgvFees.RowCount - 2
                            With mysql
                                .setTable("tbl_typeloan_fees")
                                .addValue(NoId, "NoId")
                                .addValue(dgvFees.Rows(i).Cells(0).Value, "fees")
                                .Insert()
                            End With
                        Next

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
                        MsgBox("Please enter field of type, ")
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

    Private Sub dgvRequirements_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRequirements.EditingControlShowing
        Dim c As TextBox = e.Control

        Dim mydata As DataTable = mysql.Query("SELECT DISTINCT requirements from tbl_typeloan_requirements")

        For i As Integer = 0 To mydata.Rows.Count - 1
            c.AutoCompleteCustomSource.Add(mydata.Rows(i).Item(0))
        Next
        c.CharacterCasing = CharacterCasing.Upper
        c.AutoCompleteMode = AutoCompleteMode.Suggest
        c.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub

    Private Sub txtInterestRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInterestRate.LostFocus
        If Not IsNumeric(txtInterestRate.Text) Then
            sender.text = "0"
        End If
    End Sub

    Private Sub dgvFees_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvFees.EditingControlShowing
        Dim c As TextBox = e.Control

        Dim mydata As DataTable = mysql.Query("SELECT DISTINCT fees from tbl_typeloan_fees")

        For i As Integer = 0 To mydata.Rows.Count - 1
            c.AutoCompleteCustomSource.Add(mydata.Rows(i).Item(0))
        Next
        c.CharacterCasing = CharacterCasing.Upper
        c.AutoCompleteMode = AutoCompleteMode.Suggest
        c.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
End Class