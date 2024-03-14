<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProvince
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProvince))
        Me.lblBarangayCount = New System.Windows.Forms.Label
        Me.txtBarangayCount = New System.Windows.Forms.TextBox
        Me.txtCityCount = New System.Windows.Forms.TextBox
        Me.lblCityCount = New System.Windows.Forms.Label
        Me.lblProvinceName = New System.Windows.Forms.Label
        Me.txtProvinceName = New System.Windows.Forms.TextBox
        Me.txtProvinceCode = New System.Windows.Forms.TextBox
        Me.lblProvinceCode = New System.Windows.Forms.Label
        Me.lblRegionName = New System.Windows.Forms.Label
        Me.lblMunicipalityCount = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.txtMunicipalityCount = New System.Windows.Forms.TextBox
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.lblIncomeClass = New System.Windows.Forms.Label
        Me.txtIncomeClassification = New System.Windows.Forms.TextBox
        Me.lblProvinceFlag = New System.Windows.Forms.Label
        Me.chkProvinceFl = New System.Windows.Forms.CheckBox
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBarangayCount
        '
        Me.lblBarangayCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblBarangayCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarangayCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangayCount.Location = New System.Drawing.Point(15, 215)
        Me.lblBarangayCount.Name = "lblBarangayCount"
        Me.lblBarangayCount.Size = New System.Drawing.Size(110, 16)
        Me.lblBarangayCount.TabIndex = 126
        Me.lblBarangayCount.Text = "Barangay Count"
        '
        'txtBarangayCount
        '
        Me.txtBarangayCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarangayCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBarangayCount.Location = New System.Drawing.Point(125, 215)
        Me.txtBarangayCount.Name = "txtBarangayCount"
        Me.txtBarangayCount.Size = New System.Drawing.Size(200, 20)
        Me.txtBarangayCount.TabIndex = 6
        Me.txtBarangayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCityCount
        '
        Me.txtCityCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCityCount.Location = New System.Drawing.Point(125, 155)
        Me.txtCityCount.Name = "txtCityCount"
        Me.txtCityCount.Size = New System.Drawing.Size(200, 20)
        Me.txtCityCount.TabIndex = 4
        Me.txtCityCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCityCount
        '
        Me.lblCityCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblCityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCityCount.Location = New System.Drawing.Point(15, 155)
        Me.lblCityCount.Name = "lblCityCount"
        Me.lblCityCount.Size = New System.Drawing.Size(110, 16)
        Me.lblCityCount.TabIndex = 124
        Me.lblCityCount.Text = "City Count"
        '
        'lblProvinceName
        '
        Me.lblProvinceName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceName.Location = New System.Drawing.Point(15, 95)
        Me.lblProvinceName.Name = "lblProvinceName"
        Me.lblProvinceName.Size = New System.Drawing.Size(110, 16)
        Me.lblProvinceName.TabIndex = 123
        Me.lblProvinceName.Text = "Province Name"
        '
        'txtProvinceName
        '
        Me.txtProvinceName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProvinceName.Location = New System.Drawing.Point(125, 95)
        Me.txtProvinceName.Name = "txtProvinceName"
        Me.txtProvinceName.Size = New System.Drawing.Size(200, 20)
        Me.txtProvinceName.TabIndex = 2
        '
        'txtProvinceCode
        '
        Me.txtProvinceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvinceCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinceCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProvinceCode.Location = New System.Drawing.Point(125, 125)
        Me.txtProvinceCode.Name = "txtProvinceCode"
        Me.txtProvinceCode.Size = New System.Drawing.Size(200, 20)
        Me.txtProvinceCode.TabIndex = 3
        '
        'lblProvinceCode
        '
        Me.lblProvinceCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblProvinceCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceCode.Location = New System.Drawing.Point(15, 125)
        Me.lblProvinceCode.Name = "lblProvinceCode"
        Me.lblProvinceCode.Size = New System.Drawing.Size(110, 16)
        Me.lblProvinceCode.TabIndex = 122
        Me.lblProvinceCode.Text = "Province Code"
        '
        'lblRegionName
        '
        Me.lblRegionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegionName.Location = New System.Drawing.Point(15, 65)
        Me.lblRegionName.Name = "lblRegionName"
        Me.lblRegionName.Size = New System.Drawing.Size(110, 16)
        Me.lblRegionName.TabIndex = 121
        Me.lblRegionName.Text = "Region Name"
        '
        'lblMunicipalityCount
        '
        Me.lblMunicipalityCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblMunicipalityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipalityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipalityCount.Location = New System.Drawing.Point(15, 185)
        Me.lblMunicipalityCount.Name = "lblMunicipalityCount"
        Me.lblMunicipalityCount.Size = New System.Drawing.Size(110, 16)
        Me.lblMunicipalityCount.TabIndex = 125
        Me.lblMunicipalityCount.Text = "Municipality Count"
        '
        'btnAdd
        '
        Me.btnAdd.ImageIndex = 0
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Text = "Add"
        Me.btnAdd.ToolTipText = "Add new record"
        '
        'btnEdit
        '
        Me.btnEdit.ImageIndex = 1
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Text = "Edit "
        Me.btnEdit.ToolTipText = "Edit record"
        '
        'tbrMainForm
        '
        Me.tbrMainForm.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrMainForm.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAdd, Me.btnEdit, Me.btnDelete, Me.btnFind, Me.btnSave, Me.btnCancel, Me.btnApprove})
        Me.tbrMainForm.ButtonSize = New System.Drawing.Size(40, 36)
        Me.tbrMainForm.Divider = False
        Me.tbrMainForm.DropDownArrows = True
        Me.tbrMainForm.ImageList = Me.ilTool
        Me.tbrMainForm.Location = New System.Drawing.Point(0, 0)
        Me.tbrMainForm.Name = "tbrMainForm"
        Me.tbrMainForm.ShowToolTips = True
        Me.tbrMainForm.Size = New System.Drawing.Size(350, 40)
        Me.tbrMainForm.TabIndex = 0
        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Delete record"
        '
        'btnFind
        '
        Me.btnFind.ImageIndex = 3
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Find"
        Me.btnFind.ToolTipText = "Launch Finder Screen"
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 4
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save Record"
        '
        'btnCancel
        '
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancel Changes Made"
        '
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 6
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Text = "Approve"
        '
        'ilTool
        '
        Me.ilTool.ImageStream = CType(resources.GetObject("ilTool.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilTool.TransparentColor = System.Drawing.Color.Transparent
        Me.ilTool.Images.SetKeyName(0, "add.ico")
        Me.ilTool.Images.SetKeyName(1, "edit.ico")
        Me.ilTool.Images.SetKeyName(2, "delete.ico")
        Me.ilTool.Images.SetKeyName(3, "find.ico")
        Me.ilTool.Images.SetKeyName(4, "save.ico")
        Me.ilTool.Images.SetKeyName(5, "cancel.ico")
        Me.ilTool.Images.SetKeyName(6, "approve.ico")
        '
        'txtMunicipalityCount
        '
        Me.txtMunicipalityCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMunicipalityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipalityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMunicipalityCount.Location = New System.Drawing.Point(125, 185)
        Me.txtMunicipalityCount.Name = "txtMunicipalityCount"
        Me.txtMunicipalityCount.Size = New System.Drawing.Size(200, 20)
        Me.txtMunicipalityCount.TabIndex = 5
        Me.txtMunicipalityCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(350, 45)
        Me.pnlToolbar.TabIndex = 120
        '
        'cboRcode
        '
        Me.cboRcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboRcode.FormattingEnabled = True
        Me.cboRcode.Location = New System.Drawing.Point(305, 65)
        Me.cboRcode.Name = "cboRcode"
        Me.cboRcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRcode.TabIndex = 1
        Me.cboRcode.TabStop = False
        Me.cboRcode.Visible = False
        '
        'cboRegion
        '
        Me.cboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRegion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboRegion.FormattingEnabled = True
        Me.cboRegion.Location = New System.Drawing.Point(125, 65)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(200, 22)
        Me.cboRegion.TabIndex = 0
        '
        'lblIncomeClass
        '
        Me.lblIncomeClass.BackColor = System.Drawing.SystemColors.Control
        Me.lblIncomeClass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncomeClass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIncomeClass.Location = New System.Drawing.Point(15, 245)
        Me.lblIncomeClass.Name = "lblIncomeClass"
        Me.lblIncomeClass.Size = New System.Drawing.Size(110, 16)
        Me.lblIncomeClass.TabIndex = 128
        Me.lblIncomeClass.Text = "Income Classification"
        '
        'txtIncomeClassification
        '
        Me.txtIncomeClassification.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIncomeClassification.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomeClassification.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIncomeClassification.Location = New System.Drawing.Point(125, 245)
        Me.txtIncomeClassification.Name = "txtIncomeClassification"
        Me.txtIncomeClassification.Size = New System.Drawing.Size(200, 20)
        Me.txtIncomeClassification.TabIndex = 7
        Me.txtIncomeClassification.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblProvinceFlag
        '
        Me.lblProvinceFlag.BackColor = System.Drawing.SystemColors.Control
        Me.lblProvinceFlag.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceFlag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceFlag.Location = New System.Drawing.Point(15, 275)
        Me.lblProvinceFlag.Name = "lblProvinceFlag"
        Me.lblProvinceFlag.Size = New System.Drawing.Size(110, 16)
        Me.lblProvinceFlag.TabIndex = 130
        Me.lblProvinceFlag.Text = "Province Flag"
        '
        'chkProvinceFl
        '
        Me.chkProvinceFl.AutoSize = True
        Me.chkProvinceFl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkProvinceFl.Location = New System.Drawing.Point(125, 275)
        Me.chkProvinceFl.Name = "chkProvinceFl"
        Me.chkProvinceFl.Size = New System.Drawing.Size(15, 14)
        Me.chkProvinceFl.TabIndex = 8
        Me.chkProvinceFl.Tag = "1"
        Me.chkProvinceFl.UseVisualStyleBackColor = True
        '
        'frmProvince
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 315)
        Me.Controls.Add(Me.chkProvinceFl)
        Me.Controls.Add(Me.lblProvinceFlag)
        Me.Controls.Add(Me.lblIncomeClass)
        Me.Controls.Add(Me.txtIncomeClassification)
        Me.Controls.Add(Me.cboRcode)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.lblBarangayCount)
        Me.Controls.Add(Me.txtBarangayCount)
        Me.Controls.Add(Me.txtCityCount)
        Me.Controls.Add(Me.lblCityCount)
        Me.Controls.Add(Me.lblProvinceName)
        Me.Controls.Add(Me.txtProvinceName)
        Me.Controls.Add(Me.txtProvinceCode)
        Me.Controls.Add(Me.lblProvinceCode)
        Me.Controls.Add(Me.lblRegionName)
        Me.Controls.Add(Me.lblMunicipalityCount)
        Me.Controls.Add(Me.txtMunicipalityCount)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmProvince"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Province"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblBarangayCount As System.Windows.Forms.Label
    Friend WithEvents txtBarangayCount As System.Windows.Forms.TextBox
    Friend WithEvents txtCityCount As System.Windows.Forms.TextBox
    Friend WithEvents lblCityCount As System.Windows.Forms.Label
    Friend WithEvents lblProvinceName As System.Windows.Forms.Label
    Friend WithEvents txtProvinceName As System.Windows.Forms.TextBox
    Friend WithEvents txtProvinceCode As System.Windows.Forms.TextBox
    Friend WithEvents lblProvinceCode As System.Windows.Forms.Label
    Friend WithEvents lblRegionName As System.Windows.Forms.Label
    Friend WithEvents lblMunicipalityCount As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtMunicipalityCount As System.Windows.Forms.TextBox
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents lblIncomeClass As System.Windows.Forms.Label
    Friend WithEvents txtIncomeClassification As System.Windows.Forms.TextBox
    Friend WithEvents lblProvinceFlag As System.Windows.Forms.Label
    Friend WithEvents chkProvinceFl As System.Windows.Forms.CheckBox
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
