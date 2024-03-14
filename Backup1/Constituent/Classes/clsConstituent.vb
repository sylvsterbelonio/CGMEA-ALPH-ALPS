Imports System.Windows.Forms

Public Class Constituent

#Region "Class Constituent Declarations"

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

    Public WriteOnly Property UseRecordCd() As String
        Set(ByVal value As String)
            If Use_Record_Cd = value Then
                Return
            End If
            Use_Record_Cd = value
        End Set
    End Property

    Public WriteOnly Property UseRecordName() As String
        Set(ByVal value As String)
            If Use_Record_Name = value Then
                Return
            End If
            Use_Record_Name = value
        End Set
    End Property

    Public Sub New(ByVal fn As String, ByVal path As String, ByVal userId As Integer, ByVal roleId As Integer, ByVal gProduct As String)
        gConnStringFileName = fn
        gApplicationPath = path
        gUserID = userId
        gRoleID = roleId
        gAssemblyProduct = gProduct
        ImageDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\images"
        PresetDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\presets"
    End Sub

#End Region

#Region "Class Constituent Class Declarations"

    Public Function NewclsConstituents()
        Try
            NewclsConstituents = New Constituents.Constituents
            Return NewclsConstituents
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Constituent Forms Declarations"

    Public Function NewfrmConstituent() As Form
        Try
            NewfrmConstituent = New frmConstituent
            Return NewfrmConstituent
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmConstituentFinder() As Form
        Try
            NewfrmConstituentFinder = New frmConstituentFinder
            Return NewfrmConstituentFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class
