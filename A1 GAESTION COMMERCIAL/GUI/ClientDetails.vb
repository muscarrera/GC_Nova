Public Class ClientDetails

    Private _id As Integer = 0

    Public tb_C As String = "Client"
    Dim tb_F As String
    Dim tb_B As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

            getClientDetails(value)
            getFactures(value)


        End Set
    End Property
    Public Property Table As String
        Get
            Return tb_C
        End Get
        Set(ByVal value As String)
            tb_C = value

            If value = "Client" Then
                tb_F = "Sell_Facture"
                tb_B = "Bon_Livraison"
            Else
                tb_F = "Buy_Facture"
                tb_B = "Bon_Achat"
            End If
        End Set
    End Property

    Private Sub plBodyFct_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plBodyFct.ControlAdded, plBodyFct.ControlRemoved
        If plBodyFct.Controls.Count > 3 Then
            plBodyFct.Height = plBodyFct.Controls(0).Height * plBodyFct.Controls.Count + 15
        Else
            plBodyFct.Height = 111
        End If

        Dim T As Double = 0
        Dim R As Double = 0
        Dim Avc As Double = 0
        Try
            For Each C As ListLine In plBodyFct.Controls
                T += C.Total
                R += C.remise
                Avc += C.Avance
            Next
        Catch ex As Exception

        End Try


        lbFTtc.Text = T
        lbFRs.Text = R
        lbFAvc.Text = Avc

    End Sub
    Private Sub plBodyBl_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plBodyBl.ControlAdded, plBodyBl.ControlRemoved
        If plBodyBl.Controls.Count > 3 Then
            plBodyBl.Height = plBodyBl.Controls(0).Height * plBodyBl.Controls.Count + 15
        Else
            plBodyBl.Height = 111
        End If

        Dim T As Double = 0
        Dim R As Double = 0
        Dim Avc As Double = 0
        Try
            For Each C As ListLine In plBodyBl.Controls
                T += C.Total
                R += C.remise
                Avc += C.Avance
            Next
        Catch ex As Exception

        End Try

        lbBTtc.Text = T
        lbBRs.Text = R
        lbBAvc.Text = Avc
    End Sub

    Private Sub getClientDetails(ByVal value As Integer)

        Dim cl As New Client(value, tb_C)

        lbRef.Text = "[" & cl.ref & "]"
        lbName.Text = cl.name
        Dim str As String = cl.adresse
        str &= vbNewLine & cl.ville
        str &= vbNewLine & "ICE :" & cl.ICE

        lbInfo.Text = str

        str = ""
        str = "Tél :" & cl.tel
        str &= vbNewLine & "Gsm :" & cl.gsm
        str &= vbNewLine & "Email :" & cl.email
        str &= vbNewLine & cl.info

        lbinfo2.text = str

        If cl.remise > 0 Then
            plRemise.Visible = CBool(cl.remise)
            txtRemise.text = cl.remise & " %"
        End If
    End Sub
    Private Sub getFactures(ByVal clid As Integer)
        Try
            Dim params As New Dictionary(Of String, Object)
            plBodyBl.Controls.Clear()
            plBodyFct.Controls.Clear()


            Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add("cid", clid)
                params.Add("isPayed", False)
                Dim dtF = c.SelectDataTable(tb_F, {"*"}, params)

                params.Clear()
                params.Add("cid = ", clid)
                params.Add("isPayed =", False)
                params.Add("isAdmin <>", "Facturé")
                Dim dt = c.SelectDataTableSymbols(tb_F, {"*"}, params)


                Dim t As Double = 0
                If dtF.Rows.Count > 0 Then
                    For i As Integer = 0 To dtF.Rows.Count - 1
                        Dim a As New ListLine
                        a.Id = dtF.Rows(i).Item(0)
                        a.Libele = StrValue(dtF, "name", i)
                        a.Total = DblValue(dtF, "total", i)
                        a.Avance = DblValue(dtF, "avance", i)
                        a.remise = DblValue(dtF, "remise", i)

                        t += a.Total - a.Avance


                        a.Index = i
                        a.Dock = DockStyle.Top
                        a.BringToFront()

                        AddHandler a.EditSelectedFacture, AddressOf Edit_SelectedFacture
                        AddHandler a.GetFactureInfos, AddressOf Get_FactureInfos
                        plBodyFct.Controls.Add(a)
                    Next
                End If
                lbFctIm.Text = dtF.Rows.Count
                lbFRest.Text = t


                t = 0
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim a As New ListLine
                        a.Id = dt.Rows(i).Item(0)
                        a.Libele = StrValue(dt, "name", i)
                        a.Total = DblValue(dt, "total", i)
                        a.Avance = DblValue(dt, "avance", i)
                        a.remise = DblValue(dt, "remise", i)

                        t += a.Total - a.Avance

                        a.Index = i
                        a.Dock = DockStyle.Top
                        a.BringToFront()

                        AddHandler a.EditSelectedFacture, AddressOf Edit_SelectedFacture
                        AddHandler a.GetFactureInfos, AddressOf Get_FactureInfos
                        plBodyFct.Controls.Add(a)
                    Next

                    lbBlImp.Text = dtF.Rows.Count
                    lbBlRest.Text = t
                End If

            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Edit_SelectedFacture(ByVal p1 As Integer)

    End Sub

    Private Sub Get_FactureInfos(ByVal p1 As Integer)

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click, Label12.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class