Public Class InvTracability

    Event Search(ByRef ds As InvTracability)

    Private Sub btInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.Click
        Dim sr As New SearchForArticle

        If sr.ShowDialog = DialogResult.OK Then
            txt.text = sr._name & "|" & sr.arid
        End If
    End Sub
    Private Sub btDepot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDepot.Click
        Dim clc As New ChooseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.dpid = 0 Then
                txtDepot.text = ""
            Else
                txtDepot.text = clc.dpName & "|" & clc.dpid
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent Search(Me)

        If dg_D.Rows.Count = 0 Then Exit Sub
        ' select depot name
    End Sub
End Class
