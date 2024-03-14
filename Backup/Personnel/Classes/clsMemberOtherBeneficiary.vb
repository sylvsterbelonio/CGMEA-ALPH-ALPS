Namespace MemberOtherBeneficiary

    Public Class MemberOtherBeneficiary

        Private BeneficiaryFName As String
        Private BeneficiaryMName As String
        Private BeneficiaryLName As String
        Private BeneficiarySuffix As String
        Private BeneficiaryRelation As String

        Public Property Beneficiary_FName() As String
            Get
                Return BeneficiaryFName
            End Get
            Set(ByVal value As String)
                If BeneficiaryFName = value Then
                    Return
                End If
                BeneficiaryFName = value
            End Set
        End Property

        Public Property Beneficiary_MName() As String
            Get
                Return BeneficiaryMName
            End Get
            Set(ByVal value As String)
                If BeneficiaryMName = value Then
                    Return
                End If
                BeneficiaryMName = value
            End Set
        End Property

        Public Property Beneficiary_LName() As String
            Get
                Return BeneficiaryLName
            End Get
            Set(ByVal value As String)
                If BeneficiaryLName = value Then
                    Return
                End If
                BeneficiaryLName = value
            End Set
        End Property

        Public Property Beneficiary_Suffix() As String
            Get
                Return BeneficiarySuffix
            End Get
            Set(ByVal value As String)
                If BeneficiarySuffix = value Then
                    Return
                End If
                BeneficiarySuffix = value
            End Set
        End Property

        Public Property Beneficiary_Relation() As String
            Get
                Return BeneficiaryRelation
            End Get
            Set(ByVal value As String)
                If BeneficiaryRelation = value Then
                    Return
                End If
                BeneficiaryRelation = value
            End Set
        End Property

    End Class

End Namespace
