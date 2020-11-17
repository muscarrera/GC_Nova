Public Class Items
 
    Public Event ItemDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Item_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ItemValueChanged(ByVal oldValue As Double, ByVal newValue As Double, ByVal Field As String, ByVal itm As Items)
    Public Event RemiseChanged()
    'Members
    Private _addDesc As String
    Private _showDesc As Boolean

    Private _qte As Decimal
    Private _price As Decimal
    Private _total As Decimal
    Private _tva As Double
    Private _stock As Double
    Private _index As Integer
    Private _color As Color
    Private _BgColor As Color
    Private _isSelected As Boolean
    Private _remise As Integer
    Private _code As String
    Private _name As String
    Private _colorStock As Integer = 0

    Public id As Integer
    Public arid As Integer

    Public Unite As String
    Public Bprice As Double
    Public Poid As Double
    Public cid As Integer
    Private _depot As Integer

    'properties
    Public ReadOnly Property Total_ttc() As Decimal
        Get
            If Remise > 0 Then
                Return Total_ht + Total_tva
            Else
                Return _total
            End If
        End Get
    End Property
    Public ReadOnly Property Total_ht() As Decimal
        Get
            Dim t As Decimal = _total / ((100 + Tva) / 100)
            t -= (t * Remise) / 100
            Return Math.Round(t, 3)
        End Get
    End Property
    Public ReadOnly Property Total_tva() As Decimal
        Get
            Dim t As Decimal = Total_ht
            t = (t * Tva) / 100
            Return Math.Round(t, 3)
        End Get
    End Property
    Public ReadOnly Property Total_remise() As Decimal
        Get
            Dim t As Decimal = _total / ((100 + Tva) / 100)
            t = (t * Remise) / 100
            Return Math.Round(t, 3)
        End Get
    End Property
    Public ReadOnly Property Profit_ht() As Decimal
        Get
            Dim t As Decimal = (Qte * Bprice) / ((100 + Tva) / 100)
            't -= (t * Remise) / 100
            t = Total_ht - t
            Return Math.Round(t, 3)
        End Get
    End Property

    Shadows Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
            FullName = _name '& " " & _code
        End Set
    End Property
    Shadows Property code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
            ' FullName = _name & " " & _code
        End Set
    End Property
    Shadows Property FullName() As String
        Get
            Return LbName.Text
        End Get
        Set(ByVal value As String)
            LbName.Text = value
        End Set
    End Property

    Public Property Qte() As Decimal
        Get
            Return _qte
        End Get
        Set(ByVal value As Decimal)
            '''''''
            RaiseEvent ItemValueChanged(_qte, value, "qte", Me)
            '''''''
            _qte = value
            _total = Price_TTC * value
            LbTotal.Text = String.Format("{0:n}", Total_ttc)
            LbQte.Text = _qte & " " & CStr(Unite) '& " x "
        End Set
    End Property
    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            '''''''
            RaiseEvent ItemValueChanged(_price, value, "price", Me)
            '''''''
            _price = value
            _total = _qte * Price_TTC
            LbTotal.Text = String.Format("{0:n}", Total_ttc)

            ' LbPrice.Text = String.Format("{0:n}", _price) & " Dhs"
            LbPrice.Text = String.Format("{0:n}", _price * ((100 + Tva) / 100)) & " Dhs"
        End Set
    End Property

    Public ReadOnly Property Price_Ht() As Decimal
        Get
            ' Return _price / ((100 + Tva) / 100)
            Return Math.Round(Price, 3)
        End Get
    End Property
    Public ReadOnly Property Price_TTC() As Decimal
        Get
            Dim t = _price * ((100 + Tva) / 100)
            Return Math.Round(t, 3)
        End Get
    End Property
    Public ReadOnly Property bPrice_TTC() As Decimal
        Get
            Dim t = Bprice * ((100 + Tva) / 100)
            Return Math.Round(t, 3)
        End Get
    End Property
    Public Property Depot() As Decimal
        Get
            Return _depot
        End Get
        Set(ByVal value As Decimal)
            '''''''
            _depot = value

            LbStk.Text = ""
            If Depot > 0 Then LbStk.Text = " [" & Depot & "] Rest : (" & Stock & ")"

        End Set
    End Property
    Public Property Tva() As Double
        Get
            Return _tva
        End Get
        Set(ByVal value As Double)
            _tva = value
            LbTva.Text = "Tva:" & value & "%"
            If Remise > 0 Then LbTva.Text &= "-R:" & Remise & "%"
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
        End Set
    End Property
    Public Property SideColor() As Color
        Get
            Return _color
        End Get
        Set(ByVal value As Color)
            _color = value
        End Set
    End Property
    Public Property BgColor() As Color
        Get
            Return _BgColor
        End Get
        Set(ByVal value As Color)
            _BgColor = value
            Pl.BackColor = value
        End Set
    End Property
    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            _isSelected = value
            If value Then
                Pl.BackColor = _color
            Else
                Pl.BackColor = _BgColor
            End If
        End Set
    End Property
    Public Property IsArabic As Boolean
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
            'If value Then
            '    LbTotal.Left = 0
            '    LbTva.Left = 0
            '    LbTotal.TextAlign = ContentAlignment.MiddleLeft
            '    LbTva.TextAlign = ContentAlignment.MiddleLeft

            '    LbTotal.Anchor = AnchorStyles.Left
            '    LbTva.Anchor = AnchorStyles.Left
            '    LbName.Anchor = AnchorStyles.Right
            '    LbDesc.Anchor = AnchorStyles.Right

            '    LbName.TextAlign = ContentAlignment.MiddleRight
            '    LbDesc.TextAlign = ContentAlignment.MiddleRight

            '    LbName.AutoSize = False
            '    LbDesc.AutoSize = False

            '    LbName.Width = Me.Width - LbTotal.Width - 5
            '    LbDesc.Width = Me.Width - LbTotal.Width - 5

            '    LbName.Left = Me.Width - LbName.Width
            '    LbDesc.Left = Me.Width - LbDesc.Width
            'End If
        End Set
    End Property

    Public Property Remise() As Integer
        Get
            Return _remise
        End Get
        Set(ByVal value As Integer)
            If value > 100 Then value = 100
            If value < 0 Then value = 0
            'If Form1.CbArticleRemise.Checked = False Then value = 0
            value = 0

            _remise = value
            LbTva.Text = "Tva:" & Tva & "%"
            If value > 0 Then LbTva.Text &= "-R:" & value & "%"

            RaiseEvent RemiseChanged()
        End Set
    End Property
    Public Property ShowDesc As Boolean
        Get
            Return _showDesc
        End Get
        Set(ByVal value As Boolean)
            _showDesc = value

            LbQte.Visible = value
            LbTva.Visible = value
        End Set
    End Property
    Public Property ColorStock() As Integer
        Get
            Return _colorStock
        End Get
        Set(ByVal value As Integer)

            _colorStock = value

            If value = 0 Then
                LbName.ForeColor = Color.DarkCyan
            ElseIf value = 1 Then
                LbName.ForeColor = Color.Orange
            Else
                LbName.ForeColor = Color.Red
            End If

            If Depot = 0 Then LbName.ForeColor = Color.Black
        End Set
    End Property
    Public Property Stock() As Double
        Get
            Return _Stock
        End Get
        Set(ByVal value As Double)

            _Stock = value

            'LbQte.Text = String.Format("{0:n}", _qte) & " " & CStr(Unite) & " x "
            'LbQte.Text &= String.Format("{0:n}", _price) & " Dhs  -  "
            LbStk.Text = ""
            If Depot > 0 Then LbStk.Text = " [" & Depot & "] Rest : (" & Stock & ")"

        End Set
    End Property


    Private Sub PlBody_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pl.Click, LbQte.Click, LbName.Click, LbTotal.Click, LbTva.Click, Panel1.Click, LbStk.Click, LbPrice.Click, Label3.Click, Label2.Click
        If IsSelected = True Then
            IsSelected = False
        Else
            IsSelected = True
        End If
        RaiseEvent ItemDoubleClick(Me, e)
    End Sub

    Private Sub Pl_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pl.DoubleClick, LbTva.DoubleClick, LbTotal.DoubleClick, LbName.DoubleClick, LbQte.DoubleClick, LbStk.DoubleClick, LbPrice.DoubleClick, Label3.DoubleClick, Label2.DoubleClick
        RaiseEvent Item_DoubleClick(Me, e)
    End Sub
End Class
