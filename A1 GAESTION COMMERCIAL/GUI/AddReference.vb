Public Class AddReference

    Dim params As New Dictionary(Of String, Object)
    Dim tableName As String

    Private Sub AddReference_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CL.ListeOfString.Clear()
        CL.ListeOfNumber.Clear()
        CL.ListeOfDates.Clear()
        CL.ListeOfBoolean.Clear()

        CL.ListeOfString.Add("Mode de Paiement", "MP")
        CL.ListeOfString.Add("Reference", "RF")
        CL.ListeOfString.Add("Editeur", "ED")
        CL.ListeOfString.Add("En Compte de ", "EC")
        '''''/// numbers
        CL.ListeOfNumber.Add("Total Min", "PM")
        CL.ListeOfNumber.Add("Total Max", "PX")
        CL.ListeOfNumber.Add("En Compte de ", "EC")
        CL.ListeOfNumber.Add("Devis N°", "DV")
        CL.ListeOfNumber.Add("Reference", "RF")
        CL.ListeOfNumber.Add("N°", "ID")

        '''''/// Booleans
        CL.ListeOfBoolean.Add("Réglé", "RG")
        '''''/// Date
        CL.ListeOfDates.Add("Date", "DT")
        CL.ListeOfDates.Add("Date Min", "DM")
        CL.ListeOfDates.Add("Date Max", "DX")

    End Sub
    Private Sub txt_TxtChanged() Handles txt.TxtChanged
        If txt.text.Trim = "" Then
            CL.Mode = 0
            plTag.Height = 1
        ElseIf IsNumeric(txt.text) Then
            CL.Mode = 2
            plTag.Height = 140
        ElseIf IsDate(txt.text) Then
            CL.Mode = 4
            plTag.Height = 1
        Else
            If txt.text.ToUpper.Trim = "NO" Or txt.text.ToUpper.Trim = "NON" Or
                txt.text.ToUpper.Trim = "OUI" Or txt.text.ToUpper.Trim = "O" Then
                CL.Mode = 3
                plTag.Height = 40
            Else
                CL.Mode = 1
                plTag.Height = 120
            End If
        End If
    End Sub
    Private Sub CL_LabelClicked(ByVal key As System.String, ByVal val As System.String) Handles CL.LabelClicked

        Dim myKey As String = "[name] Like "
        Dim myVal As New Object

        Select Case val


            Case "RF"
                myKey = "Bon_Commande Like "
                myVal = "%" & txt.text & "%"
            Case "MP"
                myKey = "modePayement Like "
                myVal = "%" & txt.text & "%"
            Case "ED"
                myKey = "writer Like "
                myVal = "%" & txt.text & "%"
            Case "DV"
                myKey = "devis Like "
                myVal = "%" & txt.text & "%"
            Case "PX"
                myKey = "total < "
                myVal = txt.text

            Case "PM"
                myKey = "total > "
                myVal = txt.text

            Case "RG"
                Dim isPayed As Boolean = True
                Dim v = txt.text
                If v.ToUpper = "NO" Or v.ToUpper = "NON" Or v.ToUpper = "N" Then
                    isPayed = False
                End If
                myKey = "isPayed = "
                myVal = isPayed
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

        txt.text = ""
        Search()
    End Sub
    Private Sub DeleteTag(ByVal T As A1_GAESTION_COMMERCIAL.Tag)
        FL.Controls.Remove(T)
        Search()
    End Sub
    Private Sub Search()

        DataGridView1.Rows.Clear()
        If FL.Controls.Count = 0 Then Exit Sub

        params.Clear()
        For Each c As Tag In FL.Controls
            Try
                params.Add(c.myKey, c.myVal)

            Catch ex As Exception
            End Try
        Next

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTableSymbols(tableName, {"*"}, params)


            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    DataGridView1.Rows.Add(dt.Rows(i).Item(0), dt.Rows(i).Item("date").ToString("dd/MM/yyyy"),
                                        String.Format("{0:n}", CDec(dt.Rows(i).Item("total"))),
                                        String.Format("{0:n}", CDec(dt.Rows(i).Item("avance"))))

                Next
            End If
        End Using
    End Sub
End Class