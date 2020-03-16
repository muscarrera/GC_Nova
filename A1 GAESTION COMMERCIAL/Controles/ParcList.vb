Public Class ParcList

    Event AddNewDriver(ByVal ds As ParcList, ByVal clientRow As ClientRow)
    Event AddNewVehicule(ByVal ds As ParcList, ByVal clientRow As ClientRow)
    Event AddNewMission(ByVal ds As ParcList)
    Event GetElements(ByRef parcList As ParcList)
    Event GetElementsById(ByVal value As Integer, ByRef parcList As ParcList)
    Event DeleteSelectedElement(ByVal ds As ParcList, ByVal elm As ClientRow)
    Event EditSelectedVehicule(ByVal ds As ParcList, ByVal elm As ClientRow)
    Event EditSelectedDriver(ByVal parcList As ParcList, ByVal elm As ClientRow)
    Event GetElementInfos(ByVal ds As ParcList, ByVal id As Integer)
    Event SearchByDate(ByRef parcList As ParcList)

    Event AddFiles(ByRef ds As ParcList)
    Event NewBcRef(ByRef ds As ParcList)
    Event ClientChanged(ByRef ds As ParcList)
    Event DriverChanged(ByRef ds As ParcList)
    Event VehiculeChanged(ByRef ds As ParcList)
    Event SaveMissionChanges(ByRef parcList As ParcList)
    Event MissionFactured(ByRef parcList As ParcList)
    Event MissionSolde(ByRef parcList As ParcList)
    Event MissionDuplicate(ByRef parcList As ParcList)
    Event DeleteMission(ByVal _id As Integer, ByRef parcList As ParcList)
    Event SavePdf(ByRef parcList As ParcList)
    Event PramsPrint(ByVal parcList As ParcList)
    Event PrintMission(ByVal parcList As ParcList)
    Event GetClientDetails(ByVal _cid As Integer)
    Event GetDeiverDetails(ByVal _drid As Integer)
    Event GetVehiculeDetails(ByVal ds As ParcList, ByVal _vid As Integer)
    Event AddNewChargeMission(ByVal k As String, ByVal v As Double, ByVal parcList As ParcList)
    Event AddNewDetailsMission(ByVal k As String, ByVal v As Double, ByVal q As Double, ByVal parcList As ParcList)
    Event PrintListOfParc(ByVal parcList As ParcList)
    Event addNewCharge(ByVal parcList As ParcList)
    Event EditNewCharge(ByVal parcList As ParcList)
    Event ReleveClientByDate(ByVal ds As ParcList)
    Event GetListOfDomain(ByVal ds As ParcList)
    Event GetTransportById(ByVal value As Integer, ByRef ds As ParcList)
    Event SaveTransportChanges(ByRef ds As ParcList)
    Event addNewTransport(ByRef ds As ParcList)
    Event TransportFactured(ByRef ds As ParcList)
    Event DeleteTransport(ByVal i As Integer, ByRef ds As ParcList)
    Event GetPriceOfDetails(ByVal ds As ParcList, ByVal str As String)
    Event EditMissionDate(ByVal parcList As ParcList)
    Event EditTransportDate(ByVal parcList As ParcList)
    Event EditSelectedCharge(ByVal parcList As ParcList, ByVal clientRow As ClientRow)



    Dim _date As Date
    Dim _cid As Integer
    Dim _vid As Integer
    Dim _did As Integer
    Dim _isAdmin As Boolean
    Dim _avc As Double
    Friend SearchWords As String
    Dim _id_T As Integer
    Dim _MissionBonTransport As Integer
    Dim id_Cleared As String

    Private startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Dim _mode As String
    Dim _id_M As Integer
    Dim _dt As DataTable
    Dim _client As A1_GAESTION_COMMERCIAL.Client

    Public TableName As String = "Mission"

    Public dt_Driver As DataTable
    Public dt_Vehicule As DataTable


    Public Property AutoCompleteSourceDetails() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtDKey.AutoCompleteSource = value
        End Set
    End Property
    Public Property AutoCompleteSourceCharges() As AutoCompleteStringCollection
        Get
            Return Nothing
        End Get
        Set(ByVal value As AutoCompleteStringCollection)
            txtCKey.AutoCompleteSource = value
        End Set
    End Property

    Public Property Mode() As String
        Get
            Return _mode
        End Get
        Set(ByVal value As String)
            _mode = value
            plList.Controls.Clear()

            If value.ToUpper = "LIST" Then
                plDetails.Dock = DockStyle.Left
                plDetails.Width = 1
                plTransport.Dock = DockStyle.Left
                plTransport.Width = 1
                plList.Dock = DockStyle.Fill
                plFooter.Height = 38
                Panel3.Height = 165
                plAddEdit.Visible = True

                plList.Controls.Clear()
                txtSearchName.text = ""
                RaiseEvent GetElements(Me)

            ElseIf value.ToUpper = "TRANSPORT" Then
                plList.Dock = DockStyle.Left
                plList.Width = 0
                plDetails.Dock = DockStyle.Left
                plDetails.Width = 1


                'plList.Visible = False
                'plDetails.Visible = False
                plTransport.Width = 666

                plTransport.Dock = DockStyle.Fill
                Panel3.Height = 60
                plAddEdit.Visible = False

                plFooter.Height = 0
            Else
                plList.Dock = DockStyle.Left
                plList.Width = 0
                plTransport.Dock = DockStyle.Left
                plTransport.Width = 1
                plDetails.Width = 666
                plDetails.Dock = DockStyle.Fill
                plDetails.BringToFront()
                Panel3.Height = 60
                plAddEdit.Visible = False

                plFooter.Height = 0
            End If

        End Set
    End Property

    Public Property id_M As Integer
        Get
            Return _id_M
        End Get
        Set(ByVal value As Integer)
            _id_M = value
            id_Cleared = value.ToString
            Form1.prefix = "Ms"

            If value.ToString.Length > 5 Then
                Form1.Ex_fact = value.ToString.Remove(2)
                id_Cleared = value.ToString.Remove(0, 2)

                Dim sss As Integer = CInt(id_Cleared)
                id_Cleared = sss.ToString

            End If

            lbId.Text = Form1.prefix & id_Cleared
            If value > 0 Then RaiseEvent GetElementsById(value, Me)
        End Set
    End Property
    Public Property id_T As Integer
        Get
            Return _id_T
        End Get
        Set(ByVal value As Integer)
            _id_t = value

            id_Cleared = value.ToString
            Form1.prefix = "BT"

            If value.ToString.Length > 5 Then
                Form1.Ex_fact = value.ToString.Remove(2)
                id_Cleared = value.ToString.Remove(0, 2)

                Dim sss As Integer = CInt(id_Cleared)
                id_Cleared = sss.ToString

            End If


            lbTransId.Text = Form1.prefix & id_Cleared

            If value > 0 Then RaiseEvent GetTransportById(value, Me)
        End Set
    End Property
    Public Property MissionBonTransport As Integer
        Get
            Return _MissionBonTransport
        End Get
        Set(ByVal value As Integer)
            _MissionBonTransport = value
            lbMissionBon.Text = "--"
            If value > 0 Then lbMissionBon.Text = "Bon de Transport : " & value

        End Set
    End Property
    Public Property cid As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value
            If value > 0 Then RaiseEvent GetListOfDomain(Me)
        End Set
    End Property
    Public Property vid As Integer
        Get
            Return _vid
        End Get
        Set(ByVal value As Integer)
            _vid = value
        End Set
    End Property
    Public Property drid As Integer
        Get
            Return _did
        End Get
        Set(ByVal value As Integer)
            _did = value
        End Set
    End Property

    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
            If Not IsNothing(value) Then
                cid = value.cid
                ClientName = value.name
                Dim str As String = "[" & value.cid & "]"
                str &= value.adresse
                str &= vbNewLine
                str &= "ICE: " & value.ICE

                lbInfo.Text = str
                lbTransportClientInfos.Text = str
            End If
        End Set
    End Property
    Public Property ClientName() As String
        Get
            Dim n = lbTransportClienName.Text
            If TableName = "Mission" Then n = lbName.Text

            Return n
        End Get
        Set(ByVal value As String)

            If TableName = "Mission" Then
                lbName.Text = value
            Else
                lbTransportClienName.Text = value
            End If
        End Set
    End Property
    Public Property Domain() As String
        Get
            Return txtDomainName.text
        End Get
        Set(ByVal value As String)
            txtDomainName.text = value.ToUpper
        End Set
    End Property
    Public Property Bc As String
        Get
            Return lbBc.Text
        End Get
        Set(ByVal value As String)
            lbBc.Text = value
        End Set
    End Property
    Public Property isAdmin As Boolean
        Get
            Return _isAdmin
        End Get
        Set(ByVal value As Boolean)
            _isAdmin = value
            If value Then
                txtStatus.text = "Fini"
            Else
                txtStatus.text = "Creation"
            End If

        End Set
    End Property
    Property [date] As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            lbDateMission.Text = "Date " & value.ToString("dd MMM yyyy")
        End Set
    End Property
    Property date_Transport As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            lbDateTrans.Text = "Date :" & value.ToString("dd MMM yyyy")
        End Set
    End Property
    Property depart As String
        Get
            Return txtdepart.text
        End Get
        Set(ByVal value As String)
            txtdepart.text = value
        End Set
    End Property
    Property arrive As String
        Get
            Return txtdest.text
        End Get
        Set(ByVal value As String)
            txtdest.text = value
        End Set
    End Property
    Property isFactured As Boolean
        Get
            Return Not btFacturer.Enabled
        End Get
        Set(ByVal value As Boolean)
            btFacturer.Enabled = Not value
            btSolde.Enabled = Not value
            If value Then lbAvc.Text = "Facturé"
        End Set
    End Property
    Property isFactured_Transport As Boolean
        Get
            Return Not btFacture_Trans.Enabled
        End Get
        Set(ByVal value As Boolean)
            btFacture_Trans.Enabled = Not value
            btSolde_Trans.Enabled = Not value
            'If value Then lbAvc.Text = "Facturé"
        End Set
    End Property
    Property pj As Integer
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)
            lbpj.Text = value & " Fichies"
            pbJoindre_Mission.Visible = True

            If value = 0 Then
                lbpj.Text = "Joindre des fichiers"
                pbJoindre_Mission.Visible = False
            End If
        End Set
    End Property
    Property writer As String
        Get
            If TableName = "Mission" Then
                Return lbwriterMission.Text
            Else
                Return lbwriterTrans.Text
            End If

        End Get
        Set(ByVal value As String)

            If TableName = "Mission" Then
                lbwriterMission.Text = value
            Else
                lbwriterTrans.Text = value
            End If


        End Set
    End Property
    Property km_D As Integer
        Get
            If IsNumeric(txtKmDepart.text) Then
                Return CInt(txtKmDepart.text)
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            txtKmDepart.text = value
        End Set
    End Property
    Property km_A As Integer
        Get
            If IsNumeric(txtKmArrive.text) Then
                Return CInt(txtKmArrive.text)
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            txtKmArrive.text = value
        End Set
    End Property
    Property vehiculeName As String
        Get
            Return lbVehiculeName.Text
        End Get
        Set(ByVal value As String)
            lbVehiculeName.Text = value
        End Set
    End Property
    Property vehiculeRef As String
        Get
            Return lbVehiculeInfo.Text
        End Get
        Set(ByVal value As String)
            lbVehiculeInfo.Text = value
        End Set
    End Property
    Property DriverName As String
        Get
            Return lbDriverName.Text
        End Get
        Set(ByVal value As String)
            lbDriverName.Text = value
        End Set
    End Property
    Property DriverInfo As String
        Get
            Return lbDriverInfo.Text
        End Get
        Set(ByVal value As String)
            lbDriverInfo.Text = value
        End Set
    End Property
    Property DataSource As DataTable
        Get
            If plList.Controls.Count = 0 Then
                Return Nothing
            Else
                Dim c = plList.Controls(0)
                If TypeOf c Is AddElement Then Return Nothing
            End If

            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
            startIndex = 0
            'lastIndex = value.Rows.Count
            lastIndex = 0
            numberOfItems = Form1.numberOfItems
            numberOfPage = Math.Truncate(value.Rows.Count / numberOfItems)
            If value.Rows.Count Mod numberOfItems > 0 Then numberOfPage += 1
            currentPage = 1

            FillRows()

            btPage.Text = "1/" & numberOfPage

            Try
                lbLnbr.Text = value.Rows.Count
                lbLtotal.Text = ""
                lbLavc.Text = ""

                Dim sum As Double = Convert.ToDouble(_dt.Compute("SUM(total)", String.Empty))
                lbLtotal.Text = String.Format("{0:n}", CDec(sum))
                Dim avc As Double = Convert.ToDouble(_dt.Compute("SUM(avance)", String.Empty))
                lbLavc.Text = String.Format("{0:n}", avc)

            Catch ex As Exception
                Try
                    Dim SM = _dt.AsEnumerable().Aggregate(0, Function(n, r) PriceField(r) + n)
                    lbLtotal.Text = String.Format("{0:n}", CDec(SM))
                Catch exe As Exception
                End Try
            End Try


        End Set
    End Property
    Private Shared Function PriceField(ByVal r As DataRow) As Integer
        Dim v As Integer
        Return If(Integer.TryParse(If((TryCast(r("value"), String)), String.Empty), v), v, 0)
    End Function

    ReadOnly Property DetailsSource As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("value", GetType(Integer))
            table.Columns.Add("qte", GetType(Integer))

            Dim a As AddElement
            For Each a In plDBody.Controls()
                ' Add  rows with those columns filled in the DataTable.
                table.Rows.Add(a.Key, a.price, a.qte)
            Next
            Return table
        End Get
    End Property
    Public ReadOnly Property SelectedItem() As ClientRow
        Get
            Dim i As ClientRow = Nothing
            Try
                For Each c As ClientRow In plList.Controls
                    If c.isSelected Then
                        i = c
                        Exit For
                    End If
                Next
            Catch ex As Exception
            End Try

            Return i
        End Get
    End Property
    Public Property Avance As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            lbAvc.Text = String.Format("{0:n}", value)
            If isFactured Then lbAvc.Text = "Facturé"
        End Set
    End Property
    Public Property Avance_Transport As Double
        Get
            Return TB.avance
        End Get
        Set(ByVal value As Double)
            TB.avance = value
        End Set
    End Property
    Public ReadOnly Property Total As Double
        Get
            Dim t As Double = 0

            For Each a As AddElement In plDBody.Controls
                t += a.Total
            Next
            Return t
        End Get
    End Property
    Public ReadOnly Property Total_Transport As Double
        Get
            Return TB.TotalHt
        End Get
    End Property
    Public ReadOnly Property TotalCharge As Double
        Get
            Dim t As Double = 0

            For Each a As AddElement In plCBody.Controls
                t += a.Total
            Next
            Return t
        End Get
    End Property
    Public ReadOnly Property isPayed As Boolean
        Get
            If isFactured Then Return True
            Return Avance >= Total
        End Get
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub Clear()
        plList.Controls.Clear()
        'plDetails.Controls.Clear()

    End Sub

    Private Sub FillRows()

        'If IsNothing(DataSource) Then Exit Sub

        plList.Controls.Clear()

        If _dt.Rows.Count > 0 Then
            'Dim n = numberOfItems
            'If _dt.Rows.Count - lastIndex < numberOfItems Then n = _dt.Rows.Count - lastIndex
            If _dt.Rows.Count - lastIndex < numberOfItems Then
                'n = _dt.Rows.Count - lastIndex
                lastIndex = _dt.Rows.Count - 1
            Else
                lastIndex += numberOfItems
            End If

            'Dim arr(n) As ClientRow
            Dim arr(_dt.Rows.Count - 1) As ClientRow
            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ClientRow

                If TableName = "Mission" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("clientName")
                    a.lbType.Text = DteValue(_dt, "date", i).ToString("dd MMM, yyyy")
                    a.Responsable = StrValue(_dt, "depart", i) & " - " & StrValue(_dt, "arrive", i)
                    a.Tel = String.Format("{0:n}", DblValue(_dt, "total", i))

                    Dim vid As Integer = IntValue(_dt, "vid", i)
                    Try
                        If vid > 0 Then
                            Dim query = From d In dt_Vehicule.AsEnumerable()
                                        Where d.Field(Of Integer)(0) = vid
                                        Select d

                            Dim r As DataTable = query.CopyToDataTable()

                            a.Ville = r.Rows(0).Item("ref")
                        End If
                    Catch ex As Exception
                    End Try

                    If BoolValue(_dt, "isPayed", i) Then a.lbTel.BackColor = Color.PaleGreen
                    If IntValue(_dt, "Bon_Transport", i) > 0 Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                ElseIf TableName = "Bon_Transport" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("name")
                    a.lbType.Text = DteValue(_dt, "date", i).ToString("dd MMM, yyyy")
                    a.Responsable = StrValue(_dt, "delai", i)
                    a.Tel = String.Format("{0:n}", DblValue(_dt, "total", i))
                    a.Ville = String.Format("{0:n}", DblValue(_dt, "avance", i))

                    If BoolValue(_dt, "isPayed", i) Then a.lbTel.BackColor = Color.PaleGreen
                    If BoolValue(_dt, "isFactured", i) Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                ElseIf TableName = "Details_Charge" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("name")
                    a.lbType.Text = DteValue(_dt, "date", i).ToString("dd MMM, yyyy")
                    a.Tel = StrValue(_dt, "value", i)
                    If IntValue(_dt, "mid", i) > 0 Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                    Dim vid As Integer = IntValue(_dt, "vid", i)
                    Dim drid As Integer = IntValue(_dt, "drid", i)

                    Try
                        If vid > 0 Then
                            Dim query = From d In dt_Vehicule.AsEnumerable()
                                        Where d.Field(Of Integer)(0) = vid
                                        Select d

                            Dim r As DataTable = query.CopyToDataTable()
                            a.Responsable = r.Rows(0).Item("ref")
                        End If

                        If drid > 0 Then
                            Dim query = From d In dt_Driver.AsEnumerable()
                                          Where d.Field(Of Integer)(0) = drid
                                          Select d

                            Dim r As DataTable = query.CopyToDataTable()
                            a.Ville = r.Rows(0).Item("name")
                        End If
                    Catch ex As Exception
                    End Try

                ElseIf TableName = "Vehicule" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("name")
                    a.lbType.Text = StrValue(_dt, "ref", i)
                    a.Responsable = StrValue(_dt, "carb", i)
                    a.Ville = StrValue(_dt, "km", i)
                    a.Tel = StrValue(_dt, "year", i)

                    If StrValue(_dt, "info", i).Length > 3 Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                ElseIf TableName = "Driver" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("name")
                    a.lbType.Text = StrValue(_dt, "cin", i)
                    a.Responsable = StrValue(_dt, "tel", i)
                    a.Ville = StrValue(_dt, "adresse", i)
                    a.Tel = StrValue(_dt, "date", i)
                End If

                a.Index = i
                a.Dock = DockStyle.Top
                a.BringToFront()
                arr(i - startIndex) = a

                AddHandler a.EditSelectedItem, AddressOf EditSelectedClient
                AddHandler a.DeleteItem, AddressOf DeleteSelectedClient
                AddHandler a.GetFactureInfos, AddressOf GetClientInfos

                If i = lastIndex Then Exit For
            Next
            plList.Controls.AddRange(arr)
            startIndex = i
        End If
    End Sub
    Private Sub HeaderColor(ByVal value As String)
        For Each b As Control In plHeader.Controls
            If b.Text = value Then
                b.BackColor = Color.PaleGreen
                b.ForeColor = Color.Green
            Else
                b.BackColor = Color.WhiteSmoke
                b.ForeColor = Color.DarkGray
            End If
        Next
    End Sub
    Sub RemoveElement(ByVal ls As ClientRow)
        plList.Controls.Remove(ls)
    End Sub

    'bt Mission
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        If id_M > 0 Then RaiseEvent SaveMissionChanges(Me)
        If id_T > 0 Then RaiseEvent SaveTransportChanges(Me)
        'plAddEdit.Height = 0
        HeaderColor(Button11.Text)
        TableName = Button11.Tag
        Mode = "List"
        id_M = 0
        id_T = 0
    End Sub
    'bt Driver & vehicule
    Private Sub btClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFournisseur.Click, btClient.Click
        If id_M > 0 Then RaiseEvent SaveMissionChanges(Me)
        If id_T > 0 Then RaiseEvent SaveTransportChanges(Me)
        plAddEdit.Height = 38
        Dim bt As Button = sender
        HeaderColor(bt.Text)
        TableName = bt.Tag

        Mode = "List"
        id_T = 0
        id_M = 0
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        If id_M > 0 Then RaiseEvent SaveMissionChanges(Me)
        If id_T > 0 Then RaiseEvent SaveTransportChanges(Me)
        HeaderColor(Button15.Text)
        TableName = Button15.Tag
        Mode = "List"
        id_M = 0
        id_T = 0
    End Sub
    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If id_M > 0 Then RaiseEvent SaveMissionChanges(Me)
        If id_T > 0 Then RaiseEvent SaveTransportChanges(Me)
        'plAddEdit.Height = 0
        HeaderColor(Button5.Text)
        TableName = Button5.Tag
        Mode = "List"
        id_M = 0
        id_T = 0
    End Sub

    'Elements Row
    Private Sub EditSelectedClient(ByRef elm As ClientRow)
        If TableName = "Driver" Then
            RaiseEvent EditSelectedDriver(Me, elm)

        ElseIf TableName = "Vehicule" Then
            RaiseEvent EditSelectedVehicule(Me, elm)

        ElseIf TableName = "Details_Charge" Then
            RaiseEvent EditSelectedCharge(Me, elm)

        ElseIf TableName = "Mission" Then
            id_M = elm.Id

        ElseIf TableName = "Bon_Transport" Then
            id_T = elm.Id
            'RaiseEvent GetElementsById(, Me)
        End If
    End Sub
    Private Sub DeleteSelectedClient(ByRef elm As ClientRow)
        RaiseEvent DeleteSelectedElement(Me, elm)
    End Sub
    Private Sub GetClientInfos(ByVal _id As Integer)
        RaiseEvent GetElementInfos(Me, _id)
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If TableName = "Driver" Then
            RaiseEvent AddNewDriver(Me, SelectedItem)
        ElseIf TableName = "Vehicule" Then
            RaiseEvent AddNewVehicule(Me, SelectedItem)
        ElseIf TableName = "Mission" Then
            RaiseEvent AddNewMission(Me)
        ElseIf TableName = "Bon_Transport" Then
            RaiseEvent addNewTransport(Me)
        ElseIf TableName = "Details_Charge" Then
            RaiseEvent addNewCharge(Me)
        End If
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEdit.Click
        Try
            If TableName = "Driver" Then
                RaiseEvent EditSelectedDriver(Me, SelectedItem)

            ElseIf TableName = "Vehicule" Then
                RaiseEvent EditSelectedVehicule(Me, SelectedItem)

            ElseIf TableName = "Details_Charge" Then
                RaiseEvent EditSelectedCharge(Me, SelectedItem)

            ElseIf TableName = "Mission" Then
                id_M = SelectedItem.Id

            ElseIf TableName = "Bon_Transport" Then
                id_T = SelectedItem.Id

            ElseIf TableName = "Details_Charge" Then
                RaiseEvent EditNewCharge(Me)
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        If MsgBox(MsgDelete & vbNewLine & TableName & " : " & SelectedItem.Id, MsgBoxStyle.YesNo, "Suppression") = MsgBoxResult.Yes Then
            RaiseEvent DeleteSelectedElement(Me, SelectedItem)
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If currentPage = numberOfPage Then Exit Sub
        currentPage += 1

        FillRows()

        btPage.Text = currentPage & "/" & numberOfPage
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If currentPage = 1 Then Exit Sub
        currentPage -= 1
        startIndex -= numberOfItems * 2
        If startIndex < 0 Then startIndex = 0

        lastIndex -= numberOfItems * 2
        If lastIndex < 0 Then lastIndex = 0

        FillRows()

        btPage.Text = currentPage & "/" & numberOfPage
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        RaiseEvent GetElements(Me)
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbSearchDate.Click
        RaiseEvent SearchByDate(Me)
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        RaiseEvent AddFiles(Me)
    End Sub
    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        RaiseEvent NewBcRef(Me)
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        RaiseEvent ClientChanged(Me)
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        RaiseEvent DriverChanged(Me)
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        RaiseEvent VehiculeChanged(Me)
    End Sub
    Private Sub plDBody_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plDBody.ControlAdded, plDBody.ControlRemoved
        If plDBody.Controls.Count > 3 Then
            plD.Height = plDBody.Controls(0).Height * plDBody.Controls.Count + 150
        Else
            plD.Height = 330
        End If

        lbTotal.Text = String.Format("{0:n}", Total)
    End Sub
    Private Sub plCBody_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plCBody.ControlAdded, plCBody.ControlRemoved
        If plCBody.Controls.Count > 3 Then
            plC.Height = plCBody.Controls(0).Height * plCBody.Controls.Count + 150
        Else
            plC.Height = 330
        End If

        lbTotalCharge.Text = String.Format("{0:n}", TotalCharge)
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If plD.Height > 60 Then
            plD.Height = 60
            PictureBox3.BackgroundImage = My.Resources.ADD14
        Else
            plD.Height = 330
            PictureBox3.BackgroundImage = My.Resources.SUB14
            plDBody_ControlAdded(Nothing, Nothing)
        End If
    End Sub
    Private Sub PictureBox1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If plMissionHeader.Height > 105 Then
            plMissionHeader.Height = 105
            PictureBox1.BackgroundImage = My.Resources.ADD14
        Else
            plMissionHeader.Height = 366
            PictureBox1.BackgroundImage = My.Resources.SUB14
        End If
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        If plC.Height > 60 Then
            plC.Height = 60
            PictureBox4.BackgroundImage = My.Resources.ADD14
        Else
            plC.Height = 330
            PictureBox4.BackgroundImage = My.Resources.SUB14
        End If
    End Sub
    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        RaiseEvent SaveMissionChanges(Me)
    End Sub
    Private Sub btFacturer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFacturer.Click
        RaiseEvent MissionFactured(Me)
    End Sub
    Private Sub btSolde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSolde.Click
        'RaiseEvent MissionSolde(Me)
    End Sub
    Private Sub btDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDuplicate.Click
        RaiseEvent SaveMissionChanges(Me)
        RaiseEvent MissionDuplicate(Me)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox(MsgDelete & vbNewLine & "Mission : " & id_M, MsgBoxStyle.YesNo, "Suppression") = MsgBoxResult.Yes Then
            RaiseEvent DeleteMission(id_M, Me)
        End If
    End Sub
    Private Sub btPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPdf.Click
        RaiseEvent SavePdf(Me)
    End Sub
    Private Sub btParamsImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btParamsImp.Click
        RaiseEvent PramsPrint(Me)
    End Sub
    Private Sub btPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPrint.Click
        RaiseEvent PrintMission(Me)
    End Sub
    Private Sub LbNewFacture_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LbNewFacture.LinkClicked
        If id_M > 0 Then RaiseEvent SaveMissionChanges(Me)
        RaiseEvent AddNewMission(Me)
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent GetClientDetails(cid)
    End Sub
    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If drid = 0 Then Exit Sub

        RaiseEvent GetDeiverDetails(drid)
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If vid = 0 Then Exit Sub
        RaiseEvent GetVehiculeDetails(Me, vid)
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If txtDKey.text = "" Or txtDPrix.text = "" Then Exit Sub
        If txtDQte.text = "" Then txtDQte.text = 1

        Dim k As String = txtDKey.text
        Dim v As Double = CDbl(txtDPrix.text)
        Dim q As Double = CDbl(txtDQte.text)

        RaiseEvent AddNewDetailsMission(k, v, q, Me)
    End Sub
    Private Sub txtDValue_KeyDownOk() Handles txtDPrix.KeyDownOk
        If txtDKey.text = "" Or txtDPrix.text = "" Then Exit Sub

        If txtDQte.text.Trim = "" Then txtDQte.text = 1

        Dim k As String = txtDKey.text
        Dim v As Double = CDbl(txtDPrix.text)
        Dim q As Double = CDbl(txtDQte.text)

        RaiseEvent AddNewDetailsMission(k, v, q, Me)
        txtDKey.Focus()
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If txtCKey.text = "" Or txtCValue.text = "" Then Exit Sub

        Dim k As String = txtCKey.text
        Dim v As Double = CDbl(txtCValue.text)

        RaiseEvent AddNewChargeMission(k, v, Me)
        txtCKey.Focus()
    End Sub
    Private Sub txtCValue_KeyDownOk() Handles txtCValue.KeyDownOk
        If txtCKey.text = "" Or txtCValue.text = "" Then Exit Sub

        Dim k As String = txtCKey.text
        Dim v As Double = CDbl(txtCValue.text)

        RaiseEvent AddNewChargeMission(k, v, Me)
    End Sub
    Private Sub txtCKey_KeyDownOk() Handles txtCKey.KeyDownOk

        If txtCKey.text.Contains("(") Then
            txtCValue.Focus()
        Else
            txtCKey.text &= " ( )"
            txtCKey.Select(txtCKey.text.Length - 1, 0)
        End If
    End Sub
    Private Sub txtDKey_KeyDownOk() Handles txtDKey.KeyDownOk, txtDomainName.KeyDownOk
        If txtDKey.text.Trim = "" Then Exit Sub
        Try
            If depart.Trim <> "" And arrive.Trim <> "" Then RaiseEvent GetPriceOfDetails(Me, txtDKey.text)

        Catch ex As Exception
        End Try

        txtDQte.Focus()
    End Sub
    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click, Panel21.Click
        txtDKey.Focus()
    End Sub
    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click, Panel57.Click, Panel46.Click, Label24.Click
        txtDPrix.Focus()
    End Sub
    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel62.Click, Label25.Click
        txtCKey.Focus()
    End Sub
    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel63.Click, Label26.Click
        txtCValue.Focus()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btImpList.Click
        If plList.Controls.Count = 0 Then Exit Sub
        RaiseEvent PrintListOfParc(Me)
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel19.Click, Label9.Click
        txtdepart.Focus()
    End Sub
    Private Sub txtdepart_KeyDownOk() Handles txtdepart.KeyDownOk
        txtdest.Focus()
    End Sub
    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel31.Click, Label16.Click
        txtdest.Focus()
    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel4.Click, Label4.Click
        txtKmDepart.Focus()
    End Sub
    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel61.Click, Label18.Click
        txtKmArrive.Focus()
    End Sub

    Private Sub txtSearchName_KeyDownOk() Handles txtSearchName.KeyDownOk
        RaiseEvent GetElements(Me)
    End Sub

    Private Sub txtDQte_KeyDownOk() Handles txtDQte.KeyDownOk
        If txtDPrix.text <> "" And IsNumeric(txtDPrix.text) Then
            txtDValue_KeyDownOk()
        Else
            txtDPrix.Focus()
        End If
    End Sub

    Private Sub Button10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent ReleveClientByDate(Me)
    End Sub

    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel47.Click, Label27.Click
        txtDomainName.Focus()
    End Sub


    Private Sub LinkLabel13_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel13.LinkClicked
        RaiseEvent ReleveClientByDate(Me)
    End Sub

    Private Sub plTransBody_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plTransBody.ControlAdded, plTransBody.ControlRemoved
        If plTransBody.Controls.Count > 3 Then
            plTransBody.Height = plTransBody.Controls(0).Height * plTransBody.Controls.Count + 15
        Else
            plTransBody.Height = 111
        End If

        If Mode = "LIST" Then Exit Sub

        Dim T As Double = 0
        Dim R As Double = 0
        Dim tva As Double = 0

        For Each C As AddElement In plTransBody.Controls
            T += C.Total
        Next

        TB.TotalHt = T
        TB.Remise = 0
        TB.TVA = T * Form1.tva / 100
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        RaiseEvent SaveTransportChanges(Me)
    End Sub

    Private Sub btFacture_Trans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFacture_Trans.Click
        RaiseEvent TransportFactured(Me)
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        If MsgBox(MsgDelete & vbNewLine & "Bon de Transport : " & id_T, MsgBoxStyle.YesNo, "Suppression") = MsgBoxResult.Yes Then
            RaiseEvent DeleteTransport(id_T, Me)
        End If
    End Sub

    Private Sub btSolde_Trans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSolde_Trans.Click
        RaiseEvent MissionSolde(Me)
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        RaiseEvent PrintMission(Me)
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        RaiseEvent SavePdf(Me)
    End Sub

    Private Sub lbDateMission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDateMission.Click
        RaiseEvent EditMissionDate(Me)
    End Sub

    Private Sub lbDateTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDateTrans.Click
        RaiseEvent EditTransportDate(Me)
    End Sub
End Class
