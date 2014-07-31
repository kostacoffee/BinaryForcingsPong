Public Class Game
    Private user1 As Player
    Private user2 As Player
    Private ball As Ball

    Private keysDown As List(Of Keys) = New List(Of Keys)

    Public Sub New(width As Integer, height As Integer)
        InitializeComponent()
        Me.Width = width
        Me.Height = height
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim x = New UserControl()
        x = Me.u

        Randomize()
        ball = New Ball(Me)
        user1 = New Player(True, Me, ball)
        user2 = New Player(False, Me, ball)
        user1.setOpponent(user2)
        user2.setOpponent(user1)
        user1.startTimer()
        user2.startTimer()
        ball.startTimer()
    End Sub

    Public Function getKeysDown() As List(Of Keys)
        Return keysDown
    End Function

    Public Sub resetGame(collision As Boolean)

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (Not keysDown.Contains(e.KeyCode)) Then keysDown.Add(e.KeyCode)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        keysDown.Remove(e.KeyCode)
    End Sub
End Class
