Public Class DataList




    Public Event SearchById(ByVal id As Integer, ByRef ds As DataList)
    Public Event SearchByDate(ByRef ds As DataList)
    Public Event IdChanged(ByVal id As Integer, ByRef ds As DataList)
    Public Event OperationTypeChanged()
    Public Event NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
    Public Event ModeChanged(ByVal value As String, ByVal dataList As DataList)
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
    'Bloc Tolal Event
    Public Event EditModePayement(ByRef dataList As DataList)
    'ListLine events
    Event EditSelectedFacture(ByVal id As Integer)
    Event DeleteItem(ByVal ls As ListLine)
    Event GetFactureInfos(ByVal id As Integer)
    'ListRow articles
    Event ArticleItemChanged(ByVal lr As ListRow, ByVal art As Article)
    Event ArticleItemDelete(ByVal lr As ListRow)

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

            isSell = True
            If value = "Sell_Facture" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Sell_Facture"
                DetailsTable = "Details_Sell_Facture"
                Entete.Type = "Facture "
                '
            ElseIf value = "Buy_Facture" Then
                clientTable = "Company"
                payementTable = "Company_Payement"
                FactureTable = "Buy_Facture"
                DetailsTable = "Details_Buy_Facture"
                Entete.Type = "Facture "
                isSell = False
                '
            ElseIf value = "Devis" Then
                clientTable = "Client"
                payementTable = "-"
                FactureTable = "Devis"
                DetailsTable = "Details_Devis"
                Entete.Type = "Devis "
                '
            ElseIf value = "Commande_Client" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Commande_Client"
                DetailsTable = "Details_Commande"
                Entete.Type = "Commande"

            ElseIf value = "Bon_Livraison" Then
                clientTable = "Client"
                payementTable = "Client_Payement"
                FactureTable = "Bon_Livraison"
                DetailsTable = "Details_Bon_Livraison"
                Entete.Type = "BL "
                '
            ElseIf value = "Bon_Commande" Then
                clientTable = "Company"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Commande"
                DetailsTable = "Details_Bon_Commande"
                Entete.Type = "BC "
                isSell = False

            ElseIf value = "Bon_Achat" Then
                clientTable = "Company"
                payementTable = "Company_Payement"
                FactureTable = "Bon_Achat"
                DetailsTable = "Details_Bon_Achat"
                Entete.Type = "BA "
                isSell = False
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
            TB.Writer = value.writer
            TB.ModePayement = value.modePayement
            'payement mode
            TB.ModePayement = value.modePayement
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
                TB.Visible = False
                PlFooter.Visible = True
            Else
                plNewElement.Visible = True
                plDetailsHeader.Visible = True

                PlAdd.Visible = True
                Entete.Height = 280
                Entete.lbId.Visible = True
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
            Return TB.TotalTTC >= TB.avance
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
          
            Dim a As ListRow
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.arid, a.Name, a.cid, a.qte, a.sprice, a.bprice,
                              a.TVA, a.ref, a.depot, a.remise)
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
                    R.BringToFront()
                    arr(i) = R
                Next
                Pl.Controls.AddRange(arr)
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

            Operation = "Devis"
            Mode = "LIST"

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
        R.index = Pl.Controls.Count

        AddHandler R.itemChanged, AddressOf Article_Item_Changed
        AddHandler R.DeleteItem, AddressOf Article_Item_Delete

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

        TB.TotalHt = T
        TB.Remise = R
        TB.TVA = tva

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
    Private Sub Entete_CommandDelivry(ByVal p1 As System.String) Handles Entete.CommandDelivry
        RaiseEvent CommandeDelivry(CInt(p1), Me)
    End Sub
    Private Sub Entete_DeleteFacture(ByVal p1 As System.String) Handles Entete.DeleteFacture
        RaiseEvent DeleteFacture(CInt(p1), Me)
    End Sub
    Private Sub Entete_DuplicateFacture(ByVal p1 As System.String) Handles Entete.DuplicateFacture
        RaiseEvent DuplicateFacture(CInt(p1), Me)
    End Sub
    Private Sub Entete_Facturer(ByVal p1 As System.String) Handles Entete.Facturer
        RaiseEvent Facturer(CInt(p1), Me)
    End Sub
    Private Sub Entete_PayFacture(ByVal p1 As System.String) Handles Entete.PayFacture
        RaiseEvent PayFacture(CInt(p1), Me)
    End Sub
    Private Sub Entete_PrintFacture() Handles Entete.PrintFacture
        RaiseEvent PrintFacture(Me)
    End Sub
    Private Sub Entete_SaveChanges(ByVal p1 As System.String) Handles Entete.SaveChanges
        RaiseEvent SaveChanges(CInt(p1), Me)
    End Sub
    Private Sub Entete_SavePdf() Handles Entete.SavePdf
        RaiseEvent SavePdf(Me)
    End Sub
    Private Sub Entete_Type_Transformer(ByVal p1 As System.String) Handles Entete.Type_Transformer
        RaiseEvent TypeTransformer(CInt(p1), Me)
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
        startIndex -= numberOfItems
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
                a.Id = _dtList.Rows(i).Item(0)
                a.Libele = StrValue(_dtList, "name", i)
                a.Total = DblValue(_dtList, "total", i)
                a.Avance = DblValue(_dtList, "avance", i)
                a.remise = DblValue(_dtList, "remise", i)

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
            startIndex = i
        End If


    End Sub

    Private Sub Article_Item_Changed(ByVal listRow As ListRow, ByVal art As Article)
        RaiseEvent ArticleItemChanged(listRow, art)
    End Sub

    Private Sub Article_Item_Delete(ByVal listRow As ListRow)
        RaiseEvent ArticleItemDelete(listRow)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button1.Click
        Dim bt As Button = sender
        Operation = bt.Tag

    End Sub
End Class
