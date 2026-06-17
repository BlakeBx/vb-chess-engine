Module StaticPieceGeneration
    Const FILE_A As ULong = &H101010101010101UL
    Const FILE_B As ULong = &H202020202020202UL
    Const FILE_G As ULong = &H4040404040404040UL
    Const FILE_H As ULong = &H8080808080808080UL

    Const NOT_FILE_A As ULong = Not FILE_A
    Const NOT_FILE_H As ULong = Not FILE_H

    Const Mask_A As ULong = FILE_A
    Const Mask_H As ULong = FILE_H
    Const Mask_AB As ULong = (FILE_A Or FILE_B)
    Const Mask_GH As ULong = (FILE_G Or FILE_H)

    '--------------------------------------------------------------------------------------------------

    Function GenerateWhitePawnPushes()
        Dim WhitePawnArray(63) As ULong

        For looper = 0 To 63
            Dim ValidMoves As ULong = 0UL
            Dim PawnPosition As ULong = 1UL << looper
            Dim Shift As Integer = 8

            ValidMoves = PawnPosition << Shift

            WhitePawnArray(looper) = ValidMoves
        Next

        Return WhitePawnArray
    End Function

    Function GenerateBlackPawnPushes()
        Dim BlackPawnArray(63) As ULong

        For looper = 0 To 63
            Dim ValidMoves As ULong = 0UL
            Dim PawnPosition As ULong = 1UL << looper
            Dim Shift As Integer = 8

            ValidMoves = PawnPosition >> Shift

            BlackPawnArray(looper) = ValidMoves
        Next

        Return BlackPawnArray
    End Function

    Sub GeneratePawnAttacks(ByVal Side, ByRef PawnArray)

        If Side Then 'White Pieces
            For looper = 0 To 63
                Dim ValidMoves As ULong = 0UL
                Dim PawnPosition As ULong = 1UL << looper

                If (NOT_FILE_A And PawnPosition) <> 0UL Then
                    ValidMoves = ValidMoves Or (PawnPosition << 7)
                End If

                If (NOT_FILE_H And PawnPosition) <> 0UL Then
                    ValidMoves = ValidMoves Or (PawnPosition << 9)
                End If

                PawnArray(0, looper) = ValidMoves
            Next
        Else         'Black Pieces
            For looper = 0 To 63
                Dim ValidMoves As ULong = 0UL
                Dim PawnPosition As ULong = 1UL << looper

                If (NOT_FILE_H And PawnPosition) <> 0UL Then
                    ValidMoves = ValidMoves Or (PawnPosition >> 7)
                End If

                If (NOT_FILE_A And PawnPosition) <> 0UL Then
                    ValidMoves = ValidMoves Or (PawnPosition >> 9)
                End If

                PawnArray(1, looper) = ValidMoves
            Next
        End If

        
    End Sub

    Function GenerateKnightMoves()
        Dim KnightArray(63) As ULong

        For looper = 0 To 63
            Dim KnightPosition As ULong = 1UL << looper
            Dim ValidMoves As ULong = 0UL
            Dim Shift As Integer

            Shift = 17
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_H) << Shift
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_A) >> Shift

            Shift = 15
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_A) << Shift
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_H) >> Shift

            Shift = 10
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_GH) << Shift
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_AB) >> Shift

            Shift = 6
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_AB) << Shift
            ValidMoves = ValidMoves Or (KnightPosition And Not Mask_GH) >> Shift

            KnightArray(looper) = ValidMoves
        Next

        Return KnightArray
    End Function

    Function GenerateKingMoves()
        Dim KingArray(63) As ULong

        For looper = 0 To 63
            Dim KingPosition As ULong = 1UL << looper
            Dim ValidMoves As ULong = 0UL
            Dim Shift As Integer

            Shift = 9
            ValidMoves = ValidMoves Or (KingPosition And Not Mask_H) << Shift
            ValidMoves = ValidMoves Or (KingPosition And Not Mask_A) >> Shift

            Shift = 8
            ValidMoves = ValidMoves Or KingPosition << Shift
            ValidMoves = ValidMoves Or KingPosition >> Shift

            Shift = 7
            ValidMoves = ValidMoves Or (KingPosition And Not Mask_A) << Shift
            ValidMoves = ValidMoves Or (KingPosition And Not Mask_H) >> Shift

            Shift = 1
            ValidMoves = ValidMoves Or (KingPosition And Not Mask_H) << Shift
            ValidMoves = ValidMoves Or (KingPosition And Not Mask_A) >> Shift

            KingArray(looper) = ValidMoves
        Next

        Return KingArray
    End Function
End Module
