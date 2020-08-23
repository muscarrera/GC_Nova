Public Class CPanel
    Public Event UpdateQte()
    Public Event UpdatePrice()
    Public Event DeleteItems()
    Public Event UpdatePayment()
    Public Event UpdateRemise()
    Public Event UpdateClient()
    Public Event ValueChange()
    Public Event UpdateArticleRemise()
    Public Event UpdateArticledepot()
    Public Event UpdatearicleDetails()
    Public Event CommandeDate()


    Private _hasRemise As Boolean
    Public isActive As Boolean = False
    Private _EditMode As Boolean
    Private _bl As String
    Private _depot As Integer = 0



    'properties
    Public Property Value() As Double
        Get
            Dim qte As Double = 0
            If txt.Text = "" Then
                qte = 1
            Else
                qte = CDbl(txt.Text)
            End If
            Return qte
        End Get
        Set(ByVal value As Double)
            If value = 0 Then
                txt.Text = ""
            Else
                txt.Text = value
            End If
        End Set
    End Property
    Public Property EditMode() As Boolean
        Get
            Return _EditMode
        End Get
        Set(ByVal value As Boolean)
            _EditMode = value
            'If value Then
            '    btClient.Text = "Client"

            'Else
            '    btClient.Text = "Designation"
            'End If
        End Set
    End Property
    Public Property bl As String
        Get
            Return _bl
        End Get
        Set(ByVal value As String)
            If value = "" Then value = "---"
            _bl = value
            'If EditMode = False Then btClient.Text = value
        End Set
    End Property
    Public Property hasRemise() As Boolean
        Get
            Return _hasRemise
        End Get
        Set(ByVal value As Boolean)
            _hasRemise = value
            'If value Then
            '    BtDel.Text = ""
            '    BtDel.BackgroundImage = My.Resources.Remisepng
            '    BtRemise.Visible = False
            'Else
            '    BtDel.Text = "C"
            '    BtDel.BackgroundImage = Nothing
            '    BtRemise.Visible = True
            'End If
        End Set
    End Property
    Public Property Depot As Integer
        Get
            Return _depot
        End Get
        Set(ByVal value As Integer)
            _depot = value
        End Set
    End Property


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button4.Click, Button3.Click, Button2.Click, Button16.Click, Button13.Click, Button12.Click, Button11.Click, Button17.Click
        Dim bt As Button = sender
        Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If bt.Text = Button17.Text Then
            If Not txt.Text.Contains(decimalSeparator) Then txt.Text = txt.Text + decimalSeparator
            Exit Sub
        End If
        txt.Text = txt.Text + bt.Text
    End Sub
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        txt.Text = ""
    End Sub

    Public Sub ActiveQte(ByVal a As Boolean)
        Dim fnt As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim bkc As Color = Color.Teal
        Dim ftc As Color = Color.White
        isActive = True

        If a = False Then
            fnt = New Font("Microsoft Sans Serif", 9)
            bkc = Color.WhiteSmoke
            isActive = False
            ftc = Color.Black
        End If

        'BtPrix.BackColor = bkc
        'BtPrix.Font = fnt
        'BtPrix.ForeColor = ftc
        BtQte.BackColor = bkc
        BtQte.ForeColor = ftc
        BtQte.Font = fnt
        BtDpt.BackColor = bkc
        BtDpt.ForeColor = ftc
        BtDpt.Font = fnt
        BtDel.BackColor = bkc
        'btClient.BackColor = bkc
        'If EditMode = False Then btClient.Text = "Designation"
        '''''''''''''

    End Sub

    Private Sub BtQte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtQte.Click
        If isActive Then
            RaiseEvent UpdateQte()
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub BtPrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If isActive Then
            RaiseEvent UpdatePrice()
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDel.Click
        If isActive Then
            RaiseEvent DeleteItems()
            isActive = False
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent UpdatePayment()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRemise.Click
        RaiseEvent UpdateRemise()
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Value += 1
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtDpt.Click
        If isActive Then
            RaiseEvent UpdateArticledepot()
        Else
            RaiseEvent ValueChange()
        End If
    End Sub
    Private Sub Client_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClient.Click
        'If isActive Then
        '    RaiseEvent UpdatearicleDetails()
        'Else
        RaiseEvent UpdateClient()
        'End If

    End Sub
    Private Sub txt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt.TextChanged
        RaiseEvent ValueChange()
    End Sub

    Private Sub BtCmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtCmd.Click
        RaiseEvent CommandeDate()
    End Sub
End Class
