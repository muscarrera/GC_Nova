<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListRow
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
        Me.PlButtom = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.plNm = New System.Windows.Forms.Panel()
        Me.lbName = New System.Windows.Forms.Label()
        Me.plRef = New System.Windows.Forms.Panel()
        Me.lbref = New System.Windows.Forms.Label()
        Me.plQ = New System.Windows.Forms.Panel()
        Me.lbQte = New System.Windows.Forms.Label()
        Me.plP = New System.Windows.Forms.Panel()
        Me.lbPrice = New System.Windows.Forms.Label()
        Me.plR = New System.Windows.Forms.Panel()
        Me.lbRemise = New System.Windows.Forms.Label()
        Me.PlLeft = New System.Windows.Forms.Panel()
        Me.plT = New System.Windows.Forms.Panel()
        Me.lbTotal = New System.Windows.Forms.Label()
        Me.plSet = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.plTva = New System.Windows.Forms.Panel()
        Me.lbTva = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.plNm.SuspendLayout()
        Me.plRef.SuspendLayout()
        Me.plQ.SuspendLayout()
        Me.plP.SuspendLayout()
        Me.plR.SuspendLayout()
        Me.plT.SuspendLayout()
        Me.plSet.SuspendLayout()
        Me.plTva.SuspendLayout()
        Me.SuspendLayout()
        '
        'PlButtom
        '
        Me.PlButtom.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.PlButtom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PlButtom.Location = New System.Drawing.Point(0, 40)
        Me.PlButtom.Name = "PlButtom"
        Me.PlButtom.Size = New System.Drawing.Size(904, 1)
        Me.PlButtom.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.plNm)
        Me.Panel1.Controls.Add(Me.plRef)
        Me.Panel1.Controls.Add(Me.plQ)
        Me.Panel1.Controls.Add(Me.plP)
        Me.Panel1.Controls.Add(Me.plR)
        Me.Panel1.Controls.Add(Me.PlLeft)
        Me.Panel1.Controls.Add(Me.plTva)
        Me.Panel1.Controls.Add(Me.plT)
        Me.Panel1.Controls.Add(Me.plSet)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel1.Size = New System.Drawing.Size(904, 41)
        Me.Panel1.TabIndex = 5
        '
        'plNm
        '
        Me.plNm.Controls.Add(Me.lbName)
        Me.plNm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plNm.Location = New System.Drawing.Point(151, 3)
        Me.plNm.Name = "plNm"
        Me.plNm.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.plNm.Size = New System.Drawing.Size(233, 35)
        Me.plNm.TabIndex = 8
        '
        'lbName
        '
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbName.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.Location = New System.Drawing.Point(10, 2)
        Me.lbName.MaximumSize = New System.Drawing.Size(225, 0)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(213, 31)
        Me.lbName.TabIndex = 0
        Me.lbName.Text = "designation"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plRef
        '
        Me.plRef.Controls.Add(Me.lbref)
        Me.plRef.Dock = System.Windows.Forms.DockStyle.Left
        Me.plRef.Location = New System.Drawing.Point(39, 3)
        Me.plRef.Name = "plRef"
        Me.plRef.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.plRef.Size = New System.Drawing.Size(112, 35)
        Me.plRef.TabIndex = 7
        '
        'lbref
        '
        Me.lbref.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbref.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbref.Location = New System.Drawing.Point(10, 2)
        Me.lbref.Name = "lbref"
        Me.lbref.Size = New System.Drawing.Size(92, 31)
        Me.lbref.TabIndex = 1
        Me.lbref.Text = "-"
        Me.lbref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plQ
        '
        Me.plQ.Controls.Add(Me.lbQte)
        Me.plQ.Dock = System.Windows.Forms.DockStyle.Right
        Me.plQ.Location = New System.Drawing.Point(384, 3)
        Me.plQ.Name = "plQ"
        Me.plQ.Padding = New System.Windows.Forms.Padding(2)
        Me.plQ.Size = New System.Drawing.Size(88, 35)
        Me.plQ.TabIndex = 6
        '
        'lbQte
        '
        Me.lbQte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbQte.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbQte.Location = New System.Drawing.Point(2, 2)
        Me.lbQte.Name = "lbQte"
        Me.lbQte.Size = New System.Drawing.Size(84, 31)
        Me.lbQte.TabIndex = 0
        Me.lbQte.Text = "-"
        Me.lbQte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'plP
        '
        Me.plP.Controls.Add(Me.lbPrice)
        Me.plP.Dock = System.Windows.Forms.DockStyle.Right
        Me.plP.Location = New System.Drawing.Point(472, 3)
        Me.plP.Name = "plP"
        Me.plP.Padding = New System.Windows.Forms.Padding(2)
        Me.plP.Size = New System.Drawing.Size(88, 35)
        Me.plP.TabIndex = 5
        '
        'lbPrice
        '
        Me.lbPrice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbPrice.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPrice.Location = New System.Drawing.Point(2, 2)
        Me.lbPrice.Name = "lbPrice"
        Me.lbPrice.Size = New System.Drawing.Size(84, 31)
        Me.lbPrice.TabIndex = 1
        Me.lbPrice.Text = "-"
        Me.lbPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'plR
        '
        Me.plR.Controls.Add(Me.lbRemise)
        Me.plR.Dock = System.Windows.Forms.DockStyle.Right
        Me.plR.Location = New System.Drawing.Point(560, 3)
        Me.plR.Name = "plR"
        Me.plR.Padding = New System.Windows.Forms.Padding(2)
        Me.plR.Size = New System.Drawing.Size(88, 35)
        Me.plR.TabIndex = 4
        '
        'lbRemise
        '
        Me.lbRemise.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbRemise.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbRemise.Location = New System.Drawing.Point(2, 2)
        Me.lbRemise.Name = "lbRemise"
        Me.lbRemise.Size = New System.Drawing.Size(84, 31)
        Me.lbRemise.TabIndex = 1
        Me.lbRemise.Text = "-"
        Me.lbRemise.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PlLeft
        '
        Me.PlLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PlLeft.Location = New System.Drawing.Point(3, 3)
        Me.PlLeft.Name = "PlLeft"
        Me.PlLeft.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.PlLeft.Size = New System.Drawing.Size(36, 35)
        Me.PlLeft.TabIndex = 9
        '
        'plT
        '
        Me.plT.Controls.Add(Me.lbTotal)
        Me.plT.Dock = System.Windows.Forms.DockStyle.Right
        Me.plT.Location = New System.Drawing.Point(688, 3)
        Me.plT.Name = "plT"
        Me.plT.Padding = New System.Windows.Forms.Padding(2)
        Me.plT.Size = New System.Drawing.Size(88, 35)
        Me.plT.TabIndex = 11
        '
        'lbTotal
        '
        Me.lbTotal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTotal.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTotal.Location = New System.Drawing.Point(2, 2)
        Me.lbTotal.Name = "lbTotal"
        Me.lbTotal.Size = New System.Drawing.Size(84, 31)
        Me.lbTotal.TabIndex = 0
        Me.lbTotal.Text = "-"
        Me.lbTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'plSet
        '
        Me.plSet.Controls.Add(Me.Button1)
        Me.plSet.Controls.Add(Me.btClear)
        Me.plSet.Controls.Add(Me.btAdd)
        Me.plSet.Dock = System.Windows.Forms.DockStyle.Right
        Me.plSet.Location = New System.Drawing.Point(776, 3)
        Me.plSet.Name = "plSet"
        Me.plSet.Size = New System.Drawing.Size(125, 35)
        Me.plSet.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.INFO_22
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(91, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 35)
        Me.Button1.TabIndex = 8
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Edit_Delete_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Left
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(48, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 35)
        Me.btClear.TabIndex = 6
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_edit_3218
        Me.btAdd.Location = New System.Drawing.Point(0, 0)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(48, 35)
        Me.btAdd.TabIndex = 7
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'plTva
        '
        Me.plTva.Controls.Add(Me.lbTva)
        Me.plTva.Dock = System.Windows.Forms.DockStyle.Right
        Me.plTva.Location = New System.Drawing.Point(648, 3)
        Me.plTva.Name = "plTva"
        Me.plTva.Padding = New System.Windows.Forms.Padding(2)
        Me.plTva.Size = New System.Drawing.Size(40, 35)
        Me.plTva.TabIndex = 12
        '
        'lbTva
        '
        Me.lbTva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTva.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTva.Location = New System.Drawing.Point(2, 2)
        Me.lbTva.Name = "lbTva"
        Me.lbTva.Size = New System.Drawing.Size(36, 31)
        Me.lbTva.TabIndex = 1
        Me.lbTva.Text = "-"
        Me.lbTva.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ListRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PlButtom)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ListRow"
        Me.Size = New System.Drawing.Size(904, 41)
        Me.Panel1.ResumeLayout(False)
        Me.plNm.ResumeLayout(False)
        Me.plRef.ResumeLayout(False)
        Me.plQ.ResumeLayout(False)
        Me.plP.ResumeLayout(False)
        Me.plR.ResumeLayout(False)
        Me.plT.ResumeLayout(False)
        Me.plSet.ResumeLayout(False)
        Me.plTva.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents plNm As System.Windows.Forms.Panel
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents plRef As System.Windows.Forms.Panel
    Friend WithEvents lbref As System.Windows.Forms.Label
    Friend WithEvents plQ As System.Windows.Forms.Panel
    Friend WithEvents lbQte As System.Windows.Forms.Label
    Friend WithEvents plP As System.Windows.Forms.Panel
    Friend WithEvents lbPrice As System.Windows.Forms.Label
    Friend WithEvents plR As System.Windows.Forms.Panel
    Friend WithEvents lbRemise As System.Windows.Forms.Label
    Friend WithEvents PlLeft As System.Windows.Forms.Panel
    Friend WithEvents plT As System.Windows.Forms.Panel
    Friend WithEvents lbTotal As System.Windows.Forms.Label
    Friend WithEvents plSet As System.Windows.Forms.Panel
    Friend WithEvents PlButtom As System.Windows.Forms.Panel
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents plTva As System.Windows.Forms.Panel
    Friend WithEvents lbTva As System.Windows.Forms.Label

End Class
