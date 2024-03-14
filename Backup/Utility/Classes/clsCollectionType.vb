Imports System.IO
Imports MySql.Data.MySqlClient

Namespace CollectionType

    Public Class CollectionType

#Region "Class CollectionType Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritCollectionName As String
        Private CritCollectionCode As String

        Private typeId As Integer
        Private typeName As String
        Private typeCode As String
        Private loanRequired As Integer
        Private typeDescription As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class CollectionType Public Property Variable Declaration"

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
        Public WriteOnly Property _CritCollectionName() As String
            Set(ByVal Value As String)
                If CritCollectionName = Value Then
                    Return
                End If
                CritCollectionName = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public WriteOnly Property _CritCollectionCode() As String
            Set(ByVal Value As String)
                If CritCollectionCode = Value Then
                    Return
                End If
                CritCollectionCode = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _typeId() As Integer
            Get
                Return typeId
            End Get
            Set(ByVal value As Integer)
                If typeId = value Then
                    Return
                End If
                typeId = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _typeName() As String
            Get
                Return typeName
            End Get
            Set(ByVal value As String)
                If typeName = value Then
                    Return
                End If
                typeName = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _typeCode() As String
            Get
                Return typeCode
            End Get
            Set(ByVal Value As String)
                If typeCode = Value Then
                    Return
                End If
                typeCode = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _loanRequired() As Integer
            Get
                Return loanRequired
            End Get
            Set(ByVal Value As Integer)
                If loanRequired = Value Then
                    Return
                End If
                loanRequired = Value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _typeDescription() As String
            Get
                Return typeDescription
            End Get
            Set(ByVal value As String)
                If typeDescription = value Then
                    Return
                End If
                typeDescription = value
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

#Region "Class CollectionType Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spCollectionTypeSave(" & typeId & ",'" & typeName & "','" & typeCode & "'," & loanRequired & ",'" & typeDescription & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        typeId = Me.dtSaveRow("typeId")
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
                strSql = "CALL spCollectionTypeDelete(" & typeId & "," & updatedBy & ");"
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

                    strSql = "CALL spCollectionTypeFind(" & typeId & ",'" & CritCollectionName & "','" & CritCollectionCode & "'," & initFlag & ");"

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

                    strSql = "CALL spCollectionTypeFind(" & initFlag & ",'','',2);"

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
                        Me.typeId = Trim(myRow1("typeId").ToString)
                        Me.typeName = Trim(myRow1("typeName").ToString)
                        Me.typeCode = Trim(myRow1("typeCode").ToString)
                        Me.loanRequired = Trim(myRow1("loanRequired").ToString)
                        Me.typeDescription = Trim(myRow1("typeDescription").ToString)

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

#Region "Class CollectionType Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritCollectionName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCollectionName))
                CritCollectionCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCollectionCode))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                typeName = .ReplaceSingleQuotes(typeName)
                typeCode = .ReplaceSingleQuotes(typeCode)
                typeDescription = .ReplaceSingleQuotes(typeDescription)
            End With
        End Sub

#End Region

    End Class

End Namespace

