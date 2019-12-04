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
        Me.txtQ = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.plleft = New System.Windows.Forms.Panel()
        Me.plName.SuspendLayout()
        Me.PlRight.SuspendLayout()
        Me.plQte.SuspendLayout()
        Me.SuspendLayout()
        '
        'plName
        '
        Me.plName.BackColor = System.Drawing.Color.Transparent
        Me.plName.Controls.Add(Me.txtN)
        Me.plName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plName.Location = New System.Drawing.Point(2, 2)
        Me.plName.Name = "plName"
        Me.plName.Padding = New System.Windows.Forms.Padding(22, 0, 5, 0)
        Me.plName.Size = New System.Drawing.Size(455, 31)
        Me.plName.TabIndex = 16
        '
        'txtN
        '
        Me.txtN.BackColor = System.Drawing.Color.White
        Me.txtN.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtN.IsNumiric = False
        Me.txtN.Location = New System.Drawing.Point(22, 0)
        Me.txtN.Name = "txtN"
        Me.txtN.PlaceHolder = "Designation"
        Me.txtN.ShowClearIcon = False
        Me.txtN.ShowSaveIcon = False
        Me.txtN.Size = New System.Drawing.Size(428, 31)
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
        Me.PlRight.Location = New System.Drawing.Point(671, 2)
        Me.PlRight.Name = "PlRight"
        Me.PlRight.Size = New System.Drawing.Size(112, 31)
        Me.PlRight.TabIndex = 13
        '
        'btAdd
        '
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Emblem_Default222
        Me.btAdd.Location = New System.Drawing.Point(25, 0)
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
        Me.btClear.Location = New System.Drawing.Point(69, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 31)
        Me.btClear.TabIndex = 7
        Me.btClear.UseVisualStyleBackColor = True
        '
        'plQte
        '
        Me.plQte.BackColor = System.Drawing.Color.Transparent
        Me.plQte.Controls.Add(Me.txtQ)
        Me.plQte.Dock = System.Windows.Forms.DockStyle.Right
        Me.plQte.Location = New System.Drawing.Point(457, 2)
        Me.plQte.Name = "plQte"
        Me.plQte.Padding = New System.Windows.Forms.Padding(10, 0, 5, 0)
        Me.plQte.Size = New System.Drawing.Size(214, 31)
        Me.plQte.TabIndex = 15
        '
        'txtQ
        '
        Me.txtQ.BackColor = System.Drawing.Color.White
        Me.txtQ.BorderColor = System.Drawing.SystemColors.ControlText
        Me.txtQ.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtQ.IsNumiric = True
        Me.txtQ.Location = New System.Drawing.Point(10, 0)
        Me.txtQ.Name = "txtQ"
        Me.txtQ.PlaceHolder = "Montant"
        Me.txtQ.ShowClearIcon = False
        Me.txtQ.ShowSaveIcon = False
        Me.txtQ.Size = New System.Drawing.Size(199, 31)
        Me.txtQ.StartUp = 2
        Me.txtQ.TabIndex = 3
        Me.txtQ.TextSize = 8
        Me.txtQ.TxtBackColor = True
        Me.txtQ.TxtColor = System.Drawing.Color.White
        Me.txtQ.txtReadOnly = False
        Me.txtQ.TxtSelect = New Integer() {1, 0}
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
        'AddElement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.plName)
        Me.Controls.Add(Me.plQte)
        Me.Controls.Add(Me.PlRight)
        Me.Controls.Add(Me.plleft)
        Me.Name = "AddElement"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(785, 36)
        Me.plName.ResumeLayout(False)
        Me.PlRight.ResumeLayout(False)
        Me.plQte.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plName As System.Windows.Forms.Panel
    Friend WithEvents txtN As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents PlRight As System.Windows.Forms.Panel
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents plQte As System.Windows.Forms.Panel
    Friend WithEvents txtQ As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents plleft As System.Windows.Forms.Panel

End Class
