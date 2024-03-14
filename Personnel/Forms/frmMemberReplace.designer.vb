<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMemberReplace
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMemberReplace))
        Me.btnFind = New System.Windows.Forms.ToolBarButton
        Me.ilTool = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSave = New System.Windows.Forms.ToolBarButton
        Me.btnDelete = New System.Windows.Forms.ToolBarButton
        Me.btnCancel = New System.Windows.Forms.ToolBarButton
        Me.pnlToolbar = New System.Windows.Forms.Panel
        Me.tbrMainForm = New System.Windows.Forms.ToolBar
        Me.btnAdd = New System.Windows.Forms.ToolBarButton
        Me.btnEdit = New System.Windows.Forms.ToolBarButton
        Me.btnApprove = New System.Windows.Forms.ToolBarButton
        Me.dtpManagementDt = New System.Windows.Forms.DateTimePicker
        Me.lblReplacementDt = New System.Windows.Forms.Label
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.txtMemberName = New System.Windows.Forms.TextBox
        Me.lblMemberName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMemberIdReplacement = New System.Windows.Forms.TextBox
        Me.txtMemberNameReplacement = New System.Windows.Forms.TextBox
        Me.lblMemberNameReplacement = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFind
        '
        Me.btnFind.ImageIndex = 3
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Text = "Find"
        Me.btnFind.ToolTipText = "Launch Finder Screen"
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
        'btnSave
        '
        Me.btnSave.ImageIndex = 4
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Text = "Save"
        Me.btnSave.ToolTipText = "Save Record"
        '
        'btnDelete
        '
        Me.btnDelete.ImageIndex = 2
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.ToolTipText = "Delete record"
        '
        'btnCancel
        '
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.ToolTipText = "Cancel Changes Made"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(674, 37)
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
        Me.tbrMainForm.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tbrMainForm.Name = "tbrMainForm"
        Me.tbrMainForm.ShowToolTips = True
        Me.tbrMainForm.Size = New System.Drawing.Size(674, 40)
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
        'btnApprove
        '
        Me.btnApprove.ImageIndex = 6
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Text = "Approve"
        '
        'dtpManagementDt
        '
        Me.dtpManagementDt.Checked = False
        Me.dtpManagementDt.CustomFormat = "MMMM dd, yyyy"
        Me.dtpManagementDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpManagementDt.Location = New System.Drawing.Point(130, 95)
        Me.dtpManagementDt.Name = "dtpManagementDt"
        Me.dtpManagementDt.ShowCheckBox = True
        Me.dtpManagementDt.Size = New System.Drawing.Size(200, 20)
        Me.dtpManagementDt.TabIndex = 4
        Me.dtpManagementDt.Tag = "0"
        '
        'lblReplacementDt
        '
        Me.lblReplacementDt.BackColor = System.Drawing.Color.Transparent
        Me.lblReplacementDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReplacementDt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblReplacementDt.Location = New System.Drawing.Point(15, 95)
        Me.lblReplacementDt.Name = "lblReplacementDt"
        Me.lblReplacementDt.Size = New System.Drawing.Size(115, 15)
        Me.lblReplacementDt.TabIndex = 3
        Me.lblReplacementDt.Text = "Date Replaced"
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(15, 155)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(115, 16)
        Me.lblRemarks.TabIndex = 8
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(130, 155)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(535, 100)
        Me.txtRemarks.TabIndex = 9
        '
        'txtMemberId
        '
        Me.txtMemberId.Location = New System.Drawing.Point(645, 65)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 2
        Me.txtMemberId.TabStop = False
        Me.txtMemberId.Visible = False
        '
        'txtMemberName
        '
        Me.txtMemberName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberName.Location = New System.Drawing.Point(130, 65)
        Me.txtMemberName.Name = "txtMemberName"
        Me.txtMemberName.Size = New System.Drawing.Size(535, 20)
        Me.txtMemberName.TabIndex = 1
        '
        'lblMemberName
        '
        Me.lblMemberName.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMemberName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberName.Location = New System.Drawing.Point(15, 65)
        Me.lblMemberName.Name = "lblMemberName"
        Me.lblMemberName.Size = New System.Drawing.Size(115, 15)
        Me.lblMemberName.TabIndex = 0
        Me.lblMemberName.Text = "Member Name *"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(15, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Member Name"
        '
        'txtMemberIdReplacement
        '
        Me.txtMemberIdReplacement.Location = New System.Drawing.Point(645, 125)
        Me.txtMemberIdReplacement.Name = "txtMemberIdReplacement"
        Me.txtMemberIdReplacement.ReadOnly = True
        Me.txtMemberIdReplacement.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberIdReplacement.TabIndex = 7
        Me.txtMemberIdReplacement.TabStop = False
        Me.txtMemberIdReplacement.Visible = False
        '
        'txtMemberNameReplacement
        '
        Me.txtMemberNameReplacement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberNameReplacement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberNameReplacement.Location = New System.Drawing.Point(130, 125)
        Me.txtMemberNameReplacement.Name = "txtMemberNameReplacement"
        Me.txtMemberNameReplacement.Size = New System.Drawing.Size(535, 20)
        Me.txtMemberNameReplacement.TabIndex = 6
        '
        'lblMemberNameReplacement
        '
        Me.lblMemberNameReplacement.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberNameReplacement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMemberNameReplacement.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberNameReplacement.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNameReplacement.Location = New System.Drawing.Point(15, 125)
        Me.lblMemberNameReplacement.Name = "lblMemberNameReplacement"
        Me.lblMemberNameReplacement.Size = New System.Drawing.Size(115, 15)
        Me.lblMemberNameReplacement.TabIndex = 5
        Me.lblMemberNameReplacement.Text = "Replacement *"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(15, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Replacement"
        '
        'frmMemberReplace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 267)
        Me.Controls.Add(Me.txtMemberIdReplacement)
        Me.Controls.Add(Me.txtMemberNameReplacement)
        Me.Controls.Add(Me.dtpManagementDt)
        Me.Controls.Add(Me.lblReplacementDt)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.txtMemberId)
        Me.Controls.Add(Me.txtMemberName)
        Me.Controls.Add(Me.lblMemberName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.lblMemberNameReplacement)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMemberReplace"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Member Replace"
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlToolbar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFind As System.Windows.Forms.ToolBarButton
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
    Friend WithEvents btnSave As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnDelete As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancel As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlToolbar As System.Windows.Forms.Panel
    Friend WithEvents tbrMainForm As System.Windows.Forms.ToolBar
    Friend WithEvents btnAdd As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEdit As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents dtpManagementDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReplacementDt As System.Windows.Forms.Label
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberName As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMemberIdReplacement As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberNameReplacement As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberNameReplacement As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
