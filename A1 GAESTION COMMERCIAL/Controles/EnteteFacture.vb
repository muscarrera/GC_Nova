Public Class EnteteFacture

    Dim _isDisibleEditing As Boolean
    Dim _CompteId As Integer


    Public Event NewFacture()
    Public Event SearchById(ByVal id As String)
    Public Event SearchByDate()
    Public Event SaveChanges(ByVal id As Integer)
    Public Event Type_Transformer(ByVal id As Integer)
    Public Event PayFacture(ByVal id As Integer)
    Public Event DuplicateFacture(ByVal id As Integer)
    Public Event DeleteFacture(ByVal id As Integer)
    Public Event SavePdf()
    Public Event PrintFacture()
    Public Event CommandDelivry(ByVal id As Integer)
    Public Event Facturer(ByVal id As Integer)
    Public Event AvoirFacture(ByVal id As Integer)
    Public Event PrintParamsFacture()
    Public Event ChangingClient()

    Public Event GetClientDetails()
    Public Event AddListofBl()
    Public Event SavePdfList()
    Public Event PrintList()
    Public Event NewEnCompteRef()

    Public Event NewBlRef()
    Public Event NewBcRef()
    Public Event NewDevisRef()

    Private fid As Integer
    Private cid As Integer
    Private _adresse As String
    Private _ice As String
    Private _clientType_Company As Boolean = True
    Dim _clientGroupe As String
    Private _date As Date
    Private _bL As String
    Private _client As Client = Nothing
    Private _Type As String


    Dim dte As Date
    Dim isPayed As Boolean
    Dim isAdmin As Boolean
    Dim info As String
    Dim delai As Integer
    Dim id_Cleared As String

    Event EdtitFactureDate()




    Public Property Id() As Integer
        Get
            Return fid
        End Get
        Set(ByVal value As Integer)
            fid = value
            id_Cleared = value.ToString
            Clear()

            If value.ToString.Length > 5 Then
                Form1.Ex_fact = value.ToString.Remove(2)
                id_Cleared = value.ToString.Remove(0, 2)

                Dim sss As Integer = CInt(id_Cleared)
                id_Cleared = sss.ToString

            End If



            lbId.Text = Form1.prefix & id_Cleared

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
    Public Property CompteId() As Integer
        Get
            Return _CompteId
        End Get
        Set(ByVal value As Integer)
            _CompteId = value

            If value = 0 Then
                plEnCompte.Width = 1
                lbEnCompte.Text = ""
            Else
                Try
                    Dim c As New Client(value, "Client")
                 
                    Dim str As String = c.name '& " [" & c.cid & "]"
                    str &= vbNewLine
                    'str &= c.adresse
                    'str &= vbNewLine
                    str &= "ICE : " & c.ICE
                    lbEnCompte.Text = str

                    plEnCompte.Width = plClient.Width / 3
                Catch ex As Exception

                End Try
            End If
        End Set
    End Property
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
            Form1.clientFacture = value
            If Not IsNothing(value) Then

                _clientGroupe = value.groupe
                _clientType_Company = value.isCompany
                ClientName = value.name
                cid = value.cid
                ICE = value.ICE
                ClientAdresse = value.adresse
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
            If _clientType_Company Then
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
            If _clientType_Company Then
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
            btAvoir.Visible = False
            btPrint.Visible = True

            If value = "Devis" Then
                btFacturer.Visible = False
                btDelivry.Visible = False
                btTranformer.Visible = True
                btSolde.Visible = False
                btParamsImp.Visible = True
            ElseIf value = "Commande" Or value = "BC" Then
                btFacturer.Visible = True
                btDelivry.Visible = True
                btTranformer.Visible = False
                btSolde.Visible = True
                btParamsImp.Visible = True
            ElseIf value = "BL" Or value = "BA" Then
                btFacturer.Visible = True
                btDelivry.Visible = False
                btTranformer.Visible = False
                btSolde.Visible = True
                btParamsImp.Visible = False
            ElseIf value = "Facture" Then
                btFacturer.Visible = False
                btDelivry.Visible = False
                btTranformer.Visible = False
                btSolde.Visible = True
                btParamsImp.Visible = True
                If Statut <> "CREATION" Then btAvoir.Visible = True

            ElseIf value = "Buy_Facture" Then
                btFacturer.Visible = False
                btDelivry.Visible = False
                btTranformer.Visible = False
                btSolde.Visible = True
                btParamsImp.Visible = False
                btAvoir.Visible = False
                btPrint.Visible = False

            ElseIf value = "Avoir" Then
                btFacturer.Visible = False
                btDelivry.Visible = False
                btTranformer.Visible = False
                btSolde.Visible = False
                btParamsImp.Visible = False
            End If
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
            plDv.Width = 300
            If value = "" Then plDv.Width = 75
        End Set
    End Property
    Public Property Bl As String
        Get
            Return _bL
        End Get
        Set(ByVal value As String)
            _bL = value
            FlowLayoutPanel1.Controls.Clear()
            plBL.Width = 300
            If value = "" Then
                plBL.Width = 75
                Exit Property
            End If

            Dim STR As String() = value.Split("|")
            For i As Integer = 0 To STR.Length - 1
                Dim b As New Label
                b.Text = STR(i)
                b.AutoSize = True
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
            plBc.Width = 300
            If value = "" Then plBc.Width = 75
        End Set
    End Property
    Public Property Statut As String
        Get
            Return txtStatus.text
        End Get
        Set(ByVal value As String)
            txtStatus.text = value
            btAvoir.Visible = False
            If value <> "CREATION" And Type = "Facture" Then btAvoir.Visible = True
        End Set
    End Property
    Public Property HasJoinFiles As Boolean
        Get
            Return False
        End Get
        Set(ByVal value As Boolean)
            pbJoindre.Visible = value
        End Set
    End Property
    Public Property isDisibleEditing As Boolean
        Get
            Return _isDisibleEditing
        End Get
        Set(ByVal value As Boolean)
            _isDisibleEditing = value
            plBc.Enabled = Not value
            plBL.Enabled = Not value
            plDv.Enabled = Not value
            btEditClient.Enabled = Not value
            btSolde.Enabled = Not value
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
        'If Not IsNumeric(txtSearch.text) Then Exit Sub
        'Dim fctid As Integer = CInt(txtSearch.text)
        RaiseEvent SearchById(txtSearch.text)
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        RaiseEvent SearchByDate()
    End Sub
    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        RaiseEvent SaveChanges(Id)
    End Sub
    Private Sub btTranformer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTranformer.Click
        RaiseEvent Type_Transformer(Id)
    End Sub
    Private Sub btSolde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSolde.Click
        RaiseEvent PayFacture(Id)
    End Sub
    Private Sub btDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDuplicate.Click
        RaiseEvent DuplicateFacture(Id)
    End Sub
    Private Sub btDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        RaiseEvent DeleteFacture(Id)
    End Sub
    Private Sub btPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPdf.Click
        RaiseEvent SavePdf()
    End Sub
    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        RaiseEvent PrintFacture()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelivry.Click
        RaiseEvent CommandDelivry(Id)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFacturer.Click
        RaiseEvent Facturer(Id)
    End Sub
    Private Sub txtSearch_KeyDownOk() Handles txtSearch.KeyDownOk
        RaiseEvent SearchById(txtSearch.text)
    End Sub

    Private Sub btAvoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAvoir.Click
        RaiseEvent AvoirFacture(Id)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btParamsImp.Click
        RaiseEvent PrintParamsFacture()
    End Sub
    'Devis Bc BL
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent NewDevisRef()
    End Sub
    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RaiseEvent NewBcRef()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Type = "Facture" Then
            RaiseEvent AddListofBl()
        Else
            RaiseEvent NewBlRef()
        End If


    End Sub
    'Client
    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEditClient.Click
        If Statut = "Livré" Then Exit Sub
        If Statut = "Facturé" Then Exit Sub
        'If Statut <> "CREATION" And Statut <> "ANNULER" And Statut <> "" And Type = "Facture" Then Exit Sub
        RaiseEvent ChangingClient()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        RaiseEvent GetClientDetails()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbListPdf.Click
        RaiseEvent SavePdfList()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbListPrint.Click
        RaiseEvent PrintList()
    End Sub

    Private Sub PictureBox2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        RaiseEvent NewEnCompteRef()
    End Sub

    Private Sub lbDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDate.Click
        RaiseEvent EdtitFactureDate()
    End Sub
End Class
