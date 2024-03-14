Imports MySql.Data.MySqlClient

Namespace CollectionFee

    Public Class CollectionFee

#Region "Class CollectionFee Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritCollectionName As String
        Private CritCollectionCode As String

        Private feeId As Integer
        Private revisionId As Integer
        Private revisionCode As String
        Private typeId As Integer
        Private typeName As String
        Private typeCode As String
        Private feeType As Integer
        Private feeTypeName As String
        Private feeDefault As Double

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class CollectionFee Public Property Variable Declaration"

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

        <CLSCompliant(False)> _
        Public Property _revisionId() As Integer
            Get
                Return revisionId
            End Get
            Set(ByVal value As Integer)
                If revisionId = value Then
                    Return
                End If
                revisionId = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _revisionCode() As String
            Get
                Return revisionCode
            End Get
            Set(ByVal value As String)
                If revisionCode = value Then
                    Return
                End If
                revisionCode = value
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
            Set(ByVal value As String)
                If typeCode = value Then
                    Return
                End If
                typeCode = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _feeType() As Integer
            Get
                Return feeType
            End Get
            Set(ByVal value As Integer)
                If feeType = value Then
                    Return
                End If
                feeType = value
            End Set
        End Property

        <CLSCompliant(False)> _
      Public Property _feeTypeName() As String
            Get
                Return feeTypeName
            End Get
            Set(ByVal value As String)
                If feeTypeName = value Then
                    Return
                End If
                feeTypeName = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _feeDefault() As Double
            Get
                Return feeDefault
            End Get
            Set(ByVal Value As Double)
                If feeDefault = Value Then
                    Return
                End If
                feeDefault = Value
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

#Region "Class CollectionFee Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spCollectionFeeSave(" & feeId & "," & revisionId & ",'" & revisionCode & "'," & typeId & ",'" & typeName & "'," & feeType & ",'" & feeDefault & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In Me.dtSave.Rows
                        feeId = Me.dtSaveRow("feeId")
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
                strSql = "CALL spCollectionFeeDelete(" & feeId & "," & updatedBy & ");"
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

                    strSql = "CALL spCollectionFeeFind(" & typeId & ",'" & CritCollectionName & "','" & CritCollectionCode & "'," & initFlag & ");"

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

                    strSql = "CALL spCollectionFeeFind(" & initFlag & ",'','',2);"

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
                        Me.feeId = Trim(myRow1("feeId").ToString)
                        Me.revisionId = Trim(myRow1("revisionId").ToString)
                        Me.revisionCode = Trim(myRow1("revisionCode").ToString)
                        Me.typeId = Trim(myRow1("typeId").ToString)
                        Me.typeName = Trim(myRow1("typeName").ToString)
                        Me.feeType = Trim(myRow1("feeType").ToString)
                        'Me.feeTypeName = Trim(myRow1("feeTypeName").ToString)
                        Me.feeDefault = Trim(myRow1("feeDefault").ToString)
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

        Public Function GetRevisionList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spRevisionGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

#End Region

#Region "Class CollectionFee Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritCollectionName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCollectionName))
                CritCollectionCode = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritCollectionCode))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                revisionCode = .ReplaceSingleQuotes(revisionCode)
                typeName = .ReplaceSingleQuotes(typeName)
                feeType = .ReplaceSingleQuotes(feeType)
                feeDefault = .ReplaceSingleQuotes(feeDefault)
            End With
        End Sub

#End Region

    End Class

End Namespace

