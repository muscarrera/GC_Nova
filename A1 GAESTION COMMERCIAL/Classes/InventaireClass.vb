Public Class InventaireClass
    Implements IDisposable

    Public Sub AddDataList()
        If Form1.plBody.Controls.Count > 0 Then
            If TypeOf Form1.plBody.Controls(0) Is InventaireList Then
                Dim _ds As InventaireList = Form1.plBody.Controls(0)
                LoadHomePage(_ds)
                Exit Sub
            End If
        End If
        Form1.plBody.Controls.Clear()




        Dim ds As New InventaireList
        ds.Dock = DockStyle.Fill
        AddHandler ds.LoadHomePage, AddressOf LoadHomePage



        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Mission", {"*"})

            Form1.plBody.Controls.Add(ds)
        End Using
    End Sub

    Private Sub LoadHomePage(ByRef ds As InventaireList)
        ds.pl.Controls.Clear()
        Dim hm As New InvHome
        hm.Dock = DockStyle.Fill
        AddHandler hm.Reception, AddressOf Reception
        AddHandler hm.Livraison, AddressOf Livraison
        AddHandler hm.Transfer, AddressOf Transfer
        AddHandler hm.Valorisation, AddressOf Valorisation
        AddHandler hm.Ajustement, AddressOf Ajustement
        AddHandler hm.Tracabilite, AddressOf Tracabilite

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            'livraison
            Dim c = a.SelectDataTableWithSyntaxe("Bon_Livraison", "COUNT(id)")
            hm.btLiv.Text = c.Rows(0).Item(0).ToString & " Operations"

            Dim params As New Dictionary(Of String, Object)
            If Form1.useButtonValidForStock Then
                params.Add("isValid", False)
                c = a.SelectDataTableWithSyntaxe("Bon_Livraison", "COUNT(id)", , params)
                params.Clear()
                hm.lbLiv.Text = c.Rows(0).Item(0).ToString & " Operations en atente"
            End If
            'Reception
            c = a.SelectDataTableWithSyntaxe("Bon_Achat", "COUNT(id)")
            hm.btRec.Text = c.Rows(0).Item(0).ToString & " Operations"

            If Form1.useButtonValidForStock Then
                params.Add("isValid", False)
                c = a.SelectDataTableWithSyntaxe("Bon_Achat", "COUNT(id)", , params)
                params.Clear()
                hm.lbRec.Text = c.Rows(0).Item(0).ToString & " Operations en atente"
            End If
            'Entrepotes
            c = a.SelectDataTableWithSyntaxe("Depot", "COUNT(dpid)")
            hm.btEntrepote.Text = c.Rows(0).Item(0).ToString & " Entrepotes"

            'valorisation
            params.Add("isAjustement", False)
            c = a.SelectDataTableWithSyntaxe("Ajustement_Stock", "COUNT(ajId)", , params)
            params.Clear()
            hm.btValeur.Text = c.Rows(0).Item(0).ToString & " Operations"

            'Ajustement
            params.Add("isAjustement", True)
            c = a.SelectDataTableWithSyntaxe("Ajustement_Stock", "COUNT(ajId)", , params)
            params.Clear()
            hm.btAjust.Text = c.Rows(0).Item(0).ToString & " Operations"

            'Transferts
            c = a.SelectDataTableWithSyntaxe("Details_Transfer", "COUNT(id)")
            params.Clear()
            hm.btTransfer.Text = c.Rows(0).Item(0).ToString & " Transferts"

        End Using



        ds.pl.Controls.Add(hm)
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
    'style DataGrid
    Private Sub StyleDatagrid(ByRef dg As DataGridView)
        dg.AutoGenerateColumns = True
        dg.BorderStyle = Windows.Forms.BorderStyle.None
        dg.CellBorderStyle = DataGridViewCellBorderStyle.None
        dg.RowsDefaultCellStyle.BackColor = Form1.Color_Default_Row
        dg.AlternatingRowsDefaultCellStyle.BackColor = Form1.Color_Alternating_Row

        dg.DefaultCellStyle.SelectionBackColor = Form1.Color_Selected_Row
        dg.DefaultCellStyle.SelectionForeColor = Form1.Color_Selected_Text

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.MultiSelect = False

        dg.AllowUserToResizeColumns = False
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub

    'Home
    Private Sub Reception()
        Dim ds As InventaireList = Form1.plBody.Controls(0)
        ds.pl.Controls.Clear()

        Dim rc As New InvReception
        rc.Dock = DockStyle.Top
        rc.dte1.Value = Now.Date.AddMonths(-2)
        rc.tb_B = "Bon_Achat"
        rc.tb_C = "Fournisseur"
        rc.tb_D = "Details_Bon_Achat"
        rc.Mode = "LIST"

        rc.isSell = False

        rc.txt.AutoCompleteSource = AutoCompleteByName("Fournisseur")
        AddHandler rc.Search, AddressOf Receprion_Search
        AddHandler rc.Apercu, AddressOf Receprion_Apercu
        AddHandler rc.Print, AddressOf Receprion_Print

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            'livraison
            Dim dt = a.SelectDataTable("Depot", {"*"})
            If dt.Rows.Count > 0 Then
                dt.Rows.Add(0, "Tous")

                rc.cbDepot.DataSource = dt
                rc.cbDepot.DisplayMember = "name"
                rc.cbDepot.ValueMember = "dpid"
                rc.cbDepot.SelectedValue = 0
            End If
        End Using

        ds.pl.Controls.Add(rc)
    End Sub
    Private Sub Livraison()
        Dim ds As InventaireList = Form1.plBody.Controls(0)
        ds.pl.Controls.Clear()


        Dim rc As New InvReception
        rc.Dock = DockStyle.Top
        rc.dte1.Value = Now.Date.AddMonths(-2)
        rc.tb_B = "Bon_Livraison"
        rc.tb_C = "Client"
        rc.tb_D = "Details_Bon_Livraison"
        rc.Mode = "LIST"

        rc.isSell = True

        rc.txt.AutoCompleteSource = AutoCompleteByName("Client")
        AddHandler rc.Search, AddressOf Receprion_Search
        AddHandler rc.Apercu, AddressOf Receprion_Apercu
        AddHandler rc.Print, AddressOf Receprion_Print

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

            Dim dt = a.SelectDataTable("Depot", {"*"})
            If dt.Rows.Count > 0 Then
                dt.Rows.Add(0, "Tous")

                rc.cbDepot.DataSource = dt
                rc.cbDepot.DisplayMember = "name"
                rc.cbDepot.ValueMember = "dpid"
                rc.cbDepot.SelectedValue = 0
            End If
        End Using

        ds.pl.Controls.Add(rc)
    End Sub

    Private Sub Transfer()
        Dim ds As InventaireList = Form1.plBody.Controls(0)
        ds.pl.Controls.Clear()


        Dim rc As New InvTransfer
        rc.Dock = DockStyle.Top
        rc.dte1.Value = Now.Date.AddMonths(-2)

        rc.txt.AutoCompleteSource = AutoCompleteByName("Article")
        AddHandler rc.Search, AddressOf Transfer_Search
        AddHandler rc.AddNew, AddressOf Transfer_AddNew
        AddHandler rc.Print, AddressOf Transfer_Print
        ds.pl.Controls.Add(rc)
    End Sub

    Private Sub Tracabilite()
        Dim ds As InventaireList = Form1.plBody.Controls(0)
        ds.pl.Controls.Clear()

        Dim rc As New InvTracability
        rc.Dock = DockStyle.Top

        rc.dte1.Value = Now.Date.AddMonths(-2)
        rc.txt.AutoCompleteSource = AutoCompleteByName("Article")
        rc.txtDepot.AutoCompleteSource = AutoCompleteByName("Depot")

        AddHandler rc.Search, AddressOf Trace_Search
       
        StyleDatagrid(rc.dg_D)

        rc.dg_D.EditMode = DataGridViewEditMode.EditProgrammatically
        ds.pl.Controls.Add(rc)
    End Sub
    Private Sub Ajustement()
        Dim ds As InventaireList = Form1.plBody.Controls(0)
        ds.pl.Controls.Clear()

        Dim rc As New InvJustement
        rc.Dock = DockStyle.Top
        rc.isAjustement = True

        rc.txtCat.AutoCompleteSource = AutoCompleteByName("Category")
        rc.txtDepot.AutoCompleteSource = AutoCompleteByName("Depot")

        AddHandler rc.getDetails, AddressOf Ajust_getDetails
        AddHandler rc.getList, AddressOf Ajust_getList
        AddHandler rc.AddNew_Ajustement, AddressOf Ajust_AddNew
        AddHandler rc.SaveDetails, AddressOf Ajust_SaveDetails
        AddHandler rc.SavePdfDetails, AddressOf Ajust_SavePdfDetails
        AddHandler rc.PrintDetails, AddressOf Ajust_PrintDetails
        AddHandler rc.PrintList, AddressOf Ajust_PrintList
        AddHandler rc.ValiderAjustement, AddressOf Ajust_valider

        StyleDatagrid(rc.dg_D)
        StyleDatagrid(rc.dg_L)
        rc.dg_D.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        rc.id_Jus = 0

        ds.pl.Controls.Add(rc)
    End Sub
    Private Sub Valorisation()
        Dim ds As InventaireList = Form1.plBody.Controls(0)
        ds.pl.Controls.Clear()

        Dim rc As New InvJustement
        rc.Dock = DockStyle.Top
        rc.isAjustement = False

        rc.txtCat.AutoCompleteSource = AutoCompleteByName("Category")
        rc.txtDepot.AutoCompleteSource = AutoCompleteByName("Depot")

        AddHandler rc.getDetails, AddressOf Ajust_getDetails
        AddHandler rc.getList, AddressOf Ajust_getList
        AddHandler rc.AddNew_Valorisation, AddressOf Valorisation_AddNew
        AddHandler rc.SaveDetails, AddressOf Ajust_SaveDetails
        AddHandler rc.SavePdfDetails, AddressOf Ajust_SavePdfDetails
        AddHandler rc.PrintDetails, AddressOf Ajust_PrintDetails
        AddHandler rc.PrintList, AddressOf Ajust_PrintList
        AddHandler rc.ValiderValorisation, AddressOf Valorisation_valider

        StyleDatagrid(rc.dg_D)
        StyleDatagrid(rc.dg_L)
        rc.dg_D.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2

        rc.id_Jus = 0
        ds.pl.Controls.Add(rc)
    End Sub

    'Reception
    Private Sub Receprion_Search(ByRef ds As InvReception)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            ds.pl.Controls.Clear()
            Dim dg As New DataGridView

            ds.pl.Controls.Add(dg)
            StyleDatagrid(dg)

            Dim dte1 As Date = ds.dte1.Value.AddDays(-1)
            Dim dte2 As Date = ds.dte2.Value.AddDays(1)

            Dim tb_B = ds.tb_B
            Dim tb_C = ds.tb_C
            Dim tb_D = ds.tb_D


            If ds.cbDetail.Checked Then

                Dim BTA As New ALMohassinDBDataSetTableAdapters.ReceptionTableAdapter
                If ds.isSell = False Then
                    ds.dt_D = BTA.GetDataIn(dte1, dte2)
                Else
                    ds.dt_D = BTA.GetDataOUT(dte1, dte2)
                End If
                ds.Mode = "DETAILS"
            Else
                'List
                params.Add("[date] > ", dte1.ToString("dd/MM/yyyy"))
                params.Add("[date] < ", dte2.ToString("dd/MM/yyyy"))

                If ds.txt.text.Contains("|") Then params.Add(" cid  = ", ds.txt.text.Split("|")(1))

                Dim dt = a.SelectDataTableSymbols(tb_B, {"*"}, params)

                If IsNothing(dt) Then MsgBox("Aucun résultat trouvé", MsgBoxStyle.Information, "Recherche")

                dg.DataSource = dt
                AddHandler dg.CellMouseDoubleClick, AddressOf Reception_Dg_MouseDoubleClick

                '''''''''''''''''''''''''''''''''''''''''''''
                dg.Columns(0).Visible = False
                dg.Columns(2).Visible = False
                dg.Columns(4).Visible = False
                dg.Columns(6).Visible = False
                dg.Columns(5).Visible = False
                dg.Columns(7).Visible = False
                dg.Columns(8).Visible = False
                dg.Columns(9).Visible = False
                dg.Columns(11).Visible = False
                dg.Columns(10).Visible = False
                dg.Columns(13).Visible = False
                dg.Columns(14).Visible = False
                dg.Columns(15).Visible = False
                dg.Columns(16).Visible = False
                dg.Columns(17).Visible = False
                dg.Columns(18).Visible = False
                dg.Columns(19).Visible = False

                dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
                dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                dg.Columns(3).FillWeight = 200

                dg.Columns(1).HeaderText = "Date"
                dg.Columns(3).HeaderText = "Libellé"
                dg.Columns(12).HeaderText = "Editeur"
                '''''''''''''''''''''''''''''''''''''''''''''''
                ds.Mode = "LIST"

                ds.lbLnbr.Text = dg.Rows.Count & " Lines"
                ds.Height = (dg.Rows.Count * 40) + 500
            End If



        End Using
    End Sub
    Private Sub Receprion_Apercu(ByRef ds As InvReception)
        Try
            Dim dg As DataGridView = ds.pl.Controls(0)
            Reception_Dg_MouseDoubleClick(dg, Nothing)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Reception_Dg_MouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        Dim dg As DataGridView = sender
        If dg.SelectedRows.Count = 0 Then Exit Sub

        Dim ds As InvReception = dg.Parent.Parent.Parent

        If ds.Mode <> "LIST" Then Exit Sub

        Dim fctid As Integer = CInt(dg.SelectedRows(0).Cells(0).Value)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)

            Dim dte1 As Date = ds.dte1.Value.AddDays(-1)
            Dim dte2 As Date = ds.dte2.Value.AddDays(1)

            Dim tb_B = ds.tb_B
            Dim tb_C = ds.tb_C
            Dim tb_D = ds.tb_D

            params.Add("fctid = ", fctid)
            If ds.cbDepot.SelectedValue > 0 Then params.Add("depot = ", ds.cbDepot.SelectedValue)

            Dim dt = a.SelectDataTableSymbols(tb_D, {"*"}, params)

            dg.DataSource = dt
            'StyleDatagrid(dg)
            'ds.pl.Controls.Add(dg)

            dg.Columns(0).Visible = False
            dg.Columns(1).Visible = False
            dg.Columns(3).Visible = False
            dg.Columns(4).Visible = False
            dg.Columns(5).Visible = False
            dg.Columns(7).Visible = False
            dg.Columns(11).Visible = False
            dg.Columns(10).Visible = False


            dg.Columns(2).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(2).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
            dg.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dg.Columns(2).FillWeight = 300
            dg.Columns(2).Width = 300

            dg.Columns(0).HeaderText = "ID/N°"
            dg.Columns(1).HeaderText = "Date"
            dg.Columns(2).HeaderText = "Libellé"
            dg.Columns(6).HeaderText = "QTE"
            dg.Columns(8).HeaderText = "Réf"
            dg.Columns(9).HeaderText = "Entrepôte"

            ds.Mode = "DETAIL"
        End Using

        ds.Height = (dg.Rows.Count * 40) + 500
        ds.lbLnbr.Text = dg.Rows.Count & " Lines"
    End Sub
    Private Sub Receprion_Print(ByRef ds As InvReception)
        Throw New NotImplementedException
    End Sub
    'Transfer
    Private Sub Transfer_Search(ByRef ds As InvTransfer)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            ds.pl.Controls.Clear()
            Dim dg As New DataGridView

            Dim dte1 As Date = ds.dte1.Value.AddDays(-1)
            Dim dte2 As Date = ds.dte2.Value.AddDays(1)

            Dim tb_B = "Details_Transfer"
           
            params.Add("[date] > ", dte1.ToString("dd/MM/yyyy"))
            params.Add("[date] < ", dte2.ToString("dd/MM/yyyy"))

            If ds.txt.text.Contains("|") Then params.Add(" arid  = ", ds.txt.text.Split("|")(1))

                Dim dt = a.SelectDataTableSymbols(tb_B, {"*"}, params)
                'Dim dg As New DataGridView
            If IsNothing(dt) Then MsgBox("aucun résultat trouvé", MsgBoxStyle.Information, "Transfertes Internes")

            dg.DataSource = dt
                StyleDatagrid(dg)
                ds.pl.Controls.Add(dg)
                AddHandler dg.CellMouseDoubleClick, AddressOf Reception_Dg_MouseDoubleClick

                '''''''''''''''''''''''''''''''''''''''''''''
            dg.Columns(0).Visible = False
            dg.Columns(1).Visible = False
            dg.Columns(3).Visible = False
            dg.Columns(4).Visible = False
              

            dg.Columns(2).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(2).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
            dg.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            dg.Columns(2).FillWeight = 300

            dg.Columns(2).HeaderText = "Designation"
            dg.Columns(5).HeaderText = "Départ entrepôt "
            dg.Columns(6).HeaderText = "Destination"
            dg.Columns(7).HeaderText = "Qte"
            dg.Columns(8).HeaderText = "Date"
            dg.Columns(9).HeaderText = "Editeur "

            ds.lbLnbr.Text = dg.Rows.Count & " Lines"
            ds.Height = (dg.Rows.Count * 40) + 500
        End Using
    End Sub
    Private Sub Transfer_AddNew(ByRef ds As InvTransfer)
        Dim mv As New SearchForArticle
        If mv.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If

        ds.dte1.Value = Now.Date.AddMonths(-2)
        ds.dte2.Value = Now.Date
        ds.txt.text = ""

        Transfer_Search(ds)
    End Sub
    Private Sub Transfer_Print(ByRef ds As InvTransfer)
        Throw New NotImplementedException
    End Sub

    'Ajustement
    Private Sub Ajust_getList(ByRef ds As InvJustement)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("isAjustement", ds.isAjustement)
            Dim dt = a.SelectDataTable("Ajustement_Stock", {"*"}, params)
            ds.dg_L.DataSource = dt

            ds.dg_L.Columns(0).Visible = False
            ds.dg_L.Columns(4).Visible = False
            ds.dg_L.Columns(6).Visible = False

            ds.dg_L.Columns(1).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            ds.dg_L.Columns(1).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
            ds.dg_L.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

            ds.dg_L.Columns(1).HeaderText = "Date"
            ds.dg_L.Columns(2).HeaderText = "Destination"
            ds.dg_L.Columns(3).HeaderText = "Observation"
            ds.dg_L.Columns(5).HeaderText = "Editeur "
            If ds.isAjustement = False Then ds.dg_L.Columns(3).HeaderText = "Valeur"

            ds.lbLnbr.Text = ds.dg_L.Rows.Count & " Lines"
            ds.Height = (ds.dg_L.Rows.Count * 40) + 250
        End Using
    End Sub
    Private Sub Ajust_getDetails(ByRef ds As InvJustement)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("ajId", ds.id_Jus)

            Dim dt_L = a.SelectDataTable("Ajustement_Stock", {"*"}, params)
            Dim dt_D = a.SelectDataTable("Details_Ajustement_Stock", {"*"}, params)

            ds.name_Jus = StrValue(dt_L, "name", 0)
            ds.Obs = StrValue(dt_L, "obs", 0)
            ds.date_Jus = DteValue(dt_L, "date", 0)
            ds.isValid = BoolValue(dt_L, "isValid", 0)

            ds.dataSource = dt_D
            ds.Height = (ds.dg_D.Rows.Count * 33) + 450
            ds.lbLnbr.Text = ds.dg_D.Rows.Count & " Articles"
        End Using
    End Sub
    Private Sub Ajust_SaveDetails(ByRef ds As InvJustement)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("name", ds.txtName.text)
            params.Add("obs", ds.txtObs.text)
            where.Add("ajId", ds.id_Jus)

            a.UpdateRecord("Ajustement_Stock", params, where)


            For i As Integer = 0 To ds.dg_D.Rows.Count - 1
                Dim oldQ As Double = ds.dg_D.Rows(i).Cells(5).Value
                If Not IsNumeric(ds.dg_D.Rows(i).Cells(6).Value) Then Continue For
                Dim newQ As Double = ds.dg_D.Rows(i).Cells(6).Value
                If newQ = oldQ Then Continue For

                where.Clear()
                params.Clear()

                params.Add("qte_Real", newQ)
                where.Add("id", ds.dg_D.Rows(i).Cells(0).Value)

                a.UpdateRecord("Details_Ajustement_Stock", params, where)
            Next
        End Using
    End Sub
    Private Sub Ajust_valider(ByRef ds As InvJustement)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("isValid", True)
            where.Add("ajId", ds.id_Jus)
            a.UpdateRecord("Ajustement_Stock", params, where)

            For i As Integer = 0 To ds.dg_D.Rows.Count - 1
                Dim oldQ As Double = ds.dg_D.Rows(i).Cells(5).Value
                If Not IsNumeric(ds.dg_D.Rows(i).Cells(6).Value) Then Continue For
                Dim newQ As Double = ds.dg_D.Rows(i).Cells(6).Value
                If newQ = oldQ Then Continue For

                where.Clear()
                params.Clear()

                params.Add("qte", newQ)
                where.Add("arid", ds.dg_D.Rows(i).Cells(2).Value)
                where.Add("dpid", ds.dg_D.Rows(i).Cells(4).Value)

                a.UpdateRecord("Details_Stock", params, where)

                where.Clear()
                params.Clear()

                params.Add("qte_Real", newQ)
                where.Add("id", ds.dg_D.Rows(i).Cells(0).Value)

                a.UpdateRecord("Details_Ajustement_Stock", params, where)
            Next

            ds.isValid = True
        End Using
    End Sub
    Private Sub Ajust_AddNew(ByRef ds As InvJustement)
        Dim id As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("isValid", True)
            where.Add("isAjustement", ds.isAjustement)
            a.UpdateRecord("Ajustement_Stock", params, where)
            params.Clear()

            params.Add("date", Now.Date)
            params.Add("name", "-")
            params.Add("obs", "-")
            params.Add("isValid", False)
            params.Add("writer", Form1.adminName)
            params.Add("isAjustement", True)
            id = a.InsertRecord("Ajustement_Stock", params, True)

            If id > 0 Then
                Dim st_dt As DataTable = a.SelectDataTable("Details_Stock", {"*"})
                For i As Integer = 0 To st_dt.Rows.Count - 1
                    params.Clear()
                    Dim arid As Integer = IntValue(st_dt, "arid", i)
                    params.Add("arid", arid)
                    Dim name As String = " "
                    name = a.SelectByScalar("Article", "name", params)

                    params.Clear()
                    params.Add("ajId", id)
                    params.Add("arid", arid)
                    params.Add("name", name)
                    params.Add("dpid", IntValue(st_dt, "dpid", i))
                    params.Add("qte_theorique", DblValue(st_dt, "qte", i))
                    params.Add("qte_Real", DblValue(st_dt, "qte", i))
                    params.Add("cid", IntValue(st_dt, "cid", i))
                    a.InsertRecord("Details_Ajustement_Stock", params)
                Next
            End If
        End Using
        ds.id_Jus = id
    End Sub

    Private Sub Valorisation_valider(ByRef ds As InvJustement)
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("isValid", True)
            where.Add("ajId", ds.id_Jus)
            a.UpdateRecord("Ajustement_Stock", params, where)

            For i As Integer = 0 To ds.dg_D.Rows.Count - 1
                If Not IsNumeric(ds.dg_D.Rows(i).Cells(6).Value) Then Continue For
                Dim price As Double = ds.dg_D.Rows(i).Cells(6).Value

                where.Clear()
                params.Clear()

                params.Add("bprice", price)
                params.Add("CUMP", price)
                where.Add("arid", ds.dg_D.Rows(i).Cells(2).Value)

                a.UpdateRecord("Article", params, where)

                where.Clear()
                params.Clear()

                params.Add("qte_Real", price)
                where.Add("id", ds.dg_D.Rows(i).Cells(0).Value)

                a.UpdateRecord("Details_Ajustement_Stock", params, where)
            Next

            ds.isValid = True
        End Using
    End Sub
    Private Sub Valorisation_AddNew(ByRef ds As InvJustement)

        Dim id As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            params.Add("isValid", True)
            where.Add("isAjustement", ds.isAjustement)
            a.UpdateRecord("Ajustement_Stock", params, where)
            params.Clear()

            params.Add("date", Now.Date)
            params.Add("name", "-")
            params.Add("obs", "-")
            params.Add("isValid", False)
            params.Add("writer", Form1.adminName)
            params.Add("isAjustement", ds.isAjustement)
            id = a.InsertRecord("Ajustement_Stock", params, True)

            If id > 0 Then
                Dim st_dt As DataTable = a.SelectDataTable("Details_Stock", {"*"})
                For i As Integer = 0 To st_dt.Rows.Count - 1
                    params.Clear()
                    Dim arid As Integer = IntValue(st_dt, "arid", i)
                    params.Add("arid", arid)
                    Dim name As String = " "
                    Dim pr As Double = 0
                    Try
                        Dim dt = a.SelectDataTable("Article", {"*"}, params)
                        If dt.Rows.Count = 0 Then Continue For
                        name = dt.Rows(0).Item("name")
                        Try
                            'price
                            If Form1.useValue_CUMP Then pr = dt.Rows(0).Item(20)
                            If pr = 0 Then pr = dt.Rows(0).Item(5)
                        Catch ex As Exception
                            pr = dt.Rows(0).Item(5)
                        End Try
                    Catch ex As Exception
                        Continue For
                    End Try

                    params.Clear()
                    params.Add("ajId", id)
                    params.Add("arid", arid)
                    params.Add("name", name)
                    params.Add("dpid", IntValue(st_dt, "dpid", i))
                    params.Add("qte_theorique", DblValue(st_dt, "qte", i))
                    params.Add("qte_Real", pr)
                    params.Add("cid", IntValue(st_dt, "cid", i))
                    a.InsertRecord("Details_Ajustement_Stock", params)
                Next
            End If
        End Using
        ds.id_Jus = id

    End Sub

    Private Sub Ajust_PrintDetails(ByRef ds As InvJustement)
        ds.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
        ds.PrintDoc.Print()
    End Sub
    Private Sub Ajust_SavePdfDetails(ByRef ds As InvJustement)
        ds.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Pdf
        ds.PrintDoc.Print()
    End Sub
    Private Sub Ajust_PrintList(ByRef ds As InvJustement)

        ds.PrintDoc.PrinterSettings.PrinterName = Form1.printer_Bon
        ds.PrintDoc.Print()


    End Sub

    'tracability
    Private Sub Trace_Search(ByRef ds As InvTracability)

        'Dim tb_In = "Bon_Livraison"
        'Dim tb_In_D = "Details_Bon_Livraison"
        'Dim tb_Out = "Bon_Livraison"
        'Dim tb_Out_D = "Details_Bon_Livraison"

        Dim dte1 As Date = ds.dte1.Value.AddDays(-1)
        Dim dte2 As Date = ds.dte2.Value.AddDays(1)

        'Dim params As New Dictionary(Of String, Object)
        'params.Add(tb_In & ".[date] > ", CDate(dte1.ToString("dd-MM-yyyy")))
        'params.Add(tb_In & ".[date] < ", CDate(dte2.ToString("dd-MM-yyyy")))

        'params.Add(tb_In_D & ".arid = ", ds.arid)


        Dim BTA As New ALMohassinDBDataSetTableAdapters.TracabilityINTableAdapter
        ds.dt_in = BTA.GetDataIN(dte1, dte2, ds.arid)
        ds.dt_Out = BTA.GetDataOUT(dte1, dte2, ds.arid)

    End Sub
End Class
