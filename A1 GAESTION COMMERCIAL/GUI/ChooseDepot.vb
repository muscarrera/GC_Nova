Public Class ChooseDepot

    Public dpid As Integer = 0
    Public dpName As String = ""


    Private Sub ChooseDepot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            dpid = DataGridView1.SelectedRows(0).Cells(0).Value
            dpName = DataGridView1.SelectedRows(0).Cells(1).Value
        Else
            dpid = 0
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        dpid = 0

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class