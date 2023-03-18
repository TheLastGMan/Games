Public Class Form1

    Private TI As New Stomple.Core.Info(New String() {"P1", "P2"}.ToList)
    Private isloaded As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        newgame()
        isloaded = True
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Dim min As Integer = Math.Min(Me.Width, Me.Height - 25)
        Me.Size = New Size(min, min + 25)
        GameMap1.PaintBoard(TI.GameBoard)
        If isloaded Then
            'GameMap1.HightlightCells(TI.GameBoard.GetMoves(TI.TurnInfo.Turn, TI.GameBoard.FindPlayerPiece(TI.CurrentPlayer.PlayerName).Position, TI.CurrentPlayer))
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        newgame()
    End Sub

    Private Sub PlayerInfo(ByRef pi As Core.PlayerInfo) Handles GameMap1.PlayerInfo
        pi = TI.FindPlayer(pi.PlayerName)
    End Sub

    Private Sub PlacePiece(ByRef pt As Drawing.Point) Handles GameMap1.PlacePiece
        Dim moves = TI.GameBoard.MakeMove(pt, TI.CurrentPlayer)

        GameMap1.PaintBoard(TI.GameBoard)
        If moves.Count > 0 Then
            GameMap1.HightlightCells(moves)
        Else
NT:
            MsgBox("next turn")
            TI.TurnInfo.NextTurn()

            'set player
            PlayerView1.SetActivePlayer(TI.CurrentPlayer)

            'check win
            If TI.TurnInfo.Turn > 1 Then
                With TI.GameBoard.CheckWin(TI.CurrentPlayer)
                    If .IsWinner Then
                        MsgBox(TI.CurrentPlayer.PlayerName & " WINS " & .Points & " POINTS!")
                        TI.CurrentPlayer.TotalPoints += .Points
                        newgame(True)
                        Exit Sub
                    End If
                End With
            End If

            Dim point As Point
            'check turn
            If TI.TurnInfo.Turn = 1 Then
                MsgBox("First Move")
                point = New Point(-1, -1)
            Else
                point = TI.GameBoard.FindPlayerPiece(TI.CurrentPlayer.PlayerName).Position
            End If

            Dim available_moves = TI.GameBoard.GetMoves(TI.TurnInfo.Turn, point, TI.CurrentPlayer)
            If available_moves.Count > 0 Then
                'continue
                GameMap1.HightlightCells(available_moves)
            Else
                MsgBox("No More Moves Available")
                'remove piece from board
                TI.GameBoard.ClearPiece(point.X, point.Y)
                GameMap1.PaintBoard(TI.GameBoard)
                GoTo NT
            End If

        End If

    End Sub

    Private Sub newgame(Optional ByVal SavePoints As Boolean = False)
        TI.NewGame(SavePoints)
        GameMap1.PaintBoard(TI.GameBoard)
        GameMap1.HightlightCells(TI.GameBoard.GetMoves(1, New Point(-1, -1), TI.CurrentPlayer))
        PlayerView1.SetPlayers(TI.Players)
    End Sub

End Class
