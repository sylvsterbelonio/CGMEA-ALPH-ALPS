Imports MySql.Data.MySqlClient

Namespace ZipCode

    Public Class ZipCode

#Region "Class Barangay Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritProvinceName As String
        Private CritMunicipalityName As String
        Private CritZipCode As String
        Private CritZipCodeArea As String

        Private zipCodeId As Integer
        Private zipCode As String
        Private zipCodeArea As String
        Private mCode As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Barangay Public Property Variable Declaration"

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

        Public WriteOnly Property CritZip_Code() As String
            Set(ByVal value As String)
                If CritZipCode = value Then
                    Return
                End If
                CritZipCode = value
            End Set
        End Property

        Public WriteOnly Property CritZipCode_Area() As String
            Set(ByVal value As String)
                If CritZipCodeArea = value Then
                    Return
                End If
                CritZipCodeArea = value
            End Set
        End Property

        Public Property zipCode_Id() As Integer
            Get
                Return zipCodeId
            End Get
            Set(ByVal value As Integer)
                If zipCodeId = value Then
                    Return
                End If
                zipCodeId = value
            End Set
        End Property

        Public Property zip_Code() As String
            Get
                Return zipCode
            End Get
            Set(ByVal value As String)
                If zipCode = value Then
                    Return
                End If
                zipCode = value
            End Set
        End Property

        Public Property zipCode_Area() As String
            Get
                Return zipCodeArea
            End Get
            Set(ByVal value As String)
                If zipCodeArea = value Then
                    Return
                End If
                zipCodeArea = value
            End Set
        End Property

        Public Property m_Code() As String
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

#Region "Class Barangay Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSpatialZipCodeSave(" & zipCodeId & ",'" & zipCode & "','" & zipCodeArea & "','" & mCode & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        zipCodeId = Me.dtSaveRow("zipCodeId")
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
                strSql = "CALL spSpatialZipCodeDelete(" & zipCodeId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialZipCodeFind(" & zipCodeId & ",'" & CritProvinceName & "','" & CritMunicipalityName & "','" & CritZipCode & "','" & CritZipCodeArea & "'," & initFlag & ");"

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

                    strSql = "CALL spSpatialZipCodeFind(" & initFlag & ",'','','','',2);"

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
                        Me.zipCodeId = Trim(myRow1("zipCodeId").ToString)
                        Me.zipCode = Trim(myRow1("zipCode").ToString)
                        Me.zipCodeArea = Trim(myRow1("zipCodeArea").ToString)
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
                sqlComboStmt = "CALL spSpatialProvinceGet('" & Microsoft.VisualBasic.Left(mCode, 2) & "');"
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
                sqlComboStmt = "CALL spSpatialMunicipalityGet('" & Microsoft.VisualBasic.Left(mCode, 4) & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

#End Region

#Region "Class Barangay Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritProvinceName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritProvinceName))
                CritMunicipalityName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMunicipalityName))
                CritZipCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritZipCode))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                zipCode = .ReplaceSingleQuotes(zipCode)
                zipCodeArea = .ReplaceSingleQuotes(zipCodeArea)
                mCode = .ReplaceSingleQuotes(mCode)
            End With
        End Sub

#End Region

    End Class

End Namespace
