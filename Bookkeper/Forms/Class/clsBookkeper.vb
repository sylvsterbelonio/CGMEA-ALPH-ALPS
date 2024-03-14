Imports System.Windows.Forms

Public Class Bookkeper

#Region "Class Bookkeper Declarations"

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

#Region "Class Bookkeper Class Declarations"

    Public Function NewclsContributionGeneration()
        Try
            NewclsContributionGeneration = New ContributionGeneration.ContributionGeneration
            Return NewclsContributionGeneration
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsLoanType()
        Try
            NewclsLoanType = New LoanType.LoanType
            Return NewclsLoanType
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMemberContribution()
        Try
            NewclsMemberContribution = New MemberContribution.MemberContribution
            Return NewclsMemberContribution
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMemberContributionUpdater()
        Try
            NewclsMemberContributionUpdater = New MemberContributionUpdater.MemberContributionUpdater
            Return NewclsMemberContributionUpdater
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMemberContributionDetails()
        Try
            NewclsMemberContributionDetails = New MemberContributionDetails.MemberContributionDetails
            Return NewclsMemberContributionDetails
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsLoanApplication()
        Try
            NewclsLoanApplication = New LoanApplication.LoanApplication
            Return NewclsLoanApplication
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsLoanApplicationApproval()
        Try
            NewclsLoanApplicationApproval = New LoanApplicationApproval.LoanApplicationApproval
            Return NewclsLoanApplicationApproval
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsLoanApplicationRelease()
        Try
            NewclsLoanApplicationRelease = New LoanApplicationRelease.LoanApplicationRelease
            Return NewclsLoanApplicationRelease
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMemberLoanPayment()
        Try
            NewclsMemberLoanPayment = New MemberLoanPayment.MemberLoanPayment
            Return NewclsMemberLoanPayment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


#End Region

#Region "Class Bookkeper Forms Declarations"

    Public Function NewfrmMemberContributionGeneration() As Form
        Try
            NewfrmMemberContributionGeneration = New frmMemberContributionGeneration
            Return NewfrmMemberContributionGeneration
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberContributionUpdater() As Form
        Try
            NewfrmMemberContributionUpdater = New frmMemberContributionUpdater
            Return NewfrmMemberContributionUpdater
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanApplication() As Form
        Try
            NewfrmLoanApplication = New frmLoanApplication
            Return NewfrmLoanApplication
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanApplicationFinder() As Form
        Try
            NewfrmLoanApplicationFinder = New frmLoanApplicationFinder
            Return NewfrmLoanApplicationFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmFSFinder() As Form
        Try
            NewfrmFSFinder = New frmFSFinder
            Return NewfrmFSFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Public Function NewfrmFinancialExpensesSummary() As Form
        Try
            NewfrmFinancialExpensesSummary = New frmFSReport
            Return NewfrmFinancialExpensesSummary
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmExpensesFinder() As Form
        Try
            NewfrmExpensesFinder = New frmExpensesFinder
            Return NewfrmExpensesFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanApplicationApproval() As Form
        Try
            NewfrmLoanApplicationApproval = New frmLoanApplicationApproval
            Return NewfrmLoanApplicationApproval
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanApplicationApprovalFinder() As Form
        Try
            NewfrmLoanApplicationApprovalFinder = New frmLoanApplicationApprovalFinder
            Return NewfrmLoanApplicationApprovalFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanApplicationRelease() As Form
        Try
            NewfrmLoanApplicationRelease = New frmLoanApplicationRelease
            Return NewfrmLoanApplicationRelease
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanApplicationReleaseFinder() As Form
        Try
            NewfrmLoanApplicationReleaseFinder = New frmLoanApplicationReleaseFinder
            Return NewfrmLoanApplicationReleaseFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberContribution() As Form
        Try
            NewfrmMemberContribution = New frmMemberContribution
            Return NewfrmMemberContribution
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberContributionFinder() As Form
        Try
            NewfrmMemberContributionFinder = New frmMemberContributionFinder
            Return NewfrmMemberContributionFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanCalculator() As Form
        Try
            NewfrmLoanCalculator = New frmLoanCalculator
            Return NewfrmLoanCalculator
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmTypeLoanFinder() As Form
        Try
            NewfrmTypeLoanFinder = New frmTypeLoanFinder
            Return NewfrmTypeLoanFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanRateFinder() As Form
        Try
            NewfrmLoanRateFinder = New frmLoanRateFinder
            Return NewfrmLoanRateFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmRevisionFinder() As Form
        Try
            NewfrmRevisionFinder = New frmRevisionFinder
            Return NewfrmRevisionFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmrefVariableFinder() As Form
        Try
            NewfrmrefVariableFinder = New frmrefVariableFinder
            Return NewfrmrefVariableFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberLoanPaymentGeneration() As Form
        Try
            NewfrmMemberLoanPaymentGeneration = New frmMemberLoanPaymentGeneration
            Return NewfrmMemberLoanPaymentGeneration
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmContributionAndPaymentSummary() As Form
        Try
            NewfrmContributionAndPaymentSummary = New frmContributionAndPaymentSummary
            Return NewfrmContributionAndPaymentSummary
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberContributionSummary() As Form
        Try
            NewfrmMemberContributionSummary = New frmMemberContributionSummary
            Return NewfrmMemberContributionSummary
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanChecksIssued() As Form
        Try
            NewfrmLoanChecksIssued = New frmLoanChecksIssued
            Return NewfrmLoanChecksIssued
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLoanPaymentUpdater() As Form
        Try
            NewfrmLoanPaymentUpdater = New frmLoanPaymentUpdater
            Return NewfrmLoanPaymentUpdater
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberContributionAndDrawing() As Form
        Try
            NewfrmMemberContributionAndDrawing = New frmMemberContributionAndDrawing
            Return NewfrmMemberContributionAndDrawing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class

