Imports System.Text
Imports System.IO
Public Class Form1
    Dim LineArg As String
    Dim SaveArg As String
    Dim RandomText As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox3.Text = "" Then 'Random Filename Generator
            RandomText = String.Format("s{0:X7}", New Random().Next(67108864))
            TextBox3.Text = RandomText
        ElseIf TextBox3.Text.Equals(RandomText) Then
            RandomText = String.Format("s{0:X7}", New Random().Next(67108864))
            TextBox3.Text = RandomText
        End If
        If TextBox2.Text = "" Then 'Default: Current Path
            'SaveArg = "m3u8_bin\download.bat " & TextBox1.Text & " """ &  & "\" & TextBox3.Text & ".mp4"""
            TextBox2.Text = My.Application.Info.DirectoryPath
            SaveArg = "m3u8_bin\download.bat " & TextBox1.Text & " """ & TextBox2.Text & "\" & TextBox3.Text & ".mp4"""
        Else
            SaveArg = "m3u8_bin\download.bat " & TextBox1.Text & " """ & TextBox2.Text & "\" & TextBox3.Text & ".mp4"""
        End If
        LineArg = "m3u8_bin\temp.bat"
        Dim myfilepath As String = My.Application.Info.DirectoryPath + "\m3u8_bin\temp.bat"
        Dim sw As StreamWriter = New StreamWriter(myfilepath, False, Encoding.Default)
        sw.Write(SaveArg)
        sw.Close()
        Shell(LineArg, 1)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If My.Computer.Clipboard.ContainsText() Then
            TextBox1.Text = My.Computer.Clipboard.GetText()
        End If
    End Sub
End Class
