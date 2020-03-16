Public Class Client_Remise

    Dim _cid As Integer = 0
    Dim _id As Integer = 0

    Public Property client_Id As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value

            If value > 0 Then
                GetData()
            End If
        End Set
    End Property
    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

            If value > 0 Then
                plleft.BackgroundImage = My.Resources.fav_16
            Else
                plleft.BackgroundImage = Nothing
            End If
        End Set
    End Property
    Public Function AutoCompleteByAll(ByVal tb As String) As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable(tb, {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString.ToUpper & "|" & dt.Rows(i).Item(0).ToString)
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function AutoCompleteBycat(ByVal cid As String) As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("cid", cid)

            Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString.ToUpper & "|" & dt.Rows(i).Item(0).ToString)
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function

    Private Sub GetData()

        DataGridView1.Rows.Clear()

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("clid", client_Id)

            Dim dt As DataTable = a.SelectDataTable("Client_Remise", {"*"}, params)
            If dt.Rows.Count > 0 Then
                Dim tp As String = "Famille"
                Dim nm As String

                For i As Integer = 0 To dt.Rows.Count - 1
                    tp = "Famille"
                    nm = dt.Rows(i).Item("cat_name")

                    If CInt(dt.Rows(i).Item("arid")) > 0 Then
                        tp = "Article"
                        nm = dt.Rows(i).Item("art_name")
                    End If

                    If CBool(dt.Rows(i).Item("all")) Then
                        tp = "Tous"
                        nm = "*"
                    End If


                    DataGridView1.Rows.Add(dt.Rows(i).Item(0),
                                           tp, nm, dt.Rows(i).Item("remise"))
                Next
            Else
                params.Clear()

                params.Add("clid", client_Id)
                params.Add("cid", 0)
                params.Add("arid", 0)
                params.Add("all", True)
                params.Add("cat_name", "*")
                params.Add("art_name", "*")
                params.Add("remise", 0)
                Dim IID = a.InsertRecord("Client_Remise", params, True)
                If IID > 0 Then
                    DataGridView1.Rows.Add(IID, "Tous", "*", 0)
                End If
            End If
        End Using
    End Sub
    Private Sub addData()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim ct = 0
            Dim ct_name = ""
            Dim ar = 0
            Dim ar_name = ""

            If txtCat.text.Contains("|") Then
                Dim str As String() = txtCat.text.Split("|")

                If IsNumeric(str(0)) Then
                    ct = str(0)
                    ct_name = str(1)
                Else
                    ct = str(1)
                    ct_name = str(0)
                End If
            End If


            If txtArt.text.Contains("|") Then
                Dim str As String() = txtArt.text.Split("|")

                If IsNumeric(str(0)) Then
                    ar = str(0)
                    ar_name = str(1)
                Else
                    ar = str(1)
                    ar_name = str(0)
                End If
            End If



            If ar > 0 Then
                params.Add("clid", client_Id)
                params.Add("arid", ar)

                Dim dt As DataTable = a.SelectDataTable("Client_Remise", {"*"}, params)
                If dt.Rows.Count > 0 Then
                    Id = dt.Rows(0).Item(0)
                    editData()
                    Exit Sub
                End If
            ElseIf ar = 0 And ct > 0 Then
                params.Clear()
                params.Add("clid", client_Id)
                params.Add("cid", ct)

                Dim dt As DataTable = a.SelectDataTable("Client_Remise", {"*"}, params)
                If dt.Rows.Count > 0 Then
                    Id = dt.Rows(0).Item(0)
                    editData()
                    Exit Sub
                End If
            End If



            If ar = 0 And ct = 0 Then Exit Sub


            params.Clear()
            params.Add("clid", client_Id)
            params.Add("cid", ct)
            params.Add("arid", ar)
            params.Add("all", False)
            params.Add("cat_name", ct_name)
            params.Add("art_name", ar_name)
            params.Add("remise", txtRemise.text)
            Dim IID = a.InsertRecord("Client_Remise", params, True)
            If IID > 0 Then

                Dim tp As String = "Famille"
                Dim nm As String

                tp = "Famille"
                nm = ct_name

                If CInt(ar) > 0 Then
                    tp = "Article"
                    nm = ar_name
                End If

                DataGridView1.Rows.Add(IID, tp, nm, txtRemise.text)
            End If
        End Using
    End Sub
    Private Sub editData()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            Dim ct = 0
            Dim ct_name = ""
            Dim ar = 0
            Dim ar_name = ""

            If txtCat.text.Contains("|") Then
                Dim str As String() = txtCat.text.Split("|")

                If IsNumeric(str(0)) Then
                    ct = str(0)
                    ct_name = str(1)
                Else
                    ct = str(1)
                    ct_name = str(0)
                End If
            End If


            If txtArt.text.Contains("|") Then
                Dim str As String() = txtArt.text.Split("|")

                If IsNumeric(str(0)) Then
                    ar = str(0)
                    ar_name = str(1)
                Else
                    ar = str(1)
                    ar_name = str(0)
                End If
            End If


            If ar = 0 And ct = 0 Then Exit Sub


            params.Add("clid", client_Id)
            params.Add("cid", ct)
            params.Add("arid", ar)
            params.Add("all", False)
            params.Add("cat_name", ct_name)
            params.Add("art_name", ar_name)
            params.Add("remise", txtRemise.text)

            Dim where As New Dictionary(Of String, Object)
            where.Add("id", Id)

            If a.UpdateRecord("Client_Remise", params, where) Then

            End If
        End Using

        GetData()
    End Sub


    Private Sub Client_Remise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCat.AutoCompleteSource = AutoCompleteByAll("Category")
        txtArt.AutoCompleteSource = AutoCompleteByAll("Article")




    End Sub

    Private Sub cbTous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbTous.CheckedChanged
        txtCat.Enabled = Not cbTous.Checked
        txtArt.Enabled = Not cbTous.Checked

    End Sub

    Private Sub txtCat_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCat.Leave
        If txtCat.text.Contains("|") Then
            Dim str As String() = txtCat.text.Split("|")
            Dim cid = 0

            If IsNumeric(str(0)) Then
                cid = str(0)
            Else
                cid = str(1)
            End If
            If cid > 0 Then
                txtArt.AutoCompleteSource = AutoCompleteBycat(cid)
            Else
                txtArt.AutoCompleteSource = AutoCompleteByAll("Article")
            End If

        End If
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        Clear()
    End Sub
    Private Sub Clear()
        Id = 0
        txtArt.text = ""
        txtCat.text = ""
        txtRemise.text = ""
        cbTous.Checked = False

        txtCat.AutoCompleteSource = AutoCompleteByAll("Category")
        txtArt.AutoCompleteSource = AutoCompleteByAll("Article")
    End Sub
    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click

        If IsNumeric(txtRemise.text) = False Then Exit Sub


        If cbTous.Checked Then
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                Dim where As New Dictionary(Of String, Object)
                where.Add("clid", client_Id)
                where.Add("all", True)

                params.Add("cid", 0)
                params.Add("arid", 0)
                params.Add("cat_name", "*")
                params.Add("art_name", "*")
                params.Add("remise", txtRemise.text)
                Dim IID = a.UpdateRecord("Client_Remise", params, where)
            End Using
            GetData()
            Clear()
            Exit Sub
        End If

        If Id = 0 Then
            addData()
        Else
            editData()
        End If

        Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub

        Clear()
        Id = DataGridView1.SelectedRows(0).Cells(0).Value

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("id", Id)

            Dim dt As DataTable = a.SelectDataTable("Client_Remise", {"*"}, params)
            If dt.Rows.Count > 0 Then
               
                If CInt(dt.Rows(0).Item("cid")) > 0 Then
                    txtCat.text = dt.Rows(0).Item("cat_name") & "|" & dt.Rows(0).Item("cid")
                End If

                If CInt(dt.Rows(0).Item("arid")) > 0 Then
                    txtArt.text = dt.Rows(0).Item("art_name") & "|" & dt.Rows(0).Item("arid")
                End If

                cbTous.Checked = CBool(dt.Rows(0).Item("all"))

                txtRemise.text = dt.Rows(0).Item("remise")
            End If
        End Using
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count = 0 Then Exit Sub
        If (MsgBox(MsgDelete, MsgBoxStyle.YesNo, "Suppression")) = MsgBoxResult.No Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("id", DataGridView1.SelectedRows(0).Cells(0).Value)

            a.DeleteRecords("Client_Remise", params)
        End Using
        GetData()
    End Sub
End Class