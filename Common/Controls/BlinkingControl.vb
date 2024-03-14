Public Class BlinkingControl

    Private m_BlinkOnBrush As System.Drawing.SolidBrush
    Private m_BlinkOffBrush As System.Drawing.SolidBrush
    Private m_UseBlinkOnColor As Boolean = True
    ' Control properties. This is the interval at which the blinking label
    ' changes its color from on to off or back again, in seconds.

    Private m_BlinkInterval As Integer = 1

    Public Event BlinkStateChanged(ByVal UseBlinkOnColor As Boolean)

    Public Property BlinkInterval() As Integer
        Get
            Return m_BlinkInterval
        End Get

        ' Property has changed. Remember its new value, and set the 
        ' control's timer to use it. 

        Set(ByVal Value As Integer)
            m_BlinkInterval = Value
            myTimer.Interval = m_BlinkInterval * 750
        End Set
    End Property

    ' Handler for our control's internal timer. 

    Private Sub OnTimerExpired(ByVal Source As Object, ByVal e As System.Timers.ElapsedEventArgs)

        ' Toggle the flag the tells the painting code whether to use the 
        ' BlinkOnColor or the BlinkOff color

        If (m_UseBlinkOnColor = True) Then
            m_UseBlinkOnColor = False
        Else
            m_UseBlinkOnColor = True
        End If

        ' Invalidate the control to force a repaint.

        Me.Invalidate()

        ' Fire the blink event to the control's container, in case it 
        ' cares.

        RaiseEvent BlinkStateChanged(m_UseBlinkOnColor)

    End Sub

    ' This function gets called when the control needs painting

    Protected Overrides Sub OnPaint(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pe)

        Dim BrushToUse As System.Drawing.Brush

        ' Choose the brush to use for the text color. If the blink cycle is
        ' currently on, or if we're in design mode (in which case we never
        ' want to blink, select the first brush. Otherwise select the second.

        If (m_UseBlinkOnColor = True Or Me.DesignMode = True) Then
            BrushToUse = m_BlinkOnBrush
        Else
            BrushToUse = m_BlinkOffBrush
        End If

        ' Draw the control's current Text property

        pe.Graphics.DrawString(Me.Text, Me.Font, BrushToUse, 0, 0)
    End Sub

    Private Sub myTimer_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles myTimer.Elapsed

    End Sub
End Class
