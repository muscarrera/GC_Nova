Public Class Facture

    Public client As New Client

    Public id As Integer = 0
    Public compteId As Integer = 0
    'Public name As String
    'Public adresse As String
    'Public Ice As String
    Public type As String
    Public modePayement As String
    Public writer As String

    Public totalHt As Double = 0
    'Public totalttc As Double = 0
    Public tva As Double = 0
    Public remise As Double = 0
    Public droitTimbre As Double = 0
    Public Avance As Double = 0

    Public dte As Date
    Public isAdmin As String
    Public isPayed As Boolean = False

    Public bl As String = ""
    Public bc As String = ""
    Public devis As String = ""
    Public pj As Integer = 0

    Public DataSource As DataTable = Nothing
    Public PaymenetDataSource As DataTable = Nothing


    Public ReadOnly Property TotalTTC As Double
        Get
            Dim t As Double = totalHt + tva + droitTimbre
            t -= remise
            Return t
        End Get
    End Property

    Public Sub New(ByVal _id As Integer, ByVal _type As String, ByVal _mode As String,
                    ByVal _Ht As Double, ByVal _Rs As Double, ByVal _timbre As Double,
                    ByVal _Avc As Double, ByVal _isAdm As Boolean, ByVal _isPyd As Boolean,
                    ByVal _date As Date, ByVal clt As Client)

        id = _id
        type = _type
        modePayement = _mode
        totalHt = _Ht
        remise = _Rs
        droitTimbre = _timbre
        Avance = _Avc
        isAdmin = _isAdm
        isPayed = _isPyd
        dte = _date
        client = clt
    End Sub
    Public Sub New(ByVal _id As Integer, ByVal _type As String, ByVal _mode As String,
                ByVal _Ht As Double, ByVal _Rs As Double, ByVal _timbre As Double,
                ByVal _Avc As Double, ByVal _isAdm As Boolean, ByVal _isPyd As Boolean,
                ByVal _date As Date, ByVal _cid As Integer, ByVal tb_C As String)

        id = _id
        type = _type
        modePayement = _mode
        totalHt = _Ht
        remise = _Rs
        droitTimbre = _timbre
        Avance = _Avc
        isAdmin = _isAdm
        isPayed = _isPyd
        dte = _date
        client = New Client(_cid, tb_C)
    End Sub
    Public Sub New(ByVal _id As Integer, ByVal tb_F As String, ByVal tb_C As String, ByVal tb_D As String, ByVal tb_P As String)
        id = 0
        Dim cid = 0
        Dim params As New Dictionary(Of String, Object)
        params.Add("id", _id)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable(tb_F, {"*"}, params)
            If dt.Rows.Count > 0 Then
                id = dt.Rows(0).Item(0)
                modePayement = StrValue(dt, "modePayement", 0)
                remise = DblValue(dt, "remise", 0)
                droitTimbre = DblValue(dt, "droitTimbre", 0)
                Avance = DblValue(dt, "Avance", 0)
                isAdmin = StrValue(dt, "isAdmin", 0)
                isPayed = BoolValue(dt, "isPayed", 0)
                dte = DteValue(dt, "Date", 0)
                cid = IntValue(dt, "cid", 0)
                compteId = IntValue(dt, "compteId", 0)
                bl = StrValue(dt, "Bon_Livraison", 0)
                bc = StrValue(dt, "Bon_Commande", 0)
                devis = StrValue(dt, "Devis", 0)

                writer = StrValue(dt, "writer", 0)
                pj = IntValue(dt, "pj", 0)

                params.Clear()
                params.Add("fctid", _id)
                DataSource = a.SelectDataTable(tb_D, {"*"}, params)

                params.Clear()
                params.Add(tb_F, _id)
                PaymenetDataSource = a.SelectDataTable(tb_P, {"*"}, params)
            End If
        End Using
        client = New Client(cid, tb_C)
    End Sub

    Public Sub New()
        id = 0
        modePayement = "Chique"
        totalHt = 0
        remise = 0
        droitTimbre = 0
        Avance = 0
        isAdmin = False
        isPayed = False
        dte = Date.Now
        client = Nothing
    End Sub
End Class
