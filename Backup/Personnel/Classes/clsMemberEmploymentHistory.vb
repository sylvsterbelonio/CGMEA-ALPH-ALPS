Namespace MemberEmploymentHistory

    Public Class MemberEmploymentHistory

        Private FromDate As String
        Private TempFromDate As Date
        Private ToDate As String
        Private TempToDate As Date
        Private CompanyName As String
        Private JobTitle As String
        Private CompanyContactNo As String
        Private CompanyAddress As String
        Private MonthlySalary As Double
        Private TaskAccomplishment As String

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

        Public Property Company_Name() As String
            Get
                Return CompanyName
            End Get
            Set(ByVal value As String)
                If CompanyName = value Then
                    Return
                End If
                CompanyName = value
            End Set
        End Property

        Public Property Job_Title() As String
            Get
                Return JobTitle
            End Get
            Set(ByVal value As String)
                If JobTitle = value Then
                    Return
                End If
                JobTitle = value
            End Set
        End Property

        Public Property CompanyContact_No() As String
            Get
                Return CompanyContactNo
            End Get
            Set(ByVal value As String)
                If CompanyContactNo = value Then
                    Return
                End If
                CompanyContactNo = value
            End Set
        End Property

        Public Property Company_Address() As String
            Get
                Return CompanyAddress
            End Get
            Set(ByVal value As String)
                If CompanyAddress = value Then
                    Return
                End If
                CompanyAddress = value
            End Set
        End Property

        Public Property Monthly_Salary() As Double
            Get
                Return MonthlySalary
            End Get
            Set(ByVal value As Double)
                If MonthlySalary = value Then
                    Return
                End If
                MonthlySalary = value
            End Set
        End Property

        Public Property Task_Accomplishment() As String
            Get
                Return TaskAccomplishment
            End Get
            Set(ByVal value As String)
                If TaskAccomplishment = value Then
                    Return
                End If
                TaskAccomplishment = value
            End Set
        End Property

    End Class

End Namespace
