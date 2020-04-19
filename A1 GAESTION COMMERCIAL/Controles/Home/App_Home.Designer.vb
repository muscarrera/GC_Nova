<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class App_Home
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
        Me.PL = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(586, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(14)
        Me.Panel1.Size = New System.Drawing.Size(212, 525)
        Me.Panel1.TabIndex = 1
        '
        'PL
        '
        Me.PL.BackColor = System.Drawing.Color.Transparent
        Me.PL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PL.Location = New System.Drawing.Point(11, 11)
        Me.PL.Name = "PL"
        Me.PL.Padding = New System.Windows.Forms.Padding(14)
        Me.PL.Size = New System.Drawing.Size(575, 525)
        Me.PL.TabIndex = 2
        '
        'App_Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PL)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "App_Home"
        Me.Padding = New System.Windows.Forms.Padding(11)
        Me.Size = New System.Drawing.Size(809, 547)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PL As System.Windows.Forms.Panel

End Class
