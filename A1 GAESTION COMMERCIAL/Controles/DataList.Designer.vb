<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataList
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
        Me.plNewElement = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PlAdd = New System.Windows.Forms.Panel()
        Me.Pl = New System.Windows.Forms.Panel()
        Me.PlFooter = New System.Windows.Forms.Panel()
        Me.plL = New System.Windows.Forms.Panel()
        Me.plR = New System.Windows.Forms.Panel()
        Me.plTotal = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.plDetailsHeader = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lbQte = New System.Windows.Forms.Label()
        Me.plListHeader = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TotalBloc1 = New A1_GAESTION_COMMERCIAL.TotalBloc()
        Me.AddRow1 = New A1_GAESTION_COMMERCIAL.AddRow()
        Me.Entete = New A1_GAESTION_COMMERCIAL.EnteteFacture()
        Me.plNewElement.SuspendLayout()
        Me.PlAdd.SuspendLayout()
        Me.plTotal.SuspendLayout()
        Me.plDetailsHeader.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.plListHeader.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel13.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel16.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.SuspendLayout()
        '
        'plNewElement
        '
        Me.plNewElement.BackColor = System.Drawing.Color.White
        Me.plNewElement.Controls.Add(Me.LinkLabel1)
        Me.plNewElement.Dock = System.Windows.Forms.DockStyle.Top
        Me.plNewElement.Location = New System.Drawing.Point(105, 75)
        Me.plNewElement.Name = "plNewElement"
        Me.plNewElement.Padding = New System.Windows.Forms.Padding(5)
        Me.plNewElement.Size = New System.Drawing.Size(710, 27)
        Me.plNewElement.TabIndex = 5
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(8, 7)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(116, 15)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Ajouter un element"
        '
        'PlAdd
        '
        Me.PlAdd.BackColor = System.Drawing.Color.Gainsboro
        Me.PlAdd.Controls.Add(Me.AddRow1)
        Me.PlAdd.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlAdd.Location = New System.Drawing.Point(105, 170)
        Me.PlAdd.Name = "PlAdd"
        Me.PlAdd.Padding = New System.Windows.Forms.Padding(5)
        Me.PlAdd.Size = New System.Drawing.Size(710, 39)
        Me.PlAdd.TabIndex = 6
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.BackColor = System.Drawing.Color.White
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Top
        Me.Pl.Location = New System.Drawing.Point(105, 209)
        Me.Pl.Name = "Pl"
        Me.Pl.Padding = New System.Windows.Forms.Padding(5)
        Me.Pl.Size = New System.Drawing.Size(710, 104)
        Me.Pl.TabIndex = 7
        '
        'PlFooter
        '
        Me.PlFooter.BackColor = System.Drawing.Color.Gainsboro
        Me.PlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlFooter.Location = New System.Drawing.Point(105, 873)
        Me.PlFooter.Name = "PlFooter"
        Me.PlFooter.Padding = New System.Windows.Forms.Padding(5)
        Me.PlFooter.Size = New System.Drawing.Size(710, 27)
        Me.PlFooter.TabIndex = 8
        '
        'plL
        '
        Me.plL.BackColor = System.Drawing.Color.Transparent
        Me.plL.Dock = System.Windows.Forms.DockStyle.Left
        Me.plL.Location = New System.Drawing.Point(0, 0)
        Me.plL.Name = "plL"
        Me.plL.Padding = New System.Windows.Forms.Padding(5)
        Me.plL.Size = New System.Drawing.Size(105, 900)
        Me.plL.TabIndex = 10
        '
        'plR
        '
        Me.plR.BackColor = System.Drawing.Color.Transparent
        Me.plR.Dock = System.Windows.Forms.DockStyle.Right
        Me.plR.Location = New System.Drawing.Point(815, 0)
        Me.plR.Name = "plR"
        Me.plR.Padding = New System.Windows.Forms.Padding(5)
        Me.plR.Size = New System.Drawing.Size(105, 900)
        Me.plR.TabIndex = 11
        '
        'plTotal
        '
        Me.plTotal.AutoScroll = True
        Me.plTotal.BackColor = System.Drawing.Color.White
        Me.plTotal.Controls.Add(Me.TotalBloc1)
        Me.plTotal.Dock = System.Windows.Forms.DockStyle.Top
        Me.plTotal.Location = New System.Drawing.Point(105, 313)
        Me.plTotal.Name = "plTotal"
        Me.plTotal.Padding = New System.Windows.Forms.Padding(5)
        Me.plTotal.Size = New System.Drawing.Size(710, 164)
        Me.plTotal.TabIndex = 7
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(105, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel9.Size = New System.Drawing.Size(710, 27)
        Me.Panel9.TabIndex = 15
        '
        'plDetailsHeader
        '
        Me.plDetailsHeader.BackColor = System.Drawing.Color.White
        Me.plDetailsHeader.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.plDetailsHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plDetailsHeader.Controls.Add(Me.Panel6)
        Me.plDetailsHeader.Controls.Add(Me.Panel5)
        Me.plDetailsHeader.Controls.Add(Me.Panel4)
        Me.plDetailsHeader.Controls.Add(Me.Panel3)
        Me.plDetailsHeader.Controls.Add(Me.Panel2)
        Me.plDetailsHeader.Controls.Add(Me.Panel7)
        Me.plDetailsHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.plDetailsHeader.Location = New System.Drawing.Point(105, 136)
        Me.plDetailsHeader.Name = "plDetailsHeader"
        Me.plDetailsHeader.Padding = New System.Windows.Forms.Padding(25, 5, 100, 5)
        Me.plDetailsHeader.Size = New System.Drawing.Size(710, 34)
        Me.plDetailsHeader.TabIndex = 9
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(139, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel6.Size = New System.Drawing.Size(99, 24)
        Me.Panel6.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 24)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Designation"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(238, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel5.Size = New System.Drawing.Size(89, 24)
        Me.Panel5.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label2.Location = New System.Drawing.Point(5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Qte"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(327, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel4.Size = New System.Drawing.Size(90, 24)
        Me.Panel4.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label3.Location = New System.Drawing.Point(5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "PU"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(417, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel3.Size = New System.Drawing.Size(84, 24)
        Me.Panel3.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label4.Location = New System.Drawing.Point(5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Remise %"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(501, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel2.Size = New System.Drawing.Size(109, 24)
        Me.Panel2.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label5.Location = New System.Drawing.Point(5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 24)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Total"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.lbQte)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(25, 5)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel7.Size = New System.Drawing.Size(114, 24)
        Me.Panel7.TabIndex = 12
        '
        'lbQte
        '
        Me.lbQte.BackColor = System.Drawing.Color.Transparent
        Me.lbQte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbQte.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQte.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lbQte.Location = New System.Drawing.Point(5, 0)
        Me.lbQte.Name = "lbQte"
        Me.lbQte.Size = New System.Drawing.Size(104, 24)
        Me.lbQte.TabIndex = 1
        Me.lbQte.Text = "Réf"
        Me.lbQte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plListHeader
        '
        Me.plListHeader.BackColor = System.Drawing.Color.White
        Me.plListHeader.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.plListHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plListHeader.Controls.Add(Me.Panel12)
        Me.plListHeader.Controls.Add(Me.Panel13)
        Me.plListHeader.Controls.Add(Me.Panel14)
        Me.plListHeader.Controls.Add(Me.Panel15)
        Me.plListHeader.Controls.Add(Me.Panel16)
        Me.plListHeader.Controls.Add(Me.Panel17)
        Me.plListHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.plListHeader.Location = New System.Drawing.Point(105, 102)
        Me.plListHeader.Name = "plListHeader"
        Me.plListHeader.Padding = New System.Windows.Forms.Padding(25, 5, 100, 5)
        Me.plListHeader.Size = New System.Drawing.Size(710, 34)
        Me.plListHeader.TabIndex = 16
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Transparent
        Me.Panel12.Controls.Add(Me.Label6)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(139, 5)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel12.Size = New System.Drawing.Size(99, 24)
        Me.Panel12.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label6.Location = New System.Drawing.Point(5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 24)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Libellé"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Transparent
        Me.Panel13.Controls.Add(Me.Label7)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(238, 5)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel13.Size = New System.Drawing.Size(89, 24)
        Me.Panel13.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label7.Location = New System.Drawing.Point(5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 24)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Total"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Transparent
        Me.Panel14.Controls.Add(Me.Label8)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel14.Location = New System.Drawing.Point(327, 5)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel14.Size = New System.Drawing.Size(90, 24)
        Me.Panel14.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label8.Location = New System.Drawing.Point(5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 24)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Avance"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.Controls.Add(Me.Label9)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel15.Location = New System.Drawing.Point(417, 5)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel15.Size = New System.Drawing.Size(84, 24)
        Me.Panel15.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label9.Location = New System.Drawing.Point(5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 24)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Remise %"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.Controls.Add(Me.Label10)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel16.Location = New System.Drawing.Point(501, 5)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel16.Size = New System.Drawing.Size(109, 24)
        Me.Panel16.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label10.Location = New System.Drawing.Point(5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 24)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Tva"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.Transparent
        Me.Panel17.Controls.Add(Me.Label11)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel17.Location = New System.Drawing.Point(25, 5)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel17.Size = New System.Drawing.Size(114, 24)
        Me.Panel17.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label11.Location = New System.Drawing.Point(5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(104, 24)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Réf"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalBloc1
        '
        Me.TotalBloc1.avance = 0.0R
        Me.TotalBloc1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalBloc1.Location = New System.Drawing.Point(5, 5)
        Me.TotalBloc1.ModePayement = Nothing
        Me.TotalBloc1.Name = "TotalBloc1"
        Me.TotalBloc1.Remise = 0.0R
        Me.TotalBloc1.Size = New System.Drawing.Size(700, 154)
        Me.TotalBloc1.TabIndex = 0
        Me.TotalBloc1.TotalHt = 0.0R
        Me.TotalBloc1.TVA = 0.0R
        Me.TotalBloc1.Writer = "-"
        '
        'AddRow1
        '
        Me.AddRow1.AutoCompleteSourceName = Nothing
        Me.AddRow1.AutoCompleteSourceRef = Nothing
        Me.AddRow1.BackColor = System.Drawing.Color.Transparent
        Me.AddRow1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddRow1.Location = New System.Drawing.Point(5, 5)
        Me.AddRow1.Name = "AddRow1"
        Me.AddRow1.Padding = New System.Windows.Forms.Padding(2)
        Me.AddRow1.Size = New System.Drawing.Size(700, 29)
        Me.AddRow1.TabIndex = 0
        '
        'Entete
        '
        Me.Entete.BackColor = System.Drawing.Color.Transparent
        Me.Entete.Bc = "Devis"
        Me.Entete.Bl = "Devis"
        Me.Entete.Client = Nothing
        Me.Entete.ClientAdresse = ""
        Me.Entete.ClientName = ""
        Me.Entete.Devis = "Devis"
        Me.Entete.Dock = System.Windows.Forms.DockStyle.Top
        Me.Entete.FactureDate = New Date(CType(0, Long))
        Me.Entete.ICE = ""
        Me.Entete.Id = "0"
        Me.Entete.Location = New System.Drawing.Point(105, 27)
        Me.Entete.Name = "Entete"
        Me.Entete.Size = New System.Drawing.Size(710, 48)
        Me.Entete.Statut = ""
        Me.Entete.TabIndex = 0
        Me.Entete.Type = Nothing
        '
        'DataList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.plTotal)
        Me.Controls.Add(Me.Pl)
        Me.Controls.Add(Me.PlAdd)
        Me.Controls.Add(Me.plDetailsHeader)
        Me.Controls.Add(Me.PlFooter)
        Me.Controls.Add(Me.plListHeader)
        Me.Controls.Add(Me.plNewElement)
        Me.Controls.Add(Me.Entete)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.plL)
        Me.Controls.Add(Me.plR)
        Me.Name = "DataList"
        Me.Size = New System.Drawing.Size(920, 900)
        Me.plNewElement.ResumeLayout(False)
        Me.plNewElement.PerformLayout()
        Me.PlAdd.ResumeLayout(False)
        Me.plTotal.ResumeLayout(False)
        Me.plDetailsHeader.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.plListHeader.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel13.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plNewElement As System.Windows.Forms.Panel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents PlAdd As System.Windows.Forms.Panel
    Friend WithEvents AddRow1 As A1_GAESTION_COMMERCIAL.AddRow
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents PlFooter As System.Windows.Forms.Panel
    Friend WithEvents plDetailsHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbQte As System.Windows.Forms.Label
    Friend WithEvents plL As System.Windows.Forms.Panel
    Friend WithEvents plR As System.Windows.Forms.Panel
    Friend WithEvents plTotal As System.Windows.Forms.Panel
    Friend WithEvents TotalBloc1 As A1_GAESTION_COMMERCIAL.TotalBloc
    Friend WithEvents Entete As A1_GAESTION_COMMERCIAL.EnteteFacture
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents plListHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
