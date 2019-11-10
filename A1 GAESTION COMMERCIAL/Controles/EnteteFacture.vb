Public Class EnteteFacture

    Dim _bL As String

    Public Event NewFacture()
    Public Event SearchById(ByVal id As Integer)
    Public Event SearchByDate()

    Private fid As Integer
    Private cid As Integer
    Private _adresse As String
    Private _ice As String
    Private _clientType As String = "Physique"
    Private _date As Date
    Private _client As Client = Nothing

    Private _Type As String
    Dim dte As Date
    Dim isPayed As Boolean
    Dim isAdmin As Boolean
    Dim info As String
    Dim delai As Integer



    Public Property Id() As String
        Get
            Return fid
        End Get
        Set(ByVal value As String)
            fid = value
            Clear()
            lbId.Text = value

            ''''''
            If value = 0 Then
                'Me.Height = 48
                'LbNewFacture.Visible = True
                lbId.Visible = False
            Else
                'Me.Height = 280
                ''LbNewFacture.Visible = False
                lbId.Visible = True
            End If
        End Set
    End Property
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
            If Not IsNothing(value) Then

                _clientType = value.groupe
                ClientName = value.name
                cid = value.cid
                ICE = value.ICE

            End If
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
    Public Property ClientAdresse() As String
        Get
            Return _adresse
        End Get
        Set(ByVal value As String)
            _adresse = value
            If _clientType = "MORAL" Then
                Dim str As String = "[" & cid & "]"
                str &= vbNewLine
                str &= ClientAdresse
                str &= vbNewLine
                str &= "ICE : " & _ice
                lbInfo.Text = str
            End If
        End Set
    End Property
    Public Property ICE() As String
        Get
            Return _ice
        End Get
        Set(ByVal value As String)
            _ice = value
            If _clientType = "MORAL" Then
                Dim str As String = "[" & cid & "]"
                str &= vbNewLine
                str &= ClientAdresse
                str &= vbNewLine
                str &= "ICE : " & _ice
                lbInfo.Text = str
            End If
        End Set
    End Property
    Public Property Type() As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
            lbType.Text = value
            Id = 0
        End Set
    End Property
    Public Property FactureDate() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            lbDate.Text = value.ToString("dd MMM yyyy")
        End Set
    End Property
    Public Property Devis As String
        Get
            Return lbdv.Text
        End Get
        Set(ByVal value As String)
            lbdv.Text = value
            plDv.Visible = True
            If value = "" Then plDv.Visible = False
        End Set
    End Property
    Public Property Bl As String
        Get
            Return _bL
        End Get
        Set(ByVal value As String)
            _bL = value

            plBL.Visible = True
            If value = "" Then
                plBL.Visible = False
                Exit Property
            End If

            FlowLayoutPanel1.Controls.Clear()
            Dim STR As String() = value.Split("|")
            For i As Integer = 0 To STR.Length - 1
                Dim b As New Label
                b.Text = STR(i)
                FlowLayoutPanel1.Controls.Add(b)
            Next
        End Set
    End Property
    Public Property Bc As String
        Get
            Return lbBc.Text
        End Get
        Set(ByVal value As String)
            lbBc.Text = value
            plBc.Visible = True
            If value = "" Then plBc.Visible = False
        End Set
    End Property
    Public Property Statut As String
        Get
            Return txtStatus.text
        End Get
        Set(ByVal value As String)
            txtStatus.text = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub Clear()
        'Id = 0
        Client = Nothing
        ClientName = ""
        ClientAdresse = ""
        ICE = ""

    End Sub
    Private Sub LbNewFacture_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LbNewFacture.LinkClicked
        RaiseEvent NewFacture()
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        If Not IsNumeric(txtSearch.text) Then Exit Sub
        Dim fctid As Integer = CInt(txtSearch.text)
        RaiseEvent SearchById(fctid)
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        RaiseEvent SearchByDate()
    End Sub
End Class
