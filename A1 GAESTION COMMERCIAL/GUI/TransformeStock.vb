Public Class TransformeStock
    Private _arid As Integer = 0
    Dim ds_id1 As Integer = 0
    Dim qte1 As Double = 0
    Dim qte2 As Double = 0
    Dim ds_id2 As Integer = 0
    Dim cid As Integer = 0

    Public Property arid As Integer
        Get
            Return _arid
        End Get
        Set(ByVal value As Integer)
            _arid = value
            'btdp.visible = False

            If value > 0 Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("arid", value)


                    Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
                    If dt.Rows.Count > 0 Then
                        lbName.Text = dt.Rows(0).Item("name")
                        cid = dt.Rows(0).Item("cid")
                        Try
                            Dim STR As String = Form1.ImgPah & "\art" & dt.Rows(0).Item("img")
                            Dim pmg2 As New Bitmap(STR)

                            PictureBox1.BackgroundImage = pmg2
                        Catch ex As Exception
                            PictureBox1.BackgroundImage = My.Resources.BGpRD
                        End Try

                    End If
                End Using



            End If
        End Set
    End Property
    Private Sub TransformeStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)



        Cb1_SelectedIndexChanged(Nothing, Nothing)
        Cb2_SelectedIndexChanged(Nothing, Nothing)

        If Form1.admin = False Then Button6.Enabled = False
    End Sub

    Private Sub Cb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb1.SelectedIndexChanged
        Dim dpid As Integer = Cb1.SelectedValue
        ds_id1 = 0
        qte1 = 0
        lbQteStock.Text = 0
        If dpid = 0 Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", arid)
            params.Add("dpid", dpid)

            Dim dt As DataTable = a.SelectDataTable("Details_Stock", {"*"}, params)
            If dt.Rows.Count > 0 Then
                ds_id1 = dt.Rows(0).Item(0)
                qte1 = dt.Rows(0).Item("qte")
                lbQteStock.Text = qte1
            End If

        End Using
    End Sub
    Private Sub Cb2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cb2.SelectedIndexChanged
        Dim dpid As Integer = Cb2.SelectedValue
        ds_id2 = 0
        qte2 = 0
        lbQteStock2.Text = 0
        If dpid = 0 Then Exit Sub

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            Dim params As New Dictionary(Of String, Object)
            params.Add("arid", arid)
            params.Add("dpid", dpid)

            Dim dt As DataTable = a.SelectDataTable("Details_Stock", {"*"}, params)
            If dt.Rows.Count > 0 Then
                ds_id2 = dt.Rows(0).Item(0)
                qte2 = dt.Rows(0).Item("qte")
                lbQteStock2.Text = qte2
            End If
        End Using
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim dpid1 As Integer = Cb1.SelectedValue
        Dim dpid2 As Integer = Cb2.SelectedValue

        If ds_id1 = 0 Then Exit Sub
        If dpid1 = 0 Then Exit Sub
        If dpid2 = 0 Then Exit Sub
        If arid = 0 Then Exit Sub
        If dpid1 = dpid2 Then Exit Sub
        If Not IsNumeric(txtQte.text) Or txtQte.text = 0 Then Exit Sub



        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim qte = qte1 - CDbl(txtQte.text)

            Dim params As New Dictionary(Of String, Object)
            Dim where As New Dictionary(Of String, Object)
            params.Add("qte", qte)
            where.Add("id", ds_id1)

            a.UpdateRecord("Details_Stock", params, where)
            params.Clear()
            where.Clear()

            If ds_id2 > 0 Then
                qte = qte2 + CDbl(txtQte.text)

                params.Add("qte", qte)
                where.Add("id", ds_id2)
                a.UpdateRecord("Details_Stock", params, where)
            Else
                qte = CDbl(txtQte.text)
                params.Add("arid", arid)
                params.Add("dpid", dpid2)
                params.Add("cid", cid)
                params.Add("qte", qte)
                a.InsertRecord("Details_Stock", params)
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK

        End Using


    End Sub
End Class