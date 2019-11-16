Imports System.IO

Public Class AddFiles

    Private Property Str As String = "Join-Files"

    Private Sub AddFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub GetFiles()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim dir1 As New DirectoryInfo(Form1.SvgdPah & Str)
        If dir1.Exists = False Then dir1.Create()

       

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim savepic As New OpenFileDialog
        savepic.Filter = "*.*|*.*"
        If savepic.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Dim file As File = savepic.FileName
            'lbPath.Text = savepic.FileName

        End If
    End Sub
End Class