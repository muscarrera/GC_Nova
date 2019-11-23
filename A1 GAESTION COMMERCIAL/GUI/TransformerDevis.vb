Public Class TransformerDevis

    Public tb_F As String
    Public tb_D As String
    Public tb_P As String
    Public Operation As String

    Public Property Mode As String
        Get
            Return "mode"
        End Get
        Set(ByVal value As String)
            cbType.Items.Clear()

            If value = "Devis" Then
                cbType.Items.Add("Commande Client")
                cbType.Items.Add("Bon de Livraison")
                cbType.Items.Add("Facture")

            Else
                cbType.Items.Add("Bon de Commande")
                cbType.Items.Add("Facture d'Achat")
            End If
            cbType.SelectedItem = cbType.Items(0)
        End Set
    End Property
    Public Property Client As String
        Get
            Return "client"
        End Get
        Set(ByVal value As String)
            lbClient.Text = value
        End Set
    End Property
    Public Property Ref As String
        Get
            Return lbRef.Text
        End Get
        Set(ByVal value As String)
            lbRef.Text = value
        End Set
    End Property
    Private Sub TransformerDevis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If cbType.Text = "Commande Client" Then
            tb_D = "Details_Commande"
            tb_F = "Commande_Client"
            tb_P = "Client_Payement"
            Operation = "Commande_Client"

        ElseIf cbType.Text = "Bon de Livraison" Then
            tb_D = "Details_Bon_Livraison"
            tb_F = "Bon_Livraison"
            tb_P = "Client_Payement"
            Operation = "Bon_Livraison"

        ElseIf cbType.Text = "Facture" Then
            tb_D = "Details_Sell_Facture"
            tb_F = "Sell_Facture"
            tb_P = "Client_Payement"
            Operation = "Sell_Facture"

        ElseIf cbType.Text = "Bon de Commande" Then
            tb_D = "Details_Bon_Commande"
            tb_F = "Bon_Commande"
            tb_P = "Company_Payement"
            Operation = "Bon_Commande"

        ElseIf cbType.Text = "Facture d'Achat" Then
            tb_D = "Details_Buy_Facture"
            tb_F = "Buy_Facture"
            tb_P = "Company_Payement"
            Operation = "Buy_Facture"

        ElseIf cbType.Text = "Bon d'Achat" Then
            tb_D = "Details_Bon_Achat"
            tb_F = "Bon_Achat"
            tb_P = "Company_Payement"
            Operation = "Bon_Achat"
        Else
            Exit Sub
        End If

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub txtDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDate.Leave
        Try
            txtDate.text = CDate(txtDate.text).ToString("dd-MM-yyyy")
        Catch ex As Exception
            MsgBox("la date vous avez choisie n'est pas valide")
            txtDate.text = Now.Date.ToString("dd-MM-yyyy")
            txtDate.Focus()
        End Try
    End Sub
End Class