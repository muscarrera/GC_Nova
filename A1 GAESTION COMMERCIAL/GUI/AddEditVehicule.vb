Public Class AddEditVehicule
    'Image
    Private _imgPrd As Image
    Private _id As Integer = 0

    Public EditMode As Boolean = False
    Public tb_C As String = "Vehicule"

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
        If txtKm.text.Trim = "" Then txtKm.text = "-"
        If txtMarque.text.Trim = "" Then txtMarque.text = "-"
        If txtModel.text.Trim = "" Then txtModel.text = "-"
        If txtYear.text.Trim = "" Then txtYear.text = "-"
        If txtCarb.text.Trim = "" Then txtCarb.text = "-"
        If txtEtat.text.Trim = "" Then txtEtat.text = "-"
        If txtInfo.text.Trim = "" Then txtInfo.text = "-"

    End Sub
    Private Sub FillForm(ByVal _Pid As Integer, ByVal tb_C As String)

        Dim cid = 0
        Dim params As New Dictionary(Of String, Object)
        params.Add("Vid", _Pid)
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable(tb_C, {"*"}, params)
            If dt.Rows.Count > 0 Then

                txtRef.text = StrValue(dt, "ref", 0)
                txtName.text = StrValue(dt, "name", 0)
                txtKm.text = StrValue(dt, "km", 0)
                txtMarque.text = StrValue(dt, "marque", 0)
                txtModel.text = StrValue(dt, "model", 0)
                txtYear.text = StrValue(dt, "year", 0)
                txtCarb.text = StrValue(dt, "carb", 0)
                txtEtat.text = StrValue(dt, "etat", 0)
                txtInfo.text = StrValue(dt, "info", 0)

                txtKm.txtReadOnly = False
            End If
        End Using
    End Sub

    Private Sub AddEditElement()
        Validation()

        Dim params As New Dictionary(Of String, Object)
        params.Add("ref", txtRef.text)
        params.Add("name", txtName.text)
        params.Add("km", txtKm.text)
        params.Add("marque", txtMarque.text)
        params.Add("model", txtModel.text)
        params.Add("year", txtYear.text)
        params.Add("carb", txtCarb.text)
        params.Add("etat", txtEtat.text)
        params.Add("info", txtInfo.text)
        Dim x As Integer = 0
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)

            If EditMode Then
                Dim where As New Dictionary(Of String, Object)
                where.Add("Vid", Id)
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