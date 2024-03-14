Imports MySql.Data.MySqlClient

Namespace Province

    Public Class Province

#Region "Class Province Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritRegionName As String
        Private CritProvinceCode As String
        Private CritProvinceName As String
        Private CritProvinceFl As Integer

        Private provinceId As Integer
        Private pCode As String
        Private provinceName As String
        Private cityCnt As Integer
        Private municipalityCnt As Integer
        Private barangayCnt As Integer
        Private incomeClass As String
        Private provinceFl As Integer
        Private rCode As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Province Public Property Variable Declaration"

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

        Public WriteOnly Property CritProvince_Code() As String
            Set(ByVal value As String)
                If CritProvinceCode = value Then
                    Return
                End If
                CritProvinceCode = value
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

        Public WriteOnly Property CritProvince_Fl() As Integer
            Set(ByVal value As Integer)
                If CritProvinceFl = value Then
                    Return
                End If
                CritProvinceFl = value
            End Set
        End Property

        Public Property Province_Id() As Integer
            Get
                Return ProvinceId
            End Get
            Set(ByVal value As Integer)
                If provinceId = value Then
                    Return
                End If
                provinceId = value
            End Set
        End Property

        Public Property P_Code() As String
            Get
                Return PCode
            End Get
            Set(ByVal value As String)
                If pCode = value Then
                    Return
                End If
                pCode = value
            End Set
        End Property

        Public Property Province_Name() As String
            Get
                Return ProvinceName
            End Get
            Set(ByVal value As String)
                If provinceName = value Then
                    Return
                End If
                provinceName = value
            End Set
        End Property

        Public Property City_Cnt() As Integer
            Get
                Return CityCnt
            End Get
            Set(ByVal value As Integer)
                If cityCnt = value Then
                    Return
                End If
                cityCnt = value
            End Set
        End Property

        Public Property Municipality_Cnt() As Integer
            Get
                Return MunicipalityCnt
            End Get
            Set(ByVal value As Integer)
                If municipalityCnt = value Then
                    Return
                End If
                municipalityCnt = value
            End Set
        End Property

        Public Property Barangay_Cnt() As Integer
            Get
                Return BarangayCnt
            End Get
            Set(ByVal value As Integer)
                If barangayCnt = value Then
                    Return
                End If
                barangayCnt = value
            End Set
        End Property

        Public Property Income_Class() As String
            Get
                Return IncomeClass
            End Get
            Set(ByVal value As String)
                If incomeClass = value Then
                    Return
                End If
                incomeClass = value
            End Set
        End Property

        Public Property Province_Fl() As Integer
            Get
                Return ProvinceFl
            End Get
            Set(ByVal value As Integer)
                If provinceFl = value Then
                    Return
                End If
                provinceFl = value
            End Set
        End Property

        Public Property R_Code() As String
            Get
                Return RCode
            End Get
            Set(ByVal value As String)
                If rCode = value Then
                    Return
                End If
                rCode = value
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

#Region "Class Province Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSpatialProvinceSave(" & provinceId & ",'" & pCode & "','" & provinceName & "'," & cityCnt & "," & municipalityCnt & "," & barangayCnt & ",'" & incomeClass & "'," & provinceFl & ",'" & rCode & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        provinceId = Me.dtSaveRow("provinceId")
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
                strSql = "CALL spSpatialProvinceDelete(" & provinceId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialProvinceFind(" & provinceId & ",'" & CritRegionName & "','" & CritProvinceCode & "','" & CritProvinceName & "'," & CritProvinceFl & "," & initFlag & ");"

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

                    strSql = "CALL spSpatialProvinceFind(" & initFlag & ",'','','',0,2);"

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
                        Me.provinceId = Trim(myRow1("provinceId").ToString)
                        Me.pCode = Trim(myRow1("pCode").ToString)
                        Me.provinceName = Trim(myRow1("provinceName").ToString)
                        Me.cityCnt = Trim(myRow1("cityCnt").ToString)
                        Me.municipalityCnt = Trim(myRow1("municipalityCnt").ToString)
                        Me.barangayCnt = Trim(myRow1("barangayCnt").ToString)
                        Me.incomeClass = Trim(myRow1("incomeClass").ToString)
                        Me.provinceFl = Trim(myRow1("provinceFl").ToString)
                        Me.rCode = Trim(myRow1("rCode").ToString)

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

#End Region

#Region "Class Province Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritRegionName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRegionName))
                CritProvinceCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritProvinceCode))
                CritProvinceName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritProvinceName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                rCode = .ReplaceSingleQuotes(rCode)
                pCode = .ReplaceSingleQuotes(pCode)
                provinceName = .ReplaceSingleQuotes(provinceName)
                incomeClass = .ReplaceSingleQuotes(incomeClass)
            End With
        End Sub

#End Region

    End Class

End Namespace
