Public Class Paddle
    'Class responsible for the Paddle interactions with the game field and the ball
    Private Const BUFF_TIME = 10
    Private Const WIDTH As Integer = 20
    Private Const HEIGHT As Integer = 75
    Private Const ORIGINAL_SPEED As Integer = 5
    Private playingField As Game
    Private allowedToHitBall As Boolean = True
    Private surface As PictureBox
    Delegate Sub Moves()
    Private controls As Dictionary(Of Keys, Moves)
    Private moveAmount As Double = 5
    Private startPos As Point
    Private WithEvents buffTimer As Timer = New Timer()
    Private ticks As Integer = 0
    Private isLeft As Boolean

    Public Sub New(isLeft As Boolean, ByRef playingField As UserControl, ByRef monitorBall As Ball)
        Me.isLeft = isLeft
        Me.playingField = playingField
        setControls(isLeft)
        createSurface(isLeft)
        Me.startPos = New Point(surface.Left, surface.Top)
        buffTimer.Interval = 1000
    End Sub

    Public Function isBuffed() As Boolean
        Return buffTimer.Enabled
    End Function

    Public Function getTimeLeftForPowerup() As Integer
        Return BUFF_TIME - ticks
    End Function

    Public Function getSpeed() As Double
        Return moveAmount
    End Function

    Public Sub setSpeed(newSpeed As Double, isBuff As Boolean)
        moveAmount = newSpeed
        If (isBuff) Then startTimer()
    End Sub

    Public Function getheight() As Integer
        Return HEIGHT
    End Function

    Public Sub setHeight(newHeight As Integer)
        surface.Height = newHeight
        startTimer()
    End Sub

    Public Function getPlayingField() As Game
        Return playingField
    End Function

    Public Function isAllowedToHitBall() As Boolean
        Return allowedToHitBall
    End Function

    Public Sub allowToHitBall()
        allowedToHitBall = True
    End Sub

    Public Sub dissallowToHitBall()
        allowedToHitBall = False
    End Sub

    Public Sub resetPaddle(gameReset As Boolean)
        Dim currentPoint = New Point(surface.Location)
        surface.Dispose()
        createSurface(isLeft)
        surface.Location = currentPoint
        buffTimer.Stop()
        moveAmount = ORIGINAL_SPEED
        allowToHitBall()
        surface.BringToFront()
        If gameReset Then
            surface.Location = startPos
        End If
    End Sub

    Public Sub move(ByRef keys As List(Of Keys))
        For Each key In keys
            If (controls.ContainsKey(key)) Then controls.Item(key)()
        Next
    End Sub

    Private Sub startTimer()
        ticks = 0
        buffTimer.Start()
    End Sub

    Private Sub moveUp()
        If (surface.Top > 0) Then
            surface.Top -= moveAmount
        End If
    End Sub

    Private Sub moveDown()
        If (surface.Top + surface.Height < playingField.Height) Then
            surface.Top += moveAmount
        End If
    End Sub

    Private Sub moveLeft()
        If (surface.Left > 0) Then
            surface.Left -= moveAmount
        End If
    End Sub

    Private Sub moveRight()
        If (surface.Left + surface.Width * 2 < playingField.Width) Then
            surface.Left += moveAmount
        End If
    End Sub

    Public Function getBounds() As Rectangle
        Return surface.Bounds
    End Function

    Private Sub buffTick() Handles buffTimer.Tick
        ticks += 1
        If (ticks >= BUFF_TIME) Then
            resetPaddle(False)
        End If
    End Sub

    Private Sub setControls(isLeft As Boolean)
        controls = New Dictionary(Of Keys, Moves)
        Dim moves As Moves() = {AddressOf moveUp, AddressOf moveDown, AddressOf moveLeft, AddressOf moveRight}
        Dim moveInput As Keys()
        If (isLeft) Then
            moveInput = {Keys.W, Keys.S, Keys.A, Keys.D}
        Else : moveInput = {Keys.Up, Keys.Down, Keys.Left, Keys.Right}
        End If
        For i = 0 To 3
            controls.Add(moveInput(i), moves(i))
        Next
    End Sub

    Private Sub createSurface(isLeft As Boolean)
        surface = New PictureBox With {
            .Width = WIDTH,
            .Height = HEIGHT}
        If isLeft Then
            surface.Location = New Point(50, 100)
            surface.BackColor = Color.Red
        Else
            surface.Location = New Point(playingField.Width - 50, 100)
            surface.BackColor = Color.Blue
        End If
        surface.SetBounds(surface.Left, surface.Top, WIDTH, HEIGHT)
        playingField.Controls.Add(surface)
    End Sub

End Class
