Imports MySql.Data.MySqlClient
Imports System.IO

Namespace Constituents

    Public Class Constituents

#Region "Class Constituent Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritLastName As String
        Private CritFirstName As String
        Private CritConstituentType As String

        Private constituentId As Integer
        Private constituentType As String
        Private lastName As String
        Private firstName As String
        Private middleName As String
        Private suffixName As String
        Private birthDate As String
        Private tempBirthDate As Date
        Private birthPlace As String
        Private constituentGender As String
        Private civilStatus As String
        Private constituentNationality As String
        Private householdNo As String
        Private constituentAddress As String
        Private constituentPermanentAddress As String
        Private constituentBillingAddress As String
        Private countryId As Integer
        Private rCode As String
        Private pCode As String
        Private mCode As String
        Private rurCode As String
        Private zipCodeId As Integer
        Private homeTelNo As String
        Private workTelNo As String
        Private faxNo As String
        Private mobileNo As String
        Private emailAddress As String
        Private spouseId As Integer
        Private spouseName As String
        Private spouseContactNo As String
        Private constituentRemarks As String
        Private activeFl As Integer
        Private constituentPhoto As String
        Private taxIdNo As String
        Private birthFl As Integer
        Private taxCredit As Double

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private dtRecord As DataTable

        Private FileSize As UInt32
        Private rawData() As Byte
        Private fs As FileStream
#End Region

#Region "Class Constituent Public Property Variable Declaration"

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

        Public WriteOnly Property CritLast_Name() As String
            Set(ByVal Value As String)
                If CritLastName = Value Then
                    Return
                End If
                CritLastName = Value
            End Set
        End Property

        Public WriteOnly Property CritFirst_Name() As String
            Set(ByVal Value As String)
                If CritFirstName = Value Then
                    Return
                End If
                CritFirstName = Value
            End Set
        End Property

        Public WriteOnly Property CritConstituent_Type() As String
            Set(ByVal Value As String)
                If CritConstituentType = Value Then
                    Return
                End If
                CritConstituentType = Value
            End Set
        End Property

        Public Property constituent_Id() As Integer
            Get
                Return constituentId
            End Get
            Set(ByVal value As Integer)
                If constituentId = value Then
                    Return
                End If
                constituentId = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _constituentType() As String
            Get
                Return constituentType
            End Get
            Set(ByVal value As String)
                If constituentType = value Then
                    Return
                End If
                constituentType = value
            End Set
        End Property

        Public Property last_Name() As String
            Get
                Return lastName
            End Get
            Set(ByVal value As String)
                If lastName = value Then
                    Return
                End If
                lastName = value
            End Set
        End Property

        Public Property first_Name() As String
            Get
                Return firstName
            End Get
            Set(ByVal value As String)
                If firstName = value Then
                    Return
                End If
                firstName = value
            End Set
        End Property

        Public Property middle_Name() As String
            Get
                Return middleName
            End Get
            Set(ByVal value As String)
                If middleName = value Then
                    Return
                End If
                middleName = value
            End Set
        End Property

        Public Property suffix_Name() As String
            Get
                Return suffixName
            End Get
            Set(ByVal value As String)
                If suffixName = value Then
                    Return
                End If
                suffixName = value
            End Set
        End Property

        Public Property Birth_Date() As String
            Get
                Return birthDate
            End Get
            Set(ByVal value As String)
                If birthDate = value Then
                    Return
                End If
                birthDate = value
            End Set
        End Property

        Public Property TempBirth_Date() As Date
            Get
                Return tempBirthDate
            End Get
            Set(ByVal value As Date)
                If tempBirthDate = value Then
                    Return
                End If
                tempBirthDate = value
            End Set
        End Property

        Public Property Birth_Place() As String
            Get
                Return birthPlace
            End Get
            Set(ByVal value As String)
                If birthPlace = value Then
                    Return
                End If
                birthPlace = value
            End Set
        End Property

        Public Property Constituent_Gender() As String
            Get
                Return constituentGender
            End Get
            Set(ByVal value As String)
                If constituentGender = value Then
                    Return
                End If
                constituentGender = value
            End Set
        End Property

        Public Property Civil_Status() As String
            Get
                Return civilStatus
            End Get
            Set(ByVal value As String)
                If civilStatus = value Then
                    Return
                End If
                civilStatus = value
            End Set
        End Property

        Public Property Constituent_Nationality() As String
            Get
                Return constituentNationality
            End Get
            Set(ByVal value As String)
                If constituentNationality = value Then
                    Return
                End If
                constituentNationality = value
            End Set
        End Property

        Public Property Household_No() As String
            Get
                Return householdNo
            End Get
            Set(ByVal value As String)
                If householdNo = value Then
                    Return
                End If
                householdNo = value
            End Set
        End Property

        Public Property Constituent_Address() As String
            Get
                Return constituentAddress
            End Get
            Set(ByVal value As String)
                If constituentAddress = value Then
                    Return
                End If
                constituentAddress = value
            End Set
        End Property

        Public Property ConstituentPermanent_Address() As String
            Get
                Return constituentPermanentAddress
            End Get
            Set(ByVal value As String)
                If constituentPermanentAddress = value Then
                    Return
                End If
                constituentPermanentAddress = value
            End Set
        End Property

        Public Property ConstituentBilling_Address() As String
            Get
                Return constituentBillingAddress
            End Get
            Set(ByVal value As String)
                If constituentBillingAddress = value Then
                    Return
                End If
                constituentBillingAddress = value
            End Set
        End Property

        Public Property Country_Id() As Integer
            Get
                Return countryId
            End Get
            Set(ByVal value As Integer)
                If countryId = value Then
                    Return
                End If
                countryId = value
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

        Public Property HomeTel_No() As String
            Get
                Return homeTelNo
            End Get
            Set(ByVal value As String)
                If homeTelNo = value Then
                    Return
                End If
                homeTelNo = value
            End Set
        End Property

        Public Property WorkTel_No() As String
            Get
                Return workTelNo
            End Get
            Set(ByVal value As String)
                If workTelNo = value Then
                    Return
                End If
                workTelNo = value
            End Set
        End Property

        Public Property Fax_No() As String
            Get
                Return faxNo
            End Get
            Set(ByVal value As String)
                If faxNo = value Then
                    Return
                End If
                faxNo = value
            End Set
        End Property

        Public Property Mobile_No() As String
            Get
                Return mobileNo
            End Get
            Set(ByVal value As String)
                If mobileNo = value Then
                    Return
                End If
                mobileNo = value
            End Set
        End Property

        Public Property Email_Address() As String
            Get
                Return emailAddress
            End Get
            Set(ByVal value As String)
                If emailAddress = value Then
                    Return
                End If
                emailAddress = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _taxIdNo() As String
            Get
                Return taxIdNo
            End Get
            Set(ByVal value As String)
                If taxIdNo = value Then
                    Return
                End If
                taxIdNo = value
            End Set
        End Property

        Public Property spouse_Id() As Integer
            Get
                Return spouseId
            End Get
            Set(ByVal value As Integer)
                If spouseId = value Then
                    Return
                End If
                spouseId = value
            End Set
        End Property

        Public ReadOnly Property Spouse_Name() As String
            Get
                Return spouseName
            End Get
        End Property

        Public Property SpouseContact_No() As String
            Get
                Return spouseContactNo
            End Get
            Set(ByVal value As String)
                If spouseContactNo = value Then
                    Return
                End If
                spouseContactNo = value
            End Set
        End Property

        Public Property Constituent_Remarks() As String
            Get
                Return constituentRemarks
            End Get
            Set(ByVal value As String)
                If constituentRemarks = value Then
                    Return
                End If
                constituentRemarks = value
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

        Public Property birth_Fl() As Integer
            Get
                Return birthFl
            End Get
            Set(ByVal value As Integer)
                If birthFl = value Then
                    Return
                End If
                birthFl = value
            End Set
        End Property

        Public Property constituent_Photo() As String
            Get
                Return constituentPhoto
            End Get
            Set(ByVal value As String)
                If constituentPhoto = value Then
                    Return
                End If
                constituentPhoto = value
            End Set
        End Property

        Public ReadOnly Property Tax_Credit() As Double
            Get
                Return taxCredit
            End Get
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

#Region "Class Constituent Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Dim pconstituentId = New MySqlParameter("?pconstituentId", MySqlDbType.Int64)
                Dim pconstituentType = New MySqlParameter("?pconstituentType", MySqlDbType.VarChar)
                Dim plastName = New MySqlParameter("?plastName", MySqlDbType.VarChar)
                Dim pfirstName = New MySqlParameter("?pfirstName", MySqlDbType.VarChar)
                Dim pmiddleName = New MySqlParameter("?pmiddleName", MySqlDbType.VarChar)
                Dim psuffixName = New MySqlParameter("?psuffixName", MySqlDbType.VarChar)
                Dim pbirthDate = New MySqlParameter("?pbirthDate", MySqlDbType.VarChar)
                Dim pbirthPlace = New MySqlParameter("?pbirthPlace", MySqlDbType.VarChar)
                Dim pconstituentGender = New MySqlParameter("?pconstituentGender", MySqlDbType.VarChar)
                Dim pcivilStatus = New MySqlParameter("?pcivilStatus", MySqlDbType.VarChar)
                Dim pconstituentNationality = New MySqlParameter("?pconstituentNationality", MySqlDbType.VarChar)
                Dim phouseholdNo = New MySqlParameter("?phouseholdNo", MySqlDbType.VarChar)
                Dim pconstituentAddress = New MySqlParameter("?pconstituentAddress", MySqlDbType.VarChar)
                Dim pconstituentPermanentAddress = New MySqlParameter("?pconstituentPermanentAddress", MySqlDbType.VarChar)
                Dim pconstituentBillingAddress = New MySqlParameter("?pconstituentBillingAddress", MySqlDbType.VarChar)
                Dim pcountryId = New MySqlParameter("?pcountryId", MySqlDbType.Int64)
                Dim prCode = New MySqlParameter("?prCode", MySqlDbType.VarChar)
                Dim ppCode = New MySqlParameter("?ppCode", MySqlDbType.VarChar)
                Dim pmCode = New MySqlParameter("?pmCode", MySqlDbType.VarChar)
                Dim prurCode = New MySqlParameter("?prurCode", MySqlDbType.VarChar)
                Dim pzipCodeId = New MySqlParameter("?pzipCodeId", MySqlDbType.Int64)
                Dim phomeTelNo = New MySqlParameter("?phomeTelNo", MySqlDbType.VarChar)
                Dim pworkTelNo = New MySqlParameter("?pworkTelNo", MySqlDbType.VarChar)
                Dim pfaxNo = New MySqlParameter("?pfaxNo", MySqlDbType.VarChar)
                Dim pmobileNo = New MySqlParameter("?pmobileNo", MySqlDbType.VarChar)
                Dim pemailAddress = New MySqlParameter("?pemailAddress", MySqlDbType.VarChar)
                Dim pspouseId = New MySqlParameter("?pspouseId", MySqlDbType.Int64)
                Dim pspouseContactNo = New MySqlParameter("?pspouseContactNo", MySqlDbType.VarChar)
                Dim pconstituentRemarks = New MySqlParameter("?pconstituentRemarks", MySqlDbType.VarChar)
                Dim pactiveFl = New MySqlParameter("?pactiveFl", MySqlDbType.Int64)
                Dim pconstituentPhoto = New MySqlParameter("?pconstituentPhoto", MySqlDbType.LongBlob)
                Dim ptaxIdNo = New MySqlParameter("?ptaxIdNo", MySqlDbType.VarChar)
                Dim pbirthFl = New MySqlParameter("?pbirthFl", MySqlDbType.Int64)
                Dim pupdatedBy = New MySqlParameter("?pupdatedBy", MySqlDbType.Int64)
                Dim pupdatedDt = New MySqlParameter("?pupdatedDt", MySqlDbType.VarChar)

                pconstituentId.Value = constituentId
                pconstituentType.Value = constituentType
                plastName.Value = lastName
                pfirstName.Value = firstName
                pmiddleName.Value = middleName
                psuffixName.Value = suffixName
                pbirthDate.Value = birthDate
                pbirthPlace.Value = birthPlace
                pconstituentGender.Value = constituentGender
                pcivilStatus.Value = civilStatus
                pconstituentNationality.Value = constituentNationality
                phouseholdNo.Value = householdNo
                pconstituentAddress.Value = constituentAddress
                pconstituentPermanentAddress.Value = constituentPermanentAddress
                pconstituentBillingAddress.Value = constituentBillingAddress
                pcountryId.Value = countryId
                prCode.Value = rCode
                ppCode.Value = pCode
                pmCode.Value = mCode
                prurCode.Value = rurCode
                pzipCodeId.Value = zipCodeId
                phomeTelNo.Value = homeTelNo
                pworkTelNo.Value = workTelNo
                pfaxNo.Value = faxNo
                pmobileNo.Value = mobileNo
                pemailAddress.Value = emailAddress
                pspouseId.Value = spouseId
                pspouseContactNo.Value = spouseContactNo
                pconstituentRemarks.Value = constituentRemarks
                pactiveFl.Value = activeFl
                If File.Exists(constituentPhoto) Then
                    fs = New FileStream(constituentPhoto, FileMode.Open, FileAccess.Read)
                    FileSize = fs.Length

                    rawData = New Byte(FileSize) {}
                    fs.Read(rawData, 0, FileSize)
                    fs.Close()

                    pconstituentPhoto.Value = rawData
                Else
                    pconstituentPhoto.Value = DBNull.Value
                End If
                ptaxIdNo.Value = taxIdNo
                pbirthFl.Value = birthFl
                pupdatedBy.Value = updatedBy
                pupdatedDt.Value = updatedDt

                arr = New ArrayList
                arr.Add(pconstituentId)
                arr.Add(pconstituentType)
                arr.Add(plastName)
                arr.Add(pfirstName)
                arr.Add(pmiddleName)
                arr.Add(psuffixName)
                arr.Add(pbirthDate)
                arr.Add(pbirthPlace)
                arr.Add(pconstituentGender)
                arr.Add(pcivilStatus)
                arr.Add(pconstituentNationality)
                arr.Add(phouseholdNo)
                arr.Add(pconstituentAddress)
                arr.Add(pconstituentPermanentAddress)
                arr.Add(pconstituentBillingAddress)
                arr.Add(pcountryId)
                arr.Add(prCode)
                arr.Add(ppCode)
                arr.Add(pmCode)
                arr.Add(prurCode)
                arr.Add(pzipCodeId)
                arr.Add(phomeTelNo)
                arr.Add(pworkTelNo)
                arr.Add(pfaxNo)
                arr.Add(pmobileNo)
                arr.Add(pemailAddress)
                arr.Add(pspouseId)
                arr.Add(pspouseContactNo)
                arr.Add(pconstituentRemarks)
                arr.Add(pactiveFl)
                arr.Add(pconstituentPhoto)
                arr.Add(ptaxIdNo)
                arr.Add(pbirthFl)
                arr.Add(pupdatedBy)
                arr.Add(pupdatedDt)

                Save_Record = True

                strSql = "spConstituentSave"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE, arr)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        constituentId = Me.dtSaveRow("constituentId")
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

        Public page_no As Long
        Public limiter As long

        Public Function Delete_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim dtRec As DataTable

                Delete_Record = True
                strSql = "CALL spConstituentDelete(" & constituentId & "," & updatedBy & ");"
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

                    strSql = "CALL spConstituentFind(" & constituentId _
                    & ",'" & CritLastName & "','" & CritFirstName & "','" & CritConstituentType & "'," & initFlag & "," & page_no.ToString & "," & limiter.ToString & ");"

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


        Public Function Search_Record_Count()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spConstituentFindCount(" & constituentId _
                    & ",'" & CritLastName & "','" & CritFirstName & "','" & CritConstituentType & "'," & initFlag & "," & page_no.ToString & "," & limiter.ToString & ");"

                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Return dtgRID

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

                    strSql = "CALL spConstituentFind(" & initFlag & ",'','','',2,0,10);"

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
                        Me.constituentId = Trim(myRow1("constituentId").ToString)
                        Me.constituentType = Trim(myRow1("constituentType").ToString)
                        Me.firstName = Trim(myRow1("firstName").ToString)
                        Me.lastName = Trim(myRow1("lastName").ToString)
                        Me.middleName = Trim(myRow1("middleName").ToString)
                        Me.suffixName = Trim(myRow1("suffixName").ToString)
                        Me.birthDate = Trim(myRow1("birthDate").ToString)
                        Me.tempBirthDate = Microsoft.VisualBasic.DateValue(myRow1("birthDate").ToString)
                        Me.birthPlace = Trim(myRow1("birthPlace").ToString)
                        Me.constituentGender = Trim(myRow1("constituentGender").ToString)
                        Me.civilStatus = Trim(myRow1("civilStatus").ToString)
                        Me.constituentNationality = Trim(myRow1("constituentNationality").ToString)
                        Me.householdNo = Trim(myRow1("householdNo").ToString)
                        Me.constituentAddress = Trim(myRow1("constituentAddress").ToString)
                        Me.constituentPermanentAddress = Trim(myRow1("constituentPermanentAddress").ToString)
                        Me.constituentBillingAddress = Trim(myRow1("constituentBillingAddress").ToString)
                        Me.countryId = Trim(myRow1("countryId").ToString)
                        Me.rCode = Trim(myRow1("rCode").ToString)
                        Me.pCode = Trim(myRow1("pCode").ToString)
                        Me.mCode = Trim(myRow1("mCode").ToString)
                        Me.rurCode = Trim(myRow1("rurCode").ToString)
                        Me.zipCodeId = Trim(myRow1("zipCodeId").ToString)
                        Me.homeTelNo = Trim(myRow1("homeTelNo").ToString)
                        Me.workTelNo = Trim(myRow1("workTelNo").ToString)
                        Me.faxNo = Trim(myRow1("faxNo").ToString)
                        Me.mobileNo = Trim(myRow1("mobileNo").ToString)
                        Me.emailAddress = Trim(myRow1("emailAddress").ToString)
                        Me.spouseId = Trim(myRow1("spouseId").ToString)
                        Me.spouseName = Trim(myRow1("spouseName").ToString)
                        Me.spouseContactNo = Trim(myRow1("spouseContactNo").ToString)
                        Me.constituentRemarks = Trim(myRow1("constituentRemarks").ToString)
                        Me.activeFl = Trim(myRow1("activeFl").ToString)
                        If Not IsDBNull(myRow1("constituentPhoto")) Then
                            Me.constituentPhoto = ImageDir & "\" & LCase(lastName) & LCase(firstName) & LCase(middleName) & LCase(suffixName) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("constituentPhoto")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(constituentPhoto, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                            End Try
                        Else
                            Me.constituentPhoto = ""
                        End If
                        Me.taxIdNo = Trim(myRow1("taxIdNo").ToString)
                        Me.birthFl = Trim(myRow1("birthFl").ToString)
                        Me.taxCredit = Trim(myRow1("taxCredit").ToString)
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

                paramVal = dtParam.Rows(0)("paramVal")

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
            Return paramVal
        End Function

        Public Function GetNationality() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spConstituentNationalityGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetCountryList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialCountryGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
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

        Public Function GetConstituentRecordCount() As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spConstituentRecordCountGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetConstituentRecordCount = dtRecord.Rows(0)("RecNo")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function
#End Region

#Region "Class Constituent Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritFirstName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritFirstName))
                CritLastName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLastName))
                CritConstituentType = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritConstituentType))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                birthDate = tempBirthDate.ToString("yyyy-MM-dd")

                constituentType = .ReplaceSingleQuotes(constituentType)
                firstName = .ReplaceSingleQuotes(firstName)
                lastName = .ReplaceSingleQuotes(lastName)
                middleName = .ReplaceSingleQuotes(middleName)
                suffixName = .ReplaceSingleQuotes(suffixName)
                birthDate = .ReplaceSingleQuotes(birthDate)
                birthPlace = .ReplaceSingleQuotes(birthPlace)
                constituentGender = .ReplaceSingleQuotes(constituentGender)
                civilStatus = .ReplaceSingleQuotes(civilStatus)
                constituentNationality = .ReplaceSingleQuotes(constituentNationality)
                householdNo = .ReplaceSingleQuotes(householdNo)
                constituentAddress = .ReplaceSingleQuotes(constituentAddress)
                constituentPermanentAddress = .ReplaceSingleQuotes(constituentPermanentAddress)
                constituentBillingAddress = .ReplaceSingleQuotes(constituentBillingAddress)
                homeTelNo = .ReplaceSingleQuotes(homeTelNo)
                workTelNo = .ReplaceSingleQuotes(workTelNo)
                faxNo = .ReplaceSingleQuotes(faxNo)
                mobileNo = .ReplaceSingleQuotes(mobileNo)
                emailAddress = .ReplaceSingleQuotes(emailAddress)
                spouseContactNo = .ReplaceSingleQuotes(spouseContactNo)
                constituentRemarks = .ReplaceSingleQuotes(constituentRemarks)
            End With
        End Sub

#End Region

    End Class

End Namespace
