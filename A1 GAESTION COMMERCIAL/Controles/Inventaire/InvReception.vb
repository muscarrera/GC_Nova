Public Class InvReception

    Dim _mode As String

    Public tb_C As String
    Public tb_B As String
    Public tb_D As String

    Event Search(ByRef ds As InvReception)
    Event Apercu(ByRef ds As InvReception)
    Event Print(ByRef ds As InvReception)


    Public Property Mode As String
        Get
            Return _mode
        End Get
        Set(ByVal value As String)
            _mode = value

        End Set
    End Property


    Private Sub InvReception_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent Search(Me)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Mode <> "LIST" Then Exit Sub
        If Form1.plBody.Controls.Count = 0 Then Exit Sub
        If Not TypeOf pl.Controls(0) Is DataGridView Then Exit Sub
 
        Dim dg As DataGridView = pl.Controls(0)
        If dg.SelectedRows.Count = 0 Then Exit Sub

        RaiseEvent Apercu(Me)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RaiseEvent Print(Me)
    End Sub
End Class
