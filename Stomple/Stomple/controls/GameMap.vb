Public Class GameMap : Implements IGameMap

    Public Event PlacePiece(ByRef pt As Drawing.Point) Implements IGameMap.PlacePiece
    Public Event PlayerInfo(ByRef pi As Core.PlayerInfo) Implements IGameMap.PlayerInfo

    Public Sub PaintBoard(ByRef board As Stomple.Core.StompelBoard) Implements IGameMap.PaintBoard
        Me.Controls.Clear()
        Dim width As Integer = Math.Floor(Math.Min(Me.Width, Me.Height) / 7)

        Dim startx As Integer = Math.Floor(Me.Width / 2 - (width * 7) / 2)
        Dim starty As Integer = Math.Floor(Me.Height / 2 - (width * 7) / 2)

        For Each cell In board.ToList
            Dim BTN As New Button()
            With BTN
                .Name = PositionToName(cell.Position)
                .Width = width
                .Height = .Width
                .Location = New Drawing.Point(startx + width * cell.Position.Y, starty + width * cell.Position.X)
                .BackColor = TempBackColor(cell.name)
                If cell.Type = Core.CellInfo.CellType.Player Then
                    .Text = cell.name
                    Dim pi As New Core.PlayerInfo With {.PlayerName = cell.name}
                    RaiseEvent PlayerInfo(pi)
                    .ForeColor = TempBackColor(pi.PieceName)
                End If
            End With
            AddHandler BTN.Click, AddressOf Cell_Click
            Controls.Add(BTN)
        Next
        Me.Refresh()
    End Sub

    Public Sub HightlightCells(ByRef pts As List(Of Point)) Implements IGameMap.HightlightCells
        For Each ctrl As Control In Controls
            If ctrl.Text = "X" Then
                ctrl.Text = ""
            End If
        Next
        For Each pt In pts
            Controls(PositionToName(pt)).Text = "X"
        Next
    End Sub

    Private Sub Cell_Click(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        If btn.Text.ToLower = "x" Then
            'valid move
            RaiseEvent PlacePiece(GetPosition(DirectCast(sender, Button).Name))
        End If
    End Sub

    Private Function GetPosition(ByRef str As String) As Point
        Dim pospart As String = str.Substring(1)
        Dim posary As String() = pospart.Split("-")
        Return New Drawing.Point(posary(0), posary(1))
    End Function

    Private Function PositionToName(ByRef pt As Point) As String
        Return "C" & pt.X & "-" & pt.Y
    End Function

End Class
