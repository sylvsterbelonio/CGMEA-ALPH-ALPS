Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml
Public Class frmOfficialReceiptsIssued

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)
    Private WithEvents clsPayment As New Payment.Payment
    Private frmChecksIssuedReportViewer As New frmCrystalReportViewer

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            If Trim(cboReportType.Text) = "" Then
                clsCommon.Prompt_User("information", "No seleted report type.")
                Exit Sub
            End If
            Me.Cursor = WaitCursor
            Dim dsOfficialReceiptsListReport As New DataSet
            Dim dtOfficialReceiptsIssued As DataTable
            Dim dtSystemUser As DataTable

            With clsPayment
                dtOfficialReceiptsIssued = .Populate_Official_Receipts_Issued_List_Report(Format(dtpLoanPaymentDate.Value, "yyyy-MM-dd"), Trim(cboReportType.Text))
                dtSystemUser = .System_User_Report
            End With

            dtOfficialReceiptsIssued.TableName = "ORDetail"
            dtSystemUser.TableName = "SystemUser"

            dsOfficialReceiptsListReport.Tables.Add(dtOfficialReceiptsIssued)
            dsOfficialReceiptsListReport.Tables.Add(dtSystemUser)

            frmChecksIssuedReportViewer = New frmCrystalReportViewer

            dsOfficialReceiptsListReport.DataSetName = "crptOfficialReceiptsIssued"
            dsOfficialReceiptsListReport.WriteXml(ReportDir + "\crptOfficialReceiptsIssued.xml", XmlWriteMode.WriteSchema)
            dsOfficialReceiptsListReport.WriteXmlSchema(ReportDir + "\" + "crptOfficialReceiptsIssued.xsd")

            If dtOfficialReceiptsIssued.Rows.Count > 0 Then
                With frmChecksIssuedReportViewer
                    .ds = dsOfficialReceiptsListReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptListOfOfficialReceiptsIssued.rpt"
                    .ReportTitle = "List Of Official Receipts Issued (Treasurer)"
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