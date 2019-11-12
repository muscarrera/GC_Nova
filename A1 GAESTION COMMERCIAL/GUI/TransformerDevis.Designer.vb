<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransformerDevis
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbClient = New System.Windows.Forms.Label()
        Me.txtBC = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtDate = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lbRef = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel24.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel23)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(550, 47)
        Me.Panel1.TabIndex = 6
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.DimGray
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(5, 5)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(540, 2)
        Me.Panel23.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(194, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Transformer le Devis "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbClient
        '
        Me.lbClient.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClient.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lbClient.Location = New System.Drawing.Point(354, 127)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(143, 85)
        Me.lbClient.TabIndex = 5
        Me.lbClient.Text = "[]"
        '
        'txtBC
        '
        Me.txtBC.BackColor = System.Drawing.Color.Transparent
        Me.txtBC.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtBC.IsNumiric = False
        Me.txtBC.Location = New System.Drawing.Point(30, 205)
        Me.txtBC.Name = "txtBC"
        Me.txtBC.PlaceHolder = ""
        Me.txtBC.ShowClearIcon = False
        Me.txtBC.ShowSaveIcon = False
        Me.txtBC.Size = New System.Drawing.Size(116, 26)
        Me.txtBC.StartUp = 2
        Me.txtBC.TabIndex = 3
        Me.txtBC.TextSize = 10
        Me.txtBC.TxtBackColor = True
        Me.txtBC.TxtColor = System.Drawing.Color.White
        Me.txtBC.txtReadOnly = False
        Me.txtBC.TxtSelect = New Integer() {1, 0}
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.Transparent
        Me.txtDate.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtDate.IsNumiric = False
        Me.txtDate.Location = New System.Drawing.Point(30, 143)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.PlaceHolder = ""
        Me.txtDate.ShowClearIcon = False
        Me.txtDate.ShowSaveIcon = False
        Me.txtDate.Size = New System.Drawing.Size(256, 26)
        Me.txtDate.StartUp = 2
        Me.txtDate.TabIndex = 2
        Me.txtDate.TextSize = 10
        Me.txtDate.TxtBackColor = True
        Me.txtDate.TxtColor = System.Drawing.Color.White
        Me.txtDate.txtReadOnly = False
        Me.txtDate.TxtSelect = New Integer() {1, 0}
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label15.Location = New System.Drawing.Point(29, 183)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 17)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Bon de Commande"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Location = New System.Drawing.Point(29, 123)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 17)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Date"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(29, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Transformer en "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.PictureBox1)
        Me.Panel11.Controls.Add(Me.lbClient)
        Me.Panel11.Controls.Add(Me.Panel24)
        Me.Panel11.Controls.Add(Me.cbType)
        Me.Panel11.Controls.Add(Me.Button1)
        Me.Panel11.Controls.Add(Me.txtBC)
        Me.Panel11.Controls.Add(Me.txtDate)
        Me.Panel11.Controls.Add(Me.Label15)
        Me.Panel11.Controls.Add(Me.Label14)
        Me.Panel11.Controls.Add(Me.lbRef)
        Me.Panel11.Controls.Add(Me.Label2)
        Me.Panel11.Controls.Add(Me.Label5)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.ForeColor = System.Drawing.Color.Brown
        Me.Panel11.Location = New System.Drawing.Point(10, 10)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel11.Size = New System.Drawing.Size(530, 302)
        Me.Panel11.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_User_278871
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(371, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 91)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.Button7)
        Me.Panel24.Controls.Add(Me.Button6)
        Me.Panel24.Controls.Add(Me.Panel29)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(10, 253)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(508, 37)
        Me.Panel24.TabIndex = 7
        '
        'Button7
        '
        Me.Button7.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(293, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Button7.Size = New System.Drawing.Size(90, 28)
        Me.Button7.TabIndex = 5
        Me.Button7.Text = "Annuler   "
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(389, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button6.Size = New System.Drawing.Size(116, 28)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Enregistrer   "
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(508, 2)
        Me.Panel29.TabIndex = 1
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.ItemHeight = 13
        Me.cbType.Location = New System.Drawing.Point(30, 85)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(256, 21)
        Me.cbType.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.JOINDRE_20
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(152, 203)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(134, 28)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Joindre un fichier"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lbRef
        '
        Me.lbRef.AutoSize = True
        Me.lbRef.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRef.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbRef.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbRef.Location = New System.Drawing.Point(110, 24)
        Me.lbRef.Name = "lbRef"
        Me.lbRef.Size = New System.Drawing.Size(13, 16)
        Me.lbRef.TabIndex = 5
        Me.lbRef.Text = "-"
        Me.lbRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(29, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Réference :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 47)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel10.Size = New System.Drawing.Size(550, 322)
        Me.Panel10.TabIndex = 10
        '
        'TransformerDevis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 369)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "TransformerDevis"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TransformerDevis"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel24.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbClient As System.Windows.Forms.Label
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents txtBC As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtDate As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents lbRef As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
