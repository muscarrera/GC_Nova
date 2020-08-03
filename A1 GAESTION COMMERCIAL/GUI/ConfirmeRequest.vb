Public Class ConfirmeRequest

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TxtBox1.text = "1234" & Date.Now.Day.ToString Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Error")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If
    End Sub
End Class