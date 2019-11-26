Public Class AddEditDriver
    'Image
    Private _imgPrd As Image
    Private _id As Integer = 0

    Public EditMode As Boolean = False
    Public tb_C As String = "Driver"

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
            If value = 0 Then Exit Property

            FillForm(value, tb_C)
        End Set
    End Property
    'ref
    Private Sub txtRef_TxtChanged() Handles txtRef.TxtChanged
        lbRef.Text = "[" & txtRef.text & "]"
    End Sub

    Private Sub Validation()
        If txtName.text.Trim = "" Then
            Dim str As String = "Nom de Chauffeur est Obligatoire"
            str &= vbNewLine
            str &= "Veuillez remplir tous les champs obligatoires"
            MsgBox(str, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "ERROR")
            txtName.Focus()
            Exit Sub
        End If
        If txtCIN.text.Trim = "" Then txtCIN.text = "-"
        If txtAdresse.text.Trim = "" Then txtAdresse.text = "-"
        If txtTel.text.Trim = "" Then txtTel.text = "-"
        If txtDate.text.Trim = "" Then txtDate.text = "-"
        If txtCnss.text.Trim = "" Then txtCnss.text = "-"
        If txtInfo.text.Trim = "" Then txtInfo.text = "-"

    End Sub
    Private Sub FillForm(ByVal _Pid As Integer, ByVal tb_C As String)

        Dim cid = 0
        Dim params As New Dictionary(Of String, Object)
        params.Add("Drid", _Pid)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable(tb_C, {"*"}, params)
            If dt.Rows.Count > 0 Then

                txtRef.text = StrValue(dt, "ref", 0)
                txtName.text = StrValue(dt, "name", 0)
                txtAdresse.text = StrValue(dt, "adresse", 0)
                txtTel.text = StrValue(dt, "tel", 0)
                txtDate.text = StrValue(dt, "date", 0)
                txtCnss.text = StrValue(dt, "cnss", 0)
                txtCIN.text = StrValue(dt, "cin", 0)
                txtInfo.text = StrValue(dt, "info", 0)

            End If
        End Using
    End Sub

    Private Sub AddEditElement()
        Validation()

        Dim params As New Dictionary(Of String, Object)
        params.Add("ref", txtRef.text)
        params.Add("name", txtName.text)
        params.Add("adresse", txtAdresse.text)
        params.Add("cin", txtCIN.text)
        params.Add("cnss", txtCnss.text)
        params.Add("date", txtDate.text)
        params.Add("tel", txtTel.text)
        params.Add("info", txtInfo.text)

        Dim x As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            If EditMode Then
                Dim where As New Dictionary(Of String, Object)
                where.Add("Drid", Id)
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

End Class