Imports System.Text

Namespace Maps

    Public Class MapManager

        Private Shared Property Maps As New Dictionary(Of String, String())

        Public Sub New()
            LoadMaps()
        End Sub

        Public Function LoadMaps() As Boolean
            Dim lines As String() = New IO.StreamReader("maps.txt", True).ReadToEnd.Split(vbCrLf)
            For Each mapstring As String In lines
                Dim localmap As String() = mapstring.Trim().Trim(vbCrLf).Split(",")
                AddMap(localmap(0), localmap)
            Next
            Return True
        End Function

        Private Function ParsePoints(ByRef str As String, ByRef piece_type As GameBoard.Pieces.Types) As List(Of IPieceInfo)
            Dim lst As New List(Of IPieceInfo)

            For Each p In str.Split("|")
                Dim pts As String() = p.Split("=")
                If pts.Length = 2 Then
                    'correct
                    Dim pl As New GameBoard.PieceInfo() With {.Location = New Point(pts(0), pts(1)), .Type = piece_type}
                    lst.Add(pl)
                End If
            Next

            Return lst
        End Function

        Private Function JoinPoints(ByRef points As List(Of IPieceInfo)) As String
            Return String.Join("|", points.Where(Function(f) Not (f.Location.X = 2 And f.Location.Y = 2)).Select(Function(f) f.Location.X & "=" & f.Location.Y).ToArray)
        End Function

        Private Function ParseLine(ByRef line As String()) As MapInfo
            Dim mi As New MapInfo()
            With mi
                .name = line(0)
                .difficulty = DirectCast(Byte.Parse(line(1)), GameBoard.Pieces.Difficulty)
                .green = ParsePoints(line(2), GameBoard.Pieces.Types.Green)
                .blue = ParsePoints(line(3), GameBoard.Pieces.Types.Blue)
                .stoppers = ParsePoints(line(4), GameBoard.Pieces.Types.Stopper)
                Dim parts As String() = line(5).Split("=").Where(Function(f) f.Length > 0).ToArray
                If parts.Count > 0 Then
                    .solution = parts.Select(Function(f) DirectCast(Byte.Parse(f), GameBoard.Pieces.Direction))
                End If
            End With
            Return mi
        End Function

        Public Function Save(ByVal name As String, ByRef pieces As List(Of IPieceInfo)) As Boolean
            If MapExists(name) Then
                Dim mapinfo As MapInfo = LoadMap(name)
                mapinfo.blue = pieces.Where(Function(f) f.Type = GameBoard.Pieces.Types.Blue).ToList
                mapinfo.green = pieces.Where(Function(f) f.Type = GameBoard.Pieces.Types.Green).ToList
                mapinfo.stoppers = pieces.Where(Function(f) f.Type = GameBoard.Pieces.Types.Stopper).ToList
                Dim mapval As String() = Maps.Where(Function(f) f.Key = name).Single.Value
                mapval = ParseMap(mapinfo)
                Maps.Remove(name)
                AddMap(name, mapval)
                Export()
                Return True
            End If

            Return False
        End Function

        Private Function Export() As Boolean
            Using SW As New IO.StreamWriter("maps.txt", False)
                For Each mi In Maps
                    SW.WriteLine(String.Join(",", mi.Value))
                Next
            End Using
            Return True
        End Function

        Private Function ParseMap(ByRef mi As MapInfo) As String()
            Dim SB As New StringBuilder
            SB.AppendFormat("{0},", mi.name)
            SB.AppendFormat("{0},", Byte.Parse(mi.difficulty))
            SB.AppendFormat("{0},", JoinPoints(mi.green))
            SB.AppendFormat("{0},", JoinPoints(mi.blue))
            SB.AppendFormat("{0},", JoinPoints(mi.stoppers))
            SB.AppendFormat("{0},", mi.solution)
            Return SB.ToString.Split(",")
        End Function

        Public Function LoadMap(ByVal mapname As String) As MapInfo
            Dim map As MapInfo = ParseLine(Maps.Where(Function(f) f.Key = mapname).Select(Function(f) f.Value).SingleOrDefault)
            Return map
        End Function

        Public Function RemoveMap(ByVal mapname As String) As Boolean
            Maps.Remove(Maps.Where(Function(f) f.Key = mapname).Select(Function(f) f.Key).SingleOrDefault)
            Return True
        End Function

        Public Function MapExists(ByVal name As String) As Boolean
            Dim exists As Boolean = IIf(Maps.Where(Function(f) f.Key = name).Count > 0, True, False)
            Return exists
        End Function

        Private Function AddMap(ByRef key As String, ByRef line As String()) As Boolean
            Maps.Add(key, line)
            Return True
        End Function

    End Class

End Namespace
