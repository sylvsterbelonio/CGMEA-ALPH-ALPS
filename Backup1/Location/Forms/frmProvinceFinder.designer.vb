<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProvinceFinder
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
        Me.lblProvinceCode = New System.Windows.Forms.Label()
        Me.lblProvinceFl = New System.Windows.Forms.Label()
        Me.txtProvinceName = New System.Windows.Forms.TextBox()
        Me.txtProvinceCode = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtRegionName = New System.Windows.Forms.TextBox()
        Me.lblRegionName = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox()
        Me.chkProvinceFl = New System.Windows.Forms.CheckBox()
        Me.lblProvinceName = New System.Windows.Forms.Label()
        Me.dgvFinder = New System.Windows.Forms.DataGridView()
        Me.dgvHeader = New System.Windows.Forms.Label()
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProvinceCode
        '
        Me.lblProvinceCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceCode.Location = New System.Drawing.Point(15, 55)
        Me.lblProvinceCode.Name = "lblProvinceCode"
        Me.lblProvinceCode.Size = New System.Drawing.Size(80, 16)
        Me.lblProvinceCode.TabIndex = 14
        Me.lblProvinceCode.Text = "Province Code"
        '
        'lblProvinceFl
        '
        Me.lblProvinceFl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceFl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceFl.Location = New System.Drawing.Point(335, 55)
        Me.lblProvinceFl.Name = "lblProvinceFl"
        Me.lblProvinceFl.Size = New System.Drawing.Size(80, 16)
        Me.lblProvinceFl.TabIndex = 15
        Me.lblProvinceFl.Text = "Province Flag"
        '
        'txtProvinceName
        '
        Me.txtProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProvinceName.Location = New System.Drawing.Point(420, 25)
        Me.txtProvinceName.MaxLength = 20
        Me.txtProvinceName.Name = "txtProvinceName"
        Me.txtProvinceName.Size = New System.Drawing.Size(200, 20)
        Me.txtProvinceName.TabIndex = 1
        '
        'txtProvinceCode
        '
        Me.txtProvinceCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinceCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProvinceCode.Location = New System.Drawing.Point(100, 55)
        Me.txtProvinceCode.MaxLength = 4
        Me.txtProvinceCode.Name = "txtProvinceCode"
        Me.txtProvinceCode.Size = New System.Drawing.Size(200, 20)
        Me.txtProvinceCode.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(10, 115)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 33
        Me.btnSearch.Text = "&Search"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(335, 115)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 35
        Me.btnView.Text = "&View"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(115, 115)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 34
        Me.btnClear.Text = "C&lear"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(545, 115)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 37
        Me.btnEdit.Text = "&Edit"
        '
        'txtRegionName
        '
        Me.txtRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRegionName.Location = New System.Drawing.Point(100, 25)
        Me.txtRegionName.MaxLength = 20
        Me.txtRegionName.Name = "txtRegionName"
        Me.txtRegionName.Size = New System.Drawing.Size(200, 20)
        Me.txtRegionName.TabIndex = 0
        '
        'lblRegionName
        '
        Me.lblRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegionName.Location = New System.Drawing.Point(15, 25)
        Me.lblRegionName.Name = "lblRegionName"
        Me.lblRegionName.Size = New System.Drawing.Size(80, 16)
        Me.lblRegionName.TabIndex = 10
        Me.lblRegionName.Text = "Region Name"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(440, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 36
        Me.btnAdd.Text = "&Add"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.chkProvinceFl)
        Me.grpSearchCriteria.Controls.Add(Me.txtProvinceCode)
        Me.grpSearchCriteria.Controls.Add(Me.lblProvinceCode)
        Me.grpSearchCriteria.Controls.Add(Me.lblProvinceFl)
        Me.grpSearchCriteria.Controls.Add(Me.txtProvinceName)
        Me.grpSearchCriteria.Controls.Add(Me.txtRegionName)
        Me.grpSearchCriteria.Controls.Add(Me.lblRegionName)
        Me.grpSearchCriteria.Controls.Add(Me.lblProvinceName)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 38
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'chkProvinceFl
        '
        Me.chkProvinceFl.AutoSize = True
        Me.chkProvinceFl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkProvinceFl.Location = New System.Drawing.Point(420, 55)
        Me.chkProvinceFl.Name = "chkProvinceFl"
        Me.chkProvinceFl.Size = New System.Drawing.Size(15, 14)
        Me.chkProvinceFl.TabIndex = 3
        Me.chkProvinceFl.Tag = "1"
        Me.chkProvinceFl.UseVisualStyleBackColor = True
        '
        'lblProvinceName
        '
        Me.lblProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceName.Location = New System.Drawing.Point(335, 25)
        Me.lblProvinceName.Name = "lblProvinceName"
        Me.lblProvinceName.Size = New System.Drawing.Size(80, 16)
        Me.lblProvinceName.TabIndex = 11
        Me.lblProvinceName.Text = "Province Name"
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 39
        '
        'dgvHeader
        '
        Me.dgvHeader.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(10, 155)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(635, 20)
        Me.dgvHeader.TabIndex = 43
        '
        'frmProvinceFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 472)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(660, 500)
        Me.MinimumSize = New System.Drawing.Size(660, 500)
        Me.Name = "frmProvinceFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Province Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblProvinceCode As System.Windows.Forms.Label
    Friend WithEvents lblProvinceFl As System.Windows.Forms.Label
    Friend WithEvents txtProvinceName As System.Windows.Forms.TextBox
    Friend WithEvents txtProvinceCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtRegionName As System.Windows.Forms.TextBox
    Friend WithEvents lblRegionName As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents lblProvinceName As System.Windows.Forms.Label
    Friend WithEvents chkProvinceFl As System.Windows.Forms.CheckBox
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
End Class
