Imports MySql.Data.MySqlClient

Namespace Municipality

    Public Class Municipality

#Region "Class Municipality Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritRegionName As String
        Private CritProvinceName As String
        Private CritMunicipalityName As String
        Private CritCityFl As Integer

        Private municipalityId As Integer
        Private mCode As String
        Private municipalityName As String
        Private incomeClass As String
        Private cityFl As Integer
        Private pCode As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Municipality Public Property Variable Declaration"

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

        Public WriteOnly Property CritRegion_Name() As String
            Set(ByVal value As String)
                If CritRegionName = value Then
                    Return
                End If
                CritRegionName = value
            End Set
        End Property

        Public WriteOnly Property CritProvince_Name() As String
            Set(ByVal value As String)
                If CritProvinceName = value Then
                    Return
                End If
                CritProvinceName = value
            End Set
        End Property

        Public WriteOnly Property CritMunicipality_Name() As String
            Set(ByVal value As String)
                If CritMunicipalityName = value Then
                    Return
                End If
                CritMunicipalityName = value
            End Set
        End Property

        Public WriteOnly Property CritCity_Fl() As Integer
            Set(ByVal value As Integer)
                If CritCityFl = value Then
                    Return
                End If
                CritCityFl = value
            End Set
        End Property

        Public Property Municipality_Id() As Integer
            Get
                Return municipalityId
            End Get
            Set(ByVal value As Integer)
                If municipalityId = value Then
                    Return
                End If
                municipalityId = value
            End Set
        End Property

        Public Property M_Code() As String
            Get
                Return mCode
            End Get
            Set(ByVal value As String)
                If mCode = value Then
                    Return
                End If
                mCode = value
            End Set
        End Property

        Public Property Municipality_Name() As String
            Get
                Return municipalityName
            End Get
            Set(ByVal value As String)
                If municipalityName = value Then
                    Return
                End If
                municipalityName = value
            End Set
        End Property

        Public Property Income_Class() As String
            Get
                Return incomeClass
            End Get
            Set(ByVal value As String)
                If incomeClass = value Then
                    Return
                End If
                incomeClass = value
            End Set
        End Property

        Public Property City_Fl() As Integer
            Get
                Return cityFl
            End Get
            Set(ByVal value As Integer)
                If cityFl = value Then
                    Return
                End If
                cityFl = value
            End Set
        End Property

        Public Property P_Code() As String
            Get
                Return pCode
            End Get
            Set(ByVal value As String)
                If pCode = value Then
                    Return
                End If
                pCode = value
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

#Region "Class Municipality Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSpatialMunicipalitySave(" & municipalityId & ",'" & mCode & "','" & municipalityName & "','" & incomeClass & "'," & cityFl & ",'" & pCode & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        municipalityId = Me.dtSaveRow("municipalityId")
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
                strSql = "CALL spSpatialMunicipalityDelete(" & municipalityId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialMunicipalityFind(" & municipalityId & ",'" & CritRegionName & "','" & CritProvinceName & "','" & CritMunicipalityName & "'," & CritCityFl & "," & initFlag & ");"

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

                    strSql = "CALL spSpatialMunicipalityFind(" & initFlag & ",'','','',0,2);"

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
                        Me.municipalityId = Trim(myRow1("municipalityId").ToString)
                        Me.mCode = Trim(myRow1("mCode").ToString)
                        Me.municipalityName = Trim(myRow1("municipalityName").ToString)
                        Me.incomeClass = Trim(myRow1("incomeClass").ToString)
                        Me.cityFl = Trim(myRow1("cityFl").ToString)
                        Me.pCode = Trim(myRow1("pCode").ToString)

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

        Public Function GetRegionList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialRegionGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetProvinceList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialProvinceGet('" & Microsoft.VisualBasic.Left(pCode, 2) & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

#End Region

#Region "Class Municipality Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritRegionName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRegionName))
                CritProvinceName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritProvinceName))
                CritMunicipalityName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMunicipalityName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                mCode = .ReplaceSingleQuotes(mCode)
                municipalityName = .ReplaceSingleQuotes(municipalityName)
                incomeClass = .ReplaceSingleQuotes(incomeClass)
                pCode = .ReplaceSingleQuotes(pCode)
            End With
        End Sub

#End Region

    End Class

End Namespace
