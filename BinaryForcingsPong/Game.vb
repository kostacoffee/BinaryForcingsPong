Public Class Game
    'Main game class
    Private player1 As Player
    Private player2 As Player
    Private ball As Ball
    Private gems As List(Of Gem) = New List(Of Gem)
    Private keysDown As List(Of Keys) = New List(Of Keys)
    Private WithEvents gemCreator As Timer = New Timer()

    Public Sub New(width As Integer, height As Integer, UI As UserInterface)
        InitializeComponent()
        Me.Width = width
        Me.Height = height
        ball = New Ball(Me)
        player1 = New Player(True, Me, ball, UI.livesLeft, UI.scoreLeft, UI.powerUpTimeLeft)
        player2 = New Player(False, Me, ball, UI.livesRight, UI.scoreRight, UI.powerUpTimeRight)
    End Sub

    Public Sub determineWinner()
        Dim highScore As Integer = getCurrentHighScore()
        player1.stopTimer()
        player2.stopTimer()
        ball.stopTimer()
        Dim thisHighScore As Integer
        If (player1.getScore() > player2.getScore()) Then
            announceWinner(player1)
            thisHighScore = player1.getScore()
        Else
            announceWinner(player2)
            thisHighScore = player2.getScore()
        End If
        If (thisHighScore > highScore) Then writeHighScore(thisHighScore)
    End Sub

    Public Sub resetGame(paddleCollision As Boolean)
        clearGems()
        player1.resetPosition()
        player2.resetPosition()
        ball.resetPos()
        generateGems()
        Me.BackColor = Color.White
        If (paddleCollision) Then
            player1.decreaseLives()
            player2.decreaseLives()
        End If
    End Sub

    Public Function getBall() As Ball
        Return ball
    End Function

    Public Function getKeysDown() As List(Of Keys)
        Return keysDown
    End Function

    Public Function getGems() As List(Of Gem)
        Return gems
    End Function

    Private Sub writeHighScore(highScore As Integer)
        Dim file = My.Computer.FileSystem.OpenTextFileWriter("highScore.txt", False)
        file.WriteLine(highScore)
        file.Close()
    End Sub

    Private Sub clearGems()
        For Each gem In gems
            gem.applyPowerUp(player1)
        Next
        gems.Clear()
    End Sub

    Private Function getCurrentHighScore() As Integer
        Dim file = My.Computer.FileSystem.OpenTextFileReader("highScore.txt")
        Dim score = Int(file.ReadLine())
        file.Close()
        Return score
    End Function

    Private Sub game_Load(sender As Object, e As EventArgs) Handles Me.Load
        Randomize()
        Me.BackColor = Color.White
        player1.setOpponent(player2)
        player2.setOpponent(player1)
        player1.startTimer()
        player2.startTimer()
        ball.startTimer()
        generateGems()
        gemCreator.Interval = 250
        gemCreator.Start()
    End Sub

    Private Sub announceWinner(player As Player)
        MessageBox.Show("The winner is " + player.getPlayerName() + " with " + player.getScore.ToString() + " points!")
    End Sub


    Private Sub game_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        keysDown.Remove(e.KeyCode)
    End Sub

    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If (Not keysDown.Contains(keyData)) Then keysDown.Add(keyData)
        Return True
    End Function

    Private Sub generateGems() Handles gemCreator.Tick
        Dim r As Random = New Random()
        If (r.Next(0, 101) < 5) Then
            gems.Add(New Gem(Me))
        End If
    End Sub


End Class