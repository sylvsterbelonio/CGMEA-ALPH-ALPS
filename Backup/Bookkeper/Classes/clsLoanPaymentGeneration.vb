Imports MySql.Data.MySqlClient

Namespace LoanPaymentGeneration

    Public Class LoanPaymentGeneration

#Region "Class LoanPaymentGeneration Variable Declaration"

        Private memberId As Integer
        Private memberNo As String
        Private memberName As String
        Private loanPaymentDt As String
        Private tempLoanPaymentDt As Date
        Private updatedBy As Integer

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private dtRecord As DataTable
#End Region

#Region "Class LoanPaymentGeneration Public Property Variable Declaration"

        <CLSCompliant(False)> _
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

        Public Property LoanPayment_Dt() As String
            Get
                Return loanPaymentDt
            End Get
            Set(ByVal value As String)
                If loanPaymentDt = value Then
                    Return
                End If
                loanPaymentDt = value
            End Set
        End Property

        Public Property TempLoanPayment_Dt() As Date
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

        Public WriteOnly Property Updated_By() As Integer
            Set(ByVal Value As Integer)
                If updatedBy = Value Then
                    Return
                End If
                updatedBy = Value
            End Set
        End Property

#End Region

#Region "Class LoanPaymentGeneration Public Functions"

        Public Function Save_Generated_LoanPayment_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Generated_LoanPayment_Record = True
                strSql = "CALL spMemberLoanPaymentGeneratedSave('" & memberNo & "','" & memberName & "','" & loanPaymentDt & "'," & updatedBy & ");"

                dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    If ErrorMsg = "No records generated." Then
                        clsCommon.Prompt_User("information", ErrorMsg & " Please try again.")
                    Else
                        clsCommon.Prompt_User("error", "An error occured while saving information. Please try again later.")
                    End If
                    Return False
                Else
                    Return True
                End If
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Save_Generated_LoanPayment_Record = False
            End Try
        End Function

        Private Sub Clean_Parameters_Save()
            With clsCommon
                loanPaymentDt = tempLoanPaymentDt.ToString("yyyy-MM-dd")

            End With
        End Sub

        Public Function Populate_Member_Contribution_List_Report(ByVal conDt As String, ByVal memNo As String, ByVal memName As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionDetailReport('" & conDt & "','" & memNo & "','" & memName & "');"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_LoanPayment_List_Report(ByVal conDt As String, ByVal memNo As String, ByVal memName As String) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberLoanPaymentDetailReport('" & conDt & "','" & memNo & "','" & memName & "');"

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

#End Region

    End Class

End Namespace

