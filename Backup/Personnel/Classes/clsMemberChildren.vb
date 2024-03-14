
Namespace MemberChildren

    Public Class MemberChildren

        Private ChildFName As String
        Private ChildMName As String
        Private ChildLName As String
        Private ChildSuffix As String
        Private ChildBirth As String
        Private TempChildBirth As Date
        Private ChildStatus As String

        Public Property Child_FName() As String
            Get
                Return ChildFName
            End Get
            Set(ByVal value As String)
                If ChildFName = value Then
                    Return
                End If
                ChildFName = value
            End Set
        End Property

        Public Property Child_MName() As String
            Get
                Return ChildMName
            End Get
            Set(ByVal value As String)
                If ChildMName = value Then
                    Return
                End If
                ChildMName = value
            End Set
        End Property

        Public Property Child_LName() As String
            Get
                Return ChildLName
            End Get
            Set(ByVal value As String)
                If ChildLName = value Then
                    Return
                End If
                ChildLName = value
            End Set
        End Property

        Public Property Child_Suffix() As String
            Get
                Return ChildSuffix
            End Get
            Set(ByVal value As String)
                If ChildSuffix = value Then
                    Return
                End If
                ChildSuffix = value
            End Set
        End Property

        Public Property Child_Birth() As String
            Get
                Return ChildBirth
            End Get
            Set(ByVal value As String)
                If ChildBirth = value Then
                    Return
                End If
                ChildBirth = value
            End Set
        End Property

        Public Property Child_Status() As String
            Get
                Return ChildStatus
            End Get
            Set(ByVal value As String)
                If ChildStatus = value Then
                    Return
                End If
                ChildStatus = value
            End Set
        End Property

        Public Property TempChild_Date() As Date
            Get
                Return TempChildBirth
            End Get
            Set(ByVal value As Date)
                If TempChildBirth = value Then
                    Return
                End If
                TempChildBirth = value
            End Set
        End Property


    End Class

End Namespace
