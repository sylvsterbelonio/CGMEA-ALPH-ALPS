Imports PowerNET8.myString.Share

Public Class frmExpensesFinder
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
    End Sub

    Private Sub reloadRecord()
        With myNav
            .set_class(mysql)
            .Set_SELECT("EID,receiptNo as 'RECEIPT NO', expensesName AS 'EXPENSE NAME', amount AS 'AMOUNT', `date_incurred` AS 'DATE INCURRED'")
            .Set_FROM("tbl_expenses")
            .Set_ORDER("expensesName")
            .Set_Data(dgvFinder)
            .Execute()
        End With
        dgvFinder.Columns(0).Visible = False
    End Sub

    Private Sub frmExpensesFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        reloadRecord()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnClear.Click, btnEdit.Click, btnSearch.Click, btnView.Click
        Select Case CType(sender, Button).Text
            Case "&Search"
                Dim wh As String = ""
                If txtReceiptNo.Text <> "" Then Concat.Append(wh, " receiptNo like '" + txtReceiptNo.Text + "%'", " and ")
                If cboExpensesType.SelectedIndex <> -1 Then Concat.Append(wh, " expensesName like '" + cboExpensesType.Text + "%'", " and ")
                If txtFrom.Text <> "" Then Concat.Append(wh, " `from` like '" + txtFrom.Text + "%'", " and ")
                myNav.Execute()
            Case "C&lear"
                txtReceiptNo.Text = ""
                cboExpensesType.SelectedIndex = -1
                txtFrom.Text = ""
            Case "&View"
                Dim frm As New frmExpenses
                With frm
                    .EID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "view"
                    .ShowDialog()
                End With
            Case "&Add"
                Dim frm As New frmExpenses
                With frm
                    .EID = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Dim frm As New frmExpenses
                With frm
                    .EID = "0"
                    .action = "edit"
                    .ShowDialog()
                End With
            Case "&Use"

        End Select
    End Sub

    Private Sub dgvFinder_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFinder.MouseDoubleClick
        If dgvFinder.RowCount > 0 Then
            btnAdd_Click(btnView, Nothing)
        End If
    End Sub

End Class