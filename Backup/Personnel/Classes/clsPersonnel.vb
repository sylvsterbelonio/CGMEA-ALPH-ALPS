Imports System.Windows.Forms

Public Class Personnel

#Region "Class Personnel Declarations"

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

#Region "Class Personnel Class Declarations"

    Public Function NewclsLGU()
        Try
            NewclsLGU = New LGU.LGU
            Return NewclsLGU
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsDepartment()
        Try
            NewclsDepartment = New Department.Department
            Return NewclsDepartment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMember()
        Try
            NewclsMember = New Member.Member
            Return NewclsMember
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewclsMemberManagement()
        Try
            NewclsMemberManagement = New MemberManagement.MemberManagement
            Return NewclsMemberManagement
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

#Region "Class Personnel Forms Declarations"

    Public Function NewfrmLGU() As Form
        Try
            NewfrmLGU = New frmLGU
            Return NewfrmLGU
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmLGUFinder() As Form
        Try
            NewfrmLGUFinder = New frmLGUFinder
            Return NewfrmLGUFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmDepartment() As Form
        Try
            NewfrmDepartment = New frmDepartment
            Return NewfrmDepartment
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmDepartmentFinder() As Form
        Try
            NewfrmDepartmentFinder = New frmDepartmentFinder
            Return NewfrmDepartmentFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMember() As Form
        Try
            NewfrmMember = New frmMember
            Return NewfrmMember
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberFinder() As Form
        Try
            NewfrmMemberFinder = New frmMemberFinder
            Return NewfrmMemberFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberReassign() As Form
        Try
            NewfrmMemberReassign = New frmMemberReassign
            Return NewfrmMemberReassign
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberReassignFinder() As Form
        Try
            NewfrmMemberReassignFinder = New frmMemberReassignFinder
            Return NewfrmMemberReassignFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberReplace() As Form
        Try
            NewfrmMemberReplace = New frmMemberReplace
            Return NewfrmMemberReplace
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberReplaceFinder() As Form
        Try
            NewfrmMemberReplaceFinder = New frmMemberReplaceFinder
            Return NewfrmMemberReplaceFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberRetire() As Form
        Try
            NewfrmMemberRetire = New frmMemberRetire
            Return NewfrmMemberRetire
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NewfrmMemberRetireFinder() As Form
        Try
            NewfrmMemberRetireFinder = New frmMemberRetireFinder
            Return NewfrmMemberRetireFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

End Class
