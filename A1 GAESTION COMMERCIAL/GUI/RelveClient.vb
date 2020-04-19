Public Class RelveClient

    Dim _cid As Integer
    Private factureTable As String = "Sell_Facture"
    Private bonTable As String = "Bon_Livraison"
    Private PayementTable As String = "Client_Payement"

    Dim _cTable As String

    Public Property ClientTable As String
        Get
            Return _cTable
        End Get
        Set(ByVal value As String)
            _cTable = value

            If value = "Client" Then
                factureTable = "Sell_Facture"
                bonTable = "Bon_Livraison"
                PayementTable = "Client_Payement"
            Else
                factureTable = "Buy_Facture"
                bonTable = "Bon_Achat"
                PayementTable = "Company_Payement"
            End If
        End Set
    End Property
    Public Property Client As String
        Get
            Return lbClient.Text
        End Get
        Set(ByVal value As String)
            lbClient.Text = value
        End Set
    End Property
    Public Property CID As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value

            If value = 0 Then Exit Property
            getDetails()
        End Set
    End Property

    Private Property TotalReserve As Double
        Get
            Return CDbl(lbTreserve.Text)
        End Get
        Set(ByVal value As Double)
            lbTreserve.Text = value
        End Set
    End Property
    Private Property TotalCredit As Double
        Get
            Return 0
        End Get
        Set(ByVal value As Double)
            lbRest.Text = value.ToString("c")
        End Set
    End Property

    Private Sub getDetails()

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            'Avoir
                If Form1.useSoldByAvoir Then
                    params.Clear()

                    params.Add("cid", CID)
                    params.Add("isPayed", False)

                    Dim tb As String = "Sell_Avoir"
                    If ClientTable = "Fournisseur" Then tb = "Buy_Avoir"


                    Dim dtt As DataTable = a.SelectDataTable(tb, {"total"}, params)
                    Dim av As Double = 0
                    For i As Integer = 0 To dtt.Rows.Count - 1
                        av += dtt.Rows(i).Item("total")
                    Next

                lbAvoir.Text = av.ToString("c")
                TotalReserve += av

                Label2.Visible = True
                Panel7.Visible = True
                plReserve.Visible = True
                End If

                'get port Monie
                If Form1.usePortMonie Then
                    params.Clear()
                    params.Add("Clid", CID)
                    Dim dtee As DataTable = a.SelectDataTable(ClientTable, {"porte_Monie"}, params)

                    lb_PorteMonie.Text = DblValue(dtee, "porte_Monie", 0).ToString("c")
                TotalReserve += DblValue(dtee, "porte_Monie", 0)

                Label1.Visible = True
                Panel8.Visible = True
                plReserve.Visible = True
            End If

            Dim dte As Date = Now.Date
            Dim RestFact As Double = 0
            Dim RestBon As Double = 0
            Dim dt As DataTable

            If Form1.isFactureGetSold Then
                params.Clear()
                params.Add("cid", CID)
                params.Add("isPayed", False)

                dt = a.SelectDataTable(factureTable, {"*"}, params)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                        DataGridView1.Rows.Add(DteValue(dt, "date", i), "Facture",
                                               String.Format("{0:n}", CDec(DblValue(dt, "total", i))),
                                               "", IntValue(dt, "id", i))
                        RestFact += DblValue(dt, "total", i) - DblValue(dt, "avance", i)
                    Next
                End If
                lbrestFact.Visible = True
                Label1.Visible = True
            End If

            If Form1.isBlGetSold Then

                params.Clear()
                params.Add("cid = ", CID)
                params.Add("isPayed = ", False)
                If Form1.isFactureGetSold Then params.Add("isAdmin <> ", "Facturé")

                dt = a.SelectDataTableSymbols(bonTable, {"*"}, params)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                        DataGridView1.Rows.Add(DteValue(dt, "date", i), "Bon",
                                               String.Format("{0:n}", CDec(DblValue(dt, "total", i))),
                                              "", IntValue(dt, "id", i))
                        RestBon += DblValue(dt, "total", i) - DblValue(dt, "avance", i)
                    Next
                End If
                lbrestBon.Visible = True
                Label3.Visible = True
            End If

            params.Clear()

            dte = dte.AddDays(-1)
            params.Add("clid = ", CID)
            params.Add("date >", dte)

            dt = a.SelectDataTableSymbols(PayementTable, {"*"}, params)
            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                        Dim str = ""

                        If PayementTable = "Client_Payement" Then
                            If IntValue(dt, "Bon_Livraison", i) > 0 Then str &= "BN N° " & IntValue(dt, "Bon_Livraison", i)
                            If IntValue(dt, "Sell_Facture", i) > 0 Then str &= "FCT N° " & IntValue(dt, "Sell_Facture", i)
                        Else
                            If IntValue(dt, "Bon_Achat", i) > 0 Then str &= "BN N° " & IntValue(dt, "Bon_Achat", i)
                            If IntValue(dt, "Buy_Facture", i) > 0 Then str &= "FCT N° " & IntValue(dt, "Buy_Facture", i)
                        End If
                      
                        DataGridView1.Rows.Add(DteValue(dt, "date", i), "Reglement", "",
                                               String.Format("{0:n}", CDec(DblValue(dt, "montant", i))), str)
                    Next
                End If
            End If

            lbrestFact.Text = String.Format("{0:n}", CDec(RestFact)) & " Dhs"
            lbrestBon.Text = String.Format("{0:n}", CDec(RestBon)) & " Dhs"

            lbRestBonFactur.Text = String.Format("{0:n}", CDec(RestBon + RestFact)) & " Dhs"
            TotalCredit = RestBon + RestFact - TotalReserve

            params.Clear()
            params.Add("Clid", CID)
            Client = a.SelectByScalar(PayementTable, "name", params)

            'DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.Automatic
            DataGridView1.Sort(DataGridView1.Columns(0), System.ComponentModel.ListSortDirection.Ascending)

            For I As Integer = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(I).Cells(3).Value <> "" Then
                    DataGridView1.Rows(I).DefaultCellStyle.BackColor = Color.Honeydew
                End If
            Next
        End Using
    End Sub

    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click


        Try
            PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
            PrintDoc.Print()

        Catch ex As Exception
            Dim PrintDlg As New PrintDialog

            If PrintDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDoc.PrinterSettings.PrinterName = PrintDlg.PrinterSettings.PrinterName
                PrintDoc.Print()
            End If
        End Try


    End Sub
    Dim m As Integer = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
            Using a As DrawClass = New DrawClass
                Dim dte As String = Format(Date.Now, "dd-MM-yyyy [hh:mm]")

                a.DrawRelve(e, DataGridView1, Client, False, lbrestBon.Text, lbrestFact.Text, lbRest.Text, m)

            End Using
        Catch ex As Exception
            m = 0
        End Try
    End Sub
End Class