Imports System.IO

Module AdminModule
    Dim strKey = "ALMsbtrFirstRun_gc2"
    Dim strFirstUse = "AL Mohasib System de gestion - Premier utilisation .."

    Public ReadOnly Property TrialVersion_Master
        Get
            Return checktrialMaster()
        End Get
    End Property
    Public ReadOnly Property TrialVersion_Slave
        Get
            Return checktrialSlave()
        End Get
    End Property

    ' for master
    Private Function checktrialMaster() As Boolean
        Dim resultkey As Integer = HandleRegistry2()
        If resultkey = 0 Then 'something went wrong
            Dim fdt As Date
            fdt = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)
            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter

                Dim dt2 = ta.GetData("truefont")

                If dt2.Rows(0).Item("val") = "true" Then
                    Form1.btTrial.Visible = False
                    Return True
                    Exit Function
                Else
                    Dim trial As New TrialVersion
                    If trial.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                        Return False
                        Exit Function
                    Else
                        Return True
                        Exit Function
                    End If
                End If
            Catch ex As Exception
                Return False
            End Try
        Else

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("truefont")
                If dt.Rows(0).Item("val") = "true" Then
                    Form1.btTrial.Visible = False
                Else
                    MsgBox("trial version", MsgBoxStyle.Information Or MsgBoxStyle.OkOnly, "AL Mohasib")
                End If
                Return True
            Catch ex As Exception
                Return True
            End Try

        End If
    End Function
    Private Function HandleRegistry2() As Integer
        Dim ALMohasibfirstRunDate As Date

        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)
        If ALMohasibfirstRunDate = Nothing Then
            ALMohasibfirstRunDate = Now
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, ALMohasibfirstRunDate)
            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("keypsv")
                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "1d5-" & "2" & ALMohasibfirstRunDate.Year & "-4053-" & "2011" & ALMohasibfirstRunDate.Month
                If dt.Rows.Count > 0 Then
                    ta.UpdateKeyVal(val, "keypsv")
                Else
                    ta.Insert("keypsv", val)
                End If
                Dim dt2 = ta.GetData("truefont")
                If dt.Rows.Count > 0 Then
                    ta.UpdateKeyVal("false", "truefont")
                Else
                    ta.Insert("truefont", "False")
                End If
                MsgBox(strFirstUse)

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            Return 1
        ElseIf (Now - ALMohasibfirstRunDate).Days > 60 Then
            Try

                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("keypsv")
                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "d15-" & "2" & ALMohasibfirstRunDate.Year & "-4053-" & "2011" & ALMohasibfirstRunDate.Month
                ''''''
                If dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("val") <> val Then

                        ta.UpdateKeyVal(val, "keypsv")
                        Dim dt2 = ta.GetData("truefont")
                        If dt.Rows.Count > 0 Then
                            ta.UpdateKeyVal("false", "truefont")
                        Else
                            ta.Insert("truefont", "False")
                            MsgBox(strFirstUse)
                        End If

                    Else

                    End If
                Else

                    ta.Insert("keypsv", val)
                    Dim dt2 = ta.GetData("truefont")
                    If dt.Rows.Count > 0 Then
                        ta.UpdateKeyVal("false", "truefont")
                    Else
                        ta.Insert("truefont", "False")
                    End If
                    MsgBox(strFirstUse)

                End If
                '''''''

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            Return 0
        Else

            Try
                Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter
                Dim dt = ta.GetData("keypsv")
                Dim val As String = ALMohasibfirstRunDate.Day & ALMohasibfirstRunDate.Hour & "-" & ALMohasibfirstRunDate.Second & "d15-" & "2" & ALMohasibfirstRunDate.Year & "-4053-" & "2011" & ALMohasibfirstRunDate.Month
                ''''''
                If dt.Rows.Count > 0 Then

                    If dt.Rows(0).Item("val") <> val Then

                        ta.UpdateKeyVal(val, "keypsv")
                        Dim dt2 = ta.GetData("truefont")
                        If dt.Rows.Count > 0 Then
                            ta.UpdateKeyVal("false", "truefont")
                        Else

                            ta.Insert("truefont", "False")
                            MsgBox(strFirstUse)
                        End If

                    Else

                    End If
                Else

                    ta.Insert("keypsv", val)
                    Dim dt2 = ta.GetData("truefont")
                    If dt.Rows.Count > 0 Then
                        ta.UpdateKeyVal("false", "truefont")
                    Else
                        ta.Insert("truefont", "False")
                    End If
                    MsgBox(strFirstUse)

                End If
                '''''''

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            Return 1
        End If

    End Function
    ' for slave
    Private Function checktrialSlave() As Boolean

        Using a As BoundClass = New BoundClass
            a.LoadDb()
            'a.LoadDb(btDbDv.Tag)
        End Using

        Dim resultkey As Integer = HandleRegistry()
       
        Try
            Dim ta As New ALMohassinDBDataSetTableAdapters.valueTableAdapter

            Dim dt2 = ta.GetData("truefont")

            If dt2.Rows(0).Item("val") = "true" Then
                Form1.btTrial.Visible = False
                Return True
                Exit Function
            Else
                If resultkey = 1 Then
                    Return True
                Else
                    Return False
                End If


            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function HandleRegistry() As Integer
        Dim ALMohasibfirstRunDate As Date

        ALMohasibfirstRunDate = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, Nothing)
        If ALMohasibfirstRunDate = Nothing Then
            ALMohasibfirstRunDate = Now
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\MUSCRRER", strKey, ALMohasibfirstRunDate)

            Return 1
        ElseIf (Now - ALMohasibfirstRunDate).Days > 60 Then
            Return 0
        Else
            Return 1
        End If

    End Function



End Module

Public Class BoundClass
    Implements IDisposable
    Private _PathDocs As String
    Private _DbPath As String
    Private _PathBoundDb As String

    Public Sub New()
        _PathDocs = Form1.ImgPah
        _DbPath = GetDatabaseName()
        _PathBoundDb = Form1.BoundDbPath
    End Sub

    Public Function SaveNewChangement(ByVal CaseType As String, ByVal tableName As String,
                                      ByVal params As Dictionary(Of String, Object),
                                      Optional ByVal where As Dictionary(Of String, Object) = Nothing) As Boolean

        Try
            Dim TextLine As String = CaseType & "|" & tableName & "|"
            If params IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, Object) In params
                    TextLine &= kvp.Key & "_" & kvp.Value & "_"
                Next
                TextLine = TextLine.Substring(0, TextLine.Length - 1)
            End If

            If where IsNot Nothing Then
                TextLine &= "|"
                For Each kvp As KeyValuePair(Of String, Object) In where
                    TextLine &= kvp.Key & "_" & kvp.Value & "_"
                Next
                TextLine = TextLine.Substring(0, TextLine.Length - 1)
            End If

            Dim file As System.IO.StreamWriter
            Dim FILE_NAME As String = _PathDocs & "\Docs\Sv_New_Ch.dat"
            file = My.Computer.FileSystem.OpenTextFileWriter(FILE_NAME, True)
            file.WriteLine(TextLine)
            file.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LoadNewChangement() As Boolean
        Try
            Dim FILE_NAME As String = _PathDocs & "\Docs\Sv_New_Ch.dat"
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                If System.IO.File.Exists(FILE_NAME) = True Then
                    Dim objReader As New System.IO.StreamReader(FILE_NAME)
                    Do While objReader.Peek() <> -1
                        Dim TextLine As String() = CStr(objReader.ReadLine()).Split("|")
                        Dim tableName As String = CStr(TextLine(1))
                        Dim params As New Dictionary(Of String, Object)
                        Dim where As New Dictionary(Of String, Object)

                        Dim param As String() = CStr(TextLine(2)).Split("_")
                        For i As Integer = 0 To param.Length - 1 Step 2
                            params.Add(param(i), param(i + 1))
                        Next

                        If TextLine.Length > 3 Then
                            Dim wher As String() = CStr(TextLine(3)).Split("_")
                            For i As Integer = 0 To param.Length - 1 Step 2
                                where.Add(wher(i), wher(i + 1))
                            Next
                        End If

                        Select Case TextLine(0)
                            Case "insert"
                                c.InsertRecord(tableName, params)
                            Case "update"
                                'Try
                                '    Dim dt = c.SelectDataTable(tableName, {"*"}, where)
                                '    If dt.Rows.Count > 0 Then
                                '        c.UpdateRecord(tableName, params, where)
                                '    End If
                                'Catch ex As Exception
                                'End Try
                                c.UpdateRecord(tableName, params, where)
                            Case "delete"
                                c.DeleteRecords(tableName, params)
                        End Select
                    Loop
                    Return True
                Else
                    Return False
                End If
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LoadDb() As Boolean
        Try
            If File.Exists(_PathBoundDb) Then
                File.Copy(_PathBoundDb, _DbPath, True)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LoadDb(ByRef p As String) As Boolean
        Try
            If File.Exists(p) Then

                File.Copy(p, _DbPath, True)
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub DeletOldFiles()
        Try
            Dim FILE_NAME As String = _PathDocs & "\Docs\Sv_New_Ch.dat"
            File.Delete(FILE_NAME)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ChangeConnectionString()
        Try

            Dim _ldbfile As String = _PathBoundDb.Replace("mdb", "ldb")
            If File.Exists(_ldbfile) Then
                MsgBox("يوجد حاجز للربط بقاعدة البيانات المشتركة")
                Exit Sub
            End If


            Dim lcConnString = My.Settings.ALMohassinDBConnectionString
            lcConnString = lcConnString.ToLower

            ' if this is a Jet database, find the index of the "data source" setting
            Dim startIndex As Integer
            If lcConnString.IndexOf("jet.oledb") > -1 Then
                startIndex = lcConnString.IndexOf("data source=")
                If startIndex > -1 Then startIndex += 12
            Else
                ' if this is a SQL Server database, find the index of the "initial 
                ' catalog" or "database" setting
                startIndex = lcConnString.IndexOf("initial catalog=")
                If startIndex > -1 Then
                    startIndex += 16
                Else ' if the "Initial Catalog" setting is not found,
                    '  try with "Database"
                    startIndex = lcConnString.IndexOf("database=")
                    If startIndex > -1 Then startIndex += 9
                End If
            End If

            ' if the "database", "data source" or "initial catalog" values are not 
            ' found, return an empty string
            If startIndex = -1 Then Exit Sub

            ' find where the database name/path ends
            Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
            If endIndex = -1 Then endIndex = lcConnString.Length

            ' return the substring with the database name/path
            Dim oldchar As String = lcConnString.Substring(startIndex, endIndex - startIndex)

            lcConnString = lcConnString.Replace(oldchar, _PathBoundDb)

            My.Settings.Item("ALMohassinDBConnectionString") = lcConnString
        Catch ex As Exception

        End Try
    End Sub

    Function GetDatabaseName() As String
        Dim lcConnString = My.Settings.ALMohassinDBConnectionString
        lcConnString = lcConnString.ToLower

        ' if this is a Jet database, find the index of the "data source" setting
        Dim startIndex As Integer
        If lcConnString.IndexOf("jet.oledb") > -1 Then
            startIndex = lcConnString.IndexOf("data source=")
            If startIndex > -1 Then startIndex += 12
        Else
            ' if this is a SQL Server database, find the index of the "initial 
            ' catalog" or "database" setting
            startIndex = lcConnString.IndexOf("initial catalog=")
            If startIndex > -1 Then
                startIndex += 16
            Else ' if the "Initial Catalog" setting is not found,
                '  try with "Database"
                startIndex = lcConnString.IndexOf("database=")
                If startIndex > -1 Then startIndex += 9
            End If
        End If

        ' if the "database", "data source" or "initial catalog" values are not 
        ' found, return an empty string
        If startIndex = -1 Then Return ""

        ' find where the database name/path ends
        Dim endIndex As Integer = lcConnString.IndexOf(";", startIndex)
        If endIndex = -1 Then endIndex = lcConnString.Length

        ' return the substring with the database name/path
        Return lcConnString.Substring(startIndex, endIndex - startIndex)
    End Function

    Public Function LoadDbToDrive(ByVal P As String) As Boolean
        Try
            'If File.Exists(P) Then
            Dim a = _DbPath.Replace("|datadirectory|\", "")
            File.Copy(a, P, True)
            'End If

            Return True
        Catch ex As Exception
            Return False
        End Try
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