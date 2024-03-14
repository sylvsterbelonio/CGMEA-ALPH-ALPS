Option Strict On
Option Explicit On 
Option Compare Text

Imports System.Runtime.InteropServices

Namespace FindReplace

    ' Structure to hold the options for the FindReplaceDialog. For more
    ' information, see the MSDN documentation on the FINDREPLACE structure.
    '
    ' ms-help://MS.VSCC/MS.MSDNVS/winui/commdlg_4uwi.htm


    <System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)> _
    Friend Structure structFindReplace
        Friend cbSize As Integer            ' Specifies the length (in bytes) of the structure.
        Friend hwndOwner As IntPtr          ' Handle to the window that owns the dialog box.
        Friend hInstance As IntPtr          ' hInstance is a handle to a memory object containing a dialog box template. Not used in this example.
        Friend findReplaceFlags As Integer  ' Bit flags used to initialize the dialog box. 
        Friend findWhat As IntPtr           ' Pointer to a string typed by the user in the Find What edit control.
        Friend replaceWith As IntPtr        ' Pointer to a string typed by the user in the Replace With edit control.
        Friend findWhatLen As Short         ' Specifies the length(in bytes) of the buffer pointed to by the findWhat member. 
        Friend replaceWithLen As Short      ' Specifies the length(in bytes) of the buffer pointed to by the replaceWith member. 
        Friend custData As IntPtr           ' Specifies application-defined data that the system passes to the hook procedure. Not used in this example.
        Friend hookProc As IntPtr           ' Pointer to an FRHookProc hook procedure that can process messages intended for the dialog box. Not used in this example.
        Friend templateName As IntPtr       ' Pointer to a string that names the dialog box template resource in the module identified by the hInstance member. Not used in this example.
    End Structure
End Namespace