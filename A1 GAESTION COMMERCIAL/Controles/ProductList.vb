Public Class ProductList

    Private startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Private _dt As DataTable
    Public TableName As String = "Article"
    Public dt_Cats As DataTable
    Dim _dpid As Integer

    Public Event NewElement(ByRef ds As ProductList)
    Public Event EditArticle(ByRef ls As DataGridView, ByVal m As String)
    Public Event EditClient(ByRef ds As ProductList, ByRef ls As DataGridView)
    Public Event DeleteArticle(ByRef ds As ProductList, ByVal ls As DataGridView)
    Public Event DeleteClient(ByRef ds As ProductList, ByRef ls As DataGridView)
    Public Event GetElements(ByRef ds As ProductList)
    Public Event ModeChanged(ByVal ds As ProductList)
    Public Event GetClientDetails(ByVal ds As ProductList, ByVal _id As Integer)
    Public Event GetArticleStock(ByRef productList As ProductList)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtSearchCtg.PlaceHolder = "Groupe"
        txtSearchName.PlaceHolder = "N°/Designation/Réf"
    End Sub
    Public Property dpid As Integer
        Get
            Return _dpid
        End Get
        Set(ByVal value As Integer)
            _dpid = value


            If value > 0 Then
                btDepot.Text = value
                btDepot.BackgroundImage = My.Resources.BG_STK
                If TableName = "Article" Then RaiseEvent GetArticleStock(Me)
            Else
                btDepot.Text = ""
                btDepot.BackgroundImage = My.Resources.stock_icon_png_14
            End If
        End Set
    End Property

    Public Property AutoCompleteSourceGroupe() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtSearchCtg.AutoCompleteSource = value
        End Set
    End Property
    Private ReadOnly Property SelectedArticle() As ListLine
        Get
            Dim i As ListLine = Nothing
            For Each c As ListLine In pl.Controls
                If c.isSelected Then
                    i = c
                    Exit For
                End If
            Next
            Return i
        End Get
    End Property
    Private ReadOnly Property SelectedClient() As ClientRow
        Get
            Dim i As ClientRow = Nothing
            For Each c As ClientRow In pl.Controls
                If c.isSelected Then
                    i = c
                    Exit For
                End If
            Next
            Return i
        End Get
    End Property
    Public Property DataSource As DataTable
        Get
            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
            startIndex = 0
            lastIndex = 0   'value.Rows.Count
            lbValue.Visible = False
            lbValueTitle.Visible = False
            pl.Controls.Clear()

            numberOfItems = Form1.numberOfItems
            'numberOfPage = Math.Truncate(value.Rows.Count / numberOfItems)
            'If value.Rows.Count > numberOfItems * numberOfPage Then numberOfPage += 1
            numberOfPage = 1
            currentPage = 1
            If TableName = "Article" Then
                'FillRows()
                FillRowsArticles()
            ElseIf TableName = "Category" Then
                FillRowsCats()
            Else
                FillRowsClient()
            End If
            btPage.Text = "1/" & numberOfPage

            lbLnbr.Text = value.Rows.Count

        End Set
    End Property
    Public Property Mode As String
        Get
            Return TableName
        End Get
        Set(ByVal value As String)
            btDepot.Visible = False

            If value = "Client" Then
                plModeClient.Visible = True
                plModeArticle.Visible = False
                btClient.ForeColor = Color.Green
                btFournisseur.ForeColor = Color.DarkGray
            ElseIf value = "Fournisseur" Then
                plModeClient.Visible = True
                plModeArticle.Visible = False
                btClient.ForeColor = Color.DarkGray
                btFournisseur.ForeColor = Color.Green
            ElseIf value = "Article" Then
                plModeClient.Visible = False
                plModeArticle.Visible = True
                btArticle.ForeColor = Color.Green
                btCat.ForeColor = Color.DarkGray
                btDepot.Visible = True
            Else
                plModeClient.Visible = False
                plModeArticle.Visible = True
                btArticle.ForeColor = Color.DarkGray
                btCat.ForeColor = Color.Green
            End If


            TableName = value
        End Set
    End Property

    Private Sub FillRows()
        pl.Controls.Clear()

        lastIndex += numberOfItems

        If _dt.Rows.Count > 0 Then
            If lastIndex > _dt.Rows.Count - 1 Then
                'n = _dtList.Rows.Count - lastIndex
                lastIndex = _dt.Rows.Count - 1
            End If


            Dim arr(numberOfItems) As ListLine

            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ListLine
                a.Id = _dt.Rows(i).Item(0)
                a.lbDate.Text = StrValue(_dt, "ref", i)

                a.Libele = _dt.Rows(i).Item("name")

                Dim sp = DblValue(_dt, "sprice", i)
                Dim bp = DblValue(_dt, "bprice", i)

                If Form1.isBaseOnTTC Then
                    Dim tv = DblValue(_dt, "tva", i)
                    If Form1.isBaseOnOneTva Then tv = Form1.tva

                    sp += sp * tv / 100
                    bp += bp * tv / 100
                End If

                a.Total = bp
                a.Avance = sp

                If BoolValue(_dt, "isPromo", i) > 0 Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                Dim vid As Integer = IntValue(_dt, "cid", i)
                a.lbref.Text = vid

                Try
                    If vid > 0 Then
                        Dim query = From d In dt_Cats.AsEnumerable()
                                    Where d.Field(Of Integer)(0) = vid
                                    Select d

                        Dim r As DataTable = query.CopyToDataTable()

                        a.lbref.Text = r.Rows(0).Item("name")
                    End If
                Catch ex As Exception
                End Try

                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()

                AddHandler a.EditSelectedItem, AddressOf EditSelectedItem
                AddHandler a.DeleteItem, AddressOf DeleteItem
                AddHandler a.GetFactureInfos, AddressOf GetArticleInfos

                arr(i - startIndex) = a
                If i = lastIndex Then Exit For
            Next
            pl.Controls.AddRange(arr)
            startIndex = i
            RaiseEvent GetArticleStock(Me)
        End If
    End Sub
    Private Sub FillRowsArticles()
        pl.Controls.Clear()
        Try
            If _dt.Rows.Count > 0 Then

                For i As Integer = 0 To _dt.Rows.Count - 1
                    Dim vid As Integer = IntValue(_dt, "cid", i)

                    Try
                        If vid > 0 Then
                            Dim query = From d In dt_Cats.AsEnumerable()
                                        Where d.Field(Of Integer)(0) = vid
                                        Select d

                            Dim r As DataTable = query.CopyToDataTable()

                            _dt.Rows(i).Item(3) = r.Rows(0).Item("name")
                            _dt.Rows(i).Item(7) = 0
                        End If
                    Catch ex As Exception

                    End Try

                    If Form1.isBaseOnTTC Then
                        Dim tva As Double = DblValue(_dt, "tva", i)
                        If Form1.isBaseOnOneTva Then tva = Form1.tva

                        _dt.Rows(i).Item(5) += _dt.Rows(i).Item(5) * tva / 100
                        _dt.Rows(i).Item(6) += _dt.Rows(i).Item(6) * tva / 100
                    End If

                Next

                Dim dg As New DataGridView
                dg.DataSource = _dt

                StyleDatagrid(dg)

                pl.Controls.Add(dg)

                dg.Columns(0).Visible = False
                dg.Columns(1).Visible = False
                dg.Columns(7).Visible = False
                dg.Columns(8).Visible = False
                dg.Columns(9).Visible = False
                dg.Columns(10).Visible = False
                dg.Columns(11).Visible = False
                dg.Columns(12).Visible = False
                dg.Columns(13).Visible = False
                dg.Columns(14).Visible = False
                dg.Columns(15).Visible = False
                dg.Columns(16).Visible = False
                dg.Columns(17).Visible = False
                dg.Columns(18).Visible = False
                dg.Columns(19).Visible = False
                If Form1.useValue_CUMP = False Then dg.Columns(20).Visible = False

                If Form1.isWorkinOnStock Or Form1.useButtonValidForStock Then
                    dg.Columns(7).Visible = True
                    dg.Columns(7).HeaderText = "Stk"
                    dg.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                End If

                dg.Columns(2).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                dg.Columns(2).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
                dg.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dg.Columns(2).FillWeight = 69
             
                dg.Columns(3).HeaderText = "Grp"
                dg.Columns(2).HeaderText = "Designation"
                dg.Columns(4).HeaderText = "Réf"
                dg.Columns(5).HeaderText = "Pr Achat"
                dg.Columns(6).HeaderText = "Pr Vente"

                dg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dg.Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                dg.Columns(5).DefaultCellStyle.Format = "c"
                dg.Columns(6).DefaultCellStyle.Format = "c"
                dg.Columns(20).DefaultCellStyle.Format = "c"

                AddHandler dg.CellMouseDoubleClick, AddressOf Dg_MouseDoubleClick
                AddHandler dg.Sorted, AddressOf Dg_Sorted
                RaiseEvent GetArticleStock(Me)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillRowsCats()
        pl.Controls.Clear()
        Try
            If _dt.Rows.Count > 0 Then

                'Dim arr(_dt.Rows.Count - 1) As ListLine
                'Dim i As Integer = 0
                'For i = 0 To _dt.Rows.Count - 1

                '    Dim a As New ListLine
                '    a.Id = _dt.Rows(i).Item(0)
                '    a.Libele = _dt.Rows(i).Item("name")

                '    Dim rm = DblValue(_dt, "remise", i)

                '    a.Total = rm
                '    If rm > 0 Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                '    a.Index = i
                '    a.Dock = DockStyle.Top
                '    a.SendToBack()

                '    AddHandler a.EditSelectedItem, AddressOf EditSelectedItem
                '    AddHandler a.DeleteItem, AddressOf DeleteItem
                '    AddHandler a.GetFactureInfos, AddressOf GetInfos

                '    arr(i) = a
                'Next
                'pl.Controls.AddRange(arr)

                Dim dg As New DataGridView
                dg.DataSource = _dt

                StyleDatagrid(dg)

                pl.Controls.Add(dg)

                dg.Columns(1).Width = 50%
                dg.Columns(3).Width = 5%
                dg.Columns(4).Width = 20%
                dg.Columns(0).Width = 20%
                dg.Columns(2).Visible = False


                If Form1.useClientRemise_Way Then dg.Columns(4).Visible = False

                dg.Columns(0).HeaderText = "N°"
                dg.Columns(1).HeaderText = "Designation"
                dg.Columns(3).HeaderText = "PR"
                dg.Columns(4).HeaderText = "Remise"

                dg.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                dg.Columns(1).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
                AddHandler dg.CellMouseDoubleClick, AddressOf Dg_MouseDoubleClick
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillRowsClient()
        pl.Controls.Clear()
        Try
            If _dt.Rows.Count > 0 Then

                'lastIndex += numberOfItems

                'If _dt.Rows.Count - lastIndex < numberOfItems Then
                '    'n = _dtList.Rows.Count - lastIndex
                '    lastIndex = _dt.Rows.Count - 1
                'End If

                'Dim arr(numberOfItems) As ClientRow

                'Dim i As Integer = 0
                'For i = startIndex To _dt.Rows.Count - 1

                '    Dim a As New ClientRow
                '    a.Id = _dt.Rows(i).Item(0)
                '    a.Libele = _dt.Rows(i).Item("name")
                '    a.Responsable = StrValue(_dt, "responsable", i)
                '    a.Ville = StrValue(_dt, "ville", i)
                '    a.Tel = StrValue(_dt, "tel", i)
                '    a.isCompany = BoolValue(_dt, "isCompany", i)

                '    a.Index = i
                '    a.Dock = DockStyle.Top
                '    a.BringToFront()
                '    arr(i - startIndex) = a

                '    AddHandler a.EditSelectedItem, AddressOf EditSelectedClient
                '    AddHandler a.DeleteItem, AddressOf DeleteSelectedClient
                '    AddHandler a.GetFactureInfos, AddressOf GetClientInfos

                '    If i = lastIndex Then Exit For
                'Next
                'pl.Controls.AddRange(arr)
                'startIndex = i


                Dim dg As New DataGridView
                dg.DataSource = _dt

                StyleDatagrid(dg)

                pl.Controls.Add(dg)


                dg.Columns(2).Visible = False
                dg.Columns(3).Visible = False
                dg.Columns(4).Visible = False
                dg.Columns(5).Visible = False
                dg.Columns(6).Visible = False
                dg.Columns(10).Visible = False
                dg.Columns(12).Visible = False
                dg.Columns(13).Visible = False
                dg.Columns(14).Visible = False
                dg.Columns(15).Visible = False
                dg.Columns(16).Visible = False

                If Form1.usePortMonie = False Then dg.Columns(15).Visible = False

                dg.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                dg.Columns(1).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

                'dg.Columns(0).Width = 5%
                'dg.Columns(7).Width = 10%
                'dg.Columns(8).Width = 10%
                'dg.Columns(9).Width = 10%
                ''dg.Columns(2).Visible = False

                dg.Columns(0).HeaderText = "N°"
                dg.Columns(1).HeaderText = "Designation"
                dg.Columns(7).HeaderText = "Ville"
                dg.Columns(8).HeaderText = "ICE"
                dg.Columns(9).HeaderText = "Tél"
                dg.Columns(11).HeaderText = "Email"

                AddHandler dg.CellMouseDoubleClick, AddressOf Dg_MouseDoubleClick
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

        If TableName = "Client" Then
            GetClientInfos(id)
        ElseIf TableName = "Fournisseur" Then
            GetClientInfos(id)
        ElseIf TableName = "Article" Then
            GetArticleInfos(id)
        Else
            GetInfos(id)
        End If
    End Sub
    Private Sub Dg_Sorted(ByVal sender As Object, ByVal e As EventArgs)
        Dim dt As DataGridView = sender
        Dim qte As Double = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            qte = dt.Rows(i).Cells(7).Value

            If qte > Form1.myMinStock Then
                dt.Rows(i).Cells(7).Style.ForeColor = Color.Green
                dt.Rows(i).Cells(7).Style.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            ElseIf qte <= Form1.myMinStock And qte >= 0 Then
                dt.Rows(i).Cells(7).Style.ForeColor = Color.Orange
            Else
                dt.Rows(i).Cells(7).Style.ForeColor = Color.Red
            End If
        Next
    End Sub


    'raise Events
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent NewElement(Me)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim DG As DataGridView = pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub

        If TableName = "Article" Or TableName = "Category" Then
            RaiseEvent EditArticle(DG, Mode)
        Else
            RaiseEvent EditClient(Me, DG)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DG As DataGridView = pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub

        If TableName = "Article" Or TableName = "Category" Then
            RaiseEvent DeleteArticle(Me, DG)
        Else
            RaiseEvent DeleteClient(Me, DG)
        End If
    End Sub
    Private Sub txtSearchCtg_KeyDownOk() Handles txtSearchName.KeyDownOk, txtSearchCtg.KeyDownOk
        RaiseEvent GetElements(Me)
    End Sub

    Sub RemoveElement(ByVal ls As ListLine)
        pl.Controls.Remove(ls)
    End Sub
    Sub RemoveElement(ByVal ls As ClientRow)
        pl.Controls.Remove(ls)
    End Sub
    Sub RemoveElementSelectedRows()
        Dim DG As DataGridView = pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub

        DG.Rows.Remove(DG.SelectedRows(0))
    End Sub


    Private Sub btFournisseur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFournisseur.Click, btClient.Click
        Dim bt As Button = sender
        Mode = bt.Tag
        RaiseEvent ModeChanged(Me)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If currentPage = numberOfPage Then Exit Sub
        currentPage += 1

        If TableName = "Article" Then
            FillRows()
        Else
            FillRowsClient()
        End If
        btPage.Text = currentPage & "/" & numberOfPage
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If currentPage = 1 Then Exit Sub
        currentPage -= 1
        startIndex -= numberOfItems * 2
        If startIndex < 0 Then startIndex = 0
        lastIndex = startIndex

        If TableName = "Article" Then
            FillRows()
        Else
            FillRowsClient()
        End If
        btPage.Text = currentPage & "/" & numberOfPage
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        RaiseEvent GetElements(Me)
    End Sub
    'Article Row
    Private Sub EditSelectedItem(ByVal ls As ListLine)
        'RaiseEvent EditArticle(ls, Mode)
    End Sub
    Private Sub DeleteItem(ByVal ls As ListLine)
        'RaiseEvent DeleteArticle(Me, ls)
    End Sub
    Private Sub GetInfos(ByVal p1 As Integer)
        If Mode = "Category" Then RaiseEvent GetClientDetails(Me, p1)
    End Sub
    Private Sub GetArticleInfos(ByVal arid As Integer)
        Dim ad As New ArticleDetails
        ad.arid = arid
        If ad.ShowDialog = DialogResult.OK Then
            RaiseEvent GetArticleStock(Me)
        End If

    End Sub
    'Client row
    Private Sub EditSelectedClient(ByRef cr As ClientRow)
        'RaiseEvent EditClient(Me, cr)
    End Sub
    Private Sub GetClientInfos(ByVal _id As Integer)
        RaiseEvent GetClientDetails(Me, _id)
    End Sub
    Private Sub DeleteSelectedClient(ByRef cr As ClientRow)
        'RaiseEvent DeleteClient(Me, cr)
    End Sub


    Private Sub btCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCat.Click, btArticle.Click
        Dim bt As Button = sender
        Mode = bt.Tag
        RaiseEvent ModeChanged(Me)

        If TableName <> "Article" Then
            link.Visible = False
        Else
            link.Visible = True
        End If

    End Sub

    Private Sub btDepot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDepot.Click

        Dim clc As New ChooseDepot
        If clc.ShowDialog = DialogResult.OK Then
            dpid = clc.dpid
        End If
    End Sub

    
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles link.LinkClicked
        'If IsNothing(SelectedArticle) Then Exit Sub
        If TableName <> "Article" Then Exit Sub
        Dim DG As DataGridView = pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub

        Dim mv As New TransformeStock
        mv.arid = DG.SelectedRows(0).Cells(0).Value

        If mv.ShowDialog = Windows.Forms.DialogResult.OK Then
            RaiseEvent GetArticleStock(Me)
        End If

    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim DG As DataGridView = pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub


        PrintDoc.PrinterSettings.PrinterName = Form1.printer_Facture
        PrintDoc.Print()

    End Sub
    Dim m = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim DG As DataGridView = pl.Controls(0)
        If DG.SelectedRows.Count = 0 Then Exit Sub

        Try
            Using a As DrawClass = New DrawClass
                Dim dte As String = Format(Date.Now, "dd/MM/yyyy [hh:mm]")
                
                If TableName = "Client" Then
                    a.DrawListOfClient(e, DG, "Clients", m)
                ElseIf TableName = "Fournisseur" Then
                    a.DrawListOfClient(e, DG, "Fournisseurs", m)
                ElseIf TableName = "Article" Then
                    a.DrawListOfArticles(e, DG, m)
                Else
                    a.DrawListOfCats(e, DG, m)
                End If
            End Using
        Catch ex As Exception
            m = 0
        End Try

    End Sub

   

End Class
