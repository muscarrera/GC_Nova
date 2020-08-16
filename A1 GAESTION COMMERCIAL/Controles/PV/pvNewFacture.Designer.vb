<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pvNewFacture
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
        Me.OvalShape1 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.OvalShape2 = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OvalShape1
        '
        Me.OvalShape1.BackColor = System.Drawing.Color.Turquoise
        Me.OvalShape1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_User_27887
        Me.OvalShape1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OvalShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.OvalShape1.Location = New System.Drawing.Point(71, 9)
        Me.OvalShape1.Name = "OvalShape1"
        Me.OvalShape1.Size = New System.Drawing.Size(140, 140)
        '
        'OvalShape2
        '
        Me.OvalShape2.BackColor = System.Drawing.Color.Magenta
        Me.OvalShape2.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Document_write_icon_88543
        Me.OvalShape2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.OvalShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.OvalShape2.Cursor = System.Windows.Forms.Cursors.Default
        Me.OvalShape2.Location = New System.Drawing.Point(70, 9)
        Me.OvalShape2.Name = "OvalShape1"
        Me.OvalShape2.Size = New System.Drawing.Size(140, 140)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(22, 11, 22, 11)
        Me.Panel1.Size = New System.Drawing.Size(639, 230)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightCyan
        Me.Panel3.Controls.Add(Me.ShapeContainer3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(326, 11)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(291, 208)
        Me.Panel3.TabIndex = 2
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape1})
        Me.ShapeContainer3.Size = New System.Drawing.Size(291, 154)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.AliceBlue
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.DarkCyan
        Me.Button2.Location = New System.Drawing.Point(0, 154)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(291, 54)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Client Enregistrer"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightPink
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(22, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(301, 208)
        Me.Panel2.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.MediumVioletRed
        Me.Button1.Location = New System.Drawing.Point(0, 154)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(301, 54)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Client Normal"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.OvalShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(301, 208)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'pvNewFacture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 230)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "pvNewFacture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nouveau"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OvalShape1 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents OvalShape2 As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
End Class
