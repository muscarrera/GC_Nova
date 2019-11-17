Imports System.IO

Public Class AddEditProduct

    Public EditMode As Boolean = False
    Private _id As Integer = 0

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            If value = 0 Then Exit Property

            FillForm(value)
        End Set
    End Property
    'Image
    Private _imgPrd As Image
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
                    img.Save(Form1.ImgPah & "\art" & str & ".jpg", Imaging.ImageFormat.Jpeg)
                Catch ex As Exception
                    Dim ff As New FileInfo(Form1.ImgPah & "\art" & str & ".jpg")
                    ff.Delete()
                    img.Save(Form1.ImgPah & "\art" & str & ".jpg", Imaging.ImageFormat.Jpeg)
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
            lbImage.Text = savepic.FileName
            ImgPrd = pmg2
            PBImage.BackgroundImage = Drawimg()

        End If
    End Sub
    
    'prices
    Private Sub txtPAch_TxtChanged() Handles txtPAch.TxtChanged
        Try
            If txtPAch.text = "" Then Exit Sub

            If txtHt.text <> "" Then
                txtMarge.text = String.Format("{0:n}", CDec((txtHt.text - txtPAch.text) * 100 / txtPAch.text))
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtMarge_TxtChanged() Handles txtMarge.TxtChanged
        Try
            If txtMarge.text = "" Then Exit Sub
            If txtMarge.focused = False Then Exit Sub
            If txtPAch.text <> "" Then
                txtHt.text = String.Format("{0:n}", CDec(((txtPAch.text * txtMarge.text) / 100) + txtPAch.text))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtHt_TxtChanged() Handles txtHt.TxtChanged
        If txtHt.text = "" Then Exit Sub

        Try
            If txtPAch.text <> "" And txtMarge.focused = False Then
                txtMarge.text = String.Format("{0:n}", CDec((txtHt.text - txtPAch.text) * 100 / txtPAch.text))
            End If
        Catch ex As Exception

        End Try

        Try
            If txtTva.text <> "" And txtTTC.focused = False Then
                txtTTC.text = String.Format("{0:n}", CDec(((txtHt.text * txtTva.text) / 100) + txtHt.text))
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub txtTva_TxtChanged() Handles txtTva.TxtChanged
        If txtTva.text = "" Then Exit Sub

        Try
            If txtHt.text <> "" Then
                txtTTC.text = String.Format("{0:n}", CDec(((txtHt.text * txtTva.text) / 100) + txtHt.text))
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub txtTTC_TxtChanged() Handles txtTTC.TxtChanged
        If txtTTC.text = "" Then Exit Sub
        If txtTTC.focused = False Then Exit Sub
        Try
            If txtTva.text <> "" And txtHt.focused = False Then
                txtHt.text = String.Format("{0:n}", CDec((txtHt.text * 100) / (100 + txtTva.text)))
            End If
        Catch ex As Exception

        End Try
    End Sub
    'ref
    Private Sub txtRef_TxtChanged() Handles txtRef.TxtChanged
        lbRef.Text = "[" & txtRef.text & "]"
    End Sub

    Private Sub AddEditProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ALMohassinDBDataSet.Category' table. You can move, or remove it, as needed.
        Me.CategoryTableAdapter.Fill(Me.ALMohassinDBDataSet.Category)

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
        If txtPAch.text.Trim = "" Then
            Dim str As String = "Prix d'Achat est Obligatoire"
            str &= vbNewLine
            str &= "Veuillez remplir tous les champs obligatoires"
            MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtPAch.Focus()
            Exit Sub
        End If
        If txtHt.text.Trim = "" Then
            Dim str As String = "Prix de vente est Obligatoire"
            str &= vbNewLine
            str &= "Veuillez remplir tous les champs obligatoires"
            MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtHt.Focus()
            Exit Sub
        End If

        If txtAlert.text = "" Then txtAlert.text = "0"
        If txtStockType.text = "" Then txtStockType.text = "-"
        If txtPrixPromo.Text = "" Then txtPrixPromo.Text = "0"
        If txtRmax.text = "" Then txtRmax.text = "0"
        If txtRGr.text = "" Then txtRGr.text = "0"
        If txtRRev.text = "" Then txtRRev.text = "0"
        If txtRCF.text = "" Then txtRCF.text = "0"

    End Sub
    Private Sub FillForm(ByVal _Pid As Integer)

        Dim cid = 0
        EditMode = True
        Dim params As New Dictionary(Of String, Object)
        params.Add("arid", _Pid)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
            If dt.Rows.Count > 0 Then

                txtRef.text = StrValue(dt, "ref", 0) ' dt.Rows(0).Item("ref")
                txtName.text = StrValue(dt, "name", 0) 'dt.Rows(0).Item("")
                txtDesc.text = StrValue(dt, "desc", 0) 'dt.Rows(0).Item("")
                cbctg.SelectedValue = StrValue(dt, "cid", 0) 'dt.Rows(0).Item("")

                txtPAch.text = StrValue(dt, "bprice", 0) 'dt.Rows(0).Item("")
                txtHt.text = StrValue(dt, "sprice", 0) ' dt.Rows(0).Item("")
                txtTva.text = StrValue(dt, "tva", 0) ' dt.Rows(0).Item("")
                txtPrixPromo.Text = StrValue(dt, "prixPromo", 0) ' dt.Rows(0).Item("")

                txtRmax.text = StrValue(dt, "remiseMax", 0) ' dt.Rows(0).Item("")
                txtRGr.text = StrValue(dt, "remiseGr", 0) 'dt.Rows(0).Item("")
                txtRRev.text = StrValue(dt, "remiseRev", 0) 'dt.Rows(0).Item("")
                txtRCF.text = StrValue(dt, "remiseCF", 0) 'dt.Rows(0).Item("")

                txtStockType.text = StrValue(dt, "stockType", 0) 'dt.Rows(0).Item("")
                txtAlert.text = StrValue(dt, "alertStock", 0) 'dt.Rows(0).Item("")

                isPromo.Checked = BoolValue(dt, "isPromo", 0) 'dt.Rows(0).Item("")
                isStocked.Checked = BoolValue(dt, "isStocked", 0) ' dt.Rows(0).Item("")

                lbPeriode.Text = StrValue(dt, "periode", 0) 'dt.Rows(0).Item("")
                lbImage.Text = StrValue(dt, "img", 0) 'dt.Rows(0).Item("")
                PBImage.BackgroundImage = Drawimg()
            End If
        End Using
    End Sub

    Private Sub AddEditElement()
        Validation()

        Dim params As New Dictionary(Of String, Object)
        params.Add("ref", txtRef.text)
        params.Add("name", txtName.text)
        params.Add("desc", txtDesc.text)
        params.Add("cid", cbctg.SelectedValue)

        params.Add("bprice", CDbl(txtPAch.text))
        params.Add("sprice", CDbl(txtHt.text))
        params.Add("tva", CDbl(txtTva.text))
        params.Add("prixPromo", CDbl(txtPrixPromo.Text))

        params.Add("remiseMax", CDbl(txtRmax.text))
        params.Add("remiseGr", CDbl(txtRGr.text))
        params.Add("remiseRev", CDbl(txtRRev.text))
        params.Add("remiseCF", CDbl(txtRCF.text))

        params.Add("stockType", txtStockType.text)
        params.Add("alertStock", CDbl(txtAlert.text))
        params.Add("isPromo", isPromo.Checked)
        params.Add("isStocked", isStocked.Checked)
        params.Add("periode", lbPeriode.Text)
        params.Add("img", lbImage.Text)

        Dim x As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            If EditMode Then
                Dim where As New Dictionary(Of String, Object)
                where.Add("arid", Id)
                x = a.UpdateRecord("Article", params, where)

            Else
                x = a.InsertRecord("Article", params)
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
End Class