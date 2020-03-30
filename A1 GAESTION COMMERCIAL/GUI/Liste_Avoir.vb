Public Class Liste_Avoir
    Dim _cid As Integer
    Private factureTable As String = "Sell_Avoir"

    Public Property CID As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value

            If value = 0 Then Exit Property
            getDetails()
        End Set
    End Property
    Private Sub getDetails()

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim params As New Dictionary(Of String, Object)
            params.Add("cid", CID)
            params.Add("isPayed", False)

            Dim dte As Date = Now.Date
            Dim RestFact As Double = 0
          
            Dim dt = a.SelectDataTable(factureTable, {"*"}, params)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dte > DteValue(dt, "date", i) Then dte = DteValue(dt, "date", i)
                    dg.Rows.Add(False, DteValue(dt, "date", i), IntValue(dt, "id", i), String.Format("{0:n}", CDec(DblValue(dt, "total", i))))
                    RestFact += DblValue(dt, "total", i)
                Next
            End If
            params.Clear()


            lbN.Text = dg.Rows.Count
            lbS.Text = "0"

            lbT.Text = 0
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dg.Rows.Count = 0 Then Me.DialogResult = Windows.Forms.DialogResult.Cancel

        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dg.CellContentClick
        If dg.SelectedRows.Count = 0 Then Exit Sub

        Dim b As Boolean = Not dg.SelectedRows(0).Cells(0).Value
        Dim t = dg.SelectedRows(0).Cells(3).Value
        dg.SelectedRows(0).Cells(0).Value = b

        lbS.Text = CDbl(lbS.Text) + IIf(b, 1, -1)
        lbT.Text = CDbl(lbT.Text) + IIf(b, t, -1 * t)

    End Sub
End Class