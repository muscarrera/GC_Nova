Public Class CompanyBloc

    Private _name As String

    Event Activated(ByVal c As CompanyBloc, ByVal b As Boolean)

    Public Property DataName() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            BT.Text = value
            Try

                Dim str As String = Form1.Data_Comp_Path & "\" & value & "\logo.jpg"
                OvalShape1.BackgroundImage = Image.FromFile(str)

            Catch ex As Exception
                pl1.Width = 0
            End Try
        End Set
    End Property

    Private _active As Boolean
    Public Property active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
            If active Then
                BT.BackColor = Color.Moccasin
            Else
                BT.BackColor = Color.WhiteSmoke
            End If
        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT.Click
        active = Not active
        RaiseEvent Activated(Me, active)
    End Sub
End Class
