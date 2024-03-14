Option Strict On
Option Explicit On 
Option Compare Text

Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Namespace FindReplace
    Friend Class OwnerWindow
        Inherits NativeWindow

        Private parent As FindReplace.FindReplaceDialog

        Friend Sub New(ByVal FindReplaceDialogIn As FindReplace.FindReplaceDialog)

            ' Constructor for the OwnerWindow class. The parent FindReplaceDialog class
            ' is passed in to the constructor and is cached in the parent field.
            Try
                parent = FindReplaceDialogIn
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub

        Protected Overrides Sub WndProc(ByRef interceptedMessage As System.Windows.Forms.Message)

            ' This method listens for Windows messages. If it detects a FindMessage
            ' it calls the HandleFindMsgString method and forwards the message. If it
            ' detects a HelpMessage, it calls the owner's OnHelp method to raise the
            ' Help event. It ignores all other messages.
            Try
                If interceptedMessage.HWnd.Equals(Me.Handle) = True Then
                    If interceptedMessage.Msg = FindReplaceDialog.findMessage Then
                        parent.HandleFindMsgString(interceptedMessage)
                    ElseIf interceptedMessage.Msg = FindReplaceDialog.helpMessage Then
                        parent.HandleHlpMsg(interceptedMessage)
                    Else
                        MyBase.DefWndProc(interceptedMessage)
                    End If
                Else
                    MyBase.DefWndProc(interceptedMessage)
                End If
            Catch ex As System.Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace