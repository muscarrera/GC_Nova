Public Class ListLine

    Private _id As Integer = 0
    Private _cid As Integer
    Private _Total As Double
    Private _avc As Double
    Private _Remise As Double
    Private _isSelected As Boolean
    Private myColor As Color = Color.Transparent
    Dim _index As Integer
    Dim _date As Date

     Public isStocked As Boolean = True

    Public Event selected()
    Public sizeAuto As Boolean = False

    Public Event EditSelectedItem(ByVal ls As ListLine)
    Public Event EditSelectedFacture(ByVal p1 As Integer)
    Public Event DeleteItem(ByVal ls As ListLine)
    Public Event GetFactureInfos(ByVal p1 As Integer)

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            lbref.Text = value
        End Set
    End Property
    Public Property Libele As String
        Get
            Return lbName.Text
        End Get
        Set(ByVal value As String)
            lbName.Text = value
        End Set
    End Property
    Public Property Total As Double
        Get
            Return _Total
        End Get
        Set(ByVal value As Double)
            _Total = value
            lbTotal.Text = String.Format("{0:n}", CDec(value))
        End Set
    End Property
    Public Property Avance As Double
        Get
            Return _avc
        End Get
        Set(ByVal value As Double)
            _avc = value
            lbAvc.Text = String.Format("{0:n}", CDec(value))
        End Set
    End Property
    Public Property remise As Double
        Get
            Return _Remise
        End Get
        Set(ByVal value As Double)
            _Remise = value
            lbRemise.Text = String.Format("{0:n}", CDec(value))
            If value = 0 Then
                lbRemise.Visible = False
            Else
                lbRemise.Visible = True
            End If
        End Set
    End Property
    Public Property Dte As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
            lbDate.Text = value.ToString("dd MMM yyyy")
        End Set
    End Property
    Public Property isSelected() As Boolean
        Get
            Return _isSelected
        End Get
        Set(ByVal value As Boolean)
            _isSelected = value
            plSet.Visible = value

            If value Then
                Me.BackColor = Color.AntiqueWhite
            Else
                Me.BackColor = myColor
            End If
        End Set
    End Property
    Public Property isEdited As Boolean
        Get
            Return Me.BackColor = Color.FromArgb(192, 255, 192)
        End Get
        Set(ByVal value As Boolean)
            Me.BackColor = Color.FromArgb(192, 255, 192)
        End Set
    End Property
    Public Property Index As Integer
        Get
            Return _index
        End Get
        Set(ByVal value As Integer)
            _index = value
            'If value Mod 2 = 0 Then
            '    myColor = Color.WhiteSmoke
            'Else
            '    myColor = Color.Transparent
            'End If
            'Me.BackColor = myColor
            Panel1.BackgroundImage = Nothing
            If (value Mod 2) = 0 Then Panel1.BackgroundImage = My.Resources.gui_13
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        
        ResizePanels()


    End Sub
    Private Sub PlLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlLeft.Click, lbTotal.Click, lbRemise.Click, lbref.Click, lbName.Click, lbAvc.Click, plT.Click, plSet.Click, plRef.Click, plR.Click, plQ.Click, plP.Click, plNm.Click, Panel1.Click, lbDate.Click
        isSelected = Not isSelected
        RaiseEvent selected()
    End Sub

    Private Sub btAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btAdd.Click
        RaiseEvent EditSelectedFacture(Id)
        RaiseEvent EditSelectedItem(Me)
    End Sub
    Private Sub btClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClear.Click
        If MsgBox(MsgDelete & vbNewLine & lbName.Text & " : " & Id, MsgBoxStyle.YesNo, "Suppression") = MsgBoxResult.Yes Then
            RaiseEvent DeleteItem(Me)
        End If

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RaiseEvent GetFactureInfos(Id)
    End Sub

    Private Sub ListLine_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ResizePanels()
    End Sub
    Private Sub ResizePanels()


        If sizeAuto = False Then
            Dim w As Integer = Me.Width
            w -= plSet.Width
            w = w / 7

            If w > Form1.cellWidth Then w = Form1.cellWidth

            plP.Width = w
            plQ.Width = w
            plR.Width = w
            plT.Width = w
            plRef.Width = w


            'plP.Width = Form1.cellWidth
            'plQ.Width = Form1.cellWidth
            'plR.Width = Form1.cellWidth
            'plT.Width = Form1.cellWidth
            'plRef.Width = Form1.cellWidth / 2
        Else
            Dim w As Integer = Me.Width
            w -= plSet.Width

            Dim a As Integer = CInt((w - 22) / 8)

            plP.Width = a
            plQ.Width = a
            plR.Width = a
            plT.Width = a
            plRef.Width = a / 2
        End If



    End Sub
End Class
