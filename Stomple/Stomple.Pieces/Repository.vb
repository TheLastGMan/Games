Public Class Repository

    Private Shared _Pieces As New List(Of IPiece)
    Private Shared _Players As New List(Of IPlayer)
    Private Shared _RND As New Random()

    Public Shared ReadOnly Property Pieces As List(Of IPiece)
        Get
            Return FindObject(Of IPiece)()
        End Get
    End Property

    Public Shared Sub ReloadPieces()
        _Pieces.Clear()
        For Each itm In Pieces
            For i As Integer = 1 To itm.Count
                _Pieces.Add(itm)
            Next
        Next
    End Sub

    Public Shared Function GetPiece() As IPiece
        If _Pieces.Count = 0 Then
            ReloadPieces()
        End If

        'force a more random-ish result
        For i As Integer = 1 To _RND.Next(10, 50)
            _RND.Next(0, _Pieces.Count - 1)
        Next

        Dim pos As Integer = _RND.Next(0, _Pieces.Count - 1)
        Dim lp As IPiece = _Pieces(pos)
        _Pieces.RemoveAt(pos)
        Return lp
    End Function

    Public Shared Sub ReloadPlayers()
        _Players = FindObject(Of IPlayer)()
    End Sub

    ''' <summary>
    ''' gets a random player piece
    ''' </summary>
    ''' <returns>IPlayer</returns>
    ''' <remarks></remarks>
    Public Shared Function GetPlayerPiece(Optional ByVal reload As Boolean = False) As IPlayer
        If _Players.Count = 0 Or reload Then
            ReloadPlayers()
        End If

        'force a more random-ish result
        For i As Integer = 1 To _RND.Next(10, 50)
            _RND.Next(0, _Players.Count - 1)
        Next

        Dim pos As Integer = _RND.Next(0, _Players.Count - 1)
        Dim lp As IPlayer = _Players(pos)
        _Players.RemoveAt(pos)

        Return lp
    End Function

    Private Shared Function FindObject(Of T)() As List(Of T)
        Dim lst As New List(Of T)

        For Each assembly In Reflection.Assembly.GetExecutingAssembly.GetTypes
            If Not assembly.IsInterface AndAlso GetType(T).IsAssignableFrom(assembly) Then
                lst.Add(DirectCast(Activator.CreateInstance(assembly), T))
            End If
        Next

        Return lst
    End Function

End Class
