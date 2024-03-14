Imports System.IO
Imports MySql.Data.MySqlClient

Namespace Signatory

    Public Class Signatory

#Region "Class Signatory Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritFirstName As String
        Private CritLastName As String
        Private CritDesignation As String
        Private CritDepartmentName As String

        Private signatoryId As Integer
        Private lname As String
        Private fname As String
        Private mname As String
        Private suffix As String
        Private designation As String
        Private departmentId As Integer
        Private departmentName As String
        Private memberId As Integer
        Private memberNo As String
        Private remarks As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Signatory Public Property Variable Declaration"

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

        <CLSCompliant(False)> _
        Public WriteOnly Property _CritFirstName() As String
            Set(ByVal Value As String)
                If CritFirstName = Value Then
                    Return
                End If
                CritFirstName = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public WriteOnly Property _CritLastName() As String
            Set(ByVal Value As String)
                If CritLastName = Value Then
                    Return
                End If
                CritLastName = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public WriteOnly Property _CritDesignation() As String
            Set(ByVal Value As String)
                If CritDesignation = Value Then
                    Return
                End If
                CritDesignation = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public WriteOnly Property _CritDepartmentName() As String
            Set(ByVal Value As String)
                If CritDepartmentName = Value Then
                    Return
                End If
                CritDepartmentName = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _signatoryId() As Integer
            Get
                Return signatoryId
            End Get
            Set(ByVal value As Integer)
                If signatoryId = value Then
                    Return
                End If
                signatoryId = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _lname() As String
            Get
                Return lname
            End Get
            Set(ByVal value As String)
                If lname = value Then
                    Return
                End If
                lname = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _fname() As String
            Get
                Return fname
            End Get
            Set(ByVal value As String)
                If fname = value Then
                    Return
                End If
                fname = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _mname() As String
            Get
                Return mname
            End Get
            Set(ByVal value As String)
                If mname = value Then
                    Return
                End If
                mname = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _suffix() As String
            Get
                Return suffix
            End Get
            Set(ByVal value As String)
                If suffix = value Then
                    Return
                End If
                suffix = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _designation() As String
            Get
                Return designation
            End Get
            Set(ByVal value As String)
                If designation = value Then
                    Return
                End If
                designation = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _departmentId() As Integer
            Get
                Return departmentId
            End Get
            Set(ByVal value As Integer)
                If departmentId = value Then
                    Return
                End If
                departmentId = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public ReadOnly Property _departmentName() As String
            Get
                Return departmentName
            End Get
        End Property

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

        <CLSCompliant(False)> _
        Public ReadOnly Property _memberNo() As String
            Get
                Return memberNo
            End Get
        End Property

        <CLSCompliant(False)> _
        Public Property _remarks() As String
            Get
                Return remarks
            End Get
            Set(ByVal value As String)
                If remarks = value Then
                    Return
                End If
                remarks = value
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

#Region "Class Signatory Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()


                Save_Record = True

                strSql = "CALL spSignatorySave(" & signatoryId & ",'" & lname & "','" & fname & "','" & mname & "','" & suffix & "','" & designation & "'," & departmentId & "," & memberId & ",'" & remarks & "'," & updatedBy & ",'" & updatedDt & "');"

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
                        signatoryId = dtSaveRow("signatoryId")
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
                strSql = "CALL spSignatoryDelete(" & signatoryId & "," & updatedBy & ");"
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

        Public Function Get_Max_Record_Signatory_ID()
            Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
            Dim strSql As String
            Dim ErrorMsg As String = ""
            Clean_Parameters_Search()
            Try
                With clsDataAccess
                    dtgRID = New DataTable
                    strSql = "SELECT (IFNULL(MAX(signatoryId),0)+1) 'Max' FROM tblsignatory"
                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                    Return dtgRID
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

        Public Function Search_Signatory_ID_Recheck()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable
                    strSql = "select tblsignatory.signatoryId FROM  tblsignatory  INNER JOIN tbldepartment    ON (tblsignatory.departmentId = tbldepartment.departmentId) where tblsignatory.signatoryId=" + signatoryId.ToString
                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                    Return dtgRID
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function


        Public Function Search_Signatory_ID()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable
                    strSql = "select tblsignatory.signatoryId FROM  tblsignatory  INNER JOIN tbldepartment    ON (tblsignatory.departmentId = tbldepartment.departmentId) where tblsignatory.memberId=" + memberId.ToString + " and tblsignatory.departmentId=" + departmentId.ToString
                    dtgRID = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)
                    Return dtgRID
                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
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

                    strSql = "CALL spSignatoryFind(" & signatoryId _
                    & ",'" & CritFirstName & "','" & CritLastName & "','" & CritDesignation & "','" & CritDepartmentName & "'," & initFlag & ");"

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

        Public Function Save_Record_Signatory()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Search()

                With clsDataAccess
                    dtgRID = New DataTable

                    strSql = " INSERT INTO `tblsignatory`(  signatoryId,  lname,    fname,   mname,     suffix,designation,departmentId,memberId,remarks,updatedBy,updatedDt,createdBy,createdDt)" + _
                            "   VALUES (" + signatoryId.ToString + ",'" + lname + "','" + fname + "','" + mname + "','" + suffix + "','" + designation + "'," + departmentId.ToString + "," + memberId.ToString + ",'',0,CURRENT_TIMESTAMP,0,CURRENT_TIMESTAMP)"
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

                    strSql = "CALL spSignatoryFind(" & initFlag & ",'','','','',2);"

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
                        Me.signatoryId = Trim(myRow1("signatoryId").ToString)
                        Me.lname = Trim(myRow1("lname").ToString)
                        Me.fname = Trim(myRow1("fname").ToString)
                        Me.mname = Trim(myRow1("mname").ToString)
                        Me.suffix = Trim(myRow1("suffix").ToString)
                        Me.designation = Trim(myRow1("designation").ToString)
                        Me.departmentId = Trim(myRow1("departmentId").ToString)
                        Me.departmentName = Trim(myRow1("departmentName").ToString)
                        Me.memberId = Trim(myRow1("memberId").ToString)
                        Me.memberNo = Trim(myRow1("memberNo").ToString)
                        Me.remarks = Trim(myRow1("remarks").ToString)

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

#End Region

#Region "Class Signatory Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritFirstName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritFirstName))
                CritLastName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritLastName))
                CritDesignation = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDesignation))
                CritDepartmentName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritDepartmentName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon

                lname = .ReplaceSingleQuotes(lname)
                fname = .ReplaceSingleQuotes(fname)
                mname = .ReplaceSingleQuotes(mname)
                suffix = .ReplaceSingleQuotes(suffix)
                designation = .ReplaceSingleQuotes(designation)
                remarks = .ReplaceSingleQuotes(remarks)
            End With
        End Sub

#End Region

    End Class

End Namespace
