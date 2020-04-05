<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddEditDepot
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel58 = New System.Windows.Forms.Panel()
        Me.btcid = New System.Windows.Forms.Button()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvctg = New System.Windows.Forms.DataGridView()
        Me.DpidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ALMohassinDBDataSet = New A1_GAESTION_COMMERCIAL.ALMohassinDBDataSet()
        Me.DepotTableAdapter = New A1_GAESTION_COMMERCIAL.ALMohassinDBDataSetTableAdapters.DepotTableAdapter()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel58.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvctg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DepotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ALMohassinDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel58
        '
        Me.Panel58.BackColor = System.Drawing.Color.Transparent
        Me.Panel58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel58.Controls.Add(Me.btcid)
        Me.Panel58.Location = New System.Drawing.Point(125, 113)
        Me.Panel58.Name = "Panel58"
        Me.Panel58.Size = New System.Drawing.Size(183, 37)
        Me.Panel58.TabIndex = 32
        '
        'btcid
        '
        Me.btcid.BackColor = System.Drawing.Color.LimeGreen
        Me.btcid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btcid.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btcid.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btcid.ForeColor = System.Drawing.Color.Ivory
        Me.btcid.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.btcid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcid.Location = New System.Drawing.Point(0, 0)
        Me.btcid.Name = "btcid"
        Me.btcid.Padding = New System.Windows.Forms.Padding(33, 0, 6, 0)
        Me.btcid.Size = New System.Drawing.Size(181, 35)
        Me.btcid.TabIndex = 2
        Me.btcid.Text = "          Valider"
        Me.btcid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btcid.UseVisualStyleBackColor = False
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.White
        Me.Panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel21.Controls.Add(Me.Label1)
        Me.Panel21.Controls.Add(Me.TextBox1)
        Me.Panel21.Location = New System.Drawing.Point(13, 26)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(295, 51)
        Me.Panel21.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Nom"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Transparent
        Me.TextBox1.BorderColor = System.Drawing.Color.Transparent
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBox1.IsNumiric = False
        Me.TextBox1.Location = New System.Drawing.Point(0, 19)
        Me.TextBox1.MinimumSize = New System.Drawing.Size(111, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PlaceHolder = ""
        Me.TextBox1.ShowClearIcon = False
        Me.TextBox1.ShowSaveIcon = False
        Me.TextBox1.Size = New System.Drawing.Size(293, 30)
        Me.TextBox1.StartUp = 2
        Me.TextBox1.TabIndex = 7
        Me.TextBox1.TextSize = 8
        Me.TextBox1.TxtBackColor = True
        Me.TextBox1.TxtColor = System.Drawing.Color.White
        Me.TextBox1.txtReadOnly = False
        Me.TextBox1.TxtSelect = New Integer() {1, 0}
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(13, 113)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(81, 36)
        Me.Button3.TabIndex = 27
        Me.Button3.Text = "Rest"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvctg)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(353, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(293, 344)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Entrepotes"
        '
        'dgvctg
        '
        Me.dgvctg.AllowUserToAddRows = False
        Me.dgvctg.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        Me.dgvctg.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvctg.AutoGenerateColumns = False
        Me.dgvctg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvctg.BackgroundColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvctg.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvctg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvctg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DpidDataGridViewTextBoxColumn, Me.NameDataGridViewTextBoxColumn})
        Me.dgvctg.DataSource = Me.DepotBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvctg.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvctg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvctg.Location = New System.Drawing.Point(3, 16)
        Me.dgvctg.MultiSelect = False
        Me.dgvctg.Name = "dgvctg"
        Me.dgvctg.ReadOnly = True
        Me.dgvctg.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvctg.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvctg.RowTemplate.Height = 28
        Me.dgvctg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvctg.Size = New System.Drawing.Size(287, 325)
        Me.dgvctg.TabIndex = 20
        '
        'DpidDataGridViewTextBoxColumn
        '
        Me.DpidDataGridViewTextBoxColumn.DataPropertyName = "dpid"
        Me.DpidDataGridViewTextBoxColumn.FillWeight = 47.71573!
        Me.DpidDataGridViewTextBoxColumn.HeaderText = "N°"
        Me.DpidDataGridViewTextBoxColumn.Name = "DpidDataGridViewTextBoxColumn"
        Me.DpidDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NameDataGridViewTextBoxColumn
        '
        Me.NameDataGridViewTextBoxColumn.DataPropertyName = "name"
        Me.NameDataGridViewTextBoxColumn.FillWeight = 152.2843!
        Me.NameDataGridViewTextBoxColumn.HeaderText = "Designation"
        Me.NameDataGridViewTextBoxColumn.Name = "NameDataGridViewTextBoxColumn"
        Me.NameDataGridViewTextBoxColumn.ReadOnly = True
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
        'DepotTableAdapter
        '
        Me.DepotTableAdapter.ClearBeforeFill = True
        '
        'Button1
        '
        Me.Button1.AllowDrop = True
        Me.Button1.BackColor = System.Drawing.Color.PaleTurquoise
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_advancedsettings_3283__1_1
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(129, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 65)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Edit"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button45
        '
        Me.Button45.BackColor = System.Drawing.Color.Honeydew
        Me.Button45.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button45.FlatAppearance.BorderSize = 0
        Me.Button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button45.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_folder_add_61769
        Me.Button45.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button45.Location = New System.Drawing.Point(26, 34)
        Me.Button45.Margin = New System.Windows.Forms.Padding(0)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(95, 65)
        Me.Button45.TabIndex = 36
        Me.Button45.Text = "Nouveau"
        Me.Button45.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button45.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.AllowDrop = True
        Me.Button4.BackColor = System.Drawing.Color.Salmon
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button4.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.DELETE_20
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(232, 34)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(102, 65)
        Me.Button4.TabIndex = 34
        Me.Button4.Text = "Supprimer"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel21)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Panel58)
        Me.Panel1.Location = New System.Drawing.Point(26, 147)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(315, 174)
        Me.Panel1.TabIndex = 37
        '
        'AddEditDepot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 344)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button45)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "AddEditDepot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Entrepotes"
        Me.Panel58.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel21.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvctg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DepotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ALMohassinDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel58 As System.Windows.Forms.Panel
    Friend WithEvents btcid As System.Windows.Forms.Button
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvctg As System.Windows.Forms.DataGridView
    Friend WithEvents ALMohassinDBDataSet As A1_GAESTION_COMMERCIAL.ALMohassinDBDataSet
    Friend WithEvents DepotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DepotTableAdapter As A1_GAESTION_COMMERCIAL.ALMohassinDBDataSetTableAdapters.DepotTableAdapter
    Friend WithEvents DpidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button45 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
