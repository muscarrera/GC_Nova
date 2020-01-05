﻿Public Class Article
    Public arid As Integer = 0
    Public cid As Integer
    Public name As String
    Public desc As String
    Public ref As String

    Public sprice As Double = 0
    Public bprice As Double = 0
    Public TVA As Double = Form1.tva

    Public depot As Integer = 0
    Public remise As Double = 0
    Public isStocked As Boolean = True

    Public qte As Double = 0


    Public ReadOnly Property TotalHt() As Double
        Get
            Dim t As Double = sprice * qte
            't /= (100 + TVA) / 100
            Return t
        End Get
    End Property
    Public ReadOnly Property TotaltVA() As Double
        Get
            Dim t As Double = TotalHt - TotalRemise
            t = (t * TVA) / 100

            Return t
        End Get
    End Property
    Public ReadOnly Property TotalRemise() As Double
        Get
            Dim t As Double = (TotalHt * remise) / 100

            Return t
        End Get
    End Property
    Public ReadOnly Property TotalTTC() As Double
        Get
            Dim t As Double = (TotalHt - TotalRemise) + TotaltVA

            Return t
        End Get
    End Property

    Public Sub New(ByVal _arid As Integer, ByVal _cid As Integer, ByVal _name As String, ByVal _desc As String,
                    ByVal _qte As Double, ByVal _sprice As Double, ByVal _bprice As Double,
                   ByVal _remise As Double, ByVal _depot As Integer, ByVal _isStk As Integer,
                   ByVal _ref As String)

        arid = _arid
        cid = _cid
        name = _name
        desc = _desc
        qte = _qte
        sprice = _sprice
        bprice = _bprice
        ref = _ref
        depot = _depot
        isStocked = _isStk
        remise = _remise
    End Sub
    Public Sub New()

    End Sub
End Class
