<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayementForm
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
        Dim Payement1 As A1_GAESTION_COMMERCIAL.Payement = New A1_GAESTION_COMMERCIAL.Payement()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.lbAvoir = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lb_PorteMonie = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbRef = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.AddPayementRow1 = New A1_GAESTION_COMMERCIAL.AddPayementRow()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.plPmBody = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lbLavc = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbLtotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel24.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lbRef)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Panel24)
        Me.Panel1.Controls.Add(Me.Panel23)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(884, 127)
        Me.Panel1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(656, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Avoir"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(431, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "porte-monnaie"
        Me.Label2.Visible = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkGray
        Me.Panel8.Controls.Add(Me.lbAvoir)
        Me.Panel8.Controls.Add(Me.Button3)
        Me.Panel8.Location = New System.Drawing.Point(656, 41)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(216, 32)
        Me.Panel8.TabIndex = 9
        Me.Panel8.Visible = False
        '
        'lbAvoir
        '
        Me.lbAvoir.AutoSize = True
        Me.lbAvoir.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAvoir.Location = New System.Drawing.Point(16, 9)
        Me.lbAvoir.Name = "lbAvoir"
        Me.lbAvoir.Size = New System.Drawing.Size(15, 15)
        Me.lbAvoir.TabIndex = 11
        Me.lbAvoir.Text = "0"
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(174, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button3.Size = New System.Drawing.Size(42, 32)
        Me.Button3.TabIndex = 3
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkGray
        Me.Panel7.Controls.Add(Me.lb_PorteMonie)
        Me.Panel7.Controls.Add(Me.Button1)
        Me.Panel7.Location = New System.Drawing.Point(434, 41)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(216, 32)
        Me.Panel7.TabIndex = 9
        Me.Panel7.Visible = False
        '
        'lb_PorteMonie
        '
        Me.lb_PorteMonie.AutoSize = True
        Me.lb_PorteMonie.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_PorteMonie.Location = New System.Drawing.Point(13, 9)
        Me.lb_PorteMonie.Name = "lb_PorteMonie"
        Me.lb_PorteMonie.Size = New System.Drawing.Size(15, 15)
        Me.lb_PorteMonie.TabIndex = 12
        Me.lb_PorteMonie.Text = "0"
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(174, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(42, 32)
        Me.Button1.TabIndex = 3
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Cash_register_73439
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(17, 20)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(44, 30)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'lbRef
        '
        Me.lbRef.AutoSize = True
        Me.lbRef.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRef.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbRef.Location = New System.Drawing.Point(150, 29)
        Me.lbRef.Name = "lbRef"
        Me.lbRef.Size = New System.Drawing.Size(18, 18)
        Me.lbRef.TabIndex = 5
        Me.lbRef.Text = "[]"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(62, 29)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 18)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Payement"
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.AddPayementRow1)
        Me.Panel24.Controls.Add(Me.Panel29)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(5, 86)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(874, 36)
        Me.Panel24.TabIndex = 3
        '
        'AddPayementRow1
        '
        Me.AddPayementRow1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.AddPayementRow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AddPayementRow1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddPayementRow1.EditMode = False
        Me.AddPayementRow1.id = 0
        Me.AddPayementRow1.Index = 0
        Me.AddPayementRow1.Location = New System.Drawing.Point(0, 2)
        Me.AddPayementRow1.Name = "AddPayementRow1"
        Me.AddPayementRow1.Padding = New System.Windows.Forms.Padding(2)
        Me.AddPayementRow1.Payement = Payement1
        Me.AddPayementRow1.Size = New System.Drawing.Size(874, 34)
        Me.AddPayementRow1.TabIndex = 9
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(874, 2)
        Me.Panel29.TabIndex = 1
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.DimGray
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(5, 5)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(874, 2)
        Me.Panel23.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DimGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(884, 2)
        Me.Panel5.TabIndex = 1
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.plPmBody)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 127)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel4.Size = New System.Drawing.Size(884, 325)
        Me.Panel4.TabIndex = 8
        '
        'plPmBody
        '
        Me.plPmBody.AutoScroll = True
        Me.plPmBody.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.plPmBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plPmBody.Location = New System.Drawing.Point(5, 5)
        Me.plPmBody.Name = "plPmBody"
        Me.plPmBody.Padding = New System.Windows.Forms.Padding(10)
        Me.plPmBody.Size = New System.Drawing.Size(874, 315)
        Me.plPmBody.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 489)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(884, 17)
        Me.Panel2.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.lbLavc)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.lbLtotal)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 452)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(884, 37)
        Me.Panel3.TabIndex = 9
        '
        'lbLavc
        '
        Me.lbLavc.BackColor = System.Drawing.Color.LightGray
        Me.lbLavc.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbLavc.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLavc.Location = New System.Drawing.Point(354, 2)
        Me.lbLavc.Name = "lbLavc"
        Me.lbLavc.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbLavc.Size = New System.Drawing.Size(134, 35)
        Me.lbLavc.TabIndex = 8
        Me.lbLavc.Text = "0"
        Me.lbLavc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(242, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.Label5.Size = New System.Drawing.Size(112, 35)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Avance:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbLtotal
        '
        Me.lbLtotal.BackColor = System.Drawing.Color.LightGray
        Me.lbLtotal.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbLtotal.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLtotal.Location = New System.Drawing.Point(108, 2)
        Me.lbLtotal.Name = "lbLtotal"
        Me.lbLtotal.Padding = New System.Windows.Forms.Padding(11, 0, 11, 0)
        Me.lbLtotal.Size = New System.Drawing.Size(134, 35)
        Me.lbLtotal.TabIndex = 7
        Me.lbLtotal.Text = "0"
        Me.lbLtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gainsboro
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(33, 0, 11, 0)
        Me.Label3.Size = New System.Drawing.Size(108, 35)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(756, 5)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button2.Size = New System.Drawing.Size(116, 28)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Enregistrer   "
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(884, 2)
        Me.Panel6.TabIndex = 1
        '
        'PayementForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 506)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PayementForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payement"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel24.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbRef As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents plPmBody As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents AddPayementRow1 As A1_GAESTION_COMMERCIAL.AddPayementRow
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents lbLavc As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbLtotal As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbAvoir As System.Windows.Forms.Label
    Friend WithEvents lb_PorteMonie As System.Windows.Forms.Label
End Class
