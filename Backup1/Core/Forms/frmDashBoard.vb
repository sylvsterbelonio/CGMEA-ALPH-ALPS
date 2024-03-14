Public Class frmDashBoard

    Public Shared Event Button_Clicked(ByVal cmdName As String)
    Public main_form As frmMain
    Private mysql As New PowerNET8.mySQL.Init.SQL

    Public Sub set_form(ByRef frm As frmMain)
        main_form = frm
    End Sub

    Private Sub frmDashBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'FlowLayoutPanel2.BackgroundImage = My.Resources.Christmas_image_christmas_36118465_1920_1200
        'flp2.BackgroundImage = My.Resources.Christmas_image_christmas_36118465_1920_1200
        'flpIcons.BackgroundImage = My.Resources.img_3894
        Connect(mysql)
        TableLayoutPanel1.BackgroundImage = My.Resources.Christmas_image_christmas_36118465_1920_1200
        reloadShortCutLink()
    End Sub

    Private Sub reloadShortCutLink()
        allowUpdate = False
        For Each obj As Object In FlowLayoutPanel2.Controls
            If TypeOf obj Is PowerNET8.My7GlassButton Then
                CType(obj, PowerNET8.My7GlassButton).Visible = False
            End If
        Next
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblsystemuser_shortcut_link where userID=" + App_UserID.ToString)
        For i As Integer = 0 To mydata.Rows.Count - 1
            buttonAdd(mydata.Rows(i).Item(1))
        Next
        allowUpdate = True
    End Sub

    Private Sub cmdSystemUser_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSystemUser.MouseDown
        If e.Button = MouseButtons.Left Then
            With cmdSystemUser
                Dim size As Size = .Size
                '.Size = New Size(size.Width + 5, size.Height + 5)
            End With
        End If
    End Sub

    Private Sub cmdSystemUser_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdSystemUser.MouseUp
        If e.Button = MouseButtons.Left Then
            With cmdSystemUser
                Dim size As Size = .Size
                '.Size = New Size(size.Width - 5, size.Height - 5)
            End With
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If count > 5 Then
            Timer1.Stop()
            count = 0
            If MsgBox("Do you want to delete this short cut icon? [" + selectedNameButton.Substring(3) + "]", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                buttonRemove(selectedNameButton)
                selectedNameButton = ""
            End If
        Else
            count += 1
        End If
    End Sub

    Private count As Integer = 0
    Private selectedNameButton As String = ""
    Private allowUpdate As Boolean = False

    Private Sub buttonAdd(ByVal name As String)
        Select Case name
            Case "System Users", "cmdSystemUser"
                cmdSystemUser.Visible = True
            Case "System Access Level", "cmdSystemAccess"
                cmdSystemAccess.Visible = True
            Case "cmdMemberInfo"
                cmdMemberInfo.Visible = True
            Case "Member Contribution Generation", "cmdMemberContribution"
                cmdMemberContribution.Visible = True
            Case "Loan Application", "cmdLoan"
                cmdLoan.Visible = True
            Case "Accounts", "cmdAccount"
                cmdAccount.Visible = True
            Case "Calculator", "cmdCalculator"
                cmdCalculator.Visible = True
            Case "&About CGMEA-ALPS", "cmdAbout"
                cmdAbout.Visible = True
            Case "Loan Application Approval", "cmdLoanApplicationApproval"
                cmdLoanApplicationApproval.Visible = True
            Case "cmdLoanApplicationRelease", "Loan Application Release"
                cmdLoanApplicationRelease.Visible = True
            Case "cmdExpenses", "Expenses"
                cmdExpenses.Visible = True
            Case "cmdFinancialExpenses", "Financial Expenses"
                cmdFinancialExpenses.Visible = True
            Case "cmdMemberLoanPaymentGenerator", "Member Loan Payment Updater"
                cmdMemberLoanPaymentGenerator.Visible = True
            Case "cmdMemberInformationAndAccounts", "Member Information and Accounts"
                cmdMemberInformationAndAccounts.Visible = True
            Case "cmdMemberContributon2", "Member Contribution"
                cmdMemberContributon2.Visible = True
            Case "cmdMyLoanApplication", "My Loan Application"
                cmdMyLoanApplication.Visible = True
            Case "cmdMemberProfile", "Member Profile"
                cmdMemberProfile.Visible = True
            Case "cmdMemberRecord", "Member Records"
                cmdMemberRecord.Visible = True
            Case "cmdLocalGovernmentUnit", "Local Government Unit"
                cmdLocalGovernmentUnit.Visible = True
            Case "cmdDepartment", "Departments"
                cmdDepartment.Visible = True
            Case "cmdReassignMember", "Reassign Member"
                cmdReassignMember.Visible = True
            Case "cmdReplaceMember", "Replace Member"
                cmdReplaceMember.Visible = True
        End Select
        If allowUpdate Then updateUserCreateShortCutIcons()
    End Sub

    Private Sub buttonRemove(ByVal name As String)
        Select Case name
            Case "cmdAbout"
                cmdAbout.Visible = False
            Case "cmdCalculator"
                cmdCalculator.Visible = False
            Case "cmdAccount"
                cmdAccount.Visible = False
            Case "cmdLoan"
                cmdLoan.Visible = False
            Case "cmdMemberContribution"
                cmdMemberContribution.Visible = False
            Case "cmdMemberInfo"
                cmdMemberInfo.Visible = False
            Case "cmdSystemAccess"
                cmdSystemAccess.Visible = False
            Case "cmdSystemUser"
                cmdSystemUser.Visible = False
            Case "cmdLoanApplicationRelease"
                cmdLoanApplicationRelease.Visible = False
            Case "cmdLoanApplicationApproval"
                cmdLoanApplicationApproval.Visible = False
            Case "cmdExpenses"
                cmdExpenses.Visible = False
            Case "cmdFinancialExpenses"
                cmdFinancialExpenses.Visible = False
            Case "cmdMemberLoanPaymentGenerator"
                cmdMemberLoanPaymentGenerator.Visible = False
            Case "cmdMemberInformationAndAccounts"
                cmdMemberInformationAndAccounts.Visible = False
            Case "cmdMemberContributon2"
                cmdMemberContributon2.Visible = False
            Case "cmdMyLoanApplication"
                cmdMyLoanApplication.Visible = False
            Case "cmdMemberProfile"
                cmdMemberProfile.Visible = False
            Case "cmdMemberRecord"
                cmdMemberRecord.Visible = False
            Case "cmdLocalGovernmentUnit"
                cmdLocalGovernmentUnit.Visible = False
            Case "cmdDepartment"
                cmdDepartment.Visible = False
            Case "cmdReassignMember"
                cmdReassignMember.Visible = False
            Case "cmdReplaceMember"
                cmdReplaceMember.Visible = False
        End Select
        updateUserCreateShortCutIcons()
    End Sub

    Private Sub cmdAbout_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdAbout.MouseDown, cmdCalculator.MouseDown, cmdAccount.MouseDown, cmdLoan.MouseDown, cmdMemberContribution.MouseDown, cmdMemberInfo.MouseDown, cmdSystemAccess.MouseDown, cmdSystemUser.MouseDown, cmdLoanApplicationApproval.MouseDown, cmdLoanApplicationRelease.MouseDown, cmdExpenses.MouseDown, _
                                   cmdFinancialExpenses.MouseDown, cmdMemberLoanPaymentGenerator.MouseDown, cmdMemberInformationAndAccounts.MouseDown, cmdMemberContributon2.MouseDown, cmdMyLoanApplication.MouseDown, cmdMemberProfile.MouseDown, _
                                   cmdMemberRecord.MouseDown, cmdLocalGovernmentUnit.MouseDown, cmdDepartment.MouseDown, _
                                   cmdReassignMember.MouseDown, cmdReplaceMember.MouseDown
        selectedNameButton = CType(sender, Button).Name
        Timer1.Start()
        count = 0
    End Sub

    Private Sub cmdAbout_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdAbout.MouseUp, cmdCalculator.MouseUp, cmdAccount.MouseUp, cmdLoan.MouseUp, cmdMemberContribution.MouseUp, cmdMemberInfo.MouseUp, cmdSystemAccess.MouseUp, cmdSystemUser.MouseUp, cmdLoanApplicationApproval.MouseUp, cmdLoanApplicationRelease.MouseUp, cmdExpenses.MouseUp, _
                                cmdFinancialExpenses.MouseUp, cmdMemberLoanPaymentGenerator.MouseUp, cmdMemberInformationAndAccounts.MouseUp, cmdMemberContributon2.MouseUp, cmdMyLoanApplication.MouseUp, cmdMemberProfile.MouseUp, _
                                cmdMemberRecord.MouseUp, cmdLocalGovernmentUnit.MouseUp, cmdDepartment.MouseUp, _
                                cmdReassignMember.MouseUp, cmdReplaceMember.MouseUp
        count = 0
        Timer1.Stop()
    End Sub

    Private Sub cmd_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSystemUser.MouseHover, cmdSystemAccess.MouseHover, cmdMemberInfo.MouseHover, cmdLoan.MouseHover, cmdCalculator.MouseHover, cmdAbout.MouseHover, cmdMemberContribution.MouseHover, cmdAccount.MouseHover, cmdLoanApplicationApproval.MouseHover, cmdExpenses.MouseHover, _
                                cmdFinancialExpenses.MouseHover, cmdLoanApplicationRelease.MouseHover, cmdMemberLoanPaymentGenerator.MouseHover, cmdMemberInformationAndAccounts.MouseHover, cmdMemberContributon2.MouseHover, cmdMyLoanApplication.MouseHover, cmdMemberProfile.MouseHover, _
                                cmdMemberRecord.MouseHover, cmdLocalGovernmentUnit.MouseHover, cmdDepartment.MouseHover, cmdReassignMember.MouseHover, _
                                cmdReplaceMember.MouseHover
        Select Case CType(sender, PowerNET8.My7GlassButton).Name
            Case "cmdSystemUser"
                ToolTip1.Show("System Users", sender)
            Case "cmdSystemAccess"
                ToolTip1.Show("System Access Level", sender)
            Case "cmdMemberInfo"
                ToolTip1.Show("Member Information and Accounts", sender)
            Case "cmdMemberContribution"
                RaiseEvent Button_Clicked("Member Contribution")
            Case "cmdLoan"
                RaiseEvent Button_Clicked("Application of Loan")
            Case "cmdAccount"
                RaiseEvent Button_Clicked("My Account")
            Case "cmdCalculator"
                ToolTip1.Show("Calculator", sender)
            Case "cmdAbout"
                ToolTip1.Show("About", sender)
            Case "cmdLoanApplicationApproval"
                ToolTip1.Show("Loan Application Approval", sender)
            Case "cmdLoanApplicationRelease"
                ToolTip1.Show("Loan Application Release", sender)
            Case "cmdExpenses"
                ToolTip1.Show("Exepenses", sender)
            Case "cmdFinancialExpenses"
                ToolTip1.Show("Financial Expenses", sender)
            Case "cmdMemberLoanPaymentGenerator"
                ToolTip1.Show("Member Loan Payment Updater", sender)
            Case "cmdMemberInformationAndAccounts"
                ToolTip1.Show("Member Information and Accounts", sender)
            Case "cmdMemberContributon2"
                ToolTip1.Show("Member Contribution", sender)
            Case "cmdMyLoanApplication"
                ToolTip1.Show("My Loan Application", sender)
            Case "cmdMemberProfile"
                ToolTip1.Show("Member Profile", sender)
            Case "cmdMemberRecord"
                ToolTip1.Show("Member Record", sender)
            Case "cmdLocalGovernmentUnit"
                ToolTip1.Show("Local Government Unit", sender)
            Case "cmdDepartment"
                ToolTip1.Show("Departments", sender)
            Case "cmdReassignMember"
                ToolTip1.Show("Reassign Member", sender)
            Case "cmdReplaceMember"
                ToolTip1.Show("Replace Member", sender)
        End Select
    End Sub

    Private Sub cmd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSystemUser.MouseLeave, cmdSystemAccess.MouseLeave, cmdMemberInfo.MouseLeave, cmdLoan.MouseLeave, cmdCalculator.MouseLeave, cmdAbout.MouseLeave, cmdMemberContribution.MouseLeave, cmdAccount.MouseLeave, cmdLoanApplicationApproval.MouseLeave, cmdExpenses.MouseLeave, _
                                cmdFinancialExpenses.MouseLeave, cmdLoanApplicationRelease.MouseLeave, cmdMemberLoanPaymentGenerator.MouseLeave, cmdMemberContributon2.MouseLeave, cmdMemberInformationAndAccounts.MouseLeave, cmdMemberProfile.MouseLeave, _
                                cmdMemberRecord.MouseLeave, cmdLocalGovernmentUnit.MouseLeave, cmdDepartment.MouseLeave, cmdReassignMember.MouseLeave, _
                                cmdReplaceMember.MouseLeave
        ToolTip1.Hide(sender)
    End Sub

    Private Sub cmdSystemUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSystemUser.Click, cmdSystemAccess.Click, cmdCalculator.Click, cmdAbout.Click, cmdMemberInfo.Click, cmdLoan.Click, cmdMemberContribution.Click, cmdAccount.Click, cmdLoanApplicationApproval.Click, cmdExpenses.Click, _
                                cmdFinancialExpenses.Click, cmdLoanApplicationRelease.Click, cmdMemberLoanPaymentGenerator.Click, cmdMemberInformationAndAccounts.Click, cmdMemberContributon2.Click, cmdMyLoanApplication.Click, cmdMemberProfile.Click, _
                                cmdMemberRecord.Click, cmdDepartment.Click, cmdLocalGovernmentUnit.Click, cmdReassignMember.Click, _
                                cmdReplaceMember.Click
        Select Case CType(sender, PowerNET8.My7GlassButton).Name
            Case "cmdSystemUser"
                RaiseEvent Button_Clicked("system users")
            Case "cmdSystemAccess"
                RaiseEvent Button_Clicked("system access level")
            Case "cmdCalculator"
                RaiseEvent Button_Clicked("calculator")
            Case "cmdMemberInfo"
                RaiseEvent Button_Clicked("member info")
            Case "cmdMemberContribution"
                RaiseEvent Button_Clicked("contribution")
            Case "cmdLoan"
                RaiseEvent Button_Clicked("loan")
            Case "cmdAccount"
                RaiseEvent Button_Clicked("accout")
            Case "cmdAbout"
                RaiseEvent Button_Clicked("about")
            Case "cmdLoanApplicationApproval"
                RaiseEvent Button_Clicked("loan application approval")
            Case "cmdLoanApplicationRelease"
                RaiseEvent Button_Clicked("loan application release")
            Case "cmdExpenses"
                RaiseEvent Button_Clicked("expenses")
            Case "cmdFinancialExpenses"
                RaiseEvent Button_Clicked("financial expenses")
            Case "cmdMemberLoanPaymentGenerator"
                RaiseEvent Button_Clicked("member loan payment updater")
            Case "cmdMemberInformationAndAccounts"
                RaiseEvent Button_Clicked("member information and accounts")
            Case "cmdMemberContributon2"
                RaiseEvent Button_Clicked("member contribution")
            Case "cmdMyLoanApplication"
                RaiseEvent Button_Clicked("my loan application")
            Case "cmdMemberProfile"
                RaiseEvent Button_Clicked("member profile")
            Case "cmdMemberRecord"
                RaiseEvent Button_Clicked("member record")
            Case "cmdLocalGovernmentUnit"
                RaiseEvent Button_Clicked("local government unit")
            Case "cmdDepartment"
                RaiseEvent Button_Clicked("departments")
            Case "cmdReassignMember"
                RaiseEvent Button_Clicked("reassign member")
            Case "cmdReplaceMember"
                RaiseEvent Button_Clicked("replace member")
        End Select
    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click

        Do Until flpIcons.Controls.Count = 1
            flpIcons.Controls.RemoveAt(1)
        Loop
        flpIcons.Visible = False
        cmdClearAll.Visible = False
        RaiseEvent Button_Clicked("remove all")

    End Sub

    Private Sub updateUserCreateShortCutIcons()
        mysql.Query("DELETE FROM tblsystemuser_shortcut_link where userID=" + App_UserID.ToString)
        For Each obj As Object In FlowLayoutPanel2.Controls
            If TypeOf obj Is PowerNET8.My7GlassButton Then
                If CType(obj, PowerNET8.My7GlassButton).Visible Then
                    With mysql
                        .setTable("tblsystemuser_shortcut_link")
                        .addValue(App_UserID, "userID")
                        .addValue(CType(obj, PowerNET8.My7GlassButton).Name, "shortCutLink")
                        .Insert()
                    End With
                End If
            End If
        Next
    End Sub

    Private Sub FlowLayoutPanel2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles FlowLayoutPanel2.MouseHover
        If Not main_form.seletecedIcons Is Nothing Then
            If main_form.seletecedIcons <> "" Then
                buttonAdd(main_form.seletecedIcons)
                'MsgBox(main_form.seletecedIcons)
                main_form.seletecedIcons = ""
            End If
        End If
    End Sub

    Private Sub TableLayoutPanel1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableLayoutPanel1.MouseClick
        Me.SendToBack()
    End Sub

    Private Sub TableLayoutPanel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub

    Private Sub FlowLayoutPanel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles FlowLayoutPanel2.Paint

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.SendToBack()
    End Sub
End Class