Public Class PvModel

    Public localName As String = "Default.dat"

    Public ClientId As Integer = 0
    Public ClientName As String = "Client"
    Public bonDate As Date = Now.Date.ToString("dd/MM/yyyy hh:mm")

    Public DataSource As New List(Of Article)


End Class
