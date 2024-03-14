<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCountry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCountry))
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
        Me.lblSovereign = New System.Windows.Forms.Label
        Me.txtSovereign = New System.Windows.Forms.TextBox
        Me.lblFIPS = New System.Windows.Forms.Label
        Me.txtFIPS = New System.Windows.Forms.TextBox
        Me.lblGMI = New System.Windows.Forms.Label
        Me.txtGMI = New System.Windows.Forms.TextBox
        Me.txtAreaSQKM = New System.Windows.Forms.TextBox
        Me.lblAreaSQKM = New System.Windows.Forms.Label
        Me.txtPopulation = New System.Windows.Forms.TextBox
        Me.lblPopulation = New System.Windows.Forms.Label
        Me.lblCountryName = New System.Windows.Forms.Label
        Me.txtCountryName = New System.Windows.Forms.TextBox
        Me.txtCurrencyType = New System.Windows.Forms.TextBox
        Me.lblCurrencyType = New System.Windows.Forms.Label
        Me.txtAreaSQMI = New System.Windows.Forms.TextBox
        Me.lblAreaSQMI = New System.Windows.Forms.Label
        Me.txtCurrencyCode = New System.Windows.Forms.TextBox
        Me.lblCurrencyCode = New System.Windows.Forms.Label
        Me.btnFlag = New System.Windows.Forms.Button
        Me.cmenuFlag = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmnuClear = New System.Windows.Forms.ToolStripMenuItem
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblFlag = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.cmenuFlag.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(535, 45)
        Me.pnlToolbar.TabIndex = 16
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
        Me.tbrMainForm.Size = New System.Drawing.Size(535, 40)
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
        'lblSovereign
        '
        Me.lblSovereign.BackColor = System.Drawing.SystemColors.Control
        Me.lblSovereign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSovereign.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSovereign.Location = New System.Drawing.Point(15, 155)
        Me.lblSovereign.Name = "lblSovereign"
        Me.lblSovereign.Size = New System.Drawing.Size(90, 16)
        Me.lblSovereign.TabIndex = 94
        Me.lblSovereign.Text = "Sovereign"
        '
        'txtSovereign
        '
        Me.txtSovereign.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSovereign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSovereign.Location = New System.Drawing.Point(105, 155)
        Me.txtSovereign.Name = "txtSovereign"
        Me.txtSovereign.Size = New System.Drawing.Size(150, 20)
        Me.txtSovereign.TabIndex = 5
        '
        'lblFIPS
        '
        Me.lblFIPS.BackColor = System.Drawing.SystemColors.Control
        Me.lblFIPS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFIPS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFIPS.Location = New System.Drawing.Point(15, 125)
        Me.lblFIPS.Name = "lblFIPS"
        Me.lblFIPS.Size = New System.Drawing.Size(90, 16)
        Me.lblFIPS.TabIndex = 93
        Me.lblFIPS.Text = "FIPS"
        '
        'txtFIPS
        '
        Me.txtFIPS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFIPS.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIPS.Location = New System.Drawing.Point(105, 125)
        Me.txtFIPS.Name = "txtFIPS"
        Me.txtFIPS.Size = New System.Drawing.Size(150, 20)
        Me.txtFIPS.TabIndex = 4
        '
        'lblGMI
        '
        Me.lblGMI.BackColor = System.Drawing.SystemColors.Control
        Me.lblGMI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGMI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGMI.Location = New System.Drawing.Point(15, 95)
        Me.lblGMI.Name = "lblGMI"
        Me.lblGMI.Size = New System.Drawing.Size(90, 16)
        Me.lblGMI.TabIndex = 92
        Me.lblGMI.Text = "GMI"
        '
        'txtGMI
        '
        Me.txtGMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGMI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGMI.Location = New System.Drawing.Point(105, 95)
        Me.txtGMI.Name = "txtGMI"
        Me.txtGMI.Size = New System.Drawing.Size(150, 20)
        Me.txtGMI.TabIndex = 1
        '
        'txtAreaSQKM
        '
        Me.txtAreaSQKM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAreaSQKM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaSQKM.Location = New System.Drawing.Point(365, 185)
        Me.txtAreaSQKM.Name = "txtAreaSQKM"
        Me.txtAreaSQKM.Size = New System.Drawing.Size(150, 20)
        Me.txtAreaSQKM.TabIndex = 8
        Me.txtAreaSQKM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAreaSQKM
        '
        Me.lblAreaSQKM.BackColor = System.Drawing.SystemColors.Control
        Me.lblAreaSQKM.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreaSQKM.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAreaSQKM.Location = New System.Drawing.Point(275, 185)
        Me.lblAreaSQKM.Name = "lblAreaSQKM"
        Me.lblAreaSQKM.Size = New System.Drawing.Size(90, 16)
        Me.lblAreaSQKM.TabIndex = 91
        Me.lblAreaSQKM.Text = "Area (sqkm)"
        '
        'txtPopulation
        '
        Me.txtPopulation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPopulation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPopulation.Location = New System.Drawing.Point(365, 155)
        Me.txtPopulation.Name = "txtPopulation"
        Me.txtPopulation.Size = New System.Drawing.Size(150, 20)
        Me.txtPopulation.TabIndex = 6
        Me.txtPopulation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPopulation
        '
        Me.lblPopulation.BackColor = System.Drawing.SystemColors.Control
        Me.lblPopulation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopulation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPopulation.Location = New System.Drawing.Point(275, 155)
        Me.lblPopulation.Name = "lblPopulation"
        Me.lblPopulation.Size = New System.Drawing.Size(90, 16)
        Me.lblPopulation.TabIndex = 90
        Me.lblPopulation.Text = "Population"
        '
        'lblCountryName
        '
        Me.lblCountryName.BackColor = System.Drawing.SystemColors.Control
        Me.lblCountryName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountryName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCountryName.Location = New System.Drawing.Point(15, 65)
        Me.lblCountryName.Name = "lblCountryName"
        Me.lblCountryName.Size = New System.Drawing.Size(90, 16)
        Me.lblCountryName.TabIndex = 89
        Me.lblCountryName.Text = "Country Name"
        '
        'txtCountryName
        '
        Me.txtCountryName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountryName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountryName.Location = New System.Drawing.Point(105, 65)
        Me.txtCountryName.Name = "txtCountryName"
        Me.txtCountryName.Size = New System.Drawing.Size(150, 20)
        Me.txtCountryName.TabIndex = 0
        '
        'txtCurrencyType
        '
        Me.txtCurrencyType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrencyType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrencyType.Location = New System.Drawing.Point(105, 215)
        Me.txtCurrencyType.Name = "txtCurrencyType"
        Me.txtCurrencyType.Size = New System.Drawing.Size(150, 20)
        Me.txtCurrencyType.TabIndex = 9
        '
        'lblCurrencyType
        '
        Me.lblCurrencyType.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrencyType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrencyType.Location = New System.Drawing.Point(15, 215)
        Me.lblCurrencyType.Name = "lblCurrencyType"
        Me.lblCurrencyType.Size = New System.Drawing.Size(90, 16)
        Me.lblCurrencyType.TabIndex = 98
        Me.lblCurrencyType.Text = "Currency Type"
        '
        'txtAreaSQMI
        '
        Me.txtAreaSQMI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAreaSQMI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAreaSQMI.Location = New System.Drawing.Point(105, 185)
        Me.txtAreaSQMI.Name = "txtAreaSQMI"
        Me.txtAreaSQMI.Size = New System.Drawing.Size(150, 20)
        Me.txtAreaSQMI.TabIndex = 7
        Me.txtAreaSQMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAreaSQMI
        '
        Me.lblAreaSQMI.BackColor = System.Drawing.SystemColors.Control
        Me.lblAreaSQMI.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAreaSQMI.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAreaSQMI.Location = New System.Drawing.Point(15, 185)
        Me.lblAreaSQMI.Name = "lblAreaSQMI"
        Me.lblAreaSQMI.Size = New System.Drawing.Size(90, 16)
        Me.lblAreaSQMI.TabIndex = 97
        Me.lblAreaSQMI.Text = "Area (sqmi)"
        '
        'txtCurrencyCode
        '
        Me.txtCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrencyCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurrencyCode.Location = New System.Drawing.Point(365, 212)
        Me.txtCurrencyCode.Name = "txtCurrencyCode"
        Me.txtCurrencyCode.Size = New System.Drawing.Size(150, 20)
        Me.txtCurrencyCode.TabIndex = 10
        '
        'lblCurrencyCode
        '
        Me.lblCurrencyCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblCurrencyCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCurrencyCode.Location = New System.Drawing.Point(275, 212)
        Me.lblCurrencyCode.Name = "lblCurrencyCode"
        Me.lblCurrencyCode.Size = New System.Drawing.Size(90, 16)
        Me.lblCurrencyCode.TabIndex = 101
        Me.lblCurrencyCode.Text = "Currency Code"
        '
        'btnFlag
        '
        Me.btnFlag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFlag.ContextMenuStrip = Me.cmenuFlag
        Me.btnFlag.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFlag.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnFlag.Location = New System.Drawing.Point(365, 65)
        Me.btnFlag.Name = "btnFlag"
        Me.btnFlag.Size = New System.Drawing.Size(150, 80)
        Me.btnFlag.TabIndex = 3
        Me.btnFlag.UseVisualStyleBackColor = True
        '
        'cmenuFlag
        '
        Me.cmenuFlag.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmnuClear})
        Me.cmenuFlag.Name = "cmenuPhoto"
        Me.cmenuFlag.Size = New System.Drawing.Size(127, 26)
        '
        'cmnuClear
        '
        Me.cmnuClear.Name = "cmnuClear"
        Me.cmnuClear.Size = New System.Drawing.Size(126, 22)
        Me.cmnuClear.Text = "&Clear Flag"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(275, 95)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.ReadOnly = True
        Me.txtFileName.Size = New System.Drawing.Size(20, 20)
        Me.txtFileName.TabIndex = 2
        Me.txtFileName.TabStop = False
        Me.txtFileName.Visible = False
        '
        'lblFlag
        '
        Me.lblFlag.BackColor = System.Drawing.SystemColors.Control
        Me.lblFlag.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFlag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFlag.Location = New System.Drawing.Point(275, 65)
        Me.lblFlag.Name = "lblFlag"
        Me.lblFlag.Size = New System.Drawing.Size(90, 16)
        Me.lblFlag.TabIndex = 104
        Me.lblFlag.Text = "National Flag"
        '
        'frmCountry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 252)
        Me.Controls.Add(Me.btnFlag)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.lblFlag)
        Me.Controls.Add(Me.txtCurrencyType)
        Me.Controls.Add(Me.txtCurrencyCode)
        Me.Controls.Add(Me.lblGMI)
        Me.Controls.Add(Me.lblSovereign)
        Me.Controls.Add(Me.lblCurrencyCode)
        Me.Controls.Add(Me.lblFIPS)
        Me.Controls.Add(Me.lblCurrencyType)
        Me.Controls.Add(Me.txtAreaSQMI)
        Me.Controls.Add(Me.txtFIPS)
        Me.Controls.Add(Me.lblAreaSQMI)
        Me.Controls.Add(Me.txtSovereign)
        Me.Controls.Add(Me.txtGMI)
        Me.Controls.Add(Me.lblCountryName)
        Me.Controls.Add(Me.txtCountryName)
        Me.Controls.Add(Me.txtAreaSQKM)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblAreaSQKM)
        Me.Controls.Add(Me.txtPopulation)
        Me.Controls.Add(Me.lblPopulation)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCountry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Country"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.cmenuFlag.ResumeLayout(False)
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
    Friend WithEvents lblSovereign As System.Windows.Forms.Label
    Friend WithEvents txtSovereign As System.Windows.Forms.TextBox
    Friend WithEvents lblFIPS As System.Windows.Forms.Label
    Friend WithEvents txtFIPS As System.Windows.Forms.TextBox
    Friend WithEvents lblGMI As System.Windows.Forms.Label
    Friend WithEvents txtGMI As System.Windows.Forms.TextBox
    Friend WithEvents txtAreaSQKM As System.Windows.Forms.TextBox
    Friend WithEvents lblAreaSQKM As System.Windows.Forms.Label
    Friend WithEvents txtPopulation As System.Windows.Forms.TextBox
    Friend WithEvents lblPopulation As System.Windows.Forms.Label
    Friend WithEvents lblCountryName As System.Windows.Forms.Label
    Friend WithEvents txtCountryName As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrencyType As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrencyType As System.Windows.Forms.Label
    Friend WithEvents txtAreaSQMI As System.Windows.Forms.TextBox
    Friend WithEvents lblAreaSQMI As System.Windows.Forms.Label
    Friend WithEvents txtCurrencyCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCurrencyCode As System.Windows.Forms.Label
    Friend WithEvents btnFlag As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblFlag As System.Windows.Forms.Label
    Friend WithEvents cmenuFlag As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmnuClear As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
