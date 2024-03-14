Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmMemberContributionSummary

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsMemberContribution As New MemberContribution.MemberContribution
    Private frmMemberContributionReportViewer As frmCrystalReportViewer

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsMemberContributionListReport As New DataSet
            Dim dtMemberContribution As DataTable
            Dim dtSystemUser As DataTable

            With clsMemberContribution
                dtMemberContribution = .Populate_Member_Contribution_List_Report(Format(dtpDate.Value, "yyyy-MM-dd"))
                dtSystemUser = .System_User_Report
            End With

            dtMemberContribution.TableName = "MemberContribution"
            dtSystemUser.TableName = "SystemUser"

            dsMemberContributionListReport.Tables.Add(dtMemberContribution)
            dsMemberContributionListReport.Tables.Add(dtSystemUser)

            frmMemberContributionReportViewer = New frmCrystalReportViewer

            dsMemberContributionListReport.DataSetName = "crptMemberContributionSummary"
            dsMemberContributionListReport.WriteXml(ReportDir + "\crptMemberContributionSummary.xml", XmlWriteMode.WriteSchema)
            dsMemberContributionListReport.WriteXmlSchema(ReportDir + "\" + "crptMemberContributionSummary.xsd")

            If dtMemberContribution.Rows.Count > 0 Then
                With frmMemberContributionReportViewer
                    .ds = dsMemberContributionListReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberContributionSummary.rpt"
                    .ReportTitle = "Member Contribution Summary"
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

End Class