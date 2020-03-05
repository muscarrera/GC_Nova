Imports System.IO

Public Class AddEditClient

    'Image
    Private _imgPrd As Image
    Private _id As Integer = 0

    Public EditMode As Boolean = False
    Public tb_C As String = "Client"

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value

            If value = 0 Then Exit Property

            btRemise.Visible = True
            FillForm(value, tb_C)
        End Set
    End Property

    Public Property ImgPrd As Image
        Get
            Return _imgPrd
        End Get
        Set(ByVal value As Image)
            Dim rnd As New Random
            If IsNothing(value) Then
                Dim BMG As New Bitmap(Form1.imgLonger, Form1.imgLarge, Imaging.PixelFormat.Format24bppRgb)

                Dim GR As Graphics = Graphics.FromImage(BMG)
                GR.Clear(Color.White)
                GR.Clear(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)))
                _imgPrd = BMG
            Else
                _imgPrd = value
            End If

        End Set
    End Property
    Public Function Drawimg() As Bitmap
        Dim fntSmall As New Font("Arial", 7)
        Dim fnt As New Font("Arial", 11, FontStyle.Bold)
        Dim ht As Integer = CInt(Form1.imgLarge)
        Dim wd As Integer = CInt(Form1.imgLonger)
        'create the bitmap
        Dim BMG As New Bitmap(wd, ht, Imaging.PixelFormat.Format24bppRgb)
        'ceate the graphic
        Dim GR As Graphics = Graphics.FromImage(BMG)


        GR.Clear(Color.White)

        'draw the lines
        Try

            If IsNothing(ImgPrd) Then ImgPrd = Nothing

            GR.DrawImage(ImgPrd, 0, 0, wd, ht)
        Catch ex As Exception

        End Try
        Return BMG
    End Function
    Private Sub saveImage()
        Dim dir1 As New DirectoryInfo(Form1.ImgPah)
        If dir1.Exists = False Then dir1.Create()

        Try
            Dim str As String = lbImage.Text
            str = str.Replace("/", "-")
            str = str.Replace("*", "-")

            Using img As Image = ImgPrd
                Try
                    img.Save(Form1.ImgPah & "\CLT" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                Catch ex As Exception
                    Dim ff As New FileInfo(Form1.ImgPah & "\CLT" & str & ".jpg")
                    ff.Delete()
                    img.Save(Form1.ImgPah & "\CLT" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                End Try

            End Using
            lbImage.Text = str & ".jpg"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim savepic As New OpenFileDialog
        savepic.Filter = "*.jpg|*.jpg"
        If savepic.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim pmg2 As New Bitmap(savepic.FileName)
            lbImage.Text = savepic.SafeFileName
            ImgPrd = pmg2
            PBImage.BackgroundImage = Drawimg()

        End If
    End Sub
    'ref
    Private Sub txtRef_TxtChanged() Handles txtRef.TxtChanged
        lbRef.Text = "[" & txtRef.text & "]"
    End Sub

    Private Sub Validation()
        If txtName.text.Trim = "" Then
            Dim str As String = "Nom de produit est Obligatoire"
            str &= vbNewLine
            str &= "Veuillez remplir tous les champs obligatoires"
            MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtName.Focus()
            Exit Sub
        End If
        If txtICE.text.Trim = "" Then txtICE.text = "-"
        If txtAdresse.text.Trim = "" Then txtAdresse.text = "-"

        If txtCp.text.Trim = "" Then txtCp.text = "-"
        If txtVille.text.Trim = "" Then txtVille.text = "-"
        If txtTel.text.Trim = "" Then txtTel.text = "-"
        If txtGsm.text.Trim = "" Then txtGsm.text = "-"
        If txtEmail.text.Trim = "" Then txtEmail.text = "-"
        If txtInfo.text.Trim = "" Then txtInfo.text = "-"
        If cbctg.SelectedText = "" Then cbctg.SelectedText = " "
    End Sub
    Private Sub FillForm(ByVal _Pid As Integer, ByVal tb_C As String)

        Dim cid = 0
        Dim params As New Dictionary(Of String, Object)
        params.Add("Clid", _Pid)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable(tb_C, {"*"}, params)
            If dt.Rows.Count > 0 Then

                txtRef.text = StrValue(dt, "ref", 0)
                txtName.text = StrValue(dt, "name", 0)
                rbSte.Checked = BoolValue(dt, "isCompany", 0)
                cbctg.SelectedText = StrValue(dt, "groupe", 0)

                txtAdresse.text = StrValue(dt, "adresse", 0)
                txtCp.text = StrValue(dt, "cp", 0)
                txtVille.text = StrValue(dt, "ville", 0)
                txtICE.text = StrValue(dt, "ice", 0)

                txtTel.text = StrValue(dt, "tel", 0)
                txtGsm.text = StrValue(dt, "gsm", 0)
                txtEmail.text = StrValue(dt, "email", 0)
                txtInfo.text = StrValue(dt, "info", 0)

                lbImage.Text = StrValue(dt, "img", 0)
                PBImage.BackgroundImage = Drawimg()
            End If
        End Using
    End Sub

    Private Sub AddEditElement()
        Validation()

        Dim params As New Dictionary(Of String, Object)
        params.Add("ref", txtRef.text)
        params.Add("name", txtName.text)
        params.Add("isCompany", rbSte.Checked)
        params.Add("groupe", cbctg.SelectedText)

        params.Add("adresse", txtAdresse.text)
        params.Add("cp", txtCp.text)
        params.Add("ville", txtVille.text)
        params.Add("ice", txtICE.text)

        params.Add("tel", txtTel.text)
        params.Add("gsm", txtGsm.text)
        params.Add("email", txtEmail.text)
        params.Add("info", txtInfo.text)
         
        params.Add("img", lbImage.Text)

        Dim x As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            If EditMode Then
                Dim where As New Dictionary(Of String, Object)
                where.Add("Clid", Id)
                x = a.UpdateRecord(tb_C, params, where)

            Else
                x = a.InsertRecord(tb_C, params)
            End If
        End Using


        If x > 0 Then
            DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        AddEditElement()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btRemise_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRemise.Click
        Dim rm As New Client_Remise
        rm.client_Id = Id
        rm.lbClient.Text = txtName.text

        If rm.ShowDialog = Windows.Forms.DialogResult.OK Then

        End If
    End Sub
End Class