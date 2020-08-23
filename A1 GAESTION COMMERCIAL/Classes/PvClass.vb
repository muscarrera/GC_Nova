Public Class PvClass
    Implements IDisposable

    Public PvL As PvList

    Public Sub New()

    End Sub

    Public Sub AddDataList()

        If Form1.plBody.Controls.Count > 0 Then
            If TypeOf Form1.plBody.Controls(0) Is PvList Then
                PvL = Form1.plBody.Controls(0)
                Exit Sub
            End If
        End If

        Form1.plBody.Controls.Clear()

        PvL = New PvList
         
        PvL.Dock = DockStyle.Fill
        AddHandler PvL.txtSearchRef_Changed, AddressOf txtSearchRef_Changed
        AddHandler PvL.txtSearchRef_KeyPress, AddressOf txtSearchRef_KeyPress
        AddHandler PvL.txtSearchCodebar_KeyPress, AddressOf txtSearchCodebar_KeyPress

        'AddHandler ds.LoadOpenBons, AddressOf LoadOpenBons
        AddHandler PvL.SelectBon, AddressOf SelectBon
        AddHandler PvL.FillGroupe, AddressOf FillGroupes

        '
        PvL.numberOpenBons = 0
        PvL.modeSearch_isCode = False

        Form1.plBody.Controls.Add(PvL)

        FillGroupes()
        PvL.LoadOpenBons()
        PvL.KeepTxtFocus()

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

    Private Sub txtSearchRef_Changed(ByRef ds As PvList, ByVal txt As String)
        If txt.Trim = "" Then Exit Sub
        ds.FL.Controls.Clear()

        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt2 As DataTable
            Dim artdt As DataTable

            '''''''''''''''''''

            If Form1.SearchBy = "nom" Then
                artdt = artta.GetDataByLikeName("%" & txt & "%")

            ElseIf Form1.SearchBy = "ref" Then
                artdt = artta.GetDataByRef(txt & "%")

            Else
                artdt = artta.GetDataByRef("%" & txt & "%")
                artdt2 = artta.GetDataByLikeName("%" & txt & "%")
                artdt.Merge(artdt2, False)
            End If

            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                ds.FL.Controls.Add(lb)

            Else
                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.ImgPah & "\art" & artdt.Rows(i).Item("img").ToString

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                        bt.BackgroundImage = My.Resources.BGpRD
                    End Try


                    bt.Width = Form1.pvLongerbt
                    bt.Height = Form1.pvLargebt
                    ds.FL.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click


                    AddHandler bt.Click, AddressOf art_click
                    If i = Form1.numberOfItems Then Exit For
                Next

            End If
           
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtSearchRef_KeyPress(ByRef ds As PvList, ByVal txt As String)
        Dim bt As New Button
        Try
            bt = ds.FL.Controls(0)
            '''''

            ' sell function
            art_click(bt, Nothing)

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub txtSearchCodebar_KeyPress(ByRef ds As PvList, ByVal txt As String)
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt As DataTable

            '''''''''''''''''''

            artdt = artta.GetDataByCodeBar(txt & "%")

            If artdt.Rows.Count = 1 Then

                Dim bt As New Button
                bt.Tag = artdt.Rows(0)


                ' sell function
                art_click(bt, Nothing)

                Try
                    Dim lb As Label = ds.FL.Controls(0)
                    ds.FL.Controls.Clear()
                Catch ex As Exception
                End Try

            ElseIf artdt.Rows.Count > 1 Then
                ds.FL.Controls.Clear()

                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.ImgPah & "\art" & artdt.Rows(i).Item("img").ToString

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception

                        bt.BackgroundImage = My.Resources.BGpRD
                    End Try


                    bt.Width = Form1.pvLongerbt
                    bt.Height = Form1.pvLargebt
                    ds.FL.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click


                    AddHandler bt.Click, AddressOf art_click
                    If i = Form1.numberOfItems Then Exit For
                Next
            Else
                ds.FL.Controls.Clear()
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                lb.Font = New Font("Arial", 14, FontStyle.Bold)
                lb.ForeColor = Color.Red
                lb.AutoSize = True
                ds.FL.Controls.Add(lb)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Methode handlers
    Public Sub FillGroupes()
        Dim ctgta As New ALMohassinDBDataSetTableAdapters.CategoryTableAdapter
        Dim ctgdt = ctgta.GetData()
        PvL.FL.Controls.Clear()

        For i As Integer = 0 To ctgdt.Rows.Count - 1
            Dim bt As New Button

            bt.BackColor = Color.LightGoldenrodYellow
            bt.Text = ctgdt.Rows(i).Item("name").ToString
            bt.Name = "ctg" & i
            bt.Tag = ctgdt.Rows(i).Item("cid")

            bt.TextAlign = ContentAlignment.BottomCenter
            Try
                If ctgdt.Rows(i).Item("img").ToString = "No Image" Or ctgdt.Rows(i).Item("img").ToString = "" Then
                    bt.BackColor = Color.Moccasin
                Else
                    Dim str As String = Form1.ImgPah & "\cat" & ctgdt.Rows(i).Item("img").ToString

                    bt.BackgroundImage = Image.FromFile(str)
                End If
                bt.BackgroundImageLayout = ImageLayout.Stretch
            Catch ex As Exception
                bt.Text = ctgdt.Rows(i).Item("name").ToString
            End Try
            bt.Width = 125
            bt.Height = 90

            AddHandler bt.Click, AddressOf ctg_click

            PvL.FL.Controls.Add(bt)

        Next


        PvL.RPL.CP.Value = 0
        PvL.KeepTxtFocus()

    End Sub
    Private Sub ctg_click(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim bt2 As Button = sender
        PvL.FL.Controls.Clear()
        Try
            Dim artta As New ALMohassinDBDataSetTableAdapters.ArticleTableAdapter
            Dim artdt = artta.GetDataBycid(bt2.Tag)
          
            If artdt.Rows.Count = 0 Then
                Dim lb As New Label

                lb.ForeColor = Color.DarkGray
                lb.Text = "لا يوجد اي سجل"
                PvL.FL.Controls.Add(lb)
            Else

                For i As Integer = 0 To artdt.Rows.Count - 1

                    Dim bt As New Button

                    bt.Visible = True
                    bt.FlatStyle = FlatStyle.Flat
                    bt.BackColor = Color.LightSeaGreen
                    bt.Text = artdt.Rows(i).Item("name").ToString
                    bt.Name = "art" & i
                    bt.Tag = artdt.Rows(i)
                    bt.TextAlign = ContentAlignment.BottomCenter
                    Try
                        If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                        Else
                            Dim str As String = Form1.ImgPah & "\art" & artdt.Rows(i).Item("img").ToString

                            bt.BackgroundImage = Image.FromFile(str)
                        End If
                        bt.BackgroundImageLayout = ImageLayout.Stretch
                        bt.ImageAlign = ContentAlignment.BottomCenter
                    Catch ex As Exception
                        bt.Text = artdt.Rows(i).Item("name").ToString
                    End Try
                    bt.Width = Form1.pvLongerbt
                    bt.Height = Form1.pvLargebt
                    PvL.FL.Controls.Add(bt)
                    'AddHandler bt.Click, AddressOf art_click
                    ''''''''''''''''''''''''''''''''''''''''''''''' list suivant

                    If i = Form1.numberOfItems Then

                        AddHandler bt.Click, AddressOf ctg_NEXT
                        bt.BackColor = Color.Green
                        bt.Text = "[...]"
                        bt.TextAlign = ContentAlignment.MiddleCenter
                        bt.BackgroundImage = Nothing
                        bt.Tag = artdt

                        Form1.indexStartArticle = Form1.numberOfItems
                        Exit For
                    Else
                        AddHandler bt.Click, AddressOf art_click
                    End If
                Next

            End If

            PvL.KeepTxtFocus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ctg_NEXT(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim bt2 As Button = sender
            PvL.FL.Controls.Clear()
            Dim artdt = bt2.Tag

            '''''''''''''''''''''''''''''''''''' go back
            If Form1.indexStartArticle > 0 Then

                Dim btBACK As New Button
                btBACK.Visible = True
                btBACK.FlatStyle = FlatStyle.Flat
                btBACK.BackColor = Color.Green
                btBACK.Text = "[...]"
                btBACK.Tag = bt2.Tag
                'btBACK.TextAlign = ContentAlignment.BottomCenter
                btBACK.Width = Form1.pvLongerbt
                btBACK.Height = Form1.pvLargebt
                PvL.FL.Controls.Add(btBACK)
                AddHandler btBACK.Click, AddressOf ctg_BACK
            End If

            ''''''''''''''''''''''''''''''''''''
            Dim _END As Integer = Form1.indexStartArticle + Form1.numberOfItems
            For i As Integer = Form1.indexStartArticle To _END

                If i = artdt.Rows.Count Then
                    Form1.indexStartArticle = i '- Form1.indexLastArticle
                    Exit For
                End If

                Dim bt As New Button

                bt.Visible = True
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.LightSeaGreen
                bt.Text = artdt.Rows(i).Item("name").ToString
                bt.Name = "art" & i
                bt.Tag = artdt.Rows(i)
                bt.TextAlign = ContentAlignment.BottomCenter
                Try
                    If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                    Else
                        Dim str As String = Form1.ImgPah & "\art" & artdt.Rows(i).Item("img").ToString
                      
                        bt.BackgroundImage = Image.FromFile(str)
                    End If
                    bt.BackgroundImageLayout = ImageLayout.Stretch
                    bt.ImageAlign = ContentAlignment.BottomCenter
                Catch ex As Exception
                    bt.Text = artdt.Rows(i).Item("name").ToString
                End Try
                bt.Width = Form1.pvLongerbt
                bt.Height = Form1.pvLargebt
                PvL.FL.Controls.Add(bt)

                ''''''''''''''''''''''''''''''' GO FORWORD
                If i = Form1.indexStartArticle + Form1.numberOfItems Then

                    AddHandler bt.Click, AddressOf ctg_NEXT
                    bt.BackColor = Color.Green
                    bt.Text = "[...]"
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.BackgroundImage = Nothing
                    bt.Tag = bt2.Tag
                    Form1.indexStartArticle += Form1.numberOfItems
                    Exit For
                Else
                    AddHandler bt.Click, AddressOf art_click
                End If
            Next

          

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ctg_BACK(ByVal sender As System.Object, ByVal e As EventArgs)
        Try
            Dim bt2 As Button = sender
            PvL.FL.Controls.Clear()
            Dim artdt = bt2.Tag

            Dim s As Integer = Form1.indexStartArticle
            Dim l As Integer = Form1.numberOfItems
            '''''''''''''''''''''''''''''''''''' go back
            If s > l Then

                Dim btBACK As New Button
                btBACK.Visible = True
                btBACK.FlatStyle = FlatStyle.Flat
                btBACK.BackColor = Color.Green
                btBACK.Text = "[...]"
                btBACK.Tag = bt2.Tag
                'btBACK.TextAlign = ContentAlignment.BottomCenter
                btBACK.Width = Form1.pvLongerbt
                btBACK.Height = Form1.pvLargebt
                PvL.FL.Controls.Add(btBACK)
                AddHandler btBACK.Click, AddressOf ctg_BACK
            End If

            ''''''''''''''''''''''''''''''''''''
            s -= l * 2
            If s < 0 Then s = 0

            Dim _END As Integer = s + l
            For i As Integer = s To _END

                If i = artdt.Rows.Count Then
                    Form1.indexStartArticle = i '- Form1.indexLastArticle
                    Exit For
                End If

                Dim bt As New Button

                bt.Visible = True
                bt.FlatStyle = FlatStyle.Flat
                bt.BackColor = Color.LightSeaGreen
                bt.Text = artdt.Rows(i).Item("name").ToString
                bt.Name = "art" & i
                bt.Tag = artdt.Rows(i)
                bt.TextAlign = ContentAlignment.BottomCenter
                Try
                    If artdt.Rows(i).Item("img").ToString = "No Image" Or artdt.Rows(i).Item("img").ToString = "" Then

                    Else
                        Dim str As String = Form1.ImgPah & "\art" & artdt.Rows(i).Item("img").ToString
                      

                        bt.BackgroundImage = Image.FromFile(str)
                    End If
                    bt.BackgroundImageLayout = ImageLayout.Stretch
                    bt.ImageAlign = ContentAlignment.BottomCenter
                Catch ex As Exception
                    bt.Text = artdt.Rows(i).Item("name").ToString
                End Try
                bt.Width = Form1.pvLongerbt
                bt.Height = Form1.pvLargebt
                PvL.FL.Controls.Add(bt)

                ''''''''''''''''''''''''''''''' GO FORWORD
                If i = _END Then

                    AddHandler bt.Click, AddressOf ctg_NEXT
                    bt.BackColor = Color.Green
                    bt.Text = "[...]"
                    bt.TextAlign = ContentAlignment.MiddleCenter
                    bt.BackgroundImage = Nothing
                    bt.Tag = bt2.Tag
                    Form1.indexStartArticle = _END

                    Exit For
                Else
                    AddHandler bt.Click, AddressOf art_click
                End If
            Next

          

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub art_click(ByVal sender As Object, ByVal e As EventArgs)
        Dim bt As Button = sender
        Dim R As ALMohassinDBDataSet.ArticleRow = bt.Tag
        If PvL.localName = "" Then

        Else
            PvL.RPL.AddItem(R)
        End If
        PvL.KeepTxtFocus()
    End Sub

    'bons
    Private Sub SelectBon(ByRef ds As PvList, ByVal localname As Object)
        ds.lbName.Text = "-"
        ds.cleardetails()

        Dim g As New PvModel
        g = ReadFromXmlFile(Of PvModel)(Form1.ImgPah & "\Prt_Pv\" & localname)
        ds.localName = g.localName

        ds.RPL.myClient = New Client(g.ClientId, ds.tb_C)
        ds.RPL.myDate = CDate(g.bonDate)
        ds.lbName.Text = ds.RPL.myClient.name

        ds.RPL.AddItems(g.DataSource)

        Dim rnd As New Random
        For Each b As pvOpenBon_item In ds.PL.Controls
            If CStr(b.localName) = localname Then
                b.myColor = Color.White

            Else
                b.myColor = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)) 'Color.DarkSlateGray
            End If
        Next

        ds.PL.Visible = False

        PvL.KeepTxtFocus()
    End Sub

End Class
