Module MagicNumbers
    Function FindMagicNumber(ByVal square As Integer, ByVal relevantBits As Integer, ByVal bishop As Integer) As ULong

        Dim occupancies(4095) As ULong ' 4095, as thats the max amount for a rook
        Dim attacks(4095) As ULong
        Dim usedAttacks(4095) As ULong
        Dim attackMask As ULong

        If bishop = 1 Then
            attackMask = Main.MaskedBishopMoves(square)
        Else
            attackMask = Main.MaskedRookMoves(square)
        End If

        Dim occupancyIndicies As Integer = 1UL << relevantBits

        Dim index As Integer = 0

        While index < occupancyIndicies
            occupancies(index) = Main.SetOccupancy(index, relevantBits, attackMask)
            If bishop = 1 Then
                attacks(index) = SlidingPieceGeneration.GenerateMaskBishopAttacksOnTheFly(square, occupancies(index))
            Else
                attacks(index) = SlidingPieceGeneration.GenerateMaskRookAttacksOnTheFly(square, occupancies(index))
            End If


            index += 1
        End While

        Dim randomCount As Integer = 0

        While randomCount < 100000000

            Dim magicNumber As ULong = PseudoRNG.GenerateMagicNumber

            If (((Main.CountBits(attackMask * magicNumber) & &HFF00000000000000UL))) < 6 Then
                Continue While
            End If

            Array.Clear(usedAttacks, 0UL, usedAttacks.Length)

            index = 0
            Dim fail As Integer = 0

            While (Not fail) And (index < occupancyIndicies)

                Dim magicIndex As Integer = CType((occupancies(index) * magicNumber) >> (64 - relevantBits), Integer)

                If (usedAttacks(magicIndex)) = 0UL Then
                    usedAttacks(magicIndex) = attacks(index)
                ElseIf usedAttacks(magicIndex) <> attacks(index) Then
                    fail = 1
                End If

                index += 1
            End While


            If Not fail Then
                Return magicNumber
            End If

            randomCount += 1
        End While

        MsgBox("Magic number fails")
        Return 0UL
    End Function

End Module
