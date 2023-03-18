Public Class CellInfo

    Public Property value As UShort
    Public Property Type As CellType
    Public Property name As String
    Public ReadOnly Position As Drawing.Point

    Public Sub New(ByRef Pos As Drawing.Point)
        value = 0
        name = ""
        Type = CellType.Nothing
        Position = Pos
    End Sub

    Public Enum CellType As Byte
        [Nothing] = 0
        Player = 1
        Piece = 2
    End Enum

End Class
