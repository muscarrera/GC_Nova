Public Class ModePayement

    Public mode As String = ""
    Private btn As New Button

    Private Sub ModePayement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddButton("Cache", My.Resources.Resources.iconfinder_Money_22)
        AddButton("Cheque", My.Resources.Resources.iconfinder_document_open_23214__1_)
        AddButton("Trait/Effet", My.Resources.Resources.iconfinder_document_open_23214__1_)
        AddButton("Virement bancaire", My.Resources.Resources.iconfinder_Cash_register_73439)


        Dim str = getRegistryinfo("ModePayement", "")
        If str = "" Then Exit Sub
        Dim m As String() = str.Split("|")
        For i As Integer = 0 To m.Length - 1
            If m(i) = "" Then Continue For
            AddButton(m(i), Nothing)
        Next

    End Sub
    Private Sub AddButton(ByVal txt As String, ByVal img As Image)
        Dim bt As New Button
        bt.Text = txt
        bt.Width = 300
        bt.Height = 44

        If Not IsNothing(img) Then
            bt.Image = img
            bt.ImageAlign = ContentAlignment.MiddleLeft
            bt.Tag = "Origin"
        End If
        AddHandler bt.Click, AddressOf Button_Click
        AddHandler bt.MouseDown, AddressOf Button_MouseDown
        AddHandler bt.MouseUp, AddressOf Button_MouseUp
        fl.Controls.Add(bt)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If txtname.text = "" Then Exit Sub
        Dim str = getRegistryinfo("ModePayement", "")
        str = str & "|" & txtname.text
        setRegistryinfo("ModePayement", str)

        mode = txtname.text
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim bt As Button = sender

        mode = bt.Text
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim str = getRegistryinfo("ModePayement", "")
        If str = "" Then Exit Sub
        Dim m As String() = str.Split("|")
        str = ""
        For i As Integer = 0 To m.Length - 1
            If btn.Text = m(i) Then Continue For
            If i > 0 Then str &= "|"
            str &= m(i)
        Next
        setRegistryinfo("ModePayement", str)
        fl.Controls.Remove(btn)
    End Sub

    Private Sub Button_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Timer1.Enabled = False

    End Sub

    Private Sub Button_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim bt As Button = sender
        If bt.Tag = "Origin" Then Exit Sub
        btn = bt
        Timer1.Enabled = True
    End Sub

End Class