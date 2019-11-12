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
            If value = 0 And txtN.text <> "" Then
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
        txtRf.text = ""
        txtN.text = ""
        txtQ.text = ""
        txtPr.text = ""
        txtRs.text = ""
        article = New Article(0, 0, "", "", 1, 0, 0, 0, 0, False, "")
        txtRf.Focus()
    End Sub
    'validation
    Private Function ValidationForm() As Boolean

        If txtN.text = "" Then Return False
        If txtPr.text = "" Then Return False

        Return True
    End Function
    'fill
    Public Sub FillFields(ByVal art As Article)
        article = art
        txtRf.text = article.ref
        txtN.text = article.name
        txtPr.text = String.Format("{0:n}", CDec(article.sprice))
        txtRs.text = String.Format("{0:n}", CDec(article.remise))
        txtttc.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Arid = art.arid
    End Sub

    'tub with home key
    Private Sub TxtBox3_KeyDownOk() Handles txtRf.KeyDownOk
        'auto Complete
        If txtRf.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("ref", txtRf.text)
                If Not IsNothing(a) Then FillFields(a)
                txtQ.Focus()
            End Using
        End If

        If txtN.text.Count = 0 Then txtN.Focus()
    End Sub
    Private Sub txtName_KeyDownOk() Handles txtN.KeyDownOk
        If txtN.text.Length > 0 Then
            Using art As AricleClass = New AricleClass
                Dim a As Article = art.GetByfield("name", txtN.text)
                If Not IsNothing(a) Then FillFields(a)
            End Using
        End If
        txtQ.Focus()
    End Sub
    Private Sub txtQte_KeyDownOk() Handles txtQ.KeyDownOk
        If txtQ.text = "" Then txtQ.text = 1
        article.qte = qte
        If txtPr.text.Count > 0 And price > 0 Then
            txtRs.Focus()
        Else
            txtPr.Focus()
        End If

    End Sub
    Private Sub txtPrice_KeyDownOk() Handles txtPr.KeyDownOk
        txtPr.text = String.Format("{0:n}", CDec(article.sprice))
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
    'txtChanged
    Private Sub txtPrice_TxtChanged() Handles txtPr.TxtChanged
        Try
            article.sprice = price
            txtttc.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
    Private Sub txtQte_TxtChanged() Handles txtQ.TxtChanged
        Try
            article.qte = qte
            txtttc.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
    Private Sub txtRemise_TxtChanged() Handles txtRs.TxtChanged
        Try
            article.remise = remise
            txtttc.text = String.Format("{0:n}", CDec(article.TotalTTC))
        Catch ex As Exception
            txtttc.text = 0
        End Try
    End Sub
    Private Sub txtName_TxtChanged() Handles txtN.TxtChanged
        Arid = 0
        article.name = txtN.text
    End Sub
    Private Sub txtRef_TxtChanged() Handles txtRf.TxtChanged
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
End Class

