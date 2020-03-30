Public Class ChooseClient

    Public cid As Integer = 0
    Public clientName As String
    Public clientadresse As String = " "
    Public tp As String = 30
    Public num As String = 0
    Public isSell As Boolean
    Public isEditing As Boolean
    Public isBlocked As Boolean = False
    Public editMode As Boolean
    Public id As Integer

    Private dt As DataTable
    Private IND As Integer
    Friend tb_C As String

    Private Sub ChooseClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        searchForClient()
    End Sub
    Public Sub searchForClient()
        Using c As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
         
            Fpl.Controls.Clear()

            Dim params As New Dictionary(Of String, Object)

            If IsNumeric(txtSearch.Text) Then
                params.Add("Clid like ", "%" & txtSearch.Text & "%")
                dt = c.SelectDataTableSymbols(tb_C, {"*"}, params)
            Else
                params.Add("name like ", "%" & txtSearch.Text & "%")
                dt = c.SelectDataTableSymbols(tb_C, {"*"}, params)
            End If

            IND = 0

            If dt.Rows.Count > 0 Then
                FillBloc(0)
            End If
        End Using
    End Sub
    Public Sub FillBloc(ByVal startIndex As Integer)
        If startIndex >= dt.Rows.Count Then Exit Sub

        Fpl.Controls.Clear()

        If dt.Rows.Count > 0 Then
            Dim endIndex As Integer = startIndex + 23
            Dim i As Integer

            For i = startIndex To dt.Rows.Count - 1
                Dim sid As Integer = CInt(dt.Rows(i).Item(0))
                Dim nm As String = dt.Rows(i).Item("name")
                Dim adr As String = dt.Rows(i).Item("adresse")
                Dim tp As String = 0
                tp = dt.Rows(i).Item("Clid")
                Dim isB As Boolean = False
                If Form1.useAccessClient Then isB = BoolValue(dt, "isBlocked", i)
                Dim tel As String = dt.Rows(i).Item("ice")
                Dim Cl As New ClientBloc(sid, nm, adr, tel, tp, Form1.admin, isB)
                AddHandler Cl.IsActivated, AddressOf IsActivated
                AddHandler Cl.IsDisActivated, AddressOf IsdisActivated
                'AddHandler Cl.IsChoosen, AddressOf Button1_Click
                Fpl.Controls.Add(Cl)
                If i = endIndex Then
                    Exit For
                End If
            Next
            IND = i
        End If
    End Sub
    Public Sub IsActivated(ByRef sender As Object, ByVal e As System.EventArgs)

        For Each t As ClientBloc In Fpl.Controls
            t.isActive = False
        Next

        Dim cl As ClientBloc = sender
        cid = cl.Clid
        clientName = cl.clientName
        lbRef.Text = clientName
        isBlocked = cl.isBlocked

        cl.isActive = True

    End Sub
    Public Sub IsdisActivated(ByVal Arid As Integer)
        cid = 0
        clientName = ""
        clientadresse = ""
        tp = 0
        isBlocked = False
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub txtSearch_TxtChanged() Handles txtSearch.TxtChanged
        searchForClient()
    End Sub
End Class