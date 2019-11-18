Public Class ProductList

    Private startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Private _dt As DataTable
    Public TableName As String = "Article"

    Public Event NewElement(ByRef ds As ProductList)
    Public Event EditArticle(ByRef ls As ListLine)
    Public Event EditClient(ByRef ls As ClientRow)
    Public Event DeleteArticle(ByRef ds As ProductList, ByVal ls As ListLine)
    Public Event DeleteClient(ByRef ds As ProductList, ByRef ls As ClientRow)
    Public Event GetElements(ByRef ds As ProductList)
    Public Event ModeChanged(ByVal ds As ProductList)

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
            lastIndex = value.Rows.Count
            numberOfItems = Form1.numberOfItems
            numberOfPage = Math.Truncate(lastIndex / numberOfItems)
            If lastIndex Mod numberOfItems > 0 Then numberOfPage += 1
            currentPage = 1
            If TableName = "Article" Then
                FillRows()
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
                btClient.ForeColor = Color.Green
                btFournisseur.ForeColor = Color.DarkGray
            ElseIf value = "Fournisseur" Then
                plModeClient.Visible = True
                btClient.ForeColor = Color.DarkGray
                btFournisseur.ForeColor = Color.Green
            Else
                plModeClient.Visible = False
            End If
            TableName = value
        End Set
    End Property

    Private Sub FillRows()
        pl.Controls.Clear()

        If _dt.Rows.Count > 0 Then
            Dim n = numberOfItems
            If (_dt.Rows.Count - startIndex) < numberOfItems Then n = lastIndex - startIndex
            Dim arr(n - 1) As ListLine
            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ListLine
                a.Id = _dt.Rows(i).Item(0)
                a.Libele = _dt.Rows(i).Item("name")

                a.Total = _dt.Rows(i).Item("sprice")
                a.Avance = _dt.Rows(i).Item("bprice")
                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()

                AddHandler a.EditSelectedItem, AddressOf EditSelectedItem
                AddHandler a.DeleteItem, AddressOf DeleteItem
                AddHandler a.GetFactureInfos, AddressOf GetInfos

                arr(i - startIndex) = a
                If i = startIndex + n - 1 Then Exit For
            Next
            pl.Controls.AddRange(arr)
            startIndex = i
        End If
    End Sub
    Private Sub FillRowsClient()
        pl.Controls.Clear()

        If _dt.Rows.Count > 0 Then
            Dim n = numberOfItems
            If _dt.Rows.Count - lastIndex < numberOfItems Then n = _dt.Rows.Count - lastIndex
            Dim arr(_dt.Rows.Count - 1) As ClientRow
            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ClientRow
                a.Id = _dt.Rows(i).Item(0)
                a.Libele = _dt.Rows(i).Item("name")
                a.Responsable = _dt.Rows(i).Item("responsable")
                a.Ville = _dt.Rows(i).Item("ville")
                a.Tel = _dt.Rows(i).Item("tel")
                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()
                arr(i - startIndex) = a

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
        If TableName = "Article" Then
            RaiseEvent EditArticle(SelectedArticle)
        Else
            RaiseEvent EditClient(SelectedClient)
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
        RaiseEvent EditArticle(ls)
    End Sub
    Private Sub DeleteItem(ByVal ls As ListLine)
        RaiseEvent DeleteArticle(Me, ls)
    End Sub
    Private Sub GetInfos(ByVal p1 As Integer)

    End Sub
    'Client row




End Class
