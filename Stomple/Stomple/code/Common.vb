Module Common

    Function TempBackColor(ByRef name As String) As Color
        Select Case name
            Case "Bk"
                Return Color.Violet
            Case "B"
                Return Color.Blue
            Case "C"
                Return Color.Cyan
            Case "G"
                Return Color.Green
            Case "W"
                Return Color.White
            Case "Y"
                Return Color.Yellow
            Case "X"
                Return Color.Red
            Case name.StartsWith("P")
                Return Color.Violet
            Case Else
                Return Color.Gray
        End Select
    End Function

End Module
