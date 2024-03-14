Imports MySql.Data.MySqlClient

Namespace District

    Public Class District

#Region "Class District Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritRegionName As String
        Private CritProvinceName As String
        Private CritDistrictName As String
        Private CritDistrict As String

        Private districtId As Integer
        Private dCode As String
        Private regionName As String
        Private provinceName As String
        Private districtName As String
        Private distrct As String
        Private brgyCount As Integer
        Private pCode As String
        Private mCode As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class District Public Property Variable Declaration"

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

        Public WriteOnly Property CritDistrict_Name() As String
            Set(ByVal value As String)
                If CritDistrictName = value Then
                    Return
                End If
                CritDistrictName = value
            End Set
        End Property

        Public WriteOnly Property Crit_District() As String
            Set(ByVal value As String)
                If CritDistrict = value Then
                    Return
                End If
                CritDistrict = value
            End Set
        End Property

        Public Property District_Id() As Integer
            Get
                Return districtId
            End Get
            Set(ByVal value As Integer)
                If districtId = value Then
                    Return
                End If
                DistrictId = value
            End Set
        End Property

        Public Property D_Code() As String
            Get
                Return DCode
            End Get
            Set(ByVal value As String)
                If dCode = value Then
                    Return
                End If
                dCode = value
            End Set
        End Property

        Public Property Region_Name() As String
            Get
                Return regionName
            End Get
            Set(ByVal value As String)
                If regionName = value Then
                    Return
                End If
                regionName = value
            End Set
        End Property

        Public Property Province_Name() As String
            Get
                Return provinceName
            End Get
            Set(ByVal value As String)
                If provinceName = value Then
                    Return
                End If
                provinceName = value
            End Set
        End Property

        Public Property District_Name() As String
            Get
                Return DistrictName
            End Get
            Set(ByVal value As String)
                If DistrictName = value Then
                    Return
                End If
                DistrictName = value
            End Set
        End Property

        Public Property Distr_ct() As String
            Get
                Return Distrct
            End Get
            Set(ByVal value As String)
                If Distrct = value Then
                    Return
                End If
                Distrct = value
            End Set
        End Property

        Public Property Brgy_Count() As Integer
            Get
                Return BrgyCount
            End Get
            Set(ByVal value As Integer)
                If BrgyCount = value Then
                    Return
                End If
                BrgyCount = value
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

#Region "Class District Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSpatialDistrictSave(" & districtId & ",'" & dCode & "','" & regionName & "','" & provinceName & "','" & districtName & "','" & distrct & "'," & brgyCount & ",'" & pCode & "','" & mCode & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        districtId = Me.dtSaveRow("districtId")
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
                strSql = "CALL spSpatialDistrictDelete(" & districtId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialDistrictFind(" & districtId & ",'" & CritRegionName & "','" & CritProvinceName & "','" & CritDistrictName & "','" & CritDistrict & "'," & initFlag & ");"

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

                    strSql = "CALL spSpatialDistrictFind(" & initFlag & ",'','','','',2);"

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
                        Me.districtId = Trim(myRow1("districtId").ToString)
                        Me.dCode = Trim(myRow1("dCode").ToString)
                        Me.regionName = Trim(myRow1("regionName").ToString)
                        Me.provinceName = Trim(myRow1("provinceName").ToString)
                        Me.districtName = Trim(myRow1("districtName").ToString)
                        Me.distrct = Trim(myRow1("district").ToString)
                        Me.brgyCount = Trim(myRow1("barangayCnt").ToString)
                        Me.pCode = Trim(myRow1("pCode").ToString)
                        Me.mCode = Trim(myRow1("mCode").ToString)

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

        Public Function GetMunicipalityList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialMunicipalityGet('" & pCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

#End Region

#Region "Class District Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritRegionName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRegionName))
                CritProvinceName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritProvinceName))
                CritDistrictName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDistrictName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                dCode = .ReplaceSingleQuotes(dCode)
                regionName = .ReplaceSingleQuotes(regionName)
                provinceName = .ReplaceSingleQuotes(provinceName)
                districtName = .ReplaceSingleQuotes(districtName)
                distrct = .ReplaceSingleQuotes(distrct)
                pCode = .ReplaceSingleQuotes(pCode)
                mCode = .ReplaceSingleQuotes(mCode)
            End With
        End Sub

#End Region

    End Class

End Namespace
