Namespace GameBoard

    Public Class Board

        Public ReadOnly Width As Byte
        Public ReadOnly Height As Byte
        Private _bp As New List(Of IPieceInfo)
        Public ReadOnly Property BoardPieces As List(Of IPieceInfo)
            Get
                Return _bp
            End Get
        End Property

        Public Sub New(ByVal _width As Integer, ByVal _height As Integer)
            Width = _width
            Height = _height
        End Sub

        Public Sub SetPieces(ByVal pts As List(Of IPieceInfo))
            _bp = pts
        End Sub

        Public Function MakeMove(ByRef dir As Pieces.Direction) As BoardResult
            Dim res As New BoardResult
            Dim _pieces As List(Of IPieceInfo) = BoardPieces.Where(Function(f) f.Type = Pieces.Types.Blue Or f.Type = Pieces.Types.Green).ToList

            Dim blues As Integer = BoardPieces.Where(Function(f) f.Type = Pieces.Types.Blue).Count

            If dir = Pieces.Direction.Up Then
                'order by x ASC, y ASC
                _pieces = _pieces.OrderBy(Function(f) f.Location.X).ThenBy(Function(f) f.Location.Y).ToList
            ElseIf dir = Pieces.Direction.Down Then
                'order by x DESC, y ASC
                _pieces = _pieces.OrderByDescending(Function(f) f.Location.X).ThenBy(Function(f) f.Location.Y).ToList
            ElseIf dir = Pieces.Direction.Left Then
                'order by y ASC, x ASC
                _pieces = _pieces.OrderBy(Function(f) f.Location.Y).ThenBy(Function(f) f.Location.X).ToList
            ElseIf dir = Pieces.Direction.Right Then
                'order by y DESC, x ASC
                _pieces = _pieces.OrderByDescending(Function(f) f.Location.Y).ThenBy(Function(f) f.Location.X).ToList
            End If

            For Each p In _pieces
                Dim pt As Point = MovePiece(p.Location, dir)
                If pt.X = -1 Then
                    'remove
                    BoardPieces.Remove(BoardPieces.Where(Function(f) f.Location = p.Location).SingleOrDefault)
                Else
                    p.Location = pt
                End If
            Next

            'check win/loss
            If BoardPieces.Where(Function(f) f.Type = Pieces.Types.Blue).Count < blues Then
                'lost
                res.Lost = True
            ElseIf BoardPieces.Where(Function(f) f.Type = Pieces.Types.Green).Count = 0 Then
                res.Won = True
            End If

            res.Pieces = BoardPieces
            Return res
        End Function

        Private Function MovePiece(ByRef piece As Point, ByRef dir As Pieces.Direction) As Point
            Dim newpt As New Point(piece.X, piece.Y)
            If dir = Pieces.Direction.Up Then
                newpt.X -= 1
            ElseIf dir = Pieces.Direction.Down Then
                newpt.X += 1
            ElseIf dir = Pieces.Direction.Left Then
                newpt.Y -= 1
            ElseIf dir = Pieces.Direction.Right Then
                newpt.Y += 1
            End If

            'check valid location
            Dim isvalidloc As IPieceInfo = BoardPieces.Where(Function(f) f.Location = newpt).FirstOrDefault
            With newpt
                If (.X >= 0 And .X < Height And .Y >= 0 And .Y < Width) And isvalidloc Is Nothing Then
                    'valid, check center
                    If .X = 2 And .Y = 2 Then
                        'center, remove
                        Return New Point(-1, -1)
                    End If
                    'else valid, return next move
                    Return MovePiece(newpt, dir)
                Else
                    'can't be done, return point
                    Return piece
                End If
            End With

        End Function

    End Class

End Namespace
