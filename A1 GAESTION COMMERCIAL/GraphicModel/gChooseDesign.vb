Imports System.IO

Public Class gChooseDesign

    Public localName As String = ""


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If localName = "" Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub gChooseDesign_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\Prt_Dsn")
        If dir1.Exists = False Then dir1.Create()

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Dim fi As IO.FileInfo

        For Each fi In aryFi
            Dim bt As New Button
            bt.Text = fi.Name

            AddHandler bt.Click, AddressOf bt_Click
            bt.Dock = DockStyle.Top
            pl.Controls.Add(bt)
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\Prt_Dsn")
        If dir1.Exists = False Then dir1.Create()

        Dim n = InputBox("Nom de Model", "Impression", "Default")
        If n.Length < 3 Then Exit Sub
        localName = n & ".dat"

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Try
            Dim fi As IO.FileInfo = aryFi(0)
            Dim nm = fi.Name
            Dim g As New gGlobClass
            g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & nm)
            WriteToXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localName, g)

        Catch ex As Exception
            Dim g As New gGlobClass

            WriteToXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localName, g)
        End Try

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub bt_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim bt As Button = sender
            localName = bt.Text

            For Each b As Button In pl.Controls
                b.FlatStyle = FlatStyle.Standard
            Next
            bt.FlatStyle = FlatStyle.Flat
        Catch ex As Exception

        End Try
    End Sub

End Class