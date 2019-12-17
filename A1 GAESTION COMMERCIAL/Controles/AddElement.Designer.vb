<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddElement
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
        Me.plName = New System.Windows.Forms.Panel()
        Me.txtN = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.PlRight = New System.Windows.Forms.Panel()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.plQte = New System.Windows.Forms.Panel()
        Me.txtP = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plleft = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtQ = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txttotal = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plDate = New System.Windows.Forms.Panel()
        Me.txtDate = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plRef = New System.Windows.Forms.Panel()
        Me.txtRef = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plName.SuspendLayout()
        Me.PlRight.SuspendLayout()
        Me.plQte.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.plDate.SuspendLayout()
        Me.plRef.SuspendLayout()
        Me.SuspendLayout()
        '
        'plName
        '
        Me.plName.BackColor = System.Drawing.Color.Transparent
        Me.plName.Controls.Add(Me.txtN)
        Me.plName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plName.Location = New System.Drawing.Point(230, 2)
        Me.plName.Name = "plName"
        Me.plName.Padding = New System.Windows.Forms.Padding(15, 0, 5, 0)
        Me.plName.Size = New System.Drawing.Size(217, 31)
        Me.plName.TabIndex = 16
        '
        'txtN
        '
        Me.txtN.BackColor = System.Drawing.Color.White
        Me.txtN.BorderColor = System.Drawing.Color.White
        Me.txtN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtN.IsNumiric = False
        Me.txtN.Location = New System.Drawing.Point(15, 0)
        Me.txtN.Name = "txtN"
        Me.txtN.PlaceHolder = "Designation"
        Me.txtN.ShowClearIcon = False
        Me.txtN.ShowSaveIcon = False
        Me.txtN.Size = New System.Drawing.Size(197, 31)
        Me.txtN.StartUp = 2
        Me.txtN.TabIndex = 2
        Me.txtN.TextSize = 8
        Me.txtN.TxtBackColor = True
        Me.txtN.TxtColor = System.Drawing.Color.White
        Me.txtN.txtReadOnly = False
        Me.txtN.TxtSelect = New Integer() {1, 0}
        '
        'PlRight
        '
        Me.PlRight.BackColor = System.Drawing.Color.Transparent
        Me.PlRight.Controls.Add(Me.btAdd)
        Me.PlRight.Controls.Add(Me.btClear)
        Me.PlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PlRight.Location = New System.Drawing.Point(700, 2)
        Me.PlRight.Name = "PlRight"
        Me.PlRight.Size = New System.Drawing.Size(83, 31)
        Me.PlRight.TabIndex = 13
        '
        'btAdd
        '
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.btAdd.Location = New System.Drawing.Point(-4, 0)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(44, 31)
        Me.btAdd.TabIndex = 6
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.CANCEL_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(40, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 31)
        Me.btClear.TabIndex = 7
        Me.btClear.UseVisualStyleBackColor = True
        '
        'plQte
        '
        Me.plQte.BackColor = System.Drawing.Color.Transparent
        Me.plQte.Controls.Add(Me.txtP)
        Me.plQte.Dock = System.Windows.Forms.DockStyle.Right
        Me.plQte.Location = New System.Drawing.Point(516, 2)
        Me.plQte.Name = "plQte"
        Me.plQte.Padding = New System.Windows.Forms.Padding(5, 0, 2, 0)
        Me.plQte.Size = New System.Drawing.Size(90, 31)
        Me.plQte.TabIndex = 15
        '
        'txtP
        '
        Me.txtP.BackColor = System.Drawing.Color.White
        Me.txtP.BorderColor = System.Drawing.Color.White
        Me.txtP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtP.IsNumiric = True
        Me.txtP.Location = New System.Drawing.Point(5, 0)
        Me.txtP.Name = "txtP"
        Me.txtP.PlaceHolder = "Prix"
        Me.txtP.ShowClearIcon = False
        Me.txtP.ShowSaveIcon = False
        Me.txtP.Size = New System.Drawing.Size(83, 31)
        Me.txtP.StartUp = 2
        Me.txtP.TabIndex = 3
        Me.txtP.TextSize = 8
        Me.txtP.TxtBackColor = True
        Me.txtP.TxtColor = System.Drawing.Color.White
        Me.txtP.txtReadOnly = False
        Me.txtP.TxtSelect = New Integer() {1, 0}
        '
        'plleft
        '
        Me.plleft.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.plleft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plleft.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plleft.Location = New System.Drawing.Point(2, 33)
        Me.plleft.Name = "plleft"
        Me.plleft.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plleft.Size = New System.Drawing.Size(781, 1)
        Me.plleft.TabIndex = 14
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.txtQ)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(447, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5, 0, 2, 0)
        Me.Panel1.Size = New System.Drawing.Size(69, 31)
        Me.Panel1.TabIndex = 17
        '
        'txtQ
        '
        Me.txtQ.BackColor = System.Drawing.Color.White
        Me.txtQ.BorderColor = System.Drawing.Color.White
        Me.txtQ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQ.IsNumiric = True
        Me.txtQ.Location = New System.Drawing.Point(5, 0)
        Me.txtQ.Name = "txtQ"
        Me.txtQ.PlaceHolder = "Qte"
        Me.txtQ.ShowClearIcon = False
        Me.txtQ.ShowSaveIcon = False
        Me.txtQ.Size = New System.Drawing.Size(62, 31)
        Me.txtQ.StartUp = 2
        Me.txtQ.TabIndex = 3
        Me.txtQ.TextSize = 8
        Me.txtQ.TxtBackColor = True
        Me.txtQ.TxtColor = System.Drawing.Color.White
        Me.txtQ.txtReadOnly = False
        Me.txtQ.TxtSelect = New Integer() {1, 0}
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.txttotal)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(606, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(5, 0, 2, 0)
        Me.Panel2.Size = New System.Drawing.Size(94, 31)
        Me.Panel2.TabIndex = 18
        '
        'txttotal
        '
        Me.txttotal.BackColor = System.Drawing.Color.White
        Me.txttotal.BorderColor = System.Drawing.Color.White
        Me.txttotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txttotal.IsNumiric = True
        Me.txttotal.Location = New System.Drawing.Point(5, 0)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.PlaceHolder = "Total"
        Me.txttotal.ShowClearIcon = False
        Me.txttotal.ShowSaveIcon = False
        Me.txttotal.Size = New System.Drawing.Size(87, 31)
        Me.txttotal.StartUp = 2
        Me.txttotal.TabIndex = 3
        Me.txttotal.TextSize = 8
        Me.txttotal.TxtBackColor = True
        Me.txttotal.TxtColor = System.Drawing.Color.White
        Me.txttotal.txtReadOnly = False
        Me.txttotal.TxtSelect = New Integer() {1, 0}
        '
        'plDate
        '
        Me.plDate.BackColor = System.Drawing.Color.Transparent
        Me.plDate.Controls.Add(Me.txtDate)
        Me.plDate.Dock = System.Windows.Forms.DockStyle.Left
        Me.plDate.Location = New System.Drawing.Point(2, 2)
        Me.plDate.Name = "plDate"
        Me.plDate.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plDate.Size = New System.Drawing.Size(114, 31)
        Me.plDate.TabIndex = 19
        Me.plDate.Visible = False
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.BorderColor = System.Drawing.Color.White
        Me.txtDate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDate.IsNumiric = True
        Me.txtDate.Location = New System.Drawing.Point(10, 0)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.PlaceHolder = "22 MARS 2019"
        Me.txtDate.ShowClearIcon = False
        Me.txtDate.ShowSaveIcon = False
        Me.txtDate.Size = New System.Drawing.Size(99, 31)
        Me.txtDate.StartUp = 2
        Me.txtDate.TabIndex = 3
        Me.txtDate.TextSize = 8
        Me.txtDate.TxtBackColor = True
        Me.txtDate.TxtColor = System.Drawing.Color.White
        Me.txtDate.txtReadOnly = False
        Me.txtDate.TxtSelect = New Integer() {1, 0}
        '
        'plRef
        '
        Me.plRef.BackColor = System.Drawing.Color.Transparent
        Me.plRef.Controls.Add(Me.txtRef)
        Me.plRef.Dock = System.Windows.Forms.DockStyle.Left
        Me.plRef.Location = New System.Drawing.Point(116, 2)
        Me.plRef.Name = "plRef"
        Me.plRef.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plRef.Size = New System.Drawing.Size(114, 31)
        Me.plRef.TabIndex = 20
        Me.plRef.Visible = False
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.BorderColor = System.Drawing.Color.White
        Me.txtRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRef.IsNumiric = True
        Me.txtRef.Location = New System.Drawing.Point(10, 0)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.PlaceHolder = "***"
        Me.txtRef.ShowClearIcon = False
        Me.txtRef.ShowSaveIcon = False
        Me.txtRef.Size = New System.Drawing.Size(99, 31)
        Me.txtRef.StartUp = 2
        Me.txtRef.TabIndex = 3
        Me.txtRef.TextSize = 8
        Me.txtRef.TxtBackColor = True
        Me.txtRef.TxtColor = System.Drawing.Color.White
        Me.txtRef.txtReadOnly = False
        Me.txtRef.TxtSelect = New Integer() {1, 0}
        '
        'AddElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.plName)
        Me.Controls.Add(Me.plRef)
        Me.Controls.Add(Me.plDate)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.plQte)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PlRight)
        Me.Controls.Add(Me.plleft)
        Me.Name = "AddElement"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(785, 36)
        Me.plName.ResumeLayout(False)
        Me.PlRight.ResumeLayout(False)
        Me.plQte.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.plDate.ResumeLayout(False)
        Me.plRef.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plName As System.Windows.Forms.Panel
    Friend WithEvents txtN As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents PlRight As System.Windows.Forms.Panel
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents plQte As System.Windows.Forms.Panel
    Friend WithEvents txtP As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plleft As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtQ As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txttotal As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plDate As System.Windows.Forms.Panel
    Friend WithEvents txtDate As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plRef As System.Windows.Forms.Panel
    Friend WithEvents txtRef As A1_GAESTION_COMMERCIAL.TxtBox

End Class
