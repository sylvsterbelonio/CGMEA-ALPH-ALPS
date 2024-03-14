Imports MySql.Data.MySqlClient

Public Class Permission

    Private RoleID As Integer
    Private UserID As Integer
    Private AddPermission As Integer
    Private EditPermission As Integer
    Private ViewPermission As Integer
    Private DeletePermission As Integer
    Private ApprovePermission As Integer

    Private FormName As String
    Private strState As String
    Private SQLStmt As String

    Public Const RETURN_TYPE_DATASET = "DATASET"
    Public Const RETURN_TYPE_DATATABLE = "DATATABLE"

    Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

    Public WriteOnly Property Role_ID() As Integer
        Set(ByVal value As Integer)
            If RoleID = value Then
                Return
            End If
            RoleID = value
        End Set
    End Property

    Public WriteOnly Property User_ID() As Integer
        Set(ByVal value As Integer)
            If UserID = value Then
                Return
            End If
            UserID = value
        End Set
    End Property

    Public ReadOnly Property Add_Permission() As Integer
        Get
            Return AddPermission
        End Get
    End Property

    Public ReadOnly Property Edit_Permission() As Integer
        Get
            Return EditPermission
        End Get
    End Property

    Public ReadOnly Property View_Permission() As Integer
        Get
            Return ViewPermission
        End Get
    End Property

    Public ReadOnly Property Delete_Permission() As Integer
        Get
            Return DeletePermission
        End Get
    End Property

    Public ReadOnly Property Approve_Permission() As Integer
        Get
            Return ApprovePermission
        End Get
    End Property

    Public Property Form_Name() As String
        Get
            Return FormName
        End Get
        Set(ByVal value As String)
            If FormName = value Then
                Return
            End If
            FormName = value
        End Set
    End Property

    Public Property str_State() As String
        Get
            Return strState
        End Get
        Set(ByVal value As String)
            If strState = value Then
                Return
            End If
            strState = value
        End Set
    End Property

    Public Sub New(ByVal fn As String)
        gConnStringFileName = fn
    End Sub

    Public Sub SetPermission()
        Dim FormId As Integer
        Dim DataId As DataTable
        Dim DataPermission As DataTable
        Dim DataRowId As DataRow
        Dim DataRowPermission As DataRow
        Dim sqlStmt As String
        Dim clsDataAccess As New DataAccess(gConnStringFileName)

        AddPermission = 0 'Add
        EditPermission = 0  'Edit
        DeletePermission = 0  'Delete
        ViewPermission = 0  'View
        ApprovePermission = 0  'Approve
        FormId = 0

        Try
            sqlStmt = "CALL spDetermineFormId('" & FormName & "');"
            DataId = clsDataAccess.ExecuteQuery(sqlStmt, True, RETURN_TYPE_DATATABLE)
            For Each DataRowId In DataId.Rows
                Try
                    sqlStmt = "CALL spDeterminePermission(" & CStr(DataRowId(0)) & "," & CStr(RoleID) & ");"
                    DataPermission = clsDataAccess.ExecuteQuery(sqlStmt, True, RETURN_TYPE_DATATABLE)
                    For Each DataRowPermission In DataPermission.Rows
                        AddPermission = DataRowPermission(0) ' add
                        EditPermission = DataRowPermission(1) ' edit
                        DeletePermission = DataRowPermission(2) ' Delete
                        ViewPermission = DataRowPermission(3) ' View
                        ApprovePermission = DataRowPermission(4) ' View
                    Next
                    DataId = Nothing
                    DataPermission = Nothing
                    DataRowId = Nothing
                    DataRowPermission = Nothing
                Catch ex As MySqlException
                    'error was encountered while populating record
                    RaiseEvent MsgArrival(ex.Message, False)
                    DataPermission = Nothing
                    DataRowPermission = Nothing
                End Try

            Next
        Catch ex As MySqlException
            'error was encountered while populating record
            RaiseEvent MsgArrival(ex.Message, False)
            DataId = Nothing
            DataRowId = Nothing
        End Try

    End Sub
End Class
