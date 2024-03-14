<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartment))
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDepartmentCode = New System.Windows.Forms.Label
        Me.txtDepartmentCode = New System.Windows.Forms.TextBox
        Me.txtDepartmentDescription = New System.Windows.Forms.TextBox
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.lblDepartmentDescription = New System.Windows.Forms.Label
        Me.lblDepartmentName = New System.Windows.Forms.Label
        Me.txtDepartmentName = New System.Windows.Forms.TextBox
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tbrMainForm.Size = New System.Drawing.Size(434, 40)
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
        'lblDepartmentCode
        '
        Me.lblDepartmentCode.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartmentCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentCode.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentCode.Location = New System.Drawing.Point(15, 95)
        Me.lblDepartmentCode.Name = "lblDepartmentCode"
        Me.lblDepartmentCode.Size = New System.Drawing.Size(105, 16)
        Me.lblDepartmentCode.TabIndex = 2
        Me.lblDepartmentCode.Text = "Department Code"
        '
        'txtDepartmentCode
        '
        Me.txtDepartmentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentCode.Location = New System.Drawing.Point(120, 95)
        Me.txtDepartmentCode.Name = "txtDepartmentCode"
        Me.txtDepartmentCode.Size = New System.Drawing.Size(300, 20)
        Me.txtDepartmentCode.TabIndex = 3
        '
        'txtDepartmentDescription
        '
        Me.txtDepartmentDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentDescription.Location = New System.Drawing.Point(120, 125)
        Me.txtDepartmentDescription.Multiline = True
        Me.txtDepartmentDescription.Name = "txtDepartmentDescription"
        Me.txtDepartmentDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDepartmentDescription.Size = New System.Drawing.Size(300, 100)
        Me.txtDepartmentDescription.TabIndex = 5
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(434, 45)
        Me.pnlToolbar.TabIndex = 127
        '
        'lblDepartmentDescription
        '
        Me.lblDepartmentDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartmentDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentDescription.Location = New System.Drawing.Point(15, 125)
        Me.lblDepartmentDescription.Name = "lblDepartmentDescription"
        Me.lblDepartmentDescription.Size = New System.Drawing.Size(100, 16)
        Me.lblDepartmentDescription.TabIndex = 4
        Me.lblDepartmentDescription.Text = "Description"
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.BackColor = System.Drawing.SystemColors.Control
        Me.lblDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentName.Location = New System.Drawing.Point(15, 65)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(105, 16)
        Me.lblDepartmentName.TabIndex = 0
        Me.lblDepartmentName.Text = "Department Name"
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentName.Location = New System.Drawing.Point(120, 65)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(300, 20)
        Me.txtDepartmentName.TabIndex = 1
        '
        'frmDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 242)
        Me.Controls.Add(Me.lblDepartmentCode)
        Me.Controls.Add(Me.txtDepartmentCode)
        Me.Controls.Add(Me.txtDepartmentDescription)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblDepartmentDescription)
        Me.Controls.Add(Me.lblDepartmentName)
        Me.Controls.Add(Me.txtDepartmentName)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmDepartment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Department"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblDepartmentCode As System.Windows.Forms.Label
    Friend WithEvents txtDepartmentCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartmentDescription As System.Windows.Forms.TextBox
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents lblDepartmentDescription As System.Windows.Forms.Label
    Friend WithEvents lblDepartmentName As System.Windows.Forms.Label
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
