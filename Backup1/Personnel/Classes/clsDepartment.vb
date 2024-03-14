Imports MySql.Data.MySqlClient

Namespace Department

    Public Class Department

#Region "Class Department Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritDepartmentCode As String
        Private CritDepartmentName As String

        Private DepartmentID As Integer
        Private DepartmentName As String
        Private DepartmentCode As String
        Private DepartmentDescription As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Department Public Property Variable Declaration"

        Public WriteOnly Property Init_Flag() As Integer
            Set(ByVal Value As Integer)
                If initFlag = Value Then
                    Return
                End If
                initFlag = Value
            End Set
        End Property

        Public WriteOnly Property Dt_gRID() As DataTable
            Set(ByVal Value As DataTable)
                dtgRID = Value
            End Set
        End Property

        Public WriteOnly Property CritDepartment_Code() As String
            Set(ByVal Value As String)
                If CritDepartmentCode = Value Then
                    Return
                End If
                CritDepartmentCode = Value
            End Set
        End Property

        Public WriteOnly Property CritDepartment_Name() As String
            Set(ByVal Value As String)
                If CritDepartmentName = Value Then
                    Return
                End If
                CritDepartmentName = Value
            End Set
        End Property

        Public Property Department_ID() As Integer
            Get
                Return DepartmentID
            End Get
            Set(ByVal value As Integer)
                If DepartmentID = value Then
                    Return
                End If
                DepartmentID = value
            End Set
        End Property

        Public Property Department_Name() As String
            Get
                Return DepartmentName
            End Get
            Set(ByVal value As String)
                If DepartmentName = value Then
                    Return
                End If
                DepartmentName = value
            End Set
        End Property

        Public Property Department_Code() As String
            Get
                Return DepartmentCode
            End Get
            Set(ByVal value As String)
                If DepartmentCode = value Then
                    Return
                End If
                DepartmentCode = value
            End Set
        End Property

        Public Property Department_Description() As String
            Get
                Return DepartmentDescription
            End Get
            Set(ByVal value As String)
                If DepartmentDescription = value Then
                    Return
                End If
                DepartmentDescription = value
            End Set
        End Property

        Public WriteOnly Property Updated_By() As Integer
            Set(ByVal Value As Integer)
                If updatedBy = Value Then
                    Return
                End If
                updatedBy = Value
            End Set
        End Property

        Public Property Updated_Dt() As String
            Get
                Return updatedDt
            End Get
            Set(ByVal Value As String)
                If updatedDt = Value Then
                    Return
                End If
                updatedDt = Value
            End Set
        End Property

#End Region

#Region "Class Department Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spDepartmentSave(" & DepartmentID & ",'" & DepartmentCode & "','" & DepartmentName & "','" & DepartmentDescription & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        DepartmentID = Me.dtSaveRow("departmentId")
                        updatedDt = Me.dtSaveRow("updatedDt")
                    Next
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Record = False
            End Try
        End Function

        Public Function Delete_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim dtRec As DataTable

                Delete_Record = True
                strSql = "CALL spDepartmentDelete(" & DepartmentID & "," & updatedBy & ");"
                dtRec = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                Dim myRow As DataRow

                For Each myRow In dtRec.Rows
                    ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    RaiseEvent MsgArrival(MSGBOX_DELETE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Delete_Record = False
            End Try
        End Function

        Public Function Search_Record()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spDepartmentFind(" & DepartmentID _
                    & ",'" & CritDepartmentCode & "','" & CritDepartmentName & "'," & initFlag & ");"

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

        Public Function Selected_Record() As Boolean
            Dim strSql As String
            Dim ErrorMsg As String = ""
            Dim dtSelectedRecord As DataTable

            Try
                Clean_Parameters_Search()

                With clsDataAccess

                    strSql = "CALL spDepartmentFind(" & initFlag & ",'','',2);"

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
                        Me.DepartmentID = Trim(myRow1("departmentId").ToString)
                        Me.DepartmentCode = Trim(myRow1("departmentCode").ToString)
                        Me.DepartmentName = Trim(myRow1("departmentName").ToString)
                        Me.DepartmentDescription = Trim(myRow1("departmentDescription").ToString)

                        Me.updatedDt = Trim(myRow1("updatedDt").ToString)
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

#End Region

#Region "Class Department Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritDepartmentName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentName))
                CritDepartmentCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentCode))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                DepartmentCode = .ReplaceSingleQuotes(DepartmentCode)
                DepartmentName = .ReplaceSingleQuotes(DepartmentName)
                DepartmentDescription = .ReplaceSingleQuotes(DepartmentDescription)
            End With
        End Sub

#End Region

    End Class

End Namespace
