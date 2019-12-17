Public Class VehiculeDetails
    Private _id As Integer = 0

    Public tb_V As String = "Vehicule"
    Dim tb_M As String = "Mission"
    Dim tb_C As String = "Details_Charge"

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            Dim dd As Date = Now.Date
            TXT.text = dd.AddMonths(-1).ToString("dd/MM/yyyy") & " > " & dd.ToString("dd/MM/yyyy")
            getVehiculeDetails(value)
            getFactures(value)
        End Set
    End Property

    Private Sub getVehiculeDetails(ByVal value As Integer)
        If id > 0 Then
            Dim params As New Dictionary(Of String, Object)
            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                params.Clear()
                params.Add("Vid", id)
                Dim Vdt = a.SelectDataTable("Vehicule", {"*"}, params)
                If Vdt.Rows.Count > 0 Then

                    lbName.Text = Vdt.Rows(0).Item("name") & "[" & StrValue(Vdt, 0, 0) & "]"
                    lbInfo.Text = StrValue(Vdt, "ref", 0) & vbNewLine & StrValue(Vdt, "km", 0) & vbNewLine & StrValue(Vdt, "etat", 0)
                    lbInfo2.Text = StrValue(Vdt, "marque", 0) & vbNewLine & StrValue(Vdt, "model", 0) & " " & StrValue(Vdt, "year", 0) &
                                    vbNewLine & StrValue(Vdt, "carb", 0) & vbNewLine & StrValue(Vdt, "info", 0)

                End If
            End Using
        End If
    End Sub
    Private Sub getFactures(ByVal vid As Integer)
        Try
            Dim params As New Dictionary(Of String, Object)
            plBodyBl.Controls.Clear()
            plBodyFct.Controls.Clear()

            Dim dt1, dt2 As Date
            Dim str As String() = TXT.text.Split(">")

            Try
                dt1 = CDate(str(0).Trim).AddDays(-1)
            Catch ex As Exception
                pl.BackColor = Color.Red
                TXT.Focus()
                Exit Sub
            End Try


            Try
                dt2 = CDate(str(1).Trim).AddDays(1)
            Catch ex As Exception
                dt2 = Now.Date.AddDays(1)
            End Try

            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)

                params.Add("vid = ", vid)
                params.Add("[date] > ", dt1)
                params.Add("[date] < ", dt2)
                Dim dtM = c.SelectDataTableSymbols(tb_M, {"*"}, params)

                params.Clear()
                params.Add("vid = ", vid)
                params.Add("[date] > ", dt1)
                params.Add("[date] < ", dt2)
                Dim dtC = c.SelectDataTableSymbols(tb_C, {"*"}, params)

                Dim avc As Double = 0
                Dim ttc As Double = 0
                Dim kmd As Integer = 0
                Dim kma As Integer = 0

                Dim t As Double = 0
                If dtM.Rows.Count > 0 Then
                    For i As Integer = 0 To dtM.Rows.Count - 1
                        Dim a As New ClientRow
                        a.SizeAuto = True

                        a.Id = dtM.Rows(i).Item(0)
                        a.Libele = StrValue(dtM, "km_D", i) & " => " & StrValue(dtM, "km_A", i)
                        a.lbType.Text = DteValue(dtM, "date", i).ToString("dd/MMM")
                        a.Responsable = DblValue(dtM, "name", i)
                        a.Tel = String.Format("{0:n}", DblValue(dtM, "total", i))
                        a.Ville = String.Format("{0:n}", DblValue(dtM, "avance", i))

                        If BoolValue(dtM, "isPayed", i) Then a.PlLeft.BackgroundImage = My.Resources.fav_16


                        t += DblValue(dtM, "total", i) - DblValue(dtM, "avance", i)

                        avc += DblValue(dtM, "avance", i)
                        ttc += DblValue(dtM, "total", i)

                        If IntValue(dtM, "km_A", i) > 0 And IntValue(dtM, "km_A", i) > kma Then kma = IntValue(dtM, "km_A", i)
                        If IntValue(dtM, "km_D", i) > 0 And IntValue(dtM, "km_D", i) < kmd Then kmd = IntValue(dtM, "km_D", i)


                        a.Index = i + 1
                        a.Dock = DockStyle.Top
                        a.BringToFront()

                        plBodyFct.Controls.Add(a)
                    Next
                End If
                lbFctIm.Text = dtM.Rows.Count
                lbPath.Text = kmd & " => " & kma & " || " & kma - kmd & " Km"

                lbFTtc.Text = String.Format("{0:n}", ttc)
                lbFAvc.Text = String.Format("{0:n}", avc)


                t = 0
                avc = 0
                ttc = 0

                If dtC.Rows.Count > 0 Then
                    For i As Integer = 0 To dtC.Rows.Count - 1

                        Dim a As New ClientRow
                        a.SizeAuto = True

                        a.Id = dtM.Rows(i).Item(0)
                        a.Libele = StrValue(dtM, "name", i)
                        a.lbType.Text = DteValue(dtM, "date", i).ToString("dd/MMM")
                        a.Responsable = ""
                        a.Tel = String.Format("{0:n}", DblValue(dtM, "value", i))
                        a.Ville = ""

                        If IntValue(dtM, "mid", i) > 0 Then a.PlLeft.BackgroundImage = My.Resources.fav_16


                        ttc += DblValue(dtM, "value", i)

                        If IntValue(dtM, "km_A", i) > 0 And IntValue(dtM, "km_A", i) > kma Then kma = IntValue(dtM, "km_A", i)
                        If IntValue(dtM, "km_D", i) > 0 And IntValue(dtM, "km_D", i) < kmd Then kmd = IntValue(dtM, "km_D", i)


                        a.Index = i + 1
                        a.Dock = DockStyle.Top
                        a.BringToFront()

                        plBodyBl.Controls.Add(a)
                    Next



                End If

                lbBlImp.Text += CInt(dtC.Rows.Count)
                lbBlRest.Text = t
                lbBTtc.Text = String.Format("{0:n}", ttc)
                lbBAvc.Text = String.Format("{0:n}", avc)

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Edit_SelectedFacture(ByVal p1 As Integer)

    End Sub

    Private Sub Get_FactureInfos(ByVal p1 As Integer)

    End Sub

    Private Sub txt_TxtChanged() Handles TXT.TxtChanged
        PB.Visible = CBool(TXT.text.Count)

        If TXT.text.Length = 2 And TXT.text.EndsWith("/") = False Then
            TXT.text &= "/"
            TXT.Select(TXT.text.Length, 0)
        ElseIf TXT.text.Length = 5 And TXT.text.EndsWith("/") = False Then
            TXT.text &= "/"
            TXT.Select(TXT.text.Length, 0)
        ElseIf TXT.text.Length = 10 And TXT.text.EndsWith("/") = False Then
            TXT.text &= "  >  "
            TXT.Select(TXT.text.Length, 0)
        ElseIf TXT.text.Length = 17 And TXT.text.EndsWith("/") = False Then
            TXT.text &= "/"
            TXT.Select(TXT.text.Length, 0)
        ElseIf TXT.text.Length = 20 And TXT.text.EndsWith("/") = False Then
            TXT.text &= "/"
            TXT.Select(TXT.text.Length, 0)

        End If

    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub PB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB.Click
        TXT.text = ""
        TXT.Focus()
    End Sub
End Class