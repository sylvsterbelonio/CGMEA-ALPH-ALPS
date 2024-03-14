
Namespace ContributionDetails

    Public Class ContributionDetails

        Private ContributionId As Integer
        Private TypeId As Integer
        Private ContributionDt As String
        Private Amount As Double
        Private Remarks As String

        Public Property _ContributionId() As Integer
            Get
                Return ContributionId
            End Get
            Set(ByVal Value As Integer)
                If ContributionId = Value Then
                    Return
                End If
                ContributionId = Value
            End Set
        End Property

        Public Property _TypeId() As Integer
            Get
                Return TypeId
            End Get
            Set(ByVal Value As Integer)
                If TypeId = Value Then
                    Return
                End If
                TypeId = Value
            End Set
        End Property

        Public Property _ContributionDt() As String
            Get
                Return ContributionDt
            End Get
            Set(ByVal Value As String)
                If ContributionDt = Value Then
                    Return
                End If
                ContributionDt = Value
            End Set
        End Property

        Public Property _Amount() As Double
            Get
                Return Amount
            End Get
            Set(ByVal Value As Double)
                If Amount = Value Then
                    Return
                End If
                Amount = Value
            End Set
        End Property

        Public Property _Remarks() As String
            Get
                Return Remarks
            End Get
            Set(ByVal Value As String)
                If Remarks = Value Then
                    Return
                End If
                Remarks = Value
            End Set
        End Property

    End Class

End Namespace
