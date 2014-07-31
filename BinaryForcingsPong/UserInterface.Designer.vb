<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInterface
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.livesLeft = New System.Windows.Forms.Label()
        Me.scoreLeft = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.scoreRight = New System.Windows.Forms.Label()
        Me.livesRight = New System.Windows.Forms.Label()
        Me.powerUpTimeLeft = New System.Windows.Forms.Label()
        Me.powerUpTimeRight = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Red
        Me.PictureBox1.Location = New System.Drawing.Point(0, 399)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(400, 100)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'livesLeft
        '
        Me.livesLeft.AutoSize = True
        Me.livesLeft.BackColor = System.Drawing.Color.Red
        Me.livesLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.livesLeft.ForeColor = System.Drawing.Color.White
        Me.livesLeft.Location = New System.Drawing.Point(12, 465)
        Me.livesLeft.Name = "livesLeft"
        Me.livesLeft.Size = New System.Drawing.Size(69, 25)
        Me.livesLeft.TabIndex = 0
        Me.livesLeft.Text = "Lives: "
        '
        'scoreLeft
        '
        Me.scoreLeft.AutoSize = True
        Me.scoreLeft.BackColor = System.Drawing.Color.Red
        Me.scoreLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.scoreLeft.ForeColor = System.Drawing.SystemColors.Window
        Me.scoreLeft.Location = New System.Drawing.Point(12, 413)
        Me.scoreLeft.Name = "scoreLeft"
        Me.scoreLeft.Size = New System.Drawing.Size(75, 25)
        Me.scoreLeft.TabIndex = 1
        Me.scoreLeft.Text = "Score: "
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Blue
        Me.PictureBox2.Location = New System.Drawing.Point(397, 399)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(400, 100)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'scoreRight
        '
        Me.scoreRight.AutoSize = True
        Me.scoreRight.BackColor = System.Drawing.Color.Blue
        Me.scoreRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.scoreRight.ForeColor = System.Drawing.Color.White
        Me.scoreRight.Location = New System.Drawing.Point(406, 413)
        Me.scoreRight.Name = "scoreRight"
        Me.scoreRight.Size = New System.Drawing.Size(75, 25)
        Me.scoreRight.TabIndex = 1
        Me.scoreRight.Text = "Score: "
        '
        'livesRight
        '
        Me.livesRight.AutoSize = True
        Me.livesRight.BackColor = System.Drawing.Color.Blue
        Me.livesRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.livesRight.ForeColor = System.Drawing.Color.White
        Me.livesRight.Location = New System.Drawing.Point(406, 465)
        Me.livesRight.Name = "livesRight"
        Me.livesRight.Size = New System.Drawing.Size(69, 25)
        Me.livesRight.TabIndex = 0
        Me.livesRight.Text = "Lives: "
        '
        'powerUpTimeLeft
        '
        Me.powerUpTimeLeft.AutoSize = True
        Me.powerUpTimeLeft.BackColor = System.Drawing.Color.Red
        Me.powerUpTimeLeft.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.powerUpTimeLeft.ForeColor = System.Drawing.Color.White
        Me.powerUpTimeLeft.Location = New System.Drawing.Point(212, 436)
        Me.powerUpTimeLeft.Name = "powerUpTimeLeft"
        Me.powerUpTimeLeft.Size = New System.Drawing.Size(152, 25)
        Me.powerUpTimeLeft.TabIndex = 1
        Me.powerUpTimeLeft.Text = "Power Up Time:"
        '
        'powerUpTimeRight
        '
        Me.powerUpTimeRight.AutoSize = True
        Me.powerUpTimeRight.BackColor = System.Drawing.Color.Blue
        Me.powerUpTimeRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.powerUpTimeRight.ForeColor = System.Drawing.Color.White
        Me.powerUpTimeRight.Location = New System.Drawing.Point(586, 436)
        Me.powerUpTimeRight.Name = "powerUpTimeRight"
        Me.powerUpTimeRight.Size = New System.Drawing.Size(152, 25)
        Me.powerUpTimeRight.TabIndex = 1
        Me.powerUpTimeRight.Text = "Power Up Time:"
        '
        'UserInterface
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 499)
        Me.Controls.Add(Me.livesRight)
        Me.Controls.Add(Me.powerUpTimeRight)
        Me.Controls.Add(Me.scoreRight)
        Me.Controls.Add(Me.livesLeft)
        Me.Controls.Add(Me.powerUpTimeLeft)
        Me.Controls.Add(Me.scoreLeft)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "UserInterface"
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents livesLeft As System.Windows.Forms.Label
    Friend WithEvents scoreLeft As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents scoreRight As System.Windows.Forms.Label
    Friend WithEvents livesRight As System.Windows.Forms.Label
    Friend WithEvents powerUpTimeLeft As System.Windows.Forms.Label
    Friend WithEvents powerUpTimeRight As System.Windows.Forms.Label
End Class
