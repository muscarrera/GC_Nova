Public Class AddEditCharge

    Private _id As Integer = 0
    Public Property Vid As Integer
        Get
            Dim v As Integer = 0
            If IsNumeric(txtvehicule.text) Then
                v = CInt(txtvehicule.text)
            ElseIf txtvehicule.text.Contains("|") = True Then
                If txtvehicule.AutoCompleteSource.Contains(txtvehicule.text.ToUpper) Then
                    v = txtvehicule.text.Trim.Split("|")(2)
                Else
                    v = 0
                End If
            Else
                v = 0
            End If

            Return v
        End Get
        Set(ByVal value As Integer)
            txtvehicule.text = value
        End Set
    End Property
    Public Property Drid As Integer
        Get
            Dim v As Integer = 0
            If IsNumeric(txtdriver.text) Then
                v = CInt(txtdriver.text)
            ElseIf txtdriver.text.Contains("|") = True Then
                If txtdriver.AutoCompleteSource.Contains(txtdriver.text.ToUpper) Then
                    v = txtdriver.text.Trim.Split("|")(1)
                Else
                    v = 0
                End If
            Else
                v = 0
            End If

            Return v
        End Get
        Set(ByVal value As Integer)
            txtdriver.text = value
        End Set
    End Property
    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

            If value > 0 Then
                getData()
            End If
        End Set
    End Property

    Public Sub getData()
        If id = 0 Then Exit Sub

        Try
         
            Dim params As New Dictionary(Of String, Object)
            params.Add("id", id)
          
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                Dim dt = c.SelectDataTable("Details_Charge", {"*"}, params)

                txtDKey.text = StrValue(dt, "name", 0)
                txtDValue.text = DblValue(dt, "value", 0)
                txtDate.text = DteValue(dt, "date", 0).ToString("dd/MM/yyyy")

                Dim vv = IntValue(dt, "vid", 0)
                If vv > 0 Then
                    params.Clear()
                    params.Add("Vid", vv)
                    Dim v = c.SelectByScalar("Vehicule", "ref", params)
                    Dim n = c.SelectByScalar("Vehicule", "name", params)
                    txtvehicule.text = v & "|" & n & "|" & vv
                End If
                params.Clear()

                Dim dd = IntValue(dt, "drid", 0)
                If dd > 0 Then
                    params.Clear()
                    params.Add("Drid", dd)
                    Dim v = c.SelectByScalar("Driver", "name", params)
                    txtdriver.text = v & "|" & dd
                End If

                params = Nothing
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel2.Click, Label2.Click
        txtdriver.Focus()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click, Label1.Click
        txtvehicule.Focus()
    End Sub

    Private Sub Label17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel21.Click, Label17.Click, Panel3.Click, Label3.Click
        txtDKey.Focus()
    End Sub

    Private Sub Label21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel57.Click, Label21.Click
        txtDValue.Focus()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Try
            If Vid = 0 And Drid = 0 Then Exit Sub
            If txtDValue.text = 0 Or txtDValue.text.Trim = "" Then Exit Sub
            Dim dte As Date = Now.Date
            Dim K As String = txtDKey.text.Trim
            If K.Contains("(") Then
                K = K.Split("(")(0)
            End If



            If IsDate(txtDate.text) Then dte = CDate(txtDate.text)

            Dim params As New Dictionary(Of String, Object)
            params.Add("name", txtDKey.text)
            params.Add("value", CDbl(txtDValue.text))
            params.Add("vid", Vid)
            params.Add("drid", Drid)
            params.Add("writer", Form1.adminName)
            params.Add("date", dte)
            'params.Add("ex", Form1.Exercice)
            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

                If id > 0 Then
                    Dim where As New Dictionary(Of String, Object)
                    where.Add("id", id)
                    c.UpdateRecord("Details_Charge", params, where)
                    where = Nothing
                Else
                    params.Add("ex", Form1.Exercice)
                    id = c.InsertRecord("Details_Charge", params, True)
                End If



                Try ' AUTOCOMPLITE CHARGE MISSION
                    If K <> "" Then
                        params.Clear()
                        params.Add("name", K)
                        params.Add("key", "MISSION")
                        params.Add("val", "CHARGE")
                        Dim dt_d = c.SelectDataTable("Word", {"*"}, params)
                        params.Clear()

                        If dt_d.Rows.Count = 0 Then
                            params.Clear()
                            params.Add("name", K)
                            params.Add("key", "MISSION")
                            params.Add("val", "CHARGE")

                            c.InsertRecord("Word", params)
                        End If
                    End If
                Catch ex As Exception

                End Try






                params = Nothing
            End Using
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtDKey_KeyDownOk() Handles txtDKey.KeyDownOk, txtDate.KeyDownOk
        If txtDKey.text.Contains("(") Then
            txtDValue.Focus()
        Else
            txtDKey.text &= " ( )"
            txtDKey.Select(txtDKey.text.Length - 1, 0)
        End If
    End Sub
    Private Sub AddEditCharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtdriver.AutoCompleteSource = AutoCompleteByNameUpper("Driver")
        txtvehicule.AutoCompleteSource = AutoCompleteByVehicule("Vehicule")
        txtDKey.AutoCompleteSource = AutoCompleteFromWords("MISSION", "CHARGE")

        If id = 0 Then txtDate.text = Now.Date.ToString("dd/MM/yyyy")

        Try
            txtdriver.TXT.CharacterCasing = CharacterCasing.Upper
            txtvehicule.TXT.CharacterCasing = CharacterCasing.Upper


        Catch ex As Exception

        End Try



    End Sub

    Private Sub txtDate_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDate.Leave
        If Not IsDate(txtDate.text) Then
            txtDate.text = Now.Date.ToString("dd/MM/yyyy")
        End If
    End Sub
End Class