Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmMemberContributionUpdater
    Inherits System.Windows.Forms.Form

#Region "frmMemberContributionUpdater Variable Declaration"
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private WithEvents clsBookkeper As New Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMemberContribution As New MemberContribution.MemberContribution

    Private WithEvents clsContributionUpdater As New ContributionGeneration.ContributionGeneration
    Private WithEvents clsContributionGeneration As New ContributionGeneration.ContributionGeneration
    Private WithEvents clsMemberContributionUpdater As New MemberContributionUpdater.MemberContributionUpdater

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
    Private clsMemberContributionDetails As New MemberContributionDetails.MemberContributionDetails

    Private frmMemberContributionDetailReportViewer As frmCrystalReportViewer

    Private Piping_ToolTip As New ToolTip

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMemberContribution As New Collection

    Public memberNo As String = ""

    Public allowClose As Boolean = False
    Private contribution_process As Boolean = False

    Private dtable As System.Data.DataTable = Nothing

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow
#End Region

#Region "frmMemberContributionGeneration Main Form Private Sub"

    Private Sub frmMemberContributionUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Me.WindowState = FormWindowState.Maximized
        Initialize_Form()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMemberContributionUpdater_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim iAns

        iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
        If iAns = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMemberContributionUpdater_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Disposed_Class()
    End Sub

#End Region

#Region "frmMemberContributionUpdater User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Clear_All_Fields()
        Me.Text = "Member Contribution Updater"
    End Sub

    Private Sub Define_Collection()
        Define_Display()
        With ColMemberContribution
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
        clsCommon.ClearControls(ColMemberContribution)
        Define_Required_Fields()
        Me.Text = "Member Contribution Updater"
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(dtpContributionDate)
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(dtpContributionDate)
        End With
    End Sub

    Public Sub Set_Form_State()
        Set_Permission()
        Define_Display()
    End Sub

    Private Sub Set_Permission()
        With clsPermission
            .Role_ID = gRoleID
            .Form_Name = Me.Name
            .SetPermission()
            Add_Permission = .Add_Permission
            Delete_Permission = .Delete_Permission
            Edit_Permission = .Edit_Permission
            View_Permission = .View_Permission
            Approve_Permission = .Approve_Permission
        End With
    End Sub

    Private Sub Set_Required_Tags()
        Me.dtpContributionDate.Tag = "Contribution Date"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtMemberNo.MaxLength = 12
    End Sub

    Private Sub Clear_All_Fields()
        Me.dtpContributionDate.Text = Now
        Me.txtMemberNo.Text = ""
        Me.txtMemberName.Text = ""
        Me.txtTContribution.Text = "0.00"
        Me.txtTPabaon.Text = "0.00"
        Me.txtTMortuary.Text = "0.00"
        Me.txtTPSLink.Text = "0.00"
        Me.txtGrandTotal.Text = "0.00"
        Me.dgvMemberContribution.Rows.Clear()
    End Sub

    Private Sub Disposed_Class()
        clsCommon = Nothing
        clsPermission = Nothing
        clsContributionUpdater = Nothing

        ColPipe = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMemberContribution = Nothing
    End Sub

    Private Sub generateTotalContribution()
        Dim tContribution As Double = 0
        Dim tPabaon As Double = 0
        Dim tMortuary As Double = 0
        Dim tPSLink As Double = 0
        Dim oTotal As Double = 0
        For a As Integer = 0 To dgvMemberContribution.RowCount - 1
            tContribution = tContribution + CDbl(dgvMemberContribution.Item(8, a).Value)
            tPabaon = tPabaon + CDbl(dgvMemberContribution.Item(9, a).Value)
            tMortuary = tMortuary + CDbl(dgvMemberContribution.Item(10, a).Value)
            tPSLink = tPSLink + CDbl(dgvMemberContribution.Item(11, a).Value)
            oTotal = oTotal + CDbl(dgvMemberContribution.Item(12, a).Value)
        Next
        txtTContribution.Text = Format(tContribution, "Standard")
        txtTMortuary.Text = Format(tMortuary, "Standard")
        txtTPabaon.Text = Format(tPabaon, "Standard")
        txtTPSLink.Text = Format(tPSLink, "Standard")
        txtGrandTotal.Text = Format(oTotal, "Standard")
    End Sub
#End Region

#Region "frmMemberContributionUpdater DataGridView Private Sub"

    Private Sub dgvMemberContribution_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMemberContribution.CellValueChanged
        Try
            Dim conDt As Date = dtpContributionDate.Text
            Dim fId As Integer = 0
            If contribution_process = True Then
                Dim ref3 As Integer = 0
                If cboDeductionType.Text = "SALARY DEDUCTION" Then
                    ref3 = 2
                ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                    ref3 = 3
                End If
                If e.ColumnIndex = 8 Then
                    fId = 2
                    'If cboDeductionType.Text = "SALARY DEDUCTION" Then
                    If clsMemberContribution.Save_Member_Contribution_Record(Trim(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Value = "Successfully updated."
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Style.BackColor = LightGreen
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(4).Value = Format(clsMemberContribution.GetMemberContributionTotal(fId, CInt(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(12).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(8).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(9).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(11).Value), "Standard")
                        generateTotalContribution()
                    Else
                        'Nothing
                    End If
                    'ElseIf cboDeductionType.Text = "PERA/ACA/RATA DEDUCTION" Then
                    'If clsMemberContribution.Save_Member_Contribution_Others_Record(Trim(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), gUserID) Then
                    'dgvMemberContribution.Rows(e.RowIndex).Cells(13).Value = "Successfully updated."
                    'dgvMemberContribution.Rows(e.RowIndex).Cells(13).Style.BackColor = LightGreen
                    'dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                    'dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                    'dgvMemberContribution.Rows(e.RowIndex).Cells(4).Value = Format(clsMemberContribution.GetMemberContributionTotal(fId, CInt(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                    'dgvMemberContribution.Rows(e.RowIndex).Cells(12).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(8).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(9).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(11).Value), "Standard")
                    'generateTotalContribution()
                    'Else
                    'Nothing
                    'End If
                    'End If
                ElseIf e.ColumnIndex = 9 Then
                    fId = 3

                    If clsMemberContribution.Save_Member_Contribution_Record(Trim(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Value = "Successfully updated."
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Style.BackColor = LightGreen
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(5).Value = Format(clsMemberContribution.GetMemberContributionTotal(fId, CInt(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(12).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(8).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(9).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(11).Value), "Standard")
                        generateTotalContribution()
                    Else
                        'Nothing
                    End If
                ElseIf e.ColumnIndex = 10 Then
                    fId = 4
                    If clsMemberContribution.Save_Member_Contribution_Record(Trim(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Value = "Successfully updated."
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Style.BackColor = LightGreen
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(6).Value = Format(clsMemberContribution.GetMemberContributionTotal(fId, CInt(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(12).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(8).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(9).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(11).Value), "Standard")
                        generateTotalContribution()
                    Else
                        'Nothing
                    End If
                ElseIf e.ColumnIndex = 11 Then
                    fId = 5
                    If clsMemberContribution.Save_Member_Contribution_Record(Trim(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Value = "Successfully updated."
                        dgvMemberContribution.Rows(e.RowIndex).Cells(13).Style.BackColor = LightGreen
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                        dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(7).Value = Format(clsMemberContribution.GetMemberContributionTotal(fId, CInt(dgvMemberContribution.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                        dgvMemberContribution.Rows(e.RowIndex).Cells(12).Value = Format(CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(8).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(9).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(10).Value) + CDbl(dgvMemberContribution.Rows(e.RowIndex).Cells(11).Value), "Standard")
                        generateTotalContribution()
                    Else
                        'Nothing
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvMemberContribution_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvMemberContribution.RowPostPaint
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Using b As SolidBrush = New SolidBrush(sender.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), _
                                  sender.DefaultCellStyle.Font, _
                                   b, _
                                   e.RowBounds.Location.X + 15, _
                                   e.RowBounds.Location.Y + 4)
        End Using
    End Sub

#End Region

#Region "frmMemberContributionUpdater Buttons Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            If dtpContributionDate.Checked = False Then
                clsCommon.Prompt_User("information", "No selected date.")
                dtpContributionDate.Focus()
            End If
            Dim conDt As Date = dtpContributionDate.Text
            Dim memberFl As Integer = 0
            Dim tContribution As Double = 0
            Dim tPabaon As Double = 0
            Dim tMortuary As Double = 0
            Dim tPSLink As Double = 0
            Dim oTotal As Double = 0
            Dim dType As Integer = 0

            If chkMember.Checked = True Then
                memberFl = 1
            Else
                memberFl = 0
            End If
            If cboDeductionType.Text = "SALARY DEDUCTION" Then
                dType = 2
            ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                dType = 3
            End If
            contribution_process = False
            dgvMemberContribution.Rows.Clear()

            Dim rcount As Integer = 0
            If contribution_process = False Then
                With dgvMemberContribution
                    .Columns(8).HeaderText = "CONTRIBUTION " + vbCrLf + "(" + conDt.ToString("yyyy-MM-dd") + ")"
                    .Columns(9).HeaderText = "PABAON " + vbCrLf + "(" + conDt.ToString("yyyy-MM-dd") + ")"
                    .Columns(10).HeaderText = "MORTUARY " + vbCrLf + "(" + conDt.ToString("yyyy-MM-dd") + ")"
                    .Columns(11).HeaderText = "PSLINK " + vbCrLf + "(" + conDt.ToString("yyyy-MM-dd") + ")"
                End With
                With clsContributionUpdater
                    dtDataGridView = .Populate_Member_Contribution_List_Record(conDt.ToString("yyyy-MM-dd"), Trim(txtMemberNo.Text), Trim(txtMemberName.Text), memberFl, dType)
                    If Not dtDataGridView Is Nothing Then
                        For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                            With dgvMemberContribution
                                Dim rowndx As Integer
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = dtDataGridViewRow("memberId")
                                .Item(1, rowndx).Value = dtDataGridViewRow("memberNo")
                                .Item(2, rowndx).Value = dtDataGridViewRow("memberName")
                                .Item(3, rowndx).Value = dtDataGridViewRow("departmentName")
                                .Item(4, rowndx).Value = dtDataGridViewRow("totalContribution")
                                .Item(5, rowndx).Value = dtDataGridViewRow("totalPabaon")
                                .Item(6, rowndx).Value = dtDataGridViewRow("totalMortuary")
                                .Item(7, rowndx).Value = dtDataGridViewRow("totalPSLink")
                                .Item(8, rowndx).Value = dtDataGridViewRow("contribution")
                                .Item(9, rowndx).Value = dtDataGridViewRow("pabaon")
                                .Item(10, rowndx).Value = dtDataGridViewRow("mortuary")
                                .Item(11, rowndx).Value = dtDataGridViewRow("pSLink")
                                .Item(12, rowndx).Value = dtDataGridViewRow("overallTotal")

                                .Item(8, rowndx).ReadOnly = False
                                .Item(9, rowndx).ReadOnly = False
                                .Item(10, rowndx).ReadOnly = False
                                .Item(11, rowndx).ReadOnly = False

                                tContribution = tContribution + dtDataGridViewRow("contribution")
                                tPabaon = tPabaon + dtDataGridViewRow("pabaon")
                                tMortuary = tMortuary + dtDataGridViewRow("mortuary")
                                tPSLink = tPSLink + dtDataGridViewRow("pSLink")
                                oTotal = oTotal + dtDataGridViewRow("overallTotal")
                            End With
                        Next
                    End If
                End With
                txtTContribution.Text = Format(tContribution, "Standard")
                txtTPabaon.Text = Format(tPabaon, "Standard")
                txtTMortuary.Text = Format(tMortuary, "Standard")
                txtTPSLink.Text = Format(tPSLink, "Standard")
                txtGrandTotal.Text = Format(oTotal, "Standard")
            End If

            If dgvMemberContribution.Rows.Count > 0 Then
                contribution_process = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            'If cboDeductionType.Text = "SALARY DEDUCTION" Then
            Dim iAns
            iAns = clsCommon.Prompt_User("question", "Existing records from the recent month will be generated for this month. Do you want to continue?")
            If iAns = vbYes Then
                Dim CntRec As Integer = 0
                Dim orgDt As Date = "2015-09-30"
                Dim conDt As Date = dtpContributionDate.Value
                Dim memberFl As Integer = 0

                If chkMember.Checked = True Then
                    memberFl = 1
                Else
                    memberFl = 0
                End If


                If Trim(dtpContributionDate.Text) <> "" Then
                    'If CInt(dtpContributionDate.Value.Year) > CInt(Now.Year) Then
                    '    clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                    '    dtpContributionDate.Focus()
                    '    Exit Sub
                    'End If
                    'If CInt(dtpContributionDate.Value.Month) > CInt(Now.Month) Then
                    '    clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                    '    dtpContributionDate.Focus()
                    '    Exit Sub
                    'End If
                    If conDt <= orgDt Then
                        clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                        dtpContributionDate.Focus()
                        Exit Sub
                    End If
                End If

                If conDt <= Now Then
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor

                        With clsContributionGeneration
                            .TempContribution_Dt = dtpContributionDate.Value
                            ._memberNo = Trim(txtMemberNo.Text)
                            ._memberName = Trim(txtMemberName.Text)
                            ._memberFl = memberFl
                            .Updated_By = gUserID
                            If cboDeductionType.Text = "SALARY DEDUCTION" Then
                                ._dType = 2
                            ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                                ._dType = 3
                            End If
                        End With

                        If clsContributionGeneration.Save_Generated_Contribution_Record Then
                            btnSearch.PerformClick()
                            clsCommon.Prompt_User("information", "Member contribution successfully uploaded.")
                            DialogResult = Windows.Forms.DialogResult.OK
                        Else
                            'Nothing
                        End If
                        Me.Cursor = Arrow
                    Else
                        Me.dtpContributionDate.Focus()
                    End If
                Else
                    clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                    dtpContributionDate.Focus()
                    Exit Sub
                End If
            Else
                dtpContributionDate.Focus()
                Exit Sub
            End If
            ' Else
            'clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for " & CStr(cboDeductionType.Text) & ".")
            'Exit Sub
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsMemberContributionListReport As New DataSet
            Dim dtMemberContribution As DataTable
            Dim dtSystemUser As DataTable

            Dim memberFl As Integer = 0
            Dim dType As Integer = 0

            If chkMember.Checked = True Then
                memberFl = 1
            Else
                memberFl = 0
            End If

            If cboDeductionType.Text = "SALARY DEDUCTION" Then
                dType = 2
            ElseIf cboDeductionType.Text = "PERA/ACA/RATA DEDUCTION" Then
                dType = 3
            End If

            With clsContributionGeneration
                dtMemberContribution = .Populate_Member_Contribution_List_Report(Format(dtpContributionDate.Value, "yyyy-MM-dd"), Trim(txtMemberNo.Text), Trim(txtMemberName.Text), memberFl, dType)
                dtSystemUser = .System_User_Report
            End With

            dtMemberContribution.TableName = "MemberContribution"
            dtSystemUser.TableName = "SystemUser"

            dsMemberContributionListReport.Tables.Add(dtMemberContribution)
            dsMemberContributionListReport.Tables.Add(dtSystemUser)

            frmMemberContributionDetailReportViewer = New frmCrystalReportViewer

            dsMemberContributionListReport.DataSetName = "crptMemberContributionList"
            dsMemberContributionListReport.WriteXml(ReportDir + "\crptMemberContributionList.xml", XmlWriteMode.WriteSchema)
            dsMemberContributionListReport.WriteXmlSchema(ReportDir + "\" + "crptMemberContributionList.xsd")

            If dtMemberContribution.Rows.Count > 0 Then
                With frmMemberContributionDetailReportViewer
                    .ds = dsMemberContributionListReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberContributionList.rpt"
                    .ReportTitle = "Member Contribution List"
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region


End Class