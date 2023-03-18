Namespace Piece

    Public Class Blue : Implements IPiece

        Public ReadOnly Property Count As Byte Implements IPiece.Count
            Get
                Return 7
            End Get
        End Property

        Public ReadOnly Property PieceName As String Implements IPiece.PieceName
            Get
                Return "B"
            End Get
        End Property

        Public ReadOnly Property Value As Short Implements IPiece.Value
            Get
                Return 1
            End Get
        End Property

    End Class

End Namespace