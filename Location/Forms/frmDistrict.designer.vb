<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDistrict
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDistrict))
        Me.cboPcode = New System.Windows.Forms.ComboBox
        Me.cboProvince = New System.Windows.Forms.ComboBox
        Me.lblProvinceName = New System.Windows.Forms.Label
        Me.cboRcode = New System.Windows.Forms.ComboBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDistrictName = New System.Windows.Forms.Label
        Me.txtDistrictName = New System.Windows.Forms.TextBox
        Me.txtDistrict = New System.Windows.Forms.TextBox
        Me.lblDistrict = New System.Windows.Forms.Label
        Me.lblRegionName = New System.Windows.Forms.Label
        Me.txtDistrictCode = New System.Windows.Forms.TextBox
        Me.lblDistrictCode = New System.Windows.Forms.Label
        Me.txtBarangayCount = New System.Windows.Forms.TextBox
        Me.lblBarangayCount = New System.Windows.Forms.Label
        Me.cboMcode = New System.Windows.Forms.ComboBox
        Me.cboMunicipality = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
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
        Me.lblProvinceName.TabIndex = 166
        Me.lblProvinceName.Text = "Province Name"
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
        Me.pnlToolbar.TabIndex = 160
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
        'lblDistrictName
        '
        Me.lblDistrictName.BackColor = System.Drawing.SystemColors.Control
        Me.lblDistrictName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrictName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDistrictName.Location = New System.Drawing.Point(15, 125)
        Me.lblDistrictName.Name = "lblDistrictName"
        Me.lblDistrictName.Size = New System.Drawing.Size(110, 16)
        Me.lblDistrictName.TabIndex = 163
        Me.lblDistrictName.Text = "District Name"
        '
        'txtDistrictName
        '
        Me.txtDistrictName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrictName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrictName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDistrictName.Location = New System.Drawing.Point(125, 125)
        Me.txtDistrictName.Name = "txtDistrictName"
        Me.txtDistrictName.Size = New System.Drawing.Size(200, 20)
        Me.txtDistrictName.TabIndex = 4
        '
        'txtDistrict
        '
        Me.txtDistrict.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrict.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrict.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDistrict.Location = New System.Drawing.Point(125, 155)
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.Size = New System.Drawing.Size(200, 20)
        Me.txtDistrict.TabIndex = 5
        '
        'lblDistrict
        '
        Me.lblDistrict.BackColor = System.Drawing.SystemColors.Control
        Me.lblDistrict.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrict.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDistrict.Location = New System.Drawing.Point(15, 155)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(110, 16)
        Me.lblDistrict.TabIndex = 162
        Me.lblDistrict.Text = "District"
        '
        'lblRegionName
        '
        Me.lblRegionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegionName.Location = New System.Drawing.Point(15, 65)
        Me.lblRegionName.Name = "lblRegionName"
        Me.lblRegionName.Size = New System.Drawing.Size(110, 16)
        Me.lblRegionName.TabIndex = 161
        Me.lblRegionName.Text = "Region Name"
        '
        'txtDistrictCode
        '
        Me.txtDistrictCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDistrictCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrictCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDistrictCode.Location = New System.Drawing.Point(125, 185)
        Me.txtDistrictCode.Name = "txtDistrictCode"
        Me.txtDistrictCode.Size = New System.Drawing.Size(200, 20)
        Me.txtDistrictCode.TabIndex = 6
        '
        'lblDistrictCode
        '
        Me.lblDistrictCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblDistrictCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrictCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDistrictCode.Location = New System.Drawing.Point(15, 185)
        Me.lblDistrictCode.Name = "lblDistrictCode"
        Me.lblDistrictCode.Size = New System.Drawing.Size(110, 16)
        Me.lblDistrictCode.TabIndex = 164
        Me.lblDistrictCode.Text = "District Code"
        '
        'txtBarangayCount
        '
        Me.txtBarangayCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarangayCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBarangayCount.Location = New System.Drawing.Point(125, 245)
        Me.txtBarangayCount.Name = "txtBarangayCount"
        Me.txtBarangayCount.Size = New System.Drawing.Size(200, 20)
        Me.txtBarangayCount.TabIndex = 9
        Me.txtBarangayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBarangayCount
        '
        Me.lblBarangayCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblBarangayCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarangayCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangayCount.Location = New System.Drawing.Point(15, 245)
        Me.lblBarangayCount.Name = "lblBarangayCount"
        Me.lblBarangayCount.Size = New System.Drawing.Size(110, 16)
        Me.lblBarangayCount.TabIndex = 168
        Me.lblBarangayCount.Text = "Barangay Count"
        '
        'cboMcode
        '
        Me.cboMcode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMcode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboMcode.FormattingEnabled = True
        Me.cboMcode.Location = New System.Drawing.Point(305, 215)
        Me.cboMcode.Name = "cboMcode"
        Me.cboMcode.Size = New System.Drawing.Size(20, 22)
        Me.cboMcode.TabIndex = 8
        Me.cboMcode.TabStop = False
        Me.cboMcode.Visible = False
        '
        'cboMunicipality
        '
        Me.cboMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMunicipality.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cboMunicipality.FormattingEnabled = True
        Me.cboMunicipality.Location = New System.Drawing.Point(125, 215)
        Me.cboMunicipality.Name = "cboMunicipality"
        Me.cboMunicipality.Size = New System.Drawing.Size(200, 22)
        Me.cboMunicipality.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 171
        Me.Label1.Text = "Municipality Name"
        '
        'frmDistrict
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 275)
        Me.Controls.Add(Me.cboMcode)
        Me.Controls.Add(Me.cboMunicipality)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBarangayCount)
        Me.Controls.Add(Me.lblBarangayCount)
        Me.Controls.Add(Me.cboPcode)
        Me.Controls.Add(Me.cboProvince)
        Me.Controls.Add(Me.lblProvinceName)
        Me.Controls.Add(Me.cboRcode)
        Me.Controls.Add(Me.cboRegion)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblDistrictName)
        Me.Controls.Add(Me.txtDistrictName)
        Me.Controls.Add(Me.txtDistrict)
        Me.Controls.Add(Me.lblDistrict)
        Me.Controls.Add(Me.lblRegionName)
        Me.Controls.Add(Me.txtDistrictCode)
        Me.Controls.Add(Me.lblDistrictCode)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDistrict"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "District"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboPcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboProvince As System.Windows.Forms.ComboBox
    Friend WithEvents lblProvinceName As System.Windows.Forms.Label
    Friend WithEvents cboRcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblDistrictName As System.Windows.Forms.Label
    Friend WithEvents txtDistrictName As System.Windows.Forms.TextBox
    Friend WithEvents txtDistrict As System.Windows.Forms.TextBox
    Friend WithEvents lblDistrict As System.Windows.Forms.Label
    Friend WithEvents lblRegionName As System.Windows.Forms.Label
    Friend WithEvents txtDistrictCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDistrictCode As System.Windows.Forms.Label
    Friend WithEvents txtBarangayCount As System.Windows.Forms.TextBox
    Friend WithEvents lblBarangayCount As System.Windows.Forms.Label
    Friend WithEvents cboMcode As System.Windows.Forms.ComboBox
    Friend WithEvents cboMunicipality As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
