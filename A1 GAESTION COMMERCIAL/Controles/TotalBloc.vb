Public Class TotalBloc

    Dim _pj As Integer
    Dim _isDisibleEditing As Boolean

    Public Event EditModePayement()
    Public Event ValueChanged()
    Public Event AddEditPayement()
    Public Event AddFiles()

    Private _ModePayement As String
    Private _avc As Double = 0
    Private _dt As Double = 0
    Private _tva As Double = 0
    Private _rs As Double = 0
    Private _ht As Double = 0


    Public TotalTTC_base As Double = 0

    Public Property TotalHt As Double
        Get
            Return _ht
        End Get
        Set(ByVal value As Double)
            _ht = value
            lbHt.Text = String.Format("{0:n}", CDec(value))
            lbTTc.Text = String.Format("{0:n}", CDec(TotalTTC))
            RaiseEvent ValueChanged()
        End Set
    End Property
    Public Property Remise As Double
        Get
            Return _rs
        End Get
        Set(ByVal value As Double)
            _rs = value
            lbRs.Text = String.Format("{0:n}", CDec(value))
            If value = 0 Then
                plRs.Visible = False
            Else
                plRs.Visible = True
            End If
            lbTTc.Text = String.Format("{0:n}", CDec(TotalTTC))
            RaiseEvent ValueChanged()
        End Set
    End Property
    Public Property TVA As Double
        Get
            Return _tva
        End Get
        Set(ByVal value As Double)
            _tva = value
            lbTva.Text = String.Format("{0:n}", CDec(value))
            lbTTc.Text = String.Format("{0:n}", CDec(TotalTTC))
            RaiseEvent ValueChanged()
        End Set
    End Property
    Public Property pj As Integer
        Get
            Return _pj
        End Get
        Set(ByVal value As Integer)
            _pj = value

            If value = 0 Then
                lbpj.Text = "Joindre des fichiers"
            Else
                lbpj.Text = "* " & value & " Fichies"
            End If
        End Set
    End Property

    Public ReadOnly Property DroitTimbre As Double
        Get
            Dim T As Double = 0
            T = TotalHt - Remise
            T *= _dt

            lbTimbre.Text = String.Format("{0:n}", CDec(T))

            If _dt = 0 Then
                plTimbre.Visible = False
            Else
                plTimbre.Visible = True
            End If
            Return T
        End Get
    End Property
    Public ReadOnly Property TotalTTC As Double
        Get
            Dim value As Double = TotalHt + TVA + DroitTimbre - Remise

            If Form1.isBaseOnTTC Then value = TotalTTC_base + DroitTimbre

            Return value
        End Get
    End Property
    Public Property avance As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            lbAvc.Text = String.Format("{0:n}", CDec(value))
            If value = 0 Then
                plAvc.Visible = False
            Else
                plAvc.Visible = True
            End If
            RaiseEvent ValueChanged()
        End Set
    End Property
    Public Property ModePayement As String
        Get
            Return _ModePayement
        End Get
        Set(ByVal value As String)
            _ModePayement = value
            _dt = 0
            If value = "Cache" Then _dt = 25 / 10000
            lbTTc.Text = String.Format("{0:n}", CDec(TotalTTC))
            If Not IsNothing(value) Then lbModePayement.Text = value
        End Set
    End Property
    Public Property Writer As String
        Get
            Return lbwriter.Text
        End Get
        Set(ByVal value As String)
            lbwriter.Text = value
        End Set
    End Property
    Public Property isDisibleEditing As Boolean
        Get
            Return _isDisibleEditing
        End Get
        Set(ByVal value As Boolean)
            _isDisibleEditing = value
            'plAddPayement.Enabled = Not value
            plMP.Enabled = Not value
        End Set
    End Property
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        RaiseEvent EditModePayement()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent AddEditPayement()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        RaiseEvent AddFiles()
    End Sub
End Class
