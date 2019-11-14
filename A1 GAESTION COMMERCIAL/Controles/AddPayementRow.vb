Public Class AddPayementRow

    Private _id As Integer

    Public dte As Date = Now.Date
    Public way As String = ""
    Public montant As Double = 0
    Public ech As Date = Now.Date
    Public ref As String = ""
    Public desig As String = ""
    Private _PM As New Payement
    Private _EditMode As Boolean
    Private _index As Integer


    Public Event AddNewArticle(ByVal pm As Payement)
    Public Event Cleared(ByVal addPayementRow As AddPayementRow)

    Public Property Payement As Payement
        Get
            Return _PM
        End Get
        Set(ByVal value As Payement)
            _PM = value

            initForm()
            If IsNothing(value) Then Exit Property

            If value.id > 0 Then plleft.BackgroundImage = My.Resources.WARNING_15

            txtWay.text = value.way
            txtMontant.text = value.montant
            txtEch.text = value.ech
            txtRef.text = value.ref
            txtDesig.text = value.desig

        End Set

    End Property
    Public Property EditMode() As Boolean
        Get
            Return _EditMode
        End Get
        Set(ByVal value As Boolean)
            _EditMode = value
            If value Then
                btAdd.BackgroundImage = My.Resources.iconfinder_advancedsettings_3283__1_
                btClear.BackgroundImage = My.Resources.DELETE_20
                txtWay.txtReadOnly = True
                txtMontant.txtReadOnly = True
                txtEch.txtReadOnly = True
                txtRef.txtReadOnly = True
                txtDesig.txtReadOnly = True
            Else
                btAdd.BackgroundImage = My.Resources.iconfinder_Gnome_Emblem_Default222
                btClear.BackgroundImage = My.Resources.CANCEL_22
                txtWay.txtReadOnly = False
                txtMontant.txtReadOnly = False
                txtEch.txtReadOnly = False
                txtRef.txtReadOnly = False
                txtDesig.txtReadOnly = False
            End If
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
            Me.BackgroundImage = Nothing
            If (value Mod 2) = 0 Then Me.BackgroundImage = My.Resources.gui_13
        End Set
    End Property


    Public Function AutoCompleteByName() As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)
        lst.Add("Cache")
        lst.Add("Cheque")
        lst.Add("Trait/Effet")
        lst.Add("Virement bancaire")

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        Dim str = getRegistryinfo("ModePayement", "")
        If str = "" Then Return Nothing
        Dim m As String() = str.Split("|")
        For i As Integer = 0 To m.Length - 1
            If m(i) = "" Then Continue For
            lst.Add(m(i))
        Next
        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        txtWay.AutoCompleteSource = AutoCompleteByName()

    End Sub


    Private Sub initForm()
        _PM.id = 0
        txtWay.text = ""
        txtMontant.text = ""
        txtEch.text = ""
        txtRef.text = ""
        txtDesig.text = ""
    End Sub
    Private Function ValidationForm() As Boolean

        If txtMontant.text = "" Then Return False
        If txtEch.text <> "" And Not IsDate(txtEch.text) Then Return False

        If txtWay.text = "" Then txtWay.text = "Cache"
        If txtEch.text = "" Then txtEch.text = Now.Date.ToString("dd-MM-yyyy")

        Try
            _PM.way = txtWay.text
            _PM.montant = CDbl(txtMontant.text)
            _PM.ech = CDate(txtEch.text)
            _PM.ref = txtRef.text
            _PM.desig = txtDesig.text
            _PM.dte = Now.Date
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub txtWay_KeyDownOk() Handles txtWay.KeyDownOk
        txtMontant.Focus()
    End Sub
    Private Sub txtMontant_KeyDownOk() Handles txtMontant.KeyDownOk
        If txtMontant.text = "" Then Exit Sub

        If txtWay.text = "Cache" Then
            txtDesig.Focus()
        Else
            txtEch.Focus()
        End If

    End Sub
    Private Sub txtEch_KeyDownOk() Handles txtEch.KeyDownOk
        txtRef.Focus()
    End Sub
    Private Sub txtRef_KeyDownOk() Handles txtRef.KeyDownOk
        If ValidationForm() Then
            RaiseEvent AddNewArticle(Payement)
            initForm()
        End If
    End Sub
    Private Sub txtDesig_KeyDownOk() Handles txtDesig.KeyDownOk
        If ValidationForm() Then
            RaiseEvent AddNewArticle(Payement)
            initForm()
        End If
    End Sub
    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If ValidationForm() Then
            RaiseEvent AddNewArticle(Payement)
            initForm()
        End If
    End Sub
    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        initForm()
        RaiseEvent Cleared(Me)
    End Sub
End Class
