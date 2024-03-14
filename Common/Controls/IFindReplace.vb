Option Strict On
Option Explicit On 
Option Compare Text

Imports System.Windows.Forms
Public Interface IFindReplaceDialog

#Region "Events"
    Event ReplaceClick()
    Event ReplaceAllClick()
    Event FindNextClick()
    Event DialogTerminate()
    Event Help()
    Event SearchFailed(ByVal eventArguments As FindReplace.FindReplaceEventArgs)
    Event TextFound(ByVal eventArguments As FindReplace.FindReplaceEventArgs)
#End Region

#Region "Methods"
    Sub Dispose(ByVal disposing As Boolean)
    Sub FindString(ByVal sourceControl As TextBox)
    Sub ReplaceString(ByVal sourceControl As TextBox, ByVal ReplaceAll As Boolean)
    Sub Show(ByVal windowOwner As IWin32Window)
#End Region

#Region "Properties"

    Property Direction() As FindReplace.FindDirection
    Property DirectionEnabled() As Boolean
    Property DirectionVisible() As Boolean
    Property FindWhat() As String
    Property HelpVisible() As Boolean
    Property MatchCase() As Boolean
    Property MatchCaseEnabled() As Boolean
    Property MatchCaseVisible() As Boolean
    Property MatchWholeWord() As Boolean
    Property ReplaceWith() As String
    Property Type() As FindReplace.FindReplaceDialogType
    Property MatchWholeWordEnabled() As Boolean
    Property MatchWholeWordVisible() As Boolean
#End Region

End Interface