Imports System.Data.DataTableExtensions
Imports System.Linq

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

    Public dt_Driver As DataTable = Nothing
    Public dt_Vehicule As DataTable = Nothing

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

            'e.Graphics.FillRectangle(Brushes.Honeydew, 60, l + 25, 300, 65)
            e.Graphics.FillRectangle(Brushes.WhiteSmoke, 60, l, 300, 30)
            e.Graphics.DrawString("FACTURE : ", fntTitle, Brushes.Black, 65, l + 5)
            e.Graphics.DrawString("N° : ", fnt, Brushes.Black, 65, l + 40)
            If with_Date Then e.Graphics.DrawString("Date : ", fnt, Brushes.Black, 65, l + 60)
            If ds.Entete.Bl <> "" Then e.Graphics.DrawString("Réf : ", fnt, Brushes.Black, 65, l + 80)

            e.Graphics.DrawString(Form1.prefix & fctid, fnt, Brushes.Black, 111, l + 40)
            If with_Date Then e.Graphics.DrawString(ds.Entete.FactureDate.ToString("dd/MM/yyyy"), fnt, Brushes.Black, 111, l + 60)
            If ds.Entete.Bl <> "" Then e.Graphics.DrawString(ds.Entete.Bl, fnt, Brushes.Black, 111, l + 80)


            Dim str As String = clientName '& "  [" & ds.Entete.Client.cid & "]"

            str &= vbNewLine
            str &= ds.Entete.ClientAdresse
            str &= vbNewLine
            str &= "ICE : " & ds.Entete.Client.ICE
            Dim size As SizeF = e.Graphics.MeasureString(str, fnt, 300)

            e.Graphics.DrawRectangle(Pens.Black, 460, l, 310, size.Height + 30)
            e.Graphics.DrawString(str, fnt, Brushes.Black, New RectangleF(460, l + 10, 300, CInt(size.Height + 20)), sf_L) '465, l + 10)

            'e.Graphics.DrawString(str, fnt, Brushes.Black, 465, l + 35)

            l += size.Height + 55

            If ds.Entete.CompteId > 0 Then
                str = "En compte de : " & vbNewLine & ds.Entete.lbEnCompte.Text
                size = e.Graphics.MeasureString(str, fnt, 300)
                e.Graphics.DrawRectangle(Pens.Black, 460, l, 310, size.Height + 20)
                e.Graphics.DrawString(str, fnt, Brushes.Black, 465, l + 10)
                l += size.Height + 25
            End If



            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 460, l)

            l += 33

            Dim a As Integer = 0
            Dim AAA = l
            If remise > 0 Then
                a = 60
                e.Graphics.DrawString("Remise", fntsmall, Brushes.Black, New RectangleF(620, l + 5, 55, 15), sf_R)
                e.Graphics.DrawLine(pen, 682, l, 682, l + 22)
            End If
            e.Graphics.DrawRectangle(pen, 55, l, 720, 22)

            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 460 - a, 25), sf_L)
            e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(525 - a, l + 5, 65, 25), sf_R)
            e.Graphics.DrawString("P.U", fnt, Brushes.Black, New RectangleF(600 - a, l + 5, 70, 25), sf_R)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(680, l + 5, 90, 25), sf_R)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 522 - a, l, 522 - a, l + 22)
            e.Graphics.DrawLine(pen, 592 - a, l, 592 - a, l + 22)
            e.Graphics.DrawLine(pen, 680 - a, l, 680 - a, l + 22)


            l += 25

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If
                'e.Graphics.DrawLine(pen, 55, l - 10, 55, l + 22)
                'e.Graphics.DrawLine(pen, 775, l - 10, 775, l + 22)
                'If remise > 0 Then e.Graphics.DrawLine(pen, 632, l - 10, 632, l + 22)
                'e.Graphics.DrawLine(pen, 522 - a, l - 10, 522 - a, l + 22)
                'e.Graphics.DrawLine(pen, 592 - a, l - 10, 592 - a, l + 22)
                'e.Graphics.DrawLine(pen, 680 - a, l - 10, 680 - a, l + 22)


                Dim Ref As String = data.Rows(m).Item("ref")
                Dim prdName As String = data.Rows(m).Item("name")
                Dim qte As String = data.Rows(m).Item("qte").ToString
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price")))
                Dim total As String = String.Format("{0:n}", CDec((data.Rows(m).Item("price")) * data.Rows(m).Item("qte")))

                ''''''
                size = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 460 - a)

                e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 460 - a, size.Height), sf_L)
                If CDbl(qte) > 0 Then e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(523 - a, l, 70, 25), sf_R)
                If with_Price Or CDbl(price) > 0 Then e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(602 - a, l, 76, 25), sf_R)
                If with_Price Or CDbl(total) > 0 Then e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(682, l, 90, 25), sf_R)

                If a > 0 And data.Rows(m).Item("remise") > 0 Then
                    If with_Price Then e.Graphics.DrawString(data.Rows(m).Item("remise") & " %", fnt, Brushes.Black, New RectangleF(622, l + 5, 55, 25), sf_R)
                End If

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720


            e.Graphics.DrawLine(pen, 55, AAA, 55, l)
            e.Graphics.DrawLine(pen, 775, AAA, 775, l)
            If remise > 0 Then e.Graphics.DrawLine(pen, 682, AAA, 682, l)
            e.Graphics.DrawLine(pen, 522 - a, AAA, 522 - a, l)
            e.Graphics.DrawLine(pen, 592 - a, AAA, 592 - a, l)
            e.Graphics.DrawLine(pen, 680 - a, AAA, 680 - a, l)

            e.Graphics.DrawLine(pen, 55, l, 775, l)
            e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("TVA (14%)", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
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
    'Public Sub DrawFacture(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
    '                       ByVal ds As DataList,
    '                       ByVal title As String, ByVal entete As Boolean,
    '                       ByVal Pr_Id As String, ByVal with_Date As Boolean,
    '                       ByVal with_Price As Boolean, ByRef m As Integer)
    '    Try
    '        Dim fctid As Integer = ds.Id
    '        If Pr_Id > 0 Then fctid = Pr_Id

    '        Dim clientName As String = ds.Entete.ClientName
    '        Dim data As DataTable = ds.DataSource

    '        Dim h = e.MarginBounds.Height
    '        Dim w = e.MarginBounds.Width

    '        Dim remise = ds.TB.Remise
    '        Dim ht As String = String.Format("{0:n}", ds.Total_Ht)
    '        Dim Ttva As String = String.Format("{0:n}", ds.TB.TVA)
    '        Dim ttc As String = String.Format("{0:n}", ds.TB.TotalTTC)

    '        Dim isCache As Boolean = (ds.TB.ModePayement = "Cache")

    '        Try
    '            If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
    '        Catch ex As Exception
    '        End Try

    '        Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
    '                                                New Point(612, 205), New Point(600, 220),
    '                                                New Point(60, 220)}
    '        e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
    '        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

    '        myPoints = {New Point(606, 190), New Point(770, 190),
    '                   New Point(770, 220), New Point(606, 220),
    '                   New Point(618, 205)}
    '        e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
    '        e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)


    '        'print date 
    '        If with_Date Then e.Graphics.DrawString(ds.Entete.FactureDate.ToString("dd MMMM, yyyy"),
    '            fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
    '        'print  num Facture 

    '        e.Graphics.DrawString(title & "  N° : " & Form1.prefix & fctid, fntTitle, Brushes.Black, 65, 195)

    '        'print Client 
    '        e.Graphics.DrawString("M : " & clientName & "  [" & ds.Entete.Client.cid & "]",
    '                              fnt, Brushes.Black, 65, 230)

    '        Dim str As String = ds.Entete.ClientAdresse
    '        str &= vbNewLine
    '        str &= "ICE : " & ds.Entete.Client.ICE
    '        e.Graphics.DrawString(str, fnt, Brushes.Black, 65, 260)

    '        If ds.Entete.CompteId > 0 Then
    '            e.Graphics.DrawString("En compte de : ", fnt, Brushes.Black, 380, 230)
    '            e.Graphics.DrawString(ds.Entete.lbEnCompte.Text, fnt, Brushes.Black, 380, 26)
    '        End If

    '        If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)

    '        l = 333

    '        Dim a As Integer = 0
    '        If remise > 0 Then
    '            a = 50
    '            e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(630, l + 5, 40, 25), sf_R)
    '            e.Graphics.DrawLine(pen, 630, l + 20, 670, l + 20)
    '        End If

    '        e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 460 - a, 25), sf_L)
    '        e.Graphics.DrawString("Qte", fnt, Brushes.Black, New RectangleF(525 - a, l + 5, 65, 25), sf_R)
    '        e.Graphics.DrawString("P.U", fnt, Brushes.Black, New RectangleF(600 - a, l + 5, 70, 25), sf_R)
    '        e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(680, l + 5, 90, 25), sf_R)

    '        pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

    '        e.Graphics.DrawLine(pen, 60, l + 20, 515 - a, l + 20)
    '        e.Graphics.DrawLine(pen, 525 - a, l + 20, 590, l + 20)
    '        e.Graphics.DrawLine(pen, 600 - a, l + 20, 670, l + 20)
    '        e.Graphics.DrawLine(pen, 680, l + 20, 770, l + 20)

    '        l += 25

    '        While m < data.Rows.Count

    '            If l + 180 > h Then
    '                e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
    '                l = 250
    '                e.HasMorePages = True
    '                Return
    '            End If

    '            Dim Ref As String = data.Rows(m).Item("ref")
    '            Dim prdName As String = data.Rows(m).Item("name")
    '            Dim qte As String = data.Rows(m).Item("qte").ToString
    '            Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("price") / 1.2))
    '            Dim total As String = String.Format("{0:n}", CDec((data.Rows(m).Item("price") / 1.2) * data.Rows(m).Item("qte")))

    '            ''''''
    '            Dim size As SizeF = e.Graphics.MeasureString("[" & Ref & "]  " & prdName, fnt, 460 - a)

    '            e.Graphics.DrawString("[" & Ref & "]  " & prdName, fnt, Brushes.Black, New RectangleF(60, l, 460 - a, size.Height), sf_L)
    '            If CDbl(qte) > 0 Then e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(527 - a, l, 71, 25), sf_R)
    '            If with_Price Or CDbl(price) > 0 Then e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(602 - a, l, 76, 25), sf_R)
    '            If with_Price Or CDbl(total) > 0 Then e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(682, l, 90, 25), sf_R)

    '            If a > 0 Then
    '                If with_Price Then e.Graphics.DrawString(data.Rows(m).Item("remise") & " %", fnt, Brushes.Black, New RectangleF(632, l + 5, 37, 25), sf_R)
    '            End If

    '            l = l + size.Height + 5
    '            m += 1
    '        End While

    '        If l < 720 Then l = 720

    '        e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
    '        e.Graphics.DrawString("Total HT", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
    '        If with_Price Then e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

    '        e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
    '        e.Graphics.DrawString("TVA", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
    '        If with_Price Then e.Graphics.DrawString(Ttva, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)

    '        If remise > 0 Then
    '            e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
    '            e.Graphics.DrawString("Remise", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
    '            If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(remise)), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
    '            l += 20
    '        End If

    '        If isCache Then
    '            e.Graphics.DrawLine(pn, 550, l + 65, 770, l + 65)
    '            e.Graphics.DrawString("Droit de timbre", fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_L)
    '            If with_Price Then e.Graphics.DrawString(String.Format("{0:F}", (ds.Total_Ht - remise) * 0.0025), fnt, Brushes.Black, New RectangleF(550, l + 69, 220, 22), sf_R)
    '            ttc = String.Format("{0:n}", CDec(ds.TB.TotalTTC + ((ds.TB.TotalTTC - remise) * 0.0025)))
    '            l += 20
    '        End If

    '        e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
    '        e.Graphics.DrawString("Total TTC (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf_L)
    '        If with_Price Then e.Graphics.DrawString(ttc, fntTitle, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sf_R)
    '        e.Graphics.DrawLine(pn, 550, l + 90, 770, l + 90)

    '        If isCache Then l -= 20
    '        If remise > 0 Then l -= 20

    '        Dim strTotal As String = "Arrêté la présente facture à la somme : " & NumericStrings.GetNumberWords(CDec(ttc)) & " (Dhs)"
    '        Dim sze As SizeF = e.Graphics.MeasureString(strTotal, fnt, 440)
    '        If with_Price Then e.Graphics.DrawString(strTotal, fnt, Brushes.Black, New RectangleF(60, l + 25, 440, sze.Height), sf_L)

    '        e.Graphics.DrawLine(pn, 60, l + sze.Height + 35, 160, l + sze.Height + 35)
    '        If with_Price Then e.Graphics.DrawString("* Mode de paiement : " & ds.TB.ModePayement, fntsmall, Brushes.Black, New RectangleF(60, l + sze.Height + 45, 266, 22), sf_L)

    '        Try
    '            If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h - 20, 750, 120)
    '        Catch ex As Exception
    '        End Try

    '    Catch ex As Exception
    '        l = 250
    '        m = 0
    '    End Try

    '    l = 250
    '    m = 0
    'End Sub
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

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                New Point(612, 205), New Point(600, 220),
                                                New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
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
            l = 333
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

            l += 28

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
    Public Sub DrawMission(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal ds As ParcList,
                           ByVal title As String, ByVal entete As Boolean,
                           ByVal Pr_Id As String, ByVal with_Date As Boolean,
                           ByVal with_Price As Boolean, ByRef m As Integer)
        Try

            Dim fctid As Integer = ds.id_M

            Dim clientName As String = ds.ClientName
            Dim data As DataTable = ds.DetailsSource

            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                  New Point(612, 205), New Point(600, 220),
                                                  New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(ds.date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString("Mission : N° : " & fctid, fntTitle, Brushes.Black, 65, 195)

            'print Client 
            e.Graphics.DrawString("Client  : ", fnt, Brushes.Black, 50, 230)
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 50, 250)
            Dim str As String = ds.lbInfo.Text
            e.Graphics.DrawString(str, fnt, Brushes.Black, New RectangleF(50, 270, 220, 100), sf_L)


            'print Vehicule 
            e.Graphics.DrawString("Vehicule  : ", fnt, Brushes.Black, 300, 230)
            e.Graphics.DrawString(ds.vehiculeName, fnt, Brushes.Black, 300, 250)
            str = ds.vehiculeRef
            e.Graphics.DrawString(str, fnt, Brushes.Black, New RectangleF(300, 270, 220, 100), sf_L)


            'print Client 
            e.Graphics.DrawString("Chauffeur  : ", fnt, Brushes.Black, 550, 230)
            e.Graphics.DrawString("M : " & ds.DriverName, fnt, Brushes.Black, 550, 250)
            str = ds.DriverInfo
            e.Graphics.DrawString(str, fnt, Brushes.Black, New RectangleF(550, 270, 220, 100), sf_L)


            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 280)

            l = 380
            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(60, l + 5, 445, 25), sf_L)
            e.Graphics.DrawString("Qté", fnt, Brushes.Black, New RectangleF(510, l + 5, 80, 25), sf_R)
            e.Graphics.DrawString("Prix", fnt, Brushes.Black, New RectangleF(595, l + 5, 90, 25), sf_R)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(690, l + 5, 90, 25), sf_R)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 505, l + 20)
            e.Graphics.DrawLine(pen, 510, l + 20, 590, l + 20)
            e.Graphics.DrawLine(pen, 595, l + 20, 685, l + 20)
            e.Graphics.DrawLine(pen, 690, l + 20, 780, l + 20)

            l += 25

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                If m = 0 Then
                    e.Graphics.DrawString("Depart : " & ds.depart & " - Dest. : " & ds.arrive,
                                          fnt, Brushes.Black, New RectangleF(60, l, 610, 22), sf_L)

                    l = l + 40
                End If
                Dim prdName As String = data.Rows(m).Item("name") & " [" & ds.depart & " => " & ds.arrive & "]"
                Dim qte As String = data.Rows(m).Item("qte")
                Dim price As String = String.Format("{0:n}", CDec(data.Rows(m).Item("value")))
                Dim total As String = String.Format("{0:n}", CDec(data.Rows(m).Item("value") * data.Rows(m).Item("qte")))
                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 610)

                e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(60, l, 445, size.Height), sf_L)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(510, l, 80, 25), sf_R)
                e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(595, l, 90, 25), sf_R)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(690, l, 90, 25), sf_R)

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Nombre  ", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            e.Graphics.DrawString(data.Rows.Count, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            Dim tt As String = String.Format("{0:n}", CDec(ds.Total))
            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("Total ", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            e.Graphics.DrawString(tt, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)


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
    Public Sub DrawBonTransport(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal ds As ParcList,
                           ByVal title As String, ByVal entete As Boolean,
                           ByVal Pr_Id As String, ByVal with_Date As Boolean,
                           ByVal with_Price As Boolean, ByRef m As Integer)
        Try

            Dim fctid As Integer = ds.id_M

            Dim clientName As String = ds.ClientName
            Dim data As DataTable = ds.DetailsSource

            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If Form1.hasEntete_BonTransport Then
                    e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 130)
                    e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h - 20, 750, 120)
                End If

            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                   New Point(612, 205), New Point(600, 220),
                                                   New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(ds.date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 174, 24), sf_L)
            'print  num Facture 

            e.Graphics.DrawString("Bon de Transport: N° : " & Form1.Exercice & "/000" & ds.id_T, fntTitle, Brushes.Black, 65, 195)

            'print Client 
            e.Graphics.DrawString("Client  : ", fnt, Brushes.Black, 50, 230)
            e.Graphics.DrawString("M : " & clientName, fnt, Brushes.Black, 50, 250)
            Dim str As String = ds.lbInfo.Text
            e.Graphics.DrawString(str, fnt, Brushes.Black, New RectangleF(50, 270, 220, 100), sf_L)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)

            l = 370

            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 80, 25), sf_L)
            e.Graphics.DrawString("Designation", fnt, Brushes.Black, New RectangleF(143, l + 5, 365, 25), sf_L)
            e.Graphics.DrawString("Qté", fnt, Brushes.Black, New RectangleF(510, l + 5, 80, 25), sf_R)
            e.Graphics.DrawString("Prix", fnt, Brushes.Black, New RectangleF(595, l + 5, 90, 25), sf_R)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(690, l + 5, 90, 25), sf_R)

            pn.DashCap = System.Drawing.Drawing2D.DashCap.Round

            e.Graphics.DrawLine(pen, 60, l + 20, 140, l + 20)
            e.Graphics.DrawLine(pen, 143, l + 20, 505, l + 20)
            e.Graphics.DrawLine(pen, 510, l + 20, 590, l + 20)
            e.Graphics.DrawLine(pen, 595, l + 20, 685, l + 20)
            e.Graphics.DrawLine(pen, 690, l + 20, 780, l + 20)

            l += 25
            Dim COUNT As Integer = ds.plTransBody.Controls.Count
            For Each C As AddElement In ds.plTransBody.Controls

                If l + 160 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim prdName As String = C.Key
                Dim qte As String = C.qte
                Dim dte As String = C.DateElemenet
                Dim price As String = String.Format("{0:n}", C.price)
                Dim total As String = String.Format("{0:n}", C.Total)
                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 610)

                e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(60, l, 80, size.Height), sf_L)
                e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(143, l, 365, size.Height), sf_L)
                e.Graphics.DrawString(qte, fnt, Brushes.Black, New RectangleF(510, l, 80, 25), sf_R)
                e.Graphics.DrawString(price, fnt, Brushes.Black, New RectangleF(595, l, 90, 25), sf_R)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(690, l, 90, 25), sf_R)

                l = l + size.Height + 5
                m += 1
            Next
                If l < 720 Then l = 720

                e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
                e.Graphics.DrawString("Nombre  ", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            e.Graphics.DrawString(Count, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            Dim tt As String = String.Format("{0:n}", CDec(ds.Total_Transport))
                e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
                e.Graphics.DrawString("Total ", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
                e.Graphics.DrawString(tt, fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)

                

        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub

    'lists
    Public Sub DrawListOfFacture(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try

            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width


            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                New Point(612, 205), New Point(600, 220),
                                                New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(Pr_Id, fntTitle, Brushes.Black, 65, 195)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 230)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)
            l = 340

            Dim a As Integer = 0

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(50, l + 5, 110, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(162, l + 5, 260 - a, 25), sf_L)
            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(425, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(528, l + 5, 90, 25), sf_L)
            e.Graphics.DrawString("Avance", fnt, Brushes.Black, New RectangleF(622, l + 5, 90, 25), sf_L)
            e.Graphics.DrawString(" - ", fnt, Brushes.Black, New RectangleF(716, l + 5, 80, 25), sf_L)

            e.Graphics.DrawLine(pen, 50, l + 20, 158, l + 20)
            e.Graphics.DrawLine(pen, 162, l + 20, 421, l + 20)
            e.Graphics.DrawLine(pen, 425, l + 20, 524, l + 20)
            e.Graphics.DrawLine(pen, 528, l + 20, 618, l + 20)
            e.Graphics.DrawLine(pen, 622, l + 20, 712, l + 20)
            e.Graphics.DrawLine(pen, 716, l + 20, 785, l + 20)

            l += 30

            While m < data.Rows.Count

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

                e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(50, l, 110, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(162, l, 260, size.Height), sf_L)
                e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(425, l, 100, 25), sf_L)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(528, l, 90, 25), sf_L)
                e.Graphics.DrawString(avance, fnt, Brushes.Black, New RectangleF(622, l, 90, 25), sf_L)
                e.Graphics.DrawString(etat, fnt, Brushes.Black, New RectangleF(716, l, 80, 25), sf_L)

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            ''''''
            Dim sum As Double = Convert.ToDouble(data.Compute("SUM(total)", String.Empty))
            Dim avc As Double = Convert.ToDouble(data.Compute("SUM(avance)", String.Empty))

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Nombre", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            e.Graphics.DrawString(data.Rows.Count, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("Total (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            e.Graphics.DrawString(String.Format("{0:n}", CDec(sum)), fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)
            e.Graphics.DrawLine(pen, 550, l + 65, 770, l + 65)
            e.Graphics.DrawString("Avance (Dhs) ", fnt, Brushes.Black, New RectangleF(550, l + 70, 266, 22), sf_L)
            e.Graphics.DrawString(String.Format("{0:n}", avc), fnt, Brushes.Black, New RectangleF(550, l + 67, 220, 22), sf_R)
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
    Public Sub DrawListOfCharges(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try
            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                  New Point(612, 205), New Point(600, 220),
                                                  New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(Form1.Facture_Title, fntTitle, Brushes.Black, 65, 195)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 230)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)

            Dim a As Integer = 0

            l = 333

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(40, l + 5, 50, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(94, l + 5, 300, 25), sf_L)
            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(398, l + 5, 80, 25), sf_L)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(482, l + 5, 80, 25), sf_R)
            e.Graphics.DrawString("Veh ", fnt, Brushes.Black, New RectangleF(566, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Chf  ", fnt, Brushes.Black, New RectangleF(668, l + 5, 100, 25), sf_L)

            e.Graphics.DrawLine(pen, 40, l + 20, 90, l + 20)
            e.Graphics.DrawLine(pen, 94, l + 20, 394, l + 20)
            e.Graphics.DrawLine(pen, 398, l + 20, 478, l + 20)
            e.Graphics.DrawLine(pen, 482, l + 20, 562, l + 20)
            e.Graphics.DrawLine(pen, 566, l + 20, 664, l + 20)
            e.Graphics.DrawLine(pen, 668, l + 20, 768, l + 20)

            l += 28

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim ID As String = StrValue(data, "id", m)
                Dim libelle As String = data.Rows(m).Item("name")
                Dim dte As String = DteValue(data, "date", m).ToString("dd/MM/yyyy")
                Dim total As String = String.Format("{0:n}", DblValue(data, "value", m))
                Dim Vid As String = StrValue(data, "vid", m)
                Dim Drid As String = StrValue(data, "drid", m)

                ''''''

                Try

                    Dim results = From myRow As DataRow In dt_Vehicule.Rows
                                 Where myRow(0) = Vid Select myRow

                    Vid = results(0).Item("ref")

                    results = From myRow As DataRow In dt_Driver.Rows
                               Where myRow(0) = Drid Select myRow

                    Drid = results(0).Item("name")
                Catch ex As Exception

                End Try


                Dim size As SizeF = e.Graphics.MeasureString(libelle, fnt, 400)

                If IntValue(data, "id", m) > 0 Then e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(40, l, 50, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(94, l, 300, size.Height), sf_L)
                e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(398, l, 80, 25), sf_L)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(482, l, 80, 25), sf_R)
                e.Graphics.DrawString(Vid, fnt, Brushes.Black, New RectangleF(566, l, 100, 25), sf_L)
                e.Graphics.DrawString(Drid, fnt, Brushes.Black, New RectangleF(668, l, 100, 25), sf_L)

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            ''''''

            Dim ht As String = data.Rows.Count
            Dim sum As Double = 0
            Try
                sum = Convert.ToDouble(data.Compute("SUM(value)", String.Empty))
            Catch ex As Exception
                sum = 0
                sum = data.AsEnumerable.Sum(Function(item) item("value"))
            End Try




            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Nombre", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(sum)), fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)


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
    Public Sub DrawListOfMission(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try

            Dim h = e.MarginBounds.Height + 30
            Dim w = e.MarginBounds.Width


            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                 New Point(612, 205), New Point(600, 220),
                                                 New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(Form1.Facture_Title, fntTitle, Brushes.Black, 65, 195)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 230)

            l = 260
            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 250)

            Dim a As Integer = 0

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(50, l + 5, 60, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(115, l + 5, 320, 25), sf_L)
            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(435, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Dep.", fnt, Brushes.Black, New RectangleF(540, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Arr.", fnt, Brushes.Black, New RectangleF(645, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Chauf", fnt, Brushes.Black, New RectangleF(750, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Veh", fnt, Brushes.Black, New RectangleF(855, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(960, l + 5, 100, 25), sf_R)


            e.Graphics.DrawLine(pen, 50, l + 20, 110, l + 20)
            e.Graphics.DrawLine(pen, 115, l + 20, 430, l + 20)
            e.Graphics.DrawLine(pen, 435, l + 20, 535, l + 20)
            e.Graphics.DrawLine(pen, 540, l + 20, 640, l + 20)
            e.Graphics.DrawLine(pen, 645, l + 20, 745, l + 20)
            e.Graphics.DrawLine(pen, 750, l + 20, 850, l + 20)
            e.Graphics.DrawLine(pen, 855, l + 20, 955, l + 20)
            e.Graphics.DrawLine(pen, 960, l + 20, 1060, l + 20)
            l += 28

            While m < data.Rows.Count

                If l > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim ID As String = StrValue(data, "Mid", m)
                Dim libelle As String = data.Rows(m).Item("clientName") & " [" & StrValue(data, "cid", m) & "]"
                Dim dte As String = DteValue(data, "date", m).ToString("dd MMM, yyyy")
                Dim dep As String = StrValue(data, "depart", m)
                Dim arr As String = StrValue(data, "arrive", m)

                Dim Vid As String = StrValue(data, "vid", m)
                Dim drid As String = StrValue(data, "drid", m)
                Dim total As String = String.Format("{0:n}", DblValue(data, "total", m))
                Try

                    Dim results = From myRow As DataRow In dt_Vehicule.Rows
                                 Where myRow(0) = Vid Select myRow

                    Vid = results(0).Item("ref")

                    results = From myRow As DataRow In dt_Driver.Rows
                               Where myRow(0) = drid Select myRow

                    drid = results(0).Item("name")


                    If Vid = "0" Then Vid = " "
                    If drid = "0" Then drid = " "

                Catch ex As Exception

                End Try

                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(libelle, fnt, 260)

                If IntValue(data, "Mid", m) > 0 Then e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(50, l + 5, 60, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(115, l, 300, 25), sf_L)
                e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(435, l, 100, 25), sf_L)
                e.Graphics.DrawString(dep, fnt, Brushes.Black, New RectangleF(540, l, 100, 25), sf_L)
                e.Graphics.DrawString(arr, fnt, Brushes.Black, New RectangleF(645, l, 100, 25), sf_L)
                e.Graphics.DrawString(drid, fnt, Brushes.Black, New RectangleF(750, l, 100, 25), sf_L)
                e.Graphics.DrawString(Vid, fnt, Brushes.Black, New RectangleF(855, l, 100, 25), sf_L)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(960, l, 100, 25), sf_R)

                l = l + size.Height + 5
                m += 1
            End While



            If l < h Then l = h

            ''''''

            Dim ht As String = data.Rows.Count
            Dim sum As Double = Convert.ToDouble(data.Compute("SUM(total)", String.Empty))



            e.Graphics.DrawLine(pen, 60, l + 25, 1060, l + 25)
            e.Graphics.DrawString("Nombre", fnt, Brushes.Black, New RectangleF(850, l + 29, 220, 22), sf_L)
            e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(850, l + 29, 210, 22), sf_R)

            e.Graphics.DrawLine(pn, 850, l + 45, 1060, l + 45)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(850, l + 49, 210, 22), sf_L)
            If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(sum)), fnt, Brushes.Black, New RectangleF(850, l + 49, 210, 22), sf_R)


            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h + 40, 750, 120)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            l = 250
            m = 0
        End Try

        l = 250
        m = 0
    End Sub
    Public Sub DrawListOfTransport(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try
            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                  New Point(612, 205), New Point(600, 220),
                                                  New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(Form1.Facture_Title, fntTitle, Brushes.Black, 65, 195)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 230)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)

            Dim a As Integer = 0

            l = 333

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(40, l + 5, 50, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(94, l + 5, 300, 25), sf_L)
            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(398, l + 5, 80, 25), sf_L)
            'e.Graphics.DrawString("", fnt, Brushes.Black, New RectangleF(482, l + 5, 80, 25), sf_R)
            e.Graphics.DrawString("Total ", fnt, Brushes.Black, New RectangleF(566, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Solde  ", fnt, Brushes.Black, New RectangleF(668, l + 5, 100, 25), sf_L)

            e.Graphics.DrawLine(pen, 40, l + 20, 90, l + 20)
            e.Graphics.DrawLine(pen, 94, l + 20, 394, l + 20)
            e.Graphics.DrawLine(pen, 398, l + 20, 478, l + 20)
            e.Graphics.DrawLine(pen, 482, l + 20, 562, l + 20)
            e.Graphics.DrawLine(pen, 566, l + 20, 664, l + 20)
            e.Graphics.DrawLine(pen, 668, l + 20, 768, l + 20)

            l += 28

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim ID As String = StrValue(data, "id", m)
                Dim libelle As String = data.Rows(m).Item("name")
                Dim dte As String = DteValue(data, "date", m).ToString("dd/MM/yyyy")
                Dim total As String = String.Format("{0:n}", DblValue(data, "total", m))
                Dim Avc As String = String.Format("{0:n}", DblValue(data, "avance", m))
                Dim Vid As String = StrValue(data, "depart", m)


                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(libelle, fnt, 400)

                If IntValue(data, "id", m) > 0 Then e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(40, l, 50, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(94, l, 300, size.Height), sf_L)
                e.Graphics.DrawString(dte, fnt, Brushes.Black, New RectangleF(398, l, 80, 25), sf_L)
                e.Graphics.DrawString(Vid, fnt, Brushes.Black, New RectangleF(482, l, 80, 25), sf_R)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(566, l, 100, 25), sf_L)
                e.Graphics.DrawString(Avc, fnt, Brushes.Black, New RectangleF(668, l, 100, 25), sf_L)

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            ''''''

            'Dim ht As String = data.Rows.Count
            'Dim sum As Double = 0
            'Dim av As Double = 0
            'Try
            '    sum = Convert.ToDouble(data.Compute("SUM(total)", String.Empty))
            'Catch ex As Exception
            '    sum = 0
            '    sum = data.AsEnumerable.Sum(Function(item) item("total"))
            'End Try

            'e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            'e.Graphics.DrawString("Nombre", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            'e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            'e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            'e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            'If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(sum)), fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)


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
    Public Sub DrawListOfVehicules(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try
            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                  New Point(612, 205), New Point(600, 220),
                                                  New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(Form1.Facture_Title, fntTitle, Brushes.Black, 65, 195)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 230)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)

            Dim a As Integer = 0

            l = 333

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(40, l + 5, 50, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(94, l + 5, 300, 25), sf_L)
            e.Graphics.DrawString("Matr", fnt, Brushes.Black, New RectangleF(398, l + 5, 80, 25), sf_L)
            e.Graphics.DrawString("Carb", fnt, Brushes.Black, New RectangleF(482, l + 5, 80, 25), sf_R)
            e.Graphics.DrawString("Kms ", fnt, Brushes.Black, New RectangleF(566, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Année  ", fnt, Brushes.Black, New RectangleF(668, l + 5, 100, 25), sf_L)

            e.Graphics.DrawLine(pen, 40, l + 20, 90, l + 20)
            e.Graphics.DrawLine(pen, 94, l + 20, 394, l + 20)
            e.Graphics.DrawLine(pen, 398, l + 20, 478, l + 20)
            e.Graphics.DrawLine(pen, 482, l + 20, 562, l + 20)
            e.Graphics.DrawLine(pen, 566, l + 20, 664, l + 20)
            e.Graphics.DrawLine(pen, 668, l + 20, 768, l + 20)

            l += 28

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim ID As String = StrValue(data, "Vid", m)
                Dim libelle As String = data.Rows(m).Item("name")
                Dim ref As String = StrValue(data, "ref", m)
                Dim carb As String = StrValue(data, "carb", m)
                Dim km As String = StrValue(data, "km", m)
                Dim yr As String = StrValue(data, "year", m)



                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(libelle, fnt, 400)

                If IntValue(data, "id", m) > 0 Then e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(40, l, 50, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(94, l, 300, size.Height), sf_L)
                e.Graphics.DrawString(ref, fnt, Brushes.Black, New RectangleF(398, l, 80, 25), sf_L)
                e.Graphics.DrawString(carb, fnt, Brushes.Black, New RectangleF(482, l, 80, 25), sf_R)
                e.Graphics.DrawString(km, fnt, Brushes.Black, New RectangleF(566, l, 100, 25), sf_L)
                e.Graphics.DrawString(yr, fnt, Brushes.Black, New RectangleF(668, l, 100, 25), sf_L)

                l = l + size.Height + 5
                m += 1
            End While

            If l < 720 Then l = 720

            ''''''

            'Dim ht As String = data.Rows.Count
            'Dim sum As Double = 0
            'Dim av As Double = 0
            'Try
            '    sum = Convert.ToDouble(data.Compute("SUM(total)", String.Empty))
            'Catch ex As Exception
            '    sum = 0
            '    sum = data.AsEnumerable.Sum(Function(item) item("total"))
            'End Try

            'e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            'e.Graphics.DrawString("Nombre", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)
            'e.Graphics.DrawString(ht, fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_R)

            'e.Graphics.DrawLine(pn, 550, l + 45, 770, l + 45)
            'e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_L)
            'If with_Price Then e.Graphics.DrawString(String.Format("{0:n}", CDec(sum)), fnt, Brushes.Black, New RectangleF(550, l + 49, 220, 22), sf_R)


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
    Public Sub DrawListOfDrivers(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                                   ByVal data As DataTable, ByVal entete As Boolean, ByVal Pr_Id As String,
                                   ByVal with_Date As Boolean, ByVal with_Price As Boolean, ByRef m As Integer)
        Try
            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                  New Point(612, 205), New Point(600, 220),
                                                  New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            If with_Date Then e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"),
                fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString(Form1.Facture_Title, fntTitle, Brushes.Black, 65, 195)

            'print user 
            e.Graphics.DrawString("Imprimer par : " & Form1.adminName, fnt, Brushes.Black, 65, 230)

            If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 270)

            Dim a As Integer = 0

            l = 333

            e.Graphics.DrawString("Id/N°", fnt, Brushes.Black, New RectangleF(40, l + 5, 50, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(94, l + 5, 300, 25), sf_L)
            e.Graphics.DrawString("CIN", fnt, Brushes.Black, New RectangleF(398, l + 5, 80, 25), sf_L)
            e.Graphics.DrawString("Tél", fnt, Brushes.Black, New RectangleF(482, l + 5, 80, 25), sf_R)
            e.Graphics.DrawString("Adresse ", fnt, Brushes.Black, New RectangleF(566, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Date Emb", fnt, Brushes.Black, New RectangleF(668, l + 5, 100, 25), sf_L)

            e.Graphics.DrawLine(pen, 40, l + 20, 90, l + 20)
            e.Graphics.DrawLine(pen, 94, l + 20, 394, l + 20)
            e.Graphics.DrawLine(pen, 398, l + 20, 478, l + 20)
            e.Graphics.DrawLine(pen, 482, l + 20, 562, l + 20)
            e.Graphics.DrawLine(pen, 566, l + 20, 664, l + 20)
            e.Graphics.DrawLine(pen, 668, l + 20, 768, l + 20)

            l += 28

            While m < data.Rows.Count

                If l + 180 > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim ID As String = StrValue(data, "Drid", m)
                Dim libelle As String = data.Rows(m).Item("name")
                Dim ref As String = StrValue(data, "cin", m)
                Dim carb As String = StrValue(data, "tel", m)
                Dim km As String = StrValue(data, "adresse", m)
                Dim yr As String = StrValue(data, "date", m)

                Dim size As SizeF = e.Graphics.MeasureString(libelle, fnt, 400)

                If IntValue(data, "id", m) > 0 Then e.Graphics.DrawString(ID, fnt, Brushes.Black, New RectangleF(40, l, 50, 25), sf_L)
                e.Graphics.DrawString(libelle, fnt, Brushes.Black, New RectangleF(94, l, 300, size.Height), sf_L)
                e.Graphics.DrawString(ref, fnt, Brushes.Black, New RectangleF(398, l, 80, 25), sf_L)
                e.Graphics.DrawString(carb, fnt, Brushes.Black, New RectangleF(482, l, 80, 25), sf_R)
                e.Graphics.DrawString(km, fnt, Brushes.Black, New RectangleF(566, l, 100, 25), sf_L)
                e.Graphics.DrawString(yr, fnt, Brushes.Black, New RectangleF(668, l, 100, 25), sf_L)

                l = l + size.Height + 5
                m += 1
            End While

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


    'Details Vehicule / rapport
    Public Sub DrawDetailsVehicule(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal _id As String, ByVal _name As String, ByVal _str1 As String, ByVal _str2 As String,
                           ByVal _str_Date As String, ByVal _data As DataTable, ByVal _Charges As DataTable,
                           ByVal entete As Boolean, ByVal _TotalMission As String, ByVal _TotalCharge As String,
                           ByRef m As Integer, ByRef n As Integer)
        Try
            Dim h = e.MarginBounds.Height
            Dim w = e.MarginBounds.Width

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgEntetePath), 10, 10, 750, 120)
            Catch ex As Exception
            End Try

            Dim myPoints() As Point = New Point() {New Point(60, 190), New Point(600, 190),
                                                  New Point(612, 205), New Point(600, 220),
                                                  New Point(60, 220)}
            e.Graphics.FillPolygon(Brushes.WhiteSmoke, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            myPoints = {New Point(606, 190), New Point(770, 190),
                       New Point(770, 220), New Point(606, 220),
                       New Point(618, 205)}
            e.Graphics.FillPolygon(Brushes.Gainsboro, myPoints)
            e.Graphics.DrawPolygon(New Pen(Brushes.Gainsboro, 0.5F), myPoints)

            'print date 
            e.Graphics.DrawString(Now.Date.ToString("dd MMMM, yyyy"),
              fnt, Brushes.Black, New RectangleF(620, 197, 144, 24), sf_R)
            'print  num Facture 

            e.Graphics.DrawString("Rapport Vehicule : N° : " & _id, fntTitle, Brushes.Black, 65, 195)

            'print Client 
            e.Graphics.DrawString(_name, fnt, Brushes.Black, 50, 230)

            If m = 0 Then
                e.Graphics.DrawString(_str1, fnt, Brushes.Black, New RectangleF(50, 250, 320, 100), sf_L)
                e.Graphics.DrawString(_str2, fnt, Brushes.Black, New RectangleF(400, 250, 320, 100), sf_L)

                e.Graphics.DrawString(_str_Date, fnt, Brushes.Black, New RectangleF(60, 360, 680, 25), sf_C)

                e.Graphics.DrawLine(pen, 60, 375, 740, 375)
                e.Graphics.DrawString("Liste des Missions", fnt, Brushes.Black, New RectangleF(60, 380, 680, 25), sf_C)
                e.Graphics.DrawLine(pen, 60, 395, 740, 395)
                l = 410
            Else
                If m > 0 Then e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 60, 280)
                 e.Graphics.DrawString(_str_Date, fnt, Brushes.Black, New RectangleF(60, 360, 680, 25), sf_C)
                l = 305
            End If

            If n = 0 Then
                e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 100, 25), sf_L)
                e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(160, l + 5, 350, 25), sf_L)
                e.Graphics.DrawString("Km Depart", fnt, Brushes.Black, New RectangleF(510, l + 5, 105, 25), sf_R)
                e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(620, l + 5, 120, 25), sf_R)

                e.Graphics.DrawLine(pen, 60, l + 20, 155, l + 20)
                e.Graphics.DrawLine(pen, 160, l + 20, 505, l + 20)
                e.Graphics.DrawLine(pen, 510, l + 20, 615, l + 20)
                e.Graphics.DrawLine(pen, 620, l + 20, 740, l + 20)

            End If

            l += 25

            While m < _data.Rows.Count

                If l > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim prdName As String = StrValue(_data, "clientName", m) & " - " & StrValue(_data, "domain", m)
                Dim dt As String = DteValue(_data, "date", m).ToString("dd/MMM")
                Dim km As String = StrValue(_data, "km_D", m)
                Dim total As String = String.Format("{0:n}", DblValue(_data, "total", m))
                ''''''

                Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 350)

                e.Graphics.DrawString(dt, fnt, Brushes.Black, New RectangleF(60, l, 100, 25), sf_L)
                e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(160, l, 350, size.Height), sf_L)
                e.Graphics.DrawString(km, fnt, Brushes.Black, New RectangleF(510, l, 105, 25), sf_R)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(620, l, 120, 25), sf_R)

                l = l + size.Height + 5
                m += 1
            End While

            If n = 0 Then
                e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
                e.Graphics.DrawString("Nombre  : " & _data.Rows.Count, fnt, Brushes.Black, New RectangleF(60, l + 29, 220, 22), sf_L)

                Dim ttt As String = String.Format("{0:n}", CDec(_TotalMission))
                e.Graphics.DrawString("Total : " & ttt & " Dhs", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)

                l += 60
            End If

            e.Graphics.DrawLine(pen, 60, l, 740, l)
            e.Graphics.DrawString("Liste des Charges", fnt, Brushes.Black, New RectangleF(60, l + 5, 680, 25), sf_C)
            e.Graphics.DrawLine(pen, 60, l + 20, 740, l + 20)

            l += 25

            e.Graphics.DrawString("Date", fnt, Brushes.Black, New RectangleF(60, l + 5, 100, 25), sf_L)
            e.Graphics.DrawString("Libelle", fnt, Brushes.Black, New RectangleF(160, l + 5, 455, 25), sf_L)
            e.Graphics.DrawString("Total", fnt, Brushes.Black, New RectangleF(620, l + 5, 120, 25), sf_R)

            e.Graphics.DrawLine(pen, 60, l + 20, 155, l + 20)
            e.Graphics.DrawLine(pen, 160, l + 20, 615, l + 20)
            e.Graphics.DrawLine(pen, 620, l + 20, 740, l + 20)

            l += 25

            While n < _Charges.Rows.Count

                If l > h Then
                    e.Graphics.DrawString("[ ..... ]", fnt, Brushes.Black, 605, 870)
                    l = 250
                    e.HasMorePages = True
                    Return
                End If

                Dim prdName As String = StrValue(_Charges, "name", n)
                Dim dt As String = DteValue(_Charges, "date", n).ToString("dd/MMM")
                Dim total As String = String.Format("{0:n}", DblValue(_Charges, "value", n))
                ''''''
                Dim size As SizeF = e.Graphics.MeasureString(prdName, fnt, 450)

                e.Graphics.DrawString(dt, fnt, Brushes.Black, New RectangleF(60, l, 100, 25), sf_L)
                e.Graphics.DrawString(prdName, fnt, Brushes.Black, New RectangleF(160, l, 455, size.Height), sf_L)
                e.Graphics.DrawString(total, fnt, Brushes.Black, New RectangleF(620, l, 120, 25), sf_R)

                l = l + size.Height + 5
                n += 1
            End While

            e.Graphics.DrawLine(pen, 60, l + 25, 770, l + 25)
            e.Graphics.DrawString("Nombre  : " & _Charges.Rows.Count, fnt, Brushes.Black, New RectangleF(60, l + 29, 220, 22), sf_L)

            Dim tt As String = String.Format("{0:n}", CDec(_TotalCharge))
            e.Graphics.DrawString("Total : " & tt & " Dhs", fnt, Brushes.Black, New RectangleF(550, l + 29, 220, 22), sf_L)

            Try
                If entete Then e.Graphics.DrawImage(Image.FromFile(Form1.imgFootherPath), 10, h - 20, 750, 120)
            Catch ex As Exception
            End Try

        Catch ex As Exception
            l = 250
            m = 0
            n = 0
        End Try
        n = 0
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
