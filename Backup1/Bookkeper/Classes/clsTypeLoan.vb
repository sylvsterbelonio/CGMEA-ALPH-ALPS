Imports System.IO
Imports MySql.Data.MySqlClient

Namespace LoanType

    Public Class LoanType

#Region "Class LoanType Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritTypeName As String

        Private typeId As Integer

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsCommon As New Common.Common

#End Region

#Region "Class LoanType Public Property Variable Declaration"

        Public WriteOnly Property Init_Flag() As Integer
            Set(ByVal Value As Integer)
                If initFlag = Value Then
                    Return
                End If
                initFlag = Value
            End Set
        End Property

        Public Property Type_Id() As Integer
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

        Public WriteOnly Property CritType_Name() As String
            Set(ByVal Value As String)
                If CritTypeName = Value Then
                    Return
                End If
                CritTypeName = Value
            End Set
        End Property

#End Region

#Region "Class LoanType Public Functions"

        Public Function Search_Record()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spLoanTypeFind(" & typeId & ",'" & CritTypeName & "'," & initFlag & ");"

                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Dim myRow As DataRow

                    For Each myRow In dtgRID.Rows
                        ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return Nothing
                    Else
                        clsDataAccess = Nothing
                        Return dtgRID
                    End If
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function Search_Loan_Type_Record()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spLoanApplicationTypeFind(" & typeId & ",'" & CritTypeName & "'," & initFlag & ");"

                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Dim myRow As DataRow

                    For Each myRow In dtgRID.Rows
                        ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return Nothing
                    Else
                        clsDataAccess = Nothing
                        Return dtgRID
                    End If
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

#End Region

#Region "Class LoanType Private Sub"

#End Region

    End Class

End Namespace

