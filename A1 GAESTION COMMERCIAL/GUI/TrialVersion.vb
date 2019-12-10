Public Class TrialVersion


    Dim a As Integer = 0
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim arr As String() = TextBox1.Text.Split("-")
        arr(0) = arr(0).Remove(2) + 321
        arr(1) = arr(1).Remove(2) + 654
        arr(2) = arr(2).Remove(2) + 987
        arr(3) = arr(3).Remove(2) + 741
        arr(4) = arr(4).Remove(2) + 258

        Dim str As String = arr(0) & "1-2" & arr(3) & "-3" & arr(1) & "-" & arr(4) & "4-0" & arr(2)
        If TextBox2.Text = str Then
            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                ta.UpdateKeyVal("true", "truefont")
            Catch ex As Exception

            End Try

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End If

    End Sub

    Private Sub trialversion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
        Dim dt = ta.GetData("keypsv")
        Try
            TextBox1.Text = dt.Rows(0).Item("val")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class