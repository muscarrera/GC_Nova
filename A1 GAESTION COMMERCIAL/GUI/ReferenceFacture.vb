Public Class ReferenceFacture

    Public Property Value As String
        Get
            Return TxtBox1.text
        End Get
        Set(ByVal value As String)
            TxtBox1.text = value
        End Set
    End Property
    Public Property Title As String
        Get
            Return Label2.Text
        End Get
        Set(ByVal value As String)
            Label2.Text = value
        End Set
    End Property

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub TxtBox1_KeyDownOk() Handles TxtBox1.KeyDownOk
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class