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

        ' Add any initialization after the InitializeComponent() call.
        txtnn.text = getRegistryinfo("fontName_Normal", "Arial")
        txtnt.text = getRegistryinfo("fontName_Title", "Arial")
        txtns.text = getRegistryinfo("fontName_Small", "Arial")
        txtsn.text = getRegistryinfo("fontSize_Normal", 10)
        txtst.text = getRegistryinfo("fontSize_Title", 14)
        txtss.text = getRegistryinfo("fontSize_Small", 8)


        txtCellWidth.Text = getRegistryinfo("cellWidth", 8)
        HandleRegistryinfo()
    End Sub

    Public Sub HandleRegistryinfo()
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

        Catch ex As Exception

        End Try

    End Sub
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 777
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 777
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1




    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 777
        plUser.Height = 1
        plImp.Height = 1
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Form1.admin = False Then Exit Sub


        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 777
        plImp.Height = 1
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        plData.Height = 1
        plText.Height = 777
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        plData.Height = 777
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
    End Sub
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
            setRegistryinfo("isBaseOnOneTva", cbBaseOnOneTva.Checked)
            setRegistryinfo("isBaseOnTTC", cbBaseOnTTC.Checked)
            setRegistryinfo("isBonTTC", cbBlTTC.Checked)

            If txtTrial.Visible Then
                Dim a As Integer = 11
                If txtTrial.Text = "TRn-1" Then a = -1
                setRegistryinfo("nbrPrOp_Tr", a)
            End If


                Form1.isBaseOnOneTva = cbBaseOnOneTva.Checked
                Form1.isBaseOnTTC = cbBaseOnTTC.Checked
            Form1.isBonTTC = cbBlTTC.Checked

        Catch ex As Exception

        End Try



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

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            setRegistryinfo("fontName_Normal", txtnn.text)
            setRegistryinfo("fontName_Title", txtnt.text)
            setRegistryinfo("fontName_Small", txtns.text)
            setRegistryinfo("fontSize_Normal", txtsn.Text)
            setRegistryinfo("fontSize_Title", txtst.Text)
            setRegistryinfo("fontSize_Small", txtss.Text)
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
                            If IsNothing(n) = False Then
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

End Class
