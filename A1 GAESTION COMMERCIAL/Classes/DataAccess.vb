Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Collections.Generic


Public Class DataAccess

    Implements IDisposable

    Private _connectionString As String
    Private _mytrans As OleDbTransaction = Nothing
    Private _con As OleDbConnection
    Public _hasError As Boolean = False
    'Constracter
    Public Sub New(ByVal connectionString As String)
        Try
            _connectionString = connectionString
            _con = New OleDbConnection(_connectionString)
            _con.Open()
        Catch ex As Exception
            MsgBox("Error occurred while connecting to database " & vbNewLine &
                   ex.Message, MsgBoxStyle.Critical)
            _hasError = True
            Dispose()
        End Try
    End Sub
    Public Sub New(ByVal connectionString As String, ByVal hasTransaction As Boolean)
        Try
            _connectionString = connectionString
            _con = New OleDbConnection(_connectionString)
            _con.Open()
            _mytrans = _con.BeginTransaction

        Catch ex As Exception
            MsgBox("Error occurred while connecting to database " & vbNewLine &
                   ex.Message, MsgBoxStyle.Critical)
            _hasError = True
            Dispose()

        End Try

    End Sub

    ' get data from database
    Public Function SelectData(ByVal table As String, ByVal field As String(),
                               Optional ByVal params As Dictionary(Of String, Object) = Nothing,
                               Optional ByVal orderBy As Dictionary(Of String, String) = Nothing, Optional ByVal syntaxExtra As String = "") As OleDbDataReader
        Dim q As String = "SELECT " & syntaxExtra & " "
        For i As Integer = 0 To field.Length - 1
            If i > 0 Then q &= ", "
            q &= field(i)
        Next
        q &= " FROM [" & table & "]"
        Dim p As Integer = 1
        If params IsNot Nothing Then
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "
                q &= "[" & kvp.Key & "]" & " =:" & p
                p += 1
            Next
        End If
        p = 0
        If orderBy IsNot Nothing Then
            q &= " ORDER BY "
            For Each kvp As KeyValuePair(Of String, String) In orderBy
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]" & " " & kvp.Value
                p += 1
            Next
        End If



        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteReader()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return Nothing
        End Try

    End Function
    Public Function SelectDataTable(ByVal table As String, ByVal field As String(),
                                    Optional ByVal params As Dictionary(Of String, Object) = Nothing,
                                    Optional ByVal orderBy As Dictionary(Of String, String) = Nothing,
                                    Optional ByVal syntaxExtra As String = "", Optional ByVal isLike As Boolean = False) As DataTable
        Dim q As String = "SELECT " & syntaxExtra & " "
        For i As Integer = 0 To field.Length - 1
            If i > 0 Then q &= ", "
            q &= field(i)
        Next
        q &= " FROM [" & table & "]"
        Dim p As Integer = 1
        If params IsNot Nothing Then
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "

                q &= "[" & kvp.Key & "]" & " = :" & p
                p += 1
            Next
        End If
        p = 0
        If orderBy IsNot Nothing Then
            q &= " ORDER BY "
            For Each kvp As KeyValuePair(Of String, String) In orderBy
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]" & " " & kvp.Value
                p += 1
            Next
        End If

        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    Dim dt As DataTable = New DataTable()
                    dt.Load(dr)
                    Return dt
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return Nothing
        End Try

    End Function
    Public Function SelectDataTableSymbols(ByVal table As String, ByVal field As String(),
                                    Optional ByVal params As Dictionary(Of String, Object) = Nothing,
                                    Optional ByVal orderBy As Dictionary(Of String, String) = Nothing,
                                    Optional ByVal syntaxExtra As String = "", Optional ByVal isLike As Boolean = False) As DataTable
        Dim q As String = "SELECT " & syntaxExtra & " "
        For i As Integer = 0 To field.Length - 1
            If i > 0 Then q &= ", "
            q &= field(i)
        Next
        q &= " FROM [" & table & "]"
        Dim p As Integer = 1
        If params IsNot Nothing Then
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "

                q &= kvp.Key & " :" & p
                p += 1
            Next
        End If
        p = 0
        If orderBy IsNot Nothing Then
            q &= " ORDER BY "
            For Each kvp As KeyValuePair(Of String, String) In orderBy
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]" & " " & kvp.Value
                p += 1
            Next
        End If

        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    Dim dt As DataTable = New DataTable()
                    dt.Load(dr)
                    Return dt
                End Using
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return Nothing
        End Try

    End Function
    ' get data from database with inner join
    Public Function SelectData(ByVal table1 As String, ByVal table2 As String,
                               ByVal onField1 As String, ByVal onField2 As String, ByVal field As String(),
                               Optional ByVal params As Dictionary(Of String, Object) = Nothing,
                               Optional ByVal orderBy As Dictionary(Of String, String) = Nothing,
                               Optional ByVal syntaxExtra As String = "") As OleDbDataReader
        Dim q As String = "SELECT " & syntaxExtra & " "

        For i As Integer = 0 To field.Length - 1 ' field = table.field
            If i > 0 Then q &= ", "
            q &= field(i)
        Next
        q &= " FROM [" & table1 & "] INNER JOIN [" & table2 & "] ON " & onField1 & "=" & onField2 ' onfield = table.field

        Dim p As Integer = 1
        If params IsNot Nothing Then
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "
                q &= "[" & kvp.Key & "]" & "=:" & p
                p += 1
            Next
        End If
        p = 0
        If orderBy IsNot Nothing Then
            q &= " ORDER BY "
            For Each kvp As KeyValuePair(Of String, String) In orderBy
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]" & " " & kvp.Value
                p += 1
            Next
        End If

        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteReader()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return Nothing
        End Try

    End Function
    Public Function SelectDataLike(ByVal table1 As String, ByVal table2 As String,
                               ByVal onField1 As String, ByVal onField2 As String, ByVal field As String(),
                               Optional ByVal params As Dictionary(Of String, Object) = Nothing,
                               Optional ByVal orderBy As Dictionary(Of String, String) = Nothing,
                               Optional ByVal syntaxExtra As String = "") As DataTable
        Dim q As String = "SELECT " & syntaxExtra & " "

        For i As Integer = 0 To field.Length - 1 ' field = table.field
            If i > 0 Then q &= ", "
            q &= field(i)
        Next
        q &= " FROM [" & table1 & "] INNER JOIN [" & table2 & "] ON " & onField1 & "=" & onField2 ' onfield = table.field

        Dim p As Integer = 1
        If params IsNot Nothing Then
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "
                q &= kvp.Key & p
                p += 1
            Next
        End If
        p = 0
        If orderBy IsNot Nothing Then
            q &= " ORDER BY "
            For Each kvp As KeyValuePair(Of String, String) In orderBy
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]" & " " & kvp.Value
                p += 1
            Next
        End If

        Try

            Using cmd As OleDbCommand = BuildCommand(q, params)
                Using dr As OleDbDataReader = cmd.ExecuteReader()
                    Dim dt As DataTable = New DataTable()
                    dt.Load(dr)
                    Return dt
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return Nothing
        End Try

    End Function
    ' get data from database by scalar
    Public Function SelectByScalar(ByVal table As String, ByVal field As String, Optional ByVal params As Dictionary(Of String, Object) = Nothing) As Object
        Dim q As String = "SELECT [" & field & "] from [" & table & "]"

        Dim p As Integer = 1
        If params IsNot Nothing Then
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "
                q &= "[" & kvp.Key & "]" & "=:" & p
                p += 1
            Next
        End If



        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteScalar
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return Nothing
        End Try

    End Function
    ' INSERT DATA
    Public Function InsertRecord(ByVal table As String, ByVal params As Dictionary(Of String, Object)) As Integer
        Dim q As String = "INSERT INTO [" & table & "] (" '& fields & ") VALUES (" & values & ")"

        If params IsNot Nothing Then
            Dim p As Integer = 0
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]"
                p += 1
            Next
            p = 1
            q &= ") VALUES ("
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= ", "
                q &= ":" & p
                p += 1
            Next
            q &= ")"
        End If

        ' create the command
        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)

                Return cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return 0
        End Try
    End Function
    ' Insert data and get ID
    Public Function InsertRecord(ByVal table As String, ByVal params As Dictionary(Of String, Object), ByVal returnIID As Boolean) As Integer
        Dim q As String = "INSERT INTO  " & table & "  (" '& fields & ") VALUES (" & values & ")"

        If params IsNot Nothing Then
            Dim p As Integer = 0
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 0 Then q &= ", "
                q &= "[" & kvp.Key & "]"
                p += 1
            Next
            p = 1
            q &= ") VALUES ("
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= ", "
                q &= ":" & p
                p += 1
            Next
            q &= ")"
        End If


        ' create the command
        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                cmd.ExecuteNonQuery()
                cmd.CommandText = "Select @@Identity"
                Return CInt(cmd.ExecuteScalar())
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return 0
        End Try
    End Function
    ' Update records
    Public Function UpdateRecord(ByVal table As String, ByVal params As Dictionary(Of String, Object), ByVal where As Dictionary(Of String, Object)) As Integer
        Dim q As String = "UPDATE [" & table & "] SET " '& fields & ") VALUES (" & values & ")"

        If params IsNot Nothing Then
            Dim p As Integer = 1
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= ", "
                q &= "[" & kvp.Key & "] =:" & p
                p += 1
            Next
            Dim pp As Integer = p
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In where
                If p > pp Then q &= " AND "
                q &= "[" & kvp.Key & "] =:" & p
                p += 1
            Next
        End If

        For Each kvp As KeyValuePair(Of String, Object) In where
            params.Add(kvp.Key, kvp.Value)
        Next


        ' create the command
        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return 0
        End Try
    End Function
    Public Function UpdateRecordAll(ByVal table As String, ByVal params As Dictionary(Of String, Object)) As Integer
        Dim q As String = "UPDATE [" & table & "] SET " '& fields & ") VALUES (" & values & ")"

        If params IsNot Nothing Then
            Dim p As Integer = 1
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= ", "
                q &= "[" & kvp.Key & "] =:" & p
                p += 1
            Next
            Dim pp As Integer = p
        End If

        ' create the command
        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return 0
        End Try
    End Function
    Public Function UpdateRecordSymbols(ByVal table As String, ByVal params As Dictionary(Of String, Object), ByVal where As Dictionary(Of String, Object)) As Integer
        Dim q As String = "UPDATE [" & table & "] SET " '& fields & ") VALUES (" & values & ")"

        If params IsNot Nothing Then
            Dim p As Integer = 1
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= ", "
                q &= "[" & kvp.Key & "] =:" & p
                p += 1
            Next
            Dim pp As Integer = p
            q &= " WHERE "
            For Each kvp As KeyValuePair(Of String, Object) In where
                If p > pp Then q &= " AND "
                q &= kvp.Key & ":" & p
                p += 1
            Next
        End If

        For Each kvp As KeyValuePair(Of String, Object) In where
            params.Add(kvp.Key, kvp.Value)
        Next


        ' create the command
        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return 0
        End Try
    End Function

    ' Delete DATA 
    Public Function DeleteRecords(ByVal table As String, Optional ByVal params As Dictionary(Of String, Object) = Nothing) As Integer
        Dim q As String = "DELETE FROM [" & table & "]"

        If params IsNot Nothing Then
            q &= " WHERE "
            Dim p As Integer = 1
            For Each kvp As KeyValuePair(Of String, Object) In params
                If p > 1 Then q &= " AND "
                q &= "[" & kvp.Key & "] =:" & p
                p += 1
            Next
        End If


        ' create the command
        Try
            Using cmd As OleDbCommand = BuildCommand(q, params)
                Return cmd.ExecuteNonQuery()
            End Using

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()
            Return 0
        End Try
    End Function
    'Sythexe 
    Public Sub SynthexeSQL(ByVal table As String)
        Dim q As String = table

        Try
            Dim cmd As New OleDbCommand
            cmd.CommandText = q
            cmd.Connection = _con
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Error")
            _hasError = True
            Dispose()

        End Try
    End Sub
    ' Building command
    Private Function BuildCommand(ByVal cmdTxt As String, ByVal params As Dictionary(Of String, Object)) As OleDbCommand
        Dim cmd As New OleDbCommand
        cmd.CommandText = cmdTxt
        cmd.Connection = _con
        If _mytrans IsNot Nothing Then
            cmd.Transaction = _mytrans
        End If
        AddParameters(cmd, params)
        Return cmd

    End Function
    Private Sub AddParameters(ByRef cmd As OleDbCommand, ByVal params As Dictionary(Of String, Object))
        If Not params Is Nothing Then
            Dim p As Integer = 1
            For Each kvp As KeyValuePair(Of String, Object) In params
                cmd.Parameters.AddWithValue(":" & p, kvp.Value)
            Next
        End If
    End Sub


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls 

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If _hasError Then
                    If _mytrans IsNot Nothing Then _mytrans.Rollback()
                Else
                    If _mytrans IsNot Nothing Then _mytrans.Commit()

                End If

                If _con IsNot Nothing Then
                    If _con.State = ConnectionState.Open Then
                        _con.Close()
                    End If
                End If
                If _mytrans IsNot Nothing Then _mytrans.Dispose()
                _con.Dispose()
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

    Sub SynthexeSQL(ByVal p1 As String, ByVal q As String)
        Throw New NotImplementedException
    End Sub



End Class
