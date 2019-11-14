Public Class Payement
    Public id As Integer
    Public dte As Date
    Public way As String
    Public montant As Double
    Public ech As Date
    Public ref As String
    Public desig As String

    Public Sub New(ByVal _id As Integer, ByVal _dte As Date, ByVal _way As String, ByVal _mnt As Double, ByVal _ech As Date, ByVal _ref As String, ByVal _desig As String)
        id = _id
        dte = _dte
        way = _way
        montant = _mnt
        ech = _ech
        ref = _ref
        desig = _desig
    End Sub
    Public Sub New()
        id = 0
        dte = Now.Date
        way = ""
        montant = 0
        ech = Now.Date
        ref = ""
        desig = ""
    End Sub
End Class
