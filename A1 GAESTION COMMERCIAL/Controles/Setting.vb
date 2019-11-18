Public Class Setting

    Dim PrintDlg As New PrintDialog

    Private Sub Button71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button71.Click
        If PrintDlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        Try
            txtImpfct.Text = PrintDlg.PrinterSettings.PrinterName
            setRegistryinfo("FacturePrinter", txtImpfct.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub
End Class
