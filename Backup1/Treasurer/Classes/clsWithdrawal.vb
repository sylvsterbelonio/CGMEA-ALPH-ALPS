Imports MySql.Data.MySqlClient

Namespace Withdrawal

    Public Class Withdrawal

#Region "Class Withdrawal Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritVoucherNo As String
        Private CritMemberName As String
        Private CritWithdrawnDate As String
        Private CritCapitalAmount As Double
        Private CritCancelFl As Integer

        Private withdrawalId As Integer
        Private memberId As Integer
        Private memberName As String
        Private department As String
        Private receivedBy As String
        Private voucherNo As String
        Private checkNo As String
        Private withdrawnDate As String
        Private tempWithdrawnDate As Date
        Private capitalAmount As Double
        Private interestIncome As Double
        Private netProceeds As Double
        Private withdrawalRemarks As String
        Private cancelFl As Integer

        Private updatedBy As Integer
        Private updatedDt As String
        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private dtRecord As DataTable

#End Region

#Region "Class Withdrawal Public Property Variable Declaration"

        Public WriteOnly Property _initFlag() As Integer
            Set(ByVal Value As Integer)
                If initFlag = Value Then
                    Return
                End If
                initFlag = Value
            End Set
        End Property

        Public WriteOnly Property _dtgRID() As DataTable
            Set(ByVal Value As DataTable)
                dtgRID = Value
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

        Public WriteOnly Property _CritVoucherNo() As String
            Set(ByVal Value As String)
                If CritVoucherNo = Value Then
                    Return
                End If
                CritVoucherNo = Value
            End Set
        End Property

        Public Property _CritWithdrawalDate() As String
            Get
                Return CritWithdrawnDate
            End Get
            Set(ByVal value As String)
                If CritWithdrawnDate = value Then
                    Return
                End If
                CritWithdrawnDate = value
            End Set
        End Property

        Public Property _CritCapitalAmount() As Double
            Get
                Return CritCapitalAmount
            End Get
            Set(ByVal value As Double)
                If CritCapitalAmount = value Then
                    Return
                End If
                CritCapitalAmount = value
            End Set
        End Property

        Public Property _CritCancelFl() As Integer
            Get
                Return CritCancelFl
            End Get
            Set(ByVal value As Integer)
                If CritCancelFl = value Then
                    Return
                End If
                CritCancelFl = value
            End Set
        End Property

        Public Property _withdrawalId() As Integer
            Get
                Return withdrawalId
            End Get
            Set(ByVal value As Integer)
                If withdrawalId = value Then
                    Return
                End If
                withdrawalId = value
            End Set
        End Property

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

        Public ReadOnly Property _memberName() As String
            Get
                Return memberName
            End Get
        End Property

        Public ReadOnly Property _department() As String
            Get
                Return department
            End Get
        End Property

        Public Property _receivedBy() As String
            Get
                Return receivedBy
            End Get
            Set(ByVal value As String)
                If receivedBy = value Then
                    Return
                End If
                receivedBy = value
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

        Public Property _withdrawnDate() As String
            Get
                Return withdrawnDate
            End Get
            Set(ByVal value As String)
                If withdrawnDate = value Then
                    Return
                End If
                withdrawnDate = value
            End Set
        End Property

        Public Property _tempWithdrawnDate() As Date
            Get
                Return tempWithdrawnDate
            End Get
            Set(ByVal value As Date)
                If tempWithdrawnDate = value Then
                    Return
                End If
                tempWithdrawnDate = value
            End Set
        End Property

        Public Property _capitalAmount() As Double
            Get
                Return capitalAmount
            End Get
            Set(ByVal value As Double)
                If capitalAmount = value Then
                    Return
                End If
                capitalAmount = value
            End Set
        End Property


        Public Property _interestIncome() As Double
            Get
                Return interestIncome
            End Get
            Set(ByVal value As Double)
                If interestIncome = value Then
                    Return
                End If
                interestIncome = value
            End Set
        End Property


        Public Property _netProceeds() As Double
            Get
                Return netProceeds
            End Get
            Set(ByVal value As Double)
                If netProceeds = value Then
                    Return
                End If
                netProceeds = value
            End Set
        End Property

        Public Property _withdrawalRemarks() As String
            Get
                Return withdrawalRemarks
            End Get
            Set(ByVal value As String)
                If withdrawalRemarks = value Then
                    Return
                End If
                withdrawalRemarks = value
            End Set
        End Property

        Public ReadOnly Property _cancelFl() As Integer
            Get
                Return cancelFl
            End Get
        End Property

        Public WriteOnly Property _updatedBy() As Integer
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

#End Region

#Region "Class Withdrawal Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                'Build_String_Before_Saving()
                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spWithdrawalSave(" & withdrawalId & "," & memberId & ",'" & receivedBy & "','" & voucherNo & "','" & checkNo & "','" & withdrawnDate & "'," & capitalAmount & "," & interestIncome & "," & netProceeds & ",'" & withdrawalRemarks & "'," & updatedBy & ",'" & updatedDt & "');"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        withdrawalId = dtSaveRow("withdrawalId")
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
                strSql = "CALL spWithdrawalDelete(" & withdrawalId & "," & updatedBy & ");"
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

                    strSql = "CALL spWithdrawalFind(" & withdrawalId & ",'" & CritVoucherNo & "','" & CritMemberName & "'," & CritCapitalAmount & ",'" & CritWithdrawnDate & "'," & CritCancelFl & "," & initFlag & ");"

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

                    strSql = "CALL spWithdrawalFind(" & initFlag & ",'','',0,'',-1,2);"

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
                        Me.withdrawalId = Trim(myRow1("withdrawalId").ToString)
                        Me.receivedBy = Trim(myRow1("receivedBy").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberName = Trim(myRow1("memberName").ToString)
                        Me.department = Trim(myRow1("departmentName").ToString)
                        Me.voucherNo = Trim(myRow1("voucherNo").ToString)
                        Me.checkNo = Trim(myRow1("checkNo").ToString)
                        Me.WithdrawnDate = Trim(myRow1("withdrawDt").ToString)
                        Me.TempWithdrawnDate = Microsoft.VisualBasic.DateValue(myRow1("withdrawDt").ToString)
                        Me.capitalAmount = Trim(myRow1("capitalAmount").ToString)
                        Me.interestIncome = Trim(myRow1("serviceFee").ToString)
                        Me.netProceeds = Trim(myRow1("netProceeds").ToString)
                        Me.withdrawalRemarks = Trim(myRow1("withdrawalRemarks").ToString)
                        Me.cancelFl = Trim(myRow1("cancelFl").ToString)
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

        Public Function GetMemberId(ByVal userId As Integer) As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberIdGet(" & userId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberId = dtRecord.Rows(0)("memberId")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetTotalMemberContribution(ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberContributionTotalGet(" & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetTotalMemberContribution = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        'Public Function GetPaymentORNoList() As DataSet
        '    Dim dataList As DataSet
        '    Dim sqlComboStmt As String

        '    Try
        '        sqlComboStmt = "CALL spPaymentORNoGet();"
        '        dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dataList = Nothing
        '    End Try
        '    Return dataList
        'End Function

        'Public Function GetCollectionTypeList() As DataSet
        '    Dim dataList As DataSet
        '    Dim sqlComboStmt As String

        '    Try
        '        sqlComboStmt = "CALL spCollectionTypeGet();"
        '        dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dataList = Nothing
        '    End Try
        '    Return dataList
        'End Function

        'Public Function GetCollectionFeeDefault(ByVal pId As Integer) As Double
        '    Dim sqlStmt As String

        '    Try
        '        sqlStmt = "CALL spCollectionFeeDefaultGet(" & pId & ");"
        '        dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

        '        GetCollectionFeeDefault = dtRecord.Rows(0)("feeDefault")
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        Return Nothing
        '    Catch err As Exception
        '        Throw err
        '    End Try
        'End Function

        'Public Function GetBankNameList() As DataSet
        '    Dim dataList As DataSet
        '    Dim sqlComboStmt As String

        '    Try
        '        sqlComboStmt = "CALL spBankGet();"
        '        dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dataList = Nothing
        '    End Try
        '    Return dataList
        'End Function

        'Public Function Populate_Payment_Memo_Detail() As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spPaymentMemoDetailFind(" & paymentId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Payment_Check_Detail() As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spPaymentCheckDetailFind(" & paymentId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Payment_Billing_Detail() As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spPaymentBillingDetailFind(" & paymentId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Fees_Billing_Records_Member(ByVal id As Integer) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spFeesBillingRecordsMemberFind(" & id & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Fees_Billing_Records(ByVal id As Integer, ByVal bdate As Date) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spFeesBillingRecordsFind(" & id & ",'" & bdate.ToString("yyyy-MM-dd") & "');"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Loan_Billing_Records(ByVal id As Integer, ByVal bdate As Date) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spLoanBillingRecordsFind(" & id & ",'" & bdate.ToString("yyyy-MM-dd") & "');"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Collection_Billing_Records(ByVal id As Integer, ByVal bdate As Date) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spCollectionBillingRecordsFind(" & id & ",'" & bdate.ToString("yyyy-MM-dd") & "');"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Loan_Billing_MemberId(ByVal id As Integer) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spLoanBillingMemberIdFind(" & id & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function GetMemberFeesBillingRecordsCount(ByVal id As Integer, ByVal paidFl As Integer) As Integer
        '    Dim sqlStmt As String

        '    Try
        '        sqlStmt = "CALL spFeesBillingRecordsMemberCountGet(" & id & "," & paidFl & ");"
        '        dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

        '        GetMemberFeesBillingRecordsCount = dtRecord.Rows(0)(0)
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        Return Nothing
        '    Catch err As Exception
        '        Throw err
        '    End Try
        'End Function

        'Public Function Populate_Payment_Report(ByVal pId As Integer) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spORDetailReport(" & pId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Payment_Check_Detail_Report(ByVal pId As Integer) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spORCheckDetailReport(" & pId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Payment_Memo_Detail_Report(ByVal pId As Integer) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spORMemoDetailReport(" & pId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Payment_AF51_Detail_Report(ByVal pId As Integer) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spORAF51DetailReport(" & pId & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function System_User_Report() As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spReportSystemUserFind(" & gUserID & ");"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

        'Public Function Populate_Official_Receipts_Issued_List_Report(ByVal conDt As String, ByVal conType As String) As DataTable
        '    Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        '    Dim strSql As String
        '    Dim dtListView As DataTable
        '    Try
        '        With clsDataAccess
        '            dtListView = New DataTable
        '            strSql = "CALL spORIssuedListReport('" & conDt & "','" & conType & "');"

        '            dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
        '        End With
        '    Catch ex As MySqlException
        '        RaiseEvent MsgArrival(ex.Message, False)
        '        dtListView = Nothing
        '    End Try
        '    Return dtListView
        'End Function

#End Region

#Region "Class Payment Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritVoucherNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritVoucherNo))
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                CritWithdrawnDate = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritWithdrawnDate))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                WithdrawnDate = TempWithdrawnDate.ToString("yyyy-MM-dd")

                VoucherNo = .ReplaceSingleQuotes(VoucherNo)
                WithdrawnDate = .ReplaceSingleQuotes(WithdrawnDate)
                withdrawalRemarks = .ReplaceSingleQuotes(withdrawalRemarks)
            End With
        End Sub

#End Region

    End Class

End Namespace

