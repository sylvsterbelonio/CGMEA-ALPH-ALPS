Namespace FindReplace
    Public Class FindReplaceEventArgs
        Inherits EventArgs
        Private intPosition As Integer
        Private strFindWhat As String
        Private ctrlSource As System.Windows.Forms.Control

        Public ReadOnly Property Position() As Integer
            Get
                Return intPosition
            End Get
        End Property
        Public ReadOnly Property FindWhat() As String
            Get
                Return strFindWhat
            End Get
        End Property
        Public ReadOnly Property Control() As System.Windows.Forms.Control
            Get
                Return ctrlSource
            End Get
        End Property
        Friend Sub New(ByVal ControlIn As System.Windows.Forms.Control, ByVal findWhatIn As String, ByVal PositionIn As Integer)
            ctrlSource = ControlIn
            strFindWhat = findWhatIn
            intPosition = PositionIn
        End Sub
    End Class
End Namespace