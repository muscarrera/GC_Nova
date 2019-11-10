Module RegistryModule

    Dim regPath As String = "HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib"


    Public Function getRegistryinfo(ByVal str As String, ByVal v As Object) As String
        Try
            Dim msg = My.Computer.Registry.GetValue(regPath, str, Nothing)
            If msg = Nothing Then
                msg = v
                My.Computer.Registry.SetValue(regPath, str, msg)
            End If

            Return msg
        Catch ex As Exception
            Return v
        End Try
    End Function
    Public Sub setRegistryinfo(ByVal str As String, ByVal val As Object)
        Try
            My.Computer.Registry.SetValue(regPath, str, val)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub HandleRegistryinfo()

        'Dim msg As String
        'Try
        '    msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtNbrArt", Nothing)
        '    If msg = Nothing Then
        '        msg = "20"
        '        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "txtNbrArt", msg)
        '        txtNbrArt.Text = msg
        '        indexLastArticle = 20
        '    Else
        '        txtNbrArt.Text = msg
        '        indexLastArticle = CInt(msg)
        '    End If
        'Catch ex As Exception
        '    indexLastArticle = 20
        'End Try
        'msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SouvPath", Nothing)
        'If msg = Nothing Then
        '    msg = "C:"
        '    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "SouvPath", msg)
        '    btSvPath.Tag = msg
        'Else
        '    btSvPath.Tag = msg
        'End If

        'msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", Nothing)
        'If msg = Nothing Then
        '    msg = "C:\Al Mohassib"
        '    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "ImgPath", msg)
        '    BtImgPah.Tag = msg
        'Else
        '    BtImgPah.Tag = msg
        'End If

        'msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "BtBoundDbPath", Nothing)
        'If msg = Nothing Then
        '    msg = "C:\Al Mohassib"
        '    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "BtBoundDbPath", msg)
        '    BtBoundDbPath.Tag = msg
        'Else
        '    BtBoundDbPath.Tag = msg
        'End If
        'msg = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "btDbDv", Nothing)
        'If msg = Nothing Then
        '    msg = "C:\Al Mohassib"
        '    My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\AlMohassib", "btDbDv", msg)
        '    btDbDv.Tag = msg
        'Else
        '    btDbDv.Tag = msg
        'End If

        'getRegistryinfo(txttimp, "mainprinter", "no")
        'getRegistryinfo(txtprt2, "prt2", "no")
        'getRegistryinfo(txtreceipt, "receipt", "no")
        'getRegistryinfo(txtScale, "txtScale", "1")
        'getRegistryinfo(TextBox4, "LogoPath", "C:")
        'getRegistryinfo(cbsearch, "SearchMethod", "الكود (الرمز)")

        'getRegistryinfo(cbPaper, "cbPaper", "Normal&Receipt")
        'getRegistryinfo(txtNbrCopie, "txtNbrCopie", "1")


        'getRegistryinfo(CbArticleRemise, "CbArticleRemise", False)
        'getRegistryinfo(chbprint, "chbprint", False)
        'getRegistryinfo(chbreceipt, "chbreceipt", False)
        'getRegistryinfo(chbcb, "UseCodebarScanner", False)
        'getRegistryinfo(CbBlocModArt, "CbBlocModArt", False)
        'getRegistryinfo(CbBlocCalc, "CbBlocCalc", False)
        'getRegistryinfo(cbProfit, "cbProfit", False)
        'getRegistryinfo(CBTVA, "CBTVA", False)
        'getRegistryinfo(chbsell, "chbsell", False)
        'getRegistryinfo(cbImgPrice, "cbImgPrice", False)
        'getRegistryinfo(cbQte, "cbQte", False)
        'getRegistryinfo(cbBonToFact, "cbBonToFact", False)
        'getRegistryinfo(CbDelaiFct, "CbDelaiFct", False)
        'getRegistryinfo(chMasar, "chMasar", False)
        'getRegistryinfo(cbMultiPayemnt, "cbMultiPayemnt", False)
        'getRegistryinfo(cbheader, "cbheader", False)
        'getRegistryinfo(cbMergeArt, "cbMergeArt", True)
        'getRegistryinfo(cbUnite, "cbUnite", False)
        'getRegistryinfo(CbDisArch, "CbDisArch", False)
        'getRegistryinfo(CbQteStk, "CbDisNew", False)
        'getRegistryinfo(cbPrintDepot, "cbPrintDepot", True)
        'getRegistryinfo(CbDepotOrigine, "CbDepotOrigine", True)
        'getRegistryinfo(cbDual, "cbDual", False)
        'getRegistryinfo(cbTiroir, "cbTiroir", False)
        'getRegistryinfo(cbCaisse, "cbCaisse", False)
        'getRegistryinfo(cbTsImg, "cbTsImg", False)
        'getRegistryinfo(cbRTL, "cbRTL", False)

        'gbprint.Enabled = chbprint.Checked
    End Sub



End Module
