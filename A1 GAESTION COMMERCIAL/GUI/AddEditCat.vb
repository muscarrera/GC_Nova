Public Class AddEditCat

    Dim _id As Integer


    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

            If value > 0 Then
                getData()
            End If
        End Set
    End Property
    Public Sub getData()
        If id = 0 Then Exit Sub

        Try

            Dim params As New Dictionary(Of String, Object)
            params.Add("cid", id)

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim dt = c.SelectDataTable("Category", {"*"}, params)

                txtName.text = StrValue(dt, "name", 0)
                txtRemise.text = DblValue(dt, "value", 0)

                params = Nothing
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            If txtName.text.Trim = "" Then Exit Sub

            Dim R As Double = 0
            If IsNumeric(txtRemise.text) Then R = txtRemise.text

            Dim params As New Dictionary(Of String, Object)
            params.Add("name", txtName.text)
            params.Add("remise", CDbl(R))

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                If id > 0 Then
                    Dim where As New Dictionary(Of String, Object)
                    where.Add("cid", id)
                    c.UpdateRecord("Category", params, where)
                    where = Nothing
                Else
                    id = c.InsertRecord("Category", params, True)
                End If
                params = Nothing
            End Using
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class