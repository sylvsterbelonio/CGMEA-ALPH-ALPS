Imports PowerNET8.myNumber.Share.Formatter
Public Class frmLoanRate
    Private WithEvents clsCommon As New Common.Common
    Private KeyPressChar As Long
    Private myObject As New PowerNET8.myObject
    Private colObjects As New Collection
    Private mysql As New PowerNET8.mySQL.Init.SQL
    Public rateID As String = "0"
    Public action As String = "add"

    Private Sub initialize()
        Connect(mysql)
        myObject.get_all_objects_data(colObjects, Me)
        If action = "add" Then
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
            txtrateID.Text = getNextID()
            txtrateID.ReadOnly = True
        ElseIf action = "edit" Then
            reloadRecord()
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
            txtrateID.ReadOnly = True
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
        ElseIf action = "view" Then
            reloadRecord()
            myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.Yes)
            clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.view)
        End If
    End Sub

    Private Function formatDigit(ByVal value As Integer) As String
        If value.ToString.Length = 1 Then
            Return "000" + (value + 1).ToString
        ElseIf value.ToString.Length = 2 Then
            Return "00" + (value + 1).ToString
        ElseIf value.ToString.Length = 3 Then
            Return "0" + (value + 1).ToString
        Else
            Return (value + 1).ToString()
        End If
    End Function

    Private Function getNextID() As String
        Dim mydata As DataTable = mysql.Query("SELECT MAX(rateID) from tblinsurancerate")
        If mydata.Rows.Count > 0 Then
            Dim curID As String = mydata.Rows(0).Item(0).ToString.Substring(4)
            Return Now.Year.ToString + formatDigit(Val(curID))
        End If
    End Function

    Private Sub reloadRecord()
        Dim mydata As DataTable = mysql.Query("SELECT * FROM tblinsurancerate where rateId=" + rateID)
        If mydata.Rows.Count > 0 Then
            txtrateID.Text = rateID
            txtLongTerm.Text = mydata.Rows(0).Item("loanTerm")
            txtRateFactor.Text = mydata.Rows(0).Item("rateFactor")
        End If
    End Sub

    Private Sub frmLoanRateFinder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsCommon.Set_Toolbar_Tooltips(Me.tbrMainForm)
        initialize()
    End Sub

    Private Sub tbrMainForm_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrMainForm.ButtonClick
        If TypeOf (sender) Is ToolBar Then
            Select Case e.Button.ImageIndex()
                Case 0 'add
add_rec:
                    rateID = "0"
                    txtRateFactor.Text = ""
                    txtLongTerm.Text = ""
                    clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.add)
                    txtrateID.Text = getNextID()
                    myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
                    txtrateID.ReadOnly = True
                Case 1 'edit
edit_rec:
                    myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.No)
                    txtrateID.ReadOnly = True
                    clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.edit)
                Case 2 'delete
delete_rec:

                Case 3 'find
find_rec:
                    Me.Close()
                Case 4 'save
save_rec:
                    If txtLongTerm.Text <> "" And txtRateFactor.Text <> "" Then
                        With mysql
                            .setTable("tblinsurancerate")
                            .addValue(CDbl(txtLongTerm.Text), "loanTerm")
                            .addValue(CDbl(txtRateFactor.Text), "rateFactor")
                            .addValue(guserID, "updatedBy")
                            .addValue(Now, "updatedDt")
                            If rateID = "0" Then
                                rateID = txtrateID.Text
                                .addValue(txtrateID.Text, "rateId")
                                .addValue(guserID, "createdBy")
                                .addValue(Now, "createdDt")
                                .Insert()
                            Else
                                .Update("rateId", rateID)
                            End If
                        End With
                        MsgBox("You have successfully saved the record.", MsgBoxStyle.Information)

                        If clsCommon.GetRegistrySetting("Add New Record", "Disabled") = "" Then
                            Dim iAns
                            iAns = clsCommon.Prompt_User("yesnocancel", "Do you want to add another record?" & vbCrLf & vbCrLf & "Press 'CANCEL' to disable this functionality.")
                            If iAns = vbYes Then
                                GoTo add_rec
                            ElseIf iAns = vbCancel Then
                                clsCommon.SaveRegistrySetting("Add New Record", "Disabled", "Yes")
                            End If
                        End If
                        myObject.Lock_Mode_All(colObjects, PowerNET8.myObject.Lock.Yes)
                        clsGeneral.setButton(tbrMainForm, clsGeneral.lstButton.view)
                    Else
                        MsgBox("Please enter field of longterm and rate factor")
                    End If
                
                Case 5 'cancel
cancel_rec:
                    Me.Close()
            End Select
            '------------------------------------------------------------------------------
        Else
            'form KeyPress
            '------------------------------------------------------------------------------
            Select Case KeyPressChar
                Case 65537 ' press crtl+a
                    GoTo add_rec
                Case 327685 'press crtl+e
                    GoTo edit_rec
                Case 262148 'press crtl+d
                    GoTo delete_rec
                Case 393222 'press crtl+f
                    GoTo find_rec
                Case 1245203 'press crtl+s
                    GoTo save_rec
                Case 1769499 ' press esc
                    GoTo cancel_rec
            End Select
        End If
    End Sub

    Private Sub txtLongTerm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLongTerm.LostFocus, txtRateFactor.LostFocus
        If Not IsNumeric(CType(sender, TextBox).Text) Then
            sender.text = "0"
        End If
    End Sub

    Private Sub txtLongTerm_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtLongTerm.MouseClick
        sender.selectall()
    End Sub

End Class