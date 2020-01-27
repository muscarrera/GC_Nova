﻿Public Class AricleClass
    Implements IDisposable

    Public Function AutoCompleteArticles(ByVal field As String) As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Article", {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item(field).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function AutoCompleteGroupes() As AutoCompleteStringCollection
        ' auto complitae
        'Item is filled either manually or from database
        Dim lst As New List(Of String)

        'AutoComplete collection that will help to filter keep the records.
        Dim MySource As New AutoCompleteStringCollection()

        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Category", {"*"})
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    lst.Add(dt.Rows(i).Item("name").ToString & "|" & dt.Rows(i).Item(0).ToString)
                Next
            End If
        End Using

        'Records binded to the AutocompleteStringCollection.
        MySource.AddRange(lst.ToArray)
        Return MySource
    End Function
    Public Function GetByfield(ByVal field As String, ByVal val As String) As Article
      
        Dim params As New Dictionary(Of String, Object)
        params.Add(field, val)
        Dim art As Article = Nothing
        ' added some items
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
            If dt.Rows.Count > 0 Then

                Dim sprice As Double = DblValue(dt, "sprice", 0)
                Dim bprice As Double = DblValue(dt, "bprice", 0)

                Dim isPromo = False

                If BoolValue(dt, "isPromo", 0) Then
                    Dim periode = StrValue(dt, "periode", 0)

                    Dim dt1, dt2 As Date
                    Dim str As String() = periode.Split(">")

                    Try
                        dt1 = CDate(str(0).Trim).AddDays(-1)
                        dt2 = CDate(str(1).Trim).AddDays(1)

                        If Now.Date > dt1 And Now.Date < dt2 Then
                            If IsNumeric(DblValue(dt, "prixPromo", 0)) And DblValue(dt, "prixPromo", 0) > 0 Then
                                sprice = DblValue(dt, "prixPromo", 0)
                                isPromo = True
                            End If
                        End If
                    Catch ex As Exception
                        isPromo = False
                        params.Add("isPromo", False)
                        Dim where As New Dictionary(Of String, Object)
                        where.Add("arod", dt.Rows(0).Item(0))
                        a.UpdateRecord("Article", params, where)
                    End Try

                End If

                Dim tva As Double = DblValue(dt, "tva", 0)
                If Form1.isBaseOnOneTva Then tva = Form1.tva

                'If Form1.isBaseOnTTC Then
                '    sprice += sprice * tva / 100
                '    bprice += bprice * tva / 100
                'End If

                art = New Article(dt.Rows(0).Item(0), IntValue(dt, "cid", 0),
                                  StrValue(dt, "name", 0), StrValue(dt, "desc", 0),
                                  1, sprice, bprice, tva, 0, IntValue(dt, "depot", 0),
                                  BoolValue(dt, "isStocked", 0), StrValue(dt, "ref", 0), isPromo)
            End If
        End Using
        Return art
    End Function

    Public Function GetRemise(ByVal arid As String, ByVal TypeClient As String) As Double

        Dim params As New Dictionary(Of String, Object)
        params.Add("arid", arid)
        Dim remise As Double = 0
        Dim maxRemise As Double = 0
        ' added some items

        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
            Dim dt As DataTable = a.SelectDataTable("Article", {"*"}, params)
            If dt.Rows.Count > 0 Then
                maxRemise = DblValue(dt, "remiseMax", 0)
                If TypeClient = "GROS" Then
                    remise = DblValue(dt, "remiseGr", 0)
                ElseIf TypeClient = "REVENDEUR" Then
                    remise = DblValue(dt, "remiseRev", 0)
                Else
                    remise = DblValue(dt, "remiseCF", 0)
                End If

                params.Clear()
                params.Add("cid", dt.Rows(0).Item("cid"))

                dt.Rows.Clear()
                dt = a.SelectDataTable("Category", {"*"}, params)
                If dt.Rows.Count > 0 Then
                    remise += DblValue(dt, "remise", 0)
                End If
            End If
        End Using

        Return remise
    End Function


    Public Sub AddDataList()
        Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString)
            Dim dt As DataTable = a.SelectDataTableWithSyntaxe("Article", "TOP " & Form1.numberOfItems, {"*"})

            Form1.plBody.Controls.Clear()
            Dim ds As New ProductList
            ds.Mode = "Article"
            ds.DataSource = dt
            ds.AutoCompleteSourceGroupe = AutoCompleteGroupes()
            ds.Dock = DockStyle.Fill
            AddHandler ds.GetElements, AddressOf GetElements
            AddHandler ds.NewElement, AddressOf NewElement
            AddHandler ds.EditArticle, AddressOf EditElement
            AddHandler ds.DeleteArticle, AddressOf DeleteElement
            'AddHandler ds.SearchById, AddressOf SearchById

            Form1.plBody.Controls.Add(ds)
        End Using
    End Sub
    Private Sub GetElements(ByRef ds As ProductList)
        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0

            If ds.txtSearchCtg.text.Contains("|") Then
                Try
                    cid = CInt(ds.txtSearchCtg.text.Split("|")(1))
                Catch ex As Exception
                    cid = 0
                End Try
            End If

            If ds.txtSearchName.text <> "" And ds.txtSearchName.text <> "*" Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    If cid > 0 Then params.Add("cid = ", cid)
                    params.Add("name Like ", "%" & ds.txtSearchName.text & "%")

                    dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    params.Clear()

                    If cid > 0 Then params.Add("cid = ", cid)
                    params.Add("ref Like ", "%" & ds.txtSearchName.text & "%")
                    Dim dt2 = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    dt.Merge(dt2, False)
                End Using
            ElseIf ds.txtSearchName.text = "*" Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    dt = a.SelectDataTable(ds.TableName, {"*"})
                End Using
            ElseIf ds.txtSearchName.text = "" Then
                Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                    If cid > 0 Then
                        params.Add("cid = ", cid)
                        dt = a.SelectDataTableSymbols(ds.TableName, {"*"}, params)
                    Else
                        dt = a.SelectDataTableWithSyntaxe(ds.TableName, "TOP " & Form1.numberOfItems, {"*"})
                    End If
                End Using
            End If

            ds.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub NewElement(ByRef ds As ProductList)
        Dim pr As New AddEditProduct
        pr.txtTva.text = Form1.tva

        If pr.ShowDialog = DialogResult.OK Then
            ds.txtSearchName.text = pr.txtName.text
            GetElements(ds)
        End If
    End Sub
    Private Sub EditElement(ByRef ls As ListLine)
        Dim pr As New AddEditProduct
        Try
            pr.Id = ls.Id
            If pr.ShowDialog = DialogResult.OK Then
                ls.Libele = pr.txtName.text
                Dim sp = pr.txtHt.text
                Dim bp = pr.txtPAch.text

                If Form1.isBaseOnTTC Then
                    Dim tv = pr.txtTva.text
                    If Form1.isBaseOnOneTva Then tv = Form1.tva

                    sp += sp * tv / 100
                    bp += bp * tv / 100
                End If

                ls.Total = bp
                ls.Avance = sp
                ls.isEdited = True
            End If
        Catch ex As Exception
        End Try


    End Sub
    Private Sub DeleteElement(ByRef ds As ProductList, ByVal ls As ListLine)
        If MsgBox("عند قيامكم على الضغط على 'موافق' سيتم حذف المادة المؤشر عليها من القائمة .. إضغط  'لا'  لالغاء الحذف ", MsgBoxStyle.YesNo Or MessageBoxIcon.Exclamation, "حذف المادة") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim params As New Dictionary(Of String, Object)
            Dim dt As DataTable = Nothing
            Dim cid As Integer = 0

            Using a As DataAccess = New DataAccess(My.Settings.ALMohassinDBConnectionString, True)
                params.Add("arid", ls.Id)

                If a.DeleteRecords(ds.TableName, params) > 0 Then
                    ds.RemoveElement(ls)
                End If
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
