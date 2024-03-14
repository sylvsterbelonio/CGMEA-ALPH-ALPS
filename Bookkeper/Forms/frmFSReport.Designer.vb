<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFSReport
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
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.optMonth = New System.Windows.Forms.RadioButton
        Me.optQuarter = New System.Windows.Forms.RadioButton
        Me.optYear = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.txtYear = New System.Windows.Forms.NumericUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboGenerate = New System.Windows.Forms.Button
        CType(Me.txtYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboType
        '
        Me.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboType.FormattingEnabled = True
        Me.cboType.Items.AddRange(New Object() {"Financial Statement", "Collection", "Balance Monitoring Report/Transaction History", "List of Checks Issued", "List of Official Receipts Issued"})
        Me.cboType.Location = New System.Drawing.Point(107, 17)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(208, 21)
        Me.cboType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Print Type"
        '
        'optMonth
        '
        Me.optMonth.AutoSize = True
        Me.optMonth.Checked = True
        Me.optMonth.Location = New System.Drawing.Point(108, 51)
        Me.optMonth.Name = "optMonth"
        Me.optMonth.Size = New System.Drawing.Size(62, 17)
        Me.optMonth.TabIndex = 2
        Me.optMonth.TabStop = True
        Me.optMonth.Text = "Monthly"
        Me.optMonth.UseVisualStyleBackColor = True
        '
        'optQuarter
        '
        Me.optQuarter.AutoSize = True
        Me.optQuarter.Location = New System.Drawing.Point(176, 51)
        Me.optQuarter.Name = "optQuarter"
        Me.optQuarter.Size = New System.Drawing.Size(67, 17)
        Me.optQuarter.TabIndex = 3
        Me.optQuarter.Text = "Quarterly"
        Me.optQuarter.UseVisualStyleBackColor = True
        '
        'optYear
        '
        Me.optYear.AutoSize = True
        Me.optYear.Location = New System.Drawing.Point(249, 51)
        Me.optYear.Name = "optYear"
        Me.optYear.Size = New System.Drawing.Size(54, 17)
        Me.optYear.TabIndex = 4
        Me.optYear.Text = "Yearly"
        Me.optYear.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Print Style"
        '
        'cboMonth
        '
        Me.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(151, 81)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(57, 21)
        Me.cboMonth.TabIndex = 6
        '
        'txtYear
        '
        Me.txtYear.Location = New System.Drawing.Point(262, 82)
        Me.txtYear.Maximum = New Decimal(New Integer() {2100, 0, 0, 0})
        Me.txtYear.Minimum = New Decimal(New Integer() {1800, 0, 0, 0})
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(54, 20)
        Me.txtYear.TabIndex = 7
        Me.txtYear.Value = New Decimal(New Integer() {1800, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(105, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(226, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Year"
        '
        'cboGenerate
        '
        Me.cboGenerate.Location = New System.Drawing.Point(108, 121)
        Me.cboGenerate.Name = "cboGenerate"
        Me.cboGenerate.Size = New System.Drawing.Size(208, 33)
        Me.cboGenerate.TabIndex = 10
        Me.cboGenerate.Text = "Generate"
        Me.cboGenerate.UseVisualStyleBackColor = True
        '
        'frmFSReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 167)
        Me.Controls.Add(Me.cboGenerate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.optYear)
        Me.Controls.Add(Me.optQuarter)
        Me.Controls.Add(Me.optMonth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFSReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Financial Statement Report"
        CType(Me.txtYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents optMonth As System.Windows.Forms.RadioButton
    Friend WithEvents optQuarter As System.Windows.Forms.RadioButton
    Friend WithEvents optYear As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboGenerate As System.Windows.Forms.Button
End Class
