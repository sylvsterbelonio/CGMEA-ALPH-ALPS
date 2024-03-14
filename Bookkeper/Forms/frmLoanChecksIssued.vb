Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmLoanChecksIssued

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsLoanApplicationRelease As New LoanApplicationRelease.LoanApplicationRelease
    Private frmChecksIssuedReportViewer As New frmCrystalReportViewer


    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If Trim(cboReportType.Text) = "" Then
                clsCommon.Prompt_User("information", "There is no seleted report type.")
                Exit Sub
            End If
            Me.Cursor = WaitCursor
            Dim dsChecksIssuedListReport As New DataSet
            Dim dtChecksIssued As DataTable
            Dim dtSystemUser As DataTable

            With clsLoanApplicationRelease
                dtChecksIssued = .Populate_Checks_Issued_List_Report(Format(dtpLoanPaymentDate.Value, "yyyy-MM-dd"), Trim(cboReportType.Text))
                dtSystemUser = .System_User_Report
            End With

            dtChecksIssued.TableName = "ListOfChecks"
            dtSystemUser.TableName = "SystemUser"

            dsChecksIssuedListReport.Tables.Add(dtChecksIssued)
            dsChecksIssuedListReport.Tables.Add(dtSystemUser)

            frmChecksIssuedReportViewer = New frmCrystalReportViewer

            dsChecksIssuedListReport.DataSetName = "crptListOfChecksIssuedLoanReleased"
            dsChecksIssuedListReport.WriteXml(ReportDir + "\crptListOfChecksIssuedLoanReleased.xml", XmlWriteMode.WriteSchema)
            dsChecksIssuedListReport.WriteXmlSchema(ReportDir + "\" + "crptListOfChecksIssuedLoanReleased.xsd")

            If dtChecksIssued.Rows.Count > 0 Then
                With frmChecksIssuedReportViewer
                    .ds = dsChecksIssuedListReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptListOfChecksIssuedLoanReleased.rpt"
                    .ReportTitle = "List Of Checks Issued (Loan Released)"
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