Public Class ListMultiCodes
    Private _code As String
    Public Property Code() As String
        Get
            If _code.Length > 255 Then _code = _code.Substring(0, 250)
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value

            Filllist()
        End Set
    End Property

    Private Sub Filllist()

        Dim ls = Code.Split("-")
        Panel1.Controls.Clear()

        For i As Integer = 0 To ls.Length - 1
            Dim t As New Tag
            t.key = i
            t.val = ls(i)
            t.Dock = DockStyle.Top

            AddHandler t.DeleteTag, AddressOf DeleteTag

            Panel1.Controls.Add(t)
        Next


    End Sub

    Private Sub DeleteTag(ByVal T As Tag)
        Dim v = T.val
        Dim k = T.key
        Dim newStr As String = ""

        Dim ls = Code.Split("-")

        For i As Integer = 0 To ls.Length - 1

            If i = k And ls(i) = v Then Continue For

            If newStr.Length > 0 Then newStr &= "-"
            newStr &= ls(i)
        Next

        Code = newStr


        txt.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt.text.Trim = "" Then
            txt.Focus()
            Exit Sub
        End If

        Dim str = txt.text

        If Code.Length > 0 Then str = "-" & txt.text

        If Code.Length > 250 Then Exit Sub

        Code = Code & str

        txt.text = ""
        txt.Focus()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class