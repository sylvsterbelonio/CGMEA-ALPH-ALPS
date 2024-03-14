<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConstituentFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConstituentFinder))
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.lblConstituentType = New System.Windows.Forms.Label
        Me.cboConstituentType = New System.Windows.Forms.ComboBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.lblLastName = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.dgvHeader = New System.Windows.Forms.Label
        Me.lblRemarks = New CloudToolkitN6.CloudLabel
        Me.lblTotalPage = New CloudToolkitN6.CloudLabel
        Me.cboLimiter = New System.Windows.Forms.ComboBox
        Me.txtPageNo = New CloudToolkitN6.CloudTextBox
        Me.CloudHeader2 = New CloudToolkitN6.CloudHeader
        Me.picLast = New System.Windows.Forms.PictureBox
        Me.picNext = New System.Windows.Forms.PictureBox
        Me.picPrev = New System.Windows.Forms.PictureBox
        Me.picFirst = New System.Windows.Forms.PictureBox
        Me.btnSearch = New System.Windows.Forms.Button
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLast, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPrev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFirst, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFirstName
        '
        Me.txtFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(105, 25)
        Me.txtFirstName.MaxLength = 45
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'txtLastName
        '
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(420, 25)
        Me.txtLastName.MaxLength = 45
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(200, 20)
        Me.txtLastName.TabIndex = 3
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
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.lblConstituentType)
        Me.grpSearchCriteria.Controls.Add(Me.cboConstituentType)
        Me.grpSearchCriteria.Controls.Add(Me.txtLastName)
        Me.grpSearchCriteria.Controls.Add(Me.txtFirstName)
        Me.grpSearchCriteria.Controls.Add(Me.lblFirstName)
        Me.grpSearchCriteria.Controls.Add(Me.lblLastName)
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
        'lblConstituentType
        '
        Me.lblConstituentType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConstituentType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConstituentType.Location = New System.Drawing.Point(15, 55)
        Me.lblConstituentType.Name = "lblConstituentType"
        Me.lblConstituentType.Size = New System.Drawing.Size(90, 16)
        Me.lblConstituentType.TabIndex = 4
        Me.lblConstituentType.Text = "Type"
        '
        'cboConstituentType
        '
        Me.cboConstituentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConstituentType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConstituentType.FormattingEnabled = True
        Me.cboConstituentType.Items.AddRange(New Object() {"", "ENTITY / ORGANIZATION / OTHERS", "INDIVIDUAL"})
        Me.cboConstituentType.Location = New System.Drawing.Point(105, 55)
        Me.cboConstituentType.Name = "cboConstituentType"
        Me.cboConstituentType.Size = New System.Drawing.Size(200, 22)
        Me.cboConstituentType.TabIndex = 5
        '
        'lblFirstName
        '
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(15, 25)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(90, 16)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First Name"
        '
        'lblLastName
        '
        Me.lblLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastName.Location = New System.Drawing.Point(330, 25)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(90, 16)
        Me.lblLastName.TabIndex = 2
        Me.lblLastName.Text = "Last Name"
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
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(10, 155)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(635, 20)
        Me.dgvHeader.TabIndex = 43
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.Color.White
        Me.lblRemarks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.lblRemarks.Location = New System.Drawing.Point(439, 469)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(199, 19)
        Me.lblRemarks.TabIndex = 53
        Me.lblRemarks.Text = "-"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalPage
        '
        Me.lblTotalPage.BackColor = System.Drawing.Color.White
        Me.lblTotalPage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(79, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.lblTotalPage.Location = New System.Drawing.Point(302, 470)
        Me.lblTotalPage.Name = "lblTotalPage"
        Me.lblTotalPage.Size = New System.Drawing.Size(38, 17)
        Me.lblTotalPage.TabIndex = 51
        Me.lblTotalPage.Text = "/ 0"
        '
        'cboLimiter
        '
        Me.cboLimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLimiter.FormattingEnabled = True
        Me.cboLimiter.Items.AddRange(New Object() {"25", "50", "100", "200", "500", "1000"})
        Me.cboLimiter.Location = New System.Drawing.Point(388, 467)
        Me.cboLimiter.Name = "cboLimiter"
        Me.cboLimiter.Size = New System.Drawing.Size(45, 22)
        Me.cboLimiter.TabIndex = 47
        '
        'txtPageNo
        '
        Me.txtPageNo.Location = New System.Drawing.Point(263, 469)
        Me.txtPageNo.Name = "txtPageNo"
        Me.txtPageNo.Size = New System.Drawing.Size(35, 20)
        Me.txtPageNo.TabIndex = 46
        Me.txtPageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPageNo.TextRenderingMode = System.Drawing.Text.TextRenderingHint.AntiAlias
        '
        'CloudHeader2
        '
        Me.CloudHeader2.BackColor = System.Drawing.Color.Transparent
        Me.CloudHeader2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CloudHeader2.BorderColor = System.Drawing.Color.DarkGray
        Me.CloudHeader2.BorderWidth = 1.0!
        Me.CloudHeader2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CloudHeader2.FillColor1 = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.CloudHeader2.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.CloudHeader2.FillColor2_1 = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.CloudHeader2.FillColor2_2 = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.CloudHeader2.FontColorMouseOn = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CloudHeader2.FontColorNormal = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.CloudHeader2.HeaderText = Nothing
        Me.CloudHeader2.Icon = Nothing
        Me.CloudHeader2.IconAlign = CloudToolkitN6.CloudHeader.IconAlignement.Right
        Me.CloudHeader2.IconPadding = 5
        Me.CloudHeader2.ImageHeader = False
        Me.CloudHeader2.Location = New System.Drawing.Point(10, 465)
        Me.CloudHeader2.Name = "CloudHeader2"
        Me.CloudHeader2.Size = New System.Drawing.Size(635, 27)
        Me.CloudHeader2.TabIndex = 45
        '
        'picLast
        '
        Me.picLast.BackColor = System.Drawing.Color.Azure
        Me.picLast.Image = Global.Constituent.My.Resources.Resources.page_last
        Me.picLast.Location = New System.Drawing.Point(365, 470)
        Me.picLast.Name = "picLast"
        Me.picLast.Size = New System.Drawing.Size(16, 17)
        Me.picLast.TabIndex = 52
        Me.picLast.TabStop = False
        '
        'picNext
        '
        Me.picNext.BackColor = System.Drawing.Color.Azure
        Me.picNext.Image = Global.Constituent.My.Resources.Resources.page_next
        Me.picNext.Location = New System.Drawing.Point(346, 470)
        Me.picNext.Name = "picNext"
        Me.picNext.Size = New System.Drawing.Size(16, 17)
        Me.picNext.TabIndex = 50
        Me.picNext.TabStop = False
        '
        'picPrev
        '
        Me.picPrev.BackColor = System.Drawing.Color.Azure
        Me.picPrev.Image = Global.Constituent.My.Resources.Resources.page_prev
        Me.picPrev.Location = New System.Drawing.Point(242, 470)
        Me.picPrev.Name = "picPrev"
        Me.picPrev.Size = New System.Drawing.Size(16, 17)
        Me.picPrev.TabIndex = 49
        Me.picPrev.TabStop = False
        '
        'picFirst
        '
        Me.picFirst.BackColor = System.Drawing.Color.Azure
        Me.picFirst.Image = Global.Constituent.My.Resources.Resources.page_first
        Me.picFirst.Location = New System.Drawing.Point(223, 470)
        Me.picFirst.Name = "picFirst"
        Me.picFirst.Size = New System.Drawing.Size(16, 17)
        Me.picFirst.TabIndex = 48
        Me.picFirst.TabStop = False
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
        'frmConstituentFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 495)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.picLast)
        Me.Controls.Add(Me.lblTotalPage)
        Me.Controls.Add(Me.picNext)
        Me.Controls.Add(Me.picPrev)
        Me.Controls.Add(Me.picFirst)
        Me.Controls.Add(Me.cboLimiter)
        Me.Controls.Add(Me.txtPageNo)
        Me.Controls.Add(Me.CloudHeader2)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnView)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(661, 523)
        Me.MinimumSize = New System.Drawing.Size(661, 523)
        Me.Name = "frmConstituentFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Constituent Finder"
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLast, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPrev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFirst, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents lblConstituentType As System.Windows.Forms.Label
    Friend WithEvents cboConstituentType As System.Windows.Forms.ComboBox
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As CloudToolkitN6.CloudLabel
    Friend WithEvents picLast As System.Windows.Forms.PictureBox
    Friend WithEvents lblTotalPage As CloudToolkitN6.CloudLabel
    Friend WithEvents picNext As System.Windows.Forms.PictureBox
    Friend WithEvents picPrev As System.Windows.Forms.PictureBox
    Friend WithEvents picFirst As System.Windows.Forms.PictureBox
    Friend WithEvents cboLimiter As System.Windows.Forms.ComboBox
    Friend WithEvents txtPageNo As CloudToolkitN6.CloudTextBox
    Friend WithEvents CloudHeader2 As CloudToolkitN6.CloudHeader
End Class
