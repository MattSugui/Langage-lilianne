Partial Public Module Interpreter
    Public Class Lamentation
        Inherits Exception

        Public Sub New()

        End Sub

        Public Sub New(msg As String)
            Message = msg
        End Sub

        Public Sub New(msg As String, err As Long)
            Message = msg
            ErrorCode = err
        End Sub
        Public Overrides ReadOnly Property Message As String
        Public ReadOnly Property ErrorCode As Long

        Public Shared ReadOnly Property Errors As Dictionary(Of Long, String)
            Get
                Return New Dictionary(Of Long, String)(New KeyValuePair(Of Long, String)() {
                                                        New KeyValuePair(Of Long, String)(12, "r")
                                                        })
            End Get
        End Property

    End Class

End Module
