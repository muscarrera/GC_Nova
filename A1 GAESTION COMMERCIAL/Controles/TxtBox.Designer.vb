<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TxtBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TxtBox))
        Me.PO = New System.Windows.Forms.PictureBox()
        Me.PD = New System.Windows.Forms.PictureBox()
        Me.TXT = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RS = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.lbPlaceHolder = New System.Windows.Forms.Label()
        CType(Me.PO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PO
        '
        Me.PO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PO.BackColor = System.Drawing.Color.Transparent
        Me.PO.BackgroundImage = CType(resources.GetObject("PO.BackgroundImage"), System.Drawing.Image)
        Me.PO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PO.Location = New System.Drawing.Point(281, 9)
        Me.PO.Name = "PO"
        Me.PO.Size = New System.Drawing.Size(20, 39)
        Me.PO.TabIndex = 7
        Me.PO.TabStop = False
        Me.PO.Visible = False
        '
        'PD
        '
        Me.PD.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PD.BackColor = System.Drawing.Color.Transparent
        Me.PD.BackgroundImage = CType(resources.GetObject("PD.BackgroundImage"), System.Drawing.Image)
        Me.PD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PD.Location = New System.Drawing.Point(304, 7)
        Me.PD.Name = "PD"
        Me.PD.Size = New System.Drawing.Size(27, 36)
        Me.PD.TabIndex = 8
        Me.PD.TabStop = False
        Me.PD.Visible = False
        '
        'TXT
        '
        Me.TXT.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXT.Location = New System.Drawing.Point(11, 22)
        Me.TXT.Name = "TXT"
        Me.TXT.Size = New System.Drawing.Size(308, 13)
        Me.TXT.TabIndex = 6
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RS})
        Me.ShapeContainer1.Size = New System.Drawing.Size(333, 70)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'RS
        '
        Me.RS.BackColor = System.Drawing.Color.White
        Me.RS.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RS.CornerRadius = 5
        Me.RS.Location = New System.Drawing.Point(5, 1)
        Me.RS.Name = "RS"
        Me.RS.Size = New System.Drawing.Size(325, 45)
        '
        'lbPlaceHolder
        '
        Me.lbPlaceHolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbPlaceHolder.AutoSize = True
        Me.lbPlaceHolder.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPlaceHolder.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.lbPlaceHolder.Location = New System.Drawing.Point(18, 19)
        Me.lbPlaceHolder.Name = "lbPlaceHolder"
        Me.lbPlaceHolder.Size = New System.Drawing.Size(42, 15)
        Me.lbPlaceHolder.TabIndex = 10
        Me.lbPlaceHolder.Text = "Label1"
        Me.lbPlaceHolder.Visible = False
        '
        'TxtBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.lbPlaceHolder)
        Me.Controls.Add(Me.PD)
        Me.Controls.Add(Me.TXT)
        Me.Controls.Add(Me.PO)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "TxtBox"
        Me.Size = New System.Drawing.Size(333, 70)
        CType(Me.PO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PO As System.Windows.Forms.PictureBox
    Friend WithEvents PD As System.Windows.Forms.PictureBox
    Friend WithEvents TXT As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RS As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lbPlaceHolder As System.Windows.Forms.Label

End Class
