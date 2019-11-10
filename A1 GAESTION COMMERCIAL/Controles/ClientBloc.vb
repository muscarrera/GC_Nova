Public Class ClientBloc
    Public Event IsChoosen(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event IsActivated(ByRef sender As Object, ByVal e As System.EventArgs)
    Public Event IsDisActivated(ByVal Arid As Integer)

    Private _isActive As Boolean
    'Property
    Public Property Clid() As Integer
        Get
            Return CInt(lbArid.Text)
        End Get
        Set(ByVal value As Integer)
            lbArid.Text = value
        End Set
    End Property
    Public Property ClientName() As String
        Get
            Return lbName.Text
        End Get
        Set(ByVal value As String)
            lbName.Text = value
        End Set
    End Property
    Public Property Adresse() As String
        Get
            Return lbAdresse.Text
        End Get
        Set(ByVal value As String)
            lbAdresse.Text = value
        End Set
    End Property
    Public Property Tel() As String
        Get
            Return lbTel.Text
        End Get
        Set(ByVal value As String)
            lbTel.Text = value
        End Set
    End Property
    Public Property Clienttype() As String
        Get
            Return lbType.Text
        End Get
        Set(ByVal value As String)
            If value.Contains("|") Then
                lbType.Text = value.Split("|")(0)
                num = value.Split("|")(1)
                If Not IsNumeric(num) Then num = 0
            Else
                lbType.Text = value
                num = 0
            End If

            'If Form1.CbDelaiFct.Checked = False Then lbType.Visible = False
        End Set
    End Property
    Public Property num() As String
        Get
            Return lbnum.Text
        End Get
        Set(ByVal value As String)
            lbnum.Text = value
            'lbnum.Visible = Form1.chbsell.Checked
        End Set
    End Property
    Public Property isAdmin() As Boolean
        Get
            Return lbType.Visible
        End Get
        Set(ByVal value As Boolean)
            lbType.Visible = value
        End Set
    End Property
    Public Property Img() As Image
        Get
            Return Pb.BackgroundImage
        End Get
        Set(ByVal value As Image)
            Pb.BackgroundImage = value
        End Set
    End Property

    Public Property isActive() As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value

            If value Then
                lbName.Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
                PL.BackColor = Color.MintCream
            Else
                lbName.Font = New Font("Microsoft Sans Serif", 9)
                PL.BackColor = Color.FromArgb(253, 253, 253)
            End If
        End Set
    End Property

    ''Construtor
    Public Sub New(ByVal id As Integer, ByVal nm As String, ByVal adr As String,
                   ByVal t As String, ByVal tp As String, ByVal isa As Boolean)
        Call InitializeComponent()

        Clid = id
        ClientName = nm
        Adresse = adr
        Tel = t
        Clienttype = tp
        isAdmin = isa
        ' Img = im

        Dim RND As New Random
        lbArid.ForeColor = Color.FromArgb(255, RND.Next(255), RND.Next(255), RND.Next(255))

    End Sub
    Private Sub lbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbName.Click, Pb.Click, PL.Click
        isActive = Not isActive

        If isActive Then
            RaiseEvent IsActivated(Me, Nothing)
        Else
            RaiseEvent IsDisActivated(Clid)
        End If
    End Sub
    Private Sub PL_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PL.DoubleClick, lbName.DoubleClick, Pb.DoubleClick
        RaiseEvent IsChoosen(Me, Nothing)
    End Sub
End Class
