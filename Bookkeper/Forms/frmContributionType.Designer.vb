<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContributionType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContributionType))
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.lblMinAmount = New System.Windows.Forms.Label
        Me.txtConTypeDescription = New System.Windows.Forms.TextBox
        Me.lblConTypeDescription = New System.Windows.Forms.Label
        Me.lblConTypeName = New System.Windows.Forms.Label
        Me.txtConTypeName = New System.Windows.Forms.TextBox
        Me.txtConMinAmount = New System.Windows.Forms.TextBox
        Me.lblConYear = New System.Windows.Forms.Label
        Me.nudConYear = New System.Windows.Forms.NumericUpDown
        Me.pnlToolbar.SuspendLayout()
        CType(Me.nudConYear, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tbrMainForm.Size = New System.Drawing.Size(346, 40)
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
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(346, 45)
        Me.pnlToolbar.TabIndex = 128
        '
        'lblMinAmount
        '
        Me.lblMinAmount.BackColor = System.Drawing.SystemColors.Control
        Me.lblMinAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMinAmount.Location = New System.Drawing.Point(17, 118)
        Me.lblMinAmount.Name = "lblMinAmount"
        Me.lblMinAmount.Size = New System.Drawing.Size(105, 16)
        Me.lblMinAmount.TabIndex = 4
        Me.lblMinAmount.Text = "Minimum Amount"
        '
        'txtConTypeDescription
        '
        Me.txtConTypeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConTypeDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConTypeDescription.Location = New System.Drawing.Point(123, 146)
        Me.txtConTypeDescription.Multiline = True
        Me.txtConTypeDescription.Name = "txtConTypeDescription"
        Me.txtConTypeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConTypeDescription.Size = New System.Drawing.Size(199, 105)
        Me.txtConTypeDescription.TabIndex = 7
        '
        'lblConTypeDescription
        '
        Me.lblConTypeDescription.BackColor = System.Drawing.SystemColors.Control
        Me.lblConTypeDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConTypeDescription.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConTypeDescription.Location = New System.Drawing.Point(17, 146)
        Me.lblConTypeDescription.Name = "lblConTypeDescription"
        Me.lblConTypeDescription.Size = New System.Drawing.Size(100, 16)
        Me.lblConTypeDescription.TabIndex = 6
        Me.lblConTypeDescription.Text = "Description"
        '
        'lblConTypeName
        '
        Me.lblConTypeName.BackColor = System.Drawing.SystemColors.Control
        Me.lblConTypeName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConTypeName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConTypeName.Location = New System.Drawing.Point(17, 92)
        Me.lblConTypeName.Name = "lblConTypeName"
        Me.lblConTypeName.Size = New System.Drawing.Size(105, 16)
        Me.lblConTypeName.TabIndex = 2
        Me.lblConTypeName.Text = "Contribution Name"
        '
        'txtConTypeName
        '
        Me.txtConTypeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConTypeName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConTypeName.Location = New System.Drawing.Point(123, 89)
        Me.txtConTypeName.Name = "txtConTypeName"
        Me.txtConTypeName.Size = New System.Drawing.Size(200, 20)
        Me.txtConTypeName.TabIndex = 3
        '
        'txtConMinAmount
        '
        Me.txtConMinAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConMinAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConMinAmount.Location = New System.Drawing.Point(123, 115)
        Me.txtConMinAmount.Name = "txtConMinAmount"
        Me.txtConMinAmount.Size = New System.Drawing.Size(200, 20)
        Me.txtConMinAmount.TabIndex = 5
        Me.txtConMinAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblConYear
        '
        Me.lblConYear.BackColor = System.Drawing.SystemColors.Control
        Me.lblConYear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblConYear.Location = New System.Drawing.Point(17, 65)
        Me.lblConYear.Name = "lblConYear"
        Me.lblConYear.Size = New System.Drawing.Size(105, 16)
        Me.lblConYear.TabIndex = 0
        Me.lblConYear.Text = "Year"
        '
        'nudConYear
        '
        Me.nudConYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudConYear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudConYear.Location = New System.Drawing.Point(123, 63)
        Me.nudConYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nudConYear.Minimum = New Decimal(New Integer() {1940, 0, 0, 0})
        Me.nudConYear.Name = "nudConYear"
        Me.nudConYear.Size = New System.Drawing.Size(59, 20)
        Me.nudConYear.TabIndex = 1
        Me.nudConYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.nudConYear.Value = New Decimal(New Integer() {2014, 0, 0, 0})
        '
        'frmContributionType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 263)
        Me.Controls.Add(Me.nudConYear)
        Me.Controls.Add(Me.lblConYear)
        Me.Controls.Add(Me.txtConMinAmount)
        Me.Controls.Add(Me.lblMinAmount)
        Me.Controls.Add(Me.txtConTypeDescription)
        Me.Controls.Add(Me.lblConTypeDescription)
        Me.Controls.Add(Me.lblConTypeName)
        Me.Controls.Add(Me.txtConTypeName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmContributionType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contribution Types"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        CType(Me.nudConYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents lblMinAmount As System.Windows.Forms.Label
    Friend WithEvents txtConTypeDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblConTypeDescription As System.Windows.Forms.Label
    Friend WithEvents lblConTypeName As System.Windows.Forms.Label
    Friend WithEvents txtConTypeName As System.Windows.Forms.TextBox
    Friend WithEvents txtConMinAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblConYear As System.Windows.Forms.Label
    Friend WithEvents nudConYear As System.Windows.Forms.NumericUpDown
End Class
