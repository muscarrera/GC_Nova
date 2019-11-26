<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientRow
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.plNm = New System.Windows.Forms.Panel()
        Me.lbName = New System.Windows.Forms.Label()
        Me.plRef = New System.Windows.Forms.Panel()
        Me.lbref = New System.Windows.Forms.Label()
        Me.plQ = New System.Windows.Forms.Panel()
        Me.lbType = New System.Windows.Forms.Label()
        Me.plP = New System.Windows.Forms.Panel()
        Me.lbResponsable = New System.Windows.Forms.Label()
        Me.plR = New System.Windows.Forms.Panel()
        Me.lbTel = New System.Windows.Forms.Label()
        Me.plT = New System.Windows.Forms.Panel()
        Me.lbVille = New System.Windows.Forms.Label()
        Me.plSet = New System.Windows.Forms.Panel()
        Me.PlLeft = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.plNm.SuspendLayout()
        Me.plRef.SuspendLayout()
        Me.plQ.SuspendLayout()
        Me.plP.SuspendLayout()
        Me.plR.SuspendLayout()
        Me.plT.SuspendLayout()
        Me.plSet.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.plNm)
        Me.Panel1.Controls.Add(Me.plRef)
        Me.Panel1.Controls.Add(Me.plQ)
        Me.Panel1.Controls.Add(Me.plP)
        Me.Panel1.Controls.Add(Me.plR)
        Me.Panel1.Controls.Add(Me.PlLeft)
        Me.Panel1.Controls.Add(Me.plT)
        Me.Panel1.Controls.Add(Me.plSet)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel1.Size = New System.Drawing.Size(900, 33)
        Me.Panel1.TabIndex = 7
        '
        'plNm
        '
        Me.plNm.Controls.Add(Me.lbName)
        Me.plNm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plNm.Location = New System.Drawing.Point(114, 3)
        Me.plNm.Name = "plNm"
        Me.plNm.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.plNm.Size = New System.Drawing.Size(286, 27)
        Me.plNm.TabIndex = 8
        '
        'lbName
        '
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbName.Location = New System.Drawing.Point(10, 2)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(266, 23)
        Me.lbName.TabIndex = 0
        Me.lbName.Text = "designation"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plRef
        '
        Me.plRef.BackColor = System.Drawing.Color.Transparent
        Me.plRef.Controls.Add(Me.lbref)
        Me.plRef.Dock = System.Windows.Forms.DockStyle.Left
        Me.plRef.Location = New System.Drawing.Point(21, 3)
        Me.plRef.Name = "plRef"
        Me.plRef.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.plRef.Size = New System.Drawing.Size(93, 27)
        Me.plRef.TabIndex = 7
        '
        'lbref
        '
        Me.lbref.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbref.Location = New System.Drawing.Point(10, 2)
        Me.lbref.Name = "lbref"
        Me.lbref.Size = New System.Drawing.Size(73, 23)
        Me.lbref.TabIndex = 1
        Me.lbref.Text = "0"
        Me.lbref.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plQ
        '
        Me.plQ.Controls.Add(Me.lbType)
        Me.plQ.Dock = System.Windows.Forms.DockStyle.Right
        Me.plQ.Location = New System.Drawing.Point(400, 3)
        Me.plQ.Name = "plQ"
        Me.plQ.Padding = New System.Windows.Forms.Padding(2)
        Me.plQ.Size = New System.Drawing.Size(68, 27)
        Me.plQ.TabIndex = 6
        '
        'lbType
        '
        Me.lbType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbType.Location = New System.Drawing.Point(2, 2)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(64, 23)
        Me.lbType.TabIndex = 0
        Me.lbType.Text = "Ste"
        Me.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plP
        '
        Me.plP.Controls.Add(Me.lbResponsable)
        Me.plP.Dock = System.Windows.Forms.DockStyle.Right
        Me.plP.Location = New System.Drawing.Point(468, 3)
        Me.plP.Name = "plP"
        Me.plP.Padding = New System.Windows.Forms.Padding(2)
        Me.plP.Size = New System.Drawing.Size(82, 27)
        Me.plP.TabIndex = 5
        '
        'lbResponsable
        '
        Me.lbResponsable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbResponsable.Location = New System.Drawing.Point(2, 2)
        Me.lbResponsable.Name = "lbResponsable"
        Me.lbResponsable.Size = New System.Drawing.Size(78, 23)
        Me.lbResponsable.TabIndex = 1
        Me.lbResponsable.Text = "-"
        Me.lbResponsable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plR
        '
        Me.plR.Controls.Add(Me.lbTel)
        Me.plR.Dock = System.Windows.Forms.DockStyle.Right
        Me.plR.Location = New System.Drawing.Point(550, 3)
        Me.plR.Name = "plR"
        Me.plR.Padding = New System.Windows.Forms.Padding(2)
        Me.plR.Size = New System.Drawing.Size(126, 27)
        Me.plR.TabIndex = 4
        '
        'lbTel
        '
        Me.lbTel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbTel.Location = New System.Drawing.Point(2, 2)
        Me.lbTel.Name = "lbTel"
        Me.lbTel.Size = New System.Drawing.Size(122, 23)
        Me.lbTel.TabIndex = 1
        Me.lbTel.Text = "-"
        Me.lbTel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plT
        '
        Me.plT.Controls.Add(Me.lbVille)
        Me.plT.Dock = System.Windows.Forms.DockStyle.Right
        Me.plT.Location = New System.Drawing.Point(676, 3)
        Me.plT.Name = "plT"
        Me.plT.Padding = New System.Windows.Forms.Padding(2)
        Me.plT.Size = New System.Drawing.Size(91, 27)
        Me.plT.TabIndex = 11
        '
        'lbVille
        '
        Me.lbVille.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbVille.Location = New System.Drawing.Point(2, 2)
        Me.lbVille.Name = "lbVille"
        Me.lbVille.Size = New System.Drawing.Size(87, 23)
        Me.lbVille.TabIndex = 2
        Me.lbVille.Text = "-"
        Me.lbVille.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'plSet
        '
        Me.plSet.Controls.Add(Me.Button1)
        Me.plSet.Controls.Add(Me.btClear)
        Me.plSet.Controls.Add(Me.btAdd)
        Me.plSet.Dock = System.Windows.Forms.DockStyle.Right
        Me.plSet.Location = New System.Drawing.Point(767, 3)
        Me.plSet.Name = "plSet"
        Me.plSet.Size = New System.Drawing.Size(130, 27)
        Me.plSet.TabIndex = 10
        Me.plSet.Visible = False
        '
        'PlLeft
        '
        Me.PlLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PlLeft.Location = New System.Drawing.Point(3, 3)
        Me.PlLeft.Name = "PlLeft"
        Me.PlLeft.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.PlLeft.Size = New System.Drawing.Size(18, 27)
        Me.PlLeft.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.INFO_22
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(54, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 27)
        Me.Button1.TabIndex = 14
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btClear
        '
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Edit_Delete_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(87, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 27)
        Me.btClear.TabIndex = 12
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
        Me.btAdd.Size = New System.Drawing.Size(48, 27)
        Me.btAdd.TabIndex = 13
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'ClientRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ClientRow"
        Me.Size = New System.Drawing.Size(900, 33)
        Me.Panel1.ResumeLayout(False)
        Me.plNm.ResumeLayout(False)
        Me.plRef.ResumeLayout(False)
        Me.plQ.ResumeLayout(False)
        Me.plP.ResumeLayout(False)
        Me.plR.ResumeLayout(False)
        Me.plT.ResumeLayout(False)
        Me.plSet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents plNm As System.Windows.Forms.Panel
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents plRef As System.Windows.Forms.Panel
    Friend WithEvents lbref As System.Windows.Forms.Label
    Friend WithEvents plQ As System.Windows.Forms.Panel
    Friend WithEvents lbType As System.Windows.Forms.Label
    Friend WithEvents plP As System.Windows.Forms.Panel
    Friend WithEvents lbResponsable As System.Windows.Forms.Label
    Friend WithEvents plR As System.Windows.Forms.Panel
    Friend WithEvents lbTel As System.Windows.Forms.Label
    Friend WithEvents PlLeft As System.Windows.Forms.Panel
    Friend WithEvents plT As System.Windows.Forms.Panel
    Friend WithEvents lbVille As System.Windows.Forms.Label
    Friend WithEvents plSet As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button

End Class
