Imports System.IO

Public Class AddFiles

    Public tb_F As String
    Public id As String

    Private Property Str As String = "Join-Files"

    Private Sub AddFiles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetFiles()
    End Sub
    Private Sub GetFiles()
        Try
            Dim sTarget As New DirectoryInfo(Form1.SvgdPah & Str & "\" & tb_F & "\" & id)
            pl.Controls.Clear()

            Dim files() As String = IO.Directory.GetFiles(sTarget.FullName)

            For Each file As String In files
                ' Do work, example
                Dim a As New FileLine

                Dim d As String() = file.Split("\")

                a.Libele = d(d.Length - 1)

                a.Index = pl.Controls.Count
                a.Dock = DockStyle.Top
                a.BringToFront()

                AddHandler a.ViewImages, AddressOf View_SelectedFacture
                AddHandler a.DeleteItem, AddressOf Delete_Item

                pl.Controls.Add(a)
            Next
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using O As New OpenFileDialog With {.Filter = "(Default Files)|*.jpg;*.png;*.pdf;*.doc;*.docx|Jpg, | *.jpg|Png, | *.png|Pdf, | *.pdf|Doc, | *.doc|Docx | *.docx", .Multiselect = False, .Title = "Select Image"}
            Try
                If O.ShowDialog = 1 Then
                    Dim sSource = O.FileName
                    Dim sTarget As New DirectoryInfo(Form1.SvgdPah & Str & "\" & tb_F & "\" & id)

                    If sTarget.Exists = False Then sTarget.Create()

                    File.Copy(sSource, Path.Combine(sTarget.FullName, Path.GetFileName(sSource)), False)
                    GetFiles()
                End If
            Catch ex As Exception
            End Try
        End Using
    End Sub
    Private Sub View_SelectedFacture(ByVal ls As FileLine)

        Dim sTarget As New DirectoryInfo(Form1.SvgdPah & Str & "\" & tb_F & "\" & id)
        If sTarget.Exists = False Then sTarget.Create()
        Process.Start(Path.Combine(sTarget.FullName, ls.Libele))
    End Sub

    Private Sub Delete_Item(ByVal ls As FileLine)
        Dim sTarget As New DirectoryInfo(Form1.SvgdPah & Str & "\" & tb_F & "\" & id)
        If sTarget.Exists = False Then sTarget.Create()
        File.Delete(Path.Combine(sTarget.FullName, ls.Libele))
        GetFiles()
    End Sub

  
End Class