Option Strict On
Option Explicit On 
Option Compare Text

Namespace FindReplace

    'Determines which member of the dialog we are setting or getting.
    Friend Enum FindReplaceEnum
        Down = &H1
        MatchWholeWord = &H2
        MatchCase = &H4
        FindNext = &H8
        Replace = &H10
        ReplaceAll = &H20
        DialogTerm = &H40
        ShowHelp = &H80
        EnableHook = &H100
        EnableTemplate = &H200
        DisableUpDown = &H400
        DisableMatchCase = &H800
        DisableWholeWord = &H1000
        EnableTemplateHandle = &H2000
        HideUpDown = &H4000
        HideMatchCase = &H8000
        HideWholeWord = &H10000
    End Enum

End Namespace