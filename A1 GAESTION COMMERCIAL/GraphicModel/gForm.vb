Imports System.Xml.Serialization
Imports System.IO

Public Class gForm

    Public FooterFieldDic As New List(Of gTopField)
    Public TopFieldDic As New List(Of gTopField)

    'Dim dt_fact As DataTable
    'Dim dt_Details As DataTable
    'Dim dt_Client As DataTable

    Public W_Page As Integer = 720
    Public h_Page As Integer = 1160
    Public localname As String = "Default"

    Dim allowDraw As Boolean = True
    Dim p1 As Point = New Point(0, 0)
    Dim p2 As Point = New Point(0, 0)

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

            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add(1, "Article1", 1, 3, 11.5, 11,
                              20, "REF 123", 1, 0, 2)
            table.Rows.Add(1, "Article2", 1, 12, 34.4, 11,
                             20, "REF 123", 1, 0, 2)
            table.Rows.Add(1, "Article3", 1, 1, 66, 11,
                             20, "REF 123", 1, 0, 2)
            table.Rows.Add(1, "Article4", 1, 54, 5, 11,
                             14, "REF 123", 4, 0, 2)
            Return table
        End Get
    End Property
    Public ReadOnly Property Data_imp_Source As DataTable
        Get
            Dim table As New DataTable
            ' Create four typed columns in the DataTable.
            table.Columns.Add("id", GetType(Integer))
            table.Columns.Add("date", GetType(Date))
            table.Columns.Add("cid", GetType(Integer))
            table.Columns.Add("name", GetType(String))
            table.Columns.Add("total_ht", GetType(String))
            table.Columns.Add("total_tva", GetType(String))
            table.Columns.Add("total_ttc", GetType(String))
            table.Columns.Add("total_remise", GetType(String))
            table.Columns.Add("Avance", GetType(String))
            table.Columns.Add("droitTimbre", GetType(String))
            table.Columns.Add("MPayement", GetType(String))
            table.Columns.Add("Editeur", GetType(String))

            ' Add  rows with those columns filled in the DataTable.
            table.Rows.Add(1, Now.Date, 1, "Mohamed", String.Format("{0:0.00}", 222),
                           String.Format("{0:0.00}", 66), String.Format("c", 288), "0",
                              "0", "0", "CHEQUE", "ADMIN")

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

        pb.Width = W_Page
        pb.Height = h_Page

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

        Dim _Bmp As Bitmap


        Dim _w = tc.TabWidth + 44
        Dim _h = tc.TabHeight + 444



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

                            a.x += 5
                            a.y += 3
                        End If

                        Dim str As String = CStr(a.designation)

                        If a.field.StartsWith("CLT") Then
                            Dim s = a.field.Split("_")(1)
                            str &= dt_Client.Rows(0).Item(s)
                        ElseIf a.field.StartsWith("*") Then

                        Else

                            str &= data.Rows(0).Item(a.field)
                        End If

                        G.DrawString(str, fn, B,
                                     New RectangleF(a.x, a.y, a.width,
                                                    a.height), sf)

                    Next
                End Using
                '////////////////////////////////////////////////////////////////////////
                ' table


                If tc.Type = "Table_1" Then
                    G.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
                    G.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
                ElseIf tc.Type = "Table_2" Then

                ElseIf tc.Type = "Table_3" Then

                Else
                    G.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
                    G.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
                End If

                Dim x As Integer = tc.x
                y = tc.y + 33

                For Each c As gColClass In tc.details
                    G.DrawString(c.HeaderName, F_T, Brushes.Black,
                                    New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)
                    G.DrawLine(pen, x + c.ColWidth, tc.y, x + c.ColWidth, tc.TabHeight)
                    x = x + c.ColWidth
                Next
                '//////////////////////////////////////////////////////////////////////////
                'draw details into table
                While m < details.Rows.Count

                    If y > tc.y + tc.TabHeight Then
                        'e.HasMorePages = True
                        'Return
                    End If

                    Dim _x As Integer = tc.x

                    For Each c As gColClass In tc.details

                        Dim _str As String = ""
                        If c.Field = "xxx" Then
                            _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")
                            _str = String.Format("{0:0.00}", _str)
                            sf.Alignment = StringAlignment.Far
                        ElseIf c.Field = "price" Then
                            _str = details.Rows(m).Item(c.Field)
                            _str = String.Format("{0:0.00}", _str)
                            sf.Alignment = StringAlignment.Far

                        ElseIf c.Field = "qte" Then
                            sf.Alignment = StringAlignment.Center
                        Else
                            _str = details.Rows(m).Item(c.Field)
                            sf.Alignment = StringAlignment.Near
                        End If

                        G.DrawString(_str, F_D, Brushes.Black,
                                        New RectangleF(_x, y, c.ColWidth, 15), sf)

                        _x = _x + c.ColWidth
                    Next
                    y += F_D.Height
                    m += 1
                End While
                '////////////////////////////////////////////////////////////////////////////
                'Foother
                Using B As New SolidBrush(Color.Black)
                    For Each a As gTopField In FooterFieldDic
                        'Create a brush

                        Dim fn As Font
                        If a.isBold Then
                            fn = New Font("Arial", a.fSize, FontStyle.Bold)
                        Else
                            fn = New Font("Arial", a.fSize)
                        End If

                        If a.field.StartsWith("//") Then

                            sf.Alignment = StringAlignment.Near

                            Dim nPart As Decimal = 0
                            Dim zPart As Decimal = 0

                            SplitDecimal(CDec(data.Rows(0).Item("total")), nPart, zPart)
                            Dim stt As String = ChLettre.NBLT(nPart) & " (Dhs)  "
                            If zPart > 0 Then
                                stt &= "et " & ChLettre.NBLT(CInt(zPart * 100)) & " (Cts)"
                            End If
                            Dim strTotal As String = "Arrêté la présente facture à la somme : " & stt
                            G.DrawString(strTotal, fn, B, New RectangleF(a.x, a.y, a.width, a.height), sf)
                        Else
                            Dim xx = a.x
                            Dim yy = a.y
                            If a.hasBloc Then
                                Dim _br As New SolidBrush(a.backColor)
                                G.FillRectangle(_br, a.x, a.y, a.width, a.height)
                                G.DrawRectangle(pen, a.x, a.y, a.width, a.height)

                                G.FillRectangle(_br, a.x + a.width, a.y, a.width, a.height)
                                G.DrawRectangle(pen, a.x + a.width, a.y, a.width, a.height)
                                xx += 5
                                yy += 3
                            End If
                            sf.Alignment = StringAlignment.Near
                            G.DrawString(CStr(a.designation), fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                            sf.Alignment = StringAlignment.Far
                            G.DrawString(data.Rows(0).Item(a.field), fn, B, New RectangleF(xx + a.width, yy, a.width, a.height), sf)
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
        g.h_Page = h_Page
        g.localName = localname
        g.TabProp = gt.TabProp

        WriteToXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localname, g)
    End Sub
    Public Sub LoadXml()
        Dim g As New gGlobClass

        g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localname)
        FooterFieldDic = g.FooterFieldDic
        TopFieldDic = g.TopFieldDic
        W_Page = g.W_Page
        h_Page = g.h_Page
        gt.TabProp = g.TabProp
        'localname = g.localName


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

            AddHandler bt.Click, AddressOf btTop_Clicked
            Pf.Controls.Add(bt)
        Next

    End Sub

    Private Sub pb_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseDown
        p1 = e.Location
    End Sub

    Private Sub pb_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pb.MouseUp
        If p1.X = 0 Then Exit Sub
        p2 = e.Location

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
        If p1.Y * 2 > h_Page Then
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

        If p1.Y * 2 > h_Page Then
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
End Class