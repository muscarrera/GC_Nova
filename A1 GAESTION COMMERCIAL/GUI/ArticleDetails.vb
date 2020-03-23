Public Class ArticleDetails

    Dim _arid As Integer
    Dim dt_Cat As DataTable

    Public Property arid As Integer
        Get
            Return _arid
        End Get
        Set(ByVal value As Integer)
            _arid = value

            If value > 0 Then

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    dt_Cat = a.SelectDataTable("Category", {"*"})

                    Dim params As New Dictionary(Of String, Object)
                    params.Add("arid", value)

                    Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)


                    If dt.Rows.Count > 0 Then
                        Dim ctg As String = ""

                        Dim cid As Integer = IntValue(dt, "cid", 0)
                        Try
                            If cid > 0 Then
                                Dim query = From d In dt_Cat.AsEnumerable()
                                            Where d.Field(Of Integer)(0) = cid
                                            Select d

                                Dim r As DataTable = query.CopyToDataTable()

                                ctg = r.Rows(0).Item("name")
                            End If

                            lbCat.Text = ctg
                            lbRef.Text = StrValue(dt, "ref", 0)
                            lbName.Text = StrValue(dt, "name", 0)
                            lbStk.Text = GetArticleStock(value)


                            Dim sp = DblValue(dt, "sprice", 0)
                            Dim bp = DblValue(dt, "bprice", 0)

                            If Form1.isBaseOnTTC Then
                                Dim tv = DblValue(dt, "tva", 0)
                                If Form1.isBaseOnOneTva Then tv = Form1.tva

                                sp += sp * tv / 100
                                bp += bp * tv / 100
                            End If


                            lbBprice.Text = String.Format("{0:n}", bp)
                            lbSprice.Text = String.Format("{0:n}", sp)

                            Try
                                Dim STR As String = Form1.ImgPah & "\art" & StrValue(dt, "img", 0)
                                Dim pmg2 As New Bitmap(STR)

                                PictureBox1.BackgroundImage = pmg2
                            Catch ex As Exception
                                PictureBox1.BackgroundImage = My.Resources.BGpRD
                            End Try


                        Catch ex As Exception
                        End Try
                    End If
                End Using





            End If



        End Set
    End Property
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



    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim mv As New TransformeStock
        mv.arid = arid
        If mv.ShowDialog = Windows.Forms.DialogResult.OK Then
            lbStk.Text = GetArticleStock(arid)
        End If
    End Sub
End Class