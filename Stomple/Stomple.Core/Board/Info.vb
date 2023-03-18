Public Class Info

    Private _TI As TurnInfo
    Private _GameBoard As New StompelBoard()
    Private _Players As New List(Of PlayerInfo)
    Private _PlayerCache As List(Of String)

    Public Sub New(ByRef players As List(Of String))
        _PlayerCache = players
        SetUpPlayers()
        _TI = New TurnInfo(_Players.Count)
    End Sub

    Private Sub SetUpPlayers()
        Pieces.Repository.ReloadPlayers()
        _Players.Clear()

        For i As Integer = 1 To _PlayerCache.Count
            Dim pp As New PlayerInfo()
            With pp
                pp.order = i
                pp.PieceName = Pieces.Repository.GetPlayerPiece().PieceName
                pp.PlayerId = i
                pp.PlayerName = "P" & i
            End With
            _Players.Add(pp)
        Next
    End Sub

    Private Sub GetNewPieces()
        Pieces.Repository.ReloadPlayers()
        For Each p In _Players
            p.PieceName = Pieces.Repository.GetPlayerPiece().PieceName
        Next
    End Sub

    Public Sub NewGame(Optional ByVal SavePoints As Boolean = False)
        _TI.Reset()

        If SavePoints Then
            GetNewPieces()
        Else
            SetUpPlayers()
        End If

        _GameBoard.NewBoard()
    End Sub

    Public ReadOnly Property TurnInfo As TurnInfo
        Get
            Return _TI
        End Get
    End Property

    Public ReadOnly Property Players As List(Of PlayerInfo)
        Get
            Return _Players
        End Get
    End Property

    Public ReadOnly Property CurrentPlayer As PlayerInfo
        Get
            Return Players(_TI.PlayerIndex)
        End Get
    End Property

    Public Function FindPlayer(ByVal playername As String) As PlayerInfo
        Return Players.Where(Function(f) f.PlayerName = playername).FirstOrDefault
    End Function

    Public ReadOnly Property GameBoard As StompelBoard
        Get
            Return _GameBoard
        End Get
    End Property

End Class
