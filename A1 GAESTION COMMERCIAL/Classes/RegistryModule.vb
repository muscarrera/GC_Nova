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

    Public Sub HandleRegistryinfo()
        Try
            Form1.cellWidth = getRegistryinfo("cellWidth", 111)
            Form1.ImgPah = getRegistryinfo("ImgPah", "C:\")
            Form1.SvgdPah = getRegistryinfo("SvgdPah", "C:\")
            Form1.numberOfItems = getRegistryinfo("numberOfItems", 22)
            'font
            Form1.fontName_Normal = getRegistryinfo("fontName_Normal", "Arial")
            Form1.fontName_Title = getRegistryinfo("fontName_Title", "Arial")
            Form1.fontName_Small = getRegistryinfo("fontName_Small", "Arial")
            Form1.fontSize_Normal = getRegistryinfo("fontSize_Normal", 10)
            Form1.fontSize_Title = getRegistryinfo("fontSize_Title", 14)
            Form1.fontSize_Small = getRegistryinfo("fontSize_Small", 8)

            Form1.mainDepot = getRegistryinfo("mainDepot", 3)

            Form1.printer_Devis = getRegistryinfo("printer_Devis", "")
            Form1.printer_Bon = getRegistryinfo("printer_Bon", "")
            Form1.printer_Commande_Client = getRegistryinfo("printer_Commande_Client", "")
            Form1.printer_Facture = getRegistryinfo("printer_Facture", "")
            Form1.printer_Avoir = getRegistryinfo("printer_Avoir", "")
            Form1.printer_Pdf = getRegistryinfo("printer_Pdf", "")

            Form1.Ech_Bon = getRegistryinfo("txtEchBon", "1")
            Form1.Ech_Facture = getRegistryinfo("txtEchFct", "1")

            Form1.Facture_Title = getRegistryinfo("Facture_Title", "")
            Form1.imgEntetePath = getRegistryinfo("imgEntetePath", "")
            Form1.imgFootherPath = getRegistryinfo("imgFootherPath", "")

            Form1.printEnteteOnPaper = getRegistryinfo("printEnteteOnPaper", False)
            Form1.printEnteteOnPdf = getRegistryinfo("printEnteteOnPdf", False)
            Form1.hasEntete_BonTransport = getRegistryinfo("hasEntete_BonTransport", False)

            Form1.zeros = getRegistryinfo("zeros_number", "0000")

            Form1.isBaseOnOneTva = getRegistryinfo("isBaseOnOneTva", False)
            Form1.isBaseOnTTC = getRegistryinfo("isBaseOnTTC", False)
            Form1.tva = getRegistryinfo("tva", 20)

            Form1.useValue_CUMP = getRegistryinfo("useValue_CUMP", False)

            Form1.BoundDbPath = getRegistryinfo("PathBound", "C:\")
            Form1.SvgdPah = getRegistryinfo("PathSvgd", "C:\")
            Form1.ImgPah = getRegistryinfo("ImgPath", "C:\")

 

            Form1.useClientRemise_Way = getRegistryinfo("useClientRemise_Way", False)
            Form1.useBlLivrable = getRegistryinfo("useBlLivrable", False)
            Form1.useButtonValidForStock = getRegistryinfo("useButtonValidForStock", False)

            Form1.useAccessClient = getRegistryinfo("useAccessClient", False)
            Form1.useSoldByAvoir = getRegistryinfo("useSoldByAvoir", False)
            Form1.usePortMonie = getRegistryinfo("usePortMonie", False)
            Form1.useValue_CUMP = getRegistryinfo("useValue_CUMP", False)
            Form1.printRef = getRegistryinfo("printRef", False)

            'prefix
            Form1.prf_Params.clear()
            Form1.prf_Params.Add("dv", getRegistryinfo("prf_s_dv", "Av"))
            Form1.prf_Params.Add("cm", getRegistryinfo("prf_s_cm", "Cm"))
            Form1.prf_Params.Add("bl", getRegistryinfo("prf_s_bl", "Bl"))
            Form1.prf_Params.Add("fc", getRegistryinfo("prf_s_fc", "Fc"))
            Form1.prf_Params.Add("av", getRegistryinfo("prf_s_av", "Av"))

            Form1.prf_Params.Add("bc", getRegistryinfo("prf_b_bc", "Bc"))
            Form1.prf_Params.Add("ba", getRegistryinfo("prf_b_ba", "Ba"))
            Form1.prf_Params.Add("fc_b", getRegistryinfo("prf_b_fc", "Fc"))
            Form1.prf_Params.Add("av_b", getRegistryinfo("prf_b_av", "Av"))


            'Colors
            Form1.Color_Default_Text = Color.FromArgb(getRegistryinfo("Color_Default_Text", Color.Blue.ToArgb.ToString))
            Form1.Color_Selected_Text = Color.FromArgb(getRegistryinfo("Color_Selected_Text", Color.Yellow.ToArgb.ToString))
            Form1.Color_Default_Row = Color.FromArgb(getRegistryinfo("Color_Default_Row", Color.Bisque.ToArgb.ToString))
            Form1.Color_Alternating_Row = Color.FromArgb(getRegistryinfo("Color_Alternating_Row", Color.WhiteSmoke.ToArgb.ToString))
            Form1.Color_Selected_Row = Color.FromArgb(getRegistryinfo("Color_Selected_Row", Color.Red.ToArgb.ToString))





            'way of Stock
            If Form1.useButtonValidForStock Then Form1.isWorkinOnStock = False
        Catch ex As Exception

        End Try

    End Sub



End Module
