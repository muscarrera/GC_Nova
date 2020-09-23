<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RPanel
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
        Me.Pl = New System.Windows.Forms.Panel()
        Me.PlTop = New System.Windows.Forms.Panel()
        Me.PlHeader = New System.Windows.Forms.Panel()
        Me.lbProfit = New System.Windows.Forms.Label()
        Me.lbremise = New System.Windows.Forms.Label()
        Me.lbHT = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LbVidal = New System.Windows.Forms.Label()
        Me.LbTva = New System.Windows.Forms.Label()
        Me.Lbavc = New System.Windows.Forms.Label()
        Me.LbSum = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.CP = New A1_GAESTION_COMMERCIAL.CPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pl
        '
        Me.Pl.AutoScroll = True
        Me.Pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pl.Location = New System.Drawing.Point(0, 10)
        Me.Pl.Name = "Pl"
        Me.Pl.Size = New System.Drawing.Size(385, 229)
        Me.Pl.TabIndex = 6
        '
        'PlTop
        '
        Me.PlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PlTop.Location = New System.Drawing.Point(0, 0)
        Me.PlTop.Name = "PlTop"
        Me.PlTop.Size = New System.Drawing.Size(385, 10)
        Me.PlTop.TabIndex = 4
        '
        'PlHeader
        '
        Me.PlHeader.Controls.Add(Me.lbProfit)
        Me.PlHeader.Controls.Add(Me.lbremise)
        Me.PlHeader.Controls.Add(Me.lbHT)
        Me.PlHeader.Controls.Add(Me.Label2)
        Me.PlHeader.Controls.Add(Me.Label1)
        Me.PlHeader.Controls.Add(Me.LbVidal)
        Me.PlHeader.Controls.Add(Me.LbTva)
        Me.PlHeader.Controls.Add(Me.Lbavc)
        Me.PlHeader.Controls.Add(Me.LbSum)
        Me.PlHeader.Controls.Add(Me.ShapeContainer1)
        Me.PlHeader.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlHeader.Location = New System.Drawing.Point(0, 239)
        Me.PlHeader.Name = "PlHeader"
        Me.PlHeader.Size = New System.Drawing.Size(385, 55)
        Me.PlHeader.TabIndex = 3
        '
        'lbProfit
        '
        Me.lbProfit.AutoSize = True
        Me.lbProfit.Location = New System.Drawing.Point(15, 12)
        Me.lbProfit.Name = "lbProfit"
        Me.lbProfit.Size = New System.Drawing.Size(13, 13)
        Me.lbProfit.TabIndex = 2
        Me.lbProfit.Text = "[]"
        Me.lbProfit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lbProfit.Visible = False
        '
        'lbremise
        '
        Me.lbremise.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbremise.AutoSize = True
        Me.lbremise.Location = New System.Drawing.Point(251, 34)
        Me.lbremise.Name = "lbremise"
        Me.lbremise.Size = New System.Drawing.Size(63, 13)
        Me.lbremise.TabIndex = 1
        Me.lbremise.Text = "Remise =  0"
        Me.lbremise.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbHT
        '
        Me.lbHT.AutoSize = True
        Me.lbHT.Location = New System.Drawing.Point(75, 94)
        Me.lbHT.Name = "lbHT"
        Me.lbHT.Size = New System.Drawing.Size(47, 13)
        Me.lbHT.TabIndex = 1
        Me.lbHT.Text = "T HT : 0"
        Me.lbHT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbHT.Visible = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(211, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "T. TTC :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Avance :"
        '
        'LbVidal
        '
        Me.LbVidal.AutoSize = True
        Me.LbVidal.Location = New System.Drawing.Point(181, 34)
        Me.LbVidal.Name = "LbVidal"
        Me.LbVidal.Size = New System.Drawing.Size(45, 13)
        Me.LbVidal.TabIndex = 2
        Me.LbVidal.Text = "0 - Vidal"
        Me.LbVidal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbTva
        '
        Me.LbTva.AutoSize = True
        Me.LbTva.Location = New System.Drawing.Point(11, 103)
        Me.LbTva.Name = "LbTva"
        Me.LbTva.Size = New System.Drawing.Size(49, 13)
        Me.LbTva.TabIndex = 1
        Me.LbTva.Text = "Tva : 0%"
        Me.LbTva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LbTva.Visible = False
        '
        'Lbavc
        '
        Me.Lbavc.AutoSize = True
        Me.Lbavc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbavc.Location = New System.Drawing.Point(93, 31)
        Me.Lbavc.Name = "Lbavc"
        Me.Lbavc.Size = New System.Drawing.Size(17, 18)
        Me.Lbavc.TabIndex = 1
        Me.Lbavc.Text = "0"
        '
        'LbSum
        '
        Me.LbSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LbSum.AutoSize = True
        Me.LbSum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbSum.ForeColor = System.Drawing.Color.Red
        Me.LbSum.Location = New System.Drawing.Point(284, 10)
        Me.LbSum.Name = "LbSum"
        Me.LbSum.Size = New System.Drawing.Size(54, 20)
        Me.LbSum.TabIndex = 1
        Me.LbSum.Text = "00.00"
        Me.LbSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(385, 55)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 211
        Me.LineShape1.X2 = 386
        Me.LineShape1.Y1 = 9
        Me.LineShape1.Y2 = 9
        '
        'CP
        '
        Me.CP.BackColor = System.Drawing.Color.Transparent
        Me.CP.bl = "---"
        Me.CP.Depot = 0
        Me.CP.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CP.EditMode = False
        Me.CP.hasRemise = False
        Me.CP.Location = New System.Drawing.Point(0, 304)
        Me.CP.Name = "CP"
        Me.CP.Size = New System.Drawing.Size(385, 259)
        Me.CP.TabIndex = 7
        Me.CP.Value = 1.0R
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 294)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(385, 10)
        Me.Panel1.TabIndex = 5
        '
        'RPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Pl)
        Me.Controls.Add(Me.PlTop)
        Me.Controls.Add(Me.PlHeader)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CP)
        Me.Name = "RPanel"
        Me.Size = New System.Drawing.Size(385, 563)
        Me.PlHeader.ResumeLayout(False)
        Me.PlHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pl As System.Windows.Forms.Panel
    Friend WithEvents PlTop As System.Windows.Forms.Panel
    Friend WithEvents PlHeader As System.Windows.Forms.Panel
    Friend WithEvents lbProfit As System.Windows.Forms.Label
    Friend WithEvents lbremise As System.Windows.Forms.Label
    Friend WithEvents lbHT As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LbVidal As System.Windows.Forms.Label
    Friend WithEvents LbTva As System.Windows.Forms.Label
    Friend WithEvents Lbavc As System.Windows.Forms.Label
    Friend WithEvents LbSum As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents CP As A1_GAESTION_COMMERCIAL.CPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
