Public Class PlayerInfo

    Public Property order As Byte
    Public Property PlayerName As String
    Public Property PlayerId As String
    Public Property PieceName As String
    Public Property HasLost As Boolean = False
    Public Property TotalPoints As Integer = 0
    Public Property PlayerType As Type = Type.Player

    Public Sub New()
    End Sub

    Public Sub New(ByRef _PieceName As String, ByRef _PlayerName As String, ByRef _PlayerId As String, ByRef _order As Byte)
        order = _order
        PlayerName = _PlayerName
        PlayerId = _PlayerId
        PieceName = _PieceName
    End Sub

    Public Enum Type As Byte
        Player = 0
        Computer = 1
    End Enum

End Class
