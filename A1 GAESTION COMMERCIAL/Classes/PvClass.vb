﻿Public Class PvClass
    Implements IDisposable


    Public Sub New()

    End Sub

    Public Sub AddDataList()

        If Form1.plBody.Controls.Count > 0 Then
            If TypeOf Form1.plBody.Controls(0) Is PvList Then
                Dim dls As PvList = Form1.plBody.Controls(0)
                Exit Sub
            End If
        End If

        Form1.plBody.Controls.Clear()

        Dim ds As New PvList
         
        ds.Dock = DockStyle.Fill
        AddHandler ds.txtSearchRef_Changed, AddressOf txtSearchRef_Changed
        AddHandler ds.txtSearchRef_KeyPress, AddressOf txtSearchRef_KeyPress
        AddHandler ds.txtSearchCodebar_KeyPress, AddressOf txtSearchCodebar_KeyPress

        '
        ds.numberOpenBons = 0
        ds.modeSearch_isCode = False

        Form1.plBody.Controls.Add(ds)

        ds.KeepTxtFocus()

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
    Private Sub art_click(ByVal sender As Object, ByVal e As EventArgs)
        Throw New NotImplementedException
    End Sub

End Class
