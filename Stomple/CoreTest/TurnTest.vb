Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class TurnTest

    <TestMethod()>
    Public Sub NextTurn()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1", "P2"}.ToList)

        'Act
        TI.TurnInfo.NextTurn()
        TI.TurnInfo.NextTurn()
        TI.TurnInfo.NextTurn()

        'Assert
        Assert.IsTrue(TI.TurnInfo.MoveCount = 3)
        Assert.IsTrue(TI.TurnInfo.Turn = 2)
        Assert.IsTrue(TI.CurrentPlayer.PlayerId = 2)
    End Sub

    <TestMethod()>
    Public Sub OpeningMoves()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1"}.ToList)

        'Act
        TI.NewGame()
        Dim moves As Integer = TI.GameBoard.GetMoves(TI.TurnInfo.Turn, New Drawing.Point(-1, -1), TI.CurrentPlayer).Count

        'Assert
        Assert.IsTrue(moves = 24)
    End Sub

    <TestMethod()>
    Public Sub MultiOpeningMoves()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1"}.ToList)

        'Act - remove 4 outside pieces
        TI.NewGame()
        TI.GameBoard.ClearPiece(0, 0)
        TI.GameBoard.ClearPiece(0, TI.GameBoard.BoardWidth - 1)
        TI.GameBoard.ClearPiece(TI.GameBoard.BoardHeight - 1, 0)
        TI.GameBoard.ClearPiece(TI.GameBoard.BoardHeight - 1, TI.GameBoard.BoardWidth - 1)
        Dim moves As Integer = TI.GameBoard.GetMoves(TI.TurnInfo.Turn, New Drawing.Point(-1, -1), TI.CurrentPlayer).Count

        'Assert
        Assert.IsTrue(moves = 20)
    End Sub

    <TestMethod()>
    Public Sub SecondTurnMoves()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1"}.ToList)

        'Act - custom put same pieces and check result
        For r As Integer = 1 To 3
            For c As Integer = 1 To 3
                TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(r - 1, c - 1)) With {.name = TI.CurrentPlayer.PieceName, .Type = Stomple.Core.CellInfo.CellType.Piece})
            Next
        Next
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(0, 0)))
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(1, 1)) With {.name = TI.CurrentPlayer.PieceName, .Type = Stomple.Core.CellInfo.CellType.Player})
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(5, 5)) With {.name = "x", .Type = Stomple.Core.CellInfo.CellType.Piece})
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(6, 6)) With {.name = "x", .Type = Stomple.Core.CellInfo.CellType.Piece})
        Dim moves As Integer = TI.GameBoard.GetMoves(2, New Drawing.Point(1, 1), TI.CurrentPlayer).Count

        'Assert
        Assert.IsTrue(moves = 7)
    End Sub

    <TestMethod()>
    Public Sub HasMoreMoves()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1"}.ToList)

        'Act
        TI.NewGame()
        For i As Integer = 1 To TI.GameBoard.BoardWidth
            TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(0, i - 1)) With {.name = "x", .Type = Stomple.Core.CellInfo.CellType.Piece})
        Next
        Dim movesleft As Integer = TI.GameBoard.MakeMove(New Drawing.Point(0, 0), TI.CurrentPlayer).Count

    End Sub

End Class