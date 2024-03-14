Imports MySql.Data.MySqlClient

Namespace Payment

    Public Class Payment

#Region "Class Payment Variable Declaration"

        Private initFlag As Integer
        Private amountDueDt As String
        Private amountDueDtFl As Integer
        Private dtgRID As DataTable

        Private CritORNo As String
        Private CritMemberName As String
        Private CritORDate As String
        Private dateType As Integer
        Private CritORAmount As Double
        Private CritORAmountTo As Double
        Private CritCancelFl As Integer
        Private CritReferenceId As Integer

        Private paymentId As Integer
        Private memberId As Integer
        Private memberName As String
        Private ORNo As String
        Private ORDate As String
        Private TempORDate As Date
        Private ORAmount As Double
        Private cashAmount As Double
        Private checkAmount As Double
        Private creditAmount As Double
        Private paymentRemarks As String
        Private cancelFl As Integer
        Private deleteFl As Integer
        Private onlineFl As Integer
        Private paymentFl As Integer
        Private billingFl As Integer
        Private creditFl As Integer
        Private referenceId As Integer

        Private dueDate As String
        Private refId3 As Integer

        Private updatedBy As Integer
        Private updatedDt As String

        Dim clsPaymentCheckDetail As New PaymentCheck
        Dim strPaymentCheckDetail As String
        Private colPaymentCheckDetail As New Microsoft.VisualBasic.Collection

        Dim clsPaymentBillingDetail As New PaymentDetail
        Dim strPaymentBillingDetail As String
        Private colPaymentBillingDetail As New Microsoft.VisualBasic.Collection

        'Loan Payment
        Dim clsPaymentLoanBillingDetail As New PaymentDetail
        Dim strPaymentLoanBillingDetail As String
        Private colPaymentLoanBillingDetail As New Microsoft.VisualBasic.Collection
        'Contribution payment
        Dim clsPaymentContributionBillingDetail As New PaymentDetail
        Dim strPaymentContributionBillingDetail As String
        Private colPaymentContributionBillingDetail As New Microsoft.VisualBasic.Collection

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private dtRecord As DataTable

#End Region

#Region "Class Payment Public Property Variable Declaration"

        Public WriteOnly Property Init_Flag() As Integer
            Set(ByVal Value As Integer)
                If initFlag = Value Then
                    Return
                End If
                initFlag = Value
            End Set
        End Property

        Public WriteOnly Property AmountDue_Dt() As String
            Set(ByVal value As String)
                If amountDueDt = value Then
                    Return
                End If
                amountDueDt = value
            End Set
        End Property

        Public WriteOnly Property AmountDueDt_Fl() As Integer
            Set(ByVal value As Integer)
                If amountDueDtFl = value Then
                    Return
                End If
                amountDueDtFl = value
            End Set
        End Property

        Public WriteOnly Property Dt_gRID() As DataTable
            Set(ByVal Value As DataTable)
                dtgRID = Value
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

        Public WriteOnly Property CritOR_No() As String
            Set(ByVal Value As String)
                If CritORNo = Value Then
                    Return
                End If
                CritORNo = Value
            End Set
        End Property

        Public Property CritOR_Dt() As String
            Get
                Return CritORDate
            End Get
            Set(ByVal value As String)
                If CritORDate = value Then
                    Return
                End If
                CritORDate = value
            End Set
        End Property

        Public Property Date_Type() As Integer
            Get
                Return dateType
            End Get
            Set(ByVal value As Integer)
                If dateType = value Then
                    Return
                End If
                dateType = value
            End Set
        End Property

        Public Property CritOR_Amount() As Double
            Get
                Return CritORAmount
            End Get
            Set(ByVal value As Double)
                If CritORAmount = value Then
                    Return
                End If
                CritORAmount = value
            End Set
        End Property

        Public Property CritOR_AmountTo() As Double
            Get
                Return CritORAmountTo
            End Get
            Set(ByVal value As Double)
                If CritORAmountTo = value Then
                    Return
                End If
                CritORAmountTo = value
            End Set
        End Property

        Public Property CritCancel_Fl() As Integer
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

        Public Property CritReference_Id() As Integer
            Get
                Return CritReferenceId
            End Get
            Set(ByVal value As Integer)
                If CritReferenceId = value Then
                    Return
                End If
                CritReferenceId = value
            End Set
        End Property

        Public Property _dueDate() As String
            Get
                Return dueDate
            End Get
            Set(ByVal value As String)
                If dueDate = value Then
                    Return
                End If
                dueDate = value
            End Set
        End Property

        Public Property _refId3() As Integer
            Get
                Return refId3
            End Get
            Set(ByVal value As Integer)
                If refId3 = value Then
                    Return
                End If
                refId3 = value
            End Set
        End Property

        Public Property Payment_Id() As Integer
            Get
                Return paymentId
            End Get
            Set(ByVal value As Integer)
                If paymentId = value Then
                    Return
                End If
                paymentId = value
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

        Public ReadOnly Property Member_Name() As String
            Get
                Return memberName
            End Get
        End Property

        Public Property OR_No() As String
            Get
                Return ORNo
            End Get
            Set(ByVal value As String)
                If ORNo = value Then
                    Return
                End If
                ORNo = value
            End Set
        End Property

        Public Property OR_Dt() As String
            Get
                Return ORDate
            End Get
            Set(ByVal value As String)
                If ORDate = value Then
                    Return
                End If
                ORDate = value
            End Set
        End Property

        Public Property TempOR_Dt() As Date
            Get
                Return TempORDate
            End Get
            Set(ByVal value As Date)
                If TempORDate = value Then
                    Return
                End If
                TempORDate = value
            End Set
        End Property

        Public Property OR_Amount() As Double
            Get
                Return ORAmount
            End Get
            Set(ByVal value As Double)
                If ORAmount = value Then
                    Return
                End If
                ORAmount = value
            End Set
        End Property

        Public Property Cash_Amount() As Double
            Get
                Return cashAmount
            End Get
            Set(ByVal value As Double)
                If cashAmount = value Then
                    Return
                End If
                cashAmount = value
            End Set
        End Property

        Public Property Check_Amount() As Double
            Get
                Return checkAmount
            End Get
            Set(ByVal value As Double)
                If checkAmount = value Then
                    Return
                End If
                checkAmount = value
            End Set
        End Property

        Public Property Credit_Amount() As Double
            Get
                Return creditAmount
            End Get
            Set(ByVal value As Double)
                If creditAmount = value Then
                    Return
                End If
                creditAmount = value
            End Set
        End Property

        Public Property Payment_Remarks() As String
            Get
                Return paymentRemarks
            End Get
            Set(ByVal value As String)
                If paymentRemarks = value Then
                    Return
                End If
                paymentRemarks = value
            End Set
        End Property

        Public Property payment_Fl() As Integer
            Get
                Return paymentFl
            End Get
            Set(ByVal value As Integer)
                If paymentFl = value Then
                    Return
                End If
                paymentFl = value
            End Set
        End Property

        Public Property billing_Fl() As Integer
            Get
                Return billingFl
            End Get
            Set(ByVal value As Integer)
                If billingFl = value Then
                    Return
                End If
                billingFl = value
            End Set
        End Property

        Public Property credit_Fl() As Integer
            Get
                Return creditFl
            End Get
            Set(ByVal value As Integer)
                If creditFl = value Then
                    Return
                End If
                creditFl = value
            End Set
        End Property

        Public Property reference_Id() As Integer
            Get
                Return referenceId
            End Get
            Set(ByVal value As Integer)
                If referenceId = value Then
                    Return
                End If
                referenceId = value
            End Set
        End Property

        Public ReadOnly Property Cancel_Fl() As Integer
            Get
                Return cancelFl
            End Get
        End Property

        Public ReadOnly Property Delete_Fl() As Integer
            Get
                Return deleteFl
            End Get
        End Property

        Public ReadOnly Property Online_Fl() As Integer
            Get
                Return onlineFl
            End Get
        End Property

        Public Property colPaymentCheck_Detail() As Microsoft.VisualBasic.Collection
            Get
                Return colPaymentCheckDetail
            End Get
            Set(ByVal Value As Microsoft.VisualBasic.Collection)
                If colPaymentCheckDetail Is Value Then
                    Return
                End If
                colPaymentCheckDetail = Value
            End Set
        End Property

        Public Property colPaymentBilling_Detail() As Microsoft.VisualBasic.Collection
            Get
                Return colPaymentBillingDetail
            End Get
            Set(ByVal Value As Microsoft.VisualBasic.Collection)
                If colPaymentBillingDetail Is Value Then
                    Return
                End If
                colPaymentBillingDetail = Value
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

#Region "Class Payment Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Build_String_Before_Saving()
                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spPaymentSave(" & paymentId & "," & memberId & ",'" & ORNo & "','" & ORDate & "'," & ORAmount & "," & cashAmount & "," & checkAmount & "," & creditAmount & ",'" & paymentRemarks & "'," & paymentFl & "," & billingFl & "," & creditFl & "," & referenceId & ",'" & strPaymentCheckDetail & "','" & strPaymentBillingDetail & "'," & updatedBy & ",'" & updatedDt & "');"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        paymentId = dtSaveRow("paymentId")
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


        Public Function Save_Loan_And_Contribution_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Loan_And_Contribution_Record = True
                strSql = "CALL spPaymentLoanAndContributionSave(" & paymentId & "," & memberId & ",'" & ORNo & "','" & ORDate & "'," & ORAmount & "," & cashAmount & "," & checkAmount & "," & creditAmount & ",'" & paymentRemarks & "'," & paymentFl & "," & billingFl & "," & creditFl & "," & referenceId & ",'" & strPaymentCheckDetail & "','" & dueDate & "'," & updatedBy & ",'" & updatedDt & "');"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        paymentId = dtSaveRow("paymentId")
                        updatedDt = dtSaveRow("updatedDt")
                    Next
                    RaiseEvent MsgArrival(MSGBOX_SAVE_SUCCESSFUL, True)
                    Return True
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Loan_And_Contribution_Record = False
            End Try
        End Function

        Public Function Delete_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim dtRec As DataTable

                Delete_Record = True
                strSql = "CALL spPaymentDelete(" & paymentId & "," & updatedBy & ");"
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

        Public Function Delete_Loan_And_Contribution_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim dtRec As DataTable

                Delete_Loan_And_Contribution_Record = True
                strSql = "CALL spPaymentLoanAndContributionDelete(" & paymentId & "," & updatedBy & ");"
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
                Delete_Loan_And_Contribution_Record = False
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

                    strSql = "CALL spPaymentFind(" & paymentId & ",'" & CritORNo & "','" & CritMemberName & "'," & CritORAmount & "," & CritORAmountTo & ",'" & CritORDate & "'," & Date_Type & "," & CritCancelFl & "," & CritReferenceId & "," & initFlag & ");"

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

        Public Function Search_LC_Record()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spPaymentLCFind(" & paymentId & ",'" & CritORNo & "','" & CritMemberName & "'," & CritORAmount & ",'" & CritORDate & "'," & CritCancelFl & "," & CritReferenceId & "," & initFlag & ");"

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

                    strSql = "CALL spPaymentFind(" & initFlag & ",'','',0,0,'',1,-1,0,2);"

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
                        Me.paymentId = Trim(myRow1("paymentId").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberName = Trim(myRow1("memberName").ToString)
                        Me.ORNo = Trim(myRow1("ORNo").ToString)
                        Me.ORDate = Trim(myRow1("ORDate").ToString)
                        Me.TempORDate = Microsoft.VisualBasic.DateValue(myRow1("ORDate").ToString)
                        Me.ORAmount = Trim(myRow1("ORAmount").ToString)
                        Me.cashAmount = Trim(myRow1("cashAmount").ToString)
                        Me.checkAmount = Trim(myRow1("checkAmount").ToString)
                        Me.creditAmount = Trim(myRow1("creditAmount").ToString)
                        Me.paymentRemarks = Trim(myRow1("paymentRemarks").ToString)
                        Me.cancelFl = Trim(myRow1("cancelFl").ToString)
                        'commented deleteF1 since not existing on db
                        'Me.deleteFl = Trim(myRow1("deleteFl").ToString)
                        Me.onlineFl = Trim(myRow1("onlineFl").ToString)
                        Me.billingFl = Trim(myRow1("billingFl").ToString)
                        Me.paymentFl = Trim(myRow1("paymentFl").ToString)
                        Me.creditFl = Trim(myRow1("creditFl").ToString)
                        Me.referenceId = Trim(myRow1("referenceId").ToString)

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

        Public Function Selected_Loan_And_Contribution_Record() As Boolean
            Dim strSql As String
            Dim ErrorMsg As String = ""
            Dim dtSelectedRecord As DataTable

            Try
                Clean_Parameters_Search()

                With clsDataAccess

                    strSql = "CALL spPaymentLoanAndContributionFind(" & initFlag & ",'','',0,'',-1,-1,2);"

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
                        Me.paymentId = Trim(myRow1("paymentId").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberName = Trim(myRow1("memberName").ToString)
                        Me.ORNo = Trim(myRow1("ORNo").ToString)
                        Me.ORDate = Trim(myRow1("ORDate").ToString)
                        Me.TempORDate = Microsoft.VisualBasic.DateValue(myRow1("ORDate").ToString)
                        Me.ORAmount = Trim(myRow1("ORAmount").ToString)
                        Me.cashAmount = Trim(myRow1("cashAmount").ToString)
                        Me.checkAmount = Trim(myRow1("checkAmount").ToString)
                        Me.creditAmount = Trim(myRow1("creditAmount").ToString)
                        Me.paymentRemarks = Trim(myRow1("paymentRemarks").ToString)
                        Me.cancelFl = Trim(myRow1("cancelFl").ToString)
                        'commented deleteF1 since not existing on db
                        'Me.deleteFl = Trim(myRow1("deleteFl").ToString)
                        Me.onlineFl = Trim(myRow1("onlineFl").ToString)
                        Me.billingFl = Trim(myRow1("billingFl").ToString)
                        Me.paymentFl = Trim(myRow1("paymentFl").ToString)
                        Me.creditFl = Trim(myRow1("creditFl").ToString)
                        Me.referenceId = Trim(myRow1("referenceId").ToString)

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

        Public Function GetPaymentORNoList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spPaymentORNoGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetCollectionTypeList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spCollectionTypeGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetCollectionFeeDefault(ByVal pId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spCollectionFeeDefaultGet(" & pId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetCollectionFeeDefault = dtRecord.Rows(0)("feeDefault")
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetBankNameList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spBankGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function Populate_Payment_Memo_Detail() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spPaymentMemoDetailFind(" & paymentId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_Check_Detail() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spPaymentCheckDetailFind(" & paymentId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_Billing_Detail() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spPaymentBillingDetailFind(" & paymentId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_Billing_Loan_Detail() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spPaymentBillingLoanDetailFind(" & paymentId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_Billing_Contribution_Detail() As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spPaymentBillingConDetailFind(" & paymentId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Fees_Billing_Records_Member(ByVal id As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spFeesBillingRecordsMemberFind(" & id & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Fees_Billing_Records(ByVal id As Integer, ByVal bdate As Date) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spFeesBillingRecordsFind(" & id & ",'" & bdate.ToString("yyyy-MM-dd") & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Billing_Records(ByVal id As Integer, ByVal bdate As Date) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanBillingRecordsFind(" & id & ",'" & bdate.ToString("yyyy-MM-dd") & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Collection_Billing_Records(ByVal id As Integer, ByVal bdate As Date) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spCollectionBillingRecordsFind(" & id & ",'" & bdate.ToString("yyyy-MM-dd") & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Billing_MemberId(ByVal id As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanBillingMemberIdFind(" & id & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function GetMemberFeesBillingRecordsCount(ByVal id As Integer, ByVal paidFl As Integer) As Integer
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spFeesBillingRecordsMemberCountGet(" & id & "," & paidFl & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberFeesBillingRecordsCount = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Populate_Payment_Report(ByVal pId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spORDetailReport(" & pId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_Check_Detail_Report(ByVal pId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spORCheckDetailReport(" & pId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_Memo_Detail_Report(ByVal pId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spORMemoDetailReport(" & pId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Payment_AF51_Detail_Report(ByVal pId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spORAF51DetailReport(" & pId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
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

        Public Function Populate_Official_Receipts_Issued_List_Report(ByVal conDt As String, ByVal conType As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spORIssuedListReport('" & conDt & "','" & conType & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

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

#End Region

#Region "Class Payment Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritORNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritORNo))
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                CritORDate = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritORDate))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                ORDate = TempORDate.ToString("yyyy-MM-dd")

                ORNo = .ReplaceSingleQuotes(ORNo)
                ORDate = .ReplaceSingleQuotes(ORDate)
                paymentRemarks = .ReplaceSingleQuotes(paymentRemarks)
                strPaymentCheckDetail = .ReplaceSingleQuotes(strPaymentCheckDetail)
                strPaymentBillingDetail = .ReplaceSingleQuotes(strPaymentBillingDetail)
            End With
        End Sub

        Private Sub Build_String_Before_Saving()

            Dim clsPaymentCheckDetail As PaymentCheck
            strPaymentCheckDetail = ""

            If IsNothing(colPaymentCheckDetail) = False Then
                For Each clsPaymentCheckDetail In colPaymentCheckDetail
                    strPaymentCheckDetail += CStr(clsPaymentCheckDetail.check_No) _
                    & "|" & CDbl(clsPaymentCheckDetail.check_Amount) _
                    & "|" & CStr(clsPaymentCheckDetail.check_Date) _
                    & "|" & CInt(clsPaymentCheckDetail.bank_Id) _
                    & "|" & CStr(clsPaymentCheckDetail.bank_Branch) _
                    & "|" & CStr(clsPaymentCheckDetail.check_Remarks) & "|"
                Next
            End If

            Dim clsPaymentBillingDetail As PaymentDetail
            strPaymentBillingDetail = ""

            If IsNothing(colPaymentBillingDetail) = False Then
                For Each clsPaymentBillingDetail In colPaymentBillingDetail
                    strPaymentBillingDetail += CLng(clsPaymentBillingDetail.billing_Id) _
                    & "|" & CInt(clsPaymentBillingDetail.type_Id) _
                    & "|" & CDbl(clsPaymentBillingDetail.amount_Paid) _
                    & "|" & CStr(clsPaymentBillingDetail.payment_Remarks) _
                    & "|" & CDbl(clsPaymentBillingDetail.discount_Amount) _
                    & "|" & CDbl(clsPaymentBillingDetail.fines_Amount) _
                    & "|" & CLng(clsPaymentBillingDetail.reference_Id) & "|"
                Next
            End If

            ''Loan Payment Details
            'Dim clsPaymentLoanBillingDetail As PaymentDetail
            'strPaymentLoanBillingDetail = ""

            'If IsNothing(colPaymentLoanBillingDetail) = False Then
            '    For Each clsPaymentLoanBillingDetail In colPaymentLoanBillingDetail
            '        strPaymentLoanBillingDetail += CLng(clsPaymentLoanBillingDetail.billing_Id) _
            '        & "|" & CInt(clsPaymentLoanBillingDetail.type_Id) _
            '        & "|" & CDbl(clsPaymentLoanBillingDetail.amount_Paid) _
            '        & "|" & CStr(clsPaymentLoanBillingDetail.payment_Remarks) _
            '        & "|" & CDbl(clsPaymentLoanBillingDetail.discount_Amount) _
            '        & "|" & CDbl(clsPaymentLoanBillingDetail.fines_Amount) _
            '        & "|" & CLng(clsPaymentLoanBillingDetail.reference_Id) & "|"
            '    Next
            'End If
            ''Contribution Payment Details
            'Dim clsPaymentContributionBillingDetail As PaymentDetail
            'strPaymentContributionBillingDetail = ""

            'If IsNothing(colPaymentContributionBillingDetail) = False Then
            '    For Each clsPaymentContributionBillingDetail In colPaymentContributionBillingDetail
            '        strPaymentContributionBillingDetail += CLng(clsPaymentContributionBillingDetail.billing_Id) _
            '        & "|" & CInt(clsPaymentContributionBillingDetail.type_Id) _
            '        & "|" & CDbl(clsPaymentContributionBillingDetail.amount_Paid) _
            '        & "|" & CStr(clsPaymentContributionBillingDetail.payment_Remarks) _
            '        & "|" & CDbl(clsPaymentContributionBillingDetail.discount_Amount) _
            '        & "|" & CDbl(clsPaymentContributionBillingDetail.fines_Amount) _
            '        & "|" & CLng(clsPaymentContributionBillingDetail.reference_Id) & "|"
            '    Next
            'End If
        End Sub

#End Region

    End Class

End Namespace
