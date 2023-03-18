Public Class EditMenu

    Public Event Save(ByRef level_name As String)
    Public Event Delete(ByRef level_name As String)
    Public Event Cancel()
    Public Event GetName(ByRef level_name As String)

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'save
        RaiseEvent Save(MapName.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'cancel
        RaiseEvent Cancel()
    End Sub

    Private Sub EditMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RaiseEvent GetName(MapName.Text)

        Difficulty.BeginUpdate()
        Difficulty.Items.Clear()
        For Each diff In System.Enum.GetNames(GetType(Core.GameBoard.Pieces.Difficulty))
            Difficulty.Items.Add(diff)
        Next
        Difficulty.EndUpdate()
        Difficulty.SelectedText = "Beginner"
        Difficulty.Enabled = False

    End Sub

End Class
