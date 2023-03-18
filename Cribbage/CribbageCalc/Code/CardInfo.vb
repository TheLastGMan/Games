Public Class CardInfo

    
    Public Property Position As Byte
    Public Property FullCard As String
    Public Property Face As String
    Public Property Value As Byte
    Public Property Type As CardType
    Public Property Suit As CardSuit

    Public Sub New(ByVal _card As String, ByVal pos As Byte)
        Position = pos
        FullCard = _card.ToUpper
        Face = FullCard.Substring(0, FullCard.Length - 1)
        'suit
        Select Case FullCard.Substring(FullCard.Length - 1)
            Case "D"
                Suit = CardSuit.Diamonds
            Case "H"
                Suit = CardSuit.Hearts
            Case "S"
                Suit = CardSuit.Spades
            Case "C"
                Suit = CardSuit.Clubs
            Case Else
                Throw New Exception("Unknown Suit: " & FullCard.Substring(FullCard.Length - 1))
        End Select
        'card type
        Select Case Face
            Case "X"
                Type = CardType.TEN
            Case "A"
                Type = CardType.A
            Case "J"
                Type = CardType.JACK
            Case "Q"
                Type = CardType.QUEEN
            Case "K"
                Type = CardType.KING
            Case Else
                Type = Byte.Parse(Face)
        End Select
        'value
        If Type > CardType.TEN Then
            Value = 10
        Else
            Value = Type
        End If

    End Sub

    Public Enum CardSuit As Byte
        Hearts
        Spades
        Diamonds
        Clubs
    End Enum

    Public Enum CardType As Byte
        A = 1
        TWO = 2
        THREE = 3
        FOUR = 4
        FIVE = 5
        SIX = 6
        SEVEN = 7
        EIGHT = 8
        NINE = 9
        TEN = 10
        JACK = 11
        QUEEN = 12
        KING = 13
    End Enum

End Class
