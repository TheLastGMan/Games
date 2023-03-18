
Public Class Board

    Private _board(,) As CellInfo
    Public ReadOnly BoardWidth As Integer
    Public ReadOnly BoardHeight As Integer

    Public Function ToList() As List(Of CellInfo)
        Dim ret As New List(Of CellInfo)

        For Each itm In _board
            ret.Add(itm)
        Next

        Return ret
    End Function

    Public Sub New(ByVal width As Integer, ByVal height As Integer)
        BoardWidth = width
        BoardHeight = height
        Create()
    End Sub

    Public ReadOnly Property CurrentBoard As CellInfo(,)
        Get
            Return _board
        End Get
    End Property

    ''' <summary>
    ''' fill entire board with empty data
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Create()
        ReDim _board(BoardHeight - 1, BoardWidth - 1)

        For r As Integer = 1 To BoardHeight
            For c As Integer = 1 To BoardWidth
                _board(r - 1, c - 1) = New CellInfo(New Drawing.Point(r - 1, c - 1))
            Next
        Next
    End Sub

    ''' <summary>
    ''' Clears the board
    ''' </summary>
    ''' <remarks>same as Create</remarks>
    Public Sub Clear()
        Create()
    End Sub

    ''' <summary>
    ''' gets the piece at the specified location
    ''' </summary>
    ''' <param name="row">row</param>
    ''' <param name="col">column</param>
    ''' <returns>True / Error</returns>
    ''' <remarks></remarks>
    Public Function GetPiece(ByRef row As Integer, ByRef col As Integer) As CellInfo
        Try
            Return _board(row, col)
        Catch ex As Exception
            Throw New Exception("{" & row & "," & col & "} outside board dimension {" & BoardHeight & "," & BoardWidth & "}")
        End Try
    End Function

    Public Function GetPiece(ByRef point As Drawing.Point) As CellInfo
        Return GetPiece(point.X, point.Y)
    End Function

    ''' <summary>
    ''' puts the piece at the specified location
    ''' </summary>
    ''' <param name="piece">piece</param>
    ''' <returns>True / Error</returns>
    ''' <remarks></remarks>
    Public Function PutPiece(ByRef piece As CellInfo) As Boolean
        Try
            _board(piece.Position.X, piece.Position.Y) = piece
            Return True
        Catch ex As Exception
            Throw New Exception("{" & piece.Position.X & "," & piece.Position.Y & "} outside board dimension {" & BoardHeight & "," & BoardWidth & "}")
        End Try
    End Function

    ''' <summary>
    ''' Clears the piece off the board
    ''' </summary>
    ''' <param name="row">row</param>
    ''' <param name="col">column</param>
    ''' <returns>True / Error</returns>
    ''' <remarks>same as putpiece of zero length</remarks>
    Public Function ClearPiece(ByRef row As Integer, ByRef col As Integer) As Boolean
        Return PutPiece(New CellInfo(New Drawing.Point(row, col)))
    End Function

End Class
