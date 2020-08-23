<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PvList
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
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape8 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.plClientSide = New System.Windows.Forms.Panel()
        Me.lbName = New System.Windows.Forms.Label()
        Me.plClient = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lbNbrBon = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSearchCode = New System.Windows.Forms.TextBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.FL = New System.Windows.Forms.FlowLayoutPanel()
        Me.PL = New System.Windows.Forms.Panel()
        Me.RPL = New A1_GAESTION_COMMERCIAL.RPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel26.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.plClientSide.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Panel26.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_13
        Me.Panel26.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel26.Controls.Add(Me.Panel4)
        Me.Panel26.Controls.Add(Me.plClientSide)
        Me.Panel26.Controls.Add(Me.Panel2)
        Me.Panel26.Controls.Add(Me.Panel8)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel26.Location = New System.Drawing.Point(386, 0)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(799, 42)
        Me.Panel26.TabIndex = 17
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Button10)
        Me.Panel4.Controls.Add(Me.ShapeContainer2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(326, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(195, 42)
        Me.Panel4.TabIndex = 9
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.FILE_22
        Me.Button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button10.Location = New System.Drawing.Point(31, 7)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(142, 28)
        Me.Button10.TabIndex = 2
        Me.Button10.Tag = "-1"
        Me.Button10.Text = "    GROUPES"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape8})
        Me.ShapeContainer2.Size = New System.Drawing.Size(195, 42)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape8
        '
        Me.RectangleShape8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape8.BackColor = System.Drawing.Color.LightSeaGreen
        Me.RectangleShape8.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape8.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RectangleShape8.CornerRadius = 14
        Me.RectangleShape8.Location = New System.Drawing.Point(17, 5)
        Me.RectangleShape8.Name = "RectangleShape1"
        Me.RectangleShape8.Size = New System.Drawing.Size(168, 31)
        '
        'plClientSide
        '
        Me.plClientSide.BackColor = System.Drawing.Color.Transparent
        Me.plClientSide.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.plClientSide.Controls.Add(Me.lbName)
        Me.plClientSide.Controls.Add(Me.Panel6)
        Me.plClientSide.Controls.Add(Me.plClient)
        Me.plClientSide.Controls.Add(Me.Panel1)
        Me.plClientSide.Controls.Add(Me.Panel5)
        Me.plClientSide.Controls.Add(Me.Panel3)
        Me.plClientSide.Controls.Add(Me.Label10)
        Me.plClientSide.Dock = System.Windows.Forms.DockStyle.Right
        Me.plClientSide.Location = New System.Drawing.Point(527, 0)
        Me.plClientSide.Name = "plClientSide"
        Me.plClientSide.Size = New System.Drawing.Size(272, 42)
        Me.plClientSide.TabIndex = 3
        '
        'lbName
        '
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbName.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbName.Location = New System.Drawing.Point(91, 0)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(81, 42)
        Me.lbName.TabIndex = 9
        Me.lbName.Text = "---"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plClient
        '
        Me.plClient.BackColor = System.Drawing.Color.Transparent
        Me.plClient.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_User_27887__1_
        Me.plClient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plClient.Dock = System.Windows.Forms.DockStyle.Left
        Me.plClient.Location = New System.Drawing.Point(59, 0)
        Me.plClient.Name = "plClient"
        Me.plClient.Size = New System.Drawing.Size(32, 42)
        Me.plClient.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LimeGreen
        Me.Panel1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_folder_add_61769
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(210, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(62, 42)
        Me.Panel1.TabIndex = 10
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.BG_STK
        Me.Panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel5.Controls.Add(Me.lbNbrBon)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(27, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(32, 42)
        Me.Panel5.TabIndex = 8
        '
        'lbNbrBon
        '
        Me.lbNbrBon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbNbrBon.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lbNbrBon.ForeColor = System.Drawing.Color.Red
        Me.lbNbrBon.Location = New System.Drawing.Point(0, 0)
        Me.lbNbrBon.Name = "lbNbrBon"
        Me.lbNbrBon.Size = New System.Drawing.Size(32, 42)
        Me.lbNbrBon.TabIndex = 9
        Me.lbNbrBon.Text = "00"
        Me.lbNbrBon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.arrow_down1
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(27, 42)
        Me.Panel3.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 17)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Fature à :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.txtSearchCode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(306, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(20, 42)
        Me.Panel2.TabIndex = 10
        '
        'txtSearchCode
        '
        Me.txtSearchCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearchCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchCode.Location = New System.Drawing.Point(-32, 5)
        Me.txtSearchCode.Name = "txtSearchCode"
        Me.txtSearchCode.Size = New System.Drawing.Size(31, 22)
        Me.txtSearchCode.TabIndex = 5
        Me.txtSearchCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.txtSearch)
        Me.Panel8.Controls.Add(Me.ShapeContainer3)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(306, 42)
        Me.Panel8.TabIndex = 6
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(35, 15)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(246, 15)
        Me.txtSearch.TabIndex = 5
        Me.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer3.Size = New System.Drawing.Size(306, 42)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.RectangleShape1.CornerRadius = 14
        Me.RectangleShape1.Location = New System.Drawing.Point(20, 5)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(277, 31)
        '
        'FL
        '
        Me.FL.AutoScroll = True
        Me.FL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FL.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FL.Location = New System.Drawing.Point(386, 87)
        Me.FL.Name = "FL"
        Me.FL.Size = New System.Drawing.Size(799, 833)
        Me.FL.TabIndex = 20
        '
        'PL
        '
        Me.PL.BackColor = System.Drawing.Color.Teal
        Me.PL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PL.Dock = System.Windows.Forms.DockStyle.Top
        Me.PL.Location = New System.Drawing.Point(386, 42)
        Me.PL.Name = "PL"
        Me.PL.Padding = New System.Windows.Forms.Padding(5)
        Me.PL.Size = New System.Drawing.Size(799, 45)
        Me.PL.TabIndex = 21
        Me.PL.Visible = False
        '
        'RPL
        '
        Me.RPL.Avance = New Decimal(New Integer() {0, 0, 0, 0})
        Me.RPL.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RPL.bl = "---"
        Me.RPL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RPL.delivredDay = Nothing
        Me.RPL.Dock = System.Windows.Forms.DockStyle.Left
        Me.RPL.EditMode = False
        Me.RPL.hasManyRemise = False
        Me.RPL.Location = New System.Drawing.Point(15, 0)
        Me.RPL.Name = "RPL"
        Me.RPL.Num = 0
        Me.RPL.Remise = "0"
        Me.RPL.ShowProfit = False
        Me.RPL.Size = New System.Drawing.Size(371, 920)
        Me.RPL.TabIndex = 18
        Me.RPL.TypePrinter = "&"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.MidnightBlue
        Me.Panel6.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(172, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(38, 42)
        Me.Panel6.TabIndex = 12
        '
        'PvList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.FL)
        Me.Controls.Add(Me.PL)
        Me.Controls.Add(Me.Panel26)
        Me.Controls.Add(Me.RPL)
        Me.Name = "PvList"
        Me.Padding = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.Size = New System.Drawing.Size(1200, 920)
        Me.Panel26.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.plClientSide.ResumeLayout(False)
        Me.plClientSide.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents plClientSide As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents RPL As A1_GAESTION_COMMERCIAL.RPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtSearchCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents FL As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lbNbrBon As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape8 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PL As System.Windows.Forms.Panel
    Friend WithEvents plClient As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel

End Class
