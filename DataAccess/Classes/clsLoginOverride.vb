Imports MySql.Data.MySqlClient

Namespace LoginOverride

    Public Class LoginOverride

#Region "Class LoginOverride Private Variable Declaration"

        Private UserID As Integer
        Private FName As String
        Private LName As String
        Private RoleID As Integer
        Private RoleName As String
        Private JobDesc As String
        Private ActiveFl As Integer
        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private dtLogin As DataTable
        Private clsCommon As New Common.Common
        Private clsDataAccess As New DataAccess(gConnStringFileName)
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class LoginOverride Public Property Declaration"

        Public ReadOnly Property User_ID()
            Get
                Return UserID
            End Get
        End Property

        Public ReadOnly Property First_Name()
            Get
                Return FName
            End Get
        End Property

        Public ReadOnly Property Last_Name()
            Get
                Return LName
            End Get
        End Property

        Public ReadOnly Property Role_Id()
            Get
                Return RoleID
            End Get
        End Property

        Public ReadOnly Property Role_Name()
            Get
                Return RoleName
            End Get
        End Property

        Public ReadOnly Property Job_Desc() As String
            Get
                Return Me.JobDesc
            End Get
        End Property

#End Region

#Region "Class LoginOverride Public Functions"

        Public Function ValidateLogin(ByVal UserName As String, ByVal Password As String) As Boolean
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoginOverrideValidate('" & clsCommon.ReplaceSingleQuotes(UserName) & "','" & clsCommon.ReplaceSingleQuotes(clsCommon.Crypt(Password)) & "');"
                dtLogin = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                UserID = dtLogin.Rows(0)("User_ID")
                FName = dtLogin.Rows(0)("First_Name")
                LName = dtLogin.Rows(0)("Last_Name")
                RoleID = dtLogin.Rows(0)("Role_Id")
                RoleName = dtLogin.Rows(0)("Role_Name")
                JobDesc = dtLogin.Rows(0)("Job_Desc")
                ActiveFl = dtLogin.Rows(0)("Active_Fl")

                If UserID > -1 And ActiveFl = 1 And RoleID = 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return False
            Catch err As Exception
                Throw err
            End Try
        End Function

#End Region

    End Class

End Namespace
