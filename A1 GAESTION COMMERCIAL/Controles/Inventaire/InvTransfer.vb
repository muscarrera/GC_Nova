Public Class InvTransfer

    Event Print(ByRef ds As InvTransfer)
    Event Search(ByRef ds As InvTransfer)
    Event AddNew(ByRef ds As InvTransfer)

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RaiseEvent Print(Me)
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent Search(Me)
    End Sub
    Private Sub InvTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RaiseEvent Search(Me)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent AddNew(Me)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If pl.Controls.Count > 0 Then
            If TypeOf pl.Controls(0) Is DataGridView Then
                Dim _ds As DataGridView = pl.Controls(0)
                SaveDataToHtml(_ds, "Transfer_Internes")
                Exit Sub
            End If
        End If
    End Sub
End Class
