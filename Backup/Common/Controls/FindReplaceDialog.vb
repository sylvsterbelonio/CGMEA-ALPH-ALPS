Option Strict On
Option Explicit On 
Option Compare Text

Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports VB = Microsoft.VisualBasic

Namespace FindReplace

    Public Class FindReplaceDialog
        Inherits System.ComponentModel.Component
        Implements System.Windows.Forms.IMessageFilter
        Implements IFindReplaceDialog


        Private Const bufferSize As Integer = 256

#Region "Class Fields"
        ' This region defines private class fields used
        ' by property procedures.

       
        Friend Shared FindReplaceFlags As Integer           ' Stores the flags that will be used to specify how the dialog will behave.
        Friend Shared findMessage As Integer                ' Stores the return value of the FINDMSGSTRING registered message.
        Friend Shared helpMessage As Integer                ' Stores the return value of the HELPMSGSTRING registered message.
        Private findReplacePointer As IntPtr                ' Stores copy of memory passed to the FindReplace dialog.
        Private dialogType As FindReplaceDialogType         ' Stores the type of dialog to display.
        Private windowHandle As IntPtr                      ' Stores a handle of the dialog.
        Private Owner As OwnerWindow                        ' Stores the window that subclasses the owner.
        Private findWhatString As String                    ' Stores the string we are searching for.
        Private replaceWithString As String                 ' Stores the string we are replacing with.
        Private findWhatPointer As IntPtr = IntPtr.Zero     ' Stores pointer to the findwhat string
        Private replaceWithPointer As IntPtr = IntPtr.Zero  ' Stores pointer to the ReplaceWith string
        Private wordTerminators As ArrayList                ' Stores an arraylist of characters that we look for to terminate a whole word.
        Private wordPrefixes As ArrayList                   ' Stores an arraylist of characters that we look for to prefix a whole word.
#End Region


        ' Initializes a new instance of FindReplaceDialog
        Public Sub New()

            MyBase.New()
            Try
                ' Instantiate the OwnerWindow class
                Owner = New OwnerWindow(Me)
                wordPrefixes = New ArrayList()
                wordTerminators = New ArrayList()

                'Set defaults for the FindReplaceDialog
                SetOption(FindReplaceEnum.DisableMatchCase, False)
                SetOption(FindReplaceEnum.DisableUpDown, False)
                SetOption(FindReplaceEnum.DisableWholeWord, False)
                SetOption(FindReplaceEnum.Down, True)
                SetOption(FindReplaceEnum.HideMatchCase, False)
                SetOption(FindReplaceEnum.HideUpDown, False)
                SetOption(FindReplaceEnum.HideWholeWord, False)
                SetOption(FindReplaceEnum.MatchCase, False)
                SetOption(FindReplaceEnum.MatchWholeWord, False)
                SetOption(FindReplaceEnum.ShowHelp, True)

                With wordPrefixes
                    .Add(" ")
                    .Add(".")
                    .Add("!")
                    .Add("?")
                    .Add(",")
                    .Add(";")
                    .Add(":")
                    .Add("""")
                    .Add("'")
                    .Add("")
                End With
                With wordTerminators
                    .Add(" ")
                    .Add(".")
                    .Add("!")
                    .Add("?")
                    .Add(",")
                    .Add(";")
                    .Add(":")
                    .Add("""")
                    .Add("'")
                    .Add("")
                End With

            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub


#Region "IMessageFilter Implementation"
        ' This region contains the code which implements the IMessageFilter interface.
        ' There is only one method we need to implement.


        Private Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
            Try
                ' Call the IsDialogMessage function to determine if the
                ' message belongs to a dialog.
                Return IsDialogMessage(windowHandle, m)
            Catch ex As System.Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "IFindReplace Event Implementation"
        'This region contains the event implementation code for the IFindReplace interface.


        Public Event FindNextClick() Implements IFindReplaceDialog.FindNextClick
        Public Event DialogTerminate() Implements IFindReplaceDialog.DialogTerminate
        Public Event ReplaceClick() Implements IFindReplaceDialog.ReplaceClick
        Public Event ReplaceAllClick() Implements IFindReplaceDialog.ReplaceAllClick
        Public Event Help() Implements IFindReplaceDialog.Help
        Public Event TextFound(ByVal eventArguments As FindReplaceEventArgs) Implements IFindReplaceDialog.TextFound
        Public Event SearchFailed(ByVal eventArguments As FindReplaceEventArgs) Implements IFindReplaceDialog.SearchFailed

        ' Allows derived classes to override OnReplace method.
        Protected Overridable Sub OnReplaceClick()
            RaiseEvent ReplaceClick()
        End Sub

        ' Allows derived classes to override OnHelp method.
        Protected Overridable Sub OnHelp()
            RaiseEvent Help()
        End Sub

        ' Allows derived classes to override OnReplaceAll method.
        Protected Overridable Sub OnReplaceAllClick()
            RaiseEvent ReplaceAllClick()
        End Sub

        ' Allows derived classes to override OnFindNext method.
        Protected Overridable Sub OnFindNextClick()
            RaiseEvent FindNextClick()
        End Sub

        ' Allows derived classes to override OnTerminate method.
        Protected Overridable Sub OnDialogTerminate()
            Try
                windowHandle = IntPtr.Zero
                Owner.ReleaseHandle()
                Application.RemoveMessageFilter(Me)
                RaiseEvent DialogTerminate()
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        ' Allows derived classes to override OnTextFound method.
        Protected Overridable Sub OnTextFound(ByVal sourceControl As System.Windows.Forms.Control, ByVal findWhat As String, ByVal Position As Integer)
            Dim eventArguments As FindReplaceEventArgs
            eventArguments = New FindReplaceEventArgs(sourceControl, findWhat, Position)
            RaiseEvent TextFound(eventArguments)
        End Sub

        ' Allows derived classes to override OnSearchFailed method.
        Protected Overridable Sub OnSearchFailed(ByVal sourceControl As System.Windows.Forms.Control, ByVal findWhat As String)
            Dim eventArguments As FindReplaceEventArgs
            eventArguments = New FindReplaceEventArgs(sourceControl, findWhat, -1)
            RaiseEvent SearchFailed(eventArguments)
        End Sub
#End Region

#Region "IFindReplace Property Implementation"
        ' This region implements the Properties defined in the IFindReplace interface.


        ' The Direction property procedure implements the Direction property.
        <System.ComponentModel.DefaultValue(FindReplaceEnum.Down), _
            System.ComponentModel.Description("Specifies whether to search up or down.")> _
           Public Property Direction() As FindReplace.FindDirection Implements IFindReplaceDialog.Direction
            Get
                Try
                    Dim searchDirection As Boolean

                    ' Determine if the bit represent by FindReplaceEnum.Down is set.
                    ' If so, return FindDirection.Down, otherwise return FindDirection.Up
                    searchDirection = GetOption(FindReplaceEnum.Down)
                    If searchDirection = True Then
                        Return FindDirection.Down
                    Else
                        Return FindDirection.Up
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get

            Set(ByVal Value As FindDirection)
                ' If the value passed in is True, flip the bit represented by
                ' FindDirection.Down.
                Try
                    If Value = FindDirection.Down Then
                        SetOption(FindReplaceEnum.Down, True)
                    Else
                        SetOption(FindReplaceEnum.Down, False)
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' DirectionEnabled property procedure implements the DirectionEnabled property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the Directional options are enabled or disabled. Only available for a Find dialog box.")> _
        Public Property DirectionEnabled() As Boolean Implements IFindReplaceDialog.DirectionEnabled
            Get
                Try
                    ' If the dialog type is a Find dialog, then return the inverse
                    ' of the current value for FindReplaceEnum.DisableUpDown. If it is
                    ' a Replace dialog, return False because Replace dialogs cannot display
                    ' the Directional options.
                    If Me.Type = FindReplaceDialogType.Find Then

                        ' Determine if the bit represent by FindReplaceEnum.DisableUpDown is set.
                        Return Not GetOption(FindReplaceEnum.DisableUpDown)
                    Else
                        Return False
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get

            Set(ByVal Value As Boolean)
                Try
                    ' If the dialog type is a Find dialog, then set the bit represented by 
                    ' FindReplaceEnum.DisableUpDown to the inverse of the value passed in.
                    ' If it is a Replace dialog, pass it False because Replace dialogs cannot display
                    ' the Directional options.
                    If Me.Type = FindReplaceDialogType.Find Then
                        ' Flip the value passed in so we can set the bit properly.
                        SetOption(FindReplaceEnum.DisableUpDown, Not Value)
                    Else
                        SetOption(FindReplaceEnum.DisableUpDown, False)
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The DirectionEnabled property procedure implements the DirectionEnabled property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the Directional options are visible or hidden. Only available for a Find dialog box.")> _
       Public Property DirectionVisible() As Boolean Implements IFindReplaceDialog.DirectionVisible
            Get
                Try

                    ' If the dialog type is a Find dialog, then return the inverse
                    ' of the current value for FindReplaceEnum.HideUpDown. If it is
                    ' a Replace dialog, return False because Replace dialogs cannot display
                    ' the Directional options.
                    If Me.Type = FindReplaceDialogType.Find Then
                        Return Not GetOption(FindReplaceEnum.HideUpDown)
                    Else
                        Return False
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get

            Set(ByVal Value As Boolean)
                Try
                    ' If the dialog type is a Find dialog, then set the bit represented by 
                    ' FindReplaceEnum.HideUpDown to the inverse of the value passed in.
                    ' If it is a Replace dialog, pass it False because Replace dialogs cannot display
                    ' the Directional options.
                    If Me.Type = FindReplaceDialogType.Find Then
                        ' Flip the value passed in so we can set the bit properly.
                        SetOption(FindReplaceEnum.HideUpDown, Not Value)
                    Else
                        SetOption(FindReplaceEnum.HideUpDown, False)
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The MatchCase property procedure implements the MatchCase property.
        <System.ComponentModel.DefaultValue(False), _
            System.ComponentModel.Description("Specifies whether to do a case sensitive search or not.")> _
        Public Property MatchCase() As Boolean Implements IFindReplaceDialog.MatchCase
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.MatchCase
                    ' is set and return True or False appropriately.
                    Return GetOption(FindReplaceEnum.MatchCase)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get

            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.MatchCase
                    ' to the value passed in
                    SetOption(FindReplaceEnum.MatchCase, Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The MatchCaseEnabled property procedure implements the MatchCaseEnabled property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the MatchCase options should be enabled or disabled.")> _
        Public Property MatchCaseEnabled() As Boolean Implements IFindReplaceDialog.MatchCaseEnabled
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.DisableMatchCase
                    ' is set and return True or False appropriately.
                    Return Not GetOption(FindReplaceEnum.DisableMatchCase)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.DisableMatchCase
                    ' to the inverse of the value passed in
                    SetOption(FindReplaceEnum.DisableMatchCase, Not Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The MatchCaseVisible property procedure implements the MatchCaseVisible property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the MatchCase options should be visible or hidden.")> _
        Public Property MatchCaseVisible() As Boolean Implements IFindReplaceDialog.MatchCaseVisible
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.HideMatchCase
                    ' is set and return True or False appropriately.
                    Return Not GetOption(FindReplaceEnum.HideMatchCase)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get

            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.HideMatchCase
                    ' to the inverse of the value passed in
                    SetOption(FindReplaceEnum.HideMatchCase, Not Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The MatchWholeWord property procedure implements the MatchWholeWord property.
        <System.ComponentModel.DefaultValue(False), _
            System.ComponentModel.Description("Specifies whether to match the whole word or not.")> _
        Public Property MatchWholeWord() As Boolean Implements IFindReplaceDialog.MatchWholeWord
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.MatchWholeWord
                    ' is set and return True or False appropriately.
                    Return GetOption(FindReplaceEnum.MatchWholeWord)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.HideMatchCase
                    ' to the value passed in
                    SetOption(FindReplaceEnum.MatchWholeWord, Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The MatchWholeWordEnabled property procedure implements the MatchWholeWordEnabled property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the MatchCase options should be enabled or disabled.")> _
        Public Property MatchWholeWordEnabled() As Boolean Implements IFindReplaceDialog.MatchWholeWordEnabled
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.DisableWholeWord
                    ' is set and return True or False appropriately.
                    Return Not GetOption(FindReplaceEnum.DisableWholeWord)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.DisableWholeWord
                    ' to the inverse of the value passed in
                    SetOption(FindReplaceEnum.DisableWholeWord, Not Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The MatchWholeWordVisible property procedure implements the MatchWholeWordVisible property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the Directional options should be visible or hidden.")> _
        Public Property MatchWholeWordVisible() As Boolean Implements IFindReplaceDialog.MatchWholeWordVisible
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.HideWholeWord
                    ' is set and return True or False appropriately.
                    Return Not GetOption(FindReplaceEnum.HideWholeWord)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get

            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.HideWholeWord
                    ' to the inverse of the value passed in
                    SetOption(FindReplaceEnum.HideWholeWord, Not Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The HelpVisible property procedure implements the HelpVisible property.
        <System.ComponentModel.DefaultValue(True), _
            System.ComponentModel.Description("Specifies whether the Help button should be visible or not.")> _
        Public Property HelpVisible() As Boolean Implements IFindReplaceDialog.HelpVisible
            Get
                Try
                    ' Determine if the bit represented by FindReplaceEnum.ShowHelp
                    ' is set and return True or False appropriately.
                    Return GetOption(FindReplaceEnum.ShowHelp)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As Boolean)
                Try
                    ' Set the bit represented by FindReplaceEnum.ShowHelp
                    ' to the value passed in
                    SetOption(FindReplaceEnum.ShowHelp, Value)
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property

        ' The FindWhat property procedure implements the FindWhat property.
        <System.ComponentModel.Description("Specifies the string to search for.")> _
        Public Property FindWhat() As String Implements IFindReplaceDialog.FindWhat
            Get
                Try
                    ' Return the string we are searching for.
                    If IsNothing(findWhatString) Then
                        findWhatString = ""
                    End If
                    Return findWhatString
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As String)
                Try
                    ' Set the string we are searching for.
                    findWhatString = Value
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property


        ' The ReplaceWith property procedure implements the ReplaceWith property.
        <System.ComponentModel.Description("Specifies the string to replace with.")> _
        Public Property ReplaceWith() As String Implements IFindReplaceDialog.ReplaceWith
            Get
                Try
                    ' Return the string we are replacing with.
                    If IsNothing(replaceWithString) Then
                        replaceWithString = ""
                    End If
                    Return replaceWithString
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As String)
                Try
                    ' Set the string we are replacing with.
                    replaceWithString = Value
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property


        ' The Type property procedure implements the Type property.
        <System.ComponentModel.DefaultValue(FindReplaceDialogType.Find), _
            System.ComponentModel.Description("Specifies which type of dialog should be displayed.")> _
        Public Property Type() As FindReplaceDialogType Implements IFindReplaceDialog.Type
            Get
                Try
                    'Return the type of dialog.
                    Return dialogType
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Get
            Set(ByVal Value As FindReplaceDialogType)
                Try
                    ' Set the type of dialog.
                    dialogType = Value

                    ' If it is a Replace dialog, then set the DirectionVisible
                    ' and DirectionEnabled properties to False, since Replace
                    ' dialogs cannot display the Directional options.
                    If Value = FindReplaceDialogType.Replace Then
                        Me.DirectionVisible = False
                        Me.DirectionEnabled = False
                    End If
                Catch ex As System.Exception
                    Throw ex
                End Try
            End Set
        End Property
#End Region

#Region "IFindReplace Method Implementation"
        ' This region contains code which implements the methods defined in the IFindReplace interface.
        Public Sub Show(ByVal windowOwner As IWin32Window) Implements IFindReplaceDialog.Show
            Dim structFindReplace As FindReplace.structFindReplace
            Try

                ' If the common dialog's FindReplace and Help messages have not
                ' been registered, then call RegisterWindowMessage.
                If findMessage = 0 Then
                    findMessage = RegisterWindowMessage("commdlg_FindReplace")
                    helpMessage = RegisterWindowMessage("commdlg_help")
                End If


                ' Subclass the owner window of the dialog
                Owner.AssignHandle(windowOwner.Handle)
                CleanUp()

                ' Set the members of the structure accordingly
                structFindReplace.hwndOwner = windowOwner.Handle
                structFindReplace.cbSize = Marshal.SizeOf(GetType(FindReplace.structFindReplace))
                findWhatPointer = StringToPointer(Me.FindWhat, structFindReplace.findWhatLen)
                structFindReplace.findWhat = findWhatPointer
                replaceWithPointer = StringToPointer(ReplaceWith, structFindReplace.replaceWithLen)
                structFindReplace.replaceWith = replaceWithPointer
                structFindReplace.findReplaceFlags = FindReplaceFlags
                structFindReplace.hInstance = IntPtr.Zero
                findReplacePointer = Marshal.AllocHGlobal(Marshal.SizeOf(structFindReplace))
                Marshal.StructureToPtr(structFindReplace, findReplacePointer, True)

                ' Start filtering messages by calling the AddMessageFilter and passing the instance
                ' of the class.
                Application.AddMessageFilter(Me)

                ' Set the windowHandle to the appropriate type of dialog.
                If dialogType = FindReplaceDialogType.Find Then
                    windowHandle = FindText(findReplacePointer)
                Else
                    windowHandle = ReplaceText(findReplacePointer)
                End If

                ' If the windowHandle isn't set, throw an exception
                If windowHandle.Equals(IntPtr.Zero) = True Then
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error())
                End If
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean) Implements IFindReplaceDialog.Dispose
            Try

                ' Dispose the base class and then clean up
                MyBase.Dispose(disposing)
                CleanUp()
                If windowHandle.Equals(IntPtr.Zero) = False Then
                    DestroyWindow(windowHandle)
                    Application.RemoveMessageFilter(Me)
                End If
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        Public Sub FindString(ByVal sourceControl As System.Windows.Forms.TextBox) Implements IFindReplaceDialog.FindString
            FindReplaceString(sourceControl, FindReplaceOperation.FindOnly)
        End Sub

        Public Sub ReplaceString(ByVal sourceControl As System.Windows.Forms.TextBox, ByVal ReplaceAll As Boolean) Implements IFindReplaceDialog.ReplaceString
            If ReplaceAll = True Then
                FindReplaceString(sourceControl, FindReplaceOperation.ReplaceAll)
            Else
                FindReplaceString(sourceControl, FindReplaceOperation.Replace)
            End If
        End Sub

        Enum FindReplaceOperation
            FindOnly = 1
            Replace = 2
            ReplaceAll = 3
        End Enum


#End Region

#Region "Helper Methods"

        Private Function Search(ByVal sourceControl As TextBox, ByVal searchText As String, ByVal findWhat As String, ByVal compareMode As CompareMethod, ByVal direction As FindDirection, ByVal startIndex As Integer) As Integer
            Dim foundLocation As Integer

            If direction = FindDirection.Down Then
                foundLocation = InStr(startIndex, searchText, findWhat, compareMode)

                If foundLocation > 0 Then
                    If Me.MatchWholeWord = True Then
                        Do
                            If IsWholeWord(foundLocation, searchText, findWhat) = True Then
                                Exit Do
                            Else
                                startIndex += 1
                                foundLocation = InStr(startIndex, searchText, findWhat, compareMode)
                            End If
                        Loop Until foundLocation = 0
                    End If
                    Return foundLocation
                Else
                    Return -1
                End If

            Else
                If startIndex > 0 Then
                    foundLocation = InStrRev(searchText, findWhat, startIndex, compareMode)
                    If Me.MatchWholeWord = True Then
                        Do
                            If IsWholeWord(foundLocation, searchText, findWhat) = True Then
                                Exit Do
                            Else
                                startIndex -= 1
                                foundLocation = InStrRev(searchText, findWhat, startIndex, compareMode)
                            End If
                        Loop Until foundLocation = 0
                    End If
                    Return foundLocation
                Else
                    Return -1
                End If
            End If
        End Function

        Private Sub FindReplaceString(ByVal sourceControl As TextBox, ByVal operation As FindReplaceOperation)

            Dim compareMode As CompareMethod
            Dim direction As FindDirection
            Dim findWhat As String
            Dim searchText As String
            Dim stringReturn As String
            Dim startPosition As Integer
            Dim foundLocation As Integer
            Dim currentLocation As Integer
            Dim numberFound As Integer

            findWhat = Me.FindWhat
            searchText = sourceControl.Text
            direction = Me.Direction

            If Me.MatchCase = True Then
                compareMode = CompareMethod.Binary
            Else
                compareMode = CompareMethod.Text
            End If

            If direction = FindDirection.Down Then
                startPosition = sourceControl.SelectionStart + sourceControl.SelectionLength + 1
            Else
                startPosition = sourceControl.SelectionStart
            End If

            If operation = FindReplaceOperation.FindOnly Then
                foundLocation = Search(sourceControl, searchText, findWhat, compareMode, direction, startPosition)
                If foundLocation >= 0 Then
                    sourceControl.Select(foundLocation - 1, Len(findWhat))
                    sourceControl.Focus()
                    OnTextFound(sourceControl, findWhat, foundLocation - 1)
                Else
                    OnSearchFailed(sourceControl, findWhat)
                End If

            ElseIf operation = FindReplaceOperation.Replace Then
                If StrComp(sourceControl.SelectedText, findWhat, compareMode) = 0 Then
                    foundLocation = sourceControl.SelectionStart
                    stringReturn = Left(searchText, foundLocation) & _
                        VB.Replace(searchText, findWhat, Me.ReplaceWith, foundLocation + 1, 1, compareMode)
                    sourceControl.Text = stringReturn
                    sourceControl.Select(foundLocation, Len(ReplaceWith))
                    sourceControl.Focus()
                Else
                    foundLocation = Search(sourceControl, searchText, findWhat, compareMode, direction, startPosition)
                    If foundLocation >= 0 Then
                        sourceControl.Select(foundLocation - 1, Len(findWhat))
                        sourceControl.Focus()
                    Else
                        OnSearchFailed(sourceControl, findWhat)
                    End If
                End If
            Else
                foundLocation = Search(sourceControl, searchText, findWhat, compareMode, direction, startPosition)
                If foundLocation >= 0 Then
                    While foundLocation >= 1
                        searchText = Left(searchText, foundLocation - 1) & _
                            VB.Replace(searchText, findWhat, Me.ReplaceWith, foundLocation, 1, compareMode)
                        startPosition += 1
                        currentLocation = foundLocation + Me.ReplaceWith.Length
                        foundLocation = Search(sourceControl, searchText, findWhat, compareMode, direction, currentLocation)
                        numberFound += 1
                    End While
                    sourceControl.Text = searchText
                    sourceControl.Select(0, 0)
                    sourceControl.Focus()
                Else
                    OnSearchFailed(sourceControl, findWhat)
                End If
            End If
        End Sub

        Private Function IsWholeWord(ByVal startIndex As Integer, ByVal searchText As String, ByVal findWhat As String) As Boolean

            Dim firstCharacter As String
            Dim lastCharacter As String
            Dim firstCharacterFound As Boolean
            Dim lastCharacterFound As Boolean

            Try
                If startIndex > 1 Then
                    firstCharacter = Mid(searchText, startIndex - 1, 1)
                Else
                    firstCharacter = ""
                End If

                lastCharacter = Mid(searchText, startIndex + Len(findWhat), 1)
                firstCharacterFound = wordPrefixes.IndexOf(firstCharacter) >= 0
                lastCharacterFound = wordTerminators.IndexOf(lastCharacter) >= 0

                Return firstCharacterFound And lastCharacterFound
            Catch ex As System.Exception
                Throw ex
            End Try
        End Function

        Private Function StringToPointer(ByVal stringIn As String, ByRef length As Short) As IntPtr
            Dim stringPointer As IntPtr
            Try
                ' Accept a string and pass back a pointer to the string.
                stringPointer = Marshal.StringToHGlobalAuto(stringIn)
                length = CType(stringIn.Length, Short)
                If (stringIn Is Nothing) Or (stringIn.Length < bufferSize) Then
                    stringPointer = Marshal.ReAllocHGlobal(stringPointer, New IntPtr(bufferSize * Marshal.SystemDefaultCharSize))
                    length = CType(bufferSize, Short)
                End If
                Return stringPointer
            Catch ex As System.Exception
                Throw ex
            End Try
        End Function

        Private Sub SetOption(ByVal findReplaceOption As FindReplaceEnum, ByVal enableOption As Boolean)
            ' The SetOption method is used by the Property procedures in this class in order to
            ' set the bits of different options. The caller passes in which bit to set, and whether
            ' or not it should be set.

            Try
                If enableOption = True Then
                    FindReplaceDialog.FindReplaceFlags = (FindReplaceDialog.FindReplaceFlags Or findReplaceOption)
                Else
                    FindReplaceDialog.FindReplaceFlags = FindReplaceDialog.FindReplaceFlags And Not findReplaceOption
                End If
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        Private Function GetOption(ByVal findReplaceOption As FindReplaceEnum) As Boolean
            ' The SetOption method is used by the Property procedures in this class in order to
            ' determine the bit state of specific options. The caller passes in which bit to retrieve,
            ' and the method returns True or False depending on whether it is set or not.

            Dim optionEnabled As Boolean
            Try
                optionEnabled = (FindReplaceDialog.FindReplaceFlags And findReplaceOption) <> 0
                Return optionEnabled
            Catch ex As System.Exception
                Throw ex
            End Try
        End Function

        Private Sub CleanUp()

            ' The CleanUp method is used to free resources used the FindReplace dialog.
            ' If the pointers for the Find and Replace dialogs we free them.
            Dim structFindReplace As FindReplace.structFindReplace
            Try
                If findWhatPointer.Equals(IntPtr.Zero) = False Then
                    Marshal.FreeHGlobal(findWhatPointer)
                End If

                If replaceWithPointer.Equals(IntPtr.Zero) = False Then
                    Marshal.FreeHGlobal(replaceWithPointer)
                End If

                If findReplacePointer.Equals(IntPtr.Zero) = False Then
                    structFindReplace = CType(Marshal.PtrToStructure(findReplacePointer, _
                        GetType(FindReplace.structFindReplace)), FindReplace.structFindReplace)
                    Marshal.FreeHGlobal(findReplacePointer)
                End If
                findReplacePointer = IntPtr.Zero
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        Friend Sub HandleHlpMsg(ByVal forwardedMessage As System.Windows.Forms.Message)
            OnHelp()
        End Sub

        Friend Sub HandleFindMsgString(ByVal forwardedMessage As System.Windows.Forms.Message)

            ' The HandleFindMsgString method is called if the message listener detects
            ' a Find or Replace dialog message. The calling procedure passes the filtered
            ' message to this method, and it calls the appropriate method to raise events.
            Dim structFindReplace As FindReplace.structFindReplace
            Try
                structFindReplace = CType(Marshal.PtrToStructure(forwardedMessage.LParam, GetType(FindReplace.structFindReplace)), FindReplace.structFindReplace)
                FindReplaceFlags = structFindReplace.findReplaceFlags
                findWhatString = Marshal.PtrToStringAuto(structFindReplace.findWhat)
                replaceWithString = Marshal.PtrToStringAuto(structFindReplace.replaceWith)
                If GetOption(FindReplaceEnum.DialogTerm) = True Then
                    SetOption(FindReplaceEnum.DialogTerm, False)
                    OnDialogTerminate()
                ElseIf GetOption(FindReplaceEnum.FindNext) = True Then
                    SetOption(FindReplaceEnum.FindNext, False)
                    OnFindNextClick()
                ElseIf GetOption(FindReplaceEnum.Replace) = True Then
                    SetOption(FindReplaceEnum.Replace, False)
                    OnReplaceClick()
                ElseIf GetOption(FindReplaceEnum.ReplaceAll) = True Then
                    SetOption(FindReplaceEnum.ReplaceAll, False)
                    OnReplaceAllClick()
                End If
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub
#End Region

    End Class
End Namespace