Namespace Payment

    Public Class PaymentCheck

        Private checkId As Integer
        Private paymentId As Integer
        Private bankId As Integer
        Private bankBranch As String
        Private checkNo As String
        Private checkAmount As Double
        Private checkDate As String
        Private clearingDate As String
        Private clearedFl As Integer
        Private checkRemarks As String

        Public Property check_Id() As Integer
            Get
                Return checkId
            End Get
            Set(ByVal value As Integer)
                If checkId = value Then
                    Return
                End If
                checkId = value
            End Set
        End Property

        Public Property payment_Id() As Integer
            Get
                Return paymentId
            End Get
            Set(ByVal value As Integer)
                If paymentId = value Then
                    Return
                End If
                paymentId = value
            End Set
        End Property

        Public Property bank_Id() As Integer
            Get
                Return bankId
            End Get
            Set(ByVal value As Integer)
                If bankId = value Then
                    Return
                End If
                bankId = value
            End Set
        End Property

        Public Property bank_Branch() As String
            Get
                Return bankBranch
            End Get
            Set(ByVal value As String)
                If bankBranch = value Then
                    Return
                End If
                bankBranch = value
            End Set
        End Property

        Public Property check_No() As String
            Get
                Return checkNo
            End Get
            Set(ByVal value As String)
                If checkNo = value Then
                    Return
                End If
                checkNo = value
            End Set
        End Property

        Public Property check_Amount() As Double
            Get
                Return checkAmount
            End Get
            Set(ByVal value As Double)
                If checkAmount = value Then
                    Return
                End If
                checkAmount = value
            End Set
        End Property

        Public Property check_Date() As String
            Get
                Return checkDate
            End Get
            Set(ByVal value As String)
                If checkDate = value Then
                    Return
                End If
                checkDate = value
            End Set
        End Property

        Public Property clearing_Date() As String
            Get
                Return clearingDate
            End Get
            Set(ByVal value As String)
                If clearingDate = value Then
                    Return
                End If
                clearingDate = value
            End Set
        End Property

        Public Property cleared_Fl() As Integer
            Get
                Return clearedFl
            End Get
            Set(ByVal value As Integer)
                If clearedFl = value Then
                    Return
                End If
                clearedFl = value
            End Set
        End Property

        Public Property check_Remarks() As String
            Get
                Return checkRemarks
            End Get
            Set(ByVal value As String)
                If checkRemarks = value Then
                    Return
                End If
                checkRemarks = value
            End Set
        End Property

    End Class

End Namespace
