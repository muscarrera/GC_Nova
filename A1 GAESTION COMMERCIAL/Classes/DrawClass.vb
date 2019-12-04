Public Class DrawClass
    Implements IDisposable
    Dim pen As New Pen(Brushes.Black, 1.0F)
    Dim pn As New Pen(Brushes.Black, 0.5F)

    Dim fnt As New Font(Form1.fontName_Normal, Form1.fontSize_Normal)
    Dim fntTitle As New Font(Form1.fontName_Title, Form1.fontSize_Title, FontStyle.Bold)
    Dim fntsmall As New Font(Form1.fontName_Small, Form1.fontSize_Small)

    Dim sf_L As New StringFormat()
    Dim sf_R As New StringFormat()
    Dim sf_C As New StringFormat()

    Private l As Integer = 250

    Public Sub New()
        sf_L.Alignment = StringAlignment.Near
        sf_R.Alignment = StringAlignment.Far
        sf_C.Alignment = StringAlignment.Center
    End Sub



    Public Sub DrawFacture(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal ds As DataList,
                           ByVal title As String, ByVal entete As Boolean,
                           ByVal Pr_Id As String, ByVal with_Date As Boolean,
                           ByVal with_Price As Boolean, ByRef m As Integer)
        Try

            Dim fctid As Integer = ds.Id
            If Pr_Id > 0 Then fctid = Pr_Id

            Dim clientName As String = ds.Entete.ClientName
            Dim data As DataTable = ds.DataSource

            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Dim remise = ds.TB.Remise
            Dim ht As String = String.Format("{0:n}", ds.Total_Ht)
            Dim Ttva As String = String.Format("{0:n}", ds.TB.TVA)
            Dim ttc As String = String.Format("{0:n}", ds.TB.TotalTTC)

            Dim isCache As Boolean = (ds.TB.ModePayement = "Cache")

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(ds.Entete.FactureDate.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(title & "  N° : " & Form1.prefix & fctid, fntTitle, Brushes.Black, 65, 165)

            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)

            Dim str As String = "[" & ds.Entete.Client.cid & "]"
            str &= vbNewLine
            str &= ds.Entete.ClientAdresse
            str &= vbNewLine
            str &= "ICE : " & ds.Entete.Client.ICE

            e.Graphics.DrawString(str, fnt, Brushes.Black, 365, 200)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 240)

            Dim a As Integer = 0
            If remise > 0 Then
                a = 50
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(630, l + 5, 40, 25), sf_R)
                e.Graphics.DrawLine(pen, 630, l + 20, 670, l + 20)
            End If

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 460 - a, 25), sf_L)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(525 - a, l + 5, 65, 25), sf_R)
            e.Graphics.DrawString("P.U", fnt, Brushes.Black, New RectangleF(600 - a, l + 5, 70, 25), sf_R)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(680, l + 5, 90, 25), sf_R)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 515 - a, l + 20)
            e.Graphics.DrawLine(pen, 525 - a, l + 20, 590, l + 20)
            e.Graphics.DrawLine(pen, 600 - a, l + 20, 670, l + 20)
            e.Graphics.DrawLine(pen, 680, l + 20, 770, l + 20)

            l = 280

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim Ref As String = data.Rows(m).Item("ref")
                Dim prdName As String = data.Rows(m).Item("name")
                Dim qte As String = data.Rows(m).Item("qte").ToString
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") / 1.2))
                Dim total As String = String.Format("{0:n}", CDec((data.Rows(m).Item("price") / 1.2) * data.Rows(m).Item("qte")))

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 460 - a)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 460 - a, size.Height), sf_L)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(527 - a, l, 71, 25), sf_R)
                If with_Price Then e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(602 - a, l, 76, 25), sf_R)
                If with_Price Then e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(682, l, 90, 25), sf_R)

                If a > 0 Then
                    If with_Price Then e.Graphics.DrawString(data.Rows(m).Item("remise") & " %", fnt, Brushes.Black, New RectangleF(632, l + 5, 37, 25), sf_R)
                End If

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)

            If remise > 0 Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
                If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
                l += 20
            End If

            If isCache Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Droit de timbre", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
                If with_Price Then e.Graphics.DrawString(String.Format("{0:F}", (ds.Total_Ht - remise) * 0.0025), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
                ttc = String.Format("{0:n}", CDec(ds.TB.TotalTTC + ((ds.TB.TotalTTC - remise) * 0.0025)))
                l += 20
            End If

            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sf_R)
            e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

            If isCache Then l -= 20
            If remise > 0 Then l -= 20

            Dim strTotal As String = "Arrêté la présente facture à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
            Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
            If with_Price Then e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf_L)

            e.Graphics.DrawLine(pn, 60, l + sze.Height + 35, 160, l + sze.Height + 35)
            If with_Price Then e.Graphics.DrawString("* Mode de paiement : " & ds.TB.ModePayement, fntsmall, Brushes.Black, New RectangleF(60, l + sze.Height + 45, 266, 22), sf_L)

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h - 20, 750, 120)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub
    Public Sub DrawFactureFromList(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal ds As Facture, ByVal title As String,
                                   ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try


            Dim fctid As Integer = ds.id
            If Pr_Id > 0 Then fctid = Pr_Id

            Dim clientName As String = ds.client.name
            Dim data As DataTable = ds.DataSource

            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Dim remise = ds.remise
            Dim ht As String = String.Format("{0:n}", ds.totalHt)
            Dim Ttva As String = String.Format("{0:n}", ds.tva)
            Dim ttc As String = String.Format("{0:n}", ds.TotalTTC)

            Dim isCache As Boolean = (ds.modePayement = "Cache")

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(ds.dte.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(title & "  N° : " & Form1.prefix & fctid, fntTitle, Brushes.Black, 65, 165)

            'print Client 
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 65, 200)

            Dim str As String = "[" & ds.client.cid & "]"
            str &= vbNewLine
            str &= ds.client.adresse
            str &= vbNewLine
            str &= "ICE : " & ds.client.ICE

            e.Graphics.DrawString(str, fnt, Brushes.Black, 365, 200)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 240)

            Dim a As Integer = 0
            If remise > 0 Then
                a = 50
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(630, l + 5, 40, 25), sf_R)
                e.Graphics.DrawLine(pen, 630, l + 20, 670, l + 20)
            End If

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 460 - a, 25), sf_L)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(525 - a, l + 5, 65, 25), sf_R)
            e.Graphics.DrawString("P.U", fnt, Brushes.Black, New RectangleF(600 - a, l + 5, 70, 25), sf_R)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(680, l + 5, 90, 25), sf_R)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 515 - a, l + 20)
            e.Graphics.DrawLine(pen, 525 - a, l + 20, 590, l + 20)
            e.Graphics.DrawLine(pen, 600 - a, l + 20, 670, l + 20)
            e.Graphics.DrawLine(pen, 680, l + 20, 770, l + 20)

            l = 280

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim Ref As String = data.Rows(m).Item("ref")
                Dim prdName As String = data.Rows(m).Item("name")
                Dim qte As String = data.Rows(m).Item("qte").ToString
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") / 1.2))
                Dim total As String = String.Format("{0:n}", CDec((data.Rows(m).Item("price") / 1.2) * data.Rows(m).Item("qte")))

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 460 - a)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 460 - a, size.Height), sf_L)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(527 - a, l, 71, 25), sf_R)
                If with_Price Then e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(602 - a, l, 76, 25), sf_R)
                If with_Price Then e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(682, l, 90, 25), sf_R)

                If a > 0 Then
                    If with_Price Then e.Graphics.DrawString(data.Rows(m).Item("remise") & " %", fnt, Brushes.Black, New RectangleF(632, l + 5, 37, 25), sf_R)
                End If

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)

            If remise > 0 Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
                If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
                l += 20
            End If

            If isCache Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Droit de timbre", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
                If with_Price Then e.Graphics.DrawString(String.Format("{0:F}", (ds.totalHt - remise) * 0.0025), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
                ttc = String.Format("{0:n}", CDec(ds.TotalTTC + (ds.totalHt - remise) * 0.0025))
                l += 20
            End If

            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sf_R)
            e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

            If isCache Then l -= 20
            If remise > 0 Then l -= 20

            Dim strTotal As String = "Arrêté la présente facture à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
            Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
            If with_Price Then e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf_L)

            e.Graphics.DrawLine(pn, 60, l + sze.Height + 35, 160, l + sze.Height + 35)
            If with_Price Then e.Graphics.DrawString("* Mode de paiement : " & ds.modePayement, fntsmall, Brushes.Black, New RectangleF(60, l + sze.Height + 45, 266, 22), sf_L)

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h - 20, 750, 120)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub

    Public Sub DrawFactureFromList(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try

            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width


            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 160), New Point(600, 160),
                                                   New Point(612, 175), New Point(600, 190),
                                                   New Point(60, 190)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 160), New Point(770, 160),
                       New Point(770, 190), New Point(606, 190),
                       New Point(618, 175)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"), fnt, Brushes.Black, New RectangleF(620, 167, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString("Factures", fntTitle, Brushes.Black, 65, 165)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 200)

            'Search Details
            'Dim str As String = "[" & ds.client.cid & "]"
            'str &= vbNewLine
            'str &= ds.client.adresse
            'str &= vbNewLine
            'str &= "ICE : " & ds.client.ICE

            'e.Graphics.DrawString(str, fnt, Brushes.Black, 365, 200)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 240)

            Dim a As Integer = 0

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(60, l + 5, 60, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(122, l + 5, 400 - a, 25), sf_L)
            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(525 - a, l + 5, 65, 25), sf_L)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(592 - a, l + 5, 80, 25), sf_L)
            e.Graphics.DrawString("Avance", fnt, Brushes.Black, New RectangleF(574, l + 5, 80, 25), sf_L)
            e.Graphics.DrawString(" - ", fnt, Brushes.Black, New RectangleF(656, l + 5, 40, 25), sf_L)

            e.Graphics.DrawLine(pen, 60, l + 20, 60, l + 20)
            e.Graphics.DrawLine(pen, 122 - a, l + 20, 400, l + 20)
            e.Graphics.DrawLine(pen, 525 - a, l + 20, 65, l + 20)
            e.Graphics.DrawLine(pen, 592, l + 20, 80, l + 20)
            e.Graphics.DrawLine(pen, 574, l + 20, 80, l + 20)
            e.Graphics.DrawLine(pen, 656, l + 20, 40, l + 20)

            l = 280

            While m < Data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim ID As String = Form1.prefix & data.Rows(m).Item(0)
                Dim libelle As String = data.Rows(m).Item("name") & " [" & StrValue(data, "cid", m) & "]"
                Dim dte As String = DteValue(data, "date", m).ToString("dd MMM, yyyy")
                Dim total As String = String.Format("{0:n}", DblValue(data, "total", m))
                Dim avance As String = String.Format("{0:n}", DblValue(data, "avance", m))
                Dim etat As String = "Non"
                If BoolValue(data, "isPayed", m) Then etat = "Regle"
                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(libelle, fnt, 400)

                e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(60, l, 60, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(122, l, 400 - a, size.Height), sf_L)
                e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(525 - a, l, 65, 25), sf_L)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(592 - a, l, 80, 25), sf_L)
                e.Graphics.DrawString(avance, fnt, Brushes.Black, New RectangleF(574, l, 80, 25), sf_L)
                e.Graphics.DrawString(etat, fnt, Brushes.Black, New RectangleF(656, l, 40, 25), sf_L)

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            ''''''
            Dim ttva As String = ""
            Dim ht As String = ""
            Dim ttc As String = ""
            Dim remise As String = ""


            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)

            If remise > 0 Then
                e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
                e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
                If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
                l += 20
            End If

            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sf_R)
            e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h - 20, 750, 120)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub













#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
