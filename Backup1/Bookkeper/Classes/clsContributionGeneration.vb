Imports MySql.Data.MySqlClient

Namespace ContributionGeneration

    Public Class ContributionGeneration

#Region "Class ContribtuionGeneration Variable Declaration"

        Private memberId As Integer
        Private memberNo As String
        Private memberName As String
        Private memberFl As Integer

        Private contributionDt As String
        Private tempContributionDt As Date
        Private updatedBy As Integer

        Private dType As Integer

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
        Private dtRecord As DataTable
#End Region

#Region "Class ContribtuionGeneration Public Property Variable Declaration"

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

        Public Property _memberFl() As Integer
            Get
                Return memberFl
            End Get
            Set(ByVal value As Integer)
                If memberFl = value Then
                    Return
                End If
                memberFl = value
            End Set
        End Property

        Public Property Contribution_Dt() As String
            Get
                Return contributionDt
            End Get
            Set(ByVal value As String)
                If contributionDt = value Then
                    Return
                End If
                contributionDt = value
            End Set
        End Property

        Public Property TempContribution_Dt() As Date
            Get
                Return tempContributionDt
            End Get
            Set(ByVal value As Date)
                If tempContributionDt = value Then
                    Return
                End If
                tempContributionDt = value
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

        Public Property _dType() As Integer
            Get
                Return dType
            End Get
            Set(ByVal value As Integer)
                If dType = value Then
                    Return
                End If
                dType = value
            End Set
        End Property
#End Region

#Region "Class ContribtuionGeneration Public Functions"

        Public Function Save_Generated_Contribution_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Generated_Contribution_Record = True
                strSql = "CALL spMemberContributionGeneratedSave('" & memberNo & "','" & memberName & "'," & memberFl & "," & dType & ",'" & contributionDt & "'," & updatedBy & ");"

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
                Save_Generated_Contribution_Record = False
            End Try
        End Function

        Private Sub Clean_Parameters_Save()
            With clsCommon
                contributionDt = tempContributionDt.ToString("yyyy-MM-dd")

            End With
        End Sub

        Public Function Populate_Member_Contribution_List_Report(ByVal conDt As String, ByVal memNo As String, ByVal memName As String, ByVal activeFl As Integer, ByVal dType As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionDetailReport('" & conDt & "','" & memNo & "','" & memName & "'," & activeFl & "," & dType & ");"

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

        Public Function Populate_Member_Contribution_List_Record(ByVal conDt As String, ByVal memNo As String, ByVal memName As String, ByVal activeFl As Integer, ByVal dType As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionListFind('" & conDt & "','" & memNo & "','" & memName & "'," & activeFl & "," & dType & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_Contribution_Billing_Record(ByVal conDt As String, ByVal dType As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionBillingFind('" & conDt & "'," & dType & ");"

                    dtListView = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dtListView = Nothing
            End Try
            Return dtListView
        End Function

        Public Function Populate_Member_Contribution_Billing_List_Record(ByVal conDt As String, ByVal dType As Integer) As DataTable
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim dtListView As DataTable
            Try
                With clsDataAccess
                    dtListView = New DataTable
                    strSql = "CALL spMemberContributionBillingFind('" & conDt & "','','',1," & dType & ");"

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

