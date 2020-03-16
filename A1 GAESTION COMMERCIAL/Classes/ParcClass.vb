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
            AddHandler ds.GetElementsById, AddressOf GetMissionById

            AddHandler ds.EditSelectedVehicule, AddressOf EditSelectedVehicule
            AddHandler ds.EditSelectedDriver, AddressOf EditSelectedDriver
            AddHandler ds.DeleteSelectedElement, AddressOf DeleteSelectedElement
            AddHandler ds.GetElementInfos, AddressOf GetElementInfos

            AddHandler ds.SearchByDate, AddressOf SearchByDate
            AddHandler ds.ReleveClientByDate, AddressOf ReleveClientByDate
            AddHandler ds.AddFiles, AddressOf AddMissionFiles
            AddHandler ds.NewBcRef, AddressOf NewBcRef
            AddHandler ds.ClientChanged, AddressOf ClientChanged
            AddHandler ds.DriverChanged, AddressOf DriverChanged
            AddHandler ds.VehiculeChanged, AddressOf VehiculeChanged

            AddHandler ds.SaveMissionChanges, AddressOf SaveMissionChanges
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
            AddHandler ds.GetListOfDomain, AddressOf GetListOfDomain

            AddHandler ds.addNewTransport, AddressOf AddNewTransport
            AddHandler ds.GetTransportById, AddressOf GetTransportById
            AddHandler ds.SaveTransportChanges, AddressOf SaveTransportChanges
            AddHandler ds.transportFactured, AddressOf TransportFactured
            AddHandler ds.DeleteTransport, AddressOf DeleteTransport
            AddHandler ds.GetPriceOfDetails, AddressOf GetPriceOfDetails
            AddHandler ds.EditMissionDate, AddressOf EditMissionDate
            AddHandler ds.EditTransportDate, AddressOf EditTransportDate
            AddHandler ds.EditSelectedCharge, AddressOf EditSelectedCharge


            ds.txtCKey.AutoCompleteSource = AutoCompleteFromWords("MISSION", "CHARGE") 'AutoCompleteByMission("Details_Charge")
            ds.txtDKey.AutoCompleteSource = AutoCompleteFromWords("MISSION", "DETAILS") ' AutoCompleteByMission("Details_Mission")
            ds.txtdepart.AutoCompleteSource = AutoCompleteFromWords("DEPART", "DEPART")
            ds.txtdest.AutoCompleteSource = AutoCompleteFromWords("ARRIVE", "ARRIVE")


            ds.dt_Driver = a.SelectDataTable("Driver", {"*"})
            ds.dt_Vehicule = a.SelectDataTable("Vehicule", {"*"})



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
                    cn = NF.cName
                    cid = NF.cid
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
                    params.Add("domain", "")
                    params.Add("bc", "")
                    params.Add("vid", 0)
                    params.Add("drid", 0)
                    params.Add("writer", CStr(Form1.adminName))
                    params.Add("isAdmin", False)
                    params.Add("isPayed", False)
                    params.Add("isFactured", False)
                    params.Add("total", 0)
                    params.Add("avance", 0)
                    params.Add("Bon_Transport", 0)
                    params.Add("pj", 0)
                    params.Add("ex", Form1.Exercice)

                    mid = c.InsertRecord("Mission", params, True)
                End Using

                If mid > 0 Then
                    ds.Mode = "DETAILS"
                    ds.id_M = mid
                    ds.Client = New Client(cid, "Client")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub AddNewTransport(ByRef ds As ParcList)
        Try

            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.AutoCompleteSource = AutoCompleteByName("Client")
            NF.tb_C = "Client"
            NF.TxtDate.Text = Now.Date.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then
                Dim mid As Integer = 0
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim cid = NF.cid
                    Dim cname = NF.cName
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    params.Add("cid", cid)
                    params.Add("Bon_Transport", 0)
                    Dim dmn As String = "-"
                    Try
                        Dim m_dt = a.SelectDataTable("Mission", {"*"}, params)
                        If Not IsNothing(m_dt) Then
                            If m_dt.Rows.Count > 0 Then
                                For i As Integer = 0 To m_dt.Rows.Count - 1
                                    dmn = StrValue(m_dt, "domain", i)
                                    If dmn.Length > 1 Then Exit For
                                Next
                            Else
                                MsgBox("Toute les mission de ce client sont bien enregistré dans les bons de transport", MsgBoxStyle.Information, "CMC Gestion")
                                Exit Sub
                            End If
                        Else
                            MsgBox("Toute les mission de ce client sont bien enregistré dans les bons de transport", MsgBoxStyle.Information, "CMC Gestion")
                            Exit Sub
                        End If

                    Catch ex As Exception

                    End Try


                    '''''''''''''start
                    params.Clear()
                    params.Add("cid", cid)
                    params.Add("name", cname)
                    params.Add("date", NF.dte)
                    params.Add("delai", dmn)
                    params.Add("ex", Form1.Exercice)
                    params.Add("total", 0)
                    params.Add("avance", 0)
                    params.Add("isPayed", False)
                    params.Add("isFactured", False)
                    params.Add("writer", Form1.adminName)

                    mid = a.InsertRecord("Bon_Transport", params, True)
                    If mid = 0 Then Exit Sub

                    params.Clear()

                    where.Add("cid = ", cid)
                    where.Add("Bon_Transport = ", 0)
                    params.Add("Bon_Transport", mid)
                    params.Add("isAdmin", True)
                    params.Add("isPayed", True)

                    a.UpdateRecordSymbols("Mission", params, where)

                    params.Clear()
                    where.Clear()
                    where.Add("cid = ", cid)
                    where.Add("Bon_Transport = ", 0)
                    params.Add("Bon_Transport", mid)
                    a.UpdateRecordSymbols("Details_Mission", params, where)

                


                End Using

                If mid > 0 Then
                    ds.Mode = "TRANSPORT"
                    ds.id_T = mid
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
        add.id = ds.id_M
        add.tb_F = ds.TableName
        If add.ShowDialog = DialogResult.Cancel Then
            Try
                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim params As New Dictionary(Of String, Object)

                    params.Add("pj", add.pl.Controls.Count)

                    Dim where As New Dictionary(Of String, Object)
                    where.Add("mid", ds.id_M)
                    If c.UpdateRecord("Mission", params, where) Then
                        ds.pj = add.pl.Controls.Count
                    End If
                End Using
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub EditMissionDate(ByVal ds As ParcList)
        Try
            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.text = ds.ClientName
            NF.cName = ds.ClientName
            NF.cid = ds.cid

            NF.TxtExr.Enabled = False
            NF.txtName.Enabled = False

            NF.TxtDate.Text = ds.date.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then
             
                If IsDate(NF.TxtDate.Text) = False Then Exit Sub
                If CDate(NF.TxtDate.Text) = ds.date Then Exit Sub


                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    params.Add("date", CDate(NF.TxtDate.Text))
                   
                    where.Add("Mid", ds.id_M)

                    If c.UpdateRecord("Mission", params, where) Then
                        ds.date = CDate(NF.TxtDate.Text)
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub EditTransportDate(ByVal ds As ParcList)
        Try
            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.text = ds.ClientName
            NF.cName = ds.ClientName
            NF.cid = ds.cid

            NF.TxtExr.Enabled = False
            NF.txtName.Enabled = False

            NF.TxtDate.Text = ds.date.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then

                If IsDate(NF.TxtDate.Text) = False Then Exit Sub
                If CDate(NF.TxtDate.Text) = ds.date Then Exit Sub


                Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    Dim params As New Dictionary(Of String, Object)
                    Dim where As New Dictionary(Of String, Object)

                    params.Add("date", CDate(NF.TxtDate.Text))

                    where.Add("id", ds.id_T)

                    If c.UpdateRecord("Bon_Transport", params, where) Then
                        ds.date_Transport = CDate(NF.TxtDate.Text)
                    End If
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetElements(ByRef ds As ParcList)
        Try

            If ds.TableName = "Driver" Or ds.TableName = "Vehicule" Then
                GetVehiculeOrDriver(ds)
            ElseIf ds.TableName = "Mission" Then
                GetMission(ds)
            ElseIf ds.TableName = "Bon_Transport" Then
                GetTransport(ds)
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
                    params.Add(str & " Like ", "%" & ds.txtSearchName.text & "%")
                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" And ds.txtSearchName.text <> "*" Then
                    Dim txt = ds.txtSearchName.text.Split(";")
                    For i As Integer = 0 To txt.Length - 1

                        If txt(i).ToUpper.StartsWith("DP") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim
                            params.Add("depart Like ", V & "%")

                        ElseIf txt(i).ToUpper.StartsWith("DS") Then
                            Dim V = txt(i).Remove(0, 2).Trim
                            params.Add("arrive Like ", V & "%")

                        ElseIf txt(i).Trim.ToUpper.StartsWith("CH") Then
                            Dim V = txt(i).Trim.Remove(0, 2).Trim

                            If IsNumeric(V) Then
                                params.Add("drid = ", V)
                            Else
                                where.Clear()
                                where.Add("[name] Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Driver", {"*"}, where)
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
                                where.Add("[ref] Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Vehicule", {"*"}, where)
                                If dt.Rows.Count > 0 Then
                                    params.Add("vid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If
                        ElseIf txt(i).Trim.ToUpper.StartsWith("CLN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            If IsNumeric(V) Then
                                params.Add("cid = ", V.ToUpper)
                            Else
                                params.Add("clientName Like ", "%" & V & "%")
                            End If
                        ElseIf txt(i).Trim.ToUpper.StartsWith("DMN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            params.Add("domain Like ", "%" & V & "%")

                        ElseIf txt(i).Trim.ToUpper.StartsWith("EX") Then
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
                        Else
                            Try
                                params.Add("clientName Like ", "%" & txt(i).Trim.ToUpper & "%")
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                    If params.Count > 0 Then dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                ElseIf ds.txtSearchName.text.Trim = "*" Then
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
    Private Sub GetTransport(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)

            Dim dt As DataTable = Nothing
            Dim str As String = "id"
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If IsNumeric(ds.txtSearchName.text) Then

                    params.Add(str & " Like ", "%" & ds.txtSearchName.text & "%")
                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" And ds.txtSearchName.text <> "*" Then
                    Dim txt = ds.txtSearchName.text.Split(";")
                    For i As Integer = 0 To txt.Length - 1

                        If txt(i).Trim.ToUpper.StartsWith("CLN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            If IsNumeric(V) Then
                                params.Add("cid = ", V)
                            Else
                                params.Add("name Like ", "%" & V.ToUpper & "%")
                            End If

                        ElseIf txt(i).Trim.ToUpper.StartsWith("EX") Then
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
                        ElseIf txt(i).Trim.ToUpper.StartsWith("FCT") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            Dim isF As Boolean = True
                            If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
                                isF = False
                            End If
                            params.Add("isFactured = ", isF)
                        Else
                            Try
                                params.Add("name Like ", "%" & txt(i).Trim.ToUpper & "%")
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                    If params.Count > 0 Then dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                ElseIf ds.txtSearchName.text.Trim = "*" Then
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
                                where.Add("clientName Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Mission", {"*"}, where)
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
                                where.Add("[ref] Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Vehicule", {"*"}, where)
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
                                where.Add("[name] Like ", V & "%")

                                dt = a.SelectDataTableSymbols("Driver", {"*"}, where)
                                If dt.Rows.Count > 0 Then
                                    params.Add("drid = ", CInt(dt.Rows(0).Item(0)))
                                End If
                            End If
                        ElseIf txt(i).Trim.ToUpper.StartsWith("CLN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            If IsNumeric(V) Then
                                params.Add("cid = ", V)
                            Else
                                params.Add("[name] Like ", "%" & V & "%")
                            End If

                        ElseIf txt(i).Trim.ToUpper.StartsWith("DMN") Then
                            Dim V = txt(i).Trim.Remove(0, 3).Trim
                            params.Add("domain Like ", "%" & V & "%")

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

                    If params.Count > 0 Then dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
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
    Private Sub GetMissionById(ByVal value As Integer, ByRef DS As ParcList)
        Try
            DS.plDBody.Controls.Clear()
            DS.plCBody.Controls.Clear()
            DS.ClientName = ""
            DS.cid = 0
            DS.lbInfo.Text = ""
            DS.vid = 0
            DS.vehiculeName = ""
            DS.vehiculeRef = ""
            DS.drid = 0
            DS.DriverInfo = ""
            DS.DriverName = ""
            DS.Domain = ""

            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                params.Add("Mid", value)
                dt = a.SelectDataTable(DS.TableName, {"*"}, params)
                cid = IntValue(dt, "cid", 0) 'CInt(dt.Rows(0).Item("cid"))

                Dim vid As Integer = IntValue(dt, "vid", 0) 'CInt(dt.Rows(0).Item("vid"))
                Dim drid As Integer = IntValue(dt, "drid", 0) 'CInt(dt.Rows(0).Item("drid"))

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
                DS.Domain = StrValue(dt, "domain", 0)
                DS.MissionBonTransport = IntValue(dt, "Bon_Transport", 0)
                DS.vid = vid
                DS.drid = drid

                If vid > 0 Then
                    params.Clear()
                    params.Add("Vid", vid)
                    Dim Vdt = a.SelectDataTable("Vehicule", {"*"}, params)
                    If Vdt.Rows.Count > 0 Then

                        DS.vehiculeName = Vdt.Rows(0).Item("name") & "[" & StrValue(Vdt, 0, 0) & "]"
                        DS.vehiculeRef = StrValue(Vdt, "ref", 0)
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
                        az.price = DblValue(mdt, "value", i)
                        az.qte = DblValue(mdt, "qte", i)
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
                        az.price = DblValue(cdt, "value", i)
                        az.qte = 1
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
    Private Sub GetTransportById(ByVal value As Integer, ByRef DS As ParcList)
        Try
            DS.plTransBody.Controls.Clear()


            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                params.Add("id", value)
                dt = a.SelectDataTable(DS.TableName, {"*"}, params)
                cid = CInt(dt.Rows(0).Item("cid"))

                DS.isFactured_Transport = BoolValue(dt, "isFactured", 0)
                DS.date_Transport = DteValue(dt, "date", 0)
                DS.writer = StrValue(dt, "writer", 0)
                DS.TB.Writer = StrValue(dt, "writer", 0)
                DS.Avance_Transport = DblValue(dt, "avance", 0)


                params.Clear()
                params.Add("Bon_Transport", value)
                Dim mdt = a.SelectDataTable("Details_Mission", {"*"}, params)
                If mdt.Rows.Count > 0 Then
                    For i As Integer = 0 To mdt.Rows.Count - 1
                        Dim az As New AddElement

                        az.Key = StrValue(mdt, "name", i) & " " & StrValue(mdt, "depart", i)
                        az.ref = StrValue(mdt, "ref", i)
                        az.price = DblValue(mdt, "value", i)
                        az.qte = DblValue(mdt, "qte", i)
                        az.id = IntValue(mdt, "id", i)
                        az.DateElemenet = DteValue(mdt, "date", i)
                        az.HasDate = True
                        az.EditMode = True
                        az.Dock = DockStyle.Top


                        DS.plTransBody.Controls.Add(az)
                    Next
                End If

                mdt = Nothing
                DS.Mode = "TRANSPORT"
            End Using
            DS.Client = New Client(cid, "Client")
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByDate(ByRef ds As ParcList)
        SearchByTag(ds)

        'Try
        '    Dim params As New Dictionary(Of String, Object)
        '    Dim dt As DataTable = Nothing
        '    ds.plList.Controls.Clear()

        '    Dim NF As New SearchArchive
        '    NF.txtName.AutoCompleteSource = AutoCompleteByName("Client")

        '    If NF.ShowDialog = DialogResult.OK Then
        '        Dim dt1 As Date = Date.Parse(NF.dte2.Text).AddDays(1)
        '        Dim dt2 As Date = Date.Parse(NF.dte1.Text).AddDays(-1)

        '        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
        '            If NF.txtName.text <> "" Then
        '                ''''''''''''''''''''''''''''
        '                Dim where As New Dictionary(Of String, Object)
        '                Dim txt = NF.txtName.text.Split(";")


        '                For i As Integer = 0 To txt.Length - 1

        '                    If txt(i).Trim.ToUpper.StartsWith("DP") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim
        '                        params.Add("depart Like ", V & "%")

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("DS") Then
        '                        Dim V = txt(i).Remove(0, 2).Trim
        '                        params.Add("arrive Like ", V & "%")

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("CH") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim

        '                        If IsNumeric(V) Then
        '                            params.Add("drid = ", V)
        '                        Else
        '                            where.Clear()
        '                            where.Add("[name] Like ", V & "%")

        '                            dt = a.SelectDataTableSymbols("Driver", {"*"}, where)
        '                            If dt.Rows.Count > 0 Then
        '                                params.Add("drid = ", CInt(dt.Rows(0).Item(0)))
        '                            End If
        '                        End If

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("VH") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim
        '                        If IsNumeric(V) Then
        '                            params.Add("vid = ", V)
        '                        Else
        '                            where.Clear()
        '                            where.Add("[name] Like ", V & "%")

        '                            dt = a.SelectDataTableSymbols("Vehicule", {"*"}, where)
        '                            If dt.Rows.Count > 0 Then
        '                                params.Add("vid = ", CInt(dt.Rows(0).Item(0)))
        '                            End If
        '                        End If

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("CLN") Then
        '                        Dim V = txt(i).Trim.Remove(0, 3).Trim
        '                        If IsNumeric(V) Then
        '                            params.Add("cid = ", V)
        '                        Else
        '                            params.Add("clientName Like ", "%" & V & "%")
        '                        End If

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("DMN") Then
        '                        Dim V = txt(i).Trim.Remove(0, 3).Trim
        '                        params.Add("domain Like ", "%" & V & "%")

        '                    ElseIf txt(i).ToUpper.StartsWith("EX") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim
        '                        params.Add("ex Like ", "%" & V & "%")

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("EDT") Then
        '                        Dim V = txt(i).Trim.Remove(0, 3).Trim
        '                        params.Add("writer Like ", "%" & V & "%")

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("RG") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim
        '                        Dim isPayed As Boolean = True
        '                        If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
        '                            isPayed = False
        '                        End If
        '                        params.Add("isPayed = ", isPayed)

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("ST") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim
        '                        Dim isAdmin As Boolean = False
        '                        If V.ToUpper = "F" Or V.ToUpper.StartsWith("FIN") Or V.ToUpper.StartsWith("TER") Then
        '                            isAdmin = True
        '                        End If
        '                        params.Add("isAdmin = ", isAdmin)

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("FCT") Then
        '                        Dim V = txt(i).Trim.Remove(0, 3).Trim
        '                        Dim isF As Boolean = True
        '                        If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
        '                            isF = False
        '                        End If
        '                        params.Add("isFactured = ", isF)

        '                    ElseIf txt(i).Trim.ToUpper.StartsWith("MS") Then
        '                        Dim V = txt(i).Trim.Remove(0, 2).Trim
        '                        If IsNumeric(V) Then
        '                            params.Add("mid = ", V)
        '                        Else
        '                            where.Clear()
        '                            where.Add("[name] Like ", V & "%")

        '                            dt = a.SelectDataTableSymbols("Mission", {"*"}, params)
        '                            If dt.Rows.Count > 0 Then
        '                                params.Add("mid = ", CInt(dt.Rows(0).Item(0)))
        '                            End If
        '                        End If
        '                    Else
        '                        Try
        '                            If ds.TableName = "Mission" Then
        '                                params.Add("clientName Like ", "%" & txt(i).Trim & "%")
        '                            Else
        '                                params.Add("name Like ", "%" & txt(i).Trim & "%")
        '                            End If

        '                        Catch ex As Exception
        '                        End Try
        '                    End If
        '                Next
        '            End If




        '            params.Add("[date] < ", dt1)
        '            params.Add("[date] > ", dt2)

        '            dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
        '        End Using

        '        If dt.Rows.Count > 0 Then
        '            ds.Clear()
        '            ds.Mode = "LIST"

        '            ds.DataSource = dt
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub
    Public Sub SearchByTag(ByRef ds As ParcList)
        Try

            Dim NF As New SearchByTags
            NF.TableName = ds.TableName
            Dim dt As DataTable

            If NF.ShowDialog = DialogResult.OK Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, NF.params)
                End Using

                ds.Clear()
                If dt.Rows.Count > 0 Then
                    'ds.Mode = "LIST"
                    ds.DataSource = dt
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ReleveClientByDate(ByVal ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            ds.plList.Controls.Clear()

            Dim NF As New NouveauFacture
            NF.txtName.AutoCompleteSource = AutoCompleteByName("Client")

            'NF.dte2.Enabled = False
            'NF.dte1.Enabled = False

            If NF.ShowDialog = DialogResult.OK Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    Dim cid = NF.cid
                    Dim cname = NF.cName

                    params.Add("cid", cid)
                    params.Add("name", cname)
                    params.Add("date", NF.dte)
                    params.Add("delai", "-")
                    params.Add("ex", Form1.Exercice)
                    params.Add("total", 0)
                    params.Add("avance", 0)
                    params.Add("isPayed", False)

                    Dim BT_id = a.InsertRecord("Bon_Transport", params, True)
                    If BT_id = 0 Then Exit Sub
                    params.Clear()

                    params.Add("cid", cid)
                    params.Add("Bon_Transport", 0)

                    Dim dt_M = a.SelectDataTable("Mission", {"*"}, params)

                    If dt_M.Rows.Count > 0 Then
                        For t As Integer = 0 To dt_M.Rows.Count - 1

                            params.Clear()
                            params.Add("mid", dt_M.Rows(t).Item(0))
                            If t = 0 Then
                                dt = a.SelectDataTable("Details_Mission", {"*"}, params)
                            Else
                                dt.Merge(a.SelectDataTable("Details_Mission", {"*"}, params), False)
                            End If
                        Next
                        If dt.Rows.Count > 0 Then
                            For i As Integer = 0 To dt.Rows.Count - 1
                                Dim az As New AddElement
                                az.DateElemenet = DteValue(dt_M, "date", i).ToString("dd MMM, yyyy")
                                az.HasDate = True
                                az.Key = StrValue(dt, "name", i)
                                az.Key &= " [" & StrValue(dt_M, "depart", i) & " => " & StrValue(dt_M, "arrive", i) & "]"
                                az.price = DblValue(dt, "value", i)
                                az.qte = DblValue(dt, "qte", i)
                                az.id = IntValue(dt, "id", i)
                                az.EditMode = True
                                az.Dock = DockStyle.Top
                                az.PlRight.Visible = False

                                ds.plTransBody.Controls.Add(az)
                            Next
                        End If
                    End If
                End Using
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub GetPriceOfDetails(ByVal ds As ParcList, ByVal str As String)
        Try
            Dim params As New Dictionary(Of String, Object)

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                params.Add("name", str.ToUpper)
                params.Add("depart", "(" & ds.depart.ToUpper & " => " & ds.arrive.ToUpper & ")")
                Dim price = a.SelectByScalar("Details_Mission", "value", params)

                ds.txtDPrix.text = price
            End Using
            params = Nothing
        Catch ex As Exception

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
    Private Sub EditSelectedCharge(ByVal ds As ParcList, ByVal a As ClientRow)
        Try

            Dim NF As New AddEditCharge
            NF.id = a.Id

            If NF.ShowDialog = DialogResult.OK Then

                a.Responsable = NF.txtvehicule.text.Split("|")(0)
                a.Ville = NF.txtdriver.text.Split("|")(0)
                a.Tel = NF.txtDValue.text
                a.lbType.Text = CDate(NF.txtDate.text).ToString("dd MMM, yyyy")

                a.isEdited = True
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub DeleteSelectedElement(ByVal ds As ParcList, ByVal elm As ClientRow)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If ds.TableName = "Mission" Then
                    params.Add("Mid", elm.Id)
                    DeleteMission(elm.Id, ds)
                    ds.RemoveElement(elm)
                    Exit Sub

                ElseIf ds.TableName = "Bon_Transport" Then
                    DeleteTransport(elm.Id, ds)
                    ds.RemoveElement(elm)
                    Exit Sub

                ElseIf ds.TableName = "Vehicule" Then
                    params.Add("Vid", elm.Id)

                ElseIf ds.TableName = "Driver" Then
                    params.Add("Drid", elm.Id)

                ElseIf ds.TableName = "Details_Charge" Then
                    params.Add("id", elm.Id)

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
                where.Add("mid", CInt(ds.id_M))

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
                where.Add("Mid", CInt(ds.id_M))

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
                where.Add("mid", CInt(ds.id_M))

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


        rf.TxtBox1.AutoCompleteSource = AutoCompleteByVehicule("Vehicule")

        If rf.ShowDialog = DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                Dim tableName = ds.TableName
                Dim params As New Dictionary(Of String, Object)
                params.Add("ref", rf.Value.Split("|")(0))
                Dim Vdt = c.SelectDataTable("Vehicule", {"*"}, params)
                If Vdt.Rows.Count > 0 Then
                    vid = Vdt.Rows(0).Item(0)
                    nm = Vdt.Rows(0).Item("name")
                    info = StrValue(Vdt, "ref", 0)
                Else
                    MsgBox("Nom de Vehicule est incorrect..")
                    Exit Sub
                End If

                params.Clear()
                params.Add("vid", Vdt.Rows(0).Item(0))
                Dim where As New Dictionary(Of String, Object)
                where.Add("mid", CInt(ds.id_M))

                If c.UpdateRecord(ds.TableName, params, where) Then
                    ds.vid = vid
                    ds.vehiculeName = nm
                    ds.vehiculeRef = info
                End If

                params = Nothing
                where = Nothing
            End Using
        End If
    End Sub

    Private Sub SaveMissionChanges(ByRef ds As ParcList)

        If ds.txtDKey.text.Trim <> "" And ds.txtDPrix.text.Trim <> "" Then
            MsgBox("merci de compléter / valider l'operation de saisie", MsgBoxStyle.Information, vbOK)
            ds.txtDPrix.Focus()
        End If

        If ds.txtCKey.text.Trim <> "" And ds.txtCValue.text.Trim <> "" Then
            MsgBox("merci de compléter / valider l'operation de saisie", MsgBoxStyle.Information, vbOK)
            ds.txtCValue.Focus()
        End If

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
                If ds.MissionBonTransport = 0 Then params.Add("isAdmin", False)
            End If

            If ds.Total <= ds.Avance Then
                params.Add("isPayed", True)
            Else
                If ds.MissionBonTransport = 0 Then params.Add("isPayed", False)
            End If

            params.Add("total", ds.Total)
            params.Add("avance", ds.Avance)
            params.Add("depart", ds.depart.ToUpper)
            params.Add("km_D", ds.km_D)
            params.Add("km_A", ds.km_A)
            params.Add("arrive", ds.arrive.ToUpper)
            params.Add("domain", ds.Domain.ToUpper)

            Dim where As New Dictionary(Of String, Object)
            where.Add("mid", ds.id_M)

            c.UpdateRecord(tableName, params, where)
            params.Clear()
            where.Clear()

            params.Add("depart", "(" & ds.depart.ToUpper & " => " & ds.arrive.ToUpper & ")")
            params.Add("cid", ds.cid)
            params.Add("Bon_Transport", ds.MissionBonTransport)
            params.Add("ref", ds.vehiculeRef)
            params.Add("date", ds.date)

            where.Add("mid", ds.id_M)

            c.UpdateRecord("details_Mission", params, where)

            params.Clear()
            where.Clear()

            params.Add("vid", ds.vid)
            params.Add("drid", ds.drid)

            where.Add("mid", ds.id_M)
            c.UpdateRecord("details_Charge", params, where)


            params.Clear()
            where.Clear()

            params.Add("Vid", ds.vid)
            Dim old_km = c.SelectByScalar("Vehicule", "km", params)
            If Not IsNumeric(old_km) Then old_km = 0

            Dim new_km = ds.km_D
            If ds.km_D < ds.km_A Then new_km = ds.km_A
            If new_km > old_km Then
                params.Clear()
                where.Clear()

                params.Add("km", new_km)
                where.Add("Vid", ds.vid)
                c.UpdateRecord("Vehicule", params, where)
            End If

            Try ' domais
                If ds.Domain.Trim <> "" Then
                    params.Clear()
                    where.Clear()
                    params.Add("name", ds.Domain.ToUpper)
                    params.Add("key", "DOMAIN")
                    params.Add("val", ds.cid)
                    Dim dt_d = c.SelectDataTable("Word", {"*"}, params)
                    params.Clear()

                    If dt_d.Rows.Count = 0 Then
                        params.Clear()
                        params.Add("name", CStr(ds.Domain).ToUpper)
                        params.Add("key", "DOMAIN")
                        params.Add("val", ds.cid)

                        c.InsertRecord("Word", params)
                    End If
                End If

            Catch ex As Exception
            End Try
            params.Clear()

            Try ' DEPART
                If ds.depart.Trim <> "" Then
                    params.Add("name", CStr(ds.depart.ToUpper))
                    params.Add("key", "DEPART")
                    params.Add("val", "DEPART")
                    Dim dt_d = c.SelectDataTable("Word", {"*"}, params)
                    params.Clear()

                    If dt_d.Rows.Count = 0 Then
                        params.Clear()
                        params.Add("name", CStr(ds.depart).ToUpper)
                        params.Add("key", "DEPART")
                        params.Add("val", "DEPART")

                        c.InsertRecord("Word", params)
                    End If
                End If

            Catch ex As Exception
            End Try
            params.Clear()

            Try ' ARRIVE
                If ds.arrive.Trim <> "" Then
                    params.Add("name", CStr(ds.arrive.ToUpper))
                    params.Add("key", "ARRIVE")
                    params.Add("val", "ARRIVE")
                    Dim dt_d = c.SelectDataTable("Word", {"*"}, params)
                    params.Clear()

                    If dt_d.Rows.Count = 0 Then
                        params.Clear()
                        params.Add("name", CStr(ds.arrive).ToUpper)
                        params.Add("key", "ARRIVE")
                        params.Add("val", "ARRIVE")

                        c.InsertRecord("Word", params)
                    End If
                End If

            Catch ex As Exception
            End Try
            params.Clear()



            params = Nothing
            where = Nothing
        End Using
    End Sub
    Private Sub SaveTransportChanges(ByRef ds As ParcList)
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)


            Dim tableName = ds.TableName
            Dim dte As Date = ds.date
            Dim params As New Dictionary(Of String, Object)

            'Facture
            params.Clear()



            If ds.Total_Transport <= ds.Avance_Transport Then
                params.Add("isPayed", True)
            Else
                params.Add("isPayed", False)
            End If

            params.Add("total", ds.Total_Transport)
            params.Add("avance", ds.Avance_Transport)

            Dim where As New Dictionary(Of String, Object)
            where.Add("id", ds.id_T)

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
                'params.Add("isAdmin", True)
                params.Add("isFactured", True)
                Dim where As New Dictionary(Of String, Object)
                where.Add("Mid", ds.id_M)

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
                n = "Vehicule : " & ds.vehiculeName & " " & ds.vehiculeRef
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
                    params.Add("bprice", el.price)
                    params.Add("price", el.price)
                    params.Add("remise", 0)
                    params.Add("qte", el.qte)
                    params.Add("tva", 0)
                    params.Add("arid", 0)
                    params.Add("depot", 0)
                    params.Add("ref", el.ref)
                    params.Add("cid", 0)

                    c.InsertRecord("Details_Sell_Facture", params)
                    params.Clear()
                Next


                where.Clear()
                If ds.Avance > 0 Then
                    params.Add("Sell_Facture", fid)
                    where.Add("Mission", CInt(ds.id_M))
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
    Private Sub TransportFactured(ByRef ds As ParcList)
        Dim dte As String = Now.Date.ToString("dd-MM-yyyy")
        Try
            Dim fid As Integer = 0
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                params.Add("isPayed", True)
                params.Add("isFactured", True)
                Dim where As New Dictionary(Of String, Object)
                where.Add("id", ds.id_T)

                c.UpdateRecord("Bon_Transport", params, where)

                params.Clear()
                where.Clear()


                Dim cid As String = ds.cid
                Dim clientname As String = ds.ClientName

                params.Add("cid", cid)
                params.Add("name", clientname)
                params.Add("total", ds.TB.TotalTTC)
                params.Add("avance", ds.Avance_Transport)
                params.Add("remise", 0)
                params.Add("tva", ds.TB.TotalTTC)
                params.Add("date", Format(Now.Date, "dd-MM-yyyy"))
                params.Add("writer", (Form1.adminName))
                params.Add("isAdmin", "CREATION")
                params.Add("isPayed", False)
                params.Add("modePayement", "-")
                params.Add("droitTimbre", 0)
                params.Add("pj", 0)
                params.Add("Bon_Livraison", "B.T. : " & ds.id_T)

                fid = c.InsertRecord("Sell_Facture", params, True)
                params.Clear()

                Dim ListOfDetails As New Dictionary(Of String, String)
                ListOfDetails.Add("ssss", "0|0")

                For Each el As AddElement In ds.plTransBody.Controls

                    Dim sstr As String = el.Key & el.ref & el.price
                    If ListOfDetails.ContainsKey(sstr) Then
                        Dim d_id = CInt(ListOfDetails(sstr).Split("|")(0))
                        Dim d_qte = CDbl(ListOfDetails(sstr).Split("|")(1))
                        d_qte += el.qte
                        params.Add("qte", d_qte)
                        where.Add("id", d_id)
                        c.UpdateRecord("Details_Sell_Facture", params, where)
                        ListOfDetails(sstr) = d_id & "|" & d_qte
                        where.Clear()

                    Else
                        params.Add("fctid", fid)
                        params.Add("name", el.Key)
                        params.Add("bprice", el.price)
                        params.Add("price", el.price)
                        params.Add("remise", 0)
                        params.Add("qte", el.qte)
                        params.Add("tva", Form1.tva)
                        params.Add("arid", -111)
                        params.Add("depot", 0)
                        params.Add("ref", el.ref)
                        params.Add("cid", 0)

                        Dim d_id = c.InsertRecord("Details_Sell_Facture", params, True)
                        ListOfDetails.Add(sstr, d_id & "|" & el.qte)
                    End If

                    params.Clear()
                Next


                where.Clear()
                If ds.Avance > 0 Then
                    params.Add("Sell_Facture", fid)
                    where.Add("Bon_Transport", CInt(ds.id_T))
                    c.UpdateRecord("Client_Payement", params, where)
                    params.Clear()
                    where.Clear()
                End If

            End Using

            If fid > 0 Then
                Dim str As String = "Opération terminé avec succès"
                str &= vbNewLine & "Facture N° " & Form1.Exercice & "/000" & fid
                str &= vbNewLine & "Total : " & ds.TB.TotalTTC

                MsgBox(str, MsgBoxStyle.Information, "Facturation")
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
            params.Add("domain", ds.Domain)
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
            params.Add("Bon_Transport", 0)
            params.Add("ex", Form1.Exercice)
            params.Add("km_D", 0)
            params.Add("km_A", 0)

            mid = c.InsertRecord("Mission", params, True)

            For Each el As AddElement In ds.plDBody.Controls
                params.Clear()

                params.Add("name", el.Key)
                params.Add("value", el.price)
                params.Add("qte", el.qte)
                params.Add("mid", mid)
                params.Add("writer", Form1.adminName)

                params.Add("depart", "(" & ds.depart & " => " & ds.arrive & ")")
                params.Add("Bon_Transport", 0)
                params.Add("cid", ds.cid)
                params.Add("ref", "")
                params.Add("date", Now.Date)

                c.InsertRecord("Details_Mission", params)

            Next

            For Each el As AddElement In ds.plCBody.Controls
                params.Clear()
                params.Add("name", el.Key)
                params.Add("value", el.price)
                params.Add("mid", mid)
                params.Add("vid", ds.vid)
                params.Add("drid", ds.drid)
                params.Add("date", Now.Date)
                params.Add("ex", Form1.Exercice)
                params.Add("writer", Form1.adminName)

                c.InsertRecord("Details_Charge", params)
            Next
        End Using
        If mid > 0 Then
            'GetMissionById(mid, ds)

            'ds.Mode = "DETAILS"
            ds.id_M = mid
            'ds.Client = New Client(ds.cid, "Client")
        End If
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
            
            End If

        End Using

        If ds.Mode.ToUpper = "LIST" Then
            'ds.RemoveElement(elm)
        Else

            ds.Mode = "LIST"
        End If
    End Sub
    Private Sub DeleteTransport(ByVal _id As Integer, ByRef ds As ParcList)
        Dim mid As Integer = _id

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim where As New Dictionary(Of String, Object)

            where.Add("id", mid)

            If c.DeleteRecords("Bon_Transport", where) Then
                Dim params As New Dictionary(Of String, Object)
                where.Clear()
                where.Add("Bon_Transport = ", mid)
                params.Add("Bon_Transport", 0)

                c.UpdateRecordSymbols("Details_Mission", params, where)

                where.Clear()
                params.Clear()
                where.Add("Bon_Transport = ", mid)
                params.Add("Bon_Transport", 0)
                c.UpdateRecordSymbols("Mission", params, where)

                where.Clear()
                params.Clear()
                where.Add("Bon_Transport = ", mid)
                params.Add("Bon_Transport", 0)
                c.UpdateRecordSymbols("Client_Payement", params, where)

                ds.TableName = "Bon_Transport"
                If ds.Mode.ToUpper = "LIST" Then
                    'ds.RemoveElement(elm)
                Else
                    ds.Mode = "LIST"
                End If

            End If

        End Using
    End Sub

    Private Sub SavePdf(ByRef ds As ParcList)


        Form1.Facture_Title = "Bon de Transport"
        If ds.TableName = "Mission" Then Form1.Facture_Title = "Mission"

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
    Private Sub PrintMission(ByVal ds As ParcList)
        Form1.Facture_Title = "Bon de Transport"
        If ds.TableName = "Mission" Then Form1.Facture_Title = "Mission"
        Form1.printOnPaper = True

        Form1.PrintDocMission.PrinterSettings.PrinterName = Form1.printer_Bon
        Form1.PrintDocMission.Print()
    End Sub
    Private Sub PrintListOfParc(ByVal ds As ParcList)
        Form1.PrintDocMission.PrinterSettings.PrinterName = Form1.printer_Bon

        Form1.Facture_Title = ""
        If ds.TableName = "Mission" Then
            Form1.Facture_Title = "Liste des missions"
            Form1.PrintDocMission.DefaultPageSettings.Landscape = True
        ElseIf ds.TableName = "Details_Charge" Then
            Form1.Facture_Title = "Listes des Charges"
        ElseIf ds.TableName = "Driver" Then
            Form1.Facture_Title = "Chauffeurs"
        ElseIf ds.TableName = "Vehicule" Then
            Form1.Facture_Title = "Listes Vehicule"
        ElseIf ds.TableName = "Bon_Transport" Then
            Form1.Facture_Title = "Listes Bon de Transport"
        End If

        Form1.printOnPaper = True
        Form1.PrintDocMission.Print()
    End Sub
    Private Sub GetClientDetails(ByVal _cid As Integer)
        Dim fl As New ClientDetails
        fl.Table = "Client"
        fl.id = _cid
        If fl.ShowDialog = DialogResult.OK Then

        End If
    End Sub
    Private Sub AddNewDetailsMission(ByVal k As String, ByVal v As Double, ByVal q As Double, ByVal ds As ParcList)
        Try
            Dim d_Id As Integer = 0
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                params.Add("name", k.ToUpper)
                params.Add("value", v)
                params.Add("date", ds.date)
                params.Add("qte", q)
                params.Add("mid", ds.id_M)
                params.Add("writer", Form1.adminName)

                d_Id = c.InsertRecord("Details_Mission", params, True)
                If d_Id > 0 Then
                    Dim R As New AddElement

                    R.Key = k.ToUpper
                    R.price = v
                    R.qte = q
                    R.id = d_Id
                    R.EditMode = True
                    R.Dock = DockStyle.Top

                    AddHandler R.Clear, AddressOf DeleteDetailsElement
                    ds.plDBody.Controls.Add(R)

                    Try ' AUTOCOMPLITE DETAILS MISSION
                        If ds.txtDKey.text.Trim <> "" Then
                            params.Clear()
                            params.Add("name", k.ToUpper)
                            params.Add("key", "MISSION")
                            params.Add("val", "DETAILS")
                            Dim dt_d = c.SelectDataTable("Word", {"*"}, params)
                            params.Clear()

                            If dt_d.Rows.Count = 0 Then
                                params.Clear()
                                params.Add("name", k.ToUpper)
                                params.Add("key", "MISSION")
                                params.Add("val", "DETAILS")

                                c.InsertRecord("Word", params)
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    params.Clear()

                    ds.txtDPrix.text = ""
                    ds.txtDKey.text = ""
                    ds.txtDQte.text = ""
                End If
                params = Nothing
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddNewChargeMission(ByVal k As String, ByVal v As Double, ByVal ds As ParcList)
        Try
            Dim d_Id As Integer = 0
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)

                params.Add("name", k.ToUpper)
                params.Add("value", v)
                params.Add("mid", ds.id_M)
                params.Add("vid", ds.vid)
                params.Add("drid", ds.drid)
                params.Add("date", ds.date)
                params.Add("ex", Form1.Exercice)
                params.Add("writer", Form1.adminName)


                d_Id = c.InsertRecord("Details_Charge", params, True)
                If d_Id > 0 Then
                    Dim R As New AddElement

                    R.Key = k.ToUpper
                    R.price = v
                    R.id = d_Id
                    R.qte = 1
                    R.EditMode = True
                    R.Dock = DockStyle.Top
                    AddHandler R.Clear, AddressOf DeleteChargeMission
                    ds.plCBody.Controls.Add(R)

                    Try ' AUTOCOMPLITE CHARGE MISSION
                        If ds.txtCKey.text.Trim <> "" Then
                            params.Clear()

                            If k.Contains("(") Then
                                k = k.Split("(")(0)
                            End If

                            params.Add("name", k.ToUpper)
                            params.Add("key", "MISSION")
                            params.Add("val", "CHARGE")
                            Dim dt_d = c.SelectDataTable("Word", {"*"}, params)
                            params.Clear()

                            If dt_d.Rows.Count = 0 Then
                                params.Clear()
                                params.Add("name", k.ToUpper)
                                params.Add("key", "MISSION")
                                params.Add("val", "CHARGE")

                                c.InsertRecord("Word", params)
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                    params.Clear()


                    ds.txtCValue.text = ""
                    ds.txtCKey.text = ""
                End If
                params = Nothing
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
    Private Sub MissionSolde(ByRef parcList As ParcList)
        'Throw New NotImplementedException
        Dim PP As New PayementForm

        PP.ClientName = parcList.ClientName
        PP.cid = parcList.Client.cid
        PP.FactureTable = parcList.TableName
        PP.payementTable = "Client_Payement"
        PP.clientTable = "Client"
        PP.Avance = parcList.Avance_Transport
        PP.Total = parcList.Total_Transport
        PP.Id = parcList.id_T
        If PP.ShowDialog = DialogResult.OK Then

        End If
        parcList.Avance_Transport = PP.Avance
        'fill rows
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

    Private Sub GetListOfDomain(ByVal ds As ParcList)
        Dim cid = ds.cid
        ds.txtDomainName.AutoCompleteSource = AutoCompleteFromWords("DOMAIN", cid)
    End Sub
    Private Sub GetElementInfos(ByVal ds As ParcList, ByVal id As Integer)
        If ds.TableName = "Vehicule" Then
            GetVehiculeDetails(ds, id)
        End If

    End Sub
    Private Sub GetVehiculeDetails(ByVal ds As ParcList, ByVal _vid As Integer)
        Dim vd As New VehiculeDetails
        vd.id = _vid
        vd.dt_Driver = ds.dt_Driver
        If vd.ShowDialog = DialogResult.OK Then



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



    Private Sub GetDeiverDetails(ByVal _drid As Integer)
        'Throw New NotImplementedException
    End Sub



    

  











End Class
