<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlinkingControl
    Inherits System.Windows.Forms.Control

    Public Sub New()
        MyBase.New()

        InitializeComponent()

        ' Hook up handler function for timer, and set timer variables

        AddHandler myTimer.Elapsed, AddressOf OnTimerExpired
        myTimer.AutoReset = True
        myTimer.Interval = 1000
        myTimer.Enabled = True

        ' Create brushes used for drawing label text

        m_BlinkOnBrush = New System.Drawing.SolidBrush(Me.ForeColor)
        m_BlinkOffBrush = New System.Drawing.SolidBrush(Me.BackColor)
    End Sub

    'Control overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Control Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  Do not modify it
    ' using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.myTimer = New System.Timers.Timer
        CType(Me.myTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'myTimer
        '
        Me.myTimer.Enabled = True
        Me.myTimer.SynchronizingObject = Me
        CType(Me.myTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents myTimer As System.Timers.Timer 

End Class

