
Public Class frmrefVariableFinder
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Public returnValue As String = ""
    Public action = ""

    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
    End Sub

    Private Sub reloadRecord()
        With myNav
            .set_class(mysql)
            .Set_SELECT(" refID, `type` as 'TYPE', varName AS 'VARIABLE NAME', getSystemUser(updatedBy) as 'UPDATED BY', updatedDt AS 'UPDATED DATE', getSystemUser(createdBy) as 'CREATED BY', createdDt AS 'CREATED DATE'")
            .Set_FROM("tbl_ref_varname")
            .Set_ORDER("`type`, varName")
            .Set_Data(dgvFinder)
            .Execute()
            dgvFinder.Columns(0).Visible = False
        End With
    End Sub

    Private Sub frmrefVariableFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        reloadRecord()

        If action = "use" Then
            btnView.Text = "&Use"
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click, btnAdd.Click, btnClear.Click, btnEdit.Click, btnView.Click
        Select Case CType(sender, Button).Text
            Case "&Search"
                Dim wh As String = ""
                Dim con As New PowerNET8.myString.Share.Concat
                If txtType.Text <> "" Then con.Append(wh, " `type` LIKE '" + txtType.Text + "%'", " and ")
                If txtVariableName.Text <> "" Then con.Append(wh, " varname LIKE '" + txtVariableName.Text + "%'", " and ")
                myNav.Set_WHERE(wh)
                myNav.Execute()
            Case "C&lear"
                txtType.Text = ""
                txtVariableName.Text = ""
            Case "&View"
                Dim frm As New frmrefVariable
                With frm
                    .refID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "view"
                    .ShowDialog()
                End With
            Case "&Add"
                Dim frm As New frmrefVariable
                With frm
                    .refID = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Dim frm As New frmrefVariable
                With frm
                    .refID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                    .action = "edit"
                    .ShowDialog()
                End With
            Case "&Use"
                returnValue = dgvFinder.CurrentRow.Cells(0).Value.ToString + "~" + dgvFinder.CurrentRow.Cells(2).Value.ToString
                Me.Close()
        End Select
    End Sub

    Private Sub dgvFinder_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFinder.MouseDoubleClick
        If dgvFinder.RowCount > 0 Then
            If action = "use" Then
                returnValue = dgvFinder.CurrentRow.Cells(0).Value.ToString + "~" + dgvFinder.CurrentRow.Cells(2).Value.ToString
                Me.Close()
            Else
                btnSearch_Click(btnView, Nothing)
            End If

        End If
    End Sub

    Private Sub txtType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtType.KeyDown, txtVariableName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(btnSearch, Nothing)
        End If
    End Sub

    Private Sub dgvFinder_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFinder.CellContentClick

    End Sub
End Class