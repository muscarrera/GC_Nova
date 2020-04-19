Imports System.Windows.Forms.DataVisualization.Charting

Public Class HomeClass
    Implements IDisposable


    Public Sub AddDataList()
        If Form1.plBody.Controls.Count > 0 Then
            If TypeOf Form1.plBody.Controls(0) Is App_Home Then
                Dim _ds As App_Home = Form1.plBody.Controls(0)
                LoadHomePage(_ds)
                Exit Sub
            End If
        End If
        Form1.plBody.Controls.Clear()




        Dim ds As New App_Home
        ds.Dock = DockStyle.Fill
        AddHandler ds.LoadHome, AddressOf LoadHomePage



        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Mission", {"*"})


        End Using
        Form1.plBody.Controls.Add(ds)
    End Sub

    Private Sub LoadHomePage(ByRef ds As App_Home)

        Dim dte2 As Date = Now.Date.AddMonths(-1)

        Dim BTA As New ALMohassinDBDataSetTableAdapters.HomeTableAdapter
        Dim dt = BTA.GetDataBA(dte2)

        Dim ac As New AppChart
        ac.ch.Series.Clear()
        ac.Title = "Nbres d'Operation"

        CreateSerie(ac.ch, 0, "BA", "date", "Nbr", "Bon d'Achat", dt)

        dt = BTA.GetDataBL(dte2)
        CreateSerie(ac.ch, 1, "Bl", "date", "Nbr", "Bon de Livraison", dt)

        dt = BTA.GetDataBF(dte2)
        CreateSerie(ac.ch, 2, "BF", "date", "Nbr", "Facture d'Achat", dt)

        dt = BTA.GetDataSF(dte2)
        CreateSerie(ac.ch, 3, "SF", "date", "Nbr", "Facture des Ventes", dt)

        '

        'For z As Integer = 0 To ac.ch.Series.Count - 1
        '    ac.ch.Series(z).ChartType = DataVisualization.Charting.SeriesChartType.Spline
        'Next

        ac.Chart1.Visible = False
        ac.Chart2.Visible = False

        ac.Dock = DockStyle.Top


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim acc As New AppChart
        acc.ch.Series.Clear()
        acc.Chart1.Series.Clear()
        acc.Chart2.Series.Clear()
        acc.Title = "Mode de payement"

        dt = BTA.GetDataTotalAchat(dte2)
        CreateSerie(acc.Chart1, 0, "tA", "date", "total", "Total d'Achat", dt)

        dt = BTA.GetDataCompanyPayement(dte2)
        CreateSerie(acc.Chart1, 1, "pA", "date", "total", "Payement d'Achat", dt)

        dt = BTA.GetDataTotalVente(dte2)
        CreateSerie(acc.Chart2, 0, "tv", "date", "total", "Total de ventes", dt)

        dt = BTA.GetDataClientPayement(dte2)
        CreateSerie(acc.Chart2, 1, "pv", "date", "total", "Payement des ventes", dt)

        dt = BTA.GetDataByPayement(dte2)
        CreateSerie(acc.ch, 0, "pv", "way", "total", "types de reglements", dt)

        For z As Integer = 0 To acc.Chart1.Series.Count - 1
            acc.Chart1.Series(z).ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
        Next
        For z As Integer = 0 To acc.Chart2.Series.Count - 1
            acc.Chart2.Series(z).ChartType = DataVisualization.Charting.SeriesChartType.StackedColumn
        Next

        acc.ch.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Pie


        acc.Dock = DockStyle.Top
        ds.PL.Controls.Add(acc)
        ds.PL.Controls.Add(ac)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''




    End Sub

    Private Sub CreateSerie(ByRef ch As Chart, ByVal i As Integer,
                            ByVal nm As String, ByVal xn As String, ByVal yn As String, ByVal title As String, ByVal dt As DataTable)
        ch.Series.Add(nm)
        ch.Series(i).LegendText = title
        ch.Series(i).XValueMember = xn
        ch.Series(i).YValueMembers = yn
        ch.Series(i).XValueType = DataVisualization.Charting.ChartValueType.Date
        ch.Series(i).YValueType = DataVisualization.Charting.ChartValueType.Double
        'ac.ch.Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Spline

        For z As Integer = 0 To dt.Rows.Count - 1
            ch.Series(i).Points.AddXY(dt.Rows(z).Item(xn), dt.Rows(z).Item(yn))
        Next



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
