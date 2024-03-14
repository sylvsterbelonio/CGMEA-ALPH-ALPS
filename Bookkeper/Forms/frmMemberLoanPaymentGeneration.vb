Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml

Public Class frmMemberLoanPaymentGeneration
    Inherits System.Windows.Forms.Form

#Region "frmMembersLoanPaymentGeneration Variable Declaration"

    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private WithEvents clsBookkeper As New Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsMemberLoanPayment As New MemberLoanPayment.MemberLoanPayment

    Private WithEvents clsLoanPaymentGeneration As New LoanPaymentGeneration.LoanPaymentGeneration

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private frmMemberLoanPaymentDetailReportViewer As frmCrystalReportViewer

    Private Piping_ToolTip As New ToolTip

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMemberLoanPayment As New Collection

    Private assessedVal As Double
    Private dueDate As Date
    Public memberNo As String = ""

    Public allowClose As Boolean = False

    Private dtable As System.Data.DataTable = Nothing

#End Region

#Region "frmMemberContributionGeneration Main Form Private Sub"

    Private Sub frmMembersLoanPaymentGeneration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Initialize_Form()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmMembersLoanPaymentGeneration_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim iAns

        iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
        If iAns = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMembersLoanPaymentGeneration_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Disposed_Class()
    End Sub

#End Region

#Region "frmMemberLoanPaymentGeneration User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Clear_All_Fields()
        Me.Text = "Member Loan Payment Generation"
    End Sub

    Private Sub Define_Collection()
        Define_Display()

        With ColMemberLoanPayment
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
        clsCommon.ClearControls(ColMemberLoanPayment)
        Define_Required_Fields()
        Me.Text = "Member Loan Payment Generation"
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(dtpLoanPaymentDate)
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(dtpLoanPaymentDate)
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
        Me.dtpLoanPaymentDate.Tag = "Loan Payment Date"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtMemberNo.MaxLength = 12
    End Sub

    Private Sub Clear_All_Fields()
        Me.dtpLoanPaymentDate.Text = Now
        Me.txtMemberNo.Text = ""
        Me.txtMemberName.Text = ""
    End Sub

    Private Sub Disposed_Class()
        clsCommon = Nothing
        clsPermission = Nothing
        clsLoanPaymentGeneration = Nothing

        ColPipe = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMemberLoanPayment = Nothing
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Dim CntRec As Integer = 0
            If Trim(dtpLoanPaymentDate.Text) <> "" Then
                If CInt(dtpLoanPaymentDate.Value.Year) <> CInt(Now.Year) Then
                    clsCommon.Prompt_User("information", "You are not allowed to generate member loan payment for the selected date.")
                    dtpLoanPaymentDate.Focus()
                    Exit Sub
                End If
                If CInt(dtpLoanPaymentDate.Value.Month) <> CInt(Now.Month) Then
                    clsCommon.Prompt_User("information", "You are not allowed to generate member loan payment for the selected date.")
                    dtpLoanPaymentDate.Focus()
                    Exit Sub
                End If
            End If

            If CInt(dtpLoanPaymentDate.Value.Year) = Now.Year And CInt(dtpLoanPaymentDate.Value.Month) = Now.Month Then
                If clsCommon.Required_Validation_List(ColRequired) Then
                    Me.Cursor = WaitCursor

                    With clsLoanPaymentGeneration
                        .TempLoanPayment_Dt = dtpLoanPaymentDate.Value
                        ._memberNo = Trim(txtMemberNo.Text)
                        ._memberName = Trim(txtMemberName.Text)
                        .Updated_By = gUserID
                    End With

                    If clsLoanPaymentGeneration.Save_Generated_LoanPayment_Record Then
                        clsCommon.Prompt_User("information", "Member loan payment successfully uploaded.")
                        DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        'Nothing
                    End If
                    Me.Cursor = Arrow
                Else
                    Me.dtpLoanPaymentDate.Focus()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim dsMemberLoanPaymentListReport As New DataSet
           Dim dtMemberLoanPayment As DataTable
            Dim dtSystemUser As DataTable

            With clsLoanPaymentGeneration
                dtMemberLoanPayment = .Populate_Member_LoanPayment_List_Report(Format(dtpLoanPaymentDate.Value, "yyyy-MM-dd"), Trim(txtMemberNo.Text), Trim(txtMemberName.Text))
                dtSystemUser = .System_User_Report
            End With

            dtMemberLoanPayment.TableName = "MemberLoanPayment"
            dtSystemUser.TableName = "SystemUser"

            dsMemberLoanPaymentListReport.Tables.Add(dtMemberLoanPayment)
            dsMemberLoanPaymentListReport.Tables.Add(dtSystemUser)

            frmMemberLoanPaymentDetailReportViewer = New frmCrystalReportViewer

            dsMemberLoanPaymentListReport.DataSetName = "crptMemberLoanPaymentList"
            dsMemberLoanPaymentListReport.WriteXml(ReportDir + "\crptMemberLoanPaymentList.xml", XmlWriteMode.WriteSchema)
            dsMemberLoanPaymentListReport.WriteXmlSchema(ReportDir + "\" + "crptMemberLoanPaymentList.xsd")

            If dtMemberLoanPayment.Rows.Count > 0 Then
                With frmMemberLoanPaymentDetailReportViewer
                    .ds = dsMemberLoanPaymentListReport
                    .blnDataSource = True
                    .ReportPath = gApplicationPath + "\Reports\crptMemberLoanPaymentList.rpt"
                    .ReportTitle = "Member Loan Payment List"
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