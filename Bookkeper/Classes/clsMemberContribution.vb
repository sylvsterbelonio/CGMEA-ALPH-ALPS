Imports System.IO
Imports MySql.Data.MySqlClient
Namespace MemberContribution

    Public Class MemberContribution

#Region "Class Member Contribution Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritMemberNo As String
        Private CritMemberName As String
        Private CritDepartmentName As String

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
        Private departmentName As String

        Private contributionId As Integer

        Private conTypeId As Integer
        Private contributionDt As String
        Private contributionAmount As Double
        Private contributionRemarks As String
        Private updatedBy As Integer
        Private updatedDt As String

        Dim strMemberContributionDetail As String
        Private colMemberContributionDetail As New Collection
        Dim strContributionDetail As String
        Private colContributionDetail As New Collection

        Dim clsMemberContributionDetails = New MemberContributionDetails.MemberContributionDetails
        Dim strMemberContributionUpdaterDetail As String
        Private colMemberContributionUpdaterDetail As New Collection


        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private FileSize As UInt32
        Private rawData() As Byte
        Private fs As FileStream

#End Region
        
#Region "Class Member Contribution Public Property Variable Declaration"

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


        Public Property ConType_Id() As Integer
            Get
                Return conTypeId
            End Get
            Set(ByVal Value As Integer)
                If conTypeId = Value Then
                    Return
                End If
                conTypeId = Value
            End Set
        End Property

        Public Property Contribution_Dt() As String
            Get
                Return contributionDt
            End Get
            Set(ByVal Value As String)
                If contributionDt = Value Then
                    Return
                End If
                contributionDt = Value
            End Set
        End Property

        Public Property Contribution_Amount() As Double
            Get
                Return contributionAmount
            End Get
            Set(ByVal Value As Double)
                If contributionAmount = Value Then
                    Return
                End If
                contributionAmount = Value
            End Set
        End Property

        Public Property Contribution_Remarks() As String
            Get
                Return contributionRemarks
            End Get
            Set(ByVal Value As String)
                If contributionRemarks = Value Then
                    Return
                End If
                contributionRemarks = Value
            End Set
        End Property

        Public Property Updated_By() As Integer
            Get
                Return updatedBy
            End Get
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

        <CLSCompliant(False)> _
     Public Property colContribution_Detail() As Collection
            Get
                Return colContributionDetail
            End Get
            Set(ByVal Value As Collection)
                If colContributionDetail Is Value Then
                    Return
                End If
                colContributionDetail = Value
            End Set
        End Property


        <CLSCompliant(False)> _
     Public Property _colMemberContributionUpdaterDetail() As Collection
            Get
                Return colMemberContributionUpdaterDetail
            End Get
            Set(ByVal Value As Collection)
                If colMemberContributionUpdaterDetail Is Value Then
                    Return
                End If
                colMemberContributionUpdaterDetail = Value
            End Set
        End Property

#End Region

#Region "Class Member Contribution Public Functions"

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
                    & CritDepartmentName & "',1,1," & initFlag & ");"

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

                    strSql = "CALL spMemberFind(" & initFlag & ",'','','','',1,1,2);"

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

        Public Function Populate_Contribution_List_Detail() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spContributionListDetailFind();"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function GetMemberContributionPrev(ByVal mId As Integer, ByVal fId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spContributionListDetailPrevGet(" & mId & "," & fId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberContributionPrev = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
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

        Public Function Update_Record_Contribution() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Build_String_Before_Saving()

                Update_Record_Contribution = True
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
                Update_Record_Contribution = False
            End Try
        End Function

        Public Function Save_Record_Contribution() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildContribution_String_Before_Saving()

                Save_Record_Contribution = True
                strSql = "CALL spMemberContributionSave(" & memberId & ",'" & strContributionDetail & "'," & updatedBy & ");"

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
                strSql = "CALL spMemberContributionDelete(" & memberId & ",'" & contributionDt & "'," & updatedBy & ");"
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

        Public Function Save_Member_Contribution_Record(ByVal mId As Integer, ByVal fId As Integer, ByVal cDt As String, ByVal cAmt As Double, ByVal ref3 As Integer, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildUpdater_String_Before_Saving()
                'Clean_Parameters_Save()

                Save_Member_Contribution_Record = True
                strSql = "CALL spMemberContributionUpdaterSave(" & mId & _
                "," & fId & ",'" & cDt & "'," & cAmt & "," & ref3 & "," & gUser & ");"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Member_Contribution_Record = False
            End Try
        End Function

        Public Function Save_Member_Contribution_Others_Record(ByVal mId As Integer, ByVal fId As Integer, ByVal cDt As String, ByVal cAmt As Double, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildUpdater_String_Before_Saving()
                'Clean_Parameters_Save()

                Save_Member_Contribution_Others_Record = True
                strSql = "CALL spMemberContributionOthersUpdaterSave(" & mId & _
                "," & fId & ",'" & cDt & "','" & cAmt & "'," & gUser & ");"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Member_Contribution_Others_Record = False
            End Try
        End Function

        Public Function System_User_Report() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spReportSystemUserFind(" & gUserID & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function


        Public Function Populate_Member_Contribution_List_Report(ByVal conDt As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spContributionDetailReport('" & conDt & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
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

        Public Function Populate_Member_Drawings_Report(ByVal mId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberWithdrawalSummaryReport(" & mId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function
#End Region

#Region "Class Members Contribution Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                'CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                'CritDepartmentName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentName))
                'CritMemberNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberNo))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                'memberBirthdate = tempmemberBirthdate.ToString("yyyy-MM-dd")
                'appointmentDt = tempAppointmentDt.ToString("yyyy-MM-dd")
                'cgmeaMembershipDt = tempCgmeaMembershipDt.ToString("yyyy-MM-dd")

                'memberNo = .ReplaceSingleQuotes(memberNo)
                'departmentName = .ReplaceSingleQuotes(departmentName)
                'firstName = .ReplaceSingleQuotes(firstName)
                'middleName = .ReplaceSingleQuotes(middleName)
                'lastName = .ReplaceSingleQuotes(lastName)
                'suffixName = .ReplaceSingleQuotes(suffixName)
                'homeTel = .ReplaceSingleQuotes(homeTel)
                'mobileNo = .ReplaceSingleQuotes(mobileNo)
                'homeAddress = .ReplaceSingleQuotes(homeAddress)
                'jobDescription = .ReplaceSingleQuotes(jobDescription)
                'memberBirthdate = .ReplaceSingleQuotes(memberBirthdate)
                'maritalStatus = .ReplaceSingleQuotes(maritalStatus)
                'memberGender = .ReplaceSingleQuotes(memberGender)
                'appointmentDt = .ReplaceSingleQuotes(appointmentDt)
                'cgmeaMembershipDt = .ReplaceSingleQuotes(cgmeaMembershipDt)
            End With
        End Sub

        Private Sub Build_String_Before_Saving()
            Dim MemberContribution As MemberContribution
            strMemberContributionDetail = ""

            If IsNothing(colMemberContributionDetail) = False Then
                For Each MemberContribution In colMemberContributionDetail
                    strMemberContributionDetail += CInt(MemberContribution.ConType_Id) _
                            & "|" & CStr(MemberContribution.Contribution_Dt) _
                            & "|" & CDbl(MemberContribution.Contribution_Amount) _
                            & "|" & CStr(MemberContribution.Contribution_Remarks) & "|"
                Next
            End If
        End Sub

        Private Sub BuildContribution_String_Before_Saving()

            Dim ContributionDetails As ContributionDetails.ContributionDetails
            strContributionDetail = ""

            If IsNothing(colContributionDetail) = False Then
                For Each ContributionDetails In colContributionDetail
                    strContributionDetail += CInt(ContributionDetails._ContributionId) _
                            & "|" & CInt(ContributionDetails._TypeId) _
                            & "|" & CStr(ContributionDetails._ContributionDt) _
                            & "|" & CDbl(ContributionDetails._Amount) _
                            & "|" & CStr(ContributionDetails._Remarks) & "|"
                Next
            End If
        End Sub

        Private Sub BuildUpdater_String_Before_Saving()
            Dim MemberContributionUpdater As MemberContributionDetails.MemberContributionDetails
            strMemberContributionUpdaterDetail = ""

            If IsNothing(colMemberContributionUpdaterDetail) = False Then
                For Each MemberContributionUpdater In colMemberContributionUpdaterDetail
                    strMemberContributionUpdaterDetail += CInt(MemberContributionUpdater._memberId) _
                            & "|" & CStr(MemberContributionUpdater._contributionDt) _
                            & "|" & CDbl(MemberContributionUpdater._contributionAmount) _
                            & "|" & CDbl(MemberContributionUpdater._pabaonAmount) _
                            & "|" & CDbl(MemberContributionUpdater._mortuaryAmount) _
                            & "|" & CStr(MemberContributionUpdater._pSLinkAmount) & "|"
                Next
            End If
        End Sub

#End Region

    End Class

End Namespace

