Public Class AddEditDepot


    Private Sub AddEditDepot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Depot' table. You can move, or remove it, as needed.
        Me.DepotTableAdapter.Fill(Me.ALMohassinDBDataSet.Depot)

    End Sub

    Private Sub Button45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button45.Click
        Panel1.Visible = True
        TextBox1.text = ""
        TextBox1.Tag = 0
        btcid.Tag = "1"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If dgvctg.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        Panel1.Visible = True
        TextBox1.text = dgvctg.SelectedRows(0).Cells(1).Value
        TextBox1.Tag = dgvctg.SelectedRows(0).Cells(0).Value
        Label1.Tag = dgvctg.SelectedRows(0).Cells(1).Value
        btcid.Tag = "2"

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.text = ""
        TextBox1.Tag = 0
        Panel1.Visible = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If dgvctg.SelectedRows.Count = 0 Then
            Exit Sub
        End If

        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف  المخزن المؤشر عليه من القائمة .. إضغط 'لا' لالغاء الحذف ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف التصنيف") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
            ta.Delete(dgvctg.SelectedRows(0).Cells(0).Value, dgvctg.SelectedRows(0).Cells(1).Value)
            ta.Fill(ALMohassinDBDataSet.Depot)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btcid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btcid.Click
        If TextBox1.text.Trim = "" Then
            MsgBox("عذرا لا يمكن اتمام طلبكم.. المرجوا تعبئة الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            TextBox1.Focus()
            Exit Sub
        End If

        ' addddd
        If btcid.Tag = "1" Then


            ''check the name

            For i As Integer = 0 To dgvctg.Rows.Count - 1
                If TextBox1.text = dgvctg.Rows(i).Cells(1).Value Then
                    MsgBox("عذرا لا يمكن اتمام طلبكم.. يجب عدم تكرار نفس الاسم", MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
                    TextBox1.Focus()
                    dgvctg.Rows(i).Selected = True
                    dgvctg.FirstDisplayedScrollingRowIndex = dgvctg.Rows(i).Index
                    Exit Sub
                End If
            Next


            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
                ta.Insert(TextBox1.text)
                ta.Fill(ALMohassinDBDataSet.Depot)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



            'updateeee
        Else

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.DepotTableAdapter
                ta.Update(TextBox1.text, TextBox1.Tag, Label1.Tag)
                ta.Fill(ALMohassinDBDataSet.Depot)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


        TextBox1.text = ""
        TextBox1.Tag = 0
        Panel1.Visible = False


    End Sub
End Class