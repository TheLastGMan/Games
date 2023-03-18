<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditMenu
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PieceType = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MapName = New System.Windows.Forms.TextBox()
        Me.Difficulty = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.Location = New System.Drawing.Point(3, 162)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(174, 30)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(3, 198)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(174, 30)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "Cancel"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'PieceType
        '
        Me.PieceType.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PieceType.Location = New System.Drawing.Point(8, 5)
        Me.PieceType.Name = "PieceType"
        Me.PieceType.Size = New System.Drawing.Size(169, 31)
        Me.PieceType.TabIndex = 0
        Me.PieceType.Text = "Map Name"
        Me.PieceType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 31)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Difficulty"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MapName
        '
        Me.MapName.Location = New System.Drawing.Point(3, 39)
        Me.MapName.Name = "MapName"
        Me.MapName.Size = New System.Drawing.Size(174, 20)
        Me.MapName.TabIndex = 8
        '
        'Difficulty
        '
        Me.Difficulty.FormattingEnabled = True
        Me.Difficulty.Location = New System.Drawing.Point(3, 97)
        Me.Difficulty.Name = "Difficulty"
        Me.Difficulty.Size = New System.Drawing.Size(174, 21)
        Me.Difficulty.TabIndex = 9
        '
        'EditMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Difficulty)
        Me.Controls.Add(Me.MapName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.PieceType)
        Me.Name = "EditMenu"
        Me.Size = New System.Drawing.Size(180, 231)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PieceType As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MapName As System.Windows.Forms.TextBox
    Friend WithEvents Difficulty As System.Windows.Forms.ComboBox

End Class
