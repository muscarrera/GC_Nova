<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddRow
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
        Me.PlRight = New System.Windows.Forms.Panel()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.plRef = New System.Windows.Forms.Panel()
        Me.plName = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.plQte = New System.Windows.Forms.Panel()
        Me.plPrice = New System.Windows.Forms.Panel()
        Me.plRemise = New System.Windows.Forms.Panel()
        Me.plleft = New System.Windows.Forms.Panel()
        Me.plTotal = New System.Windows.Forms.Panel()
        Me.txtName = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtRef = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtQte = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtPrice = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtRemise = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtTotal = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtRemis = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.PlRight.SuspendLayout()
        Me.plRef.SuspendLayout()
        Me.plName.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.plQte.SuspendLayout()
        Me.plPrice.SuspendLayout()
        Me.plRemise.SuspendLayout()
        Me.plTotal.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlRight
        '
        Me.PlRight.BackColor = System.Drawing.Color.Gainsboro
        Me.PlRight.Controls.Add(Me.btClear)
        Me.PlRight.Controls.Add(Me.btAdd)
        Me.PlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.PlRight.Location = New System.Drawing.Point(792, 0)
        Me.PlRight.Name = "PlRight"
        Me.PlRight.Size = New System.Drawing.Size(112, 40)
        Me.PlRight.TabIndex = 4
        '
        'btClear
        '
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.CANCEL_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Left
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(44, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 40)
        Me.btClear.TabIndex = 4
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.btAdd.Location = New System.Drawing.Point(0, 0)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(44, 40)
        Me.btAdd.TabIndex = 5
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'plRef
        '
        Me.plRef.Controls.Add(Me.plName)
        Me.plRef.Controls.Add(Me.Panel7)
        Me.plRef.Controls.Add(Me.plQte)
        Me.plRef.Controls.Add(Me.plPrice)
        Me.plRef.Controls.Add(Me.plRemise)
        Me.plRef.Controls.Add(Me.plleft)
        Me.plRef.Controls.Add(Me.plTotal)
        Me.plRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plRef.Location = New System.Drawing.Point(0, 0)
        Me.plRef.Name = "plRef"
        Me.plRef.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.plRef.Size = New System.Drawing.Size(792, 40)
        Me.plRef.TabIndex = 5
        '
        'plName
        '
        Me.plName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plName.Location = New System.Drawing.Point(146, 2)
        Me.plName.Name = "plName"
        Me.plName.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plName.Size = New System.Drawing.Size(291, 36)
        Me.plName.TabIndex = 12
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(34, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel7.Size = New System.Drawing.Size(112, 36)
        Me.Panel7.TabIndex = 11
        '
        'plQte
        '
        Me.plQte.Dock = System.Windows.Forms.DockStyle.Right
        Me.plQte.Location = New System.Drawing.Point(437, 2)
        Me.plQte.Name = "plQte"
        Me.plQte.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plQte.Size = New System.Drawing.Size(88, 36)
        Me.plQte.TabIndex = 10
        '
        'plPrice
        '
        Me.plPrice.Dock = System.Windows.Forms.DockStyle.Right
        Me.plPrice.Location = New System.Drawing.Point(525, 2)
        Me.plPrice.Name = "plPrice"
        Me.plPrice.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plPrice.Size = New System.Drawing.Size(88, 36)
        Me.plPrice.TabIndex = 9
        '
        'plRemise
        '
        Me.plRemise.Dock = System.Windows.Forms.DockStyle.Right
        Me.plRemise.Location = New System.Drawing.Point(613, 2)
        Me.plRemise.Name = "plRemise"
        Me.plRemise.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plRemise.Size = New System.Drawing.Size(88, 36)
        Me.plRemise.TabIndex = 7
        '
        'plleft
        '
        Me.plleft.BackColor = System.Drawing.Color.Transparent
        Me.plleft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.plleft.Location = New System.Drawing.Point(3, 2)
        Me.plleft.Name = "plleft"
        Me.plleft.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plleft.Size = New System.Drawing.Size(31, 36)
        Me.plleft.TabIndex = 6
        '
        'plTotal
        '
        Me.plTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.plTotal.Location = New System.Drawing.Point(701, 2)
        Me.plTotal.Name = "plTotal"
        Me.plTotal.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plTotal.Size = New System.Drawing.Size(88, 36)
        Me.plTotal.TabIndex = 13
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.IsNumiric = False
        Me.txtName.Location = New System.Drawing.Point(5, 0)
        Me.txtName.Name = "txtName"
        Me.txtName.PlaceHolder = "Designation"
        Me.txtName.ShowClearIcon = False
        Me.txtName.ShowSaveIcon = False
        Me.txtName.Size = New System.Drawing.Size(281, 36)
        Me.txtName.StartUp = 2
        Me.txtName.TabIndex = 0
        Me.txtName.TextSize = 8
        Me.txtName.TxtBackColor = True
        Me.txtName.TxtColor = System.Drawing.Color.White
        Me.txtName.txtReadOnly = False
        Me.txtName.TxtSelect = New Integer() {1, 0}
        '
        'txtRef
        '
        Me.txtRef.BackColor = System.Drawing.Color.White
        Me.txtRef.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRef.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRef.IsNumiric = False
        Me.txtRef.Location = New System.Drawing.Point(5, 0)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.PlaceHolder = "Réf"
        Me.txtRef.ShowClearIcon = False
        Me.txtRef.ShowSaveIcon = False
        Me.txtRef.Size = New System.Drawing.Size(102, 36)
        Me.txtRef.StartUp = 2
        Me.txtRef.TabIndex = 0
        Me.txtRef.TextSize = 8
        Me.txtRef.TxtBackColor = True
        Me.txtRef.TxtColor = System.Drawing.Color.White
        Me.txtRef.txtReadOnly = False
        Me.txtRef.TxtSelect = New Integer() {1, 0}
        '
        'txtQte
        '
        Me.txtQte.BackColor = System.Drawing.Color.Transparent
        Me.txtQte.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtQte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQte.IsNumiric = True
        Me.txtQte.Location = New System.Drawing.Point(10, 0)
        Me.txtQte.Name = "txtQte"
        Me.txtQte.PlaceHolder = ""
        Me.txtQte.ShowClearIcon = False
        Me.txtQte.ShowSaveIcon = False
        Me.txtQte.Size = New System.Drawing.Size(73, 36)
        Me.txtQte.StartUp = 2
        Me.txtQte.TabIndex = 0
        Me.txtQte.TextSize = 8
        Me.txtQte.TxtBackColor = True
        Me.txtQte.TxtColor = System.Drawing.Color.White
        Me.txtQte.txtReadOnly = False
        Me.txtQte.TxtSelect = New Integer() {1, 0}
        '
        'txtPrice
        '
        Me.txtPrice.BackColor = System.Drawing.Color.Transparent
        Me.txtPrice.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPrice.IsNumiric = True
        Me.txtPrice.Location = New System.Drawing.Point(10, 0)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.PlaceHolder = ""
        Me.txtPrice.ShowClearIcon = False
        Me.txtPrice.ShowSaveIcon = False
        Me.txtPrice.Size = New System.Drawing.Size(73, 36)
        Me.txtPrice.StartUp = 2
        Me.txtPrice.TabIndex = 0
        Me.txtPrice.TextSize = 8
        Me.txtPrice.TxtBackColor = True
        Me.txtPrice.TxtColor = System.Drawing.Color.White
        Me.txtPrice.txtReadOnly = False
        Me.txtPrice.TxtSelect = New Integer() {1, 0}
        '
        'txtRemise
        '
        Me.txtRemise.BackColor = System.Drawing.Color.Transparent
        Me.txtRemise.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRemise.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRemise.IsNumiric = True
        Me.txtRemise.Location = New System.Drawing.Point(10, 0)
        Me.txtRemise.Name = "txtRemise"
        Me.txtRemise.PlaceHolder = ""
        Me.txtRemise.ShowClearIcon = False
        Me.txtRemise.ShowSaveIcon = False
        Me.txtRemise.Size = New System.Drawing.Size(73, 36)
        Me.txtRemise.StartUp = 2
        Me.txtRemise.TabIndex = 0
        Me.txtRemise.TextSize = 8
        Me.txtRemise.TxtBackColor = True
        Me.txtRemise.TxtColor = System.Drawing.Color.White
        Me.txtRemise.txtReadOnly = False
        Me.txtRemise.TxtSelect = New Integer() {1, 0}
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.Transparent
        Me.txtTotal.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtTotal.IsNumiric = True
        Me.txtTotal.Location = New System.Drawing.Point(10, 0)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.PlaceHolder = ""
        Me.txtTotal.ShowClearIcon = False
        Me.txtTotal.ShowSaveIcon = False
        Me.txtTotal.Size = New System.Drawing.Size(73, 36)
        Me.txtTotal.StartUp = 2
        Me.txtTotal.TabIndex = 0
        Me.txtTotal.TextSize = 8
        Me.txtTotal.TxtBackColor = True
        Me.txtTotal.TxtColor = System.Drawing.Color.White
        Me.txtTotal.txtReadOnly = True
        Me.txtTotal.TxtSelect = New Integer() {1, 0}
        '
        'txtRemis
        '
        Me.txtRemis.BackColor = System.Drawing.Color.Maroon
        Me.txtRemis.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRemis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRemis.IsNumiric = True
        Me.txtRemis.Location = New System.Drawing.Point(10, 0)
        Me.txtRemis.Name = "txtRemis"
        Me.txtRemis.PlaceHolder = ""
        Me.txtRemis.ShowClearIcon = False
        Me.txtRemis.ShowSaveIcon = False
        Me.txtRemis.Size = New System.Drawing.Size(73, 23)
        Me.txtRemis.StartUp = 2
        Me.txtRemis.TabIndex = 0
        Me.txtRemis.TextSize = 8
        Me.txtRemis.TxtBackColor = True
        Me.txtRemis.TxtColor = System.Drawing.Color.White
        Me.txtRemis.txtReadOnly = False
        Me.txtRemis.TxtSelect = New Integer() {1, 0}
        '
        'AddRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.plRef)
        Me.Controls.Add(Me.PlRight)
        Me.Name = "AddRow"
        Me.Size = New System.Drawing.Size(904, 40)
        Me.PlRight.ResumeLayout(False)
        Me.plRef.ResumeLayout(False)
        Me.plName.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.plQte.ResumeLayout(False)
        Me.plPrice.ResumeLayout(False)
        Me.plRemise.ResumeLayout(False)
        Me.plTotal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PlRight As System.Windows.Forms.Panel
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents plRef As System.Windows.Forms.Panel
    Friend WithEvents plRemise As System.Windows.Forms.Panel
    Friend WithEvents plleft As System.Windows.Forms.Panel
    Friend WithEvents plName As System.Windows.Forms.Panel
    Friend WithEvents txtName As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtRef As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plQte As System.Windows.Forms.Panel
    Friend WithEvents txtQte As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plPrice As System.Windows.Forms.Panel
    Friend WithEvents txtPrice As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtRemis As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtRemise As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plTotal As System.Windows.Forms.Panel
    Friend WithEvents txtTotal As A1_GAESTION_COMMERCIAL.TxtBox

End Class
