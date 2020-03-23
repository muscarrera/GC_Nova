Public Class SearchForArticle
    Dim params As New Dictionary(Of String, Object)
    Dim dt_Cat As DataTable
    Dim arid As Integer = 0

    Public _ref As String = ""

    Private Sub SearchForArticle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CL.ListeOfString.Clear()
        CL.ListeOfNumber.Clear()
        CL.ListeOfDates.Clear()
        CL.ListeOfBoolean.Clear()

        CL.ListeOfString.Add("Categorie", "CT")
        CL.ListeOfString.Add("Reference", "RF")
        CL.ListeOfString.Add("Nom", "NM")
        '''''/// numbers
        CL.ListeOfNumber.Add("Prix Min", "PM")
        CL.ListeOfNumber.Add("Prix Max", "PX")
        CL.ListeOfNumber.Add("Reference", "RF")
        CL.ListeOfNumber.Add("N°", "ID")
        CL.ListeOfNumber.Add("Nom", "NM")
        '''''/// Booleans
        CL.ListeOfBoolean.Add("Promo", "PR")

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            dt_Cat = a.SelectDataTable("Category", {"*"})
        End Using


    End Sub
    Private Sub txt_TxtChanged() Handles txt.TxtChanged
        If txt.text.Trim = "" Then
            CL.Mode = 0
            plTag.Height = 1
        ElseIf IsNumeric(txt.text) Then
            CL.Mode = 2
            plTag.Height = 140
        ElseIf IsDate(txt.text) Then
            CL.Mode = 4
            plTag.Height = 1
        Else
            If txt.text.ToUpper.Trim = "NO" Or txt.text.ToUpper.Trim = "NON" Or
                txt.text.ToUpper.Trim = "OUI" Or txt.text.ToUpper.Trim = "O" Then
                CL.Mode = 3
                plTag.Height = 40
            Else
                CL.Mode = 1
                plTag.Height = 120
            End If
        End If
    End Sub
    Private Sub CL_LabelClicked(ByVal key As System.String, ByVal val As System.String) Handles CL.LabelClicked

        Dim myKey As String = "[name] Like "
        Dim myVal As New Object

        Select Case val

            Case "NM"
                myKey = "[name] Like "
                myVal = "%" & txt.text & "%"
           
            Case "RF"
                myKey = "ref Like "
                myVal = "%" & txt.text & "%"
            Case "CT"
                myKey = "cid = "

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    If IsNumeric(txt.text) Then
                        myVal = txt.text
                    Else
                        Dim where As New Dictionary(Of String, Object)
                        where.Add("[name] Like ", txt.text & "%")

                        Dim dt = a.SelectDataTableSymbols("Category", {"*"}, where)
                        If dt.Rows.Count > 0 Then
                            myVal = CInt(dt.Rows(0).Item(0))
                            txt.text = dt.Rows(0).Item("name")
                        End If
                    End If
                End Using

            Case "ID"
                myKey = "arid Like "
                myVal = "%" & txt.text & "%"
            Case "PM"
                myKey = "sprice > "
                myVal = txt.text
            Case "PX"
                myKey = "sprice < "
                myVal = txt.text
           
            Case "PR"
                Dim isPayed As Boolean = True
                Dim v = txt.text
                If v.ToUpper = "NO" Or v.ToUpper = "NON" Or v.ToUpper = "N" Then
                    isPayed = False
                End If
                myKey = "isPromo = "
                myVal = isPayed

        End Select

        Dim tg As New Tag
        tg.myKey = myKey
        tg.myVal = myVal


        tg.val = txt.text
        tg.key = key

        FL.Controls.Add(tg)
        AddHandler tg.DeleteTag, AddressOf DeleteTag

        txt.text = ""
        Search()
    End Sub
    Private Sub DeleteTag(ByVal T As A1_GAESTION_COMMERCIAL.Tag)
        FL.Controls.Remove(T)
        Search()
    End Sub

    Private Sub Search()
        resetForm()
        DataGridView1.Rows.Clear()
        If FL.Controls.Count = 0 Then Exit Sub


        params.Clear()
        For Each c As Tag In FL.Controls
            Try
                params.Add(c.myKey, c.myVal)
               
            Catch ex As Exception
            End Try
        Next

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTableSymbols("Article", {"*"}, params)


            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim ctg As String = ""

                    Dim cid As Integer = IntValue(dt, "cid", i)
                    Try
                        If cid > 0 Then
                            Dim query = From d In dt_Cat.AsEnumerable()
                                        Where d.Field(Of Integer)(0) = cid
                                        Select d

                            Dim r As DataTable = query.CopyToDataTable()

                            ctg = r.Rows(0).Item("name")
                        End If
                    Catch ex As Exception
                    End Try

                    DataGridView1.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("name"), dt.Rows(i).Item("ref"),
                                          ctg, dt.Rows(i).Item("bprice"), dt.Rows(i).Item("sprice"), dt.Rows(i).Item("img"), dt.Rows(i).Item("tva"))

                Next
            End If
        End Using
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If arid = 0 Then Exit Sub
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If DataGridView1.Rows.Count = 0 Then Exit Sub

        Try
            arid = DataGridView1.SelectedRows(0).Cells(0).Value
            lbName.Text = DataGridView1.SelectedRows(0).Cells(1).Value
            lbRef.Text = DataGridView1.SelectedRows(0).Cells(2).Value
            _ref = CStr(DataGridView1.SelectedRows(0).Cells(2).Value)
            lbCat.Text = DataGridView1.SelectedRows(0).Cells(3).Value


            Dim sp = CDbl(DataGridView1.SelectedRows(0).Cells(5).Value)
            Dim bp = CDbl(DataGridView1.SelectedRows(0).Cells(4).Value)

            If Form1.isBaseOnTTC Then
                Dim tv = CDbl(DataGridView1.SelectedRows(0).Cells(7).Value)
                If Form1.isBaseOnOneTva Then tv = Form1.tva

                sp += sp * tv / 100
                bp += bp * tv / 100
            End If


            lbBprice.Text = String.Format("{0:n}", bp)
            lbSprice.Text = String.Format("{0:n}", sp)
            lbStk.Text = GetArticleStock(arid)
            Try
                Dim STR As String = Form1.ImgPah & "\art" & DataGridView1.SelectedRows(0).Cells(6).Value
                Dim pmg2 As New Bitmap(STR)

                PictureBox1.BackgroundImage = pmg2
            Catch ex As Exception
                PictureBox1.BackgroundImage = My.Resources.BGpRD
            End Try


        Catch ex As Exception
            resetForm()
        End Try

    End Sub
    Private Function GetArticleStock(ByVal id As Integer) As String
        Dim str = "- "
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            If Form1.isWorkinOnStock = False Then Return "------------"
            Dim where As New Dictionary(Of String, Object)


            'For i As Integer=0 to 
            where.Clear()
            where.Add("arid", id)

            Dim dt = a.SelectDataTable("Details_Stock", {"*"}, where)

            If IsNothing(dt) Then Return "------------"


            Try
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i > 0 Then str &= vbNewLine & "- "

                    str &= " Depôt N° " & dt.Rows(i).Item("dpid") & " : " & dt.Rows(i).Item("qte")



                Next
            Catch ex As Exception
            End Try

        End Using
        Return str
    End Function




    Private Sub resetForm()
        arid = 0
        lbName.Text = "-"
        lbRef.Text = "-"
        lbStk.Text = "-"
        lbBprice.Text = "0.00"
        lbSprice.Text = "0.00"
        _ref = ""
        PictureBox1.BackgroundImage = My.Resources.Download_Product_Png_Image_66617_For_Designing_Projects

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mv As New TransformeStock
        mv.arid = arid
        If mv.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbStk.Text = GetArticleStock(arid)
        End If


    End Sub
End Class