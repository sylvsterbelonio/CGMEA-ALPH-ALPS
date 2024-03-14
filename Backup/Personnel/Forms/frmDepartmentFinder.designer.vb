<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartmentFinder
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
        Me.txtDepartmentCode = New System.Windows.Forms.TextBox()
        Me.txtDepartmentName = New System.Windows.Forms.TextBox()
        Me.lblDepartmentName = New System.Windows.Forms.Label()
        Me.lblDepartmentCode = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.dgvFinder = New System.Windows.Forms.DataGridView()
        Me.dgvHeader = New System.Windows.Forms.Label()
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDepartmentCode
        '
        Me.txtDepartmentCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentCode.Location = New System.Drawing.Point(425, 25)
        Me.txtDepartmentCode.MaxLength = 45
        Me.txtDepartmentCode.Name = "txtDepartmentCode"
        Me.txtDepartmentCode.Size = New System.Drawing.Size(200, 20)
        Me.txtDepartmentCode.TabIndex = 1
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentName.Location = New System.Drawing.Point(110, 25)
        Me.txtDepartmentName.MaxLength = 45
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(200, 20)
        Me.txtDepartmentName.TabIndex = 0
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentName.Location = New System.Drawing.Point(15, 25)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(95, 16)
        Me.lblDepartmentName.TabIndex = 10
        Me.lblDepartmentName.Text = "Department Name"
        '
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentCode.Location = New System.Drawing.Point(330, 25)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(95, 16)
        Me.lblDepartmentCode.TabIndex = 11
        Me.lblDepartmentCode.Text = "Department Code"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(545, 115)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 51
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(440, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 50
        Me.btnAdd.Text = "&Add"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtDepartmentCode)
        Me.grpSearchCriteria.Controls.Add(Me.txtDepartmentName)
        Me.grpSearchCriteria.Controls.Add(Me.lblDepartmentName)
        Me.grpSearchCriteria.Controls.Add(Me.lblDepartmentCode)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 52
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(115, 115)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 48
        Me.btnClear.Text = "C&lear"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(10, 115)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 47
        Me.btnSearch.Text = "&Search"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(335, 115)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 49
        Me.btnView.Text = "&View"
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 53
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
        Me.dgvHeader.TabIndex = 54
        '
        'frmDepartmentFinder
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
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDepartmentFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Department Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDepartmentCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartmentName As System.Windows.Forms.Label
    Friend WithEvents lblDepartmentCode As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
End Class
