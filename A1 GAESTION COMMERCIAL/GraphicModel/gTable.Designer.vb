<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gTable
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
        Me.txtX = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtW = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtY = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtType = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.txtH = New A1_GAESTION_COMMERCIAL.TxtBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pl = New System.Windows.Forms.Panel()
        Me.cbLine = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.cbLine)
        Me.Panel1.Controls.Add(Me.txtX)
        Me.Panel1.Controls.Add(Me.txtW)
        Me.Panel1.Controls.Add(Me.txtY)
        Me.Panel1.Controls.Add(Me.txtType)
        Me.Panel1.Controls.Add(Me.txtH)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(5, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(570, 50)
        Me.Panel1.TabIndex = 0
        '
        'txtX
        '
        Me.txtX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtX.BackColor = System.Drawing.Color.White
        Me.txtX.BorderColor = System.Drawing.Color.White
        Me.txtX.IsNumiric = False
        Me.txtX.Location = New System.Drawing.Point(300, 15)
        Me.txtX.Name = "txtX"
        Me.txtX.PlaceHolder = "x.."
        Me.txtX.ShowClearIcon = False
        Me.txtX.ShowSaveIcon = False
        Me.txtX.Size = New System.Drawing.Size(44, 23)
        Me.txtX.StartUp = 2
        Me.txtX.TabIndex = 2
        Me.txtX.TextSize = 8
        Me.txtX.TxtBackColor = True
        Me.txtX.TxtColor = System.Drawing.Color.White
        Me.txtX.txtReadOnly = False
        Me.txtX.TxtSelect = New Integer() {1, 0}
        '
        'txtW
        '
        Me.txtW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtW.BackColor = System.Drawing.Color.White
        Me.txtW.BorderColor = System.Drawing.Color.White
        Me.txtW.IsNumiric = False
        Me.txtW.Location = New System.Drawing.Point(399, 15)
        Me.txtW.Name = "txtW"
        Me.txtW.PlaceHolder = "L .."
        Me.txtW.ShowClearIcon = False
        Me.txtW.ShowSaveIcon = False
        Me.txtW.Size = New System.Drawing.Size(44, 23)
        Me.txtW.StartUp = 2
        Me.txtW.TabIndex = 2
        Me.txtW.TextSize = 8
        Me.txtW.TxtBackColor = True
        Me.txtW.TxtColor = System.Drawing.Color.White
        Me.txtW.txtReadOnly = False
        Me.txtW.TxtSelect = New Integer() {1, 0}
        '
        'txtY
        '
        Me.txtY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtY.BackColor = System.Drawing.Color.White
        Me.txtY.BorderColor = System.Drawing.Color.White
        Me.txtY.IsNumiric = False
        Me.txtY.Location = New System.Drawing.Point(349, 15)
        Me.txtY.Name = "txtY"
        Me.txtY.PlaceHolder = "y.."
        Me.txtY.ShowClearIcon = False
        Me.txtY.ShowSaveIcon = False
        Me.txtY.Size = New System.Drawing.Size(44, 23)
        Me.txtY.StartUp = 2
        Me.txtY.TabIndex = 2
        Me.txtY.TextSize = 8
        Me.txtY.TxtBackColor = True
        Me.txtY.TxtColor = System.Drawing.Color.White
        Me.txtY.txtReadOnly = False
        Me.txtY.TxtSelect = New Integer() {1, 0}
        '
        'txtType
        '
        Me.txtType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtType.BackColor = System.Drawing.Color.White
        Me.txtType.BorderColor = System.Drawing.Color.White
        Me.txtType.IsNumiric = False
        Me.txtType.Location = New System.Drawing.Point(499, 15)
        Me.txtType.Name = "txtType"
        Me.txtType.PlaceHolder = "Table_1"
        Me.txtType.ShowClearIcon = False
        Me.txtType.ShowSaveIcon = False
        Me.txtType.Size = New System.Drawing.Size(60, 23)
        Me.txtType.StartUp = 2
        Me.txtType.TabIndex = 2
        Me.txtType.TextSize = 8
        Me.txtType.TxtBackColor = True
        Me.txtType.TxtColor = System.Drawing.Color.White
        Me.txtType.txtReadOnly = False
        Me.txtType.TxtSelect = New Integer() {1, 0}
        '
        'txtH
        '
        Me.txtH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtH.BackColor = System.Drawing.Color.White
        Me.txtH.BorderColor = System.Drawing.Color.White
        Me.txtH.IsNumiric = False
        Me.txtH.Location = New System.Drawing.Point(449, 15)
        Me.txtH.Name = "txtH"
        Me.txtH.PlaceHolder = "H .."
        Me.txtH.ShowClearIcon = False
        Me.txtH.ShowSaveIcon = False
        Me.txtH.Size = New System.Drawing.Size(44, 23)
        Me.txtH.StartUp = 2
        Me.txtH.TabIndex = 2
        Me.txtH.TextSize = 8
        Me.txtH.TxtBackColor = True
        Me.txtH.TxtColor = System.Drawing.Color.White
        Me.txtH.txtReadOnly = False
        Me.txtH.TxtSelect = New Integer() {1, 0}
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(20, 4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(98, 26)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pl
        '
        Me.pl.AutoScroll = True
        Me.pl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pl.Location = New System.Drawing.Point(5, 55)
        Me.pl.Name = "pl"
        Me.pl.Size = New System.Drawing.Size(570, 277)
        Me.pl.TabIndex = 1
        '
        'cbLine
        '
        Me.cbLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbLine.BackColor = System.Drawing.Color.White
        Me.cbLine.Location = New System.Drawing.Point(241, 9)
        Me.cbLine.Name = "cbLine"
        Me.cbLine.Size = New System.Drawing.Size(50, 31)
        Me.cbLine.TabIndex = 31
        Me.cbLine.Text = "Inter Lines"
        Me.cbLine.UseVisualStyleBackColor = False
        '
        'gTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.pl)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "gTable"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(580, 337)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pl As System.Windows.Forms.Panel
    Friend WithEvents txtX As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtW As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtY As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtType As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents txtH As A1_GAESTION_COMMERCIAL.TxtBox
    Friend WithEvents cbLine As System.Windows.Forms.CheckBox

End Class
