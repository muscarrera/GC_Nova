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
        Me.txtN = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtRf = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plQte = New System.Windows.Forms.Panel()
        Me.txtQ = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plPrice = New System.Windows.Forms.Panel()
        Me.txtPr = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plRemise = New System.Windows.Forms.Panel()
        Me.txtRs = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plleft = New System.Windows.Forms.Panel()
        Me.plTotal = New System.Windows.Forms.Panel()
        Me.txtttc = New A1_GAESTION_COMMERCIAL.TxtBox()
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
        Me.PlRight.Size = New System.Drawing.Size(112, 36)
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
        Me.btClear.Size = New System.Drawing.Size(43, 36)
        Me.btClear.TabIndex = 7
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
        Me.btAdd.Size = New System.Drawing.Size(44, 36)
        Me.btAdd.TabIndex = 6
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
        Me.plRef.Size = New System.Drawing.Size(792, 36)
        Me.plRef.TabIndex = 5
        '
        'plName
        '
        Me.plName.Controls.Add(Me.txtN)
        Me.plName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plName.Location = New System.Drawing.Point(146, 2)
        Me.plName.Name = "plName"
        Me.plName.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plName.Size = New System.Drawing.Size(291, 32)
        Me.plName.TabIndex = 12
        '
        'txtN
        '
        Me.txtN.BackColor = System.Drawing.Color.White
        Me.txtN.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtN.IsNumiric = False
        Me.txtN.Location = New System.Drawing.Point(5, 0)
        Me.txtN.Name = "txtN"
        Me.txtN.PlaceHolder = "Designation"
        Me.txtN.ShowClearIcon = False
        Me.txtN.ShowSaveIcon = False
        Me.txtN.Size = New System.Drawing.Size(281, 32)
        Me.txtN.StartUp = 2
        Me.txtN.TabIndex = 2
        Me.txtN.TextSize = 8
        Me.txtN.TxtBackColor = True
        Me.txtN.TxtColor = System.Drawing.Color.White
        Me.txtN.txtReadOnly = False
        Me.txtN.TxtSelect = New Integer() {1, 0}
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.txtRf)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(34, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Panel7.Size = New System.Drawing.Size(112, 32)
        Me.Panel7.TabIndex = 11
        '
        'txtRf
        '
        Me.txtRf.BackColor = System.Drawing.Color.White
        Me.txtRf.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRf.IsNumiric = False
        Me.txtRf.Location = New System.Drawing.Point(5, 0)
        Me.txtRf.Name = "txtRf"
        Me.txtRf.PlaceHolder = "Réf"
        Me.txtRf.ShowClearIcon = False
        Me.txtRf.ShowSaveIcon = False
        Me.txtRf.Size = New System.Drawing.Size(102, 32)
        Me.txtRf.StartUp = 2
        Me.txtRf.TabIndex = 1
        Me.txtRf.TextSize = 8
        Me.txtRf.TxtBackColor = True
        Me.txtRf.TxtColor = System.Drawing.Color.White
        Me.txtRf.txtReadOnly = False
        Me.txtRf.TxtSelect = New Integer() {1, 0}
        '
        'plQte
        '
        Me.plQte.Controls.Add(Me.txtQ)
        Me.plQte.Dock = System.Windows.Forms.DockStyle.Right
        Me.plQte.Location = New System.Drawing.Point(437, 2)
        Me.plQte.Name = "plQte"
        Me.plQte.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plQte.Size = New System.Drawing.Size(88, 32)
        Me.plQte.TabIndex = 10
        '
        'txtQ
        '
        Me.txtQ.BackColor = System.Drawing.Color.White
        Me.txtQ.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtQ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQ.IsNumiric = True
        Me.txtQ.Location = New System.Drawing.Point(10, 0)
        Me.txtQ.Name = "txtQ"
        Me.txtQ.PlaceHolder = "Qte"
        Me.txtQ.ShowClearIcon = False
        Me.txtQ.ShowSaveIcon = False
        Me.txtQ.Size = New System.Drawing.Size(73, 32)
        Me.txtQ.StartUp = 2
        Me.txtQ.TabIndex = 3
        Me.txtQ.TextSize = 8
        Me.txtQ.TxtBackColor = True
        Me.txtQ.TxtColor = System.Drawing.Color.White
        Me.txtQ.txtReadOnly = False
        Me.txtQ.TxtSelect = New Integer() {1, 0}
        '
        'plPrice
        '
        Me.plPrice.Controls.Add(Me.txtPr)
        Me.plPrice.Dock = System.Windows.Forms.DockStyle.Right
        Me.plPrice.Location = New System.Drawing.Point(525, 2)
        Me.plPrice.Name = "plPrice"
        Me.plPrice.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plPrice.Size = New System.Drawing.Size(88, 32)
        Me.plPrice.TabIndex = 9
        '
        'txtPr
        '
        Me.txtPr.BackColor = System.Drawing.Color.White
        Me.txtPr.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtPr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPr.IsNumiric = True
        Me.txtPr.Location = New System.Drawing.Point(10, 0)
        Me.txtPr.Name = "txtPr"
        Me.txtPr.PlaceHolder = "Prix"
        Me.txtPr.ShowClearIcon = False
        Me.txtPr.ShowSaveIcon = False
        Me.txtPr.Size = New System.Drawing.Size(73, 32)
        Me.txtPr.StartUp = 2
        Me.txtPr.TabIndex = 4
        Me.txtPr.TextSize = 8
        Me.txtPr.TxtBackColor = True
        Me.txtPr.TxtColor = System.Drawing.Color.White
        Me.txtPr.txtReadOnly = False
        Me.txtPr.TxtSelect = New Integer() {1, 0}
        '
        'plRemise
        '
        Me.plRemise.Controls.Add(Me.txtRs)
        Me.plRemise.Dock = System.Windows.Forms.DockStyle.Right
        Me.plRemise.Location = New System.Drawing.Point(613, 2)
        Me.plRemise.Name = "plRemise"
        Me.plRemise.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plRemise.Size = New System.Drawing.Size(88, 32)
        Me.plRemise.TabIndex = 7
        '
        'txtRs
        '
        Me.txtRs.BackColor = System.Drawing.Color.White
        Me.txtRs.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtRs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtRs.IsNumiric = True
        Me.txtRs.Location = New System.Drawing.Point(10, 0)
        Me.txtRs.Name = "txtRs"
        Me.txtRs.PlaceHolder = "Remise"
        Me.txtRs.ShowClearIcon = False
        Me.txtRs.ShowSaveIcon = False
        Me.txtRs.Size = New System.Drawing.Size(73, 32)
        Me.txtRs.StartUp = 2
        Me.txtRs.TabIndex = 5
        Me.txtRs.TextSize = 8
        Me.txtRs.TxtBackColor = True
        Me.txtRs.TxtColor = System.Drawing.Color.White
        Me.txtRs.txtReadOnly = False
        Me.txtRs.TxtSelect = New Integer() {1, 0}
        '
        'plleft
        '
        Me.plleft.BackColor = System.Drawing.Color.Transparent
        Me.plleft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plleft.Dock = System.Windows.Forms.DockStyle.Left
        Me.plleft.Location = New System.Drawing.Point(3, 2)
        Me.plleft.Name = "plleft"
        Me.plleft.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.plleft.Size = New System.Drawing.Size(31, 32)
        Me.plleft.TabIndex = 6
        '
        'plTotal
        '
        Me.plTotal.Controls.Add(Me.txtttc)
        Me.plTotal.Dock = System.Windows.Forms.DockStyle.Right
        Me.plTotal.Location = New System.Drawing.Point(701, 2)
        Me.plTotal.Name = "plTotal"
        Me.plTotal.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plTotal.Size = New System.Drawing.Size(88, 32)
        Me.plTotal.TabIndex = 13
        '
        'txtttc
        '
        Me.txtttc.BackColor = System.Drawing.Color.White
        Me.txtttc.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtttc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtttc.IsNumiric = True
        Me.txtttc.Location = New System.Drawing.Point(10, 0)
        Me.txtttc.Name = "txtttc"
        Me.txtttc.PlaceHolder = ""
        Me.txtttc.ShowClearIcon = False
        Me.txtttc.ShowSaveIcon = False
        Me.txtttc.Size = New System.Drawing.Size(73, 32)
        Me.txtttc.StartUp = 2
        Me.txtttc.TabIndex = 58
        Me.txtttc.TextSize = 8
        Me.txtttc.TxtBackColor = True
        Me.txtttc.TxtColor = System.Drawing.Color.White
        Me.txtttc.txtReadOnly = True
        Me.txtttc.TxtSelect = New Integer() {1, 0}
        '
        'AddRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.Add(Me.plRef)
        Me.Controls.Add(Me.PlRight)
        Me.Name = "AddRow"
        Me.Size = New System.Drawing.Size(904, 36)
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
    Friend WithEvents txtN As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtRf As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtQ As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtPr As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtRs As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtttc As A1_GAESTION_COMMERCIAL.TxtBox

End Class
