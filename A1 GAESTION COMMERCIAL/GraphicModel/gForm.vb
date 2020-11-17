Imports System.Xml.Serialization
Imports System.IO
Imports System.Drawing.Printing

Public Class gForm

    Public FooterFieldDic As New List(Of gTopField)
    Public TopFieldDic As New List(Of gTopField)

    Private _isLandscape As Boolean = False
    Private _W_Page As Integer = 720
    Private _h_Page As Integer = 1160

    Public localname As String = "Default.dat"
    Dim p_name As String = "A4"
    Dim p_Kind As PaperKind = PaperKind.A4

    Public Property isLandScape() As Boolean
        Get
            Return _isLandscape
        End Get
        Set(ByVal value As Boolean)
            _isLandscape = value
            btLand.Visible = Not value

            If isLandScape Then
                pb.Width = H_Page
                pb.Height = W_Page
            Else
                pb.Width = W_Page
                pb.Height = H_Page
            End If
        End Set
    End Property

    Dim allowDraw As Boolean = True
    Dim p1 As Point = New Point(0, 0)
    Dim p2 As Point = New Point(0, 0)

    Public Property W_Page As Integer
        Get
            Try
                Return CInt(txt_w.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txt_w.text = value
        End Set
    End Property
    Public Property H_Page As Integer
        Get
            Try
                Return CInt(txt_H.text)
            Catch ex As Exception
                Return 1
            End Try
        End Get
        Set(ByVal value As Integer)
            txt_H.text = value
        End Set
    End Property


    Public ReadOnly Property Details_imp_Source As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("arid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("qte", GetType(Double))
            table.Columns.Add("price", GetType(Double))
            table.Columns.Add("bprice", GetType(Double))
            table.Columns.Add("tva", GetType(Double))
            table.Columns.Add("ref", GetType(String))
            table.Columns.Add("depot", GetType(Integer))
            table.Columns.Add("remise", GetType(Integer))
            table.Columns.Add("bl", GetType(Integer))
            table.Columns.Add("totaltva", GetType(Double))

            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add(1, "Article1", 1, 3, String.Format("{0:0.00}", 11.5), 11,
                              20, "REF 123", 1, 0, 2, 3)
            table.Rows.Add(1, "Article2", 1, 12, String.Format("{0:0.00}", 34.4), 11,
                             20, "REF 123", 1, 0, 2, 5)
            table.Rows.Add(1, "Article3", 1, 1, String.Format("{0:0.00}", 66), 11,
                             20, "REF 123", 1, 0, 2, 2)
            table.Rows.Add(1, "Article4", 1, 54, String.Format("{0:0.00}", 5), 11,
                             14, "REF 123", 4, 0, 2, 6)
            Return table
        End Get
    End Property
    Public ReadOnly Property Data_imp_Source As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("id", GetType(String))
            table.Columns.Add("date", GetType(String))
            table.Columns.Add("cid", GetType(String))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("total_ht", GetType(String))
            table.Columns.Add("total_tva", GetType(String))
            table.Columns.Add("total_ttc", GetType(String))
            table.Columns.Add("total_remise", GetType(String))
            table.Columns.Add("total_avance", GetType(String))
            table.Columns.Add("total_droitTimbre", GetType(String))
            table.Columns.Add("MPayement", GetType(String))
            table.Columns.Add("Editeur", GetType(String))
            table.Columns.Add("vidal", GetType(String))
            table.Columns.Add("ref", GetType(String))


            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add(1, Now.Date, 1, "Mohamed", String.Format("{0:0.00}", 222),
                           String.Format("{0:0.00}", 66), String.Format("{0:0.00}", 288), "0",
                              "0", "0", "CHEQUE", "ADMIN", 12, "BL-001")
            Return table
        End Get
    End Property
    Public ReadOnly Property Client_imp_Source As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("Clid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("ref", GetType(String))
            table.Columns.Add("ville", GetType(String))
            table.Columns.Add("adresse", GetType(String))
            table.Columns.Add("ice", GetType(String))
            table.Columns.Add("tel", GetType(String))

            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add(1, "Mohamed", "md123", "Agadir", "Av 01, Lot 2, Imm 3, hay Dakhla", "1234567890", "06060606060")

            Return table
        End Get
    End Property

    Private Sub gForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If txt_H.text.Trim = "" Then H_Page = 1160
        If txt_w.text.Trim = "" Then W_Page = 680

        If isLandScape Then
            pb.Width = H_Page
            pb.Height = W_Page
        Else
            pb.Width = W_Page
            pb.Height = H_Page
        End If

    End Sub

    Public Function DrawBl(ByRef tc As gTabClass,
                              ByVal data As DataTable,
                              ByVal details As DataTable,
                              ByVal dt_Client As DataTable,
                              ByVal hightQ As Boolean, ByRef m As Integer)
        'Create a font   
        Dim F As New Font("Arial", 12, FontStyle.Bold)
        Dim ff As New Font("Arial", 11, FontStyle.Italic)

        Dim F_T As New Font(Form1.fontName_Normal, Form1.fontSize_Normal, FontStyle.Bold)
        Dim F_D As New Font(Form1.fontName_Normal, Form1.fontSize_Normal)

        Dim y As Integer = 20
        Dim h As Integer = 20
        Dim pen As New Pen(Brushes.Black, 1.0F)

        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Near
        Dim sfc As New StringFormat()
        sfc.Alignment = StringAlignment.Center
        Dim sfl As New StringFormat()
        sfl.Alignment = StringAlignment.Far


        Dim _Bmp As Bitmap

        Dim params_tva As New Dictionary(Of Double, Double)

        Dim _w = W_Page
        Dim _h = H_Page

        If isLandScape Then
            _w = H_Page
            _h = W_Page
        End If

        'Create a new bitmap
        Using Bmp As New Bitmap(_w, _h, Imaging.PixelFormat.Format24bppRgb)
            'Set the resolution to 300 DPI
            If hightQ Then Bmp.SetResolution(300, 300)
            'Create a graphics object from the bitmap
            Using G As Graphics = Graphics.FromImage(Bmp)
                'Paint the canvas white
                G.Clear(Color.White)
                'Set various modes to higher quality
                If hightQ Then
                    G.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                    G.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                    h = F.Height + 40
                End If



                Using B As New SolidBrush(Color.Black)
                    For Each a As gTopField In TopFieldDic
                        'Create a brush
                        Dim top_x = a.x
                        Dim top_y = a.y

                        Dim fn As Font
                        If a.isBold Then
                            fn = New Font("Arial", a.fSize, FontStyle.Bold)
                        Else
                            fn = New Font("Arial", a.fSize)
                        End If

                        If a.hasBloc Then
                            G.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                            Dim _br As New SolidBrush(a.backColor)
                            G.FillRectangle(_br, a.x, a.y, a.width, a.height)

                            top_x += 5
                            top_y += 3
                        End If

                        Dim str As String = CStr(a.designation)

                        If a.field.StartsWith("CLT") Then
                            Dim s = a.field.Split("_")(1)
                            str &= dt_Client.Rows(0).Item(s)
                        ElseIf a.field.StartsWith("*") Then

                        ElseIf a.field.StartsWith("image") Then
                            Try
                                str = ""
                                Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                                G.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                            Catch ex As Exception
                            End Try
                        ElseIf a.field.StartsWith("-") Then
                            str &= "Bon de Laivraison"
                        Else

                            str &= data.Rows(0).Item(a.field)
                        End If

                        G.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)
                    Next
                End Using
                '////////////////////////////////////////////////////////////////////////
                ' table
                Dim x As Integer = tc.x
                y = tc.y + 33

                If tc.Type = "Table_1" Then  '//////////////////////////////////////////////
                    G.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
                    G.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
                    Dim isFerst As Boolean = True
                    For Each c As gColClass In tc.details
                        G.DrawString(c.HeaderName, F_T, Brushes.Black,
                                        New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)


                        If isFerst = True Then
                            isFerst = False
                            x = x + c.ColWidth
                            Continue For
                        End If
                        G.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                        x = x + c.ColWidth
                    Next


                ElseIf tc.Type = "Table_2" Then '//////////////////////////////////////////////
                    G.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

                    For Each c As gColClass In tc.details
                        G.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth - 3, 15), sf)
                        G.DrawLine(pen, x, tc.y + 22, x + c.ColWidth - 3, tc.y + 22)
                        x = x + c.ColWidth
                    Next
           
                ElseIf tc.Type = "Liste_1" Then '//////////////////////////////////////////////

                    For Each c As gColClass In tc.details
                        G.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth - 3, 15), sf)
                        G.DrawLine(pen, x, tc.y + 22, x + c.ColWidth - 3, tc.y + 22)
                        x = x + c.ColWidth
                    Next
                ElseIf tc.Type = "Table_3" Then '//////////////////////////////////////////////

                    G.DrawEllipse(pen, tc.x, tc.y, 22, 22)
                    G.DrawEllipse(pen, tc.x + tc.TabWidth - 22, tc.y, 22, 22)
                    G.FillEllipse(Brushes.White, tc.x + 2, tc.y, 22, 22)
                    G.FillEllipse(Brushes.White, tc.x + tc.TabWidth - 24, tc.y, 22, 22)
                    'TOP LINES
                    G.DrawLine(pen, tc.x + 11, tc.y, tc.x + tc.TabWidth - 22, tc.y)
                    G.DrawLine(pen, tc.x + 11, tc.y + 22, tc.x + tc.TabWidth - 22, tc.y + 22)
                    'BUTTOM LINE
                    G.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)
                    'sides lines
                    G.DrawLine(pen, tc.x, tc.y + 11, tc.x, tc.y + tc.TabHeight)
                    G.DrawLine(pen, tc.x + tc.TabWidth, tc.y + 11, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

                    Dim isFerst As Boolean = True
                    For Each c As gColClass In tc.details
                        G.DrawString(c.HeaderName, F_T, Brushes.Black,
                                        New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)


                        If isFerst = True Then
                            isFerst = False
                            x = x + c.ColWidth
                            Continue For
                        End If
                        G.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                        x = x + c.ColWidth
                    Next
                ElseIf tc.Type = "Table_4" Then '//////////////////////////////////////////////

                    G.FillEllipse(Brushes.Black, tc.x, tc.y, 22, 22)
                    G.FillEllipse(Brushes.Black, tc.x + tc.TabWidth - 22, tc.y, 22, 22)
                    ''TOP LINES
                    G.FillRectangle(Brushes.Black, tc.x + 11, tc.y, tc.TabWidth - 22, 22)

                    'BUTTOM LINE
                    G.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)
                    'sides lines
                    G.DrawLine(pen, tc.x, tc.y + 11, tc.x, tc.y + tc.TabHeight)
                    G.DrawLine(pen, tc.x + tc.TabWidth, tc.y + 11, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

                    Dim isFerst As Boolean = True
                    For Each c As gColClass In tc.details
                        G.DrawString(c.HeaderName, F_T, Brushes.White, New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)
                        If isFerst = True Then
                            isFerst = False
                            x = x + c.ColWidth
                            Continue For
                        End If
                        G.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                        G.DrawLine(Pens.White, x, tc.y + 1, x, tc.y + 20)
                        x = x + c.ColWidth
                    Next
                Else '////////////////////////////////////////////////////////////////////////////
                    G.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
                    G.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
                    For Each c As gColClass In tc.details
                        G.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)
                        G.DrawLine(pen, x + c.ColWidth, tc.y, x + c.ColWidth, tc.y + tc.TabHeight)
                        x = x + c.ColWidth
                    Next
                End If

                '//////////////////////////////////////////////////////////////////////////
                'draw details into table
                While m < details.Rows.Count

                    If y > tc.y + tc.TabHeight Then
                        'e.HasMorePages = True
                        'Return
                    End If

                    Dim _x As Integer = tc.x

                    Dim plus_h As Integer = F_D.Height
                    For Each c As gColClass In tc.details
                        plus_h = F_D.Height
                        Dim _str As String = ""

                        If c.Field = "xTotal" Then '////////////////////////////////////////////////
                            _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")
                            _str = String.Format("{0:0.00}", CDbl(_str))
                            sf.Alignment = StringAlignment.Far
                        ElseIf c.Field = "xPriceTTC" Then '/////////////////////////////////////////
                            _str = details.Rows(m).Item("price")
                            Dim tva As Double = details.Rows(m).Item("tva")
                            _str = _str + ((_str * tva) / 100)
                            _str = String.Format("{0:0.00}", CDbl(_str))
                            sf.Alignment = StringAlignment.Far
                        ElseIf c.Field = "xTotalTTC" Then '/////////////////////////////////////////
                            _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")
                            Dim tva As Double = details.Rows(m).Item("tva")
                            _str = _str + ((_str * tva) / 100)
                            _str = String.Format("{0:0.00}", CDbl(_str))
                        ElseIf c.Field = "xdepot" Then '////////////////////////////////////////////
                            _str = details.Rows(m).Item("depot")
                            Try
                                Dim results = From myRow As DataRow In Form1.dt_Depot.Rows Where myRow(0) = _str Select myRow
                                _str = results(0).Item("name")
                            Catch ex As Exception
                                _str = ""
                            End Try
                            sf.Alignment = StringAlignment.Near

                        ElseIf c.Field = "xname" Then '//////////////////////////////////////////////
                            _str = "[" & details.Rows(m).Item("ref") & "] " & details.Rows(m).Item("name")
                            sf.Alignment = StringAlignment.Near
                            Dim size As SizeF = G.MeasureString(_str, F_D, c.ColWidth - 3)
                            plus_h = size.Height

                        ElseIf c.Field = "name" Then '///////////////////////////////////////////////
                            _str = details.Rows(m).Item("name")
                            sf.Alignment = StringAlignment.Near
                            Dim size As SizeF = G.MeasureString(_str, F_D, c.ColWidth - 3)
                            plus_h = size.Height

                        ElseIf c.Field = "tva" Or c.Field = "remise" Then '///////////////////////////
                            _str = details.Rows(m).Item(c.Field) & " %"

                            If details.Rows(m).Item(c.Field).ToString = "0" Or details.Rows(m).Item(c.Field).ToString = "" Then _str = ""
                            sf.Alignment = StringAlignment.Center

                        ElseIf c.Field = "price" Then '///////////////////////////////////////////////
                            _str = details.Rows(m).Item(c.Field)
                            _str = String.Format("{0:0.00}", CDbl(_str))
                            sf.Alignment = StringAlignment.Far

                        ElseIf c.Field = "qte" Then '////////////////////////////////////////////////
                            _str = details.Rows(m).Item(c.Field)
                            sf.Alignment = StringAlignment.Center
                        Else
                            _str = details.Rows(m).Item(c.Field)
                            sf.Alignment = StringAlignment.Near
                        End If
                        G.DrawString(_str, F_D, Brushes.Black, New RectangleF(_x, y, c.ColWidth - 3, plus_h), sf)
                        _x = _x + c.ColWidth
                    Next

                    Try
                        params_tva.Add(details.Rows(m).Item("tva"), details.Rows(m).Item("totaltva"))
                    Catch ex As Exception
                        params_tva(details.Rows(m).Item("tva")) += details.Rows(m).Item("totaltva")
                    End Try

                    If tc.hasLines And m > 0 Then G.DrawLine(Pens.Black, tc.x, y, tc.x + tc.TabWidth, y)

                    y += plus_h + 3
                    m += 1
                End While
                '////////////////////////////////////////////////////////////////////////////
                'Foother
                Using B As New SolidBrush(Color.Black)
                    For Each a As gTopField In FooterFieldDic
                        'Create a brush
                        If tc.Type.ToUpper.StartsWith("TAB") = False Then a.y += y

                        Dim fn As Font
                        If a.isBold Then
                            fn = New Font("Arial", a.fSize, FontStyle.Bold)
                        Else
                            fn = New Font("Arial", a.fSize)
                        End If

                        Dim xx = a.x
                        Dim yy = a.y
                        If a.hasBloc Then
                            Dim _br As New SolidBrush(a.backColor)
                            G.FillRectangle(_br, a.x, a.y, a.width, a.height)
                            G.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                        End If

                        If a.field.StartsWith("//") Then
                            sf.Alignment = StringAlignment.Near

                            Dim nPart As Decimal = 0
                            Dim zPart As Decimal = 0

                            SplitDecimal(CDec(data.Rows(0).Item(a.designation)), nPart, zPart)
                            Dim stt As String = ChLettre.NBLT(nPart) & " (Dhs)  "
                            If zPart > 0 Then
                                stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                            End If
                            'Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                            Dim strTotal As String = stt
                            G.DrawString(strTotal, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                        ElseIf a.field.StartsWith("-") Then
                            Dim Str = CStr(a.designation)
                            Str &= "Bon de Laivraison"
                            G.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)

                        ElseIf a.field.StartsWith("CLT") Then
                            Dim s = a.field.Split("_")(1)
                            Dim Str = CStr(a.designation)
                            Str &= dt_Client.Rows(0).Item(s)
                            Try
                                G.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                            Catch ex As Exception
                            End Try
                        ElseIf a.field.StartsWith("total") Then
                            If a.hasBloc Then
                                Dim _br As New SolidBrush(a.backColor)
                                G.FillRectangle(_br, a.x + a.width, a.y, a.width, a.height)
                                G.DrawRectangle(pen, a.x + a.width, a.y, a.width, a.height)
                                xx += 5
                                yy += 3
                            End If

                            sf.Alignment = StringAlignment.Near
                            G.DrawString(CStr(a.designation), fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                            sf.Alignment = StringAlignment.Far
                            Try
                                G.DrawString(data.Rows(0).Item(a.field), fn, B, New RectangleF(xx + a.width - 10, yy, a.width, a.height), sf)
                            Catch ex As Exception
                            End Try
                            sf.Alignment = StringAlignment.Near

                        ElseIf a.field.StartsWith("tableau") Then

                            Dim _x As Integer = a.x
                            Dim _y As Integer = a.y
                            Dim _wt As Integer = a.width
                            Dim _ht As Integer = a.height
                            Dim _xm As Integer = CInt(a.x + (_wt / 2))
                            G.DrawLine(Pens.Black, _x, _y, _x + _wt, _y)
                            G.DrawLine(Pens.Black, _x, _y + 15, _x + _wt, _y + 15)

                            G.DrawLine(Pens.Black, _x, _y, _x, _y + 30)
                            G.DrawLine(Pens.Black, _xm, _y, _xm, _y + 30)
                            G.DrawLine(Pens.Black, _x + _wt, _y, _x + _wt, _y + 30)
                            G.DrawString("Tva", fn, B, New RectangleF(_x + 5, _y, a.width, a.height), sf)
                            G.DrawString("Montant", fn, B, New RectangleF(_xm + 5, _y, a.width, a.height), sf)

                            _y += 20
                            For Each kvp As KeyValuePair(Of Double, Double) In params_tva
                                If kvp.Key = 0 Then Continue For

                                G.DrawLine(Pens.Black, _x, _y, _x, _y + 30)
                                G.DrawLine(Pens.Black, _xm, _y, _xm, _y + 30)
                                G.DrawLine(Pens.Black, _x + _wt, _y, _x + _wt, _y + 30)

                                G.DrawString("Taux" & kvp.Key & " %", fn, B, New RectangleF(_x + 5, _y, CInt(_wt / 2) - 7, 15), sf)
                                G.DrawString(String.Format("{0:0.00}", CDbl(kvp.Value)), fn, B, New RectangleF(_xm, _y, CInt(_wt / 2) - 7, 15), sfl)

                                _y += 15
                            Next

                            G.DrawLine(Pens.Black, _x, _y + 15, _x + _wt, _y + 15)


                        ElseIf a.field.StartsWith("image") Then
                            Try
                                Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                                G.DrawImage(Image.FromFile(fullPath), xx, yy, a.width, a.height)
                            Catch ex As Exception
                            End Try
                        Else
                            Try
                                Dim str As String = CStr(a.designation)
                                If a.field.StartsWith("*") = False Then str &= data.Rows(0).Item(a.field)
                                G.DrawString(str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                End Using

                _Bmp = DirectCast(Bmp.Clone(), Image)
            End Using
        End Using
        m = 0
        Return _Bmp
    End Function
    Dim m = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)
    End Sub

    Private Sub btTop_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim ff As New AddEditTopField
        Dim bt As Button = sender
        ff.EditMode = True
        ff.Prop = bt.Tag
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ff.Prop.isDeleted Then
                TopFieldDic.Remove(bt.Tag)
                PT.Controls.Remove(bt)
                Exit Sub
            End If


            bt.Text = ff.Prop.designation
            bt.Tag = ff.Prop

            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            TopFieldDic.Clear()
            For Each b As Button In PT.Controls
                TopFieldDic.Add(b.Tag)
            Next

            pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)
        End If
    End Sub

    Private Sub PT_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PT.DoubleClick
        Dim ff As New AddEditTopField
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bt As New Button
            bt.Text = ff.Prop.designation
            bt.Tag = ff.Prop
            bt.FlatStyle = FlatStyle.Flat
            bt.AutoSize = True

            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            AddHandler bt.Click, AddressOf btTop_Clicked
            PT.Controls.Add(bt)
            TopFieldDic.Add(ff.Prop)

            pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)
        End If
    End Sub

    Private Sub Pf_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pf.DoubleClick
        Dim ff As New AddEditTopField
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim bt As New Button
            bt.Text = ff.Prop.designation
            bt.Tag = ff.Prop
            bt.FlatStyle = FlatStyle.Flat
            bt.AutoSize = True
            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            AddHandler bt.Click, AddressOf btButom_Clicked
            Pf.Controls.Add(bt)
            FooterFieldDic.Add(ff.Prop)


            pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)
        End If
    End Sub

    Private Sub btButom_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim ff As New AddEditTopField
        Dim bt As Button = sender
        ff.EditMode = True
        ff.Prop = bt.Tag
        If ff.ShowDialog = Windows.Forms.DialogResult.OK Then
            If ff.Prop.isDeleted Then
                FooterFieldDic.Remove(bt.Tag)
                Pf.Controls.Remove(bt)
                Exit Sub
            End If


            bt.Text = ff.Prop.designation
            bt.Tag = ff.Prop

            Dim fn As Font
            If ff.Prop.isBold Then
                fn = New Font("Arial", ff.Prop.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.Prop.fSize)
            End If

            bt.Font = fn

            FooterFieldDic.Clear()
            For Each b As Button In Pf.Controls
                FooterFieldDic.Add(b.Tag)
            Next

            pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim g As New gGlobClass
        g.FooterFieldDic = FooterFieldDic
        g.TopFieldDic = TopFieldDic
        g.W_Page = W_Page
        g.h_Page = H_Page
        g.localName = localname
        g.TabProp = gt.TabProp
        g.is_Landscape = isLandScape
        g.P_name = p_name
        g.p_kind = p_Kind
        WriteToXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localname, g)
    End Sub
    Public Sub LoadXml()
        Dim g As New gGlobClass
        g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localname)
        FooterFieldDic = g.FooterFieldDic
        TopFieldDic = g.TopFieldDic
        W_Page = g.W_Page
        H_Page = g.h_Page
        p_name = g.P_name
        p_Kind = g.p_Kind
        isLandScape = g.is_Landscape
        gt.TabProp = g.TabProp

        For Each ff As gTopField In TopFieldDic
            Dim bt As New Button
            bt.Text = ff.designation
            bt.Tag = ff
            bt.FlatStyle = FlatStyle.Flat

            Dim fn As Font
            If ff.isBold Then
                fn = New Font("Arial", ff.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.fSize)
            End If

            bt.Font = fn

            AddHandler bt.Click, AddressOf btTop_Clicked
            PT.Controls.Add(bt)
        Next

        For Each ff As gTopField In FooterFieldDic
            Dim bt As New Button
            bt.Text = ff.designation
            bt.Tag = ff
            bt.FlatStyle = FlatStyle.Flat

            Dim fn As Font
            If ff.isBold Then
                fn = New Font("Arial", ff.fSize, FontStyle.Bold)
            Else
                fn = New Font("Arial", ff.fSize)
            End If

            bt.Font = fn

            AddHandler bt.Click, AddressOf btButom_Clicked
            Pf.Controls.Add(bt)
        Next

    End Sub

    Private Sub pb_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseDown
        p1 = e.Location
    End Sub

    Private Sub pb_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseUp
        If p1.X = 0 Then Exit Sub
        p2 = e.Location

        If Math.Abs(p1.X - p2.X) < 10 And Math.Abs(p1.Y - p2.Y) < 10 Then Exit Sub

        Dim _tabProp As New gTopField
        _tabProp.designation = ""
        _tabProp.field = "*"
        _tabProp.width = IIf(p1.X > p2.X, p1.X - p2.X, p2.X - p1.X)
        _tabProp.height = IIf(p1.Y > p2.Y, p1.Y - p2.Y, p2.Y - p1.Y)
        _tabProp.x = IIf(p1.X > p2.X, p2.X, p1.X)
        _tabProp.y = IIf(p1.Y > p2.Y, p2.Y, p1.Y)
        _tabProp.fSize = 9
        _tabProp.isBold = False
        _tabProp.backColor = Color.Gray
        _tabProp.hasBloc = True

        Dim bt As New Button
        bt.Text = "   *   "
        bt.AutoSize = True
        bt.Tag = _tabProp
        bt.FlatStyle = FlatStyle.Flat

        Dim fn As Font
        fn = New Font("Arial", 9)

        bt.Font = fn
        If p1.Y * 2 > H_Page Then
            AddHandler bt.Click, AddressOf btButom_Clicked
            Pf.Controls.Add(bt)
            FooterFieldDic.Add(_tabProp)
        Else
            AddHandler bt.Click, AddressOf btTop_Clicked
            PT.Controls.Add(bt)
            TopFieldDic.Add(_tabProp)
        End If
        pb.BackgroundImage = DrawBl(gt.TabProp, Data_imp_Source, Details_imp_Source, Client_imp_Source, False, m)

        _tabProp.hasBloc = False

        If p1.Y * 2 > H_Page Then
            btButom_Clicked(bt, Nothing)
        Else
            btTop_Clicked(bt, Nothing)
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox(MsgDelete, MsgBoxStyle.YesNo, "Supression") = MsgBoxResult.Yes Then
            Try
                Dim strpath As String = Form1.ImgPah & "\Prt_Dsn"
                Dim fullPath As String = Path.Combine(strpath, localname)
                File.Delete(fullPath)

                Me.DialogResult = Windows.Forms.DialogResult.OK
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txt_w_TxtChanged() Handles txt_w.TxtChanged, txt_H.TxtChanged
        If isLandScape Then
            pb.Width = H_Page
            pb.Height = W_Page
        Else
            pb.Width = W_Page
            pb.Height = H_Page
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim doc As New PrintDocument
        Dim ps As New PageSetupDialog
        With ps
            .Document = doc
            .ShowDialog(Me)
        End With
        Dim str As String = ""

        str &= "oriontation " &
            IIf(doc.DefaultPageSettings.Landscape, "Payessage", "portrait") & vbNewLine
        str &= "Format " & doc.DefaultPageSettings.PaperSize.ToString
        MsgBox(str)

        W_Page = doc.DefaultPageSettings.PaperSize.Width
        H_Page = doc.DefaultPageSettings.PaperSize.Height
        isLandScape = doc.DefaultPageSettings.Landscape
        p_name = doc.DefaultPageSettings.PaperSize.PaperName
        p_Kind = doc.DefaultPageSettings.PaperSize.Kind
    End Sub
End Class