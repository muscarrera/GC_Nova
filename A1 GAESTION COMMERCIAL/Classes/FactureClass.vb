Imports System.Drawing.Printing

Public Class FactureClass
    Implements IDisposable
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
        AddHandler ds.AddNewArticleToDb, AddressOf AddNewArticleToDb
        AddHandler ds.SearchByDate, AddressOf SearchByDate
        AddHandler ds.SearchById, AddressOf SearchById
        AddHandler ds.EditModePayement, AddressOf EditModePayement

        AddHandler ds.SavePdf, AddressOf SavePdf
        AddHandler ds.PrintFacture, AddressOf PrintFacture
        AddHandler ds.SaveListofFacturesasPdf, AddressOf SaveListofFacturesasPdf
        AddHandler ds.PrintListofFactures, AddressOf PrintListofFactures
        AddHandler ds.PrintParamsFacture, AddressOf PrintParamsFacture
        AddHandler ds.PrintListofGoupeInpayed, AddressOf PrintListofGoupeInpayed
        AddHandler ds.PrintListofDetailsJornalier, AddressOf PrintListofDetailsJornalier
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
        AddHandler ds.ChangeItemDepot, AddressOf ChangeItemDepot
        AddHandler ds.ArticleItemDelete, AddressOf ArticleItemDelete
        AddHandler ds.NewDevisRef, AddressOf NewDevisRef
        AddHandler ds.NewBcRef, AddressOf NewBcRef
        AddHandler ds.NewBlRef, AddressOf NewBlRef
        AddHandler ds.NewEnCompteRef, AddressOf NewEnCompteRef
        AddHandler ds.ChangingClient, AddressOf ChangingClient
        AddHandler ds.GetClientDetails, AddressOf GetClientDetails
        AddHandler ds.AddListofBl, AddressOf AddListofBl
        AddHandler ds.GetListofCommande, AddressOf GetListofCommande
        AddHandler ds.GetListofFacture, AddressOf GetListofFacture
        AddHandler ds.EdtitFactureDate, AddressOf EdtitFactureDate
        AddHandler ds.getStockForAddRow, AddressOf getStockForAddRow
        AddHandler ds.GetArticleStock, AddressOf GetArticleStock
        AddHandler ds.getClientRemise, AddressOf getClientRemise
        AddHandler ds.Valider, AddressOf valider

        'payement
        AddHandler ds.AddPayement, AddressOf AddPayement
        AddHandler ds.EditPayement, AddressOf EditPayement
        AddHandler ds.DeletePayement, AddressOf DeletePayement
        'Joindre fichiers
        AddHandler ds.AddFiles, AddressOf AddFiles
        'init depot
        ds.AddRow1.dpid = Form1.mainDepot
        ds.AddRow1.isSlave = Form1.admin
        'tva
        If Form1.isBaseOnOneTva = False Then ds.TB.plBlocTva.Width = 270


        Form1.plBody.Controls.Add(ds)
    End Sub
    Public Sub NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
        Try

            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.Focus()
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

                If NF.isBlocked Then
                    MsgBox("merci de vérifier avec l'administration pour l'autorisation de créer une nouvel enregistrement pour ce client",
                           MsgBoxStyle.Information, "Accès refusé")
                    Exit Sub
                End If


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
                params.Add("isPayed", False) ' ds.isPayed)
                params.Add("modePayement", ds.ModePayement)
                If isDuplicate = False Then params.Add(ds.FactureTable, ds.Id)
                If tb_F = "Sell_Avoir" And ds.FactureTable = "Sell_Facture" Then params.Add("Bon_Livraison", "Fct N° : " & ds.Id)
                'params.Add("droitTimbre", ds.TB.DroitTimbre)
                fid = c.InsertRecord(tb_F, params, True)
                params.Clear()

                If IsNothing(data) Then Exit Sub
                If data.Rows.Count > 0 Then

                    For i As Integer = 0 To data.Rows.Count - 1
                        params.Clear()
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
                        If tb_D = "Details_Sell_Facture" Then params.Add("bl", data.Rows(i).Item("bl"))

                        c.InsertRecord(tb_D, params)
                        params.Clear()

                        If Form1.isWorkinOnStock = False Then Continue For
                        If data.Rows(i).Item("depot") > 0 And data.Rows(i).Item("arid") > 0 Then
                            Dim q As Double = CDbl(data.Rows(i).Item("qte"))

                            If tb_D = "Details_Bon_Livraison" Or tb_D = "Details_Buy_Avoir" Then
                                q = q * -1
                            ElseIf tb_D = "Details_Bon_Achat" Or tb_D = "Details_Sell_Avoir" Then
                                q = q
                            Else
                                Continue For
                            End If

                            Dim oldStock = getStockById(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c)
                            If getStockId(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c) = 0 Then
                                If tb_D = "Details_Bon_Achat" And Form1.useValue_CUMP Then
                                    params.Clear()
                                    params.Add("arid", data.Rows(i).Item("arid"))

                                    Dim params2 As New Dictionary(Of String, Object)
                                    params2.Add("CUMP", data.Rows(i).Item("bprice"))

                                    c.UpdateRecord("Article", params2, params)
                                End If


                                AddNewStock(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"),
                                            data.Rows(i).Item("cid"), q, c)
                                params.Clear()
                            Else
                                If tb_F = "Bon_Achat" And Form1.useValue_CUMP Then
                                    params.Clear()
                                    params.Add("arid", data.Rows(i).Item("arid"))
                                    Dim cump As Double = c.SelectByScalar("Article", "CUMP", params)
                                    If IsDBNull(cump) Then cump = 0
                                    If Not IsNumeric(cump) Then cump = 0

                                    If cump = 0 Then
                                        cump = c.SelectByScalar("Article", "bprice", params)
                                    End If
                                    cump = ((cump * oldStock) + (data.Rows(i).Item("bprice") * q)) / (oldStock + q)
                                    Dim params2 As New Dictionary(Of String, Object)

                                    params2.Add("CUMP", cump)
                                    c.UpdateRecord("Article", params2, params)
                                    params.Clear()
                                End If


                                oldStock += q
                                updateStock(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), oldStock, c)
                            End If
                        End If
                    Next
                End If

                Dim where As New Dictionary(Of String, Object)
                If avance > 0 And isDuplicate = False Then
                    params.Add(tb_F, fid)
                    where.Add(ds.Operation, CInt(ds.Id))
                    c.UpdateRecord(tb_P, params, where)
                    params.Clear()
                    where.Clear()
                End If

                If ds.FactureTable = "Bon_Livraison" And tb_F = "Sell_Facture" Then
                    params.Add(tb_F, fid)
                    where.Add("id", CInt(ds.Id))
                    c.UpdateRecord(ds.FactureTable, params, where)
                End If
            End Using

            If fid > 0 Then
                'ds.Clear()
                ds.Mode = "DETAILS"
                ds.Operation = Op
                ds.Id = fid

                For Each b As Button In ds.plHeaderSells.Controls
                    b.BackgroundImage = My.Resources.gray_row
                Next
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

            If ds.Mode.ToUpper = "DETAILS" Then ds.Id = 0

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
                If ds.Mode.ToUpper <> "DETAILS" Then ds.Mode = "DETAILS"
                ds.Id = dt.Rows(0).Item(0)

            ElseIf dt.Rows.Count > 1 Then
                ds.Clear()
                If ds.Mode.ToUpper <> "LIST" Then ds.Mode = "LIST"

                ds.DataList = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByDate(ByRef ds As DataList)
        Try
            SearchByTag(ds)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByTag(ByRef ds As DataList)
        Try

            Dim NF As New SearchByTags
            NF.TableName = "Sell_Facture"
            'If ds.isSell = False Then NF.TableName = "Buy_Facture"

            Dim dt As DataTable
            If NF.ShowDialog = DialogResult.OK Then
                If NF.ReferenceArticle = True Then
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        Dim params As New Dictionary(Of String, Object)
                        Dim arid As String = ""
                        For Each kvp As KeyValuePair(Of String, Object) In NF.params
                            If kvp.Key = "ref Like " Then
                                arid = kvp.Value
                            Else
                                params.Add(ds.FactureTable & "." & kvp.Key, kvp.Value)
                            End If
                        Next

                        If params.Count > 0 Then
                            If arid = "" Then Exit Sub

                            Dim order As New Dictionary(Of String, String)
                            order.Add("id", "DESC")
                            dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params, order)
                        Else
                            Dim order As New Dictionary(Of String, String)
                            order.Add("id", "DESC")
                            params.Clear()
                            params.Add("ref = ", arid)
                            dt = a.SelectDataTableSymbols(ds.DetailsTable, {"*"}, params, order)
                            arid = ""
                        End If
                
                        ds.Clear()
                        If dt.Rows.Count > 0 Then
                            ds.Mode = "LIST"
                            FillByDetailsArticle(dt, arid, ds)

                        End If
                    End Using
                Else


                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        Dim order As New Dictionary(Of String, String)
                        order.Add("id", "DESC")
                        dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, NF.params, order)
                    End Using

                    ds.Clear()
                    If dt.Rows.Count > 0 Then
                        ds.Mode = "LIST"

                        If NF.EtatGénéral = True Then
                            FillByGroupingByClient(dt, ds)

                        ElseIf NF.EtatJournalier = True Then
                            FillByEtatjournalier(dt, ds)
                        Else
                            ds.DataList = dt
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub FillByGroupingByClient(ByVal Amounts As DataTable, ByVal ds As DataList)

        'Dim query = From d In dt_Vehicule.AsEnumerable()
        '                              Where d.Field(Of Integer)(0) = vid
        '                              Select d

        'Dim r As DataTable = query.CopyToDataTable()

        Dim query = From row In Amounts
                               Group row By dateGroup = New With {Key .cid = row.Field(Of Integer)("cid"),
                                                                  .name = row.Field(Of String)("name")} Into Group
                               Select New With {Key .Dates = dateGroup,
                                               .total = Group.Sum(Function(x) x.Field(Of Decimal)("total")),
                                               .avance = Group.Sum(Function(x) x.Field(Of Decimal)("avance")),
                                              .count = Group.Count(Function(x) x.Field(Of Integer)(0))}

        ds.Pl.Controls.Clear()
        Dim i As Integer = 0
        Dim arr(query.Count) As ListLine

        Dim ft = "Factures"
        If ds.FactureTable <> "Sell_Facture" Then ft = "Bons"

        ds.isEtatGeneral = True

        For Each item In query

            Dim a As New ListLine
            a.sizeAuto = True

            a.Id = item.Dates.cid
            a.Libele = item.Dates.name & " - (" & item.count & " " & ft & ")"
            a.Total = item.total
            a.Avance = item.avance
            a.remise = item.total - item.avance
            a.Index = i
            a.Dock = DockStyle.Top
            a.BringToFront()
            'a.SendToBack()

            AddHandler a.EditSelectedFacture, AddressOf GetInpayedListe
            AddHandler a.GetFactureInfos, AddressOf GetInpayedListe
            arr(i) = a

            i += 1
        Next

        ds.Pl.Controls.AddRange(arr)
    End Sub
    Public Sub GetInpayedListe(ByVal cid As String)
        Try
            Dim ds As DataList = Nothing
            If Form1.plBody.Controls.Count > 0 Then
                If TypeOf Form1.plBody.Controls(0) Is DataList Then
                    ds = Form1.plBody.Controls(0)
                Else
                    Exit Sub
                End If
            End If

            Dim dt As DataTable

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                Dim order As New Dictionary(Of String, String)
                order.Add("id", "DESC")

                params.Add("cid", cid)
                params.Add("isPayed", False)
                dt = a.SelectDataTable(ds.FactureTable, {"*"}, params, order)
            End Using

            ds.Clear()
            If dt.Rows.Count > 0 Then
                ds.Mode = "LIST"
                ds.DataList = dt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub PrintListofGoupeInpayed(ByVal ds As DataList, ByVal isPdf As Boolean)

        Form1.ListToPrint = Nothing
        Form1.Facture_Title = "liste des impayés"

        Form1.printOnPaper = True
        Form1.PrintDocList.PrinterSettings.PrinterName = Form1.printer_Facture

        If isPdf Then
            Form1.printOnPaper = False
            Form1.PrintDocList.PrinterSettings.PrinterName = Form1.printer_Pdf
        End If

        Form1.PrintDocList.Print()
    End Sub

    Private Sub FillByEtatjournalier(ByVal dt As DataTable, ByVal ds As DataList)

        Dim list As DataTable = Nothing

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            For t As Integer = 0 To dt.Rows.Count - 1
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", dt.Rows(t).Item(0))
                If t = 0 Then
                    list = a.SelectDataTable(ds.DetailsTable, {"*"}, params)
                Else
                    list.Merge(a.SelectDataTable(ds.DetailsTable, {"*"}, params))
                End If

            Next
        End Using



        Dim query = From row In list
                               Group row By dateGroup = New With {Key .arid = row.Field(Of Integer)("arid"),
                                                                  .name = row.Field(Of String)("name")} Into Group
                               Select New With {Key .Dates = dateGroup,
                                               .prix = Group.Sum(Function(x) x.Field(Of Decimal)("price") * x.Field(Of Decimal)("qte")),
                                               .qte = Group.Sum(Function(x) x.Field(Of Decimal)("qte"))}

        ds.Pl.Controls.Clear()
        Dim i As Integer = 0
        Dim arr(query.Count) As ListLine
        ds.isEtatJournalier = True

        Dim ft = "Factures"
        If ds.FactureTable <> "Sell_Facture" Then ft = "Bons"
        Dim sum As Double = 0

        For Each item In query

            Dim a As New ListLine
            a.sizeAuto = True

            a.Id = item.Dates.arid
            a.Libele = item.Dates.name
            a.Total = item.prix / item.qte
            a.Avance = item.prix
            a.lbref.Text = item.qte
            'a.remise = item.total - item.avance
            a.Index = i
            a.Dock = DockStyle.Top
            a.BringToFront()
            'a.SendToBack()

            'AddHandler a.EditSelectedFacture, AddressOf GetInpayedListe
            'AddHandler a.GetFactureInfos, AddressOf GetInpayedListe
            arr(i) = a

            sum += item.prix

            i += 1
        Next

        ds.lbLtotal.Text = String.Format("{0:n}", CDec(sum))

        ds.Pl.Controls.AddRange(arr)
    End Sub
    Private Sub FillByDetailsArticle(ByVal dt As DataTable, ByVal ref As String, ByVal ds As DataList)

        Dim list As DataTable = Nothing
        If dt.Rows.Count = 0 Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            If ref <> "" Then
                For t As Integer = 0 To dt.Rows.Count - 1
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("ref", ref)
                    params.Add("fctid", dt.Rows(t).Item(0))
                    If t = 0 Then
                        list = a.SelectDataTable(ds.DetailsTable, {"*"}, params)
                    Else
                        list.Merge(a.SelectDataTable(ds.DetailsTable, {"*"}, params))
                    End If
                Next

            Else
                list = dt
            End If

        End Using



        ds.Pl.Controls.Clear()
        Dim i As Integer = 0
        ds.isEtatJournalier = True
        Dim arr(list.Rows.Count) As ListLine
        Dim sum As Double = 0
        Dim qt As Double = 0

        For i = 0 To list.Rows.Count - 1
            Dim a As New ListLine
            a.sizeAuto = True

            a.Id = StrValue(list, "fctid", i)
            a.lbDate.Text = StrValue(list, "fctid", i)

            a.Libele = StrValue(list, "name", i)
            a.Total = StrValue(list, "qte", i)
            a.Avance = StrValue(list, "price", i)
            a.lbref.Text = StrValue(list, "ref", i)

            a.Index = i
            a.Dock = DockStyle.Top
            a.BringToFront()

            AddHandler a.EditSelectedFacture, AddressOf GetFactureDetailFromArticle
            AddHandler a.GetFactureInfos, AddressOf GetFactureDetailFromArticle

            arr(i) = a
            sum += (DblValue(list, "price", i) * DblValue(list, "qte", i))
            qt += DblValue(list, "qte", i)
            'i += 1
        Next

        ds.lbLtotal.Text = String.Format("{0:n}", CDec(sum))
        ds.lbLnbr.Text = qt
        ds.Pl.Controls.AddRange(arr)
    End Sub
    Private Sub GetFactureDetailFromArticle(ByVal id As Integer)
        Try
            Dim ds As DataList = Form1.plBody.Controls(0)
            ds.Clear()
            ds.Mode = "DETAILS"
            ds.Id = id
            'ds.Facture = New Facture(id, ds.FactureTable, ds.clientTable, ds.DetailsTable, ds.payementTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    '*Stock function and methodes
    Private Function getStockById(ByVal arid As Integer, ByVal dpid As Integer, ByVal c As DataAccess) As Double
        'If Form1.isWorkinOnStock = False Then Return Nothing

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)

        Dim qte = c.SelectByScalar("Details_Stock", "qte", where)

        Return qte
    End Function
    Private Function getStockId(ByVal arid As Integer, ByVal dpid As Integer, ByVal c As DataAccess) As Integer
        'If Form1.isWorkinOnStock = False Then Return 0

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)

        Dim id = c.SelectByScalar("Details_Stock", "id", where)
        If IsNothing(id) Then id = 0
        Return id
    End Function
    Private Function AddNewStock(ByVal arid As Integer, ByVal dpid As Integer,
                                     ByVal cid As Integer, ByVal qte As Double,
                                     ByVal c As DataAccess) As Integer
        'If Form1.isWorkinOnStock = False And Form1.useButtonValidForStock + False Then Return Nothing

        Dim where As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)
        where.Add("cid", cid)
        where.Add("qte", qte)

        Return c.InsertRecord("Details_Stock", where)

        Return qte
    End Function
    Private Function updateStock(ByVal arid As Integer, ByVal dpid As Integer,
                                    ByVal qte As Double, ByVal c As DataAccess) As Integer
        'If Form1.isWorkinOnStock = False Then Return Nothing

        Dim where As New Dictionary(Of String, Object)
        Dim params As New Dictionary(Of String, Object)
        where.Add("arid", arid)
        where.Add("dpid", dpid)

        params.Add("qte", qte)

        Return c.UpdateRecord("Details_Stock", params, where)
         
        Return qte
    End Function
    Private Sub GetArticleStock(ByRef pl As Panel, ByVal isS As Boolean)

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            'If Form1.isWorkinOnStock = False Then Exit Sub
            Dim where As New Dictionary(Of String, Object)

            For Each l As ListRow In pl.Controls
                'For i As Integer=0 to 
                where.Clear()
                where.Add("arid", l.arid)
                where.Add("dpid", l.depot)
                Dim qte = a.SelectByScalar("Details_Stock", "qte", where)

                If IsNothing(qte) Then Continue For

                If isS Then
                    l.Stock = qte + l.qte
                Else
                    l.Stock = qte - l.qte
                End If

            Next

        End Using

    End Sub

    Public Sub EditModePayement(ByRef ds As DataList)
        Try
            Dim mp As New ModePayement
            If mp.ShowDialog = DialogResult.OK Then
                Dim id = ds.Id

                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    params.Add("modePayement", mp.mode)

                    where.Add("id", id)

                    If c.UpdateRecord(ds.FactureTable, params, where) Then
                        ds.ModePayement = mp.mode
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EdtitFactureDate(ByVal FactureTable As String, ByVal id As String, ByVal ds As A1_GAESTION_COMMERCIAL.DataList)
        Try
            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.text = ds.Entete.ClientName
            NF.cName = ds.Entete.ClientName
            NF.cid = ds.Entete.Client.cid

            NF.tb_C = ds.clientTable

            NF.TxtExr.Enabled = False
            NF.txtName.Enabled = False

            NF.TxtDate.Text = ds.Entete.FactureDate.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then

                If IsDate(NF.TxtDate.Text) = False Then Exit Sub
                If CDate(NF.TxtDate.Text) = ds.Entete.FactureDate Then Exit Sub


                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    params.Add("date", CDate(NF.TxtDate.Text))

                    where.Add("id", id)

                    If c.UpdateRecord(ds.FactureTable, params, where) Then
                        ds.Entete.FactureDate = CDate(NF.TxtDate.Text)
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Entete events
    Private Sub SavePdf(ByVal ds As DataList)
        If Form1.normat_Print_Style = True Then
            SavePdf_Normal(ds)
            Exit Sub
        End If

        Dim pr As New gChooseDesign
        If pr.ShowDialog = DialogResult.OK Then
            Form1.MP_Localname = pr.localName

            Dim g As New gGlobClass
            g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & pr.localName)


            Try
                Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                ps.PaperName = g.p_Kind
                Form1.PrintDocDesign.DefaultPageSettings.PaperSize = ps
            Catch ex As Exception
            End Try

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
                Form1.Facture_Title = "Facture d'Avoir "
            End If
            Form1.printOnPaper = False

            'Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Pdf
            'Form1.PrintDoc.Print()

            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Pdf
            Form1.PrintDocDesign.Print()

            StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")
        End If
    End Sub
    Private Sub PrintFacture(ByVal ds As DataList)

        If Form1.normat_Print_Style = True Then
            PrintFacture_Normal(ds)
            Exit Sub
        End If


        Form1.MP_Localname = "Default.dat"
        If ds.Operation = "Sell_Facture" Then Form1.MP_Localname = "Facture-Default.dat"
        Try
            Dim g As New gGlobClass
            g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & Form1.MP_Localname)

            Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
            ps.PaperName = g.p_Kind
            Form1.PrintDocDesign.DefaultPageSettings.PaperSize = ps
            Form1.PrintDocDesign.DefaultPageSettings.Landscape = g.is_Landscape
        Catch ex As Exception

        End Try


        If ds.Operation = "Devis" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Devis
            Form1.Facture_Title = "Devis "
        ElseIf ds.Operation = "Sell_Facture" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Facture
            Form1.Facture_Title = "Facture "
            ''''//
        ElseIf ds.Operation = "Bon_Livraison" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
            Form1.Facture_Title = "Bon de Livraison "
        ElseIf ds.Operation = "Bon_Commande" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
            Form1.Facture_Title = "Bon de Commande "
        ElseIf ds.Operation = "Bon_Achat" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
            Form1.Facture_Title = "Bon de Achat "
            ''''//
        ElseIf ds.Operation = "Commande_Client" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Commande_Client
            Form1.Facture_Title = "Commande Client "
        ElseIf ds.Operation = "Sell_Avoir" Then
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Avoir
            Form1.Facture_Title = "Facture d'Avoir "
        Else
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
        End If
        Form1.printOnPaper = True
        Form1.PrintDocDesign.Print()

        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")

    End Sub
    Private Sub PrintParamsFacture(ByVal ds As DataList)


        If Form1.normat_Print_Style = True Then
            PrintParamsFacture_Normal(ds)
            Exit Sub
        End If


        Dim pr As New gChooseDesign
        If pr.ShowDialog = DialogResult.OK Then
            Form1.MP_Localname = pr.localName

            Dim g As New gGlobClass
            g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & pr.localName)


            Try
                Dim ps As New PaperSize(g.P_name, g.W_Page, g.h_Page)
                ps.PaperName = g.p_Kind
                Form1.PrintDocDesign.DefaultPageSettings.PaperSize = ps
            Catch ex As Exception
            End Try


            If ds.Operation = "Devis" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Devis
                Form1.Facture_Title = "Devis "
            ElseIf ds.Operation = "Sell_Facture" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Facture
                Form1.Facture_Title = "Facture "
            ElseIf ds.Operation = "Bon_Livraison" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Bon de Livraison "
            ElseIf ds.Operation = "Bon_Commande" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Bon de Commande "
            ElseIf ds.Operation = "Bon_Achat" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Bon de Achat "
            ElseIf ds.Operation = "Commande_Client" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Commande_Client
                Form1.Facture_Title = "Commande Client "
            ElseIf ds.Operation = "Sell_Avoir" Then
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Avoir
                Form1.Facture_Title = "Facture d'Avoir "
            Else
                Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_Bon
            End If


            Form1.printOnPaper = True
            Form1.PrintDocDesign.Print()

            StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")
        End If
    End Sub
    'old print methode
    Private Sub PrintFacture_Normal(ByVal ds As DataList)
        Form1.proformat_Id = 0
        Form1.printWithDate = True
        Form1.printWithPrice = True
        Form1.factureToPrint = Nothing

        If ds.Operation = "Devis" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Devis
            Form1.Facture_Title = "Devis "
        ElseIf ds.Operation = "Sell_Facture" Then
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Facture
            Form1.Facture_Title = "Facture "

            Dim ps As New PaperSize("A4", 850, 1100)
            ps.PaperName = PaperKind.A4
            Form1.PrintDoc.DefaultPageSettings.PaperSize = ps
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
            Form1.Facture_Title = "Facture d'Avoir "
        Else
            Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
        End If
        Form1.printOnPaper = True
        Form1.PrintDoc.Print()

        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")
    End Sub
    Private Sub PrintParamsFacture_Normal(ByVal ds As DataList)
        Dim pr As New ImpressionParams
        Form1.proformat_Id = 0
        If ds.Operation = "Bon_Achat" Or ds.Operation = "Bon_Commande" Then
            pr.btProformat.Visible = False
        End If

        If pr.ShowDialog = DialogResult.OK Then
            Form1.printWithDate = Not pr.cbDate.Checked
            Form1.printWithPrice = Not pr.cbPrix.Checked
            Form1.factureToPrint = Nothing

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
                Form1.Facture_Title = "Facture d'Avoir "
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
    Private Sub SavePdf_Normal(ByVal ds As DataList)
        Form1.proformat_Id = 0
        Form1.printWithDate = True
        Form1.printWithPrice = True
        Form1.factureToPrint = Nothing

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
            Form1.Facture_Title = "Facture d'Avoir "
        End If
        Form1.printOnPaper = False

        Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Pdf
        Form1.PrintDoc.Print()

        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "Imprimé")
    End Sub

    Private Sub SaveListofFacturesasPdf(ByVal ds As DataList)
        Form1.proformat_Id = 0
        Form1.printWithDate = True
        Form1.printWithPrice = True

        Form1.ListToPrint = Nothing
        Form1.ListToPrint = ds.DataList
        Form1.Facture_Title = "Facture"

        Form1.printOnPaper = False

        Form1.PrintDocList.PrinterSettings.PrinterName = Form1.printer_Pdf
        Form1.PrintDocList.Print()
    End Sub
    Private Sub PrintListofFactures(ByVal ds As DataList)
        Form1.proformat_Id = 0
        Form1.printWithDate = True
        Form1.printWithPrice = True

        If My.Computer.Keyboard.CtrlKeyDown Then
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
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
                Form1.Facture_Title = "Commande Client "
            ElseIf ds.Operation = "Sell_Avoir" Then
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Avoir
                Form1.Facture_Title = "Facture d'Avoir "
            Else
                Form1.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
            End If
            Form1.printOnPaper = True

            For i As Integer = 0 To ds.DataList.Rows.Count - 1
                Form1.factureToPrint = New Facture(ds.DataList.Rows(i).Item(0), ds.FactureTable, ds.clientTable,
                                                   ds.DetailsTable, ds.payementTable)
                Form1.PrintDoc.Print()
            Next

            Exit Sub
        End If

        Form1.ListToPrint = Nothing
        Form1.ListToPrint = ds.DataList
        Form1.Facture_Title = "Facture"

        Form1.printOnPaper = True

        Form1.PrintDocList.PrinterSettings.PrinterName = Form1.printer_Facture
        Form1.PrintDocList.Print()
    End Sub
    Private Sub SaveChanges(ByVal id As Integer, ByRef ds As DataList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim isPayed As Boolean = ds.isPayed
            Dim admin = ds.Entete.Statut

            If admin.ToUpper = "NON" Or admin.ToUpper = "ANNULER" Then
                If ds.Entete.Client.cid > 0 Then
                    admin = "Renommée"
                End If
            End If

            Dim tableName = ds.FactureTable
            Dim dte As Date = ds.Entete.FactureDate
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()
            params.Add("total", ds.TB.TotalTTC)
            params.Add("avance", ds.TB.avance)
            params.Add("isAdmin", admin)
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



            '''''''''''''''''''''''
            ''''Save Historique''''
            '''''''''''''''''''''''


        End Using
    End Sub
    Private Sub StatusChanged(ByVal status As String, ByVal id As Integer, ByRef Tb_F As String, ByVal opr As String)

        If status <> "CREATION" Then
            If opr = "Imprimé" Or opr = "Enregistrer" Then Exit Sub
        Else
            status = opr
        End If


        Dim params As New Dictionary(Of String, Object)
        params.Add("isAdmin", status)


        If opr.ToUpper.StartsWith("FACT") Then
            If Tb_F = "Bon_Livraison" Or Tb_F = "Bon_Achat" Then
                If Form1.isFactureGetSold Then
                    params.Add("isPayed", True)
                End If
            End If
        End If

        Dim where As New Dictionary(Of String, Object)
        where.Add("id", id)

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
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

        '''''''''''''''''''''''''''''''''''''''''
        If ds.isSell And Form1.useBlLivrable Then
            Bl_Livrable(tb_F, tb_D, tb_P, Operation, ds)
            Exit Sub
        Else

            StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "LIVRE")
            NewFacture_Transforme(tb_F, tb_D, tb_P, dte, Operation, ds, False)

        End If
        ''''''''''''''''''''''''''''''


        For Each b As Button In ds.plHeaderSells.Controls
            b.BackgroundImage = My.Resources.gray_row
        Next
        ds.pbBar.Width = ds.btbon.Right
        ds.pbBar.BackColor = RandomColor()
        ds.btbon.BackgroundImage = My.Resources.gui_16
    End Sub
    Public Sub Bl_Livrable(ByVal tb_F As String, ByVal tb_D As String, ByVal tb_P As String,
                                  ByVal Op As String, ByRef ds As DataList)
        Dim data = ds.DataSource
        Dim fid As Integer = 0
        Dim dte As String = Now.Date.ToString("dd-MM-yyyy")

        Dim avance = ds.TB.avance

        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                'params.Add(ds.FactureTable, ds.)
                params.Add(ds.FactureTable, ds.Id)
                Dim dt As DataTable = c.SelectDataTable(tb_F, {"id"}, params)
                Dim tt As Double = ds.TB.TotalTTC
                Dim isLivrable = False

                If dt.Rows.Count > 0 Then
                    tt = 0
                    avance = 0
                End If

                If IsNothing(data) Then Exit Sub


                params.Add("name", ds.Entete.ClientName)
                params.Add("total", tt)
                params.Add("avance", avance)
                params.Add("remise", ds.TB.Remise)
                params.Add("tva", ds.TB.TVA)
                params.Add("date", dte)
                params.Add("writer", CStr(Form1.adminName))
                params.Add("isAdmin", "CREATION")
                params.Add("isPayed", ds.isPayed)
                params.Add("modePayement", ds.ModePayement)
                params.Add(ds.FactureTable, ds.Id)

                fid = c.InsertRecord(tb_F, params, True)
                params.Clear()



                If data.Rows.Count > 0 Then
                    For i As Integer = 0 To data.Rows.Count - 1
                        Dim qq As Double = 0

                        For t As Integer = 0 To dt.Rows.Count - 1
                            Try
                                params.Clear()
                                params.Add("fctid", dt.Rows(t).Item(0))
                                params.Add("arid", data.Rows(i).Item("arid"))
                                qq += c.SelectByScalar(tb_D, "qte", params)
                            Catch ex As Exception
                            End Try
                        Next

                        qq = CDbl(data.Rows(i).Item("qte")) - qq
                        Dim p = CDbl(data.Rows(i).Item("price"))

                        If data.Rows(i).Item("depot") > 0 And data.Rows(i).Item("arid") > 0 Then
                            Dim oldStock = getStockById(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c)

                            If qq > oldStock Then
                                qq = oldStock
                                isLivrable = True
                            End If

                        End If


                        params.Clear()
                        params.Add("fctid", fid)
                        params.Add("name", data.Rows(i).Item("name"))
                        params.Add("bprice", data.Rows(i).Item("bprice"))
                        params.Add("price", p)
                        params.Add("remise", data.Rows(i).Item("remise"))
                        params.Add("qte", qq)
                        params.Add("tva", data.Rows(i).Item("tva"))
                        params.Add("arid", data.Rows(i).Item("arid"))
                        params.Add("depot", data.Rows(i).Item("depot"))
                        params.Add("ref", data.Rows(i).Item("ref"))
                        params.Add("cid", data.Rows(i).Item("cid"))

                        If qq > 0 Then c.InsertRecord(tb_D, params)
                        params.Clear()


                        If Form1.isWorkinOnStock = False And qq <= 0 Then Continue For
                        If data.Rows(i).Item("depot") > 0 And data.Rows(i).Item("arid") > 0 Then
                            Dim q As Double = qq * -1

                            Dim oldStock = getStockById(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c)
                            If getStockId(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c) = 0 Then
                                AddNewStock(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"),
                                            data.Rows(i).Item("cid"), q, c)
                            Else

                                oldStock += q
                                updateStock(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), oldStock, c)
                            End If
                        End If
                    Next
                End If

                Dim where As New Dictionary(Of String, Object)
                If avance > 0 Then
                    params.Add(tb_F, fid)
                    where.Add(ds.Operation, CInt(ds.Id))
                    c.UpdateRecord(tb_P, params, where)
                    params.Clear()
                    where.Clear()
                End If

                Dim status = "LIVRE"
                If isLivrable Then status = "TRAITE"
                params.Add("isAdmin", status)
                where.Clear()
                where.Add("id", ds.Id)
                c.UpdateRecord(ds.FactureTable, params, where)

            End Using

            If fid > 0 Then
                'ds.Clear()
                ds.Mode = "DETAILS"
                ds.Operation = Op
                ds.Id = fid

                For Each b As Button In ds.plHeaderSells.Controls
                    b.BackgroundImage = My.Resources.gray_row
                Next
            End If
        Catch ex As Exception

        End Try
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

        ds.pbBar.Width = ds.btfc.Right
        ds.pbBar.BackColor = RandomColor()
        ds.btfc.BackgroundImage = My.Resources.gui_16
    End Sub
    Private Sub PayFacture(ByVal id As Integer, ByRef ds As DataList)
        'Throw New NotImplementedException
        Dim PP As New PayementForm

        PP.ClientName = ds.Entete.ClientName
        PP.cid = ds.Entete.Client.cid
        PP.FactureTable = ds.FactureTable
        PP.payementTable = ds.payementTable
        PP.clientTable = ds.clientTable
        PP.Avance = ds.TB.avance
        PP.Total = ds.TB.TotalTTC

        PP.Id = ds.Id
        If PP.ShowDialog = DialogResult.OK Then

        End If
        ds.TB.avance = PP.Avance
        'fill rows
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

        If ds.DetailsTable = "Details_Bon_Livraison" Or
            ds.DetailsTable = "Details_Buy_Avoir" Or
            ds.DetailsTable = "Details_Bon_Achat" Or
            ds.DetailsTable = "Details_Sell_Avoir" Then

            DeleteBon(id, ds)
            Exit Sub
        End If


        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            Dim tableName = ds.FactureTable

            If ds.FactureTable = "Commande_Client" Or
                ds.FactureTable = "Devis" Or
                ds.FactureTable = "Bon_Commande" Then
                where.Add("id", id)
                If c.DeleteRecords(tableName, where) Then
                    where.Clear()
                    where.Add("fctid", id)
                    c.DeleteRecords(ds.DetailsTable, where)

                    params.Clear()
                    where.Clear()
                    where.Add(tableName & "=", id)
                    params.Add(tableName & " = ", 0)
                    c.UpdateRecordSymbols("Commande_Client", params, where)

                    params.Clear()
                    where.Clear()
                    where.Add(tableName & "=", id)
                    params.Add(tableName & " = ", 0)
                    c.UpdateRecordSymbols("Sell_Facture", params, where)

                    params.Clear()
                    where.Clear()
                    where.Add(tableName & "=", id)
                    params.Add(tableName & " = ", 0)
                    c.UpdateRecordSymbols("Bon_Livraison", params, where)

                    params.Clear()
                    where.Clear()
                    where.Add(tableName & "=", id)
                    params.Add(tableName & " = ", 0)
                    c.UpdateRecordSymbols("Bon_Achat", params, where)
                End If

                Exit Sub
            End If

            'Facture TTC
            Dim isPayed As Boolean = False
            Dim dte As Date = ds.Entete.FactureDate
         
            'Facture
            params.Clear()
            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("isAdmin", "ANNULER")
            params.Add("isPayed", isPayed)
            params.Add("tva", 0)
            params.Add("remise", 0)
            params.Add("cid", 0)

            If ds.isSell Then

                params.Add("devis", "")
                params.Add("Bon_Livraison", "")
                params.Add("Commande_Client", "")
                If tableName = "Bon_Livraison" Then params.Add("Sell_Facture", "")
            Else
                params.Add("devis", "")
                params.Add("Bon_Commande", "")
                params.Add("Bon_Achat", "")
                params.Add("Buy_Facture", "")
            End If

            where.Add("id", id)

            If c.UpdateRecord(tableName, params, where) Then
                where.Clear()
                where.Add("fctid", id)
                c.DeleteRecords(ds.DetailsTable, where)

                If tableName = "Sell_Facture" Then
                    where.Clear()
                    where.Add("id", id)

                    Dim str = c.SelectByScalar("Sell_Facture", "Bon_Livraison", where)
                    If str.StartsWith("B.T. : ") Then
                        Dim bt_id = str.Split(":")(1)

                        If IsNumeric(id) Then
                            params.Clear()
                            params.Add("isPayed", False)
                            params.Add("isFactured", False)

                            where.Clear()
                            where.Add("id", bt_id)

                            c.UpdateRecord("Bon_Transport", params, where)
                        End If

                    End If

                End If
            End If

            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
            If ds.Mode = "LIST" Then
                Dim dtt = ds.DataList
                For i As Integer = 0 To dtt.Rows.Count - 1
                    If dtt.Rows(i).Item(0) = id Then
                        dtt.Rows.Remove(dtt.Rows(i))
                        ds.DataList = dtt
                    End If
                Next
            Else
                If ds.FactureTable = "Commande_Client" Or ds.FactureTable = "Bon_Commande" Then
                    GetListofCommande(ds)
                Else
                    GetListofFacture(ds)
                End If
                ds.Mode = "LIST"
            End If

        End Using
    End Sub
    Private Sub DeleteBon(ByVal id As Integer, ByRef ds As DataList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim data As DataTable = ds.DataSource
            Dim dp As Integer = 0
            Dim qte As Double = 0
            Dim arid As Integer = 0

            If Form1.isWorkinOnStock Then
                 
                For i As Integer = 0 To data.Rows.Count - 1

                    dp = data.Rows(i).Item("depot")
                    qte = data.Rows(i).Item("qte")
                    arid = data.Rows(i).Item("arid")
                    Dim b As Boolean = False

                    If dp > 0 And arid > 0 Then

                        If ds.DetailsTable = "Details_Bon_Livraison" Or ds.DetailsTable = "Details_Buy_Avoir" Then
                            qte = qte
                        ElseIf ds.DetailsTable = "Details_Bon_Achat" Or ds.DetailsTable = "Details_Sell_Avoir" Then
                            qte = qte * -1
                        Else
                            Continue For
                        End If

                        If getStockId(arid, dp, c) > 0 Then
                            Dim oldStock = getStockById(arid, dp, c)
                            oldStock += qte
                            updateStock(arid, dp, oldStock, c)
                        End If
                    End If
                Next
            End If



            Dim tableName = ds.FactureTable
            Dim dte As Date = ds.Entete.FactureDate
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            where.Add("id", id)

            If c.DeleteRecords(tableName, where) Then
                where.Clear()
                where.Add("fctid", id)
                c.DeleteRecords(ds.DetailsTable, where)

                If tableName = "Sell_Avoir" Then
                    where.Clear()
                    where.Add("id", id)

                    Dim fctid = c.SelectByScalar(tableName, "Sell_Facture", where)
                    If IsNumeric(fctid) Then
                        params.Clear()
                        where.Clear()
                        params.Add("isAdmin", "RESTAURER")
                        params.Add("isPayed", False)
                        where.Add("id", fctid)
                        c.UpdateRecord("Sell_Facture", params, where)

                        where.Clear()
                        where.Add("id", fctid)

                        Dim str = c.SelectByScalar("Sell_Facture", "Bon_Livraison", where)
                        If str.StartsWith("B.T. : ") Then
                            Dim bt_id = str.Split(":")(1)

                            If IsNumeric(id) Then
                                params.Clear()
                                params.Add("isPayed", True)
                                params.Add("isFactured", True)

                                where.Clear()
                                where.Add("id", bt_id)

                                c.UpdateRecord("Bon_Transport", params, where)
                            End If

                        ElseIf IsNumeric(str) Then

                            params.Add("isFactured", True)

                            where.Clear()
                            where.Add("id", CInt(str))

                            c.UpdateRecord("Bon_Livraison", params, where)
                        End If
                    End If
                End If


            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
            End If

            GetListofFacture(ds)
            ds.Mode = "LIST"

        End Using
    End Sub
    



    Private Sub AvoirFacture(ByVal p1 As Integer, ByVal ds As DataList)
        ds.TB.avance = 0
        StatusChanged(ds.Entete.Statut, ds.Id, ds.FactureTable, "AVOIR")

        If ds.Entete.Bl.StartsWith("B.T. : ") Then

            Dim id = ds.Entete.Bl.Split(":")(1)

            If IsNumeric(id) Then
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("isPayed", False)
                    params.Add("isFactured", False)

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("id", id)

                    c.UpdateRecord("Bon_Transport", params, where)

                    params.Clear()
                    where.Clear()

                    params.Add("isPayed", True)
                    where.Add("id", id)

                    c.UpdateRecord(ds.FactureTable, params, where)

                    params = Nothing
                    where = Nothing
                End Using
            End If
        End If

        If ds.isSell = False Then
            NewFacture_Transforme("Buy_Avoir", "Details_Buy_Avoir", "Company_Payement", Now.Date, "Buy_Avoir", ds, False)
        Else
            NewFacture_Transforme("Sell_Avoir", "Details_Sell_Avoir", "Client_Payement", Now.Date, "Sell_Avoir", ds, False)

        End If


        'DeleteFacture(p1, ds)
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

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim oldStock = getStockById(R.arid, R.depot, c)

                'Some other options about new element
                If Form1.useBlLivrable And tb_D = "Details_Bon_Livraison" And R.qte > oldStock Then R.qte = oldStock

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

                If d_Id > 0 And R.depot > 0 And R.arid > 0 Then
                    Dim q As Double = 0

                    If tb_D = "Details_Bon_Livraison" Or tb_D = "Details_Buy_Avoir" Then
                        q = R.qte * -1
                    ElseIf tb_D = "Details_Bon_Achat" Or tb_D = "Details_Sell_Avoir" Then
                        q = R.qte
                    Else
                        Exit Sub
                    End If


                    If Form1.isWorkinOnStock = True Then
                        If getStockId(R.arid, R.depot, c) = 0 Then

                            Try
                                If tb_D = "Details_Bon_Achat" And Form1.useValue_CUMP Then
                                    params.Clear()
                                    params.Add("arid", R.arid)

                                    Dim params2 As New Dictionary(Of String, Object)
                                    params2.Add("CUMP", R.bprice)

                                    c.UpdateRecord("Article", params2, params)
                                End If
                            Catch ex As Exception
                            End Try

                            oldStock = q
                            AddNewStock(R.arid, R.depot, R.cid, q, c)
                        Else
                            If tb_D = "Details_Bon_Achat" And Form1.useValue_CUMP Then
                                params.Clear()
                                params.Add("arid", R.arid)
                                Dim cump As Double = 0

                                Try
                                    cump = c.SelectByScalar("Article", "CUMP", params)
                                    If IsDBNull(cump) Then cump = 0
                                    If Not IsNumeric(cump) Then cump = 0
                                Catch ex As Exception
                                    cump = 0
                                End Try

                                If cump = 0 Then
                                    cump = c.SelectByScalar("Article", "bprice", params)
                                End If

                                cump = ((cump * oldStock) + (R.sprice * q)) / (oldStock + q)
                                Dim params2 As New Dictionary(Of String, Object)

                                params2.Add("CUMP", cump)
                                c.UpdateRecord("Article", params2, params)
                            End If

                            oldStock += q
                            updateStock(R.arid, R.depot, oldStock, c)

                        End If

                        R.Stock = oldStock
                    End If
                End If
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
                params.Add("tva", R.TVA)

                Dim where As New Dictionary(Of String, Object)
                where.Add("id", lr.id)
                If c.UpdateRecord(ds.DetailsTable, params, where) Then
                    Dim oldQte As Double = lr.qte
                    Dim newQte As Double = R.qte

                    If R.depot > 0 And R.arid > 0 Then
                        Dim b As Boolean = False
                        If ds.DetailsTable = "Details_Bon_Livraison" Or ds.DetailsTable = "Details_Buy_Avoir" Then
                            oldQte = oldQte - newQte
                            b = True
                        ElseIf ds.DetailsTable = "Details_Bon_Achat" Or ds.DetailsTable = "Details_Sell_Avoir" Then
                            oldQte = newQte - oldQte
                            b = True
                        Else
                            b = False
                        End If


                        If b And Form1.isWorkinOnStock Then

                            'If b Then
                            Dim oldStock = getStockById(R.arid, R.depot, c)
                            If getStockId(R.arid, R.depot, c) = 0 Then
                                'AddNewStock(R.arid, R.arid, R.cid, R.qte, c)
                            Else
                                oldStock += oldQte
                                updateStock(R.arid, R.depot, oldStock, c)
                            End If
                        End If

                    End If

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

                    If lr.article.depot > 0 And lr.article.arid > 0 Then
                        Dim b As Boolean = False
                        Dim qte = lr.qte
                        If ds.DetailsTable = "Details_Bon_Livraison" Or ds.DetailsTable = "Details_Buy_Avoir" Then
                            b = True
                        ElseIf ds.DetailsTable = "Details_Bon_Achat" Or ds.DetailsTable = "Details_Sell_Avoir" Then
                            qte = qte * -1
                            b = True
                        Else
                            b = False
                        End If

                        If b And Form1.isWorkinOnStock Then

                            'If b Then
                            If getStockId(lr.article.arid, lr.article.depot, c) > 0 Then
                                Dim oldStock = getStockById(lr.article.arid, lr.article.depot, c)
                                oldStock += qte
                                updateStock(lr.article.arid, lr.article.depot, oldStock, c)
                            End If
                        End If
                    End If

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
                    avc -= pm._PM_Edit.montant

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
                        'dataList.plPmBody.Controls.Remove(pm)
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

            If CC.isBlocked Then
                MsgBox("merci de vérifier avec l'administration pour l'autorisation de créer une nouvel enregistrement pour ce client",
                       MsgBoxStyle.Information, "Accès refusé")
                Exit Sub
            End If

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
        If IsNothing(ds.Entete.Client) Then Exit Sub
        If ds.Entete.Client.cid = 0 Then Exit Sub


        Dim fl As New RelveClient
        fl.ClientTable = ds.clientTable
        fl.Client = ds.Entete.ClientName
        fl.CID = ds.Entete.Client.cid
        If fl.ShowDialog = DialogResult.OK Then

        End If


        'Dim fl As New ClientDetails
        'fl.Table = ds.clientTable
        'fl.id = ds.Entete.Client.cid
        'If fl.ShowDialog = DialogResult.OK Then

        'End If
    End Sub
    Private Sub AddListofBl(ByVal ds As DataList)
        Dim bls As New ChooseBL

        bls.table = ds.FactureTable
        bls.cid = ds.Entete.Client.cid
        bls.id = ds.Id
        If bls.ShowDialog = DialogResult.OK Then

            Dim data As DataTable
            Dim avance = ds.TB.avance

            Try
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    If bls.tb_D = "Bon_Transport" Then
                        params.Add("Bon_Livraison", "B.T. : " & bls.List)
                    Else
                        params.Add(bls.tb_D, bls.List)
                    End If

                    params.Add("total", CDbl(bls.LbSum.Text))
                    params.Add("avance", CDbl(bls.Lbavc.Text))

                    where.Add("id", CInt(ds.Id))
                    c.UpdateRecord(ds.FactureTable, params, where)
                    params.Clear()
                    where.Clear()

                    For Each a As ListLine In bls.plBody.Controls
                        Dim bonId As Integer = CInt(a.Id)

                        If bls.oldList.ContainsKey(bonId) Then
                            bls.oldList(bonId) = 0
                            Continue For
                        End If

                        If bls.tb_D = "Bon_Transport" Then
                            params.Add("isPayed", True)
                            params.Add("isFactured", True)
                        Else
                            params.Add(bls.tb_F, CInt(ds.Id))
                            params.Add("isAdmin", "Facturé")
                        End If

                        where.Add("id", bonId)
                        c.UpdateRecord(bls.tb_D, params, where)
                        params.Clear()
                        where.Clear()

                        'payment
                        params.Add(bls.tb_F, CInt(ds.Id))
                        where.Add(bls.tb_D, bonId)
                        c.UpdateRecord(bls.tb_P, params, where)
                        params.Clear()
                        where.Clear()


                        If bls.tb_D = "Bon_Transport" Then
                            where.Add("Bon_Transport", bonId)
                        Else
                            where.Add("fctid", bonId)
                        End If

                        data = c.SelectDataTable(bls.tb_D_D, {"*"}, where)
                        where.Clear()

                        If data.Rows.Count > 0 Then
                            For i As Integer = 0 To data.Rows.Count - 1
                                If bls.tb_D = "Bon_Transport" Then
                                    params.Add("fctid", CInt(ds.Id))
                                    params.Add("name", StrValue(data, "name", i))
                                    params.Add("bprice", DblValue(data, "value", i))
                                    params.Add("price", DblValue(data, "value", i))
                                    params.Add("remise", 0)
                                    params.Add("qte", DblValue(data, "qte", i))
                                    params.Add("tva", Form1.tva)
                                    params.Add("arid", -111)
                                    params.Add("depot", 0)
                                    params.Add("ref", StrValue(data, "ref", i))
                                    params.Add("cid", 0)

                                Else
                                    params.Add("fctid", CInt(ds.Id))
                                    params.Add("name", StrValue(data, "name", i))
                                    params.Add("bprice", DblValue(data, "bprice", i)) 'data.Rows(i).Item("bprice"))
                                    params.Add("price", DblValue(data, "price", i)) 'data.Rows(i).Item("price"))
                                    params.Add("remise", DblValue(data, "remise", i)) ' data.Rows(i).Item(""))
                                    params.Add("qte", DblValue(data, "qte", i)) 'data.Rows(i).Item(""))
                                    params.Add("tva", DblValue(data, "tva", i)) 'data.Rows(i).Item(""))
                                    params.Add("arid", IntValue(data, "arid", i)) ' data.Rows(i).Item(""))
                                    params.Add("depot", IntValue(data, "depot", i)) 'data.Rows(i).Item(""))
                                    params.Add("ref", StrValue(data, "ref", i)) 'data.Rows(i).Item(""))
                                    params.Add("cid", IntValue(data, "cid", i)) ' data.Rows(i).Item("cid"))
                                    If bls.tb_D = "Bon_Livraison" Then params.Add("bl", bonId) 'IntValue(data, "fctid", i)) 'data.Rows(i).Item(0))
                                End If
                                c.InsertRecord(ds.DetailsTable, params)
                                params.Clear()
                            Next
                        End If
                    Next

                    If bls.tb_D <> "Bon_Transport" Then
                        For Each kv As KeyValuePair(Of Integer, Integer) In bls.oldList

                            params.Clear()
                            where.Clear()

                            If kv.Value = 0 Then Continue For

                            params.Add(bls.tb_F, 0)
                            params.Add("isAdmin", "Traite")

                            where.Add("id", kv.Key)
                            c.UpdateRecord(bls.tb_D, params, where)
                            params.Clear()
                            where.Clear()

                            params.Add(bls.tb_F, 0)
                            where.Add(bls.tb_D, kv.Key)
                            c.UpdateRecord(bls.tb_P, params, where)
                            params.Clear()
                            where.Clear()

                            where.Add("bl", kv.Key)
                            If bls.tb_D = "Bon_Livraison" Then c.DeleteRecords(ds.DetailsTable, where)
                        Next
                    End If
                End Using


                ds.Id = ds.Id

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GetListofCommande(ByVal ds As DataList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add("isAdmin <> ", "Livré")
                params.Add(" isAdmin  <> ", "Facturé")
                dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
            End Using


            If dt.Rows.Count > 0 Then
                'Dim arr As New ListLine(dt.Rows.Count - 1)
                ds.Clear()
                ds.Mode = "LIST"

                ds.DataList = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetListofFacture(ByVal ds As DataList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim order As New Dictionary(Of String, String)
                order.Add("id", "DESC")
                dt = a.SelectDataTableWithSyntaxe(ds.FactureTable, "TOP " & Form1.numberOfItems & " ", {"*"}, , order)
            End Using


            If dt.Rows.Count > 0 Then
                'Dim arr As New ListLine(dt.Rows.Count - 1)
                ds.Clear()
                ds.Mode = "LIST"

                ds.DataList = dt
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub NewEnCompteRef(ByVal ds As DataList)

        Dim rf As New ReferenceFacture
        rf.Title = "En Compte de :"

        rf.TxtBox1.AutoCompleteSource = AutoCompleteByName("Client")

        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim tableName = ds.FactureTable
                Dim params As New Dictionary(Of String, Object)
                Dim cid As Integer = 0
                Try
                    If rf.Value.Contains("|") And IsNumeric(rf.Value.Split("|")(1)) Then
                        cid = rf.Value.Split("|")(1)
                    End If
                Catch ex As Exception
                    cid = 0
                End Try


                params.Clear()
                params.Add("compteId", cid)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", CInt(ds.Id))

                If c.UpdateRecord(tableName, params, where) Then
                    ds.Entete.CompteId = cid
                End If

                params = Nothing
                where = Nothing
            End Using
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

    Private Sub getStockForAddRow(ByVal arid As Integer, ByVal dpid As Integer, ByRef stk As Double)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            stk = getStockById(arid, dpid, a)
        End Using
    End Sub

    Private Sub PrintListofDetailsJornalier(ByVal dataList As DataList, ByVal isPdf As Boolean)
        Form1.ListToPrint = Nothing
        Form1.Facture_Title = "Details journals"

        Form1.printOnPaper = True
        Form1.PrintDocList.PrinterSettings.PrinterName = Form1.printer_Facture

        If isPdf Then
            Form1.printOnPaper = False
            Form1.PrintDocList.PrinterSettings.PrinterName = Form1.printer_Pdf
        End If

        Form1.PrintDocList.Print()
    End Sub

    Private Sub ChangeItemDepot(ByVal R As ListRow, ByVal dpid As Object)
        Try
            Dim ds As DataList = Form1.plBody.Controls(0)
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)


                Dim b As Boolean = False
                Dim oldQte As Double = R.qte
                Dim newQte As Double = R.qte


                If ds.DetailsTable = "Details_Bon_Livraison" Or ds.DetailsTable = "Details_Buy_Avoir" Then
                    oldQte = R.qte
                    newQte = R.qte * -1
                    b = True
                ElseIf ds.DetailsTable = "Details_Bon_Achat" Or ds.DetailsTable = "Details_Sell_Avoir" Then
                    oldQte = R.qte * -1
                    newQte = R.qte
                    b = True
                Else
                    b = False
                End If

                If b And R.article.arid > 0 And Form1.isWorkinOnStock Then

                    If R.depot > 0 Then
                        Dim oldStock = getStockById(R.arid, R.depot, c)
                        If getStockId(R.arid, R.depot, c) = 0 Then
                            'AddNewStock(R.arid, R.arid, R.cid, oldQte, c)
                        Else
                            oldStock += oldQte
                            updateStock(R.arid, R.depot, oldStock, c)
                        End If
                    End If

                    If dpid > 0 Then
                        Dim oldStock = getStockById(R.arid, dpid, c)
                        If getStockId(R.arid, dpid, c) = 0 Then
                            'AddNewStock(R.arid, R.arid, R.cid, oldQte, c)
                        Else
                            oldStock += newQte
                            updateStock(R.arid, dpid, oldStock, c)
                        End If
                    End If

                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub getClientRemise(ByRef ds As DataList, ByVal clientId As Integer, ByVal isS As Boolean)
        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("Clid", clientId)
                ds.dt_Client_Remise = c.SelectDataTable("Client_Remise", {"*"}, params)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AddNewArticleToDb(ByRef art As Article)
        Try
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim params As New Dictionary(Of String, Object)
                params.Add("ref", art.ref)
                params.Add("name", art.name)
                params.Add("desc", "")
                params.Add("cid", 0)

                params.Add("bprice", art.sprice)
                params.Add("sprice", art.sprice)
                params.Add("tva", art.TVA)
                params.Add("prixPromo", art.sprice)

                params.Add("remiseMax", 0)
                params.Add("remiseGr", 0)
                params.Add("remiseRev", 0)
                params.Add("remiseCF", 0)

                params.Add("stockType", "CUMP")
                params.Add("alertStock", Form1.myMinStock)
                params.Add("isPromo", False)
                params.Add("isStocked", True)
                params.Add("periode", "")
                params.Add("img", "")

                If Form1.useValue_CUMP Then params.Add("CUMP", art.sprice)

                art.arid = a.InsertRecord("Article", params, True)
            End Using
        Catch ex As Exception
            art.arid = 0
        End Try
    End Sub

    Private Sub valider(ByVal id As Integer, ByVal isV As Boolean, ByRef ds As DataList)
        Try

            If isV = True Then
                Dim pwdwin As New PWDPicker
                If pwdwin.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
                If pwdwin.DGV1.SelectedRows(0).Cells(2).Value <> "admin" Then Exit Sub
            End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)
                params.Add("isValid", Not isV)
                where.Add("id", id)

                c.UpdateRecord(ds.FactureTable, params, where)
                params.Clear()
                where.Clear()

                ds.DisibleEditing("v", Not isV)

                If ds.FactureTable.Contains("Facture") Then Exit Sub

                Dim data = ds.DataSource
                Dim tb_D = ds.DetailsTable
                Dim tb_F = ds.FactureTable

                For i As Integer = 0 To data.Rows.Count - 1

                    If data.Rows(i).Item("depot") > 0 And data.Rows(i).Item("arid") > 0 Then
                        Dim q As Double = CDbl(data.Rows(i).Item("qte"))

                        If tb_D = "Details_Bon_Livraison" Or tb_D = "Details_Buy_Avoir" Then
                            q = q * -1
                            If isV = True Then q = q
                        ElseIf tb_D = "Details_Bon_Achat" Or tb_D = "Details_Sell_Avoir" Then
                            q = q
                            If isV = True Then q = q * -1
                        Else
                            Continue For
                        End If

                        Dim oldStock = getStockById(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c)
                        If getStockId(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), c) = 0 Then
                            If tb_D = "Details_Bon_Achat" And Form1.useValue_CUMP Then
                                params.Clear()
                                params.Add("arid", data.Rows(i).Item("arid"))

                                Dim params2 As New Dictionary(Of String, Object)
                                params2.Add("CUMP", data.Rows(i).Item("price"))

                                c.UpdateRecord("Article", params2, params)
                            End If
                            AddNewStock(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"),
                                        data.Rows(i).Item("cid"), q, c)
                        Else
                            If tb_F = "Bon_Achat" And Form1.useValue_CUMP And q > 0 Then
                                params.Clear()
                                params.Add("arid", data.Rows(i).Item("arid"))
                                Dim cump As Double = c.SelectByScalar("Article", "CUMP", params)
                                If IsDBNull(cump) Then cump = 0
                                If Not IsNumeric(cump) Then cump = 0

                                If cump = 0 Then
                                    cump = c.SelectByScalar("Article", "bprice", params)
                                End If
                                Dim sb = oldStock
                                If sb > 0 Then sb = 0
                                cump = ((cump * sb) + (data.Rows(i).Item("bprice") * q)) / (sb + q)
                                Dim params2 As New Dictionary(Of String, Object)

                                params2.Add("CUMP", cump)
                                c.UpdateRecord("Article", params2, params)
                            End If

                            oldStock += q
                            updateStock(data.Rows(i).Item("arid"), data.Rows(i).Item("depot"), oldStock, c)
                        End If
                    End If
                Next
            End Using

            ds.Id = id
        Catch ex As Exception

        End Try
    End Sub



End Class
