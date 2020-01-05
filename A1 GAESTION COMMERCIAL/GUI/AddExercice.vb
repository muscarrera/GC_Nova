Public Class AddExercice


    Public EditMode As Boolean = False


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub AddExercice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If EditMode = False Then
            txty.text = Now.Date.ToString("yy")
        End If
        txtz.text = getRegistryinfo("zeros_number", "0000")
        txtn.text = 0
    End Sub
End Class