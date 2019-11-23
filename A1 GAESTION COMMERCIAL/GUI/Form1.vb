Public Class Form1
    'Members
    Private _Exercice As String = 19
    Private _Mode As String = "Accueil"


    Public admin As Boolean = True
    Public adminId As Integer = 0
    Public adminName As String = "User"
    Public isMaster As Boolean = True
    Public imgLarge As Integer = 100
    Public imgLonger As Integer = 200
    Public ImgPah As String = "C:\"
    Public SvgdPah As String = "C:\"
    Public numberOfItems As Integer = 2
    'font
    Public fontName_Normal As String
    Public fontName_Title As String
    Public fontName_Small As String
    Public fontSize_Normal As Integer
    Public fontSize_Title As Integer
    Public fontSize_Small As Integer

    Public printer_Devis As String
    Public printer_Bon As String
    Public printer_Commande_Client As String
    Public printer_Facture As String
    Public printer_Avoir As String
    Public printer_Pdf As String

    Dim m As Integer = 0
    Public Facture_Title As String
    Public imgEntetePath As String
    Public imgFootherPath As String
    Public printEnteteOnPaper As Boolean
    Public printEnteteOnPdf As Boolean
    Public printOnPaper As Boolean
    Public prefix As String
    Public proformat_Id As Integer
    Public printWithDate As Boolean = True
    Public printWithPrice As Boolean = True
    Public nbrPrOp_tr As Integer = 120

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

        'Regs info
        HandleRegistryinfo()
        'Trial
        If getTrial() = False Then End
       
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
            c.AddDataList(False)
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
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If plBody.Controls.Count > 0 Then
            If TypeOf plBody.Controls(0) Is Setting Then
                Exit Sub
            End If
        End If

        plBody.Controls.Clear()

        Dim ds As New Setting
        plBody.Controls.Add(ds)
    End Sub

    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Dim ds As DataList = plBody.Controls(0)
        Dim b As Boolean = printEnteteOnPaper
        If printOnPaper = False Then b = printEnteteOnPdf

        Try
            Using a As DrawClass = New DrawClass
                Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")
                a.DrawFacture(e, ds, Facture_Title, b, proformat_Id, printWithDate, printWithPrice, m)

            End Using
        Catch ex As Exception
            m = 0
        End Try
    End Sub


End Class
