Module Trial

    Public Function getTrial()
        Dim b As Boolean = True
        Dim n As Integer = getRegistryinfo("nbrPrOp_Tr", 22)

        If n = -1 Then Return True

        Dim d As Date = CDate(getRegistryinfo("date_Tr", Now.Date))


        If (Now - d).Days > Form1.nbrPrOp_tr Then
            setRegistryinfo("date_Tr", Now.Date)
            setRegistryinfo("nbrPrOp_Tr", 1)
            n = 1
        End If
        n += 1
        setRegistryinfo("nbrPrOp_Tr", n)
        If n < 20 Then Return False

        

        'setRegistryinfo("nbrPrOp_Tr", n)
        'If n > Form1.nbrPrOp_tr Then b = False

        Return b
    End Function


End Module
