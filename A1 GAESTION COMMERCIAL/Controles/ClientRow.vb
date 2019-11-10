Public Class ClientRow

    Private _id As Integer = 0
    Private _isSelected As Boolean
    Private myColor As Color = Color.Transparent
    Dim _index As Integer

    Public Event selected()

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            lbref.Text = value
        End Set
    End Property
    Public Property Libele As String
        Get
            Return lbName.Text
        End Get
        Set(ByVal value As String)
            lbName.Text = value
        End Set
    End Property
    Public Property Responsable As String
        Get
            Return lbResponsable.Text
        End Get
        Set(ByVal value As String)
            lbResponsable.Text = value
        End Set
    End Property
    Public Property Tel As String
        Get
            Return lbTel.Text
        End Get
        Set(ByVal value As String)
            lbTel.Text = value
        End Set
    End Property
    Public Property Ville As String
        Get
            Return lbVille.Text
        End Get
        Set(ByVal value As String)
            lbVille.Text = value
        End Set
    End Property
    Public Property isCompany As Boolean
        Get
            Return lbType.Text = "Ste"
        End Get
        Set(ByVal value As Boolean)
            If value Then
                lbType.Text = "Ste"
            Else
                lbType.Text = "Part."
            End If
        End Set
    End Property
    Public Property isSelected() As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            _isSelected = value
            If value Then
                Me.BackColor = Color.AntiqueWhite
            Else
                Me.BackColor = myColor
            End If
        End Set
    End Property
    Public Property isEdited As Boolean
        Get
            Return Me.BackColor = Color.FromArgb(192, 255, 192)
        End Get
        Set(ByVal value As Boolean)
            Me.BackColor = Color.FromArgb(192, 255, 192)
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
            If value Mod 2 = 0 Then
                myColor = Color.WhiteSmoke
            Else
                myColor = Color.Transparent
            End If
            Me.BackColor = myColor
        End Set
    End Property

    Private Sub PlLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlLeft.Click, lbVille.Click,  lbType.Click, lbResponsable.Click, lbref.Click, lbName.Click, lbTel.Click
        isSelected = Not isSelected
        RaiseEvent selected()
    End Sub
End Class
