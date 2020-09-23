Public Class RPanel
    'Events
    Public Event UpdateItem(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UpdateQte(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UpdatePrice(ByVal sender As Object, ByVal e As EventArgs)
    Public Event UpdateDepot(ByVal sender As Object, ByVal e As EventArgs)
    Public Event DeleteItem(ByRef i As Items, ByVal id As Integer)
    Public Event UpdatePayment()
    Public Event UpdateBl()
    Public Event SetDetailFacture()
    Public Event UpdateClient()
    Public Event SaveFacture(ByVal id As Integer, ByVal total As Double, ByVal avance As Double, ByVal tva As Double, ByVal table As DataTable)
    Public Event SaveAndPrint()
    Public Event EditFacture(ByVal id As Integer, ByVal Clid As Integer, ByVal ClientName As String, ByVal total As Double, ByVal avance As Double, ByVal table As DataTable)
    Public Event DeleteFacture(ByVal id As Integer, ByVal isSell As Boolean, ByVal EM As Boolean, ByVal table As DataTable)
    Public Event CPValueChange()
    Public Event UpdateArticleRemise(ByRef i As Items)
    'Edit Mode Events
    Public Event EditingItemValueChanged(ByVal oldValue As Double, ByVal newValue As Double, ByVal Field As String, ByVal itm As Items)
    Public Event SetDetailArticle(ByVal txt As String, ByRef i As Items)
    Public Event CommandeDate()
    Public Event UpdateValueChanged()
    'Members
    Public myClient As Client
   
    Public isSell As Boolean = True
    Public _bl As String
    Public isUniqTva As Boolean
    Private _hasManyRemise As Boolean
    Public myDate As Date
    Public modePayement As String = ""

    Private _Num As Integer
    Private _Total As Decimal
    Private _Avance As Decimal
    Private _EditMode As Boolean

    Private _isEditing As Boolean
    Private _oldValue As Decimal
    Private _newValue As Decimal
    Private _Field As String
    Private _editingItem As Items
    Private _Remise As Decimal
    Private _ShowClc As Boolean
    Private _hideClc As Boolean
    Private _ShowProfit As Boolean
    Private _delivredDay As String

    'properties
    Public ReadOnly Property Total_Ht As Decimal
        Get
            Dim a As Items
            Dim t As Decimal = 0
            For Each a In Pl.Controls
                t += a.Total_ht
            Next
            'If hasManyRemise = False Then t -= (t * Remise) / 100
            Return t
        End Get
    End Property
    Public ReadOnly Property Tva As Decimal
        Get

            Dim tv As Decimal = 0
            If hasManyRemise = False Then
                If isUniqTva Then
                    Dim a As Items
                    For Each a In Pl.Controls
                        Dim ttl As Double = (a.Total_ttc / ((100 + a.Tva) / 100))
                        tv = tv + ((ttl - (ttl * _Remise / 100)) * a.Tva / 100)
                    Next
                Else
                    Dim T As Decimal = Total_Ht
                    tv = (T - (T * _Remise / 100)) * 20 / 100
                End If

            Else
                Dim a As Items
                For Each a In Pl.Controls
                    tv += a.Total_tva
                Next
            End If

            Return tv
        End Get
    End Property
    Public ReadOnly Property Total_TTC As Decimal
        Get
            Dim t As Decimal = 0

            If hasManyRemise = False Then
                t = (Total_Ht - (Total_Ht * Remise / 100)) + Tva
            Else
                Dim a As Items
                For Each a In Pl.Controls
                    t += a.Total_ttc
                Next
            End If

            Return t
        End Get
    End Property
    Public ReadOnly Property Rest As Decimal
        Get
            Return Total_TTC - _Avance
        End Get
    End Property
    Public Property Avance As Decimal
        Get
            Return _Avance
        End Get
        Set(ByVal value As Decimal)
            _Avance = value
            Lbavc.Text = String.Format("{0:n}", value)
        End Set
    End Property
    Public Property Remise As String
        Get
            If hasManyRemise = False Then
                Return _Remise
            Else
                Dim a As Items
                Dim r As Decimal = 0

                For Each a In Pl.Controls
                    r += a.Total_remise
                Next
                Try
                    Return (r * 100) / Total_Ht
                Catch ex As Exception
                    Return 0
                End Try
            End If
        End Get
        Set(ByVal value As String)

            If hasManyRemise = False Then
                Try
                    If value.Contains(".") Then value = value.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    If IsNumeric(value) = False Then value = 0
                    _Remise = value
                    'CP.BtRemise.Text = "Remise (" & value & " %)"
                    lbremise.Text = "Remise = " & String.Format("{0:F}", Total_Ht * _Remise / 100)
                Catch ex As Exception
                    _Remise = 0
                    'CP.BtRemise.Text = "Remise (0 %)"
                    lbremise.Text = "Remise = 0"
                End Try
            End If
        End Set
    End Property
    Public Property bl As String
        Get
            Return _bl
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "---"
            _bl = value
            CP.bl = value
        End Set
    End Property
    Public ReadOnly Property SelectedItem As Items
        Get
            Dim a As Items
            For Each a In Pl.Controls
                If a.IsSelected = True Then
                    Return a
                End If
            Next
            Return Nothing
        End Get
    End Property
    Public ReadOnly Property TotalProfit_ht As Decimal
        Get
            Dim t As Decimal = 0
            Dim a As Items

            If hasManyRemise = True Then
                For Each a In Pl.Controls
                    t += a.Profit_ht
                Next
            Else
                t = (Total_Ht - (Total_Ht * Remise / 100))
                Dim b As Decimal = 0
                For Each a In Pl.Controls
                    b += (a.Qte * a.Bprice) / ((100 + a.Tva) / 100)
                Next

                t = t - b
            End If
            Return t
        End Get
    End Property

    Public ReadOnly Property DataSource As DataTable
        Get
            Dim table As New DataTable

            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("priceHt", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("unite", GetType(String))
            table.Columns.Add("total", GetType(Double))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("ref", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("poid", GetType(Integer))
            table.Columns.Add("totalHt", GetType(Double))
            table.Columns.Add("totaltva", GetType(Double))
            table.Columns.Add("dsid", GetType(Double))
            table.Columns.Add("remise", GetType(Double))
            Dim a As Items
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.arid, a.Name, a.Price, a.Price_Ht, a.Bprice, a.Tva,
                               a.Qte, a.Unite, a.Total_ttc, a.cid, a.code,
                               a.Depot, a.Poid, a.Total_ht, a.Total_tva, a.id, a.Remise)
            Next
            Return table
        End Get
    End Property
    Public ReadOnly Property myDataSource As List(Of Article)
        Get
            Dim table As New List(Of Article)

            Dim a As Items
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Add(New Article(a.arid, a.cid, a.Name, a.Unite, "", a.Qte, a.Price, a.Bprice, a.Tva, a.Remise,
                                      a.Depot, True, a.code, False))
            Next
            Return table
        End Get
    End Property
    Public Property hasManyRemise As Boolean
        Get
            Return _hasManyRemise
        End Get
        Set(ByVal value As Boolean)
            _hasManyRemise = value
            CP.hasRemise = value
        End Set
    End Property
    
    
    Public Property ShowProfit As Boolean
        Get
            Return _ShowProfit
        End Get
        Set(ByVal value As Boolean)
            _ShowProfit = value
            lbProfit.Visible = value

            'If value = False Then
            '    LbVidal.Top = lbProfit.Top
            '    LbVidal.Left = lbProfit.Left
            'Else
            '    LbVidal.Top = LbTva.Top
            '    LbVidal.Left = 81
            'End If
        End Set
    End Property
    Public Property Num As Integer
        Get
            Return _Num
        End Get
        Set(ByVal value As Integer)
            _Num = value
            Label2.ForeColor = Color.Black
            LbSum.ForeColor = Color.Black
            If value > 0 Then
                Label2.ForeColor = Color.Blue
                LbSum.ForeColor = Color.Blue
            End If
        End Set
    End Property
    Public Property delivredDay As String
        Get
            Return _delivredDay
        End Get
        Set(ByVal value As String)
            _delivredDay = value
            CP.BtCmd.BackColor = Color.MistyRose
            CP.BtCmd.ForeColor = Color.Maroon
            If value <> "0" And value <> "-" Then
                CP.BtCmd.BackColor = Color.ForestGreen
                CP.BtCmd.ForeColor = Color.White
            End If
        End Set
    End Property


    'Subs & functions
    Public Sub AddItem(ByVal R As ALMohassinDBDataSet.ArticleRow)
        Try
            'Never add charges items to selling items
            Dim qte As Double = CP.Value
            Dim ap As Items

            If IsExiste(R.arid) And Form1.pv_useMergeArt = True Then

                For Each ap In Pl.Controls
                    If ap.arid = R.arid Then

                        ap.Qte += qte
                        Exit For
                    End If
                Next
            Else
                Dim h As Integer = 0
                ap = New Items
                ap.Dock = DockStyle.Top
                ap.Index = Pl.Controls.Count
                ap.Name = R.name
                ap.Unite = R.stockType ' unite
                If isSell Then
                    ap.Price = R.sprice
                    ''use many prices 
                    'If Num > 0 Then
                    '    ap.Price = R.bprice + (R.bprice * Num / 100)
                    'End If
                Else
                    ap.Price = R.bprice
                End If
                Dim rnd As New Random
                ap.Bprice = R.bprice
                ap.BgColor = Color.White
                ap.SideColor = Color.Moccasin
                ap.id = rnd.Next
                ap.arid = R.arid
                ap.Tva = 20
                If isUniqTva Then ap.Tva = R.tva
                ap.cid = R.cid
                ap.code = R.ref
                ap.Poid = 0
                'ap.Depot = CP.Depot ' R.depot
                'If Form1.CbDepotOrigine.Checked Then ap.Depot = R.depot
                ap.Depot = Form1.mainDepot 'R.depot
                ap.Remise = 0

                ''''''''


                'Using c As SubClass = New SubClass

                '    If Form1.CbQteStk.Checked And isSell Then
                '        Dim stk = c.getStock(ap.arid, ap.Depot, 0)
                '        If qte >= stk Then qte = stk

                '        If ClId = -1 Then qte = stk

                '        If qte < 0 Then qte = 0
                '    End If

                '    ap.ColorStock = c.CheckForMinStock(ap.arid, ap.Depot, qte)
                '    ap.Stock = c.getStock(ap.arid, ap.Depot, qte)
                'End Using

                ap.Qte = qte

                'ap.IsArabic = True

                AddHandler ap.Click, AddressOf ClearPanel
                AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
                AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
                AddHandler ap.RemiseChanged, AddressOf UpdateValue

                ap.SendToBack()
                Pl.Controls.Add(ap)

            End If

            ap.IsSelected = True
            Item_Doubleclick(ap, Nothing)

            UpdateValue()
            CP.Value = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddItems(ByVal Ds As List(Of Article))
        Try
            Dim rnd As New Random

            For Each art As Article In Ds

                If IsExiste(art.arid) And Form1.pv_useMergeArt = True Then
                    Dim a As Items
                    For Each a In Pl.Controls
                        If a.arid = art.arid Then

                            a.Qte += art.qte

                            a = Nothing
                            UpdateValue()
                            CP.Value = 0
                            Exit For
                        End If
                    Next
                Else
                    Dim ap As New Items
                    ap.Dock = DockStyle.Top
                    ap.Index = Pl.Controls.Count
                    ap.Name = art.name
                    ap.Unite = art.unite
                    ap.Price = art.spriceTTC
                    ap.Qte = art.qte
                    ap.Bprice = art.bprice
                    ap.id = rnd.Next  '' random
                    ap.arid = art.arid
                    ap.Tva = art.TVA
                    ap.cid = art.cid
                    ap.Depot = art.depot
                    ap.code = art.ref
                    ap.Remise = art.remise

                    ap.BgColor = Color.White
                    ap.SideColor = Color.Moccasin

                    ''''''''
                    'Using c As SubClass = New SubClass
                    '    ap.ColorStock = c.CheckForMinStock(ap.arid, ap.Depot, ap.Qte)
                    '    ap.Stock = c.getStock(ap.arid, ap.Depot, ap.Qte)
                    'End Using

                    AddHandler ap.Click, AddressOf ClearPanel
                    AddHandler ap.ItemDoubleClick, AddressOf Item_Doubleclick
                    AddHandler ap.Item_DoubleClick, AddressOf Item_ShowBlocModif
                    'AddHandler ap.ItemValueChanged, AddressOf Item_Value_changed
                    AddHandler ap.RemiseChanged, AddressOf UpdateValue

                    ap.SendToBack()
                    Pl.Controls.Add(ap)
                    ap = Nothing
                End If

            Next
            UpdateValue()
            CP.Value = 0
            CP.ActiveQte(False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    '''''
    Private Sub UpdateValue()
        LbSum.Text = String.Format("{0:n}", Total_TTC)
        LbVidal.Text = Pl.Controls.Count & " - Vidals"

        'lbHT.Text = "T. Ht : " & String.Format("{0:n}", CDec(Total_Ht - (Total_Ht * Remise / 100)))
        lbHT.Text = "T. Ht : " & String.Format("{0:n}", Total_Ht)
        LbTva.Text = "Tva : " & String.Format("{0:n}", Tva)

        lbremise.Text = "Remise = " & String.Format("{0:n}", CDec(Total_Ht * Remise / 100))

        Try
            If ShowProfit Then
                lbProfit.Text = "[" & String.Format("{0:n}", TotalProfit_ht) & " Dhs - " & String.Format("{0:n}", TotalProfit_ht * 100 / Total_Ht) & "%]"
            End If
        Catch ex As Exception

        End Try

        RaiseEvent UpdateValueChanged()

        If _isEditing = False Then Exit Sub
        RaiseEvent EditingItemValueChanged(_oldValue, _newValue, _Field, _editingItem)
        _isEditing = False
    End Sub
    Public Sub ClearItems()
        Pl.Controls.Clear()
        _Total = 0
        LbSum.Text = Total_TTC
        LbTva.Text = "Tva : 0"
        LbVidal.Text = Pl.Controls.Count & " - Vidals"
        lbHT.Text = "T. Ht : " & String.Format("{0:n}", Total_Ht)
        Avance = 0
        'FctId = 0
        myDate = Now.Date
        Remise = 0
        bl = "---"
        lbProfit.Text = "[]"
        delivredDay = "-"
    End Sub
    Public Function IsExiste(ByVal arid As Integer) As Boolean
        Dim a As Items
        If Pl.Controls.Count = 0 Then
            Return False
        End If
        For Each a In Pl.Controls
            If a.arid = arid Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Public Sub ChangedItems(ByRef id As Integer, ByVal prdname As String, ByVal bprice As Double, ByVal price As Double, ByVal qte As Double)

        Dim a As Items
        For Each a In Pl.Controls
            If a.id = id Then
                a.Name = prdname
                a.Bprice = bprice
                a.Price = price
                a.Qte = qte

                UpdateValue()
                CP.Value = 0

                'Using c As SubClass = New SubClass
                '    a.ColorStock = c.CheckForMinStock(a.arid, a.Depot, a.Qte)
                '    a.Stock = c.getStock(a.arid, a.Depot, a.Qte)
                'End Using
                Exit For
            End If
        Next
    End Sub
    'item bloc
    Private Sub Item_Doubleclick(ByVal sender As Object, ByVal e As EventArgs)
        Dim it As Items = sender

        For Each i As Items In Pl.Controls
            If i.id = it.id Then Continue For
            i.IsSelected = False
        Next

        CP.ActiveQte(it.IsSelected)
    End Sub
    Private Sub Item_ShowBlocModif(ByVal sender As Object, ByVal e As EventArgs)
        '_oldValue = SelectedItem.Qte
        Dim itm As Items = sender
        If itm.cid = 0 Then Exit Sub
        itm.IsSelected = True
        Item_Doubleclick(itm, e)

        RaiseEvent UpdateItem(itm, Nothing)
    End Sub
    Private Sub ClearPanel(ByVal sender As Object, ByVal e As EventArgs)
        Dim i As Items = sender
        IIf(i.IsSelected, False, True)
    End Sub

    Private Sub CP_UpdateArticledepot() Handles CP.UpdateArticledepot
        If SelectedItem.cid = 0 Then Exit Sub
        RaiseEvent UpdateDepot(Me, Nothing)
    End Sub
    Private Sub CP_UpdateQte() Handles CP.UpdateQte
        RaiseEvent UpdateItem(SelectedItem, Nothing)
    End Sub
    Private Sub CP_ValueChange() Handles CP.ValueChange
        RaiseEvent CPValueChange()
    End Sub
    Private Sub CP_DeleteItems() Handles CP.DeleteItems
        _oldValue = SelectedItem.Qte
        'RaiseEvent DeleteItem(SelectedItem)

        Pl.Controls.Remove(SelectedItem)

        CP.ActiveQte(False)

        'If EditMode Then
        '    _isEditing = True
        '    Item_Value_changed(0, 0, "Non", SelectedItem)
        'End If

        UpdateValue()
    End Sub

    Private Sub CP_UpdatePayment() Handles CP.UpdatePayment
        RaiseEvent UpdatePayment()
    End Sub

    Private Sub CP_PrintTicket() Handles CP.PrintTicket
        RaiseEvent SaveAndPrint()
    End Sub
End Class

