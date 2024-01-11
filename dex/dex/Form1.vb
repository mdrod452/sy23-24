Imports System.IO

Public Class Form1
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        field1.Text = ""
        field2.Text = ""
        field3.Text = ""
        field4.Text = ""
        field5.Text = ""
        anythingPicture.Image = Nothing
    End Sub

    Private Sub anythingPicture_Click(sender As Object, e As EventArgs) Handles anythingPicture.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        anythingPicture.Load(OpenFileDialog1.FileName)
    End Sub

    Private Sub SaveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem1.Click
        Dim outfile As New StreamWriter("data.txt")
        outfile.Write(field1.Text)
        outfile.Write("|")
        outfile.Write(field2.Text)
        outfile.Write("|")
        outfile.Write(field3.Text)
        outfile.Write("|")
        outfile.Write(field4.text)
        outfile.Write("|")
        outfile.Write(field5.Text)
        outfile.Write("|")
        outfile.WriteLine(anythingPicture.ImageLocation)
    End Sub
End Class
