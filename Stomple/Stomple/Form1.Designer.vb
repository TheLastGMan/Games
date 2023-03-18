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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GameMap1 = New Stomple.GameMap()
        Me.PlayerView1 = New Stomple.PlayerView()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 64)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "New Board"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GameMap1
        '
        Me.GameMap1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GameMap1.BackColor = System.Drawing.Color.Sienna
        Me.GameMap1.Location = New System.Drawing.Point(156, 12)
        Me.GameMap1.Name = "GameMap1"
        Me.GameMap1.Size = New System.Drawing.Size(472, 616)
        Me.GameMap1.TabIndex = 0
        '
        'PlayerView1
        '
        Me.PlayerView1.Location = New System.Drawing.Point(12, 82)
        Me.PlayerView1.Name = "PlayerView1"
        Me.PlayerView1.Size = New System.Drawing.Size(138, 300)
        Me.PlayerView1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(640, 640)
        Me.Controls.Add(Me.PlayerView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GameMap1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stomple"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GameMap1 As Stomple.GameMap
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PlayerView1 As Stomple.PlayerView

End Class
