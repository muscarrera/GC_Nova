Public Class NouveauFacture

    Public cid As Integer
    Public cName As Integer
    Public dte As Date
    Public tb_C As String


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click, Label1.Click, plExerces.Click, Label2.Click, Panel3.Click, lbDate.Click
        txtName.Focus()
    End Sub

    Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtName.text = "" Then
            cName = "_"
            cid = 0
        Else
            If txtName.text.Contains("|") Then

                cName = txtName.text.Split("|")(0)
                cid = txtName.text.Split("|")(1)
            Else
                cName = txtName.text
                cid = 0
            End If
        End If
    End Sub

    Private Sub TextBox2_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDate.Leave
        If Not IsDate(TxtDate.Text) Then
            dte = Now.Date
            TxtDate.Text = Now.Date.ToString("dd-MM-yyyy")
        Else
            dte = CDate(TxtDate.Text)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If txtName.Text = "" Then Exit Sub
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub NouveauFacture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtExr.Text = Form1.Exercice
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CC As New ChooseClient
        CC.tb_C = tb_C
        If CC.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtName.text = CC.clientName & "|" & CC.cid
        End If
    End Sub
End Class