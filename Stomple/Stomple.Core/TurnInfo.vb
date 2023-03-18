Public Class TurnInfo

    Public ReadOnly NumPlayers As Byte
    Public Sub New(ByRef players As Byte)
        NumPlayers = players
    End Sub

    Private _playerindex As Byte
    Public ReadOnly Property PlayerIndex As Byte
        Get
            Return _playerindex
        End Get
    End Property

    Private _movecount As Short
    Public ReadOnly Property MoveCount As Short
        Get
            Return _movecount
        End Get
    End Property

    Private _turn As Short
    Public ReadOnly Property Turn As Short
        Get
            Return _turn
        End Get
    End Property

    Public Sub NextTurn()
        _movecount += 1
        _turn = Math.Ceiling((_movecount + 1) / NumPlayers)
        _playerindex = _movecount Mod NumPlayers
    End Sub

    Public Sub Reset()
        _movecount = 0
        _turn = 1
        _playerindex = 0
    End Sub

End Class
