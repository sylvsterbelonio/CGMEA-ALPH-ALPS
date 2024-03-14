Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmMemberContributionGeneration
    Inherits System.Windows.Forms.Form

#Region "frmMembersContributionGeneration Variable Declaration"

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private WithEvents clsBookkeper As New Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMemberContribution As New MemberContribution.MemberContribution

    Private WithEvents clsContributionGeneration As New ContributionGeneration.ContributionGeneration

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private frmMemberContributionDetailReportViewer As frmCrystalReportViewer

    Private Piping_ToolTip As New ToolTip

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMemberContribution As New Collection

    Private assessedVal As Double
    Private dueDate As Date
    Public memberNo As String = ""

    Public allowClose As Boolean = False

    Private dtable As System.Data.DataTable = Nothing

#End Region

#Region "frmMemberContributionGeneration Main Form Private Sub"

    Private Sub frmMemberContributionGeneration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_Form()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMemberContributionGeneration_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim iAns

        iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
        If iAns = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMemberContributionGeneration_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Disposed_Class()
    End Sub

#End Region

#Region "frmMemberContributionGeneration User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Clear_All_Fields()
        Me.Text = "Member Contribution Generation"
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColMemberContribution
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
        clsCommon.ClearControls(ColMemberContribution)
        Define_Required_Fields()
        Me.Text = "Member Contribution Generation"
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
    End Sub

    Private Sub Disposed_Class()
        clsCommon = Nothing
        clsPermission = Nothing
        clsContributionGeneration = Nothing

        ColPipe = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMemberContribution = Nothing
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Dim CntRec As Integer = 0
            If Trim(dtpContributionDate.Text) <> "" Then
                If CInt(dtpContributionDate.Value.Year) > CInt(Now.Year) Then
                    clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                    dtpContributionDate.Focus()
                    Exit Sub
                End If
                If CInt(dtpContributionDate.Value.Month) > CInt(Now.Month) Then
                    clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                    dtpContributionDate.Focus()
                    Exit Sub
                End If
                If dtpContributionDate.Value.Date <= "2015-09-30" Then
                    clsCommon.Prompt_User("information", "You are not allowed to generate member contribution for the selected date.")
                    dtpContributionDate.Focus()
                    Exit Sub
                End If
            End If

            If CInt(dtpContributionDate.Value.Year) = Now.Year And CInt(dtpContributionDate.Value.Month) <= Now.Month Then
                If clsCommon.Required_Validation_List(ColRequired) Then
                    Me.Cursor = WaitCursor

                    With clsContributionGeneration
                        .TempContribution_Dt = dtpContributionDate.Value
                        ._memberNo = Trim(txtMemberNo.Text)
                        ._memberName = Trim(txtMemberName.Text)
                        .Updated_By = gUserID
                    End With

                    If clsContributionGeneration.Save_Generated_Contribution_Record Then
                        clsCommon.Prompt_User("information", "Member contribution successfully uploaded.")
                        DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        'Nothing
                    End If
                    Me.Cursor = Arrow
                Else
                    Me.dtpContributionDate.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsMemberContributionListReport As New DataSet
            Dim dtMemberContribution As DataTable
            Dim dtSystemUser As DataTable
            Dim dType As Integer = 0

            With clsContributionGeneration
                dtMemberContribution = .Populate_Member_Contribution_List_Report(Format(dtpContributionDate.Value, "yyyy-MM-dd"), Trim(txtMemberNo.Text), Trim(txtMemberName.Text), 1, 0)
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

#End Region

End Class