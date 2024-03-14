
Namespace MemberFamilyBackground

    Public Class MemberFamilyBackground

        Private SpouseFName As String
        Private SpouseMName As String
        Private SpouseLName As String
        Private SpouseSuffix As String
        Private SpouseBirth As String
        Private TempSpouseBirth As Date
        Private FatherFName As String
        Private FatherMName As String
        Private FatherLName As String
        Private FatherSuffix As String
        Private MotherFName As String
        Private MotherMName As String
        Private MotherLName As String

        Public Property Spouse_FName() As String
            Get
                Return SpouseFName
            End Get
            Set(ByVal value As String)
                If SpouseFName = value Then
                    Return
                End If
                SpouseFName = value
            End Set
        End Property

        Public Property Spouse_MName() As String
            Get
                Return SpouseMName
            End Get
            Set(ByVal value As String)
                If SpouseMName = value Then
                    Return
                End If
                SpouseMName = value
            End Set
        End Property

        Public Property Spouse_LName() As String
            Get
                Return SpouseLName
            End Get
            Set(ByVal value As String)
                If SpouseLName = value Then
                    Return
                End If
                SpouseLName = value
            End Set
        End Property

        Public Property Spouse_Suffix() As String
            Get
                Return SpouseSuffix
            End Get
            Set(ByVal value As String)
                If SpouseSuffix = value Then
                    Return
                End If
                SpouseSuffix = value
            End Set
        End Property

        Public Property Spouse_Birth() As String
            Get
                Return SpouseBirth
            End Get
            Set(ByVal value As String)
                If SpouseBirth = value Then
                    Return
                End If
                SpouseBirth = value
            End Set
        End Property

        Public Property TempSpouse_Date() As Date
            Get
                Return TempSpouseBirth
            End Get
            Set(ByVal value As Date)
                If TempSpouseBirth = value Then
                    Return
                End If
                TempSpouseBirth = value
            End Set
        End Property

        Public Property Father_FName() As String
            Get
                Return FatherFName
            End Get
            Set(ByVal value As String)
                If FatherFName = value Then
                    Return
                End If
                FatherFName = value
            End Set
        End Property

        Public Property Father_MName() As String
            Get
                Return FatherMName
            End Get
            Set(ByVal value As String)
                If FatherMName = value Then
                    Return
                End If
                FatherMName = value
            End Set
        End Property

        Public Property Father_LName() As String
            Get
                Return FatherLName
            End Get
            Set(ByVal value As String)
                If FatherLName = value Then
                    Return
                End If
                FatherLName = value
            End Set
        End Property

        Public Property Father_Suffix() As String
            Get
                Return FatherSuffix
            End Get
            Set(ByVal value As String)
                If FatherSuffix = value Then
                    Return
                End If
                FatherSuffix = value
            End Set
        End Property

        Public Property Mother_FName() As String
            Get
                Return MotherFName
            End Get
            Set(ByVal value As String)
                If MotherFName = value Then
                    Return
                End If
                MotherFName = value
            End Set
        End Property

        Public Property Mother_MName() As String
            Get
                Return MotherMName
            End Get
            Set(ByVal value As String)
                If MotherMName = value Then
                    Return
                End If
                MotherMName = value
            End Set
        End Property

        Public Property Mother_LName() As String
            Get
                Return MotherLName
            End Get
            Set(ByVal value As String)
                If MotherLName = value Then
                    Return
                End If
                MotherLName = value
            End Set
        End Property
    End Class

End Namespace
