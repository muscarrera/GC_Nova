Imports System.IO

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
                    lst.Add(dt.Rows(i).Item("name").ToString.ToUpper & "|" & dt.Rows(i).Item(0).ToString)
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function AutoCompleteByVehicule(ByVal tb As String) As AutoCompleteStringCollection
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
                    lst.Add(dt.Rows(i).Item("ref").ToString.ToUpper & "|" & dt.Rows(i).Item("name").ToString.ToUpper & "|" & dt.Rows(i).Item(0).ToString)
                    lst.Add(dt.Rows(i).Item("ref").ToString & "|" & dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function AutoCompleteByNameUpper(ByVal tb As String) As AutoCompleteStringCollection
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
                    lst.Add(dt.Rows(i).Item("name").ToString.ToUpper & "|" & dt.Rows(i).Item(0).ToString)
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function AutoCompleteFromWords(ByVal key As String, ByVal val As String) As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim params As New Dictionary(Of String, Object)
            params.Add("key", key)
            params.Add("val", val)
            Dim dt As DataTable = a.SelectDataTable("Word", {"*"}, params)

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString.ToUpper)
                    lst.Add(dt.Rows(i).Item("name").ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function AutoCompleteByMission(ByVal tb As String) As AutoCompleteStringCollection
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
                    If lst.Contains(dt.Rows(i).Item("name").ToString.Split("(")(0)) Then Continue For
                    lst.Add(dt.Rows(i).Item("name").ToString.Split("(")(0))
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


    Sub SplitDecimal(ByVal number As Decimal, ByRef wholePart As Decimal, _
                 ByRef fractionalPart As Decimal)
        wholePart = Math.Truncate(number)
        fractionalPart = number - wholePart
    End Sub



    '''''''''''''''''''''''''
    'Strings

    Public MsgDelete As String = "Etes-vous certain de vouloir supprimer cet element"


    '''''''''
    'save datagrid as HTML and prit it


    Public Sub SaveDataToHtml(ByVal dg As DataGridView, ByVal nm As String)
        'create empty string

        Dim the_html_file As String = String.Empty

        Dim stylesheet As String = "  table.gridtable {margin:0 auto;width:95%;overflow:auto;font-family: helvetica,arial,sans-serif;"
        stylesheet &= "font-size:14px;color:#333333;border-width: 1px;border-color: #666666;border-collapse: collapse;text-align: center}"
        stylesheet &= "table.gridtable th {border-width: 1px;padding: 8px; border-style: solid;border-color: #666666;background-color: #F6B4A5;}"
        stylesheet &= "table.gridtable td {border-width: 1px;padding: 8px;border-style: solid;border-color: #666666;}"

        the_html_file = "<!DOCTYPE html><html><head><meta charset='UTF-8'><title> " & nm & "</title><style>" & stylesheet & "</style></head><body>"

        the_html_file &= "<table class='gridtable'>"
        the_html_file &= "<thead><tr>"

        'get the column headers
        For Each column As DataGridViewColumn In dg.Columns
            If column.Visible = False Then Continue For

            the_html_file = the_html_file & "<th>" & column.HeaderText & "</th>"
        Next

        the_html_file = the_html_file & "</tr></thead><tbody>"

        'get the rows
        For Each row As DataGridViewRow In dg.Rows
            the_html_file &= "<tr>"
            'get the cells
            For Each cell As DataGridViewCell In row.Cells
                If dg.Columns(cell.ColumnIndex).Visible = False Then Continue For
                Dim cellcontent As String = cell.FormattedValue
                'replace < and > with html entities
                cellcontent = Replace(cellcontent, "<", "&lt;")
                cellcontent = Replace(cellcontent, ">", "&gt;")

                'using inline styles for column 1
                'If cell.ColumnIndex = 1 Then
                '    the_html_file = the_html_file & "<td style=color:white;background-color:red;font-weight:bold>" & cellcontent & "</td>"
                'Else
                '    the_html_file = the_html_file & "<td>" & cellcontent & "</td>"
                'End If
                'no inline styles
                the_html_file = the_html_file & "<td>" & cellcontent & "</td>"

            Next
            the_html_file &= "</tr>"
        Next

        the_html_file &= "</tbody></table></body></html>"


        Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\output")
        If dir1.Exists = False Then dir1.Create()

        'write the file
        My.Computer.FileSystem.WriteAllText(Form1.ImgPah & "\output\" & nm & ".html", the_html_file, False)

        'pass file to default browser
        Dim pinfo As New ProcessStartInfo()
        pinfo.WindowStyle = ProcessWindowStyle.Normal
        pinfo.FileName = Form1.ImgPah & "\output\" & nm & ".html"
        Dim p As Process = Process.Start(pinfo)

    End Sub

End Module
