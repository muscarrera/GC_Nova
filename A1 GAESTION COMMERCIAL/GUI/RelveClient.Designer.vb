<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RelveClient
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btPrint = New System.Windows.Forms.Button()
        Me.lbClient = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbRest = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbRestBonFactur = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbrestFact = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbrestBon = New System.Windows.Forms.Label()
        Me.plReserve = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbTreserve = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbAvoir = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lb_PorteMonie = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PrintDoc = New System.Drawing.Printing.PrintDocument()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.plReserve.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btPrint)
        Me.Panel1.Controls.Add(Me.lbClient)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(736, 64)
        Me.Panel1.TabIndex = 0
        '
        'btPrint
        '
        Me.btPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPrint.BackColor = System.Drawing.Color.Transparent
        Me.btPrint.FlatAppearance.BorderSize = 0
        Me.btPrint.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPrint.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.PRINT_18
        Me.btPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btPrint.Location = New System.Drawing.Point(621, 18)
        Me.btPrint.Name = "btPrint"
        Me.btPrint.Size = New System.Drawing.Size(103, 32)
        Me.btPrint.TabIndex = 5
        Me.btPrint.Text = "Imprimer"
        Me.btPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btPrint.UseVisualStyleBackColor = False
        '
        'lbClient
        '
        Me.lbClient.AutoSize = True
        Me.lbClient.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClient.ForeColor = System.Drawing.Color.Red
        Me.lbClient.Location = New System.Drawing.Point(42, 19)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(24, 24)
        Me.lbClient.TabIndex = 0
        Me.lbClient.Text = "--"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.plReserve)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 393)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(736, 202)
        Me.Panel2.TabIndex = 0
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.LightGreen
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Label4)
        Me.Panel8.Controls.Add(Me.lbRest)
        Me.Panel8.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel8.Location = New System.Drawing.Point(27, 141)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(676, 50)
        Me.Panel8.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(16, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 12)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Total"
        '
        'lbRest
        '
        Me.lbRest.AutoSize = True
        Me.lbRest.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRest.ForeColor = System.Drawing.Color.Green
        Me.lbRest.Location = New System.Drawing.Point(101, 11)
        Me.lbRest.Name = "lbRest"
        Me.lbRest.Size = New System.Drawing.Size(22, 24)
        Me.lbRest.TabIndex = 0
        Me.lbRest.Text = "0"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.lbrestFact)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.lbrestBon)
        Me.Panel6.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Panel6.Location = New System.Drawing.Point(26, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(317, 129)
        Me.Panel6.TabIndex = 16
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel7.Controls.Add(Me.Label8)
        Me.Panel7.Controls.Add(Me.lbRestBonFactur)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 75)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(315, 52)
        Me.Panel7.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(4, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 12)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Total"
        '
        'lbRestBonFactur
        '
        Me.lbRestBonFactur.AutoSize = True
        Me.lbRestBonFactur.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRestBonFactur.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbRestBonFactur.Location = New System.Drawing.Point(52, 11)
        Me.lbRestBonFactur.Name = "lbRestBonFactur"
        Me.lbRestBonFactur.Size = New System.Drawing.Size(22, 24)
        Me.lbRestBonFactur.TabIndex = 12
        Me.lbRestBonFactur.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(11, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rest Sur les Factures"
        '
        'lbrestFact
        '
        Me.lbrestFact.AutoSize = True
        Me.lbrestFact.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbrestFact.ForeColor = System.Drawing.Color.Red
        Me.lbrestFact.Location = New System.Drawing.Point(170, 0)
        Me.lbrestFact.Name = "lbrestFact"
        Me.lbrestFact.Size = New System.Drawing.Size(22, 24)
        Me.lbrestFact.TabIndex = 0
        Me.lbrestFact.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(11, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Rest Sur les Bons"
        '
        'lbrestBon
        '
        Me.lbrestBon.AutoSize = True
        Me.lbrestBon.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbrestBon.ForeColor = System.Drawing.Color.Blue
        Me.lbrestBon.Location = New System.Drawing.Point(170, 32)
        Me.lbrestBon.Name = "lbrestBon"
        Me.lbrestBon.Size = New System.Drawing.Size(22, 24)
        Me.lbrestBon.TabIndex = 0
        Me.lbrestBon.Text = "0"
        '
        'plReserve
        '
        Me.plReserve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plReserve.Controls.Add(Me.Panel5)
        Me.plReserve.Controls.Add(Me.Label5)
        Me.plReserve.Controls.Add(Me.lbAvoir)
        Me.plReserve.Controls.Add(Me.Label2)
        Me.plReserve.Controls.Add(Me.lb_PorteMonie)
        Me.plReserve.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.plReserve.Location = New System.Drawing.Point(386, 6)
        Me.plReserve.Name = "plReserve"
        Me.plReserve.Size = New System.Drawing.Size(317, 129)
        Me.plReserve.TabIndex = 16
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Controls.Add(Me.lbTreserve)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 75)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(315, 52)
        Me.Panel5.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(4, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 12)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Total"
        '
        'lbTreserve
        '
        Me.lbTreserve.AutoSize = True
        Me.lbTreserve.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTreserve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbTreserve.Location = New System.Drawing.Point(52, 11)
        Me.lbTreserve.Name = "lbTreserve"
        Me.lbTreserve.Size = New System.Drawing.Size(22, 24)
        Me.lbTreserve.TabIndex = 12
        Me.lbTreserve.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "porte-monnaie"
        '
        'lbAvoir
        '
        Me.lbAvoir.AutoSize = True
        Me.lbAvoir.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAvoir.Location = New System.Drawing.Point(189, 40)
        Me.lbAvoir.Name = "lbAvoir"
        Me.lbAvoir.Size = New System.Drawing.Size(22, 24)
        Me.lbAvoir.TabIndex = 11
        Me.lbAvoir.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(190, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Avoir"
        Me.Label2.Visible = False
        '
        'lb_PorteMonie
        '
        Me.lb_PorteMonie.AutoSize = True
        Me.lb_PorteMonie.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_PorteMonie.Location = New System.Drawing.Point(2, 40)
        Me.lb_PorteMonie.Name = "lb_PorteMonie"
        Me.lb_PorteMonie.Size = New System.Drawing.Size(22, 24)
        Me.lb_PorteMonie.TabIndex = 12
        Me.lb_PorteMonie.Text = "0"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 64)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(736, 329)
        Me.Panel3.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(11)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(2)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 36
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(736, 329)
        Me.DataGridView1.TabIndex = 0
        '
        'PrintDoc
        '
        '
        'Column1
        '
        Me.Column1.HeaderText = "Date"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Type"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Sortie"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Entrée"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "N°"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'RelveClient
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 595)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RelveClient"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Relvé Client"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.plReserve.ResumeLayout(False)
        Me.plReserve.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents lbClient As System.Windows.Forms.Label
    Friend WithEvents lbrestFact As System.Windows.Forms.Label
    Friend WithEvents PrintDoc As System.Drawing.Printing.PrintDocument
    Friend WithEvents btPrint As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbrestBon As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbRest As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbRestBonFactur As System.Windows.Forms.Label
    Friend WithEvents plReserve As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbTreserve As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbAvoir As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lb_PorteMonie As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
