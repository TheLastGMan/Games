Namespace Maps

    Public Class MapInfo : Implements IMapInfo

        Public Property blue As List(Of IPieceInfo) Implements IMapInfo.blue

        Public Property difficulty As GameBoard.Pieces.Difficulty Implements IMapInfo.difficulty

        Public Property green As List(Of IPieceInfo) Implements IMapInfo.green

        Public Property name As String Implements IMapInfo.name

        Public Property stoppers As List(Of IPieceInfo) Implements IMapInfo.stoppers

        Public Property solution As List(Of GameBoard.Pieces.Direction) Implements IMapInfo.solution

    End Class

End Namespace
