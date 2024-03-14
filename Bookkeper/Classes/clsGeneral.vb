Public Class clsGeneral

    Public Sub New(ByVal fn As String, ByVal path As String, ByVal userId As Integer, ByVal roleId As Integer, ByVal gProduct As String)
        gConnStringFileName = fn
        gApplicationPath = path
        gUserID = userId
        gRoleID = roleId
        gAssemblyProduct = gProduct
        ImageDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\images"
        PresetDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & gAssemblyProduct & "\presets"
    End Sub

    Public Enum lstButton
        add
        edit
        view
    End Enum
    Public Shared Sub autoSuggestTextBox(ByRef txt As TextBox, ByRef mysql As PowerNET8.mySQL.Init.SQL, ByVal fieldname As String, ByVal tablename As String)
        Dim mydata As DataTable = mysql.Query("SELECT DISTINCT " + fieldname + " from " + tablename)
        With txt
            For i As Integer = 0 To mydata.Rows.Count - 1
                .AutoCompleteCustomSource.Add(mydata.Rows(i).Item(0).ToString)
            Next
            .AutoCompleteMode = AutoCompleteMode.SuggestAppend
            .AutoCompleteSource = AutoCompleteSource.CustomSource
        End With
    End Sub
    Public Function NwfrmTypeLoanFinder() As Form
        Try
            NwfrmTypeLoanFinder = New frmTypeLoanFinder
            Return NwfrmTypeLoanFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function NwfrmLoanRateFinder() As Form
        Try
            NwfrmLoanRateFinder = New frmLoanRateFinder
            Return NwfrmLoanRateFinder
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Sub setButton(ByRef lstButton As ToolBar, ByVal action As lstButton)
        Select Case action
            Case clsGeneral.lstButton.add
                With lstButton
                    .Buttons.Item(0).Visible = False 'add
                    .Buttons.Item(1).Visible = False 'edit
                    .Buttons.Item(2).Visible = False 'delete
                    .Buttons.Item(3).Visible = False 'find
                    .Buttons.Item(4).Visible = True 'save
                    .Buttons.Item(5).Visible = True 'cancel
                    .Buttons.Item(6).Visible = False 'approved
                End With
            Case clsGeneral.lstButton.view
                With lstButton
                    .Buttons.Item(0).Visible = True 'add
                    .Buttons.Item(1).Visible = True 'edit
                    .Buttons.Item(2).Visible = False 'delete
                    .Buttons.Item(3).Visible = True 'find
                    .Buttons.Item(4).Visible = False 'save
                    .Buttons.Item(5).Visible = False 'cancel
                    .Buttons.Item(6).Visible = False 'approved
                End With
            Case clsGeneral.lstButton.edit
                With lstButton
                    .Buttons.Item(0).Visible = False 'add
                    .Buttons.Item(1).Visible = False 'edit
                    .Buttons.Item(2).Visible = False 'delete
                    .Buttons.Item(3).Visible = False 'find
                    .Buttons.Item(4).Visible = True 'save
                    .Buttons.Item(5).Visible = True 'cancel
                    .Buttons.Item(6).Visible = False 'approved
                End With
        End Select

    End Sub


End Class
