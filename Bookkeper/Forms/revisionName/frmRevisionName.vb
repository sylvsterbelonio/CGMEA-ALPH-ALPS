Imports PowerNET8.myNumber.Share.Formatter
Public Class frmRevisionName
    Private WithEvents clsCommon As New Common.Common
    Private KeyPressChar As Long
    Private myObject As New PowerNET8.myObject
    Private colObjects As New Collection
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Public revisionID As String = ""
    Public action As String = ""

    Private Sub initialize()
        Connect(mysql)
        myObject.get_all_objects_data(colObjects, Me)
        If action = "add" Then
            lblGetPrev.Visible = True
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
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_revisioncode where revisionID=" + revisionID)
        If mydata.Rows.Count > 0 Then
            revisionID = mydata.Rows(0).Item("revisionID")
            txtRevisionName.Text = mydata.Rows(0).Item("revisionName")
            txtRevisionCode.Text = mydata.Rows(0).Item("code")
            txtyearFrom.Text = mydata.Rows(0).Item("yearFrom")
            txtyearTo.Text = mydata.Rows(0).Item("yearTo")
            txtDescription.Text = mydata.Rows(0).Item("description")

            dgvDetails.Rows.Clear()
            mydata = mysql.Query("SELECT tbl_ref_varname.refID, varName, `value`  from    tbl_ref_varname   INNER JOIN  tbl_revisioncode_values     ON (tbl_ref_varname.refID = tbl_revisioncode_values.refID)  where tbl_revisioncode_values.revisionID=" + revisionID + " order by varName")

            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvDetails
                    .Rows.Add()
                    With .Rows(i)
                        .Cells(2).Value = mydata.Rows(i).Item("refID")
                        .Cells(3).Value = mydata.Rows(i).Item("varName")
                        .Cells(4).Value = mydata.Rows(i).Item("value")
                    End With
                End With
            Next
        End If
    End Sub

    Private Sub dgvDetails_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellClick
     
    End Sub

    Private Sub frmRevisionName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        initialize()
    End Sub

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    revisionID = "0"
                    txtRevisionName.Text = ""
                    txtRevisionCode.Text = ""
                    txtyearFrom.Text = ""
                    txtyearTo.Text = ""
                    txtDescription.Text = ""
                    txtRevisionName.Focus()
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
                    If txtRevisionName.Text <> "" And txtRevisionCode.Text <> "" Then
                        With mysql
                            .setTable("tbl_revisioncode")
                            .addValue(txtRevisionName.Text, "revisionName")
                            .addValue(txtRevisionCode.Text, "code")
                            .addValue(txtyearFrom.Text, "yearFrom")
                            .addValue(txtyearTo.Text, "yearTo")
                            .addValue(gUserID, "updatedBy")
                            .addValue(Now, "updatedDt")
                            If revisionID = "0" Then
                                revisionID = .nextID("revisionID")
                                .addValue(revisionID, "revisionID")
                                .addValue(gUserID, "createdBy")
                                .addValue(Now, "createdDt")
                                .Insert()
                            Else
                                .Update("revisionID", revisionID)
                            End If
                        End With

                        mysql.Query("DELETE FROM tbl_revisioncode_values where revisionID=" + revisionID)
                        For i As Integer = 0 To dgvDetails.RowCount - 2
                            With mysql
                                .setTable("tbl_revisioncode_values")
                                .addValue(revisionID, "revisionID")
                                .addValue(dgvDetails.Rows(i).Cells(2).Value, "refID")
                                .addValue(CDbl(dgvDetails.Rows(i).Cells(4).Value), "value")
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
                        lblGetPrev.Visible = False
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

    Private Sub dgvDetails_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellValidated
        Select Case dgvDetails.CurrentCell.ColumnIndex
            Case 4
                dgvDetails.CurrentRow.Cells(4).Value = format_DecimalOnly(dgvDetails.CurrentRow.Cells(4).Value, 2)
        End Select
    End Sub

    Private Sub lblGetPrev_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblGetPrev.LinkClicked
        Dim mydata As DataTable = mysql.Query("SELECT MAX(revisionID) from tbl_revisioncode")
        If mydata.Rows.Count > 0 Then
            dgvDetails.Rows.Clear()
            mydata = mysql.Query("SELECT tbl_ref_varname.refID, varName, `value`  from    tbl_ref_varname   INNER JOIN  tbl_revisioncode_values     ON (tbl_ref_varname.refID = tbl_revisioncode_values.refID)  where tbl_revisioncode_values.revisionID=" + mydata.Rows(0).Item(0).ToString + " order by varName")
            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvDetails
                    .Rows.Add()
                    With .Rows(i)
                        .Cells(2).Value = mydata.Rows(i).Item("refID")
                        .Cells(3).Value = mydata.Rows(i).Item("varName")
                        .Cells(4).Value = mydata.Rows(i).Item("value")
                    End With
                End With
            Next
        End If
        lblGetPrev.Visible = False
    End Sub

    Private Sub dgvDetails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetails.CellContentClick
        If dgvDetails.AllowUserToAddRows Then
            Select Case dgvDetails.CurrentCell.ColumnIndex
                Case 0
                    Dim frm As New frmrefVariableFinder
                    With frm
                        .action = "use"
                        .ShowDialog()
                        If .returnValue <> "" Then

                            Dim col() As String = .returnValue.Split("~")
                            If dgvDetails.CurrentRow.Cells(2).Value Is Nothing Then
                                dgvDetails.Rows.Add()
                                dgvDetails.Rows(dgvDetails.RowCount - 2).Cells(2).Value = col(0)
                                dgvDetails.Rows(dgvDetails.RowCount - 2).Cells(3).Value = col(1)
                            Else
                                dgvDetails.CurrentRow.Cells(2).Value = col(0)
                                dgvDetails.CurrentRow.Cells(3).Value = col(1)
                            End If
                        End If
                    End With
                Case 1
                    If MsgBox("Do you want to remove this record?", MsgBoxStyle.YesNo, "Remove Confirm") = MsgBoxResult.Yes Then
                        If dgvDetails.RowCount = 1 Then
                            dgvDetails.Rows(0).Cells(2).Value = ""
                            dgvDetails.Rows(0).Cells(3).Value = ""
                        Else
                            dgvDetails.Rows.Remove(dgvDetails.CurrentRow)
                        End If

                    End If
            End Select
        End If
    End Sub
End Class