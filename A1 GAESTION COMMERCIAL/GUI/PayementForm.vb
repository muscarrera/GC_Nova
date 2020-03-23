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
                        R.EditMode = True
                        R.id = dt.Rows(i).Item(0)
                        R.Index = 1
                        R.Dock = DockStyle.Top
                        R.BringToFront()
                        AddHandler R.EditPayement, AddressOf Edit_Payement
                        AddHandler R.Cleared, AddressOf Delete_Payement
                        arr(i) = R
                    Next
                    plPmBody.Controls.AddRange(arr)


                    'getAvoir
                    If Form1.useSoldByAvoir Then
                        params.Clear()
                        params.Add("isPayement", False)
                        Dim av As Double = a.SelectByScalar("Sell_Avoir", "SUM(total) ", params)

                        lbAvoir.Text = av.ToString("F:2")


                        Label2.Visible = True
                        Panel7.Visible = True
                    End If

                    'get port Monie
                    If Form1.usePortMonie Then
                        params.Clear()
                        params.Add("Clid", cid)
                        Dim pm As Double = a.SelectByScalar(clientTable, "port_Monie", params)

                        lb_PorteMonie.Text = pm.ToString("F:2")


                        Label1.Visible = True
                        Panel8.Visible = True
                    End If

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
        End Set
    End Property
    Public Property Total As Double
        Get
            Return _ttc
        End Get
        Set(ByVal value As Double)
            _ttc = value
            lbLtotal.Text = String.Format("{0:n}", value)
        End Set
    End Property

    Private Sub PayementForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbRef.Text = "[" & ClientName & "/" & FactureTable & ": " & Form1.prefix & Id & "]"
    End Sub
    Private Sub FillBloc()
        Dim value As DataTable

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add(FactureTable, Id)
            value = a.SelectDataTable(payementTable, {"*"}, params)
            params = Nothing
        End Using

        plPmBody.Controls.Clear()
        If IsNothing(value) Then Exit Sub

        If value.Rows.Count > 0 Then
            Dim arr(value.Rows.Count - 1) As AddPayementRow

            For i As Integer = 0 To value.Rows.Count - 1
                Dim a As New Payement(value.Rows(i).Item(0), StrValue(value, "date", i),
                                       StrValue(value, "way", i), DblValue(value, "montant", i),
                                       StrValue(value, "ech", i), StrValue(value, "ref", i),
                                       StrValue(value, "desig", i))

                Dim R As New AddPayementRow
                R.Payement = a
                R.id = value.Rows(i).Item(0)
                R.Index = i
                R.Dock = DockStyle.Top
                R.BringToFront()
                AddHandler R.EditPayement, AddressOf Edit_Payement
                AddHandler R.Cleared, AddressOf Delete_Payement
                arr(i) = R
            Next
            plPmBody.Controls.AddRange(arr)
        End If
    End Sub

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
                    If Avance >= Total Then isPayed = True

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
                    If avc >= Total Then isPayed = True

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
                    If avc >= Total Then isPayed = True

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
End Class