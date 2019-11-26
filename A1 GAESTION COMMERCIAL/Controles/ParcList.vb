Public Class ParcList

    Private startIndex, lastIndex, numberOfPage, numberOfItems, currentPage As Integer
    Dim _mode As String
    Dim _id As Integer

    Dim _dt As DataTable

    Public TableName As String = "Mission"

    Event GetElementInfos(ByVal ds As ParcList, ByVal id As Integer)
    Event DeleteSelectedElement(ByVal ds As ParcList, ByVal elm As ClientRow)
    Event EditSelectedElement(ByVal ds As ParcList, ByVal elm As ClientRow)


    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property Mode() As String
        Get
            Return _mode
        End Get
        Set(ByVal value As String)
            _mode = value
            plDetails.Controls.Clear()
            plList.Controls.Clear()

            If value = "List" Then
                plDetails.Dock = DockStyle.Left
                plDetails.Width = 0
                plList.Dock = DockStyle.Fill
                plFooter.Height = 38

            Else
                plList.Dock = DockStyle.Left
                plList.Width = 0
                plDetails.Dock = DockStyle.Fill
                plFooter.Height = 0

            End If


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
        End Set
    End Property


    Private Sub FillRows()
        pl.Controls.Clear()

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
            pl.Controls.AddRange(arr)
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
    'bt Mission
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        plAddEdit.Height = 0
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
        RaiseEvent EditSelectedElement(Me, elm)
    End Sub
    Private Sub DeleteSelectedClient(ByRef elm As ClientRow)
        RaiseEvent DeleteSelectedElement(Me, elm)
    End Sub
    Private Sub GetClientInfos(ByVal _id As Integer)
        RaiseEvent GetElementInfos(Me, _id)
    End Sub

End Class
