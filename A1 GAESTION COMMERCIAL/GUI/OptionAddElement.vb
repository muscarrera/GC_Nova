Public Class OptionAddElement
    Public value As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        value = 2
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        value = 1
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        value = 0
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class