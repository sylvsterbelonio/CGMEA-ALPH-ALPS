Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.InteropServices

Namespace Messaging.Native

    Friend Class Win32

        Public Const WM_COPYDATA As Integer = &H4A

        Public Const WS_CHILD As UInteger = &H40000000

        <StructLayout(LayoutKind.Sequential)> _
        Public Structure COPYDATASTRUCT

            Public dwData As IntPtr
            Public cbData As Integer
            Public lpData As IntPtr

        End Structure

        <DllImport("user32.dll", EntryPoint:="GetDesktopWindow")> _
        Public Shared Function GetDesktopWindow() As IntPtr
        End Function

        <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
        Public Shared Function SendMessage( _
            ByVal hwnd As IntPtr, _
            ByVal wMsg As Integer, _
            ByVal wParam As Integer, _
            ByRef lParam As COPYDATASTRUCT) _
            As Integer
        End Function

        Public Delegate Function EnumWindowsProc(ByVal hWnd As IntPtr, ByVal lParam As Integer) As Integer

        <DllImport("user32.dll")> _
        Public Shared Function EnumChildWindows( _
            ByVal hWndParent As IntPtr, _
            ByVal lpEnumFunc As EnumWindowsProc, _
            ByVal lParam As IntPtr) _
            As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function GetProp( _
            ByVal hwnd As IntPtr, _
            ByVal lpString As String) _
            As Integer
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function SetProp( _
            ByVal hWnd As IntPtr, _
            ByVal propertyString As String, _
            ByVal data As IntPtr) As Integer
        End Function

        <DllImport("user32", CharSet:=CharSet.Auto)> _
        Public Shared Function RemoveProp( _
            ByVal hWnd As IntPtr, _
            ByVal propertyString As String) As Integer
        End Function

    End Class

End Namespace
