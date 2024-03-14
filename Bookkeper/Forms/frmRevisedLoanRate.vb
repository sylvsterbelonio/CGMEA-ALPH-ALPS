Public Class frmRevisedLoanRate
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Public revisionID As String = ""
    Private lstRevisionID As New ArrayList
    Private Sub initialize()
        Connect(mysql)
        PowerNET8.myControls.Share.Datagridviews.rowIndexNumber.add(dgvFinder)
        reloadRevisionCode()
        reloadRevisionName()
        reloadRecord()
    End Sub

    Private Sub reloadRevisionCode()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tbl_revisioncode order by revisionID")
        cboRevisionCode.Items.Clear()
        lstRevisionID.Clear()
        For i As Integer = 0 To mydata.Rows.Count - 1
            cboRevisionCode.Items.Add(mydata.Rows(i).Item("code"))
            lstRevisionID.Add(mydata.Rows(i).Item("revisionID"))
        Next
        cboRevisionCode.SelectedIndex = mydata.Rows.Count - 1
    End Sub

    Private Sub reloadRevisionName()
        Dim mydata As DataTable = mysql.Query("SELECT  code from tbl_revisioncode where revisionID=" + revisionID)
        If mydata.Rows.Count > 0 Then
            cboRevisionCode.Text = mydata.Rows(0).Item(0).ToString
        End If
    End Sub

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblinsurancerate where revisionID=" + lstRevisionID.Item(cboRevisionCode.SelectedIndex).ToString + " order by rateId")
        For i As Integer = 0 To mydata.Rows.Count - 1
            With dgvFinder
                .Rows.Add()
                With .Rows(i)
                    .Cells(1).Value = mydata.Rows(i).Item("loanTerm")
                    .Cells(2).Value = mydata.Rows(i).Item("rateFactor")
                End With
            End With
        Next
    End Sub
    Private Sub frmRevisedLoanRate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        initialize()
    End Sub

    Private Function formatDigit(ByVal value As Integer) As String
        If value.ToString.Length = 1 Then
            Return "000" + (value + 1).ToString
        ElseIf value.ToString.Length = 2 Then
            Return "00" + (value + 1).ToString
        ElseIf value.ToString.Length = 3 Then
            Return "0" + (value + 1).ToString
        Else
            Return (value + 1).ToString()
        End If
    End Function

    Private Function getNextID() As String
        Dim mydata As DataTable = mysql.Query("SELECT MAX(rateID) from tblinsurancerate")
        If mydata.Rows.Count > 0 Then
            Dim curID As String = mydata.Rows(0).Item(0).ToString.Substring(4)
            Return Now.Year.ToString + formatDigit(Val(curID))
        End If
    End Function

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblinsurancerate where revisionID=" + lstRevisionID.Item(cboRevisionCode.SelectedIndex).ToString)
        If mydata.Rows.Count = 0 Then
            If MsgBox("Are you sure you want to add this new revision code?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For i As Integer = 0 To dgvFinder.RowCount - 1
                    With mysql
                        .setTable("tblinsurancerate")
                        .addValue(getNextID, "rateID")
                        .addValue(lstRevisionID.Item(cboRevisionCode.SelectedIndex).ToString, "revisionID")
                        .addValue(CDbl(dgvFinder.Rows(i).Cells(1).Value), "loanTerm")
                        .addValue(CDbl(dgvFinder.Rows(i).Cells(2).Value), "rateFactor")
                        .addValue(gUserID, "updatedBy")
                        .addValue(Now, "updatedDt")
                        .addValue(gUserID, "createdBy")
                        .addValue(Now, "createdDt")
                        .Insert()
                    End With
                Next
                MsgBox("Record has been added!")
                Me.Close()
            End If
        Else
            MsgBox("This revision is already used. Please try another unused revision code.")
        End If
    End Sub
End Class