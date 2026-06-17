Module SlidingPieceGeneration

    Function GenerateMaskBishopAttacks()
        Dim BishopAttacks(63) As ULong

        For looper = 0 To 63
            Dim Attacks As ULong = 0UL
            Dim rank, file As Integer
            Dim targetrank, targetfile As Integer

            targetrank = looper \ 8
            targetfile = looper Mod 8

            rank = targetrank + 1
            file = targetfile + 1

            Do While rank <= 6 And file <= 6 'North-East +1, +1
                Attacks = Attacks Or (1UL << (rank * 8 + file))

                rank += 1
                file += 1
            Loop

            rank = targetrank - 1
            file = targetfile + 1

            Do While rank >= 1 And file <= 6 'South-East -1, +1
                Attacks = Attacks Or (1UL << (rank * 8 + file))

                rank -= 1
                file += 1
            Loop

            rank = targetrank - 1
            file = targetfile - 1

            Do While rank >= 1 And file >= 1 'South-West -1, -1
                Attacks = Attacks Or (1UL << (rank * 8 + file))

                rank -= 1
                file -= 1
            Loop

            rank = targetrank + 1
            file = targetfile - 1

            Do While rank <= 6 And file >= 1 'North-West +1, -1
                Attacks = Attacks Or (1UL << (rank * 8 + file))

                rank += 1
                file -= 1
            Loop

            BishopAttacks(looper) = Attacks
        Next

        Return BishopAttacks
    End Function

    Function GenerateMaskRookAttacks()
        Dim RookAttacks(63) As ULong

        For looper = 0 To 63
            Dim Attacks As ULong = 0UL
            Dim rank, file As Integer
            Dim targetrank, targetfile As Integer

            targetrank = looper \ 8
            targetfile = looper Mod 8

            rank = targetrank + 1
            file = targetfile

            Do While rank <= 6 'North
                Attacks = Attacks Or (1UL << (rank * 8 + file))
                rank += 1
            Loop

            rank = targetrank
            file = targetfile + 1

            Do While file <= 6 'East
                Attacks = Attacks Or (1UL << (rank * 8 + file))
                file += 1
            Loop

            rank = targetrank - 1
            file = targetfile

            Do While rank >= 1 'South
                Attacks = Attacks Or (1UL << (rank * 8 + file))
                rank -= 1
            Loop

            rank = targetrank
            file = targetfile - 1

            Do While file >= 1  'West
                Attacks = Attacks Or (1UL << (rank * 8 + file))
                file -= 1
            Loop

            RookAttacks(looper) = Attacks
        Next

        Return RookAttacks
    End Function

    Function GenerateMaskBishopAttacksOnTheFly(ByVal square As Integer, ByVal block As ULong)
        Dim Attacks As ULong = 0UL
        Dim rank, file As Integer
        Dim targetrank, targetfile As Integer

        targetrank = square \ 8
        targetfile = square Mod 8

        rank = targetrank + 1
        file = targetfile + 1

        Do While rank <= 7 And file <= 7 'North-East +1, +1
            Attacks = Attacks Or (1UL << (rank * 8 + file))

            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If

            rank += 1
            file += 1
        Loop

        rank = targetrank - 1
        file = targetfile + 1

        Do While rank >= 0 And file <= 7 'South-East -1, +1
            Attacks = Attacks Or (1UL << (rank * 8 + file))

            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If

            rank -= 1
            file += 1
        Loop

        rank = targetrank - 1
        file = targetfile - 1

        Do While rank >= 0 And file >= 0 'South-West -1, -1
            Attacks = Attacks Or (1UL << (rank * 8 + file))

            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If

            rank -= 1
            file -= 1
        Loop

        rank = targetrank + 1
        file = targetfile - 1

        Do While rank <= 7 And file >= 0 'North-West +1, -1
            Attacks = Attacks Or (1UL << (rank * 8 + file))

            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If

            rank += 1
            file -= 1
        Loop

        Return Attacks
    End Function

    Function GenerateMaskRookAttacksOnTheFly(ByVal square As Integer, ByVal block As ULong)

        Dim Attacks As ULong = 0UL
        Dim rank, file As Integer
        Dim targetrank, targetfile As Integer

        targetrank = square \ 8
        targetfile = square Mod 8

        rank = targetrank + 1
        file = targetfile

        Do While rank <= 7 'North
            Attacks = Attacks Or (1UL << (rank * 8 + file))
            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If
            rank += 1
        Loop

        rank = targetrank
        file = targetfile + 1

        Do While file <= 7 'East
            Attacks = Attacks Or (1UL << (rank * 8 + file))
            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If
            file += 1
        Loop

        rank = targetrank - 1
        file = targetfile

        Do While rank >= 0 'South
            Attacks = Attacks Or (1UL << (rank * 8 + file))
            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If
            rank -= 1
        Loop

        rank = targetrank
        file = targetfile - 1

        Do While file >= 0  'West
            Attacks = Attacks Or (1UL << (rank * 8 + file))
            If ((1UL << rank * 8 + file) And block) <> 0UL Then
                Exit Do
            End If
            file -= 1
        Loop

        Return Attacks
    End Function
End Module
