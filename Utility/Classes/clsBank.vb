Imports System.IO
Imports MySql.Data.MySqlClient

Namespace Bank

    Public Class Bank

#Region "Class Bank Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritBankName As String
        Private CritBankCode As String

        Private BankId As Integer
        Private BankName As String
        Private BankCode As String
        Private BankDescription As String
        Private BankRemarks As String
        Private BankLogo As String
        Private BankAddress As String
        Private rCode As String
        Private pCode As String
        Private mCode As String
        Private rurCode As String
        Private zipCodeId As Integer
        Private contactFirstName As String
        Private contactLastName As String
        Private contactTelNo As String
        Private contactFaxNo As String
        Private contactEmailAddress As String
        Private contactWebsite As String

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

#Region "Class Bank Public Property Variable Declaration"

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

        Public WriteOnly Property CritBank_Name() As String
            Set(ByVal Value As String)
                If CritBankName = Value Then
                    Return
                End If
                CritBankName = Value
            End Set
        End Property

        Public WriteOnly Property CritBank_Code() As String
            Set(ByVal Value As String)
                If CritBankCode = Value Then
                    Return
                End If
                CritBankCode = Value
            End Set
        End Property

        Public Property Bank_Id() As Integer
            Get
                Return BankId
            End Get
            Set(ByVal value As Integer)
                If BankId = value Then
                    Return
                End If
                BankId = value
            End Set
        End Property

        Public Property Bank_Name() As String
            Get
                Return BankName
            End Get
            Set(ByVal value As String)
                If BankName = value Then
                    Return
                End If
                BankName = value
            End Set
        End Property

        Public Property Bank_Code() As String
            Get
                Return BankCode
            End Get
            Set(ByVal value As String)
                If BankCode = value Then
                    Return
                End If
                BankCode = value
            End Set
        End Property

        Public Property Bank_Description() As String
            Get
                Return BankDescription
            End Get
            Set(ByVal value As String)
                If BankDescription = value Then
                    Return
                End If
                BankDescription = value
            End Set
        End Property

        Public Property Bank_Remarks() As String
            Get
                Return BankRemarks
            End Get
            Set(ByVal value As String)
                If BankRemarks = value Then
                    Return
                End If
                BankRemarks = value
            End Set
        End Property

        Public Property Bank_Logo() As String
            Get
                Return BankLogo
            End Get
            Set(ByVal value As String)
                If BankLogo = value Then
                    Return
                End If
                BankLogo = value
            End Set
        End Property

        Public Property Bank_Address() As String
            Get
                Return BankAddress
            End Get
            Set(ByVal value As String)
                If BankAddress = value Then
                    Return
                End If
                BankAddress = value
            End Set
        End Property

        Public Property R_Code() As String
            Get
                Return rCode
            End Get
            Set(ByVal value As String)
                If rCode = value Then
                    Return
                End If
                rCode = value
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

        Public Property Rur_Code() As String
            Get
                Return rurCode
            End Get
            Set(ByVal value As String)
                If rurCode = value Then
                    Return
                End If
                rurCode = value
            End Set
        End Property

        Public Property ZipCode_Id() As Integer
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

        Public Property ContactFirst_Name() As String
            Get
                Return contactFirstName
            End Get
            Set(ByVal value As String)
                If contactFirstName = value Then
                    Return
                End If
                contactFirstName = value
            End Set
        End Property

        Public Property ContactLast_Name() As String
            Get
                Return contactLastName
            End Get
            Set(ByVal value As String)
                If contactLastName = value Then
                    Return
                End If
                contactLastName = value
            End Set
        End Property

        Public Property ContactTel_No() As String
            Get
                Return contactTelNo
            End Get
            Set(ByVal value As String)
                If contactTelNo = value Then
                    Return
                End If
                contactTelNo = value
            End Set
        End Property

        Public Property ContactFax_No() As String
            Get
                Return contactFaxNo
            End Get
            Set(ByVal value As String)
                If contactFaxNo = value Then
                    Return
                End If
                contactFaxNo = value
            End Set
        End Property

        Public Property ContactEmail_Address() As String
            Get
                Return contactEmailAddress
            End Get
            Set(ByVal value As String)
                If contactEmailAddress = value Then
                    Return
                End If
                contactEmailAddress = value
            End Set
        End Property

        Public Property Contact_Website() As String
            Get
                Return contactWebsite
            End Get
            Set(ByVal value As String)
                If contactWebsite = value Then
                    Return
                End If
                contactWebsite = value
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

#Region "Class Bank Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Dim pBankId = New MySqlParameter("?pBankId", MySqlDbType.Int64)
                Dim pBankName = New MySqlParameter("?pBankName", MySqlDbType.VarChar)
                Dim pBankCode = New MySqlParameter("?pBankCode", MySqlDbType.VarChar)
                Dim pBankDescription = New MySqlParameter("?pBankDescription", MySqlDbType.VarChar)
                Dim pBankRemarks = New MySqlParameter("?pBankRemarks", MySqlDbType.VarChar)
                Dim pBankLogo = New MySqlParameter("?pBankLogo", MySqlDbType.LongBlob)
                Dim pBankAddress = New MySqlParameter("?pBankAddress", MySqlDbType.VarChar)
                Dim prCode = New MySqlParameter("?prCode", MySqlDbType.VarChar)
                Dim ppCode = New MySqlParameter("?ppCode", MySqlDbType.VarChar)
                Dim pmCode = New MySqlParameter("?pmCode", MySqlDbType.VarChar)
                Dim prurCode = New MySqlParameter("?prurCode", MySqlDbType.VarChar)
                Dim pzipCodeId = New MySqlParameter("?pzipCodeId", MySqlDbType.Int64)
                Dim pcontactFirstName = New MySqlParameter("?pcontactFirstName", MySqlDbType.VarChar)
                Dim pcontactLastName = New MySqlParameter("?pcontactLastName", MySqlDbType.VarChar)
                Dim pcontactTelNo = New MySqlParameter("?pcontactTelNo", MySqlDbType.VarChar)
                Dim pcontactFaxNo = New MySqlParameter("?pcontactFaxNo", MySqlDbType.VarChar)
                Dim pcontactEmailAddress = New MySqlParameter("?pcontactEmailAddress", MySqlDbType.VarChar)
                Dim pcontactWebsite = New MySqlParameter("?pcontactWebsite", MySqlDbType.VarChar)
                Dim pupdatedBy = New MySqlParameter("?pupdatedBy", MySqlDbType.Int64)
                Dim pupdatedDt = New MySqlParameter("?pupdatedDt", MySqlDbType.VarChar)

                pBankId.Value = BankId
                pBankName.Value = BankName
                pBankCode.Value = BankCode
                pBankDescription.Value = BankDescription
                pBankRemarks.Value = BankRemarks
                If File.Exists(BankLogo) Then
                    fs = New FileStream(BankLogo, FileMode.Open, FileAccess.Read)
                    FileSize = fs.Length

                    rawData = New Byte(FileSize) {}
                    fs.Read(rawData, 0, FileSize)
                    fs.Close()

                    pBankLogo.Value = rawData
                Else
                    pBankLogo.Value = DBNull.Value
                End If

                pBankAddress.Value = BankAddress
                prCode.Value = rCode
                ppCode.Value = pCode
                pmCode.Value = mCode
                prurCode.Value = rurCode
                pzipCodeId.Value = zipCodeId
                pcontactFirstName.Value = contactFirstName
                pcontactLastName.Value = contactLastName
                pcontactTelNo.Value = contactTelNo
                pcontactFaxNo.Value = contactFaxNo
                pcontactEmailAddress.Value = contactEmailAddress
                pcontactWebsite.Value = contactWebsite
                pupdatedBy.Value = updatedBy
                pupdatedDt.Value = updatedDt

                arr = New ArrayList
                arr.Add(pBankId)
                arr.Add(pBankName)
                arr.Add(pBankCode)
                arr.Add(pBankDescription)
                arr.Add(pBankRemarks)
                arr.Add(pBankLogo)
                arr.Add(pBankAddress)
                arr.Add(prCode)
                arr.Add(ppCode)
                arr.Add(pmCode)
                arr.Add(prurCode)
                arr.Add(pzipCodeId)
                arr.Add(pcontactFirstName)
                arr.Add(pcontactLastName)
                arr.Add(pcontactTelNo)
                arr.Add(pcontactFaxNo)
                arr.Add(pcontactEmailAddress)
                arr.Add(pcontactWebsite)
                arr.Add(pupdatedBy)
                arr.Add(pupdatedDt)

                Save_Record = True

                strSql = "spBankSave"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE, arr)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        BankId = Me.dtSaveRow("BankId")
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
                strSql = "CALL spBankDelete(" & BankId & "," & updatedBy & ");"
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

                    strSql = "CALL spBankFind(" & BankId _
                    & ",'" & CritBankName & "','" & CritBankCode & "'," & initFlag & ");"

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

                    strSql = "CALL spBankFind(" & initFlag & ",'','',2);"

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
                        Me.BankId = Trim(myRow1("BankId").ToString)
                        Me.BankName = Trim(myRow1("BankName").ToString)
                        Me.BankCode = Trim(myRow1("BankCode").ToString)
                        Me.BankDescription = Trim(myRow1("BankDescription").ToString)
                        Me.BankRemarks = Trim(myRow1("BankRemarks").ToString)
                        If Not IsDBNull(myRow1("BankLogo")) Then
                            Me.BankLogo = ImageDir & "\" & LCase(BankCode) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("BankLogo")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(BankLogo, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                            End Try
                        Else
                            Me.BankLogo = ""
                        End If
                        Me.BankAddress = Trim(myRow1("BankAddress").ToString)
                        Me.rCode = Trim(myRow1("rCode").ToString)
                        Me.pCode = Trim(myRow1("pCode").ToString)
                        Me.mCode = Trim(myRow1("mCode").ToString)
                        Me.rurCode = Trim(myRow1("rurCode").ToString)
                        Me.zipCodeId = Trim(myRow1("zipCodeId").ToString)
                        Me.contactFirstName = Trim(myRow1("contactFirstName").ToString)
                        Me.contactLastName = Trim(myRow1("contactLastName").ToString)
                        Me.contactTelNo = Trim(myRow1("contactTelNo").ToString)
                        Me.contactFaxNo = Trim(myRow1("contactFaxNo").ToString)
                        Me.contactEmailAddress = Trim(myRow1("contactEmailAddress").ToString)
                        Me.contactWebsite = Trim(myRow1("contactWebsite").ToString)
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
                sqlComboStmt = "CALL spSpatialProvinceGet('" & rCode & "');"
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

        Public Function GetBarangayList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialBarangayGet('" & mCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetZipCodeList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialZipCodeGet('" & mCode & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

#End Region

#Region "Class Bank Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritBankCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritBankCode))
                CritBankName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritBankName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                BankName = .ReplaceSingleQuotes(BankName)
                BankCode = .ReplaceSingleQuotes(BankCode)
                BankDescription = .ReplaceSingleQuotes(BankDescription)
                BankLogo = .ReplaceSingleQuotes(BankLogo)
                BankAddress = .ReplaceSingleQuotes(BankAddress)
                rCode = .ReplaceSingleQuotes(rCode)
                pCode = .ReplaceSingleQuotes(pCode)
                mCode = .ReplaceSingleQuotes(mCode)
                rurCode = .ReplaceSingleQuotes(rurCode)
                contactFirstName = .ReplaceSingleQuotes(contactFirstName)
                contactLastName = .ReplaceSingleQuotes(contactLastName)
                contactTelNo = .ReplaceSingleQuotes(contactTelNo)
                contactFaxNo = .ReplaceSingleQuotes(contactFaxNo)
                contactEmailAddress = .ReplaceSingleQuotes(contactEmailAddress)
                contactWebsite = .ReplaceSingleQuotes(contactWebsite)
            End With
        End Sub

#End Region

    End Class

End Namespace
