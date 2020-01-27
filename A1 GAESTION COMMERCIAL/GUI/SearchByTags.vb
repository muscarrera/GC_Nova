Public Class SearchByTags
    Private _tableName As String
    Dim myId As String = "id"

    Public params As New Dictionary(Of String, Object)

    Public Property TableName As String
        Get
            Return _tableName
        End Get
        Set(ByVal value As String)
            _tableName = value

            CL.ListeOfString.Clear()
            CL.ListeOfNumber.Clear()
            CL.ListeOfDates.Clear()
            CL.ListeOfBoolean.Clear()

            If value = "Mission" Then
                myId = "Mid"
                CL.ListeOfString.Add("Editeur", "ED")
                CL.ListeOfString.Add("Destination", "DS")
                CL.ListeOfString.Add("Depart", "DP")
                CL.ListeOfString.Add("Domaine", "DN")
                CL.ListeOfString.Add("Vehicule", "VH")
                CL.ListeOfString.Add("Chauffeur", "CH")
                CL.ListeOfString.Add("Client", "CL")

                '''''/// numbers
                CL.ListeOfNumber.Add("Bon de Transport", "BT")
                CL.ListeOfNumber.Add("Total Max", "TX")
                CL.ListeOfNumber.Add("Total Min", "TM")
                CL.ListeOfNumber.Add("N°", "ID")
                '''''/// Date
                CL.ListeOfDates.Add("Date", "DT")
                CL.ListeOfDates.Add("Date Min", "DM")
                CL.ListeOfDates.Add("Date Max", "DX")
            ElseIf value = "Bon_Transport" Then
                myId = "id"
                CL.ListeOfString.Add("Editeur", "ED")
                CL.ListeOfString.Add("Client", "CL")
                '''''/// numbers
                CL.ListeOfNumber.Add("Avance Max", "AX")
                CL.ListeOfNumber.Add("Avance Min", "AM")
                CL.ListeOfNumber.Add("Total Max", "TX")
                CL.ListeOfNumber.Add("Total Min", "TM")
                CL.ListeOfNumber.Add("N°", "ID")
                '''''/// Booleans
                CL.ListeOfBoolean.Add("Facturé", "FT")
                CL.ListeOfBoolean.Add("Reglé", "RG")
                '''''/// Date
                CL.ListeOfDates.Add("Date", "DT")
                CL.ListeOfDates.Add("Date Max", "DX")
                CL.ListeOfDates.Add("Date Min", "DM")
            ElseIf value = "Driver" Then
                myId = "Drid"
                CL.ListeOfString.Add("Chauffeur", "CH")
                '''''/// numbers
                CL.ListeOfNumber.Add("N°", "ID")
            ElseIf value = "Vehicule" Then
                myId = "Vid"
                CL.ListeOfString.Add("Vehicule", "VH")
                '''''/// numbers
                CL.ListeOfNumber.Add("N°", "ID")
            ElseIf value = "Details_Charge" Then
                myId = "id"
                CL.ListeOfString.Add("Editeur", "ED")
                CL.ListeOfString.Add("Chauffeur", "CH")
                CL.ListeOfString.Add("Vehicule", "VH")
                CL.ListeOfString.Add("Client", "CL")
                '''''/// numbers
                CL.ListeOfNumber.Add("Total Max", "VX")
                CL.ListeOfNumber.Add("Total Min", "VM")
                CL.ListeOfNumber.Add("N°", "ID")
                '''''/// Date
                CL.ListeOfDates.Add("Date", "DT")
                CL.ListeOfDates.Add("Date Max", "DX")
                CL.ListeOfDates.Add("Date Min", "DM")

            ElseIf value = "Sell_Facture" Then
                CL.ListeOfString.Add("Editeur", "ED")
                CL.ListeOfString.Add("Mode de Payement", "MP")
                CL.ListeOfString.Add("En Compte de", "EC")
                CL.ListeOfString.Add("Client", "CL")

                '''''/// numbers
                CL.ListeOfNumber.Add("Tva Min", "TM")
                CL.ListeOfNumber.Add("Remise Min", "RM")
                CL.ListeOfNumber.Add("Avance Min", "AM")
                CL.ListeOfNumber.Add("Avance Max", "AX")
                CL.ListeOfNumber.Add("Total Min", "TM")
                CL.ListeOfNumber.Add("Total Max", "TX")
                CL.ListeOfNumber.Add("N°", "ID")
                '''''/// Booleans
                CL.ListeOfBoolean.Add("Reglé", "RG")
                CL.ListeOfBoolean.Add("Facturé", "FC")
                '''''/// Date
                CL.ListeOfDates.Add("Date", "DT")
                CL.ListeOfDates.Add("Date Max", "DX")
                CL.ListeOfDates.Add("Date Min", "DM")

            Else

                CL.ListeOfString.Add("Editeur", "ED")
                CL.ListeOfString.Add("Depart", "DP")
                CL.ListeOfString.Add("Destination", "DS")
                CL.ListeOfString.Add("Domaine", "DN")
                CL.ListeOfString.Add("Chauffeur", "CH")
                CL.ListeOfString.Add("Vehicule", "VH")
                CL.ListeOfString.Add("Client", "CL")
                '''''/// numbers

                CL.ListeOfNumber.Add("Avance Min", "AM")
                CL.ListeOfNumber.Add("Avance Max", "AX")
                CL.ListeOfNumber.Add("Total Min", "TM")
                CL.ListeOfNumber.Add("Total Max", "TX")
                CL.ListeOfNumber.Add("N°", "ID")
                '''''/// Booleans
                CL.ListeOfBoolean.Add("Reglé", "RG")
                CL.ListeOfBoolean.Add("Facturé", "FT")

                '''''/// Date
                CL.ListeOfDates.Add("Date", "DT")
                CL.ListeOfDates.Add("Date Max", "DX")
                CL.ListeOfDates.Add("Date Min", "DM")
            End If



        End Set
    End Property
    Private Sub txt_TxtChanged() Handles txt.TxtChanged
        If txt.text.Trim = "" Then
            CL.Mode = 0
        ElseIf IsNumeric(txt.text) Then
            CL.Mode = 2
        ElseIf IsDate(txt.text) Then
            CL.Mode = 4
        Else
            If txt.text.ToUpper.Trim = "NO" Or txt.text.ToUpper.Trim = "NON" Or
                txt.text.ToUpper.Trim = "OUI" Or txt.text.ToUpper.Trim = "O" Then
                CL.Mode = 3
            Else

                CL.Mode = 1
            End If
        End If
    End Sub

    Private Sub CL_Clear() Handles CL.Clear
        txt.text = ""
    End Sub

    Private Sub CL_LabelClicked(ByVal key As System.String, ByVal val As System.String) Handles CL.LabelClicked

        Dim myKey As String = "[name] Like "
        Dim myVal As New Object

        Select Case val
          
            Case "CL"
                val = "name = "
                myVal = "%" & txt.text & "%"
                If TableName = "Mission" Then
                    val = "clientName = "
                    myKey = "clientName Like "
                End If
            Case "CH"
                myKey = "drid = "
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    If IsNumeric(txt.text) Then
                        myVal = txt.text
                    Else
                        Dim where As New Dictionary(Of String, Object)
                        where.Add("[name] Like ", txt.text & "%")

                        Dim dt = a.SelectDataTableSymbols("Driver", {"*"}, where)
                        If dt.Rows.Count > 0 Then
                            myVal = CInt(dt.Rows(0).Item(0))
                            txt.text = dt.Rows(0).Item("name")
                        End If
                    End If
                End Using
            Case "VH"
                myKey = "vid = "
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    If IsNumeric(txt.text) Then
                        myVal = txt.text
                    Else
                        Dim where As New Dictionary(Of String, Object)
                        where.Add("[ref] Like ", txt.text & "%")

                        Dim dt = a.SelectDataTableSymbols("Vehicule", {"*"}, where)
                        If dt.Rows.Count > 0 Then
                            myVal = CInt(dt.Rows(0).Item(0))
                            txt.text = dt.Rows(0).Item("ref")
                        End If
                    End If
                End Using
            Case "EC"
                myKey = "compteId = "
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                    If IsNumeric(txt.text) Then
                        myVal = txt.text
                    Else
                        Dim where As New Dictionary(Of String, Object)
                        where.Add("[name] Like ", "%" & txt.text & "%")

                        Dim dt = a.SelectDataTableSymbols("Client", {"*"}, where)
                        If dt.Rows.Count > 0 Then
                            myVal = CInt(dt.Rows(0).Item(0))
                            txt.text = dt.Rows(0).Item("name")
                        End If
                    End If
                End Using
            Case "DP"
                myKey = "depart Like "
                myVal = txt.text & "%"
            Case "DS"
                myKey = "arrive Like "
                myVal = txt.text & "%"
            Case "DN"
                myKey = "domain Like "
                myVal = txt.text & "%"
            Case "ED"
                myKey = "writer Like "
                myVal = txt.text & "%"
            Case "MP"
                myKey = "modePayement Like "
                myVal = txt.text & "%"

            Case "ID"
                myKey = myId & " Like "
                myVal = "%" & txt.text & "%"
            Case "BT"
                myKey = "Bon_Transport = "
                myVal = txt.text
            Case "TM"
                myKey = "total > "
                myVal = txt.text
            Case "TX"
                myKey = "total < "
                myVal = txt.text
            Case "AM"
                myKey = "total > "
                myVal = txt.text
            Case "AX"
                myKey = "total < "
                myVal = txt.text
            Case "VM"
                myKey = "value > "
                myVal = txt.text
            Case "VX"
                myKey = "value < "
                myVal = txt.text
            Case "TM"
                myKey = "tva > "
                myVal = txt.text
            Case "RM"
                myKey = "Remise > "
                myVal = txt.text
            Case "RG"
                Dim isPayed As Boolean = True
                Dim v = txt.text
                If V.ToUpper = "NO" Or V.ToUpper = "NON" Or V.ToUpper = "N" Then
                    isPayed = False
                End If
                myKey = "isPayed = "
                myVal = isPayed

            Case "FT"
                Dim isf As Boolean = True
                Dim v = txt.text
                If v.ToUpper = "NO" Or v.ToUpper = "NON" Or v.ToUpper = "N" Then
                    isf = False
                End If
                myKey = "isFactured = "
                myVal = isf
            Case "FC"
                Dim v = txt.text
                If v.ToUpper = "NO" Or v.ToUpper = "NON" Or v.ToUpper = "N" Then
                    myVal = "Fini"
                Else
                    myVal = "Facturé"
                End If
                myKey = "isAdmin = "

            Case "DT" ''''''''''''''''''''''''''''''

            Case "DM"
                Dim dte As Date = CDate(txt.text).AddDays(-1)
                myKey = "[date] > "
                myVal = dte
                txt.text = CDate(txt.text).ToString("dd MMM yyyy")
            Case "DX"
                Dim dte As Date = CDate(txt.text).AddDays(1)
                myKey = "[date] < "
                myVal = dte
                txt.text = CDate(txt.text).ToString("dd MMM yyyy")
        End Select






        Dim tg As New Tag
        tg.myKey = myKey
        tg.myVal = myVal


        tg.val = txt.text
        tg.key = key

        FL.Controls.Add(tg)
        AddHandler tg.DeleteTag, AddressOf DeleteTag

    End Sub

    Private Sub DeleteTag(ByVal T As A1_GAESTION_COMMERCIAL.Tag)
        FL.Controls.Remove(T)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If FL.Controls.Count = 0 Then Exit Sub

        params.Clear()
        For Each c As Tag In FL.Controls
            Try
                params.Add(c.myKey, c.myVal)
            Catch ex As Exception
            End Try
        Next

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class