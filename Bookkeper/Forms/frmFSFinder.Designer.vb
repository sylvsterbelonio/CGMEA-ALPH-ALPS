<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFSFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFSFinder))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.myNav = New PowerNET8.myNavigationGrid
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.txtExpensesName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtcategoryName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFSName = New System.Windows.Forms.TextBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'myNav
        '
        Me.myNav.Location = New System.Drawing.Point(12, 443)
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
        Me.myNav.Size = New System.Drawing.Size(576, 32)
        Me.myNav.TabIndex = 22
        '
        'dgvFinder
        '
        Me.dgvFinder.AllowUserToAddRows = False
        Me.dgvFinder.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFinder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFinder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvFinder.GridColor = System.Drawing.Color.White
        Me.dgvFinder.Location = New System.Drawing.Point(12, 147)
        Me.dgvFinder.MultiSelect = False
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.ReadOnly = True
        Me.dgvFinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinder.Size = New System.Drawing.Size(576, 290)
        Me.dgvFinder.TabIndex = 21
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(12, 111)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(89, 30)
        Me.btnSearch.TabIndex = 16
        Me.btnSearch.Text = "&Search"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(107, 111)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 30)
        Me.btnClear.TabIndex = 17
        Me.btnClear.Text = "C&lear"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtExpensesName)
        Me.grpSearchCriteria.Controls.Add(Me.Label2)
        Me.grpSearchCriteria.Controls.Add(Me.txtcategoryName)
        Me.grpSearchCriteria.Controls.Add(Me.Label1)
        Me.grpSearchCriteria.Controls.Add(Me.txtFSName)
        Me.grpSearchCriteria.Controls.Add(Me.lblFirstName)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(12, 12)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(576, 93)
        Me.grpSearchCriteria.TabIndex = 15
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'txtExpensesName
        '
        Me.txtExpensesName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExpensesName.Location = New System.Drawing.Point(383, 28)
        Me.txtExpensesName.MaxLength = 45
        Me.txtExpensesName.Name = "txtExpensesName"
        Me.txtExpensesName.Size = New System.Drawing.Size(182, 20)
        Me.txtExpensesName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(293, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Expenses Name"
        '
        'txtcategoryName
        '
        Me.txtcategoryName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcategoryName.Location = New System.Drawing.Point(105, 51)
        Me.txtcategoryName.MaxLength = 45
        Me.txtcategoryName.Name = "txtcategoryName"
        Me.txtcategoryName.Size = New System.Drawing.Size(182, 20)
        Me.txtcategoryName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Category Name"
        '
        'txtFSName
        '
        Me.txtFSName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFSName.Location = New System.Drawing.Point(105, 25)
        Me.txtFSName.MaxLength = 45
        Me.txtFSName.Name = "txtFSName"
        Me.txtFSName.Size = New System.Drawing.Size(182, 20)
        Me.txtFSName.TabIndex = 1
        '
        'lblFirstName
        '
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(15, 25)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(90, 16)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "FS Name"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(501, 111)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(85, 30)
        Me.btnEdit.TabIndex = 20
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(407, 111)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(88, 30)
        Me.btnAdd.TabIndex = 19
        Me.btnAdd.Text = "&Add"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(313, 111)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(88, 30)
        Me.btnView.TabIndex = 18
        Me.btnView.Text = "&View"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(219, 111)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 30)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "&Report"
        '
        'frmFSFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(601, 483)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.myNav)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmFSFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FS Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents myNav As PowerNET8.myNavigationGrid
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents txtFSName As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents txtExpensesName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtcategoryName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
