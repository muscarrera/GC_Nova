Imports System.IO

Public Class PvList

    Dim tb_C As String = "Client"

    Event txtSearchRef_Changed(ByRef ds As PvList, ByVal txt As String)
    Event txtSearchRef_KeyPress(ByRef ds As PvList, ByVal txt As String)
    Event txtSearchCodebar_KeyPress(ByRef ds As PvList, ByVal txt As String)




    'Members
    Public modeSearch_isCode As Boolean = False
    Public localName As String


    Shared random As New Random()

    'property

    Private numberOpenBonsValue As Integer

    Event NewFacture()

    Public Property numberOpenBons() As Integer
        Get
            Return numberOpenBonsValue
        End Get
        Set(ByVal value As Integer)
            numberOpenBonsValue = value

            If value > 0 Then
                plClientSide.Width = 275
                lbNbrBon.Text = value

                If value > 10 Then
                    lbNbrBon.ForeColor = Color.Red
                Else
                    lbNbrBon.ForeColor = Color.Green
                End If
            Else
                plClientSide.Width = 62
            End If
        End Set
    End Property
    Public ReadOnly Property ThePath As String
        Get
            Dim dir1 As New DirectoryInfo(Form1.ImgPah & "\Prt_Pv")
            If dir1.Exists = False Then dir1.Create()

            Return Form1.ImgPah & "\Prt_Pv\" & localName
        End Get
    End Property



    'subs
    Public Sub KeepTxtFocus()
        If modeSearch_isCode Then
            txtSearchCode.Text = ""
            txtSearchCode.Focus()
        Else
            txtSearch.Text = ""
            txtSearch.Focus()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
                                               ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Dim k As System.Windows.Forms.Keys = keyData
        Select Case keyData

            Case Keys.F1

            Case Keys.F2

            Case Keys.F3

            Case Keys.F4

            Case Keys.F5

            Case Keys.Add ' add one

            Case Keys.F8 ' add NOUVEAU FACTURE

            Case Keys.F9 ' add NOUVEAU FACTURE

            Case Keys.F12

            Case Keys.F11

            Case Keys.Tab
                modeSearch_isCode = Not modeSearch_isCode
                KeepTxtFocus()

            Case Keys.Space  ' save and print
                Dim a As Integer = 0

                If txtSearch.Focused Then a = 1
                If txtSearchCode.Focused Then a = 1


                If a = 1 Then
                    If RPL.Total_TTC = 0 Then
                        Return MyBase.ProcessCmdKey(msg, keyData)
                    End If

                    If txtSearch.Text.Trim <> "" Or txtSearchCode.Text.Trim <> "" Then
                        Return MyBase.ProcessCmdKey(msg, keyData)
                    End If



                    'If cbPaper.Text = "Receipt" Then
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, False, False)
                    'ElseIf cbPaper.Text = "Normal" Then
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, True, False)
                    'ElseIf cbPaper.Text = "Normal&A4" Then
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, True, False)
                    'Else
                    '    RPl_SaveAndPrint(RPl.FctId, RPl.Total_TTC, RPl.Avance, RPl.Tva, RPl.DataSource, RPl.isSell, False, False)
                    'End If
                Else
                    Return MyBase.ProcessCmdKey(msg, keyData)
                End If

            Case Keys.Delete ' delete facture
                If RPL.FctId = 0 Then Return False
                Dim str As String = " عند قيامكم على الضغط على 'موافق' سيتم حذف فاتورة "
                str = str + vbNewLine
                str = str & RPL.ClientName & " ( " & RPL.FctId & ")"
                str = str + vbNewLine
                str = str + " و جميع المواد الدفعات المسجلة في القائمة ..    "
                str = str + vbNewLine
                str = str + "  .. إضغط  'لا'  لالغاء الحذف   "

                'If MsgBox(str, MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "الغاء الفاتورة") = MsgBoxResult.No Then
                '    Return False
                'End If
                'RPl_DeleteFacture(RPl.FctId, RPl.isSell, RPl.EditMode, RPl.DataSource)
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select

        KeepTxtFocus()
        Return True
    End Function



    'Search
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress

        If e.KeyChar = Chr(13) And FL.Controls.Count = 1 Then
            RaiseEvent txtSearchRef_KeyPress(Me, txtSearch.Text)
            KeepTxtFocus()
        End If

    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged

        RaiseEvent txtSearchRef_Changed(Me, txtSearch.Text)

    End Sub
    Private Sub txtSearchCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCode.KeyPress

        If e.KeyChar = Chr(13) Then
            RaiseEvent txtSearchCodebar_KeyPress(Me, txtSearchCode.Text)
            KeepTxtFocus()
        End If

    End Sub
    'new bons
    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.Click
        Dim op As New pvNewFacture
        If op.ShowDialog = DialogResult.OK Then
            Dim n = random.Next().ToString & "-" & Now.Date.ToString("dd-MM-mm-hh") & ".dat"
            localName = n

            If op.isNormal Then
                Try

                    Dim g As New PvModel
                    g.localName = n

                    WriteToXmlFile(Of PvModel)(ThePath, g)

                Catch ex As Exception
                End Try
            Else
                Dim NF As New NouveauFacture
                NF.TxtExr.Text = Form1.Exercice
                NF.txtName.Focus()
                NF.txtName.AutoCompleteSource = AutoCompleteByName(tb_C)
                NF.tb_C = tb_C
                NF.txtDate.text = Now.Date.ToString("dd/MM/yyyy")
                If NF.ShowDialog = DialogResult.OK Then
                    Dim cn As String = NF.txtName.text
                    Dim cid As String = 0

                    Try
                        cn = NF.txtName.text.Split("|")(0)
                        cid = NF.txtName.text.Split("|")(1)
                    Catch ex As Exception
                        cid = 0
                    End Try

                    Try

                        Dim g As New PvModel
                        g.bonDate = CDate(NF.txtDate.text)
                        g.ClientId = cid
                        g.ClientName = cn
                        g.localName = n

                        WriteToXmlFile(Of PvModel)(ThePath, g)

                    Catch ex As Exception
                    End Try

                End If
            End If
        End If
        KeepTxtFocus()
    End Sub
    'show list of open bons
    Private Sub Panel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel3.Click
        If numberOpenBonsValue Then PL.Visible = True
    End Sub


End Class
