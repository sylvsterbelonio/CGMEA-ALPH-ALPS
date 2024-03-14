Imports System.Windows.Forms

Public Class Systems

#Region "Class Systems Declarations"

    Public Sub New(ByVal fn As String, ByVal path As String, ByVal userId As Integer, ByVal roleId As Integer, ByVal gProduct As String)
        gConnStringFileName = fn
        gApplicationPath = path
        gUserID = userId
        gRoleID = roleId
        gAssemblyProduct = gProduct
        ImageDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\images"
        PresetDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\presets"
    End Sub

    Public WriteOnly Property UseRecordState() As String
        Set(ByVal value As String)
            If Use_Record_State = value Then
                Return
            End If
            Use_Record_State = value
        End Set
    End Property

    Public WriteOnly Property UseRecordId() As String
        Set(ByVal value As String)
            If Use_Record_Id = value Then
                Return
            End If
            Use_Record_Id = value
        End Set
    End Property




#End Region

#Region "Class Systems Class Declarations"

    Public Function NewclsSystemAccessLevel()
        Try
            NewclsSystemAccessLevel = New SystemAccessLevel.SystemAccessLevel
            Return NewclsSystemAccessLevel
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsSystemParameter()
        Try
            NewclsSystemParameter = New SystemParameter.SystemParameter
            Return NewclsSystemParameter
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsSystemUser()
        Try
            NewclsSystemUser = New SystemUser.SystemUser
            Return NewclsSystemUser
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Systems Forms Declarations"

    Public Function NewfrmSystemUser() As Form
        Try
            NewfrmSystemUser = New frmSystemUser
            Return NewfrmSystemUser
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NwfrmSystemUserFinder() As Form
        Try
            NwfrmSystemUserFinder = New frmSystemUserFinder
            Return NwfrmSystemUserFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NwfrmSystemParameter() As Form
        Try
            NwfrmSystemParameter = New frmSystemParameter
            Return NwfrmSystemParameter
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NwfrmSystemParameterFinder() As Form
        Try
            NwfrmSystemParameterFinder = New frmSystemParameterFinder
            Return NwfrmSystemParameterFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NwfrmSystemAccessLevel() As Form
        Try
            NwfrmSystemAccessLevel = New frmSystemAccessLevel
            Return NwfrmSystemAccessLevel
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NwfrmSystemAccessLevelFinder() As Form
        Try
            NwfrmSystemAccessLevelFinder = New frmSystemAccessLevelFinder
            Return NwfrmSystemAccessLevelFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class