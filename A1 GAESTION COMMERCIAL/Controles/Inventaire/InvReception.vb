Public Class InvReception

    Dim _mode As String

    Public isSell As Boolean
    Public dt_D As New DataTable

    Public tb_C As String
    Public tb_B As String
    Public tb_D As String

    Event Search(ByRef ds As InvReception)
    Event Apercu(ByRef ds As InvReception)
    Event Print(ByRef ds As InvReception)


    Public Property Mode As String
        Get
            Return _mode
        End Get
        Set(ByVal value As String)
            _mode = value

        End Set
    End Property

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        RaiseEvent Search(Me)
        FiltreData()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If Mode <> "LIST" Then Exit Sub
        If Form1.plBody.Controls.Count = 0 Then Exit Sub
        If Not TypeOf pl.Controls(0) Is DataGridView Then Exit Sub
 
        Dim dg As DataGridView = pl.Controls(0)
        If dg.SelectedRows.Count = 0 Then Exit Sub

        RaiseEvent Apercu(Me)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent Print(Me)
    End Sub

    Private Sub FiltreData()

        If cbDetail.Checked = False Then Exit Sub

        Dim dg As DataGridView = pl.Controls(0)

        Dim dt As DataTable = dt_D.Copy

        If cbDepot.SelectedValue > 0 Then

            Dim dp = cbDepot.SelectedValue
            If IsNumeric(dp) Then
                Dim result = From myRow As DataRow In dt.Rows
                                        Where myRow("depot") = dp Select myRow
                If result.Count Then
                    dt = result.CopyToDataTable
                Else
                    dt.Rows.Clear()
                End If
            End If
        End If

        If txt.text.Contains("|") Then

            Dim cid = txt.text.Split("|")(0)

            Dim result = From myRow As DataRow In dt.Rows
                                    Where myRow("nameDg").ToString.ToUpper = cid.ToUpper Select myRow
            If result.Count Then
                dt = result.CopyToDataTable
            Else
                dt.Rows.Clear()
            End If
        End If

        If cbAccum.Checked Then
            Dim query = From row In dt.AsEnumerable()
                        Group row By dateGroup = New With {Key .name = row.Field(Of String)("ArtName"),
                                                           .ref = row.Field(Of String)("ref"),
                                                            .depot = row.Field(Of Integer)("depot")} Into Group
                        Select New With {Key .name = dateGroup.name, Key .Ref = dateGroup.ref,
                                           .Qte = Group.Sum(Function(x) x.Field(Of Decimal)("qte")),
                                          .Nbre = Group.Count(Function(x) x.Field(Of String)("ref"))}


            dg.DataSource = query.ToList

            lbLnbr.Text = dg.Rows.Count & " Lines"
            Me.Height = (dg.Rows.Count * 40) + 500

            Exit Sub

        End If
        
        dg.DataSource = dt

        'dg.Columns(0).Visible = False
        'dg.Columns(8).Visible = False
        'dg.Columns(9).Visible = False
        'dg.Columns(10).Visible = False
        'dg.Columns(8).Visible = False
        'dg.Columns(9).Visible = False
        'dg.Columns(10).Visible = False

        dg.Columns(3).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        dg.Columns(3).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
        dg.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        dg.Columns(3).FillWeight = 300
        dg.Columns(3).Width = 300

        dg.Columns(0).HeaderText = "ID/N°"
        dg.Columns(1).HeaderText = "Date"
        dg.Columns(2).HeaderText = "Libellé"
        dg.Columns(3).HeaderText = "QTE"
        dg.Columns(4).HeaderText = "Entrepôte"
        dg.Columns(5).HeaderText = "Dp N°"
        dg.Columns(6).HeaderText = "Article"
        dg.Columns(6).DisplayIndex = 4

        'End If


        lbLnbr.Text = dg.Rows.Count & " Lines"
        Me.Height = (dg.Rows.Count * 40) + 500
    End Sub
    
    Private Sub cbDepot_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDepot.SelectedIndexChanged
        FiltreData()
    End Sub

    Private Sub cbAccum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAccum.CheckedChanged
        FiltreData()
    End Sub

    Private Sub txt_TxtChanged() Handles txt.TxtChanged
        FiltreData()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If pl.Controls.Count > 0 Then
            If TypeOf pl.Controls(0) Is DataGridView Then
                Dim _ds As DataGridView = pl.Controls(0)
                Dim str = "Reception"
                If isSell Then str = "Livraison"
                SaveDataToHtml(_ds, str)
                Exit Sub
            End If
        End If
    End Sub
End Class
