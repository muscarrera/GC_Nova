Module Trial

    Public Function getTrial()
        Dim b As Boolean = True
        Dim n As Integer = getRegistryinfo("nbrPrOp_Tr", 1)
        n += 1
        setRegistryinfo("nbrPrOp_Tr", n)
        If n > Form1.nbrPrOp_tr Then b = False

        Return b
    End Function


End Module
