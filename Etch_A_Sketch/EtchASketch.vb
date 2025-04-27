'payden hoskins
'Rcet 2265
'spring 2025
'Etch A Sketch
'https://github.com/PaydenHoskins/Etch_A_Sketch.git

Option Explicit On
Option Strict On


Public Class EtchASketch
    Function ForeGround(Optional newColor As Color = Nothing) As Color
        Static _foreColor As Color = Color.Black
        If newColor <> Nothing Then
            _foreColor = newColor
        End If
        Return _foreColor
    End Function
    Sub DrawTanWave()
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim penThird As New Pen(Color.Aquamarine, 5)
        Dim ymax As Integer = CInt(DrawingPictureBox.Height / 2)
        Dim oldX, oldY, newY As Integer
        Dim yOffset As Integer = CInt(DrawingPictureBox.Height / 2)
        oldY = yOffset
        Dim degreesPerPoint As Double = 360 / DrawingPictureBox.Width
        Try
            For x = 0 To DrawingPictureBox.Width
                newY = CInt(ymax * Math.Tan((Math.PI / 180) * (x * degreesPerPoint))) + yOffset
                g.DrawLine(penThird, oldX, oldY, x, newY)
                oldX = x
                oldY = newY
            Next
        Catch ex As Exception
            MsgBox("TAN Overflow, Try again.")
        End Try
        g.Dispose()
    End Sub
    Sub DrawCosWave()
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim penSecond As New Pen(Color.Black, 5)
        Dim ymax As Integer = CInt(DrawingPictureBox.Height / 2)
        Dim oldX, oldY, newY As Integer
        Dim yOffset As Integer = CInt(DrawingPictureBox.Height / 2)
        oldY = DrawingPictureBox.Height
        Dim degreesPerPoint As Double = 360 / DrawingPictureBox.Width
        For x = 0 To DrawingPictureBox.Width
            newY = CInt(ymax * Math.Cos((Math.PI / 180) * (x * degreesPerPoint))) + DrawingPictureBox.Height \ 2
            g.DrawLine(penSecond, oldX, oldY, x, newY)
            oldX = x
            oldY = newY
        Next
    End Sub
    Sub DrawSinWave()
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(Color.Red, 5)
        Dim ymax As Integer = CInt(DrawingPictureBox.Height / 2)
        Dim oldX, oldY, newY As Integer
        Dim yOffset As Integer = CInt(DrawingPictureBox.Height / 2)
        oldY = yOffset
        Dim degreesPerPoint As Double = 360 / DrawingPictureBox.Width
        For x = 0 To DrawingPictureBox.Width
            newY = CInt(ymax * Math.Sin((Math.PI / 180) * (x * degreesPerPoint))) + yOffset
            g.DrawLine(pen, oldX, oldY, x, newY)
            oldX = x
            oldY = newY
        Next
        g.Dispose()
    End Sub
    Sub DrawWithMouse(oldX As Integer, oldY As Integer, newX As Integer, newY As Integer)
        Dim g As Graphics = DrawingPictureBox.CreateGraphics
        Dim pen As New Pen(ForeGround)
        pen.Width = 5
        g.DrawLine(pen, oldX, oldY, newX, newY)
        g.Dispose()
    End Sub
    'Event Handlers
    Private Sub GraphicExamplesForm_MouseMove(sender As Object, e As MouseEventArgs) Handles DrawingPictureBox.MouseMove, DrawingPictureBox.MouseDown
        Static oldX, oldY As Integer
        Me.Text = $"({e.X},{e.Y}) {e.Button.ToString}"
        Select Case e.Button.ToString
            Case "Left"
                DrawWithMouse(oldX, oldY, e.X, e.Y)
            Case "Right"
            Case "Middle"
                DrawWithMouse(oldX, oldY, e.X, e.Y)
        End Select
        oldX = e.X
        oldY = e.Y
    End Sub
    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click, ClearButton.Click
        Try
            My.Computer.Audio.Play(My.Resources.Shaker, AudioPlayMode.Background)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        DrawingPictureBox.Refresh()
    End Sub
    Private Sub ForeGroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorSelectButton.Click, SelectColorToolStripMenuItem.Click
        ColorDialog.ShowDialog()
        ForeGround(ColorDialog.Color)
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
        End
    End Sub
    Private Sub DrawWaveFormButton_Click(sender As Object, e As EventArgs) Handles DrawWaveFormButton.Click, DrawWaveformToolStripMenuItem.Click, DrawWaveFormToolStripMenuItem1.Click
        DrawingPictureBox.Refresh()
        DrawSinWave()
        DrawCosWave()
        DrawTanWave()
    End Sub
End Class
