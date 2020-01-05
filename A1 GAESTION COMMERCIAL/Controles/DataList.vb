Public Class DataList

    Public Event SearchById(ByVal id As String, ByRef ds As DataList)
    Public Event SearchByDate(ByRef ds As DataList)
    Public Event IdChanged(ByVal id As Integer, ByRef ds As DataList)
    Public Event OperationTypeChanged()
    Public Event NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
    Public Event ModeChanged(ByVal value As String, ByVal ds As DataList)
    Public Event NewRowAdded(ByVal id As Integer, ByVal tb_D As String, ByVal R As ListRow, ByRef d_Id As Integer)

    'Entete Events
    Public Event SavePdf(ByVal ds As DataList)
    Public Event PrintFacture(ByVal ds As DataList)
    Public Event SaveChanges(ByVal id As Integer, ByRef ds As DataList)
    Public Event TypeTransformer(ByVal id As Integer, ByRef ds As DataList)
    Public Event CommandeDelivry(ByVal id As Integer, ByRef ds As DataList)
    Public Event Facturer(ByVal id As Integer, ByRef ds As DataList)
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


    'Members
    Private _DataSource As DataTable
    Private _dtList As DataTable

    Private _fntNormal As Font
    Private _fntTitle As Font
    Private _Mode As String
    Private operationType As String = "SELL"

    Public clientTable As String = "Client"
    Public payementTable As String = "Client_Payement"
    Public FactureTable As String = "Sell_Facture"
    Public DetailsTable As String = "Details_Sell_Facture"
    Private _isSell As Boolean = True
    Public startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Private _isDisibleEditing As Boolean = True

    Event GetListofCommande(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)

    Event GetListofFacture(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)

    Event PrintListofFactures(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)

    Event SaveListofFacturesasPdf(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)

    Event NewEnCompteRef(ByVal dataList As A1_GAESTION_COMMERCIAL.DataList)

    Event EdtitFactureDate(ByVal FactureTable As String, ByVal id As String, ByVal ds As A1_GAESTION_COMMERCIAL.DataList)



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
            If CInt(Entete.Id) > 0 Then RaiseEvent SaveChanges(CInt(Entete.Id), Me)

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

            If value = "Sell_Facture" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Sell_Facture"
                DetailsTable = "Details_Sell_Facture"
                Entete.Type = "Facture"
                'isSell = True
                Form1.prefix = "Fc"
            ElseIf value = "Devis" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Devis"
                DetailsTable = "Details_Devis"
                Entete.Type = "Devis"
                'isSell = True
                Form1.prefix = "Dv"
            ElseIf value = "Commande_Client" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Commande_Client"
                DetailsTable = "Details_Commande"
                Entete.Type = "Commande"
                'isSell = True
                Form1.prefix = "Cmd"
            ElseIf value = "Bon_Livraison" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Bon_Livraison"
                DetailsTable = "Details_Bon_Livraison"
                Entete.Type = "BL"
                'isSell = True
                Form1.prefix = "BL"
            ElseIf value = "Buy_Facture" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Buy_Facture"
                DetailsTable = "Details_Buy_Facture"
                Entete.Type = "Buy_Facture"
                'isSell = False
                Form1.prefix = "Fc-Ent"
            ElseIf value = "Bon_Commande" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Commande"
                DetailsTable = "Details_Bon_Commande"
                Entete.Type = "BC"
                'isSell = False
                Form1.prefix = "BC"
            ElseIf value = "Bon_Achat" Then
                clientTable = "Fournisseur"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Achat"
                DetailsTable = "Details_Bon_Achat"
                Entete.Type = "BA"
                'isSell = False
                Form1.prefix = "BA"
            ElseIf value = "Sell_Avoir" Then
                clientTable = "client"
                payementTable = "Client_Payement"
                FactureTable = "Sell_Avoir"
                DetailsTable = "Details_Sell_Avoir"
                Entete.Type = "Avoir"
                'isSell = False
                Form1.prefix = "Av"
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
                Entete.CompteId = value.CompteId
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
            DisibleEditing(value.isAdmin)
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
            'Pl.Controls.Clear()

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
            Else
                plNewElement.Height = 27
                PlAdd.Height = 45
                Entete.Height = 280

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
            Return TB.TotalTTC <= TB.avance
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

            Dim a As ListRow
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.arid, a.ArticleName, a.cid, a.qte, a.sprice, a.bprice,
                              a.TVA, a.ref, a.depot, a.remise, a.id)
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

                    If FactureTable = "Sell_Facture" Then R.bl = IntValue(value, "bl", i)
                    R.BringToFront()
                    AddHandler R.itemChanged, AddressOf Article_Item_Changed
                    AddHandler R.DeleteItem, AddressOf Article_Item_Delete

                    arr(i) = R
                Next
                Pl.Controls.AddRange(arr)
            End If
        End Set
    End Property
    Public Property PayementDataSource As DataTable
        Get
            Return Nothing
        End Get
        Set(ByVal value As DataTable)

            plPmBody.Controls.Clear()
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
                plPmBody.Controls.AddRange(arr)
            End If
        End Set
    End Property
    Public Property DataList As DataTable
        Get
            Return _dtList
        End Get
        Set(ByVal value As DataTable)
            _dtList = value
            startIndex = 0
            lastIndex = value.Rows.Count
            numberOfItems = Form1.numberOfItems
            numberOfPage = Math.Truncate(lastIndex / numberOfItems)
            If lastIndex Mod numberOfItems > 0 Then numberOfPage += 1
            currentPage = 1
            btPage.Text = "1/" & numberOfPage

            FillRows()
        End Set
    End Property
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
                Button3.Visible = True
                Button1.Visible = True

                Button9.Tag = "Sell_Facture"
                Button8.Tag = "Bon_Livraison"
                Button8.Text = "BL"
                Button7.Text = "Commande"
                Button7.Tag = "Commande_Client"

                Button1_Click_1(Button1, Nothing)
            Else
                Button3.Visible = False
                Button1.Visible = False

                Button9.Tag = "Buy_Facture"
                Button8.Tag = "Bon_Achat"
                Button8.Text = "Achats"
                Button7.Text = "BC"
                Button7.Tag = "Bon_Commande"

                Button1_Click_1(Button7, Nothing)
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

    End Sub
    Public Sub Clear()
        If CInt(Entete.Id) > 0 Then RaiseEvent SaveChanges(CInt(Entete.Id), Me)
        Pl.Controls.Clear()
        Entete.Clear()
    End Sub
    Public Sub DisibleEditing(ByVal str As String)
        isDisibleEditing = False
        If str = "Facturé" Then isDisibleEditing = True
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

        RaiseEvent NewRowAdded(CInt(Id), DetailsTable, R, d_id)

        AddHandler R.itemChanged, AddressOf Article_Item_Changed
        AddHandler R.DeleteItem, AddressOf Article_Item_Delete

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
        If Pl.Controls.Count > 3 Then
            Pl.Height = Pl.Controls(0).Height * Pl.Controls.Count + 15
        Else
            Pl.Height = 111
        End If

        If Mode = "LIST" Then Exit Sub
        If Pl.Controls.Count > 0 Then
            If TypeOf (Pl.Controls(0)) Is ListLine Then Exit Sub
        End If

        Dim T As Double = 0
        Dim R As Double = 0
        Dim tva As Double = 0

        For Each C As ListRow In Pl.Controls
            T += C.TotalHt
            R += C.TotalRemise
            tva += C.TotaltVA
        Next

        TB.TotalHt = T
        TB.Remise = R
        TB.TVA = tva

    End Sub
    Private Sub PlPm_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plPmBody.ControlAdded, plPmBody.ControlRemoved
        If plPmBody.Controls.Count > 3 Then
            plPmBody.Height = plPmBody.Controls(0).Height * plPmBody.Controls.Count + 15
            PlPayement.Height = 280 + Pl.Height
        Else
            plPmBody.Height = 111
            PlPayement.Height = 280
        End If

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
        RaiseEvent DeleteFacture(CInt(p1), Me)
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
        RaiseEvent SaveChanges(CInt(p1), Me)
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
        pl.Controls.Clear()

        If _dtList.Rows.Count > 0 Then
            Dim n = numberOfItems
            If (_dtList.Rows.Count - startIndex) < numberOfItems Then n = lastIndex - startIndex
            Dim arr(n - 1) As ListLine
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
                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()

                AddHandler a.EditSelectedFacture, AddressOf Edit_SelectedFacture
                AddHandler a.DeleteItem, AddressOf Delete_Item
                AddHandler a.GetFactureInfos, AddressOf Get_FactureInfos

                arr(i - startIndex) = a

                If i = startIndex + n - 1 Then Exit For
            Next
            Pl.Controls.AddRange(arr)
            startIndex = i + 1
        End If


    End Sub
    Private Sub Article_Item_Changed(ByVal listRow As ListRow, ByVal art As Article)
        RaiseEvent ArticleItemChanged(listRow, art)
        Pl_ControlAdded(Nothing, Nothing)
    End Sub
    Private Sub Article_Item_Delete(ByVal listRow As ListRow)
        RaiseEvent ArticleItemDelete(listRow)
        Pl_ControlAdded(Nothing, Nothing)
    End Sub
    Public Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button1.Click, Button3.Click
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
    Private Sub AddPayementRow1_AddNewArticle(ByVal pm As A1_GAESTION_COMMERCIAL.Payement) Handles AddPayementRow1.AddNewArticle

        If Id = 0 Then Exit Sub

        'DataSource.Add(art.arid, art)
        Dim d_id As Integer = 0
        Dim R As New AddPayementRow

        R.Dock = DockStyle.Top
        R.BringToFront()
        R.Index = plPmBody.Controls.Count

        AddHandler R.EditPayement, AddressOf Edit_Payement
        AddHandler R.Cleared, AddressOf Delete_Payement

        RaiseEvent AddPayement(pm, Me, d_id)


        R.Payement = pm
        R.id = d_id
        R.EditMode = True
        R.Index = plPmBody.Controls.Count
        If d_id > 0 Then plPmBody.Controls.Add(R)


    End Sub
    Public Sub FillPayement(ByVal dt As DataTable)
        PlPayement.Visible = True
        PlPayement.Height = 200
        Me.ScrollControlIntoView(plPmHeader)
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
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        PlPayement.Visible = True
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        PlPayement.Height = 0
    End Sub
    Private Sub TB_AddEditPayement() Handles TB.AddEditPayement
        FillPayement(Nothing)
    End Sub

    Private Sub Entete_ChangingClient() Handles Entete.ChangingClient
        RaiseEvent ChangingClient(Me)
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
        RaiseEvent AddListofBl(Me)
    End Sub
    Private Sub Entete_PrintList() Handles Entete.PrintList
        RaiseEvent PrintListofFactures(Me)
    End Sub
    Private Sub Entete_SavePdfList() Handles Entete.SavePdfList
        RaiseEvent SaveListofFacturesasPdf(Me)
    End Sub
End Class
