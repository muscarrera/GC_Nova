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
    Public Event SaveAndPrint(ByVal id As Integer, ByVal total As Double, ByVal avance As Double, ByVal tva As Double, ByVal table As DataTable, ByVal b As Boolean, ByVal isBl As Boolean)
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
    Public ClientName As String
    Public ClientAdresse As String
    Public FctId As Integer
    Public ClId As Integer
    Public isSell As Boolean = True
    Public _bl As String
    Public isUniqTva As Boolean
    Private _hasManyRemise As Boolean

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

            'If isUniqTva Then

            '    For Each a In Pl.Controls
            '        t = t + (a.Total_ttc / ((100 + a.Tva) / 100))
            '    Next
            '    Return t
            'Else
            '    For Each a In Pl.Controls
            '        t = t + a.Total_ttc
            '    Next
            '    Return CDbl(t / 1.2)
            'End If

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
    Public ReadOnly Property DataSource As DataTable
        Get
            Dim table As New DataTable

            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("unite", GetType(String))
            table.Columns.Add("total", GetType(Double))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("code", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("poid", GetType(Integer))
            table.Columns.Add("totalHt", GetType(Double))
            table.Columns.Add("totaltva", GetType(Double))
            table.Columns.Add("dsid", GetType(Double))
            table.Columns.Add("remise", GetType(Double))
            Dim a As Items
            For Each a In Pl.Controls
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.arid, a.Name, a.Price, a.Bprice, a.Tva,
                               a.Qte, a.Unite, a.Total_ttc, a.cid, a.code,
                               a.Depot, a.Poid, a.Total_ht, a.Total_tva, a.id, a.Remise)
            Next
            Return table
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

    Public Property EditMode As Boolean
        Get
            Return _EditMode
        End Get
        Set(ByVal value As Boolean)
            _EditMode = value
            CP.EditMode = value
            If value = True Then
                'CP.Visible = False
                'PlButtom.Height = 45
                BtSave.Text = "   Modifier"
            Else
                'If ShowClc Then CP.Visible = True
                'If ShowClc Then PlButtom.Height = 242
                BtSave.Text = "   Enreg"
            End If
            CP.ActiveQte(False)
            'ShowClc = True
        End Set
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
    Public Property ShowClc As Boolean
        Get
            Return _ShowClc
        End Get
        Set(ByVal value As Boolean)
            _ShowClc = value

            CP.Visible = value
            CP.ActiveQte(False)
        End Set
    End Property
    Public Property hideClc As Boolean
        Get
            Return _hideClc
        End Get
        Set(ByVal value As Boolean)
            _hideClc = value
            CP.Height = 44
            CP.Visible = value
            If value Then CP.Height = 242
            CP.ActiveQte(False)
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

    Public Property TypePrinter As String
        Get
            Return "&"
        End Get
        Set(ByVal value As String)

            If value = "Receipt" Then

                BtPrint.Width = 125
                BtPrint.Visible = True
                BtBlPrint.Visible = False

                BtPrint.TextAlign = ContentAlignment.MiddleCenter

            ElseIf value = "Normal" Then

                BtBlPrint.Width = 125
                BtBlPrint.Visible = True
                BtPrint.Visible = False

                BtBlPrint.TextAlign = ContentAlignment.MiddleCenter

                BtBlPrint.Left = BtPrint.Left
            Else
                BtBlPrint.Width = 65
                BtPrint.Width = 65
                BtBlPrint.Visible = True
                BtPrint.Visible = True

                BtPrint.TextAlign = ContentAlignment.MiddleRight
                BtBlPrint.TextAlign = ContentAlignment.MiddleRight

                BtBlPrint.Left = BtPrint.Left + 75
            End If
        End Set
    End Property

End Class

