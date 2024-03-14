Public Class frmLoanRateFinder
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
    End Sub

    Private Sub reloadRecord()
        With myNav
            .set_class(mysql)
            .Set_SELECT("rateId,loanTerm AS 'LOAN TERM', rateFactor AS 'RATE FACTOR', tblsystemuser.userName as 'UPDATED BY', tblinsurancerate.updatedDt AS 'UPDATED DATE', tblinsurancerate.createdDt AS 'CREATED DATE'")
            .Set_FROM("tblsystemuser  right JOIN tblinsurancerate     ON (tblsystemuser.userId = tblinsurancerate.updatedBy)")
            .Set_ORDER("loanTerm")
            .Set_Data(dgvFinder)
            .Execute()

        End With
    End Sub

    Private Sub frmLoanRateFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        reloadRecord()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnSearch.Click, btnClear.Click, btnEdit.Click, btnView.Click
        Select Case CType(sender, Button).Text
            Case "&Search"
                If txtLongTerm.Text <> "" Then
                    myNav.Set_WHERE(" loanTerm = " + txtLongTerm.Text)
                Else
                    myNav.Set_WHERE("")
                End If
                myNav.Execute()
            Case "C&lear"
                txtLongTerm.Text = ""
            Case "&View"
                Dim frm As New frmLoanRate
                With frm
                    .rateID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "view"
                    .ShowDialog()
                End With
            Case "&Add"
                Dim frm As New frmLoanRate
                With frm
                    .rateID = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Dim frm As New frmLoanRate
                With frm
                    .rateID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "edit"
                    .ShowDialog()
                End With
            Case "&Use"

        End Select
    End Sub

    Private Sub txtLongTerm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLongTerm.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd_Click(btnSearch, Nothing)
        End If
    End Sub

    Private Sub txtLongTerm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLongTerm.LostFocus
        If Not IsNumeric(sender.text) Then
            txtLongTerm.Text = ""
        End If
    End Sub


    Private Sub dgvFinder_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFinder.MouseDoubleClick
        If dgvFinder.RowCount > 0 Then
            btnAdd_Click(btnView, Nothing)
        End If
    End Sub

    Private Sub txtLongTerm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLongTerm.TextChanged

    End Sub
End Class