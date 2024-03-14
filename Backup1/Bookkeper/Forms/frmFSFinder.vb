Imports PowerNET8.myString.Share

Public Class frmFSFinder
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
    End Sub

    Private Sub reloadRecord()
        With myNav
            .set_class(mysql)
            .Set_SELECT("FSID, FSType AS 'FS TYPE', category AS 'CATEGORY NAME', `name` AS 'EXPENSES NAME'")
            .Set_FROM("tbl_expenses_group")
            .Set_ORDER("FSType, category, name")
            .Set_Data(dgvFinder)
            .Execute()
        End With
        dgvFinder.Columns(0).Visible = False
    End Sub

    Private Sub frmFSFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        reloadRecord()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click, btnClear.Click, btnEdit.Click, btnSearch.Click, btnView.Click
        Select Case CType(sender, Button).Text
            Case "&Search"
                Dim wh As String = ""
                If txtFSName.Text <> "" Then Concat.Append(wh, " FSType like '" + txtFSName.Text + "%'", " and ")
                If txtcategoryName.Text <> "" Then Concat.Append(wh, " category like '" + txtcategoryName.Text + "%'", " and ")
                If txtExpensesName.Text <> "" Then Concat.Append(wh, " `name` like '" + txtExpensesName.Text + "%'", " and ")
                myNav.Execute()
            Case "C&lear"
                txtFSName.Text = ""
                txtcategoryName.Text = ""
                txtFSName.Text = ""
            Case "&View"
                Dim frm As New frmFS
                With frm
                    .FSID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "view"
                    .ShowDialog()
                End With
            Case "&Add"
                Dim frm As New frmFS
                With frm
                    .FSID = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Dim frm As New frmFS
                With frm
                    .FSID = dgvFinder.CurrentRow.Cells(0).Value.ToString
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmFSReport
        With frm
            .ShowDialog()
        End With
    End Sub
End Class