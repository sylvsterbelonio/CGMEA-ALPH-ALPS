Imports System.Windows.Forms

Public Class Treasurer

#Region "Class Treasurer Declarations"

    Public WriteOnly Property UseRecordState() As String
        Set(ByVal value As String)
            If Use_Record_State = value Then
                Return
            End If
            Use_Record_State = value
        End Set
    End Property

    Public WriteOnly Property UseRecordId() As String
        Set(ByVal value As String)
            If Use_Record_Id = value Then
                Return
            End If
            Use_Record_Id = value
        End Set
    End Property

    Public WriteOnly Property UseRecordCd() As String
        Set(ByVal value As String)
            If Use_Record_Cd = value Then
                Return
            End If
            Use_Record_Cd = value
        End Set
    End Property

    Public WriteOnly Property UseRecordName() As String
        Set(ByVal value As String)
            If Use_Record_Name = value Then
                Return
            End If
            Use_Record_Name = value
        End Set
    End Property

    Public Sub New(ByVal fn As String, ByVal path As String, ByVal userId As Integer, ByVal roleId As Integer, ByVal gProduct As String)
        gConnStringFileName = fn
        gApplicationPath = path
        gUserID = userId
        gRoleID = roleId
        gAssemblyProduct = gProduct
        ImageDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\images"
        PresetDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\presets"
        ReportDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\templates"
    End Sub

#End Region

#Region "Class Treasurer Class Declarations"

    Public Function NewclsPayment()
        Try
            NewclsPayment = New Payment.Payment
            Return NewclsPayment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsCancelPayment()
        Try
            NewclsCancelPayment = New Payment.CancelPayment
            Return NewclsCancelPayment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Treasurer Forms Declarations"

    Public Function NewfrmPayment() As Form
        Try
            NewfrmPayment = New frmPayment
            Return NewfrmPayment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmPaymentLoanAndContribution() As Form
        Try
            NewfrmPaymentLoanAndContribution = New frmPaymentLoanAndContribution
            Return NewfrmPaymentLoanAndContribution
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmPaymentFinder(ByVal strFormTag As String) As Form
        Try
            NewfrmPaymentFinder = New frmPaymentFinder(strFormTag)
            Return NewfrmPaymentFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmPaymentLoanAndContributionFinder(ByVal strFormLoanTag As String) As Form
        Try
            NewfrmPaymentLoanAndContributionFinder = New frmPaymentLoanAndContributionFinder(strFormLoanTag)
            Return NewfrmPaymentLoanAndContributionFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCancelPayment() As Form
        Try
            NewfrmCancelPayment = New frmCancelPayment
            Return NewfrmCancelPayment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCancelPaymentFinder() As Form
        Try
            NewfrmCancelPaymentFinder = New frmCancelPaymentFinder
            Return NewfrmCancelPaymentFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmStartORNo() As Form
        Try
            NewfrmStartORNo = New frmStartORNo
            Return NewfrmStartORNo
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmOfficialReceiptsIssued() As Form
        Try
            NewfrmOfficialReceiptsIssued = New frmOfficialReceiptsIssued
            Return NewfrmOfficialReceiptsIssued
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmSpecialLoanPaymentGeneration() As Form
        Try
            NewfrmSpecialLoanPaymentGeneration = New frmSpecialLoanPaymentGeneration
            Return NewfrmSpecialLoanPaymentGeneration
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberWithdrawalFinder() As Form
        Try
            NewfrmMemberWithdrawalFinder = New frmMemberWithdrawalFinder
            Return NewfrmMemberWithdrawalFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class
