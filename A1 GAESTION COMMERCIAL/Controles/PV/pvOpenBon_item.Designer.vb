<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pvOpenBon_item
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
        Me.RC = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.BT = New System.Windows.Forms.Button()
        Me.LB = New System.Windows.Forms.Label()
        Me.PL = New System.Windows.Forms.Panel()
        Me.PL.SuspendLayout()
        Me.SuspendLayout()
        '
        'RC
        '
        Me.RC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RC.BackColor = System.Drawing.Color.LightSeaGreen
        Me.RC.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RC.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RC.CornerRadius = 14
        Me.RC.Location = New System.Drawing.Point(0, 5)
        Me.RC.Name = "RC"
        Me.RC.Size = New System.Drawing.Size(191, 31)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RC})
        Me.ShapeContainer1.Size = New System.Drawing.Size(195, 40)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'BT
        '
        Me.BT.BackColor = System.Drawing.Color.DimGray
        Me.BT.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.BT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BT.Dock = System.Windows.Forms.DockStyle.Right
        Me.BT.FlatAppearance.BorderSize = 0
        Me.BT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BT.Location = New System.Drawing.Point(154, 0)
        Me.BT.Name = "BT"
        Me.BT.Size = New System.Drawing.Size(23, 24)
        Me.BT.TabIndex = 1
        Me.BT.UseVisualStyleBackColor = False
        '
        'LB
        '
        Me.LB.BackColor = System.Drawing.Color.White
        Me.LB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LB.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LB.Location = New System.Drawing.Point(0, 0)
        Me.LB.Name = "LB"
        Me.LB.Size = New System.Drawing.Size(154, 24)
        Me.LB.TabIndex = 2
        Me.LB.Text = "Label1"
        Me.LB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PL
        '
        Me.PL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PL.Controls.Add(Me.LB)
        Me.PL.Controls.Add(Me.BT)
        Me.PL.Location = New System.Drawing.Point(9, 9)
        Me.PL.Name = "PL"
        Me.PL.Size = New System.Drawing.Size(177, 24)
        Me.PL.TabIndex = 3
        '
        'pvOpenBon_item
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PL)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "pvOpenBon_item"
        Me.Size = New System.Drawing.Size(195, 40)
        Me.PL.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RC As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents BT As System.Windows.Forms.Button
    Friend WithEvents LB As System.Windows.Forms.Label
    Friend WithEvents PL As System.Windows.Forms.Panel

End Class
