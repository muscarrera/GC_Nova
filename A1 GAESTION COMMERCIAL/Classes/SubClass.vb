Public Class SubClass

End Class

'Exercice 
Public Class Exercice
    Implements IDisposable

    Public Function GetActiveExircice() As String
        Dim Exe As Integer = 0
        Try
            Dim params As New Dictionary(Of String, Object)
            params.Add("isActive", True)
            Dim art As Article = Nothing
            ' added some items
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                Dim dt As DataTable = a.SelectDataTable("Exercice", {"*"}, params)
                If dt.Rows.Count = 0 Then
                    Exe = NouveauExircice()
                Else
                    Exe = dt.Rows(0).Item(0)
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Exe
    End Function


    Public Function NouveauExircice() As Integer
        Dim Exe As Integer = 0
        Try
            Dim NF As New NouveauFacture
            NF.TxtExr.Text = Form1.Exercice
            NF.TxtDate.Text = Now.Date.ToString("dd/MM/yyyy")
            If NF.ShowDialog = DialogResult.OK Then
                Dim params As New Dictionary(Of String, Object)
                params.Add("isActive", False)
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                    a.UpdateRecordAll("Exercice", params)
                    params.Clear()

                    params.Add("isActive", True)
                    params.Add("name", True)
                    params.Add("startDate", CDate(NF.TxtDate.Text))
                    params.Add("endDate", CDate(NF.TxtDate.Text).AddYears(1))
                    Dim art As Article = Nothing
                    ' added some items

                    Exe = a.InsertRecord("Exercice", params, True)
                End Using
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Exe
    End Function




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