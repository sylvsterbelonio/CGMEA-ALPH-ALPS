<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSignatory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSignatory))
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
        Me.lblSuffix = New System.Windows.Forms.Label
        Me.txtSuffix = New System.Windows.Forms.TextBox
        Me.lblMiddleName = New System.Windows.Forms.Label
        Me.txtMiddleName = New System.Windows.Forms.TextBox
        Me.lblFirstName = New System.Windows.Forms.Label
        Me.txtFirstName = New System.Windows.Forms.TextBox
        Me.lblLastName = New System.Windows.Forms.Label
        Me.txtLastName = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.txtDesignation = New System.Windows.Forms.TextBox
        Me.lblDesignation = New System.Windows.Forms.Label
        Me.txtDepartmentId = New System.Windows.Forms.TextBox
        Me.txtDepartmentName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDepartmentName = New System.Windows.Forms.Label
        Me.txtMemberId = New System.Windows.Forms.TextBox
        Me.txtMemberNo = New System.Windows.Forms.TextBox
        Me.lblMemberNo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.pnlToolbar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlToolbar
        '
        Me.pnlToolbar.BackColor = System.Drawing.SystemColors.Info
        Me.pnlToolbar.Controls.Add(Me.tbrMainForm)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(674, 40)
        Me.pnlToolbar.TabIndex = 158
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
        'lblSuffix
        '
        Me.lblSuffix.BackColor = System.Drawing.SystemColors.Control
        Me.lblSuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuffix.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSuffix.Location = New System.Drawing.Point(350, 155)
        Me.lblSuffix.Name = "lblSuffix"
        Me.lblSuffix.Size = New System.Drawing.Size(115, 16)
        Me.lblSuffix.TabIndex = 14
        Me.lblSuffix.Text = "Suffix"
        '
        'txtSuffix
        '
        Me.txtSuffix.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSuffix.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuffix.Location = New System.Drawing.Point(465, 155)
        Me.txtSuffix.Name = "txtSuffix"
        Me.txtSuffix.Size = New System.Drawing.Size(200, 20)
        Me.txtSuffix.TabIndex = 15
        '
        'lblMiddleName
        '
        Me.lblMiddleName.BackColor = System.Drawing.SystemColors.Control
        Me.lblMiddleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMiddleName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMiddleName.Location = New System.Drawing.Point(350, 125)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(115, 16)
        Me.lblMiddleName.TabIndex = 10
        Me.lblMiddleName.Text = "Middle Name"
        '
        'txtMiddleName
        '
        Me.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMiddleName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMiddleName.Location = New System.Drawing.Point(465, 125)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(200, 20)
        Me.txtMiddleName.TabIndex = 11
        '
        'lblFirstName
        '
        Me.lblFirstName.BackColor = System.Drawing.SystemColors.Control
        Me.lblFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFirstName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFirstName.Location = New System.Drawing.Point(15, 125)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(115, 16)
        Me.lblFirstName.TabIndex = 8
        Me.lblFirstName.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFirstName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFirstName.Location = New System.Drawing.Point(130, 125)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 20)
        Me.txtFirstName.TabIndex = 9
        '
        'lblLastName
        '
        Me.lblLastName.BackColor = System.Drawing.SystemColors.Control
        Me.lblLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLastName.Location = New System.Drawing.Point(15, 155)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(115, 16)
        Me.lblLastName.TabIndex = 12
        Me.lblLastName.Text = "Last Name"
        '
        'txtLastName
        '
        Me.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLastName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLastName.Location = New System.Drawing.Point(130, 155)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(200, 20)
        Me.txtLastName.TabIndex = 13
        '
        'lblRemarks
        '
        Me.lblRemarks.BackColor = System.Drawing.SystemColors.Control
        Me.lblRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemarks.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRemarks.Location = New System.Drawing.Point(15, 185)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(115, 16)
        Me.lblRemarks.TabIndex = 16
        Me.lblRemarks.Text = "Remarks"
        '
        'txtRemarks
        '
        Me.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemarks.Location = New System.Drawing.Point(130, 185)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtRemarks.Size = New System.Drawing.Size(535, 40)
        Me.txtRemarks.TabIndex = 17
        '
        'txtDesignation
        '
        Me.txtDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDesignation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDesignation.Location = New System.Drawing.Point(465, 95)
        Me.txtDesignation.Name = "txtDesignation"
        Me.txtDesignation.Size = New System.Drawing.Size(200, 20)
        Me.txtDesignation.TabIndex = 7
        '
        'lblDesignation
        '
        Me.lblDesignation.BackColor = System.Drawing.SystemColors.Control
        Me.lblDesignation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesignation.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDesignation.Location = New System.Drawing.Point(350, 95)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(115, 16)
        Me.lblDesignation.TabIndex = 6
        Me.lblDesignation.Text = "Designation"
        '
        'txtDepartmentId
        '
        Me.txtDepartmentId.Location = New System.Drawing.Point(310, 95)
        Me.txtDepartmentId.Name = "txtDepartmentId"
        Me.txtDepartmentId.ReadOnly = True
        Me.txtDepartmentId.Size = New System.Drawing.Size(20, 20)
        Me.txtDepartmentId.TabIndex = 5
        Me.txtDepartmentId.TabStop = False
        Me.txtDepartmentId.Visible = False
        '
        'txtDepartmentName
        '
        Me.txtDepartmentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartmentName.Location = New System.Drawing.Point(130, 95)
        Me.txtDepartmentName.Name = "txtDepartmentName"
        Me.txtDepartmentName.Size = New System.Drawing.Size(200, 20)
        Me.txtDepartmentName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Department Name"
        '
        'lblDepartmentName
        '
        Me.lblDepartmentName.BackColor = System.Drawing.Color.Transparent
        Me.lblDepartmentName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDepartmentName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartmentName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDepartmentName.Location = New System.Drawing.Point(15, 95)
        Me.lblDepartmentName.Name = "lblDepartmentName"
        Me.lblDepartmentName.Size = New System.Drawing.Size(115, 15)
        Me.lblDepartmentName.TabIndex = 3
        Me.lblDepartmentName.Text = "Department Name"
        '
        'txtMemberId
        '
        Me.txtMemberId.Location = New System.Drawing.Point(310, 65)
        Me.txtMemberId.Name = "txtMemberId"
        Me.txtMemberId.ReadOnly = True
        Me.txtMemberId.Size = New System.Drawing.Size(20, 20)
        Me.txtMemberId.TabIndex = 2
        Me.txtMemberId.TabStop = False
        Me.txtMemberId.Visible = False
        '
        'txtMemberNo
        '
        Me.txtMemberNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemberNo.Location = New System.Drawing.Point(130, 65)
        Me.txtMemberNo.Name = "txtMemberNo"
        Me.txtMemberNo.Size = New System.Drawing.Size(200, 20)
        Me.txtMemberNo.TabIndex = 1
        '
        'lblMemberNo
        '
        Me.lblMemberNo.BackColor = System.Drawing.Color.Transparent
        Me.lblMemberNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMemberNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMemberNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblMemberNo.Location = New System.Drawing.Point(15, 65)
        Me.lblMemberNo.Name = "lblMemberNo"
        Me.lblMemberNo.Size = New System.Drawing.Size(115, 15)
        Me.lblMemberNo.TabIndex = 0
        Me.lblMemberNo.Text = "Member No."
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
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Employee No."
        '
        'frmSignatory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 247)
        Me.Controls.Add(Me.txtMemberId)
        Me.Controls.Add(Me.txtMemberNo)
        Me.Controls.Add(Me.txtDepartmentId)
        Me.Controls.Add(Me.txtDepartmentName)
        Me.Controls.Add(Me.lblDepartmentName)
        Me.Controls.Add(Me.lblRemarks)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.lblDesignation)
        Me.Controls.Add(Me.txtDesignation)
        Me.Controls.Add(Me.lblSuffix)
        Me.Controls.Add(Me.txtSuffix)
        Me.Controls.Add(Me.lblMiddleName)
        Me.Controls.Add(Me.txtMiddleName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.txtLastName)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblMemberNo)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSignatory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Signatory"
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
    Friend WithEvents btnApprove As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblSuffix As System.Windows.Forms.Label
    Friend WithEvents txtSuffix As System.Windows.Forms.TextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents txtDesignation As System.Windows.Forms.TextBox
    Friend WithEvents lblDesignation As System.Windows.Forms.Label
    Friend WithEvents txtDepartmentId As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartmentName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDepartmentName As System.Windows.Forms.Label
    Friend WithEvents txtMemberId As System.Windows.Forms.TextBox
    Friend WithEvents txtMemberNo As System.Windows.Forms.TextBox
    Friend WithEvents lblMemberNo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ilTool As System.Windows.Forms.ImageList
End Class
