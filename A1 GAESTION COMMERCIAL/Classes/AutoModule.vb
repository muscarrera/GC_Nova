Module AutoModule
    Public Function AutoCompleteByName(ByVal tb As String) As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable(tb, {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function StrValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As String
        Dim str As String = ""
        Try
            str = dt.Rows(i).Item(field).ToString
        Catch ex As Exception
            str = ""
        End Try
        Return str
    End Function
    Public Function DblValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Double
        Dim str As Double = 0
        Try
            str = CDbl(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = 0
        End Try
        Return str
    End Function
    Public Function IntValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Integer
        Dim str As Integer = 0
        Try
            str = CInt(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = 0
        End Try
        Return str
    End Function
    Public Function BoolValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Boolean
        Dim str As Boolean = False
        Try
            str = CBool(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = False
        End Try
        Return str
    End Function
    Public Function DteValue(ByVal dt As DataTable, ByVal field As String, ByVal i As Integer) As Date
        Dim str As Date = Now.Date
        Try
            str = CDate(dt.Rows(i).Item(field))
        Catch ex As Exception
            str = Now.Date
        End Try
        Return str
    End Function
    Public Function RandomColor() As Color

        Dim rnd As New Random
        Dim c As Color = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255))

        Return c
    End Function

End Module
