<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMunicipality
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMunicipality))
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.chkCityFl = New System.Windows.Forms.CheckBox
        Me.lblCityFlag = New System.Windows.Forms.Label
        Me.lblIncomeClass = New System.Windows.Forms.Label
        Me.txtIncomeClassification = New System.Windows.Forms.TextBox
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.lblMunicipalityName = New System.Windows.Forms.Label
        Me.txtMunicipalityName = New System.Windows.Forms.TextBox
        Me.txtMunicipalityCode = New System.Windows.Forms.TextBox
        Me.lblMunicipalityCode = New System.Windows.Forms.Label
        Me.lblRegionName = New System.Windows.Forms.Label
        Me.cboPcode = New System.Windows.Forms.ComboBox
        Me.cboProvince = New System.Windows.Forms.ComboBox
        Me.lblProvinceName = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
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
        'btnFind
        '
        Me.btnFind.ImageIndex = 3
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Find"
        Me.btnFind.ToolTipText = "Launch Finder Screen"
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
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Delete record"
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
        'chkCityFl
        '
        Me.chkCityFl.AutoSize = True
        Me.chkCityFl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCityFl.Location = New System.Drawing.Point(125, 215)
        Me.chkCityFl.Name = "chkCityFl"
        Me.chkCityFl.Size = New System.Drawing.Size(15, 14)
        Me.chkCityFl.TabIndex = 7
        Me.chkCityFl.Tag = "0"
        Me.chkCityFl.UseVisualStyleBackColor = True
        '
        'lblCityFlag
        '
        Me.lblCityFlag.BackColor = System.Drawing.SystemColors.Control
        Me.lblCityFlag.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCityFlag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCityFlag.Location = New System.Drawing.Point(15, 215)
        Me.lblCityFlag.Name = "lblCityFlag"
        Me.lblCityFlag.Size = New System.Drawing.Size(110, 16)
        Me.lblCityFlag.TabIndex = 148
        Me.lblCityFlag.Text = "City Flag"
        '
        'lblIncomeClass
        '
        Me.lblIncomeClass.BackColor = System.Drawing.SystemColors.Control
        Me.lblIncomeClass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncomeClass.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIncomeClass.Location = New System.Drawing.Point(15, 185)
        Me.lblIncomeClass.Name = "lblIncomeClass"
        Me.lblIncomeClass.Size = New System.Drawing.Size(110, 16)
        Me.lblIncomeClass.TabIndex = 147
        Me.lblIncomeClass.Text = "Income Classification"
        '
        'txtIncomeClassification
        '
        Me.txtIncomeClassification.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIncomeClassification.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIncomeClassification.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIncomeClassification.Location = New System.Drawing.Point(125, 185)
        Me.txtIncomeClassification.Name = "txtIncomeClassification"
        Me.txtIncomeClassification.Size = New System.Drawing.Size(200, 20)
        Me.txtIncomeClassification.TabIndex = 6
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
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(350, 45)
        Me.pnlToolbar.TabIndex = 140
        '
        'lblMunicipalityName
        '
        Me.lblMunicipalityName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMunicipalityName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipalityName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipalityName.Location = New System.Drawing.Point(15, 125)
        Me.lblMunicipalityName.Name = "lblMunicipalityName"
        Me.lblMunicipalityName.Size = New System.Drawing.Size(110, 16)
        Me.lblMunicipalityName.TabIndex = 143
        Me.lblMunicipalityName.Text = "Municipality Name"
        '
        'txtMunicipalityName
        '
        Me.txtMunicipalityName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMunicipalityName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipalityName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMunicipalityName.Location = New System.Drawing.Point(125, 125)
        Me.txtMunicipalityName.Name = "txtMunicipalityName"
        Me.txtMunicipalityName.Size = New System.Drawing.Size(200, 20)
        Me.txtMunicipalityName.TabIndex = 4
        '
        'txtMunicipalityCode
        '
        Me.txtMunicipalityCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMunicipalityCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipalityCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMunicipalityCode.Location = New System.Drawing.Point(125, 155)
        Me.txtMunicipalityCode.Name = "txtMunicipalityCode"
        Me.txtMunicipalityCode.Size = New System.Drawing.Size(200, 20)
        Me.txtMunicipalityCode.TabIndex = 5
        '
        'lblMunicipalityCode
        '
        Me.lblMunicipalityCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblMunicipalityCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipalityCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipalityCode.Location = New System.Drawing.Point(15, 155)
        Me.lblMunicipalityCode.Name = "lblMunicipalityCode"
        Me.lblMunicipalityCode.Size = New System.Drawing.Size(110, 16)
        Me.lblMunicipalityCode.TabIndex = 142
        Me.lblMunicipalityCode.Text = "Municipality Code"
        '
        'lblRegionName
        '
        Me.lblRegionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegionName.Location = New System.Drawing.Point(15, 65)
        Me.lblRegionName.Name = "lblRegionName"
        Me.lblRegionName.Size = New System.Drawing.Size(110, 16)
        Me.lblRegionName.TabIndex = 141
        Me.lblRegionName.Text = "Region Name"
        '
        'cboPcode
        '
        Me.cboPcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboPcode.FormattingEnabled = True
        Me.cboPcode.Location = New System.Drawing.Point(305, 95)
        Me.cboPcode.Name = "cboPcode"
        Me.cboPcode.Size = New System.Drawing.Size(20, 22)
        Me.cboPcode.TabIndex = 3
        Me.cboPcode.TabStop = False
        Me.cboPcode.Visible = False
        '
        'cboProvince
        '
        Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvince.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(125, 95)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(200, 22)
        Me.cboProvince.TabIndex = 2
        '
        'lblProvinceName
        '
        Me.lblProvinceName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceName.Location = New System.Drawing.Point(15, 95)
        Me.lblProvinceName.Name = "lblProvinceName"
        Me.lblProvinceName.Size = New System.Drawing.Size(110, 16)
        Me.lblProvinceName.TabIndex = 151
        Me.lblProvinceName.Text = "Province Name"
        '
        'frmMunicipality
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 245)
        Me.Controls.Add(Me.cboPcode)
        Me.Controls.Add(Me.cboProvince)
        Me.Controls.Add(Me.lblProvinceName)
        Me.Controls.Add(Me.chkCityFl)
        Me.Controls.Add(Me.lblCityFlag)
        Me.Controls.Add(Me.lblIncomeClass)
        Me.Controls.Add(Me.txtIncomeClassification)
        Me.Controls.Add(Me.cboRcode)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblMunicipalityName)
        Me.Controls.Add(Me.txtMunicipalityName)
        Me.Controls.Add(Me.txtMunicipalityCode)
        Me.Controls.Add(Me.lblMunicipalityCode)
        Me.Controls.Add(Me.lblRegionName)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMunicipality"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "City / Municipality"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents chkCityFl As System.Windows.Forms.CheckBox
    Friend WithEvents lblCityFlag As System.Windows.Forms.Label
    Friend WithEvents lblIncomeClass As System.Windows.Forms.Label
    Friend WithEvents txtIncomeClassification As System.Windows.Forms.TextBox
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents lblMunicipalityName As System.Windows.Forms.Label
    Friend WithEvents txtMunicipalityName As System.Windows.Forms.TextBox
    Friend WithEvents txtMunicipalityCode As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipalityCode As System.Windows.Forms.Label
    Friend WithEvents lblRegionName As System.Windows.Forms.Label
    Friend WithEvents cboPcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents lblProvinceName As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
