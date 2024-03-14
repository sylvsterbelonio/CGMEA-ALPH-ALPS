Imports System.IO
Imports MySql.Data.MySqlClient
Namespace LoanPaymentUpdater

    Public Class LoanPaymentUpdater

#Region "Class Loan Payment Updater Variable Declaration"

        Private memberId As Integer
        Private loanId As Integer
        Private loanTypeId As Integer
        Private loanPaymentDt As String
        Private tempLoanPaymentDt As Date
        Private loanPaymentAmount As Double

        Private memberNo As String
        Private memberName As String
        Private typeList As String

        Private updatedBy As Integer
        Private updatedDt As String

        Private referenceId3 As Integer

        Dim clsMemberLoanPaymentDetails = New MemberLoanPaymentDetails.MemberLoanPaymentDetails
        Dim strMemberLoanPaymentUpdaterDetail As String
        Private colMemberLoanPaymentUpdaterDetail As New Collection

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private FileSize As UInt32
        Private rawData() As Byte
        Private fs As FileStream


        Private dtRecord As DataTable

#End Region

#Region "Class Loan Payment Updater Public Property Variable Declaration"

        Public Property _memberId() As Integer
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

        Public Property _loanTypeId() As Integer
            Get
                Return loanTypeId
            End Get
            Set(ByVal value As Integer)
                If loanTypeId = value Then
                    Return
                End If
                loanTypeId = value
            End Set
        End Property

        Public Property _loanPaymentDt() As String
            Get
                Return loanPaymentDt
            End Get
            Set(ByVal Value As String)
                If loanPaymentDt = Value Then
                    Return
                End If
                loanPaymentDt = Value
            End Set
        End Property

        Public Property _tempLoanPaymentDt() As Date
            Get
                Return tempLoanPaymentDt
            End Get
            Set(ByVal value As Date)
                If tempLoanPaymentDt = value Then
                    Return
                End If
                tempLoanPaymentDt = value
            End Set
        End Property

        Public Property _loanPaymentAmount() As Double
            Get
                Return loanPaymentAmount
            End Get
            Set(ByVal Value As Double)
                If loanPaymentAmount = Value Then
                    Return
                End If
                loanPaymentAmount = Value
            End Set
        End Property

        Public Property _updatedBy() As Integer
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

        Public Property _updatedDt() As String
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

        Public Property _referenceId3() As Integer
            Get
                Return referenceId3
            End Get
            Set(ByVal Value As Integer)
                If referenceId3 = Value Then
                    Return
                End If
                referenceId3 = Value
            End Set
        End Property

        Public Property _memberNo() As String
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

        Public Property _typeList() As String
            Get
                Return typeList
            End Get
            Set(ByVal value As String)
                If typeList = value Then
                    Return
                End If
                typeList = value
            End Set
        End Property


#End Region

#Region "Class Loan Payment Updater Public Functions"

        Public Function Save_Member_Loan_Payment_Record(ByVal lId As Integer, ByVal fId As Integer, ByVal cDt As String, ByVal cAmt As Double, ByVal ref3 As Integer, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildUpdater_String_Before_Saving()
                'Clean_Parameters_Save()

                Save_Member_Loan_Payment_Record = True
                strSql = "CALL spMemberLoanPaymentUpdaterSave(" & lId & _
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
                Save_Member_Loan_Payment_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_Interest_Payment_Record(ByVal lId As Integer, ByVal fId As Integer, ByVal cDt As String, ByVal cAmt As Double, ByVal ref3 As Integer, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildUpdater_String_Before_Saving()
                'Clean_Parameters_Save()

                Save_Member_Loan_Interest_Payment_Record = True
                strSql = "CALL spMemberLoanInterestPaymentUpdaterSave(" & lId & _
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
                Save_Member_Loan_Interest_Payment_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_Principal_Record(ByVal lId As Integer, ByVal cAmt As Double, ByVal dt As String, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildUpdater_String_Before_Saving()
                'Clean_Parameters_Save()

                Save_Member_Loan_Principal_Record = True
                strSql = "CALL spMemberLoanPrincipalUpdaterSave(" & lId & _
                ",'" & cAmt & "','" & dt & "'," & gUser & ");"

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
                Save_Member_Loan_Principal_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_Balance_Record(ByVal lId As Integer, ByVal cAmt As Double, ByVal dt As String, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                BuildUpdater_String_Before_Saving()
                'Clean_Parameters_Save()

                Save_Member_Loan_Balance_Record = True
                strSql = "CALL spMemberLoanBalanceUpdaterSave(" & lId & _
                ",'" & cAmt & "','" & dt & "'," & gUser & ");"

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
                Save_Member_Loan_Balance_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_Monthly_Payment_Record(ByVal lId As Integer, ByVal cAmt As Double, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Loan_Monthly_Payment_Record = True
                strSql = "CALL spMemberLoanMonthlyPaymentUpdaterSave(" & lId & _
                ",'" & cAmt & "'," & gUser & ");"

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
                Save_Member_Loan_Monthly_Payment_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_Date_Record(ByVal lId As Integer, ByVal lDt As String, ByVal lType As Integer, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Loan_Date_Record = True
                strSql = "CALL spMemberLoanDateUpdaterSave(" & lId & _
                ",'" & lDt & "'," & lType & "," & gUser & ");"

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
                Save_Member_Loan_Date_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_Term_Record(ByVal lId As Integer, ByVal lTerm As Integer, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Loan_Term_Record = True
                strSql = "CALL spMemberLoanTermUpdaterSave(" & lId & _
                ",'" & lTerm & "'," & gUser & ");"

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
                Save_Member_Loan_Term_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_VoucherNo_Record(ByVal lId As Integer, ByVal vNo As String, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Loan_VoucherNo_Record = True
                strSql = "CALL spMemberLoanVoucherAndCheckUpdaterSave(" & lId & _
               ",'" & vNo & "'," & gUser & ",1);"

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
                Save_Member_Loan_VoucherNo_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_CheckNo_Record(ByVal lId As Integer, ByVal cNo As Integer, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Loan_CheckNo_Record = True
                strSql = "CALL spMemberLoanVoucherAndCheckUpdaterSave(" & lId & _
               ",'" & cNo & "'," & gUser & ",2);"

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
                Save_Member_Loan_CheckNo_Record = False
            End Try
        End Function

        Public Function Close_Member_Loan_Record(ByVal lId As Integer, ByVal cNo As Integer, ByVal cDt As String, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Close_Member_Loan_Record = True
                strSql = "CALL spMemberLoanClosedSave(" & lId & ",'" & cNo & "','" & cDt & "'," & gUser & ",0);"

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
                Close_Member_Loan_Record = False
            End Try
        End Function

        Public Function Save_Member_Loan_CloseDate_Record(ByVal lId As Integer, ByVal cDt As String, ByVal gUser As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Loan_CloseDate_Record = True
                strSql = "CALL spMemberLoanClosedSave(" & lId & ",'1','" & cDt & "'," & gUser & ",1);"

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
                Save_Member_Loan_CloseDate_Record = False
            End Try
        End Function

        Public Function Populate_Loan_Payment_List_Record(ByVal paymentDt As String, ByVal memNo As String, ByVal memName As String, ByVal typeId As String, ByVal closeFl As Integer, ByVal ref3 As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanPaymentListFind('" & paymentDt & "','" & memNo & "','" & memName & "','" & typeId & "'," & closeFl & "," & ref3 & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Billing_Report(ByVal paymentDt As String, ByVal memNo As String, ByVal memName As String, ByVal typeId As String, ByVal closeFl As Integer, ByVal ref3 As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanBillingReport('" & paymentDt & "','" & memNo & "','" & memName & "','" & typeId & "'," & closeFl & "," & ref3 & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Billing_Record(ByVal paymentDt As String, ByVal ref3 As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanPaymentListFind('" & paymentDt & "','','','',1," & ref3 & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Save_Generated_Loan_Payment_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Generated_Loan_Payment_Record = True
                strSql = "CALL spMemberLoanPaymentGeneratedSave('" & memberNo & "','" & memberName & "','" & typeList & "','" & referenceId3 & "','" & loanPaymentDt & "'," & updatedBy & ");"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    If ErrorMsg = "No records generated." Then
                        clsCommon.Prompt_User("information", ErrorMsg & " Please try again.")
                    Else
                        clsCommon.Prompt_User("error", ErrorMsg)
                    End If
                    Return False
                Else
                    Return True
                End If
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Generated_Loan_Payment_Record = False
            End Try
        End Function

        Public Function Save_Generated_Special_Loan_Payment_Record(ByVal typeId As Integer) As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Generated_Special_Loan_Payment_Record = True
                strSql = "CALL spMemberSpecialLoanPaymentGeneratedSave('" & loanPaymentDt & "','" & typeId & "'," & updatedBy & ");"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    If ErrorMsg = "No records generated." Then
                        clsCommon.Prompt_User("information", ErrorMsg & " Please try again.")
                    Else
                        clsCommon.Prompt_User("error", ErrorMsg)
                    End If
                    Return False
                Else
                    Return True
                End If
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Generated_Special_Loan_Payment_Record = False
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

        Private Sub Clean_Parameters_Save()
            With clsCommon
                loanPaymentDt = tempLoanPaymentDt.ToString("yyyy-MM-dd")

            End With
        End Sub

        Private Sub BuildUpdater_String_Before_Saving()
            Dim MemberLoanPaymentUpdater As MemberLoanPaymentDetails.MemberLoanPaymentDetails
            strMemberLoanPaymentUpdaterDetail = ""

            If IsNothing(colMemberLoanPaymentUpdaterDetail) = False Then
                For Each MemberLoanPaymentUpdater In colMemberLoanPaymentUpdaterDetail
                    strMemberLoanPaymentUpdaterDetail += CInt(MemberLoanPaymentUpdater._memberId) _
                            & "|" & CStr(MemberLoanPaymentUpdater._loanId) _
                            & "|" & CDbl(MemberLoanPaymentUpdater._loanTypeId) _
                            & "|" & CDbl(MemberLoanPaymentUpdater._loanPaymentDt) _
                            & "|" & CDbl(MemberLoanPaymentUpdater._loanPaymentAmount) & "|"
                Next
            End If
        End Sub

        Public Function GetMemberBalanceAmountTotal(ByVal lId As Integer, ByVal memId As Integer) As Double
            Dim sqlStmt As String
            GetMemberBalanceAmountTotal = 0
            Try
                sqlStmt = "CALL spMemberBalanceAmountTotalGet(" & lId & "," & memId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberBalanceAmountTotal = dtRecord.Rows(0)("balanceAmount")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetMemberLoanMaturityDate(ByVal lId As Integer, ByVal memId As Integer) As String
            Dim sqlStmt As String
            GetMemberLoanMaturityDate = 0
            Try
                sqlStmt = "CALL spMemberLoanMaturityDateGet(" & lId & "," & memId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberLoanMaturityDate = dtRecord.Rows(0)("maturityDt")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetMemberLoanTerm(ByVal lId As Integer, ByVal memId As Integer) As Integer
            Dim sqlStmt As String
            GetMemberLoanTerm = 0
            Try
                sqlStmt = "CALL spMemberLoanTermGet(" & lId & "," & memId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberLoanTerm = dtRecord.Rows(0)("loanTerm")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Populate_Loan_Billing_List_Record(ByVal paymentDt As String, ByVal ref3 As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanBillingFind('" & paymentDt & "'," & ref3 & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function
#End Region

    End Class

End Namespace

