<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditCharge
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel58 = New System.Windows.Forms.Panel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel57 = New System.Windows.Forms.Panel()
        Me.txtDValue = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtDKey = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtvehicule = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdriver = New A1_GAESTION_COMMERCIAL.TxtBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel58.SuspendLayout()
        Me.Panel57.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(380, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 29)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Panel58
        '
        Me.Panel58.BackColor = System.Drawing.Color.Transparent
        Me.Panel58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel58.Controls.Add(Me.Button8)
        Me.Panel58.Location = New System.Drawing.Point(82, 387)
        Me.Panel58.Name = "Panel58"
        Me.Panel58.Size = New System.Drawing.Size(295, 37)
        Me.Panel58.TabIndex = 10
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.LimeGreen
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.Ivory
        Me.Button8.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(0, 0)
        Me.Button8.Name = "Button8"
        Me.Button8.Padding = New System.Windows.Forms.Padding(86, 0, 6, 0)
        Me.Button8.Size = New System.Drawing.Size(293, 35)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "          Valider"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Panel57
        '
        Me.Panel57.BackColor = System.Drawing.Color.Transparent
        Me.Panel57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel57.Controls.Add(Me.txtDValue)
        Me.Panel57.Controls.Add(Me.Label21)
        Me.Panel57.Location = New System.Drawing.Point(83, 312)
        Me.Panel57.Name = "Panel57"
        Me.Panel57.Size = New System.Drawing.Size(295, 51)
        Me.Panel57.TabIndex = 9
        '
        'txtDValue
        '
        Me.txtDValue.BackColor = System.Drawing.Color.Transparent
        Me.txtDValue.BorderColor = System.Drawing.Color.Transparent
        Me.txtDValue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDValue.IsNumiric = True
        Me.txtDValue.Location = New System.Drawing.Point(0, 19)
        Me.txtDValue.MinimumSize = New System.Drawing.Size(111, 30)
        Me.txtDValue.Name = "txtDValue"
        Me.txtDValue.PlaceHolder = ""
        Me.txtDValue.ShowClearIcon = False
        Me.txtDValue.ShowSaveIcon = False
        Me.txtDValue.Size = New System.Drawing.Size(293, 30)
        Me.txtDValue.StartUp = 2
        Me.txtDValue.TabIndex = 2
        Me.txtDValue.TextSize = 8
        Me.txtDValue.TxtBackColor = True
        Me.txtDValue.TxtColor = System.Drawing.Color.White
        Me.txtDValue.txtReadOnly = False
        Me.txtDValue.TxtSelect = New Integer() {1, 0}
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label21.Location = New System.Drawing.Point(3, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 16)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Valeur"
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.Transparent
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.Label17)
        Me.Panel21.Controls.Add(Me.txtDKey)
        Me.Panel21.Location = New System.Drawing.Point(83, 247)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(295, 51)
        Me.Panel21.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label17.Location = New System.Drawing.Point(3, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 16)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Designation"
        '
        'txtDKey
        '
        Me.txtDKey.BackColor = System.Drawing.Color.Transparent
        Me.txtDKey.BorderColor = System.Drawing.Color.Transparent
        Me.txtDKey.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtDKey.IsNumiric = False
        Me.txtDKey.Location = New System.Drawing.Point(0, 19)
        Me.txtDKey.MinimumSize = New System.Drawing.Size(111, 30)
        Me.txtDKey.Name = "txtDKey"
        Me.txtDKey.PlaceHolder = ""
        Me.txtDKey.ShowClearIcon = False
        Me.txtDKey.ShowSaveIcon = False
        Me.txtDKey.Size = New System.Drawing.Size(293, 30)
        Me.txtDKey.StartUp = 2
        Me.txtDKey.TabIndex = 1
        Me.txtDKey.TextSize = 8
        Me.txtDKey.TxtBackColor = True
        Me.txtDKey.TxtColor = System.Drawing.Color.White
        Me.txtDKey.txtReadOnly = False
        Me.txtDKey.TxtSelect = New Integer() {1, 0}
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtvehicule)
        Me.Panel1.Location = New System.Drawing.Point(90, 135)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(295, 51)
        Me.Panel1.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Vehicule"
        '
        'txtvehicule
        '
        Me.txtvehicule.BackColor = System.Drawing.Color.Transparent
        Me.txtvehicule.BorderColor = System.Drawing.Color.Transparent
        Me.txtvehicule.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtvehicule.IsNumiric = False
        Me.txtvehicule.Location = New System.Drawing.Point(0, 19)
        Me.txtvehicule.MinimumSize = New System.Drawing.Size(111, 30)
        Me.txtvehicule.Name = "txtvehicule"
        Me.txtvehicule.PlaceHolder = ""
        Me.txtvehicule.ShowClearIcon = False
        Me.txtvehicule.ShowSaveIcon = False
        Me.txtvehicule.Size = New System.Drawing.Size(293, 30)
        Me.txtvehicule.StartUp = 2
        Me.txtvehicule.TabIndex = 4
        Me.txtvehicule.TextSize = 8
        Me.txtvehicule.TxtBackColor = True
        Me.txtvehicule.TxtColor = System.Drawing.Color.White
        Me.txtvehicule.txtReadOnly = False
        Me.txtvehicule.TxtSelect = New Integer() {1, 0}
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtdriver)
        Me.Panel2.Location = New System.Drawing.Point(90, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(295, 51)
        Me.Panel2.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Chauffeur"
        '
        'txtdriver
        '
        Me.txtdriver.BackColor = System.Drawing.Color.Transparent
        Me.txtdriver.BorderColor = System.Drawing.Color.Transparent
        Me.txtdriver.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtdriver.IsNumiric = False
        Me.txtdriver.Location = New System.Drawing.Point(0, 19)
        Me.txtdriver.MinimumSize = New System.Drawing.Size(111, 30)
        Me.txtdriver.Name = "txtdriver"
        Me.txtdriver.PlaceHolder = ""
        Me.txtdriver.ShowClearIcon = False
        Me.txtdriver.ShowSaveIcon = False
        Me.txtdriver.Size = New System.Drawing.Size(293, 30)
        Me.txtdriver.StartUp = 2
        Me.txtdriver.TabIndex = 3
        Me.txtdriver.TextSize = 8
        Me.txtdriver.TxtBackColor = True
        Me.txtdriver.TxtColor = System.Drawing.Color.White
        Me.txtdriver.txtReadOnly = False
        Me.txtdriver.TxtSelect = New Integer() {1, 0}
        '
        'AddEditCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.bgForm
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(457, 485)
        Me.Controls.Add(Me.Panel58)
        Me.Controls.Add(Me.Panel57)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel21)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddEditCharge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddEditCharge"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel58.ResumeLayout(False)
        Me.Panel57.ResumeLayout(False)
        Me.Panel57.PerformLayout()
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel58 As System.Windows.Forms.Panel
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Panel57 As System.Windows.Forms.Panel
    Friend WithEvents txtDValue As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtDKey As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtvehicule As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtdriver As A1_GAESTION_COMMERCIAL.TxtBox
End Class
