Public Class AppChart

    Event LoadHome(ByVal ds As AppChart)

    Public Property Title As String
        Get
            Return ch.Titles(0).Text
        End Get
        Set(ByVal value As String)
            ch.Titles(0).Text = value
        End Set
    End Property
    Public Property TitleColor As Color
        Get
            Return ch.Titles(0).ForeColor
        End Get
        Set(ByVal value As Color)
            ch.Titles(0).ForeColor = value
        End Set
    End Property


End Class
