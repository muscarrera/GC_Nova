<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransformeStock
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Cb1 = New System.Windows.Forms.ComboBox()
        Me.DepotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ALMohassinDBDataSet = New A1_GAESTION_COMMERCIAL.ALMohassinDBDataSet()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Cb2 = New System.Windows.Forms.ComboBox()
        Me.txtQte = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbQteStock2 = New System.Windows.Forms.Label()
        Me.lbQteStock = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.DepotTableAdapter = New A1_GAESTION_COMMERCIAL.ALMohassinDBDataSetTableAdapters.DepotTableAdapter()
        Me.Panel24.SuspendLayout()
        CType(Me.DepotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALMohassinDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.Button7)
        Me.Panel24.Controls.Add(Me.Button6)
        Me.Panel24.Controls.Add(Me.Panel29)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(10, 292)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(473, 37)
        Me.Panel24.TabIndex = 7
        '
        'Button7
        '
        Me.Button7.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(251, 3)
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
        Me.Button6.Location = New System.Drawing.Point(347, 3)
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
        Me.Panel29.Size = New System.Drawing.Size(473, 2)
        Me.Panel29.TabIndex = 1
        '
        'Cb1
        '
        Me.Cb1.DataSource = Me.DepotBindingSource
        Me.Cb1.DisplayMember = "name"
        Me.Cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb1.FormattingEnabled = True
        Me.Cb1.ItemHeight = 13
        Me.Cb1.Location = New System.Drawing.Point(32, 113)
        Me.Cb1.Name = "Cb1"
        Me.Cb1.Size = New System.Drawing.Size(256, 21)
        Me.Cb1.TabIndex = 1
        Me.Cb1.ValueMember = "dpid"
        '
        'DepotBindingSource
        '
        Me.DepotBindingSource.DataMember = "Depot"
        Me.DepotBindingSource.DataSource = Me.ALMohassinDBDataSet
        '
        'ALMohassinDBDataSet
        '
        Me.ALMohassinDBDataSet.DataSetName = "ALMohassinDBDataSet"
        Me.ALMohassinDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbName.Location = New System.Drawing.Point(31, 45)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(13, 16)
        Me.lbName.TabIndex = 5
        Me.lbName.Text = "-"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(29, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Designation:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel11.Controls.Add(Me.Panel24)
        Me.Panel11.Controls.Add(Me.PictureBox1)
        Me.Panel11.Controls.Add(Me.Cb2)
        Me.Panel11.Controls.Add(Me.Cb1)
        Me.Panel11.Controls.Add(Me.txtQte)
        Me.Panel11.Controls.Add(Me.Label14)
        Me.Panel11.Controls.Add(Me.lbQteStock2)
        Me.Panel11.Controls.Add(Me.lbQteStock)
        Me.Panel11.Controls.Add(Me.lbName)
        Me.Panel11.Controls.Add(Me.Label3)
        Me.Panel11.Controls.Add(Me.Label2)
        Me.Panel11.Controls.Add(Me.Label5)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.ForeColor = System.Drawing.Color.Brown
        Me.Panel11.Location = New System.Drawing.Point(10, 10)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel11.Size = New System.Drawing.Size(495, 341)
        Me.Panel11.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_User_278871
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(320, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 156)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Cb2
        '
        Me.Cb2.DataSource = Me.DepotBindingSource
        Me.Cb2.DisplayMember = "name"
        Me.Cb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cb2.FormattingEnabled = True
        Me.Cb2.ItemHeight = 13
        Me.Cb2.Location = New System.Drawing.Point(32, 176)
        Me.Cb2.Name = "Cb2"
        Me.Cb2.Size = New System.Drawing.Size(256, 21)
        Me.Cb2.TabIndex = 1
        Me.Cb2.ValueMember = "dpid"
        '
        'txtQte
        '
        Me.txtQte.BackColor = System.Drawing.Color.Transparent
        Me.txtQte.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtQte.IsNumiric = True
        Me.txtQte.Location = New System.Drawing.Point(32, 239)
        Me.txtQte.Name = "txtQte"
        Me.txtQte.PlaceHolder = ""
        Me.txtQte.ShowClearIcon = False
        Me.txtQte.ShowSaveIcon = False
        Me.txtQte.Size = New System.Drawing.Size(256, 26)
        Me.txtQte.StartUp = 2
        Me.txtQte.TabIndex = 2
        Me.txtQte.TextSize = 10
        Me.txtQte.TxtBackColor = True
        Me.txtQte.TxtColor = System.Drawing.Color.White
        Me.txtQte.txtReadOnly = False
        Me.txtQte.TxtSelect = New Integer() {1, 0}
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label14.Location = New System.Drawing.Point(31, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 17)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Qte :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lbQteStock2
        '
        Me.lbQteStock2.AutoSize = True
        Me.lbQteStock2.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQteStock2.ForeColor = System.Drawing.Color.Green
        Me.lbQteStock2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbQteStock2.Location = New System.Drawing.Point(338, 223)
        Me.lbQteStock2.Name = "lbQteStock2"
        Me.lbQteStock2.Size = New System.Drawing.Size(21, 24)
        Me.lbQteStock2.TabIndex = 5
        Me.lbQteStock2.Text = "0"
        Me.lbQteStock2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQteStock
        '
        Me.lbQteStock.AutoSize = True
        Me.lbQteStock.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQteStock.ForeColor = System.Drawing.Color.Navy
        Me.lbQteStock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbQteStock.Location = New System.Drawing.Point(338, 186)
        Me.lbQteStock.Name = "lbQteStock"
        Me.lbQteStock.Size = New System.Drawing.Size(21, 24)
        Me.lbQteStock.TabIndex = 5
        Me.lbQteStock.Text = "0"
        Me.lbQteStock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(31, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Destination"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(31, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Depot"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 47)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel10.Size = New System.Drawing.Size(515, 361)
        Me.Panel10.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel23)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(515, 47)
        Me.Panel1.TabIndex = 11
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.DimGray
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(5, 5)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(505, 2)
        Me.Panel23.TabIndex = 2
        '
        'DepotTableAdapter
        '
        Me.DepotTableAdapter.ClearBeforeFill = True
        '
        'TransformeStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 408)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "TransformeStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mouvement de Stock"
        Me.Panel24.ResumeLayout(False)
        CType(Me.DepotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALMohassinDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Cb1 As System.Windows.Forms.ComboBox
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents txtQte As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Cb2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ALMohassinDBDataSet As A1_GAESTION_COMMERCIAL.ALMohassinDBDataSet
    Friend WithEvents DepotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepotTableAdapter As A1_GAESTION_COMMERCIAL.ALMohassinDBDataSetTableAdapters.DepotTableAdapter
    Friend WithEvents lbQteStock As System.Windows.Forms.Label
    Friend WithEvents lbQteStock2 As System.Windows.Forms.Label
End Class
