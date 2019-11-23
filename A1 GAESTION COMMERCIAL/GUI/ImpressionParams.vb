Public Class ImpressionParams
    Public isProformat As Boolean = False

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btProformat.Click
        Form1.Facture_Title = "Facture Proformat"
        isProformat = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        isProformat = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class