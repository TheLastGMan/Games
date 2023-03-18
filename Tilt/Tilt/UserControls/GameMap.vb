Public Class GameMap

    Private _bh As Integer
    Private _bw As Integer
    Private _editmode As Boolean = False

    Public Sub EnableEdit(ByVal edit As Boolean)
        _editmode = edit

    End Sub

    Public Function GetPieces() As List(Of Core.IPieceInfo)
        Dim pieces As New List(Of Core.IPieceInfo)

        For Each ctrl As Control In Controls
            If ctrl.Name.Contains("-") Then
                Dim valid As Boolean = False
                Dim p As New Core.GameBoard.PieceInfo

                If ctrl.BackColor = Color.LimeGreen Then
                    p.Type = Core.GameBoard.Pieces.Types.Green
                    valid = True
                ElseIf ctrl.BackColor = Color.DarkCyan Then
                    p.Type = Core.GameBoard.Pieces.Types.Blue
                    valid = True
                ElseIf ctrl.BackColor = Color.Gray Then
                    p.Type = Core.GameBoard.Pieces.Types.Stopper
                    valid = True
                End If

                Dim pt As String() = ctrl.Name.Split("-")
                p.Location = New Point(pt(0), pt(1))

                If valid Then
                    pieces.Add(p)
                End If
            End If
        Next

        Return pieces
    End Function

    Public Sub LoadMap(ByRef points As List(Of Core.IPieceInfo))
        For Each ctrl As Control In Me.Controls
            ctrl.BackColor = Color.White
            ctrl.Enabled = _editmode
            If _editmode Then
                AddHandler DirectCast(ctrl, Button).Click, AddressOf BtnClick
            End If
        Next
        'make center black
        Dim mid As String = Math.Floor(_bh / 2) & "-" & Math.Floor(_bw / 2)
        Controls(mid).BackColor = Color.Black

        For Each p In points
            Dim ctrl As String = p.Location.X & "-" & p.Location.Y
            Controls(ctrl).BackColor = GetColor(p.Type)
        Next
    End Sub

    Public Sub SetUp(ByRef board_width As Byte, ByRef board_height As Byte)
        Me.Controls.Clear()

        _bh = board_height
        _bw = board_width

        Dim bw As Integer = Me.Width / board_width
        Dim bh As Integer = Me.Width / board_height
        Dim min As Integer = Math.Min(bw, bh)

        For x As Integer = 1 To board_height
            For y As Integer = 1 To board_width
                Dim btn As New Button()
                With btn
                    .Text = ""
                    .BackColor = Color.White
                    .Name = (x - 1) & "-" & (y - 1)
                    .Width = min
                    .Height = min
                    .Location = New Point((y - 1) * min, (x - 1) * min)
                End With
                Me.Controls.Add(btn)
            Next
        Next
    End Sub

    Private Function GetColor(ByRef type As Core.GameBoard.Pieces.Types) As Color
        Select Case type
            Case Core.GameBoard.Pieces.Types.Stopper
                Return Color.Gray
            Case Core.GameBoard.Pieces.Types.Green
                Return Color.LimeGreen
            Case Core.GameBoard.Pieces.Types.Blue
                Return Color.DarkCyan
            Case Else
                Return Color.White
        End Select
    End Function

    Private Sub BtnClick(sender As Object, e As EventArgs)
        Dim ctrl As Button = DirectCast(sender, Button)
        Select Case ctrl.BackColor
            Case Color.White
                ctrl.BackColor = Color.LimeGreen
            Case Color.LimeGreen
                ctrl.BackColor = Color.DarkCyan
            Case Color.DarkCyan
                ctrl.BackColor = Color.Gray
            Case Color.Gray
                ctrl.BackColor = Color.White
        End Select
    End Sub

End Class
