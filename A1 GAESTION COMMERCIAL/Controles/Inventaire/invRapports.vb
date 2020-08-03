Public Class invRapports

    Dim _isSell As Boolean
    Public tableName As String
    Public tb_C As String
    Public tb_D As String
    Public tb_P As String

    Private _dataSource As DataTable

    Event Search(ByVal ds As invRapports)

    Public Property isSell As Boolean
        Get
            Return _isSell
        End Get
        Set(ByVal value As Boolean)
            _isSell = value
            If value Then
                tableName = "Sell_Facture"
                tb_C = "Client"
                tb_D = "Details_Sell_Facture"
                tb_P = "Client_Payement"
            Else
                tableName = "Buy_Facture"
                tb_C = "Fournisseur"
                tb_D = "Details_Buy_Facture"
                tb_P = "Company_Payement"
            End If
        End Set
    End Property


    Public Property dataSource() As DataTable
        Get
            Return _dataSource
        End Get
        Set(ByVal value As DataTable)
            _dataSource = value
            ' dg_D.DataSource = value

            lbLnbr.Text = value.Rows.Count
            Try
                Dim sum As Double = Convert.ToDouble(value.Compute("SUM(total)", String.Empty))
                lbTotal.Text = String.Format("{0:n}", CDec(sum))
            Catch ex As Exception
                lbTotal.Text = "-"
            End Try


            Try
                If isSell Then
                    'FillRows_sell()
                Else

                    FillRows_Buy()
                End If
            Catch ex As Exception

            End Try

        End Set
    End Property

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent Search(Me)
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim str As String = "Rapport des Facture d'Achats de "
        If isSell Then str = "Rapport des Facturedes Ventes de "

        str &= dte1.Value.ToString("dd-MM-yyyy") & " au " & dte2.Value.ToString("dd-MM-yyyy")

        SaveDataToHtml(dg, str)
    End Sub
    Private Sub btInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.Click
        Dim CC As New ChooseClient
        CC.tb_C = tb_C
        If CC.ShowDialog = Windows.Forms.DialogResult.OK Then
            txt.text = CC.clientName & "|" & CC.cid
        End If
    End Sub


    Private Sub FillRows_Buy()
        'Pl.Controls.Clear()
        Try

            _dataSource.Columns.Add("IF", GetType(String))
            _dataSource.Columns.Add("ICE", GetType(String))
            _dataSource.Columns.Add("Plastic  ttc", GetType(String))
            _dataSource.Columns.Add("Alum ttc", GetType(String))
            _dataSource.Columns.Add("Inox ttc", GetType(String))
            _dataSource.Columns.Add("Divers ttc", GetType(String))
            '_dataSource.Columns.Add("M. Paiement", GetType(String))

            Dim cid As Integer = 0
            Dim fctid As Integer = 0
            Dim dt As DataTable = Nothing
            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try
                    fctid = _dataSource.Rows(i).Item(0)
                    If fctid > 0 Then
                        Dim f As Facture = New Facture(fctid, tableName, tb_C, tb_D, tb_P)
                        _dataSource.Rows(i).Item("ICE") = f.client.ICE
                        _dataSource.Rows(i).Item("IF") = f.client.info

                        dt = f.DataSource

                        Dim result = From myRow As DataRow In dt.Rows
                                                   Where myRow("ref").ToString.EndsWith("PL") Select myRow
                        Dim pl As Double = Convert.ToDouble(result.CopyToDataTable.Compute("SUM(qte * price)", String.Empty))


                        '             Dim sums = From dr In dt.AsEnumerable()
                        '                         Where dr("ref").ToString.EndsWith("PL")
                        '                        Select New With {
                        '                            .sum = dr.Sum(Function(dr) dr.Field(Of int)("Length")),
                        '                            .StartSum = drg.Sum(Function(dr) dr.Field(Of Double)("Start"))
                        '}

                    End If
                Catch ex As Exception
                End Try




            Next






            'Dim dg As New DataGridView
            dg.DataSource = _dataSource
            StyleDatagrid(dg)
            'pl.Controls.Add(dg)

            dg.Columns(2).Visible = False
            dg.Columns(5).Visible = False
            dg.Columns(7).Visible = False
            dg.Columns(9).Visible = False
            dg.Columns(10).Visible = False
            dg.Columns(11).Visible = False
            dg.Columns(13).Visible = False
            dg.Columns(14).Visible = False
            dg.Columns(15).Visible = False
            dg.Columns(16).Visible = False
            dg.Columns(17).Visible = False
            dg.Columns(18).Visible = False
            dg.Columns(19).Visible = False
            'dg.Columns(20).Visible = False
            dg.Columns(12).Visible = False

            dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dg.Columns(0).HeaderText = "ID/N°"
            dg.Columns(1).HeaderText = "Date"
            dg.Columns(3).HeaderText = "Fornisseur"
            dg.Columns(4).HeaderText = "Total TTC"
            dg.Columns(6).HeaderText = "Tva"

            dg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dg.Columns(1).DefaultCellStyle.Format = "dd/MM/yy"

            dg.Columns(4).DefaultCellStyle.Format = "c"
            dg.Columns(6).DefaultCellStyle.Format = "c"
            dg.Columns(23).DefaultCellStyle.Format = "c"
            dg.Columns(24).DefaultCellStyle.Format = "c"
            dg.Columns(25).DefaultCellStyle.Format = "c"
            dg.Columns(22).DefaultCellStyle.Format = "c"

            dg.Columns(20).DisplayIndex = 4
            dg.Columns(21).DisplayIndex = 5
            dg.Columns(10).DisplayIndex = 25
            'Dg_Sorted(dg, Nothing)
            ' Pl.Height = dg.Rows.Count * 33 + 222

        Catch ex As Exception
        End Try
    End Sub
    Private Sub StyleDatagrid(ByRef dg As DataGridView)
        dg.AutoGenerateColumns = True
        dg.BorderStyle = Windows.Forms.BorderStyle.None
        dg.CellBorderStyle = DataGridViewCellBorderStyle.None
        dg.RowsDefaultCellStyle.BackColor = Form1.Color_Default_Row
        dg.AlternatingRowsDefaultCellStyle.BackColor = Form1.Color_Alternating_Row

        dg.DefaultCellStyle.SelectionBackColor = Form1.Color_Selected_Row
        dg.DefaultCellStyle.SelectionForeColor = Form1.Color_Selected_Text

        dg.BackgroundColor = Color.White

        dg.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dg.MultiSelect = False

        dg.AllowUserToResizeColumns = False
        dg.AllowUserToAddRows = False
        dg.AllowUserToDeleteRows = False
        dg.AllowUserToResizeRows = False
        dg.EditMode = DataGridViewEditMode.EditProgrammatically

        dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        dg.RowTemplate.Height = 33
        dg.ColumnHeadersHeight = 33

        dg.Dock = DockStyle.Fill
        dg.RowHeadersVisible = False
    End Sub



End Class
