<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.DownBtn = New System.Windows.Forms.Button()
        Me.UpBtn = New System.Windows.Forms.Button()
        Me.LeftBtn = New System.Windows.Forms.Button()
        Me.RightBtn = New System.Windows.Forms.Button()
        Me.ResetBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GameMap1 = New Tilt.GameMap()
        Me.SuspendLayout()
        '
        'DownBtn
        '
        Me.DownBtn.Location = New System.Drawing.Point(64, 266)
        Me.DownBtn.Name = "DownBtn"
        Me.DownBtn.Size = New System.Drawing.Size(48, 48)
        Me.DownBtn.TabIndex = 1
        Me.DownBtn.Text = "Down"
        Me.DownBtn.UseVisualStyleBackColor = True
        '
        'UpBtn
        '
        Me.UpBtn.Location = New System.Drawing.Point(64, 212)
        Me.UpBtn.Name = "UpBtn"
        Me.UpBtn.Size = New System.Drawing.Size(48, 48)
        Me.UpBtn.TabIndex = 2
        Me.UpBtn.Text = "Up"
        Me.UpBtn.UseVisualStyleBackColor = True
        '
        'LeftBtn
        '
        Me.LeftBtn.Location = New System.Drawing.Point(10, 243)
        Me.LeftBtn.Name = "LeftBtn"
        Me.LeftBtn.Size = New System.Drawing.Size(48, 48)
        Me.LeftBtn.TabIndex = 3
        Me.LeftBtn.Text = "<<"
        Me.LeftBtn.UseVisualStyleBackColor = True
        '
        'RightBtn
        '
        Me.RightBtn.Location = New System.Drawing.Point(118, 243)
        Me.RightBtn.Name = "RightBtn"
        Me.RightBtn.Size = New System.Drawing.Size(48, 48)
        Me.RightBtn.TabIndex = 4
        Me.RightBtn.Text = ">>"
        Me.RightBtn.UseVisualStyleBackColor = True
        '
        'ResetBtn
        '
        Me.ResetBtn.Location = New System.Drawing.Point(42, 38)
        Me.ResetBtn.Name = "ResetBtn"
        Me.ResetBtn.Size = New System.Drawing.Size(92, 32)
        Me.ResetBtn.TabIndex = 5
        Me.ResetBtn.Text = "Reset"
        Me.ResetBtn.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(91, 382)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 24)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Next"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(10, 382)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 24)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Previous"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(172, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 7)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 24)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "E"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GameMap1
        '
        Me.GameMap1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GameMap1.Location = New System.Drawing.Point(172, 38)
        Me.GameMap1.Name = "GameMap1"
        Me.GameMap1.Size = New System.Drawing.Size(480, 480)
        Me.GameMap1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 530)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ResetBtn)
        Me.Controls.Add(Me.RightBtn)
        Me.Controls.Add(Me.LeftBtn)
        Me.Controls.Add(Me.UpBtn)
        Me.Controls.Add(Me.DownBtn)
        Me.Controls.Add(Me.GameMap1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GameMap1 As Tilt.GameMap
    Friend WithEvents DownBtn As System.Windows.Forms.Button
    Friend WithEvents UpBtn As System.Windows.Forms.Button
    Friend WithEvents LeftBtn As System.Windows.Forms.Button
    Friend WithEvents RightBtn As System.Windows.Forms.Button
    Friend WithEvents ResetBtn As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button

End Class
