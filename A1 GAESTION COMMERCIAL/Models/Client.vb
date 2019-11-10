Public Class Client
    Public cid As Integer = 0
    Public delai As Integer = 0

    Public name As String
    Public ref As String
    Public isCompany As Boolean
    Public groupe As String
    Public ICE As String
    Public adresse As String
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
                name = dt.Rows(0).Item("name")
                ref = dt.Rows(0).Item("ref")
                isCompany = dt.Rows(0).Item("isCompany")
                groupe = dt.Rows(0).Item("groupe")
                ICE = dt.Rows(0).Item("ice")

                adresse = dt.Rows(0).Item("adresse")

                Dim x As Boolean
                If Not IsDBNull(dt.Rows(0).Item("cp")) And dt.Rows(0).Item("cp") <> "" Then
                    x = True
                    adresse &= vbNewLine
                    adresse &= "CP : " & dt.Rows(0).Item("cp")
                End If
                If Not IsDBNull(dt.Rows(0).Item("cp")) And dt.Rows(0).Item("cp") <> "" Then

                    If x = False Then adresse &= vbNewLine
                    adresse &= "-  " & dt.Rows(0).Item("ville").ToString.ToUpper
                End If

                tel = dt.Rows(0).Item("tel")
                gsm = dt.Rows(0).Item("gsm")
                email = dt.Rows(0).Item("email")
                info = dt.Rows(0).Item("info")
                'delai = dt.Rows(0).Item("delai")
                'remise = dt.Rows(0).Item("remise")
                'max = dt.Rows(0).Item("max")
            End If
        End Using
    End Sub
    Public Sub New()

    End Sub
End Class
