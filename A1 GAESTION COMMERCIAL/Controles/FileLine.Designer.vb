<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileLine
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
        Me.plNm = New System.Windows.Forms.Panel()
        Me.lbName = New System.Windows.Forms.Label()
        Me.PlLeft = New System.Windows.Forms.Panel()
        Me.plSet = New System.Windows.Forms.Panel()
        Me.plImg = New System.Windows.Forms.Panel()
        Me.btClear = New System.Windows.Forms.Button()
        Me.btAdd = New System.Windows.Forms.Button()
        Me.plNm.SuspendLayout()
        Me.plSet.SuspendLayout()
        Me.SuspendLayout()
        '
        'plNm
        '
        Me.plNm.Controls.Add(Me.lbName)
        Me.plNm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.plNm.Location = New System.Drawing.Point(56, 0)
        Me.plNm.Name = "plNm"
        Me.plNm.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.plNm.Size = New System.Drawing.Size(459, 33)
        Me.plNm.TabIndex = 12
        '
        'lbName
        '
        Me.lbName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbName.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbName.ForeColor = System.Drawing.Color.DodgerBlue
        Me.lbName.Location = New System.Drawing.Point(10, 2)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(439, 29)
        Me.lbName.TabIndex = 0
        Me.lbName.Text = "designation"
        Me.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PlLeft
        '
        Me.PlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PlLeft.Location = New System.Drawing.Point(0, 0)
        Me.PlLeft.Name = "PlLeft"
        Me.PlLeft.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.PlLeft.Size = New System.Drawing.Size(18, 33)
        Me.PlLeft.TabIndex = 13
        '
        'plSet
        '
        Me.plSet.Controls.Add(Me.btClear)
        Me.plSet.Controls.Add(Me.btAdd)
        Me.plSet.Dock = System.Windows.Forms.DockStyle.Right
        Me.plSet.Location = New System.Drawing.Point(515, 0)
        Me.plSet.Name = "plSet"
        Me.plSet.Size = New System.Drawing.Size(89, 33)
        Me.plSet.TabIndex = 14
        '
        'plImg
        '
        Me.plImg.BackColor = System.Drawing.Color.Transparent
        Me.plImg.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.FILE_22
        Me.plImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.plImg.Dock = System.Windows.Forms.DockStyle.Left
        Me.plImg.Location = New System.Drawing.Point(18, 0)
        Me.plImg.Name = "plImg"
        Me.plImg.Padding = New System.Windows.Forms.Padding(10, 2, 10, 2)
        Me.plImg.Size = New System.Drawing.Size(38, 33)
        Me.plImg.TabIndex = 11
        '
        'btClear
        '
        Me.btClear.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_Gnome_Edit_Delete_22
        Me.btClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btClear.FlatAppearance.BorderSize = 0
        Me.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btClear.Location = New System.Drawing.Point(46, 0)
        Me.btClear.Name = "btClear"
        Me.btClear.Size = New System.Drawing.Size(43, 33)
        Me.btClear.TabIndex = 9
        Me.btClear.UseVisualStyleBackColor = True
        '
        'btAdd
        '
        Me.btAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btAdd.Dock = System.Windows.Forms.DockStyle.Left
        Me.btAdd.FlatAppearance.BorderSize = 0
        Me.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAdd.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_document_preview_23216__1_
        Me.btAdd.Location = New System.Drawing.Point(0, 0)
        Me.btAdd.Name = "btAdd"
        Me.btAdd.Size = New System.Drawing.Size(48, 33)
        Me.btAdd.TabIndex = 10
        Me.btAdd.UseVisualStyleBackColor = True
        '
        'FileLine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.plNm)
        Me.Controls.Add(Me.plImg)
        Me.Controls.Add(Me.PlLeft)
        Me.Controls.Add(Me.plSet)
        Me.Name = "FileLine"
        Me.Size = New System.Drawing.Size(604, 33)
        Me.plNm.ResumeLayout(False)
        Me.plSet.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents plNm As System.Windows.Forms.Panel
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents plImg As System.Windows.Forms.Panel
    Friend WithEvents PlLeft As System.Windows.Forms.Panel
    Friend WithEvents plSet As System.Windows.Forms.Panel
    Friend WithEvents btClear As System.Windows.Forms.Button
    Friend WithEvents btAdd As System.Windows.Forms.Button

End Class
