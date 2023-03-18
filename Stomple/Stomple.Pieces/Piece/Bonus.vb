Namespace Piece

    Public Class Bonus : Implements IPiece

        Public ReadOnly Property Count As Byte Implements IPiece.Count
            Get
                Return 7
            End Get
        End Property

        Public ReadOnly Property PieceName As String Implements IPiece.PieceName
            Get
                Return "X"
            End Get
        End Property

        Public ReadOnly Property Value As Short Implements IPiece.Value
            Get
                Return 3
            End Get
        End Property

    End Class

End Namespace