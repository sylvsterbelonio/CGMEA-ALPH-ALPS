Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml
Public Class frmLoanPaymentUpdater
    Inherits System.Windows.Forms.Form

#Region "frmLoanPaymentUpdater Variable Declaration"
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private WithEvents clsBookkeper As New Bookkeper(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsLoanPaymentUpdater As New LoanPaymentUpdater.LoanPaymentUpdater
    Private WithEvents clsLoanApplication As New LoanApplication.LoanApplication

    Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)

    Private frmMemberContributionDetailReportViewer As frmCrystalReportViewer

    Private Piping_ToolTip As New ToolTip

    'Declaration of Collections
    Private ColPipe As New Collection
    Private ColDisplay As New Collection
    Private ColRequired As New Collection
    Private ColMemberLoanPayment As New Collection

    Public memberNo As String = ""

    Public allowClose As Boolean = False
    Private payment_process As Boolean = False

    Private dtable As System.Data.DataTable = Nothing

    'Declaration of SQL Related functions
    Private dtDataGridView As DataTable
    Private dtDataGridViewRow As DataRow
#End Region

#Region "frmLoanPaymentUpdater Main Form Private Sub"

    Private Sub frmLoanPaymentUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = WaitCursor
        Me.WindowState = FormWindowState.Maximized
        Initialize_Form()
        Me.Cursor = Arrow
    End Sub

    Private Sub frmLoanPaymentUpdater_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim iAns

        iAns = clsCommon.Prompt_User("question", MSGBOX_CANCEL_CONFIRMATION)
        If iAns = vbYes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmLoanPaymentUpdater_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Disposed_Class()
    End Sub

#End Region

#Region "frmLoanPaymentUpdater User Defined Private Sub"

    Private Sub Initialize_Form()
        Define_Collection()
        Set_Form_State()
        Initialize_AutoComplete()
        Piping_ToolTip = clsCommon.SetUp_ToolTip_Piping(ColPipe)
        Set_Required_Tags()
        Set_Max_Length()
        Clear_All_Fields()
        chkAllLoanType.Checked = True
        Me.Text = "Loan Payment Updater"
    End Sub

    Private Sub Initialize_AutoComplete()
        PopulateCheckListBox()
    End Sub

    Public Sub PopulateCheckListBox()
        Dim dataComboRow As DataRow
        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
        Dim dataCombo As DataSet
        Try
            clbLoanTypeId.Items.Clear()
            clbLoanType.Items.Clear()

            dataCombo = clsLoanApplication.GetLoanTypeList
            For Each dataComboRow In dataCombo.Tables(0).Rows

                clbLoanTypeId.Items.Add(dataComboRow(0))
                clbLoanType.Items.Add(dataComboRow(1))
            Next
            dataCombo = Nothing
            dataComboRow = Nothing
        Catch ex As Exception
            'error was encountered while populating record
            DataCombo = Nothing
            dataComboRow = Nothing
        End Try
    End Sub

    Private Sub Define_Collection()
        Define_Display()
        With ColMemberLoanPayment
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
        clsCommon.ClearControls(ColMemberLoanPayment)
        Define_Required_Fields()
        Me.Text = "Member Loan Payment Updater"
    End Sub

    Private Sub Define_Display()
        ColDisplay = New Collection
        With ColDisplay
            .Add(dtpPaymentDate)
            .Add(txtMemberNo)
            .Add(txtMemberName)
        End With
    End Sub

    Private Sub Define_Required_Fields()
        With ColRequired
            .Add(dtpPaymentDate)
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
        Me.dtpPaymentDate.Tag = "Payment Date"
    End Sub

    Private Sub Set_Max_Length()
        Me.txtMemberNo.MaxLength = 12
    End Sub

    Private Sub Clear_All_Fields()
        Me.dtpPaymentDate.Text = Now
        Me.txtMemberNo.Text = ""
        Me.txtMemberName.Text = ""
        Me.txtTPayment.Text = "0.00"
        Me.txtTInterest.Text = "0.00"
        Me.txtTotalMembers.Text = "0.00"
        Me.txtTotalAmountPaid.Text = "0.00"
        Me.txtTotalInterestPaid.Text = "0.00"
        Me.txtTotal.Text = "0.00"
        Me.dgvMemberLoanPayment.Rows.Clear()
    End Sub

    Private Sub Disposed_Class()
        clsCommon = Nothing
        clsPermission = Nothing
        clsLoanPaymentUpdater = Nothing

        ColPipe = Nothing
        ColDisplay = Nothing
        ColRequired = Nothing
        ColMemberLoanPayment = Nothing
    End Sub

    Private Sub generateTotalContribution()
        Dim tPayment As Double = 0
        Dim tInterest As Double = 0
        Dim tMem As Integer = 0
        For a As Integer = 0 To dgvMemberLoanPayment.RowCount - 1
            tPayment = tPayment + CDbl(dgvMemberLoanPayment.Item(9, a).Value)
            tInterest = tInterest + CDbl(dgvMemberLoanPayment.Item(10, a).Value)
            'tMem = tMem + 1
        Next
        tMem = dgvMemberLoanPayment.RowCount - 1
        txtTPayment.Text = Format(tPayment, "Standard")
        txtTInterest.Text = Format(tInterest, "Standard")
        txtTotalMembers.Text = Format(tPayment + tInterest, "Standard")
    End Sub

    Private Sub generateCurrentMemberInformation(ByVal rw As Integer)
        Try
            Dim curTotal As Double = 0
            Dim intTotal As Double = 0
            'Select Case e.ColumnIndex
            ' Case 2
            If dgvMemberLoanPayment.RowCount > 1 Then
                txtCurMemberName.Text = Trim(dgvMemberLoanPayment.Rows(rw).Cells(2).Value)
                For i As Integer = 0 To dgvMemberLoanPayment.RowCount - 1
                    If CInt(dgvMemberLoanPayment.Rows(i).Cells(0).Value) = CInt(dgvMemberLoanPayment.Rows(rw).Cells(0).Value) And CDbl(dgvMemberLoanPayment.Rows(i).Cells(9).Value) > 0 Then
                        curTotal = curTotal + CDbl(dgvMemberLoanPayment.Rows(i).Cells(9).Value)
                        intTotal = intTotal + CDbl(dgvMemberLoanPayment.Rows(i).Cells(10).Value)
                    End If
                Next
                txtTotalAmountPaid.Text = Format(curTotal, "Standard")
                txtTotalInterestPaid.Text = Format(intTotal, "Standard")
                txtTotal.Text = Format(curTotal + intTotal, "Standard")
            End If
            'End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

#Region "frmLoanPaymentUpdater DataGridView Private Sub"

    Private Sub dgvMemberLoanPayment_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMemberLoanPayment.SelectionChanged
        If dgvMemberLoanPayment.RowCount > 1 Then
            generateCurrentMemberInformation(dgvMemberLoanPayment.CurrentCell.RowIndex)
        End If
    End Sub

    Private Sub dgvMemberLoanPayment_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMemberLoanPayment.CellValueChanged
        Try
            Dim conDt As Date = dtpPaymentDate.Text
            Dim fId As Integer = 0
            If payment_process = True Then
                Select Case e.ColumnIndex
                    Case 6 'Principal Amount
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            If clsLoanPaymentUpdater.Save_Member_Loan_Principal_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), Trim(conDt.ToString("yyyy-MM-dd")), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Principal amount updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                                generateTotalContribution()
                                generateCurrentMemberInformation(dgvMemberLoanPayment.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 7 'Loan Balance
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            If clsLoanPaymentUpdater.Save_Member_Loan_Balance_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), Trim(conDt.ToString("yyyy-MM-dd")), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan balance updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                                generateTotalContribution()
                                generateCurrentMemberInformation(dgvMemberLoanPayment.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 8 'Monthly Payment
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            If clsLoanPaymentUpdater.Save_Member_Loan_Monthly_Payment_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan monthly payment updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            End If
                        End If
                    Case 9 'Amount Paid
                        fId = 9
                        Dim ref3 As Integer = 0
                        If cboDeductionType.Text = "SALARY DEDUCTION" Then
                            ref3 = 2
                        ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                            ref3 = 3
                        End If
                        If clsLoanPaymentUpdater.Save_Member_Loan_Payment_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Successfully updated."
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            If (conDt.Year = 2016 And conDt.Month > 7) Or conDt.Year > 2016 Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(7).Value = Format(clsLoanPaymentUpdater.GetMemberBalanceAmountTotal(CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                            End If
                            generateTotalContribution()
                            generateCurrentMemberInformation(dgvMemberLoanPayment.CurrentCell.RowIndex)
                        End If
                    Case 10 'Loan Interest
                        fId = 8
                        Dim ref3 As Integer = 0
                        If cboDeductionType.Text = "SALARY DEDUCTION" Then
                            ref3 = 2
                        ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                            ref3 = 3
                        End If
                        If clsLoanPaymentUpdater.Save_Member_Loan_Interest_Payment_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), fId, AddSlashes(conDt.ToString("yyyy-MM-dd")), CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), ref3, gUserID) Then
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Successfully updated."
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = Format(CDbl(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value), "Standard")
                            dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            generateTotalContribution()
                            generateCurrentMemberInformation(dgvMemberLoanPayment.CurrentCell.RowIndex)
                        End If
                    Case 11 'Date of Loan
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            Dim loanDt As Date = Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                            If clsLoanPaymentUpdater.Save_Member_Loan_Date_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), Trim(loanDt.ToString("yyyy-MM-dd")), 0, gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan date updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(12).Value = Format(clsLoanPaymentUpdater.GetMemberLoanMaturityDate(CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(0).Value)), "Standard")
                            End If
                        End If
                    Case 12 'Maturity Date
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            Dim loanDt As Date = Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                            If clsLoanPaymentUpdater.Save_Member_Loan_Date_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), Trim(loanDt.ToString("yyyy-MM-dd")), 1, gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan maturity date updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(13).Value = CInt(clsLoanPaymentUpdater.GetMemberLoanTerm(CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(0).Value)))
                            End If
                        End If
                    Case 13 'Loan Term
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            If clsLoanPaymentUpdater.Save_Member_Loan_Term_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(13).Value), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan term updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            End If
                        End If
                    Case 14 'Voucher No
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            If clsLoanPaymentUpdater.Save_Member_Loan_VoucherNo_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CStr(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(14).Value), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan Voucher No. updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            End If
                        End If
                    Case 15 'Check No
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            If clsLoanPaymentUpdater.Save_Member_Loan_CheckNo_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), CStr(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(15).Value), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan Check No. updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            End If
                        End If
                    Case 16 'Close loans
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            Dim loanDt As Date = Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(11).Value)
                            Dim chk As Integer = 0
                            Dim cDt As Date
                            If CInt(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(16).Value) = True Then
                                chk = 1
                                cDt = InputBox("Close Date: FORMAR(YYYY-DD-MM)", gAssemblyProduct, Now.ToString("yyyy-MM-dd"))
                                'If Len(cDt) <> 10 Then
                                '    Exit Sub
                                'End If
                                If Not IsDate(cDt) Then
                                    clsCommon.Prompt_User("error", "'" & cDt.ToString & "' is not a date value.")
                                    Exit Sub
                                End If
                            End If
                            If clsLoanPaymentUpdater.Close_Member_Loan_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), chk, Trim(cDt.ToString("yyyy-MM-dd")), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan closed."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            End If
                        End If
                    Case 17 'Close Date
                        If conDt.Year = 2016 And conDt.Month = 7 Then
                            Dim cloanDt As Date = Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                            If clsLoanPaymentUpdater.Save_Member_Loan_CloseDate_Record(Trim(dgvMemberLoanPayment.Rows(e.RowIndex).Cells(3).Value), Trim(cloanDt.ToString("yyyy-MM-dd")), gUserID) Then
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Value = "Loan date updated."
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(18).Style.BackColor = LightGreen
                                dgvMemberLoanPayment.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = LightPink
                            End If
                        End If
                End Select
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvMemberLoanPayment_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvMemberLoanPayment.RowPostPaint
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

    Private Sub dgvMemberLoanPayment_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvMemberLoanPayment.CellFormatting
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim f As Font = dgvMemberLoanPayment.DefaultCellStyle.Font

        If dgvMemberLoanPayment.Rows(e.RowIndex).Cells(16).Value = 1 AndAlso dgvMemberLoanPayment.Rows(e.RowIndex).Cells(16).Value IsNot DBNull.Value Then
            dgvMemberLoanPayment.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Red
            dgvMemberLoanPayment.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(f, FontStyle.Strikeout Or FontStyle.Bold)
        End If
    End Sub

#End Region

#Region "frmLoanPaymentUpdater Buttons Private Sub"

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            Dim listCnt As Integer = 0
            If dtpPaymentDate.Checked = False Then
                clsCommon.Prompt_User("information", "No selected date.")
                dtpPaymentDate.Focus()
            End If

            For Each s In clbLoanTypeId.CheckedIndices
                listCnt = listCnt + 1
            Next

            If listCnt = 0 Then
                clsCommon.Prompt_User("information", "No selected loan type.")
                clbLoanType.Focus()
            End If

            Dim typeList As New System.Text.StringBuilder
            For Each item In clbLoanTypeId.CheckedItems
                If typeList.ToString <> "" Then
                    typeList.Append(",")
                End If
                typeList.Append(item)
            Next

            Dim conDt As Date = dtpPaymentDate.Text
            Dim closeFl As Integer = 0
            Dim tPayment As Double = 0
            Dim tInterest As Double = 0
            Dim tMem As Integer = 0
            Dim ref3 As Integer = 0

            If chkClose.Checked = True Then
                closeFl = 1
            Else
                closeFl = 0
            End If

            If cboDeductionType.Text = "SALARY DEDUCTION" Then
                ref3 = 2
            ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                ref3 = 3
            End If

            payment_process = False
            dgvMemberLoanPayment.Rows.Clear()

            Dim rcount As Integer = 0
            If payment_process = False Then
                With dgvMemberLoanPayment
                    .Columns(9).HeaderText = "AMOUNT PAID " + vbCrLf + "(" + conDt.ToString("yyyy-MM-dd") + ")"
                    .Columns(10).HeaderText = "LOAN INTEREST " + vbCrLf + "(" + conDt.ToString("yyyy-MM-dd") + ")"
                End With
                With clsLoanPaymentUpdater
                    dtDataGridView = .Populate_Loan_Payment_List_Record(conDt.ToString("yyyy-MM-dd"), Trim(txtMemberNo.Text), Trim(txtMemberName.Text), Trim(typeList.ToString), closeFl, ref3)
                    If Not dtDataGridView Is Nothing Then
                        For Each Me.dtDataGridViewRow In Me.dtDataGridView.Rows
                            With dgvMemberLoanPayment
                                Dim rowndx As Integer
                                rowndx = .Rows.Add()
                                .Item(0, rowndx).Value = dtDataGridViewRow("memberId")
                                .Item(1, rowndx).Value = dtDataGridViewRow("memberNo")
                                .Item(2, rowndx).Value = dtDataGridViewRow("memberName")
                                .Item(3, rowndx).Value = dtDataGridViewRow("loanId")
                                .Item(4, rowndx).Value = dtDataGridViewRow("loanNo")
                                .Item(5, rowndx).Value = dtDataGridViewRow("loanType")
                                .Item(6, rowndx).Value = dtDataGridViewRow("principalAmount")
                                .Item(7, rowndx).Value = dtDataGridViewRow("balanceAmount")
                                .Item(8, rowndx).Value = dtDataGridViewRow("monthlyPayment")
                                .Item(9, rowndx).Value = dtDataGridViewRow("amountPaid")
                                .Item(10, rowndx).Value = dtDataGridViewRow("loanInterest")
                                'Dim conUpdt As Date = dtDataGridViewRow("loanDt")
                                If conDt.Year = 2016 And conDt.Month = 7 Then
                                    '.Item(6, rowndx).ReadOnly = False
                                    .Item(7, rowndx).ReadOnly = False
                                    '.Item(8, rowndx).ReadOnly = False
                                    '.Item(11, rowndx).ReadOnly = False
                                    '.Item(12, rowndx).ReadOnly = False
                                    '.Item(13, rowndx).ReadOnly = False
                                    '.Item(14, rowndx).ReadOnly = False
                                    '.Item(15, rowndx).ReadOnly = False
                                    '.Item(16, rowndx).ReadOnly = False
                                    '.Item(17, rowndx).ReadOnly = False
                                    'If (conDt.Year >= 2016 And conDt.Month > 6) Or conDt.Year > 2016 Then
                                Else
                                    '.Item(6, rowndx).ReadOnly = True
                                    .Item(7, rowndx).ReadOnly = True
                                    '.Item(8, rowndx).ReadOnly = True
                                    '.Item(11, rowndx).ReadOnly = True
                                    '.Item(12, rowndx).ReadOnly = True
                                    '.Item(13, rowndx).ReadOnly = True
                                    '.Item(14, rowndx).ReadOnly = True
                                    '.Item(15, rowndx).ReadOnly = True
                                    '.Item(16, rowndx).ReadOnly = True
                                    '.Item(17, rowndx).ReadOnly = True
                                End If
                                .Item(6, rowndx).ReadOnly = False
                                .Item(8, rowndx).ReadOnly = False
                                .Item(9, rowndx).ReadOnly = False
                                .Item(10, rowndx).ReadOnly = False
                                .Item(11, rowndx).ReadOnly = False
                                .Item(12, rowndx).ReadOnly = False
                                .Item(13, rowndx).ReadOnly = False
                                .Item(14, rowndx).ReadOnly = False
                                .Item(15, rowndx).ReadOnly = False
                                .Item(16, rowndx).ReadOnly = False
                                .Item(17, rowndx).ReadOnly = False
                                If CDbl(.Item(7, rowndx).Value) < 0 Then
                                    .Item(7, rowndx).Style.BackColor = LightPink
                                End If
                                tMem = tMem + 1
                                tPayment = tPayment + dtDataGridViewRow("amountPaid")
                                tInterest = tInterest + dtDataGridViewRow("loanInterest")
                                .Item(11, rowndx).Value = dtDataGridViewRow("loanDt")
                                .Item(12, rowndx).Value = dtDataGridViewRow("maturityDt")
                                .Item(13, rowndx).Value = dtDataGridViewRow("loanTerm")
                                .Item(14, rowndx).Value = dtDataGridViewRow("voucherNo")
                                .Item(15, rowndx).Value = dtDataGridViewRow("checkNo")
                                .Item(16, rowndx).Value = dtDataGridViewRow("closeFl")
                                If CInt(dtDataGridViewRow("closeFl")) = 1 Then
                                    .Item(17, rowndx).ReadOnly = False
                                Else
                                    .Item(17, rowndx).ReadOnly = True
                                End If
                                .Item(17, rowndx).Value = dtDataGridViewRow("closeDt")
                            End With
                        Next
                    End If
                End With
                txtTPayment.Text = Format(tPayment, "Standard")
                txtTInterest.Text = Format(tInterest, "Standard")
                txtTotalMembers.Text = Format(tPayment + tInterest, "Standard")
                lblTotalRecord.Text = "- " & tMem & " rows"
                'generateTotalContribution()
            End If

            If dgvMemberLoanPayment.Rows.Count > 0 Then
                payment_process = True
                dgvMemberLoanPayment.Rows(0).Selected = True
                generateCurrentMemberInformation(dgvMemberLoanPayment.CurrentCell.RowIndex)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Dim iAns
            iAns = clsCommon.Prompt_User("question", "Existing monthly payment records from the recent month will be generated for this month. Do you want to continue?")
            If iAns = vbYes Then
                Dim CntRec As Integer = 0
                Dim orgDt As Date = "2015-09-30"
                Dim conDt As Date = dtpPaymentDate.Value

                If Trim(dtpPaymentDate.Text) <> "" Then
                    'If CInt(dtpPaymentDate.Value.Year) > CInt(Now.Year) Then
                    '    clsCommon.Prompt_User("information", "You are not allowed to generate member loan payment for the selected date.")
                    '    dtpPaymentDate.Focus()
                    '    Exit Sub
                    'End If
                    'If CInt(dtpPaymentDate.Value.Month) > CInt(Now.Month) Then
                    '    clsCommon.Prompt_User("information", "You are not allowed to generate member loan payment for the selected date.")
                    '    dtpPaymentDate.Focus()
                    '    Exit Sub
                    'End If
                    If conDt <= orgDt Then
                        clsCommon.Prompt_User("information", "You are not allowed to generate members loan payment for the selected date.")
                        dtpPaymentDate.Focus()
                        Exit Sub
                    End If
                End If
                Dim listCnt As Integer = 0

                For Each s In clbLoanTypeId.CheckedIndices
                    listCnt = listCnt + 1
                Next

                If listCnt = 0 Then
                    clsCommon.Prompt_User("information", "No selected loan type.")
                    clbLoanType.Focus()
                End If

                Dim typeList As New System.Text.StringBuilder
                For Each item In clbLoanTypeId.CheckedItems
                    If typeList.ToString <> "" Then
                        typeList.Append(",")
                    End If
                    typeList.Append(item)
                Next

                If conDt <= Now Then
                    If clsCommon.Required_Validation_List(ColRequired) Then
                        Me.Cursor = WaitCursor

                        With clsLoanPaymentUpdater
                            ._tempLoanPaymentDt = dtpPaymentDate.Value
                            ._memberNo = Trim(txtMemberNo.Text)
                            ._memberName = Trim(txtMemberName.Text)
                            ._typeList = Trim(typeList.ToString)
                            ._updatedBy = gUserID
                            If cboDeductionType.Text = "SALARY DEDUCTION" Then
                                ._referenceId3 = 2
                            ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                                ._referenceId3 = 3
                            End If
                        End With

                        If clsLoanPaymentUpdater.Save_Generated_Loan_Payment_Record Then
                            btnSearch.PerformClick()
                            clsCommon.Prompt_User("information", "Member loan payment successfully uploaded.")
                            DialogResult = Windows.Forms.DialogResult.OK
                        Else
                            'Nothing
                        End If
                        Me.Cursor = Arrow
                    Else
                        Me.dtpPaymentDate.Focus()
                    End If
                Else
                    clsCommon.Prompt_User("information", "You are not allowed to generate members loan payment for the selected date.")
                    dtpPaymentDate.Focus()
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Try
            Me.Cursor = WaitCursor
            Dim listCnt As Integer = 0
            Dim ref3 As Integer = 0
            If dtpPaymentDate.Checked = False Then
                clsCommon.Prompt_User("information", "No selected date.")
                dtpPaymentDate.Focus()
            End If

            For Each s In clbLoanTypeId.CheckedIndices
                listCnt = listCnt + 1
            Next

            If listCnt = 0 Then
                clsCommon.Prompt_User("information", "No selected loan type.")
                clbLoanType.Focus()
            End If

            Dim typeList As New System.Text.StringBuilder
            For Each item In clbLoanTypeId.CheckedItems
                If typeList.ToString <> "" Then
                    typeList.Append(",")
                End If
                typeList.Append(item)
            Next

            Dim dsMemberContributionListReport As New DataSet
            Dim dtMemberContribution As DataTable
            Dim dtSystemUser As DataTable
            Dim closeFl As Integer = 0

            If chkClose.Checked = True Then
                closeFl = 1
            Else
                closeFl = 0
            End If

            If cboDeductionType.Text = "SALARY DEDUCTION" Then
                ref3 = 2
            ElseIf cboDeductionType.Text = "PERA DEDUCTION" Then
                ref3 = 3
            End If

            With clsLoanPaymentUpdater
                dtMemberContribution = .Populate_Loan_Billing_Report(Format(dtpPaymentDate.Value, "yyyy-MM-dd"), Trim(txtMemberNo.Text), Trim(txtMemberName.Text), Trim(typeList.ToString), closeFl, ref3)
                dtSystemUser = .System_User_Report
            End With

            dtMemberContribution.TableName = "MemberLoanPayment"
            dtSystemUser.TableName = "SystemUser"

            dsMemberContributionListReport.Tables.Add(dtMemberContribution)
            dsMemberContributionListReport.Tables.Add(dtSystemUser)

            frmMemberContributionDetailReportViewer = New frmCrystalReportViewer

            dsMemberContributionListReport.DataSetName = "crptMemberLoanPaymentList"
            dsMemberContributionListReport.WriteXml(ReportDir + "\crptMemberLoanPaymentList.xml", XmlWriteMode.WriteSchema)
            dsMemberContributionListReport.WriteXmlSchema(ReportDir + "\" + "crptMemberLoanPaymentList.xsd")

            If dtMemberContribution.Rows.Count > 0 Then
                With frmMemberContributionDetailReportViewer
                    .ds = dsMemberContributionListReport
                    .blnDataSource = True
                    .ReportPaperSize = 3
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dtpPaymentDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpPaymentDate.ValueChanged
        Dim dt As Date = dtpPaymentDate.Value
        If dtpPaymentDate.Checked = True Then
            lblDate.Text = dt.ToString("MMMM") + " " + dt.Year.ToString
        End If
    End Sub

    Private Sub clbLoanType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles clbLoanType.SelectedValueChanged
        Dim sb As New Integer
        Dim s As New Integer
        For Each s In clbLoanTypeId.CheckedIndices
            clbLoanTypeId.SetItemCheckState(s, CheckState.Unchecked)
        Next
        For Each sb In clbLoanType.CheckedIndices
            For sb2 As Integer = 0 To clbLoanTypeId.Items.Count
                If sb = sb2 Then
                    clbLoanTypeId.SetItemCheckState(sb, CheckState.Checked)
                End If
            Next
        Next

    End Sub

#End Region

    Private Sub chkAllLoanType_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllLoanType.CheckedChanged
        If chkAllLoanType.Checked = True Then
            For s As Integer = 0 To clbLoanType.Items.Count - 1
                clbLoanType.SetItemCheckState(s, CheckState.Checked)
                clbLoanTypeId.SetItemCheckState(s, CheckState.Checked)
            Next
        Else
            For Each s In clbLoanType.CheckedIndices
                clbLoanType.SetItemCheckState(s, CheckState.Unchecked)
                clbLoanTypeId.SetItemCheckState(s, CheckState.Unchecked)
            Next
        End If
    End Sub
End Class