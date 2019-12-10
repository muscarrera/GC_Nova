Public Class Setting

    Dim PrintDlg As New PrintDialog

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

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
            'TXTImgPah.Text = getRegistryinfo("ImgPah", "C:\")
            'TXTSvgdPah.Text = getRegistryinfo("SvgdPah", "C:\")
            'TXTnumberOfItems.Text = getRegistryinfo("numberOfItems", 22)
            'font
            txtnn.text = getRegistryinfo("fontName_Normal", "Arial")
            txtnt.text = getRegistryinfo("fontName_Title", "Arial")
            txtns.text = getRegistryinfo("fontName_Small", "Arial")
            txtsn.text = getRegistryinfo("fontSize_Normal", 10)
            txtst.text = getRegistryinfo("fontSize_Title", 14)
            txtss.text = getRegistryinfo("fontSize_Small", 8)

            txtImpDv.Text = getRegistryinfo("printer_Devis", "")
            txtImpBon.Text = getRegistryinfo("printer_Bon", "")
            txtImpfct.Text = getRegistryinfo("printer_Facture", "")
            txtImpAv.Text = getRegistryinfo("printer_Avoir", "")
            txtImpPdf.Text = getRegistryinfo("printer_Pdf", "")

            'TXTFAC.Text = getRegistryinfo("Facture_Title", "")
            'Form1.imgEntetePath.Text = getRegistryinfo("imgEntetePath", "")
            'Form1.imgFootherPath.Text = getRegistryinfo("imgFootherPath", "")
            cbImp.Checked = getRegistryinfo("printEnteteOnPaper", False)
            cbImp.Checked = getRegistryinfo("printEnteteOnPdf", False)




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
        plImp.Height = 666
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 666
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 666
        plUser.Height = 1
        plImp.Height = 1
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        plData.Height = 1
        plText.Height = 1
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 666
        plImp.Height = 1
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        plData.Height = 1
        plText.Height = 666
        plPref.Height = 1
        plRole.Height = 1
        plUser.Height = 1
        plImp.Height = 1
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        plData.Height = 666
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
End Class
