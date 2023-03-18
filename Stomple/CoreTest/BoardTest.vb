Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class BoardTest

    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = Value
        End Set
    End Property

    ''' <summary>
    ''' Ensures there are 7 pieces of 7 each
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub BoardPieceCount()
        'Arrange
        Dim pieces As List(Of Stomple.Pieces.IPiece) = Stomple.Pieces.Repository.Pieces

        'Act
        Dim uniquepieces As Integer = pieces.GroupBy(Function(f) f.PieceName).Count
        Dim piececount As Integer = pieces.Where(Function(f) f.Count = 7).Count

        'Assert
        Assert.AreEqual(uniquepieces, 7)
        Assert.AreEqual(piececount, 7)
    End Sub

    <TestMethod()>
    Public Sub BoardValue()
        'Arrange
        Dim BI As New Stomple.Core.StompelBoard()

        'Act
        BI.NewBoard()

        'Assert
        Dim bv As Integer = BI.BoardValue()
        Dim pv As Integer = Stomple.Pieces.Repository.Pieces.Sum(Function(f) (f.Value * f.Count))
        Assert.AreEqual(bv, pv)

    End Sub

    <TestMethod()>
    Public Sub RemovePiece()
        'Arrange
        Dim BI As New Stomple.Core.StompelBoard

        'Act
        BI.NewBoard()
        BI.ClearPiece(0, 0)
        BI.ClearPiece(BI.BoardHeight - 1, BI.BoardWidth - 1)
        Dim res1 As Stomple.Core.CellInfo = BI.GetPiece(0, 0)
        Dim res2 As Stomple.Core.CellInfo = BI.GetPiece(BI.BoardHeight - 1, BI.BoardWidth - 1)

        'Assert
        Assert.IsTrue(res1.Type = Stomple.Core.CellInfo.CellType.Nothing)
        Assert.IsTrue(res1.Type = Stomple.Core.CellInfo.CellType.Nothing)

    End Sub

    <TestMethod()>
    Public Sub AdjacentSameColors()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1"}.ToList)

        'Act - custom put same pieces and check result
        For r As Integer = 1 To 3
            For c As Integer = 1 To 3
                TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(r - 1, c - 1)) With {.name = "x", .Type = Stomple.Core.CellInfo.CellType.Piece})
            Next
        Next
        TI.GameBoard.ClearPiece(0, 0)
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(1, 1)) With {.name = "x", .Type = Stomple.Core.CellInfo.CellType.Player})
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(2, 0)) With {.name = "y", .Type = Stomple.Core.CellInfo.CellType.Piece})
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(2, 2)) With {.name = "y", .Type = Stomple.Core.CellInfo.CellType.Piece})
        Dim moves As Integer = TI.GameBoard.FindAdjacentSameColors(New Drawing.Point(1, 1), "x").Count

        'Assert
        Assert.IsTrue(moves = 5)
    End Sub

    <TestMethod()>
    Public Sub FindPlayerPiece()
        'Arrange
        Dim TI As New Stomple.Core.Info(New String() {"P1"}.ToList)

        'Act
        TI.GameBoard.PutPiece(New Stomple.Core.CellInfo(New Drawing.Point(4, 4)) With {.Type = Stomple.Core.CellInfo.CellType.Player, .name = "P1"})
        Dim pos As Drawing.Point = TI.GameBoard.FindPlayerPiece("P1").Position

        'Assert
        Assert.IsNotNull(pos)
    End Sub

End Class
