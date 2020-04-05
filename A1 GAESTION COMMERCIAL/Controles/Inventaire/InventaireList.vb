Public Class InventaireList

    Event LoadHomePage(ByRef ds As InventaireList)

    Private Sub InventaireList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RaiseEvent LoadHomePage(Me)
    End Sub
End Class
