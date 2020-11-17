<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PvArticle
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
        Me.lb = New System.Windows.Forms.Label()
        Me.plB = New System.Windows.Forms.Panel()
        Me.plB.SuspendLayout()
        Me.SuspendLayout()
        '
        'lb
        '
        Me.lb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lb.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lb.Location = New System.Drawing.Point(2, 2)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(144, 35)
        Me.lb.TabIndex = 0
        Me.lb.Text = "Label1"
        Me.lb.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'plB
        '
        Me.plB.BackColor = System.Drawing.Color.Transparent
        Me.plB.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.BGPVAR_2
        Me.plB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.plB.Controls.Add(Me.lb)
        Me.plB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.plB.Location = New System.Drawing.Point(0, 103)
        Me.plB.Name = "plB"
        Me.plB.Padding = New System.Windows.Forms.Padding(2, 2, 2, 8)
        Me.plB.Size = New System.Drawing.Size(148, 45)
        Me.plB.TabIndex = 1
        '
        'PvArticle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.plB)
        Me.Name = "PvArticle"
        Me.Size = New System.Drawing.Size(148, 148)
        Me.plB.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents plB As System.Windows.Forms.Panel

End Class
