Public Class AddEditTopField

    Dim _tabProp As gTopField

    Public Property Prop As gTopField
        Get

            _tabProp.designation = txt.text
            _tabProp.field = CB.Text
            _tabProp.width = W.text
            _tabProp.height = H.text
            _tabProp.x = X.text
            _tabProp.y = Y.text
            _tabProp.fSize = T.text
            _tabProp.isBold = CheckBox1.Checked

            _tabProp.backColor = btColor.BackColor
            _tabProp.hasBloc = cbBloc.Checked

            Return _tabProp
        End Get
        Set(ByVal value As gTopField)
            _tabProp = value
            If IsNothing(value) Then Exit Property

            txt.text = value.designation
            CB.Text = value.field

            W.text = value.width
            H.text = value.height
            X.text = value.x
            Y.text = value.y
            T.text = value.fSize
            CheckBox1.Checked = value.isBold
            btColor.BackColor = value.backColor
            cbBloc.Checked = value.hasBloc
        End Set
    End Property

    Private _editMode As Boolean = False
    Public Property EditMode() As Boolean
        Get
            Return _editMode
        End Get
        Set(ByVal value As Boolean)
            _editMode = value
            Button2.Visible = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Prop = New gTopField
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If CB.Text.StartsWith("//") Then
            If txt.text <> "total_ht" And txt.text <> "total_ttc" And txt.text <> "Avance" Then
                txt.ForeColor = Color.Red
                txt.Focus()
                Exit Sub
            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Prop.isDeleted = True
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btColor.Click
        Dim cr As New ColorDialog
        If cr.ShowDialog = DialogResult.OK Then
            btColor.BackColor = cr.Color
            _tabProp.backColor = cr.Color
        End If
    End Sub
End Class