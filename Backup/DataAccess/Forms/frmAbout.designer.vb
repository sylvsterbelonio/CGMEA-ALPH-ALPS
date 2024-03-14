<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.btnOk = New System.Windows.Forms.Button
        Me.lblWarning = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.rtfLicense = New System.Windows.Forms.RichTextBox
        Me.llblURL = New System.Windows.Forms.LinkLabel
        Me.lblURL = New System.Windows.Forms.Label
        Me.lblBuildDate = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblDeveloper = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.pbLogo = New System.Windows.Forms.PictureBox
        Me.btnSystemInfo = New System.Windows.Forms.Button
        Me.tclAbout = New System.Windows.Forms.TabControl
        Me.tpLicense = New System.Windows.Forms.TabPage
        Me.tpApplication = New System.Windows.Forms.TabPage
        Me.lvAppInfo = New System.Windows.Forms.ListView
        Me.colKey = New System.Windows.Forms.ColumnHeader
        Me.colValue = New System.Windows.Forms.ColumnHeader
        Me.tpAssemblies = New System.Windows.Forms.TabPage
        Me.lvAssemblyInfo = New System.Windows.Forms.ListView
        Me.colAssemblyName = New System.Windows.Forms.ColumnHeader
        Me.colAssemblyVersion = New System.Windows.Forms.ColumnHeader
        Me.colAssemblyBuilt = New System.Windows.Forms.ColumnHeader
        Me.colAssemblyCodeBase = New System.Windows.Forms.ColumnHeader
        Me.tpAssemblyDetails = New System.Windows.Forms.TabPage
        Me.lvAssemblyDetails = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.cboAssemblyNames = New System.Windows.Forms.ComboBox
        Me.tpCredits = New System.Windows.Forms.TabPage
        Me.rtfCredits = New System.Windows.Forms.RichTextBox
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tclAbout.SuspendLayout()
        Me.tpLicense.SuspendLayout()
        Me.tpApplication.SuspendLayout()
        Me.tpAssemblies.SuspendLayout()
        Me.tpAssemblyDetails.SuspendLayout()
        Me.tpCredits.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnOk.Location = New System.Drawing.Point(380, 395)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(100, 30)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Close"
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblWarning.Location = New System.Drawing.Point(15, 330)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(461, 62)
        Me.lblWarning.TabIndex = 38
        Me.lblWarning.Text = resources.GetString("lblWarning.Text")
        '
        'lblCopyright
        '
        Me.lblCopyright.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCopyright.Location = New System.Drawing.Point(15, 300)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(468, 16)
        Me.lblCopyright.TabIndex = 37
        '
        'rtfLicense
        '
        Me.rtfLicense.BackColor = System.Drawing.SystemColors.Window
        Me.rtfLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfLicense.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfLicense.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rtfLicense.Location = New System.Drawing.Point(3, 3)
        Me.rtfLicense.Name = "rtfLicense"
        Me.rtfLicense.ReadOnly = True
        Me.rtfLicense.Size = New System.Drawing.Size(451, 147)
        Me.rtfLicense.TabIndex = 0
        Me.rtfLicense.TabStop = False
        Me.rtfLicense.Text = ""
        '
        'llblURL
        '
        Me.llblURL.AutoSize = True
        Me.llblURL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.llblURL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.llblURL.Location = New System.Drawing.Point(340, 60)
        Me.llblURL.Name = "llblURL"
        Me.llblURL.Size = New System.Drawing.Size(0, 14)
        Me.llblURL.TabIndex = 35
        '
        'lblURL
        '
        Me.lblURL.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblURL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblURL.Location = New System.Drawing.Point(300, 60)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(33, 15)
        Me.lblURL.TabIndex = 34
        Me.lblURL.Text = "URL : "
        '
        'lblBuildDate
        '
        Me.lblBuildDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBuildDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBuildDate.Location = New System.Drawing.Point(300, 30)
        Me.lblBuildDate.Name = "lblBuildDate"
        Me.lblBuildDate.Size = New System.Drawing.Size(190, 16)
        Me.lblBuildDate.TabIndex = 33
        Me.lblBuildDate.Text = "Build Date :  "
        '
        'lblVersion
        '
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersion.Location = New System.Drawing.Point(300, 15)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(190, 16)
        Me.lblVersion.TabIndex = 32
        Me.lblVersion.Text = "Version :  "
        '
        'lblDeveloper
        '
        Me.lblDeveloper.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDeveloper.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDeveloper.Location = New System.Drawing.Point(300, 45)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(190, 16)
        Me.lblDeveloper.TabIndex = 31
        Me.lblDeveloper.Text = "Developer :  "
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("High Tower Text", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblName.Location = New System.Drawing.Point(100, 5)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(194, 97)
        Me.lblName.TabIndex = 30
        Me.lblName.Text = "Integrated Revenue Generation System"
        '
        'pbLogo
        '
        Me.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbLogo.Location = New System.Drawing.Point(10, 5)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(90, 90)
        Me.pbLogo.TabIndex = 41
        Me.pbLogo.TabStop = False
        '
        'btnSystemInfo
        '
        Me.btnSystemInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSystemInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSystemInfo.Location = New System.Drawing.Point(270, 395)
        Me.btnSystemInfo.Name = "btnSystemInfo"
        Me.btnSystemInfo.Size = New System.Drawing.Size(100, 30)
        Me.btnSystemInfo.TabIndex = 1
        Me.btnSystemInfo.Text = "&System Info..."
        '
        'tclAbout
        '
        Me.tclAbout.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tclAbout.Controls.Add(Me.tpLicense)
        Me.tclAbout.Controls.Add(Me.tpApplication)
        Me.tclAbout.Controls.Add(Me.tpAssemblies)
        Me.tclAbout.Controls.Add(Me.tpAssemblyDetails)
        Me.tclAbout.Controls.Add(Me.tpCredits)
        Me.tclAbout.HotTrack = True
        Me.tclAbout.Location = New System.Drawing.Point(15, 105)
        Me.tclAbout.Margin = New System.Windows.Forms.Padding(5)
        Me.tclAbout.Name = "tclAbout"
        Me.tclAbout.SelectedIndex = 0
        Me.tclAbout.Size = New System.Drawing.Size(465, 180)
        Me.tclAbout.TabIndex = 0
        '
        'tpLicense
        '
        Me.tpLicense.Controls.Add(Me.rtfLicense)
        Me.tpLicense.Location = New System.Drawing.Point(4, 23)
        Me.tpLicense.Name = "tpLicense"
        Me.tpLicense.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLicense.Size = New System.Drawing.Size(457, 153)
        Me.tpLicense.TabIndex = 3
        Me.tpLicense.Text = "License"
        Me.tpLicense.UseVisualStyleBackColor = True
        '
        'tpApplication
        '
        Me.tpApplication.Controls.Add(Me.lvAppInfo)
        Me.tpApplication.Location = New System.Drawing.Point(4, 23)
        Me.tpApplication.Name = "tpApplication"
        Me.tpApplication.Size = New System.Drawing.Size(457, 153)
        Me.tpApplication.TabIndex = 0
        Me.tpApplication.Text = "Application"
        Me.tpApplication.UseVisualStyleBackColor = True
        '
        'lvAppInfo
        '
        Me.lvAppInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colKey, Me.colValue})
        Me.lvAppInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvAppInfo.FullRowSelect = True
        Me.lvAppInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvAppInfo.Location = New System.Drawing.Point(0, 0)
        Me.lvAppInfo.Name = "lvAppInfo"
        Me.lvAppInfo.Size = New System.Drawing.Size(457, 153)
        Me.lvAppInfo.TabIndex = 16
        Me.lvAppInfo.UseCompatibleStateImageBehavior = False
        Me.lvAppInfo.View = System.Windows.Forms.View.Details
        '
        'colKey
        '
        Me.colKey.Text = "Application Key"
        Me.colKey.Width = 120
        '
        'colValue
        '
        Me.colValue.Text = "Value"
        Me.colValue.Width = 700
        '
        'tpAssemblies
        '
        Me.tpAssemblies.Controls.Add(Me.lvAssemblyInfo)
        Me.tpAssemblies.Location = New System.Drawing.Point(4, 23)
        Me.tpAssemblies.Name = "tpAssemblies"
        Me.tpAssemblies.Size = New System.Drawing.Size(457, 153)
        Me.tpAssemblies.TabIndex = 1
        Me.tpAssemblies.Text = "Assemblies"
        Me.tpAssemblies.UseVisualStyleBackColor = True
        '
        'lvAssemblyInfo
        '
        Me.lvAssemblyInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colAssemblyName, Me.colAssemblyVersion, Me.colAssemblyBuilt, Me.colAssemblyCodeBase})
        Me.lvAssemblyInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvAssemblyInfo.FullRowSelect = True
        Me.lvAssemblyInfo.Location = New System.Drawing.Point(0, 0)
        Me.lvAssemblyInfo.MultiSelect = False
        Me.lvAssemblyInfo.Name = "lvAssemblyInfo"
        Me.lvAssemblyInfo.Size = New System.Drawing.Size(457, 153)
        Me.lvAssemblyInfo.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvAssemblyInfo.TabIndex = 13
        Me.lvAssemblyInfo.UseCompatibleStateImageBehavior = False
        Me.lvAssemblyInfo.View = System.Windows.Forms.View.Details
        '
        'colAssemblyName
        '
        Me.colAssemblyName.Text = "Assembly"
        Me.colAssemblyName.Width = 123
        '
        'colAssemblyVersion
        '
        Me.colAssemblyVersion.Text = "Version"
        Me.colAssemblyVersion.Width = 100
        '
        'colAssemblyBuilt
        '
        Me.colAssemblyBuilt.Text = "Built"
        Me.colAssemblyBuilt.Width = 130
        '
        'colAssemblyCodeBase
        '
        Me.colAssemblyCodeBase.Text = "CodeBase"
        Me.colAssemblyCodeBase.Width = 750
        '
        'tpAssemblyDetails
        '
        Me.tpAssemblyDetails.Controls.Add(Me.lvAssemblyDetails)
        Me.tpAssemblyDetails.Controls.Add(Me.cboAssemblyNames)
        Me.tpAssemblyDetails.Location = New System.Drawing.Point(4, 23)
        Me.tpAssemblyDetails.Name = "tpAssemblyDetails"
        Me.tpAssemblyDetails.Size = New System.Drawing.Size(457, 153)
        Me.tpAssemblyDetails.TabIndex = 2
        Me.tpAssemblyDetails.Text = "Assembly Details"
        Me.tpAssemblyDetails.UseVisualStyleBackColor = True
        '
        'lvAssemblyDetails
        '
        Me.lvAssemblyDetails.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvAssemblyDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvAssemblyDetails.FullRowSelect = True
        Me.lvAssemblyDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvAssemblyDetails.Location = New System.Drawing.Point(0, 22)
        Me.lvAssemblyDetails.Name = "lvAssemblyDetails"
        Me.lvAssemblyDetails.Size = New System.Drawing.Size(457, 131)
        Me.lvAssemblyDetails.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvAssemblyDetails.TabIndex = 19
        Me.lvAssemblyDetails.UseCompatibleStateImageBehavior = False
        Me.lvAssemblyDetails.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Assembly Key"
        Me.ColumnHeader1.Width = 120
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.Width = 700
        '
        'cboAssemblyNames
        '
        Me.cboAssemblyNames.Dock = System.Windows.Forms.DockStyle.Top
        Me.cboAssemblyNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssemblyNames.Location = New System.Drawing.Point(0, 0)
        Me.cboAssemblyNames.Name = "cboAssemblyNames"
        Me.cboAssemblyNames.Size = New System.Drawing.Size(457, 22)
        Me.cboAssemblyNames.Sorted = True
        Me.cboAssemblyNames.TabIndex = 18
        '
        'tpCredits
        '
        Me.tpCredits.Controls.Add(Me.rtfCredits)
        Me.tpCredits.Location = New System.Drawing.Point(4, 23)
        Me.tpCredits.Name = "tpCredits"
        Me.tpCredits.Padding = New System.Windows.Forms.Padding(3)
        Me.tpCredits.Size = New System.Drawing.Size(457, 153)
        Me.tpCredits.TabIndex = 4
        Me.tpCredits.Text = "Credits"
        Me.tpCredits.UseVisualStyleBackColor = True
        '
        'rtfCredits
        '
        Me.rtfCredits.BackColor = System.Drawing.SystemColors.Window
        Me.rtfCredits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtfCredits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtfCredits.ForeColor = System.Drawing.SystemColors.WindowText
        Me.rtfCredits.Location = New System.Drawing.Point(3, 3)
        Me.rtfCredits.Margin = New System.Windows.Forms.Padding(5)
        Me.rtfCredits.Name = "rtfCredits"
        Me.rtfCredits.ReadOnly = True
        Me.rtfCredits.Size = New System.Drawing.Size(451, 147)
        Me.rtfCredits.TabIndex = 1
        Me.rtfCredits.TabStop = False
        Me.rtfCredits.Text = ""
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 450)
        Me.Controls.Add(Me.tclAbout)
        Me.Controls.Add(Me.btnSystemInfo)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.llblURL)
        Me.Controls.Add(Me.lblURL)
        Me.Controls.Add(Me.lblBuildDate)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblDeveloper)
        Me.Controls.Add(Me.lblName)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tclAbout.ResumeLayout(False)
        Me.tpLicense.ResumeLayout(False)
        Me.tpApplication.ResumeLayout(False)
        Me.tpAssemblies.ResumeLayout(False)
        Me.tpAssemblyDetails.ResumeLayout(False)
        Me.tpCredits.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents rtfLicense As System.Windows.Forms.RichTextBox
    Friend WithEvents llblURL As System.Windows.Forms.LinkLabel
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents lblBuildDate As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblDeveloper As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents btnSystemInfo As System.Windows.Forms.Button
    Friend WithEvents tclAbout As System.Windows.Forms.TabControl
    Friend WithEvents tpApplication As System.Windows.Forms.TabPage
    Friend WithEvents lvAppInfo As System.Windows.Forms.ListView
    Friend WithEvents colKey As System.Windows.Forms.ColumnHeader
    Friend WithEvents colValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpAssemblies As System.Windows.Forms.TabPage
    Friend WithEvents lvAssemblyInfo As System.Windows.Forms.ListView
    Friend WithEvents colAssemblyName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssemblyVersion As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssemblyBuilt As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssemblyCodeBase As System.Windows.Forms.ColumnHeader
    Friend WithEvents tpAssemblyDetails As System.Windows.Forms.TabPage
    Friend WithEvents lvAssemblyDetails As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboAssemblyNames As System.Windows.Forms.ComboBox
    Friend WithEvents tpLicense As System.Windows.Forms.TabPage
    Friend WithEvents tpCredits As System.Windows.Forms.TabPage
    Friend WithEvents rtfCredits As System.Windows.Forms.RichTextBox
End Class
