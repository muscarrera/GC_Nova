Public Class InvHome

    Event Tracabilite()
    Event Valorisation()
    Event Ajustement()
    Event Transfer()
    Event Livraison()
    Event Reception()

    Event Rapports(ByVal p1 As Boolean)


    Private Sub btRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click, btRec.Click
        RaiseEvent Reception()
    End Sub

    Private Sub btLiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click, btLiv.Click
        RaiseEvent Livraison()
    End Sub

    Private Sub btTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click, btTransfer.Click
        RaiseEvent Transfer()
    End Sub

    Private Sub btAjust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click, btAjust.Click
        RaiseEvent Ajustement()
    End Sub

    Private Sub btValeur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click, btValeur.Click
        RaiseEvent Valorisation()
    End Sub

    Private Sub btTracabilite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click, btTracabilite.Click
        RaiseEvent Tracabilite()
    End Sub

    Private Sub btEntrepote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click, btEntrepote.Click
        Dim stok As New AddEditDepot
        If stok.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
        btEntrepote.Text = stok.dgvctg.Rows.Count & " Entrepôtes"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent Rapports(False)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RaiseEvent Rapports(True)
    End Sub
End Class
