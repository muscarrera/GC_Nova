Public Class Client
    Public cid As Integer = 0
    Public delai As Integer = 0

    Public name As String
    Public ref As String
    Public isCompany As Boolean
    Public groupe As String
    Public ICE As String
    Public adresse As String
    Public cp As String
    Public ville As String
    Public tel As String
    Public gsm As String
    Public email As String
    Public info As String

    Public remise As Double = 0
    Public max As Double = 0


    Public ReadOnly Property isMax() As Boolean
        Get
            If max = 0 Then Return False

            Return False
        End Get
    End Property

    Public Sub New(ByVal _cid As Integer, ByVal _name As String, ByVal _type As String,
                    ByVal _ice As String, ByVal _adresse As String, ByVal _tel As String,
                   ByVal _email As String, ByVal _info As String, ByVal _remise As Integer,
                   ByVal _delai As Integer, ByVal _max As Double)

        cid = _cid
        name = _name
        groupe = _type
        ICE = _ice
        tel = _tel
        adresse = _adresse
        email = _email
        info = _info
        delai = _delai
        remise = _remise
        max = _max
    End Sub
    Public Sub New(ByVal _cid As Integer, ByVal tb_C As String)
        cid = 0
        Dim params As New Dictionary(Of String, Object)
        params.Add("Clid", _cid)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable(tb_C, {"*"}, params)
            If dt.Rows.Count > 0 Then
                cid = dt.Rows(0).Item(0)
                name = StrValue(dt, "name", 0) '
                ref = StrValue(dt, "ref", 0) 'dt.Rows(0).Item("ref")
                isCompany = StrValue(dt, "isCompany", 0) 'dt.Rows(0).Item("isCompany")
                groupe = StrValue(dt, "groupe", 0) 'dt.Rows(0).Item("groupe")
                ICE = StrValue(dt, "ice", 0) 'dt.Rows(0).Item("ice")

                adresse = StrValue(dt, "adresse", 0) 'dt.Rows(0).Item("adresse")

                Dim x As Boolean
                If Not IsDBNull(dt.Rows(0).Item("cp")) And dt.Rows(0).Item("cp") <> "" Then
                    x = True
                    adresse &= vbNewLine
                    adresse &= "CP : " & StrValue(dt, "cp", 0) 'dt.Rows(0).Item("cp")
                End If
                If Not IsDBNull(dt.Rows(0).Item("ville")) And dt.Rows(0).Item("ville") <> "" Then

                    If x = False Then adresse &= vbNewLine
                    adresse &= "-  " & StrValue(dt, "ville", 0).ToUpper ' dt.Rows(0).Item("ville").ToString.ToUpper
                End If

                tel = StrValue(dt, "tel", 0) 'dt.Rows(0).Item("tel")
                gsm = StrValue(dt, "gsm", 0) 'dt.Rows(0).Item("gsm")
                email = StrValue(dt, "email", 0) 'dt.Rows(0).Item("email")
                info = StrValue(dt, "info", 0) 'dt.Rows(0).Item("info")
                cp = StrValue(dt, "cp", 0) 'dt.Rows(0).Item("cp")
                ville = StrValue(dt, "ville", 0) ' dt.Rows(0).Item("ville")
                'delai = dt.Rows(0).Item("delai")
                'remise = dt.Rows(0).Item("remise")
                'max = dt.Rows(0).Item("max")
            End If
        End Using
    End Sub
    Public Sub New()

    End Sub
End Class
