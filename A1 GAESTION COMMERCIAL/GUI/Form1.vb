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
    Public numberOfItems As Integer = 25


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
    Public Property Mode As String
        Get
            Return _Mode
        End Get
        Set(ByVal value As String)
            _Mode = value

            For Each b As Button In plHeaderButtons.Controls
                If b.Text = value Then
                    b.BackColor = Color.SlateBlue
                Else
                    b.BackColor = Color.DodgerBlue
                End If
            Next


        End Set
    End Property


    'Forms
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Exercice
        'Using x As New Exercice
        '    lbExr.Text = CStr(x.GetActiveExircice)
        'End Using


    End Sub

    'Buttons
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button9.Click, Button8.Click, Button7.Click
        Using c As New FactureClass
            Dim bt As Button = sender
            c.AddDataList(bt.Tag)
        End Using
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Using c As New AricleClass
            plHead.Height = 83
            c.AddDataList()
        End Using
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        plHead.Height = 140
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Using c As New ClientClass
            plHead.Height = 83
            c.AddDataList()
        End Using
    End Sub
End Class
