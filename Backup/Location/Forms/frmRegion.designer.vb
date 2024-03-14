<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegion))
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
        Me.txtMunicipalityCount = New System.Windows.Forms.TextBox
        Me.lblMunicipalityCount = New System.Windows.Forms.Label
        Me.txtCityCount = New System.Windows.Forms.TextBox
        Me.lblCityCount = New System.Windows.Forms.Label
        Me.lblRCode = New System.Windows.Forms.Label
        Me.txtRegionCode = New System.Windows.Forms.TextBox
        Me.txtProvinceCount = New System.Windows.Forms.TextBox
        Me.lblProvinceCount = New System.Windows.Forms.Label
        Me.lblRegionName = New System.Windows.Forms.Label
        Me.txtRegionName = New System.Windows.Forms.TextBox
        Me.txtBarangayCount = New System.Windows.Forms.TextBox
        Me.lblBarangayCount = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(350, 45)
        Me.pnlToolbar.TabIndex = 17
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
        'txtMunicipalityCount
        '
        Me.txtMunicipalityCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMunicipalityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipalityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtMunicipalityCount.Location = New System.Drawing.Point(120, 185)
        Me.txtMunicipalityCount.Name = "txtMunicipalityCount"
        Me.txtMunicipalityCount.Size = New System.Drawing.Size(200, 20)
        Me.txtMunicipalityCount.TabIndex = 4
        Me.txtMunicipalityCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMunicipalityCount
        '
        Me.lblMunicipalityCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblMunicipalityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipalityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMunicipalityCount.Location = New System.Drawing.Point(15, 185)
        Me.lblMunicipalityCount.Name = "lblMunicipalityCount"
        Me.lblMunicipalityCount.Size = New System.Drawing.Size(100, 16)
        Me.lblMunicipalityCount.TabIndex = 111
        Me.lblMunicipalityCount.Text = "Municipality Count"
        '
        'txtCityCount
        '
        Me.txtCityCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCityCount.Location = New System.Drawing.Point(120, 155)
        Me.txtCityCount.Name = "txtCityCount"
        Me.txtCityCount.Size = New System.Drawing.Size(200, 20)
        Me.txtCityCount.TabIndex = 3
        Me.txtCityCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCityCount
        '
        Me.lblCityCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblCityCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCityCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCityCount.Location = New System.Drawing.Point(15, 155)
        Me.lblCityCount.Name = "lblCityCount"
        Me.lblCityCount.Size = New System.Drawing.Size(100, 16)
        Me.lblCityCount.TabIndex = 110
        Me.lblCityCount.Text = "City Count"
        '
        'lblRCode
        '
        Me.lblRCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblRCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRCode.Location = New System.Drawing.Point(15, 95)
        Me.lblRCode.Name = "lblRCode"
        Me.lblRCode.Size = New System.Drawing.Size(100, 16)
        Me.lblRCode.TabIndex = 109
        Me.lblRCode.Text = "Region Code"
        '
        'txtRegionCode
        '
        Me.txtRegionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRegionCode.Location = New System.Drawing.Point(120, 95)
        Me.txtRegionCode.Name = "txtRegionCode"
        Me.txtRegionCode.Size = New System.Drawing.Size(200, 20)
        Me.txtRegionCode.TabIndex = 1
        '
        'txtProvinceCount
        '
        Me.txtProvinceCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtProvinceCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProvinceCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProvinceCount.Location = New System.Drawing.Point(120, 125)
        Me.txtProvinceCount.Name = "txtProvinceCount"
        Me.txtProvinceCount.Size = New System.Drawing.Size(200, 20)
        Me.txtProvinceCount.TabIndex = 2
        Me.txtProvinceCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblProvinceCount
        '
        Me.lblProvinceCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblProvinceCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProvinceCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblProvinceCount.Location = New System.Drawing.Point(15, 125)
        Me.lblProvinceCount.Name = "lblProvinceCount"
        Me.lblProvinceCount.Size = New System.Drawing.Size(100, 16)
        Me.lblProvinceCount.TabIndex = 108
        Me.lblProvinceCount.Text = "Province Count"
        '
        'lblRegionName
        '
        Me.lblRegionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRegionName.Location = New System.Drawing.Point(15, 65)
        Me.lblRegionName.Name = "lblRegionName"
        Me.lblRegionName.Size = New System.Drawing.Size(100, 16)
        Me.lblRegionName.TabIndex = 107
        Me.lblRegionName.Text = "Region Name"
        '
        'txtRegionName
        '
        Me.txtRegionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRegionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRegionName.Location = New System.Drawing.Point(120, 65)
        Me.txtRegionName.Name = "txtRegionName"
        Me.txtRegionName.Size = New System.Drawing.Size(200, 20)
        Me.txtRegionName.TabIndex = 0
        '
        'txtBarangayCount
        '
        Me.txtBarangayCount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBarangayCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarangayCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBarangayCount.Location = New System.Drawing.Point(120, 215)
        Me.txtBarangayCount.Name = "txtBarangayCount"
        Me.txtBarangayCount.Size = New System.Drawing.Size(200, 20)
        Me.txtBarangayCount.TabIndex = 5
        Me.txtBarangayCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBarangayCount
        '
        Me.lblBarangayCount.BackColor = System.Drawing.SystemColors.Control
        Me.lblBarangayCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBarangayCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblBarangayCount.Location = New System.Drawing.Point(15, 215)
        Me.lblBarangayCount.Name = "lblBarangayCount"
        Me.lblBarangayCount.Size = New System.Drawing.Size(100, 16)
        Me.lblBarangayCount.TabIndex = 113
        Me.lblBarangayCount.Text = "Barangay Count"
        '
        'frmRegion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 255)
        Me.Controls.Add(Me.lblBarangayCount)
        Me.Controls.Add(Me.txtBarangayCount)
        Me.Controls.Add(Me.txtMunicipalityCount)
        Me.Controls.Add(Me.lblMunicipalityCount)
        Me.Controls.Add(Me.txtCityCount)
        Me.Controls.Add(Me.lblCityCount)
        Me.Controls.Add(Me.lblRCode)
        Me.Controls.Add(Me.txtRegionCode)
        Me.Controls.Add(Me.txtProvinceCount)
        Me.Controls.Add(Me.lblProvinceCount)
        Me.Controls.Add(Me.lblRegionName)
        Me.Controls.Add(Me.txtRegionName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "frmRegion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Region"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtMunicipalityCount As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipalityCount As System.Windows.Forms.Label
    Friend WithEvents txtCityCount As System.Windows.Forms.TextBox
    Friend WithEvents lblCityCount As System.Windows.Forms.Label
    Friend WithEvents lblRCode As System.Windows.Forms.Label
    Friend WithEvents txtRegionCode As System.Windows.Forms.TextBox
    Friend WithEvents txtProvinceCount As System.Windows.Forms.TextBox
    Friend WithEvents lblProvinceCount As System.Windows.Forms.Label
    Friend WithEvents lblRegionName As System.Windows.Forms.Label
    Friend WithEvents txtRegionName As System.Windows.Forms.TextBox
    Friend WithEvents txtBarangayCount As System.Windows.Forms.TextBox
    Friend WithEvents lblBarangayCount As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
