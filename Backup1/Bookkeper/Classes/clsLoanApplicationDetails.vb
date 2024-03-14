Namespace LoanApplicationDetails

    Public Class LoanApplicationDetails

        Private signatoryType As String
        Private signatoryName As String
        Private signatoryPosition As String
        Private signedBy As Integer

        Private feeId As Integer
        Private feeAmount As Double

        Private loanId As Integer
        Private loanBalAmount As Double
        Private loanRebates As Double
        Private loanUnused As Double

        Private scheduleDt As String
        Private monthlyInterest As Double
        Private monthlyPrincipal As Double
        Private totalAmount As Double

        Public Property _signatoryType() As String
            Get
                Return signatoryType
            End Get
            Set(ByVal value As String)
                If signatoryType = value Then
                    Return
                End If
                signatoryType = value
            End Set
        End Property

        Public Property _signatoryName() As String
            Get
                Return signatoryName
            End Get
            Set(ByVal value As String)
                If signatoryName = value Then
                    Return
                End If
                signatoryName = value
            End Set
        End Property

        Public Property _signatoryPosition() As String
            Get
                Return signatoryPosition
            End Get
            Set(ByVal value As String)
                If signatoryPosition = value Then
                    Return
                End If
                signatoryPosition = value
            End Set
        End Property

        Public Property _signedBy() As Integer
            Get
                Return signedBy
            End Get
            Set(ByVal value As Integer)
                If signedBy = value Then
                    Return
                End If
                signedBy = value
            End Set
        End Property

        Public Property _feeId() As Integer
            Get
                Return feeId
            End Get
            Set(ByVal value As Integer)
                If feeId = value Then
                    Return
                End If
                feeId = value
            End Set
        End Property

        Public Property _feeAmount() As Double
            Get
                Return feeAmount
            End Get
            Set(ByVal value As Double)
                If feeAmount = value Then
                    Return
                End If
                feeAmount = value
            End Set
        End Property

        'Loan Balance
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

        Public Property _loanBalAmount() As Double
            Get
                Return loanBalAmount
            End Get
            Set(ByVal value As Double)
                If loanBalAmount = value Then
                    Return
                End If
                loanBalAmount = value
            End Set
        End Property

        Public Property _loanRebates() As Double
            Get
                Return loanRebates
            End Get
            Set(ByVal value As Double)
                If loanRebates = value Then
                    Return
                End If
                loanRebates = value
            End Set
        End Property

        Public Property _loanUnused() As Double
            Get
                Return loanUnused
            End Get
            Set(ByVal value As Double)
                If loanUnused = value Then
                    Return
                End If
                loanUnused = value
            End Set
        End Property

        'End Loan Balance

        Public Property _scheduleDt() As String
            Get
                Return scheduleDt
            End Get
            Set(ByVal value As String)
                If scheduleDt = value Then
                    Return
                End If
                scheduleDt = value
            End Set
        End Property

        Public Property _monthlyInterest() As Double
            Get
                Return monthlyInterest
            End Get
            Set(ByVal value As Double)
                If monthlyInterest = value Then
                    Return
                End If
                monthlyInterest = value
            End Set
        End Property

        Public Property _monthlyPrincipal() As Double
            Get
                Return monthlyPrincipal
            End Get
            Set(ByVal value As Double)
                If monthlyPrincipal = value Then
                    Return
                End If
                monthlyPrincipal = value
            End Set
        End Property

        Public Property _totalAmount() As Double
            Get
                Return totalAmount
            End Get
            Set(ByVal value As Double)
                If totalAmount = value Then
                    Return
                End If
                totalAmount = value
            End Set
        End Property
    End Class

End Namespace
