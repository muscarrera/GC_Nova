Imports System.Drawing.Printing

Public Class gGlobClass

    Public localName As String = "Default.dat"
    Public W_Page As Integer = 820
    Public h_Page As Integer = 1160
    Public P_name As String = "A4"
    Public p_Kind As PaperKind = PaperKind.A4
    Public is_Landscape As Boolean = False
    Public FooterFieldDic As New List(Of gTopField)
    Public TopFieldDic As New List(Of gTopField)
    Public TabProp As New gTabClass

End Class
