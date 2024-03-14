<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSystemAccessLevel
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSystemAccessLevel))
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.tbrMainForm = New System.Windows.Forms.ToolBar()
        Me.btnAdd = New System.Windows.Forms.ToolBarButton()
        Me.btnEdit = New System.Windows.Forms.ToolBarButton()
        Me.btnDelete = New System.Windows.Forms.ToolBarButton()
        Me.btnFind = New System.Windows.Forms.ToolBarButton()
        Me.btnSave = New System.Windows.Forms.ToolBarButton()
        Me.btnCancel = New System.Windows.Forms.ToolBarButton()
        Me.btnApprove = New System.Windows.Forms.ToolBarButton()
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.grpMain = New System.Windows.Forms.GroupBox()
        Me.txtRoleName = New System.Windows.Forms.TextBox()
        Me.txtRoleDescription = New System.Windows.Forms.TextBox()
        Me.lblRoleDescription = New System.Windows.Forms.Label()
        Me.lblRoleName = New System.Windows.Forms.Label()
        Me.dgvSystemAccess = New System.Windows.Forms.DataGridView()
        Me.pnlToolbar.SuspendLayout()
        Me.grpMain.SuspendLayout()
        CType(Me.dgvSystemAccess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(894, 45)
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
        Me.tbrMainForm.Size = New System.Drawing.Size(894, 40)
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
        'grpMain
        '
        Me.grpMain.Controls.Add(Me.txtRoleName)
        Me.grpMain.Controls.Add(Me.txtRoleDescription)
        Me.grpMain.Controls.Add(Me.lblRoleDescription)
        Me.grpMain.Controls.Add(Me.lblRoleName)
        Me.grpMain.Location = New System.Drawing.Point(10, 50)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(875, 85)
        Me.grpMain.TabIndex = 17
        Me.grpMain.TabStop = False
        '
        'txtRoleName
        '
        Me.txtRoleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoleName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRoleName.Location = New System.Drawing.Point(100, 25)
        Me.txtRoleName.Name = "txtRoleName"
        Me.txtRoleName.Size = New System.Drawing.Size(760, 20)
        Me.txtRoleName.TabIndex = 1
        '
        'txtRoleDescription
        '
        Me.txtRoleDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRoleDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoleDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRoleDescription.Location = New System.Drawing.Point(100, 55)
        Me.txtRoleDescription.Name = "txtRoleDescription"
        Me.txtRoleDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRoleDescription.Size = New System.Drawing.Size(760, 20)
        Me.txtRoleDescription.TabIndex = 2
        '
        'lblRoleDescription
        '
        Me.lblRoleDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoleDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRoleDescription.Location = New System.Drawing.Point(10, 55)
        Me.lblRoleDescription.Name = "lblRoleDescription"
        Me.lblRoleDescription.Size = New System.Drawing.Size(90, 16)
        Me.lblRoleDescription.TabIndex = 7
        Me.lblRoleDescription.Text = "Role Description"
        '
        'lblRoleName
        '
        Me.lblRoleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRoleName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRoleName.Location = New System.Drawing.Point(10, 25)
        Me.lblRoleName.Name = "lblRoleName"
        Me.lblRoleName.Size = New System.Drawing.Size(90, 16)
        Me.lblRoleName.TabIndex = 6
        Me.lblRoleName.Text = "Role Name *"
        '
        'dgvSystemAccess
        '
        Me.dgvSystemAccess.AllowUserToAddRows = False
        Me.dgvSystemAccess.AllowUserToDeleteRows = False
        Me.dgvSystemAccess.AllowUserToResizeColumns = False
        Me.dgvSystemAccess.AllowUserToResizeRows = False
        Me.dgvSystemAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSystemAccess.Location = New System.Drawing.Point(10, 145)
        Me.dgvSystemAccess.Name = "dgvSystemAccess"
        Me.dgvSystemAccess.Size = New System.Drawing.Size(875, 370)
        Me.dgvSystemAccess.TabIndex = 41
        '
        'frmSystemAccessLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 522)
        Me.Controls.Add(Me.dgvSystemAccess)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSystemAccessLevel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Access Level"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.dgvSystemAccess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents grpMain As System.Windows.Forms.GroupBox
    Friend WithEvents txtRoleName As System.Windows.Forms.TextBox
    Friend WithEvents txtRoleDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblRoleDescription As System.Windows.Forms.Label
    Friend WithEvents lblRoleName As System.Windows.Forms.Label
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents dgvSystemAccess As System.Windows.Forms.DataGridView
End Class
