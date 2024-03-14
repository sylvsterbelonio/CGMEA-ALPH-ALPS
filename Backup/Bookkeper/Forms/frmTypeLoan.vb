Imports PowerNET8.myNumber.Share.Formatter
Public Class frmTypeLoan
    Public NoId As String = "0"
    Public action As String = "add"

    Private WithEvents clsCommon As New Common.Common
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Private KeyPressChar As Long
    Private myObject As New PowerNET8.myObject
    Private colObjects As New Collection
    Private lstRevisionID As New ArrayList

    Private Sub initialize()
        Connect(mysql)
        myObject.get_all_objects_data(colObjects, Me)
        reloadRevisionCode()
        reloadRequirements()

        If action = "add" Then
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
        ElseIf action = "edit" Then
            reloadRecord()
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
            dgvFees.AllowUserToAddRows = False
            dgvRequirements.AllowUserToAddRows = False
        ElseIf action = "view" Then
            reloadRecord()
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.Yes)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.view)
        End If
    End Sub

    Private Sub reloadRequirements(Optional ByVal ID As String = "")
        If ID = "" Then
            Dim mydata As DataTable = mysql.Query("select refID, varName from tbl_ref_varname where `type` = 'typeLoan requirements'")
            dgvRequirements.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvRequirements
                    .Rows.Add()
                    With .Rows(i)
                        .Cells(0).Value = mydata.Rows(i).Item("refID")
                        .Cells(1).Value = mydata.Rows(i).Item("varName")
                        .Cells(2).Value = 0
                    End With
                End With
            Next
        Else
            Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_typeloan_requirements where NoId=" + ID)
            For i As Integer = 0 To mydata.Rows.Count - 1
                For ii As Integer = 0 To dgvRequirements.RowCount - 1
                    If mydata.Rows(i).Item("refID") = dgvRequirements.Rows(ii).Cells(0).Value Then
                        dgvRequirements.Rows(ii).Cells(2).Value = 1
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub reloadRevisionCode()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_revisioncode order by revisionID")
        cboRevision.Items.Clear()
        lstRevisionID.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            cboRevision.Items.Add(mydata.Rows(i).Item("code"))
            lstRevisionID.Add(mydata.Rows(i).Item("revisionID"))
        Next
        cboRevision.SelectedIndex = mydata.Rows.Count - 1
    End Sub

    Private Sub reloadFees(Optional ByVal ID As String = "", Optional ByVal revisionID As String = "0")
        If ID = "" Then
            'Dim mydata As DataTable = mysql.Query("SELECT tbl_ref_varname.refID,tbl_ref_varname.varName,tbl_revisioncode_values.value FROM    tbl_revisioncode_values  INNER JOIN  tbl_ref_varname     ON (tbl_revisioncode_values.refID = tbl_ref_varname.refID) where tbl_revisioncode_values.revisionID=" + revisionID)
            Dim mydata As DataTable = mysql.Query("SELECT tblcollectionfee.feeId, tblcollectiontype.typeName,tblcollectionfee.feeDefault FROM tblcollectionfee  INNER JOIN  tblcollectiontype  ON (tblcollectionfee.typeId = tblcollectiontype.typeId) WHERE tblcollectiontype.loanRequired = 1 AND tblcollectionfee.revisionId=" + revisionID)
            dgvFees.Rows.Clear()
            For i As Integer = 0 To mydata.Rows.Count - 1
                With dgvFees
                    .Rows.Add()
                    With .Rows(i)
                        .Cells(0).Value = mydata.Rows(i).Item("feeId")
                        .Cells(1).Value = mydata.Rows(i).Item("typeName")
                        .Cells(2).Value = format_DecimalOnly(mydata.Rows(i).Item("feeDefault"), 2)
                        .Cells(3).Value = 0
                    End With
                End With
            Next
        Else

            Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_typeloan_fees where NoId=" + ID)
            For i As Integer = 0 To mydata.Rows.Count - 1
                For ii As Integer = 0 To dgvFees.Rows.Count - 1
                    If mydata.Rows(i).Item("refID") = dgvFees.Rows(ii).Cells(0).Value Then
                        dgvFees.Rows(ii).Cells(3).Value = 1
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_typeloan where NoId=" + NoId)
        If mydata.Rows.Count > 0 Then
            txtLoanType.Text = mydata.Rows(0).Item("type")
            txtMin.Text = mydata.Rows(0).Item("terms_min")
            txtMax.Text = mydata.Rows(0).Item("terms_max")
            txtMinAmount.Text = format_DecimalOnly(mydata.Rows(0).Item("amount_min"), 2)
            txtMaxAmount.Text = format_DecimalOnly(mydata.Rows(0).Item("amount_max"), 2)
            txtInterestRate.Text = Format(mydata.Rows(0).Item("interestRate"), "Standard")
            txtDeductionTerm.Text = mydata.Rows(0).Item("interestTerm")
            txtReloanRate.Text = Format(mydata.Rows(0).Item("reloanRate"), "Standard")
            If mydata.Rows(0).Item("activeFl") = 1 Then
                chkActive.Checked = True
            Else
                chkActive.Checked = False
            End If
            mydata = mysql.Query("SELECT * from tbl_revisioncode where revisionID=" + mydata.Rows(0).Item("revisionID").ToString)
            If mydata.Rows.Count > 0 Then cboRevision.Text = mydata.Rows(0).Item("code")
        End If
        reloadRequirements(NoId)
        reloadFees(NoId)
        'dgvRequirements.Rows.Clear()
        'mydata = mysql.Query("SELECT * FROM tbl_typeloan_requirements where NoId=" + NoId + " order by requirements")
        'For i As Integer = 0 To mydata.Rows.Count - 1
        '    With dgvRequirements
        '        .Rows.Add()
        '        With .Rows(i)
        '            .Cells(0).Value = mydata.Rows(i).Item(1).ToString
        '        End With
        '    End With
        'Next

        'dgvFees.Rows.Clear()
        'mydata = mysql.Query("SELECT * FROM tbl_typeloan_fees where NoId=" + NoId + " order by fees")
        'For i As Integer = 0 To mydata.Rows.Count - 1
        '    With dgvFees
        '        .Rows.Add()
        '        With .Rows(i)
        '            .Cells(0).Value = mydata.Rows(i).Item(1).ToString
        '        End With
        '    End With
        'Next
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
                    txtInterestRate.Text = "0.00"
                    txtMax.Value = 0
                    txtMin.Value = 0
                    txtDeductionTerm.Text = "0"
                    txtReloanRate.Text = "0.00"
                    chkActive.Checked = True
                    txtLoanType.Text = ""
                    txtLoanType.Focus()
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
                    If txtLoanType.Text <> "" And txtInterestRate.Text <> "" Then
                        With mysql
                            .setTable("tbl_typeloan")
                            .addValue(lstRevisionID.Item(cboRevision.SelectedIndex), "revisionID")
                            .addValue(txtLoanType.Text, "type")
                            .addValue(txtMin.Value, "terms_min")
                            .addValue(txtMax.Value, "terms_max")
                            .addValue(CDbl(txtMinAmount.Text), "amount_min")
                            .addValue(CDbl(txtMaxAmount.Text), "amount_max")
                            If IsNumeric(txtInterestRate.Text) Then .addValue(Val(txtInterestRate.Text), "interestRate")
                            If IsNumeric(txtDeductionTerm.Text) Then .addValue(Val(txtDeductionTerm.Text), "interestTerm")
                            If IsNumeric(txtReloanRate.Text) Then .addValue(Val(txtReloanRate.Text), "reloanRate")
                            If chkActive.Checked = True Then
                                .addValue(1, "activeFl")
                            Else
                                .addValue(0, "activeFl")
                            End If
                            'If chkActive.Checked = True Then .addValue(1, "reloanRate")
                            .addValue(gUserID, "updatedBy")
                            .addValue(Now, "updatedDt")
                            If NoId = "0" And txtLoanType.Text <> "OTHERS" Then
                                NoId = .nextID("NoId")
                                .addValue(NoId, "NoId")
                                .addValue(gUserID, "createdBy")
                                .addValue(Now, "createdDt")
                                .Insert()
                            Else
                                .Update("NoId", NoId)
                            End If
                        End With

                        mysql.Query("DELETE FROM tbl_typeloan_requirements where NoId=" + NoId)
                        For i As Integer = 0 To dgvRequirements.RowCount - 1
                            With mysql
                                .setTable("tbl_typeloan_requirements")
                                .addValue(NoId, "NoId")
                                .addValue(dgvRequirements.Rows(i).Cells(0).Value, "refID")
                                If dgvRequirements.Rows(i).Cells(2).Value Then
                                    .Insert()
                                End If
                            End With
                        Next

                        mysql.Query("DELETE FROM tbl_typeloan_fees where NoId=" + NoId)
                        For i As Integer = 0 To dgvFees.RowCount - 1
                            With mysql
                                .setTable("tbl_typeloan_fees")
                                .addValue(NoId, "NoId")
                                .addValue(dgvFees.Rows(i).Cells(0).Value, "refID")
                                If dgvFees.Rows(i).Cells(3).Value Then
                                    .Insert()
                                End If
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
        'Dim c As TextBox = e.Control

        'Dim mydata As DataTable = mysql.Query("SELECT DISTINCT requirements from tbl_typeloan_requirements")

        'For i As Integer = 0 To mydata.Rows.Count - 1
        '    c.AutoCompleteCustomSource.Add(mydata.Rows(i).Item(0))
        'Next
        'c.CharacterCasing = CharacterCasing.Upper
        'c.AutoCompleteMode = AutoCompleteMode.Suggest
        'c.AutoCompleteSource = AutoCompleteSource.CustomSource

    End Sub

    Private Sub txtInterestRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtInterestRate.LostFocus
        If Not IsNumeric(txtInterestRate.Text) Then
            sender.text = "0"
        End If
    End Sub

    Private Sub dgvFees_CellValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFees.CellValidated
        Select Case dgvFees.CurrentCell.ColumnIndex
            Case 2
                dgvFees.CurrentRow.Cells(2).Value = format_DecimalOnly(dgvFees.CurrentRow.Cells(2).Value, 2)
        End Select
    End Sub

    Private Sub dgvFees_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvFees.EditingControlShowing
        'Dim c As TextBox = e.Control

        'Dim mydata As DataTable = mysql.Query("SELECT DISTINCT fees from tbl_typeloan_fees")

        'For i As Integer = 0 To mydata.Rows.Count - 1
        '    c.AutoCompleteCustomSource.Add(mydata.Rows(i).Item(0))
        'Next
        'c.CharacterCasing = CharacterCasing.Upper
        'c.AutoCompleteMode = AutoCompleteMode.Suggest
        'c.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub


    Private Sub cboRevision_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRevision.SelectedIndexChanged
        If cboRevision.SelectedIndex <> -1 Then
            reloadFees(, lstRevisionID.Item(cboRevision.SelectedIndex))
        End If
    End Sub

    Private Sub dgvFees_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFees.CellContentClick

    End Sub

    Private Sub txtMinAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMinAmount.LostFocus, txtMaxAmount.LostFocus
        sender.text = format_DecimalOnly(sender.text, 2)
    End Sub

    Private Sub txtMinAmount_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMinAmount.MouseClick, txtMaxAmount.MouseClick, txtInterestRate.MouseClick
        sender.selectall()
    End Sub

End Class