<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentLoanAndContributionFinder
    Inherits System.Windows.Forms.Form

    Public Sub New(ByVal strTag As String)
        MyBase.New()

        Me.strFormLoanTag = strTag
        Me.strFormTitle = IIf(Len(strTag) > 0, strTag & " Payment Finder", "Payment Finder")
        'Me.strFormTitle = IIf(LCase(strTag) = "all", "Business and Miscellaneous Payment Finder", IIf(LCase(strTag) = "rpt", "Real Property Payment Finder", "Payment Finder"))
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'TODO - It may be desirable to also write this exception to a log file
        'somewhere at some point, beyond the automatic logging that will take place
        'when (if?) the user hits "Send Data".
    End Sub

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
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.dtpORDate = New System.Windows.Forms.DateTimePicker
        Me.lblORDate = New System.Windows.Forms.Label
        Me.txtORAmount = New System.Windows.Forms.TextBox
        Me.lblORAmount = New System.Windows.Forms.Label
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblConstituentName = New System.Windows.Forms.Label
        Me.txtORNo = New System.Windows.Forms.TextBox
        Me.lblORNo = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
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
        Me.dgvHeader.TabIndex = 14
        '
        'dgvFinder
        '
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(10, 175)
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.RowTemplate.Height = 24
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 15
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(115, 115)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 10
        Me.btnClear.Text = "C&lear"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(545, 115)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "&Edit"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(335, 115)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 11
        Me.btnView.Text = "&View"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(10, 115)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 9
        Me.btnSearch.Text = "&Search"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.dtpORDate)
        Me.grpSearchCriteria.Controls.Add(Me.lblORDate)
        Me.grpSearchCriteria.Controls.Add(Me.txtORAmount)
        Me.grpSearchCriteria.Controls.Add(Me.lblORAmount)
        Me.grpSearchCriteria.Controls.Add(Me.txtMemberName)
        Me.grpSearchCriteria.Controls.Add(Me.lblConstituentName)
        Me.grpSearchCriteria.Controls.Add(Me.txtORNo)
        Me.grpSearchCriteria.Controls.Add(Me.lblORNo)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpSearchCriteria.Location = New System.Drawing.Point(10, 10)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 8
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'dtpORDate
        '
        Me.dtpORDate.CalendarFont = New System.Drawing.Font("Arial", 8.25!)
        Me.dtpORDate.Checked = False
        Me.dtpORDate.CustomFormat = "dddd, MMM dd, yyyy"
        Me.dtpORDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpORDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpORDate.Location = New System.Drawing.Point(425, 55)
        Me.dtpORDate.Name = "dtpORDate"
        Me.dtpORDate.ShowCheckBox = True
        Me.dtpORDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpORDate.TabIndex = 7
        Me.dtpORDate.Tag = "0"
        '
        'lblORDate
        '
        Me.lblORDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORDate.Location = New System.Drawing.Point(325, 55)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Size = New System.Drawing.Size(95, 20)
        Me.lblORDate.TabIndex = 6
        Me.lblORDate.Text = "OR Due"
        '
        'txtORAmount
        '
        Me.txtORAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtORAmount.Location = New System.Drawing.Point(115, 55)
        Me.txtORAmount.MaxLength = 45
        Me.txtORAmount.Name = "txtORAmount"
        Me.txtORAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtORAmount.TabIndex = 5
        Me.txtORAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblORAmount
        '
        Me.lblORAmount.AutoSize = True
        Me.lblORAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORAmount.Location = New System.Drawing.Point(15, 55)
        Me.lblORAmount.Name = "lblORAmount"
        Me.lblORAmount.Size = New System.Drawing.Size(93, 14)
        Me.lblORAmount.TabIndex = 4
        Me.lblORAmount.Text = "OR Amount ( < = )"
        '
        'txtMemberName
        '
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMemberName.Location = New System.Drawing.Point(425, 25)
        Me.txtMemberName.MaxLength = 45
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberName.TabIndex = 3
        '
        'lblConstituentName
        '
        Me.lblConstituentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConstituentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConstituentName.Location = New System.Drawing.Point(325, 25)
        Me.lblConstituentName.Name = "lblConstituentName"
        Me.lblConstituentName.Size = New System.Drawing.Size(95, 20)
        Me.lblConstituentName.TabIndex = 2
        Me.lblConstituentName.Text = "Member Name"
        '
        'txtORNo
        '
        Me.txtORNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtORNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtORNo.Location = New System.Drawing.Point(115, 25)
        Me.txtORNo.MaxLength = 45
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(200, 20)
        Me.txtORNo.TabIndex = 1
        '
        'lblORNo
        '
        Me.lblORNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblORNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblORNo.Location = New System.Drawing.Point(15, 25)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(95, 20)
        Me.lblORNo.TabIndex = 0
        Me.lblORNo.Text = "OR Number"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(440, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "&Add"
        '
        'frmPaymentLoanAndContributionFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 472)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnAdd)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmPaymentLoanAndContributionFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents dtpORDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblORDate As System.Windows.Forms.Label
    Friend WithEvents txtORAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblORAmount As System.Windows.Forms.Label
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblConstituentName As System.Windows.Forms.Label
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents lblORNo As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
