Public Class pvPaiement_Form

    Public ReadOnly Property Value As Double
        Get
            Dim v As Double = 0
            If IsNumeric(txt.text) Then
                v = CDbl(txt.text)
            End If
            Return v
        End Get
    End Property
    Public ReadOnly Property Mode As String
        Get
            Dim v As String = "Cache"
            If cbWay.Text <> "" Then
                v = cbWay.Text
            End If
            Return v
        End Get
    End Property


    Private _total As Double
    Public Property total() As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = value
            bt.Text = "Montant " & value & " Dhs (Cache)"
        End Set
    End Property


    Private Sub pvPaiement_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()
        txt.Focus()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button4.Click, Button3.Click, Button2.Click, Button16.Click, Button13.Click, Button12.Click, Button11.Click, Button17.Click
        Dim bt As Button = sender
        Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator
        If bt.Text = Button17.Text Then
            If Not txt.text.Contains(decimalSeparator) Then txt.text = txt.text + decimalSeparator
            Exit Sub
        End If
        txt.text = txt.text + bt.Text
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel8.Click, Label1.Click, Label2.Click
        txt.Focus()

    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        txt.text = ""
        txt.Focus()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub bt_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles bt.LinkClicked
        txt.text = total
        cbWay.Text = "Cache"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class