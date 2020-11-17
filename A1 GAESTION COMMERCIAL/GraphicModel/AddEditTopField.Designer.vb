<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditTopField
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CB = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbBloc = New System.Windows.Forms.CheckBox()
        Me.btColor = New System.Windows.Forms.Button()
        Me.T = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.H = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.W = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Y = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.X = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txt = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(67, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Text"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(14, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "X"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(137, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(14, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Y"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(203, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "W"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(269, 169)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "H"
        '
        'CB
        '
        Me.CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CB.FormattingEnabled = True
        Me.CB.ItemHeight = 13
        Me.CB.Items.AddRange(New Object() {"*", "-Titre", "id", "date", "cid", "name", "ref", "CLT_ice", "CLT_adresse", "CLT_ref", "total_ht", "total_tva", "total_ttc", "total_remise", "total_droitTimbre", "image", "total_avance", "Editeur", "//En_Chiffre", "MPayement", "tableau_tva", "DPT_ID", "DPT_Nom"})
        Me.CB.Location = New System.Drawing.Point(74, 116)
        Me.CB.Name = "CB"
        Me.CB.Size = New System.Drawing.Size(327, 21)
        Me.CB.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(335, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(14, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "T"
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(68, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Field"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(70, 355)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(328, 38)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(74, 297)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(85, 17)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Text en gras"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(272, 399)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(125, 38)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Delete"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbBloc
        '
        Me.cbBloc.AutoSize = True
        Me.cbBloc.Location = New System.Drawing.Point(206, 297)
        Me.cbBloc.Name = "cbBloc"
        Me.cbBloc.Size = New System.Drawing.Size(94, 17)
        Me.cbBloc.TabIndex = 8
        Me.cbBloc.Text = "Crée un Cadre"
        Me.cbBloc.UseVisualStyleBackColor = True
        '
        'btColor
        '
        Me.btColor.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btColor.Location = New System.Drawing.Point(272, 219)
        Me.btColor.Name = "btColor"
        Me.btColor.Size = New System.Drawing.Size(125, 30)
        Me.btColor.TabIndex = 10
        Me.btColor.Text = "Couleur"
        Me.btColor.UseVisualStyleBackColor = False
        '
        'T
        '
        Me.T.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.T.BackColor = System.Drawing.Color.Transparent
        Me.T.BorderColor = System.Drawing.SystemColors.ControlText
        Me.T.IsNumiric = True
        Me.T.Location = New System.Drawing.Point(338, 185)
        Me.T.Name = "T"
        Me.T.PlaceHolder = ""
        Me.T.ShowClearIcon = False
        Me.T.ShowSaveIcon = False
        Me.T.Size = New System.Drawing.Size(60, 23)
        Me.T.StartUp = 2
        Me.T.TabIndex = 4
        Me.T.TextSize = 8
        Me.T.TxtBackColor = True
        Me.T.TxtColor = System.Drawing.Color.White
        Me.T.txtReadOnly = False
        Me.T.TxtSelect = New Integer() {1, 0}
        '
        'H
        '
        Me.H.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.H.BackColor = System.Drawing.Color.Transparent
        Me.H.BorderColor = System.Drawing.SystemColors.ControlText
        Me.H.IsNumiric = True
        Me.H.Location = New System.Drawing.Point(272, 185)
        Me.H.Name = "H"
        Me.H.PlaceHolder = ""
        Me.H.ShowClearIcon = False
        Me.H.ShowSaveIcon = False
        Me.H.Size = New System.Drawing.Size(60, 23)
        Me.H.StartUp = 2
        Me.H.TabIndex = 4
        Me.H.TextSize = 8
        Me.H.TxtBackColor = True
        Me.H.TxtColor = System.Drawing.Color.White
        Me.H.txtReadOnly = False
        Me.H.TxtSelect = New Integer() {1, 0}
        '
        'W
        '
        Me.W.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.W.BackColor = System.Drawing.Color.Transparent
        Me.W.BorderColor = System.Drawing.SystemColors.ControlText
        Me.W.IsNumiric = True
        Me.W.Location = New System.Drawing.Point(206, 185)
        Me.W.Name = "W"
        Me.W.PlaceHolder = ""
        Me.W.ShowClearIcon = False
        Me.W.ShowSaveIcon = False
        Me.W.Size = New System.Drawing.Size(60, 23)
        Me.W.StartUp = 2
        Me.W.TabIndex = 4
        Me.W.TextSize = 8
        Me.W.TxtBackColor = True
        Me.W.TxtColor = System.Drawing.Color.White
        Me.W.txtReadOnly = False
        Me.W.TxtSelect = New Integer() {1, 0}
        '
        'Y
        '
        Me.Y.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Y.BackColor = System.Drawing.Color.Transparent
        Me.Y.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Y.IsNumiric = True
        Me.Y.Location = New System.Drawing.Point(140, 185)
        Me.Y.Name = "Y"
        Me.Y.PlaceHolder = ""
        Me.Y.ShowClearIcon = False
        Me.Y.ShowSaveIcon = False
        Me.Y.Size = New System.Drawing.Size(60, 23)
        Me.Y.StartUp = 2
        Me.Y.TabIndex = 4
        Me.Y.TextSize = 8
        Me.Y.TxtBackColor = True
        Me.Y.TxtColor = System.Drawing.Color.White
        Me.Y.txtReadOnly = False
        Me.Y.TxtSelect = New Integer() {1, 0}
        '
        'X
        '
        Me.X.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.X.BackColor = System.Drawing.Color.Transparent
        Me.X.BorderColor = System.Drawing.SystemColors.ControlText
        Me.X.IsNumiric = True
        Me.X.Location = New System.Drawing.Point(74, 185)
        Me.X.Name = "X"
        Me.X.PlaceHolder = ""
        Me.X.ShowClearIcon = False
        Me.X.ShowSaveIcon = False
        Me.X.Size = New System.Drawing.Size(60, 23)
        Me.X.StartUp = 2
        Me.X.TabIndex = 4
        Me.X.TextSize = 8
        Me.X.TxtBackColor = True
        Me.X.TxtColor = System.Drawing.Color.White
        Me.X.txtReadOnly = False
        Me.X.TxtSelect = New Integer() {1, 0}
        '
        'txt
        '
        Me.txt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt.BackColor = System.Drawing.Color.Transparent
        Me.txt.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txt.IsNumiric = False
        Me.txt.Location = New System.Drawing.Point(70, 39)
        Me.txt.Name = "txt"
        Me.txt.PlaceHolder = ""
        Me.txt.ShowClearIcon = False
        Me.txt.ShowSaveIcon = False
        Me.txt.Size = New System.Drawing.Size(328, 23)
        Me.txt.StartUp = 2
        Me.txt.TabIndex = 4
        Me.txt.TextSize = 8
        Me.txt.TxtBackColor = True
        Me.txt.TxtColor = System.Drawing.Color.White
        Me.txt.txtReadOnly = False
        Me.txt.TxtSelect = New Integer() {1, 0}
        '
        'AddEditTopField
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 452)
        Me.Controls.Add(Me.btColor)
        Me.Controls.Add(Me.cbBloc)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CB)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.T)
        Me.Controls.Add(Me.H)
        Me.Controls.Add(Me.W)
        Me.Controls.Add(Me.Y)
        Me.Controls.Add(Me.X)
        Me.Controls.Add(Me.txt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddEditTopField"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddEditTopField"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txt As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents X As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Y As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents W As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents H As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CB As System.Windows.Forms.ComboBox
    Friend WithEvents T As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbBloc As System.Windows.Forms.CheckBox
    Friend WithEvents btColor As System.Windows.Forms.Button
End Class
