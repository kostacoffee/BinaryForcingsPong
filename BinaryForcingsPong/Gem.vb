Public Class Gem
    'Class responsible for spawning and applying powerups through gems on the game field.
    Delegate Sub powerUp(player As Player)
    Private GemPic As PictureBox
    Private playingField As Game
    Private buff As powerUp = AddressOf emptyBuff

    Public Sub New(playingField As Game)
        Me.playingField = playingField
        makeGem()
    End Sub

    Public Function getBounds() As Rectangle
        Return GemPic.Bounds
    End Function

    Public Sub applyPowerUp(player As Player)
        buff(player)
        playingField.Controls.Remove(GemPic)
        GemPic.Dispose()
        buff = AddressOf emptyBuff
    End Sub

    Private Sub setPowerUp()
        Dim powerUps As powerUp() = {
                                     AddressOf increaseSize,
                                     AddressOf decreaseOpponentSize,
                                     AddressOf increaseSpeed,
                                     AddressOf decreaseOpponentSpeed,
                                     AddressOf reverseBall,
                                     AddressOf wildBall
                                     }
        Dim r As Random = New Random()
        Dim i = r.Next(powerUps.Length)
        buff = powerUps(i)
    End Sub

    Private Sub makeGem()
        Dim r As Random = New Random()
        GemPic = New PictureBox
        GemPic.Image = My.Resources.gem
        GemPic.SetBounds(GemPic.Left, GemPic.Top, My.Resources.gem.Width, My.Resources.gem.Height)
        While True
            Dim i = r.Next(775)
            GemPic.Left = i
            GemPic.Top = r.Next(playingField.Height - My.Resources.gem.Height)
            If (gemDoesNotIntersect()) Then
                Exit While
            End If
        End While
        setPowerUp()
        playingField.Controls.Add(GemPic)
    End Sub

    Private Function gemDoesNotIntersect() As Boolean
        Dim allGems As List(Of Gem) = playingField.getGems()
        For Each Gem In allGems
            If (GemPic.Bounds.IntersectsWith(Gem.getBounds())) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub emptyBuff(Player As Player)
        'keep empty
        'this is a default powerup!
    End Sub

    Private Sub increaseSize(Player As Player)
        Dim paddle As Paddle = Player.getPaddle()
        paddle.setHeight(paddle.getheight + 35)
    End Sub

    Private Sub decreaseOpponentSize(Player As Player)
        Dim opponent = Player.getOpponent.getPaddle()
        opponent.setHeight(opponent.getheight() - 35)
    End Sub

    Private Sub increaseSpeed(Player As Player)
        Dim paddle As Paddle = Player.getPaddle()
        paddle.setSpeed(paddle.getSpeed() + 2, True)
    End Sub

    Private Sub decreaseOpponentSpeed(Player As Player)
        Dim opponentPaddle As Paddle = Player.getOpponent().getPaddle()
        opponentPaddle.setSpeed(opponentPaddle.getSpeed() + 2, True)
    End Sub

    Private Sub reverseBall(Player As Player)
        playingField.getBall().paddleBounce()
        Player.getPaddle.allowToHitBall()
        Player.getOpponent.getPaddle.allowToHitBall()
    End Sub

    Private Sub wildBall(player As Player)
        player.getPaddle.getPlayingField.getBall().wildBall()
    End Sub
End Class
