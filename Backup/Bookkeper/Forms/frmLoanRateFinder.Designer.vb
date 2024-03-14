<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoanRateFinder
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoanRateFinder))
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.txtLongTerm = New System.Windows.Forms.TextBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.myNav = New PowerNET8.myNavigationGrid
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvFinder
        '
        Me.dgvFinder.AllowUserToAddRows = False
        Me.dgvFinder.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFinder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvFinder.GridColor = System.Drawing.Color.White
        Me.dgvFinder.Location = New System.Drawing.Point(12, 121)
        Me.dgvFinder.MultiSelect = False
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.ReadOnly = True
        Me.dgvFinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinder.Size = New System.Drawing.Size(521, 290)
        Me.dgvFinder.TabIndex = 13
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(12, 85)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "&Search"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(117, 85)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "C&lear"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtLongTerm)
        Me.grpSearchCriteria.Controls.Add(Me.lblFirstName)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(12, 11)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(521, 65)
        Me.grpSearchCriteria.TabIndex = 7
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'txtLongTerm
        '
        Me.txtLongTerm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLongTerm.Location = New System.Drawing.Point(105, 25)
        Me.txtLongTerm.MaxLength = 45
        Me.txtLongTerm.Name = "txtLongTerm"
        Me.txtLongTerm.Size = New System.Drawing.Size(410, 20)
        Me.txtLongTerm.TabIndex = 1
        '
        'lblFirstName
        '
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(15, 25)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(90, 16)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "Loan Term"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(433, 85)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(328, 85)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "&Add"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(223, 85)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 10
        Me.btnView.Text = "&View"
        '
        'myNav
        '
        Me.myNav.Location = New System.Drawing.Point(12, 417)
        Me.myNav.My_Skin_BackGround_BorderColor = System.Drawing.Color.White
        Me.myNav.My_Skin_BackGround_BottomColor1 = System.Drawing.Color.LightGray
        Me.myNav.My_Skin_BackGround_BottomColor2 = System.Drawing.Color.White
        Me.myNav.My_Skin_BackGround_Has_Border = False
        Me.myNav.My_Skin_BackGround_TopColor1 = System.Drawing.Color.White
        Me.myNav.My_Skin_BackGround_TopColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_Select_BorderColor = System.Drawing.Color.Black
        Me.myNav.My_Skin_Selection_Style_Custom_Select_BottomColor1 = System.Drawing.Color.FromArgb(CType(CType(198, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_Select_BottomColor2 = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_Select_Has_Border = False
        Me.myNav.My_Skin_Selection_Style_Custom_Select_TopColor1 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_Select_TopColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_UnSelect_BorderColor = System.Drawing.Color.FromArgb(CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_UnSelect_BottomColor1 = System.Drawing.Color.FromArgb(CType(CType(193, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_UnSelect_BottomColor2 = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_UnSelect_Has_Border = False
        Me.myNav.My_Skin_Selection_Style_Custom_UnSelect_TopColor1 = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.myNav.My_Skin_Selection_Style_Custom_UnSelect_TopColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.myNav.My_Skin_Standard_Select_FontColor = System.Drawing.Color.DarkBlue
        Me.myNav.My_Skin_Standard_UnSelect_FontColor = System.Drawing.Color.Black
        Me.myNav.My_TxtCbo_Backcolor_GotFocus = System.Drawing.Color.Azure
        Me.myNav.My_TxtCbo_Backcolor_LostFocus = System.Drawing.Color.White
        Me.myNav.My_TxtCbo_Fontcolor_GotFocus = System.Drawing.Color.SteelBlue
        Me.myNav.My_TxtCbo_Fontcolor_LostFocus = System.Drawing.Color.Black
        Me.myNav.My_UI_ICON_HOVER_JQUERY = CType(resources.GetObject("myNav.My_UI_ICON_HOVER_JQUERY"), System.Drawing.Image)
        Me.myNav.My_UI_ICON_NORMAL_JQUERY = CType(resources.GetObject("myNav.My_UI_ICON_NORMAL_JQUERY"), System.Drawing.Image)
        Me.myNav.Name = "myNav"
        Me.myNav.Padding = New System.Windows.Forms.Padding(1)
        Me.myNav.Size = New System.Drawing.Size(521, 32)
        Me.myNav.TabIndex = 14
        '
        'frmLoanRateFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 454)
        Me.Controls.Add(Me.myNav)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmLoanRateFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loan Rate Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents txtLongTerm As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents myNav As PowerNET8.myNavigationGrid
End Class
