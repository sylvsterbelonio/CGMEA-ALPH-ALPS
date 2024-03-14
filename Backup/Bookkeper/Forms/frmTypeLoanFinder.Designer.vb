<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTypeLoanFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTypeLoanFinder))
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFrom = New System.Windows.Forms.NumericUpDown
        Me.txtTo = New System.Windows.Forms.NumericUpDown
        Me.lblConstituentType = New System.Windows.Forms.Label
        Me.txtInterestRate = New System.Windows.Forms.TextBox
        Me.txtType = New System.Windows.Forms.TextBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.lblLastName = New System.Windows.Forms.Label
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.myNav = New PowerNET8.myNavigationGrid
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchCriteria.SuspendLayout()
        CType(Me.txtFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvFinder
        '
        Me.dgvFinder.AllowUserToAddRows = False
        Me.dgvFinder.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvFinder.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFinder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.GridColor = System.Drawing.Color.White
        Me.dgvFinder.Location = New System.Drawing.Point(12, 139)
        Me.dgvFinder.MultiSelect = False
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.ReadOnly = True
        Me.dgvFinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 13
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(12, 103)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "&Search"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(117, 103)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "C&lear"
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.Label2)
        Me.grpSearchCriteria.Controls.Add(Me.Label1)
        Me.grpSearchCriteria.Controls.Add(Me.txtFrom)
        Me.grpSearchCriteria.Controls.Add(Me.txtTo)
        Me.grpSearchCriteria.Controls.Add(Me.lblConstituentType)
        Me.grpSearchCriteria.Controls.Add(Me.txtInterestRate)
        Me.grpSearchCriteria.Controls.Add(Me.txtType)
        Me.grpSearchCriteria.Controls.Add(Me.lblFirstName)
        Me.grpSearchCriteria.Controls.Add(Me.lblLastName)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(12, 7)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 7
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(214, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "To"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(102, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "From"
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(140, 51)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.Size = New System.Drawing.Size(68, 20)
        Me.txtFrom.TabIndex = 6
        Me.txtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTo
        '
        Me.txtTo.Location = New System.Drawing.Point(237, 51)
        Me.txtTo.Name = "txtTo"
        Me.txtTo.Size = New System.Drawing.Size(68, 20)
        Me.txtTo.TabIndex = 5
        Me.txtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblConstituentType
        '
        Me.lblConstituentType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConstituentType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConstituentType.Location = New System.Drawing.Point(15, 53)
        Me.lblConstituentType.Name = "lblConstituentType"
        Me.lblConstituentType.Size = New System.Drawing.Size(90, 16)
        Me.lblConstituentType.TabIndex = 4
        Me.lblConstituentType.Text = "Terms"
        '
        'txtInterestRate
        '
        Me.txtInterestRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInterestRate.Location = New System.Drawing.Point(420, 25)
        Me.txtInterestRate.MaxLength = 45
        Me.txtInterestRate.Name = "txtInterestRate"
        Me.txtInterestRate.Size = New System.Drawing.Size(200, 20)
        Me.txtInterestRate.TabIndex = 3
        '
        'txtType
        '
        Me.txtType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtType.Location = New System.Drawing.Point(105, 25)
        Me.txtType.MaxLength = 45
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(200, 20)
        Me.txtType.TabIndex = 1
        '
        'lblFirstName
        '
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(15, 25)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(90, 16)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "Type"
        '
        'lblLastName
        '
        Me.lblLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastName.Location = New System.Drawing.Point(324, 29)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(90, 16)
        Me.lblLastName.TabIndex = 2
        Me.lblLastName.Text = "Interest Rate"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(547, 103)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(442, 103)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 11
        Me.btnAdd.Text = "&Add"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(337, 103)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 10
        Me.btnView.Text = "&View"
        '
        'myNav
        '
        Me.myNav.Location = New System.Drawing.Point(12, 435)
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
        Me.myNav.Size = New System.Drawing.Size(635, 32)
        Me.myNav.TabIndex = 15
        '
        'frmTypeLoanFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 474)
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
        Me.Name = "frmTypeLoanFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Type Loan Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        CType(Me.txtFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents lblConstituentType As System.Windows.Forms.Label
    Friend WithEvents txtInterestRate As System.Windows.Forms.TextBox
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtTo As System.Windows.Forms.NumericUpDown
    Friend WithEvents myNav As PowerNET8.myNavigationGrid
End Class
