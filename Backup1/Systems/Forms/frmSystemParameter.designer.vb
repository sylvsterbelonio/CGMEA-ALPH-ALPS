<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemParameter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemParameter))
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTransactionCode = New System.Windows.Forms.Label
        Me.txtTransactionCode = New System.Windows.Forms.TextBox
        Me.txtTransactionRemarks = New System.Windows.Forms.TextBox
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.lblTransactionName = New System.Windows.Forms.Label
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.txtTransactionName = New System.Windows.Forms.TextBox
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
        'lblTransactionCode
        '
        Me.lblTransactionCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTransactionCode.Location = New System.Drawing.Point(15, 95)
        Me.lblTransactionCode.Name = "lblTransactionCode"
        Me.lblTransactionCode.Size = New System.Drawing.Size(105, 16)
        Me.lblTransactionCode.TabIndex = 143
        Me.lblTransactionCode.Text = "Transaction Code"
        '
        'txtTransactionCode
        '
        Me.txtTransactionCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransactionCode.Location = New System.Drawing.Point(120, 95)
        Me.txtTransactionCode.Name = "txtTransactionCode"
        Me.txtTransactionCode.Size = New System.Drawing.Size(200, 20)
        Me.txtTransactionCode.TabIndex = 139
        '
        'txtTransactionRemarks
        '
        Me.txtTransactionRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransactionRemarks.Location = New System.Drawing.Point(120, 125)
        Me.txtTransactionRemarks.Multiline = True
        Me.txtTransactionRemarks.Name = "txtTransactionRemarks"
        Me.txtTransactionRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTransactionRemarks.Size = New System.Drawing.Size(200, 100)
        Me.txtTransactionRemarks.TabIndex = 140
        '
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 6
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Text = "Approve"
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(15, 125)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(100, 16)
        Me.lblRemarks.TabIndex = 142
        Me.lblRemarks.Text = "Remarks"
        '
        'lblTransactionName
        '
        Me.lblTransactionName.BackColor = System.Drawing.SystemColors.Control
        Me.lblTransactionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransactionName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTransactionName.Location = New System.Drawing.Point(15, 65)
        Me.lblTransactionName.Name = "lblTransactionName"
        Me.lblTransactionName.Size = New System.Drawing.Size(105, 16)
        Me.lblTransactionName.TabIndex = 141
        Me.lblTransactionName.Text = "Transaction Name"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(394, 40)
        Me.pnlToolbar.TabIndex = 137
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
        Me.tbrMainForm.Size = New System.Drawing.Size(394, 40)
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
        'txtTransactionName
        '
        Me.txtTransactionName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransactionName.Location = New System.Drawing.Point(120, 65)
        Me.txtTransactionName.Name = "txtTransactionName"
        Me.txtTransactionName.Size = New System.Drawing.Size(200, 20)
        Me.txtTransactionName.TabIndex = 138
        '
        'frmSystemParameter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 272)
        Me.Controls.Add(Me.lblTransactionCode)
        Me.Controls.Add(Me.txtTransactionCode)
        Me.Controls.Add(Me.txtTransactionRemarks)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.lblTransactionName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.txtTransactionName)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSystemParameter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Parameter"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents lblTransactionCode As System.Windows.Forms.Label
    Friend WithEvents txtTransactionCode As System.Windows.Forms.TextBox
    Friend WithEvents txtTransactionRemarks As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents lblTransactionName As System.Windows.Forms.Label
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtTransactionName As System.Windows.Forms.TextBox
End Class
