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
    Public BoundDbPath As String = "C:\"
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
    Public nbrPrOp_tr As Integer = 320
    Public ListToPrint As DataTable
    Public factureToPrint As Facture
    Public cellWidth As Integer
    Public tva As Double = 14

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

        'check Trial
        If TrialVersion_Master = False Then
            MsgBox("Vous devez Contacter l'administration pour plus d'infos")
            End
        End If

        'Trial
        If getTrial() = False Then End

        'check Users
        Dim pwdwin As New PWDPicker

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then

            If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then

            Else
                btSetting.Enabled = False

            End If
        Else
            End
        End If






        'Exercice
        Exercice = Now.Date.ToString("yy")


    End Sub

    'Add DataList to pl Body
    Public Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btVente.Click
        Using c As New FactureClass
            c.AddDataList(True)
        End Using
        HeaderColor(btVente.Text)
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
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Using c As New ParcClass
            c.AddDataList()
        End Using
        HeaderColor(Button9.Text)
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
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSetting.Click
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
                If IsNothing(factureToPrint) Then
                    a.DrawFacture(e, ds, Facture_Title, b, proformat_Id, printWithDate, printWithPrice, m)
                Else
                    a.DrawFactureFromList(e, factureToPrint, Facture_Title, b, proformat_Id, printWithDate, printWithPrice, m)

                End If

            End Using
        Catch ex As Exception
            m = 0
        End Try
    End Sub



    Private Sub PrintDocMission_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocMission.PrintPage
        Dim ds As ParcList = plBody.Controls(0)
        Using a As DrawClass = New DrawClass
            If Facture_Title = "Bons de Transport" Then
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    a.dt_Driver = c.SelectDataTable("Driver", {"*"})
                    a.dt_Vehicule = c.SelectDataTable("Vehicule", {"*"})
                End Using

                a.DrawListOfMission(e, ds.DataSource, printEnteteOnPaper, "", True, True, m)
            ElseIf Facture_Title = "Listes des Charges" Then
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    a.dt_Driver = c.SelectDataTable("Driver", {"*"})
                    a.dt_Vehicule = c.SelectDataTable("Vehicule", {"*"})
                End Using

                a.DrawListOfCharges(e, ds.DataSource, printEnteteOnPaper, "", True, True, m)
            ElseIf Facture_Title = "Chauffeurs" Then

            ElseIf Facture_Title = "Listes Vehicule" Then

            ElseIf Facture_Title = "Bon de Transport" Then
                a.DrawMission(e, ds, "Mission", printEnteteOnPaper, "Bon de Transport", True, True, m)
            End If
        End Using
    End Sub

    Private Sub PrintDocList_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocList.PrintPage
        Dim ds As DataList = plBody.Controls(0)
        Using a As DrawClass = New DrawClass

            a.DrawListOfFacture(e, ds.DataList, printEnteteOnPaper, ds.FactureTable, True, True, m)

        End Using
    End Sub

    Private Sub btTrial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTrial.Click
        Dim trial As New TrialVersion
        If trial.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("merci de votre compréhension , Code d'activation ' est correct")
            btTrial.Enabled = False
        End If
    End Sub
End Class
