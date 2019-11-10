Public Class ListLine

    Private _id As Integer = 0
    Private _cid As Integer
    Private _Total As Double
    Private _avc As Double
    Private _Remise As Double
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
    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
            lbTotal.Text = String.Format("{0:n}", CDec(value))
        End Set
    End Property
    Public Property Avance As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            lbAvc.Text = String.Format("{0:n}", CDec(value))
        End Set
    End Property
    Public Property remise As Double
        Get
            Return _Remise
        End Get
        Set(ByVal value As Double)
            _Remise = value
            lbRemise.Text = String.Format("{0:n}", CDec(value))
            If value = 0 Then
                lbRemise.Visible = False
            Else
                lbRemise.Visible = True
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

    Private Sub PlLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlLeft.Click, lbTotal.Click, lbRemise.Click, lbref.Click, lbName.Click, lbAvc.Click
        isSelected = Not isSelected
        RaiseEvent selected()
    End Sub
End Class
