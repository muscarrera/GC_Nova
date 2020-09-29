<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadCompanies
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.pl = New System.Windows.Forms.Panel()
        Me.Panel24.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.Button6)
        Me.Panel24.Controls.Add(Me.Panel29)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel24.Location = New System.Drawing.Point(0, 434)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(398, 37)
        Me.Panel24.TabIndex = 4
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(291, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Padding = New System.Windows.Forms.Padding(6, 0, 0, 0)
        Me.Button6.Size = New System.Drawing.Size(95, 28)
        Me.Button6.TabIndex = 2
        Me.Button6.Text = "Choisir"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(398, 2)
        Me.Panel29.TabIndex = 1
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(0, 0)
        Me.pl.Name = "pl"
        Me.pl.Padding = New System.Windows.Forms.Padding(20)
        Me.pl.Size = New System.Drawing.Size(398, 434)
        Me.pl.TabIndex = 5
        '
        'LoadCompanies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(398, 471)
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.Panel24)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LoadCompanies"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Multi-sociétés & multi-organisations"
        Me.Panel24.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel29 As System.Windows.Forms.Panel
    Friend WithEvents pl As System.Windows.Forms.Panel
End Class
