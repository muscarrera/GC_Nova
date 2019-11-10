Public Class AddRow
    'Members
 
    'Eents
    Public Event AddNewArticle(ByVal art As Article)
    Public Event Cleared(ByVal sender As System.Object, ByVal e As System.EventArgs)

    Public article As New Article

    'Properties
    Private Property Arid As Integer
        Get
            Return article.arid
        End Get
        Set(ByVal value As Integer)

            article.arid = value
            If value = 0 Then
                plleft.BackgroundImage = My.Resources.WARNING_15
            Else
                plleft.BackgroundImage = Nothing
            End If
        End Set
    End Property
    Public Property AutoCompleteSourceRef() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtRef.AutoCompleteSource = value
        End Set
    End Property
    Public Property AutoCompleteSourceName() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtName.AutoCompleteSource = value
        End Set
    End Property

    Public ReadOnly Property price() As Double
        Get
            Dim t As Double = 0

            Try
                t = txtPrice.text
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
                t = txtQte.text
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
                t = txtRemise.text
            Catch ex As Exception
                t = 0
            End Try
            Return t
        End Get
    End Property
    '
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'subs and Functions
    Shadows Sub Focus()
        txtName.Focus()
    End Sub
    'init
    Private Sub InitForm()
        txtRef.text = ""
        txtName.text = ""
        txtQte.text = ""
        txtPrice.text = ""
        txtRemise.text = ""
        article = New Article(0, 0, "", "", 1, 0, 0, 0, 0, False, "")
        txtRef.Focus()
    End Sub
    'validation
    Private Function ValidationForm() As Boolean

        If txtName.text = "" Then Return False
        If txtPrice.text = "" Then Return False

        Return True
    End Function
    'fill
    Public Sub FillFields(ByVal art As Article)
        article = art
        txtRef.text = article.ref
        txtName.text = article.name
        txtPrice.text = String.Format("{0:n}", CDec(article.sprice))
        txtRemise.text = String.Format("{0:n}", CDec(article.remise))
        txtTotal.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Arid = art.arid
    End Sub

    'tub with home key
    Private Sub TxtBox3_KeyDownOk() Handles txtRef.KeyDownOk
        'auto Complete
        If txtRef.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("ref", txtRef.text)
                If Not IsNothing(a) Then FillFields(a)
                txtQte.Focus()
            End Using
        End If

        If txtName.text.Count = 0 Then txtName.Focus()
    End Sub
    Private Sub txtName_KeyDownOk() Handles txtName.KeyDownOk
        If txtName.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("name", txtName.text)
                If Not IsNothing(a) Then FillFields(a)
            End Using
        End If
        txtQte.Focus()
    End Sub
    Private Sub txtQte_KeyDownOk() Handles txtQte.KeyDownOk
        If txtQte.text = "" Then txtQte.text = 1
        article.qte = qte
        If txtPrice.text.Count > 0 And price > 0 Then
            txtRemise.Focus()
        Else
            txtPrice.Focus()
        End If

    End Sub
    Private Sub txtPrice_KeyDownOk() Handles txtPrice.KeyDownOk
        txtPrice.text = String.Format("{0:n}", CDec(article.sprice))
        txtRemise.Focus()
    End Sub
    Private Sub txtRemise_KeyDownOk() Handles txtRemise.KeyDownOk
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
    'txtChanged
    Private Sub txtPrice_TxtChanged() Handles txtPrice.TxtChanged
        Try
            article.sprice = price
            txtTotal.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Catch ex As Exception
            txtTotal.text = 0
        End Try
    End Sub
    Private Sub txtQte_TxtChanged() Handles txtQte.TxtChanged
        Try
            article.qte = qte
            txtTotal.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Catch ex As Exception
            txtTotal.text = 0
        End Try
    End Sub
    Private Sub txtRemise_TxtChanged() Handles txtRemise.TxtChanged
        Try
            article.remise = remise
            txtTotal.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Catch ex As Exception
            txtTotal.text = 0
        End Try
    End Sub
    Private Sub txtName_TxtChanged() Handles txtName.TxtChanged
        Arid = 0
        article.name = txtName.text
    End Sub
    Private Sub txtRef_TxtChanged() Handles txtRef.TxtChanged
        article.ref = txtRef.text
    End Sub
    'Leave
    Private Sub txtName_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.Leave
        If Arid <> 0 Then Exit Sub

        If txtName.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("name", txtName.text)
                If Not IsNothing(a) Then FillFields(a)
            End Using
        End If
    End Sub
End Class

