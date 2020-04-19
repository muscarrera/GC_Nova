<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AppChart
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title3 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.ch = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.ch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ch
        '
        Me.ch.BorderlineColor = System.Drawing.Color.DarkGray
        Me.ch.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.ch.BorderSkin.BackColor = System.Drawing.Color.White
        ChartArea1.Name = "ChartArea1"
        Me.ch.ChartAreas.Add(ChartArea1)
        Me.ch.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.BackColor = System.Drawing.Color.Transparent
        Legend1.Name = "Legend1"
        Me.ch.Legends.Add(Legend1)
        Me.ch.Location = New System.Drawing.Point(658, 10)
        Me.ch.Name = "ch"
        Me.ch.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ch.Series.Add(Series1)
        Me.ch.Size = New System.Drawing.Size(301, 277)
        Me.ch.TabIndex = 0
        Me.ch.Text = "Chart1"
        Title1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!)
        Title1.ForeColor = System.Drawing.Color.Teal
        Title1.Name = "Title1"
        Title1.Text = "Reglements Client "
        Me.ch.Titles.Add(Title1)
        '
        'Chart1
        '
        Me.Chart1.BorderlineColor = System.Drawing.Color.DarkGray
        Me.Chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart1.BorderSkin.BackColor = System.Drawing.Color.White
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Left
        Legend2.BackColor = System.Drawing.Color.Transparent
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(10, 10)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(315, 277)
        Me.Chart1.TabIndex = 1
        Me.Chart1.Text = "Chart1"
        Title2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!)
        Title2.ForeColor = System.Drawing.Color.Teal
        Title2.Name = "Title1"
        Title2.Text = "Achats"
        Me.Chart1.Titles.Add(Title2)
        '
        'Chart2
        '
        Me.Chart2.BorderlineColor = System.Drawing.Color.DarkGray
        Me.Chart2.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart2.BorderSkin.BackColor = System.Drawing.Color.White
        ChartArea3.Name = "ChartArea1"
        ChartArea3.ShadowColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        ChartArea3.ShadowOffset = 3
        Me.Chart2.ChartAreas.Add(ChartArea3)
        Me.Chart2.Dock = System.Windows.Forms.DockStyle.Left
        Legend3.BackColor = System.Drawing.Color.Transparent
        Legend3.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend3)
        Me.Chart2.Location = New System.Drawing.Point(335, 10)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Size = New System.Drawing.Size(313, 277)
        Me.Chart2.TabIndex = 2
        Me.Chart2.Text = "Chart1"
        Title3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!)
        Title3.ForeColor = System.Drawing.Color.Teal
        Title3.Name = "Title1"
        Title3.Text = "Ventes"
        Me.Chart2.Titles.Add(Title3)
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(325, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 277)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(648, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 277)
        Me.Panel2.TabIndex = 4
        '
        'AppChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ch)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "AppChart"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Size = New System.Drawing.Size(969, 297)
        CType(Me.ch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ch As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
