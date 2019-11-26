Public Class NouveauFacture

    Public cid As Integer
    Public cName As String
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
                Panel1.BackColor = Color.WhiteSmoke
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
        If txtName.text = "" Then Exit Sub

        If txtName.text.Contains("|") Then
            cName = txtName.text.Split("|")(0)
            cid = txtName.text.Split("|")(1)
            Dim params As New Dictionary(Of String, Object)
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add("Clid", cid)
                Dim nm = a.SelectByScalar(tb_C, "name", params)
                If cName.ToUpper <> nm.ToString.ToUpper Then
                    Panel1.BackColor = Color.Bisque
                    txtName.Focus()
                    Exit Sub
                End If
            End Using
        Else
            If MsgBox("Cliquez sur le bouton <b> Oui </b> pour ajouter un nouveau Client",
                      MsgBoxStyle.OkCancel, txtName.text) = MsgBoxResult.Ok Then

                Dim params As New Dictionary(Of String, Object)
                params.Add("ref", txtName.text)
                params.Add("name", txtName.text)
                params.Add("isCompany", True)
                params.Add("groupe", "Client Final")

                params.Add("adresse", "-")
                params.Add("cp", "-")
                params.Add("ville", "-")
                params.Add("ice", "-")

                params.Add("tel", "-")
                params.Add("gsm", "-")
                params.Add("email", "-")
                params.Add("info", "-")

                params.Add("img", "-")


                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    cid = a.InsertRecord(tb_C, params, True)
                End Using
            Else
                Panel1.BackColor = Color.Bisque
                txtName.Focus()
                Exit Sub
            End If
        End If
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