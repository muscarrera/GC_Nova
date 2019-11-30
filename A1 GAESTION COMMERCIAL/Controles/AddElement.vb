Public Class AddElement

    Event AddNewKeyVal(ByVal k As String, ByVal v As Double)
    Event Clear()

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
                txtN.BorderColor = Color.White
                txtQ.BorderColor = Color.White
                txtN.txtReadOnly = True
                txtQ.txtReadOnly = True
            Else
                Me.BackColor = Color.DimGray
                txtN.BorderColor = Color.Black
                txtQ.BorderColor = Color.Black
                txtN.txtReadOnly = False
                txtQ.txtReadOnly = False
            End If
        End Set
    End Property


    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        If Key <> "" And Value > 0 Then
            RaiseEvent AddNewKeyVal(Key, Value)
        End If
    End Sub

    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        txtN.text = ""
        txtQ.text = ""
        RaiseEvent Clear()
    End Sub
End Class
