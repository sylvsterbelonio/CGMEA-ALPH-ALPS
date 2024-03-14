Public Class frmTypeLoanFinder
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
    End Sub

    Private Sub reloadRecord()
        With myNav
            .set_class(mysql)
            .Set_SELECT(" tbl_typeloan.NoId, `type` AS 'TYPE', terms_min AS 'TERMS MIN', terms_max AS 'TERMS MAX', interestRate AS 'INTEREST RATE', interestTerm AS 'DEDUCTION TERM', reloanRate AS 'RELOAN RATE', getfees(NoId) as 'FEES', getRequirements(NoId) as 'REQUIREMENTS', IF(activeFl=1,'YES','NO') as ACTIVE")
            .Set_FROM("tbl_typeloan")
            .Set_ORDER("`type`")
            .Set_Data(dgvFinder)
            .Execute()
            dgvFinder.Columns(0).Visible = False

            dgvFinder.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFinder.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFinder.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFinder.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvFinder.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
                Try
                    Dim frm As New frmTypeLoan
                    With frm
                        .NoId = dgvFinder.CurrentRow.Cells(0).Value.ToString
                        .action = "view"
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MsgBox("Please select a record")
                End Try
            Case "&Add"
                Dim frm As New frmTypeLoan
                With frm
                    .NoId = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Try
                    Dim frm As New frmTypeLoan
                    With frm
                        .NoId = dgvFinder.CurrentRow.Cells(0).Value.ToString
                        .action = "edit"
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MsgBox("Please select a record")
                End Try
            Case "&Use"
        End Select
    End Sub

    Private Sub dgvFinder_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFinder.MouseDoubleClick
        If dgvFinder.RowCount > 0 Then
            btnSearch_Click(btnView, Nothing)
        End If
    End Sub

    Private Sub txtType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtType.KeyDown, txtTo.KeyDown, txtInterestRate.KeyDown, txtFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(btnSearch, Nothing)
        End If
    End Sub

    Private Sub dgvFinder_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvFinder.CellFormatting
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim f As Font = dgvFinder.DefaultCellStyle.Font

        If dgvFinder.Rows(e.RowIndex).Cells("ACTIVE").Value = "NO" AndAlso dgvFinder.Rows(e.RowIndex).Cells("ACTIVE").Value IsNot DBNull.Value Then
            dgvFinder.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            dgvFinder.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(f, FontStyle.Strikeout Or FontStyle.Bold)
        End If
    End Sub

End Class