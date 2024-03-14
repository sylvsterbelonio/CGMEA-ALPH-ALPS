<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionFee
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollectionFee))
        Me.lblFeeDefault = New System.Windows.Forms.Label
        Me.lblCollectionName = New System.Windows.Forms.Label
        Me.txtCollectionName = New System.Windows.Forms.TextBox
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.txtFeeDefault = New System.Windows.Forms.TextBox
        Me.cboFeeType = New System.Windows.Forms.ComboBox
        Me.lblFeeType = New System.Windows.Forms.Label
        Me.cboRevisionId = New System.Windows.Forms.ComboBox
        Me.cboRevisionCode = New System.Windows.Forms.ComboBox
        Me.lblRevisionCode = New System.Windows.Forms.Label
        Me.txtCollectionId = New System.Windows.Forms.TextBox
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFeeDefault
        '
        Me.lblFeeDefault.BackColor = System.Drawing.SystemColors.Control
        Me.lblFeeDefault.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeeDefault.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFeeDefault.Location = New System.Drawing.Point(14, 147)
        Me.lblFeeDefault.Name = "lblFeeDefault"
        Me.lblFeeDefault.Size = New System.Drawing.Size(140, 17)
        Me.lblFeeDefault.TabIndex = 178
        Me.lblFeeDefault.Text = "Fee Default"
        '
        'lblCollectionName
        '
        Me.lblCollectionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblCollectionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline)
        Me.lblCollectionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCollectionName.Location = New System.Drawing.Point(14, 93)
        Me.lblCollectionName.Name = "lblCollectionName"
        Me.lblCollectionName.Size = New System.Drawing.Size(140, 17)
        Me.lblCollectionName.TabIndex = 174
        Me.lblCollectionName.Text = "Collection Name *"
        '
        'txtCollectionName
        '
        Me.txtCollectionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCollectionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionName.Location = New System.Drawing.Point(160, 90)
        Me.txtCollectionName.Name = "txtCollectionName"
        Me.txtCollectionName.Size = New System.Drawing.Size(248, 20)
        Me.txtCollectionName.TabIndex = 175
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
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(426, 45)
        Me.pnlToolbar.TabIndex = 180
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
        Me.tbrMainForm.Size = New System.Drawing.Size(426, 40)
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
        'txtFeeDefault
        '
        Me.txtFeeDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFeeDefault.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeeDefault.Location = New System.Drawing.Point(160, 144)
        Me.txtFeeDefault.Name = "txtFeeDefault"
        Me.txtFeeDefault.Size = New System.Drawing.Size(248, 20)
        Me.txtFeeDefault.TabIndex = 181
        Me.txtFeeDefault.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboFeeType
        '
        Me.cboFeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFeeType.DropDownWidth = 250
        Me.cboFeeType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFeeType.ItemHeight = 14
        Me.cboFeeType.Items.AddRange(New Object() {"", "FIXED", "RATE"})
        Me.cboFeeType.Location = New System.Drawing.Point(160, 116)
        Me.cboFeeType.Name = "cboFeeType"
        Me.cboFeeType.Size = New System.Drawing.Size(248, 22)
        Me.cboFeeType.TabIndex = 183
        '
        'lblFeeType
        '
        Me.lblFeeType.BackColor = System.Drawing.SystemColors.Control
        Me.lblFeeType.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFeeType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFeeType.Location = New System.Drawing.Point(14, 119)
        Me.lblFeeType.Name = "lblFeeType"
        Me.lblFeeType.Size = New System.Drawing.Size(140, 16)
        Me.lblFeeType.TabIndex = 182
        Me.lblFeeType.Text = "Fee Type *"
        '
        'cboRevisionId
        '
        Me.cboRevisionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRevisionId.FormattingEnabled = True
        Me.cboRevisionId.Location = New System.Drawing.Point(389, 62)
        Me.cboRevisionId.Name = "cboRevisionId"
        Me.cboRevisionId.Size = New System.Drawing.Size(19, 22)
        Me.cboRevisionId.TabIndex = 185
        Me.cboRevisionId.TabStop = False
        Me.cboRevisionId.Visible = False
        '
        'cboRevisionCode
        '
        Me.cboRevisionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRevisionCode.DropDownWidth = 250
        Me.cboRevisionCode.FormattingEnabled = True
        Me.cboRevisionCode.Location = New System.Drawing.Point(160, 62)
        Me.cboRevisionCode.Name = "cboRevisionCode"
        Me.cboRevisionCode.Size = New System.Drawing.Size(248, 22)
        Me.cboRevisionCode.TabIndex = 184
        '
        'lblRevisionCode
        '
        Me.lblRevisionCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblRevisionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevisionCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRevisionCode.Location = New System.Drawing.Point(14, 65)
        Me.lblRevisionCode.Name = "lblRevisionCode"
        Me.lblRevisionCode.Size = New System.Drawing.Size(140, 17)
        Me.lblRevisionCode.TabIndex = 186
        Me.lblRevisionCode.Text = "Revision Code *"
        '
        'txtCollectionId
        '
        Me.txtCollectionId.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionId.Location = New System.Drawing.Point(388, 90)
        Me.txtCollectionId.Name = "txtCollectionId"
        Me.txtCollectionId.ReadOnly = True
        Me.txtCollectionId.Size = New System.Drawing.Size(20, 20)
        Me.txtCollectionId.TabIndex = 187
        Me.txtCollectionId.Visible = False
        '
        'frmCollectionFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 181)
        Me.Controls.Add(Me.txtCollectionId)
        Me.Controls.Add(Me.lblRevisionCode)
        Me.Controls.Add(Me.cboRevisionId)
        Me.Controls.Add(Me.cboRevisionCode)
        Me.Controls.Add(Me.cboFeeType)
        Me.Controls.Add(Me.lblFeeType)
        Me.Controls.Add(Me.txtFeeDefault)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblFeeDefault)
        Me.Controls.Add(Me.lblCollectionName)
        Me.Controls.Add(Me.txtCollectionName)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCollectionFee"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection Fee"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFeeDefault As System.Windows.Forms.Label
    Friend WithEvents lblCollectionName As System.Windows.Forms.Label
    Friend WithEvents txtCollectionName As System.Windows.Forms.TextBox
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtFeeDefault As System.Windows.Forms.TextBox
    Friend WithEvents cboFeeType As System.Windows.Forms.ComboBox
    Friend WithEvents lblFeeType As System.Windows.Forms.Label
    Friend WithEvents cboRevisionId As System.Windows.Forms.ComboBox
    Friend WithEvents cboRevisionCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblRevisionCode As System.Windows.Forms.Label
    Friend WithEvents txtCollectionId As System.Windows.Forms.TextBox
End Class
