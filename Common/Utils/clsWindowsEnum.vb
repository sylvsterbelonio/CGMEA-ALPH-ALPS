Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Namespace Messaging.Utils

    Friend NotInheritable Class WindowsEnum

        Public Delegate Sub WindowFilterHandler(ByVal hWnd As IntPtr, ByRef include As Boolean)

        Private winEnumList As List(Of IntPtr)

        Private filterHandler As WindowFilterHandler

        Public Sub New(ByVal filterHandler As WindowFilterHandler)
            Me.New()
            Me.filterHandler = filterHandler
        End Sub

        Public Sub New()
        End Sub

        Public Function Enumerate(ByVal parent As IntPtr) As List(Of IntPtr)
            Me.winEnumList = New List(Of IntPtr)()
            Native.Win32.EnumChildWindows(parent, AddressOf OnWindowEnum, IntPtr.Zero)
            Return Me.winEnumList
        End Function

        Private Function OnWindowEnum(ByVal hWnd As IntPtr, ByVal lParam As Integer) As Integer
            Dim include As Boolean = True
            If Not filterHandler Is Nothing Then
                filterHandler(hWnd, include)
            End If
            If include Then
                Me.winEnumList.Add(hWnd)
            End If
            Return 1
        End Function
    End Class
End Namespace