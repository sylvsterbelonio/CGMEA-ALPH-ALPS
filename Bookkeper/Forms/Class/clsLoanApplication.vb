Imports System.IO
Imports MySql.Data.MySqlClient

Namespace LoanApplication

    Public Class LoanApplication

#Region "Class Loan Application Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritLoanNo As String
        Private CritTypeId As Integer
        Private CritMemberName As String
        Private CritMemberNo As String
        Private CritApprovedFl As Integer
        Private CritReleasedFl As Integer
        Private CritCancelFl As Integer
        Private CritActiveFl As Integer

        Private loanId As Integer
        Private loanNo As Integer
        Private memberId As Integer
        Private memberName As String
        Private departmentName As String
        Private capitalAmount As Double
        Private loanRemarks As String

        Private loanStatus As String
        Private voucherNo As String
        Private checkNo As String
        Private loanDt As String
        Private temploanDt As Date

        Private loanTypeId As Integer
        Private loanType As String
        Private principalAmount As Double

        Private valueFl As Integer
        Private valueDt As String
        Private tempvalueDt As Date

        Private loanTerm As Integer
        Private interestRate As Integer
        Private monthlyPayment As Double

        Private loanInterest As Double
        Private rebates As Double
        Private totalLoanInterest As Double
        Private loanBalance As Double
        Private serviceFee As Double
        Private cisp As Double
        Private cispUnused As Double
        Private totalCISP As Double
        Private totalDeductions As Double
        Private netProceeds As Double

        Private maturityDt As String

        Private signedFl As Integer
        Private signedDt As String
        Private tempsignedDt As Date

        Private approvedBy As Integer
        Private approvedFl As Integer
        Private approvedDt As String
        Private releasedBy As Integer
        Private releasedFl As Integer
        Private releasedDt As String

        Private cancelFl As Integer
        Private cancelDt As String
        Private closedFl As Integer
        Private closedDt As String

        Private updatedBy As Integer
        Private updatedDt As String

        Dim clsLoanApplicationFee As New LoanApplicationDetails.LoanApplicationDetails
        Dim strLoanApplicationFee As String
        Private colLoanApplicationFee As New Collection

        Dim clsLoanBalance As New LoanApplicationDetails.LoanApplicationDetails
        Dim strLoanBalance As String
        Private colLoanBalance As New Collection

        Dim clsLoanApplicationSignatory As New LoanApplicationDetails.LoanApplicationDetails
        Dim strLoanApplicationSignatory As String
        Private colLoanApplicationSignatory As New Collection

        Dim clsLoanApplicationSchedule As New LoanApplicationDetails.LoanApplicationDetails
        Dim strLoanApplicationSchedule As String
        Private colLoanApplicationSchedule As New Collection

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

#Region "Class Loan Application Public Property Variable Declaration"

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

        Public WriteOnly Property _CritTypeId() As Integer
            Set(ByVal Value As Integer)
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

        Public WriteOnly Property _CritApprovedFl() As Integer
            Set(ByVal Value As Integer)
                If CritApprovedFl = Value Then
                    Return
                End If
                CritApprovedFl = Value
            End Set
        End Property

        Public WriteOnly Property _CritReleasedFl() As Integer
            Set(ByVal Value As Integer)
                If CritReleasedFl = Value Then
                    Return
                End If
                CritReleasedFl = Value
            End Set
        End Property

        Public WriteOnly Property _CritCancelFl() As Integer
            Set(ByVal Value As Integer)
                If CritCancelFl = Value Then
                    Return
                End If
                CritCancelFl = Value
            End Set
        End Property

        Public WriteOnly Property _CritActiveFl() As Integer
            Set(ByVal Value As Integer)
                If CritActiveFl = Value Then
                    Return
                End If
                CritActiveFl = Value
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

        Public Property _loanRemarks() As String
            Get
                Return loanRemarks
            End Get
            Set(ByVal value As String)
                If loanRemarks = value Then
                    Return
                End If
                loanRemarks = value
            End Set
        End Property

        Public Property _loanStatus() As String
            Get
                Return loanStatus
            End Get
            Set(ByVal value As String)
                If loanStatus = value Then
                    Return
                End If
                loanStatus = value
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

        Public Property _loanDt() As String
            Get
                Return loanDt
            End Get
            Set(ByVal value As String)
                If loanDt = value Then
                    Return
                End If
                loanDt = value
            End Set
        End Property

        Public Property _tempLoanDt() As Date
            Get
                Return temploanDt
            End Get
            Set(ByVal value As Date)
                If temploanDt = value Then
                    Return
                End If
                temploanDt = value
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

        Public Property _valueFl() As Integer
            Get
                Return valueFl
            End Get
            Set(ByVal value As Integer)
                If valueFl = value Then
                    Return
                End If
                valueFl = value
            End Set
        End Property

        Public Property _valueDt() As String
            Get
                Return valueDt
            End Get
            Set(ByVal value As String)
                If valueDt = value Then
                    Return
                End If
                valueDt = value
            End Set
        End Property

        Public Property _tempValueDt() As Date
            Get
                Return tempvalueDt
            End Get
            Set(ByVal value As Date)
                If tempValueDt = value Then
                    Return
                End If
                tempValueDt = value
            End Set
        End Property

        Public Property _loanTerm() As Integer
            Get
                Return loanTerm
            End Get
            Set(ByVal value As Integer)
                If loanTerm = value Then
                    Return
                End If
                loanTerm = value
            End Set
        End Property

        Public Property _interestRate() As Integer
            Get
                Return interestRate
            End Get
            Set(ByVal value As Integer)
                If interestRate = value Then
                    Return
                End If
                interestRate = value
            End Set
        End Property

        Public Property _monthlyPayment() As Double
            Get
                Return monthlyPayment
            End Get
            Set(ByVal value As Double)
                If monthlyPayment = value Then
                    Return
                End If
                monthlyPayment = value
            End Set
        End Property

        Public Property _loanInterest() As Double
            Get
                Return loanInterest
            End Get
            Set(ByVal value As Double)
                If loanInterest = value Then
                    Return
                End If
                loanInterest = value
            End Set
        End Property

        Public Property _rebates() As Double
            Get
                Return rebates
            End Get
            Set(ByVal value As Double)
                If rebates = value Then
                    Return
                End If
                rebates = value
            End Set
        End Property

        Public Property _totalLoanInterest() As Double
            Get
                Return totalLoanInterest
            End Get
            Set(ByVal value As Double)
                If totalLoanInterest = value Then
                    Return
                End If
                totalLoanInterest = value
            End Set
        End Property

        Public Property _loanBalance() As Double
            Get
                Return loanBalance
            End Get
            Set(ByVal value As Double)
                If loanBalance = value Then
                    Return
                End If
                loanBalance = value
            End Set
        End Property

        Public Property _serviceFee() As Double
            Get
                Return serviceFee
            End Get
            Set(ByVal value As Double)
                If serviceFee = value Then
                    Return
                End If
                serviceFee = value
            End Set
        End Property

        Public Property _cisp() As Double
            Get
                Return cisp
            End Get
            Set(ByVal value As Double)
                If cisp = value Then
                    Return
                End If
                cisp = value
            End Set
        End Property

        Public Property _cispUnused() As Double
            Get
                Return cispUnused
            End Get
            Set(ByVal value As Double)
                If cispUnused = value Then
                    Return
                End If
                cispUnused = value
            End Set
        End Property

        Public Property _totalCISP() As Double
            Get
                Return totalCISP
            End Get
            Set(ByVal value As Double)
                If totalCISP = value Then
                    Return
                End If
                totalCISP = value
            End Set
        End Property

        Public Property _totalDeductions() As Double
            Get
                Return totalDeductions
            End Get
            Set(ByVal value As Double)
                If totalDeductions = value Then
                    Return
                End If
                totalDeductions = value
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

        Public Property _maturityDt() As String
            Get
                Return maturityDt
            End Get
            Set(ByVal value As String)
                If maturityDt = value Then
                    Return
                End If
                maturityDt = value
            End Set
        End Property

        Public Property _signedFl() As Integer
            Get
                Return signedFl
            End Get
            Set(ByVal value As Integer)
                If signedFl = value Then
                    Return
                End If
                signedFl = value
            End Set
        End Property

        Public Property _signedDt() As String
            Get
                Return signedDt
            End Get
            Set(ByVal value As String)
                If signedDt = value Then
                    Return
                End If
                signedDt = value
            End Set
        End Property

        Public Property _tempSignedDt() As Date
            Get
                Return tempsignedDt
            End Get
            Set(ByVal value As Date)
                If tempsignedDt = value Then
                    Return
                End If
                tempsignedDt = value
            End Set
        End Property

        Public Property _approvedBy() As Integer
            Get
                Return approvedBy
            End Get
            Set(ByVal value As Integer)
                If approvedBy = value Then
                    Return
                End If
                approvedBy = value
            End Set
        End Property

        Public Property _approvedFl() As Integer
            Get
                Return approvedFl
            End Get
            Set(ByVal value As Integer)
                If approvedFl = value Then
                    Return
                End If
                approvedFl = value
            End Set
        End Property

        Public Property _approvedDt() As String
            Get
                Return approvedDt
            End Get
            Set(ByVal Value As String)
                If approvedDt = Value Then
                    Return
                End If
                approvedDt = Value
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

        Public Property _releasedFl() As Integer
            Get
                Return releasedFl
            End Get
            Set(ByVal value As Integer)
                If releasedFl = value Then
                    Return
                End If
                releasedFl = value
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

        Public Property _cancelFl() As Integer
            Get
                Return cancelFl
            End Get
            Set(ByVal value As Integer)
                If cancelFl = value Then
                    Return
                End If
                cancelFl = value
            End Set
        End Property

        Public Property _cancelDt() As String
            Get
                Return cancelDt
            End Get
            Set(ByVal Value As String)
                If cancelDt = Value Then
                    Return
                End If
                cancelDt = Value
            End Set
        End Property

        Public Property _closedFl() As Integer
            Get
                Return closedFl
            End Get
            Set(ByVal value As Integer)
                If closedFl = value Then
                    Return
                End If
                closedFl = value
            End Set
        End Property

        Public Property _closedDt() As String
            Get
                Return closedDt
            End Get
            Set(ByVal Value As String)
                If closedDt = Value Then
                    Return
                End If
                closedDt = Value
            End Set
        End Property

        Public WriteOnly Property _updatedBy() As String
            Set(ByVal Value As String)
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

        Public Property _colLoanApplicationFee() As Collection
            Get
                Return colLoanApplicationFee
            End Get
            Set(ByVal Value As Collection)
                If colLoanApplicationFee Is Value Then
                    Return
                End If
                colLoanApplicationFee = Value
            End Set
        End Property

        Public Property _colLoanBalance() As Collection
            Get
                Return colLoanBalance
            End Get
            Set(ByVal Value As Collection)
                If colLoanBalance Is Value Then
                    Return
                End If
                colLoanBalance = Value
            End Set
        End Property

        Public Property _colLoanApplicationSignatory() As Collection
            Get
                Return colLoanApplicationSignatory
            End Get
            Set(ByVal Value As Collection)
                If colLoanApplicationSignatory Is Value Then
                    Return
                End If
                colLoanApplicationSignatory = Value
            End Set
        End Property

        Public Property _colLoanApplicationSchedule() As Collection
            Get
                Return colLoanApplicationSchedule
            End Get
            Set(ByVal Value As Collection)
                If colLoanApplicationSchedule Is Value Then
                    Return
                End If
                colLoanApplicationSchedule = Value
            End Set
        End Property

#End Region

#Region "Class Loan Application Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Build_String_Before_Saving()
                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spLoanApplicationSave(" & loanId & "," & loanNo & "," & memberId & "," & capitalAmount & _
                ",'" & loanRemarks & "','" & loanStatus & "','" & voucherNo & "','" & checkNo & _
                "','" & loanDt & "'," & loanTypeId & "," & principalAmount & "," & valueFl & ",'" & valueDt & _
                "'," & loanTerm & "," & interestRate & "," & monthlyPayment & _
                "," & loanInterest & "," & rebates & "," & totalLoanInterest & "," & loanBalance & "," & serviceFee & _
                "," & cisp & "," & cispUnused & "," & totalCISP & "," & totalDeductions & "," & netProceeds & ",'" & maturityDt & "'," & signedFl & ",'" & signedDt & _
                "'," & cancelFl & ",'" & cancelDt & "'," & closedFl & ",'" & closedDt & _
                "','" & strLoanBalance & "','" & strLoanApplicationFee & "','" & strLoanApplicationSignatory & "','" & strLoanApplicationSchedule & _
                "'," & updatedBy & ",'" & updatedDt & "');"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        loanId = dtSaveRow("loanId")
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
                strSql = "CALL spLoanApplicationDelete(" & loanId & "," & updatedBy & ");"
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

                    strSql = "CALL spLoanApplicationFind(" & loanId _
                    & ",'" & CritLoanNo & "'," & CritTypeId & ",'" & CritMemberName & "','" & CritMemberNo & "'," & CritApprovedFl & "," & CritReleasedFl & "," & CritCancelFl & "," & CritActiveFl & "," & initFlag & ");"

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

                    strSql = "CALL spLoanApplicationFind(" & initFlag & ",'',0,'','',0,0,0,0,2);"

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
                        Me.loanId = Trim(myRow1("loanId").ToString)
                        Me.loanNo = Trim(myRow1("loanNo").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberName = Trim(myRow1("memberName").ToString)
                        Me.departmentName = Trim(myRow1("departmentName").ToString)
                        Me.capitalAmount = Trim(myRow1("capitalAmount").ToString)
                        Me.loanRemarks = Trim(myRow1("loanRemarks").ToString)
                        Me.loanStatus = Trim(myRow1("loanStatus").ToString)
                        Me.voucherNo = Trim(myRow1("voucherNo").ToString)
                        Me.checkNo = Trim(myRow1("checkNo").ToString)
                        Me.loanDt = Trim(myRow1("loanDt").ToString)
                        Me.loanTypeId = Trim(myRow1("loanTypeId").ToString)
                        Me.loanType = Trim(myRow1("loanType").ToString)
                        Me.principalAmount = Trim(myRow1("principalAmount").ToString)
                        Me.valueFl = Trim(myRow1("valueFl").ToString)
                        Me.valueDt = Trim(myRow1("valueDt").ToString)
                        Me.loanTerm = Trim(myRow1("loanTerm").ToString)
                        Me.interestRate = Trim(myRow1("interestRate").ToString)
                        Me.monthlyPayment = Trim(myRow1("monthlyPayment").ToString)
                        Me.loanInterest = Trim(myRow1("loanInterest").ToString)
                        Me.rebates = Trim(myRow1("rebates").ToString)
                        Me.totalLoanInterest = Trim(myRow1("totalLoanInterest").ToString)
                        Me.loanBalance = Trim(myRow1("loanBalance").ToString)
                        Me.serviceFee = Trim(myRow1("serviceFee").ToString)
                        Me.cisp = Trim(myRow1("cisp").ToString)
                        Me.cispUnused = Trim(myRow1("cispUnused").ToString)
                        Me.totalCISP = Trim(myRow1("totalCISP").ToString)
                        Me.totalDeductions = Trim(myRow1("totalDeductions").ToString)
                        Me.netProceeds = Trim(myRow1("netProceeds").ToString)
                        Me.maturityDt = Trim(myRow1("maturityDt").ToString)
                        Me.signedFl = Trim(myRow1("signedFl").ToString)
                        Me.signedDt = Trim(myRow1("signedDt").ToString)
                        Me.approvedBy = Trim(myRow1("approvedBy").ToString)
                        Me.approvedFl = Trim(myRow1("approvedFl").ToString)
                        Me.approvedDt = Trim(myRow1("approvedDt").ToString)
                        Me.releasedBy = Trim(myRow1("releasedBy").ToString)
                        Me.releasedFl = Trim(myRow1("releasedFl").ToString)
                        Me.releasedDt = Trim(myRow1("releasedDt").ToString)
                        Me.cancelFl = Trim(myRow1("cancelFl").ToString)
                        Me.cancelDt = Trim(myRow1("cancelDt").ToString)
                        Me.closedFl = Trim(myRow1("closeFl").ToString)
                        Me.closedDt = Trim(myRow1("closeDt").ToString)
                        Me.updatedBy = Trim(myRow1("updatedBy").ToString)
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

        Public Function GetLoanTermAndInterest()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = "CALL spLoanTermAndInterestFind(" & loanId & ");"

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

        Public Function Populate_Loan_Application_Balance(ByVal mId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationBalanceFind(" & mId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Application_Fee(ByVal lId As Integer, ByVal tId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationFeeFind(" & lId & "," & tId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Application_Signatory(ByVal tdId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationSignatoryFind(" & tdId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Application_Schedule(ByVal tdId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationScheduleFind(" & tdId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function getSignatoryName()
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "select concat(fName,' ',mname,' ',lname) as 'Name' from tblsignatory"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function getSignatoryPosition()
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "select distinct designation  from tblsignatory"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
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

        Public Function getServiceFee() As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spServiceFeeGet();"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                getServiceFee = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetCISPRate(ByVal pPeriod As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spCISPRateGet(" & pPeriod & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetCISPRate = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetRebates(ByVal lId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanApplicationRebatesGet(" & lId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetRebates = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetCISPUnused(ByVal lId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanApplicationCISPUnusedGet(" & lId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetCISPUnused = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetPrevRebates(ByVal lId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanApplicationPrevRebatesGet(" & lId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetPrevRebates = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetPrevCISPUnused(ByVal lId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanApplicationPrevCISPUnusedGet(" & lId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetPrevCISPUnused = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function RebatesGet(ByVal lId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanRebatesGet(" & lId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                RebatesGet = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function CISPUnusedGet(ByVal lId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanCISPUnusedGet(" & lId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                CISPUnusedGet = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetLoanType(ByVal typeId As Integer) As String
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanTypeGet(" & typeId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetLoanType = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetLoanBalance(ByVal lId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanApplicationLoanBalanceGet(" & lId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetLoanBalance = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
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

        Public Function GetLoanTypeCount(ByVal rId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Double
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanTypeCountGet(" & rId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetLoanTypeCount = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Populate_Loan_Detail_Report(ByVal lId As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationDetailReport(" & lId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Balance_Report(ByVal lId As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationBalancePaymentReport(" & lId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Fee_Report(ByVal lId As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationFeeReport(" & lId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Signatory_Detail_Report(ByVal lId As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanApplicationSignatoryDetailReport(" & lId & ");"

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

        Public Function GetMemberNo(ByVal UId As Integer) As String
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberNoUserGet(" & UId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberNo = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetMemberName(ByVal UId As Integer) As String
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberNameUserGet(" & UId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberName = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function GetMemberNameId(ByVal UId As Integer) As String
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spMemberNameIdUserGet(" & UId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)

                GetMemberNameId = dtRecord.Rows(0)(0)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

        Public Function Populate_Loan_Balance_Record(ByVal mId As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanBalanceDetailFind(" & mId & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Loan_Fee_Record(ByVal mId As Integer, ByVal trm As Integer, ByVal prn As Double) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spLoanDeductionDetailFind(" & mId & "," & trm & "," & prn & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function
        Public Function ValidateLoanPayment30Percent(ByVal lId As Integer, ByVal tId As Integer, ByVal mId As Integer) As Boolean
            Dim sqlStmt As String

            Try
                sqlStmt = "CALL spLoanApplicationLoanPayment30Validate(" & lId & "," & tId & "," & mId & ");"
                dtRecord = clsDataAccess.ExecuteQuery(sqlStmt, False, RETURN_TYPE_DATATABLE)
                If dtRecord.Rows.Count > 0 Then

                    ValidateLoanPayment30Percent = dtRecord.Rows(0)(0)
                Else
                    ValidateLoanPayment30Percent = False
                End If

            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            Catch err As Exception
                Throw err
            End Try
        End Function

#End Region

#Region "Class LoanApplication Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritLoanNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLoanNo))
                CritTypeId = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritTypeId))
                CritMemberName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberName))
                CritMemberNo = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMemberNo))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                loanRemarks = .ReplaceSingleQuotes(loanRemarks)
                loanStatus = .ReplaceSingleQuotes(loanStatus)
                voucherNo = .ReplaceSingleQuotes(voucherNo)
                checkNo = .ReplaceSingleQuotes(checkNo)
                maturityDt = .ReplaceSingleQuotes(maturityDt)
                loanDt = temploanDt.ToString("yyyy-MM-dd")
                valueDt = tempvalueDt.ToString("yyyy-MM-dd")
                signedDt = tempsignedDt.ToString("yyyy-MM-dd")
            End With
        End Sub

        Private Sub Build_String_Before_Saving()
            Dim clsLoanApplicationFee As LoanApplicationDetails.LoanApplicationDetails
            strLoanApplicationFee = ""

            If IsNothing(colLoanApplicationFee) = False Then
                For Each clsLoanApplicationFee In colLoanApplicationFee
                    strLoanApplicationFee += CStr(clsLoanApplicationFee._feeId) _
                    & "|" & CStr(clsLoanApplicationFee._feeAmount) & "|"
                Next
            End If

            'Loan Balance
            Dim clsLoanBalance As LoanApplicationDetails.LoanApplicationDetails
            strLoanBalance = ""

            If IsNothing(colLoanBalance) = False Then
                For Each clsLoanBalance In colLoanBalance
                    strLoanBalance += CStr(clsLoanBalance._loanId) _
                    & "|" & CStr(clsLoanBalance._loanBalAmount) _
                    & "|" & CStr(clsLoanBalance._loanRebates) _
                    & "|" & CStr(clsLoanBalance._loanUnused) & "|"
                Next
            End If

            Dim clsLoanApplicationSignatory As LoanApplicationDetails.LoanApplicationDetails
            strLoanApplicationSignatory = ""

            If IsNothing(colLoanApplicationSignatory) = False Then
                For Each clsLoanApplicationSignatory In colLoanApplicationSignatory
                    strLoanApplicationSignatory += CStr(clsLoanApplicationSignatory._signatoryType) _
                    & "|" & CStr(clsLoanApplicationSignatory._signatoryName) _
                    & "|" & CStr(clsLoanApplicationSignatory._signatoryPosition) & "|"
                Next
            End If

            Dim clsLoanApplicationSchedule As LoanApplicationDetails.LoanApplicationDetails
            strLoanApplicationSchedule = ""

            If IsNothing(colLoanApplicationSchedule) = False Then
                For Each clsLoanApplicationSchedule In colLoanApplicationSchedule
                    strLoanApplicationSchedule += CStr(clsLoanApplicationSchedule._scheduleDt) _
                    & "|" & CStr(clsLoanApplicationSchedule._monthlyInterest) _
                    & "|" & CStr(clsLoanApplicationSchedule._monthlyPrincipal) _
                    & "|" & CStr(clsLoanApplicationSchedule._totalAmount) & "|"
                Next
            End If
        End Sub

#End Region

    End Class

End Namespace
