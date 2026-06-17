Module PseudoRNG
    Public State As UInteger = 1804289383

    Function GetRandomU32Number() As UInteger
        Dim number As UInteger = State

        number = number Xor number << 13
        number = number Xor number >> 17
        number = number Xor number << 5

        State = number

        Return number
    End Function

    Function GetRandomU64Number() As ULong

        Dim n1, n2, n3, n4 As ULong

        n1 = (CType(GetRandomU32Number(), ULong)) And &HFFFFUL
        n2 = (CType(GetRandomU32Number(), ULong)) And &HFFFFUL
        n3 = (CType(GetRandomU32Number(), ULong)) And &HFFFFUL
        n4 = (CType(GetRandomU32Number(), ULong)) And &HFFFFUL

        Return n1 Or (n2 << 16) Or (n3 << 32) Or (n4 << 48)
    End Function

    Function GenerateMagicNumber() As ULong
        Return GetRandomU64Number() Or GetRandomU64Number() Or GetRandomU64Number()
    End Function
End Module
