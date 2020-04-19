<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gForm
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
        Dim GTabClass1 As A1_GAESTION_COMMERCIAL.gTabClass = New A1_GAESTION_COMMERCIAL.gTabClass()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Pfp = New System.Windows.Forms.Panel()
        Me.Pf = New System.Windows.Forms.FlowLayoutPanel()
        Me.PT = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pb = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gt = New A1_GAESTION_COMMERCIAL.gTable()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Pfp.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Pfp)
        Me.Panel1.Controls.Add(Me.PT)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(487, 509)
        Me.Panel1.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.AutoScroll = True
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.gt)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 126)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(487, 250)
        Me.Panel5.TabIndex = 3
        '
        'Pfp
        '
        Me.Pfp.BackColor = System.Drawing.Color.MintCream
        Me.Pfp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pfp.Controls.Add(Me.Pf)
        Me.Pfp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pfp.Location = New System.Drawing.Point(0, 376)
        Me.Pfp.Name = "Pfp"
        Me.Pfp.Size = New System.Drawing.Size(487, 133)
        Me.Pfp.TabIndex = 2
        '
        'Pf
        '
        Me.Pf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pf.Location = New System.Drawing.Point(0, 0)
        Me.Pf.Name = "Pf"
        Me.Pf.Size = New System.Drawing.Size(485, 131)
        Me.Pf.TabIndex = 0
        '
        'PT
        '
        Me.PT.BackColor = System.Drawing.Color.Bisque
        Me.PT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PT.Dock = System.Windows.Forms.DockStyle.Top
        Me.PT.Location = New System.Drawing.Point(0, 0)
        Me.PT.Name = "PT"
        Me.PT.Size = New System.Drawing.Size(487, 126)
        Me.PT.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.pb)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 509)
        Me.Panel2.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.iconfinder_folder_delete_61770
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(372, 3)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(44, 37)
        Me.Button3.TabIndex = 1
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.SAVE_20
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button2.Location = New System.Drawing.Point(55, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 36)
        Me.Button2.TabIndex = 1
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.A1_GAESTION_COMMERCIAL.My.Resources.Resources.AVOIR_22
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Location = New System.Drawing.Point(5, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(44, 36)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.White
        Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pb.Location = New System.Drawing.Point(5, 46)
        Me.pb.Name = "pb"
        Me.pb.Size = New System.Drawing.Size(416, 478)
        Me.pb.TabIndex = 0
        Me.pb.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(501, 175)
        Me.Panel3.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(15, 15)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(952, 509)
        Me.SplitContainer1.SplitterDistance = 487
        Me.SplitContainer1.TabIndex = 1
        '
        'gt
        '
        Me.gt.BackColor = System.Drawing.Color.White
        Me.gt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gt.Location = New System.Drawing.Point(0, 0)
        Me.gt.Name = "gt"
        Me.gt.Padding = New System.Windows.Forms.Padding(5)
        Me.gt.Size = New System.Drawing.Size(485, 248)
        Me.gt.TabIndex = 0
        Me.gt.TabProp = GTabClass1
        '
        'gForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 539)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "gForm"
        Me.Padding = New System.Windows.Forms.Padding(15)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "gForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Pfp.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pb As System.Windows.Forms.PictureBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Pfp As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents gt As A1_GAESTION_COMMERCIAL.gTable
    Friend WithEvents PT As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Pf As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
