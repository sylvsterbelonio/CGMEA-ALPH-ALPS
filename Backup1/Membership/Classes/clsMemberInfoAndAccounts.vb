Imports System.IO
Imports MySql.Data.MySqlClient

Namespace MemberInfoAndAccounts

    Public Class MemberInfoAndAccounts

#Region "Class Members Info And Accounts Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritMemberNo As String
        Private CritMemberName As String
        Private CritDepartmentName As String
        Private CritActiveFl As Integer
        Private CritMemberFl As Integer

        Private intChildCount As Integer
        Private intParentCount As Integer
        Private dtCheck1 As DataSet
        Private dtCheck2 As DataSet
        Private dtRowCheck1 As DataRow
        Private dtRowCheck2 As DataRow
        Private dtRecord As DataTable

        Private memberId As Integer
        Private memberNo As String
        Private lastName As String
        Private firstName As String
        Private middleName As String
        Private suffixName As String
        Private birthFl As Integer
        Private memberBirthdate As String
        Private tempmemberBirthdate As Date
        Private homeAddress As String
        Private memberGender As String
        Private maritalStatus As String
        Private homeTel As String
        Private mobileNo As String
        Private departmentName As String
        Private jobDescription As String
        Private appointmentFl As Integer
        Private appointmentDt As String
        Private tempAppointmentDt As Date
        Private activeFl As Integer
        Private memberFl As Integer
        Private cgmeaMembershipFl As Integer
        Private cgmeaMembershipDt As String
        Private tempCgmeaMembershipDt As Date

        Private memberPhoto As String
        Private updatedBy As Integer
        Private updatedDt As String

        Private contributionId As Integer

        Dim clsMemberContributionDetail As New Bookkeper.MemberContribution.MemberContribution
        Dim strMemberContributionDetail As String
        Private colMemberContributionDetail As New Collection

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private FileSize As UInt32
        Private rawData() As Byte
        Private fs As FileStream

#End Region

#Region "Class Members Info And Accounts Public Property Variable Declaration"

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

        Public Property CritMember_No() As String
            Get
                Return CritMemberNo
            End Get
            Set(ByVal value As String)
                If CritMemberNo = value Then
                    Return
                End If
                CritMemberNo = value
            End Set
        End Property

        Public WriteOnly Property CritMember_Name() As String
            Set(ByVal Value As String)
                If CritMemberName = Value Then
                    Return
                End If
                CritMemberName = Value
            End Set
        End Property

        Public WriteOnly Property CritDepartment_Name() As String
            Set(ByVal Value As String)
                If CritDepartmentName = Value Then
                    Return
                End If
                CritDepartmentName = Value
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

        Public WriteOnly Property CritMember_Fl() As Integer
            Set(ByVal Value As Integer)
                If CritMemberFl = Value Then
                    Return
                End If
                CritMemberFl = Value
            End Set
        End Property

        Public ReadOnly Property intChild_Count() As Integer
            Get
                Return intChildCount
            End Get
        End Property

        Public ReadOnly Property intParent_Count() As Integer
            Get
                Return intParentCount
            End Get
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

        Public Property Department_Name() As String
            Get
                Return departmentName
            End Get
            Set(ByVal Value As String)
                If departmentName = Value Then
                    Return
                End If
                departmentName = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _suffixName() As String
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

        Public Property Last_Name() As String
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

        Public Property First_Name() As String
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

        Public Property Middle_Name() As String
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

        Public Property Job_Description() As String
            Get
                Return jobDescription
            End Get
            Set(ByVal value As String)
                If jobDescription = value Then
                    Return
                End If
                jobDescription = value
            End Set
        End Property

        Public Property Member_Photo() As String
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

        Public Property Birth_Fl() As Integer
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

        Public Property Member_Birthdate() As Date
            Get
                Return memberBirthdate
            End Get
            Set(ByVal value As Date)
                If memberBirthdate = value Then
                    Return
                End If
                memberBirthdate = value
            End Set
        End Property

        Public Property TempmemberBirth_Date() As Date
            Get
                Return tempmemberBirthdate
            End Get
            Set(ByVal value As Date)
                If tempmemberBirthdate = value Then
                    Return
                End If
                tempmemberBirthdate = value
            End Set
        End Property

        Public Property Member_Gender() As String
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

        Public Property Marital_Status() As String
            Get
                Return maritalStatus
            End Get
            Set(ByVal value As String)
                If maritalStatus = value Then
                    Return
                End If
                maritalStatus = value
            End Set
        End Property

        Public Property Home_Tel() As String
            Get
                Return homeTel
            End Get
            Set(ByVal value As String)
                If homeTel = value Then
                    Return
                End If
                homeTel = value
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

        Public Property Home_Address() As String
            Get
                Return homeAddress
            End Get
            Set(ByVal value As String)
                If homeAddress = value Then
                    Return
                End If
                homeAddress = value
            End Set
        End Property

        Public Property Appointment_Fl() As Integer
            Get
                Return appointmentFl
            End Get
            Set(ByVal value As Integer)
                If appointmentFl = value Then
                    Return
                End If
                appointmentFl = value
            End Set
        End Property

        Public Property Appointment_Dt() As String
            Get
                Return appointmentDt
            End Get
            Set(ByVal value As String)
                If appointmentDt = value Then
                    Return
                End If
                appointmentDt = value
            End Set
        End Property

        Public Property TempAppointment_Dt() As Date
            Get
                Return tempAppointmentDt
            End Get
            Set(ByVal value As Date)
                If tempAppointmentDt = value Then
                    Return
                End If
                tempAppointmentDt = value
            End Set
        End Property

        Public Property CgmeaMembership_Fl() As Integer
            Get
                Return cgmeaMembershipFl
            End Get
            Set(ByVal value As Integer)
                If cgmeaMembershipFl = value Then
                    Return
                End If
                cgmeaMembershipFl = value
            End Set
        End Property

        Public Property CgmeaMembership_Dt() As String
            Get
                Return cgmeaMembershipDt
            End Get
            Set(ByVal value As String)
                If cgmeaMembershipDt = value Then
                    Return
                End If
                cgmeaMembershipDt = value
            End Set
        End Property

        Public Property TempCgmeaMembership_Dt() As Date
            Get
                Return tempCgmeaMembershipDt
            End Get
            Set(ByVal value As Date)
                If tempCgmeaMembershipDt = value Then
                    Return
                End If
                tempCgmeaMembershipDt = value
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

        <CLSCompliant(False)> _
        Public Property colMemberContribution_Detail() As Collection
            Get
                Return colMemberContributionDetail
            End Get
            Set(ByVal Value As Collection)
                If colMemberContributionDetail Is Value Then
                    Return
                End If
                colMemberContributionDetail = Value
            End Set
        End Property

        Public Property Contribution_Id() As Integer
            Get
                Return contributionId
            End Get
            Set(ByVal Value As Integer)
                If contributionId = Value Then
                    Return
                End If
                contributionId = Value
            End Set
        End Property

#End Region

#Region "Class Members Info And Accounts Public Functions"

        Public Function Search_Record()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spMemberFind(" & memberId _
                    & ",'" & CritMemberNo & "','" & CritMemberName & "','','" _
                    & CritDepartmentName & "'," & CritActiveFl & "," & CritMemberFl & "," & initFlag & ");"

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

                    strSql = "CALL spMemberFind(" & initFlag & ",'','','',''," & CritActiveFl & "," & CritMemberFl & ",2);"

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
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberNo = Trim(myRow1("memberNo").ToString)
                        Me.departmentName = Trim(myRow1("departmentName").ToString)
                        Me.firstName = Trim(myRow1("firstName").ToString)
                        Me.middleName = Trim(myRow1("middleName").ToString)
                        Me.lastName = Trim(myRow1("lastName").ToString)
                        Me.suffixName = Trim(myRow1("suffixName").ToString)
                        Me.jobDescription = Trim(myRow1("jobDescription").ToString)
                        If Not IsDBNull(myRow1("memberPhoto")) Then
                            Me.memberPhoto = ImageDir & "\" & LCase(lastName) & LCase(firstName) & LCase(middleName) & LCase(suffixName) & ".jpg"
                            Dim b() As Byte
                            Try
                                b = myRow1("memberPhoto")
                                Dim K As Long
                                K = UBound(b)

                                Dim WriteFs As New FileStream(memberPhoto, FileMode.Create, FileAccess.ReadWrite)
                                WriteFs.Write(b, 0, K)
                                WriteFs.Close()
                            Catch oExcept As Exception
                                'clsCommon.Prompt_User("error", "Error creating member image to disk :" & oExcept.Message)
                            End Try
                        Else
                            Me.memberPhoto = ""
                        End If
                        Me.memberBirthdate = Trim(myRow1("memberBirthdate").ToString)
                        Me.tempmemberBirthdate = Microsoft.VisualBasic.DateValue(myRow1("memberBirthdate").ToString)
                        Me.memberGender = Trim(myRow1("memberGender").ToString)
                        Me.maritalStatus = Trim(myRow1("maritalStatus").ToString)
                        Me.homeTel = Trim(myRow1("homeTel").ToString)
                        Me.mobileNo = Trim(myRow1("mobileNo").ToString)
                        Me.homeAddress = Trim(myRow1("homeAddress").ToString)
                        Me.activeFl = Trim(myRow1("activeFl").ToString)
                        Me.memberFl = Trim(myRow1("memberFl").ToString)
                        Me.appointmentFl = Trim(myRow1("appointmentFl").ToString)
                        Me.appointmentDt = Trim(myRow1("appointmentDt").ToString)
                        Me.tempAppointmentDt = Microsoft.VisualBasic.DateValue(myRow1("appointmentDt").ToString)
                        Me.cgmeaMembershipFl = Trim(myRow1("cgmeaMembershipFl").ToString)
                        Me.cgmeaMembershipDt = Trim(myRow1("cgmeaMembershipDt").ToString)
                        Me.tempCgmeaMembershipDt = Trim(myRow1("cgmeaMembershipDt").ToString)
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

        Public Function GetDepartmentNames() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spDepartmentGet();"
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
                sqlComboStmt = "CALL spMemberJobGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetAppointmentStatus() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spMemberAppointmentStatusGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetDepartmentList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spDepartmentGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function GetDefaultParameter(ByVal paramName As String) As String
            Dim dtParam As DataTable
            Dim sqlStmt As String
            Dim paramVal As String = ""

            Try
                sqlStmt = "CALL spDefaultParameterGet('" & paramName & "');"
                dtParam = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                If dtParam.Rows.Count <> 0 Then
                    paramVal = dtParam.Rows(0)("paramVal")
                Else
                    paramVal = ""
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            End Try
            Return paramVal
        End Function

        Public Function GetNewMemberNo() As Integer
            Dim sqlStmt As String
            GetNewMemberNo = 0
            Try
                sqlStmt = "CALL spMemberNoGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetNewMemberNo = dtRecord.Rows(0)("memberNo")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Populate_Member_Contribution_Monthly(ByVal Id As Integer, ByVal conYr As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionMonthlyFind(" & Id & "," & conYr & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_Contribution_Details(ByVal Id As Integer, ByVal conDt As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionDetailsFind(" & Id & ",'" & conDt & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function GetMemberContributionTotal(ByVal typeId As Integer, ByVal memId As Integer) As Double
            Dim sqlStmt As String
            GetMemberContributionTotal = 0
            Try
                sqlStmt = "CALL spMemberContributionTotalGet(" & typeId & "," & memId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberContributionTotal = dtRecord.Rows(0)("totalContribution")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Update_Member_Contribution(ByVal sql As String) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Update_Member_Contribution = True
                strSql = "CALL spMemberContributionUpdate(" & sql & ");"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As Exception
                RaiseEvent MsgArrival(ex.Message, False)
                Update_Member_Contribution = False
            End Try
        End Function

        Public Function Populate_Member_Loan(ByVal Id As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanFind(" & Id & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_Loan_Report(ByVal Id As Integer, ByVal Dt As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanReport(" & Id & ",'" & Dt & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Payment_Record(ByVal mId As Integer) As DataTable
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanPaymentRecordsFind(" & mId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_Withdrawal_Record(ByVal mId As Integer) As DataTable
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberWithdrawalRecordsFind(" & mId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Payment_Report(ByVal mId As Integer, ByVal Dt As String) As DataTable
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanPaymentReport(" & mId & ",'" & Dt & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function GetMemberContributionMinYear() As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberContributionMinYearRecordGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberContributionMinYear = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetMemberContributionMaxYear() As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberContributionMaxYearRecordGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberContributionMaxYear = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Save_Record_Contribution() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Build_String_Before_Saving()

                Save_Record_Contribution = True
                strSql = "CALL spMemberContributionDetailSave(" & memberId & ",'" & strMemberContributionDetail & "'," & updatedBy & ");"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        memberId = Me.dtSaveRow("memberId")
                        updatedDt = Me.dtSaveRow("updatedDt")
                    Next
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Record_Contribution = False
            End Try
        End Function

        Public Function Delete_Record_Contribution() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim dtRec As DataTable

                Delete_Record_Contribution = True
                strSql = "CALL spMemberContributionDelete(" & contributionId & "," & updatedBy & ");"
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
                Delete_Record_Contribution = False
            End Try
        End Function
           
        Public Function Populate_Record_Member(ByVal MId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberFind(" & MId & ",'','','','',0,0,2);"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_Contribution_Report(ByVal mId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionSummaryReport(" & mId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Contribution_Report(ByVal mId As Integer, ByVal Dt As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionReport(" & mId & ",'" & Dt & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Member_Loan_Details_Report(ByVal LId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationDetailReport(" & LId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function


        Public Function Member_Loan_Schedules_Report(ByVal LId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationScheduleReport(" & LId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Member_Loan_Summary_Report(ByVal MId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationSummaryReport(" & MId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function
#End Region

#Region "Class Members Info And Accounts Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                CritDepartmentName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentName))
                CritMemberNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberNo))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                memberBirthdate = tempmemberBirthdate.ToString("yyyy-MM-dd")
                appointmentDt = tempAppointmentDt.ToString("yyyy-MM-dd")
                cgmeaMembershipDt = tempCgmeaMembershipDt.ToString("yyyy-MM-dd")

                memberNo = .ReplaceSingleQuotes(memberNo)
                departmentName = .ReplaceSingleQuotes(departmentName)
                firstName = .ReplaceSingleQuotes(firstName)
                middleName = .ReplaceSingleQuotes(middleName)
                lastName = .ReplaceSingleQuotes(lastName)
                suffixName = .ReplaceSingleQuotes(suffixName)
                homeTel = .ReplaceSingleQuotes(homeTel)
                mobileNo = .ReplaceSingleQuotes(mobileNo)
                homeAddress = .ReplaceSingleQuotes(homeAddress)
                jobDescription = .ReplaceSingleQuotes(jobDescription)
                memberBirthdate = .ReplaceSingleQuotes(memberBirthdate)
                maritalStatus = .ReplaceSingleQuotes(maritalStatus)
                memberGender = .ReplaceSingleQuotes(memberGender)
                appointmentDt = .ReplaceSingleQuotes(appointmentDt)
                cgmeaMembershipDt = .ReplaceSingleQuotes(cgmeaMembershipDt)
            End With
        End Sub

        Private Sub Build_String_Before_Saving()
            Dim clsMemberContributionDetail As Bookkeper.MemberContribution.MemberContribution
            strMemberContributionDetail = ""

            If IsNothing(colMemberContributionDetail) = False Then
                For Each clsMemberContributionDetail In colMemberContributionDetail
                    strMemberContributionDetail += CInt(clsMemberContributionDetail.ConType_Id) _
                            & "|" & CStr(clsMemberContributionDetail.Contribution_Dt) _
                            & "|" & CDbl(clsMemberContributionDetail.Contribution_Amount) _
                            & "|" & CStr(clsMemberContributionDetail.Contribution_Remarks) & "|"
                Next
            End If
        End Sub

#End Region

    End Class

End Namespace
