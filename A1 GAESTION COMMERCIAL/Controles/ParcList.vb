Public Class ParcList

    Dim _date As Date
    Dim _cid As Integer
    Dim _vid As Integer
    Dim _did As Integer
    Dim _isAdmin As Boolean
    Dim _avc As Double


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



    Private startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Dim _mode As String
    Dim _id As Integer
    Dim _dt As DataTable
    Dim _client As A1_GAESTION_COMMERCIAL.Client

    Public TableName As String = "Mission"

    Event SaveChanges(ByRef parcList As ParcList)
    Event MissionFactured(ByRef parcList As ParcList)
    Event MissionSolde(ByRef parcList As ParcList)
    Event MissionDuplicate(ByRef parcList As ParcList)
    Event DeleteMission(ByVal _id As Integer, ByRef parcList As ParcList)
    Event SavePdf(ByRef parcList As ParcList)
    Event PramsPrint(ByVal parcList As ParcList)
    Event PrintMission(ByVal parcList As ParcList)
    Event GetClientDetails(ByVal _cid As Integer)
    Event GetDeiverDetails(ByVal _drid As Integer)
    Event GetVehiculeDetails(ByVal _vid As Integer)

    Event AddNewChargeMission(ByVal k As String, ByVal v As Double, ByVal parcList As ParcList)

    Event AddNewDetailsMission(ByVal k As String, ByVal v As Double, ByVal parcList As ParcList)


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

            If value = "List" Then
                plDetails.Dock = DockStyle.Left
                plDetails.Width = 1
                plList.Dock = DockStyle.Fill
                plFooter.Height = 38
                Panel3.Height = 165
                plAddEdit.Visible = True

                plList.Controls.Clear()
                txtSearchName.text = ""
                RaiseEvent GetElements(Me)

            Else
                plList.Dock = DockStyle.Left
                plList.Width = 0
                plDetails.Width = 666
                plDetails.BringToFront()
                Panel3.Height = 60
                plAddEdit.Visible = False
                plDetails.Dock = DockStyle.Fill
                plFooter.Height = 0

            End If

        End Set
    End Property
    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            lbId.Text = id
            If value > 0 Then RaiseEvent GetElementsById(value, Me)
        End Set
    End Property
    Public Property cid As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value
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
                str &= vbNewLine
                str &= value.adresse
                str &= vbNewLine
                str &= "Tel: " & value.tel & " - " & "ICE : " & value.cid
                lbInfo.Text = str
            End If
        End Set
    End Property
    Public Property ClientName() As String
        Get
            Return lbName.Text
        End Get
        Set(ByVal value As String)
            lbName.Text = value
        End Set
    End Property
    Public Property MissionDate() As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            lbDate.Text = value.ToString("dd MMM yyyy")
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
    Public Property Avance As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            lbAvc.Text = String.Format("{0:n}", value)
        End Set
    End Property
    Property [date] As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            lbDate.Text = "Date " & value.ToString("dd MMM yyyy")
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
        End Set
    End Property
    Property pj As Integer
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)
            lbpj.Text = value & " Fichies"
            pbJoindre.Visible = True

            If value = 0 Then
                lbpj.Text = "Joindre des fichiers"
                pbJoindre.Visible = False
            End If
        End Set
    End Property
    Property writer As String
        Get
            Return lbwriter.Text
        End Get
        Set(ByVal value As String)
            lbwriter.Text = value
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
    Property vehiculeInfo As String
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
            Return _dt
        End Get
        Set(ByVal value As DataTable)
            _dt = value
            startIndex = 0
            lastIndex = value.Rows.Count
            numberOfItems = Form1.numberOfItems
            numberOfPage = Math.Truncate(lastIndex / numberOfItems)
            If lastIndex Mod numberOfItems > 0 Then numberOfPage += 1
            currentPage = 1

            FillRows()

            btPage.Text = "1/" & numberOfPage

            Try

                lbLnbr.Text = value.Rows.Count
                lbLtotal.Text = ""
                lbLavc.Text = ""

                Dim sum As Double = Convert.ToDouble(_dt.Compute("SUM(total)", String.Empty))
                lbLtotal.Text = String.Format("{à,n}", sum)
                Dim avc As Double = Convert.ToDouble(_dt.Compute("SUM(avance)", String.Empty))
                lbLavc.Text = String.Format("{à,n}", avc)

            Catch ex As Exception
            End Try


        End Set
    End Property
    Private ReadOnly Property SelectedItem() As ClientRow
        Get
            Dim i As ClientRow = Nothing
            Try
                For Each c As ClientRow In pl.Controls
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
    Public ReadOnly Property Total As Double
        Get
            Dim t As Double = 0

            For Each a As AddElement In plDBody.Controls
                t += a.Value
            Next
            Return t
        End Get
    End Property
    Public ReadOnly Property TotalCharge As Double
        Get
            Dim t As Double = 0

            For Each a As AddElement In plCBody.Controls
                t += a.Value
            Next
            Return t
        End Get
    End Property
    Public ReadOnly Property isPayed As Boolean
        Get
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
        plDetails.Controls.Clear()

    End Sub





    Private Sub FillRows()
        plList.Controls.Clear()

        If _dt.Rows.Count > 0 Then
            Dim n = numberOfItems
            If _dt.Rows.Count - lastIndex < numberOfItems Then n = _dt.Rows.Count - lastIndex
            Dim arr(_dt.Rows.Count - 1) As ClientRow
            Dim i As Integer = 0
            For i = startIndex To _dt.Rows.Count - 1

                Dim a As New ClientRow

                If TableName = "Mission" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("clientName")
                    a.lbType.Text = DteValue(_dt, "date", i).ToString("dd MMM, yyyy")
                    a.Responsable = StrValue(_dt, "depart", i)
                    a.Ville = StrValue(_dt, "arrive", i)
                    a.Tel = DblValue(_dt, "total", i)

                    If BoolValue(_dt, "isPayed", i) Then a.lbTel.BackColor = Color.PaleGreen
                    If BoolValue(_dt, "isAdmin", i) Then a.PlLeft.BackgroundImage = My.Resources.fav_16

                ElseIf TableName = "Vehicule" Then
                    a.Id = _dt.Rows(i).Item(0)
                    a.Libele = _dt.Rows(i).Item("name")
                    a.lbType.Text = StrValue(_dt, "marque", i)
                    a.Responsable = StrValue(_dt, "model", i)
                    a.Ville = StrValue(_dt, "km", i)
                    a.Tel = StrValue(_dt, "carb", i)

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
        'plAddEdit.Height = 0
        HeaderColor(Button11.Text)
        TableName = Button11.Tag
        Mode = "List"
    End Sub
    'bt Driver & vehicule
    Private Sub btClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFournisseur.Click, btClient.Click
        plAddEdit.Height = 38
        Dim bt As Button = sender
        HeaderColor(bt.Text)
        TableName = bt.Tag
        Mode = "List"

    End Sub





    'Elements Row
    Private Sub EditSelectedClient(ByRef elm As ClientRow)
        If TableName = "Driver" Then
            RaiseEvent EditSelectedDriver(Me, elm)
        ElseIf TableName = "Vehicule" Then
            RaiseEvent EditSelectedVehicule(Me, elm)
        ElseIf TableName = "Mission" Then
            RaiseEvent GetElementsById(elm.Id, Me)
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
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btEdit.Click
        If TableName = "Driver" Then
            RaiseEvent EditSelectedDriver(Me, SelectedItem)
        ElseIf TableName = "Vehicule" Then
            RaiseEvent EditSelectedVehicule(Me, SelectedItem)
        ElseIf TableName = "Mission" Then

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDelete.Click
        RaiseEvent DeleteSelectedElement(Me, SelectedItem)
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
        RaiseEvent SaveChanges(Me)
    End Sub

    Private Sub btFacturer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btFacturer.Click
        RaiseEvent MissionFactured(Me)
    End Sub

    Private Sub btSolde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSolde.Click
        RaiseEvent MissionSolde(Me)
    End Sub

    Private Sub btDuplicate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDuplicate.Click
        RaiseEvent MissionDuplicate(Me)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        RaiseEvent DeleteMission(id, Me)
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
        RaiseEvent AddNewMission(Me)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent GetClientDetails(cid)
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent GetDeiverDetails(drid)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        RaiseEvent GetVehiculeDetails(vid)
    End Sub

    Private Sub AddElement1_AddNewKeyVal(ByVal k As System.String, ByVal v As System.Double)
        RaiseEvent AddNewDetailsMission(k, v, Me)
    End Sub

    Private Sub AddElement2_AddNewKeyVal(ByVal k As System.String, ByVal v As System.Double)
        RaiseEvent AddNewChargeMission(k, v, Me)
    End Sub

   
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If txtDKey.text = "" Or txtDValue.text = "" Then Exit Sub

        Dim k As String = txtDKey.text
        Dim v As Double = CDbl(txtDValue.text)

        RaiseEvent AddNewDetailsMission(k, v, Me)
    End Sub

    Private Sub txtDValue_KeyDownOk() Handles txtDValue.KeyDownOk
        If txtDKey.text = "" Or txtDValue.text = "" Then Exit Sub

        Dim k As String = txtDKey.text
        Dim v As Double = CDbl(txtDValue.text)

        RaiseEvent AddNewDetailsMission(k, v, Me)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        If txtCKey.text = "" Or txtCValue.text = "" Then Exit Sub

        Dim k As String = txtCKey.text
        Dim v As Double = CDbl(txtCValue.text)

        RaiseEvent AddNewChargeMission(k, v, Me)
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
            '' txtDKey.Cursor
        End If
    End Sub
    Private Sub txtDKey_KeyDownOk() Handles txtDKey.KeyDownOk
        If txtDKey.text.Contains("(") Then
            txtDValue.Focus()
        Else
            txtDKey.text &= " ( )"
            '' txtDKey.Cursor
        End If
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label17.Click, Panel21.Click
        txtDKey.Focus()
    End Sub
    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label21.Click, Panel57.Click
        txtDValue.Focus()
    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel62.Click, Label25.Click
        txtCKey.Focus()
    End Sub
    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel63.Click, Label26.Click
        txtCValue.Focus()
    End Sub
End Class
