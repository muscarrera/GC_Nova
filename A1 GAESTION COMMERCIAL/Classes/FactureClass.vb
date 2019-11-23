Public Class FactureClass
    Implements IDisposable

    Public Sub NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
        Try

            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.AutoCompleteSource = AutoCompleteByName(tb_C)
            NF.tb_C = tb_C
            NF.TxtDate.Text = Now.Date.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then
                Dim cn As String = NF.txtName.text
                Dim cid As String = 0

                Try
                    cn = NF.txtName.text.Split("|")(0)
                    cid = NF.txtName.text.Split("|")(1)
                Catch ex As Exception
                    cid = 0
                End Try

                NewFacture(tb_F, cid, cn, ds)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub NewFacture(ByVal tb_F As String, ByVal clid As String, ByVal cn As String, ByRef ds As DataList)
        Try
            Dim cid As String = clid
            Dim clientname As String = cn
            Dim fid As Integer = 0
            Dim dte As Date = Now.Date

            'If cid <> 0 And tp <> 0 Then
            '    If tp = "" Then tp = "1"
            '    If CheckForUnpaidFacture(cid, tp) = False Then Exit Sub
            'End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("cid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("remise", 0)
                params.Add("tva", 0)
                params.Add("date", Format(dte, "dd-MM-yyyy"))
                params.Add("writer", CStr(Form1.adminName))
                params.Add("isAdmin", "CREATION")
                params.Add("isPayed", False)
                params.Add("modePayement", "-")
                params.Add("droitTimbre", 0)
                params.Add("pj", 0)

                fid = c.InsertRecord(tb_F, params, True)
            End Using

            If fid > 0 Then
                'ds.Clear()
                ds.Mode = "DETAILS"
                ds.Id = fid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub NewFacture_Transforme(ByVal tb_F As String, ByVal tb_D As String, ByVal tb_P As String,
                                      ByVal dte As String, ByVal Op As String, ByRef ds As DataList, ByVal isDuplicate As Boolean)
        Dim data = ds.DataSource
        Dim fid As Integer = 0

        Dim avance = ds.TB.avance
        If isDuplicate Then avance = 0
        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("cid", ds.Entete.Client.cid)
                params.Add("name", ds.Entete.ClientName)
                params.Add("total", ds.TB.TotalTTC)
                params.Add("avance", avance)
                params.Add("remise", ds.TB.Remise)
                params.Add("tva", ds.TB.TVA)
                params.Add("date", dte)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("isAdmin", "CREATION")
                params.Add("isPayed", ds.isPayed)
                params.Add("modePayement", ds.ModePayement)
                'params.Add("bl", "-")
                'params.Add("droitTimbre", ds.TB.DroitTimbre)
                fid = c.InsertRecord(tb_F, params, True)
                params.Clear()

                If IsNothing(data) Then Exit Sub
                If data.Rows.Count > 0 Then

                    For i As Integer = 0 To data.Rows.Count - 1

                        params.Add("fctid", fid)
                        params.Add("name", data.Rows(i).Item("name"))
                        params.Add("bprice", data.Rows(i).Item("bprice"))
                        params.Add("price", data.Rows(i).Item("price"))
                        params.Add("remise", data.Rows(i).Item("remise"))
                        params.Add("qte", data.Rows(i).Item("qte"))
                        params.Add("tva", data.Rows(i).Item("tva"))
                        params.Add("arid", data.Rows(i).Item("arid"))
                        params.Add("depot", data.Rows(i).Item("depot"))
                        params.Add("ref", data.Rows(i).Item("ref"))
                        params.Add("cid", data.Rows(i).Item("cid"))

                        c.InsertRecord(tb_D, params)
                        params.Clear()
                    Next
                End If

                If avance > 0 Then
                    Dim where As New Dictionary(Of String, Object)
                    params.Add(tb_F, fid)
                    where.Add(ds.Operation, CInt(ds.Id))
                    c.UpdateRecord(tb_P, params, where)
                End If

            End Using

            If fid > 0 Then
                'ds.Clear()
                ds.Mode = "DETAILS"
                ds.Operation = Op
                ds.Id = fid
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetFactureDetails(ByVal id As Integer, ByRef ds As DataList)
        Try
            ds.Facture = New Facture(id, ds.FactureTable, ds.clientTable, ds.DetailsTable, ds.payementTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchById(ByVal id As String, ByRef ds As DataList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing

            If IsNumeric(id) Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("id Like ", "%" & id & "%")
                    dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                End Using
            Else
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("name Like ", "%" & id & "%")
                    dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                End Using
            End If



            If dt.Rows.Count = 1 Then
                ds.Clear()
                ds.Mode = "DETAILS"
                ds.Id = dt.Rows(0).Item(0)

            ElseIf dt.Rows.Count > 1 Then
                ds.Clear()
                ds.Mode = "LIST"

                ds.DataList = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByDate(ByRef ds As DataList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing

            Dim NF As New SearchArchive
            NF.txtName.AutoCompleteSource = AutoCompleteByName(ds.clientTable)

            If NF.ShowDialog = DialogResult.OK Then
                Dim dt1 As Date = Date.Parse(NF.dte2.Text).AddDays(1)
                Dim dt2 As Date = Date.Parse(NF.dte1.Text).AddDays(-1)
                If NF.txtName.text <> "" Then
                    If IsNumeric(NF.txtName.text) Then
                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            params.Add("fctid Like ", "%" & NF.txtName.text & "%")
                            dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                        End Using

                    ElseIf NF.txtName.text.Contains("|") Then
                        Dim str As String = NF.txtName.text.Trim
                        str = str.Split(CChar("|"))(1)
                        Dim clid As Integer = CInt(str)

                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            params.Add("cid = ", clid)
                            params.Add("[date] < ", dt1)
                            params.Add("[date] > ", dt2)
                            dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                        End Using
                    End If
                Else
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("[date] < ", dt1)
                        params.Add("[date] > ", dt2)

                        dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                    End Using
                End If

                If dt.Rows.Count > 0 Then
                    'Dim arr As New ListLine(dt.Rows.Count - 1)
                    ds.Clear()
                    ds.Mode = "LIST"

                    ds.DataList = dt
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub EditModePayement(ByRef ds As DataList)
        Try
            Dim mp As New ModePayement
            If mp.ShowDialog = DialogResult.OK Then
                ds.ModePayement = mp.mode
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddDataList(ByVal op As String)

        If Form1.plBody.Controls.Count > 0 Then
            If TypeOf Form1.plBody.Controls(0) Is DataList Then

                Dim dls As DataList = Form1.plBody.Controls(0)
                dls.isSell = CBool(op)

                Exit Sub
            End If
        End If

        Form1.plBody.Controls.Clear()

        Dim ds As New DataList
        ds.isSell = CBool(op)

        ds.Dock = DockStyle.Fill
        AddHandler ds.NewFacture, AddressOf NewFacture
        AddHandler ds.IdChanged, AddressOf GetFactureDetails
        AddHandler ds.NewRowAdded, AddressOf NewRowAdded
        AddHandler ds.SearchByDate, AddressOf SearchByDate
        AddHandler ds.SearchById, AddressOf SearchById
        AddHandler ds.EditModePayement, AddressOf EditModePayement

        AddHandler ds.SavePdf, AddressOf SavePdf
        AddHandler ds.PrintFacture, AddressOf PrintFacture
        AddHandler ds.PrintParamsFacture, AddressOf PrintParamsFacture
        AddHandler ds.SaveChanges, AddressOf SaveChanges
        AddHandler ds.TypeTransformer, AddressOf TypeTransformer
        AddHandler ds.CommandeDelivry, AddressOf CommandeDelivry
        AddHandler ds.Facturer, AddressOf Facturer
        AddHandler ds.PayFacture, AddressOf PayFacture
        AddHandler ds.DuplicateFacture, AddressOf DuplicateFacture
        AddHandler ds.DeleteFacture, AddressOf DeleteFacture
        AddHandler ds.AvoirFacture, AddressOf AvoirFacture
        AddHandler ds.GetFactureInfos, AddressOf GetFactureInfos
        AddHandler ds.DeleteItem, AddressOf DeleteItem
        AddHandler ds.EditSelectedFacture, AddressOf EditSelectedFacture
        AddHandler ds.ArticleItemChanged, AddressOf ArticleItemChanged
        AddHandler ds.ArticleItemDelete, AddressOf ArticleItemDelete
        AddHandler ds.NewDevisRef, AddressOf NewDevisRef
        AddHandler ds.NewBcRef, AddressOf NewBcRef
        AddHandler ds.NewBlRef, AddressOf NewBlRef
        AddHandler ds.ChangingClient, AddressOf ChangingClient
        AddHandler ds.GetClientDetails, AddressOf GetClientDetails

        'payement
        AddHandler ds.AddPayement, AddressOf AddPayement
        AddHandler ds.EditPayement, AddressOf EditPayement
        AddHandler ds.DeletePayement, AddressOf DeletePayement
        'Joindre fichiers
        AddHandler ds.AddFiles, AddressOf AddFiles

        Form1.plBody.Controls.Add(ds)
    End Sub
    'Entete events
    Private Sub SavePdf(ByVal ds As DataList)
        Form1.proformat_Id = 0
        Form1.printWithDate = True
        Form1.printWithPrice = True

        If ds.Operation = "Devis" Then
            Form1.Facture_Title = "Devis "
        ElseIf ds.Operation = "Sell_Facture" Then
            Form1.Facture_Title = "Facture "
            ''''//
        ElseIf ds.Operation = "Bon_Livraison" Then
            Form1.Facture_Title = "Bon de Livraison "
        ElseIf ds.Operation = "Bon_Commande" Then
            Form1.Facture_Title = "Bon de Commande "
        ElseIf ds.Operation = "Bon_Achat" Then
            Form1.Facture_Title = "Bon de Achat "
            ''''//
        ElseIf ds.Operation = "Commande_Client" Then
            Form1.Facture_Title = "Commande Client "
        ElseIf ds.Operation = "Sell_Avoir" Then
            Form1.Facture_Title = "Bon d'Avoir "
        End If
        Form1.printOnPaper = False

        Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
        Form1.PrintDoc.Print()

        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")

    End Sub
    Private Sub PrintFacture(ByVal ds As DataList)
        Form1.proformat_Id = 0
        Form1.printWithDate = True
        Form1.printWithPrice = True

        If ds.Operation = "Devis" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Devis
            Form1.Facture_Title = "Devis "
        ElseIf ds.Operation = "Sell_Facture" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Facture
            Form1.Facture_Title = "Facture "
            ''''//
        ElseIf ds.Operation = "Bon_Livraison" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
            Form1.Facture_Title = "Bon de Livraison "
        ElseIf ds.Operation = "Bon_Commande" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
            Form1.Facture_Title = "Bon de Commande "
        ElseIf ds.Operation = "Bon_Achat" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
            Form1.Facture_Title = "Bon de Achat "
            ''''//
        ElseIf ds.Operation = "Commande_Client" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Commande_Client
            Form1.Facture_Title = "Commande Client "
        ElseIf ds.Operation = "Sell_Avoir" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Avoir
            Form1.Facture_Title = "Bon d'Avoir "
        Else
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
        End If
        Form1.printOnPaper = True
        Form1.PrintDoc.Print()

        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")
    End Sub
    Private Sub PrintParamsFacture(ByVal ds As DataList)
        Dim pr As New ImpressionParams
        Form1.proformat_Id = 0
        If ds.Operation = "Bon_Achat" Or ds.Operation = "Bon_Commande" Then
            pr.btProformat.Visible = False
        End If

        If pr.ShowDialog = DialogResult.OK Then
            Form1.printWithDate = Not pr.cbDate.Checked
            Form1.printWithPrice = Not pr.cbPrix.Checked

            If ds.Operation = "Devis" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Devis
                Form1.Facture_Title = "Devis "
            ElseIf ds.Operation = "Sell_Facture" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Facture
                Form1.Facture_Title = "Facture "
                ''''//
            ElseIf ds.Operation = "Bon_Livraison" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Bon de Livraison "
            ElseIf ds.Operation = "Bon_Commande" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Bon de Commande "
            ElseIf ds.Operation = "Bon_Achat" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Bon de Achat "
                ''''//
            ElseIf ds.Operation = "Commande_Client" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Commande_Client
                Form1.Facture_Title = "Commande Client "
            ElseIf ds.Operation = "Sell_Avoir" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Avoir
                Form1.Facture_Title = "Bon d'Avoir "
            Else
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
            End If

            If pr.isProformat Then
                Form1.Facture_Title = "Facture Proformat"
                Form1.proformat_Id = getProformat(ds.Id, ds.FactureTable, ds)
            End If

            Form1.printOnPaper = True
            Form1.PrintDoc.Print()

            StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")
        End If
    End Sub
    Private Sub SaveChanges(ByVal id As Integer, ByRef ds As DataList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim isPayed As Boolean = ds.isPayed

            Dim tableName = ds.FactureTable
            Dim dte As Date = ds.Entete.FactureDate
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()
            params.Add("total", ds.TB.TotalTTC)
            params.Add("avance", ds.TB.avance)
            'params.Add("admin", admin)
            params.Add("isPayed", isPayed)
            params.Add("tva", ds.TB.TVA)
            params.Add("remise", ds.TB.Remise)

            Dim where As New Dictionary(Of String, Object)

            where.Add("id", id)

            c.UpdateRecord(tableName, params, where)
            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
        End Using
    End Sub
    Private Sub StatusChanged(ByVal status As String, ByVal id As Integer, ByRef Tb_F As String, ByVal opr As String)

        If status <> "CREATION" Then
            If opr = "Imprimé" Or opr = "Enregistrer" Then Exit Sub
        Else
            status = opr
        End If
    
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("isAdmin", status)

            Dim where As New Dictionary(Of String, Object)
            where.Add("id", id)

            c.UpdateRecord(Tb_F, params, where)

            params.Clear()
            where.Clear()
            params = Nothing
            where = Nothing
        End Using
    End Sub
    Private Sub TypeTransformer(ByVal id As Integer, ByRef ds As DataList)
        Dim td As New TransformerDevis
        td.Mode = ds.Operation
        td.Client = "[" & ds.Entete.Client.cid & "]" & vbNewLine & ds.Entete.ClientName
        td.Ref = ds.Operation & " " & ds.Id
        td.txtDate.text = Now.Date.ToString("dd-MM-yyyy")

        If td.ShowDialog = DialogResult.OK Then

            Dim tb_F = td.tb_F
            Dim tb_D = td.tb_D
            Dim tb_p = td.tb_P

            Dim status As String = "Valider"

            If tb_F = "Devis" Then
                If td.Operation = "Sell_Facture" Then status = "Facturé"
            ElseIf tb_F = "Commande_Client" Then
                status = "Traité"
            ElseIf tb_F = "Bon_Livraison" Then
                status = "Livré"
            ElseIf tb_F = "Bon_Commande" Then
                status = "Réception"
            ElseIf tb_F = "Bon_Achat" Then
                status = "Réception"
            End If



            StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, status)
            NewFacture_Transforme(tb_F, tb_D, tb_p, td.txtDate.text, td.Operation, ds, False)
        End If
    End Sub
    Private Sub CommandeDelivry(ByVal id As Integer, ByRef ds As DataList)
        Dim dte As String = Now.Date.ToString("dd-MM-yyyy")

        Dim tb_D = "Details_Bon_Livraison"
        Dim tb_F = "Bon_Livraison"
        Dim tb_P = "Client_Payement"
        Dim Operation = "Bon_Livraison"
        If ds.isSell = False Then
            tb_D = "Details_Bon_Achat"
            tb_F = "Bon_Achat"
            tb_P = "Company_Payement"
            Operation = "Bon_Achat"
        End If
        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Livré")
        NewFacture_Transforme(tb_F, tb_D, tb_P, dte, Operation, ds, False)

        For Each b As Button In ds.plHeaderSells.Controls
            b.BackgroundImage = My.Resources.gray_row
        Next
        ds.pbBar.Width = ds.Button8.Right
        ds.pbBar.BackColor = RandomColor()
        ds.Button8.BackgroundImage = My.Resources.gui_16
    End Sub
    Private Sub Facturer(ByVal id As Integer, ByRef ds As DataList)
        Dim dte As String = Now.Date.ToString("dd-MM-yyyy")

        Dim tb_D = "Details_Sell_Facture"
        Dim tb_F = "Sell_Facture"
        Dim tb_P = "Client_Payement"
        Dim Operation = "Sell_Facture"

        If ds.isSell = False Then
            tb_D = "Details_Buy_Facture"
            tb_F = "Buy_Facture"
            tb_P = "Company_Payement"
            Operation = "Buy_Facture"
        End If

        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Facturé")
        NewFacture_Transforme(tb_F, tb_D, tb_P, dte, Operation, ds, False)


        For Each b As Button In ds.plHeaderSells.Controls
            b.BackgroundImage = My.Resources.gray_row
        Next
        ds.pbBar.Width = ds.Button9.Right
        ds.pbBar.BackColor = RandomColor()
        ds.Button9.BackgroundImage = My.Resources.gui_16
    End Sub
    Private Sub PayFacture(ByVal id As Integer, ByRef dataList As DataList)
        'Throw New NotImplementedException
    End Sub
    Private Sub DuplicateFacture(ByVal id As Integer, ByRef ds As DataList)
        Dim dte As String = Now.Date.ToString("dd-MM-yyyy")

        Dim tb_D = ds.DetailsTable
        Dim tb_F = ds.FactureTable
        Dim tb_P = ds.payementTable
        Dim Operation = ds.Operation

        NewFacture_Transforme(tb_F, tb_D, tb_P, dte, Operation, ds, True)
    End Sub
    Private Sub DeleteFacture(ByVal id As Integer, ByRef ds As DataList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim isPayed As Boolean = False

            Dim tableName = DS.FactureTable
            Dim dte As Date = DS.Entete.FactureDate
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()
            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("admin", "ANNULER")
            params.Add("isPayed", isPayed)
            params.Add("tva", 0)
            params.Add("remise", 0)

            Dim where As New Dictionary(Of String, Object)

            where.Add("id", id)

            c.UpdateRecord(tableName, params, where)
            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
        End Using
    End Sub
    Private Sub AvoirFacture(ByVal p1 As Integer, ByVal ds As DataList)
        ds.TB.avance = 0
        NewFacture_Transforme("Sell_Avoir", "Details_Sell_Avoir", "Client_Payement", Now.Date, ds.Operation, ds, False)
        DeleteFacture(p1, ds)
    End Sub
    'ListLines Events
    Private Sub EditSelectedFacture(ByVal id As Integer)
        Dim ds As DataList = Form1.plBody.Controls(0)
        ds.Clear()
        ds.Mode = "DETAILS"
        ds.Id = id
    End Sub
    Private Sub DeleteItem(ByVal listLine As ListLine)

    End Sub
    Private Sub GetFactureInfos(ByVal p1 As Integer)

    End Sub
    'List Row events
    Public Sub NewRowAdded(ByVal id As Integer, ByVal tb_D As String, ByVal R As ListRow, ByRef d_Id As Integer)

        Try

            'Dim dpt As Integer = Form1.RPl.CP.Depot
            'If Form1.CbDepotOrigine.Checked Then dpt = R.depot

            Dim arid As Integer = 0

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", id)
                params.Add("name", R.ArticleName)
                params.Add("bprice", R.bprice)
                params.Add("price", R.sprice)
                params.Add("remise", R.remise)
                params.Add("qte", R.qte)
                params.Add("tva", R.TVA)
                params.Add("arid", R.arid)
                params.Add("depot", R.depot)
                params.Add("ref", R.ref)
                params.Add("cid", R.cid)

                d_Id = c.InsertRecord(tb_D, params, True)
            End Using
        Catch ex As Exception
        End Try

    End Sub
    Private Sub ArticleItemChanged(ByVal lr As ListRow, ByVal R As Article)
        Try
            Dim ds As DataList = Form1.plBody.Controls(0)
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)


                params.Add("name", R.name)
                params.Add("bprice", R.bprice)
                params.Add("price", R.sprice)
                params.Add("remise", R.remise)
                params.Add("qte", R.qte)
                params.Add("arid", R.arid)
                params.Add("depot", R.depot)
                params.Add("ref", R.ref)
                params.Add("cid", R.cid)

                Dim where As New Dictionary(Of String, Object)
                where.Add("id", lr.id)
                If c.UpdateRecord(ds.DetailsTable, params, where) Then
                    lr.article = R
                    lr.EditMode = False
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ArticleItemDelete(ByVal lr As ListRow)
        Try
            Dim ds As DataList = Form1.plBody.Controls(0)
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", lr.id)
                If c.DeleteRecords(ds.DetailsTable, where) Then
                    ds.Pl.Controls.Remove(lr)
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    'Payement
    Public Sub AddPayement(ByVal pm As Payement, ByVal ds As A1_GAESTION_COMMERCIAL.DataList, ByRef d_Id As Integer)

        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                params.Add("name", ds.Entete.ClientName)
                params.Add("clid", ds.Entete.Client.cid)
                params.Add("montant", pm.montant)
                params.Add("way", pm.way)
                params.Add("date", pm.dte)
                params.Add("ech", pm.ech)
                params.Add("ref", pm.ref)
                params.Add("desig", pm.desig)
                params.Add("writer", Form1.adminName)
                params.Add(ds.FactureTable, ds.Id)

                d_Id = c.InsertRecord(ds.payementTable, params, True)

                If d_Id > 0 Then

                    Dim where As New Dictionary(Of String, Object)

                    Dim avc As Double = ds.TB.avance
                    avc += pm.montant

                    where.Clear()
                    params.Clear()

                    where.Add("id", ds.Id)
                    params.Add("avance", avc)

                    If c.UpdateRecord(ds.FactureTable, params, where) Then
                        ds.TB.avance = avc
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try

    End Sub
    Private Sub EditPayement(ByVal pm As AddPayementRow, ByVal DS As DataList)
        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                params.Add("montant", pm.Payement.montant)
                params.Add("way", pm.Payement.way)
                params.Add("ech", pm.Payement.ech)
                params.Add("ref", pm.Payement.ref)
                params.Add("desig", pm.Payement.desig)
                params.Add("writer", Form1.adminName)

                Dim where As New Dictionary(Of String, Object)
                where.Add("Pid", pm.id)
                If c.UpdateRecord(DS.payementTable, params, where) Then

                    where.Clear()
                    params.Clear()
                    Dim avc As Double = DS.TB.avance
                    avc += pm.Payement.montant
                    avc -= pm._pm_edit.montant

                    params.Add("avance", avc)
                    where.Add("id", DS.Id)
                    If c.UpdateRecord(DS.FactureTable, params, where) Then
                        DS.TB.avance = avc
                        pm.EditMode = True
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DeletePayement(ByVal pm As AddPayementRow, ByVal dataList As DataList)

        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)

                where.Add("Pid", pm.id)

                params.Add(dataList.FactureTable, 0)

                If c.UpdateRecord(dataList.payementTable, params, where) Then

                    Dim avc As Double = dataList.TB.avance
                    avc -= pm.Payement.montant

                    where.Clear()
                    params.Clear()

                    where.Add("id", dataList.Id)
                    params.Add("avance", avc)

                    If c.UpdateRecord(dataList.FactureTable, params, where) Then
                        dataList.TB.avance = avc
                        dataList.plPmBody.Controls.Remove(pm)
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    'Total Bloc
    Private Sub AddFiles(ByVal ds As DataList)
        Dim add As New AddFiles
        add.id = ds.Id
        add.tb_F = ds.FactureTable
        If add.ShowDialog = DialogResult.Cancel Then
            Try
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)

                    params.Add("pj", add.pl.Controls.Count)

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("id", ds.Id)
                    If c.UpdateRecord(ds.FactureTable, params, where) Then
                        ds.pj = add.pl.Controls.Count
                    End If
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub
    'Facture Proformat
    Private Function getProformat(ByVal id As Integer, ByVal tb_F As String, ByVal ds As DataList) As Integer
        Dim P_id As Integer = 0
        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                params.Add("table", tb_F)
                params.Add("fctId", id)
                P_id = c.SelectByScalar("Sell_Fecture_Proformat", "id", params)

                If P_id <= 0 Then
                    params.Clear()

                    params.Add("table", tb_F)
                    params.Add("fctId", id)
                    params.Add("total", ds.TB.TotalTTC)

                    P_id = c.InsertRecord("Sell_Fecture_Proformat", params, True)
                End If

            End Using
        Catch ex As Exception
        End Try
        Return P_id

    End Function

    Private Sub NewDevisRef(ByVal ds As DataList)
        Dim rf As New ReferenceFacture
        rf.Title = "Devis"
        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim isPayed As Boolean = ds.isPayed

                Dim tableName = ds.FactureTable
                Dim dte As Date = ds.Entete.FactureDate
                Dim params As New Dictionary(Of String, Object)

                'Facture
                params.Clear()
                params.Add("devis", rf.Value)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", CInt(ds.Id))

                If c.UpdateRecord(ds.FactureTable, params, where) Then
                    ds.Entete.Devis = rf.Value
                End If
                params.Clear()
                where.Clear()

                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub
    Private Sub NewBcRef(ByVal ds As DataList)
        Dim rf As New ReferenceFacture
        rf.Title = "Bon de Commande"
        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim isPayed As Boolean = ds.isPayed

                Dim tableName = ds.FactureTable
                Dim dte As Date = ds.Entete.FactureDate
                Dim params As New Dictionary(Of String, Object)

                'Facture
                params.Clear()
                params.Add("Bon_Commande", rf.Value)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", CInt(ds.Id))

                If c.UpdateRecord(ds.FactureTable, params, where) Then
                    ds.Entete.Bc = rf.Value
                End If
                params.Clear()
                where.Clear()

                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub
    Private Sub NewBlRef(ByVal ds As DataList)
        Dim rf As New ReferenceFacture
        rf.Title = "Bon de Livraison"
        If rf.ShowDialog = DialogResult.OK Then

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim isPayed As Boolean = ds.isPayed

                Dim tableName = ds.FactureTable
                Dim dte As Date = ds.Entete.FactureDate
                Dim params As New Dictionary(Of String, Object)

                'Facture
                params.Clear()
                params.Add("Bon_Livraison", rf.Value)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", CInt(ds.Id))

                If c.UpdateRecord(ds.FactureTable, params, where) Then
                    ds.Entete.Bl = rf.Value
                End If
                params.Clear()
                where.Clear()

                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub
    Private Sub ChangingClient(ByVal ds As DataList)

        Dim CC As New ChooseClient
        CC.tb_C = ds.clientTable

        If CC.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim isPayed As Boolean = ds.isPayed

                Dim tableName = ds.FactureTable
                Dim dte As Date = ds.Entete.FactureDate
                Dim params As New Dictionary(Of String, Object)

                'Facture
                params.Clear()
                params.Add("cid", CC.cid)
                params.Add("name", CC.clientName)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", CInt(ds.Id))

                If c.UpdateRecord(ds.FactureTable, params, where) Then
                    Dim cl As New Client(CC.cid, ds.clientTable)
                    ds.Entete.Client = cl
                End If
                params.Clear()
                where.Clear()

                params = Nothing
                where = Nothing
            End Using
        End If

    End Sub
    Private Sub GetClientDetails(ByVal ds As DataList)
        Dim fl As New ClientDetails
        fl.Table = ds.clientTable
        fl.id = ds.Id
        If fl.ShowDialog = DialogResult.OK Then

        End If
    End Sub


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region


End Class
