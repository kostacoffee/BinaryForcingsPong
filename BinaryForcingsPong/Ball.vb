Public Class Ball
    'Class responsible for the ball within the game.
    Private velX As Double
    Private velY As Integer
    Private surface As PictureBox
    Private Const DIAMETER As Integer = 15
    Private playingField As Game
    Private Const MOVE_DISTANCE As Integer = 3
    Private startPos As Point
    Private WithEvents moveTimer As Timer = New Timer
    Private WithEvents wildTimer As Timer = New Timer
    Private wildTime As Integer = 0

    Public Sub New(ByRef playingField As Game)
        moveTimer.Interval = 10
        Me.playingField = playingField
        createSurface()
        setVelocities()
        playingField.Controls.Add(surface)
        startPos = New Point(surface.Left, surface.Top)
        playingField.Controls.Add(surface)
        wildTimer.Interval = 100
    End Sub

    Public Function getX() As Integer
        Return surface.Left
    End Function

    Public Sub startTimer()
        moveTimer.Start()
    End Sub

    Public Sub stopTimer()
        moveTimer.Stop()
    End Sub

    Public Sub setTickInterval(interval As Integer)
        moveTimer.Interval = interval
    End Sub

    Public Sub resetPos()
        surface.Location = startPos
        setVelocities()
    End Sub

    Public Function getBounds() As Rectangle
        Return surface.Bounds()
    End Function

    Public Sub paddleBounce()
        velX *= -1.05
    End Sub

    Public Sub wildBall() Handles wildTimer.Tick
        wildTimer.Start()
        velY += 10
        wildTime += 1
        If (wildTime >= 25) Then
            wildTimer.Stop()
            setVelocities()
            wildTime = 0
        End If
    End Sub

    Private Sub wallBounce()
        velY *= -1
    End Sub

    Private Sub move() Handles moveTimer.Tick
        surface.Left += velX
        surface.Top += velY
        If (surface.Top <= 0 Or surface.Top + DIAMETER >= playingField.Height) Then
            wallBounce()
        End If
    End Sub

    Private Sub setVelocities()
        velX = ((-1) ^ Int(Rnd() * 2)) * MOVE_DISTANCE
        velY = ((-1) ^ Int(Rnd() * 2)) * MOVE_DISTANCE
    End Sub

    Private Sub createSurface()
        Me.surface = New PictureBox With {
            .Image = My.Resources.ballImage,
            .Width = My.Resources.ballImage.Width,
            .Height = My.Resources.ballImage.Height,
            .Top = playingField.Height / 2 - DIAMETER / 2,
            .Left = playingField.Width / 2 - DIAMETER,
            .BackColor = Color.Transparent}
        surface.SetBounds(surface.Left, surface.Top, surface.Width, surface.Height)
    End Sub


End Class
