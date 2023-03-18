Public Interface IGameMap

    Event PlacePiece(ByRef pt As Drawing.Point)
    Event PlayerInfo(ByRef pi As Core.PlayerInfo)

    Sub PaintBoard(ByRef board As Stomple.Core.StompelBoard)

    Sub HightlightCells(ByRef pts As List(Of Drawing.Point))

End Interface
