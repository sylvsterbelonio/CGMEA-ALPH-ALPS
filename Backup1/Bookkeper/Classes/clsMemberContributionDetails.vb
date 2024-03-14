Namespace MemberContributionDetails

    Public Class MemberContributionDetails

        Private memberId As Integer
        Private contributionDt As String
        Private contributionAmount As Double
        Private pabaonAmount As Double
        Private mortuaryAmount As Double
        Private pSLinkAmount As Double

        Public Property _memberId() As Integer
            Get
                Return memberId
            End Get
            Set(ByVal value As Integer)
                If memberId = value Then
                    Return
                End If
                memberId = value
            End Set
        End Property

        Public Property _contributionDt() As String
            Get
                Return contributionDt
            End Get
            Set(ByVal value As String)
                If contributionDt = value Then
                    Return
                End If
                contributionDt = value
            End Set
        End Property

        Public Property _contributionAmount() As Double
            Get
                Return contributionAmount
            End Get
            Set(ByVal value As Double)
                If contributionAmount = value Then
                    Return
                End If
                contributionAmount = value
            End Set
        End Property

        Public Property _pabaonAmount() As Double
            Get
                Return pabaonAmount
            End Get
            Set(ByVal value As Double)
                If pabaonAmount = value Then
                    Return
                End If
                pabaonAmount = value
            End Set
        End Property

        Public Property _mortuaryAmount() As Double
            Get
                Return mortuaryAmount
            End Get
            Set(ByVal value As Double)
                If mortuaryAmount = value Then
                    Return
                End If
                mortuaryAmount = value
            End Set
        End Property

        Public Property _pSLinkAmount() As Double
            Get
                Return pSLinkAmount
            End Get
            Set(ByVal value As Double)
                If pSLinkAmount = value Then
                    Return
                End If
                pSLinkAmount = value
            End Set
        End Property

    End Class

End Namespace
