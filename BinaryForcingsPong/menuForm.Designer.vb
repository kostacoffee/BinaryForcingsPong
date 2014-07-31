<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class menuForm
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
        Me.startGame = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.highScoreLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'startGame
        '
        Me.startGame.Location = New System.Drawing.Point(54, 9)
        Me.startGame.Name = "startGame"
        Me.startGame.Size = New System.Drawing.Size(75, 23)
        Me.startGame.TabIndex = 0
        Me.startGame.Text = "Start Game"
        Me.startGame.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Instructions"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'highScoreLabel
        '
        Me.highScoreLabel.AutoSize = True
        Me.highScoreLabel.Location = New System.Drawing.Point(12, 76)
        Me.highScoreLabel.Name = "highScoreLabel"
        Me.highScoreLabel.Size = New System.Drawing.Size(100, 13)
        Me.highScoreLabel.TabIndex = 1
        Me.highScoreLabel.Text = "Current High Score:"
        '
        'menuForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(186, 100)
        Me.Controls.Add(Me.highScoreLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.startGame)
        Me.Name = "menuForm"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents startGame As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents highScoreLabel As System.Windows.Forms.Label
End Class
