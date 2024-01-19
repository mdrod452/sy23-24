Imports System.IO
Imports System.Reflection
Imports System.Security.Cryptography

Public Class Form1
    Dim records(50) As String
    Dim count As Integer
    Dim current As Integer
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        field1.Text = ""
        field2.Text = ""
        field3.Text = ""
        field4.Text = ""
        field5.Text = ""
        anythingPicture.Image = Nothing
        current = count
        count = count + 1
    End Sub

    Private Sub anythingPicture_Click(sender As Object, e As EventArgs) Handles anythingPicture.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        anythingPicture.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim r As String
        r += field1.Text
        r += "|"
        r += field2.Text
        r += "|"
        r += field3.Text
        r += "|"
        r += field4.Text
        r += "|"
        r += field5.Text
        r += "|"
        r += anythingPicture.ImageLocation
        If count = 0 Then count = 1
        records(current) = r
        SaveToFile()
    End Sub
    Sub SaveToFile()
        Dim outfile As New StreamWriter("data.txt")
        For index = 0 To count - 1
            outfile.WriteLine(records(index))
        Next
        outfile.Close()
    End Sub

    Private Sub field_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("data.txt") Then
            Dim infile As New StreamReader("data.txt")
            While (Not infile.EndOfStream)
                records(count) = infile.ReadLine
                count = count + 1
            End While
            infile.Close()
            showrecord(0)
        End If
    End Sub

    Public Sub showrecord(index As Integer)
        If records(index) <> Nothing Then
            Dim fields() As String
            fields = records(index).Split("|")
            field1.Text = fields(0)
            field2.Text = fields(1)
            field3.Text = fields(2)
            field4.Text = fields(3)
            field5.Text = fields(4)
            If File.Exists(fields(5)) Then
                anythingPicture.Load(fields(5))
            End If
        End If
    End Sub

    Private Sub First_Click(sender As Object, e As EventArgs) Handles firstb.Click
        current = 0
        showrecord(current)
    End Sub

    Private Sub Last_Click(sender As Object, e As EventArgs) Handles lastb.Click
        If count > 0 Then
            current = count - 1
            showrecord(current)
        End If
    End Sub

    Private Sub Previous_Click(sender As Object, e As EventArgs) Handles previousb.Click
        If current > 0 Then
            current = current - 1
        End If
        showrecord(current)
    End Sub

    Private Sub Next_Button_Click(sender As Object, e As EventArgs) Handles nextb.Click
        If current < count - 1 Then
            current = current + 1
            showrecord(current)
        End If
    End Sub
End Class