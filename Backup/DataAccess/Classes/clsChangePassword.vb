Imports MySql.Data.MySqlClient

Namespace ChangePassword

    Public Class ChangePassword

        Private userID As Integer
        Private userName As String
        Private oldPassword As String
        Private newPassword As String
        Private updatedBy As Integer

        Private sqlStmt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private clsCommon As New Common.Common
        Private clsDataAccess As New DataAccess(gConnStringFileName)

        Public Property user_ID() As Integer
            Get
                Return Me.userID
            End Get
            Set(ByVal Value As Integer)
                userID = Value
            End Set
        End Property

        Public Property user_Name() As String
            Get
                Return Me.userName
            End Get
            Set(ByVal Value As String)
                userName = Value
            End Set
        End Property

        Public Property oldPasswrd() As String
            Get
                Return Me.oldPassword
            End Get
            Set(ByVal Value As String)
                oldPassword = Value
            End Set
        End Property

        Public Property newPasswrd() As String
            Get
                Return Me.newPassword
            End Get
            Set(ByVal Value As String)
                newPassword = Value
            End Set
        End Property

        Public WriteOnly Property updated_By() As Integer
            Set(ByVal Value As Integer)
                updatedBy = Value
            End Set
        End Property

        Public Function Selected_Record() As Boolean
            Dim strSql As String
            Dim ErrorMsg As String = ""
            Dim dtSelectedRecord As DataTable

            Try
                With clsDataAccess

                    strSql = "CALL spSystemUserFind(" & userID & ",'','','',0,2);"

                    dtSelectedRecord = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Dim myRow As DataRow

                    For Each myRow In dtSelectedRecord.Rows
                        ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return False
                        Exit Function
                    End If

                    Dim myRow1 As DataRow

                    For Each myRow1 In dtSelectedRecord.Rows
                        Me.UserID = Trim(myRow1("userID").ToString)
                        Me.UserName = Trim(myRow1("userName").ToString)
                    Next

                End With
                Return True
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return False
            Finally
                dtSelectedRecord = Nothing
            End Try
        End Function

        Public Function Save_Record() As Boolean
            Try
                Dim ErrorMsg As String = ""


                Clean_Parameters_Save()

                Save_Record = True

                With clsDataAccess
                    sqlStmt = "CALL spChangeSystemUserPassword(" & UserID & ",'" & UserName & "','" & clsCommon.Crypt(OldPassword) & _
                    "','" & clsCommon.Crypt(NewPassword) & "'," & UpdatedBy & ");"

                    Me.dtSave = .ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return False
                    Else
                        RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                        Return True
                    End If
                End With

            Catch ex As MySqlException
                'error was encountered while populating record
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Record = False
            End Try
        End Function

        Private Sub Clean_Parameters_Save()
            With clsCommon
                UserName = .ReplaceSingleQuotes(UserName)
                OldPassword = .ReplaceSingleQuotes(OldPassword)
                NewPassword = .ReplaceSingleQuotes(NewPassword)
                UpdatedBy = .ReplaceSingleQuotes(UpdatedBy)
            End With
        End Sub

    End Class

End Namespace
