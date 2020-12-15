Public Class PayementForm

    Private _ttc As Double
    Private _avc As Double

    Private _Id As Integer
    Public payementTable As String
    Public FactureTable As String
    Public clientTable As String

    Public ClientName As String
    Public cid As String


    Public Property Id As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
            'FillBloc'
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                params.Add(FactureTable, _Id)
                Dim dt = a.SelectDataTable(payementTable, {"*"}, params)
                If IsNothing(dt) Then Exit Property

                If dt.Rows.Count > 0 Then
                    Dim arr(dt.Rows.Count - 1) As AddPayementRow

                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim pa As New Payement(dt.Rows(i).Item(0), StrValue(dt, "date", i),
                                               StrValue(dt, "way", i), DblValue(dt, "montant", i),
                                               StrValue(dt, "ech", i), StrValue(dt, "ref", i),
                                               StrValue(dt, "desig", i))

                        Dim R As New AddPayementRow
                        R.Payement = pa
                        R.id = dt.Rows(i).Item(0)
                        R.Index = 1
                        R.EditMode = True
                        R.Dock = DockStyle.Top
                        R.BringToFront()
                        AddHandler R.EditPayement, AddressOf Edit_Payement
                        AddHandler R.Cleared, AddressOf Delete_Payement
                        arr(i) = R
                    Next
                    plPmBody.Controls.AddRange(arr)
                End If

                'getAvoir
                If Form1.useSoldByAvoir Then
                    params.Clear()

                    params.Add("cid", cid)
                    params.Add("isPayed", False)

                    Dim tb As String = "Sell_Avoir"
                    If clientTable = "Fournisseur" Then tb = "Buy_Avoir"


                    Dim dtt As DataTable = a.SelectDataTable(tb, {"total"}, params)
                    Dim av As Double = 0
                    For i As Integer = 0 To dtt.Rows.Count - 1
                        av += dtt.Rows(i).Item("total")
                    Next

                    lbAvoir.Text = av.ToString("c")


                    Label2.Visible = True
                    Panel7.Visible = True
                End If

                'get port Monie
                If Form1.usePortMonie Then
                    params.Clear()
                    params.Add("Clid", cid)
                    Dim dtee As DataTable = a.SelectDataTable(clientTable, {"porte_Monie"}, params)

                    lb_PorteMonie.Text = DblValue(dtee, "porte_Monie", 0).ToString("c")


                    Label1.Visible = True
                    Panel8.Visible = True
                End If
            End Using
        End Set
    End Property
    Public Property Avance As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            lbLavc.Text = String.Format("{0:n}", value)

            If value > Total Then
                btAddPorteMonie.Visible = True
            Else
                btAddPorteMonie.Visible = False
            End If
        End Set
    End Property
    Public Property Total As Double
        Get
            Return _ttc
        End Get
        Set(ByVal value As Double)
            _ttc = value
            lbLtotal.Text = String.Format("{0:n}", value)


            If value > Avance Then
                btAddPorteMonie.Visible = False
            Else
                btAddPorteMonie.Visible = True
            End If
        End Set
    End Property

    Private Sub PayementForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbRef.Text = "[" & ClientName & "/" & FactureTable & ": " & Form1.prefix & Id & "]"

        If Form1.usePortMonie Then
            Panel7.Visible = True
            Label2.Visible = True
        End If
        If Form1.useSoldByAvoir Then
            Panel8.Visible = True
            Label1.Visible = True
        End If

    End Sub
    'Private Sub FillBloc()
    '    Dim value As DataTable

    '    ' added some items
    '    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
    '        Dim params As New Dictionary(Of String, Object)
    '        params.Add(FactureTable, Id)
    '        value = a.SelectDataTable(payementTable, {"*"}, params)
    '        params = Nothing
    '    End Using

    '    plPmBody.Controls.Clear()
    '    If IsNothing(value) Then Exit Sub

    '    If value.Rows.Count > 0 Then
    '        Dim arr(value.Rows.Count - 1) As AddPayementRow

    '        For i As Integer = 0 To value.Rows.Count - 1
    '            Dim a As New Payement(value.Rows(i).Item(0), StrValue(value, "date", i),
    '                                   StrValue(value, "way", i), DblValue(value, "montant", i),
    '                                   StrValue(value, "ech", i), StrValue(value, "ref", i),
    '                                   StrValue(value, "desig", i))

    '            Dim R As New AddPayementRow
    '            R.Payement = a
    '            R.id = value.Rows(i).Item(0)
    '            R.Index = i
    '            R.Dock = DockStyle.Top
    '            R.BringToFront()
    '            AddHandler R.EditPayement, AddressOf Edit_Payement
    '            AddHandler R.Cleared, AddressOf Delete_Payement
    '            arr(i) = R
    '        Next
    '        plPmBody.Controls.AddRange(arr)
    '    End If
    'End Sub

    Private Sub AddPayementRow1_AddNewArticle(ByVal pm As A1_GAESTION_COMMERCIAL.Payement) Handles AddPayementRow1.AddNewArticle
        If Id = 0 Then Exit Sub

        'DataSource.Add(art.arid, art)
        Dim d_id As Integer = 0
        Dim R As New AddPayementRow

        ''''''''''''''''''
        Try
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                params.Add("name", ClientName)
                params.Add("clid", cid)
                params.Add("montant", pm.montant)
                params.Add("way", pm.way)
                params.Add("date", pm.dte)
                params.Add("ech", pm.ech)
                params.Add("ref", pm.ref)
                params.Add("desig", pm.desig)
                params.Add("writer", Form1.adminName)
                params.Add(FactureTable, Id)

                d_id = c.InsertRecord(payementTable, params, True)

                If d_id > 0 Then

                    Dim where As New Dictionary(Of String, Object)

                    Dim avc As Double = avance
                    avc += pm.montant

                    where.Clear()
                    params.Clear()

                    If FactureTable = "Mission" Then
                        where.Add("Mid", Id)
                    Else
                        where.Add("id", Id)
                    End If

                    Dim isPayed As Boolean = False
                    If CInt(avc) >= CInt(Total) Then isPayed = True

                    params.Add("avance", avc)
                    params.Add("isPayed", isPayed)
                    If c.UpdateRecord(FactureTable, params, where) Then
                        avance = avc

                        R.Dock = DockStyle.Top
                        R.BringToFront()
                        R.Index = plPmBody.Controls.Count

                        AddHandler R.EditPayement, AddressOf Edit_Payement
                        AddHandler R.Cleared, AddressOf Delete_Payement

                        R.Payement = pm
                        R.id = d_id
                        R.EditMode = True
                        R.Index = plPmBody.Controls.Count
                        If d_id > 0 Then
                            plPmBody.Controls.Add(R)
                        End If


                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Edit_Payement(ByVal pm As AddPayementRow)
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
                If c.UpdateRecord(payementTable, params, where) Then

                    where.Clear()
                    params.Clear()
                    Dim avc As Double = Avance
                    avc += pm.Payement.montant
                    avc -= pm._PM_Edit.montant

                    Dim isPayed As Boolean = False
                    'If avc >= Total Then isPayed = True
                     If CInt(avc) >= CInt(Total) Then isPayed = True

                    params.Add("avance", avc)
                    params.Add("isPayed", isPayed)

                    If FactureTable = "Mission" Then
                        where.Add("Mid", Id)
                    Else
                        where.Add("id", Id)
                    End If

                    If c.UpdateRecord(FactureTable, params, where) Then
                        Avance = avc
                        pm.EditMode = True
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Delete_Payement(ByVal pm As AddPayementRow)
        Try

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)


                If pm.txtWay.text = "AVOIR" Then
                    Dim avid As Integer = CInt(pm.txtDesig.text)
                    where.Add("id", avid)
                    params.Add("ispayed", False)
                    Dim tb As String = "Sell_Avoir"
                    If clientTable = "Fournisseur" Then tb = "Buy_Avoir"

                    c.UpdateRecord(tb, params, where)
                    where.Clear()
                    params.Clear()

                    Dim m As Double = CDbl(lbAvoir.Text)
                    m += pm.Payement.montant
                    lbAvoir.Text = m.ToString("c")

                ElseIf pm.txtWay.text = "PORTE-MONIE" Or pm.txtWay.text = "CONSERVATION" Then

                    params.Add("Clid", cid)
                    Dim m As Double = c.SelectByScalar(clientTable, "porte_Monie", params)
                    m += pm.Payement.montant
                    where.Add("porte_Monie", m)

                    c.UpdateRecord(clientTable, where, params)
                    where.Clear()
                    params.Clear()
                    lb_PorteMonie.Text = m.ToString("c")
                End If
            


                where.Add("Pid", pm.id)

                params.Add(FactureTable, 0)

                If c.UpdateRecord(payementTable, params, where) Then

                    Dim avc As Double = Avance
                    avc -= pm.Payement.montant

                    where.Clear()
                    params.Clear()

                    If FactureTable = "Mission" Then
                        where.Add("Mid", Id)
                    Else
                        where.Add("id", Id)
                    End If

                    Dim isPayed As Boolean = False
                    '   If avc >= Total Then isPayed = True
                    If CInt(avc) >= CInt(Total) Then isPayed = True

                    params.Add("avance", avc)
                    params.Add("isPayed", isPayed)


                    If c.UpdateRecord(FactureTable, params, where) Then
                        Avance = avc
                        plPmBody.Controls.Remove(pm)
                    End If
                End If
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    'add porte monie
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pm = CDbl(lb_PorteMonie.Text)
        If pm > 0 Then
            Dim rf As New ReferenceFacture
            rf.TxtBox1.IsNumiric = True
            rf.Title = lb_PorteMonie.Text
            If rf.ShowDialog = Windows.Forms.DialogResult.OK Then
                If Not IsNumeric(rf.Value) Then Exit Sub
                pm -= rf.Value

                If pm < 0 Then
                    pm = 0
                    rf.Value = CDbl(lb_PorteMonie.Text)
                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Id = 0 Then Exit Sub


                Dim d_id As Integer = 0
                Dim R As New AddPayementRow

                ''''''''''''''''''
                Try
                    Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                        Dim params As New Dictionary(Of String, Object)

                        params.Add("name", ClientName)
                        params.Add("clid", cid)
                        params.Add("montant", CDbl(rf.Value))
                        params.Add("way", "PORTE-MONIE")
                        params.Add("date", Now.Date)
                        params.Add("ech", Now.Date)
                        params.Add("ref", "-")
                        params.Add("desig", "-")
                        params.Add("writer", Form1.adminName)
                        params.Add(FactureTable, Id)

                        d_id = c.InsertRecord(payementTable, params, True)

                        If d_id > 0 Then

                            Dim where As New Dictionary(Of String, Object)

                            Dim avc As Double = Avance
                            avc += CDbl(rf.Value)

                            where.Clear()
                            params.Clear()

                            where.Add("Clid", cid)
                            params.Add("porte_Monie", pm)
                            c.UpdateRecord(clientTable, params, where)

                            where.Clear()
                            params.Clear()

                            If FactureTable = "Mission" Then
                                where.Add("Mid", Id)
                            Else
                                where.Add("id", Id)
                            End If

                            Dim isPayed As Boolean = False
                            'If avc >= Total Then isPayed = True
                            If CInt(avc) >= CInt(Total) Then isPayed = True

                            params.Add("avance", avc)
                            params.Add("isPayed", isPayed)
                            If c.UpdateRecord(FactureTable, params, where) Then
                                Avance = avc

                                R.Dock = DockStyle.Top
                                R.BringToFront()
                                R.Index = plPmBody.Controls.Count

                                AddHandler R.Cleared, AddressOf Delete_Payement

                                Dim pi As New Payement(d_id, Now.Date, "PORTE-MONIE", CDbl(rf.Value), Now.Date, "-", "-")
                                R.Payement = pi
                                R.id = d_id
                                R.EditMode = True
                                R.Index = plPmBody.Controls.Count
                                If d_id > 0 Then
                                    plPmBody.Controls.Add(R)
                                End If

                            End If
                        End If
                    End Using
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    'Avoir
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Id = 0 Then Exit Sub

        Dim la As New Liste_Avoir
        la.CID = cid
        la.lbClient.Text = ClientName
        If la.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)

                For i As Integer = 0 To la.dg.Rows.Count - 1
                    If la.dg.Rows(i).Cells(0).Value = False Then Continue For

                    Dim dte As Date = CDate(la.dg.Rows(i).Cells(1).Value)
                    Dim avid As Integer = la.dg.Rows(i).Cells(2).Value
                    Dim tt As Double = la.dg.Rows(i).Cells(3).Value

                    'DataSource.Add(art.arid, art)
                    Dim d_id As Integer = 0
                    ''''''''''''''''''
                    Try

                        params.Clear()

                        params.Add("name", ClientName)
                        params.Add("clid", cid)
                        params.Add("montant", tt)
                        params.Add("way", "AVOIR")
                        params.Add("date", dte)
                        params.Add("ech", Now.Date)
                        params.Add("ref", avid)
                        params.Add("desig", avid)
                        params.Add("writer", Form1.adminName)
                        params.Add(FactureTable, Id)

                        d_id = c.InsertRecord(payementTable, params, True)

                        If d_id > 0 Then
                            Dim where As New Dictionary(Of String, Object)
                            params.Clear()

                            params.Add("isPayed", True)
                            where.Add("id", avid)

                            Dim tb As String = "Sell_Avoir"
                            If clientTable = "Fournisseur" Then tb = "Buy_Avoir"
                            c.UpdateRecord(tb, params, where)

                            Dim avc As Double = Avance
                            avc += tt

                            where.Clear()
                            params.Clear()

                            If FactureTable = "Mission" Then
                                where.Add("Mid", Id)
                            Else
                                where.Add("id", Id)
                            End If

                            Dim isPayed As Boolean = False
                            '   If avc >= Total Then isPayed = True
                            If CInt(avc) >= CInt(Total) Then isPayed = True



                            params.Add("avance", avc)
                            params.Add("isPayed", isPayed)
                            If c.UpdateRecord(FactureTable, params, where) Then
                                Avance = avc
                                'update label
                                Dim m As Double = CDbl(lbAvoir.Text)
                                m -= tt
                                lbAvoir.Text = m.ToString("c")
                                'create new payement model
                                Dim pa As New Payement(d_id, dte, "AVOIR",
                                                        tt, Now.Date, avid, avid)

                                Dim R As New AddPayementRow
                                R.Payement = pa
                                R.id = d_id
                                R.Index = 1
                                R.EditMode = True
                                R.Dock = DockStyle.Top
                                R.BringToFront()
                                AddHandler R.Cleared, AddressOf Delete_Payement

                                'add control
                                If d_id > 0 Then
                                    plPmBody.Controls.Add(R)
                                End If
                                'exit if it is payed
                                If isPayed = True Then Exit For
                            End If
                        End If

                    Catch ex As Exception
                    End Try
                Next
            End Using
        End If
    End Sub

    Private Sub btAddPorteMonie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAddPorteMonie.Click
        If Avance <= Total Then Exit Sub

        Dim rest As Double = Avance - Total

        Try

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)



              
                params.Add("Clid", cid)
                Dim old_porteMonie As Double = 0
                Try
                    old_porteMonie = c.SelectByScalar(clientTable, "porte_Monie", params)
                Catch ex As Exception
                    old_porteMonie = 0
                End Try

                old_porteMonie += rest
                where.Add("porte_Monie", old_porteMonie)

                c.UpdateRecord(clientTable, where, params)
                where.Clear()
                params.Clear()
                lb_PorteMonie.Text = old_porteMonie.ToString("c")

                'insert conservation line 
                params.Add("name", ClientName)
                params.Add("clid", cid)
                params.Add("montant", -1 * rest)
                params.Add("way", "CONSERVATION")
                params.Add("date", Now.Date)
                params.Add("ech", Now.Date)
                params.Add("ref", "-")
                params.Add("desig", "-")
                params.Add("writer", Form1.adminName)
                params.Add(FactureTable, Id)

                Dim d_id As Integer = 0
                d_id = c.InsertRecord(payementTable, params, True)


                If d_id > 0 Then

                    where.Clear()
                    params.Clear()

                    If FactureTable = "Mission" Then
                        where.Add("Mid", Id)
                    Else
                        where.Add("id", Id)
                    End If
                     

                    params.Add("avance", Total)
                    params.Add("isPayed", True)
                    If c.UpdateRecord(FactureTable, params, where) Then
                        Avance = Total
                        Dim R As New AddPayementRow

                        R.Dock = DockStyle.Top
                        R.BringToFront()
                        R.Index = plPmBody.Controls.Count

                        AddHandler R.EditPayement, AddressOf Edit_Payement
                        AddHandler R.Cleared, AddressOf Delete_Payement

                        Dim pi As New Payement(d_id, Now.Date, "CONSERVATION", CDbl(-1 * rest), Now.Date, "-", "-")
                        R.Payement = pi

                        R.id = d_id
                        R.EditMode = True
                        R.Index = plPmBody.Controls.Count
                        If d_id > 0 Then
                            plPmBody.Controls.Add(R)
                        End If


                    End If
                End If

            End Using
        Catch ex As Exception
        End Try



    End Sub
End Class