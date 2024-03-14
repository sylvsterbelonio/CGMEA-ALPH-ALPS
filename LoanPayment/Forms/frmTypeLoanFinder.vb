Public Class frmTypeLoanFinder
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
    End Sub

    Private Sub reloadRecord()
        With myNav
            .set_class(mysql)
            .Set_SELECT(" tbl_typeloan.NoId, `type`, terms_min, terms_max, interestRate,getfees(NoId) as 'fees', getRequirements(NoId) as 'Requirements'")
            .Set_FROM("tbl_typeloan")
            .Set_ORDER("`type`")
            .Set_Data(dgvFinder)
            .Execute()
            dgvFinder.Columns(0).Visible = False

            dgvFinder.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFinder.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFinder.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        End With
    End Sub

    Private Sub frmTypeLoanFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        reloadRecord()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click, btnClear.Click, btnAdd.Click, btnEdit.Click, btnView.Click
        Select Case CType(sender, Button).Text
            Case "&Search"
                Dim wh As String = ""
                Dim con As New PowerNET8.myString.Share.Concat
                If txtType.Text <> "" Then con.Append(wh, " `type` LIKE '" + txtType.Text + "%'", " and ")
                If txtFrom.Value <> 0 And txtTo.Value <> 0 Then con.Append(wh, " terms_min >= " + txtFrom.Value.ToString + " and terms_max <= " + txtTo.Value.ToString, " and ")
                If txtInterestRate.Text <> "" Then con.Append(wh, " interestRate >= " + txtInterestRate.Text, " and ")
                myNav.Set_WHERE(wh)
                myNav.Execute()
            Case "C&lear"
                txtFrom.Text = ""
                txtInterestRate.Text = ""
                txtTo.Value = 0
                txtFrom.Value = 0
            Case "&View"
                Dim frm As New frmTypeLoan
                With frm
                    .NoId = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "view"
                    .ShowDialog()
                End With
            Case "&Add"
                Dim frm As New frmTypeLoan
                With frm
                    .NoId = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Dim frm As New frmTypeLoan
                With frm
                    .NoId = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "edit"
                    .ShowDialog()
                End With
            Case "&Use"
        End Select
    End Sub

End Class