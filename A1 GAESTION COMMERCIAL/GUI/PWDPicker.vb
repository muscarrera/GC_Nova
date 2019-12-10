Public Class PWDPicker
    Private nn As Boolean = False

    Private Sub PWDPicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.admin' table. You can move, or remove it, as needed.
        Me.AdminTableAdapter.Fill(Me.ALMohassinDBDataSet.admin)

        TextBox1.Select()
        Try
            If DGV1.Rows.Count Then
                TextBox2.Text = DGV1.Rows(0).Cells(1).Value
            End If
            If Form1.isMaster = True Then btSlvMode.Visible = False

        Catch ex As Exception
        End Try

        Call CenterToScreen()
        'Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        'Me.WindowState = FormWindowState.Maximized

        Panel6.Location = New Point((Me.Width - Panel6.Width) \ 2, (Me.Height - Panel6.Height) \ 2)

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = DGV1.SelectedRows(0).Cells(3).Value Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Mot de Pass Incorrect !")
        End If
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1_Click(Nothing, Nothing)
        End If
    End Sub
    Private Sub TextBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
        TextBox1.PasswordChar = "*"
    End Sub
    Private Sub DGV1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV1.CellClick
        Try
            TextBox2.Text = DGV1.SelectedRows(0).Cells(1).Value
            nn = False
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btSlvMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSlvMode.Click
        If TextBox1.Text = DGV1.SelectedRows(0).Cells(3).Value Then
            If Form1.isMaster = False Then
                Using a As BoundClass = New BoundClass
                    a.ChangeConnectionString()
                End Using
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Else
            MsgBox("Mot de Pass Incorrect !")
        End If
    End Sub
  
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim a = 300
        If plClavier.Width > 100 Then a = -300
        Panel6.Width += a
        plClavier.Width += a
        Panel6.Location = New Point((Me.Width - Panel6.Width) \ 2, (Me.Height - Panel6.Height) \ 2)

    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click, Button31.Click, Button30.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click
        If nn = False Then
            TextBox1.Text = ""
            nn = True
        End If

        Dim bt As Button = sender
        TextBox1.Text = TextBox1.Text + bt.Text
    End Sub
    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        TextBox1.Text = ""
        nn = True
    End Sub
End Class