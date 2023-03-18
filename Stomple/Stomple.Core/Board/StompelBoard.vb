Imports System.Drawing

Public Class StompelBoard : Inherits Board

    Public Sub New()
        MyBase.New(7, 7)
    End Sub

    ''' <summary>
    ''' Creates a new game board
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub NewBoard()
        For r As Integer = 1 To BoardHeight
            For c As Integer = 1 To BoardWidth
                Dim pi = Pieces.Repository.GetPiece()
                Dim ci As New CellInfo(New Point(r - 1, c - 1))
                With ci
                    .name = pi.PieceName
                    .value = pi.Value
                    .Type = CellInfo.CellType.Piece
                End With
                PutPiece(ci)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Calculates the boards current value
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function BoardValue() As Integer
        Return Me.ToList.Where(Function(f) f.Type = CellInfo.CellType.Piece).Sum(Function(f) f.value)
    End Function

    ''' <summary>
    ''' check if you are the only player left
    ''' </summary>
    ''' <param name="playerinfo">Players Info</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckWin(ByVal playerinfo As PlayerInfo) As WinInfo
        Dim WI As New WinInfo

        With WI
            Dim cnt As Integer = Me.ToList.Where(Function(f) f.Type = CellInfo.CellType.Player).Count()
            If cnt = 1 Then
                'player has won, get points
                .IsWinner = True
                .Points = BoardValue() + 3 '3pts for winning
            Else
                .IsWinner = False
                .Points = 0
            End If
        End With

        Return WI
    End Function

    ''' <summary>
    ''' Finds adjacent cells of the same color
    ''' </summary>
    ''' <param name="position">current x,y coordinate</param>
    ''' <returns>List of matched locations</returns>
    ''' <remarks></remarks>
    Public Function FindAdjacentSameColors(ByRef position As Point, ByVal name As String) As List(Of Point)
        Dim xmin As Integer = position.X - 1
        Dim xmax As Integer = position.X + 1
        Dim ymin As Integer = position.Y - 1
        Dim ymax As Integer = position.Y + 1
        Dim lst = Me.ToList.Where(Function(f) f.Position.X >= xmin And f.Position.X <= xmax _
                    And f.Position.Y >= ymin And f.Position.Y <= ymax) _
                .Where(Function(f) f.Type = CellInfo.CellType.Piece) _
                .Where(Function(f) f.name = name) _
                .Select(Function(f) f.Position).ToList()

        Return lst
    End Function

    ''' <summary>
    ''' Location of the specified piece
    ''' </summary>
    ''' <param name="name">player tag name</param>
    ''' <returns>players CellInfo</returns>
    ''' <remarks></remarks>
    Public Function FindPlayerPiece(ByVal name As String) As CellInfo
        Return Me.ToList.Where(Function(F) F.name = name And F.Type = CellInfo.CellType.Player).FirstOrDefault
    End Function

    ''' <summary>
    ''' makes the specified move
    ''' </summary>
    ''' <param name="newpos">position to move to</param>
    ''' <param name="player">current player tag name</param>
    ''' <returns>List of more moves</returns>
    ''' <remarks></remarks>
    Public Function MakeMove(ByRef newpos As Point, ByRef player As PlayerInfo) As List(Of Point)
        'old position
        Dim playerpiece = FindPlayerPiece(player.PlayerName)
        If playerpiece IsNot Nothing Then
            'clear old position
            ClearPiece(playerpiece.Position.X, playerpiece.Position.Y)
        End If
        'new position info
        Dim newcell = GetPiece(newpos.X, newpos.Y)

        'place new piece
        PutPiece(New CellInfo(New Point(newpos.X, newpos.Y)) With {.name = player.PlayerName, .Type = CellInfo.CellType.Player})

        Return FindAdjacentSameColors(newcell.Position, newcell.name)
    End Function

    ''' <summary>
    ''' List of valid moves based on the current position
    ''' </summary>
    ''' <param name="Turn">Turn of the Game</param>
    ''' <param name="playerpos">current x,y position</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMoves(ByVal Turn As Integer, ByVal playerpos As Point, ByRef playerinfo As PlayerInfo) As List(Of Point)
        Dim lst As New List(Of Point)

        If Turn = 1 Then
            'first turn, get outside row
            lst.AddRange( _
                Me.ToList.Where(Function(f) f.Position.X = 0 Or f.Position.X = BoardWidth - 1 Or f.Position.Y = 0 Or f.Position.Y = BoardHeight - 1) _
                .Where(Function(f) f.Type = CellInfo.CellType.Piece).Select(Function(f) f.Position).ToList() _
                )
        Else
            Dim xmin As Integer = playerpos.X - 1
            Dim xmax As Integer = playerpos.X + 1
            Dim ymin As Integer = playerpos.Y - 1
            Dim ymax As Integer = playerpos.Y + 1
            'two things to do
            '1: get adjacent spaces
            lst.AddRange( _
                Me.ToList.Where(Function(f) f.Position.X >= xmin And f.Position.X <= xmax _
                                    And f.Position.Y >= ymin And f.Position.Y <= ymax) _
                                .Where(Function(f) f.Type = CellInfo.CellType.Piece) _
                                .Select(Function(f) f.Position).ToList()
            )
            '2: get like colors
            Dim piece As String = playerinfo.PieceName
            lst.AddRange( _
                Me.ToList.Where(Function(f) f.name = piece) _
                                .Where(Function(f) f.Type = CellInfo.CellType.Piece) _
                                .Select(Function(f) f.Position).ToList
                )
            '3: get unique, in case of overlap
            lst = lst.Distinct.ToList
        End If

        Return lst
    End Function

End Class
