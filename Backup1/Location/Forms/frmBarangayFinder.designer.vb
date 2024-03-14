<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarangayFinder
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
        Me.lblBarangayName = New System.Windows.Forms.Label()
        Me.lblBarangayCode = New System.Windows.Forms.Label()
        Me.txtMunicipalityName = New System.Windows.Forms.TextBox()
        Me.txtBarangayName = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.txtProvinceName = New System.Windows.Forms.TextBox()
        Me.lblProvinceName = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox()
        Me.txtBarangayCode = New System.Windows.Forms.TextBox()
        Me.lblMunicipalityName = New System.Windows.Forms.Label()
        Me.dgvFinder = New System.Windows.Forms.DataGridView()
        Me.dgvHeader = New System.Windows.Forms.Label()
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBarangayName
        '
        Me.lblBarangayName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarangayName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangayName.Location = New System.Drawing.Point(15, 55)
        Me.lblBarangayName.Name = "lblBarangayName"
        Me.lblBarangayName.Size = New System.Drawing.Size(90, 16)
        Me.lblBarangayName.TabIndex = 14
        Me.lblBarangayName.Text = "Barangay Name"
        '
        'lblBarangayCode
        '
        Me.lblBarangayCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarangayCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangayCode.Location = New System.Drawing.Point(325, 55)
        Me.lblBarangayCode.Name = "lblBarangayCode"
        Me.lblBarangayCode.Size = New System.Drawing.Size(90, 16)
        Me.lblBarangayCode.TabIndex = 15
        Me.lblBarangayCode.Text = "Barangay Code"
        '
        'txtMunicipalityName
        '
        Me.txtMunicipalityName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipalityName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMunicipalityName.Location = New System.Drawing.Point(420, 25)
        Me.txtMunicipalityName.MaxLength = 20
        Me.txtMunicipalityName.Name = "txtMunicipalityName"
        Me.txtMunicipalityName.Size = New System.Drawing.Size(200, 20)
        Me.txtMunicipalityName.TabIndex = 1
        '
        'txtBarangayName
        '
        Me.txtBarangayName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBarangayName.Location = New System.Drawing.Point(105, 55)
        Me.txtBarangayName.MaxLength = 20
        Me.txtBarangayName.Name = "txtBarangayName"
        Me.txtBarangayName.Size = New System.Drawing.Size(200, 20)
        Me.txtBarangayName.TabIndex = 2
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
        'txtProvinceName
        '
        Me.txtProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProvinceName.Location = New System.Drawing.Point(105, 25)
        Me.txtProvinceName.MaxLength = 20
        Me.txtProvinceName.Name = "txtProvinceName"
        Me.txtProvinceName.Size = New System.Drawing.Size(200, 20)
        Me.txtProvinceName.TabIndex = 0
        '
        'lblProvinceName
        '
        Me.lblProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceName.Location = New System.Drawing.Point(15, 25)
        Me.lblProvinceName.Name = "lblProvinceName"
        Me.lblProvinceName.Size = New System.Drawing.Size(90, 16)
        Me.lblProvinceName.TabIndex = 10
        Me.lblProvinceName.Text = "Province Name"
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
        Me.grpSearchCriteria.Controls.Add(Me.txtBarangayCode)
        Me.grpSearchCriteria.Controls.Add(Me.txtBarangayName)
        Me.grpSearchCriteria.Controls.Add(Me.lblBarangayName)
        Me.grpSearchCriteria.Controls.Add(Me.lblBarangayCode)
        Me.grpSearchCriteria.Controls.Add(Me.txtMunicipalityName)
        Me.grpSearchCriteria.Controls.Add(Me.txtProvinceName)
        Me.grpSearchCriteria.Controls.Add(Me.lblProvinceName)
        Me.grpSearchCriteria.Controls.Add(Me.lblMunicipalityName)
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
        'txtBarangayCode
        '
        Me.txtBarangayCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBarangayCode.Location = New System.Drawing.Point(420, 55)
        Me.txtBarangayCode.MaxLength = 9
        Me.txtBarangayCode.Name = "txtBarangayCode"
        Me.txtBarangayCode.Size = New System.Drawing.Size(200, 20)
        Me.txtBarangayCode.TabIndex = 3
        '
        'lblMunicipalityName
        '
        Me.lblMunicipalityName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipalityName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipalityName.Location = New System.Drawing.Point(325, 25)
        Me.lblMunicipalityName.Name = "lblMunicipalityName"
        Me.lblMunicipalityName.Size = New System.Drawing.Size(95, 16)
        Me.lblMunicipalityName.TabIndex = 11
        Me.lblMunicipalityName.Text = "Municipality Name"
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
        'frmBarangayFinder
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
        Me.Name = "frmBarangayFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barangay Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBarangayName As System.Windows.Forms.Label
    Friend WithEvents lblBarangayCode As System.Windows.Forms.Label
    Friend WithEvents txtMunicipalityName As System.Windows.Forms.TextBox
    Friend WithEvents txtBarangayName As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents txtProvinceName As System.Windows.Forms.TextBox
    Friend WithEvents lblProvinceName As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents lblMunicipalityName As System.Windows.Forms.Label
    Friend WithEvents txtBarangayCode As System.Windows.Forms.TextBox
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
End Class
