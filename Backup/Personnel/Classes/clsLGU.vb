Imports System.IO
Imports MySql.Data.MySqlClient

Namespace LGU

    Public Class LGU

#Region "Class LGU Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritLGUName As String
        Private CritLGUCode As String

        Private LGUId As Integer
        Private LGUName As String
        Private LGUCode As String
        Private LGUDescription As String
        Private LGURemarks As String
        Private LGULogo As String
        Private LGUAddress As String
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

#Region "Class LGU Public Property Variable Declaration"

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

        Public WriteOnly Property CritLGU_Name() As String
            Set(ByVal Value As String)
                If CritLGUName = Value Then
                    Return
                End If
                CritLGUName = Value
            End Set
        End Property

        Public WriteOnly Property CritLGU_Code() As String
            Set(ByVal Value As String)
                If CritLGUCode = Value Then
                    Return
                End If
                CritLGUCode = Value
            End Set
        End Property

        Public Property LGU_Id() As Integer
            Get
                Return LGUId
            End Get
            Set(ByVal value As Integer)
                If LGUId = value Then
                    Return
                End If
                LGUId = value
            End Set
        End Property

        Public Property LGU_Name() As String
            Get
                Return LGUName
            End Get
            Set(ByVal value As String)
                If LGUName = value Then
                    Return
                End If
                LGUName = value
            End Set
        End Property

        Public Property LGU_Code() As String
            Get
                Return LGUCode
            End Get
            Set(ByVal value As String)
                If LGUCode = value Then
                    Return
                End If
                LGUCode = value
            End Set
        End Property

        Public Property LGU_Description() As String
            Get
                Return LGUDescription
            End Get
            Set(ByVal value As String)
                If LGUDescription = value Then
                    Return
                End If
                LGUDescription = value
            End Set
        End Property

        Public Property LGU_Remarks() As String
            Get
                Return LGURemarks
            End Get
            Set(ByVal value As String)
                If LGURemarks = value Then
                    Return
                End If
                LGURemarks = value
            End Set
        End Property

        Public Property LGU_Logo() As String
            Get
                Return LGULogo
            End Get
            Set(ByVal value As String)
                If LGULogo = value Then
                    Return
                End If
                LGULogo = value
            End Set
        End Property

        Public Property LGU_Address() As String
            Get
                Return LGUAddress
            End Get
            Set(ByVal value As String)
                If LGUAddress = value Then
                    Return
                End If
                LGUAddress = value
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

#Region "Class LGU Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Dim pLGUId = New MySqlParameter("?pLGUId", MySqlDbType.Int64)
                Dim pLGUName = New MySqlParameter("?pLGUName", MySqlDbType.VarChar)
                Dim pLGUCode = New MySqlParameter("?pLGUCode", MySqlDbType.VarChar)
                Dim pLGUDescription = New MySqlParameter("?pLGUDescription", MySqlDbType.VarChar)
                Dim pLGURemarks = New MySqlParameter("?pLGURemarks", MySqlDbType.VarChar)
                Dim pLGULogo = New MySqlParameter("?pLGULogo", MySqlDbType.LongBlob)
                Dim pLGUAddress = New MySqlParameter("?pLGUAddress", MySqlDbType.VarChar)
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

                pLGUId.Value = LGUId
                pLGUName.Value = LGUName
                pLGUCode.Value = LGUCode
                pLGUDescription.Value = LGUDescription
                pLGURemarks.Value = LGURemarks
                If File.Exists(LGULogo) Then
                    fs = New FileStream(LGULogo, FileMode.Open, FileAccess.Read)
                    FileSize = fs.Length

                    rawData = New Byte(FileSize) {}
                    fs.Read(rawData, 0, FileSize)
                    fs.Close()

                    pLGULogo.value = rawData
                Else
                    pLGULogo.value = DBNull.Value
                End If

                pLGUAddress.Value = LGUAddress
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
                pupdatedBy.value = updatedBy
                pupdatedDt.value = updatedDt

                arr = New ArrayList
                arr.Add(pLGUId)
                arr.Add(pLGUName)
                arr.Add(pLGUCode)
                arr.Add(pLGUDescription)
                arr.Add(pLGURemarks)
                arr.Add(pLGULogo)
                arr.Add(pLGUAddress)
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

                strSql = "spLGUSave"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE, arr)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        LGUId = Me.dtSaveRow("LGUId")
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
                strSql = "CALL spLGUDelete(" & LGUId & "," & updatedBy & ");"
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

                    strSql = "CALL spLGUFind(" & LGUId _
                    & ",'" & CritLGUName & "','" & CritLGUCode & "'," & initFlag & ");"

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

                    strSql = "CALL spLGUFind(" & initFlag & ",'','',2);"

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
                        Me.LGUId = Trim(myRow1("LGUId").ToString)
                        Me.LGUName = Trim(myRow1("LGUName").ToString)
                        Me.LGUCode = Trim(myRow1("LGUCode").ToString)
                        Me.LGUDescription = Trim(myRow1("LGUDescription").ToString)
                        Me.LGURemarks = Trim(myRow1("LGURemarks").ToString)
                        If Not IsDBNull(myRow1("LGULogo")) Then
                            Me.LGULogo = ImageDir & "\" & LCase(LGUCode) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("LGULogo")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(LGULogo, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                            End Try
                        Else
                            Me.LGULogo = ""
                        End If
                        Me.LGUAddress = Trim(myRow1("LGUAddress").ToString)
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

#Region "Class LGU Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritLGUCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLGUCode))
                CritLGUName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLGUName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                LGUName = .ReplaceSingleQuotes(LGUName)
                LGUCode = .ReplaceSingleQuotes(LGUCode)
                LGUDescription = .ReplaceSingleQuotes(LGUDescription)
                LGULogo = .ReplaceSingleQuotes(LGULogo)
                LGUAddress = .ReplaceSingleQuotes(LGUAddress)
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
