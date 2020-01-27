Public Class Tag

    Dim newGray As Color = Color.FromArgb(255, 218, 218, 218)
    Dim newPink As Color = Color.FromArgb(255, 245, 158, 195)
    Dim _key As String
    Dim _val As String

    Event DeleteTag(ByVal T As A1_GAESTION_COMMERCIAL.Tag)

    Public Property isActive As Boolean
        Get
            Return PL.BackColor <> newGray
        End Get
        Set(ByVal value As Boolean)

            If value Then
                PL.BackColor = newPink
                PLS.BackgroundImage = My.Resources.TAGIN_02
                PLR.BackgroundImage = My.Resources.TAGIN_04
                PLD.Visible = True
            Else
                PL.BackColor = newGray
                PLS.BackgroundImage = My.Resources.TAGIN_01
                PLR.BackgroundImage = My.Resources.TAGIN_03
                PLD.Visible = False
            End If
        End Set
    End Property

    Public myKey As String
    Public myVal As Object

    Public Property key As String
        Get
            Return _key
        End Get
        Set(ByVal value As String)
            _key = value
            lb.Text = value & "  |  " & val
        End Set
    End Property
    Public Property val As String
        Get
            Return _val
        End Get
        Set(ByVal value As String)
            _val = value
            lb.Text = key & "  |  " & value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        isActive = False
    End Sub

    Private Sub PL_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLS.MouseHover, PL.MouseHover, PLD.MouseHover, MyBase.MouseHover, MyBase.MouseEnter, lb.MouseHover, lb.MouseEnter, PLS.MouseEnter, PLD.MouseEnter, PL.MouseEnter
        'isActive = True
    End Sub
    Private Sub PL_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLS.MouseLeave, PL.MouseLeave, PLD.MouseLeave, MyBase.MouseLeave, lb.MouseLeave
        'isActive = False
    End Sub
    Private Sub PLD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLD.Click
        RaiseEvent DeleteTag(Me)
    End Sub

    Private Sub lb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lb.TextChanged
        Dim w As Integer = CInt(PLS.Width)
        w += CInt(lb.Width)
        w += 25

        If w < 250 Then w = 250
        If w > 400 Then w = 400

        Me.Width = w

    End Sub

    Private Sub lb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lb.Click
        isActive = Not isActive
    End Sub
End Class
