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
    Public Property Value As Double
        Get
            If txtQ.text = "" Then Return 0
            Return CDbl(txtQ.text)
        End Get
        Set(ByVal value As Double)
            txtQ.text = value
           
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
                txtQ.BorderColor = Color.White
                txtN.txtReadOnly = True
                txtQ.txtReadOnly = True
                btAdd.Visible = False
            Else
                txtN.BorderColor = Color.Black
                txtQ.BorderColor = Color.Black
                txtN.txtReadOnly = False
                txtQ.txtReadOnly = False
                btAdd.Visible = True
            End If
        End Set
    End Property


    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If Key <> "" And Value > 0 Then
            RaiseEvent AddNewKeyVal(Key, Value)
            txtN.text = ""
            txtQ.text = ""
        End If
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        If EditMode = False Then
            txtN.text = ""
            txtQ.text = ""
        Else
            RaiseEvent Clear(Me)
        End If


    End Sub
End Class
