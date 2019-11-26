Public Class ParcClass

    Private Sub GetElements(ByRef ds As ParcList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                If IsNumeric(ds.txtSearchName.text) Then
                    params.Add("clid", CInt(ds.txtSearchName.text))
                    dt = a.SelectDataTable(ds.TableName, {"*"}, params)

                ElseIf ds.txtSearchName.text <> "" Then
                    params.Add("name Like ", "%" & ds.txtSearchName.text & "%")

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                    params.Add("ref Like ", "%" & ds.txtSearchName.text & "%")
                    Dim dt2 = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    dt.Merge(dt2, False)

                ElseIf ds.txtSearchName.text = "" Then
                    dt = a.SelectDataTable(ds.TableName, {"*"})
                End If
            End Using
            ds.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub NewElement(ByRef ds As ParcList)
        Dim pr As New AddEditClient
        If pr.ShowDialog = DialogResult.OK Then
            ds.txtSearchName.text = pr.txtName.text
            GetElements(ds)
        End If
    End Sub
    Private Sub EditElement(ByRef ds As ProductList, ByRef ls As ClientRow)
        Dim pr As New AddEditClient
        pr.EditMode = True
        pr.Id = ls.Id
        If pr.ShowDialog = DialogResult.OK Then
            ls.Libele = pr.txtName.text
            ls.Ville = pr.txtVille.text
            ls.Tel = pr.txtTel.text
            ls.isEdited = pr.rbSte.Checked
        End If
    End Sub
    Private Sub DeleteElement(ByRef ds As ProductList, ByRef ls As ClientRow)
        If MsgBox("Etes-vous certain de vouloir supprimer ce Client" & vbNewLine & ls.Name,
                  MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف المادة") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0


            Dim tb_F As String = "Sell_Facture"
            If ds.Mode = "Fournisseur " Then tb_F = "Buy_Facture"

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                params.Add("Clid", ls.Id)

                dt = a.SelectDataTable(tb_F, {"id"}, params)

                If dt.Rows.Count > 0 Then
                    If a.DeleteRecords(ds.TableName, params) > 0 Then
                        ds.RemoveElement(ls)
                    End If
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

















End Class
