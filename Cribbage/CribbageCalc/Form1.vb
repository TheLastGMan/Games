Public Class Form1

    Private moves As New List(Of CardDetail)

    Private Sub CalcBtn_Click(sender As Object, e As EventArgs) Handles CalcBtn.Click
        ParseCards(True)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ParseCards(False)
    End Sub

    Public Structure CardDetail
        Public Result As HandResult
        Public Discard As List(Of CardInfo)
    End Structure

    Private Sub ParseCards(Optional ByVal MyCrib As Boolean = False)
        Dim hand As New List(Of CardInfo)
        hand.Add(New CardInfo(CARD1.Text, 1))
        hand.Add(New CardInfo(CARD2.Text, 2))
        hand.Add(New CardInfo(CARD3.Text, 3))
        hand.Add(New CardInfo(CARD4.Text, 4))
        hand.Add(New CardInfo(CARD5.Text, 5))
        hand.Add(New CardInfo(CARD6.Text, 6))
        hand = hand.Where(Function(f) f.FullCard.Length > 0).OrderBy(Function(f) f.Value).ToList
        'recursion
        moves.Clear()
        For i As Integer = 1 To hand.Count
            For j As Integer = (i + 1) To hand.Count
                Dim nh As New List(Of CardInfo)
                nh.AddRange(hand)
                nh.RemoveAt(j - 1)
                nh.RemoveAt(i - 1)
                Dim disc As New List(Of CardInfo)
                disc.Add(hand(i - 1))
                disc.Add(hand(j - 1))
                moves.Add(New CardDetail() With {.Discard = disc, .Result = New HandResult() With {.cards = nh, .Points = HandValue(nh)}})
            Next
        Next

        Dim best As HandResult = GetBestMoves(MyCrib)

        'clear backcolor
        CARD1.BackColor = Color.Red
        CARD2.BackColor = Color.Red
        CARD3.BackColor = Color.Red
        CARD4.BackColor = Color.Red
        CARD5.BackColor = Color.Red
        CARD6.BackColor = Color.Red

        For Each card In best.cards
            Dim TB As TextBox = DirectCast(Controls("CARD" & card.Position), TextBox)
            With TB
                .BackColor = Color.Green
            End With
        Next

        With best.Points
            PairRes.Text = .Pairs
            FifteenRes.Text = .Fifteens
            RunsRes.Text = .Straight.run_count & " (" & .Straight.occured & ")"
            FlushRes.Text = .SameSuit
            TotalRes.Text = .Value
        End With

    End Sub

    Public Function GetBestMoves(Optional ByVal YourCrib As Boolean = False) As HandResult
        Dim movesx As New List(Of IGrouping(Of SByte, CardDetail))
        If Not YourCrib Then
            'subtract 2 hands
            movesx = moves.OrderByDescending(Function(f) f.Result.Points.Value - HandValue(f.Discard).Value).GroupBy(Function(f) f.Result.Points.Value).ToList
        Else
            'add 2 hands
            movesx = moves.OrderByDescending(Function(f) f.Result.Points.Value + HandValue(f.Discard).Value).GroupBy(Function(f) f.Result.Points.Value).ToList
        End If

        Dim moves_final = movesx(0).ToList

        Dim RND As New Random()
        Dim index As Integer = RND.Next(moves_final.Count - 1)
        Dim sel = moves_final(index)
        Return sel.Result
    End Function

    Public Function HandValue(ByRef cards As List(Of CardInfo)) As HandDetail
        Dim HD As New HandDetail

        'check pairs
        HD.Pairs = CheckPairs(cards)

        'check straights
        HD.Straight = CheckStraights(cards)

        'check 15 count
        HD.Fifteens = Check15Sum(cards)

        'check 4 card same suit
        HD.SameSuit = CheckSameSuit(cards)

        Return HD
    End Function

    Public Structure HandDetail
        Public Pairs As Byte
        Public Straight As StraightInfo
        Public Fifteens As Byte
        Public SameSuit As Byte
        Public ReadOnly Property Value As SByte
            Get
                Dim val As Byte = 0

                val += Pairs * 2
                val += Straight.run_count * Straight.occured
                val += Fifteens * 2
                val += SameSuit * 4

                Return IIf(val < 0, 0, val)
            End Get
        End Property
    End Structure

    Public Function CheckStraights(ByRef cards As List(Of CardInfo), Optional ByVal index As Integer = 1, Optional ByVal run As Byte = 2) As StraightInfo
        Dim nr As New List(Of StraightInfo)

        For i As Integer = index To cards.Count - 1
            Dim cv As New StraightInfo() With {.run_count = run, .occured = 1}
            'check if next card is 1 more than current one
            If cards(i).Type = cards(i - 1).Type + 1 Then
                Dim nv As StraightInfo = CheckStraights(cards, i + 1, run + 1)
                If nv.run_count > cv.run_count Then
                    nr.Add(nv)
                ElseIf nv.run_count = cv.run_count Then
                    cv.occured += 1
                    nr.Add(cv)
                Else
                    nr.Add(cv)
                End If
            End If
        Next

        'return top result
        Return nr.Where(Function(f) f.run_count >= 3).OrderByDescending(Function(f) f.run_count).FirstOrDefault
    End Function

    Public Structure StraightInfo
        Public run_count As SByte
        Public occured As SByte
    End Structure

    Public Function CheckPairs(ByRef cards As List(Of CardInfo)) As Byte
        Dim ret As Byte = 0
        For i As Integer = 1 To cards.Count
            For j As Integer = (i + 1) To cards.Count
                If cards(i - 1).Type = cards(j - 1).Type Then
                    ret += 1
                Else
                    Exit For
                End If
            Next
        Next
        Return ret
    End Function

    Public Function Check15Sum(ByRef cards As List(Of CardInfo), Optional ByVal index As Integer = 1, Optional ByVal lastsum As Byte = 0) As Byte
        Dim ret As Byte = 0

        For i As Integer = index To cards.Count
            Dim newvalue As Byte = cards(i - 1).Value + lastsum
            If newvalue < 15 Then
                'get next value
                ret += Check15Sum(cards, i + 1, newvalue)
            ElseIf newvalue = 15 Then
                ret += 1
            End If
        Next

        Return ret
    End Function

    Public Function CheckSameSuit(ByRef cards As List(Of CardInfo)) As Byte
        Dim same As Boolean = True
        For i As Integer = 2 To cards.Count
            If Not cards(i - 2).Suit = cards(i - 1).Suit Then
                same = False
                Exit For
            End If
        Next
        Return IIf(same, 1, 0)
    End Function

    Public Structure HandResult
        Public cards As List(Of CardInfo)
        Public Points As HandDetail
    End Structure

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each ctrl As Control In Controls
            If ctrl.Name.StartsWith("CARD") Then
                ctrl.Text = ""
            End If
        Next
    End Sub
End Class
