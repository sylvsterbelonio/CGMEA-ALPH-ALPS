Imports System.Windows.Forms.Cursors

Public Class frmLoanCalculator

    Inherits System.Windows.Forms.Form

#Region "frmLoanCalculator Variable Declaration"

    Public _LoanTypeId As Integer
    Public _LoanType As String
    Public _PrincipalAmount As Double
    Public _ValueDate As String
    Public _Period As Integer
    Public _Interest As Integer

    Private valueDt As Date
    Private minAmount As Double
    Private maxAmount As Double

    Private clsCommon As New Common.Common
    Private WithEvents clsLoanApplication As New LoanApplication.LoanApplication
    Private WithEvents clsLoanType As New LoanType.LoanType

    'declaration of Other Variables
    Public allowClose As Boolean = False
    Public State As String
#End Region

#Region "frmLoanApplication Main Form Private Sub"

    Private Sub frmLoanCalculator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim hMenu As IntPtr
        'Dim menuItemCount As Integer
        'hMenu = Common.Common.GetSystemMenu(Me.Handle, False)
        'menuItemCount = Common.Common.GetMenuItemCount(hMenu)
        'Call Common.Common.RemoveMenu(hMenu, menuItemCount - 1, MF_DISABLED Or MF_BYPOSITION)
        'Call Common.Common.RemoveMenu(hMenu, menuItemCount - 2, MF_DISABLED Or MF_BYPOSITION)
        'Call Common.Common.DrawMenuBar(Me.Handle)

        SetTextBoxLength()
        Initialize_AutoComplete()
        'If State = EDIT_STATE Then
        '    cboTypeName.Text = _LoanType
        '    txtPrincipal.Text = _PrincipalAmount
        '    dtpValueDate.Text = _ValueDate
        '    txtPeriod.Value = _Period
        '    txtInterest.Text = _Interest
        'End If
    End Sub

    Private Sub frmLoanCalculator_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If State <> VIEW_STATE Then
            
            State = VIEW_STATE
            e.Cancel = False
        Else
        End If
    End Sub

    Private Sub frmLoanApplication_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Disposed_Class()
    End Sub

#End Region

#Region "frmMember User Defined Private Sub"

    Private Sub Disposed_Class()
        clsLoanApplication = Nothing
        clsCommon = Nothing
    End Sub

    Private Sub SetTextBoxLength()
        txtPrincipal.MaxLength = 20
        nudTerm.Minimum = 1
        nudTerm.Maximum = 60
        txtInterest.MaxLength = 4
    End Sub

    Private Sub Initialize_AutoComplete()
        Dim dataCombo As DataSet

        With clsLoanApplication
            dataCombo = .GetLoanTypeList

            clsCommon.PopulateComboBox(cboTypeId, cboTypeName, dataCombo)
        End With
    End Sub

    Private Sub objPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        Select Case Asc(e.KeyChar)
            Case 48 To 57
            Case 46, 8
            Case Else
                e.Handled = True
        End Select
    End Sub

    Private Sub Compute_Interest_Payment()
        txtMonthlyPayment.Text = Format(CDbl(txtPrincipal.Text) / CInt(Me.nudTerm.Value), "Standard")
        txtLoanInterest.Text = Format((CDbl(txtPrincipal.Text) * (CDbl(txtInterest.Text) * 0.01)) * CDbl(nudTerm.Text), "Standard")

        valueDt = dtpValueDate.Value.ToString("yyyy-MM-dd")

        GenerateSchedule()

        With clsLoanApplication
            txtCISP.Text = Format(.GetCISPRate(CInt(nudTerm.Text)) * CDbl(txtPrincipal.Text), "Standard")
            txtServiceFee.Text = Format(.getServiceFee, "Standard")
        End With

        txtTotalDeductions.Text = "0.00"
        txtNetProceeds.Text = "0.00"

        txtTotalDeductions.Text = Format(CDbl(txtLoanInterest.Text) + CDbl(txtCISP.Text) + CDbl(txtServiceFee.Text), "Standard")
        txtNetProceeds.Text = Format(CDbl(txtPrincipal.Text) - CDbl(txtTotalDeductions.Text), "Standard")
    End Sub

    Private Sub GenerateSchedule()
        Dim periodicInt As Double = 0
        Dim monthlyPrincipal As Double = 0
        Dim dtDate As Date
        Dim total As Double

        monthlyPrincipal = CInt(txtPrincipal.Text) / CInt(nudTerm.Value)
        dgvLoanSchedule.Rows.Clear()

        For i As Integer = 1 To CInt(nudTerm.Value)
            dtDate = valueDt.AddMonths(i)
            total = monthlyPrincipal
            Me.dgvLoanSchedule.Rows.Add(Format(dtDate, "yyyy-MM-dd"), "0.00", Format(monthlyPrincipal, "Standard"), Format(total, "Standard"))
        Next
    End Sub

    Private Sub btnCalculation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculation.Click
        If Not IsNumeric(Me.txtPrincipal.Text) Then
            MsgBox("Invalid principal value.", MsgBoxStyle.Exclamation, "Invalid Value")
            Return
        End If

        If CDbl(txtPrincipal.Text) < minAmount Or CDbl(txtPrincipal.Text) > maxAmount Then
            MsgBox("Must be between " & Format(minAmount, "Standard") & " and " & Format(maxAmount, "Standard") & " principal's amount.", MsgBoxStyle.Exclamation, "Invalid Value")
            txtPrincipal.Text = Format(minAmount, "Standard")
            Return
        End If

        If dtpValueDate.Checked = False Then
            MsgBox("Unchecked value date.", MsgBoxStyle.Exclamation, "Check Value Date")
            Return
        End If

        If Not IsNumeric(Me.nudTerm.Value) Then
            MsgBox("Invalid period value.", MsgBoxStyle.Exclamation, "Invalid Period")
            Return
        End If

        If Not IsNumeric(Me.txtInterest.Text) Then
            MsgBox("Invalid interest rate value.", MsgBoxStyle.Exclamation, "Invalid Interest Rate")
            Return
        End If

        If cboTypeName.Text.Trim = "" Then
            MsgBox("Invalid loan type", MsgBoxStyle.Exclamation, "Invalid Loan Type")
            Exit Sub
        End If

        Compute_Interest_Payment()
    End Sub

    Private Sub txtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrincipal.KeyPress
        objPress(sender, e)
    End Sub

    Private Sub txtInterest_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInterest.KeyPress
        objPress(sender, e)
    End Sub

    Private Sub txtPeriod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudTerm.KeyPress
        objPress(sender, e)
    End Sub

    Private Sub cboTypeName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTypeName.TextChanged
        Dim dtable As DataTable = Nothing

        If State <> VIEW_STATE Then
            cboTypeId.SelectedIndex = cboTypeName.SelectedIndex
            With clsLoanType
                .Init_Flag = 2
                .Type_Id = CInt(cboTypeId.Text)
                dtable = .Search_Record()
                Dim myRow As DataRow
                For Each myRow In dtable.Rows
                    nudTerm.Minimum = Trim(myRow("terms_min").ToString)
                    nudTerm.Maximum = Trim(myRow("terms_max").ToString)
                    nudTerm.Value = Trim(myRow("terms_min").ToString)
                    txtInterest.Text = Trim(myRow("interestRate").ToString)
                    minAmount = Trim(myRow("amount_min").ToString)
                    maxAmount = Trim(myRow("amount_max").ToString)
                    txtPrincipal.Text = Format(minAmount, "Standard")
                Next
            End With
        End If
    End Sub

    Private Sub txtPrincipal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrincipal.LostFocus
        txtPrincipal.Text = Format(txtPrincipal.Text, "Standard")
    End Sub

#End Region

End Class