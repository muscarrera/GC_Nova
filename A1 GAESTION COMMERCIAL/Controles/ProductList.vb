Public Class ProductList

    Private startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Private _dt As DataTable
    Public TableName As String = "Article"

    Public Event NewElement(ByRef ds As ProductList)
    Public Event EditArticle(ByRef ls As ListLine, ByVal m As String)
    Public Event EditClient(ByRef ds As ProductList, ByRef ls As ClientRow)
    Public Event DeleteArticle(ByRef ds As ProductList, ByVal ls As ListLine)
    Public Event DeleteClient(ByRef ds As ProductList, ByRef ls As ClientRow)
    Public Event GetElements(ByRef ds As ProductList)
    Public Event ModeChanged(ByVal ds As ProductList)
    Public Event GetClientDetails(ByVal ds As ProductList, ByVal _id As Integer)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtSearchCtg.PlaceHolder = "Groupe"
        txtSearchName.PlaceHolder = "N°/Designation/Réf"
    End Sub

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

            numberOfItems = Form1.numberOfItems
            numberOfPage = Math.Truncate(value.Rows.Count / numberOfItems)
            If lastIndex Mod numberOfItems > 0 Then numberOfPage += 1
            currentPage = 1
            If TableName = "Article" Then
                FillRows()

            ElseIf TableName = "Category" Then
                FillRowsCats()
            Else
                FillRowsClient()
            End If
            btPage.Text = "1/" & numberOfPage
        End Set
    End Property
    Public Property Mode As String
        Get
            Return TableName
        End Get
        Set(ByVal value As String)

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
            If _dt.Rows.Count - lastIndex < numberOfItems Then
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

                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()

                AddHandler a.EditSelectedItem, AddressOf EditSelectedItem
                AddHandler a.DeleteItem, AddressOf DeleteItem
                AddHandler a.GetFactureInfos, AddressOf GetInfos

                arr(i - startIndex) = a
                If i = lastIndex Then Exit For
            Next
            pl.Controls.AddRange(arr)
            startIndex = i
        End If
    End Sub
    Private Sub FillRowsCats()
        pl.Controls.Clear()

        If _dt.Rows.Count > 0 Then

            Dim arr(_dt.Rows.Count - 1) As ListLine
            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ListLine
                a.Id = _dt.Rows(i).Item(0)
                a.Libele = _dt.Rows(i).Item("name")

                Dim rm = DblValue(_dt, "remise", i)

                a.Total = rm
                If rm > 0 Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()

                AddHandler a.EditSelectedItem, AddressOf EditSelectedItem
                AddHandler a.DeleteItem, AddressOf DeleteItem
                AddHandler a.GetFactureInfos, AddressOf GetInfos

                arr(i - startIndex) = a
            Next
            pl.Controls.AddRange(arr)
            startIndex = i
        End If
    End Sub
    Private Sub FillRowsClient()
        pl.Controls.Clear()

        If _dt.Rows.Count > 0 Then

            lastIndex += numberOfItems

            If _dt.Rows.Count - lastIndex < numberOfItems Then
                'n = _dtList.Rows.Count - lastIndex
                lastIndex = _dt.Rows.Count - 1
            End If

            Dim arr(numberOfItems) As ClientRow

            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ClientRow
                a.Id = _dt.Rows(i).Item(0)
                a.Libele = _dt.Rows(i).Item("name")
                a.Responsable = StrValue(_dt, "responsable", i)
                a.Ville = StrValue(_dt, "ville", i)
                a.Tel = StrValue(_dt, "tel", i)
                a.isCompany = BoolValue(_dt, "isCompany", i)

                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()
                arr(i - startIndex) = a

                AddHandler a.EditSelectedItem, AddressOf EditSelectedClient
                AddHandler a.DeleteItem, AddressOf DeleteSelectedClient
                AddHandler a.GetFactureInfos, AddressOf GetClientInfos

                If i = lastIndex Then Exit For
            Next
            pl.Controls.AddRange(arr)
            startIndex = i
        End If
    End Sub
    'raise Events
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent NewElement(Me)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If TableName = "Article" Or TableName = "Category" Then
            RaiseEvent EditArticle(SelectedArticle, Mode)
        Else
            RaiseEvent EditClient(Me, SelectedClient)
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TableName = "Article" Then
            RaiseEvent DeleteArticle(Me, SelectedArticle)
        Else
            RaiseEvent DeleteClient(Me, SelectedClient)
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
        RaiseEvent EditArticle(ls, Mode)
    End Sub
    Private Sub DeleteItem(ByVal ls As ListLine)
        RaiseEvent DeleteArticle(Me, ls)
    End Sub
    Private Sub GetInfos(ByVal p1 As Integer)
        If Mode = "Category" Then RaiseEvent GetClientDetails(Me, p1)
    End Sub
    'Client row
    Private Sub EditSelectedClient(ByRef cr As ClientRow)
        RaiseEvent EditClient(Me, cr)
    End Sub
    Private Sub GetClientInfos(ByVal _id As Integer)
        RaiseEvent GetClientDetails(Me, _id)
    End Sub
    Private Sub DeleteSelectedClient(ByRef cr As ClientRow)
        RaiseEvent DeleteClient(Me, cr)
    End Sub


    Private Sub btCat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCat.Click, btArticle.Click
        Dim bt As Button = sender
        Mode = bt.Tag
        RaiseEvent ModeChanged(Me)
    End Sub
End Class
