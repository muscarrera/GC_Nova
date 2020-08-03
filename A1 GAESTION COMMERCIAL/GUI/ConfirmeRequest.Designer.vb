<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfirmeRequest
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtBox1 = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Confirmation Code :"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(78, 162)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(313, 50)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Valider"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TxtBox1
        '
        Me.TxtBox1.BackColor = System.Drawing.Color.Transparent
        Me.TxtBox1.BorderColor = System.Drawing.SystemColors.ControlText
        Me.TxtBox1.IsNumiric = False
        Me.TxtBox1.Location = New System.Drawing.Point(78, 85)
        Me.TxtBox1.Name = "TxtBox1"
        Me.TxtBox1.PlaceHolder = ""
        Me.TxtBox1.ShowClearIcon = False
        Me.TxtBox1.ShowSaveIcon = False
        Me.TxtBox1.Size = New System.Drawing.Size(313, 46)
        Me.TxtBox1.StartUp = 2
        Me.TxtBox1.TabIndex = 5
        Me.TxtBox1.TextSize = 8
        Me.TxtBox1.TxtBackColor = True
        Me.TxtBox1.TxtColor = System.Drawing.Color.White
        Me.TxtBox1.txtReadOnly = False
        Me.TxtBox1.TxtSelect = New Integer() {1, 0}
        '
        'ConfirmeRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Salmon
        Me.ClientSize = New System.Drawing.Size(478, 262)
        Me.Controls.Add(Me.TxtBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ConfirmeRequest"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ConfirmeRequest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtBox1 As A1_GAESTION_COMMERCIAL.TxtBox
End Class
