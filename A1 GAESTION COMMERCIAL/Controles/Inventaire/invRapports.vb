Public Class invRapports

    Dim _isSell As Boolean
    Public tableName As String
    Public tableName_avoir As String
    Public tb_C As String
    Public tb_D As String
    Public tb_D_Av As String
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
                tableName_avoir = "Sell_Avoir"
                tb_C = "Client"
                tb_D = "Details_Sell_Facture"
                tb_D_Av = "Details_Sell_Avoir"
                tb_P = "Client_Payement"
                LBTITLE.Text = "Ventes"
            Else
                tableName = "Buy_Facture"
                tableName_avoir = "Buy_Avoir"
                tb_C = "Fournisseur"
                tb_D = "Details_Buy_Facture"
                tb_D_Av = "Details_Buy_Avoir"
                tb_P = "Company_Payement"
                LBTITLE.Text = "Achats"
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

            Try
                lbLnbr.Text = value.Rows.Count
            Catch ex As Exception
                lbLnbr.Text = "-"
            End Try

            Try
                Dim sum As Double = Convert.ToDouble(value.Compute("SUM(total)", String.Empty))
                lbTotal.Text = String.Format("{0:n}", CDec(sum))
            Catch ex As Exception
                lbTotal.Text = "-"
            End Try


            Try
                If isSell Then
                    FillRows_Sell()
                    '   FillRows_Sell_______aitMelloul()
                Else
                    '    FillRows_Buy_________AitMelloul()
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
        If isSell Then str = "Rapport des Facture des Ventes de "

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

    Private Sub FillRows_Buy_________AitMelloul()
        'Pl.Controls.Clear()
        Try
            '_dataSource.Columns.Add("20", GetType(String))
            _dataSource.Columns.Add("IF", GetType(String))
            _dataSource.Columns.Add("ICE", GetType(String))

            _dataSource.Columns.Add("Total TTC", GetType(String)) '8
            _dataSource.Columns.Add("Tva 20%", GetType(String)) '9

            _dataSource.Columns.Add("Plastic  ttc", GetType(String))
            _dataSource.Columns.Add("Alum ttc", GetType(String))
            _dataSource.Columns.Add("Inox ttc", GetType(String))
            _dataSource.Columns.Add("Divers ttc", GetType(String))
            _dataSource.Columns.Add("M. Paiement", GetType(String)) '14

            Dim cid As Integer = 0
            Dim fctid As Integer = 0
            Dim dt As DataTable = Nothing

            Dim tt As Double = 0
            Dim tv As Double = 0
            Dim tpl As Double = 0
            Dim tal As Double = 0
            Dim tin As Double = 0
            Dim tdv As Double = 0

            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try
                    fctid = _dataSource.Rows(i).Item(0)
                    If fctid > 0 Then

                        Dim f As Facture
                        Dim TBL = tableName
                        Dim TBd = tb_D
                        If _dataSource.Rows(i).Item(5) < 0 Then
                            TBL = tableName_avoir
                            TBd = tb_D_Av
                        End If

                        f = New Facture(fctid, TBL, tb_C, TBd, tb_P)

                        _dataSource.Rows(i).Item("ICE") = f.client.ICE
                        _dataSource.Rows(i).Item("IF") = f.client.info

                        _dataSource.Rows(i).Item(9) = String.Format("{0:n}", _dataSource.Rows(i).Item(5))
                        _dataSource.Rows(i).Item(10) = String.Format("{0:n}", _dataSource.Rows(i).Item(6))

                        tt += CDbl(_dataSource.Rows(i).Item(5))
                        tv += CDbl(_dataSource.Rows(i).Item(6))

                        dt = f.DataSource

                        Dim _tv As Double = 0
                        Try  ''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("PL") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()

                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _tv = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _tv
                                pl += pl2
                            Next
                            If _dataSource.Rows(i).Item(5) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item(11) = String.Format("{0:n}", pl)
                            tpl += pl
                        Catch ex As Exception
                        End Try

                        Try '''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("AL") Select myRow

                            Dim r As DataTable = result.CopyToDataTable()
                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _tv = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _tv
                                pl += pl2
                            Next

                            If _dataSource.Rows(i).Item(5) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item(12) = String.Format("{0:n}", pl)
                            tal += pl
                        Catch ex As Exception
                        End Try

                        Try '''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("IN") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()
                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _tv = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _tv
                                pl += pl2
                            Next

                            If _dataSource.Rows(i).Item(5) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item("Inox ttc") = String.Format("{0:n}", pl)
                            tin += pl
                        Catch ex As Exception
                        End Try

                        Try '''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("DI") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()
                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _tv = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _tv
                                pl += pl2
                            Next

                            If _dataSource.Rows(i).Item(5) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item("Divers ttc") = String.Format("{0:n}", pl)
                            tdv += pl
                        Catch ex As Exception
                        End Try

                        If _dataSource.Rows(i).Item(5) >= 0 Then
                            Try '''''''''''''''''''''''''''''''''''''''''''''
                                Dim pm = f.PaymenetDataSource.Rows(0).Item("way") & " - " & f.PaymenetDataSource.Rows(0).Item("ref")
                                _dataSource.Rows(i).Item(15) = pm
                            Catch ex As Exception
                            End Try

                        Else
                            _dataSource.Rows(i).Item(15) = "Avoir"
                        End If

                    End If
                Catch ex As Exception
                End Try
            Next

            If _dataSource.Rows.Count Then
                _dataSource.Rows.Add(0)

                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(4) = "Total"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(5) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(6) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(7) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(8) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(9) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(10) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(11) = String.Format("{0:n}", tpl)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(12) = String.Format("{0:n}", tal)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(13) = String.Format("{0:n}", tin)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(14) = String.Format("{0:n}", tdv)
            End If


            'Dim dg As New DataGridView
            dg.DataSource = _dataSource
            StyleDatagrid(dg)
            'pl.Controls.Add(dg)

            dg.Columns(3).Visible = False
            dg.Columns(5).Visible = False
            dg.Columns(6).Visible = False

            dg.Columns(4).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(4).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(9).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(9).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    
            dg.Columns(0).HeaderText = "ID/N°"
            dg.Columns(1).HeaderText = "REF"
            dg.Columns(2).HeaderText = "Date"
            dg.Columns(4).HeaderText = "Fornisseur"

            dg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
       
            dg.Columns(2).DefaultCellStyle.Format = "dd/MM/yy"

            dg.Columns(5).DefaultCellStyle.Format = "c"
            dg.Columns(6).DefaultCellStyle.Format = "c"
            dg.Columns(9).DefaultCellStyle.Format = "c"
            dg.Columns(10).DefaultCellStyle.Format = "c"

            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightSkyBlue

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillRows_Sell_______aitMelloul()
        'Pl.Controls.Clear()
        Try
            _dataSource.Columns.Add("IF", GetType(String)) '6
            _dataSource.Columns.Add("ICE", GetType(String)) '7

            _dataSource.Columns.Add("Total TTC", GetType(String)) '8
            _dataSource.Columns.Add("Tva 20%", GetType(String)) '9

            _dataSource.Columns.Add("Plastic ttc", GetType(String)) '10
            _dataSource.Columns.Add("Alum ttc", GetType(String)) '11
            _dataSource.Columns.Add("Inox ttc", GetType(String)) '12
            _dataSource.Columns.Add("Divers ttc", GetType(String)) '13
            _dataSource.Columns.Add("Caisse", GetType(String)) '14
            _dataSource.Columns.Add("Banque", GetType(String)) '15

            Dim cid As Integer = 0
            Dim fctid As Integer = 0
            Dim dt As DataTable = Nothing

            Dim tt As Double = 0
            Dim tv As Double = 0
            Dim tpl As Double = 0
            Dim tal As Double = 0
            Dim tin As Double = 0
            Dim tdv As Double = 0
            Dim tcs As Double = 0
            Dim tba As Double = 0

            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try
                    fctid = _dataSource.Rows(i).Item(0)
                    If fctid > 0 Then
                        Dim f As Facture

                        Dim TBL = tableName
                        Dim TBd = tb_D

                        If _dataSource.Rows(i).Item(4) < 0 Then
                            TBL = tableName_avoir
                            TBd = tb_D_Av
                        End If


                        f = New Facture(fctid, TBL, tb_C, TBd, tb_P)

                        _dataSource.Rows(i).Item("ICE") = f.client.ICE
                        _dataSource.Rows(i).Item("IF") = f.client.info

                        _dataSource.Rows(i).Item(8) = String.Format("{0:n}", _dataSource.Rows(i).Item(4))
                        _dataSource.Rows(i).Item(9) = String.Format("{0:n}", _dataSource.Rows(i).Item(5))

                        tt += CDbl(_dataSource.Rows(i).Item(4))
                        tv += CDbl(_dataSource.Rows(i).Item(5))

                        dt = f.DataSource
                        Dim _TV As Double = 0

                        Try  ''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("PL") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()

                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _TV = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _TV
                                pl += pl2
                            Next
                            If _dataSource.Rows(i).Item(4) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item("Plastic ttc") = String.Format("{0:n}", pl)
                            tpl += pl
                        Catch ex As Exception
                        End Try

                        Try '''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("AL") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()

                            Dim pl As Double = 0
                            _TV = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _TV = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _TV
                                pl += pl2
                            Next

                            If _dataSource.Rows(i).Item(4) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item("Alum ttc") = String.Format("{0:n}", pl)
                            tal += pl
                        Catch ex As Exception
                        End Try

                        Try '''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("IN") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()

                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _TV = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _TV
                                pl += pl2
                            Next

                            If _dataSource.Rows(i).Item(4) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item("Inox ttc") = String.Format("{0:n}", pl)
                            tin += pl
                        Catch ex As Exception
                        End Try

                        Try '''''''''''''''''''''''''''''''''''''''''''''
                            Dim result = From myRow As DataRow In dt.Rows
                                                                              Where myRow("ref").ToString.ToUpper.EndsWith("DI") Select myRow
                            Dim r As DataTable = result.CopyToDataTable()

                            Dim pl As Double = 0
                            For ii As Integer = 0 To r.Rows.Count - 1
                                Dim pl2 As Double = r.Rows(ii).Item("qte") * r.Rows(ii).Item("price")
                                pl2 -= (pl2 * r.Rows(ii).Item("remise")) / 100
                                _TV = (pl2 * r.Rows(ii).Item("tva")) / 100
                                pl2 += _TV
                                pl += pl2
                            Next

                            If _dataSource.Rows(i).Item(4) < 0 Then pl *= -1

                            If pl <> 0 Then _dataSource.Rows(i).Item("Divers ttc") = String.Format("{0:n}", pl)
                            tdv += pl
                        Catch ex As Exception
                        End Try


                        If _dataSource.Rows(i).Item(4) >= 0 Then
                            Dim pm = f.PaymenetDataSource
                            Try '''''''''''''''''''''''''''''''''''''''''''''

                                Dim result = From myRow As DataRow In pm.Rows
                                                                                  Where myRow("way").ToString.ToUpper.StartsWith("CA") Select myRow
                                Dim pl As Double = Convert.ToDouble(result.CopyToDataTable.Compute("SUM(montant)", String.Empty))

                                If pl > 0 Then _dataSource.Rows(i).Item("Caisse") = String.Format("{0:n}", pl)
                                tcs += pl
                            Catch ex As Exception
                            End Try

                            Try '''''''''''''''''''''''''''''''''''''''''''''

                                Dim result = From myRow As DataRow In pm.Rows
                                                                                  Where myRow("way").ToString.ToUpper.StartsWith("CA") = False Select myRow
                                Dim pl As Double = Convert.ToDouble(result.CopyToDataTable.Compute("SUM(montant)", String.Empty))

                                If pl > 0 Then _dataSource.Rows(i).Item("Banque") = String.Format("{0:n}", pl)
                                tba += pl
                            Catch ex As Exception
                            End Try
                        Else

                            Try '''''''''''''''''''''''''''''''''''''''''''''

                                _dataSource.Rows(i).Item("Caisse") = "Avoir"
                                _dataSource.Rows(i).Item("Banque") = "Avoir"

                            Catch ex As Exception
                            End Try
                        End If


                    End If
                Catch ex As Exception
                End Try
            Next

            If _dataSource.Rows.Count Then
                _dataSource.Rows.Add(0)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(3) = "Total"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(4) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(5) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(6) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(7) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(8) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(9) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(10) = String.Format("{0:n}", tpl)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(11) = String.Format("{0:n}", tal)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(12) = String.Format("{0:n}", tin)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(13) = String.Format("{0:n}", tdv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(14) = String.Format("{0:n}", tcs)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(15) = String.Format("{0:n}", tba)
            End If
            dg.DataSource = _dataSource
            StyleDatagrid(dg)
       
            dg.Columns(2).Visible = False
            dg.Columns(4).Visible = False
            dg.Columns(5).Visible = False
  

            dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(8).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(8).DefaultCellStyle.ForeColor = Form1.Color_Default_Text


            dg.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        
            dg.Columns(0).HeaderText = "ID/N°"
            dg.Columns(1).HeaderText = "Date"
            dg.Columns(3).HeaderText = "Client"
       
            dg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dg.Columns(1).DefaultCellStyle.Format = "dd/MM/yy"

            dg.Columns(4).DefaultCellStyle.Format = "c"
            dg.Columns(5).DefaultCellStyle.Format = "c"
            dg.Columns(8).DefaultCellStyle.Format = "c"
            dg.Columns(9).DefaultCellStyle.Format = "c"
            dg.Columns(10).DefaultCellStyle.Format = "c"
            dg.Columns(11).DefaultCellStyle.Format = "c"
            dg.Columns(12).DefaultCellStyle.Format = "c"
            dg.Columns(13).DefaultCellStyle.Format = "c"

            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightSkyBlue

        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillRows_Buy()
        'Pl.Controls.Clear()
        Try
            '_dataSource.Columns.Add("20", GetType(String))
            _dataSource.Columns.Add("IF", GetType(String))
            _dataSource.Columns.Add("ICE", GetType(String))

            _dataSource.Columns.Add("Total TTC", GetType(String)) '8
            _dataSource.Columns.Add("Tva", GetType(String)) '9

            _dataSource.Columns.Add("M. Paiement", GetType(String)) '10

            Dim cid As Integer = 0
            Dim fctid As Integer = 0
            Dim dt As DataTable = Nothing

            Dim tt As Double = 0
            Dim tv As Double = 0
            Dim tpl As Double = 0
            Dim tal As Double = 0
            Dim tin As Double = 0
            Dim tdv As Double = 0



            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try
                    fctid = _dataSource.Rows(i).Item(0)
                    If fctid > 0 Then

                        Dim f As Facture

                        Dim TBL = tableName
                        Dim TBd = tb_D

                        If _dataSource.Rows(i).Item(5) < 0 Then
                            TBL = tableName_avoir
                            TBd = tb_D_Av
                        End If


                        f = New Facture(fctid, TBL, tb_C, TBd, tb_P)

                        _dataSource.Rows(i).Item("ICE") = f.client.ICE
                        _dataSource.Rows(i).Item("IF") = f.client.info

                        _dataSource.Rows(i).Item(8) = String.Format("{0:n}", _dataSource.Rows(i).Item(4))
                        _dataSource.Rows(i).Item(9) = String.Format("{0:n}", _dataSource.Rows(i).Item(5))

                        tt += CDbl(_dataSource.Rows(i).Item(4))
                        tv += CDbl(_dataSource.Rows(i).Item(5))


                        dt = f.DataSource


                        If _dataSource.Rows(i).Item(4) >= 0 Then
                            Try '''''''''''''''''''''''''''''''''''''''''''''
                                Dim pm = f.PaymenetDataSource.Rows(0).Item("way") & " - " & f.PaymenetDataSource.Rows(0).Item("ref")
                                _dataSource.Rows(i).Item(14) = pm
                            Catch ex As Exception
                            End Try

                        Else
                            _dataSource.Rows(i).Item(14) = "Avoir"
                        End If


                    End If
                Catch ex As Exception
                End Try
            Next

            If _dataSource.Rows.Count Then
                _dataSource.Rows.Add(0)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(3) = "Total"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(4) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(5) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(6) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(7) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(8) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(9) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(10) = String.Format("{0:n}", tdv)
            End If


            'Dim dg As New DataGridView
            dg.DataSource = _dataSource
            StyleDatagrid(dg)
            'pl.Controls.Add(dg)

            dg.Columns(2).Visible = False
            dg.Columns(4).Visible = False
            dg.Columns(5).Visible = False

            dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(8).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(8).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dg.Columns(0).HeaderText = "ID/N°"
            dg.Columns(1).HeaderText = "Date"
            dg.Columns(3).HeaderText = "Fornisseur"

            dg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dg.Columns(1).DefaultCellStyle.Format = "dd/MM/yy"

            dg.Columns(4).DefaultCellStyle.Format = "c"
            dg.Columns(5).DefaultCellStyle.Format = "c"
            dg.Columns(8).DefaultCellStyle.Format = "c"
            dg.Columns(9).DefaultCellStyle.Format = "c"

            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightSkyBlue

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillRows_Sell()
        'Pl.Controls.Clear()
        Try
            _dataSource.Columns.Add("IF", GetType(String)) '6
            _dataSource.Columns.Add("ICE", GetType(String)) '7

            _dataSource.Columns.Add("Total TTC", GetType(String)) '8
            _dataSource.Columns.Add("Tva", GetType(String)) '9

          
            _dataSource.Columns.Add("Caisse", GetType(String)) '10
            _dataSource.Columns.Add("Banque", GetType(String)) '11

            Dim cid As Integer = 0
            Dim fctid As Integer = 0
            Dim dt As DataTable = Nothing

            Dim tt As Double = 0
            Dim tv As Double = 0
            Dim tpl As Double = 0
            Dim tal As Double = 0
            Dim tin As Double = 0
            Dim tdv As Double = 0
            Dim tcs As Double = 0
            Dim tba As Double = 0


            For i As Integer = 0 To _dataSource.Rows.Count - 1
                Try
                    fctid = _dataSource.Rows(i).Item(0)
                    If fctid > 0 Then
                        Dim f As Facture

                        Dim TBL = tableName
                        Dim TBd = tb_D

                        If _dataSource.Rows(i).Item(4) < 0 Then
                            TBL = tableName_avoir
                            TBd = tb_D_Av
                        End If

                        f = New Facture(fctid, TBL, tb_C, TBd, tb_P)

                        _dataSource.Rows(i).Item("ICE") = f.client.ICE
                        _dataSource.Rows(i).Item("IF") = f.client.info

                        _dataSource.Rows(i).Item(8) = String.Format("{0:n}", _dataSource.Rows(i).Item(4))
                        _dataSource.Rows(i).Item(9) = String.Format("{0:n}", _dataSource.Rows(i).Item(5))

                        tt += CDbl(_dataSource.Rows(i).Item(4))
                        tv += CDbl(_dataSource.Rows(i).Item(5))

                        dt = f.DataSource
                        Dim _TV As Double = 0



                        If _dataSource.Rows(i).Item(4) >= 0 Then
                            Dim pm = f.PaymenetDataSource
                            Try '''''''''''''''''''''''''''''''''''''''''''''

                                Dim result = From myRow As DataRow In pm.Rows
                                                                                  Where myRow("way").ToString.ToUpper.StartsWith("CA") Select myRow
                                Dim pl As Double = Convert.ToDouble(result.CopyToDataTable.Compute("SUM(montant)", String.Empty))

                                If pl > 0 Then _dataSource.Rows(i).Item("Caisse") = String.Format("{0:n}", pl)
                                tcs += pl
                            Catch ex As Exception
                            End Try

                            Try '''''''''''''''''''''''''''''''''''''''''''''

                                Dim result = From myRow As DataRow In pm.Rows
                                                                                  Where myRow("way").ToString.ToUpper.StartsWith("CA") = False Select myRow
                                Dim pl As Double = Convert.ToDouble(result.CopyToDataTable.Compute("SUM(montant)", String.Empty))

                                If pl > 0 Then _dataSource.Rows(i).Item("Banque") = String.Format("{0:n}", pl)
                                tba += pl
                            Catch ex As Exception
                            End Try
                        Else

                            Try '''''''''''''''''''''''''''''''''''''''''''''

                                _dataSource.Rows(i).Item("Caisse") = "Avoir"
                                _dataSource.Rows(i).Item("Banque") = "Avoir"

                            Catch ex As Exception
                            End Try
                        End If


                    End If
                Catch ex As Exception
                End Try
            Next

            If _dataSource.Rows.Count Then
                _dataSource.Rows.Add(0)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(3) = "Total"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(4) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(5) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(6) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(7) = "-----"
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(8) = String.Format("{0:n}", tt)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(9) = String.Format("{0:n}", tv)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(10) = String.Format("{0:n}", tcs)
                _dataSource.Rows(_dataSource.Rows.Count - 1).Item(11) = String.Format("{0:n}", tba)
            End If




            'Dim dg As New DataGridView
            dg.DataSource = _dataSource
            StyleDatagrid(dg)
            'pl.Controls.Add(dg)

            dg.Columns(2).Visible = False
            dg.Columns(4).Visible = False
            dg.Columns(5).Visible = False

            dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text

            dg.Columns(8).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
            dg.Columns(8).DefaultCellStyle.ForeColor = Form1.Color_Default_Text


            dg.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dg.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dg.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dg.Columns(0).HeaderText = "ID/N°"
            dg.Columns(1).HeaderText = "Date"
            dg.Columns(3).HeaderText = "Client"
            'dg.Columns(4).HeaderText = "Total TTC"
            'dg.Columns(6).HeaderText = "Tva"

            dg.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dg.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            dg.Columns(1).DefaultCellStyle.Format = "dd/MM/yy"

            dg.Columns(4).DefaultCellStyle.Format = "c"
            dg.Columns(5).DefaultCellStyle.Format = "c"
            dg.Columns(8).DefaultCellStyle.Format = "c"
            dg.Columns(9).DefaultCellStyle.Format = "c"
          

            'dg.Columns(21).DisplayIndex = 4
            'dg.Columns(22).DisplayIndex = 5


            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = Color.LightSkyBlue

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
