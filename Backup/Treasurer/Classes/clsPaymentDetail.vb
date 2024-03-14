Namespace Payment

    Public Class PaymentDetail

        Private paymentBillingId As Integer
        Private billingId As Long
        Private paymentId As Integer
        Private typeId As Integer
        Private amountPaid As Double
        Private paymentRemarks As String
        Private discountAmount As Double
        Private finesAmount As Double
        Private referenceId As Long

        Public Property paymentBilling_Id() As Integer
            Get
                Return paymentBillingId
            End Get
            Set(ByVal value As Integer)
                If paymentBillingId = value Then
                    Return
                End If
                paymentBillingId = value
            End Set
        End Property

        Public Property billing_Id() As Long
            Get
                Return billingId
            End Get
            Set(ByVal value As Long)
                If billingId = value Then
                    Return
                End If
                billingId = value
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

        Public Property type_Id() As Integer
            Get
                Return typeId
            End Get
            Set(ByVal value As Integer)
                If typeId = value Then
                    Return
                End If
                typeId = value
            End Set
        End Property

        Public Property amount_Paid() As Double
            Get
                Return amountPaid
            End Get
            Set(ByVal value As Double)
                If amountPaid = value Then
                    Return
                End If
                amountPaid = value
            End Set
        End Property

        Public Property payment_Remarks() As String
            Get
                Return paymentRemarks
            End Get
            Set(ByVal value As String)
                If paymentRemarks = value Then
                    Return
                End If
                paymentRemarks = value
            End Set
        End Property

        Public Property discount_Amount() As Double
            Get
                Return discountAmount
            End Get
            Set(ByVal value As Double)
                If discountAmount = value Then
                    Return
                End If
                discountAmount = value
            End Set
        End Property

        Public Property fines_Amount() As Double
            Get
                Return finesAmount
            End Get
            Set(ByVal value As Double)
                If finesAmount = value Then
                    Return
                End If
                finesAmount = value
            End Set
        End Property

        Public Property reference_Id() As Long
            Get
                Return referenceId
            End Get
            Set(ByVal value As Long)
                If referenceId = value Then
                    Return
                End If
                referenceId = value
            End Set
        End Property

    End Class

End Namespace
