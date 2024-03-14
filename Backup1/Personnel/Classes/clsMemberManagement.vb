Imports System.IO
Imports MySql.Data.MySqlClient

Namespace MemberManagement

    Public Class MemberManagement

#Region "Class MemberManagement Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritMemberNo As String
        Private CritMemberName As String
        Private CritLGUName As String
        Private CritDepartmentName As String
        Private CritManagementStatus As Integer

        Private managementId As Integer
        Private memberId As Integer
        Private managementStatus As Integer
        Private toDepartmentId As Integer
        Private toDesignation As String
        Private toAppointmentStatus As String
        Private forMemberId As Integer
        Private managementDtFl As Integer
        Private managementDt As String
        Private tempManagementDt As Date
        Private managementRemarks As String
        Private retireFl As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class MemberManagement Public Property Variable Declaration"

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

        Public WriteOnly Property CritLGU_Name() As String
            Set(ByVal Value As String)
                If CritLGUName = Value Then
                    Return
                End If
                CritLGUName = Value
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

        Public WriteOnly Property CritManagement_Status() As String
            Set(ByVal Value As String)
                If CritManagementStatus = Value Then
                    Return
                End If
                CritManagementStatus = Value
            End Set
        End Property

        Public Property Management_Id() As Integer
            Get
                Return managementId
            End Get
            Set(ByVal value As Integer)
                If managementId = value Then
                    Return
                End If
                managementId = value
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

        Public Property Management_Status() As Integer
            Get
                Return managementStatus
            End Get
            Set(ByVal value As Integer)
                If managementStatus = value Then
                    Return
                End If
                managementStatus = value
            End Set
        End Property

        Public Property ToDepartment_Id() As Integer
            Get
                Return toDepartmentId
            End Get
            Set(ByVal value As Integer)
                If toDepartmentId = value Then
                    Return
                End If
                toDepartmentId = value
            End Set
        End Property

        Public Property To_Designation() As String
            Get
                Return toDesignation
            End Get
            Set(ByVal value As String)
                If toDesignation = value Then
                    Return
                End If
                toDesignation = value
            End Set
        End Property

        Public Property ToAppointment_Status() As String
            Get
                Return toAppointmentStatus
            End Get
            Set(ByVal value As String)
                If toAppointmentStatus = value Then
                    Return
                End If
                toAppointmentStatus = value
            End Set
        End Property

        Public Property ForMember_Id() As Integer
            Get
                Return forMemberId
            End Get
            Set(ByVal value As Integer)
                If forMemberId = value Then
                    Return
                End If
                forMemberId = value
            End Set
        End Property

        Public Property ManagementDt_Fl() As Integer
            Get
                Return managementDtFl
            End Get
            Set(ByVal value As Integer)
                If managementDtFl = value Then
                    Return
                End If
                managementDtFl = value
            End Set
        End Property

        Public Property Management_Dt() As String
            Get
                Return managementDt
            End Get
            Set(ByVal value As String)
                If managementDt = value Then
                    Return
                End If
                managementDt = value
            End Set
        End Property

        Public Property TempManagement_Dt() As Date
            Get
                Return tempManagementDt
            End Get
            Set(ByVal value As Date)
                If tempManagementDt = value Then
                    Return
                End If
                tempManagementDt = value
            End Set
        End Property

        Public Property Management_Remarks() As String
            Get
                Return managementRemarks
            End Get
            Set(ByVal value As String)
                If managementRemarks = value Then
                    Return
                End If
                managementRemarks = value
            End Set
        End Property

        Public Property Retire_Fl() As String
            Get
                Return retireFl
            End Get
            Set(ByVal value As String)
                If retireFl = value Then
                    Return
                End If
                retireFl = value
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

#Region "Class MemberManagement Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()


                Save_Record = True

                strSql = "CALL spMemberManagementSave(" & managementId & "," & memberId & "," & managementStatus & "," & toDepartmentId & ",'" & toDesignation & "','" & toAppointmentStatus & "'," & forMemberId & ",'" & retireFl & "'," & managementDtFl & ",'" & managementDt & "','" & managementRemarks & "'," & updatedBy & ",'" & updatedDt & "');"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                Dim dtSaveRow As DataRow
                For Each dtSaveRow In dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each dtSaveRow In dtSave.Rows
                        managementId = dtSaveRow("managementId")
                        updatedDt = dtSaveRow("updatedDt")
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
                strSql = "CALL spMemberManagementDelete(" & managementId & "," & managementStatus & "," & updatedBy & ");"
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

                    strSql = "CALL spMemberManagementFind(" & managementId & ",'" & CritMemberNo & "','" & CritMemberName & "','" _
                    & CritLGUName & "','" & CritDepartmentName & "'," & CritManagementStatus & "," & initFlag & ");"

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

                    strSql = "CALL spMemberManagementFind(" & initFlag & ",'','','','',-1,2);"

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
                        Me.managementId = Trim(myRow1("managementId").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.managementStatus = Trim(myRow1("managementStatus").ToString)
                        Me.toDepartmentId = Trim(myRow1("toDepartmentId").ToString)
                        Me.toDesignation = Trim(myRow1("toDesignation").ToString)
                        Me.toAppointmentStatus = Trim(myRow1("toAppointmentStatus").ToString)
                        Me.forMemberId = Trim(myRow1("forMemberId").ToString)
                        Me.retireFl = Trim(myRow1("retireFl").ToString)
                        Me.managementDtFl = Trim(myRow1("managementDtFl").ToString)
                        Me.managementDt = Trim(myRow1("managementDt").ToString)
                        Me.tempManagementDt = Microsoft.VisualBasic.DateValue(myRow1("managementDt").ToString)
                        Me.managementRemarks = Trim(myRow1("managementRemarks").ToString)

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

        Public Function GetDefaultChoices(ByVal paramName As String) As DataTable
            Dim dataList As DataTable
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spDefaultParameterChoicesGet('" & paramName & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATATABLE)
                Return dataList
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

#End Region

#Region "Class MemberManagement Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                CritLGUName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLGUName))
                CritDepartmentName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentName))
                CritMemberNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberNo))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                managementDt = tempManagementDt.ToString("yyyy-MM-dd")

                managementDt = .ReplaceSingleQuotes(managementDt)
                toDesignation = .ReplaceSingleQuotes(toDesignation)
                toAppointmentStatus = .ReplaceSingleQuotes(toAppointmentStatus)
                managementRemarks = .ReplaceSingleQuotes(managementRemarks)
            End With
        End Sub

#End Region

    End Class

End Namespace
