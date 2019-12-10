Public Class AddAdmins

    Private Sub Addadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.admin' table. You can move, or remove it, as needed.
        Me.AdminTableAdapter.Fill(Me.ALMohassinDBDataSet.admin)
       
        If Form1.adminid <> "1" Then
            DataGridView1.Columns(3).Visible = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Tag = ""
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim str As String = Form1.adminId
        'If Form1.adminId <> "1" Then
        '    Exit Sub
        'End If

        TextBox1.Text = DataGridView1.SelectedRows(0).Cells(1).Value
        If DataGridView1.SelectedRows(0).Cells(2).Value = "admin" Then


            ComboBox1.Text = "Admin"
        Else
            ComboBox1.Text = "User"
        End If
        TextBox1.Tag = DataGridView1.SelectedRows(0).Cells(0).Value
        'TextBox1.Enabled = False
        ComboBox1.Enabled = False



        Button2.Tag = "1"

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If TextBox2.Text = "" Then
                Exit Sub
            End If


            Dim ta As New ALMohassinDBDataSetTableAdapters.adminTableAdapter
            Dim a As String = "not"
            If ComboBox1.Text = "Admin" Or ComboBox1.Text = "admin" Then
                a = "admin"
            End If
            If Button2.Tag = "1" Then

                ta.UpdateQuery(TextBox1.Text, a, TextBox2.Text, TextBox1.Tag)
            Else
                ta.Insert(TextBox1.Text, a, TextBox2.Text)

            End If
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox1.Tag = ""
        Catch ex As Exception

        End Try
        AdminTableAdapter.Fill(ALMohassinDBDataSet.admin)
        TextBox2.Tag = "0"
        TextBox1.Enabled = True
        ComboBox1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Exit Sub
        End If
        'If Form1.adminId <> 1 Then
        '    Button1.Enabled = False
        '    Exit Sub
        'End If

        If DataGridView1.SelectedRows(0).Cells(0).Value = 1 Then
            MsgBox("فشل في العملية. لايمكن حذف  الادمين الرئيسي ")
            Exit Sub
        End If

        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.adminTableAdapter
            ta.DeleteQuery(DataGridView1.SelectedRows(0).Cells(0).Value)
        Catch ex As Exception

        End Try
        AdminTableAdapter.Fill(ALMohassinDBDataSet.admin)
    End Sub
End Class