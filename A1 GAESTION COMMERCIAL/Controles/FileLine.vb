Public Class FileLine

    Dim _index As Integer

    Public Event DeleteItem(ByVal ls As FileLine)
    Public Event ViewImages(ByVal ls As FileLine)

    Public Property Libele As String
        Get
            Return lbName.Text
        End Get
        Set(ByVal value As String)
            lbName.Text = value

            Try
                Dim str = value.Split(".")(1)

                If str = "jpg" Or str = "png" Then
                    plImg.BackgroundImage = My.Resources.IMAGE_22
                ElseIf str = "pdf" Then
                    plImg.BackgroundImage = My.Resources.PDF_22
                ElseIf str = "doc" Or str = "docx" Then
                    plImg.BackgroundImage = My.Resources.WORD__22
                Else
                    plImg.BackgroundImage = My.Resources.FILE_22
                End If
            Catch ex As Exception
                plImg.BackgroundImage = My.Resources.FILE_22
            End Try
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
            Me.BackColor = Color.Transparent
            If (value Mod 2) = 0 Then Me.BackColor = Color.WhiteSmoke
        End Set
    End Property

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        RaiseEvent ViewImages(Me)
    End Sub
    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        RaiseEvent DeleteItem(Me)
    End Sub
End Class
