Imports System.Windows.Forms

Public Class Membership

#Region "Class Membership Declarations"

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
        ReportDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\templates"
    End Sub

#End Region

#Region "Class Membership Class Declarations"

    Public Function NewclsMemberInfoAndAccounts()
        Try
            NewclsMemberInfoAndAccounts = New MemberInfoAndAccounts.MemberInfoAndAccounts
            Return NewclsMemberInfoAndAccounts
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Membership Forms Declarations"

    Public Function NewfrmMemberInfoAndAccounts() As Form
        Try
            NewfrmMemberInfoAndAccounts = New frmMemberInfoAndAccounts
            Return NewfrmMemberInfoAndAccounts
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberInfoAndAccountsFinder() As Form
        Try
            NewfrmMemberInfoAndAccountsFinder = New frmMemberInfoAndAccountsFinder
            Return NewfrmMemberInfoAndAccountsFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


#End Region

End Class
