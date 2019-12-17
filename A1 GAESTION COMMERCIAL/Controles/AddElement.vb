Public Class AddElement

    Event AddNewKeyVal(ByVal k As String, ByVal v As Double)
    Event Clear(ByVal addElement As AddElement)

    Public id As Integer = 0

    Public Property Key As String
        Get
            Return txtN.text
        End Get
        Set(ByVal value As String)
            txtN.text = value

        End Set
    End Property
    Public Property ref As String
        Get
            Return txtRef.text
        End Get
        Set(ByVal value As String)
            txtRef.text = value
        End Set
    End Property
    Public Property price As Double
        Get
            If txtP.text = "" Then Return 0
            Return CDbl(txtP.text)
        End Get
        Set(ByVal value As Double)
            txtP.text = String.Format("{0:n}", value)
            txttotal.text = String.Format("{0:n}", value * qte)
        End Set
    End Property
    Public Property qte As Double
        Get
            If txtQ.text = "" Then Return 0
            Return CDbl(txtQ.text)
        End Get
        Set(ByVal value As Double)
            txtQ.text = value
            txttotal.text = String.Format("{0:n}", value * price)
        End Set
    End Property
    Public Property EditMode As Boolean
        Get
            Return Me.BackColor = Color.White
        End Get
        Set(ByVal value As Boolean)
            If value Then
                Me.BackColor = Color.White
                Me.BackgroundImage = Nothing
                txtN.BorderColor = Color.White
                txtP.BorderColor = Color.White
                txtN.txtReadOnly = True
                txtP.txtReadOnly = True
                btAdd.Visible = False
            Else
                txtN.BorderColor = Color.Black
                txtP.BorderColor = Color.Black
                txtN.txtReadOnly = False
                txtP.txtReadOnly = False
                btAdd.Visible = True
            End If
        End Set
    End Property
    Public Property HasDate As Boolean
        Get
            Return plDate.Visible
        End Get
        Set(ByVal value As Boolean)
            plDate.Visible = value
            plRef.Visible = value
        End Set
    End Property
    Public Property DateElemenet As Date
        Get
            Return CDate(txtDate.text)
        End Get
        Set(ByVal value As Date)
            txtDate.text = value.ToString("dd/MM/yyyy")
        End Set
    End Property
    Public ReadOnly Property Total As Double
        Get
            Return CDbl(txttotal.text)
        End Get
    End Property

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If Key <> "" And price > 0 Then
            RaiseEvent AddNewKeyVal(Key, price)
            txtN.text = ""
            txtP.text = ""
            txtQ.text = ""
            txttotal.text = ""
        End If
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        If EditMode = False Then
            txtN.text = ""
            txtP.text = ""
        Else
            RaiseEvent Clear(Me)
        End If


    End Sub
End Class
