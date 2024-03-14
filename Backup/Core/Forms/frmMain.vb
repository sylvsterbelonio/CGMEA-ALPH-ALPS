Imports System.Windows.Forms.Cursors
Imports System.Windows.Forms.Help
Imports System.IO

Public Class frmMain
    Inherits System.Windows.Forms.Form

    Private WithEvents clsMain As New Main.Main
    Private WithEvents frmChangePasswordForm As DataAccess.frmChangePassword = Nothing
    Private WithEvents frmLoginForm As DataAccess.frmLogin = Nothing
    Private WithEvents frmSystemLockForm As DataAccess.frmSystemLock = Nothing
    Private WithEvents frmDBConnMgr As DataAccess.frmConnectionManager = Nothing
    Private WithEvents frmAboutForm As DataAccess.frmAbout = Nothing
    Private WithEvents frmWelcomeScreenForm As DataAccess.frmWelcomeScreen = Nothing
    Private WithEvents frmDashBoard As New frmDashBoard

    Private dtMainMenu As DataSet
    Private dtMainMenuRow As DataRow
    Private dtToolBar As DataSet
    Private dtToolBarRow As DataRow
    Private dtSubMenu As DataSet
    Private dtSubMenuRow As DataRow
    Private dtSubMenu1 As DataSet
    Private dtSubMenuRow1 As DataRow
    Private Conntimer As Timer

    Private gifBackground As Image = MyTemplates.clsSkin.getMainBackGroun
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        chat.isEnding = True
        chat.Close()
    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Connect(mysql)
        chat.Show()
        chat.Visible = False

        Dim ctl As Control
        Timer1.Start()
        Dim ctlMDI As MdiClient

        ' Loop through all of the form's controls looking for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                'Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = Me.BackColor
                ctlMDI.BackgroundImage = Me.BackgroundImage


            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next

        'custom initializations
        InitializeMe()


        With frmDashBoard
            .MdiParent = Me
            .set_form(Me)
            .Size = New Size(Me.Width - 35, Me.Height - 135)
            .Show()
        End With

        If isRequiredToChangePassword Then
            frmChangePasswordForm = clsDataAccess.NewfrmChangePassword(App_UserID)
            frmChangePasswordForm.ShowDialog()
        End If
    End Sub

    Private Sub InitializeMe()
        Me.Cursor = WaitCursor
        'maximize main menu
        Me.WindowState = FormWindowState.Maximized

        If (clsCommon.GetRegistrySetting("Welcome", "ShowScreen") = "1") Then
            frmWelcomeScreenForm = clsDataAccess.NewfrmWelcomeScreen
            frmWelcomeScreenForm.Show(Me)
        End If
        Me.Cursor = Arrow
    End Sub

    Public Sub SetFormState()
        'set window title
        Me.Text = modApp.AssemblyProduct

        'set window background
        Me.BackgroundImage = gifBackground
        Me.BackgroundImageLayout = ImageLayout.Stretch

        'paint menu and sub-menus
        MainMenu()

        'paint toolbar menu
        ToolBar()

        'paint panels
        StatusBar()

        Conntimer = New Timer
        AddHandler Conntimer.Tick, New EventHandler(AddressOf Timer_Tick)
        Conntimer.Enabled = True
        DoubleBuffered = True

        Me.UpdateStatusLabels()

        Me.MainMenuStrip = msMain

        'load system parameters
        LoadSystemParameters()
    End Sub

    Private Sub LoadSystemParameters()
        Try

        Catch ex As Exception
            clsCommon.Prompt_User("error", "An error had occured while the system tried to load default parameters: " & ex.Message)
        End Try
    End Sub

    Private Sub MainMenu()
        'populate main menu
        Dim intMenu As Integer

        Me.msMain.Items.Clear()

        With clsMain
            .Role_Id = Role_ID
            .PopulateMainMenu()
            Me.dtMainMenu = .dtMain
            intMenu = 0
            For Each Me.dtMainMenuRow In Me.dtMainMenu.Tables(0).Rows
                Dim mpFile As New ToolStripMenuItem
                mpFile.Name = "menu" + CStr(intMenu)
                mpFile.Text = Me.dtMainMenuRow(1)
                'showBottomIcons(mpFile.Text)
                If Me.dtMainMenuRow(3) > -1 Then
                    mpFile.Image = ilMain.Images(CInt(Me.dtMainMenuRow(3)))
                End If

                If LCase(Me.dtMainMenuRow(1)) = "&window" Then
                    msMain.MdiWindowListItem = mpFile
                End If

                .Parent_Id = Me.dtMainMenuRow(0)
                .CheckIfMenuHasChild()
                If .intChild_Count > 0 Then
                    SubMainMenu(mpFile, Me.dtMainMenuRow(0))
                End If

                msMain.Items.Add(mpFile)
                intMenu = intMenu + 1
            Next
        End With
    End Sub

    Public seletecedIcons As String = ""

    Private Sub ReadyDrag_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        seletecedIcons = sender.text
    End Sub

    Private Sub SubMainMenu(ByRef subMPFile As ToolStripMenuItem, ByVal ParentId As Integer)
        Dim intMenu As Integer
        'MsgBox(subMPFile.Text)
        With clsMain
            .Role_Id = Role_ID
            .Parent_Id = ParentId
            .PopulateSubMenu()
            Me.dtSubMenu = .dtSub
            intMenu = 0

            For Each Me.dtSubMenuRow In Me.dtSubMenu.Tables(0).Rows
                If Me.dtSubMenuRow(3) = 0 Then
                    Dim tsiMain As ToolStripItem
                    If Me.dtSubMenuRow(1) = "&About" Then
                        tsiMain = subMPFile.DropDownItems.Add(Me.dtSubMenuRow(1) & " " & modApp.AssemblyTitle)
                        tsiMain.ToolTipText = Me.dtSubMenuRow(1) & " " & modApp.AssemblyTitle
                    Else

                        tsiMain = subMPFile.DropDownItems.Add(Me.dtSubMenuRow(1))
                        'showBottomIcons(Me.dtSubMenuRow(1))
                        tsiMain.ToolTipText = clsCommon.ReplaceAmpersands(Me.dtSubMenuRow(1))
                    End If

                    If Me.dtSubMenuRow(2) = 1 Then
                        Dim tssMenu As New ToolStripSeparator
                        subMPFile.DropDownItems.Add(tssMenu)
                    End If

                    If Me.dtSubMenuRow(4) > -1 Then
                        Try
                            tsiMain.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                        Catch ex As Exception

                        End Try

                    End If

                    AddHandler tsiMain.Click, AddressOf MainMenuToolbar_Click
                    AddHandler tsiMain.MouseDown, AddressOf ReadyDrag_MouseDown

                    If Me.dtSubMenuRow(5) > 0 Then
                        'smbFile.Shortcut = CLng(Me.dtSubMenuRow(5))
                    End If

                ElseIf Me.dtSubMenuRow(3) = 1 Then
                    Dim tsmMenu As New ToolStripMenuItem
                    tsmMenu.Name = "submenu" + CStr(Me.dtSubMenuRow(0))
                    tsmMenu.Text = Me.dtSubMenuRow(1)
                    'showBottomIcons(tsmMenu.Text)
                    subMPFile.DropDownItems.Add(tsmMenu)

                    If Me.dtSubMenuRow(4) > -1 Then
                        tsmMenu.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                    End If

                    If Me.dtSubMenuRow(2) = 1 Then
                        Dim tssMenu As New ToolStripSeparator
                        subMPFile.DropDownItems.Add(tssMenu)
                    End If

                    .Parent_Id = Me.dtSubMenuRow(0)
                    .CheckIfMenuHasChild()

                    'populate submenus
                    If .intChild_Count > 0 Then
                        SubMainMenu(tsmMenu, Me.dtSubMenuRow(0))
                    End If
                End If

                intMenu = intMenu + 1
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''I let view the user's performance CRACKED BY SYLVSTER R> BELONIO
            If subMPFile.Text = "&Modules" And Role_ID <> 0 Then
                With clsMain
                    .Role_Id = 0
                    .Parent_Id = ParentId
                    .PopulateSubMenu()
                    Me.dtSubMenu = .dtSub
                    intMenu = 0
                    Dim index As Integer = 0
                    For Each Me.dtSubMenuRow In Me.dtSubMenu.Tables(0).Rows
                        If index >= 4 Then
                            Dim tsmMenu As New ToolStripMenuItem
                            tsmMenu.Name = "submenu" + CStr(Me.dtSubMenuRow(0))
                            tsmMenu.Text = Me.dtSubMenuRow(1)
                            'showBottomIcons(tsmMenu.Text)
                            subMPFile.DropDownItems.Add(tsmMenu)

                            AddHandler tsmMenu.MouseDown, AddressOf ReadyDrag_MouseDown

                            If Me.dtSubMenuRow(4) > -1 Then
                                tsmMenu.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                            End If

                            If Me.dtSubMenuRow(2) = 1 Then
                                Dim tssMenu As New ToolStripSeparator
                                subMPFile.DropDownItems.Add(tssMenu)
                            End If

                            .Parent_Id = Me.dtSubMenuRow(0)
                            .CheckIfMenuHasChild()

                            'populate submenus
                            If .intChild_Count > 0 Then
                                SubMainMenu_for_User_Performance_Mode(tsmMenu, Me.dtSubMenuRow(0))
                            End If
                        End If
                        index += 1
                    Next
                End With
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        End With
    End Sub

#Region "I added a new Functions to always view the user's performance here CRACKED BY SYLVSTER R. BELONIO"

    Private Sub SubMainMenu_for_User_Performance_Mode(ByRef subMPFile As ToolStripMenuItem, ByVal ParentId As Integer)
        Dim intMenu As Integer
        'MsgBox(subMPFile.Text)
        With clsMain
            .Role_Id = 0
            .Parent_Id = ParentId
            .PopulateSubMenu()
            Me.dtSubMenu = .dtSub
            intMenu = 0

            For Each Me.dtSubMenuRow In Me.dtSubMenu.Tables(0).Rows
                If Me.dtSubMenuRow(3) = 0 Then
                    Dim tsiMain As ToolStripItem
                    If Me.dtSubMenuRow(1) = "&About" Then
                        tsiMain = subMPFile.DropDownItems.Add(Me.dtSubMenuRow(1) & " " & modApp.AssemblyTitle)
                        tsiMain.ToolTipText = Me.dtSubMenuRow(1) & " " & modApp.AssemblyTitle
                    Else
                        tsiMain = subMPFile.DropDownItems.Add(Me.dtSubMenuRow(1))
                        tsiMain.ToolTipText = clsCommon.ReplaceAmpersands(Me.dtSubMenuRow(1))
                    End If

                    If Me.dtSubMenuRow(2) = 1 Then
                        Dim tssMenu As New ToolStripSeparator
                        subMPFile.DropDownItems.Add(tssMenu)
                    End If

                    If Me.dtSubMenuRow(4) > -1 Then
                        tsiMain.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                    End If

                    AddHandler tsiMain.Click, AddressOf MainMenuToolbar_Click

                    If Me.dtSubMenuRow(5) > 0 Then
                        'smbFile.Shortcut = CLng(Me.dtSubMenuRow(5))
                    End If

                ElseIf Me.dtSubMenuRow(3) = 1 Then
                    Dim tsmMenu As New ToolStripMenuItem
                    tsmMenu.Name = "submenu" + CStr(Me.dtSubMenuRow(0))
                    tsmMenu.Text = Me.dtSubMenuRow(1)
                    'showBottomIcons(tsmMenu.Text)
                    subMPFile.DropDownItems.Add(tsmMenu)

                    If Me.dtSubMenuRow(4) > -1 Then
                        tsmMenu.Image = ilMain.Images(CInt(Me.dtSubMenuRow(4)))
                    End If

                    If Me.dtSubMenuRow(2) = 1 Then
                        Dim tssMenu As New ToolStripSeparator
                        subMPFile.DropDownItems.Add(tssMenu)
                    End If

                    .Parent_Id = Me.dtSubMenuRow(0)
                    .CheckIfMenuHasChild()

                    'populate submenus
                    If .intChild_Count > 0 Then
                        SubMainMenu(tsmMenu, Me.dtSubMenuRow(0))
                    End If
                End If

                intMenu = intMenu + 1
            Next

        End With

      
    End Sub

#End Region

    Private Sub Toolbar()
        'populate toolbar menu
        Dim intTool As Integer
        allowOverride = True
        Me.tsMain.Items.Clear()

        With clsMain
            .Role_Id = Role_ID
            .PopulateToolBar()
            Me.dtToolBar = .dtToolBar
            intTool = 0
            For Each Me.dtToolBarRow In Me.dtToolBar.Tables(0).Rows
                Dim tsbTool As New ToolStripButton
                tsbTool.Name = "tool" + CStr(intTool)
                tsbTool.Text = Me.dtToolBarRow(1)
                tsbTool.ToolTipText = clsCommon.ReplaceAmpersands(Me.dtToolBarRow(1))
                tsMain.Items.Add(tsbTool)

                AddHandler tsbTool.Click, AddressOf MainMenuToolbar_Click

                If Me.dtToolBarRow(2) > -1 Then
                    Try
                        tsbTool.Image = ilMain.Images(CInt(Me.dtToolBarRow(2)))
                        tsbTool.DisplayStyle = ToolStripItemDisplayStyle.Image
                    Catch ex As Exception

                    End Try

                End If

                If dtToolBarRow(3) = 1 Then
                    Dim tssMenu As New ToolStripSeparator
                    tsMain.Items.Add(tssMenu)
                End If
                intTool = intTool + 1
            Next


            tsbToolx.Alignment = ToolStripItemAlignment.Right
            tsbToolx.Name = "tool" + CStr(intTool)

            tsbToolx.BackgroundImageLayout = ImageLayout.Stretch

            Connect(mysql)
            Dim mydata As DataTable = mysql.Query("SELECT * FROM   tbl_notification_user   right JOIN tbl_notification   ON (tbl_notification_user.NID = tbl_notification.NID) where viewMode is NULL")

            If mydata.Rows.Count > 0 Then
                tsbToolx.Text = "New Notifications (" + mydata.Rows.Count.ToString + ")"
                tsbToolx.BackgroundImage = My.Resources.red
                tsbToolx.ForeColor = Color.Maroon
            Else
                tsbToolx.Text = "Notifications"
                tsbToolx.BackgroundImage = My.Resources.orange
                tsbToolx.ForeColor = Color.Black
            End If

            'tsbToolx.ToolTipText = "New Notifications Incoming!"
            reload_Notifications(tsbToolx)
            tsMain.Items.Add(tsbToolx)
            tsbToolx.ToolTipText = ""
            tsbToolx.AutoToolTip = False
            AddHandler tsbToolx.Click, AddressOf Notification_Click

        End With
        tsMain.Visible = (intTool > 0)
    End Sub

    Private Sub reloadNotifications()

    End Sub

    Private Sub Notification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.BackgroundImage = My.Resources.orange
        sender.Text = "Notifications"
        sender.ToolTipText = ""
        sender.ForeColor = Color.Black
    End Sub

#Region "THIS IS FOR BOTTOM ICONS EVENT"

    Dim allowDrag As Boolean = False
    Dim allowOpan As Boolean = True
    Private X_axis As Integer
    Private y_axis As Integer

    Private Function getExistingBottomIcon(ByVal name As String)
        Dim cname As String = "cmd" + name.Replace(" ", "")
        Dim obj As FlowLayoutPanel = frmDashBoard.flpIcons
        For Each SubObj In obj.Controls
            If SubObj.name = cname Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function BottomCloseForm(ByVal strFormName As String, ByRef objForm As Form, Optional ByVal strFormTag As String = "") As Boolean
        'this procedure loads a form based on its name. it activates the form if existing already
        Dim NwObjForm As Form

        If Not clsCommon.CheckIfChildIsLoaded(Me, strFormName, strFormTag) Then
            objForm.MdiParent = Me
            objForm.Show()
            Return True
        Else
            'objForm.Dispose()
            NwObjForm = clsCommon.GetMDIChildForm(Me, strFormName, strFormTag)
            NwObjForm.Dispose()
            Return False
        End If
    End Function

    Private Sub BottomIcon_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If allowDrag Then
            allowOpan = False
            Dim pt As New Point(e.X - X_axis, e.Y - y_axis)
            'Dim pt As New Point(CType(sender, PowerNET8.My7GlassButton).Left,CType(sender, PowerNET8.My7GlassButton).Top)
            'CType(sender, PowerNET8.My7GlassButton).Left += pt.X
            CType(sender, PowerNET8.CButton).Top += pt.Y
        End If
    End Sub
    Private Sub BottomIcon_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        With CType(sender, PowerNET8.CButton)
            If e.Button = MouseButtons.Left Then
                Dim size As Size = .Size
                .Size = New Size(size.Width + 5, size.Height + 5)
                allowDrag = True
                X_axis = e.X
                y_axis = e.Y
            End If
            If .Cursor = Cursors.SizeAll Then
                .Cursor = Cursors.Default
            End If
        End With
    End Sub
    Private Sub BottomIcon_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            With CType(sender, PowerNET8.CButton)
                Dim size As Size = .Size
                .Size = New Size(size.Width - 5, size.Height - 5)
                allowDrag = False
                Dim gap As Integer = 0
                If y_axis < .Top Then
                    gap = .Top - y_axis
                Else
                    gap = y_axis - .Top
                End If
                If gap <= 2 Then
                    If allowOpan Then
                        'SelectClosedBottom(.Name)
                    End If
                    CType(sender, PowerNET8.CButton).Dispose()
                    allowOpan = True
                End If
            End With
        End If
    End Sub

    ''' <summary>
    ''' DASHBOARD
    ''' </summary>
    ''' <param name="type"></param>
    ''' <remarks></remarks>


    Private Sub BottomIconAdd(ByVal name As String)
        Select Case name
            Case "system users"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.users
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "system users"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "system access level"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Access_Control_icon_100_NEW
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "system access level"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "about"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.users
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "about"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "member info"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.memberInfo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "member info"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "member contribution billing"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Nudge_Circle_Icon
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "billing"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "loan application"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Mortgage_Loan_Calculator_icon
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "loan"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "accounts"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.my_account_login_icon
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "account"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "loan application approval"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.app
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "loan application approval"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "loan application release"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.loan_icon_lg
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "loan application release"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "disbursement"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.expense_manager_icon_256x256
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "disbursement"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "disbursement type"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.graph_icon_copy_copy
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "disbursement type"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "member loan payment billing"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.generator
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "member loan payment billing"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "member contribution"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Membership_Icon_I
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "member contribution"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "my loan application"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.personal_loan_icon
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "my loan application"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "member profile"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "member profile"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
                'Spatial Look-up Tables
            Case "country"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "country"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "region"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "region"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "province"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "province"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "district"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "district"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "city / municipality"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "city / municipality"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "barangay"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "barangay"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "zip code"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "zip code"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
                'Personnel Module
            Case "local government unit"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Local_gov_unit
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "local government unit"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "departments"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.BUSINESS_icon_blue
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "departments"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "member record"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Member_records1
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "member records"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "reassign member"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Member_reassign
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "reassign member"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "replace member"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources.Member_replace
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "replace member"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "retire / fire member"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "retire / fire member"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
                'Utility Module
            Case "banks"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "banks"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "signatory"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "signatory"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "collection type"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "collection type"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "collection fee"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "collection fee"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "type of loans"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "type of loans"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "insurance rate"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "insurance rate"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "revision code"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "revision code"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
            Case "variable names"
                If Not getExistingBottomIcon(name) Then
                    Dim btn As New PowerNET8.CButton
                    With btn
                        .Name = "cmd" + name.Replace(" ", "")
                        .Image = My.Resources._38795437_Profile_member_icon_orange_square_button_Stock_Photo
                        .Size = New Size(40, 40)
                        .ImageSize = New Size(30, 32)
                        .Text = ""
                        .Tag = "variable names"
                        AddHandler btn.Click, AddressOf BottomIcon_Click
                        AddHandler btn.MouseUp, AddressOf BottomIcon_MouseUp
                        AddHandler btn.MouseDown, AddressOf BottomIcon_MouseDown
                        AddHandler btn.MouseMove, AddressOf BottomIcon_MouseMove
                    End With
                    frmDashBoard.flpIcons.Controls.Add(btn)
                End If
                'BOD Module
        End Select
        frmDashBoard.flpIcons.Visible = True
        frmDashBoard.cmdClearAll.Visible = True
    End Sub

    Private Sub BottomIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Select Case CType(sender, PowerNET8.CButton).Name
            Case "cmdsystemusers"
                ButtonClickIcons("system users")
            Case "cmdsystemaccesslevel"
                ButtonClickIcons("system access level")
            Case "cmdmembercontributionupdater"
                ButtonClickIcons("contribution")
            Case "cmdloanapplication"
                ButtonClickIcons("loan")
            Case "cmdaccounts"
                ButtonClickIcons("accout")
            Case "cmdloanapplicationapproval"
                ButtonClickIcons("loan application approval")
            Case "cmdloanapplicationrelease"
                ButtonClickIcons("loan application release")
            Case "cmdexpenses"
                ButtonClickIcons("disbursement")
            Case "cmdfinancialexpenses"
                ButtonClickIcons("disbursement type")
            Case "cmdmemberloanpaymentgenerator"
                ButtonClickIcons("member loan payment billing")
            Case "cmdMemberContributon2"
                ButtonClickIcons("member contribution")
            Case "cmdMyLoanApplication"
                ButtonClickIcons("my loan application")
            Case "cmdMemberProfile"
                ButtonClickIcons("member profile")
        End Select
    End Sub

    Private Sub ButtonClickIcons(ByVal name As String) Handles frmDashBoard.Button_Clicked
        Dim objForm As Form
        Select Case name
            Case "system users"
                Dim clsSystems As New Systems.Systems(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsSystems.NwfrmSystemUserFinder
                LoadForm("frmSystemUserFinder", objForm)
                BottomIconAdd("system users")
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "system access level"
                Dim clsSystems As New Systems.Systems(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsSystems.NwfrmSystemAccessLevelFinder
                LoadForm("frmSystemAccessLevelFinder", objForm)
                BottomIconAdd("system access level")
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "calculator"
                Try
                    Dim pinfo As New ProcessStartInfo("CALC")
                    Dim p As Process = System.Diagnostics.Process.Start(pinfo)
                    Threading.Thread.Sleep(1000)
                    Common.Common.SetParent(p.MainWindowHandle, Me.Handle)
                    Common.Common.ShowWindow(p.MainWindowHandle, SW_NORMAL)
                Catch ex As Exception

                End Try
            Case "about"
                Try
                    frmAboutForm = clsDataAccess.NewfrmAbout
                    frmAboutForm.ShowDialog()
                Catch ex As Exception
                End Try
            Case "member info"
                Dim clsMembership As New Membership.Membership(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembership.NewfrmMemberInfoAndAccountsFinder
                LoadForm("frmMemberInfoAndAccountsFinder", objForm)
                BottomIconAdd("member info")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "contribution"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionUpdater
                LoadForm("frmMemberContributionUpdater", objForm)
                BottomIconAdd("member contribution billing updater")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "loan"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationFinder

                LoadForm("frmLoanApplicationFinder", objForm)
                BottomIconAdd("loan application")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "accout"
                Dim clsMembership As New Membership.Membership(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembership.NewfrmMemberInfoAndAccounts

                LoadForm("frmMemberInfoAndAccounts", objForm)
                BottomIconAdd("accounts")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "loan application approval"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationApprovalFinder
                BottomIconAdd("loan application approval")
                LoadForm("frmLoanApplicationApprovalFinder", objForm)

                'Treasurer's Module
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "loan application release"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationReleaseFinder
                BottomIconAdd("loan application release")
                LoadForm("frmLoanApplicationReleaseFinder", objForm)
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "disbursement"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmExpensesFinder
                LoadForm("frmExpensesFinder", objForm)
                BottomIconAdd("disbursement")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "disbursement type"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmFSFinder
                LoadForm("frmFSFinder", objForm)
                BottomIconAdd("disbursement type")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member loan billing updater"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanPaymentUpdater

                LoadForm("frmMemberLoanPaymentUpdater", objForm)
                BottomIconAdd("member loan billing updater")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member information and accounts"
                Dim clsMembership As New Membership.Membership(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembership.NewfrmMemberInfoAndAccountsFinder

                LoadForm("frmMemberInfoAndAccountsFinder", objForm)
                BottomIconAdd("member info")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member contribution"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionFinder

                LoadForm("frmMemberContributionFinder", objForm)

                BottomIconAdd("member contribution")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "my loan application"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationFinder

                LoadForm("frmLoanApplicationFinder", objForm)
                BottomIconAdd("loan application")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member profile"
                Dim clsPersonnel As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsPersonnel.NewfrmMember

                LoadForm("frmMember", objForm)

                BottomIconAdd("member profile")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'Spatial Look-up Tables
            Case "country"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmCountryFinder

                LoadForm("frmCountryFinder", objForm)
                BottomIconAdd("country")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "region"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmRegionFinder

                LoadForm("frmRegionFinder", objForm)
                BottomIconAdd("region")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "province"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmProvinceFinder

                LoadForm("frmProvinceFinder", objForm)
                BottomIconAdd("province")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "district"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmDistrictFinder

                LoadForm("frmDistrictFinder", objForm)

                BottomIconAdd("district")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "city / municipality"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmMunicipalityFinder

                LoadForm("frmMunicipalityFinder", objForm)
                BottomIconAdd("city / municipality")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "barangay"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmBarangayFinder

                LoadForm("frmBarangayFinder", objForm)
                BottomIconAdd("barangay")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "zip code"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmZipCodeFinder

                LoadForm("frmZipCodeFinder", objForm)
                BottomIconAdd("zipcode")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'Personnel Module
            Case "local government unit"
                Dim clsPersonnel As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsPersonnel.NewfrmLGUFinder

                LoadForm("frmLGUFinder", objForm)

                BottomIconAdd("local government unit")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "departments"
                Dim clsPersonnel As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsPersonnel.NewfrmDepartmentFinder

                LoadForm("frmDepartmentFinder", objForm)
                BottomIconAdd("departments")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member record"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberFinder

                LoadForm("frmMemberFinder", objForm)

                BottomIconAdd("member record")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "reassign member"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberReassignFinder

                LoadForm("frmMemberReassignFinder", objForm)
                BottomIconAdd("reassign member")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "replace member"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberReplaceFinder

                LoadForm("frmMemberReplaceFinder", objForm)
                BottomIconAdd("replace member")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "retire / fire member"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberRetireFinder

                LoadForm("frmMemberRetireFinder", objForm)
                BottomIconAdd("retire / fire member")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'Utility Module
            Case "banks"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmBankFinder

                LoadForm("frmBankFinder", objForm)
                BottomIconAdd("banks")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "chat"
                showChat()
            Case "signatory"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmSignatoryFinder

                LoadForm("frmSignatoryFinder", objForm)
                BottomIconAdd("signatory")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "collection type"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmCollectionTypeFinder

                LoadForm("frmCollectionTypeFinder", objForm)
                BottomIconAdd("collection type")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "collection fee"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmCollectionFeeFinder

                LoadForm("frmCollectionFeeFinder", objForm)

                'Bookkeeper's Module
                BottomIconAdd("collection fee")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "type of loans"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmTypeLoanFinder
                LoadForm("frmTypeLoanFinder", objForm)

                BottomIconAdd("type of loans")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "insurance rate"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanRateFinder
                LoadForm("frmLoanRateFinder", objForm)

                BottomIconAdd("insurance rate")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "revision code"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmRevisionFinder
                LoadForm("frmRevisionFinder", objForm)

                BottomIconAdd("revision code")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "variable names"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmrefVariableFinder
                LoadForm("frmrefVariableFinder", objForm)
                '--- End ---
                BottomIconAdd("variable names")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'BOD Module
            Case "contribution"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionUpdater
                LoadForm("frmMemberContributionUpdater", objForm)
                BottomIconAdd("member contribution billing updater")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed


            Case "member loan billing updater"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanPaymentUpdater

                LoadForm("frmLoanPaymentUpdater", objForm)
                BottomIconAdd("member loan billing updater")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "remove all"
                Dim frmMdiChild As Form
                For Each ctl In Me.MdiChildren
                    frmMdiChild = CType(ctl, Form)
                    If frmMdiChild.Name <> "frmDashBoard" Then
                        Try
                            frmMdiChild.Close()
                        Catch ex As Exception
                        End Try
                    End If
                Next
        End Select
    End Sub

    Private Sub BottomIcon_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        Dim listControl As FlowLayoutPanel = frmDashBoard.flpIcons
        Dim count As Integer = 0
        For Each obj As Object In listControl.Controls
            Select Case obj.tag
                Case "system users"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "system access level"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "member info"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "contribution"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "loan"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "account"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "loan application approval"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "loan application release"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "disbursement"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "disbursement type"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "member loan payment billing"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "member contribution"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "my loan application"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "member profile"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                    'Spatial Look-up Tables
                Case "country"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "region"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "province"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "district"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "city / municipality"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "barangay"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "zip code"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                    'Personnel Module
                Case "local government unit"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "departments"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "member records"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "reassign member"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "replace member"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "retire / fire member"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                    'Utility Module
                Case "banks"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "signatory"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "collection type"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "collection fee"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "type of loans"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "insurance rate"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "revision code"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                Case "variable names"
                    frmDashBoard.flpIcons.Controls.RemoveAt(count)
                    If listControl.Controls.Count = 1 Then frmDashBoard.flpIcons.Visible = False
                    Exit Sub
                    'BOD Module
            End Select
            count += 1
        Next
    End Sub

#End Region

    Public Sub MainMenuToolbar_Click(ByVal sender As Object, ByVal e As EventArgs)
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim item As ToolStripItem = CType(sender, ToolStripItem)
        Dim objForm As Form

        'System User Module
        Select Case LCase(item.Text)

            Case "system parameters"
                Dim clsSystems As New Systems.Systems(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsSystems.NwfrmSystemParameterFinder

                LoadForm("frmSystemParameterFinder", objForm)

            Case "system access level"
                Dim clsSystems As New Systems.Systems(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsSystems.NwfrmSystemAccessLevelFinder

                LoadForm("frmSystemAccessLevelFinder", objForm)
                BottomIconAdd("system access level")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "system users"
                Dim clsSystems As New Systems.Systems(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsSystems.NwfrmSystemUserFinder

                LoadForm("frmSystemUserFinder", objForm)
                BottomIconAdd("system users")
                'Database Management
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "type of loans"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmTypeLoanFinder
                LoadForm("frmTypeLoanFinder", objForm)
            Case "insurance rate"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanRateFinder
                LoadForm("frmLoanRateFinder", objForm)
            Case "revision code"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmRevisionFinder
                LoadForm("frmRevisionFinder", objForm)
            Case "variable names"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmrefVariableFinder
                LoadForm("frmrefVariableFinder", objForm)
            Case "update database connection"
                Try
                    myFileStream.Close()
                    frmDBConnMgr = clsDataAccess.NewfrmConnectionManager
                    With frmDBConnMgr
                        .myFileStream = myFileStream
                        .newconnection = False
                        If .ShowDialog = DialogResult.OK Then
                            Application.Exit()
                        Else
                            myFileStream = New System.IO.FileStream(ConnStringFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                        End If
                    End With

                    Exit Sub
                Catch ex As Exception
                    clsCommon.Prompt_User("error", "An error had occured while the system tried to update connection string: " & ex.Message)
                End Try

                'General Menus
            Case "log off user"
                Try
                    ' Show user log off confirmation, then hide main form when user proceeds.
                    Dim iAns
                    iAns = clsCommon.Prompt_User("question", "Current user will be logged off from the system." & vbCrLf & vbCrLf & "Do you want to continue log off?")
                    If iAns = vbYes Then
                        frmDashBoard.Hide()
                        'Me.Hide()

                        For Each ChildForm As Form In Me.MdiChildren
                            If ChildForm.Name <> "frmDashBoard" Then
                                ChildForm.Close()
                            End If
                        Next

                        clsMain.SystemUserOnlineUpdate(App_UserID, 0)

                        frmLoginForm = clsDataAccess.NewfrmLogin(1)
                        With frmLoginForm
                            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                                If .App_User = .password Then
                                    isRequiredToChangePassword = True
                                Else
                                    isRequiredToChangePassword = False
                                End If



                                App_User = .App_User
                                App_UserID = .App_UserID
                                App_FName = .App_FName
                                App_LName = .App_LName
                                Role_ID = .Role_ID
                                App_Role = .App_Role
                                Job_Desc = .Job_Desc

                                Current_Date = .Current_Date

                                SetFormState()
                                Me.Show()

                                With frmDashBoard
                                    .set_form(Me)
                                    .Show()
                                End With
                            End If
                        End With


                        If isRequiredToChangePassword Then
                            frmChangePasswordForm = clsDataAccess.NewfrmChangePassword(App_UserID)
                            frmChangePasswordForm.ShowDialog()
                        End If
                    End If
                Catch ex As Exception

                End Try
            Case "exit"
                Try
                    Dim iAns

                    iAns = clsCommon.Prompt_User("question", MSGBOX_EXIT_CONFIRMATION)
                    If iAns = vbYes Then
                        clsMain.SystemUserOnlineUpdate(App_UserID, 0)
                        With clsMain
                            .int_LogType = "System Exit Event"
                            .int_LogDetail = App_User & " user terminated application normally."
                            .int_UserID = App_UserID
                            .SystemLogSave()
                        End With
                        chat.isEnding = True
                        Global.System.Windows.Forms.Application.Exit()
                    End If
                Catch ex As Exception
                    clsCommon.Prompt_User("error", "An error had occured while the system tried to dispose dock panel while closing: " & ex.Message)
                End Try
            Case "system lock"
                Try
                    Me.Hide()

                    For Each ChildForm As Form In Me.MdiChildren
                        ChildForm.Close()
                    Next

                    With clsMain
                        .int_LogType = "System Lock Event"
                        .int_LogDetail = App_User & " user initiated system lock."
                        .int_UserID = App_UserID
                        .SystemLogSave()
                    End With

                    frmSystemLockForm = clsDataAccess.NewfrmSystemLock(App_User)
                    With frmSystemLockForm
                        If .ShowDialog = Windows.Forms.DialogResult.OK Then
                            Me.Show()
                        End If
                    End With
                Catch ex As Exception

                End Try
            Case ("&about " & LCase(modApp.AssemblyTitle) + "-alps")
                Try
                    frmAboutForm = clsDataAccess.NewfrmAbout
                    frmAboutForm.ShowDialog()
                Catch ex As Exception
                End Try
                BottomIconAdd("about")
            Case "chat"
                showChat()
            Case "change password"
                frmChangePasswordForm = clsDataAccess.NewfrmChangePassword(App_UserID)
                frmChangePasswordForm.ShowDialog()
            Case "calculator"
                Try
                    Dim pinfo As New ProcessStartInfo("CALC")
                    Dim p As Process = System.Diagnostics.Process.Start(pinfo)
                    Threading.Thread.Sleep(1000)
                    Common.Common.SetParent(p.MainWindowHandle, Me.Handle)
                    Common.Common.ShowWindow(p.MainWindowHandle, SW_NORMAL)
                Catch ex As Exception

                End Try
            Case "launch ms word"
                Try
                    Dim pinfo As New ProcessStartInfo("WINWORD")
                    Dim p As Process = System.Diagnostics.Process.Start(pinfo)
                    p.WaitForInputIdle()
                    Common.Common.SetParent(p.MainWindowHandle, Me.Handle)
                Catch ex As Exception

                End Try
            Case "launch ms excel"
                Try
                    Dim pinfo As New ProcessStartInfo("EXCEL")
                    Dim p As Process = System.Diagnostics.Process.Start(pinfo)
                    p.WaitForInputIdle()
                    Common.Common.SetParent(p.MainWindowHandle, Me.Handle)
                Catch ex As Exception

                End Try
            Case ("&about " & LCase(modApp.AssemblyTitle))
                Try
                    frmAboutForm = clsDataAccess.NewfrmAbout
                    frmAboutForm.ShowDialog()
                Catch ex As Exception

                End Try
            Case "&arrange icons"
                Me.LayoutMdi(MdiLayout.ArrangeIcons)
            Case "&cascade"
                Me.LayoutMdi(MdiLayout.Cascade)
            Case "c&lose all windows"
                Dim ctl As Control
                Dim frmMdiChild As Form
                For Each ctl In Me.MdiChildren
                    Try
                        ' Attempt to cast the control to type Form.
                        frmMdiChild = CType(ctl, Form)
                        frmMdiChild.Close()
                    Catch ex As Exception
                        ' Catch and ignore the error if Exception.
                        clsCommon.Prompt_User("Error while checking if the ChildForm is loaded.", ex.Message)
                    End Try
                Next
            Case "tile hori&zontally"
                Me.LayoutMdi(MdiLayout.TileHorizontal)
            Case "tile &vertically"
                Me.LayoutMdi(MdiLayout.TileVertical)
            Case "minimize all windows"
                Dim ctl As Control
                Dim frmMdiChild As Form
                For Each ctl In Me.MdiChildren
                    Try
                        ' Attempt to cast the control to type Form.
                        frmMdiChild = CType(ctl, Form)
                        frmMdiChild.WindowState = FormWindowState.Minimized
                    Catch ex As Exception
                        ' Catch and ignore the error if Exception.
                        clsCommon.Prompt_User("Error while checking if the ChildForm is loaded.", ex.Message)
                    End Try
                Next

                'Spatial Look-up Tables
            Case "country"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmCountryFinder

                LoadForm("frmCountryFinder", objForm)
                BottomIconAdd("country")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "region"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmRegionFinder

                LoadForm("frmRegionFinder", objForm)
                BottomIconAdd("region")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "province"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmProvinceFinder

                LoadForm("frmProvinceFinder", objForm)
                BottomIconAdd("province")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "district"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmDistrictFinder

                LoadForm("frmDistrictFinder", objForm)

                BottomIconAdd("district")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "city / municipality"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmMunicipalityFinder

                LoadForm("frmMunicipalityFinder", objForm)
                BottomIconAdd("city / municipality")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "barangay"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmBarangayFinder

                LoadForm("frmBarangayFinder", objForm)
                BottomIconAdd("barangay")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "zip code"
                Dim clsLocations As New Location.Locations(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsLocations.NewfrmZipCodeFinder

                LoadForm("frmZipCodeFinder", objForm)
                BottomIconAdd("zipcode")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'Personnel Module
            Case "local government unit"
                Dim clsPersonnel As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsPersonnel.NewfrmLGUFinder

                LoadForm("frmLGUFinder", objForm)

                BottomIconAdd("local government unit")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "departments"
                Dim clsPersonnel As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsPersonnel.NewfrmDepartmentFinder

                LoadForm("frmDepartmentFinder", objForm)
                BottomIconAdd("departments")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member records"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberFinder

                LoadForm("frmMemberFinder", objForm)

                BottomIconAdd("member record")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "reassign member"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberReassignFinder

                LoadForm("frmMemberReassignFinder", objForm)
                BottomIconAdd("reassign member")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "replace member"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberReplaceFinder

                LoadForm("frmMemberReplaceFinder", objForm)
                BottomIconAdd("replace member")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "retire / fire member"
                Dim clsMembers As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembers.NewfrmMemberRetireFinder

                LoadForm("frmMemberRetireFinder", objForm)
                BottomIconAdd("retire / fire member")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'Utility Module
            Case "banks"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmBankFinder

                LoadForm("frmBankFinder", objForm)
                BottomIconAdd("banks")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "signatory"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmSignatoryFinder

                LoadForm("frmSignatoryFinder", objForm)
                BottomIconAdd("signatory")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "collection type"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmCollectionTypeFinder

                LoadForm("frmCollectionTypeFinder", objForm)
                BottomIconAdd("collection type")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "collection fee"
                Dim clsUtility As New Utility.Utility(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsUtility.NewfrmCollectionFeeFinder

                LoadForm("frmCollectionFeeFinder", objForm)

                'Bookkeeper's Module
                BottomIconAdd("collection fee")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "disbursement type"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmFSFinder
                LoadForm("frmFSFinder", objForm)
                BottomIconAdd("disbursement type")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "financial summary"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmFinancialExpensesSummary
                LoadForm("frmFSReport", objForm)
                BottomIconAdd("financial summary")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "disbursement"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmExpensesFinder
                LoadForm("frmExpensesFinder", objForm)
                BottomIconAdd("disbursement")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

            Case "member information and accounts"
                Dim clsMembership As New Membership.Membership(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembership.NewfrmMemberInfoAndAccountsFinder

                LoadForm("frmMemberInfoAndAccountsFinder", objForm)
                BottomIconAdd("member info")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

            Case "member contribution billing updater"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionUpdater

                LoadForm("frmMemberContributionUpdater", objForm)
                BottomIconAdd("member contribution billing updater")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member drawings"
                Dim clsTreasurer As New Treasurer.Treasurer(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsTreasurer.NewfrmMemberWithdrawalFinder

                LoadForm("frmMemberWithdrawalFinder", objForm)

            Case "member loan billing updater"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanPaymentUpdater

                LoadForm("frmLoanPaymentUpdater", objForm)
                BottomIconAdd("member loan billing updater")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "member contribution"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionFinder

                LoadForm("frmMemberContributionFinder", objForm)

                BottomIconAdd("member contribution")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

            Case "loan application"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationFinder

                LoadForm("frmLoanApplicationFinder", objForm)
                BottomIconAdd("loan application")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

                '--- By Belonio ---
            Case "type of loans"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmTypeLoanFinder
                LoadForm("frmTypeLoanFinder", objForm)

                BottomIconAdd("type of loans")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "insurance rate"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanRateFinder
                LoadForm("frmLoanRateFinder", objForm)

                BottomIconAdd("insurance rate")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "revision code"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmRevisionFinder
                LoadForm("frmRevisionFinder", objForm)

                BottomIconAdd("revision code")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "variable names"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmrefVariableFinder
                LoadForm("frmrefVariableFinder", objForm)
                '--- End ---
                BottomIconAdd("variable names")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'BOD Module
            Case "loan application approval"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationApprovalFinder
                BottomIconAdd("loan application approval")
                LoadForm("frmLoanApplicationApprovalFinder", objForm)

                'Treasurer's Module
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "loan application release"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationReleaseFinder

                BottomIconAdd("loan application release")
                LoadForm("frmLoanApplicationReleaseFinder", objForm)
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "deposits, loans and miscellaneous payment"
                Dim clsTreasurer As New Treasurer.Treasurer(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsTreasurer.NewfrmPaymentFinder("Deposits, Loans and Miscellaneous")

                LoadForm("frmPaymentFinder", objForm)
                BottomIconAdd("payment")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

            Case "loan and contribution monthly payment"
                Dim clsTreasurer As New Treasurer.Treasurer(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsTreasurer.NewfrmPaymentLoanAndContributionFinder("Loan and Contribution")

                LoadForm("frmPaymentLoanAndContributionFinder", objForm)

                'Member's Module
            Case "member profile"
                Dim clsPersonnel As New Personnel.Personnel(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsPersonnel.NewfrmMember

                LoadForm("frmMember", objForm)

                BottomIconAdd("member profile")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

            Case "accounts"
                Dim clsMembership As New Membership.Membership(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsMembership.NewfrmMemberInfoAndAccounts

                LoadForm("frmMemberInfoAndAccounts", objForm)
                BottomIconAdd("accounts")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

            Case "loan calculator"
                Dim clsBookkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBookkeper.NewfrmLoanCalculator

                LoadForm("frmLoanCalculator", objForm)

                BottomIconAdd("loan calculator")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
            Case "my loan application"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanApplicationFinder

                LoadForm("frmLoanApplicationFinder", objForm)
                BottomIconAdd("loan application")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed

                'Reports
            Case "contribution and payment summary"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmContributionAndPaymentSummary

                LoadForm("frmContributionAndPaymentSummary", objForm)
                BottomIconAdd("contribution and payment summary")
                objForm.TopMost = True
                AddHandler objForm.FormClosed, AddressOf BottomIcon_FormClosed
                'Look-up / Maintenance Tables

            Case "list of checks issued (loans)"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmLoanChecksIssued

                LoadForm("frmLoanChecksIssued", objForm)

            Case "list of offical receipts issued (collections)"
                Dim clsTreasurer As New Treasurer.Treasurer(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsTreasurer.NewfrmOfficialReceiptsIssued

                LoadForm("frmOfficialReceiptsIssued", objForm)

            Case "contribution summary"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionSummary

                LoadForm("frmMemberContributionSummary", objForm)
            Case "member contributions and drawings"
                Dim clsBokkeper As New Bookkeper.Bookkeper(ConnStringFileName, modApp.Path, App_UserID, Role_ID, modApp.AssemblyProduct)
                objForm = clsBokkeper.NewfrmMemberContributionAndDrawing

                LoadForm("frmMemberContributionAndDrawing", objForm)
            Case Else
                clsCommon.Prompt_User("information", item.Text & " module is still under development.")
        End Select

    End Sub

    Private Sub StatusBar()
        Dim blnState As Boolean
        blnState = clsCommon.CheckInetConnection()
        'set panels

        ssMain.Items.Clear()

        Dim objPanel As New ToolStripStatusLabel
        objPanel.ToolTipText = "Current User"
        objPanel.Text = "User : " & App_FName & " " & App_LName
        objPanel.Width = 200
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "System Role"
        objPanel.Text = "Role : " & App_Role
        objPanel.Width = 175
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = ""
        objPanel.Text = ""
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.Spring = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Connection Quality"
        'objPanel.Text = "Connection Quality : " & clsCommon.ConnectionQuality_String
        'objPanel.ForeColor = clsCommon.Connection_Color
        objPanel.Width = 165
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Connection Type"
        'objPanel.Text = "Connection Type : " & clsCommon.ConnectionState_String
        objPanel.Width = 165
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "Database"
        objPanel.Text = "Database: " & UCase(Database_Name)
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = True
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New Common.ToolStripDateTimeStatusLabel
        objPanel.ToolTipText = "Current Time"
        objPanel.Width = 240
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleLeft
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "NUM LOCK"
        objPanel.Text = "NUM"
        objPanel.Width = 35
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleCenter
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "CAPS LOCK"
        objPanel.Text = "CAP"
        objPanel.Width = 35
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleCenter
        ssMain.Items.Add(objPanel)

        objPanel = New ToolStripStatusLabel
        objPanel.ToolTipText = "SCROLL LOCK"
        objPanel.Text = "SCR"
        objPanel.Width = 35
        objPanel.BorderStyle = Border3DStyle.Flat
        objPanel.BorderSides = ToolStripStatusLabelBorderSides.All
        objPanel.AutoSize = False
        objPanel.TextAlign = ContentAlignment.MiddleCenter
        ssMain.Items.Add(objPanel)
    End Sub

    Private Function LoadForm(ByVal strFormName As String, ByRef objForm As Form, Optional ByVal strFormTag As String = "") As Boolean
        'this procedure loads a form based on its name. it activates the form if existing already
        Dim NwObjForm As Form

        If Not clsCommon.CheckIfChildIsLoaded(Me, strFormName, strFormTag) Then
            objForm.MdiParent = Me
            objForm.Show()
            Return True
        Else
            objForm.Dispose()
            NwObjForm = clsCommon.GetMDIChildForm(Me, strFormName, strFormTag)
            NwObjForm.WindowState = FormWindowState.Normal
            NwObjForm.Activate()
            Return False
        End If
    End Function

    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Dim blnState As Boolean
        blnState = clsCommon.CheckInetConnection()
        With ssMain.Items(3)
            .Text = "Connection Quality : " & clsCommon.ConnectionQuality_String
            .ForeColor = clsCommon.Connection_Color
        End With
        ssMain.Items(4).Text = "Connection Type : " & clsCommon.ConnectionState_String

        ssMain.Refresh()
    End Sub

    Private Sub UpdateStatusLabels()
        ssMain.Items(7).ForeColor = IIf(My.Computer.Keyboard.NumLock, Color.Black, Color.LightGray)
        ssMain.Items(8).ForeColor = IIf(My.Computer.Keyboard.CapsLock, Color.Black, Color.LightGray)
        ssMain.Items(9).ForeColor = IIf(My.Computer.Keyboard.ScrollLock, Color.Black, Color.LightGray)
    End Sub

    Private Sub Event_Handler(ByVal strMessage As String, ByVal blnSuccessFl As Boolean) Handles clsMain.MsgArrival
        Me.Cursor = Arrow
        If blnSuccessFl Then
            clsCommon.Prompt_User("information", strMessage)
        Else
            clsCommon.Prompt_User("error", strMessage)
        End If
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            clsMain.SystemUserOnlineUpdate(App_UserID, 0)

            With clsMain
                .int_LogType = "System Exit Event"
                .int_LogDetail = App_User & " user terminated application normally."
                .int_UserID = App_UserID
                .SystemLogSave()
            End With
        Catch ex As Exception
            clsCommon.Prompt_User("error", "An error had occured while the system tried to dispose dock panel while closing: " & ex.Message)
        End Try
    End Sub

    Private Sub frmMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp, tsMain.KeyUp, ssMain.KeyUp
        Me.UpdateStatusLabels()
    End Sub

    Private allowTime As Boolean = True
    Private WithEvents frmNot As New frmNotificationBoard
    Private tsbToolx As New ToolStripDropDownButton
    Private allowOverride As Boolean = True

    Private Function getMinusTime(ByVal dt As Date)
        Dim dateold As New System.DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second)
        Dim datenow As New System.DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, Now.Second)
        Dim diff1 As System.TimeSpan
        diff1 = datenow - dateold

        If diff1.Days = 0 Then
            If diff1.Hours <= 0 Then
                If diff1.Minutes = 1 Then
                    Return "Few Minutes Ago"
                Else
                    Return diff1.Minutes.ToString + " Minutes Ago"
                End If
            ElseIf diff1.Hours = 1 Then
                Return "About an Ago"
            Else
                Return diff1.Hours.ToString + " Hours Ago"
            End If
        ElseIf diff1.Days = 1 Then
            Return "Yesterday at " + dateold.ToString("hh:mm:ss")
        Else
            Return "" + dateold.ToString("MM/dd/yyyy")
        End If
    End Function

    Private Sub reload_Notifications(ByRef ts As ToolStripDropDownButton)
        If allowOverride Then
            Connect(mysql)
            Dim mydata As DataTable = mysql.Query("SELECT *, tbl_notification.NID as 'NIDs' FROM   tbl_notification_user   right JOIN tbl_notification   ON (tbl_notification_user.NID = tbl_notification.NID)   order by DtRecorded desc limit 0,9")
            If mydata.Rows.Count > 0 Then
                ts.DropDownItems.Clear()

                For i As Integer = 0 To mydata.Rows.Count - 1
                    Dim mpFile As New ToolStripMenuItem
                    mpFile.Text = Convert.ToChar(Keys.Tab) + mydata.Rows(i).Item("Nofications").ToString + "           " + getMinusTime(mydata.Rows(i).Item("DtRecorded"))
                    mpFile.TextAlign = ContentAlignment.MiddleLeft
                    ts.DropDownItems.Add(mpFile)
                Next

                mydata = mysql.Query("SELECT * FROM   tbl_notification_user   right JOIN tbl_notification   ON (tbl_notification_user.NID = tbl_notification.NID) where viewMode is NULL")
                tsbToolx.Text = "Notifications (" + mydata.Rows.Count.ToString + ")"
                tsbToolx.BackgroundImage = My.Resources.red
                tsbToolx.ForeColor = Color.Maroon

            Else

                tsbToolx.Text = "Notifications"
                tsbToolx.BackgroundImage = My.Resources.orange
                tsbToolx.ForeColor = Color.Black

            End If
            allowOverride = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If allowTime Then

            Dim mydata As DataTable = mysql.Query("SELECT *, tbl_notification.NID as 'NIDs' FROM   tbl_notification_user   right JOIN tbl_notification   ON (tbl_notification_user.NID = tbl_notification.NID) where viewMode is NULL  limit 0,1")
            Dim frm As New frmNotificationBoard
            If mydata.Rows.Count > 0 Then
                allowOverride = True
                reload_Notifications(tsbToolx)
                With frmNot
                    .opacitys = 0
                    .opa2 = 0.5
                    .NID = mydata.Rows(0).Item("NIDs")
                    .lblHead.Text = mydata.Rows(0).Item("notHeader")
                    .lblContent.Text = mydata.Rows(0).Item("Nofications")
                    allowTime = False
                    .Show()
                End With
            End If
        End If
    End Sub

    Private Sub callBack(ByVal allowT As Boolean) Handles frmNot.CallBack
        allowTime = True
    End Sub

    Private Sub msMain_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles msMain.ItemClicked

    End Sub
End Class
