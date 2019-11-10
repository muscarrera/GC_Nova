Public Class FactureClass
    Implements IDisposable

    Public Sub NewFacture(ByVal tb_F As String, ByVal tb_C As String, ByRef ds As DataList)
        Try

            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.txtName.AutoCompleteSource = AutoCompleteByName(tb_C)
            NF.tb_C = tb_C
            NF.TxtDate.Text = Now.Date.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then
                Dim cn As String = NF.txtName.text
                Dim cid As String = 0

                Try
                    cn = NF.txtName.text.Split("|")(0)
                    cid = NF.txtName.text.Split("|")(1)
                Catch ex As Exception
                    cid = 0
                End Try

                NewFacture(tb_F, cid, cn, ds)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub NewFacture(ByVal tb_F As String, ByVal clid As String, ByVal cn As String, ByRef ds As DataList)
        Try
            Dim cid As String = clid
            Dim clientname As String = cn
            Dim fid As Integer = 0
            Dim dte As Date = Now.Date

            'If cid <> 0 And tp <> 0 Then
            '    If tp = "" Then tp = "1"
            '    If CheckForUnpaidFacture(cid, tp) = False Then Exit Sub
            'End If

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("cid", cid)
                params.Add("name", clientname)
                params.Add("total", 0)
                params.Add("avance", 0)
                params.Add("remise", 0)
                params.Add("tva", 0)
                params.Add("date", Format(dte, "dd-MM-yyyy"))
                params.Add("writer", CStr(Form1.adminName))
                params.Add("isAdmin", "CREATION")
                params.Add("isPayed", False)
                params.Add("modePayement", "-")
                params.Add("bl", "-")
                params.Add("droitTimbre", 0)
                fid = c.InsertRecord(tb_F, params, True)
            End Using

            If fid > 0 Then
                'ds.Clear()
                ds.Mode = "DETAILS"
                ds.Id = fid
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub NewRowAdded(ByVal id As Integer, ByVal tb_D As String, ByVal R As ListRow, ByRef d_Id As Integer)

        Try

            'Dim dpt As Integer = Form1.RPl.CP.Depot
            'If Form1.CbDepotOrigine.Checked Then dpt = R.depot

            Dim arid As Integer = 0

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim params As New Dictionary(Of String, Object)
                params.Add("fctid", id)
                params.Add("name", R.ArticleName)
                params.Add("bprice", R.bprice)
                params.Add("price", R.sprice)
                params.Add("remise", R.remise)
                params.Add("qte", R.qte)
                params.Add("tva", R.TVA)
                params.Add("arid", R.arid)
                params.Add("depot", R.depot)
                params.Add("ref", R.ref)
                params.Add("cid", R.cid)

                d_Id = c.InsertRecord(tb_D, params, True)
            End Using
        Catch ex As Exception
        End Try

    End Sub
    Public Sub GetFactureDetails(ByVal id As Integer, ByRef ds As DataList)
        Try
            ds.Facture = New Facture(id, ds.FactureTable, ds.clientTable, ds.DetailsTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchById(ByVal id As Integer, ByRef ds As DataList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing


            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add("id Like ", "%" & id & "%")
                dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
            End Using

            If dt.Rows.Count > 0 Then
                ds.Clear()
                ds.Mode = "LIST"
                Dim arr As New ListLine

                arr.Id = dt.Rows(0).Item(0)
               
                arr.Libele = StrValue(dt, "name", 0)
                arr.Total = DblValue(dt, "total", 0)
                arr.Avance = DblValue(dt, "avance", 0)
                arr.remise = DblValue(dt, "remise", 0)

                arr.Dock = DockStyle.Top
                arr.BringToFront()

                ds.Pl.Controls.Add(arr)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByDate(ByRef ds As DataList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing


            Dim NF As New SearchArchive
            NF.txtName.AutoCompleteSource = AutoCompleteByName(ds.clientTable)

            If NF.ShowDialog = DialogResult.OK Then
                Dim dt1 As Date = Date.Parse(NF.dte2.Text).AddDays(1)
                Dim dt2 As Date = Date.Parse(NF.dte1.Text).AddDays(-1)
                If NF.txtName.text <> "" Then
                    If IsNumeric(NF.txtName.text) Then
                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            params.Add("fctid Like ", "%" & NF.txtName.text & "%")
                            dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                        End Using

                    ElseIf NF.txtName.text.Contains("|") Then
                        Dim str As String = NF.txtName.text.Trim
                        str = str.Split(CChar("|"))(1)
                        Dim clid As Integer = CInt(str)

                        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                            params.Add("cid = ", clid)
                            params.Add("[date] < ", dt1)
                            params.Add("[date] > ", dt2)
                            dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                        End Using
                    End If
                Else
                    Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                        params.Add("[date] < ", dt1)
                        params.Add("[date] > ", dt2)

                        dt = a.SelectDataTableSymbols(ds.FactureTable, {"*"}, params)
                    End Using
                End If

                If dt.Rows.Count > 0 Then
                    'Dim arr As New ListLine(dt.Rows.Count - 1)
                    ds.Clear()
                    ds.Mode = "LIST"



                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim arr As New ListLine
                        arr.Id = dt.Rows(i).Item(0)
                        arr.Libele = StrValue(dt, "name", i)
                        arr.Total = DblValue(dt, "total", i)
                        arr.Avance = DblValue(dt, "avance", i)
                        arr.remise = DblValue(dt, "remise", i)

                        arr.Dock = DockStyle.Top
                        arr.BringToFront()
                        ds.Pl.Controls.Add(arr)
                    Next

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub EditModePayement(ByRef ds As DataList)
        Try
            Dim mp As New ModePayement
            If mp.ShowDialog = DialogResult.OK Then
                ds.ModePayement = mp.mode
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub AddDataList(ByVal op As String)
        Form1.plBody.Controls.Clear()

        Dim ds As New DataList
        ds.Operation = op
        ds.Mode = "LIST"
        ds.Dock = DockStyle.Fill
        AddHandler ds.NewFacture, AddressOf NewFacture
        AddHandler ds.IdChanged, AddressOf GetFactureDetails
        AddHandler ds.NewRowAdded, AddressOf NewRowAdded
        AddHandler ds.SearchByDate, AddressOf SearchByDate
        AddHandler ds.SearchById, AddressOf SearchById
        AddHandler ds.EditModePayement, AddressOf EditModePayement

        Form1.plBody.Controls.Add(ds)
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
