Imports MySql.Data.MySqlClient

Namespace Region

    Public Class Region

#Region "Class Region Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritRegionCode As String
        Private CritRegionName As String

        Private regionId As Integer
        Private rCode As String
        Private regionName As String
        Private provinceCnt As Integer
        Private cityCnt As Integer
        Private municipalityCnt As Integer
        Private barangayCnt As Integer

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Region Public Property Variable Declaration"

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

        Public WriteOnly Property CritRegion_Code() As String
            Set(ByVal Value As String)
                If CritRegionCode = Value Then
                    Return
                End If
                CritRegionCode = Value
            End Set
        End Property

        Public WriteOnly Property CritRegion_Name() As String
            Set(ByVal Value As String)
                If CritRegionName = Value Then
                    Return
                End If
                CritRegionName = Value
            End Set
        End Property

        Public Property Region_Id() As Integer
            Get
                Return RegionId
            End Get
            Set(ByVal value As Integer)
                If regionId = value Then
                    Return
                End If
                regionId = value
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

        Public Property Region_Name() As String
            Get
                Return RegionName
            End Get
            Set(ByVal value As String)
                If regionName = value Then
                    Return
                End If
                regionName = value
            End Set
        End Property

        Public Property Province_Cnt() As Integer
            Get
                Return ProvinceCnt
            End Get
            Set(ByVal value As Integer)
                If provinceCnt = value Then
                    Return
                End If
                provinceCnt = value
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

#Region "Class Region Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSpatialRegionSave(" & regionId & ",'" & rCode & "','" & regionName & "'," & provinceCnt & "," & cityCnt & "," & municipalityCnt & "," & barangayCnt & "," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        regionId = Me.dtSaveRow("regionId")
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
                strSql = "CALL spSpatialRegionDelete(" & regionId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialRegionFind(" & regionId _
                    & ",'" & CritRegionCode & "','" & CritRegionName & "'," & initFlag & ");"

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

                    strSql = "CALL spSpatialRegionFind(" & initFlag & ",'','',2);"

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
                        Me.regionId = Trim(myRow1("regionId").ToString)
                        Me.rCode = Trim(myRow1("rCode").ToString)
                        Me.regionName = Trim(myRow1("regionName").ToString)
                        Me.provinceCnt = Trim(myRow1("provinceCnt").ToString)
                        Me.cityCnt = Trim(myRow1("cityCnt").ToString)
                        Me.municipalityCnt = Trim(myRow1("municipalityCnt").ToString)
                        Me.barangayCnt = Trim(myRow1("barangayCnt").ToString)

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

#Region "Class Region Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritRegionName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRegionName))
                CritRegionCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRegionCode))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                rCode = .ReplaceSingleQuotes(rCode)
                regionName = .ReplaceSingleQuotes(regionName)
            End With
        End Sub

#End Region

    End Class

End Namespace
