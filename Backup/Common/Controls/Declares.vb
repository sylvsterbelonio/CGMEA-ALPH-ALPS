Option Explicit On 
Option Strict On
Option Compare Text

Imports System.Runtime.InteropServices
Namespace FindReplace
    Module basDeclares
        'Win32 API Declarations for PInvoke
        Friend Declare Auto Function FindText Lib "Comdlg32" (ByVal lpfr As IntPtr) As IntPtr
        Friend Declare Auto Function ReplaceText Lib "Comdlg32" (ByVal lpfr As IntPtr) As IntPtr
        Friend Declare Auto Function RegisterWindowMessage Lib "User32" Alias "RegisterWindowMessageA" (<MarshalAs(UnmanagedType.LPStr)> ByVal message As String) As Integer
        Friend Declare Auto Function DestroyWindow Lib "User32" (ByVal hwnd As IntPtr) As Integer
        Friend Declare Auto Function IsDialogMessage Lib "User32" (ByVal hWnd As IntPtr, ByRef m As Windows.Forms.Message) As Boolean
    End Module
End Namespace