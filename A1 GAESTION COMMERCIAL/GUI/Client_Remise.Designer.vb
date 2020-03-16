<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Client_Remise
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
        Me.lbClient = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.plRef = New System.Windows.Forms.Panel()
        Me.plName = New System.Windows.Forms.Panel()
        Me.txtCat = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cbTous = New System.Windows.Forms.CheckBox()
        Me.plRemise = New System.Windows.Forms.Panel()
        Me.txtArt = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plleft = New System.Windows.Forms.Panel()
        Me.plTotal = New System.Windows.Forms.Panel()
        Me.txtRemise = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.plRef.SuspendLayout()
        Me.plName.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.plRemise.SuspendLayout()
        Me.plTotal.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lbClient)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(741, 97)
        Me.Panel1.TabIndex = 0
        '
        'lbClient
        '
        Me.lbClient.AutoSize = True
        Me.lbClient.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClient.ForeColor = System.Drawing.Color.Red
        Me.lbClient.Location = New System.Drawing.Point(39, 25)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(24, 24)
        Me.lbClient.TabIndex = 1
        Me.lbClient.Text = "--"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.plRef)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 59)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(741, 38)
        Me.Panel4.TabIndex = 1
        '
        'plRef
        '
        Me.plRef.Controls.Add(Me.plName)
        Me.plRef.Controls.Add(Me.Panel7)
        Me.plRef.Controls.Add(Me.plRemise)
        Me.plRef.Controls.Add(Me.plleft)
        Me.plRef.Controls.Add(Me.plTotal)
        Me.plRef.Controls.Add(Me.Panel5)
        Me.plRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plRef.Location = New System.Drawing.Point(0, 0)
        Me.plRef.Name = "plRef"
        Me.plRef.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.plRef.Size = New System.Drawing.Size(741, 38)
        Me.plRef.TabIndex = 6
        '
        'plName
        '
        Me.plName.Controls.Add(Me.txtCat)
        Me.plName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plName.Location = New System.Drawing.Point(120, 2)
        Me.plName.Name = "plName"
        Me.plName.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plName.Size = New System.Drawing.Size(170, 34)
        Me.plName.TabIndex = 12
        '
        'txtCat
        '
        Me.txtCat.BackColor = System.Drawing.Color.White
        Me.txtCat.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtCat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCat.IsNumiric = False
        Me.txtCat.Location = New System.Drawing.Point(5, 0)
        Me.txtCat.Name = "txtCat"
        Me.txtCat.PlaceHolder = "Famille"
        Me.txtCat.ShowClearIcon = False
        Me.txtCat.ShowSaveIcon = False
        Me.txtCat.Size = New System.Drawing.Size(160, 34)
        Me.txtCat.StartUp = 2
        Me.txtCat.TabIndex = 2
        Me.txtCat.TextSize = 8
        Me.txtCat.TxtBackColor = True
        Me.txtCat.TxtColor = System.Drawing.Color.White
        Me.txtCat.txtReadOnly = False
        Me.txtCat.TxtSelect = New Integer() {1, 0}
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.cbTous)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(51, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel7.Size = New System.Drawing.Size(69, 34)
        Me.Panel7.TabIndex = 11
        '
        'cbTous
        '
        Me.cbTous.AutoSize = True
        Me.cbTous.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTous.Location = New System.Drawing.Point(6, 9)
        Me.cbTous.Name = "cbTous"
        Me.cbTous.Size = New System.Drawing.Size(57, 19)
        Me.cbTous.TabIndex = 0
        Me.cbTous.Text = "Tous"
        Me.cbTous.UseVisualStyleBackColor = True
        '
        'plRemise
        '
        Me.plRemise.Controls.Add(Me.txtArt)
        Me.plRemise.Dock = System.Windows.Forms.DockStyle.Right
        Me.plRemise.Location = New System.Drawing.Point(290, 2)
        Me.plRemise.Name = "plRemise"
        Me.plRemise.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plRemise.Size = New System.Drawing.Size(208, 34)
        Me.plRemise.TabIndex = 7
        '
        'txtArt
        '
        Me.txtArt.BackColor = System.Drawing.Color.White
        Me.txtArt.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtArt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtArt.IsNumiric = False
        Me.txtArt.Location = New System.Drawing.Point(10, 0)
        Me.txtArt.Name = "txtArt"
        Me.txtArt.PlaceHolder = "Articles"
        Me.txtArt.ShowClearIcon = False
        Me.txtArt.ShowSaveIcon = False
        Me.txtArt.Size = New System.Drawing.Size(193, 34)
        Me.txtArt.StartUp = 2
        Me.txtArt.TabIndex = 5
        Me.txtArt.TextSize = 8
        Me.txtArt.TxtBackColor = True
        Me.txtArt.TxtColor = System.Drawing.Color.White
        Me.txtArt.txtReadOnly = False
        Me.txtArt.TxtSelect = New Integer() {1, 0}
        '
        'plleft
        '
        Me.plleft.BackColor = System.Drawing.Color.Transparent
        Me.plleft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.plleft.Location = New System.Drawing.Point(3, 2)
        Me.plleft.Name = "plleft"
        Me.plleft.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plleft.Size = New System.Drawing.Size(48, 34)
        Me.plleft.TabIndex = 6
        '
        'plTotal
        '
        Me.plTotal.Controls.Add(Me.txtRemise)
        Me.plTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.plTotal.Location = New System.Drawing.Point(498, 2)
        Me.plTotal.Name = "plTotal"
        Me.plTotal.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plTotal.Size = New System.Drawing.Size(148, 34)
        Me.plTotal.TabIndex = 13
        '
        'txtRemise
        '
        Me.txtRemise.BackColor = System.Drawing.Color.White
        Me.txtRemise.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRemise.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRemise.IsNumiric = True
        Me.txtRemise.Location = New System.Drawing.Point(10, 0)
        Me.txtRemise.Name = "txtRemise"
        Me.txtRemise.PlaceHolder = ""
        Me.txtRemise.ShowClearIcon = False
        Me.txtRemise.ShowSaveIcon = False
        Me.txtRemise.Size = New System.Drawing.Size(133, 34)
        Me.txtRemise.StartUp = 2
        Me.txtRemise.TabIndex = 58
        Me.txtRemise.TextSize = 8
        Me.txtRemise.TxtBackColor = True
        Me.txtRemise.TxtColor = System.Drawing.Color.White
        Me.txtRemise.txtReadOnly = False
        Me.txtRemise.TxtSelect = New Integer() {1, 0}
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel5.Controls.Add(Me.btClear)
        Me.Panel5.Controls.Add(Me.btAdd)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(646, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel5.Size = New System.Drawing.Size(92, 34)
        Me.Panel5.TabIndex = 14
        '
        'btClear
        '
        Me.btClear.BackColor = System.Drawing.Color.Transparent
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.CANCEL_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Left
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(49, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 34)
        Me.btClear.TabIndex = 9
        Me.btClear.UseVisualStyleBackColor = False
        '
        'btAdd
        '
        Me.btAdd.BackColor = System.Drawing.Color.Transparent
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.btAdd.Location = New System.Drawing.Point(5, 0)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(44, 34)
        Me.btAdd.TabIndex = 8
        Me.btAdd.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 389)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(741, 55)
        Me.Panel2.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.Button2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(595, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel6.Size = New System.Drawing.Size(146, 55)
        Me.Panel6.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.DELETE_20
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(67, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(69, 55)
        Me.Button1.TabIndex = 9
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_advancedsettings_3283__1_1
        Me.Button2.Location = New System.Drawing.Point(5, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(62, 55)
        Me.Button2.TabIndex = 8
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = True
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 97)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(11)
        Me.Panel3.Size = New System.Drawing.Size(741, 292)
        Me.Panel3.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(11, 11)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 33
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(719, 270)
        Me.DataGridView1.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "N°"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Type"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Designation"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Value"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Client_Remise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 444)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Client_Remise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remises de Client"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.plRef.ResumeLayout(False)
        Me.plName.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.plRemise.ResumeLayout(False)
        Me.plTotal.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lbClient As System.Windows.Forms.Label
    Friend WithEvents plRef As System.Windows.Forms.Panel
    Friend WithEvents plName As System.Windows.Forms.Panel
    Friend WithEvents txtCat As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plRemise As System.Windows.Forms.Panel
    Friend WithEvents txtArt As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plleft As System.Windows.Forms.Panel
    Friend WithEvents plTotal As System.Windows.Forms.Panel
    Friend WithEvents txtRemise As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cbTous As System.Windows.Forms.CheckBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
