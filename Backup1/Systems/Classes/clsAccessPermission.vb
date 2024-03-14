Namespace AccessPermission

    Public Class AccessPermission

        Private ModuleID As Integer
        Private ViewPermission As Integer
        Private AddPermission As Integer
        Private SavePermission As Integer
        Private DeletePermission As Integer
        Private ApprovePermission As Integer

        Public Property Module_ID() As Integer
            Get
                Return ModuleID
            End Get
            Set(ByVal value As Integer)
                If ModuleID = value Then
                    Return
                End If
                ModuleID = value
            End Set
        End Property

        Public Property View_Permission() As Integer
            Get
                Return ViewPermission
            End Get
            Set(ByVal value As Integer)
                If ViewPermission = value Then
                    Return
                End If
                ViewPermission = value
            End Set
        End Property

        Public Property Add_Permission() As Integer
            Get
                Return AddPermission
            End Get
            Set(ByVal value As Integer)
                If AddPermission = value Then
                    Return
                End If
                AddPermission = value
            End Set
        End Property

        Public Property Save_Permission() As Integer
            Get
                Return SavePermission
            End Get
            Set(ByVal value As Integer)
                If SavePermission = value Then
                    Return
                End If
                SavePermission = value
            End Set
        End Property

        Public Property Delete_Permission() As Integer
            Get
                Return DeletePermission
            End Get
            Set(ByVal value As Integer)
                If DeletePermission = value Then
                    Return
                End If
                DeletePermission = value
            End Set
        End Property

        Public Property Approve_Permission() As Integer
            Get
                Return ApprovePermission
            End Get
            Set(ByVal value As Integer)
                If ApprovePermission = value Then
                    Return
                End If
                ApprovePermission = value
            End Set
        End Property

    End Class

End Namespace
