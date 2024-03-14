Namespace MemberSeminarsAttended

    Public Class MemberSeminarsAttended

        Private SeminarName As String
        Private SeminarLocation As String
        Private SeminarDate As String
        Private TempSeminarDate As Date
        Private SeminarRemarks As String

        Public Property Seminar_Name() As String
            Get
                Return SeminarName
            End Get
            Set(ByVal value As String)
                If SeminarName = value Then
                    Return
                End If
                SeminarName = value
            End Set
        End Property

        Public Property Seminar_Location() As String
            Get
                Return SeminarLocation
            End Get
            Set(ByVal value As String)
                If SeminarLocation = value Then
                    Return
                End If
                SeminarLocation = value
            End Set
        End Property

        Public Property Seminar_Date() As String
            Get
                Return SeminarDate
            End Get
            Set(ByVal value As String)
                If SeminarDate = value Then
                    Return
                End If
                SeminarDate = value
            End Set
        End Property

        Public Property TempSeminar_Date() As Date
            Get
                Return TempSeminarDate
            End Get
            Set(ByVal value As Date)
                If TempSeminarDate = value Then
                    Return
                End If
                TempSeminarDate = value
            End Set
        End Property

        Public Property Seminar_Remarks() As String
            Get
                Return SeminarRemarks
            End Get
            Set(ByVal value As String)
                If SeminarRemarks = value Then
                    Return
                End If
                SeminarRemarks = value
            End Set
        End Property

    End Class

End Namespace
