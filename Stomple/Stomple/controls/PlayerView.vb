Public Class PlayerView : Implements IPlayerView

    Public Sub SetPlayers(ByRef players As List(Of Core.PlayerInfo)) Implements IPlayerView.SetPlayers

        Panel1.Controls.Clear()

        For i As Integer = 1 To players.Count
            Dim p As Core.PlayerInfo = players(i - 1)
            Dim BTN As New Button
            With BTN
                BTN.Text = p.PlayerName & vbCrLf & "points: " & p.TotalPoints
                BTN.BackColor = TempBackColor(p.PieceName)
                BTN.Location = New Point(5, ((i - 1) * 64))
                BTN.Width = 128
                BTN.Height = 60
                BTN.Name = "PC-" & p.PlayerId
            End With
            Panel1.Controls.Add(BTN)
        Next

        SetActivePlayer(players(0))

        Me.Refresh()
    End Sub

    Public Sub SetActivePlayer(ByRef player As Core.PlayerInfo) Implements IPlayerView.SetActivePlayer
        PName.Text = player.PlayerName
    End Sub

    Private Sub PlayerView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
