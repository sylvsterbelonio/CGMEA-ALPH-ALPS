Public Class clsSkin

    'textbox attributes'
    Private Shared textbox_highlight_backcolor As String = "#fffcdb"
    Private Shared textbox_normal_backcolor As String = "#FFFFFF"
    Private Shared textbox_highlight_forecolor As String = "#000000"
    Private Shared textbox_normal_forecolor As String = "#000000"

    'form attributes'


#Region "OBJECT IDENTIFIER FUNCTIONS"

    Private Shared colObject As New Collection

    Public Shared Function getLogo() As Image
        Return My.Resources.coverGroup700px
    End Function

    Public Shared Function getMainBackGroun() As Image
        Return My.Resources.Christmas_image_christmas_36118465_1920_1200
    End Function

    Enum ToolIcons
        add
        edit
        delete
        cancel
        print
    End Enum


    Public Shared Sub setTemplate(ByRef forms As Form)
        colObject.Clear()
        IdentifyMainObject(colObject, forms)
        textboxSkin(colObject)
    End Sub

    Private Shared Sub applyThemes()
        For Each obj As Object In colObject
            If TypeOf obj Is TextBox Then
                textboxSkin(colObject)
            End If
        Next
    End Sub


    Private Shared Sub IdentifyMainObject(ByRef colObjects As Collection, ByRef forms As Form)
        With colObjects
            .Clear()
            Dim cControl As Control
            For Each cControl In forms.Controls
                If (TypeOf cControl Is GroupBox) Then
                    .Add(CType(cControl, GroupBox))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is Panel Then
                    .Add(CType(cControl, Panel))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is CheckBox Then
                    .Add(CType(cControl, CheckBox))
                ElseIf (TypeOf cControl Is SplitContainer) Then
                    .Add(CType(cControl, SplitContainer))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf (TypeOf cControl Is TableLayoutPanel) Then
                    .Add(CType(cControl, TableLayoutPanel))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor Then
                    .Add(CType(cControl, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor))
                ElseIf (TypeOf cControl Is Infragistics.Win.UltraWinTabControl.UltraTabControl) Then
                    .Add(CType(cControl, Infragistics.Win.UltraWinTabControl.UltraTabControl))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf (TypeOf cControl Is TabControl) Then
                    .Add(CType(cControl, TabControl))
                    IdentifySubMainObject(colObjects, cControl)
                Else
                    .Add(cControl)
                End If
            Next cControl
            .Add(forms)
        End With
    End Sub

    Private Shared Sub IdentifySubMainObject(ByRef colObjects As Collection, ByRef listOjbect As Object)
        Dim cControl As Control
        With colObjects
            For i As Integer = (listOjbect.Controls.Count - 1) To 0 Step -1
                cControl = listOjbect.Controls(i)
                If (TypeOf cControl Is GroupBox) Then
                    .Add(CType(cControl, GroupBox))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf (TypeOf cControl Is Infragistics.Win.UltraWinTabControl.UltraTabControl) Then
                    .Add(CType(cControl, Infragistics.Win.UltraWinTabControl.UltraTabControl))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is Infragistics.Win.UltraWinTabControl.UltraTabPageControl Then
                    .Add(CType(cControl, Infragistics.Win.UltraWinTabControl.UltraTabPageControl))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is Panel Then
                    .Add(CType(cControl, Panel))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is CheckBox Then
                    .Add(CType(cControl, CheckBox))
                ElseIf (TypeOf cControl Is SplitContainer) Then
                    .Add(CType(cControl, SplitContainer))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf (TypeOf cControl Is TableLayoutPanel) Then
                    .Add(CType(cControl, TableLayoutPanel))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf (TypeOf cControl Is Infragistics.Win.UltraWinTabControl.UltraTabPageControl) Then
                    .Add(CType(cControl, Infragistics.Win.UltraWinTabControl.UltraTabPageControl))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf (TypeOf cControl Is TabPage) Then
                    .Add(CType(cControl, TabPage))
                    IdentifySubMainObject(colObjects, cControl)
                ElseIf TypeOf cControl Is StatusStrip Then
                    .Add(cControl)
                Else
                    .Add(cControl)
                End If
            Next i
        End With
    End Sub


#Region "TEXTBOX"

    Private Shared Sub textboxSkin(ByRef colobjects As Collection)
        For Each obj As Object In colobjects
            If TypeOf obj Is TextBox Then
                With CType(obj, TextBox)
                    AddHandler .GotFocus, AddressOf T_GotFocus
                    AddHandler .LostFocus, AddressOf T_LostFocus
                End With
            End If
        Next
    End Sub

    Private Shared Sub T_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        With CType(sender, TextBox)
            If .ReadOnly = False Then
                .BackColor = getRGBColor(textbox_highlight_backcolor)
                .ForeColor = getRGBColor(textbox_normal_forecolor)
            End If
        End With
    End Sub

    Private Shared Sub T_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        With CType(sender, TextBox)
            If .ReadOnly = False Then
                .BackColor = getRGBColor(textbox_normal_backcolor)
                .ForeColor = getRGBColor(textbox_normal_forecolor)
            End If
        End With
    End Sub


#End Region




#End Region


    Public Shared Function getRGBColor(ByVal values As String) As Color
        If Not values Is Nothing Or values <> "" Then
            If Not values.Contains("#") Then values = "#" + values
            Return ColorTranslator.FromHtml(values)
        Else
            Return Color.Empty
        End If
    End Function

End Class
