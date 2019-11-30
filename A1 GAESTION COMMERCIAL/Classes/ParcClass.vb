Public Class ParcClass
    Implements IDisposable

    Public Sub AddDataList()
        If Form1.plBody.Controls.Count > 0 Then
            If TypeOf Form1.plBody.Controls(0) Is ParcList Then
                Exit Sub
            End If
        End If

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Mission", {"*"})
            Form1.plBody.Controls.Clear()
            Dim ds As New ParcList
            ds.TableName = "Mission"
            ds.Mode = "List"
            'ds.DataSource = dt

            ds.Dock = DockStyle.Fill
            AddHandler ds.AddNewDriver, AddressOf AddNewDriver
            AddHandler ds.AddNewVehicule, AddressOf AddNewVehicule
            AddHandler ds.AddNewMission, AddressOf AddNewMissin

            AddHandler ds.GetElements, AddressOf GetElements
            AddHandler ds.GetElementsById, AddressOf GetElementsById

            AddHandler ds.EditSelectedVehicule, AddressOf EditSelectedVehicule
            AddHandler ds.EditSelectedDriver, AddressOf EditSelectedDriver
            AddHandler ds.DeleteSelectedElement, AddressOf DeleteSelectedElement
            AddHandler ds.GetElementInfos, AddressOf GetElementInfos

            AddHandler ds.SearchByDate, AddressOf SearchByDate
            AddHandler ds.AddFiles, AddressOf AddMissionFiles
            AddHandler ds.NewBcRef, AddressOf NewBcRef
            AddHandler ds.ClientChanged, AddressOf ClientChanged
            AddHandler ds.DriverChanged, AddressOf DriverChanged
            AddHandler ds.VehiculeChanged, AddressOf VehiculeChanged

            AddHandler ds.SaveChanges, AddressOf SaveChanges
            AddHandler ds.MissionFactured, AddressOf MissionFactured
            AddHandler ds.MissionSolde, AddressOf MissionSolde
            AddHandler ds.MissionDuplicate, AddressOf MissionDuplicate
            AddHandler ds.DeleteMission, AddressOf DeleteMission
            AddHandler ds.SavePdf, AddressOf SavePdf
            AddHandler ds.PramsPrint, AddressOf PramsPrint
            AddHandler ds.PrintMission, AddressOf PrintMission
            AddHandler ds.GetClientDetails, AddressOf GetClientDetails
            AddHandler ds.GetDeiverDetails, AddressOf GetDeiverDetails
            AddHandler ds.GetVehiculeDetails, AddressOf GetVehiculeDetails


            Form1.plBody.Controls.Add(ds)
        End Using

    End Sub



    Private Sub GetElements(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim str As String = "Mid"
            If ds.TableName = "Driver" Then str = "Drid"
            If ds.TableName = "Vehicule" Then str = "Vid"

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If IsNumeric(ds.txtSearchName.text) Then
                    params.Add(str, CInt(ds.txtSearchName.text))
                    dt = a.SelectDataTable(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" Then
                    params.Add("name Like ", "%" & ds.txtSearchName.text & "%")

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                    params.Add("ref Like ", "%" & ds.txtSearchName.text & "%")
                    Dim dt2 = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    dt.Merge(dt2, False)

                ElseIf ds.txtSearchName.text = "" Then
                    dt = a.SelectDataTableWithSyntaxe(ds.TableName, "TOP 100", {"*"})
                End If
            End Using
            ds.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetElementsById(ByVal value As Integer, ByRef DS As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                params.Add("Mid", value)
                dt = a.SelectDataTable(DS.TableName, {"*"}, params)
                cid = CInt(dt.Rows(0).Item("cid"))

                Dim vid As Integer = CInt(dt.Rows(0).Item("vid"))
                Dim drid As Integer = CInt(dt.Rows(0).Item("drid"))

                DS.isAdmin = BoolValue(dt, "isAdmin", 0)
                DS.isFactured = BoolValue(dt, "isFactured", 0)
                DS.date = DteValue(dt, "date", 0)
                DS.depart = StrValue(dt, "depart", 0)
                DS.arrive = StrValue(dt, "arrive", 0)
                DS.Bc = StrValue(dt, "bc", 0)
                DS.writer = StrValue(dt, "writer", 0)
                DS.pj = IntValue(dt, "pj", 0)
                DS.km_D = IntValue(dt, "km_D", 0)
                DS.km_A = IntValue(dt, "km_A", 0)

                DS.vid = vid
                DS.drid = drid

                If vid > 0 Then
                    params.Clear()
                    params.Add("Vid", vid)
                    Dim Vdt = a.SelectDataTable("Vehicule", {"*"}, params)
                    If Vdt.Rows.Count > 0 Then

                        DS.vehiculeName = Vdt.Rows(0).Item("name")
                        DS.vehiculeInfo = "[" & StrValue(Vdt, 0, 0) & "]" & vbNewLine & StrValue(Vdt, "ref", 0) & " - " & StrValue(Vdt, "year", 0)
                    End If

                    Vdt = Nothing
                End If

                If drid > 0 Then
                    params.Clear()
                    params.Add("Drid", drid)
                    Dim Vdt = a.SelectDataTable("Driver", {"*"}, params)
                    If Vdt.Rows.Count > 0 Then

                        DS.DriverName = Vdt.Rows(0).Item("name")
                        DS.DriverInfo = "[" & Vdt.Rows(0).Item(0) & "]" & vbNewLine & StrValue(Vdt, "tel", 0)
                    End If
                    Vdt = Nothing
                End If

                params.Clear()
                params.Add("mid", value)
                Dim mdt = a.SelectDataTable("Details_Mission", {"*"}, params)
                If mdt.Rows.Count > 0 Then
                    For i As Integer = 0 To mdt.Rows.Count - 1
                        Dim az As New AddElement

                        az.Key = StrValue(mdt, "name", i)
                        az.Value = StrValue(mdt, "value", i)
                        az.EditMode = True
                        DS.plDBody.Controls.Add(az)
                    Next
                End If

                params.Clear()
                params.Add("id", value)
                Dim cdt = a.SelectDataTable("Details_Charge", {"*"}, params)
                If cdt.Rows.Count > 0 Then
                    For i As Integer = 0 To cdt.Rows.Count - 1
                        Dim az As New AddElement

                        az.Key = StrValue(cdt, "name", i)
                        az.Value = StrValue(cdt, "value", i)
                        az.EditMode = True
                        DS.plC.Controls.Add(az)
                    Next
                End If

                cdt = Nothing
                mdt = Nothing
                DS.Mode = "DETAILS"
            End Using
            DS.Client = New Client(cid, "Client")
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByDate(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            ds.plList.Controls.Clear()

            Dim NF As New SearchArchive
            NF.txtName.AutoCompleteSource = AutoCompleteByName("Client")

            If NF.ShowDialog = DialogResult.OK Then
                Dim dt1 As Date = Date.Parse(NF.dte2.Text).AddDays(1)
                Dim dt2 As Date = Date.Parse(NF.dte1.Text).AddDays(-1)
                If NF.txtName.text <> "" Then
                    If IsNumeric(NF.txtName.text) Then
                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            params.Add("Mid Like ", "%" & NF.txtName.text & "%")
                            dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                        End Using

                    ElseIf NF.txtName.text.Contains("|") Then
                        Dim str As String = NF.txtName.text.Trim
                        str = str.Split(CChar("|"))(1)
                        Dim clid As Integer = CInt(str)

                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            params.Add("cid = ", clid)
                            params.Add("[date] < ", dt1)
                            params.Add("[date] > ", dt2)
                            dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                        End Using
                    End If
                Else
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("[date] < ", dt1)
                        params.Add("[date] > ", dt2)

                        dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    End Using
                End If

                If dt.Rows.Count > 0 Then
                    ds.Clear()
                    ds.Mode = "LIST"

                    ds.DataSource = dt
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AddNewDriver(ByVal ds As ParcList, ByVal clientRow As ClientRow)
        Dim pr As New AddEditDriver
        If pr.ShowDialog = DialogResult.OK Then
            ds.txtSearchName.text = pr.txtName.text
            GetElements(ds)
        End If
    End Sub
    Private Sub AddNewVehicule(ByVal ds As ParcList, ByVal clientRow As ClientRow)
        Dim pr As New AddEditVehicule
        If pr.ShowDialog = DialogResult.OK Then
            ds.txtSearchName.text = pr.txtName.text
            GetElements(ds)
        End If
    End Sub
    Private Sub EditSelectedDriver(ByVal parcList As ParcList, ByVal elm As ClientRow)
        Dim pr As New AddEditDriver
        pr.EditMode = True
        pr.Id = elm.Id
        If pr.ShowDialog = DialogResult.OK Then
            elm.Libele = pr.txtName.text
            elm.lbType.Text = pr.txtCIN.text
            elm.Responsable = pr.txtTel.text()
            elm.Ville = pr.txtAdresse.text
            elm.Tel = pr.txtDate.text
            elm.isEdited = True
        End If
    End Sub
    Private Sub EditSelectedVehicule(ByVal ds As ParcList, ByVal elm As ClientRow)
        Dim pr As New AddEditVehicule
        pr.EditMode = True
        pr.Id = elm.Id
        If pr.ShowDialog = DialogResult.OK Then
            elm.Libele = pr.txtName.text
            elm.lbType.Text = pr.txtMarque.text
            elm.Responsable = pr.txtModel.text()
            elm.Ville = pr.txtKm.text
            elm.Tel = pr.txtCarb.text
            elm.isEdited = True
        End If
    End Sub
    Private Sub DeleteSelectedElement(ByVal ds As ParcList, ByVal elm As ClientRow)
        If MsgBox(MsgDelete & vbNewLine & elm.Name,
                      MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "Supression") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0


            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If ds.TableName = "Mission" Then
                    params.Add("Mid", elm.Id)
                ElseIf ds.TableName = "Vehicule" Then
                    params.Add("Vid", elm.Id)
                ElseIf ds.TableName = "Driver" Then
                    params.Add("Drid", elm.Id)
                End If

                If a.DeleteRecords(ds.TableName, params) > 0 Then
                    ds.RemoveElement(elm)
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AddMissionFiles(ByRef ds As ParcList)
        Dim add As New AddFiles
        add.id = ds.id
        add.tb_F = ds.TableName
        If add.ShowDialog = DialogResult.Cancel Then
            Try
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)

                    params.Add("pj", add.pl.Controls.Count)

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("mid", ds.id)
                    If c.UpdateRecord("Mission", params, where) Then
                        ds.pj = add.pl.Controls.Count
                    End If
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub NewBcRef(ByRef ds As ParcList)
        Dim rf As New ReferenceFacture
        rf.Title = "Bon de Commande"
        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim tableName = ds.TableName
                Dim params As New Dictionary(Of String, Object)

                'Facture
                params.Clear()
                params.Add("bc", rf.Value)
                Dim where As New Dictionary(Of String, Object)
                where.Add("mid", CInt(ds.id))

                If c.UpdateRecord(ds.TableName, params, where) Then
                    ds.Bc = rf.Value
                End If


                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub
    Private Sub ClientChanged(ByRef ds As ParcList)
        Dim CC As New ChooseClient
        CC.tb_C = "Client"

        If CC.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)


                Dim tableName = ds.TableName
                Dim params As New Dictionary(Of String, Object)

                'Facture
                params.Clear()
                params.Add("cid", CC.cid)
                params.Add("clientName", CC.clientName)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", CInt(ds.id))

                If c.UpdateRecord(ds.TableName, params, where) Then
                    Dim cl As New Client(CC.cid, "Client")
                    ds.Client = cl
                End If
                params.Clear()
                where.Clear()

                params = Nothing
                where = Nothing
            End Using
        End If

    End Sub
    Private Sub DriverChanged(ByRef ds As ParcList)
        Dim rf As New ReferenceFacture
        rf.Title = "Chauffeur"
        rf.Value = ds.DriverName

        Dim drid As Integer
        Dim nm As String
        Dim info As String


        rf.TxtBox1.AutoCompleteSource = AutoCompleteByName("Driver")

        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim tableName = ds.TableName
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", rf.Value)
                Dim Vdt = c.SelectDataTable("Driver", {"*"}, params)
                If Vdt.Rows.Count > 0 Then
                    drid = Vdt.Rows(0).Item(0)
                    nm = Vdt.Rows(0).Item("name")
                    info = "[" & Vdt.Rows(0).Item(0) & "]" & vbNewLine & StrValue(Vdt, "tel", 0)
                Else
                    MsgBox("Nom de Cheuffeur est incorrect..")
                    Exit Sub
                End If

                params.Clear()
                params.Add("drid", Vdt.Rows(0).Item(0))
                Dim where As New Dictionary(Of String, Object)
                where.Add("mid", CInt(ds.id))

                If c.UpdateRecord(ds.TableName, params, where) Then
                    ds.drid = drid
                    ds.DriverName = nm
                    ds.DriverInfo = info
                End If

                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub
    Private Sub VehiculeChanged(ByRef ds As ParcList)
        Dim rf As New ReferenceFacture
        rf.Title = "Vehicule"
        rf.Value = ds.vehiculeName

        Dim vid As Integer
        Dim nm As String
        Dim info As String


        rf.TxtBox1.AutoCompleteSource = AutoCompleteByName("Vehicule")

        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim tableName = ds.TableName
                Dim params As New Dictionary(Of String, Object)
                params.Add("name", rf.Value)
                Dim Vdt = c.SelectDataTable("Vehicule", {"*"}, params)
                If Vdt.Rows.Count > 0 Then
                    vid = Vdt.Rows(0).Item(0)
                    nm = Vdt.Rows(0).Item("name")
                    info = "[" & StrValue(Vdt, 0, 0) & "]" & vbNewLine & StrValue(Vdt, "ref", 0) & " - " & StrValue(Vdt, "year", 0)
                Else
                    MsgBox("Nom de Vehicule est incorrect..")
                    Exit Sub
                End If

                params.Clear()
                params.Add("vid", Vdt.Rows(0).Item(0))
                Dim where As New Dictionary(Of String, Object)
                where.Add("mid", CInt(ds.id))

                If c.UpdateRecord(ds.TableName, params, where) Then
                    ds.vid = vid
                    ds.vehiculeName = nm
                    ds.vehiculeInfo = info
                End If

                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub

    Private Sub AddNewMissin(ByVal ds As ParcList)
        Try

            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.AutoCompleteSource = AutoCompleteByName("Client")
            NF.tb_C = "Client"
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

                Dim mid As Integer = 0
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    params.Add("cid", cid)
                    params.Add("clientName", cn)
                    params.Add("date", CDate(NF.TxtDate.Text))
                    params.Add("depart", "")
                    params.Add("arrive", "")
                    params.Add("bc", "")
                    params.Add("vid", 0)
                    params.Add("drid", 0)
                    params.Add("writer", CStr(Form1.adminName))
                    params.Add("isAdmin", False)
                    params.Add("isPayed", False)
                    params.Add("isFactured", False)
                    params.Add("total", 0)
                    params.Add("avance", 0)
                    params.Add("pj", 0)

                    mid = c.InsertRecord("Mission", params, True)
                End Using

                If mid > 0 Then
                    ds.Mode = "DETAILS"
                    ds.id = mid
                    ds.Client = New Client(cid, "Client")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub GetElementInfos(ByVal ds As ParcList, ByVal id As Integer)
        'Throw New NotImplementedException
    End Sub

    Private Sub SaveChanges(ByVal ds As ParcList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim isPayed As Boolean = ds.isPayed

            Dim tableName = ds.TableName
            Dim dte As Date = ds.date
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()
            params.Add("total", ds.Total)
            params.Add("avance", ds.Avance)
            params.Add("depart", ds.depart)
            params.Add("km_D", ds.km_D)
            params.Add("km_A", ds.km_A)
            params.Add("arrive", ds.arrive)

            Dim where As New Dictionary(Of String, Object)

            where.Add("mid", ds.id)

            c.UpdateRecord(tableName, params, where)
            params.Clear()
            where.Clear()

            params = Nothing
            where = Nothing
        End Using
    End Sub

    Private Sub MissionFactured(ByRef ds As ParcList)
        Dim dte As String = Now.Date.ToString("dd-MM-yyyy")
        Try
            Dim fid As Integer = 0
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("isAdmin", True)
                params.Add("isFactured", True)
                Dim where As New Dictionary(Of String, Object)
                where.Add("Mid", ds.id)

                c.UpdateRecord("Mission", params, where)

                params.Clear()
                where.Clear()


                Dim cid As String = ds.cid
                Dim clientname As String = ds.ClientName

                params.Add("cid", cid)
                params.Add("name", clientname)
                params.Add("total", ds.Total)
                params.Add("avance", ds.Avance)
                params.Add("remise", 0)
                params.Add("tva", 0)
                params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
                params.Add("writer", (Form1.adminName))
                params.Add("isAdmin", "CREATION")
                params.Add("isPayed", False)
                params.Add("modePayement", "-")
                params.Add("droitTimbre", 0)
                params.Add("pj", 0)

                fid = c.InsertRecord("Sell_Facture", params, True)

                Dim data = ds.DataSource

                If IsNothing(Data) Then Exit Sub
                If Data.Rows.Count > 0 Then

                    For i As Integer = 0 To Data.Rows.Count - 1

                        params.Add("fctid", fid)
                        params.Add("name", Data.Rows(i).Item("name"))
                        params.Add("bprice", data.Rows(i).Item("price"))
                        params.Add("price", Data.Rows(i).Item("price"))
                        params.Add("remise", 0)
                        params.Add("qte", 1)
                        params.Add("tva", 0)
                        params.Add("arid", data.Rows(i).Item("id"))
                        params.Add("depot", 0)
                        params.Add("ref", data.Rows(i).Item("name"))
                        params.Add("cid", 0)

                        c.InsertRecord("Details_Sell_Facture", params)
                        params.Clear()
                    Next
                End If

                where.Clear()
                If ds.Avance > 0 Then
                    params.Add("Sell_Facture", fid)
                    where.Add("Mission", CInt(ds.id))
                    c.UpdateRecord("Client_Payement", params, where)
                    params.Clear()
                    where.Clear()
                End If

            End Using

            If fid > 0 Then
                Form1.Button6_Click(Form1.btVente, Nothing)
                Dim datalist As DataList = Form1.plBody.Controls(0)

                'ds.Clear()
                datalist.Mode = "DETAILS"
                datalist.Id = fid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub MissionSolde(ByRef parcList As ParcList)
        Throw New NotImplementedException
    End Sub

    Private Sub MissionDuplicate(ByRef parcList As ParcList)
        Throw New NotImplementedException
    End Sub

    Private Sub DeleteMission(ByVal _id As Integer, ByRef parcList As ParcList)
        Throw New NotImplementedException
    End Sub

    Private Sub SavePdf(ByRef parcList As ParcList)
        Throw New NotImplementedException
    End Sub

    Private Sub PramsPrint(ByVal parcList As ParcList)
        Throw New NotImplementedException
    End Sub

    Private Sub PrintMission(ByVal parcList As ParcList)
        Throw New NotImplementedException
    End Sub

    Private Sub GetClientDetails(ByVal _cid As Integer)
        Throw New NotImplementedException
    End Sub

    Private Sub GetDeiverDetails(ByVal _drid As Integer)
        Throw New NotImplementedException
    End Sub

    Private Sub GetVehiculeDetails(ByVal _vid As Integer)
        Throw New NotImplementedException
    End Sub




End Class
