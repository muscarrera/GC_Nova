Public Class gTable


    Dim _tabProp As gTabClass

    Event PropChanged()

    Public Property TabProp As gTabClass
        Get
            Return _tabProp
        End Get
        Set(ByVal value As gTabClass)
            _tabProp = value
            If IsNothing(value) Then Exit Property

            txtW.text = value.TabWidth
            txtH.text = value.TabHeight
            txtX.text = value.x
            txtY.text = value.y
            txtType.text = value.Type
            cbLine.Checked = value.hasLines

            If IsNothing(value.details) Then Exit Property
            pl.Controls.Clear()

            For Each c As gColClass In value.details
                Try
                    addNewCol(c)
                Catch ex As Exception
                End Try
            Next

            RaiseEvent PropChanged()
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TabProp = New gTabClass
    End Sub
    Private Sub addNewCol(ByVal txt As String)
        Dim gcc As New gColClass

        gcc.HeaderName = txt
        gcc.Field = ComboBox1.SelectedValue
        gcc.index = pl.Controls.Count

        Dim gc As New gColumn
        gc.Dock = DockStyle.Left
        gc.Prop = gcc
        AddHandler gc.ClearCol, AddressOf GC_Clear
        AddHandler gc.ColWidthChanged, AddressOf GC_WidthChanged
        pl.Controls.Add(gc)
        Try
            TabProp.details.Add(gcc)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        gc.txtW.text = 80
        GC_WidthChanged(gc)
        gc.BringToFront()

        RaiseEvent PropChanged()
    End Sub
    Private Sub addNewCol(ByVal gcc As gColClass)
        Dim gc As New gColumn
        gc.Dock = DockStyle.Left
        gc.Prop = gcc
        AddHandler gc.ClearCol, AddressOf GC_Clear
        AddHandler gc.ColWidthChanged, AddressOf GC_WidthChanged
        pl.Controls.Add(gc)
        gc.BringToFront()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        addNewCol(ComboBox1.Text)
    End Sub

    Private Sub GC_Clear(ByVal gColumn As gColumn)
        pl.Controls.Remove(gColumn)
        TabProp.details.Remove(gColumn.Prop)

        If pl.Controls.Count > 0 Then
            Dim i = 0
            For Each c As gColumn In pl.Controls
                c.Prop.index = i
                i += 1
            Next
        End If

        RaiseEvent PropChanged()

    End Sub

    Private Sub GC_WidthChanged(ByVal gColumn As gColumn)
        If pl.Controls.Count > 0 Then
            Dim w = 0
            For Each c As gColumn In pl.Controls
                w += c.Prop.ColWidth
            Next

            If CInt(txtW.text) < w Then
                w = w - CInt(txtW.text)
                w = CInt(w / pl.Controls.Count)
                For Each c As gColumn In pl.Controls
                    c.Prop.ColWidth -= w
                    If c.Prop.ColWidth < 0 Then c.Prop.ColWidth = 0
                    c.txtW.text = c.Prop.ColWidth
                Next
            End If
            RaiseEvent PropChanged()
        End If
    End Sub

    Private Sub txtW_TxtChanged() Handles txtW.TxtChanged
        If IsNumeric(txtW.text) Then
            TabProp.TabWidth = CInt(txtW.text)

            RaiseEvent PropChanged()
        End If
    End Sub
    Private Sub txtH_TxtChanged() Handles txtH.TxtChanged
        If IsNumeric(txtH.text) Then
            TabProp.TabHeight = CInt(txtH.text)

            RaiseEvent PropChanged()
        End If
    End Sub
    Private Sub txtx_TxtChanged() Handles txtX.TxtChanged
        If IsNumeric(txtX.text) Then
            TabProp.x = CInt(txtX.text)

            RaiseEvent PropChanged()
        End If
    End Sub
    Private Sub txty_TxtChanged() Handles txtY.TxtChanged
        If IsNumeric(txtY.text) Then
            TabProp.y = CInt(txtY.text)


            RaiseEvent PropChanged()
        End If
    End Sub
    Private Sub txtType_TxtChanged() Handles txtType.TxtChanged
        TabProp.Type = txtType.text

        RaiseEvent PropChanged()
    End Sub

    Private Sub gTable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim PARAMS As New Dictionary(Of String, String)
        PARAMS.Add("Designation", "name")
        PARAMS.Add("Réf", "ref")
        PARAMS.Add("Prix", "price")
        PARAMS.Add("Prix TTC", "xPriceTTC")
        PARAMS.Add("Remise", "remise")
        PARAMS.Add("Qte", "qte")
        PARAMS.Add("Total", "xTotal")
        PARAMS.Add("Total TTC", "xTotalTTC")
        PARAMS.Add("Tva", "tva")
        PARAMS.Add("Dpt N°", "depot")
        PARAMS.Add("bl Ref", "bl")
        PARAMS.Add("Entrepôte", "xdepot")
        PARAMS.Add("Réf & Designation", "xname")

        ComboBox1.ValueMember = "Value"
        ComboBox1.DisplayMember = "Key"

        ComboBox1.DataSource = New BindingSource(PARAMS, Nothing)
    End Sub


    Private Sub cbLine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLine.CheckedChanged
        TabProp.hasLines = cbLine.Checked

        RaiseEvent PropChanged()
    End Sub
End Class
