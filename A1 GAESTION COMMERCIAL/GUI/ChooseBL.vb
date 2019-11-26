Public Class ChooseBL

    Public cid As Object
    Public tb_F As String
    Public tb_D As String
    Public tb_D_D As String
    Dim _id As Integer
    Dim ls As String

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            'get list of bls
        End Set
    End Property
    Public Property table As String
        Get
            Return tb_F
        End Get
        Set(ByVal value As String)
            tb_F = value
            'get list of bls
            If value = "Sell_Facture" Then
                tb_D = "Bon_Livraison"
                tb_D_D = "Details_Bon_Livraison"
            Else
                tb_D = "Bon_Achat"
                tb_D_D = "Details_Bon_Achat"
            End If
        End Set
    End Property
    Public Property List As String
        Get
            Return ls
        End Get
        Set(ByVal value As String)
            ls = value
        End Set
    End Property

    Private Sub ChooseBL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SearchForBlList()
    End Sub
    Public Sub SearchForBlList()
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim _dtList As DataTable = Nothing

            plBody.Controls.Clear()

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                params.Add(tb_F, id)
                _dtList = a.SelectDataTable(tb_D, {"*"}, params)
            End Using

            If _dtList.Rows.Count > 0 Then
                Dim arr(_dtList.Rows.Count - 1) As ListLine
                Dim i As Integer = 0
                For i = 0 To _dtList.Rows.Count - 1
                    Dim b As New ListLine
                    Dim s As Boolean = False
                    For Each b In plBody.Controls
                        If b.Id = _dtList.Rows(i).Item(0) Then
                            s = True
                            Exit For
                        End If
                    Next
                    If s Then Continue For

                    Dim a As New ListLine
                    a.Id = _dtList.Rows(i).Item(0)
                    a.Libele = StrValue(_dtList, "name", i)
                    a.Total = DblValue(_dtList, "total", i)
                    a.Avance = DblValue(_dtList, "avance", i)
                    a.remise = DblValue(_dtList, "remise", i)
                    a.Dte = DteValue(_dtList, "date", i)
                    a.Index = i
                    a.Dock = DockStyle.Top
                    a.BringToFront()

                    arr(i) = a

                    a.plR.Width = 1
                    a.plSet.Width = 1
                    a.PlLeft.Width = 5
                    a.plNm.Visible = 0

                    a.lbref.Font = a.lbName.Font
                    a.lbref.ForeColor = Color.Blue
                Next
                plBody.Controls.AddRange(arr)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchByDate()
        Try

            Dim dt1 As Date = Date.Parse(dte2.Value).AddDays(1)
            Dim dt2 As Date = Date.Parse(dte2.Value).AddDays(-1)

            Dim params As New Dictionary(Of String, Object)
            Dim _dtList As DataTable = Nothing

            pl1.Controls.Clear()

            If txtSearch.text <> "" And IsNumeric(txtSearch.text) Then

                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("fctid Like ", "%" & txtSearch.text & "%")
                    params.Add("isAdmin <> ", "Facturé")
                    params.Add("cid = ", cid)
                    _dtList = a.SelectDataTableSymbols(tb_D, {"*"}, params)
                End Using
            Else
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
                    params.Add("[date] < ", dt1)
                    params.Add("[date] > ", dt2)
                    params.Add("isAdmin <> ", "Facturé")
                    params.Add("cid = ", cid)

                    _dtList = a.SelectDataTableSymbols(tb_D, {"*"}, params)
                End Using
            End If

            If _dtList.Rows.Count > 0 Then
                Dim arr(_dtList.Rows.Count - 1) As ListLine
                Dim i As Integer = 0
                For i = 0 To _dtList.Rows.Count - 1
                    Dim b As New ListLine
                    Dim s As Boolean = False
                    For Each b In plBody.Controls
                        If b.Id = _dtList.Rows(i).Item(0) Then
                            s = True
                            Exit For
                        End If
                    Next
                    If s Then Continue For

                    Dim a As New ListLine
                    a.Id = _dtList.Rows(i).Item(0)
                    a.Libele = StrValue(_dtList, "name", i)
                    a.Total = DblValue(_dtList, "total", i)
                    a.Avance = DblValue(_dtList, "avance", i)
                    a.remise = DblValue(_dtList, "remise", i)
                    a.Dte = DteValue(_dtList, "date", i)
                    a.Id = _dtList.Rows(i).Item(0)
                    a.Index = i
                    a.Dock = DockStyle.Top
                    a.BringToFront()

                    arr(i) = a

                    a.plR.Width = 1
                    a.plSet.Width = 1
                    a.PlLeft.Width = 5
                    a.plNm.Visible = 0

                    a.lbref.Font = a.lbName.Font
                    a.lbref.ForeColor = Color.Blue
                Next
                pl1.Controls.AddRange(arr)
               
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SearchByDate()
    End Sub
    'Add
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As ListLine
        For Each a In pl1.Controls
            If a.isSelected Then
                pl1.Controls.Remove(a)
                plBody.Controls.Add(a)
            End If
        Next
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        Dim a As ListLine
        For Each a In pl1.Controls
            pl1.Controls.Remove(a)
            plBody.Controls.Add(a)

        Next
    End Sub
    'Delete
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim b As ListLine
        For Each b In plBody.Controls
            If b.isSelected Then
                plBody.Controls.Remove(b)
                pl1.Controls.Add(b)
            End If
        Next
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim a As ListLine
        For Each a In plBody.Controls
            plBody.Controls.Remove(a)
            pl1.Controls.Add(a)
        Next
    End Sub

    Private Sub plBody_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles plBody.ControlAdded, plBody.ControlRemoved
        Dim T As Double = 0
        Dim R As Double = 0
        Dim av As Double = 0
        ls = ""
        For Each C As ListLine In plBody.Controls
            T += C.Total
            R += C.remise
            av += C.Avance
            If ls.Length > 0 Then ls &= "|"
            ls &= C.Id
        Next

        LbSum.Text = String.Format("{0:n}", T)
        lbHT.Text = String.Format("{0:n}", T - 20%)
        lbremise.Text = String.Format("Remise : {0:n}", R)
        Lbavc.Text = String.Format("{0:n}", av)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class