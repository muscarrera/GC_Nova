Public Class Form1
    'Members

    'Difference system
    Public useClientRemise_Way As Boolean = False
    Public useBlLivrable As Boolean = False
    Public useButtonValidForStock As Boolean = False

    Public useAccessClient As Boolean = False
    Public useSoldByAvoir As Boolean = True
    Public usePortMonie As Boolean = True
    Public useValue_CUMP As Boolean = True

    Public isWorkinOnStock As Boolean = True
    Public printRef As Boolean
    Public isBaseOnTTC As Boolean = False
    Public isBaseOnOneTva As Boolean = False

    Public isBlGetSold As Boolean
    Public isFactureGetSold As Boolean

    Public normat_Print_Style As Boolean = True
    'Tables
    Public dt_Depot As DataTable

    'private members
    Private _Exercice As String = 19
    Private _Mode As String = "Accueil"
    Private _prefix As String

    'public members
    Public zeros As String
    Public Ex_fact As String

    Public admin As Boolean = False
    Public adminId As Integer = 0
    Public adminName As String = "User"

    Public isMaster As Boolean = True
    Public imgLarge As Integer = 100
    Public imgLonger As Integer = 200
    Public ImgPah As String = "C:\"
    Public SvgdPah As String = "C:\"
    Public BoundDbPath As String = "C:\"
    Public numberOfItems As Integer = 25
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
    Public hasEntete_BonTransport As Boolean
    Public printEnteteOnPdf As Boolean
    Public printOnPaper As Boolean
    Public MP_Localname As String

    Public proformat_Id As Integer
    Public printWithDate As Boolean = True
    Public printWithPrice As Boolean = True
    Public nbrPrOp_tr As Integer = 300
    Public ListToPrint As DataTable
    Public factureToPrint As Facture
    Public cellWidth As Integer
    Public tva As Double = 14
    Public clientFacture As Client

    Public Ech_Bon As String
    Public Ech_Facture As String

    Public myMinStock As Double = 2
   
    Public mainDepot As Integer = 3
    Public prf_Params As New Dictionary(Of String, String)

    Public Color_Default_Text As Color = Color.Blue
    Public Color_Selected_Text As Color = Color.Yellow
    Public Color_Default_Row As Color = Color.Bisque
    Public Color_Alternating_Row As Color = Color.WhiteSmoke
    Public Color_Selected_Row As Color = Color.Red



    Public Property prefix As String
        Get
            Return _prefix & Ex_fact & "/" & zeros
        End Get
        Set(ByVal value As String)
            _prefix = value
        End Set
    End Property
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

        'Dim gg As New gForm
        'gg.LoadXml()
        'If gg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
        '    End
        'End If

        'check Trial
        If TrialVersion_Master = False Then
            MsgBox("Vous devez Contacter l'administration pour plus d'infos", MsgBoxStyle.Information, "***TRIAL***")
            End
        End If

        'bt_Parck.Visible = False

        'check Users
        Dim pwdwin As New PWDPicker

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then

            If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then
                admin = True
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value
            Else
                btSetting.Enabled = False
                admin = False
                adminId = pwdwin.DGV1.SelectedRows(0).Cells(0).Value
                adminName = pwdwin.DGV1.SelectedRows(0).Cells(1).Value

                bt_Achat.Visible = False
                bt_Contact.Visible = False
            End If
        Else
            End
        End If
         
        'Exercice
        Exercice = Now.Date.ToString("yy")

        Me.Show()

        If getTrial() = False Then
            'MsgBox("Vous devez Contacter l'administration pour plus d'infos", MsgBoxStyle.Information, "***NBR***")
            'End
            Dim str = "une nouvelle mise à jour a été publiée récemment," & vbNewLine &
                    "veuillez appeler l'administrateur pour en bénéficier" & vbNewLine &
                    "sécurité ** vitesse ** optimisation"
            MsgBox(str, MsgBoxStyle.Information, "***NBR***")

        End If


        Using c As New HomeClass
            c.AddDataList()
        End Using
        HeaderColor(bt_Home.Text)


    End Sub

    'Add DataList to pl Body
    Public Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Vente.Click
        Using c As New FactureClass
            c.AddDataList(True)
        End Using
        HeaderColor(bt_Vente.Text)
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Achat.Click
        Using c As New FactureClass
            Dim bt As Button = sender
            c.AddDataList(False)
        End Using
        HeaderColor(bt_Achat.Text)
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Produit.Click
        Using c As New AricleClass
            c.AddDataList()
        End Using
        HeaderColor(bt_Produit.Text)
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Contact.Click
        Using c As New ClientClass
            c.AddDataList()
        End Using
        HeaderColor(bt_Contact.Text)
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Parck.Click
        Using c As New ParcClass
            c.AddDataList()
        End Using
        HeaderColor(bt_Parck.Text)
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
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Home.Click
        Using c As New HomeClass
            c.AddDataList()
        End Using
        HeaderColor(bt_Home.Text)
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
            If Facture_Title = "Liste des missions" Then
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
                a.DrawListOfDrivers(e, ds.DataSource, printEnteteOnPaper, "", True, True, m)
            ElseIf Facture_Title = "Listes Vehicule" Then
                a.DrawListOfVehicules(e, ds.DataSource, printEnteteOnPaper, "", True, True, m)
            ElseIf Facture_Title = "Listes Bon de Transport" Then
                a.DrawListOfTransport(e, ds.DataSource, printEnteteOnPaper, "", True, True, m)



            ElseIf Facture_Title = "Bon de Transport" Then
                a.DrawBonTransport(e, ds, "Bon_Transport", printEnteteOnPaper, "Bon de Transport", True, True, m)
            ElseIf Facture_Title = "Mission" Then
                a.DrawMission(e, ds, "Mission", printEnteteOnPaper, "Mission", True, True, m)
            End If
        End Using
    End Sub
    Private Sub PrintDocList_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocList.PrintPage
        Dim ds As DataList = plBody.Controls(0)
        Using a As DrawClass = New DrawClass

            If Facture_Title = "liste des impayés" Then
                a.PrintListofGoupeInpayed(e, ds, printEnteteOnPaper, m)
            ElseIf Facture_Title = "Details journals" Then
                a.PrintListDetailsJournalier(e, ds, printEnteteOnPaper, m)
            Else
                a.DrawListOfFacture(e, ds.DataList, printEnteteOnPaper, ds.FactureTable, True, True, m)
            End If

        End Using
    End Sub


    Private Sub btTrial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTrial.Click
        Dim trial As New TrialVersion
        If trial.ShowDialog = Windows.Forms.DialogResult.OK Then
            MsgBox("merci de votre compréhension , Code d'activation ' est correct")
            btTrial.Enabled = False
        End If
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Using c As New InventaireClass
            c.AddDataList()
        End Using
        HeaderColor(bt_Parck.Text)
    End Sub

    Private Sub PrintDocDesign_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocDesign.PrintPage
        Try
            Dim ds As DataList = plBody.Controls(0)

            Dim data As New DataTable
            ' Create four typed columns in the DataTable.
            data.Columns.Add("id", GetType(String))
            data.Columns.Add("date", GetType(String))
            data.Columns.Add("cid", GetType(String))
            data.Columns.Add("name", GetType(String))
            data.Columns.Add("total_ht", GetType(String))
            data.Columns.Add("total_tva", GetType(String))
            data.Columns.Add("total_ttc", GetType(String))
            data.Columns.Add("total_remise", GetType(String))
            data.Columns.Add("total_avance", GetType(String))
            data.Columns.Add("total_droitTimbre", GetType(String))
            data.Columns.Add("MPayement", GetType(String))
            data.Columns.Add("Editeur", GetType(String))

            data.Rows.Add(1, ds.Entete.FactureDate.ToString("dd/MM/yyyy"), ds.Entete.Client.cid, ds.Entete.ClientName,
                          String.Format("{0:0.00}", ds.TB.TotalHt), String.Format("{0:0.00}", ds.TB.TVA),
                          String.Format("{0:0.00}", ds.TB.TotalTTC), String.Format("{0:0.00}", ds.TB.Remise),
                          String.Format("{0:0.00}", ds.TB.avance), String.Format("{0:0.00}", ds.TB.DroitTimbre),
                          ds.ModePayement, adminName)


            Dim dt_Client As New DataTable
            ' Create four typed columns in the DataTable.
            dt_Client.Columns.Add("Clid", GetType(Integer))
            dt_Client.Columns.Add("name", GetType(String))
            dt_Client.Columns.Add("ref", GetType(String))
            dt_Client.Columns.Add("ville", GetType(String))
            dt_Client.Columns.Add("adresse", GetType(String))
            dt_Client.Columns.Add("ice", GetType(String))
            dt_Client.Columns.Add("tel", GetType(String))

            ' Add  rows with those columns filled in the DataTable.
            dt_Client.Rows.Add(ds.Entete.Client.cid, ds.Entete.ClientName, ds.Entete.Client.ref, ds.Entete.Client.ville,
                              ds.Entete.Client.adresse, ds.Entete.Client.ICE, ds.Entete.Client.tel)


            Using g As gDrawClass = New gDrawClass(MP_Localname)
                g.DrawBl(e, data, ds.DataSource, dt_Client, Facture_Title, False, m)
            End Using
        Catch ex As Exception

        End Try
    End Sub
End Class
