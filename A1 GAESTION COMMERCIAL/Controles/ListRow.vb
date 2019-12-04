Public Class ListRow


    Public Event DeleteItem(ByVal listRow As ListRow)
    Public Event selected(ByVal R As ListRow)
    Public Event itemChanged(ByVal listRow As ListRow, ByVal art As A1_GAESTION_COMMERCIAL.Article)
    Public Event GetArticleInfos(ByVal arid As Integer)

    Private _sPrice As Double = 0
    Private _Qte As Double = 0
    Private _Remise As Double = 0
    Private _index As Integer
    Private _Stk As Double

    Private _fntNormal As Font
    Private _fntTitle As Font

    Private _article As Article

    Private _editMode As Boolean = False
    Private _isSelected As Boolean = False

    Public id As Integer = 0
    Private _bl As Integer = 0
    Public arid As Integer = 0
    Public cid As Integer
    Public alert As Double

    Public Property ArticleName As String
        Get
            Return lbName.Text
        End Get
        Set(ByVal value As String)
            lbName.Text = value
        End Set
    End Property
    Public Property qte As Double
        Get
            Return _Qte
        End Get
        Set(ByVal value As Double)
            _Qte = value

            If value = 0 Then
                lbQte.Visible = False
                lbTotal.Visible = False
            Else
                lbQte.Visible = True
                lbTotal.Visible = True
            End If

            lbQte.Text = value
            lbTotal.Text = String.Format("{0:n}", CDec(TotalTTC))
        End Set
    End Property
    Public Property sprice As Double
        Get
            Return _sPrice
        End Get
        Set(ByVal value As Double)
            _sPrice = value
            If value = 0 Then
                lbPrice.Visible = False
                lbTotal.Visible = False
            Else
                lbPrice.Visible = True
                lbTotal.Visible = True
            End If

            lbPrice.Text = String.Format("{0:n}", CDec(value))
            lbTotal.Text = String.Format("{0:n}", CDec(TotalTTC))
        End Set
    End Property
    Public Property remise As Double
        Get
            Return _Remise
        End Get
        Set(ByVal value As Double)
            _Remise = value
            lbRemise.Text = String.Format("{0:n}", CDec(value))
            If value = 0 Then
                lbRemise.Visible = False
            Else
                lbRemise.Visible = True
            End If
            lbTotal.Text = String.Format("{0:n}", CDec(TotalTTC))
        End Set
    End Property
    Public Property bl As Integer
        Get
            Return _bl
        End Get
        Set(ByVal value As Integer)
            _bl = value
            If bl > 0 Then
                btAdd.Visible = False
                btClear.Visible = False
            End If
        End Set
    End Property
    Public bprice As Double = 0
    Public ref As String
    Public depot As Integer = 0

    Public TVA As Double = 20

    Public ReadOnly Property TotalHt() As Double
        Get
            Dim t As Double = sprice * qte
            't /= (100 + TVA) / 100
            Return t
        End Get
    End Property
    Public ReadOnly Property TotaltVA() As Double
        Get
            Dim t As Double = TotalHt - TotalRemise
            t = (t * TVA) / 100

            Return t
        End Get
    End Property
    Public ReadOnly Property TotalRemise() As Double
        Get
            Dim t As Double = (TotalHt * remise) / 100

            Return t
        End Get
    End Property
    Public ReadOnly Property TotalTTC() As Double
        Get
            Dim t As Double = (TotalHt - TotalRemise) + TotaltVA

            Return t
        End Get
    End Property

    Public Property article As Article
        Get
            _article.arid = arid
            _article.cid = cid
            _article.name = ArticleName
            _article.qte = qte
            _article.sprice = sprice
            _article.bprice = bprice
            _article.ref = ref
            _article.depot = depot
            _article.remise = remise
            Return _article
        End Get
        Set(ByVal value As Article)
            _article = value
            arid = _article.arid
            cid = _article.cid
            ArticleName = _article.name
            qte = _article.qte
            sprice = _article.sprice
            bprice = _article.bprice
            ref = _article.ref
            depot = _article.depot
            remise = _article.remise
        End Set
    End Property
    Public Property Stock As Double
        Get
            Return _Stk
        End Get
        Set(ByVal value As Double)
            _Stk = value

            If Stock = 0 Then
                PlLeft.BackgroundImage = My.Resources.ERROR_15
            ElseIf _Stk < alert Then
                PlLeft.BackgroundImage = My.Resources.WARNING_15
            Else
                PlLeft.BackgroundImage = Nothing
            End If
        End Set
    End Property

    Public Property EditMode() As Boolean
        Get
            Return _editMode
        End Get
        Set(ByVal value As Boolean)
            _editMode = value

            If value Then
                PlButtom.Height = Me.Height

                Dim addR As New AddRow
                addR.Dock = DockStyle.Fill

                AddHandler addR.AddNewArticle, AddressOf SaveEditAricle
                AddHandler addR.Cleared, AddressOf CancelChangement
                PlButtom.Controls.Add(addR)
                addR.txtN.txtReadOnly = True
                addR.txtRf.txtReadOnly = True
                addR.txtQ.text = article.qte
                addR.FillFields(article)
            Else
                PlButtom.Height = 1
                PlButtom.Controls.Clear()
            End If
        End Set
    End Property
    Public Property normalFont() As Font
        Get
            Return _fntNormal
        End Get
        Set(ByVal value As Font)
            _fntNormal = value

            lbref.Font = value
            lbName.Font = value
            lbQte.Font = value
            lbPrice.Font = value
            lbRemise.Font = value
        End Set
    End Property
    Public Property titleFont() As Font
        Get
            Return _fntTitle
        End Get
        Set(ByVal value As Font)
            _fntTitle = value
            lbTotal.Font = value
        End Set
    End Property
    Public Property index() As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)

            _index = value

            'Dim cr As Color = Color.Turquoise
            'If (value Mod 2) = 0 Then cr = Color.Magenta
            'PlButtom.BackColor = cr

            Panel1.BackgroundImage = Nothing
            If (value Mod 2) = 0 Then Panel1.BackgroundImage = My.Resources.gui_13
        End Set
    End Property
    Public Property ColumnWidth() As Integer
        Get
            Return plQ.Width
        End Get
        Set(ByVal value As Integer)
            plQ.Width = value
            plRef.Width = value
            plP.Width = CInt(value * 4 / 3)
            plR.Width = CInt(value * 2 / 3)
            plT.Width = CInt(value * 5 / 3)
        End Set
    End Property
    Public Property isSelected() As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            _isSelected = value
            If value Then
                Me.BackColor = Color.AntiqueWhite
            Else
                Me.BackColor = Color.Transparent
            End If
        End Set
    End Property

    Public Sub New(ByVal art As Article)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        article = art
    End Sub
    Private Sub lbName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbName.TextChanged
        Me.Height = lbName.Height + 32
    End Sub
    Private Sub lbref_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plT.Click, plSet.Click, plR.Click, plQ.Click, plP.Click, plNm.Click, PlLeft.Click, lbTotal.Click, lbRemise.Click, lbref.Click, lbQte.Click, lbPrice.Click, lbName.Click, Panel1.Click
        isSelected = Not isSelected
        RaiseEvent selected(Me)
    End Sub
    'Raise Event
    Private Sub CancelChangement(ByVal sender As System.Object, ByVal e As System.EventArgs)
        EditMode = False
    End Sub
    Private Sub SaveEditAricle(ByVal art As A1_GAESTION_COMMERCIAL.Article)
        RaiseEvent itemChanged(Me, art)
    End Sub
    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        If bl > 0 Then Exit Sub
        RaiseEvent DeleteItem(Me)
    End Sub
    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If bl > 0 Then Exit Sub
        EditMode = True
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent GetArticleInfos(arid)
    End Sub
End Class
