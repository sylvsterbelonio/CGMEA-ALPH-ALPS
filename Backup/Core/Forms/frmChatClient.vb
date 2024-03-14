Imports System.Net.Sockets
Imports System.Text
Public Class frmChatClient
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
    Dim readData As String
    Dim infiniteCounter As Integer
    'Dim ctThread As Threading.Thread = New Threading.Thread(AddressOf getMessage)
    Dim curChatmate As String = ""
    Public isEnding As Boolean = False
    Dim chatList As New Hashtable
    Dim sender As String

    Private Sub Send_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If lstClients.SelectedIndex = 0 Then
                sendMsg(txtMessagebox.Text)
            Else
                sendMsg("[sendTo|" + CStr(lstClients.SelectedItem) + "]" + txtMessagebox.Text)
                readData = "[" + txtUserName.Text + "]: " + txtMessagebox.Text
                msg()
            End If
            txtMessagebox.Text = ""
            txtMessagebox.Focus()
        Catch ex As Exception
            readData = "Chat server offline. Please contact systems administrator."
            msg()
            'btnSend.Enabled = False
        End Try

    End Sub

    Private Sub sendMsg(ByVal msg As String)
        Dim outStream As Byte() = _
                System.Text.Encoding.ASCII.GetBytes(msg + "$")
        serverStream.Write(outStream, 0, outStream.Length)
        serverStream.Flush()
    End Sub

    Private Sub addtoClist(ByVal name As String)
        If chatList.Contains(name) <> True Then
            Dim newChatBox = New System.Windows.Forms.TextBox

            newChatBox.BackColor = System.Drawing.SystemColors.ControlLightLight
            newChatBox.Location = New System.Drawing.Point(12, 34)
            newChatBox.Multiline = True
            newChatBox.Name = name
            newChatBox.Text = "PRIVATE CHAT TO [" + name + "]" + vbCrLf
            newChatBox.ReadOnly = True
            newChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            newChatBox.Size = New System.Drawing.Size(551, 283)
            newChatBox.TabIndex = 1
            Me.Controls.Add(newChatBox)
            chatList.Add(name, newChatBox)
        End If
    End Sub

    Private Sub msg()
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New MethodInvoker(AddressOf msg))
            Else
                If readData.Contains("[getList]") Then
                    readData = readData.Replace("[getList]", "")
                    lstClients.Items.Clear()
                    lstClients.Items.Add("CGMEA-ALPS GROUP")
                    Dim clients As String() = readData.Split("|")
                    For Each client As String In clients
                        If client <> txtUserName.Text And client <> "" Then
                            lstClients.Items.Add(client)
                            addtoClist(client)
                        End If
                    Next
                    lstClients.Items.RemoveAt(lstClients.Items.Count - 1)
                    If curChatmate <> "" Then
                        For i As Integer = 0 To lstClients.Items.Count - 1
                            If curChatmate = CStr(lstClients.Items(i)) Then
                                lstClients.SelectedItem = curChatmate
                                Exit For
                            Else
                                lstClients.SelectedIndex = 0
                                txtChatBox.BringToFront()
                            End If
                        Next
                    Else
                        lstClients.SelectedIndex = 0
                        txtChatBox.BringToFront()
                    End If
                    If lstClients.SelectedIndex = 0 Then
                        curChatmate = ""
                    End If

                ElseIf readData.Contains("[private]") Then
                    sender = readData.Replace("[private]", "")
                    sender = sender.Substring(1, sender.IndexOf("]") - 1)

                    Dim cb As TextBox = chatList.Item(sender)
                    cb.Text = cb.Text + Environment.NewLine + readData.Replace("[private]", "") + vbCrLf
                    bgw.ReportProgress(10)
                Else
                    If curChatmate <> "" Then
                        Dim cb As TextBox = chatList.Item(curChatmate)
                        cb.Text = cb.Text + Environment.NewLine + " >> " + readData
                        cb.Select(cb.Text.Length, 0)
                        cb.ScrollToCaret()
                    Else
                        txtChatBox.Text = txtChatBox.Text + Environment.NewLine + " >> " + readData
                        txtChatBox.Select(txtChatBox.Text.Length, 0)
                        txtChatBox.ScrollToCaret()
                    End If
                End If
            End If
        Catch ex As Exception
            readData = "[Error] Please contact systems administrator." + vbCrLf + ex.ToString
            msg()
        End Try
    End Sub

    Private Sub chatNotify(ByVal sender As String)

        For x As Integer = 0 To lstClients.Items.Count - 1
            If CStr(lstClients.Items(x)) = sender And sender <> curChatmate Then
                lstClients.Items(x) = "*" + CStr(lstClients.Items(x))
                Exit Sub
            End If
        Next

    End Sub

    Private Sub removeNotification(ByVal sender As String)
        For x As Integer = 0 To lstClients.Items.Count - 1
            If CStr(lstClients.Items(x)).Contains(sender) Then
                lstClients.Items(x) = CStr(lstClients.Items(x)).Replace("*", "")
                Exit Sub
            End If
        Next
    End Sub

    Private Sub Connect_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs)
        connect()
    End Sub

    Private Sub getMessage()
        Try
            For infiniteCounter = 1 To 2
                infiniteCounter = 1
                serverStream = clientSocket.GetStream()
                Dim buffSize As Integer
                Dim inStream(10024) As Byte
                buffSize = clientSocket.ReceiveBufferSize
                serverStream.Read(inStream, 0, buffSize)
                Dim returndata As String = _
                System.Text.Encoding.ASCII.GetString(inStream)
                readData = "" + returndata
                msg()
            Next
        Catch ex As Exception
            readData = "Chat server offline. Please contact systems administrator."
            msg()
        End Try
    End Sub

    Private Sub frmChatClient_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            sendMsg("[exit]")
            clientSocket.Close()

            'If ctThread.IsAlive Then
            '    'serverStream.Close()
            '    clientSocket.Close()
            '    ctThread.Abort()
            'End If
        Catch ex As Exception
            'serverStream.Close()
            clientSocket.Close()
            'ctThread.Abort()
        End Try
    End Sub

    Private Sub frmChatClient_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If isEnding = False Then
            Me.Visible = False
            e.Cancel = True
        End If
    End Sub

    Private Sub frmChatClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'txtUserName.Text = CStr(DateTime.Now)
        txtUserName.Text = App_FName + " " + App_LName
        'txtUserName.Text = "Zhalick Ortiz"
        connect()
    End Sub

    Private Sub connect()
        Try

            clientSocket.Connect("192.168.0.120", 8888)
            readData = "Conected to Chat Server ..."
            msg()
            'Label1.Text = "Client Socket Program - Server Connected ..."
            serverStream = clientSocket.GetStream()

            Dim outStream As Byte() = _
            System.Text.Encoding.ASCII.GetBytes(txtUserName.Text + "$")
            serverStream.Write(outStream, 0, outStream.Length)
            serverStream.Flush()


            'ctThread.Start()
            bgw.RunWorkerAsync()
            sendMsg("[getList]")
        Catch ex As Exception
            readData = "Chat server offline. Please contact systems administrator."
            msg()
            btnSend.Enabled = False
        End Try

    End Sub

    Private Sub lstClients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstClients.Click
        curChatmate = CStr(lstClients.SelectedItem)
        If Not curChatmate Is Nothing Then
            If curChatmate.Contains("*") Then
                curChatmate = curChatmate.Replace("*", "")
                removeNotification(curChatmate)
            End If

            If curChatmate = "CGMEA-ALPS GROUP" Then
                curChatmate = ""
                txtChatBox.BringToFront()
            Else
                If curChatmate <> "" Then
                    Dim txtbox As TextBox = chatList.Item(curChatmate)
                    txtbox.BringToFront()
                End If
            End If
        End If
    End Sub

    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        getMessage()
    End Sub

    Private Sub bgw_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.BringToFront()
        chatNotify(Me.sender)
    End Sub

    Private Sub txtMessagebox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMessagebox.KeyUp
        If e.Shift <> True And e.KeyCode = Keys.Enter Then
            Send_Click("", New System.EventArgs)
        End If
    End Sub

    Private Sub ListBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lstClients.DrawItem

        e.DrawBackground()



        Dim textBrush As Brush = Brushes.Black

        Dim drawFont As Font = e.Font

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then

            textBrush = Brushes.White
            e.Graphics.FillRectangle(Brushes.DodgerBlue, e.Bounds)

        Else
            If CStr(lstClients.Items(e.Index)).Contains("*") Then
                textBrush = Brushes.White
                e.Graphics.FillRectangle(Brushes.Green, e.Bounds)
            Else
                textBrush = Brushes.Black
            End If
        End If



        ' Draw the current item text based on the current Font and the custom brush settings.

        e.Graphics.DrawString(DirectCast(sender, ListBox).Items(e.Index).ToString(), e.Font, textBrush, e.Bounds, StringFormat.GenericDefault)

        ' If the ListBox has focus, draw a focus rectangle around the selected item.

        e.DrawFocusRectangle()

    End Sub
End Class
