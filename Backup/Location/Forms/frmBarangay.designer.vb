<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBarangay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBarangay))
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.cboMunicipality = New System.Windows.Forms.ComboBox
        Me.lblMunicipalityName = New System.Windows.Forms.Label
        Me.cboProvince = New System.Windows.Forms.ComboBox
        Me.lblBrgyName = New System.Windows.Forms.Label
        Me.txtBrgyName = New System.Windows.Forms.TextBox
        Me.txtBrgyCode = New System.Windows.Forms.TextBox
        Me.lblBrgyCode = New System.Windows.Forms.Label
        Me.lblProvinceName = New System.Windows.Forms.Label
        Me.cboMcode = New System.Windows.Forms.ComboBox
        Me.cboPcode = New System.Windows.Forms.ComboBox
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.lblRegionName = New System.Windows.Forms.Label
        Me.txtBarangayIndex = New System.Windows.Forms.TextBox
        Me.lblBarangayIndex = New System.Windows.Forms.Label
        Me.txtDistrictIndex = New System.Windows.Forms.TextBox
        Me.lblDistrictIndex = New System.Windows.Forms.Label
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
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(350, 45)
        Me.pnlToolbar.TabIndex = 140
        '
        'cboMunicipality
        '
        Me.cboMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipality.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboMunicipality.FormattingEnabled = True
        Me.cboMunicipality.Location = New System.Drawing.Point(125, 125)
        Me.cboMunicipality.Name = "cboMunicipality"
        Me.cboMunicipality.Size = New System.Drawing.Size(200, 22)
        Me.cboMunicipality.TabIndex = 7
        '
        'lblMunicipalityName
        '
        Me.lblMunicipalityName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMunicipalityName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipalityName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipalityName.Location = New System.Drawing.Point(15, 125)
        Me.lblMunicipalityName.Name = "lblMunicipalityName"
        Me.lblMunicipalityName.Size = New System.Drawing.Size(110, 16)
        Me.lblMunicipalityName.TabIndex = 6
        Me.lblMunicipalityName.Text = "Municipality Name"
        '
        'cboProvince
        '
        Me.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProvince.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboProvince.FormattingEnabled = True
        Me.cboProvince.Location = New System.Drawing.Point(125, 95)
        Me.cboProvince.Name = "cboProvince"
        Me.cboProvince.Size = New System.Drawing.Size(200, 22)
        Me.cboProvince.TabIndex = 4
        '
        'lblBrgyName
        '
        Me.lblBrgyName.BackColor = System.Drawing.SystemColors.Control
        Me.lblBrgyName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrgyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBrgyName.Location = New System.Drawing.Point(15, 155)
        Me.lblBrgyName.Name = "lblBrgyName"
        Me.lblBrgyName.Size = New System.Drawing.Size(110, 16)
        Me.lblBrgyName.TabIndex = 9
        Me.lblBrgyName.Text = "Barangay Name"
        '
        'txtBrgyName
        '
        Me.txtBrgyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrgyName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrgyName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBrgyName.Location = New System.Drawing.Point(125, 155)
        Me.txtBrgyName.Name = "txtBrgyName"
        Me.txtBrgyName.Size = New System.Drawing.Size(200, 20)
        Me.txtBrgyName.TabIndex = 10
        '
        'txtBrgyCode
        '
        Me.txtBrgyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBrgyCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBrgyCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBrgyCode.Location = New System.Drawing.Point(125, 185)
        Me.txtBrgyCode.Name = "txtBrgyCode"
        Me.txtBrgyCode.Size = New System.Drawing.Size(200, 20)
        Me.txtBrgyCode.TabIndex = 12
        '
        'lblBrgyCode
        '
        Me.lblBrgyCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblBrgyCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrgyCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBrgyCode.Location = New System.Drawing.Point(15, 185)
        Me.lblBrgyCode.Name = "lblBrgyCode"
        Me.lblBrgyCode.Size = New System.Drawing.Size(110, 16)
        Me.lblBrgyCode.TabIndex = 11
        Me.lblBrgyCode.Text = "Rural Code"
        '
        'lblProvinceName
        '
        Me.lblProvinceName.BackColor = System.Drawing.SystemColors.Control
        Me.lblProvinceName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceName.Location = New System.Drawing.Point(15, 95)
        Me.lblProvinceName.Name = "lblProvinceName"
        Me.lblProvinceName.Size = New System.Drawing.Size(110, 16)
        Me.lblProvinceName.TabIndex = 3
        Me.lblProvinceName.Text = "Province Name"
        '
        'cboMcode
        '
        Me.cboMcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboMcode.FormattingEnabled = True
        Me.cboMcode.Location = New System.Drawing.Point(305, 125)
        Me.cboMcode.Name = "cboMcode"
        Me.cboMcode.Size = New System.Drawing.Size(20, 22)
        Me.cboMcode.TabIndex = 8
        Me.cboMcode.TabStop = False
        Me.cboMcode.Visible = False
        '
        'cboPcode
        '
        Me.cboPcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboPcode.FormattingEnabled = True
        Me.cboPcode.Location = New System.Drawing.Point(305, 95)
        Me.cboPcode.Name = "cboPcode"
        Me.cboPcode.Size = New System.Drawing.Size(20, 22)
        Me.cboPcode.TabIndex = 5
        Me.cboPcode.TabStop = False
        Me.cboPcode.Visible = False
        '
        'cboRcode
        '
        Me.cboRcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboRcode.FormattingEnabled = True
        Me.cboRcode.Location = New System.Drawing.Point(305, 65)
        Me.cboRcode.Name = "cboRcode"
        Me.cboRcode.Size = New System.Drawing.Size(20, 22)
        Me.cboRcode.TabIndex = 2
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
        Me.cboRegion.TabIndex = 1
        '
        'lblRegionName
        '
        Me.lblRegionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegionName.Location = New System.Drawing.Point(15, 65)
        Me.lblRegionName.Name = "lblRegionName"
        Me.lblRegionName.Size = New System.Drawing.Size(110, 16)
        Me.lblRegionName.TabIndex = 0
        Me.lblRegionName.Text = "Region Name"
        '
        'txtBarangayIndex
        '
        Me.txtBarangayIndex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarangayIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBarangayIndex.Location = New System.Drawing.Point(125, 250)
        Me.txtBarangayIndex.Name = "txtBarangayIndex"
        Me.txtBarangayIndex.Size = New System.Drawing.Size(200, 20)
        Me.txtBarangayIndex.TabIndex = 16
        '
        'lblBarangayIndex
        '
        Me.lblBarangayIndex.BackColor = System.Drawing.SystemColors.Control
        Me.lblBarangayIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarangayIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangayIndex.Location = New System.Drawing.Point(15, 250)
        Me.lblBarangayIndex.Name = "lblBarangayIndex"
        Me.lblBarangayIndex.Size = New System.Drawing.Size(110, 16)
        Me.lblBarangayIndex.TabIndex = 15
        Me.lblBarangayIndex.Text = "Barangay Index"
        '
        'txtDistrictIndex
        '
        Me.txtDistrictIndex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrictIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrictIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDistrictIndex.Location = New System.Drawing.Point(125, 215)
        Me.txtDistrictIndex.Name = "txtDistrictIndex"
        Me.txtDistrictIndex.Size = New System.Drawing.Size(200, 20)
        Me.txtDistrictIndex.TabIndex = 14
        '
        'lblDistrictIndex
        '
        Me.lblDistrictIndex.BackColor = System.Drawing.SystemColors.Control
        Me.lblDistrictIndex.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrictIndex.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDistrictIndex.Location = New System.Drawing.Point(15, 215)
        Me.lblDistrictIndex.Name = "lblDistrictIndex"
        Me.lblDistrictIndex.Size = New System.Drawing.Size(110, 30)
        Me.lblDistrictIndex.TabIndex = 13
        Me.lblDistrictIndex.Text = "District / Municipality Index (for PIN)"
        '
        'frmBarangay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 288)
        Me.Controls.Add(Me.txtDistrictIndex)
        Me.Controls.Add(Me.lblDistrictIndex)
        Me.Controls.Add(Me.txtBarangayIndex)
        Me.Controls.Add(Me.lblBarangayIndex)
        Me.Controls.Add(Me.cboRcode)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.lblRegionName)
        Me.Controls.Add(Me.cboMcode)
        Me.Controls.Add(Me.cboPcode)
        Me.Controls.Add(Me.cboMunicipality)
        Me.Controls.Add(Me.lblMunicipalityName)
        Me.Controls.Add(Me.cboProvince)
        Me.Controls.Add(Me.lblBrgyName)
        Me.Controls.Add(Me.txtBrgyName)
        Me.Controls.Add(Me.txtBrgyCode)
        Me.Controls.Add(Me.lblBrgyCode)
        Me.Controls.Add(Me.lblProvinceName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmBarangay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barangay"
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
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents cboMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents lblMunicipalityName As System.Windows.Forms.Label
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents lblBrgyName As System.Windows.Forms.Label
    Friend WithEvents txtBrgyName As System.Windows.Forms.TextBox
    Friend WithEvents txtBrgyCode As System.Windows.Forms.TextBox
    Friend WithEvents lblBrgyCode As System.Windows.Forms.Label
    Friend WithEvents lblProvinceName As System.Windows.Forms.Label
    Friend WithEvents cboMcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboPcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents lblRegionName As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtBarangayIndex As System.Windows.Forms.TextBox
    Friend WithEvents lblBarangayIndex As System.Windows.Forms.Label
    Friend WithEvents txtDistrictIndex As System.Windows.Forms.TextBox
    Friend WithEvents lblDistrictIndex As System.Windows.Forms.Label
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
