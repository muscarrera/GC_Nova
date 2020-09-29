Imports System.IO

Public Class LoadCompanies


    Public dataName As String

    Private Sub LoadCompanies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim di As DirectoryInfo = New DirectoryInfo("path")
        'Dim ls = di.GetDirectories()

        Try
            Dim i = 1
            For Each Dir As String In Directory.GetDirectories(Form1.Data_Comp_Path)
                Dim cb As New CompanyBloc
                Dim dirInfo As New System.IO.DirectoryInfo(Dir)
                cb.DataName = dirInfo.Name
                cb.Dock = DockStyle.Top

                AddHandler cb.Activated, AddressOf cb_Activated
                pl.Controls.Add(cb)

                i += 1
                If i > 4 Then Exit Sub
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cb_Activated(ByVal cb As CompanyBloc, ByVal b As Boolean)
        dataName = cb.DataName

        If b = False Then

            dataName = ""
            Exit Sub

        End If


        For Each c As CompanyBloc In pl.Controls
            If c.DataName <> cb.DataName Then c.active = False
        Next

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        If dataName = "" Then
            MsgBox("vous n'avais pas choisir aucune société", MsgBoxStyle.Exclamation, "CMC Pro")
            End
        End If

        Form1.BoundDbPath = Form1.Data_Comp_Path & "\" & dataName & "\ALMohassinDB.mdb"

        Using a As BoundClass = New BoundClass
            a.ChangeConnectionString()
        End Using

        Form1.lbNameComp.Text = dataName
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class