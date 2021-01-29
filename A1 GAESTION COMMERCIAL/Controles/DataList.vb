Public Class DataList
    'mode de recherche -- etats general -- journalier
    Dim _isEG As Boolean
    Dim _isEJ As Boolean
    Dim isValid As Boolean

    Public Event SearchById(ByVal id As String, ByRef ds As DataList)
    Public Event SearchByDate(ByRef ds As DataList)
    Public Event IdChanged(ByVal id As Integer, ByRef ds As DataList)
    Public Event OperationTypeChanged()
    Public Event NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
    Public Event ModeChanged(ByVal value As String, ByVal ds As DataList)
    Public Event NewRowAdded(ByVal id As Integer, ByVal tb_D As String, ByVal R As ListRow, ByRef d_Id As Integer)
    Public Event AddNewArticleToDb(ByRef art As Article)

    'Entete Events
    Public Event SavePdf(ByVal ds As DataList)
    Public Event PrintFacture(ByVal ds As DataList)
    Public Event SaveChanges(ByVal id As Integer, ByRef ds As DataList)
    Public Event TypeTransformer(ByVal id As Integer, ByRef ds As DataList)
    Public Event CommandeDelivry(ByVal id As Integer, ByRef ds As DataList)
    Public Event Facturer(ByVal id As Integer, ByRef ds As DataList)
    Public Event Valider(ByVal id As Integer, ByVal isV As Boolean, ByRef ds As DataList)
    Public Event PayFacture(ByVal id As Integer, ByRef ds As DataList)
    Public Event DuplicateFacture(ByVal id As Integer, ByRef ds As DataList)
    Public Event DeleteFacture(ByVal id As Integer, ByRef ds As DataList)
    Public Event AvoirFacture(ByVal p1 As Integer, ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event PrintParamsFacture(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event ChangingClient(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event NewBcRef(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event NewBlRef(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event NewDevisRef(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event GetClientDetails(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event AddListofBl(ByVal ds As A1_GAESTION_COMMERCIAL.DataList)

    'Bloc Tolal Event
    Public Event EditModePayement(ByRef dataList As DataList)
    Public Event AddFiles(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)

    'ListLine events
    Public Event EditSelectedFacture(ByVal id As Integer)
    Public Event DeleteItem(ByVal ls As ListLine)
    Public Event GetFactureInfos(ByVal id As Integer)
    'ListRow articles
    Public Event ArticleItemChanged(ByVal lr As ListRow, ByVal art As Article)
    Public Event ArticleItemDelete(ByVal lr As ListRow)
    'payement Events
    Public Event AddPayement(ByVal pm As Payement, ByVal ds As A1_GAESTION_COMMERCIAL.DataList, ByRef d_Id As Integer)
    Public Event EditPayement(ByVal pm As AddPayementRow, ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event DeletePayement(ByVal pm As AddPayementRow, ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    'events
    Public Event GetListofCommande(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)
    Public Event GetListofFacture(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)
    Public Event PrintListofFactures(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)
    Public Event SaveListofFacturesasPdf(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)
    Public Event NewEnCompteRef(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)
    Public Event EdtitFactureDate(ByVal FactureTable As String, ByVal id As String, ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
    Public Event PrintListofGoupeInpayed(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList, ByVal p2 As Boolean)
    Public Event getStockForAddRow(ByVal arid As Integer, ByVal dpid As Integer, ByRef stk As Double)
    Public Event GetArticleStock(ByRef panel As Panel, ByVal isS As Boolean)
    Public Event PrintListofDetailsJornalier(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList, ByVal p2 As Boolean)
    Public Event ChangeItemDepot(ByVal addRow As ListRow, ByVal dpid As Object)
    Public Event getClientRemise(ByRef ds As DataList, ByVal clientId As Integer, ByVal isS As Boolean)
    'Members
    Private _DataSource As DataTable
    Private _dtList As DataTable

    Private _fntNormal As Font
    Private _fntTitle As Font
    Private _Mode As String
    Private _isDisibleEditing As Boolean = False
    Private _isSell As Boolean = True
    Private operationType As String = "SELL"

    Public clientTable As String = "Client"
    Public payementTable As String = "Client_Payement"
    Public FactureTable As String = "Sell_Facture"
    Public DetailsTable As String = "Details_Sell_Facture"

    Public startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Public dt_Client_Remise As DataTable

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

            If CInt(Entete.Id) > 0 And Entete.Statut <> "AVOIR" Then
                RaiseEvent SaveChanges(CInt(Entete.Id), Me)
            End If


            Entete.Id = value
            If value > 0 Then RaiseEvent IdChanged(value, Me)
        End Set
    End Property
    Public Property Operation() As String
        Get
            Return operationType
        End Get
        Set(ByVal value As String)
            operationType = value

            If value = "Sell_Facture" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Sell_Facture"
                DetailsTable = "Details_Sell_Facture"
                Entete.Type = "Facture"
                'isSell = True
                Form1.prefix = Form1.prf_Params("fc")
            ElseIf value = "Devis" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Devis"
                DetailsTable = "Details_Devis"
                Entete.Type = "Devis"
                'isSell = True
                Form1.prefix = Form1.prf_Params("dv")
            ElseIf value = "Commande_Client" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Commande_Client"
                DetailsTable = "Details_Commande"
                Entete.Type = "Commande"
                'isSell = True
                Form1.prefix = Form1.prf_Params("cm")
            ElseIf value = "Bon_Livraison" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Bon_Livraison"
                DetailsTable = "Details_Bon_Livraison"
                Entete.Type = "BL"
                'isSell = True
                Form1.prefix = Form1.prf_Params("bl")
            ElseIf value = "Buy_Facture" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Buy_Facture"
                DetailsTable = "Details_Buy_Facture"
                Entete.Type = "Facture_Achat"
                'isSell = False
                Form1.prefix = Form1.prf_Params("fc_b")
            ElseIf value = "Bon_Commande" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Commande"
                DetailsTable = "Details_Bon_Commande"
                Entete.Type = "BC"
                'isSell = False
                Form1.prefix = Form1.prf_Params("bc")
            ElseIf value = "Bon_Achat" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Achat"
                DetailsTable = "Details_Bon_Achat"
                Entete.Type = "BA"
                'isSell = False
                Form1.prefix = Form1.prf_Params("ba")
            ElseIf value = "Sell_Avoir" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Sell_Avoir"
                DetailsTable = "Details_Sell_Avoir"
                Entete.Type = "Avoir"
                'isSell = False
                Form1.prefix = Form1.prf_Params("av")
            ElseIf value = "Buy_Avoir" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Buy_Avoir"
                DetailsTable = "Details_Buy_Avoir"
                Entete.Type = "Avoir"
                'isSell = False
                Form1.prefix = Form1.prf_Params("av_b")
            End If
            'Form1.prefix &= Form1.Exercice & "/000"
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

            If isSell Then
                If Form1.useClientRemise_Way Then
                    RaiseEvent getClientRemise(Me, Entete.Client.cid, isSell)
                End If

                Entete.CompteId = value.compteId
            Else
                Entete.CompteId = 0
            End If
            DataSource = value.DataSource
            TB.Writer = value.writer

            'payement mode
            TB.ModePayement = value.modePayement
            TB.pj = value.pj
            TB.avance = value.Avance
            PayementDataSource = value.PaymenetDataSource
            DisibleEditing(value.isAdmin, value.isValid)
            isValid = value.isValid

            If value.isAdmin <> "CREATION" Then PlAdd.Height = 1

        End Set
    End Property
    Public Property Mode() As String
        Get
            Return _Mode
        End Get
        Set(ByVal value As String)
            _Mode = value
            PlPayement.Visible = False
            'annuler l etat general
            _isEG = False

            If value = "LIST" Then
                plDetailsHeader.Visible = False
                plNewElement.Height = 1
                PlAdd.Height = 1
                Entete.Height = 48

                Entete.lbId.Visible = False
                Entete.pbListPdf.Visible = True
                Entete.pbListPrint.Visible = True
                Entete.pllist1.Visible = True
                Entete.pllist2.Visible = True

                plListHeader.Visible = True
                TB.Visible = False
                PlFooter.Visible = True
                plTotal.Height = 1
                Me.AutoScroll = False

                Pl.Dock = DockStyle.Fill
                Panel8.Height = 1
            Else
                plNewElement.Height = 27
                PlAdd.Height = 45
                Entete.Height = 280
                plTotal.Height = 210

                Pl.Dock = DockStyle.Top
                Panel8.Height = 33

                Me.AutoScroll = True
                plDetailsHeader.Visible = True
                Entete.lbId.Visible = True
                Entete.pbListPdf.Visible = False
                Entete.pbListPrint.Visible = False
                Entete.pllist1.Visible = False
                Entete.pllist2.Visible = False
                plListHeader.Visible = False
                TB.Visible = True
                PlFooter.Visible = False
            End If
        End Set
    End Property
    Public Property isEtatGeneral() As Boolean
        Get
            Return _isEG
        End Get
        Set(ByVal value As Boolean)
            _isEG = value
            If value = False Then Exit Property
            plDetailsHeader.Visible = False
            plListHeader.Visible = False
        End Set
    End Property
    Public Property isEtatJournalier() As Boolean
        Get
            Return _isEJ
        End Get
        Set(ByVal value As Boolean)
            _isEJ = value
            If value = False Then Exit Property
            plDetailsHeader.Visible = False
            plListHeader.Visible = False
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
    Public ReadOnly Property isPayed As Boolean
        Get
            Return CInt(TB.TotalTTC) <= CInt(TB.avance)
        End Get
    End Property
    Public Property DataSource As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("ref", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("remise", GetType(Integer))
            table.Columns.Add("bl", GetType(Integer))
            table.Columns.Add("totaltva", GetType(Integer))

            Dim a As ListRow
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.arid, a.ArticleName, a.cid, a.qte, a.sprice, a.bprice,
                              a.Tva, a.ref, a.depot, a.remise, a.bl, a.TotalTVA)
            Next
            Return table
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
                    R.id = value.Rows(i).Item(0)
                    R.isSell = isSell
                    R.BringToFront()

                    If FactureTable = "Sell_Facture" Then R.bl = IntValue(value, "bl", i)

                    If isDisibleEditing = False Then
                        AddHandler R.itemChanged, AddressOf Article_Item_Changed
                        AddHandler R.DeleteItem, AddressOf Article_Item_Delete
                    End If

                    arr(i) = R
                Next
                Pl.Controls.AddRange(arr)

                RaiseEvent GetArticleStock(Pl, isSell)

            End If
        End Set
    End Property
    Public Property PayementDataSource As DataTable
        Get
            Return Nothing
        End Get
        Set(ByVal value As DataTable)

            'plPmBody.Controls.Clear()
            PlPayement.Visible = False

            If Operation = "Devis" Then Exit Property

            If IsNothing(value) Then Exit Property

            If value.Rows.Count > 0 Then
                Dim arr(value.Rows.Count - 1) As AddPayementRow

                For i As Integer = 0 To value.Rows.Count - 1
                    Dim a As New Payement(value.Rows(i).Item(0), StrValue(value, "date", i),
                                           StrValue(value, "way", i), DblValue(value, "montant", i),
                                           StrValue(value, "ech", i), StrValue(value, "ref", i),
                                           StrValue(value, "desig", i))

                    Dim R As New AddPayementRow
                    R.Payement = a
                    R.id = value.Rows(i).Item(0)
                    R.Index = i
                    R.Dock = DockStyle.Top
                    R.BringToFront()
                    arr(i) = R
                Next
                'plPmBody.Controls.AddRange(arr)
            End If
        End Set
    End Property
    Public Property DataList As DataTable
        Get
            Return _dtList
        End Get
        Set(ByVal value As DataTable)
            _dtList = value
            _isEG = False

            lbLnbr.Text = value.Rows.Count
            lbLtotal.Text = ""
            lbLavc.Text = ""

            startIndex = 0
            lastIndex = value.Rows.Count
            numberOfItems = Form1.numberOfItems
            'numberOfPage = Math.Truncate(lastIndex / numberOfItems)
            'If lastIndex Mod numberOfItems > 0 Then numberOfPage += 1
            numberOfPage = 1

            currentPage = 1
            btPage.Text = "1/" & numberOfPage
            If numberOfPage = 0 Then btPage.Text = "0"
            lastIndex = 0
            'FillRows()
            FillRowsByGrid()

            Try
                Dim sum As Double = Convert.ToDouble(_dtList.Compute("SUM(total)", String.Empty))
                lbLtotal.Text = String.Format("{0:n}", CDec(sum))
                Dim avc As Double = Convert.ToDouble(_dtList.Compute("SUM(avance)", String.Empty))
                lbLavc.Text = String.Format("{0:n}", avc)

            Catch ex As Exception
                Try
                    Dim SM = _dtList.AsEnumerable().Aggregate(0, Function(n, r) PriceField(r) + n)
                    lbLtotal.Text = String.Format("{0:n}", CDec(SM))
                Catch exe As Exception
                End Try
            End Try
        End Set
    End Property
    Private Shared Function PriceField(ByVal r As DataRow) As Integer
        Dim v As Integer
        Return If(Integer.TryParse(If((TryCast(r("value"), String)), String.Empty), v), v, 0)
    End Function

    Public Property ModePayement As String
        Get
            Return TB.ModePayement
        End Get
        Set(ByVal value As String)
            TB.ModePayement = value
        End Set
    End Property
    Public Property isSell As Boolean
        Get
            Return _isSell
        End Get
        Set(ByVal value As Boolean)
            _isSell = value
            AddRow1.IsSell = value

            If value Then
                btav.Visible = True
                btdv.Visible = True

                btfc.Tag = "Sell_Facture"
                btbon.Tag = "Bon_Livraison"
                btbon.Text = "BL"
                btcmd.Text = "Commande"
                btcmd.Tag = "Commande_Client"
                btav.Tag = "Sell_Avoir"

                Button1_Click_1(btdv, Nothing)
            Else
                'btav.Visible = False
                btdv.Visible = False

                btfc.Tag = "Buy_Facture"
                btbon.Tag = "Bon_Achat"
                btbon.Text = "Achats"
                btcmd.Text = "BC"
                btcmd.Tag = "Bon_Commande"
                btav.Tag = "Buy_Avoir"
                Button1_Click_1(btcmd, Nothing)
            End If



        End Set
    End Property
    Public Property pj As Integer
        Get
            Return TB.pj
        End Get
        Set(ByVal value As Integer)
            TB.pj = value
            Entete.HasJoinFiles = CBool(value)
        End Set
    End Property
    Public Property isDisibleEditing As Boolean
        Get
            Return _isDisibleEditing
        End Get
        Set(ByVal value As Boolean)
            _isDisibleEditing = value
            plNewElement.Visible = Not value
            Entete.isDisibleEditing = value
            TB.isDisibleEditing = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Form1.isBaseOnOneTva Then plTva.Visible = False
    End Sub
    Public Sub Clear()
        If CInt(Entete.Id) > 0 And Entete.Statut <> "AVOIR" Then RaiseEvent SaveChanges(CInt(Entete.Id), Me)
        Pl.Controls.Clear()
        Entete.Clear()
    End Sub

    Public Sub DisibleEditing(ByVal str As String, ByVal b As Boolean)
        isDisibleEditing = False
        If str = "Facturé" Or str = "AVOIR" Then isDisibleEditing = True
        If b Then
            isDisibleEditing = True
            Entete.btValideBl.Text = "Invalider"
            Entete.btValideBl.Image = My.Resources.vector_cancel_icon_png_302651
            Entete.btValideBl.Tag = True
        Else
            Entete.btValideBl.Text = "Valider"
            Entete.btValideBl.Image = My.Resources.ICON_22
            Entete.btValideBl.Tag = Facture
            isDisibleEditing = False
        End If
    End Sub

    Private Sub AddRow1_AddArticleToDb(ByRef art As Article) Handles AddRow1.AddArticleToDb
        RaiseEvent AddNewArticleToDb(art)
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
        R.index = Pl.Controls.Count
        R.isSell = isSell

        'R.Stock = art.stock

        RaiseEvent NewRowAdded(CInt(Id), DetailsTable, R, d_id)

        AddHandler R.itemChanged, AddressOf Article_Item_Changed
        AddHandler R.DeleteItem, AddressOf Article_Item_Delete
        AddHandler R.ChangeArticleDepot, AddressOf ChangeArticleDepot

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

    Private Sub Pl_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Pl.ControlAdded, Pl.ControlRemoved

        If Mode = "LIST" Then
            Pl.Height = 400
            Exit Sub
        End If


        If Pl.Controls.Count > 3 Then
            Pl.Height = Pl.Controls(0).Height * Pl.Controls.Count + 15
        Else
            Pl.Height = 111
        End If

        If Pl.Controls.Count > 0 Then
            If TypeOf (Pl.Controls(0)) Is ListLine Then Exit Sub
        End If

        Dim Ht_T As Double = 0
        Dim Ttc_T As Double = 0
        Dim R As Double = 0
        Dim tva As Double = 0

        TB.dg.Rows.Clear()

        For Each C As ListRow In Pl.Controls
            Ht_T += C.TotalHt
            Ttc_T += C.TotalTTC
            R += C.TotalRemise
            tva += C.TotaltVA

            'Multi TVA
            If Form1.isBaseOnOneTva = False Then
                Dim B = True

                For i As Integer = 0 To TB.dg.Rows.Count - 1
                    If TB.dg.Rows(i).Cells(0).Value = C.TVA Then
                        TB.dg.Rows(i).Cells(1).Value = CDbl(TB.dg.Rows(i).Cells(1).Value) + C.TotaltVA
                        B = False
                    End If
                Next
                If B Then TB.dg.Rows.Add(C.TVA, C.TotaltVA)
            End If
        Next


        If Form1.isBaseOnTTC Then TB.TotalTTC_base = Ttc_T
        TB.TotalHt = Ht_T
        TB.Remise = R
        TB.TVA = tva


    End Sub
    Private Sub PlPm_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs)
        'If plPmBody.Controls.Count > 3 Then
        '    plPmBody.Height = plPmBody.Controls(0).Height * plPmBody.Controls.Count + 15
        '    PlPayement.Height = 280 + Pl.Height
        'Else
        '    plPmBody.Height = 111
        '    PlPayement.Height = 280
        'End If

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
    Private Sub EnteteFacture1_EditDate() Handles Entete.EdtitFactureDate
        RaiseEvent EdtitFactureDate(FactureTable, Id, Me)
    End Sub
    Private Sub Entete_SearchById(ByVal id As String) Handles Entete.SearchById
        RaiseEvent SearchById(id, Me)
    End Sub
    Private Sub Entete_SearchByDate() Handles Entete.SearchByDate
        RaiseEvent SearchByDate(Me)
    End Sub
    Private Sub Entete_CommandDelivry(ByVal p1 As Integer) Handles Entete.CommandDelivry
        RaiseEvent CommandeDelivry(CInt(p1), Me)
    End Sub
    Private Sub Entete_DeleteFacture(ByVal p1 As Integer) Handles Entete.DeleteFacture
        If Entete.Statut <> "AVOIR" Then RaiseEvent DeleteFacture(CInt(p1), Me)
    End Sub
    Private Sub Entete_DuplicateFacture(ByVal p1 As Integer) Handles Entete.DuplicateFacture
        RaiseEvent DuplicateFacture(CInt(p1), Me)
    End Sub
    Private Sub Entete_Facturer(ByVal p1 As Integer) Handles Entete.Facturer
        RaiseEvent Facturer(CInt(p1), Me)
    End Sub
    Private Sub Entete_PayFacture(ByVal p1 As Integer) Handles Entete.PayFacture
        'RaiseEvent PayFacture(CInt(p1), Me)
        'Me.ScrollControlIntoView(plPmHeader)
        Dim pf As New PayementForm

        pf.ClientName = Entete.ClientName
        pf.cid = Entete.Client.cid
        pf.FactureTable = FactureTable
        pf.payementTable = payementTable
        pf.clientTable = clientTable
        pf.Avance = TB.avance
        pf.Total = TB.TotalTTC
        pf.Id = Id
        If pf.ShowDialog = DialogResult.OK Then

        End If
        TB.avance = pf.Avance


    End Sub
    Private Sub Entete_PrintFacture() Handles Entete.PrintFacture
        RaiseEvent PrintFacture(Me)
    End Sub
    Private Sub Entete_PrintParamsFacture() Handles Entete.PrintParamsFacture
        RaiseEvent PrintParamsFacture(Me)
    End Sub
    Private Sub Entete_SaveChanges(ByVal p1 As Integer) Handles Entete.SaveChanges
        If Entete.Statut <> "AVOIR" Then RaiseEvent SaveChanges(CInt(p1), Me)
    End Sub
    Private Sub Entete_SavePdf() Handles Entete.SavePdf
        RaiseEvent SavePdf(Me)
    End Sub
    Private Sub Entete_Type_Transformer(ByVal p1 As Integer) Handles Entete.Type_Transformer
        RaiseEvent TypeTransformer(CInt(p1), Me)
    End Sub
    Private Sub Entete_Avoir(ByVal p1 As Integer) Handles Entete.AvoirFacture
        RaiseEvent AvoirFacture(p1, Me)
    End Sub
    'Total Bloc Events
    Private Sub TotalBloc1_ValueChanged() Handles TB.ValueChanged
        Dim h As Integer = 300
        If TB.Remise = 0 Then h -= 35
        If TB.DroitTimbre = 0 Then h -= 35
        If TB.avance = 0 Then h -= 35

        plTotal.Height = h
    End Sub
    Private Sub TotalBloc1_EditModePayement() Handles TB.EditModePayement
        RaiseEvent EditModePayement(Me)
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If currentPage = numberOfPage Then Exit Sub
        currentPage += 1

        FillRows()

        btPage.Text = currentPage & "/" & numberOfPage
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If currentPage = 1 Then Exit Sub
        currentPage -= 1
        startIndex -= (numberOfItems * 2)
        If startIndex < 0 Then startIndex = 0

        lastIndex -= numberOfItems * 2
        If lastIndex < 0 Then lastIndex = 0

        FillRows()
        btPage.Text = currentPage & "/" & numberOfPage
    End Sub

    'ListLine 
    Private Sub Edit_SelectedFacture(ByVal p As Integer)
        RaiseEvent EditSelectedFacture(p)
    End Sub
    Private Sub Delete_Item(ByVal listLine As ListLine)
        RaiseEvent DeleteItem(listLine)
    End Sub
    Private Sub Get_FactureInfos(ByVal p1 As Integer)
        RaiseEvent GetFactureInfos(p1)
    End Sub

    Private Sub FillRows()
        Pl.Controls.Clear()
        lastIndex += numberOfItems

        If _dtList.Rows.Count > 0 Then
            'Dim n = numberOfItems

            'If (_dtList.Rows.Count - startIndex) < numberOfItems Then n = lastIndex - startIndex
            If _dtList.Rows.Count - lastIndex < numberOfItems Then
                'n = _dtList.Rows.Count - lastIndex
                lastIndex = _dtList.Rows.Count - 1
            End If

            Dim arr(numberOfItems) As ListLine
            Dim i As Integer = 0

            For i = startIndex To _dtList.Rows.Count - 1
                Dim a As New ListLine
                a.sizeAuto = True

                a.Id = _dtList.Rows(i).Item(0)
                a.Libele = StrValue(_dtList, "name", i)
                a.Total = DblValue(_dtList, "total", i)
                a.Avance = DblValue(_dtList, "avance", i)
                a.remise = DblValue(_dtList, "remise", i)
                a.Dte = DteValue(_dtList, "date", i)

                If BoolValue(_dtList, "isPayed", i) Then a.plP.BackColor = Color.PaleGreen
                If StrValue(_dtList, "isAdmin", i) = "Fini" Or StrValue(_dtList, "isAdmin", i) = "Facturé" Or
                  StrValue(_dtList, "isAdmin", i) = "Livré" Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                If StrValue(_dtList, "isAdmin", i).ToUpper = "ANNULER" Or
                 StrValue(_dtList, "isAdmin", i).ToUpper = "NONE" Or
                 StrValue(_dtList, "isAdmin", i).ToUpper = "AVOIR" Then a.PlLeft.BackgroundImage = My.Resources.iconfinder_folder_delete_61770
                a.PlLeft.BackgroundImageLayout = ImageLayout.Zoom

                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()
                arr(i - startIndex) = a

                AddHandler a.EditSelectedFacture, AddressOf Edit_SelectedFacture
                AddHandler a.DeleteItem, AddressOf Delete_Item
                AddHandler a.GetFactureInfos, AddressOf Get_FactureInfos





                If i = lastIndex Then Exit For
            Next

            Pl.Controls.AddRange(arr)

            startIndex = i + 1
        End If


    End Sub
    Private Sub FillRowsByGrid()
        Pl.Controls.Clear()
        Try
            If _dtList.Rows.Count > 0 Then
                If _dtList.Columns.Count = 19 Then _dtList.Columns.Add("isVD", GetType(Boolean))
                If _dtList.Columns.Count = 20 Then _dtList.Columns.Add("isV", GetType(Boolean))
                If _dtList.Columns.Count = 21 Then _dtList.Columns.Add("ComId", GetType(Boolean))
                If _dtList.Columns.Count = 22 Then _dtList.Columns.Add("Driv", GetType(Boolean))

                _dtList.Columns.Add("Etat", GetType(String))
                _dtList.Columns.Add("_", GetType(Object))

                Dim dg As New DataGridView
                dg.DataSource = _dtList
                StyleDatagrid(dg)
                Pl.Controls.Add(dg)

                'dg.Columns(1).Visible = False
                dg.Columns(2).Visible = False
                dg.Columns(5).Visible = False
                dg.Columns(6).Visible = False
                dg.Columns(8).Visible = False
                dg.Columns(9).Visible = False
                dg.Columns(10).Visible = False
                dg.Columns(11).Visible = False
                dg.Columns(13).Visible = False
                dg.Columns(14).Visible = False
                dg.Columns(15).Visible = False
                dg.Columns(16).Visible = False
                dg.Columns(17).Visible = False
                dg.Columns(18).Visible = False
                dg.Columns(19).Visible = False
                dg.Columns(20).Visible = False
                dg.Columns(21).Visible = False
                dg.Columns(22).Visible = False
                dg.Columns(24).Visible = False

                dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

                dg.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                'dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(12).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
                dg.Columns(23).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

                dg.Columns(0).HeaderText = "ID/N°"
                dg.Columns(1).HeaderText = "Date"
                dg.Columns(3).HeaderText = "Libellé"
                dg.Columns(4).HeaderText = "Total"
                dg.Columns(7).HeaderText = "Avance"
                dg.Columns(12).HeaderText = "Editeur"



                dg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dg.Columns(1).DefaultCellStyle.Format = "dd MMM,yy"

                dg.Columns(4).DefaultCellStyle.Format = "c"
                dg.Columns(7).DefaultCellStyle.Format = "c"
                dg.Columns(23).DefaultCellStyle.Format = "c"

                AddHandler dg.CellMouseDoubleClick, AddressOf Dg_MouseDoubleClick
                AddHandler dg.CellContentClick, AddressOf Dg_CellContentClick
                AddHandler dg.Sorted, AddressOf Dg_Sorted

                Dg_Sorted(dg, Nothing)
                ' Pl.Height = dg.Rows.Count * 33 + 222

            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub StyleDatagrid(ByRef dg As DataGridView)
        dg.AutoGenerateColumns = True
        dg.BorderStyle = Windows.Forms.BorderStyle.None
        dg.CellBorderStyle = DataGridViewCellBorderStyle.None
        dg.RowsDefaultCellStyle.BackColor = Form1.Color_Default_Row
        dg.AlternatingRowsDefaultCellStyle.BackColor = Form1.Color_Alternating_Row

        dg.DefaultCellStyle.SelectionBackColor = Form1.Color_Selected_Row
        dg.DefaultCellStyle.SelectionForeColor = Form1.Color_Selected_Text

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.MultiSelect = False

        dg.AllowUserToResizeColumns = False
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub
    Private Sub Dg_MouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        Dim dg As DataGridView = sender
        If dg.SelectedRows.Count = 0 Then Exit Sub

        Dim id As Integer = dg.SelectedRows(0).Cells(0).Value
        RaiseEvent EditSelectedFacture(id)

        'If TableName = "Client" Then
        '    GetClientInfos(id)
        'ElseIf TableName = "Fournisseur" Then
        '    GetClientInfos(id)
        'ElseIf TableName = "Article" Then
        '    GetArticleInfos(id)
        'Else
        '    GetInfos(id)
        'End If
    End Sub
    Private Sub Dg_Sorted(ByVal sender As Object, ByVal e As EventArgs)
        Dim dt As DataGridView = sender
        Dim isP As Double = 0
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)

            For i As Integer = 0 To dt.Rows.Count - 1
                isP = dt.Rows(i).Cells(10).Value

                If isP Then
                    dt.Rows(i).Cells(23).Value = "Reglé"
                    dt.Rows(i).Cells(23).Style.ForeColor = Color.Green

                    If dt.Rows(i).Cells(9).Value.ToString.ToUpper.StartsWith("FAC") Then
                        dt.Rows(i).Cells(23).Value = "Facturé"

                        Try
                            If dt.Rows(i).Cells(7).Value < dt.Rows(i).Cells(4).Value Then
                                params.Clear()
                                params.Add("id", dt.Rows(i).Cells(18).Value)

                                If c.SelectByScalar("Sell_Facture", "isPayed", params) Then
                                    dt.Rows(i).Cells(7).Value = dt.Rows(i).Cells(4).Value
                                    dt.Rows(i).Cells(7).Style.ForeColor = Color.Blue
                                End If
                            End If
                        Catch ex As Exception
                        End Try

                    End If
                Else

                    If dt.Rows(i).Cells(9).Value.ToString.ToUpper.StartsWith("AVO") Then
                        dt.Rows(i).Cells(23).Value = "Avoir"
                        dt.Rows(i).Cells(23).Style.ForeColor = Color.Red

                    ElseIf dt.Rows(i).Cells(9).Value.ToString.ToUpper.StartsWith("ANN") Then
                        dt.Rows(i).Cells(23).Value = "Supp"
                        dt.Rows(i).Cells(23).Style.ForeColor = Color.Red
                    ElseIf dt.Rows(i).Cells(9).Value.ToString.ToUpper.StartsWith("FAC") Then
                        dt.Rows(i).Cells(23).Value = "Facturé"
                        dt.Rows(i).Cells(23).Style.ForeColor = Color.Blue

                        Try
                            params.Clear()
                            params.Add("id", dt.Rows(i).Cells(18).Value)

                            If c.SelectByScalar("Sell_Facture", "isPayed", params) Then
                                dt.Rows(i).Cells(7).Value = dt.Rows(i).Cells(4).Value
                                dt.Rows(i).Cells(7).Style.ForeColor = Color.Blue
                            End If
                        Catch ex As Exception
                        End Try

                    Else
                        Dim rest As Double = dt.Rows(i).Cells(7).Value - dt.Rows(i).Cells(4).Value
                        dt.Rows(i).Cells(23).Value = rest.ToString("c")
                        dt.Rows(i).Cells(7).Style.ForeColor = Color.Red
                    End If

                End If
            Next
        End Using
    End Sub
    Private Sub Dg_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
        'Dim dt As DataGridView = sender
        'dt.Columns(22).Visible = False
        'If dt.SelectedRows.Count = 0 Then Exit Sub

        'For i As Integer = 0 To dt.Rows.Count - 1
        '    Dim pl As Panel
        '    If Not IsDBNull(dt.Rows(i).Cells(22).Value) Then
        '        pl = dt.Rows(i).Cells(22).Value
        '        pl.Controls.Clear()
        '    End If
        'Next
        'If Not IsDBNull(dt.SelectedRows(0).Cells(22).Value) Then
        '    Dim pl2 As Panel = dt.SelectedRows(0).Cells(22).Value
        '    Dim bt As New Button
        '    bt.Text = "text"
        '    pl2.Controls.Clear()
        '    pl2.Controls.Add(bt)
        '    dt.Columns(22).Visible = True
        'Else
        '    Dim plz As New Panel
        '    Dim bt As New Button
        '    bt.Text = "text"
        '    plz.Controls.Add(bt)
        '    plz.BackColor = Color.Green
        '    dt.SelectedRows(0).Cells(22).Value = plz
        '    dt.Columns(22).Visible = True
        'End If
    End Sub

    'Edit
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            Dim DG As DataGridView = Pl.Controls(0)
            If DG.SelectedRows.Count = 0 Then Exit Sub

            Dim id As Integer = DG.SelectedRows(0).Cells(0).Value()
            RaiseEvent EditSelectedFacture(id)
        Catch ex As Exception
        End Try
    End Sub
    'Add
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent NewFacture(FactureTable, clientTable, Me)
    End Sub
    'Delete
    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DG As DataGridView = Pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub
        Dim id As Integer = DG.SelectedRows(0).Cells(0).Value

        RaiseEvent DeleteFacture(id, Me)
    End Sub



    Private Sub Article_Item_Changed(ByVal listRow As ListRow, ByVal art As Article)
        RaiseEvent ArticleItemChanged(listRow, art)
        Pl_ControlAdded(Nothing, Nothing)
    End Sub
    Private Sub ChangeArticleDepot(ByVal addRow As ListRow, ByVal _dpid As Object)
        RaiseEvent ChangeItemDepot(addRow, _dpid)
    End Sub

    Private Sub Article_Item_Delete(ByVal listRow As ListRow)
        RaiseEvent ArticleItemDelete(listRow)
        Pl_ControlAdded(Nothing, Nothing)
    End Sub
    Public Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btfc.Click, btbon.Click, btcmd.Click, btdv.Click, btav.Click
        Dim bt As Button = sender
        Clear()
        Entete.txtSearch.text = ""
        Mode = "LIST"
        Operation = bt.Tag
        pbBar.Width = bt.Right
        pbBar.BackColor = RandomColor()
        bt.BackgroundImage = My.Resources.gui_16

        For Each b As Button In plHeaderSells.Controls
            If b.Text = bt.Text Then Continue For
            b.BackgroundImage = My.Resources.gray_row
        Next

        If bt.Text = "Commande" Or bt.Text = "BC" Then
            RaiseEvent GetListofCommande(Me)
        Else
            RaiseEvent GetListofFacture(Me)
        End If

    End Sub
    Private Sub AddPayementRow1_AddNewArticle(ByVal pm As A1_GAESTION_COMMERCIAL.Payement)

        'If Id = 0 Then Exit Sub

        ''DataSource.Add(art.arid, art)
        'Dim d_id As Integer = 0
        'Dim R As New AddPayementRow

        'R.Dock = DockStyle.Top
        'R.BringToFront()
        'R.Index = plPmBody.Controls.Count

        'AddHandler R.EditPayement, AddressOf Edit_Payement
        'AddHandler R.Cleared, AddressOf Delete_Payement

        'RaiseEvent AddPayement(pm, Me, d_id)


        'R.Payement = pm
        'R.id = d_id
        'R.EditMode = True
        'R.Index = plPmBody.Controls.Count
        'If d_id > 0 Then plPmBody.Controls.Add(R)


    End Sub
    Public Sub FillPayement(ByVal dt As DataTable)
        PlPayement.Visible = True
        PlPayement.Height = 200
        'Me.ScrollControlIntoView(plPmHeader)
    End Sub
    Private Sub Edit_Payement(ByVal PR As A1_GAESTION_COMMERCIAL.AddPayementRow)
        RaiseEvent EditPayement(PR, Me)
    End Sub
    Private Sub Delete_Payement(ByVal pm As AddPayementRow)
        RaiseEvent DeletePayement(pm, Me)
    End Sub
    Private Sub TB_AddFiles() Handles TB.AddFiles
        RaiseEvent AddFiles(Me)
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        PlPayement.Visible = True
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PlPayement.Height = 0
    End Sub
    Private Sub TB_AddEditPayement() Handles TB.AddEditPayement
        FillPayement(Nothing)
    End Sub

    Private Sub Entete_ChangingClient() Handles Entete.ChangingClient
        RaiseEvent ChangingClient(Me)
        If isSell And Form1.useClientRemise_Way Then
            RaiseEvent getClientRemise(Me, Entete.Client.cid, isSell)
        End If
    End Sub
    Private Sub Entete_NewBcRef() Handles Entete.NewBcRef
        RaiseEvent NewBcRef(Me)
    End Sub
    Private Sub Entete_NewEnCompteRef() Handles Entete.NewEnCompteRef
        RaiseEvent NewEnCompteRef(Me)
    End Sub
    Private Sub Entete_NewBlRef() Handles Entete.NewBlRef
        RaiseEvent NewBlRef(Me)
    End Sub
    Private Sub Entete_NewDevisRef() Handles Entete.NewDevisRef
        RaiseEvent NewDevisRef(Me)
    End Sub
    Private Sub Entete_GetClientDetails() Handles Entete.GetClientDetails
        RaiseEvent GetClientDetails(Me)
    End Sub
    Private Sub Entete_AddListofBl() Handles Entete.AddListofBl

        If isSell Then
            RaiseEvent AddListofBl(Me)
        Else
            RaiseEvent NewBlRef(Me)
        End If

        '''''''''''''''''''''''''''
    End Sub
    Private Sub Entete_PrintList() Handles Entete.PrintList
        If isEtatGeneral Then
            RaiseEvent PrintListofGoupeInpayed(Me, False)
        ElseIf isEtatJournalier Then
            RaiseEvent PrintListofDetailsJornalier(Me, False)
        Else
            RaiseEvent PrintListofFactures(Me)
        End If

    End Sub
    Private Sub Entete_SavePdfList() Handles Entete.SavePdfList
        If isEtatGeneral Then
            RaiseEvent PrintListofGoupeInpayed(Me, True)
        Else
            RaiseEvent SaveListofFacturesasPdf(Me)
        End If
    End Sub

    Private Sub AddRow1_getStock(ByVal _arid As System.Int32, ByVal _dpid As System.Int32, ByRef stk As System.Double) Handles AddRow1.getStock
        RaiseEvent getStockForAddRow(_arid, _dpid, stk)
    End Sub

    Private Sub AddRow1_GetRemiseByClient(ByRef _art As Article) Handles AddRow1.GetRemiseByClient
        Dim R_All As Double = 0
        If isSell = False Then Exit Sub


        For i As Integer = 0 To dt_Client_Remise.Rows.Count - 1
            If dt_Client_Remise.Rows(i).Item("all") Then
                R_All = CDbl(dt_Client_Remise.Rows(i).Item("remise"))
            End If
        Next

        For i As Integer = 0 To dt_Client_Remise.Rows.Count - 1
            Dim ar = dt_Client_Remise.Rows(i).Item("arid")
            Dim ct = dt_Client_Remise.Rows(i).Item("cid")

            If ar = _art.arid Then
                R_All = CDbl(dt_Client_Remise.Rows(i).Item("remise"))
                Exit For
            End If

            If ar = 0 And ct = _art.cid Then
                R_All = CDbl(dt_Client_Remise.Rows(i).Item("remise"))
            End If
        Next

        _art.remise = R_All
    End Sub

    Private Sub Entete_ValiderBl(ByVal id As Integer) Handles Entete.ValiderBl
        RaiseEvent Valider(id, isValid, Me)
    End Sub

    Private Sub DataList_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        Clear()
    End Sub

End Class
