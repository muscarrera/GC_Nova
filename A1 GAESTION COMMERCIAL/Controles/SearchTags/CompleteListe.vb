Public Class CompleteListe

    Public ListeOfString As New Dictionary(Of String, String)
    Public ListeOfNumber As New Dictionary(Of String, String)
    Public ListeOfBoolean As New Dictionary(Of String, String)
    Public ListeOfDates As New Dictionary(Of String, String)

    Private Listes As Dictionary(Of String, String)

    Dim G1 As Color = Color.FromArgb(255, 238, 238, 238)
    Dim G2 As Color = Color.FromArgb(255, 248, 248, 248)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ListeOfString.Add("Client", "CL")
        'ListeOfString.Add("Chauffeur", "CH")
        'ListeOfString.Add("Vehicule", "VH")
        'ListeOfString.Add("Depart", "DP")
        'ListeOfString.Add("Destination", "DS")
        'ListeOfString.Add("Domaine", "DN")
        'ListeOfString.Add("Editeur", "ED")

        ' '''''/// numbers
        'ListeOfNumber.Add("N°", "ID")
        'ListeOfNumber.Add("Total Min", "TM")
        'ListeOfNumber.Add("Total Max", "TX")
        'ListeOfNumber.Add("Avance Min", "AM")
        'ListeOfNumber.Add("Avance Max", "AX")

        ' '''''/// Booleans
        'ListeOfBoolean.Add("Reglé", "RG")
        'ListeOfBoolean.Add("Facturé", "FT")

        ' '''''/// Date
        'ListeOfDates.Add("Date", "DT")
        'ListeOfDates.Add("Date Min", "DM")
        'ListeOfDates.Add("Date Max", "DX")

        Panel1.Controls.Clear()

    End Sub

    Event LabelClicked(ByVal key As String, ByVal val As String)

    Event Clear()

    Public Property Mode As Integer
        Get
            Return 0
        End Get
        Set(ByVal value As Integer)
            If value = 1 Then
                Listes = ListeOfString
            ElseIf value = 2 Then
                Listes = ListeOfNumber
            ElseIf value = 3 Then
                Listes = ListeOfBoolean
            ElseIf value = 4 Then
                Listes = ListeOfDates
            ElseIf value = 5 Then

            Else


            End If

            FillPanel()
            If value = 0 Then Panel1.Controls.Clear()
        End Set
    End Property



    Private Sub FillPanel()
        Panel1.Controls.Clear()
        Try

       
        If Listes.Count = 0 Then Exit Sub
        Dim N As Integer = 1

        For Each kvp As KeyValuePair(Of String, String) In Listes
            Dim lb As New Label
            lb.AutoSize = False
            lb.Padding = New Padding(10)
            lb.Height = 33

            lb.Text = kvp.Key & " ..."
            lb.Tag = kvp.Value

            lb.BackColor = G1
            If N Mod 2 = 0 Then lb.BackColor = G2
            N += 1

            lb.Dock = DockStyle.Top
            lb.SendToBack()

            AddHandler lb.Click, AddressOf label_Clicked
            Panel1.Controls.Add(lb)
        Next
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Panel1_ControlAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Panel1.ControlAdded
        'Dim W As Integer = CInt(Panel1.Controls.Count * 33)
        'W += 20
        'Me.Height = W
    End Sub

    Private Sub label_Clicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim lb As Label = sender
        Dim str As String = lb.Tag
        Dim val As String = ""

        RaiseEvent LabelClicked(lb.Text, str)
        RaiseEvent Clear()
    End Sub

End Class
