# Visual Basic Chess Engine
Made in December 2025 by following this playlist here: https://www.youtube.com/playlist?list=PLmN0neTso3Jxh8ZIylk74JpwfiWNI76Cs

Functions:
Uses bitboards, which are much more efficient than 2D arrays, so move generation is a lot faster and this allows a bot to be able to search several moves down.
Uses magic bitboards, which makes slider piece attacks a lot faster, as they can be used in conjuction with the current board state to quickly produce slider piece attacks
Uses a magic De_Bruijn number to quickly find the least significant bit of a bitboard
Negamax algorithm for move searching, so the computer plays the move with the "best worst case scenario"
Alpha-beta pruning to speed up searching, so if e.g. branch 1 is better than branch 2 regardless of what is in branch 2, branch 2 will be cut off and not looked at any further
