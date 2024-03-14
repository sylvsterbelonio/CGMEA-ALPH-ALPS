Imports System.IO
Imports MySql.Data.MySqlClient

Namespace SystemAccessLevel

    Public Class SystemAccessLevel

#Region "Class SystemAccessLevel Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable
        Private dtgRID2 As DataTable

        Private CritRoleName As String
        Private CritRoleDesc As String

        Private roleId As Integer
        Private roleName As String
        Private roleDesc As String
        Private updatedBy As Integer
        Private updatedDt As String

        Dim clsAccessPermission As New AccessPermission.AccessPermission
        Dim strAccessPermission As String
        Private colAccessPermission As New Collection

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow
#End Region

#Region "Class SystemAccessLevel Public Property Variable Declaration"

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

        Public WriteOnly Property Dt_gRID2() As DataTable
            Set(ByVal Value As DataTable)
                dtgRID2 = Value
            End Set
        End Property

        Public WriteOnly Property Crit_RoleName() As String
            Set(ByVal Value As String)
                If CritRoleName = Value Then
                    Return
                End If
                CritRoleName = Value
            End Set
        End Property

        Public WriteOnly Property Crit_RoleDesc() As String
            Set(ByVal Value As String)
                If CritRoleDesc = Value Then
                    Return
                End If
                CritRoleDesc = Value
            End Set
        End Property

        Public Property Role_ID() As Integer
            Get
                Return RoleID
            End Get
            Set(ByVal Value As Integer)
                If RoleID = Value Then
                    Return
                End If
                RoleID = Value
            End Set
        End Property

        Public Property Role_Name() As String
            Get
                Return RoleName
            End Get
            Set(ByVal Value As String)
                If RoleName = Value Then
                    Return
                End If
                RoleName = Value
            End Set
        End Property

        Public Property Role_Desc() As String
            Get
                Return RoleDesc
            End Get
            Set(ByVal Value As String)
                If RoleDesc = Value Then
                    Return
                End If
                RoleDesc = Value
            End Set
        End Property

        Public WriteOnly Property Updated_By() As Integer
            Set(ByVal Value As Integer)
                If UpdatedBy = Value Then
                    Return
                End If
                UpdatedBy = Value
            End Set
        End Property

        Public Property Updated_Dt() As String
            Get
                Return UpdatedDt
            End Get
            Set(ByVal Value As String)
                If UpdatedDt = Value Then
                    Return
                End If
                UpdatedDt = Value
            End Set
        End Property

        Public Property colAccess_Permission() As Collection
            Get
                Return colAccessPermission
            End Get
            Set(ByVal Value As Collection)
                If colAccessPermission Is Value Then
                    Return
                End If
                colAccessPermission = Value
            End Set
        End Property

#End Region

#Region "Class SystemAccessLevel Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""

                Clean_Parameters_Save()
                Build_Access_Permission_String_Before_Saving()

                Save_Record = True
                strSql = "CALL spSystemRoleSave(" & roleId & ",'" & _
                        roleName & "','" & roleDesc & "','" & strAccessPermission _
                        & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        roleId = Me.dtSaveRow("roleID")
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
                strSql = "CALL spSystemRoleDelete(" & roleId & "," & updatedBy & ");"
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

                    strSql = "CALL spSystemRoleFind(" & roleId _
                    & ",'" & CritRoleName & "','" & CritRoleDesc & "'," & initFlag & ");"

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

                    strSql = "CALL spSystemRoleFind(" & initFlag & ",'','',2);"

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
                        Me.roleId = Trim(myRow1("roleId").ToString)
                        Me.roleName = Trim(myRow1("roleName").ToString)
                        Me.roleDesc = Trim(myRow1("roleDescription").ToString)
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

        Public Function Populate_Record_System_Access()
            Try
                Dim clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
                Dim strSql As String
                Dim ErrorMsg As String = ""

                With clsDataAccess
                    dtgRID2 = New DataTable

                    strSql = "CALL spSystemAccessPermissionFind(" & roleId & "," & initFlag & ");"

                    dtgRID2 = .ExecuteQuery(strSql, False, RETURN_TYPE_DATATABLE)

                    Dim myRow As DataRow

                    For Each myRow In dtgRID2.Rows
                        ErrorMsg = Trim(myRow("ErrorMessage").ToString)
                    Next

                    If ErrorMsg <> "" Then
                        RaiseEvent MsgArrival(ErrorMsg, False)
                        Return Nothing
                    Else
                        clsDataAccess = Nothing
                        Return dtgRID2
                    End If

                End With
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                Return Nothing
            End Try
        End Function

#End Region

#Region "Class SystemAccessLevel Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritRoleName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRoleName))
                CritRoleDesc = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritRoleDesc))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                RoleName = .ReplaceSingleQuotes(RoleName)
                RoleDesc = .ReplaceSingleQuotes(RoleDesc)
                UpdatedBy = .ReplaceSingleQuotes(UpdatedBy)
            End With
        End Sub

        Private Sub Build_Access_Permission_String_Before_Saving()
            Dim AccessPermission As AccessPermission.AccessPermission

            strAccessPermission = ""

            If IsNothing(colAccessPermission) = False Then
                For Each AccessPermission In colAccessPermission
                    strAccessPermission += CInt(AccessPermission.Module_ID) _
                    & "|" & CInt(AccessPermission.View_Permission) & "|" _
                    & CInt(AccessPermission.Add_Permission) & "|" & _
                    CInt(AccessPermission.Save_Permission) & "|" & _
                    CInt(AccessPermission.Delete_Permission) & "|" & _
                    CInt(AccessPermission.Approve_Permission) & "|"
                Next
            End If
        End Sub

#End Region

    End Class

End Namespace
