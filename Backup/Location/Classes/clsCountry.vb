Imports System.IO
Imports MySql.Data.MySqlClient

Namespace Country

    Public Class Country

#Region "Class Country Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritCountryFIPS As String
        Private CritCountryGMI As String
        Private CritCountryName As String
        Private CritCountrySovereign As String

        Private countryId As Integer
        Private countryFIPS As String
        Private countryGMI As String
        Private countryName As String
        Private countryFlag As String
        Private countrySovereign As String
        Private countryPopulation As Integer
        Private countryAreaSqkm As Double
        Private countryAreaSqmi As Double
        Private countryCurrencyType As String
        Private countryCurrencyCode As String

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

#Region "Class Country Public Property Variable Declaration"

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

        Public WriteOnly Property CritCountry_FIPS() As String
            Set(ByVal Value As String)
                If CritCountryFIPS = Value Then
                    Return
                End If
                CritCountryFIPS = Value
            End Set
        End Property

        Public WriteOnly Property CritCountry_GMI() As String
            Set(ByVal Value As String)
                If CritCountryGMI = Value Then
                    Return
                End If
                CritCountryGMI = Value
            End Set
        End Property

        Public WriteOnly Property CritCountry_Name() As String
            Set(ByVal Value As String)
                If CritCountryName = Value Then
                    Return
                End If
                CritCountryName = Value
            End Set
        End Property

        Public WriteOnly Property CritCountry_Sovereign() As String
            Set(ByVal Value As String)
                If CritCountrySovereign = Value Then
                    Return
                End If
                CritCountrySovereign = Value
            End Set
        End Property

        Public Property Country_Id() As Integer
            Get
                Return CountryId
            End Get
            Set(ByVal value As Integer)
                If countryId = value Then
                    Return
                End If
                countryId = value
            End Set
        End Property

        Public Property Country_FIPS() As String
            Get
                Return CountryFIPS
            End Get
            Set(ByVal value As String)
                If countryFIPS = value Then
                    Return
                End If
                countryFIPS = value
            End Set
        End Property

        Public Property Country_GMI() As String
            Get
                Return CountryGMI
            End Get
            Set(ByVal value As String)
                If countryGMI = value Then
                    Return
                End If
                countryGMI = value
            End Set
        End Property

        Public Property Country_Name() As String
            Get
                Return CountryName
            End Get
            Set(ByVal value As String)
                If countryName = value Then
                    Return
                End If
                countryName = value
            End Set
        End Property

        Public Property Country_Flag() As String
            Get
                Return CountryFlag
            End Get
            Set(ByVal value As String)
                If countryFlag = value Then
                    Return
                End If
                countryFlag = value
            End Set
        End Property

        Public Property Country_Sovereign() As String
            Get
                Return CountrySovereign
            End Get
            Set(ByVal value As String)
                If countrySovereign = value Then
                    Return
                End If
                countrySovereign = value
            End Set
        End Property

        Public Property Country_Population() As Integer
            Get
                Return CountryPopulation
            End Get
            Set(ByVal value As Integer)
                If countryPopulation = value Then
                    Return
                End If
                countryPopulation = value
            End Set
        End Property

        Public Property CountryArea_Sqkm() As Double
            Get
                Return CountryAreaSqkm
            End Get
            Set(ByVal value As Double)
                If countryAreaSqkm = value Then
                    Return
                End If
                countryAreaSqkm = value
            End Set
        End Property

        Public Property CountryArea_Sqmi() As Double
            Get
                Return CountryAreaSqmi
            End Get
            Set(ByVal value As Double)
                If countryAreaSqmi = value Then
                    Return
                End If
                countryAreaSqmi = value
            End Set
        End Property

        Public Property CountryCurrency_Type() As String
            Get
                Return CountryCurrencyType
            End Get
            Set(ByVal value As String)
                If countryCurrencyType = value Then
                    Return
                End If
                countryCurrencyType = value
            End Set
        End Property

        Public Property CountryCurrency_Code() As String
            Get
                Return CountryCurrencyCode
            End Get
            Set(ByVal value As String)
                If countryCurrencyCode = value Then
                    Return
                End If
                countryCurrencyCode = value
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

#Region "Class Country Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Dim pcountryId = New MySqlParameter("?pcountryId", MySqlDbType.Int64)
                Dim pcountryFIPS = New MySqlParameter("?pcountryFIPS", MySqlDbType.VarChar)
                Dim pcountryGMI = New MySqlParameter("?pcountryGMI", MySqlDbType.VarChar)
                Dim pcountryName = New MySqlParameter("?pcountryName", MySqlDbType.VarChar)
                Dim pcountryFlag = New MySqlParameter("?pcountryFlag", MySqlDbType.LongBlob)
                Dim pcountrySovereign = New MySqlParameter("?pcountrySovereign", MySqlDbType.VarChar)
                Dim pcountryPopulation = New MySqlParameter("?pcountryPopulation", MySqlDbType.Int64)
                Dim pcountryAreaSqkm = New MySqlParameter("?pcountryAreaSqkm", MySqlDbType.Decimal)
                Dim pcountryAreaSqmi = New MySqlParameter("?pcountryAreaSqmi", MySqlDbType.Decimal)
                Dim pcountryCurrencyType = New MySqlParameter("?pcountryCurrencyType", MySqlDbType.VarChar)
                Dim pcountryCurrencyCode = New MySqlParameter("?pcountryCurrencyCode", MySqlDbType.VarChar)
                Dim pupdatedBy = New MySqlParameter("?pupdatedBy", MySqlDbType.Int64)
                Dim pupdatedDt = New MySqlParameter("?pupdatedDt", MySqlDbType.VarChar)

                pcountryId.Value = countryId
                pcountryFIPS.Value = countryFIPS
                pcountryGMI.Value = countryGMI
                pcountryName.Value = countryName
                If File.Exists(countryFlag) Then
                    fs = New FileStream(countryFlag, FileMode.Open, FileAccess.Read)
                    FileSize = fs.Length

                    rawData = New Byte(FileSize) {}
                    fs.Read(rawData, 0, FileSize)
                    fs.Close()

                    pcountryFlag.value = rawData
                Else
                    pcountryFlag.value = DBNull.Value
                End If

                pcountrySovereign.Value = countrySovereign
                pcountryPopulation.Value = countryPopulation
                pcountryAreaSqkm.Value = countryAreaSqkm
                pcountryAreaSqmi.Value = countryAreaSqmi
                pcountryCurrencyType.Value = countryCurrencyType
                pcountryCurrencyCode.Value = countryCurrencyCode
                pupdatedBy.value = updatedBy
                pupdatedDt.value = updatedDt

                arr = New ArrayList
                arr.Add(pcountryId)
                arr.Add(pcountryFIPS)
                arr.Add(pcountryGMI)
                arr.Add(pcountryName)
                arr.Add(pcountryFlag)
                arr.Add(pcountrySovereign)
                arr.Add(pcountryPopulation)
                arr.Add(pcountryAreaSqkm)
                arr.Add(pcountryAreaSqmi)
                arr.Add(pcountryCurrencyType)
                arr.Add(pcountryCurrencyCode)
                arr.Add(pupdatedBy)
                arr.Add(pupdatedDt)

                Save_Record = True

                strSql = "spSpatialCountrySave"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE, arr)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        countryId = Me.dtSaveRow("countryId")
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
                strSql = "CALL spSpatialCountryDelete(" & countryId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialCountryFind(" & countryId _
                    & ",'" & CritCountryFIPS & "','" & CritCountryGMI & "','" _
                    & CritCountryName & "','" & CritCountrySovereign & "'," & initFlag & ");"

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

                    strSql = "CALL spSpatialCountryFind(" & initFlag & ",'','','','',2);"

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
                        Me.countryId = Trim(myRow1("countryId").ToString)
                        Me.countryFIPS = Trim(myRow1("countryFIPS").ToString)
                        Me.countryGMI = Trim(myRow1("countryGMI").ToString)
                        Me.countryName = Trim(myRow1("countryName").ToString)
                        If Not IsDBNull(myRow1("countryFlag")) Then
                            Me.countryFlag = ImageDir & "\" & LCase(countryName) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("countryFlag")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(countryFlag, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                            End Try
                        Else
                            Me.countryFlag = ""
                        End If
                        Me.countrySovereign = Trim(myRow1("countrySovereign").ToString)
                        Me.countryPopulation = Trim(myRow1("countryPopulation").ToString)
                        Me.countryAreaSqkm = Trim(myRow1("countryAreaSqkm").ToString)
                        Me.countryAreaSqmi = Trim(myRow1("countryAreaSqmi").ToString)
                        Me.countryCurrencyType = Trim(myRow1("countryCurrencyType").ToString)
                        Me.countryCurrencyCode = Trim(myRow1("countryCurrencyCode").ToString)

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

#Region "Class Country Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritCountryGMI = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCountryGMI))
                CritCountryName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCountryName))
                CritCountrySovereign = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCountrySovereign))
                CritCountryFIPS = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCountryFIPS))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                countryFIPS = .ReplaceSingleQuotes(countryFIPS)
                countryGMI = .ReplaceSingleQuotes(countryGMI)
                countryName = .ReplaceSingleQuotes(countryName)
                countryFlag = .ReplaceSingleQuotes(countryFlag)
                countrySovereign = .ReplaceSingleQuotes(countrySovereign)
                countryCurrencyType = .ReplaceSingleQuotes(countryCurrencyType)
                countryCurrencyCode = .ReplaceSingleQuotes(countryCurrencyCode)
            End With
        End Sub

#End Region

    End Class

End Namespace
