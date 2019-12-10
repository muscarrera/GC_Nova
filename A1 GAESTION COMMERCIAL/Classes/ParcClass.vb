Imports System.Linq

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
            AddHandler ds.addNewCharge, AddressOf AddNewCharge

            AddHandler ds.EditNewCharge, AddressOf EditNewCharge

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
            AddHandler ds.PrintListOfParc, AddressOf PrintListOfParc
            AddHandler ds.GetClientDetails, AddressOf GetClientDetails
            AddHandler ds.GetDeiverDetails, AddressOf GetDeiverDetails
            AddHandler ds.GetVehiculeDetails, AddressOf GetVehiculeDetails
            AddHandler ds.AddNewChargeMission, AddressOf AddNewChargeMission
            AddHandler ds.AddNewDetailsMission, AddressOf AddNewDetailsMission

            ds.AutoCompleteSourceCharges = AutoCompleteByMission("Details_Charge")
            ds.AutoCompleteSourceDetails = AutoCompleteByMission("Details_Mission")

            Form1.plBody.Controls.Add(ds)
        End Using

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
    Private Sub AddNewCharge(ByVal ds As ParcList)
        Try

            Dim NF As New AddEditCharge
            NF.id = 0

            If NF.ShowDialog = DialogResult.OK Then
            End If

            If NF.id > 0 Then
                ds.txtSearchName.text = NF.id
                GetCharges(ds)
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

    Private Sub GetElements(ByRef ds As ParcList)
        Try

            If ds.TableName = "Driver" Or ds.TableName = "Vehicule" Then
                GetVehiculeOrDriver(ds)
            ElseIf ds.TableName = "Mission" Then
                GetMission(ds)
            ElseIf ds.TableName = "Details_Charge" Then
                GetCharges(ds)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetVehiculeOrDriver(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim str As String = "Vid"
            If ds.TableName = "Driver" Then str = "Drid"

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If IsNumeric(ds.txtSearchName.text) Then
                    params.Add(str, CInt(ds.txtSearchName.text))
                    dt = a.SelectDataTable(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" And ds.txtSearchName.text <> "*" Then

                    params.Add("name Like ", ds.txtSearchName.text & "%")

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                    params.Add("ref Like ", "%" & ds.txtSearchName.text & "%")
                    Dim dt2 = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    dt.Merge(dt2, False)

                ElseIf ds.txtSearchName.text = "*" Then
                    dt = a.SelectDataTable(ds.TableName, {"*"})
                ElseIf ds.txtSearchName.text = "" Then
                    dt = a.SelectDataTableWithSyntaxe(ds.TableName, "TOP " & Form1.numberOfItems, {"*"})
                End If
            End Using
            ds.DataSource = dt

            params = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetMission(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Dim dt As DataTable = Nothing
            Dim str As String = "Mid"
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If IsNumeric(ds.txtSearchName.text) Then
                    params.Add(str, CInt(ds.txtSearchName.text))
                    dt = a.SelectDataTable(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" And ds.txtSearchName.text <> "*" Then
                    Dim txt = ds.txtSearchName.text.Split(";")
                    For i As Integer = 0 To txt.Length - 1

                        If txt(i).ToUpper.StartsWith("DP") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim
                            params.Add("depart Like ", V & "%")

                        ElseIf txt(i).ToUpper.StartsWith("DS") Then
                            Dim V = txt(i).Remove(0, 2).Trim
                            params.Add("arrive Like ", V & "%")

                        ElseIf txt(i).ToUpper.StartsWith("CH") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim

                            If IsNumeric(V) Then
                                params.Add("drid = ", V)
                            Else
                                where.Clear()
                                where.Add("name Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Driver", {"*"}, params)
                                If dt.Rows.Count > 0 Then
                                    params.Add("drid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If
                        ElseIf txt(i).ToUpper.StartsWith("VH") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim

                            If IsNumeric(V) Then
                                params.Add("vid = ", V)
                            Else
                                where.Clear()
                                where.Add("name Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Vehicule", {"*"}, params)
                                If dt.Rows.Count > 0 Then
                                    params.Add("vid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If
                        ElseIf txt(i).ToUpper.StartsWith("CLN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            If IsNumeric(V) Then
                                params.Add("cid = ", V)
                            Else
                                params.Add("clientName Like ", "%" & V & "%")
                            End If
                        ElseIf txt(i).ToUpper.StartsWith("EX") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim
                            params.Add("ex Like ", "%" & V & "%")
                        ElseIf txt(i).ToUpper.StartsWith("EDT") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            params.Add("writer Like ", "%" & V & "%")
                        ElseIf txt(i).ToUpper.StartsWith("RG") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim
                            Dim isPayed As Boolean = True
                            If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
                                isPayed = False
                            End If
                            params.Add("isPayed = ", isPayed)
                        ElseIf txt(i).ToUpper.StartsWith("ST") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim
                            Dim isAdmin As Boolean = False
                            If V.ToUpper = "F" Or V.ToUpper.StartsWith("FIN") Or V.ToUpper.StartsWith("TER") Then
                                isAdmin = True
                            End If
                            params.Add("isAdmin = ", isAdmin)
                        ElseIf txt(i).ToUpper.StartsWith("FCT") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            Dim isF As Boolean = True
                            If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
                                isF = False
                            End If
                            params.Add("isFactured = ", isF)
                        Else
                            Try
                                params.Add("clientName Like ", "%" & txt(i).Trim & "%")
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                ElseIf ds.txtSearchName.text = "*" Then
                    dt = a.SelectDataTable(ds.TableName, {"*"})
                ElseIf ds.txtSearchName.text = "" Then

                    dt = a.SelectDataTableWithSyntaxe(ds.TableName, "TOP " & Form1.numberOfItems, {"*"})
                End If
            End Using
            ds.DataSource = dt
            where = Nothing
            params = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetCharges(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Dim dt As DataTable = Nothing
            Dim str As String = "id"
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If IsNumeric(ds.txtSearchName.text) Then
                    params.Add(str, CInt(ds.txtSearchName.text))
                    dt = a.SelectDataTable(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" And ds.txtSearchName.text <> "*" Then
                    Dim txt = ds.txtSearchName.text.Split(";")
                    For i As Integer = 0 To txt.Length - 1

                        If txt(i).Trim.ToUpper.StartsWith("MS") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim

                            If IsNumeric(V) Then
                                params.Add("mid = ", V)
                            Else
                                where.Clear()
                                where.Add("name Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Mission", {"*"}, params)
                                If dt.Rows.Count > 0 Then
                                    params.Add("mid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If

                        ElseIf txt(i).Trim.ToUpper.StartsWith("VH") Then
                            Dim V = txt(i).Remove(0, 2).Trim

                            If IsNumeric(V) Then
                                params.Add("vid = ", V)
                            Else
                                where.Clear()
                                where.Add("name Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Vehicule", {"*"}, params)
                                If dt.Rows.Count > 0 Then
                                    params.Add("vid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If
                        ElseIf txt(i).Trim.ToUpper.StartsWith("CH") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim

                            If IsNumeric(V) Then
                                params.Add("drid = ", V)
                            Else
                                where.Clear()
                                where.Add("name Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Driver", {"*"}, params)
                                If dt.Rows.Count > 0 Then
                                    params.Add("drid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If
                        ElseIf txt(i).Trim.ToUpper.StartsWith("CLN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            If IsNumeric(V) Then
                                params.Add("cid = ", V)
                            Else
                                params.Add("name Like ", "%" & V & "%")
                            End If
                        ElseIf txt(i).Trim.ToUpper.StartsWith("EX") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim
                            params.Add("ex Like ", "%" & V & "%")
                        ElseIf txt(i).Trim.ToUpper.StartsWith("EDT") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            params.Add("writer Like ", "%" & V & "%")
                        Else
                            Try
                                params.Add("name Like ", "%" & txt(i).Trim & "%")
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                ElseIf ds.txtSearchName.text = "*" Then
                    dt = a.SelectDataTable(ds.TableName, {"*"})
                ElseIf ds.txtSearchName.text = "" Then
                    dt = a.SelectDataTableWithSyntaxe(ds.TableName, "TOP " & Form1.numberOfItems, {"*"})
                End If
            End Using
            ds.DataSource = dt
            where = Nothing
            params = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetElementsById(ByVal value As Integer, ByRef DS As ParcList)
        Try
            DS.plDBody.Controls.Clear()
            DS.plCBody.Controls.Clear()
            DS.ClientName = ""
            DS.cid = 0
            DS.lbInfo.Text = ""
            DS.vid = 0
            DS.vehiculeName = ""
            DS.vehiculeInfo = ""
            DS.drid = 0
            DS.DriverInfo = ""
            DS.DriverName = ""

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
                DS.Avance = DblValue(dt, "avance", 0)

                DS.vid = vid
                DS.drid = drid

                If vid > 0 Then
                    params.Clear()
                    params.Add("Vid", vid)
                    Dim Vdt = a.SelectDataTable("Vehicule", {"*"}, params)
                    If Vdt.Rows.Count > 0 Then

                        DS.vehiculeName = Vdt.Rows(0).Item("name") & "[" & StrValue(Vdt, 0, 0) & "]"
                        DS.vehiculeInfo = StrValue(Vdt, "ref", 0) & " - " & StrValue(Vdt, "year", 0)
                    End If

                    Vdt = Nothing
                End If

                If drid > 0 Then
                    params.Clear()
                    params.Add("Drid", drid)
                    Dim Vdt = a.SelectDataTable("Driver", {"*"}, params)
                    If Vdt.Rows.Count > 0 Then

                        DS.DriverName = Vdt.Rows(0).Item("name")
                        DS.DriverInfo = "[" & Vdt.Rows(0).Item(0) & "]" & StrValue(Vdt, "tel", 0)
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
                        az.id = IntValue(mdt, "id", i)
                        az.EditMode = True
                        az.Dock = DockStyle.Top

                        AddHandler az.Clear, AddressOf DeleteDetailsElement
                        DS.plDBody.Controls.Add(az)
                    Next
                End If

                params.Clear()
                params.Add("mid", value)
                Dim cdt = a.SelectDataTable("Details_Charge", {"*"}, params)
                If cdt.Rows.Count > 0 Then
                    For i As Integer = 0 To cdt.Rows.Count - 1
                        Dim az As New AddElement

                        az.Key = StrValue(cdt, "name", i)
                        az.Value = StrValue(cdt, "value", i)
                        az.id = IntValue(mdt, "id", i)
                        az.Dock = DockStyle.Top
                        az.EditMode = True
                        AddHandler az.Clear, AddressOf DeleteChargeMission

                        DS.plCBody.Controls.Add(az)
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

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    If NF.txtName.text <> "" Then
                        ''''''''''''''''''''''''''''
                        Dim where As New Dictionary(Of String, Object)
                        Dim txt = NF.txtName.text.Split(";")


                        For i As Integer = 0 To txt.Length - 1

                            If txt(i).Trim.ToUpper.StartsWith("DP") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim
                                params.Add("depart Like ", V & "%")

                            ElseIf txt(i).Trim.ToUpper.StartsWith("DS") Then
                                Dim V = txt(i).Remove(0, 2).Trim
                                params.Add("arrive Like ", V & "%")

                            ElseIf txt(i).Trim.ToUpper.StartsWith("CH") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim

                                If IsNumeric(V) Then
                                    params.Add("drid = ", V)
                                Else
                                    where.Clear()
                                    where.Add("name Like ", V & "%")

                                    dt = a.SelectDataTableSymbols("Driver", {"*"}, params)
                                    If dt.Rows.Count > 0 Then
                                        params.Add("drid = ", CInt(dt.Rows(0).Item(0)))
                                    End If
                                End If

                            ElseIf txt(i).Trim.ToUpper.StartsWith("VH") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim
                                If IsNumeric(V) Then
                                    params.Add("vid = ", V)
                                Else
                                    where.Clear()
                                    where.Add("name Like ", V & "%")

                                    dt = a.SelectDataTableSymbols("Vehicule", {"*"}, params)
                                    If dt.Rows.Count > 0 Then
                                        params.Add("vid = ", CInt(dt.Rows(0).Item(0)))
                                    End If
                                End If

                            ElseIf txt(i).Trim.ToUpper.StartsWith("CLN") Then
                                Dim V = txt(i).Trim.Remove(0, 3).Trim
                                If IsNumeric(V) Then
                                    params.Add("cid = ", V)
                                Else
                                    params.Add("clientName Like ", "%" & V & "%")
                                End If

                            ElseIf txt(i).ToUpper.StartsWith("EX") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim
                                params.Add("ex Like ", "%" & V & "%")

                            ElseIf txt(i).Trim.ToUpper.StartsWith("EDT") Then
                                Dim V = txt(i).Trim.Remove(0, 3).Trim
                                params.Add("writer Like ", "%" & V & "%")

                            ElseIf txt(i).Trim.ToUpper.StartsWith("RG") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim
                                Dim isPayed As Boolean = True
                                If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
                                    isPayed = False
                                End If
                                params.Add("isPayed = ", isPayed)

                            ElseIf txt(i).Trim.ToUpper.StartsWith("ST") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim
                                Dim isAdmin As Boolean = False
                                If V.ToUpper = "F" Or V.ToUpper.StartsWith("FIN") Or V.ToUpper.StartsWith("TER") Then
                                    isAdmin = True
                                End If
                                params.Add("isAdmin = ", isAdmin)

                            ElseIf txt(i).Trim.ToUpper.StartsWith("FCT") Then
                                Dim V = txt(i).Trim.Remove(0, 3).Trim
                                Dim isF As Boolean = True
                                If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
                                    isF = False
                                End If
                                params.Add("isFactured = ", isF)

                            ElseIf txt(i).Trim.ToUpper.StartsWith("MS") Then
                                Dim V = txt(i).Trim.Remove(0, 2).Trim
                                If IsNumeric(V) Then
                                    params.Add("mid = ", V)
                                Else
                                    where.Clear()
                                    where.Add("name Like ", V & "%")

                                    dt = a.SelectDataTableSymbols("Mission", {"*"}, params)
                                    If dt.Rows.Count > 0 Then
                                        params.Add("mid = ", CInt(dt.Rows(0).Item(0)))
                                    End If
                                End If
                            Else
                                Try
                                    If ds.TableName = "Mission" Then
                                        params.Add("clientName Like ", "%" & txt(i).Trim & "%")
                                    Else
                                        params.Add("name Like ", "%" & txt(i).Trim & "%")
                                    End If

                                Catch ex As Exception
                                End Try
                            End If
                        Next
                    End If




                    params.Add("[date] < ", dt1)
                    params.Add("[date] > ", dt2)

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                End Using

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
                params.Add("cid", CInt(CC.cid))
                params.Add("clientName", CC.clientName)
                Dim where As New Dictionary(Of String, Object)
                where.Add("Mid", CInt(ds.id))

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
                params.Add("name", rf.Value.Split("|")(0))
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
                params.Add("name", rf.Value.Split("|")(0))
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

    Private Sub SaveChanges(ByRef ds As ParcList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim isPayed As Boolean = ds.isPayed

            Dim tableName = ds.TableName
            Dim dte As Date = ds.date
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()

            If ds.km_D < ds.km_A Then
                params.Add("isAdmin", True)
            Else
                params.Add("isAdmin", False)
            End If

            If ds.Total < ds.Avance Then
                params.Add("isPayed", True)
            Else
                params.Add("isPayed", False)
            End If

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

            params.Add("Vid", ds.vid)
            Dim old_km = c.SelectByScalar("Vehicule", "km", params)

            Dim new_km = ds.km_D
            If ds.km_D < ds.km_A Then new_km = ds.km_A
            If new_km > old_km Then
                params.Clear()
                where.Clear()

                params.Add("km", new_km)
                where.Add("Vid", ds.vid)
                c.UpdateRecord("Vehicule", params, where)
            End If

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
                'params.Add("isAdmin", True)
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
                params.Clear()
                'Depart & Destination
                Dim n As String = "Depart: " & ds.depart & " - Dest: " & ds.arrive
                params.Add("fctid", fid)
                params.Add("name", n)
                params.Add("bprice", 0)
                params.Add("price", 0)
                params.Add("remise", 0)
                params.Add("qte", 0)
                params.Add("tva", 0)
                params.Add("arid", 0)
                params.Add("depot", 0)
                params.Add("ref", " ")
                params.Add("cid", 0)

                c.InsertRecord("Details_Sell_Facture", params)
                params.Clear()
                'Vehicule
                n = "Vehicule : " & ds.vehiculeName & " " & ds.vehiculeInfo
                params.Add("fctid", fid)
                params.Add("name", n)
                params.Add("bprice", 0)
                params.Add("price", 0)
                params.Add("remise", 0)
                params.Add("qte", 0)
                params.Add("tva", 0)
                params.Add("arid", 0)
                params.Add("depot", 0)
                params.Add("ref", " ")
                params.Add("cid", 0)

                c.InsertRecord("Details_Sell_Facture", params)
                params.Clear()
                For Each el As AddElement In ds.plDBody.Controls

                    params.Add("fctid", fid)
                    params.Add("name", el.Key)
                    params.Add("bprice", el.Value)
                    params.Add("price", el.Value)
                    params.Add("remise", 0)
                    params.Add("qte", 1)
                    params.Add("tva", 0)
                    params.Add("arid", 0)
                    params.Add("depot", 0)
                    params.Add("ref", el.Name)
                    params.Add("cid", 0)

                    c.InsertRecord("Details_Sell_Facture", params)
                    params.Clear()
                Next


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
                Dim str As String = "Opération terminé avec succès"
                str &= vbNewLine & "Facture N° " & Form1.Exercice & "/000" & fid
                str &= vbNewLine & "Total : " & ds.Total

                MsgBox(str, MsgBoxStyle.Information, "Facturation")


                'Form1.Button6_Click(Form1.btVente, Nothing)
                'Dim datalist As DataList = Form1.plBody.Controls(0)
                'datalist.Button1_Click_1(Nothing, Nothing)
                ''ds.Clear()
                'datalist.Mode = "DETAILS"
                'datalist.Id = fid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub MissionDuplicate(ByRef ds As ParcList)
        Dim mid As Integer = 0

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("cid", ds.cid)
            params.Add("clientName", ds.ClientName)
            params.Add("date", Now.Date)
            params.Add("depart", ds.depart)
            params.Add("arrive", ds.arrive)
            params.Add("bc", "")
            params.Add("vid", ds.vid)
            params.Add("drid", ds.drid)
            params.Add("writer", CStr(Form1.adminName))
            params.Add("isAdmin", False)
            params.Add("isPayed", False)
            params.Add("isFactured", False)
            params.Add("total", 0)
            params.Add("avance", 0)
            params.Add("pj", 0)

            mid = c.InsertRecord("Mission", params, True)

            For Each el As AddElement In ds.plDBody.Controls

                params.Add("name", el.Key)
                params.Add("value", el.Value)
                params.Add("mid", mid)
                params.Add("writer", Form1.adminName)

                c.InsertRecord("Details_Mission", params)
                params.Clear()
            Next

            For Each el As AddElement In ds.plCBody.Controls

                params.Add("name", el.Key)
                params.Add("value", el.Value)
                params.Add("mid", mid)
                params.Add("writer", Form1.adminName)

                c.InsertRecord("Details_Mission", params)
                params.Clear()
            Next

            If mid > 0 Then
                ds.Mode = "DETAILS"
                ds.id = mid
                ds.Client = New Client(ds.cid, "Client")
            End If
        End Using
    End Sub
    Private Sub DeleteMission(ByVal _id As Integer, ByRef ds As ParcList)
        Dim mid As Integer = _id

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)

            params.Add("Mid", mid)

            If c.DeleteRecords("Mission", params) Then
                c.DeleteRecords("Details_Mission", params)
                c.DeleteRecords("Details_Charge", params)

                ds.TableName = "Mission"
                ds.Mode = "LIST"
            End If

        End Using
    End Sub

    Private Sub SavePdf(ByRef parcList As ParcList)


        Form1.Facture_Title = "Bon de Transport"

        Form1.printOnPaper = False

        Form1.PrintDocMission.PrinterSettings.PrinterName = Form1.printer_Pdf
        Form1.PrintDocMission.Print()

    End Sub
    Private Sub PramsPrint(ByVal parcList As ParcList)
        Dim pr As New ImpressionParams
        pr.btProformat.Visible = False
        Form1.Facture_Title = "Bon de Transport"
        If pr.ShowDialog = DialogResult.OK Then

        End If
        Form1.printWithDate = Not pr.cbDate.Checked
        Form1.printWithPrice = Not pr.cbPrix.Checked


        Form1.PrintDocMission.PrinterSettings.PrinterName = Form1.printer_Bon

        '''''''''''''' stel a lot of work
        If pr.isProformat Then

        End If

        Form1.printOnPaper = True
        Form1.PrintDocMission.Print()
    End Sub
    Private Sub PrintMission(ByVal parcList As ParcList)
        Form1.Facture_Title = "Bon de Transport"

        Form1.printOnPaper = True
        Form1.Facture_Title = "Bon de Transport"
        Form1.PrintDocMission.PrinterSettings.PrinterName = Form1.printer_Bon
        Form1.PrintDocMission.Print()
    End Sub
    Private Sub PrintListOfParc(ByVal ds As ParcList)
        Form1.Facture_Title = ""
        If ds.TableName = "Mission" Then
            Form1.Facture_Title = "Bons de Transport"
        ElseIf ds.TableName = "Details_Charge" Then
            Form1.Facture_Title = "Listes des Charges"
        ElseIf ds.TableName = "Driver" Then
            Form1.Facture_Title = "Chauffeurs"
        ElseIf ds.TableName = "Vehicule" Then
            Form1.Facture_Title = "Listes Vehicule"
        End If


        Form1.printOnPaper = True

        Form1.PrintDocMission.PrinterSettings.PrinterName = Form1.printer_Bon
        Form1.PrintDocMission.Print()
    End Sub
    Private Sub GetClientDetails(ByVal _cid As Integer)
        Dim fl As New ClientDetails
        fl.Table = "Client"
        fl.id = _cid
        If fl.ShowDialog = DialogResult.OK Then

        End If
    End Sub
    Private Sub AddNewDetailsMission(ByVal k As String, ByVal v As Double, ByVal ds As ParcList)
        Try
            Dim d_Id As Integer = 0
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("name", k)
                params.Add("value", v)
                params.Add("mid", ds.id)
                params.Add("writer", Form1.adminName)

                d_Id = c.InsertRecord("Details_Mission", params, True)
                If d_Id > 0 Then
                    Dim R As New AddElement

                    R.Key = k
                    R.Value = v
                    R.id = d_Id
                    R.EditMode = True
                    R.Dock = DockStyle.Top

                    AddHandler R.Clear, AddressOf DeleteDetailsElement
                    ds.plDBody.Controls.Add(R)
                    ds.txtDValue.text = ""
                    ds.txtDKey.text = ""
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddNewChargeMission(ByVal k As String, ByVal v As Double, ByVal ds As ParcList)
        Try
            Dim d_Id As Integer = 0
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("name", k)
                params.Add("value", v)
                params.Add("mid", ds.id)
                params.Add("vid", ds.vid)
                params.Add("drid", ds.drid)
                params.Add("writer", Form1.adminName)


                d_Id = c.InsertRecord("Details_Charge", params, True)
                If d_Id > 0 Then
                    Dim R As New AddElement

                    R.Key = k
                    R.Value = v
                    R.id = d_Id
                    R.EditMode = True
                    R.Dock = DockStyle.Top
                    AddHandler R.Clear, AddressOf DeleteChargeMission
                    ds.plCBody.Controls.Add(R)
                    ds.txtCValue.text = ""
                    ds.txtCKey.text = ""
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DeleteDetailsElement(ByVal elm As AddElement)
        Try

            Dim ds As ParcList = Form1.plBody.Controls(0)

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("id", elm.id)
                If c.DeleteRecords("Details_Mission", params) Then
                    ds.plDBody.Controls.Remove(elm)
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DeleteChargeMission(ByVal elm As AddElement)
        Try
            Dim ds As ParcList = Form1.plBody.Controls(0)

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("id", elm.id)
                If c.DeleteRecords("Details_Charge", params) Then
                    ds.plCBody.Controls.Remove(elm)
                End If
            End Using
        Catch ex As Exception
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
    Private Sub MissionSolde(ByRef parcList As ParcList)
        'Throw New NotImplementedException
        Dim PP As New PayementForm

        PP.ClientName = parcList.ClientName
        PP.cid = parcList.Client.cid
        PP.FactureTable = parcList.TableName
        PP.payementTable = "Client_Payement"
        PP.Avance = parcList.Avance
        PP.Total = parcList.Total
        PP.Id = parcList.id
        If PP.ShowDialog = DialogResult.OK Then

        End If
        parcList.Avance = PP.Avance
        'fill rows
    End Sub
    Private Sub GetDeiverDetails(ByVal _drid As Integer)
        'Throw New NotImplementedException
    End Sub

    Private Sub GetVehiculeDetails(ByVal _vid As Integer)
        'Throw New NotImplementedException
    End Sub

    Private Sub EditNewCharge(ByVal ds As ParcList)
        Dim pr As New AddEditCharge
        pr.id = ds.SelectedItem.Id
        pr.getData()

        If pr.ShowDialog = DialogResult.OK Then
        End If
        ds.SelectedItem.Libele = pr.txtDKey.text
        ds.SelectedItem.Responsable = pr.txtDValue.text
        ds.SelectedItem.Ville = pr.Drid
        ds.SelectedItem.Tel = pr.Vid

    End Sub










End Class
