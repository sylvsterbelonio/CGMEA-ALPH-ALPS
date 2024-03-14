Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmCrystalReportViewer
    Inherits System.Windows.Forms.Form
    ' value of parameter
    Public hsParameter As New Hashtable
    Public ds As DataSet
    Public ReportOrientation As Integer
    Public ReportPaperSize As Integer
    Public blnDataSource As Boolean
    Public ReportTitle As String
    Private clsCommon As New Common.Common
    Friend ReportPath As String

    Public WithEvents oRpt As ReportDocument

    Dim paramFields As New ParameterFields
    Dim paramField As New ParameterField

    Dim discreteVal As New ParameterDiscreteValue

    Public WriteOnly Property DisplayGroupTree() As Boolean
        Set(ByVal Value As Boolean)
            Me.crptViewer.DisplayGroupTree = Value
        End Set
    End Property

    Private Sub frmCrystalReportViewer_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        crptViewer = Nothing
        oRpt.Close()
        oRpt.Dispose()
    End Sub

    Private Sub frmCrystalReportViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        Try
            Dim logOnInfo As New TableLogOnInfo
            oRpt = New ReportDocument

            oRpt.Load(ReportPath)

            If Not blnDataSource Then
                Logon(oRpt)
                crptViewer.ParameterFieldInfo = SetParameterField()
            Else
                'Logon(oRpt)
                oRpt.SetDataSource(ds)
                Try
                    'hsParameter = New Hashtable
                    Dim myenum As IDictionaryEnumerator = hsParameter.GetEnumerator

                    While myenum.MoveNext
                        oRpt.ParameterFields.Item(myenum.Key).CurrentValues.AddValue(myenum.Value)
                    End While
                    hsParameter.Clear()
                    myenum.Reset()
                Catch ex As Exception

                End Try
            End If

            With oRpt
                If ReportOrientation = 0 Then
                    .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Portrait
                Else
                    .PrintOptions.PaperOrientation = CrystalDecisions.[Shared].PaperOrientation.Landscape
                End If

                If ReportPaperSize = 0 Then
                    .PrintOptions.PaperSize = CrystalDecisions.[Shared].PaperSize.PaperLetter
                ElseIf ReportPaperSize = 1 Then
                    .PrintOptions.PaperSize = CrystalDecisions.[Shared].PaperSize.PaperLegal
                ElseIf ReportPaperSize = 2 Then
                    .PrintOptions.PaperSize = CrystalDecisions.[Shared].PaperSize.PaperA3
                ElseIf ReportPaperSize = 3 Then
                    .PrintOptions.PaperSize = CrystalDecisions.[Shared].PaperSize.PaperA4
                ElseIf ReportPaperSize = 4 Then
                    .PrintOptions.PaperSize = CrystalDecisions.[Shared].PaperSize.PaperB5
                End If
            End With

            crptViewer.ReportSource = oRpt
            Me.Text = ReportTitle
        Catch ex As Exception

        End Try
    End Sub

    Private Function SetParameterField() As ParameterFields
        Try
            'hsParameter = New Hashtable
            Dim myenum As IDictionaryEnumerator = hsParameter.GetEnumerator

            While myenum.MoveNext
                paramField = New ParameterField
                discreteVal = New ParameterDiscreteValue

                paramField.ParameterFieldName = myenum.Key
                discreteVal.Value = myenum.Value
                paramField.CurrentValues.Add(discreteVal)
                paramFields.Add(paramField)
            End While
            hsParameter.Clear()
            myenum.Reset()
            Return paramFields
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub frmCrystalReportViewer_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.crptViewer.Width = Me.Width - 10
        Me.crptViewer.Height = Me.Height - 10
    End Sub

    Function ApplyLogon(ByVal cr As ReportDocument, ByVal ci As ConnectionInfo) As Boolean
        Dim li As TableLogOnInfo
        Dim tbl As Table

        ' for each table apply connection info 
        For Each tbl In cr.Database.Tables
            li = tbl.LogOnInfo
            li.ConnectionInfo = ci
            tbl.ApplyLogOnInfo(li)

            ' check if logon was successful 
            ' if TestConnectivity returns false, check logon credentials 

            If (tbl.TestConnectivity()) Then
                'drop fully qualified table location 
                If (tbl.Location.IndexOf(".") > 0) Then
                    tbl.Location = tbl.Location.Substring(tbl.Location.LastIndexOf(".") + 1)
                Else
                    tbl.Location = tbl.Location
                End If
            Else
                Return False
            End If

        Next
        Return True
    End Function

    Function Logon(ByVal cr As ReportDocument) As Boolean
        Dim ci As New ConnectionInfo
        Dim subObj As SubreportObject

        ci = clsCommon.GetConnectionInfo(gConnStringFileName)

        If Not (ApplyLogon(cr, ci)) Then
            Return False
        End If

        Dim obj As ReportObject

        For Each obj In cr.ReportDefinition.ReportObjects()
            If (obj.Kind = ReportObjectKind.SubreportObject) Then
                subObj = CType(obj, SubreportObject)
                If Not (ApplyLogon(cr.OpenSubreport(subObj.SubreportName), ci)) Then
                    Return False
                End If
            End If
        Next
        Return True
    End Function

End Class