Imports MySql.Data.MySqlClient

Namespace Barangay

    Public Class Barangay

#Region "Class Barangay Variable Declaration"

        Private initFlag As Integer
        Private dtgRID As DataTable

        Private CritProvinceName As String
        Private CritMunicipalityName As String
        Private CritBrgyName As String
        Private CritBrgyCode As String

        Private brgyId As Integer
        Private rurCode As String
        Private brgyName As String
        Private mCode As String
        Private bIndex As String
        Private dIndex As String

        Private updatedBy As Integer
        Private updatedDt As String

        Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

        Private clsDataAccess As New DataAccess.DataAccess(gConnStringFileName)
        Private clsCommon As New Common.Common
        Private dtSave As DataTable
        Private dtSaveRow As DataRow

#End Region

#Region "Class Barangay Public Property Variable Declaration"

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

        Public WriteOnly Property CritProvince_Name() As String
            Set(ByVal value As String)
                If CritProvinceName = value Then
                    Return
                End If
                CritProvinceName = value
            End Set
        End Property

        Public WriteOnly Property CritMunicipality_Name() As String
            Set(ByVal value As String)
                If CritMunicipalityName = value Then
                    Return
                End If
                CritMunicipalityName = value
            End Set
        End Property

        Public WriteOnly Property CritBrgy_Name() As String
            Set(ByVal value As String)
                If CritBrgyName = value Then
                    Return
                End If
                CritBrgyName = value
            End Set
        End Property

        Public WriteOnly Property CritBrgy_Code() As String
            Set(ByVal value As String)
                If CritBrgyCode = value Then
                    Return
                End If
                CritBrgyCode = value
            End Set
        End Property

        Public Property Barangay_Id() As Integer
            Get
                Return brgyId
            End Get
            Set(ByVal value As Integer)
                If brgyId = value Then
                    Return
                End If
                brgyId = value
            End Set
        End Property

        Public Property rur_Code() As String
            Get
                Return rurCode
            End Get
            Set(ByVal value As String)
                If rurCode = value Then
                    Return
                End If
                rurCode = value
            End Set
        End Property

        Public Property Barangay_Name() As String
            Get
                Return brgyName
            End Get
            Set(ByVal value As String)
                If brgyName = value Then
                    Return
                End If
                brgyName = value
            End Set
        End Property

        Public Property m_Code() As String
            Get
                Return mCode
            End Get
            Set(ByVal value As String)
                If mCode = value Then
                    Return
                End If
                mCode = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _bIndex() As String
            Get
                Return bIndex
            End Get
            Set(ByVal value As String)
                If bIndex = value Then
                    Return
                End If
                bIndex = value
            End Set
        End Property

        <CLSCompliant(False)> _
        Public Property _dIndex() As String
            Get
                Return dIndex
            End Get
            Set(ByVal value As String)
                If dIndex = value Then
                    Return
                End If
                dIndex = value
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

#Region "Class Barangay Public Functions"

        Public Function Save_Record() As Boolean
            Try
                Dim strSql As String
                Dim ErrorMsg As String = ""
                Dim arr As ArrayList = Nothing

                Clean_Parameters_Save()

                Save_Record = True
                strSql = "CALL spSpatialBrgySave(" & brgyId & ",'" & rurCode & "','" & brgyName & "','" & mCode & "','" & bIndex & "','" & dIndex & "'," & updatedBy & ",'" & updatedDt & "');"

                Me.dtSave = clsDataAccess.ExecuteQuery(strSql, True, RETURN_TYPE_DATATABLE)

                For Each Me.dtSaveRow In Me.dtSave.Rows
                    ErrorMsg = Trim(Me.dtSaveRow("ErrorMessage").ToString)
                Next

                If ErrorMsg <> "" Then
                    RaiseEvent MsgArrival(ErrorMsg, False)
                    Return False
                Else
                    For Each Me.dtSaveRow In dtSave.Rows
                        brgyId = Me.dtSaveRow("brgyId")
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
                strSql = "CALL spSpatialBrgyDelete(" & brgyId & "," & updatedBy & ");"
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

                    strSql = "CALL spSpatialBrgyFind(" & brgyId & ",'" & CritProvinceName & "','" & CritMunicipalityName & "','" & CritBrgyCode & "','" & CritBrgyName & "'," & initFlag & ");"

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

                    strSql = "CALL spSpatialBrgyFind(" & initFlag & ",'','','','',2);"

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
                        Me.brgyId = Trim(myRow1("brgyId").ToString)
                        Me.rurCode = Trim(myRow1("rurCode").ToString)
                        Me.brgyName = Trim(myRow1("brgyName").ToString)
                        Me.mCode = Trim(myRow1("mCode").ToString)
                        Me.bIndex = Trim(myRow1("bIndex").ToString)
                        Me.dIndex = Trim(myRow1("dIndex").ToString)

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

        Public Function GetRegionList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialRegionGet();"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetProvinceList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialProvinceGet('" & Microsoft.VisualBasic.Left(mCode, 2) & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

        Public Function GetMunicipalityList() As DataSet
            Dim dataList As DataSet
            Dim sqlComboStmt As String

            Try
                sqlComboStmt = "CALL spSpatialMunicipalityGet('" & Microsoft.VisualBasic.Left(mCode, 4) & "');"
                dataList = clsDataAccess.ExecuteQuery(sqlComboStmt, False, RETURN_TYPE_DATASET)
            Catch ex As MySqlException
                RaiseEvent MsgArrival(ex.Message, False)
                dataList = Nothing
            End Try
            Return dataList
        End Function

#End Region

#Region "Class Barangay Private Sub"

        Private Sub Clean_Parameters_Search()
            With clsCommon
                CritProvinceName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritProvinceName))
                CritMunicipalityName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritMunicipalityName))
                CritBrgyName = .RemoveRepeatingWildcards(.ReplaceSingleQuotes(CritBrgyName))
            End With
        End Sub

        Private Sub Clean_Parameters_Save()
            With clsCommon
                rurCode = .ReplaceSingleQuotes(rurCode)
                brgyName = .ReplaceSingleQuotes(brgyName)
                mCode = .ReplaceSingleQuotes(mCode)
                bIndex = .ReplaceSingleQuotes(bIndex)
                dIndex = .ReplaceSingleQuotes(dIndex)
            End With
        End Sub

#End Region

    End Class

End Namespace
