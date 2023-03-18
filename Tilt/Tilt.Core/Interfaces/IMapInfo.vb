Public Interface IMapInfo

    Property name As String
    Property difficulty As GameBoard.Pieces.Difficulty
    Property green As List(Of IPieceInfo)
    Property blue As List(Of IPieceInfo)
    Property stoppers As List(Of IPieceInfo)
    Property solution As List(Of GameBoard.Pieces.Direction)

End Interface
