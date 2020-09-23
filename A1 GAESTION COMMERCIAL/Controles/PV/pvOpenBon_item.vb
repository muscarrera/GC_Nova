Public Class pvOpenBon_item


    Private _myColor As Color

    Event SelectedBon(ByVal pvOpenBon_item As pvOpenBon_item)

    Event DeleteBon(ByVal pvOpenBon_item As pvOpenBon_item)

    Public localName As String = ""
    Public isActive As Boolean = False

    Public Property myColor() As Color
        Get
            Return _myColor
        End Get
        Set(ByVal value As Color)
            _myColor = value
            RC.BackColor = value
            LB.BackColor = value
            BT.BackColor = value
            PL.BackColor = value

            If value = Color.White Then
                LB.ForeColor = Color.Red
                BT.Visible = True
                isActive = True
            Else
                LB.ForeColor = Color.White
                BT.Visible = False
                isActive = False
            End If

        End Set
    End Property
    Public Property ClientName As String
        Get
            Return LB.Text
        End Get
        Set(ByVal value As String)
            LB.Text = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim rnd As New Random
        myColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))

    End Sub


    Private Sub LB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LB.Click, RC.Click, MyBase.Click
        RaiseEvent SelectedBon(Me)
    End Sub

    Private Sub BT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT.Click
        RaiseEvent DeleteBon(Me)
    End Sub
End Class
