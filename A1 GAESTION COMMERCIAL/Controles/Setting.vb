Public Class Setting

    Dim PrintDlg As New PrintDialog

    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpfct.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("printer_Facture", txtImpfct.Text)
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

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click, Button11.Click
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
End Class
