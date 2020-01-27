<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Tag
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
        Me.PL = New System.Windows.Forms.Panel()
        Me.lb = New System.Windows.Forms.Label()
        Me.PLR = New System.Windows.Forms.Panel()
        Me.PLD = New System.Windows.Forms.Panel()
        Me.PLS = New System.Windows.Forms.Panel()
        Me.PL.SuspendLayout()
        Me.SuspendLayout()
        '
        'PL
        '
        Me.PL.Controls.Add(Me.PLD)
        Me.PL.Controls.Add(Me.lb)
        Me.PL.Controls.Add(Me.PLR)
        Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PL.Location = New System.Drawing.Point(35, 0)
        Me.PL.Name = "PL"
        Me.PL.Size = New System.Drawing.Size(365, 32)
        Me.PL.TabIndex = 1
        '
        'lb
        '
        Me.lb.AutoSize = True
        Me.lb.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb.Location = New System.Drawing.Point(6, 10)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(46, 14)
        Me.lb.TabIndex = 2
        Me.lb.Text = "Label1"
        '
        'PLR
        '
        Me.PLR.BackColor = System.Drawing.Color.White
        Me.PLR.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.TAGIN_03
        Me.PLR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PLR.Dock = System.Windows.Forms.DockStyle.Right
        Me.PLR.Location = New System.Drawing.Point(352, 0)
        Me.PLR.Name = "PLR"
        Me.PLR.Size = New System.Drawing.Size(13, 32)
        Me.PLR.TabIndex = 3
        Me.PLR.Visible = False
        '
        'PLD
        '
        Me.PLD.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.vector_cancel_icon_png_302651
        Me.PLD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PLD.Dock = System.Windows.Forms.DockStyle.Right
        Me.PLD.Location = New System.Drawing.Point(321, 0)
        Me.PLD.Name = "PLD"
        Me.PLD.Size = New System.Drawing.Size(31, 32)
        Me.PLD.TabIndex = 1
        Me.PLD.Visible = False
        '
        'PLS
        '
        Me.PLS.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.TAGIN_01
        Me.PLS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PLS.Dock = System.Windows.Forms.DockStyle.Left
        Me.PLS.Location = New System.Drawing.Point(0, 0)
        Me.PLS.Name = "PLS"
        Me.PLS.Size = New System.Drawing.Size(35, 32)
        Me.PLS.TabIndex = 0
        '
        'Tag
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.PL)
        Me.Controls.Add(Me.PLS)
        Me.Name = "Tag"
        Me.Size = New System.Drawing.Size(400, 32)
        Me.PL.ResumeLayout(False)
        Me.PL.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PLS As System.Windows.Forms.Panel
    Friend WithEvents PL As System.Windows.Forms.Panel
    Friend WithEvents PLD As System.Windows.Forms.Panel
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents PLR As System.Windows.Forms.Panel

End Class
