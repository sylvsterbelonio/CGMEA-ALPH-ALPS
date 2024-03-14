Imports System.IO
Imports MySql.Data.MySqlClient
Namespace MemberContributionUpdater

    Public Class MemberContributionUpdater

#Region "Class Member Contribution Updater Variable Declaration"

        Private memberId As Integer
        Private feeId As Integer
        Private contributionDt As String
        Private contributionAmount As Double

        Private updatedBy As Integer
        Private updatedDt As String

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

        Public Property _feeId() As Integer
            Get
                Return feeId
            End Get
            Set(ByVal value As Integer)
                If feeId = value Then
                    Return
                End If
                feeId = value
            End Set
        End Property

        Public Property _contributionDt() As String
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

        Public Property _contributionAmount() As Double
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

#End Region

#Region "Class Member Contribution Public Functions"

        Public Function Save_Member_Contribution_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Save_Member_Contribution_Record = True
                strSql = "CALL spMemberContributionUpdaterSave(" & _memberId & _
                "," & feeId & ",'" & contributionDt & "','" & contributionAmount & "'," & updatedBy & ");"

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

#End Region

    End Class

End Namespace

