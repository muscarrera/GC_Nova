Imports System.IO

Public Class gDrawClass
    Implements IDisposable

    Dim frt = Form1.DesimalSringFormat

    Dim FooterFieldDic As List(Of gTopField)
    Dim TopFieldDic As List(Of gTopField)
    Dim W_Page As Integer
    Dim h_Page As Integer
    Dim gTabProp As gTabClass
    Dim localname As String



    Public Sub New(ByVal lName As String)
        localname = lName
        LoadXml()
    End Sub


    Public Sub LoadXml()
        Dim g As New gGlobClass

        g = ReadFromXmlFile(Of gGlobClass)(Form1.ImgPah & "\Prt_Dsn\" & localname)
        FooterFieldDic = g.FooterFieldDic
        TopFieldDic = g.TopFieldDic
        W_Page = g.W_Page
        h_Page = g.h_Page
        gTabProp = g.TabProp
    End Sub
    Public Sub DrawBl(ByRef e As System.Drawing.Printing.PrintPageEventArgs,
                           ByVal data As DataTable,
                              ByVal details As DataTable,
                              ByVal dt_Client As DataTable,
                              ByVal dt_Tva As DataTable,
                              ByVal title As String,
                              ByVal HD As Boolean,
                              ByRef m As Integer)
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


        Dim params_tva As New Dictionary(Of Double, Double)

        Dim g = e.Graphics

        Dim _w = W_Page
        Dim _h = h_Page
        Dim tc = gTabProp

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
                    g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
                    Dim _br As New SolidBrush(a.backColor)
                    g.FillRectangle(_br, a.x, a.y, a.width, a.height)

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
                        g.DrawImage(Image.FromFile(fullPath), top_x, top_y, a.width, a.height)
                    Catch ex As Exception
                    End Try
                ElseIf a.field.StartsWith("-") Then
                    str &= title
                Else

                    str &= data.Rows(0).Item(a.field)
                End If

                g.DrawString(str, fn, B, New RectangleF(top_x, top_y, a.width, a.height), sf)
            Next
        End Using
        '////////////////////////////////////////////////////////////////////////
        ' table
        Dim _Ttype = tc.Type
        Dim x As Integer = tc.x
        y = tc.y + 33

        If _Ttype = "Table_1" Then  '//////////////////////////////////////////////
            g.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
            g.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
            Dim isFerst As Boolean = True
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black,
                                New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)


                If isFerst = True Then
                    isFerst = False
                    x = x + c.ColWidth
                    Continue For
                End If
                g.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                x = x + c.ColWidth
            Next


        ElseIf _Ttype = "Table_2" Then '//////////////////////////////////////////////
            g.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth - 3, 15), sf)
                g.DrawLine(pen, x, tc.y + 22, x + c.ColWidth - 3, tc.y + 22)
                x = x + c.ColWidth
            Next

        ElseIf _Ttype = "Liste_1" Then '//////////////////////////////////////////////

            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth - 3, 15), sf)
                g.DrawLine(pen, x, tc.y + 22, x + c.ColWidth - 3, tc.y + 22)
                x = x + c.ColWidth
            Next
        ElseIf _Ttype = "Table_3" Then '//////////////////////////////////////////////

            g.DrawEllipse(pen, tc.x, tc.y, 22, 22)
            g.DrawEllipse(pen, tc.x + tc.TabWidth - 22, tc.y, 22, 22)
            g.FillEllipse(Brushes.White, tc.x + 2, tc.y, 22, 22)
            g.FillEllipse(Brushes.White, tc.x + tc.TabWidth - 24, tc.y, 22, 22)
            'TOP LINES
            g.DrawLine(pen, tc.x + 11, tc.y, tc.x + tc.TabWidth - 22, tc.y)
            g.DrawLine(pen, tc.x + 11, tc.y + 22, tc.x + tc.TabWidth - 22, tc.y + 22)
            'BUTTOM LINE
            g.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)
            'sides lines
            g.DrawLine(pen, tc.x, tc.y + 11, tc.x, tc.y + tc.TabHeight)
            g.DrawLine(pen, tc.x + tc.TabWidth, tc.y + 11, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

            Dim isFerst As Boolean = True
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black,
                                New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)


                If isFerst = True Then
                    isFerst = False
                    x = x + c.ColWidth
                    Continue For
                End If
                g.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                x = x + c.ColWidth
            Next
        ElseIf _Ttype = "Table_4" Then '//////////////////////////////////////////////

            g.FillEllipse(Brushes.Black, tc.x, tc.y, 22, 22)
            g.FillEllipse(Brushes.Black, tc.x + tc.TabWidth - 22, tc.y, 22, 22)
            ''TOP LINES
            g.FillRectangle(Brushes.Black, tc.x + 11, tc.y, tc.TabWidth - 22, 22)

            'BUTTOM LINE
            g.DrawLine(pen, tc.x, tc.y + tc.TabHeight, tc.x + tc.TabWidth, tc.y + tc.TabHeight)
            'sides lines
            g.DrawLine(pen, tc.x, tc.y + 11, tc.x, tc.y + tc.TabHeight)
            g.DrawLine(pen, tc.x + tc.TabWidth, tc.y + 11, tc.x + tc.TabWidth, tc.y + tc.TabHeight)

            Dim isFerst As Boolean = True
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.White, New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)
                If isFerst = True Then
                    isFerst = False
                    x = x + c.ColWidth
                    Continue For
                End If
                g.DrawLine(pen, x, tc.y, x, tc.y + tc.TabHeight)
                g.DrawLine(Pens.White, x, tc.y + 1, x, tc.y + 20)
                x = x + c.ColWidth
            Next
        Else '////////////////////////////////////////////////////////////////////////////
            g.DrawRectangle(pen, tc.x, tc.y, tc.TabWidth, tc.TabHeight)
            g.DrawLine(pen, tc.x, tc.y + 22, tc.x + tc.TabWidth, tc.y + 22)
            For Each c As gColClass In tc.details
                g.DrawString(c.HeaderName, F_T, Brushes.Black, New RectangleF(x, tc.y + 3, c.ColWidth, 15), sfc)
                g.DrawLine(pen, x + c.ColWidth, tc.y, x + c.ColWidth, tc.y + tc.TabHeight)
                x = x + c.ColWidth
            Next
        End If
        '//////////////////////////////////////////////////////////////////////////
        'draw details into table

        If m > 0 Then g.DrawString("[ ..... ]", F_D, Brushes.Black, tc.x, tc.y - 22)
        While m < details.Rows.Count

            If y > tc.y + tc.TabHeight And _Ttype.ToUpper.StartsWith("TAB") Then
                g.DrawString("[ ..... ]", F_D, Brushes.Black, tc.TabWidth + tc.x - 60, tc.y + tc.TabHeight + 22)
                y = tc.y + 33
                e.HasMorePages = True
                Return
            End If

            Dim _x As Integer = tc.x

            Dim plus_h As Integer = F_D.Height
            For Each c As gColClass In tc.details

                Dim _str As String = ""

                If c.Field = "xTotal" Then '////////////////////////////////////////////////
                    _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")
                    _str = String.Format(frt, CDbl(_str))
                    sf.Alignment = StringAlignment.Far
                ElseIf c.Field = "xPriceTTC" Then '/////////////////////////////////////////
                    _str = details.Rows(m).Item("price")
                    Dim tva As Double = details.Rows(m).Item("tva")
                    _str = _str + ((_str * tva) / 100)
                    _str = String.Format(frt, CDbl(_str))
                    sf.Alignment = StringAlignment.Far
                ElseIf c.Field = "xTotalTTC" Then '/////////////////////////////////////////
                    _str = details.Rows(m).Item("qte") * details.Rows(m).Item("price")
                    Dim tva As Double = details.Rows(m).Item("tva")
                    _str = _str + ((_str * tva) / 100)
                    _str = String.Format(frt, CDbl(_str))
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
                    Dim size As SizeF = g.MeasureString(_str, F_D, c.ColWidth - 3)
                    plus_h = size.Height

                ElseIf c.Field = "name" Then '///////////////////////////////////////////////
                    _str = details.Rows(m).Item("name")
                    sf.Alignment = StringAlignment.Near
                    Dim size As SizeF = g.MeasureString(_str, F_D, c.ColWidth - 3)
                    plus_h = size.Height

                ElseIf c.Field = "tva" Or c.Field = "remise" Then '///////////////////////////
                    _str = details.Rows(m).Item(c.Field) & " %"

                    If details.Rows(m).Item(c.Field).ToString = "0" Or details.Rows(m).Item(c.Field).ToString = "" Then _str = ""
                    sf.Alignment = StringAlignment.Center

                ElseIf c.Field = "price" Then '///////////////////////////////////////////////
                    _str = details.Rows(m).Item(c.Field)
                    _str = String.Format(frt, CDbl(_str))
                    sf.Alignment = StringAlignment.Far

                ElseIf c.Field = "qte" Then '////////////////////////////////////////////////
                    _str = details.Rows(m).Item(c.Field)
                    sf.Alignment = StringAlignment.Center
                Else
                    _str = details.Rows(m).Item(c.Field)
                    sf.Alignment = StringAlignment.Near
                End If
                g.DrawString(_str, F_D, Brushes.Black, New RectangleF(_x, y, c.ColWidth - 3, plus_h), sf)
                _x = _x + c.ColWidth
            Next

            'Try
            '    params_tva.Add(details.Rows(m).Item("tva"), details.Rows(m).Item("totaltva"))
            'Catch ex As Exception
            '    params_tva(details.Rows(m).Item("tva")) += details.Rows(m).Item("totaltva")
            'End Try

            If tc.hasLines And m > 0 Then g.DrawLine(Pens.Black, tc.x, y, tc.x + tc.TabWidth, y)


            y += plus_h + 3
            m += 1
        End While
        '////////////////////////////////////////////////////////////////////////////
        'Foother
        Using B As New SolidBrush(Color.Black)
            For Each a As gTopField In FooterFieldDic
                'Create a brush

                If _Ttype.ToUpper.StartsWith("TAB") = False Then a.y += y

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
                    g.FillRectangle(_br, a.x, a.y, a.width, a.height)
                    g.DrawRectangle(pen, a.x, a.y, a.width, a.height)
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
                    g.DrawString(strTotal, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                ElseIf a.field.StartsWith("-") Then
                    Dim Str = CStr(a.designation)
                    Str &= title
                    g.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)

                ElseIf a.field.StartsWith("CLT") Then
                    Dim s = a.field.Split("_")(1)
                    Dim Str = CStr(a.designation)
                    Str &= dt_Client.Rows(0).Item(s)
                    Try
                        g.DrawString(Str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                    Catch ex As Exception
                    End Try
                ElseIf a.field.StartsWith("total") Then
                    If a.hasBloc Then
                        Dim _br As New SolidBrush(a.backColor)
                        g.FillRectangle(_br, a.x + a.width, a.y, a.width, a.height)
                        g.DrawRectangle(pen, a.x + a.width, a.y, a.width, a.height)
                        xx += 5
                        yy += 3
                    End If

                    sf.Alignment = StringAlignment.Near
                    g.DrawString(CStr(a.designation), fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                    sf.Alignment = StringAlignment.Far
                    Try
                        Dim tt_str = data.Rows(0).Item(a.field)
                        g.DrawString(tt_str, fn, B, New RectangleF(xx + a.width - 10, yy, a.width, a.height), sf)
                    Catch ex As Exception
                    End Try

                    sf.Alignment = StringAlignment.Near

                ElseIf a.field.StartsWith("tableau") Then
                    params_tva.Clear()

                    Try
                        For ii As Integer = 0 To dt_Tva.Rows.Count - 1
                            params_tva.Add(dt_Tva.Rows(ii).Item(0), dt_Tva.Rows(ii).Item(1))
                        Next
                    Catch ex As Exception
                    End Try


                    Dim _x As Integer = a.x
                    Dim _y As Integer = a.y
                    Dim _wt As Integer = a.width
                    Dim _ht As Integer = a.height
                    Dim _xm As Integer = CInt(a.x + (_wt / 2))
                    g.DrawLine(Pens.Black, _x, _y, _x + _wt, _y)
                    g.DrawLine(Pens.Black, _x, _y + 15, _x + _wt, _y + 15)

                    g.DrawLine(Pens.Black, _x, _y, _x, _y + 30)
                    g.DrawLine(Pens.Black, _xm, _y, _xm, _y + 30)
                    g.DrawLine(Pens.Black, _x + _wt, _y, _x + _wt, _y + 30)
                    g.DrawString("Tva", fn, B, New RectangleF(_x + 5, _y, a.width, a.height), sf)
                    g.DrawString("Montant", fn, B, New RectangleF(_xm + 5, _y, a.width, a.height), sf)

                    _y += 20
                    For Each kvp As KeyValuePair(Of Double, Double) In params_tva
                        If kvp.Key = 0 Then Continue For

                        g.DrawLine(Pens.Black, _x, _y, _x, _y + 30)
                        g.DrawLine(Pens.Black, _xm, _y, _xm, _y + 30)
                        g.DrawLine(Pens.Black, _x + _wt, _y, _x + _wt, _y + 30)

                        g.DrawString("Tva  " & kvp.Key & " %", fn, B, New RectangleF(_x + 5, _y, CInt(_wt / 2) - 7, 15), sf)
                        g.DrawString(String.Format(Form1.DesimalSringFormat_Total, kvp.Value), fn, B, New RectangleF(_xm, _y, CInt(_wt / 2) - 7, 15), sfl)

                        _y += 15
                    Next
                    g.DrawLine(Pens.Black, _x, _y + 15, _x + _wt, _y + 15)

                ElseIf a.field.StartsWith("image") Then
                    Try
                        Dim fullPath As String = Path.Combine("C:\cmcimage", a.designation)
                        g.DrawImage(Image.FromFile(fullPath), xx, yy, a.width, a.height)
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        Dim str As String = CStr(a.designation)
                        If a.field.StartsWith("*") = False Then str &= data.Rows(0).Item(a.field)
                        g.DrawString(str, fn, B, New RectangleF(xx, yy, a.width, a.height), sf)
                    Catch ex As Exception
                    End Try
                End If
            Next
        End Using
        m = 0
        'Return _Bmp
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
