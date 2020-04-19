Public Class App_Home

    Event LoadHome(ByRef ds As App_Home)

    Private Sub App_Home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RaiseEvent LoadHome(Me)
    End Sub
End Class
