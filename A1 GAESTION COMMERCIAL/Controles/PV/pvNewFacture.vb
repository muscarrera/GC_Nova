Public Class pvNewFacture

    Public isNormal = True
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click, Button1.Click, OvalShape2.Click

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel3.Click, Button2.Click, OvalShape1.Click
        isNormal = False
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class