Public Class NouveauFacture

    Public cid As Integer
    Public cName As String
    Public dte As Date
    Public tb_C As String


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        txtName.Focus()
    End Sub

    Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Leave
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
    Private Sub NouveauFacture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtExr.Text = Form1.Exercice
        Me.Show()
        txtName.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CC As New ChooseClient
        CC.tb_C = tb_C
        If CC.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtName.text = CC.clientName & "|" & CC.cid
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class