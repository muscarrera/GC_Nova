<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPayementRow
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
        Me.plRef = New System.Windows.Forms.Panel()
        Me.txtRef = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plleft = New System.Windows.Forms.Panel()
        Me.plEch = New System.Windows.Forms.Panel()
        Me.txtEch = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.PlRight = New System.Windows.Forms.Panel()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.plMontant = New System.Windows.Forms.Panel()
        Me.txtMontant = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plName = New System.Windows.Forms.Panel()
        Me.txtDesig = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtWay = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plWay = New System.Windows.Forms.Panel()
        Me.plRef.SuspendLayout()
        Me.plEch.SuspendLayout()
        Me.PlRight.SuspendLayout()
        Me.plMontant.SuspendLayout()
        Me.plName.SuspendLayout()
        Me.plWay.SuspendLayout()
        Me.SuspendLayout()
        '
        'plRef
        '
        Me.plRef.BackColor = System.Drawing.Color.Transparent
        Me.plRef.Controls.Add(Me.txtRef)
        Me.plRef.Dock = System.Windows.Forms.DockStyle.Left
        Me.plRef.Location = New System.Drawing.Point(420, 2)
        Me.plRef.Name = "plRef"
        Me.plRef.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plRef.Size = New System.Drawing.Size(214, 32)
        Me.plRef.TabIndex = 18
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRef.IsNumiric = False
        Me.txtRef.Location = New System.Drawing.Point(10, 0)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.PlaceHolder = ""
        Me.txtRef.ShowClearIcon = False
        Me.txtRef.ShowSaveIcon = False
        Me.txtRef.Size = New System.Drawing.Size(199, 32)
        Me.txtRef.StartUp = 2
        Me.txtRef.TabIndex = 1
        Me.txtRef.TextSize = 8
        Me.txtRef.TxtBackColor = True
        Me.txtRef.TxtColor = System.Drawing.Color.White
        Me.txtRef.txtReadOnly = False
        Me.txtRef.TxtSelect = New Integer() {1, 0}
        '
        'plleft
        '
        Me.plleft.BackColor = System.Drawing.Color.Transparent
        Me.plleft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.plleft.Location = New System.Drawing.Point(2, 2)
        Me.plleft.Name = "plleft"
        Me.plleft.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plleft.Size = New System.Drawing.Size(31, 32)
        Me.plleft.TabIndex = 15
        '
        'plEch
        '
        Me.plEch.BackColor = System.Drawing.Color.Transparent
        Me.plEch.Controls.Add(Me.txtEch)
        Me.plEch.Dock = System.Windows.Forms.DockStyle.Left
        Me.plEch.Location = New System.Drawing.Point(290, 2)
        Me.plEch.Name = "plEch"
        Me.plEch.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plEch.Size = New System.Drawing.Size(130, 32)
        Me.plEch.TabIndex = 20
        '
        'txtEch
        '
        Me.txtEch.BackColor = System.Drawing.Color.White
        Me.txtEch.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtEch.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtEch.IsNumiric = False
        Me.txtEch.Location = New System.Drawing.Point(10, 0)
        Me.txtEch.Name = "txtEch"
        Me.txtEch.PlaceHolder = ""
        Me.txtEch.ShowClearIcon = False
        Me.txtEch.ShowSaveIcon = False
        Me.txtEch.Size = New System.Drawing.Size(115, 32)
        Me.txtEch.StartUp = 2
        Me.txtEch.TabIndex = 1
        Me.txtEch.TextSize = 8
        Me.txtEch.TxtBackColor = True
        Me.txtEch.TxtColor = System.Drawing.Color.White
        Me.txtEch.txtReadOnly = True
        Me.txtEch.TxtSelect = New Integer() {1, 0}
        '
        'PlRight
        '
        Me.PlRight.BackColor = System.Drawing.Color.Transparent
        Me.PlRight.Controls.Add(Me.btAdd)
        Me.PlRight.Controls.Add(Me.btClear)
        Me.PlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PlRight.Location = New System.Drawing.Point(800, 2)
        Me.PlRight.Name = "PlRight"
        Me.PlRight.Size = New System.Drawing.Size(102, 32)
        Me.PlRight.TabIndex = 14
        '
        'btAdd
        '
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.btAdd.Location = New System.Drawing.Point(15, 0)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(44, 32)
        Me.btAdd.TabIndex = 5
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.CANCEL_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(59, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 32)
        Me.btClear.TabIndex = 4
        Me.btClear.UseVisualStyleBackColor = True
        '
        'plMontant
        '
        Me.plMontant.BackColor = System.Drawing.Color.Transparent
        Me.plMontant.Controls.Add(Me.txtMontant)
        Me.plMontant.Dock = System.Windows.Forms.DockStyle.Left
        Me.plMontant.Location = New System.Drawing.Point(165, 2)
        Me.plMontant.Name = "plMontant"
        Me.plMontant.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plMontant.Size = New System.Drawing.Size(125, 32)
        Me.plMontant.TabIndex = 17
        '
        'txtMontant
        '
        Me.txtMontant.BackColor = System.Drawing.Color.White
        Me.txtMontant.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtMontant.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMontant.IsNumiric = True
        Me.txtMontant.Location = New System.Drawing.Point(10, 0)
        Me.txtMontant.Name = "txtMontant"
        Me.txtMontant.PlaceHolder = ""
        Me.txtMontant.ShowClearIcon = False
        Me.txtMontant.ShowSaveIcon = False
        Me.txtMontant.Size = New System.Drawing.Size(110, 32)
        Me.txtMontant.StartUp = 2
        Me.txtMontant.TabIndex = 1
        Me.txtMontant.TextSize = 8
        Me.txtMontant.TxtBackColor = True
        Me.txtMontant.TxtColor = System.Drawing.Color.White
        Me.txtMontant.txtReadOnly = False
        Me.txtMontant.TxtSelect = New Integer() {1, 0}
        '
        'plName
        '
        Me.plName.BackColor = System.Drawing.Color.Transparent
        Me.plName.Controls.Add(Me.txtDesig)
        Me.plName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plName.Location = New System.Drawing.Point(634, 2)
        Me.plName.Name = "plName"
        Me.plName.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plName.Size = New System.Drawing.Size(166, 32)
        Me.plName.TabIndex = 19
        '
        'txtDesig
        '
        Me.txtDesig.BackColor = System.Drawing.Color.White
        Me.txtDesig.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtDesig.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDesig.IsNumiric = False
        Me.txtDesig.Location = New System.Drawing.Point(5, 0)
        Me.txtDesig.Name = "txtDesig"
        Me.txtDesig.PlaceHolder = ""
        Me.txtDesig.ShowClearIcon = False
        Me.txtDesig.ShowSaveIcon = False
        Me.txtDesig.Size = New System.Drawing.Size(156, 32)
        Me.txtDesig.StartUp = 2
        Me.txtDesig.TabIndex = 1
        Me.txtDesig.TextSize = 8
        Me.txtDesig.TxtBackColor = True
        Me.txtDesig.TxtColor = System.Drawing.Color.White
        Me.txtDesig.txtReadOnly = False
        Me.txtDesig.TxtSelect = New Integer() {1, 0}
        '
        'txtWay
        '
        Me.txtWay.BackColor = System.Drawing.Color.White
        Me.txtWay.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtWay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtWay.IsNumiric = False
        Me.txtWay.Location = New System.Drawing.Point(10, 0)
        Me.txtWay.Name = "txtWay"
        Me.txtWay.PlaceHolder = ""
        Me.txtWay.ShowClearIcon = False
        Me.txtWay.ShowSaveIcon = False
        Me.txtWay.Size = New System.Drawing.Size(117, 32)
        Me.txtWay.StartUp = 2
        Me.txtWay.TabIndex = 1
        Me.txtWay.TextSize = 8
        Me.txtWay.TxtBackColor = True
        Me.txtWay.TxtColor = System.Drawing.Color.White
        Me.txtWay.txtReadOnly = False
        Me.txtWay.TxtSelect = New Integer() {1, 0}
        '
        'plWay
        '
        Me.plWay.BackColor = System.Drawing.Color.Transparent
        Me.plWay.Controls.Add(Me.txtWay)
        Me.plWay.Dock = System.Windows.Forms.DockStyle.Left
        Me.plWay.Location = New System.Drawing.Point(33, 2)
        Me.plWay.Name = "plWay"
        Me.plWay.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plWay.Size = New System.Drawing.Size(132, 32)
        Me.plWay.TabIndex = 16
        '
        'AddPayementRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.gui_16
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.plName)
        Me.Controls.Add(Me.plRef)
        Me.Controls.Add(Me.plEch)
        Me.Controls.Add(Me.plMontant)
        Me.Controls.Add(Me.plWay)
        Me.Controls.Add(Me.plleft)
        Me.Controls.Add(Me.PlRight)
        Me.Name = "AddPayementRow"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(904, 36)
        Me.plRef.ResumeLayout(False)
        Me.plEch.ResumeLayout(False)
        Me.PlRight.ResumeLayout(False)
        Me.plMontant.ResumeLayout(False)
        Me.plName.ResumeLayout(False)
        Me.plWay.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plRef As System.Windows.Forms.Panel
    Friend WithEvents txtRef As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plleft As System.Windows.Forms.Panel
    Friend WithEvents plEch As System.Windows.Forms.Panel
    Friend WithEvents txtEch As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents PlRight As System.Windows.Forms.Panel
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents plMontant As System.Windows.Forms.Panel
    Friend WithEvents txtMontant As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plName As System.Windows.Forms.Panel
    Friend WithEvents txtDesig As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtWay As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plWay As System.Windows.Forms.Panel

End Class
