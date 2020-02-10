<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditCat
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel58 = New System.Windows.Forms.Panel()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel57 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtName = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtRemise = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel2.SuspendLayout()
        Me.Panel58.SuspendLayout()
        Me.Panel57.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtName)
        Me.Panel2.Location = New System.Drawing.Point(60, 62)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(295, 51)
        Me.Panel2.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nom :"
        '
        'Panel58
        '
        Me.Panel58.BackColor = System.Drawing.Color.Transparent
        Me.Panel58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel58.Controls.Add(Me.Button8)
        Me.Panel58.Location = New System.Drawing.Point(60, 305)
        Me.Panel58.Name = "Panel58"
        Me.Panel58.Size = New System.Drawing.Size(295, 49)
        Me.Panel58.TabIndex = 17
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
        Me.Button8.Size = New System.Drawing.Size(293, 47)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "          Valider"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Panel57
        '
        Me.Panel57.BackColor = System.Drawing.Color.Transparent
        Me.Panel57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel57.Controls.Add(Me.txtRemise)
        Me.Panel57.Controls.Add(Me.Label21)
        Me.Panel57.Location = New System.Drawing.Point(61, 208)
        Me.Panel57.Name = "Panel57"
        Me.Panel57.Size = New System.Drawing.Size(295, 51)
        Me.Panel57.TabIndex = 16
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label21.Location = New System.Drawing.Point(3, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(50, 16)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Remise"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.Location = New System.Drawing.Point(344, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 29)
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.Transparent
        Me.txtName.BorderColor = System.Drawing.Color.Transparent
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtName.IsNumiric = False
        Me.txtName.Location = New System.Drawing.Point(0, 19)
        Me.txtName.MinimumSize = New System.Drawing.Size(111, 30)
        Me.txtName.Name = "txtName"
        Me.txtName.PlaceHolder = ""
        Me.txtName.ShowClearIcon = False
        Me.txtName.ShowSaveIcon = False
        Me.txtName.Size = New System.Drawing.Size(293, 30)
        Me.txtName.StartUp = 2
        Me.txtName.TabIndex = 3
        Me.txtName.TextSize = 8
        Me.txtName.TxtBackColor = True
        Me.txtName.TxtColor = System.Drawing.Color.White
        Me.txtName.txtReadOnly = False
        Me.txtName.TxtSelect = New Integer() {1, 0}
        '
        'txtRemise
        '
        Me.txtRemise.BackColor = System.Drawing.Color.Transparent
        Me.txtRemise.BorderColor = System.Drawing.Color.Transparent
        Me.txtRemise.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtRemise.IsNumiric = True
        Me.txtRemise.Location = New System.Drawing.Point(0, 19)
        Me.txtRemise.MinimumSize = New System.Drawing.Size(111, 30)
        Me.txtRemise.Name = "txtRemise"
        Me.txtRemise.PlaceHolder = ""
        Me.txtRemise.ShowClearIcon = False
        Me.txtRemise.ShowSaveIcon = False
        Me.txtRemise.Size = New System.Drawing.Size(293, 30)
        Me.txtRemise.StartUp = 2
        Me.txtRemise.TabIndex = 2
        Me.txtRemise.TextSize = 8
        Me.txtRemise.TxtBackColor = True
        Me.txtRemise.TxtColor = System.Drawing.Color.White
        Me.txtRemise.txtReadOnly = False
        Me.txtRemise.TxtSelect = New Integer() {1, 0}
        '
        'AddEditCat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.bgForm
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(415, 392)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel58)
        Me.Controls.Add(Me.Panel57)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddEditCat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddEditCat"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel58.ResumeLayout(False)
        Me.Panel57.ResumeLayout(False)
        Me.Panel57.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Panel58 As System.Windows.Forms.Panel
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Panel57 As System.Windows.Forms.Panel
    Friend WithEvents txtRemise As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
End Class
