Namespace MemberEducationalBackground

    Public Class MemberEducationalBackground

        Private EducationalLevel As String
        Private SchoolName As String
        Private DegreeCourse As String
        Private HigestGrade As String
        Private FromDate As String
        Private TempFromDate As Date
        Private ToDate As String
        Private TempToDate As Date
        Private HonorsReceived As String

        Public Property Educational_Level() As String
            Get
                Return EducationalLevel
            End Get
            Set(ByVal value As String)
                If EducationalLevel = value Then
                    Return
                End If
                EducationalLevel = value
            End Set
        End Property

        Public Property School_Name() As String
            Get
                Return SchoolName
            End Get
            Set(ByVal value As String)
                If SchoolName = value Then
                    Return
                End If
                SchoolName = value
            End Set
        End Property

        Public Property Degree_Course() As String
            Get
                Return DegreeCourse
            End Get
            Set(ByVal value As String)
                If DegreeCourse = value Then
                    Return
                End If
                DegreeCourse = value
            End Set
        End Property

        Public Property Higest_Grade() As String
            Get
                Return HigestGrade
            End Get
            Set(ByVal value As String)
                If HigestGrade = value Then
                    Return
                End If
                HigestGrade = value
            End Set
        End Property

        Public Property From_Date() As String
            Get
                Return FromDate
            End Get
            Set(ByVal value As String)
                If FromDate = value Then
                    Return
                End If
                FromDate = value
            End Set
        End Property

        Public Property TempFrom_Date() As Date
            Get
                Return TempFromDate
            End Get
            Set(ByVal value As Date)
                If TempFromDate = value Then
                    Return
                End If
                TempFromDate = value
            End Set
        End Property

        Public Property To_Date() As String
            Get
                Return ToDate
            End Get
            Set(ByVal value As String)
                If ToDate = value Then
                    Return
                End If
                ToDate = value
            End Set
        End Property

        Public Property TempTo_Date() As Date
            Get
                Return TempToDate
            End Get
            Set(ByVal value As Date)
                If TempToDate = value Then
                    Return
                End If
                TempToDate = value
            End Set
        End Property

        Public Property Honors_Received() As String
            Get
                Return HonorsReceived
            End Get
            Set(ByVal value As String)
                If HonorsReceived = value Then
                    Return
                End If
                HonorsReceived = value
            End Set
        End Property

    End Class

End Namespace
