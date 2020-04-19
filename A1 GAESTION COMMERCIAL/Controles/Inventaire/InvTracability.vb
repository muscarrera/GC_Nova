Public Class InvTracability

    Event Search(ByRef ds As InvTracability)
    Public dt_in As New DataTable
    Public dt_Out As New DataTable
    Public arid As Integer

    Private Sub btInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btInfo.Click
        Dim sr As New SearchForArticle

        If sr.ShowDialog = DialogResult.OK Then
            txt.text = sr._name & "|" & sr.arid
        End If
    End Sub
    Private Sub btDepot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btDepot.Click
        Dim clc As New ChooseDepot
        If clc.ShowDialog = DialogResult.OK Then
            If clc.dpid = 0 Then
                txtDepot.text = ""
            Else
                txtDepot.text = clc.dpName & "|" & clc.dpid
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If txt.text.Contains("|") = False Then Exit Sub
        If Not IsNumeric(txt.text.Trim.Split("|")(1)) Then Exit Sub

        arid = txt.text.Trim.Split("|")(1)

        RaiseEvent Search(Me)

        filtreTheData()

        'MsgBox(dt_in.Rows.Count & vbNewLine & dt_Out.Rows.Count)

        If dg_D.Rows.Count = 0 Then Exit Sub
        ' select depot name
    End Sub

    Private Sub filtreTheData()

        Dim dt As New DataTable

        If cbIn.Checked = True And cbOut.Checked = False Then
            If Not IsNothing(dt_in) Then dt = dt_in.Copy

        ElseIf cbIn.Checked = False And cbOut.Checked = True Then
            If Not IsNothing(dt_Out) Then dt = dt_Out.Copy
        ElseIf cbIn.Checked = True And cbOut.Checked = True Then
            dt = dt_in.Copy
            dt.Merge(dt_Out.Copy, False)
        Else
            dt.Rows.Clear()
            Exit Sub
        End If

        If IsNothing(dt) Then Exit Sub
        If dt.Columns.Count < 6 Then Exit Sub

        If txtDepot.text.Contains("|") Then

            Dim dp = txtDepot.text.Split("|")(1)
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


        dg_D.DataSource = dt


        dg_D.Columns(0).Visible = False
        dg_D.Columns(2).Visible = False
        dg_D.Columns(3).Visible = False
        dg_D.Columns(5).Visible = False
        dg_D.Columns(6).Visible = False
        dg_D.Columns(8).Visible = False
        dg_D.Columns(9).Visible = False
        dg_D.Columns(13).Visible = False
        dg_D.Columns(7).Visible = False
        
        dg_D.Columns(14).DefaultCellStyle.Font = New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        dg_D.Columns(14).DefaultCellStyle.ForeColor = Form1.Color_Default_Text
        dg_D.Columns(14).AutoSizeMode = DataGridViewAutoSizeColumnMode.None

        Try
            dg_D.Columns(1).HeaderText = "ID"
            dg_D.Columns(4).HeaderText = "Qte"
            dg_D.Columns(10).HeaderText = "Date"
            dg_D.Columns(11).HeaderText = "Entrepote"
            dg_D.Columns(12).HeaderText = "Prix d'achat"
            dg_D.Columns(14).HeaderText = "Libelle"
            dg_D.Columns(15).HeaderText = "prix de vente"
        Catch ex As Exception

        End Try

        dg_D.Sort(dg_D.Columns(10), System.ComponentModel.ListSortDirection.Ascending)

        Try
            dg_D.Columns(1).DisplayIndex = 1
            dg_D.Columns(10).DisplayIndex = 2
            dg_D.Columns(14).DisplayIndex = 3
            dg_D.Columns(4).DisplayIndex = 4
            dg_D.Columns(12).DisplayIndex = 5
            dg_D.Columns(11).DisplayIndex = 7
            dg_D.Columns(15).DisplayIndex = 6
        Catch ex As Exception
        End Try

        Dim sum As Double
        Try
            sum = Convert.ToDouble(dt.Compute("SUM(qte)", String.Empty))
            lbQte.Text = sum & " U"
        Catch ex As Exception
            lbQte.Text = "... "
        End Try


        lbLnbr.Text = dg_D.Rows.Count & " Lines"
        Me.Height = (dg_D.Rows.Count * 40) + 250

        If Me.Height < 700 Then Me.Height = 700
    End Sub

    Private Sub cbOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOut.CheckedChanged, cbIn.CheckedChanged
        filtreTheData()
    End Sub

    Private Sub txtDepot_TxtChanged() Handles txtDepot.TxtChanged
        filtreTheData()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SaveDataToHtml(dg_D, "Traçabilité")
    End Sub
End Class
