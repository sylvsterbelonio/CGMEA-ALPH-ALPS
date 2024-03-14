Module modApp

    Dim asm As System.Reflection.Assembly
    Dim titleAttr As System.Reflection.AssemblyTitleAttribute

    ' <Assembly: AssemblyDescription("My Assembly Description")>
    Dim descAttr As System.Reflection.AssemblyDescriptionAttribute

    ' <Assembly: AssemblyCompany("My Company")>
    Dim companyAttr As System.Reflection.AssemblyCompanyAttribute

    ' <Assembly: AssemblyProduct("My Product Name")>
    Dim productAttr As System.Reflection.AssemblyProductAttribute

    ' <Assembly: AssemblyCopyright("My Copyright")>
    Dim copyrtAttr As System.Reflection.AssemblyCopyrightAttribute

    ' <Assembly: AssemblyTrademark("My Trademark")>
    Dim trademkAttr As System.Reflection.AssemblyTrademarkAttribute

    ' <Assembly: AssemblyTrademark("My Informational Version")>
    Dim infoverAttr As System.Reflection.AssemblyInformationalVersionAttribute

    ' <Assembly: AssemblyAlias("Default Alias")>
    Dim infoaliasAttr As System.Reflection.AssemblyDefaultAliasAttribute

    Friend ReadOnly Property Path() As String
        Get
            Dim tStr As String = System.Windows.Forms.Application.ExecutablePath
            Return Left(tStr, tStr.LastIndexOf("\"))
        End Get
    End Property

    Friend ReadOnly Property Major() As Integer
        Get
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly.Location).FileMajorPart
        End Get
    End Property

    Friend ReadOnly Property Minor() As Integer
        Get
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly.Location).FileMinorPart
        End Get
    End Property

    Friend ReadOnly Property Revision() As Integer
        Get
            Return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly.Location).FileBuildPart
        End Get
    End Property

    Friend ReadOnly Property AssemblyVersion() As String
        Get
            With System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly.Location)
                Return .FileMajorPart & "." & .FileMinorPart & "." & .FileBuildPart
            End With
        End Get
    End Property

    Friend ReadOnly Property AssemblyTitle() As String
        Get
            ' Get the current executing Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            ' Get the Title Attribute
            titleAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyTitleAttribute), False)(0)
            Return titleAttr.Title
        End Get
    End Property

    Friend ReadOnly Property AssemblyProduct() As String
        Get
            ' Get the current executing Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            'Get the Product Attribute
            productAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyProductAttribute), False)(0)
            Return productAttr.Product
        End Get
    End Property

    Friend ReadOnly Property AssemblyCompany() As String
        Get
            ' Get the current executing Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            'Get the Company Attribute 
            companyAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyCompanyAttribute), False)(0)
            Return companyAttr.Company
        End Get
    End Property

    Friend ReadOnly Property AssemblyTrademark() As String
        Get
            ' Get the current executing Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            'Get the Company Attribute 
            trademkAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyTrademarkAttribute), False)(0)
            Return trademkAttr.Trademark
        End Get
    End Property

    Friend ReadOnly Property AssemblyInformationalVersion() As String
        Get
            ' Get the current executing Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            ' Get the Company Attribute 
            Try
                infoverAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyInformationalVersionAttribute), False)(0)
                Return infoverAttr.InformationalVersion
            Catch ex As Exception
                Return Nothing
            End Try

        End Get
    End Property

    Friend ReadOnly Property AssemblyDefaultAlias() As String
        Get
            ' Get the current executing Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            ' Get the Company Attribute 
            infoaliasAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyDefaultAliasAttribute), False)(0)
            Return infoaliasAttr.DefaultAlias
        End Get
    End Property

    Friend ReadOnly Property AssemblyCopyright() As String
        Get
            ' Get the current exec1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111                              3.uting Assembly
            asm = System.Reflection.Assembly.GetEntryAssembly
            copyrtAttr = asm.GetCustomAttributes(GetType(System.Reflection.AssemblyCopyrightAttribute), False)(0)
            Return copyrtAttr.Copyright
        End Get
    End Property

End Module
