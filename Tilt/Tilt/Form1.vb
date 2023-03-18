Public Class Form1

    Private MM As New Core.Maps.MapManager()
    Private BB As New Core.GameBoard.Board(5, 5)

    Private WithEvents EM As New EditMenu
    Private ES As New EditScreen

    Private level_name As String = "1"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NewGame(level_name)
    End Sub

    Private Sub NewGame(ByRef level As String)
        GameMap1.SetUp(BB.Width, BB.Height)
        GameMap1.LoadMap(GetMap(level))
        Label1.Text = level
        level_name = Label1.Text
    End Sub

    Private Function GetMap(ByRef name As String) As List(Of Core.IPieceInfo)
        Dim mi As Core.IMapInfo = MM.LoadMap(name)
        Dim pts As New List(Of Core.IPieceInfo)
        pts.AddRange(mi.blue)
        pts.AddRange(mi.green)
        pts.AddRange(mi.stoppers)
        BB.SetPieces(pts)
        Return pts
    End Function

    Private Sub UpBtn_Click(sender As Object, e As EventArgs) Handles UpBtn.Click
        Dim res As Core.GameBoard.BoardResult = BB.MakeMove(Core.GameBoard.Pieces.Direction.Up)
        PostMove(res)
    End Sub

    Private Sub DownBtn_Click(sender As Object, e As EventArgs) Handles DownBtn.Click
        Dim res As Core.GameBoard.BoardResult = BB.MakeMove(Core.GameBoard.Pieces.Direction.Down)
        PostMove(res)
    End Sub

    Private Sub LeftBtn_Click(sender As Object, e As EventArgs) Handles LeftBtn.Click
        Dim res As Core.GameBoard.BoardResult = BB.MakeMove(Core.GameBoard.Pieces.Direction.Left)
        PostMove(res)
    End Sub

    Private Sub RightBtn_Click(sender As Object, e As EventArgs) Handles RightBtn.Click
        Dim res As Core.GameBoard.BoardResult = BB.MakeMove(Core.GameBoard.Pieces.Direction.Right)
        PostMove(res)
    End Sub

    Private Sub PostMove(ByRef BR As Core.GameBoard.BoardResult)
        GameMap1.LoadMap(BR.Pieces)
        If BR.Won Then
            MsgBox("Level Won!")
            NextLevel()
        ElseIf BR.Lost Then
            MsgBox("Level Lost :(")
            GameReset()
        End If
    End Sub

    Private Sub ResetBtn_Click(sender As Object, e As EventArgs) Handles ResetBtn.Click
        GameReset()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        NextLevel()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PreviousLevel()
    End Sub

    Private Sub GameReset()
        NewGame(level_name)
    End Sub

    Private Sub NextLevel()
        If Integer.Parse(level_name) < 40 Then
            NewGame((Integer.Parse(level_name) + 1).ToString)
        End If
    End Sub

    Private Sub PreviousLevel()
        If Integer.Parse(level_name) > 1 Then
            NewGame((Integer.Parse(level_name) - 1).ToString)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'edit
        Try
            ES.Close()
            ES = New EditScreen
            EM = New EditMenu
        Catch ex As Exception

        End Try
        Try
            ES.Controls.Clear()
            ES.Controls.Add(EM)
            ES.Show()
            GameMap1.EnableEdit(True)
            NewGame(level_name)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cancel() Handles EM.Cancel, EM.Disposed
        ES.Close()
        GameMap1.EnableEdit(False)
        NewGame(level_name)
    End Sub

    Private Sub Save(ByRef map_name As String) Handles EM.Save
        level_name = map_name
        'get pieces
        Dim pieces As List(Of Core.IPieceInfo) = GameMap1.GetPieces()
        'save map
        MM.Save(level_name, pieces)

        'close screen, calls cancel on dispose
        ES.Close()
    End Sub

    Private Sub LevelName(ByRef map_name As String) Handles EM.GetName
        map_name = level_name
    End Sub

    Private Sub GameMap1_Load(sender As Object, e As EventArgs) Handles GameMap1.Load

    End Sub
End Class
