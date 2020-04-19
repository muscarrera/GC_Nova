Imports System.Xml.Serialization
Imports System.IO

Module ToXml
    Public Sub WriteToXmlFile(Of T As New)(ByVal filePath As String, ByVal objectToWrite As T, Optional ByVal append As Boolean = False)
        Dim writer As TextWriter = Nothing

        Try
            Dim serializer = New XmlSerializer(GetType(T))
            writer = New StreamWriter(filePath, append)
            serializer.Serialize(writer, objectToWrite)
        Finally
            If writer IsNot Nothing Then writer.Close()
        End Try
    End Sub

    Public Function ReadFromXmlFile(Of T As New)(ByVal filePath As String) As T
        Dim reader As TextReader = Nothing

        Try
            Dim serializer = New XmlSerializer(GetType(T))
            reader = New StreamReader(filePath)
            Return CType(serializer.Deserialize(reader), T)
        Finally
            If reader IsNot Nothing Then reader.Close()
        End Try
    End Function
End Module
