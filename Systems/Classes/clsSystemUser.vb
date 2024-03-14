Imports System.IO
Imports MySql.Data.MySqlClient

Namespace SystemUser

    Public Class SystemUser

#Region "Class SystemUser Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritRoleName As String
        Private CritFirstName As String
        Private CritLastName As String
        Private CritActiveFl As Integer

        Private userId As Integer
        Private roleId As Integer
        Private memberId As Integer
        Private memberNo As String
        Private roleName As String
        Private userName As String
        Private password As String
        Private firstName As String
        Private middleName As String
        Private lastName As String
        Private jobDescription As String
        Private memberPhoto As String
        Private memberBirthdate As String
        Private tempmemberBirthdate As Date
        Private memberGender As String
        Private maritalStatus As String
        Private homeTel As String
        Private workTel As String
        Private mobileNo As String
        Private emailAddress As String
        Private homeAddress As String
        Private rCode As String
        Private pCode As String
        Private mCode As String
        Private rurCode As String
        Private zipCodeId As Integer
        Private taxIdNo As String
        Private sssNo As String
        Private activeFl As Integer
        Private memberActiveFl As Integer
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

#Region "Class SystemUser Public Property Variable Declaration"

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

        Public WriteOnly Property CritRole_Name() As String
            Set(ByVal Value As String)
                If CritRoleName = Value Then
                    Return
                End If
                CritRoleName = Value
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

        Public WriteOnly Property CritLast_Name() As String
            Set(ByVal Value As String)
                If CritLastName = Value Then
                    Return
                End If
                CritLastName = Value
            End Set
        End Property

        Public WriteOnly Property CritActive_Fl() As Integer
            Set(ByVal Value As Integer)
                If CritActiveFl = Value Then
                    Return
                End If
                CritActiveFl = Value
            End Set
        End Property

        Public Property User_ID() As Integer
            Get
                Return userId
            End Get
            Set(ByVal Value As Integer)
                If userId = Value Then
                    Return
                End If
                userId = Value
            End Set
        End Property

        Public Property Role_ID() As Integer
            Get
                Return roleId
            End Get
            Set(ByVal Value As Integer)
                If roleId = Value Then
                    Return
                End If
                roleId = Value
            End Set
        End Property

        Public Property Member_Id() As Integer
            Get
                Return memberId
            End Get
            Set(ByVal value As Integer)
                If memberId = value Then
                    Return
                End If
                memberId = value
            End Set
        End Property

        Public Property Member_No() As String
            Get
                Return memberNo
            End Get
            Set(ByVal value As String)
                If memberNo = value Then
                    Return
                End If
                memberNo = value
            End Set
        End Property

        Public Property Role_Name() As String
            Get
                Return roleName
            End Get
            Set(ByVal Value As String)
                If roleName = Value Then
                    Return
                End If
                roleName = Value
            End Set
        End Property

        Public Property User_Name() As String
            Get
                Return userName
            End Get
            Set(ByVal Value As String)
                If userName = Value Then
                    Return
                End If
                userName = Value
            End Set
        End Property

        Public Property Passwd() As String
            Get
                Return password
            End Get
            Set(ByVal Value As String)
                If password = Value Then
                    Return
                End If
                password = Value
            End Set
        End Property

        Public Property First_Name() As String
            Get
                Return firstName
            End Get
            Set(ByVal Value As String)
                If firstName = Value Then
                    Return
                End If
                firstName = Value
            End Set
        End Property

        Public Property Middle_Name() As String
            Get
                Return middleName
            End Get
            Set(ByVal Value As String)
                If middleName = Value Then
                    Return
                End If
                middleName = Value
            End Set
        End Property

        Public Property Last_Name() As String
            Get
                Return lastName
            End Get
            Set(ByVal Value As String)
                If lastName = Value Then
                    Return
                End If
                lastName = Value
            End Set
        End Property

        Public Property Home_Tel() As String
            Get
                Return homeTel
            End Get
            Set(ByVal Value As String)
                If homeTel = Value Then
                    Return
                End If
                homeTel = Value
            End Set
        End Property

        Public Property Work_Tel() As String
            Get
                Return workTel
            End Get
            Set(ByVal Value As String)
                If workTel = Value Then
                    Return
                End If
                workTel = Value
            End Set
        End Property

        Public Property Mobile_No() As String
            Get
                Return mobileNo
            End Get
            Set(ByVal Value As String)
                If mobileNo = Value Then
                    Return
                End If
                mobileNo = Value
            End Set
        End Property

        Public Property Email_Address() As String
            Get
                Return emailAddress
            End Get
            Set(ByVal Value As String)
                If emailAddress = Value Then
                    Return
                End If
                emailAddress = Value
            End Set
        End Property

        Public Property Home_Address() As String
            Get
                Return homeAddress
            End Get
            Set(ByVal Value As String)
                If homeAddress = Value Then
                    Return
                End If
                homeAddress = Value
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

        Public Property P_code() As String
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

        Public Property M_code() As String
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

        Public Property Rur_code() As String
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

        Public Property Zip_CodeId() As Integer
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

        Public Property member_Gender() As String
            Get
                Return memberGender
            End Get
            Set(ByVal value As String)
                If memberGender = value Then
                    Return
                End If
                memberGender = value
            End Set
        End Property

        Public Property Job_Description() As String
            Get
                Return jobDescription
            End Get
            Set(ByVal Value As String)
                If jobDescription = Value Then
                    Return
                End If
                jobDescription = Value
            End Set
        End Property

        Public Property member_Photo() As String
            Get
                Return memberPhoto
            End Get
            Set(ByVal value As String)
                If memberPhoto = value Then
                    Return
                End If
                memberPhoto = value
            End Set
        End Property

        Public Property TempUserBirth_Date() As Date
            Get
                Return tempmemberBirthdate
            End Get
            Set(ByVal Value As Date)
                If tempmemberBirthdate = Value Then
                    Return
                End If
                tempmemberBirthdate = Value
            End Set
        End Property

        Public Property member_Birthdate() As String
            Get
                Return memberBirthdate
            End Get
            Set(ByVal Value As String)
                If memberBirthdate = Value Then
                    Return
                End If
                memberBirthdate = Value
            End Set
        End Property

        Public Property Marital_Status() As String
            Get
                Return maritalStatus
            End Get
            Set(ByVal Value As String)
                If maritalStatus = Value Then
                    Return
                End If
                maritalStatus = Value
            End Set
        End Property

        Public Property Tax_IdNo() As String
            Get
                Return taxIdNo
            End Get
            Set(ByVal Value As String)
                If taxIdNo = Value Then
                    Return
                End If
                taxIdNo = Value
            End Set
        End Property

        Public Property SSS_No() As String
            Get
                Return sssNo
            End Get
            Set(ByVal Value As String)
                If sssNo = Value Then
                    Return
                End If
                sssNo = Value
            End Set
        End Property

        Public Property Active_fl() As Integer
            Get
                Return activeFl
            End Get
            Set(ByVal Value As Integer)
                If activeFl = Value Then
                    Return
                End If
                activeFl = Value
            End Set
        End Property

        Public Property MemberActive_fl() As Integer
            Get
                Return memberActiveFl
            End Get
            Set(ByVal Value As Integer)
                If memberActiveFl = Value Then
                    Return
                End If
                memberActiveFl = Value
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

#Region "Class SystemUser Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSystemUserSave(" & userId & "," & roleId & ",'" & userName & "','" & password & "'," & memberId & "," & activeFl & "," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        userId = Me.dtSaveRow("userId")
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
                strSql = "CALL spSystemUserDelete(" & userId & "," & updatedBy & ");"
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

                    strSql = "CALL spSystemUserFind(" & userId _
                    & ",'" & CritRoleName & "','" & CritFirstName & "','" & CritLastName & "'," & CritActiveFl & "," & initFlag & ");"

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

                    strSql = "CALL spSystemUserFind(" & initFlag & ",'','','',0,2);"

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
                        Me.userId = Trim(myRow1("userID").ToString)
                        Me.roleId = Trim(myRow1("roleID").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberNo = Trim(myRow1("memberNo").ToString)
                        Me.roleName = Trim(myRow1("roleName").ToString)
                        Me.userName = Trim(myRow1("userName").ToString)
                        Me.password = Trim(myRow1("password").ToString)
                        Me.firstName = Trim(myRow1("firstName").ToString)
                        Me.middleName = Trim(myRow1("middleName").ToString)
                        Me.lastName = Trim(myRow1("lastName").ToString)
                        Me.jobDescription = Trim(myRow1("jobDescription").ToString)
                        If Not IsDBNull(myRow1("memberPhoto")) Then
                            Me.memberPhoto = ImageDir & "\" & LCase(lastName) & LCase(firstName) & LCase(middleName) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("memberPhoto")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(memberPhoto, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                            End Try
                        Else
                            Me.memberPhoto = ""
                        End If
                        Me.memberBirthdate = Trim(myRow1("memberBirthdate").ToString)
                        Me.tempmemberBirthdate = Microsoft.VisualBasic.DateValue(myRow1("memberBirthdate").ToString)
                        Me.maritalStatus = Trim(myRow1("maritalStatus").ToString)
                        Me.memberGender = Trim(myRow1("memberGender").ToString)
                        Me.activeFl = Trim(myRow1("activeFl").ToString)
                        Me.memberActiveFl = Trim(myRow1("memberActiveFl").ToString)
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

        Public Function GetRoleNames() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSystemUserRoleGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetJobTitles() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSystemUserJobGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
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

#Region "Class SystemUser Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritFirstName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritFirstName))
                CritLastName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLastName))
                CritRoleName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRoleName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                userName = .ReplaceSingleQuotes(userName)
                password = .ReplaceSingleQuotes(password)
            End With
        End Sub

#End Region

    End Class

End Namespace
