Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml
Public Class frmMemberContributionAndDrawing
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsMemberContribution As New MemberContribution.MemberContribution
    Private WithEvents clsPersonnel As New Personnel.Personnel(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMember As New Personnel.Member.Member
    Private frmMemberConAndDrawingViewer As frmCrystalReportViewer
    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private dtMember As New DataTable

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsLoanApplicationReport As New DataSet
            Dim dtMember As DataTable
            Dim dtContribution As DataTable
            Dim dtDrawings As DataTable

            With clsMemberContribution
                dtMember = .Populate_Record_Member(txtMemberId.Text)
                dtContribution = .Populate_Member_Contribution_Report(txtMemberId.Text)
                dtDrawings = .Populate_Member_Drawings_Report(txtMemberId.Text)
            End With

            dtMember.TableName = "Member"
            dtContribution.TableName = "Contribution"
            dtDrawings.TableName = "Drawings"

            dsLoanApplicationReport.Tables.Add(dtMember)
            dsLoanApplicationReport.Tables.Add(dtContribution)
            dsLoanApplicationReport.Tables.Add(dtDrawings)

            frmMemberConAndDrawingViewer = New frmCrystalReportViewer

            dsLoanApplicationReport.DataSetName = "crptMemberAccountDetails"
            dsLoanApplicationReport.WriteXml(ReportDir + "\crptMemberAccountDetails.xml", XmlWriteMode.WriteSchema)
            dsLoanApplicationReport.WriteXmlSchema(ReportDir + "\" + "crptMemberAccountDetails.xsd")

            If dtMember.Rows.Count > 0 Then
                With frmMemberConAndDrawingViewer
                    .ds = dsLoanApplicationReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberContributionAndDrawings.rpt"
                    .ReportTitle = "Member Contribution and Drawings"
                    .ShowInTaskbar = False
                    .DisplayGroupTree = False
                    .MaximizeBox = True
                    .WindowState = FormWindowState.Maximized
                    .MinimizeBox = False
                    .ShowDialog()
                End With
            Else
                clsCommon.Prompt_User("information", "There are no records available for the corresponding report.")
            End If
            Me.Cursor = Arrow
        Catch ex As Exception
            clsCommon.Prompt_User("Error", ex.Message)
        End Try
    End Sub

    Private Sub frmMemberContributionAndDrawing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'member list
        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
        Dim autoSourceCollection As New AutoCompleteStringCollection()
        Dim drow As DataRow

        dtMember = clsDA.ExecuteQuery("SELECT memberId, TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) 'Name' FROM tblmember WHERE cancelFl = 0 AND retireFl = 0;", True, RETURN_TYPE_DATATABLE)
        txtMemberName.AutoCompleteSource = AutoCompleteSource.None

        For Each drow In dtMember.Rows
            autoSourceCollection.Add(drow.Item("Name"))
        Next

        txtMemberName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtMemberName.AutoCompleteCustomSource = autoSourceCollection
        txtMemberName.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub txtMemberName_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtMemberName.MouseUp
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        If TypeOf (sender) Is TextBox Then
            clsCommon.Disable_Field_Context_Menu(e, sender)
        End If
    End Sub

    Private Sub txtMemberName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMemberName.LostFocus
        ValidateMember(CStr(txtMemberName.Text))
    End Sub

    Private Sub ValidateMember(ByVal ColName As String)
        Try
            Dim mydata As New DataTable

            mydata = clsDataAccess.ExecuteQuery("SELECT memberId FROM tblmember WHERE TRIM(CONCAT(lastName, ', ', firstName, IF(LENGTH(suffixName)>0, CONCAT(' ', suffixName),''),IF(LENGTH(middleName)>0, CONCAT(' ', middleName),''))) = '" & Trim(txtMemberName.Text) & "' LIMIT 1;", True, RETURN_TYPE_DATATABLE)

            If mydata.Rows.Count <> 0 Then
                With clsMember
                    .Init_Flag = mydata.Rows(0).Item("memberId")
                    .Selected_Record()
                    txtMemberId.Text = .Member_Id
                End With
            Else
                txtMemberId.Text = ""
            End If
        Catch ex As Exception
            txtMemberId.Text = ""
        End Try
    End Sub

End Class