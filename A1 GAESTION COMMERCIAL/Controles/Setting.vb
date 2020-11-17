Public Class Setting

    Dim PrintDlg As New PrintDialog

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        plData.Height = 60
        plText.Height = 60
        plPref.Height = 60
        plRole.Height = 60
        plUser.Height = 60
        plImp.Height = 60
        plPos.Height = 60


        ' Add any initialization after the InitializeComponent() call.
        txtnn.text = getRegistryinfo("fontName_Normal", "Arial")
        txtnt.text = getRegistryinfo("fontName_Title", "Arial")
        txtns.text = getRegistryinfo("fontName_Small", "Arial")
        txtsn.text = getRegistryinfo("fontSize_Normal", 10)
        txtst.text = getRegistryinfo("fontSize_Title", 14)
        txtss.text = getRegistryinfo("fontSize_Small", 8)


        txtCellWidth.Text = getRegistryinfo("cellWidth", 8)
        HandleRegistryinfo1()
    End Sub

    Public Sub HandleRegistryinfo1()
        Try
            txtCellWidth.Text = getRegistryinfo("cellWidth", 111)
            txtEntete.Text = getRegistryinfo("imgEntetePath", "C:\")
            txtPied.Text = getRegistryinfo("imgFootherPath", "C:\")
            txtnumberOfItems.Text = getRegistryinfo("numberOfItems", 22)
            'font
            txtnn.text = getRegistryinfo("fontName_Normal", "Arial")
            txtnt.text = getRegistryinfo("fontName_Title", "Arial")
            txtns.text = getRegistryinfo("fontName_Small", "Arial")
            txtsn.text = getRegistryinfo("fontSize_Normal", 10)
            txtst.text = getRegistryinfo("fontSize_Title", 14)
            txtss.text = getRegistryinfo("fontSize_Small", 8)
            txtnumberOfItems.Text = getRegistryinfo("numberOfItems", 22)

            txtImpDv.Text = getRegistryinfo("printer_Devis", "")
            txtImpBon.Text = getRegistryinfo("printer_Bon", "")
            txtImpfct.Text = getRegistryinfo("printer_Facture", "")
            txtImpAv.Text = getRegistryinfo("printer_Avoir", "")
            txtImpPdf.Text = getRegistryinfo("printer_Pdf", "")
            txtEchBon.Text = getRegistryinfo("txtEchBon", "1")
            txtEchFct.Text = getRegistryinfo("txtEchFct", "1")
            txtImpPos.Text = getRegistryinfo("printer_POS", "")

            'TXTFAC.Text = getRegistryinfo("Facture_Title", "")
            'Form1.imgEntetePath.Text = getRegistryinfo("imgEntetePath", "")
            'Form1.imgFootherPath.Text = getRegistryinfo("imgFootherPath", "")
            cbImp.Checked = getRegistryinfo("printEnteteOnPaper", False)
            cbPdf.Checked = getRegistryinfo("printEnteteOnPdf", False)
            cbHasEPBonTransport.Checked = getRegistryinfo("hasEntete_BonTransport", False)

            txtTva.Text = getRegistryinfo("tva", 20)
            cbBaseOnOneTva.Checked = getRegistryinfo("isBaseOnOneTva", False)
            cbBaseOnTTC.Checked = getRegistryinfo("isBaseOnTTC", False)

            txtPathBound.Text = getRegistryinfo("PathBound", "C:\")
            txtPathSvgd.Text = getRegistryinfo("PathSvgd", "C:\")
            txtPathImg.Text = getRegistryinfo("ImgPath", "C:\")
            txtDataComp.Text = getRegistryinfo("Data_Comp_Path", "C:\")


            'prefix
            txtdv.Text = getRegistryinfo("prf_s_dv", "Av")
            txtcm.Text = getRegistryinfo("prf_s_cm", "Cm")
            txtbl.Text = getRegistryinfo("prf_s_bl", "Bl")
            txtfc.Text = getRegistryinfo("prf_s_fc", "Fc")
            txtav.Text = getRegistryinfo("prf_s_av", "Av")

            txt_bc.Text = getRegistryinfo("prf_b_bc", "Bc")
            txt_ba.Text = getRegistryinfo("prf_b_ba", "Ba")
            txt_fc.Text = getRegistryinfo("prf_b_fc", "Fc")
            txt_av.Text = getRegistryinfo("prf_b_av", "Av")

            cbClientRemise.Checked = getRegistryinfo("useClientRemise_Way", False)
            cbBlLivrable.Checked = getRegistryinfo("useBlLivrable", False)
            cbValidationBL.Checked = getRegistryinfo("useButtonValidForStock", False)

            cbAccessClient.Checked = getRegistryinfo("useAccessClient", False)
            cbSoldByAvoir.Checked = getRegistryinfo("useSoldByAvoir", False)
            cbPorteMonie.Checked = getRegistryinfo("usePortMonie", False)
            cbCump.Checked = getRegistryinfo("useValue_CUMP", False)
            cbImpRef.Checked = getRegistryinfo("printRef", False)
            cbBlGetSold.Checked = getRegistryinfo("isBlGetSold", True)
            cbFactureGetSold.Checked = getRegistryinfo("isFactureGetSold", False)
            cbNormalImp.Checked = getRegistryinfo("normat_Print_Style", True)
            allowAddElement_to.Checked = getRegistryinfo("allowAddElement_to", False)


            lbDefaultText.ForeColor = Color.FromArgb(getRegistryinfo("Color_Default_Text", Color.Blue.ToArgb.ToString))
            lbSelectText.ForeColor = Color.FromArgb(getRegistryinfo("Color_Selected_Text", Color.Yellow.ToArgb.ToString))
            plDefRow.BackColor = Color.FromArgb(getRegistryinfo("Color_Default_Row", Color.Bisque.ToArgb.ToString))
            plAltRow.BackColor = Color.FromArgb(getRegistryinfo("Color_Alternating_Row", Color.WhiteSmoke.ToArgb.ToString))
            plSelRow.BackColor = Color.FromArgb(getRegistryinfo("Color_Selected_Row", Color.Red.ToArgb.ToString))

            cbSearchByCode.Checked = getRegistryinfo("modeSearch_isCode", False)
            cbSearchBy.Text = getRegistryinfo("SearchBy", "Tous")

        Catch ex As Exception

        End Try

    End Sub
    'PRINTERS
    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpfct.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_Facture", txtImpfct.Text)
            Form1.printer_Facture = txtImpfct.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpDv.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_Devis", txtImpDv.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpBon.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_Bon", txtImpBon.Text)
            Form1.printer_Bon = txtImpBon.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpAv.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_Avoir", txtImpAv.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpPdf.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_Pdf", txtImpPdf.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    'img
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtEntete.Text = OPF.FileName
            End If

            setRegistryinfo("imgEntetePath", txtEntete.Text)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                txtPied.Text = OPF.FileName
            End If

            setRegistryinfo("imgFootherPath", txtPied.Text)
        Catch ex As Exception

        End Try
    End Sub
    'bool
    Private Sub cbImp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbImp.CheckedChanged
        Try
            setRegistryinfo("printEnteteOnPaper", cbImp.Checked)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub cbPdf_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbPdf.CheckedChanged
        Try
            setRegistryinfo("printEnteteOnPdf", cbPdf.Checked)
        Catch ex As Exception

        End Try
    End Sub
    'int
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNbrCopie.TextChanged
        Try

            If Not IsNumeric(txtNbrCopie.Text) Then
                txtNbrCopie.Text = 1
            Else
                txtNbrCopie.Text = CInt(txtNbrCopie.Text)
            End If
            setRegistryinfo("NbrCopie", txtNbrCopie.Text)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    'side menu
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click, Panel4.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 777
        plPos.Height = 1
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click, Panel5.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 777
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
        plPos.Height = 1



    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click, Panel9.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 777
        plUser.Height = 1
        plImp.Height = 1
        plPos.Height = 1
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click, Panel8.Click
        If Form1.admin = False Then Exit Sub


        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 777
        plImp.Height = 1
        plPos.Height = 1
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click, Panel7.Click
        plData.Height = 1
        plText.Height = 777
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
        plPos.Height = 1
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Panel6.Click
        plData.Height = 777
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
        plPos.Height = 1
    End Sub
    'width
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            setRegistryinfo("cellWidth", txtCellWidth.Text)
            Form1.cellWidth = txtCellWidth.Text
        Catch ex As Exception
        End Try

        Try
            If IsNumeric(txtnumberOfItems.Text) Then
                setRegistryinfo("numberOfItems", txtnumberOfItems.Text)
                Form1.numberOfItems = txtnumberOfItems.Text
            End If
        Catch ex As Exception
        End Try

        Try
            If IsNumeric(txtTva.Text) Then
                setRegistryinfo("tva", txtTva.Text)
                Form1.tva = txtTva.Text
            End If

            If txtTrial.Visible Then
                Dim a As Integer = 11
                If txtTrial.Text = "TRn-1" Then a = -1
                setRegistryinfo("nbrPrOp_Tr", a)
            End If

            setRegistryinfo("isBaseOnOneTva", cbBaseOnOneTva.Checked)
            setRegistryinfo("isBaseOnTTC", cbBaseOnTTC.Checked)
            setRegistryinfo("useValue_CUMP", cbCump.Checked)
            setRegistryinfo("useClientRemise_Way", cbClientRemise.Checked)
            setRegistryinfo("useBlLivrable", cbBlLivrable.Checked)
            setRegistryinfo("useButtonValidForStock", cbValidationBL.Checked)
            setRegistryinfo("useAccessClient", cbAccessClient.Checked)
            setRegistryinfo("useSoldByAvoir", cbSoldByAvoir.Checked)
            setRegistryinfo("usePortMonie", cbPorteMonie.Checked)
            setRegistryinfo("useValue_CUMP", cbCump.Checked)
            setRegistryinfo("printRef", cbImpRef.Checked)
            setRegistryinfo("isBlGetSold", cbBlGetSold.Checked)
            setRegistryinfo("isFactureGetSold", cbFactureGetSold.Checked)
            setRegistryinfo("allowAddElement_to", allowAddElement_to.Checked)

            Form1.useValue_CUMP = cbCump.Checked
            Form1.isBaseOnOneTva = cbBaseOnOneTva.Checked
            Form1.isBaseOnTTC = cbBaseOnTTC.Checked
            Form1.printRef = cbImpRef.Checked
        Catch ex As Exception
        End Try

    End Sub
    'fonts
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click, Button19.Click
        Try
            setRegistryinfo("fontName_Normal", txtnn.text)
            setRegistryinfo("fontName_Title", txtnt.text)
            setRegistryinfo("fontName_Small", txtns.text)
            setRegistryinfo("fontSize_Normal", txtsn.text)
            setRegistryinfo("fontSize_Title", txtst.text)
            setRegistryinfo("fontSize_Small", txtss.text)

            setRegistryinfo("fontName_PV", txtnpv.text)
            setRegistryinfo("fontSize_PV", txtspv.text)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbHasEPBonTransport.CheckedChanged
        Try
            setRegistryinfo("hasEntete_BonTransport", cbHasEPBonTransport.Checked)
            Form1.hasEntete_BonTransport = cbHasEPBonTransport.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'check Users
        Dim pwdwin As New PWDPicker
        Dim adm As New AddAdmins

        If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then

            If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then

                If adm.ShowDialog = Windows.Forms.DialogResult.OK Then



                End If
            End If
        End If
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'check Users

        Dim str As String = "Vous été sur le point de créer une nouvelle exercice Comptable  "
        str &= vbNewLine & "si vous ete sure merci de sisaire le mote de passe"
        str &= vbNewLine & "de  admin pour continue "
        str &= vbNewLine & "ancien exercices est :"
        str &= vbNewLine & Form1.Exercice

        If MsgBox(str, MsgBoxStyle.YesNo, "Nouvel exercice comptable") = MsgBoxResult.Yes Then
            Dim pwdwin As New PWDPicker
            Dim NE As New AddExercice

            If pwdwin.ShowDialog = Windows.Forms.DialogResult.OK Then
                If pwdwin.DGV1.SelectedRows(0).Cells(2).Value = "admin" Then


                    If NE.ShowDialog = DialogResult.OK Then

                        setRegistryinfo("zeros_number", NE.txtz.text)

                        Using z As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                            Dim params2 As New Dictionary(Of String, Object)
                            Dim n = NE.txtn.text
                            If IsNothing(n) Then
                                n = "0"
                            Else
                                If CInt(n) > 0 Then
                                    n = n - 1
                                End If
                            End If


                            Dim id As String = NE.txty.text & NE.txtz.text & n.ToString
                            params2.Add("id", id)
                            z.InsertRecord("Sell_Facture", params2)
                            z.InsertRecord("Devis", params2)
                            z.InsertRecord("Commande_Client", params2)
                            z.InsertRecord("Bon_Livraison", params2)
                            z.InsertRecord("Buy_Facture", params2)
                            z.InsertRecord("Bon_Commande", params2)
                            z.InsertRecord("Bon_Achat", params2)
                            z.InsertRecord("Sell_Avoir", params2)
                            z.InsertRecord("Bon_Transport", params2)


                            z.DeleteRecords("Sell_Facture", params2)
                            z.DeleteRecords("Devis", params2)
                            z.DeleteRecords("Commande_Client", params2)
                            z.DeleteRecords("Bon_Livraison", params2)
                            z.DeleteRecords("Buy_Facture", params2)
                            z.DeleteRecords("Bon_Commande", params2)
                            z.DeleteRecords("Bon_Achat", params2)
                            z.DeleteRecords("Sell_Avoir", params2)
                            z.DeleteRecords("Bon_Transport", params2)


                            params2.Clear()
                            params2.Add("Mid", id)

                            z.InsertRecord("Mission", params2)
                            z.DeleteRecords("Mission", params2)


                            params2.Clear()
                            params2.Add("isActive", False)
                            z.UpdateRecordAll("Exercice", params2)

                            params2.Clear()
                            params2.Add("name", NE.txtnm.text)
                            params2.Add("startDate", Now.Date)
                            params2.Add("endDate", Now.Date.AddYears(1))
                            params2.Add("isActive", True)
                            Dim ex = z.InsertRecord("Exercice", params2, True)

                            Form1.Exercice = ex
                            MsgBox(str, MsgBoxStyle.Information, "Nouvel exercice comptable" & vbNewLine & "Exircice N° : " & ex)
                        End Using

                    End If
                End If
            End If
        End If
    End Sub
    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked

        Dim NE As New AddExercice
        NE.txtnm.Enabled = False
        NE.txtn.Enabled = False
        NE.txty.Enabled = False

        If NE.ShowDialog = DialogResult.OK Then

            setRegistryinfo("zeros_number", NE.txtz.text)
            Form1.zeros = NE.txtz.text
        End If
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Try
            setRegistryinfo("txtEchBon", txtEchBon.Text)
            setRegistryinfo("txtEchFct", txtEchFct.Text)

            Form1.Ech_Bon = txtEchBon.Text
            Form1.Ech_Facture = txtEchFct.Text

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                txtPathImg.Text = directoryName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", txtPathImg.Text)
            Form1.ImgPah = txtPathImg.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                txtPathSvgd.Text = directoryName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "PathSvgd", txtPathSvgd.Text)
            Form1.SvgdPah = txtPathSvgd.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                txtPathBound.Text = directoryName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "PathBound", txtPathBound.Text)

            Form1.BoundDbPath = txtPathBound.Text

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim stok As New AddEditDepot
        If stok.ShowDialog = Windows.Forms.DialogResult.OK Then
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim clc As New ChooseDepot
        If clc.ShowDialog = DialogResult.OK Then
            Form1.mainDepot = clc.dpid
            setRegistryinfo("mainDepot", clc.dpid)
        End If
    End Sub
    'colors
    Private Sub plDefRow_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plDefRow.DoubleClick
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            plDefRow.BackColor = cr.Color
            setRegistryinfo("Color_Default_Row", cr.Color.ToArgb.ToString)
            Form1.Color_Default_Row = cr.Color
        End If
    End Sub
    Private Sub plAltRow_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plAltRow.DoubleClick

        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            plAltRow.BackColor = cr.Color
            setRegistryinfo("Color_Alternating_Row", cr.Color.ToArgb.ToString)
            Form1.Color_Alternating_Row = cr.Color
        End If
    End Sub
    Private Sub plSelRow_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles plSelRow.DoubleClick
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            plSelRow.BackColor = cr.Color
            setRegistryinfo("Color_Selected_Row", cr.Color.ToArgb.ToString)
            Form1.Color_Selected_Row = cr.Color
        End If
    End Sub
    Private Sub lbDefaultText_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDefaultText.DoubleClick
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            lbDefaultText.ForeColor = cr.Color
            setRegistryinfo("Color_Default_Text", cr.Color.ToArgb.ToString)
            Form1.Color_Default_Text = cr.Color
        End If
    End Sub
    Private Sub lbSelectText_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSelectText.DoubleClick
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then

            lbSelectText.ForeColor = cr.Color
            setRegistryinfo("Color_Selected_Text", cr.Color.ToArgb.ToString)
            Form1.Color_Selected_Text = cr.Color
        End If

    End Sub
    'set params prefix
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Try
            setRegistryinfo("prf_s_dv", txtdv.Text)
            setRegistryinfo("prf_s_cm", txtcm.Text)
            setRegistryinfo("prf_s_bl", txtbl.Text)
            setRegistryinfo("prf_s_fc", txtfc.Text)
            setRegistryinfo("prf_s_av", txtav.Text)

            setRegistryinfo("prf_b_bc", txt_bc.Text)
            setRegistryinfo("prf_b_ba", txt_ba.Text)
            setRegistryinfo("prf_b_fc", txt_fc.Text)
            setRegistryinfo("prf_b_av", txt_av.Text)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Setting_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        HandleRegistryinfo()
    End Sub
     
    
    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Dim gch As New gChooseDesign
        If gch.ShowDialog = DialogResult.OK Then
            Dim gf As New gForm
            gf.localname = gch.localName
            gf.loadxml()


            If gf.ShowDialog = DialogResult.OK Then

            End If
        End If
    End Sub

    Private Sub cbNormalImp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNormalImp.CheckedChanged

        Try
            setRegistryinfo("normat_Print_Style", cbNormalImp.Checked)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpPos.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_POS", txtImpPos.Text)
            Form1.printer_POS = txtImpPos.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click

        Try
            setRegistryinfo("SearchBy", cbSearchBy.Text)
            setRegistryinfo("modeSearch_isCode", cbSearchByCode.Checked)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Try
            Dim OPF As New OpenFileDialog
            If OPF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim fi As New IO.FileInfo(OPF.FileName)
                Dim directoryName As String = fi.DirectoryName
                txtDataComp.Text = directoryName
            End If

            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "Data_Comp_Path", txtDataComp.Text)

            Form1.Data_Comp_Path = txtDataComp.Text

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click, Panel11.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
        plPos.Height = 777
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Try
            setRegistryinfo("pvLongerbt", CInt(txtWpv.Text))
            setRegistryinfo("pvLargebt", CInt(CInt(txtHpv.Text)))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
