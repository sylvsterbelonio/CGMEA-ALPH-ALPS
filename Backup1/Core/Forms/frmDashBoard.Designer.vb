<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashBoard
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.flpIcons = New System.Windows.Forms.FlowLayoutPanel
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.cmdSystemUser = New PowerNET8.My7GlassButton
        Me.cmdSystemAccess = New PowerNET8.My7GlassButton
        Me.cmdLocalGovernmentUnit = New PowerNET8.My7GlassButton
        Me.cmdDepartment = New PowerNET8.My7GlassButton
        Me.cmdMemberProfile = New PowerNET8.My7GlassButton
        Me.cmdMemberRecord = New PowerNET8.My7GlassButton
        Me.cmdReassignMember = New PowerNET8.My7GlassButton
        Me.cmdReplaceMember = New PowerNET8.My7GlassButton
        Me.cmdMemberInfo = New PowerNET8.My7GlassButton
        Me.cmdMemberContribution = New PowerNET8.My7GlassButton
        Me.cmdLoan = New PowerNET8.My7GlassButton
        Me.cmdAccount = New PowerNET8.My7GlassButton
        Me.cmdCalculator = New PowerNET8.My7GlassButton
        Me.cmdLoanApplicationApproval = New PowerNET8.My7GlassButton
        Me.cmdLoanApplicationRelease = New PowerNET8.My7GlassButton
        Me.cmdAbout = New PowerNET8.My7GlassButton
        Me.cmdExpenses = New PowerNET8.My7GlassButton
        Me.cmdFinancialExpenses = New PowerNET8.My7GlassButton
        Me.cmdMemberLoanPaymentGenerator = New PowerNET8.My7GlassButton
        Me.cmdMemberInformationAndAccounts = New PowerNET8.My7GlassButton
        Me.cmdMemberContributon2 = New PowerNET8.My7GlassButton
        Me.cmdMyLoanApplication = New PowerNET8.My7GlassButton
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.flpIcons.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Green
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.flpIcons, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.90438!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.09562!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(822, 556)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'flpIcons
        '
        Me.flpIcons.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.flpIcons.Controls.Add(Me.cmdClearAll)
        Me.flpIcons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flpIcons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flpIcons.Location = New System.Drawing.Point(3, 497)
        Me.flpIcons.Name = "flpIcons"
        Me.flpIcons.Padding = New System.Windows.Forms.Padding(7)
        Me.flpIcons.Size = New System.Drawing.Size(816, 56)
        Me.flpIcons.TabIndex = 0
        Me.flpIcons.Visible = False
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Location = New System.Drawing.Point(769, 10)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(30, 30)
        Me.cmdClearAll.TabIndex = 3
        Me.cmdClearAll.Text = "X"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        Me.cmdClearAll.Visible = False
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.AutoScroll = True
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdSystemUser)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdSystemAccess)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdLocalGovernmentUnit)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdDepartment)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberProfile)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberRecord)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdReassignMember)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdReplaceMember)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberInfo)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberContribution)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdLoan)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdAccount)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdCalculator)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdLoanApplicationApproval)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdLoanApplicationRelease)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdAbout)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdExpenses)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdFinancialExpenses)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberLoanPaymentGenerator)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberInformationAndAccounts)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMemberContributon2)
        Me.FlowLayoutPanel2.Controls.Add(Me.cmdMyLoanApplication)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Padding = New System.Windows.Forms.Padding(10)
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(816, 488)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'cmdSystemUser
        '
        Me.cmdSystemUser.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdSystemUser.BackColor = System.Drawing.Color.Transparent
        Me.cmdSystemUser.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdSystemUser.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdSystemUser.FlatAppearance.BorderSize = 0
        Me.cmdSystemUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSystemUser.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdSystemUser.Image = Global.Core.My.Resources.Resources.System_user
        Me.cmdSystemUser.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdSystemUser.Location = New System.Drawing.Point(13, 13)
        Me.cmdSystemUser.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdSystemUser.Name = "cmdSystemUser"
        Me.cmdSystemUser.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdSystemUser.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdSystemUser.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdSystemUser.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdSystemUser.Radius = 25
        Me.cmdSystemUser.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdSystemUser.Size = New System.Drawing.Size(82, 78)
        Me.cmdSystemUser.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdSystemUser.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdSystemUser.TabIndex = 0
        Me.cmdSystemUser.UseVisualStyleBackColor = True
        Me.cmdSystemUser.Visible = False
        '
        'cmdSystemAccess
        '
        Me.cmdSystemAccess.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdSystemAccess.BackColor = System.Drawing.Color.Transparent
        Me.cmdSystemAccess.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdSystemAccess.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdSystemAccess.FlatAppearance.BorderSize = 0
        Me.cmdSystemAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSystemAccess.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdSystemAccess.Image = Global.Core.My.Resources.Resources.System_access_level
        Me.cmdSystemAccess.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdSystemAccess.Location = New System.Drawing.Point(13, 97)
        Me.cmdSystemAccess.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdSystemAccess.Name = "cmdSystemAccess"
        Me.cmdSystemAccess.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdSystemAccess.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdSystemAccess.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdSystemAccess.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdSystemAccess.Radius = 25
        Me.cmdSystemAccess.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdSystemAccess.Size = New System.Drawing.Size(82, 78)
        Me.cmdSystemAccess.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdSystemAccess.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdSystemAccess.TabIndex = 1
        Me.cmdSystemAccess.UseVisualStyleBackColor = True
        Me.cmdSystemAccess.Visible = False
        '
        'cmdLocalGovernmentUnit
        '
        Me.cmdLocalGovernmentUnit.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdLocalGovernmentUnit.BackColor = System.Drawing.Color.Transparent
        Me.cmdLocalGovernmentUnit.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdLocalGovernmentUnit.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdLocalGovernmentUnit.FlatAppearance.BorderSize = 0
        Me.cmdLocalGovernmentUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLocalGovernmentUnit.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdLocalGovernmentUnit.Image = Global.Core.My.Resources.Resources.Local_gov_unit
        Me.cmdLocalGovernmentUnit.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdLocalGovernmentUnit.Location = New System.Drawing.Point(13, 181)
        Me.cmdLocalGovernmentUnit.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdLocalGovernmentUnit.Name = "cmdLocalGovernmentUnit"
        Me.cmdLocalGovernmentUnit.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdLocalGovernmentUnit.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdLocalGovernmentUnit.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLocalGovernmentUnit.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLocalGovernmentUnit.Radius = 25
        Me.cmdLocalGovernmentUnit.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdLocalGovernmentUnit.Size = New System.Drawing.Size(82, 78)
        Me.cmdLocalGovernmentUnit.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdLocalGovernmentUnit.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdLocalGovernmentUnit.TabIndex = 16
        Me.cmdLocalGovernmentUnit.UseVisualStyleBackColor = True
        Me.cmdLocalGovernmentUnit.Visible = False
        '
        'cmdDepartment
        '
        Me.cmdDepartment.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdDepartment.BackColor = System.Drawing.Color.Transparent
        Me.cmdDepartment.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdDepartment.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdDepartment.FlatAppearance.BorderSize = 0
        Me.cmdDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDepartment.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdDepartment.Image = Global.Core.My.Resources.Resources.BUSINESS_icon_blue
        Me.cmdDepartment.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdDepartment.Location = New System.Drawing.Point(13, 265)
        Me.cmdDepartment.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdDepartment.Name = "cmdDepartment"
        Me.cmdDepartment.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdDepartment.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdDepartment.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdDepartment.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdDepartment.Radius = 25
        Me.cmdDepartment.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdDepartment.Size = New System.Drawing.Size(82, 78)
        Me.cmdDepartment.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdDepartment.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdDepartment.TabIndex = 17
        Me.cmdDepartment.UseVisualStyleBackColor = True
        Me.cmdDepartment.Visible = False
        '
        'cmdMemberProfile
        '
        Me.cmdMemberProfile.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberProfile.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberProfile.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberProfile.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberProfile.FlatAppearance.BorderSize = 0
        Me.cmdMemberProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberProfile.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberProfile.Image = Global.Core.My.Resources.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
        Me.cmdMemberProfile.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberProfile.Location = New System.Drawing.Point(13, 349)
        Me.cmdMemberProfile.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberProfile.Name = "cmdMemberProfile"
        Me.cmdMemberProfile.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberProfile.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberProfile.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberProfile.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberProfile.Radius = 25
        Me.cmdMemberProfile.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberProfile.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberProfile.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberProfile.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberProfile.TabIndex = 14
        Me.cmdMemberProfile.UseVisualStyleBackColor = True
        Me.cmdMemberProfile.Visible = False
        '
        'cmdMemberRecord
        '
        Me.cmdMemberRecord.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberRecord.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberRecord.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberRecord.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberRecord.FlatAppearance.BorderSize = 0
        Me.cmdMemberRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberRecord.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberRecord.Image = Global.Core.My.Resources.Resources.Member_records1
        Me.cmdMemberRecord.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberRecord.Location = New System.Drawing.Point(101, 13)
        Me.cmdMemberRecord.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberRecord.Name = "cmdMemberRecord"
        Me.cmdMemberRecord.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberRecord.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberRecord.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberRecord.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberRecord.Radius = 25
        Me.cmdMemberRecord.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberRecord.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberRecord.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberRecord.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberRecord.TabIndex = 15
        Me.cmdMemberRecord.UseVisualStyleBackColor = True
        Me.cmdMemberRecord.Visible = False
        '
        'cmdReassignMember
        '
        Me.cmdReassignMember.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdReassignMember.BackColor = System.Drawing.Color.Transparent
        Me.cmdReassignMember.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdReassignMember.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdReassignMember.FlatAppearance.BorderSize = 0
        Me.cmdReassignMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReassignMember.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdReassignMember.Image = Global.Core.My.Resources.Resources.Member_reassign
        Me.cmdReassignMember.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdReassignMember.Location = New System.Drawing.Point(101, 97)
        Me.cmdReassignMember.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdReassignMember.Name = "cmdReassignMember"
        Me.cmdReassignMember.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdReassignMember.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdReassignMember.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdReassignMember.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdReassignMember.Radius = 25
        Me.cmdReassignMember.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdReassignMember.Size = New System.Drawing.Size(82, 78)
        Me.cmdReassignMember.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdReassignMember.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdReassignMember.TabIndex = 18
        Me.cmdReassignMember.UseVisualStyleBackColor = True
        Me.cmdReassignMember.Visible = False
        '
        'cmdReplaceMember
        '
        Me.cmdReplaceMember.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdReplaceMember.BackColor = System.Drawing.Color.Transparent
        Me.cmdReplaceMember.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdReplaceMember.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdReplaceMember.FlatAppearance.BorderSize = 0
        Me.cmdReplaceMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdReplaceMember.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdReplaceMember.Image = Global.Core.My.Resources.Resources.Member_replace
        Me.cmdReplaceMember.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdReplaceMember.Location = New System.Drawing.Point(101, 181)
        Me.cmdReplaceMember.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdReplaceMember.Name = "cmdReplaceMember"
        Me.cmdReplaceMember.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdReplaceMember.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdReplaceMember.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdReplaceMember.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdReplaceMember.Radius = 25
        Me.cmdReplaceMember.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdReplaceMember.Size = New System.Drawing.Size(82, 78)
        Me.cmdReplaceMember.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdReplaceMember.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdReplaceMember.TabIndex = 19
        Me.cmdReplaceMember.UseVisualStyleBackColor = True
        Me.cmdReplaceMember.Visible = False
        '
        'cmdMemberInfo
        '
        Me.cmdMemberInfo.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberInfo.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberInfo.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberInfo.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberInfo.FlatAppearance.BorderSize = 0
        Me.cmdMemberInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberInfo.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberInfo.Image = Global.Core.My.Resources.Resources.Member_records
        Me.cmdMemberInfo.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberInfo.Location = New System.Drawing.Point(101, 265)
        Me.cmdMemberInfo.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberInfo.Name = "cmdMemberInfo"
        Me.cmdMemberInfo.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberInfo.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberInfo.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberInfo.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberInfo.Radius = 25
        Me.cmdMemberInfo.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberInfo.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberInfo.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberInfo.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberInfo.TabIndex = 0
        Me.cmdMemberInfo.UseVisualStyleBackColor = True
        Me.cmdMemberInfo.Visible = False
        '
        'cmdMemberContribution
        '
        Me.cmdMemberContribution.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberContribution.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberContribution.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberContribution.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberContribution.FlatAppearance.BorderSize = 0
        Me.cmdMemberContribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberContribution.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberContribution.Image = Global.Core.My.Resources.Resources.Nudge_Circle_Icon
        Me.cmdMemberContribution.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberContribution.Location = New System.Drawing.Point(101, 349)
        Me.cmdMemberContribution.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberContribution.Name = "cmdMemberContribution"
        Me.cmdMemberContribution.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberContribution.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberContribution.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberContribution.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberContribution.Radius = 25
        Me.cmdMemberContribution.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberContribution.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberContribution.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberContribution.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberContribution.TabIndex = 4
        Me.cmdMemberContribution.UseVisualStyleBackColor = True
        Me.cmdMemberContribution.Visible = False
        '
        'cmdLoan
        '
        Me.cmdLoan.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdLoan.BackColor = System.Drawing.Color.Transparent
        Me.cmdLoan.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdLoan.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdLoan.FlatAppearance.BorderSize = 0
        Me.cmdLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLoan.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdLoan.Image = Global.Core.My.Resources.Resources.Mortgage_Loan_Calculator_icon
        Me.cmdLoan.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdLoan.Location = New System.Drawing.Point(189, 13)
        Me.cmdLoan.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdLoan.Name = "cmdLoan"
        Me.cmdLoan.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdLoan.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdLoan.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLoan.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLoan.Radius = 25
        Me.cmdLoan.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdLoan.Size = New System.Drawing.Size(82, 78)
        Me.cmdLoan.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdLoan.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdLoan.TabIndex = 1
        Me.cmdLoan.UseVisualStyleBackColor = True
        Me.cmdLoan.Visible = False
        '
        'cmdAccount
        '
        Me.cmdAccount.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdAccount.BackColor = System.Drawing.Color.Transparent
        Me.cmdAccount.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdAccount.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdAccount.FlatAppearance.BorderSize = 0
        Me.cmdAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAccount.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdAccount.Image = Global.Core.My.Resources.Resources.my_account
        Me.cmdAccount.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdAccount.Location = New System.Drawing.Point(189, 97)
        Me.cmdAccount.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdAccount.Name = "cmdAccount"
        Me.cmdAccount.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdAccount.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdAccount.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdAccount.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdAccount.Radius = 25
        Me.cmdAccount.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdAccount.Size = New System.Drawing.Size(82, 78)
        Me.cmdAccount.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdAccount.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdAccount.TabIndex = 5
        Me.cmdAccount.UseVisualStyleBackColor = True
        Me.cmdAccount.Visible = False
        '
        'cmdCalculator
        '
        Me.cmdCalculator.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdCalculator.BackColor = System.Drawing.Color.Transparent
        Me.cmdCalculator.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdCalculator.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdCalculator.FlatAppearance.BorderSize = 0
        Me.cmdCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCalculator.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdCalculator.Image = Global.Core.My.Resources.Resources.calculator
        Me.cmdCalculator.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdCalculator.Location = New System.Drawing.Point(189, 181)
        Me.cmdCalculator.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdCalculator.Name = "cmdCalculator"
        Me.cmdCalculator.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdCalculator.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdCalculator.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdCalculator.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdCalculator.Radius = 25
        Me.cmdCalculator.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdCalculator.Size = New System.Drawing.Size(82, 78)
        Me.cmdCalculator.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdCalculator.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdCalculator.TabIndex = 2
        Me.cmdCalculator.UseVisualStyleBackColor = True
        Me.cmdCalculator.Visible = False
        '
        'cmdLoanApplicationApproval
        '
        Me.cmdLoanApplicationApproval.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdLoanApplicationApproval.BackColor = System.Drawing.Color.Transparent
        Me.cmdLoanApplicationApproval.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdLoanApplicationApproval.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdLoanApplicationApproval.FlatAppearance.BorderSize = 0
        Me.cmdLoanApplicationApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLoanApplicationApproval.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdLoanApplicationApproval.Image = Global.Core.My.Resources.Resources.app
        Me.cmdLoanApplicationApproval.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdLoanApplicationApproval.Location = New System.Drawing.Point(189, 265)
        Me.cmdLoanApplicationApproval.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdLoanApplicationApproval.Name = "cmdLoanApplicationApproval"
        Me.cmdLoanApplicationApproval.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdLoanApplicationApproval.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdLoanApplicationApproval.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLoanApplicationApproval.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLoanApplicationApproval.Radius = 25
        Me.cmdLoanApplicationApproval.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdLoanApplicationApproval.Size = New System.Drawing.Size(82, 78)
        Me.cmdLoanApplicationApproval.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdLoanApplicationApproval.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdLoanApplicationApproval.TabIndex = 6
        Me.cmdLoanApplicationApproval.UseVisualStyleBackColor = True
        Me.cmdLoanApplicationApproval.Visible = False
        '
        'cmdLoanApplicationRelease
        '
        Me.cmdLoanApplicationRelease.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdLoanApplicationRelease.BackColor = System.Drawing.Color.Transparent
        Me.cmdLoanApplicationRelease.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdLoanApplicationRelease.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdLoanApplicationRelease.FlatAppearance.BorderSize = 0
        Me.cmdLoanApplicationRelease.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLoanApplicationRelease.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdLoanApplicationRelease.Image = Global.Core.My.Resources.Resources.loan_icon_lg
        Me.cmdLoanApplicationRelease.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdLoanApplicationRelease.Location = New System.Drawing.Point(189, 349)
        Me.cmdLoanApplicationRelease.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdLoanApplicationRelease.Name = "cmdLoanApplicationRelease"
        Me.cmdLoanApplicationRelease.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdLoanApplicationRelease.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdLoanApplicationRelease.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLoanApplicationRelease.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdLoanApplicationRelease.Radius = 25
        Me.cmdLoanApplicationRelease.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdLoanApplicationRelease.Size = New System.Drawing.Size(82, 78)
        Me.cmdLoanApplicationRelease.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdLoanApplicationRelease.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdLoanApplicationRelease.TabIndex = 7
        Me.cmdLoanApplicationRelease.UseVisualStyleBackColor = True
        Me.cmdLoanApplicationRelease.Visible = False
        '
        'cmdAbout
        '
        Me.cmdAbout.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdAbout.BackColor = System.Drawing.Color.Transparent
        Me.cmdAbout.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdAbout.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdAbout.FlatAppearance.BorderSize = 0
        Me.cmdAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAbout.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdAbout.Image = Global.Core.My.Resources.Resources.ip_icon_04_Info
        Me.cmdAbout.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdAbout.Location = New System.Drawing.Point(277, 13)
        Me.cmdAbout.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdAbout.Name = "cmdAbout"
        Me.cmdAbout.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdAbout.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdAbout.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdAbout.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdAbout.Radius = 25
        Me.cmdAbout.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdAbout.Size = New System.Drawing.Size(82, 78)
        Me.cmdAbout.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdAbout.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdAbout.TabIndex = 3
        Me.cmdAbout.UseVisualStyleBackColor = True
        Me.cmdAbout.Visible = False
        '
        'cmdExpenses
        '
        Me.cmdExpenses.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdExpenses.BackColor = System.Drawing.Color.Transparent
        Me.cmdExpenses.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdExpenses.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdExpenses.FlatAppearance.BorderSize = 0
        Me.cmdExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdExpenses.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdExpenses.Image = Global.Core.My.Resources.Resources.expense_manager_icon_256x256
        Me.cmdExpenses.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdExpenses.Location = New System.Drawing.Point(277, 97)
        Me.cmdExpenses.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdExpenses.Name = "cmdExpenses"
        Me.cmdExpenses.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdExpenses.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdExpenses.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdExpenses.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdExpenses.Radius = 25
        Me.cmdExpenses.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdExpenses.Size = New System.Drawing.Size(82, 78)
        Me.cmdExpenses.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdExpenses.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdExpenses.TabIndex = 8
        Me.cmdExpenses.UseVisualStyleBackColor = True
        Me.cmdExpenses.Visible = False
        '
        'cmdFinancialExpenses
        '
        Me.cmdFinancialExpenses.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdFinancialExpenses.BackColor = System.Drawing.Color.Transparent
        Me.cmdFinancialExpenses.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdFinancialExpenses.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdFinancialExpenses.FlatAppearance.BorderSize = 0
        Me.cmdFinancialExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFinancialExpenses.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdFinancialExpenses.Image = Global.Core.My.Resources.Resources.graph_icon_copy_copy
        Me.cmdFinancialExpenses.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdFinancialExpenses.Location = New System.Drawing.Point(277, 181)
        Me.cmdFinancialExpenses.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdFinancialExpenses.Name = "cmdFinancialExpenses"
        Me.cmdFinancialExpenses.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdFinancialExpenses.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdFinancialExpenses.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFinancialExpenses.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdFinancialExpenses.Radius = 25
        Me.cmdFinancialExpenses.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdFinancialExpenses.Size = New System.Drawing.Size(82, 78)
        Me.cmdFinancialExpenses.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdFinancialExpenses.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdFinancialExpenses.TabIndex = 9
        Me.cmdFinancialExpenses.UseVisualStyleBackColor = True
        Me.cmdFinancialExpenses.Visible = False
        '
        'cmdMemberLoanPaymentGenerator
        '
        Me.cmdMemberLoanPaymentGenerator.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberLoanPaymentGenerator.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberLoanPaymentGenerator.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberLoanPaymentGenerator.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberLoanPaymentGenerator.FlatAppearance.BorderSize = 0
        Me.cmdMemberLoanPaymentGenerator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberLoanPaymentGenerator.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberLoanPaymentGenerator.Image = Global.Core.My.Resources.Resources.generator
        Me.cmdMemberLoanPaymentGenerator.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberLoanPaymentGenerator.Location = New System.Drawing.Point(277, 265)
        Me.cmdMemberLoanPaymentGenerator.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberLoanPaymentGenerator.Name = "cmdMemberLoanPaymentGenerator"
        Me.cmdMemberLoanPaymentGenerator.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberLoanPaymentGenerator.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberLoanPaymentGenerator.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberLoanPaymentGenerator.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberLoanPaymentGenerator.Radius = 25
        Me.cmdMemberLoanPaymentGenerator.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberLoanPaymentGenerator.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberLoanPaymentGenerator.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberLoanPaymentGenerator.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberLoanPaymentGenerator.TabIndex = 10
        Me.cmdMemberLoanPaymentGenerator.UseVisualStyleBackColor = True
        Me.cmdMemberLoanPaymentGenerator.Visible = False
        '
        'cmdMemberInformationAndAccounts
        '
        Me.cmdMemberInformationAndAccounts.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberInformationAndAccounts.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberInformationAndAccounts.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberInformationAndAccounts.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberInformationAndAccounts.FlatAppearance.BorderSize = 0
        Me.cmdMemberInformationAndAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberInformationAndAccounts.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberInformationAndAccounts.Image = Global.Core.My.Resources.Resources.memberInfo
        Me.cmdMemberInformationAndAccounts.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberInformationAndAccounts.Location = New System.Drawing.Point(277, 349)
        Me.cmdMemberInformationAndAccounts.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberInformationAndAccounts.Name = "cmdMemberInformationAndAccounts"
        Me.cmdMemberInformationAndAccounts.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberInformationAndAccounts.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberInformationAndAccounts.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberInformationAndAccounts.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberInformationAndAccounts.Radius = 25
        Me.cmdMemberInformationAndAccounts.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberInformationAndAccounts.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberInformationAndAccounts.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberInformationAndAccounts.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberInformationAndAccounts.TabIndex = 11
        Me.cmdMemberInformationAndAccounts.UseVisualStyleBackColor = True
        Me.cmdMemberInformationAndAccounts.Visible = False
        '
        'cmdMemberContributon2
        '
        Me.cmdMemberContributon2.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMemberContributon2.BackColor = System.Drawing.Color.Transparent
        Me.cmdMemberContributon2.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMemberContributon2.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMemberContributon2.FlatAppearance.BorderSize = 0
        Me.cmdMemberContributon2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMemberContributon2.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMemberContributon2.Image = Global.Core.My.Resources.Resources.Membership_Icon_I
        Me.cmdMemberContributon2.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMemberContributon2.Location = New System.Drawing.Point(365, 13)
        Me.cmdMemberContributon2.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMemberContributon2.Name = "cmdMemberContributon2"
        Me.cmdMemberContributon2.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMemberContributon2.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMemberContributon2.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberContributon2.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMemberContributon2.Radius = 25
        Me.cmdMemberContributon2.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMemberContributon2.Size = New System.Drawing.Size(82, 78)
        Me.cmdMemberContributon2.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMemberContributon2.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMemberContributon2.TabIndex = 12
        Me.cmdMemberContributon2.UseVisualStyleBackColor = True
        Me.cmdMemberContributon2.Visible = False
        '
        'cmdMyLoanApplication
        '
        Me.cmdMyLoanApplication.Arrow = PowerNET8.My7GlassButton.MB_Arrow.None
        Me.cmdMyLoanApplication.BackColor = System.Drawing.Color.Transparent
        Me.cmdMyLoanApplication.BaseColor = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.cmdMyLoanApplication.BaseStrokeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdMyLoanApplication.FlatAppearance.BorderSize = 0
        Me.cmdMyLoanApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdMyLoanApplication.GroupPosition = PowerNET8.My7GlassButton.MB_GroupPos.None
        Me.cmdMyLoanApplication.Image = Global.Core.My.Resources.Resources.personal_loan_icon
        Me.cmdMyLoanApplication.ImageSize = New System.Drawing.Size(64, 64)
        Me.cmdMyLoanApplication.Location = New System.Drawing.Point(365, 97)
        Me.cmdMyLoanApplication.MenuListPosition = New System.Drawing.Point(0, 0)
        Me.cmdMyLoanApplication.Name = "cmdMyLoanApplication"
        Me.cmdMyLoanApplication.OnColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(78, Byte), Integer))
        Me.cmdMyLoanApplication.OnStrokeColor = System.Drawing.Color.FromArgb(CType(CType(196, Byte), Integer), CType(CType(177, Byte), Integer), CType(CType(118, Byte), Integer))
        Me.cmdMyLoanApplication.PressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMyLoanApplication.PressStrokeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmdMyLoanApplication.Radius = 25
        Me.cmdMyLoanApplication.ShowBase = PowerNET8.My7GlassButton.MB_ShowBase.Yes
        Me.cmdMyLoanApplication.Size = New System.Drawing.Size(82, 78)
        Me.cmdMyLoanApplication.SplitButton = PowerNET8.My7GlassButton.MB_SplitButton.No
        Me.cmdMyLoanApplication.SplitLocation = PowerNET8.My7GlassButton.MB_SplitLocation.Bottom
        Me.cmdMyLoanApplication.TabIndex = 13
        Me.cmdMyLoanApplication.UseVisualStyleBackColor = True
        Me.cmdMyLoanApplication.Visible = False
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'frmDashBoard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(822, 556)
        Me.ControlBox = False
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmDashBoard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.flpIcons.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdSystemUser As PowerNET8.My7GlassButton
    Friend WithEvents cmdSystemAccess As PowerNET8.My7GlassButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents flpIcons As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents cmdMemberInfo As PowerNET8.My7GlassButton
    Friend WithEvents cmdLoan As PowerNET8.My7GlassButton
    Friend WithEvents cmdCalculator As PowerNET8.My7GlassButton
    Friend WithEvents cmdAbout As PowerNET8.My7GlassButton
    Friend WithEvents cmdMemberContribution As PowerNET8.My7GlassButton
    Friend WithEvents cmdAccount As PowerNET8.My7GlassButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmdLoanApplicationApproval As PowerNET8.My7GlassButton
    Friend WithEvents cmdLoanApplicationRelease As PowerNET8.My7GlassButton
    Friend WithEvents cmdExpenses As PowerNET8.My7GlassButton
    Friend WithEvents cmdFinancialExpenses As PowerNET8.My7GlassButton
    Friend WithEvents cmdMemberLoanPaymentGenerator As PowerNET8.My7GlassButton
    Friend WithEvents cmdMemberInformationAndAccounts As PowerNET8.My7GlassButton
    Friend WithEvents cmdMemberContributon2 As PowerNET8.My7GlassButton
    Friend WithEvents cmdMyLoanApplication As PowerNET8.My7GlassButton
    Friend WithEvents cmdMemberProfile As PowerNET8.My7GlassButton
    Friend WithEvents cmdMemberRecord As PowerNET8.My7GlassButton
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents cmdLocalGovernmentUnit As PowerNET8.My7GlassButton
    Friend WithEvents cmdDepartment As PowerNET8.My7GlassButton
    Friend WithEvents cmdReassignMember As PowerNET8.My7GlassButton
    Friend WithEvents cmdReplaceMember As PowerNET8.My7GlassButton
End Class
