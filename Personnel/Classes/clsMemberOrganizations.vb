Namespace MemberOrganizations

    Public Class MemberOrganizations

        Private OrganizationName As String
        Private OrganizationPosition As String
        Private SinceDate As String
        Private TempSinceDate As Date
        Private OrganizationAddress As String

        Public Property Organization_Name() As String
            Get
                Return OrganizationName
            End Get
            Set(ByVal value As String)
                If OrganizationName = value Then
                    Return
                End If
                OrganizationName = value
            End Set
        End Property

        Public Property Organization_Position() As String
            Get
                Return OrganizationPosition
            End Get
            Set(ByVal value As String)
                If OrganizationPosition = value Then
                    Return
                End If
                OrganizationPosition = value
            End Set
        End Property

        Public Property Since_Date() As String
            Get
                Return SinceDate
            End Get
            Set(ByVal value As String)
                If SinceDate = value Then
                    Return
                End If
                SinceDate = value
            End Set
        End Property

        Public Property TempSince_Date() As Date
            Get
                Return TempSinceDate
            End Get
            Set(ByVal value As Date)
                If TempSinceDate = value Then
                    Return
                End If
                TempSinceDate = value
            End Set
        End Property

        Public Property Organization_Address() As String
            Get
                Return OrganizationAddress
            End Get
            Set(ByVal value As String)
                If OrganizationAddress = value Then
                    Return
                End If
                OrganizationAddress = value
            End Set
        End Property

    End Class

End Namespace
