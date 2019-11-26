<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParcList
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
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.txtSearchCtg = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtSearchName = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plHeader = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.plAddEdit = New System.Windows.Forms.Panel()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.pl = New System.Windows.Forms.Panel()
        Me.plFooter = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btPage = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.plrightA = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.plL = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PB = New System.Windows.Forms.PictureBox()
        Me.btFournisseur = New System.Windows.Forms.Button()
        Me.btClient = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.plDetails = New System.Windows.Forms.Panel()
        Me.plList = New System.Windows.Forms.Panel()
        Me.ClientRow1 = New A1_GAESTION_COMMERCIAL.ClientRow()
        Me.Panel10.SuspendLayout()
        Me.plHeader.SuspendLayout()
        Me.plAddEdit.SuspendLayout()
        Me.pl.SuspendLayout()
        Me.plFooter.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.plrightA.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.plList.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(670, 2)
        Me.Panel11.TabIndex = 1
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.PictureBox8)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Controls.Add(Me.PB)
        Me.Panel10.Controls.Add(Me.txtSearchCtg)
        Me.Panel10.Controls.Add(Me.txtSearchName)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(5, 42)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(670, 104)
        Me.Panel10.TabIndex = 11
        '
        'txtSearchCtg
        '
        Me.txtSearchCtg.BackColor = System.Drawing.Color.Transparent
        Me.txtSearchCtg.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtSearchCtg.IsNumiric = False
        Me.txtSearchCtg.Location = New System.Drawing.Point(93, 17)
        Me.txtSearchCtg.Name = "txtSearchCtg"
        Me.txtSearchCtg.PlaceHolder = ""
        Me.txtSearchCtg.ShowClearIcon = True
        Me.txtSearchCtg.ShowSaveIcon = False
        Me.txtSearchCtg.Size = New System.Drawing.Size(101, 26)
        Me.txtSearchCtg.StartUp = 2
        Me.txtSearchCtg.TabIndex = 5
        Me.txtSearchCtg.TextSize = 10
        Me.txtSearchCtg.TxtBackColor = True
        Me.txtSearchCtg.TxtColor = System.Drawing.Color.White
        Me.txtSearchCtg.txtReadOnly = False
        Me.txtSearchCtg.TxtSelect = New Integer() {1, 0}
        '
        'txtSearchName
        '
        Me.txtSearchName.BackColor = System.Drawing.Color.Transparent
        Me.txtSearchName.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.txtSearchName.IsNumiric = False
        Me.txtSearchName.Location = New System.Drawing.Point(200, 17)
        Me.txtSearchName.Name = "txtSearchName"
        Me.txtSearchName.PlaceHolder = ""
        Me.txtSearchName.ShowClearIcon = True
        Me.txtSearchName.ShowSaveIcon = False
        Me.txtSearchName.Size = New System.Drawing.Size(255, 26)
        Me.txtSearchName.StartUp = 2
        Me.txtSearchName.TabIndex = 5
        Me.txtSearchName.TextSize = 10
        Me.txtSearchName.TxtBackColor = True
        Me.txtSearchName.TxtColor = System.Drawing.Color.White
        Me.txtSearchName.txtReadOnly = False
        Me.txtSearchName.TxtSelect = New Integer() {1, 0}
        '
        'plHeader
        '
        Me.plHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plHeader.Controls.Add(Me.Panel9)
        Me.plHeader.Controls.Add(Me.btFournisseur)
        Me.plHeader.Controls.Add(Me.Button11)
        Me.plHeader.Controls.Add(Me.btClient)
        Me.plHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.plHeader.Location = New System.Drawing.Point(5, 5)
        Me.plHeader.Name = "plHeader"
        Me.plHeader.Size = New System.Drawing.Size(670, 37)
        Me.plHeader.TabIndex = 10
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(670, 2)
        Me.Panel9.TabIndex = 1
        '
        'plAddEdit
        '
        Me.plAddEdit.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plAddEdit.Controls.Add(Me.Button5)
        Me.plAddEdit.Controls.Add(Me.Button1)
        Me.plAddEdit.Controls.Add(Me.Button7)
        Me.plAddEdit.Controls.Add(Me.Button6)
        Me.plAddEdit.Controls.Add(Me.Panel29)
        Me.plAddEdit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plAddEdit.Location = New System.Drawing.Point(5, 146)
        Me.plAddEdit.Name = "plAddEdit"
        Me.plAddEdit.Size = New System.Drawing.Size(670, 38)
        Me.plAddEdit.TabIndex = 4
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(670, 2)
        Me.Panel29.TabIndex = 1
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.DarkCyan
        Me.Button9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(334, 3)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 31)
        Me.Button9.TabIndex = 19
        Me.Button9.Tag = "1"
        Me.Button9.Text = "الدفعات"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Button10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Location = New System.Drawing.Point(3, 3)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(128, 31)
        Me.Button10.TabIndex = 9
        Me.Button10.Tag = "1"
        Me.Button10.Text = "Etat Clients"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.BackColor = System.Drawing.Color.Transparent
        Me.pl.Controls.Add(Me.plList)
        Me.pl.Controls.Add(Me.plDetails)
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(5, 247)
        Me.pl.Name = "pl"
        Me.pl.Padding = New System.Windows.Forms.Padding(5)
        Me.pl.Size = New System.Drawing.Size(680, 631)
        Me.pl.TabIndex = 12
        '
        'plFooter
        '
        Me.plFooter.BackColor = System.Drawing.Color.WhiteSmoke
        Me.plFooter.Controls.Add(Me.Button2)
        Me.plFooter.Controls.Add(Me.Button4)
        Me.plFooter.Controls.Add(Me.btPage)
        Me.plFooter.Controls.Add(Me.Panel5)
        Me.plFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plFooter.Location = New System.Drawing.Point(5, 878)
        Me.plFooter.Name = "plFooter"
        Me.plFooter.Size = New System.Drawing.Size(680, 37)
        Me.plFooter.TabIndex = 13
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Button2.Location = New System.Drawing.Point(607, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Button2.Size = New System.Drawing.Size(60, 28)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Button4.Location = New System.Drawing.Point(475, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Button4.Size = New System.Drawing.Size(60, 28)
        Me.Button4.TabIndex = 2
        Me.Button4.Text = "<"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btPage
        '
        Me.btPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btPage.Enabled = False
        Me.btPage.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btPage.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btPage.Location = New System.Drawing.Point(541, 4)
        Me.btPage.Name = "btPage"
        Me.btPage.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btPage.Size = New System.Drawing.Size(60, 28)
        Me.btPage.TabIndex = 2
        Me.btPage.Text = "-"
        Me.btPage.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(680, 2)
        Me.Panel5.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.pl)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.plFooter)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(105, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel2.Size = New System.Drawing.Size(690, 920)
        Me.Panel2.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.plrightA)
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.plHeader)
        Me.Panel3.Controls.Add(Me.plAddEdit)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(5, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(5, 5, 5, 15)
        Me.Panel3.Size = New System.Drawing.Size(680, 199)
        Me.Panel3.TabIndex = 11
        '
        'plrightA
        '
        Me.plrightA.BackColor = System.Drawing.Color.DimGray
        Me.plrightA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plrightA.Controls.Add(Me.Button9)
        Me.plrightA.Controls.Add(Me.Button3)
        Me.plrightA.Controls.Add(Me.Button8)
        Me.plrightA.Controls.Add(Me.Button10)
        Me.plrightA.Controls.Add(Me.Button14)
        Me.plrightA.Controls.Add(Me.Button15)
        Me.plrightA.Controls.Add(Me.TextBox5)
        Me.plrightA.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plrightA.Location = New System.Drawing.Point(5, 109)
        Me.plrightA.Name = "plrightA"
        Me.plrightA.Padding = New System.Windows.Forms.Padding(3)
        Me.plrightA.Size = New System.Drawing.Size(670, 37)
        Me.plrightA.TabIndex = 16
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(259, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 31)
        Me.Button3.TabIndex = 18
        Me.Button3.Tag = "1"
        Me.Button3.Text = "الدين"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.DarkGreen
        Me.Button8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(131, 3)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(128, 31)
        Me.Button8.TabIndex = 11
        Me.Button8.Tag = "1"
        Me.Button8.Text = "Op. Général"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button14
        '
        Me.Button14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button14.Location = New System.Drawing.Point(1121, 11)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(56, 24)
        Me.Button14.TabIndex = 1
        Me.Button14.Text = "الغاء"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button15.Location = New System.Drawing.Point(1179, 12)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(56, 24)
        Me.Button15.TabIndex = 1
        Me.Button15.Text = "بحث"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.Location = New System.Drawing.Point(1241, 13)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(187, 20)
        Me.TextBox5.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(795, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(105, 920)
        Me.Panel1.TabIndex = 15
        '
        'plL
        '
        Me.plL.BackColor = System.Drawing.Color.Transparent
        Me.plL.Dock = System.Windows.Forms.DockStyle.Left
        Me.plL.Location = New System.Drawing.Point(0, 0)
        Me.plL.Name = "plL"
        Me.plL.Padding = New System.Windows.Forms.Padding(5)
        Me.plL.Size = New System.Drawing.Size(105, 920)
        Me.plL.TabIndex = 14
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(5, 204)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(680, 43)
        Me.Panel6.TabIndex = 14
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(680, 2)
        Me.Panel7.TabIndex = 1
        '
        'PictureBox8
        '
        Me.PictureBox8.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.search_folder_18
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox8.Location = New System.Drawing.Point(461, 17)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(68, 26)
        Me.PictureBox8.TabIndex = 10
        Me.PictureBox8.TabStop = False
        '
        'PB
        '
        Me.PB.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_kde_folder_saved_search_25195
        Me.PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PB.Location = New System.Drawing.Point(8, 7)
        Me.PB.Name = "PB"
        Me.PB.Size = New System.Drawing.Size(72, 45)
        Me.PB.TabIndex = 9
        Me.PB.TabStop = False
        '
        'btFournisseur
        '
        Me.btFournisseur.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFournisseur.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btFournisseur.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btFournisseur.ForeColor = System.Drawing.Color.DarkGray
        Me.btFournisseur.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.btFournisseur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btFournisseur.Location = New System.Drawing.Point(546, 5)
        Me.btFournisseur.Name = "btFournisseur"
        Me.btFournisseur.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btFournisseur.Size = New System.Drawing.Size(116, 28)
        Me.btFournisseur.TabIndex = 2
        Me.btFournisseur.Tag = "Vehicule"
        Me.btFournisseur.Text = "Vehicules"
        Me.btFournisseur.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btFournisseur.UseVisualStyleBackColor = True
        '
        'btClient
        '
        Me.btClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClient.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btClient.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.btClient.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.btClient.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btClient.Location = New System.Drawing.Point(413, 5)
        Me.btClient.Name = "btClient"
        Me.btClient.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.btClient.Size = New System.Drawing.Size(127, 28)
        Me.btClient.TabIndex = 2
        Me.btClient.Tag = "Driver"
        Me.btClient.Text = "Chauffeurs"
        Me.btClient.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Button5.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_agt_print_3826__1_
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(569, 2)
        Me.Button5.Name = "Button5"
        Me.Button5.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Button5.Size = New System.Drawing.Size(93, 34)
        Me.Button5.TabIndex = 3
        Me.Button5.Text = "Imprimer"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_folder_delete_61770
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(223, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Button1.Size = New System.Drawing.Size(99, 33)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Supprimer"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Folder_Settings_Tools_icon_88583_X_24
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(118, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Padding = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Button7.Size = New System.Drawing.Size(99, 33)
        Me.Button7.TabIndex = 2
        Me.Button7.Text = "Modifier"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_folder_add_61769
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(13, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button6.Size = New System.Drawing.Size(99, 33)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "Ajouter"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button11.BackColor = System.Drawing.Color.PaleGreen
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.Green
        Me.Button11.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button11.Location = New System.Drawing.Point(4, 5)
        Me.Button11.Name = "Button11"
        Me.Button11.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button11.Size = New System.Drawing.Size(127, 28)
        Me.Button11.TabIndex = 2
        Me.Button11.Tag = "Mission"
        Me.Button11.Text = "Mission"
        Me.Button11.UseVisualStyleBackColor = False
        '
        'plDetails
        '
        Me.plDetails.Dock = System.Windows.Forms.DockStyle.Left
        Me.plDetails.Location = New System.Drawing.Point(5, 5)
        Me.plDetails.Name = "plDetails"
        Me.plDetails.Size = New System.Drawing.Size(14, 621)
        Me.plDetails.TabIndex = 0
        '
        'plList
        '
        Me.plList.Controls.Add(Me.ClientRow1)
        Me.plList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plList.Location = New System.Drawing.Point(19, 5)
        Me.plList.Name = "plList"
        Me.plList.Size = New System.Drawing.Size(656, 621)
        Me.plList.TabIndex = 1
        '
        'ClientRow1
        '
        Me.ClientRow1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientRow1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ClientRow1.Id = 9
        Me.ClientRow1.Index = 8
        Me.ClientRow1.isCompany = True
        Me.ClientRow1.isEdited = False
        Me.ClientRow1.isSelected = False
        Me.ClientRow1.Libele = "designation"
        Me.ClientRow1.Location = New System.Drawing.Point(0, 0)
        Me.ClientRow1.Name = "ClientRow1"
        Me.ClientRow1.Responsable = "ee"
        Me.ClientRow1.Size = New System.Drawing.Size(656, 33)
        Me.ClientRow1.TabIndex = 0
        Me.ClientRow1.Tel = "ee"
        Me.ClientRow1.Ville = "ee"
        '
        'ParcList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.plL)
        Me.Name = "ParcList"
        Me.Size = New System.Drawing.Size(900, 920)
        Me.Panel10.ResumeLayout(False)
        Me.plHeader.ResumeLayout(False)
        Me.plAddEdit.ResumeLayout(False)
        Me.pl.ResumeLayout(False)
        Me.plFooter.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.plrightA.ResumeLayout(False)
        Me.plrightA.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.plList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents PB As System.Windows.Forms.PictureBox
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents txtSearchCtg As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtSearchName As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents btFournisseur As System.Windows.Forms.Button
    Friend WithEvents btClient As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents plAddEdit As System.Windows.Forms.Panel
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents btPage As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents plrightA As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents plL As System.Windows.Forms.Panel
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents plList As System.Windows.Forms.Panel
    Friend WithEvents plDetails As System.Windows.Forms.Panel
    Friend WithEvents plFooter As System.Windows.Forms.Panel
    Friend WithEvents ClientRow1 As A1_GAESTION_COMMERCIAL.ClientRow

End Class
