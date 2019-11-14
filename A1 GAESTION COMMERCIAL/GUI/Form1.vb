Public Class Form1
    'Members
    Private _Exercice As String
    Private _Mode As String = "Accueil"


    Public admin As Boolean = True
    Public adminId As Integer = 0
    Public adminName As String = "User"
    Public isMaster As Boolean = True
    Public imgLarge As Integer = 100
    Public imgLonger As Integer = 200
    Public ImgPah As String = "C:"
    Public numberOfItems As Integer = 2


    'Props
    Public Property Exercice As String
        Get
            Return _Exercice
        End Get
        Set(ByVal value As String)
            _Exercice = value
            lbExr.text = value
        End Set
    End Property

    'Forms
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Exercice
        'Using x As New Exercice
        '    lbExr.Text = CStr(x.GetActiveExircice)
        'End Using


    End Sub

    'Add DataList to pl Body
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Using c As New FactureClass
            c.AddDataList(True)
        End Using
        HeaderColor(Button6.Text)
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Using c As New FactureClass
            Dim bt As Button = sender
            c.AddDataList(True)
        End Using
        HeaderColor(Button12.Text)
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Using c As New AricleClass
            c.AddDataList()
        End Using
        HeaderColor(Button10.Text)
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Using c As New ClientClass
            c.AddDataList()
        End Using
        HeaderColor(Button11.Text)
    End Sub
    Private Sub HeaderColor(ByVal value As String)
        For Each b As Control In plHeaderButton.Controls
            If b.Text = value Then
                b.BackColor = Color.SlateBlue
            Else
                b.BackColor = Color.DodgerBlue
            End If
        Next
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        HeaderColor(Button13.Text)
    End Sub
End Class
