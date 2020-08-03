Public Class InvJustement

    Dim _isvalid As Boolean
    Dim _id_J As Integer
    Dim _isAj As Boolean

    Public _dataSource As DataTable


    Event getDetails(ByRef ds As InvJustement)
    Event SaveDetails(ByRef ds As InvJustement)
    Event PrintDetails(ByRef ds As InvJustement)
    Event SavePdfDetails(ByRef ds As InvJustement)
    Event PrintList(ByRef ds As InvJustement)
    Event AddNew_Ajustement(ByRef ds As InvJustement)
    Event AddNew_Valorisation(ByRef ds As InvJustement)
    Event ValiderAjustement(ByRef ds As InvJustement)
    Event ValiderValorisation(ByRef ds As InvJustement)
    Event getList(ByRef ds As InvJustement)
    Event getRealStockFromBons(ByRef ds As InvJustement)

    Public Property id_Jus As Integer
        Get
            Return _id_J
        End Get
        Set(ByVal value As Integer)
            _id_J = value
            If value = 0 Then
                plD.Dock = DockStyle.Left
                plD.Width = 1
                plL.Dock = DockStyle.Fill

                plDetail.Visible = False
                plList.Visible = True

                RaiseEvent getList(Me)
            Else
                plL.Dock = DockStyle.Right
                plL.Width = 1
                plD.Dock = DockStyle.Fill
                plDetail.Visible = True
                plList.Visible = False

                RaiseEvent getDetails(Me)

                dg_D_Sorted(Nothing, Nothing)
            End If
        End Set
    End Property
    Public Property date_Jus As Date
        Get
            Return CDate(lbDate.Text)
        End Get
        Set(ByVal value As Date)
            lbDate.Text = value.ToString("dd MMM yyyy")
        End Set
    End Property
    Public Property name_Jus As String
        Get
            Return txtName.text
        End Get
        Set(ByVal value As String)
            txtName.text = value
        End Set
    End Property
    Public Property Obs As String
        Get
            Return txtObs.text
        End Get
        Set(ByVal value As String)
            txtObs.text = value
        End Set
    End Property
    Public Property isValid As Boolean
        Get
            Return _isvalid
        End Get
        Set(ByVal value As Boolean)
            _isvalid = value

            If value Then
                txtName.txtReadOnly = True
                txtObs.txtReadOnly = True
                btSave.Visible = False
                btValideBl.Visible = False
                dg_D.EditMode = DataGridViewEditMode.EditProgrammatically
            Else
                txtName.txtReadOnly = False
                txtObs.txtReadOnly = False
                btSave.Visible = True
                btValideBl.Visible = True
                dg_D.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
            End If
        End Set
    End Property
    Public Property dataSource As DataTable
        Get
            Return _dataSource
        End Get
        Set(ByVal value As DataTable)
            _dataSource = value

            dg_D.DataSource = value
        End Set
    End Property
    Public Property isAjustement As Boolean
        Get
            Return _isAj
        End Get
        Set(ByVal value As Boolean)
            _isAj = value

            plVal.Visible = Not value

            If value Then
                dg_D.Columns(7).HeaderText = "Qté réel"
            Else
                dg_D.Columns(7).HeaderText = "Prix"
                dg_D.Columns(7).DefaultCellStyle.Format = "c"
                dg_D.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                Label1.Text = "Valeur"

            End If
        End Set
    End Property

    Private Sub btSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btSave.Click
        If isAjustement = False Then
            Dim v As Double = 0
            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try

                    Dim q As Double = _dataSource.Rows(i).Item(5)
                    Dim c As Double = _dataSource.Rows(i).Item(6)

                    v += q * c

                Catch ex As Exception
                End Try
            Next

            txtObs.text = v.ToString("c")
            lbValueT.Text = v.ToString("c")
        End If

        RaiseEvent SaveDetails(Me)
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent PrintDetails(Me)
    End Sub
    Private Sub btPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPdf.Click
        'RaiseEvent SavePdfDetails(Me)
        Dim str = "Ajustement_de_Stock"
        If isAjustement = False Then str = "Valorisation_de_Stock"

        SaveDataToHtml(dg_D, str)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent PrintList(Me)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If dg_L.SelectedRows.Count = 0 Then Exit Sub
        id_Jus = CInt(dg_L.SelectedRows(0).Cells(0).Value)

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        id_Jus = 0
    End Sub
    Private Sub dg_L_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_L.CellDoubleClick
        If dg_L.SelectedRows.Count = 0 Then Exit Sub
        id_Jus = CInt(dg_L.SelectedRows(0).Cells(0).Value)
    End Sub
    Private Sub LbNewFacture_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LbNewFacture.LinkClicked

        If MsgBox("vous sur le point de valider l'enregistrement president et de creer une nouvelle enregistrement",
                  vbYesNo, "Nouveau") = MsgBoxResult.No Then Exit Sub

        If isAjustement Then
            RaiseEvent AddNew_Ajustement(Me)
        Else
            RaiseEvent AddNew_Valorisation(Me)
        End If

    End Sub
    Private Sub FiltreDataSource()
        Dim dt As New DataTable
        dt = dataSource

        If txtArt.text.Trim <> "" Then
            'Dim quere = From h In dt Where h.Hierarchy.Contains("/12/") Select h()()
            Dim STR = txtArt.text.Trim

            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("name").ToString.Contains(STR) Select myRow

            If result.Count Then dt = result.CopyToDataTable
        End If

        If txtCat.text.Contains("|") Then
            'Dim quere = From h In dt Where h.Hierarchy.Contains("/12/") Select h()()
            Dim cid = txtCat.text.Split("|")(1)
            If IsNumeric(cid) Then
                Dim result = From myRow As DataRow In dt.Rows
                                                    Where myRow("cid") = cid Select myRow
                If result.Count Then dt = result.CopyToDataTable
            End If
        End If

        If txtDepot.text.Contains("|") Then
            'Dim quere = From h In dt Where h.Hierarchy.Contains("/12/") Select h()()
            Dim dp = txtDepot.text.Split("|")(1)
            If IsNumeric(dp) Then
                Dim result = From myRow As DataRow In dt.Rows
                                        Where myRow("dpid") = dp Select myRow
                If result.Count Then dt = result.CopyToDataTable
            End If
        End If

        dg_D.DataSource = dt

        dg_D_Sorted(Nothing, Nothing)
    End Sub


    Private Sub TxtBox1_TxtChanged() Handles txtDepot.TxtChanged, txtCat.TxtChanged, txtArt.TxtChanged
        FiltreDataSource()
    End Sub

    Private Sub btValideBl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btValideBl.Click

        Dim str As String = "Vous été sur le point de valider cet enregistrement"
        str &= vbNewLine & "si vous ete sure merci de sisaire le mote de passe"
        str &= vbNewLine & "de  admin pour continue "

        If MsgBox(str, MsgBoxStyle.YesNo, "Validation") = MsgBoxResult.No Then Exit Sub
        Dim pwdwin As New PWDPicker
        If pwdwin.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        If pwdwin.DGV1.SelectedRows(0).Cells(2).Value <> "admin" Then Exit Sub


        '''''''''''''''''''''''''''''''''''''

        If isAjustement = False Then
            Dim v As Double = 0
            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try

                    Dim q As Double = _dataSource.Rows(i).Item(5)
                    Dim c As Double = _dataSource.Rows(i).Item(6)

                    v += q * c

                Catch ex As Exception
                End Try
            Next

            txtObs.text = v.ToString("c")
            lbValueT.Text = v.ToString("c")
            RaiseEvent ValiderValorisation(Me)
        Else
            'Ajustement
            RaiseEvent ValiderAjustement(Me)
        End If


    End Sub

    Private Sub InvJustement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RaiseEvent getList(Me)
    End Sub

    Private Sub dg_D_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg_D.CellValueChanged
        Try
            'Dim old_v = dg_D.SelectedRows(0).Cells(6).Value
            dg_D.EndEdit()
            'If Not IsNumeric(dg_D.SelectedRows(0).Cells(6).Value) Then
            '    dg_D.SelectedRows(0).Cells(6).Value = old_v
            '    Exit Sub
            'End If

            Dim d_v = dg_D.SelectedRows(0).Cells(6).Value
            Dim d_i = dg_D.SelectedRows(0).Cells(0).Value

            For i As Integer = 0 To _dataSource.Rows.Count - 1
                If _dataSource.Rows(i).Item(0) = d_i Then
                    _dataSource.Rows(i).Item(6) = d_v

                    If dg_D.SelectedRows(0).Cells(5).Value <> dg_D.SelectedRows(0).Cells(6).Value Then
                        dg_D.SelectedRows(0).Cells(6).Style.ForeColor = Form1.Color_Default_Text
                        dg_D.SelectedRows(0).Cells(6).Style.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                    End If
                    Exit Sub
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dg_D_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dg_D.Sorted
        If isAjustement Then
            For i As Integer = 0 To dg_D.Rows.Count - 1
                If dg_D.Rows(i).Cells(5).Value <> dg_D.Rows(i).Cells(6).Value Then
                    dg_D.Rows(i).Cells(6).Style.ForeColor = IIf(dg_D.Rows(i).Cells(5).Value > dg_D.Rows(i).Cells(6).Value, Color.Red, Form1.Color_Default_Text)
                    dg_D.Rows(i).Cells(6).Style.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
                End If
            Next
        Else
            'valorisation


            Dim v As Double = 0
            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try
                    Dim q As Double = _dataSource.Rows(i).Item(5)
                    Dim c As Double = _dataSource.Rows(i).Item(6)

                    v += q * c

                Catch ex As Exception
                End Try
            Next

            txtObs.text = v.ToString("c")
            lbValueT.Text = v.ToString("c")

            v = 0
            For i As Integer = 0 To dg_D.Rows.Count - 1
                Try
                    Dim q As Double = dg_D.Rows(i).Cells(5).Value
                    Dim c As Double = dg_D.Rows(i).Cells(6).Value

                    v += q * c

                Catch ex As Exception
                End Try
            Next
            lbValueS.Text = v.ToString("c")
        End If

    End Sub
    Public m As Integer = 0
    Private Sub PrintDoc_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        Using c As DrawClass = New DrawClass
            If id_Jus = 0 Then
                c.DrawListOfAjustementStock(e, dg_L, True, isAjustement, m)
            Else


            End If
        End Using

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim str = "Liste_des_Ajustements_de_Stock"
        If isAjustement = False Then str = "Liste_des_Valorisation_de_Stock"
        SaveDataToHtml(dg_L, str)
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim nmdg As New ConfirmeRequest
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        For i As Integer = 0 To dg_D.Rows.Count - 1
            Try
                dg_D.Rows(i).Cells(6).Value = 0
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim nmdg As New ConfirmeRequest
        If nmdg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        RaiseEvent getRealStockFromBons(Me)
    End Sub
End Class
