Public Class ClientClass
    Implements IDisposable

    Public TableName As String
    Public cid As Integer

    Public Function NouveauClient(ByVal name As String, ByVal type As String, ByVal ice As String, ByVal adresse As String,
                             ByVal tel As String, ByVal email As String, ByVal info As String, ByVal remise As Double,
                             ByVal max As Double, ByVal delai As Integer) As Integer

        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("name", name)
            params.Add("type", type)
            params.Add("ice", ice)
            params.Add("adresse", adresse)
            params.Add("tel", tel)
            params.Add("email", email)
            params.Add("info", info)
            params.Add("remise", remise)
            params.Add("max", max)
            params.Add("delai", delai)


            cid = c.InsertRecord(TableName, params, True)
        End Using


        Return cid
    End Function

    Public Sub AddDataList()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Client", {"*"})
            'If Form1.plBody.Controls.Count > 0 Then
            '    If TypeOf Form1.plBody.Controls(0) Is ProductList Then

            '        Dim dls As ProductList = Form1.plBody.Controls(0)
            '        dls.Mode = "Client"
            '        dls.DataSource = dt
            '        Exit Sub
            '    End If
            'End If

            Form1.plBody.Controls.Clear()
            Dim ds As New ProductList
            ds.Mode = "Client"
            ds.DataSource = dt

            ds.Dock = DockStyle.Fill
            AddHandler ds.GetElements, AddressOf GetElements
            AddHandler ds.NewElement, AddressOf NewElement
            AddHandler ds.EditArticle, AddressOf EditElement
            AddHandler ds.DeleteArticle, AddressOf DeleteElement
            AddHandler ds.ModeChanged, AddressOf ModeChanged

            Form1.plBody.Controls.Add(ds)
        End Using

    End Sub

    Private Sub GetElements(ByRef ds As ProductList)
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
    Private Sub NewElement(ByRef ds As ProductList)
        Dim pr As New AddEditClient
        If pr.ShowDialog = DialogResult.OK Then
            ds.txtSearchName.text = pr.txtName.text
            GetElements(ds)
        End If
    End Sub
    Private Sub EditElement(ByRef ls As ClientRow)
        Dim pr As New AddEditClient
        pr.Id = ls.Id
        If pr.ShowDialog = DialogResult.OK Then
            ls.Libele = pr.txtName.text
            ls.Total = pr.txtVille.text
            ls.Avance = pr.txtTel.text
            ls.isEdited = True
        End If
    End Sub
    Private Sub DeleteElement(ByRef ds As ProductList, ByVal ls As ClientRow)
        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف المادة المؤشر عليها من القائمة .. إضغط  'لا'  لالغاء الحذف ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف المادة") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                params.Add("Clid", ls.Id)

                If a.DeleteRecords(ds.TableName, params) > 0 Then
                    ds.RemoveElement(ls)
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub ModeChanged(ByVal ds As ProductList)
        GetElements(ds)
    End Sub






#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
