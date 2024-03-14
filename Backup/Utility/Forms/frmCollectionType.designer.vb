<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCollectionType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCollectionType))
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
        Me.lblDescription = New System.Windows.Forms.Label
        Me.txtCollectionDescription = New System.Windows.Forms.TextBox
        Me.lblCollectionName = New System.Windows.Forms.Label
        Me.txtCollectionName = New System.Windows.Forms.TextBox
        Me.txtFeeDescription = New System.Windows.Forms.TextBox
        Me.lblCollectionCode = New System.Windows.Forms.Label
        Me.txtCollectionCode = New System.Windows.Forms.TextBox
        Me.chkLoanRequired = New System.Windows.Forms.CheckBox
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
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
        Me.pnlToolbar.Size = New System.Drawing.Size(576, 45)
        Me.pnlToolbar.TabIndex = 173
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
        Me.tbrMainForm.Size = New System.Drawing.Size(576, 40)
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
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDescription.Location = New System.Drawing.Point(15, 148)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(140, 16)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description"
        '
        'txtCollectionDescription
        '
        Me.txtCollectionDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCollectionDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionDescription.Location = New System.Drawing.Point(160, 145)
        Me.txtCollectionDescription.Multiline = True
        Me.txtCollectionDescription.Name = "txtCollectionDescription"
        Me.txtCollectionDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCollectionDescription.Size = New System.Drawing.Size(400, 60)
        Me.txtCollectionDescription.TabIndex = 3
        '
        'lblCollectionName
        '
        Me.lblCollectionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblCollectionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCollectionName.Location = New System.Drawing.Point(15, 65)
        Me.lblCollectionName.Name = "lblCollectionName"
        Me.lblCollectionName.Size = New System.Drawing.Size(140, 16)
        Me.lblCollectionName.TabIndex = 4
        Me.lblCollectionName.Text = "Collection Name *"
        '
        'txtCollectionName
        '
        Me.txtCollectionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCollectionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionName.Location = New System.Drawing.Point(160, 65)
        Me.txtCollectionName.Name = "txtCollectionName"
        Me.txtCollectionName.Size = New System.Drawing.Size(400, 20)
        Me.txtCollectionName.TabIndex = 0
        '
        'txtFeeDescription
        '
        Me.txtFeeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFeeDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFeeDescription.Location = New System.Drawing.Point(160, 125)
        Me.txtFeeDescription.Multiline = True
        Me.txtFeeDescription.Name = "txtFeeDescription"
        Me.txtFeeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFeeDescription.Size = New System.Drawing.Size(400, 60)
        Me.txtFeeDescription.TabIndex = 5
        '
        'lblCollectionCode
        '
        Me.lblCollectionCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblCollectionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollectionCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCollectionCode.Location = New System.Drawing.Point(15, 95)
        Me.lblCollectionCode.Name = "lblCollectionCode"
        Me.lblCollectionCode.Size = New System.Drawing.Size(140, 16)
        Me.lblCollectionCode.TabIndex = 5
        Me.lblCollectionCode.Text = "Collection Code *"
        '
        'txtCollectionCode
        '
        Me.txtCollectionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCollectionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCollectionCode.Location = New System.Drawing.Point(160, 95)
        Me.txtCollectionCode.Name = "txtCollectionCode"
        Me.txtCollectionCode.Size = New System.Drawing.Size(400, 20)
        Me.txtCollectionCode.TabIndex = 1
        '
        'chkLoanRequired
        '
        Me.chkLoanRequired.AutoSize = True
        Me.chkLoanRequired.Location = New System.Drawing.Point(160, 121)
        Me.chkLoanRequired.Name = "chkLoanRequired"
        Me.chkLoanRequired.Size = New System.Drawing.Size(96, 18)
        Me.chkLoanRequired.TabIndex = 2
        Me.chkLoanRequired.Text = "Loan Required"
        Me.chkLoanRequired.UseVisualStyleBackColor = True
        '
        'frmCollectionType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 222)
        Me.Controls.Add(Me.chkLoanRequired)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.txtCollectionDescription)
        Me.Controls.Add(Me.lblCollectionCode)
        Me.Controls.Add(Me.txtCollectionCode)
        Me.Controls.Add(Me.lblCollectionName)
        Me.Controls.Add(Me.txtCollectionName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmCollectionType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection Type"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents txtCollectionDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblCollectionName As System.Windows.Forms.Label
    Friend WithEvents txtCollectionName As System.Windows.Forms.TextBox
    Friend WithEvents txtFeeDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblCollectionCode As System.Windows.Forms.Label
    Friend WithEvents txtCollectionCode As System.Windows.Forms.TextBox
    Friend WithEvents chkLoanRequired As System.Windows.Forms.CheckBox
End Class
