Imports System.IO

Public Class PvList

    Public tb_C As String = "Client"
    Public tb_F As String = "Commande_Client"
    Public tb_D As String = "Details_Commande"
    Public tb_P As String = "Client_Payement"
    Dim m As Object

    Event txtSearchRef_Changed(ByRef ds As PvList, ByVal txt As String)
    Event txtSearchRef_KeyPress(ByRef ds As PvList, ByVal txt As String)
    Event txtSearchCodebar_KeyPress(ByRef ds As PvList, ByVal txt As String)
    Event SelectBon(ByRef ds As PvList, ByVal lName As Object)
    Event FillGroupe()
    Event SaveBon(ByVal pvList As PvList)
    Event SaveToDb(ByVal pvList As PvList)

    'Members
    Public modeSearch_isCode As Boolean = False
    Public SearchBy As String = "all"
    Public localName As String

    'property
    Private numberOpenBonsValue As Integer
    Shared random As New Random()


    Public Property numberOpenBons() As Integer
        Get
            Return numberOpenBonsValue
        End Get
        Set(ByVal value As Integer)
            numberOpenBonsValue = value

            If value > 0 Then
                plClientSide.Width = 350
                lbNbrBon.Text = value

                If value > 10 Then
                    lbNbrBon.ForeColor = Color.Red
                Else
                    lbNbrBon.ForeColor = Color.Green
                End If
            Else
                plClientSide.Width = 62
            End If
        End Set
    End Property
    Public ReadOnly Property ThePath As String
        Get
            Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\Prt_Pv")
            If dir1.Exists = False Then dir1.Create()

            Return Form1.ImgPah & "\Prt_Pv\" & localName
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        modeSearch_isCode = getRegistryinfo("modeSearch_isCode", True)
        SearchBy = getRegistryinfo("SearchBy", "all")


        tb_C = getRegistryinfo("pv_tb_C", "Client")
        tb_F = getRegistryinfo("pv_tb_F", "Commande_Client")
        tb_D = getRegistryinfo("pv_tb_D", "Details_Commande")
        tb_P = getRegistryinfo("pv_tb_P", "Client_Payement")

    End Sub

    'subs
    Public Sub KeepTxtFocus()
        If modeSearch_isCode Then
            txtSearchCode.Text = ""
            txtSearchCode.Focus()
        Else
            txtSearch.Text = ""
            txtSearch.Focus()
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
                                               ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim k As System.Windows.Forms.Keys = keyData
        Select Case keyData

            Case Keys.Escape
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0
                 
                UpdateItemQte(RPL.SelectedItem, qte)

            Case Keys.F1
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0.005
                If RPL.SelectedItem.Unite = "g" Or RPL.SelectedItem.Unite = "ج" Then qte = 5

                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)

            Case Keys.F2
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0.01
                If RPL.SelectedItem.Unite = "g" Or RPL.SelectedItem.Unite = "ج" Then qte = 10

                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)
            Case Keys.F3
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0.05
                If RPL.SelectedItem.Unite = "g" Or RPL.SelectedItem.Unite = "ج" Then qte = 50
                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)
            Case Keys.F4
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0.1
                If RPL.SelectedItem.Unite = "g" Or RPL.SelectedItem.Unite = "ج" Then qte = 100
                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)
            Case Keys.F5
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0.25
                If RPL.SelectedItem.Unite = "g" Or RPL.SelectedItem.Unite = "ج" Then qte = 250
                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)
            Case Keys.F6
                If RPL.CP.isActive = False Then Return False
                Dim qte = 0.5
                If RPL.SelectedItem.Unite = "g" Or RPL.SelectedItem.Unite = "ج" Then qte = 500
                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)
            Case Keys.Add ' add one
                If RPL.CP.isActive = False Then Return False
                Dim qte = 1
                UpdateItemQte(RPL.SelectedItem, RPL.SelectedItem.Qte + qte)
            Case Keys.Subtract  ' sub one
                If RPL.CP.isActive = False Then Return False
                Dim qte = RPL.SelectedItem.Qte - 1
                If qte < 0 Then qte = 0
                UpdateItemQte(RPL.SelectedItem, qte + qte)


                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Case Keys.F8 ' add NOUVEAU FACTURE
                SaveChanges()
              
                NewComptoirBon()

            Case Keys.F9 ' add NOUVEAU FACTURE
                SaveChanges()
                
                    Dim n = random.Next().ToString & "-" & Now.Date.ToString("dd-MM-mm-hh") & ".dat"


                        Dim NF As New NouveauFacture
                        NF.TxtExr.Text = Form1.Exercice
                        NF.txtName.Focus()
                        NF.txtName.AutoCompleteSource = AutoCompleteByName(tb_C)
                        NF.tb_C = tb_C
                        NF.txtDate.text = Now.Date.ToString("dd/MM/yyyy")
                        If NF.ShowDialog = DialogResult.OK Then
                            Dim cn As String = NF.txtName.text
                            Dim cid As String = 0
                    localName = n

                            Try
                                cn = NF.txtName.text.Split("|")(0)
                                cid = NF.txtName.text.Split("|")(1)
                            Catch ex As Exception
                                cid = 0
                            End Try

                            Try

                                Dim g As New PvModel
                                g.bonDate = CDate(NF.txtDate.text)
                                g.ClientId = cid
                                g.ClientName = cn
                                g.localName = n

                                WriteToXmlFile(Of PvModel)(ThePath, g)

                            Catch ex As Exception
                            End Try

                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If

                LoadOpenBons()
                RaiseEvent SelectBon(Me, n)
                KeepTxtFocus()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Case Keys.F12

            Case Keys.F11

            Case Keys.Tab
                modeSearch_isCode = Not modeSearch_isCode
                KeepTxtFocus()

            Case Keys.Space  ' save and print
                Dim a As Integer = 0

                If txtSearch.Focused Then a = 1
                If txtSearchCode.Focused Then a = 1


                If a = 1 Then
                    If RPL.Total_TTC = 0 Then
                        Return MyBase.ProcessCmdKey(msg, keyData)
                    End If

                    If txtSearch.Text.Trim <> "" Or txtSearchCode.Text.Trim <> "" Then
                        Return MyBase.ProcessCmdKey(msg, keyData)
                    End If



                    'If cbPaper.Text = "Receipt" Then
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, False, False)
                    'ElseIf cbPaper.Text = "Normal" Then
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, True, False)
                    'ElseIf cbPaper.Text = "Normal&A4" Then
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, True, False)
                    'Else
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, False, False)
                    'End If
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If

            Case Keys.Delete ' delete facture

                Try
                    For Each op As pvOpenBon_item In PL.Controls
                        If op.isActive Then
                            DeleteBon(op)
                        End If
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select

        KeepTxtFocus()
        Return True
    End Function

    'Search
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress

        If e.KeyChar = Chr(13) And FL.Controls.Count = 1 Then
            RaiseEvent txtSearchRef_KeyPress(Me, txtSearch.Text)
            KeepTxtFocus()
        End If

    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        RaiseEvent txtSearchRef_Changed(Me, txtSearch.Text)

    End Sub
    Private Sub txtSearchCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCode.KeyPress

        If e.KeyChar = Chr(13) Then
            RaiseEvent txtSearchCodebar_KeyPress(Me, txtSearchCode.Text)
            KeepTxtFocus()
        End If

    End Sub
    'new bons
    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        SaveChanges()
        Dim op As New pvNewFacture
        If op.ShowDialog = DialogResult.OK Then
            Dim n = random.Next().ToString & "-" & Now.Date.ToString("dd-MM-mm-hh") & ".dat"
            localName = n

            If op.isNormal Then
                Try

                    Dim g As New PvModel
                    g.localName = n

                    g.bonDate = CDate(Now.Date)
                    g.ClientId = 0
                    g.ClientName = Form1.pv_NormalClient
                  
                    WriteToXmlFile(Of PvModel)(ThePath, g)

                Catch ex As Exception
                End Try
            Else
                Dim NF As New NouveauFacture
                NF.TxtExr.Text = Form1.Exercice
                NF.txtName.Focus()
                NF.txtName.AutoCompleteSource = AutoCompleteByName(tb_C)
                NF.tb_C = tb_C
                NF.txtDate.text = Now.Date.ToString("dd/MM/yyyy")
                If NF.ShowDialog = DialogResult.OK Then
                    Dim cn As String = NF.txtName.text
                    Dim cid As String = 0

                    Try
                        cn = NF.txtName.text.Split("|")(0)
                        cid = NF.txtName.text.Split("|")(1)
                    Catch ex As Exception
                        cid = 0
                    End Try

                    Try

                        Dim g As New PvModel
                        g.bonDate = CDate(NF.txtDate.text)
                        g.ClientId = cid
                        g.ClientName = cn
                        g.localName = n

                        WriteToXmlFile(Of PvModel)(ThePath, g)

                    Catch ex As Exception
                    End Try

                End If
            End If


            LoadOpenBons()

            RaiseEvent SelectBon(Me, n)
        End If
        KeepTxtFocus()
    End Sub
    Public Sub NewComptoirBon()
        Dim n = random.Next().ToString & "-" & Now.Date.ToString("dd-MM-mm-hh") & ".dat"
        localName = n
        Try

            Dim g As New PvModel
            g.localName = n

            g.bonDate = CDate(Now.Date)
            g.ClientId = 0
            g.ClientName = Form1.pv_NormalClient

            WriteToXmlFile(Of PvModel)(ThePath, g)

        Catch ex As Exception
        End Try

        LoadOpenBons()
        RaiseEvent SelectBon(Me, n)
        KeepTxtFocus()
    End Sub

    'show list of open bons
    Private Sub Panel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click, lbNbrBon.Click
        If numberOpenBonsValue Then PL.Visible = Not PL.Visible
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        RaiseEvent FillGroupe()
    End Sub
    Private Sub plClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plClient.Click
        Dim op As New pvNewFacture
        If op.ShowDialog = DialogResult.OK Then

            If op.isNormal Then
                Try

                    RPL.myClient = New Client()
                    lbName.Text = RPL.myClient.name

                Catch ex As Exception
                End Try
            Else
                Dim NF As New NouveauFacture
                NF.TxtExr.Text = Form1.Exercice
                NF.txtName.Focus()
                NF.txtName.AutoCompleteSource = AutoCompleteByName(tb_C)
                NF.tb_C = tb_C
                NF.txtDate.text = Now.Date.ToString("dd/MM/yyyy")
                If NF.ShowDialog = DialogResult.OK Then
                    Dim cn As String = NF.txtName.text
                    Dim cid As String = 0

                    Try
                        cid = NF.txtName.text.Split("|")(1)

                        RPL.myClient = New Client(cid, tb_C)
                        lbName.Text = RPL.myClient.name

                    Catch ex As Exception
                    End Try

                End If
            End If

            SaveChanges()
            LoadOpenBons()
        End If
        KeepTxtFocus()
    End Sub
    
    Public Sub LoadOpenBons()
        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\Prt_Pv")
        If dir1.Exists = False Then dir1.Create()


        Dim ln As String = "-"

        Dim aryFi As IO.FileInfo() = dir1.GetFiles("*.dat")
        Dim fi As IO.FileInfo
        Dim g As New PvModel

        numberOpenBons = aryFi.Length
        PL.Controls.Clear()

        For Each fi In aryFi

            g = ReadFromXmlFile(Of PvModel)(Form1.ImgPah & "\Prt_Pv\" & fi.Name)
            Dim bt As New pvOpenBon_item
            bt.ClientName = g.ClientName
            bt.localName = g.localName
            If ln = "-" Then ln = g.localName

            AddHandler bt.SelectedBon, AddressOf SelectedBon
            AddHandler bt.DeleteBon, AddressOf DeleteBon

            bt.Dock = DockStyle.Left
            PL.Controls.Add(bt)

            If localName = "" And ln <> "-" Then RaiseEvent SelectBon(Me, ln)
            KeepTxtFocus()
        Next
    End Sub
    Public Sub SaveChanges()
        Try
            If localName = "" Then Exit Sub

            Dim g As New PvModel
            g.bonDate = RPL.myDate
            g.ClientId = RPL.myClient.cid
            g.ClientName = RPL.myClient.name
            g.localName = localName
            g.DataSource = RPL.myDataSource

            WriteToXmlFile(Of PvModel)(ThePath, g)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub clearDetails()
        localName = ""
        RPL.ClearItems()
        lbName.Text = "-"
    End Sub

    Private Sub DeleteBon(ByVal it As pvOpenBon_item)
        If MsgBox(MsgDelete, MsgBoxStyle.YesNo, "Supression") = MsgBoxResult.Yes Then
            Try
                Dim strpath As String = Form1.ImgPah & "\Prt_Pv"
                Dim fullPath As String = Path.Combine(strpath, it.localName)
                File.Delete(fullPath)

                clearDetails()
                LoadOpenBons()
                KeepTxtFocus()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub SelectedBon(ByVal it As pvOpenBon_item)
        SaveChanges()
        RaiseEvent SelectBon(Me, it.localName)
    End Sub

    Private Sub RPL_UpdateItem(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RPL.UpdateItem
        Try
            Dim i As Items = sender
            Dim clc As New pvEditItemDetails(i.Name, i.Bprice, i.Price, i.Qte)
            If clc.ShowDialog = DialogResult.OK Then
                  
                    
                RPL.ChangedItems(i.id, clc.prdName, clc.prdBPrice, clc.prdSPrice, clc.prdQte)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RPL_CPValueChange() Handles RPL.CPValueChange
        KeepTxtFocus()
    End Sub
    Private Sub RPL_SaveFacture(ByVal id As System.Int32, ByVal total As System.Double, ByVal avance As System.Double, ByVal tva As System.Double, ByVal table As System.Data.DataTable) Handles RPL.SaveFacture
        SaveChanges()
        clearDetails()
        KeepTxtFocus()
    End Sub

    Private Sub UpdateItemQte(ByRef item As Items, ByVal qte As Double)
        Try
            item.Qte = qte
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RPL_UpdatePayment() Handles RPL.UpdatePayment
        If localName = "" Then Exit Sub

        Dim pv As New pvPaiement_Form
        pv.total = RPL.Total_TTC
        pv.cbWay.Text = RPL.modePayement
        If RPL.Avance > 0 Then pv.txt.text = RPL.Avance

        If pv.ShowDialog = DialogResult.OK Then
            RPL.Avance = pv.Value
            RPL.modePayement = pv.Mode
        End If

    End Sub
    'save to db
    Private Sub Panel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel6.Click
        Try
            RaiseEvent SaveToDb(Me)

            Dim strpath As String = Form1.ImgPah & "\Prt_Pv"
            Dim fullPath As String = Path.Combine(strpath, localName)
            File.Delete(fullPath)

            clearDetails()
            LoadOpenBons()

            KeepTxtFocus()

        Catch ex As Exception
        End Try

    End Sub
    Private Sub RPL_SaveAndPrint() Handles RPL.SaveAndPrint
        Try
            RaiseEvent SaveToDb(Me)
            Form1.PrintDocDesign.PrinterSettings.PrinterName = Form1.printer_POS
            PrintDoc.Print()

            Dim strpath As String = Form1.ImgPah & "\Prt_Pv"
            Dim fullPath As String = Path.Combine(strpath, localName)
            File.Delete(fullPath)
            clearDetails()
            LoadOpenBons()

            KeepTxtFocus()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Try
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
            data.Columns.Add("vidal", GetType(String))

            data.Rows.Add(0, RPL.myDate.ToString("dd/MM/yyyy"), RPL.myClient.cid, RPL.myClient.name,
                          String.Format("{0:0.00}", RPL.Total_Ht), String.Format("{0:0.00}", RPL.Tva),
                          String.Format("{0:0.00}", RPL.Total_TTC), String.Format("{0:0.00}", RPL.Remise),
                          String.Format("{0:0.00}", RPL.Avance), String.Format("{0:0.00}", 0),
                         RPL.modePayement, Form1.adminName, RPL.DataSource.Rows.Count)

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
            dt_Client.Rows.Add(RPL.myClient.cid, RPL.myClient.name, "", RPL.myClient.ville,
                              RPL.myClient.adresse, RPL.myClient.ICE, RPL.myClient.tel)


            Using g As gDrawClass = New gDrawClass("Ticket.dat")
                g.DrawBl(e, data, RPL.DataSource, dt_Client, "Ticket", False, m)
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PvList_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        SaveChanges()

    End Sub
End Class
