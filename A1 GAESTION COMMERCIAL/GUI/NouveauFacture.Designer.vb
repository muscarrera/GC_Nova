<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NouveauFacture
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
        Me.txtName = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.plExerces = New System.Windows.Forms.Panel()
        Me.TxtExr = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtDate = New System.Windows.Forms.TextBox()
        Me.lbDate = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.plExerces.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtName)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(45, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(416, 40)
        Me.Panel1.TabIndex = 0
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtName.BorderColor = System.Drawing.Color.Transparent
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtName.IsNumiric = False
        Me.txtName.Location = New System.Drawing.Point(67, 0)
        Me.txtName.Name = "txtName"
        Me.txtName.ShowClearIcon = False
        Me.txtName.ShowSaveIcon = False
        Me.txtName.Size = New System.Drawing.Size(272, 38)
        Me.txtName.StartUp = 2
        Me.txtName.TabIndex = 4
        Me.txtName.TextSize = 8
        Me.txtName.TxtBackColor = True
        Me.txtName.TxtColor = System.Drawing.Color.WhiteSmoke
        Me.txtName.txtReadOnly = False
        Me.txtName.TxtSelect = New Integer() {1, 0}
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(339, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 38)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nom"
        '
        'plExerces
        '
        Me.plExerces.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plExerces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.plExerces.Controls.Add(Me.TxtExr)
        Me.plExerces.Controls.Add(Me.Label2)
        Me.plExerces.Location = New System.Drawing.Point(45, 30)
        Me.plExerces.Name = "plExerces"
        Me.plExerces.Size = New System.Drawing.Size(250, 42)
        Me.plExerces.TabIndex = 0
        '
        'TxtExr
        '
        Me.TxtExr.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtExr.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtExr.Enabled = False
        Me.TxtExr.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExr.Location = New System.Drawing.Point(71, 13)
        Me.TxtExr.Name = "TxtExr"
        Me.TxtExr.Size = New System.Drawing.Size(174, 16)
        Me.TxtExr.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Exercice "
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.TxtDate)
        Me.Panel3.Controls.Add(Me.lbDate)
        Me.Panel3.Location = New System.Drawing.Point(45, 157)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(416, 40)
        Me.Panel3.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(339, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 38)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtDate
        '
        Me.TxtDate.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDate.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDate.Location = New System.Drawing.Point(85, 13)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(248, 16)
        Me.TxtDate.TabIndex = 2
        '
        'lbDate
        '
        Me.lbDate.AutoSize = True
        Me.lbDate.Location = New System.Drawing.Point(14, 13)
        Me.lbDate.Name = "lbDate"
        Me.lbDate.Size = New System.Drawing.Size(30, 13)
        Me.lbDate.TabIndex = 1
        Me.lbDate.Text = "Date"
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(328, 222)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(133, 38)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Valider"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'NouveauFacture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(496, 272)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.plExerces)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NouveauFacture"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nouveau"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.plExerces.ResumeLayout(False)
        Me.plExerces.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents plExerces As System.Windows.Forms.Panel
    Friend WithEvents TxtExr As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TxtDate As System.Windows.Forms.TextBox
    Friend WithEvents lbDate As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtName As A1_GAESTION_COMMERCIAL.TxtBox
End Class
