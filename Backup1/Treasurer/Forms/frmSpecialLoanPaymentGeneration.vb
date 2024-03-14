Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Drawing
Imports System.Drawing.Color
Imports System.IO
Imports System.Xml
Public Class frmSpecialLoanPaymentGeneration
    Inherits System.Windows.Forms.Form
    Private WithEvents clsCommon As New Common.Common
    Private WithEvents clsPermission As New DataAccess.Permission(gConnStringFileName)

    Private WithEvents clsTreasurer As New Treasurer(gConnStringFileName, gApplicationPath, gUserID, gRoleID, gAssemblyProduct)
    Private WithEvents clsLoanPaymentUpdater As New Bookkeper.LoanPaymentUpdater.LoanPaymentUpdater
    Private WithEvents clsLoanApplication As New Bookkeper.LoanApplication.LoanApplication

    Private Sub frmSpecialLoanPaymentGeneration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Initialize_AutoComplete()
    End Sub

    Private Sub Initialize_AutoComplete()
        'member list
        Dim clsDA As New DataAccess.DataAccess(gConnStringFileName)
        Dim dataCombo As DataSet

        dataCombo = clsLoanApplication.GetLoanTypeList
        clsCommon.PopulateComboBox(cboLoanTypeId, cboLoanType, dataCombo)
    End Sub

    Private Sub cboLoanType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLoanType.TextChanged
        Dim dtable As DataTable = Nothing
        If cboLoanType.Text <> "" Then
            cboLoanTypeId.SelectedIndex = cboLoanType.SelectedIndex
        End If
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
                    If conDt <= orgDt Then
                        clsCommon.Prompt_User("information", "You are not allowed to generate members loan payment for the selected date.")
                        dtpPaymentDate.Focus()
                        Exit Sub
                    End If
                End If

                If conDt <= Now Then
                    Me.Cursor = WaitCursor
                    With clsLoanPaymentUpdater
                        ._tempLoanPaymentDt = dtpPaymentDate.Value
                        ._updatedBy = gUserID
                    End With

                    If clsLoanPaymentUpdater.Save_Generated_Special_Loan_Payment_Record(cboLoanTypeId.Text) Then
                        clsCommon.Prompt_User("information", "Member Special loan payment successfully uploaded.")
                        DialogResult = Windows.Forms.DialogResult.OK
                    Else
                        'Nothing
                    End If
                    Me.Cursor = Arrow
                Else
                    clsCommon.Prompt_User("information", "You are not allowed to generate members loan payment for the selected date.")
                    dtpPaymentDate.Focus()
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class