Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO
Imports System.Xml
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Windows.Forms.Cursors
Imports System.Text
Imports System.Net.Mail
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared

Public Class Common

    Private p_Doc As New XmlDocument
    Private Conn As MySqlConnection

    Private ConnectionStateString As String
    Private ConnectionQualityString As String = "Off"
    Private ConnectionColor As Color

    Public Declare Function ShowWindow Lib "user32" (ByVal hWnd As System.IntPtr, ByVal nCmdShow As Integer) As Boolean
    Public Declare Function SetParent Lib "user32" (ByVal hWndChild As System.IntPtr, ByVal hWndNewParent As System.IntPtr) As System.IntPtr
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As System.IntPtr) As Integer

    Public Declare Function RemoveMenu Lib "user32" (ByVal hMenu As IntPtr, ByVal nPosition As Integer, ByVal wFlags As Long) As IntPtr
    Public Declare Function GetSystemMenu Lib "user32" (ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
    Public Declare Function GetMenuItemCount Lib "user32" (ByVal hMenu As IntPtr) As Integer
    Public Declare Function DrawMenuBar Lib "user32" (ByVal hwnd As IntPtr) As Boolean

    '--The capGetDriverDescription function retrieves the version 
    ' description of the capture driver--
    Public Declare Function capGetDriverDescriptionA Lib "avicap32.dll" _
       (ByVal wDriverIndex As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, _
        ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    '--The capCreateCaptureWindow function creates a capture window--
    Public Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
       (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWnd As Integer, _
        ByVal nID As Integer) As Integer

    '--This function sends the specified message to a window or windows--
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
       (ByVal hwnd As Integer, ByVal Msg As Integer, _
        ByVal wParam As Integer, _
       <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    '--Sets the position of the window relative to the screen buffer--
    Public Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" _
       (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, _
        ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, _
        ByVal wFlags As Integer) As Integer

    '--This function destroys the specified window--
    Public Declare Function DestroyWindow Lib "user32" _
       (ByVal hndw As Integer) As Boolean

    Private CaptureImage As PictureBox
    Private hWnd As Integer

    Public ReadOnly Property ConnectionState_String() As String
        Get
            Return ConnectionStateString
        End Get
    End Property

    Public ReadOnly Property ConnectionQuality_String() As String
        Get
            Return ConnectionQualityString
        End Get
    End Property

    Public ReadOnly Property Connection_Color() As Color
        Get
            Return ConnectionColor
        End Get
    End Property

    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpSFlags As Int32, ByVal dwReserved As Int32) As Boolean

    Public Enum InetConnState
        modem = &H1
        lan = &H2
        proxy = &H4
        ras = &H10
        offline = &H20
        configured = &H40
    End Enum

    Public Event MsgArrival(ByVal Message As String, ByVal SuccessFl As Boolean)

#Region "Class Common Functions"

    '*************************************************************
    'NAME:          WriteToEventLog
    'PURPOSE:       Write to Event Log
    'PARAMETERS:    Entry - Value to Write
    '               AppName - Name of Client Application. Needed 
    '               because before writing to event log, you must 
    '               have a named EventLog source. 
    '               EventType - Entry Type, from EventLogEntryType 
    '               Structure e.g., EventLogEntryType.Warning, 
    '               EventLogEntryType.Error
    '               LogNam1e: Name of Log (System, Application; 
    '               Security is read-only) If you 
    '               specify a non-existent log, the log will be
    '               created

    'RETURNS:       True if successful
    '*************************************************************
    Public Function WriteToEventLog(ByVal entry As String, _
                    Optional ByVal appName As String = "CompanyName", _
                    Optional ByVal eventType As  _
                    EventLogEntryType = EventLogEntryType.Information, _
                    Optional ByVal logName As String = "ProductName") As Boolean

        Dim objEventLog As New EventLog

        Try
            'Register the Application as an Event Source
            If Not EventLog.SourceExists(appName) Then
                EventLog.CreateEventSource(appName, logName)
            End If

            'log the entry
            objEventLog.Source = appName
            objEventLog.WriteEntry(entry, eventType)

            Return True
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Public Function IsConnectionAvailable() As Boolean
        'Call url
        Dim url As New System.Uri("http://www.google.com/")
        'Request for request
        Dim req As System.Net.WebRequest
        req = System.Net.WebRequest.Create(url)
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try
    End Function

    Public Function RoundToValue(ByVal nValue As Double, ByVal nCeiling As Integer, Optional ByVal RoundUp As Boolean = True) As Integer
        Dim tmp As Integer
        Dim tmpVal
        If Not IsNumeric(nValue) Then
            RoundToValue = Nothing
            Exit Function
        End If

        nValue = CDbl(nValue)

        'Round up to a whole integer -
        'Any decimal value will force a round to the next integer.
        'i.e. 0.01 = 1 or 0.8 = 1

        tmpVal = ((nValue / nCeiling) + (-0.5 + (RoundUp And 1)))
        tmp = Fix(tmpVal)
        tmpVal = CInt((tmpVal - tmp) * 10 ^ 0)
        nValue = tmp + tmpVal / 10 ^ 0

        'Multiply by ceiling value to set RoundtoValue
        RoundToValue = nValue * nCeiling
    End Function

    Public Function ConvertoDate(ByVal dateString As String, ByRef result As DateTime) As Boolean
        Try
            Dim supportedFormats() As String = New String() {"MM/dd/yyyy", "MM/dd/yy", "ddMMMyyyy", "dMMMyyyy"}

            result = DateTime.ParseExact(dateString, supportedFormats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function ConvertoDate(ByVal dateString As String) As Date
        Dim supportedFormats() As String = New String() {"MM/dd/yyyy", "MM/dd/yy", "ddMMMyyyy", "dMMMyyyy"}

        Return DateTime.ParseExact(dateString, supportedFormats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None)
    End Function

    Public Function CheckInetConnection() As Boolean

        Dim lngFlags As Long
        CheckInetConnection = False

        If InternetGetConnectedState(lngFlags, 0) Then
            ' True
            If lngFlags And InetConnState.lan Then
                ConnectionStateString = "LAN."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.modem Then
                ConnectionStateString = "Modem."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.configured Then
                ConnectionStateString = "Configured."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.proxy Then
                ConnectionStateString = "Proxy"
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.ras Then
                ConnectionStateString = "RAS."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            ElseIf lngFlags And InetConnState.offline Then
                ConnectionStateString = "Offline."
                Select Case ConnectionQualityString
                    Case "Good"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Intermittent"
                        ConnectionColor = Color.Green
                        ConnectionQualityString = "Good"
                    Case "Off"
                        ConnectionColor = Color.DarkOrange
                        ConnectionQualityString = "Intermittent"
                End Select
            End If
        Else
            ' False
            ConnectionStateString = "Not Connected."
            Select Case ConnectionQualityString
                Case "Good"
                    ConnectionColor = Color.DarkOrange
                    ConnectionQualityString = "Intermittent"
                Case "Intermittent"
                    ConnectionColor = Color.Red
                    ConnectionQualityString = "Off"
                Case "Off"
                    ConnectionColor = Color.Red
                    ConnectionQualityString = "Off"
            End Select
        End If
    End Function

    'Write xml file
    Public Function WriteConnString(ByVal fn As String, _
                                    ByVal gServerName As String, _
                                    ByVal gPort As String, _
                                    ByVal gUserID As String, _
                                    ByVal gPassword As String, _
                                    ByVal gDatabaseName As String, _
                                    ByRef myFileStream As System.IO.FileStream _
                                    ) As Boolean
        Dim Root As XmlElement
        Dim Path As String
        Dim Reader As System.IO.StreamReader
        Dim tStr As String
        Dim aFileInfo As New System.IO.FileInfo(fn)

        Try
            If Not myFileStream Is Nothing Then
                myFileStream.Close()
            End If

            If File.Exists(fn) Then
                If (aFileInfo.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                    aFileInfo.Attributes = aFileInfo.Attributes And Not FileAttributes.Hidden
                End If
            End If

            Path = System.IO.Path.GetTempFileName()
            Reader = New System.IO.StreamReader(Path)
            tStr = Reader.ReadToEnd()
            'add the following elements to connection string
            p_Doc = New XmlDocument
            p_Doc.LoadXml("<" + modApp.AssemblyTitle + " Type='Connection String' Product='" + modApp.AssemblyProduct + "' Company='" + modApp.AssemblyCompany + "' Copyright='" + modApp.AssemblyCopyright + "' Version='" + modApp.AssemblyVersion + "'>" + tStr + "</" + modApp.AssemblyTitle + ">")
            Root = p_Doc.DocumentElement
            Dim ConnStr As XmlElement = p_Doc.CreateElement("Connection")
            Dim Server As XmlAttribute = p_Doc.CreateAttribute("Server")
            Dim Port As XmlAttribute = p_Doc.CreateAttribute("Port")
            Dim UserID As XmlAttribute = p_Doc.CreateAttribute("UserID")
            Dim Password As XmlAttribute = p_Doc.CreateAttribute("Password")
            Dim Database As XmlAttribute = p_Doc.CreateAttribute("Database")

            Server.InnerText = Crypt(gServerName)
            Port.InnerText = Crypt(gPort)
            UserID.InnerText = Crypt(gUserID)
            Password.InnerText = Crypt(gPassword)
            Database.InnerText = Crypt(gDatabaseName)

            With ConnStr.Attributes
                .Append(Server)
                .Append(Port)
                .Append(UserID)
                .Append(Password)
                .Append(Database)
            End With

            ConnStr.InnerText = Crypt("server=" & gServerName & "; port=" & gPort & "; uid=" & gUserID & "; pwd=" & gPassword & "; database=" & gDatabaseName & "; pooling=false")
            Root.AppendChild(ConnStr)

            Reader.Close()
            System.IO.File.Delete(Path)

            p_Doc.Save(fn)
            aFileInfo.Attributes = aFileInfo.Attributes Or FileAttributes.Hidden
            Return True
        Catch ex As System.Exception
            Throw ex
            Return False
        End Try
    End Function

    'Fetch xml file
    Public Function ReadConnString(ByVal fn As String, ByRef gConnectionString As String, Optional ByRef gServerName As String = "", Optional ByRef gPort As String = "", Optional ByRef gUserID As String = "", Optional ByRef gPassword As String = "", Optional ByRef gDatabaseName As String = "") As String
        Dim Doc As New XmlDocument
        Dim Root As XmlElement

        Try
            Doc.Load(fn)
            Root = Doc.DocumentElement.Item("Connection")

            With Root
                gConnectionString = Crypt(.InnerText)
                If gServerName = "" Then
                    gServerName = Crypt(.Attributes("Server").InnerText)
                End If
                If gPort = "" Then
                    gPort = Crypt(.Attributes("Port").InnerText)
                End If
                If gUserID = "" Then
                    gUserID = Crypt(.Attributes("UserID").InnerText)
                End If
                If gPassword = "" Then
                    gPassword = Crypt(.Attributes("Password").InnerText)
                End If
                If gDatabaseName = "" Then
                    gDatabaseName = Crypt(.Attributes("Database").InnerText)
                End If
            End With

            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetConnectionInfo(ByVal fn As String) As ConnectionInfo
        Dim Doc As New XmlDocument
        Dim Root As XmlElement

        Try
            Dim ci As New ConnectionInfo

            Doc.Load(fn)
            Root = Doc.DocumentElement.Item("Connection")

            With Root
                ci.ServerName = Crypt(.Attributes("Server").InnerText)
                ci.DatabaseName = Crypt(.Attributes("Database").InnerText)
                ci.UserID = Crypt(.Attributes("UserID").InnerText)
                ci.Password = Crypt(.Attributes("Password").InnerText)
            End With

            Return ci
        Catch ex As Exception
            RaiseEvent MsgArrival(ex.Message, False)
            Return Nothing
        End Try
    End Function

    'Check if MySQL server is running
    Public Function MySQLRunning(ByVal ConnStringFileName As String) As Boolean
        If Not Conn Is Nothing Then Conn.Close()

        Dim ConnStr As String = ""

        ReadConnString(ConnStringFileName, ConnStr)

        Try
            Conn = New MySqlConnection(ConnStr)
            Conn.Open()
            Return True
        Catch ex As MySqlException
            Prompt_User("error", "There is an error connecting to the database server: " + ex.Message + "." + vbCr + vbCr + "The host provided in your connection string maybe currently offline. Please make sure that the service is running before restarting the application. If this problem persists, please notify the system administrator immediately.")
            Return False
        End Try
    End Function

    'Encrypt/Decrypt string used for XML Connection String
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

    'Format messagebox
    Public Function Prompt_User(ByVal MessageType As String, ByVal Message As String) As Windows.Forms.DialogResult
        Select Case LCase(MessageType)
            Case "information"
                Prompt_User = MessageBox.Show(Message, modApp.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case "warning"
                Prompt_User = MessageBox.Show(Message, modApp.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Case "question"
                Prompt_User = MessageBox.Show(Message, modApp.AssemblyProduct, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Case "error"
                Prompt_User = MessageBox.Show(Message, modApp.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Case "yesnocancel"
                Prompt_User = MessageBox.Show(Message, modApp.AssemblyProduct, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Case Else
                Prompt_User = DialogResult.Ignore
        End Select
    End Function

    Public Function GetRegistrySetting(ByVal strSection As String, ByVal strKey As String) As String
        Return GetSetting(modApp.AssemblyTitle, strSection, strKey)
    End Function

    Public Function CheckIfServiceIsRunning(ByVal serviceName As String) As Boolean
        Dim mySC As ServiceProcess.ServiceController
        CheckIfServiceIsRunning = False

        mySC = New ServiceProcess.ServiceController(serviceName)
        If mySC.Status = ServiceProcess.ServiceControllerStatus.Stopped Then
            ' Service isn't running
            Return False
        ElseIf mySC.Status = ServiceProcess.ServiceControllerStatus.Running Then
            ' Service already running
            Return True
        End If
    End Function

    Public Function AppRunning()
        'Get number of processes of you program
        If Process.GetProcessesByName _
          (Process.GetCurrentProcess.ProcessName).Length > 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    'use this function when activating a childform that is already loaded based on the form name.
    Public Function GetMDIChildForm(ByVal frmMe As Form, ByVal strFormName As String, Optional ByVal strFormTag As String = "") As Form
        Dim ctl As Control
        Dim frmMdiChild As Form

        GetMDIChildForm = Nothing

        ' Loop through all child of the MDI Parent to check whether the selected from was loaded.
        For Each ctl In frmMe.MdiChildren
            Try
                ' Attempt to cast the control to type Form.
                frmMdiChild = CType(ctl, Form)
                If frmMdiChild.Name() = strFormName And frmMdiChild.Tag = strFormTag Then
                    ' Set the function to true, form was activated already
                    GetMDIChildForm = frmMdiChild
                End If
            Catch ex As Exception
                ' Catch and ignore the error if Exception.
                Prompt_User("Error while getting the ChildForm of " & strFormName, ex.Message)
            End Try
        Next
        Return GetMDIChildForm
    End Function

    'use this function when checking if a childform is already loaded based on the form name.
    Public Function CheckIfChildIsLoaded(ByVal frmMe As Form, ByVal strFormName As String, Optional ByVal strFormTag As String = "") As Boolean
        Dim ctl As Control
        Dim frmMdiChild As Form

        ' Loop through all child of the MDI Parent to check whether the selected from was loaded.
        For Each ctl In frmMe.MdiChildren
            Try
                ' Attempt to cast the control to type Form.
                frmMdiChild = CType(ctl, Form)
                If frmMdiChild.Name() = strFormName And frmMdiChild.Tag = strFormTag Then
                    ' Set the function to true, form was activated already
                    Return True
                End If
            Catch ex As Exception
                ' Catch and ignore the error if Exception.
                Prompt_User("Error while checking if the ChildForm is loaded.", ex.Message)
            End Try
        Next
        Return False

    End Function

    'use this function when activating a main form that is already loaded based on the formtitle.
    Public Function GetRecordChildForm(ByVal frmMe As Form, ByVal strFormTitle As String) As Form
        Dim ctl As Control
        Dim frmMdiChild As Form

        GetRecordChildForm = Nothing

        ' Loop through all child of the MDI Parent
        For Each ctl In frmMe.MdiChildren
            Try
                ' Attempt to cast the control to type Form.
                frmMdiChild = CType(ctl, Form)
                If frmMdiChild.Text() = strFormTitle Then
                    ' Set the function to true, form was activated already
                    GetRecordChildForm = frmMdiChild
                End If
            Catch ex As Exception
                ' Catch and ignore the error if Exception.
                Prompt_User("Error while getting the ChildForm of " & strFormTitle, ex.Message)
            End Try
        Next
        Return GetRecordChildForm
    End Function

    'use this function when checking if a form is already loaded based on the formtitle.
    Public Function CheckIfRecordIsLoaded(ByVal frmMe As Form, ByVal strFormTitle As String) As Boolean
        Dim ctl As Control
        Dim frmMdiChild As Form

        ' Loop through all child of the MDI Parent
        For Each ctl In frmMe.MdiChildren
            Try
                ' Attempt to cast the control to type Form.
                frmMdiChild = CType(ctl, Form)
                If frmMdiChild.Text.Trim() = strFormTitle.Trim Then
                    ' Set the function to true, form was activated already
                    Return True
                End If
            Catch ex As Exception
                ' Catch and ignore the error if Exception.
                Prompt_User("Error while checking if the record is loaded.", ex.Message)
            End Try
        Next
        Return False
    End Function

    'Generate validation list
    Public Function Required_Validation_List(ByRef colForm As Collection) As Boolean
        Dim objControl As Control
        Dim strMissingFields As String = ""
        Dim intNum As Integer = 1
        Dim objcollection As New Collection

        Required_Validation_List = True
        For Each objControl In colForm
            If TypeOf (objControl) Is CheckBox Then

            ElseIf TypeOf (objControl) Is CheckedListBox Then
                Dim chkcontrol As CheckedListBox = objControl
                Dim intlistcount As Integer = chkcontrol.Items.Count
                If chkcontrol.CheckedIndices.Count <> intlistcount Then
                    objcollection.Add(objControl)
                    strMissingFields += intNum & ". " & objControl.Tag + vbCr
                    intNum += 1
                    Required_Validation_List = False
                Else
                    Required_Validation_List = True
                End If

            ElseIf TypeOf (objControl) Is ListView Then
                Dim objListView As ListView = objControl
                If objListView.Items.Count = 0 Then
                    objcollection.Add(objControl)
                    strMissingFields += intNum & ". " & objControl.Tag + vbCr
                    intNum += 1
                    Required_Validation_List = False
                Else
                    Required_Validation_List = True
                End If

            ElseIf TypeOf (objControl) Is DataGridView Then
                Dim objDataGridView As DataGridView = objControl
                Dim GridRows As Integer = 0
                If objDataGridView.AllowUserToAddRows And objDataGridView.AllowUserToDeleteRows Then
                    If CInt(objDataGridView.Item(1, objDataGridView.Rows.Count - 1).Value) = 0 Then
                        GridRows = objDataGridView.Rows.Count - 1
                    Else
                        GridRows = objDataGridView.Rows.Count
                    End If
                Else
                    GridRows = objDataGridView.Rows.Count
                End If

                If GridRows = 0 Then
                    objcollection.Add(objControl)
                    strMissingFields += intNum & ". " & objControl.Tag + vbCr
                    intNum += 1
                    Required_Validation_List = False
                Else
                    Required_Validation_List = True
                End If
            Else

                If objControl.Text = "" Then
                    If objControl.Tag <> "" Then
                        objcollection.Add(objControl)
                        strMissingFields += intNum & ". " & objControl.Tag + vbCr
                        intNum += 1
                    Else
                        Prompt_User("error", MSGBOX_REQUIRED_VALIDATION)
                    End If
                    Required_Validation_List = False
                End If
            End If


        Next
        If Required_Validation_List = False Then
            objControl = objcollection.Item(1)
            Prompt_User("error", MSGBOX_REQUIRED_VALIDATION & vbCr & strMissingFields)
            objControl.Focus()
        End If
    End Function

    Public Function SetUp_ToolTip_Finder(ByRef btnCollection As Collection) As ToolTip
        ' Create the ToolTip and associate with the Form container.
        SetUp_ToolTip_Finder = New ToolTip
        ' btnCollection = New Collection
        Dim objControl As Control
        With SetUp_ToolTip_Finder
            ' Force the ToolTip text to be displayed whether or not the form is active.
            .ShowAlways = True
            ' Set up the ToolTip text for the Button
            For Each objControl In btnCollection
                Select Case LCase(objControl.Text)
                    Case "&add"
                        .SetToolTip(objControl, "Add new record.")
                    Case "&edit"
                        .SetToolTip(objControl, "Edit record.")
                    Case "&search"
                        .SetToolTip(objControl, "Search record based on criteria.")
                    Case "&view"
                        .SetToolTip(objControl, "View record.")
                    Case "c&lear"
                        .SetToolTip(objControl, "Clears search criteria.")
                    Case "&use"
                        .SetToolTip(objControl, "Use selected record.")
                    Case "&cancel"
                        .SetToolTip(objControl, "Cancel and closes the current screen.")
                    Case "a&pprove"
                        .SetToolTip(objControl, "Approve current record.")
                End Select
            Next
        End With
        Return SetUp_ToolTip_Finder
    End Function

    Public Function SetUp_ToolTip_Piping(ByRef objCollection As Collection) As ToolTip
        ' Create the ToolTip and associate with the Form container.
        SetUp_ToolTip_Piping = New ToolTip
        Dim objControl As Control
        With SetUp_ToolTip_Piping
            .ShowAlways = True
            For Each objControl In objCollection
                .SetToolTip(objControl, "Search record to use.")
            Next
            ' Force the ToolTip text to be displayed whether or not the form is active.
            ' Set up the ToolTip text for the Button
        End With
        Return SetUp_ToolTip_Piping
    End Function

    Public Function GetAge(ByVal Birthdate As System.DateTime, Optional ByVal AsOf As System.DateTime = #1/1/1700#) As String

        'Don't set second parameter if you want Age as of today

        'Demo 1: get age of person born 2/11/1954
        'Dim objDate As New System.DateTime(1954, 2, 11)
        'Debug.WriteLine(GetAge(objDate))

        'Demo 1: get same person's age 10 years from now
        'Dim objDate As New System.DateTime(1954, 2, 11)
        'Dim objdate2 As System.DateTime
        'objdate2 = Now.AddYears(10)
        'Debug.WriteLine(GetAge(objDate, objdate2))

        Dim iMonths As Integer
        Dim iYears As Integer
        Dim dYears As Decimal
        Dim lDayOfBirth As Long
        Dim lAsOf As Long
        Dim iBirthMonth As Integer
        Dim iAsOFMonth As Integer

        If AsOf = "#1/1/1700#" Then
            AsOf = DateTime.Now
        End If
        lDayOfBirth = DatePart(DateInterval.Day, Birthdate)
        lAsOf = DatePart(DateInterval.Day, AsOf)

        iBirthMonth = DatePart(DateInterval.Month, Birthdate)
        iAsOFMonth = DatePart(DateInterval.Month, AsOf)

        iMonths = DateDiff(DateInterval.Month, Birthdate, AsOf)

        dYears = iMonths / 12

        iYears = Math.Floor(dYears)

        If iBirthMonth = iAsOFMonth Then
            If lAsOf < lDayOfBirth Then
                iYears = iYears - 1
            End If
        End If

        Return iYears
    End Function

    'This function will replace single quotes to double quotes and remove excess spaces in a string
    Public Function ReplaceSingleQuotes(ByVal Param As String) As String
        Dim sbTemp As StringBuilder = New StringBuilder(Param)
        sbTemp.Replace("'", "''")
        Return TrimAll(sbTemp.ToString)
    End Function

    'This function will replace single quotes to double quotes and remove excess spaces in a string
    Public Function ReplaceAmpersands(ByVal Param As String) As String
        Dim sbTemp As StringBuilder = New StringBuilder(Param)
        sbTemp.Replace("&", "")
        Return TrimAll(sbTemp.ToString)
    End Function

    ' Replace ALL Duplicate Characters in String with a Single Instance
    Public Function TrimAll(ByVal TextIn As String, Optional ByVal TrimChar As String = " ", Optional ByVal CtrlChar As String = Chr(0)) As String
        Try
            TrimAll = Replace(TextIn, TrimChar, CtrlChar) ' In case of CrLf etc.

            While InStr(TrimAll, CtrlChar + CtrlChar) > 0
                TrimAll = TrimAll.Replace(CtrlChar + CtrlChar, CtrlChar)
            End While

            TrimAll = TrimAll.Trim(CtrlChar) ' Trim Begining and End
            TrimAll = TrimAll.Replace(CtrlChar, TrimChar) ' Replace with Original Trim Character(s)
        Catch Exp As Exception
            TrimAll = TextIn ' Justin Case
        End Try
        Return TrimAll
    End Function

    'This function will remove ampersands
    Public Function RemoveAmpersands(ByVal Param As String) As String
        Dim sbTemp As StringBuilder = New StringBuilder(Param)
        sbTemp.Replace("&", "")
        Return Trim(sbTemp.ToString)
    End Function


    'This function will remove consecutive wildcards in a string
    Public Function RemoveRepeatingWildcards(ByVal strSQL As String) As String
        strSQL = Replace(strSQL, "*", "%")
        While InStr(strSQL, "%%")
            strSQL = Replace(strSQL, "%%", "%")
        End While
        Return strSQL
    End Function

    Public Function ExtractNumbers(ByVal expr As String) As String
        Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(expr, "[^\d]"))
    End Function

    Public Function CleanInputAlphabet(ByVal str As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(str, "[0-9\b\s-]", "")
    End Function

    Public Function CleanInputNumber(ByVal str As String) As String
        CleanInputNumber = System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-.]", "")
        If Len(CleanInputNumber) = 0 Then
            CleanInputNumber = "0"
        End If
        Return CleanInputNumber
    End Function

    Public Function CleanInputFloat(ByVal str As String, Optional ByVal digits As Integer = 2) As String
        CleanInputFloat = System.Text.RegularExpressions.Regex.Replace(str, "[a-zA-Z\b\s-]", "")
        If Len(CleanInputFloat) = 0 Then
            If digits = 2 Then
                CleanInputFloat = "0.00"
            Else
                CleanInputFloat = "0.000000"
            End If
        End If
        Return CleanInputFloat
    End Function

    'Generate Debug Information
    Public Function GetDebugInfo() As String
        Dim retStringBuf As New System.Text.StringBuilder

        Try
            retStringBuf.AppendLine("Common class (debug reporter) Assembly Version: " + Environment.Version.Major.ToString() + "." + Environment.Version.Minor.ToString() + "." + Environment.Version.Revision.ToString() + "." + Environment.Version.Build.ToString())
            retStringBuf.AppendLine("Operating System: " + Environment.OSVersion.Platform.ToString())
            retStringBuf.AppendLine("Service Pack: " + Environment.OSVersion.ServicePack())
            retStringBuf.AppendLine("Major Version:	" + Environment.OSVersion.Version.Major.ToString())
            retStringBuf.AppendLine("Minor Version:	" + Environment.OSVersion.Version.Minor.ToString())
            retStringBuf.AppendLine("Revision:		" + Environment.OSVersion.Version.MajorRevision.ToString())
            retStringBuf.AppendLine("Build:		" + Environment.OSVersion.Version.Build.ToString())
            retStringBuf.Append(Environment.NewLine)
            retStringBuf.AppendLine("-------------------------------------------------")
            retStringBuf.Append("Logical Drives: ")
            For Each s As String In Environment.GetLogicalDrives()
                retStringBuf.Append(s & " ")
            Next
            retStringBuf.Append(Environment.NewLine)
            retStringBuf.AppendLine("System Directory: " + Environment.SystemDirectory)
            retStringBuf.AppendLine("Current Directory: " + Environment.CurrentDirectory)
            retStringBuf.AppendLine("Command Line: " + Environment.CommandLine)
            retStringBuf.Append("Command Line Args: ")
            For Each s As String In Environment.GetCommandLineArgs
                retStringBuf.Append(s & " ")
            Next
            retStringBuf.Append(Environment.NewLine)
            retStringBuf.Append(Environment.NewLine)
            retStringBuf.AppendLine("------------Environment Variables-----------------")
            Dim iEnum As IDictionaryEnumerator = Environment.GetEnvironmentVariables.GetEnumerator()
            While iEnum.MoveNext()
                Dim entry As DictionaryEntry = iEnum.Entry
                retStringBuf.AppendLine(entry.Key & " == " & entry.Value)
            End While
            retStringBuf.Append(Environment.NewLine)
            retStringBuf.AppendLine("------------Performance Info (Bytes)--------------")

            Dim currentProc As Process = Process.GetCurrentProcess()
            currentProc.Refresh()

            retStringBuf.Append("Private Memory:  ").AppendLine(currentProc.PrivateMemorySize64.ToString())
            retStringBuf.Append("Virtual Memory:  ").AppendLine(currentProc.VirtualMemorySize64.ToString())
            retStringBuf.Append("Total CPU time: ").AppendLine(currentProc.TotalProcessorTime.ToString())
            retStringBuf.Append("Total User Mode CPU time: ").AppendLine(currentProc.UserProcessorTime.ToString())
            retStringBuf.Append(Environment.NewLine)
            retStringBuf.AppendLine("------------Module Info:--------------------------")

            Dim myProcessModuleCollection As ProcessModuleCollection = currentProc.Modules
            Dim myProcessModule As ProcessModule
            For Each myProcessModule In myProcessModuleCollection
                Try
                    retStringBuf.Append("----Module Name:  ").AppendLine(myProcessModule.ModuleName)
                    retStringBuf.Append("    Path:  ").AppendLine(myProcessModule.FileName)
                    retStringBuf.Append("    Version: ").AppendLine(myProcessModule.FileVersionInfo.FileVersion.ToString())
                Catch
                End Try
            Next myProcessModule

            retStringBuf.Append(Environment.NewLine)
            retStringBuf.AppendLine("------------End Debug Info------------------------")
        Catch
        End Try

        Return retStringBuf.ToString()
    End Function

    Public Shared Function ExecuteUrl(ByVal fullUrl As String, ByVal postdata As String, Optional ByVal bAllowAutoRedirect As Boolean = True, Optional ByVal iTimeout As Integer = System.Threading.Timeout.Infinite) As String
        Dim webRequest As System.Net.HttpWebRequest
        Dim webResponse As System.Net.HttpWebResponse = Nothing
        Try
            'Create an HttpWebRequest with the specified URL.
            webRequest = CType(System.Net.WebRequest.Create(fullUrl), System.Net.HttpWebRequest)
            webRequest.AllowAutoRedirect = bAllowAutoRedirect
            webRequest.Method = "POST"
            webRequest.ContentType = "application/x-www-form-urlencoded"
            webRequest.ContentLength = postdata.Length
            'webRequest.MaximumAutomaticRedirections = 50
            webRequest.Timeout = iTimeout

            Dim requestStream As System.IO.Stream = webRequest.GetRequestStream()
            Dim postBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(postdata)
            requestStream.Write(postBytes, 0, postBytes.Length)
            requestStream.Close()

            'Send the request and wait for a response.
            Try
                webResponse = CType(webRequest.GetResponse(), System.Net.HttpWebResponse)
                Select Case (webResponse.StatusCode)
                    Case System.Net.HttpStatusCode.OK
                        'read the content from the response
                        Dim responseStream As System.IO.Stream = _
                            webResponse.GetResponseStream()
                        Dim responseEncoding As System.Text.Encoding = _
                            System.Text.Encoding.UTF8
                        ' Pipes the response stream to a higher level stream reader with the required encoding format.
                        Dim responseReader As New System.IO.StreamReader(responseStream, responseEncoding)
                        Dim responseContent As String = _
                            responseReader.ReadToEnd()
                        Return responseContent
                    Case System.Net.HttpStatusCode.Redirect, System.Net.HttpStatusCode.MovedPermanently
                        Throw New System.Exception(String.Format( _
                            "Unable to read response content.  URL has moved. StatusCode={0}.", _
                            webResponse.StatusCode))
                    Case System.Net.HttpStatusCode.NotFound
                        Throw New System.Exception(String.Format( _
                            "Unable to read response content. URL not found. StatusCode={0}.", _
                            webResponse.StatusCode))
                    Case Else
                        Throw New System.Exception(String.Format( _
                            "Unable to read response content. StatusCode={0}.", _
                            webResponse.StatusCode))
                End Select
            Catch we As System.Net.WebException
                'If (we.Status = Net.WebExceptionStatus.Timeout) Then
                '    Return False
                'End If
                Throw New System.Exception( _
                    "Unable to execute URL.", _
                    we)
            Finally
                If (Not IsNothing(webResponse)) Then
                    webResponse.Close()
                End If
            End Try
        Catch e As System.Exception
            Throw New System.Exception( _
                "Unable to execute URL.", _
                e)
        End Try
    End Function

    Public Function Check_If_Item_Exists(ByRef lv As ListView, ByVal ItemIdx As Integer, ByVal StrValue As String) As Boolean
        Dim Ictr As Integer

        Check_If_Item_Exists = False

        Try
            For Ictr = 0 To (lv.Items.Count - 1)
                If ItemIdx = 0 Then
                    If StrValue = lv.Items(Ictr).Text Then
                        Return True
                    End If
                Else
                    If StrValue = lv.Items(Ictr).SubItems.Item(ItemIdx).Text Then
                        Return True
                    End If
                End If
            Next

        Catch ex As Exception
            If Err.Number = 5 Then
                Exit Function
            End If
        End Try
    End Function

    Public Function GenerateRecordNo(ByVal lngVal As Long, ByVal pad As Integer, Optional ByVal padStr As String = "0") As String
        Try
            Return CStr(lngVal).PadLeft(pad, padStr)
        Catch ex As Exception
            Return "".PadLeft(pad, padStr)
            Exit Function
        End Try
    End Function

    Public Function IsImageCaptureAvailable() As Boolean
        Dim DriverName As String = Space(80)
        Dim DriverVersion As String = Space(80)

        IsImageCaptureAvailable = False

        For i As Integer = 0 To 9
            If capGetDriverDescriptionA(i, DriverName, 80, DriverVersion, 80) Then
                IsImageCaptureAvailable = True
            End If
        Next
        Return IsImageCaptureAvailable
    End Function

    Public Function CaptureImagetoBMP() As Bitmap
        Dim data As IDataObject
        Dim bmap As Image = Nothing

        CaptureImage = New PictureBox
        PreviewVideo(CaptureImage)

        SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0)

        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            StopPreviewWindow()
        End If
        Return bmap
    End Function

    Public Function RoundUp(ByVal Num As Double, ByVal MultipleOf As Double) As Double
        Return MultipleOf * System.Math.Round(Num / MultipleOf, 0)
    End Function

    Public Function SplitWords(ByVal s As String) As String()
        Return Regex.Split(s, "\W+")
    End Function

#End Region

#Region "Class Common Procedures"

    '*************************************************************
    'NAME:          WriteToErrorLog
    'PURPOSE:       Open or create an error log and submit error message
    'PARAMETERS:    msg - message to be written to error file
    '               stkTrace - stack trace from error message
    '               title - title of the error file entry
    'RETURNS:       Nothing
    '*************************************************************
    Public Sub WriteToErrorLog(ByVal msg As String, ByVal stkTrace As String, ByVal title As String)
        'check and make the directory if necessary; this is set to look in the application
        'folder, you may wish to place the error log in another location depending upon the
        'the user's role and write access to different areas of the file system
        If Not System.IO.Directory.Exists(Application.StartupPath & "\Errors\") Then
            System.IO.Directory.CreateDirectory(Application.StartupPath & "\Errors\")
        End If

        'check the file
        Dim fs As FileStream = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim s As StreamWriter = New StreamWriter(fs)
        s.Close()
        fs.Close()

        'log it
        Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\Errors\errlog.txt", FileMode.Append, FileAccess.Write)
        Dim s1 As StreamWriter = New StreamWriter(fs1)
        s1.Write("Title: " & title & vbCrLf)
        s1.Write("Message: " & msg & vbCrLf)
        s1.Write("StackTrace: " & stkTrace & vbCrLf)
        s1.Write("Date/Time: " & DateTime.Now.ToString() & vbCrLf)
        s1.Write("===========================================================================================" & vbCrLf)
        s1.Close()
        fs1.Close()
    End Sub

    Public Sub SendEmailMessage(ByVal strFrom As String, ByVal strTo() _
As String, ByVal strSubject _
As String, ByVal strMessage _
As String, ByVal fileList() As String)
        'This procedure takes string array parameters for multiple recipients and files
        Try
            For Each item As String In strTo
                'For each to address create a mail message
                Dim MailMsg As New MailMessage(New MailAddress(strFrom.Trim()), New MailAddress(item))
                MailMsg.BodyEncoding = Encoding.Default
                MailMsg.Subject = strSubject.Trim()
                MailMsg.Body = strMessage.Trim() & vbCrLf
                MailMsg.Priority = MailPriority.High
                MailMsg.IsBodyHtml = True

                'attach each file attachment
                For Each strfile As String In fileList
                    If Not strfile = "" Then
                        Dim MsgAttach As New Attachment(strfile)
                        MailMsg.Attachments.Add(MsgAttach)
                    End If
                Next

                'Smtpclient to send the mail message
                Dim SmtpMail As New SmtpClient
                SmtpMail.Host = "10.10.10.10"
                SmtpMail.Send(MailMsg)
            Next
            'Message Successful
        Catch ex As Exception
            'Message Error
        End Try
    End Sub

    Public Sub SendEmailMessage(ByVal strFrom As String, ByVal strTo _
    As String, ByVal strSubject _
    As String, ByVal strMessage _
    As String, ByVal file As String)
        'This procedure overrides the first procedure and accepts a single
        'string for the recipient and file attachement 
        Try
            Dim MailMsg As New MailMessage(New MailAddress(strFrom.Trim()), New MailAddress(strTo))
            MailMsg.BodyEncoding = Encoding.Default
            MailMsg.Subject = strSubject.Trim()
            MailMsg.Body = strMessage.Trim() & vbCrLf
            MailMsg.Priority = MailPriority.High
            MailMsg.IsBodyHtml = True

            If Not file = "" Then
                Dim MsgAttach As New Attachment(file)
                MailMsg.Attachments.Add(MsgAttach)
            End If

            'Smtpclient to send the mail message
            Dim SmtpMail As New SmtpClient
            SmtpMail.Host = "10.10.10.10"
            SmtpMail.Send(MailMsg)
        Catch ex As Exception
            'Message Error
        End Try
    End Sub

    Public Sub SaveRegistrySetting(ByVal strSection As String, ByVal strKey As String, ByVal strVal As String)
        SaveSetting(modApp.AssemblyTitle, strSection, strKey, strVal)
    End Sub

    Public Sub ClearControls(ByRef colForm As Collection)
        Try
            Dim objControl As Control
            Dim objCheckBox As CheckBox
            Dim objDateTimePicker As DateTimePicker
            Dim objRadioButton As RadioButton
            Dim objListView As ListView

            For Each objControl In colForm
                If TypeOf (objControl) Is CheckBox Then
                    objCheckBox = objControl
                    objCheckBox.CheckState = CInt(objCheckBox.Tag)
                ElseIf TypeOf (objControl) Is RadioButton Then
                    objRadioButton = objControl
                    objRadioButton.Checked = False
                ElseIf TypeOf (objControl) Is DateTimePicker Then
                    objDateTimePicker = objControl
                    objDateTimePicker.Value = Now()
                    If objDateTimePicker.ShowCheckBox = True Then
                        If CInt(objDateTimePicker.Tag) = 0 Then
                            objDateTimePicker.Checked = False
                        Else
                            objDateTimePicker.Checked = True
                        End If
                    End If
                ElseIf TypeOf (objControl) Is ListView Then
                    objListView = objControl
                    objListView.Items.Clear()
                Else
                    objControl.Text = ""
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Setup_Use_Buttons(ByRef btnCollection As Collection)
        Dim btnControl As Button
        For Each btnControl In btnCollection
            Select Case LCase(btnControl.Text)
                Case "&view"
                    btnControl.Text = "&Use"
                Case "&edit"
                    btnControl.Text = "&Cancel"
            End Select
        Next
    End Sub

    Public Sub Set_Toolbar_Tooltips(ByRef tbrForm As ToolBar)
        tbrForm.Buttons(0).ToolTipText = "Add new record."
        tbrForm.Buttons(1).ToolTipText = "Edit existing record."
        tbrForm.Buttons(2).ToolTipText = "Delete this record."
        tbrForm.Buttons(3).ToolTipText = "Launch Finder Screen."
        tbrForm.Buttons(4).ToolTipText = "Save record."
        tbrForm.Buttons(5).ToolTipText = "Cancel changes made."
        tbrForm.Buttons(6).ToolTipText = "Approve record."
    End Sub

    Public Sub HideUnhideToolbarButtons(ByRef tbrForm As ToolBar, ByVal strState As String, ByVal Add_Permission As Integer, ByVal Edit_Permission As Integer, ByVal Delete_Permission As Integer, ByVal View_Permission As Integer, ByVal Approve_Permission As Integer, Optional ByVal blnEdit As Boolean = True, Optional ByVal blnDelete As Boolean = True, Optional ByVal blnApprove As Boolean = False)
        tbrForm.Buttons(0).Visible = False 'Add
        tbrForm.Buttons(1).Visible = False 'Edit
        tbrForm.Buttons(2).Visible = False 'Delete
        tbrForm.Buttons(3).Visible = False 'Find
        tbrForm.Buttons(4).Visible = False 'Save
        tbrForm.Buttons(5).Visible = False 'Cancel
        tbrForm.Buttons(6).Visible = False 'Approve

        If strState = ADD_STATE Then 'Show Save and Cancel buttons Only
            tbrForm.Buttons(4).Visible = True 'Save
            tbrForm.Buttons(5).Visible = True 'Cancel    

            If Not Add_Permission = 1 Then
                tbrForm.Buttons(4).Enabled = False 'Save
            End If
        ElseIf strState = EDIT_STATE Then  'Show Save and Cancel buttons Only
            tbrForm.Buttons(4).Visible = True 'Save
            tbrForm.Buttons(5).Visible = True 'Cancel

            If Not Edit_Permission = 1 Then
                tbrForm.Buttons(4).Enabled = False 'Save
            End If
        ElseIf strState = VIEW_STATE Then  'Show Add, Edit, Delete, Approve and Find buttons Only
            tbrForm.Buttons(0).Visible = True 'Add
            tbrForm.Buttons(1).Visible = True 'Edit
            tbrForm.Buttons(2).Visible = True 'Delete
            tbrForm.Buttons(3).Visible = True 'Find

            If Not Add_Permission = 1 Then
                tbrForm.Buttons(0).Enabled = False 'Add
            End If
            If Not (Edit_Permission = 1 And blnEdit) Then
                tbrForm.Buttons(1).Enabled = False 'Edit
            End If
            If Not (Delete_Permission = 1 And blnDelete) Then
                tbrForm.Buttons(2).Enabled = False 'Delete
            End If
            If Not View_Permission = 1 Then
                tbrForm.Buttons(3).Enabled = False 'Find       
            End If
            If (Approve_Permission = 1 And blnApprove) Then
                tbrForm.Buttons(6).Visible = True 'Approve
            End If
        End If
    End Sub

    Public Sub EnableDisableFinderButtons(ByVal Use_Record_State As String, ByRef bView As Button, ByRef bAdd As Button, ByRef bEdit As Button, ByVal Add_Permission As Integer, ByVal Edit_Permission As Integer, ByVal Delete_Permission As Integer, ByVal View_Permission As Integer, ByVal Approve_Permission As Integer, ByVal dgStateForm As Boolean, Optional ByVal blnEdit As Boolean = True, Optional ByVal blnAdd As Boolean = False)
        bAdd.Enabled = blnAdd

        If Use_Record_State <> USE_STATE Then

            bEdit.Enabled = False
            bView.Enabled = False
            If View_Permission = 1 And dgStateForm Then
                bView.Enabled = True
            End If
            If Add_Permission = 1 Then
                bAdd.Enabled = True
            End If
            If (Edit_Permission = 1) And blnEdit And dgStateForm Then
                bEdit.Enabled = True
            End If
        End If
    End Sub

    Public Sub EnableDisableFields(ByRef colForm As Collection, ByVal strState As String)
        Dim objControl As Control
        Dim txtControl As TextBox
        Dim dgvControl As DataGridView
        Dim dgvColumn As DataGridViewColumn

        If strState = "View" Then
            For Each objControl In colForm
                If TypeOf (objControl) Is TextBox Then
                    txtControl = objControl
                    txtControl.ReadOnly = True
                    txtControl.BackColor = Color.AliceBlue
                ElseIf TypeOf (objControl) Is CheckBox Then
                    objControl.Enabled = False
                ElseIf TypeOf (objControl) Is Button Then
                    objControl.Enabled = False
                ElseIf TypeOf (objControl) Is DataGridView Then
                    Try
                        dgvControl = objControl
                        dgvControl.AllowUserToAddRows = False
                        dgvControl.AllowUserToDeleteRows = False
                        For Each dgvColumn In dgvControl.Columns
                            dgvColumn.ReadOnly = True
                        Next
                    Catch ex As Exception

                    End Try
                Else
                    objControl.Enabled = False
                    objControl.BackColor = Color.AliceBlue
                End If

            Next
        Else
            For Each objControl In colForm
                If TypeOf (objControl) Is TextBox Then
                    txtControl = objControl
                    txtControl.ReadOnly = False
                    txtControl.BackColor = SystemColors.Window
                ElseIf TypeOf (objControl) Is CheckBox Then
                    objControl.Enabled = True
                ElseIf TypeOf (objControl) Is Button Then
                    objControl.Enabled = True
                ElseIf TypeOf (objControl) Is DataGridView Then
                    Try
                        dgvControl = objControl
                        If dgvControl.TabStop = False Then
                            dgvControl.AllowUserToAddRows = False
                            dgvControl.AllowUserToDeleteRows = False
                        Else
                            dgvControl.AllowUserToAddRows = True
                            dgvControl.AllowUserToDeleteRows = True
                        End If

                        For Each dgvColumn In dgvControl.Columns
                            dgvColumn.ReadOnly = CInt(dgvColumn.ToolTipText)
                        Next
                    Catch ex As Exception

                    End Try
                Else
                    objControl.Enabled = True
                    objControl.BackColor = SystemColors.Window
                End If
            Next
        End If
    End Sub

    Public Sub EnableDisableControls(ByRef colPipes As Collection, ByRef colForm As Collection, ByVal strState As String)
        Dim objControl As Object
        Dim txtControl As TextBox
        Dim lblControl As Label
        Dim dgvControl As DataGridView
        Dim dgvColumn As DataGridViewColumn

        If strState = "View" Then
            For Each objControl In colForm
                If TypeOf (objControl) Is TextBox Then
                    txtControl = objControl
                    txtControl.ReadOnly = True
                    txtControl.BackColor = Color.AliceBlue
                ElseIf TypeOf (objControl) Is CheckBox Then
                    objControl.Enabled = False
                ElseIf TypeOf (objControl) Is Button Then
                    objControl.Enabled = False
                ElseIf TypeOf (objControl) Is DataGridView Then
                    Try
                        dgvControl = objControl
                        dgvControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
                        dgvControl.AllowUserToAddRows = False
                        dgvControl.AllowUserToDeleteRows = False
                        For Each dgvColumn In dgvControl.Columns
                            dgvColumn.ReadOnly = True
                        Next
                    Catch ex As Exception

                    End Try
                Else
                    objControl.Enabled = False
                End If
            Next
            For Each objControl In colPipes
                If TypeOf (objControl) Is Label Then
                    lblControl = objControl
                    lblControl.Cursor = Arrow
                    lblControl.SendToBack()
                End If
            Next
        Else
            For Each objControl In colForm
                If TypeOf (objControl) Is TextBox Then
                    txtControl = objControl
                    txtControl.ReadOnly = False
                    txtControl.BackColor = SystemColors.Window
                ElseIf TypeOf (objControl) Is CheckBox Then
                    objControl.Enabled = True
                ElseIf TypeOf (objControl) Is Button Then
                    objControl.Enabled = True
                ElseIf TypeOf (objControl) Is DataGridView Then
                    Try
                        dgvControl = objControl
                        dgvControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect
                        If dgvControl.TabStop = False Then
                            dgvControl.AllowUserToAddRows = False
                            dgvControl.AllowUserToDeleteRows = False
                        Else
                            dgvControl.AllowUserToAddRows = True
                            dgvControl.AllowUserToDeleteRows = True
                        End If

                        For Each dgvColumn In dgvControl.Columns
                            dgvColumn.ReadOnly = CInt(dgvColumn.ToolTipText)
                        Next
                    Catch ex As Exception

                    End Try
                Else
                    objControl.Enabled = True
                    'objControl.BackColor = SystemColors.Window
                End If
            Next
            For Each objControl In colPipes
                If TypeOf (objControl) Is Label Then
                    lblControl = objControl
                    lblControl.Cursor = Hand
                    lblControl.BringToFront()
                End If
            Next
        End If
    End Sub

    Public Sub RichTextBox_No_Selection(ByRef rtfbox As RichTextBox, ByRef objControl As Object)
        Try
            rtfbox.SelectionLength = 0
            objControl.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub PopulateComboBox(ByRef cboListId As ComboBox, ByRef cboList1 As ComboBox, ByRef DataCombo As DataSet, Optional ByRef cboList2 As ComboBox = Nothing, Optional ByVal Fl As Boolean = False)
        Dim dataComboRow As DataRow
        Try
            If Not cboList2 Is Nothing Then
                cboListId.Items.Clear()
                cboList1.Items.Clear()
                cboList2.Items.Clear()
                If Fl Then
                    cboListId.Items.Add(0)
                    cboList1.Items.Add("")
                    cboList2.Items.Add("")
                End If
                For Each dataComboRow In DataCombo.Tables(0).Rows
                    cboListId.Items.Add(dataComboRow(0))
                    cboList1.Items.Add(dataComboRow(1))
                    cboList2.Items.Add(dataComboRow(2))
                Next
            Else
                cboListId.Items.Clear()
                cboList1.Items.Clear()
                If Fl Then
                    cboListId.Items.Add(0)
                    cboList1.Items.Add("")
                End If
                For Each dataComboRow In DataCombo.Tables(0).Rows
                    cboListId.Items.Add(dataComboRow(0))
                    cboList1.Items.Add(dataComboRow(1))
                Next
            End If
            DataCombo = Nothing
            dataComboRow = Nothing
        Catch ex As Exception
            'error was encountered while populating record
            RaiseEvent MsgArrival(ex.Message, False)
            DataCombo = Nothing
            dataComboRow = Nothing
        End Try
    End Sub

    Public Sub DisAllow_Input(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        e.Handled = True
    End Sub

    Public Sub Delete_TxtBox_Value(ByRef txtBox As TextBox, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyValue = 46 Or e.KeyValue = 8 Then
            txtBox.Text = ""
        End If
    End Sub

    Public Sub Disable_Field_Context_Menu(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef txtBox As TextBox)
        If e.Button = MouseButtons.Right Then
            txtBox.ContextMenu = New ContextMenu
        End If
    End Sub

    Public Sub Key_Down(ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.ControlKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.Insert Then
            e.Handled = True
        End If
    End Sub

    Public Sub CapitalizeKeyPressString(ByRef E As System.Windows.Forms.KeyPressEventArgs)
        Dim str As String
        Dim ch As Char()

        str = E.KeyChar.ToString().ToUpper()
        ch = str.ToCharArray()
        E.KeyChar = ch(0)
    End Sub

    Public Sub AcceptNumbers(ByRef E As System.Windows.Forms.KeyPressEventArgs)
        If E.KeyChar.GetHashCode <> 524296 Then
            Select Case E.KeyChar
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    E.Handled = False
                Case Else
                    E.Handled = True
            End Select
        Else
            E.Handled = False
        End If
    End Sub

    Public Sub AcceptPercentage(ByRef txtbox As TextBox, ByRef E As System.Windows.Forms.KeyPressEventArgs)
        Dim leftindex As Integer
        Dim rightindex As Integer
        If E.KeyChar.GetHashCode <> 524296 Then
            Select Case E.KeyChar
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    leftindex = InStr(txtbox.Text, ".") - 1
                    rightindex = InStr(txtbox.Text, ".")

                    If rightindex <> 0 Then
                        If Len(Mid(txtbox.Text, rightindex)) = 3 Then
                            E.Handled = True
                        Else
                            E.Handled = False
                        End If
                    End If

                Case "."
                    If InStr(txtbox.Text, ".") > 0 Then
                        E.Handled = True
                    Else
                        E.Handled = False
                    End If
                Case Else
                    E.Handled = True
            End Select
        Else
            E.Handled = False
        End If
    End Sub

    Public Sub AcceptAmount(ByRef txtbox As TextBox, ByRef E As System.Windows.Forms.KeyPressEventArgs, Optional ByVal amtDigits As Integer = 3)
        Dim leftindex As Integer
        Dim rightindex As Integer

        If E.KeyChar.GetHashCode <> 524296 Then
            Select Case E.KeyChar
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    leftindex = InStr(txtbox.Text, ".") - 1
                    rightindex = InStr(txtbox.Text, ".")

                    If rightindex <> 0 Then
                        If Len(Mid(txtbox.Text, rightindex)) = amtDigits Then
                            E.Handled = True
                        Else
                            E.Handled = False
                        End If
                    End If

                Case "."

                    If InStr(txtbox.Text, ".") > 0 Then
                        E.Handled = True
                    Else
                        E.Handled = False
                    End If
                Case Else
                    E.Handled = True
            End Select
        Else
            E.Handled = False
        End If

    End Sub

    Public Function AcceptAmmountTest(ByRef txtbox As TextBox, ByRef E As System.Windows.Forms.KeyPressEventArgs, Optional ByVal amtDigits As Integer = 3) As Boolean
        Dim found As Boolean
        Dim leftindex As Integer
        Dim rightindex As Integer

        If E.KeyChar.GetHashCode <> 524296 Then
            Select Case E.KeyChar
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    leftindex = InStr(txtbox.Text, ".") - 1
                    rightindex = InStr(txtbox.Text, ".")

                    If rightindex <> 0 Then
                        If Len(Mid(txtbox.Text, rightindex)) = amtDigits Then
                            'E.Handled = True
                            found = True
                        Else
                            'E.Handled = False
                            found = False
                        End If
                    End If

                Case "."

                    If InStr(txtbox.Text, ".") > 0 Then
                        'E.Handled = True
                        found = True
                    Else
                        'E.Handled = False
                        found = False
                    End If
                Case Else
                    'E.Handled = True
                    found = True
            End Select
        Else
            'E.Handled = False
            found = False
        End If
        Return found
    End Function

    Public Sub AcceptRate(ByRef txtbox As TextBox, ByRef E As System.Windows.Forms.KeyPressEventArgs, Optional ByVal amtDigits As Integer = 3)
        Dim leftindex As Integer
        Dim rightindex As Integer

        If E.KeyChar.GetHashCode <> 524296 Then
            Select Case E.KeyChar
                Case "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                    leftindex = InStr(txtbox.Text, ".") - 1
                    rightindex = InStr(txtbox.Text, ".")

                    If rightindex <> 0 Then
                        If Len(Mid(txtbox.Text, rightindex)) = amtDigits Then
                            E.Handled = True
                        Else
                            E.Handled = False
                        End If
                    End If
                Case "."
                    If InStr(txtbox.Text, ".") > 0 Then
                        E.Handled = True
                    Else
                        E.Handled = False
                    End If
                Case "-"
                    If (txtbox.Text = "") Then
                        E.Handled = False
                    Else
                        E.Handled = True
                    End If
                Case Else
                    E.Handled = True
            End Select
        Else
            E.Handled = False
        End If
    End Sub

    Public Sub AcceptText(ByRef txtbox As TextBox, ByRef e As System.Windows.Forms.KeyPressEventArgs)
        Select Case e.KeyChar
            Case "|"
                e.Handled = True
            Case Else
                e.Handled = False
        End Select
    End Sub

    Public Sub AcceptAlphaNumeric(ByRef txtbox As TextBox, ByRef e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar.GetHashCode <> 524296 Then
            Select Case Asc(e.KeyChar)
                Case 48 To 57, 65 To 90, 97 To 122
                    e.Handled = False
                Case Else
                    e.Handled = True
            End Select
        Else
            e.Handled = False
        End If
    End Sub

    Public Sub Trap_Mouse_Entry(ByRef txtBox As TextBox, ByVal e As System.Windows.Forms.MouseEventArgs)
        txtBox.Text = ""
    End Sub

    Private Sub PreviewVideo(ByVal pbCtrl As PictureBox)
        hWnd = capCreateCaptureWindowA(0, WS_VISIBLE Or WS_CHILD, 0, 0, 0, _
            0, pbCtrl.Handle.ToInt32, 0)
        If SendMessage(hWnd, WM_CAP_DRIVER_CONNECT, 0, 0) Then
            '---set the preview scale---
            SendMessage(hWnd, WM_CAP_SET_SCALE, True, 0)
            '---set the preview rate (ms)---
            SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0)
            '---start previewing the image---
            SendMessage(hWnd, WM_CAP_SET_PREVIEW, True, 0)
            '---resize window to fit in PictureBox control---
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, _
               pbCtrl.Width, pbCtrl.Height, _
               SWP_NOMOVE Or SWP_NOZORDER)
        Else
            '--error connecting to video source---
            DestroyWindow(hWnd)
        End If
    End Sub

    Private Sub StopPreviewWindow()
        SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, 0, 0)
        DestroyWindow(hWnd)
    End Sub

#End Region


End Class
