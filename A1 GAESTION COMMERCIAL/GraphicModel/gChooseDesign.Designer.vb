<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gChooseDesign
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pl = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(267, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.Location = New System.Drawing.Point(12, 59)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(278, 310)
        Me.pl.TabIndex = 1
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 386)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(278, 43)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Selectionner"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'gChooseDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 450)
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "gChooseDesign"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selection Design"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
