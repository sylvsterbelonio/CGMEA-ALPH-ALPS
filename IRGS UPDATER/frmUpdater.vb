Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Security.Permissions
Imports System.IO
Public Class frmUpdater

    Dim updateDir As String = "\\192.168.10.254\cgmea\"
    Dim distinationDir As String = My.Application.Info.DirectoryPath & "\"
    Dim countFiles As Integer = 0

    <DllImport("advapi32.DLL", SetLastError:=True)> _
    Public Shared Function LogonUser(ByVal lpszUsername As String, ByVal lpszDomain As String, _
        ByVal lpszPassword As String, ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
        ByRef phToken As IntPtr) As Integer
    End Function


    Private Sub frmUpdater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim admin_token As IntPtr
        Dim wid_current As WindowsIdentity = WindowsIdentity.GetCurrent()
        Dim wid_admin As WindowsIdentity = Nothing
        Dim wic As WindowsImpersonationContext = Nothing
        Dim serverFiles() As String
        Dim statServer As String = Nothing
        Dim statLocal As String = Nothing
        Dim statStatus As String = Nothing

        dgvFiles.Rows.Clear()
        dgvFiles.Refresh()
        countFiles = 0

        Try
            'MessageBox.Show("Copying file...")
            If LogonUser("cgmea", "192.168.10.254", "cgmea4ever", 9, 0, admin_token) <> 0 Then
                wid_admin = New WindowsIdentity(admin_token)
                wic = wid_admin.Impersonate()
                'File.Copy("\\192.168.0.120\IRGS INSTALLER\dlls individual\assessment.dll", "d:\temp\ass.dll", True)
                serverFiles = Directory.GetFiles(updateDir)
                For Each serverFile As String In serverFiles
                    statLocal = ""
                    statServer = serverFile.Replace(updateDir, "") & "  [" & File.GetLastWriteTime(serverFile) & "]"
                    If File.Exists(distinationDir & serverFile.Replace(updateDir, "")) Then
                        statLocal = File.GetLastWriteTime(distinationDir & serverFile.Replace(updateDir, ""))
                        If File.GetLastWriteTime(serverFile) > File.GetLastWriteTime(distinationDir & serverFile.Replace(updateDir, "")) Then
                            statStatus = "outdated"
                            '   File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                            countFiles += 1
                        Else
                            statStatus = "updated"
                        End If
                    Else
                        statStatus = "missing"
                        '  File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                        countFiles += 1
                    End If
                    dgvFiles.Rows.Add(statServer, statLocal, statStatus)
                    ' MsgBox(CStr(File.GetCreationTime(serverFile)))
                Next

                Dim subDirs() As String
                subDirs = Directory.GetDirectories(updateDir)


                For Each subDIR As String In subDirs
                    'copy files in subdirectory

                    serverFiles = Directory.GetFiles(subDIR)

                    For Each serverFile As String In serverFiles
                        statLocal = ""
                        statServer = serverFile.Replace(subDIR & "\", "") & "  [" & File.GetLastWriteTime(serverFile) & "]"

                        If File.Exists(distinationDir & serverFile.Replace(updateDir, "")) Then

                            statLocal = File.GetLastWriteTime(distinationDir & serverFile.Replace(updateDir, ""))

                            If File.GetLastWriteTime(serverFile) > File.GetLastWriteTime(distinationDir & serverFile.Replace(updateDir, "")) Then
                                statStatus = "outdated"
                                '   File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                                countFiles += 1
                            Else
                                statStatus = "updated"
                            End If
                        Else
                            statStatus = "missing"
                            '  File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                            countFiles += 1
                        End If
                        dgvFiles.Rows.Add(statServer, statLocal, statStatus)
                        ' MsgBox(CStr(File.GetCreationTime(serverFile)))
                    Next

                Next

                'MessageBox.Show("Copy succeeded")
            Else
                MessageBox.Show("Copy Failed")
            End If
        Catch se As System.Exception
            Dim ret As Integer = Marshal.GetLastWin32Error()
            MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString())
            MessageBox.Show(se.Message)
        Finally
            If wic IsNot Nothing Then
                wic.Undo()
            End If
        End Try

        If countFiles <> 0 Then
            btnContinue.Text = "[" & CStr(countFiles) & "] Update and Continue"
        Else
            btnContinue.Text = "Continue"
        End If
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        If countFiles <> 0 Then
            Dim admin_token As IntPtr
            Dim wid_current As WindowsIdentity = WindowsIdentity.GetCurrent()
            Dim wid_admin As WindowsIdentity = Nothing
            Dim wic As WindowsImpersonationContext = Nothing
            Dim serverFiles() As String

            Try
                'MessageBox.Show("Copying file...")
                If LogonUser("cgmea", "192.168.10.254", "cgmea4ever", 9, 0, admin_token) <> 0 Then
                    wid_admin = New WindowsIdentity(admin_token)
                    wic = wid_admin.Impersonate()
                    serverFiles = Directory.GetFiles(updateDir)

                    For Each serverFile As String In serverFiles
                        If File.Exists(distinationDir & serverFile.Replace(updateDir, "")) Then
                            If File.GetLastWriteTime(serverFile) > File.GetLastWriteTime(distinationDir & serverFile.Replace(updateDir, "")) Then
                                File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                            End If
                        Else
                            File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                        End If
                    Next

                    Dim subDirs() As String
                    subDirs = Directory.GetDirectories(updateDir)


                    For Each subDIR As String In subDirs
                        'copy files in subdirectory

                        serverFiles = Directory.GetFiles(subDIR)

                        For Each serverFile As String In serverFiles
                            If File.Exists(distinationDir & serverFile.Replace(updateDir, "")) Then
                                If File.GetLastWriteTime(serverFile) > File.GetLastWriteTime(distinationDir & serverFile.Replace(updateDir, "")) Then
                                    File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                                End If
                            Else
                                File.Copy(serverFile, distinationDir & serverFile.Replace(updateDir, ""), True)
                            End If
                        Next

                    Next
                    'MessageBox.Show("Copy succeeded")
                Else
                    MessageBox.Show("Copy Failed")
                End If
            Catch se As System.Exception
                Dim ret As Integer = Marshal.GetLastWin32Error()
                MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString())
                MessageBox.Show(se.Message)
            Finally
                If wic IsNot Nothing Then
                    wic.Undo()
                End If
            End Try
        End If
        Process.Start("CGMEA.exe")
        Me.Close()
    End Sub
End Class
