Imports System.Reflection
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing
Imports System.Text.RegularExpressions
Imports Microsoft.Win32

Public Class frmAbout
    Inherits System.Windows.Forms.Form

    Private _EntryAssemblyName As String
    Private _CallingAssemblyName As String
    Private _ExecutingAssemblyName As String
    Private _EntryAssembly As System.Reflection.Assembly
    Private _EntryAssemblyAttribCollection As Specialized.NameValueCollection

    Private clsCommon As New Common.Common
    Public gifLogo As Image = MyTemplates.clsSkin.getLogo

    Public Property AppEntryAssembly() As System.Reflection.Assembly
        Get
            Return _EntryAssembly
        End Get
        Set(ByVal Value As System.Reflection.Assembly)
            _EntryAssembly = Value
        End Set
    End Property

    Private Sub frmAbout_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Comments, Credits As String

        Me.Text = "About CGMEA"
        Comments = ""
        Credits = ""
        lblName.Text = modApp.AssemblyProduct
        lblVersion.Text += modApp.AssemblyVersion
        lblBuildDate.Text += System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location).ToShortDateString()
        lblDeveloper.Text += modApp.AssemblyCompany
        llblURL.Text = modApp.AssemblyTrademark
        With pbLogo
            .BackgroundImage = gifLogo
            .BackgroundImageLayout = ImageLayout.Zoom
        End With

        If (Comments = "") Then
            Dim lic As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(Me.GetType).Location) & "\Help\license.rtf"
            If System.IO.File.Exists(lic) Then
                rtfLicense.LoadFile(lic, System.Windows.Forms.RichTextBoxStreamType.RichText)
            End If
        ElseIf (Comments.ToLower().EndsWith(".txt") Or Comments.ToLower().EndsWith(".rtf")) And System.IO.File.Exists(Comments) Then
            If Comments.ToLower().EndsWith(".txt") Then
                rtfLicense.LoadFile(Comments, System.Windows.Forms.RichTextBoxStreamType.RichText)
            Else
                rtfLicense.LoadFile(Comments, System.Windows.Forms.RichTextBoxStreamType.PlainText)
            End If
        Else
            rtfLicense.Text = Comments
        End If

        If (Credits = "") Then
            Dim cre As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetAssembly(Me.GetType).Location) & "\Help\credits.rtf"
            If System.IO.File.Exists(cre) Then
                rtfCredits.LoadFile(cre, System.Windows.Forms.RichTextBoxStreamType.RichText)
            End If
        ElseIf (Credits.ToLower().EndsWith(".txt") Or Credits.ToLower().EndsWith(".rtf")) And System.IO.File.Exists(Credits) Then
            If Credits.ToLower().EndsWith(".txt") Then
                rtfCredits.LoadFile(Credits, System.Windows.Forms.RichTextBoxStreamType.RichText)
            Else
                rtfCredits.LoadFile(Credits, System.Windows.Forms.RichTextBoxStreamType.PlainText)
            End If
        Else
            rtfCredits.Text = Credits
        End If

        lblCopyright.Text = modApp.AssemblyCopyright

        '-- if the user didn't provide an assembly, try to guess which one is the entry assembly
        If _EntryAssembly Is Nothing Then
            _EntryAssembly = [Assembly].GetEntryAssembly
        End If
        If _EntryAssembly Is Nothing Then
            _EntryAssembly = [Assembly].GetExecutingAssembly
        End If

        _ExecutingAssemblyName = [Assembly].GetExecutingAssembly.GetName.Name
        _CallingAssemblyName = [Assembly].GetCallingAssembly.GetName.Name
        Try
            '-- for web hosted apps, GetEntryAssembly = nothing
            _EntryAssemblyName = [Assembly].GetEntryAssembly.GetName.Name
        Catch ex As Exception
        End Try

        PopulateAssemblies()
        PopulateAppInfo()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub llblURL_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles llblURL.Click
        If Not llblURL.Text.ToLower().StartsWith("http://") Then
            Diagnostics.Process.Start("http://" + llblURL.Text)
        Else
            Diagnostics.Process.Start(llblURL.Text)
        End If
    End Sub

    Private Sub btnSystemInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemInfo.Click
        ShowSysInfo()
    End Sub

    Private Shared Function AssemblyLastWriteTime(ByVal a As System.Reflection.Assembly) As DateTime
        Try
            Return File.GetLastWriteTime(a.Location)
        Catch ex As Exception
            Return DateTime.MaxValue
        End Try
    End Function

    Private Shared Function AssemblyBuildDate(ByVal a As System.Reflection.Assembly, _
        Optional ByVal ForceFileDate As Boolean = False) As DateTime

        Dim AssemblyVersion As System.Version = a.GetName.Version
        Dim dt As DateTime

        If ForceFileDate Then
            dt = AssemblyLastWriteTime(a)
        Else
            dt = CType("01/01/2000", DateTime). _
                AddDays(AssemblyVersion.Build). _
                AddSeconds(AssemblyVersion.Revision * 2)
            If TimeZone.IsDaylightSavingTime(dt, TimeZone.CurrentTimeZone.GetDaylightChanges(dt.Year)) Then
                dt = dt.AddHours(1)
            End If
            If dt > DateTime.Now Or AssemblyVersion.Build < 730 Or AssemblyVersion.Revision = 0 Then
                dt = AssemblyLastWriteTime(a)
            End If
        End If

        Return dt
    End Function

    Private Function AssemblyAttribs(ByVal a As System.Reflection.Assembly) As Specialized.NameValueCollection
        Dim TypeName As String
        Dim Name As String
        Dim Value As String
        Dim nvc As New Specialized.NameValueCollection
        Dim r As New Regex("(\.Assembly|\.)(?<Name>[^.]*)Attribute$", RegexOptions.IgnoreCase)

        For Each attrib As Object In a.GetCustomAttributes(False)
            TypeName = attrib.GetType().ToString
            Name = r.Match(TypeName).Groups("Name").ToString
            Value = ""
            Select Case TypeName
                Case "System.CLSCompliantAttribute"
                    Value = CType(attrib, CLSCompliantAttribute).IsCompliant.ToString
                Case "System.Diagnostics.DebuggableAttribute"
                    Value = CType(attrib, Diagnostics.DebuggableAttribute).IsJITTrackingEnabled.ToString
                Case "System.Reflection.AssemblyCompanyAttribute"
                    Value = CType(attrib, AssemblyCompanyAttribute).Company.ToString
                Case "System.Reflection.AssemblyConfigurationAttribute"
                    Value = CType(attrib, AssemblyConfigurationAttribute).Configuration.ToString
                Case "System.Reflection.AssemblyCopyrightAttribute"
                    Value = CType(attrib, AssemblyCopyrightAttribute).Copyright.ToString
                Case "System.Reflection.AssemblyDefaultAliasAttribute"
                    Value = CType(attrib, AssemblyDefaultAliasAttribute).DefaultAlias.ToString
                Case "System.Reflection.AssemblyDelaySignAttribute"
                    Value = CType(attrib, AssemblyDelaySignAttribute).DelaySign.ToString
                Case "System.Reflection.AssemblyDescriptionAttribute"
                    Value = CType(attrib, AssemblyDescriptionAttribute).Description.ToString
                Case "System.Reflection.AssemblyInformationalVersionAttribute"
                    Value = CType(attrib, AssemblyInformationalVersionAttribute).InformationalVersion.ToString
                Case "System.Reflection.AssemblyKeyFileAttribute"
                    Value = CType(attrib, AssemblyKeyFileAttribute).KeyFile.ToString
                Case "System.Reflection.AssemblyProductAttribute"
                    Value = CType(attrib, AssemblyProductAttribute).Product.ToString
                Case "System.Reflection.AssemblyTrademarkAttribute"
                    Value = CType(attrib, AssemblyTrademarkAttribute).Trademark.ToString
                Case "System.Reflection.AssemblyTitleAttribute"
                    Value = CType(attrib, AssemblyTitleAttribute).Title.ToString
                Case "System.Resources.NeutralResourcesLanguageAttribute"
                    Value = CType(attrib, Resources.NeutralResourcesLanguageAttribute).CultureName.ToString
                Case "System.Resources.SatelliteContractVersionAttribute"
                    Value = CType(attrib, Resources.SatelliteContractVersionAttribute).Version.ToString
                Case "System.Runtime.InteropServices.ComCompatibleVersionAttribute"
                    Dim x As Runtime.InteropServices.ComCompatibleVersionAttribute
                    x = CType(attrib, Runtime.InteropServices.ComCompatibleVersionAttribute)
                    Value = x.MajorVersion & "." & x.MinorVersion & "." & x.RevisionNumber & "." & x.BuildNumber
                Case "System.Runtime.InteropServices.ComVisibleAttribute"
                    Value = CType(attrib, Runtime.InteropServices.ComVisibleAttribute).Value.ToString
                Case "System.Runtime.InteropServices.GuidAttribute"
                    Value = CType(attrib, Runtime.InteropServices.GuidAttribute).Value.ToString
                Case "System.Runtime.InteropServices.TypeLibVersionAttribute"
                    Dim x As Runtime.InteropServices.TypeLibVersionAttribute
                    x = CType(attrib, Runtime.InteropServices.TypeLibVersionAttribute)
                    Value = x.MajorVersion & "." & x.MinorVersion
                Case "System.Security.AllowPartiallyTrustedCallersAttribute"
                    Value = "(Present)"
                Case Else
                    '-- debug.writeline("** unknown assembly attribute '" & TypeName & "'")
                    Value = TypeName
            End Select

            If nvc.Item(Name) = "" Then
                nvc.Add(Name, Value)
            End If
        Next

        '-- add some extra values that are not in the AssemblyInfo, but nice to have
        With nvc
            '-- codebase
            Try
                .Add("CodeBase", a.CodeBase.Replace("file:///", ""))
            Catch ex As System.NotSupportedException
                .Add("CodeBase", "(not supported)")
            End Try
            '-- build date
            Dim dt As DateTime = AssemblyBuildDate(a)
            If dt = DateTime.MaxValue Then
                .Add("BuildDate", "(unknown)")
            Else
                .Add("BuildDate", dt.ToString("yyyy-MM-dd hh:mm tt"))
            End If
            '-- location
            Try
                .Add("Location", a.Location)
            Catch ex As System.NotSupportedException
                .Add("Location", "(not supported)")
            End Try
            '-- version
            Try
                If a.GetName.Version.Major = 0 And a.GetName.Version.Minor = 0 Then
                    .Add("Version", "(unknown)")
                Else
                    .Add("Version", a.GetName.Version.ToString)
                End If
            Catch ex As Exception
                .Add("Version", "(unknown)")
            End Try

            .Add("FullName", a.FullName)
        End With

        Return nvc
    End Function

    Private Function RegistryHklmValue(ByVal KeyName As String, ByVal SubKeyRef As String) As String
        Dim rk As RegistryKey
        Try
            rk = Registry.LocalMachine.OpenSubKey(KeyName)
            Return CType(rk.GetValue(SubKeyRef, ""), String)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub ShowSysInfo()
        Dim strSysInfoPath As String = ""

        strSysInfoPath = RegistryHklmValue("SOFTWARE\Microsoft\Shared Tools Location", "MSINFO")
        If strSysInfoPath = "" Then
            strSysInfoPath = RegistryHklmValue("SOFTWARE\Microsoft\Shared Tools\MSINFO", "PATH")
        End If

        If strSysInfoPath = "" Then
            MessageBox.Show("System Information is unavailable at this time." & _
                Environment.NewLine & _
                Environment.NewLine & _
                "(couldn't find path for Microsoft System Information Tool in the registry.)", _
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Process.Start(strSysInfoPath)
        Catch ex As Exception
            MessageBox.Show("System Information is unavailable at this time." & _
                Environment.NewLine & _
                Environment.NewLine & _
                "(couldn't launch '" & strSysInfoPath & "')", _
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Populate(ByVal lvw As ListView, ByVal Key As String, ByVal Value As String)
        If Value = "" Then Return
        Dim lvi As New ListViewItem
        lvi.Text = Key
        lvi.SubItems.Add(Value)
        lvw.Items.Add(lvi)
    End Sub

    Private Sub PopulateAppInfo()
        Dim d As System.AppDomain = System.AppDomain.CurrentDomain
        Populate(lvAppInfo, "Application Name", d.SetupInformation.ApplicationName)
        Populate(lvAppInfo, "Application Base", d.SetupInformation.ApplicationBase)
        Populate(lvAppInfo, "Cache Path", d.SetupInformation.CachePath)
        Populate(lvAppInfo, "Configuration File", d.SetupInformation.ConfigurationFile.ToString.Replace("IRGS2011", "CGMEAS"))
        Populate(lvAppInfo, "Dynamic Base", d.SetupInformation.DynamicBase)
        Populate(lvAppInfo, "Friendly Name", "CGMEAS.vhost.exe")
        Populate(lvAppInfo, "License File", d.SetupInformation.LicenseFile)
        Populate(lvAppInfo, "Private Bin Path", d.SetupInformation.PrivateBinPath)
        Populate(lvAppInfo, "Shadow Copy Directories", d.SetupInformation.ShadowCopyDirectories)
        Populate(lvAppInfo, " ", " ")
        Populate(lvAppInfo, "Entry Assembly", "CGMEAS")
        Populate(lvAppInfo, "Executing Assembly", _ExecutingAssemblyName)
        Populate(lvAppInfo, "Calling Assembly", _CallingAssemblyName)
    End Sub

    Private Sub PopulateAssemblies()
        For Each a As [Assembly] In AppDomain.CurrentDomain.GetAssemblies
            PopulateAssemblySummary(a)
        Next
        cboAssemblyNames.SelectedIndex = cboAssemblyNames.FindStringExact(_EntryAssemblyName)
    End Sub

    Private Sub PopulateAssemblySummary(ByVal a As [Assembly])
        Dim nvc As Specialized.NameValueCollection = AssemblyAttribs(a)

        Dim strAssemblyName As String = a.GetName.Name

        Dim lvi As New ListViewItem
        With lvi
            .Text = strAssemblyName
            .Tag = strAssemblyName
            If strAssemblyName = _CallingAssemblyName Then
                .Text &= " (calling)"
            End If
            If strAssemblyName = _ExecutingAssemblyName Then
                .Text &= " (executing)"
            End If
            If strAssemblyName = _EntryAssemblyName Then
                .Text &= " (entry)"
            End If
            .SubItems.Add(nvc.Item("version"))
            .SubItems.Add(nvc.Item("builddate"))
            .SubItems.Add(nvc.Item("codebase"))
        End With
        lvAssemblyInfo.Items.Add(lvi)
        cboAssemblyNames.Items.Add(strAssemblyName)
    End Sub

    Private Function EntryAssemblyAttrib(ByVal strName As String) As String
        If _EntryAssemblyAttribCollection(strName) = "" Then
            Return "<Assembly: Assembly" & strName & "("""")>"
        Else
            Return _EntryAssemblyAttribCollection(strName).ToString
        End If
    End Function

    Private Sub PopulateAssemblyDetails(ByVal a As System.Reflection.Assembly, ByVal lvw As ListView)
        lvw.Items.Clear()

        '-- this assembly property is only available in framework versions 1.1+
        Populate(lvw, "Image Runtime Version", a.ImageRuntimeVersion)
        Populate(lvw, "Loaded from GAC", a.GlobalAssemblyCache.ToString)

        Dim nvc As Specialized.NameValueCollection = AssemblyAttribs(a)
        For Each strKey As String In nvc
            Populate(lvw, strKey, nvc.Item(strKey))
        Next
    End Sub

    Private Function MatchAssemblyByName(ByVal AssemblyName As String) As [Assembly]
        For Each a As [Assembly] In AppDomain.CurrentDomain.GetAssemblies
            If a.GetName.Name = AssemblyName Then
                Return a
            End If
        Next
        Return Nothing
    End Function

    Private Sub AssemblyInfoListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvAssemblyInfo.DoubleClick
        Dim strAssemblyName As String
        If lvAssemblyInfo.SelectedItems.Count > 0 Then
            strAssemblyName = Convert.ToString(lvAssemblyInfo.SelectedItems(0).Tag)
            cboAssemblyNames.SelectedIndex = cboAssemblyNames.FindStringExact(strAssemblyName)
            Me.tclAbout.SelectedTab = Me.tpAssemblyDetails
        End If
    End Sub

    Private Sub cboAssemblyNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAssemblyNames.SelectedIndexChanged
        Dim strAssemblyName As String = Convert.ToString(cboAssemblyNames.SelectedItem)
        PopulateAssemblyDetails(MatchAssemblyByName(strAssemblyName), lvAssemblyDetails)
    End Sub

    Private Sub lvAssemblyInfo_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles lvAssemblyInfo.ColumnClick
        Dim intTargetCol As Integer = e.Column + 1

        If Not lvAssemblyInfo.Tag Is Nothing Then
            If Math.Abs(Convert.ToInt32(lvAssemblyInfo.Tag)) = intTargetCol Then
                intTargetCol = -Convert.ToInt32(lvAssemblyInfo.Tag)
            End If
        End If

        lvAssemblyInfo.Tag = intTargetCol
        lvAssemblyInfo.ListViewItemSorter = New ListViewItemComparer(intTargetCol)
    End Sub

#Region "  ListViewItemComparer Class"

    Class ListViewItemComparer
        Implements IComparer

        Private _intCol As Integer
        Private _IsAscending As Boolean = True

        Public Sub New()
            _intCol = 0
            _IsAscending = True
        End Sub

        Public Sub New(ByVal column As Integer, Optional ByVal ascending As Boolean = True)
            If column < 0 Then
                _IsAscending = False
            Else
                _IsAscending = ascending
            End If
            _intCol = Math.Abs(column) - 1
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim intResult As Integer = _
                [String].Compare(CType(x, ListViewItem).SubItems(_intCol).Text, _
                CType(y, ListViewItem).SubItems(_intCol).Text)

            If _IsAscending Then
                Return intResult
            Else
                Return -intResult
            End If
        End Function

    End Class

#End Region

    Private Sub tclAbout_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tclAbout.SelectedIndexChanged
        If tclAbout.SelectedTab Is Me.tpAssemblyDetails Then
            cboAssemblyNames.Focus()
        End If
    End Sub

    Private Sub rtfLicense_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtfLicense.DoubleClick, rtfLicense.GotFocus, rtfLicense.SelectionChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.RichTextBox_No_Selection(sender, Me.tpLicense)
    End Sub

    Private Sub rtfCredits_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles rtfCredits.DoubleClick, rtfCredits.GotFocus, rtfCredits.SelectionChanged
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If
        clsCommon.RichTextBox_No_Selection(sender, Me.tpCredits)
    End Sub

End Class