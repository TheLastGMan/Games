﻿Namespace Player

    Public Class White : Implements IPlayer

        Public ReadOnly Property PieceName As String Implements IPlayer.PieceName
            Get
                Return "W"
            End Get
        End Property

        Public ReadOnly Property order As Byte Implements IPlayer.order
            Get
                Return 0
            End Get
        End Property
    End Class

End Namespace

