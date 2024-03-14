Namespace MemberLoanPaymentDetails

    Public Class MemberLoanPaymentDetails

        Private memberId As Integer
        Private loanId As Integer
        Private loantypeId As Integer
        Private loanPaymentDt As String
        Private loanPaymentAmount As Double

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

        Public Property _loanId() As Integer
            Get
                Return loanId
            End Get
            Set(ByVal value As Integer)
                If loanId = value Then
                    Return
                End If
                loanId = value
            End Set
        End Property

        Public Property _loanTypeId() As Integer
            Get
                Return loantypeId
            End Get
            Set(ByVal value As Integer)
                If loantypeId = value Then
                    Return
                End If
                loantypeId = value
            End Set
        End Property

        Public Property _loanPaymentDt() As String
            Get
                Return loanPaymentDt
            End Get
            Set(ByVal value As String)
                If loanPaymentDt = value Then
                    Return
                End If
                loanPaymentDt = value
            End Set
        End Property

        Public Property _loanPaymentAmount() As Double
            Get
                Return loanPaymentAmount
            End Get
            Set(ByVal value As Double)
                If loanPaymentAmount = value Then
                    Return
                End If
                loanPaymentAmount = value
            End Set
        End Property

    End Class

End Namespace
