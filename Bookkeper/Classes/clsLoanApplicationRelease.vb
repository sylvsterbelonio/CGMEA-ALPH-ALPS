Imports System.IO
Imports MySql.Data.MySqlClient

Namespace LoanApplicationRelease

    Public Class LoanApplicationRelease

#Region "Class Loan Application Release Variable Declaration"
        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritLoanNo As String
        Private CritTypeId As String
        Private CritMemberName As String
        Private CritMemberNo As String
        Private CritLoanDt As String
        Private CritLoanStatus As String

        Private releasedId As Integer
        Private loanId As Integer
        Private loanNo As Integer
        Private memberName As String
        Private departmentName As String
        Private loanType As String

        Private voucherNo As String
        Private checkNo As String

        Private releasedFl As Integer
        Private releasedDt As String
        Private tempreleasedDt As Date
        Private principalAmount As Double
        Private releasedRemarks As String
        Private releasedBy As Integer

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private dtRecord As DataTable

#End Region

#Region "Class Loan Application Release Public Property Variable Declaration"

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

        Public WriteOnly Property _CritLoanNo() As String
            Set(ByVal Value As String)
                If CritLoanNo = Value Then
                    Return
                End If
                CritLoanNo = Value
            End Set
        End Property

        Public WriteOnly Property _CritTypeId() As String
            Set(ByVal Value As String)
                If CritTypeId = Value Then
                    Return
                End If
                CritTypeId = Value
            End Set
        End Property

        Public WriteOnly Property _CritMemberName() As String
            Set(ByVal Value As String)
                If CritMemberName = Value Then
                    Return
                End If
                CritMemberName = Value
            End Set
        End Property

        Public WriteOnly Property _CritMemberNo() As String
            Set(ByVal Value As String)
                If CritMemberNo = Value Then
                    Return
                End If
                CritMemberNo = Value
            End Set
        End Property

        Public WriteOnly Property _CritLoanDt() As String
            Set(ByVal Value As String)
                If CritLoanDt = Value Then
                    Return
                End If
                CritLoanDt = Value
            End Set
        End Property

        Public WriteOnly Property _CritLoanStatus() As String
            Set(ByVal Value As String)
                If CritLoanStatus = Value Then
                    Return
                End If
                CritLoanStatus = Value
            End Set
        End Property

        Public Property _releasedId() As Integer
            Get
                Return releasedId
            End Get
            Set(ByVal value As Integer)
                If releasedId = value Then
                    Return
                End If
                releasedId = value
            End Set
        End Property

        Public Property _loanId() As Integer
            Get
                Return loanId
            End Get
            Set(ByVal value As Integer)
                If loanId = value Then
                    Return
                End If
                loanId = value
            End Set
        End Property

        Public Property _loanNo() As Integer
            Get
                Return loanNo
            End Get
            Set(ByVal value As Integer)
                If loanNo = value Then
                    Return
                End If
                loanNo = value
            End Set
        End Property

        Public Property _memberName() As String
            Get
                Return memberName
            End Get
            Set(ByVal value As String)
                If memberName = value Then
                    Return
                End If
                memberName = value
            End Set
        End Property

        Public Property _departmentName() As String
            Get
                Return departmentName
            End Get
            Set(ByVal value As String)
                If departmentName = value Then
                    Return
                End If
                departmentName = value
            End Set
        End Property

        Public Property _loanType() As String
            Get
                Return loanType
            End Get
            Set(ByVal value As String)
                If loanType = value Then
                    Return
                End If
                loanType = value
            End Set
        End Property

        Public Property _principalAmount() As Double
            Get
                Return principalAmount
            End Get
            Set(ByVal value As Double)
                If principalAmount = value Then
                    Return
                End If
                principalAmount = value
            End Set
        End Property

        Public Property _voucherNo() As String
            Get
                Return voucherNo
            End Get
            Set(ByVal value As String)
                If voucherNo = value Then
                    Return
                End If
                voucherNo = value
            End Set
        End Property

        Public Property _checkNo() As String
            Get
                Return checkNo
            End Get
            Set(ByVal value As String)
                If checkNo = value Then
                    Return
                End If
                checkNo = value
            End Set
        End Property

        Public Property _releasedFl() As Integer
            Get
                Return ReleasedFl
            End Get
            Set(ByVal Value As Integer)
                If releasedFl = Value Then
                    Return
                End If
                releasedFl = Value
            End Set
        End Property

        Public Property _releasedDt() As String
            Get
                Return releasedDt
            End Get
            Set(ByVal Value As String)
                If releasedDt = Value Then
                    Return
                End If
                releasedDt = Value
            End Set
        End Property

        Public Property _tempreleasedDt() As Date
            Get
                Return tempreleasedDt
            End Get
            Set(ByVal Value As Date)
                If tempreleasedDt = Value Then
                    Return
                End If
                tempreleasedDt = Value
            End Set
        End Property

        Public Property _releasedRemarks() As String
            Get
                Return releasedRemarks
            End Get
            Set(ByVal value As String)
                If releasedRemarks = value Then
                    Return
                End If
                releasedRemarks = value
            End Set
        End Property

        Public Property _releasedBy() As Integer
            Get
                Return releasedBy
            End Get
            Set(ByVal value As Integer)
                If releasedBy = value Then
                    Return
                End If
                releasedBy = value
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

#Region "Class Loan Application Release Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spLoanApplicationReleaseSave(" & releasedId & "," & loanId & ",'" & voucherNo & "','" & checkNo & "'," & releasedFl & ",'" & releasedDt & "','" & releasedRemarks & "'," & releasedBy & "," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        releasedId = Me.dtSaveRow("releasedId")
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
                strSql = "CALL spLoanApplicationReleaseDelete(" & releasedId & "," & updatedBy & ");"
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

                    strSql = "CALL spLoanApplicationReleaseFind(" & releasedId & ",'" & CritLoanNo & "','" & CritTypeId & "','" & _
                    CritMemberName & "','" & CritMemberNo & "','" & CritLoanDt & "','" & CritLoanStatus & "'," & initFlag & ");"

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

                    strSql = "CALL spLoanApplicationReleaseFind(" & initFlag & ",'','','','','','',2);"

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
                        Me.releasedId = Trim(myRow1("releasedId").ToString)
                        Me.loanId = Trim(myRow1("loanId").ToString)
                        Me.loanNo = Trim(myRow1("loanNo").ToString)
                        Me.memberName = Trim(myRow1("memberName").ToString)
                        Me.departmentName = Trim(myRow1("departmentName").ToString)
                        Me.loanType = Trim(myRow1("loanType").ToString)
                        Me.principalAmount = Trim(myRow1("principalAmount").ToString)
                        Me.voucherNo = Trim(myRow1("voucherNo").ToString)
                        Me.checkNo = Trim(myRow1("checkNo").ToString)
                        Me.releasedFl = Trim(myRow1("releasedFl").ToString)
                        Me.releasedDt = Trim(myRow1("releasedDt").ToString)
                        Me.releasedRemarks = Trim(myRow1("releasedRemarks").ToString)
                        Me.releasedBy = Trim(myRow1("releasedBy").ToString)
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

        Public Function GetLoanTypeList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spLoanTypeGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetSignatory() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSignatoryGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
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

        Public Function Populate_Loan_Record() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationReleaseFind(" & releasedId & ",'" & CritLoanNo & "','" & CritTypeId & "','" & _
                  CritMemberName & "','" & CritMemberNo & "','" & CritLoanDt & "','" & CritLoanStatus & "'," & initFlag & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function


        Public Function Populate_Checks_Issued_List_Report(ByVal conDt As String, ByVal conType As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spChecksIssuedListReport('" & conDt & "','" & conType & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_For_Approval_List_Report(ByVal conDt As String, ByVal conType As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanForApprovalListReport('" & conDt & "','" & conType & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Released_List_Report(ByVal conDt As String, ByVal conType As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanReleasedListReport('" & conDt & "','" & conType & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function


#End Region

#Region "Class Loan Application Release Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                loanType = .ReplaceSingleQuotes(loanType)
                voucherNo = .ReplaceSingleQuotes(voucherNo)
                checkNo = .ReplaceSingleQuotes(checkNo)
                releasedRemarks = .ReplaceSingleQuotes(releasedRemarks)
                releasedBy = .ReplaceSingleQuotes(releasedBy)
                releasedDt = tempreleasedDt.ToString("yyyy-MM-dd")
            End With
        End Sub

#End Region

    End Class

End Namespace
