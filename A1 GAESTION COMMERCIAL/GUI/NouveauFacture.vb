Public Class NouveauFacture

    Public cid As Integer
    Public cName As String
    Public dte As Date
    Public isBlocked As Boolean = False
    Public tb_C As String = "Client"


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
        cName = cName.ToUpper
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
            cName = CC.clientName
            cid = CC.cid
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If cName.Trim = "_" Or cName.Trim = "" Then Exit Sub
        If cid > 0 Then
            Dim Cl As New Client(cid, tb_C)
            If Cl.name.ToUpper <> cName.ToUpper Then
                txtName.Focus()
                Exit Sub
            End If
            If Form1.useAccessClient Then isBlocked = Cl.isBlocked
        Else
            If MsgBox("créer un compte Client" & vbNewLine & "Nom: " & cName, MsgBoxStyle.YesNo, "Nouveau Client") = MsgBoxResult.Yes Then
                Dim x = AddEditElement()
                cid = x
                txtName.text = cName & "|" & cid

            Else
                Exit Sub
            End If
        End If
        cName = cName.ToUpper
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Function AddEditElement() As Integer

        Dim params As New Dictionary(Of String, Object)
        params.Add("ref", cName)
        params.Add("name", cName)
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

        Dim x As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            x = a.InsertRecord(tb_C, params)
        End Using

        Return x
    End Function




    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class