<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCountryFinder
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
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox()
        Me.txtSovereign = New System.Windows.Forms.TextBox()
        Me.txtCountryName = New System.Windows.Forms.TextBox()
        Me.lblCountryName = New System.Windows.Forms.Label()
        Me.lblSovereign = New System.Windows.Forms.Label()
        Me.txtGMI = New System.Windows.Forms.TextBox()
        Me.txtFIPS = New System.Windows.Forms.TextBox()
        Me.lblFIPS = New System.Windows.Forms.Label()
        Me.lblGMI = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.dgvFinder = New System.Windows.Forms.DataGridView()
        Me.dgvHeader = New System.Windows.Forms.Label()
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(545, 115)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(440, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "&Add"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtSovereign)
        Me.grpSearchCriteria.Controls.Add(Me.txtCountryName)
        Me.grpSearchCriteria.Controls.Add(Me.lblCountryName)
        Me.grpSearchCriteria.Controls.Add(Me.lblSovereign)
        Me.grpSearchCriteria.Controls.Add(Me.txtGMI)
        Me.grpSearchCriteria.Controls.Add(Me.txtFIPS)
        Me.grpSearchCriteria.Controls.Add(Me.lblFIPS)
        Me.grpSearchCriteria.Controls.Add(Me.lblGMI)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 0
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'txtSovereign
        '
        Me.txtSovereign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSovereign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSovereign.Location = New System.Drawing.Point(420, 55)
        Me.txtSovereign.MaxLength = 20
        Me.txtSovereign.Name = "txtSovereign"
        Me.txtSovereign.Size = New System.Drawing.Size(200, 20)
        Me.txtSovereign.TabIndex = 7
        '
        'txtCountryName
        '
        Me.txtCountryName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountryName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCountryName.Location = New System.Drawing.Point(100, 55)
        Me.txtCountryName.MaxLength = 20
        Me.txtCountryName.Name = "txtCountryName"
        Me.txtCountryName.Size = New System.Drawing.Size(200, 20)
        Me.txtCountryName.TabIndex = 5
        '
        'lblCountryName
        '
        Me.lblCountryName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountryName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCountryName.Location = New System.Drawing.Point(15, 55)
        Me.lblCountryName.Name = "lblCountryName"
        Me.lblCountryName.Size = New System.Drawing.Size(80, 16)
        Me.lblCountryName.TabIndex = 4
        Me.lblCountryName.Text = "Country Name"
        '
        'lblSovereign
        '
        Me.lblSovereign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSovereign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSovereign.Location = New System.Drawing.Point(335, 55)
        Me.lblSovereign.Name = "lblSovereign"
        Me.lblSovereign.Size = New System.Drawing.Size(80, 16)
        Me.lblSovereign.TabIndex = 6
        Me.lblSovereign.Text = "Sovereign"
        '
        'txtGMI
        '
        Me.txtGMI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGMI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtGMI.Location = New System.Drawing.Point(420, 25)
        Me.txtGMI.MaxLength = 3
        Me.txtGMI.Name = "txtGMI"
        Me.txtGMI.Size = New System.Drawing.Size(200, 20)
        Me.txtGMI.TabIndex = 3
        '
        'txtFIPS
        '
        Me.txtFIPS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFIPS.Location = New System.Drawing.Point(100, 25)
        Me.txtFIPS.MaxLength = 2
        Me.txtFIPS.Name = "txtFIPS"
        Me.txtFIPS.Size = New System.Drawing.Size(200, 20)
        Me.txtFIPS.TabIndex = 1
        '
        'lblFIPS
        '
        Me.lblFIPS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFIPS.Location = New System.Drawing.Point(15, 25)
        Me.lblFIPS.Name = "lblFIPS"
        Me.lblFIPS.Size = New System.Drawing.Size(80, 16)
        Me.lblFIPS.TabIndex = 0
        Me.lblFIPS.Tag = "Federal Information Processing Standards"
        Me.lblFIPS.Text = "FIPS"
        '
        'lblGMI
        '
        Me.lblGMI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGMI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGMI.Location = New System.Drawing.Point(335, 25)
        Me.lblGMI.Name = "lblGMI"
        Me.lblGMI.Size = New System.Drawing.Size(80, 16)
        Me.lblGMI.TabIndex = 2
        Me.lblGMI.Text = "GMI"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(115, 115)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "C&lear"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(10, 115)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "&Search"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(335, 115)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 3
        Me.btnView.Text = "&View"
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 6
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
        Me.dgvHeader.TabIndex = 44
        '
        'frmCountryFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 472)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnView)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(660, 500)
        Me.MinimumSize = New System.Drawing.Size(660, 500)
        Me.Name = "frmCountryFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Country Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents txtCountryName As System.Windows.Forms.TextBox
    Friend WithEvents lblCountryName As System.Windows.Forms.Label
    Friend WithEvents lblSovereign As System.Windows.Forms.Label
    Friend WithEvents txtGMI As System.Windows.Forms.TextBox
    Friend WithEvents txtFIPS As System.Windows.Forms.TextBox
    Friend WithEvents lblFIPS As System.Windows.Forms.Label
    Friend WithEvents lblGMI As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents txtSovereign As System.Windows.Forms.TextBox
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
End Class
