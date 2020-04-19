Public Class gColumn

    Event ClearCol(ByVal gColumn As gColumn)


    Private _isSelected As Boolean = False
    Dim _prop As New gColClass

    Event ColWidthChanged(ByVal gColumn As gColumn)
  
    Public Property Prop As gColClass
        Get
            Return _prop
        End Get
        Set(ByVal value As gColClass)
            _prop = value

            If Not IsNothing(value) Then
                txtT.Text = value.HeaderName
                txtW.text = value.ColWidth
                lbHeader.Text = value.HeaderName
            End If
        End Set
    End Property

    Public Property isSelected() As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            _isSelected = value
            If value = True Then
                Panel1.BackColor = Color.Beige
            Else
                Panel1.BackColor = Color.WhiteSmoke
            End If
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        RaiseEvent ClearCol(Me)
    End Sub
    

    Private Sub txtW_TxtChanged() Handles txtW.TxtChanged
        If IsNumeric(txtW.text) Then
            Prop.ColWidth = CInt(txtW.text)
        Else
            Prop.ColWidth = 40
        End If
    End Sub
    Private Sub txttTxtChanged() Handles txtT.TxtChanged
        Prop.HeaderName = txtT.text
    End Sub

    Private Sub Panel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel1.Click
        isSelected = Not isSelected
    End Sub

    Private Sub txtW_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtW.Leave
        RaiseEvent ColWidthChanged(Me)
    End Sub
End Class
