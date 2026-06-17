Public Class Main
    Dim RookMagicNumbers() As ULong = {
        &H8A80104000800020UL,
        &H140002000100040UL,
        &H2801880A0017001UL,
        &H100081001000420UL,
        &H200020010080420UL,
        &H3001C0002010008UL,
        &H8480008002000100UL,
        &H2080088004402900UL,
        &H800098204000UL,
        &H2024401000200040UL,
        &H100802000801000UL,
        &H120800800801000UL,
        &H208808088000400UL,
        &H2802200800400UL,
        &H2200800100020080UL,
        &H801000060821100UL,
        &H80044006422000UL,
        &H100808020004000UL,
        &H12108A0010204200UL,
        &H140848010000802UL,
        &H481828014002800UL,
        &H8094004002004100UL,
        &H4010040010010802UL,
        &H20008806104UL,
        &H100400080208000UL,
        &H2040002120081000UL,
        &H21200680100081UL,
        &H20100080080080UL,
        &H2000A00200410UL,
        &H20080800400UL,
        &H80088400100102UL,
        &H80004600042881UL,
        &H4040008040800020UL,
        &H440003000200801UL,
        &H4200011004500UL,
        &H188020010100100UL,
        &H14800401802800UL,
        &H2080040080800200UL,
        &H124080204001001UL,
        &H200046502000484UL,
        &H480400080088020UL,
        &H1000422010034000UL,
        &H30200100110040UL,
        &H100021010009UL,
        &H2002080100110004UL,
        &H202008004008002UL,
        &H20020004010100UL,
        &H2048440040820001UL,
        &H101002200408200UL,
        &H40802000401080UL,
        &H4008142004410100UL,
        &H2060820C0120200UL,
        &H1001004080100UL,
        &H20C020080040080UL,
        &H2935610830022400UL,
        &H44440041009200UL,
        &H280001040802101UL,
        &H2100190040002085UL,
        &H80C0084100102001UL,
        &H4024081001000421UL,
        &H20030A0244872UL,
        &H12001008414402UL,
        &H2006104900A0804UL,
        &H1004081002402UL}

    Dim BishopMagicNumbers() As ULong = {
        &H40040844404084UL,
        &H2004208A004208UL,
        &H10190041080202UL,
        &H108060845042010UL,
        &H581104180800210UL,
        &H2112080446200010UL,
        &H1080820820060210UL,
        &H3C0808410220200UL,
        &H4050404440404UL,
        &H21001420088UL,
        &H24D0080801082102UL,
        &H1020A0A020400UL,
        &H40308200402UL,
        &H4011002100800UL,
        &H401484104104005UL,
        &H801010402020200UL,
        &H400210C3880100UL,
        &H404022024108200UL,
        &H810018200204102UL,
        &H4002801A02003UL,
        &H85040820080400UL,
        &H810102C808880400UL,
        &HE900410884800UL,
        &H8002020480840102UL,
        &H220200865090201UL,
        &H2010100A02021202UL,
        &H152048408022401UL,
        &H20080002081110UL,
        &H4001001021004000UL,
        &H800040400A011002UL,
        &HE4004081011002UL,
        &H1C004001012080UL,
        &H8004200962A00220UL,
        &H8422100208500202UL,
        &H2000402200300C08UL,
        &H8646020080080080UL,
        &H80020A0200100808UL,
        &H2010004880111000UL,
        &H623000A080011400UL,
        &H42008C0340209202UL,
        &H209188240001000UL,
        &H400408A884001800UL,
        &H110400A6080400UL,
        &H1840060A44020800UL,
        &H90080104000041UL,
        &H201011000808101UL,
        &H1A2208080504F080UL,
        &H8012020600211212UL,
        &H500861011240000UL,
        &H180806108200800UL,
        &H4000020E01040044UL,
        &H300000261044000AUL,
        &H802241102020002UL,
        &H20906061210001UL,
        &H5A84841004010310UL,
        &H4010801011C04UL,
        &HA010109502200UL,
        &H4A02012000UL,
        &H500201010098B028UL,
        &H8040002811040900UL,
        &H28000010020204UL,
        &H6000020202D0240UL,
        &H8918844842082200UL,
        &H4010011029020020UL}

    Enum Piece
        Empty = 0

        WhitePawn = 1
        WhiteKnight = 2
        WhiteBishop = 3
        WhiteRook = 4
        WhiteQueen = 5
        WhiteKing = 6

        BlackPawn = 7
        BlackKnight = 8
        BlackBishop = 9
        BlackRook = 10
        BlackQueen = 11
        BlackKing = 12
    End Enum

    Enum BitboardOccupancies
        AllWhitePieces = 0
        AllBlackPieces = 1
        AllPieces = 2
    End Enum

    Enum CurrentSide
        White = True
        Black = False
    End Enum

    Enum RookBishop
        Rook = 0
        Bishop = 1
    End Enum

    Const De_Bruijn As ULong = &H22FDD63CC95386DUL
    Dim INDEX_LOOKUP_64() As Integer = {0, 1, 2, 53, 3, 7, 54, 27, 4, 38, 41, 8, 34, 55, 48, 28, 62, 5, 39, 46, 44, 42, 22, 9, 24, 35, 59, 56, 49, 18, 29, 11, 63, 52, 6, 26, 37, 40, 33, 47, 61, 45, 43, 21, 23, 58, 17, 10, 51, 25, 36, 32, 60, 20, 57, 16, 50, 31, 19, 15, 30, 14, 13, 12}

    Dim Bitboards() As ULong = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Dim Occupancies() As ULong = {0, 0, 0}

    Dim OneUL As ULong = 1UL
    Dim ZeroUL As ULong = 0UL

    Dim CurrentValidMoves As ULong

    Dim CurrentSquare As Integer = -1
    Dim SideToMove As Boolean = CurrentSide.Black

    Dim WhitePawnPushes() As ULong = StaticPieceGeneration.GenerateWhitePawnPushes
    Dim BlackPawnPushes() As ULong = StaticPieceGeneration.GenerateBlackPawnPushes

    Dim PawnAttacks(1, 63) As ULong

    Dim KnightMoves() As ULong = StaticPieceGeneration.GenerateKnightMoves()

    Public MaskedBishopMoves() As ULong = SlidingPieceGeneration.GenerateMaskBishopAttacks()
    Public MaskedRookMoves() As ULong = SlidingPieceGeneration.GenerateMaskRookAttacks()

    Dim KingMoves() As ULong = StaticPieceGeneration.GenerateKingMoves()

    Dim BishopRelevantBits() As Integer = {
        6, 5, 5, 5, 5, 5, 5, 6,
        5, 5, 5, 5, 5, 5, 5, 5,
        5, 5, 7, 7, 7, 7, 5, 5,
        5, 5, 7, 9, 9, 7, 5, 5,
        5, 5, 7, 9, 9, 7, 5, 5,
        5, 5, 7, 7, 7, 7, 5, 5,
        5, 5, 5, 5, 5, 5, 5, 5,
        6, 5, 5, 5, 5, 5, 5, 6}

    Dim RookRelevantBits() As Integer = {
        12, 11, 11, 11, 11, 11, 11, 12,
        11, 10, 10, 10, 10, 10, 10, 11,
        11, 10, 10, 10, 10, 10, 10, 11,
        11, 10, 10, 10, 10, 10, 10, 11,
        11, 10, 10, 10, 10, 10, 10, 11,
        11, 10, 10, 10, 10, 10, 10, 11,
        11, 10, 10, 10, 10, 10, 10, 11,
        12, 11, 11, 11, 11, 11, 11, 12}

    Dim BishopAttacks(63, 511) As ULong
    Dim RookAttacks(63, 4095) As ULong

    'castling rights
    Enum CastlingRights
        wk = 1
        wq = 2
        bk = 4
        bq = 8
    End Enum

    Dim CastlingRightsTable() As Integer = {
        13, 15, 15, 15, 12, 15, 15, 14,
        15, 15, 15, 15, 15, 15, 15, 15,
        15, 15, 15, 15, 15, 15, 15, 15,
        15, 15, 15, 15, 15, 15, 15, 15,
        15, 15, 15, 15, 15, 15, 15, 15,
        15, 15, 15, 15, 15, 15, 15, 15,
        15, 15, 15, 15, 15, 15, 15, 15,
        7, 15, 15, 15, 3, 15, 15, 11
    }

    Dim castle As Byte = 0
    Dim enpassant As Integer = 0

    Const defaultPosition As String = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
    Const whiteOPPosition As String = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/QNBQKBNQ w KQkq - 0 1"
    Const trickyPosition As String = "r3k2r/p1ppqpb1/bn2pnp1/3PN3/1p2P3/2N2Q1p/PPPBBPPP/R3K2R w KQkq - 0 1"
    Const emptyBoard As String = "8/8/8/8/8/8/8/8 w KQkq - 0 1"
    Const cmkPosition As String = "r2q1rk1/ppp2ppp/2n1bn2/2b1p3/3pP3/3P1NPP/PPP1NPB1/R1BQ1RK1 b - - 0 9 "

    Enum PromotionPieces
        Queen = 1
        Rook = 2
        Bishop = 3
        Knight = 4
    End Enum

    Dim promotePiece As Integer = PromotionPieces.Queen

    Dim materialScore() As Integer = {0, 100, 300, 350, 500, 1000, 10000, -100, -300, -350, -500, -1000, -10000}

    '// Pawn Positional scores
    Dim pawnScore() As Integer = {
        0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, -10, -10, 0, 0, 0,
        0, 0, 0, 5, 5, 0, 0, 0,
        5, 5, 10, 20, 20, 5, 5, 5,
        10, 10, 10, 20, 20, 10, 10, 10,
        20, 20, 20, 30, 30, 30, 20, 20,
        30, 30, 30, 40, 40, 30, 30, 30,
        90, 90, 90, 90, 90, 90, 90, 90}

    '// Knight Positional scores
    Dim knightScore() As Integer = {
        -5, -10, 0, 0, 0, 0, -10, -5,
        -5, 0, 0, 0, 0, 0, 0, -5,
        -5, 5, 20, 10, 10, 20, 5, -5,
        -5, 10, 20, 30, 30, 20, 10, -5,
        -5, 10, 20, 30, 30, 20, 10, -5,
        -5, 5, 20, 20, 20, 20, 5, -5,
        -5, 0, 0, 10, 10, 0, 0, -5,
        -5, 0, 0, 0, 0, 0, 0, -5}

    '// Bishop Positional scores
    Dim bishopScore() As Integer = {
        0, 0, -10, 0, 0, -10, 0, 0,
        0, 30, 0, 0, 0, 0, 30, 0,
        0, 10, 0, 0, 0, 0, 10, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        0, 0, 0, 10, 10, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0}

    '// Rook Positional scores
    Dim rookScore() As Integer = {
        0, 0, 0, 20, 20, 0, 0, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        0, 0, 10, 20, 20, 10, 0, 0,
        50, 50, 50, 50, 50, 50, 50, 50,
        50, 50, 50, 50, 50, 50, 50, 50}

    '// King Positional scores
    Dim kingScore() As Integer = {
        0, 0, 5, 0, -15, 0, 10, 0,
        0, 5, 5, -5, -5, 0, 5, 0,
        0, 0, 5, 10, 10, 5, 0, 0,
        0, 5, 10, 20, 20, 10, 5, 0,
        0, 5, 10, 20, 20, 10, 5, 0,
        0, 5, 5, 10, 10, 5, 5, 0,
        0, 0, 5, 5, 5, 5, 0, 0,
        0, 0, 0, 0, 0, 0, 0, 0}

    '// Mirror Positional score tables for opposite sides
    Dim mirrorScore() As Integer = {
    56, 57, 58, 59, 60, 61, 62, 63,
    48, 49, 50, 51, 52, 53, 54, 55,
    40, 41, 42, 43, 44, 45, 46, 47,
    32, 33, 34, 35, 36, 37, 38, 39,
    24, 25, 26, 27, 28, 29, 30, 31,
    16, 17, 18, 19, 20, 21, 22, 23,
     8, 9, 10, 11, 12, 13, 14, 15,
     0, 1, 2, 3, 4, 5, 6, 7
    }

    '// MVV LVA [attacker][victim]
    Dim mvvlva(,) As Integer = {
    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
    {0, 105, 205, 305, 405, 505, 605, 105, 205, 305, 405, 505, 605},
    {0, 104, 204, 304, 404, 504, 604, 104, 204, 304, 404, 504, 604},
    {0, 103, 203, 303, 403, 503, 603, 103, 203, 303, 403, 503, 603},
    {0, 102, 202, 302, 402, 502, 602, 102, 202, 302, 402, 502, 602},
    {0, 101, 201, 301, 401, 501, 601, 101, 201, 301, 401, 501, 601},
    {0, 100, 200, 300, 400, 500, 600, 100, 200, 300, 400, 500, 600},
    {0, 105, 205, 305, 405, 505, 605, 105, 205, 305, 405, 505, 605},
    {0, 104, 204, 304, 404, 504, 604, 104, 204, 304, 404, 504, 604},
    {0, 103, 203, 303, 403, 503, 603, 103, 203, 303, 403, 503, 603},
    {0, 102, 202, 302, 402, 502, 602, 102, 202, 302, 402, 502, 602},
    {0, 101, 201, 301, 401, 501, 601, 101, 201, 301, 401, 501, 601},
    {0, 100, 200, 300, 400, 500, 600, 100, 200, 300, 400, 500, 600}}

    Const maxPly = 63

    Const mateValue = 49000
    Const mateScore = 48000

    '// Killer moves [id][ply]
    Dim killerMoves(1, maxPly) As Integer

    '// History moves [piece][square]
    Dim historyMoves(12, 63) As Integer

    Dim searchDepth As Integer = 6

    Dim BoardHistory(0) As BoardState
    Dim CurrentBoardState As Integer = 0

    Dim repetitionTable(150) As ULong
    Dim repetitionIndex As Integer = 0

    Private Sub PromotionBoxClicked(ByVal sender As Object, ByVal e As EventArgs)
        Dim BoxClicked As PictureBox = CType(sender, PictureBox)
        promotePiece = BoxClicked.Tag

        QueenPromotion.BackColor = Color.FromArgb(160, 160, 160)
        RookPromotion.BackColor = Color.FromArgb(160, 160, 160)
        BishopPromotion.BackColor = Color.FromArgb(160, 160, 160)
        KnightPromotion.BackColor = Color.FromArgb(160, 160, 160)

        BoxClicked.BackColor = Color.FromArgb(72, 187, 120)
    End Sub
    Private Sub InitialisePromotionBoxes()
        AddHandler QueenPromotion.Click, AddressOf PromotionBoxClicked
        AddHandler RookPromotion.Click, AddressOf PromotionBoxClicked
        AddHandler BishopPromotion.Click, AddressOf PromotionBoxClicked
        AddHandler KnightPromotion.Click, AddressOf PromotionBoxClicked
    End Sub

    Sub DisplayPieces()
        For looper = 1 To 12
            Dim bitboard As ULong = Bitboards(looper)
            Do While bitboard
                Dim lsb As Integer = GetlsbIndex(bitboard)
                Dim currentPictureBox As PictureBox = Me.Controls.Find("Square_" & lsb, False)(0)

                Select Case looper
                    Case Piece.WhitePawn
                        currentPictureBox.Image = My.Resources.wp
                    Case Piece.WhiteKnight
                        currentPictureBox.Image = My.Resources.wn
                    Case Piece.WhiteBishop
                        currentPictureBox.Image = My.Resources.wb
                    Case Piece.WhiteRook
                        currentPictureBox.Image = My.Resources.wr
                    Case Piece.WhiteQueen
                        currentPictureBox.Image = My.Resources.wq
                    Case Piece.WhiteKing
                        currentPictureBox.Image = My.Resources.wk

                    Case Piece.BlackPawn
                        currentPictureBox.Image = My.Resources.bp
                    Case Piece.BlackKnight
                        currentPictureBox.Image = My.Resources.bn
                    Case Piece.BlackBishop
                        currentPictureBox.Image = My.Resources.bb
                    Case Piece.BlackRook
                        currentPictureBox.Image = My.Resources.br
                    Case Piece.BlackQueen
                        currentPictureBox.Image = My.Resources.bq
                    Case Piece.BlackKing
                        currentPictureBox.Image = My.Resources.bk
                End Select

                bitboard = bitboard Xor (1UL << lsb) 'pop bit
            Loop
        Next

        Dim EmptySpots As ULong = Not Occupancies(BitboardOccupancies.AllPieces)
        While EmptySpots
            Dim lsb As Integer = GetlsbIndex(EmptySpots)
            CType(Me.Controls.Find("Square_" & lsb, False)(0), PictureBox).Image = Nothing

            EmptySpots = EmptySpots Xor (1UL << lsb)
        End While

        Console.WriteLine("Side To Move: " & SideToMove)
        Console.WriteLine("Enpassant: " & enpassant)
        Console.WriteLine("Castle: " & If(CastlingRights.wk And castle, "K", "-") & If(CastlingRights.wq And castle, "Q", "-") & If(CastlingRights.bk And castle, "k", "-") & If(CastlingRights.bq And castle, "q", "-"))
    End Sub
    Sub InitialisePieces(ByVal FEN)
        Array.Clear(Bitboards, 0, Bitboards.Length)
        Array.Clear(Occupancies, 0, Occupancies.Length)

        Dim CurrentSquareIndex As Integer = 56
        For looper = 0 To FEN.Length - 1
            Dim currentSquare As PictureBox
            Try
                If CurrentSquareIndex < 64 Then
                    currentSquare = Me.Controls.Find("Square_" & CurrentSquareIndex, False)(0)
                End If
            Catch ex As Exception
                MsgBox(ex)
            End Try

            Select Case FEN(looper)
                Case " "
                    If FEN(looper + 1) = "w" Then
                        SideToMove = CurrentSide.White
                    ElseIf FEN(looper + 1) = "b" Then
                        SideToMove = CurrentSide.Black
                    End If

                    Dim currentCastleRights As Char
                    Dim castleLooper As Integer = 0
                    While currentCastleRights <> " "
                        currentCastleRights = FEN(looper + 3 + castleLooper)

                        Select Case currentCastleRights
                            Case "k"
                                castle += CastlingRights.bk
                            Case "K"
                                castle += CastlingRights.wk
                            Case "q"
                                castle += CastlingRights.bq
                            Case "Q"
                                castle += CastlingRights.wq
                            Case "-"
                                Exit While
                        End Select

                        castleLooper += 1
                    End While

                    If FEN(looper + 3 + castleLooper) = "-" Then
                        enpassant = 64
                    Else
                        'a1
                        Dim file, rank As Integer
                        file = Asc(FEN(looper + 3 + castleLooper)) - 97 '97
                        rank = Asc(FEN(looper + 4 + castleLooper)) - 49 '49
                        enpassant = (rank * 8) + file
                    End If


                    Exit For
                Case "/"
                    CurrentSquareIndex -= 16
                Case "1" To "8"
                    CurrentSquareIndex += Val(FEN(looper))

                Case "r"
                    Bitboards(Piece.BlackRook) = Bitboards(Piece.BlackRook) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "n"
                    Bitboards(Piece.BlackKnight) = Bitboards(Piece.BlackKnight) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "b"
                    Bitboards(Piece.BlackBishop) = Bitboards(Piece.BlackBishop) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "q"
                    Bitboards(Piece.BlackQueen) = Bitboards(Piece.BlackQueen) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "k"
                    Bitboards(Piece.BlackKing) = Bitboards(Piece.BlackKing) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "p"
                    Bitboards(Piece.BlackPawn) = Bitboards(Piece.BlackPawn) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1


                Case "R"
                    Bitboards(Piece.WhiteRook) = Bitboards(Piece.WhiteRook) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "N"
                    Bitboards(Piece.WhiteKnight) = Bitboards(Piece.WhiteKnight) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "B"
                    Bitboards(Piece.WhiteBishop) = Bitboards(Piece.WhiteBishop) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "Q"
                    Bitboards(Piece.WhiteQueen) = Bitboards(Piece.WhiteQueen) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "K"
                    Bitboards(Piece.WhiteKing) = Bitboards(Piece.WhiteKing) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
                Case "P"
                    Bitboards(Piece.WhitePawn) = Bitboards(Piece.WhitePawn) Or (OneUL << CurrentSquareIndex)
                    CurrentSquareIndex += 1
            End Select
        Next



        Occupancies(BitboardOccupancies.AllWhitePieces) = Bitboards(Piece.WhitePawn) Or Bitboards(Piece.WhiteKnight) Or Bitboards(Piece.WhiteBishop) Or Bitboards(Piece.WhiteRook) Or Bitboards(Piece.WhiteQueen) Or Bitboards(Piece.WhiteKing)
        Occupancies(BitboardOccupancies.AllBlackPieces) = Bitboards(Piece.BlackPawn) Or Bitboards(Piece.BlackKnight) Or Bitboards(Piece.BlackBishop) Or Bitboards(Piece.BlackRook) Or Bitboards(Piece.BlackQueen) Or Bitboards(Piece.BlackKing)
        Occupancies(BitboardOccupancies.AllPieces) = Occupancies(BitboardOccupancies.AllWhitePieces) Or Occupancies(BitboardOccupancies.AllBlackPieces)
    End Sub
    Sub DrawBoard()
        For row = 0 To 7
            For column = 0 To 7
                Dim bitboardIndex As Integer = (row * 8) + column

                Dim pictureBox As New PictureBox
                pictureBox.Size = New Size(100, 100)
                pictureBox.Location = New Point(column * 100 + 35, (7 - row) * 100 + 25)

                pictureBox.Name = "Square_" & bitboardIndex
                pictureBox.Tag = bitboardIndex

                pictureBox.SizeMode = PictureBoxSizeMode.Zoom

                Dim isLight As Boolean = Not ((row + column) Mod 2 = 0)
                pictureBox.BackColor = If(isLight, Color.FromArgb(240, 217, 181), Color.FromArgb(181, 136, 99))

                Me.Controls.Add(pictureBox)

                AddHandler pictureBox.MouseDown, AddressOf Square_Click
            Next
        Next
    End Sub

    Function SetOccupancy(ByVal index As Integer, ByVal bits_in_mask As Integer, ByVal attack_mask As ULong) As ULong
        'index is the number that is made if you imagine
        ' the pieces as a binary number

        Dim occupancy As ULong = 0UL

        For i = 0 To bits_in_mask - 1 'loops the amount of times of the squares it can move to, so it covers every possible blocker location
            Dim square As Integer = GetlsbIndex(attack_mask) 'finds the lsb of places it can attack

            attack_mask = attack_mask Xor (1UL << square) 'removes the lsb

            If index And (1UL << i) Then 'if that specific bit is on in the index, then add occupancy, there, which is essentially turning the binary index into a set of piece locations
                occupancy = occupancy Or (1UL << square)
            End If
        Next

        Return occupancy
    End Function

    Function GetlsbIndex(ByVal Bitboard As ULong)
        If Bitboard = 0 Then
            Return -1
        Else
            Dim lsb As ULong = Bitboard And ((Not Bitboard) + OneUL)
            Dim Product As ULong = lsb * De_Bruijn
            Dim IndexKey As ULong = Product >> 58
            Dim Result As Byte = INDEX_LOOKUP_64(IndexKey)

            Return Result
        End If
    End Function
    Function CountBits(ByVal Bitboard As ULong)
        Dim counter As Integer = 0

        While Bitboard > 0
            Dim lsb As ULong = Bitboard And ((Not Bitboard) + OneUL)
            Bitboard = Bitboard And Bitboard - OneUL
            counter += 1
        End While

        Return counter
    End Function

    Sub DisplayULong(ByVal ULongToDisplay)
        Dim SquaresToShow As New List(Of PictureBox)

        While ULongToDisplay > 0
            'de bruijn method:

            Dim lsb As ULong = ULongToDisplay And ((Not ULongToDisplay) + OneUL)
            Dim Product As ULong = lsb * De_Bruijn
            Dim IndexKey As ULong = Product >> 58
            Dim Result As Byte = INDEX_LOOKUP_64(IndexKey)

            SquaresToShow.Add(Me.Controls.Find("Square_" & Result, False)(0))

            ULongToDisplay = ULongToDisplay And ULongToDisplay - OneUL
        End While

        Me.SuspendLayout()

        For Each square In SquaresToShow
            If square.BackColor = Color.FromArgb(240, 217, 181) Then
                square.BackColor = Color.FromArgb(160, 200, 245)
            Else
                square.BackColor = Color.FromArgb(112, 165, 216)
            End If

        Next

        Me.ResumeLayout(True)
    End Sub
    Sub DisplayMove(ByVal CurrentMove As Integer)
        Dim StartSquare As PictureBox = Me.Controls.Find("Square_" & GetMoveSource(CurrentMove), False)(0)
        Dim EndSquare As PictureBox = Me.Controls.Find("Square_" & GetMoveTarget(CurrentMove), False)(0)

        EndSquare.Image = StartSquare.Image
        StartSquare.Image = Nothing

        '// Update for Capture
        If GetMovePromoted(CurrentMove) Then
            My.Computer.Audio.Play("D:\\Promote.wav")
        ElseIf GetMoveCapture(CurrentMove) Then
            My.Computer.Audio.Play("D:\\Capture.wav")
        ElseIf GetMoveCastling(CurrentMove) Then
            My.Computer.Audio.Play("D:\\Castle.wav")
        ElseIf IsSquareAttacked(If(SideToMove, GetlsbIndex(Bitboards(Piece.WhiteKing)), GetlsbIndex(Bitboards(Piece.BlackKing))), Not SideToMove) Then
            My.Computer.Audio.Play("D:\\Check.wav")
        Else
            My.Computer.Audio.Play("D:\\PieceMove.wav")
        End If

        '// Update for a promotion
        If GetMovePromoted(CurrentMove) Then
            StartSquare.Image = Nothing

            Select Case GetMovePromoted(CurrentMove)
                Case Piece.WhiteKnight
                    EndSquare.Image = My.Resources.wn
                Case Piece.WhiteBishop
                    EndSquare.Image = My.Resources.wb
                Case Piece.WhiteRook
                    EndSquare.Image = My.Resources.wr
                Case Piece.WhiteQueen
                    EndSquare.Image = My.Resources.wq

                Case Piece.BlackKnight
                    EndSquare.Image = My.Resources.bn
                Case Piece.BlackBishop
                    EndSquare.Image = My.Resources.bb
                Case Piece.BlackRook
                    EndSquare.Image = My.Resources.br
                Case Piece.BlackQueen
                    EndSquare.Image = My.Resources.bq
            End Select
        End If

        '// Check for enpassant
        If GetMoveEnpassant(CurrentMove) Then
            If GetMovePiece(CurrentMove) <= 6 Then
                CType(Me.Controls.Find("Square_" & GetMoveTarget(CurrentMove) - 8, False)(0), PictureBox).Image = Nothing
            Else
                CType(Me.Controls.Find("Square_" & GetMoveTarget(CurrentMove) + 8, False)(0), PictureBox).Image = Nothing
            End If
        End If

        '// Check for castling
        If GetMoveCastling(CurrentMove) Then
            Select Case GetMoveTarget(CurrentMove)
                Case 6
                    'wk
                    CType(Me.Controls.Find("Square_7", False)(0), PictureBox).Image = Nothing
                    CType(Me.Controls.Find("Square_5", False)(0), PictureBox).Image = My.Resources.wr
                Case 2
                    'wq
                    CType(Me.Controls.Find("Square_0", False)(0), PictureBox).Image = Nothing
                    CType(Me.Controls.Find("Square_3", False)(0), PictureBox).Image = My.Resources.wr
                Case 62
                    'bk
                    CType(Me.Controls.Find("Square_63", False)(0), PictureBox).Image = Nothing
                    CType(Me.Controls.Find("Square_61", False)(0), PictureBox).Image = My.Resources.br
                Case 58
                    'bq
                    CType(Me.Controls.Find("Square_56", False)(0), PictureBox).Image = Nothing
                    CType(Me.Controls.Find("Square_59", False)(0), PictureBox).Image = My.Resources.br
            End Select
        End If
    End Sub
    Function GetValidMoves(ByVal square As Integer, ByVal movelist As MoveList)
        Dim validMoves As ULong = 0

        For looper = 0 To movelist.count - 1
            Dim move As Integer = movelist.moves(looper)
            Dim sourceSquare As Integer = GetMoveSource(move)
            Dim targetSquare As Integer = GetMoveTarget(move)

            If square = sourceSquare Then 'move from the piece we clicked on
                'make sure it is legal, as the list of moves is only pseudo-legal
                Dim savedBoardState As BoardState = CopyBoard()
                If MakeMove(move, MoveTypes.allMoves) Then
                    validMoves = validMoves Or (1UL << targetSquare)
                    TakeBack(savedBoardState)
                End If
            End If
        Next

        Return validMoves
    End Function

    Private Function GetLegalMove(ByVal squareIndex As Integer)
        Dim CurrentMoveList As MoveList
        GenerateMoves(CurrentMoveList)

        Dim sourceSquare As Integer = CurrentSquare
        Dim targetSquare As Integer = squareIndex

        For looper = 0 To CurrentMoveList.count - 1
            Dim move As Integer = CurrentMoveList.moves(looper)

            If sourceSquare = GetMoveSource(move) And targetSquare = GetMoveTarget(move) Then
                If GetMovePromoted(move) Then

                    If (GetMovePromoted(move) = Piece.WhiteQueen Or GetMovePromoted(move) = Piece.BlackQueen) And promotePiece = PromotionPieces.Queen Then
                        Return move
                    ElseIf (GetMovePromoted(move) = Piece.WhiteRook Or GetMovePromoted(move) = Piece.BlackRook) And promotePiece = PromotionPieces.Rook Then
                        Return move
                    ElseIf (GetMovePromoted(move) = Piece.WhiteBishop Or GetMovePromoted(move) = Piece.BlackBishop) And promotePiece = PromotionPieces.Bishop Then
                        Return move
                    ElseIf (GetMovePromoted(move) = Piece.WhiteKnight Or GetMovePromoted(move) = Piece.BlackKnight) And promotePiece = PromotionPieces.Knight Then
                        Return move
                    End If
                Else
                    Return move
                End If
            End If
        Next

        'return illegal move
        Return 0
    End Function
    Private Sub Square_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        'exit if not left click
        If e.Button <> Windows.Forms.MouseButtons.Left Then
            Exit Sub
        End If

        If CurrentBoardState <> BoardHistory.Length - 1 Then
            Exit Sub
        End If

        'gets the square which was clicked, and the index of it
        Dim clickedSquare As PictureBox = CType(sender, PictureBox)
        Dim previousSquare As PictureBox = Nothing
        Dim squareIndex As Integer = CInt(clickedSquare.Tag)

        'sets all the squares back to their original colours
        For looper = 0 To 63
            Dim isLight As Boolean = Not (((Int(looper / 8)) + (looper Mod 8)) Mod 2 = 0)
            Me.Controls.Find("Square_" & looper, False)(0).BackColor = If(isLight, Color.FromArgb(240, 217, 181), Color.FromArgb(181, 136, 99))
        Next

        'if a square was clicked before, then it sets previous square to that one
        If CurrentSquare <> -1 Then
            previousSquare = Me.Controls.Find("Square_" & CurrentSquare, False)(0)
        End If

        If squareIndex = CurrentSquare Then
            '// Same thing clicked so deselect
            CurrentSquare = -1
        Else
            '// Clicked a different square

            '/ If they clicked a square which has their own piece, show the moves for that piece, otherwise check if it is a legal move and make the move if so
            If ((1UL << squareIndex) And (If(SideToMove, Occupancies(BitboardOccupancies.AllWhitePieces), Occupancies(BitboardOccupancies.AllBlackPieces)))) Then
                '/ Generates and displays all pseudo-legal moves for the piece selected
                Dim ValidMoves As ULong
                Dim CurrentMoveList As MoveList

                GenerateMoves(CurrentMoveList)
                ValidMoves = GetValidMoves(squareIndex, CurrentMoveList)

                DisplayULong(ValidMoves)

                CurrentSquare = squareIndex
            Else
                '/ Check if it is a legal move

                Dim move As Integer = GetLegalMove(squareIndex) 'returns the move if pseudo-legal, otherwise returns 0

                'checks if it is pseudo-legal
                If move Then
                    'move is pseudo legal
                    If MakeMove(move, MoveTypes.allMoves) Then
                        DisplayMove(move)
                        Me.Refresh()
                        ReDim Preserve BoardHistory(BoardHistory.Length)
                        BoardHistory(BoardHistory.Length - 1) = CopyBoard()
                        CurrentBoardState += 1

                        CheckForCheckmate()

                        Dim computermove As Integer = SearchPosition(searchDepth)
                        MakeMove(computermove, MoveTypes.allMoves)
                        DisplayMove(computermove)

                        ReDim Preserve BoardHistory(BoardHistory.Length)
                        BoardHistory(BoardHistory.Length - 1) = CopyBoard()
                        CurrentBoardState += 1

                        CheckForCheckmate()
                    End If
                Else
                    Console.WriteLine("Move is not pseudo legal")
                End If

                CurrentSquare = -1
            End If

        End If


    End Sub
    Private Sub CheckForCheckmate()
        Dim inCheck As Boolean = IsSquareAttacked(If(SideToMove, GetlsbIndex(Bitboards(Piece.WhiteKing)), GetlsbIndex(Bitboards(Piece.BlackKing))), Not SideToMove)
        Dim legalMoves As Integer = 0

        Dim movelist As MoveList
        GenerateMoves(movelist)

        For looper = 0 To movelist.count - 1
            Dim savedBoardState As BoardState = CopyBoard()
            If MakeMove(movelist.moves(looper), MoveTypes.allMoves) Then
                legalMoves += 1
                TakeBack(savedBoardState)
                Exit For
            End If
        Next

        If inCheck And legalMoves = 0 Then
            My.Computer.Audio.Play("D:\\GameEnd.wav")
            MsgBox("Checkmate: " & If(SideToMove, "Black wins", "White wins"))
            End
        ElseIf inCheck And legalMoves <> 0 Then
            'MsgBox("Check")
        ElseIf Not inCheck And legalMoves = 0 Then
            MsgBox("Stalemate")
            End
        End If
    End Sub

    '//Undo and redo moves
    Private Sub UndoRedoMove(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Left Then
            If CurrentBoardState = 0 Then Exit Sub
            CurrentBoardState -= 1
            TakeBack(BoardHistory(CurrentBoardState))
            Me.Refresh()
            DisplayPieces()
            Me.Refresh()
        ElseIf e.KeyCode = Keys.Right Then
            If CurrentBoardState = BoardHistory.Length - 1 Then Exit Sub
            CurrentBoardState += 1
            TakeBack(BoardHistory(CurrentBoardState))
            Me.Refresh()
            DisplayPieces()
            Me.Refresh()
        End If
    End Sub

    '/***********************\
    '    Computer Functions
    '\***********************/

    'PV Length (ply)
    Dim pvLength(maxPly) As Integer

    'PV Table (ply)(ply)
    Dim pvTable(maxPly, maxPly) As Integer

    'follow PV and score PV move
    Dim followPv, scorePv As Integer

    '// Search Position for best move
    Dim ply As Integer

    '/***********************\
    '  Transposition Table
    '\***********************/

    Const noHashEntry As Integer = 200000000
    Const hashSize As Integer = &H400000
    Dim hashTable(hashSize - 1) As tt

    Enum HashFlags
        Exact = 0
        Alpha = 1
        Beta = 2
    End Enum
    Structure tt
        Dim hashKey As ULong
        Dim depth As Integer
        Dim flag As Integer
        Dim score As Integer
    End Structure

    Sub ClearHashTable()
        For looper = 0 To hashTable.Length - 1
            hashTable(looper).hashKey = 0
            hashTable(looper).depth = 0
            hashTable(looper).flag = 0
            hashTable(looper).score = 0
        Next
    End Sub
    Function readHashEntry(ByVal alpha As Integer, ByVal beta As Integer, ByVal depth As Integer) As Integer
        'create a tt instance pointer to paticular hash entry storing the scoring data for the current board position if available
        Dim hashEntry As tt = hashTable(hashKey Mod hashSize)

        'make sure we're dealing with the exact position we need
        If hashEntry.hashKey = hashKey Then
            'make sure it matches the depth our search is now at
            If hashEntry.depth >= depth Then

                Dim score As Integer = hashEntry.score
                If score < -mateScore Then score += ply
                If score > mateScore Then score -= ply

                If hashEntry.flag = HashFlags.Exact Then
                    Return score
                End If

                If hashEntry.flag = HashFlags.Alpha And hashEntry.score <= alpha Then
                    Return alpha
                End If

                If hashEntry.flag = HashFlags.Beta And hashEntry.score >= beta Then
                    Return beta
                End If

            End If
        End If

        Return noHashEntry
    End Function
    Sub writeHashEntry(ByVal score As Integer, ByVal depth As Integer, ByVal hashFlag As Integer)
        'get the index of the specific hash entry
        Dim index As Integer = hashKey Mod hashSize

        If score < -mateScore Then score -= ply
        If score > mateScore Then score += ply

        'write hash entry data
        hashTable(index).hashKey = hashKey
        hashTable(index).score = score
        hashTable(index).flag = hashFlag
        hashTable(index).depth = depth
    End Sub

    '/***********************\
    '       Score Move
    '\***********************/

    '// Score Move Functions
    Private Function ScoreMove(ByVal move As Integer)
        If scorePv Then
            'make sure we are dealing with pv
            If pvTable(0, ply) = move Then
                'disable score pv flag
                scorePv = 0

                'give pv move the highest score to search it first
                Return 20000
            End If
        End If

        If GetMoveCapture(move) Then
            Dim targetPiece As Integer = Piece.WhitePawn
            Dim targetSquare As Integer = GetMoveTarget(move)

            Dim startPiece, endPiece As Integer

            If SideToMove = CurrentSide.White Then : startPiece = Piece.BlackPawn : endPiece = Piece.BlackKing
            Else : startPiece = Piece.WhitePawn : endPiece = Piece.WhiteKing : End If

            For bbPiece = startPiece To endPiece
                If (Bitboards(bbPiece) And (1UL << targetSquare)) <> 0UL Then
                    targetPiece = bbPiece
                    Exit For
                End If
            Next

            Return mvvlva(GetMovePiece(move), targetPiece) + 10000
        Else
            'score quiet move

            If killerMoves(0, ply) = move Then 'score 1st killer move
                Return 9000
            ElseIf killerMoves(1, ply) = move Then 'score 2nd killer move
                Return 8000
            Else 'score history move
                Return historyMoves(GetMovePiece(move), GetMoveTarget(move))
            End If
        End If

        Return 0
    End Function
    Private Sub SortMoveScores(ByVal movelist As MoveList)

        Dim moveScores(movelist.count - 1) As Integer

        For looper = 0 To movelist.count - 1
            moveScores(looper) = ScoreMove(movelist.moves(looper))
        Next

        For repeats = 0 To movelist.count - 1
            For i = 0 To movelist.count - 2
                If moveScores(i) < moveScores(i + 1) Then
                    Dim tempmoveScore As Integer = moveScores(i + 1)
                    moveScores(i + 1) = moveScores(i)
                    moveScores(i) = tempmoveScore

                    Dim tempmove As Integer = movelist.moves(i + 1)
                    movelist.moves(i + 1) = movelist.moves(i)
                    movelist.moves(i) = tempmove
                End If
            Next
        Next
    End Sub
    Private Sub PrintMoveScores(ByVal movelist As MoveList)
        For looper = 0 To movelist.count - 1
            Dim move As Integer = movelist.moves(looper)

            Console.WriteLine("Move: " & IndexToCoordinate(GetMoveSource(move)) & IndexToCoordinate(GetMoveTarget(move)) & " Score: " & ScoreMove(move))
        Next
    End Sub
    Private Sub enablePvScoring(ByVal movelist As MoveList)
        'disable following pv
        followPv = 0

        'loop over moves in move list
        For looper = 0 To movelist.count - 1
            'make sure we hit pv move
            If pvTable(0, ply) = movelist.moves(looper) Then
                'enable move scoring
                scorePv = 1
                'enable following pv
                followPv = 1
            End If
        Next
    End Sub

    Const fullDepthMoves As Integer = 4
    Const reductionLimit As Integer = 3
    Const scoreWindow As Integer = 50

    Dim pieceKeys(12, 63) As ULong
    Dim enpassantKeys(63) As ULong
    Dim castleKeys(15) As ULong
    Dim sideKey As ULong

    Dim hashKey As ULong = GenerateHashKey()

    '// Initialise Random Hash Keys
    Private Sub InitialiseRandomKeys()
        PseudoRNG.State = 1804289383

        For currentPiece = Piece.WhitePawn To Piece.BlackKing
            For square = 0 To 63
                pieceKeys(currentPiece, square) = PseudoRNG.GetRandomU64Number
            Next
        Next

        For square = 0 To 63
            enpassantKeys(square) = PseudoRNG.GetRandomU64Number
        Next

        sideKey = PseudoRNG.GetRandomU64Number

        For index = 1 To 15
            castleKeys(index) = PseudoRNG.GetRandomU64Number
        Next
    End Sub
    Private Function GenerateHashKey()
        Dim FinalKey As ULong = 0UL
        Dim bitboard As ULong = 0UL

        For currentPiece = Piece.WhitePawn To Piece.BlackKing
            bitboard = Bitboards(currentPiece)

            While bitboard
                Dim lsb As Integer = GetlsbIndex(bitboard)
                FinalKey = (FinalKey Xor pieceKeys(currentPiece, lsb))

                bitboard = bitboard Xor (1UL << lsb)
            End While
        Next

        If enpassant <> 64 Then
            FinalKey = FinalKey Xor enpassantKeys(enpassant)
        End If

        FinalKey = FinalKey Xor castleKeys(castle)

        If SideToMove = CurrentSide.Black Then
            FinalKey = FinalKey Xor sideKey
        End If

        Return FinalKey
    End Function

    '// Move Search Functions
    Private Function isRepetition() As Boolean

        For looper = 0 To repetitionIndex
            If repetitionTable(looper) = hashKey Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Function Quiescence(ByVal alpha As Double, ByVal beta As Double)
        'evaulate position
        nodes += 1

        If ply > 0 And isRepetition() Then
            Return 0
        End If

        If ply > maxPly - 1 Then
            Return Evaluate()
        End If

        Dim evaluation As Integer = Evaluate()

        If evaluation >= beta Then
            Return beta
        End If

        'found a better move
        If evaluation > alpha Then
            alpha = evaluation
        End If

        Dim movelist As MoveList
        GenerateMoves(movelist)

        SortMoveScores(movelist)

        'loop over moves within a movelist
        For looper = 0 To movelist.count - 1
            'preserve board state and increment ply
            Dim savedBoardState As BoardState = CopyBoard()
            ply += 1

            repetitionTable(repetitionIndex) = hashKey
            repetitionIndex += 1

            'make sure to make only legal moves
            If MakeMove(movelist.moves(looper), MoveTypes.onlyCaptures) = 0 Then
                'decrement ply
                ply -= 1
                repetitionIndex -= 1
                'skip to next move
                Continue For
            End If

            'score the current move, the -beta and -alpha swap as the sides swap
            Dim score As Integer = -Quiescence(-beta, -alpha)

            ply -= 1
            repetitionIndex -= 1
            TakeBack(savedBoardState)

            'found a better move
            If score > alpha Then
                alpha = score

                'fail hard beta cutoff
                If score >= beta Then
                    Return beta
                End If
            End If
        Next

        Return alpha
    End Function
    Private Function negamax(ByVal alpha As Double, ByVal beta As Double, ByVal depth As Integer)
        Dim score As Integer = 0

        'define hash flag
        Dim hashFlag As Integer = HashFlags.Alpha

        Dim pvNode As Boolean = ((beta - alpha) > 1)

        score = readHashEntry(alpha, beta, depth)
        If score <> noHashEntry And (ply <> 0) And (pvNode = True) Then
            'move already searched, hence has a value, without searching it
            Return score
        End If

        'init pv length
        pvLength(ply) = ply

        'recursion escape condition
        If depth = 0 Then
            'run quiescence search
            Return Quiescence(alpha, beta)
        End If

        'too deep, hence overflow of arrays relying on max ply constant
        If (ply > (maxPly - 1)) Then
            Return Evaluate()
        End If

        nodes += 1

        Dim inCheck As Boolean = IsSquareAttacked(If(SideToMove, GetlsbIndex(Bitboards(Piece.WhiteKing)), GetlsbIndex(Bitboards(Piece.BlackKing))), Not SideToMove)
        Dim legalMoves As Integer = 0

        'increase search depth is king exposed to check
        If inCheck Then
            depth += 1
        End If

        If (depth >= 3) And (Not inCheck) And (ply > 0) Then
            Dim sbs As BoardState = CopyBoard()

            ply += 1

            repetitionTable(repetitionIndex) = hashKey
            repetitionIndex += 1

            If enpassant <> 64 Then
                hashKey = hashKey Xor enpassantKeys(enpassant)
            End If

            enpassant = 64

            hashKey = hashKey Xor sideKey
            SideToMove = Not SideToMove

            score = -negamax(-beta, -beta + 1, depth - 1 - 2)

            ply -= 1
            repetitionIndex -= 1

            TakeBack(sbs)

            If score >= beta Then
                Return beta
            End If
        End If

        'create movelist instance
        Dim movelist As MoveList
        GenerateMoves(movelist)

        'if we are now following pv line
        If followPv Then
            'enable pv more scoring
            enablePvScoring(movelist)
        End If

        SortMoveScores(movelist)

        Dim movesSearched As Integer = 0

        'loop over moves within a movelist
        For looper = 0 To movelist.count - 1
            'preserve board state and increment ply
            Dim savedBoardState As BoardState = CopyBoard()
            ply += 1

            repetitionTable(repetitionIndex) = hashKey
            repetitionIndex += 1

            'make sure to make only legal moves
            If MakeMove(movelist.moves(looper), MoveTypes.allMoves) = 0 Then
                'decrement ply and take move back
                ply -= 1
                repetitionIndex -= 1

                'skip to next move
                Continue For
            End If

            legalMoves += 1

            If movesSearched = 0 Then
                'do normal alpha beta search
                score = -negamax(-beta, -alpha, depth - 1)
            Else 'LMR (late move reduction)
                'condition to consider LMR (Late move reduction)
                If (movesSearched >= fullDepthMoves) And (depth >= reductionLimit) And (inCheck = False) And (GetMoveCapture(movelist.moves(looper)) = 0) And (GetMovePromoted(movelist.moves(looper)) = 0) Then
                    'search current move with reduced depth
                    score = -negamax(-alpha - 1, -alpha, depth - 2)
                Else
                    score = alpha + 1 'ensure full depth search is done
                End If

                'found a better move during lmr
                If score > alpha Then
                    're search at normal depth buit with narrowed aspiration window
                    score = -negamax(-alpha - 1, -alpha, depth - 1)

                    'if lmr fails research at full depth and full score bandwith
                    If (score > alpha) And (score < beta) Then
                        score = -negamax(-beta, -alpha, depth - 1)
                    End If
                End If
            End If

            ply -= 1
            repetitionIndex -= 1

            TakeBack(savedBoardState)

            movesSearched += 1

            'found a better move
            If score > alpha Then
                hashFlag = HashFlags.Exact

                'history move
                If GetMoveCapture(movelist.moves(looper)) = 0 Then
                    historyMoves(GetMovePiece(movelist.moves(looper)), GetMoveTarget(movelist.moves(looper))) += depth
                End If

                alpha = score

                'write pv move
                pvTable(ply, ply) = movelist.moves(looper)
                'copy move from deepler ply into a current ply's line
                'loop over the next ply
                For nextPly = ply + 1 To pvLength(ply + 1)
                    pvTable(ply, nextPly) = pvTable(ply + 1, nextPly)
                Next

                'adjust pv length
                pvLength(ply) = pvLength(ply + 1)

                'fail hard beta cutoff
                If score >= beta Then
                    writeHashEntry(beta, depth, HashFlags.Beta)

                    'on quiet moves
                    If GetMoveCapture(movelist.moves(looper)) = 0 Then
                        killerMoves(1, ply) = killerMoves(0, ply)
                        killerMoves(0, ply) = movelist.moves(looper)
                    End If
                    'store killer moves


                    Return beta
                End If
            End If
        Next

        'no legal moves on this current position
        If legalMoves = 0 Then
            'king is in check
            If inCheck Then
                'return checkmate score
                Return -mateValue + ply

            Else 'king is not in check
                'return stalemate score
                Return 0
            End If

        End If

        writeHashEntry(alpha, depth, hashFlag)
        Return alpha
    End Function
    Private Function SearchPosition(ByVal depth As Integer)

        'reset nodes counter
        nodes = 0

        'reset follow pv flags
        followPv = 0
        scorePv = 0

        'clear helper data structures for search
        Array.Clear(killerMoves, 0, killerMoves.Length)
        Array.Clear(historyMoves, 0, historyMoves.Length)
        Array.Clear(pvTable, 0, pvTable.Length)
        Array.Clear(pvLength, 0, pvLength.Length)

        'clear hash table
        ClearHashTable()

        Dim alpha As Double = -100000000
        Dim beta As Double = 100000000

        'iterative deepening
        For currentDepth = 1 To depth
            'enable follow pv flag
            followPv = 1

            Dim score As Integer = negamax(alpha, beta, currentDepth)

            If score <= alpha Or score >= beta Then
                alpha = -100000000
                beta = 100000000
                Continue For
            End If

            alpha = score - scoreWindow
            beta = score + scoreWindow
        Next

        'find best move within a given position

        Return pvTable(0, 0)
    End Function

    '// Evaluate function
    Private Function Evaluate()

        Dim score As Integer = 0
        Dim bitboard As ULong

        Dim currentpiece, square As Integer

        For bbPiece = Piece.WhitePawn To Piece.BlackKing
            bitboard = Bitboards(bbPiece)

            While bitboard
                currentpiece = bbPiece
                square = GetlsbIndex(bitboard)
                score += materialScore(currentpiece)

                Select Case currentpiece
                    'evaluate white pieces
                    Case Piece.WhitePawn
                        score += pawnScore(square)
                    Case Piece.WhiteKnight
                        score += knightScore(square)
                    Case Piece.WhiteBishop
                        score += bishopScore(square)
                    Case Piece.WhiteRook
                        score += rookScore(square)
                    Case Piece.WhiteKing
                        score += kingScore(square)

                        'evaluate black pieces
                    Case Piece.BlackPawn
                        score -= pawnScore(square Xor 56)
                    Case Piece.BlackKnight
                        score -= knightScore(square Xor 56)
                    Case Piece.BlackBishop
                        score -= bishopScore(square Xor 56)
                    Case Piece.BlackRook
                        score -= rookScore(square Xor 56)
                    Case Piece.BlackKing
                        score -= kingScore(square Xor 56)
                End Select

                bitboard = bitboard Xor (1UL << square)
            End While
        Next

        If SideToMove = CurrentSide.White Then
            Return score
        Else
            Return -score
        End If

    End Function

    '// Slider attacks
    Private Sub InitaliseMagicNumbers()
        'loop over 64 board squares

        For square = 0 To 63
            RookMagicNumbers(square) = FindMagicNumber(square, RookRelevantBits(square), RookBishop.Rook)
        Next

        For square = 0 To 63
            BishopMagicNumbers(square) = FindMagicNumber(square, BishopRelevantBits(square), RookBishop.Bishop)
        Next
    End Sub
    Private Sub InitialiseSliderAttacks(ByVal bishop As Integer)

        For square = 0 To 63
            Dim attackMask As ULong

            If bishop Then
                attackMask = MaskedBishopMoves(square)
            Else
                attackMask = MaskedRookMoves(square)
            End If

            Dim relevantBits As Integer = CountBits(attackMask)

            Dim occupancyIndicies As Integer = (1 << relevantBits)

            For index As Integer = 0 To occupancyIndicies - 1
                If bishop Then
                    Dim occupancy As ULong = SetOccupancy(index, relevantBits, attackMask)
                    Dim magicIndex As Integer = (occupancy * BishopMagicNumbers(square)) >> (64 - BishopRelevantBits(square))
                    BishopAttacks(square, magicIndex) = GenerateMaskBishopAttacksOnTheFly(square, occupancy)
                Else
                    Dim occupancy As ULong = SetOccupancy(index, relevantBits, attackMask)
                    Dim magicIndex As Integer = (occupancy * RookMagicNumbers(square)) >> (64 - RookRelevantBits(square))
                    RookAttacks(square, magicIndex) = GenerateMaskRookAttacksOnTheFly(square, occupancy)
                End If
            Next


        Next

    End Sub

    Private Function GetBishopAttacks(ByVal square As Integer, ByVal occupancy As ULong)
        occupancy = occupancy And MaskedBishopMoves(square)
        occupancy = occupancy * BishopMagicNumbers(square)
        occupancy = occupancy >> (64 - BishopRelevantBits(square))

        Return BishopAttacks(square, occupancy)
    End Function
    Private Function GetRookAttacks(ByVal square As Integer, ByVal occupancy As ULong)
        occupancy = occupancy And MaskedRookMoves(square)
        occupancy = occupancy * RookMagicNumbers(square)
        occupancy = occupancy >> 64 - RookRelevantBits(square)

        Return RookAttacks(square, occupancy)
    End Function
    Private Function GetQueenAttacks(ByVal square As Integer, ByVal occupancy As ULong)
        Dim queenAttacks As ULong = 0UL

        Dim bishopOccupancies As ULong = occupancy
        Dim rookOccuppancies As ULong = occupancy

        bishopOccupancies = bishopOccupancies And MaskedBishopMoves(square)
        bishopOccupancies = bishopOccupancies * BishopMagicNumbers(square)
        bishopOccupancies = bishopOccupancies >> 64 - BishopRelevantBits(square)

        queenAttacks = BishopAttacks(square, bishopOccupancies)

        rookOccuppancies = rookOccuppancies And MaskedRookMoves(square)
        rookOccuppancies = rookOccuppancies * RookMagicNumbers(square)
        rookOccuppancies = rookOccuppancies >> 64 - RookRelevantBits(square)

        queenAttacks = queenAttacks Or RookAttacks(square, rookOccuppancies)

        Return queenAttacks
    End Function

    '// Check for square attacked
    Private Function IsSquareAttacked(ByVal square As Integer, ByVal side As Boolean) As Boolean
        'attacked by a pawn
        If (side = CurrentSide.White) And (PawnAttacks(1, square) And Bitboards(Piece.WhitePawn)) Then : Return True : End If
        If (side = CurrentSide.Black) And (PawnAttacks(0, square) And Bitboards(Piece.BlackPawn)) Then : Return True : End If

        'attacked by a knight
        If (KnightMoves(square) And If(side = CurrentSide.White, Bitboards(Piece.WhiteKnight), Bitboards(Piece.BlackKnight))) <> 0UL Then : Return True : End If

        'attacked by a bishop
        If (GetBishopAttacks(square, Occupancies(BitboardOccupancies.AllPieces)) And If(side = CurrentSide.White, Bitboards(Piece.WhiteBishop), Bitboards(Piece.BlackBishop))) <> 0UL Then : Return True : End If

        'attacked by a rook
        If (GetRookAttacks(square, Occupancies(BitboardOccupancies.AllPieces)) And If(side = CurrentSide.White, Bitboards(Piece.WhiteRook), Bitboards(Piece.BlackRook))) <> 0UL Then : Return True : End If

        'attacked by a queen
        If (GetQueenAttacks(square, Occupancies(BitboardOccupancies.AllPieces)) And If(side = CurrentSide.White, Bitboards(Piece.WhiteQueen), Bitboards(Piece.BlackQueen))) <> 0UL Then : Return True : End If

        'attacked by a king
        If (KingMoves(square) And If(side = CurrentSide.White, Bitboards(Piece.WhiteKing), Bitboards(Piece.BlackKing))) <> 0UL Then : Return True : End If

        Return False
    End Function

    '// Move Types
    Enum MoveTypes
        allMoves = 0
        onlyCaptures = 1
    End Enum
    Private Function MakeMove(ByVal move As Integer, ByVal moveFlag As Integer) 'This will determine whether the move is legal or not, if it is legal the move will be made, otherwise the board state will be restored and it returns 0

        If moveFlag = MoveTypes.allMoves Then
            '// Quiet Moves

            ' Preserve board state
            Dim savedBoardState As BoardState = CopyBoard()

            'decode all the information about the move
            Dim sourceSquare As Integer = GetMoveSource(move)
            Dim targetSquare As Integer = GetMoveTarget(move)
            Dim pieceMoved As Integer = GetMovePiece(move)
            Dim promotedPiece As Integer = GetMovePromoted(move)
            Dim capture As Integer = GetMoveCapture(move)
            Dim doublePush As Integer = GetMoveDouble(move)
            Dim enpass As Integer = GetMoveEnpassant(move)
            Dim castling As Integer = GetMoveCastling(move)

            ' Move piece, remove the bit and set the bit
            Bitboards(pieceMoved) = Bitboards(pieceMoved) Xor (1UL << sourceSquare)
            Bitboards(pieceMoved) = Bitboards(pieceMoved) Or (1UL << targetSquare)

            ' Remove the piece from the hashkey and add where it moved to
            hashKey = hashKey Xor pieceKeys(pieceMoved, sourceSquare)
            hashKey = hashKey Xor pieceKeys(pieceMoved, targetSquare)

            ' Handling Capture moves
            If capture Then
                'pick up bitboard piece index ranges depending on side

                Dim startPiece, endPiece As Integer

                If SideToMove = CurrentSide.White Then
                    startPiece = Piece.BlackPawn
                    endPiece = Piece.BlackKing
                Else
                    startPiece = Piece.WhitePawn
                    endPiece = Piece.WhiteKing
                End If

                For bbPiece = startPiece To endPiece
                    'if theres a piece on the target square
                    If (Bitboards(bbPiece) And (1UL << targetSquare)) <> 0UL Then
                        'remove the bit from the bitboard
                        Bitboards(bbPiece) = (Bitboards(bbPiece) Xor (1UL << targetSquare))
                        hashKey = hashKey Xor pieceKeys(bbPiece, targetSquare)
                        Exit For
                    End If
                Next
            End If

            'handle pawn promotions
            If promotedPiece Then
                'erase the pawn from the target square
                Bitboards(If(SideToMove, Piece.WhitePawn, Piece.BlackPawn)) = (Bitboards(If(SideToMove, Piece.WhitePawn, Piece.BlackPawn)) Xor (1UL << targetSquare))
                hashKey = hashKey Xor pieceKeys(If(SideToMove, Piece.WhitePawn, Piece.BlackPawn), targetSquare)

                'set up promoted piece on chess board
                Bitboards(promotedPiece) = Bitboards(promotedPiece) Or (1UL << targetSquare)
                hashKey = hashKey Xor pieceKeys(promotedPiece, targetSquare)
            End If

            If enpass Then
                'erase the pawn depending on side to move

                If SideToMove = CurrentSide.White Then
                    Bitboards(Piece.BlackPawn) = Bitboards(Piece.BlackPawn) Xor (1UL << (targetSquare - 8))
                    hashKey = hashKey Xor pieceKeys(Piece.BlackPawn, targetSquare - 8)
                Else
                    Bitboards(Piece.WhitePawn) = Bitboards(Piece.WhitePawn) Xor (1UL << (targetSquare + 8))
                    hashKey = hashKey Xor pieceKeys(Piece.WhitePawn, targetSquare + 8)
                End If

            End If

            If enpassant <> 64 Then
                hashKey = hashKey Xor enpassantKeys(enpassant)
            End If

            'reset enpassant after every move
            enpassant = 64

            'if it is a double push, set either the square ahead/behind to the enpassant depending on the side moving
            If doublePush Then
                If SideToMove = CurrentSide.White Then
                    enpassant = targetSquare - 8
                    hashKey = hashKey Xor enpassantKeys(targetSquare - 8)
                Else
                    enpassant = targetSquare + 8
                    hashKey = hashKey Xor enpassantKeys(targetSquare + 8)
                End If
            End If

            'if the move is a castle, check which square theyve castled to and adjust that bitboard accordingly
            If castling Then
                Select Case targetSquare
                    Case 6
                        Bitboards(Piece.WhiteRook) = (Bitboards(Piece.WhiteRook) Xor (1UL << 7)) Or (1UL << 5)
                        'remove the rooks current position from the hashkey and add it to the new castle position
                        hashKey = hashKey Xor pieceKeys(Piece.WhiteRook, 7)
                        hashKey = hashKey Xor pieceKeys(Piece.WhiteRook, 5)
                    Case 2
                        Bitboards(Piece.WhiteRook) = (Bitboards(Piece.WhiteRook) Xor (1UL)) Or (1UL << 3)
                        hashKey = hashKey Xor pieceKeys(Piece.WhiteRook, 0)
                        hashKey = hashKey Xor pieceKeys(Piece.WhiteRook, 3)
                    Case 62
                        Bitboards(Piece.BlackRook) = (Bitboards(Piece.BlackRook) Xor (1UL << 63)) Or (1UL << 61)
                        hashKey = hashKey Xor pieceKeys(Piece.BlackRook, 63)
                        hashKey = hashKey Xor pieceKeys(Piece.BlackRook, 61)
                    Case 58
                        Bitboards(Piece.BlackRook) = (Bitboards(Piece.BlackRook) Xor (1UL << 56)) Or (1UL << 59)
                        hashKey = hashKey Xor pieceKeys(Piece.BlackRook, 56)
                        hashKey = hashKey Xor pieceKeys(Piece.BlackRook, 59)
                End Select
            End If

            'update castling rights

            hashKey = hashKey Xor castleKeys(castle)

            castle = castle And CastlingRightsTable(sourceSquare)
            castle = castle And CastlingRightsTable(targetSquare)

            hashKey = hashKey Xor castleKeys(castle)

            'update occupancies
            Array.Clear(Occupancies, 0, 3)

            'loop over white pieces bitboards
            For bbPiece = Piece.WhitePawn To Piece.WhiteKing
                Occupancies(BitboardOccupancies.AllWhitePieces) = Occupancies(BitboardOccupancies.AllWhitePieces) Or Bitboards(bbPiece)
            Next

            'loop over black pieces bitboards
            For bbPiece = Piece.BlackPawn To Piece.BlackKing
                Occupancies(BitboardOccupancies.AllBlackPieces) = Occupancies(BitboardOccupancies.AllBlackPieces) Or Bitboards(bbPiece)
            Next

            'update both side occupancies
            Occupancies(BitboardOccupancies.AllPieces) = Occupancies(BitboardOccupancies.AllWhitePieces) Or Occupancies(BitboardOccupancies.AllBlackPieces)

            'change side
            SideToMove = Not SideToMove

            hashKey = hashKey Xor sideKey

            'make sure king is not in check
            If IsSquareAttacked(If(SideToMove = CurrentSide.White, GetlsbIndex(Bitboards(Piece.BlackKing)), GetlsbIndex(Bitboards(Piece.WhiteKing))), SideToMove) Then
                'take move back
                TakeBack(savedBoardState)

                'return illegal move
                Return 0
            Else
                'return legal move

                Return 1
            End If

        Else
            '// Capture Moves
            If GetMoveCapture(move) Then
                Return MakeMove(move, MoveTypes.allMoves)
            Else
                '// Move is not a capture, so don't make move (return 0)
                Return 0
            End If
        End If


    End Function
    Private Sub GenerateMoves(ByRef moveList As MoveList) 'This will generate every possible pseudo legal move in the current board state
        ReDim moveList.moves(255)

        Dim sourceSquare, targetSquare As Integer
        Dim bitboard, attacks As ULong
        Dim currentPiece As Integer = Piece.WhitePawn

        While currentPiece <= Piece.BlackKing
            bitboard = Bitboards(currentPiece)

            'white pawns and white king castling moves
            If SideToMove = CurrentSide.White Then

                'white pawn
                If currentPiece = Piece.WhitePawn Then
                    While bitboard <> 0UL
                        sourceSquare = GetlsbIndex(bitboard)
                        targetSquare = sourceSquare + 8

                        If (Not (targetSquare < 0)) And ((Occupancies(BitboardOccupancies.AllPieces) And (1UL << targetSquare)) = 0UL) Then


                            'pawn promotion
                            If sourceSquare >= 48 And sourceSquare <= 55 Then
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteKnight, 0, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteBishop, 0, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteRook, 0, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteQueen, 0, 0, 0, 0))
                            Else
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                                'double push, starting rank
                                If (sourceSquare >= 8 And sourceSquare <= 15) And ((Occupancies(BitboardOccupancies.AllPieces) And (1UL << (targetSquare + 8))) = 0UL) Then
                                    AddMove(moveList, EncodeMove(sourceSquare, targetSquare + 8, currentPiece, 0, 0, 1, 0, 0))
                                End If

                            End If

                        End If

                        attacks = PawnAttacks(0, sourceSquare) And Occupancies(BitboardOccupancies.AllBlackPieces)

                        While attacks <> 0UL
                            targetSquare = GetlsbIndex(attacks)

                            If sourceSquare >= 48 And sourceSquare <= 55 Then
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteKnight, 1, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteBishop, 1, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteRook, 1, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.WhiteQueen, 1, 0, 0, 0))
                            Else
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                            End If

                            attacks = attacks Xor (1UL << targetSquare)
                        End While

                        If enpassant <> 64 Then
                            Dim enpassantAttacks As ULong = PawnAttacks(0, sourceSquare) And (1UL << enpassant)

                            If enpassantAttacks <> 0UL Then
                                Dim targetEnpassant As Integer = GetlsbIndex(enpassantAttacks)
                                AddMove(moveList, EncodeMove(sourceSquare, targetEnpassant, currentPiece, 0, 1, 0, 1, 0))
                            End If
                        End If

                        bitboard = bitboard Xor (1UL << sourceSquare)
                    End While
                End If

                If currentPiece = Piece.WhiteKing Then
                    sourceSquare = GetlsbIndex(Bitboards(Piece.WhiteKing))

                    'king side castling is available
                    If (castle And CastlingRights.wk) Then
                        'make sure squares between king and king's rook are empty

                        If ((3UL << 5) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then
                            'make sure king and f1  squares arent under attack

                            If (Not IsSquareAttacked(4, CurrentSide.Black)) And (Not IsSquareAttacked(5, CurrentSide.Black)) Then
                                AddMove(moveList, EncodeMove(4, 6, currentPiece, 0, 0, 0, 0, 1))
                            End If

                        End If
                    End If

                    'queen side castling is available
                    If (castle And CastlingRights.wq) Then

                        'make sure squares between king and queens's rook are empty
                        If ((7UL << 1) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then

                            'make sure king and d1  squares arent under attack
                            If (Not IsSquareAttacked(4, CurrentSide.Black)) And (Not IsSquareAttacked(3, CurrentSide.Black)) Then
                                AddMove(moveList, EncodeMove(4, 2, currentPiece, 0, 0, 0, 0, 1))
                            End If

                        End If
                    End If

                End If


            Else 'black side to move

                'black pawn
                If currentPiece = Piece.BlackPawn Then
                    While bitboard <> 0UL
                        sourceSquare = GetlsbIndex(bitboard)
                        targetSquare = sourceSquare - 8

                        If (Not (targetSquare < 0)) And ((Occupancies(BitboardOccupancies.AllPieces) And (1UL << targetSquare)) = 0UL) Then

                            'pawn promotion
                            If sourceSquare >= 8 And sourceSquare <= 15 Then
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackKnight, 0, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackBishop, 0, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackRook, 0, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackQueen, 0, 0, 0, 0))
                            Else
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                                'double push, starting rank
                                If (sourceSquare >= 48 And sourceSquare <= 55) And ((Occupancies(BitboardOccupancies.AllPieces) And (1UL << (targetSquare - 8))) = 0UL) Then
                                    AddMove(moveList, EncodeMove(sourceSquare, targetSquare - 8, currentPiece, 0, 0, 1, 0, 0))
                                End If

                            End If

                        End If

                        attacks = PawnAttacks(1, sourceSquare) And Occupancies(BitboardOccupancies.AllWhitePieces)

                        While attacks <> 0UL
                            targetSquare = GetlsbIndex(attacks)

                            If sourceSquare >= 8 And sourceSquare <= 15 Then
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackKnight, 1, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackBishop, 1, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackRook, 1, 0, 0, 0))
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, Piece.BlackQueen, 1, 0, 0, 0))
                            Else
                                AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                            End If

                            attacks = attacks Xor (1UL << targetSquare)
                        End While

                        If enpassant <> 64 Then
                            Dim enpassantAttacks As ULong = PawnAttacks(1, sourceSquare) And (1UL << enpassant)

                            If enpassantAttacks <> 0UL Then
                                Dim targetEnpassant As Integer = GetlsbIndex(enpassantAttacks)
                                AddMove(moveList, EncodeMove(sourceSquare, targetEnpassant, currentPiece, 0, 1, 0, 1, 0))
                            End If
                        End If

                        bitboard = bitboard Xor (1UL << sourceSquare)
                    End While
                End If


                If currentPiece = Piece.BlackKing Then
                    sourceSquare = GetlsbIndex(Bitboards(Piece.BlackKing))

                    'king side castling is available
                    If (castle And CastlingRights.bk) Then
                        'make sure squares between king and king's rook are empty

                        If ((3UL << 61) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then

                            'make sure king and f8  squares arent under attack
                            If (Not IsSquareAttacked(60, CurrentSide.White)) And (Not IsSquareAttacked(61, CurrentSide.White)) Then
                                AddMove(moveList, EncodeMove(60, 62, currentPiece, 0, 0, 0, 0, 1))
                            End If

                        End If
                    End If

                    'queen side castling is available
                    If (castle And CastlingRights.bq) Then

                        'make sure squares between king and queens's rook are empty
                        If ((7UL << 57) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then

                            'make sure king and d8  squares arent under attack
                            If (Not IsSquareAttacked(60, CurrentSide.White)) And (Not IsSquareAttacked(59, CurrentSide.White)) Then
                                AddMove(moveList, EncodeMove(60, 58, currentPiece, 0, 0, 0, 0, 1))
                            End If

                        End If
                    End If
                End If
            End If

            '//Knight moves

            If (SideToMove = CurrentSide.White And currentPiece = Piece.WhiteKnight) Or (SideToMove = CurrentSide.Black And currentPiece = Piece.BlackKnight) Then
                While bitboard <> 0UL
                    sourceSquare = GetlsbIndex(bitboard)

                    '// Init piece attacks
                    attacks = KnightMoves(sourceSquare) And (If(SideToMove, Not Occupancies(BitboardOccupancies.AllWhitePieces), Not Occupancies(BitboardOccupancies.AllBlackPieces)))

                    '// loop over target squares available
                    While attacks
                        targetSquare = GetlsbIndex(attacks)

                        'quiet move
                        If ((1UL << targetSquare) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                        Else
                            'capture move
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                        End If

                        attacks = attacks Xor (1UL << targetSquare)
                    End While

                    bitboard = bitboard Xor (1UL << sourceSquare)
                End While
            End If

            '//Bishop moves

            If (SideToMove = CurrentSide.White And currentPiece = Piece.WhiteBishop) Or (SideToMove = CurrentSide.Black And currentPiece = Piece.BlackBishop) Then
                While bitboard <> 0UL
                    sourceSquare = GetlsbIndex(bitboard)

                    '// Init piece attacks
                    attacks = (GetBishopAttacks(sourceSquare, Occupancies(BitboardOccupancies.AllPieces)) And (If(SideToMove, Not Occupancies(BitboardOccupancies.AllWhitePieces), Not Occupancies(BitboardOccupancies.AllBlackPieces))))

                    '// loop over target squares available
                    While attacks
                        targetSquare = GetlsbIndex(attacks)

                        'quiet move
                        If ((1UL << targetSquare) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                        Else
                            'capture move
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                        End If

                        attacks = attacks Xor (1UL << targetSquare)
                    End While

                    bitboard = bitboard Xor (1UL << sourceSquare)
                End While
            End If

            '//Rook moves

            If (SideToMove = CurrentSide.White And currentPiece = Piece.WhiteRook) Or (SideToMove = CurrentSide.Black And currentPiece = Piece.BlackRook) Then
                While bitboard <> 0UL
                    sourceSquare = GetlsbIndex(bitboard)

                    '// Init piece attacks
                    attacks = (GetRookAttacks(sourceSquare, Occupancies(BitboardOccupancies.AllPieces)) And (If(SideToMove, Not Occupancies(BitboardOccupancies.AllWhitePieces), Not Occupancies(BitboardOccupancies.AllBlackPieces))))

                    '// loop over target squares available
                    While attacks
                        targetSquare = GetlsbIndex(attacks)

                        'quiet move
                        If ((1UL << targetSquare) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                        Else
                            'capture move
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                        End If

                        attacks = attacks Xor (1UL << targetSquare)
                    End While

                    bitboard = bitboard Xor (1UL << sourceSquare)
                End While
            End If

            '//Queen moves

            If (SideToMove = CurrentSide.White And currentPiece = Piece.WhiteQueen) Or (SideToMove = CurrentSide.Black And currentPiece = Piece.BlackQueen) Then
                While bitboard <> 0UL
                    sourceSquare = GetlsbIndex(bitboard)

                    '// Init piece attacks
                    attacks = (GetQueenAttacks(sourceSquare, Occupancies(BitboardOccupancies.AllPieces)) And (If(SideToMove, Not Occupancies(BitboardOccupancies.AllWhitePieces), Not Occupancies(BitboardOccupancies.AllBlackPieces))))

                    '// loop over target squares available
                    While attacks
                        targetSquare = GetlsbIndex(attacks)

                        'quiet move
                        If ((1UL << targetSquare) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                        Else
                            'capture move
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                        End If

                        attacks = attacks Xor (1UL << targetSquare)
                    End While

                    bitboard = bitboard Xor (1UL << sourceSquare)
                End While
            End If

            '//King moves

            If (SideToMove = CurrentSide.White And currentPiece = Piece.WhiteKing) Or (SideToMove = CurrentSide.Black And currentPiece = Piece.BlackKing) Then
                While bitboard <> 0UL
                    sourceSquare = GetlsbIndex(bitboard)

                    '// Init piece attacks
                    attacks = (KingMoves(sourceSquare) And (If(SideToMove, Not Occupancies(BitboardOccupancies.AllWhitePieces), Not Occupancies(BitboardOccupancies.AllBlackPieces))))

                    '// loop over target squares available
                    While attacks
                        targetSquare = GetlsbIndex(attacks)

                        'quiet move
                        If ((1UL << targetSquare) And Occupancies(BitboardOccupancies.AllPieces)) = 0UL Then
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 0, 0, 0, 0))
                        Else
                            'capture move
                            AddMove(moveList, EncodeMove(sourceSquare, targetSquare, currentPiece, 0, 1, 0, 0, 0))
                        End If

                        attacks = attacks Xor (1UL << targetSquare)
                    End While

                    bitboard = bitboard Xor (1UL << sourceSquare)
                End While
            End If

            currentPiece += 1
        End While
    End Sub

    Private Function EncodeMove(ByVal source, ByVal target, ByVal piece, ByVal promoted, ByVal capture, ByVal doublePush, ByVal enpassant, ByVal castling)
        Return (source Or (target << 6) Or (piece << 12) Or (promoted << 16) Or (capture << 20) Or (doublePush << 21) Or (enpassant << 22) Or (castling << 23))
    End Function

    '// Move Decoder Macros
    Private Function GetMoveSource(ByVal move)
        Return (move And &H3F)
    End Function
    Private Function GetMoveTarget(ByVal move)
        Return ((move And &HFC0) >> 6)
    End Function
    Private Function GetMovePiece(ByVal move)
        Return ((move And &HF000) >> 12)
    End Function
    Private Function GetMovePromoted(ByVal move)
        Return ((move And &HF0000) >> 16)
    End Function
    Private Function GetMoveCapture(ByVal move)
        Return (move And &HF100000)
    End Function
    Private Function GetMoveDouble(ByVal move)
        Return (move And &HF200000)
    End Function
    Private Function GetMoveEnpassant(ByVal move)
        Return (move And &HF400000)
    End Function
    Private Function GetMoveCastling(ByVal move)
        Return (move And &HF800000)
    End Function

    Structure MoveList
        Dim moves() As Integer
        Dim count As Integer
    End Structure

    Function IndexToCoordinate(ByVal index)
        Dim file, rank As Char
        rank = Chr((index \ 8) + 49)
        file = Chr((index Mod 8) + 97)
        Return (file & rank)
    End Function
    Sub PrintMove(ByVal move As Integer)
        Console.WriteLine("   " & IndexToCoordinate(GetMoveSource(move)) & "      " & IndexToCoordinate(GetMoveTarget(move)) & "       " & GetMovePiece(move) & "        " & GetMovePromoted(move) & "          " & If(GetMoveCapture(move), 1, 0) & "        " & If(GetMoveDouble(move), 1, 0) & "         " & If(GetMoveEnpassant(move), 1, 0) & "           " & If(GetMoveCastling(move), 1, 0))
    End Sub
    Sub PrintMoveList(ByVal moveList As MoveList)
        Console.WriteLine("Source | Target | Piece | Promoted | Capture | Double | Enpassant | Castling")
        For looper = 0 To moveList.count - 1
            PrintMove(moveList.moves(looper))
        Next
        Console.WriteLine("Total Number of Moves: " & moveList.count)
    End Sub

    Private Sub AddMove(ByRef movelist As MoveList, ByVal move As Integer)
        movelist.moves(movelist.count) = move

        movelist.count += 1
    End Sub

    '// "Copy Board" and "Take Back" macros
    Structure BoardState
        Dim Bitboards() As ULong
        Dim Occupancies() As ULong

        Dim SideToMove As Boolean
        Dim Enpassant As Integer
        Dim Castle As Integer
        Dim boardHashKey As ULong
    End Structure

    Private Function CopyBoard()
        Dim currentBoardState As BoardState
        ReDim currentBoardState.Bitboards(12)
        ReDim currentBoardState.Occupancies(3)

        Buffer.BlockCopy(Bitboards, 0, currentBoardState.Bitboards, 0, 104)
        Buffer.BlockCopy(Occupancies, 0, currentBoardState.Occupancies, 0, 24)
        currentBoardState.SideToMove = SideToMove : currentBoardState.Enpassant = enpassant : currentBoardState.Castle = castle : currentBoardState.boardHashKey = hashKey
        Return currentBoardState
    End Function
    Private Sub TakeBack(ByVal savedBoardState As BoardState)
        Buffer.BlockCopy(savedBoardState.Bitboards, 0, Bitboards, 0, 104)
        Buffer.BlockCopy(savedBoardState.Occupancies, 0, Occupancies, 0, 24)
        SideToMove = savedBoardState.SideToMove : enpassant = savedBoardState.Enpassant : castle = savedBoardState.Castle : hashKey = savedBoardState.boardHashKey
    End Sub

    '// Leaf nodes (number of positions reached during the test of the move generator at a given depth)
    Dim nodes As Long = 0

    '// Perft driver
    Sub PerftDriver(ByVal depth As Integer)
        'recursion escape condition
        If depth = 0 Then
            'increment nodes count (count reached positions)
            nodes += 1
            Return
        End If

        Dim currentMoveList As MoveList
        GenerateMoves(currentMoveList)

        For moveCount = 0 To currentMoveList.count - 1
            Dim savedBoardState As BoardState = CopyBoard()

            If MakeMove(currentMoveList.moves(moveCount), 0) = 0 Then
                Continue For
            End If

            '//call perft driver recursively
            PerftDriver(depth - 1)

            TakeBack(savedBoardState)
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '// Generate Piece Attack Tables
        GeneratePawnAttacks(CurrentSide.White, PawnAttacks)
        GeneratePawnAttacks(CurrentSide.Black, PawnAttacks)
        InitialiseSliderAttacks(RookBishop.Bishop)
        InitialiseSliderAttacks(RookBishop.Rook)

        '// Draw the board and the Pieces
        DrawBoard()
        InitialisePieces(defaultPosition)
        DisplayPieces()

        '// Initialise the promotion pieces
        InitialisePromotionBoxes()

        '//Add the current board to the board history
        BoardHistory(0) = CopyBoard()

        '//Initialise the hash keys for everything needed and start the board
        InitialiseRandomKeys()
        hashKey = GenerateHashKey()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        While True

            Dim computermove As Integer = SearchPosition(searchDepth)
            Console.WriteLine(IndexToCoordinate(GetMoveSource(computermove)))
            Console.WriteLine(IndexToCoordinate(GetMoveTarget(computermove)))
            MakeMove(computermove, MoveTypes.allMoves)
            DisplayMove(computermove)
            Me.Refresh()

            CheckForCheckmate()

        End While
    End Sub
End Class