<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemParameterFinder
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
        Me.txtParameterName = New System.Windows.Forms.TextBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.txtTransactionCode = New System.Windows.Forms.TextBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.lblParameterName = New System.Windows.Forms.Label
        Me.lblParameterType = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.dgvHeader = New System.Windows.Forms.Label
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtParameterName
        '
        Me.txtParameterName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParameterName.Location = New System.Drawing.Point(110, 25)
        Me.txtParameterName.MaxLength = 45
        Me.txtParameterName.Name = "txtParameterName"
        Me.txtParameterName.Size = New System.Drawing.Size(200, 20)
        Me.txtParameterName.TabIndex = 1
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(115, 115)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "C&lear"
        '
        'txtTransactionCode
        '
        Me.txtTransactionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransactionCode.Location = New System.Drawing.Point(425, 25)
        Me.txtTransactionCode.MaxLength = 45
        Me.txtTransactionCode.Name = "txtTransactionCode"
        Me.txtTransactionCode.Size = New System.Drawing.Size(200, 20)
        Me.txtTransactionCode.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(10, 115)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "&Search"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtTransactionCode)
        Me.grpSearchCriteria.Controls.Add(Me.txtParameterName)
        Me.grpSearchCriteria.Controls.Add(Me.lblParameterName)
        Me.grpSearchCriteria.Controls.Add(Me.lblParameterType)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 7
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'lblParameterName
        '
        Me.lblParameterName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParameterName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblParameterName.Location = New System.Drawing.Point(15, 25)
        Me.lblParameterName.Name = "lblParameterName"
        Me.lblParameterName.Size = New System.Drawing.Size(95, 16)
        Me.lblParameterName.TabIndex = 0
        Me.lblParameterName.Text = "Parameter Name"
        '
        'lblParameterType
        '
        Me.lblParameterType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblParameterType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblParameterType.Location = New System.Drawing.Point(330, 25)
        Me.lblParameterType.Name = "lblParameterType"
        Me.lblParameterType.Size = New System.Drawing.Size(95, 16)
        Me.lblParameterType.TabIndex = 2
        Me.lblParameterType.Text = "Parameter Type"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(545, 115)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(440, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "&Add"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(335, 115)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 10
        Me.btnView.Text = "&View"
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 41
        '
        'dgvHeader
        '
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(10, 155)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(635, 20)
        Me.dgvHeader.TabIndex = 42
        '
        'frmSystemParameterFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 468)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnView)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(660, 500)
        Me.MinimumSize = New System.Drawing.Size(660, 500)
        Me.Name = "frmSystemParameterFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Parameter Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtParameterName As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtTransactionCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents lblParameterName As System.Windows.Forms.Label
    Friend WithEvents lblParameterType As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
End Class
