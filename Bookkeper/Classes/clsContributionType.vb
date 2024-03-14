Imports System.IO
Imports MySql.Data.MySqlClient

Namespace ContributionType

    Public Class ContributionType

#Region "Class Contribution Type Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritConTypeName As String

        Private intChildCount As Integer
        Private intParentCount As Integer
        Private dtCheck1 As DataSet
        Private dtCheck2 As DataSet
        Private dtRowCheck1 As DataRow
        Private dtRowCheck2 As DataRow
        Private dtRecord As DataTable

        Private conTypeId As Integer
        Private conYear As Integer
        Private conTypeName As String
        Private conTypeDescription As String
        Private minAmount As Double
        Private activeFl As Integer
        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private FileSize As UInt32
        Private rawData() As Byte
        Private fs As FileStream

#End Region

#Region "Class Contribution Type Public Property Variable Declaration"

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

        Public WriteOnly Property CritConType_Name() As String
            Set(ByVal Value As String)
                If CritConTypeName = Value Then
                    Return
                End If
                CritConTypeName = Value
            End Set
        End Property

        Public ReadOnly Property intChild_Count() As Integer
            Get
                Return intChildCount
            End Get
        End Property

        Public ReadOnly Property intParent_Count() As Integer
            Get
                Return intParentCount
            End Get
        End Property

        Public Property ConType_Id() As Integer
            Get
                Return conTypeId
            End Get
            Set(ByVal value As Integer)
                If conTypeId = value Then
                    Return
                End If
                conTypeId = value
            End Set
        End Property

        Public Property Con_Year() As Integer
            Get
                Return conYear
            End Get
            Set(ByVal value As Integer)
                If conYear = value Then
                    Return
                End If
                conYear = value
            End Set
        End Property

        Public Property ConType_Name() As String
            Get
                Return conTypeName
            End Get
            Set(ByVal Value As String)
                If conTypeName = Value Then
                    Return
                End If
                conTypeName = Value
            End Set
        End Property

        Public Property ConType_Description() As String
            Get
                Return conTypeDescription
            End Get
            Set(ByVal Value As String)
                If conTypeDescription = Value Then
                    Return
                End If
                conTypeDescription = Value
            End Set
        End Property

        Public Property Min_Amount() As Double
            Get
                Return minAmount
            End Get
            Set(ByVal value As Double)
                If minAmount = value Then
                    Return
                End If
                minAmount = value
            End Set
        End Property

        Public Property Active_Fl() As Integer
            Get
                Return activeFl
            End Get
            Set(ByVal value As Integer)
                If activeFl = value Then
                    Return
                End If
                activeFl = value
            End Set
        End Property

        Public WriteOnly Property Updated_By() As String
            Set(ByVal Value As String)
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

#Region "Class Contribution Type Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Dim pconTypeId = New MySqlParameter("?pconTypeId", MySqlDbType.Int64)
                Dim pconYear = New MySqlParameter("?pconYear", MySqlDbType.Int64)
                Dim pconTypeName = New MySqlParameter("?pconTypeName", MySqlDbType.VarChar)
                Dim pconTypeDescription = New MySqlParameter("?pconTypeDescription", MySqlDbType.VarChar)
                Dim pconMinAmount = New MySqlParameter("?pconMinAmount", MySqlDbType.Double)
                Dim pactiveFl = New MySqlParameter("?pactiveFl", MySqlDbType.Int64)
                Dim pupdatedBy = New MySqlParameter("?pupdatedBy", MySqlDbType.Int64)
                Dim pupdatedDt = New MySqlParameter("?pupdatedDt", MySqlDbType.VarChar)

                pconTypeId.Value = conTypeId
                pconYear.Value = conYear
                pconTypeName.Value = conTypeName
                pconTypeDescription.Value = conTypeDescription
                pconMinAmount.Value = minAmount
                pactiveFl.Value = activeFl
                pupdatedBy.Value = updatedBy
                pupdatedDt.Value = updatedDt

                arr = New ArrayList
                arr.Add(pconTypeId)
                arr.Add(pconYear)
                arr.Add(pconTypeName)
                arr.Add(pconTypeDescription)
                arr.Add(pconMinAmount)
                arr.Add(pactiveFl)
                arr.Add(pupdatedBy)
                arr.Add(pupdatedDt)

                Save_Record = True

                strSql = "spContributionTypeSave"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE, arr)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        conTypeId = Me.dtSaveRow("conTypeId")
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
                strSql = "CALL spContributionTypeDelete(" & conTypeId & "," & updatedBy & ");"
                dtRec = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                Dim myRow As DataRow

                For Each myRow In dtRec.Rows
                    ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    RaiseEvent MsgArrival(MSGBOX_INACTIVE_SUCCESSFUL, True)
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

                    strSql = "CALL spContributionTypeFind(" & conTypeId _
                    & ",'" & CritConTypeName & "'," & initFlag & ");"

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

                    strSql = "CALL spContributionTypeFind(" & initFlag & ",'',2);"

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
                        Me.conTypeId = Trim(myRow1("conTypeId").ToString)
                        Me.conTypeName = Trim(myRow1("conTypeName").ToString)
                        Me.conTypeDescription = Trim(myRow1("conTypeDescription").ToString)
                        Me.minAmount = Trim(myRow1("minAmount").ToString)
                        Me.conYear = Trim(myRow1("conYear").ToString)
                        Me.activeFl = Trim(myRow1("activeFl").ToString)
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

        Public Function GetDefaultParameter(ByVal paramName As String) As String
            Dim dtParam As DataTable
            Dim sqlStmt As String
            Dim paramVal As String = ""

            Try
                sqlStmt = "CALL spDefaultParameterGet('" & paramName & "');"
                dtParam = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                If dtParam.Rows.Count <> 0 Then
                    paramVal = dtParam.Rows(0)("paramVal")
                Else
                    paramVal = ""
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
            Return paramVal
        End Function

        Public Function GetContributionTypeMinYear() As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spContributionTypeMinYearRecordGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetContributionTypeMinYear = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetContributionTypeMaxYear() As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spContributionTypeMaxYearRecordGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetContributionTypeMaxYear = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

#End Region

#Region "Class Contribution Type Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritConTypeName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritConTypeName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                conTypeName = .ReplaceSingleQuotes(conTypeName)
            End With
        End Sub

#End Region

    End Class

End Namespace
