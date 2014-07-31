Public Class Player
    'Class responsible for keeping track of player stats. Constructs Paddle.
    'Note: I wasn't sure whether I should simply construct the paddle within this class, or have the PLayer inherit the Paddle properties. There is quite a lot of redundant code between these two.
    Private Const POINT_SECTION_SPLITTER = 50
    Private score As Integer = 0
    Private scoreLabel As Label
    Private lives As Integer = 5
    Private livesLabel As Label
    Private paddle As Paddle
    Private opponent As Player
    Private monitorBall As Ball
    Private lastHit As Point
    Private powerUpLabel As Label
    Private isLeft As Boolean
    Private playerName As String
    Private WithEvents actionTimer As Timer = New Timer()

    Public Sub New(isLeft As Boolean, ByRef playingField As UserControl, ByRef monitorBall As Ball, livesLabel As Label, scoreLabel As Label, powerUpLabel As Label)
        Me.isLeft = isLeft
        playerName = If(isLeft, "Player 1", "Player 2")
        Me.paddle = New Paddle(isLeft, playingField, monitorBall)
        Me.livesLabel = livesLabel
        Me.livesLabel.Text = "Lives: " + lives.ToString
        Me.scoreLabel = scoreLabel
        Me.scoreLabel.Text = "Score: " + score.ToString
        Me.monitorBall = monitorBall
        Me.powerUpLabel = powerUpLabel
        actionTimer.Interval = 5
        powerUpLabel.Text = "Power Up Time: "
    End Sub

    Public Function getOpponent() As Player
        Return opponent
    End Function

    Public Function getPaddle() As Paddle
        Return paddle
    End Function

    Public Function getPlayerName() As String
        Return playerName
    End Function

    Public Function getScore() As Integer
        Return score
    End Function

    Public Function getLives() As Integer
        Return lives
    End Function

    Public Sub decreaseLives()
        lives -= 1
        livesLabel.Text = "Lives: " + lives.ToString
    End Sub

    Public Sub startTimer()
        actionTimer.Start()
    End Sub

    Public Sub stopTimer()
        actionTimer.Stop()
    End Sub

    Public Sub setTickInterval(interval As Integer)
        actionTimer.Interval = interval
    End Sub

    Public Sub setOpponent(opponent As Player)
        Me.opponent = opponent
    End Sub

    Public Sub resetPosition()
        paddle.resetPaddle(True)
        powerUpLabel.Text = "Power Up Time: "
    End Sub

    Private Sub action() Handles actionTimer.Tick
        paddle.move(paddle.getPlayingField().getKeysDown())
        checkBallCollision()
        checkPlayerCollision()
        checkGoal()
        checkGemPickup()
        If (paddle.isBuffed()) Then powerUpLabel.Text = "Power Up Time: " + paddle.getTimeLeftForPowerup().ToString()
        If (paddle.getTimeLeftForPowerup = 0) Then powerUpLabel.Text = "Power Up Time: "
    End Sub

    Private Sub checkGoal()
        If ((isLeft And monitorBall.getX() >= paddle.getPlayingField.Width) Or (Not isLeft And monitorBall.getX() <= 0)) Then
            score += determineScore()
            scoreLabel.Text = "Score: " + score.ToString
            paddle.getPlayingField.resetGame(False)
        End If
    End Sub

    Private Function determineScore() As Integer
        Dim midY As Integer = paddle.getPlayingField().Height / 2
        Dim distFromMid = midY - (monitorBall.getBounds.Y Mod midY)
        Dim pointDist As Integer = midY - Math.Abs(distFromMid)
        Dim yPoints = 2 ^ (Math.Floor(pointDist / POINT_SECTION_SPLITTER))
        Dim xPoints = 2 ^ ((paddle.getPlayingField.Width - lastHit.X) / 150)
        Return yPoints + xPoints
    End Function

    Private Sub checkGemPickup()
        For Each powerUp In paddle.getPlayingField().getGems()
            If paddle.getBounds.IntersectsWith(powerUp.getBounds) Then
                powerUp.applyPowerUp(Me)
            End If
        Next
    End Sub

    Private Sub checkBallCollision()
        If (paddle.getBounds().IntersectsWith(monitorBall.getBounds()) And paddle.isAllowedToHitBall) Then
            monitorBall.paddleBounce()
            lastHit = If(isLeft, New Point(paddle.getBounds.X, paddle.getBounds.Y), New Point(paddle.getPlayingField.Width - paddle.getBounds().X, paddle.getBounds.Y))
            paddle.dissallowToHitBall()
            opponent.paddle.allowToHitBall()
            paddle.setSpeed(paddle.getSpeed() + 0.15, False)
        End If
    End Sub

    Private Sub checkPlayerCollision()
        If (paddle.getBounds().IntersectsWith(opponent.paddle.getBounds())) Then
            paddle.getPlayingField().resetGame(True)
            livesLabel.Text = "Lives: " + lives.ToString
            If lives = 0 Then
                paddle.getPlayingField.determineWinner()
            End If
        End If
    End Sub

End Class
