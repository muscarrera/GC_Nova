Public Class DataList


    Public Event SearchById(ByVal id As Integer, ByRef ds As DataList)
    Public Event SearchByDate(ByRef ds As DataList)
    Public Event IdChanged(ByVal id As Integer, ByRef ds As DataList)
    Public Event OperationTypeChanged()
    Public Event NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
    Public Event ModeChanged(ByVal value As String, ByVal dataList As DataList)
    Public Event NewRowAdded(ByVal id As Integer, ByVal tb_D As String, ByVal R As ListRow, ByRef d_Id As Integer)
    Public Event EditModePayement(ByRef dataList As DataList)

    Private _DataSource As DataTable

    Private _fntNormal As Font
    Private _fntTitle As Font
    Private _Mode As String
    Private operationType As String = "SELL"

    Public clientTable As String = "Client"
    Public payementTable As String = "Client_Payement"
    Public FactureTable As String = "Sell_Facture"
    Public DetailsTable As String = "Details_Sell_Facture"



    Public Property AutoCompleteSourceRef() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            AddRow1.AutoCompleteSourceRef = value
        End Set
    End Property
    Public Property AutoCompleteSourceName() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            AddRow1.AutoCompleteSourceName = value
        End Set
    End Property

    Public Property Id() As String
        Get
            Return Entete.Id
        End Get
        Set(ByVal value As String)
            Entete.Id = value
            RaiseEvent IdChanged(value, Me)
        End Set
    End Property
    Public Property Operation() As String
        Get
            Return operationType
        End Get
        Set(ByVal value As String)
            operationType = value
            If value = "SELL" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Sell_Facture"
                DetailsTable = "Details_Sell_Facture"
                Entete.Type = "Facture "
                '
            ElseIf value = "BUY" Then
                clientTable = "Company"
                payementTable = "Company_Payement"
                FactureTable = "Buy_Facture"
                DetailsTable = "Details_Buy_Facture"
                Entete.Type = "Facture "
                '
            ElseIf value = "Devis" Then
                clientTable = "Client"
                payementTable = "-"
                FactureTable = "Devis"
                DetailsTable = "Details_Devis"
                Entete.Type = "Devis "
                '
            ElseIf value = "BL" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Bon_Livraison"
                DetailsTable = "Details_Bon_Livraison"
                Entete.Type = "BL "
                '
            ElseIf value = "BC" Then
                clientTable = "Company"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Commande"
                DetailsTable = "Details_Bon_Commande"
                Entete.Type = "BC "
            End If

            RaiseEvent OperationTypeChanged()
        End Set
    End Property
    Public Property Facture As Facture
        Get
            Return Nothing
        End Get
        Set(ByVal value As Facture)
            Entete.FactureDate = value.dte
            Entete.Client = value.client
            Entete.Statut = value.isAdmin
            Entete.Devis = value.devis
            Entete.Bc = value.bc
            Entete.Bl = value.bl
            DataSource = value.DataSource
            TotalBloc1.Writer = value.writer
            TotalBloc1.ModePayement = value.modePayement
            'payement mode
            TotalBloc1.ModePayement = value.modePayement
        End Set
    End Property
    Public Property Mode() As String
        Get
            Return _Mode
        End Get
        Set(ByVal value As String)
            _Mode = value
            If value = "LIST" Then
                plDetailsHeader.Visible = False
                plNewElement.Visible = False
                PlAdd.Visible = False
                Entete.Height = 48
                Entete.lbId.Visible = False
                plListHeader.Visible = True
                TotalBloc1.Visible = False
            Else
                plDetailsHeader.Visible = True
                plNewElement.Visible = True
                PlAdd.Visible = True
                Entete.Height = 280
                Entete.lbId.Visible = True
                plListHeader.Visible = False
                TotalBloc1.Visible = True
            End If
        End Set
    End Property
    Public ReadOnly Property Total_Ht As Decimal
        Get

            Dim a As ListRow
            Dim t As Decimal = 0
            For Each a In Pl.Controls
                t += a.TotalHt
            Next
            'If hasManyRemise = False Then t -= (t * Remise) / 100
            Return t
        End Get
    End Property
    Public Property DataSource As DataTable
        Get
            Return _DataSource
        End Get
        Set(ByVal value As DataTable)

            _DataSource = value
            Pl.Controls.Clear()
            If IsNothing(value) Then Exit Property

            If value.Rows.Count > 0 Then
                Dim arr(value.Rows.Count - 1) As ListRow

                For i As Integer = 0 To value.Rows.Count - 1
                    Dim a As New Article
                    a.arid = value.Rows(i).Item("arid")
                    a.cid = value.Rows(i).Item("cid")
                    a.name = value.Rows(i).Item("name")
                    a.qte = value.Rows(i).Item("qte")
                    a.sprice = value.Rows(i).Item("price")
                    a.bprice = value.Rows(i).Item("bprice")
                    a.ref = value.Rows(i).Item("ref")
                    a.depot = value.Rows(i).Item("depot")
                    a.remise = value.Rows(i).Item("remise")
                    a.TVA = value.Rows(i).Item("tva")

                    Dim R As New ListRow(a)
                    R.normalFont = _fntNormal
                    R.titleFont = _fntTitle
                    R.Dock = DockStyle.Top
                    R.BringToFront()
                    arr(i) = R
                Next
                Pl.Controls.AddRange(arr)
            End If
        End Set
    End Property
    Public Property ModePayement As String
        Get
            Return TotalBloc1.ModePayement
        End Get
        Set(ByVal value As String)
            TotalBloc1.ModePayement = value
        End Set
    End Property
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub Clear()
        Pl.Controls.Clear()
        Entete.Clear()
    End Sub
    Private Sub AddRow1_AddNewArticle(ByVal art As Article) Handles AddRow1.AddNewArticle
        If Id = 0 Then Exit Sub
        'DataSource.Add(art.arid, art)
        Dim d_id As Integer = 0
        Dim R As New ListRow(art)
        R.normalFont = _fntNormal
        R.titleFont = _fntTitle
        R.Dock = DockStyle.Top
        R.BringToFront()

        RaiseEvent NewRowAdded(CInt(Id), DetailsTable, R, d_id)

        R.id = d_id
        If d_id > 0 Then Pl.Controls.Add(R)

    End Sub
    Private Sub DataList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'auto Complete
        Using art As AricleClass = New AricleClass
            AutoCompleteSourceName = art.AutoCompleteArticles("name")
            AutoCompleteSourceRef = art.AutoCompleteArticles("ref")
        End Using

        'normal font
        Dim fn As String = getRegistryinfo("normalFont", "arial")
        Dim fs As FontStyle = getRegistryinfo("normalFontStyle", 0)
        Dim fz As Integer = CInt(getRegistryinfo("normalFontSize", 9))
        _fntNormal = New Font(fn, fz, fs)
        'Title font
        fn = getRegistryinfo("titleFont", "arial")
        fs = getRegistryinfo("titleFontStyle", 1)
        fz = CInt(getRegistryinfo("titleFontSize", 11))
        _fntTitle = New Font(fn, fz, fs)
    End Sub
    Private Sub AddRow1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRow1.Resize
        Dim w = Me.Width

        plR.Width = CInt(w / 10)
        plL.Width = CInt(w / 10)
    End Sub

    Private Sub Pl_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Pl.ControlAdded
        If Pl.Controls.Count > 3 Then Pl.Height = Pl.Controls(0).Height * Pl.Controls.Count + 15
        If Mode = "LIST" Then Exit Sub

        Dim T As Double = 0
        Dim R As Double = 0
        Dim tva As Double = 0

        For Each C As ListRow In Pl.Controls
            T += C.TotalHt
            R += C.TotalRemise
            tva += C.TotaltVA
        Next

        TotalBloc1.TotalHt = T
        TotalBloc1.Remise = R
        TotalBloc1.TVA = tva
         
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Id = 0 Then Exit Sub
        PlAdd.Height = 45
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Mode = "details"
    End Sub

    'Entete Events
    Private Sub EnteteFacture1_NewFacture() Handles Entete.NewFacture
        RaiseEvent NewFacture(FactureTable, clientTable, Me)
    End Sub
    Private Sub Entete_SearchById(ByVal id As System.Int32) Handles Entete.SearchById
        RaiseEvent SearchById(id, Me)
    End Sub
    Private Sub Entete_SearchByDate() Handles Entete.SearchByDate
        RaiseEvent SearchByDate(Me)
    End Sub

    'Total Bloc Events
    Private Sub TotalBloc1_ValueChanged() Handles TotalBloc1.ValueChanged
        Dim h As Integer = 300
        If TotalBloc1.Remise = 0 Then h -= 35
        If TotalBloc1.DroitTimbre = 0 Then h -= 35
        If TotalBloc1.avance = 0 Then h -= 35

        plTotal.Height = h
    End Sub
    Private Sub TotalBloc1_EditModePayement() Handles TotalBloc1.EditModePayement
        RaiseEvent EditModePayement(Me)
    End Sub
End Class
