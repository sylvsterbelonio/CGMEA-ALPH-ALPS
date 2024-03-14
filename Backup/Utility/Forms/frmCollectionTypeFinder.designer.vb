<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionTypeFinder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvHeader = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.txtCollectionCode = New System.Windows.Forms.TextBox
        Me.txtCollectionName = New System.Windows.Forms.TextBox
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.lblCollectionName = New System.Windows.Forms.Label
        Me.lblCollectionCode = New System.Windows.Forms.Label
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHeader
        '
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(10, 155)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(635, 20)
        Me.dgvHeader.TabIndex = 6
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
        'txtCollectionCode
        '
        Me.txtCollectionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionCode.Location = New System.Drawing.Point(115, 52)
        Me.txtCollectionCode.MaxLength = 45
        Me.txtCollectionCode.Name = "txtCollectionCode"
        Me.txtCollectionCode.Size = New System.Drawing.Size(200, 20)
        Me.txtCollectionCode.TabIndex = 3
        '
        'txtCollectionName
        '
        Me.txtCollectionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionName.Location = New System.Drawing.Point(115, 26)
        Me.txtCollectionName.MaxLength = 45
        Me.txtCollectionName.Name = "txtCollectionName"
        Me.txtCollectionName.Size = New System.Drawing.Size(200, 20)
        Me.txtCollectionName.TabIndex = 1
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 7
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
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtCollectionCode)
        Me.grpSearchCriteria.Controls.Add(Me.txtCollectionName)
        Me.grpSearchCriteria.Controls.Add(Me.lblCollectionName)
        Me.grpSearchCriteria.Controls.Add(Me.lblCollectionCode)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 0
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'lblCollectionName
        '
        Me.lblCollectionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCollectionName.Location = New System.Drawing.Point(15, 26)
        Me.lblCollectionName.Name = "lblCollectionName"
        Me.lblCollectionName.Size = New System.Drawing.Size(95, 16)
        Me.lblCollectionName.TabIndex = 0
        Me.lblCollectionName.Text = "Collection Name"
        '
        'lblCollectionCode
        '
        Me.lblCollectionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectionCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCollectionCode.Location = New System.Drawing.Point(15, 55)
        Me.lblCollectionCode.Name = "lblCollectionCode"
        Me.lblCollectionCode.Size = New System.Drawing.Size(90, 16)
        Me.lblCollectionCode.TabIndex = 2
        Me.lblCollectionCode.Text = "Collection Code"
        '
        'frmCollectionTypeFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 472)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCollectionTypeFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection Type Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtCollectionCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCollectionName As System.Windows.Forms.TextBox
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents lblCollectionName As System.Windows.Forms.Label
    Friend WithEvents lblCollectionCode As System.Windows.Forms.Label
End Class
