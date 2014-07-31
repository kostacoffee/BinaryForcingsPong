Public Class menuForm

    Private Sub startGame_Click(sender As Object, e As EventArgs) Handles startGame.Click
        UserInterface.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim message As String = "For Player 1, use WASD. For Player 2, use Arrow Keys"
        message += vbCrLf + vbCrLf
        message += "The closer you are to your opponent's goal" + vbCrLf + "and the closer the ball is to the middle of the goal," + vbCrLf + "the more points you will get!"
        MessageBox.Show(message, "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub menuForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim file = My.Computer.FileSystem.OpenTextFileReader("highScore.txt")
        highScoreLabel.Text += file.ReadLine()
        file.Close()
    End Sub
End Class