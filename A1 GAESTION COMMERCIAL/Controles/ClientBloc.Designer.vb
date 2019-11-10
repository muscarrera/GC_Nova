<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientBloc
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
        Me.lbnum = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Pb = New System.Windows.Forms.PictureBox()
        Me.lbTel = New System.Windows.Forms.Label()
        Me.lbAdresse = New System.Windows.Forms.Label()
        Me.PL = New System.Windows.Forms.Panel()
        Me.lbArid = New System.Windows.Forms.Label()
        Me.lbType = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PL.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbnum
        '
        Me.lbnum.AutoSize = True
        Me.lbnum.BackColor = System.Drawing.Color.Transparent
        Me.lbnum.Font = New System.Drawing.Font("Arial Black", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnum.ForeColor = System.Drawing.Color.LightSkyBlue
        Me.lbnum.Location = New System.Drawing.Point(7, 6)
        Me.lbnum.Name = "lbnum"
        Me.lbnum.Size = New System.Drawing.Size(10, 11)
        Me.lbnum.TabIndex = 4
        Me.lbnum.Text = "0"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.lbName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 62)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(180, 18)
        Me.Panel1.TabIndex = 5
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.BackColor = System.Drawing.Color.Transparent
        Me.lbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.Color.Gray
        Me.lbName.Location = New System.Drawing.Point(7, 0)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(34, 15)
        Me.lbName.TabIndex = 1
        Me.lbName.Text = "Nom"
        '
        'Pb
        '
        Me.Pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Pb.Location = New System.Drawing.Point(5, 6)
        Me.Pb.Name = "Pb"
        Me.Pb.Size = New System.Drawing.Size(43, 43)
        Me.Pb.TabIndex = 0
        Me.Pb.TabStop = False
        '
        'lbTel
        '
        Me.lbTel.AutoSize = True
        Me.lbTel.BackColor = System.Drawing.Color.Transparent
        Me.lbTel.Location = New System.Drawing.Point(53, 38)
        Me.lbTel.Name = "lbTel"
        Me.lbTel.Size = New System.Drawing.Size(22, 13)
        Me.lbTel.TabIndex = 3
        Me.lbTel.Text = "Tel"
        '
        'lbAdresse
        '
        Me.lbAdresse.AutoSize = True
        Me.lbAdresse.BackColor = System.Drawing.Color.Transparent
        Me.lbAdresse.Location = New System.Drawing.Point(53, 22)
        Me.lbAdresse.Name = "lbAdresse"
        Me.lbAdresse.Size = New System.Drawing.Size(45, 13)
        Me.lbAdresse.TabIndex = 2
        Me.lbAdresse.Text = "Adresse"
        '
        'PL
        '
        Me.PL.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.PL.Controls.Add(Me.lbnum)
        Me.PL.Controls.Add(Me.Panel1)
        Me.PL.Controls.Add(Me.Pb)
        Me.PL.Controls.Add(Me.lbTel)
        Me.PL.Controls.Add(Me.lbAdresse)
        Me.PL.Controls.Add(Me.lbArid)
        Me.PL.Controls.Add(Me.lbType)
        Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PL.Location = New System.Drawing.Point(0, 0)
        Me.PL.Name = "PL"
        Me.PL.Size = New System.Drawing.Size(180, 80)
        Me.PL.TabIndex = 6
        '
        'lbArid
        '
        Me.lbArid.AutoSize = True
        Me.lbArid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbArid.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lbArid.Location = New System.Drawing.Point(53, 6)
        Me.lbArid.Name = "lbArid"
        Me.lbArid.Size = New System.Drawing.Size(18, 13)
        Me.lbArid.TabIndex = 4
        Me.lbArid.Text = "Id"
        '
        'lbType
        '
        Me.lbType.AutoSize = True
        Me.lbType.BackColor = System.Drawing.Color.Transparent
        Me.lbType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbType.ForeColor = System.Drawing.Color.Red
        Me.lbType.Location = New System.Drawing.Point(153, 6)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(20, 13)
        Me.lbType.TabIndex = 4
        Me.lbType.Text = "Tp"
        '
        'ClientBloc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PL)
        Me.Name = "ClientBloc"
        Me.Size = New System.Drawing.Size(180, 80)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PL.ResumeLayout(False)
        Me.PL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbnum As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Pb As System.Windows.Forms.PictureBox
    Friend WithEvents lbTel As System.Windows.Forms.Label
    Friend WithEvents lbAdresse As System.Windows.Forms.Label
    Friend WithEvents PL As System.Windows.Forms.Panel
    Friend WithEvents lbArid As System.Windows.Forms.Label
    Friend WithEvents lbType As System.Windows.Forms.Label

End Class
