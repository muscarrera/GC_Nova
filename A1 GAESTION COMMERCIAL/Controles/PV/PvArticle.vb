Public Class PvArticle

    Public Event Choosed(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        lb.Font = New Font(Form1.fontName_PV, Form1.fontSize_PV, FontStyle.Bold)


    End Sub
    Private _data As DataRow
    Public Property DataSource() As DataRow
        Get
            Return _data
        End Get
        Set(ByVal value As DataRow)
            _data = value

            lb.Text = value.Item("name").ToString.ToLower

            'Try
            '    Dim arrImage() As Byte
            '    arrImage = value.Item("img")
            '    Dim mstream As New System.IO.MemoryStream(arrImage)
            '    Me.BackgroundImage = Image.FromStream(mstream)
            'Catch ex As Exception
            '    Me.BackgroundImage = My.Resources.BGpRD
            'End Try


            'Try
            '    If value.Item("img").ToString = "No Image" Or value.Item("img").ToString = "" Then

            '    Else
            '        Dim str As String = Form1.ImgPah & "\art" & value.Item("img").ToString

            '        Me.BackgroundImage = Image.FromFile(str)
            '    End If
            '    Me.BackgroundImageLayout = ImageLayout.Stretch
            'Catch ex As Exception
            '    Me.BackgroundImage = My.Resources.BGpRD
            'End Try




            'plB.Height = lb.PreferredHeight

        End Set
    End Property

    Private Sub lb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click, lb.Click
        RaiseEvent Choosed(Me, e)
    End Sub




End Class
