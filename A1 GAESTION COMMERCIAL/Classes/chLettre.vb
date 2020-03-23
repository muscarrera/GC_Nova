
' Conversion de chiffre en lettre de 0 à 1999 milliard 999 999 999
Module ChLettre
    Dim chiffre() As String
    Dim dizaine() As String
    Dim chaine As String

    Private Sub init()
        ReDim dizaine(7) ' *** tableau contenant les noms des dizaines
        dizaine(1) = "dix"
        dizaine(2) = "vingt"
        dizaine(3) = "trente"
        dizaine(4) = "quarante"
        dizaine(5) = "cinquante"
        dizaine(6) = "soixante"

        ReDim chiffre(20) ' *** tableau contenant le nom des 19 premiers nombres en lettres
        chiffre(1) = "un"
        chiffre(2) = "deux"
        chiffre(3) = "trois"
        chiffre(4) = "quatre"
        chiffre(5) = "cinq"
        chiffre(6) = "six"
        chiffre(7) = "sept"
        chiffre(8) = "huit"
        chiffre(9) = "neuf"
        chiffre(10) = "dix"
        chiffre(11) = "onze"
        chiffre(12) = "douze"
        chiffre(13) = "treize"
        chiffre(14) = "quatorze"
        chiffre(15) = "quinze"
        chiffre(16) = "seize"
        chiffre(17) = "dix-sept"
        chiffre(18) = "dix-huit"
        chiffre(19) = "dix-neuf"
    End Sub
    Public Function NBLT(ByVal nb As Long) As String
        Call init()
        If nb = 0 Then
            NBLT = "Zéro"
            Exit Function
        End If
        chaine = ""
        Decompose(nb)
        chaine = Replace(chaine, "  ", " ")
        chaine = Replace(chaine, "- ", "-")
        NBLT = chaine
    End Function
    Private Sub Decompose(ByVal Nombre As Long)
        Dim Reste As Long
        If Nombre > (10 ^ 9) Then

            Reste = Nombre Mod (10 ^ 9)
            Nombre = Nombre \ (10 ^ 9)

            If Nombre > 10 Then
                Decompose(Nombre)
            Else
                chaine += chiffre(Convert.ToInt16(Nombre))
            End If

            chaine += " milliard"
            If Nombre > 1 Then chaine += "s"

            Decompose(Reste)

        Else

            If Nombre > (10 ^ 6) Then

                Reste = Nombre Mod (10 ^ 6)
                Nombre = Nombre \ (10 ^ 6)

                If Nombre > 10 Then
                    Decompose(Nombre)
                Else
                    chaine += " " & chiffre(Convert.ToInt16(Nombre))

                End If

                chaine += " million"
                If Nombre > 1 Then chaine += "s"

                Decompose(Reste)

            Else
                If Nombre >= (10 ^ 3) Then

                    Reste = Nombre Mod (10 ^ 3)
                    Nombre = Nombre \ (10 ^ 3)

                    If Nombre > 10 Then
                        Decompose(Nombre)
                    Else
                        If Nombre > 1 Then chaine += " " & chiffre(Convert.ToInt16(Nombre))
                    End If

                    chaine += " mille"

                    Decompose(Reste)

                Else

                    If Nombre >= (100) Then

                        Reste = Nombre Mod (100)
                        Nombre = Nombre \ (100)

                        If Nombre > 10 Then
                            Decompose(Nombre)
                        Else
                            If Nombre > 1 Then chaine += " " & chiffre(Convert.ToInt16(Nombre))
                        End If

                        chaine += " cent"
                        If Nombre > 1 And Reste = 0 Then chaine += "s"

                        Decompose(Reste)

                    Else

                        If Nombre >= 80 And Nombre < 100 Then

                            Reste = Nombre Mod 20
                            Nombre = Nombre \ 20

                            If Nombre > 10 Then
                                Decompose(Nombre)
                            Else
                                chaine += " " & chiffre(Convert.ToInt16(Nombre))
                            End If

                            chaine += "-vingt"

                            Decompose(Reste)

                        Else

                            If Nombre < 20 And Nombre > 9 Then

                                chaine += " " & chiffre(Convert.ToInt16(Nombre))

                            Else

                                If Nombre > 19 And Nombre < 70 Then

                                    Reste = Nombre Mod 10
                                    Nombre = Nombre \ 10

                                    If Nombre > 10 Then
                                        Decompose(Nombre)
                                    Else
                                        chaine += " " & dizaine(Convert.ToInt16(Nombre))
                                    End If

                                    If Reste = 1 Then
                                        chaine += " et" ' Cas particlier (Ving et un , trante et un , etc...)
                                    Else
                                        If Reste <> 0 Then chaine += "-"
                                    End If

                                    Decompose(Reste)

                                Else

                                    If Nombre >= 70 Then

                                        chaine += " soixante"
                                        Reste = Nombre - 60

                                        If Reste = 1 Or Reste = 11 Then chaine += " et"

                                        Decompose(Reste)

                                    Else

                                        If Nombre < 10 Then chaine += " " & chiffre(Convert.ToInt16(Nombre))

                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
End Module
