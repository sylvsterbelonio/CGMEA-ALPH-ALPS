<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRevisionFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRevisionFinder))
        Me.dgvHeader = New System.Windows.Forms.Label
        Me.dgvFinder = New System.Windows.Forms.DataGridView
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnView = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.myNav = New PowerNET8.myNavigationGrid
        Me.grpSearchCriteria = New System.Windows.Forms.GroupBox
        Me.txtYearTo = New System.Windows.Forms.TextBox
        Me.txtYearFrom = New System.Windows.Forms.TextBox
        Me.lblYearFrom = New System.Windows.Forms.Label
        Me.lblYearTo = New System.Windows.Forms.Label
        Me.txtRevisionCode = New System.Windows.Forms.TextBox
        Me.txtRevisionName = New System.Windows.Forms.TextBox
        Me.lblRevisionName = New System.Windows.Forms.Label
        Me.lblRevisionCode = New System.Windows.Forms.Label
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSearchCriteria.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvHeader
        '
        Me.dgvHeader.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.dgvHeader.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvHeader.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvHeader.Location = New System.Drawing.Point(12, 157)
        Me.dgvHeader.Name = "dgvHeader"
        Me.dgvHeader.Size = New System.Drawing.Size(635, 20)
        Me.dgvHeader.TabIndex = 53
        '
        'dgvFinder
        '
        Me.dgvFinder.AllowUserToAddRows = False
        Me.dgvFinder.AllowUserToDeleteRows = False
        Me.dgvFinder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvFinder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFinder.Location = New System.Drawing.Point(12, 177)
        Me.dgvFinder.MultiSelect = False
        Me.dgvFinder.Name = "dgvFinder"
        Me.dgvFinder.ReadOnly = True
        Me.dgvFinder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFinder.Size = New System.Drawing.Size(635, 290)
        Me.dgvFinder.TabIndex = 52
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEdit.Location = New System.Drawing.Point(547, 117)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(100, 30)
        Me.btnEdit.TabIndex = 51
        Me.btnEdit.Text = "&Edit"
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAdd.Location = New System.Drawing.Point(442, 117)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 30)
        Me.btnAdd.TabIndex = 50
        Me.btnAdd.Text = "&Add"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSearch.Location = New System.Drawing.Point(12, 117)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(100, 30)
        Me.btnSearch.TabIndex = 47
        Me.btnSearch.Text = "&Search"
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnView.Location = New System.Drawing.Point(337, 117)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(100, 30)
        Me.btnView.TabIndex = 49
        Me.btnView.Text = "&View"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(117, 117)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 30)
        Me.btnClear.TabIndex = 48
        Me.btnClear.Text = "C&lear"
        '
        'myNav
        '
        Me.myNav.Location = New System.Drawing.Point(12, 473)
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
        Me.myNav.Size = New System.Drawing.Size(637, 32)
        Me.myNav.TabIndex = 62
        '
        'grpSearchCriteria
        '
        Me.grpSearchCriteria.Controls.Add(Me.txtYearTo)
        Me.grpSearchCriteria.Controls.Add(Me.txtYearFrom)
        Me.grpSearchCriteria.Controls.Add(Me.lblYearFrom)
        Me.grpSearchCriteria.Controls.Add(Me.lblYearTo)
        Me.grpSearchCriteria.Controls.Add(Me.txtRevisionCode)
        Me.grpSearchCriteria.Controls.Add(Me.txtRevisionName)
        Me.grpSearchCriteria.Controls.Add(Me.lblRevisionName)
        Me.grpSearchCriteria.Controls.Add(Me.lblRevisionCode)
        Me.grpSearchCriteria.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.grpSearchCriteria.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSearchCriteria.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpSearchCriteria.Location = New System.Drawing.Point(12, 12)
        Me.grpSearchCriteria.Name = "grpSearchCriteria"
        Me.grpSearchCriteria.Size = New System.Drawing.Size(635, 90)
        Me.grpSearchCriteria.TabIndex = 63
        Me.grpSearchCriteria.TabStop = False
        Me.grpSearchCriteria.Text = "Search Criteria"
        '
        'txtYearTo
        '
        Me.txtYearTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtYearTo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearTo.Location = New System.Drawing.Point(420, 55)
        Me.txtYearTo.MaxLength = 4
        Me.txtYearTo.Name = "txtYearTo"
        Me.txtYearTo.Size = New System.Drawing.Size(200, 20)
        Me.txtYearTo.TabIndex = 7
        '
        'txtYearFrom
        '
        Me.txtYearFrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYearFrom.Location = New System.Drawing.Point(100, 55)
        Me.txtYearFrom.MaxLength = 45
        Me.txtYearFrom.Name = "txtYearFrom"
        Me.txtYearFrom.Size = New System.Drawing.Size(200, 20)
        Me.txtYearFrom.TabIndex = 5
        '
        'lblYearFrom
        '
        Me.lblYearFrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearFrom.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYearFrom.Location = New System.Drawing.Point(15, 55)
        Me.lblYearFrom.Name = "lblYearFrom"
        Me.lblYearFrom.Size = New System.Drawing.Size(80, 16)
        Me.lblYearFrom.TabIndex = 4
        Me.lblYearFrom.Text = "Year From"
        '
        'lblYearTo
        '
        Me.lblYearTo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYearTo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblYearTo.Location = New System.Drawing.Point(335, 55)
        Me.lblYearTo.Name = "lblYearTo"
        Me.lblYearTo.Size = New System.Drawing.Size(80, 16)
        Me.lblYearTo.TabIndex = 6
        Me.lblYearTo.Text = "Year To"
        '
        'txtRevisionCode
        '
        Me.txtRevisionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRevisionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRevisionCode.Location = New System.Drawing.Point(420, 25)
        Me.txtRevisionCode.MaxLength = 4
        Me.txtRevisionCode.Name = "txtRevisionCode"
        Me.txtRevisionCode.Size = New System.Drawing.Size(200, 20)
        Me.txtRevisionCode.TabIndex = 3
        '
        'txtRevisionName
        '
        Me.txtRevisionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRevisionName.Location = New System.Drawing.Point(100, 25)
        Me.txtRevisionName.MaxLength = 45
        Me.txtRevisionName.Name = "txtRevisionName"
        Me.txtRevisionName.Size = New System.Drawing.Size(200, 20)
        Me.txtRevisionName.TabIndex = 1
        '
        'lblRevisionName
        '
        Me.lblRevisionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevisionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRevisionName.Location = New System.Drawing.Point(15, 25)
        Me.lblRevisionName.Name = "lblRevisionName"
        Me.lblRevisionName.Size = New System.Drawing.Size(80, 16)
        Me.lblRevisionName.TabIndex = 0
        Me.lblRevisionName.Text = "Revision Name"
        '
        'lblRevisionCode
        '
        Me.lblRevisionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevisionCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRevisionCode.Location = New System.Drawing.Point(335, 25)
        Me.lblRevisionCode.Name = "lblRevisionCode"
        Me.lblRevisionCode.Size = New System.Drawing.Size(80, 16)
        Me.lblRevisionCode.TabIndex = 2
        Me.lblRevisionCode.Text = "Revision Code"
        '
        'frmRevisionFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 520)
        Me.Controls.Add(Me.grpSearchCriteria)
        Me.Controls.Add(Me.myNav)
        Me.Controls.Add(Me.dgvHeader)
        Me.Controls.Add(Me.dgvFinder)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnView)
        Me.Controls.Add(Me.btnClear)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmRevisionFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Revision Code Finder"
        CType(Me.dgvFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSearchCriteria.ResumeLayout(False)
        Me.grpSearchCriteria.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvHeader As System.Windows.Forms.Label
    Friend WithEvents dgvFinder As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents myNav As PowerNET8.myNavigationGrid
    Friend WithEvents grpSearchCriteria As System.Windows.Forms.GroupBox
    Friend WithEvents txtYearTo As System.Windows.Forms.TextBox
    Friend WithEvents txtYearFrom As System.Windows.Forms.TextBox
    Friend WithEvents lblYearFrom As System.Windows.Forms.Label
    Friend WithEvents lblYearTo As System.Windows.Forms.Label
    Friend WithEvents txtRevisionCode As System.Windows.Forms.TextBox
    Friend WithEvents txtRevisionName As System.Windows.Forms.TextBox
    Friend WithEvents lblRevisionName As System.Windows.Forms.Label
    Friend WithEvents lblRevisionCode As System.Windows.Forms.Label
End Class
