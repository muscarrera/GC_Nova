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

    Event EditSelectedFacture(ByVal p1 As Integer)

    Event DeleteItem(ByVal listLine As ListLine)

    Event GetFactureInfos(ByVal p1 As Integer)

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
            plSet.Visible = value

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
            'If value Mod 2 = 0 Then
            '    myColor = Color.WhiteSmoke
            'Else
            '    myColor = Color.Transparent
            'End If
            'Me.BackColor = myColor
            Panel1.BackgroundImage = Nothing
            If (value Mod 2) = 0 Then Panel1.BackgroundImage = My.Resources.gui_13
        End Set
    End Property

    Private Sub PlLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlLeft.Click, lbTotal.Click, lbRemise.Click, lbref.Click, lbName.Click, lbAvc.Click
        isSelected = Not isSelected
        RaiseEvent selected()
    End Sub

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        RaiseEvent EditSelectedFacture(Id)
    End Sub
    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        RaiseEvent DeleteItem(Me)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent GetFactureInfos(Id)
    End Sub
End Class
