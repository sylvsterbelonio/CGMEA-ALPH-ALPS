Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmContributionAndPaymentSummary

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsContributionAndPayment As New ContributionAndPayment.ContributionAndPayment
    Private frmMemberLoanPaymentDetailReportViewer As frmCrystalReportViewer

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsMemberLoanPaymentListReport As New DataSet
            Dim dtMemberLoanPayment As DataTable
            Dim dtSystemUser As DataTable

            With clsContributionAndPayment
                dtMemberLoanPayment = .Populate_Member_ContributionAndPayment_List_Report(Format(dtpLoanPaymentDate.Value, "yyyy-MM-dd"))
                dtSystemUser = .System_User_Report
            End With

            dtMemberLoanPayment.TableName = "MemberContributionAndPayment"
            dtSystemUser.TableName = "SystemUser"

            dsMemberLoanPaymentListReport.Tables.Add(dtMemberLoanPayment)
            dsMemberLoanPaymentListReport.Tables.Add(dtSystemUser)

            frmMemberLoanPaymentDetailReportViewer = New frmCrystalReportViewer

            dsMemberLoanPaymentListReport.DataSetName = "crptMemberContributionAndPaymentSummary"
            dsMemberLoanPaymentListReport.WriteXml(ReportDir + "\crptMemberContributionAndPaymentSummary.xml", XmlWriteMode.WriteSchema)
            dsMemberLoanPaymentListReport.WriteXmlSchema(ReportDir + "\" + "crptMemberContributionAndPaymentSummary.xsd")

            If dtMemberLoanPayment.Rows.Count > 0 Then
                With frmMemberLoanPaymentDetailReportViewer
                    .ds = dsMemberLoanPaymentListReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberContributionAndPaymentSummary.rpt"
                    .ReportTitle = "Member Contribution And Loan Payment Summary"
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