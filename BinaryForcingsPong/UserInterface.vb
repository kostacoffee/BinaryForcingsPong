Public Class UserInterface
    Private game As Game
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 800
        Me.Height = 538
        game = New Game(800, 400, Me)
        game.Top = 0
        game.Left = 0
        Me.Controls.Add(game)
        game.Visible = True
        game.BringToFront()
    End Sub

    Private Sub livesLeft_Click(sender As Object, e As EventArgs) Handles livesLeft.Click

    End Sub
End Class