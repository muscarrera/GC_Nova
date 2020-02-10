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

    Private Sub getDetails()

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("cid", CID)
            params.Add("isPayed", False)

            Dim dte As Date = Now.Date
            Dim RestFact As Double = 0
            Dim RestBon As Double = 0

            Dim dt = a.SelectDataTable(factureTable, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                    DataGridView1.Rows.Add(DteValue(dt, "date", i), "Facture", String.Format("{0:n}", CDec(DblValue(dt, "total", i))))
                    RestFact += DblValue(dt, "total", i) - DblValue(dt, "avance", i)
                Next
            End If
            params.Clear()
            params.Add("cid = ", CID)
            params.Add("isPayed = ", False)
            params.Add("isAdmin <> ", "Facturé")

            dt = a.SelectDataTableSymbols(bonTable, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                    DataGridView1.Rows.Add(DteValue(dt, "date", i), "Bon", String.Format("{0:n}", CDec(DblValue(dt, "total", i))))
                    RestBon = DblValue(dt, "total", i) - DblValue(dt, "avance", i)
                Next
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
                        DataGridView1.Rows.Add(DteValue(dt, "date", i), "Reglement", "", String.Format("{0:n}", CDec(DblValue(dt, "montant", i))))
                    Next
                End If
            End If

            lbrestFact.Text = String.Format("{0:n}", CDec(RestFact)) & " Dhs"
            lbrestBon.Text = String.Format("{0:n}", CDec(RestBon)) & " Dhs"

            lbRest.Text = String.Format("{0:n}", CDec(RestBon + RestFact)) & " Dhs"


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