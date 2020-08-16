Public Class AddRow
    'Members
    Dim frt = Form1.DesimalSringFormat

    Private isUsingBarcodeScaner As Boolean = False
    Dim _dpid As Integer

    'Eents
    Public Event AddNewArticle(ByVal art As Article)
    Public Event Cleared(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Public article As New Article
    Public IsSell As Boolean = True
    Public EditMode As Boolean = False

    Public Event getStock(ByVal _arid As Integer, ByVal _dpid As Integer, ByRef stk As Double)
    Public Event ChangeElementDepot(ByVal addRow As AddRow, ByVal dpid As Integer)
    Public Event GetRemiseByClient(ByRef art As A1_GAESTION_COMMERCIAL.Article)
    Event AddArticleToDb(ByRef art As A1_GAESTION_COMMERCIAL.Article)

    Public Property dpid As Integer
        Get
            Return _dpid
        End Get
        Set(ByVal value As Integer)
            _dpid = value
            article.depot = value

            If value > 0 Then
                btDepot.Text = value
                btDepot.BackgroundImage = My.Resources.BG_STK
            Else
                btDepot.Text = ""
                btDepot.BackgroundImage = My.Resources.stock_icon_png_14
            End If
            RaiseEvent getStock(Arid, dpid, myStock)
        End Set
    End Property
    Public Property myStock As Double
        Get
            Return article.stock
        End Get
        Set(ByVal value As Double)
            article.stock = value

            If IsNothing(value) Or dpid = 0 Or Arid = 0 Then
                article.stock = 0
                plAlert.Visible = False
                Exit Property
            End If

            If value <= 0 Then
                plAlert.Visible = True
                plAlert.BackColor = Color.Red
            ElseIf value <= Form1.myMinStock And value > 0 Then
                plAlert.Visible = True
                plAlert.BackColor = Color.Orange
            Else
                plAlert.Visible = False
            End If
        End Set
    End Property
    'Properties
    Private Property Arid As Integer
        Get
            Return article.arid
        End Get
        Set(ByVal value As Integer)

            article.arid = value
            If value = 0 And txtN.text <> "" Then
                plleft.BackgroundImage = My.Resources.WARNING_15
                txtTva.txtReadOnly = False
            Else
                plleft.BackgroundImage = Nothing
                txtTva.txtReadOnly = True
            End If
        End Set
    End Property
    Public Property AutoCompleteSourceRef() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtRf.AutoCompleteSource = value
        End Set
    End Property
    Public Property AutoCompleteSourceName() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtN.AutoCompleteSource = value
        End Set
    End Property

    Public ReadOnly Property price() As Double
        Get
            Dim t As Double = 0

            Try
                t = txtPr.text
            Catch ex As Exception
                t = 0
            End Try
            Return t
        End Get
    End Property
    Public ReadOnly Property qte() As Double
        Get
            Dim t As Double = 0

            Try
                t = txtQ.text
            Catch ex As Exception
                t = 0
            End Try
            Return t
        End Get
    End Property
    Public ReadOnly Property remise() As Double
        Get
            Dim t As Double = 0
            Try
                t = txtRs.text
            Catch ex As Exception
                t = 0
            End Try
            Return t
        End Get
    End Property
    Public Property isAlerted() As Boolean
        Get
            Return plAlert.Visible
        End Get
        Set(ByVal value As Boolean)
            plAlert.Visible = value
        End Set
    End Property
    Public Property isSlave() As Boolean
        Get
            Return Not txtPr.txtReadOnly
        End Get
        Set(ByVal value As Boolean)
            txtPr.txtReadOnly = Not value
            txtRs.txtReadOnly = Not value
        End Set
    End Property
    '
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Form1.isBaseOnOneTva Then plTva.Visible = False
    End Sub

    'subs and Functions
    Shadows Sub Focus()
        txtName.Focus()
    End Sub
    'init
    Private Sub InitForm()
        txtRf.text = ""
        txtN.text = ""
        txtQ.text = ""
        txtPr.text = ""
        txtRs.text = ""
        myStock = Nothing

        article = New Article(0, 0, "", "", 1, 0, 0, Form1.tva, 0, 0, False, "", False)
        txtRf.Focus()
    End Sub
    'validation
    Dim isValidByOptionForm As Integer = 1
    Private Function ValidationForm() As Boolean

        If txtN.text = "" Then Return False
        If txtPr.text = "" Then Return False




        If article.arid = 0 And Form1.allowAddElement_to And EditMode = False Then
            Dim op As New OptionAddElement

            Dim MPx As Point = MousePosition()
            Dim y = MPx.Y + 10
            Dim x = MPx.X - 133
            op.Location = New Point(x, y)


            AddHandler op.FormClosing, AddressOf AdvancedSearch_FormClosing
            op.ShowDialog()

            If isValidByOptionForm = 0 Then Return False
            If isValidByOptionForm = 1 Then Return True
            'add new article
            If isValidByOptionForm = 2 Then
                RaiseEvent AddArticleToDb(article)
                If article.arid = 0 Then Return False
            End If
        End If

        Return True
    End Function

    Private Sub AdvancedSearch_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        Dim op As OptionAddElement = sender
        isValidByOptionForm = op.value
    End Sub


    'fill
    Public Sub FillFields(ByVal art As Article)

        Dim sPrice As Double = art.sprice
        If IsSell = False And EditMode = False Then sPrice = art.bprice

        article = New Article(art.arid, art.cid, art.name, art.desc, art.qte,
                              sPrice, art.bprice, art.TVA, art.remise, art.depot,
                              art.isStocked, art.ref, art.isPromo)

        txtRf.text = article.ref
        txtN.text = article.name
        txtTva.text = article.TVA

        Dim pr As Double = article.sprice
        If Form1.isBaseOnTTC Then pr = article.spriceTTC


        txtPr.text = String.Format(frt, CDec(pr))
        txtRs.text = String.Format(frt, CDec(article.remise))
        txtttc.text = String.Format(frt, CDec(article.TotalTTC))
        Arid = art.arid
        article.depot = dpid

        RaiseEvent getStock(Arid, dpid, myStock)
    End Sub

    'tub with home key
    Private Sub TxtBox3_KeyDownOk() Handles txtRf.KeyDownOk
        'auto Complete
        If txtRf.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article

                If isUsingBarcodeScaner Then
                    a = art.GetByfield("desc", txtRf.text)
                Else
                    a = art.GetByfield("ref", txtRf.text)
                End If

                If Not IsNothing(a) Then
                    'get Remise Client
                    If Form1.useClientRemise_Way Then RaiseEvent GetRemiseByClient(a)
                    'fill the information
                    FillFields(a)
                End If

                txtQ.Focus()
            End Using
        End If

        If txtN.text.Count = 0 Then txtN.Focus()
    End Sub
    Private Sub txtName_KeyDownOk() Handles txtN.KeyDownOk
        If txtN.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("name", txtN.text)
                If Not IsNothing(a) Then
                    Dim remise = art.GetRemise(a.arid, Form1.clientFacture.groupe)
                    a.remise = remise

                    If Not IsNothing(a) Then
                        'get Remise Client
                        If Form1.useClientRemise_Way Then RaiseEvent GetRemiseByClient(a)
                        'fill the information
                        FillFields(a)
                    End If

                End If
            End Using
        End If
        txtQ.Focus()
    End Sub
    Private Sub txtQte_KeyDownOk() Handles txtQ.KeyDownOk
        If txtQ.text = "" Then txtQ.text = 1
        article.qte = qte


        If isSlave = False Then
            If ValidationForm() Then
                RaiseEvent AddNewArticle(article)
                InitForm()
            End If
        End If



        If txtPr.text.Count > 0 And price > 0 Then
            txtRs.Focus()
        Else
            txtPr.Focus()
        End If

    End Sub
    Private Sub txtPrice_KeyDownOk() Handles txtPr.KeyDownOk
        Dim PR As Decimal = IIf(Form1.isBaseOnTTC, CDec(article.spriceTTC), CDec(article.sprice))

        txtPr.text = String.Format(FRT, PR)
        txtRs.Focus()
    End Sub
    Private Sub txtRemise_KeyDownOk() Handles txtRs.KeyDownOk
        article.remise = remise
        If ValidationForm() Then
            RaiseEvent AddNewArticle(article)
            InitForm()
        End If

    End Sub
    'handling the event add
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If ValidationForm() Then
            RaiseEvent AddNewArticle(article)
            InitForm()
        End If


    End Sub
    'handling the event clear
    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        InitForm()
        RaiseEvent Cleared(Me, e)
    End Sub
    'look for article
    Private Sub btInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.Click
        Dim sr As New SearchForArticle


        If sr.ShowDialog = DialogResult.OK Then
            txtRf.text = sr._ref
            TxtBox3_KeyDownOk()
        End If
    End Sub

    'txtChanged
    Private Sub txtPrice_TxtChanged() Handles txtPr.TxtChanged
        Try
            If Form1.isBaseOnTTC Then
                article.spriceTTC = price
            Else
                article.sprice = price
            End If

            txtttc.text = String.Format(frt, CDec(article.TotalTTC))
        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
    Private Sub txtQte_TxtChanged() Handles txtQ.TxtChanged
        Try
            article.qte = qte
            txtttc.text = String.Format(frt, CDec(article.TotalTTC))

            ''''
            Dim STK = myStock - qte
            If IsSell = False Then STK = myStock + qte

            If dpid = 0 Or Arid = 0 Then Exit Sub

            If STK <= 0 Then
                plAlert.Visible = True
                plAlert.BackColor = Color.Red
            ElseIf STK <= Form1.myMinStock And STK > 0 Then
                plAlert.Visible = True
                plAlert.BackColor = Color.Orange
            Else
                plAlert.Visible = False
            End If

        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
    Private Sub txtRemise_TxtChanged() Handles txtRs.TxtChanged
        Try
            article.remise = remise
            txtttc.text = String.Format(frt, CDec(article.TotalTTC))
        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
    Private Sub txtName_TxtChanged() Handles txtN.TxtChanged
        'Arid = 0
        article.name = txtN.text
    End Sub
    Private Sub txtRef_TxtChanged() Handles txtRf.TxtChanged
        Arid = 0
        article.ref = txtRf.text
    End Sub
    'Leave
    Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtN.Leave
        If Arid <> 0 Then Exit Sub

        If txtN.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("name", txtN.text)
                If Not IsNothing(a) Then FillFields(a)
            End Using
        End If
    End Sub

    Private Sub btCodeBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCodeBar.Click
        isUsingBarcodeScaner = Not isUsingBarcodeScaner

        If isUsingBarcodeScaner Then
            btCodeBar.BackColor = Color.Green
        Else
            btCodeBar.BackColor = Color.Transparent
        End If
        txtRf.Focus()

    End Sub

    Private Sub btDepot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDepot.Click
        Dim clc As New ChooseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If dpid <> clc.dpid And EditMode = True Then
                RaiseEvent ChangeElementDepot(Me, clc.dpid)
            End If
            dpid = clc.dpid
        End If
    End Sub


    Private Sub txtTva_TxtChanged() Handles txtTva.TxtChanged
        Try
            If txtTva.Focus = False Then Exit Sub
            article.TVA = txtTva.text
            txtttc.text = String.Format(frt, CDec(article.TotalTTC))
        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
End Class

