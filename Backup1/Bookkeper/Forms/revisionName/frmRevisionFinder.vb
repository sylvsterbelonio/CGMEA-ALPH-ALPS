Public Class frmRevisionFinder
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
            .Set_SELECT(" revisionID, revisionName as 'REVISION NAME', code as 'CODE', yearFrom as 'YEAR FROM', yearTo as 'YEAR TO', description as 'DESCRIPTION', getSystemUser(updatedBy) as 'UPDATED BY', updatedDt as 'UPDATED DATE', getSystemUser(createdBy) as 'CREATED BY',createdDt AS 'CREATED DATE'")
            .Set_FROM("tbl_revisioncode")
            .Set_ORDER("revisionName")
            .Set_Data(dgvFinder)
            .Execute()
            dgvFinder.Columns(0).Visible = False
        End With
    End Sub

    Private Sub frmRevisionFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
        reloadRecord()

        If action = "use" Then
            btnView.Text = "&Use"
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click, btnClear.Click, btnAdd.Click, btnEdit.Click, btnView.Click
        Select Case CType(sender, Button).Text
            Case "&Search"
                Dim wh As String = ""
                Dim con As New PowerNET8.myString.Share.Concat
                If txtRevisionName.Text <> "" Then con.Append(wh, " revisionName LIKE '" + txtRevisionName.Text + "%'", " and ")
                If txtRevisionCode.Text <> "" Then con.Append(wh, " code LIKE '" + txtRevisionCode.Text + "%'", " and ")
                If txtYearFrom.Text <> "" Then con.Append(wh, " yearFrom =" + txtYearFrom.Text + "", " and ")
                If txtYearTo.Text <> "" Then con.Append(wh, " yearTo =" + txtYearTo.Text + "", " and ")
                myNav.Set_WHERE(wh)
                myNav.Execute()
            Case "C&lear"
                txtRevisionCode.Text = ""
                txtRevisionName.Text = ""
                txtYearFrom.Text = ""
                txtYearTo.Text = ""
            Case "&View"
                Dim frm As New frmRevisionName
                With frm
                    Try
                        .revisionID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                        .action = "view"
                        .ShowDialog()
                    Catch ex As Exception
                        MsgBox("Please select a record")
                    End Try
                End With
            Case "&Add"
                Dim frm As New frmRevisionName
                With frm
                    .revisionID = "0"
                    .action = "add"
                    .ShowDialog()
                End With
            Case "&Edit"
                Try
                    Dim frm As New frmRevisionName
                    With frm
                        .revisionID = dgvFinder.CurrentRow.Cells(0).Value.ToString
                        .action = "edit"
                        .ShowDialog()
                    End With
                Catch ex As Exception
                    MsgBox("Please select a record")
                End Try
            Case "&Use"
                returnValue = dgvFinder.CurrentRow.Cells(0).Value.ToString + "~" + dgvFinder.CurrentRow.Cells(2).Value.ToString
                Me.Close()
        End Select
    End Sub

    Private Sub dgvFinder_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgvFinder.MouseDoubleClick
        If dgvFinder.RowCount > 0 Then
            If action = "use" Then
                returnValue = returnValue = dgvFinder.CurrentRow.Cells(0).Value.ToString + "~" + dgvFinder.CurrentRow.Cells(2).Value.ToString
                Me.Close()
            Else
                btnSearch_Click(btnView, Nothing)
            End If
        End If
    End Sub

    Private Sub txtYearFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYearFrom.LostFocus, txtYearTo.LostFocus
        If Not IsNumeric(CType(sender, TextBox).Text) Then
            sender.text = Now.ToString
        End If
    End Sub

    Private Sub txtRevisionName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRevisionName.KeyDown, txtRevisionCode.KeyDown, txtYearFrom.KeyDown, txtYearTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(btnSearch, Nothing)
        End If
    End Sub
End Class