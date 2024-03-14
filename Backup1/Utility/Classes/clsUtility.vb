Imports System.Windows.Forms

Public Class Utility

#Region "Class Utility Declarations"

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
    End Sub

#End Region

#Region "Class Utility Class Declarations"

    Public Function NewclsBank()
        Try
            NewclsBank = New Bank.Bank
            Return NewclsBank
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsSignatory()
        Try
            NewclsSignatory = New Signatory.Signatory
            Return NewclsSignatory
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMemberSignatory()
        Try
            NewclsMemberSignatory = New MemberSignatory.MemberSignatory
            Return NewclsMemberSignatory
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsCollectionType()
        Try
            NewclsCollectionType = New CollectionType.CollectionType
            Return NewclsCollectionType
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsCollectionFee()
        Try
            NewclsCollectionFee = New CollectionFee.CollectionFee
            Return NewclsCollectionFee
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Utility Forms Declarations"

    Public Function NewfrmBank() As Form
        Try
            NewfrmBank = New frmBank
            Return NewfrmBank
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmBankFinder() As Form
        Try
            NewfrmBankFinder = New frmBankFinder
            Return NewfrmBankFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmSignatory() As Form
        Try
            NewfrmSignatory = New frmSignatory
            Return NewfrmSignatory
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmSignatoryFinder() As Form
        Try
            NewfrmSignatoryFinder = New frmSignatoryFinder
            Return NewfrmSignatoryFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberSignatoryFinder() As Form
        Try
            NewfrmMemberSignatoryFinder = New frmMemberSignatoryFinder
            Return NewfrmMemberSignatoryFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCollectionType() As Form
        Try
            NewfrmCollectionType = New frmCollectionType
            Return NewfrmCollectionType
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCollectionTypeFinder() As Form
        Try
            NewfrmCollectionTypeFinder = New frmCollectionTypeFinder
            Return NewfrmCollectionTypeFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCollectionFee() As Form
        Try
            NewfrmCollectionFee = New frmCollectionFee
            Return NewfrmCollectionFee
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmCollectionFeeFinder() As Form
        Try
            NewfrmCollectionFeeFinder = New frmCollectionFeeFinder
            Return NewfrmCollectionFeeFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class
