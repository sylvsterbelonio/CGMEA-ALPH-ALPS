Imports System.Xml
Imports System.Windows.Forms
Module modPublic

    Friend gAssemblyProduct As String
    Friend gConnStringFileName As String
    Friend gApplicationPath As String
    Friend gRoleID As Integer
    Friend ImageDir As String
    Friend PresetDir As String
    Friend ReportDir As String
    Friend PluginDir As String

    Public gServerNamex As String = "localhost"
    Public gPorts As String = "3306"
    Public gUsername As String = "root"
    Public gDatabaseNames As String = "cgmea_alps"
    Public gPasswords As String = "password"
    Public guserID As String = "1"

    Public Function ReadConnString(ByVal fn As String, ByRef gConnectionString As String, Optional ByRef gServerName As String = "", Optional ByRef gPort As String = "", Optional ByRef gUserID As String = "", Optional ByRef gPassword As String = "", Optional ByRef gDatabaseName As String = "") As String
        Dim Doc As New XmlDocument
        Dim Root As XmlElement

        Try
            Doc.Load(fn)
            Root = Doc.DocumentElement.Item("Connection")

            With Root
                gConnectionString = Crypt(.InnerText)
                If gServerNamex = "" Then
                    gServerNamex = Crypt(.Attributes("Server").InnerText)
                End If
                If gPorts = "" Then
                    gPorts = Crypt(.Attributes("Port").InnerText)
                End If
                If gUsername = "" Then
                    gUsername = Crypt(.Attributes("UserID").InnerText)
                End If
                If gPasswords = "" Then
                    gPasswords = Crypt(.Attributes("Password").InnerText)
                End If
                If gDatabaseNames = "" Then
                    gDatabaseNames = Crypt(.Attributes("Database").InnerText)
                End If
            End With

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function Crypt(ByVal Text As String) As String
        Dim strTempChar As String = ""
        Dim i As Integer

        For i = 1 To Len(Text)
            'Decrypt
            If Asc(Mid$(Text, i, 1)) < 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) + 128
                'Encrypt
            ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                strTempChar = Asc(Mid$(Text, i, 1)) - 128
            End If
            Mid$(Text, i, 1) = Chr(strTempChar)
        Next i

        Crypt = Text
    End Function

    Public Sub Connect(ByRef myquery As PowerNET8.mySQL.Init.SQL)
        ReadConnString(gConnStringFileName, "", gServerNamex, gPorts, gUsername, gPasswords, gDatabaseNames)
        myquery.connectDatabase(gServerNamex, gPorts, gUsername, gPasswords, gDatabaseNames)
    End Sub

End Module
